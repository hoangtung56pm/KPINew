using System;
using System.Collections.Generic;
using System.Text;

namespace VmgPortal.Library.Components.Commands
{
	public class CommandInfo
	{
		private int _commandID;
		public int CommandID
		{
			get { return _commandID; }
			set { _commandID = value; }
		}

		private int _commandParentID;
		public int CommandParentID
		{
			get { return _commandParentID; }
			set { _commandParentID = value; }
		}

        private string _commandName;
        public string CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }

		private string _commandKey;
		public string CommandKey
		{
			get { return _commandKey; }
			set { _commandKey = value; }
		}
		private string _controlPath;
		public string ControlPath
		{
			get { return this._controlPath; }
			set { this._controlPath = value; }
		}
		private string _commandParams;
		public string CommandParams
		{
			get { return _commandParams; }
			set { _commandParams = value; }
		}

		private string _commandUrl;
		public string CommandUrl
		{
			get { return _commandUrl; }
			set { _commandUrl = value; }
		}

		private int _commandOrder;
		public int CommandOrder
		{
			get { return _commandOrder; }
			set { _commandOrder = value; }
		}

		private bool _commandVisible;
		public bool CommandVisible
		{
			get { return _commandVisible; }
			set { _commandVisible = value; }
		}

		private bool _commandEnable;
		public bool CommandEnable
		{
			get { return _commandEnable; }
			set { _commandEnable = value; }
		}

		private bool _isSuperUser;
		public bool IsSuperUser
		{
			get { return _isSuperUser; }
			set { _isSuperUser = value; }
		}

	}
}
