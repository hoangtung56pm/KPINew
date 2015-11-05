using System;
using System.Diagnostics;
using System.Web;
using System.Web.Security;
using VmgPortal.Library.Components.Users;

namespace VmgPortal.Library.Components.Security
{
	public class AuthenticateUtility
	{
        public const string MEMBER_PREFIX = "ADMIN_PLUS_MEMBER_INFO";
        public const string MEMBER_PREFIX_TEMP = "MEMBER_PLUS_INFO_TEMP";

		public static string GetUsername()
		{
			return HttpContext.Current.User.Identity.Name.Replace(MEMBER_PREFIX, string.Empty);
		}

		public static bool IsAuthenticated()
		{
			HttpContext context = HttpContext.Current;
			return
				context.User.Identity.IsAuthenticated && (context.User.Identity.Name.IndexOf(MEMBER_PREFIX) != -1);
		}

		public static bool LoginUser(string _username, bool _rememberAccount)
		{
			LogoutUser();
			FormsAuthentication.Initialize();
			FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, MEMBER_PREFIX + _username, DateTime.Now, DateTime.Now.AddMinutes(45), _rememberAccount, "", FormsAuthentication.FormsCookiePath);
			Trace.Write(FormsAuthentication.FormsCookiePath + FormsAuthentication.FormsCookieName);
			HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
			HttpContext.Current.Response.SetCookie(cookie);
            UserInfo info = UserController.GetUser(_username);
            if (info != null)
            {
                string _password = info.Password;
                HttpContext.Current.Response.Cookies.Get("name").Value = _username;
                HttpContext.Current.Response.Cookies.Get("pass").Value = _password;
                HttpContext.Current.Response.Cookies["name"].Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies["pass"].Expires = DateTime.Now.AddDays(1);
                return true;
            }
            else {
                return false;
            }
		}

        public static void LogoutUser()
        {
            HttpContext.Current.Session.Abandon();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Cookies["name"].Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies["pass"].Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies["nametemp"].Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies["passtemp"].Expires = DateTime.Now.AddDays(-1);
            //HttpContext.Current.Response.Cookies["otp"].Expires = DateTime.Now.AddMinutes(-60);
        }

	    public static string GetUsernameTemp()
        {
            return HttpContext.Current.User.Identity.Name.Replace(MEMBER_PREFIX_TEMP, string.Empty);
        }

        public static bool IsAuthenticatedTemp()
        {
            HttpContext context = HttpContext.Current;
            return
                context.User.Identity.IsAuthenticated && (context.User.Identity.Name.IndexOf(MEMBER_PREFIX_TEMP) != -1);
        }

        public static bool LoginUserTemp(string _username, bool _rememberAccount, UserInfo info)
        {
            LogoutUser();
            FormsAuthentication.Initialize();
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, MEMBER_PREFIX_TEMP + _username, DateTime.Now, DateTime.Now.AddMinutes(45), _rememberAccount, "", FormsAuthentication.FormsCookiePath);
            Trace.Write(FormsAuthentication.FormsCookiePath + FormsAuthentication.FormsCookieName);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            HttpContext.Current.Response.SetCookie(cookie);

            FormsAuthentication.Initialize();
            ticket = new FormsAuthenticationTicket(1, MEMBER_PREFIX + _username, DateTime.Now, DateTime.Now.AddMinutes(45), _rememberAccount, "", FormsAuthentication.FormsCookiePath);
            Trace.Write(FormsAuthentication.FormsCookiePath + FormsAuthentication.FormsCookieName);
            cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            HttpContext.Current.Response.SetCookie(cookie);

            //UserInfo info = UserController.GetUser(_username);
            if (info != null)
            {
                string _password = info.Password;
                HttpContext.Current.Response.Cookies.Get("nametemp").Value = _username;
                HttpContext.Current.Response.Cookies.Get("passtemp").Value = _password;
                HttpContext.Current.Response.Cookies["nametemp"].Expires = DateTime.Now.AddMinutes(60);
                HttpContext.Current.Response.Cookies["passtemp"].Expires = DateTime.Now.AddMinutes(60);
                
                HttpContext.Current.Response.Cookies.Get("name").Value = _username;
                HttpContext.Current.Response.Cookies.Get("pass").Value = _password;
                HttpContext.Current.Response.Cookies["name"].Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies["pass"].Expires = DateTime.Now.AddDays(1);

                return true;
            }
            else
            {
                return false;
            }
        }
        
	}
}