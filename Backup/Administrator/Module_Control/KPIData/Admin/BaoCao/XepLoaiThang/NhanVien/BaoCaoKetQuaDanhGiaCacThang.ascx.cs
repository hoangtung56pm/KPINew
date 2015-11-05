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
using System.Drawing;

namespace VmgPortal.Modules.KPIData.Admin.BaoCao.XepLoaiThang.NhanVien
{
    public partial class BaoCaoKetQuaDanhGiaCacThang : AuthenticatedControl
    {
        int idNhanVien = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            idNhanVien = ConvertUtility.ToInt32(Request.QueryString["idNhanVien"]);

            if (!IsPostBack)
            {
                lstDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
                lstDotDanhGia.DataBind();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            string idDotDanhGia = "";

            foreach (ListItem item in lstDotDanhGia.Items)
            {
                if (item.Selected == true)
                {
                    idDotDanhGia += item.Value + ",";
                }
            }

            if (idDotDanhGia.Length > 1)
            {
                idDotDanhGia = idDotDanhGia.Substring(0, idDotDanhGia.Length - 1);
            }

            if (idDotDanhGia != "")
            {
                DataSet ds = CommonController.BaoCaoKetQuaXepLoaiNhanVienCacThang(idDotDanhGia, idNhanVien);

                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dtUserInfo = ds.Tables[0];

                    if (dtUserInfo != null && dtUserInfo.Rows.Count > 0)
                    {
                        DataRow row = dtUserInfo.Rows[0];
                        lblHoTen.Text = lblName.Text = row["HoTen"].ToString();
                        lblMaSo.Text = row["MaSo"].ToString();
                        lblBoPhan.Text = row["BoPhan"].ToString();
                        lblPhong.Text = row["Phong"].ToString();
                        lblNhom.Text = row["IDNhom"].ToString();
                    }

                    DataTable dtSoThangLoaiACong = ds.Tables[1];

                    if (dtSoThangLoaiACong != null && dtSoThangLoaiACong.Rows.Count > 0)
                    {
                        DataRow row = dtSoThangLoaiACong.Rows[0];
                        lblLoaiACong.Text = row["LoaiACong"].ToString();
                    }

                    DataTable dtSoThangLoaiA = ds.Tables[2];

                    if (dtSoThangLoaiA != null && dtSoThangLoaiA.Rows.Count > 0)
                    {
                        DataRow row = dtSoThangLoaiA.Rows[0];
                        lblLoaiA.Text = row["LoaiA"].ToString();
                    }

                    DataTable dtSoThangLoaiB = ds.Tables[3];

                    if (dtSoThangLoaiB != null && dtSoThangLoaiB.Rows.Count > 0)
                    {
                        DataRow row = dtSoThangLoaiB.Rows[0];
                        lblLoaiB.Text = row["LoaiB"].ToString();
                    }

                    DataTable dtSoThangLoaiC = ds.Tables[4];

                    if (dtSoThangLoaiC != null && dtSoThangLoaiC.Rows.Count > 0)
                    {
                        DataRow row = dtSoThangLoaiC.Rows[0];
                        lblLoaiC.Text = row["LoaiC"].ToString();
                    }

                    DataTable dtSoThangLoaiD = ds.Tables[5];

                    if (dtSoThangLoaiD != null && dtSoThangLoaiD.Rows.Count > 0)
                    {
                        DataRow row = dtSoThangLoaiD.Rows[0];
                        lblLoaiD.Text = row["LoaiD"].ToString();
                    }

                    DataTable dtChiTietCacThang = ds.Tables[6];

                    if (dtChiTietCacThang != null && dtChiTietCacThang.Rows.Count > 0)
                    {
                        string builder = "";
                        foreach (DataRow item in dtChiTietCacThang.Rows)
                        {
                            builder += "<tr>";
                            builder += "<td>";
                            builder += "<b>" + item["Ten"]+ "</b>";
                            builder += "</td>";
                            builder += "<td>";
                            if (ConvertUtility.ToString(item["XepLoai"]) == "")
                            {
                                builder += "<b style=\"color: Blue\">Chưa đánh giá</b>";
                            }
                            else
                            {
                                builder += "<b style=\"color: Blue\">Loại " + item["XepLoai"] + "</b>";
                            }
                            builder += "</td>";
                            builder += "</tr>";
                        }

                        litResult.Text = builder;
                        //Literal1.Text = Literal2.Text = Literal3.Text = Literal4.Text = Literal5.Text = Literal6.Text = Literal7.Text = Literal8.Text = Literal9.Text = Literal10.Text = Literal11.Text = 
                    }
                    else
                    {
                        litResult.Text = "<tr><td></td><td></td></tr>";
                    }
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

    }
}