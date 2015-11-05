<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserPassword.ascx.cs"
    Inherits="VmgPortal.Administrator.Users.UserPassword" %>
<asp:UpdatePanel ID="upanelChangePassword" runat="server" UpdateMode="Conditional"
    RenderMode="Inline">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
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
                    <li>
                        <i class="icon-home"></i>
                        <a href="/">Trang chủ</a>
                        <i class="icon-angle-right"></i>
                    </li>                    
                    <li>
                        <a href="#">Đổi mật khẩu người dùng</a>
                        <i class="icon-angle-right"></i>
                    </li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>

            <div class="col-md-3">
            </div>
            <div class="col-md-6">
                <!-- BEGIN VALIDATION STATES-->
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption"><i class="icon-reorder"></i>Đổi mật khẩu</div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a>
                            <%--<a href="#portlet-config" data-toggle="modal" class="config"></a>--%>
                            <a href="javascript:;" class="reload"></a>
                            <%--<a href="javascript:;" class="remove"></a>--%>
                        </div>
                    </div>
                    <div class="portlet-body form">
                        <div class="form-body">
                            <!-- BEGIN FORM-->
                            <%--<h3 class="form-section">Advance validation.  <small>Custom radio buttons, checkboxes and Select2 dropdowns</small></h3>--%>
                            <div id="form_sample_2" class="form-horizontal">
                                <div class="form-group">
                                    <div class="control-label col-md-5"></div>
                                    <div class="col-md-6">
                                        <asp:Label ID="lblUpdateStatus" runat="server" meta:resourcekey="lblUpdateStatusResource1" ForeColor="Blue"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblName" runat="server" class="control-label col-md-5" Text="Tên truy cập:" meta:resourcekey="lblNameResource1"></asp:Label>
                                    <div class="col-md-6">
                                        <asp:Label ID="lblUsername" runat="server" class="form-control" meta:resourcekey="lblUsernameResource1"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblNewPass" class="control-label col-md-5" runat="server" Text="Mật khẩu mới:" meta:resourcekey="lblNewPassResource1"></asp:Label>
                                    <div class="col-md-6">
                                        <div class="input-group">
                                            <asp:TextBox ID="txtPassword" TextMode="Password" class="form-control" runat="server" placeholder="Password" meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                                            <span class="input-group-addon"><i class="icon-user"></i></span>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="lblConfirmNewPass" class="control-label col-md-5" runat="server" Text="Xác nhận mật khẩu mới:" meta:resourcekey="lblConfirmNewPassResource1"></asp:Label>
                                    <div class="col-md-6">
                                        <div class="input-group">
                                            <asp:TextBox ID="txtPasswordConfirm" TextMode="Password" class="form-control" runat="server" placeholder="Password" meta:resourcekey="txtPasswordConfirmResource1"></asp:TextBox>
                                            <span class="input-group-addon"><i class="icon-user"></i></span>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-actions fluid">
                                    <div class="col-md-offset-4 col-md-12">
                                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn blue" OnClick="btnUpdate_Click"
                                            Text="Cập nhật" meta:resourcekey="btnUpdateResource1" />&nbsp;
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn default" OnClick="btnCancel_Click"
                                Text="Quay lại" meta:resourcekey="btnCancelResource1" />
                                    </div>
                                </div>
                            </div>
                            <!-- END FORM-->
                        </div>
                    </div>
                    <!-- END VALIDATION STATES-->
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
