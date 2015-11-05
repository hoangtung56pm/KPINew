using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using VmgPortal.Library;
using VmgPortal.Library.Utilities;
using System.Web.UI.WebControls;
using VmgPortal.Modules.KPIData.Library.Providers;

namespace VmgPortal.Modules.KPIData.Library.DotDanhGia
{
    public class QuanLyCongViecBaoCaoNgayController
    {
        public static DataTable GetAll()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("QuanLyCongViecBaoCaoNgay_GetAll", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static void DeleteBaoCaoNgayBoPhan(int _iD)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("QuanLyCongViecBaoCaoNgayBoPhan_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@ID", _iD);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static void DeleteBaoCaoNgayPhongBan(int _iD)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("QuanLyCongViecBaoCaoNgayPhongBan_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@ID", _iD);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static void Delete(int _iD)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("QuanLyCongViecBaoCaoNgay_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@ID", _iD);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static int Insert(QuanLyCongViecBaoCaoNgayInfo _quanLyCongViecBaoCaoNgayInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("QuanLyCongViecBaoCaoNgay_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@IDCongViecKPI", _quanLyCongViecBaoCaoNgayInfo.IDCongViecKPI);
            dbCmd.Parameters.Add("@Ten", _quanLyCongViecBaoCaoNgayInfo.Ten);
            dbCmd.Parameters.Add("@KeHoach", _quanLyCongViecBaoCaoNgayInfo.KeHoach);
            dbCmd.Parameters.Add("@TyTrong", _quanLyCongViecBaoCaoNgayInfo.TyTrong);
            dbCmd.Parameters.Add("@ParentID", _quanLyCongViecBaoCaoNgayInfo.ParentID);
            dbCmd.Parameters.Add("@KetQua", _quanLyCongViecBaoCaoNgayInfo.KetQua);
            dbCmd.Parameters.Add("@TyLeHoanThanh", _quanLyCongViecBaoCaoNgayInfo.TyLeHoanThanh);
            dbCmd.Parameters.Add("@IDTrungTam", _quanLyCongViecBaoCaoNgayInfo.IDTrungTam);
            dbCmd.Parameters.Add("@IDPhongBan", _quanLyCongViecBaoCaoNgayInfo.IDPhongBan);
            dbCmd.Parameters.Add("@CreatedOn", _quanLyCongViecBaoCaoNgayInfo.CreatedOn);
            dbCmd.Parameters.Add("@IDDotDanhGia", _quanLyCongViecBaoCaoNgayInfo.IDDotDanhGia);
            dbCmd.Parameters.Add("@CreateBy", _quanLyCongViecBaoCaoNgayInfo.CreateBy);
            dbCmd.Parameters.Add("@SoGio", _quanLyCongViecBaoCaoNgayInfo.SoGio);
            dbCmd.Parameters.Add("@LyDo", _quanLyCongViecBaoCaoNgayInfo.LyDo);
            dbCmd.Parameters.Add("@DeXuat", _quanLyCongViecBaoCaoNgayInfo.DeXuat);
            dbCmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                return (int)dbCmd.Parameters["@RETURN_VALUE"].Value;
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static int InsertBaoCaoNgayBoPhan(QuanLyCongViecBaoCaoNgayInfo _quanLyCongViecBaoCaoNgayInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("QuanLyCongViecBaoCaoNgayBoPhan_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@IDCongViecKPI", _quanLyCongViecBaoCaoNgayInfo.IDCongViecKPI);
            dbCmd.Parameters.Add("@Ten", _quanLyCongViecBaoCaoNgayInfo.Ten);
            dbCmd.Parameters.Add("@KeHoach", _quanLyCongViecBaoCaoNgayInfo.KeHoach);
            dbCmd.Parameters.Add("@TyTrong", _quanLyCongViecBaoCaoNgayInfo.TyTrong);
            dbCmd.Parameters.Add("@ParentID", _quanLyCongViecBaoCaoNgayInfo.ParentID);
            dbCmd.Parameters.Add("@KetQua", _quanLyCongViecBaoCaoNgayInfo.KetQua);
            dbCmd.Parameters.Add("@TyLeHoanThanh", _quanLyCongViecBaoCaoNgayInfo.TyLeHoanThanh);
            dbCmd.Parameters.Add("@IDTrungTam", _quanLyCongViecBaoCaoNgayInfo.IDTrungTam);
            dbCmd.Parameters.Add("@IDPhongBan", _quanLyCongViecBaoCaoNgayInfo.IDPhongBan);
            dbCmd.Parameters.Add("@CreatedOn", _quanLyCongViecBaoCaoNgayInfo.CreatedOn);
            dbCmd.Parameters.Add("@IDDotDanhGia", _quanLyCongViecBaoCaoNgayInfo.IDDotDanhGia);
            dbCmd.Parameters.Add("@CreateBy", _quanLyCongViecBaoCaoNgayInfo.CreateBy);
            dbCmd.Parameters.Add("@SoGio", _quanLyCongViecBaoCaoNgayInfo.SoGio);
            dbCmd.Parameters.Add("@LyDo", _quanLyCongViecBaoCaoNgayInfo.LyDo);
            dbCmd.Parameters.Add("@DeXuat", _quanLyCongViecBaoCaoNgayInfo.DeXuat);
            dbCmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                return (int)dbCmd.Parameters["@RETURN_VALUE"].Value;
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static int InsertBaoCaoNgayPhongBan(QuanLyCongViecBaoCaoNgayInfo _quanLyCongViecBaoCaoNgayInfo, int status)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("QuanLyCongViecBaoCaoNgayPhongBan_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@IDCongViecKPI", _quanLyCongViecBaoCaoNgayInfo.IDCongViecKPI);
            dbCmd.Parameters.Add("@Ten", _quanLyCongViecBaoCaoNgayInfo.Ten);
            dbCmd.Parameters.Add("@KeHoach", _quanLyCongViecBaoCaoNgayInfo.KeHoach);
            dbCmd.Parameters.Add("@TyTrong", _quanLyCongViecBaoCaoNgayInfo.TyTrong);
            dbCmd.Parameters.Add("@ParentID", _quanLyCongViecBaoCaoNgayInfo.ParentID);
            dbCmd.Parameters.Add("@KetQua", _quanLyCongViecBaoCaoNgayInfo.KetQua);
            dbCmd.Parameters.Add("@TyLeHoanThanh", _quanLyCongViecBaoCaoNgayInfo.TyLeHoanThanh);
            dbCmd.Parameters.Add("@IDTrungTam", _quanLyCongViecBaoCaoNgayInfo.IDTrungTam);
            dbCmd.Parameters.Add("@IDPhongBan", _quanLyCongViecBaoCaoNgayInfo.IDPhongBan);
            dbCmd.Parameters.Add("@CreatedOn", _quanLyCongViecBaoCaoNgayInfo.CreatedOn);
            dbCmd.Parameters.Add("@IDDotDanhGia", _quanLyCongViecBaoCaoNgayInfo.IDDotDanhGia);
            dbCmd.Parameters.Add("@CreateBy", _quanLyCongViecBaoCaoNgayInfo.CreateBy);
            dbCmd.Parameters.Add("@SoGio", _quanLyCongViecBaoCaoNgayInfo.SoGio);
            dbCmd.Parameters.Add("@LyDo", _quanLyCongViecBaoCaoNgayInfo.LyDo);
            dbCmd.Parameters.Add("@DeXuat", _quanLyCongViecBaoCaoNgayInfo.DeXuat);
            dbCmd.Parameters.Add("@Status", status);
            dbCmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                return (int)dbCmd.Parameters["@RETURN_VALUE"].Value;
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static void Update(QuanLyCongViecBaoCaoNgayInfo _quanLyCongViecBaoCaoNgayInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("QuanLyCongViecBaoCaoNgay_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@ID", _quanLyCongViecBaoCaoNgayInfo.ID);
            dbCmd.Parameters.Add("@IDCongViecKPI", _quanLyCongViecBaoCaoNgayInfo.IDCongViecKPI);
            dbCmd.Parameters.Add("@Ten", _quanLyCongViecBaoCaoNgayInfo.Ten);
            dbCmd.Parameters.Add("@KeHoach", _quanLyCongViecBaoCaoNgayInfo.KeHoach);
            dbCmd.Parameters.Add("@TyTrong", _quanLyCongViecBaoCaoNgayInfo.TyTrong);
            dbCmd.Parameters.Add("@ParentID", _quanLyCongViecBaoCaoNgayInfo.ParentID);
            dbCmd.Parameters.Add("@KetQua", _quanLyCongViecBaoCaoNgayInfo.KetQua);
            dbCmd.Parameters.Add("@TyLeHoanThanh", _quanLyCongViecBaoCaoNgayInfo.TyLeHoanThanh);
            dbCmd.Parameters.Add("@IDTrungTam", _quanLyCongViecBaoCaoNgayInfo.IDTrungTam);
            dbCmd.Parameters.Add("@IDPhongBan", _quanLyCongViecBaoCaoNgayInfo.IDPhongBan);
            dbCmd.Parameters.Add("@CreatedOn", _quanLyCongViecBaoCaoNgayInfo.CreatedOn);
            dbCmd.Parameters.Add("@IDDotDanhGia", _quanLyCongViecBaoCaoNgayInfo.IDDotDanhGia);
            dbCmd.Parameters.Add("@CreateBy", _quanLyCongViecBaoCaoNgayInfo.CreateBy);
            dbCmd.Parameters.Add("@SoGio", _quanLyCongViecBaoCaoNgayInfo.SoGio);
            dbCmd.Parameters.Add("@LyDo", _quanLyCongViecBaoCaoNgayInfo.LyDo);
            dbCmd.Parameters.Add("@DeXuat", _quanLyCongViecBaoCaoNgayInfo.DeXuat);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static void UpdateBaoCaoNgayPhongBan(QuanLyCongViecBaoCaoNgayInfo _quanLyCongViecBaoCaoNgayInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("QuanLyCongViecBaoCaoNgayPhongBan_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@ID", _quanLyCongViecBaoCaoNgayInfo.ID);
            dbCmd.Parameters.Add("@IDCongViecKPI", _quanLyCongViecBaoCaoNgayInfo.IDCongViecKPI);
            dbCmd.Parameters.Add("@Ten", _quanLyCongViecBaoCaoNgayInfo.Ten);
            dbCmd.Parameters.Add("@KeHoach", _quanLyCongViecBaoCaoNgayInfo.KeHoach);
            dbCmd.Parameters.Add("@TyTrong", _quanLyCongViecBaoCaoNgayInfo.TyTrong);
            dbCmd.Parameters.Add("@ParentID", _quanLyCongViecBaoCaoNgayInfo.ParentID);
            dbCmd.Parameters.Add("@KetQua", _quanLyCongViecBaoCaoNgayInfo.KetQua);
            dbCmd.Parameters.Add("@TyLeHoanThanh", _quanLyCongViecBaoCaoNgayInfo.TyLeHoanThanh);
            dbCmd.Parameters.Add("@IDTrungTam", _quanLyCongViecBaoCaoNgayInfo.IDTrungTam);
            dbCmd.Parameters.Add("@IDPhongBan", _quanLyCongViecBaoCaoNgayInfo.IDPhongBan);
            dbCmd.Parameters.Add("@CreatedOn", _quanLyCongViecBaoCaoNgayInfo.CreatedOn);
            dbCmd.Parameters.Add("@IDDotDanhGia", _quanLyCongViecBaoCaoNgayInfo.IDDotDanhGia);
            dbCmd.Parameters.Add("@CreateBy", _quanLyCongViecBaoCaoNgayInfo.CreateBy);
            dbCmd.Parameters.Add("@SoGio", _quanLyCongViecBaoCaoNgayInfo.SoGio);
            dbCmd.Parameters.Add("@LyDo", _quanLyCongViecBaoCaoNgayInfo.LyDo);
            dbCmd.Parameters.Add("@DeXuat", _quanLyCongViecBaoCaoNgayInfo.DeXuat);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static void UpdateBaoCaoNgayBoPhan(QuanLyCongViecBaoCaoNgayInfo _quanLyCongViecBaoCaoNgayInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("QuanLyCongViecBaoCaoNgayBoPhan_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@ID", _quanLyCongViecBaoCaoNgayInfo.ID);
            dbCmd.Parameters.Add("@IDCongViecKPI", _quanLyCongViecBaoCaoNgayInfo.IDCongViecKPI);
            dbCmd.Parameters.Add("@Ten", _quanLyCongViecBaoCaoNgayInfo.Ten);
            dbCmd.Parameters.Add("@KeHoach", _quanLyCongViecBaoCaoNgayInfo.KeHoach);
            dbCmd.Parameters.Add("@TyTrong", _quanLyCongViecBaoCaoNgayInfo.TyTrong);
            dbCmd.Parameters.Add("@ParentID", _quanLyCongViecBaoCaoNgayInfo.ParentID);
            dbCmd.Parameters.Add("@KetQua", _quanLyCongViecBaoCaoNgayInfo.KetQua);
            dbCmd.Parameters.Add("@TyLeHoanThanh", _quanLyCongViecBaoCaoNgayInfo.TyLeHoanThanh);
            dbCmd.Parameters.Add("@IDTrungTam", _quanLyCongViecBaoCaoNgayInfo.IDTrungTam);
            dbCmd.Parameters.Add("@IDPhongBan", _quanLyCongViecBaoCaoNgayInfo.IDPhongBan);
            dbCmd.Parameters.Add("@CreatedOn", _quanLyCongViecBaoCaoNgayInfo.CreatedOn);
            dbCmd.Parameters.Add("@IDDotDanhGia", _quanLyCongViecBaoCaoNgayInfo.IDDotDanhGia);
            dbCmd.Parameters.Add("@CreateBy", _quanLyCongViecBaoCaoNgayInfo.CreateBy);
            dbCmd.Parameters.Add("@SoGio", _quanLyCongViecBaoCaoNgayInfo.SoGio);
            dbCmd.Parameters.Add("@LyDo", _quanLyCongViecBaoCaoNgayInfo.LyDo);
            dbCmd.Parameters.Add("@DeXuat", _quanLyCongViecBaoCaoNgayInfo.DeXuat);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
            }
            finally
            {
                dbConn.Close();
            }
        }
        

        public static void UpdateStatusCVPhongBan(int id, int status)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("QuanLyCongViecBaoCaoNgay_UpdateStatusPhongBan", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@ID", id);
            dbCmd.Parameters.Add("@Status", status);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
            }
            finally
            {
                dbConn.Close();
            }
        }

        public static void UpdateStatus(int id, int status)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("QuanLyCongViecBaoCaoNgay_UpdateStatus", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@ID", id);
            dbCmd.Parameters.Add("@Status", status);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
            }
            finally
            {
                dbConn.Close();
            }
        }

        public static QuanLyCongViecBaoCaoNgayInfo GetInfo(int _iD)
        {
            QuanLyCongViecBaoCaoNgayInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("QuanLyCongViecBaoCaoNgay_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@ID", _iD);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new QuanLyCongViecBaoCaoNgayInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.IDCongViecKPI = Convert.ToInt32(dr["IDCongViecKPI"]);
                    retVal.Ten = Convert.ToString(dr["Ten"]);
                    retVal.KeHoach = Convert.ToString(dr["KeHoach"]);
                    retVal.TyTrong = Convert.ToDouble(dr["TyTrong"]);
                    retVal.ParentID = Convert.ToString(dr["ParentID"]);
                    retVal.KetQua = Convert.ToString(dr["KetQua"]);
                    retVal.TyLeHoanThanh = Convert.ToString(dr["TyLeHoanThanh"]);
                    retVal.IDTrungTam = Convert.ToInt32(dr["IDTrungTam"]);
                    retVal.IDPhongBan = Convert.ToInt32(dr["IDPhongBan"]);
                    retVal.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                    retVal.IDDotDanhGia = Convert.ToInt32(dr["IDDotDanhGia"]);
                    retVal.CreateBy = Convert.ToInt32(dr["CreateBy"]);
                    retVal.SoGio = Convert.ToDouble(dr["SoGio"]);
                    retVal.LyDo = Convert.ToString(dr["LyDo"]);
                    retVal.DeXuat = Convert.ToString(dr["DeXuat"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static QuanLyCongViecBaoCaoNgayInfo GetBaoCaoNgayPhongBanInfo(int _iD)
        {
            QuanLyCongViecBaoCaoNgayInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("QuanLyCongViecBaoCaoNgayPhongBan_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@ID", _iD);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new QuanLyCongViecBaoCaoNgayInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.IDCongViecKPI = Convert.ToInt32(dr["IDCongViecKPI"]);
                    retVal.Ten = Convert.ToString(dr["Ten"]);
                    retVal.KeHoach = Convert.ToString(dr["KeHoach"]);
                    retVal.TyTrong = Convert.ToDouble(dr["TyTrong"]);
                    retVal.ParentID = Convert.ToString(dr["ParentID"]);
                    retVal.KetQua = Convert.ToString(dr["KetQua"]);
                    retVal.TyLeHoanThanh = Convert.ToString(dr["TyLeHoanThanh"]);
                    retVal.IDTrungTam = Convert.ToInt32(dr["IDTrungTam"]);
                    retVal.IDPhongBan = Convert.ToInt32(dr["IDPhongBan"]);
                    retVal.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                    retVal.IDDotDanhGia = Convert.ToInt32(dr["IDDotDanhGia"]);
                    retVal.CreateBy = Convert.ToInt32(dr["CreateBy"]);
                    retVal.SoGio = Convert.ToDouble(dr["SoGio"]);
                    retVal.LyDo = Convert.ToString(dr["LyDo"]);
                    retVal.DeXuat = Convert.ToString(dr["DeXuat"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }


        public static QuanLyCongViecBaoCaoNgayInfo GetBaoCaoNgayBoPhanInfo(int _iD)
        {
            QuanLyCongViecBaoCaoNgayInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("QuanLyCongViecBaoCaoNgayBoPhan_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@ID", _iD);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new QuanLyCongViecBaoCaoNgayInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.IDCongViecKPI = Convert.ToInt32(dr["IDCongViecKPI"]);
                    retVal.Ten = Convert.ToString(dr["Ten"]);
                    retVal.KeHoach = Convert.ToString(dr["KeHoach"]);
                    retVal.TyTrong = Convert.ToDouble(dr["TyTrong"]);
                    retVal.ParentID = Convert.ToString(dr["ParentID"]);
                    retVal.KetQua = Convert.ToString(dr["KetQua"]);
                    retVal.TyLeHoanThanh = Convert.ToString(dr["TyLeHoanThanh"]);
                    retVal.IDTrungTam = Convert.ToInt32(dr["IDTrungTam"]);
                    retVal.IDPhongBan = Convert.ToInt32(dr["IDPhongBan"]);
                    retVal.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                    retVal.IDDotDanhGia = Convert.ToInt32(dr["IDDotDanhGia"]);
                    retVal.CreateBy = Convert.ToInt32(dr["CreateBy"]);
                    retVal.SoGio = Convert.ToDouble(dr["SoGio"]);
                    retVal.LyDo = Convert.ToString(dr["LyDo"]);
                    retVal.DeXuat = Convert.ToString(dr["DeXuat"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static DataTable GetAllByParentID(int parentId, int idTrungTam, int idPhongBan, DateTime dt, int idDotDanhGia, int UserID)
        {
            return DataAccessProvider.Instance().GetAllByParentIDBaoCaoNgay(parentId, idTrungTam, idPhongBan,dt, idDotDanhGia,  UserID);
        }

        public static DataTable GetAllByUserID(int idTrungTam, int idPhongBan, DateTime dt, int idDotDanhGia, int UserID)
        {
            return DataAccessProvider.Instance().GetAllByUserIDBaoCaoNgay(idTrungTam, idPhongBan, dt, idDotDanhGia, UserID);
        }
        public static void LoadCongViec(ListItemCollection lstItems, int idTrungTam, int idPhongBan, DateTime dt, int idDotDanhGia, int UserID)
        {
            DataTable dtZones = GetAllByParentID(0, idTrungTam, idPhongBan, dt, idDotDanhGia, UserID);
            foreach (DataRow row in dtZones.Rows)
            {
                ListItem item = new ListItem("(" + Math.Round(ConvertUtility.ToDouble(row["TyTrong"].ToString()), 3) + "%) " + row["Ten"].ToString(), row["ID"].ToString());
                item.Attributes.Add("Level", "0");
                item.Attributes.Add("style", "font-weight:bold");
                lstItems.Add(item);
                LoadForCurItem(lstItems, item, idTrungTam, idPhongBan, dt, idDotDanhGia, UserID);
            }
        }

        public static void LoadForCurItem(ListItemCollection lstItems, ListItem curItem, int idTrungTam, int idPhongBan, DateTime dt, int idDotDanhGia, int UserID)
        {
            int curId = ConvertUtility.ToInt32(curItem.Value);
            int level = ConvertUtility.ToInt32(curItem.Attributes["Level"]);
            level++;
            DataTable dtChildZones = GetAllByParentID(curId, idTrungTam, idPhongBan, dt, idDotDanhGia, UserID);
            if (dtChildZones == null) return;
            foreach (DataRow row in dtChildZones.Rows)
            {
                ListItem item = new ListItem(MiscUtility.StringIndent(level) + "(" + Math.Round(ConvertUtility.ToDouble(row["TyTrong"].ToString()), 3) + "%) " + row["Ten"].ToString(), row["ID"].ToString());
                item.Attributes.Add("Level", level.ToString());
                lstItems.Add(item);
                LoadForCurItem(lstItems, item, idTrungTam, idPhongBan, dt, idDotDanhGia,  UserID);
            }
        }
        public static DataTable GetTongTyTrongCacCongViecCon(int idCongViecKPI)
        {
            return DataAccessProvider.Instance().GetTongTyTrongCacCongViecConBaoCaoNgay(idCongViecKPI);
        }

        public static DataTable GetAllBaoCaoNgay(int idTrungTam, DateTime dt, int userId, int userQL, int idDotDanhGia)
        {
            return DataAccessProvider.Instance().GetAllBaoCaoNgay(idTrungTam, dt, userId, userQL, idDotDanhGia);
        }
        public static DataTable GetAllBaoCaoNgayBoPhan(int idTrungTam, int idPhongBan, DateTime dt, int idDotDanhGia, int userId)
        {
            return DataAccessProvider.Instance().GetAllBaoCaoNgayBoPhan(idTrungTam, idPhongBan, dt, idDotDanhGia, userId);
        }
        public static DataTable GetAllBaoCaoNgayPhongBan(int idTrungTam, int idPhongBan, DateTime dt, int idDotDanhGia, int userId, int status)
        {
            return DataAccessProvider.Instance().GetAllBaoCaoNgayPhongBan(idTrungTam, idPhongBan, dt, idDotDanhGia, userId, status);
        }
        public static DataTable BuildRecursiveKeHoachCongViec(DataTable dtCongViec, DataTable dtReturnCongViec)
        {
            DataRow[] dtItems = GetCongViecByParentID(dtCongViec, 0);
            foreach (DataRow row in dtItems)
            {
                DataRow rowItem = dtReturnCongViec.NewRow();
                rowItem["CreateBy"] = row["CreateBy"].ToString();
                rowItem["CongViecKPI"] = row["CongViecKPI"].ToString();
                rowItem["CongViecCha"] = row["CongViecCha"].ToString();
                rowItem["Ten"] = "<font color=\"Black\" style=\"font-weight:normal\">" + row["Ten"].ToString() + "</font>";
                rowItem["TyTrong"] = row["TyTrong"].ToString();
                rowItem["SoGio"] = row["SoGio"].ToString();
                rowItem["TyLeHoanThanh"] = row["TyLeHoanThanh"].ToString();
                rowItem["KetQua"] = row["KetQua"].ToString();
                rowItem["LyDo"] = row["LyDo"].ToString();
                rowItem["DeXuat"] = row["DeXuat"].ToString();
                rowItem["Level"] = "0";
                rowItem["ID"] = row["ID"].ToString();
                rowItem["IDTrungTam"] = row["IDTrungTam"].ToString();
                rowItem["IDPhongBan"] = row["IDPhongBan"].ToString();
                rowItem["ParentID"] = row["ParentID"].ToString();

                dtReturnCongViec.Rows.Add(rowItem);
                LoadKeHoachCongViecForCur(dtCongViec, rowItem, dtReturnCongViec);
            }

            return dtReturnCongViec;
        }

        private static DataTable LoadKeHoachCongViecForCur(DataTable dtCongViec, DataRow curItem, DataTable dtReturnCongViec)
        {
            int level = Convert.ToInt32(curItem["Level"]);
            level += 1;
            int ID = Convert.ToInt32(curItem["ID"]);
            DataRow[] dtChild = GetCongViecByParentID(dtCongViec, ID);
            foreach (DataRow row in dtChild)
            {
                DataRow childItem = dtReturnCongViec.NewRow();
                childItem["CreateBy"] = row["CreateBy"].ToString();
                childItem["CongViecKPI"] = row["CongViecKPI"].ToString();
                childItem["CongViecCha"] = row["CongViecCha"].ToString();                
                childItem["TyTrong"] = row["TyTrong"].ToString();
                childItem["SoGio"] = row["SoGio"].ToString();
                childItem["TyLeHoanThanh"] = row["TyLeHoanThanh"].ToString();
                childItem["KetQua"] = row["KetQua"].ToString();
                childItem["LyDo"] = row["LyDo"].ToString();
                childItem["DeXuat"] = row["DeXuat"].ToString();
                childItem["Level"] = level;
                childItem["ID"] = row["ID"].ToString();
                childItem["IDTrungTam"] = row["IDTrungTam"].ToString();
                childItem["IDPhongBan"] = row["IDPhongBan"].ToString();
                childItem["ParentID"] = row["ParentID"].ToString();

                if (level == 1)
                {
                    childItem["Ten"] = MiscUtility.StringIndent(level) + "<font color=\"Black\">" + row["Ten"].ToString() + "</font>";
                }
                else if (level == 2)
                {
                    childItem["Ten"] = MiscUtility.StringIndent(level) + "<font color=\"Orange\">" + row["Ten"].ToString() + "</font>";
                }
                else if (level == 3)
                {
                    childItem["Ten"] = MiscUtility.StringIndent(level) + "<font color=\"Orange\">" + row["Ten"].ToString() + "</font>";
                }
                else if (level > 3)
                {
                    childItem["Ten"] = MiscUtility.StringIndent(level) + "<font color=\"Gray\">" + row["Ten"].ToString() + "</font>";
                }
                
                dtReturnCongViec.Rows.Add(childItem);
                LoadKeHoachCongViecForCur(dtCongViec, childItem, dtReturnCongViec);
            }
            return dtReturnCongViec;
        }

        private static DataRow[] GetCongViecByParentID(DataTable dtCongViec, int parentID)
        {
            DataRow[] retVal = null;
            retVal = dtCongViec.Select("ParentID = '" + parentID + "'");
            return retVal;
        }
    }
}