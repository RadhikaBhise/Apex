<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="DriveOfReport.aspx.vb" Inherits="DriveOfReport" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="Form1" method="post" runat="server">
        <table cellspacing="0" cellpadding="0" border="0">
            <tr>
                <td class="css_header">Top Driver Report</td>
            </tr>
            <tr><td align ="left">
                <asp:label id="Label1" Runat="Server" Font-Names="Arial" Font-Size="Larger" Font-Bold="True"></asp:label></td></tr>
            <tr>
						<td align="center"  bgcolor="darkgray"><asp:datagrid id="DataGrid_VoucherList" runat="server" Font-Names="Arial" Font-Size="Small" ShowFooter="True"
								AllowSorting="True" BackColor="Gainsboro" AutoGenerateColumns="False" ForeColor="Black" BorderColor="Gray">
								<SelectedItemStyle Wrap="False"></SelectedItemStyle>
								<EditItemStyle Wrap="False"></EditItemStyle>
								<AlternatingItemStyle Font-Size="Smaller" Font-Names="Arial" Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"
									BackColor="White"></AlternatingItemStyle>
								<ItemStyle Font-Size="Smaller" Font-Names="Arial" Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								<HeaderStyle Font-Size="Smaller" Font-Underline="True" Font-Names="Arial" Wrap="False" HorizontalAlign="Center"
									ForeColor="White" VerticalAlign="Middle" BackColor="DarkBlue"></HeaderStyle>
								<FooterStyle Font-Size="Smaller" Font-Names="Arial" Font-Bold="True" Wrap="False" HorizontalAlign="Center"
									ForeColor="White" VerticalAlign="Middle" BackColor="DarkBlue"></FooterStyle>
								<Columns>
									<asp:TemplateColumn SortExpression="car_no" HeaderText="CAR NO.">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:HyperLink ID="HyperLink1" runat="server" ForeColor ="Blue" Text='<%# DataBinder.Eval(Container, "DataItem.car_no") %>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.car_no", "DriveOfReport2.aspx?CarNo="+DataBinder.Eval(Container.DataItem,"car_no").ToString()) %>'>
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="totalBase" SortExpression="totalBase" ReadOnly="True" HeaderText="RATE">
										<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="totalTolls" SortExpression="totalTolls" ReadOnly="True"
										HeaderText="TOLLS" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="totalParking" SortExpression="totalParking" ReadOnly="True" HeaderText="PARKING" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="totalWait" SortExpression="totalWait" ReadOnly="True" HeaderText="WAIT">
										<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
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
										<ItemStyle Wrap="False"></ItemStyle>
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
									<asp:BoundColumn DataField="totalCount" SortExpression="totalCount" ReadOnly="True" HeaderText="NO. OF RIDES" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="avgNet" SortExpression="avgNet" ReadOnly="True" HeaderText="AVG. COST" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle VerticalAlign="Middle" Font-Size="X-Small" Font-Names="Arial" HorizontalAlign="Left"
									ForeColor="Red" BackColor="Silver" Wrap="False" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</tr>
					<tr>
						<td align="center"></td>
					</tr>
					<tr class="noshown" id="trpage" runat="server">
						<td align="left"><font face="Arial" size="2">Page&nbsp;
								<asp:label id="lbl_PageIndex" runat="server" Font-Names="Arial"></asp:label>&nbsp;of&nbsp;
								<asp:label id="lbl_PageAmount" runat="server" Font-Names="Arial"></asp:label></font></td>
					</tr>
					<tr><td>ALL VEHICLES ARE INDEPENDENTLY OWNED AND OPERATED</td></tr>
					<tr><td><a href ="">Back To Home</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href ="rptmenu.aspx">Report Page</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href ="default.aspx">Main Menu</a></td></tr>
</table>
</form>
</asp:Content>

