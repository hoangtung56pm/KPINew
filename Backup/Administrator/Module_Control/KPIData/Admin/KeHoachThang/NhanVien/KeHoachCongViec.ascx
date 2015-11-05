<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KeHoachCongViec.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.KeHoachThang.NhanVien.KeHoachCongViec" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Import Namespace="VmgPortal.Library.Utilities" %>
<div class="row">
    <div class="col-md-12">
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnLuoi" runat="server" CssClass="btn green" Text="Xem dưới dạng lưới"
                        OnClick="btnLuoi_Click" />
                </td>
            </tr>
        </table>
        <div class="portlet box blue calendar">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-calendar"></i>Calendar</div>
            </div>
            <div class="portlet-body light-grey">
                <div id='script-warning'>
                </div>
                <div id='loading'>
                    loading...</div>
                <div id="calendar" class="fc fc-ltr">
                </div>
            </div>
        </div>
    </div>
</div>
