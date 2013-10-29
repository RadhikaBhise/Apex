<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RptOfPass.aspx.vb" Inherits="RptOfPass" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<form id="Form1" method="post" runat="server">
			<table cellspacing="0" cellpadding="0" width="800px" align="center" border="0" class="tb-bg">
				<tr>
					<td align="center">
						<table height="90" cellspacing="0" cellpadding="0" width="570" border="0">
							<tr>
								<td align="center" colSpan="2" align="center"><font face="Arial" color="darkblue" size="5"><b>Top Passenger  
											Report</b></font>
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
														<td><big><b><font face="Arial" color="#ffffff" size="3">Sort By:</font></b></big></td>
														<td><big><b><font face="Arial" color="#ffffff" size="3">Top:</font></b></big></td>
													</tr>
													<tr align="center" bgColor="lightgrey">
														<td><asp:dropdownlist id="lst_SortBy" Runat="server">
																<asp:ListItem Value="1" Selected="True">Amount</asp:ListItem>
																<asp:ListItem Value="2">Number of Rides</asp:ListItem>
															</asp:dropdownlist></td>
														<td><asp:textbox id="txt_Top" runat="server" size="3" maxLength="3"></asp:textbox></td>
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
</asp:Content>

