<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhGiaCBCNV_DichVuKhachHangDiemThuongPhat.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.DotDanhGia.CeoDanhGia.LanhDao_HT.DanhGiaCBCNV_DichVuKhachHangDiemThuongPhat" %>
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
        <td valign="top" style="width: 20%;">
        </td>
        <td valign="top" style="width: 20%;">
            <table width="100%" border="0" cellpadding="2" cellspacing="2">
                <%--<tr>
                    <td colspan="2">
                        <b style="color: Red">Khối lượng công việc</b>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <strong>Điểm đánh giá:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDiemThuong" CssClass="form-control" Width="50px" runat="server">
                          
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Lý do:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLyDoThuong" CssClass="form-control" runat="server" TextMode="MultiLine"
                            Rows="3"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top" style="width: 20%;">
        </td>
    </tr>
    <tr>
        <td height="15px">
        </td>
    </tr>
    <tr>
        <td valign="top" align="center" colspan="4" style="width: 100%;">
            <asp:Button ID="btnUpdateAll" runat="server" CssClass="btn green" Height="40px" Width="100px"
                Text="Cập  nhật" OnClick="btnUpdateAll_Click" />
        </td>
    </tr>
    <tr>
        <td height="15px">
        </td>
    </tr>
    <%--<tr>
        <td valign="top" style="width: 20%;">
        </td>
        <td valign="top" style="width: 20%;">
            <table width="100%" border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td colspan="2" style="line-height: 20px; font-size: 13px; font-style: normal; vertical-align: top;">
                        <table cellpadding="5" cellspacing="0">
                            <tr>
                                <td width="50px" style="vertical-align: top">
                                </td>
                                <td>
                                    * Sáng tạo: 1% cho sáng tạo được BQL ghi nhận (không tính số lượng) * Các khen thưởng
                                    khác dựa trên quyết định khen thưởng (khen thưởng sẽ ghi rõ điểm thưởng KPI là bao
                                    nhiêu)
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top" style="width: 20%;">
        </td>
    </tr>--%>
</table>
