<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThongTinMoRong.ascx.cs"
    Inherits="VmgPortal.Administrator.Users.ThongTinMoRong" %>
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
                    <b >Số Điện Thoại Liên Hệ</b>
                </label>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-12">
                    <b >Chứng Minh Nhân Dân</b>
                </label>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-12">
                    <b >Thông tin Tài Khoản Ngân Hàng</b>
                </label>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Mobile
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Số CMND
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtSoCMND" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Số TK ngân hàng
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtSoTKNH" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Home
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtHome" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Ngày cấp
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNgayCapCMND" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Ngân hàng
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNganHang" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Nới cấp
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNoiCapCMND" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Chi nhánh
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtChiNhanh" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-12">
                    <b >Thông tin Email</b>
                </label>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-12">
                    <b >Thông tin hộ chiếu</b>
                </label>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                 <label class="control-label col-md-12">
                    <b >Mã số thuế cá nhân</b>
                </label>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">Email VMG
                </label>
                <div class="col-md-8">
                    <p class="form-control-static"><asp:TextBox ID="txtVmgEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">Số hộ chiếu
                </label>
                <div class="col-md-8">
                    <p class="form-control-static"><asp:TextBox ID="txtSoHoChieu" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">Mã số
                </label>
                <div class="col-md-8">
                    <p class="form-control-static"><asp:TextBox ID="txtMaSoThueCaNhan" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">Email cá nhân
                </label>
                <div class="col-md-8">
                    <p class="form-control-static"><asp:TextBox ID="txtEmailCaNhan" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">Ngày cấp
                </label>
                <div class="col-md-8">
                    <p class="form-control-static"><asp:TextBox ID="txtNgayCapHoChieu" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">Nơi cấp
                </label>
                <div class="col-md-8">
                    <p class="form-control-static"><asp:TextBox ID="txtNoiCapHoChieu" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
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

