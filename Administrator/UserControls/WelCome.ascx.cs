using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VmgPortal.Library;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Utilities;
using VmgPortal.Modules.KPIData.Library;
using VmgPortal.Library.Components.Users;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using VmgPortal.Modules.KPIData.Library.DanhGia;

namespace VmgPortal.Administrator.UserControls
{
    public partial class WelCome : AuthenticatedControl
    {
        int idDotDanhGia = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //idDotDanhGia = ConvertUtility.ToInt32(Request.QueryString["idDotDanhGia"]);
            //if (!IsPostBack)
            //{
            //    if (CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiHoTro || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiKinhDoanh || CurrentUser.RoleID == (int)Constants.Role.TruongPhong || CurrentUser.RoleID == (int)Constants.Role.PhoPhong || CurrentUser.RoleID == (int)Constants.Role.TruongNhom)
            //    {
            //        ViewState["DropDownPageItemsChuaGuiKeHoach"] = 10;
            //        ViewState["DropDownPageItemsDaGuiKeHoach"] = 10;
            //        ViewState["DropDownPageItemsChuaGuiDanhGia"] = 10;
            //        ViewState["DropDownPageItemsDaGuiDanhGia"] = 10;
            //        ViewState["DropDownPageItemsCongViecPhatSinh"] = 10;
            //    }

            //    if (CurrentUser.RoleID == (int)Constants.Role.CEO || CurrentUser.RoleID == (int)Constants.Role.COO)
            //    {
            //        ViewState["DropDownPageItemsBoPhanChuaGuiKeHoach"] = 10;
            //        ViewState["DropDownPageItemsBoPhanDaGuiKeHoach"] = 10;
            //        ViewState["DropDownPageItemsBoPhanChuaGuiDanhGia"] = 10;
            //        ViewState["DropDownPageItemsBoPhanDaGuiDanhGia"] = 10;
            //    }

            //    dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
            //    dropDotDanhGia.DataBind();

            //    if (idDotDanhGia == 0)
            //    {
            //        try
            //        {
            //            int idDotDotDanhDefault = ConvertUtility.ToInt32(DotDanhGiaController.GetDaultDotDanhGia().Rows[0]["ID"]);
            //            Response.Redirect(AppEnv.AdminUrlParams("home") + "&idDotDanhGia=" + idDotDotDanhDefault);
            //        }
            //        catch (Exception)
            //        {
            //        }

            //    }
            //    else
            //    {
            //        dropDotDanhGia.SelectedValue = idDotDanhGia.ToString();
            //    }
            //}
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            //if (CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiHoTro || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiKinhDoanh || CurrentUser.RoleID == (int)Constants.Role.TruongPhong || CurrentUser.RoleID == (int)Constants.Role.PhoPhong || CurrentUser.RoleID == (int)Constants.Role.TruongNhom)
            //{
            //    pnlCOO_CEO.Visible = false;

            //    #region Chua Gui Ke Hoạch

            //    DataTable dtUsersChuaGuiKeHoach;

            //    if (CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiHoTro || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiKinhDoanh)
            //    {
            //        dtUsersChuaGuiKeHoach = UserController.GetUsersKeHoachByNguoiDanhGiaTheoThang(CurrentUser.UserID, CurrentUser.IDTrungTam, idDotDanhGia, CurrentUser.RoleID, (int)Constants.TrangThaiDanhGiaNhanVien.LapKeHoach);
            //    }
            //    else
            //    {
            //        dtUsersChuaGuiKeHoach = UserController.GetUsersKeHoachByNguoiDanhGiaTheoThang(CurrentUser.UserID, CurrentUser.IDTrungTam, idDotDanhGia, CurrentUser.RoleID, (int)Constants.TrangThaiDanhGiaNhanVien.LapKeHoach);
            //    }
            //    //-------sort----------
            //    DataView dv = new DataView(dtUsersChuaGuiKeHoach);
            //    if (ViewState["sortExpressionChuaGuiKeHoach"] != null && ViewState["sortExpressionChuaGuiKeHoach"].ToString() != string.Empty)
            //    {
            //        dv.Sort = ViewState["sortExpressionChuaGuiKeHoach"].ToString();
            //    }


            //    if (ViewState["sortDirectionChuaGuiKeHoach"] != null && ViewState["sortDirectionChuaGuiKeHoach"].ToString() == "Desc")
            //    {
            //        dv.Sort = ViewState["sortExpressionChuaGuiKeHoach"].ToString() + " " + ViewState["sortDirectionChuaGuiKeHoach"].ToString();
            //    }
            //    //--------sort-------------

            //    dgrChuaGuiKeHoach.DataSource = dv;
            //    dgrChuaGuiKeHoach.RowDataBound += new GridViewRowEventHandler(dgrChuaGuiKeHoach_RowDataBound);
            //    dgrChuaGuiKeHoach.DataBind();

            //    if (dtUsersChuaGuiKeHoach != null)
            //    {
            //        lblTotalTopChuaGuiKeHoach.Text = dtUsersChuaGuiKeHoach.Rows.Count.ToString();//lblTotalBottomChuaGuiKeHoach.Text = 
            //    }

            //    #endregion

            //    #region Da gui ke hoach

            //    DataTable dtUsersDaGuiKeHoach;

            //    if (CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiHoTro || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiKinhDoanh)
            //    {
            //        dtUsersDaGuiKeHoach = UserController.GetUsersKeHoachByNguoiDanhGiaTheoThang(CurrentUser.UserID, CurrentUser.IDTrungTam, idDotDanhGia, CurrentUser.RoleID, (int)Constants.TrangThaiDanhGiaNhanVien.DaGuiKeHoachChoTBP);
            //    }
            //    else
            //    {
            //        dtUsersDaGuiKeHoach = UserController.GetUsersKeHoachByNguoiDanhGiaTheoThang(CurrentUser.UserID, CurrentUser.IDTrungTam, idDotDanhGia, CurrentUser.RoleID, (int)Constants.TrangThaiDanhGiaNhanVien.DaGuiKeHoachChoTruongPhong);
            //    }
            //    //-------sort----------
            //    dv = new DataView(dtUsersDaGuiKeHoach);
            //    if (ViewState["sortExpressionDaGuiKeHoach"] != null && ViewState["sortExpressionDaGuiKeHoach"].ToString() != string.Empty)
            //    {
            //        dv.Sort = ViewState["sortExpressionDaGuiKeHoach"].ToString();
            //    }


            //    if (ViewState["sortDirectionDaGuiKeHoach"] != null && ViewState["sortDirectionDaGuiKeHoach"].ToString() == "Desc")
            //    {
            //        dv.Sort = ViewState["sortExpressionDaGuiKeHoach"].ToString() + " " + ViewState["sortDirectionDaGuiKeHoach"].ToString();
            //    }
            //    //--------sort-------------

            //    dgrDaGuiKeHoach.DataSource = dv;
            //    dgrDaGuiKeHoach.RowDataBound += new GridViewRowEventHandler(dgrDaGuiKeHoach_RowDataBound);
            //    dgrDaGuiKeHoach.DataBind();

            //    if (dtUsersDaGuiKeHoach != null)
            //    {
            //        lblTotalTopDaGuiKeHoach.Text = dtUsersDaGuiKeHoach.Rows.Count.ToString();//lblTotalBottomDaGuiKeHoach.Text =
            //    }

            //    #endregion

            //    #region Chua gui danh gia

            //    DataTable dtUsersChuaGuiDanhGia;

            //    if (CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiHoTro || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiKinhDoanh)
            //    {
            //        dtUsersChuaGuiDanhGia = UserController.GetUsersDanhGiaByNguoiDanhGiaTheoThang(CurrentUser.UserID, CurrentUser.IDTrungTam, idDotDanhGia, CurrentUser.RoleID, (int)Constants.TrangThaiDanhGiaNhanVien.DangDanhGia);
            //    }
            //    else
            //    {
            //        dtUsersChuaGuiDanhGia = UserController.GetUsersDanhGiaByNguoiDanhGiaTheoThang(CurrentUser.UserID, CurrentUser.IDTrungTam, idDotDanhGia, CurrentUser.RoleID, (int)Constants.TrangThaiDanhGiaNhanVien.DangDanhGia);
            //    }
            //    //-------sort----------
            //    DataView dvChuaGuiDanhGia = new DataView(dtUsersChuaGuiDanhGia);
            //    if (ViewState["sortExpressionChuaGuiDanhGia"] != null && ViewState["sortExpressionChuaGuiKeHoach"].ToString() != string.Empty)
            //    {
            //        dvChuaGuiDanhGia.Sort = ViewState["sortExpressionChuaGuiDanhGia"].ToString();
            //    }


            //    if (ViewState["sortDirectionChuaGuiDanhGia"] != null && ViewState["sortDirectionChuaGuiDanhGia"].ToString() == "Desc")
            //    {
            //        dvChuaGuiDanhGia.Sort = ViewState["sortExpressionChuaGuiDanhGia"].ToString() + " " + ViewState["sortDirectionChuaGuiDanhGia"].ToString();
            //    }
            //    //--------sort-------------

            //    dgrChuaGuiDanhGia.DataSource = dvChuaGuiDanhGia;
            //    dgrChuaGuiDanhGia.RowDataBound += new GridViewRowEventHandler(dgrChuaGuiKeHoach_RowDataBound);
            //    dgrChuaGuiDanhGia.DataBind();

