using System;
using System.Collections.Generic;
using System.Text;

namespace VmgPortal.Library.Components.Modules
{
	public class ModuleInfo
	{
		private int _moduleID;
		public int ModuleID
		{
			get { return _moduleID; }
			set { _moduleID = value; }
		}

		private string _moduleName;
		public string ModuleName
		{
			get { return _moduleName; }
			set { _moduleName = value; }
		}

		private string _moduleTitle;
		public string ModuleTitle
		{
			get { return _moduleTitle; }
			set { _moduleTitle = value; }
		}

		private string _moduleDescription;
		public string ModuleDescription
		{
			get { return _moduleDescription; }
			set { _moduleDescription = value; }
		}
		private string _moduleFolder;
		public string ModuleFolder
		{
			get { return this._moduleFolder; }
			set { this._moduleFolder = value; }
		}
	}
}
