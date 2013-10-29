<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RptOfElement.aspx.vb" Inherits="RptOfElement" title="Untitled Page" %>

<%@ Register Src="Modules/VoucherList.ascx" TagName="VoucherList" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <form id="Form1" method="post" runat="server">
        <table  cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td class="css_header">Ride Elements Report
                </td>
            </tr>
            <tr>
                <td>
                    <table cellspacing="2" cellpadding="2" border="0" width="800px">
                        <tr>
                            <td class="css_desc" style="width:15%;" align="left">Ride Element</td>
                            <td class="css_desc" style="width:15%;" align="left">Greater than</td>
                            <td class="css_desc" style="width:15%;" align="left">From Date</td>
                            <td class="css_desc" style="width:15%;" align="left">To Date</td>
                            <td class="css_desc" style="width:25%;" align="left">Date Type</td>
                            <td class="css_desc" style="width:15%;" align="left"></td>
                        </tr>
                        <tr>
                            <td class="font3" style="width:15%;" align="left">
                                <asp:dropdownlist id="lst_rType" runat="server">
                                <asp:ListItem value="0" Selected="True">Phone</asp:ListItem>
                                <asp:ListItem value="1">Waiting Time</asp:ListItem>
                                <asp:ListItem value="2">Base Rate</asp:ListItem>
                                <asp:ListItem value="3">Net</asp:ListItem>
                                <asp:ListItem value="4">Tolls</asp:ListItem>
                                <asp:ListItem value="5">Stops</asp:ListItem>
                                </asp:dropdownlist>
                            </td>
                            <td class="font3" style="width:15%; height: 27px;" align="left">
                                <asp:textbox id="txtAmount" runat="server" Width="100"></asp:textbox>
                            </td>
                            <td class="font3" style="width:15%; height: 27px;" align="left">
                                <asp:textbox id="txtFromDate" runat="server" Width="100"></asp:textbox></td>
                            <td class="font3" style="width:15%; height: 27px;" align="left">
                                <asp:textbox id="txtToDate" runat="server" Width="100"></asp:textbox></td>
                            <td class="font3" style="width:25%; height: 27px;" align="left">
                                <asp:RadioButton ID="radTip" runat ="server" GroupName ="radDate" Text="Trip Date" Checked ="true" />
                                <asp:RadioButton ID="radInvoice" runat ="server" GroupName ="radDate" Text="Invoice Date"/>
                            </td>
                            <td class="font3" style="width:15%; height: 27px;" align="left">
                                <asp:imagebutton  ImageUrl="~/Images/Submit.gif" id="btnSubmit"   runat="server" />
                            </td>
                        </tr>
                        <tr id="trDatagrid" runat="server" visible="false" align="left">
                            <td colspan="6">
                                <uc1:VoucherList ID="VoucherList1" runat="server" />
                            </td>
                        </tr>		       
                    </table>
                </td>
             </tr>
            <tr class="noshown" id="trpage" runat="server">
                <td align="center"><br />
                    <a href="rptmenu.aspx">Back to Report Menu</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a href ="default.aspx">Back To Main Menu</a><br />
                    &nbsp;<br />
                </td>
            </tr>

        </table>
    </form>
    
</asp:Content>

