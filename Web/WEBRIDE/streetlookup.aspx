<%@ Page Language="VB" AutoEventWireup="false" CodeFile="streetlookup.aspx.vb" Inherits="streetlookup" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title> <%=System.Web.Configuration.WebConfigurationManager.AppSettings("Title")%></title>
    <link rel="stylesheet" type="text/css" href="CSS/layout.css" />
   <script language="javascript" type="text/javascript" src="JS/orderform.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    		<table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr>
					<td class="css_header" align="center"><b>STREET 
								LOOKUP RESULTS</b>
					</td>
				</tr>
				<tr>
					<td>All Matching Results to "<a style="color:red"><b>
								<asp:label id="lblStName" runat="server"></asp:label></b></a>" and 
						similar results.<br/>
						<i>Click on street name to select</i> </td>
				</tr>
				<tr>
					<td align="center"><asp:datagrid id="grdStreet" runat="server" AutoGenerateColumns="False" Width="100%">
							<Columns>
								<asp:BoundColumn DataField="county" HeaderText="City" Visible="false"></asp:BoundColumn>
								<asp:BoundColumn DataField="county" HeaderText="County"></asp:BoundColumn>
								<asp:BoundColumn DataField="from_st_no" HeaderText="From_st_no"></asp:BoundColumn>
								<asp:BoundColumn DataField="to_st_no" HeaderText="To_st_no"></asp:BoundColumn>
								<asp:ButtonColumn HeaderText="Street Name">
									<ItemStyle Font-Bold="True"></ItemStyle>
									<FooterStyle Font-Size="8pt" Font-Names="helvetica,arial,sans serif"></FooterStyle>
								</asp:ButtonColumn>
							</Columns>
						</asp:datagrid><asp:label id="lbltype" runat="server" Visible="False"></asp:label></td>
				</tr>
				<tr>
					<td style="height:8px"></td>
				</tr>
				<tr>
					<td align="center"><input onclick="window.close();" type="image" src="Images/closewindow.gif"/></td>
				</tr>
			</table>
    </div>
    </form>
</body>
</html>
