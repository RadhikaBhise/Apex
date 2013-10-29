<%@ Page Language="VB" AutoEventWireup="false" CodeFile="index_news.aspx.vb" Inherits="index_news" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><%=System.Web.Configuration.WebConfigurationManager.AppSettings("title")%></title>
    <link href="CSS/styles.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Menu.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Menu1.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="JS/News.js"></script>
</head>
<body class="news_title">
    <form id="form1" runat="server" method="post" class="news_title">
    <table id="table1" width="100%" cellpadding="0" cellspacing="0" border="0" class="news_title">
    <tr>
    <td align="left">
    <asp:DataList ID="dlNews" runat="server" Width="100%" BorderStyle="none">
    <ItemTemplate>
    <table width="100%">    
    <tr>
    <td id="tdTitle" runat="server" width="100%" align="left" style="font-size:15pt;" colspan="3" class="news_title"><%#DataBinder.Eval(Container.DataItem,"summary_title")%>
    </td>
    </tr>    
    <tr> 
    <td id="tdNews" runat="server" width="100%" colspan="3" align="left" valign="top" height="60%" style="font-family:Arial;" class="news_text"><%#DataBinder.Eval(Container.DataItem,"summary_text")%>
     </td>
    </tr>

    </table>
   <table id="table2" width="100%" cellpadding="0" cellspacing="0" border="0" height="25px">
     
     <tr><td id="tdMore" width="100%" align="right" runat="server" valign="middle">
     <table><tr>
     <td valign="middle"><a href="#" onclick="javascript:link_pages('<%#DataBinder.Eval(Container.DataItem,"id")%>');" class="news_text_dark" style="float:right;"><strong>Details </strong></a></td><td></td>
     </tr></table>
           
     </td></tr>
          <TR>
				<TD class="css_title" style="height: 2px; width:100%" colspan="3">
				<hr color="#d6d6d6"></TD>
			</TR>
     </table>
    </ItemTemplate>
    </asp:DataList>
    
    </td>
    
    </tr>

    </table>
     
    </form>
</body>
</html>
