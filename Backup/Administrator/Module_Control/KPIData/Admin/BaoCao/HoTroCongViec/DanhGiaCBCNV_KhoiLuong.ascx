<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhGiaCBCNV_KhoiLuong.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.HoTroCongViec.DanhGiaCBCNV_KhoiLuong" %>
<table id="TABLE1" border="0" cellpadding="2" cellspacing="2" style="width: 100%">
    <tr>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblStatusUpdate" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2" valign="top" style="width: 100%;">
            <b style="font-size: 14px; color: Red">1. Những công việc thường xuyên /thực hiện hàng
                tháng của Nhân sự</b>
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="2" style="width: 100%;">
            <table border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td>
                        <table width="100%" cellpadding="5" cellspacing="0">
                            <tr>
                                <td width="150px">
                                    • <b>Tên công việc:</b>
                                </td>
                                <td>
                                    Những công việc được giao hoặc đầu mục công việc thực hiện
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    • <b>Tỷ trọng (%):</b>
                                </td>
                                <td>
                                    Là % công sức và thời gian mà nhân sự dành cho mỗi công việc trong tổng thể: con
                                    số này được đặt công thức tự động từ phần giao việc của trưởng bộ phận.
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    • <b>Cam kết:</b>
                                </td>
                                <td>
                                    Kế hoạch thực hiện của nhân sự về số lương, chất lượng, tiến độ sẽ hoàn thành trong
                                    tháng
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    • <b>Y/cầu hỗ trợ:</b>
                                </td>
                                <td>
                                    Là yêu cầu của nhân sự cần sự hỗ trợ của các bộ phận khác để hoàn thành được đầu
                                    mục công việc (Phần này để chọn nhiều bộ phận: phần này em nhập dữ liệu tất cả các
                                    bộ phận trong Cty, nhân viên click vào nó sẽ hiện ra 1 cột dài các bộ phận, nhân
                                    viên có thể chọn 1 hoặc 2 hoặc 3 bộ phận trong phần yêu cầu hỗ trợ này.)
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    • <b>Kết quả Thực hiện :</b>
                                </td>
                                <td>
                                    Nêu rõ số liệu hoặc kết quả đã thực hiện được trong tháng
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    • <b>Tỷ lệ hoàn thành %:</b>
                                </td>
                                <td>
                                    Tỷ lệ hoàn thành so với Cam kết đã đưa ra trong kế hoạch
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    • <b>Ý kiến của Nhân Viên:</b>
                                </td>
                                <td>
                                    Nhân viên nêu ý kiến về lý do không hoàn thành được 100% kế hoạch hoặc các ý kiến
                                    đề xuất khác
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    • <b>Ý kiến của TBP:</b>
                                </td>
                                <td>
                                    Trưởng bộ phận cho ý kiến về lý do tăng – giảm điểm đánh giá đối với nhân sự
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="dgrKhoiLuongCV1" runat="server" AutoGenerateColumns="False" BorderColor="#999999"
                            BorderStyle="solid" BorderWidth="1px" CellPadding="2" CssClass="table table-striped table-hover table-bordered dataTable"
                            Width="100%" AllowPaging="true" AllowSorting="True" PageSize="20" OnRowCommand="dgrKhoiLuongCV1_RowCommand"
                            OnRowEditing="dgrKhoiLuongCV1_RowEditing" OnRowDeleting="dgrKhoiLuongCV1_RowDeleting"
                            OnRowDataBound="dgrKhoiLuongCV1_RowDataBound">
                            <AlternatingRowStyle CssClass="odd" />
                            <RowStyle CssClass="even" />
                            <HeaderStyle CssClass="sorting_disabled" ForeColor="Black" />
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="30px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="txtID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                        <asp:Label ID="lblIDCongViec" runat="server" Text='<%# Eval("IDCongViec") %>'></asp:Label>
                                        <asp:Label ID="lblIDBoPhan" runat="server" Text='<%# Eval("IDBoPhan") %>'></asp:Label>
                                        <asp:Label ID="lblIDBoPhanHoTro" runat="server" Text='<%# Eval("IDBoPhanHoTro") %>'></asp:Label>
                                        <asp:Label ID="lblIDPhongBan" runat="server" Text='<%# Eval("IDPhongBan") %>'></asp:Label>
                                        <asp:Label ID="txtIdCongViec" runat="server" Text='<%# Eval("IDCongViec") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tên công việc" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="200px">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTenCongViec" Rows="3" TextMode="MultiLine" Width="200px" runat="server"
                                            Text='<%# Eval("TenCongViec") %>' Style="text-align: left"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tỷ trọng (%)" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="70px">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTyTrongCV" Width="50px" runat="server" Text='<%# Eval("TyTrongCV") %>'
                                            Style="text-align: center"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cam kết" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtSoLieuCamKet" Rows="3" TextMode="MultiLine" Width="150px" runat="server"
                                            Text='<%# Eval("SoLieuCamKet") %>' Style="text-align: left"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bộ phận hỗ trợ" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="100px">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ListBox Height="70px" Width="98%" SelectionMode="Multiple" ID="dropBoPhanHoTro"
                                            runat="server" DataTextField="Ten" DataValueField="ID"></asp:ListBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Y/cầu hỗ trợ" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="100px">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtYeuCauHoTro" Rows="3" TextMode="MultiLine" Width="120px" runat="server"
                                            Text='<%# Eval("YeuCauHoTro") %>' Style="text-align: left"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false" HeaderText="Kết quả Thực hiện" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="100px">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtSoLieuThucHienThucTeTrongThang" Rows="3" TextMode="MultiLine"
                                            Width="130px" runat="server" Text='<%# Eval("SoLieuThucHienThucTeTrongThang") %>'
                                            Style="text-align: center"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false" HeaderText="Tỷ lệ hoàn thành %" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="70px">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtNhanVienDanhGiaTyLeHoanThanh" Width="50px" runat="server" Text='<%# Eval("NhanVienDanhGiaTyLeHoanThanh") %>'
                                            Style="text-align: center"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false" HeaderText="TBP đánh giá %" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="80px">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTBPDanhGia" Width="50px" runat="server" Text='<%# Eval("TBPDanhGia") %>'
                                            Style="text-align: center"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ý kiến của Nhân Viên" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="100px">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtYKienCuaNhanVien" Rows="3" TextMode="MultiLine" Width="150px"
                                            runat="server" Text='<%# Eval("YKienCuaNhanVien") %>' Style="text-align: center"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false" HeaderText="Ý kiến của TBP" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="100px">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtYKienCuaTBP" Rows="3" TextMode="MultiLine" Width="150px" runat="server"
                                            Text='<%# Eval("YKienCuaTBP") %>' Style="text-align: center"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
