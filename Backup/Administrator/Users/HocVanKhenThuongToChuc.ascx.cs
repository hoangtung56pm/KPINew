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
    public partial class HocVanKhenThuongToChuc : AuthenticatedControl
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

                    txtBangCap.Text = info.HocVanBangCap;
                    txtNoiDaoTao.Text = info.HocVanNoiDaoTao;
                    txtChuyenNganh.Text = info.HocVanChuyenNganh;
                    txtCacKhoaHocKhac.Text = info.HocVanCacKhoaHocKhac;
                    txtNgoaiNgu.Text = info.HocVanNgoaiNgu;

                    txtToChucDoanThe.Text = info.ToChucDoanHiepHoi;
                    txtNgayGiaNhap.Text = info.ToChucNgayGiaNhap;
                    txtNoiKetNap.Text = info.ToChucNoiKetNap;

                    txtGiaiThuong.Text = info.KhenThuongGiaiThuong;
                    txtToChucTraoThuong.Text = info.KhenThuongToChucTrao;
                    txtNamTraoThuong.Text = info.KhenThuongNamTrao;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfo user = new UserInfo();

                user.UserID = ConvertUtility.ToInt32(Request.QueryString["uid"]);

                user.HocVanBangCap = txtBangCap.Text.Trim();
                user.HocVanNoiDaoTao = txtNoiDaoTao.Text.Trim();
                user.HocVanChuyenNganh = txtChuyenNganh.Text.Trim();
                user.HocVanCacKhoaHocKhac = txtCacKhoaHocKhac.Text.Trim();
                user.HocVanNgoaiNgu = txtNgoaiNgu.Text.Trim();

                user.ToChucDoanHiepHoi = txtToChucDoanThe.Text.Trim();
                user.ToChucNgayGiaNhap = txtNgayGiaNhap.Text.Trim();
                user.ToChucNoiKetNap = txtNoiKetNap.Text.Trim();

                user.KhenThuongGiaiThuong = txtGiaiThuong.Text.Trim();
                user.KhenThuongToChucTrao = txtToChucTraoThuong.Text.Trim();
                user.KhenThuongNamTrao = txtNamTraoThuong.Text.Trim();

                UserController.UpdateUserHocVanToChucDoanTheKhenThuong(user);

                lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;

            }
            catch (Exception ex)
            {
                lblUpdateStatus.Text = ex.Message;
            }
        }
    }
}