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
using Telerik.WebControls;
using VmgPortal.Library;
using VmgPortal.Library.Components.Commands;
using VmgPortal.Library.Components.Roles;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Components.Portal;
using VmgPortal.Library.Utilities;
using VmgPortal.Library.Components;

namespace VmgPortal.Administrator.Roles
{
	public partial class RolePermision : AuthenticatedControl
	{
        private DataTable dtCommand = null;

        protected void Page_Load(object sender, EventArgs e)
        {
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

                dropPortal.Items.Insert(0, new ListItem("Root", "0"));
                dropPortal.SelectedValue = AppEnv.PortalId().ToString();

                //Fill roles
                if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                {
                    dropRole.DataSource = RoleController.GetRolesByUserManager(CurrentUser.UserID);
                    dropRole.DataBind();
                    dropRole.SelectedValue = ConvertUtility.ToString(Request.QueryString["roleid"]);
                }
                else
                {
                    dropRole.DataSource = RoleController.GetRoles();
                    dropRole.DataBind();
                    dropRole.SelectedValue = ConvertUtility.ToString(Request.QueryString["roleid"]);
                }


            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            BindData();
        }
        public void BindData()
        {
            int roleId = ConvertUtility.ToInt32(dropRole.SelectedValue);
            DataTable dtRoleCommands = CommandController.GetCommandsForRoleByPortalID(roleId, ConvertUtility.ToInt32(dropPortal.SelectedValue));
            DataTable dtReturnCommand = new DataTable();

            dtReturnCommand.Columns.Add("CommandID", typeof(String));
            dtReturnCommand.Columns.Add("PortalID", typeof(String));
            dtReturnCommand.Columns.Add("RoleID", typeof(String));
            dtReturnCommand.Columns.Add("CommandParentID", typeof(String));
            dtReturnCommand.Columns.Add("CommandName", typeof(String));
            dtReturnCommand.Columns.Add("Level", typeof(String));
            dtReturnCommand.Columns.Add("Role_View", typeof(String));
            dtReturnCommand.Columns.Add("Role_Add", typeof(String));
            dtReturnCommand.Columns.Add("Role_Update", typeof(String));
            dtReturnCommand.Columns.Add("Role_Delete", typeof(String));
            //dtReturnCommand.Columns.Add("UseForWeb", typeof(String));
            //dtReturnCommand.Columns.Add("UseForWap", typeof(String));
            //dtReturnCommand.Columns.Add("UseForSMS", typeof(String));
            //dtReturnCommand.Columns.Add("UseForXzone", typeof(String));

            dtCommand = dtRoleCommands;
            DataTable _dtReturnCommand = RoleController.BuildRecursiveRolePermission(dtRoleCommands, dtReturnCommand, roleId, ConvertUtility.ToInt32(dropPortal.SelectedValue));
            dgrRolePermission.DataSource = _dtReturnCommand;
            dgrRolePermission.DataBind();

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
            CommandSelected();
        }
        protected void dgrRolePermission_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                int role_id = ConvertUtility.ToInt32(e.Item.Cells[0].Text);
                int command_id = ConvertUtility.ToInt32(e.Item.Cells[1].Text);
                int portal_id = ConvertUtility.ToInt32(e.Item.Cells[2].Text);
                CheckBox chkView = (CheckBox)e.Item.FindControl("chkView");
                CheckBox chkAdd = (CheckBox)e.Item.FindControl("chkAdd");
                CheckBox chkUpdate = (CheckBox)e.Item.FindControl("chkEdit");
                CheckBox chkDelete = (CheckBox)e.Item.FindControl("chkDelete");
                //CheckBox chkWeb = (CheckBox)e.Item.FindControl("chkWeb");
                //CheckBox chkWap = (CheckBox)e.Item.FindControl("chkWap");
                //CheckBox chkSMS = (CheckBox)e.Item.FindControl("chkSMS");
                //CheckBox chkXzone = (CheckBox)e.Item.FindControl("chkXzone");
                try
                {
                    DataTable dtRoleCommands = CommandController.GetCommandsForRoleByPortalID(role_id, portal_id);
                    DataRow[] rowItems = dtRoleCommands.Select("CommandParentID = " + command_id);

                    foreach (DataRow row in rowItems)
                    {
                        //RoleController.UpdateRolePermissionByPortalID(ConvertUtility.ToInt32(row["RoleID"]), ConvertUtility.ToInt32(row["CommandID"]), portal_id, true, true, true, true, chkView.Checked, true, true, true);
                        RoleController.UpdateRolePermissionByPortalID(ConvertUtility.ToInt32(row["RoleID"]), ConvertUtility.ToInt32(row["CommandID"]), portal_id, chkView.Checked, true, true, true);
                    }

                    try
                    {
                        //RoleController.UpdateRolePermissionByPortalID(role_id, command_id, portal_id, chkWeb.Checked, chkWap.Checked, chkSMS.Checked, chkXzone.Checked, chkView.Checked, chkAdd.Checked, chkUpdate.Checked, chkDelete.Checked);
                        RoleController.UpdateRolePermissionByPortalID(role_id, command_id, portal_id, chkView.Checked, chkAdd.Checked, chkUpdate.Checked, chkDelete.Checked);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    lblUpdate1.Text = MiscUtility.MSG_UPDATE_SUCCESS;
                }
                catch (Exception ex)
                {
                    throw ex;
                    //lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_ERROR;
                }
            }
        }
        protected void dgrRolePermission_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            DataRowView row = (DataRowView)e.Item.DataItem;

