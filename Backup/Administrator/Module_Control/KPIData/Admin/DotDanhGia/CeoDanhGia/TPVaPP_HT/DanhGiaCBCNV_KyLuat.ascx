<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhGiaCBCNV_KyLuat.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.DotDanhGia.CeoDanhGia.TPVaPP_HT.DanhGiaCBCNV_KyLuat" %>
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
                <tr>
                    <td>
                        <strong>TBP đánh giá:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPTDanhGia1" CssClass="form-control" Width="150px" runat="server">                          
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 40%">
                        <strong>Nhận xét:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNhanXet1" CssClass="form-control" Width="150px" runat="server"
                            Rows="3" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top" id="td3" runat="server">
            <table width="100%" border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td colspan="2">
                        <b style="color: Red">2. Nhiệt tình trách nhiệm với công việc<br />
                            <br />
                        </b>
                    </td>
                </tr>
                <tr style="display: none">
                    <td>
                        <strong>PT đánh giá:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPTDanhGia3" CssClass="form-control" Width="150px" runat="server">                          
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>TBP đánh giá:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTBPDanhGia3" CssClass="form-control" Width="150px" runat="server">                          
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 40%">
                        <strong>Nhận xét:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNhanXet3" CssClass="form-control" Width="150px" runat="server"
                            Rows="3" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top" id="td4" runat="server">
            <table width="100%" border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td colspan="2">
                        <b style="color: Red">3. Linh hoạt sáng tạo trong công việc<br />
                            <br />
                        </b>
                    </td>
                </tr>
                <tr style="display: none">
                    <td>
                        <strong>PT đánh giá:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPTDanhGia4" CssClass="form-control" Width="150px" runat="server">                          
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>TBP đánh giá:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTBPDanhGia4" CssClass="form-control" Width="150px" runat="server">                          
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 40%">
                        <strong>Nhận xét:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNhanXet4" CssClass="form-control" Width="150px" runat="server"
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
                <tr>
                    <td>
                        <strong>TBP đánh giá:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPTDanhGia2" CssClass="form-control" Width="150px" runat="server">                          
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 40%">
                        <strong>Nhận xét:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNhanXet2" CssClass="form-control" Width="150px" runat="server"
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
        <td colspan="4">
            <br />
            <b style="color: Red">Lưu ý:</b> • 100%: chấp nhận được • Trên 100%: vượt mức, xuất
            sắc • Dưới 100%: Chưa đạt kỳ vọng • Điểm tối đa là 130% • Bước nhẩy là 1%
            <br />
            <br />
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
                                    Làm việc tốt và không có phàn nàn khi làm việc trong một nhóm tại bộ phận hoặc các
                                    bộ phận khác trong công ty
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top" id="td31" runat="server">
            <table width="100%" border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td colspan="2" style="line-height: 20px; font-size: 13px; font-style: normal; vertical-align: top;">
                        <table cellpadding="5" cellspacing="0">
                            <tr>
                                <td colspan="2" style="vertical-align: top">
                                    Tinh thần sẵn sàng vượt qua mọi trở ngại và khắc phục khó khăn, ý thức làm tốt nhất
                                    trong điều kiện có thể, giải quyết tận cùng vấn đề và hỗ trợ hiệu quả các thành
                                    viên. Tạo được nhiệt huyết và truyền cảm hứng cho các thành viên bộ phận.
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top" id="td41" runat="server">
            <table width="100%" border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td colspan="2" style="line-height: 20px; font-size: 13px; font-style: normal; vertical-align: top;">
                        <table cellpadding="5" cellspacing="0">
                            <tr>
                                <td colspan="2" style="vertical-align: top">
                                    Giải quyết nhanh chóng các tình huống phát sinh trong phạm vi chức trách của mình.
                                    Chủ động xin ý kiến và đưa ra các tình huống giải quyết các vấn đề phức tạp lên
                                    Lãnh đạo cấp trên. Luôn chủ động tạo dựng các mối quan hệ hợp tác, đối tác,… nhằm
                                    hỗ trợ công việc của bộ phận và của Công ty tốt hơn.
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
                                    Thực hiện tốt các quy định của Công ty: thời gian làm việc, họp, trung thực, thẳng
                                    thắn và có tinh thần xây dựng. Luôn là người nhiệt thành tham gia các hoạt động
                                    chung. Không vi phạm những giá trị văn hóa, chuẩn mực của Công ty.
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
