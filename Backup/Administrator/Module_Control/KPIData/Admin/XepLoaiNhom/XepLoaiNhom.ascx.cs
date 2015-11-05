using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library.Components.Security;
using VmgPortal.Modules.KPIData.Library.Nhom;
using VmgPortal.Modules.KPIData.Library.XepLoai;
using VmgPortal.Modules.KPIData.Library.XepLoaiNhom;
using VmgPortal.Library.Utilities;
using VmgPortal.Library;

namespace VmgPortal.Modules.KPIData.Admin.XepLoaiNhom
{
    public partial class XepLoaiNhom : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropNhom.DataSource = NhomController.GetAll();
                dropNhom.DataBind();
                dropNhom.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));

                dropXepLoai.DataSource = XepLoaiController.GetAll();
                dropXepLoai.DataBind();
                dropXepLoai.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));

            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (id > 0)
            {
                XepLoaiNhomInfo info = XepLoaiNhomController.GetInfo(id);

                if (info != null)
                {
                    dropNhom.SelectedValue = info.IDNhomNhanVien.ToString();
                    dropXepLoai.SelectedValue = info.IDXepLoai.ToString();
                    txtMin.Text = info.Min.ToString();
                    txtMax.Text = info.Max.ToString();
                }
            }
            else 
            {
                btnUpdate.Visible = false;
            }
            dgrXepLoaiNhom.DataSource = XepLoaiNhomController.GetAll();
            dgrXepLoaiNhom.DataBind();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            XepLoaiNhomInfo info = new XepLoaiNhomInfo();

            info.ID = id;
            info.IDNhomNhanVien = ConvertUtility.ToInt32(dropNhom.SelectedValue);
            info.IDXepLoai = ConvertUtility.ToInt32(dropXepLoai.SelectedValue);
            info.Min = ConvertUtility.ToInt32(txtMin.Text);
            info.Max = ConvertUtility.ToInt32(txtMax.Text);

            XepLoaiNhomController.Update(info);

        }

        protected void dgrXepLoaiNhom_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgrXepLoaiNhom_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                int id = ConvertUtility.ToInt32(e.CommandArgument);

                Response.Redirect(AppEnv.AdminUrlParams("xeploainhom") + "&id=" + id);
            }

            if (e.CommandName == "delete")
            {
                try
                {
                    int id = ConvertUtility.ToInt32(e.CommandArgument);

                    XepLoaiNhomController.Delete(id);

                    lblStatusUpdate.Text = MiscUtility.MSG_UPDATE_SUCCESS;
                }
                catch (Exception ex)
                {
                    lblStatusUpdate.Text = ex.Message;
                }
            }
        }

        protected void dgrXepLoaiNhom_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            XepLoaiNhomInfo info = new XepLoaiNhomInfo();

            info.IDNhomNhanVien = ConvertUtility.ToInt32(dropNhom.SelectedValue);
            info.IDXepLoai = ConvertUtility.ToInt32(dropXepLoai.SelectedValue);
            info.Min = ConvertUtility.ToInt32(txtMin.Text);
            info.Max = ConvertUtility.ToInt32(txtMax.Text);

            XepLoaiNhomController.Insert(info);
        }
    }
}