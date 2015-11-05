<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LyLichCaNhan.ascx.cs"
    Inherits="VmgPortal.Administrator.Users.LyLichCaNhan" %>
<div class="form-body">
    <div class="row">
        <div class="col-md-12">
            <label class="control-label col-md-12">
                <asp:Label ID="lblUpdateStatus" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></label></div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Tên truy cập</label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server"
                            ControlToValidate="txtUsername" ErrorMessage="Chưa nhập tên truy cập"></asp:RequiredFieldValidator></p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Mã số nhân viên
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtMaSo" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Nguyên quán
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNguyenQuan" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group" style="display:none">
                <label class="control-label col-md-4">
                    Tên hiển thị</label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtDisplayName" runat="server" CssClass="form-control"></asp:TextBox></p>
                </div>
            </div>
             <div class="form-group" runat="server" id="divMK">
                <label class="control-label col-md-4">
                    Mật khẩu</label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server"
                            ControlToValidate="txtPassword" ErrorMessage="Chưa nhập mật khẩu"></asp:RequiredFieldValidator></p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Họ tên
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Quốc tịch
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtQuocTich" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
           <div class="form-group" runat="server" id="divXNMK">
                <label class="control-label col-md-4">
                    Xác nhận MK</label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" Display="Dynamic" runat="server" ControlToCompare="txtPassword"
                            ControlToValidate="txtPasswordConfirm" ErrorMessage="Mật khẩu ko đúng"></asp:CompareValidator></p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Ngày sinh
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNgaySinh" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Nơi Sinh
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtNoiSinh" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Là Super Admin
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:Panel ID="pnlSuperadmin" runat="server" Width="100%">
                            <asp:CheckBox ID="chkIsSuperAdmin" runat="server" /></asp:Panel>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Giới tính
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:DropDownList ID="dropGioiTinh" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Nam" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Nữ" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Tôn giáo
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtTonGiao" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Là Admin
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:Panel ID="pnlAdmin" runat="server" Width="100%">
                            <asp:CheckBox ID="chkIsAdmin" runat="server" Font-Bold="True" /></asp:Panel>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Chức vụ
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:DropDownList ID="dropChucVu" runat="server" CssClass="form-control" DataTextField="Ten"
                            DataValueField="ID">
                        </asp:DropDownList>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Dân tộc
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtDanToc" runat="server" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Bộ phận LV
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:DropDownList ID="dropTrungTam" CssClass="form-control" AutoPostBack="true" runat="server"
                            DataTextField="Ten" DataValueField="ID" OnSelectedIndexChanged="dropTrungTam_SelectedIndexChanged">
                        </asp:DropDownList>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Trạng thái
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:DropDownList ID="dropTrangThai" CssClass="form-control" runat="server">
                            <asp:ListItem Text="Nghỉ việc" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Chính thức" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Thời vụ" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Thử việc" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Nghỉ chế độ" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Đào tạo" Value="5"></asp:ListItem>
                            <asp:ListItem Text="CTV" Value="6"></asp:ListItem>
                        </asp:DropDownList>
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
                    Phòng/Ban
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:DropDownList ID="dropPhong" CssClass="form-control" runat="server" DataTextField="Ten"
                            DataValueField="ID">
                        </asp:DropDownList>
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
                    Địa chỉ thường trú
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox TextMode="MultiLine" Rows="1" ID="txtDiaChiThuongChu" runat="server"
                            CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-md-4">
                    Địa chỉ tạm trú
                </label>
                <div class="col-md-8">
                    <p class="form-control-static">
                        <asp:TextBox ID="txtDiaChiTamChu" Rows="1" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
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
                <asp:Button ID="btnUpdate" runat="server"  CssClass="btn green" Text="Cập  nhật" OnClick="btnUpdate_Click" />
                <button class="btn default" type="button">
                    Hủy</button>
            </div>
        </div>
    </div>
</div>
