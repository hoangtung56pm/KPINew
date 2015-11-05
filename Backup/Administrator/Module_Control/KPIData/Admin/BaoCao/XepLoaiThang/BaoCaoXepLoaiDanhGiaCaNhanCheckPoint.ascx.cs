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
    public partial class BaoCaoXepLoaiDanhGiaCaNhanCheckPoint : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["DropDownPageItems"] = 10;

                dropTrungTam.DataSource = BoPhanController.BoPhan_GetAllActive();
                dropTrungTam.DataBind();

                int idDotDanhActive = ConvertUtility.ToInt32(DotDanhGiaController.GetDaultDotDanhGiaCheckPoint().Rows[0]["ID"]);
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

                dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(2);
                dropDotDanhGia.DataBind();

                hplDownload.Visible = false;

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

            DataTable dtUsersTemp = new DataTable();
            dtUsersTemp.Columns.Add("UserID", typeof(string));
            dtUsersTemp.Columns.Add("Bộ phận", typeof(string));
            dtUsersTemp.Columns.Add("Họ tên", typeof(string));
            dtUsersTemp.Columns.Add("Điểm đánh giá công việc", typeof(string));
            dtUsersTemp.Columns.Add("Điểm kỷ luật và văn hóa doanh nghiệp", typeof(string));
            dtUsersTemp.Columns.Add("Điểm đồng nghiệp đánh giá", typeof(string));
            dtUsersTemp.Columns.Add("Tổng điểm", typeof(string));
            dtUsersTemp.Columns.Add("Xếp loại", typeof(string));

            BoPhanInfo _BoPhanInfo = BoPhanController.GetInfo(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            int loaiTrungTam = _BoPhanInfo.Loai;
            string tenTrungTam = ConvertUtility.ToString(dropTrungTam.SelectedItem.Text);
                     
            foreach (DataRow item in dtUsers.Rows)
            {
                DataSet ds = DotDanhGiaController.DanhGiaCheckPoint_DGCBCNVDanhGia_TongDiemCongThucMoi(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(item["UserID"]));
                if (ds != null)
                {
                    DataRow row = dtUsersTemp.NewRow();

                    double TongDiemDGCV = 0;
                    double TongDiemDGCV1 = 0;
                    double diemKyLuat = 0;
                    double diemKyLuat1 = 0;
                    double DiemDongNghiepDanhGia = 0;
                    double DiemDongNghiepDanhGia1 = 0;

                    double DiemCLCV = 100;
                    double DiemTDCV = 100;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DiemCLCV = ConvertUtility.ToDouble(ds.Tables[0].Rows[0]["DiemCLCV"].ToString());
                        DiemTDCV = ConvertUtility.ToDouble(ds.Tables[0].Rows[0]["DiemTDCV"].ToString());
                    }
                    double DiemDGCV = 0;

                    DataTable dtDotDanhGiaByCheckpoint = DotDanhGiaController.CheckPoint_GetAllDotDanhGiaByCheckpoint(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

                    int count = 0;

                    foreach (DataRow itemDotDanhGia in dtDotDanhGiaByCheckpoint.Rows)
                    {
                        DataTable dtDiemTB = DotDanhGiaController.CheckPoint_DanhGiaCongViec_GetDiemTB(ConvertUtility.ToInt32(itemDotDanhGia["IDDotDanhGia"]), ConvertUtility.ToInt32(item["UserID"]));

                        if (dtDiemTB != null && dtDiemTB.Rows.Count > 0)
                        {
                            DiemDGCV += ConvertUtility.ToDouble(dtDiemTB.Rows[0]["DiemTB"]);
                            count++;
                        }
                    }

                    DiemDGCV = DiemDGCV / count;
                    if (count == 0) count = 1;

                    TongDiemDGCV = (DiemDGCV * 50 / 100) + (DiemCLCV * 10 / 100) + (DiemTDCV * 10 / 100);
                    TongDiemDGCV = Math.Round(TongDiemDGCV, 2, MidpointRounding.AwayFromZero);
                    TongDiemDGCV1 = (((DiemDGCV * 5) + (DiemCLCV) + (DiemTDCV))) / 7;

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        diemKyLuat = ConvertUtility.ToDouble(ds.Tables[1].Rows[0]["DiemKyLuat"].ToString());
                        diemKyLuat1 = diemKyLuat;
                        diemKyLuat = diemKyLuat * 20 / 100;

                        diemKyLuat = Math.Round(diemKyLuat, 2, MidpointRounding.AwayFromZero);
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        DiemDongNghiepDanhGia = ConvertUtility.ToDouble(ds.Tables[2].Rows[0]["DiemDongNghiepDanhGia"]);

                        if (DiemDongNghiepDanhGia == 0)
                        {
                            DiemDongNghiepDanhGia = 10;
                            DiemDongNghiepDanhGia1 = 100;
                        }
                        else
                        {
                            DiemDongNghiepDanhGia1 = DiemDongNghiepDanhGia;
                            DiemDongNghiepDanhGia = DiemDongNghiepDanhGia * 10 / 100;
                        }
                        DiemDongNghiepDanhGia = Math.Round(DiemDongNghiepDanhGia, 2);
                    }

                    string ten = "";
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        ten = ds.Tables[3].Rows[0]["HoTen"].ToString();
                    }

                    double TongDiem = Math.Round(TongDiemDGCV, 2, MidpointRounding.AwayFromZero);
                    TongDiem += Math.Round(diemKyLuat, 2, MidpointRounding.AwayFromZero);
                    TongDiem += Math.Round(DiemDongNghiepDanhGia, 2, MidpointRounding.AwayFromZero);
                    TongDiem = Math.Round(TongDiem, 2);

                    string xepLoai = GetXepLoai(TongDiem);

                    row["UserID"] = item["UserID"];
                    row["Bộ phận"] = tenTrungTam;
                    row["Họ tên"] = ten;
                    row["Điểm đánh giá công việc"] = Math.Round(TongDiemDGCV1, 2, MidpointRounding.AwayFromZero);
                    row["Điểm kỷ luật và văn hóa doanh nghiệp"] = Math.Round(diemKyLuat1, 2, MidpointRounding.AwayFromZero);
                    row["Điểm đồng nghiệp đánh giá"] = Math.Round(DiemDongNghiepDanhGia1, 2, MidpointRounding.AwayFromZero);
                    row["Tổng điểm"] = Math.Round(TongDiem, 2, MidpointRounding.AwayFromZero);
                    row["Xếp loại"] = xepLoai;

                    dtUsersTemp.Rows.Add(row);
                }
            }

            //-------sort----------
            DataView dv = new DataView(dtUsersTemp);
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
                Label lblXepLoai = (Label)e.Row.FindControl("lblXepLoai");
                Label lblTongDiem = (Label)e.Row.FindControl("lblTongDiem");
                Label lblDiemDGCV = (Label)e.Row.FindControl("lblDiemDGCV");
                Label lblDiemKL = (Label)e.Row.FindControl("lblDiemKL");
                Label lblDiemDNDG = (Label)e.Row.FindControl("lblDiemDNDG");
                HyperLink hplName = (HyperLink)e.Row.FindControl("hplName");

                DataRowView curData = (DataRowView)e.Row.DataItem;

                lblXepLoai.Text = GetXepLoai(Math.Round(ConvertUtility.ToDouble(curData["Tổng điểm"]), 2)) ;
                lblTongDiem.Text = Math.Round(ConvertUtility.ToDouble(curData["Tổng điểm"]), 2).ToString() + "%";
                lblDiemDGCV.Text = Math.Round(ConvertUtility.ToDouble(curData["Điểm đánh giá công việc"]), 2).ToString() + "%";
                lblDiemKL.Text = Math.Round(ConvertUtility.ToDouble(curData["Điểm kỷ luật và văn hóa doanh nghiệp"]), 2).ToString() + "%";
                lblDiemDNDG.Text = Math.Round(ConvertUtility.ToDouble(curData["Điểm đồng nghiệp đánh giá"]), 2).ToString() + "%";

                hplName.NavigateUrl = AppEnv.AdminUrlParams("checkpoint") + "&idDotDanhGia=" + dropDotDanhGia.SelectedValue + "&idNhanVien=" + curData["UserID"].ToString();
        
            }
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
            dtUsersTemp.Columns.Add("Điểm đánh giá công việc", typeof(string));
            dtUsersTemp.Columns.Add("Điểm kỷ luật và văn hóa doanh nghiệp", typeof(string));
            dtUsersTemp.Columns.Add("Điểm đồng nghiệp đánh giá", typeof(string));
            dtUsersTemp.Columns.Add("Tổng điểm", typeof(string));
            //dtUsersTemp.Columns.Add("Xếp loại", typeof(string));

            BoPhanInfo _BoPhanInfo = BoPhanController.GetInfo(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            int loaiTrungTam = _BoPhanInfo.Loai;
            string tenTrungTam = ConvertUtility.ToString(dropTrungTam.SelectedItem.Text);

            DataTable dtUsers = DotDanhGiaController.GetAllNhanVienInDotDanhGiaExport(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue));

            #region ket qua danh gia checkpoint

            foreach (DataRow item in dtUsers.Rows)
            {
                DataSet ds = DotDanhGiaController.DanhGiaCheckPoint_DGCBCNVDanhGia_TongDiemCongThucMoi(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(item["UserID"]));
                if (ds != null)
                {
                    DataRow row = dtUsersTemp.NewRow();

                    double TongDiemDGCV = 0;
                    double TongDiemDGCV1 = 0;
                    double diemKyLuat = 0;
                    double diemKyLuat1 = 0;
                    double DiemDongNghiepDanhGia = 0;
                    double DiemDongNghiepDanhGia1 = 0;

                    double DiemCLCV = 100;
                    double DiemTDCV = 100;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DiemCLCV = ConvertUtility.ToDouble(ds.Tables[0].Rows[0]["DiemCLCV"].ToString());
                        DiemTDCV = ConvertUtility.ToDouble(ds.Tables[0].Rows[0]["DiemTDCV"].ToString());
                    }
                    double DiemDGCV = 0;

                    DataTable dtDotDanhGiaByCheckpoint = DotDanhGiaController.CheckPoint_GetAllDotDanhGiaByCheckpoint(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

                    int count = 0;

                    foreach (DataRow itemDotDanhGia in dtDotDanhGiaByCheckpoint.Rows)
                    {
                        DataTable dtDiemTB = DotDanhGiaController.CheckPoint_DanhGiaCongViec_GetDiemTB(ConvertUtility.ToInt32(itemDotDanhGia["IDDotDanhGia"]), ConvertUtility.ToInt32(item["UserID"]));

                        if (dtDiemTB != null && dtDiemTB.Rows.Count > 0)
                        {
                            DiemDGCV += ConvertUtility.ToDouble(dtDiemTB.Rows[0]["DiemTB"]);
                            count++;
                        }
                    }

                    DiemDGCV = DiemDGCV / count;
                    if (count == 0) count = 1;

                    TongDiemDGCV = (DiemDGCV * 50 / 100) + (DiemCLCV * 10 / 100) + (DiemTDCV * 10 / 100);
                    TongDiemDGCV1 = (((DiemDGCV * 5) + (DiemCLCV) + (DiemTDCV))) / 7;
                    TongDiemDGCV = Math.Round(TongDiemDGCV, 2, MidpointRounding.AwayFromZero);

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        diemKyLuat = ConvertUtility.ToDouble(ds.Tables[1].Rows[0]["DiemKyLuat"].ToString());
                        diemKyLuat1 = diemKyLuat;
                        diemKyLuat = diemKyLuat * 20 / 100;

                        diemKyLuat = Math.Round(diemKyLuat, 2, MidpointRounding.AwayFromZero);
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        DiemDongNghiepDanhGia = ConvertUtility.ToDouble(ds.Tables[2].Rows[0]["DiemDongNghiepDanhGia"]);

                        if (DiemDongNghiepDanhGia == 0)
                        {
                            DiemDongNghiepDanhGia = 10;
                            DiemDongNghiepDanhGia1 = 100;
                        }
                        else
                        {
                            DiemDongNghiepDanhGia1 = DiemDongNghiepDanhGia;
                            DiemDongNghiepDanhGia = DiemDongNghiepDanhGia * 10 / 100;
                        }
                        DiemDongNghiepDanhGia = Math.Round(DiemDongNghiepDanhGia, 2);
                    }

                    string ten = "";
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        ten = ds.Tables[3].Rows[0]["HoTen"].ToString();
                    }

                    double TongDiem = Math.Round(TongDiemDGCV, 2, MidpointRounding.AwayFromZero);
                    TongDiem += Math.Round(diemKyLuat, 2, MidpointRounding.AwayFromZero);
                    TongDiem += Math.Round(DiemDongNghiepDanhGia, 2, MidpointRounding.AwayFromZero);
                    TongDiem = Math.Round(TongDiem, 2);

                    string xepLoai = GetXepLoai(TongDiem);

                    row["Bộ phận"] = tenTrungTam;
                    row["Họ tên"] = ten;
                    row["Điểm đánh giá công việc"] = (Math.Round(TongDiemDGCV1, 2, MidpointRounding.AwayFromZero) / 100).ToString();
                    row["Điểm kỷ luật và văn hóa doanh nghiệp"] = (Math.Round(diemKyLuat1, 2, MidpointRounding.AwayFromZero) / 100).ToString();
                    row["Điểm đồng nghiệp đánh giá"] = (Math.Round(DiemDongNghiepDanhGia1, 2, MidpointRounding.AwayFromZero) / 100).ToString();
                    row["Tổng điểm"] = Math.Round(TongDiem, 2, MidpointRounding.AwayFromZero)/100;
                    //row["Xếp loại"] = xepLoai;

                    dtUsersTemp.Rows.Add(row);
                }
            }

            #endregion

            ImportExcelToDataTable.ExportToExcel(dtUsersTemp, "KQDanhGiaCaNhanCheckPoint_" + dropTrungTam.SelectedItem.Text + ".csv");

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

        private string GetXepLoai(double TongDiem)
        {
            //A+	Từ 105% trở lên	
            //A	Từ 101% đến 105%	
            //B	Từ 94% đến 101%	
            //C	Từ 88% đến 94%	
            //D	Dưới 88%	

            if (TongDiem >= 105)
            {
                return "A+";
            }
            else if (TongDiem >= 101 && TongDiem < 105)
            {
                return "A";
            }
            else if (TongDiem >= 94 && TongDiem < 101)
            {
                return "B";
            }
            else if (TongDiem >= 88 && TongDiem < 94)
            {
                return "C";
            }
            else //if (TongDiem >= 105)
            {
                return "D";
            }
        }
    }
}