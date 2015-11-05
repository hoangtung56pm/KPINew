using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VmgPortal.Modules.KPIData.Library.Providers;
using System.Data;
using VmgPortal.Modules.KPIData.Library.DanhGiaBoPhan;
using VmgPortal.Library.Utilities;
using VmgPortal.Modules.KPIData.Library.PhongBan;
using System.Globalization;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;

namespace VmgPortal.Modules.KPIData.Library.DanhGia
{
    public class DanhGiaThang_BoPhanTTCVController
    {
        public static DataTable GetAll(int loai, int IDDotDanhGia, int idBoPhan)
        {
            return DataAccessProvider.Instance().GetAllDanhGiaThang_BoPhanTTCV(loai, IDDotDanhGia, idBoPhan);
        }
        public static DataTable GetAllNew(int loai, int IDDotDanhGia, int idBoPhan)
        {
            return DataAccessProvider.Instance().GetAllDanhGiaThang_BoPhanTTCVNew(loai, IDDotDanhGia, idBoPhan);
        }
        public static DataSet GetAllCongViecPhong(int loai, int IDDotDanhGia, int idBoPhan, int idPhong)
        {
            return DataAccessProvider.Instance().GetAllKeHoachThangCuaPhong_BoPhanTTCV(loai, IDDotDanhGia, idBoPhan, idPhong);
        }
        public static DataSet GetAllCongViecPhongNew(int loai, int IDDotDanhGia, int idBoPhan, int idPhong)
        {
            return DataAccessProvider.Instance().GetAllKeHoachThangCuaPhong_BoPhanTTCV_New(loai, IDDotDanhGia, idBoPhan, idPhong);
        }
        public static DataSet GetAllCongViecPhong_ForExport(int loai, int IDDotDanhGia, int idBoPhan, int idPhong)
        {
            return DataAccessProvider.Instance().GetAllKeHoachThangCuaPhong_BoPhanTTCV_ForExport(loai, IDDotDanhGia, idBoPhan, idPhong);
        }
        public static void DeleteNew(int _id)
        {
            DataAccessProvider.Instance().DeleteDanhGiaThang_BoPhanTTCVNew(_id);
        }
        public static void Delete(int _id)
        {
            DataAccessProvider.Instance().DeleteDanhGiaThang_BoPhanTTCV(_id);
        }
        public static int Insert(DanhGiaThang_BoPhanTTCVInfo _DotDanhGiaInfo)
        {
            return DataAccessProvider.Instance().InsertDanhGiaThang_BoPhanTTCV(_DotDanhGiaInfo);
        }

        public static void Update(DanhGiaThang_BoPhanTTCVInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().UpdateDanhGiaThang_BoPhanTTCV(_DotDanhGiaInfo);
        }

        public static int InsertKeHoachThang(DanhGiaThang_BoPhanTTCVInfo _DotDanhGiaInfo)
        {
            return DataAccessProvider.Instance().InsertKeHoachThang_BoPhanTTCV(_DotDanhGiaInfo);
        }

        public static int InsertKeHoachThangNew(DanhGiaThang_BoPhanTTCVInfo _DotDanhGiaInfo)
        {
            return DataAccessProvider.Instance().InsertKeHoachThang_BoPhanTTCV_New(_DotDanhGiaInfo);
        }

        public static void UpdateKeHoachThang(DanhGiaThang_BoPhanTTCVInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().UpdateKeHoachThang_BoPhanTTCV(_DotDanhGiaInfo);
        }

        public static void UpdateKeHoachThangCOODanhGia(DanhGiaThang_BoPhanTTCVInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().UpdateKeHoachThangCOODanhGia(_DotDanhGiaInfo);
        }

        public static void UpdateKeHoachThangCOODanhGiaNew(DanhGiaThang_BoPhanTTCVInfo _DotDanhGiaInfo)
        {
            DataAccessProvider.Instance().UpdateKeHoachThangCOODanhGiaNew(_DotDanhGiaInfo);
        }

        public static DanhGiaThang_BoPhanTTCVInfo GetInfo(int _id)
        {
            return DataAccessProvider.Instance().GetInfoDanhGiaThang_BoPhanTTCV(_id);
        }

        public static DataTable BuildRecursiveCongViecKTXVaPS(DataTable dtCongViec, DataTable dtReturnCongViec)
        {
            DataRow[] dtItems = GetCongViecByParentID(dtCongViec, 0);
            foreach (DataRow row in dtItems)
            {
                DataRow rowItem = dtReturnCongViec.NewRow();
                rowItem["ID"] = row["ID"].ToString();
                rowItem["TenCongViec"] = row["TenCongViec"];
                rowItem["TyTrongCV"] = row["TyTrongCV"].ToString();
                rowItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString();
                rowItem["Level"] = "0";
                rowItem["IDParent"] = row["IDParent"].ToString();
                rowItem["IDCongViec"] = row["IDCongViec"].ToString();
                rowItem["YeuCauHoTro"] = row["YeuCauHoTro"].ToString();

                DataTable dtTen = GetNguoiThamGiaCongViecKTXVaPS(ConvertUtility.ToInt32(row["IDDotDanhGia"]), ConvertUtility.ToInt32(row["IDCongViec"]));

                if (dtTen != null && dtTen.Rows.Count > 0)
                {
                    rowItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                }
                else
                {
                    rowItem["NguoiThamGia"] = "";
                }
                rowItem["IDPhongBan"] = row["IDPhongBan"].ToString();
                dtReturnCongViec.Rows.Add(rowItem);
            }

            return dtReturnCongViec;
        }
        public static DataTable BuildRecursiveCongViecKTXVaPSNew(DataTable dtCongViec, DataTable dtReturnCongViec)
        {
            foreach (DataRow row in dtCongViec.Rows)
            {
                DataRow rowItem = dtReturnCongViec.NewRow();
                rowItem["ID"] = row["ID"].ToString();
                rowItem["TenCongViec"] = row["TenCongViec"];
                rowItem["TyTrongCV"] = row["TyTrongCV"].ToString();
                rowItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString();
                rowItem["Level"] = "0";
                rowItem["IDParent"] = row["IDParent"].ToString();
                rowItem["IDCongViec"] = row["IDCongViec"].ToString();
                rowItem["YeuCauHoTro"] = row["YeuCauHoTro"].ToString();
                rowItem["NgayBatDau"] = row["NgayBatDau"].ToString();
                rowItem["NgayKetThuc"] = row["NgayKetThuc"].ToString();
                DataTable dtTen = GetNguoiThamGiaCongViecKTXVaPS(ConvertUtility.ToInt32(row["IDDotDanhGia"]), ConvertUtility.ToInt32(row["IDCongViec"]));

                if (dtTen != null && dtTen.Rows.Count > 0)
                {
                    rowItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                }
                else
                {
                    rowItem["NguoiThamGia"] = "";
                }
                rowItem["IDPhongBan"] = row["IDPhongBan"].ToString();
                dtReturnCongViec.Rows.Add(rowItem);
            }

            return dtReturnCongViec;
        }

        public static DataTable BuildRecursiveKeHoachCongViec(DataTable dtCongViec, DataTable dtReturnCongViec)
        {
            DataRow[] dtItems = GetCongViecByParentID(dtCongViec, 0);
            foreach (DataRow row in dtItems)
            {
                DataRow rowItem = dtReturnCongViec.NewRow();
                rowItem["ID"] = row["ID"].ToString();
                rowItem["TenCongViec"] = row["TenCongViec"].ToString();// "<font color=\"Black\" style=\"font-weight:normal\">" + row["TenCongViec"].ToString() + "</font>";
                rowItem["TyTrongCV"] = row["TyTrongCV"].ToString();
                rowItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString();// "<font color=\"Black\" style=\"font-weight:normal\">" + row["SoLieuCamKet"].ToString() + "</font>";
                rowItem["Level"] = "0";
                rowItem["IDParent"] = row["IDParent"].ToString();
                rowItem["IDCongViec"] = row["IDCongViec"].ToString();
                rowItem["IDPhongBan"] = row["IDPhongBan"].ToString();

                DataTable dtTen = GetNguoiThamGiaCongViec(ConvertUtility.ToInt32(row["IDDotDanhGia"]), ConvertUtility.ToInt32(row["IDCongViec"]));

                if (dtTen != null && dtTen.Rows.Count > 0)
                {
                    rowItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                }
                else
                {
                    rowItem["NguoiThamGia"] = "";
                }

                dtReturnCongViec.Rows.Add(rowItem);
                LoadKeHoachCongViecForCur(dtCongViec, rowItem, dtReturnCongViec);
            }

            return dtReturnCongViec;
        }

