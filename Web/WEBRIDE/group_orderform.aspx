<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/group_MasterPageMenu.master" AutoEventWireup="false" CodeFile="group_orderform.aspx.vb" Inherits="group_orderform" title="Untitled Page" %>
<%@ Register Src="Modules/orderentry.ascx" TagName="orderentry" TagPrefix="uc3" %>

<%@ Register Src="Modules/calendar.ascx" TagName="calendar" TagPrefix="uc2" %>

<%@ Register Src="Modules/stop.ascx" TagName="stop" TagPrefix="uc1" %>

<asp:Content ID="Content" ContentPlaceHolderID="content" runat="server">
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
                <td colspan="2">
                    <uc3:orderentry ID="Orderentry1" runat="server" SetUserType="GroupUser" />
                </td>
            </tr>
            <tr>
                <td height="15px" colspan="2">
                </td>
            </tr>            
            <tr>
                <td colspan="2">
                    <uc1:stop ID="Stop1" runat="server" AddressType="Pickup" />
                </td>
            </tr>
            <tr>
                <td height="15px" colspan="2">
                </td>
            </tr>              
            <tr>
                <td colspan="2">
                    <uc1:stop ID="Stop2" runat="server" AddressType="Destination" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="hdnUserID" runat="server" />
                </td>
            </tr>             
        </table>
        <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="images/Submit Order.gif" />&nbsp;
        <img alt="" onclick="javascript:document.forms[0].reset();" src="images/reset.gif" style="cursor: hand" />
        <asp:HiddenField ID="hdnConfNo" runat="server" /> 
                                   
    </form>
</asp:Content>




