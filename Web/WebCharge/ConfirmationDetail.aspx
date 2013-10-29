<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConfirmationDetail.aspx.vb" Inherits="ConfirmationDetail" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<form id="Form1" name="Form1" method="post" runat="server" style="text-align:left">
<table width="100%" border="0">
    <tr >
         <td align ="left" class="css_desc">
           Your&nbsp;Requested&nbsp;Confirmation&nbsp;#&nbsp;Detail
         </td>
    </tr>
    <tr>
	    <td>
	        <asp:datagrid id="DataGrid_InvoiceList" runat="server"  HorizontalAlign="Left" Font-Names="Arial" Font-Size="11px" 
	        PageSize="20" AutoGenerateColumns="False" Width="100%" AllowSorting="True" ShowFooter="false" AllowPaging="true">
		        <SelectedItemStyle Wrap="False"></SelectedItemStyle>
			    <EditItemStyle Wrap="False"></EditItemStyle>
			    <AlternatingItemStyle CssClass="css_alterdesc"></AlternatingItemStyle>
			    <ItemStyle CssClass="css_itemdesc"></ItemStyle>
			    <HeaderStyle CssClass="css_title"></HeaderStyle>
			    <FooterStyle CssClass="css_footdesc"></FooterStyle>
			    <Columns>
				    <asp:BoundColumn DataField="confirmation_no" SortExpression="confirmation_no" ReadOnly="True" HeaderText="Confirmation No">
					    <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="Car_No" SortExpression="Car_No" ReadOnly="True" HeaderText="Car No" >
					    <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="Passenger" SortExpression="Passenger" ReadOnly="True" HeaderText="Passenger">
					    <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="Pu_Date_Time" SortExpression="Pu_Date_Time" ReadOnly="True" HeaderText="Pick Up Date" DataFormatString="{0:MM/dd/yyyy}">
					    <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="Pu_Address" SortExpression="Pu_Address" ReadOnly="True" HeaderText="Pick Up Address">
					    <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="Dest_Address" SortExpression="Dest_Address" ReadOnly="True" HeaderText="Destination">
					    <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="comp_id_1" SortExpression="comp_id_1" ReadOnly="True">
					    <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="comp_id_2" SortExpression="comp_id_2" ReadOnly="True">
					    <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="comp_id_3" SortExpression="comp_id_3" ReadOnly="True">
					    <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="comp_id_4" SortExpression="comp_id_4" ReadOnly="True">
					    <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="comp_id_5" SortExpression="comp_id_5" ReadOnly="True">
					    <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="comp_id_6" SortExpression="comp_id_6" ReadOnly="True">
					    <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="base_rate" SortExpression="base_rate" ReadOnly="True" HeaderText="Base Rate" DataFormatString="{0:#,###,##0.00}">
					    <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="tolls" SortExpression="tolls" ReadOnly="True" HeaderText="Tolls" DataFormatString="{0:#,###,##0.00}">
					    <ItemStyle Wrap="False"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="parking" SortExpression="parking" ReadOnly="True" HeaderText="Parking" DataFormatString="{0:#,###,##0.00}">
					    <ItemStyle Wrap="False"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="phone_amt" SortExpression="phone_amt" ReadOnly="True" HeaderText="Phone Amount" DataFormatString="{0:#,###,##0.00}">
					    <ItemStyle Wrap="False"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="tips" SortExpression="tips" ReadOnly="True" HeaderText="Gratuity" DataFormatString="{0:#,###,##0.00}">
					    <ItemStyle Wrap="False"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="miscellaneous" SortExpression="miscellaneous" ReadOnly="True" HeaderText="Miscellaneous" DataFormatString="{0:#,###,##0.00}">
					    <ItemStyle Wrap="False"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="gross" SortExpression="gross" ReadOnly="True" HeaderText="Gross" DataFormatString="{0:#,###,##0.00}">
					    <ItemStyle Wrap="False"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="discount" SortExpression="discount" ReadOnly="True" HeaderText="Discount" DataFormatString="{0:#,###,##0.00}">
					    <ItemStyle Wrap="False"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="Net" SortExpression="Net" ReadOnly="True" HeaderText="Net" DataFormatString="{0:#,###,##0.00}">
					    <ItemStyle Wrap="False"></ItemStyle>
				    </asp:BoundColumn>
				    <asp:BoundColumn DataField="comment" SortExpression="comment" ReadOnly="True" HeaderText="Comment" DataFormatString="{0:#,###,##0.00}">
					    <ItemStyle Wrap="False"></ItemStyle>
				    </asp:BoundColumn>
			    </Columns>
				<PagerStyle CssClass="css_pagedesc"  Mode="NumericPages"></PagerStyle>
		    </asp:datagrid>
		</td>
		</tr>

    <tr class="noshown" id="trpage" runat="server">
	    <td align="left" class="css_font">Page&nbsp;
	        <asp:label id="lbl_PageIndex" runat="server" Font-Names="Arial"></asp:label>&nbsp;of&nbsp;
			<asp:label id="lbl_PageAmount" runat="server" Font-Names="Arial"></asp:label></td> 
	</tr> 
         <tr>
	            <td align="center">
	                <br />
	                <a href ="rptmenu.aspx">Back to Confirmation # Inquiry</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	                <a href ="default.aspx">Back To Main Menu</a><br />
                    <asp:HiddenField ID="hdnSort" runat="server" />
    	         </td>
	        </tr>
</table>
</form>


</asp:Content>

