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
using System.IO;
using System.Xml.Xsl;
using System.Text;

namespace VmgPortal.Modules.KPIData.Admin.BaoCao.XepLoaiThang
{
    public partial class BaoCaoXepLoaiDanhGiaCaNhan : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["DropDownPageItems"] = 10;

                dropTrungTam.DataSource = BoPhanController.BoPhan_GetAllActive();
                dropTrungTam.DataBind();

                int idDotDanhActive = ConvertUtility.ToInt32(DotDanhGiaController.GetDaultDotDanhGia().Rows[0]["ID"]);
                dropDotDanhGia.SelectedValue = idDotDanhActive.ToString();

                if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                {
                    dropTrungTam.Enabled = false;
                }

                dropTrungTam.SelectedValue = CurrentUser.IDTrungTam.ToString();

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

                dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
                dropDotDanhGia.DataBind();

                hplDownload.Visible = false;

                if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                {
                    trAdmin.Visible = false;
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            DataTable dtUsers;

            if (CurrentUser.IsAdmin || CurrentUser.IsSuperAdmin)
            {
                dtUsers = CommonController.BaoCaoXepLoaiDanhGiaCaNhanThang(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropPhongBan.SelectedValue), ConvertUtility.ToInt32(dropChucVu.SelectedValue), ConvertUtility.ToInt32(dropTrangThai.SelectedValue));
            }
            else
            {
                dtUsers = CommonController.BaoCaoXepLoaiDanhGiaCaNhanThang(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropPhongBan.SelectedValue), ConvertUtility.ToInt32(dropChucVu.SelectedValue), ConvertUtility.ToInt32(dropTrangThai.SelectedValue), CurrentUser.UserID);
            }

            //-------sort----------
            DataView dv = new DataView(dtUsers);
            if (ViewState["sortExpression"] != null && ViewState["sortExpression"].ToString() != string.Empty)
            {
                dv.Sort = ViewState["sortExpression"].ToString();
            }


            if (ViewState["sortDirection"] != null && ViewState["sortDirection"].ToString() == "Desc")
            {
                dv.Sort = ViewState["sortExpression"].ToString() + " " + ViewState["sortDirection"].ToString();
            }
            //--------sort-------------

            dtgUsers.DataSource = dv;
            dtgUsers.RowDataBound += new GridViewRowEventHandler(dtgUsers_RowDataBound);
            dtgUsers.DataBind();

            if (dtUsers != null)
            {
                lblTotalTop.Text = lblTotalBottom.Text = dtUsers.Rows.Count.ToString();
            }
        }

        protected void dtgUsers_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["sortDirection"] == null || ViewState["sortDirection"].ToString() == "")
            {
                ViewState["sortDirection"] = "Desc";
            }
            else if (ViewState["sortDirection"].ToString() == "Desc")
            {
                ViewState["sortDirection"] = "";
            }
            ViewState["sortExpression"] = e.SortExpression;

        }
        protected void dtgUsers_PreRender(object sender, EventArgs e)
        {
            if (dtgUsers.BottomPagerRow != null)
            {
                ((Label)dtgUsers.BottomPagerRow.FindControl("lbTotalPages")).Text = dtgUsers.PageCount.ToString();

                //This makes the first and last button disappear when on the first and last pages.
                ((LinkButton)dtgUsers.BottomPagerRow.FindControl("lbtnFirst")).Visible = dtgUsers.PageIndex != 0;
                ((LinkButton)dtgUsers.BottomPagerRow.FindControl("lbtnLast")).Visible = dtgUsers.PageCount != (dtgUsers.PageIndex + 1);

                DropDownList ddlistPageof = (DropDownList)dtgUsers.BottomPagerRow.FindControl("ddlPageItems");
                ddlistPageof.SelectedIndex = ddlistPageof.Items.IndexOf(ddlistPageof.Items.FindByValue(ViewState["DropDownPageItems"].ToString()));
                DropDownList ddlistPageno = (DropDownList)dtgUsers.BottomPagerRow.FindControl("ddlNumberPages");
                ddlistPageno.Items.Clear();
                for (int i = 1; i <= dtgUsers.PageCount; i++)
                {
                    ListItem liTemp = new ListItem();
                    liTemp.Text = i.ToString();
                    liTemp.Value = i.ToString();
                    ddlistPageno.Items.Add(liTemp);
                }
                if (dtgUsers.PageCount != 0)
                {
                    ddlistPageno.SelectedIndex = dtgUsers.PageIndex;
                    ddlistPageno.DataBind();
                }
            }
        }
        protected void dtgUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblTrangThai = (Label)e.Row.FindControl("lblTrangThai");
                Label lblTongDiem = (Label)e.Row.FindControl("lblTongDiem");
                HyperLink hplChiTiet = (HyperLink)e.Row.FindControl("hplChiTiet");
                HyperLink hplName = (HyperLink)e.Row.FindControl("hplName");

                DataRowView curData = (DataRowView)e.Row.DataItem;

                int Loai = ConvertUtility.ToInt32(curData["Loai"]);
                lblTrangThai.Text = GetTrangThai(ConvertUtility.ToInt32(curData["IDXepLoai"]));
                lblTongDiem.Text = Math.Round(ConvertUtility.ToDouble(curData["TongDiem"]), 1).ToString();


                if (e.Row.RowState == DataControlRowState.Alternate)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#f7fff8';");
                }
                else
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#eefef0';");
                }

                //if (Loai == 1 )
                hplName.NavigateUrl = AppEnv.AdminUrlParams("ptdanhgianhanvienhangthang") + "&idDotDanhGia=" + dropDotDanhGia.SelectedValue + "&idNhanVien=" + curData["UserID"].ToString();
                hplChiTiet.NavigateUrl = AppEnv.AdminUrlParams("baocaoxeploaicanhancacthang") + "&idNhanVien=" + curData["UserID"].ToString();
            }
        }

        private string GetTrangThai(int trangthai)
        {
            if (trangthai == 1)
            {
                return "Loại A+";
            }
            else if (trangthai == 2)
            {
                return "Loại A";
            }
            else if (trangthai == 3)
            {
                return "Loại B";
            }
            else if (trangthai == 4)
            {
                return "Loại C";
            }
            else
            {
                return "D";
            }

        }
        private string GetTrangThaiBoPhan(double tong)
        {
            #region Xep Loai

            //* Loại A: >= 90												
            //* Loại B: tong >= 80 && tong < 90													
            //* Loại C: tong >= 70 && tong < 80													
            //* Loại C: < 70
            if (tong >= 90)
            {
                return "A";
            }
            else if (tong >= 80 && tong < 90)
            {
                return "B";
            }
            else if (tong >= 70 && tong < 80)
            {
                return "C";
            }
            else
            {
                return "D";
            }

            #endregion

        }
        protected void ddlNumberPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlistPageno = (DropDownList)dtgUsers.BottomPagerRow.FindControl("ddlNumberPages");
            dtgUsers.PageIndex = Convert.ToInt32(ddlistPageno.SelectedValue) - 1;

        }
        protected void dtgUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgUsers.PageIndex = e.NewPageIndex;
        }
        protected void ddlPageItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pageItems = Convert.ToInt32(((DropDownList)sender).SelectedValue);
            this.dtgUsers.PageSize = pageItems;
            ViewState["DropDownPageItems"] = pageItems;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private XmlDocument BuildXmlDocument(DataTable source)
        {
            XmlDocument _XMLDoc = new XmlDocument();

            string xml = DateConverter.ConvertDataTableToXML(source);

            _XMLDoc.LoadXml(xml);

            return _XMLDoc;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dtUsersTemp = new DataTable();
            dtUsersTemp.Columns.Add("Bộ phận", typeof(string));
            dtUsersTemp.Columns.Add("Họ tên", typeof(string));
            dtUsersTemp.Columns.Add("KPI", typeof(string));
            dtUsersTemp.Columns.Add("Điểm đánh giá đơn vị", typeof(string));
            dtUsersTemp.Columns.Add("Lợi nhuận công ty", typeof(string));
            dtUsersTemp.Columns.Add("Lợi nhuận bộ phận", typeof(string));
            dtUsersTemp.Columns.Add("Quản lý công việc và làm việc nhóm", typeof(string));
            dtUsersTemp.Columns.Add("Kỷ luật cá nhân", typeof(string));
            dtUsersTemp.Columns.Add("Điểm thưởng", typeof(string));
            dtUsersTemp.Columns.Add("Mức độ hoàn thành", typeof(string));
            dtUsersTemp.Columns.Add("Xếp loại", typeof(string));
            dtUsersTemp.Columns.Add("Hệ số lương mềm", typeof(string));

            BoPhanInfo _BoPhanInfo = BoPhanController.GetInfo(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            int loaiTrungTam = _BoPhanInfo.Loai;
            string tenTrungTam = ConvertUtility.ToString(dropTrungTam.SelectedItem.Text);

            DataTable dtUsers = DotDanhGiaController.GetAllNhanVienInDotDanhGiaExport(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue));

            if (loaiTrungTam == 0)
            {
                if (ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue) < 223)
                {
                    #region Bo phan kinh doanh

                    foreach (DataRow item in dtUsers.Rows)
                    {
                        DataSet ds = DotDanhGiaController.DanhGiaThang_DGCBCNVDanhGia_TongDiemCongThucMoi(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(item["UserID"]));
                        if (ds != null)
                        {
                            DataRow row = dtUsersTemp.NewRow();

                            string lblTyLeHoanThanh = "";

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                lblTyLeHoanThanh = Math.Round(ConvertUtility.ToDouble(ds.Tables[0].Rows[0]["TyLeHoanThanh"].ToString()) / ConvertUtility.ToDouble(100), 2).ToString().Replace(",", ".");
                            }

                            string lblDiemDanhGiaDonVi = "";
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                lblDiemDanhGiaDonVi = Math.Round(ConvertUtility.ToDouble(ds.Tables[1].Rows[0]["TotalDiemDanhGiaDonVi"].ToString()) / ConvertUtility.ToDouble(100), 2, MidpointRounding.AwayFromZero).ToString().Replace(",", ".");
                            }

                            string lblDiemHoanThanhLoiNhuanCongTy = "";
                            if (ds.Tables[2].Rows.Count > 0)
                            {
                                lblDiemHoanThanhLoiNhuanCongTy = Math.Round(ConvertUtility.ToDouble(ds.Tables[2].Rows[0]["TotalDiemLNCgTy"]) / ConvertUtility.ToDouble(100), 2).ToString().Replace(",", ".");
                            }

                            string lblQuanLyCongViecVaLamViecNhom = "";
                            if (ds.Tables[3].Rows.Count > 0)
                            {
                                lblQuanLyCongViecVaLamViecNhom = Math.Round(ConvertUtility.ToDouble(ds.Tables[3].Rows[0]["TotalDiemPhoiHop"]) / ConvertUtility.ToDouble(100), 2).ToString().Replace(",", ".");
                            }

                            string lblDiemKyLuat = "";
                            if (ds.Tables[4].Rows.Count > 0)
                            {
                                lblDiemKyLuat = Math.Round(ConvertUtility.ToDouble(ds.Tables[4].Rows[0]["TotalDiemKyLuat"]) / ConvertUtility.ToDouble(100), 2).ToString().Replace(",", ".");
                            }

                            string lblDiemHoanThanhLoiNhuanBoPhan = "";
                            if (ds.Tables[5].Rows.Count > 0)
                            {
                                lblDiemHoanThanhLoiNhuanBoPhan = Math.Round(ConvertUtility.ToDouble(ds.Tables[5].Rows[0]["TotalDiemLNBoPhan"]) / ConvertUtility.ToDouble(100), 1, MidpointRounding.AwayFromZero).ToString().Replace(",", ".");
                            }

                            string lblMucDoHoanThanh = "";
                            if (ds.Tables[6].Rows.Count > 0)
                            {
                                lblMucDoHoanThanh = Math.Round(ConvertUtility.ToDouble(ds.Tables[6].Rows[0]["TongDiem"]) / ConvertUtility.ToDouble(100), 1, MidpointRounding.AwayFromZero).ToString().Replace(",", ".");
                            }

                            string lblXepLoai = "";
                            if (ds.Tables[7].Rows.Count > 0)
                            {
                                lblXepLoai = ds.Tables[7].Rows[0]["XepLoai"].ToString();
                            }

                            string lblName = "";
                            if (ds.Tables[8].Rows.Count > 0)
                            {
                                lblName = ds.Tables[8].Rows[0]["HoTen"].ToString();
                            }

                            string lblDiemThuong = "";
                            if (ds.Tables[9].Rows.Count > 0)
                            {
                                lblDiemThuong = Math.Round(ConvertUtility.ToDouble(ds.Tables[9].Rows[0]["DiemThuong"]) / 100, 3).ToString().Replace(",", ".");
                            }

                            string lblHeSoLuongMem = GetLuongMem(lblXepLoai);

                            row["Bộ phận"] = tenTrungTam;
                            row["Họ tên"] = lblName;
                            row["KPI"] = lblTyLeHoanThanh;
                            row["Điểm đánh giá đơn vị"] = lblDiemDanhGiaDonVi;
                            row["Lợi nhuận công ty"] = lblDiemHoanThanhLoiNhuanCongTy;
                            row["Lợi nhuận bộ phận"] = lblDiemHoanThanhLoiNhuanBoPhan;
                            row["Quản lý công việc và làm việc nhóm"] = lblQuanLyCongViecVaLamViecNhom;
                            row["Kỷ luật cá nhân"] = lblDiemKyLuat;
                            row["Điểm thưởng"] = lblDiemThuong;
                            row["Mức độ hoàn thành"] = lblMucDoHoanThanh;
                            row["Xếp loại"] = lblXepLoai;
                            row["Hệ số lương mềm"] = Math.Round(ConvertUtility.ToDouble(lblHeSoLuongMem) / 100, 2).ToString().Replace(",", ".");

                            dtUsersTemp.Rows.Add(row);
                        }
                    }

                    #endregion
                }
                else
                {
                    #region Bo phan ho tro

                    foreach (DataRow item in dtUsers.Rows)
                    {
                        DataSet ds = DotDanhGiaController.DanhGiaThang_DGCBCNVDanhGia_TongDiemCongThucMoi(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(item["UserID"]));
                        if (ds != null)
                        {
                            DataRow row = dtUsersTemp.NewRow();

                            string lblTyLeHoanThanh = "";

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                lblTyLeHoanThanh = Math.Round(ConvertUtility.ToDouble(ds.Tables[0].Rows[0]["TyLeHoanThanh"].ToString()) / ConvertUtility.ToDouble(100), 2).ToString().Replace(",", ".");
                            }

                            string lblDiemDanhGiaDonVi = "";
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                lblDiemDanhGiaDonVi = Math.Round(ConvertUtility.ToDouble(ds.Tables[1].Rows[0]["TotalDiemDanhGiaDonVi"].ToString()) / ConvertUtility.ToDouble(100), 2, MidpointRounding.AwayFromZero).ToString().Replace(",", ".");
                            }

                            string lblDiemHoanThanhLoiNhuanCongTy = "";
                            if (ds.Tables[2].Rows.Count > 0)
                            {
                                lblDiemHoanThanhLoiNhuanCongTy = Math.Round(ConvertUtility.ToDouble(ds.Tables[2].Rows[0]["TotalDiemLNCgTy"]) / ConvertUtility.ToDouble(100), 2).ToString().Replace(",", ".");
                            }

                            string lblQuanLyCongViecVaLamViecNhom = "";
                            if (ds.Tables[3].Rows.Count > 0)
                            {
                                lblQuanLyCongViecVaLamViecNhom = Math.Round(ConvertUtility.ToDouble(ds.Tables[3].Rows[0]["TotalDiemPhoiHop"]) / ConvertUtility.ToDouble(100), 2).ToString().Replace(",", ".");
                            }

                            string lblDiemKyLuat = "";
                            if (ds.Tables[4].Rows.Count > 0)
                            {
                                lblDiemKyLuat = Math.Round(ConvertUtility.ToDouble(ds.Tables[4].Rows[0]["TotalDiemKyLuat"]) / ConvertUtility.ToDouble(100), 2).ToString().Replace(",", ".");
                            }

                            string lblMucDoHoanThanh = "";
                            if (ds.Tables[5].Rows.Count > 0)
                            {
                                lblMucDoHoanThanh = (Math.Round(ConvertUtility.ToDouble(ds.Tables[5].Rows[0]["TongDiem"]), 1, MidpointRounding.AwayFromZero) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                            }

                            string lblXepLoai = "";
                            if (ds.Tables[6].Rows.Count > 0)
                            {
                                lblXepLoai = ds.Tables[6].Rows[0]["XepLoai"].ToString();
                            }

                            string lblName = "";
                            if (ds.Tables[7].Rows.Count > 0)
                            {
                                lblName = ds.Tables[7].Rows[0]["HoTen"].ToString();
                            }

                            string lblDiemThuong = "";
                            if (ds.Tables[8].Rows.Count > 0)
                            {
                                lblDiemThuong = Math.Round(ConvertUtility.ToDouble(ds.Tables[8].Rows[0]["DiemThuong"]) / 100, 3).ToString().Replace(",", ".");
                            }

                            string lblHeSoLuongMem = GetLuongMem(lblXepLoai);

                            row["Bộ phận"] = tenTrungTam;
                            row["Họ tên"] = lblName;
                            row["KPI"] = lblTyLeHoanThanh;
                            row["Điểm đánh giá đơn vị"] = lblDiemDanhGiaDonVi;
                            row["Lợi nhuận công ty"] = lblDiemHoanThanhLoiNhuanCongTy;
                            row["Lợi nhuận bộ phận"] = "";
                            row["Quản lý công việc và làm việc nhóm"] = lblQuanLyCongViecVaLamViecNhom;
                            row["Kỷ luật cá nhân"] = lblDiemKyLuat;
                            row["Điểm thưởng"] = lblDiemThuong;
                            row["Mức độ hoàn thành"] = lblMucDoHoanThanh;
                            row["Xếp loại"] = lblXepLoai;
                            row["Hệ số lương mềm"] = Math.Round(ConvertUtility.ToDouble(lblHeSoLuongMem) / 100, 2).ToString().Replace(",", ".");

                            dtUsersTemp.Rows.Add(row);
                        }
                    }

                    #endregion
                }
            }
            else
            {
                #region Bo phan ho tro

                foreach (DataRow item in dtUsers.Rows)
                {
                    DataSet ds = DotDanhGiaController.DanhGiaThang_DGCBCNVDanhGia_TongDiemCongThucMoi(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(item["UserID"]));
                    if (ds != null)
                    {
                        DataRow row = dtUsersTemp.NewRow();

                        string lblTyLeHoanThanh = "";

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lblTyLeHoanThanh = Math.Round(ConvertUtility.ToDouble(ds.Tables[0].Rows[0]["TyLeHoanThanh"].ToString()) / ConvertUtility.ToDouble(100), 2).ToString().Replace(",", ".");
                        }

                        string lblDiemDanhGiaDonVi = "";
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            lblDiemDanhGiaDonVi = Math.Round(ConvertUtility.ToDouble(ds.Tables[1].Rows[0]["TotalDiemDanhGiaDonVi"].ToString()) / ConvertUtility.ToDouble(100), 2, MidpointRounding.AwayFromZero).ToString().Replace(",", ".");
                        }

                        string lblDiemHoanThanhLoiNhuanCongTy = "";
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            lblDiemHoanThanhLoiNhuanCongTy = Math.Round(ConvertUtility.ToDouble(ds.Tables[2].Rows[0]["TotalDiemLNCgTy"]) / ConvertUtility.ToDouble(100), 2).ToString().Replace(",", ".");
                        }

                        string lblQuanLyCongViecVaLamViecNhom = "";
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            lblQuanLyCongViecVaLamViecNhom = Math.Round(ConvertUtility.ToDouble(ds.Tables[3].Rows[0]["TotalDiemPhoiHop"]) / ConvertUtility.ToDouble(100), 2).ToString().Replace(",", ".");
                        }

                        string lblDiemKyLuat = "";
                        if (ds.Tables[4].Rows.Count > 0)
                        {
                            lblDiemKyLuat = Math.Round(ConvertUtility.ToDouble(ds.Tables[4].Rows[0]["TotalDiemKyLuat"]) / ConvertUtility.ToDouble(100), 2).ToString().Replace(",", ".");
                        }

                        string lblMucDoHoanThanh = "";
                        if (ds.Tables[5].Rows.Count > 0)
                        {
                            lblMucDoHoanThanh = (Math.Round(ConvertUtility.ToDouble(ds.Tables[5].Rows[0]["TongDiem"]), 1, MidpointRounding.AwayFromZero) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                        }

                        string lblXepLoai = "";
                        if (ds.Tables[6].Rows.Count > 0)
                        {
                            lblXepLoai = ds.Tables[6].Rows[0]["XepLoai"].ToString();
                        }

                        string lblName = "";
                        if (ds.Tables[7].Rows.Count > 0)
                        {
                            lblName = ds.Tables[7].Rows[0]["HoTen"].ToString();
                        }

                        string lblDiemThuong = "";
                        if (ds.Tables[8].Rows.Count > 0)
                        {
                            lblDiemThuong = Math.Round(ConvertUtility.ToDouble(ds.Tables[8].Rows[0]["DiemThuong"]) / 100, 3).ToString().Replace(",", ".");
                        }

                        string lblHeSoLuongMem = GetLuongMem(lblXepLoai);

                        row["Bộ phận"] = tenTrungTam;
                        row["Họ tên"] = lblName;
                        row["KPI"] = lblTyLeHoanThanh;
                        row["Điểm đánh giá đơn vị"] = lblDiemDanhGiaDonVi;
                        row["Lợi nhuận công ty"] = lblDiemHoanThanhLoiNhuanCongTy;
                        row["Lợi nhuận bộ phận"] = "";
                        row["Quản lý công việc và làm việc nhóm"] = lblQuanLyCongViecVaLamViecNhom;
                        row["Kỷ luật cá nhân"] = lblDiemKyLuat;
                        row["Điểm thưởng"] = lblDiemThuong;
                        row["Mức độ hoàn thành"] = lblMucDoHoanThanh;
                        row["Xếp loại"] = lblXepLoai;
                        row["Hệ số lương mềm"] = Math.Round(ConvertUtility.ToDouble(lblHeSoLuongMem) / 100, 2).ToString().Replace(",", ".");

                        dtUsersTemp.Rows.Add(row);
                    }
                }

                #endregion
            }

            ImportExcelToDataTable.ExportToExcel(dtUsersTemp, "KQDanhGiaCaNhanThang_" + dropTrungTam.SelectedItem.Text + ".csv");

            //ExportData.Export obj = new ExportData.Export();

            //obj.ExportDetails(dtUsersTemp, ExportData.Export.ExportFormat.Excel, "KQDanhGiaCaNhanThang_" + dropTrungTam.SelectedItem.Text + ".xls");
            //DataTable dtUsers = CommonController.BaoCaoXepLoaiDanhGiaCaNhanThang(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropPhongBan.SelectedValue), ConvertUtility.ToInt32(dropChucVu.SelectedValue), ConvertUtility.ToInt32(dropTrangThai.SelectedValue));

            //DataTable dtUsersTemp = dtUsers.Clone();
            //dtUsersTemp.Columns.Add("XepLoai", typeof(string));
            //dtUsersTemp.Columns.Add("XepLoaiBoPhan", typeof(string));
            //foreach (DataRow item in dtUsers.Rows)
            //{
            //    DataRow row = dtUsersTemp.NewRow();

            //    row["HoTen"] = item["HoTen"];
            //    row["TongDiem"] = Math.Round(ConvertUtility.ToDouble(item["TongDiem"]), 2).ToString().Replace(".", ",");
            //    row["XepLoai"] = GetTrangThai(ConvertUtility.ToInt32(item["IDXepLoai"]));
            //    row["XepLoaiBoPhan"] = GetTrangThaiBoPhan(ConvertUtility.ToDouble(item["IDXepLoaiBoPhan"]));

            //    dtUsersTemp.Rows.Add(row);
            //}
            //XmlDocument doc = BuildXmlDocument(dtUsersTemp);

            //if (!Directory.Exists(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/")))
            //{
            //    Directory.CreateDirectory(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/"));
            //}
            ////ds.Dispose();
            //string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            //FileStream downloadFile =
            //    File.Create(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/") + "ReportKetQuaXepLoaiNhanVien_" + datetime +
            //                ".xls");

            //// transform
            //XslTransform xsl = new XslTransform();
            //xsl.Load(Server.MapPath("/Template/" + "ReportKetQuaXepLoaiNhanVien.xsl"));

            //DateConverter objDateConverter = new DateConverter();
            //XsltArgumentList args = new XsltArgumentList();
            //args.AddExtensionObject("urn:ms-kb", objDateConverter);

            //xsl.Transform(doc, args, downloadFile, null);
            //downloadFile.Flush();
            //downloadFile.Close();

            //hplDownload.Text = "Hãy click vào liên kết này để Tải file về";
            //hplDownload.Visible = true;
            //hplDownload.NavigateUrl = "/UpLoad/Temp/" + CurrentUser.UserID + "/ReportKetQuaXepLoaiNhanVien_" + datetime + ".xls";
        }

        protected void dropTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropPhongBan.Items.Clear();

            DataTable dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue)); ;
            dropPhongBan.DataSource = dtPhong;
            dropPhongBan.DataBind();
            dropPhongBan.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));

        }

        protected void dropPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dropChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dropTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dropTrungTam_SelectedIndexChanged1(object sender, EventArgs e)
        {
            dropPhongBan.Items.Clear();

            DataTable dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue)); ;
            dropPhongBan.DataSource = dtPhong;
            dropPhongBan.DataBind();
            dropPhongBan.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));
        }

        protected void btnExportHoTro_Click(object sender, EventArgs e)
        {
            DataTable dtTrungTamTheoKhoi = CommonController.GetAllBoPhanTheoLoai(1);

            DataTable dtUsersTemp = new DataTable();
            dtUsersTemp.Columns.Add("TrungTam", typeof(string));
            dtUsersTemp.Columns.Add("HoTen", typeof(string));
            dtUsersTemp.Columns.Add("KPI", typeof(string));
            dtUsersTemp.Columns.Add("DanhGiaDonVi", typeof(string));
            dtUsersTemp.Columns.Add("LoiNhuanCongTy", typeof(string));
            dtUsersTemp.Columns.Add("QuanLyCongViecVaLamViecNhom", typeof(string));
            dtUsersTemp.Columns.Add("KyLuatCaNhan", typeof(string));
            dtUsersTemp.Columns.Add("DiemThuong", typeof(string));
            dtUsersTemp.Columns.Add("MucDoHoanThanh", typeof(string));
            dtUsersTemp.Columns.Add("XepLoai", typeof(string));
            dtUsersTemp.Columns.Add("HeSoLuongMem", typeof(string));

            foreach (DataRow rowBoPhan in dtTrungTamTheoKhoi.Rows)
            {
                int loaiTrungTam = ConvertUtility.ToInt32(rowBoPhan["Loai"]);
                string tenTrungTam = ConvertUtility.ToString(rowBoPhan["Ten"]);

                DataTable dtUsers = DotDanhGiaController.GetAllNhanVienInDotDanhGiaNew(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(rowBoPhan["ID"]));

                foreach (DataRow item in dtUsers.Rows)
                {
                    DataSet ds = DotDanhGiaController.DanhGiaThang_DGCBCNVDanhGia_TongDiemCongThucMoi(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(item["UserID"]));
                    if (ds != null)
                    {
                        DataRow row = dtUsersTemp.NewRow();

                        string lblTyLeHoanThanh = "";

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lblTyLeHoanThanh = (Math.Round(ConvertUtility.ToDouble(ds.Tables[0].Rows[0]["TyLeHoanThanh"].ToString()), 2) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                        }

                        string lblDiemDanhGiaDonVi = "";
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            lblDiemDanhGiaDonVi = (Math.Round(ConvertUtility.ToDouble(ds.Tables[1].Rows[0]["TotalDiemDanhGiaDonVi"].ToString()), 2, MidpointRounding.AwayFromZero) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                        }

                        string lblDiemHoanThanhLoiNhuanCongTy = "";
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            lblDiemHoanThanhLoiNhuanCongTy = (Math.Round(ConvertUtility.ToDouble(ds.Tables[2].Rows[0]["TotalDiemLNCgTy"]), 2) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                        }

                        string lblQuanLyCongViecVaLamViecNhom = "";
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            lblQuanLyCongViecVaLamViecNhom = (Math.Round(ConvertUtility.ToDouble(ds.Tables[3].Rows[0]["TotalDiemPhoiHop"]), 2) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                        }

                        string lblDiemKyLuat = "";
                        if (ds.Tables[4].Rows.Count > 0)
                        {
                            lblDiemKyLuat = (Math.Round(ConvertUtility.ToDouble(ds.Tables[4].Rows[0]["TotalDiemKyLuat"]), 2) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                        }

                        string lblMucDoHoanThanh = "";
                        if (ds.Tables[5].Rows.Count > 0)
                        {
                            lblMucDoHoanThanh = (Math.Round(ConvertUtility.ToDouble(ds.Tables[5].Rows[0]["TongDiem"]), 1, MidpointRounding.AwayFromZero) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                        }

                        string lblXepLoai = "";
                        if (ds.Tables[6].Rows.Count > 0)
                        {
                            lblXepLoai = ds.Tables[6].Rows[0]["XepLoai"].ToString();
                        }

                        string lblName = "";
                        if (ds.Tables[7].Rows.Count > 0)
                        {
                            lblName = ds.Tables[7].Rows[0]["HoTen"].ToString();
                        }

                        string lblDiemThuong = "";
                        if (ds.Tables[8].Rows.Count > 0)
                        {
                            lblDiemThuong = Math.Round(ConvertUtility.ToDouble(ds.Tables[8].Rows[0]["DiemThuong"]) / 100, 3).ToString().Replace(",", ".");
                        }

                        string lblHeSoLuongMem = GetLuongMem(lblXepLoai);

                        row["TrungTam"] = tenTrungTam;
                        row["HoTen"] = lblName;
                        row["KPI"] = lblTyLeHoanThanh;
                        row["DanhGiaDonVi"] = lblDiemDanhGiaDonVi;
                        row["LoiNhuanCongTy"] = lblDiemHoanThanhLoiNhuanCongTy;
                        row["QuanLyCongViecVaLamViecNhom"] = lblQuanLyCongViecVaLamViecNhom;
                        row["KyLuatCaNhan"] = lblDiemKyLuat;
                        row["DiemThuong"] = lblDiemThuong;
                        row["MucDoHoanThanh"] = lblMucDoHoanThanh;
                        row["XepLoai"] = lblXepLoai;
                        row["HeSoLuongMem"] = Math.Round(ConvertUtility.ToDouble(lblHeSoLuongMem) / 100, 2).ToString().Replace(",", ".");

                        dtUsersTemp.Rows.Add(row);
                    }
                }

            }

            XmlDocument doc = BuildXmlDocument(dtUsersTemp);

            if (!Directory.Exists(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/")))
            {
                Directory.CreateDirectory(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/"));
            }
            //ds.Dispose();
            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            FileStream downloadFile =
                File.Create(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/") + "ReportKetQuaXepLoaiNhanVienHT_" + datetime +
                            ".xls");

            // transform
            XslTransform xsl = new XslTransform();
            xsl.Load(Server.MapPath("/Template/" + "ReportKetQuaXepLoaiNhanVienHT.xsl"));

            DateConverter objDateConverter = new DateConverter();
            XsltArgumentList args = new XsltArgumentList();
            args.AddExtensionObject("urn:ms-kb", objDateConverter);

            xsl.Transform(doc, args, downloadFile, null);
            downloadFile.Flush();
            downloadFile.Close();

            hplDownload.Text = "Hãy click vào liên kết này để Tải file về";
            hplDownload.Visible = true;
            hplDownload.NavigateUrl = "/UpLoad/Temp/" + CurrentUser.UserID + "/ReportKetQuaXepLoaiNhanVienHT_" + datetime + ".xls";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue) < 223)
            {
                #region dotdanhgia < 223

                DataTable dtTrungTamTheoKhoi = CommonController.GetAllBoPhanTheoLoai(0);

                DataTable dtUsersTemp = new DataTable();
                dtUsersTemp.Columns.Add("TrungTam", typeof(string));
                dtUsersTemp.Columns.Add("HoTen", typeof(string));
                dtUsersTemp.Columns.Add("KPI", typeof(string));
                dtUsersTemp.Columns.Add("DanhGiaDonVi", typeof(string));
                dtUsersTemp.Columns.Add("LoiNhuanCongTy", typeof(string));
                dtUsersTemp.Columns.Add("LoiNhuanBoPhan", typeof(string));
                dtUsersTemp.Columns.Add("QuanLyCongViecVaLamViecNhom", typeof(string));
                dtUsersTemp.Columns.Add("KyLuatCaNhan", typeof(string));
                dtUsersTemp.Columns.Add("DiemThuong", typeof(string));
                dtUsersTemp.Columns.Add("MucDoHoanThanh", typeof(string));
                dtUsersTemp.Columns.Add("XepLoai", typeof(string));
                dtUsersTemp.Columns.Add("HeSoLuongMem", typeof(string));

                foreach (DataRow rowBoPhan in dtTrungTamTheoKhoi.Rows)
                {
                    int loaiTrungTam = ConvertUtility.ToInt32(rowBoPhan["Loai"]);
                    string tenTrungTam = ConvertUtility.ToString(rowBoPhan["Ten"]);

                    DataTable dtUsers = DotDanhGiaController.GetAllNhanVienInDotDanhGiaNew(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(rowBoPhan["ID"]));

                    foreach (DataRow item in dtUsers.Rows)
                    {
                        DataRow row = dtUsersTemp.NewRow();

                        DataSet ds = DotDanhGiaController.DanhGiaThang_DGCBCNVDanhGia_TongDiemCongThucMoi(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(item["UserID"]));
                        if (ds != null)
                        {
                            string lblTyLeHoanThanh = "";

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                lblTyLeHoanThanh = (Math.Round(ConvertUtility.ToDouble(ds.Tables[0].Rows[0]["TyLeHoanThanh"].ToString()), 2) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                            }

                            string lblDiemDanhGiaDonVi = "";
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                lblDiemDanhGiaDonVi = (Math.Round(ConvertUtility.ToDouble(ds.Tables[1].Rows[0]["TotalDiemDanhGiaDonVi"].ToString()), 2, MidpointRounding.AwayFromZero) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                            }

                            string lblDiemHoanThanhLoiNhuanCongTy = "";
                            if (ds.Tables[2].Rows.Count > 0)
                            {
                                lblDiemHoanThanhLoiNhuanCongTy = (Math.Round(ConvertUtility.ToDouble(ds.Tables[2].Rows[0]["TotalDiemLNCgTy"]), 2) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                            }

                            string lblQuanLyCongViecVaLamViecNhom = "";
                            if (ds.Tables[3].Rows.Count > 0)
                            {
                                lblQuanLyCongViecVaLamViecNhom = (Math.Round(ConvertUtility.ToDouble(ds.Tables[3].Rows[0]["TotalDiemPhoiHop"]), 2) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                            }

                            string lblDiemKyLuat = "";
                            if (ds.Tables[4].Rows.Count > 0)
                            {
                                lblDiemKyLuat = (Math.Round(ConvertUtility.ToDouble(ds.Tables[4].Rows[0]["TotalDiemKyLuat"]), 2) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                            }

                            string lblDiemHoanThanhLoiNhuanBoPhan = "";
                            if (ds.Tables[5].Rows.Count > 0)
                            {
                                lblDiemHoanThanhLoiNhuanBoPhan = (Math.Round(ConvertUtility.ToDouble(ds.Tables[5].Rows[0]["TotalDiemLNBoPhan"]), 1, MidpointRounding.AwayFromZero) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                            }

                            string lblMucDoHoanThanh = "";
                            if (ds.Tables[6].Rows.Count > 0)
                            {
                                lblMucDoHoanThanh = (Math.Round(ConvertUtility.ToDouble(ds.Tables[6].Rows[0]["TongDiem"]), 1, MidpointRounding.AwayFromZero) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                            }

                            string lblXepLoai = "";
                            if (ds.Tables[7].Rows.Count > 0)
                            {
                                lblXepLoai = ds.Tables[7].Rows[0]["XepLoai"].ToString();
                            }

                            string lblName = "";
                            if (ds.Tables[8].Rows.Count > 0)
                            {
                                lblName = ds.Tables[8].Rows[0]["HoTen"].ToString();
                            }

                            string lblDiemThuong = "";
                            if (ds.Tables[9].Rows.Count > 0)
                            {
                                lblDiemThuong = Math.Round(ConvertUtility.ToDouble(ds.Tables[9].Rows[0]["DiemThuong"]) / 100, 3).ToString().Replace(",", ".");
                            }

                            string lblHeSoLuongMem = GetLuongMem(lblXepLoai);

                            row["TrungTam"] = tenTrungTam;
                            row["HoTen"] = lblName;
                            row["KPI"] = lblTyLeHoanThanh;
                            row["DanhGiaDonVi"] = lblDiemDanhGiaDonVi;
                            row["LoiNhuanCongTy"] = lblDiemHoanThanhLoiNhuanCongTy;
                            row["LoiNhuanBoPhan"] = lblDiemHoanThanhLoiNhuanBoPhan;
                            row["QuanLyCongViecVaLamViecNhom"] = lblQuanLyCongViecVaLamViecNhom;
                            row["KyLuatCaNhan"] = lblDiemKyLuat;
                            row["DiemThuong"] = lblDiemThuong;
                            row["MucDoHoanThanh"] = lblMucDoHoanThanh;
                            row["XepLoai"] = lblXepLoai;
                            row["HeSoLuongMem"] = Math.Round(ConvertUtility.ToDouble(lblHeSoLuongMem) / 100, 2).ToString().Replace(",", ".");

                            dtUsersTemp.Rows.Add(row);
                        }
                    }
                    XmlDocument doc = BuildXmlDocument(dtUsersTemp);

                    if (!Directory.Exists(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/")))
                    {
                        Directory.CreateDirectory(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/"));
                    }
                    //ds.Dispose();
                    string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
                    FileStream downloadFile =
                        File.Create(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/") + "ReportKetQuaXepLoaiNhanVienKD_" + datetime +
                                    ".xls");

                    // transform
                    XslTransform xsl = new XslTransform();
                    xsl.Load(Server.MapPath("/Template/" + "ReportKetQuaXepLoaiNhanVienKD.xsl"));

                    DateConverter objDateConverter = new DateConverter();
                    XsltArgumentList args = new XsltArgumentList();
                    args.AddExtensionObject("urn:ms-kb", objDateConverter);

                    xsl.Transform(doc, args, downloadFile, null);
                    downloadFile.Flush();
                    downloadFile.Close();

                    hplDownload.Text = "Hãy click vào liên kết này để Tải file về";
                    hplDownload.Visible = true;
                    hplDownload.NavigateUrl = "/UpLoad/Temp/" + CurrentUser.UserID + "/ReportKetQuaXepLoaiNhanVienKD_" + datetime + ".xls";

                }

                #endregion
            }
            else
            {
                DataTable dtTrungTamTheoKhoi = CommonController.GetAllBoPhanTheoLoai(0);

                DataTable dtUsersTemp = new DataTable();
                dtUsersTemp.Columns.Add("TrungTam", typeof(string));
                dtUsersTemp.Columns.Add("HoTen", typeof(string));
                dtUsersTemp.Columns.Add("KPI", typeof(string));
                dtUsersTemp.Columns.Add("DanhGiaDonVi", typeof(string));
                dtUsersTemp.Columns.Add("LoiNhuanCongTy", typeof(string));
                dtUsersTemp.Columns.Add("QuanLyCongViecVaLamViecNhom", typeof(string));
                dtUsersTemp.Columns.Add("KyLuatCaNhan", typeof(string));
                dtUsersTemp.Columns.Add("DiemThuong", typeof(string));
                dtUsersTemp.Columns.Add("MucDoHoanThanh", typeof(string));
                dtUsersTemp.Columns.Add("XepLoai", typeof(string));
                dtUsersTemp.Columns.Add("HeSoLuongMem", typeof(string));

                foreach (DataRow rowBoPhan in dtTrungTamTheoKhoi.Rows)
                {
                    int loaiTrungTam = ConvertUtility.ToInt32(rowBoPhan["Loai"]);
                    string tenTrungTam = ConvertUtility.ToString(rowBoPhan["Ten"]);

                    DataTable dtUsers = DotDanhGiaController.GetAllNhanVienInDotDanhGiaNew(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(rowBoPhan["ID"]));

                    foreach (DataRow item in dtUsers.Rows)
                    {
                        try
                        {
                            DataSet ds = DotDanhGiaController.DanhGiaThang_DGCBCNVDanhGia_TongDiemCongThucMoi(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(item["UserID"]));
                            if (ds != null)
                            {
                                DataRow row = dtUsersTemp.NewRow();

                                string lblTyLeHoanThanh = "";

                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    lblTyLeHoanThanh = (Math.Round(ConvertUtility.ToDouble(ds.Tables[0].Rows[0]["TyLeHoanThanh"].ToString()), 2) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                                }

                                string lblDiemDanhGiaDonVi = "";
                                if (ds.Tables[1].Rows.Count > 0)
                                {
                                    lblDiemDanhGiaDonVi = (Math.Round(ConvertUtility.ToDouble(ds.Tables[1].Rows[0]["TotalDiemDanhGiaDonVi"].ToString()), 2, MidpointRounding.AwayFromZero) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                                }

                                string lblDiemHoanThanhLoiNhuanCongTy = "";
                                if (ds.Tables[2].Rows.Count > 0)
                                {
                                    lblDiemHoanThanhLoiNhuanCongTy = (Math.Round(ConvertUtility.ToDouble(ds.Tables[2].Rows[0]["TotalDiemLNCgTy"]), 2) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                                }

                                string lblQuanLyCongViecVaLamViecNhom = "";
                                if (ds.Tables[3].Rows.Count > 0)
                                {
                                    lblQuanLyCongViecVaLamViecNhom = (Math.Round(ConvertUtility.ToDouble(ds.Tables[3].Rows[0]["TotalDiemPhoiHop"]), 2) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                                }

                                string lblDiemKyLuat = "";
                                if (ds.Tables[4].Rows.Count > 0)
                                {
                                    lblDiemKyLuat = (Math.Round(ConvertUtility.ToDouble(ds.Tables[4].Rows[0]["TotalDiemKyLuat"]), 2) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                                }

                                string lblMucDoHoanThanh = "";
                                if (ds.Tables[5].Rows.Count > 0)
                                {
                                    lblMucDoHoanThanh = (Math.Round(ConvertUtility.ToDouble(ds.Tables[5].Rows[0]["TongDiem"]), 1, MidpointRounding.AwayFromZero) / ConvertUtility.ToDouble(100)).ToString().Replace(",", ".");
                                }

                                string lblXepLoai = "";
                                if (ds.Tables[6].Rows.Count > 0)
                                {
                                    lblXepLoai = ds.Tables[6].Rows[0]["XepLoai"].ToString();
                                }

                                string lblName = "";
                                if (ds.Tables[7].Rows.Count > 0)
                                {
                                    lblName = ds.Tables[7].Rows[0]["HoTen"].ToString();
                                }

                                string lblDiemThuong = "";
                                if (ds.Tables[8].Rows.Count > 0)
                                {
                                    lblDiemThuong = Math.Round(ConvertUtility.ToDouble(ds.Tables[8].Rows[0]["DiemThuong"]) / 100, 3).ToString().Replace(",", ".");
                                }

                                string lblHeSoLuongMem = GetLuongMem(lblXepLoai);

                                row["TrungTam"] = tenTrungTam;
                                row["HoTen"] = lblName;
                                row["KPI"] = lblTyLeHoanThanh;
                                row["DanhGiaDonVi"] = lblDiemDanhGiaDonVi;
                                row["LoiNhuanCongTy"] = lblDiemHoanThanhLoiNhuanCongTy;
                                row["QuanLyCongViecVaLamViecNhom"] = lblQuanLyCongViecVaLamViecNhom;
                                row["KyLuatCaNhan"] = lblDiemKyLuat;
                                row["DiemThuong"] = lblDiemThuong;
                                row["MucDoHoanThanh"] = lblMucDoHoanThanh;
                                row["XepLoai"] = lblXepLoai;
                                row["HeSoLuongMem"] = Math.Round(ConvertUtility.ToDouble(lblHeSoLuongMem) / 100, 2).ToString().Replace(",", ".");

                                dtUsersTemp.Rows.Add(row);
                            }
                        }
                        catch (Exception)
                        {
                               //Response.Write(ConvertUtility.ToInt32(item["UserID"]));
                        }                        
                    }

                }

                XmlDocument doc = BuildXmlDocument(dtUsersTemp);

                if (!Directory.Exists(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/")))
                {
                    Directory.CreateDirectory(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/"));
                }
                //ds.Dispose();
                string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
                FileStream downloadFile =
                    File.Create(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/") + "ReportKetQuaXepLoaiNhanVienHT_" + datetime +
                                ".xls");

                // transform
                XslTransform xsl = new XslTransform();
                xsl.Load(Server.MapPath("/Template/" + "ReportKetQuaXepLoaiNhanVienHT.xsl"));

                DateConverter objDateConverter = new DateConverter();
                XsltArgumentList args = new XsltArgumentList();
                args.AddExtensionObject("urn:ms-kb", objDateConverter);

                xsl.Transform(doc, args, downloadFile, null);
                downloadFile.Flush();
                downloadFile.Close();

                hplDownload.Text = "Hãy click vào liên kết này để Tải file về";
                hplDownload.Visible = true;
                hplDownload.NavigateUrl = "/UpLoad/Temp/" + CurrentUser.UserID + "/ReportKetQuaXepLoaiNhanVienHT_" + datetime + ".xls";
            }
        }

        private string GetLuongMem(string xeploai)
        {
            if (xeploai == "A+")
            {
                return "140";
            }
            else if (xeploai == "A")
            {
                return "130";
            }
            else if (xeploai == "B")
            {
                return "120";
            }
            else if (xeploai == "C")
            {
                return "110";
            }
            else
            {
                return "100";
            }
        }
    }
}