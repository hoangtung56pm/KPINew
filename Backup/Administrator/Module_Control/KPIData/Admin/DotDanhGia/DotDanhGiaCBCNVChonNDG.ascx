<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DotDanhGiaCBCNVChonNDG.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.DotDanhGia.DotDanhGiaCBCNVChonNDG" %>
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
    <tr>
        <td height="10">
        </td>
    </tr>
    <tr>
        <td class="InputBox" align="center">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="left">
                        <asp:Label ID="lblDotDanhGia" runat="server" Text="Đợt đánh giá:" 
                            Font-Bold="True"></asp:Label>
                        <asp:Label ID="lblDotDanhGiaName" runat="server" Font-Bold="True" 
                            ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td>
                        <asp:DropDownList ID="dropPortal" Visible="false" runat="server" DataTextField="Portal_Name"
                            DataValueField="PortalID" AutoPostBack="True" meta:resourcekey="dropPortalResource1">
                        </asp:DropDownList>
                        <b>Trung tâm: </b>
                        <asp:DropDownList ID="dropTrungTam" runat="server" DataTextField="Ten" DataValueField="ID"
                            AutoPostBack="True" Width="200px" OnSelectedIndexChanged="dropTrungTam_SelectedIndexChanged">
                        </asp:DropDownList><br />
                        <b>PT đánh giá: </b>
                        <asp:DropDownList ID="dropNhanVien" runat="server" DataTextField="Username" DataValueField="UserID"
                            AutoPostBack="True" Width="200px" 
                            onselectedindexchanged="dropNhanVien_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMember" runat="server" Text="Nhân viên trong đợt đánh giá" Font-Bold="True"></asp:Label>
                    </td>
                    <td style="width: 10px;">
                    </td>
                    <td>
                        <asp:Label ID="lblList" runat="server" Text="Danh sách nhân viên" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td class="InputBox">
                        <asp:ListBox ID="lstNhanVienInDotDanhGia" runat="server" DataTextField="Username" DataValueField="UserID"
                            Height="425px" SelectionMode="Multiple" Width="286px">
                        </asp:ListBox>
                    </td>
                    <td align="center" style="width: 10px;">
                        <asp:Button ID="btnAdd" runat="server" CssClass="Button" OnClick="btnAdd_Click" Text="<<"
                            Width="35px" meta:resourcekey="btnAddResource1" /><br />
                        <br />
                        <asp:Button ID="btnRemove" runat="server" CssClass="Button" OnClick="btnRemove_Click"
                            Text=">>" Width="35px" meta:resourcekey="btnRemoveResource1" />
                    </td>
                    <td class="InputBox">
                        <asp:ListBox ID="lstNhanVien" runat="server" DataTextField="Username" DataValueField="UserID"
                            Height="425px" SelectionMode="Multiple" Width="286px" >
                        </asp:ListBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
