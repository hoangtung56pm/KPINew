<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserManagement.ascx.cs"
    Inherits="VmgPortal.Administrator.Users.UserManagement" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Import Namespace="VmgPortal.Library.Utilities" %>
<div class="row">
    <div class="col-md-12">
        <!-- BEGIN PAGE TITLE & BREADCRUMB-->
        <ul class="page-breadcrumb breadcrumb">
            <%--  <li class="btn-group">
                <button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                    <span>Actions</span> <i class="icon-angle-down"></i>
                </button>
                <ul class="dropdown-menu pull-right" role="menu">
                    <li><a href="#">Action</a></li>
                    <li><a href="#">Another action</a></li>
                    <li><a href="#">Something else here</a></li>
                    <li class="divider"></li>
                    <li><a href="#">Separated link</a></li>
                </ul>
            </li>--%>
            <li><i class="icon-home"></i><a href="/">Trang chủ</a> <i class="icon-angle-right"></i>
            </li>
            <li><a href="#">Quản lý nhân viên</a> <i class="icon-angle-right"></i></li>
        </ul>
        <!-- END PAGE TITLE & BREADCRUMB-->
    </div>
</div>
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
                    <asp:AsyncPostBackTrigger ControlID="btnDeleteSelected" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <asp:Label ID="lblUpdateStatus" runat="server"></asp:Label>
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td class="InputBox">
                                <asp:Panel ID="pnSearch" runat="server" DefaultButton="btnSearch">
                                    <table cellpadding="4" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                <strong>Trung Tâm:</strong>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dropTrungTam" CssClass="form-control" Width="100px" runat="server"
                                                    DataTextField="Ten" DataValueField="ID">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <strong>Từ khóa:</strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtKeyword" CssClass="form-control" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <strong>Theo:</strong>
                                            </td>
                                            <td>
                                                <asp:DropDownList CssClass="form-control" ID="dropSearchBy" runat="server" Width="100px">
                                                    <asp:ListItem Text="Tất cả" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="Tên Đăng nhập" Value="Username"></asp:ListItem>
                                                    <asp:ListItem Text="Họ tên" Value="HoTen"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <strong>Trạng thái:</strong>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dropTrangThai" Width="100px" CssClass="form-control" runat="server">
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
                                                <asp:DropDownList ID="dropGender" Width="100px" CssClass="form-control" runat="server">
                                                    <asp:ListItem Text="All" Value="-1"></asp:ListItem>
                                                    <asp:ListItem Text="Nam" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Nữ" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSearch" runat="server" CssClass="btn blue" Text="Tìm kiếm" OnClick="btnSearch_Click" />
                                                <asp:Button ID="btnAddUser" runat="server" CssClass="btn green" OnClick="btnAddUser_Click"
                                                    Text="Tạo người dùng mới" />
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
                        <tr>
                            <td height="10">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Tổng số bản ghi là: </b>
                                <asp:Label ID="lblTotalTop" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="dtgUsers" runat="server" AutoGenerateColumns="False" CellPadding="2" CssClass="table table-striped table-hover table-bordered dataTable"
                                    OnRowCommand="dtgUsers_RowCommand" Width="100%" AllowPaging="true" AllowSorting="True"
                                    OnSorting="dtgUsers_Sorting" OnPreRender="dtgUsers_PreRender" OnPageIndexChanging="dtgUsers_PageIndexChanging"
                                    PageSize="20">
                                    <AlternatingRowStyle CssClass="odd" />
                                    <RowStyle CssClass="even" />
                                    <HeaderStyle CssClass="sorting_disabled" />
                                    <Columns>
                                        <asp:TemplateField SortExpression="User_ID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblKey" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false" ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:CheckBox runat="server" ID="chkAll" onclick="Check(this,'dtgUsers');highlightChkBxRow(this);" />
                                            </HeaderTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="DeleteThis" onclick="highlightChkBxRow(this);" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="HoTen" HeaderText="T&#234;n" ItemStyle-Width="150px" />
                                        <asp:BoundField DataField="MaSo" HeaderText="Mã Số" ItemStyle-Width="70px"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Username" HeaderText="T&#234;n truy cập"
                                            ItemStyle-Width="150px" />
                                        <asp:TemplateField ItemStyle-Width="100px">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblTrangThai" Text='<%# GetTrangThai(Eval("TrangThai")) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="Ngày Sinh" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNgaySinh" runat="server" Text='<%# ConvertUtility.ToDateTime(Eval("NgaySinh")).ToString("dd/MM/yyyy") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ChucVu" HeaderText="Chức Vụ" ItemStyle-Width="200px" />
                                        <asp:BoundField DataField="RoleDescription" HeaderText="Nhóm quyền" 
                                            ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField ItemStyle-Width="150px" HeaderText="Phòng ban" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="dropPhong" CssClass="form-control" Width="150px" runat="server" DataTextField="Ten"
                                                    DataValueField="ID">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Thao t&#225;c" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnImgManageProfile" ImageUrl="/Images/GridView/edit.gif" runat="server"
                                                    CommandArgument='<%# Eval("UserID") %>' CommandName="manageprofile" ToolTip="Sửa" />
                                                &nbsp;
                                                <asp:ImageButton ID="btnImgManagePassword" ImageUrl="/Images/GridView/password.gif"
                                                    runat="server" CommandArgument='<%# Eval("UserID") %>' CommandName="managepassword"
                                                    ToolTip="Mật khẩu" />
                                                &nbsp;
                                                <asp:ImageButton ID="btnImgUserPermision" ImageUrl="/Images/GridView/role.gif" runat="server"
                                                    CommandArgument='<%# Eval("UserID") %>' CommandName="userpermision" ToolTip="Phân quyền" />
                                                &nbsp;
                                                <asp:ImageButton ID="btnImgDeleteUser" ImageUrl="/Images/GridView/delete.gif" runat="server"
                                                    CommandArgument='<%# Eval("UserID") %>' CommandName="deleteuser" ToolTip="Xóa" />
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
                       <%-- <tr>
                            <td height="10">
                            </td>
                        </tr>--%>
                        <tr style="display:none">
                            <td height="10">
                                <asp:Button ID="btnDeleteSelected" runat="server" CssClass="btn red" OnClientClick="return confirmMsg(this.form)"
                                    Text="Xóa các bản ghi được chọn" OnClick="btnDeleteSelected_Click" />
                                <%-- Chọn đợt đánh giá:
                                <asp:DropDownList AutoPostBack="true" Width="300px" ID="dropDotDanhGia" runat="server"
                                    DataTextField="Ten" DataValueField="ID">
                                </asp:DropDownList>
                                <asp:Button ID="btnUpdatePhongBan" runat="server" CssClass="Button" Text="Cập nhật phòng ban"
                                    OnClick="btnUpdatePhongBan_Click" />--%>
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
