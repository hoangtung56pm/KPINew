using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.IO;
using System.Globalization;

namespace VmgPortal.Modules.KPIData.Library
{
    public class DateConverter
    {
        static GregorianCalendar _gc = new GregorianCalendar();

        public static int GetDayOfWeek(string day)
        {
            if (day == "Monday")
            {
                return 2;
            }
            else if (day == "Tuesday")
            {
                return 3;
            }
            else if (day == "Wednesday")
            {
                return 4;
            }
            else if (day == "Thursday")
            {
                return 5;
            }
            else if (day == "Friday")
            {
                return 6;
            }
            else
            {
                return 7;
            }
        }
        public int GetWeekOfMonth(DateTime time)
        {
            DateTime first = new DateTime(time.Year, time.Month, 1);
            if (GetWeekOfYear(time) - GetWeekOfYear(first) == 5)
                return GetWeekOfYear(time) - GetWeekOfYear(first);
            else
            return GetWeekOfYear(time) - GetWeekOfYear(first) +1;
        }

        int GetWeekOfYear(DateTime time)
        {
            return _gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }


        public string GetDateTime(string data, string format)
        {
            DateTime dt = DateTime.Parse(data);
            return dt.ToString(format);
        }

        public static string ConvertDataTableToXML(DataTable dtBuildSQL)
        {
            DataSet dsBuildSQL = new DataSet();
            StringBuilder sbSQL;
            StringWriter swSQL;
            string XMLformat;

            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsBuildSQL.Merge(dtBuildSQL, true, MissingSchemaAction.AddWithKey);
            dsBuildSQL.Tables[0].TableName = "Table";
            foreach (DataColumn col in dsBuildSQL.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Element;//.Attribute;
            }
            dsBuildSQL.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
    }
}