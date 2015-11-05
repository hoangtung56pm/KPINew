using System.Data;
using VmgPortal.Library.Components.Providers;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Utilities;
using System;

namespace VmgPortal.Library.Components.Users
{
	public class UserController
	{
		private const string key = "VmgPortal.Portal.User";
		public static UserInfo GetCurrentUser()
		{
			return DataAccessProvider.Instance().GetUser(AuthenticateUtility.GetUsername());
		}
		public static DataTable GetUsers()
		{
			//string param = "GetUsers";
            //DataCaching data = new DataCaching();
            DataTable dtUsers ;//= (DataTable) data.GetHashCache(key, param);
            //if (dtUsers != null) return dtUsers;
			dtUsers = DataAccessProvider.Instance().GetUsers();
			//data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtUsers);
			return dtUsers;
		}
        public static DataTable GetUsers(string roleId, int portalId)
        {
            return DataAccessProvider.Instance().GetUsers(roleId, portalId);
        }
		public static DataTable GetUsers(int roleId, int portalId, int idbophan)
		{
            //string param = "GetUsers?roleid=" + roleId + "&portalId=" + portalId;
			//DataCaching data = new DataCaching();
			DataTable dtUsers;// = (DataTable)data.GetHashCache(key, param);
			//if (dtUsers != null) return dtUsers;
            dtUsers = DataAccessProvider.Instance().GetUsers(roleId, portalId, idbophan);
			//data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtUsers);
			return dtUsers;
		}


        public static DataTable GetUsersExcludeUserName(string keyword, string searchby, string filter, int portalid, string username)
        {
            return DataAccessProvider.Instance().GetUsersExcludeUserName(keyword, searchby, filter, portalid, username);
        }
		public static DataTable GetUsers(string keyword, string searchby, string filter, int portalid, int idbophan)
		{
            return DataAccessProvider.Instance().GetUsers(keyword, searchby, filter, portalid, idbophan);
		}
        public static DataTable GetUsers(string keyword, string searchby, string filter, int portalid, int idbophan, int trangthai, int gender)
		{
            return DataAccessProvider.Instance().GetUsers(keyword, searchby, filter, portalid, idbophan, trangthai, gender);
		}

        public static DataTable GetUsersDiemSangTao(string keyword, string searchby, string filter, int portalid, int idbophan, int trangthai, int gender, int idDotDanhGia)
        {
            return DataAccessProvider.Instance().GetUsersDiemSangTao(keyword, searchby, filter, portalid, idbophan, trangthai, gender, idDotDanhGia);
        }
        
        public static DataTable GetUsersByNguoiDanhGia(string keyword, string searchby, string filter, int portalid, int idNguoiDanhGia, int idTrungTam, int idDotDanhGia, int roleNguoiDanhGia, int roleNhanVien)
		{
            return DataAccessProvider.Instance().GetUsersByNguoiDanhGia(keyword, searchby, filter, portalid,  idNguoiDanhGia, idTrungTam, idDotDanhGia, roleNguoiDanhGia, roleNhanVien);
		}

        public static DataTable GetUsersByNguoiDanhGiaTheoThang(string keyword, string searchby, string filter, int idNguoiDanhGia, int idTrungTam, int idDotDanhGia, int roleNguoiDanhGia, int roleNhanVien)
        {
            return DataAccessProvider.Instance().GetUsersByNguoiDanhGiaTheoThang(keyword, searchby, filter, idNguoiDanhGia, idTrungTam, idDotDanhGia, roleNguoiDanhGia, roleNhanVien);
        }

        public static DataTable GetUsersLapKeHoachByNguoiDanhGiaTheoThang(string keyword, string searchby, string filter, int idNguoiDanhGia, int idTrungTam, int idDotDanhGia, int roleNguoiDanhGia, int roleNhanVien)
        {
            return DataAccessProvider.Instance().GetUsersLapKeHoachByNguoiDanhGiaTheoThang(keyword, searchby, filter, idNguoiDanhGia, idTrungTam, idDotDanhGia, roleNguoiDanhGia, roleNhanVien);
        }        

