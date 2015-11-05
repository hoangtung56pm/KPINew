using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library.Utilities;
using VmgPortal.Library;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;
using VmgPortal.Library.Components.Security;
using System.Data;
using VmgPortal.Modules.KPIData.Library.DanhGia;
using VmgPortal.Modules.KPIData.Library.DanhGiaBoPhan;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using VmgPortal.Modules.LogFile.Lib;

namespace VmgPortal.Modules.KPIData.Admin.DotDanhGia
{
    public partial class DotDanhGia : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (id > 0)
            {
                DotDanhGiaInfo info = DotDanhGiaController.GetInfo(id);

                if (info != null)
                {
                    txtTen.Text = info.Ten.ToString();
                    txtThoiGianBatDau.Text = info.ThoiGianBatDau.ToShortDateString();
                    txtThoiGianKetThuc.Text = info.ThoiGianKetThuc.ToShortDateString();
                    dropStatus.SelectedValue = info.DangChay.ToString();
                    dropTypeOf.SelectedValue = info.TrangThai.ToString();
                    dropChuan.SelectedValue = ConvertUtility.ToInt32(info.IsDefault).ToString();
                }
            }
            else
            {
                btnUpdate.Visible = false;
            }

            dgrDotDanhGia.DataSource = DotDanhGiaController.GetAll();
            dgrDotDanhGia.DataBind();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            DotDanhGiaInfo info = new DotDanhGiaInfo();

            info.ID = id;
            info.Ten = txtTen.Text.Trim();
            info.ThoiGianBatDau = ConvertUtility.ToDateTime(txtThoiGianBatDau.Text);
            info.ThoiGianKetThuc = ConvertUtility.ToDateTime(txtThoiGianKetThuc.Text);
            info.TrangThai = ConvertUtility.ToInt32(dropTypeOf.SelectedValue);
            info.DangChay = ConvertUtility.ToInt32(dropStatus.SelectedValue);
            info.IsDefault = ConvertUtility.ToInt32(dropChuan.SelectedValue);

            info.Nam = info.ThoiGianKetThuc.Year;
            info.Thang = info.ThoiGianKetThuc.Month;

