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
    public class PanelWeb : System.Web.UI.WebControls.Panel
	{
        protected bool pmsRoleWeb;
        protected bool pmsRoleWeb1;

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
                        pmsRoleWeb = ConvertUtility.ToBoolean(dt.Rows[0]["UseForWeb"]);
                        pmsRoleWeb1 = ConvertUtility.ToBoolean(dt.Rows[1]["UseForWeb"]);

                        if (!pmsRoleWeb && !pmsRoleWeb1)
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
                        pmsRoleWeb = ConvertUtility.ToBoolean(dt.Rows[0]["UseForWeb"]);
                        if (!pmsRoleWeb)
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
