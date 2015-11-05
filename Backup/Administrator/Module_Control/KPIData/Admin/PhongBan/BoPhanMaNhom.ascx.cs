using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library.Utilities;
using VmgPortal.Library;
using VmgPortal.Modules.KPIData.Library.PhongBan;
using VmgPortal.Library.Components.Security;
using System.Data;
using VmgPortal.Modules.KPIData.Library.DanhGia;
using VmgPortal.Modules.KPIData.Library.DanhGiaBoPhan;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using VmgPortal.Library.Components.Users;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;
using VmgPortal.Modules.KPIData.Library;

namespace VmgPortal.Modules.KPIData.Admin.PhongBan
{
    public partial class BoPhanMaNhom : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = BoPhanController.BoPhan_GetAllActive();

                dropTrungTam.DataSource = dt;
                dropTrungTam.DataBind();

                dropTrungTamSearch.DataSource = dt;
                dropTrungTamSearch.DataBind();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            DataTable dt = PhongBanController.GetAllNhomCongViec(ConvertUtility.ToInt32(dropTrungTamSearch.SelectedValue));

            dgrNhom.DataSource = dt;
            dgrNhom.DataBind();

            int id = ConvertUtility.ToInt32(Request.QueryString["idnhom"]);
            if (id > 0)
            {
                NhomCongViecInfo info = PhongBanController.GetInfoNhom(id);

                if (info != null)
                {
                    dropTrungTam.SelectedValue = info.IDBoPhan.ToString();
                    txtTen.Text = info.TenNhomViec;
                    txtMoTa.Text = info.MoTa;
                    txtMa.Text = info.Ma.ToString();
                }
            }
            else
            {
                btnUpdate.Visible = false;
            }

           
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["idnhom"]);

            NhomCongViecInfo info = new NhomCongViecInfo();

            info.ID = id;
            info.IDBoPhan = ConvertUtility.ToInt32(dropTrungTam.SelectedValue);
            info.TenNhomViec = txtTen.Text.Trim();
            info.MoTa = txtMoTa.Text;
            info.Ma = txtMa.Text;

            PhongBanController.UpdateNhomCongViec(info);

        }

        protected void dgrNhom_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgrNhom_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                string id = ConvertUtility.ToString(e.CommandArgument);
                string[] arr = id.Split('_');

                int idnhom = ConvertUtility.ToInt32(arr[0]);
                int idTrungTam = ConvertUtility.ToInt32(arr[1]);
                Response.Redirect(AppEnv.AdminUrlParams("nhomcongviec") + "&idTrungTam=" + idTrungTam + "&idnhom=" + idnhom);
            }
            
            if (e.CommandName == "delete")
            {
                string id = ConvertUtility.ToString(e.CommandArgument);
                string[] arr = id.Split('_');

                int idNhom = ConvertUtility.ToInt32(arr[0]);
                int idTrungTam = ConvertUtility.ToInt32(arr[1]);
                try
                {
                    PhongBanController.DeleteNhomCongViec(idNhom);

                    lblStatusUpdate.Text = MiscUtility.MSG_UPDATE_SUCCESS;
                }
                catch (Exception ex)
                {
                    lblStatusUpdate.Text = ex.Message;
                }
            }
        }

        protected void dgrNhom_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dgrNhom_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex < 0) return;
            
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["idnhom"]);

            NhomCongViecInfo info = new NhomCongViecInfo();

            info.IDBoPhan = ConvertUtility.ToInt32(dropTrungTam.SelectedValue);
            info.TenNhomViec = txtTen.Text.Trim();
            info.MoTa = txtMoTa.Text;
            info.Ma = txtMa.Text;

            PhongBanController.InsertNhomCongViec(info);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void dropTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(AppEnv.AdminUrlParams("nhomcongviec") + "&idTrungTam=" + dropTrungTam.SelectedValue);

        }

    }
}