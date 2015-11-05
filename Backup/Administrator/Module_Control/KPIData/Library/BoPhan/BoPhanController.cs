using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VmgPortal.Modules.KPIData.Library.Providers;
using System.Data;

namespace VmgPortal.Modules.KPIData.Library.BoPhan
{
    public class BoPhanController
    {
        public static DataTable GetAll()
        {
            return DataAccessProvider.Instance().GetAllBoPhan();
        }

        public static DataTable GetAllWithStatus(int idDotDanhGia)
        {
            return DataAccessProvider.Instance().GetAllWithStatus(idDotDanhGia);
        }

        public static DataTable GetAllWithTrangThai(int idDotDanhGia, int trangThai)
        {
            return DataAccessProvider.Instance().GetAllWithTrangThai(idDotDanhGia, trangThai);
        }

        public static DataTable BoPhan_GetAllActive()
        {
            return DataAccessProvider.Instance().BoPhan_GetAllActive();
        }        

        public static void Delete(int _id)
        {
            DataAccessProvider.Instance().DeleteBoPhan(_id);
        }

        public static int Insert(BoPhanInfo _BoPhanInfo)
        {
            return DataAccessProvider.Instance().InsertBoPhan(_BoPhanInfo);
        }

        public static void Update(BoPhanInfo _BoPhanInfo)
        {
            DataAccessProvider.Instance().InsertBoPhan(_BoPhanInfo);
        }

        public static BoPhanInfo GetInfo(int _id)
        {
            return DataAccessProvider.Instance().GetInfoBoPhan(_id);
        }

        public static void UpdatePhongBan(int IdNhanVien, int IdPhongBan, int idDotDanhGia)
        {
            DataAccessProvider.Instance().UpdatePhongBan(IdNhanVien, IdPhongBan, idDotDanhGia);
        }

        public static DataTable KeHoachThang_GetCongViecCuaBoPhan_GetAll(int IDBoPhan, int IDDotDanhGia)
        {
            return DataAccessProvider.Instance().KeHoachThang_GetCongViecCuaBoPhan_GetAll(IDBoPhan, IDDotDanhGia);
        }

        public static DataTable KeHoachThang_GetCongViecCuaBoPhan_GetAll_New(int IDBoPhan, int IDDotDanhGia)
        {
            return DataAccessProvider.Instance().KeHoachThang_GetCongViecCuaBoPhan_GetAll_New(IDBoPhan, IDDotDanhGia);
        }

        public static DataTable DanhGiaThang_GetCongViecCuaBoPhan_GetAll(int IDBoPhan, int IDDotDanhGia)
        {
            return DataAccessProvider.Instance().DanhGiaThang_GetCongViecCuaBoPhan_GetAll(IDBoPhan, IDDotDanhGia);
        }
        public static DataTable DanhGiaThang_GetCongViecCuaBoPhan_GetAllNew(int IDBoPhan, int IDDotDanhGia)
        {
            return DataAccessProvider.Instance().DanhGiaThang_GetCongViecCuaBoPhan_GetAllNew(IDBoPhan, IDDotDanhGia);
        }
        public static void DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGia(int idCongViec, int idDotDanhGia, double TBPDanhGia)
        {
            DataAccessProvider.Instance().DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGia(idCongViec, idDotDanhGia, TBPDanhGia);
        }
        public static void DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGiaNew(int idCongViec, int idDotDanhGia, double TBPDanhGia)
        {
            DataAccessProvider.Instance().DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGiaNew(idCongViec, idDotDanhGia, TBPDanhGia);
        }
        public static void DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGiaLai(int idCongViec, int idDotDanhGia, double TBPDanhGia)
        {
            DataAccessProvider.Instance().DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGiaLai(idCongViec, idDotDanhGia, TBPDanhGia);
        }
        public static void DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGiaLaiNew(int idCongViec, int idDotDanhGia, double TBPDanhGia, double TyTrongCV)
        {
            DataAccessProvider.Instance().DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGiaLaiNew(idCongViec, idDotDanhGia, TBPDanhGia, TyTrongCV);
        }
    }
}