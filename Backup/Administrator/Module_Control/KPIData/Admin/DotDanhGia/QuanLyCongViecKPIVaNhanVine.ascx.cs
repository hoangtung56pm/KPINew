using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library.Components.Security;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using VmgPortal.Library.Utilities;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;
using System.Data;
using VmgPortal.Library.Components.Users;
using System.Drawing;
using VmgPortal.Modules.KPIData.Library;
using VmgPortal.Modules.KPIData.Library.DanhGiaBoPhan;
using VmgPortal.Modules.KPIData.Library.DanhGia;
using System.IO;

namespace VmgPortal.Modules.KPIData.Admin.DotDanhGia
{
    public partial class QuanLyCongViecKPIVaNhanVine : AuthenticatedControl
    {
        double tongCaNhan = 0;
        double tongCaNhanGLV = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Nav"] = "1";
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            
            dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
            dropDotDanhGia.DataBind();

            if (Session["IDDotDanhGia"] != null)
            {
                dropDotDanhGia.SelectedValue = Session["IDDotDanhGia"].ToString();
            }
            else
            {
                int idDotDanhActive = ConvertUtility.ToInt32(DotDanhGiaController.GetDaultDotDanhGia().Rows[0]["ID"]);
                dropDotDanhGia.SelectedValue = idDotDanhActive.ToString();
            }

            dropTrungTam.DataSource = BoPhanController.GetAll();
            dropTrungTam.DataBind();


            if (Session["IDTrungTam"] != null)
            {
                dropTrungTam.SelectedValue = Session["IDTrungTam"].ToString();
            }
            else
            {
                dropTrungTam.SelectedValue = CurrentUser.IDTrungTam.ToString();
            }

            lstNhanVien.Items.Clear();
            DataTable dtNhanVien = null;

            if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
            {
                dtNhanVien = DotDanhGiaController.QuanLyNhanVienTheoNDG_ByNhanVienQuanLy(CurrentUser.UserID, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            }
            else
            {
                dtNhanVien = DotDanhGiaController.GetAllNhanVien(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 0, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));
            }

