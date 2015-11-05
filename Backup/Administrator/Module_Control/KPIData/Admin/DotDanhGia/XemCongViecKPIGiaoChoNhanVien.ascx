<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="XemCongViecKPIGiaoChoNhanVien.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.DotDanhGia.XemCongViecKPIGiaoChoNhanVien" %>
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
    <tr>
        <td height="10">
        </td>
    </tr>
    <tr>
        <td class="InputBox" align="center">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="border-bottom: 1px solid #333333;">
                        <asp:Repeater ID="rptCongViec" runat="server">
                            <HeaderTemplate>
                                <table border="0" cellpadding="5" cellspacing="0" width="100%">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td width="150px" style="border-top: 1px solid #333333; border-left: 1px solid #333333">
                                        <asp:Label ID="lblTenCongViec" runat="server" Text='<%# Eval("Ten") %>'></asp:Label>
                                    </td>
                                    <td valign="top" style="border-top: 1px solid #333333; border-left: 1px solid #333333;
                                        border-right: 1px solid #333333;">
                                        <asp:DataList ID="dlNhanVien" RepeatDirection="Horizontal" runat="server">
                                            <ItemTemplate>
                                                <table style="border: 1px solid #dedede; font-size: 11px;" cellpadding="5" cellspacing="0"
                                                    width="100%">
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            <asp:Label ID="lblHoTen" ForeColor="Blue" runat="server" Text='<%# Eval("HoTen") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            <asp:Label ID="lblTyTrong" ForeColor="Red" runat="server" Text='<%# Eval("TyTrong") %>'></asp:Label>%
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            <asp:Label ID="lblSoGio" ForeColor="Red" runat="server" Text='<%# Eval("SoGio") %>'></asp:Label>h
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table></FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
