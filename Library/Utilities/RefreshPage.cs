using System;
using System.Web;
using System.Web.UI;

namespace VmgPortal.Library.Utilities
{
	public class RefreshPage : System.Web.UI.Page
	{
        #region New Properties

        public bool IsRefreshed
        {
            get
            {
                object o = HttpContext.Current.Items[RefreshAction.PageRefreshEntry];
                if (o == null)
                    return false;
                return (bool)o;
            }
        }
        #endregion


        #region Overrides
        // **************************************************************
        // Handle the PreRenderComplete event
        protected override void OnPreRenderComplete(EventArgs e)
        {
            base.OnPreRenderComplete(e);
            SaveRefreshState();
        }
        #endregion


        #region Helpers
        // **************************************************************
        // Create the hidden field to store the current request ticket
        private void SaveRefreshState()
        {
            int ticket = ConvertUtility.ToInt32(HttpContext.Current.Items[RefreshAction.NextPageTicketEntry]);

            ClientScript.RegisterHiddenField(RefreshAction.CurrentRefreshTicketEntry,
                                             ticket.ToString());
        }

	    #endregion


	}// class
}
