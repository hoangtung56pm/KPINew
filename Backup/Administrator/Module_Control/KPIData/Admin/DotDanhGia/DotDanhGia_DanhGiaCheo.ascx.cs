using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library.Utilities;
using VmgPortal.Library;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;
using VmgPortal.Library.Components.Security;
using System.Data;
using VmgPortal.Modules.KPIData.Library.DanhGia;
using VmgPortal.Modules.KPIData.Library.DanhGiaBoPhan;
using VmgPortal.Modules.KPIData.Library.BoPhan;

namespace VmgPortal.Modules.KPIData.Admin.DotDanhGia
{
    public partial class DotDanhGia_DanhGiaCheo : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
                dropDotDanhGia.DataBind();
                int idDotDanhActive = ConvertUtility.ToInt32(DotDanhGiaController.GetDaultDotDanhGia().Rows[0]["ID"]);
                dropDotDanhGia.SelectedValue = idDotDanhActive.ToString();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            DotDanhGiaDanhGiaCheoInfo info = DotDanhGiaController.GetInfoDanhGiaCheo(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 1);

            try
            {
                txtTLHTCongViecIT.Text = info.TyTrongDanhGia.ToString().Replace(".", ",");
                lblDiemCuoiIT.Text = info.DiemDanhGia.ToString().Replace(".", ",");
            }
            catch
            {
                txtTLHTCongViecIT.Text = "0";
            }

            info = DotDanhGiaController.GetInfoDanhGiaCheo(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 2);

            try
            {
                txtTLHTCongViecNSHC.Text = info.TyTrongDanhGia.ToString().Replace(".", ",");
                lblDiemCuoiNSHC.Text = info.DiemDanhGia.ToString().Replace(".", ",");
            }
            catch
            {
                txtTLHTCongViecNSHC.Text = "0";
            }

            info = DotDanhGiaController.GetInfoDanhGiaCheo(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 3);

            try
            {
                txtTLHTCongViecTCKT.Text = info.TyTrongDanhGia.ToString().Replace(".", ",");
                lblDiemCuoiTCKT.Text = info.DiemDanhGia.ToString().Replace(".", ",");
            }
            catch
            {
                txtTLHTCongViecTCKT.Text = "0";
            }

            info = DotDanhGiaController.GetInfoDanhGiaCheo(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 4);

            try
            {
                txtTLHTCongViecPTKD.Text = info.TyTrongDanhGia.ToString().Replace(".", ",");
                lblDiemCuoiPTKD.Text = info.DiemDanhGia.ToString().Replace(".", ",");
            }
            catch
            {
                txtTLHTCongViecPTKD.Text = "0";
            }

            info = DotDanhGiaController.GetInfoDanhGiaCheo(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 5);

            try
            {
                txtTLHTCongViecPTND.Text = info.TyTrongDanhGia.ToString().Replace(".", ",");
                lblDiemCuoiPTND.Text = info.DiemDanhGia.ToString().Replace(".", ",");
            }
            catch
            {
                txtTLHTCongViecPTND.Text = "0";
            }

            info = DotDanhGiaController.GetInfoDanhGiaCheo(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 6);

            try
            {
                txtTLHTCongViecLUCKYFONE.Text = info.TyTrongDanhGia.ToString().Replace(".", ",");
                lblDiemCuoiLUCKYFONE.Text = info.DiemDanhGia.ToString().Replace(".", ",");
            }
            catch
            {
                txtTLHTCongViecLUCKYFONE.Text = "0";
            }

            info = DotDanhGiaController.GetInfoDanhGiaCheo(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 7);

            try
            {
                txtTLHTCongViecBANQUYEN.Text = info.TyTrongDanhGia.ToString().Replace(".", ",");
                lblDiemCuoiBANQUYEN.Text = info.DiemDanhGia.ToString().Replace(".", ",");
            }
            catch
            {
                txtTLHTCongViecBANQUYEN.Text = "0";
            }

            info = DotDanhGiaController.GetInfoDanhGiaCheo(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 8);

            try
            {
                txtTLHTCongViecDVKH.Text = info.TyTrongDanhGia.ToString().Replace(".", ",");
                lblDiemCuoiDVKH.Text = info.DiemDanhGia.ToString().Replace(".", ",");
            }
            catch
            {
                txtTLHTCongViecDVKH.Text = "0";
            }

            info = DotDanhGiaController.GetInfoDanhGiaCheo(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 14);

            try
            {
                txtTLHTCongViecDSTC.Text = info.TyTrongDanhGia.ToString().Replace(".", ",");
                lblDiemCuoiDSTC.Text = info.DiemDanhGia.ToString().Replace(".", ",");
            }
            catch
            {
                txtTLHTCongViecDSTC.Text = "0";
            }

