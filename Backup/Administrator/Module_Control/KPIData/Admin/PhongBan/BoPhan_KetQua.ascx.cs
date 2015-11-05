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
    public partial class BoPhan_KetQua : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
            }
        }
        protected void dgrBoPhan_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        private string GetXepLoai(double tong)
        {
            if (tong < 80) return "D";
            else if (tong >= 80 && tong < 90) return "C";
            else if (tong >= 90 && tong < 101) return "B";
            else if (tong >= 101 && tong < 105) return "A";
            else return "A+";
        }

        private string GetRank(string idBoPhan)
        {
            return "1";
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            DataTable dtUsers = UserController.GetKetQuaDanhGia(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

            DataTable dtUsersTemp = dtUsers.Clone();

            dtUsersTemp.Columns.Add("MucDoHoanThanh", typeof(double));
            dtUsersTemp.Columns.Add("XepLoai", typeof(string));
            dtUsersTemp.Columns.Add("Rank", typeof(string));

            double tbKetquaHTKHHD = 0;
            double tbDiemPhoiHop = 0;
            double tbDiemSangTao = 0;
            double tbDiemKyLuat = 0;
            double tbDiemMucDoHoanThanh= 0;
            foreach (DataRow item in dtUsers.Rows)
            {
                double KetquaHTKHHD = ConvertUtility.ToDouble(item["KetquaHTKHHD"]);
                double DiemPhoiHop = ConvertUtility.ToDouble(item["DiemPhoiHop"]);
                double DiemSangTao = ConvertUtility.ToDouble(item["DiemSangTao"]);
                double DiemKyLuat = ConvertUtility.ToDouble(item["DiemKyLuat"]);

                if (DiemSangTao == 0) DiemSangTao = 100;
                if (DiemPhoiHop == 0) DiemPhoiHop = 100;

                tbKetquaHTKHHD += KetquaHTKHHD;
                tbDiemPhoiHop += DiemPhoiHop;
                tbDiemSangTao += DiemSangTao;
                tbDiemKyLuat += DiemKyLuat;

                double tong = KetquaHTKHHD * 75 / 100;
                tong += DiemPhoiHop * 10 / 100;
                tong += DiemSangTao * 5 / 100;
                tong += DiemKyLuat * 10 / 100;
                tong = Math.Round(tong, 1);

                tbDiemMucDoHoanThanh += tong;

                DataRow row = dtUsersTemp.NewRow();
                row["ID"] = item["ID"];
                row["Ten"] = item["Ten"];
                row["KetquaHTKHHD"] = item["KetquaHTKHHD"];
                row["DiemPhoiHop"] = DiemPhoiHop;
                row["DiemSangTao"] = DiemSangTao;
                row["DiemKyLuat"] = item["DiemKyLuat"];
                row["MucDoHoanThanh"] = tong;//.ToString().Substring(0, tong.ToString().IndexOf(',')) + "," + tong.ToString().Substring(tong.ToString().IndexOf(',') + 1,1);
                row["XepLoai"] = GetXepLoai(tong);

                dtUsersTemp.Rows.Add(row);              
            }

            DataTable dtBoPhan = RankDt(dtUsersTemp, "MucDoHoanThanh");

            foreach (DataRow item in dtUsersTemp.Rows)
            {
                item["Rank"] = dtBoPhan.Select(" ID='" + item["ID"] + "'")[0]["RankTemp"];
                item["DiemSangTao"] = dtBoPhan.Select(" ID='" + item["ID"] + "'")[0]["DiemSangTao"];
                item["DiemPhoiHop"] = dtBoPhan.Select(" ID='" + item["ID"] + "'")[0]["DiemPhoiHop"];
            }

            dgrBoPhan.DataSource = dtUsersTemp;
            dgrBoPhan.RowDataBound += new GridViewRowEventHandler(dgrBoPhan_RowDataBound);
            dgrBoPhan.DataBind();

            lblTotalTop.Text = lblTotalBottom.Text = dtUsers.Rows.Count.ToString();
            int i = dtUsers.Rows.Count;
            lblTBKetQuaKHHD.Text = Math.Round(tbKetquaHTKHHD / i,1).ToString() + "%";
            tblTBDiemPhoiHop.Text = Math.Round(tbDiemPhoiHop / i, 1).ToString() + "%";
            lblTBDiemSangTao.Text = Math.Round(tbDiemSangTao / i, 1).ToString() + "%";
            lblTBKyLuat.Text = Math.Round(tbDiemKyLuat / i, 1).ToString() + "%";
            lblTBMucDoHoanThanh.Text = Math.Round(tbDiemMucDoHoanThanh / i, 1).ToString() + "%";
        }


        public DataTable RankDt(DataTable dt, string fld)
        {
            var rankDt = (from row in dt.AsEnumerable()
                          orderby row.Field<double>(fld) descending
                          select row).CopyToDataTable();

            rankDt.Columns.Add("RankTemp");
            int rank = 1;
            for (int i = 0; i < rankDt.Rows.Count - 1; i++)
            {
                rankDt.Rows[i]["RankTemp"] = rank;
                if (rankDt.Rows[i][fld].ToString() != rankDt.Rows[i + 1][fld].ToString())
                    rank++;
            }
            rankDt.Rows[rankDt.Rows.Count - 1]["RankTemp"] = rank;
            return rankDt;
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

    }
}