using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using VmgPortal.Library.Components.Commands;
using VmgPortal.Library.Components.Modules;
using VmgPortal.Library.Components.Portal;
using VmgPortal.Library.Components.Portal.Data;
using VmgPortal.Library.Components.Roles;
using VmgPortal.Library.Components.Users;

namespace VmgPortal.Library.Components.Providers
{
    public abstract class DataAccessProvider
    {
        public DataAccessProvider() { }

        private static DataAccessProvider objProvider;

        public static DataAccessProvider Instance()
        {
            if (objProvider != null) return objProvider;
            DataAccessProviderConfiguration objConfig = DataAccessProviderConfiguration.GetDataAccessProviderConfiguration();
            objProvider = (DataAccessProvider)DataAccessProviderFactory.CreateDataAccess((Provider)objConfig.Providers[objConfig.DefaultProvider]);
            return objProvider;
        }

        #region Main Language

        public abstract DataTable GetAll();
        #endregion

        #region Portals provider
        //Portals
        public abstract PortalSetting GetPortalSetting();
        public abstract void SetPortalSetting(string settingName, string settingValue);
        public abstract void SetPortalSetting(string settingName, string settingValue, string param1, string param2);
        public abstract Portal_PortalsInfo GetPortalsInfoByLang(int portalId);
        public abstract DataTable GetPortalsById(int portalId);
        public abstract DataTable GetPortalsByParentId(int parentId);
        public abstract DataTable GetPortalsByParentId(int userid, int parentId);
        public abstract DataTable GetPortals();
        public abstract DataTable GetPortalsByUserID(int _userid);
        public abstract DataTable GetPortalsByUserIDAndLang(int _userid, string lang);
        public abstract DataTable GetPortalsByLang(string lang);
        public abstract void DeletePortal(int portalId);
        public abstract int AddPortal(Portal_PortalsInfo portal);
        public abstract void AddPortalFollowLang(Portal_PortalsInfo portal);
        public abstract void UpdatePortal(Portal_PortalsInfo portal);
        #endregion

        #region PortalCache
        public abstract int AddPortalCache(Portal_CacheInfo portal);
        public abstract DataTable GetPortalCacheByPortalIdAndZoneID(int portalId, int zoneid);
        public abstract void DeletePortalCache(Portal_CacheInfo info);
        #endregion

        #region Command Provider

        //Commands        
        public abstract DataTable GetCommands();// Get all commands
        public abstract DataTable GetCommandByCmdId(int commandid);// Get all commands        
        public abstract DataTable GetCommands(int parent); // Get commands by parent id
        public abstract DataTable GetCommandsForUserNotGroup(int userId, int portalId); // Get commands for instance user
        public abstract DataTable GetCommandsForRoleByPortalID(int roleId, int portalID); // Get commands for instance role by portalid
        public abstract DataTable GetCommandsForUserByPortalID(int userId, int portalID); // Get commands for instance user by portalid
        public abstract DataTable GetButtonRoleForUserByPortalID(int userId, int portalID); // Get button role for instance user by portalid

        public abstract int AddCommand(CommandInfo command); // Add new command
        public abstract void UpdateCommand(CommandInfo command); // update instance command
        public abstract void AddCommandByLang(CommandInfo command, string lang); // Add new command
        public abstract void UpdateCommandByLang(CommandInfo command, string lang); // update instance command
        public abstract void DeleteCommand(int commandId); // Delete command
        public abstract CommandInfo GetCommand(int commandId); // Get command info
        public abstract CommandInfo GetCommandWithoutControlPath(int commandId); // Get command info
        public abstract CommandInfo GetCommandByLang(int commandId); // Get command by lang
        public abstract CommandInfo GetCommand(string commandKey); // Get command info
        public abstract bool IsAvailableForUser(int commandId, int userId, int portalid);

        #endregion

        #region Module Provider

        //Modules
        public abstract DataTable GetModules();
        public abstract int AddModule(ModuleInfo module);
        public abstract void UpdateModule(ModuleInfo module);
        public abstract void DeleteModule(int moduleId);
        public abstract ModuleInfo GetModule(int moduleId);
        public abstract ModuleSetting GetModuleSettings(int moduleId);
        public abstract void SetModuleSetting(int moduleId, string name, string value);

        #endregion

        #region ModuleControls provider