        public static DataTable GetUsersTruongBoPhan(string keyword, string searchby, string filter)
        {
            return DataAccessProvider.Instance().GetUsersTruongBoPhan(keyword, searchby, filter);
        }

        public static DataTable GetUsersTruongBoPhan(string keyword, string searchby, string filter, int idDotDanhGia)
        {
            return DataAccessProvider.Instance().GetUsersTruongBoPhan(keyword, searchby, filter, idDotDanhGia);
        }
        public static DataTable GetUsersByUser(string keyword, string searchby, string filter, int userid, int portalid)
        {
            return DataAccessProvider.Instance().GetUsersByUser(keyword, searchby, filter, userid, portalid);
        }
        public static DataTable GetUsersNotInRole(int roleId, int portalId, int idbophan)
		{
			//string param = "GetUsersNotInRole?roleid=" + roleId + "&portalid=" + portalId;
			//DataCaching data = new DataCaching();
			DataTable dtUsers ;//= (DataTable)data.GetHashCache(key, param);
			//if (dtUsers != null) return dtUsers;
            dtUsers = DataAccessProvider.Instance().GetUsersNotInRole(roleId, portalId, idbophan);
			//data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtUsers);
			return dtUsers;
		}
        public static DataTable GetUsersNotInRoleByUser(int userId, int roleId, int portalId)
        {
            //string param = "GetUsersNotInRole?roleid=" + roleId + "&portalid=" + portalId;
            //DataCaching data = new DataCaching();
            DataTable dtUsers;//= (DataTable)data.GetHashCache(key, param);
            //if (dtUsers != null) return dtUsers;
            dtUsers = DataAccessProvider.Instance().GetUsersNotInRoleByUser(userId, roleId, portalId);
            //data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtUsers);
            return dtUsers;
        }
		public static UserInfo ValidateUser(string username, string password)
		{
			return DataAccessProvider.Instance().ValidateUser(username, password);
		}
		public static int AddUser(UserInfo user)
		{
			int id = DataAccessProvider.Instance().AddUser(user);
			DataCaching data = new DataCaching();
			data.RemoveCache(key);
			return id;
		}
		public static void UpdateUser(UserInfo user)
		{
			DataAccessProvider.Instance().UpdateUser(user);			
		}

        public static void UpdateUserThongTinMoRong(UserInfo user)
        {
            DataAccessProvider.Instance().UpdateUserThongTinMoRong(user);
        }
        
        public static void UpdateUserHDLDGH1GH2(UserInfo user)
        {
            DataAccessProvider.Instance().UpdateUserHDLDGH1GH2(user);
        }
        public static void UpdateUserHDLDGH345(UserInfo user)
        {
            DataAccessProvider.Instance().UpdateUserHDLDGH345(user);
        }
        public static void UpdateUserHocVanToChucDoanTheKhenThuong(UserInfo user)
        {
            DataAccessProvider.Instance().UpdateUserHocVanToChucDoanTheKhenThuong(user);
        }
        public static void UpdateUserQuaTrinhLamViec(UserInfo user)
        {
            DataAccessProvider.Instance().UpdateUserQuaTrinhLamViec(user);
        }
        public static void UpdateUserThongTinGiaDinh(UserInfo user)
        {
            DataAccessProvider.Instance().UpdateUserThongTinGiaDinh(user);
        }

        public static void UpdateUserDiemSangTao(int idNhanVien, int idDotDanhGia, double diem, string note)
        {
            DataAccessProvider.Instance().UpdateUserDiemSangTao(idNhanVien, idDotDanhGia, diem, note);
        }

        public static void UpdateBoPhanDiemSangTao(int idBoPhan, int idDotDanhGia, int ytuongthang, int ytuongmoi, int sonhanviengui, int ytuongduocchon, int sonhanvien)
        {
            DataAccessProvider.Instance().UpdateBoPhanDiemSangTao(idBoPhan, idDotDanhGia, ytuongthang, ytuongmoi, sonhanviengui, ytuongduocchon, sonhanvien);
        }

