<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CacDieuChinhNhanSu.ascx.cs"
    Inherits="VmgPortal.Administrator.Users.CacDieuChinhNhanSu" %>
<div class="form-body">
    <div class="row">
        <div class="col-md-12">
            <label class="control-label col-md-12">
                <asp:Label ID="lblUpdateStatus" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-12">
                    <b>Thay đổi 1</b>
                </label>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-12">
                    <b>Thay đổi 2</b>
                </label>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-12">
                    <b>Thay đổi 3</b>
                </label>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    QĐ số
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtQuyetDinhSo1" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    QĐ số
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtQuyetDinhSo2" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    QĐ số
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtQuyetDinhSo3" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Ngày
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNgay1" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Ngày
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNgay2" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Ngày
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNgay3" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Ngày h/lực
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNgayHieuLuc1" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Ngày h/lực
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNgayHieuLuc2" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Ngày h/lực
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNgayHieuLuc3" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Chi tiết điều chỉnh
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtChiTietDieuChinh1" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Chi tiết điều chỉnh
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtChiTietDieuChinh2" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Chi tiết điều chỉnh
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtChiTietDieuChinh3" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="form-actions fluid">
    <div class="row">
        <div class="col-md-12">
            <div class="col-md-offset-5 col-md-7">
                <asp:Button ID="btnUpdate" CausesValidation="false" runat="server" CssClass="btn green" Text="Cập  nhật" OnClick="btnUpdate_Click" />
                <button class="btn default" type="button">
                    Hủy</button>
            </div>
        </div>
    </div>
</div>