        public static DataTable BuildRecursiveKeHoachCongViecNew(DataTable dtCongViec, DataTable dtReturnCongViec)
        {
            DataRow[] dtItems = GetCongViecByParentID(dtCongViec, 0);
            if (dtItems.Length > 0)
            {
                foreach (DataRow row in dtItems)
                {
                    DataRow rowItem = dtReturnCongViec.NewRow();
                    rowItem["ID"] = row["ID"].ToString();
                    rowItem["TenCongViec"] = row["TenCongViec"].ToString();// "<font color=\"Black\" style=\"font-weight:normal\">" + row["TenCongViec"].ToString() + "</font>";
                    rowItem["TyTrongCV"] = row["TyTrongCV"].ToString();
                    rowItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString();// "<font color=\"Black\" style=\"font-weight:normal\">" + row["SoLieuCamKet"].ToString() + "</font>";
                    rowItem["Level"] = "0";
                    rowItem["IDParent"] = row["IDParent"].ToString();
                    rowItem["IDCongViec"] = row["IDCongViec"].ToString();
                    rowItem["IDPhongBan"] = row["IDPhongBan"].ToString();
                    rowItem["NgayBatDau"] = row["NgayBatDau"].ToString();
                    rowItem["NgayKetThuc"] = row["NgayKetThuc"].ToString();
                    DataTable dtTen = GetNguoiThamGiaCongViec(ConvertUtility.ToInt32(row["IDDotDanhGia"]), ConvertUtility.ToInt32(row["IDCongViec"]));

                    if (dtTen != null && dtTen.Rows.Count > 0)
                    {
                        rowItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                    }
                    else
                    {
                        rowItem["NguoiThamGia"] = "";
                    }

                    dtReturnCongViec.Rows.Add(rowItem);
                    LoadKeHoachCongViecForCurNew(dtCongViec, rowItem, dtReturnCongViec);
                }
            }
            else
            {
                foreach (DataRow row in dtCongViec.Rows)
                {
                    DataRow rowItem = dtReturnCongViec.NewRow();
                    rowItem["ID"] = row["ID"].ToString();
                    rowItem["TenCongViec"] = row["TenCongViec"].ToString();// "<font color=\"Black\" style=\"font-weight:normal\">" + row["TenCongViec"].ToString() + "</font>";
                    rowItem["TyTrongCV"] = row["TyTrongCV"].ToString();
                    rowItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString();// "<font color=\"Black\" style=\"font-weight:normal\">" + row["SoLieuCamKet"].ToString() + "</font>";
                    rowItem["Level"] = "0";
                    rowItem["IDParent"] = row["IDParent"].ToString();
                    rowItem["IDCongViec"] = row["IDCongViec"].ToString();
                    rowItem["IDPhongBan"] = row["IDPhongBan"].ToString();
                    rowItem["NgayBatDau"] = row["NgayBatDau"].ToString();
                    rowItem["NgayKetThuc"] = row["NgayKetThuc"].ToString();
                    DataTable dtTen = GetNguoiThamGiaCongViec(ConvertUtility.ToInt32(row["IDDotDanhGia"]), ConvertUtility.ToInt32(row["IDCongViec"]));

                    if (dtTen != null && dtTen.Rows.Count > 0)
                    {
                        rowItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                    }
                    else
                    {
                        rowItem["NguoiThamGia"] = "";
                    }

                    dtReturnCongViec.Rows.Add(rowItem);
                }
            }
            return dtReturnCongViec;
        }
        private static string GetPhongBan(object idPhongBan)
        {
            if (ConvertUtility.ToInt32(idPhongBan) > 0)
            {
                PhongBanInfo info = PhongBanController.GetInfoCache(ConvertUtility.ToInt32(idPhongBan));
                if (info != null)
                {
                    return info.Ten;
                }
                return "";
            }
            return "";
        }

