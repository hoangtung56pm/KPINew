<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Setting.ascx.cs" Inherits="VmgPortal.Modules.LogFile.Admin.Setting" %>
<table border="0" cellpadding="0" cellspacing="0" class="InputBox" width="98%">
	<tr>
		<td></td>
		<td>Số năm lưu trữ File Log
		</td>
		<td><asp:textbox id="txtyears" Runat="server" Width="150"></asp:textbox></td>
		<td></td>
	</tr>
	<tr>
		<td style="height: 24px"></td>
		<td style="height: 24px">Số Tháng lưu trữ File Log
		</td>
		<td style="height: 24px"><asp:textbox id="txtmonths" Runat="server" CssClass="inputTextBox150" Width="150"></asp:textbox></td>
		<td style="height: 24px"></td>
	</tr>
	<tr>
		<td style="height: 24px"></td>
		<td style="height: 24px">Số ngày lưu trữ File Log
		</td>
		<td style="height: 24px"><asp:textbox id="txtdays" Runat="server"  CssClass="inputTextBox150" Width="150"></asp:textbox></td>
		<td style="height: 24px"></td>
	</tr>
	<tr>
		<td style="height: 18px"></td>
		<td style="height: 18px">Không xóa File Log</td>
		<td style="height: 18px"><asp:CheckBox ID="chkLog" Runat="server" CssClass="inputTextBox150" ></asp:CheckBox></td>
		<td style="height: 18px"></td>
	</tr>
	<tr>
		<td colspan="4" height="20"></td>
	</tr>
	<tr>
		<td width="100">&nbsp;</td>
		<td colspan="2" align="center"><asp:button id="btnUpdate" CssClass="Button" Runat="server" Text="Cập nhật" OnClick="btnUpdate_Click"></asp:button></td>
		<td width="100">&nbsp;</td>
	</tr>
</table>
