using System;
using System.Collections.Generic;
using System.Text;

namespace VmgPortal.Library.Components.Users
{
	public class UserInfo
	{
		private int _userID;
		public int UserID
		{
			get { return _userID; }
			set { _userID = value; }
		}

		private string _username;
		public string Username
		{
			get { return _username; }
			set { _username = value; }
		}

		private string _password;
		public string Password
		{
			get { return _password; }
			set { _password = value; }
		}

		private string _displayName;
		public string DisplayName
		{
			get { return _displayName; }
			set { _displayName = value; }
		}

		private bool _isAdmin;
		public bool IsAdmin
		{
			get { return this._isAdmin; }
			set { this._isAdmin = value; }
		}
		private bool _isSuperAdmin;
		public bool IsSuperAdmin
		{
			get { return this._isSuperAdmin; }
			set { this._isSuperAdmin = value; }
		}
        
        private string _maSo;
        public string MaSo
        {
            get { return _maSo; }
            set { _maSo = value; }
        }

        private string _hoTen;
        public string HoTen
        {
            get { return _hoTen; }
            set { _hoTen = value; }
        }

        private int _iDChucVu;
        public int IDChucVu
        {
            get { return _iDChucVu; }
            set { _iDChucVu = value; }
        }

        private int _iDTrungTam;
        public int IDTrungTam
        {
            get { return _iDTrungTam; }
            set { _iDTrungTam = value; }
        }

        private int _iDPhong;
        public int IDPhong
        {
            get { return _iDPhong; }
            set { _iDPhong = value; }
        }

        private DateTime _ngaySinh;
        public DateTime NgaySinh
        {
            get { return _ngaySinh; }
            set { _ngaySinh = value; }
        }

        private string _noiSinh;
        public string NoiSinh
        {
            get { return _noiSinh; }
            set { _noiSinh = value; }
        }

        private string _nguyenQuan;
        public string NguyenQuan
        {
            get { return _nguyenQuan; }
            set { _nguyenQuan = value; }
        }

        private string _quocTich;
        public string QuocTich
        {
            get { return _quocTich; }
            set { _quocTich = value; }
        }

        private string _danToc;
        public string DanToc
        {
            get { return _danToc; }
            set { _danToc = value; }
        }

        private string _tonGiao;
        public string TonGiao
        {
            get { return _tonGiao; }
            set { _tonGiao = value; }
        }

        private int _gioiTinh;
        public int GioiTinh
        {
            get { return _gioiTinh; }
            set { _gioiTinh = value; }
        }

        private string _diaChiThuongChu;
        public string DiaChiThuongChu
        {
            get { return _diaChiThuongChu; }
            set { _diaChiThuongChu = value; }
        }

        private string _diaChiTamChu;
        public string DiaChiTamChu
        {
            get { return _diaChiTamChu; }
            set { _diaChiTamChu = value; }
        }

        private string _soDienThoaiMobile;
        public string SoDienThoaiMobile
        {
            get { return _soDienThoaiMobile; }
            set { _soDienThoaiMobile = value; }
        }

        private string _soDienThoaiHome;
        public string SoDienThoaiHome
        {
            get { return _soDienThoaiHome; }
            set { _soDienThoaiHome = value; }
        }

        private string _emailVNG;
        public string EmailVNG
        {
            get { return _emailVNG; }
            set { _emailVNG = value; }
        }

        private string _emailCaNhan;
        public string EmailCaNhan
        {
            get { return _emailCaNhan; }
            set { _emailCaNhan = value; }
        }

        private string _cMNDSo;
        public string CMNDSo
        {
            get { return _cMNDSo; }
            set { _cMNDSo = value; }
        }

        private string _cMNDNgayCap;
        public string CMNDNgayCap
        {
            get { return _cMNDNgayCap; }
            set { _cMNDNgayCap = value; }
        }

        private string _cMNDNoiCap;
        public string CMNDNoiCap
        {
            get { return _cMNDNoiCap; }
            set { _cMNDNoiCap = value; }
        }

