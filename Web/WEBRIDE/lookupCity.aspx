<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lookupCity.aspx.vb" Inherits="lookupCity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
	<title>
		<%=System.Web.Configuration.WebConfigurationManager.AppSettings("title")%>
	</title>
    <link href="CSS/layout.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" language="javascript">
        function returnValue(city)
        {
            var direction = document.getElementById("hdnDirection").value;
            var txtCity = self.opener.document.getElementById("txt" + direction + "City");
            
			//##    use defined control ID if the url address provide it. modified by yang
            var txtCityCtlID = document.getElementById("hdnCityID").value;
            
            if ( txtCityCtlID.length>0 && self.opener.document.getElementById(txtCityCtlID) != null)
                txtCity = self.opener.document.getElementById(txtCityCtlID);

            if(txtCity != null)
                txtCity.value = city;
            
            window.close();
            return false;
        }
    </script>
</head>
<body style="background:white">
    <form id="form1" runat="server">
    <table id="tableMain" width="100%">
        <tr>
            <td class="css_title">
                CITY LOOKUP RESULTS</td>
        </tr>
        <tr>
            <td><i>Please click on the city name to select</i></td>
        </tr>
        <tr>
            <td>
                <asp:DataGrid ID="grdBoro" runat="server" AutoGenerateColumns="False" 
                    ShowHeader="False" Width="263px">
                    <ItemStyle Height="13pt" />
                    <Columns>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkBoro" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"name") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td><br />
                If there are not matches above, please search for city by selecting the first letter of city name:
            </td>
        </tr>
        <tr>
			<td>
			<asp:datalist id="dltABC" runat="server" RepeatDirection="Horizontal" RepeatColumns="27" CssClass="citylookup">
					<ItemTemplate>
						<asp:HyperLink id="hlinkABC" runat="server" />
					</ItemTemplate>
				</asp:datalist></td>
		</tr>
		<tr>
			<td>
				<table id="tbresult" width="100%" runat="server">
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
        <tr>
            <td>
                <asp:DataGrid ID="grdCity" runat="server" AutoGenerateColumns="False" 
                    ShowHeader="False" Width="263px">
                    <ItemStyle Height="13pt" />
                    <Columns>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"name") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
                <input type="hidden" id="hdnDirection" runat="server" />
                <input type="hidden" id="hdnCityID" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <input onclick="window.close();" type="button" value="Close"/></td>
        </tr>
    </table>
    </form>
</body>
</html>