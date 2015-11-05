using System;
using System.Data;
using System.Web.UI.WebControls;
using VmgPortal.Library.Components.Providers;
using VmgPortal.Library.Utilities;

namespace VmgPortal.Library.Components.Roles
{
	public class RoleController
	{
	    
        private const string key = "VmgPortal.Portal.Role";
        public static DataTable GetRolesByParentId(int parentId)
        {
            //string param = "GetRolesByParentId?" + parentId.ToString() + "&" + AppEnv.GetLanguage();
            //DataCaching data = new DataCaching();
            DataTable dtZones ;//= (DataTable)data.GetHashCache(key, param);
            //if (dtZones != null) ; return dtZones;
            dtZones = DataAccessProvider.Instance().GetRolesByParentId(parentId);
            //data.SetHashCache(key, param, Definition.CacheTime, dtZones);
            return dtZones;
        }
        public static void LoadRolesByUser(ListItemCollection lstItems, int userid)
        {
            //DataTable dtZones = GetRoles(userid);
            DataTable dtZones = GetRolesByUserManager(userid);
            foreach (DataRow row in dtZones.Rows)
            {
                ListItem item = new ListItem(row["RoleName"].ToString(), row["RoleID"].ToString());
                item.Attributes.Add("Level", "0");
                lstItems.Add(item);
                LoadForCurItem(lstItems, item);
            }
        }
        public static void LoadRoles(ListItemCollection lstItems)
        {
            DataTable dtZones = GetRolesByParentId(0);
            foreach (DataRow row in dtZones.Rows)
            {
                ListItem item = new ListItem(row["RoleName"].ToString(), row["RoleID"].ToString());
                item.Attributes.Add("Level", "0");
                lstItems.Add(item);
                LoadForCurItem(lstItems, item);
            }
        }
        public static void LoadForCurItem(ListItemCollection lstItems, ListItem curItem)
        {
            int curId = ConvertUtility.ToInt32(curItem.Value);
            int level = ConvertUtility.ToInt32(curItem.Attributes["Level"]);
            level++;
            DataTable dtChildRoles = GetRolesByParentId(curId);
            foreach (DataRow row in dtChildRoles.Rows)
            {
                ListItem item = new ListItem(MiscUtility.StringIndent(level) + row["RoleName"].ToString(), row["RoleID"].ToString());
                item.Attributes.Add("Level", level.ToString());
                lstItems.Add(item);
                LoadForCurItem(lstItems, item);
            }
        }

        public static DataRow[] GetRoleByParentID(DataTable dtRole, int parentID)
        {
            DataRow[] retVal = null;
            retVal = dtRole.Select("RoleParentID = " + parentID);
            return retVal;
        }
        public static DataTable GetRoleByParentID(DataTable dtRole, DataTable dtReturnRole)
        {
            DataRow[] dtItems = GetRoleByParentID(dtRole, 0);
            foreach (DataRow row in dtItems)
            {
                DataRow rowItem = dtReturnRole.NewRow();

                rowItem["RoleID"] = row["RoleID"].ToString();
                rowItem["RoleName"] = row["RoleName"];
                rowItem["RoleDescription"] = row["RoleDescription"];
                rowItem["RoleParentID"] = row["RoleParentID"];
                rowItem["Level"] = "0";

                dtReturnRole.Rows.Add(rowItem);
                LoadRoleForCur(dtRole, rowItem, dtReturnRole);
            }
            return dtReturnRole;
        }
      
        public static DataTable LoadRoleForCur(DataTable dtRole, DataRow curItem, DataTable dtReturnRole)
        {
            int level = Convert.ToInt32(curItem["Level"]);
            level += 1;
            int _roleID = Convert.ToInt32(curItem["RoleID"]);
            DataRow[] dtChild = GetRoleByParentID(dtRole, _roleID);

            foreach (DataRow row in dtChild)
            {
                DataRow childItem = dtReturnRole.NewRow();

                childItem["RoleID"] = row["RoleID"].ToString();
                childItem["RoleParentID"] = row["RoleParentID"];
                childItem["RoleDescription"] = row["RoleDescription"];
                childItem["RoleName"] = MiscUtility.StringIndent(level) + row["RoleName"].ToString();
                childItem["Level"] = level;
                dtReturnRole.Rows.Add(childItem);
                LoadRoleForCur(dtRole, childItem, dtReturnRole);
            }
            return dtReturnRole;
        }
	    
