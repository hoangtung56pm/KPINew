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
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using VmgPortal.Modules.KPIData.Library.DanhGia;

namespace VmgPortal.Modules.KPIData.Admin.BaoCao
{
    public partial class BaoCaoNgayBoPhan : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["DropDownPageItems"] = 10;

                dropTrungTam.DataSource = BoPhanController.BoPhan_GetAllActive();
                dropTrungTam.DataBind();

                if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                {
                    dropTrungTam.Enabled = false;
                }
                dropTrungTam.SelectedValue = CurrentUser.IDTrungTam.ToString();
                dropYear.SelectedValue = DateTime.Now.Year.ToString();
                dropMonth.SelectedValue = DateTime.Now.Month.ToString();

                BindDay();

                dropDay.SelectedValue = DateTime.Now.Day.ToString();

                //DataTable dtPhong;
                //if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                //{
                //    dropTrungTam.Enabled = false;

                //    if (CurrentUser.RoleID != (int)Constants.Role.TruongBoPhanKhoiHoTro && CurrentUser.RoleID != (int)Constants.Role.TruongBoPhanKhoiKinhDoanh)
                //    {
                //        dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), CurrentUser.UserID);
                //    }
                //    else
                //    {
                //        dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
                //    }
                //}
                //else
                //{
                //    dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
                //}

                //dropPhongBan.DataSource = dtPhong;
                //dropPhongBan.DataBind();
                //dropPhongBan.Items.Insert(0, new ListItem("----------All----------", "0"));

                dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
                dropDotDanhGia.DataBind();

