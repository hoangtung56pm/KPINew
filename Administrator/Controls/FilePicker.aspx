<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FilePicker.aspx.cs" Inherits="VmgPortal.Administrator.Controls.FilePicker" %>
<HTML>
	<HEAD>
		<title>Chọn một File</title>
		<meta http-equiv="content-type" content="text/html;charset=UTF-8">
		<link href="/JScripts/ePiAdmin.css" type="text/css" rel="stylesheet">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">.hd { FONT-WEIGHT: bold; FONT-SIZE: x-small; COLOR: #003366; FONT-FAMILY: Verdana; HEIGHT: 30px; BACKGROUND-COLOR: #e9e9e9 }
		</style>
	</HEAD>
	<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
		<form id="frmFilePicker" enctype="multipart/form-data" runat="server">
			<table class="tblFormContainer" height="100%" cellspacing="0" cellpadding="0" width="100%"
				border="1">
				<tbody>
					<tr>
						<td class="hd" colspan="2">Tải tệp ảnh</td>
					</tr>
					<asp:placeholder id="UploadArea" runat="server" visible="false" enableviewstate="False">
						<TR>
							<TD><IMG src="/Images/Icons/Upload.gif" align="left">Tải lên các file</TD>
							<TD><INPUT class="textBox" id="fileToUpload1" type="file" size="15" name="fileToUpload1" runat="server"><BR>
								<INPUT class="textBox" id="fileToUpload2" type="file" size="15" name="fileToUpload2" runat="server"><BR>
								<INPUT class="textBox" id="fileToUpload3" type="file" size="15" name="fileToUpload3" runat="server">
								&nbsp;
								<asp:button id="UploadBtn" runat="server" text="Tải lên"></asp:button></TD>
						</TR>
						<TR>
							<TD><IMG src="/Images/Icons/Rich.gif" align="left">Tạo ảnh thu nhỏ</TD>
							<TD><INPUT id="chkThumbnail" type="checkbox" name="chkThumbnail" runat="server"></TD>
						</TR>
					</asp:placeholder><asp:placeholder id="CreateDirArea" runat="server" visible="false" enableviewstate="False">
						<TR>
							<TD><IMG src="/Images/Icons/folderAdd.gif" align="left">Tạo thư mục mới</TD>
							<TD>
								<asp:textbox id="NewFolderText" runat="server" enableviewstate="False" cssclass="textBox" size="15"></asp:textbox>
								<asp:button id="NewFolderBtn" runat="server" enableviewstate="False" text="Tạo mới"></asp:button></TD>
						</TR>
					</asp:placeholder>
					<tr>
						<td class="hd" colspan="2">Thư mục ảnh</td>
					</tr>
					<tr>
						<td><asp:imagebutton id="UpBtn" runat="server" enableviewstate="False" tooltip="Lên thư mục trên" imageurl="/Images/Icons/folder_up.gif"
								commandname="ChangePath" commandargument="../"></asp:imagebutton><asp:imagebutton id="GoRoot" runat="server" enableviewstate="False" imageurl="/Images/Icons/Home.gif"
								commandname="ChangePath" commandargument="/" alternatetext="Về thư mục gốc"></asp:imagebutton></td>
						<td align="right"><asp:label id="Header" runat="server" enableviewstate="False" font-name="Arial"></asp:label></td>
					</tr>
					<tr>
						<td valign="top" align="left" width="100%" colspan="2" height="100%"><asp:datagrid id="dgFSList" runat="server" enableviewstate="False" cssclass="tblForm" cellpadding="3"
								autogeneratecolumns="False" allowpaging="True" allowsorting="True" pagesize="20" width="100%">
								<itemstyle font-size="12px" font-names="Tahoma"></itemstyle>
								<headerstyle cssclass="tblHeader"></headerstyle>
								<columns>
									<asp:templatecolumn sortexpression="IsFile">
										<itemtemplate>
											<asp:image runat="server" id="imgFSObject" />
										</itemtemplate>
									</asp:templatecolumn>
									<asp:templatecolumn sortexpression="FileName" headertext="T&#234;n File">
										<itemtemplate>
											<asp:linkbutton id="lbFileName" runat="server" commandname="FSOClick"></asp:linkbutton>
										</itemtemplate>
										<edititemtemplate>
											<asp:TextBox id="txtFileName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FileName") %>'>
											</asp:TextBox>
										</edititemtemplate>
									</asp:templatecolumn>
									<asp:templatecolumn sortexpression="Size" headertext="K&#237;ch cỡ">
										<headerstyle horizontalalign="Right"></headerstyle>
										<itemstyle horizontalalign="Right"></itemstyle>
										<itemtemplate>
											<asp:label id="lblSize" runat="server"></asp:label>
											<asp:label id="lblWidth" runat="server" visible="false"></asp:label>
											<asp:label id="lblHeight" runat="server" visible="false"></asp:label>
										</itemtemplate>
									</asp:templatecolumn>
									<asp:templatecolumn sortexpression="Modified" headertext="Ng&#224;y thay đổi">
										<headerstyle horizontalalign="Center"></headerstyle>
										<itemstyle horizontalalign="Right"></itemstyle>
										<itemtemplate>
											<asp:label id="lbModified" runat="server"></asp:label>
										</itemtemplate>
									</asp:templatecolumn>
									<asp:templatecolumn headertext="Xử l&#253;">
										<headerstyle horizontalalign="Center"></headerstyle>
										<itemstyle horizontalalign="Center"></itemstyle>
										<itemtemplate>
											<asp:hyperlink id="hlView" runat="server" tooltip="Xem" imageurl="/Images/Icons/View.gif" target="_Blank"></asp:hyperlink>
											<asp:linkbutton id="imbRen" runat="server" visible="False" text="<img src='/Images/Icons/saveAs.gif' border='0' align='center'/>"
												tooltip="Đổi tên" commandname="Rename">
												<img src='/Images/Icons/saveAs.gif' border='0'></asp:linkbutton>
											<asp:hyperlink id="lnkEditImage" runat="server" target="_blank">
												<img src='/Images/Icons/editImage.gif' border='0'></asp:hyperlink>
											<asp:linkbutton id="imbDel" runat="server" visible="False" text="<img src='/Images/Icons/Delete.gif' border='0' align='center'/>"
												tooltip="Xóa" commandname="Del">
												<img src='/Images/Icons/Delete.gif' border='0'></asp:linkbutton>
										</itemtemplate>
										<edititemtemplate>
											<asp:linkbutton id="imbUpdate" runat="server" text="<img src='/Images/Icons/Check.gif' border='0' align='center'/>"
												tooltip="Cập nhật" commandname="Update">
												<img src='/Images/Icons/Check.gif' border='0'></asp:linkbutton>
											<asp:linkbutton id="imbCancel" runat="server" text="<img src='/Images/Icons/Cancel.gif' border='0' align='center'/>"
												tooltip="Hủy" commandname="Cancel">
												<img src='/Images/Icons/Cancel.gif' border='0'></asp:linkbutton>
										</edititemtemplate>
									</asp:templatecolumn>
								</columns>
								<pagerstyle nextpagetext="Next &gt;&gt;" prevpagetext="&lt;&lt; Prev" horizontalalign="Left"
									mode="NumericPages"></pagerstyle>
							</asp:datagrid></td>
					</tr>
				</tbody>
			</table>
		</form>
	</body>
</HTML>

