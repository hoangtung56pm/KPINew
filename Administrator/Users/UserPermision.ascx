<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserPermision.ascx.cs"
    Inherits="VmgPortal.Administrator.Users.UserPermision" %>
<div class="row">
    <div class="col-md-12">
        <!-- BEGIN PAGE TITLE & BREADCRUMB-->
        <ul class="page-breadcrumb breadcrumb">
            <%--  <li class="btn-group">
                <button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                    <span>Actions</span> <i class="icon-angle-down"></i>
                </button>
                <ul class="dropdown-menu pull-right" role="menu">
                    <li><a href="#">Action</a></li>
                    <li><a href="#">Another action</a></li>
                    <li><a href="#">Something else here</a></li>
                    <li class="divider"></li>
                    <li><a href="#">Separated link</a></li>
                </ul>
            </li>--%>
            <li><i class="icon-home"></i><a href="/">Trang chủ</a> <i class="icon-angle-right"></i>
            </li>
            <li><a href="#">Phân quyền người dùng</a> <i class="icon-angle-right"></i></li>
        </ul>
        <!-- END PAGE TITLE & BREADCRUMB-->
    </div>
</div>
<div class="row">
    <div class="col-md-4" style="padding-right: 0px;">
        <div class="portlet box grey">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-reorder"></i>Phân quyền menu
                </div>
                <div class="tools">
                    <a href="" class="collapse"></a>
                    <%--<a href="#portlet-config" data-toggle="modal" class="config"></a>--%>
                    <a href="" class="reload"></a>
                    <%--<a href="" class="remove"></a>--%>
                </div>
            </div>
            <div class="portlet-body form">
                <div class="form-horizontal" role="form">
                    <div class="form-body">
                        <div class="form-group">
                            <div class="col-md-3 control-label">
                            </div>
                            <div class="col-md-9">
                                <asp:Label ID="lblUpdateStatus" runat="server" ForeColor="Blue"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblUser" runat="server" Text="Người dùng" class="col-md-3 control-label"
                                meta:resourcekey="lblUserResource1"></asp:Label>
                            <div class="col-md-9">
                                <asp:Label ID="lblUsername" runat="server" Font-Bold="True" CssClass="form-control"
                                    meta:resourcekey="lblUsernameResource1"></asp:Label>
                                <%--<span class="help-block">A block of help text.</span>--%>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblPortal" runat="server" class="col-md-3 control-label" Text="Portal"
                                meta:resourcekey="lblPortalResource1"></asp:Label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="dropPortal" CssClass="form-control" runat="server" DataTextField="Portal_Name"
                                    DataValueField="PortalID" AutoPostBack="True" meta:resourcekey="dropPortalResource1"
                                    OnSelectedIndexChanged="dropPortal_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <asp:UpdatePanel ID="upanelUserPermission" runat="server" UpdateMode="Conditional"
                            RenderMode="Inline">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="dropPortal" EventName="SelectedIndexChanged" />
                            </Triggers>
                            <ContentTemplate>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        Thuộc nhóm</label>
                                    <div class="col-md-9">
                                        <asp:ListBox ID="lstCommands" runat="server" Height="621px" SelectionMode="Multiple"
                                            CssClass="form-control" meta:resourcekey="lstCommandsResource1"></asp:ListBox>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="form-actions fluid">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn blue" OnClick="btnUpdate_Click"
                            Text="Cập nhật" meta:resourcekey="btnUpdateResource1" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-8">
        <div class="portlet box blue ">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-reorder"></i>Phân quyền chức năng
                </div>
                <div class="tools">
                    <a href="" class="collapse"></a>
                    <%--<a href="#portlet-config" data-toggle="modal" class="config"></a>--%>
                    <a href="" class="reload"></a>
                    <%--<a href="" class="remove"></a>--%>
                </div>
            </div>
            <div class="portlet-body form">
                <div class="form-horizontal" role="form">
                    <div class="form-body">
                        <div class="form-group">
                            <div class="col-md-3 control-label">
                            </div>
                            <div class="col-md-9">
                                <asp:Label ID="lblUpdateStatus1" runat="server" ForeColor="Blue"></asp:Label>
                            </div>
                        </div>
                        <asp:UpdatePanel ID="upanelUserPermission1" runat="server" UpdateMode="Conditional"
                            RenderMode="Inline">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btnUpdateAll" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="dropPortal" EventName="SelectedIndexChanged" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:DataGrid ID="dgrUserRole" runat="server" AutoGenerateColumns="False" Width="100%"
                                    OnItemCommand="dgrUserRole_ItemCommand" OnItemDataBound="dgrUserRole_ItemDataBound"
                                    CaptionAlign="Top" CellPadding="2" CssClass="Grid table table-bordered table-hover"
                                    meta:resourcekey="dgrUserRoleResource1">
                                    <HeaderStyle CssClass="Grid_Top" Font-Bold="True" ForeColor="Desktop" />
                                    <ItemStyle CssClass="Grid_Raw1" HorizontalAlign="Center" />
                                    <AlternatingItemStyle CssClass="Grid_Raw2" />
                                    <Columns>
                                        <asp:BoundColumn DataField="UserID" Visible="False" />
                                        <asp:BoundColumn DataField="CommandID" Visible="False" />
                                        <asp:BoundColumn DataField="PortalID" Visible="False" />
                                        <asp:TemplateColumn>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="34%" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblCmdName" runat="server" meta:resourcekey="lblCmdNameResource1"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn Visible="false" HeaderText="Web" >
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkWeb" runat="server" meta:resourcekey="chkWebResource1" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn Visible="false" HeaderText="Wap">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkWap" runat="server" meta:resourcekey="chkWapResource1" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn Visible="false" HeaderText="SMS">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSMS" runat="server" meta:resourcekey="chkSMSResource1" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn Visible="false" HeaderText="Xzone" >
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkXzone" runat="server" meta:resourcekey="chkXzoneResource1" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Đọc" >
                                            <ItemStyle HorizontalAlign="Center"  />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkView" runat="server" meta:resourcekey="chkViewResource1" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Ghi" >
                                            <ItemStyle HorizontalAlign="Center"/>
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
                                        <asp:TemplateColumn HeaderText="Xóa">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkDelete" runat="server" meta:resourcekey="chkDeleteResource1" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Button runat="server" CssClass="btn btn-xs dark" ID="btnUpdate" Text="Update"
                                                    CommandName="edit" meta:resourcekey="btnUpdateResource2" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                </asp:DataGrid><br>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="form-actions fluid">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:Button ID="btnUpdateAll" CssClass="btn blue" runat="server" Text="Cập nhật tất cả"
                            OnClick="btnUpdateAll_Click" meta:resourcekey="btnUpdateAllResource1" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
