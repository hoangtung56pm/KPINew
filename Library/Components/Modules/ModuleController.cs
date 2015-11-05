using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using VmgPortal.Library.Components.Providers;

namespace VmgPortal.Library.Components.Modules
{
	public class ModuleController
	{
		public static DataTable GetModules()
		{
			const string key = "VmgPortal.Portal.Module.GetModules";
			DataCaching data = new DataCaching();
			DataTable dtModuleControls = (DataTable)data.GetCache(key);
			if (dtModuleControls != null) return dtModuleControls;
			return DataAccessProvider.Instance().GetModules();
		}
		public static int AddModule(ModuleInfo module)
		{
			int id = DataAccessProvider.Instance().AddModule(module);
			DataCaching data = new DataCaching();
			
			return id;
		}
		public static void UpdateModule(ModuleInfo module)
		{
			DataAccessProvider.Instance().UpdateModule(module);
			DataCaching data = new DataCaching();
			
		}
		public static void DeleteModule(int moduleId)
		{
			DataAccessProvider.Instance().DeleteModule(moduleId);
			DataCaching data = new DataCaching();
			
		}
		public static ModuleInfo GetModule(int moduleId)
		{
			return DataAccessProvider.Instance().GetModule(moduleId);
		}
		public static ModuleSetting GetModuleSettings(int moduleId)
		{
			const string key = "VmgPortal.Portal.ModuleControl.GetModuleSettings";
			string param = moduleId.ToString();
			DataCaching data = new DataCaching();
			ModuleSetting setting = (ModuleSetting)data.GetHashCache(key, param);
			if (setting != null) return setting;
			setting = DataAccessProvider.Instance().GetModuleSettings(moduleId);
			data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), setting);
			return setting;
		}
		public static void SetModuleSetting(int moduleId, string name, string value)
		{
			DataAccessProvider.Instance().SetModuleSetting(moduleId, name, value);
		}
	}
}
