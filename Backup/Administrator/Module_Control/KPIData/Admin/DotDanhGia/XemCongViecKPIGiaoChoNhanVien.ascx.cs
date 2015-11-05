using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library.Components.Security;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using VmgPortal.Library.Utilities;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;
using System.Data;
using VmgPortal.Library.Components.Users;
using System.Drawing;
using VmgPortal.Modules.KPIData.Library;
using VmgPortal.Modules.KPIData.Library.DanhGiaBoPhan;
using VmgPortal.Modules.KPIData.Library.DanhGia;
using System.IO;

namespace VmgPortal.Modules.KPIData.Admin.DotDanhGia
{
    public partial class XemCongViecKPIGiaoChoNhanVien : UserControl
    {
        int idCongViec;
        int idDotDanhGia;
        int idTrungTam;
        int idPhongBan;
        int loai;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            idCongViec = ConvertUtility.ToInt32(Request.QueryString["idCongViec"]);
            idDotDanhGia = ConvertUtility.ToInt32(Request.QueryString["idDotDanhGia"]);
            idTrungTam = ConvertUtility.ToInt32(Request.QueryString["idTrungTam"]);
            idPhongBan = ConvertUtility.ToInt32(Request.QueryString["idPhongBan"]);
            loai = ConvertUtility.ToInt32(Request.QueryString["loai"]);

            DataTable dt = new DataTable();

            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Ten", typeof(string));
            dt.Columns.Add("TyTrong", typeof(string));
            dt.Columns.Add("KeHoach", typeof(string));
            dt.Columns.Add("DonViDo", typeof(string));
            dt.Columns.Add("Level", typeof(string));
            dt.Columns.Add("Bold", typeof(string));
            DataTable source = QuanLyCongViecKTXVaPSController.LoadCongViecForView(idCongViec, dt, idTrungTam, idPhongBan, loai, idDotDanhGia);

            if (source != null && source.Rows.Count > 0)
            {
                rptCongViec.DataSource = source;
                rptCongViec.ItemDataBound += new RepeaterItemEventHandler(rptCongViec_ItemDataBound);
                rptCongViec.DataBind();
            }
        }

        void rptCongViec_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            
            DataList dl = (DataList)e.Item.FindControl("dlNhanVien");

            DataRowView crr = (DataRowView)e.Item.DataItem;

            int idCongViec = ConvertUtility.ToInt32(crr["ID"]);

            DataSet ds = DotDanhGiaController.GetAllNhanVienTheoIDCongViec(idTrungTam, idCongViec, idDotDanhGia);

            DataTable dt = ds.Tables[0].Clone();
          
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                DataRow row = dt.NewRow();
                row["HoTen"] = item["HoTen"];
                row["TyTrong"] =  Math.Round(ConvertUtility.ToDouble(item["TyTrong"]), 2);
                row["SoGio"] = Math.Round(ConvertUtility.ToDouble(item["SoGio"]), 2);
                dt.Rows.Add(row);
            }
            dl.DataSource = dt;
            dl.DataBind();
        }

    }
}