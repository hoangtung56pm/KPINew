<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WelCome.ascx.cs" Inherits="VmgPortal.Administrator.UserControls.WelCome" %>
<%@ Import Namespace="VmgPortal.Library.Utilities" %>
<%--<table width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td height="10px">
        </td>
    </tr>
    <tr>
        <td colspan="7" class="InputBox">
            <table width="100%" cellpadding="5">
                <tr>
                    <td>
                        Chọn đợt đánh giá:
                        <asp:DropDownList AutoPostBack="true" Width="300px" ID="dropDotDanhGia" runat="server"
                            DataTextField="Ten" DataValueField="ID" OnSelectedIndexChanged="dropDotDanhGia_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td height="10px">
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="pnlTBP_TP" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="50%" colspan="2" class="InputBox" valign="top">
                            <table width="100%" cellpadding="5" cellspacing="0">
                                <tr>
                                    <td valign="top" align="center" style="background-color: #D0D5D9">
                                        <b style="color: Black">Công việc trong tuần</b>
                                        <asp:DropDownList ID="dropTuan" AutoPostBack="true" runat="server">
                                            <asp:ListItem Text="Tuần 1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Tuần 2" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Tuần 3" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Tuần 4" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Tuần 5" Value="5"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Tổng số công việc: </b>
                                        <asp:Label ID="lblTotalCVTT" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="overflow: scroll; height: 300px">
                                            <asp:GridView ID="dgrCVTT" runat="server" AutoGenerateColumns="False" BorderColor="Gainsboro"
                                                BorderStyle="solid" BorderWidth="1px" CellPadding="5" CssClass="Grid" AllowPaging="true"
                                                AllowSorting="True" PageSize="200" Width="100%">
                                                <AlternatingRowStyle CssClass="Grid_Raw2" />
                                                <RowStyle CssClass="Grid_Raw1" />
                                                <HeaderStyle CssClass="Grid_Top" Font-Bold="True" />
                                                <Columns>
                                                    <asp:BoundField Visible="true" ItemStyle-HorizontalAlign="Center" HeaderText="STT">
                                                        <HeaderStyle Width="5%"></HeaderStyle>
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Nhóm CV" HeaderStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTenCVCha" runat="server" Text='<%# Eval("TenCVCha") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Tên công việc" HeaderStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTenCongViec" runat="server" Text='<%# Eval("Ten") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Người thực hiện" HeaderStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNguoiThucHien" runat="server" Text='<%# Eval("NguoiThucHien") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Deadline" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDeadline" runat="server" Text='<%# ConvertUtility.ToDateTime(Eval("NgayKetThuc")).ToString("dd/MM/yyyy") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="50%" colspan="2" class="InputBox" valign="top">
                            <table width="100%" cellpadding="5" cellspacing="0">
                                <tr>
                                    <td valign="top" align="center" style="background-color: #D0D5D9">
                                        <b style="color: Black">Tỷ trong công việc của nhân viên</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Tổng số nhân viên: </b>
                                        <asp:Label ID="lblTongSoNhanVien" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="overflow: scroll; height: 300px">
                                            <asp:GridView ID="dgrTyTrongNhanVien" runat="server" AutoGenerateColumns="False"
                                                BorderColor="Gainsboro" BorderStyle="solid" BorderWidth="1px" CellPadding="5"
                                                CssClass="Grid" Width="100%" AllowPaging="true" AllowSorting="True" PageSize="200">
                                                <AlternatingRowStyle CssClass="Grid_Raw2" />
                                                <RowStyle CssClass="Grid_Raw1" />
                                                <HeaderStyle CssClass="Grid_Top" Font-Bold="True" />
                                                <Columns>
                                                    <asp:BoundField Visible="true" ItemStyle-HorizontalAlign="Center" HeaderText="STT">
                                                        <HeaderStyle Width="25px"></HeaderStyle>
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Tên" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="left" Width="150px" />
                                                        <FooterStyle Font-Bold="true" HorizontalAlign="left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHoTen" runat="server" Text='<%# Eval("HoTen") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="TT công việc thường xuyên" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                        <FooterStyle Font-Bold="true" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTGCVThuongXuyen" runat="server" Text='<%# Eval("TTCVThuongXuyen") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="TT công việc kế hoạch tháng" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                        <FooterStyle Font-Bold="true" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTGCVKeHoachThang" runat="server" Text='<%# Eval("TTCVKeHoachThang") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="TT công việc phát sinh" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                        <FooterStyle Font-Bold="true" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTGCVPhatSinh" runat="server" Text='<%# Eval("TTCVPhatSinh") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="TT còn lại" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                        <FooterStyle Font-Bold="true" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTGConLai" runat="server" Text='<%# Eval("TTConLai") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Tổng" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                        <FooterStyle Font-Bold="true" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTong" runat="server" Text='<%# Eval("Tong") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px" colspan="7" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" colspan="2" class="InputBox" valign="top">
                            <table width="100%" cellpadding="5" cellspacing="0">
                                <tr>
                                    <td valign="top" align="center" style="background-color: #D0D5D9">
                                        <b style="color: Black">Công việc quá hạn deadline</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Tổng số công việc: </b>
                                        <asp:Label ID="lblTotalCVQHHT" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="overflow: scroll; height: 300px">
                                            <asp:GridView ID="dgrCVQHHT" runat="server" AutoGenerateColumns="False" BorderColor="Gainsboro"
                                                BorderStyle="solid" BorderWidth="1px" CellPadding="5" CssClass="Grid" Width="100%"
                                                AllowPaging="true" AllowSorting="True" PageSize="200">
                                                <AlternatingRowStyle CssClass="Grid_Raw2" />
                                                <RowStyle CssClass="Grid_Raw1" />
                                                <HeaderStyle CssClass="Grid_Top" Font-Bold="True" />
                                                <Columns>
                                                    <asp:BoundField Visible="true" ItemStyle-HorizontalAlign="Center" HeaderText="STT">
                                                        <HeaderStyle Width="5%"></HeaderStyle>
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Nhóm CV" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTenCVCha" runat="server" Text='<%# Eval("TenCVCha") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Tên công việc" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTenCongViec" runat="server" Text='<%# Eval("Ten") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Người thực hiện" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNguoiThucHien" runat="server" Text='<%# Eval("NguoiThucHien") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Deadline" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDeadline" runat="server" Text='<%# ConvertUtility.ToDateTime(Eval("NgayKetThuc")).ToString("dd/MM/yyyy") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Quá hạn" HeaderStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQH" runat="server" Text='<%# Eval("SoNgayQuaHan") %>'></asp:Label>
                                                            (ngày)
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="50%" colspan="2" class="InputBox" valign="top">
                            <table width="100%" cellpadding="5" cellspacing="0">
                                <tr>
                                    <td valign="top" align="center" style="background-color: #D0D5D9">
                                        <b style="color: Black">Công việc đến hạn hoàn thành</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnExport1" Visible="false" runat="server" CssClass="Button" Text="Xuất ra excel">
                                        </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Tổng số công việc: </b>
                                        <asp:Label ID="lblTotalCVDHHT" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="overflow: scroll; height: 300px">
                                            <asp:GridView ID="dgrCVDHHT" runat="server" AutoGenerateColumns="False" BorderColor="Gainsboro"
                                                BorderStyle="solid" BorderWidth="1px" CellPadding="5" CssClass="Grid" Width="100%"
                                                AllowPaging="true" AllowSorting="True" PageSize="200">
                                                <AlternatingRowStyle CssClass="Grid_Raw2" />
                                                <RowStyle CssClass="Grid_Raw1" />
                                                <HeaderStyle CssClass="Grid_Top" Font-Bold="True" />
                                                <Columns>
                                                    <asp:BoundField Visible="true" ItemStyle-HorizontalAlign="Center" HeaderText="STT">
                                                        <HeaderStyle Width="5%"></HeaderStyle>
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Nhóm CV" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTenCVCha" runat="server" Text='<%# Eval("TenCVCha") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Tên công việc" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTenCongViec" runat="server" Text='<%# Eval("Ten") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Người thực hiện" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNguoiThucHien" runat="server" Text='<%# Eval("NguoiThucHien") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Deadline" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDeadline" runat="server" Text='<%# ConvertUtility.ToDateTime(Eval("NgayKetThuc")).ToString("dd/MM/yyyy") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cách deadline" HeaderStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQH" runat="server" Text='<%# Eval("SoNgayConLai") %>'></asp:Label>
                                                            (ngày)
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px" colspan="7" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" class="InputBox" valign="top">
                            <table width="100%" cellpadding="5" cellspacing="0">
                                <tr>
                                    <td valign="top" align="center" style="background-color: #D0D5D9">
                                        <b style="color: Red">Nhân viên chưa gửi kế hoạch</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnChuaGuiKeHoach" runat="server" CssClass="Button" Text="Gửi mail nhắc nhở"
                                            OnClick="btnChuaGuiKeHoach_Click"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Tổng số nhân viên là: </b>
                                        <asp:Label ID="lblTotalTopChuaGuiKeHoach" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="overflow: scroll; height: 300px">
                                            <asp:GridView ID="dgrChuaGuiKeHoach" runat="server" AutoGenerateColumns="False" BorderColor="Gainsboro"
                                                BorderStyle="solid" BorderWidth="1px" CellPadding="5" CssClass="Grid" OnRowCommand="dgrChuaGuiKeHoach_RowCommand"
                                                Width="100%" AllowPaging="true" AllowSorting="True" OnSorting="dgrChuaGuiKeHoach_Sorting"
                                                OnPreRender="dgrChuaGuiKeHoach_PreRender" OnPageIndexChanging="dgrChuaGuiKeHoach_PageIndexChanging"
                                                PageSize="200">
                                                <AlternatingRowStyle CssClass="Grid_Raw2" />
                                                <RowStyle CssClass="Grid_Raw1" />
                                                <HeaderStyle CssClass="Grid_Top" Font-Bold="True" />
                                                <Columns>
                                                    <asp:TemplateField SortExpression="User_ID" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKey" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                                            <asp:Label ID="lblMail" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="HoTen" HeaderText="T&#234;n" SortExpression="HoTen" ItemStyle-Width="200px" />
                                                    <asp:TemplateField HeaderText="Thao t&#225;c" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnGuiMailNhacNho" runat="server" CommandArgument='<%# Eval("Username") %>'
                                                                CssClass="Button" CommandName="mail" Text="Gửi mail"></asp:Button>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerTemplate>
                                                    <table id="tbPager" width="100%">
                                                        <tr>
                                                            <td>
                                                                Page
                                                                <asp:DropDownList ID="ddlNumberPagesChuaGuiKeHoach" Width="40px" runat="server" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlNumberPagesChuaGuiKeHoach_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                of
                                                                <asp:Label ID="lbTotalPagesChuaGuiKeHoach" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPageItemsChuaGuiKeHoach" Width="40px" runat="server" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlPageItemsChuaGuiKeHoach_SelectedIndexChanged">
                                                                    <asp:ListItem>5</asp:ListItem>
                                                                    <asp:ListItem Selected="True">10</asp:ListItem>
                                                                    <asp:ListItem>20</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right">
                                                                <asp:LinkButton ID="lbtnFirstChuaGuiKeHoach" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="First" Text="<<"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnPrevChuaGuiKeHoach" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Prev" Text="Prev"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnNextChuaGuiKeHoach" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Next" Text="Next"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnLastChuaGuiKeHoach" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Last" Text=">>"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </PagerTemplate>
                                                <EmptyDataTemplate>
                                                    There was no data to return
                                                </EmptyDataTemplate>
                                                <PagerSettings Mode="NumericFirstLast" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td height="5px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="25%" class="InputBox" valign="top">
                            <table width="100%" cellpadding="5" cellspacing="0">
                                <tr>
                                    <td valign="top" align="center" style="background-color: #D0D5D9">
                                        <b style="color: Red">Nhân viên đã gửi kế hoạch</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Tổng số nhân viên là: </b>
                                        <asp:Label ID="lblTotalTopDaGuiKeHoach" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="overflow: scroll; height: 300px">
                                            <asp:GridView ID="dgrDaGuiKeHoach" runat="server" AutoGenerateColumns="False" BorderColor="Gainsboro"
                                                BorderStyle="solid" BorderWidth="1px" CellPadding="5" CssClass="Grid" OnRowCommand="dgrDaGuiKeHoach_RowCommand"
                                                Width="100%" AllowPaging="true" AllowSorting="True" OnSorting="dgrDaGuiKeHoach_Sorting"
                                                OnPreRender="dgrDaGuiKeHoach_PreRender" OnPageIndexChanging="dgrDaGuiKeHoach_PageIndexChanging"
                                                PageSize="200">
                                                <AlternatingRowStyle CssClass="Grid_Raw2" />
                                                <RowStyle CssClass="Grid_Raw1" />
                                                <HeaderStyle CssClass="Grid_Top" Font-Bold="True" />
                                                <Columns>
                                                    <asp:TemplateField SortExpression="User_ID" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKey" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                                            <asp:Label ID="lblMail" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="HoTen" HeaderText="T&#234;n" SortExpression="HoTen" ItemStyle-Width="200px" />
                                                    <asp:TemplateField HeaderText="Thao t&#225;c" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnXem" Width="70px" CommandArgument='<%# Eval("UserID") %>' runat="server"
                                                                CssClass="Button" CommandName="xem" Text="Xem"></asp:Button>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerTemplate>
                                                    <table id="tbPager" width="100%">
                                                        <tr>
                                                            <td>
                                                                Page
                                                                <asp:DropDownList ID="ddlNumberPagesDaGuiKeHoach" Width="40px" runat="server" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlNumberPagesDaGuiKeHoach_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                of
                                                                <asp:Label ID="lbTotalPagesDaGuiKeHoach" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPageItemsDaGuiKeHoach" Width="40px" runat="server" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlPageItemsDaGuiKeHoach_SelectedIndexChanged">
                                                                    <asp:ListItem>5</asp:ListItem>
                                                                    <asp:ListItem Selected="True">10</asp:ListItem>
                                                                    <asp:ListItem>20</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right">
                                                                <asp:LinkButton ID="lbtnFirstDaGuiKeHoach" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="First" Text="<<"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnPrevDaGuiKeHoach" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Prev" Text="Prev"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnNextDaGuiKeHoach" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Next" Text="Next"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnLastDaGuiKeHoach" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Last" Text=">>"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </PagerTemplate>
                                                <EmptyDataTemplate>
                                                    There was no data to return
                                                </EmptyDataTemplate>
                                                <PagerSettings Mode="NumericFirstLast" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                              
                                <tr>
                                    <td height="5px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="25%" class="InputBox" valign="top">
                            <table width="100%" cellpadding="5" cellspacing="0">
                                <tr>
                                    <td valign="top" align="center" style="background-color: #D0D5D9">
                                        <b style="color: Red">Nhân viên chưa gửi đánh giá tháng</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnChuaGuiDanhGia" runat="server" CssClass="Button" Text="Gửi mail nhắc nhở"
                                            OnClick="btnChuaGuiDanhGia_Click"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Tổng số bản ghi là: </b>
                                        <asp:Label ID="lblTotalTopChuaGuiDanhGia" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="overflow: scroll; height: 300px">
                                            <asp:GridView ID="dgrChuaGuiDanhGia" runat="server" AutoGenerateColumns="False" BorderColor="Gainsboro"
                                                BorderStyle="solid" BorderWidth="1px" CellPadding="5" CssClass="Grid" OnRowCommand="dgrChuaGuiDanhGia_RowCommand"
                                                Width="100%" AllowPaging="true" AllowSorting="True" OnSorting="dgrChuaGuiDanhGia_Sorting"
                                                OnPreRender="dgrChuaGuiDanhGia_PreRender" OnPageIndexChanging="dgrChuaGuiDanhGia_PageIndexChanging"
                                                PageSize="200">
                                                <AlternatingRowStyle CssClass="Grid_Raw2" />
                                                <RowStyle CssClass="Grid_Raw1" />
                                                <HeaderStyle CssClass="Grid_Top" Font-Bold="True" />
                                                <Columns>
                                                    <asp:TemplateField SortExpression="User_ID" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKey" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                                            <asp:Label ID="lblMail" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="HoTen" HeaderText="T&#234;n" SortExpression="HoTen" ItemStyle-Width="200px" />
                                                    <asp:TemplateField HeaderText="Thao t&#225;c" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnGuiMailNhacNho" Width="70px" CommandArgument='<%# Eval("Username") %>'
                                                                runat="server" CssClass="Button" CommandName="mail" Text="Gửi mail"></asp:Button>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerTemplate>
                                                    <table id="tbPager" width="100%">
                                                        <tr>
                                                            <td>
                                                                Page
                                                                <asp:DropDownList ID="ddlNumberPagesChuaGuiDanhGia" Width="40px" runat="server" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlNumberPagesChuaGuiDanhGia_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                of
                                                                <asp:Label ID="lbTotalPagesChuaGuiDanhGia" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPageItemsChuaGuiDanhGia" Width="40px" runat="server" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlPageItemsChuaGuiDanhGia_SelectedIndexChanged">
                                                                    <asp:ListItem>5</asp:ListItem>
                                                                    <asp:ListItem Selected="True">10</asp:ListItem>
                                                                    <asp:ListItem>20</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right">
                                                                <asp:LinkButton ID="lbtnFirstChuaGuiDanhGia" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="First" Text="<<"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnPrevChuaGuiDanhGia" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Prev" Text="Prev"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnNextChuaGuiDanhGia" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Next" Text="Next"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnLastChuaGuiDanhGia" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Last" Text=">>"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </PagerTemplate>
                                                <EmptyDataTemplate>
                                                    There was no data to return
                                                </EmptyDataTemplate>
                                                <PagerSettings Mode="NumericFirstLast" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                              
                            </table>
                        </td>
                        <td width="25%" class="InputBox" valign="top">
                            <table width="100%" cellpadding="5" cellspacing="0">
                                <tr>
                                    <td valign="top" align="center" style="background-color: #D0D5D9">
                                        <b style="color: Red">Nhân viên đã gửi đánh giá tháng</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Tổng số nhân viên là: </b>
                                        <asp:Label ID="lblTotalTopDaGuiDanhGia" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="overflow: scroll; height: 300px">
                                            <asp:GridView ID="dgrDaGuiDanhGia" runat="server" AutoGenerateColumns="False" BorderColor="Gainsboro"
                                                BorderStyle="solid" BorderWidth="1px" CellPadding="5" CssClass="Grid" OnRowCommand="dgrDaGuiDanhGia_RowCommand"
                                                Width="100%" AllowPaging="true" AllowSorting="True" OnSorting="dgrDaGuiDanhGia_Sorting"
                                                OnPreRender="dgrDaGuiDanhGia_PreRender" OnPageIndexChanging="dgrDaGuiDanhGia_PageIndexChanging"
                                                PageSize="200">
                                                <AlternatingRowStyle CssClass="Grid_Raw2" />
                                                <RowStyle CssClass="Grid_Raw1" />
                                                <HeaderStyle CssClass="Grid_Top" Font-Bold="True" />
                                                <Columns>
                                                    <asp:TemplateField SortExpression="User_ID" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKey" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                                            <asp:Label ID="lblMail" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="HoTen" HeaderText="T&#234;n" SortExpression="HoTen" ItemStyle-Width="200px" />
                                                    <asp:TemplateField HeaderText="Thao t&#225;c" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnXem" Width="70px" CommandArgument='<%# Eval("UserID") %>' runat="server"
                                                                CssClass="Button" CommandName="xem" Text="Xem"></asp:Button>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerTemplate>
                                                    <table id="tbPager" width="100%">
                                                        <tr>
                                                            <td>
                                                                Page
                                                                <asp:DropDownList ID="ddlNumberPagesDaGuiDanhGia" Width="40px" runat="server" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlNumberPagesDaGuiDanhGia_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                of
                                                                <asp:Label ID="lbTotalPagesDaGuiDanhGia" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPageItemsDaGuiDanhGia" Width="40px" runat="server" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlPageItemsDaGuiDanhGia_SelectedIndexChanged">
                                                                    <asp:ListItem>5</asp:ListItem>
                                                                    <asp:ListItem Selected="True">10</asp:ListItem>
                                                                    <asp:ListItem>20</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right">
                                                                <asp:LinkButton ID="lbtnFirstDaGuiDanhGia" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="First" Text="<<"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnPrevDaGuiDanhGia" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Prev" Text="Prev"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnNextDaGuiDanhGia" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Next" Text="Next"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnLastDaGuiDanhGia" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Last" Text=">>"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </PagerTemplate>
                                                <EmptyDataTemplate>
                                                    There was no data to return
                                                </EmptyDataTemplate>
                                                <PagerSettings Mode="NumericFirstLast" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                               
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px" colspan="7" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" class="InputBox" valign="top">
                            <table width="100%" cellpadding="5" cellspacing="0">
                                <tr>
                                    <td valign="top" align="center" style="background-color: #D0D5D9">
                                        <b style="color: Red">Nhân viên có cập nhật công việc phát sinh</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Tổng số bản ghi là: </b>
                                        <asp:Label ID="lblTotalTopCongViecPhatSinh" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="overflow: scroll; height: 300px">
                                            <asp:GridView ID="dgrCongViecPhatSinh" runat="server" AutoGenerateColumns="False"
                                                BorderColor="Gainsboro" BorderStyle="solid" BorderWidth="1px" CellPadding="5"
                                                CssClass="Grid" OnRowCommand="dgrCongViecPhatSinh_RowCommand" Width="100%" AllowPaging="true"
                                                AllowSorting="True" OnSorting="dgrCongViecPhatSinh_Sorting" OnPreRender="dgrCongViecPhatSinh_PreRender"
                                                OnPageIndexChanging="dgrCongViecPhatSinh_PageIndexChanging" PageSize="200">
                                                <AlternatingRowStyle CssClass="Grid_Raw2" />
                                                <RowStyle CssClass="Grid_Raw1" />
                                                <HeaderStyle CssClass="Grid_Top" Font-Bold="True" />
                                                <Columns>
                                                    <asp:TemplateField SortExpression="User_ID" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKey" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                                            <asp:Label ID="lblMail" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="HoTen" HeaderText="T&#234;n" SortExpression="HoTen" ItemStyle-Width="200px" />
                                                    <asp:TemplateField HeaderText="Thao t&#225;c" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnXem" Width="70px" runat="server" CssClass="Button" CommandName="xem"
                                                                Text="Xem"></asp:Button>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerTemplate>
                                                    <table id="tbPager" width="100%">
                                                        <tr>
                                                            <td>
                                                                Page
                                                                <asp:DropDownList ID="ddlNumberPagesCongViecPhatSinh" runat="server" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlNumberPagesCongViecPhatSinh_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                of
                                                                <asp:Label ID="lbTotalPagesCongViecPhatSinh" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPageItemsCongViecPhatSinh" Width="70px" runat="server" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlPageItemsCongViecPhatSinh_SelectedIndexChanged">
                                                                    <asp:ListItem>5</asp:ListItem>
                                                                    <asp:ListItem Selected="True">10</asp:ListItem>
                                                                    <asp:ListItem>20</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right">
                                                                <asp:LinkButton ID="lbtnFirstCongViecPhatSinh" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="First" Text="<<"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnPrevCongViecPhatSinh" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Prev" Text="Prev"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnNextCongViecPhatSinh" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Next" Text="Next"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnLastCongViecPhatSinh" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Last" Text=">>"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </PagerTemplate>
                                                <EmptyDataTemplate>
                                                    There was no data to return
                                                </EmptyDataTemplate>
                                                <PagerSettings Mode="NumericFirstLast" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10">
                                    </td>
                                </tr>
                               
                            </table>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlCOO_CEO" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="25%" class="InputBox" valign="top">
                            <table width="100%" cellpadding="5" cellspacing="0">
                                <tr>
                                    <td valign="top" align="center" style="background-color: #D0D5D9">
                                        <b style="color: Red">Bộ phận chưa gửi kế hoạch</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnBoPhanChuaGuiKeHoach" runat="server" CssClass="Button" Text="Gửi mail nhắc nhở"
                                            OnClick="btnBoPhanChuaGuiKeHoach_Click"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Tổng số bộ phận là: </b>
                                        <asp:Label ID="lblTotalBoPhanChuaGuiKeHoachTop" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="overflow: scroll; height: 300px">
                                            <asp:GridView ID="dgrBoPhanChuaGuiKeHoach" runat="server" AutoGenerateColumns="False"
                                                BorderColor="Gainsboro" BorderStyle="solid" BorderWidth="1px" CellPadding="5"
                                                CssClass="Grid" OnRowCommand="dgrBoPhanChuaGuiKeHoach_RowCommand" Width="100%"
                                                AllowPaging="true" AllowSorting="True" OnSorting="dgrBoPhanChuaGuiKeHoach_Sorting"
                                                OnPreRender="dgrBoPhanChuaGuiKeHoach_PreRender" OnPageIndexChanging="dgrBoPhanChuaGuiKeHoach_PageIndexChanging"
                                                PageSize="200">
                                                <AlternatingRowStyle CssClass="Grid_Raw2" />
                                                <RowStyle CssClass="Grid_Raw1" />
                                                <HeaderStyle CssClass="Grid_Top" Font-Bold="True" />
                                                <Columns>
                                                    <asp:TemplateField SortExpression="User_ID" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKey" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                            <asp:Label ID="lblMail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Ten" HeaderText="T&#234;n" SortExpression="Ten" ItemStyle-Width="200px" />
                                                    <asp:TemplateField HeaderText="Thao t&#225;c" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnGuiMailNhacNho" runat="server" CommandArgument='<%# Eval("Email") %>'
                                                                CssClass="Button" CommandName="mail" Text="Gửi mail"></asp:Button>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerTemplate>
                                                    <table id="tbPager" width="100%">
                                                        <tr>
                                                            <td>
                                                                Page
                                                                <asp:DropDownList ID="ddlNumberPagesBoPhanChuaGuiKeHoach" Width="40px" runat="server"
                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlNumberPagesBoPhanChuaGuiKeHoach_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                of
                                                                <asp:Label ID="lbTotalPagesBoPhanChuaGuiKeHoach" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPageItemsBoPhanChuaGuiKeHoach" Width="40px" runat="server"
                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlPageItemsBoPhanChuaGuiKeHoach_SelectedIndexChanged">
                                                                    <asp:ListItem>5</asp:ListItem>
                                                                    <asp:ListItem Selected="True">10</asp:ListItem>
                                                                    <asp:ListItem>20</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right">
                                                                <asp:LinkButton ID="lbtnFirstBoPhanChuaGuiKeHoach" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="First" Text="<<"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnPrevBoPhanChuaGuiKeHoach" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Prev" Text="Prev"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnNextBoPhanChuaGuiKeHoach" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Next" Text="Next"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnLastBoPhanChuaGuiKeHoach" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Last" Text=">>"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </PagerTemplate>
                                                <EmptyDataTemplate>
                                                    There was no data to return
                                                </EmptyDataTemplate>
                                                <PagerSettings Mode="NumericFirstLast" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td height="5px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="25%" class="InputBox" valign="top">
                            <table width="100%" cellpadding="5" cellspacing="0">
                                <tr>
                                    <td valign="top" align="center" style="background-color: #D0D5D9">
                                        <b style="color: Red">Bộ phận đã gửi kế hoạch</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Tổng số bộ phận là: </b>
                                        <asp:Label ID="lblTotalBoPhanDaGuiKeHoachTop" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="overflow: scroll; height: 300px">
                                            <asp:GridView ID="dgrBoPhanDaGuiKeHoach" runat="server" AutoGenerateColumns="False"
                                                BorderColor="Gainsboro" BorderStyle="solid" BorderWidth="1px" CellPadding="5"
                                                CssClass="Grid" OnRowCommand="dgrBoPhanDaGuiKeHoach_RowCommand" Width="100%"
                                                AllowPaging="true" AllowSorting="True" OnSorting="dgrBoPhanDaGuiKeHoach_Sorting"
                                                OnPreRender="dgrBoPhanDaGuiKeHoach_PreRender" OnPageIndexChanging="dgrBoPhanDaGuiKeHoach_PageIndexChanging"
                                                PageSize="200">
                                                <AlternatingRowStyle CssClass="Grid_Raw2" />
                                                <RowStyle CssClass="Grid_Raw1" />
                                                <HeaderStyle CssClass="Grid_Top" Font-Bold="True" />
                                                <Columns>
                                                    <asp:TemplateField SortExpression="User_ID" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKey" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                            <asp:Label ID="lblMail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Ten" HeaderText="T&#234;n" SortExpression="Ten" ItemStyle-Width="200px" />
                                                    <asp:TemplateField HeaderText="Thao t&#225;c" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnXem" Width="70px" runat="server" CssClass="Button" CommandName="xem"
                                                                Text="Xem"></asp:Button>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerTemplate>
                                                    <table id="tbPager" width="100%">
                                                        <tr>
                                                            <td>
                                                                Page
                                                                <asp:DropDownList ID="ddlNumberPagesBoPhanDaGuiKeHoach" Width="40px" runat="server"
                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlNumberPagesBoPhanDaGuiKeHoach_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                of
                                                                <asp:Label ID="lbTotalPagesBoPhanDaGuiKeHoach" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPageItemsBoPhanDaGuiKeHoach" Width="40px" runat="server"
                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlPageItemsBoPhanDaGuiKeHoach_SelectedIndexChanged">
                                                                    <asp:ListItem>5</asp:ListItem>
                                                                    <asp:ListItem Selected="True">10</asp:ListItem>
                                                                    <asp:ListItem>20</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right">
                                                                <asp:LinkButton ID="lbtnFirstBoPhanDaGuiKeHoach" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="First" Text="<<"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnPrevBoPhanDaGuiKeHoach" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Prev" Text="Prev"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnNextBoPhanDaGuiKeHoach" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Next" Text="Next"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnLastBoPhanDaGuiKeHoach" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Last" Text=">>"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </PagerTemplate>
                                                <EmptyDataTemplate>
                                                    There was no data to return
                                                </EmptyDataTemplate>
                                                <PagerSettings Mode="NumericFirstLast" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Tổng số bộ phận là: </b>
                                        <asp:Label ID="lblTotalBoPhanDaGuiKeHoachBottom" runat="server" Font-Bold="true"
                                            ForeColor="Blue"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="25%" class="InputBox" valign="top">
                            <table width="100%" cellpadding="5" cellspacing="0">
                                <tr>
                                    <td valign="top" align="center" style="background-color: #D0D5D9">
                                        <b style="color: Red">Bộ phận chưa gửi đánh giá tháng</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnBoPhanChuaGuiDanhGia" runat="server" CssClass="Button" Text="Gửi mail nhắc nhở"
                                            OnClick="btnBoPhanChuaGuiDanhGia_Click"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Tổng số bản ghi là: </b>
                                        <asp:Label ID="lblTotalBoPhanChuaGuiDanhGiaTop" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="overflow: scroll; height: 300px">
                                            <asp:GridView ID="dgrBoPhanChuaGuiDanhGia" runat="server" AutoGenerateColumns="False"
                                                BorderColor="Gainsboro" BorderStyle="solid" BorderWidth="1px" CellPadding="5"
                                                CssClass="Grid" OnRowCommand="dgrBoPhanChuaGuiDanhGia_RowCommand" Width="100%"
                                                AllowPaging="true" AllowSorting="True" OnSorting="dgrBoPhanChuaGuiDanhGia_Sorting"
                                                OnPreRender="dgrBoPhanChuaGuiDanhGia_PreRender" OnPageIndexChanging="dgrBoPhanChuaGuiDanhGia_PageIndexChanging"
                                                PageSize="200">
                                                <AlternatingRowStyle CssClass="Grid_Raw2" />
                                                <RowStyle CssClass="Grid_Raw1" />
                                                <HeaderStyle CssClass="Grid_Top" Font-Bold="True" />
                                                <Columns>
                                                    <asp:TemplateField SortExpression="User_ID" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKey" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                            <asp:Label ID="lblMail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Ten" HeaderText="T&#234;n" SortExpression="Ten" ItemStyle-Width="200px" />
                                                    <asp:TemplateField HeaderText="Thao t&#225;c" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnGuiMailNhacNho" Width="70px" CommandArgument='<%# Eval("Email") %>'
                                                                runat="server" CssClass="Button" CommandName="mail" Text="Gửi mail"></asp:Button>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerTemplate>
                                                    <table id="tbPager" width="100%">
                                                        <tr>
                                                            <td>
                                                                Page
                                                                <asp:DropDownList ID="ddlNumberPagesBoPhanChuaGuiDanhGia" Width="40px" runat="server"
                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlNumberPagesBoPhanChuaGuiDanhGia_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                of
                                                                <asp:Label ID="lbTotalPagesBoPhanChuaGuiDanhGia" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPageItemsBoPhanChuaGuiDanhGia" Width="40px" runat="server"
                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlPageItemsBoPhanChuaGuiDanhGia_SelectedIndexChanged">
                                                                    <asp:ListItem>5</asp:ListItem>
                                                                    <asp:ListItem Selected="True">10</asp:ListItem>
                                                                    <asp:ListItem>20</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right">
                                                                <asp:LinkButton ID="lbtnFirstBoPhanChuaGuiDanhGia" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="First" Text="<<"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnPrevBoPhanChuaGuiDanhGia" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Prev" Text="Prev"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnNextBoPhanChuaGuiDanhGia" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Next" Text="Next"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnLastBoPhanChuaGuiDanhGia" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Last" Text=">>"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </PagerTemplate>
                                                <EmptyDataTemplate>
                                                    There was no data to return
                                                </EmptyDataTemplate>
                                                <PagerSettings Mode="NumericFirstLast" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Tổng số bản ghi là: </b>
                                        <asp:Label ID="lblTotalBoPhanChuaGuiDanhGiaBottom" runat="server" Font-Bold="true"
                                            ForeColor="Blue"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="25%" class="InputBox" valign="top">
                            <div style="overflow: scroll; height: 300px">
                                <table width="100%" cellpadding="5" cellspacing="0">
                                    <tr>
                                        <td valign="top" align="center" style="background-color: #D0D5D9">
                                            <b style="color: Red">Bộ phận đã gửi đánh giá tháng</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Tổng số bộ phận là: </b>
                                            <asp:Label ID="lblTotalBoPhanDaGuiDanhGiaTop" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="dgrBoPhanDaGuiDanhGia" runat="server" AutoGenerateColumns="False"
                                                BorderColor="Gainsboro" BorderStyle="solid" BorderWidth="1px" CellPadding="5"
                                                CssClass="Grid" OnRowCommand="dgrBoPhanDaGuiDanhGia_RowCommand" Width="100%"
                                                AllowPaging="true" AllowSorting="True" OnSorting="dgrBoPhanDaGuiDanhGia_Sorting"
                                                OnPreRender="dgrBoPhanDaGuiDanhGia_PreRender" OnPageIndexChanging="dgrBoPhanDaGuiDanhGia_PageIndexChanging"
                                                PageSize="200">
                                                <AlternatingRowStyle CssClass="Grid_Raw2" />
                                                <RowStyle CssClass="Grid_Raw1" />
                                                <HeaderStyle CssClass="Grid_Top" Font-Bold="True" />
                                                <Columns>
                                                    <asp:TemplateField SortExpression="User_ID" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKey" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                            <asp:Label ID="lblMail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Ten" HeaderText="T&#234;n" SortExpression="Ten" ItemStyle-Width="200px" />
                                                    <asp:TemplateField HeaderText="Thao t&#225;c" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnXem" Width="70px" runat="server" CssClass="Button" CommandName="xem"
                                                                Text="Xem"></asp:Button>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerTemplate>
                                                    <table id="tbPager" width="100%">
                                                        <tr>
                                                            <td>
                                                                Page
                                                                <asp:DropDownList ID="ddlNumberPagesBoPhanDaGuiDanhGia" Width="40px" runat="server"
                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlNumberPagesBoPhanDaGuiDanhGia_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                of
                                                                <asp:Label ID="lbTotalPagesBoPhanDaGuiDanhGia" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPageItemsBoPhanDaGuiDanhGia" Width="40px" runat="server"
                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlPageItemsBoPhanDaGuiDanhGia_SelectedIndexChanged">
                                                                    <asp:ListItem>5</asp:ListItem>
                                                                    <asp:ListItem Selected="True">10</asp:ListItem>
                                                                    <asp:ListItem>20</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right">
                                                                <asp:LinkButton ID="lbtnFirstBoPhanDaGuiDanhGia" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="First" Text="<<"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnPrevBoPhanDaGuiDanhGia" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Prev" Text="Prev"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnNextBoPhanDaGuiDanhGia" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Next" Text="Next"></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lbtnLastBoPhanDaGuiDanhGia" runat="server" CausesValidation="false"
                                                                    CommandName="Page" CommandArgument="Last" Text=">>"></asp:LinkButton>
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
                                  
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>--%>
