using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library.PhongBan
{
    public class PhongBanInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private int _iDTrungTam;
        public int IDTrungTam
        {
            get { return _iDTrungTam; }
            set { _iDTrungTam = value; }
        }

        private string _ten;
        public string Ten
        {
            get { return _ten; }
            set { _ten = value; }
        }

        private string _moTa;
        public string MoTa
        {
            get { return _moTa; }
            set { _moTa = value; }
        }

        private double _tyTrong;
        public double TyTrong
        {
            get { return _tyTrong; }
            set { _tyTrong = value; }
        }

        private int _iDNhanVienTruongPhong;
        public int IDNhanVienTruongPhong
        {
            get { return _iDNhanVienTruongPhong; }
            set { _iDNhanVienTruongPhong = value; }
        }

        private int _SoNguoi;
        public int SoNguoi
        {
            get { return _SoNguoi; }
            set { _SoNguoi = value; }
        }

        private int _IDParent;
        public int IDParent
        {
            get { return _IDParent; }
            set { _IDParent = value; }
        }
    }
}