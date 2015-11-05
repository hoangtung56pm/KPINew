<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DotDanhGiaCBCNVChiTiet.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.DotDanhGia.DotDanhGiaCBCNVChiTiet" %>
<div class="portlet box blue">
    <div class="portlet-title">
        <div class="caption">
            <i class="icon-reorder"></i>Chọn nhân viên vào đợt đánh giá
        </div>
        <div class="tools">
            <a class="collapse" href="javascript:;"></a>
            <%--  <a class="config" data-toggle="modal"
                href="#portlet-config"></a><a class="reload" href="javascript:;"></a><a class="remove"
                    href="javascript:;"></a>--%>
        </div>
    </div>
    <div class="portlet-body">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td height="10">
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table border="0" cellpadding="5" cellspacing="0">
                        <tr>
                            <td style="height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="left">
                                <asp:Label ID="lblDotDanhGia" runat="server" Text="Đợt đánh giá:" Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblDotDanhGiaName" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                            <td>
                                <b>Trung tâm: </b>
                            </td>
                            <td>
                                <asp:DropDownList ID="dropPortal" Visible="false" runat="server" DataTextField="Portal_Name"
                                    DataValueField="PortalID" AutoPostBack="True" meta:resourcekey="dropPortalResource1">
                                </asp:DropDownList>
                                <asp:DropDownList ID="dropTrungTam" CssClass="form-control" runat="server" DataTextField="Ten"
                                    DataValueField="ID" AutoPostBack="True" Width="200px" OnSelectedIndexChanged="dropTrungTam_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMember" runat="server" Text="Nhân viên trong đợt đánh giá" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="width: 10px;">
                            </td>
                            <td>
                                <asp:Label ID="lblList" runat="server" Text="Danh sách nhân viên" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td class="InputBox">
                                <asp:ListBox ID="lstNhanVienInDotDanhGia" CssClass="form-control" runat="server"
                                    DataTextField="Username" DataValueField="UserID" Height="425px" SelectionMode="Multiple"
                                    Width="350px"></asp:ListBox>
                            </td>
                            <td align="center" style="width: 10px;">
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn green" OnClick="btnAdd_Click"
                                    Text="<<"  meta:resourcekey="btnAddResource1" /><br />
                                <br />
                                <asp:Button ID="btnRemove" runat="server" CssClass="btn dark" OnClick="btnRemove_Click"
                                    Text=">>"  meta:resourcekey="btnRemoveResource1" />
                            </td>
                            <td class="InputBox" colspan="2">
                                <asp:ListBox ID="lstNhanVien" runat="server" CssClass="form-control" DataTextField="Username"
                                    DataValueField="UserID" Height="425px" SelectionMode="Multiple" Width="350px">
                                </asp:ListBox>
                            </td>
                            
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</div>