        private string _hoChieuSo;
        public string HoChieuSo
        {
            get { return _hoChieuSo; }
            set { _hoChieuSo = value; }
        }

        private string _hoChieuNgayCap;
        public string HoChieuNgayCap
        {
            get { return _hoChieuNgayCap; }
            set { _hoChieuNgayCap = value; }
        }

        private string _hoChieuNoiCap;
        public string HoChieuNoiCap
        {
            get { return _hoChieuNoiCap; }
            set { _hoChieuNoiCap = value; }
        }

        private string _tKNNSo;
        public string TKNNSo
        {
            get { return _tKNNSo; }
            set { _tKNNSo = value; }
        }

        private string _tKNNNganHang;
        public string TKNNNganHang
        {
            get { return _tKNNNganHang; }
            set { _tKNNNganHang = value; }
        }

        private string _tKNNChiNhanh;
        public string TKNNChiNhanh
        {
            get { return _tKNNChiNhanh; }
            set { _tKNNChiNhanh = value; }
        }

        private string _maSoThueCaNhan;
        public string MaSoThueCaNhan
        {
            get { return _maSoThueCaNhan; }
            set { _maSoThueCaNhan = value; }
        }

        private string _tTGDHoTenVoChong;
        public string TTGDHoTenVoChong
        {
            get { return _tTGDHoTenVoChong; }
            set { _tTGDHoTenVoChong = value; }
        }

        private string _tTGDNamSinhVoChong;
        public string TTGDNamSinhVoChong
        {
            get { return _tTGDNamSinhVoChong; }
            set { _tTGDNamSinhVoChong = value; }
        }

        private string _tTGDNgheNgiep;
        public string TTGDNgheNgiep
        {
            get { return _tTGDNgheNgiep; }
            set { _tTGDNgheNgiep = value; }
        }

        private string _tTGDHoTenCon;
        public string TTGDHoTenCon
        {
            get { return _tTGDHoTenCon; }
            set { _tTGDHoTenCon = value; }
        }

        private string _tTGDNamSinhCon;
        public string TTGDNamSinhCon
        {
            get { return _tTGDNamSinhCon; }
            set { _tTGDNamSinhCon = value; }
        }

        private string _tTGDGioiTinhCon;
        public string TTGDGioiTinhCon
        {
            get { return _tTGDGioiTinhCon; }
            set { _tTGDGioiTinhCon = value; }
        }

        private string _tTGDNguoiLienHe;
        public string TTGDNguoiLienHe
        {
            get { return _tTGDNguoiLienHe; }
            set { _tTGDNguoiLienHe = value; }
        }

        private string _hocVanBangCap;
        public string HocVanBangCap
        {
            get { return _hocVanBangCap; }
            set { _hocVanBangCap = value; }
        }

        private string _hocVanNoiDaoTao;
        public string HocVanNoiDaoTao
        {
            get { return _hocVanNoiDaoTao; }
            set { _hocVanNoiDaoTao = value; }
        }

        private string _hocVanChuyenNganh;
        public string HocVanChuyenNganh
        {
            get { return _hocVanChuyenNganh; }
            set { _hocVanChuyenNganh = value; }
        }

        private string _hocVanCacKhoaHocKhac;
        public string HocVanCacKhoaHocKhac
        {
            get { return _hocVanCacKhoaHocKhac; }
            set { _hocVanCacKhoaHocKhac = value; }
        }

        private string _hocVanNgoaiNgu;
        public string HocVanNgoaiNgu
        {
            get { return _hocVanNgoaiNgu; }
            set { _hocVanNgoaiNgu = value; }
        }

        private string _toChucDoanHiepHoi;
        public string ToChucDoanHiepHoi
        {
            get { return _toChucDoanHiepHoi; }
            set { _toChucDoanHiepHoi = value; }
        }

        private string _toChucNgayGiaNhap;
        public string ToChucNgayGiaNhap
        {
            get { return _toChucNgayGiaNhap; }
            set { _toChucNgayGiaNhap = value; }
        }

        private string _toChucNoiKetNap;
        public string ToChucNoiKetNap
        {
            get { return _toChucNoiKetNap; }
            set { _toChucNoiKetNap = value; }
        }

