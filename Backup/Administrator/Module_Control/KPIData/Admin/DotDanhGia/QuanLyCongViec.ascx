<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuanLyCongViec.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.DotDanhGia.QuanLyCongViec" %>
<%@ Import Namespace="VmgPortal.Library.Utilities" %>
<%@ Register Src="QuanLyCongViecKPI.ascx" TagName="QuanLyCongViecKPI" TagPrefix="uc1" %>
<%@ Register Src="QuanLyCongViecKTX.ascx" TagName="QuanLyCongViecKTX" TagPrefix="uc2" %>
<%@ Register Src="QuanLyCongViecPS.ascx" TagName="QuanLyCongViecPS" TagPrefix="uc3" %>
<%--<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>--%>
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
            <asp:Literal ID="litNav" runat="server"></asp:Literal>
            <div class="tab-content">
                <asp:Literal ID="litTab0" runat="server"></asp:Literal>
                <%--<div id="tab_0" class="tab-pane active">--%>
                <div class="portlet box grey">
                    <div class="portlet-body form">
                        <uc1:QuanLyCongViecKPI ID="QuanLyCongViecKPI1" runat="server" />
                    </div>
                </div>
            </div>
            <asp:Literal ID="litTab1" runat="server"></asp:Literal>
            <%--<div id="tab_1" class="tab-pane">--%>
            <div class="portlet box grey">
                <div class="portlet-body form">
                    <uc2:QuanLyCongViecKTX ID="QuanLyCongViecKTX1" runat="server" />
                </div>
            </div>
        </div>
        <asp:Literal ID="litTab2" runat="server"></asp:Literal>
        <%--<div id="tab_2" class="tab-pane">--%>
        <div class="portlet box grey">
            <div class="portlet-body form">
                <uc3:QuanLyCongViecPS ID="QuanLyCongViecPS1" runat="server" />
            </div>
        </div>
    </div>
</div>
</div> </div> </div> 