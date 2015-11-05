using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library.Components.Security;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;
using System.Data;
using VmgPortal.Library.Utilities;
using VmgPortal.Library.Components.Users;
using VmgPortal.Modules.KPIData.Library;
using VmgPortal.Modules.KPIData.Library.Common;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using VmgPortal.Library;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace VmgPortal.Modules.KPIData.Admin.BaoCao.XepLoaiThang
{
    public partial class BaoCaoCongViecNhanVien : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dropTrungTam.DataSource = BoPhanController.GetAll();
                dropTrungTam.DataBind();

                if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                {
                    dropTrungTam.Enabled = false;
                    dropTrungTam.SelectedValue = CurrentUser.IDTrungTam.ToString();
                }

                dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
                dropDotDanhGia.DataBind();

                DataTable dtPhong;
                if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                {
                    dropTrungTam.Enabled = false;

                    if (CurrentUser.RoleID != (int)Constants.Role.TruongBoPhanKhoiHoTro && CurrentUser.RoleID != (int)Constants.Role.TruongBoPhanKhoiKinhDoanh)
                    {
                        dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), CurrentUser.UserID);
                    }
                    else
                    {
                        dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
                    }
                }
                else
                {
                    dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
                }

                dropPhongBan.DataSource = dtPhong;
                dropPhongBan.DataBind();
                dropPhongBan.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));
                try
                {
                    dropPhongBan.SelectedValue = CurrentUser.IDPhong.ToString();
                }
                catch (Exception)
                {
                    dropPhongBan.SelectedIndex = -1;
                }

            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        protected void dropTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropPhongBan.Items.Clear();
            dropPhongBan.DataSource = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            dropPhongBan.DataBind();
            dropPhongBan.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));
        }

        protected void dropPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dtNhanVien = DotDanhGiaController.GetAllNhanVien(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropPhongBan.SelectedValue));

            if (dtNhanVien == null) return;

            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            int sheet = 1;
            foreach (DataRow itemNhanVien in dtNhanVien.Rows)
            {
                int idNhanVien = ConvertUtility.ToInt32(itemNhanVien["UserID"]);

                #region Cong viec thuong xuyen

                DataTable dtCongViec = DotDanhGiaController.GetAllCongViecGiaoChoNhanVienKTXVaPS(idNhanVien, 1, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));
                DataTable dtCongViecNew = dtCongViec.Clone();
                dtCongViecNew.Columns.Add("TyTrongCaNhan", typeof(string));
                dtCongViecNew.Columns.Add("TyTrongCaNhanSoVoiPhong", typeof(string));
                dtCongViecNew.Columns.Add("GioLamViec", typeof(string));

                DataSet ds = DotDanhGiaController.GetPTDG(idNhanVien, 0, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue));

                DataTable dtSoNhanVien = ds.Tables[1];
                DataTable dtTyTrong = ds.Tables[2];
                DataTable dtSoNhanVienPhong = ds.Tables[3];

                int tongSoNhanVien = 0;
                if (dtSoNhanVien != null && dtSoNhanVien.Rows.Count > 0)
                {
                    tongSoNhanVien = ConvertUtility.ToInt32(dtSoNhanVien.Rows[0]["TongSoNhanVien"]);
                }

                int tyTrongCVPhongVoiTrungTam = 0;
                if (dtTyTrong != null && dtTyTrong.Rows.Count > 0)
                {
                    tyTrongCVPhongVoiTrungTam = ConvertUtility.ToInt32(dtTyTrong.Rows[0]["TyTrong"]);
                }

                if (tyTrongCVPhongVoiTrungTam == 0) tyTrongCVPhongVoiTrungTam = 100;

                int tongSoNhanVienPhong = 0;
                if (dtSoNhanVienPhong != null && dtSoNhanVienPhong.Rows.Count > 0)
                {
                    tongSoNhanVienPhong = ConvertUtility.ToInt32(dtSoNhanVienPhong.Rows[0]["TongSoNhanVien"]);
                }

                DataRow rowHeader = dtCongViecNew.NewRow();
                rowHeader["TenCVCha"] = "-----------------Công việc thường xuyên----------------";
                rowHeader["Ten"] = "---------------------------";
                rowHeader["TyTrong"] = "0";
                rowHeader["KeHoach"] = "";
                rowHeader["TyTrongCaNhan"] = "0";
                rowHeader["GioLamViec"] = "0";
                rowHeader["TyTrongCaNhanSoVoiPhong"] = "0";
                dtCongViecNew.Rows.Add(rowHeader);
                foreach (DataRow item in dtCongViec.Rows)
                {
                    DataRow row = dtCongViecNew.NewRow();
                    int idCongViecKPI = ConvertUtility.ToInt32(item["IDCongViecKPI"]);

                    DataTable dtTyTrongKPI = DotDanhGiaController.GetTyTrongCongViec(idCongViecKPI, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropPhongBan.SelectedValue), idNhanVien);

                    double tyTrongCVDuocGiao = 0;

                    row["TenCVCha"] = ConvertUtility.ToString(item["TenCVCha"]);
                    row["Ten"] = item["Ten"];
                    double tyTrongCVDuocGiaoCaNhan = 0;
                    double tyTrongCVDuocGiaoCaNhanSoVoiPhong = 0;
                    
                    if (dtTyTrongKPI != null && dtTyTrongKPI.Rows.Count > 0)
                    {
                        tyTrongCVDuocGiaoCaNhan = ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]) * tongSoNhanVien;

                        double songaylamvieccuaNV = Math.Round(ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]) * tongSoNhanVien * 22 / 100, 3);
                        double tongsongaylamvieccuaphong = Math.Round(ConvertUtility.ToDouble(tongSoNhanVien) * 22 * tyTrongCVPhongVoiTrungTam / 100, 3);
                        tyTrongCVDuocGiaoCaNhanSoVoiPhong = Math.Round(songaylamvieccuaNV * 100 / tongsongaylamvieccuaphong, 3);

                        tyTrongCVDuocGiao = Math.Round(ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]), 3);
                        row["TyTrong"] = tyTrongCVDuocGiao;
                    }
                    else
                    {
                        tyTrongCVDuocGiaoCaNhan = ConvertUtility.ToDouble(item["TyTrong"]) * tongSoNhanVien;

                        double songaylamvieccuaNV = Math.Round(ConvertUtility.ToDouble(item["TyTrong"]) * tongSoNhanVien * 22 / 100, 3);
                        double tongsongaylamvieccuaphong = Math.Round(ConvertUtility.ToDouble(tongSoNhanVien) * 22 * tyTrongCVPhongVoiTrungTam / 100, 3);
                        tyTrongCVDuocGiaoCaNhanSoVoiPhong = Math.Round(songaylamvieccuaNV * 100 / tongsongaylamvieccuaphong, 3);

                        tyTrongCVDuocGiao = Math.Round(ConvertUtility.ToDouble(item["TyTrong"]), 3);
                        row["TyTrong"] = tyTrongCVDuocGiao;
                    }

                    row["KeHoach"] = item["KeHoach"].ToString();
                    row["TyTrongCaNhan"] = Math.Round(tyTrongCVDuocGiaoCaNhan, 3).ToString().Replace(",", ".");// tyTrongCVDuocGiaoCaNhan.ToString().Replace(",", ".");
                    row["GioLamViec"] = Math.Round(tyTrongCVDuocGiaoCaNhan * 22 * 8 / 100, 3).ToString().Replace(",", ".");


                    //if (dtTyTrongKPI != null && dtTyTrongKPI.Rows.Count > 0)
                    //{
                    //    tyTrongCVDuocGiaoCaNhan = ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]) * tongSoNhanVien;

                    //    double songaylamvieccuaNV = Math.Round(ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]) * tongSoNhanVien * 22 / 100, 2);
                    //    double tongsongaylamvieccuaphong = Math.Round(ConvertUtility.ToDouble(tongSoNhanVien) * 22 * tyTrongCVPhongVoiTrungTam / 100, 2);
                    //    tyTrongCVDuocGiaoCaNhanSoVoiPhong = Math.Round(songaylamvieccuaNV * 100 / tongsongaylamvieccuaphong, 2);

                    //    tyTrongCVDuocGiao = Math.Round(ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]), 2);
                    //    row["TyTrong"] = tyTrongCVDuocGiao.ToString();
                    //}
                    //else
                    //{
                    //    tyTrongCVDuocGiaoCaNhan = ConvertUtility.ToDouble(item["TyTrong"]) * tongSoNhanVien;

                    //    double songaylamvieccuaNV = Math.Round(ConvertUtility.ToDouble(item["TyTrong"]) * tongSoNhanVien * 22 / 100, 2);
                    //    double tongsongaylamvieccuaphong = Math.Round(ConvertUtility.ToDouble(tongSoNhanVien) * 22 * tyTrongCVPhongVoiTrungTam / 100, 2);
                    //    tyTrongCVDuocGiaoCaNhanSoVoiPhong = Math.Round(songaylamvieccuaNV * 100 / tongsongaylamvieccuaphong, 2);

                    //    tyTrongCVDuocGiao = Math.Round(ConvertUtility.ToDouble(item["TyTrong"]), 2);
                    //    row["TyTrong"] = tyTrongCVDuocGiao.ToString();
                    //}
                    row["TyTrongCaNhanSoVoiPhong"] = tyTrongCVDuocGiaoCaNhanSoVoiPhong.ToString().Replace(",", ".");
                    dtCongViecNew.Rows.Add(row);

                }

                #endregion

                rowHeader = dtCongViecNew.NewRow();
                rowHeader["TenCVCha"] = "-----------------Công việc kế hoạch tháng----------------";
                rowHeader["Ten"] = "---------------------------";
                rowHeader["TyTrong"] = "0";
                rowHeader["KeHoach"] = "";
                rowHeader["TyTrongCaNhan"] = "0";
                rowHeader["GioLamViec"] = "0";
                rowHeader["TyTrongCaNhanSoVoiPhong"] = "0";
                dtCongViecNew.Rows.Add(rowHeader);

                #region Cong viec ke hoach thang

                dtCongViec = DotDanhGiaController.GetAllCongViecGiaoChoNhanVienKTXVaPS(idNhanVien, 2, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

                ds = DotDanhGiaController.GetPTDG(idNhanVien, 0, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue));

                dtSoNhanVien = ds.Tables[1];
                dtTyTrong = ds.Tables[2];
                dtSoNhanVienPhong = ds.Tables[3];

                tongSoNhanVien = 0;
                if (dtSoNhanVien != null && dtSoNhanVien.Rows.Count > 0)
                {
                    tongSoNhanVien = ConvertUtility.ToInt32(dtSoNhanVien.Rows[0]["TongSoNhanVien"]);
                }

                tyTrongCVPhongVoiTrungTam = 0;
                if (dtTyTrong != null && dtTyTrong.Rows.Count > 0)
                {
                    tyTrongCVPhongVoiTrungTam = ConvertUtility.ToInt32(dtTyTrong.Rows[0]["TyTrong"]);
                }

                if (tyTrongCVPhongVoiTrungTam == 0) tyTrongCVPhongVoiTrungTam = 100;

                tongSoNhanVienPhong = 0;
                if (dtSoNhanVienPhong != null && dtSoNhanVienPhong.Rows.Count > 0)
                {
                    tongSoNhanVienPhong = ConvertUtility.ToInt32(dtSoNhanVienPhong.Rows[0]["TongSoNhanVien"]);
                }

                double tyTrongCVKeHoachThang = 0;
                foreach (DataRow item in dtCongViec.Rows)
                {
                    DataRow row = dtCongViecNew.NewRow();
                    int idCongViecKPI = ConvertUtility.ToInt32(item["IDCongViecKPI"]);

                    DataTable dtTyTrongKPI = DotDanhGiaController.GetTyTrongCongViec(idCongViecKPI, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropPhongBan.SelectedValue),idNhanVien);

                    double tyTrongCVDuocGiao = 0;

                    row["TenCVCha"] = ConvertUtility.ToString(item["TenCVCha"]);
                    row["Ten"] = item["Ten"];
                    //double tyTrongCVDuocGiaoCaNhan = 0;
                    //double tyTrongCVDuocGiaoCaNhanSoVoiPhong = 0;
                    //if (dtTyTrongKPI != null && dtTyTrongKPI.Rows.Count > 0)
                    //{
                    //    tyTrongCVDuocGiaoCaNhan = ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]) * tongSoNhanVien;
                    //    tyTrongCVKeHoachThang += tyTrongCVDuocGiaoCaNhan;

                    //    double songaylamvieccuaNV = Math.Round(ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]) * tongSoNhanVien * 22 / 100, 2);
                    //    double tongsongaylamvieccuaphong = Math.Round(ConvertUtility.ToDouble(tongSoNhanVien) * 22 * tyTrongCVPhongVoiTrungTam / 100, 2);
                    //    tyTrongCVDuocGiaoCaNhanSoVoiPhong = Math.Round(songaylamvieccuaNV * 100 / tongsongaylamvieccuaphong, 2);

                    //    tyTrongCVDuocGiao = Math.Round(ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]), 2);
                    //    row["TyTrong"] = tyTrongCVDuocGiao.ToString();
                    //}
                    //else
                    //{
                    //    tyTrongCVDuocGiaoCaNhan = ConvertUtility.ToDouble(item["TyTrong"]) * tongSoNhanVien;
                    //    tyTrongCVKeHoachThang += tyTrongCVDuocGiaoCaNhan;

                    //    double songaylamvieccuaNV = Math.Round(ConvertUtility.ToDouble(item["TyTrong"]) * tongSoNhanVien * 22 / 100, 2);
                    //    double tongsongaylamvieccuaphong = Math.Round(ConvertUtility.ToDouble(tongSoNhanVien) * 22 * tyTrongCVPhongVoiTrungTam / 100, 2);
                    //    tyTrongCVDuocGiaoCaNhanSoVoiPhong = Math.Round(songaylamvieccuaNV * 100 / tongsongaylamvieccuaphong, 2);

                    //    tyTrongCVDuocGiao = Math.Round(ConvertUtility.ToDouble(item["TyTrong"]), 2);
                    //    row["TyTrong"] = tyTrongCVDuocGiao.ToString();
                    //}
                    //row["KeHoach"] = item["KeHoach"].ToString();

                    //row["TyTrongCaNhan"] = tyTrongCVDuocGiaoCaNhan.ToString().Replace(",", ".");
                    //row["GioLamViec"] = Math.Round(tyTrongCVDuocGiaoCaNhan * 22 * 8 / 100, 2);

                    double tyTrongCVDuocGiaoCaNhan = 0;
                    double tyTrongCVDuocGiaoCaNhanSoVoiPhong = 0;

                    if (dtTyTrongKPI != null && dtTyTrongKPI.Rows.Count > 0)
                    {
                        tyTrongCVDuocGiaoCaNhan = ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]) * tongSoNhanVien;

                        double songaylamvieccuaNV = Math.Round(ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]) * tongSoNhanVien * 22 / 100, 3);
                        double tongsongaylamvieccuaphong = Math.Round(ConvertUtility.ToDouble(tongSoNhanVien) * 22 * tyTrongCVPhongVoiTrungTam / 100, 3);
                        tyTrongCVDuocGiaoCaNhanSoVoiPhong = Math.Round(songaylamvieccuaNV * 100 / tongsongaylamvieccuaphong, 3);

                        tyTrongCVDuocGiao = Math.Round(ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]), 3);
                        row["TyTrong"] = tyTrongCVDuocGiao;
                    }
                    else
                    {
                        tyTrongCVDuocGiaoCaNhan = ConvertUtility.ToDouble(item["TyTrong"]) * tongSoNhanVien;

                        double songaylamvieccuaNV = Math.Round(ConvertUtility.ToDouble(item["TyTrong"]) * tongSoNhanVien * 22 / 100, 3);
                        double tongsongaylamvieccuaphong = Math.Round(ConvertUtility.ToDouble(tongSoNhanVien) * 22 * tyTrongCVPhongVoiTrungTam / 100, 3);
                        tyTrongCVDuocGiaoCaNhanSoVoiPhong = Math.Round(songaylamvieccuaNV * 100 / tongsongaylamvieccuaphong, 3);

                        tyTrongCVDuocGiao = Math.Round(ConvertUtility.ToDouble(item["TyTrong"]), 3);
                        row["TyTrong"] = tyTrongCVDuocGiao;
                    }

                    row["KeHoach"] = item["KeHoach"].ToString();
                    row["TyTrongCaNhan"] = Math.Round(tyTrongCVDuocGiaoCaNhan, 3).ToString().Replace(",", ".");// tyTrongCVDuocGiaoCaNhan.ToString().Replace(",", ".");
                    row["GioLamViec"] = Math.Round(tyTrongCVDuocGiaoCaNhan * 22 * 8 / 100, 3).ToString().Replace(",", ".");

                    row["TyTrongCaNhanSoVoiPhong"] = tyTrongCVDuocGiaoCaNhanSoVoiPhong.ToString().Replace(",", ".");
                    dtCongViecNew.Rows.Add(row);

                }

                #endregion

                rowHeader = dtCongViecNew.NewRow();
                rowHeader["TenCVCha"] = "-----------------Công việc phát sinh----------------";
                rowHeader["Ten"] = "---------------------------";
                rowHeader["TyTrong"] = "0";
                rowHeader["KeHoach"] = "";
                rowHeader["TyTrongCaNhan"] = "0";
                rowHeader["GioLamViec"] = "0";
                rowHeader["TyTrongCaNhanSoVoiPhong"] = "0";
                dtCongViecNew.Rows.Add(rowHeader);

                #region Cong viec phat sinh

                dtCongViec = DotDanhGiaController.GetAllCongViecGiaoChoNhanVienKTXVaPS(idNhanVien, 3, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

                ds = DotDanhGiaController.GetPTDG(idNhanVien, 0, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue));

                dtSoNhanVien = ds.Tables[1];
                dtTyTrong = ds.Tables[2];
                dtSoNhanVienPhong = ds.Tables[3];

                tongSoNhanVien = 0;
                if (dtSoNhanVien != null && dtSoNhanVien.Rows.Count > 0)
                {
                    tongSoNhanVien = ConvertUtility.ToInt32(dtSoNhanVien.Rows[0]["TongSoNhanVien"]);
                }

                tyTrongCVPhongVoiTrungTam = 0;
                if (dtTyTrong != null && dtTyTrong.Rows.Count > 0)
                {
                    tyTrongCVPhongVoiTrungTam = ConvertUtility.ToInt32(dtTyTrong.Rows[0]["TyTrong"]);
                }

                if (tyTrongCVPhongVoiTrungTam == 0) tyTrongCVPhongVoiTrungTam = 100;

                tongSoNhanVienPhong = 0;
                if (dtSoNhanVienPhong != null && dtSoNhanVienPhong.Rows.Count > 0)
                {
                    tongSoNhanVienPhong = ConvertUtility.ToInt32(dtSoNhanVienPhong.Rows[0]["TongSoNhanVien"]);
                }

                tyTrongCVKeHoachThang = 0;
                foreach (DataRow item in dtCongViec.Rows)
                {
                    DataRow row = dtCongViecNew.NewRow();
                    int idCongViecKPI = ConvertUtility.ToInt32(item["IDCongViecKPI"]);

                    DataTable dtTyTrongKPI = DotDanhGiaController.GetTyTrongCongViec(idCongViecKPI, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropPhongBan.SelectedValue), idNhanVien);

                    double tyTrongCVDuocGiao = 0;

                    row["TenCVCha"] = ConvertUtility.ToString(item["TenCVCha"]);
                    row["Ten"] = item["Ten"];
                    //double tyTrongCVDuocGiaoCaNhan = 0;
                    //double tyTrongCVDuocGiaoCaNhanSoVoiPhong = 0;
                    //if (dtTyTrongKPI != null && dtTyTrongKPI.Rows.Count > 0)
                    //{
                    //    tyTrongCVDuocGiaoCaNhan = Math.Round(ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]) * tongSoNhanVien, 2);
                    //    tyTrongCVKeHoachThang += tyTrongCVDuocGiaoCaNhan;

                    //    double songaylamvieccuaNV = Math.Round(ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]) * tongSoNhanVien * 22 / 100, 2);
                    //    double tongsongaylamvieccuaphong = Math.Round(ConvertUtility.ToDouble(tongSoNhanVien) * 22 * tyTrongCVPhongVoiTrungTam / 100, 2);
                    //    tyTrongCVDuocGiaoCaNhanSoVoiPhong = Math.Round(songaylamvieccuaNV * 100 / tongsongaylamvieccuaphong, 2);

                    //    tyTrongCVDuocGiao = Math.Round(ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]), 2);
                    //    row["TyTrong"] = tyTrongCVDuocGiao.ToString();
                    //}
                    //else
                    //{
                    //    tyTrongCVDuocGiaoCaNhan = Math.Round(ConvertUtility.ToDouble(item["TyTrong"]) * tongSoNhanVien, 2);
                    //    tyTrongCVKeHoachThang += tyTrongCVDuocGiaoCaNhan;

                    //    double songaylamvieccuaNV = Math.Round(ConvertUtility.ToDouble(item["TyTrong"]) * tongSoNhanVien * 22 / 100, 2);
                    //    double tongsongaylamvieccuaphong = Math.Round(ConvertUtility.ToDouble(tongSoNhanVien) * 22 * tyTrongCVPhongVoiTrungTam / 100, 2);
                    //    tyTrongCVDuocGiaoCaNhanSoVoiPhong = Math.Round(songaylamvieccuaNV * 100 / tongsongaylamvieccuaphong, 2);

                    //    tyTrongCVDuocGiao = Math.Round(ConvertUtility.ToDouble(item["TyTrong"]), 2);
                    //    row["TyTrong"] = tyTrongCVDuocGiao.ToString();
                    //}
                    //row["KeHoach"] = item["KeHoach"].ToString();

                    //row["TyTrongCaNhan"] = tyTrongCVDuocGiaoCaNhan.ToString().Replace(",", ".");
                    //row["GioLamViec"] = Math.Round(tyTrongCVDuocGiaoCaNhan * 22 * 8 / 100, 2);

                    double tyTrongCVDuocGiaoCaNhan = 0;
                    double tyTrongCVDuocGiaoCaNhanSoVoiPhong = 0;

                    if (dtTyTrongKPI != null && dtTyTrongKPI.Rows.Count > 0)
                    {
                        tyTrongCVDuocGiaoCaNhan = ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]) * tongSoNhanVien;

                        double songaylamvieccuaNV = Math.Round(ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]) * tongSoNhanVien * 22 / 100, 3);
                        double tongsongaylamvieccuaphong = Math.Round(ConvertUtility.ToDouble(tongSoNhanVien) * 22 * tyTrongCVPhongVoiTrungTam / 100, 3);
                        tyTrongCVDuocGiaoCaNhanSoVoiPhong = Math.Round(songaylamvieccuaNV * 100 / tongsongaylamvieccuaphong, 3);

                        tyTrongCVDuocGiao = Math.Round(ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]), 3);
                        row["TyTrong"] = tyTrongCVDuocGiao;
                    }
                    else
                    {
                        tyTrongCVDuocGiaoCaNhan = ConvertUtility.ToDouble(item["TyTrong"]) * tongSoNhanVien;

                        double songaylamvieccuaNV = Math.Round(ConvertUtility.ToDouble(item["TyTrong"]) * tongSoNhanVien * 22 / 100, 3);
                        double tongsongaylamvieccuaphong = Math.Round(ConvertUtility.ToDouble(tongSoNhanVien) * 22 * tyTrongCVPhongVoiTrungTam / 100, 3);
                        tyTrongCVDuocGiaoCaNhanSoVoiPhong = Math.Round(songaylamvieccuaNV * 100 / tongsongaylamvieccuaphong, 3);

                        tyTrongCVDuocGiao = Math.Round(ConvertUtility.ToDouble(item["TyTrong"]), 3);
                        row["TyTrong"] = tyTrongCVDuocGiao;
                    }

                    row["KeHoach"] = item["KeHoach"].ToString();
                    row["TyTrongCaNhan"] = Math.Round(tyTrongCVDuocGiaoCaNhan, 3).ToString().Replace(",", ".");// tyTrongCVDuocGiaoCaNhan.ToString().Replace(",", ".");
                    row["GioLamViec"] = Math.Round(tyTrongCVDuocGiaoCaNhan * 22 * 8 / 100, 3).ToString().Replace(",", ".");

                    row["TyTrongCaNhanSoVoiPhong"] = tyTrongCVDuocGiaoCaNhanSoVoiPhong.ToString().Replace(",", ".");
                    dtCongViecNew.Rows.Add(row);

                }

                #endregion

                XmlDocument doc = BuildXmlDocument(dtCongViecNew);

                if (!Directory.Exists(Server.MapPath("/UpLoad/Temp/" + itemNhanVien["UserID"].ToString() + "/")))
                {
                    Directory.CreateDirectory(Server.MapPath("/UpLoad/Temp/" + itemNhanVien["UserID"].ToString() + "/"));
                }
                ////ds.Dispose();
                string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
                FileStream downloadFile =
                    File.Create(Server.MapPath("/UpLoad/Temp/" + itemNhanVien["UserID"].ToString() + "/") + "ReportCongViecNhanVien_" + datetime +
                                ".xls");

                // transform
                XslTransform xsl = new XslTransform();
                xsl.Load(Server.MapPath("/Template/" + "ReportCongViecNhanVien.xsl"));

                DateConverter objDateConverter = new DateConverter();
                XsltArgumentList args = new XsltArgumentList();
                args.AddExtensionObject("urn:ms-kb", objDateConverter);

                xsl.Transform(doc, args, downloadFile, null);
                downloadFile.Flush();
                downloadFile.Close();

                HyperLink hplDownload = new HyperLink();
                hplDownload.Text = "Công việc của " + itemNhanVien["Username"].ToString() + ", click vào link để Tải file về";
                hplDownload.Visible = true;
                hplDownload.NavigateUrl = "/UpLoad/Temp/" + itemNhanVien["UserID"].ToString() + "/ReportCongViecNhanVien_" + datetime + ".xls";

                Literal lit = new Literal();
                lit.Text = "<br />";
                pnLink.Controls.Add(hplDownload);
                pnLink.Controls.Add(lit);

                CreateExcelDoc excell_app = new CreateExcelDoc(sheet, xlWorkBook, itemNhanVien["UserName"].ToString());
                //creates the main header
                excell_app.createHeaders(1, 1, "Nhóm công việc", "A1", "A1", 0, "YELLOW", true, 40, "");
                excell_app.createHeaders(1, 2, "Tên công việc", "B1", "B1", 0, "YELLOW", true, 40, "");
                excell_app.createHeaders(1, 3, "Kế hoạch", "C1", "C1", 0, "YELLOW", true, 40, "");
                excell_app.createHeaders(1, 4, "Tỷ Trọng so với trung tâm", "D1", "D1", 0, "YELLOW", true, 20, "");
                excell_app.createHeaders(1, 5, "Tỷ Trọng so với phòng", "E1", "E1", 0, "YELLOW", true, 20, "");
                excell_app.createHeaders(1, 6, "Tỷ Trọng công việc cá nhân trong tháng", "F1", "F1", 0, "YELLOW", true, 20, "");
                excell_app.createHeaders(1, 7, "Giờ làm việc", "G1", "G1", 0, "YELLOW", true, 20, "");

                int rowIndex = 2;
                foreach (DataRow item in dtCongViecNew.Rows)
                {
                    excell_app.addData(rowIndex, 1, item["TenCVCha"].ToString(), "A" + rowIndex.ToString(), "A" + rowIndex.ToString(), "");
                    excell_app.addData(rowIndex, 2, item["Ten"].ToString(), "B" + rowIndex.ToString(), "B" + rowIndex.ToString() , "");
                    excell_app.addData(rowIndex, 3, item["KeHoach"].ToString(), "C" + rowIndex.ToString(), "C" + rowIndex.ToString(), "");
                    excell_app.addData(rowIndex, 4, item["TyTrong"].ToString(), "D" + rowIndex.ToString() , "D" + rowIndex.ToString(), "#,##0");
                    excell_app.addData(rowIndex, 5, item["TyTrongCaNhanSoVoiPhong"].ToString(), "E" + rowIndex.ToString(), "E" + rowIndex.ToString() , "#,##0");
                    excell_app.addData(rowIndex, 6, item["TyTrongCaNhan"].ToString(), "F" + rowIndex.ToString(), "F" + rowIndex.ToString(), "#,##0");
                    excell_app.addData(rowIndex, 7, item["GioLamViec"].ToString(), "G" + rowIndex.ToString(), "G" + rowIndex.ToString(), "");

                    rowIndex++;
                }

                sheet++;
            }

            string datetimeTTPhong = DateTime.Now.ToString("yyyyMMddHHmmss");
            string fileName = "/UpLoad/Temp/ReportCongViecNhanVien_" + datetimeTTPhong + ".xls";
            CreateExcelDoc.SaveExcel(Server.MapPath(fileName), xlWorkBook);

            HyperLink hplDownloadCVPhongTT = new HyperLink();
            hplDownloadCVPhongTT.Text = "Công việc của Trung Tâm hoặc phòng, click vào link để Tải file về";
            hplDownloadCVPhongTT.Visible = true;
            hplDownloadCVPhongTT.NavigateUrl = fileName;

            pnLink.Controls.Add(hplDownloadCVPhongTT);
        }

        private XmlDocument BuildXmlDocument(DataTable source)
        {
            XmlDocument _XMLDoc = new XmlDocument();

            string xml = DateConverter.ConvertDataTableToXML(source);

            _XMLDoc.LoadXml(xml);

            return _XMLDoc;
        }
    }
}