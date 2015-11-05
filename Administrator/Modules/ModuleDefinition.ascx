<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModuleDefinition.ascx.cs"
    Inherits="VmgPortal.Administrator.Modules.ModuleDefinition" %>
<%@ Register Assembly="VmgPortal.WebControls" Namespace="VmgPortal.WebControls" TagPrefix="cc2" %>
<%@ Register Assembly="VmgPortal.Library" Namespace="VmgPortal.Library.Controls"
    TagPrefix="cc3" %>
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
            <li><a href="#">Quản lý Modules</a> <i class="icon-angle-right"></i></li>
        </ul>
        <!-- END PAGE TITLE & BREADCRUMB-->
    </div>
</div>
<asp:UpdatePanel ID="upanelModuleDefinition" runat="server" UpdateMode="Conditional"
    RenderMode="Inline">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="dtgModules" EventName="RowCommand" />
    </Triggers>
    <ContentTemplate>
        <cc3:GridView ID="dtgModules" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-bordered dataTable"
            Width="100%" meta:resourcekey="dtgModulesResource1" OnRowCommand="dtgModules_RowCommand"
            AllowPaging="True" PageSize="20">
            <AlternatingRowStyle CssClass="odd" />
            <RowStyle CssClass="even" />
            <HeaderStyle CssClass="sorting_disabled" />
            <Columns>
                <asp:BoundField DataField="ModuleID" Visible="False" meta:resourcekey="BoundFieldResource1" />
                <asp:BoundField DataField="ModuleName" HeaderText="T&#234;n module" meta:resourcekey="BoundFieldResource2" />
                <asp:BoundField DataField="ModuleTitle" HeaderText="Title" meta:resourcekey="BoundFieldResource3" />
                <asp:BoundField DataField="ModuleDescription" HeaderText="M&#244; tả" meta:resourcekey="BoundFieldResource4" />
                <asp:BoundField DataField="ModuleFolder" HeaderText="Thư mục" meta:resourcekey="BoundFieldResource5" />
                <asp:TemplateField HeaderText="Thao t&#225;c" meta:resourcekey="TemplateFieldResource1">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <cc2:ButtonRoleEdit ID="btnEditModule" runat="server" meta:resourcekey="btnEditModuleResource1"
                            CommandName="editmodule" CssClass="btn default btn-xs blue" Text="Sửa" CommandArgument='<%# Eval("ModuleID") %>' />
                        <cc2:ButtonRoleDelete ID="btnDeleteModule" runat="server" CommandArgument='<%# Eval("ModuleID") %>'
                            CommandName="deletemodule" CssClass="btn default btn-xs dark" Text="X&#243;a"
                            meta:resourcekey="btnDeleteModuleResource1" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </cc3:GridView>
    </ContentTemplate>
</asp:UpdatePanel>
<div class="form-actions">
    <cc2:ButtonRoleAdd ID="btnAddModule" runat="server" CssClass="btn green" Text="Thêm Control"
        OnClick="btnAddModule_Click" /></div>
