using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using VmgPortal.Library.Components.Modules;
using VmgPortal.Library.Components.Users;
using VmgPortal.Library.Utilities;

namespace VmgPortal.Library.Components.Security
{
    public class AuthenticatedControlTemp : ModuleControlBase
	{
		public new UserInfo CurrentUser
		{
			get
			{
                return ((AuthenticatedPageTemp)this.Page).CurrentUserTemp;
			}
		}
	}
}

