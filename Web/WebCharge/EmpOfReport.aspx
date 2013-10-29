<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EmpOfReport.aspx.vb" Inherits="PassOfReport" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<form id="Form1" method="post" runat="server">
<table cellspacing="2" cellpadding="2" border="0" width="808px">
    <tr><td align="left" class="css_desc" ><asp:label id="lbl_TabCap" Runat="Server" ></asp:label></td></tr>
    <tr>
		<td >
		    <asp:datagrid id="DataGrid_VoucherList" PageSize="20" runat="server" AutoGenerateColumns="False" AllowPaging="True" Width="100%" AllowSorting="True">
				    <SelectedItemStyle Wrap="False"></SelectedItemStyle>
				    <EditItemStyle Wrap="False"></EditItemStyle>
				    <AlternatingItemStyle CssClass="css_alterdesc"></AlternatingItemStyle>
				    <ItemStyle CssClass="css_itemdesc"></ItemStyle>
				    <HeaderStyle CssClass="css_title"></HeaderStyle>
				    <FooterStyle CssClass="css_footdesc"></FooterStyle>
				<Columns>
					<asp:TemplateColumn SortExpression="vip_no" HeaderText="EMP NO.">
						<ItemStyle></ItemStyle>
						<ItemTemplate>
							<asp:HyperLink ID="HyperLink1" runat="server" ForeColor ="Blue" Text='<%# DataBinder.Eval(Container, "DataItem.vip_no") %>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.vip_no", "empOfReport2.aspx?VipNo="+DataBinder.Eval(Container.DataItem,"vip_no").ToString()) %>'>
							</asp:HyperLink>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="totalBase" DataFormatString="{0:#,###,##0.00}" HeaderText="RATE"
                        ReadOnly="True" SortExpression="totalBase">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalTolls" SortExpression="totalTolls" ReadOnly="True"
						HeaderText="TOLLS" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalParking" SortExpression="totalParking" ReadOnly="True" HeaderText="PARKING" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalWait" SortExpression="totalWait" ReadOnly="True" HeaderText="WAIT">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalStop" SortExpression="totalStop" ReadOnly="True" HeaderText="STOPS" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalSW" SortExpression="totalSW" ReadOnly="True" HeaderText="STOPS/W.T." DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalPackage" SortExpression="totalPackage" ReadOnly="True" HeaderText="PACKAGE" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalMisc" SortExpression="totalMisc" ReadOnly="True" HeaderText="MISC" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalPhone" SortExpression="totalPhone" ReadOnly="True" HeaderText="PHONE" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalTips" SortExpression="totalTips" ReadOnly="True" HeaderText="TIPS" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalService" SortExpression="totalService" ReadOnly="True" HeaderText="SERVICE" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalGross" SortExpression="totalGross" ReadOnly="True" HeaderText="GROSS" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalDiscount" SortExpression="totalDiscount" ReadOnly="True" HeaderText="DISCOUNT" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalNet" SortExpression="totalNet" ReadOnly="True" HeaderText="NET" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="totalCount" SortExpression="totalCount" ReadOnly="True" HeaderText="NO. OF RIDES" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="avgNet" SortExpression="avgNet" ReadOnly="True" HeaderText="AVG. COST" DataFormatString="{0:#,###,##0.00}">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
				</Columns>
				    <PagerStyle CssClass="css_pagedesc"  Mode="NumericPages"></PagerStyle>
			</asp:datagrid></td>
	</tr>

	<tr class="noshown" id="trpage" runat="server">
		<td align="left" class="css_font" >Page&nbsp;
				<asp:label id="lbl_PageIndex" runat="server" Font-Names="Arial"></asp:label>&nbsp;of&nbsp;
				<asp:label id="lbl_PageAmount" runat="server" Font-Names="Arial"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	            <a href ="default.aspx">Back To Main Menu</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href ="rptmenu.aspx">Back To Report Page</a>
	            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnExcel" runat ="server" Text ="Export To Excel Format" />
	    </td>
	</tr>
</table>
</form>
</asp:Content>

