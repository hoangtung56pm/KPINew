﻿using System;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using VmgPortal.Library;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Components.Users;
using VmgPortal.Library.Utilities;
using System.Drawing;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using VmgPortal.Modules.KPIData.Library;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;

namespace VmgPortal.Modules.KPIData.Admin.DotDanhGia
{
    public partial class DanhGiaThang_DGNhanVien : AuthenticatedControl
    {
        int idDotDanhGia = 0;
        int idNhanVien = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            idDotDanhGia = ConvertUtility.ToInt32(Request.QueryString["idDotDanhGia"]);
            idNhanVien = ConvertUtility.ToInt32(Request.QueryString["idNhanVien"]);
            if (!IsPostBack)
            {
                dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
                dropDotDanhGia.DataBind();

                if (idDotDanhGia == 0)
                {
                    int idDotDanhActive = ConvertUtility.ToInt32(DotDanhGiaController.GetDaultDotDanhGia().Rows[0]["ID"]);

                    Response.Redirect(AppEnv.AdminUrlParams("danhgianhanvienhangthang") + "&idDotDanhGia=" + idDotDanhActive + "&idNhanVien=" + CurrentUser.UserID);
                }
                else
                {
                    dropDotDanhGia.SelectedValue = idDotDanhGia.ToString();
                }

                ViewState["DropDownPageItems"] = 10;

                if (CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiHoTro || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiKinhDoanh || CurrentUser.RoleID == (int)Constants.Role.TruongPhong)
                {
                    btnUpdateStatus.Visible = true;
                }
                else
                {
                    btnUpdateStatus.Visible = false;
                }

                lblUpdateStatus.Text = "";
            }

        }

        protected void dtgUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            dropDotDanhGia.SelectedValue = idDotDanhGia.ToString();

            DataTable dtUsers;

