using System;
using System.Collections.Generic;
using System.Text;

namespace VmgPortal.Library.Components.Modules
{
	public class ModuleControlInfo
	{
		private int _controlID;
		public int ControlID
		{
			get { return _controlID; }
			set { _controlID = value; }
		}

		private int _moduleID;
		public int ModuleID
		{
			get { return _moduleID; }
			set { _moduleID = value; }
		}

		private string _controlName;
		public string ControlName
		{
			get { return _controlName; }
			set { _controlName = value; }
		}

		private string _controlTitle;
		public string ControlTitle
		{
			get { return _controlTitle; }
			set { _controlTitle = value; }
		}

		private string _controlKey;
		public string ControlKey
		{
			get { return _controlKey; }
			set { _controlKey = value; }
		}

		private string _controlPath;
		public string ControlPath
		{
			get { return _controlPath; }
			set { _controlPath = value; }
		}

		private string _controlRole;
		public string ControlRole
		{
			get { return _controlRole; }
			set { _controlRole = value; }
		}

		private string _controlIcon;
		public string ControlIcon
		{
			get { return _controlIcon; }
			set { _controlIcon = value; }
		}

		private string _controlDescription;
		public string ControlDescription
		{
			get { return _controlDescription; }
			set { _controlDescription = value; }
		}

		private int _controlOrder;
		public int ControlOrder
		{
			get { return _controlOrder; }
			set { _controlOrder = value; }
		}
		private bool _controlHeader = true;
		public bool ControlHeader
		{
			get { return this._controlHeader; }
			set { this._controlHeader = value; }
		}
	}
}
