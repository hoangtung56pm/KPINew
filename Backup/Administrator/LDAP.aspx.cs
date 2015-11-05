using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library;
using System.Net;
using Novell.Directory.Ldap;

namespace VmgPortal.Administrator
{
    public partial class LDAP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                LdapConnection conn = new LdapConnection();
                //Console.WriteLine("Connecting to:" + ldapHost);
                conn.Connect("192.168.36.10", 389);
                conn.Bind(Login1.UserName, Login1.Password);
                conn.Disconnect();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string host = string.Empty;

            string port = string.Empty;

            string strError = string.Empty;

            host = AppEnv.GetSetting("host");

            port = AppEnv.GetSetting("port");

            if (true == AuthenticateUser(host, Login1.UserName, Login1.Password, port, out strError))
            {
                lblError.Text = "Valid user name or Password!";
            }

            host = string.Empty;

            port = string.Empty;

            if (!string.IsNullOrEmpty(strError))
            {

                lblError.Text = "Invalid user name or Password!";

            }
        }

        public bool AuthenticateUser(string host, string username, string password, string port, out string Errmsg)
        {
            try
            {
                LdapConnection conn = new LdapConnection();
                conn.Connect(host, Convert.ToInt32(port));
                conn.Bind(username, password);               
                conn.Disconnect();
                Errmsg = "";
                return true;

            }
            catch (Exception ex)
            {
                Errmsg = ex.Message;
                return false;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

           

        }
    }
}