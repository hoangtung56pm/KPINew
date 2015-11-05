using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VmgPortal.Modules.KPIData.Library.Providers;
using System.Data;
using System.Web.UI.WebControls;
using VmgPortal.Library.Utilities;

namespace VmgPortal.Modules.KPIData.Library.DotDanhGia
{
    public class DotDanhGiaController
    {
        public static DataTable GetAllMucDoanhThuLoiNhuan()
        {
            return DataAccessProvider.Instance().GetAllMucDoanhThuLoiNhuan();
        }

        public static void UpdateDoanhThuLoiNhuan(DotDanhGiaConfigInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().UpdateDoanhThuLoiNhuan(_DotDanhGiaInfo);
        }

        public static void UpdateTLHTCongViec(DotDanhGiaTLHTCVInfo _DotDanhGiaTLHTCVInfo)
        {
            DataAccessProvider.Instance().UpdateTLHTCongViec(_DotDanhGiaTLHTCVInfo);
        }

        public static void UpdateDanhGiaCheo(DotDanhGiaDanhGiaCheoInfo _DotDanhGiaTLHTCVInfo)
        {
            DataAccessProvider.Instance().UpdateDanhGiaCheo(_DotDanhGiaTLHTCVInfo);
        }

        public static DotDanhGiaConfigInfo GetInfoDotDanhGiaConfig(int _id, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetInfoDotDanhGiaConfig(_id, idTrungTam);
        }

        public static DotDanhGiaTLHTCVInfo GetInfoTLHTCongViec(int _id, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetInfoTLHTCongViec(_id, idTrungTam);
        }

        public static DotDanhGiaDanhGiaCheoInfo GetInfoDanhGiaCheo(int _id, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetInfoDanhGiaCheo(_id, idTrungTam);
        }

        public static DataTable GetAll()
        {
            return DataAccessProvider.Instance().GetAllDotDanhGia();
        }

        public static DataTable GetAll(int type)
        {
            return DataAccessProvider.Instance().GetAllDotDanhGia(type);
        }

        public static void Delete(int _id)
        {
            DataAccessProvider.Instance().DeleteDotDanhGia(_id);
        }

        public static DataTable GetDaultDotDanhGia()
        {
            return DataAccessProvider.Instance().GetDaultDotDanhGia();
        }

        public static DataTable GetDaultDotDanhGiaCheckPoint()
        {
            return DataAccessProvider.Instance().GetDaultDotDanhGiaCheckPoint();
        }
        public static int Insert(DotDanhGiaInfo _DotDanhGiaInfo)
        {
            return DataAccessProvider.Instance().InsertDotDanhGia(_DotDanhGiaInfo);
        }

        public static void Update(DotDanhGiaInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().UpdateDotDanhGia(_DotDanhGiaInfo);
        }

        public static DotDanhGiaInfo GetInfo(int _id)
        {
            return DataAccessProvider.Instance().GetInfoDotDanhGia(_id);
        }
               
        public static void UpdateNhanVienVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam, int idNhom)
        {
            DataAccessProvider.Instance().UpdateNhanVienVaoDotDanhGia(idDotDanhGia, idNhanVien, idTrungTam, idNhom);
        }

