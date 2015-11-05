using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library.DanhGiaBoPhan
{
    public class DanhGiaThang_BoPhanTTCVInfo
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

        private int _iDBoPhan;
        public int IDBoPhan
        {
            get { return _iDBoPhan; }
            set { _iDBoPhan = value; }
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

        private string _soLieuCamKet;
        public string SoLieuCamKet
        {
            get { return _soLieuCamKet; }
            set { _soLieuCamKet = value; }
        }

        private int _soLieuThucHienThucTeTrongThang;
        public int SoLieuThucHienThucTeTrongThang
        {
            get { return _soLieuThucHienThucTeTrongThang; }
            set { _soLieuThucHienThucTeTrongThang = value; }
        }

        private double _tBPDanhGia;
        public double TBPDanhGia
        {
            get { return _tBPDanhGia; }
            set { _tBPDanhGia = value; }
        }

        private double _tBPDanhGiaLai;
        public double TBPDanhGiaLai
        {
            get { return _tBPDanhGiaLai; }
            set { _tBPDanhGiaLai = value; }

        }
        private double _cOODanhGia;
        public double COODanhGia
        {
            get { return _cOODanhGia; }
            set { _cOODanhGia = value; }
        }

        private string _yKienCuaCOO;
        public string YKienCuaCOO
        {
            get { return _yKienCuaCOO; }
            set { _yKienCuaCOO = value; }
        }

        private string _yKienCuaCEO;
        public string YKienCuaCEO
        {
            get { return _yKienCuaCEO; }
            set { _yKienCuaCEO = value; }
        }

        private int _loai;
        public int Loai
        {
            get { return _loai; }
            set { _loai = value; }
        }

        private int _IDCongViec;
        public int IDCongViec
        {
            get { return _IDCongViec; }
            set { _IDCongViec = value; }
        }

        private int _IDParent;
        public int IDParent
        {
            get { return _IDParent; }
            set { _IDParent = value; }
        }

        private int _IDBoPhanHoTro;
        public int IDBoPhanHoTro
        {
            get { return _IDBoPhanHoTro; }
            set { _IDBoPhanHoTro = value; }
        }

        private int _IDNhanVien;
        public int IDNhanVien
        {
            get { return _IDNhanVien; }
            set { _IDNhanVien = value; }
        }

        private int _IDPhongBan;
        public int IDPhongBan
        {
            get { return _IDPhongBan; }
            set { _IDPhongBan = value; }
        }

        private DateTime _NgayBatDau;
        public DateTime NgayBatDau
        {
            get { return _NgayBatDau; }
            set { _NgayBatDau = value; }
        }

        private DateTime _NgayKetThuc;
        public DateTime NgayKetThuc
        {
            get { return _NgayKetThuc; }
            set { _NgayKetThuc = value; }
        }
    }
}