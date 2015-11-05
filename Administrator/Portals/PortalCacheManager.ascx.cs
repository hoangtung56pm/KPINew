using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using VmgPortal.Library.Components;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Utilities;

namespace Portal.Administrator.Portals
{
	public partial class PortalCacheManager : AuthenticatedControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            lblUpdateStatus.Text = string.Empty;

            if (!IsPostBack)
            {
                HttpContext context = HttpContext.Current;
                IEnumerator dcEnum = context.Cache.GetEnumerator();
                ArrayList _cacheArray = new ArrayList();
                while (dcEnum.MoveNext())
                    if (((DictionaryEntry) dcEnum.Current).Value != null)
                        _cacheArray.Add(((DictionaryEntry) dcEnum.Current).Key.ToString());
                _cacheArray.Sort();
                lstAllCache.DataSource = _cacheArray;
                lstAllCache.DataBind();
            }
		}

		protected void btnRemoveAll_Click(object sender, EventArgs e)
		{
            DataCaching data = new DataCaching();
            foreach (ListItem item in lstAllCache.Items)
               data.RemoveCache(item.Text);
           lstAllCache.DataBind();
            lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;
		}

       
       
		
	}
}