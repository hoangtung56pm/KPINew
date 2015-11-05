using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Utilities;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;
using System.Data;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using VmgPortal.Modules.KPIData.Library;
using System.Xml;
using System.Text;
using System.IO;
using System.Xml.Xsl;
using VmgPortal.Modules.LogFile.Lib;
using VmgPortal.Modules.KPIData.Library.DanhGia;
using System.Text.RegularExpressions;
using VmgPortal.Library;

namespace VmgPortal.Modules.KPIData.Admin.DotDanhGia
{
    public partial class QuanLyCongViecBaoCaoNgay : AuthenticatedControl
    {
        private const int MAX_ZONE_ORDER = 50;
        private int zoneSelected
        {
            get
            {
                if (ViewState["zoneSelected"] != null) return (int)ViewState["zoneSelected"];
                else return 0;
            }
            set { ViewState["zoneSelected"] = value; }
        }

        private int IDPhongBan
        {
            get
            {
                if (ViewState["IDPhongBan"] != null) return (int)ViewState["IDPhongBan"];
                else return ConvertUtility.ToInt32(dropPhongBan.SelectedValue);
            }
            set { ViewState["IDPhongBan"] = value; }
        }

        private int IDDotDanhGia
        {
            get
            {
                if (ViewState["IDDotDanhGia"] != null) return (int)ViewState["IDDotDanhGia"];
                else return 0;
            }
            set { ViewState["IDDotDanhGia"] = value; }
        }

        double tong = 0;
        double tongSoGio = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dropYearCopy.SelectedValue = dropYear.SelectedValue = DateTime.Now.Year.ToString();
                dropMonthCopy.SelectedValue = dropMonth.SelectedValue = DateTime.Now.Month.ToString();
                BindDay();
                dropDay.SelectedValue = DateTime.Now.Day.ToString();
                BindDayCopy();
                dropDayCopy.SelectedValue = DateTime.Now.Day.ToString();

                dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
                dropDotDanhGia.DataBind();

                cmdDel.OnClientClick = MiscUtility.MSG_DELETE_CONFIRM;

                lblStatusUpdate.Text = string.Empty;

                dropTrungTam.DataSource = BoPhanController.GetAll();
                dropTrungTam.DataBind();
                dropTrungTam.SelectedValue = CurrentUser.IDTrungTam.ToString();

                #region Get Phong Ban

