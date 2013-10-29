<%@ Page Language="VB" MasterPageFile="~/MasterPageQuick.master"  enableEventValidation="false" AutoEventWireup="false" CodeFile="register.aspx.vb" Inherits="register" title="Untitled Page" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td align="left" class="css_header">New Customer</td>
    </tr>
 <%--   <tr>
        <td class="darkgray_11" align="left">
            &nbsp;&nbsp;&nbsp;&nbsp;If you already have an APEX online account then sign-in with your user name and password or contact APEX at 718 522 0427 for further instructions.
            If you would like to receive all the benefits provided to our frequent corporate travelers, please complete our 
            <a href="Profile_add.aspx" style="text-decoration: underline; font-weight:bold;">Expanded Profile</a>.
        </td>
    </tr>
    <tr>
        <td style="height:25px;"></td>
    </tr>--%>
    <tr>
        <td class="blue_14_b" align="left" >
            Individual/Leisure Travelers 
        </td>
    </tr>
    <tr>
        <td class="main_text" align="left" style="height:26px;">
            &nbsp;&nbsp;&nbsp;&nbsp;Not a frequent traveler? Booking a 1 time trip? That's okay. <a style="font-weight:bold;" href="quickorderform.aspx">Press here</a> to book your trip in one easy step.
        </td>
    </tr>
    <tr>
        <td >
            &nbsp;&nbsp;&nbsp;&nbsp;<a href="quickorderform.aspx" style="display:none;"><img id="Img1" alt="" runat="server" src="images/login.gif" border="0"/></a>
        </td>
    </tr>
      <tr>
        <td style="height:25px;"></td>
    </tr>
  
     <tr><td class="blue_14_b" align="left">Corporate/Frequent Travelers</td>
     </tr>
     <tr><td class="main_text" align="left" style="height:25px;">
            &nbsp;&nbsp;&nbsp;&nbsp;Manage your account Anywhere, Anytime.  This option allows you to store all of the information necessary to complete a reservation and eliminates repeating personal data entry. 
        </td>
     </tr>
     <tr><td class="main_text" align="left" style="height:25px;">&nbsp;&nbsp;&nbsp;&nbsp;•  Book and Confirm Reservations Faster</td></tr>
     <tr><td class="main_text" align="left" style="height:25px;">&nbsp;&nbsp;&nbsp;&nbsp;•  Check your Reservations status online</td></tr>
     <tr><td class="main_text" align="left" style="height:25px;">&nbsp;&nbsp;&nbsp;&nbsp;•  View a history of the rides you've taken, including detailed pricing information</td></tr>
     <tr><td class="main_text" align="left" style="height:25px;">&nbsp;&nbsp;&nbsp;&nbsp;•  Obtain online trip receipts</td></tr>
     <tr>
        <td >
             &nbsp;&nbsp;&nbsp;&nbsp;<a href="Profile_add.aspx"><img  alt="" runat="server" src="images/Create A New Account.gif" border="0"/></a>

        </td>
    </tr>
     <tr>
        <td style="height:25px;"></td>
    </tr>
<%--     <tr>
        <td align="left" class="blue_18">
            Not sure which option to select? 
        </td>
    </tr>
    <tr>
        <td align="left" class="darkgray_11">
            &nbsp;&nbsp;&nbsp;&nbsp;Information is Power! We recommend that you take a moment to create an expanded profile so that you will be able to:<br /><br />
            &nbsp;&nbsp;&nbsp;&nbsp;•  Book and Confirm Reservations Faster<br />
            &nbsp;&nbsp;&nbsp;&nbsp;•  Check your Reservations status online<br />
            &nbsp;&nbsp;&nbsp;&nbsp;•  Obtain a history of the rides you've taken, including detailed pricing information<br />
            &nbsp;&nbsp;&nbsp;&nbsp;•  Obtain online trip receipts<br />
            &nbsp;&nbsp;&nbsp;&nbsp;•  Check your frequent rider bonus point status<br />
            &nbsp;&nbsp;&nbsp;&nbsp;•  Receive updates on special offers, events, and new products and services<br /><br />
            &nbsp;&nbsp;&nbsp;&nbsp;Your <a href="Profile_add.aspx" style="text-decoration: underline; font-weight:bold;">Expanded Profile</a> will provide 24 hour access to your travel history, 
            pending trips, frequently traveled to destinations and more. 
            </td>
    </tr>
    <tr>
        <td style="height:25px;"></td>
    </tr>--%>
</table>
       
</asp:Content>
