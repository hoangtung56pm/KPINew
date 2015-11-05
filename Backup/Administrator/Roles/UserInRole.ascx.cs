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
using VmgPortal.Library.Components.Portal;
using VmgPortal.Library.Components.Roles;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Components.Users;
using VmgPortal.Library.Utilities;
using VmgPortal.Modules.KPIData.Library.BoPhan;

namespace VmgPortal.Administrator.Roles
{
	public partial class UserInRole : AuthenticatedControl
	{
        private int roleId;
        protected void Page_Load(object sender, EventArgs e)
        {
            roleId = ConvertUtility.ToInt32(Request.QueryString["roleid"]);
            if (!Page.IsPostBack)
            {
                RoleInfo role = RoleController.GetRole(roleId);
                if (role == null)
                {
                    this.btnAdd.Visible = false;
                    this.btnRemove.Visible = false;
                    return;
                }
                lblRoleName.Text = role.RoleName;

                dropTrungTam.DataSource = BoPhanController.GetAll();
                dropTrungTam.DataBind();
                dropTrungTam.Items.Insert(0, new ListItem("Tất cả", "0"));

                dropPortal.Items.Clear();
                PortalController.LoadPortals(dropPortal.Items);
            }

        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            lstUsers.Items.Clear();
            lstUsers.DataSource = UserController.GetUsersNotInRole(AppEnv.DEFAULT_ROLE, ConvertUtility.ToInt32(dropPortal.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            lstUsers.DataBind();

            lstUserInRole.Items.Clear();
            lstUserInRole.DataSource = UserController.GetUsers(roleId, ConvertUtility.ToInt32(dropPortal.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            lstUserInRole.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lstUsers.Items)
            {
                if (item.Selected)
                {
                    RoleController.UpdateUserToRole(Convert.ToInt32(item.Value), roleId, ConvertUtility.ToInt32(dropPortal.SelectedValue));
                }
            }
        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lstUserInRole.Items)
            {
                if (item.Selected)
                {

                    RoleController.UpdateUserToRole(Convert.ToInt32(item.Value), AppEnv.DEFAULT_ROLE, ConvertUtility.ToInt32(dropPortal.SelectedValue));
                }
            }
        }

        protected void dropTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
	}
}