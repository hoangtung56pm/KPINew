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

namespace VmgPortal.Modules.KPIData.Admin.DanhGiaThang.DanhGiaNhanVien
{
    public partial class DanhGiaCBCNV_KhoiLuong : AuthenticatedControl
    {
        int idDotDanhGia = 0;
        int idNhanVien = 0;
        static DataTable dtBoPhanHoTro;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdateDiem1.OnClientClick = MiscUtility.MSG_UPDATE_CONFIRM;
            idDotDanhGia = ConvertUtility.ToInt32(Request.QueryString["idDotDanhGia"]);
            idNhanVien = ConvertUtility.ToInt32(Request.QueryString["idNhanVien"]);

            if (idDotDanhGia == 0)
            {
                idDotDanhGia = CurrentUser.IDDotDanhGiaVaNhanVien;
                idNhanVien = CurrentUser.UserID;
            }

            if (!IsPostBack)
            {
                dtBoPhanHoTro = BoPhanController.BoPhan_GetAllActive();

                Session["Nav"] = "1";
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);


            #region Cong viec thuong xuyen

            DataTable dtKhoiLuong = DanhGiaThang_DGCBCNVDanhGiaTTCVController.GetAll(1, idDotDanhGia, idNhanVien);
            dgrKhoiLuongCV1.DataSource = dtKhoiLuong;
            dgrKhoiLuongCV1.DataBind();

            #endregion

            if (dgrKhoiLuongCV1.Rows.Count > 0)
            {
                btnUpdateDiem1.Visible = true;
            }
            else
            {
                btnUpdateDiem1.Visible = false;
            }

            DataTable dt = DotDanhGiaController.checkDanhGiaThang(idDotDanhGia, idNhanVien);

            if (dt != null && dt.Rows.Count > 0)
            {
                if (idNhanVien == CurrentUser.UserID)
                {
                    if (CurrentUser.IsAdmin || CurrentUser.IsSuperAdmin)
                    {
                        btnUpdateDiem1.Visible = true;
                    }
                    else
                    {
                        if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) <= (int)Constants.TrangThaiDanhGiaNhanVien.DangDanhGia)
                        {
                            btnUpdateDiem1.Visible = true;
                        }
                        else
                        {
                            btnUpdateDiem1.Visible = false;
                        }
                    }
                }
                else
                {
                    if (CurrentUser.IsAdmin || CurrentUser.IsSuperAdmin)
                    {
                        btnUpdateDiem1.Visible = true;
                    }
                    else
                    {
                        if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) == (int)Constants.TrangThaiDanhGiaNhanVien.ThongNhat)
                        {
                            btnUpdateDiem1.Visible = false;
                        }
                        else
                        {
                            btnUpdateDiem1.Visible = true;
                        }
                    }
                }
            }
            else
            {
                if (CurrentUser.IsAdmin || CurrentUser.IsSuperAdmin)
                {
                    btnUpdateDiem1.Visible = true;
                }
                else
                {
                    if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) == (int)Constants.TrangThaiDanhGiaNhanVien.ThongNhat)
                    {
                        btnUpdateDiem1.Visible = false;
                    }
                    else
                    {
                        btnUpdateDiem1.Visible = true;
                    }
                }
            }

        }

        protected void dgrKhoiLuongCV1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgrKhoiLuongCV1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "delete")
            //{
            //    try
            //    {
            //        int id = ConvertUtility.ToInt32(e.CommandArgument);

            //        DanhGiaThang_DGCBCNVDanhGiaTTCVController.Delete(id);

            //        lblStatusUpdate.Text = MiscUtility.MSG_UPDATE_SUCCESS;
            //    }
            //    catch (Exception ex)
            //    {
            //        lblStatusUpdate.Text = ex.Message;
            //    }
            //}
        }

        protected void dgrKhoiLuongCV1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }


        protected void btnUpdateDiem1_Click(object sender, EventArgs e)
        {
            Session["Nav"] = "1";
            foreach (GridViewRow row in dgrKhoiLuongCV1.Rows)
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
                Label lblIDCongViec = (Label)row.FindControl("lblIDCongViec");

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
                info.TyTrongCV = ConvertUtility.ToDouble(info.SoGio * 100/176);
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

                info.YeuCauHoTro = ConvertUtility.ToString(txtYeuCauHoTro.Text);
                info.YKienCuaNhanVien = ConvertUtility.ToString(txtYKienCuaNhanVien.Text);
                info.YKienCuaTBP = ConvertUtility.ToString(txtYKienCuaTBP.Text);
                info.Loai = 1;

                info.IDCongViec = ConvertUtility.ToInt32(lblIDCongViec.Text);
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

            if (CurrentUser.RoleID != (int)Constants.Role.NhanVien)
            {
                DataTable dt = DotDanhGiaController.checkDanhGiaThang(idDotDanhGia, idNhanVien);

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) == (int)Constants.TrangThaiDanhGiaNhanVien.ThongNhat)
                    {
                        UserInfo userInfo = UserController.GetUser(idNhanVien);

                        EmailUtility.DoSendMail(userInfo.EmailVNG, "", "Trưởng bộ phận/Trưởng Phòng đã thống nhất bảng đánh giá tháng", "TBP/TP (" + CurrentUser.EmailVNG + ")  đã cập nhật điểm công việc thường xuyên của bạn. Đề nghị bạn đăng nhập phần mềm để xem kết quả đánh giá.");
                    }
                }
            }

            //if (dgrKhoiLuongCV1.Rows.Count > 0)
            //{
            //    Response.Write("<script>javascript:alert('Bạn đã cập nhật thông tin thành công')</script>");
            //}
        }

        protected void dgrKhoiLuongCV1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex < 0) return;

            TextBox txtTyTrongCV = (TextBox)e.Row.FindControl("txtTyTrongCV");
            TextBox txtThoiGian = (TextBox)e.Row.FindControl("txtThoiGian");
            
            Label txtTenCongViec = (Label)e.Row.FindControl("txtTenCongViec");
            Label txtSoLieuCamKet = (Label)e.Row.FindControl("txtSoLieuCamKet");
            Label txtYeuCauHoTro = (Label)e.Row.FindControl("txtYeuCauHoTro");
            TextBox txtTBPDanhGia = (TextBox)e.Row.FindControl("txtTBPDanhGia");

            txtTyTrongCV.ReadOnly = true;
           
            if (CurrentUser.RoleID == (int)Constants.Role.NhanVien || CurrentUser.RoleID == (int)Constants.Role.NhanVienKD)
            {
                txtTBPDanhGia.ReadOnly = true;
                txtThoiGian.ReadOnly = true;
            }
            else
            {
                txtTBPDanhGia.ReadOnly = false;
                txtThoiGian.ReadOnly = false;
            }
            DataRowView crrData = (DataRowView)e.Row.DataItem;

            int idDotDanhGia = ConvertUtility.ToInt32(crrData["IDDotDanhGia"]);
            int idCongViec = ConvertUtility.ToInt32(crrData["IDCongViec"]);
            ListBox dropBoPhanHoTro = (ListBox)e.Row.FindControl("dropBoPhanHoTro");

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

        protected string GetThoiGian(object tytrong)
        {
            return Math.Round(ConvertUtility.ToDouble(tytrong) * 22 * 8 / 100, 3).ToString();
        }

        protected void dgrKhoiLuongCV1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Session["Nav"] = "1";
        }
    }
}