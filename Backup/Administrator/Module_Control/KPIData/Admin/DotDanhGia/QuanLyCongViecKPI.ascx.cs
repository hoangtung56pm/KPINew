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
using System.Threading;
using System.Globalization;

namespace VmgPortal.Modules.KPIData.Admin.DotDanhGia
{
    public partial class QuanLyCongViecKPI : AuthenticatedControl
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
        private int IDTrungTam
        {
            get
            {
                if (Session["IDTrungTam"] != null) return ConvertUtility.ToInt32(Session["IDTrungTam"]);
                else return 0;
            }
            set { Session["IDTrungTam"] = value; }

        }
        private int IDPhongBan
        {
            get
            {
                return 0;
                //if (ViewState["IDPhongBan"] != null) return (int)ViewState["IDPhongBan"];
                //else return ConvertUtility.ToInt32(dropPhongBan.SelectedValue);
            }
            //set { ViewState["IDPhongBan"] = value; }
        }

        private int IDDotDanhGia
        {
            get
            {
                if (Session["IDDotDanhGia"] != null) return ConvertUtility.ToInt32(Session["IDDotDanhGia"]);
                else return 0;
            }
            set { Session["IDDotDanhGia"] = value; }
        }

        private int selectedparentid = 0;
        double tong = 0;
        double tongSoGio = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cmdDel.OnClientClick = MiscUtility.MSG_DELETE_CONFIRM;
                lblStatusUpdate.Text = string.Empty;

                Session["Nav"] = "1";

