<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PortalList.ascx.cs"
    Inherits="VmgPortal.Administrator.UserControls.PortalList" %>
<asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatLayout=Table RepeatColumns=3>
    <ItemTemplate>
        <table width="100%" cellpadding="10" cellspacing="10">
            <tr>
                <td>
                    <%--<asp:ImageButton ID=imgAvatar runat=server CommandArgument='<%# Eval("PortalID") %>' CommandName="Redirect" />                                 --%>
                    <asp:Image ID=imgAvatar runat=server />
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>