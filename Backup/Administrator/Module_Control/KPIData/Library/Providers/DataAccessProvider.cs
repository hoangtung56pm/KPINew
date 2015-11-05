using System;
using System.Data;
using VmgPortal.Library.Components.Providers;
using VmgPortal.Modules.KPIData.Library.XepLoai;
using VmgPortal.Modules.KPIData.Library.Nhom;
using VmgPortal.Modules.KPIData.Library.XepLoaiNhom;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;
using VmgPortal.Modules.KPIData.Library.DanhGia;
using VmgPortal.Modules.KPIData.Library.DanhGiaBoPhan;
using VmgPortal.Modules.KPIData.Library.DinhNghia;
using VmgPortal.Modules.KPIData.Library.PhongBan;

namespace VmgPortal.Modules.KPIData.Library.Providers
{
    public abstract class DataAccessProvider
    {
        private static DataAccessProvider objProvider;
        public static DataAccessProvider Instance()
        {
            if (objProvider != null) return objProvider;
            DataAccessProviderConfiguration objConfig = DataAccessProviderConfiguration.GetDataAccessProviderConfiguration();
            Provider provider = new Provider(objConfig.DefaultProvider, "VmgPortal.Modules.KPIData.Library.Providers." + objConfig.DefaultProvider, ((Provider)objConfig.Providers[objConfig.DefaultProvider]).ConnectionString);
            objProvider = (DataAccessProvider)DataAccessProviderFactory.CreateDataAccess(provider);
            return objProvider;
        }

        #region Xep Loai

        public abstract DataTable GetAllXepLoai();
        public abstract void DeleteXepLoai(int _id);
        public abstract int InsertXepLoai(XepLoaiInfo _xepLoaiInfo);
        public abstract void UpdateXepLoai(XepLoaiInfo _xepLoaiInfo);
        public abstract XepLoaiInfo GetInfoXepLoai(int _id);

        #endregion

        #region Nhom

        public abstract DataTable GetAllNhom();
        public abstract void DeleteNhom(int _id);
        public abstract int InsertNhom(NhomInfo _NhomInfo);
        public abstract void UpdateNhom(NhomInfo _NhomInfo);
        public abstract NhomInfo GetInfoNhom(int _id);

        #endregion

        #region XepLoaiNhom

        public abstract DataTable GetAllXepLoaiNhom();
        public abstract void DeleteXepLoaiNhom(int _id);
        public abstract int InsertXepLoaiNhom(XepLoaiNhomInfo _XepLoaiNhomInfo);
        public abstract void UpdateXepLoaiNhom(XepLoaiNhomInfo _XepLoaiNhomInfo);
        public abstract XepLoaiNhomInfo GetInfoXepLoaiNhom(int _id);

        #endregion

        #region BoPhan

        public abstract DataTable GetAllBoPhan();
        public abstract DataTable GetAllWithStatus(int idDotDanhGia);
        public abstract DataTable GetAllWithTrangThai(int idDotDanhGia, int trangThai);
        public abstract DataTable BoPhan_GetAllActive();

        public abstract void DeleteBoPhan(int _id);
        public abstract int InsertBoPhan(BoPhanInfo _BoPhanInfo);
        public abstract void UpdateBoPhan(BoPhanInfo _BoPhanInfo);
        public abstract BoPhanInfo GetInfoBoPhan(int _id);
        public abstract void UpdatePhongBan(int IdNhanVien, int IdPhongBan, int idDotDanhGia);

        #endregion

        #region DotDanhGia


        public abstract DataTable GetAllMucDoanhThuLoiNhuan();
        public abstract void UpdateDoanhThuLoiNhuan(DotDanhGiaConfigInfo _DotDanhGiaInfo);
        public abstract void UpdateTLHTCongViec(DotDanhGiaTLHTCVInfo _DotDanhGiaInfo);
        public abstract void UpdateDanhGiaCheo(DotDanhGiaDanhGiaCheoInfo _DotDanhGiaInfo);
        
        public abstract DotDanhGiaConfigInfo GetInfoDotDanhGiaConfig(int _id, int idTrungTam);
        public abstract DotDanhGiaTLHTCVInfo GetInfoTLHTCongViec(int _id, int idTrungTam);
        public abstract DotDanhGiaDanhGiaCheoInfo GetInfoDanhGiaCheo(int _id, int idTrungTam);

        public abstract DataTable GetAllDotDanhGia();
        public abstract DataTable GetAllDotDanhGia(int type);
        public abstract void DeleteDotDanhGia(int _id);
        public abstract DataTable GetDaultDotDanhGia();
        public abstract DataTable GetDaultDotDanhGiaCheckPoint();
        