            //    if (dtUsersChuaGuiDanhGia != null)
            //    {
            //        lblTotalTopChuaGuiDanhGia.Text = dtUsersChuaGuiDanhGia.Rows.Count.ToString();//lblTotalBottomChuaGuiDanhGia.Text = 
            //    }

            //    #endregion

            //    #region Da gui danh gia

            //    DataTable dtUsersDaGuiDanhGia;

            //    if (CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiHoTro || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiKinhDoanh)
            //    {
            //        dtUsersDaGuiDanhGia = UserController.GetUsersDanhGiaByNguoiDanhGiaTheoThang(CurrentUser.UserID, CurrentUser.IDTrungTam, idDotDanhGia, CurrentUser.RoleID, (int)Constants.TrangThaiDanhGiaNhanVien.DaGuiDanhGiaChoTruongBoPhan);
            //    }
            //    else
            //    {
            //        dtUsersDaGuiDanhGia = UserController.GetUsersDanhGiaByNguoiDanhGiaTheoThang(CurrentUser.UserID, CurrentUser.IDTrungTam, idDotDanhGia, CurrentUser.RoleID, (int)Constants.TrangThaiDanhGiaNhanVien.DaGuiDanhGiaChoTruongPhong);
            //    }
            //    //-------sort----------
            //    DataView dvDaGuiDanhGia = new DataView(dtUsersDaGuiDanhGia);
            //    if (ViewState["sortExpressionDaGuiDanhGia"] != null && ViewState["sortExpressionChuaGuiKeHoach"].ToString() != string.Empty)
            //    {
            //        dvDaGuiDanhGia.Sort = ViewState["sortExpressionDaGuiDanhGia"].ToString();
            //    }


            //    if (ViewState["sortDirectionDaGuiDanhGia"] != null && ViewState["sortDirectionDaGuiDanhGia"].ToString() == "Desc")
            //    {
            //        dvDaGuiDanhGia.Sort = ViewState["sortExpressionDaGuiDanhGia"].ToString() + " " + ViewState["sortDirectionDaGuiDanhGia"].ToString();
            //    }
            //    //--------sort-------------

            //    dgrDaGuiDanhGia.DataSource = dvDaGuiDanhGia;
            //    dgrDaGuiDanhGia.RowDataBound += new GridViewRowEventHandler(dgrChuaGuiKeHoach_RowDataBound);
            //    dgrDaGuiDanhGia.DataBind();

            //    if (dtUsersDaGuiDanhGia != null)
            //    {
            //        lblTotalTopDaGuiDanhGia.Text = dtUsersDaGuiDanhGia.Rows.Count.ToString();//lblTotalBottomDaGuiDanhGia.Text = 
            //    }

            //    #endregion

            //    #region Cong Viec Phat Sinh

            //    DataTable dtUsersCongViecPhatSinh;

            //    if (CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiHoTro || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiKinhDoanh)
            //    {
            //        dtUsersCongViecPhatSinh = UserController.GetUsersPhatSinhCongViecTheoThang(CurrentUser.UserID, CurrentUser.IDTrungTam, idDotDanhGia, (int)Constants.ChucVu.TruongBoPhan);
            //    }
            //    else
            //    {
            //        dtUsersCongViecPhatSinh = UserController.GetUsersPhatSinhCongViecTheoThang(CurrentUser.UserID, CurrentUser.IDTrungTam, idDotDanhGia, (int)Constants.ChucVu.TruongPhong);
            //    }
            //    //-------sort----------
            //    DataView dvCongViecPhatSinh = new DataView(dtUsersCongViecPhatSinh);
            //    if (ViewState["sortExpressionDaGuiDanhGia"] != null && ViewState["sortExpressionChuaGuiKeHoach"].ToString() != string.Empty)
            //    {
            //        dvDaGuiDanhGia.Sort = ViewState["sortExpressionDaGuiDanhGia"].ToString();
            //    }


            //    if (ViewState["sortDirectionDaGuiDanhGia"] != null && ViewState["sortDirectionDaGuiDanhGia"].ToString() == "Desc")
            //    {
            //        dvDaGuiDanhGia.Sort = ViewState["sortExpressionDaGuiDanhGia"].ToString() + " " + ViewState["sortDirectionDaGuiDanhGia"].ToString();
            //    }
            //    //--------sort-------------

            //    dgrCongViecPhatSinh.DataSource = dvCongViecPhatSinh;
            //    dgrCongViecPhatSinh.RowDataBound += new GridViewRowEventHandler(dgrCongViecPhatSinh_RowDataBound);
            //    dgrCongViecPhatSinh.DataBind();

            //    if (dtUsersCongViecPhatSinh != null)
            //    {
            //        lblTotalTopCongViecPhatSinh.Text = dtUsersCongViecPhatSinh.Rows.Count.ToString();//lblTotalBottomCongViecPhatSinh.Text =
            //    }

            //    #endregion

            //}
            //else if (CurrentUser.RoleID == (int)Constants.Role.CEO || CurrentUser.RoleID == (int)Constants.Role.COO)
            //{
            //    pnlTBP_TP.Visible = false;

            //    #region BoPhan Chua Gui Ke Hoạch

            //    DataTable dtBoPhanChuaGuiKeHoach = null;

            //    dtBoPhanChuaGuiKeHoach = BoPhanController.GetAllWithTrangThai(idDotDanhGia, (int)Constants.TrangThaiDanhGia.LapKeHoach);

            //    //-------sort----------
            //    DataView dv = new DataView(dtBoPhanChuaGuiKeHoach);
            //    if (ViewState["sortExpressionBoPhanChuaGuiKeHoach"] != null && ViewState["sortExpressionBoPhanChuaGuiKeHoach"].ToString() != string.Empty)
            //    {
            //        dv.Sort = ViewState["sortExpressionBoPhanChuaGuiKeHoach"].ToString();
            //    }


            //    if (ViewState["sortDirectionBoPhanChuaGuiKeHoach"] != null && ViewState["sortDirectionBoPhanChuaGuiKeHoach"].ToString() == "Desc")
            //    {
            //        dv.Sort = ViewState["sortExpressionBoPhanChuaGuiKeHoach"].ToString() + " " + ViewState["sortDirectionBoPhanChuaGuiKeHoach"].ToString();
            //    }
            //    //--------sort-------------

            //    dgrBoPhanChuaGuiKeHoach.DataSource = dv;
            //    dgrBoPhanChuaGuiKeHoach.RowDataBound += new GridViewRowEventHandler(dgrChuaGuiKeHoach_RowDataBound);
            //    dgrBoPhanChuaGuiKeHoach.DataBind();

            //    if (dtBoPhanChuaGuiKeHoach != null)
            //    {
            //        lblTotalBoPhanChuaGuiKeHoachTop.Text = dtBoPhanChuaGuiKeHoach.Rows.Count.ToString();//lblTotalBoPhanChuaGuiKeHoachBottom.Text =
            //    }

            //    #endregion

            //    #region BoPhan Da gui ke hoach

            //    DataTable dtBoPhanDaGuiKeHoach = null;

            //    dtBoPhanDaGuiKeHoach = BoPhanController.GetAllWithTrangThai(idDotDanhGia, (int)Constants.TrangThaiDanhGia.DangDanhGia);

            //    //-------sort----------
            //    dv = new DataView(dtBoPhanDaGuiKeHoach);
            //    if (ViewState["sortExpressionDaGuiKeHoach"] != null && ViewState["sortExpressionBoPhanDaGuiKeHoach"].ToString() != string.Empty)
            //    {
            //        dv.Sort = ViewState["sortExpressionBoPhanDaGuiKeHoach"].ToString();
            //    }


            //    if (ViewState["sortDirectionBoPhanDaGuiKeHoach"] != null && ViewState["sortDirectionBoPhanDaGuiKeHoach"].ToString() == "Desc")
            //    {
            //        dv.Sort = ViewState["sortExpressionBoPhanDaGuiKeHoach"].ToString() + " " + ViewState["sortDirectionBoPhanDaGuiKeHoach"].ToString();
            //    }
            //    //--------sort-------------

            //    dgrBoPhanDaGuiKeHoach.DataSource = dv;
            //    dgrBoPhanDaGuiKeHoach.RowDataBound += new GridViewRowEventHandler(dgrBoPhanDaGuiKeHoach_RowDataBound);
            //    dgrBoPhanDaGuiKeHoach.DataBind();

            //    if (dtBoPhanDaGuiKeHoach != null)
            //    {
            //        lblTotalBoPhanDaGuiDanhGiaTop.Text = lblTotalBoPhanDaGuiKeHoachBottom.Text = dtBoPhanDaGuiKeHoach.Rows.Count.ToString();
            //    }

            //    #endregion

            //    #region BoPhan Chua gui danh gia

            //    DataTable dtBoPhanChuaGuiDanhGia = null;

            //    dtBoPhanChuaGuiDanhGia = BoPhanController.GetAllWithTrangThai(idDotDanhGia, (int)Constants.TrangThaiDanhGia.DangDanhGia);

            //    //-------sort----------
            //    DataView dvBoPhanChuaGuiDanhGia = new DataView(dtBoPhanChuaGuiDanhGia);
            //    if (ViewState["sortExpressionChuaGuiDanhGia"] != null && ViewState["sortExpressionChuaGuiKeHoach"].ToString() != string.Empty)
            //    {
            //        dvBoPhanChuaGuiDanhGia.Sort = ViewState["sortExpressionBoPhanChuaGuiDanhGia"].ToString();
            //    }