                dropDotDanhGiaCopy.DataSource = DotDanhGiaController.GetAll(1);
                dropDotDanhGiaCopy.DataBind();
            }


        }

        protected void LoadZones()
        {

            //try
            //{
            //    dropPhongBan.SelectedValue = IDPhongBan.ToString();
            //    dropPhong.SelectedValue = IDPhongBan.ToString();
            //}
            //catch (Exception)
            //{
            //    dropPhongBan.SelectedIndex = -1;
            //    IDPhongBan = 0;
            //}

            lstCongViec.Items.Clear();
            QuanLyCongViecKTXVaPSController.LoadCongViec(lstCongViec.Items, ConvertUtility.ToInt32(dropTrungTam.SelectedValue), IDPhongBan, 1, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));
            lstCongViec.Items.Insert(0, new ListItem("Root", "0"));

            dropCongViecKPI.Items.Clear();
            foreach (ListItem item in lstCongViec.Items)
            {
                dropCongViecKPI.Items.Add(new ListItem(item.Text, item.Value));
            }
            MiscUtility.SelectItemFromList(lstCongViec, zoneSelected.ToString());

            DataTable dt = QuanLyCongViecKTXVaPSController.GetAllByParentIDNew(zoneSelected, ConvertUtility.ToInt32(dropTrungTam.SelectedValue), IDPhongBan, 1, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));
            dgrCongViec.DataSource = dt;
            dgrCongViec.DataBind();
            LoadInfo(zoneSelected);
        }

        protected void lstCongViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            zoneSelected = ConvertUtility.ToInt32(lstCongViec.SelectedValue);
            Session["Nav"] = "1";
        }

        protected void cmdAdd_Click(object sender, EventArgs e)
        {
            QuanLyCongViecKTXVaPSInfo info = new QuanLyCongViecKTXVaPSInfo();
            info.Ten = txtName.Text;
            info.ParentID = ConvertUtility.ToInt32(dropCongViecKPI.SelectedValue);
            info.TyTrong = ConvertUtility.ToDouble(txtTyTrong.Text);
            info.KeHoach = txtKeHoach.Text;
            info.IDTrungTam = ConvertUtility.ToInt32(dropTrungTam.SelectedValue);
            info.DonViDo = txtDonViDo.Text;
            info.IDPhongBan = 0;// ConvertUtility.ToInt32(dropPhong.SelectedValue);
            info.Loai = 1;
            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            info.SoGio = ConvertUtility.ToDouble(txtSoGio.Text);
            info.IsKPI = ConvertUtility.ToInt32(dropKPIBoPhan.SelectedValue);
            info.NgayBatDau = ConvertUtility.ToDateTime(dtFrom.Text);
            info.NgayKetThuc = ConvertUtility.ToDateTime(dtTo.Text);
            info.IDNhomCongViec = ConvertUtility.ToInt32(dropMaNhom.SelectedValue);
            info.TrangThaiCV = ConvertUtility.ToInt32(dropTrangThai.SelectedValue);

            DateConverter objDate = new DateConverter();

            int tuanBD = objDate.GetWeekOfMonth(info.NgayBatDau);
            int tuanKT = objDate.GetWeekOfMonth(info.NgayKetThuc);

            string tuanLV = "";
            for (int i = tuanBD; i <= tuanKT; i++)
            {
                tuanLV += i + ",";
            }
            info.TuanLamViec = tuanLV.Substring(0, tuanLV.Length - 1);

            try
            {
                QuanLyCongViecKTXVaPSController.Insert(info);

                #region Log Action

                LogFileInfo logFileInfo = new LogFileInfo();
                logFileInfo.Log_Action = "Add";
                logFileInfo.Log_Type_Object = "QuanLyCongViecKPI";
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

                UpdateCapDoCongViec();

                cmdEmpty_Click(null, null);
            }
            catch (Exception ex)
            {
                lblStatusUpdate.Text = ex.Message;
            }
            Session["Nav"] = "1";
        }

        protected void cmdEmpty_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtTyTrong.Text = string.Empty;
            txtSoGio.Text = string.Empty;
            txtKeHoach.Text = string.Empty;
            txtDonViDo.Text = string.Empty;
            Session["Nav"] = "1";
        }

        private void LoadInfo(int id)
        {
            QuanLyCongViecKTXVaPSInfo info = QuanLyCongViecKTXVaPSController.GetInfo(id);
            if (info == null)
            {
                cmdEmpty_Click(null, null);
                return;
            }
            txtID.Text = info.ID.ToString();
            txtName.Text = info.Ten;
            txtTyTrong.Text = Math.Round(info.TyTrong, 3).ToString();
            txtKeHoach.Text = info.KeHoach;
            dropCongViecKPI.SelectedValue = info.ParentID.ToString();
            txtDonViDo.Text = info.DonViDo;
            selectedparentid = info.ParentID;
            lblTuanLV.Text = info.TuanLamViec;
            try
            {
                dropMaNhom.SelectedValue = info.IDNhomCongViec.ToString();
            }
            catch (Exception)
            {
                dropMaNhom.SelectedIndex = -1;
            }

            try
            {
                dropTrangThai.SelectedValue = info.TrangThaiCV.ToString();
            }
            catch (Exception)
            {
                dropTrangThai.SelectedIndex = -1;
            }

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
            try
            {
                dropKPIBoPhan.SelectedValue = info.IsKPI.ToString();
            }
            catch (Exception)
            {
                dropKPIBoPhan.SelectedValue = "1";
            }

            try
            {
                dtFrom.Text = info.NgayBatDau.ToShortDateString();
            }
            catch (Exception)
            {
                dtFrom.Text = DateTime.Now.ToShortDateString();
            }

            try
            {
                dtTo.Text = info.NgayKetThuc.ToShortDateString();
            }
            catch (Exception)
            {
                dtTo.Text = DateTime.Now.ToShortDateString();
            }
        }

        protected void cmdDel_Click(object sender, EventArgs e)
        {
            try
            {
                QuanLyCongViecKTXVaPSInfo info = QuanLyCongViecKTXVaPSController.GetInfo(ConvertUtility.ToInt32(txtID.Text));
                if (info == null)
                {
                    cmdEmpty_Click(null, null);
                    return;
                }

                QuanLyCongViecKTXVaPSController.Delete(ConvertUtility.ToInt32(txtID.Text), ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

                int ParentID = ConvertUtility.ToInt32(dropCongViecKPI.SelectedValue);
                if (ParentID > 0)
                {
                    UpdateTyTrongCongViecCha(ParentID, info.IsKPI);

                    string oldData = GetObjectInfo(info);

                    #region Log Action

                    LogFileInfo logFileInfo = new LogFileInfo();
                    logFileInfo.Log_Action = "Delete";
                    logFileInfo.Log_Type_Object = "QuanLyCongViecKPI";
                    logFileInfo.Item_CatID = "Cong Viec Thuong Xuyen";
                    logFileInfo.Item_ID = info.ID.ToString();
                    logFileInfo.Item_Name = info.Ten;
                    logFileInfo.Description_Before = "Old Data: " + oldData;
                    logFileInfo.Description_After = "Delete KPI with info: <br />" + GetObjectInfo(info);
                    logFileInfo.UserName = CurrentUser.Username;
                    logFileInfo.UserID = CurrentUser.UserID;
                    CreateLogFile.LogAction(logFileInfo);

                    #endregion

                    UpdateCapDoCongViec();
                }
            }
            catch (Exception ex)
            {
                lblStatusUpdate.Text = ex.Message;
            }

            Session["Nav"] = "1";

        }

        void UpdateCapDoCongViec()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Ten", typeof(string));
            dt.Columns.Add("TyTrong", typeof(string));
            dt.Columns.Add("SoGio", typeof(string));
            dt.Columns.Add("KeHoach", typeof(string));
            dt.Columns.Add("DonViDo", typeof(string));
            dt.Columns.Add("Level", typeof(string));
            dt.Columns.Add("Bold", typeof(string));
            dt.Columns.Add("Ma", typeof(string));
            DataTable source = QuanLyCongViecKTXVaPSController.LoadCongViecForExport(dt, ConvertUtility.ToInt32(dropTrungTam.SelectedValue), IDPhongBan, 1, IDDotDanhGia);

            foreach (DataRow item in source.Rows)
            {
                int level = ConvertUtility.ToInt32(item["Level"]);
                int idCongViec = ConvertUtility.ToInt32(item["ID"]);
                QuanLyCongViecKTXVaPSController.UpdateCapDoCongViec(idCongViec, level);
            }
        }

        void UpdateCapDoCongViec(int idTrungTam, int idDotDanhGia)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Ten", typeof(string));
            dt.Columns.Add("TyTrong", typeof(string));
            dt.Columns.Add("SoGio", typeof(string));
            dt.Columns.Add("KeHoach", typeof(string));
            dt.Columns.Add("DonViDo", typeof(string));
            dt.Columns.Add("Level", typeof(string));
            dt.Columns.Add("Bold", typeof(string));
            dt.Columns.Add("Ma", typeof(string));

            DataTable source = QuanLyCongViecKTXVaPSController.LoadCongViecForExport(dt, idTrungTam, 0, 1, idDotDanhGia);

            foreach (DataRow item in source.Rows)
            {
                int level = ConvertUtility.ToInt32(item["Level"]);
                int idCongViec = ConvertUtility.ToInt32(item["ID"]);
                QuanLyCongViecKTXVaPSController.UpdateCapDoCongViec(idCongViec, level);
            }
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            QuanLyCongViecKTXVaPSInfo info = QuanLyCongViecKTXVaPSController.GetInfo(ConvertUtility.ToInt32(txtID.Text));
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

            info.Ten = txtName.Text;
            info.ParentID = ConvertUtility.ToInt32(dropCongViecKPI.SelectedValue);
            info.TyTrong = ConvertUtility.ToDouble(txtTyTrong.Text);
            info.IDTrungTam = ConvertUtility.ToInt32(dropTrungTam.SelectedValue);
            info.KeHoach = txtKeHoach.Text;
            info.DonViDo = txtDonViDo.Text;
            info.IDPhongBan = 0;//ConvertUtility.ToInt32(dropPhong.SelectedValue);
            info.Loai = 1;
            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue); ;
            info.SoGio = ConvertUtility.ToDouble(txtSoGio.Text);
            info.IsKPI = ConvertUtility.ToInt32(dropKPIBoPhan.SelectedValue);

            info.NgayBatDau = ConvertUtility.ToDateTime(dtFrom.Text.ToString());
            info.NgayKetThuc = ConvertUtility.ToDateTime(dtTo.Text);

            info.IDNhomCongViec = ConvertUtility.ToInt32(dropMaNhom.SelectedValue);
            info.TrangThaiCV = ConvertUtility.ToInt32(dropTrangThai.SelectedValue);

            DateConverter objDate = new DateConverter();

            int tuanBD = objDate.GetWeekOfMonth(info.NgayBatDau);
            int tuanKT = objDate.GetWeekOfMonth(info.NgayKetThuc);

            string tuanLV = "";
            for (int i = tuanBD; i <= tuanKT; i++)
            {
                tuanLV += i + ",";
            }
            info.TuanLamViec = tuanLV.Substring(0, tuanLV.Length - 1);
            try
            {
                QuanLyCongViecKTXVaPSController.Update(info);

                lblStatusUpdate.Text = MiscUtility.MSG_UPDATE_SUCCESS;

                #region Log Action

                LogFileInfo logFileInfo = new LogFileInfo();
                logFileInfo.Log_Action = "Update";
                logFileInfo.Log_Type_Object = "QuanLyCongViecKPI";
                logFileInfo.Item_CatID = "Cong Viec Thuong Xuyen";
                logFileInfo.Item_ID = info.ID.ToString();
                logFileInfo.Item_Name = info.Ten;
                logFileInfo.Description_Before = "Old Data: " + oldData;
                logFileInfo.Description_After = "Update KPI with info: <br />" + GetObjectInfo(info);
                logFileInfo.UserName = CurrentUser.Username;
                logFileInfo.UserID = CurrentUser.UserID;
                CreateLogFile.LogAction(logFileInfo);

                #endregion

                UpdateCapDoCongViec();
            }
            catch (Exception ex)
            {
                lblStatusUpdate.Text = ex.Message;
            }
            Session["Nav"] = "1";
        }

        private void UpdateTyTrongCongViecCha(int parentId, int isKPI)
        {
            //if (parentId == 0) return;

            //DataTable dtTyTrongKPI = DotDanhGiaController.GetTongTyTrongCacCongViecCon(parentId);

            //if (dtTyTrongKPI != null && dtTyTrongKPI.Rows.Count > 0)
            //{
            //    double tong = ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TongTyTrong"]);
            //    double tongSoGio = ConvertUtility.ToDouble(dtTyTrongKPI.Rows[0]["TongSoGio"]);

            //    QuanLyCongViecKTXVaPSInfo infoCVCha = QuanLyCongViecKTXVaPSController.GetInfo(parentId);

            //    infoCVCha.TyTrong = tong;
            //    infoCVCha.SoGio = tongSoGio;
            //    infoCVCha.IsKPI = isKPI;

            //    QuanLyCongViecKTXVaPSController.Update(infoCVCha);

            //    UpdateTyTrongCongViecCha(infoCVCha.ParentID, isKPI);
            //}
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

                Button cmdDel = (Button)e.Row.FindControl("cmdDelete");
                cmdDel.OnClientClick = MiscUtility.MSG_DELETE_CONFIRM;
            }
        }

        protected void dgrCongViec_RowCommand(object source, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                try
                {
                    int id = ConvertUtility.ToInt32(e.CommandArgument);

                    QuanLyCongViecKTXVaPSInfo info = QuanLyCongViecKTXVaPSController.GetInfo(id);
                    if (info == null)
                    {
                        cmdEmpty_Click(null, null);
                        return;
                    }

                    QuanLyCongViecKTXVaPSController.Delete(id, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

                    int ParentID = ConvertUtility.ToInt32(dropCongViecKPI.SelectedValue);
                    if (ParentID > 0)
                    {
                        UpdateTyTrongCongViecCha(ParentID, info.IsKPI);

                        string oldData = GetObjectInfo(info);

                        #region Log Action

                        LogFileInfo logFileInfo = new LogFileInfo();
                        logFileInfo.Log_Action = "Delete";
                        logFileInfo.Log_Type_Object = "QuanLyCongViecKPI";
                        logFileInfo.Item_CatID = "Cong Viec Thuong Xuyen";
                        logFileInfo.Item_ID = info.ID.ToString();
                        logFileInfo.Item_Name = info.Ten;
                        logFileInfo.Description_Before = "Old Data: " + oldData;
                        logFileInfo.Description_After = "Delete KPI with info: <br />" + GetObjectInfo(info);
                        logFileInfo.UserName = CurrentUser.Username;
                        logFileInfo.UserID = CurrentUser.UserID;
                        CreateLogFile.LogAction(logFileInfo);

                        #endregion

                        UpdateCapDoCongViec();
                    }

                    lblStatusUpdate.Text = MiscUtility.MSG_UPDATE_SUCCESS;
                }
                catch (Exception ex)
                {
                    lblStatusUpdate.Text = ex.Message;
                }
            }
            Session["Nav"] = "1";
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
            //#region Get Phong Ban

            //DataTable dtPhong;
            if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
            {
                dropTrungTam.Enabled = false;
            }
            //    if (CurrentUser.RoleID == (int)Constants.Role.NhanVien)
            //    {
            //        #region Role Nhan Vien

            //        dropPhongBan.Enabled = false;
            //        dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            //        dropPhongBan.Items.Clear();
            //        dropPhongBan.DataSource = dtPhong;
            //        dropPhongBan.DataBind();
            //        dropPhongBan.Items.Insert(0, new ListItem("Tất cả", "0"));

            //        try
            //        {
            //            dropPhongBan.SelectedValue = CurrentUser.IDPhong.ToString();
            //        }
            //        catch (Exception)
            //        {
            //            dropPhongBan.SelectedIndex = -1;
            //        }

            //        #endregion
            //    }
            //    else
            //    {
            //        if (CurrentUser.RoleID == (int)Constants.Role.COO || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiHoTro || CurrentUser.RoleID == (int)Constants.Role.TruongBoPhanKhoiKinhDoanh || CurrentUser.RoleID == (int)Constants.Role.PhoGiamDoc)
            //        {
            //            #region Role TBP, Pho Giam Doc, COO

            //            dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            //            dropPhongBan.Items.Clear();
            //            dropPhongBan.DataSource = dtPhong;
            //            dropPhongBan.DataBind();
            //            dropPhongBan.Items.Insert(0, new ListItem("Tất cả", "0"));

            //            #endregion
            //        }
            //        else
            //        {
            //            #region Role Pho Phong, Truong Phong, Truong Nhom

            //            dropPhongBan.Enabled = false;
            //            dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), CurrentUser.UserID);
            //            dropPhongBan.Items.Clear();
            //            dropPhongBan.DataSource = dtPhong;
            //            dropPhongBan.DataBind();
            //            dropPhongBan.Items.Insert(0, new ListItem("Tất cả", "0"));

            //            #endregion
            //        }
            //    }
            //}
            //else
            //{
            //    #region Role Admin

            //    dropTrungTam.Enabled = true;
            //    dropPhongBan.Enabled = true;

            //    dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
            //    dropPhongBan.Items.Clear();
            //    dropPhongBan.DataSource = dtPhong;
            //    dropPhongBan.DataBind();
            //    dropPhongBan.Items.Insert(0, new ListItem("Tất cả", "0"));

            //    try
            //    {
            //        dropPhongBan.SelectedValue = CurrentUser.IDPhong.ToString();
            //    }
            //    catch (Exception)
            //    {
            //        dropPhongBan.SelectedIndex = -1;
            //    }

            //    #endregion
            //}

            //#endregion

            DataTable dtNhomCongViec = DotDanhGiaController.GetAllMaNhomCongViec(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));

            dropMaNhom.DataSource = dtNhomCongViec;
            dropMaNhom.DataBind();

            //dropPhong.DataSource = dtPhong;
            //dropPhong.DataBind();
            //dropPhong.Items.Insert(0, new ListItem("Tất cả", "0"));

            LoadZones();

            btnDelete.OnClientClick = "return window.confirm('Bạn chắc chắn xóa toàn bộ công việc của đợt đánh giá \"" + dropDotDanhGia.SelectedItem.Text + "\" này không ?')";
            btnImport.OnClientClick = "return window.confirm('Bạn chắc chắn import toàn bộ công việc từ file excel cho đợt đánh giá \"" + dropDotDanhGia.SelectedItem.Text + "\" và toàn bộ dữ liệu của đợt đánh giá này sẽ bị xóa không ?')";
            btnLayCongViecThangTruoc.OnClientClick = "return window.confirm('Bạn chắc chắn copy toàn bộ công việc của đợt đánh giá \"" + dropDotDanhGiaCopy.SelectedItem.Text + "\" cho đợt đánh giá \"" + dropDotDanhGia.SelectedItem.Text + "\" và toàn bộ dữ liệu của đợt đánh giá này sẽ bị xóa không ?')";
        }

        protected void dropTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dropPhongBan.Items.Clear();

            //DataTable dtPhong = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue)); ;
            //dropPhongBan.DataSource = dtPhong;
            //dropPhongBan.DataBind();
            //dropPhongBan.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));

            //dropPhong.Items.Clear();
            //dropPhong.DataSource = dtPhong;
            //dropPhong.DataBind();
            //dropPhong.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));

            zoneSelected = 0;
            lblStatusUpdate.Text = "";

            //dropMaNhom.Items.Clear();
            //DataTable dtNhomCongViec = DotDanhGiaController.GetAllMaNhomCongViec(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));

            //dropMaNhom.DataSource = dtNhomCongViec;
            //dropMaNhom.DataBind();

            IDTrungTam = ConvertUtility.ToInt32(dropTrungTam.SelectedValue);
            Session["Nav"] = "1";
        }

        //protected void dropPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //IDPhongBan = ConvertUtility.ToInt32(dropPhongBan.SelectedValue);
        //    zoneSelected = 0;
        //    lblStatusUpdate.Text = "";

        //    zoneSelected = 0;
        //    Session["Nav"] = "1";
        //}

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Ten", typeof(string));
            dt.Columns.Add("TyTrong", typeof(string));
            dt.Columns.Add("SoGio", typeof(string));
            dt.Columns.Add("KeHoach", typeof(string));
            dt.Columns.Add("DonViDo", typeof(string));
            dt.Columns.Add("Level", typeof(string));
            dt.Columns.Add("Bold", typeof(string));
            dt.Columns.Add("Ma", typeof(string));
            DataTable source = QuanLyCongViecKTXVaPSController.LoadCongViecForExport(dt, ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 0, 1, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

            XmlDocument doc = BuildXmlDocument(source);

            if (!Directory.Exists(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/")))
            {
                Directory.CreateDirectory(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/"));
            }
            //ds.Dispose();
            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            FileStream downloadFile =
                File.Create(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/") + "Report_" + datetime +
                            ".xls");

            // transform
            XslTransform xsl = new XslTransform();
            xsl.Load(Server.MapPath("/Template/" + "Report.xsl"));

            DateConverter objDateConverter = new DateConverter();
            XsltArgumentList args = new XsltArgumentList();
            args.AddExtensionObject("urn:ms-kb", objDateConverter);

            xsl.Transform(doc, args, downloadFile, null);
            downloadFile.Flush();
            downloadFile.Close();

            hplDownload.Text = "Hãy click vào liên kết này để Tải file về";

            hplDownload.NavigateUrl = "/UpLoad/Temp/" + CurrentUser.UserID + "/Report_" + datetime + ".xls";
            Session["Nav"] = "1";
        }

        private XmlDocument BuildXmlDocument(DataTable source)
        {
            XmlDocument _XMLDoc = new XmlDocument();

            string xml = DateConverter.ConvertDataTableToXML(source);

            _XMLDoc.LoadXml(xml);

            return _XMLDoc;
        }

        private string GetObjectInfo(QuanLyCongViecKTXVaPSInfo info)
        {
            string returnValue = "";

            #region Bind Old Info

            returnValue += "ID: " + info.ID + " <br />";
            returnValue += "Ten: " + info.Ten + " <br />";
            returnValue += "TyTrong: " + info.TyTrong + " <br />";
            returnValue += "SoGio: " + info.SoGio + " <br />";
            returnValue += "ParentID: " + info.ParentID + " <br />";
            returnValue += "Priority: " + info.Priority + " <br />";
            returnValue += "KeHoach: " + info.KeHoach + " <br />";
            returnValue += "DonViDo: " + info.DonViDo + " <br />";
            returnValue += "IDTrungTam: " + info.IDTrungTam + " <br />";
            returnValue += "IDPhongBan: " + info.IDPhongBan + " <br />";
            returnValue += "DateTime: " + DateTime.Now + " <br />";
            returnValue += "IsKPI:" + info.IsKPI;
            returnValue += "NgayBatDau:" + info.NgayBatDau;
            returnValue += "NgayKetThuc:" + info.NgayKetThuc;

            #endregion

            return returnValue;
        }

        protected void dropDotDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            zoneSelected = 0;
            IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
            Session["Nav"] = "1";
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            if (fileImport.HasFile)
            {
                if (!Directory.Exists(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/")))
                {
                    Directory.CreateDirectory(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/"));
                }

                string ext = ".xls";

                if (fileImport.FileName.IndexOf(".xlsx") > 0)
                {
                    ext = ".xlsx";
                }
                fileImport.PostedFile.SaveAs(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/") + fileImport.FileName.Replace(ext, "") + "_Temp" + ext);

                string path = Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/") + fileImport.FileName.Replace(ext, "") + "_Temp" + ext;

                if (File.Exists(path))
                {
                    DataTable returnTable = ImportExcelToDataTable.ImportExcel(path);

                    if (returnTable != null && returnTable.Rows.Count > 0)
                    {
                        if (chkDeleteAll.Checked)
                        {
                            QuanLyCongViecKTXVaPSController.DeleteAll(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 1, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));
                        }

                        for (int i = 0; i < returnTable.Rows.Count; i++)
                        {
                            try
                            {
                                DataRow row = returnTable.Rows[i];

                                #region Import

                                QuanLyCongViecKTXVaPSInfo info = new QuanLyCongViecKTXVaPSInfo();
                                info.Ten = row[0].ToString();
                                info.ParentID = 0;
                                info.TyTrong = 0;
                                info.KeHoach = "";
                                info.IDTrungTam = ConvertUtility.ToInt32(dropTrungTam.SelectedValue);
                                info.DonViDo = "";
                                info.IDPhongBan = 0;//ConvertUtility.ToInt32(dropPhong.SelectedValue);
                                info.Loai = 1;
                                info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
                                info.SoGio = 0;
                                info.IsKPI = 1;
                                info.NgayBatDau = DateTime.Now;
                                info.NgayKetThuc = DateTime.Now;
                                info.IDNhomCongViec = 1;
                                info.TrangThaiCV = 2;
                                info.TuanLamViec = "1,2,3,4,5";

                                QuanLyCongViecKTXVaPSController.Insert(info);

                                info = new QuanLyCongViecKTXVaPSInfo();
                                info.Ten = row[1].ToString();
                                int parentID = GetParentID(row[0].ToString(), ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
                                info.ParentID = parentID;
                                info.TyTrong = 0;
                                info.KeHoach = ConvertUtility.ToString(row[3].ToString());
                                info.IDTrungTam = ConvertUtility.ToInt32(dropTrungTam.SelectedValue);
                                info.DonViDo = "";
                                info.IDPhongBan = 0;//ConvertUtility.ToInt32(dropPhong.SelectedValue);
                                info.Loai = 1;
                                info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
                                info.SoGio = ConvertUtility.ToDouble(row[2].ToString());
                                info.IsKPI = 1;
                                info.NgayBatDau = DateTime.Now;
                                info.NgayKetThuc = DateTime.Now;
                                info.IDNhomCongViec = 1;
                                info.TrangThaiCV = 2;
                                info.TuanLamViec = ConvertUtility.ToString(row[4].ToString());

                                QuanLyCongViecKTXVaPSController.Insert(info);

                                if (info.ParentID > 0)
                                {
                                    UpdateCapDoCongViec();
                                }

                                #endregion
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    lblStatusUpdate.Text = GetLocalResourceObject("lblUpdateStatusResource4.Text").ToString();
                }
            }
            Session["Nav"] = "1";
        }

        private int GetParentID(string tencongvieccha, int idDotDanhGia, int idTrungTam)
        {
            QuanLyCongViecKTXVaPSInfo info = QuanLyCongViecKTXVaPSController.GetInfoByTen(tencongvieccha, idDotDanhGia, idTrungTam, 1);

            if (info != null)
            {
                return info.ID;
            }
            return 0;
        }

        protected void btnLayCongViecThangTruoc_Click(object sender, EventArgs e)
        {
            QuanLyCongViecKTXVaPSController.ClearAllCongViecTheoBoPhanVaDotDanhGia(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 1);

            #region Copy cong viec thuong xuyen cua thang truoc

            DataTable dt = new DataTable();

            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Ten", typeof(string));
            dt.Columns.Add("TyTrong", typeof(string));
            dt.Columns.Add("SoGio", typeof(string));
            dt.Columns.Add("ParentID", typeof(string));
            dt.Columns.Add("Priority", typeof(string));
            dt.Columns.Add("KeHoach", typeof(string));
            dt.Columns.Add("DonViDo", typeof(string));
            dt.Columns.Add("IDTrungTam", typeof(string));
            dt.Columns.Add("IDPhongBan", typeof(string));
            dt.Columns.Add("Loai", typeof(string));
            dt.Columns.Add("IDDotDanhGia", typeof(string));
            dt.Columns.Add("LevelDeep", typeof(string));
            dt.Columns.Add("NgayBatDau", typeof(string));
            dt.Columns.Add("NgayKetThuc", typeof(string));
            dt.Columns.Add("TrangThaiCV", typeof(string));
            dt.Columns.Add("TuanLamViec", typeof(string));
            dt.Columns.Add("IDNhomCongViec", typeof(string));
            DataTable source = QuanLyCongViecKTXVaPSController.LoadCongViecForCopyNew(dt, ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 0, 1, ConvertUtility.ToInt32(dropDotDanhGiaCopy.SelectedValue));

            DataRow[] row = source.Select("ParentID=0");
            int parentId = 0;
            foreach (DataRow item in row)
            {
                QuanLyCongViecKTXVaPSInfo info = new QuanLyCongViecKTXVaPSInfo();

                info.Ten = ConvertUtility.ToString(item["Ten"]);
                info.TyTrong = ConvertUtility.ToDouble(item["TyTrong"]);
                info.SoGio = ConvertUtility.ToDouble(item["SoGio"]);
                info.ParentID = 0;
                info.Priority = ConvertUtility.ToInt32(item["Priority"]);
                info.KeHoach = ConvertUtility.ToString(item["KeHoach"]);
                info.DonViDo = ConvertUtility.ToString(item["DonViDo"]);
                info.IDTrungTam = ConvertUtility.ToInt32(item["IDTrungTam"]);
                info.IDPhongBan = ConvertUtility.ToInt32(item["IDPhongBan"]);
                info.Loai = ConvertUtility.ToInt32(item["Loai"]);
                info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
                info.LevelDeep = ConvertUtility.ToInt32(item["LevelDeep"]);
                info.NgayBatDau = ConvertUtility.ToDateTime(item["NgayBatDau"]).AddMonths(1);
                info.NgayKetThuc = ConvertUtility.ToDateTime(item["NgayKetThuc"]).AddMonths(1);
                info.TrangThaiCV = ConvertUtility.ToInt32(item["TrangThaiCV"]);
                info.TuanLamViec = ConvertUtility.ToString(item["TuanLamViec"]);
                info.IDNhomCongViec = ConvertUtility.ToInt32(item["IDNhomCongViec"]);
                if (ConvertUtility.ToInt32(item["ID"]) == 31279)
                {
                    string a = "a";
                }
                info.OldID = ConvertUtility.ToInt32(item["ID"]);

                try
                {
                    parentId = QuanLyCongViecKTXVaPSController.Insert_6_11_2014(info);

                    #region Log Action

                    LogFileInfo logFileInfo = new LogFileInfo();
                    logFileInfo.Log_Action = "Add";
                    logFileInfo.Log_Type_Object = "QuanLyCongViecKPI";
                    logFileInfo.Item_CatID = "Cong Viec thuong xuyen";
                    logFileInfo.Item_ID = info.ID.ToString();
                    logFileInfo.Item_Name = info.Ten;
                    logFileInfo.Description_Before = "Old Data: ";
                    logFileInfo.Description_After = "Add KPI with info: <br />" + GetObjectInfo(info);
                    logFileInfo.UserName = CurrentUser.Username;
                    logFileInfo.UserID = CurrentUser.UserID;
                    CreateLogFile.LogAction(logFileInfo);

                    #endregion

                    InsertCongViecCon(source, item, parentId, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

                    lblStatusUpdate.Text = MiscUtility.MSG_UPDATE_SUCCESS;

                }
                catch (Exception ex)
                {
                    lblStatusUpdate.Text = ex.Message;
                }
            }

            UpdateCapDoCongViec(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));

            #endregion

            #region Lay cac nhan vien va cac cong viec duoc giao thang truoc --> thuc hien giao viec

            //lay tat ca nhan vien cua trung tam
            DataTable dtNhanVien = DotDanhGiaController.GetAllNhanVienTemp(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 0);

            foreach (DataRow item in dtNhanVien.Rows)
            {
                try
                {
                    string[] array = item["UserID"].ToString().Split('_');
                    int idNhanVien = ConvertUtility.ToInt32(array[0]);
                    int idBoPhan = ConvertUtility.ToInt32(array[2]);

                    DataSet ds = DotDanhGiaController.GetPTDG(idNhanVien, ConvertUtility.ToInt32(item["IDPhong"]));

                    DataTable dtNDG = ds.Tables[0];

                    int idNguoiDanhGia = 0;
                    if (dtNDG != null && dtNDG.Rows.Count > 0)
                    {
                        idNguoiDanhGia = ConvertUtility.ToInt32(dtNDG.Rows[0]["IDNguoiDG"]);
                    }

                    DotDanhGiaController.UpdateNhanVienVaoDotDanhGia(ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), idNhanVien, ConvertUtility.ToInt32(array[2]), ConvertUtility.ToInt32(array[1]), idNguoiDanhGia, 0);

                    #region Update cong viec cho nhan vien theo thang

                    DataTable dtCongViec = DotDanhGiaController.GetAllCongViecGiaoChoNhanVienKTXVaPS_6_11_2014(idNhanVien, 1, ConvertUtility.ToInt32(dropDotDanhGiaCopy.SelectedValue));

                    if (dtCongViec != null && dtCongViec.Rows.Count > 0)
                    {
                        foreach (DataRow rowCV in dtCongViec.Rows)
                        {
                            DanhGiaThang_DGCBCNVDanhGiaTTCVInfo info = new DanhGiaThang_DGCBCNVDanhGiaTTCVInfo();

                            info.IDDotDanhGia = ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue);
                            info.IDNhanVien = idNhanVien;
                            info.TenCongViec = ConvertUtility.ToString(rowCV["Ten"]);
                            int idCongViecKPI = ConvertUtility.ToInt32(rowCV["IDCongViecKPI"]);

                            QuanLyCongViecKTXVaPSInfo infoCongViecKPI = QuanLyCongViecKTXVaPSController.GetInfoByOldID(idCongViecKPI);

                            if (infoCongViecKPI != null)
                            {
                                info.IDBoPhan = ConvertUtility.ToInt32(rowCV["IDBoPhan"]);
                                info.IDPhongBan = ConvertUtility.ToInt32(rowCV["IDPhongBan"]);
                                info.TyTrongCV = Math.Round(ConvertUtility.ToDouble(rowCV["TyTrong"]), 2);
                                info.SoGio = Math.Round(ConvertUtility.ToDouble(rowCV["SoGio"]), 2);

                                DotDanhGiaController.UpdateCongViecChoNhanVien(idNhanVien, infoCongViecKPI.ID, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue), info.IDBoPhan, info.IDPhongBan, info.TyTrongCV, info.SoGio);

                                info.SoLieuCamKet = ConvertUtility.ToString(rowCV["KeHoach"]);
                                info.YeuCauHoTro = "";
                                info.Loai = 1;
                                info.IDCongViec = infoCongViecKPI.ID;
                                info.IDBoPhanHoTro = 0;
                                info.IDBoPhan = ConvertUtility.ToInt32(rowCV["IDBoPhan"]);
                                info.IDPhongBan = ConvertUtility.ToInt32(rowCV["IDPhongBan"]);
                                info.NgayBatDau = ConvertUtility.ToDateTime(rowCV["NgayBatDau"]).AddMonths(1);
                                info.NgayKetThuc = ConvertUtility.ToDateTime(rowCV["NgayKetThuc"]).AddMonths(1);

                                DanhGiaThang_DGCBCNVDanhGiaTTCVController.InsertKeHoachThang(info);
                            }
                        }
                    }

                    #endregion

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            #endregion
            Session["Nav"] = "1";
        }

        private void InsertCongViecCon(DataTable source, DataRow curItem, int parentId, int idDotDanhGia)
        {

            DataRow[] rowChild = source.Select("ParentID='" + ConvertUtility.ToInt32(curItem["ID"]) + "'");

            if (rowChild.Length > 0)
            {
                foreach (DataRow itemChild in rowChild)
                {
                    QuanLyCongViecKTXVaPSInfo info = new QuanLyCongViecKTXVaPSInfo();

                    info.Ten = ConvertUtility.ToString(itemChild["Ten"]);
                    info.TyTrong = ConvertUtility.ToDouble(itemChild["TyTrong"]);
                    info.SoGio = ConvertUtility.ToDouble(itemChild["SoGio"]);
                    info.ParentID = parentId;
                    info.Priority = ConvertUtility.ToInt32(itemChild["Priority"]);
                    info.KeHoach = ConvertUtility.ToString(itemChild["KeHoach"]);
                    info.DonViDo = ConvertUtility.ToString(itemChild["DonViDo"]);
                    info.IDTrungTam = ConvertUtility.ToInt32(itemChild["IDTrungTam"]);
                    info.IDPhongBan = ConvertUtility.ToInt32(itemChild["IDPhongBan"]);
                    info.Loai = ConvertUtility.ToInt32(itemChild["Loai"]);
                    info.IDDotDanhGia = idDotDanhGia;
                    info.LevelDeep = ConvertUtility.ToInt32(itemChild["LevelDeep"]);
                    info.NgayBatDau = ConvertUtility.ToDateTime(itemChild["NgayBatDau"]).AddMonths(1);
                    info.NgayKetThuc = ConvertUtility.ToDateTime(itemChild["NgayKetThuc"]).AddMonths(1);
                    info.TrangThaiCV = ConvertUtility.ToInt32(itemChild["TrangThaiCV"]);
                    info.TuanLamViec = ConvertUtility.ToString(itemChild["TuanLamViec"]);
                    info.OldID = ConvertUtility.ToInt32(itemChild["ID"]);

                    int parentIDTemp = QuanLyCongViecKTXVaPSController.Insert_6_11_2014(info);

                    InsertCongViecCon(source, itemChild, parentIDTemp, idDotDanhGia);
                }
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            QuanLyCongViecKTXVaPSController.DeleteAll(ConvertUtility.ToInt32(dropTrungTam.SelectedValue), 1, ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));
            Session["Nav"] = "1";
        }

        protected void dgrCongViec_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["Nav"] = "1";
        }

        protected void dropDotDanhGiaCopy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Nav"] = "1";
        }

        protected void btnXoaAll_Click(object sender, EventArgs e)
        {
            Session["Nav"] = "1";
            foreach (GridViewRow gv in dgrCongViec.Rows)
            {
                CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("chkCheck");
                if (deleteChkBxItem.Checked)
                {
                    string strTemp = ((Label)gv.FindControl("lblID")).Text.ToString();

                    QuanLyCongViecKTXVaPSController.DeleteRecursive(ConvertUtility.ToInt32(strTemp));
                }
            }
        }
    }
}