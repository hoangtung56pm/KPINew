using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using VmgPortal.Modules.KPIData.Library.Providers;

namespace VmgPortal.Modules.KPIData.Library.Common
{
    public class CommonController
    {
        public static DataTable GetAllChucVu()
        {
            return DataAccessProvider.Instance().GetAllChucVu();
        }

        public static DataTable GetAllNhomTieuChiDef()
        {
            return DataAccessProvider.Instance().GetAllNhomTieuChiDef();
        }

        public static DataTable BaoCaoTienDoThucHienDanhGia(int idDotDanhGia, int idTrungTam, int chucVu, int trangthai, int idPhongBan)
        {
            return DataAccessProvider.Instance().BaoCaoTienDoThucHienDanhGia(idDotDanhGia, idTrungTam, chucVu, trangthai, idPhongBan);
        }

        public static DataSet BaoCaoKetQuaDiemPhoiHopBoPhan(int idDotDanhGia)
        {
            return DataAccessProvider.Instance().BaoCaoKetQuaDiemPhoiHopBoPhan(idDotDanhGia);
        }

        public static DataTable BaoCaoXepLoaiDanhGiaCaNhan(int idDotDanhGia, int idTrungTam, int idPhongBan, int chucVu, int xeploai)
        {
            return DataAccessProvider.Instance().BaoCaoXepLoaiDanhGiaCaNhan(idDotDanhGia, idTrungTam, idPhongBan, chucVu, xeploai);
        }

        public static DataTable BaoCaoTongHopXepLoaiNhanVien(int idDotDanhGia, int idTrungTam)
        {
            return DataAccessProvider.Instance().BaoCaoTongHopXepLoaiNhanVien(idDotDanhGia, idTrungTam);
        }

        public static DataTable BaoCaoXepLoaiDanhGiaCaNhanThang(int idDotDanhGia, int idTrungTam, int idPhongBan, int chucVu, int xeploai)
        {
            return DataAccessProvider.Instance().BaoCaoXepLoaiDanhGiaCaNhanThang(idDotDanhGia, idTrungTam, idPhongBan, chucVu, xeploai);
        }
        public static DataTable BaoCaoXepLoaiDanhGiaCaNhanThang(int idDotDanhGia, int idTrungTam, int idPhongBan, int chucVu, int xeploai, int idNguoiDanhGia)
        {
            return DataAccessProvider.Instance().BaoCaoXepLoaiDanhGiaCaNhanThang(idDotDanhGia, idTrungTam, idPhongBan, chucVu, xeploai, idNguoiDanhGia);
        }

        public static DataTable BaoCaoTienDoThucHienDanhGiaThang(int idDotDanhGia, int idTrungTam, int chucVu, int trangthai, int idPhongBan)
        {
            return DataAccessProvider.Instance().BaoCaoTienDoThucHienDanhGiaThang(idDotDanhGia, idTrungTam, chucVu, trangthai, idPhongBan);
        }

        public static DataTable BaoCaoTienDoThucHienDanhGiaThang(int idDotDanhGia, int idTrungTam, int chucVu, int trangthai, int idPhongBan, int idNguoiDanhGia)
        {
            return DataAccessProvider.Instance().BaoCaoTienDoThucHienDanhGiaThang(idDotDanhGia, idTrungTam, chucVu, trangthai, idPhongBan, idNguoiDanhGia);
        }

        public static DataSet BaoCaoKetQuaDiemPhoiHopBoPhanThang(int idDotDanhGia)
        {
            return DataAccessProvider.Instance().BaoCaoKetQuaDiemPhoiHopBoPhanThang(idDotDanhGia);
        }

        public static DataSet BaoCaoKetQuaXepLoaiNhanVienCacThang(string idDotDanhGia, int idNhanVien)
        {
            return DataAccessProvider.Instance().BaoCaoKetQuaXepLoaiNhanVienCacThang(idDotDanhGia, idNhanVien);
        }

        public static DataSet BaoCaoKetQuaXepLoaiBoPhanCacThang(string idDotDanhGia, int idBoPhan)
        {
            return DataAccessProvider.Instance().BaoCaoKetQuaXepLoaiBoPhanCacThang(idDotDanhGia, idBoPhan);
        }

        public static DataTable BaoCaoTongHopXepLoaiBoPhan(int idDotDanhGia, int idBoPhan)
        {
            return DataAccessProvider.Instance().BaoCaoTongHopXepLoaiBoPhan(idDotDanhGia, idBoPhan);
        }

        public static DataTable GetAllBoPhanTheoLoai(int loai)
        {
            return DataAccessProvider.Instance().GetAllBoPhanTheoLoai(loai);
        }
    }
}