            //    if (ViewState["sortDirectionBoPhanChuaGuiDanhGia"] != null && ViewState["sortDirectionBoPhanChuaGuiDanhGia"].ToString() == "Desc")
            //    {
            //        dvBoPhanChuaGuiDanhGia.Sort = ViewState["sortExpressionBoPhanChuaGuiDanhGia"].ToString() + " " + ViewState["sortDirectionBoPhanChuaGuiDanhGia"].ToString();
            //    }
            //    //--------sort-------------

            //    dgrBoPhanChuaGuiDanhGia.DataSource = dvBoPhanChuaGuiDanhGia;
            //    dgrBoPhanChuaGuiDanhGia.RowDataBound += new GridViewRowEventHandler(dgrBoPhanChuaGuiKeHoach_RowDataBound);
            //    dgrBoPhanChuaGuiDanhGia.DataBind();

            //    if (dtBoPhanChuaGuiDanhGia != null)
            //    {
            //        lblTotalBoPhanChuaGuiDanhGiaTop.Text = lblTotalBoPhanChuaGuiDanhGiaBottom.Text = dtBoPhanChuaGuiDanhGia.Rows.Count.ToString();
            //    }

            //    #endregion

            //    #region BoPhan Da gui danh gia

            //    DataTable dtBoPhanDaGuiDanhGia = null;

            //    dtBoPhanChuaGuiDanhGia = BoPhanController.GetAllWithTrangThai(idDotDanhGia, (int)Constants.TrangThaiDanhGia.DaGuiChoPhuTrachDanhGia);

            //    //-------sort----------
            //    DataView dvBoPhanDaGuiDanhGia = new DataView(dtBoPhanDaGuiDanhGia);
            //    if (ViewState["sortExpressionBoPhanDaGuiDanhGia"] != null && ViewState["sortExpressionBoPhanChuaGuiKeHoach"].ToString() != string.Empty)
            //    {
            //        dvBoPhanDaGuiDanhGia.Sort = ViewState["sortExpressionBoPhanDaGuiDanhGia"].ToString();
            //    }


            //    if (ViewState["sortDirectionBoPhanDaGuiDanhGia"] != null && ViewState["sortDirectionBoPhanDaGuiDanhGia"].ToString() == "Desc")
            //    {
            //        dvBoPhanDaGuiDanhGia.Sort = ViewState["sortExpressionBoPhanDaGuiDanhGia"].ToString() + " " + ViewState["sortDirectionBoPhanDaGuiDanhGia"].ToString();
            //    }
            //    //--------sort-------------

            //    dgrBoPhanDaGuiDanhGia.DataSource = dvBoPhanDaGuiDanhGia;
            //    dgrBoPhanDaGuiDanhGia.RowDataBound += new GridViewRowEventHandler(dgrBoPhanChuaGuiKeHoach_RowDataBound);
            //    dgrBoPhanDaGuiDanhGia.DataBind();

            //    if (dtBoPhanDaGuiDanhGia != null)
            //    {
            //        lblTotalTopDaGuiDanhGia.Text = dtBoPhanDaGuiDanhGia.Rows.Count.ToString();//lblTotalBottomDaGuiDanhGia.Text = 
            //    }

            //    #endregion
            //}
            //else
            //{
            //    pnlTBP_TP.Visible = false;
            //    pnlCOO_CEO.Visible = false;
            //}

            //#region Công việc đến hạn deadline

            //DataTable dtCVDHHT = QuanLyCongViecKTXVaPSController.GetAllCongViecDenHanDeadline(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), CurrentUser.IDTrungTam);
            //dgrCVDHHT.DataSource = dtCVDHHT;
            //dgrCVDHHT.RowDataBound += new GridViewRowEventHandler(dgrCVDHHT_RowDataBound);
            //dgrCVDHHT.DataBind();

            //lblTotalCVDHHT.Text = dtCVDHHT.Rows.Count.ToString();

            //#endregion

            //#region Công việc đến hạn deadline

            //DataTable dtCVQHHT = QuanLyCongViecKTXVaPSController.GetAllCongViecQuaHanDeadline(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), CurrentUser.IDTrungTam);
            //dgrCVQHHT.DataSource = dtCVQHHT;
            //dgrCVQHHT.RowDataBound += new GridViewRowEventHandler(dgrCVQHHT_RowDataBound);
            //dgrCVQHHT.DataBind();

            //lblTotalCVQHHT.Text = dtCVQHHT.Rows.Count.ToString();

            //#endregion

            //#region ty trong cong viec nhan vien

            //DataTable dtTyTrongNhanVien = new DataTable();

            //dtTyTrongNhanVien.Columns.Add("HoTen", typeof(String));
            //dtTyTrongNhanVien.Columns.Add("ChucVu", typeof(String));
            //dtTyTrongNhanVien.Columns.Add("TTCVThuongXuyen", typeof(String));
            //dtTyTrongNhanVien.Columns.Add("TTCVKeHoachThang", typeof(String));
            //dtTyTrongNhanVien.Columns.Add("TTCVPhatSinh", typeof(String));
            //dtTyTrongNhanVien.Columns.Add("TTConLai", typeof(String));
            //dtTyTrongNhanVien.Columns.Add("Tong", typeof(String));

            //DataTable dtNhanVien = DotDanhGiaController.GetAllNhanVien(CurrentUser.IDTrungTam, 0);

            //if (dtNhanVien == null) return;

            //foreach (DataRow itemNhanVien in dtNhanVien.Rows)
            //{
            //    DataRow row = dtTyTrongNhanVien.NewRow();

            //    #region Ty Trong Cong Viec

            //    double totalCVTX = 0;
            //    double totalCVKTX = 0;
            //    double totalCVPS = 0;
            //    double total = 0;

            //    int idNhanVien = ConvertUtility.ToInt32(itemNhanVien["UserID"]);

            //    int SoNguoiTrungTam = 1;
            //    string HoTen = "";
            //    string ChucVu = "";

            //    DataTable dtUserInfo = DotDanhGiaController.GetUserInfo(idNhanVien);

            //    if (dtUserInfo != null && dtUserInfo.Rows.Count > 0)
            //    {
            //        HoTen = dtUserInfo.Rows[0]["HoTen"].ToString();
            //        ChucVu = dtUserInfo.Rows[0]["ChucVu"].ToString();
            //        SoNguoiTrungTam = ConvertUtility.ToInt32(dtUserInfo.Rows[0]["SoNguoiTrungTam"].ToString());
            //    }

            //    DataTable dtCongViecThuongXuyen = DanhGiaThang_DGCBCNVDanhGiaTTCVController.GetAll(1, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), idNhanVien);

            //    foreach (DataRow item in dtCongViecThuongXuyen.Rows)
            //    {
            //        totalCVTX += ConvertUtility.ToDouble(item["TyTrongCV"]);
            //    }

            //    DataTable dtCongViecKhongThuonguyen = DanhGiaThang_DGCBCNVDanhGiaTTCVController.GetAll(2, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), idNhanVien);
            //    foreach (DataRow item in dtCongViecKhongThuonguyen.Rows)
            //    {
            //        totalCVKTX += ConvertUtility.ToDouble(item["TyTrongCV"]);
            //    }

            //    DataTable dtCongViecPhatSinh = DanhGiaThang_DGCBCNVDanhGiaTTCVController.GetAll(3, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), idNhanVien);
            //    foreach (DataRow item in dtCongViecPhatSinh.Rows)
            //    {
            //        totalCVPS += ConvertUtility.ToDouble(item["TyTrongCV"]);
            //    }
            //    row["HoTen"] = HoTen;
            //    row["ChucVu"] = ChucVu;
            //    row["TTCVThuongXuyen"] = Math.Round(totalCVTX, 2) + "%";
            //    row["TTCVKeHoachThang"] = Math.Round(totalCVKTX,2) + "%";
            //    row["TTCVPhatSinh"] = Math.Round(totalCVPS,2) + "%";

            //    total = totalCVTX + totalCVKTX + totalCVPS;

            //    double totalCVPhatSinh = Math.Round((100 - total), 2);

            //    if (totalCVPhatSinh > 0)
            //    {
            //        row["TTConLai"] = Math.Round((100 - total), 2) + "%";
            //    }
            //    else
            //    {
            //        row["TTConLai"] = "0%";
            //    }

            //    if (total > 100)
            //    {
            //        row["Tong"] = "<b style=\"color:red\">" + Math.Round(total,2) + "%</b>";
            //    }
            //    else
            //    {
            //        row["Tong"] = Math.Round(total,2) + "%";
            //    }
            //    dtTyTrongNhanVien.Rows.Add(row);

            //    #endregion
            //}

            //dgrTyTrongNhanVien.DataSource = dtTyTrongNhanVien;
            //dgrTyTrongNhanVien.RowDataBound += new GridViewRowEventHandler(dgrTyTrongNhanVien_RowDataBound);
            //dgrTyTrongNhanVien.DataBind();


            //lblTongSoNhanVien.Text = dtTyTrongNhanVien.Rows.Count.ToString();

            //#endregion

