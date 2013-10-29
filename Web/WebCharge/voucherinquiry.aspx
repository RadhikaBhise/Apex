<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="VoucherInquiry.aspx.vb" Inherits="VoucherInquiry" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
  <%--  <script language="javascript" type="text/javascript">
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
    </script>--%>
    <script type="text/javascript" language="javascript">
    function ShowVoucherImage(vno,cno)
    {
        var width = 700+30;    //window.screen.width - 150;
        var height = 400+40;   //window.screen.height - 230;
       
        window.open("voucherimage.aspx?vno="+vno+"&cno="+cno, "_VoucherDetail", "height=" + height
				                + ",left=75,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,"
				                + "toolbar=no,top=115,width=" + width);
	              
				              
    }
</script>
<form id="Form1" method="post" runat="server">
        
<table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">

    <tr>
        <td class="css_header" style="padding-left:105px">Voucher Inquiry
        </td>
	      
    </tr>
    <tr id="trSearch" runat="server">
	    <td align="center">
		    <table id="Table2" cellspacing="2" cellpadding="2" width="600px" border="0">
			    <tr>
				    <td colspan="2" class="css_desc" style="width:350px;">Please Enter up to 15 Voucher Numbers</td>
				    <td class="css_desc" style="width:150px;">Trip Date On Or After</td>
			    </tr>
			    <tr>
				    <td class="font3">&nbsp; 1.<asp:textbox id="txtcn01" runat="server" Width="115px" tabIndex="1"></asp:textbox></td>
				    <td class="font3">&nbsp; 2.<asp:textbox id="txtcn02" runat="server" Width="115px" tabIndex="2"></asp:textbox></td>
			        <td class="font3" rowspan="8" valign="middle"><asp:textbox id="txtDateAfter" runat="server" Width="115px"></asp:textbox>
			        <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDateAfter"
                            ErrorMessage="Please enter Trip Date on or After!"></asp:RequiredFieldValidator></td>
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
                    <td colspan="3" align="center"><br />
                        <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/Images/Submit.gif" /> &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                        <asp:ImageButton ID="btnReset" runat="server" ImageUrl="~/Images/Reset.gif" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center"><br />
                    <a href="default.aspx">Back To Main Menu</a></td>
                </tr>
		    </table>
	    </td>
    </tr>
    <tr id="trData" runat="server">
        <td align="center">
            <table width="600px">
                <tr>
                    <td align="left">
                        <asp:DataGrid ID="grdData" HorizontalAlign="Left" PageSize="20" runat="server" AutoGenerateColumns="False" AllowPaging="true"  Width="100%">
				                <SelectedItemStyle Wrap="False"></SelectedItemStyle>
				                <EditItemStyle Wrap="False"></EditItemStyle>
				                <AlternatingItemStyle CssClass="css_alterdesc"></AlternatingItemStyle>
				                <ItemStyle CssClass="css_itemdesc"></ItemStyle>
				                <HeaderStyle CssClass="css_title"></HeaderStyle>
				                <FooterStyle CssClass="css_footdesc"></FooterStyle>
                            <Columns>
                                <asp:TemplateColumn HeaderText="VOUCHER #" SortExpression="confirmation_no">
                                    <ItemStyle/>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server"  ForeColor ="Blue" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.voucher_no", "VoucherInquiryDetails.aspx?VoucherNo="+DataBinder.Eval(Container.DataItem,"voucher_no").ToString()& "&InvoiceNo="+DataBinder.Eval(Container.DataItem,"invoice_no").ToString() ) %>'
                                            Text='<%# DataBinder.Eval(Container, "DataItem.voucher_no") %>'>
									    </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="Pu_Date_Time" HeaderText="VOUCHER DATE" ReadOnly="True" DataFormatString="{0:MM/dd/yyyy hh:mm tt}">
                                    <ItemStyle Wrap="False" />
                                    <HeaderStyle Wrap="false" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="invoice_no" HeaderText="INVOICE #" ReadOnly="True">
                                    <ItemStyle Wrap="False" />
                                    <HeaderStyle Wrap="false" />
                                 </asp:BoundColumn>
                                <asp:BoundColumn DataField="invoice_date" DataFormatString="{0:MM/dd/yyyy hh:mm tt}"
                                    HeaderText="INVOICE DATE" ReadOnly="True">
                                     <ItemStyle Wrap="False" />
                                    <HeaderStyle Wrap="false" />
                                </asp:BoundColumn>
                                <asp:TemplateColumn>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkImage" runat="server" NavigateUrl='<%# "javascript:ShowVoucherImage(""" & DataBinder.Eval(Container.DataItem,"voucher_no").ToString().Trim() & """,""" & DataBinder.Eval(Container.DataItem, "confirmation_no").ToString.Trim & """)" %>' Text="View Voucher Image"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle CssClass="css_pagedesc"  Mode="NumericPages" Visible="false"></PagerStyle>
                        </asp:DataGrid>
                    </td>
                </tr>
                <tr class="noshown" id="trpage" runat="server">
                    <td align="left"><br />
	                    <div style="display:none">Page&nbsp;
	                    <asp:label id="lblPageIndex" runat="server" Font-Names="Arial"></asp:label>&nbsp;of&nbsp;
	                    <asp:label id="lblPageCount" runat="server" Font-Names="Arial"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                       
                        </div><asp:ImageButton ID="btnExcel" runat="server" ImageUrl="~/Images/ExportToExcelFormat.gif" /></td>
                </tr>
                <tr >
                <td colspan="4" align="center"><br />
                    <asp:LinkButton ID="btnBack" runat="server">Back To Voucher Inquiry</asp:LinkButton> &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                    <a href="default.aspx">Back To Main Menu</a></td>
                </tr>
            </table>
        </td>
    </tr>

<%--    <tr 　 align="center">
	    <td 　 align="center" class="css_font" >
            <asp:LinkButton ID="btnBack" runat="server">Back To Voucher Inquiry</asp:LinkButton>
            &nbsp;&nbsp; <a href="default.aspx">Back To Home</a><br /><br />
         </td>
    </tr>--%>
</table>
</form>
<br />
</asp:Content>

