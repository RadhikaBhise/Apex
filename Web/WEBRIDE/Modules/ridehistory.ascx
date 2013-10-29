<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ridehistory.ascx.vb" Inherits="Modules_ridehistory" %>

<link href="../css/layout.css" type="text/css" rel="stylesheet" />
<style type="text/css">
    .css_text
    {
        font-family:Arial;
	    font-size:11px;
	    font-weight:bold;
	    height:18px;
	    width:80px;
    }
    .css_value
    {
        font-family:Arial;
	    font-size:11px;
	    color: green;
    }
</style>

<table width="100%">
    <tr>
        <td>
            <asp:datagrid id="dgRide" runat="server" PageSize="15" CellPadding="2" CellSpacing="2"  AutoGenerateColumns="false"  Width="100%" AllowPaging="True">
				<AlternatingItemStyle cssclass="css_alterdesc"></AlternatingItemStyle>
				<ItemStyle cssclass="css_itemdesc"></ItemStyle>
				<HeaderStyle  CssClass="css_title"></HeaderStyle>					
				<Columns>
				    <asp:TemplateColumn>
						<ItemTemplate>
							<table cellpadding="1" cellspacing="1" border="0" width="100%">
							    <tr align="left">
							        <td valign="top">
								        <asp:HyperLink ID="hlnkConf" Font-Bold="true" runat="server" Text='<%# databinder.eval(container.dataItem,"confirmation_no")%>'
                                            Width="40px">
                                        </asp:HyperLink><br />
								    </td>
								    <td valign="top" >
								        <a title="Populate Order Form With This Rides Data" href='order.aspx?f=rh&cno=<%# databinder.eval(container.dataItem,"confirmation_no")%>'>
									        Use this data
									    </a>
									</td>
									<td colspan="2" align="left" >
								        <%--CANCELLED--%>
								        <asp:Label id="lblStatus" Width="50px" Runat="server" CssClass="form_new"></asp:Label>
					                    <asp:Label ID="lblCancelNo" runat="server" ></asp:Label>
					                </td>
					            </tr>
					            <tr>
					                <td colspan="4" style="background-image:url(Images/line.gif)">
					                </td>
					            </tr>
					            <tr class="">
					                <td align="left">
					                    Name</font>
					                </td>
					                <td align="left" >
					                    <asp:Label ID="lblName" runat="server" > </asp:Label>
					                </td>
					                <td align="left" >
					                    Travel Date:
					                </td>
					                <td align="left">
					                    <asp:Label id="lblReq_date_time" Runat="server" Width="120px"></asp:Label>
					                </td>
					            </tr>
						        <tr>
						            <td colspan="4" style="background-image:url(Images/line.gif)">
						            </td>
						        </tr>
							    <tr class="">
							        <td  align="left" >
							            Pickup: 
							        </td>
							        <td align="left" style="width:230px;">
							            <asp:Label id="lblPuAddress" Width="230px" Runat="server" CssClass="searchfont_new"></asp:Label>
							        </td>
							        <td align="left" >
							            Confirm/Cancel Time: 
							        </td><td align="left">
							            <asp:Label ID="lblCdate" runat="server"  CssClass="searchfont_new"></asp:Label>
							        </td>
						        </tr>
						    	<tr>
						    	    <td colspan="4" style="background-image:url(Images/line.gif)">
						    	    </td>
						    	</tr>
						        <tr class="">
						            <td  align="left">
						                 Destination: 
						            </td>
						            <td align="left" style="width:230px;"> 
						                <asp:Label id="lblDestAddress" Width="230px" Runat="server" CssClass="searchfont_new"></asp:Label>
						            </td>
						            <td align="left" >
						                Price:
						            </td>
						            <td align="left">
						                <asp:Label ID="lblPrice" runat="server"  CssClass="searchfont_new" ></asp:Label>
						            </td>
						        </tr>
						    	<tr>
						    	    <td colspan="4" style="background-image:url(Images/line.gif)">
						    	    </td>
						    	</tr>
						        <tr class="" style="display:none">
						            <td align="left" >
						                Dispatched:
						                <asp:Label ID="lblDisp" runat="server"  CssClass="searchfont_new"></asp:Label>
						            </td>
						            <td align="left" >
						                On Scene: 
						                <asp:Label ID="lblos" runat="server"  CssClass="searchfont_new"></asp:Label>
						            </td>
						    	    <td align="left" >
						    	        Load:
						    	        <asp:Label ID="lblLoad" runat="server" CssClass="searchfont_new" ></asp:Label>
						    	    </td>
						  	        <td align="left" >
						  	            Unload:
						  	            <asp:Label ID="lblUnload" runat="server" CssClass="searchfont_new" ></asp:Label>
						  	        </td>
						       </tr>
						 		<tr>
						 		    <td colspan="4" style="background-image:url(Images/line.gif)">
						 		    </td>
						 		</tr>
						     </table>    
						</ItemTemplate>
						<HeaderTemplate>
						    <b>Sort By:</b>&nbsp;&nbsp;
						    <asp:label runat="server" ID="conf" Visible="false" ForeColor="red" >Conf.#</asp:label>
						    <asp:LinkButton ID="lbtnConf" runat="server" CommandName="sort" CommandArgument="confirmation_no">Conf.#</asp:LinkButton> /&nbsp;&nbsp;
						    <asp:LinkButton ID="lbtnPickup" runat="server" CommandName="sort" CommandArgument="pu_landmark">Pickup Location </asp:LinkButton> /&nbsp;&nbsp;
						    <asp:LinkButton ID="lbtnDest" runat="server" CommandName="sort" CommandArgument="dest_landmark">Destination</asp:LinkButton> /&nbsp;&nbsp;
						    <asp:LinkButton ID="lbtnStatus" runat="server" CommandName="sort" CommandArgument="status_flag">Status</asp:LinkButton> /&nbsp;&nbsp;
						    <asp:LinkButton ID="lbtnPrice" runat="server" CommandName="sort" CommandArgument="price_est">Price </asp:LinkButton> /&nbsp;&nbsp;
						    <asp:LinkButton ID="lbtnTime" runat="server" CommandName="sort" CommandArgument="display_date_time">Confirm/Cancel Time </asp:LinkButton> /&nbsp;&nbsp;
						</HeaderTemplate>
					</asp:TemplateColumn> 
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
        </td>
    </tr>
    <tr>
	    <td>
		    <table id="table4" cellspacing="1" cellpadding="1" border="0" style="width:100%">
			    <tr>
				    <td align="left" style="width: 63px">Total Rides:</td>
				    <td  align="left" style="width: 503px"><asp:label id="lblCountRide" runat="server">0</asp:label></td>
				    <td align="right" style="width: 63px;display:none">Page: </td>
				    <td align="left" style="display:none;">
				        <asp:dropdownlist id="ddlPage" runat="server" AutoPostBack="True"></asp:dropdownlist>
				    </td>
			    </tr>
		    </table>
		<asp:HiddenField ID="hdnSort" runat="server" />
		</td>
	</tr>
</table>