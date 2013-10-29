<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" enableEventValidation="false" AutoEventWireup="false" CodeFile="price.aspx.vb" Inherits="rate_lookup" title="Untitled Page" %>

<%@ Register Src="Modules/stop.ascx" TagName="stop" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">

    <table id="table1" width="100%">
        <tr>
            <td class="css_header" colspan="2">Quick Quote</td>
        </tr>
        <tr>
            <td style="width:60%">
                <uc1:stop ID="Stop1" runat="server" AddressType="QuickQuotePickup" />
            </td>
            <td rowspan="2" valign="top">
                <table width="100%">
                    <tr>
                        <td><asp:Button ID="btnSubmit" runat="server" Text="Click Here to Get Quote" /></td>
                    </tr>
                    <tr id="trRateResult" runat="server">
                        <td style="background-color:#ffffff" class="css_title">
                            Rate Results:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblRate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trFailed" runat="server">
                        <td>
                             <a style="color: dimgray">The trip you are tying to book or obtain a quote for could not be given a valid rate. This can be caused by a number of reasons. Please make sure you entered both City and State information in the proper field.<br /><br />
                            Please try selecting the City and State from the drop down selection box. If you are still having problems please call APEX directly at 718.522.1313. One of our reservationists will be able to assist you.<br /><br />
                            We apologize for any inconvenience.</a>
                       </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width:60%">
                <uc1:stop ID="Stop2" runat="server" AddressType="QuickQuoteDestination" />
            </td>
        </tr>
    </table>
<%--<script type="text/javascript" src="JS/price.js"></script>--%>
<!--
<table style="width: 100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width:25%"><table border="0" cellpadding="1" cellspacing="1" style="width: 30%">
            <tr><td align="center" class="title">Quick Quote</td></tr>
            <tr><td></td></tr>
            <tr><td align="left" class="title">From:</td></tr>
            <tr><td align="center">
                <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                <asp:DropDownList ID="ddlpucity" runat="server" Width="152px" Visible="False">
                </asp:DropDownList></td></tr>                          
            <tr><td align="center" class="main_text">City, State or <a href="javascript:searchairport('p');">Airport</a></td></tr>
            <tr><td>&nbsp;</td></tr>
<tr><td align="left" class="title">To:</td></tr>
<tr><td align="center"><input name="txtTo" id="txtTo" type="text" size="20" maxlength="30" class="field" tabindex="2" runat="server" />
                <asp:DropDownList ID="ddldestcity" runat="server" Width="152px" Visible="False">
                </asp:DropDownList></td></tr>
<tr><td align="center"></td></tr>                
<tr><td align="center" class="main_text">City, State or <a href="javascript:searchairport('d');">Airport</a></td></tr>
<tr><td>&nbsp;</td></tr>
<tr><td>
    <asp:DropDownList ID="ddltype" runat="server" Width="160px">
        <asp:ListItem Value="S">Luxury Sedan</asp:ListItem>
    </asp:DropDownList></td></tr>
<tr><td><div align="center"></div></td></tr>
<tr><td><div align="center">
    <asp:Button ID="imgbtnquote" runat="server" Text="Get Quote" /></div></td></tr>
</table>
  <input name="FormName" id="FormName" type="hidden" style="width: 24px" runat="server" value="N" />
                <input name="hidputype" id="hidputype" type="hidden" style="width: 24px" runat="server" />
                <input name="hiddesttype" id="hiddesttype" type="hidden" style="width: 24px" runat="server" />
                <input name="ToName" id="ToName" type="hidden" style="width: 24px" runat="server" value="N" />
                <input name="hidTime" id="hidTime" type="hidden" style="width: 24px" runat="server" />
                <input name="hidpuAirport" id="hidpuAirport" type="hidden" style="width: 24px" runat="server" />
                <input name="hiddestAirport" id="hiddestAirport" type="hidden" style="width: 24px" runat="server" /></td>            
            <td style="width:75%" valign="top"><table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
            <tr><td align="left" style="height: 17px" class="title">Rate Results</td></tr>
            <tr><td><table id="Table1" border="0" cellpadding="1" cellspacing="1"><tr>
          
            <td style="width: 111px"><font class="main_text"></font>
            </td>
            <td><font class="main_text"></font>
            </td>
        </tr>
        <tr >
         <td align="left" valign="top">
         <table id="trwelcome" runat="server" border="0" cellpadding="1" cellspacing="1" style="width: 592px"><tr><td colspan="2" align="left"><font class="main_text">
              
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
    </font></td></tr>
    </table>
                
        </td></tr>
            <tr valign="top">
            <td><table id="trhavenotResult" runat="server" border="0" cellpadding="1" cellspacing="1" style="width: 592px"><tr><td colspan="2" align="left"><font class="main_text">
                <br />
               The trip you are tying to book or obtain a quote for could not be given a valid rate.  This can be caused by a number of reasons.  Please make sure you entered both City and State information in the proper field separated by a comma (ie:  New York, NY)<br /><br />
Please try selecting the City and State from the drop down selection box.  If you are still having problems please call APEX directly at 718.522.1313.  One of our reservationists will be able to assist you.<br />
<br />             <br />
    </font></td></tr>
    <tr><td colspan="2" align="left"><font class="main_text">We apologize for any inconvenience.<br />
        <br />
        <br />
        <br />
    </font></td></tr></table>
    </td></tr>
     <tr valign="top" align="left"><td>
     <table style="width: 457px;display:none;" id="trgetprice" runat="server" border="0" cellpadding="1" cellspacing="1" class="main_text">
                    <tr>                        
                        <td style="width: 100px" class="orderformtd" align="left"><font class="GridFont">From:</font>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblfrom" runat="server" Width="328px"></asp:Label></td>
                    </tr>
                    <tr>                        
                        <td style="width: 100px" class="orderformtd" align="left"><font class="GridFont">To:</font>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblto" runat="server" Width="328px"></asp:Label></td>
                    </tr>
                        <tr>                        
                        <td style="width: 100px" class="orderformtd" align="left"><font class="GridFont">Car Type:</font>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblcartype" runat="server" Width="328px"></asp:Label></td>
                    </tr>
                    <tr>                        
                        <td style="width: 100px" class="orderformtd" align="left"><font class="GridFont">Estimated Total:</font>
                        </td>
                        <td align="left">
                            <asp:Label ID="lbltotal" runat="server" Width="328px"></asp:Label></td>
                    </tr>
                    <tr><td colspan="2">
                        <br />
                        <asp:Label id="lblshowtext" runat="server" Height="34px" Width="584px" CssClass="main_text"></asp:Label><br />
                        <br />
                        <br />
                    </td></tr>
             <tr><td align="right" colspan="2"><input src="images/button-Lookupar2.gif" type="image" name="btnlookup" id="btnlookup" runat="server" onmouseout="MM_swapImgRestore();" onmouseover="MM_swapImage('ctl00_ContentMain_btnlookup','','images/button-Lookupar.gif',1);" />&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;<input src="images/button-startr.gif" type="image" name="btnreservation" id="btnreservation" runat="server" onmouseout="MM_swapImgRestore();" onmouseover="MM_swapImage('ctl00_ContentMain_btnreservation','','images/button-startr2.gif',1);" /></td></tr></table>
    </td></tr></table>
            </td>            
        </tr>
    </table>-->
    
</asp:Content>

