<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="XepLoaiNhom.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.XepLoaiNhom.XepLoaiNhom" %>
<%@ Register Assembly="VmgPortal.Library" Namespace="VmgPortal.Library.Controls"
    TagPrefix="cc1" %>
<table id="TABLE1" border="0" cellpadding="2" cellspacing="2" style="width: 100%">
    <tr>
        <td>
            <asp:Label ID="lblStatusUpdate" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
        </td>
    </tr>
    <tr>
        <td valign="top" class="InputBox" style="width: 25%;">
            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td style="width: 150px;">
                        <strong>Nhóm phân loại nhân viên:</strong>
                    </td>
                    <td>
                        <asp:DropDownList ID="dropNhom" Width="150px" runat="server" DataTextField="Ten"
                            DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Xếp loại:</strong>
                    </td>
                    <td>
                        <asp:DropDownList ID="dropXepLoai" Width="150px" runat="server" DataTextField="Ten"
                            DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Min:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMin" runat="server" Width="70px" CssClass="inputTextBox150"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Max:</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMax" runat="server" Width="70px" CssClass="inputTextBox150"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong></strong>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnUpdate" runat="server" CssClass="Button70" Text="Cập  nhật" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnThemMoi" runat="server" CssClass="Button70" Text="Thêm mới" OnClick="btnThemMoi_Click" />
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top" class="InputBox" style="width: 60%;">
            <table border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td>
                        <asp:GridView ID="dgrXepLoaiNhom" runat="server" AutoGenerateColumns="False" BorderColor="Gainsboro"
                            BorderStyle="solid" BorderWidth="1px" CellPadding="2" CssClass="Grid" Width="100%"
                            AllowPaging="true" AllowSorting="True" PageSize="20" OnRowCommand="dgrXepLoaiNhom_RowCommand"
                            OnRowEditing="dgrXepLoaiNhom_RowEditing" OnRowDeleting="dgrXepLoaiNhom_RowDeleting">
                            <AlternatingRowStyle CssClass="Grid_Raw2" />
                            <RowStyle CssClass="Grid_Raw1" />
                            <HeaderStyle CssClass="Grid_Top" Font-Bold="True" />
                            <Columns>
                                <asp:BoundField DataField="NhomNhanVien" HeaderText="Nhóm phân loại nhân viên" ItemStyle-HorizontalAlign="Center"
                                    ItemStyle-Width="200px" />
                                <asp:BoundField DataField="MoTa" HeaderText="Mô tả nhóm phân loại nhân viên" ItemStyle-Width="350px" />
                                <asp:BoundField DataField="XepLoai" HeaderText="Xếp loại" ItemStyle-Width="100px"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="Min" HeaderText="Min" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="Max" HeaderText="Max" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:TemplateField HeaderText="Thao tác" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="140px">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" CssClass="Button" CommandName="edit" Text="Sửa"
                                            CommandArgument='<%# Eval("ID") %>'></asp:Button>
                                        &nbsp;
                                        <asp:Button ID="btnDelete" runat="server" CssClass="Button" CommandName="delete"
                                            Text="Xóa" CommandArgument='<%# Eval("ID") %>'></asp:Button>
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
