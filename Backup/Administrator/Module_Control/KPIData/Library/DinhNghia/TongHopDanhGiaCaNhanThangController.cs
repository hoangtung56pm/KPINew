using System;
using System.Data;
using System.Data.SqlClient;
using VmgPortal.Library.Utilities;
using VmgPortal.Library;

namespace VmgPortal.Modules.KPIData.Library.DinhNghia
{
    public class TongHopDanhGiaCaNhanThangController
    {
        public static DataTable GetAllNhanVien(string bophan, int nam)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("TongHopDanhGiaCaNhanThang_GetAllNhanVienByBoPhanNamThang", dbConn);
            dbCmd.Parameters.Add("@BoPhan", bophan);
            dbCmd.Parameters.Add("@Nam", nam);

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

        public static DataTable GetAll(string bophan, int nam, string hoten)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("TongHopDanhGiaCaNhanThang_GetAllByBoPhanNamThang", dbConn);
            dbCmd.Parameters.Add("@BoPhan", bophan);
            dbCmd.Parameters.Add("@Nam", nam);
            dbCmd.Parameters.Add("@HoTen", hoten);
            
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

        public static DataTable GetAll()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("TongHopDanhGiaCaNhanThang_GetAll", dbConn);
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
        public static void Delete(int _iD)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("TongHopDanhGiaCaNhanThang_Delete", dbConn);
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
        public static int Insert(TongHopDanhGiaCaNhanThangInfo _tongHopDanhGiaCaNhanThangInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("TongHopDanhGiaCaNhanThang_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@BoPhan", _tongHopDanhGiaCaNhanThangInfo.BoPhan);
            dbCmd.Parameters.Add("@HoTen", _tongHopDanhGiaCaNhanThangInfo.HoTen);
            dbCmd.Parameters.Add("@KPI", _tongHopDanhGiaCaNhanThangInfo.KPI);
            dbCmd.Parameters.Add("@DiemDanhGiaDonVi", _tongHopDanhGiaCaNhanThangInfo.DiemDanhGiaDonVi);
            dbCmd.Parameters.Add("@LoiNhuanCongTy", _tongHopDanhGiaCaNhanThangInfo.LoiNhuanCongTy);
            dbCmd.Parameters.Add("@LoiNhuanBoPhan", _tongHopDanhGiaCaNhanThangInfo.LoiNhuanBoPhan);
            dbCmd.Parameters.Add("@QuanLyCongViecVaPhoiHop", _tongHopDanhGiaCaNhanThangInfo.QuanLyCongViecVaPhoiHop);
            dbCmd.Parameters.Add("@KyLuatCaNhan", _tongHopDanhGiaCaNhanThangInfo.KyLuatCaNhan);
            dbCmd.Parameters.Add("@DiemThuong", _tongHopDanhGiaCaNhanThangInfo.DiemThuong);
            dbCmd.Parameters.Add("@MucDoHoanThanh", _tongHopDanhGiaCaNhanThangInfo.MucDoHoanThanh);
            dbCmd.Parameters.Add("@XepLoai", _tongHopDanhGiaCaNhanThangInfo.XepLoai);
            dbCmd.Parameters.Add("@HeSoLuongMem", _tongHopDanhGiaCaNhanThangInfo.HeSoLuongMem);
            dbCmd.Parameters.Add("@Thang", _tongHopDanhGiaCaNhanThangInfo.Thang);
            dbCmd.Parameters.Add("@Nam", _tongHopDanhGiaCaNhanThangInfo.Nam);
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

        public static void Update(TongHopDanhGiaCaNhanThangInfo _tongHopDanhGiaCaNhanThangInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("TongHopDanhGiaCaNhanThang_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@ID", _tongHopDanhGiaCaNhanThangInfo.ID);
            dbCmd.Parameters.Add("@BoPhan", _tongHopDanhGiaCaNhanThangInfo.BoPhan);
            dbCmd.Parameters.Add("@HoTen", _tongHopDanhGiaCaNhanThangInfo.HoTen);
            dbCmd.Parameters.Add("@KPI", _tongHopDanhGiaCaNhanThangInfo.KPI);
            dbCmd.Parameters.Add("@DiemDanhGiaDonVi", _tongHopDanhGiaCaNhanThangInfo.DiemDanhGiaDonVi);
            dbCmd.Parameters.Add("@LoiNhuanCongTy", _tongHopDanhGiaCaNhanThangInfo.LoiNhuanCongTy);
            dbCmd.Parameters.Add("@LoiNhuanBoPhan", _tongHopDanhGiaCaNhanThangInfo.LoiNhuanBoPhan);
            dbCmd.Parameters.Add("@QuanLyCongViecVaPhoiHop", _tongHopDanhGiaCaNhanThangInfo.QuanLyCongViecVaPhoiHop);
            dbCmd.Parameters.Add("@KyLuatCaNhan", _tongHopDanhGiaCaNhanThangInfo.KyLuatCaNhan);
            dbCmd.Parameters.Add("@DiemThuong", _tongHopDanhGiaCaNhanThangInfo.DiemThuong);
            dbCmd.Parameters.Add("@MucDoHoanThanh", _tongHopDanhGiaCaNhanThangInfo.MucDoHoanThanh);
            dbCmd.Parameters.Add("@XepLoai", _tongHopDanhGiaCaNhanThangInfo.XepLoai);
            dbCmd.Parameters.Add("@HeSoLuongMem", _tongHopDanhGiaCaNhanThangInfo.HeSoLuongMem);
            dbCmd.Parameters.Add("@Thang", _tongHopDanhGiaCaNhanThangInfo.Thang);
            dbCmd.Parameters.Add("@Year", _tongHopDanhGiaCaNhanThangInfo.Nam);
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

        public static TongHopDanhGiaCaNhanThangInfo GetInfo(int _iD)
        {
            TongHopDanhGiaCaNhanThangInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("TongHopDanhGiaCaNhanThang_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@ID", _iD);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new TongHopDanhGiaCaNhanThangInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.BoPhan = Convert.ToString(dr["BoPhan"]);
                    retVal.HoTen = Convert.ToString(dr["HoTen"]);
                    retVal.KPI = Convert.ToDouble(dr["KPI"]);
                    retVal.DiemDanhGiaDonVi = Convert.ToDouble(dr["DiemDanhGiaDonVi"]);
                    retVal.LoiNhuanCongTy = Convert.ToDouble(dr["LoiNhuanCongTy"]);
                    retVal.LoiNhuanBoPhan = Convert.ToDouble(dr["LoiNhuanBoPhan"]);
                    retVal.QuanLyCongViecVaPhoiHop = Convert.ToDouble(dr["QuanLyCongViecVaPhoiHop"]);
                    retVal.KyLuatCaNhan = Convert.ToDouble(dr["KyLuatCaNhan"]);
                    retVal.DiemThuong = Convert.ToDouble(dr["DiemThuong"]);
                    retVal.MucDoHoanThanh = Convert.ToDouble(dr["MucDoHoanThanh"]);
                    retVal.XepLoai = Convert.ToString(dr["XepLoai"]);
                    retVal.HeSoLuongMem = Convert.ToDouble(dr["HeSoLuongMem"]);
                    retVal.Thang = Convert.ToInt32(dr["Thang"]);
                    retVal.Nam = Convert.ToInt32(dr["Nam"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
 

    }
}