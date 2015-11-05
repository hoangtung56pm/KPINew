using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Globalization;

namespace VmgPortal.Modules.KPIData.Library
{
    public class ImportExcelToDataTable
    {
        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            StreamReader sr = new StreamReader(strFilePath);
            string line = sr.ReadLine();
            string[] value = line.Split('\t');
            DataTable dt = new DataTable();
            DataRow row;
            foreach (string dc in value)
            {
                dt.Columns.Add(new DataColumn(dc));
            }

            while (!sr.EndOfStream)
            {
                value = sr.ReadLine().Split('\t');
                if (value.Length == dt.Columns.Count)
                {
                    row = dt.NewRow();
                    row.ItemArray = value;
                    dt.Rows.Add(row);
                }
            }
           
            return dt;
        } 

        public static void ExportToExcel(DataTable dt, string fileName)
        {
            System.Web.HttpResponse Response= System.Web.HttpContext.Current.Response;
            Response.ContentType = "application/csv";
            Response.Charset = "";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.ContentEncoding = Encoding.Unicode;
            Response.BinaryWrite(Encoding.Unicode.GetPreamble());
            DataTable dtb = dt;
            try
            {
                StringBuilder sb = new StringBuilder();
                //Tạo dòng tiêu để cho bảng tính
                for (int count = 0; count < dtb.Columns.Count; count++)
                {
                    if (dtb.Columns[count].ColumnName != null)
                        sb.Append(dtb.Columns[count].ColumnName);
                    if (count < dtb.Columns.Count - 1)
                    {
                        sb.Append("\t");
                    }
                }
                Response.Write(sb.ToString() + "\n");
                Response.Flush();
                //Duyệt từng bản ghi 
                int soDem = 0;
                while (dtb.Rows.Count >= soDem + 1)
                {
                    sb = new StringBuilder();


                    for (int col = 0; col < dtb.Columns.Count - 1; col++)
                    {
                        if (dtb.Rows[soDem][col] != null)
                            sb.Append(dtb.Rows[soDem][col].ToString().Replace(",", " "));
                        sb.Append("\t");
                    }
                    if (dtb.Rows[soDem][dtb.Columns.Count - 1] != null)
                        sb.Append(dtb.Rows[soDem][dtb.Columns.Count - 1].ToString().Replace(",", " "));


                    Response.Write(sb.ToString() + "\n");
                    Response.Flush();
                    soDem = soDem + 1;
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            dtb.Dispose();
            Response.End();
        }

        public static void ExportKHHDToExcel(DataTable dt, string fileName)
        {
            System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.ContentType = "application/xls";
            Response.Charset = "";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.ContentEncoding = Encoding.Unicode;
            Response.BinaryWrite(Encoding.Unicode.GetPreamble());
            DataTable dtb = dt;
            try
            {
                StringBuilder sb = new StringBuilder();
                //Tạo dòng tiêu để cho bảng tính
                for (int count = 0; count < dtb.Columns.Count; count++)
                {
                    if (dtb.Columns[count].ColumnName != null)
                        sb.Append(dtb.Columns[count].ColumnName);
                    if (count < dtb.Columns.Count - 1)
                    {
                        sb.Append("\t");
                    }
                }
                Response.Write(sb.ToString() + "\n");
                Response.Flush();
                //Duyệt từng bản ghi 
                int soDem = 0;
                while (dtb.Rows.Count >= soDem + 1)
                {
                    sb = new StringBuilder();


                    for (int col = 0; col < dtb.Columns.Count - 1; col++)
                    {
                        if (dtb.Rows[soDem][col] != null)
                            sb.Append(dtb.Rows[soDem][col].ToString());
                        sb.Append("\t");
                    }
                    if (dtb.Rows[soDem][dtb.Columns.Count - 1] != null)
                        sb.Append(dtb.Rows[soDem][dtb.Columns.Count - 1].ToString());


                    Response.Write(sb.ToString() + "\n");
                    Response.Flush();
                    soDem = soDem + 1;
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            dtb.Dispose();
            Response.End();
        }

        public static DataTable ImportExcel(String strFilePath)
        {
            if (!File.Exists(strFilePath))
            {
                return null;
            }
            String strExcelConn = "";
            if (strFilePath.IndexOf(".xlsx") > 0)
            {
                strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
            }
            else
            {
                strExcelConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
            }
            //String strExcelConn = "Provider=Microsoft.Jet.OLEDB.4.0;"
            //+ "Data Source=" + strFilePath + ";"
            //+ "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
            OleDbConnection connExcel = new OleDbConnection(strExcelConn);
            OleDbCommand cmdExcel = new OleDbCommand();
            try
            {
                cmdExcel.Connection = connExcel;

                //Check if the Sheet Exists
                connExcel.Open();
                DataTable dtExcelSchema;
                //Get the Schema of the WorkBook
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                connExcel.Close();

                //Read Data from Sheet1
                connExcel.Open();
                OleDbDataAdapter da = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

                da.SelectCommand = cmdExcel;
                da.Fill(ds);

                connExcel.Close();

                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }

            }
            catch(Exception ex)
            {
                throw ex;
                return null;
            }
            finally
            {
                cmdExcel.Dispose();
                connExcel.Dispose();
            }
        }
        public static void ImportExcel(String strFilePath, out DataTable dt1, out DataTable dt2, out DataTable dt3)
        {
            if (!File.Exists(strFilePath))
            {
                dt1 = null;
                dt2 = null;
            }
                       
            String strExcelConn = "";
            if (strFilePath.IndexOf(".xlsx") > 0)
            {
                strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
            }
            else
            {
                strExcelConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
            }

            //String strExcelConn = "Provider=Microsoft.Jet.OLEDB.4.0;"
            //+ "Data Source=" + strFilePath + ";"
            //+ "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
            OleDbConnection connExcel = new OleDbConnection(strExcelConn);
            OleDbCommand cmdExcel = new OleDbCommand();
            try
            {
                cmdExcel.Connection = connExcel;

                //Check if the Sheet Exists
                connExcel.Open();
                DataTable dtExcelSchema;
                //Get the Schema of the WorkBook
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                connExcel.Close();

                //Read Data from Sheet1
                connExcel.Open();
                OleDbDataAdapter da = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                string SheetName = "KHHD_DK$";// dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                //string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

                da.SelectCommand = cmdExcel;
                da.Fill(ds);
                
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt1 = ds.Tables[0];
                }
                else
                {
                    dt1= null;
                }

                ds = new DataSet();
                SheetName = "KHHD_PS$";//dtExcelSchema.Rows[1]["TABLE_NAME"].ToString();
                //SheetName = dtExcelSchema.Rows[1]["TABLE_NAME"].ToString();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

                da.SelectCommand = cmdExcel;
                da.Fill(ds);

                connExcel.Close();

                if (ds != null && ds.Tables.Count > 0)
                {
                    dt2 = ds.Tables[0];
                }
                else
                {
                    dt2 = null;
                }

                ds = new DataSet();
                SheetName = "KHHD_CVC$";//dtExcelSchema.Rows[1]["TABLE_NAME"].ToString();
                //SheetName = dtExcelSchema.Rows[2]["TABLE_NAME"].ToString();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

                da.SelectCommand = cmdExcel;
                da.Fill(ds);

                connExcel.Close();

                if (ds != null && ds.Tables.Count > 0)
                {
                    dt3 = ds.Tables[0];
                }
                else
                {
                    dt3 = null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
                dt1= null;
                dt2 = null;
                dt3 = null;
            }
            finally
            {
                cmdExcel.Dispose();
                connExcel.Dispose();
            }
        }
    }
}