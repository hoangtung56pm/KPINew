using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using VmgPortal.Modules.KPIData.Library.Providers;

namespace VmgPortal.Modules.KPIData.Library.DanhGia
{
    public class DGCBCNVDanhGiaCLCVController
    {
        public static void Update(DGCBCNVDanhGiaCLCVInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().UpdateDGCBCNVDanhGiaCLCV(_DotDanhGiaInfo);
        }

        public static DGCBCNVDanhGiaCLCVInfo GetInfo(int _idDotDanhGia, int _idNhanVien, int _idTrungTam, int _loai)
        {
            return DataAccessProvider.Instance().GetInfoDGCBCNVDanhGiaCLCV(_idDotDanhGia, _idNhanVien, _idTrungTam, _loai);
        }
    }
}