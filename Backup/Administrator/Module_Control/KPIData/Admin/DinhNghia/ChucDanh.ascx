<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChucDanh.ascx.cs" Inherits="VmgPortal.Modules.KPIData.Admin.DinhNghia.ChucDanh" %>
<%@ Register Assembly="VmgPortal.Library" Namespace="VmgPortal.Library.Controls"
    TagPrefix="cc1" %>
<div class="row">
    <div class="col-md-4" style="padding-right: 0px;">
        <div class="portlet box grey">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-reorder"></i>Thêm mới
                </div>
                <div class="tools">
                    <a href="" class="collapse"></a>
                </div>
            </div>
            <div class="portlet-body form">
                <div class="form-horizontal" role="form">
                    <div class="form-body">
                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td style="width: 150px;">
                                    <strong>Tên:</strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTen" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Mô tả:</strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMoTa" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Mã:</strong>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropTypeOf" runat="server"  CssClass="form-control">
                                        <asp:ListItem Text="Chức Danh" Value="CHUCVU"></asp:ListItem>
                                    </asp:DropDownList>
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
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn blue" Text="Cập  nhật" OnClick="btnUpdate_Click" />
                                    <asp:Button ID="btnThemMoi" runat="server" CssClass="btn green" Text="Thêm mới" OnClick="btnThemMoi_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblStatusUpdate" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-8">
        <div class="portlet box blue ">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-reorder"></i>Danh sách
                </div>
                <div class="tools">
                    <a href="" class="collapse"></a>
                </div>
            </div>
            <div class="portlet-body form">
                <div class="form-horizontal" role="form">
                    <div class="form-body">
                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td>
                                    <cc1:GridView ID="dgrChucDanh" runat="server" AutoGenerateColumns="False" BorderColor="Gainsboro"
                                        BorderStyle="solid" BorderWidth="1px" CellPadding="2"  Width="100%"
                                        AllowPaging="true" AllowSorting="True" PageSize="10" OnRowCommand="dgrChucDanh_RowCommand"
                                        OnRowEditing="dgrChucDanh_RowEditing" OnRowDeleting="dgrChucDanh_RowDeleting"
                                        OnRowDataBound="dgrChucDanh_RowDataBound" CssClass="table table-striped table-hover table-bordered dataTable">
                                        <AlternatingRowStyle CssClass="odd" />
                                        <RowStyle CssClass="even" />
                                        <HeaderStyle CssClass="sorting_disabled"  ForeColor="Black"  />
                                        <Columns>
                                            <asp:BoundField DataField="Ten" HeaderText="Tên" ItemStyle-Width="250px" />
                                            <asp:TemplateField HeaderText="Mô tả" HeaderStyle-Width="200px">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMoTa" runat="server" Text='<%# Eval("MoTa") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Loại" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="dropTypeOf1" CssClass="form-control" runat="server" Width="130px">
                                                        <asp:ListItem Text="Chức Danh" Value="CHUCVU"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Thao tác" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-xs blue" CommandName="edit" Text="Sửa"
                                                        CommandArgument='<%# Eval("ID") %>'></asp:Button>
                                                    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-xs dark" CommandName="delete"
                                                        Text="Xóa" CommandArgument='<%# Eval("ID") %>'></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </cc1:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
