using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using VmgPortal.Modules.KPIData.Library.Providers;
using System.Web.UI.WebControls;
using VmgPortal.Library.Utilities;

namespace VmgPortal.Modules.KPIData.Library.DotDanhGia
{
    public class QuanLyCongViecKPIController
    {
        public static DataTable GetAll(int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllCongViecKPI(idTrungTam);
        }

        //public static DataRow[] GetRolePermissionByParentID(DataTable dtCommand, int parentID)
        //{
        //    DataRow[] retVal = null;
        //    retVal = dtCommand.Select("CommandParentID = " + parentID);
        //    return retVal;
        //}

        //public static DataTable BuildRecursiveRolePermission(DataTable dtCommand, DataTable dtReturnCommand, int roleid, int portalid)
        //{
        //    DataRow[] dtItems = GetRolePermissionByParentID(dtCommand, 0);
        //    foreach (DataRow row in dtItems)
        //    {
        //        DataRow rowItem = dtReturnCommand.NewRow();
        //        rowItem["CommandID"] = row["CommandID"].ToString();
        //        rowItem["PortalID"] = portalid.ToString();
        //        rowItem["CommandParentID"] = row["CommandParentID"].ToString();
        //        rowItem["RoleID"] = roleid.ToString();
        //        rowItem["CommandName"] = "<font color=\"Blue\">" + row["CommandName"].ToString() + "</font>";
        //        rowItem["Role_View"] = row["Role_View"].ToString();
        //        rowItem["Role_Add"] = row["Role_Add"].ToString();
        //        rowItem["Role_Update"] = row["Role_Update"].ToString();
        //        rowItem["Role_Delete"] = row["Role_Delete"].ToString();
        //        rowItem["UseForWeb"] = row["UseForWeb"].ToString();
        //        rowItem["UseForWap"] = row["UseForWap"].ToString();
        //        rowItem["UseForSMS"] = row["UseForSMS"].ToString();
        //        rowItem["UseForXzone"] = row["UseForXzone"].ToString();
        //        rowItem["Level"] = "0";

        //        dtReturnCommand.Rows.Add(rowItem);
        //        LoadRolePermissionForCur(dtCommand, rowItem, dtReturnCommand);
        //    }
        //    DataCaching data = new DataCaching();
        //    data.RemoveCache("VmgPortal.Portal.Command.GetCommandsForUserNotGroup");
        //    return dtReturnCommand;
        //}
        ///// <summary>
        ///// Load role permission for current item
        ///// </summary>
        ///// <param name="dtCommand"></param>
        ///// <param name="curItem"></param>
        ///// <param name="dtReturnCommand"></param>
        ///// <returns></returns>
        //public static DataTable LoadRolePermissionForCur(DataTable dtCommand, DataRow curItem, DataTable dtReturnCommand)
        //{
        //    int level = Convert.ToInt32(curItem["Level"]);
        //    level += 1;
        //    int _commandID = Convert.ToInt32(curItem["CommandID"]);
        //    DataRow[] dtChild = GetRolePermissionByParentID(dtCommand, _commandID);
        //    foreach (DataRow row in dtChild)
        //    {
        //        DataRow childItem = dtReturnCommand.NewRow();
        //        childItem["CommandID"] = row["CommandID"].ToString();
        //        childItem["CommandParentID"] = row["CommandParentID"].ToString();
        //        childItem["PortalID"] = row["PortalID"].ToString();
        //        childItem["RoleID"] = row["RoleID"].ToString();
        //        if (level == 1)
        //        {
        //            childItem["CommandName"] = MiscUtility.StringIndent(level) + "<font color=\"Red\">" + row["CommandName"].ToString() + "</font>";
        //        }
        //        else if (level == 2)
        //        {
        //            childItem["CommandName"] = MiscUtility.StringIndent(level) + "<font color=\"Orange\">" + row["CommandName"].ToString() + "</font>";
        //        }
        //        else if (level == 3)
        //        {
        //            childItem["CommandName"] = MiscUtility.StringIndent(level) + "<font color=\"Black\">" + row["CommandName"].ToString() + "</font>";
        //        }
        //        else if (level > 3)
        //        {
        //            childItem["CommandName"] = MiscUtility.StringIndent(level) + "<font color=\"Gray\">" + row["CommandName"].ToString() + "</font>";
        //        }
        //        childItem["Role_View"] = row["Role_View"].ToString();
        //        childItem["Role_Add"] = row["Role_Add"].ToString();
        //        childItem["Role_Update"] = row["Role_Update"].ToString();
        //        childItem["Role_Delete"] = row["Role_Delete"].ToString();
        //        childItem["UseForWeb"] = row["UseForWeb"].ToString();
        //        childItem["UseForWap"] = row["UseForWap"].ToString();
        //        childItem["UseForSMS"] = row["UseForSMS"].ToString();
        //        childItem["UseForXzone"] = row["UseForXzone"].ToString();
        //        childItem["Level"] = level.ToString();

