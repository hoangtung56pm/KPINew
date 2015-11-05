<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HDLDBatDauGH1GH2.ascx.cs"
    Inherits="VmgPortal.Administrator.Users.HDLDBatDauGH1GH2" %>
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
                    <b>HỢP ĐỒNG LAO ĐỘNG</b>
                </label>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-12">
                    <b>HỢP ĐỒNG LAO ĐỘNG (Gia Hạn 1)</b>
                </label>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-12">
                    <b>HỢP ĐỒNG LAO ĐỘNG (Gia Hạn 2)</b>
                </label>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Số Hợp đồng
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtSoHopDong" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Ngày ký gia hạn
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNgayKyGiaHan1" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Ngày ký gia hạn
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNgayKyGiaHan2" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Người ký Hợp đồng
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNguoiKyHopDong" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Người ký gia hạn
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNguoiKyGiaHan1" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Người ký gia hạn
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNguoiKyGiaHan2" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Ngày ký HĐ
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNgayKyHopDong" runat="server" CssClass="form-control"></asp:TextBox>
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
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Ngày hiệu lực
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNgayHieuLuc" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Ngày hiệu lực
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
                    Ngày hiệu lực
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNgayHieuLuc2" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Ngày hết hạn
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNgayHetHan" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Ngày hết hạn
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNgayHetHan1" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Ngày hết hạn
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNgayHetHan2" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Loại Hợp đồng
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                       <asp:TextBox ID="txtLoaiHopDong" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Thời hạn
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                       <asp:TextBox ID="txtThoiHan1" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Thời hạn
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                       <asp:TextBox ID="txtThoiHan2" runat="server" CssClass="form-control"></asp:TextBox>
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
