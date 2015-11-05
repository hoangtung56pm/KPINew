using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Xml;

namespace VmgPortal.Library.Components.Providers
{
	public class DataAccessProviderConfigurationHandler : IConfigurationSectionHandler
	{
		public object Create(object parent, object context, XmlNode node)
		{
			DataAccessProviderConfiguration objConfig = new DataAccessProviderConfiguration();
			objConfig.LoadValuesFromConfigurationXml(node);
			return objConfig;
		}
		
	}
}