        public static void UpdateBoPhanDGDiemSangTao(int idBoPhan, int idDotDanhGia, int YTuongDoatGiai, int KhongPhoiHop, int PhoiHopNhietTinh, int ThucDayNhanVien)
        {
            DataAccessProvider.Instance().UpdateBoPhanDGDiemSangTao(idBoPhan, idDotDanhGia, YTuongDoatGiai, KhongPhoiHop, PhoiHopNhietTinh, ThucDayNhanVien);
        }

        public static void UpdateBoPhanDiemKyLuat5S(int idBoPhan, int idDotDanhGia, int MatXanh, int MatMeu, int MatNau, int Other, string note, string note1)
        {
            DataAccessProvider.Instance().UpdateBoPhanDiemKyLuat5S(idBoPhan, idDotDanhGia, MatXanh, MatMeu, MatNau, Other, note, note1);
        }

        public static void UpdateBoPhanDGKyLuat(int idBoPhan, int idDotDanhGia, int ThamGiaHDCongTy, int ChuyenCan, int TuanThuThoiGian, int KhenThuong, int DiemKyLuatTT)
        {
            DataAccessProvider.Instance().UpdateBoPhanDGKyLuat(idBoPhan, idDotDanhGia, ThamGiaHDCongTy, ChuyenCan, TuanThuThoiGian, KhenThuong, DiemKyLuatTT);
        }
        

