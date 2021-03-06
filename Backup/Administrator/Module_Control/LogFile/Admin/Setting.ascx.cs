using System;
using System.Web.UI;

using VmgPortal.Library.Components.Portal;
using VmgPortal.Library.Utilities;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Components.Portal;

namespace VmgPortal.Modules.LogFile.Admin
{
    public partial class Setting : AuthenticatedControl
    {
        public const string Main_LogFileTime = "Main.LogFileTime";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string logfiletime = ConvertUtility.ToString(Portal[Main_LogFileTime]);
                if (logfiletime == "0" || logfiletime == "" || logfiletime == null)
                {
                    chkLog.Checked = true;
                    txtdays.Text = "";
                }
                else
                {
                    chkLog.Checked = false;
                    string temp = logfiletime.Substring(0, 1);
                    // kiểm tra xem kiểu lưu trữ là theo năm, tháng hay ngày
                    // 1 -> năm, 2 -> tháng, 3 -> ngày
                    if (temp == "1")
                        txtyears.Text = logfiletime.Substring(1);
                    else if (temp == "2")
                        txtmonths.Text = logfiletime.Substring(1);
                    else
                        txtdays.Text = logfiletime.Substring(1);
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (chkLog.Checked)
            {
                PortalSetting.SetValue(Main_LogFileTime, "0");
            }
            else
            {
                if (txtyears.Text != "" && ConvertUtility.ToInt32(txtyears.Text) > 0)
                    PortalSetting.SetValue(Main_LogFileTime, "1" + txtyears.Text);
                else if (txtmonths.Text != "" && ConvertUtility.ToInt32(txtmonths.Text) > 0)
                    PortalSetting.SetValue(Main_LogFileTime, "2" + txtmonths.Text);
                else
                    PortalSetting.SetValue(Main_LogFileTime, "3" + txtdays.Text);
            }
        }
    }
}