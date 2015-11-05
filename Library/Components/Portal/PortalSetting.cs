using System.Collections;
using VmgPortal.Library.Components.Providers;

namespace VmgPortal.Library.Components.Portal
{
	public class PortalSetting : Hashtable
	{
		private const string key = "Portal_Settings";
		public static PortalSetting GetSetting()
		{
            DataCaching data = new DataCaching();
            PortalSetting setting = (PortalSetting)data.GetCache(key);
            if (setting != null) return setting;
            setting = DataAccessProvider.Instance().GetPortalSetting();
            data.InsertCacheNoExpireTime(key, setting);
			return setting;
		}
		public static void SetValue(string settingName, string settingValue)
		{
			DataAccessProvider.Instance().SetPortalSetting(settingName, settingValue);
			DataCaching data = new DataCaching();
			data.RemoveCache(key);
		}
		public static void SetValue(string settingName, string settingValue, string param1, string param2)
		{
			DataAccessProvider.Instance().SetPortalSetting(settingName, settingValue, param1, param2);
			DataCaching data = new DataCaching();
			data.RemoveCache(key);
		}
	}
}
