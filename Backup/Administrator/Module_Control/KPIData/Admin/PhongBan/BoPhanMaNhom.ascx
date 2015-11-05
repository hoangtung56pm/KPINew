<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoPhanMaNhom.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.PhongBan.BoPhanMaNhom" %>
<%@ Register Assembly="VmgPortal.Library" Namespace="VmgPortal.Library.Controls"
    TagPrefix="cc1" %>
<%@ Import Namespace="VmgPortal.Library.Utilities" %>
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
                                    <strong>Trung tâm:</strong>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropTrungTam" DataTextField="Ten" DataValueField="ID" runat="server"
                                        CssClass="form-control">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 150px;">
                                    <strong>Tên nhóm việc:</strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTen" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Viết tắt:</strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMa" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Mổ tả:</strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMoTa" Rows="2" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
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
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn blue" Text="Cập nhật" OnClick="btnUpdate_Click" />
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
                        <table border="0" cellpadding="2" cellspacing="2">
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                Trung tâm:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dropTrungTamSearch" DataTextField="Ten" DataValueField="ID"
                                                    runat="server" CssClass="form-control" Width="220px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSearch" runat="server" Text="Tìm" CssClass="btn blue" OnClick="btnSearch_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <cc1:GridView ID="dgrNhom" runat="server" AutoGenerateColumns="False" BorderColor="Gainsboro"
                                        BorderStyle="solid" BorderWidth="1px" CellPadding="2" CssClass="table table-striped table-hover table-bordered dataTable" Width="100%"
                                        AllowPaging="true" AllowSorting="True" PageSize="10" OnRowCommand="dgrNhom_RowCommand"
                                        OnRowEditing="dgrNhom_RowEditing" OnRowDeleting="dgrNhom_RowDeleting" OnRowDataBound="dgrNhom_RowDataBound">
                                        <AlternatingRowStyle CssClass="odd" />
                                        <RowStyle CssClass="even" />
                                        <HeaderStyle  CssClass="sorting_disabled"  ForeColor="Black" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="STT" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tên nhóm việc" HeaderStyle-Width="150px">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTen" runat="server" Text='<%# Eval("TenNhomViec") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tên nhóm việc viết tắt" HeaderStyle-Width="150px">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTenShort" runat="server" Text='<%# Eval("Ma") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mô tả" HeaderStyle-Width="350px">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMoTa" runat="server" Text='<%# ConvertUtility.ToString(Eval("MoTa")).Replace("-","<br/> -") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Thao tác" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-xs blue" CommandName="edit" Text="Sửa"
                                                        CommandArgument='<%# Eval("ID") + "_" + Eval("IDBoPhan") %>'></asp:Button>
                                                    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-xs dark" CommandName="delete"
                                                        Text="Xóa" CommandArgument='<%# Eval("ID") + "_" + Eval("IDBoPhan") %>'></asp:Button>
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
