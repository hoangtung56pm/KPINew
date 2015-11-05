using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using VmgPortal.Modules.KPIData.Library.XepLoai;
using VmgPortal.Library.Utilities;
using VmgPortal.Modules.KPIData.Library.Nhom;
using VmgPortal.Modules.KPIData.Library.XepLoaiNhom;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;
using VmgPortal.Modules.KPIData.Library.DanhGia;
using VmgPortal.Modules.KPIData.Library.DanhGiaBoPhan;
using VmgPortal.Modules.KPIData.Library.DinhNghia;
using VmgPortal.Modules.KPIData.Library.PhongBan;
using VmgPortal.Library;

namespace VmgPortal.Modules.KPIData.Library.Providers
{
    public class SqlDataProvider : DataAccessProvider
    {
        private string connectionString;
        public string ConnectionString
        {
            get { return this.connectionString; }

            set { this.connectionString = value; }
        }
        public SqlDataProvider(string strConn)
        {
            this.ConnectionString = strConn;
        }

        #region Xep Loai

        public override DataTable GetAllXepLoai()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "XepLoai_GetAll");

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override int InsertXepLoai(XepLoaiInfo _xepLoaiInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "XepLoai_Insert", _xepLoaiInfo.Ten);
        }

        public override void UpdateXepLoai(XepLoaiInfo _xepLoaiInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "XepLoai_Update", _xepLoaiInfo.ID, _xepLoaiInfo.Ten);
        }

        public override void DeleteXepLoai(int _id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "XepLoai_Delete", _id);
        }
        public override XepLoaiInfo GetInfoXepLoai(int _id)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "XepLoai_GetInfo", _id);
            XepLoaiInfo zone = (XepLoaiInfo)ObjectHelper.CreateObject(typeof(XepLoaiInfo), dr);
            return zone;
        }

        #endregion

        #region Nhom

        public override DataTable GetAllNhom()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Nhom_GetAll");

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override int InsertNhom(NhomInfo _NhomInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "Nhom_Insert", _NhomInfo.Ten);
        }

        public override void UpdateNhom(NhomInfo _NhomInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Nhom_Update", _NhomInfo.ID, _NhomInfo.Ten);
        }

        public override void DeleteNhom(int _id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Nhom_Delete", _id);
        }
        public override NhomInfo GetInfoNhom(int _id)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "Nhom_GetInfo", _id);
            NhomInfo zone = (NhomInfo)ObjectHelper.CreateObject(typeof(NhomInfo), dr);
            return zone;
        }

        #endregion

        #region XepLoaiNhom

        public override DataTable GetAllXepLoaiNhom()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "XepLoaiNhom_GetAll");

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override int InsertXepLoaiNhom(XepLoaiNhomInfo _XepLoaiNhomInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "XepLoaiNhom_Insert", _XepLoaiNhomInfo.IDNhomNhanVien, _XepLoaiNhomInfo.IDXepLoai, _XepLoaiNhomInfo.Min, _XepLoaiNhomInfo.Max);
        }

        public override void UpdateXepLoaiNhom(XepLoaiNhomInfo _XepLoaiNhomInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "XepLoaiNhom_Update", _XepLoaiNhomInfo.ID, _XepLoaiNhomInfo.IDNhomNhanVien, _XepLoaiNhomInfo.IDXepLoai, _XepLoaiNhomInfo.Min, _XepLoaiNhomInfo.Max);
        }

        public override void DeleteXepLoaiNhom(int _id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "XepLoaiNhom_Delete", _id);
        }
        public override XepLoaiNhomInfo GetInfoXepLoaiNhom(int _id)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "XepLoaiNhom_GetInfo", _id);
            XepLoaiNhomInfo zone = (XepLoaiNhomInfo)ObjectHelper.CreateObject(typeof(XepLoaiNhomInfo), dr);
            return zone;
        }

        #endregion

        #region BoPhan

        public override DataTable GetAllWithStatus(int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "BoPhan_GetAllWithStatus", idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllWithTrangThai(int idDotDanhGia, int trangThai)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "BoPhan_GetAllWithTrangThai", idDotDanhGia, trangThai);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable BoPhan_GetAllActive()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "BoPhan_GetAllActive");

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllBoPhan()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "BoPhan_GetAll");

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override int InsertBoPhan(BoPhanInfo _BoPhanInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "BoPhan_Insert", _BoPhanInfo.Ten, _BoPhanInfo.MoTa);
        }

        public override void UpdateBoPhan(BoPhanInfo _BoPhanInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "BoPhan_Update", _BoPhanInfo.ID, _BoPhanInfo.Ten, _BoPhanInfo.MoTa);
        }

        public override void UpdatePhongBan(int IdNhanVien, int IdPhongBan, int IdDotDanhGia)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "BoPhan_UpdatePhongBan", IdNhanVien, IdPhongBan, IdDotDanhGia);
        }

        public override void DeleteBoPhan(int _id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "BoPhan_Delete", _id);
        }
        public override BoPhanInfo GetInfoBoPhan(int _id)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "BoPhan_GetInfo", _id);
            BoPhanInfo zone = (BoPhanInfo)ObjectHelper.CreateObject(typeof(BoPhanInfo), dr);
            return zone;
        }

        #endregion

        #region DotDanhGia



        public override DataTable GetAllMucDoanhThuLoiNhuan()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllMucDoanhThuLoiNhuan");

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override void UpdateDoanhThuLoiNhuan(DotDanhGiaConfigInfo config)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_UpdateDoanhThuLoiNhuan", config.IDDotDanhGia, config.IDDiemDoanhThu, config.IDDiemLoiNhuan, config.IDTrungTam, config.IDDiem1, config.IDDiem2, config.IDDiem3);

        }

        public override void UpdateTLHTCongViec(DotDanhGiaTLHTCVInfo config)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_UpdateTLHTCongViec", config.IDDotDanhGia, config.TLHTCongViec, config.IDTrungTam);

        }
        public override void UpdateDanhGiaCheo(DotDanhGiaDanhGiaCheoInfo config)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_UpdateDanhGiaCheo", config.IDDotDanhGia, config.TyTrongDanhGia, config.DiemDanhGia, config.IDTrungTam);

        }
        public override DotDanhGiaConfigInfo GetInfoDotDanhGiaConfig(int _id, int idTrungTam)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "DotDanhGia_GetInfoDotDanhGiaConfig", _id, idTrungTam);
            DotDanhGiaConfigInfo zone = (DotDanhGiaConfigInfo)ObjectHelper.CreateObject(typeof(DotDanhGiaConfigInfo), dr);
            return zone;
        }
        public override DotDanhGiaTLHTCVInfo GetInfoTLHTCongViec(int _id, int idTrungTam)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "DotDanhGia_GetInfoTLHTCongViec", _id, idTrungTam);
            DotDanhGiaTLHTCVInfo zone = (DotDanhGiaTLHTCVInfo)ObjectHelper.CreateObject(typeof(DotDanhGiaTLHTCVInfo), dr);
            return zone;
        }


        public override DotDanhGiaDanhGiaCheoInfo GetInfoDanhGiaCheo(int _id, int idTrungTam)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "DotDanhGia_GetInfoDanhGiaCheo", _id, idTrungTam);
            DotDanhGiaDanhGiaCheoInfo zone = (DotDanhGiaDanhGiaCheoInfo)ObjectHelper.CreateObject(typeof(DotDanhGiaDanhGiaCheoInfo), dr);
            return zone;
        }
        public override DataTable GetAllDotDanhGia()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAll");

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetDaultDotDanhGia()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetDefaultDotDanhGia");

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public override DataTable GetDaultDotDanhGiaCheckPoint()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetDefaultDotDanhGiaCheckPoint");

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        
        public override DataTable GetAllDotDanhGia(int type)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllByType", type);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override int InsertDotDanhGia(DotDanhGiaInfo _DotDanhGiaInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "DotDanhGia_Insert", _DotDanhGiaInfo.Ten, _DotDanhGiaInfo.TrangThai, _DotDanhGiaInfo.ThoiGianBatDau, _DotDanhGiaInfo.ThoiGianKetThuc, _DotDanhGiaInfo.DangChay, _DotDanhGiaInfo.IsDefault, _DotDanhGiaInfo.Nam, _DotDanhGiaInfo.Thang);
        }

        public override void UpdateDotDanhGia(DotDanhGiaInfo _DotDanhGiaInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_Update", _DotDanhGiaInfo.ID, _DotDanhGiaInfo.Ten, _DotDanhGiaInfo.TrangThai, _DotDanhGiaInfo.ThoiGianBatDau, _DotDanhGiaInfo.ThoiGianKetThuc, _DotDanhGiaInfo.DangChay, _DotDanhGiaInfo.IsDefault, _DotDanhGiaInfo.Nam, _DotDanhGiaInfo.Thang);
        }

        public override void DeleteDotDanhGia(int _id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_Delete", _id);
        }
        public override DotDanhGiaInfo GetInfoDotDanhGia(int _id)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "DotDanhGia_GetInfo", _id);
            DotDanhGiaInfo zone = (DotDanhGiaInfo)ObjectHelper.CreateObject(typeof(DotDanhGiaInfo), dr);
            return zone;
        }

        public override void UpdateNhanVienVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam, int idNhom)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_UpdateNhanVienVaoDotDanhGia", idDotDanhGia, idNhanVien, idTrungTam, idNhom);
        }

        public override void UpdateNhanVienVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam, int idNhom, int nguoiDG)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_UpdateNhanVienVaoDotDanhGiaNDG", idDotDanhGia, idNhanVien, idTrungTam, idNhom, nguoiDG);

        }

        public override void UpdateNhanVienVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam, int idNhom, int nguoiDG, int trangthai)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_UpdateNhanVienVaoDotDanhGiaTrangThai", idDotDanhGia, idNhanVien, idTrungTam, idNhom, nguoiDG, trangthai);

        }
        public override void RemoveNhanVienVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_RemoveNhanVienVaoDotDanhGia", idDotDanhGia, idNhanVien, idTrungTam);

        }
        public override void RemoveNhanVienVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam, int idNguoiDG)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_RemoveNhanVienVaoDotDanhGiaNDG", idDotDanhGia, idNhanVien, idTrungTam);

        }

        public override void UpdateNhanVienTheoNDG(int idNhanVien, int idTrungTam, int nguoiDG, int idDotDanhGia)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_UpdateNhanVienTheoNDG", idNhanVien, idTrungTam, nguoiDG, idDotDanhGia);

        }
        public override void RemoveNhanVienTheoNDG(int idNhanVien, int idTrungTam, int nguoiDG, int idDotDanhGia)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_RemoveNhanVienTheoNDG", idNhanVien, idTrungTam, nguoiDG, idDotDanhGia);

        }

        public override void UpdateTruongBoPhanVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_UpdateTruongBoPhanVaoDotDanhGia", idDotDanhGia, idNhanVien, idTrungTam);
        }

        public override void RemoveTruongBoPhanVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_RemoveTruongBoPhanVaoDotDanhGia", idDotDanhGia, idNhanVien, idTrungTam);

        }

        public override DataTable GetAllNhanVienByTrungTam(int idTrungTam, int role)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllNhanVienByTrungTam", idTrungTam, role);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllTruongPhongByTrungTam(int idTrungTam, int role)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllTruongPhongByTrungTam", idTrungTam, role);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllNhanVienNotByNhanVienQuanLy(int idDotDanhGia, int idNhanVienQuanLy, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllNhanVienNotInByNhanVienQuanLy", idDotDanhGia, idTrungTam, idNhanVienQuanLy);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllNhanVienInByNhanVienQuanLy(int idDotDanhGia, int idNhanVienQuanLy, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllNhanVienInByNhanVienQuanLy", idDotDanhGia, idTrungTam, idNhanVienQuanLy);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllNhanVienNotByNhanVienQuanLy(int idNhanVienQuanLy, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllNhanVienNotByNDG", idTrungTam, idNhanVienQuanLy);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllNhanVienInDotDanhGiaExport(int idDotDanhGia, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllNhanVienInDotDanhGiaExport", idDotDanhGia, idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllNhanVienInDotDanhGia(int idDotDanhGia, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllNhanVienInDotDanhGia", idDotDanhGia, idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllNhanVienInDotDanhGiaNew(int idDotDanhGia, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllNhanVienInDotDanhGiaNew", idDotDanhGia, idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllNhanVienNotInDotDanhGia(int idDotDanhGia, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllNhanVienNotInDotDanhGia", idDotDanhGia, idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllTruongPhongInDotDanhGia(int idDotDanhGia, int idTrungTam, int idNhanVienQuanLy)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllTruongPhongInDotDanhGia", idDotDanhGia, idTrungTam, idNhanVienQuanLy);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllTruongPhongNotInDotDanhGia(int idDotDanhGia, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllTruongPhongNotInDotDanhGia", idDotDanhGia, idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllTruongBoPhanInDotDanhGia(int idDotDanhGia, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllTruongBoPhanInDotDanhGia", idDotDanhGia, idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllTruongBoPhanNotInDotDanhGia(int idDotDanhGia, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllTruongBoPhanNotInDotDanhGia", idDotDanhGia, idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataSet DGCBCNVDanhGia_TongDiem(int idDotDanhGia, int idNhanVien)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DGCBCNVDanhGia_TongDiem", idDotDanhGia, idNhanVien);//, idNhanVien, idTrungTam

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataSet DGCBCNVDanhGia_TongDiemTBP(int idDotDanhGia, int idNhanVien, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DGCBCNVDanhGia_TongDiemTBP", idDotDanhGia, idNhanVien, idTrungTam);//, idNhanVien, idTrungTam

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataSet DGCBCNVDanhGiaDongNghiep_GetAll(int idDotDanhGia, int idNhanVien, int roleId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DGCBCNVDanhGiaDongNghiep_GetAll", idDotDanhGia, idNhanVien, roleId);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataTable CheckPointDanhGiaDongNghiep_GetAll(int idDotDanhGia, int idNhanVien)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "CheckPointDanhGiaDongNghiep_GetAll", idDotDanhGia, idNhanVien);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        

        public override DataSet DGCBCNVDanhGiaDongNghiepTP_GetAll(int idDotDanhGia, int idNhanVien, int roleId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DGCBCNVDanhGiaDongNghiepTP_GetAll", idDotDanhGia, idNhanVien, roleId);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override void DGCBCNVDanhGiaDongNghiep_Update(int idDotDanhGia, int idNhanVien, int idNhanVienDuocDG, double diemDG, int loai, int capdodanhgia)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DGCBCNVDanhGiaDongNghiep_Update", idDotDanhGia, idNhanVien, idNhanVienDuocDG, diemDG, loai, capdodanhgia);
        }

        public override void CheckPointDanhGiaDongNghiep_Update(int idDotDanhGia, int idNhanVien, int idNhanVienDuocDG, double diemDG, int loai, string nhanxet)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "CheckPointDanhGiaDongNghiep_Update", idDotDanhGia, idNhanVien, idNhanVienDuocDG, diemDG, loai, nhanxet);
        }

        public override void CheckPointDanhGiaDongNghiep_Delete(int idDotDanhGia, int idNhanVien, int idNhanVienDuocDG, double diemDG, int loai, string nhanxet)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "CheckPointDanhGiaDongNghiep_Delete", idDotDanhGia, idNhanVien, idNhanVienDuocDG, diemDG, loai, nhanxet);
        }
        
        public override DataSet DGCBCNVDanhGiaPhoiHopBoPhan_GetAll(int idDotDanhGia, int idNhanVien)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DGCBCNVDanhGiaPhoiHopBoPhan_GetAll", idDotDanhGia, idNhanVien);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }
        public override void DGCBCNVDanhGiaPhoiHopBoPhan_Update(int idDotDanhGia, int idNhanVien, int idBoPhanDuocDG, double diemDG, int loai)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DGCBCNVDanhGiaPhoiHopBoPhan_Update", idDotDanhGia, idNhanVien, idBoPhanDuocDG, diemDG, loai);
        }

        public override void DanhGiaThang_DanhGiaPhoiHopBoPhan_Update(int idDotDanhGia, int idBoPhan, int idBoPhanDuocDG, double diemDG, int loai, string ghichu)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "BoPhanDanhGiaPhoiHopBoPhan_Update", idDotDanhGia, idBoPhan, idBoPhanDuocDG, diemDG, loai, ghichu);
        }

        public override DataSet DanhGiaThang_DanhGiaPhoiHopBoPhan_GetAll(int idDotDanhGia, int idBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaThang_DanhGiaPhoiHopBoPhan_GetAll", idDotDanhGia, idBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataTable checkDanhGiaNam(int idDotDanhGia, int idNhanVien)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "checkDanhGia", idDotDanhGia, idNhanVien);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable checkDanhGiaThang(int idDotDanhGia, int idNhanVien)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "checkDanhGiaThang", idDotDanhGia, idNhanVien);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable checkDanhGiaBoPhan(int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "checkDanhGiaBoPhan", idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public override DataTable checkDanhGiaBoPhan(int idDotDanhGia, int idBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "checkDanhGiaBoPhanThang", idDotDanhGia, idBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable checkKeHoachPhongBan(int idDotDanhGia, int idBoPhan, int idPhongBan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "checkKeHoachPhongBanThang", idDotDanhGia, idBoPhan, idPhongBan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override void GuiDanhGia(int idDotDanhGia, int idNhanVien, int status)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DGCBCNV_GuiDanhGia", idDotDanhGia, idNhanVien, status);
        }

        public override void GuiDanhGiaBoPhan(int idDotDanhGia, int IDBoPhan, int status)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DGCBCNV_GuiDanhGiaBoPhan", idDotDanhGia, IDBoPhan, status);
        }

        public override DataTable GetAllNhanVienInNhom(int idNhom, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllNhanVienInNhom", idNhom, idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllNhanVienNotInNhom(int idNhom, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllNhanVienNotInNhom", idNhom, idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override void UpdateNhanVienVaoNhom(int idNhanVien, int idTrungTam, int idNhom)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_UpdateNhanVienVaoNhom", idNhanVien, idTrungTam, idNhom);

        }

        public override DataTable GetAllBoPhanInDotDanhGia(int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllBoPhanInDotDanhGia", idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllBoPhanNotInDotDanhGia(int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllBoPhanNotInDotDanhGia", idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override void UpdateBoPhanVaoDotDanhGia(int idDotDanhGia, int idTrungTam)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_UpdateBoPhanVaoDotDanhGia", idDotDanhGia, idTrungTam);
        }

        public override void UpdateBoPhanVaoDotDanhGia(int idDotDanhGia, int idTrungTam, int trangThai)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_UpdateBoPhanVaoDotDanhGiaVoiTrangThai", idDotDanhGia, idTrungTam, trangThai);
        }

        public override void RemoveBoPhanTrongDotDanhGia(int idDotDanhGia, int idTrungTam)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_RemoveBoPhanTrongDotDanhGia", idDotDanhGia, idTrungTam);

        }

        #endregion

        #region Common

        public override DataTable GetAllChucVu()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Common_GetAllChucVu");

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllNhomTieuChiDef()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Common_GetAllNhomTieuChi");

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }



        public override DataSet BaoCaoKetQuaDiemPhoiHopBoPhan(int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "BaoCao_KetQuaDiemPhoiHopBoPhan", idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataTable BaoCaoXepLoaiDanhGiaCaNhan(int idDotDanhGia, int idTrungTam, int idPhongBan, int chucVu, int xeploai)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGia_BaoCaoXepLoaiDanhGiaCaNhan", idDotDanhGia, idTrungTam, chucVu, xeploai, idPhongBan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable BaoCaoTienDoThucHienDanhGia(int idDotDanhGia, int idTrungTam, int chucVu, int trangthai, int idPhongBan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGia_BaoCaoTienDoThucHienDanhGia", idDotDanhGia, idTrungTam, chucVu, trangthai, idPhongBan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable BaoCaoTongHopXepLoaiNhanVien(int idDotDanhGia, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGia_BaoCaoTongHopXepLoaiNhanVien", idDotDanhGia, idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }


        public override DataTable BaoCaoXepLoaiDanhGiaCaNhanThang(int idDotDanhGia, int idTrungTam, int idPhongBan, int chucVu, int xeploai)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGia_BaoCaoXepLoaiDanhGiaCaNhanThang", idDotDanhGia, idTrungTam, chucVu, xeploai, idPhongBan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable BaoCaoXepLoaiDanhGiaCaNhanThang(int idDotDanhGia, int idTrungTam, int idPhongBan, int chucVu, int xeploai, int idNguoiDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGia_BaoCaoXepLoaiDanhGiaCaNhanThangByNguoiDanhGia", idDotDanhGia, idTrungTam, chucVu, xeploai, idPhongBan, idNguoiDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        

        public override DataTable BaoCaoTienDoThucHienDanhGiaThang(int idDotDanhGia, int idTrungTam, int chucVu, int trangthai, int idPhongBan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGia_BaoCaoTienDoThucHienDanhGiaThang", idDotDanhGia, idTrungTam, chucVu, trangthai, idPhongBan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public override DataTable BaoCaoTienDoThucHienDanhGiaThang(int idDotDanhGia, int idTrungTam, int chucVu, int trangthai, int idPhongBan, int idNguoiDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGia_BaoCaoTienDoThucHienDanhGiaThangByNguoiDanhGia", idDotDanhGia, idTrungTam, chucVu, trangthai, idPhongBan, idNguoiDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        
        public override DataSet BaoCaoKetQuaDiemPhoiHopBoPhanThang(int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "BaoCao_KetQuaDiemPhoiHopBoPhanThang", idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataSet BaoCaoKetQuaXepLoaiNhanVienCacThang(string idDotDanhGia, int idNhanVien)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGia_BaoCaoKetQuaXepLoaiNhanVienCacThang", idDotDanhGia, idNhanVien);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataSet BaoCaoKetQuaXepLoaiBoPhanCacThang(string idDotDanhGia, int idBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGia_BaoCaoKetQuaXepLoaiBoPhanCacThang", idDotDanhGia, idBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataTable BaoCaoTongHopXepLoaiBoPhan(int idDotDanhGia, int idBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "BaoCao_TongHopXepLoaiBoPhan", idDotDanhGia, idBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region DanhGia Khoi Luong Cong Viec

        public override DataTable GetAllDGCBCNVDanhGiaTTCV(int loai, int IDDotDanhGia, int IDNhanVien)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DGCBCNVDanhGiaTTCV_GetAll", loai, IDDotDanhGia, IDNhanVien);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override void DeleteDGCBCNVDanhGiaTTCV(int _id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DGCBCNVDanhGiaTTCV_Delete", _id);
        }

        public override int InsertDGCBCNVDanhGiaTTCV(DGCBCNVDanhGiaTTCVInfo _DGCBCNVDanhGiaTTCVInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "DGCBCNVDanhGiaTTCV_Insert",
                _DGCBCNVDanhGiaTTCVInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.IDNhanVien,
                _DGCBCNVDanhGiaTTCVInfo.TenCongViec,
                _DGCBCNVDanhGiaTTCVInfo.TyTrongCV,
                _DGCBCNVDanhGiaTTCVInfo.DiemTDG,
                _DGCBCNVDanhGiaTTCVInfo.DiemTBPDG,
                _DGCBCNVDanhGiaTTCVInfo.DiemThongNhat,
                _DGCBCNVDanhGiaTTCVInfo.IDNguoiDG,
                _DGCBCNVDanhGiaTTCVInfo.IDNguoiTN,
                _DGCBCNVDanhGiaTTCVInfo.Loai,

                _DGCBCNVDanhGiaTTCVInfo.SoLieuCamKet,
                _DGCBCNVDanhGiaTTCVInfo.IDCongViec,
                _DGCBCNVDanhGiaTTCVInfo.IDBoPhan,
                _DGCBCNVDanhGiaTTCVInfo.IDPhongBan

    );
        }

        public override void UpdateDGCBCNVDanhGiaTTCV(DGCBCNVDanhGiaTTCVInfo _DGCBCNVDanhGiaTTCVInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DGCBCNVDanhGiaTTCV_Update",
                _DGCBCNVDanhGiaTTCVInfo.ID,
                 _DGCBCNVDanhGiaTTCVInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.IDNhanVien,
                _DGCBCNVDanhGiaTTCVInfo.TenCongViec,
                _DGCBCNVDanhGiaTTCVInfo.TyTrongCV,
                _DGCBCNVDanhGiaTTCVInfo.DiemTDG,
                _DGCBCNVDanhGiaTTCVInfo.DiemTBPDG,
                _DGCBCNVDanhGiaTTCVInfo.DiemThongNhat,
                _DGCBCNVDanhGiaTTCVInfo.IDNguoiDG,
                _DGCBCNVDanhGiaTTCVInfo.IDNguoiTN,

                _DGCBCNVDanhGiaTTCVInfo.SoLieuCamKet);
        }

        public override DGCBCNVDanhGiaTTCVInfo GetInfoDGCBCNVDanhGiaTTCV(int _id)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "DGCBCNVDanhGiaTTCV_GetInfo", _id);
            DGCBCNVDanhGiaTTCVInfo zone = (DGCBCNVDanhGiaTTCVInfo)ObjectHelper.CreateObject(typeof(DGCBCNVDanhGiaTTCVInfo), dr);
            return zone;
        }

        #endregion

        #region Chat Luong cong viec

        public override void UpdateDGCBCNVDanhGiaCLCV(DGCBCNVDanhGiaCLCVInfo _DGCBCNVDanhGiaCLCVInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DGCBCNVDanhGiaCLCV_Update",
                _DGCBCNVDanhGiaCLCVInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaCLCVInfo.IDNhanVien,
                _DGCBCNVDanhGiaCLCVInfo.DiemTDG,
                _DGCBCNVDanhGiaCLCVInfo.DiemTBPDG,
                _DGCBCNVDanhGiaCLCVInfo.DiemThongNhat,
                _DGCBCNVDanhGiaCLCVInfo.Loai,
                _DGCBCNVDanhGiaCLCVInfo.GhiChu);
        }

        public override DGCBCNVDanhGiaCLCVInfo GetInfoDGCBCNVDanhGiaCLCV(int _idDotDanhGia, int _idNhanVien, int _idTrungTam, int _loai)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "DGCBCNVDanhGiaCLCV_GetInfo", _idDotDanhGia, _idNhanVien, _idTrungTam, _loai);
            DGCBCNVDanhGiaCLCVInfo zone = (DGCBCNVDanhGiaCLCVInfo)ObjectHelper.CreateObject(typeof(DGCBCNVDanhGiaCLCVInfo), dr);
            return zone;
        }

        #endregion


        public override void UpdateDanhGiaNangLucNhanVien(DGCBCNVDanhGiaNangLucNhanVienInfo _DGCBCNVDanhGiaTDvaKLInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DGCBCNVDanhGiaNangLucNhanVien_Update",
                _DGCBCNVDanhGiaTDvaKLInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTDvaKLInfo.IDNhanVien,
                _DGCBCNVDanhGiaTDvaKLInfo.DiemTDG,
                _DGCBCNVDanhGiaTDvaKLInfo.DiemPTDG,
                _DGCBCNVDanhGiaTDvaKLInfo.DiemThongNhat,
                _DGCBCNVDanhGiaTDvaKLInfo.Loai,
                "");
        }

        #region Thai Do Va Ky Luat

        public override void UpdateDGCBCNVDanhGiaTDvaKL(DGCBCNVDanhGiaTDvaKLInfo _DGCBCNVDanhGiaTDvaKLInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DGCBCNVDanhGiaTDvaKL_Update",
                _DGCBCNVDanhGiaTDvaKLInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTDvaKLInfo.IDNhanVien,
                _DGCBCNVDanhGiaTDvaKLInfo.DiemTDG,
                _DGCBCNVDanhGiaTDvaKLInfo.DiemTBPDG,
                _DGCBCNVDanhGiaTDvaKLInfo.DiemThongNhat,
                _DGCBCNVDanhGiaTDvaKLInfo.Loai,
                _DGCBCNVDanhGiaTDvaKLInfo.GhiChu);
        }

        public override void DanhGiaThang_DGCBCNVDanhGiaTDvaKL_Update(DGCBCNVDanhGiaTDvaKLInfo _DGCBCNVDanhGiaTDvaKLInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaThang_DGCBCNVDanhGiaTDvaKL_Update",
                _DGCBCNVDanhGiaTDvaKLInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTDvaKLInfo.IDNhanVien,
                _DGCBCNVDanhGiaTDvaKLInfo.DiemTDG,
                _DGCBCNVDanhGiaTDvaKLInfo.DiemTBPDG,
                _DGCBCNVDanhGiaTDvaKLInfo.DiemThongNhat,
                _DGCBCNVDanhGiaTDvaKLInfo.Loai,
                _DGCBCNVDanhGiaTDvaKLInfo.GhiChu);
        }

        public override DGCBCNVDanhGiaTDvaKLInfo GetInfoDGCBCNVDanhGiaTDvaKL(int _idDotDanhGia, int _idNhanVien, int _loai)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "DGCBCNVDanhGiaTDvaKL_GetInfo", _idDotDanhGia, _idNhanVien, _loai);
            DGCBCNVDanhGiaTDvaKLInfo zone = (DGCBCNVDanhGiaTDvaKLInfo)ObjectHelper.CreateObject(typeof(DGCBCNVDanhGiaTDvaKLInfo), dr);
            return zone;
        }

        public override DGCBCNVDanhGiaTDvaKLInfo GetInfoDGCBCNVDanhGiaTDvaKLNew(int _idDotDanhGia, int _idNhanVien, int _loai, int capDoDanhGia)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "DGCBCNVDanhGiaTDvaKL_GetInfoNew", _idDotDanhGia, _idNhanVien, _loai, capDoDanhGia);
            DGCBCNVDanhGiaTDvaKLInfo zone = (DGCBCNVDanhGiaTDvaKLInfo)ObjectHelper.CreateObject(typeof(DGCBCNVDanhGiaTDvaKLInfo), dr);
            return zone;
        }


        public override DGCBCNVDanhGiaNangLucNhanVienInfo GetDanhGiaNangLucNhanVienInfo(int _idDotDanhGia, int _idNhanVien, int _loai)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "DGCBCNVDanhGiaNangLucNhanVien_GetInfo", _idDotDanhGia, _idNhanVien, _loai);
            DGCBCNVDanhGiaNangLucNhanVienInfo zone = (DGCBCNVDanhGiaNangLucNhanVienInfo)ObjectHelper.CreateObject(typeof(DGCBCNVDanhGiaNangLucNhanVienInfo), dr);
            return zone;
        }


        public override DGCBCNVDanhGiaTDvaKLInfo GetInfoDGCBCNVDanhGiaTDvaKLDanhGiaThang(int _idDotDanhGia, int _idNhanVien, int _loai)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "DanhGiaThang_DGCBCNVDanhGiaTDvaKL_GetInfo", _idDotDanhGia, _idNhanVien, _loai);
            DGCBCNVDanhGiaTDvaKLInfo zone = (DGCBCNVDanhGiaTDvaKLInfo)ObjectHelper.CreateObject(typeof(DGCBCNVDanhGiaTDvaKLInfo), dr);
            return zone;
        }

        #endregion

        #region Danh Gia Chi Tiet

        public override DataTable GetAllDGCBCNVDanhGiaChiTiet(int loai, int IDDotDanhGia, int idNhanVien)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DGCBCNVDanhGiaChiTiet_GetAll", loai, IDDotDanhGia, idNhanVien);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override void UpdateDGCBCNVDanhGiaChiTiet(DGCBCNVDanhGiaChiTietInfo _DGCBCNVDanhGiaChiTietInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DGCBCNVDanhGiaChiTiet_Update",
                _DGCBCNVDanhGiaChiTietInfo.ID,
                _DGCBCNVDanhGiaChiTietInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaChiTietInfo.IDNhanVien,
                _DGCBCNVDanhGiaChiTietInfo.NoiDung,
                _DGCBCNVDanhGiaChiTietInfo.TBPDanhGia,
                _DGCBCNVDanhGiaChiTietInfo.GhiChu,
                _DGCBCNVDanhGiaChiTietInfo.Loai);
        }

        public override void DeleteDGCBCNVDanhGiaChiTiet(int id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DGCBCNVDanhGiaChiTiet_Delete", id);
        }

        public override DGCBCNVDanhGiaChiTietInfo GetInfoDGCBCNVDanhGiaChiTiet(int id)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "DGCBCNVDanhGiaChiTiet_GetInfo", id);
            DGCBCNVDanhGiaChiTietInfo zone = (DGCBCNVDanhGiaChiTietInfo)ObjectHelper.CreateObject(typeof(DGCBCNVDanhGiaChiTietInfo), dr);
            return zone;
        }
        #endregion

        #region DanhGiaBoPhan

        public override void UpdateDanhGiaBoPhanTDvaKL(DGBoPhanTDvaKLInfo _DotDanhGiaInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DotDanhGia_UpdateDanhGiaBoPhanTDvaKL",
                _DotDanhGiaInfo.IDDotDanhGia,
                _DotDanhGiaInfo.IDBoPhan,
                _DotDanhGiaInfo.DiemTuDanhGia,
                _DotDanhGiaInfo.DiemCOODanhGia,
                _DotDanhGiaInfo.DiemThongNhat,
                _DotDanhGiaInfo.Loai);
        }
        public override void DanhGiaThang_UpdateDanhGiaBoPhanTDvaKL(DGBoPhanTDvaKLInfo _DotDanhGiaInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaThang_UpdateDanhGiaBoPhanTDvaKL",
                _DotDanhGiaInfo.IDDotDanhGia,
                _DotDanhGiaInfo.IDBoPhan,
                _DotDanhGiaInfo.DiemTuDanhGia,
                _DotDanhGiaInfo.DiemCOODanhGia,
                _DotDanhGiaInfo.DiemThongNhat,
                _DotDanhGiaInfo.Loai,
                _DotDanhGiaInfo.GhiChu);
        }

        public override DGBoPhanTDvaKLInfo GetInfoDanhGiaBoPhanTDvaKL(int _idDotDanhGia, int idBoPhan, int _loai)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "DotDanhGia_GetInfoDanhGiaBoPhanTDvaKL", _idDotDanhGia, idBoPhan, _loai);
            DGBoPhanTDvaKLInfo zone = (DGBoPhanTDvaKLInfo)ObjectHelper.CreateObject(typeof(DGBoPhanTDvaKLInfo), dr);
            return zone;
        }
        public override DGBoPhanTDvaKLInfo DanhGiaThang_GetInfoDanhGiaBoPhanTDvaKL(int _idDotDanhGia, int idBoPhan, int _loai)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "DanhGiaThang_GetInfoDanhGiaBoPhanTDvaKL", _idDotDanhGia, idBoPhan, _loai);
            DGBoPhanTDvaKLInfo zone = (DGBoPhanTDvaKLInfo)ObjectHelper.CreateObject(typeof(DGBoPhanTDvaKLInfo), dr);
            return zone;
        }
        public override DataTable GetAllDanhGiaBoPhanChiTiet(int loai, int IDDotDanhGiaVaNhanVien, int idBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaBoPhanChiTiet_GetAll", loai, IDDotDanhGiaVaNhanVien, idBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public override DataTable DanhGiaThang_GetAllDanhGiaBoPhanChiTiet(int loai, int IDDotDanhGia, int idBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaThang_DanhGiaBoPhanChiTiet_GetAll", loai, IDDotDanhGia, idBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public override void UpdateDanhGiaBoPhanChiTiet(DanhGiaBoPhanChiTietInfo _DGCBCNVDanhGiaChiTietInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaBoPhanChiTiet_Update",
                _DGCBCNVDanhGiaChiTietInfo.ID,
                _DGCBCNVDanhGiaChiTietInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaChiTietInfo.IDBoPhan,
                _DGCBCNVDanhGiaChiTietInfo.NoiDung,
                _DGCBCNVDanhGiaChiTietInfo.TBPDanhGia,
                _DGCBCNVDanhGiaChiTietInfo.GhiChu,
                _DGCBCNVDanhGiaChiTietInfo.Loai);
        }

        public override void DanhGiaThang_UpdateDanhGiaBoPhanChiTiet(DanhGiaBoPhanChiTietInfo _DGCBCNVDanhGiaChiTietInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaThang_BoPhanChiTiet_Update",
                _DGCBCNVDanhGiaChiTietInfo.ID,
                _DGCBCNVDanhGiaChiTietInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaChiTietInfo.IDBoPhan,
                _DGCBCNVDanhGiaChiTietInfo.NoiDung,
                _DGCBCNVDanhGiaChiTietInfo.TBPDanhGia,
                _DGCBCNVDanhGiaChiTietInfo.GhiChu,
                _DGCBCNVDanhGiaChiTietInfo.Loai);
        }

        public override void DeleteDanhGiaBoPhanChiTiet(int id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaBoPhanChiTiet_Delete", id);
        }

        public override DanhGiaBoPhanChiTietInfo GetInfoDanhGiaBoPhanChiTiet(int id)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "DanhGiaBoPhanChiTiet_GetInfo", id);
            DanhGiaBoPhanChiTietInfo zone = (DanhGiaBoPhanChiTietInfo)ObjectHelper.CreateObject(typeof(DanhGiaBoPhanChiTietInfo), dr);
            return zone;
        }

        public override DataTable DiemPhoiHopBoPhan(int idDotDanhGia, int IdBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaBoPhanChiTiet_DiemPhoiHopBoPhan", idDotDanhGia, IdBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataSet TongDiemBoPhan(int idDotDanhGia, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaBoPhanChiTiet_TongDiemBoPhan", idDotDanhGia, idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetXepLoaiBoPhan(int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaBoPhan_GetXepLoaiBoPhan", idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }


        public override void UpdateXepLoaiBoPhan(int idTrungTam, int xepLoai, int idDotDanhGia)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaBoPhan_UpdateXepLoaiBoPhan", idTrungTam, xepLoai, idDotDanhGia);

        }

        public override void DanhGiaThang_UpdateXepLoaiBoPhan(int idDotDanhGian, int idTrungTam, int xepLoai, double tongdiem)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaThang_UpdateXepLoaiBoPhan", idDotDanhGian, idTrungTam, xepLoai, tongdiem);

        }

        public override DataTable GetAllDanhGiaBoPhanTTCV(int loai, int IDDotDanhGiaVaBoPhan, int idBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaBoPhanTTCV_GetAll", loai, IDDotDanhGiaVaBoPhan, idBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override void DeleteDanhGiaBoPhanTTCV(int _id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaBoPhanTTCV_Delete", _id);
        }

        public override int InsertDanhGiaBoPhanTTCV(DanhGiaBoPhanTTCVInfo _DGCBCNVDanhGiaTTCVInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "DanhGiaBoPhanTTCV_Insert",
                _DGCBCNVDanhGiaTTCVInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.IDBoPhan,
                _DGCBCNVDanhGiaTTCVInfo.TenCongViec,
                _DGCBCNVDanhGiaTTCVInfo.TyTrongCV,
                _DGCBCNVDanhGiaTTCVInfo.DiemTDG,
                _DGCBCNVDanhGiaTTCVInfo.DiemTBPDG,
                _DGCBCNVDanhGiaTTCVInfo.MatManh,
                _DGCBCNVDanhGiaTTCVInfo.MatYeu,
                _DGCBCNVDanhGiaTTCVInfo.Loai
    );
        }

        public override void UpdateDanhGiaBoPhanTTCV(DanhGiaBoPhanTTCVInfo _DGCBCNVDanhGiaTTCVInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaBoPhanTTCV_Update", _DGCBCNVDanhGiaTTCVInfo.ID,
                 _DGCBCNVDanhGiaTTCVInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.IDBoPhan,
                _DGCBCNVDanhGiaTTCVInfo.TenCongViec,
                _DGCBCNVDanhGiaTTCVInfo.TyTrongCV,
                _DGCBCNVDanhGiaTTCVInfo.DiemTDG,
                _DGCBCNVDanhGiaTTCVInfo.DiemTBPDG,
                _DGCBCNVDanhGiaTTCVInfo.MatManh,
                _DGCBCNVDanhGiaTTCVInfo.MatYeu,
                _DGCBCNVDanhGiaTTCVInfo.Loai);
        }

        public override DanhGiaBoPhanTTCVInfo GetInfoDanhGiaBoPhanTTCV(int _id)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "DanhGiaBoPhanTTCV_GetInfo", _id);
            DanhGiaBoPhanTTCVInfo zone = (DanhGiaBoPhanTTCVInfo)ObjectHelper.CreateObject(typeof(DanhGiaBoPhanTTCVInfo), dr);
            return zone;
        }

        #endregion

        #region DanhGiaThang Nhan Vien

        public override DataTable GetAllDanhGiaThang_DGCBCNVDanhGiaTTCV(int loai, int IDDotDanhGia, int IDNhanVien)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaThang_DGCBCNVDanhGiaTTCV_GetAll", loai, IDDotDanhGia, IDNhanVien);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable DanhGiaThang_GetAllCongViecCanHoTro(int loai, int IDDotDanhGia, int IDBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaThang_GetAllCongViecCanHoTro", loai, IDDotDanhGia, IDBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override void DeleteDanhGiaThang_DGCBCNVDanhGiaTTCVNew(int _id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DeleteDanhGiaThang_DGCBCNVDanhGiaTTCVNew", _id);
        }

        public override void DeleteDanhGiaThang_DGCBCNVDanhGiaTTCV(int _id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaThang_DGCBCNVDanhGiaTTCV_Delete", _id);
        }


        public override int InsertDanhGiaThangCVNV_DGCBCNVDanhGiaTTCV(DanhGiaThang_DGCBCNVDanhGiaTTCVInfo _DGCBCNVDanhGiaTTCVInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "DanhGiaThang_DGCBCNVDanhGiaTTCV_Insert1",
                _DGCBCNVDanhGiaTTCVInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.IDNhanVien,
                _DGCBCNVDanhGiaTTCVInfo.TenCongViec,
                _DGCBCNVDanhGiaTTCVInfo.TyTrongCV,
                _DGCBCNVDanhGiaTTCVInfo.SoLieuCamKet,
                _DGCBCNVDanhGiaTTCVInfo.SoLieuThucHienThucTeTrongThang,
                _DGCBCNVDanhGiaTTCVInfo.NhanVienDanhGiaTyLeHoanThanh,
                _DGCBCNVDanhGiaTTCVInfo.TBPDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.YeuCauHoTro,
                _DGCBCNVDanhGiaTTCVInfo.YKienCuaNhanVien,
                _DGCBCNVDanhGiaTTCVInfo.YKienCuaTBP,
                _DGCBCNVDanhGiaTTCVInfo.Loai,
                 _DGCBCNVDanhGiaTTCVInfo.SoGio
    );
        }

        public override int InsertDanhGiaThang_DGCBCNVDanhGiaTTCV(DanhGiaThang_DGCBCNVDanhGiaTTCVInfo _DGCBCNVDanhGiaTTCVInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "DanhGiaThang_DGCBCNVDanhGiaTTCV_Insert",
                _DGCBCNVDanhGiaTTCVInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.IDNhanVien,
                _DGCBCNVDanhGiaTTCVInfo.TenCongViec,
                _DGCBCNVDanhGiaTTCVInfo.TyTrongCV,
                _DGCBCNVDanhGiaTTCVInfo.SoLieuCamKet,
                _DGCBCNVDanhGiaTTCVInfo.SoLieuThucHienThucTeTrongThang,
                _DGCBCNVDanhGiaTTCVInfo.NhanVienDanhGiaTyLeHoanThanh,
                _DGCBCNVDanhGiaTTCVInfo.TBPDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.YeuCauHoTro,
                _DGCBCNVDanhGiaTTCVInfo.YKienCuaNhanVien,
                _DGCBCNVDanhGiaTTCVInfo.YKienCuaTBP,
                _DGCBCNVDanhGiaTTCVInfo.Loai,
                 _DGCBCNVDanhGiaTTCVInfo.SoGio
    );
        }

        public override void UpdateDanhGiaThang_DGCBCNVDanhGiaTTCV(DanhGiaThang_DGCBCNVDanhGiaTTCVInfo _DGCBCNVDanhGiaTTCVInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaThang_DGCBCNVDanhGiaTTCV_Update",
                _DGCBCNVDanhGiaTTCVInfo.ID,
                _DGCBCNVDanhGiaTTCVInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.IDNhanVien,
                _DGCBCNVDanhGiaTTCVInfo.TenCongViec,
                _DGCBCNVDanhGiaTTCVInfo.TyTrongCV,
                _DGCBCNVDanhGiaTTCVInfo.SoLieuCamKet,
                _DGCBCNVDanhGiaTTCVInfo.SoLieuThucHienThucTeTrongThang,
                _DGCBCNVDanhGiaTTCVInfo.NhanVienDanhGiaTyLeHoanThanh,
                _DGCBCNVDanhGiaTTCVInfo.TBPDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.YeuCauHoTro,
                _DGCBCNVDanhGiaTTCVInfo.YKienCuaNhanVien,
                _DGCBCNVDanhGiaTTCVInfo.YKienCuaTBP,
                _DGCBCNVDanhGiaTTCVInfo.Loai,
                _DGCBCNVDanhGiaTTCVInfo.IDCongViec,
                _DGCBCNVDanhGiaTTCVInfo.IDBoPhan,
                _DGCBCNVDanhGiaTTCVInfo.IDBoPhanHoTro,
                _DGCBCNVDanhGiaTTCVInfo.IDPhongBan,
                 _DGCBCNVDanhGiaTTCVInfo.SoGio);
        }

        public override DanhGiaThang_DGCBCNVDanhGiaTTCVInfo GetInfoDanhGiaThang_DGCBCNVDanhGiaTTCV(int _id)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "DanhGiaThang_DGCBCNVDanhGiaTTCV_GetInfo", _id);
            DanhGiaThang_DGCBCNVDanhGiaTTCVInfo zone = (DanhGiaThang_DGCBCNVDanhGiaTTCVInfo)ObjectHelper.CreateObject(typeof(DanhGiaThang_DGCBCNVDanhGiaTTCVInfo), dr);
            return zone;
        }

        public override DataSet DanhGiaThang_DGCBCNVDanhGia_TongDiem(int idDotDanhGia, int idNhanVien)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaThang_DGCBCNVDanhGia_TongDiem", idDotDanhGia, idNhanVien);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataSet DanhGiaThang_DGCBCNVDanhGia_TongDiemCongThucMoi(int idDotDanhGia, int idNhanVien)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaThang_DGCBCNVDanhGia_TongDiemCongThucMoi", idDotDanhGia, idNhanVien);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataSet DanhGiaCheckPoint_DGCBCNVDanhGia_TongDiemCongThucMoi(int idDotDanhGia, int idNhanVien)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaCheckPoint_DGCBCNVDanhGia_TongDiemCongThucMoi", idDotDanhGia, idNhanVien);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }


        public override DataTable CheckPoint_DanhGiaTDvaKL_GetDiemTB(int idDotDanhGia, int idNhanVien)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "CheckPoint_DanhGiaTDvaKL_GetDiemTB", idDotDanhGia, idNhanVien);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }  
        public override DataTable CheckPoint_GetAllDotDanhGiaByCheckpoint(int checkPointID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "CheckPoint_GetAllDotDanhGia", checkPointID);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }  

        public override DataTable CheckPoint_DanhGiaCongViec_GetDiemTB(int idDotDanhGia, int idNhanVien)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "CheckPoint_DanhGiaCongViec_GetDiemTB", idDotDanhGia, idNhanVien);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }        

        public override void GuiDanhGiaThang(int idDotDanhGia, int idNhanVien, int status)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaThang_DGCBCNV_GuiDanhGia", idDotDanhGia, idNhanVien, status);
        }

        public override int InsertKeHoachThang_DGCBCNVDanhGiaTTCV(DanhGiaThang_DGCBCNVDanhGiaTTCVInfo _DGCBCNVDanhGiaTTCVInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "KeHoachThang_DGCBCNVDanhGiaTTCV_Insert_5_6_2014",
                _DGCBCNVDanhGiaTTCVInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.IDNhanVien,
                _DGCBCNVDanhGiaTTCVInfo.TenCongViec,
                _DGCBCNVDanhGiaTTCVInfo.TyTrongCV,
                _DGCBCNVDanhGiaTTCVInfo.SoLieuCamKet,
                _DGCBCNVDanhGiaTTCVInfo.YeuCauHoTro,
                _DGCBCNVDanhGiaTTCVInfo.Loai,
                _DGCBCNVDanhGiaTTCVInfo.IDCongViec,
                _DGCBCNVDanhGiaTTCVInfo.IDBoPhanHoTro,
                _DGCBCNVDanhGiaTTCVInfo.IDBoPhan,
                _DGCBCNVDanhGiaTTCVInfo.IDPhongBan,
                 _DGCBCNVDanhGiaTTCVInfo.SoGio,
                 _DGCBCNVDanhGiaTTCVInfo.NgayBatDau,
                 _DGCBCNVDanhGiaTTCVInfo.NgayKetThuc
    );
        }

        public override void UpdateKeHoachThang_DGCBCNVDanhGiaTTCV(DanhGiaThang_DGCBCNVDanhGiaTTCVInfo _DGCBCNVDanhGiaTTCVInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "KeHoachThang_DGCBCNVDanhGiaTTCV_Update",
                _DGCBCNVDanhGiaTTCVInfo.ID,
                _DGCBCNVDanhGiaTTCVInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.IDNhanVien,
                _DGCBCNVDanhGiaTTCVInfo.TenCongViec,
                _DGCBCNVDanhGiaTTCVInfo.TyTrongCV,
                _DGCBCNVDanhGiaTTCVInfo.SoGio,
                _DGCBCNVDanhGiaTTCVInfo.SoLieuCamKet,
                _DGCBCNVDanhGiaTTCVInfo.YeuCauHoTro,
                _DGCBCNVDanhGiaTTCVInfo.Loai,
                _DGCBCNVDanhGiaTTCVInfo.IDCongViec,
                _DGCBCNVDanhGiaTTCVInfo.IDBoPhanHoTro,
                _DGCBCNVDanhGiaTTCVInfo.IDBoPhan,
                _DGCBCNVDanhGiaTTCVInfo.IDPhongBan);
        }

        public override void UpdateKeHoachThangBoPhanHoTro(int idDotDanhGia, int idCongViec, int idBoPhanHoTro)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "KeHoachThang_UpdateBoPhanHoTro",
                idDotDanhGia, idCongViec, idBoPhanHoTro);
        }

        public override void DeleteKeHoachThangBoPhanHoTro(int idDotDanhGia, int idCongViec, int idBoPhanHoTro)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "KeHoachThang_DeleteBoPhanHoTro",
                idDotDanhGia, idCongViec, idBoPhanHoTro);
        }

        public override DataTable GetKeHoachThangBoPhanHoTro(int idDotDanhGia, int idCongViec)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "KeHoachThang_GetBoPhanHoTro", idDotDanhGia, idCongViec);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }

        }

        public override DataTable GetAllNhanVien()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllNhanVien");

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllNhanVien(int idTrungTam, int idPhongBan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllNhanVienByTrungTamVaPhongBan", idTrungTam, idPhongBan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllNhanVien(int idTrungTam, int idPhongBan, int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllNhanVienByTrungTamVaPhongBanDotDanhGia_30_12_2013", idTrungTam, idPhongBan, idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllNhanVienTemp(int idTrungTam, int idPhongBan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllNhanVienByTrungTamVaPhongBanTemp", idTrungTam, idPhongBan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllPhongBanByParentId(int idTrungTam, int parentId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllPhongBanByParentID", idTrungTam, parentId);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllMaNhomCongViec(int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllMaNhomCongViec", idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllPhongBan(int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllPhongBan", idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllPhongBan(int idTrungTam, int idTruongPhong)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllPhongBanByTruongPhong", idTrungTam, idTruongPhong);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Quan ly cong viec KPI

        public override DataTable GetAllCongViecKPI(int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetAll", idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllCongViecKPI(int idTrungTam, int idPhongBan, int loai)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetAllByPhongBan", idTrungTam, idPhongBan, loai);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }


        public override DataTable GetAllByParentID(int parentId, int idTrungTam, int idPhongBan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetAllByParentId", parentId, idTrungTam, idPhongBan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override int InsertCongViecKPI(QuanLyCongViecKPIInfo _QuanLyCongViecKPIInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "QuanLyCongViecKPI_Insert", _QuanLyCongViecKPIInfo.Ten, _QuanLyCongViecKPIInfo.TyTrong, _QuanLyCongViecKPIInfo.ParentID, _QuanLyCongViecKPIInfo.KeHoach, _QuanLyCongViecKPIInfo.DonViDo, _QuanLyCongViecKPIInfo.IDTrungTam, _QuanLyCongViecKPIInfo.IDPhongBan);
        }

        public override void UpdateCongViecKPI(QuanLyCongViecKPIInfo _QuanLyCongViecKPIInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "QuanLyCongViecKPI_Update", _QuanLyCongViecKPIInfo.ID, _QuanLyCongViecKPIInfo.Ten, _QuanLyCongViecKPIInfo.TyTrong, _QuanLyCongViecKPIInfo.ParentID, _QuanLyCongViecKPIInfo.KeHoach, _QuanLyCongViecKPIInfo.DonViDo, _QuanLyCongViecKPIInfo.IDTrungTam, _QuanLyCongViecKPIInfo.IDPhongBan);
        }

        public override void SetPriority(int _id, int order)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "QuanLyCongViecKPI_SetPriority", _id, order);
        }

        public override void DeleteCongViecKPI(int _id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "QuanLyCongViecKPI_Delete", _id);
        }
        public override QuanLyCongViecKPIInfo GetInfoCongViecKPI(int _id)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "QuanLyCongViecKPI_GetInfo", _id);
            QuanLyCongViecKPIInfo zone = (QuanLyCongViecKPIInfo)ObjectHelper.CreateObject(typeof(QuanLyCongViecKPIInfo), dr);
            return zone;
        }

        public override void UpdateCongViecChoNhanVien(int idNhanVien, int idCongViec, int idDotDanhGia, int idTrungTam, int idPhongBan, double tytrong, double sogio)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "QuanLyCongViecKPI_UpdateCongViecChoNhanVienNew", idNhanVien, idCongViec, idDotDanhGia, idTrungTam, idPhongBan, tytrong, sogio);
        }

        public override void RemoveCongViecGiaoChoNhanVien(int idNhanVien, int idCongViec, int idDotDanhGia, int idTrungTam, int idPhongBan)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "QuanLyCongViecKPI_RemoveCongViecGiaoChoNhanVienNew", idNhanVien, idCongViec, idDotDanhGia, idTrungTam, idPhongBan);
        }

        public override DataTable GetAllCongViecGiaoChoNhanVien(int idNhanVien)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetAllCongViecGiaoChoNhanVien", idNhanVien);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllNhanVienTheoCongViec(int idCongViec, int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetAllNhanVienTheoCongViec", idCongViec, idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataSet GetAllNhanVienTheoIDCongViec(int idTrungTam, int idCongViec, int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetAllNhanVienTheoIDCongViec", idTrungTam, idCongViec, idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetTyTrongCongViec(int idCongViecKPI, int idDotDanhGia, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetTyTrongCongViec", idCongViecKPI, idDotDanhGia, idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetTyTrongCongViec(int idCongViecKPI, int idDotDanhGia, int idTrungTam, int idPhongBan, int userId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetTyTrongCongViecNew", idCongViecKPI, idDotDanhGia, idTrungTam, idPhongBan, userId);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetTyTrongHoanThanhCongViec(int idCongViecKPI, int idDotDanhGia, int idBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetTyTrongHoanThanhCongViec", idCongViecKPI, idDotDanhGia, idBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetTongTyTrongCacCongViecCon(int idCongViecKPI)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetTyTrongCongViecCon", idCongViecKPI);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetTongTLHTCacCongViecCon(int idCongViecKPI, int idDotDanhGia, int idBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetTongTLHTCacCongViecCon", idCongViecKPI, idDotDanhGia, idBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public override DataTable GetTongTLHTCacCongViecConNew(int idCongViecKPI, int idDotDanhGia, int idBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetTongTLHTCacCongViecConNew", idCongViecKPI, idDotDanhGia, idBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public override DataTable QuanLyCongViecKPI_GetTBPDanhGiaLaiCacCongViecCon(int idCongViecKPI, int idDotDanhGia, int idBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetTBPDanhGiaLaiCacCongViecCon", idCongViecKPI, idDotDanhGia, idBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public override DataTable QuanLyCongViecKPI_GetTBPDanhGiaLaiCacCongViecConNew(int idCongViecKPI, int idDotDanhGia, int idBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetTBPDanhGiaLaiCacCongViecConNew", idCongViecKPI, idDotDanhGia, idBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public override DataSet GetPTDG(int idNhanVien, int idPhongBan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetPTDG", idNhanVien, idPhongBan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataSet GetPTDG(int idNhanVien, int idPhongBan, int idDotDanhGia, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetPTDGNew", idNhanVien, idPhongBan, idDotDanhGia, idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }
        public override DataSet DotDanhGia_GetTyTrongCVDuocGiao(int idNhanVien, int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetTyTrongCVDuocGiao", idNhanVien, idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataTable KeHoachThang_GetCongViecCuaBoPhan_GetAll(int idBoPhan, int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "KeHoachThang_GetCongViecCuaBoPhan_GetAll", idBoPhan, idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable KeHoachThang_GetCongViecCuaBoPhan_GetAll_New(int idBoPhan, int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "KeHoachThang_GetCongViecCuaBoPhan_GetAll_New", idBoPhan, idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region DanhGiaThang Bo Phan

        public override DataTable GetAllDanhGiaThang_BoPhanTTCV(int loai, int IDDotDanhGia, int IDBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaThang_BoPhanTTCV_GetAll", loai, IDDotDanhGia, IDBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllDanhGiaThang_BoPhanTTCVNew(int loai, int IDDotDanhGia, int IDBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaThang_BoPhanTTCV_GetAllNew", loai, IDDotDanhGia, IDBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }


        public override DataTable GetMaNhomCongViec(int idCongViec)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetMaNhomCongViec", idCongViec);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public override DataTable GetNguoiThamGiaCongViec(int idDotDanhGia, int idCongViec)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaThang_BoPhanTTCV_GetNguoiThamGiaCongViec", idDotDanhGia, idCongViec);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetNguoiThamGiaCongViecKTXVaPS(int idDotDanhGia, int idCongViec)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaThang_BoPhanTTCV_GetNguoiThamGiaCongViecKTXVaPS", idDotDanhGia, idCongViec);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override void DeleteDanhGiaThang_BoPhanTTCV(int _id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaThang_BoPhanTTCV_Delete", _id);
        }
        public override void DeleteDanhGiaThang_BoPhanTTCVNew(int _id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaThang_BoPhanTTCV_DeleteNew", _id);
        }

        public override int InsertDanhGiaThang_BoPhanTTCV(DanhGiaThang_BoPhanTTCVInfo _DGCBCNVDanhGiaTTCVInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "DanhGiaThang_BoPhanTTCV_Insert",
                _DGCBCNVDanhGiaTTCVInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.IDBoPhan,
                _DGCBCNVDanhGiaTTCVInfo.TenCongViec,
                _DGCBCNVDanhGiaTTCVInfo.TyTrongCV,
                _DGCBCNVDanhGiaTTCVInfo.SoLieuCamKet,
                _DGCBCNVDanhGiaTTCVInfo.SoLieuThucHienThucTeTrongThang,
                _DGCBCNVDanhGiaTTCVInfo.TBPDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.TBPDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.YKienCuaCOO,
                _DGCBCNVDanhGiaTTCVInfo.YKienCuaCEO,
                _DGCBCNVDanhGiaTTCVInfo.Loai
    );
        }

        public override void UpdateDanhGiaThang_BoPhanTTCV(DanhGiaThang_BoPhanTTCVInfo _DGCBCNVDanhGiaTTCVInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaThang_BoPhanTTCV_Update",
                _DGCBCNVDanhGiaTTCVInfo.ID,
                _DGCBCNVDanhGiaTTCVInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.IDBoPhan,
                _DGCBCNVDanhGiaTTCVInfo.TenCongViec,
                _DGCBCNVDanhGiaTTCVInfo.TyTrongCV,
                _DGCBCNVDanhGiaTTCVInfo.SoLieuCamKet,
                _DGCBCNVDanhGiaTTCVInfo.SoLieuThucHienThucTeTrongThang,
                _DGCBCNVDanhGiaTTCVInfo.TBPDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.TBPDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.YKienCuaCOO,
                _DGCBCNVDanhGiaTTCVInfo.TyTrongCV,
                _DGCBCNVDanhGiaTTCVInfo.Loai);
        }

        public override DanhGiaThang_BoPhanTTCVInfo GetInfoDanhGiaThang_BoPhanTTCV(int _id)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "DanhGiaThang_BoPhanTTCV_GetInfo", _id);
            DanhGiaThang_BoPhanTTCVInfo zone = (DanhGiaThang_BoPhanTTCVInfo)ObjectHelper.CreateObject(typeof(DanhGiaThang_BoPhanTTCVInfo), dr);
            return zone;
        }

        public override DataSet DanhGiaThang_BoPhan_TongDiem(int idDotDanhGia, int IDBoPhan, int loai)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaThang_BoPhan_TongDiem", idDotDanhGia, IDBoPhan, loai);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataSet DanhGiaThang_BoPhan_TongDiemNew(int idDotDanhGia, int IDBoPhan, int loai)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaThang_BoPhan_TongDiemNew", idDotDanhGia, IDBoPhan, loai);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override void GuiDanhGiaThangBoPhan(int idDotDanhGia, int IDBoPhan, int status)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaThang_BoPhan_GuiDanhGia", idDotDanhGia, IDBoPhan, status);
        }

        public override int InsertKeHoachThang_BoPhanTTCV(DanhGiaThang_BoPhanTTCVInfo _DGCBCNVDanhGiaTTCVInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "KeHoachThang_BoPhanTTCV_Insert",
                _DGCBCNVDanhGiaTTCVInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.IDBoPhan,
                _DGCBCNVDanhGiaTTCVInfo.TenCongViec,
                _DGCBCNVDanhGiaTTCVInfo.TyTrongCV,
                _DGCBCNVDanhGiaTTCVInfo.SoLieuCamKet,
                _DGCBCNVDanhGiaTTCVInfo.Loai,
                _DGCBCNVDanhGiaTTCVInfo.IDCongViec,
                _DGCBCNVDanhGiaTTCVInfo.IDParent,
                _DGCBCNVDanhGiaTTCVInfo.IDBoPhanHoTro,
                _DGCBCNVDanhGiaTTCVInfo.IDNhanVien,
                _DGCBCNVDanhGiaTTCVInfo.IDPhongBan
    );
        }

        public override int InsertKeHoachThang_BoPhanTTCV_New(DanhGiaThang_BoPhanTTCVInfo _DGCBCNVDanhGiaTTCVInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "KeHoachThang_BoPhanTTCV_Insert_New_5_6_2014",
                _DGCBCNVDanhGiaTTCVInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.IDBoPhan,
                _DGCBCNVDanhGiaTTCVInfo.TenCongViec,
                _DGCBCNVDanhGiaTTCVInfo.TyTrongCV,
                _DGCBCNVDanhGiaTTCVInfo.SoLieuCamKet,
                _DGCBCNVDanhGiaTTCVInfo.Loai,
                _DGCBCNVDanhGiaTTCVInfo.IDCongViec,
                _DGCBCNVDanhGiaTTCVInfo.IDParent,
                _DGCBCNVDanhGiaTTCVInfo.IDBoPhanHoTro,
                _DGCBCNVDanhGiaTTCVInfo.IDNhanVien,
                _DGCBCNVDanhGiaTTCVInfo.IDPhongBan,
                _DGCBCNVDanhGiaTTCVInfo.NgayBatDau,
                _DGCBCNVDanhGiaTTCVInfo.NgayKetThuc
    );
        }

        public override void UpdateKeHoachThang_BoPhanTTCV(DanhGiaThang_BoPhanTTCVInfo _DGCBCNVDanhGiaTTCVInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "KeHoachThang_BoPhanTTCV_Update",
                _DGCBCNVDanhGiaTTCVInfo.ID,
                _DGCBCNVDanhGiaTTCVInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.IDBoPhan,
                _DGCBCNVDanhGiaTTCVInfo.TenCongViec,
                _DGCBCNVDanhGiaTTCVInfo.TyTrongCV,
                _DGCBCNVDanhGiaTTCVInfo.SoLieuCamKet,
                _DGCBCNVDanhGiaTTCVInfo.Loai,
                _DGCBCNVDanhGiaTTCVInfo.IDCongViec,
                _DGCBCNVDanhGiaTTCVInfo.IDParent);
        }


        public override void UpdateKeHoachThangCOODanhGiaNew(DanhGiaThang_BoPhanTTCVInfo _DGCBCNVDanhGiaTTCVInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "KeHoachThang_BoPhanTTCV_UpdateCOODanhGiaNew",
                _DGCBCNVDanhGiaTTCVInfo.ID,
                _DGCBCNVDanhGiaTTCVInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.IDBoPhan,
                _DGCBCNVDanhGiaTTCVInfo.TBPDanhGiaLai,
                _DGCBCNVDanhGiaTTCVInfo.COODanhGia,
                _DGCBCNVDanhGiaTTCVInfo.YKienCuaCOO,
                _DGCBCNVDanhGiaTTCVInfo.YKienCuaCEO,
                _DGCBCNVDanhGiaTTCVInfo.Loai,
                _DGCBCNVDanhGiaTTCVInfo.IDCongViec,
                _DGCBCNVDanhGiaTTCVInfo.IDParent,
                _DGCBCNVDanhGiaTTCVInfo.TyTrongCV);
        }
        public override void UpdateKeHoachThangCOODanhGia(DanhGiaThang_BoPhanTTCVInfo _DGCBCNVDanhGiaTTCVInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "KeHoachThang_BoPhanTTCV_UpdateCOODanhGia",
                _DGCBCNVDanhGiaTTCVInfo.ID,
                _DGCBCNVDanhGiaTTCVInfo.IDDotDanhGia,
                _DGCBCNVDanhGiaTTCVInfo.IDBoPhan,
                _DGCBCNVDanhGiaTTCVInfo.TBPDanhGiaLai,
                _DGCBCNVDanhGiaTTCVInfo.COODanhGia,
                _DGCBCNVDanhGiaTTCVInfo.YKienCuaCOO,
                _DGCBCNVDanhGiaTTCVInfo.YKienCuaCEO,
                _DGCBCNVDanhGiaTTCVInfo.Loai,
                _DGCBCNVDanhGiaTTCVInfo.IDCongViec,
                _DGCBCNVDanhGiaTTCVInfo.IDParent);
        }

        public override DataTable DanhGiaThang_GetCongViecCuaBoPhan_GetAll(int idBoPhan, int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaThang_GetCongViecCuaBoPhan_GetAll", idBoPhan, idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable DanhGiaThang_GetCongViecCuaBoPhan_GetAllNew(int idBoPhan, int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGiaThang_GetCongViecCuaBoPhan_GetAllNew", idBoPhan, idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override void DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGia(int idCongViec, int idDotDanhGia, double TBPDanhGia)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGia", idCongViec, idDotDanhGia, TBPDanhGia);
        }
        public override void DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGiaNew(int idCongViec, int idDotDanhGia, double TBPDanhGia)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGiaNew", idCongViec, idDotDanhGia, TBPDanhGia);
        }
        public override void DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGiaLai(int idCongViec, int idDotDanhGia, double TBPDanhGia)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGiaLai", idCongViec, idDotDanhGia, TBPDanhGia);
        }
        public override void DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGiaLaiNew(int idCongViec, int idDotDanhGia, double TBPDanhGia, double TyTrongCV)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGiaLaiNew", idCongViec, idDotDanhGia, TBPDanhGia, TyTrongCV);
        }

        public override DataTable GetTrangThaiNhanVien(int idDotDanhGia, int idNhanVien, int idTrungTam, int idPhongBan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "GetTrangThaiNhanVien", idDotDanhGia, idNhanVien, idTrungTam, idPhongBan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllTruongBoPhan()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "GetAllTruongBoPhan");

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }


        public override void UpdateTrangThaiNhanVien(int idDotDanhGia, int idNhanVien, int trangthai, int idTrungTam, int idPhongBan)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "UpdateTrangThaiNhanVien", idDotDanhGia, idNhanVien, trangthai, idTrungTam, idPhongBan);
        }


        public override DataSet QuanLyCongViecKPI_GetTTCVCuaMotCongViecBatKy(int idTrungTam, int idCongViec)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetTTCVCuaMotCongViecBatKy", idTrungTam, idCongViec);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Dinh Nghia

        public override DataTable GetAllDinhNghia(string type)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DinhNghia_GetAll", type);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override void DeleteDinhNghia(int id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DinhNghia_Delete", id);
        }


        public override int InsertDinhNghia(DinhNghiaInfo _DinhNghiaInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "DinhNghia_Insert",
                _DinhNghiaInfo.Ten,
                _DinhNghiaInfo.MoTa,
                _DinhNghiaInfo.Code
    );
        }

        public override void UpdateDinhNghia(DinhNghiaInfo _DinhNghiaInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "DinhNghia_Update",
                _DinhNghiaInfo.ID,
                _DinhNghiaInfo.Ten,
                _DinhNghiaInfo.MoTa,
                _DinhNghiaInfo.Code);
        }

        public override DinhNghiaInfo GetInfoDinhNghia(int _id)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "DinhNghia_GetInfo", _id);
            DinhNghiaInfo zone = (DinhNghiaInfo)ObjectHelper.CreateObject(typeof(DinhNghiaInfo), dr);
            return zone;
        }

        #endregion

        #region Phong Ban

        public override DataSet GetAllKeHoachThangCuaPhong_BoPhanTTCV(int loai, int IDDotDanhGia, int IDBoPhan, int IDPhong)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "KeHoachThang_TTCVCuaPhongBan_GetAll", loai, IDDotDanhGia, IDBoPhan, IDPhong);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataSet GetAllKeHoachThangCuaPhong_BoPhanTTCV_ForExport(int loai, int IDDotDanhGia, int IDBoPhan, int IDPhong)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "KeHoachThang_TTCVCuaPhongBan_GetAll_ForExport", loai, IDDotDanhGia, IDBoPhan, IDPhong);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataSet GetAllKeHoachThangCuaPhong_BoPhanTTCV_New(int loai, int IDDotDanhGia, int IDBoPhan, int IDPhong)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "KeHoachThang_TTCVCuaPhongBan_GetAll_New", loai, IDDotDanhGia, IDBoPhan, IDPhong);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllNhomCongViec(int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "BoPhan_GetAllNhomCongViec", idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllPhong(int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "PhongBan_GetAll", idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllByParentID(int parentId, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "PhongBan_GetAllByParentId", parentId, idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }


        public override void DeleteNhomCongViec(int id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "NhomCongViec_Delete", id);
        }
        public override void DeletePhong(int id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "PhongBan_Delete", id);
        }


        public override int InsertPhong(PhongBanInfo _PhongBanInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "PhongBan_Insert",
                _PhongBanInfo.IDTrungTam,
                _PhongBanInfo.Ten,
                _PhongBanInfo.MoTa,
                _PhongBanInfo.TyTrong,
                _PhongBanInfo.IDNhanVienTruongPhong,
                _PhongBanInfo.SoNguoi,
                _PhongBanInfo.IDParent
    );
        }

        public override void UpdatePhong(PhongBanInfo _PhongBanInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "PhongBan_Update",
                _PhongBanInfo.ID,
                _PhongBanInfo.IDTrungTam,
                _PhongBanInfo.Ten,
                _PhongBanInfo.MoTa,
                _PhongBanInfo.TyTrong,
                _PhongBanInfo.IDNhanVienTruongPhong,
                _PhongBanInfo.SoNguoi,
                _PhongBanInfo.IDParent);
        }

        public override int InsertNhomCongViec(NhomCongViecInfo _PhongBanInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "NhomCongViec_Insert",
                _PhongBanInfo.IDBoPhan,
                _PhongBanInfo.TenNhomViec,
                _PhongBanInfo.MoTa,
                _PhongBanInfo.Ma
    );
        }

        public override void UpdateNhomCongViec(NhomCongViecInfo _PhongBanInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "NhomCongViec_Update",
                _PhongBanInfo.ID,
                _PhongBanInfo.IDBoPhan,
                _PhongBanInfo.TenNhomViec,
                _PhongBanInfo.MoTa,
                _PhongBanInfo.Ma);
        }

        public override NhomCongViecInfo GetInfoNhomCongViec(int _id)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "NhomCongViec_GetInfo", _id);
            NhomCongViecInfo zone = (NhomCongViecInfo)ObjectHelper.CreateObject(typeof(NhomCongViecInfo), dr);
            return zone;
        }
        public override PhongBanInfo GetInfoPhong(int _id)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "PhongBan_GetInfo", _id);
            PhongBanInfo zone = (PhongBanInfo)ObjectHelper.CreateObject(typeof(PhongBanInfo), dr);
            return zone;
        }

        #endregion

        #region Quan ly cong viec KTXVaPS

        public override DataTable GetAllCongViecKTXVaPS(int idTrungTam, int loai)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKTXVaPS_GetAll", idTrungTam, loai);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllByParentIDKTXVaPS(int parentId, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKTXVaPS_GetAllByParentId", parentId, idTrungTam, idPhongBan, loai, idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllByParentIDKTXVaPSNew(int parentId, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKTXVaPS_GetAllByParentIdNew", parentId, idTrungTam, idPhongBan, loai, idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override int InsertCongViecKTXVaPS(QuanLyCongViecKTXVaPSInfo _QuanLyCongViecKPIInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "QuanLyCongViecKTXVaPS_Insert_5_6_2014", _QuanLyCongViecKPIInfo.Ten, _QuanLyCongViecKPIInfo.TyTrong, _QuanLyCongViecKPIInfo.ParentID, _QuanLyCongViecKPIInfo.KeHoach, _QuanLyCongViecKPIInfo.DonViDo, _QuanLyCongViecKPIInfo.IDTrungTam, _QuanLyCongViecKPIInfo.IDPhongBan, _QuanLyCongViecKPIInfo.Loai, _QuanLyCongViecKPIInfo.IDDotDanhGia, _QuanLyCongViecKPIInfo.SoGio, _QuanLyCongViecKPIInfo.IsKPI, _QuanLyCongViecKPIInfo.NgayBatDau, _QuanLyCongViecKPIInfo.NgayKetThuc, _QuanLyCongViecKPIInfo.IDNhomCongViec, _QuanLyCongViecKPIInfo.TrangThaiCV, _QuanLyCongViecKPIInfo.TuanLamViec);
        }

        public override int InsertCongViecKTXVaPS_6_11_2014(QuanLyCongViecKTXVaPSInfo _QuanLyCongViecKPIInfo)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "QuanLyCongViecKTXVaPS_Insert_6_11_2014", _QuanLyCongViecKPIInfo.Ten, _QuanLyCongViecKPIInfo.TyTrong, _QuanLyCongViecKPIInfo.ParentID, _QuanLyCongViecKPIInfo.KeHoach, _QuanLyCongViecKPIInfo.DonViDo, _QuanLyCongViecKPIInfo.IDTrungTam, _QuanLyCongViecKPIInfo.IDPhongBan, _QuanLyCongViecKPIInfo.Loai, _QuanLyCongViecKPIInfo.IDDotDanhGia, _QuanLyCongViecKPIInfo.SoGio, _QuanLyCongViecKPIInfo.IsKPI, _QuanLyCongViecKPIInfo.NgayBatDau, _QuanLyCongViecKPIInfo.NgayKetThuc, _QuanLyCongViecKPIInfo.IDNhomCongViec, _QuanLyCongViecKPIInfo.TrangThaiCV, _QuanLyCongViecKPIInfo.TuanLamViec, _QuanLyCongViecKPIInfo.OldID);
        }

        public override void UpdateCongViecKTXVaPS(QuanLyCongViecKTXVaPSInfo _QuanLyCongViecKPIInfo)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "QuanLyCongViecKTXVaPS_Update_5_6_2014", _QuanLyCongViecKPIInfo.ID, _QuanLyCongViecKPIInfo.Ten, _QuanLyCongViecKPIInfo.TyTrong, _QuanLyCongViecKPIInfo.ParentID, _QuanLyCongViecKPIInfo.KeHoach, _QuanLyCongViecKPIInfo.DonViDo, _QuanLyCongViecKPIInfo.IDTrungTam, _QuanLyCongViecKPIInfo.IDPhongBan, _QuanLyCongViecKPIInfo.Loai, _QuanLyCongViecKPIInfo.IDDotDanhGia, _QuanLyCongViecKPIInfo.SoGio, _QuanLyCongViecKPIInfo.IsKPI, _QuanLyCongViecKPIInfo.NgayBatDau, _QuanLyCongViecKPIInfo.NgayKetThuc, _QuanLyCongViecKPIInfo.IDNhomCongViec, _QuanLyCongViecKPIInfo.TrangThaiCV, _QuanLyCongViecKPIInfo.TuanLamViec);
        }

        public override void SetPriorityKTXVaPS(int _id, int order)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "QuanLyCongViecKTXVaPS_SetPriority", _id, order);
        }

        public override void UpdateCapDoCongViec(int idCongViec, int level)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "QuanLyCongViecKTXVaPS_UpdateCapDoCongViec", idCongViec, level);
        }

        public override void UpdateTyTrong(int idCongViec, int soGio, int idTrungTam)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "QuanLyCongViecKTXVaPS_UpdateTyTrong", idCongViec, soGio, idTrungTam);
        }

        public override void DeleteCongViecKTXVaPS(int _id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "QuanLyCongViecKTXVaPS_Delete", _id);
        }
        public override void DeleteCongViecKTXVaPS(int _id, int idDotDanhGia)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "QuanLyCongViecKTXVaPS_DeleteByDotDanhGia", _id, idDotDanhGia);
        }
        public override void DeleteAll(int idTrungTam, int loai, int idDotDanhGia)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "QuanLyCongViecKTXVaPS_DeleteAllByDotDanhGia", idTrungTam, loai, idDotDanhGia);
        }


        public override QuanLyCongViecKTXVaPSInfo GetInfoCongViecKTXVaPS(int _id)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "QuanLyCongViecKTXVaPS_GetInfo", _id);
            QuanLyCongViecKTXVaPSInfo zone = (QuanLyCongViecKTXVaPSInfo)ObjectHelper.CreateObject(typeof(QuanLyCongViecKTXVaPSInfo), dr);
            return zone;
        }
        public override QuanLyCongViecKTXVaPSInfo GetInfoCongViecKTXVaPSByOldID(int _id)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "QuanLyCongViecKTXVaPS_GetInfoByOldID", _id);
            QuanLyCongViecKTXVaPSInfo zone = (QuanLyCongViecKTXVaPSInfo)ObjectHelper.CreateObject(typeof(QuanLyCongViecKTXVaPSInfo), dr);
            return zone;
        }


        public override void UpdateCongViecChoNhanVienKTXVaPS(int idNhanVien, int idCongViec)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "QuanLyCongViecKTXVaPS_UpdateCongViecChoNhanVien", idNhanVien, idCongViec);
        }

        public override void RemoveCongViecGiaoChoNhanVienKTXVaPS(int idNhanVien, int idCongViec)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "QuanLyCongViecKTXVaPS_RemoveCongViecGiaoChoNhanVien", idNhanVien, idCongViec);
        }

        public override DataTable KeHoachThang_BaoCaoNgayByCongViecTT(int idCongViec, int idDotDanhGia, DateTime ngay)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "KeHoachThang_BaoCaoNgayByCongViecTT", idCongViec, idDotDanhGia, ngay);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable KeHoachThang_GetCongViecCamKetHT(int idCongViec, int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "KeHoachThang_GetCongViecCamKetHT", idCongViec, idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable KeHoachThang_BaoCaoNgayByCongViecTK(int idCongViec, int idDotDanhGia, DateTime ngay)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "KeHoachThang_BaoCaoNgayByCongViecTK", idCongViec, idDotDanhGia, ngay);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllCongViecGiaoChoNhanVienKTXVaPS_6_11_2014(int idNhanVien, int loai, int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKTXVaPS_GetAllCongViecGiaoChoNhanVien_6_11_2014", idNhanVien, loai, idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public override DataTable GetAllCongViecGiaoChoNhanVienKTXVaPS(int idNhanVien, int loai, int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKTXVaPS_GetAllCongViecGiaoChoNhanVien", idNhanVien, loai, idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public override DataTable GetAllCongViecGiaoChoNhanVienTheoNgay(int idNhanVien, int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecBaoCaoNgay_GetAllCongViecGiaoChoNhanVien", idNhanVien, idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }



        public override DataTable GetAllCongViecGiaoChoNhanVienCoOldID(int idNhanVien, int loai, int idDotDanhGia, int idDotDanhGiaNew)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKTXVaPS_GetAllCongViecGiaoChoNhanVien_6_11_2014", idNhanVien, loai, idDotDanhGia, idDotDanhGiaNew);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllCongViecGiaoChoNhanVienKTXVaPS(int idNhanVien, int loai, int idDotDanhGia, int idDotDanhGiaNew)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKTXVaPS_GetAllCongViecGiaoChoNhanVienNew", idNhanVien, loai, idDotDanhGia, idDotDanhGiaNew);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable CheckNhanVienDaChuyen(int idNhanVien, int idDotDanhGia, int idTrungTam, int idPhongBan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_CheckNhanVienDaChuyen", idNhanVien, idDotDanhGia, idTrungTam, idPhongBan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }


        public override DataTable GetTyTrongCongViecKTXVaPS(int idCongViecKPI)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKTXVaPS_GetTyTrongCongViec", idCongViecKPI);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetTongTyTrongCacCongViecConKTXVaPS(int idCongViecKPI)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKTXVaPS_GetTyTrongCongViecCon", idCongViecKPI);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataSet GetCongViecDeCapNhatTyTrong(int idDotDanhGia, int idBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetCongViecDeCapNhatTyTrong", idDotDanhGia, idBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataSet GetCongViecDeCapNhatTyTrongNew(int idDotDanhGia, int idBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetCongViecDeCapNhatTyTrongNew", idDotDanhGia, idBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetMaxLevel(int idDotDanhGia, int idBoPhan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetMaxLevel", idDotDanhGia, idBoPhan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }


        public override DataTable QuanLyCongViecKPI_GetCongViecByType(int idDotDanhGia, int idBoPhan, int loai)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetCongViecByType", idDotDanhGia, idBoPhan, loai);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }


        #endregion

        public override DataTable TestGetKPIFromOldDB()
        {
            string test = AppEnv.GetSetting("ConnectionString1");
            DataSet ds = SqlHelper.ExecuteDataset(test, "TestGetKPIFromOldDB");

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override void UpdateTest(int id, string kehoach)
        {
            SqlHelper.ExecuteDataset(this.ConnectionString, "UpdateTest", id, kehoach);

        }

        public override DataTable GetUserInfo(int id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetUserInfo", id);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }


        #region Bao cao ngay

        public override DataTable GetAllBaoCaoNgayPhongBan(int idTrungTam, int idPhongBan, DateTime dt, int idDotDanhGia, int userId, int status)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecTheoNgay_GetAllBaoCaoNgayPhongBan", idTrungTam, idPhongBan, dt, idDotDanhGia, userId, status);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllBaoCaoNgayBoPhan(int idTrungTam, int idPhongBan, DateTime dt, int idDotDanhGia, int userId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecTheoNgay_GetAllBaoCaoNgayBoPhan", idTrungTam, idPhongBan, dt, idDotDanhGia, userId);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllBaoCaoNgay(int idTrungTam, DateTime dt, int userId, int userQL, int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecTheoNgay_GetAllBaoCaoNgay", idTrungTam, dt, userId, userQL, idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllByUserIDBaoCaoNgay(int idTrungTam, int idPhongBan, DateTime dtTime, int idDotDanhGia, int UserID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecTheoNgay_GetAllByUserID", idTrungTam, idPhongBan, dtTime, idDotDanhGia, UserID);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public override DataTable GetAllByParentIDBaoCaoNgay(int parentId, int idTrungTam, int idPhongBan, DateTime dtTime, int idDotDanhGia, int UserID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecTheoNgay_GetAllByParentId", parentId, idTrungTam, idPhongBan, dtTime, idDotDanhGia, UserID);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetTongTyTrongCacCongViecConBaoCaoNgay(int idCongViecKPI)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKPI_GetTyTrongCongViecConBaoCaoNgay", idCongViecKPI);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        #endregion

        public override void ClearAllCongViecTheoBoPhanVaDotDanhGia(int idDotDanhGia, int idTrungTam, int loai)
        {
            SqlHelper.ExecuteDataset(this.ConnectionString, "ClearAllCongViecTheoBoPhanVaDotDanhGia", idDotDanhGia, idTrungTam, loai);

        }

        public override DataTable GetAllBoPhanTheoLoai(int loai)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DanhGia_GetAllBoPhanTheoLoai", loai);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override QuanLyCongViecKTXVaPSInfo GetInfoCongViecKTXVaPSByTen(string tencongviec, int idDotDanhGia, int idbophan, int loai)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "QuanLyCongViecKTXVaPS_GetInfoByTen", tencongviec, idDotDanhGia, idbophan, loai);
            QuanLyCongViecKTXVaPSInfo zone = (QuanLyCongViecKTXVaPSInfo)ObjectHelper.CreateObject(typeof(QuanLyCongViecKTXVaPSInfo), dr);
            return zone;
        }

        public override DataTable GetAllCongViecDenHanDeadline(int idDotDanhGia, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKTXVaPS_GetAllCongViecDenHanDeadline", idDotDanhGia, idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllCongViecQuaHanDeadline(int idDotDanhGia, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKTXVaPS_GetAllCongViecQuaHanDeadline", idDotDanhGia, idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllCongViecTrongTuan(int idDotDanhGia, int idTrungTam, int tuan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKTXVaPS_GetAllCongViecTrongTuan", idDotDanhGia, idTrungTam, tuan);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }


        public override DataTable GetAllNhanVienInByNhanVienQuanLy(int idNhanVienQuanLy, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "DotDanhGia_GetAllNhanVienByNDG", idTrungTam, idNhanVienQuanLy);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }



        public override DataTable QuanLyNhanVienTheoNDG_GetAllNhanVien(int idNhanVienQuanLy, int idTrungTam, int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyNhanVienTheoNDG_GetAllNhanVien", idNhanVienQuanLy, idTrungTam, idDotDanhGia);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override DataTable GetAllNhanVienCapTBP_TP_PP(int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "GetAllTruongBoPhan_TP_TN", idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override void UpdateTyTrongCongViecNhanVienV2(int id, double tytrong, double sogio)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "UpdateTyTrongCongViecNhanVienV2", id, tytrong, sogio);
        }

        public override DataTable QuanLyNhanVienTheoNDG_ByNhanVienQuanLy(int idNhanVienQuanLy, int idDotDanhGia, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyNhanVienTheoNDG_ByNhanVienQuanLy", idNhanVienQuanLy, idDotDanhGia,idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }


        public override DataTable GetAllNhanVienTheoQLVaDotDanhGia(int idDotDanhGia, int idTrungTam)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "QuanLyCongViecKTXVaPS_GetAllNhanVienTheoQLVaDotDanhGia", idDotDanhGia, idTrungTam);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public override void DeleteRecursive(int id)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "QuanLyCongViecKTXVaPS_DeleteRecursive", id);

        }
        
    }
}