        private string _khenThuongGiaiThuong;
        public string KhenThuongGiaiThuong
        {
            get { return _khenThuongGiaiThuong; }
            set { _khenThuongGiaiThuong = value; }
        }

        private string _khenThuongToChucTrao;
        public string KhenThuongToChucTrao
        {
            get { return _khenThuongToChucTrao; }
            set { _khenThuongToChucTrao = value; }
        }

        private string _khenThuongNamTrao;
        public string KhenThuongNamTrao
        {
            get { return _khenThuongNamTrao; }
            set { _khenThuongNamTrao = value; }
        }

        private string _qTLVCongTy;
        public string QTLVCongTy
        {
            get { return _qTLVCongTy; }
            set { _qTLVCongTy = value; }
        }

        private string _qTLVChucDanh;
        public string QTLVChucDanh
        {
            get { return _qTLVChucDanh; }
            set { _qTLVChucDanh = value; }
        }

        private string _qTLVLyDoChuyenDoi;
        public string QTLVLyDoChuyenDoi
        {
            get { return _qTLVLyDoChuyenDoi; }
            set { _qTLVLyDoChuyenDoi = value; }
        }

        private string _bHXHThoiGianDong;
        public string BHXHThoiGianDong
        {
            get { return _bHXHThoiGianDong; }
            set { _bHXHThoiGianDong = value; }
        }

        private string _bHXHSoSo;
        public string BHXHSoSo
        {
            get { return _bHXHSoSo; }
            set { _bHXHSoSo = value; }
        }

        private string _bHXHGhiChu;
        public string BHXHGhiChu
        {
            get { return _bHXHGhiChu; }
            set { _bHXHGhiChu = value; }
        }

        private string _hDLDSHD;
        public string HDLDSHD
        {
            get { return _hDLDSHD; }
            set { _hDLDSHD = value; }
        }

        private string _hDLDNguoiKy;
        public string HDLDNguoiKy
        {
            get { return _hDLDNguoiKy; }
            set { _hDLDNguoiKy = value; }
        }

        private string _hDLDNgayKy;
        public string HDLDNgayKy
        {
            get { return _hDLDNgayKy; }
            set { _hDLDNgayKy = value; }
        }

        private string _hDLDNgayHieuLuc;
        public string HDLDNgayHieuLuc
        {
            get { return _hDLDNgayHieuLuc; }
            set { _hDLDNgayHieuLuc = value; }
        }

        private string _hDLDNgayHetHan;
        public string HDLDNgayHetHan
        {
            get { return _hDLDNgayHetHan; }
            set { _hDLDNgayHetHan = value; }
        }

        private string _hDLDLoaiHopDong;
        public string HDLDLoaiHopDong
        {
            get { return _hDLDLoaiHopDong; }
            set { _hDLDLoaiHopDong = value; }
        }

        private string _hDLD1NgayKyGiaHan;
        public string HDLD1NgayKyGiaHan
        {
            get { return _hDLD1NgayKyGiaHan; }
            set { _hDLD1NgayKyGiaHan = value; }
        }

        private string _hDLD1NguoiKyGiaHan;
        public string HDLD1NguoiKyGiaHan
        {
            get { return _hDLD1NguoiKyGiaHan; }
            set { _hDLD1NguoiKyGiaHan = value; }
        }

        private string _hDLD1QDSo;
        public string HDLD1QDSo
        {
            get { return _hDLD1QDSo; }
            set { _hDLD1QDSo = value; }
        }

        private string _hDLD1NgayHieuLuc;
        public string HDLD1NgayHieuLuc
        {
            get { return _hDLD1NgayHieuLuc; }
            set { _hDLD1NgayHieuLuc = value; }
        }

        private string _hDLD1NgayHetHan;
        public string HDLD1NgayHetHan
        {
            get { return _hDLD1NgayHetHan; }
            set { _hDLD1NgayHetHan = value; }
        }

        private string _hDLD1ThoiHan;
        public string HDLD1ThoiHan
        {
            get { return _hDLD1ThoiHan; }
            set { _hDLD1ThoiHan = value; }
        }

