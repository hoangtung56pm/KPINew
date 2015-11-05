using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library.Components.Security;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;
using System.Data;
using VmgPortal.Library.Utilities;
using VmgPortal.Library.Components.Users;
using VmgPortal.Modules.KPIData.Library;
using VmgPortal.Modules.KPIData.Library.Common;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using System.Drawing;
using VmgPortal.Modules.KPIData.Library.DanhGia;

namespace VmgPortal.Modules.KPIData.Admin.BaoCao.XepLoaiThang.NhanVien
{
    public partial class BaoCaoTyTrongCVCuaNhanVien : AuthenticatedControl
    {
        int idNhanVien = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dropTrungTam.DataSource = BoPhanController.GetAll();
                dropTrungTam.DataBind();

                if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                {
                    dropTrungTam.Enabled = false;
                    dropTrungTam.SelectedValue = CurrentUser.IDTrungTam.ToString();
                }

                dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
                dropDotDanhGia.DataBind();

                //DataTable dtPhong;
                //if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                //{
                //    dropTrungTam.Enabled = false;

                //    if (CurrentUser.RoleID != (int)Constants.Role.TruongBoPhanKhoiHoTro && CurrentUser.RoleID != (int)Constants.Role.TruongBoPhanKhoiKinhDoanh)
                //    {
                //        dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), CurrentUser.UserID);
                //    }
                //    else
                //    {
                //        dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
                //    }
                //}
                //else
                //{
                //    dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
                //}

                //dropPhongBan.DataSource = dtPhong;
                //dropPhongBan.DataBind();
                //dropPhongBan.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));
                //try
                //{
                //    dropPhongBan.SelectedValue = CurrentUser.IDPhong.ToString();
                //}
                //catch (Exception)
                //{
                //    dropPhongBan.SelectedIndex = -1;
                //}

            }
        }

        //protected void dropTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    dropPhongBan.Items.Clear();
        //    dropPhongBan.DataSource = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
        //    dropPhongBan.DataBind();
        //    dropPhongBan.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));
        //}

        //protected void dropPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //}

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            DataTable dt = new DataTable();

            dt.Columns.Add("HoTen", typeof(String));
            dt.Columns.Add("ChucVu", typeof(String));
            dt.Columns.Add("TTCVThuongXuyen", typeof(String));
            dt.Columns.Add("TTCVKeHoachThang", typeof(String));
            dt.Columns.Add("TTCVPhatSinh", typeof(String));
            dt.Columns.Add("TTConLai", typeof(String));
            //dt.Columns.Add("TTSoVoiBoPhan", typeof(String));

            DataTable dtNhanVien = DotDanhGiaController.GetAllNhanVien(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 0);

            if (dtNhanVien == null) return;

            foreach (DataRow itemNhanVien in dtNhanVien.Rows)
            {
                DataRow row = dt.NewRow();

                #region Ty Trong Cong Viec

                double totalCVTX = 0;
                double totalCVKTX = 0;
                double totalCVPS = 0;
                double total = 0;

                double totalCVTX_Gio = 0;
                double totalCVKTX_Gio = 0;
                double totalCVPS_Gio = 0;
                double total_Gio = 0;

                idNhanVien = ConvertUtility.ToInt32(itemNhanVien["UserID"]);

                string HoTen = "";
                string ChucVu = "";

                DataTable dtUserInfo = DotDanhGiaController.GetUserInfo(idNhanVien);

                if (dtUserInfo != null && dtUserInfo.Rows.Count > 0)
                {
                    HoTen = dtUserInfo.Rows[0]["HoTen"].ToString();
                    ChucVu = dtUserInfo.Rows[0]["ChucVu"].ToString();
                }

                DataTable dtCongViecThuongXuyen = DanhGiaThang_DGCBCNVDanhGiaTTCVController.GetAll(1, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), idNhanVien);

                foreach (DataRow item in dtCongViecThuongXuyen.Rows)
                {
                    totalCVTX += ConvertUtility.ToDouble(item["TyTrongCV"]);
                    totalCVTX_Gio += ConvertUtility.ToDouble(item["SoGio"]);
                }

                DataTable dtCongViecKhongThuonguyen = DanhGiaThang_DGCBCNVDanhGiaTTCVController.GetAll(2, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), idNhanVien);
                foreach (DataRow item in dtCongViecKhongThuonguyen.Rows)
                {
                    totalCVKTX += ConvertUtility.ToDouble(item["TyTrongCV"]);
                    totalCVKTX_Gio += ConvertUtility.ToDouble(item["SoGio"]);
                }

                DataTable dtCongViecPhatSinh = DanhGiaThang_DGCBCNVDanhGiaTTCVController.GetAll(3, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), idNhanVien);
                foreach (DataRow item in dtCongViecPhatSinh.Rows)
                {
                    totalCVPS += ConvertUtility.ToDouble(item["TyTrongCV"]);
                    totalCVPS_Gio += ConvertUtility.ToDouble(item["SoGio"]);
                }
                row["HoTen"] = HoTen;
                row["ChucVu"] = ChucVu;
                row["TTCVThuongXuyen"] = Math.Round(totalCVTX,2) + "% (" + totalCVTX_Gio + "h)";
                row["TTCVKeHoachThang"] = Math.Round(totalCVKTX,2) + "% (" + totalCVKTX_Gio + "h)";
                row["TTCVPhatSinh"] = Math.Round(totalCVPS, 2) + "% (" + totalCVPS_Gio + "h)";
                
                total = totalCVTX + totalCVKTX + totalCVPS;
                total_Gio = totalCVTX_Gio + totalCVKTX_Gio + totalCVPS_Gio;

                double totalCVPhatSinh = Math.Round((100 - total), 2);
                double totalCVPhatSinh_Gio = Math.Round((176 - total_Gio), 2);

                if (totalCVPhatSinh > 0)
                {
                    row["TTConLai"] = totalCVPhatSinh + "% (" + totalCVPhatSinh_Gio + "h)";              
                }
                else
                {
                    row["TTConLai"] = "0%";
                }

                dt.Rows.Add(row);

                #endregion
            }

            dgrBaoCao.DataSource = dt;
            dgrBaoCao.DataBind();

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

    }
}