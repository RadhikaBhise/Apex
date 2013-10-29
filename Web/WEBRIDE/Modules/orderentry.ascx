<%@ Control Language="VB" AutoEventWireup="false" CodeFile="orderentry.ascx.vb" Inherits="Modules_orderentry" %>
<%@ Register Src="calendar.ascx" TagName="calendar" TagPrefix="uc1" %>

<script type="text/javascript" language="javascript">
    function OrderEntryModuleSelectPaymentType(paytype,cardtype,month,year,cardno)
    {
        var ddlPayType,ddlCardType,ddlMonth,ddlYear,txtCardNo
        ddlPayType = document.getElementById(paytype);
        ddlCardType = document.getElementById(cardtype);
        ddlMonth = document.getElementById(month);
        ddlYear = document.getElementById(year);
        txtCardNo = document.getElementById(cardno);

        if (ddlCardType != null)
        {
            if(ddlPayType.options[ddlPayType.selectedIndex].text != 'Credit Card')
            {
                ddlCardType.disabled = true;
                ddlMonth.disabled = true;
                ddlYear.disabled = true;
                txtCardNo.disabled = true;
                ddlCardType.className = 'css_grayed';
                ddlMonth.className = 'css_grayed';
                ddlYear.className = 'css_grayed';
                txtCardNo.className = 'css_grayed';
            }
            else
            {
                ddlCardType.disabled = false;
                ddlMonth.disabled = false;
                ddlYear.disabled = false;
                txtCardNo.disabled = false;
                ddlCardType.className = '';
                ddlMonth.className = '';
                ddlYear.className = '';
                txtCardNo.className = '';
            }
        }
    }
    
    
    function OrderEntryModuleGoToNextPhoneBox(thisBoxId,nextBoxId,maxlength)
    {
        var thisBox = document.getElementById(thisBoxId);
        var nextBox = document.getElementById(nextBoxId);
        if (thisBox!=null && nextBox!=null & thisBox.value.length>=maxlength)
        {
            nextBox.focus();
        }
    }
    
    //added by joey 1/30/2008
    function OrderEntryMuduleSelectFreqUser(ddlFreq,phone,phone_ext,lname,fname,email)
    {
        var txtphone = document.getElementById(phone);
        var txtphone_ext = document.getElementById(phone_ext);
        var txtlname = document.getElementById(lname);
        var txtfname = document.getElementById(fname);
        var txtemail = document.getElementById(email);
        
        //## 1 phone, 2 phone_ext, 3 lname, 4 fname, 5 Email address
        var values = ddlFreq.options[ddlFreq.selectedIndex].value.split("|");
        
        if (values.length>=4)
        {
            if (txtphone!=null)
                txtphone.value = values[0];
            if (txtphone_ext!=null)
                txtphone_ext.value = values[1];
            if (txtlname!=null)
                txtlname.value = values[2];
            if (txtfname!=null)
                txtfname.value = values[3];
            if (txtemail!=null)
                txtemail.value = values[4];
        }
    }
</script>

<table width="100%">
   <tr>
        <td colspan="4" class="css_stoptitle" align="left" style="background-image:url(Images/background.gif);padding-left:50px;height: 27px;">
                                Make a Reservation
        </td>
  </tr>
  <tr><td colspan="4" align="right"><span style="color:blue">
                                "<img id="img1" alt=""  src="Images/required_star.gif"  />"
                                 = REQUIRED
                                "<img id="img2" alt="" src="Images/reddot.gif"  />"
                                 = INCORRECT DATA
      </span></td></tr>
