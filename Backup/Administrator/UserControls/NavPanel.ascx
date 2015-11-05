<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavPanel.ascx.cs" Inherits="VmgPortal.Administrator.UserControls.NavPanel" %>
<%--BEGIN LEFT MENU--%>
<div class="page-sidebar navbar-collapse">
    <!-- BEGIN SIDEBAR MENU -->
    <ul class="page-sidebar-menu">
        <li>
            <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
            <div class="sidebar-toggler hidden-phone">
            </div>
            <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
        </li>
        <li>
            <!-- BEGIN RESPONSIVE QUICK SEARCH FORM -->
            <div class="sidebar-search">
                <div class="form-container">
                    <div class="input-box">
                        <a href="javascript:;" class="remove"></a>
                        <input type="text" placeholder="Search...">
                        <input type="button" class="submit" value=" ">
                    </div>
                </div>
            </div>
            <!-- END RESPONSIVE QUICK SEARCH FORM -->
        </li>
        
        <asp:Literal ID="radmMenu" runat="server"></asp:Literal>
    </ul>
    <!-- END SIDEBAR MENU -->
</div>
<%--END LEFT MENU--%>