<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"  enableEventValidation="false" AutoEventWireup="false" CodeFile="News.aspx.vb" Inherits="News" title="Untitled Page" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
    <script language="javascript" type="text/javascript" src="JS/News.js"></script>

    <table id="table1" width="100%" cellpadding="0" cellspacing="0" border="0" class="news_title">
    <tr>
    <td align="center">
    <asp:DataList ID="dlNews" runat="server" Width="100%" BorderStyle="none">
    <ItemTemplate>
    <table width="99%">    
    <tr>
    <td id="tdTitle" runat="server" width="100%" align="left" style="font-size:15pt;" colspan="3" class="news_title"><%#DataBinder.Eval(Container.DataItem,"summary_title")%>
    </td>
    </tr>    
    <tr> 
    <td id="tdNews" runat="server" width="100%" colspan="3" align="left" valign="top" height="60%" style="font-family:Arial;" class="news_text"><%#DataBinder.Eval(Container.DataItem,"summary_text")%>
     </td>
    </tr>

    </table>
   <table id="table2" width="99%" cellpadding="0" cellspacing="0" border="0" height="1px">
     
     <tr><td id="tdMore" width="100%" align="right" runat="server" valign="middle">
     <table><tr>
     <td valign="middle"><a href="#" onclick="javascript:link_pages('<%#DataBinder.Eval(Container.DataItem,"id")%>');" class="news_text_dark" style="float:right;"><strong>Details </strong></a></td><td></td>
     </tr></table>
           
     </td></tr>
          <TR>
				<TD class="css_title" style="height: 1px; width:100%" colspan="3">
				<hr color="#d6d6d6" style="height:1px;"></TD>
			</TR>
     </table>
    </ItemTemplate>
    </asp:DataList>
    
    </td>
    
    </tr>

    </table>
    </asp:Content>


