using System;
using System.Globalization;
using System.Threading;
using System.Web;
using PKILibary.Asn1.Ocsp;
using VmgPortal.Library.Utilities;
namespace VmgPortal.Library
{
	public class HitCounterHttpModule:IHttpModule
	{
		private HttpApplication _application;
		public void Init(HttpApplication app)
		{
			this._application = app;
			this._application.BeginRequest += new EventHandler(_application_BeginRequest);
		}
		public void _application_BeginRequest(object sender, EventArgs e)
		{
            int count = ConvertUtility.ToInt32(Components.Portal.PortalSetting.GetSetting()[Definition.Portal_Hit_Counter]);
            count++;
            Components.Portal.PortalSetting.SetValue(Definition.Portal_Hit_Counter, count.ToString());
            string langCulture = AppEnv.GetLanguage();
            CultureInfo cur = new CultureInfo(langCulture);
            Thread.CurrentThread.CurrentCulture = cur;
            Thread.CurrentThread.CurrentUICulture = cur;

            //string host = HttpContext.Current.Request.Url.Host;
            //int port = HttpContext.Current.Request.Url.Port;
            //string uri = HttpContext.Current.Request.Url.AbsoluteUri.Trim();
            //string test = "hostname=" + host + "_port= " + port + "_url=" + uri;
            ////test += Request.RawUrl;
            //if (uri.IndexOf("/Game/") > -1)
            //{
            //    //Response.Write(Request.RawUrl.Replace(":8005", ":8006"));
            //    HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl.Replace(":8005", ":8006"));
            //}
            //lblTest.Text = test;
            //Response.Redirect("http://3g.dalink.vn/");
		}
		public void Dispose()
		{
			
		}
	}
}