        public static DataTable BuildRecursiveKeHoachCongViecForExport(DataTable dtCongViec, DataTable dtReturnCongViec)
        {
            DataRow[] dtItems = GetCongViecByParentID(dtCongViec, 0);
            foreach (DataRow row in dtItems)
            {
                DataRow rowItem = dtReturnCongViec.NewRow();
                rowItem["ID"] = row["ID"].ToString();
                rowItem["IDPhongBan"] = GetPhongBan(row["IDPhongBan"]);
                rowItem["TenCongViec"] = row["TenCongViec"].ToString();
                rowItem["TyTrongCV"] = row["TyTrongCV"].ToString().Replace(",", ".");
                rowItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString();
                rowItem["Level"] = "0";
                rowItem["IDParent"] = row["IDParent"].ToString();
                rowItem["IDCongViec"] = row["IDCongViec"].ToString();

                DataTable dtTen = GetNguoiThamGiaCongViec(ConvertUtility.ToInt32(row["IDDotDanhGia"]), ConvertUtility.ToInt32(row["IDCongViec"]));

                if (dtTen != null && dtTen.Rows.Count > 0)
                {
                    rowItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                }
                else
                {
                    rowItem["NguoiThamGia"] = "";
                }

                dtReturnCongViec.Rows.Add(rowItem);
                LoadKeHoachCongViecForCurForExport(dtCongViec, rowItem, dtReturnCongViec);
            }

            return dtReturnCongViec;
        }
        public static DataTable BuildRecursiveKeHoachCongViecForExportNew(DataTable dtCongViec, DataTable dtReturnCongViec)
        {
            foreach (DataRow row in dtCongViec.Rows)
            {
                DataRow rowItem = dtReturnCongViec.NewRow();
                rowItem["ID"] = row["ID"].ToString();
                rowItem["IDPhongBan"] = GetPhongBan(row["IDPhongBan"]);
                rowItem["TenCongViec"] = row["TenCongViec"].ToString();
                rowItem["TyTrongCV"] = row["TyTrongCV"].ToString().Replace(",", ".");
                rowItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString();
                rowItem["Level"] = "0";
                rowItem["IDParent"] = row["IDParent"].ToString();
                rowItem["IDCongViec"] = row["IDCongViec"].ToString();
                rowItem["NgayBatDau"] = ConvertUtility.ToDateTime(row["NgayBatDau"]).ToString("dd/MM/yyyy");
                rowItem["NgayKetThuc"] = ConvertUtility.ToDateTime(row["NgayKetThuc"]).ToString("dd/MM/yyyy"); row["NgayKetThuc"].ToString();
                DataTable dtTen = GetNguoiThamGiaCongViec(ConvertUtility.ToInt32(row["IDDotDanhGia"]), ConvertUtility.ToInt32(row["IDCongViec"]));

                if (dtTen != null && dtTen.Rows.Count > 0)
                {
                    rowItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                }
                else
                {
                    rowItem["NguoiThamGia"] = "";
                }

                dtReturnCongViec.Rows.Add(rowItem);
                LoadKeHoachCongViecForCurForExportNew(dtCongViec, rowItem, dtReturnCongViec);
            }

            return dtReturnCongViec;
        }
        public static DataTable BuildRecursiveCongViecNew(DataTable dtCongViec, DataTable dtReturnCongViec)
        {
            DataRow[] dtItems = GetCongViecByParentID(dtCongViec, 0);
            if (dtItems.Length > 0)
            {
                foreach (DataRow row in dtItems)
                {
                    DataRow rowItem = dtReturnCongViec.NewRow();
                    rowItem["ID"] = row["ID"].ToString();
                    rowItem["TenCongViec"] = row["TenCongViec"].ToString();// "<font color=\"Black\" style=\"font-weight:bold\">" + row["TenCongViec"].ToString() + "</font>";
                    rowItem["TyTrongCV"] = row["TyTrongCV"].ToString();
                    rowItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString();// "<font color=\"Black\" style=\"font-weight:bold\">" + row["SoLieuCamKet"].ToString() + "</font>";
                    rowItem["Level"] = "0";
                    rowItem["IDParent"] = row["IDParent"].ToString();
                    rowItem["IDCongViec"] = row["IDCongViec"].ToString();
                    rowItem["YeuCauHoTro"] = row["YeuCauHoTro"].ToString();
                    rowItem["YKienCuaCOO"] = row["YKienCuaCOO"].ToString();
                    rowItem["IDPhongBan"] = row["IDPhongBan"].ToString();
                    rowItem["NgayBatDau"] = ConvertUtility.ToDateTime(row["NgayBatDau"]).ToString("dd/MM/yyyy");
                    rowItem["NgayKetThuc"] = ConvertUtility.ToDateTime(row["NgayKetThuc"]).ToString("dd/MM/yyyy");
                    DataRow[] dtChildLevel = GetCongViecByParentID(dtCongViec, ConvertUtility.ToInt32(row["IDCongViec"]));
                    if (dtChildLevel.Length > 0)
                    {
                        rowItem["HasChild"] = "1";
                    }
                    else
                    {
                        rowItem["HasChild"] = "0";
                    }

                    DataTable dtTen = GetNguoiThamGiaCongViec(ConvertUtility.ToInt32(row["IDDotDanhGia"]), ConvertUtility.ToInt32(row["IDCongViec"]));

                    if (dtTen != null && dtTen.Rows.Count > 0)
                    {
                        rowItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                    }
                    else
                    {
                        rowItem["NguoiThamGia"] = "";
                    }

                    double tyTrongCV = ConvertUtility.ToDouble(row["TyTrongCV"]);

                    if (tyTrongCV == 0)
                    {
                        rowItem["TBPDanhGia"] = "100";
                    }
                    else
                    {
                        rowItem["TBPDanhGia"] = Math.Round(ConvertUtility.ToDouble(row["TBPDanhGia"]), 2);
                    }

                    rowItem["TBPDanhGiaLai"] = Math.Round(ConvertUtility.ToDouble(row["TBPDanhGiaLai"]), 2);
                    rowItem["COODanhGia"] = Math.Round(ConvertUtility.ToDouble(row["COODanhGia"]), 2);

                    dtReturnCongViec.Rows.Add(rowItem);
                    LoadCongViecForCurNew(dtCongViec, rowItem, dtReturnCongViec);
                }
            }
            else
            {
                foreach (DataRow row in dtCongViec.Rows)
                {
                    DataRow rowItem = dtReturnCongViec.NewRow();
                    rowItem["ID"] = row["ID"].ToString();
                    rowItem["TenCongViec"] = row["TenCongViec"].ToString();// "<font color=\"Black\" style=\"font-weight:bold\">" + row["TenCongViec"].ToString() + "</font>";
                    rowItem["TyTrongCV"] = row["TyTrongCV"].ToString();
                    rowItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString();// "<font color=\"Black\" style=\"font-weight:bold\">" + row["SoLieuCamKet"].ToString() + "</font>";
                    rowItem["Level"] = "0";
                    rowItem["IDParent"] = row["IDParent"].ToString();
                    rowItem["IDCongViec"] = row["IDCongViec"].ToString();
                    rowItem["YeuCauHoTro"] = row["YeuCauHoTro"].ToString();
                    rowItem["YKienCuaCOO"] = row["YKienCuaCOO"].ToString();
                    rowItem["IDPhongBan"] = row["IDPhongBan"].ToString();
                    DataRow[] dtChildLevel = GetCongViecByParentID(dtCongViec, ConvertUtility.ToInt32(row["IDCongViec"]));
                    if (dtChildLevel.Length > 0)
                    {
                        rowItem["HasChild"] = "1";
                    }
                    else
                    {
                        rowItem["HasChild"] = "0";
                    }

                    DataTable dtTen = GetNguoiThamGiaCongViec(ConvertUtility.ToInt32(row["IDDotDanhGia"]), ConvertUtility.ToInt32(row["IDCongViec"]));

                    if (dtTen != null && dtTen.Rows.Count > 0)
                    {
                        rowItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                    }
                    else
                    {
                        rowItem["NguoiThamGia"] = "";
                    }

                    double tyTrongCV = ConvertUtility.ToDouble(row["TyTrongCV"]);

                    if (tyTrongCV == 0)
                    {
                        rowItem["TBPDanhGia"] = "100";
                    }
                    else
                    {
                        rowItem["TBPDanhGia"] = Math.Round(ConvertUtility.ToDouble(row["TBPDanhGia"]), 2);
                    }

                    rowItem["TBPDanhGiaLai"] = Math.Round(ConvertUtility.ToDouble(row["TBPDanhGiaLai"]), 2);
                    rowItem["COODanhGia"] = Math.Round(ConvertUtility.ToDouble(row["COODanhGia"]), 2);

                    dtReturnCongViec.Rows.Add(rowItem);
                }
            }
            return dtReturnCongViec;
        }

        private static DataTable LoadCongViecForCurNewForExport(DataTable dtCongViec, DataRow curItem, DataTable dtReturnCongViec)
        {
            int level = Convert.ToInt32(curItem["Level"]);
            level += 1;
            int ID = Convert.ToInt32(curItem["IDCongViec"]);
            DataRow[] dtChild = GetCongViecByParentID(dtCongViec, ID);
            foreach (DataRow row in dtChild)
            {
                DataRow childItem = dtReturnCongViec.NewRow();
                childItem["ID"] = row["ID"].ToString();
                childItem["IDPhongBan"] = "";
                childItem["TyTrongCV"] = row["TyTrongCV"].ToString().Replace(",", ".");
                childItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString();
                childItem["IDCongViec"] = row["IDCongViec"].ToString();
                childItem["YKienCuaCOO"] = row["YKienCuaCOO"].ToString();

                DataTable dtTen = GetNguoiThamGiaCongViec(ConvertUtility.ToInt32(row["IDDotDanhGia"]), ConvertUtility.ToInt32(row["IDCongViec"]));

                if (dtTen != null && dtTen.Rows.Count > 0)
                {
                    childItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                }
                else
                {
                    childItem["NguoiThamGia"] = "";
                }

                DataRow[] dtChildLevel = GetCongViecByParentID(dtCongViec, ConvertUtility.ToInt32(childItem["IDCongViec"]));

                double TBPDanhGia = 0;
                double COODanhGia = 0;
                if (dtChildLevel.Length > 0)
                {
                    foreach (DataRow rowChild in dtChildLevel)
                    {
                        TBPDanhGia += ConvertUtility.ToDouble(rowChild["TBPDanhGia"]) * ConvertUtility.ToDouble(rowChild["TyTrongCV"]);
                        COODanhGia += ConvertUtility.ToDouble(rowChild["COODanhGia"]) * ConvertUtility.ToDouble(rowChild["TyTrongCV"]);
                    }
                }

                double tyTrongCV = ConvertUtility.ToDouble(childItem["TyTrongCV"]);
                if (tyTrongCV == 0)
                {
                    childItem["TBPDanhGia"] = "100";
                }
                else
                {
                    if (TBPDanhGia > 0)
                    {
                        childItem["TBPDanhGia"] = Math.Round(TBPDanhGia / tyTrongCV, 2).ToString().Replace(",", ".");
                    }
                    else
                    {
                        childItem["TBPDanhGia"] = row["TBPDanhGia"].ToString().ToString().Replace(",", ".");
                    }
                }
                childItem["TBPDanhGiaLai"] = Math.Round(ConvertUtility.ToDouble(row["TBPDanhGiaLai"]), 2).ToString().Replace(",", ".");
                childItem["COODanhGia"] = Math.Round(ConvertUtility.ToDouble(row["COODanhGia"].ToString()), 2).ToString().Replace(",", ".");
                childItem["YeuCauHoTro"] = row["YeuCauHoTro"].ToString().Replace("\n", "<br />");
                childItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString().Replace("\n", "<br />");
                childItem["TenCongViec"] = MiscUtility.StringIndent(level) + row["TenCongViec"].ToString();
                childItem["IDParent"] = row["IDParent"].ToString();
                childItem["Level"] = level.ToString();
                childItem["NgayBatDau"] = ConvertUtility.ToDateTime(row["NgayBatDau"]).ToString("dd/MM/yyyy");
                childItem["NgayKetThuc"] = ConvertUtility.ToDateTime(row["NgayKetThuc"]).ToString("dd/MM/yyyy");

                dtReturnCongViec.Rows.Add(childItem);
                LoadCongViecForCurNewForExport(dtCongViec, childItem, dtReturnCongViec);
            }
            return dtReturnCongViec;
        }