            info = DotDanhGiaController.GetInfoDanhGiaCheo(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 15);

            try
            {
                txtTLHTCongViecVPHCM.Text = info.TyTrongDanhGia.ToString().Replace(".", ",");
                lblDiemCuoiVPHCM.Text = info.DiemDanhGia.ToString().Replace(".", ",");
            }
            catch
            {
                txtTLHTCongViecVPHCM.Text = "0";
            }

            info = DotDanhGiaController.GetInfoDanhGiaCheo(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 16);

            try
            {
                txtTLHTCongViecPTDV.Text = info.TyTrongDanhGia.ToString().Replace(".", ",");
                lblDiemCuoiPTDV.Text = info.DiemDanhGia.ToString().Replace(".", ",");
            }
            catch
            {
                txtTLHTCongViecPTDV.Text = "0";
            }

            info = DotDanhGiaController.GetInfoDanhGiaCheo(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 17);

            try
            {
                txtTLHTCongViecMarketing.Text = info.TyTrongDanhGia.ToString().Replace(".", ",");
                lblDiemCuoiMarketing.Text = info.DiemDanhGia.ToString().Replace(".", ",");
            }
            catch
            {
                txtTLHTCongViecMarketing.Text = "0";
            }

            info = DotDanhGiaController.GetInfoDanhGiaCheo(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 18);

