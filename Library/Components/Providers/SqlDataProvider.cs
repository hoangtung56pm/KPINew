using System.Data;
using VmgPortal.Library.Components.Commands;
using VmgPortal.Library.Components.Modules;
using VmgPortal.Library.Components.Portal;
using VmgPortal.Library.Components.Portal.Data;
using VmgPortal.Library.Components.Roles;
using VmgPortal.Library.Components.Users;
using Microsoft.ApplicationBlocks.Data;
using VmgPortal.Library.Utilities;

namespace VmgPortal.Library.Components.Providers
{
    public class SqlDataProvider : DataAccessProvider
    {
        private string ConnectionString;
        public SqlDataProvider(string connStr)
        {
            this.ConnectionString = connStr;
        }

        #region Backup

        #region MainLanguage

        public override DataTable GetAll()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_MainLang_GetAll");
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        #endregion

        #region Portals provider
        //Portals

        public override PortalSetting GetPortalSetting()
        {
            PortalSetting setting = new PortalSetting();
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_PortalSettings_GetSettings");
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dtSettings = ds.Tables[0];
                foreach (DataRow row in dtSettings.Rows)
                {
                    setting[row["SettingName"].ToString()] = row["SettingValue"].ToString();
                }
            }
            return setting;
        }
        public override void SetPortalSetting(string settingName, string settingValue)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_PortalSettings_SetValue", settingName, settingValue);
        }
        public override void SetPortalSetting(string settingName, string settingValue, string param1, string param2)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_PortalSettings_SetValueWidthParams", settingName, settingValue, param1, param2);
        }

        public override Portal_PortalsInfo GetPortalsInfoByLang(int portalId)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "Portal_Portals_GetInfoByLang", portalId, AppEnv.GetLanguage());
            Portal_PortalsInfo portalInfo = (Portal_PortalsInfo)ObjectHelper.CreateObject(typeof(Portal_PortalsInfo), dr);
            return portalInfo;
        }

        public override DataTable GetPortals()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Portals_GetAll", AppEnv.GetLanguage());
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetPortalsByUserID(int _userid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Portals_GetAllByUserID", _userid);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetPortalsByUserIDAndLang(int _userid, string _lang)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Portals_GetAllByUserIDAndLang", _userid, _lang);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetPortalsByLang(string _lang)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Portals_GetAllByLang", _lang);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetPortalsById(int _portalId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Portals_GetAllById", _portalId);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetPortalsByParentId(int _parentId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Portals_GetAllByParentId", _parentId, AppEnv.GetLanguage());
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override DataTable GetPortalsByParentId(int userId, int _parentId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Portals_GetAllByParentIdAndUserId", userId, _parentId, AppEnv.GetLanguage());
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override void DeletePortal(int portalId)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Portals_Delete", portalId);
        }

        public override int AddPortal(Portal_PortalsInfo portal)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "Portal_Portals_Insert", portal.Visible, portal.Active, portal.ImageUrl, portal.Portal_ParentId, portal.Priority);
        }
        public override void AddPortalFollowLang(Portal_PortalsInfo portal)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Portals_InsertFollowLang", portal.PortalID, portal.Lang, portal.Portal_Name, portal.Portal_Description);
        }
        public override void UpdatePortal(Portal_PortalsInfo portal)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Portals_Update", portal.PortalID, portal.Visible, portal.Active, portal.ImageUrl,
                                                 portal.Lang, portal.Portal_Name, portal.Portal_Description, portal.Portal_ParentId, portal.Priority, portal.TabDefault);
        }

        #endregion

        #region PortalCache
        public override int AddPortalCache(Portal_CacheInfo portal)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "Portal_Cache_Insert", portal.PortalID, portal.ZoneID, portal.CacheKey);
        }

        public override void DeletePortalCache(Portal_CacheInfo info)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Cache_Delete", info.PortalID, info.ZoneID, info.Portal_Cache_ID);
        }

        public override DataTable GetPortalCacheByPortalIdAndZoneID(int _portalId, int zoneid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Cache_GetAll", _portalId, zoneid);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        #endregion

        #region Command provider
        //Commands
        public override DataTable GetCommands()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Commands_GetAll", AppEnv.GetLanguage());
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetCommandByCmdId(int commandid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Commands_ByCommandID", commandid);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override DataTable GetCommands(int parent)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Commands_GetCommandsByParent", parent, AppEnv.GetLanguage());
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetCommandsForUserNotGroup(int userId, int portalId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Commands_GetCommandsForUserNotGroupByPortalID", userId, portalId, AppEnv.GetLanguage());
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override DataTable GetCommandsForRoleByPortalID(int roleId, int portalId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Commands_GetCommandsForRoleByPortalID", roleId, portalId, AppEnv.GetLanguage());
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override DataTable GetCommandsForUserByPortalID(int userId, int portalId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Commands_GetCommandsForUserByPortalID", userId, portalId, AppEnv.GetLanguage());
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override DataTable GetButtonRoleForUserByPortalID(int userId, int portalId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Commands_GetButtonRoleForUserByPortalID", userId, portalId, AppEnv.CommandID());
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override int AddCommand(CommandInfo command)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "Portal_Commands_Insert", command.CommandParentID,
                                        command.CommandKey, command.CommandParams, command.CommandUrl, command.CommandOrder,
                                                   command.CommandVisible, command.CommandEnable, false);
        }
        public override void UpdateCommand(CommandInfo command)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Commands_Update", command.CommandID, command.CommandParentID,
                                      command.CommandKey, command.CommandParams, command.CommandUrl, command.CommandOrder,
                                      command.CommandVisible, command.CommandEnable, command.IsSuperUser);
        }
        public override void AddCommandByLang(CommandInfo command, string lang)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Commands_InsertByLang", lang, command.CommandID, command.CommandName);

        }
        public override void UpdateCommandByLang(CommandInfo command, string lang)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Commands_UpdateByLang", lang, command.CommandID, command.CommandName);
        }
        public override void DeleteCommand(int commandId)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Commands_Delete", commandId);
        }
        public override CommandInfo GetCommand(int commandId)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "Portal_Commands_GetInfo", commandId, AppEnv.GetLanguage());
            CommandInfo command = (CommandInfo)ObjectHelper.CreateObject(typeof(CommandInfo), dr);
            return command;
        }
        public override CommandInfo GetCommandWithoutControlPath(int commandId)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "Portal_Commands_GetInfoWithoutControlPath", commandId, AppEnv.GetLanguage());
            CommandInfo command = (CommandInfo)ObjectHelper.CreateObject(typeof(CommandInfo), dr);
            return command;
        }
        public override CommandInfo GetCommandByLang(int commandId)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "Portal_Commands_ByLang", commandId, AppEnv.GetLanguage());
            CommandInfo command = (CommandInfo)ObjectHelper.CreateObject(typeof(CommandInfo), dr);
            return command;
        }
        public override CommandInfo GetCommand(string commandKey)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "Portal_Commands_GetInfoByCommandKey", commandKey, AppEnv.GetLanguage());
            CommandInfo command = (CommandInfo)ObjectHelper.CreateObject(typeof(CommandInfo), dr);
            return command;
        }

        public override bool IsAvailableForUser(int commandId, int userId, int portalid)
        {
            DataTable dtCommandsForUser = GetCommandsForUserByPortalID(userId, portalid);
            foreach (DataRow row in dtCommandsForUser.Rows)
                if ((int)row["CommandID"] == commandId)
                    return true;
            return false;
        }

        #endregion

        #region Module provider
        //Modules
        public override DataTable GetModules()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Modules_GetAll");
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override int AddModule(ModuleInfo module)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "Portal_Modules_Insert", module.ModuleName, module.ModuleTitle, module.ModuleDescription, module.ModuleFolder);
        }
        public override void UpdateModule(ModuleInfo module)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Modules_Update", module.ModuleID, module.ModuleName, module.ModuleTitle, module.ModuleDescription, module.ModuleFolder);
        }
        public override void DeleteModule(int moduleId)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Modules_Delete", moduleId);
        }
        public override ModuleInfo GetModule(int moduleId)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "Portal_Modules_GetInfo", moduleId);
            ModuleInfo module = (ModuleInfo)ObjectHelper.CreateObject(typeof(ModuleInfo), dr);
            return module;

        }
        public override ModuleSetting GetModuleSettings(int moduleId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Modules_GetModuleSettings", moduleId);
            ModuleSetting setting = new ModuleSetting();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dtSettings = ds.Tables[0];
                foreach (DataRow row in dtSettings.Rows)
                {
                    setting[row["SettingName"].ToString()] = row["SettingValue"].ToString();
                }
            }
            return setting;
        }
        public override void SetModuleSetting(int moduleId, string name, string value)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Modules_SetModuleSettings", moduleId, name, value);
        }

        #endregion

        #region ModuleControls provider
        //ModuleControls
        public override DataTable GetModuleControls()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_ModuleControls_GetAll");
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override DataTable GetModuleControlsForCommand()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_ModuleControls_GetForCommand");
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override DataTable GetModuleControlsForWeb()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_ModuleControls_GetForWeb");
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override DataTable GetModuleControls(int moduleId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_ModuleControls_GetByModule", moduleId);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override DataTable GetModuleControls(int tabId, string layoutPosition)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_ModuleControls_GetByTabIDAndLayoutPosition", tabId, layoutPosition);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override int AddModuleControl(ModuleControlInfo moduleControl)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "Portal_ModuleControls_Insert", moduleControl.ModuleID,
                        moduleControl.ControlName, moduleControl.ControlTitle, moduleControl.ControlKey, moduleControl.ControlPath,
                  moduleControl.ControlRole, moduleControl.ControlIcon, moduleControl.ControlDescription, moduleControl.ControlOrder,
                                                 moduleControl.ControlHeader);
        }
        public override void UpdateModuleControl(ModuleControlInfo moduleControl)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_ModuleControls_Update", moduleControl.ControlID, moduleControl.ModuleID, moduleControl.ControlName,
                                     moduleControl.ControlTitle, moduleControl.ControlKey, moduleControl.ControlPath, moduleControl.ControlRole,
                                                                                     moduleControl.ControlIcon, moduleControl.ControlDescription, moduleControl.ControlOrder, moduleControl.ControlHeader);
        }
        public override void DeleteModuleControl(int controlId)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_ModuleControls_Delete", controlId);
        }
        public override ModuleControlInfo GetModuleControl(int controlId)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "Portal_ModuleControls_GetInfo", controlId);
            ModuleControlInfo control = (ModuleControlInfo)ObjectHelper.CreateObject(typeof(ModuleControlInfo), dr);
            return control;
        }
        public override ModuleControlInfo GetModuleControl(string controlKey)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "Portal_ModuleControls_GetInfoByControlKey", controlKey);
            ModuleControlInfo control = (ModuleControlInfo)ObjectHelper.CreateObject(typeof(ModuleControlInfo), dr);
            return control;
        }
        public override bool CheckExistsControlKey(string controlKey)
        {
            int result = (int)SqlHelper.ExecuteScalar(this.ConnectionString, "Portal_ModuleControls_CheckExistsControlKey", controlKey);
            return result > 0;
        }

        #endregion

        #region Users provider
        //Users
        public override DataTable GetUsers()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Users_GetAll", AppEnv.PortalId());
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetUsers(string key, string searchby, string filter, int portalId, int idbophan, int trangthai, int gender)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Users_SearchTrangThai", key, searchby, filter, portalId, idbophan, trangthai, gender);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetUsersDiemSangTao(string key, string searchby, string filter, int portalId, int idbophan, int trangthai, int gender, int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Users_GetUsersDiemSangTao", key, searchby, filter, portalId, idbophan, trangthai, gender, idDotDanhGia);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetUsers(string key, string searchby, string filter, int portalId, int idbophan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Users_Search", key, searchby, filter, portalId, idbophan);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetUsersByNguoiDanhGia(string key, string searchby, string filter, int portalId, int idNguoiDanhGia, int idTrungTam, int idDotDanhGia, int roleNguoiDanhGia, int roleNhanVien)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Users_Search_NguoiDanhGia", key, searchby, filter, portalId, idNguoiDanhGia, idTrungTam, idDotDanhGia, roleNguoiDanhGia, roleNhanVien);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetUsersByNguoiDanhGiaTheoThang(string key, string searchby, string filter, int idNguoiDanhGia, int idTrungTam, int idDotDanhGia, int roleNguoiDanhGia, int roleNhanVien)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Users_Search_TheoThangVaNguoiDanhGia", key, searchby, filter, idNguoiDanhGia, idTrungTam, idDotDanhGia, roleNguoiDanhGia, roleNhanVien);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetUsersLapKeHoachByNguoiDanhGiaTheoThang(string key, string searchby, string filter, int idNguoiDanhGia, int idTrungTam, int idDotDanhGia, int roleNguoiDanhGia, int roleNhanVien)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Users_Search_LapKeHoachThang", key, searchby, filter, idNguoiDanhGia, idTrungTam, idDotDanhGia, roleNguoiDanhGia, roleNhanVien);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }


        public override DataTable GetUsersTruongBoPhan(string key, string searchby, string filter)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Users_Search_TruongBoPhan", key, searchby, filter);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetUsersTruongBoPhan(string key, string searchby, string filter, int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Users_Search_TruongBoPhanByDotDanhGia", key, searchby, filter, idDotDanhGia);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetUsersByUser(string key, string searchby, string filter, int userid, int portalId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Users_Search_By_User", key, searchby, filter, userid, portalId);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override DataTable GetUsers(int roleId, int portalId, int idbophan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Users_GetUsersInRole", roleId, portalId, idbophan);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override DataTable GetUsers(string roleId, int portalId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Users_GetUsersInRoleNew", roleId, portalId);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override DataTable GetUsersNotInRole(int roleId, int portalId, int idbophan)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Users_GetUsersNotInRole", roleId, portalId, idbophan);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override DataTable GetUsersNotInRoleByUser(int userId, int roleId, int portalId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Users_GetUsersNotInRoleByUser", userId, roleId, portalId);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override UserInfo ValidateUser(string username, string password)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "Portal_Users_ValidateUser", username, password);
            UserInfo user = (UserInfo)ObjectHelper.CreateObject(typeof(UserInfo), dr);
            return user;
        }


        public override int AddUser(UserInfo user)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "NhanVien_Insert",
                    user.Username,
                    user.Password,
                    user.DisplayName,
                    user.IsAdmin,
                    user.IsSuperAdmin,
                    user.MaSo,
                    user.HoTen,
                    user.IDChucVu,
                    user.IDTrungTam,
                    user.IDPhong,
                    user.NgaySinh,
                    user.NoiSinh,
                    user.NguyenQuan,
                    user.QuocTich,
                    user.DanToc,
                    user.TonGiao,
                    user.GioiTinh,
                    user.DiaChiThuongChu,
                    user.DiaChiTamChu,
                    user.TrangThai);
        }
        public override void UpdateUser(UserInfo user)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "NhanVien_Update",
                    user.UserID,
                    user.Username,
                    user.Password,
                    user.DisplayName,
                    user.IsAdmin,
                    user.IsSuperAdmin,
                    user.MaSo,
                    user.HoTen,
                    user.IDChucVu,
                    user.IDTrungTam,
                    user.IDPhong,
                    user.NgaySinh,
                    user.NoiSinh,
                    user.NguyenQuan,
                    user.QuocTich,
                    user.DanToc,
                    user.TonGiao,
                    user.GioiTinh,
                    user.DiaChiThuongChu,
                    user.DiaChiTamChu,
                    user.TrangThai);
        }

        public override void UpdateUserThongTinMoRong(UserInfo user)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "NhanVien_UpdateThongTinMoRong",
                    user.UserID,
                    user.Username,
                    user.Password,
                    user.DisplayName,
                    user.IsAdmin,
                    user.IsSuperAdmin,
                    user.MaSo,
                    user.HoTen,
                    user.IDChucVu,
                    user.IDTrungTam,
                    user.IDPhong,
                    user.NgaySinh,
                    user.NoiSinh,
                    user.NguyenQuan,
                    user.QuocTich,
                    user.DanToc,
                    user.TonGiao,
                    user.GioiTinh,
                    user.DiaChiThuongChu,
                    user.DiaChiTamChu);
        }

        public override void UpdateUserThongTinGiaDinh(UserInfo user)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "NhanVien_UpdateThongTinGiaDinh",
                    user.UserID,
                    user.TTGDHoTenVoChong,
                    user.TTGDNamSinhVoChong,
                    user.TTGDNgheNgiep,
                    user.TTGDHoTenCon,
                    user.TTGDNamSinhCon,
                    user.TTGDGioiTinhCon,
                    user.TTGDNguoiLienHe);
        }

        public override void UpdateUserQuaTrinhLamViec(UserInfo user)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "NhanVien_UpdateQuaTrinhLamViec",
                    user.UserID,
                    user.QTLVCongTy,
                    user.QTLVChucDanh,
                    user.QTLVLyDoChuyenDoi,
                    user.BHXHThoiGianDong,
                    user.BHXHSoSo,
                    user.BHXHGhiChu);
        }

        public override void UpdateUserHocVanToChucDoanTheKhenThuong(UserInfo user)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "NhanVien_UpdateHocVanToChucDoanTheKhenThuong",
                    user.UserID,
                    user.HocVanBangCap,
                    user.HocVanNoiDaoTao,
                    user.HocVanChuyenNganh,
                    user.HocVanCacKhoaHocKhac,
                    user.HocVanNgoaiNgu,
                    user.ToChucDoanHiepHoi,
                    user.ToChucNgayGiaNhap,
                    user.ToChucNoiKetNap,
                    user.KhenThuongGiaiThuong,
                    user.KhenThuongToChucTrao,
                    user.KhenThuongNamTrao);
        }

        public override void UpdateUserHDLDGH345(UserInfo user)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "NhanVien_UpdateHDLDGH345",
                    user.UserID,
                    user.HDLD3NgayKyGiaHan,
                    user.HDLD3NguoiKyGiaHan,
                    user.HDLD3QDSo,
                    user.HDLD3NgayHieuLuc,
                    user.HDLD3NgayHetHan,
                    user.HDLD3ThoiHan,
                    user.HDLD4NgayKyGiaHan,
                    user.HDLD4NguoiKyGiaHan,
                    user.HDLD4QDSo,
                    user.HDLD4NgayHieuLuc,
                    user.HDLD4NgayHetHan,
                    user.HDLD4ThoiHan,
                    user.HDLD5NgayKyGiaHan,
                    user.HDLD5NguoiKyGiaHan,
                    user.HDLD5QDSo,
                    user.HDLD5NgayHieuLuc,
                    user.HDLD5NgayHetHan,
                    user.HDLD5ThoiHan);
        }

        public override void UpdateUserHDLDGH1GH2(UserInfo user)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "NhanVien_UpdateHDLDGH1GH2",
                    user.UserID,
                    user.HDLDSHD,
                    user.HDLDNguoiKy,
                    user.HDLDNgayKy,
                    user.HDLDNgayHieuLuc,
                    user.HDLDNgayHetHan,
                    user.HDLDLoaiHopDong,
                    user.HDLD1NgayKyGiaHan,
                    user.HDLD1NguoiKyGiaHan,
                    user.HDLD1QDSo,
                    user.HDLD1NgayHieuLuc,
                    user.HDLD1NgayHetHan,
                    user.HDLD1ThoiHan,
                    user.HDLD2NgayKyGiaHan,
                    user.HDLD2NguoiKyGiaHan,
                    user.HDLD2QDSo,
                    user.HDLD2NgayHieuLuc,
                    user.HDLD2NgayHetHan,
                    user.HDLD2ThoiHan);
        }

        public override void UpdateUserDieuChinhNhanSu(UserInfo user)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "NhanVien_UpdateCacDieuChinhNhanSu",
                    user.UserID,
                    user.DCNSQDSo,
                    user.DCNSNgay,
                    user.DCNSNgayHieuLuc,
                    user.DCNSChiTiet,
                    user.DCNSQDSo1,
                    user.DCNSNgay1,
                    user.DCNSNgayHieuLuc1,
                    user.DCNSChiTiet1,
                    user.DCNSQDSo2,
                    user.DCNSNgay2,
                    user.DCNSNgayHieuLuc2,
                    user.DCNSChiTiet2);

        }

        public override void UpdateUserDiemSangTao(int idNhanVien, int idDotDanhGia, double diem, string note)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "NhanVien_UpdateDiemSangTao",
                        idNhanVien, idDotDanhGia, diem, note);
        }

        public override void UpdateBoPhanDiemSangTao(int idBoPhan, int idDotDanhGia, int ytuongthang, int ytuongmoi, int sonhanviengui, int ytuongduocchon, int sonhanvien)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "BoPhan_UpdateDiemSangTao", idBoPhan, idDotDanhGia, ytuongthang, ytuongmoi, sonhanviengui, ytuongduocchon, sonhanvien);
        }

        public override void UpdateBoPhanDGDiemSangTao(int idBoPhan, int idDotDanhGia, int YTuongDoatGiai, int KhongPhoiHop, int PhoiHopNhietTinh, int ThucDayNhanVien)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "BoPhan_UpdateDGDiemSangTao", idBoPhan, idDotDanhGia, YTuongDoatGiai, KhongPhoiHop, PhoiHopNhietTinh, ThucDayNhanVien);
        }
        

        public override void UpdateBoPhanDiemKyLuat5S(int idBoPhan, int idDotDanhGia, int MatXanh, int MatMeu, int MatNau, int Other, string note, string note1)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "BoPhan_UpdateDiemKyLuat", idBoPhan, idDotDanhGia, MatXanh, MatMeu, MatNau, Other, note, note1);
        }

        public override void UpdateBoPhanDGKyLuat(int idBoPhan, int idDotDanhGia, int ThamGiaHDCongTy, int ChuyenCan, int TuanThuThoiGian, int KhenThuong, int DiemKyLuatTT)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "BoPhan_UpdateDiemDGKyLuat", idBoPhan, idDotDanhGia, ThamGiaHDCongTy, ChuyenCan, TuanThuThoiGian, KhenThuong, DiemKyLuatTT);
        } 
        
        public override void DeleteUser(int userId)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Users_Delete", userId);
        }
        public override void RemoveUserFromPortal(int userId)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Users_RemoveUserFromPortal", userId);
        }
        public override UserInfo GetUser(int userId)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "NhanVien_GetInfo", userId);
            UserInfo user = (UserInfo)ObjectHelper.CreateObject(typeof(UserInfo), dr);
            return user;
        }
        public override UserInfo GetUser(string username)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "Portal_Users_GetInfoByUsername", username);
            UserInfo user = (UserInfo)ObjectHelper.CreateObject(typeof(UserInfo), dr);
            return user;
        }
        public override void AddCommandToUser(int commandId, int userId)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Users_AddCommandToUser", commandId, userId);
        }
        public override void RemoveCommandFromUser(int commandId, int userId)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Users_RemoveCommandFromUser", commandId, userId);
        }
        public override void ResetPassword(int userId, string password)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Users_ResetPassword", userId, password);
        }
        public override void ChangePassword(int userId, string oldPassword, string newPassword)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Users_ChangePassword", userId, oldPassword, newPassword);
        }

        public override void AddCommandToUserByPortalID(int commandId, int userId, int portalId)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Users_AddCommandToUserByPortalID", commandId, userId, portalId);
        }
        public override void RemoveCommandFromUserByPortalID(int commandId, int userId, int portalId)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Users_RemoveCommandFromUserByPortalID", commandId, userId, portalId);
        }
        public override void UpdateUserPermissionByPortalID(int commandId, int userId, int portalId, bool Role_View, bool Role_Add, bool Role_Update, bool Role_Delete)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Users_UpdateCommandFromUserByPortalID", commandId, userId, portalId, Role_View, Role_Add, Role_Update, Role_Delete);
        }
        public override void UpdateUserPermissionByPortalID(int commandId, int userId, int portalId, bool web, bool wap, bool sms, bool xzone, bool Role_View, bool Role_Add, bool Role_Update, bool Role_Delete)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Users_UpdateCommandFromUserByPortalIDForUI", commandId, userId, portalId, web, wap, sms, xzone, Role_View, Role_Add, Role_Update, Role_Delete);
        }
        #endregion

        #region Roles provider
        //Roles
        public override DataTable GetRoles()
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Roles_GetAll");
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override DataTable GetRoles(string key, string searchby, string filter)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Roles_Search", key, searchby, filter);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override DataTable GetRoles(int userId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Roles_GetRolesForUser", userId);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override DataTable GetRolesByUserManager(int userManager)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Roles_GetRolesByUserManager", userManager);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetRolesByParentId(int parentId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Roles_GetRolesByParentId", parentId);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override int AddRole(RoleInfo role)
        {
            return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "Portal_Roles_Insert", role.RoleName, role.RoleDescription, role.Address, role.Phone, role.Fax, role.Email, role.UserManager, role.RoleParentID);
        }
        public override void UpdateRole(RoleInfo role)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Roles_Update", role.RoleID, role.RoleName, role.RoleDescription, role.Address, role.Phone, role.Fax, role.Email, role.UserManager, role.RoleParentID);
        }
        public override void DeleteRole(int roleId)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Roles_Delete", roleId);
        }
        public override RoleInfo GetRole(int roleId)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "Portal_Roles_GetInfo", roleId);
            RoleInfo role = (RoleInfo)ObjectHelper.CreateObject(typeof(RoleInfo), dr);
            return role;
        }
        public override DataTable GetUsersExcludeUserName(string key, string searchby, string filter, int portalId, string username)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "Portal_Users_Search_ExcludeUsername", key, searchby, filter, portalId, username);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public override void UpdateUserToRole(int userId, int roleId, int portalId)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Roles_UpdateUserToRoleAndPortal", userId, roleId, portalId);
        }

        public override void AddUserToRole(int userId, int roleId, int portalId)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Roles_AddUserToRoleAndPortal", userId, roleId, portalId);
        }

        public override void RemoveUserFromRole(int userId, int roleId, int portalId)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Roles_RemoveUserFromRoleAndPortalID", userId, roleId, portalId);
        }

        /// <summary>
        /// Add command to role by portalID
        /// Added by Dungnt2
        /// 23/4/2007
        /// </summary>
        /// <param name="commandId"></param>
        /// <param name="roleId"></param>
        public override void AddCommandToRoleByPortalID(int commandId, int roleId, int portalID)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Roles_AddCommandToRoleByPortalID", commandId, roleId, portalID);
        }
        /// <summary>
        /// Remove command from role by portalID
        /// Added by Dungnt2
        /// 23/4/2007
        /// </summary>
        /// <param name="commandId"></param>
        /// <param name="roleId"></param>
        /// <param name="portalID"></param>
        public override void RemoveCommandFromRoleByPortalID(int commandId, int roleId, int portalID)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Roles_RemoveCommandFromRoleByPortalID", commandId, roleId, portalID);
        }
        public override void UpdateRolePermissionByPortalID(int commandId, int roleId, int portalId, bool Role_View, bool Role_Add, bool Role_Update, bool Role_Delete)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Roles_UpdateCommandFromRoleByPortalID", commandId, roleId, portalId, Role_View, Role_Add, Role_Update, Role_Delete);
        }
        public override void UpdateRolePermissionByPortalID(int commandId, int roleId, int portalId, bool web, bool wap, bool sms, bool xzone, bool Role_View, bool Role_Add, bool Role_Update, bool Role_Delete)
        {
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "Portal_Roles_UpdateCommandFromRoleByPortalIDForUI", commandId, roleId, portalId, web, wap, sms, xzone, Role_View, Role_Add, Role_Update, Role_Delete);
        }
        #endregion

        #endregion

        public override DataTable GetUsersKeHoachByNguoiDanhGiaTheoThang(int idNguoiDanhGia, int idTrungTam, int idDotDanhGia, int roleNguoiDanhGia, int trangthai)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "GetUsersKeHoachByNguoiDanhGiaTheoThang", idNguoiDanhGia, idTrungTam, idDotDanhGia, roleNguoiDanhGia, trangthai);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetUsersDanhGiaByNguoiDanhGiaTheoThang(int idNguoiDanhGia, int idTrungTam, int idDotDanhGia, int roleNguoiDanhGia, int trangthai)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "GetUsersDanhGiaByNguoiDanhGiaTheoThang", idNguoiDanhGia, idTrungTam, idDotDanhGia, roleNguoiDanhGia, trangthai);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetUsersPhatSinhCongViecTheoThang(int userId, int idTrungTam, int idDotDanhGia, int roleId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "GetUsersPhatSinhCongViecTheoThang", userId, idTrungTam, idDotDanhGia, roleId);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override UserInfo GetThongTinNguoiDanhGiaMinh(int idDotDanhGia, int idNhanVien)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "Portal_Users_GetThongNguoiDanhGiaMinh", idDotDanhGia, idNhanVien);
            UserInfo user = (UserInfo)ObjectHelper.CreateObject(typeof(UserInfo), dr);
            return user;
        }

        public override UserInfo GetUserTBP(int idBoPhan)
        {
            IDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, "Portal_Users_GetThongTinTBP", idBoPhan);
            UserInfo user = (UserInfo)ObjectHelper.CreateObject(typeof(UserInfo), dr);
            return user;
        }

        public override DataTable GetBoPhanDiemSangTao(int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "BoPhan_GetDiemSangTao", idDotDanhGia);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetBoPhanDiemDGSangTao(int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "BoPhan_GetDiemDGSangTao", idDotDanhGia);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }


        public override DataTable GetBoPhanDiemKyLuat5S(int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "BoPhan_GetBoPhanDiemKyLuat5S", idDotDanhGia);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetBoPhanDanhGiaKyLuat(int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "BoPhan_GetBoPhanDiemDGKyLuat", idDotDanhGia);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        
        public override DataTable GetKetQuaDanhGia(int idDotDanhGia)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "BoPhan_GetKetQuaDanhGia", idDotDanhGia);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        

        #region CEO danh gia

        public override DataTable GetTPvaPP(string key, string searchby, string filter, int idDotDanhGia, int loai)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "CEO_DanhGia_GetTPVaPP", key, searchby, filter, idDotDanhGia, loai);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetTPvaPPByUserManager(string key, string searchby, string filter, int idDotDanhGia, int loai, int userManager)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "CEO_DanhGia_GetTPVaPPByUserManager", key, searchby, filter, idDotDanhGia, loai, userManager);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public override DataTable GetLanhDaoBP(string key, string searchby, string filter, int idDotDanhGia, int loai)
        {
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, "CEO_DanhGia_GetLanhDaoBP", key, searchby, filter, idDotDanhGia, loai);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        #endregion
    }
}

