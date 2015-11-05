<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImportXepLoaiDanhGiaCaNhan.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.BaoCao.XepLoaiThang.ImportXepLoaiDanhGiaCaNhan" %>
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
                    <td >
                        <table class="InputBox" cellpadding="5" cellspacing="0" style="width: 100%">
                            <tr>
                                <td align="right">
                                    <b>File mẫu</b>
                                </td>
                                <td align="left">
                                    <asp:HyperLink ID="HyperLink1" runat="server" Text="Click vào tải file mẫu" NavigateUrl="http://kpi.vmgmedia.vn/Template/KQDanhGiaCaNhanThang.csv"></asp:HyperLink>
                                    <br />
                                    File có định dạng csv, là file export ra từ hệ thống
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <b>Bộ phận</b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropBoPhan" Width="200px" CssClass="form-control" runat="server" DataTextField="Ten" DataValueField="ID">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>Năm:</strong>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropNam" Width="100px" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                                        <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                                        <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                                        <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                                        <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                        <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                                        <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                        <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                        <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>Tháng:</strong>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropThang" Width="100px" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <b>File import</b>
                                </td>
                                <td>
                                    <asp:FileUpload ID="fileImport" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnSearch" runat="server" CssClass="btn blue" Text="Import" OnClick="btnSearch_Click" />&nbsp;
                                    <asp:Button ID="btnExport" runat="server" CssClass="btn green" Text="Export kết quả theo năm"
                                        OnClick="btnExport_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:HyperLink ID="hplDownload" runat="server"></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblUpdateStatus" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