            Label lblCmdName = (Label)e.Item.FindControl("lblCmdName");
            lblCmdName.Text = row["CommandName"].ToString();

            CheckBox chkView = (CheckBox)e.Item.FindControl("chkView");
            CheckBox chkAdd = (CheckBox)e.Item.FindControl("chkAdd");
            CheckBox chkEdit = (CheckBox)e.Item.FindControl("chkEdit");
            CheckBox chkDelete = (CheckBox)e.Item.FindControl("chkDelete");
            //CheckBox chkWeb = (CheckBox)e.Item.FindControl("chkWeb");
            //CheckBox chkWap = (CheckBox)e.Item.FindControl("chkWap");
            //CheckBox chkSMS = (CheckBox)e.Item.FindControl("chkSMS");
            //CheckBox chkXzone = (CheckBox)e.Item.FindControl("chkXzone");

            //chkWeb.Checked = ConvertUtility.ToBoolean(row["UseForWeb"].ToString());
            //chkWap.Checked = ConvertUtility.ToBoolean(row["UseForWap"].ToString());
            //chkSMS.Checked = ConvertUtility.ToBoolean(row["UseForSMS"].ToString());
            //chkXzone.Checked = ConvertUtility.ToBoolean(row["UseForXzone"].ToString());

            DataRow[] _row = dtCommand.Select("CommandParentID = " + row["CommandID"]);

            if (_row.Length > 0)
            {
                chkView.Checked = ConvertUtility.ToBoolean(ConvertUtility.ToInt32(row["Role_View"]));
                chkAdd.Visible = false;
                chkEdit.Visible = false;
                chkDelete.Visible = false;
            }
            else
            {
                if (ConvertUtility.ToInt32(row["CommandParentID"]) == 0)
                {
                    chkView.Checked = ConvertUtility.ToBoolean(ConvertUtility.ToInt32(row["Role_View"]));
                    chkAdd.Visible = false;
                    chkEdit.Visible = false;
                    chkDelete.Visible = false;
                }
                else
                {
                    chkView.Checked = ConvertUtility.ToBoolean(ConvertUtility.ToInt32(row["Role_View"]));
                    chkAdd.Checked = ConvertUtility.ToBoolean(ConvertUtility.ToInt32(row["Role_Add"]));
                    chkEdit.Checked = ConvertUtility.ToBoolean(ConvertUtility.ToInt32(row["Role_Update"]));
                    chkDelete.Checked = ConvertUtility.ToBoolean(ConvertUtility.ToInt32(row["Role_Delete"]));
                }

            }

