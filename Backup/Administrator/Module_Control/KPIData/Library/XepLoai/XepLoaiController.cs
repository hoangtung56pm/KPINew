using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VmgPortal.Modules.KPIData.Library.Providers;
using System.Data;

namespace VmgPortal.Modules.KPIData.Library.XepLoai
{
    public class XepLoaiController
    {
        public static DataTable GetAll()
        {
            return DataAccessProvider.Instance().GetAllXepLoai();
        }

        public static void Delete(int _id)
        {
            DataAccessProvider.Instance().DeleteXepLoai(_id);
        }

        public static int Insert(XepLoaiInfo _xepLoaiInfo)
        {
            return DataAccessProvider.Instance().InsertXepLoai(_xepLoaiInfo);
        }

        public static void Update(XepLoaiInfo _xepLoaiInfo)
        {
            DataAccessProvider.Instance().InsertXepLoai(_xepLoaiInfo);
        }

        public static XepLoaiInfo GetInfo(int _id)
        {
            return DataAccessProvider.Instance().GetInfoXepLoai(_id);
        }
    }
}