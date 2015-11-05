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

namespace VmgPortal.Administrator
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btLogin_Click(object sender, EventArgs e)
        {
            string returnUrl = Request.QueryString["returnUrl"];
            if ((UserController.ValidateUser(txtUsername.Text.Trim(), SecurityMethod.MD5Encrypt(txtPassword.Text.Trim())) != null))
            {
                AuthenticateUtility.LoginUser(txtUsername.Text.Trim(), true);
                AppEnv.SetLanguage("vi-VN");
                Response.Redirect("/Authenticate.aspx");
            }
            else
            {
                //Response.Write("NULL");
            }
        }
	}
}
