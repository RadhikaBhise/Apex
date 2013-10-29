<%@ Page Language="VB" AutoEventWireup="false" CodeFile="citylookup.aspx.vb" Inherits="citylookup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>City Lookup</title>
     <style type="text/css">
    .bodyfont
{
	font-family: Arial;
	font-size: 12px;
	color: red;
    font-weight:bold;
}

.font2
{
	font-family:Arial;
	font-size:12px;
	color:Green;
}
.form
{
	font-family:Arial;
	font-size:12px;
	color:#000000;
}
</style>
<script type="text/javascript" src="JS/orderform.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table >
        <tr><td class="form"> <font class="form"><strong><span style="font-size: 8pt; font-family: Helvetica">
                Here are the matching cities based on your search value["<font color="red"><b>
                <asp:Label ID="lblCity" runat="server"></asp:Label></b></font>"]: </span></strong></font></td></tr>
        <tr><td>
            <asp:DataGrid ID="grdcity" runat="server" AutoGenerateColumns="False" CssClass="bodyfont" Width="50%" ShowHeader="false">
                <Columns>
                    <asp:buttonColumn></asp:buttonColumn>
                   				
                </Columns>
            </asp:DataGrid></td></tr>
        <tr><td>
            <strong><span ><font class="form" >If there are not matches
                above, please search for city by selecting the first letter of city name:</font></span></strong></td></tr>
                <tr>
					<td align="left" class="form">
					<asp:datalist id="dltABC" runat="server" RepeatDirection="Horizontal" RepeatColumns="27" CssClass="citylookup">
							<ItemTemplate>
								<asp:HyperLink id="hlinkABC" runat="server" />
							</ItemTemplate>
						</asp:datalist></td>
				</tr>
				<tr>
					<td>
						<table id="tbresult" width="100%" align="left" runat="server">
							
							<tr>
								<td><asp:datalist id="dltCitis" runat="server" CssClass="form">
										<ItemTemplate>
											<asp:LinkButton ID="lbtnCity" Runat="server" />
										</ItemTemplate>
									</asp:datalist>
									<asp:Label id="Label1" runat="server" Visible="False"></asp:Label>
									<asp:Label id="lblState" runat="server" Visible="False"></asp:Label>
									<asp:Label id="lblCityHeader" runat="server" Visible="False"></asp:Label></td>
							</tr>
						</table>
					</td>
				</tr>
<tr><td><asp:label id="lbltype" runat="server" Visible="False"></asp:label></td></tr>
<tr><td><font class="bodyfont" color="red"><asp:label id="lblErr" runat="server" Visible="False"></asp:label></font></td></tr>
<tr><td style="height:10px"></td></tr>
<tr><td><font class="form"><a href="javascript:window.close();">CLOSE WINDOW</a> </font> </td></tr>
        </table>
    
    </div>
    </form>
</body>
</html>
