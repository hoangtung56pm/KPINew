<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LDAP.aspx.cs" Inherits="VmgPortal.Administrator.LDAP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <table cellpadding="1" cellspacing="1" style="background-color: #E0E0E0; border: 1px solid #727272">
                <tr>
                    <td>
                       <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" DisplayRememberMe="false"
                            DestinationPageUrl="~/HTMLPage1.htm">
                        </asp:Login>
                    </td>
                   
                </tr>
               
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
