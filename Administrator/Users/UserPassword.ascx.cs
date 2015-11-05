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
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Components.Users;
using VmgPortal.Library.Utilities;

namespace VmgPortal.Administrator.Users
{
    public partial class UserPassword : AuthenticatedControl
    {
        private int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUpdateStatus.Text = string.Empty;

            if (CurrentUser.IsSuperAdmin || CurrentUser.IsAdmin)// 
            {
                userId = ConvertUtility.ToInt32(Request.QueryString["uid"]);
                if (userId == 0)
                {
                    userId = CurrentUser.UserID;
                }
            }
            else
            {
                userId = CurrentUser.UserID;
            }

            UserInfo user = UserController.GetUser(userId);
            if (user == null)
            {
                this.btnUpdate.Visible = false;
                return;
            }
            lblUsername.Text = user.Username;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() != string.Empty && txtPassword.Text.Trim() == txtPasswordConfirm.Text.Trim())
            {
                try
                {
                    UserController.ResetPassword(userId, SecurityMethod.MD5Encrypt(txtPassword.Text.Trim()));
                    lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;
                }
                catch (Exception ex)
                {
                    lblUpdateStatus.Text = ex.Message;
                }
            }
            else
            {
                lblUpdateStatus.Text = "Mật khẩu không đúng";
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(AppEnv.AdminUrlParams("usermanager"));
        }
    }
}