        private string _hDLD2NgayKyGiaHan;
        public string HDLD2NgayKyGiaHan
        {
            get { return _hDLD2NgayKyGiaHan; }
            set { _hDLD2NgayKyGiaHan = value; }
        }

        private string _hDLD2NguoiKyGiaHan;
        public string HDLD2NguoiKyGiaHan
        {
            get { return _hDLD2NguoiKyGiaHan; }
            set { _hDLD2NguoiKyGiaHan = value; }
        }

        private string _hDLD2QDSo;
        public string HDLD2QDSo
        {
            get { return _hDLD2QDSo; }
            set { _hDLD2QDSo = value; }
        }

        private string _hDLD2NgayHieuLuc;
        public string HDLD2NgayHieuLuc
        {
            get { return _hDLD2NgayHieuLuc; }
            set { _hDLD2NgayHieuLuc = value; }
        }

        private string _hDLD2NgayHetHan;
        public string HDLD2NgayHetHan
        {
            get { return _hDLD2NgayHetHan; }
            set { _hDLD2NgayHetHan = value; }
        }

        private string _hDLD2ThoiHan;
        public string HDLD2ThoiHan
        {
            get { return _hDLD2ThoiHan; }
            set { _hDLD2ThoiHan = value; }
        }

        private string _hDLD3NgayKyGiaHan;
        public string HDLD3NgayKyGiaHan
        {
            get { return _hDLD3NgayKyGiaHan; }
            set { _hDLD3NgayKyGiaHan = value; }
        }

        private string _hDLD3NguoiKyGiaHan;
        public string HDLD3NguoiKyGiaHan
        {
            get { return _hDLD3NguoiKyGiaHan; }
            set { _hDLD3NguoiKyGiaHan = value; }
        }

        private string _hDLD3QDSo;
        public string HDLD3QDSo
        {
            get { return _hDLD3QDSo; }
            set { _hDLD3QDSo = value; }
        }

        private string _hDLD3NgayHieuLuc;
        public string HDLD3NgayHieuLuc
        {
            get { return _hDLD3NgayHieuLuc; }
            set { _hDLD3NgayHieuLuc = value; }
        }

        private string _hDLD3NgayHetHan;
        public string HDLD3NgayHetHan
        {
            get { return _hDLD3NgayHetHan; }
            set { _hDLD3NgayHetHan = value; }
        }

        private string _hDLD3ThoiHan;
        public string HDLD3ThoiHan
        {
            get { return _hDLD3ThoiHan; }
            set { _hDLD3ThoiHan = value; }
        }

        private string _hDLD4NgayKyGiaHan;
        public string HDLD4NgayKyGiaHan
        {
            get { return _hDLD4NgayKyGiaHan; }
            set { _hDLD4NgayKyGiaHan = value; }
        }

        private string _hDLD4NguoiKyGiaHan;
        public string HDLD4NguoiKyGiaHan
        {
            get { return _hDLD4NguoiKyGiaHan; }
            set { _hDLD4NguoiKyGiaHan = value; }
        }

        private string _hDLD4QDSo;
        public string HDLD4QDSo
        {
            get { return _hDLD4QDSo; }
            set { _hDLD4QDSo = value; }
        }

        private string _hDLD4NgayHieuLuc;
        public string HDLD4NgayHieuLuc
        {
            get { return _hDLD4NgayHieuLuc; }
            set { _hDLD4NgayHieuLuc = value; }
        }

        private string _hDLD4NgayHetHan;
        public string HDLD4NgayHetHan
        {
            get { return _hDLD4NgayHetHan; }
            set { _hDLD4NgayHetHan = value; }
        }

        private string _hDLD4ThoiHan;
        public string HDLD4ThoiHan
        {
            get { return _hDLD4ThoiHan; }
            set { _hDLD4ThoiHan = value; }
        }

        private string _hDLD5NgayKyGiaHan;
        public string HDLD5NgayKyGiaHan
        {
            get { return _hDLD5NgayKyGiaHan; }
            set { _hDLD5NgayKyGiaHan = value; }
        }

