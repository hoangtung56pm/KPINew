using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VmgPortal.Modules.KPIData.Library.Providers;
using System.Data;

namespace VmgPortal.Modules.KPIData.Library.Nhom
{
    public class NhomController
    {
        public static DataTable GetAll()
        {
            return DataAccessProvider.Instance().GetAllNhom();
        }

        public static void Delete(int _id)
        {
            DataAccessProvider.Instance().DeleteNhom(_id);
        }

        public static int Insert(NhomInfo _NhomInfo)
        {
            return DataAccessProvider.Instance().InsertNhom(_NhomInfo);
        }

        public static void Update(NhomInfo _NhomInfo)
        {
            DataAccessProvider.Instance().InsertNhom(_NhomInfo);
        }

        public static NhomInfo GetInfo(int _id)
        {
            return DataAccessProvider.Instance().GetInfoNhom(_id);
        }
    }
}