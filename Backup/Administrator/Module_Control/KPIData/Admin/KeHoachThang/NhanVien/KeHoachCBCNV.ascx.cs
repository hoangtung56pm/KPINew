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
using VmgPortal.Library.Components.Users;
using System.Drawing;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using System.Text.RegularExpressions;

namespace VmgPortal.Modules.KPIData.Admin.KeHoachThang.NhanVien
{
    public partial class KeHoachCBCNV : AuthenticatedControl
    {
        int idDotDanhGia = 0;
        int idNhanVien = 0;
        DataTable dt;
        static DataTable dtBoPhanHoTro;
        static UserInfo userInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            idDotDanhGia = ConvertUtility.ToInt32(Request.QueryString["idDotDanhGia"]);
            idNhanVien = ConvertUtility.ToInt32(Request.QueryString["idNhanVien"]);

            if (!IsPostBack)
            {
                dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
                dropDotDanhGia.DataBind();

                if (idDotDanhGia > 0)
                {
                    dropDotDanhGia.SelectedValue = idDotDanhGia.ToString();
                }
                dtBoPhanHoTro = BoPhanController.BoPhan_GetAllActive();
                dropBoPhanHoTro.Items.Clear();
                dropBoPhanHoTro.DataSource = dtBoPhanHoTro;
                dropBoPhanHoTro.DataBind();
            }

            if (idDotDanhGia == 0)
            {
                Response.Redirect(AppEnv.AdminUrlParams("kehoachnhanvien") + "&idDotDanhGia=" + dropDotDanhGia.SelectedValue + "&idNhanVien=" + CurrentUser.UserID);
            }

            if (CurrentUser.RoleID == (int)Constants.Role.NhanVien || CurrentUser.RoleID == (int)Constants.Role.NhanVienKD)
            {
                btnYeuCauLamLaiKeHoach.Visible = false;
            }
            else
            {
                btnYeuCauLamLaiKeHoach.Visible = true;
            }

            #region Check authenticate

            userInfo = UserController.GetUser(idNhanVien);
            if (userInfo == null)
            {
                Response.Redirect(AppEnv.AdminUrlParams("accessdeny"));
            }

            if (CurrentUser.RoleID == (int)Constants.Role.NhanVien || CurrentUser.RoleID == (int)Constants.Role.NhanVienKD)
            {
                if (CurrentUser.UserID != idNhanVien)
                {
                    Response.Redirect(AppEnv.AdminUrlParams("accessdeny"));
                }
            }

            #endregion

            btnSumit.OnClientClick = "return confirm('Bạn có chắc chắn gửi kế hoạch hay không ?')";
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            lblName.Text = userInfo.HoTen;

            dt = DotDanhGiaController.checkDanhGiaThang(idDotDanhGia, idNhanVien);