            if (CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiHoTro || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiKinhDoanh)
            {
                dtUsers = UserController.GetUsersByNguoiDanhGiaTheoThang(txtKeyword.Text, dropSearchBy.SelectedValue, ConvertUtility.ToString(ViewState["Alphabet"]), CurrentUser.UserID, CurrentUser.IDTrungTam, idDotDanhGia, CurrentUser.RoleID, ConvertUtility.ToInt32(dropChucVu.SelectedValue));
            }
            else
            {
                dtUsers = UserController.GetUsersByNguoiDanhGiaTheoThang(txtKeyword.Text, dropSearchBy.SelectedValue, ConvertUtility.ToString(ViewState["Alphabet"]), CurrentUser.UserID, CurrentUser.IDTrungTam, idDotDanhGia, CurrentUser.RoleID, ConvertUtility.ToInt32(dropChucVu.SelectedValue));
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
                lblTotalBottom.Text = dtUsers.Rows.Count.ToString();
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

                DataRowView curData = (DataRowView)e.Row.DataItem;

                lblTrangThai.Text = GetTrangThai(ConvertUtility.ToInt32(curData["TrangThai"]));

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

                Button btnDanhGia = (Button)e.Row.FindControl("btnDanhGia");
                string url = "window.open('" + AppEnv.AdminUrlParams("ptdanhgianhanvienhangthang") + "&idDotDanhGia=" + curData["IDDotDanhGia"].ToString() + "&idNhanVien=" + curData["UserID"].ToString() + "','_self'); return false;";
                btnDanhGia.OnClientClick = url;
            }
        }

        private string GetTrangThai(int trangthai)
        {
            //LapKeHoach = 0,
            //DaGuiKeHoachChoTruongPhong = 1,
            //DaGuiKeHoachChoTBP = 2,
            //DangDanhGia = 3,
            //DaGuiDanhGiaChoTruongPhong = 4,
            //DaGuiDanhGiaChoTruongBoPhan = 5,
            //TruongPhongGuiLaiDanhGiaChoNhanVien = 6,
            //TruongBoPhanGuiLaiDanhGiaChoNhanVien = 7,
            //NhanVienDongYVoiKetQuaDanhGia = 8,            
            //ThongNhat = 9,

            //if (trangthai == 0)
            //{
            //    return "Lập kế hoạch";
            //}
            //else if (trangthai == 1)
            //{
            //    return "Kế hoạch đã gửi đến trưởng phòng";
            //}
            //else if (trangthai == 2)
            //{
            //    return "Kế hoạch đã gửi đến trưởng bộ phận";
            //}
            //else 
            if (trangthai <= 3)
            {
                return "Đang đánh giá";
            }
            else if (trangthai == 4)
            {
                return "Đánh giá đã gửi đến trưởng phòng";
            }
            else if (trangthai == 5)
            {
                return "Đánh giá gửi đến trưởng bộ phận";

            }
            else if (trangthai == 6)
            {
                return "Trưởng phòng gửi lại đánh giá cho nhân viên";
            }
            else if (trangthai == 7)
            {
                return "Trưởng bộ phận gửi lại đánh giá cho nhân viên";
            }
            else if (trangthai == 8)
            {
                return "Nhân viên đồng ý với kết quả đánh giá";
            }
            else if (trangthai == 9)
            {
                return "Thống nhất";
            }

            return "Đang đánh giá";
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
            lblUpdateStatus.Text = "";
        }

        protected void dropDotDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(AppEnv.AdminUrlParams("danhgianhanvienhangthang") + "&idDotDanhGia=" + dropDotDanhGia.SelectedValue + "&idNhanVien=" + CurrentUser.UserID);
        }

        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            DataTable dtUsers;

            if (CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiHoTro || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiKinhDoanh)
            {
                dtUsers = UserController.GetUsersByNguoiDanhGiaTheoThang(txtKeyword.Text, dropSearchBy.SelectedValue, ConvertUtility.ToString(ViewState["Alphabet"]), CurrentUser.UserID, CurrentUser.IDTrungTam, idDotDanhGia, CurrentUser.RoleID, ConvertUtility.ToInt32(dropChucVu.SelectedValue));
            }
            else
            {
                dtUsers = UserController.GetUsersByNguoiDanhGiaTheoThang(txtKeyword.Text, dropSearchBy.SelectedValue, ConvertUtility.ToString(ViewState["Alphabet"]), CurrentUser.UserID, CurrentUser.IDTrungTam, idDotDanhGia, (int)Constants.Role.TruongPhong, ConvertUtility.ToInt32(dropChucVu.SelectedValue));
            }

            foreach (DataRow item in dtUsers.Rows)
            {
                if (ConvertUtility.ToInt32(item["TrangThai"]) == 6 || ConvertUtility.ToInt32(item["TrangThai"]) == 7 || ConvertUtility.ToInt32(item["TrangThai"]) == 8)
                {
                    DotDanhGiaController.GuiDanhGiaThang(idDotDanhGia, ConvertUtility.ToInt32(item["UserID"]), (int)Constants.TrangThaiDanhGiaNhanVien.ThongNhat);

                    EmailUtility.DoSendMail(item["Email"].ToString(), "", "Trưởng bộ phận đã thống nhất bảng đánh giá tháng", "Người phụ trách trực tiếp đã đánh giá công việc tháng của bạn. Đề nghị bạn đăng nhập phần mềm để xem kết quả đánh giá.");
                }
            }

            lblUpdateStatus.Text = "Bạn vừa thống nhất kết quả thành công";
        }

        protected void btnSendBack_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gv in dtgUsers.Rows)
            {
                CheckBox chkDeleteThis = (CheckBox)gv.FindControl("DeleteThis");
                string lblUserId = ((Label)gv.FindControl("lblKey")).Text.ToString();
                string lblEmail = ((Label)gv.FindControl("lblEmail")).Text.ToString();
                string lblIDPhong = ((Label)gv.FindControl("lblIDPhong")).Text.ToString();

                if (chkDeleteThis.Checked)
                {
                    DotDanhGiaController.GuiDanhGiaThang(idDotDanhGia, ConvertUtility.ToInt32(lblUserId), (int)Constants.TrangThaiDanhGiaNhanVien.DangDanhGia);

                    EmailUtility.DoSendMail(lblEmail, "", "Yêu cầu đánh giá lại đánh giá tháng " + dropDotDanhGia.SelectedItem.Text, "TBP/TBP thấy bạn đánh giá chưa hợp lý. Đề nghị bạn đăng nhập phần mềm để đánh giá lại.");
                }
            }

            lblUpdateStatus.Text = "Bạn vừa yêu cầu nhân viên đánh giá lại thành công.";
        }
    }
}