        public static DataTable BuildRecursiveCongViecNewForExport(DataTable dtCongViec, DataTable dtReturnCongViec)
        {
            DataRow[] dtItems = GetCongViecByParentID(dtCongViec, 0);
            if (dtItems.Length > 0)
            {
                foreach (DataRow row in dtItems)
                {
                    DataRow rowItem = dtReturnCongViec.NewRow();
                    rowItem["ID"] = row["ID"].ToString();
                    rowItem["IDPhongBan"] = GetPhongBan(row["IDPhongBan"]).ToString();
                    rowItem["TenCongViec"] = row["TenCongViec"];
                    rowItem["TyTrongCV"] = row["TyTrongCV"].ToString().Replace(",", ".");
                    rowItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString();
                    rowItem["Level"] = "0";
                    rowItem["IDParent"] = row["IDParent"].ToString();
                    rowItem["IDCongViec"] = row["IDCongViec"].ToString();
                    rowItem["YeuCauHoTro"] = row["YeuCauHoTro"].ToString();
                    rowItem["YKienCuaCOO"] = row["YKienCuaCOO"].ToString();
                    rowItem["NgayBatDau"] = ConvertUtility.ToDateTime(row["NgayBatDau"]).ToString("dd/MM/yyyy");
                    rowItem["NgayKetThuc"] = ConvertUtility.ToDateTime(row["NgayKetThuc"]).ToString("dd/MM/yyyy");

                    DataTable dtTen = GetNguoiThamGiaCongViec(ConvertUtility.ToInt32(row["IDDotDanhGia"]), ConvertUtility.ToInt32(row["IDCongViec"]));

                    if (dtTen != null && dtTen.Rows.Count > 0)
                    {
                        rowItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                    }
                    else
                    {
                        rowItem["NguoiThamGia"] = "";
                    }

                    double tyTrongCV = ConvertUtility.ToDouble(row["TyTrongCV"]);

                    if (tyTrongCV == 0)
                    {
                        rowItem["TBPDanhGia"] = "100";
                    }
                    else
                    {
                        rowItem["TBPDanhGia"] = Math.Round(ConvertUtility.ToDouble(row["TBPDanhGia"]), 2).ToString().Replace(",", ".");
                    }

                    rowItem["TBPDanhGiaLai"] = Math.Round(ConvertUtility.ToDouble(row["TBPDanhGiaLai"]), 2).ToString().Replace(",", ".");
                    rowItem["COODanhGia"] = Math.Round(ConvertUtility.ToDouble(row["COODanhGia"]), 2).ToString().Replace(",", ".");

                    dtReturnCongViec.Rows.Add(rowItem);
                    LoadCongViecForCurNewForExport(dtCongViec, rowItem, dtReturnCongViec);
                }
            }
            return dtReturnCongViec;
        }