        //ModuleControls
        public abstract DataTable GetModuleControls();
        public abstract DataTable GetModuleControlsForCommand();
        public abstract DataTable GetModuleControlsForWeb();
        public abstract DataTable GetModuleControls(int moduleId);
        public abstract DataTable GetModuleControls(int tabId, string layoutPosition);
        public abstract int AddModuleControl(ModuleControlInfo moduleControl);
        public abstract void UpdateModuleControl(ModuleControlInfo moduleControl);
        public abstract void DeleteModuleControl(int controlId);
        public abstract ModuleControlInfo GetModuleControl(int controlId);
        public abstract ModuleControlInfo GetModuleControl(string controlKey);
        public abstract bool CheckExistsControlKey(string controlKey);

        #endregion

        #region Users Provider
        //Users
        public abstract DataTable GetUsers();
        public abstract DataTable GetUsers(int roleId, int portalId, int idbophan);
        public abstract DataTable GetUsers(string roleId, int portalId);
        public abstract DataTable GetUsersNotInRole(int roleId, int portalId, int idbophan);
        public abstract DataTable GetUsersNotInRoleByUser(int userId, int roleId, int portalId);
        public abstract DataTable GetUsers(string key, string searchby, string filter, int portalIdm, int idbophan);
        public abstract DataTable GetUsers(string key, string searchby, string filter, int portalIdm, int idbophan, int trangthai, int gender);
        public abstract DataTable GetUsersDiemSangTao(string key, string searchby, string filter, int portalIdm, int idbophan, int trangthai, int gender, int idDotDanhGia);
       
        public abstract DataTable GetUsersByNguoiDanhGia(string key, string searchby, string filter, int portalId, int idNguoiDanhGia, int idTrungTam, int idDotDanhGia, int roleNguoiDanhGia, int roleNhanVien);
        public abstract DataTable GetUsersByNguoiDanhGiaTheoThang(string key, string searchby, string filter,int idNguoiDanhGia, int idTrungTam, int idDotDanhGia, int roleNguoiDanhGia, int roleNhanVien);
        public abstract DataTable GetUsersLapKeHoachByNguoiDanhGiaTheoThang(string key, string searchby, string filter, int idNguoiDanhGia, int idTrungTam, int idDotDanhGia, int roleNguoiDanhGia, int roleNhanVien);
        
        public abstract DataTable GetUsersTruongBoPhan(string key, string searchby, string filter);
        public abstract DataTable GetUsersTruongBoPhan(string key, string searchby, string filter, int idDotDanhGia);
        
        public abstract DataTable GetUsersByUser(string key, string searchby, string filter, int userid, int portalId);
        public abstract UserInfo ValidateUser(string username, string password);

        public abstract int AddUser(UserInfo user);
        public abstract void UpdateUser(UserInfo user);
        public abstract void UpdateUserThongTinMoRong(UserInfo user);
        public abstract void UpdateUserHDLDGH1GH2(UserInfo user);
        public abstract void UpdateUserHDLDGH345(UserInfo user);
        public abstract void UpdateUserHocVanToChucDoanTheKhenThuong(UserInfo user);
        public abstract void UpdateUserQuaTrinhLamViec(UserInfo user);
        public abstract void UpdateUserThongTinGiaDinh(UserInfo user);
        public abstract void UpdateUserDieuChinhNhanSu(UserInfo user);

        public abstract void UpdateUserDiemSangTao(int idNhanVien, int idDotDanhGia, double diem, string note);
        public abstract void UpdateBoPhanDiemSangTao(int idBoPhan, int idDotDanhGia, int ytuongthang, int ytuongmoi, int sonhanviengui, int ytuongduocchon, int sonhanvien);
        public abstract void UpdateBoPhanDiemKyLuat5S(int idBoPhan, int idDotDanhGia, int MatXanh, int MatMeu, int MatNau, int Other, string note, string note1);
        public abstract void UpdateBoPhanDGDiemSangTao(int idBoPhan, int idDotDanhGia, int YTuongDoatGiai, int KhongPhoiHop, int PhoiHopNhietTinh, int ThucDayNhanVien);
        public abstract void UpdateBoPhanDGKyLuat(int idBoPhan, int idDotDanhGia, int ThamGiaHDCongTy, int ChuyenCan, int TuanThuThoiGian, int KhenThuong, int DiemKyLuatTT);
       

