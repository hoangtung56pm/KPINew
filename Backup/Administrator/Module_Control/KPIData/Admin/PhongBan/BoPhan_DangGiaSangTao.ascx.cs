using System;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using VmgPortal.Library;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Components.Users;
using VmgPortal.Library.Utilities;
using System.Drawing;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;

namespace VmgPortal.Modules.KPIData.Admin.PhongBan
{
    public partial class BoPhan_DangGiaSangTao : AuthenticatedControl
	{
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
            {
                btnUpdate.Visible = false;
            }

			if (!Page.IsPostBack)
			{              
                dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
                dropDotDanhGia.DataBind();

                int idDotDanhActive = ConvertUtility.ToInt32(DotDanhGiaController.GetDaultDotDanhGia().Rows[0]["ID"]);
                dropDotDanhGia.SelectedValue = idDotDanhActive.ToString();
			}
		}
        private void rptLetters_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lnkLetter = (LinkButton)e.Item.FindControl("lnkLetter");
                lnkLetter.Text = e.Item.DataItem.ToString();
                lnkLetter.CommandArgument = e.Item.DataItem.ToString();

                if (ConvertUtility.ToString(ViewState["Alphabet"]) == e.Item.DataItem.ToString())
                {
                    lnkLetter.Font.Underline = true;
                    lnkLetter.ForeColor = Color.Blue;
                }
            }
        }
        public void rptLetters_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Alpha")
            {
                if (ConvertUtility.ToString(e.CommandArgument) != "All")
                {
                    ViewState["Alphabet"] = e.CommandArgument;
                }
                else
                {
                    ViewState["Alphabet"] = "";
                }
               
            }
        }

        protected void dgrBoPhan_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
                Label lblKey = (Label)e.Row.FindControl("lblKey");
                Label lblKhongCoYTuong = (Label)e.Row.FindControl("lblKhongCoYTuong");
                Label lblSoYTuong = (Label)e.Row.FindControl("lblSoYTuong");
                Label lblDiemSangTaoThang = (Label)e.Row.FindControl("lblDiemSangTaoThang");
              
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

                if (ConvertUtility.ToInt32(curData["TongYTuong"]) > 0)
                {
                    lblKhongCoYTuong.Text = "20%";
                }
                else
                {
                    lblKhongCoYTuong.Text = "0%";
                }

                lblSoYTuong.Text = curData["TyLeSangTao"].ToString() + "%";

                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();

                double tongdiem = 100;
                if (ConvertUtility.ToInt32(curData["TongYTuong"]) > 0)
                {
                    tongdiem += 20;
                }
                tongdiem += ConvertUtility.ToDouble(curData["TyLeSangTao"].ToString());
                tongdiem += ConvertUtility.ToDouble(curData["YTuongApDung"].ToString());
                tongdiem += ConvertUtility.ToDouble(curData["YTuongDoatGiai"].ToString());
                tongdiem += ConvertUtility.ToDouble(curData["PhoiHopNhietTinh"].ToString());
                tongdiem += ConvertUtility.ToDouble(curData["ThucDayNhanVien"].ToString());
                tongdiem -= ConvertUtility.ToDouble(curData["KhongPhoiHop"].ToString());
                lblDiemSangTaoThang.Text = tongdiem.ToString() + "%";
			}
		}
		protected void dgrBoPhan_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
            
            DataTable dtUsers = UserController.GetBoPhanDiemDGSangTao(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

            dgrBoPhan.DataSource = dtUsers;
			dgrBoPhan.RowDataBound += new GridViewRowEventHandler(dgrBoPhan_RowDataBound);
			dgrBoPhan.DataBind();

            lblTotalTop.Text = lblTotalBottom.Text = dtUsers.Rows.Count.ToString();
		}
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gv in dgrBoPhan.Rows)
            {
                int idBoPhan = ConvertUtility.ToInt32(((Label)gv.FindControl("lblKey")).Text);
                int idDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
                TextBox txtYTuongDoatGiai = (TextBox)gv.FindControl("txtYTuongDoatGiai");
                TextBox txtKhongPhoiHop = (TextBox)gv.FindControl("txtKhongPhoiHop");
                TextBox txtPhoiHopNhietTinh = (TextBox)gv.FindControl("txtPhoiHopNhietTinh");
                TextBox txtThucDayNhanVien = (TextBox)gv.FindControl("txtThucDayNhanVien");

                int YTuongDoatGiai = ConvertUtility.ToInt32(txtYTuongDoatGiai.Text);
                int KhongPhoiHop = ConvertUtility.ToInt32(txtKhongPhoiHop.Text);
                int PhoiHopNhietTinh = ConvertUtility.ToInt32(txtPhoiHopNhietTinh.Text);
                int ThucDayNhanVien = ConvertUtility.ToInt32(txtThucDayNhanVien.Text);

                UserController.UpdateBoPhanDGDiemSangTao(idBoPhan, idDotDanhGia, YTuongDoatGiai, KhongPhoiHop, PhoiHopNhietTinh, ThucDayNhanVien);
            }

            DataTable dtNhanVien = DotDanhGiaController.GetAllNhanVien(0, 0, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

            if (dtNhanVien != null && dtNhanVien.Rows.Count > 0)
            {
                foreach (DataRow item in dtNhanVien.Rows)
                {
                    DotDanhGiaController.DanhGiaThang_DGCBCNVDanhGia_TongDiemCongThucMoi(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(item["IDNhanVien"]));
                }
            }
        }

        protected string GetTyLe(object obj1, object obj2)
        {
            double tyle1 = ConvertUtility.ToDouble(obj1);
            double tyle2 = ConvertUtility.ToDouble(obj2);

            return Math.Round((tyle1 * 100 / tyle2), 0).ToString() + "%";
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dtUsers = UserController.GetBoPhanDiemDGSangTao(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

            ExportData.Export objExport = new ExportData.Export();
            objExport.ExportDetails(dtUsers, ExportData.Export.ExportFormat.Excel, "KyLuat.xls");
        }
	}
}