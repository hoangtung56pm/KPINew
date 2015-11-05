using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library.DotDanhGia
{
    public class DotDanhGiaTLHTCVInfo
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

        private double _TLHTCongViec;
        public double TLHTCongViec
        {
            get { return _TLHTCongViec; }
            set { _TLHTCongViec = value; }
        }

        private int _IDTrungTam;
        public int IDTrungTam
        {
            get { return _IDTrungTam; }
            set { _IDTrungTam = value; }
        }

    }
}