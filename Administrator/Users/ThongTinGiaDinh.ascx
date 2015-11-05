<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThongTinGiaDinh.ascx.cs"
    Inherits="VmgPortal.Administrator.Users.ThongTinGiaDinh" %>
<div class="form-body">
    <div class="row">
        <div class="col-md-12">
            <label class="control-label col-md-12">
                <asp:Label ID="lblUpdateStatus" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div >
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Họ tên Chồng/Vợ
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtHoTenVoChong" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div >
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Năm sinh Chồng/Vợ
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtNamSinhVoChong" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Nghề nghiệp/Nơi công tác
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtNgheNghiepNoiCongTac" TextMode="MultiLine" Rows="2" runat="server"
                                    CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Họ tên Con
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtHoTenCon" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Năm sinh con
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtNamSinhCon" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div >
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Giới tính
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtGioiTinhCon" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Người liên hệ trong trường hợp khẩn cấp
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtNguoiLienHe" TextMode="MultiLine" Height="150px" runat="server"
                                    CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
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
