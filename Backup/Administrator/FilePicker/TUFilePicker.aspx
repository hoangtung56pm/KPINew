<%@ Page Language="C#" AutoEventWireup="true" Inherits="VmgPortal.FilePicker.FilePicker"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" EnableSessionState="True" %>

<%@ Register TagPrefix="radU" Namespace="Telerik.WebControls" Assembly="RadUpload.NET2" %>
<%@ Register TagPrefix="cc1" Namespace="ChrisDengler.WebUI.Components" Assembly="WebMsgBox" %>
<%@ Import Namespace="System.IO" %>
<html>
<head>
    <title>
        <% =lblTitle%>
    </title>
    <meta http-equiv="Content-Type" content="text/html">
    <link href="styles.css" type="text/css" rel="stylesheet">

    <script language="javascript" src="menu.js"></script>

</head>
<body>
    <form id="formExplorer" enctype="multipart/form-data" runat="server">
        &nbsp;<table class="background" cellspacing="2" cellpadding="2" width="100%" border="0">
            <tr>
                <td align="center" width="100%" colspan="15">
                    <table cellspacing="7" cellpadding="0" border="0">
                        <tr>
                            <td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')">
                                <asp:ImageButton ID="btnRoot" OnClick="NavigateHome" runat="server" ImageUrl="Images/Root.gif"
                                    Height="24px" Width="24px" meta:resourcekey="btnRootResource1"></asp:ImageButton></td>
                            <td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')">
                                <asp:ImageButton ID="btnNavigateUp" OnClick="NavigateUp" runat="server" ImageUrl="Images/Up.gif"
                                    Height="24px" Width="24px" meta:resourcekey="btnNavigateUpResource1"></asp:ImageButton></td>
                            <td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')">
                                <asp:ImageButton ID="btnCopy" OnClick="Copy" runat="server" ImageUrl="Images/Copy.gif"
                                    Height="24px" Width="24px" meta:resourcekey="btnCopyResource1"></asp:ImageButton></td>
                            <td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')">
                                <asp:ImageButton ID="btnCut" OnClick="Cut" runat="server" ImageUrl="Images/Cut.gif"
                                    Height="24px" Width="24px" meta:resourcekey="btnCutResource1"></asp:ImageButton></td>
                            <td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')">
                                <asp:ImageButton ID="btnPaste" OnClick="Paste" runat="server" ImageUrl="Images/Paste.gif"
                                    Height="24px" Width="24px" meta:resourcekey="btnPasteResource1"></asp:ImageButton></td>
                            <td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')">
                                <asp:ImageButton ID="btnNewFolder" OnClick="NewFolder" runat="server" ImageUrl="Images/NewFolder.gif"
                                    Height="24px" Width="24px" meta:resourcekey="btnNewFolderResource1"></asp:ImageButton></td>
                            <td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onclick="javascript: return confirm('<%=deleteConfirmation %>');"
                                onmouseout="changeBg(this,'buttonOff')">
                                <asp:ImageButton ID="btnDelete" OnClick="Delete" runat="server" ImageUrl="Images/Delete.gif"
                                    Height="24px" Width="24px" meta:resourcekey="btnDeleteResource1"></asp:ImageButton></td>
                            <td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')">
                                <asp:ImageButton ID="btnRefresh" OnClick="Refresh" runat="server" ImageUrl="Images/Refresh.gif"
                                    Height="24px" Width="24px" meta:resourcekey="btnRefreshResource1"></asp:ImageButton></td>
                            <td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')">
                                <asp:ImageButton ID="btnReserverCheck" OnClick="ReverseCheck" runat="server" ImageUrl="Images/ReverseCheck.gif"
                                    Height="24px" Width="24px" meta:resourcekey="btnReserverCheckResource1"></asp:ImageButton></td>
                            <td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')">
                                <asp:ImageButton ID="btnToggleThumbnails" OnClick="ToggleThumbnails" runat="server"
                                    ImageUrl="Images/ThumbNail.gif" Height="24px" Width="24px" meta:resourcekey="btnToggleThumbnailsResource1">
                                </asp:ImageButton></td>
                            <td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')">
                                <asp:ImageButton ID="btnUpload" OnClick="ShowUpload" runat="server" ImageUrl="Images/Upload.gif"
                                    Height="24px" Width="24px" meta:resourcekey="btnUploadResource1"></asp:ImageButton></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="15" style="height: 117px">
                    <cc1:WebMsgBox ID="wmbMessage" runat="server" Enabled="False" MsgBoxIcon="vbExclamation"
                        MsgBoxDefaultButton="none" MsgBoxModal="none">
                    </cc1:WebMsgBox>
                    <div id="ProgressBarPanel" style="display: none">
                        <table align="center">
                            <tr>
                                <td>
                                    <span class="languageSelector"><b>
                                        <%=lblLabelPleaseWaith%>
                                    </b></span>
                                    <img id="ProgressBar" height="13" src="Images/Progress.gif" width="240" border="0">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:Panel ID="PanelUpload" runat="server" Visible="False" CssClass="Panel" meta:resourcekey="PanelUploadResource1">
                        <table id="Table1" align="center" runat="server" visible="false">
                            <tr align="center">
                                <td colspan="2" height="30">
                                    <input class="textBox" id="inputFileName" type="file" runat="server"><a href="javascript:ShowProgressBar('uploadfileLink')">
                                        <img height="24" src="Images/Save.gif" width="24" align="absMiddle" border="0" id="IMG1">
                                    </a>
                                    <asp:LinkButton ID="uploadfileLink" OnClick="uploadFile" runat="server" EnableViewState="False"
                                        meta:resourcekey="uploadfileLinkResource1"></asp:LinkButton></td>
                            </tr>
                            <tr align="left">
                                <td colspan="2">
                                    <fieldset class="fieldset">
                                        <legend><b></b></legend>
                                        <asp:RadioButtonList ID="rblUploadOptions" runat="server" CssClass="radiolist" RepeatColumns="3"
                                            meta:resourcekey="rblUploadOptionsResource1">
                                            <asp:ListItem meta:resourcekey="ListItemResource1" />
                                            <asp:ListItem meta:resourcekey="ListItemResource2" />
                                            <asp:ListItem Selected="True" meta:resourcekey="ListItemResource3" />
                                        </asp:RadioButtonList>
                                    </fieldset>
                                    <br>                                    
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" align="center">
                            <tr>
                                <td style="vertical-align: top;">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                                    <asp:UpdatePanel runat="server" ID="updatePanel1">
                                        <ContentTemplate>
                                            <radU:RadUpload ID="upload1" runat="server" InitialFileInputsCount="1" OverwriteExistingFiles="true" AllowedFileExtensions=".gif,.jpg,.jpeg,.png,.swf,.zip" />
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="RadUploadButton" Text="Update"
                                                Style="margin-top: 6px;" OnClick="btnSubmit_Click" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnSubmit" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="vertical-align: top;">
                                    <div class="module" style="width: 280px; height: 150px; margin-top: 5px; float: right;
                                        overflow: auto;">
                                        <asp:Label ID="labelNoResults" runat="server" Visible="True">No uploaded files</asp:Label>
                                        <asp:Repeater ID="repeaterValidResults" runat="server" Visible="False">
                                            <HeaderTemplate>
                                                <fieldset class="fieldset">
                                                    <legend><b>Uploaded files:</b></legend>
                                                    <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Literal ID="ltFileName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FileName")%>'></asp:Literal>
                                                (<asp:Literal ID="ltFileSize" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ContentLength").ToString() + " bytes"%>'></asp:Literal>)<br />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </fieldset></FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div class="module" style="margin-top: 5px; float: right; overflow: auto; width: 280px;
                                        height: auto;">
                                        <asp:Label ID="labelNoInvalidResults" runat="server" Visible="True">No invalid files</asp:Label>
                                        <asp:Repeater ID="repeaterInvalidResults" runat="server" Visible="False">
                                            <HeaderTemplate>
                                                <fieldset class="fieldset">
                                                    <legend><b>Invalid files:</b></legend>
                                                    <br />
                                                    <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                File:
                                                <%#DataBinder.Eval(Container.DataItem, "FileName")%>
                                                <br />
                                                File Size:
                                                <%#DataBinder.Eval(Container.DataItem, "ContentLength").ToString() + " bytes"%>
                                                <br />
                                                Mime-type:
                                                <%#DataBinder.Eval(Container.DataItem, "ContentType").ToString()%>
                                                <br />
                                                <br />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </fieldset></FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                </td>
                            </tr>
                            <tr align="left">
                                <td colspan="2">
                                    <fieldset class="fieldset">
                                        <legend><b></b></legend>
                                        <nobr><asp:CheckBox id="chkSelectUponUpload" runat="server" meta:resourceKey="chkSelectUponUploadResource1" Checked="false" ></asp:CheckBox> </nobr>
                                        <nobr><asp:CheckBox id="chkOverwrite" runat="server" meta:resourceKey="chkOverwriteResource1"></asp:CheckBox> </nobr>
                                        <br>
                                        <br>
                                        <asp:Label ID="lblUploadNote" runat="server" meta:resourcekey="lblUploadNoteResource1"></asp:Label>
                                    </fieldset>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    
                </td>
            </tr>
            <!--moi them-->
            <!--moi them-->
            <asp:PlaceHolder ID="phLanguageSelector" runat="server">
                <tr>
                    <td class="languageSelector" align="right" colspan="15" height="11">
                        Language: <a class="link" onclick="document.cookie ='UserLanguage=en';document.location.href=document.location.href;return true;"
                            href="#">English</a>&nbsp;|&nbsp;<a class="link" onclick="document.cookie ='UserLanguage=vi';document.location.href=document.location.href;return true;"
                                href="#">Vietnamese</a>&nbsp;</td>
                </tr>
            </asp:PlaceHolder>
            <tr>
                <td colspan="15">
                    <asp:TextBox ID="txtCurrentPath" runat="server" CssClass="pathTextBox" ReadOnly="True"
                        meta:resourcekey="txtCurrentPathResource1"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="15">
                    <span class="info">
                        <asp:Label ID="Info" runat="server" CssClass="text" Text='<b><% =lblLabelInfo%> </b>'
                            meta:resourcekey="InfoResource1"></asp:Label>
                    </span>
                </td>
            </tr>
            <tr align="right">
                <td colspan="14">
                </td>
                <td align="right">
                    <a href="#Bottom">
                        <img height="5" alt='<%=lblLabelBottom %>' src="Images/Bottom.gif" width="9" align="bottom"
                            border="0"></a></td>
            </tr>
            <tr>
                <td colspan="15">
                    <asp:DataGrid ID="dgExplorer" runat="server" CssClass="fileFolderGrid" AutoGenerateColumns="False"
                        BorderColor="#0053A5" AllowSorting="True" DataKeyField="Id" OnSortCommand="Sort"
                        OnEditCommand="Edit" OnCancelCommand="Cancel" OnUpdateCommand="Update" OnItemCreated="Created"
                        GridLines="Horizontal" Width="100%" CellPadding="2" OnItemCommand="ItemCommand"
                        meta:resourcekey="dgExplorerResource1">
                        <ItemStyle BackColor="White"></ItemStyle>
                        <AlternatingItemStyle BackColor="#CFDFE5"></AlternatingItemStyle>
                        <Columns>
                            <asp:TemplateColumn>
                                <HeaderStyle CssClass="fileFolderGridHeader" Width="5%" HorizontalAlign="Center"></HeaderStyle>
                                <ItemTemplate>
                                    <a name='<%# DataBinder.Eval(Container, "DataItem.Id") %>'>
                                        <asp:CheckBox ID="chkSelected" Checked='<%# DataBinder.Eval(Container, "DataItem.Chk") %>'
                                            runat='server' meta:resourcekey="chkSelectedResource1" />
                                    </a>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkSelectAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server"
                                        meta:resourcekey="chkSelectAllResource1" />
                                </HeaderTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="chkSelected" Checked='<%# DataBinder.Eval(Container, "DataItem.Chk") %>'
                                        runat='server' meta:resourcekey="chkSelectedResource2" />
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn SortExpression="Name">
                                <HeaderStyle Width="35%" CssClass="fileFolderGridHeader"></HeaderStyle>
                                <ItemTemplate>
                                    <nobr>
											<asp:ImageButton runat="server" ID="Icon" ImageAlign="Middle" CommandName='<%# DataBinder.Eval(Container, "DataItem.Type") %>' AlternateText='<%# DataBinder.Eval(Container, "DataItem.Name") %>' ImageUrl='<%# GetFileDirPictureUrl(DataBinder.Eval(Container, "DataItem.Type"), DataBinder.Eval(Container, "DataItem.Name")) %>' meta:resourceKey="IconResource1" OnCommand="NavigateDown"></asp:ImageButton>


											<asp:LinkButton runat="server" ID="Name" CssClass="link" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>' CommandName='<%# DataBinder.Eval(Container, "DataItem.Type") %>' meta:resourceKey="NameResource1" OnCommand="NavigateDown"></asp:LinkButton>


										</nobr>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="Name" CssClass='newNameTextBox' Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'
                                        runat='server' meta:resourcekey="NameResource2" />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn SortExpression="Length">
                                <HeaderStyle Width="15%" CssClass="fileFolderGridHeader"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="Length" Text='<%# DataBinder.Eval(Container, "DataItem.Length") %>'
                                        runat='server' CssClass='<%# DirectoryAlign(DataBinder.Eval(Container, "DataItem.Type")) %>'
                                        meta:resourcekey="LengthResource1" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="Length" Text='<%# DataBinder.Eval(Container, "DataItem.Length") %>'
                                        runat='server' CssClass='<%# DirectoryAlign(DataBinder.Eval(Container, "DataItem.Type")) %>'
                                        meta:resourcekey="LengthResource2" />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn SortExpression="Updated">
                                <HeaderStyle Width="20%" CssClass="fileFolderGridHeader"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Updated") %>'
                                        ID="Updated" meta:resourcekey="UpdatedResource1" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Updated") %>'
                                        ID="Label2" meta:resourcekey="Label2Resource1" />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <ItemTemplate>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderStyle Width="15%" CssClass="fileFolderGridHeader"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:ImageButton CommandName="Edit" runat="server" ImageUrl="Images/Rename.gif" Width="24px"
                                        Height="16px" ID="btnRename" EnableViewState="False" meta:resourcekey="btnRenameResource1" />&nbsp;
                                    <asp:ImageButton CommandName="Download" runat="server" ImageUrl='<%# GetDownloadImageUrl(DataBinder.Eval(Container, "DataItem.Type")) %>'
                                        Width="24px" Height="16px" ID="btnDownload" meta:resourcekey="btnDownloadResource1" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton CommandName="Update" runat="server" ImageUrl="Images/Ok.gif" ID="btnRenameOk"
                                        meta:resourcekey="btnRenameOkResource1" />
                                    <asp:ImageButton CommandName="Cancel" runat="server" ImageUrl="Images/Cancel.gif"
                                        ID="btnRenameCancel" meta:resourcekey="btnRenameCancelResource1" />
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                        </Columns>
                    </asp:DataGrid></td>
            </tr>
            <tr align="right">
                <td colspan="14">
                </td>
                <td align="right">
                    <a href="#Top">
                        <img height="5" alt='<%=lblLabelTop %>' src="Images/Top.gif" width="9" border="0"></a></td>
            </tr>
        </table>
        <a name="#Bottom"></a>
    </form>
</body>
</html>
