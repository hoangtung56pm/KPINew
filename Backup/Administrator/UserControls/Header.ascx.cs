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

namespace VmgPortal.Administrator.UserControls
{
	public partial class Header : AuthenticatedControl
	{
        private string cmd = string.Empty;
        private string _path = string.Empty;
        private int portalid = 0;
        StringBuilder sb = new StringBuilder();
        string fmUi = "<li><a href=\"{0}\">{1}</a></li>";
        string fmA = "<a href=\"{0}\">{1}</a>";
        string fmAd = "<a data-toggle=\"dropdown\" data-hover=\"dropdown\" data-close-others=\"true\" class=\"dropdown-toggle\" href=\"{0}\">{1}<i class=\"icon-angle-down\"></i></a>";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadSidebar();

                lblCurrentUser.Text = CurrentUser.Username.Replace("@vmgmedia.vn","");
                if (AppEnv.GetLanguage() == "vi-VN")
                {
                    hplChangePass.Text = "<i class=\"icon-user\"></i> Hồ sơ cá nhân";
                    btnLogout.Text = "<i class=\"icon-key\"></i> Đăng xuất";
                    trigger_fullscreen.Text = "<i class=\"icon-move\"></i> Toàn màn hình</a>";
                    btnEng.Text = "<i class=\"icon-female\"></i> Tiếng Anh</a>";
                    btnViet.Text = "<i class=\"icon-male\"></i> Tiếng Việt</a>";
                }
                else
                {
                    hplChangePass.Text = "<i class=\"icon-user\"></i> Edit profile";
                    btnLogout.Text = "<i class=\"icon-key\"></i> Log Out";
                    trigger_fullscreen.Text = "<i class=\"icon-move\"></i> Full Screen</a>";
                    btnEng.Text = "<i class=\"icon-female\"></i> English</a>";
                    btnViet.Text = "<i class=\"icon-male\"></i> Vietnamese</a>";
                }

                HttpRequest htp = HttpContext.Current.Request;
                if (!CurrentUser.IsSuperAdmin)
                {
                    PortalController.LoadPortalsForRadComboByUserIDGenLi(ltrPortal, htp, CurrentUser.UserID);
                }
                else
                {
                    PortalController.LoadPortalsForRadComboLi(ltrPortal, htp);
                }

                hplChangePass.NavigateUrl = "/Default.aspx?portalid=" + AppEnv.PortalId() + "&cmd=createuser&uid=" + CurrentUser.UserID + "&lang=" + AppEnv.GetLanguage();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            AuthenticateUtility.LogoutUser();
            Response.Redirect("/");
        }

        protected void btnViet_Click(object sender, EventArgs e)
        {
            AppEnv.SetLanguage("vi-VN");
            string curUrl = Request.RawUrl;
            string newUrl = string.Empty;
            if (curUrl.IndexOf("&lang") > -1)
                newUrl = curUrl.Substring(0, curUrl.IndexOf("&lang"));
            else if (curUrl.IndexOf("?lang") > -1)
                newUrl = curUrl.Substring(0, curUrl.IndexOf("?lang"));
            else
                newUrl = curUrl;
            DataCaching data = new DataCaching();
            data.RemoveCache("VmgPortal.Portal.Command");
            Response.Redirect(newUrl);
        }

        protected void btnEng_Click(object sender, EventArgs e)
        {
            AppEnv.SetLanguage("en-US");
            string curUrl = Request.RawUrl;
            string newUrl = string.Empty;
            if (curUrl.IndexOf("&lang") > -1)
                newUrl = curUrl.Substring(0, curUrl.IndexOf("&lang"));
            else if (curUrl.IndexOf("?lang") > -1)
                newUrl = curUrl.Substring(0, curUrl.IndexOf("?lang"));
            else
                newUrl = curUrl;
            DataCaching data = new DataCaching();
            data.RemoveCache("VmgPortal.Portal.Command");
            Response.Redirect(newUrl);
        }

        #region Menu Top
        private void LoadSidebar()
        {

            radmMenu.Text = "";
            //GetPath();
            cmd = ConvertUtility.ToString(Request.QueryString["cmd"]);
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

            DataRow[] drRoots = dtCommands.Select("CommandParentID = 0");
            sb.Append("<ul class=\"nav navbar-nav\">");
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

                if (_lstCommands.Length > 0)
                {
                    sb.Append("<li>");
                    sb.Append(string.Format(fmAd, url, name));
                    sb.Append("<ul class=\"dropdown-menu\">");
                    LoadSidebarItems(ConvertUtility.ToInt32(row["CommandID"].ToString()), dtCommands);
                    sb.Append("</ul>");
                    sb.Append("</li>");
                }
                else
                {
                    sb.Append(string.Format(fmUi, url, name));
                }


            }
            sb.Append("</ul>");

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


                if (_lstCommands.Length > 0)
                {
                    sb.Append("<li class=\"dropdown-submenu\">");
                    sb.Append(string.Format(fmA, url, name));
                    sb.Append("<ul class=\"dropdown-menu\">");
                    LoadSidebarItems(ConvertUtility.ToInt32(row["CommandID"].ToString()), dtCommands);
                    sb.Append("</ul>");
                    sb.Append("</li>");
                }
                else
                {
                    sb.Append(string.Format(fmUi, url, name));
                }
            }
        }
        #endregion
	}
}