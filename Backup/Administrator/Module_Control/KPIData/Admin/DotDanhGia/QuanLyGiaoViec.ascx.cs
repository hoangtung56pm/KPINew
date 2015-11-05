using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library.Components.Security;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;
using System.Data;
using VmgPortal.Library.Utilities;

namespace VmgPortal.Modules.KPIData.Admin.DotDanhGia
{
    public partial class QuanLyGiaoViec : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (ConvertUtility.ToInt32(Session["Nav"]) == 1)
            {
                litNav.Text = "";
                litNav.Text += "<ul class=\"nav nav-tabs\">";
                litNav.Text += "<li class=\"active\"><a data-toggle=\"tab\" href=\"#tab_0\"><b>CÔNG VIỆC THƯỜNG XUYÊN</b></a></li>";
                litNav.Text += "<li class=\"\"><a data-toggle=\"tab\" href=\"#tab_1\"><b>CÔNG VIỆC KẾ HOẠCH THÁNG</b></a></li>";
                litNav.Text += "<li class=\"\"><a data-toggle=\"tab\" href=\"#tab_2\"><b>CÔNG VIỆC PHÁT SINH</b></a></li>";
                litNav.Text += "</ul>";
                litTab0.Text = "<div id=\"tab_0\" class=\"tab-pane active\">";
                litTab1.Text = "<div id=\"tab_1\" class=\"tab-pane\">";
                litTab2.Text = "<div id=\"tab_2\" class=\"tab-pane\">";
            }
            else if (ConvertUtility.ToInt32(Session["Nav"]) == 2)
            {
                litNav.Text = "";
                litNav.Text += "<ul class=\"nav nav-tabs\">";
                litNav.Text += "<li class=\"\"><a data-toggle=\"tab\" href=\"#tab_0\"><b>CÔNG VIỆC THƯỜNG XUYÊN</b></a></li>";
                litNav.Text += "<li class=\"active\"><a data-toggle=\"tab\" href=\"#tab_1\"><b>CÔNG VIỆC KẾ HOẠCH THÁNG</b></a></li>";
                litNav.Text += "<li class=\"\"><a data-toggle=\"tab\" href=\"#tab_2\"><b>CÔNG VIỆC PHÁT SINH</b></a></li>";
                litNav.Text += "</ul>";
                litTab0.Text = "<div id=\"tab_0\" class=\"tab-pane\">";
                litTab1.Text = "<div id=\"tab_1\" class=\"tab-pane active\">";
                litTab2.Text = "<div id=\"tab_2\" class=\"tab-pane\">";
            }
            else if (ConvertUtility.ToInt32(Session["Nav"]) == 3)
            {
                litNav.Text = "";
                litNav.Text += "<ul class=\"nav nav-tabs\">";
                litNav.Text += "<li class=\"\"><a data-toggle=\"tab\" href=\"#tab_0\"><b>CÔNG VIỆC THƯỜNG XUYÊN</b></a></li>";
                litNav.Text += "<li class=\"\"><a data-toggle=\"tab\" href=\"#tab_1\"><b>CÔNG VIỆC KẾ HOẠCH THÁNG</b></a></li>";
                litNav.Text += "<li class=\"active\"><a data-toggle=\"tab\" href=\"#tab_2\"><b>CÔNG VIỆC PHÁT SINH</b></a></li>";
                litNav.Text += "</ul>";
                litTab0.Text = "<div id=\"tab_0\" class=\"tab-pane\">";
                litTab1.Text = "<div id=\"tab_1\" class=\"tab-pane\">";
                litTab2.Text = "<div id=\"tab_2\" class=\"tab-pane active\">";
            }
            else
            {
                litNav.Text = "";
                litNav.Text += "<ul class=\"nav nav-tabs\">";
                litNav.Text += "<li class=\"active\"><a data-toggle=\"tab\" href=\"#tab_0\"><b>CÔNG VIỆC THƯỜNG XUYÊN</b></a></li>";
                litNav.Text += "<li class=\"\"><a data-toggle=\"tab\" href=\"#tab_1\"><b>CÔNG VIỆC KẾ HOẠCH THÁNG</b></a></li>";
                litNav.Text += "<li class=\"\"><a data-toggle=\"tab\" href=\"#tab_2\"><b>CÔNG VIỆC PHÁT SINH</b></a></li>";
                litNav.Text += "</ul>";
                litTab0.Text = "<div id=\"tab_0\" class=\"tab-pane active\">";
                litTab1.Text = "<div id=\"tab_1\" class=\"tab-pane\">";
                litTab2.Text = "<div id=\"tab_2\" class=\"tab-pane\">";
            }
        }
    }
}