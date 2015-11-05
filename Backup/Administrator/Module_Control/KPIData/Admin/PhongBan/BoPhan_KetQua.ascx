<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoPhan_KetQua.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.PhongBan.BoPhan_KetQua" %>
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
                        <asp:Panel ID="pnSearch" runat="server">
                            <table cellpadding="4" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td width="150px">
                                        <strong>Chọn đợt đánh giá:</strong>
                                    </td>
                                    <td>
                                        <asp:DropDownList AutoPostBack="true" CssClass="form-control" Width="300px" ID="dropDotDanhGia"
                                            runat="server" DataTextField="Ten" DataValueField="ID">
                                        </asp:DropDownList>
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
                            BorderStyle="solid" BorderWidth="1px" CellPadding="10" CssClass="table table-striped table-hover table-bordered dataTable"
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
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Kết quả hoàn thành KHHD <br/>(75%)"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblKetquaHTKHHD" Text='<%# Eval("KetquaHTKHHD") + "%" %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Điểm phối hợp <br/>(10%)"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDiemPhoiHop" Text='<%# Eval("DiemPhoiHop") + "%" %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Điểm Sáng tạo <br/>(5%)" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDiemSangTao" Text='<%# Eval("DiemSangTao")+ "%" %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Điểm Kỷ luật <br/>(10%)" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDiemKyLuat" Text='<%# Eval("DiemKyLuat")+ "%" %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Mức độ hoàn thành" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMucDoHoanThanh" Font-Bold="true" Text='<%# Eval("MucDoHoanThanh")+ "%" %>'
                                            runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Xếp loại" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblXepLoai" Text='<%# Eval("XepLoai") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Xếp hạng" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblXepHang" Text='<%# Eval("Rank") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Ghi chú" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNote" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" class="table table-striped table-hover table-bordered dataTable">
                            <tr>
                                <td width="25px">
                                    13
                                </td>
                                <td align="left" width="150px">
                                    <b>Trung bình</b>
                                </td>
                                <td width="150px" align="center">
                                    <asp:Label Font-Bold="true" ForeColor="Blue" ID="lblTBKetQuaKHHD" runat="server"></asp:Label>
                                </td>
                                <td width="150px" align="center">
                                    <asp:Label Font-Bold="true" ForeColor="Blue" ID="tblTBDiemPhoiHop" runat="server"></asp:Label>
                                </td>
                                <td width="150px" align="center">
                                    <asp:Label Font-Bold="true" ForeColor="Blue" ID="lblTBDiemSangTao" runat="server"></asp:Label>
                                </td>
                                <td width="150px" align="center">
                                    <asp:Label Font-Bold="true" ForeColor="Blue" ID="lblTBKyLuat" runat="server"></asp:Label>
                                </td>
                                <td width="150px" align="center">
                                    <asp:Label Font-Bold="true" ForeColor="Blue" ID="lblTBMucDoHoanThanh" runat="server"></asp:Label>
                                </td>
                                <td width="150px" align="center">
                                </td>
                                <td width="150px" align="center">
                                </td>
                                <td width="150px" align="center">
                                </td>
                            </tr>
                        </table>
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