            //#region Công việc trong tuan
            ////DateConverter objDate = new DateConverter();
            ////int tuan = objDate.GetWeekOfMonth(DateTime.Now);
            //DataTable dtCVTT = QuanLyCongViecKTXVaPSController.GetAllCongViecTrongTuan(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), CurrentUser.IDTrungTam, ConvertUtility.ToInt32(dropTuan.SelectedValue));
            //dgrCVTT.DataSource = dtCVTT;
            //dgrCVTT.RowDataBound += new GridViewRowEventHandler(dgrCVTT_RowDataBound);
            //dgrCVTT.DataBind();

            //lblTotalCVTT.Text = dtCVTT.Rows.Count.ToString();

            //#endregion
        }

        //void dgrCVTT_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (e.Row.RowIndex == 0)
        //            e.Row.Style.Add("height", "50px");

        //        e.Row.Cells[0].Text = Convert.ToString(e.Row.DataItemIndex + 1);

        //        DataRowView curData = (DataRowView)e.Row.DataItem;

        //        if (e.Row.RowState == DataControlRowState.Alternate)
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffffdd';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff';");
        //        }
        //        else
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffffdd';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#f3f8ef';");
        //        }
        //    }
        //}

        //void dgrTyTrongNhanVien_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Cells[0].Text = Convert.ToString(e.Row.DataItemIndex + 1);

        //        DataRowView curData = (DataRowView)e.Row.DataItem;

        //        if (e.Row.RowState == DataControlRowState.Alternate)
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffffdd';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff';");
        //        }
        //        else
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffffdd';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#f3f8ef';");
        //        }
        //    }
        //}

        //void dgrCVQHHT_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Cells[0].Text = Convert.ToString(e.Row.DataItemIndex + 1);

        //        DataRowView curData = (DataRowView)e.Row.DataItem;

        //        if (e.Row.RowState == DataControlRowState.Alternate)
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffffdd';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff';");
        //        }
        //        else
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffffdd';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#f3f8ef';");
        //        }
        //    }
        //}

        //void dgrCVDHHT_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Cells[0].Text = Convert.ToString(e.Row.DataItemIndex + 1);

        //        DataRowView curData = (DataRowView)e.Row.DataItem;

        //        if (e.Row.RowState == DataControlRowState.Alternate)
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffffdd';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff';");
        //        }
        //        else
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffffdd';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#f3f8ef';");
        //        }
        //    }
        //}

        //protected void dropDotDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Response.Redirect(AppEnv.AdminUrlParams("") + "&idDotDanhGia=" + dropDotDanhGia.SelectedValue);
        //}

        #region chua gui ke hoach

        //protected void dgrChuaGuiKeHoach_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    if (ViewState["sortDirectionChuaGuiKeHoach"] == null || ViewState["sortDirectionChuaGuiKeHoach"].ToString() == "")
        //    {
        //        ViewState["sortDirectionChuaGuiKeHoach"] = "Desc";
        //    }
        //    else if (ViewState["sortDirectionChuaGuiKeHoach"].ToString() == "Desc")
        //    {
        //        ViewState["sortDirectionChuaGuiKeHoach"] = "";
        //    }
        //    ViewState["sortExpressionChuaGuiKeHoach"] = e.SortExpression;

        //}
        //protected void dgrChuaGuiKeHoach_PreRender(object sender, EventArgs e)
        //{
        //    if (dgrChuaGuiKeHoach.BottomPagerRow != null)
        //    {
        //        ((Label)dgrChuaGuiKeHoach.BottomPagerRow.FindControl("lbTotalPagesChuaGuiKeHoach")).Text = dgrChuaGuiKeHoach.PageCount.ToString();

        //        //This makes the first and last button disappear when on the first and last pages.
        //        ((LinkButton)dgrChuaGuiKeHoach.BottomPagerRow.FindControl("lbtnFirstChuaGuiKeHoach")).Visible = dgrChuaGuiKeHoach.PageIndex != 0;
        //        ((LinkButton)dgrChuaGuiKeHoach.BottomPagerRow.FindControl("lbtnLastChuaGuiKeHoach")).Visible = dgrChuaGuiKeHoach.PageCount != (dgrChuaGuiKeHoach.PageIndex + 1);

        //        DropDownList ddlistPageof = (DropDownList)dgrChuaGuiKeHoach.BottomPagerRow.FindControl("ddlPageItemsChuaGuiKeHoach");
        //        ddlistPageof.SelectedIndex = ddlistPageof.Items.IndexOf(ddlistPageof.Items.FindByValue(ViewState["DropDownPageItemsChuaGuiKeHoach"].ToString()));
        //        DropDownList ddlistPageno = (DropDownList)dgrChuaGuiKeHoach.BottomPagerRow.FindControl("ddlNumberPagesChuaGuiKeHoach");
        //        ddlistPageno.Items.Clear();
        //        for (int i = 1; i <= dgrChuaGuiKeHoach.PageCount; i++)
        //        {
        //            ListItem liTemp = new ListItem();
        //            liTemp.Text = i.ToString();
        //            liTemp.Value = i.ToString();
        //            ddlistPageno.Items.Add(liTemp);
        //        }
        //        if (dgrChuaGuiKeHoach.PageCount != 0)
        //        {
        //            ddlistPageno.SelectedIndex = dgrChuaGuiKeHoach.PageIndex;
        //            ddlistPageno.DataBind();
        //        }
        //    }
        //}
        //protected void dgrChuaGuiKeHoach_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (e.Row.RowState == DataControlRowState.Alternate)
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#f7fff8';");
        //        }
        //        else
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#eefef0';");
        //        }

        //    }
        //}
        //protected void ddlNumberPagesChuaGuiKeHoach_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DropDownList ddlistPagenoChuaGuiKeHoach = (DropDownList)dgrChuaGuiKeHoach.BottomPagerRow.FindControl("ddlNumberPagesChuaGuiKeHoach");
        //    dgrChuaGuiKeHoach.PageIndex = Convert.ToInt32(ddlistPagenoChuaGuiKeHoach.SelectedValue) - 1;

        //}
        //protected void dgrChuaGuiKeHoach_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    dgrChuaGuiKeHoach.PageIndex = e.NewPageIndex;
        //}
        //protected void ddlPageItemsChuaGuiKeHoach_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int pageItems = Convert.ToInt32(((DropDownList)sender).SelectedValue);
        //    this.dgrChuaGuiKeHoach.PageSize = pageItems;
        //    ViewState["DropDownPageItemsChuaGuiKeHoach"] = pageItems;
        //}
        //protected void dgrChuaGuiKeHoach_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "mail")
        //    {
        //        string lblMail = e.CommandArgument.ToString();

        //        bool value = EmailUtility.DoSendMail(lblMail, "", "Mail nhắc nhở gửi kế hoạch", "Yêu cầu bạn hoàn thiện kế hoạch công việc tháng và gửi lại trong ngày hôm nay.");

        //    }
        //}

        #endregion

        #region da gui ke hoach

        //protected void dgrDaGuiKeHoach_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    if (ViewState["sortDirectionDaGuiKeHoach"] == null || ViewState["sortDirectionDaGuiKeHoach"].ToString() == "")
        //    {
        //        ViewState["sortDirectionDaGuiKeHoach"] = "Desc";
        //    }
        //    else if (ViewState["sortDirectionDaGuiKeHoach"].ToString() == "Desc")
        //    {
        //        ViewState["sortDirectionDaGuiKeHoach"] = "";
        //    }
        //    ViewState["sortExpressionDaGuiKeHoach"] = e.SortExpression;

        //}
        //protected void dgrDaGuiKeHoach_PreRender(object sender, EventArgs e)
        //{
        //    if (dgrDaGuiKeHoach.BottomPagerRow != null)
        //    {
        //        ((Label)dgrDaGuiKeHoach.BottomPagerRow.FindControl("lbTotalPagesDaGuiKeHoach")).Text = dgrDaGuiKeHoach.PageCount.ToString();

        //        //This makes the first and last button disappear when on the first and last pages.
        //        ((LinkButton)dgrDaGuiKeHoach.BottomPagerRow.FindControl("lbtnFirstDaGuiKeHoach")).Visible = dgrDaGuiKeHoach.PageIndex != 0;
        //        ((LinkButton)dgrDaGuiKeHoach.BottomPagerRow.FindControl("lbtnLastDaGuiKeHoach")).Visible = dgrDaGuiKeHoach.PageCount != (dgrDaGuiKeHoach.PageIndex + 1);

        //        DropDownList ddlistPageof = (DropDownList)dgrDaGuiKeHoach.BottomPagerRow.FindControl("ddlPageItemsDaGuiKeHoach");
        //        ddlistPageof.SelectedIndex = ddlistPageof.Items.IndexOf(ddlistPageof.Items.FindByValue(ViewState["DropDownPageItemsDaGuiKeHoach"].ToString()));
        //        DropDownList ddlistPageno = (DropDownList)dgrDaGuiKeHoach.BottomPagerRow.FindControl("ddlNumberPagesDaGuiKeHoach");
        //        ddlistPageno.Items.Clear();
        //        for (int i = 1; i <= dgrDaGuiKeHoach.PageCount; i++)
        //        {
        //            ListItem liTemp = new ListItem();
        //            liTemp.Text = i.ToString();
        //            liTemp.Value = i.ToString();
        //            ddlistPageno.Items.Add(liTemp);
        //        }
        //        if (dgrDaGuiKeHoach.PageCount != 0)
        //        {
        //            ddlistPageno.SelectedIndex = dgrDaGuiKeHoach.PageIndex;
        //            ddlistPageno.DataBind();
        //        }
        //    }
        //}
        //protected void dgrDaGuiKeHoach_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        //Button btnDanhGia = (Button)e.Row.FindControl("btnDanhGia");

