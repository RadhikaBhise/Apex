<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="CustomerOfReport.aspx.vb" Inherits="CustomerOfReport" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<form id="Form1" method="post" runat="server">
<table cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr><td align="left" class="css_desc" ><asp:label id="lbl_TabCap" Runat="Server" ></asp:label></td></tr>
    <tr>
		<td  align="left"  >
		   <asp:DataGrid  id="DataGrid_InvoiceList"   PageSize="20" runat="server" AutoGenerateColumns="False" AllowPaging="True" Width="100%" AllowSorting="True">
				    <SelectedItemStyle Wrap="False"></SelectedItemStyle>
				    <EditItemStyle Wrap="False"></EditItemStyle>
				    <AlternatingItemStyle CssClass="css_alterdesc"></AlternatingItemStyle>
				    <ItemStyle CssClass="css_itemdesc"></ItemStyle>
				    <HeaderStyle CssClass="css_title"></HeaderStyle>
				    <FooterStyle CssClass="css_footdesc"></FooterStyle>
				<Columns>
					
					<asp:TemplateColumn HeaderText="">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:HyperLink ID="HyperLink1" runat="server" ForeColor ="Blue">
							</asp:HyperLink>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="totalBase" SortExpression="totalBase" ReadOnly="True" HeaderText="Rate">
						<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalTolls" SortExpression="totalTolls" ReadOnly="True" HeaderText="Tolls" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalParking" SortExpression="totalParking" ReadOnly="True" HeaderText="Parking" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalWait" SortExpression="totalWait" ReadOnly="True" HeaderText="Wait" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalStop" SortExpression="totalStop" ReadOnly="True" HeaderText="Stops" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalSW" SortExpression="totalSW" ReadOnly="True" HeaderText="Stops/W.T." DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
						<asp:BoundColumn DataField="totalPackage" SortExpression="totalPackage" ReadOnly="True" HeaderText="Package" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalMisc" SortExpression="totalMisc" ReadOnly="True" HeaderText="Misc." DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalPhone" SortExpression="totalPhone" ReadOnly="True" HeaderText="Phone" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalTips" SortExpression="totalTips" ReadOnly="True" HeaderText="Tips" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalService" SortExpression="totalService" ReadOnly="True" HeaderText="Service" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalGross" SortExpression="totalGross" ReadOnly="True" HeaderText="Gross" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalDiscount" SortExpression="totalDiscount" ReadOnly="True" HeaderText="Discount" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalNet" SortExpression="totalNet" ReadOnly="True" HeaderText="Net" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalCount" SortExpression="totalCount" ReadOnly="True" HeaderText="No.Of Rides" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="avgNet" SortExpression="avgNet" ReadOnly="True" HeaderText="Avg.Cost" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					
				</Columns>
				    <PagerStyle CssClass="css_pagedesc"  Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
		</td>
	</tr>

	<tr >
		<td align="left"><br />Page&nbsp;
		    <asp:label id="lbl_PageIndex" runat="server" Font-Names="Arial"></asp:label>&nbsp;of&nbsp;
		    <asp:label id="lbl_PageAmount" runat="server" Font-Names="Arial"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		    <asp:ImageButton ID="btnExcel" runat="server" ImageAlign="Middle" ImageUrl="~/Images/ExportToExcelFormat.gif" /><br />
        </td>
	</tr>
		     <tr>
	            <td align="center">
	                <br />
	                <a href ="default.aspx">Back To Main Menu</a><br />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
	            </td>
	        </tr>
</table>
</form>
</asp:Content>

