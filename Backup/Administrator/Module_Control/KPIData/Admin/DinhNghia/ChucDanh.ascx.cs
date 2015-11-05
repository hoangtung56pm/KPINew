using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library.Utilities;
using VmgPortal.Library;
using VmgPortal.Modules.KPIData.Library.DinhNghia;
using VmgPortal.Library.Components.Security;
using System.Data;
using VmgPortal.Modules.KPIData.Library.DanhGia;
using VmgPortal.Modules.KPIData.Library.DanhGiaBoPhan;
using VmgPortal.Modules.KPIData.Library.BoPhan;

namespace VmgPortal.Modules.KPIData.Admin.DinhNghia
{
    public partial class ChucDanh : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (id > 0)
            {
                DinhNghiaInfo info = DinhNghiaController.GetInfo(id);

                if (info != null)
                {
                    txtTen.Text = info.Ten.ToString();
                    txtMoTa.Text = info.MoTa;
                    dropTypeOf.SelectedValue = info.Code.ToString();
                }
            }
            else
            {
                btnUpdate.Visible = false;
            }
            dgrChucDanh.DataSource = DinhNghiaController.GetAll(dropTypeOf.SelectedValue);
            dgrChucDanh.DataBind();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            DinhNghiaInfo info = new DinhNghiaInfo();

            info.ID = id;
            info.Ten = txtTen.Text.Trim();
            info.MoTa = txtMoTa.Text;
            info.Code = dropTypeOf.SelectedValue;
            DinhNghiaController.Update(info);

        }

        protected void dgrChucDanh_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgrChucDanh_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                int id = ConvertUtility.ToInt32(e.CommandArgument);

                Response.Redirect(AppEnv.AdminUrlParams("dinhnghia") + "&id=" + id);
            }
            
            if (e.CommandName == "delete")
            {
                try
                {
                    int id = ConvertUtility.ToInt32(e.CommandArgument);

                    DinhNghiaController.Delete(id);

                    lblStatusUpdate.Text = MiscUtility.MSG_UPDATE_SUCCESS;
                }
                catch (Exception ex)
                {
                    lblStatusUpdate.Text = ex.Message;
                }
            }
        }

        protected void dgrChucDanh_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dgrChucDanh_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex < 0) return;

            DropDownList dropTypeOf1 = (DropDownList)e.Row.FindControl("dropTypeOf1");

            DataRowView currData = (DataRowView)e.Row.DataItem;

            dropTypeOf1.SelectedValue = currData["Code"].ToString();

        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            DinhNghiaInfo info = new DinhNghiaInfo();

            info.Ten = txtTen.Text.Trim();
            info.MoTa = txtMoTa.Text;
            info.Code = dropTypeOf.SelectedValue;
            DinhNghiaController.Insert(info);
        }

    }
}