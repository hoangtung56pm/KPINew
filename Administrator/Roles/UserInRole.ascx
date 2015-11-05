<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserInRole.ascx.cs"
    Inherits="VmgPortal.Administrator.Roles.UserInRole" %>
<div class="portlet box blue">
    <div class="portlet-title">
        <div class="caption">
            <i class="icon-reorder"></i>Phân nhóm người dùng
        </div>
        <div class="tools">
            <a class="collapse" href="javascript:;"></a>
            <%--  <a class="config" data-toggle="modal"
                href="#portlet-config"></a><a class="reload" href="javascript:;"></a><a class="remove"
                    href="javascript:;"></a>--%>
        </div>
    </div>
    <div class="portlet-body">
        <asp:UpdatePanel ID="upanelUserInRole" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnRemove" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="dropPortal" EventName="SelectedIndexChanged" />
            </Triggers>
            <ContentTemplate>
                <table border="0" cellpadding="0" cellspacing="0" width="70%">
                    <tr>
                        <td class="InputBox" colspan="3" align="left">
                            <asp:Label ID="lblGroup" runat="server" Text="Nhóm:" meta:resourcekey="lblGroupResource1"
                                Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblRoleName" runat="server" Font-Bold="True" meta:resourcekey="lblRoleNameResource1"
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
                            <b>Trung tâm: </b>
                            <asp:Label Visible="false" ID="lblPortal" runat="server" Text="Portal" meta:resourcekey="lblPortalResource1"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dropPortal" Visible="false" CssClass="form-control" runat="server"
                                DataTextField="Portal_Name" DataValueField="PortalID" meta:resourcekey="dropPortalResource1"
                                Width="200px">
                            </asp:DropDownList>
                            <asp:DropDownList ID="dropTrungTam" CssClass="form-control" runat="server" DataTextField="Ten"
                                DataValueField="ID" AutoPostBack="True" Width="200px" OnSelectedIndexChanged="dropTrungTam_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMember" runat="server" Text="Thành viên trong nhóm" meta:resourcekey="lblMemberResource1"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width: 10px;">
                        </td>
                        <td>
                            <asp:Label ID="lblList" runat="server" Text="Danh sách" meta:resourcekey="lblListResource1"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="InputBox" style="width: 40%;">
                            <asp:ListBox ID="lstUserInRole" CssClass="form-control" runat="server" DataTextField="Username"
                                DataValueField="UserID" Height="425px" SelectionMode="Multiple" Width="100%"
                                meta:resourcekey="lstUserInRoleResource1"></asp:ListBox>
                        </td>
                        <td align="center" style="width: 10px;">
                            <asp:Button ID="btnAdd" runat="server" CssClass="btn dark" OnClick="btnAdd_Click" Text="<<"
                                Width="40px" meta:resourcekey="btnAddResource1" /><br />
                            <br />
                            <asp:Button ID="btnRemove" runat="server" CssClass="btn blue"  OnClick="btnRemove_Click"
                                Text=">>" Width="40px" meta:resourcekey="btnRemoveResource1" />
                        </td>
                        <td class="InputBox" colspan="2" style="width: 40%;">
                            <asp:ListBox ID="lstUsers" runat="server" CssClass="form-control" DataTextField="Username"
                                DataValueField="UserID" Height="425px" SelectionMode="Multiple" Width="100%"
                                meta:resourcekey="lstUsersResource1"></asp:ListBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
