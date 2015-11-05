using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using VmgPortal.Library.Utilities;
using VmgPortal.Modules.KPIData.Library.DanhGia;
using VmgPortal.Library;
using VmgPortal.Library.Components.Security;
using VmgPortal.Modules.KPIData.Library;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using VmgPortal.Library.Components.Users;

namespace VmgPortal.Modules.KPIData.Admin.DotDanhGia.CeoDanhGia.TPVaPP_KD
{
    public partial class DanhGiaCBCNV_KhoiLuongCVPhatSinh : AuthenticatedControl
    {
        DataTable dt;
        int idDotDanhGia = 0;
        int idNhanVien = 0;
        static DataTable dtBoPhanHoTro;
        protected void Page_Load(object sender, EventArgs e)
        {
            idDotDanhGia = ConvertUtility.ToInt32(Request.QueryString["idDotDanhGia"]);
            idNhanVien = ConvertUtility.ToInt32(Request.QueryString["idNhanVien"]);

            if (idDotDanhGia == 0)
            {
                idDotDanhGia = CurrentUser.IDDotDanhGiaVaNhanVien;
                idNhanVien = CurrentUser.UserID;

            }


            dtBoPhanHoTro = BoPhanController.BoPhan_GetAllActive();
            dropBoPhanHoTro.Items.Clear();
            dropBoPhanHoTro.DataSource = dtBoPhanHoTro;
            dropBoPhanHoTro.DataBind();

            if (CurrentUser.RoleID == (int)Constants.Role.CEO)
            {
                btnThemMoi3.Visible = false;
                btnUpdateDiem3.Visible = false;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            #region Cong viec phat sinh

            DataTable dtCongViec3 = DanhGiaThang_DGCBCNVDanhGiaTTCVController.GetAll(3, idDotDanhGia, idNhanVien);
            dgrKhoiLuongCV3.DataSource = dtCongViec3;
            dgrKhoiLuongCV3.DataBind();

            #endregion

            if (dgrKhoiLuongCV3.Rows.Count > 0)
            {
                btnUpdateDiem3.Visible = true;
            }
            else
            {
                btnUpdateDiem3.Visible = false;
            }

            dt = DotDanhGiaController.checkDanhGiaThang(idDotDanhGia, idNhanVien);

            if (dt != null && dt.Rows.Count > 0)
            {
                if (idNhanVien == CurrentUser.UserID)
                {
                    if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) <= (int)Constants.TrangThaiDanhGiaNhanVien.DangDanhGia)
                    {
                        btnThemMoi3.Visible = true;
                        btnUpdateDiem3.Visible = true;
                    }
                    else
                    {
                        btnThemMoi3.Visible = false;
                        btnUpdateDiem3.Visible = false;
                    }
                }
                else
                {
                    btnThemMoi3.Visible = true;
                    btnUpdateDiem3.Visible = true;
                }
            }


        }

        #region Những công việc phát sinh

