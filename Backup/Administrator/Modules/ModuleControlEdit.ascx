<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModuleControlEdit.ascx.cs"
    Inherits="VmgPortal.Administrator.Modules.ModuleControlEdit" %>
<%@ Register Assembly="VmgPortal.WebControls" Namespace="VmgPortal.WebControls" TagPrefix="cc3" %>
<%@ Register Assembly="VmgPortal.FilePickerControl" Namespace="VmgPortal.FilePickerControl"
    TagPrefix="cc1" %>
<div class="portlet box blue">
    <div class="portlet-title">
        <div class="caption">
            <i class="icon-reorder"></i>Cập nhật Control</div>
        <div class="tools">
            <a href="javascript:;" class="collapse"></a><a href="#portlet-config" data-toggle="modal"
                class="config"></a><a href="javascript:;" class="reload"></a><a href="javascript:;"
                    class="remove"></a>
        </div>
    </div>
    <div class="portlet-body form">
        <!-- BEGIN FORM-->
        <div id="form_sample_1" class="form-horizontal">
            <div class="form-body">
                <%--        <div class="alert alert-danger display-hide">
                    <button class="close" data-dismiss="alert"></button>
                    You have some form errors. Please check below.
                </div>
                <div class="alert alert-success display-hide">
                    <button class="close" data-dismiss="alert"></button>
                    Your form validation is successful!
                </div>--%>
                <div class="form-group">
                    <div class="col-md-3">
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="lblUpdateStatus" runat="server" ForeColor="Red" meta:resourcekey="lblUpdateStatusResource1"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3">
                        Tên Module<span class="required">*</span></label>
                    <div class="col-md-4">
                        <asp:Label ID="lblModuleName" runat="server" class="form-control"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3">
                        Tên Control<span class="required">*</span></label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtControlName" runat="server" class="form-control" meta:resourcekey="txtControlNameResource1"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtControlName"
                            ErrorMessage="Chưa nhập tên control" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3">
                        Tiêu đề</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtControlTitle" runat="server" class="form-control" meta:resourcekey="txtControlTitleResource1"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3">
                        Lệnh</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtControlKey" runat="server" class="form-control" meta:resourcekey="txtControlKeyResource1"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3">
                        Đường dẫn</label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="dropPath" runat="server" class="form-control" meta:resourcekey="dropPathResource1">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3">
                        Biểu tượng</label>
                    <div class="col-md-4">
                        <cc1:FilePicker ID="txtControlIcon" runat="server" fpPopupURL="/FilePicker/TUFilePicker.aspx"
                            Width="313px" FileName="" fpAllowedUploadFileExts="" fpUploadSizeLimit="0" meta:resourcekey="txtControlIconResource1"></cc1:FilePicker>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3">
                        Hiển thị Header</label>
                    <div class="col-md-4">
                        <div class="checkbox-list">
                            <label class="checkbox-inline">
                                <span>
                                    <asp:CheckBox ID="chkControlHeader" runat="server" Checked="True" /></span>
                                Header
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3">
                        Mô tả</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtControlDescription" runat="server" Height="103px" class="form-control"
                            TextMode="MultiLine" meta:resourcekey="txtControlDescriptionResource1"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3">
                        Thứ tự</label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="dropControlOrder" runat="server" class="form-control" meta:resourcekey="dropControlOrderResource1">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-actions fluid">
                <div class="col-md-offset-3 col-md-9">
                    <%--  <button type="submit" class="btn green">Submit</button>
                    <button type="button" class="btn default">Cancel</button>--%>
                    <cc3:ButtonRoleEdit ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Cập nhật"
                        CssClass="btn blue" />
                    <cc3:ButtonRoleDelete ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Xóa"
                        CssClass="btn dark" CausesValidation="False" />&nbsp;
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn defaul" Text="Hủy" OnClick="btnCancel_Click"
                        meta:resourcekey="btnCancelResource1" CausesValidation="False" />
                </div>
            </div>
        </div>
        <!-- END FORM-->
    </div>
</div>
<asp:UpdatePanel ID="upanelModuleControlEdit" runat="server" UpdateMode="Conditional"
    RenderMode="Inline">
    <ContentTemplate>
        <table border="0" cellpadding="2" cellspacing="2" class="InputBox" style="width: 100%">
            <tr style="visibility: hidden; display: none;">
                <td style="height: 19px" valign="top">
                    <asp:Label ID="lblRoles" runat="server" Text="Quyền truy cập" meta:resourcekey="lblRolesResource1"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:CheckBoxList ID="chkControlType" runat="server" CellPadding="0" CellSpacing="0"
                        DataTextField="RoleName" DataValueField="RoleID" meta:resourcekey="chkControlTypeResource1">
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
