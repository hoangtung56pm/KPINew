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
    public partial class DotDanhGiaTruongBoPhanChiTiet : AuthenticatedControl
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

                dropTrungTam.DataSource = BoPhanController.GetAll();
                dropTrungTam.DataBind();
                dropTrungTam.Items.Insert(0, new ListItem("Tất cả", "0"));

                if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                {
                    dropTrungTam.Enabled = false;
                    dropTrungTam.SelectedValue = CurrentUser.IDTrungTam.ToString();
                }

                dropPortal.Items.Clear();
                PortalController.LoadPortals(dropPortal.Items);
            }

        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            lstNhanVien.Items.Clear();
            lstNhanVien.DataSource = DotDanhGiaController.GetAllTruongBoPhanNotInDotDanhGia(idDotDanhGia, ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            lstNhanVien.DataBind();

            lstNhanVienInDotDanhGia.Items.Clear();
            lstNhanVienInDotDanhGia.DataSource = DotDanhGiaController.GetAllTruongBoPhanInDotDanhGia(idDotDanhGia, ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            lstNhanVienInDotDanhGia.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lstNhanVien.Items)
            {
                if (item.Selected)
                {
                    if (dropTrungTam.SelectedValue != "0" && dropTrungTam.SelectedValue != "12")
                    {
                        DotDanhGiaController.UpdateTruongBoPhanVaoDotDanhGia(idDotDanhGia, ConvertUtility.ToInt32(item.Value), ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
                    }
                    else
                    {
                        string[] array = item.Value.Split('_');
                        DotDanhGiaController.UpdateTruongBoPhanVaoDotDanhGia(idDotDanhGia, ConvertUtility.ToInt32(array[0]), ConvertUtility.ToInt32(array[1]));
                    }
                }
            }
        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lstNhanVienInDotDanhGia.Items)
            {
                if (item.Selected)
                {
                    if (dropTrungTam.SelectedValue != "0" && dropTrungTam.SelectedValue != "12")
                    {
                        DotDanhGiaController.RemoveTruongBoPhanVaoDotDanhGia(idDotDanhGia, ConvertUtility.ToInt32(item.Value), ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
                    }
                    else
                    {
                        string[] array = item.Value.Split('_');
                        DotDanhGiaController.RemoveTruongBoPhanVaoDotDanhGia(idDotDanhGia, ConvertUtility.ToInt32(array[0]), ConvertUtility.ToInt32(array[1]));
                    }
                }
            }
        }

        protected void dropTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}