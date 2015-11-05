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

namespace VmgPortal.Administrator.Users
{
	public partial class UserProfile : AuthenticatedControl
	{
		private int userId;
		protected void Page_Load(object sender, EventArgs e)
		{
			userId = ConvertUtility.ToInt32(Request.QueryString["uid"]);
            if (!CurrentUser.IsAdmin)
            {
                pnlAdmin.Visible = false;
            }
            if (!CurrentUser.IsSuperAdmin)
            {
                pnlSuperadmin.Visible = false;
            }
            else if (CurrentUser.IsSuperAdmin)
            {
                pnlSuperadmin.Visible = true;
                pnlAdmin.Visible = true;
            }
			if (!Page.IsPostBack)
			{
                PortalController.LoadPortals(lstPortal.Items);
			    
				UserInfo user = UserController.GetUser(userId);
				if (user == null)
				{
					this.btnUpdate.Visible = false;
					this.btnManagePassword.Visible = false;
					return;
				}
				lblUsername.Text = user.Username;
				txtAddress1.Text = user.Address1;
				txtAddress2.Text = user.Address2;
				MiscUtility.SelectItemFromList(dropCity, user.City.ToString());
				MiscUtility.SelectItemFromList(dropCountry, user.Country.ToString());
				txtDisplayName.Text = user.DisplayName;
				txtEmail.Text = user.Email;
				txtFirstName.Text = user.FirstName;
				chkIsSuperAdmin.Checked = user.IsSuperAdmin;
				chkIsAdmin.Checked = user.IsAdmin;
				txtLastName.Text = user.LastName;
				txtMobile.Text = user.Mobile;
				txtTel.Text = user.Tel;
				txtZipCode.Text = user.ZipCode;
                
                DataTable dtUserPortals = PortalController.GetPortals(user.UserID, AppEnv.GetLanguage());
                foreach (DataRow row in dtUserPortals.Rows)
				{
					if (lstPortal.Items.FindByValue(row["PortalID"].ToString()) != null)
					{
					    lstPortal.Items.FindByValue(row["PortalID"].ToString()).Selected = true;
					}
				}
                //dropPartner.DataSource = PartnerController.GetPartners();
                //dropPartner.DataBind();
                //if (user.PartnerID != 0)
                //{
                //    dropPartner.SelectedValue = user.PartnerID.ToString();
                //}
			}
		}

		protected void btnUpdate_Click(object sender, EventArgs e)
        {
            
			if (userId == 0) return;
			try
			{
				UserInfo user = UserController.GetUser(userId);
			    
				if (user == null) return;
				user.Address1 = txtAddress1.Text.Trim();
				user.Address2 = txtAddress2.Text.Trim();
				user.City = ConvertUtility.ToInt32(dropCity.SelectedValue);
				user.Country = ConvertUtility.ToInt32(dropCountry.SelectedValue);
				user.DisplayName = txtDisplayName.Text.Trim();
				user.Email = txtEmail.Text;
				user.FirstName = txtFirstName.Text.Trim();
				user.IsSuperAdmin = chkIsSuperAdmin.Checked;
				user.LastName = txtLastName.Text.Trim();
				user.Mobile = txtMobile.Text.Trim();
				user.Tel = txtTel.Text.Trim();
				user.ZipCode = txtZipCode.Text.Trim();
                user.PartnerID = 0;// ConvertUtility.ToInt32(dropPartner.SelectedValue);
				if(pnlSuperadmin.Visible) user.IsSuperAdmin = chkIsSuperAdmin.Checked;
				if(pnlAdmin.Visible) user.IsAdmin = chkIsAdmin.Checked;
			    
				UserController.UpdateUser(user);

                foreach (ListItem item in lstPortal.Items)
				{
                    if (item.Selected)
                    {
                        RoleController.AddUserToRole(user.UserID, AppEnv.DEFAULT_ROLE, Convert.ToInt32(item.Value));
                    }
                    else
                    {
                        RoleController.RemoveUserFromRole(user.UserID, AppEnv.DEFAULT_ROLE, Convert.ToInt32(item.Value));
                    }
				}
                lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;
			}
			catch (Exception ex)
			{
				Response.Write(ex.Message);
			}
		}
		protected void btnManagePassword_Click(object sender, EventArgs e)
		{
            Response.Redirect(AppEnv.AdminUrlParams("managepassword") + "&uid=" + userId);
		}
		protected void btnCancel_Click(object sender, EventArgs e)
		{
			Response.Redirect(AppEnv.ADMIN_CMD + "usermanager");
		}
	}
}