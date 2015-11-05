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

namespace VmgPortal.Modules.KPIData.Admin.BaoCao.XepLoaiThang
{
    public partial class BaoCaoTienDoThucHienDanhGia : AuthenticatedControl
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
                    btnMailTBP.Visible = false;
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
                    btnMailTBP.Visible = true;
                    dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
                }

                dropPhongBan.DataSource = dtPhong;
                dropPhongBan.DataBind();
                dropPhongBan.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));

                dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
                dropDotDanhGia.DataBind();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            DataTable dtUsers;

            if (CurrentUser.IsAdmin || CurrentUser.IsSuperAdmin)
            {
                dtUsers = CommonController.BaoCaoTienDoThucHienDanhGiaThang(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropChucVu.SelectedValue), ConvertUtility.ToInt32(dropTrangThai.SelectedValue), ConvertUtility.ToInt32(dropPhongBan.SelectedValue));
            }
            else
            {
                dtUsers = CommonController.BaoCaoTienDoThucHienDanhGiaThang(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropChucVu.SelectedValue), ConvertUtility.ToInt32(dropTrangThai.SelectedValue), ConvertUtility.ToInt32(dropPhongBan.SelectedValue), CurrentUser.UserID);
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
            }
        }

        private string GetTrangThai(int trangthai)
        {
            // LapKeHoach = 0,
            //DaGuiKeHoachChoTruongPhong = 1,
            //DaGuiKeHoachChoTBP = 2,
            //DangDanhGia = 3,
            //DaGuiDanhGiaChoTruongPhong = 4,
            //DaGuiDanhGiaChoTruongBoPhan = 5,
            //TruongPhongGuiLaiDanhGiaChoNhanVien = 6,
            //TruongBoPhanGuiLaiDanhGiaChoNhanVien = 7,
            //NhanVienDongYVoiKetQuaDanhGia = 8,            
            //ThongNhat = 9,

            if (trangthai < 3)
            {
                return "Đang đánh giá";
            }
            //else if (trangthai == 2)
            //{
            //    return "Đã gửi kế hoạch đến trưởng bộ phận";
            //}
            //else if (trangthai == 3)
            //{
            //    return "Đang đanh giá";
            //}
            else if (trangthai == 4)
            {
                return "Đã gửi đánh giá đến trưởng phòng";
            }
            else if (trangthai == 5)
            {
                return "Đã gửi đánh giá đến trưởng bộ phận";
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
                return "Nhân viên đã đồng ý với kết quả đánh giá";
            }
            else if (trangthai == 9)
            {
                return "Thống nhất";
            }
            else
            {
                return "Lập kế hoạch";
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

        protected void dropTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dropChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private string GetNoiDungTheoTrangThai(int trangthai)
        {
            if (trangthai == 3)
            {
                return "Đã đến thời gian phải hoàn thiện đánh giá cá nhân, đề nghị bạn vào phần mềm để đánh giá và gửi cho người phụ trách trực tiếp";
            }
            else if (trangthai == 1 || trangthai == 2)
            {
                return "Đã đến thời gian phải hoàn thiện đánh giá cá nhân, đề nghị bạn vào phần mềm để đánh giá và gửi cho người phụ trách trực tiếp";
            }  
            else if (trangthai == 6)
            {
                return "Trưởng phòng đã hoàn thiện phần đánh giá và gửi lại cho bạn. Đề nghị bạn vào phần mềm để thống nhất kết quả.";
            }
            else if (trangthai == 7)
            {
                return "Trưởng bộ phận đã hoàn thiện phần đánh giá và gửi lại cho bạn. Đề nghị bạn vào  phần mềm để thống nhất kết quả.";
            }
            else if (trangthai == 0)
            {
                return "Đã đến thời gian gửi kế hoạch tháng, đề nghị bạn vào phần mềm để gửi kế hoạch tháng";
            }
            return "";
        }

        protected void btnMail_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gv in dtgUsers.Rows)
            {
                Label lblMail = (Label)gv.FindControl("lblMail");
                Label lblTrangThai = (Label)gv.FindControl("lblTrangThaiDG");

                bool value = EmailUtility.DoSendMail(lblMail.Text, "", "Mail nhắc nhở kế hoạch và đánh giá", GetNoiDungTheoTrangThai(ConvertUtility.ToInt32(lblTrangThai.Text)));
                
            }

            lblUpdateStatus.Text = "Bạn đã gửi mail thành công";

        }
        protected void btnMailTBP_Click(object sender, EventArgs e)
        {
            DataTable dt = DotDanhGiaController.GetAllNhanVienByTrungTam(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), (int)Constants.ChucVu.TruongPhong);

            foreach (DataRow item in dt.Rows)
            {
                //if (ConvertUtility.ToInt32(item["RoleID"]) == (int)Constants.Role.TruongPhong)
                //{
                //    EmailUtility.DoSendMail(item["UserName"].ToString(), "", "Mail nhắc nhở đánh giá nhân viên", "Đã có một số nhân viên hoàn thiện phần đánh giá. Đề nghị bạn vào phần mềm để đánh giá và gửi lại cho nhân viên.");
                //}
                //else
                //{
                    EmailUtility.DoSendMail(item["UserName"].ToString(), "", "Mail nhắc nhở đánh giá nhân viên", "Đề nghị TBP vào xem lại kết quả đánh giá của nhân viên và thống nhất để kết quả được chuyển vào phần tổng hợp của bộ phận.");
                //}
            }

            lblUpdateStatus.Text = "Bạn đã gửi mail thành công";
        }
    }
}