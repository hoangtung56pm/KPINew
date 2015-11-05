using System;
using System.Collections.Generic;
using System.Text;

namespace VmgPortal.Library.Components.Lang
{
    public class MainLanguagesInfo
    {
        private string _language_Culture;
        public string Language_Culture
        {
            get { return _language_Culture; }
            set { _language_Culture = value; }
        }

        private string _language_Name;
        public string Language_Name
        {
            get { return _language_Name; }
            set { _language_Name = value; }
        }

    }
}
