using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VmgPortal.Library.Controls
{
    public class GridViewRepair : System.Web.UI.WebControls.GridView
	{
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			this.PageIndexChanging += new GridViewPageEventHandler(GridView_PageIndexChanging);
		}
		protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			this.PageIndex = e.NewPageIndex;
		}
       
	}
}
