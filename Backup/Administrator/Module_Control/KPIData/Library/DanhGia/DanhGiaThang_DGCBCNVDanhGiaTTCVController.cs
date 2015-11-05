using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VmgPortal.Modules.KPIData.Library.Providers;
using System.Data;

namespace VmgPortal.Modules.KPIData.Library.DanhGia
{
    public class DanhGiaThang_DGCBCNVDanhGiaTTCVController
    {
        public static DataTable GetAll(int loai, int IDDotDanhGia, int IDNhanVien)
        {
            return DataAccessProvider.Instance().GetAllDanhGiaThang_DGCBCNVDanhGiaTTCV(loai, IDDotDanhGia, IDNhanVien);
        }

        public static DataTable DanhGiaThang_GetAllCongViecCanHoTro(int loai, int IDDotDanhGia, int IDBoPhan)
        {
            return DataAccessProvider.Instance().DanhGiaThang_GetAllCongViecCanHoTro(loai, IDDotDanhGia, IDBoPhan);
        }
        public static void DeleteNew(int _id)
        {
            DataAccessProvider.Instance().DeleteDanhGiaThang_DGCBCNVDanhGiaTTCVNew(_id);
        }

        public static void Delete(int _id)
        {
            DataAccessProvider.Instance().DeleteDanhGiaThang_DGCBCNVDanhGiaTTCV(_id);
        }

        public static int Insert(DanhGiaThang_DGCBCNVDanhGiaTTCVInfo _DotDanhGiaInfo)
        {
            return DataAccessProvider.Instance().InsertDanhGiaThang_DGCBCNVDanhGiaTTCV(_DotDanhGiaInfo);
        }

        public static int InsertCVNV(DanhGiaThang_DGCBCNVDanhGiaTTCVInfo _DotDanhGiaInfo)
        {
            return DataAccessProvider.Instance().InsertDanhGiaThangCVNV_DGCBCNVDanhGiaTTCV(_DotDanhGiaInfo);
        }

        public static void Update(DanhGiaThang_DGCBCNVDanhGiaTTCVInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().UpdateDanhGiaThang_DGCBCNVDanhGiaTTCV(_DotDanhGiaInfo);
        }

        public static int InsertKeHoachThang(DanhGiaThang_DGCBCNVDanhGiaTTCVInfo _DotDanhGiaInfo)
        {
            return DataAccessProvider.Instance().InsertKeHoachThang_DGCBCNVDanhGiaTTCV(_DotDanhGiaInfo);
        }

        public static void UpdateKeHoachThang(DanhGiaThang_DGCBCNVDanhGiaTTCVInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().UpdateKeHoachThang_DGCBCNVDanhGiaTTCV(_DotDanhGiaInfo);
        }

        public static DanhGiaThang_DGCBCNVDanhGiaTTCVInfo GetInfo(int _id)
        {
            return DataAccessProvider.Instance().GetInfoDanhGiaThang_DGCBCNVDanhGiaTTCV(_id);
        }

        public static void UpdateKeHoachThangBoPhanHoTro(int idDotDanhGia, int idCongViec, int idBoPhanHoTro)
        {
            DataAccessProvider.Instance().UpdateKeHoachThangBoPhanHoTro(idDotDanhGia, idCongViec, idBoPhanHoTro);
        }

        public static void DeleteKeHoachThangBoPhanHoTro(int idDotDanhGia, int idCongViec, int idBoPhanHoTro)
        {
            DataAccessProvider.Instance().DeleteKeHoachThangBoPhanHoTro(idDotDanhGia, idCongViec, idBoPhanHoTro);
        }

        public static DataTable GetKeHoachThangBoPhanHoTro(int idDotDanhGia, int idCongViec)
        {
            return DataAccessProvider.Instance().GetKeHoachThangBoPhanHoTro(idDotDanhGia, idCongViec);
        }
    }
}