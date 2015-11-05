using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VmgPortal.Library.Components.Modules;
using VmgPortal.Library.Components.Roles;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Utilities;
using VmgPortal.Library;

namespace VmgPortal.Administrator.Modules
{
	public partial class ModuleControlEdit : AuthenticatedControl
	{
		private int controlId;
		private int moduleId;
		private ArrayList lstFile = new ArrayList();
		private string CheckPath(ModuleInfo module)
		{
			string temp = "/Uploads";
			if (module.ModuleFolder.Length > 0)
			{
				temp = module.ModuleFolder;
				if (temp.LastIndexOf("/") == temp.Length - 1)
					temp += "Uploads/Controls";
				else
					temp += "/Uploads/Controls";
				if (!Directory.Exists(Server.MapPath(temp)))
				{
					try
					{
						Directory.CreateDirectory(Server.MapPath(temp));
					}
					catch (Exception ex)
					{
						Response.Write(ex.Message);
						return "/Uploads";
					}
				}
			}
			return temp;
		}
		
		private void GetFiles(string rootPath, string path)
		{
			string[] files = Directory.GetFiles(path); 
			for (int i = 0; i < files.Length; i++ )
			{
				if(files[i].EndsWith(".ascx"))
				{
					string temp = files[i].Replace(rootPath, string.Empty);
					temp = temp.Replace("\\", "/");
					if (!temp.StartsWith("/")) temp = "/" + temp;
					lstFile.Add(temp);
				}
			}
			string[] folders = Directory.GetDirectories(path);
			for (int i = 0; i < folders.Length; i++)
			{
				if (folders[i] == Server.MapPath("/Modules")) continue;
				if (folders[i] == Server.MapPath("/RadControls")) continue;
				if (folders[i] == Server.MapPath("/Themes")) continue;
				if (folders[i] == Server.MapPath("/Layouts")) continue;
				GetFiles(rootPath,folders[i]);
			}
			lstFile.Sort();
		}
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!CurrentUser.IsSuperAdmin) Response.Redirect(AppEnv.ADMIN_CMD);

			controlId = ConvertUtility.ToInt32(Request.QueryString["cid"]);
			moduleId = ConvertUtility.ToInt32(Request.QueryString["mid"]);
			ModuleInfo module = ModuleController.GetModule(moduleId);
			ModuleControlInfo moduleControl = ModuleControlController.GetModuleControl(controlId);
            if (moduleControl == null)
            {
                this.btnDelete.Visible = false;                
            }
            
            if (module == null)
            {
                module = ModuleController.GetModule(moduleControl.ModuleID);
            }
		    if (module != null)
		    {
			    lblModuleName.Text = module.ModuleName;
			    txtControlIcon.fpUploadDir = CheckPath(module);
		    }            
			
			if (!Page.IsPostBack)
			{
				if(module != null && module.ModuleFolder.Length > 0)
				{
					GetFiles(Server.MapPath("/"), Server.MapPath(module.ModuleFolder));
					dropPath.DataSource = lstFile;
					dropPath.DataBind();
				}
				MiscUtility.FillIndex(dropControlOrder, 30, 1);
				chkControlType.DataSource = RoleController.GetRoles();
				chkControlType.DataBind();
				if (moduleControl == null) return;
				lblModuleName.Text = ModuleController.GetModule(moduleControl.ModuleID).ModuleName;
				txtControlName.Text = moduleControl.ControlName;
                txtControlDescription.Text = moduleControl.ControlDescription;
				txtControlKey.Text = moduleControl.ControlKey;
				MiscUtility.SelectItemFromList(dropPath, moduleControl.ControlPath);
				txtControlIcon.Text = moduleControl.ControlIcon;
				txtControlDescription.Text = moduleControl.ControlDescription;
				chkControlHeader.Checked = moduleControl.ControlHeader;
				MiscUtility.SelectItemFromList(dropControlOrder, moduleControl.ControlOrder.ToString());
                string[] roleList = (moduleControl.ControlRole!=null)?moduleControl.ControlRole.Split("|".ToCharArray()):null;
				MiscUtility.SelectItemFromList(chkControlType, roleList);
			}
		}
		protected void btnUpdate_Click(object sender, EventArgs e)
		{
			try
			{
				
				if (controlId == 0) // add control
				{
					if (txtControlKey.Text != string.Empty && ModuleControlController.CheckExistsControlKey(txtControlKey.Text))
					{
						this.lblUpdateStatus.Text = MiscUtility.MSG_CONTROKEY_EXISTS;
						return;
					}
					ModuleInfo module = ModuleController.GetModule(moduleId);
					if (module == null) return;
					ModuleControlInfo moduleControl = new ModuleControlInfo();
					moduleControl.ModuleID = module.ModuleID;
					moduleControl.ControlName = txtControlName.Text.Trim();
					moduleControl.ControlKey = txtControlKey.Text.Trim();
					moduleControl.ControlPath = dropPath.SelectedValue;
					moduleControl.ControlIcon = txtControlIcon.Text.Trim();
					moduleControl.ControlOrder = ConvertUtility.ToInt32(dropControlOrder.SelectedValue);
					moduleControl.ControlHeader = chkControlHeader.Checked;
					string roleList = "|";
					foreach (ListItem item in chkControlType.Items)
					{
						if (item.Selected)
							roleList += item.Value + "|";
					}
					if (roleList.Length < 2) roleList = string.Empty;
					moduleControl.ControlTitle = txtControlTitle.Text;
					moduleControl.ControlRole = roleList;
					moduleControl.ControlDescription = txtControlDescription.Text.Trim();

					ModuleControlController.AddModuleControl(moduleControl);
				}
				else // update control
				{
					ModuleControlInfo moduleControl = ModuleControlController.GetModuleControl(controlId);
					moduleControl.ControlName = txtControlName.Text.Trim();
                    moduleControl.ControlDescription = txtControlDescription.Text;
					moduleControl.ControlKey = txtControlKey.Text.Trim();
					moduleControl.ControlPath = dropPath.SelectedValue;
					moduleControl.ControlIcon = txtControlIcon.Text.Trim();
					moduleControl.ControlOrder = ConvertUtility.ToInt32(dropControlOrder.SelectedValue);
					string roleList = "|";
					foreach (ListItem item in chkControlType.Items)
					{
						if (item.Selected)
							roleList += item.Value + "|";
					}
					//if (roleList.Length < 2) roleList = string.Empty;
					moduleControl.ControlRole = roleList;
					moduleControl.ControlDescription = txtControlDescription.Text.Trim();
					moduleControl.ControlHeader = chkControlHeader.Checked;
					ModuleControlController.UpdateModuleControl(moduleControl);
				}
                this.lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;
			}
			catch (Exception ex)
			{
				Response.Write(ex.Message);
			}
		}
		protected void btnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				ModuleControlController.DeleteModuleControl(controlId);
                this.lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;
			}
			catch (Exception ex)
			{
				Response.Write(ex.Message);
			}
		}
		protected void btnCancel_Click(object sender, EventArgs e)
		{
			this.txtControlDescription.Text = string.Empty;
			this.txtControlIcon.Text = string.Empty;
			this.txtControlKey.Text = string.Empty;
			this.txtControlName.Text = string.Empty;
			dropPath.SelectedIndex = -1;
			this.txtControlTitle.Text = string.Empty;
		}
	}
}