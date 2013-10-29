<%@ Control Language="VB" AutoEventWireup="false" CodeFile="rideinquiry.ascx.vb" Inherits="Modules_rideinquiry" %>


<style type="text/css">
    .css_text
    {
        font-family:Arial;
	    font-size:11px;
	    font-weight:bold;
	    width:22%;
    }
    .css_value
    {
        font-family:Arial;
	    font-size:11px;
	    color: green;
	    width:28%;
    }
</style>
<table width="100%">
    <tr>
        <td>     
            <asp:DataGrid ID="grdData" runat="server" AutoGenerateColumns="False" Width="100%" PageSize="15" PagerStyle-Mode="numericpages">
                <AlternatingItemStyle CssClass="css_alterdesc" />
                <ItemStyle CssClass="css_itemdesc" />
                <HeaderStyle CssClass ="css_title" />
                <Columns>
                    <asp:TemplateColumn HeaderText="Conf #">
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:HyperLink ID="lnkConfNo" Font-Bold="true" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"confirmation_no") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Status">
                        <ItemStyle VerticalAlign="Top" />
                        <ItemTemplate>
                            <table style="height:100%;">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblStatus" ForeColor="darkblue" CssClass="css_text" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"status_flag") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="bottom">
                                        <asp:Label ID="lblCancelNo" runat="server"></asp:Label>
                                        <br /><br />
                                        <asp:Image ID="imgCancel" ImageUrl="../images/r_arrow.gif" runat="server" /><asp:LinkButton ID="btnCancel" ToolTip="Click here to cancel order." runat="server" CommandName="Delete" Text="Cancel&nbsp;Order" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"confirmation_no") %>' />
                                        <br />
                                        <asp:Image ID="imgModify" ImageUrl="../images/r_arrow.gif" runat="server" /><asp:HyperLink ID="btnModify" ToolTip="Click here to modify order." runat="server" NavigateUrl="~/OrderForm.aspx" Text="Modify&nbsp;Order"></asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Info">
                        <ItemTemplate>
                            <table width="100%" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td class="css_text">Travel Date:</td>
                                    <td class="css_value" ><asp:Label ID="lblReqDateTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"req_date_time") %>'></asp:Label></td>
                                    <td class="css_text">Est.Price:</td>
                                    <td class="css_value"><asp:Label ID="lblPriceEst" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="css_text">Name:</td>
                                    <td class="css_value"><asp:Label ID="lblName" runat="server" > </asp:Label></td> 
                                    <td class="css_text">On Scene:</td>
                                    <td class="css_value"><asp:Label ID="lblOnScene" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="css_text">ETA/CarType:</td>
                                    <td class="css_value"><asp:Label ID="lblETA" runat="server" ></asp:Label></td>                                    
                                    <td class="css_text">Load:</td>
                                    <td class="css_value"><asp:Label ID="lblLoad" runat="server" ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="css_text">Car #/Dr.Name:</td>
                                    <td class="css_value"><asp:Label id="lblCarNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"car_no") %>'></asp:Label></td>                                    
                                    <td class="css_text">Unload:</td>
                                    <td class="css_value"><asp:Label ID="lblUnload" runat="server" ></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="css_text">Contact&nbsp;Phone:</td>
                                    <td class="css_value" colspan="3"><asp:Label id="lblDPhone" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"pu_phone") %>'></asp:Label></td>                                    
                                </tr>
                                <tr>
                                    <td class="css_text">Pickup:</td>
                                    <td class="css_value" colspan="3"><asp:Label ID="lblPickup" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="css_text">Dropoff:</td>
                                    <td class="css_value" colspan="3"><asp:Label ID="lblDropoff" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height:10px"></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid>
        </td>
    </tr>
    <tr>
                    <td colspan="2"><br /><b>Status Legend</b></td>
    </tr>
    <tr>
        <td>
	        <table border="1" cellspacing="1" cellpadding="0" width="100%">
              
		        <tr>
			        <td class="css_desc" style="width: 15%">
			            <b>LIVE</b>
			        </td>
			        <td>
			            This order will be processing soon.
			        </td>
		        </tr>
		        <tr>
			        <td class="css_desc" style="width: 15%"><b>RESERVATION</b>
			        </td>
			        <td>This is a reservation call and will be dispatched at the requested time.
			        </td>
		        </tr>
		        <tr>
			        <td class="css_desc" style="width: 15%"><b>PROCESSING</b>
			        </td>
			        <td>This order is currently processing and is locating a car.
			        </td>
		        </tr>
		        <tr>
			        <td class="css_desc" style="height: 23px; width: 15%;"><b>DISPATCHED</b>
			        </td>
			        <td style="height: 23px">This order has been dispatched, please meet at the pickup address.
			        </td>
		        </tr>
		        <tr>
			        <td class="css_desc" style="width: 15%"><b>CONFIRMED</b>
			        </td>
			        <td>This order has been completed.
			        </td>
		        </tr>
	        </table>
        </td>
    </tr>
</table>