        public abstract int InsertDotDanhGia(DotDanhGiaInfo _DotDanhGiaInfo);
        public abstract void UpdateDotDanhGia(DotDanhGiaInfo _DotDanhGiaInfo);
        public abstract DotDanhGiaInfo GetInfoDotDanhGia(int _id);

        public abstract void UpdateNhanVienVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam, int idNhom);
        public abstract void UpdateNhanVienVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam, int idNhom, int nguoiDG);
        public abstract void UpdateNhanVienVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam, int idNhom, int nguoiDG, int trangthai);
        public abstract void RemoveNhanVienVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam);
        public abstract void RemoveNhanVienVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam, int idNguoiDG);

        public abstract void UpdateNhanVienTheoNDG(int idNhanVien, int idTrungTam, int nguoiDG, int idDotDanhGia);
        public abstract void RemoveNhanVienTheoNDG(int idNhanVien, int idTrungTam, int nguoiDG, int idDotDanhGia);

        public abstract void UpdateTruongBoPhanVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam);
        public abstract void RemoveTruongBoPhanVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam);

        public abstract DataTable GetAllNhanVienByTrungTam(int idTrungTam, int role);
        public abstract DataTable GetAllTruongPhongByTrungTam(int idTrungTam, int role);
        public abstract DataTable GetAllNhanVienNotByNhanVienQuanLy(int idDotDanhGia, int idNhanVienQuanLy, int idTrungTam);
        public abstract DataTable GetAllNhanVienInByNhanVienQuanLy(int idDotDanhGia, int idNhanVienQuanLy, int idTrungTam);
        public abstract DataTable GetAllNhanVienNotByNhanVienQuanLy(int idNhanVienQuanLy, int idTrungTam);
        
        public abstract DataTable GetAllNhanVienInDotDanhGia(int idDotDanhGia, int idTrungTam);
        public abstract DataTable GetAllNhanVienInDotDanhGiaExport(int idDotDanhGia, int idTrungTam);
        public abstract DataTable GetAllNhanVienInDotDanhGiaNew(int idDotDanhGia, int idTrungTam);
        public abstract DataTable GetAllNhanVienNotInDotDanhGia(int idDotDanhGia, int idTrungTam);

        public abstract DataTable GetAllTruongPhongInDotDanhGia(int idDotDanhGia, int idTrungTam, int idNhanVienQuanLy);
        public abstract DataTable GetAllTruongPhongNotInDotDanhGia(int idDotDanhGia, int idTrungTam);

        public abstract DataTable GetAllTruongBoPhanInDotDanhGia(int idDotDanhGia, int idTrungTam);
        public abstract DataTable GetAllTruongBoPhanNotInDotDanhGia(int idDotDanhGia, int idTrungTam);

        public abstract DataTable GetAllBoPhanInDotDanhGia(int idDotDanhGia);
        public abstract DataTable GetAllBoPhanNotInDotDanhGia(int idDotDanhGia);

        public abstract void UpdateBoPhanVaoDotDanhGia(int idDotDanhGia, int idTrungTam);
        public abstract void UpdateBoPhanVaoDotDanhGia(int idDotDanhGia, int idTrungTam, int trangThai);

        public abstract void RemoveBoPhanTrongDotDanhGia(int idDotDanhGia, int idTrungTam);


        public abstract DataSet DGCBCNVDanhGia_TongDiem(int idDotDanhGia, int idNhanVien);
        public abstract DataSet DGCBCNVDanhGia_TongDiemTBP(int idDotDanhGia, int idNhanVien, int idTrungTam);
        
        public abstract DataSet DGCBCNVDanhGiaDongNghiep_GetAll(int idDotDanhGia, int idNhanVien, int roleId);
        public abstract DataSet DGCBCNVDanhGiaDongNghiepTP_GetAll(int idDotDanhGia, int idNhanVien, int roleId);

        public abstract DataTable CheckPointDanhGiaDongNghiep_GetAll(int idDotDanhGia, int idNhanVien);
     
        public abstract void DGCBCNVDanhGiaDongNghiep_Update(int idDotDanhGia, int idNhanVien, int idNhanVienDuocDG, double diemDG, int loai, int capdodanhgia);
        public abstract void CheckPointDanhGiaDongNghiep_Update(int idDotDanhGia, int idNhanVien, int idNhanVienDuocDG, double diemDG, int loai, string nhanxet);
        public abstract void CheckPointDanhGiaDongNghiep_Delete(int idDotDanhGia, int idNhanVien, int idNhanVienDuocDG, double diemDG, int loai, string nhanxet);
        
        

        public abstract DataTable checkDanhGiaNam(int idDotDanhGia, int idNhanVien);
        public abstract DataTable checkDanhGiaThang(int idDotDanhGia, int idNhanVien);
        public abstract DataTable checkDanhGiaBoPhan(int idDotDanhGia);
        public abstract DataTable checkDanhGiaBoPhan(int idDotDanhGia, int idBoPhan);
        public abstract DataTable checkKeHoachPhongBan(int idDotDanhGia, int idBoPhan, int idPhongBan);        

        public abstract DataSet DGCBCNVDanhGiaPhoiHopBoPhan_GetAll(int idDotDanhGia, int idNhanVien);
        public abstract void DGCBCNVDanhGiaPhoiHopBoPhan_Update(int idDotDanhGia, int idNhanVien, int idBoPhanDuocDG, double diemDG, int loai);
        public abstract void DanhGiaThang_DanhGiaPhoiHopBoPhan_Update(int idDotDanhGia, int idBoPhan, int idBoPhanDuocDG, double diemDG, int loai, string ghichu);

        public abstract DataSet DanhGiaThang_DanhGiaPhoiHopBoPhan_GetAll(int idDotDanhGia, int idBoPhan);

        public abstract void GuiDanhGia(int idDotDanhGia, int idNhanVien, int status);
        public abstract void GuiDanhGiaBoPhan(int idDotDanhGia, int IDBoPhan, int status);

        public abstract DataTable GetAllNhanVienInNhom(int idNhom, int idTrungTam);

        public abstract DataTable GetAllNhanVienNotInNhom(int idNhom, int idTrungTam);
        public abstract void UpdateNhanVienVaoNhom(int idNhanVien, int idTrungTam, int idNhom);


        #endregion

        #region Common

        public abstract DataTable GetAllChucVu();
        public abstract DataTable GetAllNhomTieuChiDef();

        public abstract DataSet BaoCaoKetQuaDiemPhoiHopBoPhan(int idDotDanhGia);
        public abstract DataTable BaoCaoTienDoThucHienDanhGia(int idDotDanhGia, int idTrungTam, int chucVu, int trangthai, int idPhongBan);
        public abstract DataTable BaoCaoXepLoaiDanhGiaCaNhan(int idDotDanhGia, int idTrungTam, int chucVu, int xeploai, int idPhongBan);
        public abstract DataTable BaoCaoTongHopXepLoaiNhanVien(int idDotDanhGia, int idTrungTam);

        public abstract DataTable BaoCaoXepLoaiDanhGiaCaNhanThang(int idDotDanhGia, int idTrungTam, int idPhongBan, int chucVu, int xeploai);
        public abstract DataTable BaoCaoXepLoaiDanhGiaCaNhanThang(int idDotDanhGia, int idTrungTam, int idPhongBan, int chucVu, int xeploai, int idNguoiDanhGia);
        
        public abstract DataTable BaoCaoTienDoThucHienDanhGiaThang(int idDotDanhGia, int idTrungTam, int chucVu, int trangthai, int idPhongBan);
        public abstract DataTable BaoCaoTienDoThucHienDanhGiaThang(int idDotDanhGia, int idTrungTam, int chucVu, int trangthai, int idPhongBan, int idNguoiDanhGia);
        public abstract DataSet BaoCaoKetQuaXepLoaiNhanVienCacThang(string idDotDanhGia, int idNhanVien);
        public abstract DataSet BaoCaoKetQuaXepLoaiBoPhanCacThang(string idDotDanhGia, int idBoPhan);
        public abstract DataSet BaoCaoKetQuaDiemPhoiHopBoPhanThang(int idDotDanhGia);
        public abstract DataTable BaoCaoTongHopXepLoaiBoPhan(int idDotDanhGia, int idBoPhan);
        

        #endregion


        #region DanhGia

        public abstract DataTable GetAllDGCBCNVDanhGiaTTCV(int loai, int IDDotDanhGia, int IDNhanVien);
        public abstract void DeleteDGCBCNVDanhGiaTTCV(int _id);
        public abstract int InsertDGCBCNVDanhGiaTTCV(DGCBCNVDanhGiaTTCVInfo _DotDanhGiaInfo);
        public abstract void UpdateDGCBCNVDanhGiaTTCV(DGCBCNVDanhGiaTTCVInfo _DotDanhGiaInfo);
        public abstract DGCBCNVDanhGiaTTCVInfo GetInfoDGCBCNVDanhGiaTTCV(int _id);

        public abstract void UpdateDGCBCNVDanhGiaCLCV(DGCBCNVDanhGiaCLCVInfo _DotDanhGiaInfo);
        public abstract DGCBCNVDanhGiaCLCVInfo GetInfoDGCBCNVDanhGiaCLCV(int _idDotDanhGia, int _idNhanVien, int _idTrungTam, int _loai);

        public abstract void UpdateDGCBCNVDanhGiaTDvaKL(DGCBCNVDanhGiaTDvaKLInfo _DotDanhGiaInfo);
        public abstract void DanhGiaThang_DGCBCNVDanhGiaTDvaKL_Update(DGCBCNVDanhGiaTDvaKLInfo _DotDanhGiaInfo);

        public abstract DGCBCNVDanhGiaTDvaKLInfo GetInfoDGCBCNVDanhGiaTDvaKL(int _idDotDanhGia, int _idNhanVien, int _loai);
        public abstract DGCBCNVDanhGiaTDvaKLInfo GetInfoDGCBCNVDanhGiaTDvaKLNew(int _idDotDanhGia, int _idNhanVien, int _loai, int capDoDanhGia);

        

        public abstract DGCBCNVDanhGiaTDvaKLInfo GetInfoDGCBCNVDanhGiaTDvaKLDanhGiaThang(int _idDotDanhGia, int _idNhanVien, int _loai);
        public abstract DGCBCNVDanhGiaNangLucNhanVienInfo GetDanhGiaNangLucNhanVienInfo(int _idDotDanhGia, int _idNhanVien, int _loai);

        public abstract void UpdateDanhGiaNangLucNhanVien(DGCBCNVDanhGiaNangLucNhanVienInfo _DotDanhGiaInfo);

        

        #endregion

        #region Danh Gia Chi Tiet

        public abstract DataTable GetAllDGCBCNVDanhGiaChiTiet(int loai, int IDDotDanhGia, int idNhanVien);
        public abstract void UpdateDGCBCNVDanhGiaChiTiet(DGCBCNVDanhGiaChiTietInfo _DGCBCNVDanhGiaChiTietInfo);
        public abstract void DeleteDGCBCNVDanhGiaChiTiet(int id);
        public abstract DGCBCNVDanhGiaChiTietInfo GetInfoDGCBCNVDanhGiaChiTiet(int id);

        #endregion

        #region DanhGiaBoPhan

        public abstract void UpdateDanhGiaBoPhanTDvaKL(DGBoPhanTDvaKLInfo _DotDanhGiaInfo);

        public abstract DGBoPhanTDvaKLInfo GetInfoDanhGiaBoPhanTDvaKL(int _idDotDanhGia, int idBoPhan, int _loai);

        public abstract DataTable GetAllDanhGiaBoPhanChiTiet(int loai, int IDDotDanhGia, int idBoPhan);
        public abstract void UpdateDanhGiaBoPhanChiTiet(DanhGiaBoPhanChiTietInfo _DGCBCNVDanhGiaChiTietInfo);
        public abstract void DeleteDanhGiaBoPhanChiTiet(int id);
        public abstract DanhGiaBoPhanChiTietInfo GetInfoDanhGiaBoPhanChiTiet(int id);
        public abstract DataTable DiemPhoiHopBoPhan(int idDotDanhGia, int IdBoPhan);
        public abstract DataSet TongDiemBoPhan(int idDotDanhGia, int idTrungTam);
        public abstract void UpdateXepLoaiBoPhan(int idTrungTam, int xepLoai, int idDotDanhGia);
        public abstract DataTable GetXepLoaiBoPhan(int idTrungTam);

        public abstract DataTable GetAllDanhGiaBoPhanTTCV(int loai, int IDDotDanhGiaVaBoPhan, int idBoPhan);
        public abstract void DeleteDanhGiaBoPhanTTCV(int _id);
        public abstract int InsertDanhGiaBoPhanTTCV(DanhGiaBoPhanTTCVInfo _DotDanhGiaInfo);
        public abstract void UpdateDanhGiaBoPhanTTCV(DanhGiaBoPhanTTCVInfo _DotDanhGiaInfo);
        public abstract DanhGiaBoPhanTTCVInfo GetInfoDanhGiaBoPhanTTCV(int _id);

        #endregion

        #region DanhGiaThang Nhan Vien

        public abstract DataTable GetAllDanhGiaThang_DGCBCNVDanhGiaTTCV(int loai, int IDDotDanhGia, int IDNhanVien);
        public abstract DataTable DanhGiaThang_GetAllCongViecCanHoTro(int loai, int IDDotDanhGia, int IDBoPhan);
        

        public abstract void DeleteDanhGiaThang_DGCBCNVDanhGiaTTCV(int _id);
        public abstract void DeleteDanhGiaThang_DGCBCNVDanhGiaTTCVNew(int _id);
        
        public abstract int InsertDanhGiaThang_DGCBCNVDanhGiaTTCV(DanhGiaThang_DGCBCNVDanhGiaTTCVInfo _DotDanhGiaInfo);
        public abstract int InsertDanhGiaThangCVNV_DGCBCNVDanhGiaTTCV(DanhGiaThang_DGCBCNVDanhGiaTTCVInfo _DotDanhGiaInfo);
        
        public abstract void UpdateDanhGiaThang_DGCBCNVDanhGiaTTCV(DanhGiaThang_DGCBCNVDanhGiaTTCVInfo _DotDanhGiaInfo);
        public abstract DanhGiaThang_DGCBCNVDanhGiaTTCVInfo GetInfoDanhGiaThang_DGCBCNVDanhGiaTTCV(int _id);

        public abstract DataSet DanhGiaThang_DGCBCNVDanhGia_TongDiem(int idDotDanhGia, int IDNhanVien);
        public abstract DataSet DanhGiaThang_DGCBCNVDanhGia_TongDiemCongThucMoi(int idDotDanhGia, int IDNhanVien);
        public abstract DataSet DanhGiaCheckPoint_DGCBCNVDanhGia_TongDiemCongThucMoi(int idDotDanhGia, int IDNhanVien);
        public abstract DataTable CheckPoint_DanhGiaCongViec_GetDiemTB(int idDotDanhGia, int IDNhanVien);
        public abstract DataTable CheckPoint_GetAllDotDanhGiaByCheckpoint(int checkPointId);
        public abstract DataTable CheckPoint_DanhGiaTDvaKL_GetDiemTB(int idDotDanhGia, int IDNhanVien);
        

        public abstract void GuiDanhGiaThang(int idDotDanhGia, int IDNhanVien, int status);

        public abstract int InsertKeHoachThang_DGCBCNVDanhGiaTTCV(DanhGiaThang_DGCBCNVDanhGiaTTCVInfo _DotDanhGiaInfo);
        public abstract void UpdateKeHoachThang_DGCBCNVDanhGiaTTCV(DanhGiaThang_DGCBCNVDanhGiaTTCVInfo _DotDanhGiaInfo);
        
        public abstract DataTable GetAllNhanVien();
        public abstract DataTable GetAllNhanVien(int idTrungTam, int idPhongBan);
        public abstract DataTable GetAllNhanVien(int idTrungTam, int idPhongBan, int idDotDanhGia);
        
        public abstract DataTable GetAllNhanVienTemp(int idTrungTam, int idPhongBan);
        public abstract DataTable GetAllPhongBan(int idTrungTam);
        public abstract DataTable GetAllPhongBanByParentId(int idTrungTam, int parentId);
        public abstract DataTable GetAllPhongBan(int idTrungTam, int idTruongPhong);
        public abstract DataTable GetAllMaNhomCongViec(int idTrungTam);
        
        public abstract void UpdateKeHoachThangBoPhanHoTro(int idDotDanhGia, int idCongViec, int idBoPhanHoTro);
        public abstract void DeleteKeHoachThangBoPhanHoTro(int idDotDanhGia, int idCongViec, int idBoPhanHoTro);
        public abstract DataTable GetKeHoachThangBoPhanHoTro(int idDotDanhGia, int idCongViec);

        #endregion

        #region Quan ly cong viec KPI

        public abstract DataTable GetAllCongViecKPI(int idTrungTam);
        public abstract DataTable GetAllCongViecKPI(int idTrungTam, int idPhongBan, int loai);        

        public abstract DataTable GetAllByParentID(int parentId, int idTrungTam, int idPhongBan);
        public abstract void DeleteCongViecKPI(int _id);
        public abstract int InsertCongViecKPI(QuanLyCongViecKPIInfo _QuanLyCongViecKPIInfo);
        public abstract void UpdateCongViecKPI(QuanLyCongViecKPIInfo _QuanLyCongViecKPIInfo);
        public abstract QuanLyCongViecKPIInfo GetInfoCongViecKPI(int _id);
        public abstract void SetPriority(int _id, int order);
        public abstract void UpdateCongViecChoNhanVien(int idNhanVien, int idCongViec, int idDotDanhGia, int idTrungTam, int idPhongBan, double tytrong, double sogio);
        public abstract void RemoveCongViecGiaoChoNhanVien(int idNhanVien, int idCongViec, int idDotDanhGia, int idTrungTam, int idPhongBan);
        public abstract DataTable GetAllCongViecGiaoChoNhanVien(int idNhanVien);

        public abstract DataSet GetPTDG(int idNhanVien, int idPhongBan);
        public abstract DataSet GetPTDG(int idNhanVien, int idPhongBan, int idDotDanhGia, int idTrungTam);


        public abstract DataTable GetTyTrongCongViec(int idCongViecKPI, int idDotDanhGia, int idTrungTam);
        public abstract DataTable GetTyTrongCongViec(int idCongViecKPI, int idDotDanhGia, int idTrungTam, int idPhongBan, int userId);
        
        public abstract DataTable GetTyTrongHoanThanhCongViec(int idCongViecKPI, int idDotDanhGia, int idBoPhan);        

        public abstract DataTable GetTongTyTrongCacCongViecCon(int idCongViecKPI);
        public abstract DataTable GetTongTLHTCacCongViecCon(int idCongViecKPI, int idDotDanhGia, int idBoPhan);
        public abstract DataTable GetTongTLHTCacCongViecConNew(int idCongViecKPI, int idDotDanhGia, int idBoPhan);
        public abstract DataTable QuanLyCongViecKPI_GetTBPDanhGiaLaiCacCongViecCon(int idCongViecKPI, int idDotDanhGia, int idBoPhan);
        public abstract DataTable QuanLyCongViecKPI_GetTBPDanhGiaLaiCacCongViecConNew(int idCongViecKPI, int idDotDanhGia, int idBoPhan);
        
        public abstract DataSet DotDanhGia_GetTyTrongCVDuocGiao(int idNhanVien, int idDotDanhGia);

        public abstract DataTable GetAllNhanVienTheoCongViec(int idCongViec, int idDotDanhGia);
        public abstract DataSet GetAllNhanVienTheoIDCongViec(int idTrungTam, int idCongViec, int idDotDanhGia);
        public abstract DataSet GetCongViecDeCapNhatTyTrong(int idDotDanhGia, int idBoPhan);
        public abstract DataSet GetCongViecDeCapNhatTyTrongNew(int idDotDanhGia, int idBoPhan);
        public abstract DataTable GetMaxLevel(int idDotDanhGia, int idBoPhan);
        
        public abstract DataTable QuanLyCongViecKPI_GetCongViecByType(int idDotDanhGia, int idBoPhan, int loai);
        
        public abstract DataSet QuanLyCongViecKPI_GetTTCVCuaMotCongViecBatKy(int idTrungTam, int idCongViec);
     
        

        #endregion

        #region DanhGiaThang BoPhan

        public abstract DataTable GetAllDanhGiaThang_BoPhanTTCV(int loai, int IDDotDanhGia, int IDBoPhan);
        public abstract DataTable GetAllDanhGiaThang_BoPhanTTCVNew(int loai, int IDDotDanhGia, int IDBoPhan);


        public abstract DataTable GetMaNhomCongViec(int idCongViec);
        public abstract DataTable GetNguoiThamGiaCongViec(int idDotDanhGia, int idCongViec);
        public abstract DataTable GetNguoiThamGiaCongViecKTXVaPS(int idDotDanhGia, int idCongViec);

        public abstract void DeleteDanhGiaThang_BoPhanTTCV(int _id);
        public abstract void DeleteDanhGiaThang_BoPhanTTCVNew(int _id);
        public abstract int InsertDanhGiaThang_BoPhanTTCV(DanhGiaThang_BoPhanTTCVInfo _DotDanhGiaInfo);
        public abstract void UpdateDanhGiaThang_BoPhanTTCV(DanhGiaThang_BoPhanTTCVInfo _DotDanhGiaInfo);
        public abstract DanhGiaThang_BoPhanTTCVInfo GetInfoDanhGiaThang_BoPhanTTCV(int _id);

        public abstract DataSet DanhGiaThang_BoPhan_TongDiem(int idDotDanhGia, int IDBoPhan, int loai);
        public abstract DataSet DanhGiaThang_BoPhan_TongDiemNew(int idDotDanhGia, int IDBoPhan, int loai);
        
        public abstract void GuiDanhGiaThangBoPhan(int idDotDanhGia, int IDBoPhan, int status);

        public abstract int InsertKeHoachThang_BoPhanTTCV(DanhGiaThang_BoPhanTTCVInfo _DotDanhGiaInfo);
        public abstract int InsertKeHoachThang_BoPhanTTCV_New(DanhGiaThang_BoPhanTTCVInfo _DotDanhGiaInfo);
        public abstract void UpdateKeHoachThang_BoPhanTTCV(DanhGiaThang_BoPhanTTCVInfo _DotDanhGiaInfo);
        public abstract void UpdateKeHoachThangCOODanhGia(DanhGiaThang_BoPhanTTCVInfo _DotDanhGiaInfo);
        public abstract void UpdateKeHoachThangCOODanhGiaNew(DanhGiaThang_BoPhanTTCVInfo _DotDanhGiaInfo);
        
        public abstract void DanhGiaThang_UpdateDanhGiaBoPhanTDvaKL(DGBoPhanTDvaKLInfo _DotDanhGiaInfo);
        public abstract DGBoPhanTDvaKLInfo DanhGiaThang_GetInfoDanhGiaBoPhanTDvaKL(int _idDotDanhGia, int idBoPhan, int _loai);
        public abstract void DanhGiaThang_UpdateDanhGiaBoPhanChiTiet(DanhGiaBoPhanChiTietInfo _DGCBCNVDanhGiaChiTietInfo);
        public abstract DataTable DanhGiaThang_GetAllDanhGiaBoPhanChiTiet(int loai, int IDDotDanhGiaVaBoPhan, int idBoPhan);
        public abstract void DanhGiaThang_UpdateXepLoaiBoPhan(int idDotDanhGian, int idTrungTam, int xepLoai, double tongdiem);

        public abstract DataSet GetAllKeHoachThangCuaPhong_BoPhanTTCV(int loai, int IDDotDanhGia, int IDBoPhan, int IDPhong);
        public abstract DataSet GetAllKeHoachThangCuaPhong_BoPhanTTCV_New(int loai, int IDDotDanhGia, int IDBoPhan, int IDPhong);
        public abstract DataSet GetAllKeHoachThangCuaPhong_BoPhanTTCV_ForExport(int loai, int IDDotDanhGia, int IDBoPhan, int IDPhong);
        public abstract DataTable KeHoachThang_GetCongViecCuaBoPhan_GetAll(int IDBoPhan, int IDDotDanhGia);
        public abstract DataTable KeHoachThang_GetCongViecCuaBoPhan_GetAll_New(int IDBoPhan, int IDDotDanhGia);
        public abstract DataTable DanhGiaThang_GetCongViecCuaBoPhan_GetAll(int IDBoPhan, int IDDotDanhGia);
        public abstract DataTable DanhGiaThang_GetCongViecCuaBoPhan_GetAllNew(int IDBoPhan, int IDDotDanhGia);
        public abstract void DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGia(int idCongViec, int idDotDanhGia, double TBPDanhGia);
        public abstract void DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGiaNew(int idCongViec, int idDotDanhGia, double TBPDanhGia);
        public abstract void DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGiaLai(int idCongViec, int idDotDanhGia, double TBPDanhGia);
        public abstract void DanhGiaThang_BoPhanTTCV_UpdateTBPDanhGiaLaiNew(int idCongViec, int idDotDanhGia, double TBPDanhGia, double TyTrongCV);
        
        public abstract DataTable GetTrangThaiNhanVien(int idDotDanhGia, int idNhanVien, int idTrungTam, int idPhongBan);
        public abstract void UpdateTrangThaiNhanVien(int idDotDanhGia, int idNhanVien, int trangthai, int idTrungTam, int idPhongBan);

        public abstract DataTable GetAllTruongBoPhan();
        public abstract DataTable GetAllNhanVienCapTBP_TP_PP( int idTrungTam);

        public abstract void UpdateTyTrongCongViecNhanVienV2(int id, double tytrong, double sogio);

        #endregion

        #region Dinh Nghia

        public abstract DataTable GetAllDinhNghia(string type);
        public abstract void DeleteDinhNghia(int _id);
        public abstract int InsertDinhNghia(DinhNghiaInfo _DinhNghiaInfo);
        public abstract void UpdateDinhNghia(DinhNghiaInfo _DinhNghiaInfo);
        public abstract DinhNghiaInfo GetInfoDinhNghia(int _id);

        #endregion

        #region Phong Ban


        public abstract DataTable GetAllNhomCongViec(int idTrungTam);
        public abstract DataTable GetAllPhong(int idTrungTam);
        public abstract DataTable GetAllByParentID(int parentId, int idTrungTam);
        public abstract void DeletePhong(int _id);
        public abstract void DeleteNhomCongViec(int _id);
        
        public abstract int InsertPhong(PhongBanInfo _PhongBanInfo);
        public abstract void UpdatePhong(PhongBanInfo _PhongBanInfo);

        public abstract int InsertNhomCongViec(NhomCongViecInfo _PhongBanInfo);
        public abstract void UpdateNhomCongViec(NhomCongViecInfo _PhongBanInfo);

        public abstract NhomCongViecInfo GetInfoNhomCongViec(int _id);
        public abstract PhongBanInfo GetInfoPhong(int _id);

        #endregion

        #region Quan ly cong viec KTX va PS

        public abstract DataTable GetAllCongViecKTXVaPS(int idTrungTam, int loai);
        public abstract DataTable GetAllByParentIDKTXVaPS(int parentId, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia);

        public abstract DataTable GetAllByParentIDKTXVaPSNew(int parentId, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia);

        public abstract void DeleteCongViecKTXVaPS(int _id);
        public abstract void DeleteCongViecKTXVaPS(int _id, int idDotDanhGia);
        public abstract void DeleteAll(int idTrungTam, int loai, int idDotDanhGia);
        public abstract DataTable KeHoachThang_BaoCaoNgayByCongViecTT(int idCongViec, int idDotDanhGia, DateTime ngay);
        public abstract DataTable KeHoachThang_GetCongViecCamKetHT(int idCongViec, int idDotDanhGia);
        public abstract DataTable KeHoachThang_BaoCaoNgayByCongViecTK(int idCongViec, int idDotDanhGia, DateTime ngay);
        public abstract int InsertCongViecKTXVaPS(QuanLyCongViecKTXVaPSInfo _QuanLyCongViecKPIInfo);
        public abstract int InsertCongViecKTXVaPS_6_11_2014(QuanLyCongViecKTXVaPSInfo _QuanLyCongViecKPIInfo);
        

        public abstract void UpdateCongViecKTXVaPS(QuanLyCongViecKTXVaPSInfo _QuanLyCongViecKPIInfo);
        public abstract QuanLyCongViecKTXVaPSInfo GetInfoCongViecKTXVaPS(int _id);
        public abstract QuanLyCongViecKTXVaPSInfo GetInfoCongViecKTXVaPSByOldID(int _id);
        

        public abstract void SetPriorityKTXVaPS(int _id, int order);
        public abstract void UpdateCongViecChoNhanVienKTXVaPS(int idNhanVien, int idCongViec);
        public abstract void RemoveCongViecGiaoChoNhanVienKTXVaPS(int idNhanVien, int idCongViec);
        public abstract DataTable GetAllCongViecGiaoChoNhanVienKTXVaPS(int idNhanVien, int loai, int idDotDanhGia, int idDotDanhGiaNew);
        public abstract DataTable GetAllCongViecGiaoChoNhanVienCoOldID(int idNhanVien, int loai, int idDotDanhGia, int idDotDanhGiaNew);
        
        public abstract DataTable GetAllCongViecGiaoChoNhanVienKTXVaPS(int idNhanVien, int loai, int idDotDanhGia);
        public abstract DataTable GetAllCongViecGiaoChoNhanVienKTXVaPS_6_11_2014(int idNhanVien, int loai, int idDotDanhGia);
        
        public abstract DataTable GetAllCongViecGiaoChoNhanVienTheoNgay(int idNhanVien, int idDotDanhGia);
        
        public abstract DataTable CheckNhanVienDaChuyen(int idNhanVien, int idDotDanhGia, int idTrungTam, int idPhongBan);
        
        public abstract DataTable GetTyTrongCongViecKTXVaPS(int idCongViecKPI);
        public abstract DataTable GetTongTyTrongCacCongViecConKTXVaPS(int idCongViecKPI);
        public abstract void UpdateCapDoCongViec(int idCongViec, int level);
        public abstract void UpdateTyTrong(int idCongViec, int soGio, int idTrungTam);  
        
        #endregion

        public abstract DataTable TestGetKPIFromOldDB();
        public abstract void UpdateTest(int id, string kehoach);
        public abstract DataTable GetUserInfo(int id);

        #region Bao cao ngay

        public abstract DataTable GetAllByUserIDBaoCaoNgay(int idTrungTam, int idPhongBan, DateTime dtTime, int idDotDanhGia, int UserID);
        public abstract DataTable GetAllByParentIDBaoCaoNgay(int parentId, int idTrungTam, int idPhongBan, DateTime dtTime, int idDotDanhGia, int UserID);
        public abstract DataTable GetTongTyTrongCacCongViecConBaoCaoNgay(int idCongViecKPI);
        public abstract DataTable GetAllBaoCaoNgay(int idTrungTam, DateTime dt, int userId, int userQL, int idDotDanhGia);
        public abstract DataTable GetAllBaoCaoNgayBoPhan(int idTrungTam, int idPhongBan, DateTime dt, int idDotDanhGia, int userId);
        public abstract DataTable GetAllBaoCaoNgayPhongBan(int idTrungTam, int idPhongBan, DateTime dt, int idDotDanhGia, int userId, int status);
        
        #endregion

        public abstract void ClearAllCongViecTheoBoPhanVaDotDanhGia(int idDotDanhGia, int idTrungTam, int loai);

        public abstract DataTable GetAllBoPhanTheoLoai(int loai);

        public abstract QuanLyCongViecKTXVaPSInfo GetInfoCongViecKTXVaPSByTen(string tencongviec, int idDotDanhGia, int idTrungTam, int Loai);


        public abstract DataTable GetAllCongViecDenHanDeadline(int idDotDanhGia, int idTrungTam);
        public abstract DataTable GetAllCongViecQuaHanDeadline(int idDotDanhGia, int idTrungTam); 
        public abstract DataTable GetAllCongViecTrongTuan(int idDotDanhGia, int idTrungTam, int tuan);
        public abstract DataTable GetAllNhanVienInByNhanVienQuanLy(int idNhanVienQuanLy, int idTrungTam);

        public abstract DataTable QuanLyNhanVienTheoNDG_GetAllNhanVien(int idNhanVienQuanLy, int idTrungTam, int idDotDanhGia);
        public abstract DataTable QuanLyNhanVienTheoNDG_ByNhanVienQuanLy(int idNhanVienQuanLy, int idDotDanhGia, int idTrungTam);

        public abstract DataTable GetAllNhanVienTheoQLVaDotDanhGia(int idDotDanhGia, int idTrungTam);
        public abstract void DeleteRecursive(int id);
        
    }
}