            if (dt != null && dt.Rows.Count > 0)
            {
                if (CurrentUser.UserID == idNhanVien)
                {
                    if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) == (int)Constants.TrangThaiDanhGiaNhanVien.LapKeHoach)
                    {
                        btnSumit.Enabled = true;
                        btnSumit.Text = "Gửi kế hoạch";
                        btnThemMoi2.Visible = true;
                        btnUpdateDiem1.Visible = true;
                        btnUpdateDiem2.Visible = true;
                    }
                    else
                    {
                        btnSumit.Enabled = false;
                        if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) == (int)Constants.TrangThaiDanhGiaNhanVien.DaGuiKeHoachChoTruongPhong)
                        {
                            btnSumit.Text = "Kế hoạch đã gửi đến trưởng phòng";
                        }
                        else if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) == (int)Constants.TrangThaiDanhGiaNhanVien.DaGuiKeHoachChoTBP)
                        {
                            btnSumit.Text = "Kế hoạch đã gửi đến trưởng bộ phận";
                        }
                        else
                        {
                            btnSumit.Text = "Đã hoàn thành kế hoạch tháng";
                        }
                        btnThemMoi2.Visible = false;
                        btnUpdateDiem1.Visible = false;
                        btnUpdateDiem2.Visible = false;
                    }
                }
                else
                {
                    if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) == (int)Constants.TrangThaiDanhGiaNhanVien.DaGuiKeHoachChoTruongPhong)
                    {
                        btnSumit.Text = "Gửi kế hoạch đến trưởng bộ phận";
                        btnSumit.Enabled = true;
                        btnThemMoi2.Visible = true;
                        btnUpdateDiem1.Visible = true;
                        btnUpdateDiem2.Visible = true;
                    }
                    else if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) == (int)Constants.TrangThaiDanhGiaNhanVien.LapKeHoach)
                    {
                        btnSumit.Enabled = true;
                        btnSumit.Text = "Gửi kế hoạch";
                        btnThemMoi2.Visible = true;
                        btnUpdateDiem1.Visible = true;
                        btnUpdateDiem2.Visible = true;
                    }
                    else
                    {
                        btnSumit.Enabled = true;
                        if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) == (int)Constants.TrangThaiDanhGiaNhanVien.DaGuiKeHoachChoTruongPhong)
                        {
                            btnSumit.Text = "Kế hoạch đã gửi đến trưởng phòng";
                        }
                        else if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) == (int)Constants.TrangThaiDanhGiaNhanVien.DaGuiKeHoachChoTBP)
                        {
                            btnSumit.Text = "Kế hoạch đã gửi đến trưởng bộ phận";
                        }
                        btnThemMoi2.Visible = true;
                        btnUpdateDiem1.Visible = true;
                        btnUpdateDiem2.Visible = true;
                    }
                }
            }

            #region Cong viec thuong xuyen

            DataTable dtKhoiLuong = DanhGiaThang_DGCBCNVDanhGiaTTCVController.GetAll(1, idDotDanhGia, idNhanVien);
            dgrKhoiLuongCV1.DataSource = dtKhoiLuong;
            dgrKhoiLuongCV1.RowDataBound += new GridViewRowEventHandler(dgrKhoiLuongCV1_RowDataBound);
            dgrKhoiLuongCV1.DataBind();

            #endregion

            #region Cong viec khong thuong xuyen

            DataTable dtCongViec2 = DanhGiaThang_DGCBCNVDanhGiaTTCVController.GetAll(2, idDotDanhGia, idNhanVien);
            dgrKhoiLuongCV2.DataSource = dtCongViec2;
            dgrKhoiLuongCV2.DataBind();

            #endregion

            #region Ty Trong Cong Viec

            double totalCVTX = 0;
            double totalCVKTX = 0;
            double total = 0;
            foreach (DataRow item in dtKhoiLuong.Rows)
            {
                totalCVTX += ConvertUtility.ToDouble(item["TyTrongCV"]);
            }

            foreach (DataRow item in dtCongViec2.Rows)
            {
                totalCVKTX += ConvertUtility.ToDouble(item["TyTrongCV"]);
            }

            lblCVTX.Text = Math.Round(totalCVTX, 2, MidpointRounding.AwayFromZero) + "%";
            lblCVKTX.Text = Math.Round(totalCVKTX,2, MidpointRounding.AwayFromZero) + "%";

            total = totalCVTX + totalCVKTX;

            lblTotal.Text = total.ToString() + "%";

            if (total > 100)
            {
                lblTotal.ForeColor = Color.Red;
                btnSumit.Enabled = true;
                //btnSumit.Text = "Tỷ trọng % công việc vượt quá mức 100%";

                tdCVPS.Visible = false;
                tdCVPSValue.Visible = false;
            }
            else
            {
                lblTotal.Text = "100%";
                lblCVPhatSinh.Text = Math.Round((100 - total), 2) + "%";
                if (total < 100)
                {
                    tdCVPS.Visible = true;
                    tdCVPSValue.Visible = true;
                }
                else
                {
                    tdCVPS.Visible = false;
                    tdCVPSValue.Visible = false;
                }
            }

            #endregion
        }

        void dgrKhoiLuongCV1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex < 0) return;

            ListBox dropBoPhanHoTro = (ListBox)e.Row.FindControl("dropBoPhanHoTro");

            dropBoPhanHoTro.Items.Clear();
            dropBoPhanHoTro.DataSource = dtBoPhanHoTro;
            dropBoPhanHoTro.DataBind();

            DataRowView crrData = (DataRowView)e.Row.DataItem;

            int idDotDanhGia = ConvertUtility.ToInt32(crrData["IDDotDanhGia"]);
            int idCongViec = ConvertUtility.ToInt32(crrData["IDCongViec"]);

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

            TextBox txtNguoiThamGia = (TextBox)e.Row.FindControl("txtNguoiThamGia");
            DataTable dtTen = DanhGiaThang_BoPhanTTCVController.GetNguoiThamGiaCongViecKTXVaPS(idDotDanhGia, idCongViec);

            if (dtTen != null && dtTen.Rows.Count > 0)
            {
                txtNguoiThamGia.Text = dtTen.Rows[0]["Ten"].ToString();
            }
            else
            {
                txtNguoiThamGia.Text = "";
            }

            Button btnDelete = (Button)e.Row.FindControl("btnDelete");
            btnDelete.OnClientClick = "return window.confirm('Bạn chắc chắn xóa công việc này không ?')";
            //TextBox txtSoLieuCamKet = (TextBox)e.Row.FindControl("txtSoLieuCamKet");
            //TextBox txtTenCongViec = (TextBox)e.Row.FindControl("txtTenCongViec");
            TextBox txtTyTrongCV = (TextBox)e.Row.FindControl("txtTyTrongCV");
            TextBox txtGLVCaNhan = (TextBox)e.Row.FindControl("txtGLVCaNhan");


            txtTyTrongCV.Text = Math.Round(ConvertUtility.ToDouble(crrData["TyTrongCV"]), 2, MidpointRounding.AwayFromZero).ToString();
            txtGLVCaNhan.Text = Math.Round(ConvertUtility.ToDouble(crrData["SoGio"]), 2, MidpointRounding.AwayFromZero).ToString();

            //if (CurrentUser.RoleID == (int)Constants.Role.NhanVien)
            //{
            //    QuanLyCongViecKTXVaPSInfo infoCongViec = QuanLyCongViecKTXVaPSController.GetInfo(ConvertUtility.ToInt32(crrData["IDCongViec"]));
            //    if (CurrentUser.UserID == infoCongViec.CreateBy)
            //    {
            //        btnDelete.Visible = true;
            //        txtSoLieuCamKet.ReadOnly = false;
            //        txtTenCongViec.ReadOnly = false;
            //        txtTyTrongCV.ReadOnly = false;
            //    }
            //    else
            //    {
            //        btnDelete.Visible = false;
            //        txtSoLieuCamKet.ReadOnly = true;
            //        txtTenCongViec.ReadOnly = true;
            //        txtTyTrongCV.ReadOnly = true;
            //    }
            //}
            //else
            //{
            //    btnDelete.Visible = true;
            //    txtSoLieuCamKet.ReadOnly = false;
            //    txtTenCongViec.ReadOnly = false;
            //    txtTyTrongCV.ReadOnly = false;
            //}
        }

        protected void dgrKhoiLuongCV1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgrKhoiLuongCV1_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void dgrKhoiLuongCV1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }


        protected void btnUpdateDiem1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in dgrKhoiLuongCV1.Rows)
            {
                TextBox txtTenCongViec = (TextBox)row.FindControl("txtTenCongViec");
                TextBox txtTyTrongCV = (TextBox)row.FindControl("txtTyTrongCV");
                TextBox txtSoLieuCamKet = (TextBox)row.FindControl("txtSoLieuCamKet");
                TextBox txtYeuCauHoTro = (TextBox)row.FindControl("txtYeuCauHoTro");
                ListBox dropBoPhanHoTro = (ListBox)row.FindControl("dropBoPhanHoTro");

                Label txtID = (Label)row.FindControl("txtID");
                Label txtIdCongViec = (Label)row.FindControl("txtIdCongViec");

                DanhGiaThang_DGCBCNVDanhGiaTTCVInfo info = new DanhGiaThang_DGCBCNVDanhGiaTTCVInfo();

                info.ID = ConvertUtility.ToInt32(txtID.Text);
                info.IDDotDanhGia = idDotDanhGia;
                info.IDNhanVien = idNhanVien;
                info.TenCongViec = txtTenCongViec.Text.Trim();
                info.TyTrongCV = ConvertUtility.ToDouble(txtTyTrongCV.Text);
                info.SoLieuCamKet = ConvertUtility.ToString(txtSoLieuCamKet.Text);
                info.YeuCauHoTro = ConvertUtility.ToString(txtYeuCauHoTro.Text);
                info.Loai = 1;
                info.IDBoPhan = userInfo.IDTrungTam;
                info.IDBoPhanHoTro = ConvertUtility.ToInt32(dropBoPhanHoTro.SelectedValue);
                info.IDPhongBan = userInfo.IDPhong;
                info.IDCongViec = ConvertUtility.ToInt32(txtIdCongViec.Text);

                if (info.TyTrongCV > 0 && info.SoGio == 0)
                {
                    info.SoGio = info.TyTrongCV * 176 / 100;
                }
                else
                {
                    info.TyTrongCV = info.SoGio * 100 / 176;
                }

                DanhGiaThang_DGCBCNVDanhGiaTTCVController.UpdateKeHoachThang(info);

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
        }

        #region Những công việc không thường xuyên

        protected void dgrKhoiLuongCV2_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgrKhoiLuongCV2_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void dgrKhoiLuongCV2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }


        protected void btnUpdateDiem2_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in dgrKhoiLuongCV2.Rows)
            {
                TextBox txtTenCongViec = (TextBox)row.FindControl("txtTenCongViec");
                TextBox txtTyTrongCV = (TextBox)row.FindControl("txtTyTrongCV");
                TextBox txtGLVCaNhan = (TextBox)row.FindControl("txtGLVCaNhan");
                TextBox txtSoLieuCamKet = (TextBox)row.FindControl("txtSoLieuCamKet");
                TextBox txtYeuCauHoTro = (TextBox)row.FindControl("txtYeuCauHoTro");
                ListBox dropBoPhanHoTro = (ListBox)row.FindControl("dropBoPhanHoTro");

                Label txtID = (Label)row.FindControl("txtID");
                Label txtIdCongViec = (Label)row.FindControl("txtIdCongViec");

                DanhGiaThang_DGCBCNVDanhGiaTTCVInfo info = new DanhGiaThang_DGCBCNVDanhGiaTTCVInfo();

                info.ID = ConvertUtility.ToInt32(txtID.Text);
                info.IDDotDanhGia = idDotDanhGia;
                info.IDNhanVien = idNhanVien;
                info.TenCongViec = txtTenCongViec.Text.Trim();
                info.TyTrongCV = ConvertUtility.ToDouble(txtTyTrongCV.Text);
                info.SoLieuCamKet = ConvertUtility.ToString(txtSoLieuCamKet.Text);
                info.YeuCauHoTro = ConvertUtility.ToString(txtYeuCauHoTro.Text);
                info.Loai = 2;
                info.IDCongViec = ConvertUtility.ToInt32(txtIdCongViec.Text);
                info.IDBoPhan = userInfo.IDTrungTam;
                info.IDBoPhanHoTro = ConvertUtility.ToInt32(dropBoPhanHoTro.SelectedValue);
                info.IDPhongBan = userInfo.IDPhong;
                info.SoGio = ConvertUtility.ToDouble(txtGLVCaNhan.Text);

                if (info.TyTrongCV > 0 && info.SoGio == 0)
                {
                    info.SoGio = info.TyTrongCV * 176 / 100;
                }
                else
                {
                    info.TyTrongCV = info.SoGio * 100 / 176;
                }

                DanhGiaThang_DGCBCNVDanhGiaTTCVController.UpdateKeHoachThang(info);

                //foreach (ListItem item in dropBoPhanHoTro.Items)
                //{
                //    if (item.Selected)
                //    {
                //        DanhGiaThang_DGCBCNVDanhGiaTTCVController.UpdateKeHoachThangBoPhanHoTro(idDotDanhGia, ConvertUtility.ToInt32(txtIdCongViec.Text), ConvertUtility.ToInt32(item.Value));
                //    }
                //    else
                //    {
                //        DanhGiaThang_DGCBCNVDanhGiaTTCVController.DeleteKeHoachThangBoPhanHoTro(idDotDanhGia, ConvertUtility.ToInt32(txtIdCongViec.Text), ConvertUtility.ToInt32(item.Value));
                //    }
                //}
            }
        }


        protected void btnThemMoi2_Click(object sender, EventArgs e)
        {
            DanhGiaThang_DGCBCNVDanhGiaTTCVInfo info = new DanhGiaThang_DGCBCNVDanhGiaTTCVInfo();

            info.IDDotDanhGia = idDotDanhGia;
            info.IDNhanVien = idNhanVien;
            info.TenCongViec = txtTenCongViec2.Text.Trim();
            info.TyTrongCV = ConvertUtility.ToDouble(txtTyTrongCongViec2.Text);
            info.SoLieuCamKet = ConvertUtility.ToString(txtSoLieuCamKet2.Text);
            info.YeuCauHoTro = ConvertUtility.ToString(txtYeuCauCanHoTro2.Text);
            info.Loai = 2;
            info.IDBoPhan = userInfo.IDTrungTam;
            info.IDBoPhanHoTro = ConvertUtility.ToInt32(dropBoPhanHoTro.SelectedValue);
            info.IDPhongBan = userInfo.IDPhong;
            info.SoGio = ConvertUtility.ToDouble(txtSoGio.Text);

            info.TyTrongCV = info.SoGio * 100 / 176;
            info.NgayBatDau = ConvertUtility.ToDateTime(dtFrom.Text);
            info.NgayKetThuc = ConvertUtility.ToDateTime(dtTo.Text);

            int idCongViec = DanhGiaThang_DGCBCNVDanhGiaTTCVController.InsertKeHoachThang(info);

            //foreach (ListItem item in dropBoPhanHoTro.Items)
            //{
            //    if (item.Selected)
            //    {
            //        DanhGiaThang_DGCBCNVDanhGiaTTCVController.UpdateKeHoachThangBoPhanHoTro(idDotDanhGia, idCongViec, ConvertUtility.ToInt32(item.Value));
            //    }
            //    else
            //    {
            //        DanhGiaThang_DGCBCNVDanhGiaTTCVController.DeleteKeHoachThangBoPhanHoTro(idDotDanhGia, idCongViec, ConvertUtility.ToInt32(item.Value));
            //    }
            //}
        }

        #endregion

        protected void dropDotDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(AppEnv.AdminUrlParams("kehoachnhanvien") + "&idDotDanhGia=" + dropDotDanhGia.SelectedValue + "&idNhanVien=" + idNhanVien);
        }

        protected void btnSumit_Click(object sender, EventArgs e)
        {

            DataTable dt = DotDanhGiaController.checkDanhGiaThang(idDotDanhGia, idNhanVien);

            if (dt != null && dt.Rows.Count > 0)
            {
                if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) == (int)Constants.TrangThaiDanhGiaNhanVien.LapKeHoach)
                {
                    UserInfo userInfo = UserController.GetUser(idNhanVien);
                    if (userInfo == null)
                    {
                        Response.Redirect(AppEnv.AdminUrlParams("accessdeny"));
                    }

                    if (userInfo.IDPhong > 0)
                    {
                        DotDanhGiaController.GuiDanhGiaThang(idDotDanhGia, idNhanVien, (int)Constants.TrangThaiDanhGiaNhanVien.DaGuiKeHoachChoTruongPhong);
                    }
                    else
                    {
                        DotDanhGiaController.GuiDanhGiaThang(idDotDanhGia, idNhanVien, (int)Constants.TrangThaiDanhGiaNhanVien.DaGuiKeHoachChoTBP);
                    }
                }
                //else
                //{
                //    DotDanhGiaController.GuiDanhGiaThang(idDotDanhGia, idNhanVien, (int)Constants.TrangThaiDanhGiaNhanVien.DaGuiKeHoachChoTBP);
                //}
            }
        }

        protected void dgrKhoiLuongCV2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex < 0) return;

            DataRowView crrData = (DataRowView)e.Row.DataItem;
            Button btnDelete = (Button)e.Row.FindControl("btnDelete");
            TextBox txtSoLieuCamKet = (TextBox)e.Row.FindControl("txtSoLieuCamKet");
            TextBox txtTenCongViec = (TextBox)e.Row.FindControl("txtTenCongViec");
            TextBox txtTyTrongCV = (TextBox)e.Row.FindControl("txtTyTrongCV");

            if (CurrentUser.RoleID == (int)Constants.Role.NhanVien || CurrentUser.RoleID == (int)Constants.Role.NhanVienKD)
            {
                QuanLyCongViecKTXVaPSInfo infoCongViec = QuanLyCongViecKTXVaPSController.GetInfo(ConvertUtility.ToInt32(crrData["IDCongViec"]));

                if (infoCongViec != null)
                {
                    if (CurrentUser.UserID == infoCongViec.CreateBy)
                    {
                        if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) <= (int)Constants.TrangThaiDanhGiaNhanVien.DangDanhGia)
                        {
                            btnDelete.Visible = true;
                        }
                        else
                        {
                            btnDelete.Visible = false;
                        }
                        txtSoLieuCamKet.ReadOnly = false;
                        txtTenCongViec.ReadOnly = false;
                        txtTyTrongCV.ReadOnly = false;
                    }
                    else
                    {
                        btnDelete.Visible = false;
                        txtSoLieuCamKet.ReadOnly = true;
                        txtTenCongViec.ReadOnly = true;
                        txtTyTrongCV.ReadOnly = true;
                    }
                }
                else
                {
                    btnDelete.Visible = false;
                    txtSoLieuCamKet.ReadOnly = true;
                    txtTenCongViec.ReadOnly = true;
                    txtTyTrongCV.ReadOnly = true;
                }
            }
            else
            {
                btnDelete.Visible = true;
                txtSoLieuCamKet.ReadOnly = false;
                txtTenCongViec.ReadOnly = false;
                txtTyTrongCV.ReadOnly = false;
            }


            ListBox dropBoPhanHoTro = (ListBox)e.Row.FindControl("dropBoPhanHoTro");

            dropBoPhanHoTro.Items.Clear();
            dropBoPhanHoTro.DataSource = dtBoPhanHoTro;
            dropBoPhanHoTro.DataBind();


            int idDotDanhGia = ConvertUtility.ToInt32(crrData["IDDotDanhGia"]);
            int idCongViec = ConvertUtility.ToInt32(crrData["IDCongViec"]);

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

            TextBox txtNguoiThamGia = (TextBox)e.Row.FindControl("txtNguoiThamGia");
            DataTable dtTen = DanhGiaThang_BoPhanTTCVController.GetNguoiThamGiaCongViecKTXVaPS(idDotDanhGia, idCongViec);

            if (dtTen != null && dtTen.Rows.Count > 0)
            {
                txtNguoiThamGia.Text = dtTen.Rows[0]["Ten"].ToString();
            }
            else
            {
                txtNguoiThamGia.Text = "";
            }
                     
            btnDelete.OnClientClick = "return window.confirm('Bạn chắc chắn xóa công việc này không ?')";
        }

        protected void btnYeuCauLamLaiKeHoach_Click(object sender, EventArgs e)
        {
            UserInfo info = UserController.GetUser(idNhanVien);
            if (info != null)
            {
                DotDanhGiaController.GuiDanhGiaThang(idDotDanhGia, idNhanVien, (int)Constants.TrangThaiDanhGiaNhanVien.LapKeHoach);

                EmailUtility.DoSendMail(info.EmailVNG, "", "Yêu cầu lập lại kế hoạch tháng " + dropDotDanhGia.SelectedItem.Text, "TBP/TBP thấy bạn lập kế hoạch chưa hợp lý. Đề nghị bạn đăng nhập phần mềm để làm lại kế hoạch.");
            }
        }

        protected void btnLich_Click(object sender, EventArgs e)
        {
            string idDotDanhGia = Request.QueryString["idDotDanhGia"];

            Response.Redirect(AppEnv.AdminUrlParams("kehoachthang_nhanvien") + "&idDotDanhGia=" + idDotDanhGia + "&idNhanVien=" + CurrentUser.UserID);
 
        }
    }
}