<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KeHoachCBCNV.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.KeHoachThang.NhanVien.KeHoachCBCNV" %>
<%@ Import Namespace="VmgPortal.Library.Utilities" %>
<div class="row">
    <div class="col-md-12">
        <table width="100%" border="0" cellpadding="5" cellspacing="2">
            <tr>
                <td>
                    <asp:Button ID="btnLich" runat="server" CssClass="btn green" 
                        Text="Xem dưới dạng lịch" onclick="btnLich_Click" />
                </td>
            </tr>
            <tr>
                <td valign="top" class="InputBox" style="width: 100%;">
                    <table width="100%" border="0" cellpadding="5" cellspacing="2">
                        <tr>
                            <td class="textcenter">
                                Kết hoạch tháng của nhân viên
                                <asp:Label ID="lblName" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 15px">
                </td>
            </tr>
            <tr>
                <td valign="top" class="InputBox" colspan="2" style="width: 100%;">
                    <table width="100%" border="0" cellpadding="5" cellspacing="2">
                        <tr>
                            <td>
                                Chọn đợt đánh giá:
                            </td>
                            <td align="left" width="420px">
                                <asp:DropDownList AutoPostBack="true" CssClass="form-control" Width="300px" ID="dropDotDanhGia"
                                    runat="server" DataTextField="Ten" DataValueField="ID" OnSelectedIndexChanged="dropDotDanhGia_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td colspan="6" align="left">
                                <table width="100%" cellpadding="5" cellspacing="0">
                                    <tr>
                                        <td align="center">
                                            <b>CV thường xuyên</b>
                                        </td>
                                        <td align="center">
                                            <b>CV không thường xuyên</b>
                                        </td>
                                        <td align="center" id="tdCVPS" runat="server">
                                            <b>CV Phát sinh</b>
                                        </td>
                                        <td align="center">
                                            <b>Tổng % Công việc</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <b style="color: Blue;">
                                                <asp:Label ID="lblCVTX" runat="server" Font-Bold="true">34%</asp:Label></b>
                                        </td>
                                        <td align="center">
                                            <b style="color: Blue;">
                                                <asp:Label ID="lblCVKTX" runat="server" Font-Bold="true">34%</asp:Label></b>
                                        </td>
                                        <td align="center" id="tdCVPSValue" runat="server">
                                            <b style="color: Blue;">
                                                <asp:Label ID="lblCVPhatSinh" runat="server" Font-Bold="true"></asp:Label></b>
                                        </td>
                                        <td align="center">
                                            <b style="color: Blue;">
                                                <asp:Label ID="lblTotal" runat="server" Font-Bold="true">100%</asp:Label></b>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 15px" colspan="2">
                </td>
            </tr>
        </table>
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-reorder"></i>Công việc thường xuyên
                </div>
                <div class="tools">
                    <a href="" class="expand"></a>
                </div>
            </div>
            <div class="portlet-body form" style="display: none;">
                <div class="form-horizontal" role="form">
                    <div class="form-body">
                        <table id="TABLE1" border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                            <tr style="display: none">
                                <td>
                                    <asp:Label ID="lblStatusUpdate" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td style="height: 15px">
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td valign="top" class="InputBox" colspan="2" style="width: 100%;">
                                    <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td colspan="7" align="center">
                                                <asp:Button ID="btnSumit" runat="server" CssClass="solidButton" Height="40px" Text="Gửi kế hoạch"
                                                    OnClick="btnSumit_Click" />
                                                <asp:Button ID="btnYeuCauLamLaiKeHoach" runat="server" CssClass="solidButton" Height="40px"
                                                    Text="Yêu cầu làm lại kế hoạch" OnClick="btnYeuCauLamLaiKeHoach_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td style="height: 15px">
                                </td>
                            </tr>
                            <%--<tr>
                                <td colspan="2" valign="top" class="InputBox" style="width: 100%;">
                                    <b style="font-size: 14px; color: Red">1. Những công việc thường xuyên /thực hiện hàng
                                        tháng của Nhân sự</b>
                                </td>
                            </tr>--%>
                            <tr>
                                <td valign="top" colspan="2" class="InputBox" style="width: 100%;">
                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td>
                                                <table width="100%" cellpadding="5" cellspacing="0">
                                                    <tr>
                                                        <td width="150px">
                                                            • <b>Tên công việc:</b>
                                                        </td>
                                                        <td>
                                                            Những công việc được giao hoặc đầu mục công việc thực hiện
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            • <b>Tỷ trọng (%):</b>
                                                        </td>
                                                        <td>
                                                            Là % công sức và thời gian mà nhân sự dành cho mỗi công việc trong tổng thể: con
                                                            số này được đặt công thức tự động từ phần giao việc của trưởng bộ phận. Nhân sự
                                                            có thể nhìn thấy tổng khối lượng công việc của mình ở bên trên.
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            • <b>Cam kết:</b>
                                                        </td>
                                                        <td>
                                                            Kế hoạch thực hiện của nhân sự về số lương, chất lượng, tiến độ sẽ hoàn thành trong
                                                            tháng.
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            • <b>Bộ phận Hỗ trợ:</b>
                                                        </td>
                                                        <td>
                                                            Có thể chọn nhiều bộ phận mà mình cần sự hỗ trợ
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            • <b>Y/cầu hỗ trợ:</b>
                                                        </td>
                                                        <td>
                                                            Là yêu cầu của nhân sự cần sự hỗ trợ của các bộ phận khác để hoàn thành được đầu
                                                            mục công việc : ghi rõ thông tin cần bộ phận nào hỗ trợ gì
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="btnUpdateDiem1" runat="server" CssClass="btn green" Text="Cập nhật"
                                                    OnClick="btnUpdateDiem1_Click"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="dgrKhoiLuongCV1" runat="server" AutoGenerateColumns="False" BorderColor="#999999"
                                                    BorderStyle="solid" BorderWidth="1px" CellPadding="2" CssClass="table table-striped table-hover table-bordered dataTable"
                                                    Width="100%" AllowPaging="true" AllowSorting="True" PageSize="20" OnRowCommand="dgrKhoiLuongCV1_RowCommand"
                                                    OnRowEditing="dgrKhoiLuongCV1_RowEditing" OnRowDeleting="dgrKhoiLuongCV1_RowDeleting">
                                                    <AlternatingRowStyle CssClass="odd" />
                                                    <RowStyle CssClass="even" />
                                                    <HeaderStyle CssClass="sorting_disabled" ForeColor="Black" />
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="30px" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                                <asp:Label ID="txtIdCongViec" runat="server" Text='<%# Eval("IDCongViec") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Nhóm công việc" HeaderStyle-Width="200px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTenCVCha" runat="server" Text='<%# Eval("TenCVCha") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tên công việc" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderStyle-Width="250px">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTenCongViec" ReadOnly="true" Rows="5" TextMode="MultiLine" CssClass="form-control"
                                                                    runat="server" Text='<%# Eval("TenCongViec") %>' Style="text-align: left"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tỷ trọng (%)" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderStyle-Width="70px">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTyTrongCV" ReadOnly="true" CssClass="form-control" Width="70px"
                                                                    runat="server" Text='<%# Eval("TyTrongCV") %>' Style="text-align: center"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Số giờ" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtGLVCaNhan" ReadOnly="true" CssClass="form-control" Style="text-align: center"
                                                                    Width="70px" runat="server" Text='<%# Eval("SoGio") %>'>
                                                                </asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Ngày bắt đầu" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderStyle-Width="5%">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNgayBatDau" runat="server" Style="font-size: 12px" Text='<%# ConvertUtility.ToDateTime(Eval("NgayBatDau")).ToString("dd/MM/yyyy") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Ngày kết thúc" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderStyle-Width="5%">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNgayKetTHuc" runat="server" Style="font-size: 12px" Text='<%# ConvertUtility.ToDateTime(Eval("NgayKetThuc")).ToString("dd/MM/yyyy") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Cam kết" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="250px">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtSoLieuCamKet" Rows="5" ReadOnly="true" TextMode="MultiLine" CssClass="form-control"
                                                                    runat="server" Text='<%# Eval("SoLieuCamKet") %>' Style="text-align: left"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bộ phận hỗ trợ" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderStyle-Width="150px">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:ListBox Height="70px" CssClass="form-control" SelectionMode="Multiple" ID="dropBoPhanHoTro"
                                                                    runat="server" DataTextField="Ten" DataValueField="ID"></asp:ListBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Y/cầu hỗ trợ" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderStyle-Width="200px">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtYeuCauHoTro" Rows="5" TextMode="MultiLine" CssClass="form-control"
                                                                    runat="server" Text='<%# Eval("YeuCauHoTro") %>' Style="text-align: left"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Người cùng làm" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderStyle-Width="200px">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtNguoiThamGia" Rows="5" TextMode="MultiLine" CssClass="form-control"
                                                                    runat="server" Style="text-align: left"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="70px" Visible="false">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnDelete" runat="server" CssClass="btn dark" CommandName="delete"
                                                                    Text="Xóa" CommandArgument='<%# Eval("ID") %>'></asp:Button>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
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
</div>
<div class="row">
    <div class="col-md-12">
        <div class="portlet box green">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-reorder"></i>Công việc kế hoạch hành động phát sinh
                </div>
                <div class="tools">
                    <a href="" class="collapse"></a>
                </div>
            </div>
            <div class="portlet-body form">
                <div class="form-horizontal" role="form">
                    <div class="form-body">
                        <table width="100%" cellspacing="2" cellpadding="5">
                            <tr>
                                <td valign="top" class="InputBox" style="width: 100%;">
                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="btnUpdateDiem2" runat="server" CssClass="btn blue" Text="Cập nhật"
                                                    OnClick="btnUpdateDiem2_Click"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="dgrKhoiLuongCV2" runat="server" AutoGenerateColumns="False" BorderColor="#999999"
                                                    BorderStyle="solid" BorderWidth="1px" CellPadding="2" CssClass="table table-striped table-hover table-bordered dataTable"
                                                    Width="100%" AllowPaging="true" AllowSorting="True" PageSize="20" OnRowCommand="dgrKhoiLuongCV2_RowCommand"
                                                    OnRowEditing="dgrKhoiLuongCV2_RowEditing" OnRowDeleting="dgrKhoiLuongCV2_RowDeleting"
                                                    OnRowDataBound="dgrKhoiLuongCV2_RowDataBound">
                                                    <AlternatingRowStyle CssClass="odd" />
                                                    <RowStyle CssClass="even" />
                                                    <HeaderStyle CssClass="sorting_disabled" ForeColor="Black" />
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="30px" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                                <asp:Label ID="txtIdCongViec" runat="server" Text='<%# Eval("IDCongViec") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField  HeaderText="Nhóm CV" HeaderStyle-Width="200px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTenCVCha" runat="server" Text='<%# Eval("TenCVCha") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tên công việc" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderStyle-Width="250px">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTenCongViec" Rows="3" TextMode="MultiLine" CssClass="form-control"
                                                                    runat="server" Text='<%# Eval("TenCongViec") %>' Style="text-align: left"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false" HeaderText="Tỷ trọng (%)" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderStyle-Width="70px">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTyTrongCV" CssClass="form-control" Width="70px" runat="server"
                                                                    Text='<%# Eval("TyTrongCV") %>' Style="text-align: center"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Số giờ" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtGLVCaNhan" CssClass="form-control" Style="text-align: center"
                                                                    Width="70px" runat="server" Text='<%# Eval("SoGio") %>'>
                                                                </asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Ngày bắt đầu" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderStyle-Width="5%">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNgayBatDau" runat="server" Style="font-size: 12px" Text='<%# ConvertUtility.ToDateTime(Eval("NgayBatDau")).ToString("dd/MM/yyyy") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Ngày kết thúc" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderStyle-Width="5%">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNgayKetTHuc" runat="server" Style="font-size: 12px" Text='<%# ConvertUtility.ToDateTime(Eval("NgayKetThuc")).ToString("dd/MM/yyyy") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Cam kết" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="250px">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtSoLieuCamKet" Rows="3" TextMode="MultiLine" CssClass="form-control"
                                                                    runat="server" Text='<%# Eval("SoLieuCamKet") %>' Style="text-align: left"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bộ phận hỗ trợ" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderStyle-Width="150px">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:ListBox Height="70px" CssClass="form-control" SelectionMode="Multiple" ID="dropBoPhanHoTro"
                                                                    runat="server" DataTextField="Ten" DataValueField="ID"></asp:ListBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Y/cầu hỗ trợ" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderStyle-Width="200px">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtYeuCauHoTro" Rows="3" TextMode="MultiLine" CssClass="form-control"
                                                                    runat="server" Text='<%# Eval("YeuCauHoTro") %>' Style="text-align: left"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Người cùng làm" Visible="false" HeaderStyle-HorizontalAlign="Center"
                                                            HeaderStyle-Width="200px">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtNguoiThamGia" Rows="3" TextMode="MultiLine" CssClass="form-control"
                                                                    runat="server" Style="text-align: left"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="70px">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-xs dark" CommandName="delete"
                                                                    Text="Xóa" CommandArgument='<%# Eval("ID") %>'></asp:Button>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="InputBox">
                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td style="width: 150px;">
                                                <strong>Tên công việc</strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTenCongViec2" runat="server" Width="350px" TextMode="MultiLine"
                                                    Rows="2" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td>
                                                <strong>Tỷ trọng (%)</strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTyTrongCongViec2" runat="server" CssClass="form-control" Width="50px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Số giờ</strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSoGio" CssClass="form-control" runat="server" Width="50px">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Từ ngày</strong>
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
                                                <strong>Tuần làm việc</strong>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTuanLV" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Cam kết</strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSoLieuCamKet2" runat="server" Width="350px" TextMode="MultiLine"
                                                    Rows="2" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Bộ phận hỗ trợ</strong>
                                            </td>
                                            <td>
                                                <asp:ListBox ID="dropBoPhanHoTro" Height="100px" Width="350px" CssClass="form-control"
                                                    SelectionMode="Multiple" runat="server" DataTextField="Ten" DataValueField="ID">
                                                </asp:ListBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Y/cầu hỗ trợ</strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtYeuCauCanHoTro2" runat="server" Width="350px" TextMode="MultiLine"
                                                    Rows="5" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnThemMoi2" runat="server" CssClass="btn green" Text="Thêm mới"
                                                    OnClick="btnThemMoi2_Click" />
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
</div>