        //        dtReturnCommand.Rows.Add(childItem);
        //        LoadRolePermissionForCur(dtCommand, childItem, dtReturnCommand);
        //    }
        //    return dtReturnCommand;
        //}

        public static DataTable GetAllByParentID(int parentId, int idTrungTam, int idPhongBan)
        {
            return DataAccessProvider.Instance().GetAllByParentID(parentId, idTrungTam, idPhongBan);
        }

        public static void Delete(int _id)
        {
            DataAccessProvider.Instance().DeleteCongViecKPI(_id);
        }

        public static int Insert(QuanLyCongViecKPIInfo _QuanLyCongViecKPIInfo)
        {
            return DataAccessProvider.Instance().InsertCongViecKPI(_QuanLyCongViecKPIInfo);
        }

        public static void Update(QuanLyCongViecKPIInfo _QuanLyCongViecKPIInfo)
        {
            DataAccessProvider.Instance().UpdateCongViecKPI(_QuanLyCongViecKPIInfo);
        }
        public static void SetPriority(int id, int order)
        {
            DataAccessProvider.Instance().SetPriority(id, order);
        }
        
        public static QuanLyCongViecKPIInfo GetInfo(int _id)
        {
            return DataAccessProvider.Instance().GetInfoCongViecKPI(_id);
        }

        public static void LoadCongViec(ListItemCollection lstItems, int idTrungTam, int idPhongBan)
        {
            DataTable dtZones = GetAllByParentID(0, idTrungTam, idPhongBan);
            foreach (DataRow row in dtZones.Rows)
            {
                ListItem item = new ListItem("(" + row["TyTrong"].ToString() + "%) " + row["Ten"].ToString(), row["ID"].ToString());
                item.Attributes.Add("Level", "0");
                item.Attributes.Add("style", "font-weight:bold");
                lstItems.Add(item);
                LoadForCurItem(lstItems, item, idTrungTam, idPhongBan);
            }
        }

        public static void LoadForCurItem(ListItemCollection lstItems, ListItem curItem, int idTrungTam, int idPhongBan)
        {
            int curId = ConvertUtility.ToInt32(curItem.Value);
            int level = ConvertUtility.ToInt32(curItem.Attributes["Level"]);
            level++;
            DataTable dtChildZones = GetAllByParentID(curId, idTrungTam, idPhongBan);
            if (dtChildZones == null) return;
            foreach (DataRow row in dtChildZones.Rows)
            {
                ListItem item = new ListItem(MiscUtility.StringIndent(level) + "(" + row["TyTrong"].ToString() + "%) " + row["Ten"].ToString() , row["ID"].ToString());
                item.Attributes.Add("Level", level.ToString());
                lstItems.Add(item);
                LoadForCurItem(lstItems, item, idTrungTam, idPhongBan);
            }
        }

        public static DataTable LoadCongViecForExport(DataTable dt, int idTrungTam, int idPhongBan)
        {
            DataTable dtZones = GetAllByParentID(0, idTrungTam, idPhongBan);
            foreach (DataRow row in dtZones.Rows)
            {
                DataRow _row = dt.NewRow();

                _row["ID"] = row["ID"].ToString();
                _row["Ten"] = row["Ten"].ToString();
                _row["TyTrong"] = row["TyTrong"].ToString();
                _row["KeHoach"] = row["KeHoach"].ToString();
                _row["DonViDo"] = row["DonViDo"].ToString();                   
                _row["Level"] = "0";
                _row["Bold"] = "1";

                dt.Rows.Add(_row);
                LoadForCurItemForExport(dt, _row, idTrungTam, idPhongBan);
            }
            return dt;
        }

