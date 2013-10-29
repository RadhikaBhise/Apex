<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RptOfEmp.aspx.vb" Inherits="RptOfPass" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <form id="Form1" method="post" runat="server">
        <script type="text/javascript" language="javascript">
            function SubmitValidation(topid)
            {
                var txtTop = document.getElementById(topid);
                
                if(txtTop.value.length==0)
                {
                    alert("Please enter a top value.");
                    return false;
                }
                
                return true;
            }
        </script>
<table cellspacing="0" cellpadding="0" width="100%" border="0">
	        <tr>
		        <td class="css_header">Top Employee Report
		        </td>
	        </tr>
	        <tr>
		        <td>
		            <table width="100%">
			            <tr class="css_desc">
				            <td align="left" >Sort By:</td>
				            <td align="left">Top:</td>
				            <td align="left">From Date</td>
				            <td align="left">To Date</td>
				            <td align="left">Date Type</td>
				            <td></td>
				            <td style="display:none"></td>
			            </tr>
			            <tr class="font3">
				            <td align="left">
				                <asp:dropdownlist id="ddlSortBy" Runat="server">
						            <asp:ListItem Value="1" Selected="True">Amount</asp:ListItem>
						            <asp:ListItem Value="2">Number of Rides</asp:ListItem>
					            </asp:dropdownlist>
					        </td>
				            <td align="left">
				                <asp:textbox id="txtTopCount" runat="server" maxLength="3" Width="60px"></asp:textbox>
				            </td>
			                <td align="left">
			                    <asp:textbox id="txtFromDate" runat="server" maxLength="10" Width="100px"></asp:textbox>
			                </td>
				            <td align="left">
				                <asp:textbox id="txtToDate" runat="server" maxLength="10" Width="100px"></asp:textbox>
				            </td>
				            <td align="left">
				                <asp:RadioButton ID="radTip" runat ="server" GroupName ="radDate" Text="Trip Date" Checked ="true" />
				                <asp:RadioButton ID="radInvoice" runat ="server" GroupName ="radDate" Text="Invoice Date"/>
				            </td>
				            <td align="left">
				                <asp:imagebutton ImageUrl="~/Images/Submit.gif" id="btn_Submit" Runat="server"></asp:imagebutton>
				            </td>
				            <td align="left" style="display:none">
				                <input type="image" src="Images/Reset.gif" onclick="javscript:document.forms[0].reset();return false;" />
				            </td>
				        </tr>
		            </table>
	            </td>
	        </tr>
	        <tr>
	            <td id="trData" runat="server">
	                <table width="100%">
	                    <tr>
	                        <td class="css_desc2">
	                            <asp:Label ID="lblTitle" runat="server" ></asp:Label>
	                        </td>
	                    </tr>
	                    <tr>
	                        <td>      
                                <asp:DataGrid ID="grdData" runat="server" AllowPaging="True" AllowSorting="True"   AutoGenerateColumns="False" PageSize="20" Width="100%">
                                    <SelectedItemStyle Wrap="False" />
                                    <EditItemStyle Wrap="False" />
                                    <AlternatingItemStyle CssClass="css_alterdesc" Wrap="False"/>
                                    <ItemStyle CssClass="css_itemdesc" Wrap="False"/>
                                    <HeaderStyle CssClass="css_title" Wrap="False"/>
                                    <FooterStyle CssClass="css_footdesc" Wrap="False"/>
                                    <Columns>
                                        <asp:TemplateColumn HeaderText="EMP NO." SortExpression="vip_no">
                                            <ItemStyle />
                                            <ItemTemplate>
                                                <asp:HyperLink ID="lnkVipNo" runat="server" ForeColor="Blue" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.vip_no", "empOfReport2.aspx?VipNo="+DataBinder.Eval(Container.DataItem,"vip_no").ToString()) %>'
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.vip_no") %>'>
							            </asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn DataField="totalBase" DataFormatString="{0:#,###,##0.00}" HeaderText="RATE"
                                            ReadOnly="True" SortExpression="totalBase">
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="totalTolls" DataFormatString="{0:#,###,##0.00}" HeaderText="TOLLS"
                                            ReadOnly="True" SortExpression="totalTolls">
                                             <ItemStyle Wrap="False" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="totalParking" DataFormatString="{0:#,###,##0.00}" HeaderText="PARKING"
                                            ReadOnly="True" SortExpression="totalParking">
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="totalWait"  DataFormatString="{0:#,###,##0.00}" HeaderText="WAIT" ReadOnly="True" SortExpression="totalWait">
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="totalStop" DataFormatString="{0:#,###,##0.00}" HeaderText="STOPS"
                                            ReadOnly="True" SortExpression="totalStop">
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="totalSW" DataFormatString="{0:#,###,##0.00}" HeaderText="STOPS/W.T."
                                            ReadOnly="True" SortExpression="totalSW">
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="totalPackage" DataFormatString="{0:#,###,##0.00}" HeaderText="PACKAGE"
                                            ReadOnly="True" SortExpression="totalPackage">
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="totalMisc" DataFormatString="{0:#,###,##0.00}" HeaderText="MISC"
                                            ReadOnly="True" SortExpression="totalMisc">
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="totalPhone" DataFormatString="{0:#,###,##0.00}" HeaderText="PHONE"
                                            ReadOnly="True" SortExpression="totalPhone">
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="totalTips" DataFormatString="{0:#,###,##0.00}" HeaderText="TIPS"
                                            ReadOnly="True" SortExpression="totalTips">
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="totalService" DataFormatString="{0:#,###,##0.00}" HeaderText="SERVICE"
                                            ReadOnly="True" SortExpression="totalService">
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="totalGross" DataFormatString="{0:#,###,##0.00}" HeaderText="GROSS"
                                            ReadOnly="True" SortExpression="totalGross">
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="totalDiscount" DataFormatString="{0:#,###,##0.00}" HeaderText="DISCOUNT"
                                            ReadOnly="True" SortExpression="totalDiscount">
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="totalNet" DataFormatString="{0:#,###,##0.00}" HeaderText="NET"
                                            ReadOnly="True" SortExpression="totalNet">
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="totalCount" HeaderText="NO. OF RIDES"
                                            ReadOnly="True" SortExpression="totalCount">
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="avgNet" DataFormatString="{0:#,###,##0.00}" HeaderText="AVG. COST"
                                            ReadOnly="True" SortExpression="avgNet">
                                            <ItemStyle Wrap="False" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:BoundColumn>
                                    </Columns>
                                    <PagerStyle CssClass="css_pagedesc" Mode="NumericPages" />
                                </asp:DataGrid>
                            </td>
	                    </tr>
	                    <tr>
	                        <td align="left"><br />
	                           Page&nbsp;
                                <asp:Label ID="lbl_PageIndex" runat="server" Font-Names="Arial"></asp:Label>
                                of&nbsp;
                                <asp:Label ID="lbl_PageAmount" runat="server" Font-Names="Arial"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                <asp:ImageButton ID="btnExport" runat="server" ImageUrl="~/Images/ExportToExcelFormat.gif" /></td>
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
	            </td>
	        </tr>
        </table>
    </form>
</asp:Content>

