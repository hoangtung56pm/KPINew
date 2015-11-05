using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using VmgPortal.Library.Components.Portal;
using VmgPortal.Library.Components.Commands;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Components.Users;
using VmgPortal.Library.Utilities;
using VmgPortal.Library;
using VmgPortal.Library.Components;

namespace VmgPortal.Administrator.Users
{
	public partial class UserPermision : AuthenticatedControl
	{
        private DataTable dtCommand = null;
		private int userId;
        //private int portalId = 0;
		protected void Page_Load(object sender, EventArgs e)
		{
			userId = ConvertUtility.ToInt32(Request.QueryString["uid"]);
			if (!Page.IsPostBack)
			{
                //Fill portals

                dropPortal.Items.Clear();
                if (!CurrentUser.IsSuperAdmin)
                {
                    PortalController.LoadPortalsForUserID(dropPortal.Items, CurrentUser.UserID);
                }
                else
                {
                    PortalController.LoadPortals(dropPortal.Items);
                }
                dropPortal.SelectedValue = AppEnv.PortalId().ToString();

				UserInfo user = UserController.GetUser(userId);
				if (user == null) return;
				lblUsername.Text = user.Username;
			}
		}
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
            //Fill commands
            lstCommands.Items.Clear();
           
            if (!CurrentUser.IsSuperAdmin)
            {
                CommandController.FillToListBox(lstCommands.Items, CommandController.GetCommandsForUserByPortalID(CurrentUser.UserID, ConvertUtility.ToInt32(dropPortal.SelectedValue)), 0, CurrentUser.IsSuperAdmin);
            }
		    else
            {
                CommandController.FillToListBox(lstCommands.Items, CommandController.GetCommands(), 0, CurrentUser.IsSuperAdmin);
            }
            
            DataTable dtUserCommands = CommandController.GetCommandsForUserNotGroup(userId, ConvertUtility.ToInt32(dropPortal.SelectedValue));
            foreach (DataRow row in dtUserCommands.Rows)
            {
                if (lstCommands.Items.FindByValue(row["CommandID"].ToString()) != null)
                    lstCommands.Items.FindByValue(row["CommandID"].ToString()).Selected = true;
            }

            DataTable dtReturnCommand = new DataTable();

            dtReturnCommand.Columns.Add("CommandID", typeof(String));
            dtReturnCommand.Columns.Add("PortalID", typeof(String));
            dtReturnCommand.Columns.Add("UserID", typeof(String));
            dtReturnCommand.Columns.Add("CommandParentID", typeof(String));
            dtReturnCommand.Columns.Add("CommandName", typeof(String));
            dtReturnCommand.Columns.Add("Level", typeof(String));
            dtReturnCommand.Columns.Add("Role_View", typeof(String));
            dtReturnCommand.Columns.Add("Role_Add", typeof(String));
            dtReturnCommand.Columns.Add("Role_Update", typeof(String));
            dtReturnCommand.Columns.Add("Role_Delete", typeof(String));
            dtReturnCommand.Columns.Add("UseForWeb", typeof(String));
            dtReturnCommand.Columns.Add("UseForWap", typeof(String));
            dtReturnCommand.Columns.Add("UseForSMS", typeof(String));
            dtReturnCommand.Columns.Add("UseForXzone", typeof(String));