                DataTable dtPhong;
                if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                {
                    dropTrungTam.Enabled = false;
                    if (CurrentUser.RoleID == (int)Constants.Role.NhanVien)
                    {
                        #region Role Nhan Vien

                        dropPhongBan.Enabled = false;
                        dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
                        dropPhongBan.Items.Clear();
                        dropPhongBan.DataSource = dtPhong;
                        dropPhongBan.DataBind();
                        dropPhongBan.Items.Insert(0, new ListItem("Tất cả", "0"));

                        try
                        {
                            dropPhongBan.SelectedValue = CurrentUser.IDPhong.ToString();
                        }
                        catch (Exception)
                        {
                            dropPhongBan.SelectedIndex = -1;
                        }

                        #endregion
                    }
                    else
                    {
                        if (CurrentUser.RoleID == (int)Constants.Role.COO || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiHoTro || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiKinhDoanh || CurrentUser.RoleID == (int)Constants.Role.PhoGiamDoc)
                        {
                            #region Role TBP, Pho Giam Doc, COO

                            dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
                            dropPhongBan.Items.Clear();
                            dropPhongBan.DataSource = dtPhong;
                            dropPhongBan.DataBind();
                            dropPhongBan.Items.Insert(0, new ListItem("Tất cả", "0"));

                            #endregion
                        }
                        else
                        {
                            #region Role Pho Phong, Truong Phong, Truong Nhom

                            dropPhongBan.Enabled = false;
                            dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), CurrentUser.UserID);
                            dropPhongBan.Items.Clear();
                            dropPhongBan.DataSource = dtPhong;
                            dropPhongBan.DataBind();
                            dropPhongBan.Items.Insert(0, new ListItem("Tất cả", "0"));

                            #endregion
                        }
                    }
                }
                else
                {
                    #region Role Admin

                    dropTrungTam.Enabled = true;
                    dropPhongBan.Enabled = true;

                    dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
                    dropPhongBan.Items.Clear();
                    dropPhongBan.DataSource = dtPhong;
                    dropPhongBan.DataBind();
                    dropPhongBan.Items.Insert(0, new ListItem("Tất cả", "0"));

                    try
                    {
                        dropPhongBan.SelectedValue = CurrentUser.IDPhong.ToString();
                    }
                    catch (Exception)
                    {
                        dropPhongBan.SelectedIndex = -1;
                    }

                    #endregion
                }

                #endregion

                //dropPhong.Items.Clear();
                //dropPhong.DataSource = dtPhong;
                //dropPhong.DataBind();
                //dropPhong.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));

                BuildCongViec();
            }
        }

        private void BuildCongViec()
        {
            dropCongViecKPI.Items.Clear();
            DataTable dtCongViec = DotDanhGiaController.GetAllCongViecGiaoChoNhanVienTheoNgay(CurrentUser.UserID, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

            DataTable dtCongViecClone = dtCongViec.Clone();
            foreach (DataRow item in dtCongViec.Rows)
            {
                DataTable lstCongViec = new DataTable();
                lstCongViec.Columns.Add("IDCongViecKPI", typeof(string));
                lstCongViec.Columns.Add("Ten", typeof(string));
                lstCongViec.Columns.Add("ParentID", typeof(string));
                lstCongViec.Columns.Add("LevelDeep", typeof(string));
                GetTenCongViec(lstCongViec, ConvertUtility.ToInt32(item["IDCongViecKPI"]), ConvertUtility.ToString(item["Ten"]), ConvertUtility.ToInt32(item["ParentID"]), ConvertUtility.ToInt32(item["LevelDeep"]));

                lstCongViec = resort(lstCongViec, "LevelDeep", "DESC");
                int i = 0;
                foreach (DataRow _item in lstCongViec.Rows)
                {
                    DataRow row = dtCongViecClone.NewRow();

                    row["IDCongViecKPI"] = item["IDCongViecKPI"];
                    row["Ten"] = MiscUtility.StringIndent(i) + _item["Ten"];

                    ListItem itemStyle = new ListItem();
                    itemStyle.Text = MiscUtility.StringIndent(i) + _item["Ten"];
                    itemStyle.Value = item["IDCongViecKPI"].ToString();
                    if (i == lstCongViec.Rows.Count - 1)
                    {
                        itemStyle.Attributes.Add("style", "font-weight:bold; color:blue");
                    }
                    else
                    {
                        itemStyle.Attributes.Add("style", "font-style: italic;");
                    }

                    dropCongViecKPI.Items.Add(itemStyle);
                    i++;
                }
            }

            dropCongViecKPI.Items.Add(new ListItem("Công việc khác hoặc công việc phát sinh", "0"));
        }

        private static DataTable resort(DataTable dt, string colName, string direction)
        {
            dt.DefaultView.Sort = colName + " " + direction;
            dt = dt.DefaultView.ToTable();
            return dt;
        }

        private static void GetTenCongViec(DataTable lstItems, int IDCongViecKPI, string ten, int ParentID, int LevelDeep)
        {
            DataRow item = lstItems.NewRow();

            item["Ten"] = ten;
            item["ParentID"] = ParentID;
            item["LevelDeep"] = LevelDeep;
            item["IDCongViecKPI"] = IDCongViecKPI;
            lstItems.Rows.Add(item);

            LoadForCurItem(lstItems, item, ParentID, LevelDeep);
        }

        private static void LoadForCurItem(DataTable lstItems, DataRow curItem, int ParentID, int LevelDeep)
        {
            int level = ConvertUtility.ToInt32(curItem["LevelDeep"]);
            level++;
            QuanLyCongViecKTXVaPSInfo info = QuanLyCongViecKTXVaPSController.GetInfo(ParentID);
            if (info == null) return;

            DataRow item = lstItems.NewRow();

            item["Ten"] = info.Ten;
            item["ParentID"] = info.ParentID;
            item["LevelDeep"] = level;
            item["IDCongViecKPI"] = info.ID;
            lstItems.Rows.Add(item);

            LoadForCurItem(lstItems, item, info.ParentID, info.LevelDeep);
        }

        protected void LoadZones()
        {
            try
            {
                dropPhongBan.SelectedValue = IDPhongBan.ToString();
                //dropPhong.SelectedValue = IDPhongBan.ToString();
            }
            catch (Exception)
            {
                dropPhongBan.SelectedIndex = -1;
                IDPhongBan = 0;
            }

            DateTime dtTime = new DateTime(ConvertUtility.ToInt32(dropYear.SelectedValue), ConvertUtility.ToInt32(dropMonth.SelectedValue), ConvertUtility.ToInt32(dropDay.SelectedValue));

            DataTable dt = QuanLyCongViecBaoCaoNgayController.GetAllByParentID(0, ConvertUtility.ToInt32(dropTrungTam.SelectedValue), IDPhongBan, dtTime, IDDotDanhGia, CurrentUser.UserID);
            dgrCongViec.DataSource = dt;
            dgrCongViec.DataBind();

            if (dropCongViecKPI.SelectedValue != "0")
            {
                QuanLyCongViecKPIInfo info = QuanLyCongViecKPIController.GetInfo(ConvertUtility.ToInt32(dropCongViecKPI.SelectedValue));
                if (info != null)
                {
                    txtCongViecLon.Text = info.KeHoach;
                    lblFrom.Text = info.NgayBatDau.ToString("dd/MM/yyyy");
                    lblTo.Text = info.NgayKetThuc.ToString("dd/MM/yyyy");
                }
                else
                {
                    cmdEmpty_Click(null, null);
                }
            }
        }

        protected void cmdAdd_Click(object sender, EventArgs e)
        {
            QuanLyCongViecBaoCaoNgayInfo info = new QuanLyCongViecBaoCaoNgayInfo();
            info.IDCongViecKPI = ConvertUtility.ToInt32(dropCongViecKPI.SelectedValue);
            info.Ten = txtName.Text;
            info.KeHoach = txtKeHoach.Text;
            info.ParentID = txtCongViecLon.Text;
            info.TyTrong = 0;// ConvertUtility.ToDouble(txtTyTrong.Text);
            info.KetQua = txtKetqua.Text;
            info.TyLeHoanThanh = dropTyLeHoanThanh.SelectedValue;
            info.IDTrungTam = CurrentUser.IDTrungTam;
            info.IDPhongBan = CurrentUser.IDPhong;
            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.SoGio = ConvertUtility.ToDouble(txtSoGio.Text);
            info.CreateBy = CurrentUser.UserID;
            info.LyDo = txtLyDo.Text;
            info.DeXuat = txtDeXuat.Text;
            info.CreatedOn = new DateTime(ConvertUtility.ToInt32(dropYear.SelectedValue), ConvertUtility.ToInt32(dropMonth.SelectedValue), ConvertUtility.ToInt32(dropDay.SelectedValue));
            try
            {
                QuanLyCongViecBaoCaoNgayController.Insert(info);

                #region Log Action

                LogFileInfo logFileInfo = new LogFileInfo();
                logFileInfo.Log_Action = "Add";
                logFileInfo.Log_Type_Object = "QuanLyCongViecKPITheoNgay";
                logFileInfo.Item_CatID = "Cong Viec Thuong Xuyen";
                logFileInfo.Item_ID = info.ID.ToString();
                logFileInfo.Item_Name = info.Ten;
                logFileInfo.Description_Before = "Old Data: ";
                logFileInfo.Description_After = "Add KPI with info: <br />" + GetObjectInfo(info);
                logFileInfo.UserName = CurrentUser.Username;
                logFileInfo.UserID = CurrentUser.UserID;
                CreateLogFile.LogAction(logFileInfo);

                #endregion

                lblStatusUpdate.Text = MiscUtility.MSG_UPDATE_SUCCESS;

                if (ConvertUtility.ToInt32(dropCongViecKPI.SelectedValue) == 0)
                {
                    //them vao cong viec phat sinh
                    DanhGiaThang_DGCBCNVDanhGiaTTCVInfo infoCVPhatSinh = new DanhGiaThang_DGCBCNVDanhGiaTTCVInfo();

                    infoCVPhatSinh.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
                    infoCVPhatSinh.IDNhanVien = CurrentUser.UserID;
                    infoCVPhatSinh.TenCongViec = txtName.Text;
                    infoCVPhatSinh.TyTrongCV = 0;// ConvertUtility.ToDouble(txtTyTrong.Text);
                    infoCVPhatSinh.SoLieuCamKet = txtKeHoach.Text;
                    infoCVPhatSinh.SoLieuThucHienThucTeTrongThang = txtKetqua.Text;
                    infoCVPhatSinh.NhanVienDanhGiaTyLeHoanThanh = ConvertUtility.ToDouble(dropTyLeHoanThanh.SelectedValue);
                    if (infoCVPhatSinh.NhanVienDanhGiaTyLeHoanThanh > 100)
                    {
                        infoCVPhatSinh.NhanVienDanhGiaTyLeHoanThanh = 100;
                    }

                    if (infoCVPhatSinh.NhanVienDanhGiaTyLeHoanThanh < 0)
                    {
                        infoCVPhatSinh.NhanVienDanhGiaTyLeHoanThanh = 0;
                    }
                    infoCVPhatSinh.YeuCauHoTro = "";
                    infoCVPhatSinh.YKienCuaNhanVien = "";
                    infoCVPhatSinh.YKienCuaTBP = "";
                    infoCVPhatSinh.Loai = 3;
                    infoCVPhatSinh.SoGio = ConvertUtility.ToDouble(txtSoGio.Text);

                    DanhGiaThang_DGCBCNVDanhGiaTTCVController.Insert(infoCVPhatSinh);

                }

            }
            catch (Exception ex)
            {
                lblStatusUpdate.Text = ex.Message;
            }
        }

        protected void cmdEmpty_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtCongViecLon.Text = string.Empty;
            txtKeHoach.Text = string.Empty;
            txtKetqua.Text = string.Empty;
            txtSoGio.Text = string.Empty;
            txtLyDo.Text = string.Empty;
            dropTyLeHoanThanh.SelectedIndex = -1;
            txtDeXuat.Text = string.Empty;
        }

        private void LoadInfo(int id)
        {
            QuanLyCongViecBaoCaoNgayInfo info = QuanLyCongViecBaoCaoNgayController.GetInfo(id);
            if (info == null)
            {
                cmdEmpty_Click(null, null);
                return;
            }

            if (info.CreatedOn.Year != DateTime.Now.Year || info.CreatedOn.Month != DateTime.Now.Month || info.CreatedOn.Day < DateTime.Now.Day)
            {
                txtName.ReadOnly = true;
                txtKeHoach.ReadOnly = true;
                //txtTyTrong.ReadOnly = true;
                txtKetqua.ReadOnly = true;
                txtCongViecLon.ReadOnly = true;
                dropTyLeHoanThanh.Enabled = false;
                txtLyDo.ReadOnly = true;
                txtDeXuat.ReadOnly = true;
                //dropPhong.Enabled = false;
                txtSoGio.ReadOnly = true;
            }
            else
            {
                txtName.ReadOnly = false;
                txtKeHoach.ReadOnly = false;
                //txtTyTrong.ReadOnly = false;
                txtKetqua.ReadOnly = false;
                txtCongViecLon.ReadOnly = true;
                dropTyLeHoanThanh.Enabled = true;
                txtLyDo.ReadOnly = false;
                txtDeXuat.ReadOnly = false;
                //dropPhong.Enabled = true;
                txtSoGio.ReadOnly = false;
            }

            try
            {
                dropCongViecKPI.SelectedValue = info.IDCongViecKPI.ToString();
            }
            catch (Exception)
            {
                dropCongViecKPI.SelectedIndex = 0;
            }

            txtID.Text = info.ID.ToString();
            txtName.Text = info.Ten;
            txtKeHoach.Text = info.KeHoach;
            //txtTyTrong.Text = Math.Round(info.TyTrong, 3).ToString().Replace(".", ",");
            txtKetqua.Text = info.KetQua;
            txtCongViecLon.Text = info.ParentID;

            dropTyLeHoanThanh.SelectedValue = info.TyLeHoanThanh;
            txtLyDo.Text = info.LyDo;
            txtDeXuat.Text = info.DeXuat;
            //try
            //{
            //    dropPhong.SelectedValue = info.IDPhongBan.ToString();
            //}
            //catch (Exception)
            //{
            //    dropPhong.SelectedIndex = -1;
            //}

            try
            {
                txtSoGio.Text = info.SoGio.ToString();
            }
            catch (Exception)
            {
                txtSoGio.Text = "";
            }

            dropYear.SelectedValue = info.CreatedOn.Year.ToString();
            dropMonth.SelectedValue = info.CreatedOn.Month.ToString();
            dropDay.SelectedValue = info.CreatedOn.Day.ToString();
        }

        protected void cmdDel_Click(object sender, EventArgs e)
        {
            try
            {

                QuanLyCongViecBaoCaoNgayController.Delete(ConvertUtility.ToInt32(txtID.Text));

                int ParentID = ConvertUtility.ToInt32(dropCongViecKPI.SelectedValue);
                if (ParentID > 0)
                {
                    QuanLyCongViecBaoCaoNgayInfo info = QuanLyCongViecBaoCaoNgayController.GetInfo(ConvertUtility.ToInt32(txtID.Text));
                    if (info == null)
                    {
                        cmdEmpty_Click(null, null);
                        return;
                    }

                    string oldData = GetObjectInfo(info);

                    #region Log Action

                    LogFileInfo logFileInfo = new LogFileInfo();
                    logFileInfo.Log_Action = "Delete";
                    logFileInfo.Log_Type_Object = "QuanLyCongViecKPITheoNgay";
                    logFileInfo.Item_CatID = "Cong Viec Thuong Xuyen";
                    logFileInfo.Item_ID = info.ID.ToString();
                    logFileInfo.Item_Name = info.Ten;
                    logFileInfo.Description_Before = "Old Data: " + oldData;
                    logFileInfo.Description_After = "Delete KPI with info: <br />" + GetObjectInfo(info);
                    logFileInfo.UserName = CurrentUser.Username;
                    logFileInfo.UserID = CurrentUser.UserID;
                    CreateLogFile.LogAction(logFileInfo);

                    #endregion

                }
            }
            catch (Exception ex)
            {
                lblStatusUpdate.Text = ex.Message;
            }


        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            QuanLyCongViecBaoCaoNgayInfo info = QuanLyCongViecBaoCaoNgayController.GetInfo(ConvertUtility.ToInt32(txtID.Text));
            if (info == null)
            {
                cmdEmpty_Click(null, null);
                return;
            }
            if (info.ID == ConvertUtility.ToInt32(dropCongViecKPI.SelectedValue))
            {
                lblStatusUpdate.Text = "Trung mục cha";
                return;
            }
            string oldData = GetObjectInfo(info);

            info.IDCongViecKPI = ConvertUtility.ToInt32(dropCongViecKPI.SelectedValue);
            info.Ten = txtName.Text;
            info.KeHoach = txtKeHoach.Text;
            info.ParentID = txtCongViecLon.Text;
            info.TyTrong = 0;// ConvertUtility.ToDouble(txtTyTrong.Text);
            info.KetQua = txtKetqua.Text;
            info.TyLeHoanThanh = dropTyLeHoanThanh.SelectedValue;
            info.IDTrungTam = CurrentUser.IDTrungTam;
            info.IDPhongBan = CurrentUser.IDPhong;
            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.SoGio = ConvertUtility.ToDouble(txtSoGio.Text);
            info.CreateBy = CurrentUser.UserID;
            info.LyDo = txtLyDo.Text;
            info.DeXuat = txtDeXuat.Text;
            info.CreatedOn = new DateTime(ConvertUtility.ToInt32(dropYear.SelectedValue), ConvertUtility.ToInt32(dropMonth.SelectedValue), ConvertUtility.ToInt32(dropDay.SelectedValue));
            try
            {
                QuanLyCongViecBaoCaoNgayController.Update(info);

                lblStatusUpdate.Text = MiscUtility.MSG_UPDATE_SUCCESS;

                #region Log Action

                LogFileInfo logFileInfo = new LogFileInfo();
                logFileInfo.Log_Action = "Update";
                logFileInfo.Log_Type_Object = "QuanLyCongViecKPITheoNgay";
                logFileInfo.Item_CatID = "Cong Viec Thuong Xuyen";
                logFileInfo.Item_ID = info.ID.ToString();
                logFileInfo.Item_Name = info.Ten;
                logFileInfo.Description_Before = "Old Data: " + oldData;
                logFileInfo.Description_After = "Update KPI with info: <br />" + GetObjectInfo(info);
                logFileInfo.UserName = CurrentUser.Username;
                logFileInfo.UserID = CurrentUser.UserID;
                CreateLogFile.LogAction(logFileInfo);

                #endregion

                cmdEmpty_Click(null, null);
                //Response.Redirect(AppEnv.AdminUrlParams("baocaongay"));

            }
            catch (Exception ex)
            {
                lblStatusUpdate.Text = ex.Message;
            }
        }

        protected void dgrCongViec_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;

                if (ConvertUtility.ToDouble(dr["TyTrong"]) > 0)
                {
                    tong += ConvertUtility.ToDouble(dr["TyTrong"]);
                }
                if (ConvertUtility.ToDouble(dr["SoGio"]) > 0)
                {
                    tongSoGio += ConvertUtility.ToDouble(dr["SoGio"]);
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTong = (Label)e.Row.FindControl("lblTong");
                Label lblTongSoGio = (Label)e.Row.FindControl("lblTongSoGio");
                lblTong.Text = Math.Round(tong, 3).ToString() + "%";
                lblTongSoGio.Text = Math.Round(tongSoGio, 3).ToString();
            }
        }

        protected void dgrCongViec_RowCommand(object source, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int ID = ConvertUtility.ToInt32(e.CommandArgument);

                zoneSelected = ID;
                LoadInfo(zoneSelected);
            }
            if (e.CommandName == "Delete")
            {
                int ID = ConvertUtility.ToInt32(e.CommandArgument);

                QuanLyCongViecBaoCaoNgayController.Delete(ID);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            LoadZones();
        }

        protected void dropTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropPhongBan.Items.Clear();

            DataTable dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue)); ;
            dropPhongBan.DataSource = dtPhong;
            dropPhongBan.DataBind();
            dropPhongBan.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));

            //dropPhong.Items.Clear();
            //dropPhong.DataSource = dtPhong;
            //dropPhong.DataBind();
            //dropPhong.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));

            zoneSelected = 0;
            lblStatusUpdate.Text = "";

            BuildCongViec();
        }

        protected void dropPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDPhongBan = ConvertUtility.ToInt32(dropPhongBan.SelectedValue);
            zoneSelected = 0;
            lblStatusUpdate.Text = "";
        }

        private string GetObjectInfo(QuanLyCongViecBaoCaoNgayInfo info)
        {
            string returnValue = "";

            #region Bind Old Info

            returnValue += "ID: " + info.ID + " <br />";
            returnValue += "Ten: " + info.Ten + " <br />";
            returnValue += "KeHoach: " + info.KeHoach + " <br />";
            returnValue += "TyTrong: " + info.TyTrong + " <br />";
            returnValue += "SoGio: " + info.SoGio + " <br />";
            returnValue += "ParentID: " + info.ParentID + " <br />";
            returnValue += "TyLeHoanThanh: " + info.TyLeHoanThanh + " <br />";
            returnValue += "KetQua: " + info.KetQua + " <br />";
            returnValue += "IDTrungTam: " + info.IDTrungTam + " <br />";
            returnValue += "IDPhongBan: " + info.IDPhongBan + " <br />";
            returnValue += "DateTime: " + DateTime.Now + " <br />";
            returnValue += "LyDo:" + info.LyDo + " <br />";
            returnValue += "DeXuat:" + info.DeXuat + " <br />";

            #endregion

            return returnValue;
        }

        protected void dropDotDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            zoneSelected = 0;

            BuildCongViec();

        }

        protected void dropMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropMonth.SelectedValue == "0")
            {
                dropDay.Items.Clear();
                dropDay.Items.Add(new ListItem("--All--", "0"));
            }
            else
            {
                BindDay();
            }
        }

        private void BindDay()
        {
            dropDay.Items.Clear();
            int days = DateTime.DaysInMonth(ConvertUtility.ToInt32(dropYear.SelectedValue), ConvertUtility.ToInt32(dropMonth.SelectedValue));

            for (int i = 1; i < days + 1; i++)
            {
                dropDay.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        protected void dropDay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dropMonth1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropMonth.SelectedValue == "0")
            {
                dropDay.Items.Clear();
                dropDay.Items.Add(new ListItem("--All--", "0"));
            }
            else
            {
                BindDay();
            }
        }

        protected void btnCapNhatCVHomTruoc_Click(object sender, EventArgs e)
        {
            DateTime dtTime = new DateTime(ConvertUtility.ToInt32(dropYearCopy.SelectedValue), ConvertUtility.ToInt32(dropMonthCopy.SelectedValue), ConvertUtility.ToInt32(dropDayCopy.SelectedValue));
            DateTime dtTimeNow = new DateTime(ConvertUtility.ToInt32(dropYear.SelectedValue), ConvertUtility.ToInt32(dropMonth.SelectedValue), ConvertUtility.ToInt32(dropDay.SelectedValue));
            DataTable dt = QuanLyCongViecBaoCaoNgayController.GetAllByUserID(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 0, dtTime, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), CurrentUser.UserID);

            foreach (DataRow item in dt.Rows)
            {
                QuanLyCongViecBaoCaoNgayInfo info = new QuanLyCongViecBaoCaoNgayInfo();
                info.IDCongViecKPI = ConvertUtility.ToInt32(item["IDCongViecKPI"]);
                info.Ten = item["Ten"].ToString();
                info.KeHoach = item["KeHoach"].ToString();
                info.ParentID = item["ParentID"].ToString();
                info.TyTrong = ConvertUtility.ToDouble(item["TyTrong"].ToString());
                info.KetQua = item["KetQua"].ToString();
                info.TyLeHoanThanh = item["TyLeHoanThanh"].ToString();
                info.IDTrungTam = ConvertUtility.ToInt32(item["IDTrungTam"].ToString());
                info.IDPhongBan = ConvertUtility.ToInt32(item["IDPhongBan"].ToString());
                info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
                info.SoGio = ConvertUtility.ToDouble(item["SoGio"].ToString());
                info.CreateBy = CurrentUser.UserID;
                info.LyDo = item["LyDo"].ToString();
                info.DeXuat = item["DeXuat"].ToString();
                info.CreatedOn = dtTimeNow;
                try
                {
                    QuanLyCongViecBaoCaoNgayController.Insert(info);

                    #region Log Action

                    LogFileInfo logFileInfo = new LogFileInfo();
                    logFileInfo.Log_Action = "Add";
                    logFileInfo.Log_Type_Object = "QuanLyCongViecKPITheoNgay";
                    logFileInfo.Item_CatID = "Cong Viec Thuong Xuyen";
                    logFileInfo.Item_ID = info.ID.ToString();
                    logFileInfo.Item_Name = info.Ten;
                    logFileInfo.Description_Before = "Old Data: ";
                    logFileInfo.Description_After = "Add KPI with info: <br />" + GetObjectInfo(info);
                    logFileInfo.UserName = CurrentUser.Username;
                    logFileInfo.UserID = CurrentUser.UserID;
                    CreateLogFile.LogAction(logFileInfo);

                    #endregion
                }
                catch (Exception ex)
                {
                    lblStatusUpdate.Text = ex.Message;
                }
            }
        }

        protected void dgrCongViec_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dropCongViecKPI_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dropMonthCopy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropMonthCopy.SelectedValue == "0")
            {
                dropDayCopy.Items.Clear();
                dropDayCopy.Items.Add(new ListItem("--All--", "0"));
            }
            else
            {
                BindDayCopy();
            }
        }
        private void BindDayCopy()
        {
            dropDayCopy.Items.Clear();
            int days = DateTime.DaysInMonth(ConvertUtility.ToInt32(dropYearCopy.SelectedValue), ConvertUtility.ToInt32(dropMonthCopy.SelectedValue));

            for (int i = 1; i < days + 1; i++)
            {
                dropDayCopy.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        protected void dgrCongViec_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}