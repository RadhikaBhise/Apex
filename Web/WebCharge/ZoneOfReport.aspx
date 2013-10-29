<%@ Page Language="VB" MasterPageFile="~/MasterPage_New.master" AutoEventWireup="false" CodeFile="ZoneOfReport.aspx.vb" Inherits="ZoneOfReport" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<form id="Form1" method="post" runat="server">
<table cellspacing="0" cellpadding="0" border="0" class="tb-bg" width="100%">
<tr><td align ="left"><asp:label id="lbl_TabCap" Runat="Server" Font-Names="Arial" Font-Size="Larger" Font-Bold="True">Invoice Inquiry Results:&nbsp;</asp:label></td></tr>
<tr><td align ="left"><asp:Label ID="lbl_invoice" runat ="server" Font-Names="Arial"></asp:Label></td></tr>
<tr valign="top">
						<td align="center" style="width:100%;"><asp:datagrid id="DataGrid_VoucherList" AllowPaging="true" Width="100%"  runat="server" Font-Names="Arial" Font-Size="Small" ShowFooter="True"
								AllowSorting="True" BackColor="Gainsboro" AutoGenerateColumns="False" ForeColor="Black" borderColor="Gray">
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
									<asp:TemplateColumn HeaderText="PU">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:HyperLink ID="HyperLink1" runat="server" ForeColor ="Blue"></asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="DO">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:Label ID="lbldo" runat ="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="no_rides" SortExpression="no_rides" ReadOnly="True" HeaderText="TRIPS">
										<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="s_base" SortExpression="s_base" ReadOnly="True"
										HeaderText="BASE $" DataFormatString="{0:#,###,##0.00}">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="a_base" SortExpression="a_base" ReadOnly="True" HeaderText="AVG BASE $" DataFormatString="{0:#,###,##0.00}">
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
						<td align="center"><FONT face="Arial" size="2">Page&nbsp;
								<asp:label id="lbl_PageIndex" runat="server" Font-Names="Arial"></asp:label>&nbsp;of&nbsp;
								<asp:label id="lbl_PageAmount" runat="server" Font-Names="Arial"></asp:label><asp:Button ID="btnExcel" runat ="server" Text ="Export To Excel Format" /></FONT></td>
					</tr>
					<tr>
					<td align="center"><a href ="javascript:history.back()">Back</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="rptmenu.aspx">Report Menu</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="default.aspx">Main Menu</a></td>
				</tr>
				<tr>
                <td align="center" style="height:40">
                </td>
            </tr>
</table>
</form>
</asp:Content>

