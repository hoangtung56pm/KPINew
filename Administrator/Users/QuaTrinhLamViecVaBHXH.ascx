<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuaTrinhLamViecVaBHXH.ascx.cs"
    Inherits="VmgPortal.Administrator.Users.QuaTrinhLamViecVaBHXH" %>
<div class="form-body">
    <div class="row">
        <div class="col-md-12">
            <label class="control-label col-md-12">
                <asp:Label ID="lblUpdateStatus" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-12">
                            <b>Quá trình làm việc trước đây</b>
                        </label>
                    </div>
                </div>
            </div>
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-4">
                            Công ty/tổ chức
                        </label>
                        <div class="col-md-8">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtCongty" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-4">
                            Chức danh
                        </label>
                        <div class="col-md-8">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtChucDanh" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-4">
                            Lý do chuyển đổi
                        </label>
                        <div class="col-md-8">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtLyDo" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-12">
                            <b>BHXH</b>
                        </label>
                    </div>
                </div>
            </div>
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Đóng BHXH từ</label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtBHXDDongTu" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Số sổ BHXH
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtSoSoBHXH" runat="server" CssClass="form-control"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label col-md-5">
                            Ghi chú
                        </label>
                        <div class="col-md-7">
                            <p class="form-control-static">
                                <asp:TextBox ID="txtGhiChu" TextMode="MultiLine" Rows="2" runat="server" CssClass="form-control"></asp:TextBox>
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
