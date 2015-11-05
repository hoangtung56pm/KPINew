<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BaoCaoTyTrongCVCuaNhanVien.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.BaoCao.XepLoaiThang.NhanVien.BaoCaoTyTrongCVCuaNhanVien" %>
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
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td class="InputBox" colspan="2" align="center">
                        <asp:Panel ID="pnSearch" runat="server" DefaultButton="btnSearch">
                            <table cellpadding="4" cellspacing="0" style="width: 50%">
                                <tr>
                                    <td width="100px">
                                        <strong>Đợt đánh giá:</strong>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control" ID="dropDotDanhGia" DataTextField="Ten"
                                            DataValueField="ID" runat="server" Width="300px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <strong>Bộ phận:</strong>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control" ID="dropTrungTam" runat="server" DataTextField="Ten"
                                            DataValueField="ID" AutoPostBack="True" Width="300px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td>
                                        <strong>Phòng ban:</strong>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control" ID="dropPhongBan" runat="server" DataTextField="Ten"
                                            DataValueField="ID" AutoPostBack="True" Width="300px" OnSelectedIndexChanged="dropPhongBan_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn blue" Text="Tìm kiếm" OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="dgrBaoCao" AutoGenerateColumns="false" ShowFooter="true" runat="server"
                            BorderColor="Gainsboro" BorderStyle="solid" BorderWidth="1px" CellPadding="5"
                            CssClass="table table-striped table-hover table-bordered dataTable" Width="100%"
                            PageSize="20">
                            <AlternatingRowStyle CssClass="odd" />
                            <RowStyle CssClass="even" />
                            <HeaderStyle CssClass="sorting_disabled" ForeColor="Black" />
                            <Columns>
                                <asp:TemplateField HeaderText="Tên" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" Width="80px" />
                                    <FooterStyle Font-Bold="true" HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblHoTen" runat="server" Text='<%# Eval("HoTen") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chức Danh" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" Width="80px" />
                                    <FooterStyle Font-Bold="true" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblChucDanh" runat="server" Text='<%# Eval("ChucVu") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Thời gian làm công việc thường xuyên" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                    <FooterStyle Font-Bold="true" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTGCVThuongXuyen" runat="server" Text='<%# Eval("TTCVThuongXuyen") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Thời gian làm công việc kế hoạch tháng" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                    <FooterStyle Font-Bold="true" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTGCVKeHoachThang" runat="server" Text='<%# Eval("TTCVKeHoachThang") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Thời gian làm công việc phát sinh" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                    <FooterStyle Font-Bold="true" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTGCVPhatSinh" runat="server" Text='<%# Eval("TTCVPhatSinh") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Thời gian còn lại" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                    <FooterStyle Font-Bold="true" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTGConLai" runat="server" Text='<%# Eval("TTConLai") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField Visible="false" HeaderText="Tỷ trọng so với bộ phận" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                    <FooterStyle Font-Bold="true" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTTBoPhan" runat="server" Text='<%# Eval("TTSoVoiBoPhan") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
