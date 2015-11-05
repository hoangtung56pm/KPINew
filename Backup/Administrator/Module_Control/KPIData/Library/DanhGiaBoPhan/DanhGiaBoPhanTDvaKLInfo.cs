using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library.DanhGiaBoPhan
{
    public class DGBoPhanTDvaKLInfo
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

        private double _diemTDG;
        public double DiemTuDanhGia
        {
            get { return _diemTDG; }
            set { _diemTDG = value; }
        }

        private double _DiemCOODanhGia;
        public double DiemCOODanhGia
        {
            get { return _DiemCOODanhGia; }
            set { _DiemCOODanhGia = value; }
        }


        private double _diemThongNhat;
        public double DiemThongNhat
        {
            get { return _diemThongNhat; }
            set { _diemThongNhat = value; }
        }
        
        private int _loai;
        public int Loai
        {
            get { return _loai; }
            set { _loai = value; }
        }

        private string _GhiChu;
        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
    }
}