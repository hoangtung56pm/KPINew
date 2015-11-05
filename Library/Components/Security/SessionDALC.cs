using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Security.Cryptography;


namespace VmgPortal.Library.Components.Security
{
    
    public class SessionDALC
    {
        //public void SetCookie(HttpContext ctx, string UserName)
        //{

        //    SessionObject ObjSession = new SessionObject();
        //    TripleDESCryptoServiceProvider tDESalg = new TripleDESCryptoServiceProvider();
        //    ObjSession.Ticket = ctx.Session.SessionID + UserName;
        //    ObjSession.UserName = UserName;
        //    ObjSession.Key = tDESalg.Key;
        //    ObjSession.IV = tDESalg.IV;
        //    InsertSession(ObjSession);

        //    //Set Cookie
        //    HttpCookie MyCookie = new HttpCookie("PassportCookie");
        //    MyCookie.Values["Ticket"] = SSOSecurity.Encrypt(ObjSession.Ticket, tDESalg.Key, tDESalg.IV);
        //    MyCookie.Values["Name"] = UserName;
        //    MyCookie.Expires = DateTime.Now.AddMinutes(20);
        //    ctx.Response.Cookies.Add(MyCookie);

        //}

        //public bool IsAuthenticate(System.Web.HttpContext Context)
        //{
        //    if (Context.Session["Ticket"] != null)
        //    {
        //        if (ServerValidateTicket(Context.Session["Ticket"].ToString()))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        //public bool ServerValidateTicket(string Ticket)
        //{
        //    SqlParameter[] Para = new SqlParameter[1];
        //    Para[0] = new SqlParameter("@Ticket", SqlDbType.NVarChar);
        //    Para[0].Value = Ticket;

        //    int Count = Convert.ToInt32(SqlHelper.ExecuteScalar(conString, CommandType.Text, ListSqlCommands.Session_ValidateTicket, Para));
        //    bool Authenticate = true;
        //    if (Count == 0)
        //    {
        //        Authenticate = false;

        //    }
        //    return Authenticate;
        //}
        //public DataSet  GetAll(string UserName)
        //{
        //    SqlParameter[] Para = new SqlParameter[1];
        //    Para[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
        //    Para[0].Value = UserName;
        //    return  SqlHelper.ExecuteDataset(conString, CommandType.Text, ListSqlCommands.Session_GetTicket, Para);           

        //}
        //public void  DeleteByName(string UserName)
        //{
        //    SqlParameter[] Para = new SqlParameter[1];
        //    Para[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
        //    Para[0].Value = UserName;
        //     SqlHelper.ExecuteNonQuery (conString, CommandType.Text, ListSqlCommands.Session_DeleteByUserName, Para);

        //}
        //public int GetLoginID(string Ticket)
        //{
        //    SqlParameter[] Para = new SqlParameter[1];
        //    Para[0] = new SqlParameter("@Ticket", SqlDbType.VarChar);
        //    Para[0].Value = Ticket;
        //    DataSet ds = SqlHelper.ExecuteDataset(conString, CommandType.Text, ListSqlCommands.Session_GetLoginID, Para);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        if (ds.Tables[0].Rows[0]["LoginID"] == DBNull.Value )
        //        {
        //            return 0;
        //        }
        //        else
        //        {
        //            return Convert.ToInt32(ds.Tables[0].Rows[0]["LoginID"]);
        //        }
        //    }
        //    return 0;
        //}
        //public bool HaveLoginID(string Ticket)
        //{
        //    if (GetLoginID(Ticket) > 0)
        //    {
        //        return true;
        //    }
        //    return false;            
            
        //}
        //public void InsertConnection(string UserName, int SiteID)
        //{
        //    SqlParameter[] Para = new SqlParameter[2];
        //    Para[0] = new SqlParameter("@UserName", SqlDbType.NVarChar);
        //    Para[0].Value =UserName ;
        //    Para[1] = new SqlParameter("@SiteID", SqlDbType.Int );
        //    Para[1].Value = SiteID;
        //    //Verify that this connection does not exsit
        //    int Count = Convert.ToInt32(SqlHelper.ExecuteScalar(conString, CommandType.Text, ListSqlCommands.Site_SelectConnection, Para));
        //    if (Count == 0)
        //    {
        //        SqlHelper.ExecuteNonQuery(conString, CommandType.Text, ListSqlCommands.Site_InsertConnection, Para); 
        //    }


            
        //}
        //public void DeleteConnection(string UserName, int  SiteID)
        //{
        //    SqlParameter[] Para = new SqlParameter[2];
        //    Para[0] = new SqlParameter("@UserName", SqlDbType.NVarChar);
        //    Para[0].Value = UserName;
        //    Para[1] = new SqlParameter("@SiteID", SqlDbType.Int);
        //    Para[1].Value = SiteID;
        //    SqlHelper.ExecuteNonQuery(conString, CommandType.Text, ListSqlCommands.Site_DeleteConnection , Para);
        //    int NumberConnection = Convert.ToInt32(SqlHelper.ExecuteScalar(conString, CommandType.Text, ListSqlCommands.Site_SelectByName, Para));
        //    if (NumberConnection == 0)
        //    { 
        //        //User Siteout
        //        DeleteByName(UserName);

        //    }
        //}

