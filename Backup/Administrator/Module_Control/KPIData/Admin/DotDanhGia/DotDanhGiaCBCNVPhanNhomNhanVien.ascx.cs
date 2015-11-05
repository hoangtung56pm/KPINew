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
using VmgPortal.Modules.KPIData.Library.Nhom;

namespace VmgPortal.Modules.KPIData.Admin.DotDanhGia
{
    public partial class DotDanhGiaCBCNVPhanNhomNhanVien : AuthenticatedControl
    {
        private int idDotDanhGia;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                dropTrungTam.DataSource = BoPhanController.GetAll();
                dropTrungTam.DataBind();
                dropTrungTam.Items.Insert(0, new ListItem("Tất cả", "0"));

                if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                {
                    dropTrungTam.Enabled = false;
                    dropTrungTam.SelectedValue = CurrentUser.IDTrungTam.ToString();
                }

                dropNhom.DataSource = NhomController.GetAll();
                dropNhom.DataBind();
                dropNhom.SelectedValue = "2";
                dropPortal.Items.Clear();
                PortalController.LoadPortals(dropPortal.Items);
            }

        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            lstNhanVien.Items.Clear();
            lstNhanVien.DataSource = DotDanhGiaController.GetAllNhanVienNotInNhom(ConvertUtility.ToInt32(dropNhom.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            lstNhanVien.DataBind();

            lstNhanVienInDotDanhGia.Items.Clear();
            lstNhanVienInDotDanhGia.DataSource = DotDanhGiaController.GetAllNhanVienInNhom(ConvertUtility.ToInt32(dropNhom.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            lstNhanVienInDotDanhGia.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lstNhanVien.Items)
            {
                if (item.Selected)
                {
                    DotDanhGiaController.UpdateNhanVienVaoNhom(ConvertUtility.ToInt32(item.Value), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropNhom.SelectedValue));

                }
            }
        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lstNhanVienInDotDanhGia.Items)
            {
                if (item.Selected)
                {
                    DotDanhGiaController.UpdateNhanVienVaoNhom(ConvertUtility.ToInt32(item.Value), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 0);
                }
            }
        }

        protected void dropTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}