using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VmgPortal.Modules.KPIData.Library
{
    public class Constants
    {
        public enum ChucVu
        {
            NhanVien = 2,
            TruongPhong = 1,
            TruongBoPhan = 3,
            PhoGiamDoc = 4,
        }
        public enum Role
        {
            NhanVien = 4,
            NhanVienKD = 15,
            TruongPhong = 8,
            PhoPhong = 12,
            TruongNhom = 13,
            TruongBoPhanKhoiHoTro = 5,
            TruongBoPhanKhoiKinhDoanh = 9,
            TruongBoPhan = 0,
            TruongBoPhanTheoTrungTam = 1,
            CEO = 6,
            COO = 10,
            PhoGiamDoc = 11,
        }

        public enum TrangThaiDanhGia
        {
            LapKeHoach = -1,
            DangDanhGia = 0,
            DaGuiChoPhuTrachDanhGia = 1,
            PhuTrachDanhGiaGuiLai = 2,
            DongYVoiKetQuaDanhGia = 3,
            GuiTruongBoPhanPheDuyet = 4,
            ThongNhat = 5,
        }

        public enum TrangThaiDanhGiaNhanVien
        {
            LapKeHoach = 0,
            DaGuiKeHoachChoTruongPhong = 1,
            DaGuiKeHoachChoTBP = 2,
            DangDanhGia = 3,
            DaGuiDanhGiaChoTruongPhong = 4,
            DaGuiDanhGiaChoTruongBoPhan = 5,
            TruongPhongGuiLaiDanhGiaChoNhanVien = 6,
            TruongBoPhanGuiLaiDanhGiaChoNhanVien = 7,
            NhanVienDongYVoiKetQuaDanhGia = 8,            
            ThongNhat = 9,
        }
    }
}