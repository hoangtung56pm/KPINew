using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library.Components.Security;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using VmgPortal.Modules.KPIData.Library.Common;
using VmgPortal.Library.Components.Users;
using VmgPortal.Library.Utilities;

namespace VmgPortal.Administrator.Users
{
    public partial class HDLDGH3GH4GH5 : AuthenticatedControl
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

                    txtNgayKyGiaHan3.Text = info.HDLD3NgayKyGiaHan;
                    txtNguoiKyGiaHan3.Text = info.HDLD3NguoiKyGiaHan;
                    txtQuyetDinhSo3.Text = info.HDLD3QDSo;
                    txtNgayHieuLuc3.Text = info.HDLD3NgayHieuLuc;
                    txtNgayHetHan3.Text = info.HDLD3NgayHetHan;
                    txtThoiHan3.Text = info.HDLD3ThoiHan;

                    txtNgayKyGiaHan4.Text = info.HDLD4NgayKyGiaHan;
                    txtNguoiKyGiaHan4.Text = info.HDLD4NguoiKyGiaHan;
                    txtQuyetDinhSo4.Text = info.HDLD4QDSo;
                    txtNgayHieuLuc4.Text = info.HDLD4NgayHieuLuc;
                    txtNgayHetHan4.Text = info.HDLD4NgayHetHan;
                    txtThoiHan4.Text = info.HDLD4ThoiHan;

                    txtNgayKyGiaHan5.Text = info.HDLD5NgayKyGiaHan;
                    txtNguoiKyGiaHan5.Text = info.HDLD5NguoiKyGiaHan;
                    txtQuyetDinhSo5.Text = info.HDLD5QDSo;
                    txtNgayHieuLuc5.Text = info.HDLD5NgayHieuLuc;
                    txtNgayHetHan5.Text = info.HDLD5NgayHetHan;
                    txtThoiHan5.Text = info.HDLD5ThoiHan;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfo user = new UserInfo();

                user.UserID = ConvertUtility.ToInt32(Request.QueryString["uid"]);

                user.HDLD3NgayKyGiaHan = txtNgayKyGiaHan3.Text.Trim();
                user.HDLD3NguoiKyGiaHan = txtNguoiKyGiaHan3.Text.Trim();
                user.HDLD3QDSo = txtQuyetDinhSo3.Text.Trim();
                user.HDLD3NgayHieuLuc = txtNgayHieuLuc3.Text.Trim();
                user.HDLD3NgayHetHan = txtNgayHetHan3.Text.Trim();
                user.HDLD3ThoiHan = txtThoiHan3.Text.Trim();

                user.HDLD4NgayKyGiaHan = txtNgayKyGiaHan4.Text.Trim();
                user.HDLD4NguoiKyGiaHan = txtNguoiKyGiaHan4.Text.Trim();
                user.HDLD4QDSo = txtQuyetDinhSo4.Text.Trim();
                user.HDLD4NgayHieuLuc = txtNgayHieuLuc4.Text.Trim();
                user.HDLD4NgayHetHan = txtNgayHetHan4.Text.Trim();
                user.HDLD4ThoiHan = txtThoiHan4.Text.Trim();

                user.HDLD5NgayKyGiaHan = txtNgayKyGiaHan5.Text.Trim();
                user.HDLD5NguoiKyGiaHan = txtNguoiKyGiaHan5.Text.Trim();
                user.HDLD5QDSo = txtQuyetDinhSo5.Text.Trim();
                user.HDLD5NgayHieuLuc = txtNgayHieuLuc5.Text.Trim();
                user.HDLD5NgayHetHan = txtNgayHetHan5.Text.Trim();
                user.HDLD5ThoiHan = txtThoiHan5.Text.Trim();

                UserController.UpdateUserHDLDGH345(user);

                lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;

            }
            catch (Exception ex)
            {
                lblUpdateStatus.Text = ex.Message;
            }
        }
    }
}