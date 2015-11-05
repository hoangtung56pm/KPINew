<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhGiaCBCNV.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.HoTroCongViec.DanhGiaCBCNV" %>
<%@ Register Assembly="RadTabStrip.Net2" Namespace="Telerik.WebControls" TagPrefix="radTS" %>
<%@ Register Src="DanhGiaCBCNV_KhoiLuong.ascx" TagName="DanhGiaCBCNV_KhoiLuong" TagPrefix="uc1" %>
<%@ Register Src="DanhGiaCBCNV_KhoiLuongCVKTX.ascx" TagName="DanhGiaCBCNV_KhoiLuongCVKTX"
    TagPrefix="uc4" %>
<%@ Register Src="DanhGiaCBCNV_KhoiLuongCVPhatSinh.ascx" TagName="DanhGiaCBCNV_KhoiLuongCVPhatSinh"
    TagPrefix="uc5" %>
<style>
    .tabbable-custom.boxless > .tab-content
    {
        padding: 0px 0;
        border-left: none;
        border-right: none;
        border-bottom: none;
    }
</style>
<div class="row">
    <div class="col-md-12">
        <div class="tabbable tabbable-custom boxless">
            <table align="center" id="tableContent" runat="server" cellpadding="0" cellspacing="0"
                border="0" width="100%">
                <tr>
                    <td style="height: 5px">
                    </td>
                </tr>
                <tr>
                    <td valign="top" style="width: 100%;">
                        <table class="InputBox" width="100%" border="0" cellpadding="5" cellspacing="0">
                            <tr>
                                <td width="120px">
                                    Đợt đánh giá:
                                </td>
                                <td>
                                    <asp:DropDownList AutoPostBack="true" Width="300px" ID="dropDotDanhGia" runat="server"
                                        CssClass="form-control" DataTextField="Ten" DataValueField="ID" OnSelectedIndexChanged="dropDotDanhGia_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 15px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <ul class="nav nav-tabs">
                            <li class="active"><a data-toggle="tab" href="#tab_0"><b>CÔNG VIỆC THƯỜNG XUYÊN</b></a></li>
                            <li class=""><a data-toggle="tab" href="#tab_1"><b>CÔNG VIỆC KẾ HOẠCH THÁNG</b></a></li>
                            <li class=""><a data-toggle="tab" href="#tab_2"><b>CÔNG VIỆC PHÁT SINH</b></a></li>
                        </ul>
                        <div class="tab-content">
                            <div id="tab_0" class="tab-pane active">
                                <div class="portlet box grey">
                                    <div class="portlet-body form">
                                        <uc1:DanhGiaCBCNV_KhoiLuong ID="DanhGiaCBCNV_KhoiLuong1" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div id="tab_1" class="tab-pane">
                                <div class="portlet box grey">
                                    <div class="portlet-body form">
                                        <uc4:DanhGiaCBCNV_KhoiLuongCVKTX ID="DanhGiaCBCNV_KhoiLuongCVKTX1" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div id="tab_2" class="tab-pane">
                                <div class="portlet box grey">
                                    <div class="portlet-body form">
                                        <uc5:DanhGiaCBCNV_KhoiLuongCVPhatSinh ID="DanhGiaCBCNV_KhoiLuongCVPhatSinh1" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
