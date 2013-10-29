<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RptOfDrive.aspx.vb" Inherits="RptOfDrive" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<script language="javascript" type="text/javascript">
function batchvalidate(stracct,from,to,top)
{

    var fromdate=document.getElementById(from).value;
    var todate=document.getElementById(to).value;

    if(fromdate=="")
	{
		alert("From Date should not be blank!");
		return false;
	}
	if(todate=="")
	{
		alert("To Date should not be blank!");
		return false;
	}
	if(!CheckDate(fromdate)){
	    alert("From Date is invalid!");
	    return false;
	}
	if(!CheckDate(todate)){
	    alert("From Date is invalid!");
	    return false;
	}
    if((new Date(fromdate)).getYear() < (new Date()).getYear() - 5 || (new Date(todate)).getYear() < (new Date()).getYear() - 5){
        alert("Yesr must be entered between the range of "+ ((new Date()).getYear() - 5) +" and "+ (new Date()).getYear());
        return false;
        
    }
    if(document.getElementById(top).value=="")
    {
        alert("Top should not be blank!");
        return false;
    }

//    if (stracct=="Y"){
//		if(document.getElementById(Acctlist).selectedIndex == -1){
//			  alert("Please select a account");
//			  return false;
//		}
//	    else{ 
//	        return true;
//	    }
//	} 
}
function CheckDate(strDate)
{
	if(strDate=="") return false;
	
	//------------------------------------------------------------------------
	// * Check whether the year is a leap Year or not
	//------------------------------------------------------------------------

	var m_YYYY = /(1[89]\d{2}|2\d{3})/;
	RegExp.$1="";
	m_YYYY.exec(strDate);
	var m_Year = RegExp.$1;
	if(m_Year=="") m_Year = (new Date()).getYear();
	var bln_LeapYear = false;
	if((m_Year%4==0 && m_Year%100!=0)||(m_Year%400==0)) bln_LeapYear = true;
	//------------------------------------------------------------------------
	
	var YYYY = "(1[89]\\d{2}|2\\d{3})";
	var MMDD_1 = "(0\?[13578]|1[02])[\-\/](0\?[1-9]|[12]\\d|3[01])";
	var MMDD_2 = "(0\?[469]|11)[\-\/](0\?[1-9]|[12]\\d|30)";
	var MMDD_3;
	if(bln_LeapYear)
		MMDD_3 = "0\?2[\-\/](0\?[1-9]|[12]\\d)";
	else
		MMDD_3 = "0\?2[\-\/](0\?[1-9]|1\\d|2[0-8])";
	var MMDD_All = "((" + MMDD_1 + ")|(" + MMDD_2 + ")|(" + MMDD_3 + "))";
	var DateFormat_1 = "(" + YYYY + "[\-\/]" + MMDD_All + ")";
	var DateFormat_2 = "(" + MMDD_All + "[\-\/]" + YYYY + ")";
	var DateFormat_3 = "(" + MMDD_All + ")";
	var DateFormat_All ="^(" + DateFormat_1 + "|" + DateFormat_2 + "|" + DateFormat_3 + ")$";
	var m_ChkDate = new RegExp(DateFormat_All);
	return(m_ChkDate.test(strDate));
}
</script>

