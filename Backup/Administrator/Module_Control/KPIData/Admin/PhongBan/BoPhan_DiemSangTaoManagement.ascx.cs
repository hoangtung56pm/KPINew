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
    public partial class BoPhan_DiemSangTaoManagement : AuthenticatedControl
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
                Label txtTyLeSangTao = (Label)e.Row.FindControl("txtTyLeSangTao");
                Label txtTyLeNVTG = (Label)e.Row.FindControl("txtTyLeNVTG");
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


                double TongYTuong = ConvertUtility.ToDouble(curData["TongYTuong"]);
                double SoNhanVienGuiYTuong = ConvertUtility.ToDouble(curData["SoNhanVienGuiYTuong"]);
                double SoNhanVien = ConvertUtility.ToDouble(curData["SoNhanVien"]);

                if ((TongYTuong * 100 / SoNhanVien) > 100)
                {
                    txtTyLeSangTao.ForeColor = Color.Red;
                }

                if ((SoNhanVienGuiYTuong * 100 / SoNhanVien) > 50)
                {
                    txtTyLeNVTG.ForeColor = Color.Red;
                }

                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
			}
		}
		protected void dgrBoPhan_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
            
            DataTable dtUsers = UserController.GetBoPhanDiemSangTao(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

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
                TextBox txtYTuongThang = (TextBox)gv.FindControl("txtYTuongThang");
                TextBox txtYTuongMoi = (TextBox)gv.FindControl("txtYTuongMoi");
                TextBox txtSoNhanVienGui = (TextBox)gv.FindControl("txtSoNhanVienGui");
                TextBox txtSoYTuongDuocChon = (TextBox)gv.FindControl("txtSoYTuongDuocChon");
                TextBox txtSoNhanVien = (TextBox)gv.FindControl("txtSoNhanVien");
                
                int ytuongthang = ConvertUtility.ToInt32(txtYTuongThang.Text);
                 int ytuongmoi = ConvertUtility.ToInt32(txtYTuongMoi.Text);
                 int sonhanviengui = ConvertUtility.ToInt32(txtSoNhanVienGui.Text);
                 int ytuongduocchon = ConvertUtility.ToInt32(txtSoYTuongDuocChon.Text);
                 int sonhanvien = ConvertUtility.ToInt32(txtSoNhanVien.Text);

                 UserController.UpdateBoPhanDiemSangTao(idBoPhan, idDotDanhGia, ytuongthang, ytuongmoi, sonhanviengui, ytuongduocchon, sonhanvien);
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
            DataTable dtUsers = UserController.GetBoPhanDiemSangTao(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

            ExportData.Export objExport = new ExportData.Export();
            objExport.ExportDetails(dtUsers, ExportData.Export.ExportFormat.Excel, "KyLuat.xls");
        }
	}
}