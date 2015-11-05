<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="User_DiemSangTaoManagement.ascx.cs"
    Inherits="VmgPortal.Administrator.Users.User_DiemSangTaoManagement" %>
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
                    <asp:AsyncPostBackTrigger ControlID="rptLetters" EventName="ItemCommand" />
                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <asp:Label ID="lblUpdateStatus" runat="server"></asp:Label>
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td class="InputBox">
                                <asp:Panel ID="pnSearch" runat="server" DefaultButton="btnSearch">
                                    <table cellpadding="5" cellspacing="0">
                                        <tr>
                                            <td>
                                                <strong>Đợt đánh giá:</strong>
                                            </td>
                                            <td>
                                                <asp:DropDownList AutoPostBack="true" CssClass="form-control" Width="220px" ID="dropDotDanhGia"
                                                    runat="server" DataTextField="Ten" DataValueField="ID">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <strong>Trung Tâm:</strong>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dropTrungTam" CssClass="form-control" Width="90px" runat="server"
                                                    DataTextField="Ten" DataValueField="ID">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <strong>Từ khóa:</strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtKeyword" Width="130px" CssClass="form-control" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <strong>Theo:</strong>
                                            </td>
                                            <td>
                                                <asp:DropDownList CssClass="form-control" ID="dropSearchBy" runat="server" Width="110px">
                                                    <asp:ListItem Text="Tất cả" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="Tên Đăng nhập" Value="Username"></asp:ListItem>
                                                    <asp:ListItem Text="Họ tên" Value="HoTen"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <strong>Trạng thái:</strong>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dropTrangThai" CssClass="form-control" Width="110px" runat="server">
                                                    <asp:ListItem Text="All" Value="-1"></asp:ListItem>
                                                    <asp:ListItem Text="Nghỉ việc" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Chính thức" Value="1" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Thời vụ" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Thử việc" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Nghỉ chế độ" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="Đào tạo" Value="5"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <strong>Giới tính:</strong>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dropGender" CssClass="form-control" Width="70px" runat="server">
                                                    <asp:ListItem Text="All" Value="-1"></asp:ListItem>
                                                    <asp:ListItem Text="Nam" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Nữ" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="12" align="center">
                                                <asp:Button ID="btnSearch" runat="server" CssClass="btn blue" Text="Tìm kiếm" OnClick="btnSearch_Click" />&nbsp;<asp:Button
                                                    ID="btnUpdate" runat="server" CssClass="btn green" Text="Cập nhật" OnClick="btnUpdate_Click" />
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
                                <strong>Alphabet:</strong>
                                <asp:Repeater ID="rptLetters" runat="server" OnItemCommand="rptLetters_ItemCommand">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkLetter" runat="server" CommandName="Alpha"></asp:LinkButton>
                                    </ItemTemplate>
                                    <SeparatorTemplate>
                                        &nbsp;|&nbsp;</SeparatorTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                        <tr style="display: none">
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
                                        <asp:TemplateField SortExpression="User_ID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblKey" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="HoTen" HeaderText="T&#234;n" SortExpression="HoTen" ItemStyle-Width="150px" />
                                        <asp:BoundField DataField="MaSo" HeaderText="Mã Số" SortExpression="MaSo" ItemStyle-Width="70px"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Username" HeaderText="T&#234;n truy cập" SortExpression="Username"
                                            ItemStyle-Width="150px" />
                                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="Tình trạng">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblTrangThai" Text='<%# GetTrangThai(Eval("TrangThai")) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="150px" HeaderText="Điểm" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtDiem" CssClass="form-control" Width="50px" runat="server" Text='<%# Eval("Diem") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="300px" HeaderText="Ghi chú" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtNote" CssClass="form-control" Width="350px" TextMode="MultiLine"
                                                    runat="server" Text='<%# Eval("Note") %>'></asp:TextBox>
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
