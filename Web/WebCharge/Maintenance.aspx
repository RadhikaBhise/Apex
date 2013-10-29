<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Maintenance.aspx.vb" Inherits="Maintenance" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<form id="Form1" name="Form1" method="post" runat="server">
<table border="0" cellspacing="0" cellpadding="0" style="width:570">
    <tr>
        <td class="css_header">Maintenance</td>
    </tr>
	<tr><td><hr noshade="noshade" size="3" /></td></tr>
    <tr><td align="left">
              <table border="0">
                 <tr>
                    <td align="right"><img src="images/bluebullet.gif" alt=""></td>
                    <td class="css_desc" style="width:70%">Security File</td>
                    <td class="css_desc"></td>
                    <td class="css_desc">&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td class="font3" style="width:70%">Change Current Logon</td>
                    <td class="font3"></td>
                    <td class="font3"><asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/Images/go_btn.gif" /></td>
                </tr>
                <tr>
                    <td colspan="4" align="center"><a href="default.aspx">Back To Main Menu</a></td>
                </tr>
              </table>
          </td>
     </tr>
</table>
</form>
<br />
</asp:Content>

