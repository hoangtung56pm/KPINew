using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VmgPortal.Library;
using VmgPortal.Library.Components.Portal;
using VmgPortal.Library.Components.Roles;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Components.Users;
using VmgPortal.Library.Utilities;
namespace VmgPortal.Administrator.Users
{
    public partial class CreateUser : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int userId = ConvertUtility.ToInt32(Request.QueryString["uid"]);

                if (userId == 0)
                {
                    //tabLyLichCaNhan.Enabled = true;
                }
                else
                {
                    //tabThongTinMoRong.Enabled = true;
                    //tabThongTinGiaDinh.Enabled = true;
                    //tabHocVan.Enabled = true;
                    //tabQuaTrinhLamViec.Enabled = true;
                    //tabHopDongLaoDong.Enabled = true;
                    //tabHopDongLaoDongGiaHan3.Enabled = true;
                    //tabDieuChinhNhanSu.Enabled = true;
                }

            }
        }
        
    }
}