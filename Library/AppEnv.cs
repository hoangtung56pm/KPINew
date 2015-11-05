using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Xml;
using VmgPortal.Library.Components.Commands;
using VmgPortal.Library.Components.Portal;
using VmgPortal.Library.Utilities;
using VmgPortal.Library;
using System.IO;
using System.Data;
using System.Xml.Serialization;

namespace VmgPortal.Library
{
    public class AppEnv
    {
        public static string ConnectionString
        {
            get
            {
                string con = AppEnv.DecryptString(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "dungdeptrai");
                return con;
            }
        }

        public static string ConnectionString_Plus
        {
            get
            {
                string con = AppEnv.DecryptString(WebConfigurationManager.ConnectionStrings["ConnectionString_Plus"].ConnectionString, "dungdeptrai");
                return con;
            }
        }
        public static string DecryptString(string Message, string Passphrase)
        {
            return Message;

        }


        public static string ADMIN_EMAIL = "admin@vmgmedia.vn";
        public static int DEFAULT_ROLE
        {
            get { return 2; }
            //ConvertUtility.ToInt32(PortalSetting.GetSetting()[Definition.Portal_Default_Role + "_" + GetLanguage()]);
        }
        public static string ContactMail
        {
            get { return GetSetting("ContactMail"); }
        }
        public static string GetConnectionString(string name)
        {
            return AppEnv.DecryptString(WebConfigurationManager.ConnectionStrings[name].ConnectionString, "dungdeptrai");
        }
        public static string GetSetting(string key)
        {
            return WebConfigurationManager.AppSettings[key];
        }
        public static double GetTimeCacheExpire()
        {
            return ConvertUtility.ToInt32(GetSetting("CacheExpire"));
        }

        public static string BuildDetailLink(int portalId, int tabId, int catId, object id, object title)
        {
            return string.Format("/{0}/{1}/{2}/{3}/{4}/{5}/{6}", "News", portalId, tabId, catId, 1, id, UnicodeUtility.ToPlainText(title));
        }
        public static string BuildSongDetailLink(int portalId, int tabId, int catId, object id, object title)
        {
            return string.Format("/{0}/{1}/{2}/{3}/{4}/{5}/{6}", "Song", portalId, tabId, catId, 1, id, UnicodeUtility.ToPlainText(title));
        }
        public static string BuildAudioBookDetailLink(int portalId, int tabId, int catId, object id, object title)
        {
            return string.Format("/{0}/{1}/{2}/{3}/{4}/{5}/{6}", "Song", portalId, tabId, catId, 1, id, UnicodeUtility.ToPlainText(title));
        }
        public static string GetAppSetting(string key, string configFileName)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(HttpContext.Current.Server.MapPath(configFileName));
            XmlNode node = xd.DocumentElement.SelectSingleNode("/configuration/appSettings/add[@key=\"" + key + "\"]");
            if (node != null) return node.Attributes.GetNamedItem("value").Value;
            else return null;
        }
        public static void SetLanguage(string cultureCode)
        {
            HttpContext context = HttpContext.Current;
            HttpCookie cookieLang;
            if (HttpContext.Current.Request.RawUrl.IndexOf("Administrator") > 0)
            {
                cookieLang = new HttpCookie(Definition.Portal_Admin_Cookie, cultureCode);
            }
            else
            {
                cookieLang = new HttpCookie(Definition.Portal_Cookie, cultureCode);
            }
            cookieLang.Expires = DateTime.Now.AddYears(100);
            context.Response.Cookies.Add(cookieLang);
        }

        public static string GetLanguage()
        {
            string strOutput = String.Empty;
            if (HttpContext.Current.Request.RawUrl.IndexOf("Administrator") > 0)
            {
                if (HttpContext.Current.Request.Cookies[Definition.Portal_Admin_Cookie] != null)
                {
                    if (HttpContext.Current.Request.Cookies[Definition.Portal_Admin_Cookie].Value != string.Empty)
                    {
                        strOutput = HttpContext.Current.Request.Cookies[Definition.Portal_Admin_Cookie].Value;
                    }
                    else
                    {
                        strOutput = GetDefaultLanguage();
                    }
                }
                else
                {
                    strOutput = GetDefaultLanguage();
                }
            }
            else
            {
                if (HttpContext.Current.Request.Cookies[Definition.Portal_Cookie] != null)
                {
                    if (HttpContext.Current.Request.Cookies[Definition.Portal_Cookie].Value != string.Empty)
                    {
                        strOutput = HttpContext.Current.Request.Cookies[Definition.Portal_Cookie].Value;
                    }
                    else
                    {
                        strOutput = GetDefaultLanguage();
                    }
                }
                else
                {
                    strOutput = GetDefaultLanguage();
                }
            }
            return strOutput;
        }

