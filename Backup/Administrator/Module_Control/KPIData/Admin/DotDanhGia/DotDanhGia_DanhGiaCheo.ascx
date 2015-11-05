<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DotDanhGia_DanhGiaCheo.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.DotDanhGia.DotDanhGia_DanhGiaCheo" %>
<%@ Register Assembly="VmgPortal.Library" Namespace="VmgPortal.Library.Controls"
    TagPrefix="cc1" %>
<table id="tblContent" runat="server" border="0" cellpadding="5" cellspacing="0"
    style="width: 100%">
    <tr>
        <td height="10">
        </td>
    </tr>
    <tr>
        <td valign="top" class="InputBox" colspan="6" style="width: 100%;">
            <table width="100%" border="0" cellpadding="5" cellspacing="0">
                <tr>
                    <td width="150px">
                        Chọn đợt đánh giá:
                    </td>
                    <td>
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
            <table border="0" cellpadding="5" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Phòng hệ thống</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr>
                                <td width="70px">
                                    <asp:TextBox ID="txtTLHTCongViecIT" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td align="left" width="10px">
                                    %
                                </td>
                                <td width="70px" align="center">
                                    *
                                    <asp:Label ID="lblDiemIT" Text="10" runat="server"></asp:Label>
                                </td>
                                <td>
                                    =
                                    <asp:Label ID="lblDiemCuoiIT" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%">
            <table border="0" cellpadding="5" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Phòng NSHC</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr>
                                <td width="70px">
                                    <asp:TextBox ID="txtTLHTCongViecNSHC" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td align="left" width="10px">
                                    %
                                </td>
                                <td width="70px" align="center">
                                    *
                                    <asp:Label ID="lblDiemNSHC" Text="10" runat="server"></asp:Label>
                                </td>
                                <td>
                                    =
                                    <asp:Label ID="lblDiemCuoiNSHC" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%">
            <table border="0" cellpadding="5" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Phòng TCKT</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr>
                                <td width="70px">
                                    <asp:TextBox ID="txtTLHTCongViecTCKT" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td align="left" width="10px">
                                    %
                                </td>
                                <td width="70px" align="center">
                                    *
                                    <asp:Label ID="lblDiemTCKT" Text="10" runat="server"></asp:Label>
                                </td>
                                <td>
                                    =
                                    <asp:Label ID="lblDiemCuoiTCKT" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%" valign="top">
            <table border="0" cellpadding="5" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Trung tâm DVKH</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr>
                                <td width="70px">
                                    <asp:TextBox ID="txtTLHTCongViecDVKH" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td align="left" width="10px">
                                    %
                                </td>
                                <td width="70px" align="center">
                                    *
                                    <asp:Label ID="lblDiemDVKH" Text="10" runat="server"></asp:Label>
                                </td>
                                <td>
                                    =
                                    <asp:Label ID="lblDiemCuoiDVKH" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%;">
            <table border="0" cellpadding="5" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Phòng DSTC</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr>
                                <td width="70px">
                                    <asp:TextBox ID="txtTLHTCongViecDSTC" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td align="left" width="10px">
                                    %
                                </td>
                                <td width="70px" align="center">
                                    *
                                    <asp:Label ID="lblDiemDSTC" Text="10" runat="server"></asp:Label>
                                </td>
                                <td>
                                    =
                                    <asp:Label ID="lblDiemCuoiDSTC" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%">
            <table border="0" cellpadding="5" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Phòng PTDV</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr>
                                <td width="70px">
                                    <asp:TextBox ID="txtTLHTCongViecPTDV" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td align="left" width="10px">
                                    %
                                </td>
                                <td width="70px" align="center">
                                    *
                                    <asp:Label ID="lblDiemPTDV" Text="10" runat="server"></asp:Label>
                                </td>
                                <td>
                                    =
                                    <asp:Label ID="lblDiemCuoiPTDV" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                        </table>
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
        <td class="InputBox" style="width: 20%; display: none">
            <table border="0" cellpadding="5" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>VP HCM</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtTLHTCongViecVPHCM" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>%
                                </td>
                                <td>
                                    *
                                    <asp:Label ID="lblDiemVPHCM" Text="5" runat="server"></asp:Label>
                                </td>
                                <td>
                                    =
                                    <asp:Label ID="lblDiemCuoiVPHCM" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                        </table>
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
            <table border="0" cellpadding="5" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Trung tâm PTND</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr>
                                <td width="70px">
                                    <asp:TextBox ID="txtTLHTCongViecPTND" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td align="left" width="10px">
                                    %
                                </td>
                                <td width="70px" align="center">
                                    *
                                    <asp:Label ID="lblDiemPTND" Text="5" runat="server"></asp:Label>
                                </td>
                                <td>
                                    =
                                    <asp:Label ID="lblDiemCuoiPTND" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%">
            <table border="0" cellpadding="5" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Trung tâm LUCKYFONE</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr>
                                <td width="70px">
                                    <asp:TextBox ID="txtTLHTCongViecLUCKYFONE" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td align="left" width="10px">
                                    %
                                </td>
                                <td width="70px" align="center">
                                    *
                                    <asp:Label ID="lblDiemLUCKYFONE" Text="5" runat="server"></asp:Label>
                                </td>
                                <td>
                                    =
                                    <asp:Label ID="lblDiemCuoiLUCKYFONE" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%">
            <table border="0" cellpadding="5" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Trung tâm BANQUYEN</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr>
                                <td width="70px">
                                    <asp:TextBox ID="txtTLHTCongViecBANQUYEN" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td align="left" width="10px">
                                    %
                                </td>
                                <td width="70px" align="center">
                                    *
                                    <asp:Label ID="lblDiemBANQUYEN" Text="5" runat="server"></asp:Label>
                                </td>
                                <td>
                                    =
                                    <asp:Label ID="lblDiemCuoiBANQUYEN" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%">
            <table border="0" cellpadding="5" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Trung tâm PTKD</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr>
                                <td width="70px">
                                    <asp:TextBox ID="txtTLHTCongViecPTKD" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td align="left" width="10px">
                                    %
                                </td>
                                <td width="70px" align="center">
                                    *
                                    <asp:Label ID="lblDiemPTKD" Text="5" runat="server"></asp:Label>
                                </td>
                                <td>
                                    =
                                    <asp:Label ID="lblDiemCuoiPTKD" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%">
            <table border="0" cellpadding="5" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Trung tâm QCS</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr>
                                <td width="70px">
                                    <asp:TextBox ID="txtTLHTCongViecQCS" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td align="left" width="10px">
                                    %
                                </td>
                                <td width="70px" align="center">
                                    *
                                    <asp:Label ID="lblDiemQCS" Text="10" runat="server"></asp:Label>
                                </td>
                                <td>
                                    =
                                    <asp:Label ID="lblDiemCuoiQCS" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
        <td class="InputBox" style="width: 15%">
            <table border="0" cellpadding="5" cellspacing="3" style="width: 100%">
                <tr>
                    <td>
                        <b>Phòng Marketing</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr>
                                <td width="70px">
                                    <asp:TextBox ID="txtTLHTCongViecMarketing" runat="server" Width="70px" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td align="left" width="10px">
                                    %
                                </td>
                                <td width="70px" align="center">
                                    *
                                    <asp:Label ID="lblDiemMarketing" Text="10" runat="server"></asp:Label>
                                </td>
                                <td>
                                    =
                                    <asp:Label ID="lblDiemCuoiMarketing" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                        </table>
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
        <td class="InputBox" colspan="6" align="center" height="50px">
            <asp:Button ID="btnUpdate" runat="server" CssClass="btn blue" Text="Cập  nhật" OnClick="btnUpdate_Click" />
        </td>
    </tr>
</table>
