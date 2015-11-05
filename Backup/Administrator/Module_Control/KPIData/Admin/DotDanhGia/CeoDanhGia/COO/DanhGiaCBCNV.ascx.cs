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
using System.Drawing;
using VmgPortal.Library;
using VmgPortal.Modules.KPIData.Library.DanhGia;

namespace VmgPortal.Modules.KPIData.Admin.DotDanhGia.CeoDanhGia.COO
{
    public partial class DanhGiaCBCNV : AuthenticatedControl
    {
        int idDotDanhGia = 0;
        int idNhanVien = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            idDotDanhGia = ConvertUtility.ToInt32(Request.QueryString["idDotDanhGia"]);
            idNhanVien = ConvertUtility.ToInt32(Request.QueryString["idNhanVien"]);
            if (!IsPostBack)
            {
                dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
                dropDotDanhGia.DataBind();

                if (idDotDanhGia == 0)
                {
                    int idDotDotDanhDefault = ConvertUtility.ToInt32(DotDanhGiaController.GetDaultDotDanhGia().Rows[0]["ID"]);
                    Response.Redirect(AppEnv.AdminUrlParams("dg_danhgiald_kd") + "&idDotDanhGia=" + idDotDotDanhDefault + "&idNhanVien=" + CurrentUser.UserID);
                }
                else
                {
                    dropDotDanhGia.SelectedValue = idDotDanhGia.ToString();
                }
            }

            if (CurrentUser.RoleID == (int)Constants.Role.CEO || CurrentUser.IsAdmin || CurrentUser.IsSuperAdmin)
            {
                btnYeuCauLamLaiDanhGia.Visible = true;
            }
            else
            {
                btnYeuCauLamLaiDanhGia.Visible = false;
            }

            btnSumit.OnClientClick = "return confirm('Bạn có chắc chắn gửi đánh giá hay không ?')";
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            #region Check authenticate

            UserInfo userInfo = UserController.GetUser(idNhanVien);
            if (userInfo == null)
            {
                Response.Redirect(AppEnv.AdminUrlParams("accessdeny"));
            }

            if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
            {
                if (CurrentUser.UserID != 8)
                {
                    if (CurrentUser.RoleID == (int)Constants.Role.NhanVien || CurrentUser.RoleID == (int)Constants.Role.NhanVienKD)
                    {
                        if (CurrentUser.UserID != idNhanVien)
                        {
                            Response.Redirect(AppEnv.AdminUrlParams("accessdeny"));
                        }
                    }
                }
            }

            #endregion

            DataTable dt = DotDanhGiaController.checkDanhGiaThang(idDotDanhGia, idNhanVien);

