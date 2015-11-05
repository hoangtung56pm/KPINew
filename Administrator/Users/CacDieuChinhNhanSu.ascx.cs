using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library.Components.Security;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using VmgPortal.Modules.KPIData.Library.Common;
using VmgPortal.Library.Utilities;
using VmgPortal.Library.Components.Users;

namespace VmgPortal.Administrator.Users
{
    public partial class CacDieuChinhNhanSu : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                {
                    btnUpdate.Visible = false;
                }
                int userId = ConvertUtility.ToInt32(Request.QueryString["uid"]);

                if (userId > 0)
                {
                    UserInfo info = UserController.GetUser(userId);

                    txtQuyetDinhSo1.Text = info.DCNSQDSo;
                    txtNgay1.Text = info.DCNSNgay;
                    txtNgayHieuLuc1.Text = info.DCNSNgayHieuLuc;
                    txtChiTietDieuChinh1.Text = info.DCNSChiTiet;

                    txtQuyetDinhSo2.Text = info.DCNSQDSo1;
                    txtNgay2.Text = info.DCNSNgay1;
                    txtNgayHieuLuc2.Text = info.DCNSNgayHieuLuc1;
                    txtChiTietDieuChinh2.Text = info.DCNSChiTiet1;

                    txtQuyetDinhSo3.Text = info.DCNSQDSo2;
                    txtNgay3.Text = info.DCNSNgay2;
                    txtNgayHieuLuc3.Text = info.DCNSNgayHieuLuc2;
                    txtChiTietDieuChinh3.Text = info.DCNSChiTiet2;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfo user = new UserInfo();

                user.UserID = ConvertUtility.ToInt32(Request.QueryString["uid"]);

                user.DCNSQDSo = txtQuyetDinhSo1.Text.Trim();
                user.DCNSNgay = txtNgay1.Text.Trim();
                user.DCNSNgayHieuLuc = txtNgayHieuLuc1.Text.Trim();
                user.DCNSChiTiet = txtChiTietDieuChinh1.Text.Trim();

                user.DCNSQDSo1 = txtQuyetDinhSo2.Text.Trim();
                user.DCNSNgay1 = txtNgay2.Text.Trim();
                user.DCNSNgayHieuLuc1 = txtNgayHieuLuc2.Text.Trim();
                user.DCNSChiTiet1 = txtChiTietDieuChinh2.Text.Trim();

                user.DCNSQDSo2 = txtQuyetDinhSo2.Text.Trim();
                user.DCNSNgay2 = txtNgay2.Text.Trim();
                user.DCNSNgayHieuLuc2 = txtNgayHieuLuc2.Text.Trim();
                user.DCNSChiTiet2 = txtChiTietDieuChinh2.Text.Trim();

                UserController.UpdateUserDieuChinhNhanSu(user);

                lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;

            }
            catch (Exception ex)
            {
                lblUpdateStatus.Text = ex.Message;
            }
        }
    }
}