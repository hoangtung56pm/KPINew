using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library.DanhGia
{
    public class DGCBCNVDanhGiaNangLucNhanVienInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private int _iDDotDanhGiaVaNhanVien;
        public int IDDotDanhGiaVaNhanVien
        {
            get { return _iDDotDanhGiaVaNhanVien; }
            set { _iDDotDanhGiaVaNhanVien = value; }
        }

        private int _idNhanVien;
        public int IDNhanVien
        {
            get { return _idNhanVien; }
            set { _idNhanVien = value; }
        }

        private int _IDDotDanhGia;
        public int IDDotDanhGia
        {
            get { return _IDDotDanhGia; }
            set { _IDDotDanhGia = value; }
        }

        private double _diemTDG;
        public double DiemTDG
        {
            get { return _diemTDG; }
            set { _diemTDG = value; }
        }

        private double _DiemPTDG;
        public double DiemPTDG
        {
            get { return _DiemPTDG; }
            set { _DiemPTDG = value; }
        }

        private double _DiemThongNhat;
        public double DiemThongNhat
        {
            get { return _DiemThongNhat; }
            set { _DiemThongNhat = value; }
        }

        private int _iDNguoiDG;
        public int IDNguoiDG
        {
            get { return _iDNguoiDG; }
            set { _iDNguoiDG = value; }
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