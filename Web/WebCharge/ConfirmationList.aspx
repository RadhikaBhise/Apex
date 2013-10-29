<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConfirmationList.aspx.vb" Inherits="ConfirmationList" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<form id="Form1" name="Form1" method="post" runat="server">
<table width="100%" border="0">
<tr >
<td align ="left" class="css_desc">Invoice&nbsp;Index&nbsp;Results:
</td></tr>
<tr id="trData" runat="server">
<td colspan="5">
<table style="width:100%">
  <tr><td>
  <asp:datagrid id="DataGrid_Confirm" runat="server"  HorizontalAlign="Left" Font-Names="Arial" Font-Size="Small" 
  AutoGenerateColumns="False" BorderColor="Gray" Width="30%" AllowSorting="True" ShowFooter="False" PageSize="20" AllowPaging="true">
				                <SelectedItemStyle Wrap="False"></SelectedItemStyle>
				                <EditItemStyle Wrap="False"></EditItemStyle>
				                <AlternatingItemStyle CssClass="css_alterdesc"></AlternatingItemStyle>
				                <ItemStyle CssClass="css_itemdesc"></ItemStyle>
				                <HeaderStyle CssClass="css_title"></HeaderStyle>
				                <FooterStyle CssClass="css_footdesc"></FooterStyle>
									<Columns>
									<asp:TemplateColumn SortExpression="confirmation_no" HeaderText="CONFIRMATION #">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:HyperLink ID="HyperLink1" runat="server" ForeColor ="Blue" Text='<%# DataBinder.Eval(Container, "DataItem.confirmation_no") %>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.confirmation_no", "ConfirmationDetail.aspx?confirmation="+DataBinder.Eval(Container.DataItem,"confirmation_no").ToString()) %>'>
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="Pu_Date_Time" SortExpression="Pu_Date_Time" ReadOnly="True" HeaderText="TRIP DATE">
										<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50%"></ItemStyle>
									</asp:BoundColumn>
								 </Columns>
					<PagerStyle CssClass="css_pagedesc"  Mode="NumericPages"></PagerStyle>
	</asp:datagrid>
  </td></tr>
  
<tr class="noshown" id="trpage" runat="server">
  <td align="left" class="css_font"><br />Page&nbsp;
  <asp:label id="lbl_PageIndex" runat="server" Font-Names="Arial"></asp:label>&nbsp;of&nbsp;
  <asp:label id="lbl_PageAmount" runat="server" Font-Names="Arial"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</td></tr>

</table>
</td></tr>
  	        <tr>
	            <td align="center">
	                <br />
	                <a href ="rptmenu.aspx">Back to Confirmation # Inquiry</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	                <a href ="default.aspx">Back To Main Menu</a><br />
                    <asp:HiddenField ID="hdnSort" runat="server" />
    	         </td>
	        </tr>
</table>
</form>
</asp:Content>

