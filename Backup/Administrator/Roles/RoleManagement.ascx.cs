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

using VmgPortal.Library;
using VmgPortal.Library.Components.Roles;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Components.Users;
using VmgPortal.Library.Utilities;

namespace VmgPortal.Administrator.Roles
{
    public partial class RoleManagement : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            dropRoleParentID.Items.Clear();

            //DataTable dtUsers;
           
            RoleController.LoadRoles(dropRoleParentID.Items);

            //dtUsers = UserController.GetUsers();
           
            dropUserManager.Items.Clear();
            //dropUserManager.DataSource = dtUsers;
            //dropUserManager.DataBind();

            dropRoleParentID.Items.Insert(0, new ListItem("Root", "0"));

            dropUserManager.Items.Insert(0, new ListItem(CurrentUser.Username, CurrentUser.UserID.ToString()));

            DataTable dtRebuildData = new DataTable();

            dtRebuildData.Columns.Add("RoleID", typeof(String));
            dtRebuildData.Columns.Add("RoleName", typeof(String));
            dtRebuildData.Columns.Add("RoleDescription", typeof(String));
            dtRebuildData.Columns.Add("RoleParentID", typeof(String));
            dtRebuildData.Columns.Add("Level", typeof(String));

            DataTable dtRole;
            //if (!CurrentUser.IsSuperAdmin)
            //{
            //    dtRole = RoleController.GetRolesByUserManager(CurrentUser.UserID);
            //    dtgRoles.DataSource = RoleController.GetRoleByParentID(dtRole, dtRebuildData);
            //    dtgRoles.DataBind();
            //}
            //else
            //{
                dtRole = RoleController.GetRoles();
                dtgRoles.DataSource = RoleController.GetRoleByParentID(dtRole, dtRebuildData);
                dtgRoles.DataBind();
            //}

        }
        protected void dtgRoles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int roleId;
            switch (e.CommandName)
            {
                case "editrole":
                    roleId = ConvertUtility.ToInt32(e.CommandArgument);
                    RoleInfo role = RoleController.GetRole(roleId);
                    txtRoleID.Text = role.RoleID.ToString();
                    txtRoleName.Text = role.RoleName;
                    txtRoleDescription.Text = role.RoleDescription;
                    txtAddress.Text = role.Address;
                    txtPhone.Text = role.Phone;
                    txtFax.Text = role.Fax;
                    txtEmail.Text = role.Email;
                    dropUserManager.SelectedValue = role.UserManager.ToString();
                    dropRoleParentID.SelectedValue = role.RoleParentID.ToString();
                    break;
                case "deleterole":
                    try
                    {
                        roleId = ConvertUtility.ToInt32(e.CommandArgument);
                        RoleController.DeleteRole(roleId);
                        lblUpdate.Text = MiscUtility.MSG_UPDATE_SUCCESS;
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                    break;
                case "rolepermision":
                    roleId = ConvertUtility.ToInt32(e.CommandArgument);
                    Response.Redirect(AppEnv.AdminUrlParams("rolepermision") + "&roleid=" + roleId);
                    break;
                case "userinrole":
                    roleId = ConvertUtility.ToInt32(e.CommandArgument);
                    Response.Redirect(AppEnv.AdminUrlParams("userinrole") + "&roleid=" + roleId);
                    break;
                default:
                    break;
            }
        }
        protected void dtgRoles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                VmgPortal.WebControls.ButtonRoleDelete btnDeleteRole = (VmgPortal.WebControls.ButtonRoleDelete)e.Row.FindControl("btnDeleteRole");
                btnDeleteRole.Attributes.Add("onclick", MiscUtility.MSG_DELETE_CONFIRM);

                if (e.Row.Cells[0].Text == "Default")
                {
                    e.Row.Visible = CurrentUser.IsSuperAdmin;
                }
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int roleId = ConvertUtility.ToInt32(txtRoleID.Text);
                RoleInfo role = RoleController.GetRole(roleId);
                role.RoleName = txtRoleName.Text;
                role.RoleDescription = txtRoleDescription.Text;
                role.Address = txtAddress.Text;
                role.Phone = txtPhone.Text;
                role.Fax = txtFax.Text;
                role.Email = txtEmail.Text;
                role.UserManager = ConvertUtility.ToInt32(dropUserManager.SelectedValue);
                role.RoleParentID = ConvertUtility.ToInt32(dropRoleParentID.SelectedValue);

                RoleController.UpdateRole(role);
                lblUpdate.Text = MiscUtility.MSG_UPDATE_SUCCESS;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            btnCancel_Click(null, null);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                RoleInfo role = new RoleInfo();
                role.RoleName = txtRoleName.Text;
                role.RoleDescription = txtRoleDescription.Text;
                role.Address = txtAddress.Text;
                role.Phone = txtPhone.Text;
                role.Fax = txtFax.Text;
                role.Email = txtEmail.Text;
                role.UserManager = ConvertUtility.ToInt32(dropUserManager.SelectedValue);
                role.RoleParentID = ConvertUtility.ToInt32(dropRoleParentID.SelectedValue);
                RoleController.AddRole(role);
                lblUpdate.Text = MiscUtility.MSG_UPDATE_SUCCESS;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            btnCancel_Click(null, null);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int roleId = ConvertUtility.ToInt32(txtRoleID.Text);
                RoleController.DeleteRole(roleId);
                lblUpdate.Text = MiscUtility.MSG_UPDATE_SUCCESS;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            btnCancel_Click(null, null);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtRoleName.Text = "";
            txtRoleDescription.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            dropUserManager.SelectedIndex = -1;
            dropRoleParentID.SelectedIndex = -1;
        }

    }
}