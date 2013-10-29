<%@ Page Language="VB" AutoEventWireup="false" CodeFile="newAddress.aspx.vb" Inherits="newAddress" %>

<%@ Register Src="Modules/stop.ascx" TagName="stop" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>
			<%=System.Web.Configuration.WebConfigurationManager.AppSettings("title")%>
	</title>
    <link href="CSS/layout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%">
            <tr>
                <td class="css_title">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblVipNo" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:stop ID="Stop1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="images/Submit.gif" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