<tr><td colspan="1" align="center">
<table width="100%">
   <tr>
        <td class="css_text" style="width: 175px">
            Travel Date Time</td>
        <td align="left">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <uc1:calendar ID="Calendar1" runat="server" />
                    </td>
                    <td><a style="color:red">*</a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="css_text" style="width: 175px">Passenger Cell Phone #</td>
        <td align="left">
            <asp:TextBox ID="txtPhone" runat="server" MaxLength="10"></asp:TextBox><a style="color:red">*</a>
            Extension: &nbsp;<asp:TextBox ID="txtPhoneExt" runat="server" MaxLength="3" Width="46px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="css_text" style="width: 175px">
            Last, First Name</td>
        <td align="left">
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox><a style="color:red">*</a>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><a style="color:red">*</a></td>
    </tr>
    <tr>
        <td class="css_text" style="width: 175px">
            Email Address</td>
        <td align="left">
            <asp:TextBox ID="txtEmailAddress" runat="server" Width="250px"></asp:TextBox><a style="color:red">*</a></td>
    </tr>
    <tr>
        <td class="css_text" style="width: 175px">
            Payment Type</td>
        <td align="left">
            <asp:DropDownList ID="ddlPaymentType" runat="server">
            </asp:DropDownList><a style="color:red">*</a><asp:DropDownList ID="ddlCardType" runat="server">
            </asp:DropDownList></td>
    </tr>
    <tr id="trCreditCard" runat="server">
        <td class="css_text" style="width: 175px">
            Credit Card #</td>
        <td align="left">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:TextBox ID="txtCardNo" runat="server" MaxLength="16"></asp:TextBox>
                    </td>
                    <td>
                        Exp. Date<asp:DropDownList ID="ddlCardExpMonth" runat="server">
                            <asp:ListItem>Month</asp:ListItem>
                            <asp:ListItem Value="01">Jan</asp:ListItem>
                            <asp:ListItem Value="02">Feb</asp:ListItem>
                            <asp:ListItem Value="03">Mar</asp:ListItem>
                            <asp:ListItem Value="04">Apr</asp:ListItem>
                            <asp:ListItem Value="05">May</asp:ListItem>
                            <asp:ListItem Value="06">Jun</asp:ListItem>
                            <asp:ListItem Value="07">Jul</asp:ListItem>
                            <asp:ListItem Value="08">Aug</asp:ListItem>
                            <asp:ListItem Value="09">Sep</asp:ListItem>
                            <asp:ListItem Value="10">Oct</asp:ListItem>
                            <asp:ListItem Value="11">Nov</asp:ListItem>
                            <asp:ListItem Value="12">Dec</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCardExpYear" runat="server">
                            <asp:ListItem>Year</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="css_text" style="width: 175px">
            Vehicle Type</td>
        <td align="left">
            <asp:DropDownList ID="ddlVehicleType" runat="server">
            </asp:DropDownList></td>
    </tr>
    <tr id="trReq1" runat="server">
        <td class="css_text" style="width: 175px">
            <asp:Label ID="lblReq1" runat="server"></asp:Label></td>
        <td align="left">
            <asp:TextBox ID="txtReq1" runat="server"></asp:TextBox><asp:Label style="color:red" id="req1" runat="server">*</asp:Label>
        </td>
    </tr>
    <tr id="trReq2" runat="server">
        <td class="css_text" style="width: 175px">
            <asp:Label ID="lblReq2" runat="server"></asp:Label></td>
        <td align="left">
            <asp:TextBox ID="txtReq2" runat="server"></asp:TextBox><asp:Label style="color:red" id="req2" runat="server">*</asp:Label>
        </td>
    </tr>
    <tr id="trReq3" runat="server">
        <td class="css_text" style="width: 175px">
            <asp:Label ID="lblReq3" runat="server"></asp:Label></td>
        <td align="left">
            <asp:TextBox ID="txtReq3" runat="server"></asp:TextBox><asp:Label style="color:red" id="req3" runat="server">*</asp:Label>
        </td>
    </tr>
    <tr id="trReq4" runat="server">
        <td class="css_text" style="width: 175px">
            <asp:Label ID="lblReq4" runat="server"></asp:Label></td>
        <td align="left">
            <asp:TextBox ID="txtReq4" runat="server"></asp:TextBox><asp:Label style="color:red" id="req4" runat="server">*</asp:Label>
        </td>
    </tr>
    <tr id="trReq5" runat="server">
        <td class="css_text" style="width: 175px">
            <asp:Label ID="lblReq5" runat="server"></asp:Label></td>
        <td align="left">
            <asp:TextBox ID="txtReq5" runat="server"></asp:TextBox><asp:Label style="color:red" id="req5" runat="server">*</asp:Label>
        </td>
    </tr>
    <tr id="trReq6" runat="server">
        <td class="css_text" style="width: 175px">
            <asp:Label ID="lblReq6" runat="server"></asp:Label></td>
        <td align="left">
            <asp:TextBox ID="txtReq6" runat="server"></asp:TextBox><asp:Label style="color:red" id="req6" runat="server">*</asp:Label>
        </td>
    </tr>
</table>
</td>
<td colspan="3" id="tdFreq" runat="server" valign="top" style="width: 40%">
    <table border="0" style="width: 64%">
        <tr>
            <td class="frequent_font" style="height: 26px;width:100%; background-image:url(Images/frequent_bk.gif);">
                Frequent Profile
            </td>
        </tr>
        <tr>
            <td class="frequent_value">
                <asp:ListBox ID="lstFreq" runat="server" Rows="10" Width="100%"></asp:ListBox></td>
        </tr>
    </table>
</td>
</tr>      
 
</table>