        public static void UpdateNhanVienVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam, int idNhom, int nguoiDG)
        {
            DataAccessProvider.Instance().UpdateNhanVienVaoDotDanhGia(idDotDanhGia, idNhanVien, idTrungTam, idNhom, nguoiDG);
        }

        public static void UpdateNhanVienVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam, int idNhom, int nguoiDG, int trangthai)
        {
            DataAccessProvider.Instance().UpdateNhanVienVaoDotDanhGia(idDotDanhGia, idNhanVien, idTrungTam, idNhom, nguoiDG, trangthai);
        }

        public static void RemoveNhanVienVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam)
        {
            DataAccessProvider.Instance().RemoveNhanVienVaoDotDanhGia(idDotDanhGia, idNhanVien, idTrungTam);

        }

        public static void RemoveNhanVienVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam, int idNguoiDG)
        {
            DataAccessProvider.Instance().RemoveNhanVienVaoDotDanhGia(idDotDanhGia, idNhanVien, idTrungTam, idNguoiDG);
        }

        public static void UpdateNhanVienTheoNDG(int idNhanVien, int idTrungTam, int nguoiDG, int idDotDanhGia)
        {
            DataAccessProvider.Instance().UpdateNhanVienTheoNDG(idNhanVien, idTrungTam, nguoiDG, idDotDanhGia);
        }

        public static void RemoveNhanVienTheoNDG(int idNhanVien, int idTrungTam, int idNguoiDG, int idDotDanhGia)
        {
            DataAccessProvider.Instance().RemoveNhanVienTheoNDG(idNhanVien, idTrungTam, idNguoiDG, idDotDanhGia);
        }

        public static void UpdateTruongBoPhanVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam)
        {
            DataAccessProvider.Instance().UpdateTruongBoPhanVaoDotDanhGia(idDotDanhGia, idNhanVien, idTrungTam);
        }

        public static void RemoveTruongBoPhanVaoDotDanhGia(int idDotDanhGia, int idNhanVien, int idTrungTam)
        {
            DataAccessProvider.Instance().RemoveTruongBoPhanVaoDotDanhGia(idDotDanhGia, idNhanVien, idTrungTam);

        }
        public static DataTable GetAllNhanVienInDotDanhGia(int idDotDanhGia, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllNhanVienInDotDanhGia(idDotDanhGia, idTrungTam);
        }
        public static DataTable GetAllNhanVienInDotDanhGiaExport(int idDotDanhGia, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllNhanVienInDotDanhGiaExport(idDotDanhGia, idTrungTam);
        }
        public static DataTable GetAllNhanVienInDotDanhGiaNew(int idDotDanhGia, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllNhanVienInDotDanhGiaNew(idDotDanhGia, idTrungTam);
        }
        public static DataTable GetAllNhanVienByTrungTam(int idTrungTam, int role)
        {
            return DataAccessProvider.Instance().GetAllNhanVienByTrungTam(idTrungTam, role);
        }

        public static DataTable GetAllTruongPhongByTrungTam(int idTrungTam, int role)
        {
            return DataAccessProvider.Instance().GetAllTruongPhongByTrungTam(idTrungTam, role);
        }

        public static DataTable GetAllNhanVienNotByNhanVienQuanLy(int idDotDanhGia, int idNhanVienQuanLy, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllNhanVienNotByNhanVienQuanLy(idDotDanhGia, idNhanVienQuanLy, idTrungTam);
        }

        public static DataTable GetAllNhanVienInByNhanVienQuanLy(int idDotDanhGia, int idNhanVienQuanLy, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllNhanVienInByNhanVienQuanLy(idDotDanhGia, idNhanVienQuanLy, idTrungTam);
        }

        public static DataTable GetAllNhanVienNotByNhanVienQuanLy(int idNhanVienQuanLy, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllNhanVienNotByNhanVienQuanLy(idNhanVienQuanLy, idTrungTam);
        }

        

        public static DataTable GetAllNhanVienNotInDotDanhGia(int idDotDanhGia, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllNhanVienNotInDotDanhGia(idDotDanhGia, idTrungTam);
        }

        public static DataTable GetAllTruongPhongNotInDotDanhGia(int idDotDanhGia, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllTruongPhongNotInDotDanhGia(idDotDanhGia, idTrungTam);
        }

        public static DataTable GetAllTruongPhongInDotDanhGia(int idDotDanhGia, int idTrungTam, int idNhanVienQuanLy)
        {
            return DataAccessProvider.Instance().GetAllTruongPhongInDotDanhGia(idDotDanhGia, idTrungTam, idNhanVienQuanLy);
        }

        public static DataTable GetAllTruongBoPhanInDotDanhGia(int idDotDanhGia, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllTruongBoPhanInDotDanhGia(idDotDanhGia, idTrungTam);
        }

        public static DataTable GetAllTruongBoPhanNotInDotDanhGia(int idDotDanhGia, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllTruongBoPhanNotInDotDanhGia(idDotDanhGia, idTrungTam);
        }

        public static DataSet DGCBCNVDanhGia_TongDiem(int idDotDanhGia, int idNhanVien)
        {
            return DataAccessProvider.Instance().DGCBCNVDanhGia_TongDiem(idDotDanhGia, idNhanVien);
        }

        public static DataSet DGCBCNVDanhGia_TongDiemTBP(int idDotDanhGia, int idNhanVien, int idTrungTam)
        {
            return DataAccessProvider.Instance().DGCBCNVDanhGia_TongDiemTBP(idDotDanhGia, idNhanVien, idTrungTam);
        }

        public static DataSet DGCBCNVDanhGiaDongNghiep_GetAll(int idDotDanhGia, int idNhanVien, int roleId)
        {
            return DataAccessProvider.Instance().DGCBCNVDanhGiaDongNghiep_GetAll(idDotDanhGia,idNhanVien, roleId);
        }
        public static DataTable CheckPointDanhGiaDongNghiep_GetAll(int idDotDanhGia, int idNhanVien)
        {
            return DataAccessProvider.Instance().CheckPointDanhGiaDongNghiep_GetAll(idDotDanhGia, idNhanVien);
        }

        public static DataSet DGCBCNVDanhGiaDongNghiepTP_GetAll(int idDotDanhGia, int idNhanVien, int roleId)
        {
            return DataAccessProvider.Instance().DGCBCNVDanhGiaDongNghiepTP_GetAll(idDotDanhGia, idNhanVien, roleId);
        }

        public static void DGCBCNVDanhGiaDongNghiep_Update(int idDotDanhGia, int idNhanVien, int idNhanVienDuocDG, double diemDG, int loai, int capdodanhdanh)
        {
            DataAccessProvider.Instance().DGCBCNVDanhGiaDongNghiep_Update(idDotDanhGia,idNhanVien, idNhanVienDuocDG, diemDG, loai, capdodanhdanh);
        }

        public static void CheckPointDanhGiaDongNghiep_Update(int idDotDanhGia, int idNhanVien, int idNhanVienDuocDG, double diemDG, int loai, string nhanxet)
        {
            DataAccessProvider.Instance().CheckPointDanhGiaDongNghiep_Update(idDotDanhGia, idNhanVien, idNhanVienDuocDG, diemDG, loai, nhanxet);
        }

        public static void CheckPointDanhGiaDongNghiep_Delete(int idDotDanhGia, int idNhanVien, int idNhanVienDuocDG, double diemDG, int loai, string nhanxet)
        {
            DataAccessProvider.Instance().CheckPointDanhGiaDongNghiep_Delete(idDotDanhGia, idNhanVien, idNhanVienDuocDG, diemDG, loai, nhanxet);
        }
        public static DataSet DGCBCNVDanhGiaPhoiHopBoPhan_GetAll(int idDotDanhGia, int idNhanVien)
        {
            return DataAccessProvider.Instance().DGCBCNVDanhGiaPhoiHopBoPhan_GetAll(idDotDanhGia, idNhanVien);
        }

        public static DataSet DanhGiaThang_DanhGiaPhoiHopBoPhan_GetAll(int idDotDanhGia, int idBoPhan)
        {
            return DataAccessProvider.Instance().DanhGiaThang_DanhGiaPhoiHopBoPhan_GetAll(idDotDanhGia, idBoPhan);
        }

        public static void DGCBCNVDanhGiaPhoiHopBoPhan_Update(int idDotDanhGia, int idNhanVien, int idBoPhanDuocDG, double diemDG, int loai)
        {
            DataAccessProvider.Instance().DGCBCNVDanhGiaPhoiHopBoPhan_Update(idDotDanhGia,idNhanVien, idBoPhanDuocDG, diemDG, loai);

        }

        public static void DanhGiaThang_DanhGiaPhoiHopBoPhan_Update(int idDotDanhGia, int idBoPhan, int idBoPhanDuocDG, double diemDG, int loai, string ghichu)
        {
            DataAccessProvider.Instance().DanhGiaThang_DanhGiaPhoiHopBoPhan_Update(idDotDanhGia, idBoPhan, idBoPhanDuocDG, diemDG, loai, ghichu);

        }

        public static DataTable checkDanhGiaNam(int idDotDanhGia, int idNhanVien)
        {
            return DataAccessProvider.Instance().checkDanhGiaNam(idDotDanhGia, idNhanVien);

        }
        public static DataTable checkDanhGiaThang(int idDotDanhGia, int idNhanVien)
        {
            return DataAccessProvider.Instance().checkDanhGiaThang(idDotDanhGia, idNhanVien);

        }

        public static DataTable checkDanhGiaBoPhan(int idDotDanhGia)
        {
            return DataAccessProvider.Instance().checkDanhGiaBoPhan(idDotDanhGia);

        }

        public static DataTable checkDanhGiaBoPhan(int idDotDanhGia, int idBoPhan)
        {
            return DataAccessProvider.Instance().checkDanhGiaBoPhan(idDotDanhGia, idBoPhan);
        }

        public static DataTable checkKeHoachPhongBan(int idDotDanhGia, int idBoPhan, int idPhongBan)
        {
            return DataAccessProvider.Instance().checkKeHoachPhongBan(idDotDanhGia, idBoPhan, idPhongBan);
        }

        public static void GuiDanhGia(int idDotDanhGia, int idNhanVien, int status)
        {
            DataAccessProvider.Instance().GuiDanhGia(idDotDanhGia, idNhanVien, status);
        }
        public static void GuiDanhGiaBoPhan(int idDotDanhGia, int IDBoPhan, int status)
        {
            DataAccessProvider.Instance().GuiDanhGiaBoPhan(idDotDanhGia, IDBoPhan, status);
        }
        public static DataTable GetAllNhanVienInNhom(int idNhom, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllNhanVienInNhom(idNhom, idTrungTam);
        }

        public static DataTable GetAllNhanVienNotInNhom(int idNhom, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllNhanVienNotInNhom(idNhom, idTrungTam);
        }

        public static void UpdateNhanVienVaoNhom(int idNhanVien, int idTrungTam, int idNhom)
        {
            DataAccessProvider.Instance().UpdateNhanVienVaoNhom(idNhanVien, idTrungTam, idNhom);
        }


        public static DataTable GetAllBoPhanInDotDanhGia(int idDotDanhGia)
        {
            return DataAccessProvider.Instance().GetAllBoPhanInDotDanhGia(idDotDanhGia);
        }

        public static DataTable GetAllBoPhanNotInDotDanhGia(int idDotDanhGia)
        {
            return DataAccessProvider.Instance().GetAllBoPhanNotInDotDanhGia(idDotDanhGia);
        }

        public static void UpdateBoPhanVaoDotDanhGia(int idDotDanhGia, int idTrungTam)
        {
            DataAccessProvider.Instance().UpdateBoPhanVaoDotDanhGia(idDotDanhGia, idTrungTam);
        }

        public static void UpdateBoPhanVaoDotDanhGia(int idDotDanhGia, int idTrungTam, int trangThai)
        {
            DataAccessProvider.Instance().UpdateBoPhanVaoDotDanhGia(idDotDanhGia, idTrungTam, trangThai);
        }

        public static void RemoveBoPhanTrongDotDanhGia(int idDotDanhGia,  int idTrungTam)
        {
            DataAccessProvider.Instance().RemoveBoPhanTrongDotDanhGia(idDotDanhGia, idTrungTam);

        }

        public static DataTable DiemPhoiHopBoPhan(int idDotDanhGia, int idBoPhan)
        {
            return DataAccessProvider.Instance().DiemPhoiHopBoPhan(idDotDanhGia, idBoPhan);

        }

        public static DataSet TongDiemBoPhan(int idDotDanhGia,int idTrungTam)
        {
            return DataAccessProvider.Instance().TongDiemBoPhan(idDotDanhGia, idTrungTam);

        }

        public static void UpdateXepLoaiBoPhan(int idTrungTam, int xepLoai, int idDotDanhGia)
        {
            DataAccessProvider.Instance().UpdateXepLoaiBoPhan(idTrungTam, xepLoai, idDotDanhGia);

        }
        public static DataTable GetXepLoaiBoPhan(int idTrungTam)
        {
            return DataAccessProvider.Instance().GetXepLoaiBoPhan(idTrungTam);

        }

        public static DataSet DanhGiaThang_DGCBCNVDanhGia_TongDiem(int idDotDanhGia, int idNhanVien)
        {
            return DataAccessProvider.Instance().DanhGiaThang_DGCBCNVDanhGia_TongDiem(idDotDanhGia, idNhanVien);
        }

        public static DataSet DanhGiaThang_DGCBCNVDanhGia_TongDiemCongThucMoi(int idDotDanhGia, int idNhanVien)
        {
            return DataAccessProvider.Instance().DanhGiaThang_DGCBCNVDanhGia_TongDiemCongThucMoi(idDotDanhGia, idNhanVien);
        }

        public static DataSet DanhGiaCheckPoint_DGCBCNVDanhGia_TongDiemCongThucMoi(int idDotDanhGia, int idNhanVien)
        {
            return DataAccessProvider.Instance().DanhGiaCheckPoint_DGCBCNVDanhGia_TongDiemCongThucMoi(idDotDanhGia, idNhanVien);
        }

        public static DataTable CheckPoint_DanhGiaTDvaKL_GetDiemTB(int idDotDanhGia, int idNhanVien)
        {
            return DataAccessProvider.Instance().CheckPoint_DanhGiaTDvaKL_GetDiemTB(idDotDanhGia, idNhanVien);
        }
        public static DataTable CheckPoint_DanhGiaCongViec_GetDiemTB(int idDotDanhGia, int idNhanVien)
        {
            return DataAccessProvider.Instance().CheckPoint_DanhGiaCongViec_GetDiemTB(idDotDanhGia, idNhanVien);
        }
        public static DataTable CheckPoint_GetAllDotDanhGiaByCheckpoint(int checkPointId)
        {
            return DataAccessProvider.Instance().CheckPoint_GetAllDotDanhGiaByCheckpoint(checkPointId);
        }

        public static DataSet DanhGiaThang_BoPhan_TongDiem(int idDotDanhGia, int idBoPhan, int loai)
        {
            return DataAccessProvider.Instance().DanhGiaThang_BoPhan_TongDiem(idDotDanhGia, idBoPhan, loai);
        }

        public static DataSet DanhGiaThang_BoPhan_TongDiemNew(int idDotDanhGia, int idBoPhan, int loai)
        {
            return DataAccessProvider.Instance().DanhGiaThang_BoPhan_TongDiemNew(idDotDanhGia, idBoPhan, loai);
        }
        public static void DanhGiaThang_UpdateXepLoaiBoPhan(int idDotDanhGia, int idTrungTam, int xepLoai, double tongdiem)
        {
            DataAccessProvider.Instance().DanhGiaThang_UpdateXepLoaiBoPhan(idDotDanhGia, idTrungTam, xepLoai, tongdiem);

        }
        public static void GuiDanhGiaThang(int idDotDanhGia, int idNhanVien, int status)
        {
            DataAccessProvider.Instance().GuiDanhGiaThang(idDotDanhGia, idNhanVien, status);
        }

        public static void GuiDanhGiaThangBoPhan(int idDotDanhGia, int idBoPhan, int status)
        {
            DataAccessProvider.Instance().GuiDanhGiaThangBoPhan(idDotDanhGia, idBoPhan, status);
        }


        public static DataTable GetAllNhanVien()
        {
            return DataAccessProvider.Instance().GetAllNhanVien();
        }

        public static DataTable GetAllNhanVien(int idTrungTam, int idPhongBan)
        {
            return DataAccessProvider.Instance().GetAllNhanVien(idTrungTam, idPhongBan);
        }

        public static DataTable GetAllNhanVien(int idTrungTam, int idPhongBan, int idDotDanhGia)
        {
            return DataAccessProvider.Instance().GetAllNhanVien(idTrungTam, idPhongBan, idDotDanhGia);
        }

        public static DataTable GetAllNhanVienTemp(int idTrungTam, int idPhongBan)
        {
            return DataAccessProvider.Instance().GetAllNhanVienTemp(idTrungTam, idPhongBan);
        }

        public static DataTable GetAllPhongBan(int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllPhongBan(idTrungTam);
        }

        public static DataTable GetAllMaNhomCongViec(int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllMaNhomCongViec(idTrungTam);
        }

        public static DataTable GetAllPhongBanByParentId(int idTrungTam, int parentId)
        {
            return DataAccessProvider.Instance().GetAllPhongBanByParentId(idTrungTam, parentId);
        }
        public static DataTable GetAllPhongBan(int idTrungTam, int idTruongPhong)
        {
            return DataAccessProvider.Instance().GetAllPhongBan(idTrungTam, idTruongPhong);

        }
        public static void LoadPhongBan(ListItemCollection lstItems, int idTrungTam, int idTruongPhong)
        {
            DataTable dtZones = GetAllPhongBan(idTrungTam, idTruongPhong);
            foreach (DataRow row in dtZones.Rows)
            {
                ListItem item = new ListItem(row["Ten"].ToString(), row["ID"].ToString());
                lstItems.Add(item);
                LoadForCurItem(lstItems, item, idTrungTam, idTruongPhong);
            }
        }

        public static void LoadForCurItem(ListItemCollection lstItems, ListItem curItem, int idTrungTam, int idTruongPhong)
        {
            int curId = ConvertUtility.ToInt32(curItem.Value);
            int level = ConvertUtility.ToInt32(curItem.Attributes["Level"]);
            level++;
            DataTable dtChildZones = GetAllPhongBanByParentId(idTrungTam, curId);
            if (dtChildZones == null) return;
            foreach (DataRow row in dtChildZones.Rows)
            {
                ListItem item = new ListItem(MiscUtility.StringIndent(level) + row["Ten"].ToString(), row["ID"].ToString());
                item.Attributes.Add("Level", level.ToString());
                lstItems.Add(item);
                LoadForCurItem(lstItems, item, idTrungTam, idTruongPhong);
            }
        }

        public static void LoadPhongBan(ListItemCollection lstItems, int idTrungTam)
        {
            DataTable dtZones = GetAllPhongBanByParentId(idTrungTam,0);
            foreach (DataRow row in dtZones.Rows)
            {
                ListItem item = new ListItem(row["Ten"].ToString(), row["ID"].ToString());
                lstItems.Add(item);
                LoadForCurItem(lstItems, item, idTrungTam);
            }
        }

        public static void LoadForCurItem(ListItemCollection lstItems, ListItem curItem, int idTrungTam)
        {
            int curId = ConvertUtility.ToInt32(curItem.Value);
            int level = ConvertUtility.ToInt32(curItem.Attributes["Level"]);
            level++;
            DataTable dtChildZones = GetAllPhongBanByParentId(idTrungTam, curId); 
            if (dtChildZones == null) return;
            foreach (DataRow row in dtChildZones.Rows)
            {
                ListItem item = new ListItem(MiscUtility.StringIndent(level) + row["Ten"].ToString(), row["ID"].ToString());
                item.Attributes.Add("Level", level.ToString());
                lstItems.Add(item);
                LoadForCurItem(lstItems, item, idTrungTam);
            }
        }

        public static void UpdateCongViecChoNhanVien(int idNhanVien, int idCongViec, int idDotDanhGia, int idTrungTam, int idPhongBan, double tytrong, double sogio)
        {
            DataAccessProvider.Instance().UpdateCongViecChoNhanVien(idNhanVien, idCongViec, idDotDanhGia, idTrungTam, idPhongBan, tytrong, sogio);
        }

        public static void RemoveCongViecGiaoChoNhanVien(int idNhanVien, int idCongViec, int idDotDanhGia, int idTrungTam, int idPhongBan)
        {
            DataAccessProvider.Instance().RemoveCongViecGiaoChoNhanVien(idNhanVien, idCongViec, idDotDanhGia, idTrungTam, idPhongBan);
        }

        public static DataTable GetAllCongViecGiaoChoNhanVien(int idNhanVien)
        {
            return DataAccessProvider.Instance().GetAllCongViecGiaoChoNhanVien(idNhanVien);
        }

        public static DataTable GetAllCongViecGiaoChoNhanVienKTXVaPS(int idNhanVien, int loai, int idDotDanhGia)
        {
            return DataAccessProvider.Instance().GetAllCongViecGiaoChoNhanVienKTXVaPS(idNhanVien, loai, idDotDanhGia);
        }
        public static DataTable GetAllCongViecGiaoChoNhanVienKTXVaPS_6_11_2014(int idNhanVien, int loai, int idDotDanhGia)
        {
            return DataAccessProvider.Instance().GetAllCongViecGiaoChoNhanVienKTXVaPS_6_11_2014(idNhanVien, loai, idDotDanhGia);
        }

        public static DataTable GetAllCongViecGiaoChoNhanVienTheoNgay(int idNhanVien, int idDotDanhGia)
        {
            return DataAccessProvider.Instance().GetAllCongViecGiaoChoNhanVienTheoNgay(idNhanVien, idDotDanhGia);
        }
        
        public static DataTable GetAllCongViecGiaoChoNhanVienKTXVaPS(int idNhanVien, int loai, int idDotDanhGia, int idDotDanhGiaNew)
        {
            return DataAccessProvider.Instance().GetAllCongViecGiaoChoNhanVienKTXVaPS(idNhanVien, loai, idDotDanhGia, idDotDanhGiaNew);
        }

        public static DataTable GetAllCongViecGiaoChoNhanVienCoOldID(int idNhanVien, int loai, int idDotDanhGia, int idDotDanhGiaNew)
        {
            return DataAccessProvider.Instance().GetAllCongViecGiaoChoNhanVienCoOldID(idNhanVien, loai, idDotDanhGia, idDotDanhGiaNew);
        }

        public static DataTable CheckNhanVienDaChuyen(int idNhanVien, int idDotDanhGia, int idTrungTam, int idPhongBan)
        {
            return DataAccessProvider.Instance().CheckNhanVienDaChuyen(idNhanVien, idDotDanhGia, idTrungTam, idPhongBan);
        }
        //public static DataTable GetAllCongViecGiaoChoNhanVienTX(int idNhanVien)
        //{
        //    return DataAccessProvider.Instance().GetAllCongViecGiaoChoNhanVienTX(idNhanVien);
        //}

        public static DataTable GetTyTrongCongViec(int idCongViecKPI, int idDotDanhGia, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetTyTrongCongViec(idCongViecKPI, idDotDanhGia, idTrungTam);
        }

        public static DataTable GetTyTrongCongViec(int idCongViecKPI, int idDotDanhGia, int idTrungTam, int idPhongBan, int userId)
        {
            return DataAccessProvider.Instance().GetTyTrongCongViec(idCongViecKPI, idDotDanhGia, idTrungTam, idPhongBan, userId);
        }

        public static DataTable GetTyTrongHoanThanhCongViec(int idCongViecKPI, int idDotDanhGia, int idBoPhan)
        {
            return DataAccessProvider.Instance().GetTyTrongHoanThanhCongViec(idCongViecKPI, idDotDanhGia, idBoPhan);
        }

        public static DataSet GetCongViecDeCapNhatTyTrong(int idDotDanhGia, int idBoPhan)
        {
            return DataAccessProvider.Instance().GetCongViecDeCapNhatTyTrong(idDotDanhGia, idBoPhan);
        }

        public static DataSet GetCongViecDeCapNhatTyTrongNew(int idDotDanhGia, int idBoPhan)
        {
            return DataAccessProvider.Instance().GetCongViecDeCapNhatTyTrongNew(idDotDanhGia, idBoPhan);
        }

        public static DataTable GetMaxLevel(int idDotDanhGia, int idBoPhan)
        {
            return DataAccessProvider.Instance().GetMaxLevel(idDotDanhGia, idBoPhan);

        }
        public static DataTable QuanLyCongViecKPI_GetCongViecByType(int idDotDanhGia, int idBoPhan, int loai)
        {
            return DataAccessProvider.Instance().QuanLyCongViecKPI_GetCongViecByType(idDotDanhGia, idBoPhan,  loai);
        }
        

        public static DataTable GetTongTyTrongCacCongViecCon(int idCongViecKPI)
        {
            return DataAccessProvider.Instance().GetTongTyTrongCacCongViecCon(idCongViecKPI);
        }

        public static DataSet GetPTDG(int idNhanVien, int idPhongBan)
        {
            return DataAccessProvider.Instance().GetPTDG(idNhanVien, idPhongBan);
        }

        public static DataSet GetPTDG(int idNhanVien, int idPhongBan, int idDotDanhGia, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetPTDG(idNhanVien, idPhongBan, idDotDanhGia,  idTrungTam);
        }

        public static DataSet DotDanhGia_GetTyTrongCVDuocGiao(int idNhanVien, int idDotDanhGia)
        {
            return DataAccessProvider.Instance().DotDanhGia_GetTyTrongCVDuocGiao(idNhanVien, idDotDanhGia);
        }

        public static DataTable GetAllNhanVienTheoCongViec(int idCongViec, int idDotDanhGia)
        {
            return DataAccessProvider.Instance().GetAllNhanVienTheoCongViec(idCongViec, idDotDanhGia);
        }

        public static DataSet GetAllNhanVienTheoIDCongViec(int idTrungTam, int idCongViec, int idDotDanhGia)
        {
            return DataAccessProvider.Instance().GetAllNhanVienTheoIDCongViec(idTrungTam, idCongViec, idDotDanhGia);
        }

        public static DataTable GetTongTLHTCacCongViecCon(int idCongViecKPI, int idDotDanhGia, int idBoPhan)
        {
            return DataAccessProvider.Instance().GetTongTLHTCacCongViecCon(idCongViecKPI, idDotDanhGia, idBoPhan);
        }

        public static DataTable GetTongTLHTCacCongViecConNew(int idCongViecKPI, int idDotDanhGia, int idBoPhan)
        {
            return DataAccessProvider.Instance().GetTongTLHTCacCongViecConNew(idCongViecKPI, idDotDanhGia, idBoPhan);
        }

        public static DataTable QuanLyCongViecKPI_GetTBPDanhGiaLaiCacCongViecCon(int idCongViecKPI, int idDotDanhGia, int idBoPhan)
        {
            return DataAccessProvider.Instance().QuanLyCongViecKPI_GetTBPDanhGiaLaiCacCongViecCon(idCongViecKPI, idDotDanhGia, idBoPhan);
        }
        public static DataTable QuanLyCongViecKPI_GetTBPDanhGiaLaiCacCongViecConNew(int idCongViecKPI, int idDotDanhGia, int idBoPhan)
        {
            return DataAccessProvider.Instance().QuanLyCongViecKPI_GetTBPDanhGiaLaiCacCongViecConNew(idCongViecKPI, idDotDanhGia, idBoPhan);
        }

        public static DataSet QuanLyCongViecKPI_GetTTCVCuaMotCongViecBatKy(int idTrungTam, int idCongViec)
        {
            return DataAccessProvider.Instance().QuanLyCongViecKPI_GetTTCVCuaMotCongViecBatKy(idTrungTam, idCongViec);
        }


        public static DataTable TestGetKPIFromOldDB()
        {
            return DataAccessProvider.Instance().TestGetKPIFromOldDB();
        }

        public static void UpdateTest(int id, string kehoach)
        {
             DataAccessProvider.Instance().UpdateTest(id, kehoach);
        }

        public static DataTable GetUserInfo(int id)
        {
            return DataAccessProvider.Instance().GetUserInfo(id);
        }

        public static DataTable GetTrangThaiNhanVien(int idDotDanhGia, int idNhanVien, int idTrungTam, int idPhongBan)
        {
            return DataAccessProvider.Instance().GetTrangThaiNhanVien(idDotDanhGia, idNhanVien, idTrungTam,  idPhongBan);
        }

        public static void UpdateTrangThaiNhanVien(int idDotDanhGia, int idNhanVien, int trangThai, int idTrungTam, int idPhongBan)
        {
            DataAccessProvider.Instance().UpdateTrangThaiNhanVien(idDotDanhGia, idNhanVien, trangThai, idTrungTam,  idPhongBan);
        }

        public static DataTable GetAllTruongBoPhan()
        {
            return DataAccessProvider.Instance().GetAllTruongBoPhan();
        }

        public static DataTable GetAllNhanVienInByNhanVienQuanLy(int idNhanVienQuanLy, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllNhanVienInByNhanVienQuanLy(idNhanVienQuanLy, idTrungTam);
        }
        
        public static DataTable QuanLyNhanVienTheoNDG_GetAllNhanVien(int idNhanVienQuanLy, int idTrungTam, int idDotDanhGia)
        {
            return DataAccessProvider.Instance().QuanLyNhanVienTheoNDG_GetAllNhanVien(idNhanVienQuanLy, idTrungTam, idDotDanhGia);
        }
        
        public static DataTable GetAllNhanVienCapTBP_TP_PP(int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllNhanVienCapTBP_TP_PP(idTrungTam);
        }


        public static void UpdateTyTrongCongViecNhanVienV2(int id, double tytrong, double sogio)
        {
            DataAccessProvider.Instance().UpdateTyTrongCongViecNhanVienV2(id, tytrong, sogio);
        }

        public static DataTable QuanLyNhanVienTheoNDG_ByNhanVienQuanLy(int idNhanVienQuanLy, int idDotDanhGia, int idTrungTam)
        {
            return DataAccessProvider.Instance().QuanLyNhanVienTheoNDG_ByNhanVienQuanLy(idNhanVienQuanLy, idDotDanhGia, idTrungTam);
        }
    }
}