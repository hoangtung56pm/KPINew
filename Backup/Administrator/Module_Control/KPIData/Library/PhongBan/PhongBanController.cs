using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VmgPortal.Modules.KPIData.Library.Providers;
using System.Data;
using VmgPortal.Library.Components;
using VmgPortal.Library;
using VmgPortal.Library.Utilities;
using System.Web.UI.WebControls;

namespace VmgPortal.Modules.KPIData.Library.PhongBan
{
    public class PhongBanController
    {
        private const string key = "PhongBanController";
        public static DataTable GetAllNhomCongViec(int idBoPhan)
        {
            return DataAccessProvider.Instance().GetAllNhomCongViec(idBoPhan);
        }

        public static DataTable GetAll(int type)
        {
            return DataAccessProvider.Instance().GetAllPhong(type);
        }

        public static void Delete(int _id)
        {
            DataAccessProvider.Instance().DeletePhong(_id);
        }

        public static void DeleteNhomCongViec(int _id)
        {
            DataAccessProvider.Instance().DeleteNhomCongViec(_id);
        }
        
        public static int InsertNhomCongViec(NhomCongViecInfo _PhongBanInfo)
        {
            return DataAccessProvider.Instance().InsertNhomCongViec(_PhongBanInfo);
        }

        public static void UpdateNhomCongViec(NhomCongViecInfo _PhongBanInfo)
        {
            DataAccessProvider.Instance().UpdateNhomCongViec(_PhongBanInfo);
        }

        public static int Insert(PhongBanInfo _PhongBanInfo)
        {
            return DataAccessProvider.Instance().InsertPhong(_PhongBanInfo);
        }

        public static void Update(PhongBanInfo _PhongBanInfo)
        {
            DataAccessProvider.Instance().UpdatePhong(_PhongBanInfo);
        }

        public static NhomCongViecInfo GetInfoNhom(int _id)
        {
            return DataAccessProvider.Instance().GetInfoNhomCongViec(_id);
        }

        public static PhongBanInfo GetInfo(int _id)
        {
            return DataAccessProvider.Instance().GetInfoPhong(_id);
        }

        public static DataTable GetAllByParentID(int parentId,int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllByParentID(parentId, idTrungTam);
        }
        
        public static PhongBanInfo GetInfoCache(int _id)
        {
            string param = "PhongBanInfo_" + _id;
            DataCaching data = new DataCaching();
            PhongBanInfo infoPhong = (PhongBanInfo)data.GetHashCache(key, param);
            if (infoPhong != null) return infoPhong;
            infoPhong = DataAccessProvider.Instance().GetInfoPhong(_id);
            data.SetHashCache(key, param, AppEnv.GetTimeCacheExpire(), infoPhong);
            return infoPhong;
        }

        public static void LoadPhongBan(ListItemCollection lstItems, int idTrungTam)
        {
            DataTable dtZones = GetAllByParentID(0, idTrungTam);
            foreach (DataRow row in dtZones.Rows)
            {
                ListItem item = new ListItem(row["Ten"].ToString(), row["ID"].ToString());
                lstItems.Add(item);
                LoadForCurItem(lstItems, item, idTrungTam);
            }
        }

        public static void LoadForCurItem(ListItemCollection lstItems, ListItem curItem,int idTrungTam)
        {
            int curId = ConvertUtility.ToInt32(curItem.Value);
            int level = ConvertUtility.ToInt32(curItem.Attributes["Level"]);
            level++;
            DataTable dtChildZones = GetAllByParentID(curId, idTrungTam);
            if (dtChildZones == null) return;
            foreach (DataRow row in dtChildZones.Rows)
            {
                ListItem item = new ListItem(MiscUtility.StringIndent(level) + row["Ten"].ToString(), row["ID"].ToString());
                item.Attributes.Add("Level", level.ToString());
                lstItems.Add(item);
                LoadForCurItem(lstItems, item, idTrungTam);
            }
        }
    }
}