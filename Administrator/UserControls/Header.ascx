<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="VmgPortal.Administrator.UserControls.Header" %>
<!-- BEGIN HEADER -->
<div style="height: 70px;" class="header navbar navbar-inverse navbar-fixed-top">
    <div class="header-inner">
        <!-- BEGIN LOGO -->
        <a class="navbar-brand" style="color: #fff; font-weight: bold;" href="/">
            <%--       <img width="200px" src="assets/img/logo-mobi.png" alt="" />--%>
            <%--<img src="/Images/logoVMG55portal.png" alt="logo" height="14px" style="height: 14px;" class="img-responsive" />--%>
            VMG KPI SYSTEM </a>
        <!-- END LOGO -->
        <!-- BEGIN HORIZANTAL MENU -->
        <div class="hor-menu hidden-sm hidden-xs">
            <asp:Literal ID="radmMenu" runat="server"></asp:Literal>
        </div>
        <!-- END HORIZANTAL MENU -->
        <!-- BEGIN RESPONSIVE MENU TOGGLER -->
        <a href="javascript:;" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
            <img src="assets/img/menu-toggler.png" alt="" />
        </a>
        <!-- END RESPONSIVE MENU TOGGLER -->
        <!-- BEGIN TOP NAVIGATION MENU -->
        <ul class="nav navbar-nav pull-right">
            <!-- BEGIN NOTIFICATION DROPDOWN -->
            <%--<li class="dropdown" id="header_notification_bar">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown"
                    data-close-others="true">
                    <i class="icon-warning-sign"></i>
                    <span class="badge">6</span>
                </a>
                <ul class="dropdown-menu extended notification">
                    <li>
                        <p>You have 14 new notifications</p>
                    </li>
                    <li>
                        <ul class="dropdown-menu-list scroller" style="height: 250px;">
                            <li>
                                <a href="#">
                                    <span class="label label-icon label-success"><i class="icon-plus"></i></span>
                                    New user registered. 
									<span class="time">Just now</span>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <span class="label label-icon label-danger"><i class="icon-bolt"></i></span>
                                    Server #12 overloaded. 
									<span class="time">15 mins</span>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <span class="label label-icon label-warning"><i class="icon-bell"></i></span>
                                    Server #2 not responding.
									<span class="time">22 mins</span>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <span class="label label-icon label-info"><i class="icon-bullhorn"></i></span>
                                    Application error.
									<span class="time">40 mins</span>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <span class="label label-icon label-danger"><i class="icon-bolt"></i></span>
                                    Database overloaded 68%. 
									<span class="time">2 hrs</span>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <span class="label label-icon label-danger"><i class="icon-bolt"></i></span>
                                    2 user IP blocked.
									<span class="time">5 hrs</span>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <span class="label label-icon label-warning"><i class="icon-bell"></i></span>
                                    Storage Server #4 not responding.
									<span class="time">45 mins</span>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <span class="label label-icon label-info"><i class="icon-bullhorn"></i></span>
                                    System Error.
									<span class="time">55 mins</span>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <span class="label label-icon label-danger"><i class="icon-bolt"></i></span>
                                    Database overloaded 68%. 
									<span class="time">2 hrs</span>
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li class="external">
                        <a href="#">See all notifications <i class="m-icon-swapright"></i></a>
                    </li>
                </ul>
            </li>--%>
            <!-- END NOTIFICATION DROPDOWN -->
            <!-- BEGIN INBOX DROPDOWN -->
            <%--<li class="dropdown" id="header_inbox_bar">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown"
                    data-close-others="true">
                    <i class="icon-envelope"></i>
                    <span class="badge">5</span>
                </a>
                <ul class="dropdown-menu extended inbox">
                    <li>
                        <p>You have 12 new messages</p>
                    </li>
                    <li>
                        <ul class="dropdown-menu-list scroller" style="height: 250px;">
                            <li>
                                <a href="inbox.html?a=view">
                                    <span class="photo">
                                        <img src="./assets/img/avatar2.jpg" alt="" /></span>
                                    <span class="subject">
                                        <span class="from">Lisa Wong</span>
                                        <span class="time">Just Now</span>
                                    </span>
                                    <span class="message">Vivamus sed auctor nibh congue nibh. auctor nibh
									auctor nibh...
                                    </span>
                                </a>
                            </li>
                            <li>
                                <a href="inbox.html?a=view">
                                    <span class="photo">
                                        <img src="./assets/img/avatar3.jpg" alt="" /></span>
                                    <span class="subject">
                                        <span class="from">Richard Doe</span>
                                        <span class="time">16 mins</span>
                                    </span>
                                    <span class="message">Vivamus sed congue nibh auctor nibh congue nibh. auctor nibh
									auctor nibh...
                                    </span>
                                </a>
                            </li>
                            <li>
                                <a href="inbox.html?a=view">
                                    <span class="photo">
                                        <img src="./assets/img/avatar1.jpg" alt="" /></span>
                                    <span class="subject">
                                        <span class="from">Bob Nilson</span>
                                        <span class="time">2 hrs</span>
                                    </span>
                                    <span class="message">Vivamus sed nibh auctor nibh congue nibh. auctor nibh
									auctor nibh...
                                    </span>
                                </a>
                            </li>
                            <li>
                                <a href="inbox.html?a=view">
                                    <span class="photo">
                                        <img src="./assets/img/avatar2.jpg" alt="" /></span>
                                    <span class="subject">
                                        <span class="from">Lisa Wong</span>
                                        <span class="time">40 mins</span>
                                    </span>
                                    <span class="message">Vivamus sed auctor 40% nibh congue nibh...
                                    </span>
                                </a>
                            </li>
                            <li>
                                <a href="inbox.html?a=view">
                                    <span class="photo">
                                        <img src="./assets/img/avatar3.jpg" alt="" /></span>
                                    <span class="subject">
                                        <span class="from">Richard Doe</span>
                                        <span class="time">46 mins</span>
                                    </span>
                                    <span class="message">Vivamus sed congue nibh auctor nibh congue nibh. auctor nibh
									auctor nibh...
                                    </span>
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li class="external">
                        <a href="inbox.html">See all messages <i class="m-icon-swapright"></i></a>
                    </li>
                </ul>
            </li>--%>
            <!-- END INBOX DROPDOWN -->
            <%--BEGIN SELECT PORTAL--%>
            <li class="dropdown" id="header_task_bar"><a href="#" class="dropdown-toggle" data-toggle="dropdown"
                data-hover="dropdown" data-close-others="true"><i class="icon-tasks"></i>
                <%-- <%=Admin.library.Portal.PortalControllerAdmin.SelectPortalNameById(AppEnv.PortalId(),AppEnv.GetLanguage()) %>--%>
                <%--  <span class="badge">5</span>--%>
            </a>
                <ul class="dropdown-menu" role="menu">
                    <asp:Literal ID="ltrPortal" runat="server"></asp:Literal>
                </ul>
            </li>
            <%--END SELECT PORTAL--%>
            <!-- BEGIN USER LOGIN DROPDOWN -->
            <li class="dropdown user"><a href="#" class="dropdown-toggle" data-toggle="dropdown"
                data-hover="dropdown" data-close-others="true">
                <img alt="" src="assets/img/avatar1_small.jpg" />
                <span class="username">
                    <asp:Label ID="lblCurrentUser" runat="server"></asp:Label></span> <i class="icon-angle-down">
                    </i></a>
                <ul class="dropdown-menu">
                    <li>
                        <asp:HyperLink ID="hplChangePass" runat="server"><i class="icon-user"></i>Edit Profile</asp:HyperLink></li>
                    <%--     <li><a href="page_calendar.html"><i class="icon-calendar"></i>My Calendar</a></li>
                        <li><a href="inbox.html"><i class="icon-envelope"></i>My Inbox <span class="badge badge-danger">3</span></a></li>
                        <li><a href="#"><i class="icon-tasks"></i>My Tasks <span class="badge badge-success">7</span></a></li>--%>
                    <li class="divider"></li>
                    <li>
                        <asp:HyperLink ID="trigger_fullscreen" ClientIDMode="Static" runat="server"></asp:HyperLink></li>
                    <%--<li><a href="extra_lock.html"><i class="icon-lock"></i>Lock Screen</a></li>--%>
                    <li>
                        <asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click" CausesValidation="False"></asp:LinkButton></li>
                    <li class="divider"></li>
                    <li>
                        <asp:LinkButton ID="btnViet" runat="server" OnClick="btnViet_Click" CausesValidation="False"></asp:LinkButton>
                        <asp:LinkButton ID="btnEng" runat="server" OnClick="btnEng_Click" CausesValidation="False"></asp:LinkButton>
                    </li>
                </ul>
            </li>
            <!-- END USER LOGIN DROPDOWN -->
        </ul>
        <!-- END TOP NAVIGATION MENU -->
    </div>
</div>
<!-- END HEADER -->
<%--begin old--%>