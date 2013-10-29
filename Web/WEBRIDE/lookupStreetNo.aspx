<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lookupStreetNo.aspx.vb" Inherits="lookupStreetNo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>
		<%=System.Web.Configuration.WebConfigurationManager.AppSettings("title")%>
	</title>
    <link href="CSS/layout.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" language="javascript">
        function returnValue(streetNo)
        {
            var direction = document.getElementById("hdnDirection").value;
            var txtStNo = self.opener.document.getElementById("txt" + direction + "StNo");

			//##    use defined control ID if the url address provide it. modified by yang
            var txtStNoCtlID = document.getElementById("hdnStNoID").value;
            if ( txtStNoCtlID.length>0 && self.opener.document.getElementById(txtStNoCtlID) != null)
                txtStNo = self.opener.document.getElementById(txtStNoCtlID);
                
            if(txtStNo != null)
                txtStNo.value = streetNo;
            
            window.close();
            return false;
        }
    </script>
</head>
<body style="background:white">
    <form id="form1" runat="server">
    <table id="tableMain" width="100%">
        <tr>
            <td class="css_title">STREET #  LOOKUP RESULTS</td>
        </tr>
        <tr>
            <td><i>Please select the correct cross street and the street # will automatically 
							be populated. </i>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataGrid ID="dgStrNo" runat="server" AutoGenerateColumns="False" 
                    ShowHeader="False" Width="263px">
                    <ItemStyle Height="13pt" />
                    <Columns>
                        <asp:ButtonColumn CommandName="edit" DataTextField="to_st_no"></asp:ButtonColumn>
                        <asp:BoundColumn DataField="x_st" Visible="true"></asp:BoundColumn>
                    </Columns>
                </asp:DataGrid></td>
        </tr>
        <tr>
            <td>
                <input type="hidden" id="hdnDirection" runat="server" />
                <input type="hidden" id="hdnStNoID" runat="server" />
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