        protected void dgrKhoiLuongCV3_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void dgrKhoiLuongCV3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex < 0) return;

            TextBox txtTyTrongCV = (TextBox)e.Row.FindControl("txtTyTrongCV");
            TextBox txtThoiGian = (TextBox)e.Row.FindControl("txtThoiGian");
            Label txtTenCongViec = (Label)e.Row.FindControl("txtTenCongViec");
            Label txtSoLieuCamKet = (Label)e.Row.FindControl("txtSoLieuCamKet");
            Label txtYeuCauHoTro = (Label)e.Row.FindControl("txtYeuCauHoTro");
            Button btnDelete = (Button)e.Row.FindControl("btnDelete");
            TextBox txtTBPDanhGia = (TextBox)e.Row.FindControl("txtTBPDanhGia");

            if (CurrentUser.RoleID == (int)Constants.Role.NhanVien || CurrentUser.RoleID == (int)Constants.Role.NhanVienKD)
            {
                txtTBPDanhGia.ReadOnly = true;
            }
            else
            {
                txtTBPDanhGia.ReadOnly = false;
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                if (idNhanVien == CurrentUser.UserID)
                {
                    //if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) < (int)Constants.TrangThaiDanhGiaNhanVien.DangDanhGia)
                    //{
                        btnDelete.Visible = true;
                    //}
                    //else
                    //{
                    //    btnDelete.Visible = false;
                    //}
                }
                else
                {
                    btnDelete.Visible = true;
                }
            }

            DataRowView crrData = (DataRowView)e.Row.DataItem;

            int idDotDanhGia = ConvertUtility.ToInt32(crrData["IDDotDanhGia"]);
            int idCongViec = ConvertUtility.ToInt32(crrData["IDCongViec"]);

            dropBoPhanHoTro.Items.Clear();
            dropBoPhanHoTro.DataSource = dtBoPhanHoTro;
            dropBoPhanHoTro.DataBind();

            DataTable dtBoPhanHoTroSelected = DanhGiaThang_DGCBCNVDanhGiaTTCVController.GetKeHoachThangBoPhanHoTro(idDotDanhGia, idCongViec);
            if (dtBoPhanHoTroSelected != null && dtBoPhanHoTroSelected.Rows.Count > 0)
            {
                foreach (ListItem item in dropBoPhanHoTro.Items)
                {
                    DataRow[] row = dtBoPhanHoTroSelected.Select("IDBoPhanHoTro = " + item.Value);
                    if (row.Length > 0)
                    {
                        item.Selected = true;
                    }
                }
            }
        }
        protected void dgrKhoiLuongCV3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                try
                {
                    int id = ConvertUtility.ToInt32(e.CommandArgument);

                    DanhGiaThang_DGCBCNVDanhGiaTTCVController.Delete(id);

                    lblStatusUpdate.Text = MiscUtility.MSG_UPDATE_SUCCESS;
                }
                catch (Exception ex)
                {
                    lblStatusUpdate.Text = ex.Message;
                }
            }
        }

        protected void dgrKhoiLuongCV3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }


        protected void btnUpdateDiem3_Click(object sender, EventArgs e)
        {
            Session["Nav"] = "3";
            foreach (GridViewRow row in dgrKhoiLuongCV3.Rows)
            {
                Label txtTenCongViec = (Label)row.FindControl("txtTenCongViec");
                TextBox txtTyTrongCV = (TextBox)row.FindControl("txtTyTrongCV");
                TextBox txtThoiGian = (TextBox)row.FindControl("txtThoiGian");
                Label txtSoLieuCamKet = (Label)row.FindControl("txtSoLieuCamKet");
                TextBox txtSoLieuThucHienThucTeTrongThang = (TextBox)row.FindControl("txtSoLieuThucHienThucTeTrongThang");
                TextBox txtNhanVienDanhGiaTyLeHoanThanh = (TextBox)row.FindControl("txtNhanVienDanhGiaTyLeHoanThanh");
                TextBox txtTBPDanhGia = (TextBox)row.FindControl("txtTBPDanhGia");
                Label txtYeuCauHoTro = (Label)row.FindControl("txtYeuCauHoTro");
                TextBox txtYKienCuaNhanVien = (TextBox)row.FindControl("txtYKienCuaNhanVien");
                TextBox txtYKienCuaTBP = (TextBox)row.FindControl("txtYKienCuaTBP");
                ListBox dropBoPhanHoTro = (ListBox)row.FindControl("dropBoPhanHoTro");

                Label txtID = (Label)row.FindControl("txtID");
                Label lblIDBoPhan = (Label)row.FindControl("lblIDBoPhan");
                Label lblIDBoPhanHoTro = (Label)row.FindControl("lblIDBoPhanHoTro");
                Label lblIDPhongBan = (Label)row.FindControl("lblIDPhongBan");
                Label txtIdCongViec = (Label)row.FindControl("txtIdCongViec");

                DanhGiaThang_DGCBCNVDanhGiaTTCVInfo info = new DanhGiaThang_DGCBCNVDanhGiaTTCVInfo();

                info.ID = ConvertUtility.ToInt32(txtID.Text);
                info.IDDotDanhGia = idDotDanhGia;
                info.IDNhanVien = idNhanVien;
                info.TenCongViec = txtTenCongViec.Text.Trim();
                info.SoGio = ConvertUtility.ToDouble(txtThoiGian.Text);
                info.TyTrongCV = ConvertUtility.ToDouble(txtTyTrongCV.Text);
                info.SoLieuCamKet = ConvertUtility.ToString(txtSoLieuCamKet.Text);
                info.SoLieuThucHienThucTeTrongThang = txtSoLieuThucHienThucTeTrongThang.Text;
                info.NhanVienDanhGiaTyLeHoanThanh = ConvertUtility.ToDouble(txtNhanVienDanhGiaTyLeHoanThanh.Text);

                if (info.NhanVienDanhGiaTyLeHoanThanh < 0)
                {
                    info.NhanVienDanhGiaTyLeHoanThanh = 0;
                }

                if (CurrentUser.RoleID != (int)Constants.Role.TruongBoPhanKhoiHoTro && CurrentUser.RoleID != (int)Constants.Role.TruongBoPhanKhoiKinhDoanh)
                {
                    if (CurrentUser.UserID == idNhanVien)
                    {
                        info.TBPDanhGia = info.NhanVienDanhGiaTyLeHoanThanh;
                    }
                    else
                    {
                        info.TBPDanhGia = ConvertUtility.ToDouble(txtTBPDanhGia.Text);
                    }
                }
                else
                {
                    info.TBPDanhGia = ConvertUtility.ToDouble(txtTBPDanhGia.Text);
                }

                if (info.TBPDanhGia < 0)
                {
                    info.TBPDanhGia = 0;
                }

                info.YKienCuaNhanVien = ConvertUtility.ToString(txtYKienCuaNhanVien.Text);
                info.YKienCuaTBP = ConvertUtility.ToString(txtYKienCuaTBP.Text);
                info.Loai = 3;

                info.IDCongViec = ConvertUtility.ToInt32(txtIdCongViec.Text);
                info.IDBoPhan = ConvertUtility.ToInt32(lblIDBoPhan.Text);
                info.IDBoPhanHoTro = ConvertUtility.ToInt32(dropBoPhanHoTro.SelectedValue);
                info.IDPhongBan = ConvertUtility.ToInt32(lblIDPhongBan.Text);

                DanhGiaThang_DGCBCNVDanhGiaTTCVController.Update(info);

                foreach (ListItem item in dropBoPhanHoTro.Items)
                {
                    if (item.Selected)
                    {
                        DanhGiaThang_DGCBCNVDanhGiaTTCVController.UpdateKeHoachThangBoPhanHoTro(idDotDanhGia, ConvertUtility.ToInt32(txtIdCongViec.Text), ConvertUtility.ToInt32(item.Value));
                    }
                    else
                    {
                        DanhGiaThang_DGCBCNVDanhGiaTTCVController.DeleteKeHoachThangBoPhanHoTro(idDotDanhGia, ConvertUtility.ToInt32(txtIdCongViec.Text), ConvertUtility.ToInt32(item.Value));
                    }
                }
            }

            if (CurrentUser.RoleID != (int)Constants.Role.NhanVien && CurrentUser.RoleID != (int)Constants.Role.NhanVienKD)
            {
                DataTable dt = DotDanhGiaController.checkDanhGiaThang(idDotDanhGia, idNhanVien);

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) == (int)Constants.TrangThaiDanhGiaNhanVien.ThongNhat)
                    {
                        UserInfo userInfo = UserController.GetUser(idNhanVien);

                        EmailUtility.DoSendMail(userInfo.EmailVNG, "", "Trưởng bộ phận/Trưởng Phòng đã thống nhất bảng đánh giá tháng", "TBP/TP (" + CurrentUser.EmailVNG + ") đã cập nhật điểm công việc phát sinh của bạn. Đề nghị bạn đăng nhập phần mềm để xem kết quả đánh giá.");
                    }
                    //else
                    //{
                    //    UserInfo infoUser = UserController.GetUser(idNhanVien);
                    //    if (infoUser != null)
                    //    {
                    //        bool value = EmailUtility.DoSendMail(infoUser.EmailVNG, "", "Mail nhắc nhở nhân viên hoàn thành công việc phát sinh", "Yêu cầu bạn hoàn thành công việc phát sinh theo deadline.");
                    //    }
                    //}
                }
            }


            //if (dgrKhoiLuongCV3.Rows.Count > 0)
            //{
            //    Response.Write("<script>javascript:alert('Bạn đã cập nhật thông tin thành công')</script>");
            //}
        }


        protected void btnThemMoi3_Click(object sender, EventArgs e)
        {
            Session["Nav"] = "3";
            DanhGiaThang_DGCBCNVDanhGiaTTCVInfo info = new DanhGiaThang_DGCBCNVDanhGiaTTCVInfo();

            info.IDDotDanhGia = idDotDanhGia;
            info.IDNhanVien = idNhanVien;
            info.TenCongViec = txtTenCongViec3.Text.Trim();
            info.TyTrongCV = ConvertUtility.ToDouble(txtTyTrongCongViec3.Text);        
            info.SoLieuCamKet = ConvertUtility.ToString(txtSoLieuCamKet3.Text);
            info.SoLieuThucHienThucTeTrongThang = txtSoLieuThucHienThucTeTrongThang3.Text;
            info.NhanVienDanhGiaTyLeHoanThanh = ConvertUtility.ToDouble(dropTyLeHoanThanh.SelectedValue);
            if (info.NhanVienDanhGiaTyLeHoanThanh > 100)
            {
                info.NhanVienDanhGiaTyLeHoanThanh = 100;
            }

            if (info.NhanVienDanhGiaTyLeHoanThanh < 0)
            {
                info.NhanVienDanhGiaTyLeHoanThanh = 0;
            }

            info.TBPDanhGia = info.NhanVienDanhGiaTyLeHoanThanh;           

            if (info.TBPDanhGia > 100)
            {
                info.TBPDanhGia = 100;
            }

            if (info.TBPDanhGia < 0)
            {
                info.TBPDanhGia = 0;
            }

            info.YeuCauHoTro = ConvertUtility.ToString(txtYeuCauCanHoTro3.Text);
            info.YKienCuaNhanVien = ConvertUtility.ToString(txtYKienCuaNhanVien3.Text);
            info.YKienCuaTBP = "";
            info.Loai = 3;
            info.SoGio = ConvertUtility.ToDouble(txtSoGio.Text);
            info.TyTrongCV = ConvertUtility.ToDouble(info.SoGio * 100 / 176);

            int idCongViec = DanhGiaThang_DGCBCNVDanhGiaTTCVController.Insert(info);

            foreach (ListItem item in dropBoPhanHoTro.Items)
            {
                if (item.Selected)
                {
                    DanhGiaThang_DGCBCNVDanhGiaTTCVController.UpdateKeHoachThangBoPhanHoTro(idDotDanhGia, idCongViec, ConvertUtility.ToInt32(item.Value));
                }
                else
                {
                    DanhGiaThang_DGCBCNVDanhGiaTTCVController.DeleteKeHoachThangBoPhanHoTro(idDotDanhGia, idCongViec, ConvertUtility.ToInt32(item.Value));
                }
            }

            if (dt == null)
            {
                dt = DotDanhGiaController.checkDanhGiaThang(idDotDanhGia, idNhanVien);
            }
            if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) < (int)Constants.TrangThaiDanhGiaNhanVien.DangDanhGia)
            {
                if (CurrentUser.RoleID != (int)Constants.Role.NhanVien && CurrentUser.RoleID != (int)Constants.Role.NhanVienKD)
                {
                    UserInfo infoUser = UserController.GetUser(idNhanVien);
                    if (infoUser != null)
                    {
                        bool value = EmailUtility.DoSendMail(infoUser.EmailVNG, "", "Mail nhắc nhở nhân viên hoàn thành công việc phát sinh", "Yêu cầu bạn hoàn thành công việc phát sinh theo deadline. Mọi người vào phần đánh giá -  Công việc phát sinh để xem công việc phải làm");
                    }
                }
            }
        }

        #endregion

    }
}