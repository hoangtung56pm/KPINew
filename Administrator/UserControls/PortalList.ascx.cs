using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using VmgPortal.Library;
using VmgPortal.Library.Components.Portal;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Utilities;
using VmgPortal.Library.Components.Lang;

namespace VmgPortal.Administrator.UserControls
{
    public partial class PortalList : AuthenticatedControlTemp
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            DataList1.DataSource = PortalController.GetPortals(CurrentUser.UserID, AppEnv.GetLanguage());
            DataList1.ItemDataBound += new DataListItemEventHandler(DataList1_ItemDataBound);
            DataList1.DataBind();
        }
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView currData = (DataRowView)e.Item.DataItem;
                Image imgAvatar = (Image)e.Item.FindControl("imgAvatar");
                imgAvatar.ImageUrl = ConvertUtility.ToString(currData["ImageUrl"]);
                imgAvatar.Attributes.Add("onclick", "javascript:window.location.href ='/Administrator/Default.aspx?portalid=" + ConvertUtility.ToString(currData["PortalID"])  + "';");
                imgAvatar.ToolTip = ConvertUtility.ToString(currData["Portal_Description"]);
            }
        }

        //protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        //{
            //if(e.CommandName == "Redirect")
            //{
            //    int _portalID = ConvertUtility.ToInt32(e.CommandArgument.ToString());
            //    Session["PortalID"] = _portalID;
            //    Response.Redirect("/Administrator/Default.aspx");
            //}
        //}
    }
}