<%@ Page Language="VB" MasterPageFile="MasterPageMenu.master" AutoEventWireup="false" Debug="true" CodeFile="OrderForm.aspx.vb" Inherits="webride_OrderForm" title="Untitled Page" %>

<%@ Register Src="Modules/calendar.ascx" TagName="calendar" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
<script type="text/javascript" language="javascript" src="JS/orderform.js"></script>
<form id="bodyform" runat="server">
<table  border="0" cellpadding="0" cellspacing="0" style="background-image:url(images/mainbg.gif); width:100%; height:100%">
<tr >
<td align="left" >    
<table   border="0" cellpadding="0" cellspacing="0" width="620" >
    <tr id="Profiletitle">
        <td  >
            <table id="table1" border="0" cellpadding="0" cellspacing="0" style="width: 100%; ">
                <tr >                    
                    <td class="css_header">
                        Online Order Entry Form<asp:HiddenField ID="hdnConfNo" runat="server" />
                    </td>                  
                    <td align="right" style=" color:blue" >
                        "<img  id="img1" alt=""  src="Images/required_star.gif"  />"
                         = REQUIRED
                        "<img id="img2" alt="" src="Images/reddot.gif"  />"<
                         = INCORRECT DATA
                    </td>
                </tr>                      
            </table>
            <table id="table2">
                <tr>
                    <td class="css_desc" >
                        Travel Date/Time
                    </td>
                    <td align="left">
                        <uc1:calendar id="Calendar1" runat="server">
                        </uc1:calendar>
                      </td>
                </tr>
                <tr >
                    <td class="css_desc">Phone Number
                    </td>
                    <td align="left"  >(<asp:TextBox ID='txtPhoneFront' CssClass="form" runat="server" style="width:60px" MaxLength="3"></asp:TextBox>)
                        <asp:TextBox ID="txtPhoneTail" runat="server" MaxLength="7"></asp:TextBox>
                        <img alt='' src='Images/required_star.gif' />
                        Extension:
                        <asp:TextBox ID="txtPhoneExt" runat="server" MaxLength="5"></asp:TextBox>
                    </td>
                </tr>
                 <tr style="display:none">
                    <td class="css_desc">Contact Phone
                    </td>
                    <td align="left"  >(<asp:TextBox ID='txtConPhoneFront' CssClass="form" runat="server" style="width:60px" MaxLength="3"></asp:TextBox>)
                        <asp:TextBox ID="txtConPhoneTail" runat="server" MaxLength="7"></asp:TextBox>
                        
                    </td>

                </tr>
                <tr>
                    <td class="css_desc" >
                        Last, First Name (Passenger)
                    </td>
                    <td align="left" >
                        <asp:TextBox ID="txtLastName" runat="server"  ></asp:TextBox>
                        <img alt='' src='Images/required_star.gif' />,
                        <asp:TextBox ID="txtFirstName" runat="server" ></asp:TextBox>
                        <img alt='' src='Images/required_star.gif' />
                    </td>           
                </tr>
                 <tr>
                    <td class="css_desc">Email Address</td>
                    <td align="left"  ><asp:TextBox ID="txtEmail" runat="server"   Width="280px"></asp:TextBox><img alt='' src='Images/required_star.gif' /></td>
                </tr>
                 <tr>
                    <td class="css_desc">
                        Payment Type
                    </td>
                    <td align="left" >
                        <asp:DropDownList ID="ddlPayType" runat="server"  AutoPostBack="false" DataTextField="content" DataValueField="type" Width="130px"></asp:DropDownList>&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlCardType" runat="server" AutoPostBack="true" DataTextField="content" DataValueField="type" Width="130px"></asp:DropDownList>
                    </td>
                </tr>
                <tr id="trCreditCard">
                    <td class="css_desc">
                        Credit Card #
                    </td>
                    <td align="left" >
                        <asp:TextBox ID="txtCardNo" runat="server"></asp:TextBox>
                        Exp.Date
                        <asp:DropDownList ID='ddlMonth' runat="server" Width="80px"></asp:DropDownList>
                        <asp:DropDownList ID='ddlYear' runat="server" Width="80px"></asp:DropDownList>
                    </td>
                </tr>
                <tr id="trCreditCardName" style="display:none">
                    <td class="css_desc">
                        Credit Card Name
                    </td>
                    <td align="left"  >
                        <asp:TextBox ID="txtCardName"  runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="css_desc">
                        Vehicle Type
                    </td>
                    <td align="left" >
                        <asp:DropDownList ID='ddlVehicleType' runat="server"  Width="130px"></asp:DropDownList>
                        <asp:DropDownList id="hidddlCarType" runat="server" Visible="False" Width="130px"></asp:DropDownList>
                    </td>
                </tr>
             <%--   <tr style="font-size: 12pt; font-family: Times New Roman">
                    <td class="css_desc" >Passenger Contact Phone Number<br />(If Availiable)</td>
                    <td >(<asp:TextBox ID='txtConPhoneFront' CssClass="form" runat="server" onpropertychange='if(this.value.length==10) document.getElementById("ctl00_MainContent_txtConPhoneTail").focus()'  MaxLength="10" Width="98px"></asp:TextBox>)
                        <asp:TextBox ID="txtConPhoneTail" runat="server" ></asp:TextBox>
                    </td>
                </tr>--%>
           
                <tr style="display:none">
                    <td align="left"  bgcolor="White" ><span class="bodyfont"><asp:Literal ID="lit1" runat="server"></asp:Literal></span></td>
                    <td align="left" >
                        <input id="hidreque1" type="hidden" name="hidreque1" runat="server"/>
                        <input id="hidcomp_id_1" type="hidden" name="hidcomp_id_1"	runat="server"/>
                        <input id="hidcomp_id_2" type="hidden" name="hidcomp_id_2"	runat="server"/>
                        <input id="hidcomp_id_3" type="hidden" name="hidcomp_id_3"	runat="server"/>
                        <input id="hidcomp_id_4" type="hidden" name="hidcomp_id_4"	runat="server"/>
                        <input id="hidcomp_id_5" type="hidden" name="hidcomp_id_5"	runat="server"/>
                        <input id="hidcomp_id_6" type="hidden" name="hidcomp_id_6"	runat="server"/>
                    </td>
                </tr>
            </table>

            <table id="table3">
               <tr  align="left" valign="top">
                  <td >
                
                        <table id="table11" border="0" cellpadding="2" cellspacing="2" style="width: 100%;">
                            <tr  id="puaddress">
                                      
                                        <td class="css_header"> Pick Up

                                        </td>
                                        <td align="left"  >
                                             <a href="javascript:void(0)" onclick="window.open('addr_format.aspx','addrformat','width=375,height=400');">[FOR PROPER ADDRESS FORMAT] </a>

                                        </td>
                            </tr>  
                                         
                            <tr id="ptr2" >
                                <td class="css_desc" >
                                  State/Airport
                                </td>
                                <td align="left"  >
                                   <div id="PState"><asp:DropDownList ID='ddlPState' runat="server" ></asp:DropDownList></div><asp:CheckBox ID="ckPAirport" AutoPostBack="false" runat="server"   Text="Click Here For Airports"/>
                                    <%--<a href="javascript:void(0)" onclick="display_airport_detail('pinfo');">ENTER FLIGHT DETAILS</a>--%>
                                </td>
                            </tr>
                            <tr id="ptr4" runat="server">
                                <td class="css_desc">Bldg No.</td>
                                <td align="left" ><asp:TextBox ID="txtPStNo" runat="server" Width="130" ></asp:TextBox><%--<a href="javascript:void(0)" onclick="window.open('addr_format.aspx','addrformat','width=375,height=400');">[FOR PROPER ADDRESS FORMAT]</a>--%>
                                </td>
                            </tr>
                        
                         
                            <tr id="ptr5" runat="server">
                                <td class="css_desc">Street Name</td>
                                <td align="left" >
                                    <asp:TextBox ID="txtPStName" runat="server" Width="130"></asp:TextBox>
                                    <a id="linklookup" onmouseover="self.status = 'Click Here to Look Up Borough Street Name!'; return true" title="Click Here to Look Up Borough Street Name" onclick="streetlookup('p');" onmouseout="self.status = ''; return true" href="javascript:void(0);">Street Lookup</a>
                                </td>
                            </tr>
                            <tr id="ptr3" runat="server">
                                <td class="css_desc">City</td>
                                <td align="left" ><asp:TextBox ID="txtPCity" runat="server" Width="130"></asp:TextBox>
                                                 <a href="javascript:void(0);" runat="server" id="apCity" title="Click Here to Look Up Out Of Town City Names" onclick="citylookup('p');" onmouseover="self.status = 'Click Here to Look Up Out Of Town City Names!'; return true" onmouseout="self.status = ''; return true">City Lookup</a>
                                </td>
                            </tr>
                            <tr id="ptr6" runat="server" style="display:none">
                                <td class="css_desc">Zip Code</td>
                                <td align="left" ><asp:TextBox ID="txtPZip" runat="server" Width="130"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="ptr7" runat="server">
                                <td class="css_desc">Pickup Point</td>
                                <td align="left" ><asp:TextBox ID="txtPPoint" runat="server" Width="130"></asp:TextBox>
                                </td>
                            </tr>
                             <tr id="Tr1" runat="server">
                                <td class="css_desc">Enter Airport Detail</td>
                                <td align="left" >
                                    <a href="javascript:void(0);" runat="server" id="a10" title="Click Here to Enter Airport Detail" onclick="display_airport_detail('p');" onmouseover="self.status = 'Click Here to ENTER AIRPORT DETAILS'; return true" onmouseout="self.status = ''; return true">ENTER AIRPORT DETAILS (optional) </a>
                                </td>
                           </tr>
                                
                      </table> 
                </td> 
               
                <td valign="top" align="left"  rowspan="2">
                                 
                                 <table border="1" cellpadding="0" cellspacing="0"  width="100%" >
                                        <tr>
                                            <td   class="css_desc">
                                               FREQUENT PICKUP POINTS
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td  align="left" colspan="2">
                                                <asp:DataList ID="dlstPU" runat="server" width="100%">
                                                    <ItemStyle BorderWidth="0px" />
                                                    <ItemTemplate>
                                                        <a href='javascript:Assign_Addr(<%#DataBinder.Eval(Container.DataItem, "allinfo") %>)'>
                                                            <%# DataBinder.Eval(Container.DataItem, "pickupaddr") %>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                        </tr>
                                 
                                        <tr>
                                            <td >Arrival Airport Details:</td>
                                        </tr>
                                        <tr>
                                            <td >
                                                <textarea id="pu_airport_detail"  cols="36" rows="6" runat="server" ></textarea>
                                            </td>
                                        </tr>  
                                   </table>          
                 </td>
                      
                             
                </tr>
                <tr>
                <td>
                      <table id="PAirport" border="0" cellpadding="2" cellspacing="2" style="display:none">
                            <tr id="patr3">
                                <td class="css_desc">Airport Name</td>
                                <td align="left"><asp:DropDownList ID='ddlPAirport' runat="server" ></asp:DropDownList></td>
                            </tr>
                            <tr id="patr4">
                                <td class="css_desc">Airline Name</td>
                                <td align="left" ><asp:TextBox ID="txtPAirline" runat="server" ></asp:TextBox></td>
                            </tr>
                            <tr id="patr5">
                                <td class="css_desc">Airport Flight</td>
                                <td align="left" ><asp:TextBox ID="txtPFlightNo" runat="server" ></asp:TextBox>
                                    <input id="hidairport" runat="server"  type="hidden" />
                                    <input id="hidairportvalue" runat="server"  type="hidden" />
                                    <input id="hidairline" runat="server"  type="hidden" />
                                    <input id="hidairline_airport" runat="server"  type="hidden" />
                                    <input id="hidstatevalue" runat="server"  type="hidden" />
                                    <input id="hidstate" runat="server"  type="hidden" />
                                </td>
                            </tr>
                            <tr id="patr6">
                                <td class="css_desc">Airport Pickup Point</td>
                                <td align="left" >
                                    <asp:DropDownList ID='ddlPAirPoint' runat="server" >
                                        <asp:ListItem Value="Outside-Curb Pickup" Selected="True">Outside-Curb Pickup</asp:ListItem>
                                        <asp:ListItem Value="Inside-Baggage Claim">Inside-Baggage Claim</asp:ListItem>
                                        <asp:ListItem Value="Inside-Baggage Escalators">Inside-Baggage Escalators</asp:ListItem>
                                        <asp:ListItem Value="Inside-Customs Exit">Inside-Customs Exit</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="patr7">
                                <td class="css_desc">Passenger Pickup Phone</td>
                                <td align="left"  ><asp:TextBox ID="txtPPhone" runat="server" ></asp:TextBox><br/>Please Enter Numbers Only (No Symbols ex. 5551112222) </td>
                            </tr>
                            <tr id="patr8">
                                <td class="css_desc">Departing City</td>
                                <td align="left" ><asp:TextBox ID="txtPAirCity" runat="server" ></asp:TextBox></td>
                            </tr>
                             <tr>
                                <td align="left" ><input onclick="pickup_airport_reset();" type="button" size="20" value="P/U Airport Reset"/></td>
                               
                            </tr>
                          
                     </table>
                </td>
                </tr>
              
          
           <%--<tr>
            <td colspan="3" class="title-bg" align="left" valign="middle"><img alt="" src="Images/jiantou.jpg" />Destination</td>
            </tr>--%>
                <tr>
                <td>
                      <table id="lable21" border="0" cellpadding="2" cellspacing="2"  width="100%">
                              <tr  id="Tr9">
                                                 
                                        <td class="css_header">
                                           Destination
                                        </td>
                                        <td align="left"  >
                                             <a href="javascript:void(0)" onclick="window.open('addr_format.aspx','addrformat','width=375,height=400');">[FOR PROPER ADDRESS FORMAT] </a>

                                        </td>
                                </tr> 
                                        
                                  <%--      <tr id="Tr2">
                                            <td align="left" colspan="2" ><asp:CheckBox ID="chk_as_directed" runat="server" />CHECK HERE FOR "AS DIRECTED" CALLS. <i><font style="color:blue">(Please do not enter any destination address information for "As Directed" calls)</i></td>
                                        </tr>--%>
                                <tr id="Tr3" runat="server">
                                    <td class="css_desc" >State/Airport</td>
                                    <td align="left" >
                                        <div id="DState"><asp:DropDownList ID='ddlDState' runat="server" ></asp:DropDownList></div><asp:CheckBox ID="ckDAirport" AutoPostBack="false" runat="server" Text="Click Here For Airports"/>
    <%--                                                <a href="javascript:void(0)" onclick="display_airport_detail('dinfo');">ENTER FLIGHT DETAILS</a>
    --%>                                            </td>
                                </tr>
                                <tr id="Tr5" runat="server">
                                    <td class="css_desc">Bldg No.</td>
                                    <td align="left" >
                                        <asp:TextBox ID="txtDStNo" runat="server" Width="130" ></asp:TextBox>         
    <%--                                                <a href="javascript:void(0)" onclick="window.open('addr_format.aspx','addrformat','width=375,height=400');">[FOR PROPER ADDRESS FORMAT]</a>
    --%>                                            </td>
                                </tr>
                                <tr id="Tr6" runat="server">
                                    <td class="css_desc">Street Name</td>
                                    <td align="left" >
                                        <asp:TextBox ID="txtDStName" runat="server" Width="130" ></asp:TextBox>
                                        <a id="destlookup" onmouseover="self.status = 'Click Here to Look Up Borough Street Name!'; return true" title="Click Here to Look Up Borough Street Name" onclick="streetlookup('d');" onmouseout="self.status = ''; return true" href="javascript:void(0);">Street Lookup</a>
                                    </td>
                                </tr>
                                <tr id="Tr4" runat="server">
                                    <td class="css_desc">City</td>
                                    <td align="left" >
                                        <asp:TextBox ID="txtDCity" runat="server" Width="130"></asp:TextBox>
                                        <a href="javascript:void(0);" onclick="citylookup('d');" >City Lookup</a>
                                    </td>
                                </tr>
                           
                                <tr id="Tr8" runat="server">
                                    <td class="css_desc">Nearest Cross Street</td>
                                    <td align="left" ><asp:TextBox ID="txtDCross" runat="server" Width="130"></asp:TextBox></td>
                                </tr>
                                <tr id="Tr99" runat="server" style="display:none">
                                    <td class="css_desc">Zip Code</td>
                                    <td align="left" ><asp:TextBox ID="txtDZip" runat="server" Width="130"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="Tr2" runat="server">
                                    <td class="css_desc">Enter Airport Detail</td>
                                    <td align="left" >
                                        <a href="javascript:void(0);" runat="server" id="a11" title="Click Here to Enter Airport Detail" onclick="display_airport_detail('d');" onmouseover="self.status = 'Click Here to ENTER AIRPORT DETAILS'; return true" onmouseout="self.status = ''; return true">ENTER AIRPORT DETAILS (optional) </a>
                                    </td>
                               </tr>
                                                
                       </table>
                  </td>
                  
                  <td valign="top" align="left"  rowspan="2">
                                 <table border="1" cellpadding="0" cellspacing="0" width="100%" >
                                        <tr>
                                            <td  class="css_desc">
                                                FREQUENT DESTINATIONS
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td  colspan="2" align="left">
                                                <asp:DataList ID="dlst" runat="server" width="100%">
                                                  <ItemStyle BorderWidth="0px" />
                                                  <ItemTemplate><a href='javascript:Assign_Addr(<%# DataBinder.Eval(Container.DataItem, "allinfo") %>)'><%# DataBinder.Eval(Container.DataItem, "pickupaddr") %></a></ItemTemplate>
                                               </asp:DataList>
                                           </td>
                                        </tr>
                                      
                                        <tr align="left" >
                                            <td >Departure Airport Details:</td>
                                        </tr>
                                        <tr align="left" >
                                            <td><textarea id="dest_airport_detail" cols="36" rows="6" runat="server"></textarea></td>
                                        </tr> 
                                        <tr>  
                                             <td align="center">
                                                 <a href="javascript:void(0);" runat="server" id="a12" title="Click Here to ENTER DIRECTIONS (optional)" onclick="citylookup('p');" onmouseover="self.status = 'Click Here to ENTER DIRECTIONS (optional)'; return true" onmouseout="self.status = ''; return true">ENTER DIRECTIONS (optional)</a>

                                             </td>
                                        </tr>
                                  </table>
                   </td>
                   </tr>
                        
                      
              
                  <tr>
                  <td>
                       <table id="DAirport" border="0" cellpadding="2" cellspacing="2" style="display:none">
                                        <tr id="Tr10">
                                            <td class="css_desc">Airport Name</td>
                                            <td align="left"><asp:DropDownList ID='ddlDAirport' runat="server"></asp:DropDownList></td>
                                        </tr>
                                        <tr id="Tr11">
                                            <td class="css_desc">Airline Name</td>
                                            <td align="left" >
                                                <asp:TextBox ID="txtDAirline" runat="server" ></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="Tr12">
                                            <td class="css_desc">Airport Flight</td>
                                            <td align="left" style="width: 481px; height: 24px;"><asp:TextBox ID="txtDFlightNo" runat="server" CssClass="form" MaxLength="50" Width="63px"></asp:TextBox>
                                                <input id="Hidden1" runat="server"  type="hidden" />
                                                <input id="Hidden2" runat="server"  type="hidden" />
                                                <input id="Hidden3" runat="server"  type="hidden" />
                                                <input id="Hidden4" runat="server"  type="hidden" />
                                                <input id="Hidden5" runat="server"  type="hidden" />
                                                <input id="Hidden6" runat="server"  type="hidden" /></td>
                                        </tr>
                                        <tr id="Tr13">
                                            <td class="css_desc">Airport Pickup Point</td>
                                            <td align="left" ><asp:DropDownList ID='ddlDAirPoint' runat="server" >
                                                <asp:ListItem Value="Outside-Curb Pickup" Selected="True">Outside-Curb Pickup</asp:ListItem>
				                                <asp:ListItem Value="Inside-Baggage Claim">Inside-Baggage Claim</asp:ListItem>
				                                <asp:ListItem Value="Inside-Baggage Escalators">Inside-Baggage Escalators</asp:ListItem>
				                                <asp:ListItem Value="Inside-Customs Exit">Inside-Customs Exit</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr id="Tr14">
                                            <td class="css_desc">Passenger Pickup Phone</td>
                                            <td align="left"  >
                                                <asp:TextBox ID="txtDPhone" runat="server" ></asp:TextBox><br/>
                                               Please Enter Numbers Only (No Symbols ex. 5551112222) 
                                            </td>
                                        </tr>
                                        <tr id="Tr15">
                                            <td class="css_desc">Departing City</td>
                                            <td align="left" >
                                                <asp:TextBox ID="txtDDepartingCity" runat="server" ></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
		                                    <td align="left" ><input type="button" value="Dest Airport Reset" onclick="dest_airport_reset();" style="WIDTH: 114px; HEIGHT: 24px"/></td>
		                                   
	                                    </tr>
	                                    
	                                    
                       </table>
                   </td>
                   </tr>
                   </table>
                   </td>
                   </tr>
       
     
         <tr>
            <td align="left">
                <hr />
                &nbsp;
                <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="images/Submit Order.gif" />
                &nbsp;
                <!--<input style="background-image: url(images/Reset.gif);" id="Reset1" name="btnReset" onclick="javascript:LoadDefault();" type="reset" value="Reset"/>-->
                <img alt="" src="images/reset.gif" style="cursor:hand" onclick="javascript:LoadDefault();" />
            </td>
                
        </tr>
        <tr>
            <td colspan="2" style="display:none;"><asp:textbox id="txtcheckpu" runat="server" >0</asp:textbox><asp:textbox id="txtcheckdest" runat="server" Width="16px">0</asp:textbox><input id="hidpuairline" type="hidden" runat="server"/><input id="hiddestairline" type="hidden" runat="server"/></td>
        </tr>

        <tr>
            <td colspan="2" style="display:none;">
                <asp:textbox id="Textbox1" runat="server" >0</asp:textbox><asp:textbox id="Textbox2" runat="server" >0</asp:textbox><input id="Hidden7" type="hidden" runat="server"/><input id="Hidden8" type="hidden" runat="server"/>
                <asp:TextBox ID="txtPFbo" runat="server" ></asp:TextBox><asp:TextBox ID="txtDFbo" runat="server" ></asp:TextBox>
                <asp:TextBox ID="txtPFboName" runat="server" ></asp:TextBox><asp:TextBox ID="txtDFboName" runat="server" ></asp:TextBox>
                <asp:TextBox ID="txtPFboAddress" runat="server" ></asp:TextBox><asp:TextBox ID="txtDFboAddress" runat="server" ></asp:TextBox>
                <asp:TextBox ID="txtPAirTime" runat="server" ></asp:TextBox><asp:TextBox ID="txtDAirTime" runat="server" ></asp:TextBox>
                <asp:TextBox ID="txtPAirPoint" runat="server" ></asp:TextBox>
                <asp:TextBox ID="txtPAirName" runat="server" ></asp:TextBox><asp:TextBox ID="txtDAirName" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr> 
            
             <td   style=" color:Blue">
                 <br /><br />Powered by <a href="javascript:void(0);" onclick="window.open('http://www.alephcomputer.com','aleph');">Aleph Computer Systems, Inc.</a>
                 <br /><br />
            </td>
       </tr>	
</table>
</td>
</tr>
</table>
</form>
</asp:Content >