        //private DataSet GetKeyAndIVByNameAndLoginID(string Name, int LoginID)
        //{

        //    SqlParameter[] Para = new SqlParameter[2];
        //    Para[0] = new SqlParameter("@UserName", SqlDbType.NVarChar);
        //    Para[0].Value = Name ;
        //    Para[1] = new SqlParameter("@LoginID", SqlDbType.Int);
        //    Para[1].Value = LoginID;
        //    return SqlHelper.ExecuteDataset(conString, CommandType.Text, ListSqlCommands.Session_GetkeyAndIVByNameAndTicket, Para);

        //}
        //public bool VerifyLogin(string Ticket,string Name, int  LoginID)
        //{
        //    //Get Key And IV to Decrypt this ticket
        //    DataSet ds = GetKeyAndIVByNameAndLoginID(Name, LoginID);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        byte[] Key = (byte[])ds.Tables[0].Rows[0]["Key"];
        //        byte[] IV = (byte[])ds.Tables[0].Rows[0]["IV"];

        //        SqlParameter[] Para = new SqlParameter[2];
        //        Para[0] = new SqlParameter("@LoginID", SqlDbType.NVarChar);
        //        Para[0].Value = LoginID;
        //        Para[1] = new SqlParameter("@Ticket", SqlDbType.NVarChar);
        //        Para[1].Value = SSOSecurity.Decrypt(Ticket, Key, IV);
        //        int Count = Convert.ToInt32(SqlHelper.ExecuteScalar(conString, CommandType.Text, ListSqlCommands.Session_VerifyLogin, Para));
        //        if (Count > 0)
        //        {
        //            return true;
        //        }
        //        else {
        //            return false;
        //        }

             
        //    }
        //    return false;

        //}
        //public void UpdateLoginID(SessionObject ObjSession)
        //{
        //    SqlParameter[] Para = new SqlParameter[2];
        //    Para[0] = new SqlParameter("@LoginID", SqlDbType.NVarChar);
        //    Para[0].Value = ObjSession.LoginID ;
        //    Para[1] = new SqlParameter("@Ticket", SqlDbType.NVarChar);
        //    Para[1].Value = ObjSession.Ticket;
        //    SqlHelper.ExecuteNonQuery(conString, CommandType.Text, ListSqlCommands.Session_UpdateLoginID, Para);

        //}
        //public DataSet GetKeyAndIVByUserName(string UserName)
        //{
        //    SqlParameter[] Para = new SqlParameter[1];
        //    Para[0] = new SqlParameter("@UserName", SqlDbType.NVarChar);
        //    Para[0].Value = UserName ;
        //    return SqlHelper.ExecuteDataset(conString, CommandType.Text, ListSqlCommands.Session_GetKeyAndIVByName, Para);
            
        //}
     
        //public bool Check_Already_SignIn(string UserName)
        //{
        //    SqlParameter[] Para = new SqlParameter[1];
        //    Para[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
        //    Para[0].Value = UserName;
        //    bool Already_SignIn = true;

        //    int Count = Convert.ToInt32(SqlHelper.ExecuteScalar(conString, CommandType.Text, ListSqlCommands.Session_Check_Already_SignIn, Para));    
        //    if (Count == 0)
        //    {
        //        Already_SignIn = false;
        //    }
        //    return Already_SignIn;


        //}

        
       
      
        //public bool ClientValidateTicket(string Ticket,string Name)
        //{
        //    DataSet ds = GetKeyAndIVByUserName(Name);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        byte[] Key = (byte[])ds.Tables[0].Rows[0]["Key"];
        //        byte[] IV = (byte[])ds.Tables[0].Rows[0]["IV"];

        //        SqlParameter[] Para = new SqlParameter[1];
        //        Para[0] = new SqlParameter("@Ticket", SqlDbType.NVarChar);
        //        Para[0].Value = SSOSecurity.Decrypt(Ticket, Key, IV);

        //        int Count = Convert.ToInt32(SqlHelper.ExecuteScalar(conString, CommandType.Text, ListSqlCommands.Session_ValidateTicket, Para));
        //        if (Count > 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    return false ;
        //}
        //public void InsertSession(SessionObject objSession)
        //{
        //    SqlParameter[] Para = new SqlParameter[4];
        //    Para[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
        //    Para[0].Value = objSession.UserName;
        
        //    Para[1] = new SqlParameter("@IV", SqlDbType.Binary);
        //    Para[1].Value = objSession.IV ;           

        //    Para[2] = new SqlParameter("@Key", SqlDbType.Binary );
        //    Para[2].Value = objSession.Key ;
        //    Para[3] = new SqlParameter("@Ticket", SqlDbType.NVarChar );
        //    Para[3].Value = objSession.Ticket;
        //    SqlHelper.ExecuteNonQuery(conString, CommandType.Text, ListSqlCommands.Session_Insert, Para);


        //}

        
        //public void SignOut(string Ticket)
        //{ 
        //    SqlParameter[] Para = new SqlParameter[1];           
        //    Para[0] = new SqlParameter("@Ticket", SqlDbType.NVarChar);
        //    Para[0].Value = Ticket;
        //    SqlHelper.ExecuteNonQuery(conString, CommandType.Text, ListSqlCommands.Session_Delete, Para);
        //}
    }

}

