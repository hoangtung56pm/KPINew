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
    public class QuanLyCongViecKTXVaPSController
    {
        public static DataTable GetAll(int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllCongViecKPI(idTrungTam);
        }

        public static DataTable GetAll(int idTrungTam, int idPhongBan, int loai)
        {
            return DataAccessProvider.Instance().GetAllCongViecKPI(idTrungTam, idPhongBan, loai);
        }

        //public static DataTable GetAllByParentID(int parentId, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia)
        //{
        //    return DataAccessProvider.Instance().GetAllByParentIDKTXVaPS(parentId, idTrungTam, idPhongBan, loai, idDotDanhGia);
        //}

        public static DataTable GetAllByParentIDNew(int parentId, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia)
        {
            return DataAccessProvider.Instance().GetAllByParentIDKTXVaPSNew(parentId, idTrungTam, 0, loai, idDotDanhGia);

        }
        public static void Delete(int _id)
        {
            DataAccessProvider.Instance().DeleteCongViecKTXVaPS(_id);
        }
        public static void Delete(int _id, int idDotDanhGia)
        {
            DataAccessProvider.Instance().DeleteCongViecKTXVaPS(_id, idDotDanhGia);
        }

        public static void DeleteAll(int idTrungTam, int loai, int idDotDanhGia)
        {
            DataAccessProvider.Instance().DeleteAll(idTrungTam, loai, idDotDanhGia);
        }
        public static DataTable KeHoachThang_BaoCaoNgayByCongViecTT(int idCongViec, int idDotDanhGia, DateTime ngay)
        {
            return DataAccessProvider.Instance().KeHoachThang_BaoCaoNgayByCongViecTT(idCongViec, idDotDanhGia, ngay);
        }
        public static DataTable KeHoachThang_GetCongViecCamKetHT(int idCongViec, int idDotDanhGia)
        {
            return DataAccessProvider.Instance().KeHoachThang_GetCongViecCamKetHT(idCongViec, idDotDanhGia);
        }


        public static DataTable KeHoachThang_BaoCaoNgayByCongViecTK(int idCongViec, int idDotDanhGia, DateTime ngay)
        {
            return DataAccessProvider.Instance().KeHoachThang_BaoCaoNgayByCongViecTK(idCongViec, idDotDanhGia, ngay);
        }
        public static int Insert(QuanLyCongViecKTXVaPSInfo _QuanLyCongViecKPIInfo)
        {
            return DataAccessProvider.Instance().InsertCongViecKTXVaPS(_QuanLyCongViecKPIInfo);
        }
        public static int Insert_6_11_2014(QuanLyCongViecKTXVaPSInfo _QuanLyCongViecKPIInfo)
        {
            return DataAccessProvider.Instance().InsertCongViecKTXVaPS_6_11_2014(_QuanLyCongViecKPIInfo);
        }
        public static void Update(QuanLyCongViecKTXVaPSInfo _QuanLyCongViecKPIInfo)
        {
            DataAccessProvider.Instance().UpdateCongViecKTXVaPS(_QuanLyCongViecKPIInfo);
        }
        public static void SetPriority(int id, int order)
        {
            DataAccessProvider.Instance().SetPriorityKTXVaPS(id, order);
        }

        public static QuanLyCongViecKTXVaPSInfo GetInfo(int _id)
        {
            return DataAccessProvider.Instance().GetInfoCongViecKTXVaPS(_id);
        }

        public static QuanLyCongViecKTXVaPSInfo GetInfoByOldID(int _id)
        {
            return DataAccessProvider.Instance().GetInfoCongViecKTXVaPSByOldID(_id);
        }
        public static void LoadCongViec(ListItemCollection lstItems, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia)
        {
            DataTable dtZones = GetAllByParentIDNew(0, idTrungTam, idPhongBan, loai, idDotDanhGia);
            foreach (DataRow row in dtZones.Rows)
            {
                //ListItem item = new ListItem("(" + Math.Round(ConvertUtility.ToDouble(row["TyTrong"].ToString()),3) + "%) " + row["Ten"].ToString(), row["ID"].ToString());
                ListItem item = new ListItem(row["Ten"].ToString(), row["ID"].ToString());
                item.Attributes.Add("Level", "0");
                //item.Attributes.Add("style", "font-weight:bold; color:red");
                lstItems.Add(item);
                LoadForCurItem(lstItems, item, idTrungTam, idPhongBan, loai, idDotDanhGia);
            }
        }

        public static void LoadForCurItem(ListItemCollection lstItems, ListItem curItem, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia)
        {
            int curId = ConvertUtility.ToInt32(curItem.Value);
            int level = ConvertUtility.ToInt32(curItem.Attributes["Level"]);
            level++;
            DataTable dtChildZones = GetAllByParentIDNew(curId, idTrungTam, idPhongBan, loai, idDotDanhGia);
            if (dtChildZones == null) return;
            foreach (DataRow row in dtChildZones.Rows)
            {
                //ListItem item = new ListItem(MiscUtility.StringIndent(level) + "(" + Math.Round(ConvertUtility.ToDouble(row["TyTrong"].ToString()), 3) + "%) " + row["Ten"].ToString(), row["ID"].ToString());
                ListItem item = new ListItem(MiscUtility.StringIndent(level) + row["Ten"].ToString(), row["ID"].ToString());
                item.Attributes.Add("Level", level.ToString());
                lstItems.Add(item);
                LoadForCurItem(lstItems, item, idTrungTam, idPhongBan, loai, idDotDanhGia);
            }
        }

        public static DataTable LoadCongViecForExport(DataTable dt, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia)
        {
            DataTable dtZones = GetAllByParentIDNew(0, idTrungTam, idPhongBan, loai, idDotDanhGia);
            foreach (DataRow row in dtZones.Rows)
            {
                DataRow _row = dt.NewRow();

                _row["ID"] = row["ID"].ToString();
                _row["Ten"] = row["Ten"].ToString();
                _row["TyTrong"] = ConvertUtility.ToString(row["TyTrong"]).ToString().Replace(",", ".");
                _row["SoGio"] = Math.Round(ConvertUtility.ToDouble(row["SoGio"]), 3).ToString();
                _row["KeHoach"] = row["KeHoach"].ToString();
                _row["DonViDo"] = row["DonViDo"].ToString();
                _row["Level"] = "0";
                _row["Bold"] = "1";
                _row["Ma"] = row["Ma"].ToString();

                dt.Rows.Add(_row);
                LoadForCurItemForExport(dt, _row, idTrungTam, idPhongBan, loai, idDotDanhGia);
            }
            return dt;
        }

        public static void LoadForCurItemForExport(DataTable dt, DataRow curItem, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia)
        {
            int curId = ConvertUtility.ToInt32(curItem["ID"]);
            int level = ConvertUtility.ToInt32(curItem["Level"]);
            level++;
            DataTable dtChildZones = GetAllByParentIDNew(curId, idTrungTam, idPhongBan, loai, idDotDanhGia);
            if (dtChildZones == null) return;
            foreach (DataRow row in dtChildZones.Rows)
            {
                DataRow _row = dt.NewRow();

                _row["ID"] = row["ID"].ToString();
                _row["Ten"] = MiscUtility.StringIndent(level) + row["Ten"].ToString();
                _row["TyTrong"] = ConvertUtility.ToString(row["TyTrong"]).ToString().Replace(",", ".");
                _row["SoGio"] = Math.Round(ConvertUtility.ToDouble(row["SoGio"]), 3).ToString();
                _row["KeHoach"] = row["KeHoach"].ToString();
                _row["DonViDo"] = row["DonViDo"].ToString();
                _row["Level"] = level;
                _row["Bold"] = "0";
                _row["Ma"] = row["Ma"].ToString();
                dt.Rows.Add(_row);
                LoadForCurItemForExport(dt, _row, idTrungTam, idPhongBan, loai, idDotDanhGia);
            }
        }

        public static DataTable LoadCongViecForView(int idCongViec, DataTable dt, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia)
        {
            DataTable dtZones = GetAllByParentIDNew(idCongViec, idTrungTam, idPhongBan, loai, idDotDanhGia);
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
                LoadForCurItemForView(idCongViec, dt, _row, idTrungTam, idPhongBan, loai, idDotDanhGia);
            }
            return dt;
        }

        public static void LoadForCurItemForView(int idCongViec, DataTable dt, DataRow curItem, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia)
        {
            int curId = ConvertUtility.ToInt32(curItem["ID"]);
            int level = ConvertUtility.ToInt32(curItem["Level"]);
            level++;
            DataTable dtChildZones = GetAllByParentIDNew(curId, idTrungTam, idPhongBan, loai, idDotDanhGia);
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
                LoadForCurItemForView(idCongViec, dt, _row, idTrungTam, idPhongBan, loai, idDotDanhGia);
            }
        }

        private static DataRow[] GetCongViecByParentID(DataTable dtCongViec, int parentID)
        {
            DataRow[] retVal = null;
            retVal = dtCongViec.Select("ParentID = " + parentID);
            return retVal;
        }

        public static void LoadCongViecChuaDuocGiao(ListItemCollection lstItems, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia)
        {
            DataTable dtCongViec = GetAllByParentIDNew(0, idTrungTam, idPhongBan, loai, idDotDanhGia);
            foreach (DataRow row in dtCongViec.Rows)
            {
                DataTable dtChildLevel = GetAllByParentIDNew(ConvertUtility.ToInt32(row["ID"].ToString()), idTrungTam, idPhongBan, loai, idDotDanhGia);

                ListItem item;
                if (dtChildLevel.Rows.Count > 0)
                {
                    item = new ListItem(row["Ten"].ToString(), row["ID"].ToString() + "_1");
                    item.Attributes.Add("Level", "0");
                    item.Attributes.Add("HasChild", "1");
                    item.Attributes.Add("style", "font-weight:bold;color:red");
                }
                else
                {
                    item = new ListItem(row["Ten"].ToString(), row["ID"].ToString() + "_0");
                    item.Attributes.Add("Level", "0");
                    item.Attributes.Add("HasChild", "0");
                }

                lstItems.Add(item);

                LoadForCurItemChuaDuocGiao(lstItems, item, idTrungTam, idPhongBan, loai, idDotDanhGia);
            }
        }

        public static void LoadForCurItemChuaDuocGiao(ListItemCollection lstItems, ListItem curItem, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia)
        {
            string[] arr = curItem.Value.Split('_');
            int curId = ConvertUtility.ToInt32(arr[0]);
            int hasChild = ConvertUtility.ToInt32(arr[1]);

            int level = ConvertUtility.ToInt32(curItem.Attributes["Level"]);
            level++;
            DataTable dtCongViec = GetAllByParentIDNew(curId, idTrungTam, idPhongBan, loai, idDotDanhGia);
            if (dtCongViec == null) return;
            foreach (DataRow row in dtCongViec.Rows)
            {
                DataTable dtChildLevel = GetAllByParentIDNew(ConvertUtility.ToInt32(row["ID"].ToString()), idTrungTam, idPhongBan, loai, idDotDanhGia);

                //DataTable dt = DotDanhGiaController.GetAllNhanVienTheoCongViec(ConvertUtility.ToInt32(row["ID"].ToString()), idDotDanhGia);
                ListItem item;
                //if (dt != null && dt.Rows.Count > 0 && ConvertUtility.ToInt32(dt.Rows[0][0]) > 0)
                //{

                //    if (dtChildLevel.Rows.Count > 0)
                //    {
                //        //item = new ListItem(MiscUtility.StringIndent(level) + "(" + Math.Round(ConvertUtility.ToDouble(row["TyTrong"].ToString()), 3) + "%) " + row["Ten"].ToString(), row["ID"].ToString() + "_1");
                //        item = new ListItem(MiscUtility.StringIndent(level) + row["Ten"].ToString(), row["ID"].ToString() + "_1");
                //        item.Attributes.Add("Level", level.ToString());
                //        item.Attributes.Add("HasChild", "1");
                //    }
                //    else
                //    {
                //        //item = new ListItem(MiscUtility.StringIndent(level) + "(" + Math.Round(ConvertUtility.ToDouble(row["TyTrong"].ToString()), 3) + "%) " + row["Ten"].ToString(), row["ID"].ToString() + "_0");
                //        item = new ListItem(MiscUtility.StringIndent(level) + row["Ten"].ToString(), row["ID"].ToString() + "_0");
                //        item.Attributes.Add("Level", level.ToString());
                //        item.Attributes.Add("HasChild", "0");
                //    }
                //    lstItems.Add(item);
                //}
                //else
                //{                   
                if (dtChildLevel.Rows.Count > 0)
                {
                    //item = new ListItem(MiscUtility.StringIndent(level) + "(" + Math.Round(ConvertUtility.ToDouble(row["TyTrong"].ToString()), 3) + "%) " + row["Ten"].ToString(), row["ID"].ToString() + "_1");
                    item = new ListItem(MiscUtility.StringIndent(level) + row["Ten"].ToString(), row["ID"].ToString() + "_1");
                    item.Attributes.Add("Level", level.ToString());
                    item.Attributes.Add("style", "color:red");
                    item.Attributes.Add("HasChild", "1");
                }
                else
                {
                    //item = new ListItem(MiscUtility.StringIndent(level) + "(" + Math.Round(ConvertUtility.ToDouble(row["TyTrong"].ToString()), 3) + "%) " + row["Ten"].ToString(), row["ID"].ToString() + "_0");
                    item = new ListItem(MiscUtility.StringIndent(level) + row["Ten"].ToString(), row["ID"].ToString() + "_0");
                    item.Attributes.Add("Level", level.ToString());
                    //item.Attributes.Add("style", "color:red");
                    item.Attributes.Add("HasChild", "0");
                }
                lstItems.Add(item);
                //}
                LoadForCurItemChuaDuocGiao(lstItems, item, idTrungTam, idPhongBan, loai, idDotDanhGia);
            }
        }

        public static void UpdateCapDoCongViec(int idCongViec, int level)
        {
            DataAccessProvider.Instance().UpdateCapDoCongViec(idCongViec, level);
        }

        public static void UpdateTyTrong(int idCongViec, int soGio, int idTrungTam)
        {
            DataAccessProvider.Instance().UpdateTyTrong(idCongViec, soGio, idTrungTam);
        }

        public static DataTable LoadCongViecForCopy(DataTable dt, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia)
        {
            DataTable dtZones = GetAllByParentIDNew(0, idTrungTam, idPhongBan, loai, idDotDanhGia);
            foreach (DataRow row in dtZones.Rows)
            {
                DataRow _row = dt.NewRow();

                _row["ID"] = row["ID"].ToString();
                _row["Ten"] = row["Ten"].ToString();
                _row["TyTrong"] = row["TyTrong"].ToString();
                _row["SoGio"] = Math.Round(ConvertUtility.ToDouble(row["SoGio"]), 3).ToString();
                _row["ParentID"] = row["ParentID"].ToString();
                _row["Priority"] = row["Priority"].ToString();
                _row["KeHoach"] = row["KeHoach"].ToString();
                _row["DonViDo"] = row["DonViDo"].ToString();
                _row["IDTrungTam"] = row["IDTrungTam"].ToString();
                _row["IDPhongBan"] = row["IDPhongBan"].ToString();
                _row["Loai"] = row["Loai"].ToString();
                _row["IDDotDanhGia"] = row["IDDotDanhGia"].ToString();
                _row["LevelDeep"] = row["LevelDeep"].ToString();
                _row["NgayBatDau"] = row["NgayBatDau"].ToString();
                _row["NgayKetThuc"] = row["NgayKetThuc"].ToString();
                _row["TrangThaiCV"] = row["TrangThaiCV"].ToString();
                _row["TuanLamViec"] = row["TuanLamViec"].ToString();
                dt.Rows.Add(_row);
                LoadForCurItemForCopy(dt, _row, idTrungTam, idPhongBan, loai, idDotDanhGia);
            }
            return dt;
        }

        public static void LoadForCurItemForCopy(DataTable dt, DataRow curItem, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia)
        {
            int curId = ConvertUtility.ToInt32(curItem["ID"]);
            DataTable dtChildZones = GetAllByParentIDNew(curId, idTrungTam, idPhongBan, loai, idDotDanhGia);
            if (dtChildZones == null) return;
            foreach (DataRow row in dtChildZones.Rows)
            {
                DataRow _row = dt.NewRow();

                _row["ID"] = row["ID"].ToString();
                _row["Ten"] = row["Ten"].ToString();
                _row["TyTrong"] = row["TyTrong"].ToString();
                _row["SoGio"] = Math.Round(ConvertUtility.ToDouble(row["SoGio"]), 3).ToString();
                _row["ParentID"] = row["ParentID"].ToString();
                _row["Priority"] = row["Priority"].ToString();
                _row["KeHoach"] = row["KeHoach"].ToString();
                _row["DonViDo"] = row["DonViDo"].ToString();
                _row["IDTrungTam"] = row["IDTrungTam"].ToString();
                _row["IDPhongBan"] = row["IDPhongBan"].ToString();
                _row["Loai"] = row["Loai"].ToString();
                _row["IDDotDanhGia"] = row["IDDotDanhGia"].ToString();
                _row["LevelDeep"] = row["LevelDeep"].ToString();
                _row["NgayBatDau"] = row["NgayBatDau"].ToString();
                _row["NgayKetThuc"] = row["NgayKetThuc"].ToString();
                _row["TrangThaiCV"] = row["TrangThaiCV"].ToString();
                _row["TuanLamViec"] = row["TuanLamViec"].ToString();
                dt.Rows.Add(_row);
                LoadForCurItemForCopy(dt, _row, idTrungTam, idPhongBan, loai, idDotDanhGia);
            }
        }

        public static DataTable LoadCongViecForCopyNew(DataTable dt, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia)
        {
            DataTable dtZones = GetAllByParentIDNew(0, idTrungTam, idPhongBan, loai, idDotDanhGia);
            foreach (DataRow row in dtZones.Rows)
            {
                DataRow _row = dt.NewRow();

                _row["ID"] = row["ID"].ToString();
                _row["Ten"] = row["Ten"].ToString();
                _row["TyTrong"] = row["TyTrong"].ToString();
                _row["SoGio"] = Math.Round(ConvertUtility.ToDouble(row["SoGio"]), 3).ToString();
                _row["ParentID"] = row["ParentID"].ToString();
                _row["Priority"] = row["Priority"].ToString();
                _row["KeHoach"] = row["KeHoach"].ToString();
                _row["DonViDo"] = row["DonViDo"].ToString();
                _row["IDTrungTam"] = row["IDTrungTam"].ToString();
                _row["IDPhongBan"] = row["IDPhongBan"].ToString();
                _row["Loai"] = row["Loai"].ToString();
                _row["IDDotDanhGia"] = row["IDDotDanhGia"].ToString();
                _row["LevelDeep"] = row["LevelDeep"].ToString();
                _row["NgayBatDau"] = row["NgayBatDau"].ToString();
                _row["NgayKetThuc"] = row["NgayKetThuc"].ToString();
                _row["TrangThaiCV"] = row["TrangThaiCV"].ToString();
                _row["TuanLamViec"] = row["TuanLamViec"].ToString();
                _row["IDNhomCongViec"] = row["IDNhomCongViec"].ToString();

                dt.Rows.Add(_row);
                LoadForCurItemForCopyNew(dt, _row, idTrungTam, idPhongBan, loai, idDotDanhGia);
            }
            return dt;
        }

        public static void LoadForCurItemForCopyNew(DataTable dt, DataRow curItem, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia)
        {
            int curId = ConvertUtility.ToInt32(curItem["ID"]);
            DataTable dtChildZones = GetAllByParentIDNew(curId, idTrungTam, idPhongBan, loai, idDotDanhGia);
            if (dtChildZones == null) return;
            foreach (DataRow row in dtChildZones.Rows)
            {
                DataRow _row = dt.NewRow();

                _row["ID"] = row["ID"].ToString();
                _row["Ten"] = row["Ten"].ToString();
                _row["TyTrong"] = row["TyTrong"].ToString();
                _row["SoGio"] = Math.Round(ConvertUtility.ToDouble(row["SoGio"]), 3).ToString();
                _row["ParentID"] = row["ParentID"].ToString();
                _row["Priority"] = row["Priority"].ToString();
                _row["KeHoach"] = row["KeHoach"].ToString();
                _row["DonViDo"] = row["DonViDo"].ToString();
                _row["IDTrungTam"] = row["IDTrungTam"].ToString();
                _row["IDPhongBan"] = row["IDPhongBan"].ToString();
                _row["Loai"] = row["Loai"].ToString();
                _row["IDDotDanhGia"] = row["IDDotDanhGia"].ToString();
                _row["LevelDeep"] = row["LevelDeep"].ToString();
                _row["NgayBatDau"] = row["NgayBatDau"].ToString();
                _row["NgayKetThuc"] = row["NgayKetThuc"].ToString();
                _row["TrangThaiCV"] = row["TrangThaiCV"].ToString();
                _row["TuanLamViec"] = row["TuanLamViec"].ToString();
                _row["IDNhomCongViec"] = row["IDNhomCongViec"].ToString();

                dt.Rows.Add(_row);
                LoadForCurItemForCopyNew(dt, _row, idTrungTam, idPhongBan, loai, idDotDanhGia);
            }
        }

        public static DataTable LoadCongViecForExportNew(DataTable dt, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia)
        {
            DataTable dtZones = GetAllByParentIDNew(0, idTrungTam, idPhongBan, loai, idDotDanhGia);
            foreach (DataRow row in dtZones.Rows)
            {
                DataRow _row = dt.NewRow();

                _row["ID"] = row["ID"].ToString();
                _row["Ten"] = row["Ten"].ToString();
                _row["TyTrong"] = ConvertUtility.ToString(row["TyTrong"]).ToString().Replace(",", ".");
                _row["SoGio"] = Math.Round(ConvertUtility.ToDouble(row["SoGio"]), 3).ToString();
                _row["KeHoach"] = row["KeHoach"].ToString();
                _row["DonViDo"] = row["DonViDo"].ToString();
                _row["Level"] = "0";
                _row["Bold"] = "1";
                _row["Ma"] = row["Ma"].ToString();

                dt.Rows.Add(_row);
                LoadForCurItemForExportNew(dt, _row, idTrungTam, idPhongBan, loai, idDotDanhGia);
            }
            return dt;
        }

        public static void LoadForCurItemForExportNew(DataTable dt, DataRow curItem, int idTrungTam, int idPhongBan, int loai, int idDotDanhGia)
        {
            int curId = ConvertUtility.ToInt32(curItem["ID"]);
            int level = ConvertUtility.ToInt32(curItem["Level"]);
            level++;
            DataTable dtChildZones = GetAllByParentIDNew(curId, idTrungTam, idPhongBan, loai, idDotDanhGia);
            if (dtChildZones == null) return;
            foreach (DataRow row in dtChildZones.Rows)
            {
                DataRow _row = dt.NewRow();

                _row["ID"] = row["ID"].ToString();
                _row["Ten"] = MiscUtility.StringIndent(level) + row["Ten"].ToString();
                _row["TyTrong"] = ConvertUtility.ToString(row["TyTrong"]).ToString().Replace(",", ".");
                _row["SoGio"] = Math.Round(ConvertUtility.ToDouble(row["SoGio"]), 3).ToString();
                _row["KeHoach"] = row["KeHoach"].ToString();
                _row["DonViDo"] = row["DonViDo"].ToString();
                _row["Level"] = level;
                _row["Bold"] = "0";
                _row["Ma"] = row["Ma"].ToString();
                dt.Rows.Add(_row);
                LoadForCurItemForExportNew(dt, _row, idTrungTam, idPhongBan, loai, idDotDanhGia);
            }
        }

        public static void ClearAllCongViecTheoBoPhanVaDotDanhGia(int idDotDanhGia, int idTrungTam, int loai)
        {
            DataAccessProvider.Instance().ClearAllCongViecTheoBoPhanVaDotDanhGia(idDotDanhGia, idTrungTam, loai);
        }

        public static QuanLyCongViecKTXVaPSInfo GetInfoByTen(string tencongviec, int idDotDanhGia, int idTrungTam, int Loai)
        {
            return DataAccessProvider.Instance().GetInfoCongViecKTXVaPSByTen(tencongviec, idDotDanhGia, idTrungTam, Loai);
        }


        public static DataTable GetAllCongViecDenHanDeadline(int idDotDanhGia, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllCongViecDenHanDeadline(idDotDanhGia, idTrungTam);
        }

        public static DataTable GetAllCongViecQuaHanDeadline(int idDotDanhGia, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllCongViecQuaHanDeadline(idDotDanhGia, idTrungTam);
        }

        public static DataTable GetAllCongViecTrongTuan(int idDotDanhGia, int idTrungTam, int tuan)
        {
            return DataAccessProvider.Instance().GetAllCongViecTrongTuan(idDotDanhGia, idTrungTam, tuan);
        }

        public static DataTable GetAllNhanVienTheoQLVaDotDanhGia(int idDotDanhGia, int idTrungTam)
        {
            return DataAccessProvider.Instance().GetAllNhanVienTheoQLVaDotDanhGia(idDotDanhGia, idTrungTam);
        }

        public static void DeleteRecursive(int _id)
        {
            DataAccessProvider.Instance().DeleteRecursive(_id);
        }
    }
}