<%@ Page Language="VB" MasterPageFile="MasterPageMenu.master" AutoEventWireup="false" CodeFile="RideHistory.aspx.vb" Inherits="webride_RideHistory" title="" %>

<%@ Register Src="Modules/footer.ascx" TagName="footer" TagPrefix="uc3" %>

<%@ Register Src="Modules/ridehistory.ascx" TagName="ridehistory" TagPrefix="uc1" %>
<%@ Register Src="Modules/ridesearch.ascx" TagName="ridesearch" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
<form id="form1" runat="server">
<table border="0" cellpadding="0" cellspacing="0" style="background-image:url(images/mainbg.gif); width:100%; height:100%">
    <tr>
        <td align="left">
            <table border="0" cellpadding="0" cellspacing="0" id="table1" width="620">
                <tr>
                    <td class="css_header" colspan="2">Ride History</td>
                </tr>
                <tr>
                    <td align="left">- These are the rides you have taken or cancelled. 
                    </td>
                    <td align="right"><!--<a href="rideinquery.aspx"><img  alt="" src="images/refresh.gif" id="img1"  style="border:0"/></a>--></td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        <uc2:ridesearch ID="Ridesearch1" runat="server"   />
                    </td>
                </tr>
              
                <tr>
                    <td align="left" colspan="2">
                        &nbsp;<uc1:ridehistory ID="Ridehistory1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        <uc3:footer ID="Footer1" runat="server" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>  
</form>
</asp:Content>