<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<%--<script language="JavaScript" type="text/javascript">
	function validate(){
	if(document.forms[0].ctl00_MainContent_txt_vipno.value == "" || document.forms[0].ctl00_MainContent_txt_vipno.value.length == 0){
		alert("Please enter a VIP #!");
		document.forms[0].ctl00_MainContent_txt_vipno.focus();
		return false;
	}
	}
</script>--%>
<form id="bodyform" runat="server">
<table   cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
		    <td style="HEIGHT: 21px" align="center">
			    <p ><asp:label id="lbl_LogOn" runat="server" Font-Size="Medium" Font-Names="Arial" Font-Bold="True"><strong>Log On</strong></asp:label></p>
		    </td>
	</tr>
	<tr>
			<td  style="height:10px">&nbsp;&nbsp;&nbsp;</td>
	</tr>
	<tr>
		    <td style=" padding-left: 128px;">
			    <table cellspacing="2" cellpadding="2" border="0" >
				    <tr>
					    <td align="right">User ID:</td>
					    <td align="left"><asp:textbox id="txt_vipno" tabIndex="1" runat="server" MaxLength="20" Columns="18" EnableViewState="False"   Font-Size="Smaller" Width="135px"></asp:textbox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserID" runat="server"  Font-Size="Smaller" ControlToValidate="txt_vipno" ErrorMessage="Please enter a VIP #!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
    				
				    <tr valign="top">
					    <td  align="right">PASSWORD:</td>
					    <td align="left"><asp:textbox id="txt_Password" tabIndex="2" runat="server" MaxLength="20" Columns="18" EnableViewState="False"   TextMode="Password" Width="135px"></asp:textbox>
					    		           <asp:RequiredFieldValidator  ID="RequiredFieldValidatorPwd" runat="server" Font-Size="Smaller" ControlToValidate="txt_Password" ErrorMessage="Please enter a Password."></asp:RequiredFieldValidator>
									  
					    </td>
				    </tr>
				    <tr><td style="font:helvetica,arial;FONT-SIZE: 8pt" colspan="2" >(If this is your first time logging in enter you employee ID number.)</td></tr>
				    <tr>
                        <td align="right">ACCOUNT #:</td>
                        <td align="left">
                            <asp:textbox id="txt_acct_id" tabIndex="3" runat="server" MaxLength="20" Columns="18" EnableViewState="False" Font-Size="Smaller" Width="135px"></asp:textbox>
                       		<asp:RequiredFieldValidator  ID="RequiredFieldValidatorAcct" runat="server" Font-Size="Smaller" ControlToValidate="txt_acct_id" ErrorMessage="Please enter an Account ID."></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td align="right">SUB-ACCOUNT #:</td>
                        <td align="left">
                            <asp:textbox id="txt_sub_acct_id" tabIndex="4" runat="server"  Text="0000000000" MaxLength="20" Columns="18" EnableViewState="False" Font-Size="Smaller" Width="135px"></asp:textbox>
                       
                        </td>
                    </tr>
				    <tr>
					    <td colspan="2" align="center" style="padding-right:80px;"><br/>
						    <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="images/go_btn.gif"  />&nbsp;
                            &nbsp;<input type="image" src="images/reset.gif" onclick="javascript:document.forms[0].reset();return false;" />
						    <br/>
					    </td>
				    </tr>
			    </table>
		    </td>
	</tr>
	<tr>
		    <td align="center" style="height: 13px"><asp:label id="lbl_ErrMsg" runat="server" Font-Size="X-Small" Font-Names="Arial" EnableViewState="False" ForeColor="Red"></asp:label></td>
	</tr>
	<tr>
		    <td align="center">
			    <script  type="text/javascript" src="https://seal.verisign.com/getseal?host_name=WWW.MTCLIMOUSINE.COM&amp;size=L&amp;use_flash=YES&amp;use_transparent=NO"></script>
		    </td>
	</tr>
	<tr>    <td  style="height:45px">&nbsp;</td>
	</tr>
</table>
</form>
</asp:Content>

