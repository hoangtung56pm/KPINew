using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using VmgPortal.Library.Components.Users;
using System.Text.RegularExpressions;
using System.Web;
using System.Configuration;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using VmgPortal.Library.Utilities;

namespace VmgPortal.Library.Components.Security
{
    public class AuthenticatedPage : Page
	{
		protected string returnUrl = string.Empty;
		public UserInfo CurrentUser
		{
			get
			{
                if (Context.Items["ADMIN_PLUS_MEMBER_INFO"] != null) return (UserInfo)Context.Items["ADMIN_PLUS_MEMBER_INFO"];
				return null;
			}
			set
			{
                Context.Items.Remove("ADMIN_PLUS_MEMBER_INFO");
                Context.Items["ADMIN_PLUS_MEMBER_INFO"] = value;
			}
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			returnUrl = Server.UrlEncode(Request.RawUrl);
            HttpCookie memInfoUser = Request.Cookies["name"];
            HttpCookie memInfoPass = Request.Cookies["pass"];
			if(AuthenticateUtility.IsAuthenticated())
			{

				if (CurrentUser == null) CurrentUser = UserController.GetUser(AuthenticateUtility.GetUsername());
				if (CurrentUser == null) Response.Redirect("/Login.aspx?returnurl=" + returnUrl);
			}else
			{
                if (memInfoPass != null && memInfoUser.Expires != null)
                {
                    UserInfo next = UserController.ValidateUser(memInfoUser.Value, memInfoPass.Value);
                    if(AuthenticateUtility.LoginUser(memInfoUser.Value, true))
                    if (next!=null) CurrentUser = UserController.GetUser(memInfoUser.Value);
                    else
                        Response.Redirect("/Login.aspx?returnurl=" + returnUrl);
                }
                else {
                    Response.Redirect("/Login.aspx?returnurl=" + returnUrl);
                }
				
			}
		}
	}
}
