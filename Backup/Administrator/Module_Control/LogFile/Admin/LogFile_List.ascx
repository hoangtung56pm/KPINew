<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LogFile_List.ascx.cs" Inherits="VmgPortal.Modules.LogFile.Admin.LogFile_List" %>
<%@ Register TagPrefix="componentart" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<table border="0" cellpadding="0" cellspacing="0" width="98%" class="InputBox">
	<tr>
		<td style="height: 62px">
			<componentart:menu id="mnuCommands" CssClass="TopMenuGroup" DefaultGroupCssClass="MenuGroup" DefaultItemLookID="DefaultItemLook"
				DefaultGroupItemSpacing="0px" ExpandDelay="100" EnableViewState="false" ClientScriptLocation="/Jscripts/componentart_webui_client/"
				runat="server" TopGroupItemSpacing="0px" Orientation="Vertical">
				<ItemLooks>
					<componentart:ItemLook HoverCssClass="MenuSubBut" LabelPaddingTop="3px" LabelPaddingRight="10px" LabelPaddingBottom="3px"
						LabelPaddingLeft="30px" LookId="unselected" CssClass="MenuSubBut"></componentart:ItemLook>
					<componentart:ItemLook HoverCssClass="MenuSubBut_1" LabelPaddingTop="3px" LabelPaddingRight="10px" LabelPaddingBottom="3px"
						LabelPaddingLeft="10px" LookId="child" CssClass="MenuSubBut_1"></componentart:ItemLook>
					<componentart:ItemLook HoverCssClass="MenuSubBut_1_1" LabelPaddingTop="3px" LabelPaddingRight="10px" LabelPaddingBottom="3px"
						LabelPaddingLeft="10px" LookId="child1" CssClass="MenuSubBut_1_1"></componentart:ItemLook>
					<componentart:ItemLook HoverCssClass="MenuSubBut_1_1_1" LabelPaddingTop="3px" LabelPaddingRight="10px"
						LabelPaddingBottom="3px" LabelPaddingLeft="10px" LookId="child2" CssClass="MenuSubBut_1_1_1"></componentart:ItemLook>
					<componentart:ItemLook HoverCssClass="MenuSubBut_parent" LabelPaddingTop="3px" LabelPaddingRight="10px"
						LabelPaddingBottom="3px" LabelPaddingLeft="30px" LookId="home" CssClass="MenuSubBut_parent"></componentart:ItemLook>
				</ItemLooks>
			</componentart:menu>
		</td>
	</tr>
	<tr><td height=30px></td></tr>
	<tr>
		<td><asp:Label ID="lblog" Runat="server"></asp:Label></td>
	</tr>
</table>
