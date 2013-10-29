<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="loginadmin.aspx.vb" Inherits="loginadmin" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<script language="JavaScript" type="text/javascript">
	function validate(){
	if(document.forms[0].ctl00_MainContent_txt_AcctID.value == "" || document.forms[0].ctl00_MainContent_txt_AcctID.value.length == 0){
		alert("A username is required in order to access the data.  Please input a username!");
		document.forms[0].ctl00_MainContent_txt_AcctID.focus();
		return false;
	}
	if (document.forms[0].ctl00_MainContent_txt_pwd.value.length < 1) {
		window.alert("A password is required in order to access the data.  Please input a password!");
		document.forms[0].ctl00_MainContent_txt_pwd.focus();
		return false;
	}
	if(document.forms[0].ctl00_MainContent_txt_subAcctid.value.length < 1) {
		document.forms[0].ctl00_MainContent_txt_subAcctid.value = "0000000000";
	}
	return true;
	}
</script>
<form id="bodyform" runat="server">
   <table  style="height:90px" cellspacing="0" cellpadding="0" width="100%" border="0">
     <tr>
						<td style="HEIGHT: 21px">
							<p align="right"><asp:label id="lbl_LogOn" runat="server" Font-Size="Medium" Font-Names="Arial" Font-Bold="True"><strong>Admin Log On</strong></asp:label></p>
						</td>
					</tr>
					<tr>
								<td  style="height :10px">&nbsp;&nbsp;&nbsp;</td>
								</tr>
					<tr>
						<td align="center">
							<table cellspacing="2" cellpadding="2" border="0" >
								<tr>
									<td align="right"><span class="gray_12_b">ACCOUNT #:</span></td>
									<td align="center"><asp:textbox id="txt_AcctID" tabIndex="1" runat="server" MaxLength="20" Columns="18" EnableViewState="False"	Font-Size="Smaller" Width="135px"></asp:textbox></td></tr>
								
								<tr>
									<td valign="top" align="right"><span class="gray_12_b">SUB-ACCOUNT #:</span></td>
									<td align="center"><asp:textbox id="txt_subAcctid" tabIndex="2" runat="server" MaxLength="20" Columns="18" EnableViewState="False" Width="135px">0000000000</asp:textbox><font style="FONT-SIZE: 8pt" face="helvetica,arial" size="1"></font></td>
								</tr>
								<tr>
									<td valign="top" align="right"><span class="gray_12_b">PASSWORD:</span></td>
									<td align="center"><asp:textbox id="txt_pwd" tabIndex="2" runat="server" MaxLength="20" Columns="18" EnableViewState="False" TextMode="Password" Width="135px"></asp:textbox></td>
								</tr>
								<tr>
									<td valign="top" align="right"><span class="gray_12_b">COMPANY:</span></td>
									<td align="center">
                                        <asp:DropDownList ID="ddlCompany" runat="server" Width="142px">
                                            <asp:ListItem Value="1">NYC2Way</asp:ListItem>
                                            <asp:ListItem Value="2">Aristacar</asp:ListItem>
                                            <asp:ListItem Value="3">CTG</asp:ListItem>
                                        </asp:DropDownList></td>
								</tr>
								<tr>
									<td align="center" colspan="2"><br>
										<asp:button id="btn_Login" tabIndex="3" runat="server" Width="70px" Text="GO"></asp:button>&nbsp;
										<asp:button id="btn_Clear" tabIndex="4" runat="server" Text="CLEAR"></asp:button><br/>
									</td>
								</tr>
							</table>
							<%--<a href="login.aspx">Click here for user login</a>--%>
						</td>
					</tr>
					<tr>
						<td align="center"><asp:label id="lbl_ErrMsg" runat="server" Font-Size="X-Small" Font-Names="Arial" EnableViewState="False"
								ForeColor="Red"></asp:label></td>
					</tr>
					<tr>
						<td align="center">
							<script  type="text/javascript" src="https://seal.verisign.com/getseal?host_name=WWW.MTCLIMOUSINE.COM&amp;size=L&amp;use_flash=YES&amp;use_transparent=NO"></script>
						</td>
					</tr>
					<tr><td  style="height:45">&nbsp;</td></tr>
   </table>
 </form>
</asp:Content>


