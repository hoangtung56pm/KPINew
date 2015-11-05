<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrangThaiNhanVien.ascx.cs"
    Inherits="VmgPortal.Administrator.Users.TrangThaiNhanVien" %>
<table id="TABLE1" border="0" cellpadding="2" cellspacing="2" style="width: 100%">
    <tr>
        <td>
            <asp:Label ID="lblUpdateStatus" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
        </td>
    </tr>
    <tr>
        <td valign="top" class="InputBox" style="width: 30%;">
            <table border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td>
                        Chọn đợt đánh giá:
                    </td>
                    <td>
                        <asp:DropDownList AutoPostBack="true" Width="300px" ID="dropDotDanhGia" runat="server"
                            DataTextField="Ten" DataValueField="ID" OnSelectedIndexChanged="dropDotDanhGia_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Bộ phận làm việc:</strong>
                    </td>
                    <td>
                        <asp:DropDownList ID="dropTrungTam" AutoPostBack="true" runat="server" DataTextField="Ten"
                            DataValueField="ID" OnSelectedIndexChanged="dropTrungTam_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Phòng/Ban:</strong>
                    </td>
                    <td>
                        <asp:DropDownList AutoPostBack="true" ID="dropPhong" runat="server" DataTextField="Ten" DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Trạng thái:</strong>
                    </td>
                    <td>
                        <asp:DropDownList ID="dropTrangThai" runat="server">
                            <asp:ListItem Text="Nghỉ việc" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Chính thức" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Thời vụ" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Thử việc" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Nghỉ chế độ" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Đào tạo" Value="5"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="center" class="InputBox" colspan="3" style="height: 28px">
            <asp:Button ID="btnUpdate" CausesValidation="false" runat="server" CssClass="Button70" Text="Cập  nhật" OnClick="btnUpdate_Click" />
        </td>
    </tr>
</table>
