using System;
using System.Collections.Generic;
using System.Text;

namespace VmgPortal.Library.Components.Security
{
	public class AdminPage : AuthenticatedPage
	{
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			if(CurrentUser == null) Response.Redirect("/Login.aspx?returnurl=" + returnUrl);
		}
	}

}
