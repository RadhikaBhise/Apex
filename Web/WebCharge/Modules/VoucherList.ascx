<%@ Control Language="VB" AutoEventWireup="false" CodeFile="VoucherList.ascx.vb" Inherits="Modules_VoucherList" %>

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

<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:DataGrid ID="grdData" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" PageSize="20" Width="100%" ShowFooter="True">
                <SelectedItemStyle Wrap="False" />
                <EditItemStyle Wrap="False" />
                <AlternatingItemStyle CssClass="css_alterdesc" wrap="False"/>
                <ItemStyle CssClass="css_itemdesc" wrap="False"/>
                <HeaderStyle CssClass="css_title" Wrap="False" />
                <FooterStyle CssClass="css_alterdesc" wrap="False"/>
                <Columns>
                    <asp:TemplateColumn   HeaderText="#">   
                      <ItemTemplate>   
                          <asp:Label id="Label1" runat="server" Text='<%# Convert.ToInt32(DataBinder.Eval(Container,"DataSetIndex"))+1%>'>   
                          </asp:Label>   
                       </ItemTemplate>  
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="Invoice_No" HeaderText="INVOICE#" ReadOnly="True" SortExpression="Invoice_No">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="VOUCHER" SortExpression="Voucher_No">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" NavigateUrl='<%# "javascript:ShowVoucherImage(""" & DataBinder.Eval(Container.DataItem,"voucher_no").ToString().Trim() & """,""" & DataBinder.Eval(Container.DataItem, "confirmation_no").ToString.Trim & """)" %>'
                                Text='<%# DataBinder.Eval(Container, "DataItem.Voucher_No") %>'>
		                            </asp:HyperLink>
                        </ItemTemplate>
                        
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="Pu_Date_Time" DataFormatString="{0:MM/dd/yyyy}" HeaderText="PU DATE"
                        ReadOnly="True" SortExpression="Pu_Date_Time">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Car_No" HeaderText="CAR" ReadOnly="True" SortExpression="Car_No">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Passenger" HeaderText="PASSENGER" ReadOnly="True" SortExpression="Passenger">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Pu_Address" HeaderText="PICKUP" ReadOnly="True" SortExpression="Pu_Address">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Dest_Address" HeaderText="DESTINATION" ReadOnly="True"
                        SortExpression="Dest_Address">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Pu_Date_Time" DataFormatString="{0:HH:mm}" HeaderText="TIME"  ReadOnly="True" SortExpression="Pu_Date_Time">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="base_rate" DataFormatString="{0:#,###,##0.00}" HeaderText="RATE"  ReadOnly="True" SortExpression="base_rate">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="tolls" DataFormatString="{0:#,###,##0.00}" HeaderText="TOLLS" ReadOnly="True" SortExpression="tolls">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="parking" DataFormatString="{0:#,###,##0.00}" HeaderText="PARK"  ReadOnly="True" SortExpression="parking">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="wait_amount" DataFormatString="{0:#,###,##0.00}" HeaderText="W.T."  ReadOnly="True" SortExpression="wait_amount">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="stops_amt" DataFormatString="{0:#,###,##0.00}" HeaderText="STOPS" ReadOnly="True" SortExpression="stops_amt">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="stop_wt_amount" DataFormatString="{0:#,###,##0.00}" HeaderText="STP/W.T."  ReadOnly="True" SortExpression="stop_wt_amount">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="package_amt" DataFormatString="{0:#,###,##0.00}" HeaderText="PACK"   ReadOnly="True" SortExpression="package_amt">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="phone_amt" DataFormatString="{0:#,###,##0.00}" HeaderText="PHONE" ReadOnly="True" SortExpression="phone_amt">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="tips" DataFormatString="{0:#,###,##0.00}" HeaderText="ADJ" ReadOnly="True" SortExpression="tips">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="service_fee" DataFormatString="{0:#,###,##0.00}" HeaderText="SVR"  ReadOnly="True" SortExpression="service_fee">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Gross" DataFormatString="{0:#,###,##0.00}" HeaderText="GROSS"   ReadOnly="True" SortExpression="Gross">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Surcharge" DataFormatString="{0:#,###,##0.00}" HeaderText="NYS SURCHARGE" ReadOnly="True" SortExpression="Surcharge">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Discount" DataFormatString="{0:#,###,##0.00}" HeaderText="DISC" ReadOnly="True" SortExpression="Discount">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Net" DataFormatString="{0:#,###,##0.00}" HeaderText="NET" ReadOnly="True" SortExpression="Net">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                   <%-- <asp:BoundColumn DataField="cc_settle_comment" DataFormatString="{0: MMM d yyyy }"  HeaderText="CC DATE" ReadOnly="True" SortExpression="cc_settle_comment">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>--%>
                     <asp:TemplateColumn HeaderText="CC DATE" SortExpression="cc_settle_comment">
                        <ItemTemplate>
                            <asp:Label ID="lblCCDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cc_settle_comment") %>'></asp:Label>
                        </ItemTemplate>
                          <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="CC SETTLEMENT DATE" SortExpression="export_cc_date_time">
                        <ItemTemplate>
                            <asp:Label ID="lblCCSettlementDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.export_cc_date_time", "{0: MMM d yyyy hh:mm tt}") %>'></asp:Label>
                        </ItemTemplate>
                          <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="comp_id_1" ReadOnly="True" SortExpression="comp_id_1" Visible="False">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="comp_id_2" ReadOnly="True" SortExpression="comp_id_2" Visible="False">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="comp_id_3" ReadOnly="True" SortExpression="comp_id_3" Visible="False">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="comp_id_4" ReadOnly="True" SortExpression="comp_id_4" Visible="False">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="comp_id_5" ReadOnly="True" SortExpression="comp_id_5" Visible="False">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="comp_id_6" ReadOnly="True" SortExpression="comp_id_6" Visible="False">
                        <ItemStyle Wrap="False" />
                         <HeaderStyle Wrap="False" />
                    </asp:BoundColumn>
                    
                </Columns>
                
                <PagerStyle CssClass="css_pagedesc" Mode="NumericPages" />
            </asp:DataGrid></td>
    </tr>
    <tr>
        <td>
            <br />
            Page:&nbsp;
            <asp:Label ID="lblPageIndex" runat="server" Font-Names="Arial"></asp:Label>
            of&nbsp;
            <asp:Label ID="lblPageCount" runat="server" Font-Names="Arial"></asp:Label>
            &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:ImageButton ID="btnExport" runat="server" ImageUrl="~/Images/ExportToExcelFormat.gif" />
            <asp:HiddenField ID="hdnSort" runat="server" />
            <br />
        </td>
    </tr>
</table>