                BindUser();
            }
        }

        private void BindUser()
        {
            DataTable dtNhanVien = null;
            if (CurrentUser.RoleID != (int)Constants.Role.TruongBoPhanKhoiHoTro && CurrentUser.RoleID != (int)Constants.Role.TruongBoPhanKhoiKinhDoanh)
            {
                if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                {
                    //if (ConvertUtility.ToInt32(dropPhongBan.SelectedValue) > 0)
                    //{
                    dtNhanVien = DotDanhGiaController.GetAllNhanVien(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 0, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));
                    //}
                }
                else
                {
                    dtNhanVien = DotDanhGiaController.GetAllNhanVien(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 0, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));
                }
            }
            else
            {
                dtNhanVien = DotDanhGiaController.GetAllNhanVien(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 0, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));
            }

            if (dtNhanVien != null && dtNhanVien.Rows.Count > 0)
            {
                DataTable dtNew = dtNhanVien.Clone();

                foreach (DataRow item in dtNhanVien.Rows)
                {
                    DataRow rowNew = dtNew.NewRow();
                    rowNew["UserID"] = item["UserID"];

                    DataTable dtCongViec = DotDanhGiaController.GetAllCongViecGiaoChoNhanVienKTXVaPS(ConvertUtility.ToInt32(item["UserID"]), 1, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

                    double tyTrongCVDuocGiao = 0;
                    foreach (DataRow row in dtCongViec.Rows)
                    {
                        int idCongViecKPI = ConvertUtility.ToInt32(row["IDCongViecKPI"]);

                        DataTable dtTyTrongKPI = DotDanhGiaController.GetTyTrongCongViec(idCongViecKPI, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 0, ConvertUtility.ToInt32(item["UserID"]));//, ConvertUtility.ToInt32(dropPhongBan.SelectedValue), ConvertUtility.ToInt32(item["UserID"])

                        if (dtTyTrongKPI != null && dtTyTrongKPI.Rows.Count > 0)
                        {
                            tyTrongCVDuocGiao += Math.Round(ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TyTrong"]), 3);

                        }
                        else
                        {
                            tyTrongCVDuocGiao += Math.Round(ConvertUtility.ToDouble(row["TyTrong"]), 3);
                        }
                    }

                    rowNew["UserName"] = "( " + tyTrongCVDuocGiao + "%) " + item["UserName"].ToString();

                    dtNew.Rows.Add(rowNew);
                }

                dropUser.DataSource = dtNew;
                dropUser.DataBind();
                dropUser.Items.Insert(0, new ListItem("All", "0"));
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            int idTrungTam = ConvertUtility.ToInt32(dropTrungTam.SelectedValue);
            int idPhongBan = 0;
            DateTime dtTime = new DateTime(ConvertUtility.ToInt32(dropYear.SelectedValue), ConvertUtility.ToInt32(dropMonth.SelectedValue), ConvertUtility.ToInt32(dropDay.SelectedValue));
            int idDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);

            DataTable dtCongViecKeHoachThangTemp = new DataTable();

            dtCongViecKeHoachThangTemp.Columns.Add("CreateBy", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("CongViecKPI", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("CongViecCha", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("Ten", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("TyTrong", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("SoGio", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("TyLeHoanThanh", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("KetQua", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("LyDo", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("DeXuat", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("Level", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("ID", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("IDTrungTam", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("IDPhongBan", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("ParentID", typeof(String));

            DataTable dt = QuanLyCongViecBaoCaoNgayController.GetAllBaoCaoNgayBoPhan(idTrungTam, idPhongBan, dtTime, idDotDanhGia, ConvertUtility.ToInt32(dropUser.SelectedValue));

            //-------sort----------
            DataView dv = new DataView(dt);
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

            if (dt != null)
            {
                lblTotalBottom.Text = dt.Rows.Count.ToString();
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
                DataRowView curData = (DataRowView)e.Row.DataItem;

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
            lblStatusUpdate.Text = "";
        }

        protected void dropTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dropPhongBan.Items.Clear();

            //DataTable dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue)); ;
            //dropPhongBan.DataSource = dtPhong;
            //dropPhongBan.DataBind();
            //dropPhongBan.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));

            BindUser();
        }

        //protected void dropPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindUser();
        //}

        protected void dropMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropMonth.SelectedValue == "0")
            {
                dropDay.Items.Clear();
                dropDay.Items.Add(new ListItem("--All--", "0"));
            }
            else
            {
                BindDay();
            }
        }

        private void BindDay()
        {
            dropDay.Items.Clear();
            int days = DateTime.DaysInMonth(ConvertUtility.ToInt32(dropYear.SelectedValue), ConvertUtility.ToInt32(dropMonth.SelectedValue));

            for (int i = 1; i < days + 1; i++)
            {
                dropDay.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        protected void dropDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStatusUpdate.Text = "";
        }

        protected void dropUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStatusUpdate.Text = "";
        }

        protected void btnGuiBaoCaoNgayBoPhan_Click(object sender, EventArgs e)
        {
            lblStatusUpdate.Text = "";
            BoPhanInfo infoBoPhan = BoPhanController.GetInfo(CurrentUser.IDTrungTam);
            if (infoBoPhan != null)
            {
                bool value = EmailUtility.DoSendMail("tuan.pham@vmgmedia.vn", "", "Bộ phận " + infoBoPhan.Ten + " gửi báo cáo ngày", "Bộ phận " + infoBoPhan.Ten + " đã cập nhật báo cáo ngày vào phần mềm. Đề nghị bạn vào kiểm tra.");
            }
        }

        protected void btnUpdateVaoBoPhan_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow item in dtgUsers.Rows)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkCheck");
                Label lblID = (Label)item.FindControl("lblID");

                int id = ConvertUtility.ToInt32(lblID.Text);

                if (chk.Checked)
                {
                    QuanLyCongViecBaoCaoNgayController.DeleteBaoCaoNgayBoPhan(id);
                }

            }
        }

        protected void dtgUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void dtgUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dtgUsers.EditIndex = e.NewEditIndex;

        }

        protected void dtgUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dtgUsers.EditIndex = -1;
        }

        protected void dtgUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)dtgUsers.Rows[e.RowIndex];


            Label lblID = (Label)row.FindControl("lblID");
            int id = ConvertUtility.ToInt32(lblID.Text);

            TextBox txtCongViecCha = (TextBox)row.FindControl("txtCongViecCha");

            TextBox txtTenCongViec = (TextBox)row.FindControl("txtTenCongViec");

            TextBox txtKeHoach = (TextBox)row.FindControl("txtKeHoach");

            TextBox txtTyLeHoanThanh = (TextBox)row.FindControl("txtTyLeHoanThanh");

            TextBox txtKetQua = (TextBox)row.FindControl("txtKetQua");

            TextBox txtLyDo = (TextBox)row.FindControl("txtLyDo");

            TextBox txtDeXuat = (TextBox)row.FindControl("txtDeXuat");

            QuanLyCongViecBaoCaoNgayInfo info = QuanLyCongViecBaoCaoNgayController.GetBaoCaoNgayBoPhanInfo(id);
            if (info == null)
            {
                return;
            }

            info.Ten = txtTenCongViec.Text;
            info.KeHoach = txtKeHoach.Text;
            info.ParentID = txtCongViecCha.Text;
            info.KetQua = txtKetQua.Text;
            info.TyLeHoanThanh = txtTyLeHoanThanh.Text;
            info.LyDo = txtLyDo.Text;
            info.DeXuat = txtDeXuat.Text;
            info.CreatedOn = new DateTime(ConvertUtility.ToInt32(dropYear.SelectedValue), ConvertUtility.ToInt32(dropMonth.SelectedValue), ConvertUtility.ToInt32(dropDay.SelectedValue));
            try
            {
                QuanLyCongViecBaoCaoNgayController.UpdateBaoCaoNgayBoPhan(info);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            dtgUsers.EditIndex = -1;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            QuanLyCongViecBaoCaoNgayInfo info = new QuanLyCongViecBaoCaoNgayInfo();
            info.IDCongViecKPI = 0;
            info.Ten = txtCongViec.Text;
            info.KeHoach = txtKeHoach.Text;
            info.ParentID = txtCongViecLon.Text;
            info.TyTrong = 0;
            info.KetQua = txtKetQua.Text;
            info.TyLeHoanThanh = txtTyLeHoanThanh.Text;
            info.IDTrungTam = ConvertUtility.ToInt32(dropTrungTam.SelectedValue);
            info.IDPhongBan = 0;// ConvertUtility.ToInt32(dropPhongBan.SelectedValue);
            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.SoGio = 0;
            info.CreateBy = CurrentUser.UserID;
            info.LyDo = txtLyDo.Text;
            info.DeXuat = txtDeXuat.Text;
            info.CreatedOn = new DateTime(ConvertUtility.ToInt32(dropYear.SelectedValue), ConvertUtility.ToInt32(dropMonth.SelectedValue), ConvertUtility.ToInt32(dropDay.SelectedValue));
            try
            {
                QuanLyCongViecBaoCaoNgayController.InsertBaoCaoNgayBoPhan(info);

                lblStatusUpdate.Text = MiscUtility.MSG_UPDATE_SUCCESS;
            }
            catch (Exception ex)
            {
                lblStatusUpdate.Text = ex.Message;
            }
        }

        protected void btnCapNhatCVTuNhanVien_Click(object sender, EventArgs e)
        {
            int idTrungTam = ConvertUtility.ToInt32(dropTrungTam.SelectedValue);
            DateTime dtTime = new DateTime(ConvertUtility.ToInt32(dropYear.SelectedValue), ConvertUtility.ToInt32(dropMonth.SelectedValue), ConvertUtility.ToInt32(dropDay.SelectedValue));
            int idDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);

            DataTable dtCongViecKeHoachThangTemp = new DataTable();

            dtCongViecKeHoachThangTemp.Columns.Add("CreateBy", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("CongViecKPI", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("CongViecCha", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("Ten", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("TyTrong", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("SoGio", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("TyLeHoanThanh", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("KetQua", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("LyDo", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("DeXuat", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("Level", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("ID", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("IDTrungTam", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("IDPhongBan", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("ParentID", typeof(String));

            DataTable dt = null;
            dt = QuanLyCongViecBaoCaoNgayController.GetAllBaoCaoNgay(idTrungTam, dtTime, 0, 0, idDotDanhGia); //QuanLyCongViecBaoCaoNgayController.GetAllBaoCaoNgay(idTrungTam, dtTime, ConvertUtility.ToInt32(dropUser.SelectedValue), CurrentUser.UserID, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    QuanLyCongViecBaoCaoNgayInfo info = QuanLyCongViecBaoCaoNgayController.GetInfo(ConvertUtility.ToInt32(item["ID"]));

                    QuanLyCongViecBaoCaoNgayController.InsertBaoCaoNgayBoPhan(info);

                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    lblStatusUpdate.Text = "Bạn đã tổng hợp thành công báo cáo ngày của nhân viên";
                }
                else
                {
                    lblStatusUpdate.Text = "Không có báo cáo ngày của nhân viên";
                }
            }
            else
            {
                lblStatusUpdate.Text = "Không có báo cáo ngày của nhân viên";
            }
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            lblStatusUpdate.Text = "";
            int idDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            int idBoPhan = ConvertUtility.ToInt32(dropTrungTam.SelectedValue);
            
            DataTable dtCongViecPhatSinhReturn;
            DataTable dtCongViecKeHoachThangReturn;
            DataTable dtCongViecThuongXuyenReturn;

            #region Cong viec thuong xuyen

            DataSet ds = DanhGiaThang_BoPhanTTCVController.GetAllCongViecPhong_ForExport(1, idDotDanhGia, idBoPhan, 0);

            DataTable dtCongViecThuongXuyen = ds.Tables[0];
            DataTable dtCongViecThuongXuyenTemp = new DataTable();

            dtCongViecThuongXuyenTemp.Columns.Add("ID", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("IDPhongBan", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("IDParent", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("Level", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("IDCongViec", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("Tuan", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("NguoiThamGia", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("STT", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("TenCongViec", typeof(String));

            #region Tuan 1

            dtCongViecThuongXuyenTemp.Columns.Add("T1_T2", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T2_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T2_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T2_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T1_T3", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T3_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T3_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T3_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T1_T4", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T4_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T4_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T4_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T1_T5", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T5_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T5_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T5_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T1_T6", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T6_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T6_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T6_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T1_T7", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T7_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T7_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T7_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T1_T8", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T8_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T8_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T1_T8_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T1_KQ", typeof(String));

            #endregion

            #region Tuan2

            dtCongViecThuongXuyenTemp.Columns.Add("T2_T2", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T2_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T2_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T2_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T2_T3", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T3_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T3_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T3_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T2_T4", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T4_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T4_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T4_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T2_T5", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T5_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T5_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T5_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T2_T6", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T6_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T6_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T6_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T2_T7", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T7_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T7_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T7_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T2_T8", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T8_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T8_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T2_T8_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T2_KQ", typeof(String));

            #endregion

            #region Tuan3

            dtCongViecThuongXuyenTemp.Columns.Add("T3_T2", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T2_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T2_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T2_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T3_T3", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T3_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T3_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T3_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T3_T4", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T4_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T4_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T4_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T3_T5", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T5_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T5_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T5_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T3_T6", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T6_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T6_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T6_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T3_T7", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T7_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T7_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T7_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T3_T8", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T8_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T8_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T3_T8_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T3_KQ", typeof(String));

            #endregion

            #region Tuan4

            dtCongViecThuongXuyenTemp.Columns.Add("T4_T2", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T2_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T2_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T2_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T4_T3", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T3_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T3_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T3_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T4_T4", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T4_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T4_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T4_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T4_T5", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T5_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T5_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T5_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T4_T6", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T6_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T6_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T6_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T4_T7", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T7_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T7_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T7_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T4_T8", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T8_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T8_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T4_T8_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T4_KQ", typeof(String));

            #endregion

            #region Tuan5

            dtCongViecThuongXuyenTemp.Columns.Add("T5_T2", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T2_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T2_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T2_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T5_T3", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T3_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T3_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T3_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T5_T4", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T4_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T4_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T4_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T5_T5", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T5_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T5_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T5_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T5_T6", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T6_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T6_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T6_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T5_T7", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T7_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T7_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T7_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T5_T8", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T8_TK", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T8_Status", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("T5_T8_TT", typeof(String));

            dtCongViecThuongXuyenTemp.Columns.Add("T5_KQ", typeof(String));
            dtCongViecThuongXuyenTemp.Columns.Add("KQT", typeof(String));
            #endregion

            DotDanhGiaInfo infoDotDanhGia = DotDanhGiaController.GetInfo(idDotDanhGia);

            int i = 1;
            int returnIndex = 0;
            DateTime ngaybatdau = infoDotDanhGia.ThoiGianKetThuc;
            dtCongViecThuongXuyenReturn = DanhGiaThang_BoPhanTTCVController.BuildRecursiveKeHoachCongViecBoPhanExport(dtCongViecThuongXuyen, dtCongViecThuongXuyenTemp, idDotDanhGia, ngaybatdau, i, out returnIndex);

            #endregion

            #region Cong viec ke hoach thang

            DataSet ds1 = DanhGiaThang_BoPhanTTCVController.GetAllCongViecPhong_ForExport(2, idDotDanhGia, idBoPhan, 0);
            DataTable dtCongViecKeHoachThang = ds1.Tables[0];

            DataTable dtCongViecKeHoachThangTemp = new DataTable();

            dtCongViecKeHoachThangTemp.Columns.Add("ID", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("IDPhongBan", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("IDParent", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("Level", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("IDCongViec", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("Tuan", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("NguoiThamGia", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("STT", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("TenCongViec", typeof(String));
            
            #region Tuan 1

            dtCongViecKeHoachThangTemp.Columns.Add("T1_T2", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T2_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T2_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T2_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T1_T3", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T3_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T3_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T3_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T1_T4", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T4_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T4_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T4_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T1_T5", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T5_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T5_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T5_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T1_T6", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T6_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T6_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T6_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T1_T7", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T7_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T7_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T7_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T1_T8", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T8_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T8_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T1_T8_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T1_KQ", typeof(String));

            #endregion

            #region Tuan2

            dtCongViecKeHoachThangTemp.Columns.Add("T2_T2", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T2_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T2_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T2_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T2_T3", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T3_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T3_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T3_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T2_T4", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T4_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T4_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T4_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T2_T5", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T5_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T5_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T5_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T2_T6", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T6_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T6_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T6_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T2_T7", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T7_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T7_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T7_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T2_T8", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T8_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T8_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T2_T8_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T2_KQ", typeof(String));

            #endregion

            #region Tuan3

            dtCongViecKeHoachThangTemp.Columns.Add("T3_T2", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T2_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T2_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T2_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T3_T3", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T3_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T3_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T3_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T3_T4", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T4_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T4_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T4_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T3_T5", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T5_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T5_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T5_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T3_T6", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T6_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T6_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T6_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T3_T7", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T7_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T7_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T7_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T3_T8", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T8_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T8_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T3_T8_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T3_KQ", typeof(String));

            #endregion

            #region Tuan4

            dtCongViecKeHoachThangTemp.Columns.Add("T4_T2", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T2_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T2_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T2_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T4_T3", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T3_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T3_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T3_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T4_T4", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T4_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T4_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T4_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T4_T5", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T5_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T5_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T5_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T4_T6", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T6_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T6_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T6_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T4_T7", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T7_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T7_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T7_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T4_T8", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T8_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T8_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T4_T8_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T4_KQ", typeof(String));

            #endregion

            #region Tuan5

            dtCongViecKeHoachThangTemp.Columns.Add("T5_T2", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T2_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T2_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T2_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T5_T3", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T3_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T3_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T3_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T5_T4", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T4_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T4_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T4_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T5_T5", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T5_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T5_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T5_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T5_T6", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T6_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T6_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T6_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T5_T7", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T7_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T7_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T7_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T5_T8", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T8_TK", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T8_Status", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("T5_T8_TT", typeof(String));

            dtCongViecKeHoachThangTemp.Columns.Add("T5_KQ", typeof(String));
            dtCongViecKeHoachThangTemp.Columns.Add("KQT", typeof(String));
            #endregion

            dtCongViecKeHoachThangReturn = DanhGiaThang_BoPhanTTCVController.BuildRecursiveKeHoachCongViecBoPhanExport(dtCongViecKeHoachThang, dtCongViecKeHoachThangTemp, idDotDanhGia, ngaybatdau, returnIndex, out returnIndex);

            DataRow row = dtCongViecThuongXuyenReturn.NewRow();
            row["ID"] = "##9999##";
            row["IDPhongBan"] = "";
            row["IDParent"] = "";
            row["Level"] = "";
            row["IDCongViec"] = "";
            row["Tuan"] = "";
            row["NguoiThamGia"] = "";
            row["STT"] = "";
            row["TenCongViec"] = "Kế hoạch tháng";

            #region Tuan 1

            row["T1_T2"] = "";
            row["T1_T2_TK"] = "";
            row["T1_T2_Status"] = "";
            row["T1_T2_TT"] = "";

            row["T1_T3"] = "";
            row["T1_T3_TK"] = "";
            row["T1_T3_Status"] = "";
            row["T1_T3_TT"] = "";

            row["T1_T4"] = "";
            row["T1_T4_TK"] = "";
            row["T1_T4_Status"] = "";
            row["T1_T4_TT"] = "";

            row["T1_T5"] = "";
            row["T1_T5_TK"] = "";
            row["T1_T5_Status"] = "";
            row["T1_T5_TT"] = "";

            row["T1_T6"] = "";
            row["T1_T6_TK"] = "";
            row["T1_T6_Status"] = "";
            row["T1_T6_TT"] = "";

            row["T1_T7"] = "";
            row["T1_T7_TK"] = "";
            row["T1_T7_Status"] = "";
            row["T1_T7_TT"] = "";

            row["T1_T8"] = "";
            row["T1_T8_TK"] = "";
            row["T1_T8_Status"] = "";
            row["T1_T8_TT"] = "";

            row["T1_KQ"] = "";

            #endregion

            #region Tuan 2

            row["T2_T2"] = "";
            row["T2_T2_TK"] = "";
            row["T2_T2_Status"] = "";
            row["T2_T2_TT"] = "";

            row["T2_T3"] = "";
            row["T2_T3_TK"] = "";
            row["T2_T3_Status"] = "";
            row["T2_T3_TT"] = "";

            row["T2_T4"] = "";
            row["T2_T4_TK"] = "";
            row["T2_T4_Status"] = "";
            row["T2_T4_TT"] = "";

            row["T2_T5"] = "";
            row["T2_T5_TK"] = "";
            row["T2_T5_Status"] = "";
            row["T2_T5_TT"] = "";

            row["T2_T6"] = "";
            row["T2_T6_TK"] = "";
            row["T2_T6_Status"] = "";
            row["T2_T6_TT"] = "";

            row["T2_T7"] = "";
            row["T2_T7_TK"] = "";
            row["T2_T7_Status"] = "";
            row["T2_T7_TT"] = "";

            row["T2_T8"] = "";
            row["T2_T8_TK"] = "";
            row["T2_T8_Status"] = "";
            row["T2_T8_TT"] = "";

            row["T2_KQ"] = "";

            #endregion

            #region Tuan 3

            row["T3_T2"] = "";
            row["T3_T2_TK"] = "";
            row["T3_T2_Status"] = "";
            row["T3_T2_TT"] = "";

            row["T3_T3"] = "";
            row["T3_T3_TK"] = "";
            row["T3_T3_Status"] = "";
            row["T3_T3_TT"] = "";

            row["T3_T4"] = "";
            row["T3_T4_TK"] = "";
            row["T3_T4_Status"] = "";
            row["T3_T4_TT"] = "";

            row["T3_T5"] = "";
            row["T3_T5_TK"] = "";
            row["T3_T5_Status"] = "";
            row["T3_T5_TT"] = "";

            row["T3_T6"] = "";
            row["T3_T6_TK"] = "";
            row["T3_T6_Status"] = "";
            row["T3_T6_TT"] = "";

            row["T3_T7"] = "";
            row["T3_T7_TK"] = "";
            row["T3_T7_Status"] = "";
            row["T3_T7_TT"] = "";

            row["T3_T8"] = "";
            row["T3_T8_TK"] = "";
            row["T3_T8_Status"] = "";
            row["T3_T8_TT"] = "";

            row["T3_KQ"] = "";

            #endregion

            #region Tuan 4

            row["T4_T2"] = "";
            row["T4_T2_TK"] = "";
            row["T4_T2_Status"] = "";
            row["T4_T2_TT"] = "";

            row["T4_T3"] = "";
            row["T4_T3_TK"] = "";
            row["T4_T3_Status"] = "";
            row["T4_T3_TT"] = "";

            row["T4_T4"] = "";
            row["T4_T4_TK"] = "";
            row["T4_T4_Status"] = "";
            row["T4_T4_TT"] = "";

            row["T4_T5"] = "";
            row["T4_T5_TK"] = "";
            row["T4_T5_Status"] = "";
            row["T4_T5_TT"] = "";

            row["T4_T6"] = "";
            row["T4_T6_TK"] = "";
            row["T4_T6_Status"] = "";
            row["T4_T6_TT"] = "";

            row["T4_T7"] = "";
            row["T4_T7_TK"] = "";
            row["T4_T7_Status"] = "";
            row["T4_T7_TT"] = "";

            row["T4_T8"] = "";
            row["T4_T8_TK"] = "";
            row["T4_T8_Status"] = "";
            row["T4_T8_TT"] = "";

            row["T4_KQ"] = "";

            #endregion

            #region Tuan 5

            row["T5_T2"] = "";
            row["T5_T2_TK"] = "";
            row["T5_T2_Status"] = "";
            row["T5_T2_TT"] = "";

            row["T5_T3"] = "";
            row["T5_T3_TK"] = "";
            row["T5_T3_Status"] = "";
            row["T5_T3_TT"] = "";

            row["T5_T4"] = "";
            row["T5_T4_TK"] = "";
            row["T5_T4_Status"] = "";
            row["T5_T4_TT"] = "";

            row["T5_T5"] = "";
            row["T5_T5_TK"] = "";
            row["T5_T5_Status"] = "";
            row["T5_T5_TT"] = "";

            row["T5_T6"] = "";
            row["T5_T6_TK"] = "";
            row["T5_T6_Status"] = "";
            row["T5_T6_TT"] = "";

            row["T5_T7"] = "";
            row["T5_T7_TK"] = "";
            row["T5_T7_Status"] = "";
            row["T5_T7_TT"] = "";

            row["T5_T8"] = "";
            row["T5_T8_TK"] = "";
            row["T5_T8_Status"] = "";
            row["T5_T8_TT"] = "";

            row["T5_KQ"] = "";
            row["KQT"] = "";

            #endregion

            dtCongViecThuongXuyenReturn.Rows.Add(row);

            foreach (DataRow item in dtCongViecKeHoachThangReturn.Rows)
            {
                row = dtCongViecThuongXuyenReturn.NewRow();

                row["ID"] = item["ID"];
                row["IDPhongBan"] = item["IDPhongBan"];
                row["IDParent"] = item["IDParent"];
                row["Level"] = item["Level"];
                row["IDCongViec"] = item["IDCongViec"];
                row["Tuan"] = item["Tuan"];
                row["NguoiThamGia"] = item["NguoiThamGia"];
                row["STT"] = item["STT"];
                row["TenCongViec"] = item["TenCongViec"];

                #region Tuan 1

                row["T1_T2"] = item["T1_T2"];
                row["T1_T2_TK"] = item["T1_T2_TK"];
                row["T1_T2_Status"] = item["T1_T2_Status"];
                row["T1_T2_TT"] = item["T1_T2_TT"];

                row["T1_T3"] = item["T1_T3"];
                row["T1_T3_TK"] = item["T1_T3_TK"];
                row["T1_T3_Status"] = item["T1_T3_Status"];
                row["T1_T3_TT"] = item["T1_T3_TT"];

                row["T1_T4"] = item["T1_T4"];
                row["T1_T4_TK"] = item["T1_T4_TK"];
                row["T1_T4_Status"] = item["T1_T4_Status"];
                row["T1_T4_TT"] = item["T1_T4_TT"];

                row["T1_T5"] = item["T1_T5"];
                row["T1_T5_TK"] = item["T1_T5_TK"];
                row["T1_T5_Status"] = item["T1_T5_Status"];
                row["T1_T5_TT"] = item["T1_T5_TT"];

                row["T1_T6"] = item["T1_T6"];
                row["T1_T6_TK"] = item["T1_T6_TK"];
                row["T1_T6_Status"] = item["T1_T6_Status"];
                row["T1_T6_TT"] = item["T1_T6_TT"];

                row["T1_T7"] = item["T1_T7"];
                row["T1_T7_TK"] = item["T1_T7_TK"];
                row["T1_T7_Status"] = item["T1_T7_Status"];
                row["T1_T7_TT"] = item["T1_T7_TT"];

                row["T1_T8"] = item["T1_T8"];
                row["T1_T8_TK"] = item["T1_T8_TK"];
                row["T1_T8_Status"] = item["T1_T8_Status"];
                row["T1_T8_TT"] = item["T1_T8_TT"];

                row["T1_KQ"] = item["T1_KQ"];

                #endregion

                #region Tuan 2

                row["T2_T2"] = item["T2_T2"];
                row["T2_T2_TK"] = item["T2_T2_TK"];
                row["T2_T2_Status"] = item["T2_T2_Status"];
                row["T2_T2_TT"] = item["T2_T2_TT"];

                row["T2_T3"] = item["T2_T3"];
                row["T2_T3_TK"] = item["T2_T3_TK"];
                row["T2_T3_Status"] = item["T2_T3_Status"];
                row["T2_T3_TT"] = item["T2_T3_TT"];

                row["T2_T4"] = item["T2_T4"];
                row["T2_T4_TK"] = item["T2_T4_TK"];
                row["T2_T4_Status"] = item["T2_T4_Status"];
                row["T2_T4_TT"] = item["T2_T4_TT"];

                row["T2_T5"] = item["T2_T5"];
                row["T2_T5_TK"] = item["T2_T5_TK"];
                row["T2_T5_Status"] = item["T2_T5_Status"];
                row["T2_T5_TT"] = item["T2_T5_TT"];

                row["T2_T6"] = item["T2_T6"];
                row["T2_T6_TK"] = item["T2_T6_TK"];
                row["T2_T6_Status"] = item["T2_T6_Status"];
                row["T2_T6_TT"] = item["T2_T6_TT"];

                row["T2_T7"] = item["T2_T7"];
                row["T2_T7_TK"] = item["T2_T7_TK"];
                row["T2_T7_Status"] = item["T2_T7_Status"];
                row["T2_T7_TT"] = item["T2_T7_TT"];

                row["T2_T8"] = item["T2_T8"];
                row["T2_T8_TK"] = item["T2_T8_TK"];
                row["T2_T8_Status"] = item["T2_T8_Status"];
                row["T2_T8_TT"] = item["T2_T8_TT"];

                row["T2_KQ"] = item["T2_KQ"];

                #endregion

                #region Tuan 3

                row["T3_T2"] = item["T3_T2"];
                row["T3_T2_TK"] = item["T3_T2_TK"];
                row["T3_T2_Status"] = item["T3_T2_Status"];
                row["T3_T2_TT"] = item["T3_T2_TT"];

                row["T3_T3"] = item["T3_T3"];
                row["T3_T3_TK"] = item["T3_T3_TK"];
                row["T3_T3_Status"] = item["T3_T3_Status"];
                row["T3_T3_TT"] = item["T3_T3_TT"];

                row["T3_T4"] = item["T3_T4"];
                row["T3_T4_TK"] = item["T3_T4_TK"];
                row["T3_T4_Status"] = item["T3_T4_Status"];
                row["T3_T4_TT"] = item["T3_T4_TT"];

                row["T3_T5"] = item["T3_T5"];
                row["T3_T5_TK"] = item["T3_T5_TK"];
                row["T3_T5_Status"] = item["T3_T5_Status"];
                row["T3_T5_TT"] = item["T3_T5_TT"];

                row["T3_T6"] = item["T3_T6"];
                row["T3_T6_TK"] = item["T3_T6_TK"];
                row["T3_T6_Status"] = item["T3_T6_Status"];
                row["T3_T6_TT"] = item["T3_T6_TT"];

                row["T3_T7"] = item["T3_T7"];
                row["T3_T7_TK"] = item["T3_T7_TK"];
                row["T3_T7_Status"] = item["T3_T7_Status"];
                row["T3_T7_TT"] = item["T3_T7_TT"];

                row["T3_T8"] = item["T3_T8"];
                row["T3_T8_TK"] = item["T3_T8_TK"];
                row["T3_T8_Status"] = item["T3_T8_Status"];
                row["T3_T8_TT"] = item["T3_T8_TT"];

                row["T3_KQ"] = item["T3_KQ"];

                #endregion

                #region Tuan 4

                row["T4_T2"] = item["T4_T2"];
                row["T4_T2_TK"] = item["T4_T2_TK"];
                row["T4_T2_Status"] = item["T4_T2_Status"];
                row["T4_T2_TT"] = item["T4_T2_TT"];

                row["T4_T3"] = item["T4_T3"];
                row["T4_T3_TK"] = item["T4_T3_TK"];
                row["T4_T3_Status"] = item["T4_T3_Status"];
                row["T4_T3_TT"] = item["T4_T3_TT"];

                row["T4_T4"] = item["T4_T4"];
                row["T4_T4_TK"] = item["T4_T4_TK"];
                row["T4_T4_Status"] = item["T4_T4_Status"];
                row["T4_T4_TT"] = item["T4_T4_TT"];

                row["T4_T5"] = item["T4_T5"];
                row["T4_T5_TK"] = item["T4_T5_TK"];
                row["T4_T5_Status"] = item["T4_T5_Status"];
                row["T4_T5_TT"] = item["T4_T5_TT"];

                row["T4_T6"] = item["T4_T6"];
                row["T4_T6_TK"] = item["T4_T6_TK"];
                row["T4_T6_Status"] = item["T4_T6_Status"];
                row["T4_T6_TT"] = item["T4_T6_TT"];

                row["T4_T7"] = item["T4_T7"];
                row["T4_T7_TK"] = item["T4_T7_TK"];
                row["T4_T7_Status"] = item["T4_T7_Status"];
                row["T4_T7_TT"] = item["T4_T7_TT"];

                row["T4_T8"] = item["T4_T8"];
                row["T4_T8_TK"] = item["T4_T8_TK"];
                row["T4_T8_Status"] = item["T4_T8_Status"];
                row["T4_T8_TT"] = item["T4_T8_TT"];

                row["T4_KQ"] = item["T4_KQ"];

                #endregion

                #region Tuan 5

                row["T5_T2"] = item["T5_T2"];
                row["T5_T2_TK"] = item["T5_T2_TK"];
                row["T5_T2_Status"] = item["T5_T2_Status"];
                row["T5_T2_TT"] = item["T5_T2_TT"];

                row["T5_T3"] = item["T5_T3"];
                row["T5_T3_TK"] = item["T5_T3_TK"];
                row["T5_T3_Status"] = item["T5_T3_Status"];
                row["T5_T3_TT"] = item["T5_T3_TT"];

                row["T5_T4"] = item["T5_T4"];
                row["T5_T4_TK"] = item["T5_T4_TK"];
                row["T5_T4_Status"] = item["T5_T4_Status"];
                row["T5_T4_TT"] = item["T5_T4_TT"];

                row["T5_T5"] = item["T5_T5"];
                row["T5_T5_TK"] = item["T5_T5_TK"];
                row["T5_T5_Status"] = item["T5_T5_Status"];
                row["T5_T5_TT"] = item["T5_T5_TT"];

                row["T5_T6"] = item["T5_T6"];
                row["T5_T6_TK"] = item["T5_T6_TK"];
                row["T5_T6_Status"] = item["T5_T6_Status"];
                row["T5_T6_TT"] = item["T5_T6_TT"];

                row["T5_T7"] = item["T5_T7"];
                row["T5_T7_TK"] = item["T5_T7_TK"];
                row["T5_T7_Status"] = item["T5_T7_Status"];
                row["T5_T7_TT"] = item["T5_T7_TT"];

                row["T5_T8"] = item["T5_T8"];
                row["T5_T8_TK"] = item["T5_T8_TK"];
                row["T5_T8_Status"] = item["T5_T8_Status"];
                row["T5_T8_TT"] = item["T5_T8_TT"];

                row["T5_KQ"] = item["T5_KQ"];

                row["KQT"] = item["KQT"];

                #endregion

                dtCongViecThuongXuyenReturn.Rows.Add(row);
            }

            #endregion

            #region Cong viec phat sinh

            ds1 = DanhGiaThang_BoPhanTTCVController.GetAllCongViecPhong_ForExport(3, idDotDanhGia, idBoPhan, 0);
            DataTable dtCongViecPhatSinh = ds1.Tables[0];

            DataTable dtCongViecPhatSinhTemp = new DataTable();

            dtCongViecPhatSinhTemp.Columns.Add("ID", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("IDPhongBan", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("IDParent", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("Level", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("IDCongViec", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("Tuan", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("NguoiThamGia", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("STT", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("TenCongViec", typeof(String));


            #region Tuan 1

            dtCongViecPhatSinhTemp.Columns.Add("T1_T2", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T2_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T2_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T2_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T1_T3", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T3_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T3_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T3_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T1_T4", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T4_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T4_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T4_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T1_T5", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T5_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T5_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T5_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T1_T6", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T6_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T6_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T6_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T1_T7", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T7_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T7_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T7_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T1_T8", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T8_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T8_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T1_T8_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T1_KQ", typeof(String));

            #endregion

            #region Tuan2

            dtCongViecPhatSinhTemp.Columns.Add("T2_T2", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T2_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T2_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T2_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T2_T3", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T3_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T3_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T3_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T2_T4", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T4_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T4_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T4_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T2_T5", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T5_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T5_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T5_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T2_T6", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T6_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T6_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T6_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T2_T7", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T7_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T7_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T7_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T2_T8", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T8_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T8_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T2_T8_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T2_KQ", typeof(String));

            #endregion

            #region Tuan3

            dtCongViecPhatSinhTemp.Columns.Add("T3_T2", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T2_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T2_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T2_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T3_T3", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T3_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T3_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T3_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T3_T4", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T4_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T4_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T4_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T3_T5", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T5_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T5_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T5_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T3_T6", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T6_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T6_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T6_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T3_T7", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T7_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T7_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T7_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T3_T8", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T8_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T8_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T3_T8_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T3_KQ", typeof(String));

            #endregion

            #region Tuan4

            dtCongViecPhatSinhTemp.Columns.Add("T4_T2", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T2_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T2_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T2_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T4_T3", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T3_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T3_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T3_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T4_T4", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T4_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T4_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T4_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T4_T5", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T5_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T5_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T5_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T4_T6", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T6_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T6_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T6_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T4_T7", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T7_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T7_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T7_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T4_T8", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T8_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T8_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T4_T8_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T4_KQ", typeof(String));

            #endregion

            #region Tuan5

            dtCongViecPhatSinhTemp.Columns.Add("T5_T2", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T2_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T2_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T2_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T5_T3", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T3_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T3_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T3_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T5_T4", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T4_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T4_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T4_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T5_T5", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T5_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T5_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T5_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T5_T6", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T6_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T6_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T6_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T5_T7", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T7_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T7_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T7_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T5_T8", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T8_TK", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T8_Status", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("T5_T8_TT", typeof(String));

            dtCongViecPhatSinhTemp.Columns.Add("T5_KQ", typeof(String));
            dtCongViecPhatSinhTemp.Columns.Add("KQT", typeof(String));
            #endregion

            dtCongViecPhatSinhReturn = DanhGiaThang_BoPhanTTCVController.BuildRecursiveKeHoachCongViecBoPhanExport(dtCongViecPhatSinh, dtCongViecPhatSinhTemp, idDotDanhGia, ngaybatdau, returnIndex, out returnIndex);

            row = dtCongViecThuongXuyenReturn.NewRow();
            row["ID"] = "##9999##";
            row["IDPhongBan"] = "";
            row["IDParent"] = "";
            row["Level"] = "";
            row["IDCongViec"] = "";
            row["Tuan"] = "";
            row["NguoiThamGia"] = "";
            row["STT"] = "";
            row["TenCongViec"] = "Công việc phát sinh";

            #region Tuan 1

            row["T1_T2"] = "";
            row["T1_T2_TK"] = "";
            row["T1_T2_Status"] = "";
            row["T1_T2_TT"] = "";

            row["T1_T3"] = "";
            row["T1_T3_TK"] = "";
            row["T1_T3_Status"] = "";
            row["T1_T3_TT"] = "";

            row["T1_T4"] = "";
            row["T1_T4_TK"] = "";
            row["T1_T4_Status"] = "";
            row["T1_T4_TT"] = "";

            row["T1_T5"] = "";
            row["T1_T5_TK"] = "";
            row["T1_T5_Status"] = "";
            row["T1_T5_TT"] = "";

            row["T1_T6"] = "";
            row["T1_T6_TK"] = "";
            row["T1_T6_Status"] = "";
            row["T1_T6_TT"] = "";

            row["T1_T7"] = "";
            row["T1_T7_TK"] = "";
            row["T1_T7_Status"] = "";
            row["T1_T7_TT"] = "";

            row["T1_T8"] = "";
            row["T1_T8_TK"] = "";
            row["T1_T8_Status"] = "";
            row["T1_T8_TT"] = "";

            row["T1_KQ"] = "";

            #endregion

            #region Tuan 2

            row["T2_T2"] = "";
            row["T2_T2_TK"] = "";
            row["T2_T2_Status"] = "";
            row["T2_T2_TT"] = "";

            row["T2_T3"] = "";
            row["T2_T3_TK"] = "";
            row["T2_T3_Status"] = "";
            row["T2_T3_TT"] = "";

            row["T2_T4"] = "";
            row["T2_T4_TK"] = "";
            row["T2_T4_Status"] = "";
            row["T2_T4_TT"] = "";

            row["T2_T5"] = "";
            row["T2_T5_TK"] = "";
            row["T2_T5_Status"] = "";
            row["T2_T5_TT"] = "";

            row["T2_T6"] = "";
            row["T2_T6_TK"] = "";
            row["T2_T6_Status"] = "";
            row["T2_T6_TT"] = "";

            row["T2_T7"] = "";
            row["T2_T7_TK"] = "";
            row["T2_T7_Status"] = "";
            row["T2_T7_TT"] = "";

            row["T2_T8"] = "";
            row["T2_T8_TK"] = "";
            row["T2_T8_Status"] = "";
            row["T2_T8_TT"] = "";

            row["T2_KQ"] = "";

            #endregion

            #region Tuan 3

            row["T3_T2"] = "";
            row["T3_T2_TK"] = "";
            row["T3_T2_Status"] = "";
            row["T3_T2_TT"] = "";

            row["T3_T3"] = "";
            row["T3_T3_TK"] = "";
            row["T3_T3_Status"] = "";
            row["T3_T3_TT"] = "";

            row["T3_T4"] = "";
            row["T3_T4_TK"] = "";
            row["T3_T4_Status"] = "";
            row["T3_T4_TT"] = "";

            row["T3_T5"] = "";
            row["T3_T5_TK"] = "";
            row["T3_T5_Status"] = "";
            row["T3_T5_TT"] = "";

            row["T3_T6"] = "";
            row["T3_T6_TK"] = "";
            row["T3_T6_Status"] = "";
            row["T3_T6_TT"] = "";

            row["T3_T7"] = "";
            row["T3_T7_TK"] = "";
            row["T3_T7_Status"] = "";
            row["T3_T7_TT"] = "";

            row["T3_T8"] = "";
            row["T3_T8_TK"] = "";
            row["T3_T8_Status"] = "";
            row["T3_T8_TT"] = "";

            row["T3_KQ"] = "";

            #endregion

            #region Tuan 4

            row["T4_T2"] = "";
            row["T4_T2_TK"] = "";
            row["T4_T2_Status"] = "";
            row["T4_T2_TT"] = "";

            row["T4_T3"] = "";
            row["T4_T3_TK"] = "";
            row["T4_T3_Status"] = "";
            row["T4_T3_TT"] = "";

            row["T4_T4"] = "";
            row["T4_T4_TK"] = "";
            row["T4_T4_Status"] = "";
            row["T4_T4_TT"] = "";

            row["T4_T5"] = "";
            row["T4_T5_TK"] = "";
            row["T4_T5_Status"] = "";
            row["T4_T5_TT"] = "";

            row["T4_T6"] = "";
            row["T4_T6_TK"] = "";
            row["T4_T6_Status"] = "";
            row["T4_T6_TT"] = "";

            row["T4_T7"] = "";
            row["T4_T7_TK"] = "";
            row["T4_T7_Status"] = "";
            row["T4_T7_TT"] = "";

            row["T4_T8"] = "";
            row["T4_T8_TK"] = "";
            row["T4_T8_Status"] = "";
            row["T4_T8_TT"] = "";

            row["T4_KQ"] = "";

            #endregion

            #region Tuan 5

            row["T5_T2"] = "";
            row["T5_T2_TK"] = "";
            row["T5_T2_Status"] = "";
            row["T5_T2_TT"] = "";

            row["T5_T3"] = "";
            row["T5_T3_TK"] = "";
            row["T5_T3_Status"] = "";
            row["T5_T3_TT"] = "";

            row["T5_T4"] = "";
            row["T5_T4_TK"] = "";
            row["T5_T4_Status"] = "";
            row["T5_T4_TT"] = "";

            row["T5_T5"] = "";
            row["T5_T5_TK"] = "";
            row["T5_T5_Status"] = "";
            row["T5_T5_TT"] = "";

            row["T5_T6"] = "";
            row["T5_T6_TK"] = "";
            row["T5_T6_Status"] = "";
            row["T5_T6_TT"] = "";

            row["T5_T7"] = "";
            row["T5_T7_TK"] = "";
            row["T5_T7_Status"] = "";
            row["T5_T7_TT"] = "";

            row["T5_T8"] = "";
            row["T5_T8_TK"] = "";
            row["T5_T8_Status"] = "";
            row["T5_T8_TT"] = "";

            row["T5_KQ"] = "";
            row["KQT"] = "";

            #endregion

            dtCongViecThuongXuyenReturn.Rows.Add(row);

            foreach (DataRow item in dtCongViecPhatSinhReturn.Rows)
            {
                row = dtCongViecThuongXuyenReturn.NewRow();

                row["ID"] = item["ID"];
                row["IDPhongBan"] = item["IDPhongBan"];
                row["IDParent"] = item["IDParent"];
                row["Level"] = item["Level"];
                row["IDCongViec"] = item["IDCongViec"];
                row["Tuan"] = item["Tuan"];
                row["NguoiThamGia"] = item["NguoiThamGia"];
                row["STT"] = item["STT"];
                row["TenCongViec"] = item["TenCongViec"];

                #region Tuan 1

                row["T1_T2"] = item["T1_T2"];
                row["T1_T2_TK"] = item["T1_T2_TK"];
                row["T1_T2_Status"] = item["T1_T2_Status"];
                row["T1_T2_TT"] = item["T1_T2_TT"];

                row["T1_T3"] = item["T1_T3"];
                row["T1_T3_TK"] = item["T1_T3_TK"];
                row["T1_T3_Status"] = item["T1_T3_Status"];
                row["T1_T3_TT"] = item["T1_T3_TT"];

                row["T1_T4"] = item["T1_T4"];
                row["T1_T4_TK"] = item["T1_T4_TK"];
                row["T1_T4_Status"] = item["T1_T4_Status"];
                row["T1_T4_TT"] = item["T1_T4_TT"];

                row["T1_T5"] = item["T1_T5"];
                row["T1_T5_TK"] = item["T1_T5_TK"];
                row["T1_T5_Status"] = item["T1_T5_Status"];
                row["T1_T5_TT"] = item["T1_T5_TT"];

                row["T1_T6"] = item["T1_T6"];
                row["T1_T6_TK"] = item["T1_T6_TK"];
                row["T1_T6_Status"] = item["T1_T6_Status"];
                row["T1_T6_TT"] = item["T1_T6_TT"];

                row["T1_T7"] = item["T1_T7"];
                row["T1_T7_TK"] = item["T1_T7_TK"];
                row["T1_T7_Status"] = item["T1_T7_Status"];
                row["T1_T7_TT"] = item["T1_T7_TT"];

                row["T1_T8"] = item["T1_T8"];
                row["T1_T8_TK"] = item["T1_T8_TK"];
                row["T1_T8_Status"] = item["T1_T8_Status"];
                row["T1_T8_TT"] = item["T1_T8_TT"];

                row["T1_KQ"] = item["T1_KQ"];

                #endregion

                #region Tuan 2

                row["T2_T2"] = item["T2_T2"];
                row["T2_T2_TK"] = item["T2_T2_TK"];
                row["T2_T2_Status"] = item["T2_T2_Status"];
                row["T2_T2_TT"] = item["T2_T2_TT"];

                row["T2_T3"] = item["T2_T3"];
                row["T2_T3_TK"] = item["T2_T3_TK"];
                row["T2_T3_Status"] = item["T2_T3_Status"];
                row["T2_T3_TT"] = item["T2_T3_TT"];

                row["T2_T4"] = item["T2_T4"];
                row["T2_T4_TK"] = item["T2_T4_TK"];
                row["T2_T4_Status"] = item["T2_T4_Status"];
                row["T2_T4_TT"] = item["T2_T4_TT"];

                row["T2_T5"] = item["T2_T5"];
                row["T2_T5_TK"] = item["T2_T5_TK"];
                row["T2_T5_Status"] = item["T2_T5_Status"];
                row["T2_T5_TT"] = item["T2_T5_TT"];

                row["T2_T6"] = item["T2_T6"];
                row["T2_T6_TK"] = item["T2_T6_TK"];
                row["T2_T6_Status"] = item["T2_T6_Status"];
                row["T2_T6_TT"] = item["T2_T6_TT"];

                row["T2_T7"] = item["T2_T7"];
                row["T2_T7_TK"] = item["T2_T7_TK"];
                row["T2_T7_Status"] = item["T2_T7_Status"];
                row["T2_T7_TT"] = item["T2_T7_TT"];

                row["T2_T8"] = item["T2_T8"];
                row["T2_T8_TK"] = item["T2_T8_TK"];
                row["T2_T8_Status"] = item["T2_T8_Status"];
                row["T2_T8_TT"] = item["T2_T8_TT"];

                row["T2_KQ"] = item["T2_KQ"];

                #endregion

                #region Tuan 3

                row["T3_T2"] = item["T3_T2"];
                row["T3_T2_TK"] = item["T3_T2_TK"];
                row["T3_T2_Status"] = item["T3_T2_Status"];
                row["T3_T2_TT"] = item["T3_T2_TT"];

                row["T3_T3"] = item["T3_T3"];
                row["T3_T3_TK"] = item["T3_T3_TK"];
                row["T3_T3_Status"] = item["T3_T3_Status"];
                row["T3_T3_TT"] = item["T3_T3_TT"];

                row["T3_T4"] = item["T3_T4"];
                row["T3_T4_TK"] = item["T3_T4_TK"];
                row["T3_T4_Status"] = item["T3_T4_Status"];
                row["T3_T4_TT"] = item["T3_T4_TT"];

                row["T3_T5"] = item["T3_T5"];
                row["T3_T5_TK"] = item["T3_T5_TK"];
                row["T3_T5_Status"] = item["T3_T5_Status"];
                row["T3_T5_TT"] = item["T3_T5_TT"];

                row["T3_T6"] = item["T3_T6"];
                row["T3_T6_TK"] = item["T3_T6_TK"];
                row["T3_T6_Status"] = item["T3_T6_Status"];
                row["T3_T6_TT"] = item["T3_T6_TT"];

                row["T3_T7"] = item["T3_T7"];
                row["T3_T7_TK"] = item["T3_T7_TK"];
                row["T3_T7_Status"] = item["T3_T7_Status"];
                row["T3_T7_TT"] = item["T3_T7_TT"];

                row["T3_T8"] = item["T3_T8"];
                row["T3_T8_TK"] = item["T3_T8_TK"];
                row["T3_T8_Status"] = item["T3_T8_Status"];
                row["T3_T8_TT"] = item["T3_T8_TT"];

                row["T3_KQ"] = item["T3_KQ"];

                #endregion

                #region Tuan 4

                row["T4_T2"] = item["T4_T2"];
                row["T4_T2_TK"] = item["T4_T2_TK"];
                row["T4_T2_Status"] = item["T4_T2_Status"];
                row["T4_T2_TT"] = item["T4_T2_TT"];

                row["T4_T3"] = item["T4_T3"];
                row["T4_T3_TK"] = item["T4_T3_TK"];
                row["T4_T3_Status"] = item["T4_T3_Status"];
                row["T4_T3_TT"] = item["T4_T3_TT"];

                row["T4_T4"] = item["T4_T4"];
                row["T4_T4_TK"] = item["T4_T4_TK"];
                row["T4_T4_Status"] = item["T4_T4_Status"];
                row["T4_T4_TT"] = item["T4_T4_TT"];

                row["T4_T5"] = item["T4_T5"];
                row["T4_T5_TK"] = item["T4_T5_TK"];
                row["T4_T5_Status"] = item["T4_T5_Status"];
                row["T4_T5_TT"] = item["T4_T5_TT"];

                row["T4_T6"] = item["T4_T6"];
                row["T4_T6_TK"] = item["T4_T6_TK"];
                row["T4_T6_Status"] = item["T4_T6_Status"];
                row["T4_T6_TT"] = item["T4_T6_TT"];

                row["T4_T7"] = item["T4_T7"];
                row["T4_T7_TK"] = item["T4_T7_TK"];
                row["T4_T7_Status"] = item["T4_T7_Status"];
                row["T4_T7_TT"] = item["T4_T7_TT"];

                row["T4_T8"] = item["T4_T8"];
                row["T4_T8_TK"] = item["T4_T8_TK"];
                row["T4_T8_Status"] = item["T4_T8_Status"];
                row["T4_T8_TT"] = item["T4_T8_TT"];

                row["T4_KQ"] = item["T4_KQ"];

                #endregion

                #region Tuan 5

                row["T5_T2"] = item["T5_T2"];
                row["T5_T2_TK"] = item["T5_T2_TK"];
                row["T5_T2_Status"] = item["T5_T2_Status"];
                row["T5_T2_TT"] = item["T5_T2_TT"];

                row["T5_T3"] = item["T5_T3"];
                row["T5_T3_TK"] = item["T5_T3_TK"];
                row["T5_T3_Status"] = item["T5_T3_Status"];
                row["T5_T3_TT"] = item["T5_T3_TT"];

                row["T5_T4"] = item["T5_T4"];
                row["T5_T4_TK"] = item["T5_T4_TK"];
                row["T5_T4_Status"] = item["T5_T4_Status"];
                row["T5_T4_TT"] = item["T5_T4_TT"];

                row["T5_T5"] = item["T5_T5"];
                row["T5_T5_TK"] = item["T5_T5_TK"];
                row["T5_T5_Status"] = item["T5_T5_Status"];
                row["T5_T5_TT"] = item["T5_T5_TT"];

                row["T5_T6"] = item["T5_T6"];
                row["T5_T6_TK"] = item["T5_T6_TK"];
                row["T5_T6_Status"] = item["T5_T6_Status"];
                row["T5_T6_TT"] = item["T5_T6_TT"];

                row["T5_T7"] = item["T5_T7"];
                row["T5_T7_TK"] = item["T5_T7_TK"];
                row["T5_T7_Status"] = item["T5_T7_Status"];
                row["T5_T7_TT"] = item["T5_T7_TT"];

                row["T5_T8"] = item["T5_T8"];
                row["T5_T8_TK"] = item["T5_T8_TK"];
                row["T5_T8_Status"] = item["T5_T8_Status"];
                row["T5_T8_TT"] = item["T5_T8_TT"];

                row["T5_KQ"] = item["T5_KQ"];

                row["KQT"] = item["KQT"];

                #endregion

                dtCongViecThuongXuyenReturn.Rows.Add(row);
            }

            #endregion

            XmlDocument doc = BuildXmlDocument(dtCongViecThuongXuyenReturn);

            if (!Directory.Exists(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/")))
            {
                Directory.CreateDirectory(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/"));
            }
            //ds.Dispose();
            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            FileStream downloadFile =
                File.Create(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/") + "Test_" + datetime +
                            ".xls");

            XslTransform xsl = new XslTransform();
            xsl.Load(Server.MapPath("/Template/" + "Test.xsl"));
            xsl.Transform(doc, null, downloadFile, null);
            downloadFile.Flush();
            downloadFile.Close();

            hplDownload.Text = "Hãy click vào liên kết này để Tải file về";
            hplDownload.Visible = true;
            hplDownload.NavigateUrl = "/UpLoad/Temp/" + CurrentUser.UserID + "/Test_" + datetime + ".xls";
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