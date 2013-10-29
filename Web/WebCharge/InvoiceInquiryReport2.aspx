<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="InvoiceInquiryReport2.aspx.vb" Inherits="InvoiceInquiryReport2" title="Untitled Page" %>

<%@ Register Src="Modules/VoucherList.ascx" TagName="VoucherList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script  type="text/javascript" language ="javascript" src="JS/Report.js"></script>
    <form id="Form1" method="post" runat="server">
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <tr>
                <td colspan="5"  style="height:10px"></td>
                </tr>
           
            <tr>
                <td align ="left" class="css_desc2">
                    Invoice Date: <asp:Label ID="lblInvoiceDate" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Invoice #: <asp:Label ID="lblInvoiceNo" runat ="server" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
            <tr id="trData" runat="server" align="left">
                 <td>
                     <uc1:VoucherList ID="VoucherList1" runat="server" />
		        </td>
	        </tr>
	        <tr class="noshown" id="trpage" runat="server">
		        <td align="center">
		            <a href="invoiceinquiry.aspx">Back To Invoice Inquiry</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		            <a href ="default.aspx">Back To Main Menu</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /><br />
		            <asp:HiddenField ID="hdnInvoiceNo" runat="server" />
		            <asp:HiddenField ID="hdnInvoiceDate" runat="server" />
		            <br /><br />
		        </td>
	        </tr>
        </table>
    </form>
</asp:Content>

