using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VmgPortal.Library.Controls
{
	public class SnapHeader : ITemplate
	{
		public string SnapID;
		public string Title;
		public string Icon = "/administrator/images/snap_icon.gif";
		public void InstantiateIn(Control container)
		{
			Literal L1 = new Literal();
			L1.Text = "<table class=\"SnapHeader\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\">";
			L1.Text += "<tr class='SnapHeader'>";
			L1.Text += "<td style=\"width:16px;padding:3px;cursor:move;\" onmousedown=\" " + SnapID + ".StartDragging(event);\"><img src=\"" + Icon +"\" alt=\"\" width=\"16\" height=\"16\" /></td>";
			L1.Text += "<td style=\"width:100%;padding:3px;font-size:11px;cursor:move;\" onmousedown=\" " + SnapID + ".StartDragging(event);\">" + Title + "</td>";
			L1.Text += "<td style=\"width:15px;padding:1px;\"><img onclick=\" " + SnapID + ".ToggleExpand();\" src=\"/administrator/images/toggle_expand.gif\" alt=\"\" width=\"15\" height=\"14\" style=\"cursor:pointer;\" onmouseover=\"this.src='/administrator/images/toggle_expandHover.gif';\" onmouseout=\"this.src='/administrator/images/toggle_expand.gif';\" onmousedown=\"this.src='/administrator/images/toggle_expandActive.gif';\" onmouseup=\"this.src='/administrator/images/toggle_expandHover.gif';\" /></td>";
			L1.Text += "<td style=\"width:15px;padding:1px;padding-right:3px;\"><img onclick=\" " + SnapID + ".ToggleMinimize();ToggleItemCheckedState(0);\" src=\"/administrator/images/toggle_minimize.gif\" alt=\"\" width=\"15\" height=\"14\" style=\"cursor:pointer;\" onmouseover=\"this.src='/administrator/images/toggle_minimizeHover.gif';\" onmouseout=\"this.src='/administrator/images/toggle_minimize.gif';\" onmousedown=\"this.src='/administrator/images/toggle_minimizeActive.gif';\" onmouseup=\"this.src='/administrator/images/toggle_minimizeHover.gif';\" /></td>";
			L1.Text += "</tr></table>";
			
			container.Controls.Add(L1);
			
		}
	}
}