            if (dtNhanVien != null && dtNhanVien.Rows.Count > 0)
            {
                DataTable dtNew = dtNhanVien.Clone();

                foreach (DataRow item in dtNhanVien.Rows)
                {
                    DataRow rowNew = dtNew.NewRow();
                    rowNew["UserID"] = item["UserID"];

                    DataTable dtCongViec = DotDanhGiaController.GetAllCongViecGiaoChoNhanVienKTXVaPS_6_11_2014(ConvertUtility.ToInt32(item["UserID"]), 1, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

                    double tyTrongCVDuocGiao = 0;
                    foreach (DataRow row in dtCongViec.Rows)
                    {
                        tyTrongCVDuocGiao += Math.Round(ConvertUtility.ToDouble(row["TyTrong"]), 3);
                    }

                    rowNew["UserName"] = "( " + tyTrongCVDuocGiao + "%) " + item["UserName"].ToString();

                    dtNew.Rows.Add(rowNew);
                }

                lstNhanVien.DataSource = dtNew;
                lstNhanVien.DataBind();

                int idNhanVien = 0;

                if (Session["IDNhanVien"] != null)
                {
                    idNhanVien = ConvertUtility.ToInt32(Session["IDNhanVien"]);
                    try
                    {
                        lstNhanVien.SelectedValue = idNhanVien.ToString();
                    }
                    catch
                    {
                    }                    
                }

                lstCongViecDuocGiao.Items.Clear();
                QuanLyCongViecKTXVaPSController.LoadCongViec(lstCongViecDuocGiao.Items, ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 0, 1, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

                lstCongViec.Items.Clear();
                QuanLyCongViecKTXVaPSController.LoadCongViecChuaDuocGiao(lstCongViec.Items, ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 0, 1, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

                if (idNhanVien > 0)
                {
                    DataTable dtCongViecTX = DotDanhGiaController.GetAllCongViecGiaoChoNhanVienKTXVaPS_6_11_2014(idNhanVien, 1, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

                    DataTable dtCongViecTXNew = dtCongViecTX.Clone();

                    try
                    {
                        lstNhanVien.SelectedValue = idNhanVien.ToString();
                    }
                    catch (Exception)
                    {
                        lstNhanVien.SelectedIndex = -1;
                    }

                    #region Cong Viec Thuong Xuyen

                    foreach (ListItem item in lstCongViecDuocGiao.Items)
                    {
                        if (dtCongViecTX.Select("IDCongViecKPI = " + item.Value).Length > 0)
                        {
                            item.Attributes.Add("style", "color:blue");
                        }
                    }

                    foreach (DataRow item in dtCongViecTX.Rows)
                    {
                        DataRow row = dtCongViecTXNew.NewRow();

                        row["ID"] = ConvertUtility.ToString(item["ID"]);
                        row["TenCVCha"] = ConvertUtility.ToString(item["TenCVCha"]);
                        row["Ten"] = item["Ten"];
                        row["NgayBatDau"] = ConvertUtility.ToDateTime(item["NgayBatDau"]);//.ToString("dd/MM/yyyy");
                        row["NgayKetThuc"] = ConvertUtility.ToDateTime(item["NgayKetThuc"]);//.ToString("dd/MM/yyyy");
                        row["KeHoach"] = item["KeHoach"].ToString().Replace("\n", "<br /><br />").Replace("\r", "<br /><br />");
                        row["TyTrong"] = Math.Round(ConvertUtility.ToDouble(item["TyTrong"]), 2).ToString();
                        row["SoGio"] = Math.Round(ConvertUtility.ToDouble(item["SoGio"]), 2).ToString();
                        dtCongViecTXNew.Rows.Add(row);

                    }
                    dgrNhanVienCVTX.DataSource = dtCongViecTXNew;

                    #endregion

                    #region ty trong cong viec da giao

                    DataTable dtCongViecThuongXuyen = DotDanhGiaController.GetAllCongViecGiaoChoNhanVienKTXVaPS(idNhanVien, 1, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

                    double tyTrongCVThuongXuyen = 0;
                    double SoGioCVThuongXuyen = 0;
                    foreach (DataRow item in dtCongViecThuongXuyen.Rows)
                    {
                        tyTrongCVThuongXuyen += ConvertUtility.ToDouble(item["TyTrong"]);
                        SoGioCVThuongXuyen += ConvertUtility.ToDouble(item["SoGio"]);
                    }

                    DataTable dtCongViecKTH = DotDanhGiaController.GetAllCongViecGiaoChoNhanVienKTXVaPS(idNhanVien, 2, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

                    double tyTrongCVKeHoachThang = 0;
                    double SoGioCVKeHoachThang = 0;
                    foreach (DataRow item in dtCongViecKTH.Rows)
                    {
                        tyTrongCVKeHoachThang += ConvertUtility.ToDouble(item["TyTrong"]);
                        SoGioCVKeHoachThang += ConvertUtility.ToDouble(item["SoGio"]);
                    }

                    DataTable dtCongViecPhatSinh = DotDanhGiaController.GetAllCongViecGiaoChoNhanVienKTXVaPS(idNhanVien, 3, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

                    double tyTrongCVPhatSinh = 0;
                    double SoGioCVPhatSinh = 0;
                    foreach (DataRow item in dtCongViecPhatSinh.Rows)
                    {
                        tyTrongCVPhatSinh += ConvertUtility.ToDouble(item["TyTrong"]);
                        SoGioCVPhatSinh += ConvertUtility.ToDouble(item["SoGio"]);
                    }

                    lblTyTrongCVThuongXuyen.Text = Math.Round(tyTrongCVThuongXuyen, 2).ToString() + "% <br/>" + Math.Round(SoGioCVThuongXuyen, 2).ToString() + "h";
                    lblTyTrongCVKeHoachThang.Text = Math.Round(tyTrongCVKeHoachThang, 2).ToString() + "% <br/>" + Math.Round(SoGioCVKeHoachThang, 2).ToString() + "h";
                    lblTyTrongCVPhatSinh.Text = Math.Round(tyTrongCVPhatSinh, 2).ToString() + "% <br/>" + Math.Round(SoGioCVPhatSinh, 2).ToString() + "h";
                    lblTongTyTrong.Text = Math.Round((tyTrongCVThuongXuyen + tyTrongCVKeHoachThang + tyTrongCVPhatSinh), 2) + "% <br />" + Math.Round((SoGioCVThuongXuyen + SoGioCVKeHoachThang + SoGioCVPhatSinh), 2) + "h";

                    #endregion
                }
            }
            dgrNhanVienCVTX.DataBind();
        }

        protected void dropTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dropPhongBan.Items.Clear();
            //dropPhongBan.DataSource = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            //dropPhongBan.DataBind();
            //dropPhongBan.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));
            Session["Nav"] = "1";
            Session["IDNhanVien"] = null;

            if (CurrentUser.IsAdmin || CurrentUser.IsSuperAdmin)
            {
                Session["IDTrungTam"] = dropTrungTam.SelectedValue;
                Session["IDDotDanhGia"] = dropDotDanhGia.SelectedValue;
            }
        }

        protected void dropPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Nav"] = "1";
            Session["IDNhanVien"] = null;

            if (CurrentUser.IsAdmin || CurrentUser.IsSuperAdmin)
            {
                Session["IDTrungTam"] = dropTrungTam.SelectedValue;
                Session["IDDotDanhGia"] = dropDotDanhGia.SelectedValue;
            }
        }

        protected void btnUpdateCongViecVaoKeHoach1_Click(object sender, EventArgs e)
        {
            #region Cap nhat cong viec vao ke hoach thang cua nhan vien va bo phan


            int idDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);

            try
            {
                int idNhanVien = ConvertUtility.ToInt32(lstNhanVien.SelectedValue);
                DataTable dtCongViec = DotDanhGiaController.GetAllCongViecGiaoChoNhanVienKTXVaPS(idNhanVien, 1, idDotDanhGia);

                if (dtCongViec != null && dtCongViec.Rows.Count > 0)
                {
                    foreach (DataRow row in dtCongViec.Rows)
                    {
                        DanhGiaThang_DGCBCNVDanhGiaTTCVInfo info = new DanhGiaThang_DGCBCNVDanhGiaTTCVInfo();

                        info.IDDotDanhGia = idDotDanhGia;
                        info.IDNhanVien = idNhanVien;
                        info.TenCongViec = ConvertUtility.ToString(row["Ten"]);
                        int idCongViecKPI = ConvertUtility.ToInt32(row["IDCongViecKPI"]);
                        info.TyTrongCV = ConvertUtility.ToDouble(row["TyTrong"]);
                        info.SoGio = ConvertUtility.ToDouble(row["SoGio"]);
                        info.SoLieuCamKet = ConvertUtility.ToString(row["KeHoach"]);
                        info.YeuCauHoTro = "";
                        info.Loai = 1;
                        info.IDCongViec = idCongViecKPI;
                        info.IDBoPhanHoTro = 0;
                        info.IDBoPhan = ConvertUtility.ToInt32(row["IDBoPhan"]);
                        info.IDPhongBan = ConvertUtility.ToInt32(row["IDPhongBan"]);
                        info.NgayBatDau = ConvertUtility.ToDateTime(row["NgayBatDau"]);
                        info.NgayKetThuc = ConvertUtility.ToDateTime(row["NgayKetThuc"]);
                        DanhGiaThang_DGCBCNVDanhGiaTTCVController.InsertKeHoachThang(info);
                    }
                }
            }
            catch (Exception)
            {
            }

            #endregion
            Session["Nav"] = "1";

        }

        protected void btnUpdateCongViecVaoKeHoach_Click(object sender, EventArgs e)
        {
            #region Cap nhat cong viec vao ke hoach thang cua nhan vien va bo phan

            DataTable dt = DotDanhGiaController.GetAllNhanVienTemp(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 0);

            int idDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);

            foreach (DataRow item in dt.Rows)
            {
                try
                {
                    string[] array = item["UserID"].ToString().Split('_');
                    int idNhanVien = ConvertUtility.ToInt32(array[0]);
                    DataTable dtCongViec = DotDanhGiaController.GetAllCongViecGiaoChoNhanVienKTXVaPS(idNhanVien, 1, idDotDanhGia);

                    if (dtCongViec != null && dtCongViec.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtCongViec.Rows)
                        {
                            DanhGiaThang_DGCBCNVDanhGiaTTCVInfo info = new DanhGiaThang_DGCBCNVDanhGiaTTCVInfo();

                            info.IDDotDanhGia = idDotDanhGia;
                            info.IDNhanVien = idNhanVien;
                            info.TenCongViec = ConvertUtility.ToString(row["Ten"]);
                            int idCongViecKPI = ConvertUtility.ToInt32(row["IDCongViecKPI"]);
                            info.TyTrongCV = ConvertUtility.ToDouble(row["TyTrong"]);
                            info.SoGio = ConvertUtility.ToDouble(row["SoGio"]);
                            info.SoLieuCamKet = ConvertUtility.ToString(row["KeHoach"]);
                            info.YeuCauHoTro = "";
                            info.Loai = 1;
                            info.IDCongViec = idCongViecKPI;
                            info.IDBoPhanHoTro = 0;
                            info.IDBoPhan = ConvertUtility.ToInt32(row["IDBoPhan"]);
                            info.IDPhongBan = ConvertUtility.ToInt32(row["IDPhongBan"]);
                            info.NgayBatDau = ConvertUtility.ToDateTime(row["NgayBatDau"]);
                            info.NgayKetThuc = ConvertUtility.ToDateTime(row["NgayKetThuc"]);
                            DanhGiaThang_DGCBCNVDanhGiaTTCVController.InsertKeHoachThang(info);
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }

            #endregion
            Session["Nav"] = "1";
        }

        protected void lstNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idNhanVien = ConvertUtility.ToInt32(lstNhanVien.SelectedValue);
            Session["IDNhanVien"] = idNhanVien;
            Session["Nav"] = "1";
        }

        protected void dgrNhanVienCVTX_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView crr = (DataRowView)e.Row.DataItem;

                tongCaNhan += ConvertUtility.ToDouble(crr["TyTrong"]);
                tongCaNhanGLV += ConvertUtility.ToDouble(crr["SoGio"]);
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTongCaNhan = (Label)e.Row.FindControl("lblTongCaNhan");
                Label lblGLVTongCaNhan = (Label)e.Row.FindControl("lblGLVTongCaNhan");

                lblTongCaNhan.Text = Math.Round(tongCaNhan, 2).ToString() + "%";
                lblGLVTongCaNhan.Text = Math.Round(tongCaNhanGLV, 2).ToString() + "h";
            }
        }

        protected void dropDotDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Nav"] = "1";

            //if (CurrentUser.IsAdmin || CurrentUser.IsSuperAdmin)
            //{
                Session["IDTrungTam"] = dropTrungTam.SelectedValue;
                Session["IDDotDanhGia"] = dropDotDanhGia.SelectedValue;
            //}
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int idNhanVien = ConvertUtility.ToInt32(lstNhanVien.SelectedValue);

            foreach (ListItem item in lstCongViec.Items)
            {
                if (item.Selected)
                {
                    string[] arr = item.Value.Split('_');
                    int value = ConvertUtility.ToInt32(arr[0]);
                    int hasChild = ConvertUtility.ToInt32(arr[1]);
                    if (hasChild == 0)
                    {
                        DotDanhGiaController.UpdateCongViecChoNhanVien(idNhanVien, value, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 0, 0, 0);
                    }

                    btnUpdateCongViecVaoKeHoach1_Click(null, null);
                }
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int idNhanVien = ConvertUtility.ToInt32(lstNhanVien.SelectedValue);

            foreach (ListItem item in lstCongViecDuocGiao.Items)
            {
                if (item.Selected)
                {
                    DotDanhGiaController.RemoveCongViecGiaoChoNhanVien(idNhanVien, ConvertUtility.ToInt32(item.Value), ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 0);
                }
            }
            Session["Nav"] = "1";
        }

        protected void dgrNhanVienCVTX_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "TyTrongCaNhan")
            {
                foreach (GridViewRow item in dgrNhanVienCVTX.Rows)
                {
                    Label lblID = (Label)item.FindControl("lblID");
                    TextBox txtTyTrongCaNhan = (TextBox)item.FindControl("txtTyTrongCaNhan");
                    double tytong = ConvertUtility.ToDouble(txtTyTrongCaNhan.Text);
                    double sogio = tytong * 176 / 100;

                    DotDanhGiaController.UpdateTyTrongCongViecNhanVienV2(ConvertUtility.ToInt32(lblID.Text), tytong, sogio);
                }

                btnUpdateCongViecVaoKeHoach1_Click(null, null);
            }

            if (e.CommandName == "GioLamViec")
            {
                foreach (GridViewRow item in dgrNhanVienCVTX.Rows)
                {
                    Label lblID = (Label)item.FindControl("lblID");
                    TextBox txtGLVCaNhan = (TextBox)item.FindControl("txtGLVCaNhan");

                    double sogio = ConvertUtility.ToDouble(txtGLVCaNhan.Text);
                    double tytrong = sogio * 100 / 176;
                    DotDanhGiaController.UpdateTyTrongCongViecNhanVienV2(ConvertUtility.ToInt32(lblID.Text), tytrong, sogio);
                }

                btnUpdateCongViecVaoKeHoach1_Click(null, null);
            }
        }

        protected void btnXem_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '/popup.aspx?idCongViec=" + lstCongViecDuocGiao.SelectedValue + "&idDotDanhGia=" + dropDotDanhGia.SelectedValue + "&idTrungTam=" + dropTrungTam.SelectedValue + "&idPhongBan=" + 0 + "&loai=1', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );");
            Response.Write("</script>");
            Session["Nav"] = "1";
        }
    }
}