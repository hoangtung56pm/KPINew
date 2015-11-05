using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library.BoPhan
{
    public class BoPhanInfo
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

        private string _moTa;
        public string MoTa
        {
            get { return _moTa; }
            set { _moTa = value; }
        }

        private int _Loai;
        public int Loai
        {
            get { return _Loai; }
            set { _Loai = value; }
        }
        
    }
}