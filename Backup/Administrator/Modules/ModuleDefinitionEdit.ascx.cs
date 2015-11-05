using System;
using System.Data;
using System.Web.UI.WebControls;
using VmgPortal.Library.Components.Modules;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Utilities;
using VmgPortal.Library;

namespace VmgPortal.Administrator.Modules
{
	public partial class ModuleDefinitionEdit : AuthenticatedControl
	{
		private int moduleId;
		private ModuleInfo module;
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!CurrentUser.IsSuperAdmin) Response.Redirect(AppEnv.ADMIN_CMD);

			moduleId = ConvertUtility.ToInt32(Request.QueryString["mid"]);
			module = ModuleController.GetModule(moduleId);
			if (!Page.IsPostBack)
			{
				if (module == null)
				{
					this.btnAddControl.Visible = false;
					this.btnDelete.Visible = false;
				}
				this.btnDelete.Attributes.Add("onclick", MiscUtility.MSG_DELETE_CONFIRM);
			}
		}
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			if (module != null)
			{
				txtID.Text = module.ModuleID.ToString();
				txtModuleName.Text = module.ModuleName;
				txtModuleTitle.Text = module.ModuleTitle;
				txtModuleDescription.Text = module.ModuleDescription;
				txtModuleFolder.Text = module.ModuleFolder;
				DataTable dtControls = ModuleControlController.GetModuleControls(moduleId);
				dtgModuleControls.DataSource = dtControls;
				dtgModuleControls.DataBind();
			}
		}
		protected void btnUpdate_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid) return;
			try
			{
				if (moduleId == 0)//add new module
				{
					ModuleInfo newmodule = new ModuleInfo();
					newmodule.ModuleName = txtModuleName.Text.Trim();
					newmodule.ModuleTitle = txtModuleTitle.Text.Trim();
					newmodule.ModuleDescription = txtModuleDescription.Text.Trim();
					newmodule.ModuleFolder = txtModuleFolder.Text.Trim();
					txtID.Text = ModuleController.AddModule(newmodule).ToString();
					this.btnAddControl.Visible = true;
					this.btnDelete.Visible = true;
				}
				else//update module
				{
					module = ModuleController.GetModule(moduleId);
					if (module == null) return;
					module.ModuleName = txtModuleName.Text.Trim();
					module.ModuleTitle = txtModuleTitle.Text.Trim();
					module.ModuleDescription = txtModuleDescription.Text.Trim();
					module.ModuleFolder = txtModuleFolder.Text.Trim();
					ModuleController.UpdateModule(module);
					txtID.Text = module.ModuleID.ToString();
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
				ModuleController.DeleteModule(moduleId);
                this.lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;
			}
			catch (Exception ex)
			{
				Response.Write(ex.Message);
			}
		}
		protected void dtgModuleControls_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			switch (e.CommandName)
			{
				case "editcontrol":
					Response.Redirect(AppEnv.AdminUrlParams("modulecon") + "&cid=" + e.CommandArgument.ToString());
					break;
				case "deletecontrol":
					try
					{
						ModuleControlController.DeleteModuleControl(ConvertUtility.ToInt32(e.CommandArgument));
                        this.lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;
					}
					catch (Exception ex)
					{
						Response.Write(ex.Message);
					}
					break;
			}
		}
		protected void dtgModuleControls_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
                VmgPortal.WebControls.ButtonRoleDelete btnDeleteControl = (VmgPortal.WebControls.ButtonRoleDelete)e.Row.FindControl("btnDeleteControl");
				btnDeleteControl.Attributes.Add("onclick", MiscUtility.MSG_DELETE_CONFIRM);
			    DataRowView row = (DataRowView)e.Row.DataItem;
			    Label lblControlPath = (Label)e.Row.FindControl("lblControlPath");
                lblControlPath.Text = ConvertUtility.ToString(row["ControlPath"]).Replace(txtModuleFolder.Text.Trim(),"/");
			}
		}
		protected void btnAddControl_Click(object sender, EventArgs e)
		{
			Response.Redirect(AppEnv.AdminUrlParams("modulecon") + "&mid=" + ConvertUtility.ToInt32(txtID.Text));
		}
        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    this.txtID.Text = string.Empty;
        //    this.txtModuleDescription.Text = string.Empty;
        //    this.txtModuleFolder.Text = string.Empty;
        //    this.txtModuleName.Text = string.Empty;
        //    this.txtModuleTitle.Text = string.Empty;
        //}
    
	}
}