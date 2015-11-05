<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DotDanhGia.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.DotDanhGia.DotDanhGia" %>
<%@ Register Assembly="VmgPortal.Library" Namespace="VmgPortal.Library.Controls"
    TagPrefix="cc1" %>
<div class="row">
    <div class="col-md-12">
        <label class="control-label col-md-12">
            <asp:Label ID="lblStatusUpdate" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></label>
    </div>
</div>
<div class="row">
    <div class="col-md-4">
        <table border="0" cellpadding="2" cellspacing="2" width="100%">
            <tr>
                <td>
                    <strong>Tên:</strong>
                </td>
                <td>
                    <asp:TextBox ID="txtTen" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Thời gian bắt đầu:</strong>
                </td>
                <td>
                    <asp:TextBox ID="txtThoiGianBatDau" runat="server" CssClass="form-control form-control-inline input-small date-picker"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Thời gian kết thúc:</strong>
                </td>
                <td>
                    <asp:TextBox ID="txtThoiGianKetThuc" runat="server" CssClass="form-control form-control-inline input-small date-picker"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Loại đánh giá:</strong>
                </td>
                <td>
                    <asp:DropDownList ID="dropTypeOf" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Đánh giá tháng" Value="1"></asp:ListItem>
                        <%--  <asp:ListItem Text="Đánh giá 6 tháng và 1 năm" Value="0"></asp:ListItem>--%>
                        <asp:ListItem Text="Checkpoint" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Trạng thái:</strong>
                </td>
                <td>
                    <asp:DropDownList ID="dropStatus" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Đang đánh giá" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Tạm dừng" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    <strong>Đợt đánh giá chuẩn:</strong>
                </td>
                <td>
                    <asp:DropDownList ID="dropChuan" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Chuẩn" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Không" Value="0"></asp:ListItem>
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
                    <asp:Button ID="btnThemMoi" runat="server" CssClass="btn green" Text="Thêm mới" OnClick="btnThemMoi1_Click" />
                    <asp:Button ID="Button1" runat="server" Visible="false" CssClass="Button70" Text="test"
                        OnClick="btnThemMoi1_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div class="col-md-8">
        <cc1:GridView ID="dgrDotDanhGia" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-bordered dataTable"
            Width="100%" AllowPaging="true" AllowSorting="True" PageSize="10" OnRowCommand="dgrDotDanhGia_RowCommand"
            OnRowEditing="dgrDotDanhGia_RowEditing" OnRowDeleting="dgrDotDanhGia_RowDeleting"
            OnRowDataBound="dgrDotDanhGia_RowDataBound">
            <AlternatingRowStyle CssClass="odd" />
            <RowStyle CssClass="even" />
            <HeaderStyle CssClass="sorting_disabled" ForeColor="Black" />
            <Columns>
                <asp:BoundField DataField="Ten" HeaderText="Tên" ItemStyle-Width="200px" />
                <asp:TemplateField HeaderText="Thời gian bắt đầu" HeaderStyle-Width="70px">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblThoiGianBatDau" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Thời gian kết thúc" HeaderStyle-Width="70px">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblThoiGianKetThuc" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Trạng thái" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:DropDownList ID="dropStatus1" CssClass="form-control" runat="server">
                            <asp:ListItem Text="Đang đánh giá" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Tạm dừng" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="false" HeaderText="Chọn làm chuẩn" HeaderStyle-HorizontalAlign="Center"
                    HeaderStyle-Width="70px">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:DropDownList ID="dropChuan1" CssClass="form-control" runat="server">
                            <asp:ListItem Text="Chuẩn" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Không" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Thao tác" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-xs blue" CommandName="edit"
                            Text="Sửa" CommandArgument='<%# Eval("ID") %>'></asp:Button>
                        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-xs dark" CommandName="delete"
                            Text="Xóa" CommandArgument='<%# Eval("ID") %>'></asp:Button>
                        <asp:Button ID="btnDetail" runat="server" CssClass="btn btn-xs green" CommandName="detail"
                            Text="Nhân viên" CommandArgument='<%# Eval("ID") %>'></asp:Button>
                        <asp:Button ID="btnTBP" runat="server" CssClass="btn btn-xs black" CommandName="tbp"
                            Text="TBP" CommandArgument='<%# Eval("ID") %>'></asp:Button>
                        <asp:Button ID="btnNDG" Visible="false" runat="server" CssClass="btn btn-xs dark"
                            CommandName="ndgnhanvien" Text="NĐG" CommandArgument='<%# Eval("ID") %>'>
                        </asp:Button>
                        <asp:Button ID="btnNDGTP" runat="server" Visible="false" CssClass="btn btn-xs black"
                            CommandName="ndgtruongphong" Text="NDG Trưởng Phòng" CommandArgument='<%# Eval("ID") %>'>
                        </asp:Button>
                        <asp:Button ID="btnDanhGiaBoPhan" Visible="false" runat="server" CssClass="btn btn-xs black"
                            CommandName="bophan" Text="Bộ phận" CommandArgument='<%# Eval("ID") %>'></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </cc1:GridView>
    </div>
</div>
