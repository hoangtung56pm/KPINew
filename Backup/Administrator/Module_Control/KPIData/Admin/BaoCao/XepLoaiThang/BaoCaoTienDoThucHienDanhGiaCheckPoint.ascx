<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BaoCaoTienDoThucHienDanhGiaCheckPoint.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.BaoCao.XepLoaiThang.BaoCaoTienDoThucHienDanhGiaCheckPoint" %>
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
            <asp:UpdatePanel ID="upanelGridUserManagemt" runat="server" UpdateMode="Conditional"
                RenderMode="Inline">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <asp:Label ID="lblUpdateStatus" runat="server"></asp:Label>
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td class="InputBox">
                                <asp:Panel ID="pnSearch" runat="server" DefaultButton="btnSearch">
                                    <table cellpadding="5" cellspacing="0" style="width: 100%">
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
                                                <strong>Trạng thái:</strong>
                                            </td>
                                            <td>
                                                <asp:DropDownList AutoPostBack="True" CssClass="form-control" ID="dropTrangThai"
                                                    runat="server" Width="100px" OnSelectedIndexChanged="dropTrangThai_SelectedIndexChanged">
                                                    <asp:ListItem Text="Tất cả" Value="-1"></asp:ListItem>
                                                  <%--  <asp:ListItem Text="Lập kế hoạch" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Đã gửi kế hoạch đến trưởng phòng" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Đã gửi kế hoạch đến trưởng bộ phận" Value="2"></asp:ListItem>--%>
                                                    <asp:ListItem Text="Đang đánh giá" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Đã gửi phụ trách đánh giá" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="Nhân viên review đánh giá" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="TBP/TP gửi lại kết quả đánh giá" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="Nhân viên đồng ý với kết quả đánh giá" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="Hoàn thành đánh giá" Value="9"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="10" align="center">
                                                <asp:Button ID="btnSearch" runat="server" CssClass="btn blue" Text="Tìm kiếm" OnClick="btnSearch_Click" />
                                                <asp:Button ID="btnMail" runat="server" CssClass="btn green" Text="Gửi mail nhắc nhở nhân viên"
                                                    OnClick="btnMail_Click" />
                                                <asp:Button ID="btnMailTBP" runat="server" CssClass="btn blue" Text="Gửi mail nhắc nhở TBP/TP"
                                                    OnClick="btnMailTBP_Click" />
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
                        <tr style="display:none">
                            <td>
                                <b>Tổng số bản ghi là: </b>
                                <asp:Label ID="lblTotalTop" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                         <tr style="display:none">
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
                                        <asp:TemplateField SortExpression="User_ID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblKey" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                                <asp:Label ID="lblMail" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                                                <asp:Label ID="lblTrangThaiDG" runat="server" Text='<%# Eval("TrangThai") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="HoTen" HeaderText="T&#234;n" SortExpression="HoTen" ItemStyle-Width="150px" />
                                        <asp:BoundField DataField="MaSo"  HeaderText="Mã Số" SortExpression="MaSo" ItemStyle-Width="70px"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Username" HeaderText="T&#234;n truy cập" SortExpression="Username"
                                            ItemStyle-Width="150px" />
                                       <%-- <asp:BoundField DataField="TenPhong" HeaderText="Phòng" SortExpression="Username"
                                            ItemStyle-Width="120px" />--%>
                                        <asp:TemplateField  ItemStyle-Width="100px" HeaderText="Ngày Sinh" SortExpression="NgaySinh"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNgaySinh" runat="server" Text='<%# ConvertUtility.ToDateTime(Eval("NgaySinh")).ToString("dd/MM/yyyy") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ChucVu" HeaderText="Chức Vụ" SortExpression="ChucVu" ItemStyle-Width="280px" />
                                        <asp:TemplateField ItemStyle-Width="100px" SortExpression="TrangThai" HeaderText="Trạng thái"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTrangThai" runat="server"></asp:Label>
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
