<%--<%@ Page Language="VB" MasterPageFile="~/MasterPage_New.master" AutoEventWireup="false" CodeFile="PassOfReport.aspx.vb" Inherits="PassOfReport" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<form id="Form1" method="post" runat="server">
<table cellspacing="0" cellpadding="0" border="0" class="tb-bg" width="100%">
<tr><td align ="left" ><asp:label id="lbl_TabCap" Runat="Server" Font-Names="Arial" Font-Size="Larger" Font-Bold="True">Invoice Inquiry Results:&nbsp;</asp:label></td></tr>
<tr><td align ="left"><asp:Label ID="lbl_invoice" runat ="server" Font-Names="Arial"></asp:Label><input type="hidden" id="hdnSort" name="hdnSort" runat="server" /></td></tr>
<tr>
						<td align="center" class="form">
						<div style="OVERFLOW:auto;width:100%;">
						<asp:datagrid id="DataGrid_VoucherList" runat="server"  AllowPaging="true"  Font-Names="Arial" Font-Size="Small" ShowFooter="True" PageSize="20"
								AllowSorting="True" BackColor="Gainsboro" AutoGenerateColumns="False" ForeColor="Black" borderColor="Gray" Width="100%">
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
									<asp:TemplateColumn SortExpression="passenger_name" HeaderText="Passenger Name">
										<ItemStyle HorizontalAlign="right"></ItemStyle>
										<ItemTemplate>
											<asp:HyperLink ID="HyperLink1" runat="server" ForeColor ="Blue" Text='<%# DataBinder.Eval(Container, "DataItem.passenger_name") %>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.passenger_name", "PassOfReport2.aspx?VipNo="+DataBinder.Eval(Container.DataItem,"vip_no").ToString()) %>'>
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="totalBase" SortExpression="totalBase" ReadOnly="True" HeaderText="RATE" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle Wrap="False" HorizontalAlign="right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="totalTolls" SortExpression="totalTolls" ReadOnly="True" HeaderText="TOLLS" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle Wrap="False" HorizontalAlign="right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="totalParking" SortExpression="totalParking" ReadOnly="True" HeaderText="PARKING" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="totalWait" SortExpression="totalWait" ReadOnly="True" HeaderText="WAIT" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle Wrap="False" HorizontalAlign="right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="totalStop" SortExpression="totalStop" ReadOnly="True" HeaderText="STOPS" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="totalSW" SortExpression="totalSW" ReadOnly="True" HeaderText="STOPS/W.T." DataFormatString="{0:#,###,##0.00}">
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="totalPackage" SortExpression="totalPackage" ReadOnly="True" HeaderText="PACKAGE" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle Wrap="False"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="totalMisc" SortExpression="totalMisc" ReadOnly="True" HeaderText="MISC" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="totalPhone" SortExpression="totalPhone" ReadOnly="True" HeaderText="PHONE" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="totalTips" SortExpression="totalTips" ReadOnly="True" HeaderText="TIPS" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="totalService" SortExpression="totalService" ReadOnly="True" HeaderText="SERVICE" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="totalGross" SortExpression="totalGross" ReadOnly="True" HeaderText="GROSS" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="totalDiscount" SortExpression="totalDiscount" ReadOnly="True" HeaderText="DISCOUNT" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="totalNet" SortExpression="totalNet" ReadOnly="True" HeaderText="NET" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="totalCount" SortExpression="totalCount" ReadOnly="True" HeaderText="NO. OF RIDES" DataFormatString="{0:#,###,##0}">
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="avgNet" SortExpression="avgNet" ReadOnly="True" HeaderText="AVG. COST" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle VerticalAlign="Middle" Font-Size="X-Small" Font-Names="Arial" HorizontalAlign="Left"
									ForeColor="Red" BackColor="Silver" Wrap="False" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></div></td>
					</tr>
					
					<tr class="noshown" id="trpage" runat="server">
						<td align="center"><FONT face="Arial" size="2">Page&nbsp;
								<asp:label id="lbl_PageIndex" runat="server" Font-Names="Arial"></asp:label>&nbsp;of&nbsp;
								<asp:label id="lbl_PageAmount" runat="server" Font-Names="Arial"></asp:label><asp:Button ID="btnExcel" runat ="server" Text ="Export To Excel Format" /></FONT></td>
					</tr>
					<tr>
						<td align="center" style="height:20px"></td>
					</tr>
					<tr>
					<td align="center"><a href="rptofpass.aspx">Back</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="rptmenu.aspx">Report Menu</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="default.aspx">Main Menu</a></td>
				</tr>
				<tr>
                <td align="center" style="height:40px">
                </td>
            </tr>
</table>
</form>
</asp:Content>--%>


