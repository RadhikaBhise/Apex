<%@ Page Language="VB" MasterPageFile="~/group_MasterPageMenu.master" AutoEventWireup="false" CodeFile="group_orderconfirmno.aspx.vb" Inherits="group_orderconfirmno" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
<form id="form1" runat="server">
<table  border="0" cellpadding="0" cellspacing="0" style="background-image:url(images/mainbg.gif); width:100%; height:100%">
<tr >
<td align="left" > 
<table id="tb1" cellspacing="0" cellpadding="0" width="620" border="0"  >
            <tr >                    
                <td  align="left" colspan="2">
                    <font class="css_header">Order Completed</font>
                </td>
            </tr> 
		  
			<tr>
				<td colspan="2" align="left" style="padding-left:50px; height: 16px;">
					<font face="Arial" size="2" color="red"><b><i>Your order has been processed.</i></b></font>
				</td>
			</tr>
			<tr>
	            <td>
							       <table>
										<tr>
											<td  align="left" >
												<table cellspacing="2" cellpadding="2" border="0"  >
												<tr>
														<td class="css_desc"><b>Confirmation#</b></td>
														<td class="font2" align="left" ><asp:label id="lblConfirmationNo" Runat="server" ></asp:label></td>
													</tr>
													<tr>
														<td class="css_desc"><b>Travel Date/Time</b></td>
														<td class="font2" align="left"><asp:label id="lblReqDT" Runat="server" ></asp:label></td>
													</tr>
													<tr>
														<td class="css_desc"><b>Passenger Name</b></td>
														<td class="font2" align="left" ><asp:label id="lblFullName" Runat="server"></asp:label></td>
													</tr>
													<tr class="form">
													   <td class="css_desc"><b>Acct ID</b></td>
													   <td align="left"class="font2" ><asp:Label runat="server" ID="lblAcct"></asp:Label></td>
													</tr>
													
													<tr style="display:none">
														<td class="css_desc"><b>Agent Phone Number</b></td>
														<td class="font2" align="left" ><asp:label id="lblPhone" Runat="server" ></asp:label></td>
													</tr>
													<tr id="trAName" class="form" style="display:none">
													   <td class="css_desc"><b>Agent Name</b></td>
													   <td align="left" class="font2" ><asp:Label runat="server" ID="lblAName"></asp:Label></td>
													</tr>
													<tr class="form" id="trAEmail" style="display:none">
													   <td class="css_desc"><b>Agent Email</b></td>
													   <td align="left" class="font2"><asp:Label runat="server" ID="lblAEmail"></asp:Label></td>
													</tr>
													<tr class="form" id="trAPhone" style="display:none">
													   <td class="css_desc"><b>Agent Phone</b></td>
													   <td align="left" class="font2" ><asp:Label runat="server" ID="lblAPhone"></asp:Label></td>
													</tr>
													<tr class="form" style="display:none ">
													   <td class="css_desc"><b>Contact Phone</b></td>
													   <td align="left" class="font2"> <asp:Label runat="server" ID="lblConPhone"></asp:Label></td>
													</tr>
													<tr>
														<td class="css_desc"><b><span id="AEmail">Agent </span>Email Address</b></td>
														<td class="font2" align="left" ><asp:label id="lblEmail" Runat="server" ></asp:label></td>
													</tr>
													<tr>
														<td class="css_desc"><b>Payment Type</b></td>
														<td class="font2" align="left"><asp:label id="lblPaymentType" Runat="server" ></asp:label></td>
													</tr>
													
													<tr>
														<td class="css_desc"><b>Car Type</b></td>
														<td class="font2" align="left" ><asp:label id="lblCarType" Runat="server" CssClass="font2"></asp:label></td>
													</tr>
													 <asp:Literal ID="lit_ComReq" runat="server"></asp:Literal><tr style="display:none">
															<td class="css_desc"><b>Car #</b></td>
															<td align="left" class="font2" >
															<asp:Label runat="server" ID="lblCarDriver"></asp:Label>
															</td>
													</tr>
												  <tr style="display:none">
													<td class="css_desc"><b>Stops?</b></td>
													<td align="left" class="font2" ><asp:Label runat="server" ID="lblstops"></asp:Label></td>
												  </tr>
                                                    <tr>
                                                        <td class="css_desc"><b>Estimated Price</b></td>
                                                        <td align="left" >
                                                            
                                                                <asp:Label ID="lblEstPrice" runat="server" CssClass="font2" ></asp:Label></td>
                                                    </tr>
                                                </table>
											</td>
											<td valign="top"  align="left" >
												<table id="tdstops" runat="server" cellspacing="2" cellpadding="2" border="0" >
													<tr>
														<td class="css_header" colspan="2"><b>Stops</b></td>
														
													</tr>
													<tr id="trstop1" runat="server">
														<td class="css_desc"><b>Stop1</b></td>
														<td class="font2" ><asp:label id="lblstop1"  CssClass="font2" Runat="server"></asp:label></td>
													</tr>
													<tr id="trstop2" runat="server">
														<td class="css_desc"><b>Stop2</b></td>
														<td class="font2" ><asp:label id="lblstop2"  CssClass="font2" Runat="server"></asp:label></td>
													</tr>
													<tr id="trstop3" runat="server">
														<td class="css_desc"><b>Stop3</b></td>
														<td class="font2"><asp:label id="lblstop3"  CssClass="font2" Runat="server"></asp:label></td>
													</tr>
													<tr id="trstop4" runat="server">
														<td class="css_desc"><b>Stop4</b></td>
														<td class="font2" ><asp:label id="lblstop4"  CssClass="font2" Runat="server"></asp:label></td>
													</tr>	
													<tr id="trstop5" runat="server">
														<td class="css_desc"><b>Stop5</b></td>
														<td class="font2" ><asp:label id="lblstop5"  CssClass="font2" Runat="server"></asp:label></td>
													</tr>	
													<tr id="trstop6" runat="server">
														<td class="css_desc"><b>Stop6</b></td>
														<td class="font2" ><asp:label id="lblstop6" CssClass="font2" Runat="server"></asp:label></td>
													</tr>
													<tr id="trstop7" runat="server">
														<td class="css_desc"><b>Stop7</b></td>
														<td class="font2" ><asp:label id="lblstop7"  CssClass="font2" Runat="server"></asp:label></td>
													</tr>
													<tr id="trstop8" runat="server">
														<td class="css_desc"><b>Stop8</b></td>
														<td class="font2" ><asp:label id="lblstop8"  CssClass="font2" Runat="server"></asp:label></td>
													</tr>
													<tr id="trstop9" runat="server">
														<td class="css_desc"><b>Stop9</b></td>
														<td class="font2" ><asp:label id="lblstop9"  CssClass="font2" Runat="server"></asp:label></td>
													</tr>
													<tr id="trstop10" runat="server">
														<td class="css_desc"><b>Stop10</b></td>
														<td class="font2" ><asp:label id="lblstop10"  CssClass="font2" Runat="server"></asp:label></td>
													</tr>																																																																																										
												</table>											
												<table id="tddirection" cellspacing="2" cellpadding="2" border="0" >
													<tr>
															<td  align="left" ><!--Directions/Notes--></td><td>&nbsp;</td>
																</tr>
														<tr>
															<td colspan="2" class="font2" align="left" ><asp:Label ID="lblDirection" runat="server" ></asp:Label></td>
														</tr>
												</table>
											</td>
										</tr>
									<%--	<tr>
										
											<td valign="top" style="height: 16px" ></td>
										</tr>--%>
										<tr>
											<td valign="top" align="left"  >
											
												<table id="tdpu" runat="server" cellspacing="2" cellpadding="2" border="0" >
													<tr>
														<td class="css_header" colspan="2"><b>Pickup</b></td>
														
													</tr>
													<tr>
														<td class="css_desc"><b>State</b></td>
														<td class="font2"><asp:label id="lblPState" Runat="server" ></asp:label></td>
													</tr>
													<tr>
														<td class="css_desc"><b>Address</b></td>
														<td class="font2"><asp:label id="lblPAddress" Runat="server" ></asp:label></td>
													</tr>
													<tr>
														<td class="css_desc"><b>City</b></td>
														<td class="font2" ><asp:label id="lblPTown" Runat="server"></asp:label></td>
													</tr>
													<tr style="display:none">
														<td class="css_desc"><b>County</b></td>
														<td class="font2" ><asp:label id="lblPCounty" runat="server" ></asp:label></td>
													</tr>
													
													<tr style="display:none" >
														<td class="css_desc"><b>Bldg No</b></td>
														<td class="font2" ><asp:label id="lblPArea" Runat="server" ></asp:label></td>
													</tr>
													<tr>
														<td class="css_desc"><b>Point</b></td>
														<td class="font2"><asp:label id="lblPPoint" Runat="server" ></asp:label></td>
													</tr>
													<tr>
									                    <td class="css_desc"><b>Directions</b></td>
									                    <td class="font2" ><asp:label id="lblPDirection" Runat="server" ></asp:label></td>
								                    </tr>
												</table>
												<table id="tdpuairport" runat="server" cellspacing="2" cellpadding="2" border="0" >
													<tr>
														<td class="css_header" colspan="2"><b>Pickup</b></td>
														
													</tr>
													<tr>
														<td class="css_desc"><b>Arrival Airport</b></td>
														<td class="font2"><asp:label id="lblPairport" Runat="server" ></asp:label></td>
													</tr>
													<tr>
														<td class="css_desc"><b>Arrival Airline Name</b></td>
														<td class="font2" ><asp:label id="lblPAirName" Runat="server" ></asp:label></td>
													</tr>
													
													<tr>
														<td class="css_desc"><b>Arrival Flight #/Tail #</b></td>
														<td class="font2"><asp:label id="lblPAirFli" Runat="server" ></asp:label></td>
													</tr>
													<tr>
														<td class="css_desc"><b>Arrival FBO/Terminal</b></td>
														<td class="font2"><asp:label id="lblPAirFbo" Runat="server" ></asp:label></td>
													</tr>
													<tr style="display:none">
														<td class="css_desc"><b>Arrival Time</b></td>
														<td class="font2" ><asp:label id="lblPAirTime" Runat="server" ></asp:label></td>
													</tr>
													<tr>
														<td class="css_desc"><b>Airline Pickup Point</b></td>
														<td class="font2"><asp:label id="lblPuAirpoint" runat="server" ></asp:label></td>
														
													</tr>
													
													<tr>
														<td class="css_desc"><b>Arrival City</b></td>
														<td class="font2" ><asp:label id="lblPCity" Runat="server" ></asp:label></td>
													</tr>
													<tr>
									                    <td class="css_desc"><b>Directions</b></td>
									                    <td class="font2" ><asp:label id="lblPAirDirection" Runat="server" ></asp:label></td>
								                    </tr>
												</table>
											</td>
											<td valign="top"  align="left">
												<table id="tddest" runat="server" cellspacing="2" cellpadding="2" width="100%" border="0">
															<tr>
														<td class="css_header" colspan="2"><b>Destination</b></td>
													
													</tr>
													<tr>
														<td class="css_desc"><b>State</b></td>
														<td class="font2"  align="left"><asp:label id="lblDstate" Runat="server" ></asp:label></td>
													</tr>
													<tr>
														<td class="css_desc"><b>Address</b></td>
														<td class="font2"  align="left"><asp:label id="lblDAddress" Runat="server" ></asp:label></td>
													</tr>
													<tr>
														<td class="css_desc"><b>City</b></td>
														<td class="font2"  align="left"><asp:label id="lblDTown" Runat="server" ></asp:label></td>
													</tr>
													<tr style="display:none">
														<td class="css_desc"><b>County</b></td>
														<td class="font2"  align="left"><asp:label id="lblDCounty" runat="server" ></asp:label></td>
													</tr>
													
													<tr style="display:none">
														<td class="css_desc"><b>Bldg No</b></td>
														<td class="font2"  align="left"><asp:label id="lblDArea" Runat="server" ></asp:label></td>
													</tr>
													<tr>
														<td class="css_desc"><b>Point</b></td>
														<td class="font2" align="left"><asp:label id="lblDPoint" Runat="server"></asp:label></td>
													</tr>
													<tr>
								                        <td class="css_desc"><b>Directions</b></td>
								                        <td class="font2" ><asp:label id="lblDDirection" Runat="server" ></asp:label></td>
							                        </tr> 
													</table>
												
													  <table id="tddestairport" runat="server" cellspacing="2" cellpadding="2" border="0" >
														<tr>
														    <td  class="css_header" colspan="2"><b>Destination</b></td>
														
													    </tr>
													    <tr>
														    <td  class="css_desc"><b>Departure Airport</b></td>
														    <td class="font2"  align="left" ><asp:label id="lblDairport" Runat="server" ></asp:label></td>
														    <%--<td style="width:60px; height: 19px;"></td>--%>
													    </tr>
													    <tr>
														    <td  class="css_desc"><b>Departure Airline Name</b></td>
														    <td class="font2"  align="left"><asp:label id="lblDairname" Runat="server" ></asp:label></td>
														    <%--<td style="width:60px"></td>--%>
													    </tr>
													    <tr>
														    <td class="css_desc"><b>Departure Flight #/Tail #</b></td>
														    <td class="font2"  align="left"><asp:label id="lblDestAirFlight" Runat="server" ></asp:label></td>
														    <%--<td style="width:60px"></td>--%>
													    </tr>
													    <tr>
														    <td class="css_desc"><b>Departure FBO/Terminal</b></td>
														    <td class="font2" align="left"><asp:label id="lblDAirFbo" Runat="server"></asp:label></td>
														    <%--<td style="width:60px"></td>--%>
													    </tr>
													    <tr style="display: none">
														    <td class="css_desc"><b>Arrival Time</b></td>
														    <td class="font2" align="left"><asp:label id="lblDairtime" Runat="server" ></asp:label></td>
													    <%--	<td style="width:60px"></td>--%>
													    </tr>
													    <tr style="display:none">
														    <td class="css_desc"><b>Destination City</b></td>
														    <td class="font2"  align="left"><asp:label id="lblDestAirDepartingCity" Runat="server"></asp:label></td>
														    <%--<td style="width:60px"></td>--%>
													    </tr>
													    <tr>
										                    <td class="css_desc"><b>Directions</b></td>
										                    <td class="font2" ><asp:label id="lblDAirDirection" Runat="server" ></asp:label></td>
									                    </tr>
												     </table>
												</td>
											
										</tr>
									<%--	<tr>
											<td  colspan="2">
													<table id="Table1" cellspacing="2" cellpadding="2" width="100%" border="0">
														<tbody>															
														</tbody>
													</table>
												
											</td>
										</tr>
										<tr>
											<td width="100%" colspan="2" style="height: 21px">
												
											</td>
										</tr>--%>										
										<tr>
											<td align="left">
											    <img alt="" runat="server" src="images/ride inquiry.gif" style="cursor:hand" onclick="javascript:window.location='rideinquiry.aspx';" id="Submit"/>&nbsp;
                                                <img alt="" src="images/logout.gif" style="cursor:hand" onclick="javascript:window.location='index.aspx?action=logout';" id="btnLogout" />
										  </td>
											<td id="trPrint" style="display:none;" align="left">
											    <asp:Button ID="btnPrint" runat="server" Text="Print Trip" />
											</td>
										</tr>
										
									</table>
								</td>
							</tr>
							
							 <tr>
								<td align="center"  >
								    <input type="hidden" id="hdnFrom" runat="server" />
                                    <asp:TextBox ID="txtShowType" runat="server" Visible="False" >0</asp:TextBox></td>
							 </tr>
						</table>
					</td>
				</tr>
				

</table>
</form>
</asp:Content>

