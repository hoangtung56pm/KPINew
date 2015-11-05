using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using VmgPortal.Modules.KPIData.Library.Providers;

namespace VmgPortal.Modules.KPIData.Library.DanhGia
{
    public class DGCBCNVDanhGiaChiTietController
    {
        public static DataTable GetAll(int loai, int idDotDanhGia, int idNhanVien)
        {
            return DataAccessProvider.Instance().GetAllDGCBCNVDanhGiaChiTiet(loai, idDotDanhGia, idNhanVien);
        }
        public static void Update(DGCBCNVDanhGiaChiTietInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().UpdateDGCBCNVDanhGiaChiTiet(_DotDanhGiaInfo);
        }
        public static void Delete(int id)
        {
            DataAccessProvider.Instance().DeleteDGCBCNVDanhGiaChiTiet(id);
        }

        public static DGCBCNVDanhGiaChiTietInfo GetInfo(int id)
        {
            return DataAccessProvider.Instance().GetInfoDGCBCNVDanhGiaChiTiet(id);
        }
    }
}