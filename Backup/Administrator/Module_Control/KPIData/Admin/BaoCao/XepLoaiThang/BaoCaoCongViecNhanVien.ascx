<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BaoCaoCongViecNhanVien.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.BaoCao.XepLoaiThang.BaoCaoCongViecNhanVien" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Import Namespace="VmgPortal.Library.Utilities" %>
<%@ Import Namespace="System" %>
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
    <tr>
        <td height="10">
        </td>
    </tr>
    <tr>
        <td>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td class="InputBox" align="center">
                        <asp:Panel ID="pnSearch" runat="server" DefaultButton="btnExport">
                            <table cellpadding="4" cellspacing="0" style="width: 50%">
                                <tr>
                                    <td width="100px">
                                        <strong>Đợt đánh giá:</strong>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control" ID="dropDotDanhGia" DataTextField="Ten"
                                            DataValueField="ID" runat="server" Width="300px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <strong>Bộ phận:</strong>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control" ID="dropTrungTam" runat="server" DataTextField="Ten"
                                            DataValueField="ID" AutoPostBack="True" Width="300px" OnSelectedIndexChanged="dropTrungTam_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <strong>Phòng ban:</strong>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control" ID="dropPhongBan" runat="server" DataTextField="Ten"
                                            DataValueField="ID" AutoPostBack="True" Width="300px" OnSelectedIndexChanged="dropPhongBan_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnExport" CssClass="btn blue" runat="server" Text="Export" OnClick="btnExport_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Panel ID="pnLink" runat="server">
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
