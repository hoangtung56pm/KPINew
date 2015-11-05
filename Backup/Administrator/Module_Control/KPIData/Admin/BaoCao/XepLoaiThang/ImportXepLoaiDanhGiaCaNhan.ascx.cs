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
using VmgPortal.Library;
using System.Xml;
using System.IO;
using System.Xml.Xsl;
using System.Text;
using VmgPortal.Modules.KPIData.Library.DinhNghia;

namespace VmgPortal.Modules.KPIData.Admin.BaoCao.XepLoaiThang
{
    public partial class ImportXepLoaiDanhGiaCaNhan : AuthenticatedControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dropBoPhan.DataSource = BoPhanController.BoPhan_GetAllActive();
                dropBoPhan.DataBind();

                dropNam.SelectedValue = DateTime.Now.Year.ToString();
                dropThang.SelectedValue = DateTime.Now.Month.ToString();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (fileImport.HasFile)
            {
                if (!Directory.Exists(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/")))
                {
                    Directory.CreateDirectory(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/"));
                }
                string date = DateTime.Now.ToString("yyyyMMddHHmmss");

                string path = Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/") + fileImport.FileName.Replace(".csv", "") + "_Temp_" + date + ".csv";

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                fileImport.PostedFile.SaveAs(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/") + fileImport.FileName.Replace(".csv", "") + "_Temp_" + date + ".csv");

                if (File.Exists(path))
                {
                    DataTable returnTable = ImportExcelToDataTable.ConvertCSVtoDataTable(path);

                    if (returnTable != null && returnTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < returnTable.Rows.Count; i++)
                        {
                            try
                            {
                                DataRow row = returnTable.Rows[i];

                                #region Import

                                TongHopDanhGiaCaNhanThangInfo info = new TongHopDanhGiaCaNhanThangInfo();

                                info.BoPhan = row[0].ToString();
                                info.HoTen = row[1].ToString();
                                info.KPI = ConvertUtility.ToDouble(row[2].ToString().Replace(".", ",")) * 100;
                                info.DiemDanhGiaDonVi = ConvertUtility.ToDouble(row[3].ToString().Replace(".", ",")) * 100;
                                info.LoiNhuanCongTy = ConvertUtility.ToDouble(row[4].ToString().Replace(".", ",")) * 100;
                                info.LoiNhuanBoPhan = ConvertUtility.ToDouble(row[5].ToString().Replace(".", ",")) * 100;
                                info.QuanLyCongViecVaPhoiHop = ConvertUtility.ToDouble(row[6].ToString().Replace(".", ",")) * 100;
                                info.KyLuatCaNhan = ConvertUtility.ToDouble(row[7].ToString().Replace(".", ",")) * 100;
                                info.DiemThuong = ConvertUtility.ToDouble(row[8].ToString().Replace(".", ","));
                                info.MucDoHoanThanh = ConvertUtility.ToDouble(row[9].ToString().Replace(".", ",")) * 100;
                                info.XepLoai = row[10].ToString();
                                info.HeSoLuongMem = ConvertUtility.ToDouble(row[11].ToString().Replace(".", ",")) * 100;
                                info.Nam = ConvertUtility.ToInt32(dropNam.SelectedValue);
                                info.Thang = ConvertUtility.ToInt32(dropThang.SelectedValue);

                                TongHopDanhGiaCaNhanThangController.Insert(info);

                                #endregion
                            }
                            catch
                            {
                                continue;
                            }
                        }

                        lblUpdateStatus.Text = "Bạn đã import thành công file \"" + fileImport.FileName + "\"";
                    }
                    else
                    {
                        lblUpdateStatus.Text = "File import sai định dạng";
                    }
                }
                else
                {
                    lblUpdateStatus.Text = "File import sai định dạng";
                }
            }
            else
            {
                lblUpdateStatus.Text = "File import sai định dạng";
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();

            // Write down the XML declaration
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);

            // Create the root element
            XmlElement rootNode = xmlDoc.CreateElement("ReportDataSet");
            xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement);
            xmlDoc.AppendChild(rootNode);

            DataTable dt = BoPhanController.BoPhan_GetAllActive();

            foreach (DataRow item in dt.Rows)
            {
                string desc = item["MoTa"].ToString();
                string ten = item["Ten"].ToString();

                XmlElement Node = xmlDoc.CreateElement("Table" + desc);
                rootNode.AppendChild(Node);

                DataTable dtNhanVien = TongHopDanhGiaCaNhanThangController.GetAllNhanVien(ten, ConvertUtility.ToInt32(dropNam.SelectedValue));

                int stt = 1;
                foreach (DataRow itemNhanVien in dtNhanVien.Rows)
                {
                    DataTable dtDataOfNhanVien = TongHopDanhGiaCaNhanThangController.GetAll(ten, ConvertUtility.ToInt32(dropNam.SelectedValue), itemNhanVien["HoTen"].ToString());

                    xmlDoc = BuildXmlDocument(dtDataOfNhanVien, xmlDoc, Node, stt, itemNhanVien["HoTen"].ToString());
                    stt++;
                }
            }

            if (!Directory.Exists(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/")))
            {
                Directory.CreateDirectory(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/"));
            }
            //ds.Dispose();
            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            FileStream downloadFile =
                File.Create(Server.MapPath("/UpLoad/Temp/" + CurrentUser.UserID + "/") + "TongHopBaoCaoXepLoaiNhanVien_" + datetime +
                            ".xls");

            // transform
            XslTransform xsl = new XslTransform();
            xsl.Load(Server.MapPath("/Template/" + "ReportTongHopXepLoaiNhanVien.xsl"));
            xsl.Transform(xmlDoc, null, downloadFile, null);
            downloadFile.Flush();
            downloadFile.Close();

            if (AppEnv.GetLanguage() == "vi-VN")
            {
                hplDownload.Text = "Hãy click vào liên kết này để Tải file về";
            }
            else
            {
                hplDownload.Text = "Please, click here to download file";
            }
            hplDownload.NavigateUrl = "/UpLoad/Temp/" + CurrentUser.UserID + "/TongHopBaoCaoXepLoaiNhanVien_" + datetime + ".xls";

        }

        private XmlDocument BuildXmlDocument(DataTable dtDataOfNhanVien, XmlDocument xmlDoc, XmlElement tableNode, int stt, string ten)
        {

            #region Table Node

            DataRow[] Thang1 = dtDataOfNhanVien.Select("Nam = '" + dropNam.SelectedValue + "' and Thang = '1'");
            DataRow[] Thang2 = dtDataOfNhanVien.Select("Nam = '" + dropNam.SelectedValue + "' and Thang = '2'");
            DataRow[] Thang3 = dtDataOfNhanVien.Select("Nam = '" + dropNam.SelectedValue + "' and Thang = '3'");
            DataRow[] Thang4 = dtDataOfNhanVien.Select("Nam = '" + dropNam.SelectedValue + "' and Thang = '4'");
            DataRow[] Thang5 = dtDataOfNhanVien.Select("Nam = '" + dropNam.SelectedValue + "' and Thang = '5'");
            DataRow[] Thang6 = dtDataOfNhanVien.Select("Nam = '" + dropNam.SelectedValue + "' and Thang = '6'");
            DataRow[] Thang7 = dtDataOfNhanVien.Select("Nam = '" + dropNam.SelectedValue + "' and Thang = '7'");
            DataRow[] Thang8 = dtDataOfNhanVien.Select("Nam = '" + dropNam.SelectedValue + "' and Thang = '8'");
            DataRow[] Thang9 = dtDataOfNhanVien.Select("Nam = '" + dropNam.SelectedValue + "' and Thang = '9'");
            DataRow[] Thang10 = dtDataOfNhanVien.Select("Nam = '" + dropNam.SelectedValue + "' and Thang = '10'");
            DataRow[] Thang11 = dtDataOfNhanVien.Select("Nam = '" + dropNam.SelectedValue + "' and Thang = '11'");
            DataRow[] Thang12 = dtDataOfNhanVien.Select("Nam = '" + dropNam.SelectedValue + "' and Thang = '12'");

            XmlElement Table = xmlDoc.CreateElement("Table");
            
            XmlElement STTNode = xmlDoc.CreateElement("STT");
            XmlText STTNodeText = xmlDoc.CreateTextNode(stt.ToString());
            STTNode.AppendChild(STTNodeText);

            XmlElement HoTenNode = xmlDoc.CreateElement("HoTen");
            XmlText HoTenNodeText = xmlDoc.CreateTextNode(ten);
            HoTenNode.AppendChild(HoTenNodeText);

            XmlElement Thang1DiemNode = xmlDoc.CreateElement("Thang1Diem");
            XmlText Thang1DiemNodeText = xmlDoc.CreateTextNode(Thang1.Length > 0 ? (ConvertUtility.ToDouble(Thang1[0]["MucDoHoanThanh"].ToString()) / 100).ToString().Replace(",",".") : "0");
            Thang1DiemNode.AppendChild(Thang1DiemNodeText);

            XmlElement Thang1XepLoaiNode = xmlDoc.CreateElement("Thang1XepLoai");
            XmlText Thang1XepLoaiNodeText = xmlDoc.CreateTextNode(Thang1.Length > 0 ? Thang1[0]["XepLoai"].ToString() : "");
            Thang1XepLoaiNode.AppendChild(Thang1XepLoaiNodeText);

            XmlElement Thang2DiemNode = xmlDoc.CreateElement("Thang2Diem");
            XmlText Thang2DiemNodeText = xmlDoc.CreateTextNode(Thang2.Length > 0 ? (ConvertUtility.ToDouble(Thang2[0]["MucDoHoanThanh"].ToString()) / 100).ToString().Replace(",", ".") : "0");
            Thang2DiemNode.AppendChild(Thang2DiemNodeText);

            XmlElement Thang2XepLoaiNode = xmlDoc.CreateElement("Thang2XepLoai");
            XmlText Thang2XepLoaiNodeText = xmlDoc.CreateTextNode(Thang2.Length > 0 ? Thang2[0]["XepLoai"].ToString() : "");
            Thang2XepLoaiNode.AppendChild(Thang2XepLoaiNodeText);

            XmlElement Thang3DiemNode = xmlDoc.CreateElement("Thang3Diem");
            XmlText Thang3DiemNodeText = xmlDoc.CreateTextNode(Thang3.Length > 0 ? (ConvertUtility.ToDouble(Thang3[0]["MucDoHoanThanh"].ToString()) / 100).ToString().Replace(",", ".") : "0");
            Thang3DiemNode.AppendChild(Thang3DiemNodeText);

            XmlElement Thang3XepLoaiNode = xmlDoc.CreateElement("Thang3XepLoai");
            XmlText Thang3XepLoaiNodeText = xmlDoc.CreateTextNode(Thang3.Length > 0 ? Thang3[0]["XepLoai"].ToString() : "");
            Thang3XepLoaiNode.AppendChild(Thang3XepLoaiNodeText);

            XmlElement Thang4DiemNode = xmlDoc.CreateElement("Thang4Diem");
            XmlText Thang4DiemNodeText = xmlDoc.CreateTextNode(Thang4.Length > 0 ? (ConvertUtility.ToDouble(Thang4[0]["MucDoHoanThanh"].ToString()) / 100).ToString().Replace(",", ".") : "0");
            Thang4DiemNode.AppendChild(Thang4DiemNodeText);

            XmlElement Thang4XepLoaiNode = xmlDoc.CreateElement("Thang4XepLoai");
            XmlText Thang4XepLoaiNodeText = xmlDoc.CreateTextNode(Thang4.Length > 0 ? Thang4[0]["XepLoai"].ToString() : "");
            Thang4XepLoaiNode.AppendChild(Thang4XepLoaiNodeText);

            XmlElement Thang5DiemNode = xmlDoc.CreateElement("Thang5Diem");
            XmlText Thang5DiemNodeText = xmlDoc.CreateTextNode(Thang5.Length > 0 ? (ConvertUtility.ToDouble(Thang5[0]["MucDoHoanThanh"].ToString()) / 100).ToString().Replace(",", ".") : "0");
            Thang5DiemNode.AppendChild(Thang5DiemNodeText);

            XmlElement Thang5XepLoaiNode = xmlDoc.CreateElement("Thang5XepLoai");
            XmlText Thang5XepLoaiNodeText = xmlDoc.CreateTextNode(Thang5.Length > 0 ? Thang5[0]["XepLoai"].ToString() : "");
            Thang5XepLoaiNode.AppendChild(Thang5XepLoaiNodeText);

            XmlElement Thang6DiemNode = xmlDoc.CreateElement("Thang6Diem");
            XmlText Thang6DiemNodeText = xmlDoc.CreateTextNode(Thang6.Length > 0 ? (ConvertUtility.ToDouble(Thang6[0]["MucDoHoanThanh"].ToString()) / 100).ToString().Replace(",", ".") : "0");
            Thang6DiemNode.AppendChild(Thang6DiemNodeText);

            XmlElement Thang6XepLoaiNode = xmlDoc.CreateElement("Thang6XepLoai");
            XmlText Thang6XepLoaiNodeText = xmlDoc.CreateTextNode(Thang6.Length > 0 ? Thang6[0]["XepLoai"].ToString() : "");
            Thang6XepLoaiNode.AppendChild(Thang6XepLoaiNodeText);

            XmlElement Thang7DiemNode = xmlDoc.CreateElement("Thang7Diem");
            XmlText Thang7DiemNodeText = xmlDoc.CreateTextNode(Thang7.Length > 0 ? (ConvertUtility.ToDouble(Thang7[0]["MucDoHoanThanh"].ToString()) / 100).ToString().Replace(",", ".") : "0");
            Thang7DiemNode.AppendChild(Thang7DiemNodeText);

            XmlElement Thang7XepLoaiNode = xmlDoc.CreateElement("Thang7XepLoai");
            XmlText Thang7XepLoaiNodeText = xmlDoc.CreateTextNode(Thang7.Length > 0 ? Thang7[0]["XepLoai"].ToString() : "");
            Thang7XepLoaiNode.AppendChild(Thang7XepLoaiNodeText);

            XmlElement Thang8DiemNode = xmlDoc.CreateElement("Thang8Diem");
            XmlText Thang8DiemNodeText = xmlDoc.CreateTextNode(Thang8.Length > 0 ? (ConvertUtility.ToDouble(Thang8[0]["MucDoHoanThanh"].ToString()) / 100).ToString().Replace(",", ".") : "0");
            Thang8DiemNode.AppendChild(Thang8DiemNodeText);

            XmlElement Thang8XepLoaiNode = xmlDoc.CreateElement("Thang8XepLoai");
            XmlText Thang8XepLoaiNodeText = xmlDoc.CreateTextNode(Thang8.Length > 0 ? Thang8[0]["XepLoai"].ToString() : "");
            Thang8XepLoaiNode.AppendChild(Thang8XepLoaiNodeText);

            XmlElement Thang9DiemNode = xmlDoc.CreateElement("Thang9Diem");
            XmlText Thang9DiemNodeText = xmlDoc.CreateTextNode(Thang9.Length > 0 ? (ConvertUtility.ToDouble(Thang9[0]["MucDoHoanThanh"].ToString()) / 100).ToString().Replace(",", ".") : "0");
            Thang9DiemNode.AppendChild(Thang9DiemNodeText);

            XmlElement Thang9XepLoaiNode = xmlDoc.CreateElement("Thang9XepLoai");
            XmlText Thang9XepLoaiNodeText = xmlDoc.CreateTextNode(Thang9.Length > 0 ? Thang9[0]["XepLoai"].ToString() : "");
            Thang9XepLoaiNode.AppendChild(Thang9XepLoaiNodeText);

            XmlElement Thang10DiemNode = xmlDoc.CreateElement("Thang10Diem");
            XmlText Thang10DiemNodeText = xmlDoc.CreateTextNode(Thang10.Length > 0 ? (ConvertUtility.ToDouble(Thang10[0]["MucDoHoanThanh"].ToString()) / 100).ToString().Replace(",", ".") : "0");
            Thang10DiemNode.AppendChild(Thang10DiemNodeText);

            XmlElement Thang10XepLoaiNode = xmlDoc.CreateElement("Thang10XepLoai");
            XmlText Thang10XepLoaiNodeText = xmlDoc.CreateTextNode(Thang10.Length > 0 ? Thang10[0]["XepLoai"].ToString() : "");
            Thang10XepLoaiNode.AppendChild(Thang10XepLoaiNodeText);

            XmlElement Thang11DiemNode = xmlDoc.CreateElement("Thang11Diem");
            XmlText Thang11DiemNodeText = xmlDoc.CreateTextNode(Thang11.Length > 0 ? (ConvertUtility.ToDouble(Thang11[0]["MucDoHoanThanh"].ToString()) / 100).ToString().Replace(",", ".") : "0");
            Thang11DiemNode.AppendChild(Thang11DiemNodeText);

            XmlElement Thang11XepLoaiNode = xmlDoc.CreateElement("Thang11XepLoai");
            XmlText Thang11XepLoaiNodeText = xmlDoc.CreateTextNode(Thang11.Length > 0 ? Thang11[0]["XepLoai"].ToString() : "");
            Thang11XepLoaiNode.AppendChild(Thang11XepLoaiNodeText);

            XmlElement Thang12DiemNode = xmlDoc.CreateElement("Thang12Diem");
            XmlText Thang12DiemNodeText = xmlDoc.CreateTextNode(Thang12.Length > 0 ? (ConvertUtility.ToDouble(Thang12[0]["MucDoHoanThanh"].ToString()) / 100).ToString().Replace(",", ".") : "0");
            Thang12DiemNode.AppendChild(Thang12DiemNodeText);

            XmlElement Thang12XepLoaiNode = xmlDoc.CreateElement("Thang12XepLoai");
            XmlText Thang12XepLoaiNodeText = xmlDoc.CreateTextNode(Thang12.Length > 0 ? Thang12[0]["XepLoai"].ToString(): "");
            Thang12XepLoaiNode.AppendChild(Thang12XepLoaiNodeText);

            Table.AppendChild(STTNode);
            Table.AppendChild(HoTenNode);

            Table.AppendChild(Thang1DiemNode);
            Table.AppendChild(Thang1XepLoaiNode);

            Table.AppendChild(Thang2DiemNode);
            Table.AppendChild(Thang2XepLoaiNode);

            Table.AppendChild(Thang3DiemNode);
            Table.AppendChild(Thang3XepLoaiNode);

            Table.AppendChild(Thang4DiemNode);
            Table.AppendChild(Thang4XepLoaiNode);

            Table.AppendChild(Thang5DiemNode);
            Table.AppendChild(Thang5XepLoaiNode);

            Table.AppendChild(Thang6DiemNode);
            Table.AppendChild(Thang6XepLoaiNode);

            Table.AppendChild(Thang7DiemNode);
            Table.AppendChild(Thang7XepLoaiNode);

            Table.AppendChild(Thang8DiemNode);
            Table.AppendChild(Thang8XepLoaiNode);

            Table.AppendChild(Thang9DiemNode);
            Table.AppendChild(Thang9XepLoaiNode);

            Table.AppendChild(Thang10DiemNode);
            Table.AppendChild(Thang10XepLoaiNode);

            Table.AppendChild(Thang11DiemNode);
            Table.AppendChild(Thang11XepLoaiNode);

            Table.AppendChild(Thang12DiemNode);
            Table.AppendChild(Thang12XepLoaiNode);
            
            #endregion

            tableNode.AppendChild(Table);

            return xmlDoc;
        }
    }
}