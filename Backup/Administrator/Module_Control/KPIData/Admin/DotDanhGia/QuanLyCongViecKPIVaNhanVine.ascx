<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuanLyCongViecKPIVaNhanVine.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.DotDanhGia.QuanLyCongViecKPIVaNhanVine" %>
<%@ Import Namespace="VmgPortal.Library.Utilities" %>
<table border="0" cellpadding="5" cellspacing="0" style="width: 100%">
    <tr>
        <td height="10">
        </td>
    </tr>
    <tr>
        <td >
            <table class="InputBox" border="0" cellpadding="5" cellspacing="0" width="100%">
                <tr>
                    <td align="center">
                        <b>Tỷ trọng công việc thường xuyên</b>
                    </td>
                    <td align="center">
                        <b>Tỷ trọng công việc kế hoạch tháng</b>
                    </td>
                    <td align="center">
                        <b>Tỷ trọng công việc phát sinh</b>
                    </td>
                    <td align="center">
                        <b>Tổng tỷ trọng</b>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblTyTrongCVThuongXuyen" Font-Bold="true" ForeColor="Blue" runat="server"></asp:Label>
                    </td>
                    <td align="center">
                        <asp:Label ID="lblTyTrongCVKeHoachThang"  runat="server"></asp:Label>
                    </td>
                    <td align="center">
                        <asp:Label ID="lblTyTrongCVPhatSinh" runat="server"></asp:Label>
                    </td>
                    <td align="center">
                        <asp:Label ID="lblTongTyTrong" Font-Bold="true" ForeColor="Blue" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td  align="center">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="dgrNhanVienCVTX" AutoGenerateColumns="false" ShowFooter="true"
                            runat="server" BorderColor="Gainsboro" BorderStyle="solid" BorderWidth="1px"
                            CellPadding="5" CssClass="table table-striped table-hover table-bordered dataTable"
                            Width="100%" PageSize="50" OnRowDataBound="dgrNhanVienCVTX_RowDataBound" OnRowCommand="dgrNhanVienCVTX_RowCommand">
                            <AlternatingRowStyle CssClass="odd" />
                            <RowStyle CssClass="even" />
                            <HeaderStyle CssClass="sorting_disabled" ForeColor="Black" />
                            <FooterStyle BackColor="#f9f9f9" />
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nhóm CV" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTenCVCha" runat="server" Text='<%# Eval("TenCVCha") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tên công việc" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTenCV" runat="server" Text='<%# Eval("Ten") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTongTyTrong" Font-Bold="true" runat="server" Text="Tổng tỷ trọng"></asp:Label>
                                    </FooterTemplate>
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
                                <asp:TemplateField HeaderText="Kế hoạch" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblKeHoach" runat="server" Text='<%# Eval("KeHoach") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <FooterStyle HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        <asp:Button ID="btnTyTrongCaNhan" CommandName="TyTrongCaNhan"  runat="server" Text="Câp nhật Tỷ Trọng"
                                            CssClass="btn blue" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTyTrongCaNhan" CssClass="form-control" Style="text-align: center"
                                            Width="70px" runat="server" Text='<%# Eval("TyTrong") %>'>
                                        </asp:TextBox>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTongCaNhan" Font-Bold="true" ForeColor="Blue" runat="server"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <FooterStyle HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        <asp:Button ID="btnGioLamViec" CommandName="GioLamViec" runat="server" Text="Cập nhật Giờ LV"
                                            CssClass="btn green" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGLVCaNhan" CssClass="form-control" Style="text-align: center"
                                            Width="70px" runat="server" Text='<%# Eval("SoGio") %>'>
                                        </asp:TextBox>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblGLVTongCaNhan" Font-Bold="true" ForeColor="Blue" runat="server"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table width="100%" cellpadding="5" cellspacing="0">
                            <tr>
                                <td>
                                    <b>Trung tâm: </b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropTrungTam" runat="server" DataTextField="Ten" DataValueField="ID"
                                        AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="dropTrungTam_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                           <%-- <tr style="display: none">
                                <td>
                                    <b>Phòng ban: </b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropPhongBan" runat="server" DataTextField="Ten" DataValueField="ID"
                                        AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="dropPhongBan_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>--%>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td  valign="top" width="300px">
                        <asp:ListBox ID="lstNhanVien" runat="server" CssClass="form-control" AutoPostBack="true"
                            DataTextField="Username" DataValueField="UserID" Height="480px" Width="300px"
                            OnSelectedIndexChanged="lstNhanVien_SelectedIndexChanged"></asp:ListBox>
                    </td>
                    <td>
                    </td>
                    <td  valign="top">
                        <table width="100%" cellpadding="5" cellspacing="0">
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                Chọn đợt đánh giá:
                                            </td>
                                            <td>
                                                <asp:DropDownList AutoPostBack="true" CssClass="form-control" Width="320px" ID="dropDotDanhGia"
                                                    runat="server" DataTextField="Ten" DataValueField="ID" OnSelectedIndexChanged="dropDotDanhGia_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" cellpadding="0" cellspacing="3">
                                        <tr>
                                            <td width="350px">
                                                <b>Danh sách công việc</b><br />
                                                <asp:ListBox ID="lstCongViec" CssClass="form-control" runat="server" DataTextField="Ten"
                                                    DataValueField="ID" Height="425px" SelectionMode="Multiple"></asp:ListBox>
                                                <br />
                                                <b>Công việc "màu đỏ" là chưa có người thực hiện</b>
                                            </td>
                                            <td width="60px" align="center">
                                                <asp:Button ID="btnAdd" runat="server" CssClass="btn blue" Text=" >>> " OnClick="btnAdd_Click" /><br />
                                                <br />
                                                <asp:Button ID="btnDelete" runat="server" CssClass="btn dark" Text=" <<< " OnClick="btnDelete_Click" />
                                            </td>
                                            <td width="350px">
                                                <b>Công việc được giao</b>&nbsp;&nbsp;<asp:Button ID="btnXem" CssClass="btn btn-xs green"
                                                    runat="server" Text="Xem" OnClick="btnXem_Click" /><br />
                                                <asp:ListBox ID="lstCongViecDuocGiao" CssClass="form-control" runat="server" DataTextField="Ten"
                                                    DataValueField="ID" Height="425px" SelectionMode="Multiple"></asp:ListBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
