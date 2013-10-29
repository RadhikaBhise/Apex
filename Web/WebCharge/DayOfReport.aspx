<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="DayOfReport.aspx.vb" Inherits="DayOfReport" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<script language="JavaScript" src="JS/Report.js" type="text/javascript"></script>
<form id="Form1" method="post" runat="server">
    <table  border="0">
        <tr>
            <td align="left" class="css_header">
                <asp:label id="lbl_TabCap" Runat="Server">Time of Day Report Results</asp:label>
            </td>
        </tr>
        <tr>
	        <td align="center" bgColor="darkgray">
	            <asp:datagrid id="DataGrid_VoucherList" runat="server" AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" ShowFooter="true">
			        <SelectedItemStyle Wrap="False"></SelectedItemStyle>
			        <EditItemStyle Wrap="False"></EditItemStyle>
			        <AlternatingItemStyle CssClass="css_alterdesc"></AlternatingItemStyle>
			        <ItemStyle CssClass="css_itemdesc"></ItemStyle>
			        <HeaderStyle CssClass="css_title"></HeaderStyle>
			        <FooterStyle CssClass="css_footdesc"></FooterStyle>
			        <Columns>
				        <asp:BoundColumn DataField="Invoice_No" SortExpression="Invoice_No" ReadOnly="True" HeaderText="INVOICE#">
					        <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
				        </asp:BoundColumn>
				        <asp:BoundColumn DataField="confirmation_no" SortExpression="confirmation_no" ReadOnly="True" HeaderText="CONFIRMATION#">
					        <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
				        </asp:BoundColumn>
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
				        <asp:BoundColumn DataField="Pu_Date_Time" SortExpression="Pu_Date_Time" ReadOnly="True" HeaderText="P/U TIME" Visible="false">
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
			        </Columns>
			        <PagerStyle CssClass="css_pagedesc" Mode="NumericPages"></PagerStyle>
		        </asp:datagrid>
		    </td>
        </tr>
        <tr>
	        <td align="center"></td>
        </tr>
        <tr class="noshown" id="trpage" runat="server">
	        <td class="css_font">Page&nbsp;
			        <asp:label id="lbl_PageIndex" runat="server" Font-Names="Arial"></asp:label>&nbsp;of&nbsp;
			        <asp:label id="lbl_PageAmount" runat="server" Font-Names="Arial"></asp:label>
			        <a href ="default.aspx">Back To Home</a>&nbsp;<asp:Button ID="btnExcel" runat ="server" Text ="Export To Excel Format" />
			</td>
        </tr>
    </table>
</form>
<br />
</asp:Content>

