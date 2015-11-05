<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhGiaCBCNV_KyLuat.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.DotDanhGia.CeoDanhGia.LanhDao_KD.DanhGiaCBCNV_KyLuat" %>
<table id="TABLE1" border="0" cellpadding="2" cellspacing="2" style="width: 100%">
    <tr>
        <td height="15px">
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblUpdateStatus" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
        </td>
    </tr>
    <tr>
        <td valign="top" id="td1" runat="server">
            <table width="100%" border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td colspan="2">
                        <b style="color: Red">1. Quản lý công việc, tính chủ động, phối hợp làm việc nhóm</b>
                    </td>
                </tr>
                <tr style="display: none">
                    <td>
                        <strong>PT đánh giá:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPTDanhGia1" CssClass="form-control" Width="150px" runat="server">                          
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>CEO đánh giá:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTBPDanhGia1" CssClass="form-control" Width="150px" runat="server">                          
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 40%">
                        <strong>Nhận xét:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNhanXet1" CssClass="form-control" Width="250px" runat="server"
                            Rows="3" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top" id="td2" runat="server">
            <table width="100%" border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td colspan="2">
                        <b style="color: Red">2. Kỷ luật lao động cá nhân</b><br />
                        <br />
                    </td>
                </tr>
                <tr style="display: none">
                    <td>
                        <strong>PT đánh giá:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPTDanhGia2" CssClass="form-control" Width="150px" runat="server">                          
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>CEO đánh giá:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTBPDanhGia2" CssClass="form-control" Width="150px" runat="server">                          
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 40%">
                        <strong>Nhận xét:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNhanXet2" CssClass="form-control" Width="250px" runat="server"
                            Rows="3" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td valign="top" align="center" colspan="5" style="width: 100%;">
            <asp:Button ID="btnUpdateAll" runat="server" CssClass="btn green" Width="100px" Text="Cập  nhật"
                OnClick="btnUpdateAll_Click" />
        </td>
    </tr>
    <tr>
        <td valign="top" id="td11" runat="server">
            <table width="100%" border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td colspan="2" style="line-height: 20px; font-size: 13px; font-style: normal; vertical-align: top;">
                        <table cellpadding="5" cellspacing="0">
                            <tr>
                                <td colspan="2" style="vertical-align: top">
                                    Lưu ý: nếu nhân sự không có gì nổi bật thì được chấm điểm 100%, nếu nổi bật được
                                    chấm điểm trên 100%, không tốt thì chấm điểm dưới 100%
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top" id="td21" runat="server">
            <table width="100%" border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td colspan="2" style="line-height: 20px; font-size: 13px; font-style: normal; vertical-align: top;">
                        <table cellpadding="5" cellspacing="0">
                            <tr>
                                <td colspan="2" style="vertical-align: top">
                                    Lưu ý: Nhân viên không vi phạm kỷ luật gì thì được 100%, nếu có một vài vi phạm
                                    thì điểm dưới 100% và xuất sắc thì điểm trên 100%
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
