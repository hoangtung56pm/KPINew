<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhGiaCBCNV.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.DotDanhGia.CeoDanhGia.LanhDao_HT.DanhGiaCBCNV" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="DanhGiaCBCNV_KyLuat.ascx" TagName="DanhGiaCBCNV_KyLuat" TagPrefix="uc2" %>
<%@ Register Src="DanhGiaCBCNV_DichVuKhachHangDiemThuongPhat.ascx" TagName="DanhGiaCBCNV_DichVuKhachHangDiemThuongPhat"
    TagPrefix="uc3" %>
<style>
    .tabbable-custom.boxless > .tab-content
    {
        padding: 0px 0;
        border-left: none;
        border-right: none;
        border-bottom: none;
    }
</style>
<div class="row">
    <div class="col-md-12">
        <div class="tabbable tabbable-custom boxless">
            <table align="center" id="tableAlert" runat="server" cellpadding="0" cellspacing="0"
                border="0" width="100%">
                <tr>
                    <td align="center" style="font-size: 14px; color: Blue; font-weight: bold" class="InputBox">
                        Bạn chưa đủ điều kiện để tham gia đợt đánh giá này. Xin vui lòng liên hệ phòng HCNS
                        để được hỗ trợ.
                    </td>
                </tr>
            </table>
            <table align="center" id="tableContent" runat="server" cellpadding="0" cellspacing="0"
                border="0" width="100%">
                <tr>
                    <td style="height: 5px">
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table class="InputBox" cellpadding="5" style="width: 100%;">
                            <tr>
                                <td>
                                    Kết quả đánh giá của bạn
                                    <asp:Label ID="lblName" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    <b>Chú ý:</b> được chấm điểm lẻ đến 0.5 (lưu ý là dùng dấu "chấm" khi để điểm lẻ)
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 15px">
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table class="InputBox" cellpadding="5" style="width: 100%;">
                            <tr>
                                <td align="center" valign="top">
                                    <b style="color: #dede">Điểm đánh giá đơn vị
                                        <br />
                                        (60%)</b>
                                </td>
                                <td align="center" valign="top">
                                    <b style="color: #dede">Lợi nhuận công ty
                                        <br />
                                        (15%)</b>
                                </td>
                                <td align="center" valign="top">
                                    <b style="color: #dede">Khối lượng công việc
                                        <br />
                                        (15%)</b>
                                </td>
                                <td align="center" valign="top">
                                    <b style="color: #dede">Quản lý công việc, chủ động, làm việc nhóm
                                        <br />
                                        (5%)</b>
                                </td>
                                <td align="center" valign="top">
                                    <b style="color: #dede">Kỷ luật cá nhân
                                        <br />
                                        (5%)</b>
                                </td>
                                <td align="center" valign="top">
                                    <b style="color: #dede">Điểm thưởng</b>
                                </td>
                                <td align="center" valign="top">
                                    <b style="color: #dede">Mức độ hoàn thành</b>
                                </td>
                                <td align="center" valign="top">
                                    <b style="color: #dede">Xếp loại</b>
                                </td>
                                <td align="center" valign="top">
                                    <b style="color: #dede">Hệ số lương mềm</b>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="color: Blue">
                                    <b>
                                        <asp:Label ID="lblDiemDanhGiaDonVi" runat="server"></asp:Label></b>
                                </td>
                                <td align="center" style="color: Blue">
                                    <b>
                                        <asp:Label ID="lblDiemHoanThanhLoiNhuanCongTy" runat="server"></asp:Label></b>
                                </td>
                                <td align="center" style="color: Blue">
                                    <b>
                                        <asp:Label ID="lblDiemBLD" runat="server"></asp:Label></b>
                                </td>
                                <td align="center" style="color: Blue">
                                    <b>
                                        <asp:Label ID="lblDiemPhoiHop" runat="server"></asp:Label></b>
                                </td>
                                <td align="center" style="color: Blue">
                                    <b>
                                        <asp:Label ID="lblDiemKyLuat" runat="server"></asp:Label></b>
                                </td>
                                <td align="center" style="color: Blue">
                                    <b>
                                        <asp:Label ID="lblDiemThuong" runat="server"></asp:Label></b>
                                </td>
                                <td align="center" style="color: Blue">
                                    <b>
                                        <asp:Label ID="lblMucDoHoanThanh" runat="server"></asp:Label></b>
                                </td>
                                <td align="center" style="color: Blue">
                                    <b>
                                        <asp:Label ID="lblXepLoai" runat="server"></asp:Label></b>
                                </td>
                                <td align="center" style="color: Blue">
                                    <b>
                                        <asp:Label ID="lblHeSoLuongMem" runat="server"></asp:Label></b>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 15px">
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table cellpadding="5" style="width: 100%;">
                            <tr>
                                <td colspan="7" align="center">
                                    <asp:Button ID="btnSumit" runat="server" CssClass="btn blue" Text="Gửi đánh giá"
                                        OnClick="btnSumit_Click" />
                                    <asp:Button ID="btnYeuCauLamLaiDanhGia" runat="server" CssClass="btn green" Text="Yêu cầu làm lại đánh giá"
                                        OnClick="btnYeuCauLamLaiDanhGia_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 15px">
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table class="InputBox" cellpadding="5" style="width: 100%;">
                            <tr>
                                <td width="120px">
                                    Đợt đánh giá:
                                </td>
                                <td align="left" width="300px">
                                    <asp:DropDownList AutoPostBack="true" CssClass="form-control" Width="300px" ID="dropDotDanhGia"
                                        runat="server" DataTextField="Ten" DataValueField="ID" OnSelectedIndexChanged="dropDotDanhGia_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td colspan="6" align="left">
                                    <table width="100%" cellpadding="5" cellspacing="0">
                                        <tr style="display: none">
                                            <td align="center">
                                                <b>CV thường xuyên</b>
                                            </td>
                                            <td align="center">
                                                <b>CV kế hoạch tháng</b>
                                            </td>
                                            <td align="center" id="tdCVPS" runat="server">
                                                <b>CV Phát sinh</b>
                                            </td>
                                            <td align="center">
                                                <b>Tổng % Công việc</b>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td align="center">
                                                <b style="color: Blue;">
                                                    <asp:Label ID="lblCVTX" runat="server" Font-Bold="true">34%</asp:Label></b>
                                            </td>
                                            <td align="center">
                                                <b style="color: Blue;">
                                                    <asp:Label ID="lblCVKTX" runat="server" Font-Bold="true">34%</asp:Label></b>
                                            </td>
                                            <td align="center" id="tdCVPSValue" runat="server">
                                                <b style="color: Blue;">
                                                    <asp:Label ID="lblCVPhatSinh" runat="server" Font-Bold="true"></asp:Label></b>
                                            </td>
                                            <td align="center">
                                                <b style="color: Blue;">
                                                    <asp:Label ID="lblTotal" runat="server" Font-Bold="true">100%</asp:Label></b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 15px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <ul class="nav nav-tabs">
                            <li class="active"><a data-toggle="tab" href="#tab_0"><b>KHỐI LƯỢNG CÔNG VIỆC</b></a></li>
                            <li class=""><a data-toggle="tab" href="#tab_1"><b>KỶ LUẬT VÀ PHỐI HỢP</b></a></li>
                        </ul>
                        <div class="tab-content">
                            <div id="tab_0" class="tab-pane active">
                                <div class="portlet box grey">
                                    <div class="portlet-body form">
                                        <asp:UpdatePanel ID="updateDanhGiaCBCNV_DichVuKhachHangDiemThuongPhat1" runat="server">
                                            <contenttemplate>
                                                 <uc3:DanhGiaCBCNV_DichVuKhachHangDiemThuongPhat ID="DanhGiaCBCNV_DichVuKhachHangDiemThuongPhat1"
                                        runat="server" />
                                            </contenttemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <div id="tab_1" class="tab-pane">
                                <div class="portlet box grey">
                                    <div class="portlet-body form">
                                        <asp:UpdatePanel ID="updateDanhGiaCBCNV_KyLuat1" runat="server">
                                            <contenttemplate>
                                                <uc2:DanhGiaCBCNV_KyLuat ID="DanhGiaCBCNV_KyLuat1" runat="server" />
                                            </contenttemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
