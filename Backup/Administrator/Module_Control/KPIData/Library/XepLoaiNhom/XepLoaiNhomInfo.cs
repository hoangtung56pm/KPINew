using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library.XepLoaiNhom
{
    public class XepLoaiNhomInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private int _iDNhomNhanVien;
        public int IDNhomNhanVien
        {
            get { return _iDNhomNhanVien; }
            set { _iDNhomNhanVien = value; }
        }

        private int _iDXepLoai;
        public int IDXepLoai
        {
            get { return _iDXepLoai; }
            set { _iDXepLoai = value; }
        }

        private int _min;
        public int Min
        {
            get { return _min; }
            set { _min = value; }
        }

        private int _max;
        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }

    }
}