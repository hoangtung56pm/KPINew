using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VmgPortal.Modules.KPIData.Library.Providers;
using System.Data;

namespace VmgPortal.Modules.KPIData.Library.DinhNghia
{
    public class DinhNghiaController
    {
        public static DataTable GetAll(string type)
        {
            return DataAccessProvider.Instance().GetAllDinhNghia(type);
        }

        public static void Delete(int _id)
        {
            DataAccessProvider.Instance().DeleteDinhNghia(_id);
        }

        public static int Insert(DinhNghiaInfo _DinhNghiaInfo)
        {
            return DataAccessProvider.Instance().InsertDinhNghia(_DinhNghiaInfo);
        }

        public static void Update(DinhNghiaInfo _DinhNghiaInfo)
        {
            DataAccessProvider.Instance().UpdateDinhNghia(_DinhNghiaInfo);
        }

        public static DinhNghiaInfo GetInfo(int _id)
        {
            return DataAccessProvider.Instance().GetInfoDinhNghia(_id);
        }
               
    }
}