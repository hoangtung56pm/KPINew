<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DotDanhGia_Config.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.DotDanhGia.DotDanhGia_Config" %>
<%@ Register Assembly="VmgPortal.Library" Namespace="VmgPortal.Library.Controls"
    TagPrefix="cc1" %>
<table id="tblContent" runat="server" border="0" cellpadding="2" cellspacing="2"
    style="width: 100%">
    <tr>
        <td height="10">
        </td>
    </tr>
    <tr>
        <td valign="top" class="InputBox" colspan="7" style="width: 100%;">
            <table width="100%" border="0" cellpadding="5" cellspacing="0">
                <tr>
                    <td width="150px">
                        Chọn đợt đánh giá:
                    </td>
                    <td align="left">
                        <asp:DropDownList AutoPostBack="true" CssClass="form-control" Width="300px" ID="dropDotDanhGia"
                            runat="server" DataTextField="Ten" DataValueField="ID" OnSelectedIndexChanged="dropDotDanhGia_SelectedIndexChanged">
                        </asp:DropDownList>
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
        <td class="InputBox" style="width: 25%; display: none">
            <table border="0" cellpadding="3" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Trung tâm LINGO</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        Doanh thu:
                        <asp:DropDownList ID="dropDoanhThuLINGO" runat="server" DataTextField="DoanhThu"
                            DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Lợi nhuận:
                        <asp:DropDownList ID="dropLoiNhuanLINGO" runat="server" DataTextField="DoanhThu"
                            DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Số lượng đối tác điểm ưu đãi và cung ứng hàng hóa:
                        <asp:TextBox ID="txtDiemUuDiem" runat="server">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Số lượng thẻ duyệt phát hành của Lingo Card:
                        <asp:TextBox ID="txtPhatHanhThe" runat="server">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tổng giá trị giao dịch qua POS của Lingo Card và Lingo Shop:
                        <asp:TextBox ID="txtPos" runat="server">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 25%; display: none">
            <table border="0" cellpadding="3" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Trung tâm PTDV</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        Doanh thu:
                        <asp:DropDownList ID="dropDoanhThuPTDV" runat="server" DataTextField="DoanhThu" DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Lợi nhuận:
                        <asp:DropDownList ID="dropLoiNhuanPTDV" runat="server" DataTextField="DoanhThu" DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 25%; display: none">
            <table border="0" cellpadding="3" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Trung tâm TIEPTHISO</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        Doanh thu:
                        <asp:DropDownList ID="dropDoanhThuTIEPTHISO" runat="server" DataTextField="DoanhThu"
                            DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Lợi nhuận:
                        <asp:DropDownList ID="dropLoiNhuanTIEPTHISO" runat="server" DataTextField="DoanhThu"
                            DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 25%; display: none;">
            <table border="0" cellpadding="3" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Phòng DSTC</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        Doanh thu:
                        <asp:DropDownList ID="dropDoanhThuDSTC" runat="server" DataTextField="DoanhThu" DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Lợi nhuận:
                        <asp:DropDownList ID="dropLoiNhuanDSTC" runat="server" DataTextField="DoanhThu" DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="InputBox" style="width: 25%">
            <table border="0" cellpadding="3" cellspacing="3" style="width: 100%">
                <tr>
                    <td colspan="2">
                        <b>Trung tâm PTND</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        Doanh thu:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDoanhThuPTND" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        %
                    </td>
                </tr>
                <tr>
                    <td>
                        Lợi nhuận:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLoiNhuanPTND" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        %
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td>
                        Điểm doanh thu:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblDiemDT_PTND" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Điểm lợi nhuận:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblDiemLN_PTND" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tổng điểm:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblTongDiem_PTND" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 25%">
            <table border="0" cellpadding="3" cellspacing="3" style="width: 100%">
                <tr>
                    <td colspan="2">
                        <b>Trung tâm LUCKYFONE</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        Doanh thu:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDoanhThuLuckyFone" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        %
                    </td>
                </tr>
                <tr>
                    <td>
                        Lợi nhuận:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLoiNhuanLuckyFone" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        %
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td>
                        Điểm doanh thu:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblDiemDT_LUCK" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Điểm lợi nhuận:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblDiemLN_LUCK" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tổng điểm:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblTongDiem_LUCK" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 25%">
            <table border="0" cellpadding="3" cellspacing="3" style="width: 100%">
                <tr>
                    <td colspan="2">
                        <b>Trung tâm BANQUYEN</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        Doanh thu:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDoanhThuBanQuyen" CssClass="form-control" runat="server"></asp:TextBox>%
                    </td>
                </tr>
                <tr>
                    <td>
                        Lợi nhuận:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLoiNhuanBanQuyen" CssClass="form-control" runat="server"></asp:TextBox>%
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td>
                        Điểm doanh thu:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblDiemDT_BQ" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Điểm lợi nhuận:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblDiemLN_BQ" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tổng điểm:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblTongDiem_BQ" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 25%">
            <table border="0" cellpadding="3" cellspacing="3" style="width: 100%">
                <tr>
                    <td colspan="2">
                        <b>Trung tâm PTKD</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        Doanh thu:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDoanhThuPTKD" CssClass="form-control" runat="server"></asp:TextBox>%
                    </td>
                </tr>
                <tr>
                    <td>
                        Lợi nhuận:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLoiNhuanPTKD" CssClass="form-control" runat="server"></asp:TextBox>%
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td>
                        Điểm doanh thu:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblDiemDT_PTKD" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Điểm lợi nhuận:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblDiemLN_PTKD" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tổng điểm:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblTongDiem_PTKD" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="InputBox" style="width: 25%">
            <table border="0" cellpadding="3" cellspacing="3" style="width: 100%">
                <tr>
                    <td colspan="2">
                        <b>Trung tâm QUANGCAOSO</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        Doanh thu:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDoanhThuQUANGCAOSO" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        %
                    </td>
                </tr>
                <tr>
                    <td>
                        Lợi nhuận:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLoiNhuanQUANGCAOSO" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        %
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td>
                        Điểm doanh thu:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblDiemDT_QUANGCAOSO" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Điểm lợi nhuận:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblDiemLN_QUANGCAOSO" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tổng điểm:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblTongDiem_QUANGCAOSO" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 25%; display:none;">
            <table border="0" cellpadding="3" cellspacing="3" style="width: 100%">
                <tr>
                    <td colspan="2">
                        <b>VPHCM</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        Doanh thu:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDoanhThuVPHCM" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        %
                    </td>
                </tr>
                <tr>
                    <td>
                        Lợi nhuận:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLoiNhuanVPHCM" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        %
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td>
                        Điểm doanh thu:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblDiemDT_VPHCM" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Điểm lợi nhuận:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblDiemLN_VPHCM" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tổng điểm:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblTongDiem_VPHCM" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 25%">
        </td>
        <td class="InputBox" style="width: 25%">
        </td>
    </tr>
    <tr>
        <td class="InputBox" style="width: 25%">
            <table border="0" cellpadding="3" cellspacing="3" style="width: 100%">
                <tr>
                    <td colspan="2">
                        <b>Khối hỗ trợ</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        Doanh thu:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDoanhThuIT" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        %
                    </td>
                </tr>
                <tr>
                    <td>
                        Lợi nhuận:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLoiNhuanIT" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        %
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td>
                        Điểm doanh thu:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblDiemDT" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Điểm lợi nhuận:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblDiemLN" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tổng điểm:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblTongHT" ForeColor="Blue" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 25%" valign="top">
            <table border="0" cellpadding="3" cellspacing="3" style="width: 100%">
                <tr>
                    <td colspan="2">
                        <b style="color: Red">Công thức tính</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <b>Khối kinh doanh</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Điểm doanh thu = DiemDoanhThu * 24 / 100
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Điểm Lợi nhuận = DiemLoiNhuan * 36 / 100
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <b>Khối hỗ trợ</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Điểm doanh thu = DiemDoanhThu * 12 / 100
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Điểm Lợi nhuận = DiemLoiNhuan * 18 / 100
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 25%; display: none;">
            <table border="0" cellpadding="3" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Trung tâm NSHC</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        Doanh thu:
                        <asp:DropDownList ID="dropDoanhThuNSHC" runat="server" DataTextField="DoanhThu" DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Lợi nhuận:
                        <asp:DropDownList ID="dropLoiNhuanNSHC" runat="server" DataTextField="DoanhThu" DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 25%; display: none;">
            <table border="0" cellpadding="3" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Trung tâm TCKT</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        Doanh thu:
                        <asp:DropDownList ID="dropDoanhThuTCKT" runat="server" DataTextField="DoanhThu" DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Lợi nhuận:
                        <asp:DropDownList ID="dropLoiNhuanTCKT" runat="server" DataTextField="DoanhThu" DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 25%; display: none;">
            <table border="0" cellpadding="3" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Trung tâm DVKH</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        Doanh thu:
                        <asp:DropDownList ID="dropDoanhThuDVKH" runat="server" DataTextField="DoanhThu" DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Lợi nhuận:
                        <asp:DropDownList ID="dropLoiNhuanDVKH" runat="server" DataTextField="DoanhThu" DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="InputBox" colspan="7" align="center" height="50px">
            <asp:Button ID="btnUpdate" runat="server" CssClass="btn blue" Text="Cập  nhật" OnClick="btnUpdate_Click" />
        </td>
    </tr>
</table>