            DotDanhGiaController.Update(info);

        }

        protected void dgrDotDanhGia_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgrDotDanhGia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                int id = ConvertUtility.ToInt32(e.CommandArgument);

                Response.Redirect(AppEnv.AdminUrlParams("dotdanhgia") + "&id=" + id);
            }

            if (e.CommandName == "detail")
            {
                int id = ConvertUtility.ToInt32(e.CommandArgument);

                Response.Redirect(AppEnv.AdminUrlParams("dotdanhgiachitiet") + "&id=" + id);
            }
            if (e.CommandName == "tbp")
            {
                int id = ConvertUtility.ToInt32(e.CommandArgument);

                Response.Redirect(AppEnv.AdminUrlParams("dotdanhgiatruongbophan") + "&id=" + id);
            }

            if (e.CommandName == "ndgnhanvien")
            {
                int id = ConvertUtility.ToInt32(e.CommandArgument);

                Response.Redirect(AppEnv.AdminUrlParams("dotdanhgiachonNDG") + "&id=" + id);
            }

            if (e.CommandName == "ndgtruongphong")
            {
                int id = ConvertUtility.ToInt32(e.CommandArgument);

                Response.Redirect(AppEnv.AdminUrlParams("dotdanhgiachonNDGTruongPhong") + "&id=" + id);
            }

            if (e.CommandName == "bophan")
            {
                int id = ConvertUtility.ToInt32(e.CommandArgument);

                Response.Redirect(AppEnv.AdminUrlParams("chonbophanvaodotdanhgia") + "&id=" + id);

            }

            if (e.CommandName == "delete")
            {
                try
                {
                    int id = ConvertUtility.ToInt32(e.CommandArgument);

                    DotDanhGiaController.Delete(id);

                    lblStatusUpdate.Text = MiscUtility.MSG_UPDATE_SUCCESS;
                }
                catch (Exception ex)
                {
                    lblStatusUpdate.Text = ex.Message;
                }
            }
        }

        protected void dgrDotDanhGia_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dgrDotDanhGia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex < 0) return;

            Label lblThoiGianBatDau = (Label)e.Row.FindControl("lblThoiGianBatDau");
            Label lblThoiGianKetThuc = (Label)e.Row.FindControl("lblThoiGianKetThuc");

            Button btnEdit = (Button)e.Row.FindControl("btnEdit");
            Button btnDelete = (Button)e.Row.FindControl("btnDelete");
            Button btnTBP = (Button)e.Row.FindControl("btnTBP");
            Button btnDanhGiaBoPhan = (Button)e.Row.FindControl("btnDanhGiaBoPhan");
            Button btnNDG = (Button)e.Row.FindControl("btnNDG");
            Button btnNDGTP = (Button)e.Row.FindControl("btnNDGTP");
            Button btnDetail = (Button)e.Row.FindControl("btnDetail");
            DropDownList dropChuan1 = (DropDownList)e.Row.FindControl("dropChuan1");
            DropDownList dropStatus1 = (DropDownList)e.Row.FindControl("dropStatus1");
            if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
            {
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnDanhGiaBoPhan.Visible = false;
                btnTBP.Visible = false;
                btnNDG.Visible = false;
                btnNDGTP.Visible = false;
                btnDetail.Visible = false;
            }
            else
            {
                if (CurrentUser.IsAdmin)
                {
                    btnDanhGiaBoPhan.Visible = false;
                    btnTBP.Visible = false;
                    btnNDG.Visible = true;
                    btnNDGTP.Visible = false;
                    btnDetail.Visible = true;
                }
            }

            DataRowView currData = (DataRowView)e.Row.DataItem;

            lblThoiGianBatDau.Text = ConvertUtility.ToDateTime(currData["ThoiGianBatDau"]).ToString("dd/MM/yyyyy");
            lblThoiGianKetThuc.Text = ConvertUtility.ToDateTime(currData["ThoiGianKetThuc"]).ToString("dd/MM/yyyyy");
            dropStatus1.SelectedValue = ConvertUtility.ToInt32(currData["DangChay"]).ToString();
            dropChuan1.SelectedValue = ConvertUtility.ToInt32(currData["IsDefault"]).ToString();
            btnDelete.OnClientClick = MiscUtility.MSG_DELETE_CONFIRM;

        }

        private string GetObjectInfo(QuanLyCongViecKTXVaPSInfo info)
        {
            string returnValue = "";

            #region Bind Old Info

            returnValue += "ID: " + info.ID + " <br />";
            returnValue += "Ten: " + info.Ten + " <br />";
            returnValue += "TyTrong: " + info.TyTrong + " <br />";
            returnValue += "ParentID: " + info.ParentID + " <br />";
            returnValue += "Priority: " + info.Priority + " <br />";
            returnValue += "KeHoach: " + info.KeHoach + " <br />";
            returnValue += "DonViDo: " + info.DonViDo + " <br />";
            returnValue += "IDTrungTam: " + info.IDTrungTam + " <br />";
            returnValue += "IDPhongBan: " + info.IDPhongBan;
            returnValue += "DateTime: " + DateTime.Now;

            #endregion

            return returnValue;
        }

        protected void btnThemMoi1_Click(object sender, EventArgs e)
        {
            //lay dot danh gia truoc ra lam chuan
            int idDotDanhCopy = ConvertUtility.ToInt32(DotDanhGiaController.GetDaultDotDanhGia().Rows[0]["ID"]);

            #region Tao dot danh gia moi

            DotDanhGiaInfo infoDotDanhGia = new DotDanhGiaInfo();

            infoDotDanhGia.Ten = txtTen.Text.Trim();
            infoDotDanhGia.ThoiGianBatDau = ConvertUtility.ToDateTime(txtThoiGianBatDau.Text);
            infoDotDanhGia.ThoiGianKetThuc = ConvertUtility.ToDateTime(txtThoiGianKetThuc.Text);
            infoDotDanhGia.TrangThai = ConvertUtility.ToInt32(dropTypeOf.SelectedValue);
            infoDotDanhGia.DangChay = ConvertUtility.ToInt32(dropStatus.SelectedValue);
            infoDotDanhGia.IsDefault = ConvertUtility.ToInt32(dropChuan.SelectedValue);

            infoDotDanhGia.Nam = infoDotDanhGia.ThoiGianKetThuc.Year;
            infoDotDanhGia.Thang = infoDotDanhGia.ThoiGianKetThuc.Month;

            int idDotDanhGia = DotDanhGiaController.Insert(infoDotDanhGia);

            #endregion

            DataTable dtTrungTam = BoPhanController.BoPhan_GetAllActive();

            foreach (DataRow itemTrungTam in dtTrungTam.Rows)
            {
                DataTable source = QuanLyCongViecKTXVaPSController.GetAllNhanVienTheoQLVaDotDanhGia(ConvertUtility.ToInt32(itemTrungTam["ID"]), idDotDanhCopy);

                UpdateNhanVienTheoNDG(source, idDotDanhGia, ConvertUtility.ToInt32(itemTrungTam["ID"]));

                UpdateNhanVienVaoDotDanhGia(source, idDotDanhGia, ConvertUtility.ToInt32(itemTrungTam["ID"]));
            }
        }

        private void UpdateNhanVienTheoNDG(DataTable source, int idDotDanhGia, int idTrungTam)
        {
            foreach (DataRow _item in source.Rows)
            {
                int idNhanVien = ConvertUtility.ToInt32(_item["IDNhanVien"]);
                int IDNguoiDG = ConvertUtility.ToInt32(_item["IDNguoiDG"]);

                DotDanhGiaController.UpdateNhanVienTheoNDG(idNhanVien, idTrungTam, IDNguoiDG, idDotDanhGia);
            }
        }

        private void UpdateNhanVienVaoDotDanhGia(DataTable source, int idDotDanhGia, int idTrungTam)
        {
            foreach (DataRow _item in source.Rows)
            {
                int idNhanVien = ConvertUtility.ToInt32(_item["IDNhanVien"]);
                int IDNguoiDG = ConvertUtility.ToInt32(_item["IDNguoiDG"]);

                DotDanhGiaController.UpdateNhanVienVaoDotDanhGia(idDotDanhGia, idNhanVien, idTrungTam, 3);
                DotDanhGiaController.UpdateNhanVienVaoDotDanhGia(idDotDanhGia, idNhanVien, idTrungTam, 3, IDNguoiDG);
            }
        }
    }
}