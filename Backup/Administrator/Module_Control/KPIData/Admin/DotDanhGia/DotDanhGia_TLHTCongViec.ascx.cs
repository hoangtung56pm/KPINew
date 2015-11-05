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
    public partial class DotDanhGia_TLHTCongViec : AuthenticatedControl
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

            DotDanhGiaTLHTCVInfo info = DotDanhGiaController.GetInfoTLHTCongViec(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 1);

            try
            {
                txtTLHTCongViecIT.Text = info.TLHTCongViec.ToString().Replace(".",",");
            }
            catch
            {
                txtTLHTCongViecIT.Text = "0";
            }

            info = DotDanhGiaController.GetInfoTLHTCongViec(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 2);

            try
            {
                txtTLHTCongViecNSHC.Text = info.TLHTCongViec.ToString();
            }
            catch
            {
                txtTLHTCongViecNSHC.Text = "0";
            }

            info = DotDanhGiaController.GetInfoTLHTCongViec(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 3);

            try
            {
                txtTLHTCongViecTCKT.Text = info.TLHTCongViec.ToString();
            }
            catch
            {
                txtTLHTCongViecTCKT.Text = "0";
            }

            info = DotDanhGiaController.GetInfoTLHTCongViec(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 4);

            try
            {
                txtTLHTCongViecPTKD.Text = info.TLHTCongViec.ToString();
            }
            catch
            {
                txtTLHTCongViecPTKD.Text = "0";
            }

            info = DotDanhGiaController.GetInfoTLHTCongViec(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 5);

            try
            {
                txtTLHTCongViecPTND.Text = info.TLHTCongViec.ToString();
            }
            catch
            {
                txtTLHTCongViecPTND.Text = "0";
            }

            info = DotDanhGiaController.GetInfoTLHTCongViec(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 6);

            try
            {
                txtTLHTCongViecLUCKYFONE.Text = info.TLHTCongViec.ToString();
            }
            catch
            {
                txtTLHTCongViecLUCKYFONE.Text = "0";
            }

            info = DotDanhGiaController.GetInfoTLHTCongViec(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 7);

            try
            {
                txtTLHTCongViecBANQUYEN.Text = info.TLHTCongViec.ToString();
            }
            catch
            {
                txtTLHTCongViecBANQUYEN.Text = "0";
            }

            info = DotDanhGiaController.GetInfoTLHTCongViec(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 8);

            try
            {
                txtTLHTCongViecDVKH.Text = info.TLHTCongViec.ToString();
            }
            catch
            {
                txtTLHTCongViecDVKH.Text = "0";
            }
            
            info = DotDanhGiaController.GetInfoTLHTCongViec(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 14);

            try
            {
                txtTLHTCongViecDSTC.Text = info.TLHTCongViec.ToString();
            }
            catch
            {
                txtTLHTCongViecDSTC.Text = "0";
            }

            info = DotDanhGiaController.GetInfoTLHTCongViec(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 15);

            try
            {
                txtTLHTCongViecVPHCM.Text = info.TLHTCongViec.ToString();
            }
            catch
            {
                txtTLHTCongViecVPHCM.Text = "0";
            }

            info = DotDanhGiaController.GetInfoTLHTCongViec(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 16);

            try
            {
                txtTLHTCongViecPTDV.Text = info.TLHTCongViec.ToString();
            }
            catch
            {
                txtTLHTCongViecPTDV.Text = "0";
            }

            info = DotDanhGiaController.GetInfoTLHTCongViec(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 17);

            try
            {
                txtTLHTCongViecMAR.Text = info.TLHTCongViec.ToString();
            }
            catch
            {
                txtTLHTCongViecMAR.Text = "0";
            }

            info = DotDanhGiaController.GetInfoTLHTCongViec(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 18);

            try
            {
                txtTLHTCongViecQCS.Text = info.TLHTCongViec.ToString();
            }
            catch
            {
                txtTLHTCongViecQCS.Text = "0";
            }
        }
        protected void btnUpdate1_Click(object sender, EventArgs e)
        {
            DotDanhGiaTLHTCVInfo info = new DotDanhGiaTLHTCVInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TLHTCongViec = ConvertUtility.ToDouble(txtTLHTCongViecIT.Text);
            info.IDTrungTam = 1;

            DotDanhGiaController.UpdateTLHTCongViec(info);
        }

        protected void btnUpdate2_Click(object sender, EventArgs e)
        {
            DotDanhGiaTLHTCVInfo info = new DotDanhGiaTLHTCVInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TLHTCongViec = ConvertUtility.ToDouble(txtTLHTCongViecNSHC.Text);
            info.IDTrungTam = 2;

            DotDanhGiaController.UpdateTLHTCongViec(info);
        }

        protected void btnUpdate3_Click(object sender, EventArgs e)
        {
            DotDanhGiaTLHTCVInfo info = new DotDanhGiaTLHTCVInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TLHTCongViec = ConvertUtility.ToDouble(txtTLHTCongViecTCKT.Text);
            info.IDTrungTam = 3;

            DotDanhGiaController.UpdateTLHTCongViec(info);
        }

        protected void btnUpdate4_Click(object sender, EventArgs e)
        {
            DotDanhGiaTLHTCVInfo info = new DotDanhGiaTLHTCVInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TLHTCongViec = ConvertUtility.ToDouble(txtTLHTCongViecPTKD.Text);
            info.IDTrungTam = 4;

            DotDanhGiaController.UpdateTLHTCongViec(info);
        }

        protected void btnUpdate5_Click(object sender, EventArgs e)
        {
            DotDanhGiaTLHTCVInfo info = new DotDanhGiaTLHTCVInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TLHTCongViec = ConvertUtility.ToDouble(txtTLHTCongViecPTND.Text);
            info.IDTrungTam = 5;

            DotDanhGiaController.UpdateTLHTCongViec(info);
        }

        protected void btnUpdate6_Click(object sender, EventArgs e)
        {
            DotDanhGiaTLHTCVInfo info = new DotDanhGiaTLHTCVInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TLHTCongViec = ConvertUtility.ToDouble(txtTLHTCongViecLUCKYFONE.Text);
            info.IDTrungTam = 6;

            DotDanhGiaController.UpdateTLHTCongViec(info);
        }

        protected void btnUpdate7_Click(object sender, EventArgs e)
        {
            DotDanhGiaTLHTCVInfo info = new DotDanhGiaTLHTCVInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TLHTCongViec = ConvertUtility.ToDouble(txtTLHTCongViecBANQUYEN.Text);
            info.IDTrungTam = 7;

            DotDanhGiaController.UpdateTLHTCongViec(info);
        }

        protected void btnUpdate8_Click(object sender, EventArgs e)
        {
            DotDanhGiaTLHTCVInfo info = new DotDanhGiaTLHTCVInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TLHTCongViec = ConvertUtility.ToDouble(txtTLHTCongViecDVKH.Text);
            info.IDTrungTam = 8;

            DotDanhGiaController.UpdateTLHTCongViec(info);
        }


        protected void btnUpdate14_Click(object sender, EventArgs e)
        {
            DotDanhGiaTLHTCVInfo info = new DotDanhGiaTLHTCVInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TLHTCongViec = ConvertUtility.ToDouble(txtTLHTCongViecDSTC.Text);
            info.IDTrungTam = 14;

            DotDanhGiaController.UpdateTLHTCongViec(info);
        }

        protected void btnUpdate15_Click(object sender, EventArgs e)
        {
            DotDanhGiaTLHTCVInfo info = new DotDanhGiaTLHTCVInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TLHTCongViec = ConvertUtility.ToDouble(txtTLHTCongViecVPHCM.Text);
            info.IDTrungTam = 15;

            DotDanhGiaController.UpdateTLHTCongViec(info);
        }

        protected void btnUpdate16_Click(object sender, EventArgs e)
        {
            DotDanhGiaTLHTCVInfo info = new DotDanhGiaTLHTCVInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TLHTCongViec = ConvertUtility.ToDouble(txtTLHTCongViecPTDV.Text);
            info.IDTrungTam = 16;

            DotDanhGiaController.UpdateTLHTCongViec(info);
        }

        protected void btnUpdate17_Click(object sender, EventArgs e)
        {
            DotDanhGiaTLHTCVInfo info = new DotDanhGiaTLHTCVInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TLHTCongViec = ConvertUtility.ToDouble(txtTLHTCongViecMAR.Text);
            info.IDTrungTam = 17;

            DotDanhGiaController.UpdateTLHTCongViec(info);
        }

        protected void btnUpdate18_Click(object sender, EventArgs e)
        {
            DotDanhGiaTLHTCVInfo info = new DotDanhGiaTLHTCVInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.TLHTCongViec = ConvertUtility.ToDouble(txtTLHTCongViecQCS.Text);
            info.IDTrungTam = 18;

            DotDanhGiaController.UpdateTLHTCongViec(info);
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
            btnUpdate18_Click(null,null);

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