using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VmgPortal.Library.Controls
{
	public class GridView : System.Web.UI.WebControls.GridView
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
        protected override void OnRowCreated(GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Pager) return;
            foreach (Control pager in e.Row.Cells[0].Controls)
            {
                foreach (Control row in pager.Controls)
                {
                    foreach (Control cell in row.Controls)
                    {
                        foreach (Control c in cell.Controls)
                        {
                            if (c.GetType().ToString() == "System.Web.UI.WebControls.DataControlPagerLinkButton")
                            {
                                LinkButton lnk = (LinkButton)c;
                                lnk.Text = "|&nbsp;" + lnk.Text + "&nbsp;|";
                            }
                            if (c.GetType().ToString() == "System.Web.UI.WebControls.Label")
                            {
                                Label lbl = (Label)c;
                                if (AppEnv.GetLanguage() == "vi-VN")
                                {
                                    lbl.Text = "<b>Trang " + lbl.Text + "</b>";
                                }
                                else
                                {
                                    lbl.Text = "Page " + lbl.Text;
                                }
                            }
                        }
                    }
                }
            }
        }
	}
}
