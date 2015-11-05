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

namespace VmgPortal.Modules.KPIData.Admin.BaoCao
{
    public partial class TongHopBaoCaoNgayNhanVien : AuthenticatedControl
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
                
                dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
                dropDotDanhGia.DataBind();

                BindUser();
            }
        }

        private void BindUser()
        {
            DataTable dtNhanVien = null;
            if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
            {
                dtNhanVien = DotDanhGiaController.QuanLyNhanVienTheoNDG_ByNhanVienQuanLy(CurrentUser.UserID, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            }
            else
            {
                dtNhanVien = DotDanhGiaController.GetAllNhanVien(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropPhongBan.SelectedValue), ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));
            }

            if (dtNhanVien != null && dtNhanVien.Rows.Count > 0)
            {
                dropUser.DataSource = dtNhanVien;
                dropUser.DataBind();
                dropUser.Items.Insert(0, new ListItem("All", "0"));
            }
           
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            int idTrungTam = ConvertUtility.ToInt32(dropTrungTam.SelectedValue);
            int idPhongBan = ConvertUtility.ToInt32(dropPhongBan.SelectedValue);
            DateTime dtTime = new DateTime(ConvertUtility.ToInt32(dropYear.SelectedValue), ConvertUtility.ToInt32(dropMonth.SelectedValue), ConvertUtility.ToInt32(dropDay.SelectedValue));
            int idDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            
            DataTable dt = null;
            if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
            {
                dt = QuanLyCongViecBaoCaoNgayController.GetAllBaoCaoNgay(idTrungTam, dtTime, ConvertUtility.ToInt32(dropUser.SelectedValue), CurrentUser.UserID, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));
            }
            else 
            {
                dt = QuanLyCongViecBaoCaoNgayController.GetAllBaoCaoNgay(idTrungTam, dtTime, ConvertUtility.ToInt32(dropUser.SelectedValue), 0, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));
            }

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
                lblTotalTop.Text = lblTotalBottom.Text = dt.Rows.Count.ToString();
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

        }

        protected void dropTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dropPhongBan.Items.Clear();

            //DataTable dtPhong;
            //if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
            //{
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

            BindUser();
        }

        protected void dropPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindUser();
        }

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

        }

        protected void dropUser_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    QuanLyCongViecBaoCaoNgayController.UpdateStatus(id, 1);
                    QuanLyCongViecBaoCaoNgayInfo info = QuanLyCongViecBaoCaoNgayController.GetInfo(id);                   
                    QuanLyCongViecBaoCaoNgayController.InsertBaoCaoNgayBoPhan(info);
                }
                else
                {
                    QuanLyCongViecBaoCaoNgayController.UpdateStatus(id, 0);
                }
            }
        }
    }
}