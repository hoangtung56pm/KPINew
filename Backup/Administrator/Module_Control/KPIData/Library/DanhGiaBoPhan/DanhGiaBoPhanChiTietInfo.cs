using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library.DanhGiaBoPhan
{
    public class DanhGiaBoPhanChiTietInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private int _IDDotDanhGia;
        public int IDDotDanhGia
        {
            get { return _IDDotDanhGia; }
            set { _IDDotDanhGia = value; }
        }

        private int _IDBoPhan;
        public int IDBoPhan
        {
            get { return _IDBoPhan; }
            set { _IDBoPhan = value; }
        }

        private string _NoiDung;
        public string NoiDung
        {
            get { return _NoiDung; }
            set { _NoiDung = value; }
        }

        private string _TBPDanhGia;
        public string TBPDanhGia
        {
            get { return _TBPDanhGia; }
            set { _TBPDanhGia = value; }
        }

        private string _GhiChu;
        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }

        private int _Loai;
        public int Loai
        {
            get { return _Loai; }
            set { _Loai = value; }
        }

    }
}