        public static void UpdateUserDieuChinhNhanSu(UserInfo user)
        {
            DataAccessProvider.Instance().UpdateUserDieuChinhNhanSu(user);
        }
		public static void DeleteUser(int userId)
		{
			DataAccessProvider.Instance().DeleteUser(userId);
			DataCaching data = new DataCaching();
			data.RemoveCache(key);
		}
        public static void RemoveUserFromPortal(int userId)
        {
            DataAccessProvider.Instance().RemoveUserFromPortal(userId);
            DataCaching data = new DataCaching();
            data.RemoveCache(key);
        }
		public static UserInfo GetUser(int userId)
		{
			return DataAccessProvider.Instance().GetUser(userId);
		}
		public static UserInfo GetUser(string username)
		{
			return DataAccessProvider.Instance().GetUser(username);
		}
		public static void AddCommandToUser(int commandId, int userId)
		{
			DataAccessProvider.Instance().AddCommandToUser(commandId, userId);
			DataCaching data = new DataCaching();
			data.RemoveCache("VmgPortal.Portal.Command.GetCommandsForUserNotGroup");
		}
		public static void RemoveCommandFromUser(int commandId, int userId)
		{
			DataAccessProvider.Instance().RemoveCommandFromUser(commandId, userId);		
		}
		public static void ResetPassword(int userId, string password)
		{
			DataAccessProvider.Instance().ResetPassword(userId, password);
			DataCaching data = new DataCaching();
			data.RemoveCache(key);
		}
		public static void ChangePassword(int userId, string oldPassword, string newPassword)
		{
			DataAccessProvider.Instance().ChangePassword(userId, oldPassword, newPassword);
			DataCaching data = new DataCaching();
			data.RemoveCache(key);
		}
        public static void AddCommandToUserByPortalID(int commandId, int userId, int portalId)
        {
            DataAccessProvider.Instance().AddCommandToUserByPortalID(commandId, userId, portalId);
            DataCaching data = new DataCaching();
            data.RemoveCache("VmgPortal.Portal.Command.GetCommandsForUserNotGroup");
        }
        public static void RemoveCommandFromUserByPortalID(int commandId, int userId, int portalId)
        {
            DataAccessProvider.Instance().RemoveCommandFromUserByPortalID(commandId, userId, portalId);
        }
        public static DataRow[] GetUserPermissionByParentID(DataTable dtCommand, int parentID)
        {
            DataRow[] retVal = null;
            retVal = dtCommand.Select("CommandParentID = " + parentID);
            return retVal;
        }
        public static DataTable BuildRecursiveUserPermission(DataTable dtCommand, DataTable dtReturnCommand,int userid, int portalid)
        {
            DataRow[] dtItems = GetUserPermissionByParentID(dtCommand, 0);
            foreach (DataRow row in dtItems)
            {
                DataRow rowItem = dtReturnCommand.NewRow();
                rowItem["CommandID"]    = row["CommandID"].ToString();
                rowItem["PortalID"] = portalid.ToString();
                rowItem["CommandParentID"] = row["CommandParentID"].ToString();
                rowItem["UserID"] = userid.ToString();
                rowItem["CommandName"]  = "<font color=\"Blue\">" + row["CommandName"].ToString() + "</font>";
                rowItem["Role_View"] = row["Role_View"].ToString();
                rowItem["Role_Add"] = row["Role_Add"].ToString();
                rowItem["Role_Update"] = row["Role_Update"].ToString();
                rowItem["Role_Delete"] = row["Role_Delete"].ToString();
                rowItem["UseForWeb"] = row["UseForWeb"].ToString();
                rowItem["UseForWap"] = row["UseForWap"].ToString();
                rowItem["UseForSMS"] = row["UseForSMS"].ToString();
                rowItem["UseForXzone"] = row["UseForXzone"].ToString();
                rowItem["Level"] = "0";

                dtReturnCommand.Rows.Add(rowItem);
                LoadUserPermissionForCur(dtCommand, rowItem, dtReturnCommand);
            }
            DataCaching data = new DataCaching();
            data.RemoveCache("VmgPortal.Portal.Command.GetCommandsForUserNotGroup");
            return dtReturnCommand;
        }
        public static DataTable LoadUserPermissionForCur(DataTable dtCommand,DataRow curItem, DataTable dtReturnCommand)
        {
            int level = Convert.ToInt32(curItem["Level"]);
            level += 1;
            int _commandID = Convert.ToInt32(curItem["CommandID"]);
            DataRow[] dtChild = GetUserPermissionByParentID(dtCommand, _commandID);
            foreach (DataRow row in dtChild)
            {
                DataRow childItem = dtReturnCommand.NewRow();
                childItem["CommandID"] = row["CommandID"].ToString();
                childItem["CommandParentID"] = row["CommandParentID"].ToString();
                childItem["PortalID"] = row["PortalID"].ToString();
                childItem["UserID"] = row["UserID"].ToString();
                if (level == 1)
                {
                    childItem["CommandName"] = MiscUtility.StringIndent(level) + "<font color=\"Red\">" + row["CommandName"].ToString() + "</font>";
                }
                else if (level == 2)
                {
                    childItem["CommandName"] = MiscUtility.StringIndent(level) + "<font color=\"Orange\">" + row["CommandName"].ToString() + "</font>";
                }
                else if (level == 3)
                {
                    childItem["CommandName"] = MiscUtility.StringIndent(level) + "<font color=\"Black\">" + row["CommandName"].ToString() + "</font>";
                }
                else
                {
                    childItem["CommandName"] = MiscUtility.StringIndent(level) + "<font color=\"Gray\">" + row["CommandName"].ToString() + "</font>";
                }
                childItem["Role_View"] = row["Role_View"].ToString();
                childItem["Role_Add"] = row["Role_Add"].ToString();
                childItem["Role_Update"] = row["Role_Update"].ToString();
                childItem["Role_Delete"] = row["Role_Delete"].ToString();
                childItem["UseForWeb"] = row["UseForWeb"].ToString();
                childItem["UseForWap"] = row["UseForWap"].ToString();
                childItem["UseForSMS"] = row["UseForSMS"].ToString();
                childItem["UseForXzone"] = row["UseForXzone"].ToString();
                childItem["Level"] = level.ToString();

                dtReturnCommand.Rows.Add(childItem);
                LoadUserPermissionForCur(dtCommand, childItem, dtReturnCommand);
            }
            return dtReturnCommand;
        }
        public static void UpdateUserPermissionByPortalID(int userId,int commandId, int portalId, bool view, bool add, bool update, bool delete)
        {
            //DataCaching data = new DataCaching();
            //data.RemoveCache("VmgPortal.Portal.Command.GetCommandsForUserNotGroup");
            DataAccessProvider.Instance().UpdateUserPermissionByPortalID(commandId, userId, portalId, view,  add,  update,  delete);           
        }
        public static void UpdateUserPermissionByPortalID(int userId, int commandId, int portalId, bool web, bool wap, bool sms, bool xzone, bool view, bool add, bool update, bool delete)
        {
            //DataCaching data = new DataCaching();
            //data.RemoveCache("VmgPortal.Portal.Command.GetCommandsForUserNotGroup");
            DataAccessProvider.Instance().UpdateUserPermissionByPortalID(commandId, userId, portalId, web, wap, sms, xzone, view, add, update, delete);
        }