            Button btnUpdate = (Button)e.Item.FindControl("btnUpdate");
            btnUpdate.Text = "Cập nhật";
            btnUpdate.OnClientClick = "javascript:return confirm('Bạn đã chắc chắn chưa' )";
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int roleId = ConvertUtility.ToInt32(dropRole.SelectedValue);
                foreach (ListItem item in lstCommands.Items)
                {
                    if (item.Selected && item.Value != "0")
                    {
                        RoleController.AddCommandToRoleByPortalID(Convert.ToInt32(item.Value), roleId, ConvertUtility.ToInt32(dropPortal.SelectedValue));
                    }
                    else
                    {
                        RoleController.RemoveCommandFromRoleByPortalID(Convert.ToInt32(item.Value), roleId, ConvertUtility.ToInt32(dropPortal.SelectedValue));
                    }
                }
                lblUpdate.Text = MiscUtility.MSG_UPDATE_SUCCESS;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            lblUpdate1.Text = "";
        }
        private void CommandSelected()
        {
            int roleId = ConvertUtility.ToInt32(dropRole.SelectedValue);
            DataTable dtCommands = CommandController.GetCommandsForRoleByPortalID(roleId, ConvertUtility.ToInt32(dropPortal.SelectedValue));
            foreach (ListItem item in lstCommands.Items)
            {
                if (dtCommands.Select("CommandID = " + item.Value).Length > 0)
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
            }
        }

        protected void btnUpdateAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridItem item in dgrRolePermission.Items)
                {
                    int role_id = ConvertUtility.ToInt32(item.Cells[0].Text);
                    int command_id = ConvertUtility.ToInt32(item.Cells[1].Text);
                    int portal_id = ConvertUtility.ToInt32(item.Cells[2].Text);
                    CheckBox chkView = (CheckBox)item.FindControl("chkView");
                    CheckBox chkAdd = (CheckBox)item.FindControl("chkAdd");
                    CheckBox chkUpdate = (CheckBox)item.FindControl("chkEdit");
                    CheckBox chkDelete = (CheckBox)item.FindControl("chkDelete");

                    //CheckBox chkWeb = (CheckBox)item.FindControl("chkWeb");
                    //CheckBox chkWap = (CheckBox)item.FindControl("chkWap");
                    //CheckBox chkSMS = (CheckBox)item.FindControl("chkSMS");
                    //CheckBox chkXzone = (CheckBox)item.FindControl("chkXzone");

                    DataTable dtRoleCommands = CommandController.GetCommandsForRoleByPortalID(role_id, portal_id);
                    DataRow[] rowItems = dtRoleCommands.Select("CommandParentID = " + command_id);

                    foreach (DataRow row in rowItems)
                    {
                        //RoleController.UpdateRolePermissionByPortalID(ConvertUtility.ToInt32(row["RoleID"]), ConvertUtility.ToInt32(row["CommandID"]), portal_id, chkWeb.Checked, chkWap.Checked, chkSMS.Checked, chkXzone.Checked, chkView.Checked, true, true, true);
                        RoleController.UpdateRolePermissionByPortalID(ConvertUtility.ToInt32(row["RoleID"]), ConvertUtility.ToInt32(row["CommandID"]), portal_id, chkView.Checked, true, true, true);
                    }
                    try
                    {
                        //RoleController.UpdateRolePermissionByPortalID(role_id, command_id, portal_id, chkWeb.Checked, chkWap.Checked, chkSMS.Checked, chkXzone.Checked, chkView.Checked, chkAdd.Checked, chkUpdate.Checked, chkDelete.Checked);
                        RoleController.UpdateRolePermissionByPortalID(role_id, command_id, portal_id, chkView.Checked, chkAdd.Checked, chkUpdate.Checked, chkDelete.Checked);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                lblUpdate1.Text = MiscUtility.MSG_UPDATE_SUCCESS;
                new DataCaching().RemoveAll();
            }
            catch
            {
                lblUpdate1.Text = MiscUtility.MSG_UPDATE_ERROR;
            }
            lblUpdate.Text = "";
        }

        protected void dropRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommandSelected();
        }

        protected void dgrRolePermission_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

	}
}