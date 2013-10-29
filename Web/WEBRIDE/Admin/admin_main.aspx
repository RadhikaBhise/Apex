<%@ Page Language="VB" AutoEventWireup="false" CodeFile="admin_main.aspx.vb" Inherits="Admin_admin_main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../Modules/admin_header.ascx" TagName="admin_header" TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><%=System.Web.Configuration.WebConfigurationManager.AppSettings("title")%></title>
    <link href="../CSS/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
  <table width="780"  border="0" style="border-collapse: collapse">
    <tr>
      <td height="15" align="right" valign="middle">
          <uc1:admin_header ID="Admin_header1" runat="server" />
          &nbsp;</td>
    </tr>
      <tr> 
      <td align="center" valign="middle"> <p>&nbsp;</p>
       
        <p><strong><font class="loginfont"><a href="admin_news.aspx">NEWS ITEMS</a></font></strong></p>
        <p><strong><font class="loginfont"><a href="admin_banner.aspx">BANNER</a></font></strong></p>
        <p><strong><font class="loginfont"><a href="login.aspx?msg=logoff">Log Off</a></font></strong></p>      
		
<p>&nbsp;</p></td>
    </tr>
  </table>
</div>
    </form>
</body>
</html>