        //        //Label lblTrangThai = (Label)e.Row.FindControl("lblTrangThai");

        //        if (e.Row.RowState == DataControlRowState.Alternate)
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#f7fff8';");
        //        }
        //        else
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#eefef0';");
        //        }
        //    }
        //}
        //protected void ddlNumberPagesDaGuiKeHoach_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DropDownList ddlistPagenoDaGuiKeHoach = (DropDownList)dgrDaGuiKeHoach.BottomPagerRow.FindControl("ddlNumberPagesDaGuiKeHoach");
        //    dgrDaGuiKeHoach.PageIndex = Convert.ToInt32(ddlistPagenoDaGuiKeHoach.SelectedValue) - 1;

        //}
        //protected void dgrDaGuiKeHoach_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    dgrDaGuiKeHoach.PageIndex = e.NewPageIndex;
        //}
        //protected void ddlPageItemsDaGuiKeHoach_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int pageItems = Convert.ToInt32(((DropDownList)sender).SelectedValue);
        //    this.dgrDaGuiKeHoach.PageSize = pageItems;
        //    ViewState["DropDownPageItemsDaGuiKeHoach"] = pageItems;
        //}
        //protected void dgrDaGuiKeHoach_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    int idNhanVien = ConvertUtility.ToInt32(e.CommandArgument);
        //    Response.Redirect(AppEnv.AdminUrlParams("kehoachthang_nhanvien") + "&idDotDanhGia=" + dropDotDanhGia.SelectedValue + "&idNhanVien=" + idNhanVien);
        //}

        #endregion

        #region Chua Gui Danh Gia

        //protected void dgrChuaGuiDanhGia_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    if (ViewState["sortDirectionChuaGuiDanhGia"] == null || ViewState["sortDirectionChuaGuiDanhGia"].ToString() == "")
        //    {
        //        ViewState["sortDirectionChuaGuiDanhGia"] = "Desc";
        //    }
        //    else if (ViewState["sortDirectionChuaGuiDanhGia"].ToString() == "Desc")
        //    {
        //        ViewState["sortDirectionChuaGuiDanhGia"] = "";
        //    }
        //    ViewState["sortExpressionChuaGuiDanhGia"] = e.SortExpression;

        //}
        //protected void dgrChuaGuiDanhGia_PreRender(object sender, EventArgs e)
        //{
        //    if (dgrChuaGuiDanhGia.BottomPagerRow != null)
        //    {
        //        ((Label)dgrChuaGuiDanhGia.BottomPagerRow.FindControl("lbTotalPagesChuaGuiDanhGia")).Text = dgrChuaGuiDanhGia.PageCount.ToString();

        //        //This makes the first and last button disappear when on the first and last pages.
        //        ((LinkButton)dgrChuaGuiDanhGia.BottomPagerRow.FindControl("lbtnFirstChuaGuiDanhGia")).Visible = dgrChuaGuiDanhGia.PageIndex != 0;
        //        ((LinkButton)dgrChuaGuiDanhGia.BottomPagerRow.FindControl("lbtnLastChuaGuiDanhGia")).Visible = dgrChuaGuiDanhGia.PageCount != (dgrChuaGuiDanhGia.PageIndex + 1);

        //        DropDownList ddlistPageof = (DropDownList)dgrChuaGuiDanhGia.BottomPagerRow.FindControl("ddlPageItemsChuaGuiDanhGia");
        //        ddlistPageof.SelectedIndex = ddlistPageof.Items.IndexOf(ddlistPageof.Items.FindByValue(ViewState["DropDownPageItemsChuaGuiDanhGia"].ToString()));
        //        DropDownList ddlistPageno = (DropDownList)dgrChuaGuiDanhGia.BottomPagerRow.FindControl("ddlNumberPagesChuaGuiDanhGia");
        //        ddlistPageno.Items.Clear();
        //        for (int i = 1; i <= dgrChuaGuiDanhGia.PageCount; i++)
        //        {
        //            ListItem liTemp = new ListItem();
        //            liTemp.Text = i.ToString();
        //            liTemp.Value = i.ToString();
        //            ddlistPageno.Items.Add(liTemp);
        //        }
        //        if (dgrChuaGuiDanhGia.PageCount != 0)
        //        {
        //            ddlistPageno.SelectedIndex = dgrChuaGuiDanhGia.PageIndex;
        //            ddlistPageno.DataBind();
        //        }
        //    }
        //}
        //protected void dgrChuaGuiDanhGia_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        //Button btnDanhGia = (Button)e.Row.FindControl("btnDanhGia");

        //        //Label lblTrangThai = (Label)e.Row.FindControl("lblTrangThai");

        //        if (e.Row.RowState == DataControlRowState.Alternate)
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#f7fff8';");
        //        }
        //        else
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#eefef0';");
        //        }
        //    }
        //}
        //protected void ddlNumberPagesChuaGuiDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DropDownList ddlistPagenoChuaGuiDanhGia = (DropDownList)dgrChuaGuiDanhGia.BottomPagerRow.FindControl("ddlNumberPagesChuaGuiDanhGia");
        //    dgrChuaGuiDanhGia.PageIndex = Convert.ToInt32(ddlistPagenoChuaGuiDanhGia.SelectedValue) - 1;

        //}
        //protected void dgrChuaGuiDanhGia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    dgrChuaGuiDanhGia.PageIndex = e.NewPageIndex;
        //}
        //protected void ddlPageItemsChuaGuiDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int pageItems = Convert.ToInt32(((DropDownList)sender).SelectedValue);
        //    this.dgrChuaGuiDanhGia.PageSize = pageItems;
        //    ViewState["DropDownPageItemsChuaGuiDanhGia"] = pageItems;
        //}
        //protected void dgrChuaGuiDanhGia_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "mail")
        //    {
        //        string lblMail = e.CommandArgument.ToString();

        //        bool value = EmailUtility.DoSendMail(lblMail, "", "Mail nhắc nhở gửi bản đánh giá", "Yêu cầu bạn hoàn thiện bản đánh giá tháng và gửi lại trong ngày hôm nay.");

        //    }
        //}

        #endregion

        #region Da Gui Danh Gia

        //protected void dgrDaGuiDanhGia_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    if (ViewState["sortDirectionDaGuiDanhGia"] == null || ViewState["sortDirectionDaGuiDanhGia"].ToString() == "")
        //    {
        //        ViewState["sortDirectionDaGuiDanhGia"] = "Desc";
        //    }
        //    else if (ViewState["sortDirectionDaGuiDanhGia"].ToString() == "Desc")
        //    {
        //        ViewState["sortDirectionDaGuiDanhGia"] = "";
        //    }
        //    ViewState["sortExpressionDaGuiDanhGia"] = e.SortExpression;

        //}
        //protected void dgrDaGuiDanhGia_PreRender(object sender, EventArgs e)
        //{
        //    if (dgrDaGuiDanhGia.BottomPagerRow != null)
        //    {
        //        ((Label)dgrDaGuiDanhGia.BottomPagerRow.FindControl("lbTotalPagesDaGuiDanhGia")).Text = dgrDaGuiDanhGia.PageCount.ToString();

        //        //This makes the first and last button disappear when on the first and last pages.
        //        ((LinkButton)dgrDaGuiDanhGia.BottomPagerRow.FindControl("lbtnFirstDaGuiDanhGia")).Visible = dgrDaGuiDanhGia.PageIndex != 0;
        //        ((LinkButton)dgrDaGuiDanhGia.BottomPagerRow.FindControl("lbtnLastDaGuiDanhGia")).Visible = dgrDaGuiDanhGia.PageCount != (dgrDaGuiDanhGia.PageIndex + 1);

        //        DropDownList ddlistPageof = (DropDownList)dgrDaGuiDanhGia.BottomPagerRow.FindControl("ddlPageItemsDaGuiDanhGia");
        //        ddlistPageof.SelectedIndex = ddlistPageof.Items.IndexOf(ddlistPageof.Items.FindByValue(ViewState["DropDownPageItemsDaGuiDanhGia"].ToString()));
        //        DropDownList ddlistPageno = (DropDownList)dgrDaGuiDanhGia.BottomPagerRow.FindControl("ddlNumberPagesDaGuiDanhGia");
        //        ddlistPageno.Items.Clear();
        //        for (int i = 1; i <= dgrDaGuiDanhGia.PageCount; i++)
        //        {
        //            ListItem liTemp = new ListItem();
        //            liTemp.Text = i.ToString();
        //            liTemp.Value = i.ToString();
        //            ddlistPageno.Items.Add(liTemp);
        //        }
        //        if (dgrDaGuiDanhGia.PageCount != 0)
        //        {
        //            ddlistPageno.SelectedIndex = dgrDaGuiDanhGia.PageIndex;
        //            ddlistPageno.DataBind();
        //        }
        //    }
        //}
        //protected void dgrDaGuiDanhGia_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (e.Row.RowState == DataControlRowState.Alternate)
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#f7fff8';");
        //        }
        //        else
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#eefef0';");
        //        }

        //        DataRowView curData = (DataRowView)e.Row.DataItem;

