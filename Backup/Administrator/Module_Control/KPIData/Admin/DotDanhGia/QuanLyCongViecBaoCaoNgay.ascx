<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuanLyCongViecBaoCaoNgay.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.DotDanhGia.QuanLyCongViecBaoCaoNgay" %>
<%@ Import Namespace="VmgPortal.Library.Utilities" %>
<%@ Register Assembly="VmgPortal.FilePickerControl" Namespace="VmgPortal.FilePickerControl"
    TagPrefix="cc2" %>
<%@ Register Assembly="VmgPortal.Library" Namespace="VmgPortal.Library.Controls"
    TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<div class="row">
    <div class="col-md-3">
        <div class="portlet box grey">
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
                        <table width="100%" cellpadding="3" cellspacing="0">
                            <tr>
                                <td colspan="3">
                                    Đợt đánh giá
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:DropDownList AutoPostBack="true" CssClass="form-control" ID="dropDotDanhGia"
                                        runat="server" DataTextField="Ten" DataValueField="ID" OnSelectedIndexChanged="dropDotDanhGia_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    Bộ phận
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:DropDownList ID="dropTrungTam" runat="server" DataTextField="Ten" DataValueField="ID"
                                        AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="dropTrungTam_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    Phòng ban
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:DropDownList ID="dropPhongBan" runat="server" DataTextField="Ten" DataValueField="ID"
                                        AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="dropPhongBan_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                              <tr>
                                <td colspan="3">
                                    Năm/Tháng/Ngày
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="dropYear" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                                        <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                                        <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                        <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                                        <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                        <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                        <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList  ID="dropMonth" AutoPostBack="true" runat="server"
                                        CssClass="form-control" OnSelectedIndexChanged="dropMonth_SelectedIndexChanged">
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
                                <td>
                                    <asp:DropDownList ID="dropDay"  AutoPostBack="true" runat="server" CssClass="form-control"
                                        OnSelectedIndexChanged="dropDay_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="portlet box green">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-reorder"></i>Copy báo cáo ngày
                </div>
                <div class="tools">
                    <a href="" class="collapse"></a>
                </div>
            </div>
            <div class="portlet-body form">
                <div class="form-horizontal" role="form">
                    <div class="form-body">
                        <div class="row">
                            <div class="col-md-4">
                                <asp:DropDownList ID="dropYearCopy" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                                    <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                                    <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                    <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                                    <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                    <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                    <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="dropMonthCopy" AutoPostBack="true" runat="server" CssClass="form-control"
                                    OnSelectedIndexChanged="dropMonthCopy_SelectedIndexChanged">
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
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="dropDayCopy" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row" style="height: 15px">
                        </div>
                        <div class="row">
                            <div class="col-md-12" align="center">
                                <asp:Button ID="btnCapNhatCVHomTruoc" CausesValidation="false" runat="server" CssClass="btn blue"
                                    Text="Copy" OnClick="btnCapNhatCVHomTruoc_Click" /></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-9">
        <div class="portlet box blue ">
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
                        <table width="100%">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblStatusUpdate" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
                                    <cc1:GridView ID="dgrCongViec" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                        BorderColor="Gainsboro" BorderStyle="solid" BorderWidth="1px" CaptionAlign="Top"
                                        CellPadding="5" CssClass="table table-striped table-hover table-bordered dataTable"
                                        OnRowCommand="dgrCongViec_RowCommand" OnRowDataBound="dgrCongViec_RowDataBound"
                                        Width="100%" OnRowEditing="dgrCongViec_RowEditing" OnRowDeleting="dgrCongViec_RowDeleting">
                                        <AlternatingRowStyle CssClass="odd" />
                                        <RowStyle CssClass="even" />
                                        <HeaderStyle CssClass="sorting_disabled" ForeColor="Black" />
                                        <FooterStyle BackColor="Yellow" />
                                        <Columns>
                                           
                                            <%--<asp:BoundField HeaderText="ID" DataField="ID" Visible="true" HeaderStyle-Width="5%" />--%>
                                            <asp:TemplateField HeaderText="Nhóm công việc KPI" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblKPI" runat="server" Text='<%# Eval("CongViecKPI") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Yêu cầu công việc" HeaderStyle-Width="200px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCongViecLon" runat="server" Text='<%# Eval("ParentID") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tên công việc" HeaderStyle-Width="150px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTen" runat="server" Text='<%# Eval("Ten") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTongText" runat="server" Font-Bold="true" Text="Tổng tỷ trọng"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false" HeaderText="Tỷ trọng %" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="5%">
                                                <FooterStyle Font-Bold="true" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTyTrong" runat="server" Text='<%#  Math.Round(ConvertUtility.ToDouble(Eval("TyTrong")) ,3).ToString() %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTong" runat="server" ForeColor="Blue"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Số giờ" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="5%">
                                                <FooterStyle Font-Bold="true" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSoGio" runat="server" Text='<%#  Math.Round(ConvertUtility.ToDouble(Eval("SoGio")) ,3).ToString() %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTongSoGio" runat="server" ForeColor="Blue"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Kết quả" DataField="KetQua" HeaderStyle-Width="100px" />
                                            <asp:BoundField HeaderText="Tỷ lệ hoàn thành" DataField="TyLeHoanThanh" HeaderStyle-Width="70px" />
                                            <asp:BoundField HeaderText="Lý do không hoàn thành/ Báo cáo lỗi và sự cố" DataField="LyDo"
                                                HeaderStyle-Width="15%" />
                                            <asp:BoundField Visible="false" HeaderText="Đề xuât" DataField="DeXuat" HeaderStyle-Width="15%" />
                                             <asp:TemplateField HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnEdit" CausesValidation="false" CommandArgument='<%# Eval("ID") %>'
                                                        Text="Sửa" CssClass="btn btn-xs blue" CommandName="Edit" runat="server"></asp:Button>
                                                    <asp:Button ID="btnDelete" CausesValidation="false" CommandArgument='<%# Eval("ID") %>'
                                                        Text="Xóa" CssClass="btn btn-xs dark" CommandName="Delete" runat="server"></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </cc1:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td width="200px">
                                    Nhóm công việc KPI
                                    <%--(theo Kế hoạch tháng)--%>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropCongViecKPI" AutoPostBack="true" runat="server" CssClass="form-control"
                                        DataTextField="Ten" DataValueField="IDCongViecKPI" OnSelectedIndexChanged="dropCongViecKPI_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:UpdatePanel ID="updatedropCongViecKPI" runat="server" UpdateMode="Conditional"
                                        RenderMode="Inline">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="dropCongViecKPI" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td width="198px">
                                                    </td>
                                                    <td>
                                                        <table cellpadding="5">
                                                            <tr>
                                                                <td>
                                                                    Bắt đầu
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblFrom" runat="server" ForeColor="Blue"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    kết thúc
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblTo" runat="server" ForeColor="Blue"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Yêu cầu công việc
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCongViecLon" ReadOnly="true" runat="server" TextMode="MultiLine"
                                                            Rows="2" CssClass="form-control"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Công việc chi tiết theo ngày
                                </td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" TextMode="MultiLine" Rows="2" CssClass="form-control"></asp:TextBox><asp:TextBox
                                        ID="txtID" runat="server" Enabled="False" Visible="False" Width="10px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rpt" runat="server" ControlToValidate="txtName" ErrorMessage="Bạn phải nhập tên công việc chi tiết"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td>
                                    Cam kết hoàn thành
                                </td>
                                <td>
                                    <asp:TextBox ID="txtKeHoach" runat="server" TextMode="MultiLine" Rows="2" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Số giờ
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSoGio" runat="server" Width="50px" CssClass="form-control">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <%--<tr style="display: none">
                                <td>
                                    Phòng ban
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropPhong" runat="server" DataTextField="Ten" DataValueField="ID"
                                        CssClass="form-control">
                                    </asp:DropDownList>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    Kết quả hoàn thành
                                </td>
                                <td>
                                    <asp:TextBox ID="txtKetqua" runat="server" TextMode="MultiLine" Rows="2" CssClass="form-control">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tỷ lệ hoàn thành
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropTyLeHoanThanh" runat="server" CssClass="form-control" Width="80px">
                                        <asp:ListItem Text="10%" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="20%" Value="20"></asp:ListItem>
                                        <asp:ListItem Text="30%" Value="30"></asp:ListItem>
                                        <asp:ListItem Text="40%" Value="40"></asp:ListItem>
                                        <asp:ListItem Text="50%" Value="50"></asp:ListItem>
                                        <asp:ListItem Text="60%" Value="60"></asp:ListItem>
                                        <asp:ListItem Text="70%" Value="70"></asp:ListItem>
                                        <asp:ListItem Text="80%" Value="80"></asp:ListItem>
                                        <asp:ListItem Text="90%" Value="90"></asp:ListItem>
                                        <asp:ListItem Text="100%" Value="100"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Lý do không hoàn thành / Báo cáo lỗi và sự cố
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLyDo" runat="server" TextMode="MultiLine" Rows="2" CssClass="form-control">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Một số đề xuất
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDeXuat" runat="server" TextMode="MultiLine" Rows="2" CssClass="form-control">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" height="10px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="cmdUpdate" runat="server" CssClass="btn blue" Text="Cập nhật" Width="75px"
                                        OnClick="cmdUpdate_Click" />
                                    <asp:Button ID="cmdAdd" runat="server" CssClass="btn green" Text="Thêm" Width="75px"
                                        OnClick="cmdAdd_Click" />
                                    <asp:Button ID="cmdDel" runat="server" CausesValidation="False" CssClass="btn dark"
                                        Text="Xóa" Width="75px" OnClick="cmdDel_Click" />
                                    <asp:Button ID="cmdEmpty" runat="server" CausesValidation="False" CssClass="btn black"
                                        Text="Hủy" Width="75px" OnClick="cmdEmpty_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
