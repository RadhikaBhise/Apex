<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RptOfZone.aspx.vb" Inherits="RptOfZone" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<script language="javascript" type="text/javascript" src="JS/report.js"></script>
<form id="Form1" runat="server">
			<table cellspacing="0" cellpadding="0" width="800px" align="center" border="0" class="tb-bg">
				<tr>
					<td align="center" >
						<table height="90" cellspacing="0" cellpadding="0" width="570" border="0">
							<tr>
								<td align="center" colSpan="2"><font face="Arial" color="darkblue" size="5"><b>Account Zone Analysis Report</b></font>
									<br/>
									<br/>
									<table cellspacing="1" cellpadding="0" border="0">
										<tr>
											<td class="bodyfont">
												<table cellspacing="1" cellpadding="2" bgColor="gray" border="0">
												    <tr align ="center" class="bodyfont" id="trSelAcct" runat ="server">
												    <td colspan="2"><big><b><font face="Arial" color="#ffffff" size="3">Select Account:</font></b></big></td>
												    </tr>
												    <tr align="center" bgColor="lightgrey" id="trSelList" runat ="server">
												     <td colspan="2"><asp:ListBox ID="listAcct" runat ="server" SelectionMode="Multiple" Width ="130" Height ="160" AutoPostBack="True"></asp:ListBox></td>
												    </tr>
													<tr align="center" class="bodyfont">
														<td align="center" colspan="2"><big><b><font face="Arial" color="#ffffff" size="3">Zone Range:</font></b></big></td>
													</tr>
													<tr align="center" bgColor="lightgrey">
														<td align="center" colspan="2"><asp:RadioButton ID="radAtoA" runat ="server" GroupName ="radMethord" Text="Airport to Airport" Checked ="true"/>
														<asp:RadioButton ID="radAtoC" runat ="server" GroupName ="radMethord" Text="Airport to City"/><asp:RadioButton ID="radCtoA" runat ="server" GroupName ="radMethord" Text="City to Airport " />
														<asp:RadioButton ID="radCtoC" runat ="server" GroupName ="radMethord" Text="City to City"/></td>
														
													</tr>
													<tr align="center" class="bodyfont">
														<td><big><b><font face="Arial" color="#ffffff" size="3">Pick Up</font></b></big></td>
														<td><big><b><font face="Arial" color="#ffffff" size="3">Drop Off</font></b></big></td>
													</tr>
													<tr align="center" bgColor="lightgrey" style="height:30px">
														<td style="HEIGHT: 15px">
														  <table cellpadding ="0" cellspacing ="0" border ="0" style="height:15px">
														   <tr id="trLAir" runat ="server" valign="top"><td align="left">Airport Name:<asp:TextBox ID="txtlAir" runat ="server"></asp:TextBox><asp:Button ID="btnLsearch" runat ="server" Text="Search" /></td></tr>
														   <tr id="trLAirList" runat ="server"><td align="left">&nbsp;<asp:datalist id="dlstPAirport" runat="server" CssClass="form"><ItemTemplate><asp:HyperLink runat="server" ID="hyPAirName"></asp:HyperLink></ItemTemplate></asp:datalist></td></tr>
														 <tr id="trLState" runat ="server" valign="top"><td align="left">State:<asp:DropDownList ID="ddlLstate" runat ="server"></asp:DropDownList></td></tr>
														 <tr id="trLCity" runat ="server"><td align="left">City:&nbsp;
                                                             <asp:TextBox ID="txtLcity" runat ="server"></asp:TextBox>
                                                             <asp:Button ID="btnPCity_Search" runat="server" Text="Search" /><br />
                                                             <asp:datalist id="dglstPCity" runat="server" CssClass="form">
                                                                 <ItemTemplate>
                                                                     <asp:HyperLink ID="hyPCityName" runat="server"></asp:HyperLink>
                                                                 </ItemTemplate>
                                                             </asp:datalist></td></tr>
														  </table>
														</td>
														<td style="HEIGHT: 15px"><table cellpadding ="0" cellspacing ="0" border ="0" style="height:15px" >
														   <tr id="trRAir" runat ="server" valign="top" ><td align="left">Airport Name:<asp:TextBox ID="txtrAir" runat ="server" Width="112px" Height="15px"></asp:TextBox><asp:Button ID="btnRsearch" runat ="server" Text="Search" /></td></tr>
														   <tr id="trRAirList" runat ="server"><td align="left">&nbsp;<asp:datalist id="dlstDAirport" runat="server" CssClass="form"><ItemTemplate><asp:HyperLink runat="server" ID="hyDAirName"></asp:HyperLink></ItemTemplate></asp:datalist></td></tr>
														  <tr id="trRState" runat ="server" valign="top"><td align="left">State:<asp:DropDownList ID="ddlRstate" runat ="server"></asp:DropDownList></td></tr>
														 <tr id="trRCity" runat ="server"><td align="left">City:&nbsp;
                                                             <asp:TextBox ID="txtRcity" runat ="server"></asp:TextBox>
                                                             <asp:Button ID="btnDCity_Search" runat="server" Text="Search" /><br />
                                                             <asp:datalist id="dglstDCity" runat="server" CssClass="form">
                                                                 <ItemTemplate>
                                                                     <asp:HyperLink ID="hyDCityName" runat="server"></asp:HyperLink>
                                                                 </ItemTemplate>
                                                             </asp:datalist></td></tr>
														  </table></td>
													</tr>
													<tr align="center" bgColor="lightgrey" id="trReserve" runat ="server">
														<td style="HEIGHT: 15px" colspan="2"><asp:CheckBox ID="chkReserve" runat= "server" Text ="Click here to also view reserve(Dropoff to Pickup)" /></td>
													</tr>
													<tr align="center" class="bodyfont">
														<td><big><b><font face="Arial" color="#ffffff" size="3">From Date</font></b></big></td>
														<td><big><b><font face="Arial" color="#ffffff" size="3">To Date</font></b></big></td>
													</tr>
													<tr align="center" bgColor="lightgrey">
														<td style="HEIGHT: 15px"><asp:textbox id="txt_FromTrip" runat="server" size="10" maxLength="10"></asp:textbox></td>
														<td style="HEIGHT: 15px"><asp:textbox id="txt_ToTrip" runat="server" size="10" maxLength="10"></asp:textbox></td>
													</tr>
													<tr align="center" bgColor="lightgrey">
														<td colSpan="2"><font class="font1"><asp:RadioButton ID="radTip" runat ="server" GroupName ="radDate" Text="Trip Date" Checked =true/>
														<asp:RadioButton ID="radInvoice" runat ="server" GroupName ="radDate" Text="Invoice Date"/>
														</font>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<br/>
									<asp:button id="btn_Submit" Runat="server" Text="Submit"></asp:button>&nbsp;&nbsp;<asp:button id="btn_Reset" Runat="server" Text="Reset"></asp:button><br/>
								</td>
							</tr>
							<tr>
								<td align="center"><br/>
									<br/>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			
				<tr>
					<td align="center"><a href="rptmenu.aspx">Report Menu</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="default.aspx">Main Menu</a></td>
				</tr>
				<tr>
                <td align="center" style="height:40px">
                </td>
            </tr>
			</table>
		</form>
<script language="javascript">
AirOrCity();
</script>
</asp:Content>

