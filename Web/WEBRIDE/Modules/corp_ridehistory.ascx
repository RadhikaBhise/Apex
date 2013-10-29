<%@ Control Language="VB" AutoEventWireup="false" CodeFile="corp_ridehistory.ascx.vb" Inherits="Modules_corp_ridehistory" %>
<table width="800" border="0" cellspacing="0" cellpadding="0">
 <tr>
  <td align="center"><asp:DataGrid id="dgRides" runat="server" AlternatingItemStyle-BorderColor="#FFFFFF" BackColor="White" AllowSorting="True" AllowPaging="True" PageSize="15" AutoGenerateColumns="False" Width="80%">
													<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
													<ItemStyle Height="30px" BackColor="White"></ItemStyle>
													<HeaderStyle Height="25px" BackColor="#A2ABC4" ForeColor="Black"></HeaderStyle>
													<Columns>
												<asp:TemplateColumn SortExpression="confirmation_no" HeaderText="Conf#">
															<HeaderStyle Width="40px"></HeaderStyle>
															<ItemTemplate>
																<asp:HyperLink id="hy1" CssClass="GridFont1" Runat="server" Width="50px"></asp:HyperLink>
																
															</ItemTemplate>
														</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="Status_flag" HeaderText="Status_flag">
													<HeaderStyle Width="78px"></HeaderStyle>
													<ItemTemplate>
													        <asp:Label id="lblStatus" Width="50px" Runat="server" CssClass="GridFont1"></asp:Label><br />
													        <asp:HyperLink id="hylkprint" CssClass="GridFont1" ForeColor="blue" Runat="server" Width="80px"></asp:HyperLink>
													    </ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="Name" HeaderText="Name">
													<HeaderStyle Width="50px"></HeaderStyle>
													<ItemTemplate>
													        <asp:Label id="lblName" Width="50px" Runat="server" CssClass="GridFont1"></asp:Label>
													    </ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="pu_st_no" HeaderText="Pick Up">
													<HeaderStyle Width="90px"></HeaderStyle>
													    <ItemTemplate>
													        <asp:Label id="lblPuAddress" Width="90px" Runat="server" CssClass="GridFont1"></asp:Label>
													    </ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="dest_st_no" HeaderText="Destination">
													<HeaderStyle Width="90px"></HeaderStyle>
													<ItemTemplate>
													        <asp:Label id="lblDestAddress" Width="90px" Runat="server" CssClass="GridFont1"></asp:Label>
													    </ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="display_date_time" HeaderText="Travel Date">
															<ItemTemplate>
																<asp:Label id="lblReq_date_time" Runat="server" Width="70px" CssClass="GridFont1"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="eta_time" HeaderText="ETA">
															<ItemTemplate>
																<asp:Label id="lblETA"  Runat="server" Width="20px" CssClass="GridFont1"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="car_no" HeaderText="Car#">
															<ItemTemplate>
																<asp:Label id="lblCarNo" Runat="server" Width="20px" CssClass="GridFont1"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Action">
													<HeaderStyle Width="80px"></HeaderStyle>
													<ItemTemplate>
																	<asp:Label id="lblShow" Runat="server" Visible="False" CssClass="GridFont1">To Cancel/Modify Order Call</asp:Label><br />
																	<asp:Image id="img1" Runat="server" Visible="False" ImageUrl="../Images/r_arrow.gif"></asp:Image>&nbsp;
																	<asp:LinkButton id="lbCancel" Runat="server" width="80px" CssClass="GridFont1" text="Cancel Order" Visible="False" CommandName="OnClick"></asp:LinkButton><br>
																	<asp:Image id="img2" Runat="server" Visible="False" ImageUrl="../Images/r_arrow.gif"></asp:Image>&nbsp;
																	<asp:HyperLink id="hyModify" Runat="server" width="80px" Visible="False" CssClass="GridFont1">Modify Order</asp:HyperLink><br>
													</ItemTemplate>
													</asp:TemplateColumn>
											</Columns>
													<PagerStyle Mode="NumericPages"></PagerStyle>
												</asp:DataGrid>
												<asp:DataGrid id="dgExcel" runat="server" AlternatingItemStyle-BorderColor="#FFFFFF" BackColor="White" AllowSorting="True" AllowPaging="True" PageSize="15" AutoGenerateColumns="False" Width="100%">
													<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
													<ItemStyle Height="30px" BackColor="White"></ItemStyle>
													<HeaderStyle Height="25px" BackColor="#A2ABC4" ForeColor="Black"></HeaderStyle>
													<Columns>
												<asp:TemplateColumn SortExpression="confirmation_no" HeaderText="CONFIRMATION #">
															<HeaderStyle Width="40px"></HeaderStyle>
															<ItemTemplate>
																<asp:HyperLink id="hy1" CssClass="GridFont1" Runat="server" Width="50px"></asp:HyperLink>																
															</ItemTemplate>
														</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="Status_flag" HeaderText="STATUS FLAG">
													<HeaderStyle Width="78px"></HeaderStyle>
													<ItemTemplate>
													        <asp:Label id="lblStatus" Width="50px" Runat="server" CssClass="GridFont1"></asp:Label><br />													        
													    </ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="lname" HeaderText="LAST NAME">
													<HeaderStyle Width="50px"></HeaderStyle>
													<ItemTemplate>
													        <asp:Label id="lblLName" Width="50px" Runat="server" CssClass="GridFont1"></asp:Label>
													    </ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="fname" HeaderText="FIRST NAME">
													<HeaderStyle Width="50px"></HeaderStyle>
													<ItemTemplate>
													        <asp:Label id="lblFName" Width="50px" Runat="server" CssClass="GridFont1"></asp:Label>
													    </ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="display_date_time" HeaderText="TRAVEL DATE">
															<ItemTemplate>
																<asp:Label id="lblReq_date_time" Runat="server" Width="70px" CssClass="GridFont1"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>	
												<asp:TemplateColumn SortExpression="car_no" HeaderText="CAR #">
															<ItemTemplate>
																<asp:Label id="lblCarNo" Runat="server" Width="20px" CssClass="GridFont1"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>	
												<asp:TemplateColumn SortExpression="eta_time" HeaderText="ETA">
															<ItemTemplate>
																<asp:Label id="lblETA"  Runat="server" Width="20px" CssClass="GridFont1"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>																																						
												<asp:TemplateColumn SortExpression="pu_st_no" HeaderText="PICK UP">
													<HeaderStyle Width="90px"></HeaderStyle>
													    <ItemTemplate>
													        <asp:Label id="lblPuAddress" Width="90px" Runat="server" CssClass="GridFont1"></asp:Label>
													    </ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="dest_st_no" HeaderText="DROP OFF">
													<HeaderStyle Width="90px"></HeaderStyle>
													<ItemTemplate>
													        <asp:Label id="lblDestAddress" Width="90px" Runat="server" CssClass="GridFont1"></asp:Label>
													    </ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="net" HeaderText="FINAL BILLED (if status is COMPLETED)">
													<HeaderStyle Width="90px"></HeaderStyle>
													<ItemTemplate>
													        <asp:Label id="lblNet" Width="90px" Runat="server" CssClass="GridFont1"></asp:Label>
													    </ItemTemplate>
												</asp:TemplateColumn>	
												<asp:TemplateColumn SortExpression="auth_person" HeaderText="AUTH PERSON">
													<HeaderStyle Width="90px"></HeaderStyle>
													<ItemTemplate>
													        <asp:Label id="lblauth_person" Width="90px" Runat="server" CssClass="GridFont1"></asp:Label>
													    </ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
													<PagerStyle Mode="NumericPages"></PagerStyle>
												</asp:DataGrid> <TABLE id="Table4" cellSpacing="1" cellPadding="1" border="0" style="width: 80%">
										<TR>
											<TD class="font1" style="WIDTH: 90px; height: 22px;" align="right"></TD>
											<TD style="WIDTH: 497px; height: 22px;" align="left"><asp:label id="lblCountRide" runat="server" CssClass="font2" Height="16px" Font-Size="11px" ></asp:label></TD>
											<TD class="font" style="height: 22px"><asp:label id="lblPage" runat="server" CssClass="text2" Font-Size="11px">Page: </asp:label></TD>
											<TD class="form" style="height: 22px"><asp:dropdownlist id="ddlPage" runat="server" CssClass="text2" Font-Size="11px" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD class="form" style="height: 22px"><asp:Button ID="btnExcel" runat ="server" Text ="Export To Excel Format" /></TD>
										</TR>
									</TABLE>	
									
  </td></tr>
  <tr><td><table id="showtable" cellSpacing="0" cellPadding="0" border="1" style="width: 100%" bordercolor="white">
										<tr><td colspan="2" class="font" align="left"><span class="GridFont1"><b>Status Flags</b></span></td></tr>
										<tr>
											<td class="orderformtd" style="width: 8px; height: 16px;"><font class="GridFont"><b>&nbsp;LIVE&nbsp;</b></font>
											</td>
											<td align="left" style="width: 310px; height: 16px;"><font class="css_text_font1">This order will be processing soon.</font>
											</td>
										</tr>
										<tr>
											<td class="orderformtd" style="height: 16px; width: 8px;"><font class="GridFont"><b>&nbsp;RESERVATION&nbsp;</b></font>
											</td>
											<td align="left" style="height: 16px; width: 400px;"><font class="css_text_font1">This is a reservation call and will be dispatched at the requested time.</font>
											</td>
										</tr>
										<tr>
											<td class="orderformtd" style="height: 16px; width: 8px;"><font class="GridFont"><b>&nbsp;PROCESSING&nbsp;</b></font>
											</td>
											<td align="left" style="height: 16px; width: 310px;"><font class="css_text_font1">This order is currently processing and is locating a car.</font>
											</td>
										</tr>
										<tr>
											<td class="orderformtd" style="height: 16px; width: 8px;"><font class="GridFont"><b>&nbsp;DISPATCHED&nbsp;</b></font>
											</td>
											<td align="left" style="height: 16px; width: 400px;"><font class="css_text_font1">This order has been dispatched, please meet at the pickup address.</font>
											</td>
										</tr>
										<tr>
											<td class="orderformtd" style="width: 8px; height: 16px;"><font class="GridFont"><b>&nbsp;CONFIRMED&nbsp;</b></font>
											</td>
											<td align="left" style="width: 310px; height: 16px;"><font class="css_text_font1">This order has been completed.</font>
											</td>
										</tr>
										<tr>
											<td class="orderformtd" style="width: 8px; height: 16px;"><font class="GridFont"><b>&nbsp;COMPLETED&nbsp;</b></font>
											</td>
											<td align="left" style="width: 310px; height: 16px;"><font class="css_text_font1">This order has been completed and billed</font>
											</td>
										</tr>
										</table>
  </td></tr>
  <tr>
  <td height="15px"></td></tr>
  </table>