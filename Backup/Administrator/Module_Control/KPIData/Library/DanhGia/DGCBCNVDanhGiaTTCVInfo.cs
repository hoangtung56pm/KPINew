using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library.DanhGia
{
    public class DGCBCNVDanhGiaTTCVInfo
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

        private string _soLieuCamKet;
        public string SoLieuCamKet
        {
            get { return _soLieuCamKet; }
            set { _soLieuCamKet = value; }
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
    }
}