using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library.DotDanhGia
{
    public class QuanLyCongViecKPIInfo
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

        private double _tyTrong;
        public double TyTrong
        {
            get { return _tyTrong; }
            set { _tyTrong = value; }
        }

        private int _parentID;
        public int ParentID
        {
            get { return _parentID; }
            set { _parentID = value; }
        }

        private int _priority;
        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        private string _KeHoach;
        public string KeHoach
        {
            get { return _KeHoach; }
            set { _KeHoach = value; }
        }

        private string _DonViDo;
        public string DonViDo
        {
            get { return _DonViDo; }
            set { _DonViDo = value; }
        }

        private int _IDTrungTam;
        public int IDTrungTam
        {
            get { return _IDTrungTam; }
            set { _IDTrungTam = value; }
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

        private int _IDNhomCongViec;
        public int IDNhomCongViec
        {
            get { return _IDNhomCongViec; }
            set { _IDNhomCongViec = value; }
        }

        private int _TrangThai;
        public int TrangThaiCV
        {
            get { return _TrangThai; }
            set { _TrangThai = value; }
        }
    }
}