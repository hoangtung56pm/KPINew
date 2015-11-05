using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VmgPortal.Modules.KPIData.Library.Providers;
using System.Data;

namespace VmgPortal.Modules.KPIData.Library.DanhGiaBoPhan
{
    public class DanhGiaBoPhanTTCVController
    {
        public static DataTable GetAll(int loai, int IDDotDanhGiaVaNhanVien, int idBoPhan)
        {
            return DataAccessProvider.Instance().GetAllDanhGiaBoPhanTTCV(loai, IDDotDanhGiaVaNhanVien, idBoPhan);
        }

        public static void Delete(int _id)
        {
            DataAccessProvider.Instance().DeleteDanhGiaBoPhanTTCV(_id);
        }

        public static int Insert(DanhGiaBoPhanTTCVInfo _DotDanhGiaInfo)
        {
            return DataAccessProvider.Instance().InsertDanhGiaBoPhanTTCV(_DotDanhGiaInfo);
        }

        public static void Update(DanhGiaBoPhanTTCVInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().UpdateDanhGiaBoPhanTTCV(_DotDanhGiaInfo);
        }

        public static DanhGiaBoPhanTTCVInfo GetInfo(int _id)
        {
            return DataAccessProvider.Instance().GetInfoDanhGiaBoPhanTTCV(_id);
        }
    }
}