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

namespace VmgPortal.Modules.KPIData.Admin.DotDanhGia.CeoDanhGia.LanhDao_HT
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

            //DataTable dt = DotDanhGiaController.checkDanhGiaThang(idDotDanhGia, idNhanVien);

            //if (dt != null && dt.Rows.Count > 0)
            //{
                //if (idNhanVien == CurrentUser.UserID)
                //{
                //    if (CurrentUser.IsAdmin || CurrentUser.IsSuperAdmin)
                //    {
                //        //td5.Visible = true;
                //        //td51.Visible = true;
                //        btnUpdateAll.Visible = true;

                //        td1.Attributes.Add("style", "width:20%");
                //        td2.Attributes.Add("style", "width:20%");
                //        //td3.Attributes.Add("style", "width:20%");
                //        //td4.Attributes.Add("style", "width:20%");
                //        //td5.Attributes.Add("style", "width:20%");
                //        td11.Attributes.Add("style", "width:20%");
                //        td21.Attributes.Add("style", "width:20%");
                //        //td31.Attributes.Add("style", "width:20%");
                //        //td41.Attributes.Add("style", "width:20%");
                //        //td51.Attributes.Add("style", "width:20%");
                //    }
                //    else
                //    {
                //        //td5.Visible = true;
                //        //td51.Visible = true;
                //        td1.Attributes.Add("style", "width:20%");
                //        td2.Attributes.Add("style", "width:20%");
                //        //td3.Attributes.Add("style", "width:20%");
                //        //td4.Attributes.Add("style", "width:20%");
                //        td11.Attributes.Add("style", "width:20%");
                //        td21.Attributes.Add("style", "width:20%");
                //        //td31.Attributes.Add("style", "width:20%");
                //        //td41.Attributes.Add("style", "width:20%");
                //        //dropDiemThongNhat5.Enabled = false;
                //        if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) <= (int)Constants.TrangThaiDanhGiaNhanVien.DangDanhGia)
                //        {
                //            btnUpdateAll.Visible = true;
                //        }
                //        else
                //        {
                //            btnUpdateAll.Visible = false;
                //        }
                //    }
                //}
                //else
                //{
                //    //td5.Visible = true;
                //    //td51.Visible = true;
                //    btnUpdateAll.Visible = true;
                //    td1.Attributes.Add("style", "width:20%");
                //    td2.Attributes.Add("style", "width:20%");
                //    //td3.Attributes.Add("style", "width:20%");
                //    //td4.Attributes.Add("style", "width:20%");
                //    //td5.Attributes.Add("style", "width:20%");
                //    td11.Attributes.Add("style", "width:20%");
                //    td21.Attributes.Add("style", "width:20%");
                //    //td31.Attributes.Add("style", "width:20%");
                //    //td41.Attributes.Add("style", "width:20%");
                //    //td51.Attributes.Add("style", "width:20%");
                //}
                if (CurrentUser.RoleID == (int)Constants.Role.CEO || CurrentUser.IsAdmin || CurrentUser.IsSuperAdmin)
                {
                    btnUpdateAll.Visible = true;
                }
                else
                {
                    btnUpdateAll.Visible = false;
                }
            //}

            DGCBCNVDanhGiaTDvaKLInfo info1 = DGCBCNVDanhGiaTDvaKLController.GetInfo_DanhGiaThang(idDotDanhGia, idNhanVien, 1);

            if (info1 != null)
            {
                txtPTDanhGia1.Text = info1.DiemTBPDG.ToString().Replace(".", ",");
                txtTBPDanhGia1.Text = info1.DiemThongNhat.ToString().Replace(".", ",");
                txtNhanXet1.Text = info1.GhiChu;
            }

            DGCBCNVDanhGiaTDvaKLInfo info2 = DGCBCNVDanhGiaTDvaKLController.GetInfo_DanhGiaThang(idDotDanhGia, idNhanVien, 2);

            if (info2 != null)
            {
                txtPTDanhGia2.Text = info2.DiemTBPDG.ToString().Replace(".", ",");
                txtTBPDanhGia2.Text = info2.DiemThongNhat.ToString().Replace(".", ",");
                txtNhanXet2.Text = info2.GhiChu;
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

            if (info.DiemTBPDG == -1)
            {
                info.DiemTBPDG = info.DiemTDG;
            }
            if (info.DiemThongNhat == -1)
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
            else if (CurrentUser.RoleID == (int)Constants.Role.TruongPhong)
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

            if (info.DiemTBPDG == -1)
            {
                info.DiemTBPDG = info.DiemTDG;
            }
            if (info.DiemThongNhat == -1)
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
            else if (CurrentUser.RoleID == (int)Constants.Role.TruongPhong)
            {
                info.DiemThongNhat = info.DiemTBPDG;
            }
            info.Loai = 2;
            info.GhiChu = txtNhanXet2.Text;

            DGCBCNVDanhGiaTDvaKLController.DanhGiaThang_DGCBCNVDanhGiaTDvaKL_Update(info);
        }

        protected void btnUpdateAll_Click(object sender, EventArgs e)
        {
            btnUpdate1_Click(null, null);
            btnUpdate2_Click(null, null);          

            if (CurrentUser.RoleID != (int)Constants.Role.NhanVien)
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