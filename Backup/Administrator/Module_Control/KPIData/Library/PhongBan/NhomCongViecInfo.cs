using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library.PhongBan
{
    public class NhomCongViecInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private int _IDBoPhan;
        public int IDBoPhan
        {
            get { return _IDBoPhan; }
            set { _IDBoPhan = value; }
        }

        private string _TenNhomViec;
        public string TenNhomViec
        {
            get { return _TenNhomViec; }
            set { _TenNhomViec = value; }
        }

        private string _Ma;
        public string Ma
        {
            get { return _Ma; }
            set { _Ma = value; }
        }

        private string _moTa;
        public string MoTa
        {
            get { return _moTa; }
            set { _moTa = value; }
        }

    }
}