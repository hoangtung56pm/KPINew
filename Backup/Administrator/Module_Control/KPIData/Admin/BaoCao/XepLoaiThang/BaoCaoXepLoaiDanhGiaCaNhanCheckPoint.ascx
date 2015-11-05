<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BaoCaoXepLoaiDanhGiaCaNhanCheckPoint.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.BaoCao.XepLoaiThang.BaoCaoXepLoaiDanhGiaCaNhanCheckPoint" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Import Namespace="VmgPortal.Library.Utilities" %>
<%@ Import Namespace="System" %>
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
                    <td>
                        <asp:Panel ID="pnSearch" runat="server" DefaultButton="btnSearch">
                            <table class="InputBox" cellpadding="5" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td>
                                        <strong>Đợt đánh giá:</strong>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control" ID="dropDotDanhGia" DataTextField="Ten"
                                            DataValueField="ID" runat="server" Width="300px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <strong>Trung tâm:</strong>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control" ID="dropTrungTam" runat="server" DataTextField="Ten"
                                            DataValueField="ID" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="dropTrungTam_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <strong>Phòng ban:</strong>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dropPhongBan" runat="server" DataTextField="Ten" DataValueField="ID"
                                            AutoPostBack="True" CssClass="form-control" Width="150px" OnSelectedIndexChanged="dropPhongBan_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <strong>Chức vụ:</strong>
                                    </td>
                                    <td>
                                        <asp:DropDownList AutoPostBack="True" CssClass="form-control" ID="dropChucVu" runat="server"
                                            Width="100px" OnSelectedIndexChanged="dropChucVu_SelectedIndexChanged">
                                            <asp:ListItem Text="Tất cả" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Nhân Viên" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Trưởng Phòng" Value="8"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <strong>Xếp loại:</strong>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control" ID="dropTrangThai" runat="server" Width="100px"
                                            AutoPostBack="True" OnSelectedIndexChanged="dropTrangThai_SelectedIndexChanged">
                                            <asp:ListItem Text="Tất cả" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="A+" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="A" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="B" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="C" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="D" Value="5"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="10" align="center">
                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn blue" Text="Tìm kiếm" OnClick="btnSearch_Click" />
                                        <asp:Button ID="btnExport" runat="server" CssClass="btn green" Text="Export form kết quả đánh giá nhân sự"
                                            OnClick="btnExport_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="10">
                                        <asp:HyperLink ID="hplDownload" runat="server"></asp:HyperLink>
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
                <tr style="display: none">
                    <td>
                        <b>Tổng số bản ghi là: </b>
                        <asp:Label ID="lblTotalTop" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr style="display: none">
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="dtgUsers" runat="server" AutoGenerateColumns="False" BorderColor="Gainsboro"
                            BorderStyle="solid" BorderWidth="1px" CellPadding="5" CssClass="table table-striped table-hover table-bordered dataTable"
                            Width="100%" AllowPaging="true" AllowSorting="True" OnSorting="dtgUsers_Sorting"
                            OnPreRender="dtgUsers_PreRender" OnPageIndexChanging="dtgUsers_PageIndexChanging"
                            PageSize="20">
                            <AlternatingRowStyle CssClass="odd" />
                            <RowStyle CssClass="even" />
                            <HeaderStyle CssClass="sorting_disabled" ForeColor="Black" />
                            <Columns>
                                <asp:TemplateField Visible="false" ItemStyle-Width="80px" HeaderText="Bộ phận" SortExpression="HoTen"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBoPhan" runat="server" Text='<%# Eval("Bộ phận") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="T&#234;n" SortExpression="HoTen"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                    <asp:HyperLink ID="hplName" runat="server">
                                            <asp:Label ID="lblHoTen" runat="server" Text='<%# Eval("Họ tên") %>'></asp:Label></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Điểm đánh giá công việc" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDiemDGCV" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Điểm kỷ luật và văn hóa doanh nghiệp"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDiemKL" runat="server" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Điểm đồng nghiệp đánh giá"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDiemDNDG" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Tổng điểm" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTongDiem" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false" ItemStyle-Width="150px" HeaderText="Xếp loại" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblXepLoai" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerTemplate>
                                <table id="tbPager" width="100%">
                                    <tr>
                                        <td>
                                            Page
                                            <asp:DropDownList ID="ddlNumberPages" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNumberPages_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            of
                                            <asp:Label ID="lbTotalPages" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPageItems" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageItems_SelectedIndexChanged">
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem Selected="True">10</asp:ListItem>
                                                <asp:ListItem>20</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:LinkButton ID="lbtnFirst" runat="server" CausesValidation="false" CommandName="Page"
                                                CommandArgument="First" Text="<<"></asp:LinkButton>&nbsp;
                                            <asp:LinkButton ID="lbtnPrev" runat="server" CausesValidation="false" CommandName="Page"
                                                CommandArgument="Prev" Text="Prev"></asp:LinkButton>&nbsp;
                                            <asp:LinkButton ID="lbtnNext" runat="server" CausesValidation="false" CommandName="Page"
                                                CommandArgument="Next" Text="Next"></asp:LinkButton>&nbsp;
                                            <asp:LinkButton ID="lbtnLast" runat="server" CausesValidation="false" CommandName="Page"
                                                CommandArgument="Last" Text=">>"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </PagerTemplate>
                            <EmptyDataTemplate>
                                There was no data to return
                            </EmptyDataTemplate>
                            <PagerSettings Mode="NumericFirstLast" />
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
