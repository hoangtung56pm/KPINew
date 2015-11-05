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
using System.IO;

using Menu=ComponentArt.Web.UI.Menu;
using VmgPortal.Library.Utilities;
using VmgPortal.Library.Components.Security;

namespace VmgPortal.Modules.LogFile.Admin
{
    public partial class LogFile_List : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader(Server.MapPath(Request.QueryString["url"]));
                lblog.Text = reader.ReadToEnd();
                reader.Close();
                lblog.Visible = true;
            }
            catch
            {
                lblog.Visible = false;
            }
            if (IsPostBack) return;
            //mnuHeader = new Menu();
            //Menu mnuHeader = new Menu();
            ComponentArt.Web.UI.MenuItem item = new ComponentArt.Web.UI.MenuItem();
            ComponentArt.Web.UI.MenuItem subItem = new ComponentArt.Web.UI.MenuItem();
            ComponentArt.Web.UI.MenuItem subsubitem = new ComponentArt.Web.UI.MenuItem();
            ComponentArt.Web.UI.MenuItem subsubsubitem = new ComponentArt.Web.UI.MenuItem();
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("/Temp/"));
            if (dir.GetDirectories().Length > 0)
            {
                //mnuHeader = new Menu();
                foreach (DirectoryInfo dinfo in dir.GetDirectories())
                {
                    item = LoadCmdItem(dinfo);
                    item.LookId = "home";
                    if (dinfo.GetDirectories().Length > 0)
                    {
                        foreach (DirectoryInfo subdinfo in dinfo.GetDirectories())
                        {
                            subItem = LoadCmdItem(subdinfo);
                            subItem.LookId = "child";
                            item.Items.Add(subItem);
                            if (subdinfo.GetDirectories().Length > 0)
                            {
                                foreach (DirectoryInfo subsubinfo in subdinfo.GetDirectories())
                                {
                                    subsubitem = LoadCmdItem(subsubinfo);
                                    subsubitem.LookId = "child1";
                                    subItem.Items.Add(subsubitem);
                                    if (subsubinfo.GetFiles().Length > 0)
                                    {
                                        foreach (FileInfo finfo in subsubinfo.GetFiles())
                                        {
                                            subsubsubitem = LoadCmdsubItem(subdinfo, subsubinfo, finfo);
                                            subsubsubitem.LookId = "child2";
                                            subsubitem.Items.Add(subsubsubitem);
                                        }
                                    }
                                }
                            }
                            item.Attributes.Add("Style", "cursor:hand");
                            subItem.Attributes.Add("Style", "cursor:hand");
                            subsubitem.Attributes.Add("Style", "cursor:hand");
                            subsubsubitem.Attributes.Add("Style", "cursor:hand");
                        }
                    }
                    //mnuHeader.Items.Add(item);
                    mnuCommands.Items.Add(item);
                }
            } 
        }
        private static  ComponentArt.Web.UI.MenuItem LoadCmdItem(DirectoryInfo subdir)
        {
            ComponentArt.Web.UI.MenuItem retVal = new ComponentArt.Web.UI.MenuItem();
            retVal.Text = subdir.Name;
            return retVal;
        }
        private static  ComponentArt.Web.UI.MenuItem LoadCmdsubItem(DirectoryInfo dir, DirectoryInfo subdir, FileInfo finfo)
        {
            ComponentArt.Web.UI.MenuItem retVal = new ComponentArt.Web.UI.MenuItem();
            retVal.Text = finfo.Name;
            //			string domain = Request.Url.Host;
            //			string port = Request.Url.Port.ToString();
            string redirect = "";
            //			if(domain.LastIndexOf(".")<=0)
            redirect = "/Temp/" + dir.Parent.Name + "/" + subdir.Parent.Name + "/" + subdir.Name + "/" + finfo.Name;
            //			else
            //				redirect = "http://" + domain + "/Temp/"+ dir.Parent.Name + "/" + subdir.Parent.Name + "/"+subdir.Name+"/"+finfo.Name;
            retVal.NavigateUrl = MiscUtility.UpdateQueryStringItem(HttpContext.Current.Request, "url", redirect);
            return retVal;
        }
    }
}