using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VmgPortal.Administrator
{
    public partial class Ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("ctrl") != null)
            {
                string ctrlSrc = Request.QueryString.Get("ctrl").Trim().ToLower() + ".ascx";
                //load control
                plhUserControl.Controls.Add(LoadControl(ctrlSrc));
            }
        }
    }
}
