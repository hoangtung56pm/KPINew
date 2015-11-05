using System.Data;
using System.Web.UI.WebControls;

using VmgPortal.Library.Components.Providers;
using VmgPortal.Library.Utilities;

namespace VmgPortal.Library.Components.Lang
{
    public class MainLanguagesController
    {
        public static DataTable GetAll()
        {
            const string key = "VmgPortal.Portal.MainLanguages.GetAll";
            DataCaching data = new DataCaching();
            DataTable dtLang = (DataTable)data.GetCache(key);
            if (dtLang != null) return dtLang;
            dtLang = DataAccessProvider.Instance().GetAll();
            data.InsertCacheNoExpireTime(key, dtLang);
            return dtLang;
        }
    }
}
