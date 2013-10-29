<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="News_details.aspx.vb" Inherits="News_details" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">

<table width="808" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td colspan="2">
        </td>
  </tr>
  </table>
  <table width="808" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td colspan="2" valign="top" class="title" style="padding-top:10px;"><p><%=Full_Title%></p>
    <div class="main_text"><%=Full_Text%></div>
    <p><br />
      <br />
    </p></td>
  </tr>

</table> 
</asp:Content>

