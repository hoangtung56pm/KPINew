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

namespace VmgPortal.Modules.KPIData.Admin.DotDanhGia.CeoDanhGia.TPVaPP_HT
{
    public partial class DanhGiaCBCNV_DichVuKhachHangDiemThuongPhat : AuthenticatedControl
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

            if (CurrentUser.RoleID == (int)Constants.Role.CEO || CurrentUser.IsAdmin || CurrentUser.IsSuperAdmin)
            {
                btnUpdateAll.Visible = true;
            }
            else
            {
                btnUpdateAll.Visible = false;
            }

            //DataTable dt = DotDanhGiaController.checkDanhGiaThang(idDotDanhGia, idNhanVien);

            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    if (idNhanVien == CurrentUser.UserID)
            //    {
            //        if (CurrentUser.IsAdmin || CurrentUser.IsSuperAdmin)
            //        {
            //            btnUpdateAll.Visible = true;
            //        }
            //        else
            //        {
            //            if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) <= (int)Constants.TrangThaiDanhGiaNhanVien.DangDanhGia)
            //            {
            //                btnUpdateAll.Visible = true;
            //            }
            //            else
            //            {
            //                btnUpdateAll.Visible = false;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        btnUpdateAll.Visible = true;
            //    }
            //}
            //else
            //{
            //    btnUpdateAll.Visible = false;
            //}

            //DGCBCNVDanhGiaTDvaKLInfo info1 = DGCBCNVDanhGiaTDvaKLController.GetInfo_DanhGiaThang(idDotDanhGia, idNhanVien, 6);

            //if (info1 != null)
            //{
            //    dropDiemDVKH.SelectedValue = info1.DiemThongNhat.ToString();
            //    txtLyDoDVKH.Text = info1.GhiChu;
            //}

            DGCBCNVDanhGiaTDvaKLInfo info2 = DGCBCNVDanhGiaTDvaKLController.GetInfo_DanhGiaThang(idDotDanhGia, idNhanVien, 7);

            if (info2 != null)
            {
                //dropDiemThuong.SelectedValue = info2.DiemThongNhat.ToString();
                txtDiemThuong.Text = info2.DiemThongNhat.ToString();
                txtLyDoThuong.Text = info2.GhiChu;
            }

            //DGCBCNVDanhGiaTDvaKLInfo info3 = DGCBCNVDanhGiaTDvaKLController.GetInfo_DanhGiaThang(idDotDanhGia, idNhanVien, 8);

            //if (info3 != null)
            //{
            //    dropDiemPhat.SelectedValue = info3.DiemThongNhat.ToString();
            //    txtLyDoPhat.Text = info3.GhiChu;
            //}
        }
        //protected void btnUpdate1_Click(object sender, EventArgs e)
        //{
        //    DGCBCNVDanhGiaTDvaKLInfo info = new DGCBCNVDanhGiaTDvaKLInfo();

        //    info.IDDotDanhGia = idDotDanhGia;
        //    info.IDNhanVien = idNhanVien;
        //    info.DiemTDG = ConvertUtility.ToInt32(dropDiemDVKH.Text);
        //    info.DiemTBPDG = ConvertUtility.ToInt32(dropDiemDVKH.Text);
        //    info.DiemThongNhat = ConvertUtility.ToInt32(dropDiemDVKH.Text);
        //    info.Loai = 6;
        //    info.GhiChu = txtLyDoDVKH.Text;
        //    DGCBCNVDanhGiaTDvaKLController.DanhGiaThang_DGCBCNVDanhGiaTDvaKL_Update(info);
        //}

        protected void btnUpdate2_Click(object sender, EventArgs e)
        {
            DGCBCNVDanhGiaTDvaKLInfo info = new DGCBCNVDanhGiaTDvaKLInfo();

            info.IDDotDanhGia = idDotDanhGia;
            info.IDNhanVien = idNhanVien;
            info.DiemTDG = ConvertUtility.ToInt32(txtDiemThuong.Text);
            info.DiemTBPDG = ConvertUtility.ToInt32(txtDiemThuong.Text);
            info.DiemThongNhat = ConvertUtility.ToInt32(txtDiemThuong.Text);
            info.Loai = 7;
            info.GhiChu = txtLyDoThuong.Text;

            DGCBCNVDanhGiaTDvaKLController.DanhGiaThang_DGCBCNVDanhGiaTDvaKL_Update(info);
        }

        //protected void btnUpdate3_Click(object sender, EventArgs e)
        //{
        //    DGCBCNVDanhGiaTDvaKLInfo info = new DGCBCNVDanhGiaTDvaKLInfo();

        //    info.IDDotDanhGia = idDotDanhGia;
        //    info.IDNhanVien = idNhanVien;
        //    info.DiemTDG = ConvertUtility.ToInt32(dropDiemPhat.Text);
        //    info.DiemTBPDG = ConvertUtility.ToInt32(dropDiemPhat.Text);
        //    info.DiemThongNhat = ConvertUtility.ToInt32(dropDiemPhat.Text);
        //    info.Loai = 8;
        //    info.GhiChu = txtLyDoPhat.Text;

        //    DGCBCNVDanhGiaTDvaKLController.DanhGiaThang_DGCBCNVDanhGiaTDvaKL_Update(info);
        //}

        protected void btnUpdateAll_Click(object sender, EventArgs e)
        {
            Session["Nav"] = "5";
            //btnUpdate1_Click(null,null);
            btnUpdate2_Click(null, null);
            //btnUpdate3_Click(null, null);
        }
    }
}