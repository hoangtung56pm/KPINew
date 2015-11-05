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
	public class AuthenticatedPageTemp : Page
	{
		protected string returnUrl = string.Empty;
        public UserInfo CurrentUserTemp
        {
            get
            {
                if (Context.Items["MEMBER_PLUS_INFO_TEMP"] != null)
                {
                    return (UserInfo)Context.Items["MEMBER_PLUS_INFO_TEMP"];
                }
                return null;
            }
            set
            {
                Context.Items.Remove("MEMBER_PLUS_INFO_TEMP");
                Context.Items["MEMBER_PLUS_INFO_TEMP"] = value;
            }
        }
	    protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
            
			returnUrl = Server.UrlEncode(Request.RawUrl);
            HttpCookie memInfoUser = Request.Cookies["nametemp"];
            HttpCookie memInfoPass = Request.Cookies["passtemp"];
			if(AuthenticateUtility.IsAuthenticatedTemp())
			{
                CurrentUserTemp = UserController.GetUser(AuthenticateUtility.GetUsernameTemp());

                if (CurrentUserTemp == null)
                {
                    Response.Redirect("/Login.aspx?returnurl=" + returnUrl);
                }
			}
            else
			{
                if (memInfoPass != null && memInfoUser != null)
			    {
			        UserInfo info = UserController.ValidateUser(memInfoUser.Value, memInfoPass.Value);
                    //set cookies
                    if (AuthenticateUtility.LoginUserTemp(memInfoUser.Value, true, info))
			        {
                        if (info != null)
			            {
			                CurrentUserTemp = info;
			            }
			            else
			            {
			                Response.Redirect("/Login.aspx?returnurl=" + returnUrl);
			            }
			        }
			    }
			    else
			    {
			        Response.Redirect("/Login.aspx?returnurl=" + returnUrl);
			    }
			}
		}
	}
}
