using System.Collections.Generic;
using System.Data;
using VmgPortal.Library.Helper;
using System.Linq;

namespace VmgPortal.Library.Utilities
{
   
    public class CheckCodeSubcodeExist
    {

        public string CompetitionCheckCodeExist(string strInput, string PK_Competition_ID)
        {

            string[] arrIn = SplitString(strInput, "-");
            string[] arrCheck = new string[10000];

            int n = 0;
            
            //Competition
            DataTable dtCode = Sport_Competition_GetAllCodeSubcode(PK_Competition_ID);
            foreach (DataRow drr in dtCode.Rows)
            {
                string[] arrCode = SplitString(string.Concat(drr["code"].ToString(), "-", drr["subcode"].ToString()), "-");
                for (int i = 0; i < arrCode.Length; i++)
                {
                    if (arrCode[i] == null) break;
                    if (arrCode[i].Trim() != "")
                    {
                        arrCheck[n] = arrCode[i];
                        n++;
                    }
                    else break;
                }
            }



            //Sort
            arrIn = Sort(arrIn);
            arrCheck = Sort(arrCheck);

            //Check Exist
            int m1 = 0;
            int n1 = 0;
            while (true)
            {
                if (arrIn[m1] == null) break;
                if (arrCheck[n1] == null) break;
                if (arrIn[m1].CompareTo(arrCheck[n1]) < 0) m1++;
                else if (arrIn[m1].CompareTo(arrCheck[n1]) > 0) n1++;
                else return arrIn[m1];

            }
            return string.Empty;
        }
        public string CheckCodeExist(string strInput, string PK_Game_ID, string PK_Competition_ID)
        {
            
            string[] arrIn = SplitString(strInput, "-");
            string[] arrCheck = new string[10000];
            
            int n = 0;
            //Get all Code and Subcode from Game and Competition

            //Game
            DataTable dtCode = Sport_Game_GetAllCodeSubcode(PK_Game_ID);
            foreach (DataRow drr in dtCode.Rows)
            {
                string[] arrCode = SplitString(string.Concat(drr["code"].ToString(), "-", drr["subcode"].ToString()), "-");
                for (int i = 0; i < arrCode.Length; i++)
                {
                    if (string.IsNullOrEmpty(arrCode[i]))
                        break;
                    arrCheck[n] = arrCode[i];
                    n++;

                }
            }

            //Competition
            dtCode = Sport_Competition_GetAllCodeSubcode(PK_Competition_ID);
            foreach (DataRow drr in dtCode.Rows)
            {
                string[] arrCode = SplitString(string.Concat(drr["code"].ToString(), "-", drr["subcode"].ToString()), "-");
                for (int i = 0; i < arrCode.Length; i++)
                {
                    if (arrCode[i] == null) break;
                    if (arrCode[i].Trim() != "")
                    {
                        arrCheck[n] = arrCode[i];
                        n++;
                    }
                    else break;
                }
            }



            //Sort
            arrIn = Sort(arrIn);
            arrCheck = Sort(arrCheck);

            //Check Exist
            int m1 = 0;
            int n1 = 0;
            while (true)
            {
                if (arrIn[m1] == null) break;
                if (arrCheck[n1] == null) break;
                if (arrIn[m1].CompareTo(arrCheck[n1]) < 0) m1++;
                else if (arrIn[m1].CompareTo(arrCheck[n1]) > 0) n1++;
                else return arrIn[m1];

            }
            return string.Empty;
        }


        public string CheckCodeExistByRound(string strInput, string PK_Game_ID, string PK_Competition_ID, string FK_Round_ID)
        {

            string[] arrIn = SplitString(strInput, "-");
            string[] arrCheck = new string[3000];

            int n = 0;
            //Get all Code and Subcode from Game and Competition

            //Game
            DataTable dtCode = Sport_Game_GetAllCodeSubcodeByRoundID(PK_Game_ID, FK_Round_ID);
            foreach (DataRow drr in dtCode.Rows)
            {
                string[] arrCode = SplitString(string.Concat(drr["code"].ToString(), "-", drr["subcode"].ToString()), "-");
                for (int i = 0; i < arrCode.Length; i++)
                {
                    if (string.IsNullOrEmpty(arrCode[i]))
                        break;
                    arrCheck[n] = arrCode[i];
                    n++;
                }
            }

            //Competition
            //dtCode = Sport_Competition_GetAllCodeSubcode(PK_Competition_ID);
            //foreach (DataRow drr in dtCode.Rows)
            //{
            //    string[] arrCode = SplitString(string.Concat(drr["code"].ToString(), "-", drr["subcode"].ToString()), "-");
            //    for (int i = 0; i < arrCode.Length; i++)
            //    {
            //        if (arrCode[i] == null) break;
            //        if (arrCode[i].Trim() != "")
            //        {
            //            arrCheck[n] = arrCode[i];
            //            n++;
            //        }
            //        else break;
            //    }
            //}


            //Sort
            arrIn = Sort(arrIn);
            arrCheck = Sort(arrCheck);

            //Check Exist
            int m1 = 0;
            int n1 = 0;
            while (true)
            {
                if (arrIn[m1] == null) break;
                if (arrCheck[n1] == null) break;
                if (arrIn[m1].CompareTo(arrCheck[n1]) < 0) m1++;
                else if (arrIn[m1].CompareTo(arrCheck[n1]) > 0) n1++;
                else return arrIn[m1];

            }
            return string.Empty;
        }

        private string[] Sort(string[] arr)
        {
            int n = 0;
            for (n = 0; n < arr.Length; n++)
                if ((arr[n] == null) || (arr[n] == "")) break;

            for (int i = 0; i < n; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j].CompareTo(arr[min]) < 0) min = j;
                }

                if (i != min)
                {
                    string tg = arr[i];
                    arr[i] = arr[min];
                    arr[min] = tg;
                }
            }
            return arr;
        }

        private string[] SplitString(string strInput, string strSeparator)
        {
            string[] arrOut = new string[500];
            string[] arrIn = strInput.Split(strSeparator.ToCharArray());
            int n = 0;
            for (int i = 0; i < arrIn.Length; i++)
            {
                if (arrIn[i].Trim() != "")
                {
                    arrOut[n] = arrIn[i];
                    n++;
                }
            }
            return arrOut;
        }

        private DataTable Sport_Game_GetAllCodeSubcode(string PK_Game_ID)
        {
            string ConnectionString = AppEnv.ConnectionString;

            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Sport_Game_GetAllCodeSubcode", PK_Game_ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        private DataTable Sport_Game_GetAllCodeSubcodeByRoundID(string PK_Game_ID, string FK_Round_ID)
        {
            string ConnectionString = AppEnv.ConnectionString;

            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Sport_Game_GetAllCodeSubcodeByRoundID", PK_Game_ID, FK_Round_ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        private DataTable Sport_Competition_GetAllCodeSubcode(string PK_Competition_ID)
        {
            string ConnectionString = AppEnv.ConnectionString;

            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "Sport_Competition_GetAllCodeSubcode", PK_Competition_ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        public static string standardize(string Code)
        {
            string returnvalue = Code;
            returnvalue = returnvalue.Replace(" ", "");
            while (returnvalue.StartsWith("-"))
            {
                returnvalue = returnvalue.Substring(1, returnvalue.Length - 1);
            }

            while (returnvalue.EndsWith("-"))
            {
                returnvalue = returnvalue.Substring(0, returnvalue.Length - 1);
            }


            return returnvalue;
        }

    }
}
