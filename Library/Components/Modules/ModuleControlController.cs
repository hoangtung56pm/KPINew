using System.Data;
using VmgPortal.Library.Components.Providers;

namespace VmgPortal.Library.Components.Modules
{
	public class ModuleControlController
	{
		public const string key = "VmgPortal.Portal.ModuleControl";
		public static DataTable GetModuleControls()
		{
            string param = "GetModuleControls";
            DataCaching data = new DataCaching();
			DataTable dtModuleControls = (DataTable)data.GetHashCache(key, param);
			if (dtModuleControls != null) return dtModuleControls;
			dtModuleControls = DataAccessProvider.Instance().GetModuleControls();
			data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtModuleControls);
			return dtModuleControls;
		}
		public static DataTable GetModuleControls(int moduleId)
		{
			string param = "GetModuleControls?moduleId=" + moduleId;
			DataCaching data = new DataCaching();
			DataTable dtModuleControls = (DataTable)data.GetHashCache(key, param);
			if (dtModuleControls != null) return dtModuleControls;
			dtModuleControls = DataAccessProvider.Instance().GetModuleControls(moduleId);
			data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtModuleControls);
			return dtModuleControls;
		}
		public static DataTable GetModuleControlsForCommand()
		{
			string param = "GetModuleControlsForCommand";
			DataCaching data = new DataCaching();
			DataTable dtModuleControls = (DataTable)data.GetHashCache(key, param);
			if (dtModuleControls != null) return dtModuleControls;
			dtModuleControls = DataAccessProvider.Instance().GetModuleControlsForCommand();
			data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtModuleControls);
			return dtModuleControls;
		}
		public static DataTable GetModuleControlsForWeb()
		{
			string param = "GetModuleControlsForWeb";
			DataCaching data = new DataCaching();
			DataTable dtModuleControls = (DataTable)data.GetHashCache(key, param);
			if (dtModuleControls != null) return dtModuleControls;
			dtModuleControls = DataAccessProvider.Instance().GetModuleControlsForWeb();
			data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtModuleControls);
			return dtModuleControls;
		}
		public static DataTable GetModuleControls(int tabId, string position)
		{
			string param = "GetModuleControls?tabId=" + tabId.ToString() + "&position=" + position;
			DataCaching data = new DataCaching();
			DataTable dtModuleControls = (DataTable)data.GetHashCache(key, param);
			if (dtModuleControls != null) return dtModuleControls;
			dtModuleControls = DataAccessProvider.Instance().GetModuleControls(tabId, position);
			data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtModuleControls);
			return dtModuleControls;
		}
		public static int AddModuleControl(ModuleControlInfo moduleControl)
		{
			int id = DataAccessProvider.Instance().AddModuleControl(moduleControl);
			DataCaching data = new DataCaching();
			data.RemoveCache(key);
			return id;
		}
		public static void UpdateModuleControl(ModuleControlInfo moduleControl)
		{
			DataAccessProvider.Instance().UpdateModuleControl(moduleControl);
			DataCaching data = new DataCaching();
			data.RemoveCache(key);
		}
		public static void DeleteModuleControl(int controlId)
		{
			DataAccessProvider.Instance().DeleteModuleControl(controlId);
            DataCaching data = new DataCaching();
            data.RemoveCache(key);
		}
		public static ModuleControlInfo GetModuleControl(int controlId)
		{
            string param = "GetModuleControl?controlId=" + controlId.ToString();
            DataCaching data = new DataCaching();
            ModuleControlInfo setting = (ModuleControlInfo)data.GetHashCache(key, param);
            if (setting != null) return setting;
            setting = DataAccessProvider.Instance().GetModuleControl(controlId);
            data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), setting);
            return setting;
		}
		public static ModuleControlInfo GetModuleControl(string controlKey)
		{
            string param = "GetModuleControl?controlKey=" + controlKey.ToString();
            DataCaching data = new DataCaching();
            ModuleControlInfo setting = (ModuleControlInfo)data.GetHashCache(key, param);
            if (setting != null) return setting;
            setting = DataAccessProvider.Instance().GetModuleControl(controlKey);
            data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), setting);
            return setting;
		}
		public static ModuleSetting GetModuleSettings(int moduleId)
		{
			string param = "GetModuleSettings?moduleId=" + moduleId.ToString();
			DataCaching data = new DataCaching();
			ModuleSetting setting = (ModuleSetting)data.GetHashCache(key, param);
			if (setting != null) return setting;
			setting = DataAccessProvider.Instance().GetModuleSettings(moduleId);
			data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), setting);
			return setting;
		}
		public static bool CheckExistsControlKey(string controlKey)
		{
			return DataAccessProvider.Instance().CheckExistsControlKey(controlKey);
		}
	}
}