        //        Button btnXem = (Button)e.Row.FindControl("btnXem");
        //        string url = "window.open('" + AppEnv.AdminUrlParams("ptdanhgianhanvienhangthang") + "&idDotDanhGia=" + curData["IDDotDanhGia"].ToString() + "&idNhanVien=" + curData["UserID"].ToString() + "','_blank'); return false;";
        //        btnXem.OnClientClick = url;
        //    }
        //}
        //protected void ddlNumberPagesDaGuiDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DropDownList ddlistPagenoDaGuiDanhGia = (DropDownList)dgrDaGuiDanhGia.BottomPagerRow.FindControl("ddlNumberPagesDaGuiDanhGia");
        //    dgrDaGuiDanhGia.PageIndex = Convert.ToInt32(ddlistPagenoDaGuiDanhGia.SelectedValue) - 1;

        //}
        //protected void dgrDaGuiDanhGia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    dgrDaGuiDanhGia.PageIndex = e.NewPageIndex;
        //}
        //protected void ddlPageItemsDaGuiDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int pageItems = Convert.ToInt32(((DropDownList)sender).SelectedValue);
        //    this.dgrDaGuiDanhGia.PageSize = pageItems;
        //    ViewState["DropDownPageItemsDaGuiDanhGia"] = pageItems;
        //}
        //protected void dgrDaGuiDanhGia_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    int idNhanVien = ConvertUtility.ToInt32(e.CommandArgument);
        //    Response.Redirect(AppEnv.AdminUrlParams("ptdanhgianhanvienhangthang") + "&idDotDanhGia=" + dropDotDanhGia.SelectedValue + "&idNhanVien=" + idNhanVien);
        //}

        #endregion

        #region Cong Viec Phat Sinh

        //protected void dgrCongViecPhatSinh_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    if (ViewState["sortDirectionCongViecPhatSinh"] == null || ViewState["sortDirectionCongViecPhatSinh"].ToString() == "")
        //    {
        //        ViewState["sortDirectionCongViecPhatSinh"] = "Desc";
        //    }
        //    else if (ViewState["sortDirectionCongViecPhatSinh"].ToString() == "Desc")
        //    {
        //        ViewState["sortDirectionCongViecPhatSinh"] = "";
        //    }
        //    ViewState["sortExpressionCongViecPhatSinh"] = e.SortExpression;

        //}
        //protected void dgrCongViecPhatSinh_PreRender(object sender, EventArgs e)
        //{
        //    if (dgrCongViecPhatSinh.BottomPagerRow != null)
        //    {
        //        ((Label)dgrCongViecPhatSinh.BottomPagerRow.FindControl("lbTotalPagesCongViecPhatSinh")).Text = dgrCongViecPhatSinh.PageCount.ToString();

        //        //This makes the first and last button disappear when on the first and last pages.
        //        ((LinkButton)dgrCongViecPhatSinh.BottomPagerRow.FindControl("lbtnFirstCongViecPhatSinh")).Visible = dgrCongViecPhatSinh.PageIndex != 0;
        //        ((LinkButton)dgrCongViecPhatSinh.BottomPagerRow.FindControl("lbtnLastCongViecPhatSinh")).Visible = dgrCongViecPhatSinh.PageCount != (dgrCongViecPhatSinh.PageIndex + 1);

        //        DropDownList ddlistPageof = (DropDownList)dgrCongViecPhatSinh.BottomPagerRow.FindControl("ddlPageItemsCongViecPhatSinh");
        //        ddlistPageof.SelectedIndex = ddlistPageof.Items.IndexOf(ddlistPageof.Items.FindByValue(ViewState["DropDownPageItemsCongViecPhatSinh"].ToString()));
        //        DropDownList ddlistPageno = (DropDownList)dgrCongViecPhatSinh.BottomPagerRow.FindControl("ddlNumberPagesCongViecPhatSinh");
        //        ddlistPageno.Items.Clear();
        //        for (int i = 1; i <= dgrCongViecPhatSinh.PageCount; i++)
        //        {
        //            ListItem liTemp = new ListItem();
        //            liTemp.Text = i.ToString();
        //            liTemp.Value = i.ToString();
        //            ddlistPageno.Items.Add(liTemp);
        //        }
        //        if (dgrCongViecPhatSinh.PageCount != 0)
        //        {
        //            ddlistPageno.SelectedIndex = dgrCongViecPhatSinh.PageIndex;
        //            ddlistPageno.DataBind();
        //        }
        //    }
        //}
        //protected void dgrCongViecPhatSinh_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (e.Row.RowState == DataControlRowState.Alternate)
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#f7fff8';");
        //        }
        //        else
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#eefef0';");
        //        }

        //        DataRowView curData = (DataRowView)e.Row.DataItem;

        //        Button btnXem = (Button)e.Row.FindControl("btnXem");
        //        string url = "window.open('" + AppEnv.AdminUrlParams("ptdanhgianhanvienhangthang") + "&idDotDanhGia=" + curData["IDDotDanhGia"].ToString() + "&idNhanVien=" + curData["UserID"].ToString() + "','_blank'); return false;";
        //        btnXem.OnClientClick = url;
        //    }
        //}
        //protected void ddlNumberPagesCongViecPhatSinh_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DropDownList ddlistPagenoCongViecPhatSinh = (DropDownList)dgrCongViecPhatSinh.BottomPagerRow.FindControl("ddlNumberPagesCongViecPhatSinh");
        //    dgrCongViecPhatSinh.PageIndex = Convert.ToInt32(ddlistPagenoCongViecPhatSinh.SelectedValue) - 1;

        //}
        //protected void dgrCongViecPhatSinh_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    dgrCongViecPhatSinh.PageIndex = e.NewPageIndex;
        //}
        //protected void ddlPageItemsCongViecPhatSinh_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int pageItems = Convert.ToInt32(((DropDownList)sender).SelectedValue);
        //    this.dgrCongViecPhatSinh.PageSize = pageItems;
        //    ViewState["DropDownPageItemsCongViecPhatSinh"] = pageItems;
        //}
        //protected void dgrCongViecPhatSinh_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //}

        #endregion

        #region BoPhan chua gui ke hoach

        //protected void dgrBoPhanChuaGuiKeHoach_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    if (ViewState["sortDirectionBoPhanChuaGuiKeHoach"] == null || ViewState["sortDirectionBoPhanChuaGuiKeHoach"].ToString() == "")
        //    {
        //        ViewState["sortDirectionBoPhanChuaGuiKeHoach"] = "Desc";
        //    }
        //    else if (ViewState["sortDirectionBoPhanChuaGuiKeHoach"].ToString() == "Desc")
        //    {
        //        ViewState["sortDirectionBoPhanChuaGuiKeHoach"] = "";
        //    }
        //    ViewState["sortExpressionBoPhanChuaGuiKeHoach"] = e.SortExpression;

        //}
        //protected void dgrBoPhanChuaGuiKeHoach_PreRender(object sender, EventArgs e)
        //{
        //    if (dgrBoPhanChuaGuiKeHoach.BottomPagerRow != null)
        //    {
        //        ((Label)dgrBoPhanChuaGuiKeHoach.BottomPagerRow.FindControl("lbTotalPagesBoPhanChuaGuiKeHoach")).Text = dgrBoPhanChuaGuiKeHoach.PageCount.ToString();

        //        //This makes the first and last button disappear when on the first and last pages.
        //        ((LinkButton)dgrBoPhanChuaGuiKeHoach.BottomPagerRow.FindControl("lbtnFirstBoPhanChuaGuiKeHoach")).Visible = dgrBoPhanChuaGuiKeHoach.PageIndex != 0;
        //        ((LinkButton)dgrBoPhanChuaGuiKeHoach.BottomPagerRow.FindControl("lbtnLastBoPhanChuaGuiKeHoach")).Visible = dgrBoPhanChuaGuiKeHoach.PageCount != (dgrBoPhanChuaGuiKeHoach.PageIndex + 1);

        //        DropDownList ddlistPageof = (DropDownList)dgrBoPhanChuaGuiKeHoach.BottomPagerRow.FindControl("ddlPageItemsBoPhanChuaGuiKeHoach");
        //        ddlistPageof.SelectedIndex = ddlistPageof.Items.IndexOf(ddlistPageof.Items.FindByValue(ViewState["DropDownPageItemsBoPhanChuaGuiKeHoach"].ToString()));
        //        DropDownList ddlistPageno = (DropDownList)dgrBoPhanChuaGuiKeHoach.BottomPagerRow.FindControl("ddlNumberPagesBoPhanChuaGuiKeHoach");
        //        ddlistPageno.Items.Clear();
        //        for (int i = 1; i <= dgrBoPhanChuaGuiKeHoach.PageCount; i++)
        //        {
        //            ListItem liTemp = new ListItem();
        //            liTemp.Text = i.ToString();
        //            liTemp.Value = i.ToString();
        //            ddlistPageno.Items.Add(liTemp);
        //        }
        //        if (dgrBoPhanChuaGuiKeHoach.PageCount != 0)
        //        {
        //            ddlistPageno.SelectedIndex = dgrBoPhanChuaGuiKeHoach.PageIndex;
        //            ddlistPageno.DataBind();
        //        }
        //    }
        //}
        //protected void dgrBoPhanChuaGuiKeHoach_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (e.Row.RowState == DataControlRowState.Alternate)
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#f7fff8';");
        //        }
        //        else
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#eefef0';");
        //        }
        //    }
        //}
        //protected void ddlNumberPagesBoPhanChuaGuiKeHoach_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DropDownList ddlistPagenoBoPhanChuaGuiKeHoach = (DropDownList)dgrBoPhanChuaGuiKeHoach.BottomPagerRow.FindControl("ddlNumberPagesBoPhanChuaGuiKeHoach");
        //    dgrBoPhanChuaGuiKeHoach.PageIndex = Convert.ToInt32(ddlistPagenoBoPhanChuaGuiKeHoach.SelectedValue) - 1;

