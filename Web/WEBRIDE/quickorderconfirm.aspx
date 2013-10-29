<%@ Page Language="VB" MasterPageFile="MasterPageQuick.master" AutoEventWireup="false" CodeFile="quickorderconfirm.aspx.vb" Inherits="quickorderconfirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
    <script type="text/javascript" language="javascript" src="js/common.js"></script>
    
    <form id="form1" runat="server">
        <table  border="0" cellpadding="0" cellspacing="0" style="background-image:url(images/mainbg.gif); width:100%; height:100%">
            <tr>
                <td align="left" > 
                    <table id="tb1" cellspacing="0" cellpadding="0" width="620"  border="0">
                        <tr >                    
                            <td  align="left"  class="css_header">Quick Ride Verification
                            </td>
                        </tr> 
	                    <tr> <!-- Left Margin //-->
		                    <!-- Main Body   //-->
		                    <td >
			                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
				                    <tr>
					                    <td align="left" colspan="2" style="height: 80px">
						                    <font face="arial" size="1">- Please verify your order, and click "Place Order" to place your order.<br/>
										                                - If you do not hit "Place Order", your order will not be placed.<br/>
										                                - If you want to change your order, please click the "Back To Order Form" link<br/>
						                    </font>
					                    </td>
				                    </tr>
				                    <tr>
					                    <td >
						                    <table width="100%">
							                    <tr>
								                    <td  valign="top" align ="left">
									                    <table cellspacing="2" cellpadding="2" border="0">
										                    <tr>
											                    <td class="css_desc"><b>Travel Date/Time</b></td>
											                    <td align="left" class="font2" ><asp:label id="lblReqDT" Runat="server" ></asp:label></td>
										                    </tr>
										                    <tr>
											                    <td class="css_desc"><b>Passenger Name</b></td>
											                    <td align="left" class="font2"><asp:label id="lblFullName" Runat="server" ></asp:label></td>
										                    </tr>
										                    <tr>
											                    <td class="css_desc" ><b>Acct ID</b></td>
											                    <td align="left" class="font2" ><asp:label id="lblAcct" Runat="server" ></asp:label></td>
										                    </tr>
										                    <tr>
											                    <td class="css_desc"><b><span id="APhone" style="display:none;">Agent </span>Phone Number</b></td>
											                    <td align="left" class="font2"><asp:label id="lblPhone" Runat="server" ></asp:label></td>
										                    </tr>
										                    <tr>
											                    <td class="css_desc"><b><span id="AEmail" style="display:none;">Agent </span>Email Address</b></td>
											                    <td align="left" class="font2" ><asp:label id="lblEmail" Runat="server"></asp:label></td>
										                    </tr>
										                    <asp:repeater id="rptComp" runat="server">
											                    <ItemTemplate>
												                    <tr>
													                    <td class="color-label"><font class="bodyfont"><%# DataBinder.Eval(Container.DataItem, "req_desc") %></font></td>
													                    <td>
														                    <asp:label CssClass="font2" id='comp_value' Text='<%# DataBinder.Eval(Container.DataItem, "value") %>' runat="server" >
														                    </asp:label>
														                    <asp:Label ID="comp_id" text='<%# DataBinder.Eval(Container.DataItem, "id") %>' Visible="False" Runat="server" >
														                    </asp:Label>
													                    </td>
												                    </tr>
											                    </ItemTemplate>
										                    </asp:repeater>
										                    <tr style="display:none">
											                    <td class="css_desc"><b>Contact Phone</b></td>
											                    <td class="font2" align="left" ><asp:label id="lblConPhone" runat="server" ></asp:label></td>
										                    </tr>
										                    <tr>
											                    <td class="css_desc"><b>Payment Type</b></td>
											                    <td align="left" class="font2" ><asp:label id="lblPayment" runat="server" ></asp:label></td>
										                    </tr>
										                    <tr>
											                    <td class="css_desc"><b>Car Type</b></td>
											                    <td align="left" class="font2" ><asp:label id="lblCarType" Runat="server" ></asp:label></td>
										                    </tr>
                    										
										                    <asp:Literal ID="lit_ComReq" runat="server"></asp:Literal><tr>
                                                                <td  class="css_desc"><b>Estimated Price</b></td>
                                                                <td class="font2" align="left">
                                                                   
                                                                        <asp:Label ID="lblEstPrice" runat="server" CssClass="font2" ></asp:Label></td>
                                                            </tr>
									                    </table>
                                                        </td>
								                    <td valign="top" style="width: 267px; ">
									                    <table id="tdstops" cellspacing="2" cellpadding="2" width="100%" border="0">
										                    <tr>
												                    <td  align="left" ><!--Directions/Notes--></td><td>&nbsp;</td>
													                    </tr>
											                    <tr>
												                    <td colspan="2"' class="font2" align="left" ><asp:Label ID="lblDirection" runat="server" ></asp:Label></td>
											                    </tr>
									                    </table>
								                    </td>
							                    </tr>
							                    <tr>
								                    <td valign="top" colspan="2">
								                    <table width ="100%">
								                    <tr>
								                    <td valign="top" colspan="2"  align="left" >
                    								
									                    <table id="tdpu" cellspacing="2" cellpadding="2" border="0" runat="server">
										                    <tr>
											                    <td class="css_header" colspan="2">Pickup</td>
                    											
										                    </tr>
									                        <tr>
											                    <td class="css_desc"><b>Bldg No</b></td>
											                    <td class="font2" ><asp:label id="lblPBlogNo" Runat="server" ></asp:label></td>
										                    </tr>
										                    <tr>
											                    <td class="css_desc"><b>Street Name</b></td>
											                    <td class="font2" ><asp:label id="lblPStName" runat="server" ></asp:label></td>
										                    </tr>
										                    <tr>
											                    <td class="css_desc"><b>City</b></td>
											                    <td class="font2" ><asp:label id="lblPuCity" runat="server" ></asp:label></td>
										                    </tr>
										                    <tr>
											                    <td class="css_desc"><b>State</b></td>
											                    <td class="font2" ><asp:label id="lblState" Runat="server" ></asp:label></td>
										                    </tr>
										                    <tr>
											                    <td class="css_desc"><b>Pickup Point</b></td>
											                    <td class="font2" ><asp:label id="lblPuPoint" Runat="server" ></asp:label></td>
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
											                    <td class="font2" ><asp:label id="lblPAirName" Runat="server"></asp:label></td>
										                    </tr>
										                    <tr>
											                    <td class="css_desc"><b>Arrival Flight #/Tail #</b></td>
											                    <td class="font2" ><asp:label id="lblPAirFli" Runat="server" ></asp:label></td>
										                    </tr>
										                    <tr>
											                    <td class="css_desc"><b>Arrival FBO/Terminal</b></td>
											                    <td class="font2"><asp:label id="lblPairfbo" Runat="server" ></asp:label></td>
										                    </tr>
										                    <tr style="display:none">
											                    <td class="css_desc"><b>Arrival Time</b></td>
											                    <td class="font2"  ><asp:label id="lblPairtime" Runat="server" ></asp:label></td>
										                    </tr>
										                    <tr>
											                    <td class="css_desc"><b>Airline Pickup Point</b></td>
											                    <td class="font2"><asp:label id="lblAirPu" Runat="server" ></asp:label></td>
										                    </tr>
                    										
										                    <tr>
											                    <td class="css_desc"><b>Arrival City</b></td>
											                    <td class="font2" ><asp:label id="lblPuAirDepartingCity" runat="server" ></asp:label></td>
										                    </tr>
										                    <tr>
											                    <td class="css_desc"><b>Directions</b></td>
											                    <td class="font2" ><asp:label id="lblPAirDirection" Runat="server" ></asp:label></td>
										                    </tr>
									                    </table>
									                    </td>
								                    <td valign="top" align ="left" >
										                    <table id="tddest" cellspacing="2" cellpadding="2" border="0" runat="server">
											                    <tr>
												                    <td class="css_header" colspan="2"><b>Destination</b></td>
                    											
											                    </tr>
										                    <tr>
												                    <td class="css_desc"><b>Bldg No</b></td>
												                    <td class="font2" ><asp:label id="lblDestBlogno" runat="server" ></asp:label></td>
												                    <%--<td style="width:60px; height: 19px;"></td>--%>
										                    </tr>
											                    <tr>
											                    <td class="css_desc"><b>Street Name</b></td>
											                    <td class="font2" ><asp:label id="lblDStName" runat="server" ></asp:label></td>
										                    </tr>
											                    <tr>
												                    <td class="css_desc"><b>City</b></td>
												                    <td class="font2" ><asp:label id="lblDestCity" Runat="server" ></asp:label></td>
												                    <%--<td style="width:60px"></td>--%>
											                    </tr>
											                    <tr>
												                    <td class="css_desc"><b>State</b></td>
												                    <td class="font2" ><asp:label id="lblDestState" Runat="server" ></asp:label></td>
												                    <%--<td style="width:60px"></td>--%>
											                    </tr>
										                    <%--	<tr>
												                    <td class="css_desc">Address</td>
												                    <td class="font2"><asp:label id="lblDestAddress" Runat="server"></asp:label></td>
											                    </tr>--%>
                    											
											                    <tr>
												                    <td class="css_desc"><b>Nearest Cross Street</b></td>
												                    <td class="font2" ><asp:label id="lblDstrross" Runat="server" ></asp:label></td>
												                    <%--<td style="width:60px"></td>--%>
											                    </tr>
											                    <tr>
											                        <td class="css_desc"><b>Directions</b></td>
											                        <td class="font2" ><asp:label id="lblDDirection" Runat="server" ></asp:label></td>
										                        </tr>
                        											
                    										
										                    </table>
                    									
									                    <table id="tddestairport" runat="server" cellspacing="2" cellpadding="2" border="0" >
										                    <tr>
											                    <td class="css_header" colspan="2"><b>Destination</b></td>
                    											
										                    </tr>
										                    <tr>
											                    <td class="css_desc"><b>Departure Airport</b></td>
											                    <td class="font2" ><asp:label id="lblDairport" Runat="server"></asp:label></td>
											                    <%--<td style="width:60px"></td>--%>
										                    </tr>
										                    <tr>
											                    <td class="css_desc"><b>Departure Airline Name</b></td>
											                    <td class="font2" ><asp:label id="lblDairname" Runat="server" ></asp:label></td>
											                    <%--<td style="width:60px"></td>--%>
										                    </tr>
										                    <tr>
											                    <td class="css_desc"><b>Departure Flight #/Tail #</b></td>
											                    <td class="font2" ><asp:label id="lblDestAirFlight" Runat="server" ></asp:label></td>
											                    <%--<td style="width:60px"></td>--%>
										                    </tr>
										                    <tr>
											                    <td class="css_desc"><b>Departure FBO/Terminal</b></td>
											                    <td class="font2" ><asp:label id="lblDAirFbo" Runat="server" ></asp:label></td>
											                    <%--<td style="width:60px"></td>--%>
										                    </tr>
										                    <tr>
											                    <td class="css_desc"><b>Directions</b></td>
											                    <td class="font2" ><asp:label id="lblDAirDirection" Runat="server" ></asp:label></td>
										                    </tr>
									                    </table>
									                    </td>
									                    </tr>
								                    </table>
								                    </td>
							                    </tr>
							                    <tr>
								                    <td width="100%" colspan="2" style="height: 22px">
										                    <table id="Table1" cellspacing="2" cellpadding="2" width="100%" border="0">
											                    <tbody>
                    												
											                    </tbody>
										                    </table>
                                                        <asp:DropDownList ID="ddlCardType" runat="server" Visible="False">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="ddlCarType" runat="server" Visible="False">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="ddlPayType" runat="server" Visible="False">
                                                        </asp:DropDownList></td>
							                    </tr>
							                    <tr>
								                    <td width="100%" colspan="2">
                    									
								                    </td>
							                    </tr>
                    							
							                    <tr id="trButton" valign="bottom" runat="server">
								                    <td align="left" width="600" colspan="2">
                                                        &nbsp; &nbsp; &nbsp;
                                                        <asp:ImageButton ID="Submit" runat="server" ImageUrl="images/place order.gif" />
                                                        <asp:Button ID="SubmitHide" runat="server" style="display:none" />
                                                        &nbsp; &nbsp;<asp:ImageButton ID="btnBack" runat="server" ImageUrl="images/Back to Order Form.gif" /></td>
							                    </tr>
							                </table>
							            </td>
							        </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>