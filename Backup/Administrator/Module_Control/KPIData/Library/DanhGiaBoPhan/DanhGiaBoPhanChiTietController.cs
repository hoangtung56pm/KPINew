using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using VmgPortal.Modules.KPIData.Library.Providers;

namespace VmgPortal.Modules.KPIData.Library.DanhGiaBoPhan
{
    public class DanhGiaBoPhanChiTietController
    {
        public static DataTable GetAll(int loai, int idDotDanhGia, int idBoPhan)
        {
            return DataAccessProvider.Instance().GetAllDanhGiaBoPhanChiTiet(loai, idDotDanhGia, idBoPhan);
        }
        public static void Update(DanhGiaBoPhanChiTietInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().UpdateDanhGiaBoPhanChiTiet(_DotDanhGiaInfo);
        }
        public static void Delete(int id)
        {
            DataAccessProvider.Instance().DeleteDanhGiaBoPhanChiTiet(id);
        }

        public static DanhGiaBoPhanChiTietInfo GetInfo(int id)
        {
            return DataAccessProvider.Instance().GetInfoDanhGiaBoPhanChiTiet(id);
        }

        public static DataTable DanhGiaThang_GetAll(int loai, int idDotDanhGia, int idBoPhan)
        {
            return DataAccessProvider.Instance().DanhGiaThang_GetAllDanhGiaBoPhanChiTiet(loai, idDotDanhGia, idBoPhan);
        }
        public static void DanhGiaThang_Update(DanhGiaBoPhanChiTietInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().DanhGiaThang_UpdateDanhGiaBoPhanChiTiet(_DotDanhGiaInfo);
        }
    }
}