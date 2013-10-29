 <%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MainLogUpdate.aspx.vb" Inherits="MainLogUpdate" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<script language ="javascript">
  function CheckPass(){
    if(document.getElementById("ctl00_MainContent_txtOpass").value.length==0){
     alert("Please enter old password!");
     document.getElementById("ctl00_MainContent_txtOpass").focus();
     return false;
    }
    if(document.getElementById("ctl00_MainContent_txtNpass").value.length==0){
     alert("Please enter new password!");
     document.getElementById("ctl00_MainContent_txtNpass").focus();
     return false;
    }
    if(document.getElementById("ctl00_MainContent_txtCpass").value.length==0){
     alert("Please enter confirm password!");
     document.getElementById("ctl00_MainContent_txtCpass").focus();
     return false;
    }
    if(document.getElementById("ctl00_MainContent_txtNpass").value!=document.getElementById("ctl00_MainContent_txtCpass").value){
    alert("The password is not match!");
    document.getElementById("ctl00_MainContent_txtCpass").focus();
     return false;
    }
  }
</script>
<form id="Form1" name="Form1" method="post" runat="server">
<table border="0" cellspacing="0" cellpadding="0" style="width:540">
<tr>
<td style="width:540">
	<table border="0" cellspacing="0" cellpadding="0" style="width:540">
	  <tr>
		<td colspan="2" class="css_header">Maintenance (Security):Change Current Logon
			<br />
			<table>
				<tr>
					<td class="css_desc">Vip #</td>
					<td class="css_desc">Acct ID</td>
					<td class="css_desc">Old Password</td>
					<td class="css_desc">Password</td>
					<td class="css_desc">Confirm</td>
				</tr>
				<tr >
				    <td class="font3"><asp:Label ID="lblVipno" runat ="server"></asp:Label></td>
					<td class="font3"><asp:label ID="lblAcct" runat ="server" ></asp:label></td>
					<td class="font3"><asp:TextBox ID="txtOpass" runat ="server" Width ="100" TextMode="Password"></asp:TextBox></td>
					<td class="font3"><asp:TextBox ID="txtNpass" runat ="server" Width ="100" TextMode="Password"></asp:TextBox></td>
					<td class="font3"><asp:TextBox ID="txtCpass" runat ="server" Width ="100" TextMode="Password"></asp:TextBox></td>
				</tr>
				<tr>
				    <td align="center" colspan="5" class="css_font">
			            <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/Images/Submit.gif" />
                        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                        <asp:ImageButton ID="btnReset" runat="server" ImageUrl="~/Images/Reset.gif" />
				    </td>
				</tr>
				<tr>
                    <td colspan="5" align="center"><br />
                    <a href="default.aspx">Back To Main Menu</a></td>
                </tr>
			</table>
			<br />
		</td>
	  </tr>
    </table>
</td>
</tr>
</table>
</form>
</asp:Content>