            if (dt != null && dt.Rows.Count > 0)
            {
                #region kiem tra trang thai cua Ban danh gia

                if (idNhanVien == CurrentUser.UserID)
                {
                    if (ConvertUtility.ToInt32(dt.Rows[0]["TrangThai"]) == (int)Constants.TrangThaiDanhGiaNhanVien.ThongNhat)
                    {
                        btnSumit.Enabled = false;
                        btnSumit.Text = "Thống nhất";
                    }
                    else
                    {
                        btnSumit.Enabled = false;
                        btnSumit.Text = "Chờ CEO đánh giá";
                    }
                }
                else
                {
                    btnSumit.Enabled = true;
                    btnSumit.Text = "Đánh giá và gửi lại kết quả cho TBP";
                }

                #endregion

                tableContent.Visible = true;
                tableAlert.Visible = false;

                #region Tong diem cua ban danh gia

                DataSet ds = DotDanhGiaController.DanhGiaThang_DGCBCNVDanhGia_TongDiemCongThucMoi(idDotDanhGia, idNhanVien);

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblDiemDanhGiaDonVi.Text = Math.Round(ConvertUtility.ToDouble(ds.Tables[0].Rows[0]["TotalDiemDanhGiaDonVi"].ToString()), 2).ToString() + "%";
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        lblDiemHoanThanhLoiNhuanCongTy.Text = Math.Round(ConvertUtility.ToDouble(ds.Tables[1].Rows[0]["TotalDiemLNCgTy"]), 2).ToString() + "%";
                    } 
                    
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        lblDiemKhoiLuongCongViec.Text = Math.Round(ConvertUtility.ToDouble(ds.Tables[2].Rows[0]["TotalDiemKhoiLuongCongViec"]), 2).ToString() + "%";
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        lblDiemKyNangLamViec.Text = Math.Round(ConvertUtility.ToDouble(ds.Tables[3].Rows[0]["TotalDiemKyNangLamViec"]), 2).ToString() + "%";
                    }
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        lblDiemKyLuat.Text = Math.Round(ConvertUtility.ToDouble(ds.Tables[4].Rows[0]["TotalDiemKyLuat"]), 2).ToString() + "%";
                    }
                    
                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        lblMucDoHoanThanh.Text = Math.Round(ConvertUtility.ToDouble(ds.Tables[5].Rows[0]["TongDiem"]), 1, MidpointRounding.AwayFromZero).ToString() + "%";
                    }

                    if (ds.Tables[6].Rows.Count > 0)
                    {
                        lblXepLoai.Text = ds.Tables[6].Rows[0]["XepLoai"].ToString();
                    }

                    if (ds.Tables[7].Rows.Count > 0)
                    {
                        lblName.Text = ds.Tables[7].Rows[0]["HoTen"].ToString();
                    }

                    if (ds.Tables[8].Rows.Count > 0)
                    {
                        lblDiemThuong.Text = Math.Round(ConvertUtility.ToDouble(ds.Tables[8].Rows[0]["DiemThuong"]), 2).ToString() + "%";
                    }

                    lblHeSoLuongMem.Text = GetLuongMem(lblXepLoai.Text);


                    #region Ty Trong Cong Viec

                    double totalCVTX = 0;
                    double totalCVKTX = 0;
                    double totalCVPS = 0;
                    double total = 0;

                    DataTable dtCongViecThuongXuyen = DanhGiaThang_DGCBCNVDanhGiaTTCVController.GetAll(1, idDotDanhGia, idNhanVien);

                    foreach (DataRow item in dtCongViecThuongXuyen.Rows)
                    {
                        totalCVTX += ConvertUtility.ToDouble(item["TyTrongCV"]);
                    }

                    DataTable dtCongViecKhongThuonguyen = DanhGiaThang_DGCBCNVDanhGiaTTCVController.GetAll(2, idDotDanhGia, idNhanVien);
                    foreach (DataRow item in dtCongViecKhongThuonguyen.Rows)
                    {
                        totalCVKTX += ConvertUtility.ToDouble(item["TyTrongCV"]);
                    }

                    DataTable dtCongViecPhatSinh = DanhGiaThang_DGCBCNVDanhGiaTTCVController.GetAll(3, idDotDanhGia, idNhanVien);
                    foreach (DataRow item in dtCongViecPhatSinh.Rows)
                    {
                        totalCVPS += ConvertUtility.ToDouble(item["TyTrongCV"]);
                    }

                    lblCVTX.Text = Math.Round(totalCVTX, 2) + "%";
                    lblCVKTX.Text = Math.Round(totalCVKTX, 2) + "%";
                    lblCVPhatSinh.Text = Math.Round(totalCVPS, 2) + "%";

                    total = totalCVTX + totalCVKTX + totalCVPS;

                    lblTotal.Text = Math.Round(total, 2).ToString() + "%";

                    lblTotal.Text = Math.Round(total, 2).ToString() + "%";
                    if (total > 100)
                    {
                        lblTotal.ForeColor = Color.Red;
                    }
                    double totalCVPhatSinh = Math.Round((100 - total), 2);

                    if (totalCVPhatSinh > 0)
                    {
                        lblCVPhatSinh.Text = Math.Round(totalCVPS, 2) + "%" + " còn lại " + Math.Round((100 - total), 2) + "%";
                    }
                    else
                    {
                        lblCVPhatSinh.Text = Math.Round(totalCVPS, 2) + "%";
                    }

                    #endregion
                }

                #endregion

            }
            else
            {
                tableContent.Visible = false;
                tableAlert.Visible = true;
            }

        }

        private string GetLuongMem(string xeploai)
        {
            if (xeploai == "A+")
            {
                return "140%";
            }
            else if (xeploai == "A")
            {
                return "130%";
            }
            else if (xeploai == "B")
            {
                return "120%";
            }
            else if (xeploai == "C")
            {
                return "110%";
            }
            else
            {
                return "100%";
            }

        }

        protected void btnSumit_Click(object sender, EventArgs e)
        {
            DataTable dt = DotDanhGiaController.checkDanhGiaNam(idDotDanhGia, idNhanVien);

            if (dt != null && dt.Rows.Count > 0)
            {
                UserInfo userInfo = UserController.GetUser(idNhanVien);

                DotDanhGiaController.GuiDanhGiaThang(idDotDanhGia, idNhanVien, (int)Constants.TrangThaiDanhGiaNhanVien.ThongNhat);

                EmailUtility.DoSendMail(userInfo.EmailVNG, "", "CEO đã thống nhất bảng đánh giá tháng", "CEO đã đánh giá công việc tháng của bạn. Đề nghị bạn đăng nhập phần mềm để xem kết quả đánh giá.");

                Response.Redirect(AppEnv.AdminUrlParams("danhgiathang_ld_kd") + "&idDotDanhGia=" + dropDotDanhGia.SelectedValue);
            }
        }

        protected void dropDotDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(AppEnv.AdminUrlParams("dg_danhgiald_kd") + "&idDotDanhGia=" + dropDotDanhGia.SelectedValue + "&idNhanVien=" + idNhanVien);
        }

        protected void btnYeuCauLamLaiDanhGia_Click(object sender, EventArgs e)
        {
            UserInfo info = UserController.GetUser(idNhanVien);
            if (info != null)
            {
                DotDanhGiaController.GuiDanhGiaThang(idDotDanhGia, idNhanVien, (int)Constants.TrangThaiDanhGiaNhanVien.DangDanhGia);

                EmailUtility.DoSendMail(info.EmailVNG, "", "Yêu cầu lập lại đánh giá tháng " + dropDotDanhGia.SelectedItem.Text, "TBP/TBP thấy bạn lập đánh giá tháng chưa hợp lý. Đề nghị bạn đăng nhập phần mềm để làm lại kế hoạch.");
            }
        }

    }
}