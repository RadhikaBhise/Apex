<%@ Control Language="VB" AutoEventWireup="false" CodeFile="group_ridehistory.ascx.vb" Inherits="Modules_group_ridehistory" %>
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
<table width="800" border="0" cellspacing="0" cellpadding="0">
 <tr>
  <td align="center"><asp:DataGrid id="dgRides" runat="server" AutoGenerateColumns="False" PageSize="10"
													AllowPaging="True" AllowSorting="True" Width="100%">
                <AlternatingItemStyle CssClass="css_alterdesc" />
                <ItemStyle CssClass="css_itemdesc" />
                <HeaderStyle CssClass ="css_title" />
													<Columns>
												<asp:TemplateColumn SortExpression="confirmation_no" HeaderText="Conf#">
															<HeaderStyle Width="40px"></HeaderStyle>
															<ItemTemplate>
																<asp:HyperLink id="hy1" CssClass="main_text" Runat="server" Width="50px"></asp:HyperLink>
																
															</ItemTemplate>
														</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="Status_flag" HeaderText="Status_flag">
													<HeaderStyle Width="78px"></HeaderStyle>
													<ItemTemplate>
													        <asp:Label id="lblStatus" Width="50px" Runat="server" CssClass="main_text"></asp:Label>
													    </ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="Name" HeaderText="Name">
													<HeaderStyle Width="50px"></HeaderStyle>
													<ItemTemplate>
													        <asp:Label id="lblName" Width="50px" Runat="server" CssClass="main_text"></asp:Label>
													    </ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="pu_st_no" HeaderText="Pick Up">
													<HeaderStyle Width="90px"></HeaderStyle>
													    <ItemTemplate>
													        <asp:Label id="lblPuAddress" Width="90px" Runat="server" CssClass="main_text"></asp:Label>
													    </ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="dest_st_no" HeaderText="Destination">
													<HeaderStyle Width="90px"></HeaderStyle>
													<ItemTemplate>
													        <asp:Label id="lblDestAddress" Width="90px" Runat="server" CssClass="main_text"></asp:Label>
													    </ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="display_date_time" HeaderText="Travel Date">
															<ItemTemplate>
																<asp:Label id="lblReq_date_time" Runat="server" Width="70px" CssClass="main_text"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="eta_time" HeaderText="ETA">
															<ItemTemplate>
																<asp:Label id="lblETA"  Runat="server" Width="20px" CssClass="main_text"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
												<asp:TemplateColumn SortExpression="car_no" HeaderText="Car#">
															<ItemTemplate>
																<asp:Label id="lblCarNo" Runat="server" Width="20px" CssClass="main_text"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Action">
													<HeaderStyle Width="80px"></HeaderStyle>
													<ItemTemplate>
																	<asp:Label id="lblShow" Runat="server" Visible="False" CssClass="main_text">To Cancel/Modify Order Call</asp:Label><br>
																	<asp:Image id="img1" Runat="server" Visible="False" ImageUrl="../Images/r_arrow.gif"></asp:Image>&nbsp;
																	<asp:LinkButton id="lbCancel" Runat="server" width="80px" CssClass="main_text" text="Cancel Order" Visible="False" CommandName="OnClick"></asp:LinkButton><br>
																	<asp:Image id="img2" Runat="server" Visible="False" ImageUrl="../Images/r_arrow.gif"></asp:Image>&nbsp;
																	<asp:HyperLink id="hyModify" Runat="server" width="80px" Visible="False" CssClass="main_text">Modify Order</asp:HyperLink>
													</ItemTemplate>
													</asp:TemplateColumn>
											</Columns>
													<PagerStyle Mode="NumericPages"></PagerStyle>
												</asp:DataGrid> <TABLE id="Table4" cellSpacing="1" cellPadding="1" border="0" style="width: 100%">
										<TR>
											<TD class="main_text" style="WIDTH: 90px; height: 22px;" align="right"></TD>
											<TD style="WIDTH: 497px; height: 22px;" align="left"><asp:label id="lblCountRide" runat="server" CssClass="font2" Height="16px" Font-Size="11px"  ></asp:label></TD>
											<TD class="font" style="height: 22px"><asp:label id="lblPage" runat="server" CssClass="main_text" Font-Size="11px">Page: </asp:label></TD>
											<TD class="form" style="height: 22px"><asp:dropdownlist id="ddlPage" runat="server" CssClass="text2" Font-Size="11px" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD class="form" style="height: 22px"><asp:Button ID="btnExcel" runat ="server" Text ="Export To Excel Format" /></TD>
										</TR>
									</TABLE>	
									
  </td></tr>
     <tr>
                    <td colspan="2" style="height: 30px"><br /><b>Status Legend</b></td>
    </tr>
    <tr>
        <td>
	        <table border="1" cellspacing="1" cellpadding="0" Width="100%">
              
		        <tr>
			        <td class="css_desc">
			            <b>LIVE</b>
			        </td>
			        <td>
			            This order will be processing soon.
			        </td>
		        </tr>
		        <tr>
			        <td class="css_desc"><b>RESERVATION</b>
			        </td>
			        <td>This is a reservation call and will be dispatched at the requested time.
			        </td>
		        </tr>
		        <tr>
			        <td class="css_desc"><b>PROCESSING</b>
			        </td>
			        <td>This order is currently processing and is locating a car.
			        </td>
		        </tr>
		        <tr>
			        <td class="css_desc" style="height: 23px"><b>DISPATCHED</b>
			        </td>
			        <td style="height: 23px">This order has been dispatched, please meet at the pickup address.
			        </td>
		        </tr>
		        <tr>
			        <td class="css_desc"><b>CONFIRMED</b>
			        </td>
			        <td>This order has been completed.
			        </td>
		        </tr>
	        </table>
        </td>
    </tr>
  </table>