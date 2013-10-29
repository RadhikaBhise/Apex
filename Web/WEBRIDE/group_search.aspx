<%@ Page EnableEventValidation="false" Language="VB" MasterPageFile="~/group_MasterPageMenu.master" AutoEventWireup="false" CodeFile="group_search.aspx.vb" Inherits="group_search" title="Untitled Page" %>

<%@ Register Src="Modules/group_ridesearch.ascx" TagName="group_ridesearch" TagPrefix="uc1" %>
<%@ Register Src="Modules/group_ridehistory.ascx" TagName="group_ridehistory" TagPrefix="uc2" %>
<%@ Register Src="Modules/footer.ascx" TagName="footer" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
<form id="form1" runat="server">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td align="left">
      <table border="0" cellpadding="0" cellspacing="0" id="table1" width="620"  >    
        <tr>
            <td class="css_header">Search</td>
        </tr>       
        <tr>
            <td align="left" colspan="2">
                <uc1:group_ridesearch ID="Group_ridesearch1" runat="server" />                
            </td>
        </tr>      
        <tr>
            <td align="left" colspan="2">
                <uc2:group_ridehistory id="Group_ridehistory1" runat="server">
                </uc2:group_ridehistory></td>
        </tr>
       <tr>         
            <td   align="left"  colspan="2">
             <uc3:footer ID="Footer1" runat="server" />              
            </td>
            </tr>
    </table>    
</td>
</tr>
</table>
</form>
</asp:Content>

