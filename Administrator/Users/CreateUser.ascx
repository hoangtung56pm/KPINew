<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateUser.ascx.cs"
    Inherits="VmgPortal.Administrator.Users.CreateUser" %>
<%@ Register Assembly="RadTabStrip.Net2" Namespace="Telerik.WebControls" TagPrefix="radTS" %>
<%@ Register Src="LyLichCaNhan.ascx" TagName="LyLichCaNhan" TagPrefix="uc1" %>
<%@ Register Src="ThongTinMoRong.ascx" TagName="ThongTinMoRong" TagPrefix="uc2" %>
<%@ Register Src="ThongTinGiaDinh.ascx" TagName="ThongTinGiaDinh" TagPrefix="uc3" %>
<%@ Register Src="HocVanKhenThuongToChuc.ascx" TagName="HocVanKhenThuongToChuc" TagPrefix="uc4" %>
<%@ Register Src="QuaTrinhLamViecVaBHXH.ascx" TagName="QuaTrinhLamViecVaBHXH" TagPrefix="uc5" %>
<%@ Register Src="HDLDBatDauGH1GH2.ascx" TagName="HDLDBatDauGH1GH2" TagPrefix="uc6" %>
<%@ Register Src="HDLDGH3GH4GH5.ascx" TagName="HDLDGH3GH4GH5" TagPrefix="uc7" %>
<%@ Register Src="CacDieuChinhNhanSu.ascx" TagName="CacDieuChinhNhanSu" TagPrefix="uc8" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<div class="row">
    <div class="col-md-12">
        <div class="tabbable tabbable-custom boxless">
            <ul class="nav nav-tabs">
                <li class="active"><a data-toggle="tab" href="#tab_0">Lý lịch cá nhân</a></li>
                <li class=""><a data-toggle="tab" href="#tab_1">Thông tin mở rộng</a></li>
                <li class=""><a data-toggle="tab" href="#tab_2">Gia đình</a></li>
                <li class=""><a data-toggle="tab" href="#tab_3">Học vấn/Khen thưởng</a></li>
                <li class=""><a data-toggle="tab" href="#tab_4">QTLV trước đây/BHXH</a></li>
                <li><a data-toggle="tab" href="#tab_5">HDLD (Bắt đầu/GH lần 1/GH lần 2)</a></li>
                <li><a data-toggle="tab" href="#tab_6">HDLD (GH lần 3/GH lần 4/GH lần 5)</a></li>
                <li><a data-toggle="tab" href="#tab_7">Các DCNS</a></li>
            </ul>
            <div class="tab-content">
                <div id="tab_0" class="tab-pane active">
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-reorder"></i>Lý lịch cá nhân</div>
                            <div class="tools">
                                <a class="collapse" href="javascript:;"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <asp:UpdatePanel ID="upanelLyLichCaNhan1" runat="server" UpdateMode="Conditional"
                                RenderMode="Inline">
                                <ContentTemplate>
                                    <uc1:LyLichCaNhan ID="LyLichCaNhan1" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <!-- END FORM-->
                        </div>
                    </div>
                </div>
                <div id="tab_1" class="tab-pane">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-reorder"></i>Thông tin mở rộng</div>
                            <div class="tools">
                                <a class="collapse" href="javascript:;"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                <ContentTemplate>
                                    <uc2:ThongTinMoRong ID="ThongTinMoRong1" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <!-- END FORM-->
                        </div>
                    </div>
                </div>
                <div id="tab_2" class="tab-pane">
                    <div class="portlet box purple">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-reorder"></i>Gia đình</div>
                            <div class="tools">
                                <a class="collapse" href="javascript:;"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                <ContentTemplate>
                                    <uc3:ThongTinGiaDinh ID="ThongTinGiaDinh1" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <!-- END FORM-->
                        </div>
                    </div>
                </div>
                <div id="tab_3" class="tab-pane">
                    <div class="portlet box red">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-reorder"></i>Học vấn/Khen thưởng</div>
                            <div class="tools">
                                <a class="collapse" href="javascript:;"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                <ContentTemplate>
                                    <uc4:HocVanKhenThuongToChuc ID="HocVanKhenThuongToChuc1" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <!-- END FORM-->
                        </div>
                    </div>
                </div>
                <div id="tab_4" class="tab-pane">
                    <div class="portlet box yellow">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-reorder"></i>QTLV trước đây/BHXH</div>
                            <div class="tools">
                                <a class="collapse" href="javascript:;"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                <ContentTemplate>
                                    <uc5:QuaTrinhLamViecVaBHXH ID="QuaTrinhLamViecVaBHXH1" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <!-- END FORM-->
                        </div>
                    </div>
                </div>
                <div id="tab_5" class="tab-pane">
                    <div class="portlet box red ">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-reorder"></i>HDLD (Bắt đầu/GH lần 1/GH lần 2)</div>
                            <div class="tools">
                                <a class="collapse" href="javascript:;"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                <ContentTemplate>
                                    <uc6:HDLDBatDauGH1GH2 ID="HDLDBatDauGH1GH21" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <!-- END FORM-->
                        </div>
                    </div>
                </div>
                <div id="tab_6" class="tab-pane">
                    <div class="portlet box blue ">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-reorder"></i>HDLD (GH lần 3/GH lần 4/GH lần 5)</div>
                            <div class="tools">
                                <a class="collapse" href="javascript:;"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                <ContentTemplate>
                                    <uc7:HDLDGH3GH4GH5 ID="HDLDGH3GH4GH51" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <!-- END FORM-->
                        </div>
                    </div>
                </div>
                <div id="tab_7" class="tab-pane">
                    <div class="portlet box green ">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-reorder"></i>Các DCNS</div>
                            <div class="tools">
                                <a class="collapse" href="javascript:;"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                <ContentTemplate>
                                    <uc8:CacDieuChinhNhanSu ID="CacDieuChinhNhanSu1" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <!-- END FORM-->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
