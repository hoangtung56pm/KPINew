using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library.Nhom
{
    public class NhomInfo
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

        private int _trangThai;
        public int TrangThai
        {
            get { return _trangThai; }
            set { _trangThai = value; }
        }

    }
}