        public static void LoadForCurItemForExport(DataTable dt, DataRow curItem, int idTrungTam, int idPhongBan)
        {
            int curId = ConvertUtility.ToInt32(curItem["ID"]);
            int level = ConvertUtility.ToInt32(curItem["Level"]);
            level++;
            DataTable dtChildZones = GetAllByParentID(curId, idTrungTam, idPhongBan);
            if (dtChildZones == null) return;
            foreach (DataRow row in dtChildZones.Rows)
            {
                DataRow _row = dt.NewRow();

                _row["ID"] = row["ID"].ToString();
                _row["Ten"] = MiscUtility.StringIndent(level) + row["Ten"].ToString();
                _row["TyTrong"] = row["TyTrong"].ToString();
                _row["KeHoach"] = row["KeHoach"].ToString();
                _row["DonViDo"] = row["DonViDo"].ToString(); 
                _row["Level"] = level;
                _row["Bold"] = "0";

                dt.Rows.Add(_row);
                LoadForCurItemForExport(dt, _row, idTrungTam, idPhongBan);
            }
        }

        public static void LoadCongViecChuaDuocGiao(ListItemCollection lstItems, int idTrungTam, int idPhongBan, int idDotDanhGia)
        {
            DataTable dtZones = GetAllByParentID(0, idTrungTam, idPhongBan);
            foreach (DataRow row in dtZones.Rows)
            {
                DataTable dt = DotDanhGiaController.GetAllNhanVienTheoCongViec(ConvertUtility.ToInt32(row["ID"].ToString()), idDotDanhGia);
                ListItem item;
                
                if (dt != null && dt.Rows.Count > 0 && ConvertUtility.ToInt32(dt.Rows[0][0]) > 0)
                {
                    item = new ListItem("(" + row["TyTrong"].ToString() + "%) " + row["Ten"].ToString(), row["ID"].ToString());
                    item.Attributes.Add("Level", "0");
                    item.Attributes.Add("style", "font-weight:bold;");
                    lstItems.Add(item);
                }
                else
                {
                    item = new ListItem("(" + row["TyTrong"].ToString() + "%) " + row["Ten"].ToString(), row["ID"].ToString());
                    item.Attributes.Add("Level", "0");
                    item.Attributes.Add("style", "font-weight:bold;color:red");
                    lstItems.Add(item);
                }

                LoadForCurItemChuaDuocGiao(lstItems, item, idTrungTam, idPhongBan, idDotDanhGia);
            }
        }

        public static void LoadForCurItemChuaDuocGiao(ListItemCollection lstItems, ListItem curItem, int idTrungTam, int idPhongBan, int idDotDanhGia)
        {
            int curId = ConvertUtility.ToInt32(curItem.Value);
            int level = ConvertUtility.ToInt32(curItem.Attributes["Level"]);
            level++;
            DataTable dtChildZones = GetAllByParentID(curId, idTrungTam, idPhongBan);
            if (dtChildZones == null) return;
            foreach (DataRow row in dtChildZones.Rows)
            {
                DataTable dt = DotDanhGiaController.GetAllNhanVienTheoCongViec(ConvertUtility.ToInt32(row["ID"].ToString()), idDotDanhGia);
                ListItem item;
                if (dt != null && dt.Rows.Count > 0 && ConvertUtility.ToInt32(dt.Rows[0][0]) > 0)
                {
                    item = new ListItem(MiscUtility.StringIndent(level) + "(" + row["TyTrong"].ToString() + "%) " + row["Ten"].ToString(), row["ID"].ToString());
                    item.Attributes.Add("Level", level.ToString());
                    //item.Attributes.Add("style", "color:red");
                    lstItems.Add(item);
                }
                else
                {
                    item = new ListItem(MiscUtility.StringIndent(level) + "(" + row["TyTrong"].ToString() + "%) " + row["Ten"].ToString(), row["ID"].ToString());
                    item.Attributes.Add("Level", level.ToString());
                    item.Attributes.Add("style", "color:red");
                    lstItems.Add(item);
                }

                LoadForCurItemChuaDuocGiao(lstItems, item, idTrungTam, idPhongBan, idDotDanhGia);
            }
        }
    }
}