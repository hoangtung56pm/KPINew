<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoPhan_DiemKyLuat5S.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.PhongBan.BoPhan_DiemKyLuat5S" %>
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
                            <table cellpadding="4" cellspacing="0">
                                <tr>
                                    <td>
                                        Chọn đợt đánh giá:
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control" AutoPostBack="true" Width="300px" ID="dropDotDanhGia"
                                            runat="server" DataTextField="Ten" DataValueField="ID">
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
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
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
                            BorderStyle="solid" BorderWidth="1px" CellPadding="5" CssClass="table table-striped table-hover table-bordered dataTable" Width="100%"
                            PageSize="20">
                            <AlternatingRowStyle CssClass="odd" />
                            <RowStyle CssClass="even" />
                            <HeaderStyle CssClass="sorting_disabled" ForeColor="Black" />
                            <Columns>
                                <asp:BoundField Visible="true" HeaderText="Stt"  ItemStyle-VerticalAlign="Middle">
                                    <HeaderStyle Width="25px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:TemplateField SortExpression="ID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblKey" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Ten" HeaderText="Tên đơn vị" SortExpression="Ten" ItemStyle-Width="150px" />
                                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Mặt cười xanh" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMatXanh" CssClass="form-control" Width="50px" runat="server" Text='<%# Eval("MatXanh") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Mặt cười mếu" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMatMeu" CssClass="form-control" Width="50px" runat="server" Text='<%# Eval("MatMeu") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Mặt cười nâu" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMatNau" CssClass="form-control" Width="50px" runat="server" Text='<%# Eval("MatNau") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Mặt cười khác" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOther" CssClass="form-control" Width="50px" runat="server" Text='<%# Eval("Other") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Tổng điểm trừ (gồm mặt nâu và mặt mếu)"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="txtTongDiemTru" Font-Bold="true" runat="server" Text='<%# Eval("TongDiemTru") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="300px" HeaderText="Ghi chú lỗi phạt" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtNote" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server" Text='<%# Eval("Note") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="300px" HeaderText="Thời điểm" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGhiChu" CssClass="form-control" TextMode="MultiLine" Rows="4" Font-Bold="true" runat="server"
                                            Text='<%# Eval("Note1") %>'></asp:TextBox>
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
