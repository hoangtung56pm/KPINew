<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RolePermision.ascx.cs"
    Inherits="VmgPortal.Administrator.Roles.RolePermision" %>
  <div class="row">
    <div class="col-md-5" style="padding-right: 0px;">
        <div class="portlet box grey">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-reorder"></i>Phân quyền menu
                </div>
                <div class="tools">
                    <a href="" class="collapse"></a>
                    <%--<a href="#portlet-config" data-toggle="modal" class="config"></a>--%>
                    <%--  <a href="" class="reload"></a>--%>
                    <%--<a href="" class="remove"></a>--%>
                </div>
            </div>
            <div class="portlet-body form">
                <div class="form-horizontal" role="form">
                    <div class="form-body">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 15%">
                                    <asp:Label ID="lblPortal" runat="server" Text="Portal" meta:resourcekey="lblPortalResource1"
                                        Font-Bold="True"></asp:Label>
                                </td>
                                <td style="width: 60%">
                                    <asp:DropDownList ID="dropPortal" CssClass="form-control" runat="server" DataTextField="Portal_Name"
                                        DataValueField="PortalID" AutoPostBack="True" meta:resourcekey="dropPortalResource1"
                                        Width="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblRoles" runat="server" Text="Roles" meta:resourcekey="lblRolesResource1"
                                        Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropRole" CssClass="form-control" runat="server" DataTextField="RoleName"
                                        DataValueField="RoleID" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="dropRole_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; padding-right: 10px;">
                                    <asp:Label ID="lblCommands" runat="server" Text="Commands" meta:resourcekey="lblCommandsResource1"
                                        Font-Bold="True"></asp:Label>
                                </td>
                                <td valign="top" style="height: 719px">
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="upanelUserPermission" runat="server" UpdateMode="Conditional"
                                                    RenderMode="Inline">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                                                        <asp:AsyncPostBackTrigger ControlID="dropPortal" EventName="SelectedIndexChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="dropRole" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                    <ContentTemplate>
                                                        <asp:ListBox ID="lstCommands" CssClass="form-control" runat="server" Height="621px"
                                                            Style="margin-bottom: 5px;" SelectionMode="Multiple" Width="100%" meta:resourcekey="lstCommandsResource1">
                                                        </asp:ListBox>
                                                        <br />
                                                        <asp:Label ID="lblUpdate" runat="server" meta:resourcekey="lblUpdateResource1" ForeColor="Blue"
                                                            Font-Bold="True"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="form-actions fluid">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Cập nhật"
                            CssClass="btn blue" meta:resourcekey="btnUpdateResource1" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-7">
        <div class="portlet box blue ">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-reorder"></i>Phân quyền chức năng
                </div>
                <div class="tools">
                    <a href="" class="collapse"></a>
                </div>
            </div>
            <div class="portlet-body form">
                <div class="form-horizontal" role="form">
                    <div class="form-body">
                        <asp:UpdatePanel ID="upanelUserPermission1" runat="server" UpdateMode="Conditional"
                            RenderMode="Inline">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btnUpdateAll" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="dropPortal" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="dropRole" EventName="SelectedIndexChanged" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:DataGrid ID="dgrRolePermission" runat="server" AutoGenerateColumns="False" Width="100%"
                                    OnItemCommand="dgrRolePermission_ItemCommand" OnItemDataBound="dgrRolePermission_ItemDataBound"
                                    BorderColor="Gainsboro" BorderStyle="solid" BorderWidth="1px" CellPadding="2"
                                    CssClass="table table-striped table-hover table-bordered dataTable">
                                    <AlternatingItemStyle CssClass="odd" />
                                  <%--  <ItemStyle CssClass="even" />--%>
                                    <HeaderStyle CssClass="sorting_disabled"  ForeColor="Black" />
                                    <Columns>
                                        <asp:BoundColumn DataField="RoleID" Visible="False" />
                                        <asp:BoundColumn DataField="CommandID" Visible="False" />
                                        <asp:BoundColumn DataField="PortalID" Visible="False" />
                                        <asp:TemplateColumn>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="34%" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblCmdName" runat="server" meta:resourcekey="lblCmdNameResource1"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Đọc">
                                            <ItemStyle HorizontalAlign="Center"/>
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkView" runat="server" meta:resourcekey="chkViewResource1" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Ghi">
                                            <ItemStyle HorizontalAlign="Center"  />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAdd" runat="server" meta:resourcekey="chkAddResource1" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Sửa" >
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkEdit" runat="server" meta:resourcekey="chkEditResource1" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Xóa" >
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkDelete" runat="server" meta:resourcekey="chkDeleteResource1" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Button runat="server" CssClass="btn btn-xs black" ID="btnUpdate" Text="Update"
                                                    CommandName="edit" meta:resourcekey="btnUpdateResource2" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                </asp:DataGrid><asp:Label ID="lblUpdate1" runat="server" meta:resourcekey="lblUpdateResource1"
                                    ForeColor="Blue" Font-Bold="True"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="form-actions fluid">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:Button ID="btnUpdateAll" CssClass="btn blue" runat="server" Text="Cập nhật"
                            OnClick="btnUpdateAll_Click" meta:resourcekey="btnUpdateAllResource1" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