		public static DataTable GetRoles()
		{
            return DataAccessProvider.Instance().GetRoles();
		}
        public static DataTable GetRoles(string keyword, string searchby, string filter)
        {
            return DataAccessProvider.Instance().GetRoles(keyword, searchby, filter);
        }
        public static DataTable GetRoles(int userId)
        {
            return DataAccessProvider.Instance().GetRoles(userId);
        }
        public static DataTable GetRolesByUserManager(int userManager)
        {
            return DataAccessProvider.Instance().GetRolesByUserManager(userManager);
        }
		public static int AddRole(RoleInfo role)
		{
			int id = DataAccessProvider.Instance().AddRole(role);
            DataCaching data = new DataCaching();
            data.RemoveCache(key);
			return id;
		}
		public static void UpdateRole(RoleInfo role)
		{
			DataAccessProvider.Instance().UpdateRole(role);
            DataCaching data = new DataCaching();
            data.RemoveCache(key);
			
		}
		public static void DeleteRole(int roleId)
		{            
			DataAccessProvider.Instance().DeleteRole(roleId);
			DataCaching data = new DataCaching();
            data.RemoveCache(key);
		}
		public static RoleInfo GetRole(int roleId)
		{
			return DataAccessProvider.Instance().GetRole(roleId);
		}
       
        public static void AddUserToRole(int userId, int roleId, int portalId)
        {
            DataAccessProvider.Instance().AddUserToRole(userId, roleId, portalId);
            DataCaching data = new DataCaching();
            data.RemoveCache("VmgPortal.Portal.User");
            data.RemoveCache("VmgPortal.Portal.Portal");
        }
        public static void UpdateUserToRole(int userId, int roleId, int portalId)
        {
            DataAccessProvider.Instance().UpdateUserToRole(userId, roleId, portalId);
            DataCaching data = new DataCaching();
            data.RemoveCache("VmgPortal.Portal.User");
            data.RemoveCache("VmgPortal.Portal.Portal");
            
        }
       
        public static void RemoveUserFromRole(int userId, int roleId, int portalId)
        {
            DataAccessProvider.Instance().RemoveUserFromRole(userId, roleId, portalId);
            DataCaching data = new DataCaching();
            data.RemoveCache("VmgPortal.Portal.User");
            data.RemoveCache("VmgPortal.Portal.Portal");
        }
       
        /// <summary>
        /// Add Command to role by PortalID
        /// Add by Dungnt2
        /// </summary>
        /// <param name="commandId"></param>
        /// <param name="roleId"></param>
        public static void AddCommandToRoleByPortalID(int commandId, int roleId, int portalID)
        {
            DataAccessProvider.Instance().AddCommandToRoleByPortalID(commandId, roleId, portalID);
            DataCaching data = new DataCaching();
            data.RemoveCache("VmgPortal.Portal.Command");
        }
        /// <summary>
        /// Remove command from role by PortalID
        /// Add by Dungnt2
        /// </summary>
        /// <param name="commandId"></param>
        /// <param name="roleId"></param>
        public static void RemoveCommandFromRoleByPortalID(int commandId, int roleId, int portalID)
        {
            DataAccessProvider.Instance().RemoveCommandFromRoleByPortalID(commandId, roleId, portalID);
            DataCaching data = new DataCaching();
            data.RemoveCache("VmgPortal.Portal.Command");
        }

        /// <summary>
        /// Filter command for role by CommandParentID
        /// </summary>
        /// <param name="dtCommand"></param>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public static DataRow[] GetRolePermissionByParentID(DataTable dtCommand, int parentID)
        {
            DataRow[] retVal = null;
            retVal = dtCommand.Select("CommandParentID = " + parentID);
            return retVal;
        }

