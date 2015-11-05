using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using VmgPortal.Library.Components.Portal.Data;
using VmgPortal.Library.Components.Providers;

namespace VmgPortal.Library.Components.Portal
{
    public class PortalCacheController
    {
        public static int AddPortalCache(Portal_CacheInfo portal)
        {
            return DataAccessProvider.Instance().AddPortalCache(portal);
        }

        public static DataTable GetPortalCacheByPortalIdAndZoneID(int portalId, int zoneid)
        {
            DataTable dt = DataAccessProvider.Instance().GetPortalCacheByPortalIdAndZoneID(portalId, zoneid);
            return dt;
        }

        public static void DeletePortalCache(Portal_CacheInfo info)
        {
            DataAccessProvider.Instance().DeletePortalCache(info);
        }

    }
}
