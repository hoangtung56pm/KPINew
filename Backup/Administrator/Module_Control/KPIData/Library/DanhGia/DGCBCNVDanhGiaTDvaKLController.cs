using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VmgPortal.Modules.KPIData.Library.Providers;

namespace VmgPortal.Modules.KPIData.Library.DanhGia
{
    public class DGCBCNVDanhGiaTDvaKLController
    {
        public static void Update(DGCBCNVDanhGiaTDvaKLInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().UpdateDGCBCNVDanhGiaTDvaKL(_DotDanhGiaInfo);
        }
        public static void DanhGiaThang_DGCBCNVDanhGiaTDvaKL_Update(DGCBCNVDanhGiaTDvaKLInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().DanhGiaThang_DGCBCNVDanhGiaTDvaKL_Update(_DotDanhGiaInfo);
        }
        public static DGCBCNVDanhGiaTDvaKLInfo GetInfo(int _idDotDanhGia, int _idNhanVien, int _loai)
        {
            return DataAccessProvider.Instance().GetInfoDGCBCNVDanhGiaTDvaKL(_idDotDanhGia, _idNhanVien, _loai);
        }
        public static DGCBCNVDanhGiaTDvaKLInfo GetInfoNew(int _idDotDanhGia, int _idNhanVien, int _loai, int capDoDanhGia)
        {
            return DataAccessProvider.Instance().GetInfoDGCBCNVDanhGiaTDvaKLNew(_idDotDanhGia, _idNhanVien, _loai, capDoDanhGia);
        }

        public static DGCBCNVDanhGiaTDvaKLInfo GetInfo_DanhGiaThang(int _idDotDanhGia, int _idNhanVien, int _loai)
        {
            return DataAccessProvider.Instance().GetInfoDGCBCNVDanhGiaTDvaKLDanhGiaThang(_idDotDanhGia, _idNhanVien,  _loai);
        }

        public static DGCBCNVDanhGiaNangLucNhanVienInfo GetDanhGiaNangLucNhanVienInfo(int _idDotDanhGia, int _idNhanVien, int _loai)
        {
            return DataAccessProvider.Instance().GetDanhGiaNangLucNhanVienInfo(_idDotDanhGia, _idNhanVien, _loai);
        }

        public static void UpdateDanhGiaNangLucNhanVien(DGCBCNVDanhGiaNangLucNhanVienInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().UpdateDanhGiaNangLucNhanVien(_DotDanhGiaInfo);
        }
    }
}