using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using Telerik.WebControls;
using VmgPortal.Library.Components.Providers;
using VmgPortal.Library.Utilities;
using System.Web;

namespace VmgPortal.Library.Components.Portal
{
    public class PortalController
    {
        private const string key = "VmgPortal.Portal.Portal";

        public static Portal_PortalsInfo GetPortalsInfoByLang(int portalId)
        {
            Portal_PortalsInfo portalsInfo = DataAccessProvider.Instance().GetPortalsInfoByLang(portalId);
            return portalsInfo;
        }

        public static DataTable GetPortalsById(int portalId)
        {
            return DataAccessProvider.Instance().GetPortalsById(portalId);
        }
        public static DataTable GetPortalsByParentId(int portal_ParentId)
        {
            string param = "GetPortalsByParentId?" + portal_ParentId.ToString() + "&" + AppEnv.GetLanguage();
            DataCaching data = new DataCaching();
            DataTable dt = (DataTable)data.GetHashCache(key, param);
            if (dt != null)  return dt;
            dt = DataAccessProvider.Instance().GetPortalsByParentId(portal_ParentId);
            data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dt);
            return dt;
        }
        public static DataTable GetPortalsByParentId(int userId,int portal_ParentId)
        {
            string param = "GetPortalsByParentId?userid=" + userId + "&portalId=" + portal_ParentId.ToString() + "&" + AppEnv.GetLanguage();
            DataCaching data = new DataCaching();
            DataTable dt = (DataTable)data.GetHashCache(key, param);
            if (dt != null) return dt;
            dt = DataAccessProvider.Instance().GetPortalsByParentId(userId,portal_ParentId);
            data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dt);
            return dt;
        }
        public static void LoadPortalsForRadComboByUserID(ListItemCollection lstItems, int userId)
        {
            DataTable dtPortals = GetPortals(userId, AppEnv.GetLanguage());
            foreach (DataRow row in dtPortals.Rows)
            {
                ListItem item = new ListItem(row["Portal_Name"].ToString(), row["PortalID"].ToString());
                item.Attributes.Add("Level", "0");
                lstItems.Add(item);
                LoadForCurItemForRadCombo(lstItems, item, userId);
            }
        }
        public static void LoadPortalsForRadCombo(ListItemCollection lstItems)
        {
            DataTable dtPortals = GetPortalsByParentId(0);
            foreach (DataRow row in dtPortals.Rows)
            {
                ListItem item = new ListItem(row["Portal_Name"].ToString(), row["PortalID"].ToString());
                item.Attributes.Add("Level", "0");
                lstItems.Add(item);
                LoadForCurItemForRadCombo(lstItems, item);
            }
        }
        public static void LoadForCurItemForRadCombo(ListItemCollection lstItems, ListItem curItem, int userId)
        {
            int curId = ConvertUtility.ToInt32(curItem.Value);
            int level = ConvertUtility.ToInt32(curItem.Attributes["Level"]);
            level++;
            DataTable dtChildZones = GetPortalsByParentId(userId, curId);
            foreach (DataRow row in dtChildZones.Rows)
            {
                ListItem item = new ListItem(MiscUtility.StringIndent(level) + row["Portal_Name"].ToString(), row["PortalID"].ToString());
                item.Attributes.Add("Level", level.ToString());
                lstItems.Add(item);
                LoadForCurItemForRadCombo(lstItems, item, userId);
            }
        }
        public static void LoadForCurItemForRadCombo(ListItemCollection lstItems, ListItem curItem)
        {
            int curId = ConvertUtility.ToInt32(curItem.Value);
            int level = ConvertUtility.ToInt32(curItem.Attributes["Level"]);
            level++;
            DataTable dtChildZones = GetPortalsByParentId(curId);
            foreach (DataRow row in dtChildZones.Rows)
            {
                ListItem item = new ListItem(MiscUtility.StringIndent(level) + row["Portal_Name"].ToString(), row["PortalID"].ToString());
                item.Attributes.Add("Level", level.ToString());
                lstItems.Add(item);
                LoadForCurItemForRadCombo(lstItems, item);
            }
        }
        public static void LoadPortalsForUserID(ListItemCollection lstItems, int userId)
        {
            DataTable dtPortals = GetPortals(userId, AppEnv.GetLanguage());
            foreach (DataRow row in dtPortals.Rows)
            {
                ListItem item = new ListItem(row["Portal_Name"].ToString(), row["PortalID"].ToString());
                item.Attributes.Add("Level", "0");
                lstItems.Add(item);
                LoadForCurItem(lstItems, item, userId);
            }
        }
        public static void LoadPortals(ListItemCollection lstItems)
        {
            DataTable dtPortals = GetPortalsByParentId(0);
            foreach (DataRow row in dtPortals.Rows)
            {
                ListItem item = new ListItem(row["Portal_Name"].ToString(), row["PortalID"].ToString());
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
            DataTable dtChildZones = GetPortalsByParentId(curId);
            foreach (DataRow row in dtChildZones.Rows)
            {
                ListItem item = new ListItem(MiscUtility.StringIndent(level) + row["Portal_Name"].ToString(), row["PortalID"].ToString());
                item.Attributes.Add("Level", level.ToString());
                lstItems.Add(item);
                LoadForCurItem(lstItems, item);
            }
        }
        public static void LoadForCurItem(ListItemCollection lstItems, ListItem curItem, int userId)
        {
            int curId = ConvertUtility.ToInt32(curItem.Value);
            int level = ConvertUtility.ToInt32(curItem.Attributes["Level"]);
            level++;
            DataTable dtChildZones = GetPortalsByParentId(userId, curId);
            foreach (DataRow row in dtChildZones.Rows)
            {
                ListItem item = new ListItem(MiscUtility.StringIndent(level) + row["Portal_Name"].ToString(), row["PortalID"].ToString());
                item.Attributes.Add("Level", level.ToString());
                lstItems.Add(item);
                LoadForCurItem(lstItems, item, userId);
            }
        }
        public static DataTable GetPortals()
        {
            //string param = "GetPortals";
            //DataCaching data = new DataCaching();
            //DataTable dtPortals = (DataTable)data.GetHashCache(key, param);
            //if (dtPortals != null) return dtPortals;
            DataTable dtPortals = DataAccessProvider.Instance().GetPortals();
            //data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtPortals);
            return dtPortals;
        }

        public static DataTable GetPortals(int _userid, string _lang)
        {
            string param = "GetPortals?userid=" + _userid + "&lang=" + _lang;
            DataCaching data = new DataCaching();
            DataTable dtPortals = (DataTable)data.GetHashCache(key, param);
            if (dtPortals != null) return dtPortals;
            dtPortals = DataAccessProvider.Instance().GetPortalsByUserIDAndLang(_userid, _lang);
            data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtPortals);
            return dtPortals;
        }
        public static DataTable GetPortalsByLang(string _lang)
        {
            string param = "GetPortalsByLang" + _lang;
            DataCaching data = new DataCaching();
            DataTable dtPortals = (DataTable)data.GetHashCache(key, param);
            if (dtPortals != null) return dtPortals;
            dtPortals = DataAccessProvider.Instance().GetPortalsByLang(_lang);
            data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), dtPortals);
            return dtPortals;
        }
        public static void DeletePortal(int portalId)
        {
            DataCaching data = new DataCaching();
            data.RemoveCache(key);
            DataAccessProvider.Instance().DeletePortal(portalId);            
        }
        public static int AddPortal(Portal_PortalsInfo portal)
        { 
           DataCaching data = new DataCaching();
           data.RemoveCache(key); 
           return DataAccessProvider.Instance().AddPortal(portal);
                     
        }
        public static void AddPortalFollowLang(Portal_PortalsInfo portal)
        {
            DataAccessProvider.Instance().AddPortalFollowLang(portal);
            DataCaching data = new DataCaching();
            data.RemoveCache(key);            
        }
        public static void UpdatePortal(Portal_PortalsInfo portal)
        {
            DataAccessProvider.Instance().UpdatePortal(portal);
            DataCaching data = new DataCaching();
            data.RemoveCache(key);
        }

        public static DataRow[] GetPortalByParentID(DataTable dtPortal, int parentID)
        {
            DataRow[] retVal = null;
            retVal = dtPortal.Select("Portal_ParentId = " + parentID);
            return retVal;
        }
        public static DataTable GetPortalByParentID(DataTable dtPortal, DataTable dtReturnPortal)
        {
            DataRow[] dtItems = GetPortalByParentID(dtPortal, 0);
            foreach (DataRow row in dtItems)
            {
                DataRow rowItem = dtReturnPortal.NewRow();

                rowItem["PortalID"] = row["PortalID"].ToString();
                rowItem["Portal_Name"] = row["Portal_Name"];
                rowItem["Portal_Description"] = row["Portal_Description"];
                rowItem["Portal_ParentId"] = row["Portal_ParentId"];
                rowItem["Level"] = "0";

                dtReturnPortal.Rows.Add(rowItem);
                LoadPortalForCur(dtPortal, rowItem, dtReturnPortal);
            }
            return dtReturnPortal;
        }
        public static DataTable LoadPortalForCur(DataTable dtPortal, DataRow curItem, DataTable dtReturnPortal)
        {
            int level = Convert.ToInt32(curItem["Level"]);
            level += 1;
            int _portalID = Convert.ToInt32(curItem["PortalID"]);
            DataRow[] dtChild = GetPortalByParentID(dtPortal, _portalID);
            foreach (DataRow row in dtChild)
            {
                DataRow childItem = dtReturnPortal.NewRow();

                childItem["PortalID"] = row["PortalID"].ToString();
                childItem["Portal_Description"] = row["Portal_Description"];
                childItem["Portal_ParentId"] = row["Portal_ParentId"];
                childItem["Portal_Name"]  = MiscUtility.StringIndent(level) + row["Portal_Name"].ToString();
                childItem["Level"] = level;
                dtReturnPortal.Rows.Add(childItem);
                LoadPortalForCur(dtPortal, childItem, dtReturnPortal);
            }
            return dtReturnPortal;
        }

        public static void LoadPortalsForRadComboByUserIDGenLi(Literal ltrItems, HttpRequest hpcontext, int userId)
        {
            StringBuilder _sb = new StringBuilder();
            DataTable dtPortals = GetPortals(userId, AppEnv.GetLanguage());
            string fmItem = "<li><a href=\"{0}\">{1}</a></li>";
            foreach (DataRow row in dtPortals.Rows)
            {
                string _lnk = MiscUtility.UpdateQueryStringItem(hpcontext, "portalid", row["PortalID"].ToString());
                _sb.Append(string.Format(fmItem, _lnk, row["Portal_Name"].ToString()));
            }
            ltrItems.Text = _sb.ToString();
        }

        public static void LoadPortalsForRadComboLi(Literal ltrItems, HttpRequest hpcontext)
        {
            StringBuilder _sb = new StringBuilder();
            DataTable dtPortals = GetPortalsByParentId(0);
            string fmItem = "<li><a href=\"{0}\">{1}</a></li>";
            foreach (DataRow row in dtPortals.Rows)
            {
                string _lnk = MiscUtility.UpdateQueryStringItem(hpcontext, "portalid", row["PortalID"].ToString());
                _sb.Append(string.Format(fmItem, _lnk, row["Portal_Name"].ToString()));
            }
            ltrItems.Text = _sb.ToString();
        }
    }
}
