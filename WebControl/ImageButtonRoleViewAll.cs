using System;
using System.Data;
using VmgPortal.Library;
using VmgPortal.Library.Components.Commands;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Components.Users;
using VmgPortal.Library.Utilities;

namespace VmgPortal.WebControls
{
	/// <summary>
	/// Summary description for ButtonRoleViewAll.
	/// </summary>
	public class ImageButtonRoleViewAll : System.Web.UI.WebControls.ImageButton
	{
        protected bool pmsRole;
        protected bool pmsRole1;

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
            base.OnInit(e);
            if (CurrentUser.IsSuperAdmin)// || CurrentUser.IsAdmin
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
                        pmsRole = ConvertUtility.ToBoolean(dt.Rows[0]["Role_View"]);
                        pmsRole1 = ConvertUtility.ToBoolean(dt.Rows[1]["Role_View"]);

                        if (!pmsRole && !pmsRole1)
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
                        pmsRole = ConvertUtility.ToBoolean(dt.Rows[0]["Role_View"]);
                        if (!pmsRole)
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