        public abstract void DeleteUser(int userId);
        public abstract void RemoveUserFromPortal(int userId);
        public abstract UserInfo GetUser(int userId);
        public abstract UserInfo GetUser(string username);
        public abstract void AddCommandToUser(int commandId, int userId);
        public abstract void RemoveCommandFromUser(int commandId, int userId);
        public abstract void ResetPassword(int userId, string password);
        public abstract void ChangePassword(int userId, string oldPassword, string newPassword);
        public abstract void AddCommandToUserByPortalID(int commandId, int userId, int portalId);
        public abstract void RemoveCommandFromUserByPortalID(int commandId, int userId, int portalId);
        public abstract void UpdateUserPermissionByPortalID(int commandId, int userId, int portalId, bool view, bool add, bool update, bool delete);
        public abstract void UpdateUserPermissionByPortalID(int commandId, int userId, int portalId, bool web, bool wap, bool sms, bool xzone, bool view, bool add, bool update, bool delete);
        public abstract DataTable GetUsersExcludeUserName(string key, string searchby, string filter, int portalId, string username);

        #endregion

        #region Roles provider
        //Roles
        public abstract DataTable GetRoles();
        public abstract DataTable GetRoles(string key, string searchby, string filter);
        public abstract DataTable GetRoles(int userId);
        public abstract DataTable GetRolesByUserManager(int userManager);
        public abstract DataTable GetRolesByParentId(int parentId);
        public abstract int AddRole(RoleInfo role);
        public abstract void UpdateRole(RoleInfo role);
        public abstract void DeleteRole(int roleId);
        public abstract RoleInfo GetRole(int roleId);
        public abstract void AddUserToRole(int userId, int roleId, int portalId);
        public abstract void UpdateUserToRole(int userId, int roleId, int portalId);
        public abstract void RemoveUserFromRole(int userId, int roleId, int portalId);
        /// <summary>
        /// Add command to role by portalID
        /// Added by Dungnt2
        /// 24/4/2007
        /// </summary>
        /// <param name="commandId"></param>
        /// <param name="roleId"></param>
        /// <param name="portalID"></param>
        public abstract void AddCommandToRoleByPortalID(int commandId, int roleId, int portalID);
        /// <summary>
        /// Remove command from role by portalID
        /// Added by Dungnt2
        /// 24/4/2007
        /// </summary>
        /// <param name="commandId"></param>
        /// <param name="roleId"></param>
        /// <param name="portalID"></param>
        public abstract void RemoveCommandFromRoleByPortalID(int commandId, int roleId, int portalID);
        public abstract void UpdateRolePermissionByPortalID(int commandId, int roleid, int portalId, bool view, bool add, bool update, bool delete);
        public abstract void UpdateRolePermissionByPortalID(int commandId, int roleid, int portalId, bool web, bool wap, bool sms, bool xzone, bool view, bool add, bool update, bool delete);

        #endregion

        public abstract DataTable GetUsersKeHoachByNguoiDanhGiaTheoThang(int idNguoiDanhGia, int idTrungTam, int idDotDanhGia, int roleNguoiDanhGia, int trangThai);
        public abstract DataTable GetUsersDanhGiaByNguoiDanhGiaTheoThang(int idNguoiDanhGia, int idTrungTam, int idDotDanhGia, int roleNguoiDanhGia, int trangThai);
        public abstract DataTable GetUsersPhatSinhCongViecTheoThang(int userId, int idTrungTam, int idDotDanhGia, int roleId);

        public abstract UserInfo GetThongTinNguoiDanhGiaMinh(int idDotDanhGia, int idNhanVien);
        public abstract UserInfo GetUserTBP(int idBoPhan);


        public abstract DataTable GetBoPhanDiemSangTao(int idDotDanhGia);
        public abstract DataTable GetBoPhanDiemDGSangTao(int idDotDanhGia);
        

        public abstract DataTable GetBoPhanDiemKyLuat5S(int idDotDanhGia);
        public abstract DataTable GetBoPhanDanhGiaKyLuat(int idDotDanhGia);
        
        public abstract DataTable GetKetQuaDanhGia(int idDotDanhGia);
        

        #region CEO danh gia

        public abstract DataTable GetTPvaPP(string key, string searchby, string filter, int idDotDanhGia, int loai);
        public abstract DataTable GetTPvaPPByUserManager(string key, string searchby, string filter, int idDotDanhGia, int loai, int userManager);
        public abstract DataTable GetLanhDaoBP(string key, string searchby, string filter, int idDotDanhGia, int loai);

        #endregion
    }
}
