<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommandDefinition.ascx.cs"
    Inherits="VmgPortal.Administrator.Commands.CommandDefinition" %>
<%@ Register Assembly="VmgPortal.WebControls" Namespace="VmgPortal.WebControls" TagPrefix="cc1" %>
<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="componentart" %>
<style>
    .tree .tree-item, .tree .tree-folder
    {
        border: 0px solid #FFF !important;
    }
</style>
<asp:UpdatePanel ID="uppanelCommandDefinitionUpdate" runat="server" UpdateMode="Conditional"
    RenderMode="Inline">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="cmdUpdate" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="cmdAddNew" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="cmdDelete" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tvwCmds" EventName="NodeSelected" />
        <%--<asp:AsyncPostBackTrigger ControlID="cmdEmpty" EventName="Click" />--%>
    </Triggers>
    <ContentTemplate>
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
                    <li><a href="#">Quản lý chức năng</a> <i class="icon-angle-right"></i></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <div class="row">
            <div class="col-md-3" style="padding-right: 0px;">
                <div class="portlet grey box">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="icon-cogs"></i>Cây chức năng</div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a>
                            <%--  <a href="#portlet-config" data-toggle="modal" class="config"></a>
                    <a href="javascript:;" class="reload"></a>
                    <a href="javascript:;" class="remove"></a>--%>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div id="MyTree1" class="tree tree-plus-minus tree-no-line tree-unselectable">
                            <componentart:TreeView ID="tvwCmds" runat="server" AutoPostBackOnSelect="True" CausesValidation="False"
                                ClientScriptLocation="/JScripts/componentart_webui_client/" CollapseImageUrl="assets/img/TreeView/exp.gif"
                                ExpandCollapseImageHeight="11" ExpandCollapseImageWidth="14" ExpandImageUrl="assets/img/TreeView/col.gif"
                                Height="100%" HoverNodeCssClass="" NodeCssClass="tree-item" NodeIndent="15" NodeRowCssClass="tree-item"
                                NoExpandImageUrl="assets/img/TreeView/noexp.gif" OnNodeSelected="tvwCmds_NodeSelected"
                                PreloadCurrentPath="True" SelectedNodeCssClass="" meta:resourcekey="tvwCmdsResource1">
                            </componentart:TreeView>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-9">
                <div class="row">
                    <div class="col-md-12">
                        <div class="portlet blue box" style="margin-bottom: 5px;">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="icon-cogs"></i>Tên theo ngôn ngữ</div>
                                <div class="tools">
                                    <a href="javascript:;" class="collapse"></a>
                                    <%--  <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                    <a href="#"><a href="javascript:;" class="reload"></a>
                                    </a> href="javascript:;" class="remove"></a>--%>
                                </div>
                            </div>
                            <div class="portlet-body">
                                <div class="form-body">
                                    <asp:DataGrid ID="dgrNameFollowLang" runat="server" Width="100%" AllowSorting="True"
                                        AllowPaging="True" AutoGenerateColumns="False" ShowHeader="False" GridLines="None">
                                        <Columns>
                                            <asp:BoundColumn Visible="False" DataField="CommandID"></asp:BoundColumn>
                                            <asp:BoundColumn Visible="False" DataField="Lang"></asp:BoundColumn>
                                            <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <div class="form-group">
                                                        <div class="control-label col-md-3">
                                                            <asp:Label ID="lblName" runat="server" Text="Tên" meta:resourcekey="lblNameResource1"></asp:Label>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <asp:TextBox runat="server" class="form-control" ID="txtName" Text='<%# Eval("CommandName") %>'></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                                                                Display="Dynamic" ErrorMessage="(*)" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="control-label col-md-3">
                                                            <asp:Label ForeColor="Green" runat="server" ID="lblLang" Text='<%# Eval("Language_Name") %>'></asp:Label>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                        <PagerStyle Visible="False"></PagerStyle>
                                    </asp:DataGrid>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="portlet blue box">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="icon-cogs"></i>Thuộc tính</div>
                                <div class="tools">
                                    <a href="javascript:;" class="collapse"></a>
                                    <%--<a href="#portlet-config" data-toggle="modal" class="config"></a>
                                    <a href="javascript:;" class="reload"></a>
                                    <a href="javascript:;" class="remove"></a>--%>
                                </div>
                            </div>
                            <div class="portlet-body">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-9">
                                            <asp:Label ID="lblUpdateStatus" runat="server" meta:resourcekey="lblUpdateStatusResource1"
                                                ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblID" class="control-label col-md-3" runat="server" Text="ID" meta:resourcekey="lblIDResource1"></asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtID" runat="server" Enabled="False" class="form-control" meta:resourcekey="txtIDResource1"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblCommands" class="control-label col-md-3" runat="server" Text="Lệnh"
                                            meta:resourcekey="lblCommandsResource1"></asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="dropCommandKeys" runat="server" DataTextField="ControlPath"
                                                DataValueField="ControlKey" class="form-control" meta:resourcekey="dropCommandKeysResource1">
                                            </asp:DropDownList>
                                            </td>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblParam" class="control-label col-md-3" runat="server" Text="Tham số"
                                            meta:resourcekey="lblParamResource1"></asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtParams" runat="server" class="form-control" meta:resourcekey="txtParamsResource1"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblLinkUrl" class="control-label col-md-3" runat="server" Text="Link Url"
                                            meta:resourcekey="lblLinkUrlResource1"></asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtUrl" runat="server" class="form-control" meta:resourcekey="txtUrlResource1"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblParent" runat="server" class="control-label col-md-3" Text="Cha"
                                            meta:resourcekey="lblParentResource1"></asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="dropParent" class="form-control" runat="server" meta:resourcekey="dropParentResource1">
                                            </asp:DropDownList>
                                            </td>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblOrder" runat="server" class="control-label col-md-3" Text="Thứ tự"
                                            meta:resourcekey="lblOrderResource1"></asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="dropIndex" runat="server" class="form-control" meta:resourcekey="dropIndexResource1">
                                            </asp:DropDownList>
                                            </td>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblActive" runat="server" Text="Hoạt động" class="control-label col-md-3"
                                            meta:resourcekey="lblActiveResource1"></asp:Label>
                                        <div class="col-md-9">
                                            <div class="checkbox-list">
                                                <label class="checkbox-inline">
                                                    <span class="checked">
                                                        <asp:CheckBox ID="chkEnable" runat="server" Checked="True" meta:resourcekey="chkEnableResource1" />
                                                    </span>
                                                    <%-- Cho phép hiển thị--%>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblVisible" class="control-label col-md-3" runat="server" Text="Hiện thị"
                                            meta:resourcekey="lblVisibleResource1"></asp:Label>
                                        <div class="col-md-9">
                                            <div class="checkbox-list">
                                                <label class="checkbox-inline">
                                                    <span class="checked">
                                                        <asp:CheckBox ID="chkVisble" runat="server" Checked="True" meta:resourcekey="chkVisbleResource1" />
                                                    </span>
                                                    <%-- Cho phép hiển thị--%>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblIsSuperUser" class="control-label col-md-3" runat="server" Text="Is Super User"
                                            meta:resourcekey="lblIsSuperUserResource1"></asp:Label>
                                        <div class="col-md-9">
                                            <div class="checkbox-list">
                                                <label class="checkbox-inline">
                                                    <span class="checked">
                                                        <asp:CheckBox ID="chkIsSuperUser" runat="server" Checked="True" meta:resourcekey="chkIsSuperUserResource1" />
                                                    </span>
                                                    <%-- Cho phép hiển thị--%>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-actions">
                                    <div class="col-md-offset-3 col-md-9">
                                        <cc1:ButtonRoleEdit ID="cmdUpdate" runat="server" OnClick="cmdUpdate_Click" Text="Cập nhật"
                                            CssClass="btn blue" />
                                        <cc1:ButtonRoleAdd ID="cmdAddNew"  runat="server" OnClick="cmdAddNew_Click" Text="Thêm mới"
                                            CssClass="btn green" />
                                        <cc1:ButtonRoleDelete ID="cmdDelete" runat="server" OnClick="cmdDelete_Click" Text="Xóa"
                                            CssClass="btn dark" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div> </div>
    </ContentTemplate>
</asp:UpdatePanel>
<script>
    jQuery(document).ready(function () {
        UITree.init();
    });
</script>