            try
            {
                txtTLHTCongViecQCS.Text = info.TyTrongDanhGia.ToString().Replace(".", ",");
                lblDiemCuoiQCS.Text = info.DiemDanhGia.ToString().Replace(".", ",");
            }
            catch
            {
                txtTLHTCongViecQCS.Text = "0";
            }
        }

        protected void btnUpdate1_Click(object sender, EventArgs e)
        {
            DotDanhGiaDanhGiaCheoInfo info = new DotDanhGiaDanhGiaCheoInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TyTrongDanhGia = ConvertUtility.ToDouble(txtTLHTCongViecIT.Text);
            info.DiemDanhGia = info.TyTrongDanhGia * 10/ 100;
            info.IDTrungTam = 1;

            DotDanhGiaController.UpdateDanhGiaCheo(info);
        }

        protected void btnUpdate2_Click(object sender, EventArgs e)
        {
            DotDanhGiaDanhGiaCheoInfo info = new DotDanhGiaDanhGiaCheoInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TyTrongDanhGia = ConvertUtility.ToDouble(txtTLHTCongViecNSHC.Text);
            info.DiemDanhGia = info.TyTrongDanhGia * 10 / 100;
            info.IDTrungTam = 2;

            DotDanhGiaController.UpdateDanhGiaCheo(info);
        }

        protected void btnUpdate3_Click(object sender, EventArgs e)
        {
            DotDanhGiaDanhGiaCheoInfo info = new DotDanhGiaDanhGiaCheoInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TyTrongDanhGia = ConvertUtility.ToDouble(txtTLHTCongViecTCKT.Text);
            info.DiemDanhGia = info.TyTrongDanhGia * 10 / 100;
            info.IDTrungTam = 3;

            DotDanhGiaController.UpdateDanhGiaCheo(info);
        }

        protected void btnUpdate4_Click(object sender, EventArgs e)
        {
            DotDanhGiaDanhGiaCheoInfo info = new DotDanhGiaDanhGiaCheoInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TyTrongDanhGia = ConvertUtility.ToDouble(txtTLHTCongViecPTKD.Text);
            info.DiemDanhGia = info.TyTrongDanhGia * 5 / 100;
            info.IDTrungTam = 4;

            DotDanhGiaController.UpdateDanhGiaCheo(info);
        }

        protected void btnUpdate5_Click(object sender, EventArgs e)
        {
            DotDanhGiaDanhGiaCheoInfo info = new DotDanhGiaDanhGiaCheoInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TyTrongDanhGia = ConvertUtility.ToDouble(txtTLHTCongViecPTND.Text);
            info.DiemDanhGia = info.TyTrongDanhGia * 5 / 100;
            info.IDTrungTam = 5;

            DotDanhGiaController.UpdateDanhGiaCheo(info);
        }

        protected void btnUpdate6_Click(object sender, EventArgs e)
        {
            DotDanhGiaDanhGiaCheoInfo info = new DotDanhGiaDanhGiaCheoInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TyTrongDanhGia = ConvertUtility.ToDouble(txtTLHTCongViecLUCKYFONE.Text);
            info.DiemDanhGia = info.TyTrongDanhGia * 5 / 100;
            info.IDTrungTam = 6;

            DotDanhGiaController.UpdateDanhGiaCheo(info);
        }

        protected void btnUpdate7_Click(object sender, EventArgs e)
        {
            DotDanhGiaDanhGiaCheoInfo info = new DotDanhGiaDanhGiaCheoInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TyTrongDanhGia = ConvertUtility.ToDouble(txtTLHTCongViecBANQUYEN.Text);
            info.DiemDanhGia = info.TyTrongDanhGia * 5 / 100;
            info.IDTrungTam = 7;

            DotDanhGiaController.UpdateDanhGiaCheo(info);
        }

        protected void btnUpdate8_Click(object sender, EventArgs e)
        {
            DotDanhGiaDanhGiaCheoInfo info = new DotDanhGiaDanhGiaCheoInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TyTrongDanhGia = ConvertUtility.ToDouble(txtTLHTCongViecDVKH.Text);
            info.DiemDanhGia = info.TyTrongDanhGia * 10 / 100;
            info.IDTrungTam = 8;

            DotDanhGiaController.UpdateDanhGiaCheo(info);
        }


        protected void btnUpdate14_Click(object sender, EventArgs e)
        {
            DotDanhGiaDanhGiaCheoInfo info = new DotDanhGiaDanhGiaCheoInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TyTrongDanhGia = ConvertUtility.ToDouble(txtTLHTCongViecDSTC.Text);
            info.DiemDanhGia = info.TyTrongDanhGia * 10 / 100;
            info.IDTrungTam = 14;

            DotDanhGiaController.UpdateDanhGiaCheo(info);
        }

        protected void btnUpdate15_Click(object sender, EventArgs e)
        {
            DotDanhGiaDanhGiaCheoInfo info = new DotDanhGiaDanhGiaCheoInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TyTrongDanhGia = ConvertUtility.ToDouble(txtTLHTCongViecVPHCM.Text);
            info.DiemDanhGia = info.TyTrongDanhGia * 10 / 100;
            info.IDTrungTam = 15;

            DotDanhGiaController.UpdateDanhGiaCheo(info);
        }

        protected void btnUpdate16_Click(object sender, EventArgs e)
        {
            DotDanhGiaDanhGiaCheoInfo info = new DotDanhGiaDanhGiaCheoInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TyTrongDanhGia = ConvertUtility.ToDouble(txtTLHTCongViecPTDV.Text);
            info.DiemDanhGia = info.TyTrongDanhGia * 10 / 100;
            info.IDTrungTam = 16;

            DotDanhGiaController.UpdateDanhGiaCheo(info);
        }

        protected void btnUpdate17_Click(object sender, EventArgs e)
        {
            DotDanhGiaDanhGiaCheoInfo info = new DotDanhGiaDanhGiaCheoInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TyTrongDanhGia = ConvertUtility.ToDouble(txtTLHTCongViecMarketing.Text);
            info.DiemDanhGia = info.TyTrongDanhGia * 10 / 100;
            info.IDTrungTam = 17;

            DotDanhGiaController.UpdateDanhGiaCheo(info);
        }

        protected void btnUpdate18_Click(object sender, EventArgs e)
        {
            DotDanhGiaDanhGiaCheoInfo info = new DotDanhGiaDanhGiaCheoInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TyTrongDanhGia = ConvertUtility.ToDouble(txtTLHTCongViecQCS.Text);
            info.DiemDanhGia = info.TyTrongDanhGia * 10 / 100;
            info.IDTrungTam = 18;

            DotDanhGiaController.UpdateDanhGiaCheo(info);
        }

        protected void dropDotDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate1_Click(null, null);
            btnUpdate2_Click(null, null);
            btnUpdate3_Click(null, null);
            btnUpdate4_Click(null, null);
            btnUpdate5_Click(null, null);
            btnUpdate6_Click(null, null);
            btnUpdate7_Click(null, null);
            btnUpdate8_Click(null, null);
            btnUpdate14_Click(null, null);
            btnUpdate15_Click(null, null);
            btnUpdate16_Click(null, null);
            btnUpdate17_Click(null, null);
            btnUpdate18_Click(null, null);

            DataTable dtNhanVien = DotDanhGiaController.GetAllNhanVien(0, 0, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

            if (dtNhanVien != null && dtNhanVien.Rows.Count > 0)
            {
                foreach (DataRow item in dtNhanVien.Rows)
                {
                    DotDanhGiaController.DanhGiaThang_DGCBCNVDanhGia_TongDiemCongThucMoi(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(item["IDNhanVien"]));
                }
            }
        }
    }
}