using System.Data;
using System.Web.UI;
using VmgPortal.Library.Components.Portal;
using VmgPortal.Library.Components.Roles;
//using VmgPortal.Library.Components.Tabs;
using VmgPortal.Library.Components.Users;
namespace VmgPortal.Library.Components.Modules
{
	public class ModuleControlBase : System.Web.UI.UserControl, ITemplate
	{
		private int _tabControlId = 0;
        //private TabControlInfo _tabControl = null;
		private int _controlId = 0;
		private UserInfo _curUser = null;
		private PortalSetting _portal;
        private Portal_PortalsInfo _portalInfo = null;
        //public int TabControlID
        //{
        //    get { return this._tabControlId; }
        //    set 
        //    { 
        //        this._tabControlId = value;
        //        this._tabControl = TabController.GetTabControl(this.TabControlID);
        //    }
        //}
        //public TabControlInfo TabControl
        //{
        //    get { return this._tabControl; }
        //}
		public int ControlID
		{
			get
			{
				return this._controlId;
			}
			set { this._controlId = value; }
		}
		public UserInfo CurrentUser
		{
			get
			{
				if (this._curUser == null) 
                {
                    this._curUser = UserController.GetCurrentUser();               
                }
				return this._curUser;
			}
		}
	
		public int ModuleID
		{
			get
			{
				if (this.ControlID != 0)
				{
					ModuleControlInfo control = ModuleControlController.GetModuleControl(this.ControlID);
					if (control != null) return control.ModuleID;
				}
				return 0;
			}
		}
		public ModuleSetting Setting
		{
			get
			{
				if (this.ModuleID != 0) return ModuleSetting.GetModuleSetting(this.ModuleID);
					return null;
			}
		}
		public PortalSetting Portal
		{
			get
			{
				if (this._portal == null)
					this._portal = PortalSetting.GetSetting();
				return this._portal;
			}
		}

        public Portal_PortalsInfo PortalInfo
        {
            get { return this._portalInfo; }            
        }

		public void InstantiateIn(Control container)
		{
			DataTable dtCurrentRoles = null;
			ModuleControlInfo moduleControl = ModuleControlController.GetModuleControl(ControlID);
			if (moduleControl == null) return;
			if(moduleControl.ControlRole == string.Empty)
			{
				container.Controls.Add(this);
				return;
			}else if(CurrentUser != null)
			{
				dtCurrentRoles = RoleController.GetRoles(CurrentUser.UserID);
				string[] roleList = moduleControl.ControlRole.Split("|".ToCharArray());
				for (int i = 0; i < roleList.Length; i++ )
				{
					if (dtCurrentRoles.Select("RoleID = " + roleList[i]).Length > 0)
					{
						container.Controls.Add(this);
					}
				}
			}
		}
	}
}