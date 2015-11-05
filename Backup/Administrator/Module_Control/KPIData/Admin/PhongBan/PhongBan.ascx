<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhongBan.ascx.cs" Inherits="VmgPortal.Modules.KPIData.Admin.PhongBan.PhongBan" %>
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
                                    <strong>Trung tâm:</strong>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropTrungTam" DataTextField="Ten" DataValueField="ID" runat="server"
                                        CssClass="form-control" OnSelectedIndexChanged="dropTrungTam_SelectedIndexChanged"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 150px;">
                                    <strong>Tên phòng/nhóm cha:</strong>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropParent" CssClass="form-control" runat="server" DataTextField="Ten"
                                        DataValueField="ID">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 150px;">
                                    <strong>Tên phòng:</strong>
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
                                    <asp:TextBox ID="txtMoTa" runat="server" TextMode="MultiLine" Rows="2" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td>
                                    <strong>TTCV của phòng so với trung tâm:</strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTyTrong" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 150px;">
                                    <strong>Trưởng phòng:</strong>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropTruongPhongBan" DataTextField="Ten" DataValueField="ID"
                                        runat="server" CssClass="form-control">
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
                                    <table>
                                        <tr>
                                            <td>
                                                Trung tâm:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dropTrungTamSearch" CssClass="form-control" DataTextField="Ten"
                                                    DataValueField="ID" runat="server" Width="220px">
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
                                    <cc1:GridView ID="dgrPhongBan" runat="server" AutoGenerateColumns="False" BorderColor="Gainsboro"
                                        BorderStyle="solid" BorderWidth="1px" CellPadding="2" CssClass="table table-striped table-hover table-bordered dataTable"
                                        Width="100%" AllowPaging="true" AllowSorting="True" PageSize="10" OnRowCommand="dgrPhongBan_RowCommand"
                                        OnRowEditing="dgrPhongBan_RowEditing" OnRowDeleting="dgrPhongBan_RowDeleting"
                                        OnRowDataBound="dgrPhongBan_RowDataBound">
                                        <AlternatingRowStyle CssClass="odd" />
                                        <RowStyle CssClass="even" />
                                        <HeaderStyle CssClass="sorting_disabled"  ForeColor="Black" />
                                        <Columns>
                                            <asp:BoundField DataField="Ten" HeaderText="Tên" ItemStyle-Width="200px" />
                                            <asp:TemplateField HeaderText="Mô tả" HeaderStyle-Width="250px">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMoTa" runat="server" Text='<%# Eval("MoTa") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false" HeaderText="Tỷ trọng%" HeaderStyle-Width="100px">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTyTrong" runat="server" Text='<%# Eval("TyTrong") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Trưởng Phòng/Trưởng Nhóm" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="200px">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="dropTruongPhong" CssClass="form-control" DataTextField="Ten"
                                                        DataValueField="ID" runat="server" Width="200px">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Thao tác" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="250px">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-xs blue" CommandName="edit"
                                                        Text="Sửa" CommandArgument='<%# Eval("ID") + "_" + Eval("IDTrungTam") %>'></asp:Button>
                                                    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-xs dark" CommandName="delete"
                                                        Text="Xóa" CommandArgument='<%# Eval("ID") + "_" + Eval("IDTrungTam") %>'></asp:Button>
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
