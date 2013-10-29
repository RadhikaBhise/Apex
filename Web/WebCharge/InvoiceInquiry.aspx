<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="InvoiceInquiry.aspx.vb" Inherits="InvoiceInquiry" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

<form id="Form2" method="post" runat="server">
   <table id="Table1" width="100%" border="0">
	    <tr>
		    <td class="css_header" colspan="5" >Invoice Inquiry</td>
	    </tr>
        <tr>
            <td class="css_desc" >From Invoice Date</td>
		    <td class="css_desc" >To Invoice Date</td>
		    <td class="css_desc">Invoice Number</td>
		    <td class="css_desc"></td>
		    <td class="css_desc" style="width:12.5%; display:none" ></td>
        </tr>
        <tr>
		    <td class="font3" align="left"><asp:textbox id="txt_InVoiceDate" runat="server" Columns="10" MaxLength="10" Width="100px"></asp:textbox></td>
		    <td class="font3" align="left"><asp:textbox id="txt_ToInVoiceDate" runat="server" Columns="10" MaxLength="10" Width="100px"></asp:textbox></td>
            <td class="font3" align="left"><asp:textbox id="txt_InVoiceNo" runat="server" Columns="10" MaxLength="10" Width="100px"></asp:textbox></td>
		    <td class="font3" align="left">
                <asp:ImageButton ID="btnSubmit" runat="server"  ImageAlign="Left" ImageUrl="~/Images/Submit.gif" />
            </td>
		    <td class="font3" align="left" style="display:none">		        
		        <input type="image" src="Images/Reset.gif" onclick="javscript:document.forms[0].reset();return false;" />
		    </td>
        </tr>
       
         <tr>
            <td colspan="5"  style="height:10px"></td>
        </tr>
        <tr id="trData" runat="server">
            <td colspan="5">
                <table style="width:100%">
                    <tr >
                        <td align ="left" class="css_desc">
                            Your&nbsp;Requested&nbsp;Invoice&nbsp;Index:
                        </td>
                    </tr>
                    <tr>
		                <td>
		                    <asp:datagrid id="grdData" runat="server"  HorizontalAlign="Left" Width="100%" PageSize="20" AutoGenerateColumns="False"  AllowPaging="True" AllowSorting="true">
				                <SelectedItemStyle Wrap="False"></SelectedItemStyle>
				                <EditItemStyle Wrap="False"></EditItemStyle>
				                <AlternatingItemStyle CssClass="css_alterdesc" Wrap="False"></AlternatingItemStyle>
				                <ItemStyle CssClass="css_itemdesc" Wrap="False"></ItemStyle>
				                <HeaderStyle CssClass="css_title" Wrap="False"></HeaderStyle>
				                <FooterStyle CssClass="css_footdesc" Wrap="False"></FooterStyle>
				               <Columns>
					                <asp:TemplateColumn  SortExpression="invoice_date" HeaderText="Date">
							            <ItemStyle Wrap="False"></ItemStyle>
							            <HeaderStyle Wrap="false" />
							            <ItemTemplate>
								            <asp:HyperLink ID="lnkInvoiceNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Invoice_Date") %>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.Invoice_No", "InvoiceInquiryReport2.aspx?InvoiceNo={0}"+"&InvoiceDate="+DataBinder.Eval(Container.DataItem,"Invoice_Date")) %>'>
								            </asp:HyperLink>
							            </ItemTemplate>
						            </asp:TemplateColumn>
					                <asp:BoundColumn DataField="Invoice_No" SortExpression="Invoice_No" ReadOnly="True" HeaderText="INVOICE#">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
					                <asp:BoundColumn DataField="base_rate" SortExpression="base_rate" ReadOnly="True" HeaderText="RATE" DataFormatString="{0:#,###,##0.00}">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
					                <asp:BoundColumn DataField="tips" SortExpression="tips" ReadOnly="True" HeaderText="TIPS" DataFormatString="{0:#,###,##0.00}">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
						            <asp:BoundColumn DataField="tolls" SortExpression="tolls" ReadOnly="True" HeaderText="TOLLS" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False"></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="phone_amt" SortExpression="phone_amt" ReadOnly="True" HeaderText="PHONE" DataFormatString="{0:#,###,##0.00}">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="stops_amt" SortExpression="stops_amt" ReadOnly="True" HeaderText="STOPS" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False"></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="wait_amount" SortExpression="wait_amount" ReadOnly="True" HeaderText="W.T." DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False"></ItemStyle>
							            <HeaderStyle Wrap="false" />							            
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="Parking" SortExpression="Parking" ReadOnly="True" HeaderText="PARKING" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False"></ItemStyle>
							            <HeaderStyle Wrap="false" />							            
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="package_amt" SortExpression="package_amt" ReadOnly="True" HeaderText="PAKG#" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False"></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="miscellaneous" SortExpression="miscellaneous" ReadOnly="True" HeaderText="MISC." DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False"></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="Discount" SortExpression="Discount" ReadOnly="True" HeaderText="DISC." DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False"></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="Net" SortExpression="Net" ReadOnly="True" HeaderText="TOTAL" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False"></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
            					    					    
				                </Columns>
				                <PagerStyle CssClass="css_pagedesc"  Mode="NumericPages"></PagerStyle>
			                </asp:datagrid>
		                </td>
	                </tr>
	             
	                <tr class="noshown" id="trpage" runat="server">
		                <td align="left" style="height: 52px"><br />
		                    Page&nbsp;
		                    <asp:label id="lblPageIndex" runat="server" Font-Names="Arial"></asp:label>&nbsp;of&nbsp;
		                    <asp:label id="lblPageCount" runat="server" Font-Names="Arial"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		                    <asp:ImageButton ID="btnExcel" runat="server" ImageAlign="Middle" ImageUrl="~/Images/ExportToExcelFormat.gif" /><br />
                        </td>
	                </tr>
	          </table>
	        </td>
	    </tr>
	    <tr>
	            <td align="center" colspan="5">
	                <br />
	                <a href ="default.aspx">Back To Main Menu</a><br />
                    <asp:HiddenField ID="hdnSort" runat="server" />
	            </td>
	    </tr>
</table>
</form>
 
</asp:Content>

