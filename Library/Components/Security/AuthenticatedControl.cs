using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using VmgPortal.Library.Components.Modules;
using VmgPortal.Library.Components.Users;
using VmgPortal.Library.Utilities;

namespace VmgPortal.Library.Components.Security
{
	public class AuthenticatedControl : ModuleControlBase
	{
		public new UserInfo CurrentUser
		{
			get
			{
				return ((AuthenticatedPage)this.Page).CurrentUser;
			}
		}
        public bool IsRefreshed
        {
            get
            {
                return true;//((RefreshPage)this.Page).IsRefreshed;
            }
        }  
	}
}

