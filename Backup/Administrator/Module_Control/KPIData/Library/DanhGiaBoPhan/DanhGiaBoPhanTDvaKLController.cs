using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VmgPortal.Modules.KPIData.Library.Providers;

namespace VmgPortal.Modules.KPIData.Library.DanhGiaBoPhan
{
    public class DanhGiaBoPhanTDvaKLController
    {
        public static void Update(DGBoPhanTDvaKLInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().UpdateDanhGiaBoPhanTDvaKL(_DotDanhGiaInfo);
        }

        public static void DanhGiaThang_Update(DGBoPhanTDvaKLInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().DanhGiaThang_UpdateDanhGiaBoPhanTDvaKL(_DotDanhGiaInfo);
        }

        public static DGBoPhanTDvaKLInfo GetInfo(int _idDotDanhGia,int idBoPhan, int _loai)
        {
            return DataAccessProvider.Instance().GetInfoDanhGiaBoPhanTDvaKL(_idDotDanhGia, idBoPhan, _loai);
        }

        public static DGBoPhanTDvaKLInfo DanhGiaThang_GetInfo(int _idDotDanhGia, int idBoPhan, int _loai)
        {
            return DataAccessProvider.Instance().DanhGiaThang_GetInfoDanhGiaBoPhanTDvaKL(_idDotDanhGia, idBoPhan, _loai);
        }
    }
}