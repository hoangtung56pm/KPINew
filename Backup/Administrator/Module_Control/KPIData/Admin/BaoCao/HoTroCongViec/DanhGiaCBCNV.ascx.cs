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
using System.Drawing;
using VmgPortal.Library;
using VmgPortal.Modules.KPIData.Library.DanhGia;

namespace VmgPortal.Modules.KPIData.Admin.HoTroCongViec
{
    public partial class DanhGiaCBCNV : AuthenticatedControl
    {
        int idDotDanhGia = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            idDotDanhGia = ConvertUtility.ToInt32(Request.QueryString["idDotDanhGia"]);           
            if (!IsPostBack)
            {
                dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
                dropDotDanhGia.DataBind();

                if (idDotDanhGia == 0)
                {
                    Response.Redirect(AppEnv.AdminUrlParams("congviechotrotrongthang") + "&idDotDanhGia=" + dropDotDanhGia.SelectedValue);
                }
                else
                {
                    dropDotDanhGia.SelectedValue = idDotDanhGia.ToString();
                }
            }

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);            
        }

        protected void dropDotDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(AppEnv.AdminUrlParams("congviechotrotrongthang") + "&idDotDanhGia=" + dropDotDanhGia.SelectedValue);
        }

    }
}