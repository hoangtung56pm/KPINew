using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library.Utilities;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using VmgPortal.Library.Components.Portal;
using VmgPortal.Library.Components.Users;
using VmgPortal.Library;
using VmgPortal.Library.Components.Security;

namespace VmgPortal.Modules.KPIData.Admin.DotDanhGia
{
    public partial class DotDanhGiaBoPhan : AuthenticatedControl
    {
        private int idDotDanhGia;
        protected void Page_Load(object sender, EventArgs e)
        {
            idDotDanhGia = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (!Page.IsPostBack)
            {
                DotDanhGiaInfo info = DotDanhGiaController.GetInfo(idDotDanhGia);
                if (info == null)
                {
                    this.btnAdd.Visible = false;
                    this.btnRemove.Visible = false;
                    return;
                }
                lblDotDanhGiaName.Text = info.Ten;

                dropPortal.Items.Clear();
                PortalController.LoadPortals(dropPortal.Items);
            }

        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            lstBoPhan.Items.Clear();
            lstBoPhan.DataSource = DotDanhGiaController.GetAllBoPhanNotInDotDanhGia(idDotDanhGia);
            lstBoPhan.DataBind();

            lstBoPhanInDotDanhGia.Items.Clear();
            lstBoPhanInDotDanhGia.DataSource = DotDanhGiaController.GetAllBoPhanInDotDanhGia(idDotDanhGia);
            lstBoPhanInDotDanhGia.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lstBoPhan.Items)
            {
                if (item.Selected)
                {
                    DotDanhGiaController.UpdateBoPhanVaoDotDanhGia(idDotDanhGia, ConvertUtility.ToInt32(item.Value));
                }
            }
        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lstBoPhanInDotDanhGia.Items)
            {
                if (item.Selected)
                {
                    DotDanhGiaController.RemoveBoPhanTrongDotDanhGia(idDotDanhGia, ConvertUtility.ToInt32(item.Value));
                }
            }
        }

        protected void dropTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}