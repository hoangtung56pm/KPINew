using System;
namespace VmgPortal.Library.Components.Portal.Data
{
    public class Portal_CacheInfo
    {
        private int _portal_Cache_ID;
        public int Portal_Cache_ID
        {
            get { return _portal_Cache_ID; }
            set { _portal_Cache_ID = value; }
        }

        private int _portalID;
        public int PortalID
        {
            get { return _portalID; }
            set { _portalID = value; }
        }

        private int _zoneID;
        public int ZoneID
        {
            get { return _zoneID; }
            set { _zoneID = value; }
        }

        private string _cacheKey;
        public string CacheKey
        {
            get { return _cacheKey; }
            set { _cacheKey = value; }
        }

    }
}
