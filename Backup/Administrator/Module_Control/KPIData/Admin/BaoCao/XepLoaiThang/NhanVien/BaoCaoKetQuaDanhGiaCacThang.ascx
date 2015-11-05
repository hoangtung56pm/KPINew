<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BaoCaoKetQuaDanhGiaCacThang.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.BaoCao.XepLoaiThang.NhanVien.BaoCaoKetQuaDanhGiaCacThang" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Import Namespace="VmgPortal.Library.Utilities" %>
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
    <tr>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td valign="top" class="InputBox" style="width: 100%;">
            <table>
                <tr>
                    <td class="textcenter">
                        Kết quả đánh giá của bạn
                        <asp:Label ID="lblName" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
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
        <td class="InputBox">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td height="15px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%" valign="top">
                        <asp:ListBox ID="lstDotDanhGia" SelectionMode="Multiple" Width="250px" runat="server"
                            DataTextField="Ten" DataValueField="ID" Height="300px"></asp:ListBox>
                    </td>
                    <td style="width: 80%" valign="top">
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr>
                                <td align="left" colspan="3">
                                    <asp:Button ID="btnSearch" CssClass="btn blue" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" /><br />
                                </td>
                            </tr>
                            <tr>
                                <td height="5px" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td class="InputBox" style="width: 30%" valign="top">
                                    <table width="100%" cellpadding="5" cellspacing="2">
                                        <tr>
                                            <td style="background-color: #D0D5D9;" colspan="2">
                                                <b style="color: Red">Thông tin cá nhân</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>Họ tên:</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblHoTen" Font-Bold="true" ForeColor="Blue" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>Mã số:</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMaSo" Font-Bold="true" ForeColor="Blue" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>Bộ phận:</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBoPhan" Font-Bold="true" ForeColor="Blue" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>Phòng:</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPhong" Font-Bold="true" ForeColor="Blue" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>Nhóm:</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNhom" Font-Bold="true" ForeColor="Blue" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="InputBox" style="width: 30%" valign="top">
                                    <table width="100%" cellpadding="5" cellspacing="2">
                                        <tr>
                                            <td style="background-color: #D0D5D9;">
                                                <b style="color: Red">Xếp loại</b>
                                            </td>
                                            <td style="background-color: #D0D5D9;">
                                                <b style="color: Red">Số tháng</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>Loại A+</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblLoaiACong" Font-Bold="true" ForeColor="Blue" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>Loại A</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblLoaiA" Font-Bold="true" ForeColor="Blue" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>Loại B</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblLoaiB" Font-Bold="true" ForeColor="Blue" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>Loại C</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblLoaiC" Font-Bold="true" ForeColor="Blue" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>Loại D</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblLoaiD" Font-Bold="true" ForeColor="Blue" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="InputBox" style="width: 40%" valign="top">
                                    <table width="100%" cellpadding="5" cellspacing="2">
                                        <tr>
                                            <td style="background-color: #D0D5D9; width: 60%">
                                                <b style="color: Red">Tháng</b>
                                            </td>
                                            <td style="background-color: #D0D5D9;">
                                                <b style="color: Red">Xếp loại</b>
                                            </td>
                                        </tr>
                                        <asp:Literal ID="litResult" runat="server"></asp:Literal>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
