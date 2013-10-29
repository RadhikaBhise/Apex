<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lookupStreet.aspx.vb" Inherits="lookupStreet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>
			<%=System.Web.Configuration.WebConfigurationManager.AppSettings("title")%>
	</title>
    <link href="CSS/layout.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" language="javascript">
        function returnValue(streetName)
        {
            var direction = document.getElementById("hdnDirection").value;
            var txtStName = self.opener.document.getElementById("txt" + direction + "StName");
            
			//##    use defined control ID if the url address provide it. modified by yang
            var txtStNameCtlID = document.getElementById("hdnStNameID").value;
            if ( txtStNameCtlID.length>0 && self.opener.document.getElementById(txtStNameCtlID) != null)
                txtStName = self.opener.document.getElementById(txtStNameCtlID);
          
            if(txtStName != null)
                txtStName.value = streetName;
            
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
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <em>Click on street name to select</em></td>
            </tr>
            <tr>
                <td>
                    <asp:DataGrid ID="grdStreet" runat="server" AutoGenerateColumns="False" ShowHeader="False" Width="100%">
                        <Columns>
                            <asp:ButtonColumn>
                            </asp:ButtonColumn>
                        </Columns>
                    </asp:DataGrid></td>
            </tr>
            <tr>
                <td>
                    <input type="hidden" id="hdnDirection" runat="server" />
                    <input type="hidden" id="hdnStNameID" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <input onclick="javascript:window.close();"  type="button" value="Close" /></td>
            </tr>
        </table>
        
    </form>
</body>
</html>
