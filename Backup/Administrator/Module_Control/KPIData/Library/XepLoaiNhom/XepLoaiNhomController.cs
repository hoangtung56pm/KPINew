using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VmgPortal.Modules.KPIData.Library.Providers;
using System.Data;

namespace VmgPortal.Modules.KPIData.Library.XepLoaiNhom
{
    public class XepLoaiNhomController
    {
        public static DataTable GetAll()
        {
            return DataAccessProvider.Instance().GetAllXepLoaiNhom();
        }

        public static void Delete(int _id)
        {
            DataAccessProvider.Instance().DeleteXepLoaiNhom(_id);
        }

        public static int Insert(XepLoaiNhomInfo _NhomInfo)
        {
            return DataAccessProvider.Instance().InsertXepLoaiNhom(_NhomInfo);
        }

        public static void Update(XepLoaiNhomInfo _NhomInfo)
        {
            DataAccessProvider.Instance().UpdateXepLoaiNhom(_NhomInfo);
        }

        public static XepLoaiNhomInfo GetInfo(int _id)
        {
            return DataAccessProvider.Instance().GetInfoXepLoaiNhom(_id);
        }
    }
}