        public static string GetDefaultLanguage()
        {
            string strLanguage = "";
            if (WebConfigurationManager.AppSettings["Default_Language"] != null)
                strLanguage = WebConfigurationManager.AppSettings["Default_Language"];
            else
                strLanguage = "vi-VN";
            return strLanguage;
        }

        public static string AdminUrlParams(string cmd)
        {
            return ADMIN_CMD + "?portalid=" + HttpContext.Current.Request["portalid"] + "&cmd=" + cmd;
        }

        public static string IframeUrlParams(string cmd)
        {
            return FRAME_PAGE + "?portalid=" + HttpContext.Current.Request["portalid"] + "&cmd=" + cmd;
        }

        public static int PortalId()
        {

            int portalId = ConvertUtility.ToInt32(HttpContext.Current.Request["portalid"]);
            if (portalId == 0)
            {
                portalId = 1;// ConvertUtility.ToInt32(PortalSetting.GetSetting()[Definition.Portal_Active + "_" + AppEnv.GetLanguage()]);
            }
            return portalId;
        }
        public static int CommandID()
        {
            return CommandController.GetCommand(ConvertUtility.ToString(HttpContext.Current.Request["cmd"])).CommandID;
        }

        public static string DateTimeNow()
        {
            if (DateTime.Now.ToString("ddd") != "cn")
            {
                if (GetLanguage() == "vi-VN")
                {
                    return "Thứ " + DateTime.Now.ToString("ddd") + ", " + DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    return DateTime.Now.ToString("ddd") + ", " + DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
            else
            {
                if (GetLanguage() == "vi-VN")
                {
                    return "Chủ nhật, " + DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    return DateTime.Now.ToString("dd/MM/yyyy");

                }
            }
        }

        public static void LogFile(string message)
        {
            FileInfo f = new FileInfo(HttpContext.Current.Server.MapPath("/Logservice.txt"));
            if (!f.Exists)
            {
                f.Create();
                TextWriter tw = f.AppendText();

                tw.WriteLine(message);
                tw.Flush();
                tw.Close();
            }
            else
            {
                TextWriter tw = f.AppendText(); ; // new StreamWriter(HttpContext.Current.Server.MapPath("/Logservice.txt"));

                tw.WriteLine(message);
                tw.Flush();
                tw.Close();
            }

        }

        public const string DEFAULT_PAGE = "/Default.aspx";
        public const string DEFAULT_EXTENTSION = ".html";
        public const string FRAME_PAGE = "/Frame.aspx";
        public const string ADMIN_CMD = "/Default.aspx";
        public const string ACCESSDENY = "/Default.aspx?cmd=accessdeny";

        private const string CONFIG_FILENAME = "/Module_Control/Customer/Customer.config";
        private const string GAMECONFIG_FILENAME = "/Module_Control/Sport_Game/game.config";
        public static string Server_Mail
        {
            get { return ConvertUtility.ToString(AppEnv.GetAppSetting("ServerMail", CONFIG_FILENAME)); }
        }

        public static string Username_Mail
        {
            get { return ConvertUtility.ToString(AppEnv.GetAppSetting("Username_Mail", CONFIG_FILENAME)); }
        }
        public static string Password
        {
            get { return ConvertUtility.ToString(AppEnv.GetAppSetting("Password", CONFIG_FILENAME)); }
        }


        public static string expand
        {
            get { return ConvertUtility.ToString(AppEnv.GetAppSetting("expand", GAMECONFIG_FILENAME)); }
        }

        public static DataTable GetDataFromXML(string path)
        {
            DataSet data = new DataSet();

            data.ReadXml(HttpContext.Current.Server.MapPath(path));
            DataTable dtRoot = data.Tables[0];
            return dtRoot;
        }

        public static int Customer_ID()
        {
            return ConvertUtility.ToInt32(HttpContext.Current.Session["MyPay_CustomerID_OK"]);
        }

        public static string OptismiseTeaser(object teaser)
        {
            //string test = teaser.ToString().Replace("\"", "").Replace("\r\n", "").Replace("'", "");
            return teaser.ToString().Replace("<br>", "").Replace("\"", "").Replace("\r\n", "").Replace("\n", "<br />").Replace("\r", "").Replace("'", "");
        }
    }
}
