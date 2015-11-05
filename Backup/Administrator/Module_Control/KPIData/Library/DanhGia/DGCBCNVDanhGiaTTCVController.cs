using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VmgPortal.Modules.KPIData.Library.Providers;
using System.Data;

namespace VmgPortal.Modules.KPIData.Library.DanhGia
{
    public class DGCBCNVDanhGiaTTCVController
    {
        public static DataTable GetAll(int loai, int IDDotDanhGia, int NhanVien)
        {
            return DataAccessProvider.Instance().GetAllDGCBCNVDanhGiaTTCV(loai, IDDotDanhGia, NhanVien);
        }

        public static void Delete(int _id)
        {
            DataAccessProvider.Instance().DeleteDGCBCNVDanhGiaTTCV(_id);
        }

        public static int Insert(DGCBCNVDanhGiaTTCVInfo _DotDanhGiaInfo)
        {
            return DataAccessProvider.Instance().InsertDGCBCNVDanhGiaTTCV(_DotDanhGiaInfo);
        }

        public static void Update(DGCBCNVDanhGiaTTCVInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().UpdateDGCBCNVDanhGiaTTCV(_DotDanhGiaInfo);
        }

        public static DGCBCNVDanhGiaTTCVInfo GetInfo(int _id)
        {
            return DataAccessProvider.Instance().GetInfoDGCBCNVDanhGiaTTCV(_id);
        }
    }
}