using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Compilation;

namespace VmgPortal.Library.Components.Providers
{
	public class DataAccessProviderFactory
	{
		private static DataAccessProvider objProvider;
		public static DataAccessProvider CreateDataAccess()
		{
			DataAccessProviderConfiguration objConfig = DataAccessProviderConfiguration.GetDataAccessProviderConfiguration();
			return CreateDataAccess(objConfig);
		}
		public static DataAccessProvider CreateDataAccess(DataAccessProviderConfiguration objConfig)
		{
			if (objProvider != null) return objProvider;
			Type type = Type.GetType(((Provider) objConfig.Providers[objConfig.DefaultProvider]).ProviderType);
			objProvider = (DataAccessProvider)Activator.CreateInstance(type, AppEnv.GetConnectionString(((Provider)objConfig.Providers[objConfig.DefaultProvider]).ConnectionString));
			return objProvider;
		}
		public static object CreateDataAccess(Provider provider)
		{
			Type type = BuildManager.GetType(provider.ProviderType, true);
			object obj = Activator.CreateInstance(type, AppEnv.GetConnectionString(provider.ConnectionString));
			return obj;
		}
	}
}
