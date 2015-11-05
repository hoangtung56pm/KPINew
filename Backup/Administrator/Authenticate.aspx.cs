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
using VmgPortal.Library.Components.Security;
namespace VmgPortal.Administrator
{
    public partial class Authenticate : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!CurrentUser.IsSuperAdmin)
                {
                    PortalController.LoadPortalsForRadComboByUserID(dropPortal.Items, CurrentUser.UserID);
                }
                else
                {
                    PortalController.LoadPortalsForRadCombo(dropPortal.Items);
                }
            }

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            Response.Redirect(AppEnv.ADMIN_CMD + "?portalid=" + dropPortal.SelectedValue);
        }

    }
}
