using System.Data;
using System.Web.UI.WebControls;

using VmgPortal.Library.Components.Providers;
using VmgPortal.Library.Utilities;

namespace VmgPortal.Library.Components.Commands
{
	public class CommandController
	{
        static string key = "VmgPortal.Portal.Command";
		public static DataTable GetCommands()
		{
            //string param = "GetCommands";
            //DataCaching data = new DataCaching();
            //DataTable dtCommands = (DataTable)data.GetHashCache(key, param);
            //if (dtCommands != null) return dtCommands;
            //dtCommands = DataAccessProvider.Instance().GetCommands();
            //data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtCommands);
            //return dtCommands;

            return DataAccessProvider.Instance().GetCommands();
		}
       
		public static DataTable GetCommands(int parent)
		{
            //string param = "GetCommandsByParent_" + parent;
            //DataCaching data = new DataCaching();
            //DataTable dtCommands = (DataTable)data.GetHashCache(key, param);
            //if (dtCommands != null) return dtCommands;
            //dtCommands = DataAccessProvider.Instance().GetCommands(parent);
            //data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtCommands);
            //return dtCommands;

            return DataAccessProvider.Instance().GetCommands(parent);
		}
        public static DataTable GetCommandByCmdId(int commandid)
        {
            string param = "GetCommandByCmdId_" + commandid;
            DataCaching data = new DataCaching();
            DataTable dtCommands = (DataTable)data.GetHashCache(key, param);
            if (dtCommands != null) return dtCommands;
            dtCommands = DataAccessProvider.Instance().GetCommandByCmdId(commandid);
            data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtCommands);
            return dtCommands;

            //return DataAccessProvider.Instance().GetCommandByCmdId(commandid);
        }
        
