<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="setpw.aspx.vb" Inherits="setpw" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
<script language="javascript" type="text/javascript">
function batchValidate(){
	if(document.forms[0].ctl00_content_txtUsername.value == "" ){
		alert("Please enter a Password.");
		document.forms[0].ctl00_content_txtUsername.focus();
		return false;
	}else if(document.forms[0].ctl00_content_txtUsername.value.length < 4){
		alert("Password must be at least 4 characters.");
		document.forms[0].ctl00_content_txtUsername.focus();
		return false;
	}else if(document.forms[0].ctl00_content_txtPassword.value == ""){
		alert("Please enter Confirm Password.");
		document.forms[0].ctl00_content_txtPassword.focus();
		return false;
	}else if(document.forms[0].ctl00_content_txtUsername.value!=document.forms[0].ctl00_content_txtPassword.value){
	    alert("Passwords do not match! Please try again!");
	    document.forms[0].ctl00_content_txtPassword.focus();
	    return false;
	}
}
</script>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="background: url(images/content-bg.jpg) repeat-x">
  <tr><td>
  </td></tr>
  <tr>
    <td align="left" style="background-image:url(images/background.gif); height: 27px; padding-left: 50px;" class="css_stoptitle">Update Password</td>
  </tr>
  <tr>
  <td>
      <br />
      <br />
      <table width="100%" style="height: 112px">
  <tr>
  <td colspan="2" align="left"><font face=arial size=1 color=red>PLEASE SELECT A PASSWORD OTHER THAN YOUR USERID</font></td></tr>						
	<tr>
								<td align="center" colSpan="3" style="height: 16px"><B><asp:label id="lblErr" runat="server" ForeColor="Red" Width="378px"></asp:label></B></td>
							</tr>
							<tr>
								<td align="left" class="css_text" style="width: 109px">New Password</td>
								<td align="left"><!--input type="text" name="fname" value="VIP" maxlength="20" class="form"--><asp:textbox id="txtUsername" runat="server" Width="266px" MaxLength="50" TextMode="Password"></asp:textbox>&nbsp;<FONT color="#ff0033">*</FONT></td>
							</tr>
							<tr>
								<td align="left" class="css_text" style="width: 109px">Confirm Password</td>
								<td align="left" style="HEIGHT: 27px"><asp:textbox id="txtPassword" runat="server" Width="266px" MaxLength="50" TextMode="Password"></asp:textbox>&nbsp;<FONT color="#ff0033">*</FONT></td>
							</tr>
							<%--<tr>
								<td align="left" class="orderformtd" style="width: 121px"><font class="GridFont">Confirm Password</font></td>
								<td align="left" style="HEIGHT: 27px"><asp:textbox id="txtConfir" runat="server" Width="130px" MaxLength="25"></asp:textbox>&nbsp;<FONT color="#ff0033">*</FONT></td>
							</tr>--%>
							<tr>
								<td align="center" style="width: 109px" ><%--<a href="Home.aspx"><font face="arial" size="1">Back to Login Page</font></a>--%></td>
								<td align="left" width="450">
                                    <asp:ImageButton ID="ImgbtnSubmit" runat="server" ImageUrl="Images/Submit.gif" /></td>
							</tr>
	
							</table>
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
  </td>
  </tr>
  </table>
</asp:Content>



