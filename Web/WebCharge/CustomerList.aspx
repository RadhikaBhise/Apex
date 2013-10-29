<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="CustomerList.aspx.vb" Inherits="CustomerList" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<script language ="javascript" src ="JS/Report.js" type="text/javascript"></script>
<form id="Form1" method="post" runat="server">
<table cellspacing="0" cellpadding="0" border="0" style="width:100%">
    <tr>
        <td align ="left" class="css_header">
            <asp:label id="lbl_TabCap" Runat="Server">Query & Statistics: By Customer Reference:</asp:label>
        </td>
    </tr>
    <tr>
        <td align ="left">
            <asp:label id="lbl_content" Runat="Server" Font-Size="12px"></asp:label>
        </td>
    </tr>
    <tr>
		<td align="center">
		    <asp:datagrid id="DataGrid_VoucherList" runat="server" HorizontalAlign="Left" 
				AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
				<SelectedItemStyle Wrap="False"></SelectedItemStyle>
				<EditItemStyle Wrap="False"></EditItemStyle>
				<AlternatingItemStyle CssClass="css_alterdesc"></AlternatingItemStyle>
				<ItemStyle CssClass="css_itemdesc"></ItemStyle>
				<HeaderStyle CssClass="css_title"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="Invoice_No" SortExpression="Invoice_No" ReadOnly="True" HeaderText="INVOICE#">
						<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn SortExpression="confirmation_no" HeaderText="CONFIRMATION#">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:HyperLink ID="HyperLink1"  runat="server" ForeColor ="Blue" Text='<%# DataBinder.Eval(Container, "DataItem.confirmation_no") %>' NavigateUrl='<%# "javascript:ShowConfirmation(""" & DataBinder.Eval(Container.DataItem, "confirmation_no").ToString.Trim & """)" %>'>
							</asp:HyperLink>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Pu_Date_Time" SortExpression="Pu_Date_Time" ReadOnly="True" HeaderText="PU_DATE">
						<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Car_No" SortExpression="Car_No" ReadOnly="True" HeaderText="CAR">
						<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Passenger" SortExpression="Passenger" ReadOnly="True" HeaderText="PASSENGER">
						<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Pu_Address" SortExpression="Pu_Address" ReadOnly="True" HeaderText="PICKUP">
						<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Dest_Address" SortExpression="Dest_Address" ReadOnly="True" HeaderText="DESTINATION">
						<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Pu_Date_Time" SortExpression="Pu_Date_Time" ReadOnly="True" HeaderText="P/U TIME" Visible="False">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="base_rate" SortExpression="base_rate" ReadOnly="True" HeaderText="BASE RATE">
						<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="tolls" SortExpression="tolls" ReadOnly="True"
						HeaderText="TOLLS" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="parking" SortExpression="parking" ReadOnly="True" HeaderText="PARK" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="stops_amt" SortExpression="stops_amt" ReadOnly="True" HeaderText="STOPS" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="phone_amt" SortExpression="phone_amt" ReadOnly="True" HeaderText="PHONE" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Tips" SortExpression="Tips" ReadOnly="True" HeaderText="GRATUITY" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Gross" SortExpression="Gross" ReadOnly="True" HeaderText="GROSS" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Discount" SortExpression="Discount" ReadOnly="True" HeaderText="DISC" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Net" SortExpression="Net" ReadOnly="True" HeaderText="NET" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
				</Columns>
				 <PagerStyle CssClass="css_pagedesc" Mode="NumericPages" />
			</asp:datagrid>
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
<br />

</asp:Content>

