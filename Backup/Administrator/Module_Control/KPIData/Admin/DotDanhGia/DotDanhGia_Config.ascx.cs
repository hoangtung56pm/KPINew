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
    public partial class DotDanhGia_Config : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
                dropDotDanhGia.DataBind();

                //DataTable dt = DotDanhGiaController.GetAllMucDoanhThuLoiNhuan();
                //dropDoanhThuIT.DataSource = dropLoiNhuanIT.DataSource = dt;
                //dropDoanhThuIT.DataBind();
                //dropLoiNhuanIT.DataBind();

                //dropDoanhThuNSHC.DataSource = dropLoiNhuanNSHC.DataSource = dt;
                //dropDoanhThuNSHC.DataBind();
                //dropLoiNhuanNSHC.DataBind();

                //dropDoanhThuTCKT.DataSource = dropLoiNhuanTCKT.DataSource = dt;
                //dropDoanhThuTCKT.DataBind();
                //dropLoiNhuanTCKT.DataBind();

                //dropDoanhThuPTKD.DataSource = dropLoiNhuanPTKD.DataSource = dt;
                //dropDoanhThuPTKD.DataBind();
                //dropLoiNhuanPTKD.DataBind();

                //dropDoanhThuPTND.DataSource = dropLoiNhuanPTND.DataSource = dt;
                //dropDoanhThuPTND.DataBind();
                //dropLoiNhuanPTND.DataBind();

                //dropDoanhThuLUCKYFONE.DataSource = dropLoiNhuanLUCKYFONE.DataSource = dt;
                //dropDoanhThuLUCKYFONE.DataBind();
                //dropLoiNhuanLUCKYFONE.DataBind();

                //dropDoanhThuBANQUYEN.DataSource = dropLoiNhuanBANQUYEN.DataSource = dt;
                //dropDoanhThuBANQUYEN.DataBind();
                //dropLoiNhuanBANQUYEN.DataBind();

                //dropDoanhThuDVKH.DataSource = dropLoiNhuanDVKH.DataSource = dt;
                //dropDoanhThuDVKH.DataBind();
                //dropLoiNhuanDVKH.DataBind();

                //dropDoanhThuLINGO.DataSource = dropLoiNhuanLINGO.DataSource = dt;
                //dropDoanhThuLINGO.DataBind();
                //dropLoiNhuanLINGO.DataBind();

                //dropDoanhThuPTDV.DataSource = dropLoiNhuanPTDV.DataSource = dt;
                //dropDoanhThuPTDV.DataBind();
                //dropLoiNhuanPTDV.DataBind();

                //dropDoanhThuTIEPTHISO.DataSource = dropLoiNhuanTIEPTHISO.DataSource = dt;
                //dropDoanhThuTIEPTHISO.DataBind();
                //dropLoiNhuanTIEPTHISO.DataBind();

                //dropDoanhThuDSTC.DataSource = dropLoiNhuanDSTC.DataSource = dt;
                //dropDoanhThuDSTC.DataBind();
                //dropLoiNhuanDSTC.DataBind();

            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            DotDanhGiaConfigInfo info = DotDanhGiaController.GetInfoDotDanhGiaConfig(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 1);

            try
            {
                //dropDoanhThuIT.SelectedValue = info.IDDiemDoanhThu.ToString();
                //dropLoiNhuanIT.SelectedValue = info.IDDiemLoiNhuan.ToString();

                txtDoanhThuIT.Text = info.IDDiemDoanhThu.ToString().Replace(".", ",");
                txtLoiNhuanIT.Text = info.IDDiemLoiNhuan.ToString().Replace(".", ",");

                double diemDoanhThuHT = info.IDDiemDoanhThu * 12 / 100;
                double diemLoiNhuanHT = info.IDDiemLoiNhuan * 18 / 100;

                if (diemDoanhThuHT > 12) diemDoanhThuHT = 12;
                if (diemLoiNhuanHT > 18) diemLoiNhuanHT = 18;

                lblDiemDT.Text = diemDoanhThuHT.ToString().Replace(".", ",");
                lblDiemLN.Text = diemLoiNhuanHT.ToString().Replace(".", ",");
                lblTongHT.Text = (diemDoanhThuHT + diemLoiNhuanHT).ToString().Replace(".", ",");
            }
            catch
            {
                //dropDoanhThuIT.SelectedIndex = 0;
                //dropLoiNhuanIT.SelectedIndex = 0;
            }


            //info = DotDanhGiaController.GetInfoDotDanhGiaConfig(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 2);

            //try
            //{
            //    dropDoanhThuNSHC.SelectedValue = info.IDDiemDoanhThu.ToString();
            //    dropLoiNhuanNSHC.SelectedValue = info.IDDiemLoiNhuan.ToString();
            //}
            //catch
            //{
            //    dropDoanhThuNSHC.SelectedIndex = 0;
            //    dropLoiNhuanNSHC.SelectedIndex = 0;
            //}

            //info = DotDanhGiaController.GetInfoDotDanhGiaConfig(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 3);

            //try
            //{
            //    dropDoanhThuTCKT.SelectedValue = info.IDDiemDoanhThu.ToString();
            //    dropLoiNhuanTCKT.SelectedValue = info.IDDiemLoiNhuan.ToString();
            //}
            //catch
            //{
            //    dropDoanhThuTCKT.SelectedIndex = 0;
            //    dropLoiNhuanTCKT.SelectedIndex = 0;
            //}

            info = DotDanhGiaController.GetInfoDotDanhGiaConfig(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 4);

            try
            {
                //dropDoanhThuPTKD.SelectedValue = info.IDDiemDoanhThu.ToString();
                //dropLoiNhuanPTKD.SelectedValue = info.IDDiemLoiNhuan.ToString();

                txtDoanhThuPTKD.Text = info.IDDiemDoanhThu.ToString().Replace(".", ",");
                txtLoiNhuanPTKD.Text = info.IDDiemLoiNhuan.ToString().Replace(".", ",");

                //int diemDoanhThuHT = GetDiemDTKinhDoanh((int)info.IDDiemDoanhThu);
                //int diemLoiNhuanHT = GetDiemLNKinhDoanh((int)info.IDDiemLoiNhuan);

                double diemDoanhThuHT = info.IDDiemDoanhThu * 24 / 100;
                double diemLoiNhuanHT = info.IDDiemLoiNhuan * 36 / 100;

                if (diemDoanhThuHT > 24) diemDoanhThuHT = 24;
                if (diemLoiNhuanHT > 36) diemLoiNhuanHT = 36;

                lblDiemDT_PTKD.Text = diemDoanhThuHT.ToString("#.##");
                lblDiemLN_PTKD.Text = diemLoiNhuanHT.ToString("#.##");
                lblTongDiem_PTKD.Text = (diemDoanhThuHT + diemLoiNhuanHT).ToString("#.##");
            }
            catch
            {
                //dropDoanhThuPTKD.SelectedIndex = 0;
                //dropLoiNhuanPTKD.SelectedIndex = 0;

                txtDoanhThuPTKD.Text = "";
                txtLoiNhuanPTKD.Text = "";
            }

            info = DotDanhGiaController.GetInfoDotDanhGiaConfig(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 5);

            try
            {
                //dropDoanhThuPTND.SelectedValue = info.IDDiemDoanhThu.ToString();
                //dropLoiNhuanPTND.SelectedValue = info.IDDiemLoiNhuan.ToString();

                txtDoanhThuPTND.Text = info.IDDiemDoanhThu.ToString().Replace(".", ",");
                txtLoiNhuanPTND.Text = info.IDDiemLoiNhuan.ToString().Replace(".", ",");

                //int diemDoanhThuHT = GetDiemDTKinhDoanh((int)info.IDDiemDoanhThu);
                //int diemLoiNhuanHT = GetDiemLNKinhDoanh((int)info.IDDiemLoiNhuan);

                double diemDoanhThuHT = info.IDDiemDoanhThu * 24 / 100;
                double diemLoiNhuanHT = info.IDDiemLoiNhuan * 36 / 100;

                if (diemDoanhThuHT > 24) diemDoanhThuHT = 24;
                if (diemLoiNhuanHT > 36) diemLoiNhuanHT = 36;

                lblDiemDT_PTND.Text = diemDoanhThuHT.ToString("#.##");
                lblDiemLN_PTND.Text = diemLoiNhuanHT.ToString("#.##");
                lblTongDiem_PTND.Text = (diemDoanhThuHT + diemLoiNhuanHT).ToString("#.##");
            }
            catch
            {
                //dropDoanhThuPTND.SelectedIndex = 0;
                //dropLoiNhuanPTND.SelectedIndex = 0;

                txtDoanhThuPTND.Text = "";
                txtLoiNhuanPTND.Text = "";
            }

            info = DotDanhGiaController.GetInfoDotDanhGiaConfig(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 6);

            try
            {
                //dropDoanhThuLUCKYFONE.SelectedValue = info.IDDiemDoanhThu.ToString();
                //dropLoiNhuanLUCKYFONE.SelectedValue = info.IDDiemLoiNhuan.ToString();

                txtDoanhThuLuckyFone.Text = info.IDDiemDoanhThu.ToString().Replace(".", ",");
                txtLoiNhuanLuckyFone.Text = info.IDDiemLoiNhuan.ToString().Replace(".", ",");
                
                //int diemDoanhThuHT = GetDiemDTKinhDoanh((int)info.IDDiemDoanhThu);
                //int diemLoiNhuanHT = GetDiemLNKinhDoanh((int)info.IDDiemLoiNhuan);

                double diemDoanhThuHT = info.IDDiemDoanhThu * 24 / 100;
                double diemLoiNhuanHT = info.IDDiemLoiNhuan * 36 / 100;

                if (diemDoanhThuHT > 24) diemDoanhThuHT = 24;
                if (diemLoiNhuanHT > 36) diemLoiNhuanHT = 36;

                lblDiemDT_LUCK.Text = diemDoanhThuHT.ToString();
                lblDiemLN_LUCK.Text = diemLoiNhuanHT.ToString();
                lblTongDiem_LUCK.Text = (diemDoanhThuHT + diemLoiNhuanHT).ToString("#.##");
            }
            catch
            {
                //dropDoanhThuLUCKYFONE.SelectedIndex = 0;
                //dropLoiNhuanLUCKYFONE.SelectedIndex = 0;
                txtDoanhThuLuckyFone.Text = "";
                txtLoiNhuanLuckyFone.Text = "";
            }

            info = DotDanhGiaController.GetInfoDotDanhGiaConfig(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 7);

            try
            {
                //dropDoanhThuBANQUYEN.SelectedValue = info.IDDiemDoanhThu.ToString();
                //dropLoiNhuanBANQUYEN.SelectedValue = info.IDDiemLoiNhuan.ToString();

                txtDoanhThuBanQuyen.Text = info.IDDiemDoanhThu.ToString().Replace(".", ",");
                txtLoiNhuanBanQuyen.Text = info.IDDiemLoiNhuan.ToString().Replace(".", ",");

                //int diemDoanhThuHT = GetDiemDTKinhDoanh((int)info.IDDiemDoanhThu);
                //int diemLoiNhuanHT = GetDiemLNKinhDoanh((int)info.IDDiemLoiNhuan);

                double diemDoanhThuHT = info.IDDiemDoanhThu * 24 / 100;
                double diemLoiNhuanHT = info.IDDiemLoiNhuan * 36 / 100;

                if (diemDoanhThuHT > 24) diemDoanhThuHT = 24;
                if (diemLoiNhuanHT > 36) diemLoiNhuanHT = 36;

                lblDiemDT_BQ.Text = diemDoanhThuHT.ToString();
                lblDiemLN_BQ.Text = diemLoiNhuanHT.ToString();
                lblTongDiem_BQ.Text = (diemDoanhThuHT + diemLoiNhuanHT).ToString("#.##");
            }
            catch
            {
                //dropDoanhThuBANQUYEN.SelectedIndex = 0;
                //dropLoiNhuanBANQUYEN.SelectedIndex = 0;

                txtDoanhThuBanQuyen.Text = "";
                txtLoiNhuanBanQuyen.Text = "";
            }

            //info = DotDanhGiaController.GetInfoDotDanhGiaConfig(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 8);

            //try
            //{
            //    dropDoanhThuDVKH.SelectedValue = info.IDDiemDoanhThu.ToString();
            //    dropLoiNhuanDVKH.SelectedValue = info.IDDiemLoiNhuan.ToString();
            //}
            //catch
            //{
            //    dropDoanhThuDVKH.SelectedIndex = 0;
            //    dropLoiNhuanDVKH.SelectedIndex = 0;
            //}

            //info = DotDanhGiaController.GetInfoDotDanhGiaConfig(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 9);

            //try
            //{
            //    dropDoanhThuLINGO.SelectedValue = info.IDDiemDoanhThu.ToString();
            //    dropLoiNhuanLINGO.SelectedValue = info.IDDiemLoiNhuan.ToString();

            //    txtDiemUuDiem.Text = info.IDDiem1.ToString();
            //    txtPhatHanhThe.Text = info.IDDiem2.ToString();
            //    txtPos.Text = info.IDDiem3.ToString();
            //}
            //catch
            //{
            //    dropDoanhThuLINGO.SelectedIndex = 0;
            //    dropLoiNhuanLINGO.SelectedIndex = 0;
            //    txtDiemUuDiem.Text = "";
            //    txtPhatHanhThe.Text = "";
            //    txtPos.Text = "";
            //}

            //info = DotDanhGiaController.GetInfoDotDanhGiaConfig(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 10);

            //try
            //{
            //    dropDoanhThuPTDV.Text = info.IDDiemDoanhThu.ToString();
            //    dropLoiNhuanPTDV.Text = info.IDDiemLoiNhuan.ToString();
            //}
            //catch
            //{
            //    dropDoanhThuPTDV.SelectedIndex = 0;
            //    dropLoiNhuanPTDV.SelectedIndex = 0;
            //}

            //info = DotDanhGiaController.GetInfoDotDanhGiaConfig(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 11);

            //try
            //{
            //    dropDoanhThuTIEPTHISO.SelectedValue = info.IDDiemDoanhThu.ToString();
            //    dropLoiNhuanTIEPTHISO.Text = info.IDDiemLoiNhuan.ToString();
            //}
            //catch
            //{
            //    dropDoanhThuTIEPTHISO.SelectedIndex = 0;
            //    dropLoiNhuanTIEPTHISO.SelectedIndex = 0;
            //}

            //info = DotDanhGiaController.GetInfoDotDanhGiaConfig(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 14);

            //try
            //{
            //    dropDoanhThuDSTC.SelectedValue = info.IDDiemDoanhThu.ToString();
            //    dropLoiNhuanDSTC.Text = info.IDDiemLoiNhuan.ToString();
            //}
            //catch
            //{
            //    dropLoiNhuanDSTC.SelectedIndex = 0;
            //    dropLoiNhuanDSTC.SelectedIndex = 0;
            //}

            info = DotDanhGiaController.GetInfoDotDanhGiaConfig(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 15);

            try
            {
                //dropDoanhThuPTKD.SelectedValue = info.IDDiemDoanhThu.ToString();
                //dropLoiNhuanPTKD.SelectedValue = info.IDDiemLoiNhuan.ToString();

                txtDoanhThuVPHCM.Text = info.IDDiemDoanhThu.ToString().Replace(".", ",");
                txtLoiNhuanVPHCM.Text = info.IDDiemLoiNhuan.ToString().Replace(".", ",");

                //int diemDoanhThuHT = GetDiemDTKinhDoanh((int)info.IDDiemDoanhThu);
                //int diemLoiNhuanHT = GetDiemLNKinhDoanh((int)info.IDDiemLoiNhuan);

                double diemDoanhThuHT = info.IDDiemDoanhThu * 24 / 100;
                double diemLoiNhuanHT = info.IDDiemLoiNhuan * 36 / 100;

                if (diemDoanhThuHT > 24) diemDoanhThuHT = 24;
                if (diemLoiNhuanHT > 36) diemLoiNhuanHT = 36;

                lblDiemDT_VPHCM.Text = diemDoanhThuHT.ToString("#.##");
                lblDiemLN_VPHCM.Text = diemLoiNhuanHT.ToString("#.##");
                lblTongDiem_VPHCM.Text = (diemDoanhThuHT + diemLoiNhuanHT).ToString("#.##");
            }
            catch
            {
                //dropDoanhThuPTKD.SelectedIndex = 0;
                //dropLoiNhuanPTKD.SelectedIndex = 0;

                txtDoanhThuVPHCM.Text = "";
                txtLoiNhuanVPHCM.Text = "";
            }

            info = DotDanhGiaController.GetInfoDotDanhGiaConfig(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), 18);

            try
            {
                //dropDoanhThuPTKD.SelectedValue = info.IDDiemDoanhThu.ToString();
                //dropLoiNhuanPTKD.SelectedValue = info.IDDiemLoiNhuan.ToString();

                txtDoanhThuQUANGCAOSO.Text = info.IDDiemDoanhThu.ToString().Replace(".", ",");
                txtLoiNhuanQUANGCAOSO.Text = info.IDDiemLoiNhuan.ToString().Replace(".", ",");

                //int diemDoanhThuHT = GetDiemDTKinhDoanh((int)info.IDDiemDoanhThu);
                //int diemLoiNhuanHT = GetDiemLNKinhDoanh((int)info.IDDiemLoiNhuan);

                double diemDoanhThuHT = info.IDDiemDoanhThu * 24 / 100;
                double diemLoiNhuanHT = info.IDDiemLoiNhuan * 36 / 100;

                if (diemDoanhThuHT > 24) diemDoanhThuHT = 24;
                if (diemLoiNhuanHT > 36) diemLoiNhuanHT = 36;

                lblDiemDT_QUANGCAOSO.Text = diemDoanhThuHT.ToString("#.##");
                lblDiemLN_QUANGCAOSO.Text = diemLoiNhuanHT.ToString("#.##");
                lblTongDiem_QUANGCAOSO.Text = (diemDoanhThuHT + diemLoiNhuanHT).ToString("#.##");
            }
            catch
            {
                //dropDoanhThuPTKD.SelectedIndex = 0;
                //dropLoiNhuanPTKD.SelectedIndex = 0;

                txtDoanhThuQUANGCAOSO.Text = "";
                txtLoiNhuanQUANGCAOSO.Text = "";
            }
        }

        //private int GetDiemDT(int idDiemDoanhThu)
        //{
        //    if (idDiemDoanhThu == 1) return 8;
        //    if (idDiemDoanhThu == 2) return 7;
        //    if (idDiemDoanhThu == 3) return 6;
        //    if (idDiemDoanhThu == 4) return 5;
        //    if (idDiemDoanhThu == 5) return 4;
        //    if (idDiemDoanhThu == 6) return 3;
        //    if (idDiemDoanhThu == 7) return 0;
        //    return 0;
        //}

        //private int GetDiemLN(int idDiemLoiNhuan)
        //{
        //    if (idDiemLoiNhuan == 1) return 12;
        //    if (idDiemLoiNhuan == 2) return 10;
        //    if (idDiemLoiNhuan == 3) return 9;
        //    if (idDiemLoiNhuan == 4) return 8;
        //    if (idDiemLoiNhuan == 5) return 6;
        //    if (idDiemLoiNhuan == 6) return 5;
        //    if (idDiemLoiNhuan == 7) return 0;
        //    return 0;
        //}

        //private int GetDiemDTKinhDoanh(int idDiemDoanhThu)
        //{
        //    if (idDiemDoanhThu == 1) return 50;
        //    if (idDiemDoanhThu == 2) return 40;
        //    if (idDiemDoanhThu == 3) return 30;
        //    if (idDiemDoanhThu == 4) return 20;
        //    if (idDiemDoanhThu == 5) return 10;
        //    if (idDiemDoanhThu == 6) return 5;
        //    if (idDiemDoanhThu == 7) return 0;
        //    return 0;
        //}

        //private int GetDiemLNKinhDoanh(int idDiemLoiNhuan)
        //{
        //    if (idDiemLoiNhuan == 1) return 70;
        //    if (idDiemLoiNhuan == 2) return 60;
        //    if (idDiemLoiNhuan == 3) return 50;
        //    if (idDiemLoiNhuan == 4) return 40;
        //    if (idDiemLoiNhuan == 5) return 30;
        //    if (idDiemLoiNhuan == 6) return 20;
        //    if (idDiemLoiNhuan == 7) return 10;
        //    return 0;
        //}

        protected void btnUpdate1_Click(object sender, EventArgs e)
        {
            DotDanhGiaConfigInfo info = new DotDanhGiaConfigInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            //info.IDDiemDoanhThu = ConvertUtility.ToDouble(dropDoanhThuIT.SelectedValue);
            //info.IDDiemLoiNhuan = ConvertUtility.ToDouble(dropLoiNhuanIT.SelectedValue);
            info.IDDiemDoanhThu = ConvertUtility.ToDouble(txtDoanhThuIT.Text);
            info.IDDiemLoiNhuan = ConvertUtility.ToDouble(txtLoiNhuanIT.Text);
            info.IDTrungTam = 1;

            DotDanhGiaController.UpdateDoanhThuLoiNhuan(info);
        }

        protected void btnUpdate2_Click(object sender, EventArgs e)
        {
            DotDanhGiaConfigInfo info = new DotDanhGiaConfigInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.IDDiemDoanhThu = ConvertUtility.ToDouble(dropDoanhThuNSHC.SelectedValue);
            info.IDDiemLoiNhuan = ConvertUtility.ToDouble(dropLoiNhuanNSHC.SelectedValue);
            info.IDTrungTam = 2;

            DotDanhGiaController.UpdateDoanhThuLoiNhuan(info);
        }

        //protected void btnUpdate3_Click(object sender, EventArgs e)
        //{
        //    DotDanhGiaConfigInfo info = new DotDanhGiaConfigInfo();

        //    info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
        //    info.IDDiemDoanhThu = ConvertUtility.ToDouble(dropDoanhThuTCKT.SelectedValue);
        //    info.IDDiemLoiNhuan = ConvertUtility.ToDouble(dropLoiNhuanTCKT.SelectedValue);
        //    info.IDTrungTam = 3;

        //    DotDanhGiaController.UpdateDoanhThuLoiNhuan(info);
        //}

        protected void btnUpdate4_Click(object sender, EventArgs e)
        {
            DotDanhGiaConfigInfo info = new DotDanhGiaConfigInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            //info.IDDiemDoanhThu = ConvertUtility.ToDouble(dropDoanhThuPTKD.SelectedValue);
            //info.IDDiemLoiNhuan = ConvertUtility.ToDouble(dropLoiNhuanPTKD.SelectedValue);
            info.IDDiemDoanhThu = ConvertUtility.ToDouble(txtDoanhThuPTKD.Text);
            info.IDDiemLoiNhuan = ConvertUtility.ToDouble(txtLoiNhuanPTKD.Text);
            info.IDTrungTam = 4;

            DotDanhGiaController.UpdateDoanhThuLoiNhuan(info);
        }

        protected void btnUpdate5_Click(object sender, EventArgs e)
        {
            DotDanhGiaConfigInfo info = new DotDanhGiaConfigInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            //info.IDDiemDoanhThu = ConvertUtility.ToDouble(dropDoanhThuPTND.SelectedValue);
            //info.IDDiemLoiNhuan = ConvertUtility.ToDouble(dropLoiNhuanPTND.SelectedValue);
            info.IDDiemDoanhThu = ConvertUtility.ToDouble(txtDoanhThuPTND.Text);
            info.IDDiemLoiNhuan = ConvertUtility.ToDouble(txtLoiNhuanPTND.Text);
            info.IDTrungTam = 5;

            DotDanhGiaController.UpdateDoanhThuLoiNhuan(info);
        }

        protected void btnUpdate6_Click(object sender, EventArgs e)
        {
            DotDanhGiaConfigInfo info = new DotDanhGiaConfigInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            //info.IDDiemDoanhThu = ConvertUtility.ToDouble(dropDoanhThuLUCKYFONE.SelectedValue);
            //info.IDDiemLoiNhuan = ConvertUtility.ToDouble(dropLoiNhuanLUCKYFONE.SelectedValue);
            info.IDDiemDoanhThu = ConvertUtility.ToDouble(txtDoanhThuLuckyFone.Text);
            info.IDDiemLoiNhuan = ConvertUtility.ToDouble(txtLoiNhuanLuckyFone.Text);
            info.IDTrungTam = 6;

            DotDanhGiaController.UpdateDoanhThuLoiNhuan(info);
        }

        protected void btnUpdate7_Click(object sender, EventArgs e)
        {
            DotDanhGiaConfigInfo info = new DotDanhGiaConfigInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            //info.IDDiemDoanhThu = ConvertUtility.ToDouble(dropDoanhThuBANQUYEN.SelectedValue);
            //info.IDDiemLoiNhuan = ConvertUtility.ToDouble(dropLoiNhuanBANQUYEN.SelectedValue);
            info.IDDiemDoanhThu = ConvertUtility.ToDouble(txtDoanhThuBanQuyen.Text);
            info.IDDiemLoiNhuan = ConvertUtility.ToDouble(txtLoiNhuanBanQuyen.Text);
            info.IDTrungTam = 7;

            DotDanhGiaController.UpdateDoanhThuLoiNhuan(info);
        }

        //protected void btnUpdate8_Click(object sender, EventArgs e)
        //{
        //    DotDanhGiaConfigInfo info = new DotDanhGiaConfigInfo();

        //    info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
        //    info.IDDiemDoanhThu = ConvertUtility.ToDouble(dropDoanhThuDVKH.SelectedValue);
        //    info.IDDiemLoiNhuan = ConvertUtility.ToDouble(dropLoiNhuanDVKH.SelectedValue);
        //    info.IDTrungTam = 8;

        //    DotDanhGiaController.UpdateDoanhThuLoiNhuan(info);
        //}

        //protected void btnUpdate9_Click(object sender, EventArgs e)
        //{
        //    DotDanhGiaConfigInfo info = new DotDanhGiaConfigInfo();

        //    info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
        //    info.IDDiemDoanhThu = ConvertUtility.ToDouble(dropDoanhThuLINGO.SelectedValue);
        //    info.IDDiemLoiNhuan = ConvertUtility.ToDouble(dropLoiNhuanLINGO.SelectedValue);

        //    info.IDDiem1 = ConvertUtility.ToInt32(txtDiemUuDiem.Text);
        //    info.IDDiem2 = ConvertUtility.ToInt32(txtPhatHanhThe.Text);
        //    info.IDDiem3 = ConvertUtility.ToInt32(txtPos.Text);

        //    info.IDTrungTam = 9;

        //    DotDanhGiaController.UpdateDoanhThuLoiNhuan(info);
        //}

        //protected void btnUpdate10_Click(object sender, EventArgs e)
        //{
        //    DotDanhGiaConfigInfo info = new DotDanhGiaConfigInfo();

        //    info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
        //    info.IDDiemDoanhThu = ConvertUtility.ToDouble(dropDoanhThuPTDV.SelectedValue);
        //    info.IDDiemLoiNhuan = ConvertUtility.ToDouble(dropLoiNhuanPTDV.SelectedValue);
        //    info.IDTrungTam = 10;

        //    DotDanhGiaController.UpdateDoanhThuLoiNhuan(info);
        //}

        //protected void btnUpdate11_Click(object sender, EventArgs e)
        //{
        //    DotDanhGiaConfigInfo info = new DotDanhGiaConfigInfo();

        //    info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
        //    info.IDDiemDoanhThu = ConvertUtility.ToDouble(dropDoanhThuTIEPTHISO.SelectedValue);
        //    info.IDDiemLoiNhuan = ConvertUtility.ToDouble(dropLoiNhuanTIEPTHISO.SelectedValue);
        //    info.IDTrungTam = 11;

        //    DotDanhGiaController.UpdateDoanhThuLoiNhuan(info);
        //}

        //protected void btnUpdate14_Click(object sender, EventArgs e)
        //{
        //    DotDanhGiaConfigInfo info = new DotDanhGiaConfigInfo();

        //    info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
        //    info.IDDiemDoanhThu = ConvertUtility.ToDouble(dropDoanhThuDSTC.SelectedValue);
        //    info.IDDiemLoiNhuan = ConvertUtility.ToDouble(dropLoiNhuanDSTC.SelectedValue);
        //    info.IDTrungTam = 14;

        //    DotDanhGiaController.UpdateDoanhThuLoiNhuan(info);
        //}


        protected void btnUpdate15_Click(object sender, EventArgs e)
        {
            DotDanhGiaConfigInfo info = new DotDanhGiaConfigInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.IDDiemDoanhThu = ConvertUtility.ToDouble(txtDoanhThuVPHCM.Text);
            info.IDDiemLoiNhuan = ConvertUtility.ToDouble(txtLoiNhuanVPHCM.Text);
            info.IDTrungTam = 15;

            DotDanhGiaController.UpdateDoanhThuLoiNhuan(info);
        }

        protected void btnUpdate18_Click(object sender, EventArgs e)
        {
            DotDanhGiaConfigInfo info = new DotDanhGiaConfigInfo();

            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.IDDiemDoanhThu = ConvertUtility.ToDouble(txtDoanhThuQUANGCAOSO.Text);
            info.IDDiemLoiNhuan = ConvertUtility.ToDouble(txtLoiNhuanQUANGCAOSO.Text);
            info.IDTrungTam = 18;

            DotDanhGiaController.UpdateDoanhThuLoiNhuan(info);
        }

        protected void dropDotDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate1_Click(null, null);
            btnUpdate2_Click(null, null);
            //btnUpdate3_Click(null, null);
            btnUpdate4_Click(null, null);
            btnUpdate5_Click(null, null);
            btnUpdate6_Click(null, null);
            btnUpdate7_Click(null, null);
            //btnUpdate8_Click(null, null);
            //btnUpdate9_Click(null, null);
            //btnUpdate10_Click(null, null);
            //btnUpdate11_Click(null, null);
            //btnUpdate14_Click(null, null);
            btnUpdate15_Click(null, null);
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