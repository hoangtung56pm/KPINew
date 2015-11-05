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
    public partial class HDLDBatDauGH1GH2 : AuthenticatedControl
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

                    txtSoHopDong.Text = info.HDLDSHD;
                    txtNguoiKyHopDong.Text = info.HDLDNguoiKy;
                    txtNgayKyHopDong.Text = info.HDLDNgayKy;
                    txtNgayHieuLuc.Text = info.HDLDNgayHieuLuc;
                    txtNgayHetHan.Text = info.HDLDNgayHetHan;
                    txtLoaiHopDong.Text = info.HDLDLoaiHopDong;

                    txtNgayKyGiaHan1.Text = info.HDLD1NgayKyGiaHan;
                    txtNguoiKyGiaHan1.Text = info.HDLD1NguoiKyGiaHan;
                    txtQuyetDinhSo1.Text = info.HDLD1QDSo;
                    txtNgayHieuLuc1.Text = info.HDLD1NgayHieuLuc;
                    txtNgayHetHan1.Text = info.HDLD1NgayHetHan;
                    txtThoiHan1.Text = info.HDLD1ThoiHan;

                    txtNgayKyGiaHan2.Text = info.HDLD2NgayKyGiaHan;
                    txtNguoiKyGiaHan2.Text = info.HDLD2NguoiKyGiaHan;
                    txtQuyetDinhSo2.Text = info.HDLD2QDSo;
                    txtNgayHieuLuc2.Text = info.HDLD2NgayHieuLuc;
                    txtNgayHetHan2.Text = info.HDLD2NgayHetHan;
                    txtThoiHan2.Text = info.HDLD2ThoiHan;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfo user = new UserInfo();

                user.UserID = ConvertUtility.ToInt32(Request.QueryString["uid"]);

                user.HDLDSHD = txtSoHopDong.Text.Trim();
                user.HDLDNguoiKy = txtNguoiKyHopDong.Text.Trim();
                user.HDLDNgayKy = txtNgayKyHopDong.Text.Trim();
                user.HDLDNgayHieuLuc = txtNgayHieuLuc.Text.Trim();
                user.HDLDNgayHetHan = txtNgayHetHan.Text.Trim();
                user.HDLDLoaiHopDong = txtLoaiHopDong.Text.Trim();

                user.HDLD1NgayKyGiaHan = txtNgayKyGiaHan1.Text.Trim();
                user.HDLD1NguoiKyGiaHan = txtNguoiKyGiaHan1.Text.Trim();
                user.HDLD1QDSo = txtQuyetDinhSo1.Text.Trim();
                user.HDLD1NgayHieuLuc = txtNgayHieuLuc1.Text.Trim();
                user.HDLD1NgayHetHan = txtNgayHetHan1.Text.Trim();
                user.HDLD1ThoiHan = txtThoiHan1.Text.Trim();

                user.HDLD2NgayKyGiaHan = txtNgayKyGiaHan2.Text.Trim();
                user.HDLD2NguoiKyGiaHan = txtNguoiKyGiaHan2.Text.Trim();
                user.HDLD2QDSo = txtQuyetDinhSo2.Text.Trim();
                user.HDLD2NgayHieuLuc = txtNgayHieuLuc2.Text.Trim();
                user.HDLD2NgayHetHan = txtNgayHetHan2.Text.Trim();
                user.HDLD2ThoiHan = txtThoiHan2.Text.Trim();

                UserController.UpdateUserHDLDGH1GH2(user);

                lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;

            }
            catch (Exception ex)
            {
                lblUpdateStatus.Text = ex.Message;
            }
        }
    }
}