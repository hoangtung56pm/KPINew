using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library.Components.Security;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using VmgPortal.Modules.KPIData.Library.Common;
using VmgPortal.Library.Utilities;
using VmgPortal.Library.Components.Users;
using VmgPortal.Library.Components.Roles;
using VmgPortal.Library;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;
using System.Data;

namespace VmgPortal.Administrator.Users
{
    public partial class TrangThaiNhanVien : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropTrungTam.DataSource = BoPhanController.GetAll();
                dropTrungTam.DataBind();
                dropTrungTam.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));
                
                dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
                dropDotDanhGia.DataBind();

                if (ConvertUtility.ToInt32(dropTrungTam.SelectedValue) > 0)
                {
                    dropPhong.DataSource = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
                    dropPhong.DataBind();
                    dropPhong.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));
                }
                else
                {
                    dropPhong.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));
                }

                //int userId = ConvertUtility.ToInt32(Request.QueryString["uid"]);

                //if (userId > 0)
                //{
                //    DataTable dt = DotDanhGiaController.GetTrangThaiNhanVien(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), userId, ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropPhong.SelectedValue));
                //    if (dt != null && dt.Rows.Count > 0)
                //    {
                //        dropTrangThai.SelectedValue = ConvertUtility.ToInt32(dt.Rows[0]["TrangThaiNhanVien"]).ToString();
                //    }
                //}
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            
            int userId = ConvertUtility.ToInt32(Request.QueryString["uid"]);

            if (userId > 0)
            {
                DataTable dt = DotDanhGiaController.GetTrangThaiNhanVien(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), userId, ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropPhong.SelectedValue));
                if (dt != null && dt.Rows.Count > 0)
                {
                    dropTrungTam.SelectedValue = dt.Rows[0]["IDTrungTam"].ToString();
                    dropPhong.SelectedValue = dt.Rows[0]["IDPhongBan"].ToString();
                    dropTrangThai.SelectedValue = dt.Rows[0]["TrangThaiNhanVien"].ToString();
                }
                else 
                {
                    dropTrangThai.SelectedIndex = -1;
                }
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int userId = ConvertUtility.ToInt32(Request.QueryString["uid"]);
                    
                    if (userId > 0)
                    {
                        DotDanhGiaController.UpdateTrangThaiNhanVien(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), userId, ConvertUtility.ToInt32(dropTrangThai.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropPhong.SelectedValue));

                        lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;
                    }
                }
                catch (Exception ex)
                {
                    lblUpdateStatus.Text = ex.Message;
                }
            }
        }

        protected void dropDotDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dropTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropPhong.Items.Clear();
            dropPhong.DataSource = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            dropPhong.DataBind();
            dropPhong.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));
        }
    }
}