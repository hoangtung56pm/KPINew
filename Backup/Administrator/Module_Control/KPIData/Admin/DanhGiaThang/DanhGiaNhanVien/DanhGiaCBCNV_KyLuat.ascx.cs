using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library.Utilities;
using VmgPortal.Modules.KPIData.Library.DanhGia;
using VmgPortal.Library.Components.Security;
using System.Data;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;
using VmgPortal.Modules.KPIData.Library;
using VmgPortal.Library.Components.Users;

namespace VmgPortal.Modules.KPIData.Admin.DanhGiaThang.DanhGiaNhanVien
{
    public partial class DanhGiaCBCNV_KyLuat : AuthenticatedControl
    {
        int idDotDanhGia = 0;
        int idNhanVien = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            idDotDanhGia = ConvertUtility.ToInt32(Request.QueryString["idDotDanhGia"]);
            idNhanVien = ConvertUtility.ToInt32(Request.QueryString["idNhanVien"]);

            if (idDotDanhGia == 0)
            {
                idDotDanhGia = CurrentUser.IDDotDanhGiaVaNhanVien;
                idNhanVien = CurrentUser.UserID;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            DataTable dt = DotDanhGiaController.checkDanhGiaThang(idDotDanhGia, idNhanVien);

            if (dt != null && dt.Rows.Count > 0)
            {
                if (idNhanVien == CurrentUser.UserID)
                {
                    if (CurrentUser.IsAdmin || CurrentUser.IsSuperAdmin)
                    {
                        btnUpdateAll.Visible = true;

                        td1.Attributes.Add("style", "width:25%");
                        td2.Attributes.Add("style", "width:25%");
                        td3.Attributes.Add("style", "width:25%");
                        td4.Attributes.Add("style", "width:25%");
                        td11.Attributes.Add("style", "width:25%");
                        td21.Attributes.Add("style", "width:25%");
                        td31.Attributes.Add("style", "width:25%");
                        td41.Attributes.Add("style", "width:25%");
                    }
                    else
                    {
                        td1.Attributes.Add("style", "width:25%");
                        td2.Attributes.Add("style", "width:25%");
                        td3.Attributes.Add("style", "width:25%");
                        td4.Attributes.Add("style", "width:25%");
                        td11.Attributes.Add("style", "width:25%");
                        td21.Attributes.Add("style", "width:25%");
                        td31.Attributes.Add("style", "width:25%");
                        td41.Attributes.Add("style", "width:25%");
                        if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) <= (int)Constants.TrangThaiDanhGiaNhanVien.DangDanhGia)
                        {
                            btnUpdateAll.Visible = true;
                        }
                        else
                        {
                            btnUpdateAll.Visible = false;
                        }
                    }
                }
                else
                {
                    btnUpdateAll.Visible = true;
                    td1.Attributes.Add("style", "width:25%");
                    td2.Attributes.Add("style", "width:25%");
                    td3.Attributes.Add("style", "width:25%");
                    td4.Attributes.Add("style", "width:25%");
                    td11.Attributes.Add("style", "width:25%");
                    td21.Attributes.Add("style", "width:25%");
                    td31.Attributes.Add("style", "width:25%");
                    td41.Attributes.Add("style", "width:25%");

                    if (CurrentUser.IsAdmin || CurrentUser.IsSuperAdmin)
                    {
                        btnUpdateAll.Visible = true;
                    }
                    else
                    {
                        if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) == (int)Constants.TrangThaiDanhGiaNhanVien.ThongNhat)
                        {
                            btnUpdateAll.Visible = false;
                        }
                        else
                        {
                            btnUpdateAll.Visible = true;
                        }
                    }
                }

                if (CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiHoTro || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiKinhDoanh)
                {
                    txtPTDanhGia1.Enabled = false;
                    txtPTDanhGia2.Enabled = false;
                }
                else
                {
                    if (idNhanVien == CurrentUser.UserID)
                    {
                        if (CurrentUser.RoleID == (int)Constants.Role.TruongPhong || CurrentUser.RoleID == (int)Constants.Role.PhoPhong)
                        {
                            txtTBPDanhGia1.Enabled = true;
                            txtTBPDanhGia2.Enabled = true;
                            txtTBPDanhGia3.Enabled = true;
                            txtTBPDanhGia4.Enabled = true;
                        }
                    }
                    else
                    {
                        if (CurrentUser.RoleID == (int)Constants.Role.TruongPhong || CurrentUser.RoleID == (int)Constants.Role.PhoPhong)
                        {
                            txtTBPDanhGia1.Enabled = true;
                            txtTBPDanhGia2.Enabled = true;
                            txtTBPDanhGia3.Enabled = true;
                            txtTBPDanhGia4.Enabled = true;
                        }
                        else
                        {
                            txtPTDanhGia1.Enabled = false;
                            txtTBPDanhGia1.Enabled = false;
                            txtNhanXet1.Enabled = false;

                            txtPTDanhGia2.Enabled = false;
                            txtTBPDanhGia2.Enabled = false;
                            txtNhanXet2.Enabled = false;

                            txtPTDanhGia3.Enabled = false;
                            txtTBPDanhGia3.Enabled = false;
                            txtNhanXet3.Enabled = false;

                            txtPTDanhGia4.Enabled = false;
                            txtTBPDanhGia4.Enabled = false;
                            txtNhanXet4.Enabled = false;
                        }
                    }
                }
            }

            DGCBCNVDanhGiaTDvaKLInfo info1 = DGCBCNVDanhGiaTDvaKLController.GetInfo_DanhGiaThang(idDotDanhGia, idNhanVien, 1);

            if (info1 != null)
            {
                txtPTDanhGia1.Text = info1.DiemTBPDG.ToString();//.Replace(".", ",");
                txtTBPDanhGia1.Text = info1.DiemThongNhat.ToString();//.Replace(".", ",");
                txtNhanXet1.Text = info1.GhiChu;
            }

            DGCBCNVDanhGiaTDvaKLInfo info2 = DGCBCNVDanhGiaTDvaKLController.GetInfo_DanhGiaThang(idDotDanhGia, idNhanVien, 2);

            if (info2 != null)
            {
                txtPTDanhGia2.Text = info2.DiemTBPDG.ToString();//.Replace(".", ",");
                txtTBPDanhGia2.Text = info2.DiemThongNhat.ToString();//.Replace(".", ",");
                txtNhanXet2.Text = info2.GhiChu;
            }

            DGCBCNVDanhGiaTDvaKLInfo info3 = DGCBCNVDanhGiaTDvaKLController.GetInfo_DanhGiaThang(idDotDanhGia, idNhanVien, 3);

            if (info3 != null)
            {
                txtPTDanhGia3.Text = info3.DiemTBPDG.ToString();//.Replace(".", ",");
                txtTBPDanhGia3.Text = info3.DiemThongNhat.ToString();//.Replace(".", ",");
                txtNhanXet3.Text = info3.GhiChu;
            }
            else 
            {
                txtPTDanhGia3.Text = txtTBPDanhGia1.Text;
                txtTBPDanhGia3.Text = txtTBPDanhGia1.Text;
                txtNhanXet3.Text = "";
            }

            DGCBCNVDanhGiaTDvaKLInfo info4 = DGCBCNVDanhGiaTDvaKLController.GetInfo_DanhGiaThang(idDotDanhGia, idNhanVien, 4);

            if (info4 != null)
            {
                txtPTDanhGia4.Text = info4.DiemTBPDG.ToString();//.Replace(".", ",");
                txtTBPDanhGia4.Text = info4.DiemThongNhat.ToString();//.Replace(".", ",");
                txtNhanXet4.Text = info4.GhiChu;
            }
            else
            {
                txtPTDanhGia4.Text = txtTBPDanhGia1.Text;
                txtTBPDanhGia4.Text = txtTBPDanhGia1.Text;
                txtNhanXet4.Text = "";
            }
        }
        protected void btnUpdate1_Click(object sender, EventArgs e)
        {
            DGCBCNVDanhGiaTDvaKLInfo info = new DGCBCNVDanhGiaTDvaKLInfo();

            info.IDDotDanhGia = idDotDanhGia;
            info.IDNhanVien = idNhanVien;
            info.DiemTDG = ConvertUtility.ToDouble(txtPTDanhGia1.Text);
            info.DiemTBPDG = ConvertUtility.ToDouble(txtPTDanhGia1.Text);
            info.DiemThongNhat = ConvertUtility.ToDouble(txtTBPDanhGia1.Text);

            if (info.DiemTBPDG == 0)
            {
                info.DiemTBPDG = info.DiemTDG;
            }
            if (info.DiemThongNhat == 0)
            {
                info.DiemThongNhat = info.DiemTDG;
            }
            if (info.DiemTBPDG != info.DiemTDG)
            {
                info.DiemThongNhat = info.DiemTBPDG;
            }

            if (CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiHoTro || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiKinhDoanh)
            {
                if (ConvertUtility.ToDouble(txtPTDanhGia1.Text) != ConvertUtility.ToDouble(txtTBPDanhGia1.Text))
                {
                    info.DiemThongNhat = ConvertUtility.ToDouble(txtTBPDanhGia1.Text);
                }
            }
            else if (CurrentUser.RoleID == (int)Constants.Role.TruongPhong || CurrentUser.RoleID == (int)Constants.Role.PhoPhong || CurrentUser.RoleID == (int)Constants.Role.TruongNhom)
            {
                info.DiemThongNhat = info.DiemTBPDG;
            }
            info.Loai = 1;
            info.GhiChu = txtNhanXet1.Text;

            DGCBCNVDanhGiaTDvaKLController.DanhGiaThang_DGCBCNVDanhGiaTDvaKL_Update(info);
        }

        protected void btnUpdate2_Click(object sender, EventArgs e)
        {
            DGCBCNVDanhGiaTDvaKLInfo info = new DGCBCNVDanhGiaTDvaKLInfo();

            info.IDDotDanhGia = idDotDanhGia;
            info.IDNhanVien = idNhanVien;
            info.DiemTDG = ConvertUtility.ToDouble(txtPTDanhGia2.Text);
            info.DiemTBPDG = ConvertUtility.ToDouble(txtPTDanhGia2.Text);
            info.DiemThongNhat = ConvertUtility.ToDouble(txtTBPDanhGia2.Text);

            if (info.DiemTBPDG == 0)
            {
                info.DiemTBPDG = info.DiemTDG;
            }
            if (info.DiemThongNhat == 0)
            {
                info.DiemThongNhat = info.DiemTDG;
            }
            if (info.DiemTBPDG != info.DiemTDG)
            {
                info.DiemThongNhat = info.DiemTBPDG;
            }

            if (CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiHoTro || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiKinhDoanh)
            {
                if (ConvertUtility.ToDouble(txtPTDanhGia2.Text) != ConvertUtility.ToDouble(txtTBPDanhGia2.Text))
                {
                    info.DiemThongNhat = ConvertUtility.ToDouble(txtTBPDanhGia2.Text);
                }
            }
            else if (CurrentUser.RoleID == (int)Constants.Role.TruongPhong || CurrentUser.RoleID == (int)Constants.Role.PhoPhong || CurrentUser.RoleID == (int)Constants.Role.TruongNhom)
            {
                info.DiemThongNhat = info.DiemTBPDG;
            }
            info.Loai = 2;
            info.GhiChu = txtNhanXet2.Text;

            DGCBCNVDanhGiaTDvaKLController.DanhGiaThang_DGCBCNVDanhGiaTDvaKL_Update(info);
        }

        protected void btnUpdate3_Click(object sender, EventArgs e)
        {
            DGCBCNVDanhGiaTDvaKLInfo info = new DGCBCNVDanhGiaTDvaKLInfo();

            info.IDDotDanhGia = idDotDanhGia;
            info.IDNhanVien = idNhanVien;
            info.DiemTDG = ConvertUtility.ToDouble(txtPTDanhGia3.Text);
            info.DiemTBPDG = ConvertUtility.ToDouble(txtPTDanhGia3.Text);
            info.DiemThongNhat = ConvertUtility.ToDouble(txtTBPDanhGia3.Text);

            if (info.DiemTBPDG == 0)
            {
                info.DiemTBPDG = info.DiemTDG;
            }
            if (info.DiemThongNhat == 0)
            {
                info.DiemThongNhat = info.DiemTDG;
            }
            if (info.DiemTBPDG != info.DiemTDG)
            {
                info.DiemThongNhat = info.DiemTBPDG;
            }

            if (CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiHoTro || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiKinhDoanh)
            {
                if (ConvertUtility.ToDouble(txtPTDanhGia3.Text) != ConvertUtility.ToDouble(txtTBPDanhGia3.Text))
                {
                    info.DiemThongNhat = ConvertUtility.ToDouble(txtTBPDanhGia3.Text);
                }
            }
            else if (CurrentUser.RoleID == (int)Constants.Role.TruongPhong || CurrentUser.RoleID == (int)Constants.Role.PhoPhong || CurrentUser.RoleID == (int)Constants.Role.TruongNhom)
            {
                info.DiemThongNhat = info.DiemTBPDG;
            }
            info.Loai = 3;
            info.GhiChu = txtNhanXet3.Text;

            DGCBCNVDanhGiaTDvaKLController.DanhGiaThang_DGCBCNVDanhGiaTDvaKL_Update(info);
        }

        protected void btnUpdate4_Click(object sender, EventArgs e)
        {
            DGCBCNVDanhGiaTDvaKLInfo info = new DGCBCNVDanhGiaTDvaKLInfo();

            info.IDDotDanhGia = idDotDanhGia;
            info.IDNhanVien = idNhanVien;
            info.DiemTDG = ConvertUtility.ToDouble(txtPTDanhGia4.Text);
            info.DiemTBPDG = ConvertUtility.ToDouble(txtPTDanhGia4.Text);
            info.DiemThongNhat = ConvertUtility.ToDouble(txtTBPDanhGia4.Text);

            if (info.DiemTBPDG == 0)
            {
                info.DiemTBPDG = info.DiemTDG;
            }
            if (info.DiemThongNhat == 0)
            {
                info.DiemThongNhat = info.DiemTDG;
            }
            if (info.DiemTBPDG != info.DiemTDG)
            {
                info.DiemThongNhat = info.DiemTBPDG;
            }

            if (CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiHoTro || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiKinhDoanh)
            {
                if (ConvertUtility.ToDouble(txtPTDanhGia4.Text) != ConvertUtility.ToDouble(txtTBPDanhGia4.Text))
                {
                    info.DiemThongNhat = ConvertUtility.ToDouble(txtTBPDanhGia4.Text);
                }
            }
            else if (CurrentUser.RoleID == (int)Constants.Role.TruongPhong || CurrentUser.RoleID == (int)Constants.Role.PhoPhong || CurrentUser.RoleID == (int)Constants.Role.TruongNhom)
            {
                info.DiemThongNhat = info.DiemTBPDG;
            }
            info.Loai = 4;
            info.GhiChu = txtNhanXet4.Text;

            DGCBCNVDanhGiaTDvaKLController.DanhGiaThang_DGCBCNVDanhGiaTDvaKL_Update(info);
        }

        protected void btnUpdateAll_Click(object sender, EventArgs e)
        {

            Session["Nav"] = "4";
            btnUpdate1_Click(null, null);
            btnUpdate2_Click(null, null);
            btnUpdate3_Click(null, null);
            btnUpdate4_Click(null, null);

            if (CurrentUser.RoleID != (int)Constants.Role.NhanVien && CurrentUser.RoleID != (int)Constants.Role.NhanVienKD)
            {
                DataTable dt = DotDanhGiaController.checkDanhGiaThang(idDotDanhGia, idNhanVien);

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) == (int)Constants.TrangThaiDanhGiaNhanVien.ThongNhat)
                    {
                        UserInfo userInfo = UserController.GetUser(idNhanVien);

                        EmailUtility.DoSendMail(userInfo.EmailVNG, "", "Trưởng bộ phận/Trưởng Phòng đã thống nhất bảng đánh giá tháng", "TBP/TP (" + CurrentUser.EmailVNG + ") đã cập nhật điểm thái độ và kỷ luật của bạn. Đề nghị bạn đăng nhập phần mềm để xem kết quả đánh giá.");
                    }
                }
            }
        }
    }
}