<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TongHopBaoCaoNgayNhanVien.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.BaoCao.TongHopBaoCaoNgayNhanVien" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Import Namespace="VmgPortal.Library.Utilities" %>
<div class="row">
    <div class="col-md-12">
        <div class="portlet box green">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-reorder"></i>Tiêu chí tìm kiếm
                </div>
                <div class="tools">
                    <a href="" class="collapse"></a>
                </div>
            </div>
            <div class="portlet-body form">
                <div class="form-horizontal" role="form">
                    <div class="form-body">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td align="center" valign="top">
                                    <asp:Panel ID="pnSearch" runat="server" DefaultButton="btnSearch">
                                        <table cellpadding="5" cellspacing="0" style="width: 50%">
                                            <tr>
                                                <td width="150px">
                                                    <table cellpadding="4" cellspacing="0" style="width: 100%">
                                                        <tr>
                                                            <td align="right">
                                                                Năm:
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="dropYear" CssClass="form-control" runat="server" Width="80px">
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
                                                                    Width="80px" OnSelectedIndexChanged="dropMonth_SelectedIndexChanged">
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
                                                                <asp:DropDownList ID="dropDay" AutoPostBack="true" CssClass="form-control" runat="server"
                                                                    Width="80px" OnSelectedIndexChanged="dropDay_SelectedIndexChanged">
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
                                                                <asp:DropDownList ID="dropDotDanhGia" CssClass="form-control" DataTextField="Ten"
                                                                    DataValueField="ID" runat="server" Width="300px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <strong>Trung tâm:</strong>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="dropTrungTam" CssClass="form-control" runat="server" DataTextField="Ten"
                                                                    DataValueField="ID" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="dropTrungTam_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr style="display: none">
                                                            <td align="right">
                                                                <strong>Phòng ban:</strong>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="dropPhongBan" runat="server" CssClass="form-control" DataTextField="Ten"
                                                                    DataValueField="ID" AutoPostBack="True" Width="300px" OnSelectedIndexChanged="dropPhongBan_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <strong>Người thực hiện:</strong>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="dropUser" runat="server" CssClass="form-control" DataTextField="UserName"
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
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-reorder"></i>Báo cáo ngày
                </div>
                <div class="tools">
                    <a href="" class="collapse"></a>
                </div>
            </div>
            <div class="portlet-body form">
                <div class="form-horizontal" role="form">
                    <div class="form-body">
                        <asp:Label ID="lblUpdateStatus" runat="server"></asp:Label>
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
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
                                <td align="right">
                                    <asp:Button ID="btnUpdateVaoBoPhan" CssClass="btn green" runat="server" Text="Cập nhật công việc vào báo cáo của bộ phận"
                                        OnClick="btnUpdateVaoBoPhan_Click" />
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
                                        Width="100%" AllowPaging="true" AllowSorting="True" OnSorting="dtgUsers_Sorting"
                                        OnPreRender="dtgUsers_PreRender" OnPageIndexChanging="dtgUsers_PageIndexChanging"
                                        PageSize="20">
                                        <AlternatingRowStyle CssClass="odd" />
                                        <RowStyle CssClass="even" />
                                        <HeaderStyle CssClass="sorting_disabled" ForeColor="Black" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Người thực hiện" ItemStyle-Width="150px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNguoiThucHien" runat="server" Text='<%# Eval("HoTen") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="User_ID" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblKey" runat="server" Text='<%# Eval("CreateBy") %>'></asp:Label>
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CongViecCha" HeaderText="Nhóm công việc" ItemStyle-Width="150px" />
                                            <asp:BoundField DataField="CongViecKPI" HeaderText="Tên công việc" ItemStyle-Width="150px" />
                                            <asp:TemplateField HeaderText="Công việc trong ngày" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="150px">
                                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lnkTenCongViec" runat="server" Text='<%# Eval("Ten") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:BoundField DataField="KeHoach" HeaderText="Kế hoạch và yêu cầu" ItemStyle-Width="150px" />--%>
                                            <%-- <asp:TemplateField ItemStyle-Width="70px" HeaderText="Tỷ trọng" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTrangThai" runat="server" Text='<%# Math.Round(ConvertUtility.ToDouble(Eval("TyTrong")),2).ToString() + "%" %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:BoundField DataField="SoGio" HeaderText="Số giờ" ItemStyle-Width="70px" />
                                            <asp:BoundField DataField="TyLeHoanThanh" HeaderText="Tỷ lệ hoàn thành" ItemStyle-Width="70px" />
                                            <asp:BoundField DataField="KetQua" HeaderText="Kết quả" ItemStyle-Width="150px" />
                                            <asp:BoundField DataField="LyDo" HeaderText="Lý do không hoàn thành / Báo cáo lỗi và sự cố"
                                                ItemStyle-Width="150px" />
                                            <asp:BoundField DataField="DeXuat" HeaderText="Đề xuất" ItemStyle-Width="150px" />
                                            <asp:TemplateField ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkCheck" runat="server" Checked='<%# Eval("Status") %>' />
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
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
