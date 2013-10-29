<%@ Page Language="VB" MasterPageFile="~/MasterPage_New.master" AutoEventWireup="false" CodeFile="zoneOfReport2.aspx.vb" Inherits="zoneOfReport2" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<form id="Form1" method="post" runat="server">
<table cellspacing="0" cellpadding="0" border="0" class="tb-bg" width="100%" align="center">
<tr><td align ="left"><asp:label id="lbl_TabCap" Runat="Server" Font-Names="Arial" Font-Size="Larger" Font-Bold="True">Invoice Inquiry Results:&nbsp;</asp:label></td></tr>
<tr><td align ="left"><asp:Label ID="lbl_invoice" runat ="server" Font-Names="Arial"></asp:Label></td></tr>
<tr>
						<td align="center" class="form">
						<div style="OVERFLOW:auto;width:100%;">
						<asp:datagrid id="DataGrid_VoucherList"  AllowPaging="true"  runat="server" Font-Names="Arial" Font-Size="Small" ShowFooter="True"
								AllowSorting="True" BackColor="Gainsboro" AutoGenerateColumns="False" ForeColor="Black" borderColor="Gray" PageSize="20" Width="100%">
								<SelectedItemStyle Wrap="False"></SelectedItemStyle>
								<EditItemStyle Wrap="False"></EditItemStyle>
								<AlternatingItemStyle Font-Size="Smaller" Font-Names="Arial" Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"
									BackColor="White"></AlternatingItemStyle>
								<ItemStyle Font-Size="Smaller" Font-Names="Arial" Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								<HeaderStyle Font-Size="Smaller" Font-Underline="True" Font-Names="Arial" Wrap="False" HorizontalAlign="Center"
									ForeColor="White" VerticalAlign="Middle" cssclass="bodyfont"></HeaderStyle>
								<FooterStyle Font-Size="Smaller" Font-Names="Arial" Font-Bold="True" Wrap="False" HorizontalAlign="Center"
									ForeColor="White" VerticalAlign="Middle" cssclass="bodyfont"></FooterStyle>
								<Columns>
									<%--<asp:BoundColumn DataField="Invoice_No" SortExpression="Invoice_No" ReadOnly="True" HeaderText="INVOICE#" Visible="false">
										<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>--%>
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
									<%--<asp:BoundColumn DataField="Pu_Date_Time" SortExpression="Pu_Date_Time" ReadOnly="True" HeaderText="P/U TIME" Visible="false">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>--%>
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
								<PagerStyle VerticalAlign="Middle" Font-Size="X-Small" Font-Names="Arial" HorizontalAlign="Left"
									ForeColor="Red" BackColor="Silver" Wrap="False" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></div></td>
					</tr>
					<tr>
						<td align="center"></td>
					</tr>
					<tr class="noshown" id="trpage" runat="server">
						<td align="center"><FONT face="Arial" size="2">Page&nbsp;
								<asp:label id="lbl_PageIndex" runat="server" Font-Names="Arial"></asp:label>&nbsp;of&nbsp;
								<asp:label id="lbl_PageAmount" runat="server" Font-Names="Arial"></asp:label>
									&nbsp;<asp:Button ID="btnExcel" runat ="server" Text ="Export To Excel Format" /></FONT></td>
					</tr>
					<tr>
					<td align="center"><a href="#" onclick="history.go(-1);">Back</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="rptmenu.aspx">Report Menu</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="default.aspx">Main Menu</a></td>
				</tr>
				<tr>
                <td align="center" style="height:40">
                </td>
            </tr>
</table>
</form>
</asp:Content>