        private static DataTable LoadCongViecForCurNew(DataTable dtCongViec, DataRow curItem, DataTable dtReturnCongViec)
        {
            int level = Convert.ToInt32(curItem["Level"]);
            level += 1;
            int ID = Convert.ToInt32(curItem["IDCongViec"]);
            DataRow[] dtChild = GetCongViecByParentID(dtCongViec, ID);
            foreach (DataRow row in dtChild)
            {
                DataRow childItem = dtReturnCongViec.NewRow();
                childItem["ID"] = row["ID"].ToString();
                childItem["TyTrongCV"] = row["TyTrongCV"].ToString();
                childItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString();
                childItem["IDCongViec"] = row["IDCongViec"].ToString();
                childItem["YKienCuaCOO"] = row["YKienCuaCOO"].ToString();
                childItem["IDPhongBan"] = row["IDPhongBan"].ToString();
                childItem["NgayBatDau"] = ConvertUtility.ToDateTime(row["NgayBatDau"]).ToString("dd/MM/yyyy");
                childItem["NgayKetThuc"] = ConvertUtility.ToDateTime(row["NgayKetThuc"]).ToString("dd/MM/yyyy");
                DataTable dtTen = GetNguoiThamGiaCongViec(ConvertUtility.ToInt32(row["IDDotDanhGia"]), ConvertUtility.ToInt32(row["IDCongViec"]));

                if (dtTen != null && dtTen.Rows.Count > 0)
                {
                    childItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                }
                else
                {
                    childItem["NguoiThamGia"] = "";
                }

                if (ConvertUtility.ToInt32(childItem["IDCongViec"]) == 1661)
                {
                    string test = "aaa";
                }
                DataRow[] dtChildLevel = GetCongViecByParentID(dtCongViec, ConvertUtility.ToInt32(childItem["IDCongViec"]));

                double TBPDanhGia = 0;
                double COODanhGia = 0;
                if (dtChildLevel.Length > 0)
                {
                    childItem["HasChild"] = "1";
                    foreach (DataRow rowChild in dtChildLevel)
                    {
                        double tbpDanhGia = ConvertUtility.ToDouble(rowChild["TBPDanhGia"]);
                        double tytrongcv = ConvertUtility.ToDouble(rowChild["TyTrongCV"]);
                        double tytrong = ConvertUtility.ToDouble(rowChild["TBPDanhGia"]) * ConvertUtility.ToDouble(rowChild["TyTrongCV"]);
                        TBPDanhGia += tytrong;// Math.Round(ConvertUtility.ToDouble(rowChild["TBPDanhGia"]) * ConvertUtility.ToDouble(rowChild["TyTrongCV"]), 3);
                        COODanhGia += tytrong;// Math.Round(ConvertUtility.ToDouble(rowChild["COODanhGia"]) * ConvertUtility.ToDouble(rowChild["TyTrongCV"]), 3);
                    }
                }
                else
                {
                    childItem["HasChild"] = "0";
                }
                double tyTrongCV = ConvertUtility.ToDouble(childItem["TyTrongCV"]);
                if (tyTrongCV == 0)
                {
                    childItem["TBPDanhGia"] = "100";
                }
                else
                {
                    if (TBPDanhGia > 0)
                    {
                        childItem["TBPDanhGia"] = "<font color=\"Black\" style=\"font-weight:bold\">" + Math.Round(TBPDanhGia / tyTrongCV, 2) + "%" + "</font>";
                    }
                    else
                    {
                        childItem["TBPDanhGia"] = row["TBPDanhGia"].ToString() + "%";
                    }
                }
                childItem["TBPDanhGiaLai"] = Math.Round(ConvertUtility.ToDouble(row["TBPDanhGiaLai"]), 2);
                childItem["COODanhGia"] = Math.Round(ConvertUtility.ToDouble(row["COODanhGia"].ToString()), 2);
                if (level == 1)
                {
                    childItem["YeuCauHoTro"] = "<font color=\"Black\">" + row["YeuCauHoTro"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["SoLieuCamKet"] = "<font color=\"Black\">" + row["SoLieuCamKet"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + "<font color=\"Black\">" + row["TenCongViec"].ToString() + "</font>";
                }
                else if (level == 2)
                {
                    childItem["YeuCauHoTro"] = "<font color=\"Orange\">" + row["YeuCauHoTro"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["SoLieuCamKet"] = "<font color=\"Orange\">" + row["SoLieuCamKet"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + "<font color=\"Orange\">" + row["TenCongViec"].ToString() + "</font>";
                }
                else if (level == 3)
                {
                    childItem["YeuCauHoTro"] = "<font color=\"Black\">" + row["YeuCauHoTro"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["SoLieuCamKet"] = "<font color=\"Black\">" + row["SoLieuCamKet"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + "<font color=\"Black\">" + row["TenCongViec"].ToString() + "</font>";
                }
                else if (level > 3)
                {
                    childItem["YeuCauHoTro"] = "<font color=\"Gray\">" + row["YeuCauHoTro"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["SoLieuCamKet"] = "<font color=\"Gray\">" + row["SoLieuCamKet"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + "<font color=\"Gray\">" + row["TenCongViec"].ToString() + "</font>";
                }
                childItem["IDParent"] = row["IDParent"].ToString();
                childItem["Level"] = level.ToString();

                dtReturnCongViec.Rows.Add(childItem);
                LoadCongViecForCurNew(dtCongViec, childItem, dtReturnCongViec);
            }
            return dtReturnCongViec;
        }


        public static DataTable BuildRecursiveCongViec(DataTable dtCongViec, DataTable dtReturnCongViec)
        {
            DataRow[] dtItems = GetCongViecByParentID(dtCongViec, 0);
            foreach (DataRow row in dtItems)
            {
                DataRow rowItem = dtReturnCongViec.NewRow();
                rowItem["ID"] = row["ID"].ToString();
                rowItem["TenCongViec"] = "<font color=\"Black\" style=\"font-weight:bold\">" + row["TenCongViec"].ToString() + "</font>";
                rowItem["TyTrongCV"] = row["TyTrongCV"].ToString();
                rowItem["SoLieuCamKet"] = "<font color=\"Black\" style=\"font-weight:bold\">" + row["SoLieuCamKet"].ToString() + "</font>";
                rowItem["Level"] = "0";
                rowItem["IDParent"] = row["IDParent"].ToString();
                rowItem["IDCongViec"] = row["IDCongViec"].ToString();
                rowItem["YeuCauHoTro"] = row["YeuCauHoTro"].ToString();
                rowItem["YKienCuaCOO"] = row["YKienCuaCOO"].ToString();

                DataTable dtTen = GetNguoiThamGiaCongViec(ConvertUtility.ToInt32(row["IDDotDanhGia"]), ConvertUtility.ToInt32(row["IDCongViec"]));

                if (dtTen != null && dtTen.Rows.Count > 0)
                {
                    rowItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                }
                else
                {
                    rowItem["NguoiThamGia"] = "";
                }

                double tyTrongCV = ConvertUtility.ToDouble(row["TyTrongCV"]);

                if (tyTrongCV == 0)
                {
                    rowItem["TBPDanhGia"] = "100";
                }
                else
                {
                    rowItem["TBPDanhGia"] = Math.Round(ConvertUtility.ToDouble(row["TBPDanhGia"]), 2);

                }

                rowItem["COODanhGia"] = Math.Round(ConvertUtility.ToDouble(row["COODanhGia"]), 2);

                dtReturnCongViec.Rows.Add(rowItem);
                LoadCongViecForCur(dtCongViec, rowItem, dtReturnCongViec);
            }

            return dtReturnCongViec;
        }

        private static DataRow[] GetCongViecByParentID(DataTable dtCongViec, int parentID)
        {
            DataRow[] retVal = null;
            retVal = dtCongViec.Select("IDParent = '" + parentID + "'");
            return retVal;
        }
        private static DataTable GetMaNhomCongViec(int idCongViec)
        {
            return DataAccessProvider.Instance().GetMaNhomCongViec(idCongViec);
        }
        private static DataTable GetNguoiThamGiaCongViec(int idDotDanhGia, int idCongViec)
        {
            return DataAccessProvider.Instance().GetNguoiThamGiaCongViec(idDotDanhGia, idCongViec);
        }
        public static DataTable GetNguoiThamGiaCongViecKTXVaPS(int idDotDanhGia, int idCongViec)
        {
            return DataAccessProvider.Instance().GetNguoiThamGiaCongViecKTXVaPS(idDotDanhGia, idCongViec);
        }

        private static DataTable LoadKeHoachCongViecForCur(DataTable dtCongViec, DataRow curItem, DataTable dtReturnCongViec)
        {
            int level = Convert.ToInt32(curItem["Level"]);
            level += 1;
            int ID = Convert.ToInt32(curItem["IDCongViec"]);
            DataRow[] dtChild = GetCongViecByParentID(dtCongViec, ID);
            foreach (DataRow row in dtChild)
            {
                DataRow childItem = dtReturnCongViec.NewRow();
                childItem["ID"] = row["ID"].ToString();
                childItem["TyTrongCV"] = row["TyTrongCV"].ToString();
                childItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString();
                childItem["IDCongViec"] = row["IDCongViec"].ToString();

                DataTable dtTen = GetNguoiThamGiaCongViec(ConvertUtility.ToInt32(row["IDDotDanhGia"]), ConvertUtility.ToInt32(row["IDCongViec"]));

                if (dtTen != null && dtTen.Rows.Count > 0)
                {
                    childItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                }
                else
                {
                    childItem["NguoiThamGia"] = "";
                }

                if (level == 1)
                {
                    childItem["YeuCauHoTro"] = "<font color=\"Black\">" + row["YeuCauHoTro"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["SoLieuCamKet"] = "<font color=\"Black\">" + row["SoLieuCamKet"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + "<font color=\"Black\">" + row["TenCongViec"].ToString() + "</font>";
                }
                else if (level == 2)
                {
                    childItem["YeuCauHoTro"] = "<font color=\"Orange\">" + row["YeuCauHoTro"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["SoLieuCamKet"] = "<font color=\"Orange\">" + row["SoLieuCamKet"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + "<font color=\"Orange\">" + row["TenCongViec"].ToString() + "</font>";
                }
                else if (level == 3)
                {
                    childItem["YeuCauHoTro"] = "<font color=\"Black\">" + row["YeuCauHoTro"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["SoLieuCamKet"] = "<font color=\"Black\">" + row["SoLieuCamKet"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + "<font color=\"Black\">" + row["TenCongViec"].ToString() + "</font>";
                }
                else if (level > 3)
                {
                    childItem["YeuCauHoTro"] = "<font color=\"Gray\">" + row["YeuCauHoTro"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["SoLieuCamKet"] = "<font color=\"Gray\">" + row["SoLieuCamKet"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + "<font color=\"Gray\">" + row["TenCongViec"].ToString() + "</font>";
                }
                childItem["IDParent"] = row["IDParent"].ToString();
                childItem["Level"] = level.ToString();
                childItem["IDPhongBan"] = row["IDPhongBan"].ToString();

                dtReturnCongViec.Rows.Add(childItem);
                LoadKeHoachCongViecForCur(dtCongViec, childItem, dtReturnCongViec);
            }
            return dtReturnCongViec;
        }
        private static DataTable LoadKeHoachCongViecForCurNew(DataTable dtCongViec, DataRow curItem, DataTable dtReturnCongViec)
        {
            int level = Convert.ToInt32(curItem["Level"]);
            level += 1;
            int ID = Convert.ToInt32(curItem["IDCongViec"]);
            DataRow[] dtChild = GetCongViecByParentID(dtCongViec, ID);
            foreach (DataRow row in dtChild)
            {
                DataRow childItem = dtReturnCongViec.NewRow();
                childItem["ID"] = row["ID"].ToString();
                childItem["TyTrongCV"] = row["TyTrongCV"].ToString();
                childItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString();
                childItem["IDCongViec"] = row["IDCongViec"].ToString();
                childItem["NgayBatDau"] = row["NgayBatDau"].ToString();
                childItem["NgayKetThuc"] = row["NgayKetThuc"].ToString();
                DataTable dtTen = GetNguoiThamGiaCongViec(ConvertUtility.ToInt32(row["IDDotDanhGia"]), ConvertUtility.ToInt32(row["IDCongViec"]));

                if (dtTen != null && dtTen.Rows.Count > 0)
                {
                    childItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                }
                else
                {
                    childItem["NguoiThamGia"] = "";
                }

                if (level == 1)
                {
                    childItem["YeuCauHoTro"] = "<font color=\"Black\">" + row["YeuCauHoTro"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["SoLieuCamKet"] = "<font color=\"Black\">" + row["SoLieuCamKet"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + "<font color=\"Black\">" + row["TenCongViec"].ToString() + "</font>";
                }
                else if (level == 2)
                {
                    childItem["YeuCauHoTro"] = "<font color=\"Orange\">" + row["YeuCauHoTro"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["SoLieuCamKet"] = "<font color=\"Orange\">" + row["SoLieuCamKet"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + "<font color=\"Orange\">" + row["TenCongViec"].ToString() + "</font>";
                }
                else if (level == 3)
                {
                    childItem["YeuCauHoTro"] = "<font color=\"Black\">" + row["YeuCauHoTro"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["SoLieuCamKet"] = "<font color=\"Black\">" + row["SoLieuCamKet"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + "<font color=\"Black\">" + row["TenCongViec"].ToString() + "</font>";
                }
                else if (level > 3)
                {
                    childItem["YeuCauHoTro"] = "<font color=\"Gray\">" + row["YeuCauHoTro"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["SoLieuCamKet"] = "<font color=\"Gray\">" + row["SoLieuCamKet"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + "<font color=\"Gray\">" + row["TenCongViec"].ToString() + "</font>";
                }
                childItem["IDParent"] = row["IDParent"].ToString();
                childItem["Level"] = level.ToString();
                childItem["IDPhongBan"] = row["IDPhongBan"].ToString();

                dtReturnCongViec.Rows.Add(childItem);
                LoadKeHoachCongViecForCurNew(dtCongViec, childItem, dtReturnCongViec);
            }
            return dtReturnCongViec;
        }
        private static DataTable LoadKeHoachCongViecForCurForExport(DataTable dtCongViec, DataRow curItem, DataTable dtReturnCongViec)
        {
            int level = Convert.ToInt32(curItem["Level"]);
            level += 1;
            int ID = Convert.ToInt32(curItem["IDCongViec"]);
            DataRow[] dtChild = GetCongViecByParentID(dtCongViec, ID);
            foreach (DataRow row in dtChild)
            {
                DataRow childItem = dtReturnCongViec.NewRow();
                childItem["ID"] = row["ID"].ToString();
                childItem["IDPhongBan"] = "";
                childItem["TyTrongCV"] = row["TyTrongCV"].ToString().Replace(",", ".");
                childItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString();
                childItem["IDCongViec"] = row["IDCongViec"].ToString();

                DataTable dtTen = GetNguoiThamGiaCongViec(ConvertUtility.ToInt32(row["IDDotDanhGia"]), ConvertUtility.ToInt32(row["IDCongViec"]));

                if (dtTen != null && dtTen.Rows.Count > 0)
                {
                    childItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                }
                else
                {
                    childItem["NguoiThamGia"] = "";
                }

                if (level == 1)
                {
                    childItem["YeuCauHoTro"] = row["YeuCauHoTro"].ToString().Replace("\n", "<br />");
                    childItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString().Replace("\n", "<br />");
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + row["TenCongViec"].ToString();
                }
                else if (level == 2)
                {
                    childItem["YeuCauHoTro"] = row["YeuCauHoTro"].ToString().Replace("\n", "<br />");
                    childItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString().Replace("\n", "<br />");
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + row["TenCongViec"].ToString();
                }
                else if (level == 3)
                {
                    childItem["YeuCauHoTro"] = row["YeuCauHoTro"].ToString().Replace("\n", "<br />");
                    childItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString().Replace("\n", "<br />");
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + row["TenCongViec"].ToString();
                }
                else if (level > 3)
                {
                    childItem["YeuCauHoTro"] = row["YeuCauHoTro"].ToString().Replace("\n", "<br />");
                    childItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString().Replace("\n", "<br />");
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + "<font color=\"Gray\">" + row["TenCongViec"].ToString();
                }
                childItem["IDParent"] = row["IDParent"].ToString();
                childItem["Level"] = level.ToString();

                dtReturnCongViec.Rows.Add(childItem);
                LoadKeHoachCongViecForCurForExport(dtCongViec, childItem, dtReturnCongViec);
            }
            return dtReturnCongViec;
        }
        private static DataTable LoadKeHoachCongViecForCurForExportNew(DataTable dtCongViec, DataRow curItem, DataTable dtReturnCongViec)
        {
            int level = Convert.ToInt32(curItem["Level"]);
            level += 1;
            int ID = Convert.ToInt32(curItem["IDCongViec"]);
            DataRow[] dtChild = GetCongViecByParentID(dtCongViec, ID);
            foreach (DataRow row in dtChild)
            {
                DataRow childItem = dtReturnCongViec.NewRow();
                childItem["ID"] = row["ID"].ToString();
                childItem["IDPhongBan"] = "";
                childItem["TyTrongCV"] = row["TyTrongCV"].ToString().Replace(",", ".");
                childItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString();
                childItem["IDCongViec"] = row["IDCongViec"].ToString();
                childItem["NgayBatDau"] = ConvertUtility.ToDateTime(row["NgayBatDau"]).ToString("dd/MM/yyyy");
                childItem["NgayKetThuc"] = ConvertUtility.ToDateTime(row["NgayKetThuc"]).ToString("dd/MM/yyyy");
                DataTable dtTen = GetNguoiThamGiaCongViec(ConvertUtility.ToInt32(row["IDDotDanhGia"]), ConvertUtility.ToInt32(row["IDCongViec"]));

                if (dtTen != null && dtTen.Rows.Count > 0)
                {
                    childItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                }
                else
                {
                    childItem["NguoiThamGia"] = "";
                }

                if (level == 1)
                {
                    childItem["YeuCauHoTro"] = row["YeuCauHoTro"].ToString().Replace("\n", "<br />");
                    childItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString().Replace("\n", "<br />");
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + row["TenCongViec"].ToString();
                }
                else if (level == 2)
                {
                    childItem["YeuCauHoTro"] = row["YeuCauHoTro"].ToString().Replace("\n", "<br />");
                    childItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString().Replace("\n", "<br />");
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + row["TenCongViec"].ToString();
                }
                else if (level == 3)
                {
                    childItem["YeuCauHoTro"] = row["YeuCauHoTro"].ToString().Replace("\n", "<br />");
                    childItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString().Replace("\n", "<br />");
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + row["TenCongViec"].ToString();
                }
                else if (level > 3)
                {
                    childItem["YeuCauHoTro"] = row["YeuCauHoTro"].ToString().Replace("\n", "<br />");
                    childItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString().Replace("\n", "<br />");
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + "<font color=\"Gray\">" + row["TenCongViec"].ToString();
                }
                childItem["IDParent"] = row["IDParent"].ToString();
                childItem["Level"] = level.ToString();

                dtReturnCongViec.Rows.Add(childItem);
                LoadKeHoachCongViecForCurForExportNew(dtCongViec, childItem, dtReturnCongViec);
            }
            return dtReturnCongViec;
        }
        private static DataTable LoadCongViecForCur(DataTable dtCongViec, DataRow curItem, DataTable dtReturnCongViec)
        {
            int level = Convert.ToInt32(curItem["Level"]);
            level += 1;
            int ID = Convert.ToInt32(curItem["IDCongViec"]);
            DataRow[] dtChild = GetCongViecByParentID(dtCongViec, ID);
            foreach (DataRow row in dtChild)
            {
                DataRow childItem = dtReturnCongViec.NewRow();
                childItem["ID"] = row["ID"].ToString();
                childItem["TyTrongCV"] = row["TyTrongCV"].ToString();
                childItem["SoLieuCamKet"] = row["SoLieuCamKet"].ToString();
                childItem["IDCongViec"] = row["IDCongViec"].ToString();
                childItem["YKienCuaCOO"] = row["YKienCuaCOO"].ToString();

                DataTable dtTen = GetNguoiThamGiaCongViec(ConvertUtility.ToInt32(row["IDDotDanhGia"]), ConvertUtility.ToInt32(row["IDCongViec"]));

                if (dtTen != null && dtTen.Rows.Count > 0)
                {
                    childItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                }
                else
                {
                    childItem["NguoiThamGia"] = "";
                }

                DataRow[] dtChildLevel = GetCongViecByParentID(dtCongViec, ConvertUtility.ToInt32(childItem["IDCongViec"]));

                double TBPDanhGia = 0;
                double COODanhGia = 0;
                if (dtChildLevel.Length > 0)
                {
                    foreach (DataRow rowChild in dtChildLevel)
                    {
                        double tbpDanhGia = ConvertUtility.ToDouble(rowChild["TBPDanhGia"]);
                        double tytrongcv = ConvertUtility.ToDouble(rowChild["TyTrongCV"]);
                        double tytrong = ConvertUtility.ToDouble(rowChild["TBPDanhGia"]) * ConvertUtility.ToDouble(rowChild["TyTrongCV"]);
                        TBPDanhGia += tytrong;// Math.Round(ConvertUtility.ToDouble(rowChild["TBPDanhGia"]) * ConvertUtility.ToDouble(rowChild["TyTrongCV"]), 3);
                        COODanhGia += tytrong;// Math.Round(ConvertUtility.ToDouble(rowChild["COODanhGia"]) * ConvertUtility.ToDouble(rowChild["TyTrongCV"]), 3);

                    }
                }

                double tyTrongCV = ConvertUtility.ToDouble(childItem["TyTrongCV"]);
                if (tyTrongCV == 0)
                {
                    childItem["TBPDanhGia"] = "100";
                }
                else
                {

                    if (TBPDanhGia > 0)
                    {
                        childItem["TBPDanhGia"] = "<font color=\"Black\" style=\"font-weight:bold\">" + Math.Round(TBPDanhGia / tyTrongCV, 2) + "%" + "</font>";
                    }
                    else
                    {
                        childItem["TBPDanhGia"] = row["TBPDanhGia"].ToString() + "%";
                    }
                }
                childItem["COODanhGia"] = row["COODanhGia"].ToString();
                if (level == 1)
                {
                    childItem["YeuCauHoTro"] = "<font color=\"Black\">" + row["YeuCauHoTro"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["SoLieuCamKet"] = "<font color=\"Black\">" + row["SoLieuCamKet"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + "<font color=\"Black\">" + row["TenCongViec"].ToString() + "</font>";
                }
                else if (level == 2)
                {
                    childItem["YeuCauHoTro"] = "<font color=\"Orange\">" + row["YeuCauHoTro"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["SoLieuCamKet"] = "<font color=\"Orange\">" + row["SoLieuCamKet"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + "<font color=\"Orange\">" + row["TenCongViec"].ToString() + "</font>";
                }
                else if (level == 3)
                {
                    childItem["YeuCauHoTro"] = "<font color=\"Black\">" + row["YeuCauHoTro"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["SoLieuCamKet"] = "<font color=\"Black\">" + row["SoLieuCamKet"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + "<font color=\"Black\">" + row["TenCongViec"].ToString() + "</font>";
                }
                else if (level > 3)
                {
                    childItem["YeuCauHoTro"] = "<font color=\"Gray\">" + row["YeuCauHoTro"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["SoLieuCamKet"] = "<font color=\"Gray\">" + row["SoLieuCamKet"].ToString().Replace("\n", "<br />") + "</font>";
                    childItem["TenCongViec"] = MiscUtility.StringIndent(level) + "<font color=\"Gray\">" + row["TenCongViec"].ToString() + "</font>";
                }
                childItem["IDParent"] = row["IDParent"].ToString();
                childItem["Level"] = level.ToString();

                dtReturnCongViec.Rows.Add(childItem);
                LoadCongViecForCur(dtCongViec, childItem, dtReturnCongViec);
            }
            return dtReturnCongViec;
        }

        public static DataTable BuildRecursiveKeHoachCongViecBoPhanExport(DataTable dtCongViec, DataTable dtReturnCongViec, int idDotDanhGia, DateTime ngaybatdau, int i, out int returnIndex)
        {
            int songay = DateTime.DaysInMonth(ngaybatdau.Year, ngaybatdau.Month);
            int returnIndexTemp = i;
            DateTime _NgayBatDau, _NgayKetThuc;

            DataRow[] dtLevel0 = GetCongViecByParentID(dtCongViec, 0);

            foreach (DataRow row in dtLevel0)
            {
                DataRow rowItem = dtReturnCongViec.NewRow();

                rowItem["ID"] = row["ID"].ToString();
                rowItem["IDPhongBan"] = GetPhongBan(row["IDPhongBan"]);
                rowItem["IDParent"] = row["IDParent"].ToString();
                rowItem["Level"] = "0";
                rowItem["IDCongViec"] = row["IDCongViec"].ToString();
                if (ConvertUtility.ToString(row["TuanLamViec"]) != "")
                {
                    rowItem["Tuan"] = row["TuanLamViec"].ToString();
                }
                else
                {
                    rowItem["Tuan"] = "Đang cập nhật";
                }
                DataTable dtTen = GetNguoiThamGiaCongViec(idDotDanhGia, ConvertUtility.ToInt32(row["IDCongViec"]));

                if (dtTen != null && dtTen.Rows.Count > 0)
                {
                    if (ConvertUtility.ToString(dtTen.Rows[0]["Ten"]) != "")
                    {
                        rowItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                    }
                    else
                    {
                        rowItem["NguoiThamGia"] = "Đang cập nhật";
                    }
                }
                else
                {
                    rowItem["NguoiThamGia"] = "Đang cập nhật";
                }
                rowItem["STT"] = returnIndexTemp;
                DataTable dtMaNhom = GetMaNhomCongViec(ConvertUtility.ToInt32(row["IDCongViec"]));
                string MaNhom = "[]";
                if (dtMaNhom != null && dtMaNhom.Rows.Count > 0)
                {
                    MaNhom = "[" + dtMaNhom.Rows[0]["Ma"].ToString() + "] ";
                }
                rowItem["TenCongViec"] = MaNhom + row["TenCongViec"].ToString();

                _NgayBatDau = ConvertUtility.ToDateTime(row["NgayBatDau"]);
                _NgayKetThuc = ConvertUtility.ToDateTime(row["NgayKetThuc"]);

                for (int day = 1; day < songay + 1; day++)
                {
                    string dateString = day + "/" + ngaybatdau.Month + "/" + ngaybatdau.Year;
                    DateTime dateValue = DateTime.Parse(dateString, new CultureInfo("fr-FR"));

                    int weekOfMonth = new DateConverter().GetWeekOfMonth(dateValue);
                    int dayOfWeek = (int)dateValue.DayOfWeek;

                    if (dayOfWeek == 0) continue;
                    dayOfWeek = dayOfWeek + 1;

                    if (dayOfWeek <= 8)
                    {
                        string trangThaiCV = GetTrangThai(ConvertUtility.ToInt32(row["TrangThaiCV"]));
                        string commentTT = GetCongViecCommentTT(ConvertUtility.ToInt32(row["IDCongViec"]), idDotDanhGia, dateValue);
                        string commentTK = "";// GetCongViecCommentTK(ConvertUtility.ToInt32(row["IDCongViec"]), idDotDanhGia, dateValue);

                        string TK = "";
                        if (dateValue >= _NgayBatDau && dateValue <= _NgayKetThuc)
                        {
                            TK = "TK";
                            if (ConvertUtility.ToInt32(row["TrangThaiCV"]) == 1)
                            {
                                trangThaiCV = "X";
                            }
                            else
                            {
                                if (commentTT != "")
                                {
                                    trangThaiCV = "PS";
                                }
                                else
                                {
                                    TK = "";
                                    trangThaiCV = "";
                                }
                            }
                        }
                        else if (dateValue > _NgayKetThuc)
                        {
                            TK = "";
                            trangThaiCV = "";
                            commentTT = "";
                        }
                        else
                        {
                            if (commentTT != "")
                            {
                                TK = "TK";
                                trangThaiCV = "PS";
                            }
                            else
                            {
                                TK = "";
                                trangThaiCV = "";
                                commentTT = "";
                            }
                        }

                        rowItem["T" + weekOfMonth + "_T" + dayOfWeek] = TK;
                        rowItem["T" + weekOfMonth + "_T" + dayOfWeek + "_TK"] = commentTK;
                        rowItem["T" + weekOfMonth + "_T" + dayOfWeek + "_Status"] = trangThaiCV;
                        rowItem["T" + weekOfMonth + "_T" + dayOfWeek + "_TT"] = commentTT;

                        //if (dayOfWeek >= 6)
                        //{
                        //    if (dayOfWeek == 6)
                        //    {
                                if (commentTT != "")
                                {
                                    rowItem["T" + weekOfMonth + "_KQ"] = commentTT;
                                }
                        //        else
                        //        {
                        //            rowItem["T" + weekOfMonth + "_KQ"] = "";
                        //        }
                        //    }
                        //    else 
                        //    {
                        //        if (dayOfWeek == 7)
                        //        {
                        //            if (commentTT != "")
                        //            {
                        //                rowItem["T" + weekOfMonth + "_KQ"] = commentTT;
                        //            }
                        //        }
                        //        else 
                        //        {
                        //            if (commentTT != "")
                        //            {
                        //                rowItem["T" + weekOfMonth + "_KQ"] = commentTT;
                        //            }
                        //        }
                        //    }                            
                        //}
                        //else 
                        //{
                        //    rowItem["T" + weekOfMonth + "_KQ"] = "";
                        //}
                    }
                }
               
                rowItem["KQT"] = GetCongViecCamKetHT(ConvertUtility.ToInt32(row["IDCongViec"]), idDotDanhGia);
                dtReturnCongViec.Rows.Add(rowItem);
                returnIndexTemp++;


                LoadKeHoachCongViecForCurBoPhanExport(dtCongViec, rowItem, dtReturnCongViec, idDotDanhGia, ngaybatdau, returnIndexTemp, out returnIndexTemp);

            }
            returnIndex = returnIndexTemp;
            return dtReturnCongViec;
        }

        private static DataTable LoadKeHoachCongViecForCurBoPhanExport(DataTable dtCongViec, DataRow curItem, DataTable dtReturnCongViec, int idDotDanhGia, DateTime ngaybatdau, int i, out int returnIndex)
        {
            int returnIndexTemp = i;
            int songay = DateTime.DaysInMonth(ngaybatdau.Year, ngaybatdau.Month);
            DateTime _NgayBatDau, _NgayKetThuc;

            int level = Convert.ToInt32(curItem["Level"]);
            level += 1;
            int ID = Convert.ToInt32(curItem["IDCongViec"]);
            DataRow[] dtChild = GetCongViecByParentID(dtCongViec, ID);
            foreach (DataRow row in dtChild)
            {
                DataRow rowItem = dtReturnCongViec.NewRow();
                rowItem["ID"] = row["ID"].ToString();
                rowItem["IDPhongBan"] = GetPhongBan(row["IDPhongBan"]);
                rowItem["IDParent"] = row["IDParent"].ToString();
                rowItem["Level"] = level.ToString();
                rowItem["IDCongViec"] = row["IDCongViec"].ToString();
                if (ConvertUtility.ToString(row["TuanLamViec"]) != "")
                {
                    rowItem["Tuan"] = row["TuanLamViec"].ToString();
                }
                else
                {
                    rowItem["Tuan"] = "Đang cập nhật";
                }
                DataTable dtTen = GetNguoiThamGiaCongViec(idDotDanhGia, ConvertUtility.ToInt32(row["IDCongViec"]));

                if (dtTen != null && dtTen.Rows.Count > 0)
                {
                    if (ConvertUtility.ToString(dtTen.Rows[0]["Ten"]) != "")
                    {
                        rowItem["NguoiThamGia"] = dtTen.Rows[0]["Ten"].ToString();
                    }
                    else
                    {
                        rowItem["NguoiThamGia"] = "Đang cập nhật";
                    }
                }
                else
                {
                    rowItem["NguoiThamGia"] = "Đang cập nhật";
                }
                rowItem["STT"] = i;

                if (level == 1)
                {
                    rowItem["TenCongViec"] = MiscUtility.StringIndent(level) + row["TenCongViec"].ToString();
                }
                else if (level == 2)
                {
                    rowItem["TenCongViec"] = MiscUtility.StringIndent(level) + row["TenCongViec"].ToString();
                }
                else if (level == 3)
                {
                    rowItem["TenCongViec"] = MiscUtility.StringIndent(level) + row["TenCongViec"].ToString();
                }
                else if (level > 3)
                {
                    rowItem["TenCongViec"] = MiscUtility.StringIndent(level) + row["TenCongViec"].ToString();
                }

                _NgayBatDau = ConvertUtility.ToDateTime(row["NgayBatDau"]);
                _NgayKetThuc = ConvertUtility.ToDateTime(row["NgayKetThuc"]);

                for (int day = 1; day < songay + 1; day++)
                {
                    string dateString = day + "/" + ngaybatdau.Month + "/" + ngaybatdau.Year;
                    DateTime dateValue = DateTime.Parse(dateString, new CultureInfo("fr-FR"));

                    int weekOfMonth = new DateConverter().GetWeekOfMonth(dateValue);
                    int dayOfWeek = DateConverter.GetDayOfWeek(dateValue.DayOfWeek.ToString());

                    if (dayOfWeek <= 8)
                    {
                        string trangThaiCV = GetTrangThai(ConvertUtility.ToInt32(row["TrangThaiCV"]));
                        string commentTT = GetCongViecCommentTT(ConvertUtility.ToInt32(row["IDCongViec"]), idDotDanhGia, dateValue);
                        string commentTK = "";//GetCongViecCommentTK(ConvertUtility.ToInt32(row["IDCongViec"]), idDotDanhGia, dateValue);

                        string TK = "";
                        if (dateValue >= _NgayBatDau && dateValue <= _NgayKetThuc)
                        {
                            if (dateValue.Year == _NgayKetThuc.Year && dateValue.Month == _NgayKetThuc.Month && dateValue.Day == _NgayKetThuc.Day)
                            {
                                TK = "HT";
                            }
                            else
                            {
                                TK = "TK";
                            }
                            if (ConvertUtility.ToInt32(row["TrangThaiCV"]) == 1)
                            {
                                trangThaiCV = "X";
                            }
                            else
                            {
                                if (commentTT != "")
                                {
                                    trangThaiCV = "PS";
                                }
                                else
                                {
                                    trangThaiCV = "";
                                }
                            }
                        }
                        else if (dateValue > _NgayKetThuc)
                        {
                            TK = "";
                            trangThaiCV = "";
                            commentTT = "";
                        }
                        else
                        {
                            if (commentTT != "")
                            {
                                TK = "";
                                trangThaiCV = "PS";
                            }
                            else
                            {
                                TK = "";
                                trangThaiCV = "";
                                commentTT = "";
                            }
                        }
                        rowItem["T" + weekOfMonth + "_T" + dayOfWeek] = TK;
                        rowItem["T" + weekOfMonth + "_T" + dayOfWeek + "_TK"] = commentTK;
                        rowItem["T" + weekOfMonth + "_T" + dayOfWeek + "_Status"] = trangThaiCV;
                        rowItem["T" + weekOfMonth + "_T" + dayOfWeek + "_TT"] = commentTT;

                        //if (dayOfWeek >= 6)
                        //{
                        //    if (dayOfWeek == 6)
                        //    {
                                if (commentTT != "")
                                {
                                    rowItem["T" + weekOfMonth + "_KQ"] = commentTT;
                                }
                        //        else
                        //        {
                        //            rowItem["T" + weekOfMonth + "_KQ"] = "";
                        //        }
                        //    }
                        //    else
                        //    {
                        //        if (dayOfWeek == 7)
                        //        {
                        //            if (commentTT != "")
                        //            {
                        //                rowItem["T" + weekOfMonth + "_KQ"] = commentTT;
                        //            }
                        //        }
                        //        else
                        //        {
                        //            if (commentTT != "")
                        //            {
                        //                rowItem["T" + weekOfMonth + "_KQ"] = commentTT;
                        //            }
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    rowItem["T" + weekOfMonth + "_KQ"] = "";
                        //}
                    }
                }
                //rowItem["T1_KQ"] = "";
                //rowItem["T2_KQ"] = "";
                //rowItem["T3_KQ"] = "";
                //rowItem["T4_KQ"] = "";
                //rowItem["T5_KQ"] = "";
                rowItem["KQT"] = GetCongViecCamKetHT(ConvertUtility.ToInt32(row["IDCongViec"]), idDotDanhGia);

                dtReturnCongViec.Rows.Add(rowItem);
                i++;
                LoadKeHoachCongViecForCurBoPhanExport(dtCongViec, rowItem, dtReturnCongViec, idDotDanhGia, ngaybatdau, i, out returnIndexTemp);
            }

            returnIndex = returnIndexTemp;
            return dtReturnCongViec;
        }

        private static string GetCongViecCamKetHT(int idCongViec, int idDotDanhGia)
        {
            DataTable dt = QuanLyCongViecKTXVaPSController.KeHoachThang_GetCongViecCamKetHT(idCongViec, idDotDanhGia);
            if (dt != null && dt.Rows.Count > 0)
            {
                return ConvertUtility.ToString(dt.Rows[0][0]);
            }
            return "";
        }

        private static string GetCongViecCommentTT(int idCongViec, int idDotDanhGia, DateTime ngay)
        {
            DataTable dt = QuanLyCongViecKTXVaPSController.KeHoachThang_BaoCaoNgayByCongViecTT(idCongViec, idDotDanhGia, ngay);
            if (dt != null && dt.Rows.Count > 0)
            {
                return ConvertUtility.ToString(dt.Rows[0][0]);
            }
            return "";
        }
        private static string GetCongViecCommentTK(int idCongViec, int idDotDanhGia, DateTime ngay)
        {
            DataTable dt = QuanLyCongViecKTXVaPSController.KeHoachThang_BaoCaoNgayByCongViecTK(idCongViec, idDotDanhGia, ngay);
            if (dt != null && dt.Rows.Count > 0)
            {
                return ConvertUtility.ToString(dt.Rows[0][0]);
            }
            return "";
        }
        private static string GetTrangThai(int trangthai)
        {
            if (trangthai == 1) return "X";
            //if (trangthai == 2) return "PS";
            //if (trangthai == 3) return "PS";
            //if (trangthai == 4) return "C";
            return "PS";
        }
    }
}