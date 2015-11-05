using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using VmgPortal.Library;
using VmgPortal.Library.Components;
using VmgPortal.Library.Components.Portal;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Utilities;
using System.Text;
using VmgPortal.Library.Components.Commands;
using System.Collections;
using System.Collections.Generic;


namespace VmgPortal.Administrator.UserControls
{
    public partial class NavPanel : AuthenticatedControl
    {
        private string cmd = string.Empty;
        private string _path = string.Empty;
        private int portalid = 0;
        StringBuilder sb = new StringBuilder();

        string fmAd = "<a href=\"{0}\"><i class=\"{2}\"></i><span class=\"title\">{1}</span></a>";
        string fmAu = "<a href=\"{0}\"><i class=\"{2}\"></i><span class=\"title\">{1}</span><span class=\"arrow\"></span></a>";
        private List<string> listCmd = new List<string>();
        string fmAdS = "<a href=\"{0}\"><span class=\"title\">{1}</span></a>";
        string fmAuS = "<a href=\"{0}\"><span class=\"title\">{1}</span><span class=\"arrow\"></span></a>";        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cmd = Request.QueryString["cmd"].ToString();
            }
            catch
            {
            }

            if (!Page.IsPostBack)
            {
                LoadSidebar();
            }

        }

        private void LoadSidebar()
        {

            radmMenu.Text = "";
            //GetPath();
            try
            {
                cmd = ConvertUtility.ToString(Request.QueryString["cmd"]);
            }
            catch
            {
                cmd = "";
            }
            portalid = ConvertUtility.ToInt32(Request.QueryString["portalid"]);
            DataTable dtCommands = null;

            if (!CurrentUser.IsSuperAdmin)
            {
                dtCommands = CommandController.GetCommandsForUserByPortalID(CurrentUser.UserID, portalid);
            }
            else
            {
                dtCommands = CommandController.GetCommands();
            }

            
            if (cmd != "")
            {
                DataRow[] _lstCommands = dtCommands.Select("CommandKey = '" + cmd + "' AND CommandVisible = 1");
                foreach (DataRow row in _lstCommands)
                {
                    listCmd.Add(row["CommandID"].ToString());
                    if (row["CommandParentID"].ToString() != "0")
                    {
                        LoadParentCommand(ConvertUtility.ToInt32(row["CommandParentID"].ToString()), dtCommands, ref listCmd);
                    }
                    break;
                }
            }

            DataRow[] drRoots = dtCommands.Select("CommandParentID = 0");
            int _count = 0;

            if (ConvertUtility.ToString(Request.QueryString["cmd"]) == "")
            {
                sb.Append("<li class=\"start active\"><a href=\"/\"><i class=\"icon-home\"></i><span class=\"title\">Home</span><span class=\"selected\"></span></a></li>");
            }
            else
            {
                sb.Append("<li><a href=\"/\"><i class=\"icon-home\"></i><span class=\"title\">Home</span><span class=\"selected\"></span></a></li>");
            }

            foreach (DataRow row in drRoots)
            {
                string name = "";
                string url = "";
                name = row["CommandName"].ToString();
                //_item.Value = row["CommandID"].ToString();

                int curItem = ConvertUtility.ToInt32(row["CommandID"].ToString());
                DataRow[] _lstCommands = dtCommands.Select("CommandParentID = " + curItem + " AND CommandVisible = 1");

                if (!string.IsNullOrEmpty(row["CommandUrl"].ToString().Trim()))
                {
                    url = row["CommandUrl"].ToString();
                }
                else if (!string.IsNullOrEmpty(row["CommandKey"].ToString().Trim()))
                {
                    url = AppEnv.AdminUrlParams(row["CommandKey"].ToString()) + row["CommandParams"].ToString();
                }
                if (ConvertUtility.ToBoolean(row["CommandVisible"]) == false || ConvertUtility.ToBoolean(row["CommandEnable"]) == false)
                {
                    continue;
                }
                if (listCmd.Contains(row["CommandID"].ToString()))
                {
                     if (_count == 0)
                        sb.Append("<li class=\"start active\">");
                    else
                        sb.Append("<li class=\"active\">");
                }
                else
                {
                      if (_count == 0)
                        sb.Append("<li class=\"\">");
                    else
                        sb.Append("<li>");
                }

                if (_lstCommands.Length > 0)
                {
                    if (_count == 0)
                        sb.Append(string.Format(fmAu, url, name, "icon-gift"));
                    else 
                        sb.Append(string.Format(fmAu, url, name, "icon-gift"));
                    sb.Append("<ul class=\"sub-menu\">");
                    LoadSidebarItems(ConvertUtility.ToInt32(row["CommandID"].ToString()), dtCommands);
                    sb.Append("</ul>");
                }
                else
                {
                    if (_count == 0)
                        sb.Append(string.Format(fmAd, url, name, "icon-home"));
                    else
                        sb.Append(string.Format(fmAd, url, name, "icon-gift"));
                }
                sb.Append("</li>");
                _count++;
            }
            radmMenu.Text = sb.ToString();
        }
        private void LoadSidebarItems(int curItem, DataTable dtCommands)
        {
            int _curCommandId = ConvertUtility.ToInt32(curItem);
            DataRow[] _lstCommands = dtCommands.Select("CommandParentID = " + curItem + " AND CommandVisible = 1");
            foreach (DataRow row in _lstCommands)
            {
                if (ConvertUtility.ToBoolean(row["CommandVisible"]) == false || ConvertUtility.ToBoolean(row["CommandEnable"]) == false)
                {
                    continue;
                }
                string name = "";
                string url = "";

                name = row["CommandName"].ToString();
                //_item.Value = row["CommandID"].ToString();
                if (!String.IsNullOrEmpty(row["CommandUrl"].ToString().Trim()))
                {
                    url = row["CommandUrl"].ToString();
                }
                else if (row["CommandKey"].ToString() != string.Empty)
                {
                    url = AppEnv.AdminUrlParams(row["CommandKey"].ToString()) + row["CommandParams"].ToString();
                }

                curItem = ConvertUtility.ToInt32(row["CommandID"].ToString());
                _lstCommands = dtCommands.Select("CommandParentID = " + curItem + " AND CommandVisible = 1");

                if (listCmd.Contains(row["CommandID"].ToString()))
                {                
                        sb.Append("<li class=\"active\">");
                }
                else
                {                   
                        sb.Append("<li>");
                }

                if (_lstCommands.Length > 0)
                {
                    sb.Append(string.Format(fmAuS, url, name));
                    sb.Append("<ul class=\"sub-menu\">");
                    LoadSidebarItems(ConvertUtility.ToInt32(row["CommandID"].ToString()), dtCommands);
                    sb.Append("</ul>");
                }
                else
                {
                    sb.Append(string.Format(fmAdS, url, name));                  
                }
                sb.Append("</li>");
            }
        }


        private void LoadParentCommand(int parentId, DataTable dtCommands, ref List<string> lst)
        {
            DataRow[] _lstCommands = dtCommands.Select("CommandID = " + parentId + " AND CommandVisible = 1");
            foreach (DataRow row in _lstCommands)
            {
                lst.Add(row["CommandID"].ToString());              
                if (row["CommandParentID"].ToString() != "0")                   
                {                   
                    LoadParentCommand(ConvertUtility.ToInt32(row["CommandParentID"].ToString()), dtCommands, ref lst);
                   
                }
                break;
            }
        }
    }
}