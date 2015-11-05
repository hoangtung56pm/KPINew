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
    public partial class PhongBan : AuthenticatedControl
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

                int id = ConvertUtility.ToInt32(Request.QueryString["idTrungTam"]);
                if (id > 0)
                {
                    dropTruongPhongBan.Items.Clear();
                    dropTruongPhongBan.DataSource = DotDanhGiaController.GetAllNhanVienCapTBP_TP_PP(id);
                    dropTruongPhongBan.DataBind();

                    dropTrungTam.SelectedValue = dropTrungTamSearch.SelectedValue = id.ToString();
                }
                else
                {
                    dropTruongPhongBan.Items.Clear();
                    dropTruongPhongBan.DataSource = DotDanhGiaController.GetAllNhanVienCapTBP_TP_PP(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
                    dropTruongPhongBan.DataBind();
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            DataTable dt = PhongBanController.GetAll(ConvertUtility.ToInt32(dropTrungTamSearch.SelectedValue));

            PhongBanController.LoadPhongBan(dropParent.Items, ConvertUtility.ToInt32(dropTrungTam.SelectedValue));           
            dropParent.Items.Insert(0, new ListItem("Root","0"));

            int id = ConvertUtility.ToInt32(Request.QueryString["idPhong"]);
            if (id > 0)
            {
                PhongBanInfo info = PhongBanController.GetInfo(id);

                if (info != null)
                {
                    dropTrungTam.SelectedValue = info.IDTrungTam.ToString();
                    txtTen.Text = info.Ten;
                    txtMoTa.Text = info.MoTa;
                    txtTyTrong.Text = info.TyTrong.ToString();
                    dropTruongPhongBan.SelectedValue = info.IDNhanVienTruongPhong.ToString();
                    try
                    {
                        dropParent.SelectedValue = info.IDParent.ToString();
                    }
                    catch
                    {
                        dropParent.SelectedIndex = -1;
                    }
                    
                }
            }
            else
            {
                btnUpdate.Visible = false;
            }

            dgrPhongBan.DataSource = dt;
            dgrPhongBan.DataBind();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["idphong"]);

            PhongBanInfo info = new PhongBanInfo();

            info.ID = id;
            info.IDTrungTam = ConvertUtility.ToInt32(dropTrungTam.SelectedValue);
            info.Ten = txtTen.Text.Trim();
            info.MoTa = txtMoTa.Text;
            info.TyTrong = ConvertUtility.ToDouble(txtTyTrong.Text);
            info.IDNhanVienTruongPhong = ConvertUtility.ToInt32(dropTruongPhongBan.SelectedValue);
            info.SoNguoi = 0;//ConvertUtility.ToInt32(txtSoNguoi.Text);
            info.IDParent = ConvertUtility.ToInt32(dropParent.SelectedValue);

            PhongBanController.Update(info);

        }

        protected void dgrPhongBan_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgrPhongBan_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                string id = ConvertUtility.ToString(e.CommandArgument);
                string[] arr = id.Split('_');

                int idPhong = ConvertUtility.ToInt32(arr[0]);
                int idTrungTam = ConvertUtility.ToInt32(arr[1]);
                Response.Redirect(AppEnv.AdminUrlParams("phongban") + "&idTrungTam=" + idTrungTam + "&idPhong=" + idPhong);
            }
            
            if (e.CommandName == "delete")
            {
                string id = ConvertUtility.ToString(e.CommandArgument);
                string[] arr = id.Split('_');

                int idPhong = ConvertUtility.ToInt32(arr[0]);
                int idTrungTam = ConvertUtility.ToInt32(arr[1]);
                try
                {                    
                    PhongBanController.Delete(idPhong);

                    lblStatusUpdate.Text = MiscUtility.MSG_UPDATE_SUCCESS;
                }
                catch (Exception ex)
                {
                    lblStatusUpdate.Text = ex.Message;
                }
            }
        }

        protected void dgrPhongBan_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dgrPhongBan_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex < 0) return;

            DropDownList dropTruongPhong = (DropDownList)e.Row.FindControl("dropTruongPhong");
            dropTruongPhong.Items.Clear();

            DataRowView currData = (DataRowView)e.Row.DataItem;

            DataTable dtNhanVien = DotDanhGiaController.GetAllNhanVienCapTBP_TP_PP(ConvertUtility.ToInt32(dropTrungTamSearch.SelectedValue));

            dropTruongPhong.DataSource = dtNhanVien;
            dropTruongPhong.DataBind();
           
            try
            {
                dropTruongPhong.SelectedValue = currData["IDNhanVienTruongPhong"].ToString();
            }
            catch (Exception)
            {
                dropTruongPhong.SelectedIndex = -1;
            }            
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            PhongBanInfo info = new PhongBanInfo();

            info.IDTrungTam = ConvertUtility.ToInt32(dropTrungTam.SelectedValue);
            info.Ten = txtTen.Text.Trim();
            info.MoTa = txtMoTa.Text;
            info.TyTrong = ConvertUtility.ToDouble(txtTyTrong.Text);
            info.IDNhanVienTruongPhong = ConvertUtility.ToInt32(dropTruongPhongBan.SelectedValue);
            info.SoNguoi = 0;
            info.IDParent = ConvertUtility.ToInt32(dropParent.SelectedValue);
            PhongBanController.Insert(info);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void dropTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(AppEnv.AdminUrlParams("phongban") + "&idTrungTam=" + dropTrungTam.SelectedValue);

        }

    }
}