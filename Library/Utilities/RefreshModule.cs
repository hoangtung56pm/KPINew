using System;
using System.Web;

namespace VmgPortal.Library.Utilities
{
    public class RefreshModule : IHttpModule
    {
        #region IHttpModule
        // ***********************************************************
        // IHttpModule::Init
        public void Init(HttpApplication app)
        {
            // Register for pipeline events
            app.BeginRequest += new EventHandler(this.OnAcquireRequestState);
        }
        // ***********************************************************
        // IHttpModule::Dispose
        public void Dispose()
        {
        }
        #endregion


        #region Helpers
        // ***********************************************************
        // Determine if a F5 or back/fwd action is in course
        private void OnAcquireRequestState(object sender, EventArgs e)
        {
            // Get access to the HTTP context 
            HttpApplication app = (HttpApplication)sender;
            HttpContext ctx = app.Context;

            // Check F5 action
            RefreshAction.Check(ctx);

            return;
        }
        #endregion
    }
}