        //}
        //protected void dgrBoPhanChuaGuiKeHoach_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    dgrBoPhanChuaGuiKeHoach.PageIndex = e.NewPageIndex;
        //}
        //protected void ddlPageItemsBoPhanChuaGuiKeHoach_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int pageItems = Convert.ToInt32(((DropDownList)sender).SelectedValue);
        //    this.dgrBoPhanChuaGuiKeHoach.PageSize = pageItems;
        //    ViewState["DropDownPageItemsBoPhanChuaGuiKeHoach"] = pageItems;
        //}
        //protected void dgrBoPhanChuaGuiKeHoach_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "mail")
        //    {
        //        string lblMail = e.CommandArgument.ToString();

        //        bool value = EmailUtility.DoSendMail(lblMail, "", "Mail nhắc nhở gửi kế hoạch Bộ phận", "Yêu cầu bạn hoàn thiện kế hoạch công việc tháng của Bộ phận và gửi lại trong ngày hôm nay.");

        //    }
        //}

        #endregion

        #region BoPhan da gui ke hoach

        //protected void dgrBoPhanDaGuiKeHoach_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    if (ViewState["sortDirectionBoPhanDaGuiKeHoach"] == null || ViewState["sortDirectionBoPhanDaGuiKeHoach"].ToString() == "")
        //    {
        //        ViewState["sortDirectionBoPhanDaGuiKeHoach"] = "Desc";
        //    }
        //    else if (ViewState["sortDirectionBoPhanDaGuiKeHoach"].ToString() == "Desc")
        //    {
        //        ViewState["sortDirectionBoPhanDaGuiKeHoach"] = "";
        //    }
        //    ViewState["sortExpressionBoPhanDaGuiKeHoach"] = e.SortExpression;

        //}
        //protected void dgrBoPhanDaGuiKeHoach_PreRender(object sender, EventArgs e)
        //{
        //    if (dgrBoPhanDaGuiKeHoach.BottomPagerRow != null)
        //    {
        //        ((Label)dgrBoPhanDaGuiKeHoach.BottomPagerRow.FindControl("lbTotalPagesBoPhanDaGuiKeHoach")).Text = dgrBoPhanDaGuiKeHoach.PageCount.ToString();

        //        //This makes the first and last button disappear when on the first and last pages.
        //        ((LinkButton)dgrBoPhanDaGuiKeHoach.BottomPagerRow.FindControl("lbtnFirstBoPhanDaGuiKeHoach")).Visible = dgrBoPhanDaGuiKeHoach.PageIndex != 0;
        //        ((LinkButton)dgrBoPhanDaGuiKeHoach.BottomPagerRow.FindControl("lbtnLastBoPhanDaGuiKeHoach")).Visible = dgrBoPhanDaGuiKeHoach.PageCount != (dgrBoPhanDaGuiKeHoach.PageIndex + 1);

        //        DropDownList ddlistPageof = (DropDownList)dgrBoPhanDaGuiKeHoach.BottomPagerRow.FindControl("ddlPageItemsBoPhanDaGuiKeHoach");
        //        ddlistPageof.SelectedIndex = ddlistPageof.Items.IndexOf(ddlistPageof.Items.FindByValue(ViewState["DropDownPageItemsBoPhanDaGuiKeHoach"].ToString()));
        //        DropDownList ddlistPageno = (DropDownList)dgrBoPhanDaGuiKeHoach.BottomPagerRow.FindControl("ddlNumberPagesBoPhanDaGuiKeHoach");
        //        ddlistPageno.Items.Clear();
        //        for (int i = 1; i <= dgrBoPhanDaGuiKeHoach.PageCount; i++)
        //        {
        //            ListItem liTemp = new ListItem();
        //            liTemp.Text = i.ToString();
        //            liTemp.Value = i.ToString();
        //            ddlistPageno.Items.Add(liTemp);
        //        }
        //        if (dgrDaGuiKeHoach.PageCount != 0)
        //        {
        //            ddlistPageno.SelectedIndex = dgrDaGuiKeHoach.PageIndex;
        //            ddlistPageno.DataBind();
        //        }
        //    }
        //}
        //protected void dgrBoPhanDaGuiKeHoach_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (e.Row.RowState == DataControlRowState.Alternate)
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#f7fff8';");
        //        }
        //        else
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#eefef0';");
        //        }

        //        Button btnXem = (Button)e.Row.FindControl("btnXem");
        //        DataRowView curData = (DataRowView)e.Row.DataItem;

        //        string url;

        //        url = "window.open('" + AppEnv.AdminUrlParams("kehoachthang_bophan") + "&idDotDanhGia=" + curData["IDDotDanhGia"].ToString() + "&idBoPhan=" + curData["ID"].ToString() + "','_blank'); return false;";

        //        btnXem.OnClientClick = url;
        //    }
        //}
        //protected void ddlNumberPagesBoPhanDaGuiKeHoach_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DropDownList ddlistPagenoBoPhanDaGuiKeHoach = (DropDownList)dgrBoPhanDaGuiKeHoach.BottomPagerRow.FindControl("ddlNumberPagesBoPhanDaGuiKeHoach");
        //    dgrBoPhanDaGuiKeHoach.PageIndex = Convert.ToInt32(ddlistPagenoBoPhanDaGuiKeHoach.SelectedValue) - 1;

        //}
        //protected void dgrBoPhanDaGuiKeHoach_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    dgrBoPhanDaGuiKeHoach.PageIndex = e.NewPageIndex;
        //}
        //protected void ddlPageItemsBoPhanDaGuiKeHoach_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int pageItems = Convert.ToInt32(((DropDownList)sender).SelectedValue);
        //    this.dgrBoPhanDaGuiKeHoach.PageSize = pageItems;
        //    ViewState["DropDownPageItemsBoPhanDaGuiKeHoach"] = pageItems;
        //}
        //protected void dgrBoPhanDaGuiKeHoach_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //}

        #endregion

        #region BoPhan Chua Gui Danh Gia

        //protected void dgrBoPhanChuaGuiDanhGia_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    if (ViewState["sortDirectionBoPhanChuaGuiDanhGia"] == null || ViewState["sortDirectionBoPhanChuaGuiDanhGia"].ToString() == "")
        //    {
        //        ViewState["sortDirectionBoPhanChuaGuiDanhGia"] = "Desc";
        //    }
        //    else if (ViewState["sortDirectionBoPhanChuaGuiDanhGia"].ToString() == "Desc")
        //    {
        //        ViewState["sortDirectionBoPhanChuaGuiDanhGia"] = "";
        //    }
        //    ViewState["sortExpressionBoPhanChuaGuiDanhGia"] = e.SortExpression;

        //}
        //protected void dgrBoPhanChuaGuiDanhGia_PreRender(object sender, EventArgs e)
        //{
        //    if (dgrBoPhanChuaGuiDanhGia.BottomPagerRow != null)
        //    {
        //        ((Label)dgrBoPhanChuaGuiDanhGia.BottomPagerRow.FindControl("lbTotalPagesBoPhanChuaGuiDanhGia")).Text = dgrBoPhanChuaGuiDanhGia.PageCount.ToString();

        //        //This makes the first and last button disappear when on the first and last pages.
        //        ((LinkButton)dgrBoPhanChuaGuiDanhGia.BottomPagerRow.FindControl("lbtnFirstBoPhanChuaGuiDanhGia")).Visible = dgrBoPhanChuaGuiDanhGia.PageIndex != 0;
        //        ((LinkButton)dgrBoPhanChuaGuiDanhGia.BottomPagerRow.FindControl("lbtnLastBoPhanChuaGuiDanhGia")).Visible = dgrBoPhanChuaGuiDanhGia.PageCount != (dgrBoPhanChuaGuiDanhGia.PageIndex + 1);

        //        DropDownList ddlistPageof = (DropDownList)dgrBoPhanChuaGuiDanhGia.BottomPagerRow.FindControl("ddlPageItemsBoPhanChuaGuiDanhGia");
        //        ddlistPageof.SelectedIndex = ddlistPageof.Items.IndexOf(ddlistPageof.Items.FindByValue(ViewState["DropDownPageItemsBoPhanChuaGuiDanhGia"].ToString()));
        //        DropDownList ddlistPageno = (DropDownList)dgrBoPhanChuaGuiDanhGia.BottomPagerRow.FindControl("ddlNumberPagesBoPhanChuaGuiDanhGia");
        //        ddlistPageno.Items.Clear();
        //        for (int i = 1; i <= dgrBoPhanChuaGuiDanhGia.PageCount; i++)
        //        {
        //            ListItem liTemp = new ListItem();
        //            liTemp.Text = i.ToString();
        //            liTemp.Value = i.ToString();
        //            ddlistPageno.Items.Add(liTemp);
        //        }
        //        if (dgrBoPhanChuaGuiDanhGia.PageCount != 0)
        //        {
        //            ddlistPageno.SelectedIndex = dgrBoPhanChuaGuiDanhGia.PageIndex;
        //            ddlistPageno.DataBind();
        //        }
        //    }
        //}
        //protected void dgrBoPhanChuaGuiDanhGia_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (e.Row.RowState == DataControlRowState.Alternate)
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#f7fff8';");
        //        }
        //        else
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#eefef0';");
        //        }