        private string _hDLD5NguoiKyGiaHan;
        public string HDLD5NguoiKyGiaHan
        {
            get { return _hDLD5NguoiKyGiaHan; }
            set { _hDLD5NguoiKyGiaHan = value; }
        }

        private string _hDLD5QDSo;
        public string HDLD5QDSo
        {
            get { return _hDLD5QDSo; }
            set { _hDLD5QDSo = value; }
        }

        private string _hDLD5NgayHieuLuc;
        public string HDLD5NgayHieuLuc
        {
            get { return _hDLD5NgayHieuLuc; }
            set { _hDLD5NgayHieuLuc = value; }
        }

        private string _hDLD5NgayHetHan;
        public string HDLD5NgayHetHan
        {
            get { return _hDLD5NgayHetHan; }
            set { _hDLD5NgayHetHan = value; }
        }

        private string _hDLD5ThoiHan;
        public string HDLD5ThoiHan
        {
            get { return _hDLD5ThoiHan; }
            set { _hDLD5ThoiHan = value; }
        }

        private string _dCNSQDSo;
        public string DCNSQDSo
        {
            get { return _dCNSQDSo; }
            set { _dCNSQDSo = value; }
        }

        private string _dCNSNgay;
        public string DCNSNgay
        {
            get { return _dCNSNgay; }
            set { _dCNSNgay = value; }
        }

        private string _dCNSNgayHieuLuc;
        public string DCNSNgayHieuLuc
        {
            get { return _dCNSNgayHieuLuc; }
            set { _dCNSNgayHieuLuc = value; }
        }

        private string _dCNSChiTiet;
        public string DCNSChiTiet
        {
            get { return _dCNSChiTiet; }
            set { _dCNSChiTiet = value; }
        }

        private string _dCNSQDSo1;
        public string DCNSQDSo1
        {
            get { return _dCNSQDSo1; }
            set { _dCNSQDSo1 = value; }
        }

        private string _dCNSNgay1;
        public string DCNSNgay1
        {
            get { return _dCNSNgay1; }
            set { _dCNSNgay1 = value; }
        }

        private string _dCNSNgayHieuLuc1;
        public string DCNSNgayHieuLuc1
        {
            get { return _dCNSNgayHieuLuc1; }
            set { _dCNSNgayHieuLuc1 = value; }
        }

        private string _dCNSChiTiet1;
        public string DCNSChiTiet1
        {
            get { return _dCNSChiTiet1; }
            set { _dCNSChiTiet1 = value; }
        }

        private string _dCNSQDSo2;
        public string DCNSQDSo2
        {
            get { return _dCNSQDSo2; }
            set { _dCNSQDSo2 = value; }
        }

        private string _dCNSNgay2;
        public string DCNSNgay2
        {
            get { return _dCNSNgay2; }
            set { _dCNSNgay2 = value; }
        }

        private string _dCNSNgayHieuLuc2;
        public string DCNSNgayHieuLuc2
        {
            get { return _dCNSNgayHieuLuc2; }
            set { _dCNSNgayHieuLuc2 = value; }
        }

        private string _dCNSChiTiet2;
        public string DCNSChiTiet2
        {
            get { return _dCNSChiTiet2; }
            set { _dCNSChiTiet2 = value; }
        }

        private int _IDDotDanhGiaVaNhanVien;
        public int IDDotDanhGiaVaNhanVien
        {
            get { return _IDDotDanhGiaVaNhanVien; }
            set { _IDDotDanhGiaVaNhanVien = value; }
        }

        private int _IDDotDanhGiaVaBoPhan;
        public int IDDotDanhGiaVaBoPhan
        {
            get { return _IDDotDanhGiaVaBoPhan; }
            set { _IDDotDanhGiaVaBoPhan = value; }
        }
        
        private int _RoleID;
        public int RoleID
        {
            get { return _RoleID; }
            set { _RoleID = value; }
        }

        private int _TrangThai;
        public int TrangThai
        {
            get { return _TrangThai; }
            set { _TrangThai = value; }
        }
	}
}
