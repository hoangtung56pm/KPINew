<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModuleDefinitionEdit.ascx.cs"
    Inherits="VmgPortal.Administrator.Modules.ModuleDefinitionEdit" %>
<%@ Register Assembly="VmgPortal.WebControls" Namespace="VmgPortal.WebControls" TagPrefix="cc2" %>

<%@ Register Assembly="VmgPortal.Library" Namespace="VmgPortal.Library.Controls"
    TagPrefix="cc3" %>
<%@ Import Namespace="VmgPortal.Library" %>
<div class="portlet box blue">
    <div class="portlet-title">
        <div class="caption"><i class="icon-reorder"></i>Nhập Modules</div>
        <div class="tools">
            <a href="javascript:;" class="collapse"></a>
            <%--          <a href="#portlet-config" data-toggle="modal" class="config"></a>
                    <a href="javascript:;" class="reload"></a>
                    <a href="javascript:;" class="remove"></a>--%>
        </div>
    </div>
    <div class="portlet-body form">
        <!-- BEGIN FORM-->
        <div id="form_sample_1" class="form-horizontal">
            <div class="form-body">
                <%--<div class="alert alert-danger display-hide">
                    <button class="close" data-dismiss="alert"></button>                  
                </div>--%>

                <%-- <div id="static" class="alert alert-success display-hide" role="alert">
                    <button class="close" data-dismiss="alert"></button>                   
                </div>--%>
                <div class="form-group">
                    <div class="col-md-4">
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="lblUpdateStatus" ForeColor="Red" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <%--<asp:Label class="control-label col-md-3" ID="lblModuleID" runat="server" Text="Module ID" meta:resourcekey="lblModuleIDResource1"></asp:Label><span class="required">*</span>                   --%>
                    <label class="control-label col-md-3">ModuleID<span class="required">*</span></label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtID" data-required="1" class="form-control" runat="server" Enabled="False" meta:resourcekey="txtIDResource1"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <%--<asp:Label ID="lblModuleName" class="control-label col-md-3" runat="server" Text="Tên module" meta:resourcekey="lblModuleNameResource1"></asp:Label><span class="required">*</span>                   --%>
                    <label class="control-label col-md-3">Tên Module<span class="required">*</span></label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtModuleName" runat="server" class="form-control" meta:resourcekey="txtModuleNameResource1"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtModuleName"
                            ErrorMessage="Chưa nhập tên module" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3">Tiêu đề</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtModuleTitle" runat="server" class="form-control" meta:resourcekey="txtModuleTitleResource1"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3">Mô tả</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtModuleDescription" runat="server" class="form-control" TextMode="MultiLine" meta:resourcekey="txtModuleDescriptionResource1"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3">Thư mục<span class="required">*</span></label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtModuleFolder" class="form-control" runat="server" Width="338px" meta:resourcekey="txtModuleFolderResource1"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtModuleFolder"
                            ErrorMessage="Chưa nhập đường dẫn" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="form-actions">
                <div class="col-md-offset-3 col-md-9">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn blue" Text="Cập nhật"
                        OnClick="btnUpdate_Click" data-target="#static" data-toggle="alert" />
                    <asp:Button ID="btnDelete" runat="server" CssClass="btn dark" Text="Xóa"
                        OnClick="btnDelete_Click" />
                    <%--  <asp:Button ID="btnCancel" runat="server" CssClass="btn default" OnClick="btnCancel_Click"
                        Text="Hủy" meta:resourcekey="btnCancelResource1" />--%>
                    <a href="<%=AppEnv.AdminUrlParams("moduledef")%>" class="btn default">Quay lại</a>

                </div>
            </div>
        </div>
        <!-- END FORM-->
    </div>
</div>

<div class="portlet">
    <div class="portlet-title">
        <div class="caption"><i class="icon-bell"></i>Danh sách Control</div>                
        <div class="tools">                     
             <a href="javascript:;" class="collapse"></a>
            <%-- <a href="#portlet-config" data-toggle="modal" class="config"></a>
                        <a href="javascript:;" class="reload"></a>
                        <a href="javascript:;" class="remove"></a>--%>
        </div>
    </div>

    <div class="portlet-body form">
        <div class="table-responsive">
            <cc3:GridView ID="dtgModuleControls" runat="server" AutoGenerateColumns="False"
                CssClass="table table-striped table-hover table-bordered dataTable"
                OnRowCommand="dtgModuleControls_RowCommand" OnRowDataBound="dtgModuleControls_RowDataBound"
                Width="100%" meta:resourcekey="dtgModuleControlsResource1" AllowPaging="True" PageSize="16">
                <AlternatingRowStyle CssClass="odd" />
                <RowStyle CssClass="even" />
                <HeaderStyle CssClass="sorting_disabled" />
                <Columns>
                    <asp:BoundField DataField="ControlID" Visible="False" meta:resourcekey="BoundFieldResource1" />
                    <asp:BoundField DataField="ControlName" HeaderText="T&#234;n control" meta:resourcekey="BoundFieldResource2" />
                    <asp:BoundField DataField="ControlKey" HeaderText="Lệnh" meta:resourcekey="BoundFieldResource3" />
                    <asp:TemplateField HeaderText="Đường dẫn" meta:resourcekey="BoundFieldResource4">
                        <ItemStyle HorizontalAlign="left" />
                        <ItemTemplate>
                            <asp:Label ID="lblControlPath" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Thao t&#225;c" meta:resourcekey="TemplateFieldResource1">

                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                        <ItemTemplate>
                            <cc2:ButtonRoleEdit ID="btnEditControl" runat="server" CommandArgument='<%# Eval("ControlID") %>'
                                CommandName="editcontrol" CssClass="btn default btn-xs blue" Text="Sửa" meta:resourcekey="btnEditControlResource1" />
                            <cc2:ButtonRoleDelete ID="btnDeleteControl" runat="server" CommandArgument='<%# Eval("ControlID") %>'
                                CommandName="deletecontrol" CssClass="btn default btn-xs dark" Text="X&#243;a" meta:resourcekey="btnDeleteControlResource1" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </cc3:GridView>
        </div>
    </div>
     <div class="form-actions"> <cc2:ButtonRoleAdd ID="btnAddControl" runat="server" CssClass="btn green" Text="Thêm Control"
            OnClick="btnAddControl_Click" /></div>
</div>

