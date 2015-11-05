<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoPhan_DangGiaSangTao.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.PhongBan.BoPhan_DangGiaSangTao" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Import Namespace="VmgPortal.Library.Utilities" %>
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
    <tr>
        <td height="10">
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblUpdateStatus" runat="server"></asp:Label>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td class="InputBox">
                        <asp:Panel ID="pnSearch" runat="server" DefaultButton="btnUpdate">
                            <table cellpadding="4" cellspacing="0" >
                                <tr>
                                    <td>
                                        Chọn đợt đánh giá:
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control" AutoPostBack="true" Width="300px" ID="dropDotDanhGia" runat="server"
                                            DataTextField="Ten" DataValueField="ID">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn green" Text="Cập nhật" OnClick="btnUpdate_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnExport" runat="server" CssClass="btn blue" Text="Export to excel"
                                            OnClick="btnExport_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr style="display:none">
                    <td height="10">
                    </td>
                </tr>
                <tr style="display:none">
                    <td>
                        <b>Tổng số bản ghi là: </b>
                        <asp:Label ID="lblTotalTop" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="dgrBoPhan" runat="server" AutoGenerateColumns="False" BorderColor="Gainsboro"
                            BorderStyle="solid" BorderWidth="1px" CellPadding="5" CssClass="table table-striped table-hover table-bordered dataTable"
                            Width="100%" PageSize="20">
                            <AlternatingRowStyle CssClass="odd" />
                            <RowStyle CssClass="even" />
                            <HeaderStyle CssClass="sorting_disabled" ForeColor="Black" />
                            <Columns>
                                <asp:BoundField Visible="true" HeaderText="Stt">
                                    <HeaderStyle Width="25px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:TemplateField SortExpression="ID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblKey" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Ten" HeaderText="Tên đơn vị" SortExpression="Ten" ItemStyle-Width="150px" />
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Điểm khởi đầu (cộng và trừ theo các tiêu chí chấm điểm)"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDiemKhoiDau" runat="server" Text="100%"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Không có ý tưởng gửi" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblKhongCoYTuong" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Số ý tưởng" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSoYTuong" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Ý tưởng được áp dụng" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblYTuongApDung" Text='<%# Eval("YTuongApDung") + "%" %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Ý tưởng đoạt giải" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtYTuongDoatGiai" CssClass="form-control" runat="server" Text='<%# Eval("YTuongDoatGiai") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Không phối hợp, không thúc đẩy nhân viên tham gia"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtKhongPhoiHop" CssClass="form-control" runat="server" Text='<%# Eval("KhongPhoiHop") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Phối hợp nhiệt tình, thúc đẩy nhân viên tham gia"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPhoiHopNhietTinh" CssClass="form-control" runat="server" Text='<%# Eval("PhoiHopNhietTinh") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Phối hợp nhiệt tình, có tổ chức các hoạt động thúc đẩy nhân viên tham gia và tích cực áp dụng ý tưởng"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtThucDayNhanVien" CssClass="form-control" runat="server" Text='<%# Eval("ThucDayNhanVien") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Điểm sáng tạo trong tháng"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDiemSangTaoThang" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Tổng số bản ghi là: </b>
                        <asp:Label ID="lblTotalBottom" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
