using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Configuration;
using System.IO;
using System.Web.UI;
using System.IO.Compression;

namespace VmgPortal.Administrator
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            //if (Request.RawUrl.IndexOf(".ashx") < 0)
            //{
            //    HttpApplication app = (HttpApplication)sender;
            //    string acceptEncoding = app.Request.Headers["Accept-Encoding"];
            //    Stream prevUncompressedStream = app.Response.Filter;

            //    if (!(app.Context.CurrentHandler is Page || app.Context.CurrentHandler.GetType().Name == "SyncSessionlessHandler") || app.Request["HTTP_X_MICROSOFTAJAX"] != null)
            //    {
            //        return;
            //    }

            //    if (string.IsNullOrEmpty(acceptEncoding))
            //    {
            //        return;
            //    }

            //    acceptEncoding = acceptEncoding.ToLower();

            //    if (acceptEncoding.Contains("gzip"))
            //    {
            //         gzip
            //        app.Response.Filter = new GZipStream(prevUncompressedStream, CompressionMode.Compress);
            //        app.Response.AppendHeader("Content-Encoding", "gzip");
            //    }
            //    else if (acceptEncoding.Contains("deflate"))
            //    {
            //         defalte
            //        app.Response.Filter = new DeflateStream(prevUncompressedStream, CompressionMode.Compress);
            //        app.Response.AppendHeader("Content-Encoding", "deflate");
            //    }
            //}
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}