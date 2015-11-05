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
    public partial class ThongTinGiaDinh : AuthenticatedControl
    {
        int userId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userId = ConvertUtility.ToInt32(Request.QueryString["uid"]);
                if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                {
                    btnUpdate.Visible = false;
                }
                if (userId > 0)
                {
                    UserInfo info = UserController.GetUser(userId);

                    txtHoTenVoChong.Text = info.TTGDHoTenVoChong;
                    txtNamSinhVoChong.Text = info.TTGDNamSinhVoChong;
                    txtNgheNghiepNoiCongTac.Text = info.TTGDNgheNgiep;

                    txtHoTenCon.Text = info.TTGDHoTenCon;
                    txtNamSinhCon.Text = info.TTGDNamSinhCon;
                    txtGioiTinhCon.Text = info.TTGDGioiTinhCon;

                    txtNguoiLienHe.Text = info.TTGDNguoiLienHe;

                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfo user = new UserInfo();
                user.UserID = ConvertUtility.ToInt32(Request.QueryString["uid"]);

                user.TTGDHoTenVoChong = txtHoTenVoChong.Text.Trim();
                user.TTGDNamSinhVoChong = txtNamSinhVoChong.Text.Trim();
                user.TTGDNgheNgiep = txtNgheNghiepNoiCongTac.Text.Trim();

                user.TTGDHoTenCon = txtHoTenCon.Text.Trim();
                user.TTGDNamSinhCon = txtNamSinhCon.Text.Trim();
                user.TTGDGioiTinhCon = txtGioiTinhCon.Text.Trim();

                user.TTGDNguoiLienHe = txtNguoiLienHe.Text.Trim();

                UserController.UpdateUserThongTinGiaDinh(user);

                lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;

            }
            catch (Exception ex)
            {
                lblUpdateStatus.Text = ex.Message;
            }
        }
    }
}