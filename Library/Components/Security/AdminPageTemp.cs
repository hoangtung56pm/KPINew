using System;
using System.Collections.Generic;
using System.Text;

namespace VmgPortal.Library.Components.Security
{
    public class AdminPageTemp : AuthenticatedPageTemp
	{
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			if(CurrentUserTemp == null) Response.Redirect("/Login.aspx?returnurl=" + returnUrl);
		}
	}

}
