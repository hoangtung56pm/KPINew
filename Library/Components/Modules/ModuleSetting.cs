using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using VmgPortal.Library.Components.Providers;

namespace VmgPortal.Library.Components.Modules
{
	public class ModuleSetting : Hashtable
	{
		public static ModuleSetting GetModuleSetting(int moduleId)
		{
			return ModuleController.GetModuleSettings(moduleId);
		}
		public static void SetValue(int moduleId, string name, string value)
		{
			ModuleController.SetModuleSetting(moduleId, name, value);
		}
	}
}
