using System;
using System.Data;
using VmgPortal.Library;
using VmgPortal.Library.Components.Commands;
using VmgPortal.Library.Components.Roles;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Components.Users;
using VmgPortal.Library.Components.Providers;
using VmgPortal.Library.Utilities;

namespace VmgPortal.WebControls
{
	/// <summary>
	/// Summary description for ButtonRoleViewAll.
	/// </summary>
    public class PanelXzone : System.Web.UI.WebControls.Panel
	{
        protected bool pmsRoleXzone;
        protected bool pmsRoleXzone1;

        private AuthenticatedPage CurrentPage
		{
            get { return (AuthenticatedPage)this.Page; }
		}

        protected UserInfo CurrentUser
		{
			get { return CurrentPage.CurrentUser; }
		}

		protected override void OnPreRender(EventArgs e)
		{
            if (CurrentUser.IsSuperAdmin || CurrentUser.IsAdmin)
            {
                this.Visible = true;
            }
            else
            {
                DataTable dt = CommandController.GetRoleForUserByPortalID(CurrentUser.UserID, ConvertUtility.ToInt32(AppEnv.PortalId()));

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count > 1)
                    {
                        pmsRoleXzone = ConvertUtility.ToBoolean(dt.Rows[0]["UseForXzone"]);
                        pmsRoleXzone1 = ConvertUtility.ToBoolean(dt.Rows[1]["UseForXzone"]);

                        if (!pmsRoleXzone && !pmsRoleXzone1)
                        {
                            this.Visible = false;
                        }
                        else
                        {
                            this.Visible = true;
                        }
                    }
                    else
                    {
                        pmsRoleXzone = ConvertUtility.ToBoolean(dt.Rows[0]["UseForXzone"]);
                        if (!pmsRoleXzone)
                        {
                            this.Visible = false;
                        }
                        else
                        {
                            this.Visible = true;
                        }
                    }
                }
                else
                {
                    this.Visible = false;
                }
            }
		}
	}
}
