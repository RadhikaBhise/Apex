<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RptOfCustom.aspx.vb" Inherits="RptOfCustom" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<%--<script language="javascript" type="text/javascript">
function batchvalidate(stracct)
{
    var fromdate=document.all['ctl00_MainContent_txt_FromTrip'].value;
    var todate=document.all['ctl00_MainContent_txt_ToTrip'].value;
    if (!ValidateDateForm(fromdate,todate)) return false;
    if (stracct=="Y"){
			  if(document.getElementById("ctl00_MainContent_listAcct").selectedIndex == -1){
			  alert("Please select a account");
			  return false;}
			 else{ return true;}

			} 
    if (document.all['ctl00_MainContent_txt_Top'].value==""){
	    alert('Please Enter top!');
	    document.all['ctl00_MainContent_txt_Top'].focus();
	    return false;
	}
	if (isNaN(document.all['ctl00_MainContent_txt_Top'].value)){
	    alert('Please Enter only numeric values in top');
	    document.all['ctl00_MainContent_txt_Top'].focus();
	    return false;
	}
}
</script>--%>
<form id="Form1" method="post" runat="server">
<table cellspacing="0" cellpadding="0" width="100%"  border="0">
<tr><td align="center"  class="css_header">Top Customer Report</td></tr>
<tr><td align="center" >
		
					<%--<table cellspacing="2" cellpadding="2"  border="0">
					    <tr align ="center" style=" background :darkblue" id="trSelAcct" runat ="server">
					        <td colspan="2"><big><b><font face="Arial" color="#ffffff" size="3">Select Account:</font></b></big></td>
					    </tr>
					    <tr align="center"  id="trSelList" runat ="server">
					        <td colspan="2"><asp:ListBox ID="listAcct" runat ="server" SelectionMode="Multiple" Width ="130" Height ="160" AutoPostBack="True"></asp:ListBox></td>
					    </tr>
					    <tr id="trCusRef" runat="server">
	                        <td style="FONT-SIZE: medium; COLOR: #ffffff; FONT-FAMILY: Arial; BACKGROUND-COLOR: darkblue; font-weight:bold" align="center" colspan="2">Select Customer Reference</td>
                        </tr>
                        <tr id="trCusList" runat ="server">
	                        <td style="HEIGHT: 12px; BACKGROUND-COLOR: lightgrey" align="center" colspan="2"><asp:dropdownlist id="lst_CmpReq" runat="server" DataTextField="req_desc" DataValueField="req_id"
			                        Width="128px"></asp:dropdownlist></td>
                        </tr>
						<tr align="center" style=" background :darkblue">
							<td><big><b><font face="Arial" color="#ffffff" size="3">Sort By:</font></b></big></td>
							<td><big><b><font face="Arial" color="#ffffff" size="3">Top:</font></b></big></td>
						</tr>
						<tr align="center" >
							<td><asp:dropdownlist id="lst_SortBy" Runat="server"  Width="100">
									<asp:ListItem Value="1" Selected="True">Amount</asp:ListItem>
									<asp:ListItem Value="2">Number of Rides</asp:ListItem>
								</asp:dropdownlist></td>
							<td><asp:textbox id="txt_Top" runat="server" size="3" maxLength="3"></asp:textbox></td>
						</tr>
						<tr align="center" style=" background :darkblue">
							<td><big><b><font face="Arial" color="#ffffff" size="3">From Date</font></b></big></td>
							<td><big><b><font face="Arial" color="#ffffff" size="3">To Date</font></b></big></td>
						</tr>
						<tr align="center">
							<td style="HEIGHT: 15px"><asp:textbox id="txt_FromTrip" runat="server" size="10" maxLength="10"></asp:textbox></td>
							<td style="HEIGHT: 15px"><asp:textbox id="txt_ToTrip" runat="server" size="10" maxLength="10"></asp:textbox></td>
						</tr>
						<tr align="center" >
							<td >
							                <asp:RadioButton ID="radTip" runat ="server" GroupName ="radDate" Text="Trip Date" Checked ="true"/>
			                </td>
			                <td>
							                
							                <asp:RadioButton ID="radInvoice" runat ="server" GroupName ="radDate" Text="Invoice Date"/>
							</td>
						</tr>
					</table>--%>
            <table  >
                    <tr align="left">
	                    <td class="css_desc" style="width:15%">Sort By:</td>
	                    <td class="css_desc" style="width:5%">Top:</td>
	                    <td class="css_desc" id="trCusRef"  runat="server" style="width:25%">Select Customer Reference:</td>
	                    <td class="css_desc" style="width:15%">From Date:</td>
	                    <td class="css_desc" style="width:15%">To Date:</td>
	                    <td class="css_desc" style="width:25%">Date Type:</td>
	                    <td class="css_desc" style="width:15%"></td>
                    </tr>
                    <tr align="left">
	                    <td class="font3" style="width:15%">
	                        <asp:dropdownlist id="lst_SortBy" Runat="server">
			                    <asp:ListItem Value="1" Selected="True">Amount</asp:ListItem>
			                    <asp:ListItem Value="2">Number of Rides</asp:ListItem>
		                    </asp:dropdownlist>
		                </td>
	                    <td style="width:5%" class="font3"><asp:textbox id="txtTop" runat="server" Width="50px"></asp:textbox></td>
	                     <td class="font3" id="trCusList"  runat="server"  >
	                        <asp:dropdownlist id="lst_CmpReq" Runat="server" style=" Width:180px"  DataTextField="req_desc" DataValueField="req_id">
		                    </asp:dropdownlist>
		                </td>
	                    <td class="font3" ><asp:textbox id="txtFromDate" runat="server" Width="85px"></asp:textbox></td>
	                   
	                    <td class="font3" ><asp:textbox id="txtToDate" runat="server" Width="85px"></asp:textbox></td>
	                    <td class="font3" > 
	                        <asp:RadioButton ID="radTrip" runat ="server" GroupName ="radDate" Text="Trip Date" Checked ="true"/>
	                        <asp:RadioButton ID="radInvoice" runat ="server" GroupName ="radDate" Text="Invoice Date"/>
	                    </td>
	                    <td class="font3" style="width:15%"><asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/Images/Submit.gif" /> </td>
                    </tr>
            </table>				
		</td>
	  </tr>
	   <tr>
                <td colspan="6"></td>
            </tr>
      <tr  id="trdata" runat="server" visible="false">
            <td>
               <table width="100%" >
                    <tr ><td align="left" class="css_desc2" ><asp:label id="lbl_TabCap" Runat="Server" ></asp:label></td></tr>
                    <tr>
		                <td  align="left"  >
		                   <asp:DataGrid  id="DataGrid_InvoiceList"   PageSize="20" runat="server" AutoGenerateColumns="False" AllowPaging="True" Width="100%" AllowSorting="True">
				                    <SelectedItemStyle Wrap="False"></SelectedItemStyle>
				                    <EditItemStyle Wrap="False"></EditItemStyle>
				                    <AlternatingItemStyle CssClass="css_alterdesc"></AlternatingItemStyle>
				                    <ItemStyle CssClass="css_itemdesc"></ItemStyle>
				                    <HeaderStyle CssClass="css_title"></HeaderStyle>
				                    <FooterStyle CssClass="css_footdesc"></FooterStyle>
				                <Columns>
                					
					                <asp:TemplateColumn HeaderText="">
						                <ItemStyle></ItemStyle>
						                <ItemTemplate>
							                <asp:HyperLink ID="HyperLink1" runat="server">
							                </asp:HyperLink>
						                </ItemTemplate>
					                </asp:TemplateColumn>
					                <asp:BoundColumn DataField="totalBase" SortExpression="totalBase" ReadOnly="True" HeaderText="Rate" DataFormatString="{0:#,###,##0.00}">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
					                <asp:BoundColumn DataField="totalTolls" SortExpression="totalTolls" ReadOnly="True" HeaderText="Tolls" DataFormatString="{0:#,###,##0.00}">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
					                <asp:BoundColumn DataField="totalParking" SortExpression="totalParking" ReadOnly="True" HeaderText="Parking" DataFormatString="{0:#,###,##0.00}">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
					                <asp:BoundColumn DataField="totalWait" SortExpression="totalWait" ReadOnly="True" HeaderText="Wait" DataFormatString="{0:#,###,##0.00}">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
					                <asp:BoundColumn DataField="totalStop" SortExpression="totalStop" ReadOnly="True" HeaderText="Stops" DataFormatString="{0:#,###,##0.00}">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
					                <asp:BoundColumn DataField="totalSW" SortExpression="totalSW" ReadOnly="True" HeaderText="Stops/W.T." DataFormatString="{0:#,###,##0.00}">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
						                <asp:BoundColumn DataField="totalPackage" SortExpression="totalPackage" ReadOnly="True" HeaderText="Package" DataFormatString="{0:#,###,##0.00}">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
					                <asp:BoundColumn DataField="totalMisc" SortExpression="totalMisc" ReadOnly="True" HeaderText="Misc" DataFormatString="{0:#,###,##0.00}">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
					                <asp:BoundColumn DataField="totalPhone" SortExpression="totalPhone" ReadOnly="True" HeaderText="Phone" DataFormatString="{0:#,###,##0.00}">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
					                <asp:BoundColumn DataField="totalTips" SortExpression="totalTips" ReadOnly="True" HeaderText="Tips" DataFormatString="{0:#,###,##0.00}">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
					                <asp:BoundColumn DataField="totalService" SortExpression="totalService" ReadOnly="True" HeaderText="Service" DataFormatString="{0:#,###,##0.00}">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
					                <asp:BoundColumn DataField="totalGross" SortExpression="totalGross" ReadOnly="True" HeaderText="Gross" DataFormatString="{0:#,###,##0.00}">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
					                <asp:BoundColumn DataField="totalDiscount" SortExpression="totalDiscount" ReadOnly="True" HeaderText="Discount" DataFormatString="{0:#,###,##0.00}">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
					                <asp:BoundColumn DataField="totalNet" SortExpression="totalNet" ReadOnly="True" HeaderText="Net" DataFormatString="{0:#,###,##0.00}">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
					                <asp:BoundColumn DataField="totalCount" SortExpression="totalCount" ReadOnly="True" HeaderText="No.Of Rides">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
					                <asp:BoundColumn DataField="avgNet" SortExpression="avgNet" ReadOnly="True" HeaderText="Avg.Cost" DataFormatString="{0:#,###,##0.00}">
						                <ItemStyle Wrap="False"></ItemStyle>
						                <HeaderStyle Wrap="false" />
					                </asp:BoundColumn>
                					
				                </Columns>
				                    <PagerStyle CssClass="css_pagedesc"  Mode="NumericPages"></PagerStyle>
			                </asp:DataGrid>
		                </td>
	                </tr>
	                <tr >	
	                        <td  align="left" class="css_font"  >Page&nbsp;<asp:label id="lbl_PageIndex" runat="server" Font-Names="Arial"></asp:label>&nbsp;of&nbsp;
				                <asp:label id="lbl_PageAmount" runat="server" Font-Names="Arial"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                				
				                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="btnExport" runat="server" ImageUrl="~/Images/ExportToExcelFormat.gif" /><br/>
			                </td>
	                </tr>
                </table>
            </td>
      </tr>

	  
		
   <tr>
	            <td align="center">
	                <br />
	                <a href ="rptmenu.aspx">Back To Report Page</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	                <a href ="default.aspx">Back To Main Menu</a><br />
                    <asp:HiddenField ID="hdnSort" runat="server" />
                    <br />
	            </td>
	        </tr></table>
</form>
</asp:Content>

