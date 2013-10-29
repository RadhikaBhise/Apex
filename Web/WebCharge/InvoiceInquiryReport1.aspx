<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="InvoiceInquiryReport1.aspx.vb" Inherits="InvoiceInquiryReport1" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<form id="Form1" method="post" runat="server">
<table cellspacing="0" cellpadding="0"  border="0" width="100%">
<tr>
            <td colspan="5"  style="height:10px"></td>
</tr>
<tr><td align="left" class="css_desc">Your Requested Invoice Index:</td></tr>

<tr>
		<td align="center"   >
		    <asp:datagrid id="DataGrid_InvoiceList" runat="server"  Width="100%" HorizontalAlign="Left" AutoGenerateColumns="False"  AllowPaging="True">
                <SelectedItemStyle Wrap="False"></SelectedItemStyle>
                <EditItemStyle Wrap="False"></EditItemStyle>
                <AlternatingItemStyle CssClass="css_alterdesc"></AlternatingItemStyle>
                <ItemStyle CssClass="css_itemdesc"></ItemStyle>
                <HeaderStyle CssClass="css_title"></HeaderStyle>
                <FooterStyle CssClass="css_footdesc"></FooterStyle>
				<Columns>
					<asp:TemplateColumn  SortExpression="invoice_date" HeaderText="Date">
						<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:HyperLink ID="HyperLink1" runat="server" ForeColor ="Blue"  Text='<%# DataBinder.Eval(Container, "DataItem.Invoice_Date") %>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.Invoice_No", "InvoiceInquiryReport2.aspx?InvoiceNo={0}"+"&InvoiceDate="+DataBinder.Eval(Container.DataItem,"Invoice_Date").ToString()) %>'>
							</asp:HyperLink>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="invoice_no" SortExpression="invoice_no" ReadOnly="True" HeaderText="INVOICE#">
						<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="base_rate" SortExpression="base_rate" ReadOnly="True" HeaderText="RATE" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="tips" SortExpression="tips" ReadOnly="True" HeaderText="TIPS" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="tolls" SortExpression="tolls" ReadOnly="True" HeaderText="TOLLS" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="phone_amt" SortExpression="phone_amt" ReadOnly="True" HeaderText="PHONE" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="stops_amt" SortExpression="stops_amt" ReadOnly="True" HeaderText="STOPS" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="stop_wt_amount" SortExpression="stop_wt_amount" ReadOnly="True" HeaderText="W.T." DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Parking" SortExpression="Parking" ReadOnly="True" HeaderText="PARKING" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="package_amt" SortExpression="package_amt" ReadOnly="True" HeaderText="PAKG#" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="miscellaneous" SortExpression="miscellaneous" ReadOnly="True" HeaderText="MISC." DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Discount" SortExpression="Discount" ReadOnly="True" HeaderText="DISC." DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Net" SortExpression="Net" ReadOnly="True" HeaderText="TOTAL" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					
				</Columns>
						 <PagerStyle CssClass="css_pagedesc"  Mode="NumericPages"></PagerStyle>

			</asp:datagrid>
		</td>
	</tr>
	<tr>
		<td align="center"></td>
	</tr>
	<tr>
		<td align="left" class="css_font" ><br />Page&nbsp;
		<asp:label id="lbl_PageIndex" runat="server" Font-Names="Arial"></asp:label>&nbsp;of&nbsp;
		<asp:label id="lbl_PageAmount" runat="server" Font-Names="Arial"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<a href ="default.aspx">Back To Home</a>&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;<asp:Button ID="btnExcel" runat ="server" Text ="Export To Excel Format" /><br />
        <asp:HiddenField ID="hdnSort" runat="server" />
        <br />
		</td>
		
	</tr>
</table>
</form>
</asp:Content>