        public static DataTable GetUsersKeHoachByNguoiDanhGiaTheoThang(int idNguoiDanhGia, int idTrungTam, int idDotDanhGia, int roleNguoiDanhGia, int trangThai)
        {
            return DataAccessProvider.Instance().GetUsersKeHoachByNguoiDanhGiaTheoThang(idNguoiDanhGia, idTrungTam, idDotDanhGia, roleNguoiDanhGia, trangThai);
        }

        public static DataTable GetUsersDanhGiaByNguoiDanhGiaTheoThang(int idNguoiDanhGia, int idTrungTam, int idDotDanhGia, int roleNguoiDanhGia, int trangThai)
        {
            return DataAccessProvider.Instance().GetUsersDanhGiaByNguoiDanhGiaTheoThang(idNguoiDanhGia, idTrungTam, idDotDanhGia, roleNguoiDanhGia, trangThai);
        }

        public static DataTable GetUsersPhatSinhCongViecTheoThang(int userId, int idTrungTam, int idDotDanhGia, int roleId)
        {
            return DataAccessProvider.Instance().GetUsersPhatSinhCongViecTheoThang(userId, idTrungTam, idDotDanhGia, roleId);
        }

        public static UserInfo GetThongTinNguoiDanhGiaMinh(int idDotDanhGia, int idNhanVien)
        {
            return DataAccessProvider.Instance().GetThongTinNguoiDanhGiaMinh(idDotDanhGia, idNhanVien);
        }

        public static UserInfo GetUserTBP(int idBoPhan)
        {
            return DataAccessProvider.Instance().GetUserTBP(idBoPhan);
        }

        public static DataTable GetBoPhanDiemSangTao(int idDotDanhGia)
        {
            return DataAccessProvider.Instance().GetBoPhanDiemSangTao(idDotDanhGia);
        }

        public static DataTable GetBoPhanDiemDGSangTao(int idDotDanhGia)
        {
            return DataAccessProvider.Instance().GetBoPhanDiemDGSangTao(idDotDanhGia);
        }

        public static DataTable GetBoPhanDiemKyLuat5S(int idDotDanhGia)
        {
            return DataAccessProvider.Instance().GetBoPhanDiemKyLuat5S(idDotDanhGia);

        }
        public static DataTable GetBoPhanDanhGiaKyLuat(int idDotDanhGia)
        {
            return DataAccessProvider.Instance().GetBoPhanDanhGiaKyLuat(idDotDanhGia);

        }
        public static DataTable GetKetQuaDanhGia(int idDotDanhGia)
        {
            return DataAccessProvider.Instance().GetKetQuaDanhGia(idDotDanhGia);


        }
        #region CEO danh gia

        public static DataTable GetTPvaPP(string keyword, string searchby, string filter, int idDotDanhGia, int loai)
        {
            return DataAccessProvider.Instance().GetTPvaPP(keyword, searchby, filter, idDotDanhGia, loai);
        }

        public static DataTable GetTPvaPPByUserManager(string keyword, string searchby, string filter, int idDotDanhGia, int loai, int userManager)
        {
            return DataAccessProvider.Instance().GetTPvaPPByUserManager(keyword, searchby, filter, idDotDanhGia, loai, userManager);
        }

        public static DataTable GetLanhDaoBP(string keyword, string searchby, string filter, int idDotDanhGia, int loai)
        {
            return DataAccessProvider.Instance().GetLanhDaoBP(keyword, searchby, filter, idDotDanhGia, loai);
        }

        #endregion
    }
	
}
