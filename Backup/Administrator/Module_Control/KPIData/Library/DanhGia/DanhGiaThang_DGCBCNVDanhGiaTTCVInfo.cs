using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library.DanhGia
{
    public class DanhGiaThang_DGCBCNVDanhGiaTTCVInfo
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

        private string _soLieuThucHienThucTeTrongThang;
        public string SoLieuThucHienThucTeTrongThang
        {
            get { return _soLieuThucHienThucTeTrongThang; }
            set { _soLieuThucHienThucTeTrongThang = value; }
        }

        private double _nhanVienDanhGiaTyLeHoanThanh;
        public double NhanVienDanhGiaTyLeHoanThanh
        {
            get { return _nhanVienDanhGiaTyLeHoanThanh; }
            set { _nhanVienDanhGiaTyLeHoanThanh = value; }
        }

        private double _tBPDanhGia;
        public double TBPDanhGia
        {
            get { return _tBPDanhGia; }
            set { _tBPDanhGia = value; }
        }

        private string _yeuCauHoTro;
        public string YeuCauHoTro
        {
            get { return _yeuCauHoTro; }
            set { _yeuCauHoTro = value; }
        }

        private string _yKienCuaNhanVien;
        public string YKienCuaNhanVien
        {
            get { return _yKienCuaNhanVien; }
            set { _yKienCuaNhanVien = value; }
        }

        private string _yKienCuaTBP;
        public string YKienCuaTBP
        {
            get { return _yKienCuaTBP; }
            set { _yKienCuaTBP = value; }
        }

        private int _loai;
        public int Loai
        {
            get { return _loai; }
            set { _loai = value; }
        }

        private int _IDCongViecKPI;
        public int IDCongViec
        {
            get { return _IDCongViecKPI; }
            set { _IDCongViecKPI = value; }
        }

        private int _IDBoPhanHoTro;
        public int IDBoPhanHoTro
        {
            get { return _IDBoPhanHoTro; }
            set { _IDBoPhanHoTro = value; }
        }

        private int _IDBoPhan;
        public int IDBoPhan
        {
            get { return _IDBoPhan; }
            set { _IDBoPhan = value; }
        }

        private int _IDPhongBan;
        public int IDPhongBan
        {
            get { return _IDPhongBan; }
            set { _IDPhongBan = value; }
        }

        private double _SoGio;
        public double SoGio
        {
            get { return _SoGio; }
            set { _SoGio = value; }
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