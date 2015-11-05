<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuanLyNhanVienTheoNDG.ascx.cs"
    Inherits="VmgPortal.Modules.KPIData.Admin.DotDanhGia.QuanLyNhanVienTheoNDG" %>
<div class="portlet box blue">
    <div class="portlet-title">
        <div class="caption">
            <i class="icon-reorder"></i>Chọn người đánh giá nhân viên
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
                <td align="center">
                    <table border="0" cellpadding="5" cellspacing="0">
                        
                        <tr>
                            <td colspan="2">
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <b>Đợt đánh giá:</b>
                                        </td>
                                        <td>
                                            <asp:DropDownList AutoPostBack="true" CssClass="form-control" Width="250px" ID="dropDotDanhGia"
                                                runat="server" DataTextField="Ten" DataValueField="ID" OnSelectedIndexChanged="dropDotDanhGia_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Trung tâm: </b>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="dropTrungTam" CssClass="form-control" runat="server" DataTextField="Ten"
                                                DataValueField="ID" AutoPostBack="True" Width="250px" OnSelectedIndexChanged="dropTrungTam_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>PT đánh giá: </b>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="dropNhanVien" CssClass="form-control" runat="server" DataTextField="Ten"
                                                DataValueField="ID" AutoPostBack="True" Width="250px" OnSelectedIndexChanged="dropNhanVien_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                      
                        <tr>
                            <td>
                                <asp:Label ID="lblMember" runat="server" Text="Nhân viên theo người đánh giá" Font-Bold="True"></asp:Label>
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
                            <td class="InputBox">
                                <asp:ListBox ID="lstNhanVien" CssClass="form-control" runat="server" DataTextField="Username"
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
