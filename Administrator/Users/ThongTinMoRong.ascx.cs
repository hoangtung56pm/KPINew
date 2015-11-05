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
    public partial class ThongTinMoRong : AuthenticatedControl
    {
        int userId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                {
                    btnUpdate.Visible = false;
                }
                userId = ConvertUtility.ToInt32(Request.QueryString["uid"]);

                if (userId > 0)
                {
                    UserInfo info = UserController.GetUser(userId);

                    txtMobile.Text = info.SoDienThoaiMobile;
                    txtHome.Text = info.SoDienThoaiHome;

                    txtVmgEmail.Text = info.EmailVNG;
                    txtEmailCaNhan.Text = info.EmailCaNhan;

                    txtSoCMND.Text = info.CMNDSo;
                    txtNgayCapCMND.Text = info.CMNDNgayCap;
                    txtNoiCapCMND.Text = info.CMNDNoiCap;

                    txtSoHoChieu.Text = info.HoChieuSo;
                    txtNgayCapHoChieu.Text = info.HoChieuNgayCap;
                    txtNoiCapHoChieu.Text = info.HoChieuNoiCap;

                    txtSoTKNH.Text = info.TKNNSo;
                    txtNganHang.Text = info.TKNNNganHang;
                    txtChiNhanh.Text = info.TKNNChiNhanh;

                    txtMaSoThueCaNhan.Text = info.MaSoThueCaNhan;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfo user = new UserInfo();

                user.UserID = ConvertUtility.ToInt32(Request.QueryString["uid"]);

                user.SoDienThoaiMobile = txtMobile.Text.Trim();
                user.SoDienThoaiHome = txtHome.Text.Trim();

                user.EmailVNG = txtVmgEmail.Text.Trim();
                user.EmailCaNhan = txtEmailCaNhan.Text.Trim();

                user.CMNDSo = txtSoCMND.Text.Trim();
                user.CMNDNgayCap = txtNgayCapCMND.Text.Trim();
                user.CMNDNoiCap = txtNoiCapCMND.Text.Trim();

                user.HoChieuSo = txtSoHoChieu.Text.Trim();
                user.HoChieuNgayCap = txtNgayCapHoChieu.Text.Trim();
                user.HoChieuNoiCap = txtNoiCapHoChieu.Text.Trim();

                user.TKNNSo = txtSoTKNH.Text.Trim();
                user.TKNNNganHang = txtNganHang.Text.Trim();
                user.TKNNChiNhanh = txtChiNhanh.Text.Trim();

                user.MaSoThueCaNhan = txtMaSoThueCaNhan.Text.Trim();

                UserController.UpdateUserThongTinMoRong(user);

                lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;

            }
            catch (Exception ex)
            {
                lblUpdateStatus.Text = ex.Message;
            }
        }
    }
}