<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuanLyGiaoViec.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.DotDanhGia.QuanLyGiaoViec" %>
<%@ Import Namespace="VmgPortal.Library.Utilities" %>
<%@ Register Assembly="RadTabStrip.Net2" Namespace="Telerik.WebControls" TagPrefix="radTS" %>
<%@ Register Src="QuanLyCongViecKPIVaNhanVine.ascx" TagName="QuanLyCongViecKPIVaNhanVine"
    TagPrefix="uc1" %>
<%@ Register Src="QuanLyCongViecKTXVaNhanVien.ascx" TagName="QuanLyCongViecKTXVaNhanVien"
    TagPrefix="uc2" %>
<%@ Register Src="QuanLyCongViecPSVaNhanVien.ascx" TagName="QuanLyCongViecPSVaNhanVien"
    TagPrefix="uc3" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
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
                <div class="portlet box grey">
                    <div class="portlet-body form">
                        <%-- <asp:UpdatePanel ID="updateQuanLyCongViecKPIVaNhanVine1" runat="server">
                                <ContentTemplate>--%>
                        <uc1:QuanLyCongViecKPIVaNhanVine ID="QuanLyCongViecKPIVaNhanVine1" runat="server" />
                        <%--   </ContentTemplate>
                            </asp:UpdatePanel>--%>
                    </div>
                </div>
            </div>
            <asp:Literal ID="litTab1" runat="server"></asp:Literal>
            <div class="portlet box grey">
                <div class="portlet-body form">
                    <%--   <asp:UpdatePanel ID="updateQuanLyCongViecKTXVaNhanVien1" runat="server">
                                <ContentTemplate>--%>
                    <uc2:QuanLyCongViecKTXVaNhanVien ID="QuanLyCongViecKTXVaNhanVien1" runat="server" />
                    <%-- </ContentTemplate>
                            </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
        <asp:Literal ID="litTab2" runat="server"></asp:Literal>
        <div class="portlet box grey">
            <div class="portlet-body form">
                <%-- <asp:UpdatePanel ID="updateQuanLyCongViecPSVaNhanVien1" runat="server">
                                <ContentTemplate>--%>
                <uc3:QuanLyCongViecPSVaNhanVien ID="QuanLyCongViecPSVaNhanVien1" runat="server" />
                <%-- </ContentTemplate>
                            </asp:UpdatePanel>--%>
            </div>
        </div>
    </div>
</div>
</div> </div> </div> 