        //    }
        //}
        //protected void ddlNumberPagesBoPhanChuaGuiDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DropDownList ddlistPagenoBoPhanChuaGuiDanhGia = (DropDownList)dgrBoPhanChuaGuiDanhGia.BottomPagerRow.FindControl("ddlNumberPagesBoPhanChuaGuiDanhGia");
        //    dgrBoPhanChuaGuiDanhGia.PageIndex = Convert.ToInt32(ddlistPagenoBoPhanChuaGuiDanhGia.SelectedValue) - 1;

        //}
        //protected void dgrBoPhanChuaGuiDanhGia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    dgrBoPhanChuaGuiDanhGia.PageIndex = e.NewPageIndex;
        //}
        //protected void ddlPageItemsBoPhanChuaGuiDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int pageItems = Convert.ToInt32(((DropDownList)sender).SelectedValue);
        //    this.dgrBoPhanChuaGuiDanhGia.PageSize = pageItems;
        //    ViewState["DropDownPageItemsBoPhanChuaGuiDanhGia"] = pageItems;
        //}
        //protected void dgrBoPhanChuaGuiDanhGia_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "mail")
        //    {
        //        string lblMail = e.CommandArgument.ToString();

        //        bool value = EmailUtility.DoSendMail(lblMail, "", "Mail nhắc nhở gửi bản đánh giá tháng bộ phận", "Yêu cầu bạn hoàn thiện bản đánh giá tháng bộ phận và gửi lại trong ngày hôm nay.");

        //    }
        //}

        #endregion

        #region BoPhan Da Gui Danh Gia

        //protected void dgrBoPhanDaGuiDanhGia_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    if (ViewState["sortDirectionBoPhanDaGuiDanhGia"] == null || ViewState["sortDirectionBoPhanDaGuiDanhGia"].ToString() == "")
        //    {
        //        ViewState["sortDirectionBoPhanDaGuiDanhGia"] = "Desc";
        //    }
        //    else if (ViewState["sortDirectionBoPhanDaGuiDanhGia"].ToString() == "Desc")
        //    {
        //        ViewState["sortDirectionBoPhanDaGuiDanhGia"] = "";
        //    }
        //    ViewState["sortExpressionBoPhanDaGuiDanhGia"] = e.SortExpression;

        //}
        //protected void dgrBoPhanDaGuiDanhGia_PreRender(object sender, EventArgs e)
        //{
        //    if (dgrBoPhanDaGuiDanhGia.BottomPagerRow != null)
        //    {
        //        ((Label)dgrBoPhanDaGuiDanhGia.BottomPagerRow.FindControl("lbTotalPagesBoPhanDaGuiDanhGia")).Text = dgrBoPhanDaGuiDanhGia.PageCount.ToString();

        //        //This makes the first and last button disappear when on the first and last pages.
        //        ((LinkButton)dgrBoPhanDaGuiDanhGia.BottomPagerRow.FindControl("lbtnFirstBoPhanDaGuiDanhGia")).Visible = dgrBoPhanDaGuiDanhGia.PageIndex != 0;
        //        ((LinkButton)dgrBoPhanDaGuiDanhGia.BottomPagerRow.FindControl("lbtnLastBoPhanDaGuiDanhGia")).Visible = dgrBoPhanDaGuiDanhGia.PageCount != (dgrBoPhanDaGuiDanhGia.PageIndex + 1);

        //        DropDownList ddlistPageof = (DropDownList)dgrBoPhanDaGuiDanhGia.BottomPagerRow.FindControl("ddlPageItemsBoPhanDaGuiDanhGia");
        //        ddlistPageof.SelectedIndex = ddlistPageof.Items.IndexOf(ddlistPageof.Items.FindByValue(ViewState["DropDownPageItemsBoPhanDaGuiDanhGia"].ToString()));
        //        DropDownList ddlistPageno = (DropDownList)dgrBoPhanDaGuiDanhGia.BottomPagerRow.FindControl("ddlNumberPagesBoPhanDaGuiDanhGia");
        //        ddlistPageno.Items.Clear();
        //        for (int i = 1; i <= dgrBoPhanDaGuiDanhGia.PageCount; i++)
        //        {
        //            ListItem liTemp = new ListItem();
        //            liTemp.Text = i.ToString();
        //            liTemp.Value = i.ToString();
        //            ddlistPageno.Items.Add(liTemp);
        //        }
        //        if (dgrBoPhanDaGuiDanhGia.PageCount != 0)
        //        {
        //            ddlistPageno.SelectedIndex = dgrBoPhanDaGuiDanhGia.PageIndex;
        //            ddlistPageno.DataBind();
        //        }
        //    }
        //}
        //protected void dgrBoPhanDaGuiDanhGia_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (e.Row.RowState == DataControlRowState.Alternate)
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#f7fff8';");
        //        }
        //        else
        //        {
        //            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#eefef0';");
        //        }

        //        DataRowView curData = (DataRowView)e.Row.DataItem;

        //        Button btnXem = (Button)e.Row.FindControl("btnXem");

        //        string url;
        //        if (ConvertUtility.ToInt32(curData["Loai"]) == 0)
        //        {
        //            url = "window.open('" + AppEnv.AdminUrlParams("danhgiathang_bophankinhdoanh") + "&idDotDanhGia=" + curData["IDDotDanhGia"].ToString() + "&idBoPhan=" + curData["ID"].ToString() + "','_blank'); return false;";
        //        }
        //        else
        //        {
        //            url = "window.open('" + AppEnv.AdminUrlParams("danhgiathang_bophanhotro") + "&idDotDanhGia=" + curData["IDDotDanhGia"].ToString() + "&idBoPhan=" + curData["ID"].ToString() + "','_blank'); return false;";
        //        }

        //        btnXem.OnClientClick = url;
        //    }
        //}
        //protected void ddlNumberPagesBoPhanDaGuiDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DropDownList ddlistPagenoBoPhanDaGuiDanhGia = (DropDownList)dgrBoPhanDaGuiDanhGia.BottomPagerRow.FindControl("ddlNumberPagesBoPhanDaGuiDanhGia");
        //    dgrBoPhanDaGuiDanhGia.PageIndex = Convert.ToInt32(ddlistPagenoBoPhanDaGuiDanhGia.SelectedValue) - 1;

        //}
        //protected void dgrBoPhanDaGuiDanhGia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    dgrDaGuiDanhGia.PageIndex = e.NewPageIndex;
        //}
        //protected void ddlPageItemsBoPhanDaGuiDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int pageItems = Convert.ToInt32(((DropDownList)sender).SelectedValue);
        //    this.dgrBoPhanDaGuiDanhGia.PageSize = pageItems;
        //    ViewState["DropDownPageItemsBoPhanDaGuiDanhGia"] = pageItems;
        //}
        //protected void dgrBoPhanDaGuiDanhGia_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //}

        #endregion

        //protected void btnChuaGuiKeHoach_Click(object sender, EventArgs e)
        //{
        //    foreach (GridViewRow gv in dgrChuaGuiKeHoach.Rows)
        //    {
        //        Label lblMail = (Label)gv.FindControl("lblMail");

        //        bool value = EmailUtility.DoSendMail(lblMail.Text, "", "Mail nhắc nhở gửi kế hoạch", "Yêu cầu bạn hoàn thiện kế hoạch công việc tháng và gửi lại trong ngày hôm nay.");
        //    }
        //}

        //protected void btnChuaGuiDanhGia_Click(object sender, EventArgs e)
        //{
        //    foreach (GridViewRow gv in dgrChuaGuiDanhGia.Rows)
        //    {
        //        Label lblMail = (Label)gv.FindControl("lblMail");

        //        bool value = EmailUtility.DoSendMail(lblMail.Text, "", "Mail nhắc nhở gửi bản đánh giá", "Yêu cầu bạn hoàn thiện bản đánh giá tháng và gửi lại trong ngày hôm nay.");
        //    }
        //}

        //protected void btnBoPhanChuaGuiKeHoach_Click(object sender, EventArgs e)
        //{
        //    foreach (GridViewRow gv in dgrBoPhanChuaGuiKeHoach.Rows)
        //    {
        //        Label lblMail = (Label)gv.FindControl("lblMail");

        //        bool value = EmailUtility.DoSendMail(lblMail.Text, "", "Mail nhắc nhở gửi kế hoạch Bộ phận", "Yêu cầu bạn hoàn thiện kế hoạch công việc tháng của Bộ phận và gửi lại trong ngày hôm nay.");
        //    }
        //}

        //protected void btnBoPhanChuaGuiDanhGia_Click(object sender, EventArgs e)
        //{
        //    foreach (GridViewRow gv in dgrBoPhanChuaGuiDanhGia.Rows)
        //    {
        //        Label lblMail = (Label)gv.FindControl("lblMail");

        //        bool value = EmailUtility.DoSendMail(lblMail.Text, "", "Mail nhắc nhở gửi bản đánh giá tháng bộ phận", "Yêu cầu bạn hoàn thiện bản đánh giá tháng bộ phận và gửi lại trong ngày hôm nay.");
        //    }
        //}
    }
}