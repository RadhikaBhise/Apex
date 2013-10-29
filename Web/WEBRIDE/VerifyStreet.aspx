<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VerifyStreet.aspx.vb" Inherits="VerifyStreet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Street Name Validation</title>
    <link href="CSS/layout.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .bodyfont
{
	font-family: Arial;
	font-size: 12px;
	color: #ffffff;
	font-weight: bold;
}
.form
{
	font-family:Arial;
	font-size:12px;
	color:#000000;
}
.bg{background-image:url(images/small-bg.jpg);}


</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   
        &nbsp;
    
    &nbsp;&nbsp;
        <input name="stno" type="hidden" />
        <input name="stname" type="hidden" />
        <input name="state" type="hidden" />
        <input name="city" type="hidden" />
        <input name="zip" type="hidden" />
        <input name="dstno" type="hidden" />
        <input name="dstname" type="hidden" />
        <input name="dstate" type="hidden" />
        <input name="dcity" type="hidden" />
        <input name="zip2" type="hidden" />
        <input name="dlandmark" type="hidden" />
        <input name="order_form_mode" type="hidden" />
       <input name="type" type="hidden"/>
        <br />
        
        <table border="1" cellspacing="0" width="100%">
        <tr><td align="center" colspan="2"> </td></tr>
        <tr><td align="center" colspan="2"><strong><span style="font-size: 10pt; font-family: Arial">Street Validation</span></strong><br /></td></tr>
            <tr>
                <td class="css_desc" style="width: 13px;white-space:nowrap;" valign="top">
                    <asp:Label ID="lblPikcup" runat="server" Font-Bold="true">Pickup Address:</asp:Label>
                </td>
                <td>
                   <asp:Label CssClass="form" ForeColor="red"  id="lblPickUp" runat="server"></asp:Label>
                </td>
            </tr>
            <tr id="trDest" runat="server">
                <td class="css_desc" style="width: 13px" valign="top"><b>Destination<br />
                        Address:</b></td>
                <td>
                   <asp:Label CssClass="form" ForeColor="red" id="lblDest" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
       <input type="button" id="btnYes" runat="server" value="Click here to continue with order" onclick="window.returnValue='T';window.close();" class="form"/>
	<br/>or<br/><br/>
	<input type="button" id="btnNo" runat="server" value="Click here to return back to order form" onclick="window.opener=null;window.returnValue='F';window.close();" class="form"/>
	<input type="hidden" id="hdnType" runat="server" />
	<input type="hidden" name="stno"		/>
	<input type="hidden" name="stname"	/>
	<input type="hidden" name="state"	/>
	<input type="hidden" name="city"	/>
	<input type="hidden" name="zip"/>
	<input type="hidden" name="dstno"/>
	<input type="hidden" name="dstname"	/>
	<input type="hidden" name="dstate"	/>
	<input type="hidden" name="dcity"	/>
	<input type="hidden" name="zip2"/>
	<asp:Literal id="ltrMsg" runat="server"></asp:Literal>
			<input id="hidMatchPStreet" style="Z-INDEX: 101; LEFT: 80px; POSITION: absolute; TOP: 304px"
				type="hidden" name="hidMatchPStreet" runat="server"/><input id="hidMatchDStreet" style="Z-INDEX: 102; LEFT: 240px; POSITION: absolute; TOP: 128px"
				type="hidden" name="hidMatchDStreet" runat="server"/> <input id="hidPType" type="hidden" name="hidPType" runat="server"/><input id="hidDType" type="hidden" name="hidDType" runat="server"/>
			<input id="hidPState" type="hidden" name="hidPState" runat="server"/><input id="hidDState" type="hidden" name="hidDState" runat="server"/><input id="hidDCity" type="hidden" name="hidDCity" runat="server"/><input id="hidDStreetNo" type="hidden" name="hidDStreetNo" runat="server"/><input id="hidDStreetName" type="hidden" name="hidDStreetName" runat="server"/><input id="hidDZip" type="hidden" name="hidDZip" runat="server"/><input id="hidPZip" type="hidden" name="hidPZip" runat="server"/><input id="hidPStreetName" type="hidden" name="hidPStreetName" runat="server"/><input id="hidPStreetNo" type="hidden" name="hidPStreetNo" runat="server"/><input id="hidPCity" type="hidden" name="hidPCity" runat="server"/>&nbsp;
        </div>
    </form>
</body>
</html>
