using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library.DanhGiaBoPhan
{
    public class DanhGiaBoPhanTTCVInfo
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

        private string _tenCongViec;
        public string TenCongViec
        {
            get { return _tenCongViec; }
            set { _tenCongViec = value; }
        }

        private double _tyTrongCV;
        public double TyTrongCV
        {
            get { return _tyTrongCV; }
            set { _tyTrongCV = value; }
        }

        private double _diemTDG;
        public double DiemTDG
        {
            get { return _diemTDG; }
            set { _diemTDG = value; }
        }

        private double _diemTBPDG;
        public double DiemTBPDG
        {
            get { return _diemTBPDG; }
            set { _diemTBPDG = value; }
        }


        private string _MatManh;
        public string MatManh
        {
            get { return _MatManh; }
            set { _MatManh = value; }
        }

        private string _MatYeu;
        public string MatYeu
        {
            get { return _MatYeu; }
            set { _MatYeu = value; }
        }

        private int _loai;
        public int Loai
        {
            get { return _loai; }
            set { _loai = value; }
        }
    }
}