<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HocVanKhenThuongToChuc.ascx.cs"
    Inherits="VmgPortal.Administrator.Users.HocVanKhenThuongToChuc" %>
<div class="form-body">
    <div class="row">
        <div class="col-md-12">
            <label class="control-label col-md-12">
                <asp:Label ID="lblUpdateStatus" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-12">
                            <b>Học vấn</b>
                        </label>
                    </div>
                </div>
            </div>
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Bằng cấp
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtBangCap" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Nơi đào tạo
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtNoiDaoTao" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Chuyên ngành
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtChuyenNganh" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Các khóa học khác
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtCacKhoaHocKhac" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Ngoại ngữ
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtNgoaiNgu" runat="server" CssClass="form-control"></asp:TextBox>
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
                        <label class="control-label col-md-12">
                            <b>Thành viên Tổ chức, đoàn thể, hiệp hội</b>
                        </label>
                    </div>
                </div>
            </div>
             <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Tổ chức/đoàn thể
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtToChucDoanThe" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Ngày gia nhập
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtNgayGiaNhap" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
             <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Nơi kết nạp
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtNoiKetNap" TextMode="MultiLine" Rows="2" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
             <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-12">
                            <b>Khen Thưởng</b>
                        </label>
                    </div>
                </div>
            </div>
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">Giải thưởng</label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtGiaiThuong" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Tổ chức trao thưởng
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtToChucTraoThuong" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
             <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Năm trao thưởng
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtNamTraoThuong" runat="server" CssClass="form-control"></asp:TextBox>
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
