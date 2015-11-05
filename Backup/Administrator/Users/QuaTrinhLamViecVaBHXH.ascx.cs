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
    public partial class QuaTrinhLamViecVaBHXH : AuthenticatedControl
    {
        int userId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userId = ConvertUtility.ToInt32(Request.QueryString["uid"]);

                if (userId > 0)
                {
                    if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                    {
                        btnUpdate.Visible = false;
                    }

                    UserInfo info = UserController.GetUser(userId);

                    txtCongty.Text = info.QTLVCongTy;
                    txtChucDanh.Text = info.QTLVChucDanh;
                    txtLyDo.Text = info.QTLVLyDoChuyenDoi;

                    txtBHXDDongTu.Text = info.BHXHThoiGianDong;
                    txtSoSoBHXH.Text = info.BHXHSoSo;
                    txtGhiChu.Text = info.BHXHGhiChu;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfo user = new UserInfo();
                user.UserID = ConvertUtility.ToInt32(Request.QueryString["uid"]);

                user.QTLVCongTy = txtCongty.Text.Trim();
                user.QTLVChucDanh = txtChucDanh.Text.Trim();
                user.QTLVLyDoChuyenDoi = txtLyDo.Text.Trim();

                user.BHXHThoiGianDong = txtBHXDDongTu.Text.Trim();
                user.BHXHSoSo = txtSoSoBHXH.Text.Trim();
                user.BHXHGhiChu = txtGhiChu.Text.Trim();

                UserController.UpdateUserQuaTrinhLamViec(user);

                lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;

            }
            catch (Exception ex)
            {
                lblUpdateStatus.Text = ex.Message;
            }
        }
    }
}