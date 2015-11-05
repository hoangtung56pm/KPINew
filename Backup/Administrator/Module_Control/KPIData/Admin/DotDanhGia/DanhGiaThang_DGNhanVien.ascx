<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhGiaThang_DGNhanVien.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.DotDanhGia.DanhGiaThang_DGNhanVien" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Import Namespace="VmgPortal.Library.Utilities" %>
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
    <tr>
        <td style="height: 15px">
        </td>
    </tr>
    <tr>
        <td>
            <asp:UpdatePanel ID="upanelGridUserManagemt" runat="server" UpdateMode="Conditional"
                RenderMode="Inline">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnUpdateStatus" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnSendBack" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <asp:Label ID="lblUpdateStatus" runat="server"></asp:Label>
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td class="InputBox">
                                <asp:Panel ID="pnSearch" runat="server" DefaultButton="btnSearch">
                                    <table cellpadding="2">
                                        <tr>
                                            <td align="left">
                                                <strong>Đợt đánh giá</strong>
                                            </td>
                                            <td>
                                                <asp:DropDownList AutoPostBack="true" CssClass="form-control"  ID="dropDotDanhGia"
                                                    runat="server" DataTextField="Ten" DataValueField="ID" OnSelectedIndexChanged="dropDotDanhGia_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <strong>Chức vụ</strong>
                                            </td>
                                            <td>
                                                <asp:DropDownList CssClass="form-control" ID="dropChucVu" runat="server" Width="120px">
                                                    <asp:ListItem Text="Nhân Viên" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="Trưởng Phòng" Value="8"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <strong>Từ khóa:</strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtKeyword" CssClass="form-control" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <strong>Theo</strong>
                                            </td>
                                            <td>
                                                <asp:DropDownList CssClass="form-control" ID="dropSearchBy" runat="server" Width="100px">
                                                    <asp:ListItem Text="Tất cả" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="Tên Đăng nhập" Value="Username"></asp:ListItem>
                                                    <asp:ListItem Text="Họ tên" Value="HoTen"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSearch" runat="server" CssClass="btn blue" Text="Tìm kiếm" OnClick="btnSearch_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnUpdateStatus" runat="server" CssClass="btn green" ToolTip="Dùng cho trường hợp trưởng bộ phận chờ nhân viên đồng ý nhưng chưa làm"
                                                    Text="Thống nhất kết quả" OnClick="btnUpdateStatus_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSendBack" CssClass="btn dark" Text="Yêu cầu đánh giá lại" runat="server"
                                                    OnClick="btnSendBack_Click" />
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
                                <asp:GridView ID="dtgUsers" runat="server" AutoGenerateColumns="False" BorderColor="Gainsboro"
                                    BorderStyle="solid" BorderWidth="1px" CellPadding="5" CssClass="table table-striped table-hover table-bordered dataTable"
                                    OnRowCommand="dtgUsers_RowCommand" Width="100%" AllowPaging="true" AllowSorting="True"
                                    OnSorting="dtgUsers_Sorting" OnPreRender="dtgUsers_PreRender" OnPageIndexChanging="dtgUsers_PageIndexChanging"
                                    PageSize="50">
                                    <AlternatingRowStyle CssClass="odd" />
                                    <RowStyle CssClass="even" />
                                    <HeaderStyle CssClass="sorting_disabled" ForeColor="Black" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center">
                                            <%-- <HeaderTemplate>
                                                <asp:CheckBox runat="server" ID="chkAll" onclick="Check(this,'dtgUsers');highlightChkBxRow(this);" />
                                            </HeaderTemplate>--%>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="DeleteThis" onclick="highlightChkBxRow(this);" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="User_ID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblKey" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                                <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                                <asp:Label ID="lblIDPhong" runat="server" Text='<%# Eval("IDPhong") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="HoTen" HeaderText="T&#234;n" SortExpression="HoTen" ItemStyle-Width="200px" />
                                        <asp:BoundField Visible="false" DataField="MaSo" HeaderText="Mã Số" SortExpression="MaSo"
                                            ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Username" HeaderText="T&#234;n truy cập" SortExpression="Username"
                                            ItemStyle-Width="200px" />
                                        <asp:TemplateField Visible="false" ItemStyle-Width="100px" HeaderText="Ngày Sinh"
                                            SortExpression="NgaySinh" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNgaySinh" runat="server" Text='<%# ConvertUtility.ToDateTime(Eval("NgaySinh")).ToString("dd/MM/yyyy") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ChucVu" HeaderText="Chức Vụ" SortExpression="ChucVu" ItemStyle-Width="200px" />
                                        <asp:BoundField DataField="RoleDescription" HeaderText="Nhóm quyền" SortExpression="RoleDescription"
                                            ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField ItemStyle-Width="150px" HeaderText="Trạng thái" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTrangThai" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="Thời gian gửi đánh giá" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTime1" runat="server" Text='<%# ConvertUtility.ToDateTimeNew(Eval("ThoiGianGuiDG")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="Thời gian phụ trách gửi lại"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTime3" runat="server" Text='<%# ConvertUtility.ToDateTimeNew(Eval("ThoiGianGuiLaiDG")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="Thời gian NV đồng ý" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTime2" runat="server" Text='<%# ConvertUtility.ToDateTimeNew(Eval("ThoiGianDongY")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Thao t&#225;c" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Button ID="btnDanhGia" runat="server" CssClass="btn green" CommandName="danhgianhanvien"
                                                    Text="Đánh giá"></asp:Button>
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
