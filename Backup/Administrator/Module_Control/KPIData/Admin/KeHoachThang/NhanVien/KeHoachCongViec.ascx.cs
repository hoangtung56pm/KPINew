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
using VmgPortal.Library;

namespace VmgPortal.Modules.KPIData.Admin.KeHoachThang.NhanVien
{
    public partial class KeHoachCongViec : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }
        }

        protected void btnLuoi_Click(object sender, EventArgs e)
        {
            string idDotDanhGia = Request.QueryString["idDotDanhGia"];

            Response.Redirect(AppEnv.AdminUrlParams("kehoachnhanvien") + "&idDotDanhGia=" + idDotDanhGia + "&idNhanVien=" + CurrentUser.UserID);
        }        
    }
}