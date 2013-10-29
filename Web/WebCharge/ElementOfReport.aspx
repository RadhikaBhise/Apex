<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ElementOfReport.aspx.vb" Inherits="ElementOfReport" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<script type="text/javascript"  language ="JavaScript" src="JS/Report.js"></script>
<form id="Form1" method="post" runat="server">
<table cellspacing="0" cellpadding="0" border="0" width="808px">
    <tr><td align="left" class="css_desc">Invoice Inquiry Results:</td></tr>
    <tr>
		<td align="left" >
		    <asp:datagrid id="DataGrid_VoucherList"  PageSize="20" runat="server" AutoGenerateColumns="False" AllowPaging="True" Width="100%" AllowSorting="True">
				    <SelectedItemStyle Wrap="False"></SelectedItemStyle>
				    <EditItemStyle Wrap="False"></EditItemStyle>
				    <AlternatingItemStyle CssClass="css_alterdesc"></AlternatingItemStyle>
				    <ItemStyle CssClass="css_itemdesc"></ItemStyle>
				    <HeaderStyle CssClass="css_title"></HeaderStyle>
				    <FooterStyle CssClass="css_footdesc"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="Invoice_No" SortExpression="Invoice_No" ReadOnly="True" HeaderText="INVOICE#">
						<ItemStyle Wrap="False" ></ItemStyle>
					</asp:BoundColumn>
				<%--	<asp:BoundColumn DataField="confirmation_no" SortExpression="confirmation_no" ReadOnly="True" HeaderText="CONFIRMATION#">
						<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>--%>
					<asp:BoundColumn DataField="Voucher_No" SortExpression="Voucher_No" ReadOnly="True" HeaderText="VOUCHER">
		                <ItemStyle Wrap="False" ></ItemStyle>
	                </asp:BoundColumn>
	                
					<asp:BoundColumn DataField="Pu_Date_Time" SortExpression="Pu_Date_Time" ReadOnly="True" HeaderText="PU_DATE" DataFormatString="{0:MM/dd/yyyy}">
						<ItemStyle Wrap="False" ></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Car_No" SortExpression="Car_No" ReadOnly="True" HeaderText="CAR">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Passenger" SortExpression="Passenger" ReadOnly="True" HeaderText="PASSENGER">
						<ItemStyle Wrap="False" HorizontalAlign="left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Pu_Address" SortExpression="Pu_Address" ReadOnly="True" HeaderText="PICKUP">
						<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Dest_Address" SortExpression="Dest_Address" ReadOnly="True" HeaderText="DESTINATION">
						<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					
					<asp:BoundColumn DataField="Pu_Date_Time" SortExpression="Pu_Date_Time" ReadOnly="True" HeaderText="TIME" DataFormatString="{0:HH:mm }">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="base_rate" SortExpression="base_rate" ReadOnly="True" HeaderText="RATE" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="tolls" SortExpression="tolls" ReadOnly="True" HeaderText="TOLLS" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="parking" SortExpression="parking" ReadOnly="True" HeaderText="PARK" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False" ></ItemStyle>
					</asp:BoundColumn>
					
				    <asp:BoundColumn DataField="wait_amount" SortExpression="wait_amount" ReadOnly="True" HeaderText="W.T." DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"  ></ItemStyle>
					</asp:BoundColumn>
					
					<asp:BoundColumn DataField="stops_amt" SortExpression="stops_amt" ReadOnly="True" HeaderText="STOPS" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False" ></ItemStyle>
					</asp:BoundColumn>
					
					<asp:BoundColumn DataField="stop_wt_amount" SortExpression="stop_wt_amount" ReadOnly="True" HeaderText="STP/W.T." DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"  ></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="package_amt" SortExpression="package_amt" ReadOnly="True" HeaderText="PACK" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"  ></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Surcharge" SortExpression="Surcharge" ReadOnly="True" HeaderText="NYS SURCHARGE" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					
					<asp:BoundColumn DataField="phone_amt" SortExpression="phone_amt" ReadOnly="True" HeaderText="PHONE" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False" ></ItemStyle>
					</asp:BoundColumn>
					
					<asp:BoundColumn DataField="package_amt" SortExpression="package_amt" ReadOnly="True" HeaderText="ADJ" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle  Wrap="False" ></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="service_fee" SortExpression="service_fee" ReadOnly="True" HeaderText="SVR" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle  Wrap="False" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
				    <%--	<asp:BoundColumn DataField="Tips" SortExpression="Tips" ReadOnly="True" HeaderText="GRATUITY" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>--%>
					
					<asp:BoundColumn DataField="Gross" SortExpression="Gross" ReadOnly="True" HeaderText="GROSS" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Discount" SortExpression="Discount" ReadOnly="True" HeaderText="DISC" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False" ></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Net" SortExpression="Net" ReadOnly="True" HeaderText="NET" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False" ></ItemStyle>
					</asp:BoundColumn>
					
					<asp:BoundColumn DataField="comp_id_1" SortExpression="comp_id_1" ReadOnly="True">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="comp_id_2" SortExpression="comp_id_2" ReadOnly="True">
						<ItemStyle Wrap="False" ></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="comp_id_3" SortExpression="comp_id_3" ReadOnly="True">
						<ItemStyle Wrap="False" ></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="comp_id_4" SortExpression="comp_id_4" ReadOnly="True">
						<ItemStyle Wrap="False" ></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="comp_id_5" SortExpression="comp_id_5" ReadOnly="True">
						<ItemStyle Wrap="False" ></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="comp_id_6" SortExpression="comp_id_6" ReadOnly="True">
						<ItemStyle Wrap="False" ></ItemStyle>
					</asp:BoundColumn>
				</Columns>
				    <PagerStyle CssClass="css_pagedesc"  Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
		</td>
	</tr>
	
	<tr class="noshown" id="trpage" runat="server">
		<td align="left" class="css_font" ><br />Page&nbsp;
				<asp:label id="lbl_PageIndex" runat="server" Font-Names="Arial"></asp:label>&nbsp;of&nbsp;
				<asp:label id="lbl_PageAmount" runat="server" Font-Names="Arial"></asp:label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href ="default.aspx">Back To Home</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="rptmenu.aspx">Back to Report Menu</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnExcel" runat ="server" Text ="Export To Excel Format" />
			<br /><br />
		</td>
	</tr>
 
</table>
</form>
</asp:Content>

