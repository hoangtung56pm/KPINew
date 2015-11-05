using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library.DinhNghia
{
    public class DinhNghiaInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private string _ten;
        public string Ten
        {
            get { return _ten; }
            set { _ten = value; }
        }

        private string _MoTa;
        public string MoTa
        {
            get { return _MoTa; }
            set { _MoTa = value; }
        }

        private string _Code;
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

    }
}