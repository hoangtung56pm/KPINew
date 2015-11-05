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
using VmgPortal.Library.Components.Roles;
using VmgPortal.Library;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;

namespace VmgPortal.Administrator.Users
{
    public partial class LyLichCaNhan : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!CurrentUser.IsSuperAdmin)
                {
                    pnlSuperadmin.Visible = false;
                    pnlAdmin.Visible = false;
                }
                else
                {
                    pnlSuperadmin.Visible = true;
                    pnlAdmin.Visible = true;
                }

                dropTrungTam.DataSource = BoPhanController.GetAll();
                dropTrungTam.DataBind();
                dropTrungTam.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));

                dropChucVu.DataSource = CommonController.GetAllChucVu();
                dropChucVu.DataBind();
                dropChucVu.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));

                int userId = ConvertUtility.ToInt32(Request.QueryString["uid"]);

                if (userId > 0)
                {
                    if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                    {
                        btnUpdate.Visible = false;
                    }

                    divMK.Visible = divXNMK.Visible = false;
                    UserInfo info = UserController.GetUser(userId);

                    txtUsername.Text = info.Username;
                    txtDisplayName.Text = info.DisplayName;

                    txtMaSo.Text = info.MaSo;
                    txtFullName.Text = info.HoTen;
                    txtNgaySinh.Text = info.NgaySinh.ToString("dd/MM/yyyy");
                    dropGioiTinh.Text = info.GioiTinh.ToString();
                    dropChucVu.Text = info.IDChucVu.ToString();
                    dropTrungTam.SelectedValue = info.IDTrungTam.ToString();

                    if (ConvertUtility.ToInt32(dropTrungTam.SelectedValue) > 0)
                    {
                        dropPhong.DataSource = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
                        dropPhong.DataBind();
                        dropPhong.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));
                        dropPhong.SelectedValue = info.IDPhong.ToString();
                    }
                    else
                    {
                        dropPhong.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));
                    }

                    txtNoiSinh.Text = info.NoiSinh;
                    txtNguyenQuan.Text = info.NguyenQuan;
                    txtQuocTich.Text = info.QuocTich;                   
                    txtDanToc.Text = info.DanToc;
                    txtTonGiao.Text = info.TonGiao;
                    txtDiaChiThuongChu.Text = info.DiaChiThuongChu;
                    txtDiaChiTamChu.Text = info.DiaChiTamChu;
                    chkIsAdmin.Checked = info.IsAdmin;
                    chkIsSuperAdmin.Checked = info.IsSuperAdmin;
                    dropTrangThai.SelectedValue = info.TrangThai.ToString();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int userId = ConvertUtility.ToInt32(Request.QueryString["uid"]);

                    UserInfo user = new UserInfo();
                    user.Username = txtUsername.Text.Trim();                    
                    user.DisplayName = txtDisplayName.Text.Trim();
                    user.IsAdmin = chkIsAdmin.Checked;
                    user.IsSuperAdmin = chkIsSuperAdmin.Checked;

                    user.MaSo = txtMaSo.Text.Trim();
                    user.HoTen = txtFullName.Text.Trim();
                    user.NgaySinh = ConvertUtility.ToDateTime(txtNgaySinh.Text.Trim());
                    user.GioiTinh = ConvertUtility.ToInt32(dropGioiTinh.SelectedValue);
                    user.IDChucVu = ConvertUtility.ToInt32(dropChucVu.SelectedValue);
                    user.IDTrungTam = ConvertUtility.ToInt32(dropTrungTam.SelectedValue);
                    user.IDPhong = ConvertUtility.ToInt32(dropPhong.SelectedValue);
                    user.NoiSinh = txtNoiSinh.Text.Trim();
                    user.NguyenQuan = txtNguyenQuan.Text.Trim();
                    user.QuocTich = txtQuocTich.Text.Trim();

                    user.DanToc = txtDanToc.Text.Trim();
                    user.TonGiao = txtTonGiao.Text.Trim();
                    user.DiaChiThuongChu = txtDiaChiThuongChu.Text.Trim();
                    user.DiaChiTamChu = txtDiaChiTamChu.Text.Trim();
                    user.TrangThai = ConvertUtility.ToInt32(dropTrangThai.SelectedValue);

                    if (userId > 0)
                    {
                        user.UserID = userId;
                        UserController.UpdateUser(user);

                        lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;
                    }
                    else
                    {
                        if (txtPassword.Text.Trim() != txtPasswordConfirm.Text.Trim())
                        {
                            return;
                        }
                        user.Password = SecurityMethod.MD5Encrypt(txtPassword.Text.Trim());
                        userId = UserController.AddUser(user);

                        if (userId > 0)
                        {
                            RoleController.AddUserToRole(userId, 4, AppEnv.PortalId());

                            Response.Redirect(AppEnv.AdminUrlParams("createuser") + "&uid=" + userId);
                        }
                        else
                        {
                            lblUpdateStatus.Text = "Tên đăng nhập lại đã tồn tại.";
                        }
                    }

                }
                catch (Exception ex)
                {
                    lblUpdateStatus.Text = ex.Message;
                }
            }
        }

        protected void dropTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropPhong.Items.Clear();
            dropPhong.DataSource = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            dropPhong.DataBind();
            dropPhong.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));

            txtPassword.Text = "111111";
            txtPasswordConfirm.Text = "111111";
        }
    }
}