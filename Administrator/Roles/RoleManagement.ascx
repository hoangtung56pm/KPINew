<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RoleManagement.ascx.cs"
    Inherits="VmgPortal.Administrator.Roles.RoleManagement" %>
<%@ Register Assembly="VmgPortal.WebControls" Namespace="VmgPortal.WebControls" TagPrefix="cc2" %>
<%@ Register Assembly="VmgPortal.Library" Namespace="VmgPortal.Library.Controls"
    TagPrefix="cc3" %>
<style>
    .table-padding tr td
    {
        padding-bottom: 8px;
    }
</style>
<div class="row">
    <div class="col-md-8">
        <asp:UpdatePanel ID="upanelRoleManagement" runat="server" UpdateMode="Conditional"
            RenderMode="Inline">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <cc3:GridView ID="dtgRoles" runat="server" AutoGenerateColumns="False" BorderColor="Gainsboro"
                    BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Top" CellPadding="2" CssClass="Grid table table-bordered table-hover"
                    OnRowCommand="dtgRoles_RowCommand" OnRowDataBound="dtgRoles_RowDataBound" Width="100%"
                    meta:resourcekey="dtgRolesResource1">
                    <AlternatingRowStyle CssClass="Grid_Raw2" />
                    <RowStyle CssClass="Grid_Raw1" />
                    <HeaderStyle CssClass="Grid_Top" Font-Bold="True" />
                    <Columns>
                        <asp:BoundField DataField="RoleName" HeaderText="Nh&#243;m" meta:resourcekey="BoundFieldResource2" />
                        <asp:BoundField DataField="RoleDescription" HeaderText="M&#244; tả" meta:resourcekey="BoundFieldResource3" />
                        <asp:TemplateField HeaderText="Thao t&#225;c" meta:resourcekey="TemplateFieldResource1">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <cc2:ButtonRoleEdit ID="btnEditRole" runat="server" CommandArgument='<%# Eval("RoleID") %>'
                                    CommandName="editrole" CssClass="btn btn-xs green" Text="Sửa" meta:resourcekey="btnEditRoleResource1" />&nbsp;
                                <asp:Button ID="btnRolePermision" runat="server" CommandArgument='<%# Eval("RoleID") %>'
                                    CommandName="rolepermision" CssClass="btn btn-xs blue" Text="Ph&#226;n quyền"
                                    meta:resourcekey="btnRolePermisionResource1" />
                                <asp:Button ID="btnUserInRole" runat="server" CommandArgument='<%# Eval("RoleID") %>'
                                    CommandName="userinrole" CssClass="btn btn-xs yellow " Text="Th&#224;nh vi&#234;n"
                                    meta:resourcekey="btnUserInRoleResource1" />
                                <cc2:ButtonRoleDelete ID="btnDeleteRole" runat="server" CommandArgument='<%# Eval("RoleID") %>'
                                    CommandName="deleterole" CssClass="btn btn-xs red" Text="X&#243;a" meta:resourcekey="btnDeleteRoleResource1" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </cc3:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="col-md-4">
        <asp:UpdatePanel ID="upanelRoleManagement1" runat="server" UpdateMode="Conditional"
            RenderMode="Inline">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="dtgRoles" EventName="RowCommand" />
            </Triggers>
            <ContentTemplate>
                <asp:Label ID="lblUpdate" meta:resourcekey="lblUpdateResource1" runat="server" ForeColor="Blue"></asp:Label>
                <table border="0" cellpadding="0" cellspacing="0" class="InputBox table-padding"
                    style="width: 100%">
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCode" runat="server" Text="Mã" meta:resourcekey="lblCodeResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRoleID" CssClass="form-control" runat="server" Enabled="False" Width="46px" meta:resourcekey="txtRoleIDResource1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblGroup" runat="server" Text="Group" meta:resourcekey="lblGroupResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRoleName" runat="server" meta:resourcekey="txtRoleNameResource1"
                                CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDescription" runat="server" Text="Mô tả" meta:resourcekey="lblDescriptionResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRoleDescription" runat="server" Height="60px" TextMode="MultiLine"
                                meta:resourcekey="txtRoleDescriptionResource1" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAddress" runat="server" Text="Mô tả" meta:resourcekey="lblAddressResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" TextMode="singleLine" meta:resourcekey="txtAddressResource1"
                                CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPhone" runat="server" Text="Điện thoại" meta:resourcekey="lblPhoneResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server" TextMode="singleLine" meta:resourcekey="txtPhoneResource1"
                                CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFax" runat="server" Text="Fax" meta:resourcekey="lblFaxResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFax" runat="server" TextMode="singleLine" meta:resourcekey="txtFaxResource1"
                                CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEmail" runat="server" Text="Email" meta:resourcekey="lblEmailResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" TextMode="singleLine" meta:resourcekey="txtEmailResource1"
                                CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblUserManager" runat="server" Text="Người quản lý" meta:resourcekey="lblUserManagerResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dropUserManager" CssClass="form-control" runat="server" DataTextField="UserName"
                                DataValueField="UserID">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblRoleParentID" runat="server" Text="Nhóm cha" meta:resourcekey="lblRoleParentIDResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dropRoleParentID" CssClass="form-control" runat="server" DataTextField="RoleName"
                                DataValueField="RoleID">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <table border="0" cellpadding="0" cellspacing="0" class="InputBox" style="width: 100%">
            <tr>
                <td align="center" colspan="2" style="height: 24px">
                    <cc2:ButtonRoleEdit ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Cập nhật"
                        CssClass="btn blue" Width="" meta:resourcekey="btnUpdateResource2" />
                    <cc2:ButtonRoleAdd ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Thêm mới"
                        CssClass="btn green" Width="" meta:resourcekey="btnAddResource2" />
                    <cc2:ButtonRoleDelete ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Xóa"
                        CssClass="btn dark" Width="" meta:resourcekey="btnDeleteResource2" />
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn" Text="Huỷ" Width="" meta:resourcekey="btnCancelResource1"
                        OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
</div>
