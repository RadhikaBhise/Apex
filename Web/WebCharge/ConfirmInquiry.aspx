<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConfirmInquiry.aspx.vb" Inherits="ConfirmInquiry" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script language="javascript" type="text/javascript">
        function batchvalidate()
        {   
            var pudate=document.all['ctl00_MainContent_txtDateAfter'].value;
            
            if (pudate=="")
            {
                alert('Please enter Trip Date on After!');
                document.all['ctl00_MainContent_txtDateAfter'].focus();
                return false;
            }
            if (!CheckDate(pudate))
            {
                alert('Trip Date On After enter is invalid');
                document.all['ctl00_MainContent_txtDateAfter'].focus();
                return false;
           }
        }
    </script>
    <form id="Form1" method="post" runat="server">
        
        <table id="Table1" width="100%" border="0">
		    <tr>
			    <td align="left">
			        <table width="600px">
			            <tr>
			                <td class="css_header">
			                    Confirmation # Inquiry
			                </td>
			            </tr>
			        </table>
			    </td>
		    </tr>
		    <tr id="trSearch" runat="server">
			    <td align="left">
				    <table id="Table2" width="600px" border="0" >
					    <tr>
						    <td colspan="2" class="css_desc" style="width:350px;">Please Enter Confirmation Numbers (In 10 digit form)</td>
						    <td class="css_desc" style="width:150px;">Trip Date On After</td>
					    </tr>
					    <tr>
						    <td class="font3">&nbsp; 1.<asp:textbox id="txtcn01" runat="server" Width="115px" tabIndex="1"></asp:textbox></td>
						    <td class="font3">&nbsp; 2.<asp:textbox id="txtcn02" runat="server" Width="115px" tabIndex="2"></asp:textbox></td>
					        <td class="font3"  align="center" rowspan="8" valign="middle"><asp:textbox id="txtDateAfter" runat="server" Width="105px"></asp:textbox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="txtDateAfter"
                                    ErrorMessage="Please enter Trip Date on After!"></asp:RequiredFieldValidator></td>
					    </tr>
					    <tr>
						    <td class="font3">&nbsp; 3.<asp:textbox id="txtcn03" runat="server" Width="115px" tabIndex="3"></asp:textbox></td>
						    <td class="font3">&nbsp; 4.<asp:textbox id="txtcn04" runat="server" Width="115px" tabIndex="4"></asp:textbox></td>
					    </tr>
					    <tr>
						    <td class="font3">&nbsp; 5.<asp:textbox id="txtcn05" runat="server" Width="115px" tabIndex="5"></asp:textbox></td>
						    <td class="font3">&nbsp; 6.<asp:textbox id="txtcn06" runat="server" Width="115px" tabIndex="6"></asp:textbox></td>
					    </tr>
					    <tr>
						    <td class="font3">&nbsp; 7.<asp:textbox id="txtcn07" runat="server" Width="115px" tabIndex="7"></asp:textbox></td>
						    <td class="font3">&nbsp; 8.<asp:textbox id="txtcn08" runat="server" Width="115px" tabIndex="8"></asp:textbox></td>
					    </tr>
					    <tr>
						    <td class="font3">&nbsp; 9.<asp:textbox id="txtcn09" runat="server" Width="115px" tabIndex="9"></asp:textbox></td>
						    <td class="font3">10.<asp:textbox id="txtcn10" runat="server" Width="115px" tabIndex="10"></asp:textbox></td>
					    </tr>
					    <tr>
						    <td class="font3">11.<asp:textbox id="txtcn11" runat="server" Width="115px" tabIndex="11"></asp:textbox></td>
						    <td class="font3">12.<asp:textbox id="txtcn12" runat="server" Width="115px" tabIndex="12"></asp:textbox></td>
					    </tr>
					    <tr>
						    <td class="font3">13.<asp:textbox id="txtcn13" runat="server" Width="115px" tabIndex="13"></asp:textbox></td>
						    <td class="font3">14.<asp:textbox id="txtcn14" runat="server" Width="115px" tabIndex="14"></asp:textbox></td>
					    </tr>
					    <tr>
						    <td class="font3">15.<asp:textbox id="txtcn15" runat="server" Width="115px" tabIndex="15"></asp:textbox></td>
						    <td class="font3">&nbsp;</td>
					    </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:button id="btnSubmit" tabIndex="16" runat="server" Text="Submit"></asp:button>&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                                <asp:button id="btnReset" tabIndex="17" runat="server" Text="Reset"></asp:button>
                            </td>
                        </tr>
				    </table>
			    </td>
		    </tr>
            <tr id="trData" runat="server">
                <td colspan="5">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:DataGrid ID="grdData" runat="server"  HorizontalAlign="Left"  PageSize="20" AutoGenerateColumns="False" Width="100%" AllowPaging="true">
				                    <SelectedItemStyle Wrap="False"></SelectedItemStyle>
				                    <EditItemStyle Wrap="False"></EditItemStyle>
				                    <AlternatingItemStyle CssClass="css_alterdesc"></AlternatingItemStyle>
				                    <ItemStyle CssClass="css_itemdesc"></ItemStyle>
				                    <HeaderStyle CssClass="css_title"></HeaderStyle>
                                    <Columns>
                                        <asp:TemplateColumn HeaderText="VOUCHER #" SortExpression="confirmation_no">
                                            <ItemStyle/>
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.confirmation_no", "ConfirmationDetail.aspx?confirmation="+DataBinder.Eval(Container.DataItem,"confirmation_no").ToString()) %>'
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.confirmation_no") %>'>
											            </asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn DataField="Pu_Date_Time" HeaderText="VOUCHER DATE" ReadOnly="True" DataFormatString="{0:MM/dd/yyyy hh:mm tt}">
                                            <ItemStyle Wrap="False" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="invoice_no" HeaderText="INVOICE #" ReadOnly="True"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="invoice_date" DataFormatString="{0:MM/dd/yyyy hh:mm tt}"
                                            HeaderText="INVOICE DATE" ReadOnly="True"></asp:BoundColumn>
                                    </Columns>
                                    <PagerStyle CssClass="css_pagedesc"  Mode="NumericPages"></PagerStyle>
                                </asp:DataGrid>
                            </td>
                        </tr>

                        <tr>
	                        <td align="left">
	                            Page&nbsp;
                                <asp:Label ID="lbl_PageIndex" runat="server" Font-Names="Arial"></asp:Label>of&nbsp;
                                <asp:Label ID="lbl_PageAmount" runat="server" Font-Names="Arial"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="~/Images/ExportToExcelFormat.gif" /></td>
	                    </tr>
                    </table>
                </td>
            </tr>
		    <tr>
			    <td align="center">
			    <br />
                    <asp:LinkButton ID="btnBack" runat="server">Back To Voucher Inquiry</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp; 
                    <a href="default.aspx">Back To Main Menu</a></td>
		    </tr>
	    </table>
    </form>
</asp:Content>