<form id="Form1" method="post" runat="server">
    <table  width="100%">
      <tr>
		        <td class="css_header" colspan="6">Top Drivers Report
		        </td>
	        </tr>
	    <tr align="left">
		    <td class="css_desc" style="width:15%">Sort By:</td>
		    <td class="css_desc" style="width:15%">Top:</td>
		    <td class="css_desc" style="width:15%">From Date</td>
		    <td class="css_desc" style="width:15%">To Date</td>
		    <td class="css_desc" style="width:25%">Date Type</td>
		    <td class="css_desc" style="width:15%"></td>
	    </tr>
	    <tr align="left">
		    <td class="font3" style="width:15%">
		        <asp:dropdownlist id="lst_SortBy" Runat="server">
				    <asp:ListItem Value="1" Selected="True">Amount</asp:ListItem>
				    <asp:ListItem Value="2">Number of Rides</asp:ListItem>
			    </asp:dropdownlist>
			</td>
		    <td style="width:15%" class="font3"><asp:textbox id="txtTop" runat="server" Width="120"></asp:textbox></td>
		    <td class="font3" style="width:15%"><asp:textbox id="txtFromDate" runat="server" Width="120"></asp:textbox></td>
		    <td class="font3" style="width:15%"><asp:textbox id="txtToDate" runat="server" Width="120"></asp:textbox></td>
		    <td class="font3" style="width:25%"> 
		        <asp:RadioButton ID="radTip" runat ="server" GroupName ="radDate" Text="Trip Date" Checked ="true"/>
		        <asp:RadioButton ID="radInvoice" runat ="server" GroupName ="radDate" Text="Invoice Date"/>
		    </td>
		    <td class="font3" style="width:15%"><asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/Images/Submit.gif" /></td>
	    </tr>
	    <tr id="trdata" runat="server"  visible="false">
	           <td align="left" colspan="6">
	             <table style="width:100%">
	                <tr ><td align="left" class="css_desc2" ><asp:label id="lbl_TabCap" Runat="Server" ></asp:label></td></tr>
                    <tr>
                        <td  align="left">
                            <asp:datagrid id="DataGridVoucherList" runat="server" AllowSorting="True" BackColor="Gainsboro" AutoGenerateColumns="False" PageSize="20" AllowPaging="true">
					            <SelectedItemStyle Wrap="False"></SelectedItemStyle>
					            <EditItemStyle Wrap="False"></EditItemStyle>
					            <AlternatingItemStyle CssClass="css_alterdesc" Wrap="False"></AlternatingItemStyle>
					            <ItemStyle CssClass="css_itemdesc" Wrap="False"></ItemStyle>
					            <HeaderStyle CssClass="css_title" Wrap="False"></HeaderStyle>
					            <FooterStyle CssClass="css_footdesc" Wrap="False"></FooterStyle>
					            <Columns>
						            <asp:TemplateColumn SortExpression="car_no" HeaderText="CAR NO.">
							            <ItemStyle ></ItemStyle>
							            <ItemTemplate>
								            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor ="Blue" Text='<%# DataBinder.Eval(Container, "DataItem.car_no") %>' >
								            </asp:HyperLink>
							            </ItemTemplate>
						            </asp:TemplateColumn>
						            <asp:BoundColumn DataField="totalBase" SortExpression="totalBase" ReadOnly="True" HeaderText="RATE" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False"></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="totalTolls" SortExpression="totalTolls" ReadOnly="True"   HeaderText="TOLLS" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False"></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="totalParking" SortExpression="totalParking" ReadOnly="True" HeaderText="PARKING" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False" ></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="totalWait" SortExpression="totalWait" ReadOnly="True" HeaderText="WAIT" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False" ></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="totalStop" SortExpression="totalStop" ReadOnly="True" HeaderText="STOPS" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False" ></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="totalSW" SortExpression="totalSW" ReadOnly="True" HeaderText="STOPS/W.T." DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False" ></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="totalPackage" SortExpression="totalPackage" ReadOnly="True" HeaderText="PACKAGE" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False"></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="totalMisc" SortExpression="totalMisc" ReadOnly="True" HeaderText="MISC" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False" ></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="totalPhone" SortExpression="totalPhone" ReadOnly="True" HeaderText="PHONE" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False"></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="totalTips" SortExpression="totalTips" ReadOnly="True" HeaderText="TIPS" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False" ></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="totalService" SortExpression="totalService" ReadOnly="True" HeaderText="SERVICE" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False"></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="totalGross" SortExpression="totalGross" ReadOnly="True" HeaderText="GROSS" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False" ></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="totalDiscount" SortExpression="totalDiscount" ReadOnly="True" HeaderText="DISCOUNT" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False" ></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="totalNet" SortExpression="totalNet" ReadOnly="True" HeaderText="NET" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False" ></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="totalCount" SortExpression="totalCount" ReadOnly="True" HeaderText="NO. OF RIDES" >
							            <ItemStyle Wrap="False" ></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
						            <asp:BoundColumn DataField="avgNet" SortExpression="avgNet" ReadOnly="True" HeaderText="AVG. COST" DataFormatString="{0:#,###,##0.00}">
							            <ItemStyle Wrap="False" ></ItemStyle>
							            <HeaderStyle Wrap="false" />
						            </asp:BoundColumn>
					            </Columns>
					            <PagerStyle CssClass="css_pagedesc" Mode="NumericPages"></PagerStyle>
				            </asp:datagrid>
                        </td>
                       
                    </tr>
                    <tr class="noshown" id="trpage" runat="server" visible="false">
			            <td align="left" class="css_font" >Page&nbsp;
					            <asp:label id="lblPageIndex" runat="server" Font-Names="Arial"></asp:label>&nbsp;of&nbsp;
					            <asp:label id="lblPageAmount" runat="server" Font-Names="Arial"></asp:label>
					            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                            <asp:ImageButton ID="btnExport" runat="server" ImageUrl="~/Images/ExportToExcelFormat.gif" />
			            </td>
            <%--			<td align="left" class="css_font">ALL VEHICLES ARE INDEPENDENTLY OWNED AND OPERATED</td>
            --%>		
                    </tr> 
                   </table>
	         </td>
	    </tr>
                
                
                
   
		<tr align="center">
		    <td  class="css_font"  colspan="6"><a href ="rptmenu.aspx">Back to Report Page</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href ="default.aspx">Back To Main Menu </a><asp:HiddenField ID="hdnSort" runat="server" /><br /><br /></td>
		</tr>
    </table>
</form>
</asp:Content>

