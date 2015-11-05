<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PortalCacheManager.ascx.cs"
    Inherits="Portal.Administrator.Portals.PortalCacheManager" %>
<%@ Register Assembly="VmgPortal.WebControls" Namespace="VmgPortal.WebControls" TagPrefix="cc2" %>
<asp:UpdatePanel ID="upanelPortalCacheManagement" runat="server" UpdateMode="Conditional"
    RenderMode="Inline">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnRemoveAll" EventName="Click" />
    </Triggers>
    <ContentTemplate>
        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%" class="InputBox">
            <tr>
                <td align="center">
                    <asp:Label ID="lblUpdateStatus" runat="server" meta:resourcekey="lblUpdateStatusResource1"
                        Font-Bold="True" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table width="471" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td>
                                <div class="form-group">
                                    <asp:ListBox ID="lstAllCache" runat="server" CssClass="form-control" Height="311px" Width="471px" SelectionMode="Multiple"></asp:ListBox>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center"></td>
            </tr>
            <tr>
                <td align="center">
                    <cc2:ButtonRoleDelete ID="btnRemoveAll" runat="server" CssClass="btn green" OnClick="btnRemoveAll_Click"
                        Text="Xóa toàn bộ cache hệ thống quản trị" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