        /// <summary>
        /// Build recursive role permission by roleid and portalid
        /// Return table with multi level
        /// </summary>
        /// <param name="dtCommand"></param>
        /// <param name="dtReturnCommand"></param>
        /// <param name="roleid"></param>
        /// <param name="portalid"></param>
        /// <returns></returns>
        public static DataTable BuildRecursiveRolePermission(DataTable dtCommand, DataTable dtReturnCommand, int roleid, int portalid)
        {
            DataRow[] dtItems = GetRolePermissionByParentID(dtCommand, 0);
            foreach (DataRow row in dtItems)
            {
                DataRow rowItem = dtReturnCommand.NewRow();
                rowItem["CommandID"] = row["CommandID"].ToString();
                rowItem["PortalID"] = portalid.ToString();
                rowItem["CommandParentID"] = row["CommandParentID"].ToString();
                rowItem["RoleID"] = roleid.ToString();
                rowItem["CommandName"] = "<font color=\"Blue\">" + row["CommandName"].ToString() + "</font>";
                rowItem["Role_View"] = row["Role_View"].ToString();
                rowItem["Role_Add"] = row["Role_Add"].ToString();
                rowItem["Role_Update"] = row["Role_Update"].ToString();
                rowItem["Role_Delete"] = row["Role_Delete"].ToString();
                //rowItem["UseForWeb"] = row["UseForWeb"].ToString();
                //rowItem["UseForWap"] = row["UseForWap"].ToString();
                //rowItem["UseForSMS"] = row["UseForSMS"].ToString();
                //rowItem["UseForXzone"] = row["UseForXzone"].ToString();
                rowItem["Level"] = "0";

                dtReturnCommand.Rows.Add(rowItem);
                LoadRolePermissionForCur(dtCommand, rowItem, dtReturnCommand);
            }
            DataCaching data = new DataCaching();
            data.RemoveCache("VmgPortal.Portal.Command.GetCommandsForUserNotGroup");
            return dtReturnCommand;
        }
        /// <summary>
        /// Load role permission for current item
        /// </summary>
        /// <param name="dtCommand"></param>
        /// <param name="curItem"></param>
        /// <param name="dtReturnCommand"></param>
        /// <returns></returns>
        public static DataTable LoadRolePermissionForCur(DataTable dtCommand, DataRow curItem, DataTable dtReturnCommand)
        {
            int level = Convert.ToInt32(curItem["Level"]);
            level += 1;
            int _commandID = Convert.ToInt32(curItem["CommandID"]);
            DataRow[] dtChild = GetRolePermissionByParentID(dtCommand, _commandID);
            foreach (DataRow row in dtChild)
            {
                DataRow childItem = dtReturnCommand.NewRow();
                childItem["CommandID"] = row["CommandID"].ToString();
                childItem["CommandParentID"] = row["CommandParentID"].ToString();
                childItem["PortalID"] = row["PortalID"].ToString();
                childItem["RoleID"] = row["RoleID"].ToString();
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
                else if (level > 3)
                {
                    childItem["CommandName"] = MiscUtility.StringIndent(level) + "<font color=\"Gray\">" + row["CommandName"].ToString() + "</font>";
                }
                childItem["Role_View"] = row["Role_View"].ToString();
                childItem["Role_Add"] = row["Role_Add"].ToString();
                childItem["Role_Update"] = row["Role_Update"].ToString();
                childItem["Role_Delete"] = row["Role_Delete"].ToString();
                //childItem["UseForWeb"] = row["UseForWeb"].ToString();
                //childItem["UseForWap"] = row["UseForWap"].ToString();
                //childItem["UseForSMS"] = row["UseForSMS"].ToString();
                //childItem["UseForXzone"] = row["UseForXzone"].ToString();
                childItem["Level"] = level.ToString();

                dtReturnCommand.Rows.Add(childItem);
                LoadRolePermissionForCur(dtCommand, childItem, dtReturnCommand);
            }
            return dtReturnCommand;
        }
        public static void UpdateRolePermissionByPortalID(int roleid, int commandId, int portalId, bool view, bool add, bool update, bool delete)
        {
            DataCaching data = new DataCaching();
            data.RemoveCache("VmgPortal.Portal.Command.GetCommandsForRoleByPortalID");
            DataAccessProvider.Instance().UpdateRolePermissionByPortalID(commandId, roleid, portalId, view, add, update, delete);
        }
        public static void UpdateRolePermissionByPortalID(int roleid, int commandId, int portalId, bool web, bool wap, bool sms, bool xzone, bool view, bool add, bool update, bool delete)
        {
            DataCaching data = new DataCaching();
            data.RemoveCache("VmgPortal.Portal.Command.GetCommandsForRoleByPortalID");
            DataAccessProvider.Instance().UpdateRolePermissionByPortalID(commandId, roleid, portalId,web, wap,sms, xzone, view, add, update, delete);
        }
	}
}
