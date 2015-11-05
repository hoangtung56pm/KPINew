using System;
using System.Collections.Generic;
using System.Text;

namespace VmgPortal.Library.Components.Roles
{
	public class RoleInfo
	{
		private int _roleID;
		public int RoleID
		{
			get { return _roleID; }
			set { _roleID = value; }
		}

		private string _roleName;
		public string RoleName
		{
			get { return _roleName; }
			set { _roleName = value; }
		}

		private string _roleDescription;
		public string RoleDescription
		{
			get { return _roleDescription; }
			set { _roleDescription = value; }
		}
	    
        private string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private string _Fax;
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private int _UserManager;
        public int UserManager
        {
            get { return _UserManager; }
            set { _UserManager = value; }
        }

        private int _RoleParentID;
        public int RoleParentID
        {
            get { return _RoleParentID; }
            set { _RoleParentID = value; }
        }
	}
}
