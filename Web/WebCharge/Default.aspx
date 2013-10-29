<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <form id="bodyform" runat="server">
        <table cellspacing="0" cellpadding="0" width="100%" border="0" class="rptmenu_font">
            <tr>
                <td height="15"></td>
            </tr>
            <tr>
	            <td align="center">
		            <table cellspacing="1" cellpadding="1" border="0">
		              <tr>
				            <td  style=" width:200px">
					            <table cellspacing="0" cellpadding="0" border="0">
						            <tr id="trInvoice" runat="server">
							            <td align="left">
								            <p>
								                <img alt="" src="images/printer.jpg"  />&nbsp;
								                <b>
									            <asp:linkbutton id="lbtnVou" runat="server">Invoice Inquiry</asp:linkbutton></b>
									        </p>
							            </td>
						            </tr>
						            <tr id="trCon" runat="server">
							            <td align="left">
								            <p>
								                <img alt=""  src="images/printer.jpg"  />&nbsp;
								                <b>
									            <asp:linkbutton id="lbtnCI" runat="server">Voucher Inquiry</asp:linkbutton></b>
									        </p>
							            </td>
						            </tr>
						            <tr id="trMaintenance" runat="server">
							            <td align="left">
								            <p>
								                <img alt=""   src="images/maint.gif"  />&nbsp;
									             <b><asp:linkbutton id="lnkbtn_Maintain" runat="server">Maintenance</asp:linkbutton></b>
									        </p>
							            </td>
						            </tr>	
					            </table>
				            </td>
				            <td>
					            <table cellspacing="0" cellpadding="0" border="0">
					                <tr id="trqueandsta" runat="server">
							            <td align="left">
								            <p><img alt=""  src="images/1btn271.gif"   /> 
										            Query &amp; Statistics</p>
							            </td>
						            </tr>
						            <tr>
							            <td  style="height:4px"></td>
						            </tr>
						            <tr id="trcustom" runat="server">
							            <td align="left" style="height:28px">
								            <p ><img alt="" src="images/clear.gif" width="10" />
								                <img alt="" src="images/3arrow.gif" />
									            <img alt="" src="images/clear.gif"  width="10"/>
									            <b><asp:linkbutton id="lbtnCustomer" runat="server">By Customer Reference</asp:linkbutton></b></p>
							            </td>
						            </tr>
						            <tr id="trvip" runat="server">
							            <td align="left" style="height:28px">
								            <p ><img alt="" src="images/clear.gif"  width="10"/>
								                <img alt="" src="images/3arrow.gif" />
									            <img alt="" src="images/clear.gif"  width="10"/>
									            <b><asp:linkbutton id="lbtnVIP" runat="server">By VIP</asp:linkbutton></b>
									        </p>
							            </td>
						            </tr>
						            <tr id="trReport" runat="server"  visible="false">
							            <td align="left">
								            <p >
								                <img alt="" src="images/report.gif"  />&nbsp;
									            <b><asp:HyperLink id="lnk_Reports" NavigateUrl="~/rptmenu.aspx" runat="server">Reports</asp:HyperLink></b>
									        </p>
							            </td>
						            </tr>
					            </table>
				            </td>
		              </tr>
		            </table>
	            </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <tr>
                <td  style="height:55px" align="center"><asp:linkbutton id="lbtnLogoff" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="Medium" Font-Names="Arial">Log Off</asp:linkbutton>
            </td>
        </tr>
        </table>
        
    </form>
</asp:Content>

