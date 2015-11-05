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
using VmgPortal.Modules.KPIData.Library;

namespace VmgPortal.Modules.KPIData.Admin.DotDanhGia
{
    public partial class QuanLyNhanVienTheoNDG : AuthenticatedControl
    {
        private int idDotDanhGia;
        protected void Page_Load(object sender, EventArgs e)
        {
            idDotDanhGia = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (!Page.IsPostBack)
            {
                dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(3);
                dropDotDanhGia.DataBind();
                int idDotDanhActive = ConvertUtility.ToInt32(DotDanhGiaController.GetDaultDotDanhGia().Rows[0]["ID"]);
                dropDotDanhGia.SelectedValue = idDotDanhActive.ToString();

                dropTrungTam.DataSource = BoPhanController.BoPhan_GetAllActive();
                dropTrungTam.DataBind();
                dropTrungTam.Items.Insert(0, new ListItem("Tất cả", "0"));
             

                if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                {
                    dropTrungTam.Enabled = false;                    
                }
                dropTrungTam.SelectedValue = CurrentUser.IDTrungTam.ToString();
       
                dropNhanVien.Items.Clear();
                dropNhanVien.DataSource = DotDanhGiaController.GetAllNhanVienCapTBP_TP_PP(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
                dropNhanVien.DataBind();
            }

        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            lstNhanVien.Items.Clear();
            lstNhanVien.DataSource = DotDanhGiaController.QuanLyNhanVienTheoNDG_GetAllNhanVien(ConvertUtility.ToInt32(dropNhanVien.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));
            lstNhanVien.DataBind();

            lstNhanVienInDotDanhGia.Items.Clear();
            lstNhanVienInDotDanhGia.DataSource = DotDanhGiaController.QuanLyNhanVienTheoNDG_ByNhanVienQuanLy(ConvertUtility.ToInt32(dropNhanVien.SelectedValue), ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue),  ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            lstNhanVienInDotDanhGia.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lstNhanVien.Items)
            {
                if (item.Selected)
                {
                    DotDanhGiaController.UpdateNhanVienTheoNDG(ConvertUtility.ToInt32(item.Value), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropNhanVien.SelectedValue), ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));
                }
            }
        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lstNhanVienInDotDanhGia.Items)
            {
                if (item.Selected)
                {
                    DotDanhGiaController.RemoveNhanVienTheoNDG(ConvertUtility.ToInt32(item.Value), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropNhanVien.SelectedValue), ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));
                }
            }
        }

        protected void dropTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropNhanVien.Items.Clear();
            dropNhanVien.DataSource = DotDanhGiaController.GetAllNhanVienCapTBP_TP_PP(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            dropNhanVien.DataBind();
        }

        protected void dropNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dropDotDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}