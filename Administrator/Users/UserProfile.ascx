<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UserProfile.ascx.cs"
    Inherits="VmgPortal.Administrator.Users.UserProfile" %>

<%--<asp:UpdatePanel ID="upanelEditUser" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
    </Triggers>
    <ContentTemplate>--%>
        <table width="100%">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblUpdateStatus" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></td>
            </tr>
        </table>
        <table border="0" cellpadding="2" cellspacing="2" class="InputBox" style="width: 100%">
            
            <tr style="color: #000000">
                <td style="width: 150px">
                    <strong>Tên truy cập:</strong></td>
                <td>
                    <asp:Label ID="lblUsername" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr style="color: #000000">
                <td style="width: 150px">
                    <strong>Tên hiển thị:</strong></td>
                <td>
                    <asp:TextBox ID="txtDisplayName" runat="server" CssClass="inputTextBox150"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px">
                    <strong>Email:</strong></td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="inputTextBox150"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Chưa nhập email"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 150px;">
                    <strong>Họ đệm:</strong></td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="inputTextBox150"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px;">
                    <strong>Tên:</strong></td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputTextBox150"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    <strong>Điện thoại:</strong></td>
                <td>
                    <asp:TextBox ID="txtTel" runat="server" CssClass="inputTextBox150"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px">
                    <strong>Di động:</strong></td>
                <td>
                    <asp:TextBox ID="txtMobile" runat="server" CssClass="inputTextBox150"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px">
                    <strong>Địa chỉ 1:</strong></td>
                <td>
                    &nbsp;<asp:TextBox ID="txtAddress1" runat="server" TextMode="MultiLine" Width="305px"
                        CssClass="inputTextBox150" Height="60px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px">
                    <strong>Địa chỉ 2:</strong></td>
                <td>
                    &nbsp;<asp:TextBox ID="txtAddress2" runat="server" TextMode="MultiLine" Width="305px"
                        CssClass="inputTextBox150" Height="60px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px">
                    <strong>ZipCode:</strong></td>
                <td>
                    <asp:TextBox ID="txtZipCode" runat="server" CssClass="inputTextBox150"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px">
                    <strong>Nước:</strong></td>
                <td>
                    <asp:DropDownList ID="dropCountry" runat="server" Width="150px">
                        <asp:ListItem Value="1">Việt Nam</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="height: 26px">
                    <strong>Thành phố:</strong></td>
                <td style="height: 26px">
                    <asp:DropDownList ID="dropCity" runat="server" Width="150px">
                        <asp:ListItem Value="1">H&#224; Nội</asp:ListItem>
                        <asp:ListItem Value="2">Th&#224;nh phố Hồ Ch&#237; Minh</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
           <%-- <tr>
                <td style="height: 26px">
                    <strong>Đối tác:</strong></td>
                <td style="height: 26px">
                    <asp:DropDownList ID="dropPartner" runat="server" Width="150px" DataTextField="PartnerName"
                        DataValueField="PartnerID">
                    </asp:DropDownList>
                </td>
            </tr>--%>
            <tr>
                <td valign="top" style="height: 53px">
                    <strong>Thuộc nhóm:</strong></td>
                <td valign="top" style="height: 53px">
                    &nbsp;<asp:ListBox ID="lstPortal" Style="height: 150px; width: 180px;" runat="server" SelectionMode="Multiple">
                    </asp:ListBox></td>
            </tr>
            <asp:Panel ID="pnlAdmin" runat="server" Width="100%">
                <tr>
                    <td style="width: 150px">
                        <strong>Là Admin:</strong>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkIsAdmin" runat="server" Font-Bold="True" /></td>
                </tr>
            </asp:Panel>
            <asp:Panel ID="pnlSuperadmin" runat="server" Height="50px" Width="100%">
                <tr>
                    <td>
                        <strong>Là SuperAdmin:</strong>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkIsSuperAdmin" runat="server" /></td>
                </tr>
            </asp:Panel>
            <tr>
                <td style="width: 150px">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="Button70" OnClick="btnUpdate_Click"
                        Text="Cập  nhật" />
                    <asp:Button ID="btnManagePassword" runat="server" CssClass="Button70" OnClick="btnManagePassword_Click"
                        Text="Mật khẩu" />
                    <asp:Button ID="btnCancel" runat="server" CssClass="Button70" Text="Quay lại" Width="84px"
                        OnClick="btnCancel_Click" /></td>
            </tr>
            <tr>
                <td style="width: 150px">
                </td>
                <td>
                </td>
            </tr>
        </table>
    <%--</ContentTemplate>
</asp:UpdatePanel>
--%>