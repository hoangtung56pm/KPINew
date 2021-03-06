using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using VmgPortal.Library;
using VmgPortal.Library.Helper;

namespace VmgPortal.Modules.LogFile.Lib
{
    public class  LogFileInfo
    {
        private string _log_Action;
        public string Log_Action
        {
            get { return _log_Action; }
            set { _log_Action = value; }
        }

        private string _log_Type_Object;
        public string Log_Type_Object
        {
            get { return _log_Type_Object; }
            set { _log_Type_Object = value; }
        }

        private string _item_CatID;
        public string Item_CatID
        {
            get { return _item_CatID; }
            set { _item_CatID = value; }
        }

        private string _item_ID;
        public string Item_ID
        {
            get { return _item_ID; }
            set { _item_ID = value; }
        }

        private string _item_Name;
        public string Item_Name
        {
            get { return _item_Name; }
            set { _item_Name = value; }
        }

        private string _description_Before;
        public string Description_Before
        {
            get { return _description_Before; }
            set { _description_Before = value; }
        }

        private string _description_After;
        public string Description_After
        {
            get { return _description_After; }
            set { _description_After = value; }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private int _userID;
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }


    }
    public class CreateLogFile
    {
        private static string client_ip = HttpContext.Current.Request.UserHostAddress;
        private static string clientname = HttpContext.Current.Server.MachineName;
        public static void checkpath(string urlpath)
        {

            if (!Directory.Exists(HttpContext.Current.Server.MapPath(urlpath)))
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(urlpath));
        }
        public static void Perform(string urlpath, string function, string name, int id, string userName, int userid, string userEmail)
        {
            string filename = DateTime.Now.Day + ".txt";
            FileInfo file = new FileInfo(HttpContext.Current.Server.MapPath(urlpath + filename));
            if (file.Exists)
            {
                TextReader tr = new StreamReader(HttpContext.Current.Server.MapPath(urlpath + filename));
                tr.ReadToEnd();
                tr.Close();
                StreamWriter tw = new StreamWriter(HttpContext.Current.Server.MapPath(urlpath + filename), true, Encoding.UTF8, 1);
                tw.WriteLine("-- " + function + ": " + name + "(ID=" + id + ") \n  , vào lúc: " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ff") + " <br>-- bởi: " + userName + "(ID=" + userid + " - UserEmail: " + userEmail + ") -- Tên máy: " + clientname + " -- IP= " + client_ip + "\n <br>-------------------------------------------------------------------- <br>");
                tw.Flush();
                tw.Close();
            }
            else
            {


                StreamWriter tw = new StreamWriter(HttpContext.Current.Server.MapPath(urlpath + filename), true, Encoding.UTF8, 1);
                tw.WriteLine("-- " + function + ": " + name + "(ID=" + id + ") \n  , vào lúc: " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ff") + " <br>-- bởi: " + userName + "(ID=" + userid + " - UserEmail: " + userEmail + ") -- Tên máy: " + clientname + " -- IP= " + client_ip + "\n <br>-------------------------------------------------------------------- <br>");
                tw.Flush();
                tw.Close();

            }
        }

        public static void LogFile_Update_Data(string function, string name, int id, string userName, int userid, string userEmail)
        {
            string urlpath = "/Temp/Update/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/";
            checkpath(urlpath);
            Perform(urlpath, function, name, id, userName, userid, userEmail);
        }
        public static void LogFile_Delete_Data(string function, string name, int id, string userName, int userid, string userEmail)
        {
            string urlpath = "/Temp/Delete/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/";
            checkpath(urlpath);
            Perform(urlpath, function, name, id, userName, userid, userEmail);
        }

        public static void LogAction(LogFileInfo info)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(AppEnv.ConnectionString, "Log_Action_Trace_Insert", 
                    info.Log_Action,
                    info.Log_Type_Object,
                    info.Item_CatID,
                    info.Item_ID,
                    info.Item_Name,
                    info.Description_Before,
                    info.Description_After,
                    info.UserName,
                    info.UserID);
          
            }
            finally
            {
               // con.Close();
            }
        }
    }

}
