using System;
namespace VmgPortal.Library.Components.Portal
{
    public class Portal_PortalsInfo
    {
        private int _portalID;
        public int PortalID
        {
            get { return _portalID; }
            set { _portalID = value; }
        }

        private bool _visible;
        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        private bool _enable;
        public bool Active
        {
            get { return _enable; }
            set { _enable = value; }
        }

        private string _portal_ImageUrl;
        public string ImageUrl
        {
            get { return _portal_ImageUrl; }
            set { _portal_ImageUrl = value; }
        }

        private string _portal_Name;
        public string Portal_Name
        {
            get { return _portal_Name; }
            set { _portal_Name = value; }
        }

        private string _portal_Description;
        public string Portal_Description
        {
            get { return _portal_Description; }
            set { _portal_Description = value; }
        }

        private string _portal_Lang;
        public string Lang
        {
            get { return _portal_Lang; }
            set { _portal_Lang = value; }
        }

        private int _portal_ParentId;
        public int Portal_ParentId
        {
            get { return _portal_ParentId; }
            set { _portal_ParentId = value; }
        }

        private int _portal_Priority;
        public int Priority
        {
            get { return _portal_Priority; }
            set { _portal_Priority = value; }
        }
        private int _tabDefault;
        public int TabDefault
        {
            get { return _tabDefault; }
            set { _tabDefault = value; }
        }
    }
}
