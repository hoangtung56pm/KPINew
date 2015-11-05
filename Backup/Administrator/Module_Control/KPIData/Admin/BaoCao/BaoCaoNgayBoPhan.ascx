<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BaoCaoNgayBoPhan.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.BaoCao.BaoCaoNgayBoPhan" %>
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
            <%--<asp:UpdatePanel ID="upanelGridUserManagemt" runat="server" UpdateMode="Conditional"
                RenderMode="Inline">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                </Triggers>
                <ContentTemplate>--%>
            <asp:Label ID="lblUpdateStatus" runat="server"></asp:Label>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td class="InputBox" align="center">
                        <asp:Panel ID="pnSearch" runat="server" DefaultButton="btnSearch">
                            <table cellpadding="4" cellspacing="0" style="width: 50%">
                                <tr>
                                    <td width="150px">
                                        <table cellpadding="4" cellspacing="0" style="width: 100%">
                                            <tr>
                                                <td align="right">
                                                    Năm:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="dropYear" CssClass="form-control" runat="server" Width="70px">
                                                        <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                                                        <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                                                        <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                                        <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                                                        <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                                        <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                                        <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    Tháng:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="dropMonth" CssClass="form-control" AutoPostBack="true" runat="server"
                                                        Width="70px" OnSelectedIndexChanged="dropMonth_SelectedIndexChanged">
                                                        <asp:ListItem Text="--All--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    Ngày:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="dropDay" CssClass="form-control" AutoPostBack="true" runat="server"
                                                        Width="70px" OnSelectedIndexChanged="dropDay_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table cellpadding="4" cellspacing="0">
                                            <tr>
                                                <td align="right">
                                                    <strong>Đợt đánh giá:</strong>
                                                </td>
                                                <td>
                                                    <asp:DropDownList CssClass="form-control" ID="dropDotDanhGia" DataTextField="Ten"
                                                        DataValueField="ID" runat="server" Width="300px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <strong>Trung tâm:</strong>
                                                </td>
                                                <td>
                                                    <asp:DropDownList CssClass="form-control" ID="dropTrungTam" runat="server" DataTextField="Ten"
                                                        DataValueField="ID" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="dropTrungTam_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <strong>Người thực hiện:</strong>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="dropUser" CssClass="form-control" runat="server" DataTextField="UserName"
                                                        DataValueField="UserID" AutoPostBack="True" Width="300px" OnSelectedIndexChanged="dropUser_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn blue" Text="Tìm kiếm" OnClick="btnSearch_Click" />
                                        <asp:Button ID="btnGuiBaoCaoNgayBoPhan" CssClass="btn green" runat="server" Text="Gửi mail thông báo đến COO"
                                            OnClick="btnGuiBaoCaoNgayBoPhan_Click" />
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
                    <td class="inputBox">
                        <table width="100%" cellpadding="5" cellspacing="0">
                            <tr>
                                <td align="center">
                                    <b>Tên công việc lớn</b>
                                </td>
                                <td align="center">
                                    <b>Tên công việc</b>
                                </td>
                                <td align="center">
                                    <b>Kế hoạch và yêu cầu</b>
                                </td>
                                <td align="center">
                                    <b>Tỷ lệ hoàn thành</b>
                                </td>
                                <td align="center">
                                    <b>Kết quả</b>
                                </td>
                                <td align="center" width="150px">
                                    <b>Lý do không hoàn thành / Báo cáo lỗi và sự cố</b>
                                </td>
                                <td align="center">
                                    <b>Đề xuất</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCongViecLon" CssClass="form-control" Rows="4" runat="server"
                                        Width="150px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCongViec" CssClass="form-control" Rows="4" runat="server" Width="150px"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtKeHoach" CssClass="form-control" Rows="4" runat="server" Width="150px"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTyLeHoanThanh" CssClass="form-control" Rows="4" runat="server"
                                        Width="150px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtKetQua" CssClass="form-control" Rows="4" runat="server" Width="150px"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLyDo" CssClass="form-control" Rows="4" runat="server" Width="150px"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDeXuat" CssClass="form-control" Rows="4" runat="server" Width="150px"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" align="center">
                                    <asp:Button CssClass="btn green" ID="btnAdd" runat="server" Text="Thêm mới" OnClick="btnAdd_Click" />
                                    <br />
                                    <asp:Label ID="lblStatusUpdate" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <%--<tr>
                    <td>
                        <b>Tổng số bản ghi là: </b>
                        <asp:Label ID="lblTotalTop" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                      
                        <asp:Button ID="btnCapNhatCVTuNhanVien" CssClass="btn blue" runat="server" Text="Tổng hợp công việc của nhân viên"
                            OnClick="btnCapNhatCVTuNhanVien_Click" />
                        <asp:Button ID="btnUpdateVaoBoPhan" CssClass="btn dark" runat="server" Text="Gỡ bỏ công việc ra khỏi báo cáo của bộ phận"
                            OnClick="btnUpdateVaoBoPhan_Click" />
                              <asp:Button ID="btnTest" runat="server" CssClass="btn green" Text="Export to excel"
                            OnClick="btnTest_Click" />
                    </td>
                </tr>
                <tr>
                    <td height="10">
                        <asp:HyperLink ID="hplDownload" runat="server"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="dtgUsers" runat="server" AutoGenerateColumns="False" BorderColor="Gainsboro"
                            BorderStyle="solid" BorderWidth="1px" CellPadding="5" CssClass="table table-striped table-hover table-bordered dataTable"
                            Width="100%" AllowPaging="true" AllowSorting="True" OnSorting="dtgUsers_Sorting"
                            OnPreRender="dtgUsers_PreRender" OnPageIndexChanging="dtgUsers_PageIndexChanging"
                            PageSize="20" OnRowCommand="dtgUsers_RowCommand" AutoGenerateEditButton="false"
                            OnRowCancelingEdit="dtgUsers_RowCancelingEdit" OnRowEditing="dtgUsers_RowEditing"
                            OnRowUpdating="dtgUsers_RowUpdating">
                            <AlternatingRowStyle CssClass="odd" />
                            <RowStyle CssClass="even" />
                            <HeaderStyle CssClass="sorting_disabled" ForeColor="Black" />
                            <Columns>
                                <asp:CommandField ItemStyle-Width="100px" ShowEditButton="true" ButtonType="Button"
                                    ItemStyle-HorizontalAlign="Center" EditText="Sửa" CancelText="Hủy" UpdateText="Cập nhật"
                                    HeaderText=""></asp:CommandField>
                                <asp:TemplateField SortExpression="User_ID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblKey" runat="server" Text='<%# Eval("CreateBy") %>'></asp:Label>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tên công việc lớn" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="150px">
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lnkCongViecCha" runat="server" Text='<%# Eval("CongViecKPI") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtCongViecCha" ReadOnly="true" Rows="4" CssClass="form-control"
                                            runat="Server" Text='<%# Eval("CongViecKPI") %>' Width="150px" TextMode="MultiLine"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tên công việc" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="150px">
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lnkTenCongViec" runat="server" Text='<%# Eval("Ten") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtTenCongViec" Rows="4" CssClass="form-control" runat="Server"
                                            Text='<%# Eval("Ten") %>' Width="150px" TextMode="MultiLine"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Kế hoạch và yêu cầu" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="150px">
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblKeHoach" runat="server" Text='<%# Eval("KeHoach") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtKeHoach" Rows="4" CssClass="form-control" runat="Server" Text='<%# Eval("KeHoach") %>'
                                            Width="150px" TextMode="MultiLine"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tỷ lệ hoàn thành" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="50px">
                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTyLeHoanThanh" runat="server" Text='<%# Eval("TyLeHoanThanh") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtTyLeHoanThanh" Rows="4" CssClass="form-control" runat="Server"
                                            Text='<%# Eval("TyLeHoanThanh") %>' Width="50px"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Kết quả" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblKetQua" runat="server" Text='<%# Eval("KetQua") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtKetQua" Rows="4" CssClass="form-control" runat="Server" Text='<%# Eval("KetQua") %>'
                                            Width="150px" TextMode="MultiLine"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lý do không hoàn thành / Báo cáo lỗi và sự cố" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="150px">
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLyDo" runat="server" Text='<%# Eval("LyDo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLyDo" Rows="4" CssClass="form-control" runat="Server" Text='<%# Eval("LyDo") %>'
                                            Width="150px" TextMode="MultiLine"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Đề xuất" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDeXuat" runat="server" Text='<%# Eval("DeXuat") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDeXuat" Rows="4" CssClass="form-control" runat="Server" Text='<%# Eval("DeXuat") %>'
                                            Width="150px" TextMode="MultiLine"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkCheck" CssClass="form-control" runat="server" Checked='<%# Eval("Status") %>' />
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
            <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
        </td>
    </tr>
</table>
