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

using VmgPortal.Library.Components.Modules;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Utilities;
using VmgPortal.Library;

namespace VmgPortal.Administrator.Modules
{
	public partial class ModuleDefinition : AuthenticatedControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!CurrentUser.IsSuperAdmin) Response.Redirect(AppEnv.ADMIN_CMD);
		}
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
            BindData();
		}
	    void BindData()
	    {
	        DataTable dtModules = ModuleController.GetModules();
			dtgModules.DataSource = dtModules;
			dtgModules.RowDataBound += new GridViewRowEventHandler(dtgModules_RowDataBound);
			dtgModules.DataBind();
	    }
		static void dtgModules_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
                VmgPortal.WebControls.ButtonRoleDelete btnDeleteModule = (VmgPortal.WebControls.ButtonRoleDelete)e.Row.FindControl("btnDeleteModule");
				btnDeleteModule.Attributes.Add("onclick", MiscUtility.MSG_DELETE_CONFIRM);
			}
		}
		protected void btnAddModule_Click(object sender, EventArgs e)
		{
            Response.Redirect(AppEnv.AdminUrlParams("moduleedit"));
		}
		protected void dtgModules_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			switch (e.CommandName)
			{
				case "deletemodule":
					try
					{
						int moduleId = ConvertUtility.ToInt32(e.CommandArgument);
						ModuleController.DeleteModule(moduleId);
                        BindData();
					}
					catch (Exception ex)
					{
						Response.Write(ex.Message);
					}
					break;
				case "editmodule":
					Response.Redirect(AppEnv.AdminUrlParams("moduleedit") + "&mid=" + e.CommandArgument.ToString());
					break;
			}
		}

	}
}