using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library.DotDanhGia
{
    public class QuanLyCongViecBaoCaoNgayInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private int _iDCongViecKPI;
        public int IDCongViecKPI
        {
            get { return _iDCongViecKPI; }
            set { _iDCongViecKPI = value; }
        }

        private string _ten;
        public string Ten
        {
            get { return _ten; }
            set { _ten = value; }
        }

        private string _KeHoach;
        public string KeHoach
        {
            get { return _KeHoach; }
            set { _KeHoach = value; }
        }
        private double _tyTrong;
        public double TyTrong
        {
            get { return _tyTrong; }
            set { _tyTrong = value; }
        }

        private string _parentID;
        public string ParentID
        {
            get { return _parentID; }
            set { _parentID = value; }
        }

        private string _ketQua;
        public string KetQua
        {
            get { return _ketQua; }
            set { _ketQua = value; }
        }

        private string _tyLeHoanThanh;
        public string TyLeHoanThanh
        {
            get { return _tyLeHoanThanh; }
            set { _tyLeHoanThanh = value; }
        }

        private int _iDTrungTam;
        public int IDTrungTam
        {
            get { return _iDTrungTam; }
            set { _iDTrungTam = value; }
        }

        private int _iDPhongBan;
        public int IDPhongBan
        {
            get { return _iDPhongBan; }
            set { _iDPhongBan = value; }
        }

        private DateTime _createdOn;
        public DateTime CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }

        private int _iDDotDanhGia;
        public int IDDotDanhGia
        {
            get { return _iDDotDanhGia; }
            set { _iDDotDanhGia = value; }
        }

        private int _createBy;
        public int CreateBy
        {
            get { return _createBy; }
            set { _createBy = value; }
        }

        private double _soGio;
        public double SoGio
        {
            get { return _soGio; }
            set { _soGio = value; }
        }

        private string _lyDo;
        public string LyDo
        {
            get { return _lyDo; }
            set { _lyDo = value; }
        }

        private string _deXuat;
        public string DeXuat
        {
            get { return _deXuat; }
            set { _deXuat = value; }
        }

    }
}