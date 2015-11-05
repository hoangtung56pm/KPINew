using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library.DanhGia
{
    public class DGCBCNVDanhGiaCLCVInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private int _iDDotDanhGia;
        public int IDDotDanhGia
        {
            get { return _iDDotDanhGia; }
            set { _iDDotDanhGia = value; }
        }

        private int _iDNhanVien;
        public int IDNhanVien
        {
            get { return _iDNhanVien; }
            set { _iDNhanVien = value; }
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

        private double _diemThongNhat;
        public double DiemThongNhat
        {
            get { return _diemThongNhat; }
            set { _diemThongNhat = value; }
        }

        private int _iDNguoiDG;
        public int IDNguoiDG
        {
            get { return _iDNguoiDG; }
            set { _iDNguoiDG = value; }
        }

        private int _iDNguoiTN;
        public int IDNguoiTN
        {
            get { return _iDNguoiTN; }
            set { _iDNguoiTN = value; }
        }

        private int _loai;
        public int Loai
        {
            get { return _loai; }
            set { _loai = value; }
        }

        private string _ghiChu;
        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }
    }
}