<%@ Page Language="VB" MasterPageFile="~/MasterPageMenu.master" AutoEventWireup="false" CodeFile="daytimevoucherconfirm2.aspx.vb" Inherits="daytimevoucherconfirm2" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
    <form id="form1" runat="server">
        
        <script language="javascript" type="text/javascript">
            /****************************************************
            ** Function confirmpage display
            ** Description:hide some table where customer not set info
            ** Input:pagetype
            ** Output:
            ** 11/18/04 - Created(jack)
            ** 27/04/06 - Copy (Daniel)
            ****************************************************/
            function show_confirmpage(pagetype)
            {
                if (pagetype==0){
                    document.getElementById("ctl00_content_tdpu").style.display='';
                    document.getElementById("ctl00_content_tddest").style.display='';
                    document.getElementById("ctl00_content_tdpuairport").style.display='none';
                    document.getElementById("ctl00_content_tddestairport").style.display='none';
                }
                else if(pagetype==1)
                {
                    document.getElementById("ctl00_content_tdpu").style.display='none';
                    document.getElementById("ctl00_content_tddest").style.display='';
                    document.getElementById("ctl00_content_tdpuairport").style.display='';
                    document.getElementById("ctl00_content_tddestairport").style.display='none';
                }
                else if(pagetype==2)
                {
                    document.getElementById("ctl00_content_tdpu").style.display='';
                    document.getElementById("ctl00_content_tddest").style.display='none';
                    document.getElementById("ctl00_content_tdpuairport").style.display='none';
                    document.getElementById("ctl00_content_tddestairport").style.display='';
                }
                else if(pagetype==3)
                {
                    document.getElementById("ctl00_content_tdpu").style.display='none';
                    document.getElementById("ctl00_content_tddest").style.display='none';
                    document.getElementById("ctl00_content_tdpuairport").style.display='';
                    document.getElementById("ctl00_content_tddestairport").style.display='';
                }
            }

            function Open_Receipt2()
            {
                var strconf=document.all['ctl00_content_hidconf'].value;
                window.open("receipt2.aspx?cno="+strconf+"");
            }
        </script>
        
        <table width="800" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td></td>
            </tr>
            <tr>
                <td colspan="2" align="left" class="css_header">Order Completed</td>
            </tr>
            <tr>
                <td align="left">
                    <br />
                    <table id="maintable" cellspacing="0" cellpadding="0" border="0" style="width: 670px">
                        <tr>
                            <td align="left" colspan="2"><b><i>Your order has been processed.</i></b>
                            </td>
                        </tr>
                        <tr>
				            <td valign="top" align="left">
					            <table id="Table3" cellspacing="2" cellpadding="2" border="0" style="width: 356px; height: 216px;">
						            <tr>
							            <td class="css_desc">
									            Confirmation #</td>
							            <td>
									            <asp:label id="lblconfirmno" runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">
									            Travel Date/Time</td>
							            <td>
									            <asp:label id="TDate" runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">
									            Passenger Name</td>
							            <td>
									            <asp:label id="PName" runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">
									            Phone Number</td>
							            <td>
									            <asp:label id="Phone" runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">
									            Email Address</td>
							            <td>
									            <asp:label id="Email" runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">
									            Payment Type</td>
							            <td>
									            <asp:label id="payment_type" runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">
									            Car Type</td>
							            <td>
									            <asp:label id="Car_Type" runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">
									            Car #</td>
							            <td>
									            <asp:label id="lblCarNo" runat="server"></asp:label>
                                        </td>
						            </tr>
						            <tr>
							            <td class="css_desc">
									            ETA</td>
							            <td>
									            <asp:label id="lblEta" runat="server"></asp:label>
                                        </td>
						            </tr>
						            <tr style="display:none;">
							            <td class="css_desc">
									            Stops</td>
							            <td>
									            <asp:label id="lblStops" runat="server"></asp:label>
                                        </td>
						            </tr>
						            <tr>
							            <td class="css_desc">
								            Estimated Price	</td>
							            <td>
								            <asp:label id="EPrice" runat="server"></asp:label></td>
						            </tr>
						            <asp:repeater id="rptComp" runat="server">
							            <ItemTemplate>
								            <tr>
									            <td class="css_desc">
									                <%# DataBinder.Eval(Container.DataItem, "req_desc") %>
									            </td>
									            <td>
										            <asp:label id='comp_value' Text='<%# DataBinder.Eval(Container.DataItem, "value") %>' runat="server">
										            </asp:label>
										            <asp:Label ID="comp_id" text='<%# DataBinder.Eval(Container.DataItem, "id") %>' Visible="False" Runat="server">
										            </asp:Label>
									            </td>
								            </tr>
							            </ItemTemplate>
						            </asp:repeater>
					            </table>
                                                      
				            </td>
				            <td valign="top" align="left" style="height: 182px">
				            </td>
			            </tr>
			            <tr>
				            <td align="left" style="WIDTH: 359px" valign="top">
				                <table id="tdpu" cellspacing="2" cellpadding="2" width="100%" border="0" runat="server">
						            <tr>
							            <td class="css_header">Pickup</td>
							            <td></td>
						            </tr>
						            <tr>
							            <td class="css_desc">State</td>
							            <td><asp:label id="lblState" Runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">City</td>
							            <td><asp:label id="lblCity" Runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">Bldg No</td>
							            <td><asp:label id="lblStNo" runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">Street Name</td>
							            <td><asp:label id="lblStName" Runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">Zip Code</td>
							            <td><asp:label id="lblZipCode" runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">Pickup Point</td>
							            <td><asp:label id="lblPuPoint" Runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">Directions</td>
							            <td><asp:label id="lblPuDirections" runat="server"></asp:label></td>
						            </tr>
					            </table>
					            <table id="tdpuairport" runat="server" cellspacing="2" cellpadding="2" width="100%" border="0">
						            <tr>
							            <td class="css_header">Pickup</td>
							            <td></td>
						            </tr>
						            <tr>
							            <td class="css_desc">Airport Name</td>
							            <td><asp:label id="lblPairport" Runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">Airline Name</td>
							            <td><asp:label id="lblPAirName" Runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">Airline Flight</td>
							            <td><asp:label id="lblPAirFli" Runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">Departing City</td>
							            <td><asp:label id="lblPCity" Runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">Airline Pickup Point</td>
							            <td><asp:label id="lblAirPu" Runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">Passenger Pickup Phone</td>
							            <td><asp:label id="lblPassPuPhone" Runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">Directions</td>
							            <td><asp:label id="lblPuAirDirections" runat="server"></asp:label></td>
						            </tr>
					            </table>
				            </td>
				            <td valign="top" align="left">
				                <table id="tddest" runat="server" cellspacing="2" cellpadding="2" width="100%" border="0">
						            <tr>
							            <td class="css_header">Destination</td>
							            <td></td>
						            </tr>
						            <tr>
							            <td class="css_desc">State </td>
							            <td><asp:label id="lblDState" Runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">City</td>
							            <td><asp:label id="lblDCity" Runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">Bldg No</td>
							            <td><asp:label id="lblDStNo" runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">Street Name</td>
							            <td><asp:label id="lblDStName" Runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">Nearest Cross Street</td>
							            <td><asp:label id="lblDStX" runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">Zip Code</td>
							            <td><asp:label id="lblDZipCode" Runat="server"></asp:label></td>
						            </tr>
						            <tr>
							            <td class="css_desc">Directions</td>
							            <td><asp:label id="lblDDirections" Runat="server"></asp:label></td>
						            </tr>
					            </table>
					            <table id="tddestairport" runat="server" cellspacing="2" cellpadding="2" width="100%" border="0">
					                <tr>
						                <td class="css_header">Destination</td>
						                <td></td>
					                </tr>
					                <tr>
						                <td class="css_desc">Airport Name</td>
						                <td><asp:label id="lblDairport" Runat="server"></asp:label></td>
					                </tr>
					                <tr>
						                <td class="css_desc">Airline Name</td>
						                <td><asp:label id="lblDairname" Runat="server"></asp:label></td>
					                </tr>
					                <tr>
						                <td class="css_desc">Airline Flight</td>
						                <td><asp:label id="lblDairFli" Runat="server"></asp:label></td>
					                </tr>
					                <tr>
						                <td class="css_desc">Departing City</td>
						                <td><asp:label id="lblDestCity" Runat="server"></asp:label></td>
					                </tr>
					                <tr>
						                <td class="css_desc">Airline Pickup Point</td>
						                <td><asp:label id="lblAirDest" Runat="server"></asp:label></td>
					                </tr>
					                <tr>
						                <td class="css_desc">Passenger Pickup Phone</td>
						                <td><asp:label id="lblPassDestPhone" Runat="server"></asp:label></td>
					                </tr>
					                <tr>
						                <td class="css_desc">Directions</td>
						                <td><asp:label id="lblDestAirDirections" Runat="server"></asp:label></td>
					                </tr>
				                </table>
				            </td>
			            </tr>
			            <tr>
				            <td align="center" colspan="2" style="height: 21px">
				            </td>
			            </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:TextBox ID="txtShowType" runat="server" Height="15px" Visible="False" Width="16px">0</asp:TextBox>
                    <input id="hidconf" name="hidconf" style="width: 40px" type="hidden" runat="server" />
                </td>
            </tr>
        </table>		
    </form>
</asp:Content>