        public static DataTable GetCommandsForUserNotGroup(int userId, int portalId)
        {
            string param = "GetCommandsForUserNotGroup?" + userId.ToString() + "&portalid=" + portalId;
            DataCaching data = new DataCaching();
            DataTable dtCommands = (DataTable)data.GetHashCache(key, param);
            if (dtCommands != null) return dtCommands;
            dtCommands = DataAccessProvider.Instance().GetCommandsForUserNotGroup(userId, portalId);
            data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtCommands);
            return dtCommands;
        }
        public static DataTable GetCommandsForRoleByPortalID(int roleId,int portalId)
        {
            //string param = "GetCommandsForRoleByPortalID?" + roleId.ToString() + "&portalid=" + portalId;
            //DataCaching data = new DataCaching();
            DataTable dtCommands = null;// (DataTable)data.GetHashCache(key, param);
            //if (dtCommands != null) return dtCommands;
            dtCommands = DataAccessProvider.Instance().GetCommandsForRoleByPortalID(roleId, portalId);
            //data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtCommands);
            return dtCommands;
        }


        public static DataTable GetRoleForUserByPortalID(int userId, int portalId)
        {
            //string param = "GetButtonRoleForUserByPortalID?" + userId.ToString() + "&portalid=" + portalId;
            //DataCaching data = new DataCaching();
            DataTable dtCommands = null;// (DataTable)data.GetHashCache(key, param);
            //if (dtCommands != null) return dtCommands;
            dtCommands = DataAccessProvider.Instance().GetButtonRoleForUserByPortalID(userId, portalId);
            //data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtCommands);
            return dtCommands;
        }
        public static DataTable GetCommandsForUserByPortalID(int userId, int portalId)
        {
            //string param = "GetCommandsForUserByPortalID?" + userId.ToString() + "&portalid=" + portalId;
            //DataCaching data = new DataCaching();
            DataTable dtCommands = null;// (DataTable)data.GetHashCache(key, param);
            //if (dtCommands != null) return dtCommands;
            dtCommands = DataAccessProvider.Instance().GetCommandsForUserByPortalID(userId, portalId);
            //data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtCommands);
            return dtCommands;
        }
       
		public static int AddCommand(CommandInfo command)
		{
			int id = DataAccessProvider.Instance().AddCommand(command);
            DataCaching data = new DataCaching();           
            data.RemoveCache(key);
			return id;
		}
		public static void UpdateCommand(CommandInfo command)
		{
			DataAccessProvider.Instance().UpdateCommand(command);
            DataCaching data = new DataCaching();
            data.RemoveCache(key);
		}
        public static void AddCommandByLang(CommandInfo command, string lang)
        {
            DataAccessProvider.Instance().AddCommandByLang(command, lang);
            DataCaching data = new DataCaching();
            data.RemoveCache(key);     
        }
        public static void UpdateCommandByLang(CommandInfo command, string lang)
        {
            DataAccessProvider.Instance().UpdateCommandByLang(command, lang);
            DataCaching data = new DataCaching();
            data.RemoveCache(key);
        }
		public static void DeleteCommand(int commandId)
		{            
			DataAccessProvider.Instance().DeleteCommand(commandId);
            DataCaching data = new DataCaching();
            data.RemoveCache(key);		
		}
        public static CommandInfo GetCommandByLang(int commandId)
        {
            return DataAccessProvider.Instance().GetCommandByLang(commandId);
        }
		public static CommandInfo GetCommand(int commandId)
		{
			return DataAccessProvider.Instance().GetCommand(commandId);
		}
        public static CommandInfo GetCommandWithoutControlPath(int commandId)
		{
            return DataAccessProvider.Instance().GetCommandWithoutControlPath(commandId);
		}
        
		public static CommandInfo GetCommand(string commandKey)
		{
            string param = "GetCommand?key" + commandKey;
            DataCaching data = new DataCaching();
            CommandInfo _CommandInfo = (CommandInfo)data.GetHashCache(key, param);
            if (_CommandInfo != null) return _CommandInfo;
            _CommandInfo = DataAccessProvider.Instance().GetCommand(commandKey);
            data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), _CommandInfo);
            return _CommandInfo;
		}
        //public static bool IsAvailableForUser(int commandId, int userId)
        //{
        //    return DataAccessProvider.Instance().IsAvailableForUser(commandId, userId);
        //}
        public static bool IsAvailableForUser(int commandId, int userId, int portalid)
        {
            return DataAccessProvider.Instance().IsAvailableForUser(commandId, userId, portalid);
        }
		public static void FillToListBox(ListItemCollection lstItems, DataTable source, int rootId, bool superUser)
		{
			DataRow[] drCommands = source.Select("CommandParentID = " + rootId);
			foreach(DataRow row in drCommands)
			{
				if (!superUser && (bool)row["IsSuperUser"]) continue;
				ListItem rootItem = new ListItem(row["CommandName"].ToString(), row["CommandID"].ToString());
				rootItem.Attributes.Add("Level","0");
				lstItems.Add(rootItem);
				LoadForCurListItem(lstItems, rootItem, source, superUser);
			}
			lstItems.Insert(0, new ListItem("Root","0"));
		}
		private static void LoadForCurListItem(ListItemCollection lstItems, ListItem curItem, DataTable source, bool superUser)
		{
			
			int curCommandId = ConvertUtility.ToInt32(curItem.Value);
			int level = ConvertUtility.ToInt32(curItem.Attributes["Level"]);
			level++;
			DataRow[] drChildCommands = source.Select("CommandParentID = " + curCommandId);
			foreach(DataRow row in drChildCommands)
			{
				if (!superUser && (bool)row["IsSuperUser"]) continue;
				ListItem item = new ListItem(MiscUtility.StringIndent(level) + row["CommandName"].ToString(), row["CommandID"].ToString());
				item.Attributes.Add("Level",level.ToString());
				lstItems.Add(item);
				LoadForCurListItem(lstItems, item, source, superUser);
			}
		}
      
	}
}
