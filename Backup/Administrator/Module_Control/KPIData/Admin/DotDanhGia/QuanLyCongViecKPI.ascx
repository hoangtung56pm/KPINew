<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuanLyCongViecKPI.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.DotDanhGia.QuanLyCongViecKPI" %>
<%@ Import Namespace="VmgPortal.Library.Utilities" %>
<%@ Register Assembly="VmgPortal.FilePickerControl" Namespace="VmgPortal.FilePickerControl"
    TagPrefix="cc2" %>
<%@ Register Assembly="VmgPortal.Library" Namespace="VmgPortal.Library.Controls"
    TagPrefix="cc1" %>
<div class="row">
    <div class="col-md-4" style="padding-left: 25px; padding-top: 10px;">
        <div class="portlet box green">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-reorder"></i>Danh sách công việc
                </div>
                <div class="tools">
                    <a href="" class="collapse"></a>
                </div>
            </div>
            <div class="portlet-body form">
                <div class="form-horizontal" role="form">
                    <div class="form-body">
                        <table width="100%" cellpadding="2" cellspacing="0">
                            <tr>
                                <td>
                                    Đợt đánh giá:
                                </td>
                                <td>
                                    <asp:DropDownList AutoPostBack="true" ID="dropDotDanhGia" runat="server" CssClass="form-control"
                                        DataTextField="Ten" DataValueField="ID" OnSelectedIndexChanged="dropDotDanhGia_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Bộ phận:
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropTrungTam" runat="server" DataTextField="Ten" DataValueField="ID"
                                        CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="dropTrungTam_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <%--<tr>
                                <td>
                                    Phòng ban:
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropPhongBan" runat="server" DataTextField="Ten" DataValueField="ID"
                                        CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="dropPhongBan_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>--%>
                            <tr>
                                <td colspan="2">
                                    <asp:ListBox ID="lstCongViec" runat="server" AutoPostBack="True" Rows="40" CssClass="form-control"
                                        OnSelectedIndexChanged="lstCongViec_SelectedIndexChanged"></asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <table width="98%" cellpadding="5" cellspacing="0" style="border: 1px solid #dedede">
                                        <tr>
                                            <td>
                                                <b>Export công việc ra excel</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnExport" Text="Export to excel" CssClass="btn green" runat="server"
                                                    OnClick="btnExport_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:HyperLink ID="hplDownload" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <table width="98%" cellpadding="5" cellspacing="0" style="border: 1px solid #dedede">
                                        <tr>
                                            <td>
                                                <b>Xóa toàn bộ công việc hiện tại</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnDelete" Text="Xóa toàn bộ công việc" CssClass="btn dark" runat="server"
                                                    OnClick="btnDelete_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <table width="98%" cellpadding="5" cellspacing="0" style="border: 1px solid #dedede">
                                        <tr>
                                            <td>
                                                <b>Copy công việc tháng được chọn cho tháng hiện tại</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList Width="250px" CssClass="form-control" AutoPostBack="true" ID="dropDotDanhGiaCopy"
                                                    runat="server" DataTextField="Ten" DataValueField="ID" OnSelectedIndexChanged="dropDotDanhGiaCopy_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnLayCongViecThangTruoc" Text="Cập nhật công việc từ tháng trước"
                                                    CssClass="btn blue" runat="server" OnClick="btnLayCongViecThangTruoc_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <table width="98%" cellpadding="5" cellspacing="0" style="border: 1px solid #dedede">
                                        <tr>
                                            <td>
                                                <b>Import dữ liệu từ file excel định dạng Excel 2003</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                File mẫu:
                                                <asp:HyperLink ID="HyperLink1" runat="server" Text="Click vào tải file mẫu" NavigateUrl="http://kpi.vmgmedia.vn/Template/FileMau.xls"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:FileUpload ID="fileImport" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkDeleteAll" Text="Xóa hết dữ liệu cũ" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnImport" Text="Import" CssClass="btn red" runat="server" OnClick="btnImport_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-8" style="padding-right: 25px; padding-top: 10px;">
        <div class="portlet box blue ">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-reorder"></i>Thêm mới
                </div>
                <div class="tools">
                    <a href="" class="collapse"></a>
                </div>
            </div>
            <div class="portlet-body form">
                <div class="form-horizontal" role="form">
                    <div class="form-body">
                        <table id="Table1" class="NavBtn" width="100%">
                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Button ID="btnXoaAll" runat="server" OnClientClick="return confirm('Bạn có chắc chắn xóa các bản ghi được chọn ? Toàn bộ các dữ liệu liên quan đến công việc này sẽ bị xóa.')" Text="Xóa các bản ghi được chọn" CssClass="btn dark"
                                        OnClick="btnXoaAll_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" height="10">
                                    <asp:Label ID="lblStatusUpdate" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
                                    <cc1:GridView ID="dgrCongViec" runat="server" AutoGenerateColumns="False" ShowFooter="false"
                                        BorderColor="Gainsboro" BorderStyle="solid" BorderWidth="1px" CaptionAlign="Top"
                                        CellPadding="5" OnRowCommand="dgrCongViec_RowCommand" OnRowDataBound="dgrCongViec_RowDataBound"
                                        Width="100%" OnRowDeleting="dgrCongViec_RowDeleting" CssClass="table table-striped table-hover table-bordered dataTable">
                                        <AlternatingRowStyle CssClass="odd" />
                                        <RowStyle CssClass="even" />
                                        <HeaderStyle CssClass="sorting_disabled" ForeColor="Black" />
                                        <Columns>
                                          <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="5%">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkCheck" runat="server"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="ID" DataField="ID" Visible="true" HeaderStyle-Width="5%" />
                                            <asp:TemplateField HeaderText="Tên công việc" HeaderStyle-Width="40%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTen" runat="server" Text='<%# Eval("Ten") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ngày bắt đầu" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="15%">
                                                <FooterStyle Font-Bold="true" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNgayBatDau" runat="server" Text='<%# ConvertUtility.ToDateTime(Eval("NgayBatDau")).ToString("dd/MM/yyyy") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ngày kết thúc" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="15%">
                                                <FooterStyle Font-Bold="true" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNgayKetThuc" runat="server" Text='<%# ConvertUtility.ToDateTime(Eval("NgayKetThuc")).ToString("dd/MM/yyyy") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Cam kết thực hiện" DataField="KeHoach" HeaderStyle-Width="20%" />
                                            <asp:TemplateField HeaderText="Thao tác" HeaderStyle-Width="10%">
                                                <HeaderTemplate>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Button ID="cmdDelete" CommandArgument='<%# Eval("ID") %>' runat="server" Width="60px"
                                                        Text="Xóa" CommandName="delete" CssClass="btn btn-xs dark"></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </cc1:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td width="150px">
                                    Mã nhóm công việc
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropMaNhom" Width="350px" CssClass="form-control" runat="server"
                                        DataTextField="TenNhomViec" DataValueField="ID">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tên công việc
                                </td>
                                <td>
                                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server" TextMode="MultiLine"
                                        Rows="3" Width="350"></asp:TextBox><asp:TextBox ID="txtID" runat="server" Enabled="False"
                                            Visible="False" Width="10px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Trạng thái
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropTrangThai" CssClass="form-control" runat="server" Width="350px">
                                        <asp:ListItem Text="-------------Chọn------------" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Hoàn thành" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Triển khai" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Chưa hoàn thành" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Chuyển sang giai đoạn khác" Value="4"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Parent
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropCongViecKPI" CssClass="form-control" runat="server" Width="350px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td>
                                    Tỷ trọng
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTyTrong" CssClass="form-control" runat="server" Width="50">
                                    </asp:TextBox>%
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td>
                                    Số giờ
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSoGio" CssClass="form-control" runat="server" Width="50">
                                    </asp:TextBox>(Nếu bạn nhập số giờ thì tỷ trọng tự động được tính theo số giờ làm
                                    việc, nếu nhập tỷ trọng rồi thì không cần nhập số giờ nữa)
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Từ ngày
                                </td>
                                <td>
                                    <div class="input-group input-large date-picker input-daterange" data-date="10/11/2012"
                                        data-date-format="mm/dd/yyyy">
                                        <asp:TextBox ID="dtFrom" CssClass="form-control" runat="server"></asp:TextBox>
                                        <span class="input-group-addon">đến</span>
                                        <asp:TextBox ID="dtTo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tuần làm việc
                                </td>
                                <td>
                                    <asp:Label ID="lblTuanLV" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <%--<tr style="display: none">
                                <td>
                                    Phòng ban
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropPhong" CssClass="form-control" runat="server" DataTextField="Ten"
                                        DataValueField="ID" Width="350px">
                                    </asp:DropDownList>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    Cam kết thực hiện
                                </td>
                                <td>
                                    <asp:TextBox ID="txtKeHoach" CssClass="form-control" runat="server" TextMode="MultiLine"
                                        Rows="3" Width="350">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td>
                                    Đơn vị đo
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDonViDo" CssClass="form-control" runat="server" Width="100px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    KPI bộ phận
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropKPIBoPhan" Width="350px" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="Không chọn" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Chọn" Value="1" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                    (Nếu bạn chọn "Chọn", công việc này sẽ được đưa bảng tổng hợp để gửi lên CEO trong
                                    phần kế hoạch và đánh giá tháng. Nếu bạn chọn "Không chọn": công việc này được quản
                                    lý trong bộ phận.)
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 30px">
                                    &nbsp;&nbsp;
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
                                    <asp:Button ID="cmdEmpty" runat="server" CausesValidation="False" CssClass="btn grey"
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
