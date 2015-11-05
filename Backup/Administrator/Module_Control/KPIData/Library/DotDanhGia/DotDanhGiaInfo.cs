using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library.DotDanhGia
{
    public class DotDanhGiaInfo
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

        private DateTime _ThoiGianBatDau;
        public DateTime ThoiGianBatDau
        {
            get { return _ThoiGianBatDau; }
            set { _ThoiGianBatDau = value; }
        }

        private DateTime _ThoiGianKetThuc;
        public DateTime ThoiGianKetThuc
        {
            get { return _ThoiGianKetThuc; }
            set { _ThoiGianKetThuc = value; }
        }        
            
        private int _trangThai;
        public int TrangThai
        {
            get { return _trangThai; }
            set { _trangThai = value; }
        }

        private int _DangChay;
        public int DangChay
        {
            get { return _DangChay; }
            set { _DangChay = value; }
        }

        private int _Chuan;
        public int IsDefault
        {
            get { return _Chuan; }
            set { _Chuan = value; }
        }

        private int _Thang;
        public int Thang
        {
            get { return _Thang; }
            set { _Thang = value; }
        }

        private int _Nam;
        public int Nam
        {
            get { return _Nam; }
            set { _Nam = value; }
        }
    }
}