            dtCommand = dtUserCommands;
            DataTable _dtReturnCommand = UserController.BuildRecursiveUserPermission(dtUserCommands, dtReturnCommand, userId, ConvertUtility.ToInt32(dropPortal.SelectedValue));
            dgrUserRole.DataSource = _dtReturnCommand;
            dgrUserRole.DataBind();
            
		}
		protected void btnUpdate_Click(object sender, EventArgs e)
        {
            
			try
			{
				foreach (ListItem item in lstCommands.Items)
				{
					if (item.Selected && item.Value != "0")
					{
                        UserController.AddCommandToUserByPortalID(Convert.ToInt32(item.Value), userId, ConvertUtility.ToInt32(dropPortal.SelectedValue));
					}
					else
					{
                        UserController.RemoveCommandFromUserByPortalID(Convert.ToInt32(item.Value), userId, ConvertUtility.ToInt32(dropPortal.SelectedValue));
					}
				}
                lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;
                new DataCaching().RemoveAll();
			}
			catch (Exception ex)
			{
				Response.Write(ex.Message);
			}
            lblUpdateStatus1.Text = ""; 
		}
        protected void dgrUserRole_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                int user_id = ConvertUtility.ToInt32(e.Item.Cells[0].Text);
                int command_id = ConvertUtility.ToInt32(e.Item.Cells[1].Text);
                int portal_id = ConvertUtility.ToInt32(e.Item.Cells[2].Text);
                CheckBox chkView = (CheckBox)e.Item.FindControl("chkView");
                CheckBox chkAdd = (CheckBox)e.Item.FindControl("chkAdd");
                CheckBox chkUpdate = (CheckBox)e.Item.FindControl("chkEdit");
                CheckBox chkDelete = (CheckBox)e.Item.FindControl("chkDelete");
                CheckBox chkWeb = (CheckBox)e.Item.FindControl("chkWeb");
                CheckBox chkWap = (CheckBox)e.Item.FindControl("chkWap");
                CheckBox chkSMS = (CheckBox)e.Item.FindControl("chkSMS");
                CheckBox chkXzone = (CheckBox)e.Item.FindControl("chkXzone");
                try
                {
                    DataTable dtUserCommands = CommandController.GetCommandsForUserNotGroup(user_id,ConvertUtility.ToInt32(dropPortal.SelectedValue));
                    DataRow[] rowItems = dtUserCommands.Select("CommandParentID = " + command_id);

                    foreach (DataRow row in rowItems)
                    {
                        UserController.UpdateUserPermissionByPortalID(ConvertUtility.ToInt32(row["UserID"]), ConvertUtility.ToInt32(row["CommandID"]), portal_id, true, true, true, true, chkView.Checked, true, true, true);
                    }
                    try
                    {
                        UserController.UpdateUserPermissionByPortalID(user_id, command_id, portal_id, chkWeb.Checked, chkWap.Checked, chkSMS.Checked, chkXzone.Checked, chkView.Checked, chkAdd.Checked, chkUpdate.Checked, chkDelete.Checked);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;
                }
                catch
                {
                    lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_ERROR;
                }
            }
        }
        protected void dgrUserRole_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            DataRowView row = (DataRowView)e.Item.DataItem;

            Label lblCmdName = (Label)e.Item.FindControl("lblCmdName");
            lblCmdName.Text = row["CommandName"].ToString();

            CheckBox chkView = (CheckBox)e.Item.FindControl("chkView");
            CheckBox chkAdd = (CheckBox)e.Item.FindControl("chkAdd");
            CheckBox chkEdit = (CheckBox)e.Item.FindControl("chkEdit");
            CheckBox chkDelete = (CheckBox)e.Item.FindControl("chkDelete");
            CheckBox chkWeb = (CheckBox)e.Item.FindControl("chkWeb");
            CheckBox chkWap = (CheckBox)e.Item.FindControl("chkWap");
            CheckBox chkSMS = (CheckBox)e.Item.FindControl("chkSMS");
            CheckBox chkXzone = (CheckBox)e.Item.FindControl("chkXzone");

            chkWeb.Checked = ConvertUtility.ToBoolean(row["UseForWeb"].ToString());
            chkWap.Checked = ConvertUtility.ToBoolean(row["UseForWap"].ToString());
            chkSMS.Checked = ConvertUtility.ToBoolean(row["UseForSMS"].ToString());
            chkXzone.Checked = ConvertUtility.ToBoolean(row["UseForXzone"].ToString());
            DataRow[] _row = dtCommand.Select("CommandParentID = " + row["CommandID"]);

            if (_row.Length > 0)
            {
                chkView.Checked = ConvertUtility.ToBoolean(row["Role_View"].ToString());
                chkAdd.Visible = false;
                chkEdit.Visible = false;
                chkDelete.Visible = false;
            }
            else
            {
                if (ConvertUtility.ToInt32(row["CommandParentID"]) == 0)
                {
                    chkView.Checked = ConvertUtility.ToBoolean(row["Role_View"].ToString());
                    chkAdd.Visible = false;
                    chkEdit.Visible = false;
                    chkDelete.Visible = false;
                }
                else
                {
                    chkView.Checked = ConvertUtility.ToBoolean(row["Role_View"].ToString());
                    chkAdd.Checked = ConvertUtility.ToBoolean(row["Role_Add"].ToString());
                    chkEdit.Checked = ConvertUtility.ToBoolean(row["Role_Update"].ToString());
                    chkDelete.Checked = ConvertUtility.ToBoolean(row["Role_Delete"].ToString());
                }

            }
           
            Button btnUpdate = (Button)e.Item.FindControl("btnUpdate");
            btnUpdate.Text = "Cập nhật";
            btnUpdate.OnClientClick = "javascript:return confirm('Bạn đã chắc chắn chưa' )";
        }

        protected void btnUpdateAll_Click(object sender, EventArgs e)
        {
            
            try
            {
                foreach (DataGridItem item in dgrUserRole.Items)
                {
                    int user_id = ConvertUtility.ToInt32(item.Cells[0].Text);
                    int command_id = ConvertUtility.ToInt32(item.Cells[1].Text);
                    int portal_id = ConvertUtility.ToInt32(item.Cells[2].Text);
                    CheckBox chkView = (CheckBox) item.FindControl("chkView");
                    CheckBox chkAdd = (CheckBox) item.FindControl("chkAdd");
                    CheckBox chkUpdate = (CheckBox) item.FindControl("chkEdit");
                    CheckBox chkDelete = (CheckBox) item.FindControl("chkDelete");
                    CheckBox chkWeb = (CheckBox)item.FindControl("chkWeb");
                    CheckBox chkWap = (CheckBox)item.FindControl("chkWap");
                    CheckBox chkSMS = (CheckBox)item.FindControl("chkSMS");
                    CheckBox chkXzone = (CheckBox)item.FindControl("chkXzone");
                    try
                    {
                        DataTable dtUserCommands = CommandController.GetCommandsForUserNotGroup(user_id, ConvertUtility.ToInt32(dropPortal.SelectedValue));
                        DataRow[] rowItems = dtUserCommands.Select("CommandParentID = " + command_id);

                        foreach (DataRow row in rowItems)
                        {
                            UserController.UpdateUserPermissionByPortalID(ConvertUtility.ToInt32(row["UserID"]), ConvertUtility.ToInt32(row["CommandID"]), portal_id, chkWeb.Checked, chkWap.Checked, chkSMS.Checked, chkXzone.Checked, chkView.Checked, true, true, true);
                        }
                        try
                        {
                            UserController.UpdateUserPermissionByPortalID(user_id, command_id, portal_id, chkWeb.Checked, chkWap.Checked, chkSMS.Checked, chkXzone.Checked, chkView.Checked, chkAdd.Checked, chkUpdate.Checked, chkDelete.Checked);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    catch
                    {
                        lblUpdateStatus1.Text = MiscUtility.MSG_UPDATE_ERROR;
                    }
                }
                lblUpdateStatus1.Text = MiscUtility.MSG_UPDATE_SUCCESS;
                new DataCaching().RemoveAll();
            }
            catch
            {
                lblUpdateStatus1.Text = MiscUtility.MSG_UPDATE_ERROR;
            }
            lblUpdateStatus.Text = "";
        }

        protected void dropPortal_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
	}
}