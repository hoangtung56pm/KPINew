using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using VmgPortal.Library.Utilities;
using VmgPortal.Modules.KPIData.Library.DanhGia;
using VmgPortal.Library;
using VmgPortal.Library.Components.Security;
using VmgPortal.Modules.KPIData.Library;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;
using VmgPortal.Modules.KPIData.Library.BoPhan;

namespace VmgPortal.Modules.KPIData.Admin.HoTroCongViec
{
    public partial class DanhGiaCBCNV_KhoiLuongCVKTX : AuthenticatedControl
    {
        int idDotDanhGia = 0;
        static DataTable dtBoPhanHoTro;
        protected void Page_Load(object sender, EventArgs e)
        {
            idDotDanhGia = ConvertUtility.ToInt32(Request.QueryString["idDotDanhGia"]);

            if (idDotDanhGia == 0)
            {
                idDotDanhGia = CurrentUser.IDDotDanhGiaVaNhanVien;
            }

            if (!IsPostBack)
            {
                dtBoPhanHoTro = BoPhanController.BoPhan_GetAllActive();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            
            #region Cong viec khong thuong xuyen

            DataTable dtCongViec2 = DanhGiaThang_DGCBCNVDanhGiaTTCVController.DanhGiaThang_GetAllCongViecCanHoTro(2, idDotDanhGia, CurrentUser.IDTrungTam);
            dgrKhoiLuongCV2.DataSource = dtCongViec2;
            dgrKhoiLuongCV2.DataBind();

            #endregion
        }

        #region Những công việc không thường xuyên

        protected void dgrKhoiLuongCV2_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgrKhoiLuongCV2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void dgrKhoiLuongCV2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        
        #endregion

        protected void dgrKhoiLuongCV2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex < 0) return;

            TextBox txtTyTrongCV = (TextBox)e.Row.FindControl("txtTyTrongCV");
            TextBox txtTenCongViec = (TextBox)e.Row.FindControl("txtTenCongViec");
            TextBox txtSoLieuCamKet = (TextBox)e.Row.FindControl("txtSoLieuCamKet");
            TextBox txtYeuCauHoTro = (TextBox)e.Row.FindControl("txtYeuCauHoTro");
            ListBox dropBoPhanHoTro = (ListBox)e.Row.FindControl("dropBoPhanHoTro");

            txtTyTrongCV.ReadOnly = true;
            txtSoLieuCamKet.ReadOnly = true;
            txtYeuCauHoTro.ReadOnly = true;
            txtTenCongViec.ReadOnly = true;

            DataRowView crrData = (DataRowView)e.Row.DataItem;

            int idDotDanhGia = ConvertUtility.ToInt32(crrData["IDDotDanhGia"]);
            int idCongViec = ConvertUtility.ToInt32(crrData["IDCongViec"]);

            dropBoPhanHoTro.Items.Clear();
            dropBoPhanHoTro.DataSource = dtBoPhanHoTro;
            dropBoPhanHoTro.DataBind();

            DataTable dtBoPhanHoTroSelected = DanhGiaThang_DGCBCNVDanhGiaTTCVController.GetKeHoachThangBoPhanHoTro(idDotDanhGia, idCongViec);
            if (dtBoPhanHoTroSelected != null && dtBoPhanHoTroSelected.Rows.Count > 0)
            {
                foreach (ListItem item in dropBoPhanHoTro.Items)
                {
                    DataRow[] row = dtBoPhanHoTroSelected.Select("IDBoPhanHoTro = " + item.Value);
                    if (row.Length > 0)
                    {
                        item.Selected = true;
                    }
                }
            }
        }
    }
}