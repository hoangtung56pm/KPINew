using System;
using System.Collections;
using System.Web;

namespace VmgPortal.Library.Utilities
{
    public class RefreshAction
    {
        #region Constants
        // ***********************************************************
        // Constants
        public const string LastRefreshTicketEntry = "__LASTREFRESHTICKET";
        public const string CurrentRefreshTicketEntry = "__CURRENTREFRESHTICKET";
        public const string PageRefreshEntry = "IsRefreshed";
        public const string NextPageTicketEntry = "__NEXTPAGETICKET";
        #endregion

        static Hashtable requestHistory = null;

        // ***********************************************************
        // Manage to check if the F5 button has been pressed
        public static void Check(HttpContext ctx)
        {
            // Initialize the ticket slot
            EnsureRefreshTicket(ctx);

            // Read the last ticket served in the session (from Session)
            int lastTicket = GetLastRefreshTicket(ctx);

            // Read the ticket of the current request (from a hidden field)
            int thisTicket = GetCurrentRefreshTicket(ctx, lastTicket);

            // Compare tickets
            if (thisTicket > lastTicket ||
                (thisTicket == lastTicket && thisTicket == 0))
            {
                UpdateLastRefreshTicket(ctx, thisTicket);
                ctx.Items[PageRefreshEntry] = false;
            }
            else
            {
                ctx.Items[PageRefreshEntry] = true;
            }
        }

        // ***********************************************************
        // Initialize the internal data store 
        private static void EnsureRefreshTicket(HttpContext ctx)
        {
            // Initialize the session slots for the page (Ticket) and the module (LastTicketServed)
            if (requestHistory == null)
                requestHistory = new Hashtable();
        }


        // ***********************************************************
        // Return the last-served ticket for the URL
        private static int GetLastRefreshTicket(HttpContext ctx)
        {
            // Extract and return the last ticket
            if (!requestHistory.ContainsKey(ctx.Request.RawUrl))
                return 0;
            else
                return (int)requestHistory[ctx.Request.RawUrl];
        }


        // ***********************************************************
        // Return the ticket associated with the page
        private static int GetCurrentRefreshTicket(HttpContext ctx, int lastTicket)
        {
            int ticket;
            object o = ctx.Request[CurrentRefreshTicketEntry];
            if (o == null)
                ticket = lastTicket;
            else
                ticket = Convert.ToInt32(o);

            ctx.Items[RefreshAction.NextPageTicketEntry] = ticket + 1;
            return ticket;
        }


        // ***********************************************************
        // Store the last-served ticket for the URL
        private static void UpdateLastRefreshTicket(HttpContext ctx, int ticket)
        {
            // Item overwrites, Add does not
            requestHistory[ctx.Request.RawUrl] = ticket;
        }
    }
}
