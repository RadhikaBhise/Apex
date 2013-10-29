<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="MasterPageQuick.master" AutoEventWireup="false" Debug="true" CodeFile="QuickOrderForm.aspx.vb" Inherits="QuickOrderForm" title="Untitled Page" %>

<%@ Register Src="Modules/stop.ascx" TagName="stop" TagPrefix="uc2" %>

<%@ Register Src="Modules/orderentry.ascx" TagName="orderentry" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
    <script type="text/javascript" language="javascript" src="js/common.js"></script>

    <form id="form1" runat="server">
        <table id="table1" width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="2">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="css_header">On Line Order Form</td>
                            <td style="font-weight:bold; color:Red;width:70%"><asp:Literal ID="ltrBannerMsg" runat="server"></asp:Literal></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width:10%;" colspan="2">
                    <uc1:orderentry ID="Orderentry1" SetUserType="QuickUser" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <uc2:stop ID="Stop1" runat="server" AddressType="Pickup" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <uc2:stop ID="Stop2" runat="server" AddressType="Destination" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
        </table>
        <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="images/Submit Order.gif" />&nbsp;
        <input type="image" src="images/reset.gif" onclick="document.forms[0].reset();return false;" /></form>
</asp:Content >