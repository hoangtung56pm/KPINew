<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DotDanhGia_TLHTCongViec.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.DotDanhGia.DotDanhGia_TLHTCongViec" %>
<%@ Register Assembly="VmgPortal.Library" Namespace="VmgPortal.Library.Controls"
    TagPrefix="cc1" %>
<table id="tblContent" runat="server" border="0" cellpadding="2" cellspacing="2"
    width="100%">
    <tr>
        <td height="10">
        </td>
    </tr>
    <tr>
        <td valign="top" class="InputBox" colspan="7" style="width: 100%;">
            <table width="100%" border="0" cellpadding="5" cellspacing="0">
                <tr>
                    <td width="150px">
                        Chọn đợt đánh giá:
                    </td>
                    <td align="left">
                        <asp:DropDownList AutoPostBack="true" CssClass="form-control" Width="300px" ID="dropDotDanhGia"
                            runat="server" DataTextField="Ten" DataValueField="ID" OnSelectedIndexChanged="dropDotDanhGia_SelectedIndexChanged">
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
        <td class="InputBox" style="width: 15%">
            <table border="0" cellpadding="3" cellspacing="3" width="100%">
                <tr>
                    <td colspan="2">
                        <b>Phòng hệ thống</b>
                    </td>
                </tr>
                <tr>
                    <td width="70px">
                        <asp:TextBox ID="txtTLHTCongViecIT" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                    </td>
                     <td align="left" width="80%">
                        %
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%">
            <table border="0" cellpadding="3" cellspacing="3" width="100%">
                <tr>
                    <td colspan="2">
                        <b>Phòng NSHC</b>
                    </td>
                </tr>
                <tr>
                    <td width="70px">
                        <asp:TextBox ID="txtTLHTCongViecNSHC" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                    </td>
                     <td align="left" width="80%">
                        %
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%">
            <table border="0" cellpadding="3" cellspacing="3" width="100%">
                <tr>
                    <td colspan="2">
                        <b>Phòng TCKT</b>
                    </td>
                </tr>
                <tr>
                    <td width="70px">
                        <asp:TextBox ID="txtTLHTCongViecTCKT" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                    </td>
                     <td align="left" width="80%">
                        %
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%" valign="top">
            <table border="0" cellpadding="3" cellspacing="3" width="100%">
                <tr>
                    <td colspan="2">
                        <b>Trung tâm DVKH</b>
                    </td>
                </tr>
                <tr>
                    <td width="70px">
                        <asp:TextBox ID="txtTLHTCongViecDVKH" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                    </td>
                     <td align="left" width="80%">
                        %
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%;">
            <table border="0" cellpadding="3" cellspacing="3" width="100%">
                <tr>
                    <td colspan="2">
                        <b>Phòng DSTC</b>
                    </td>
                </tr>
                <tr>
                    <td width="70px">
                        <asp:TextBox ID="txtTLHTCongViecDSTC" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                    </td>
                     <td align="left" width="80%">
                        %
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%">
            <table border="0" cellpadding="3" cellspacing="3" width="100%">
                <tr>
                    <td colspan="2">
                        <b>Phòng PTDV</b>
                    </td>
                </tr>
                <tr>
                    <td width="70px">
                        <asp:TextBox ID="txtTLHTCongViecPTDV" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                    </td>
                     <td align="left" width="80%">
                        %
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="InputBox" style="width: 15%; display: none">
            <table border="0" cellpadding="3" cellspacing="3" width="100%">
                <tr>
                    <td colspan="2">
                        <b>VP HCM</b>
                    </td>
                </tr>
                <tr>
                    <td width="70px">
                        <asp:TextBox ID="txtTLHTCongViecVPHCM" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="InputBox" style="width: 15%">
            <table border="0" cellpadding="3" cellspacing="3" width="100%">
                <tr>
                    <td colspan="2">
                        <b>Trung tâm PTND</b>
                    </td>
                </tr>
                <tr>
                    <td width="70px">
                        <asp:TextBox ID="txtTLHTCongViecPTND" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                    </td>
                     <td align="left" width="80%">
                        %
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%">
            <table border="0" cellpadding="3" cellspacing="3" width="100%">
                <tr>
                    <td colspan="2">
                        <b>Trung tâm LUCKYFONE</b>
                    </td>
                </tr>
                <tr>
                    <td width="70px">
                        <asp:TextBox ID="txtTLHTCongViecLUCKYFONE" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                    </td>
                     <td align="left" width="80%">
                        %
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%">
            <table border="0" cellpadding="3" cellspacing="3" width="100%">
                <tr>
                    <td colspan="2">
                        <b>Trung tâm BANQUYEN</b>
                    </td>
                </tr>
                <tr>
                    <td width="70px">
                        <asp:TextBox ID="txtTLHTCongViecBANQUYEN" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                    </td>
                     <td align="left" width="80%">
                        %
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%">
            <table border="0" cellpadding="3" cellspacing="3" width="100%">
                <tr>
                    <td colspan="2">
                        <b>Trung tâm PTKD</b>
                    </td>
                </tr>
                <tr>
                    <td width="70px">
                        <asp:TextBox ID="txtTLHTCongViecPTKD" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                    </td>
                     <td align="left" width="80%">
                        %
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%">
            <table border="0" cellpadding="3" cellspacing="3" width="100%">
                <tr>
                    <td colspan="2">
                        <b>Phòng Marketting</b>
                    </td>
                </tr>
                <tr>
                    <td width="70px">
                        <asp:TextBox ID="txtTLHTCongViecMAR" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                    </td>
                     <td align="left" width="80%">
                        %
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%">
            <table border="0" cellpadding="3" cellspacing="3" width="100%">
                <tr>
                    <td colspan="2">
                        <b>Trung tâm QCS</b>
                    </td>
                </tr>
                <tr>
                    <td width="70px">
                        <asp:TextBox ID="txtTLHTCongViecQCS" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td align="left" width="80%">
                        %
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td height="15px">
        </td>
    </tr>
    <tr>
        <td class="InputBox" colspan="7" align="center" height="50px">
            <asp:Button ID="btnUpdate" runat="server" CssClass="btn blue" Text="Cập  nhật" OnClick="btnUpdate_Click" />
        </td>
    </tr>
</table>
