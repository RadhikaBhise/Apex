<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lookupLandmark.aspx.vb" Inherits="lookupLandmark" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=System.Web.Configuration.WebConfigurationManager.AppSettings("title")%></title>
    <link href="CSS/layout.css" rel="stylesheet" type="text/css" />
</head>
<script type="text/javascript" language="javascript">
        function returnValue(name,city,st_name,st_no,zip_code)
        {
            
            var txtLandmarkID =document.getElementById("hdnLandmarkID").value;
            var txtCityCtlID = document.getElementById("hdnCityID").value;
            var txtStNameID = document.getElementById("hdnStNameID").value;
            var txtStNoID = document.getElementById("hdnStNoID").value;
            var txtZipCodeID = document.getElementById("hdnZipCodeID").value; 

            if ( txtCityCtlID.length>0 && self.opener.document.getElementById(txtCityCtlID) != null)
                txtCity = self.opener.document.getElementById(txtCityCtlID);
              
            if ( txtLandmarkID.length>0 && self.opener.document.getElementById(txtLandmarkID) != null)
                txtLandmark = self.opener.document.getElementById(txtLandmarkID);
                
            if ( txtStNameID.length>0 && self.opener.document.getElementById(txtStNameID) != null)
                txtStName = self.opener.document.getElementById(txtStNameID);
               
            if ( txtStNoID.length>0 && self.opener.document.getElementById(txtStNoID) != null)
                txtStNo = self.opener.document.getElementById(txtStNoID);
                
            if ( txtZipCodeID.length>0 && self.opener.document.getElementById(txtZipCodeID) != null)
                txtZipCode = self.opener.document.getElementById(txtZipCodeID);

            if(txtStNameID != null)
                txtStName.value = st_name;

            if(txtStNoID != null)
                txtStNo.value = st_no;
            
            if(txtZipCodeID != null)
                txtZipCode.value = zip_code;
  
            if(txtCity != null)
                txtCity.value = city;

            if(txtLandmark != null)
                txtLandmark.value = name;

 
            window.close();
            return false;
        }
    </script>
    
<body style="background:white">
    <form id="form1" runat="server">
    <table id="tableMain" width="100%">
        <tr>
            <td class="css_title">
                LANDMARK LOOKUP RESULTS</td>
        </tr>
        <tr>
            <td><i>Please click on the landmark name to select</i></td>
        </tr>
        <tr>
            <td>
                <asp:DataGrid ID="grdLandmark" runat="server" AutoGenerateColumns="False" 
                    ShowHeader="False" Width="263px">
                    <ItemStyle Height="13pt" />
                    <Columns>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkLandmark" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem,"name") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                    <Columns>
                        <asp:BoundColumn DataField="city" Visible="false"></asp:BoundColumn>
                    </Columns>
                    <Columns>
                        <asp:BoundColumn DataField="st_name" Visible="false"></asp:BoundColumn>
                    </Columns>
                    <Columns>
                        <asp:BoundColumn DataField="st_no" Visible="false"></asp:BoundColumn>
                    </Columns>
                    <Columns>
                        <asp:BoundColumn DataField="zip_code" Visible="false"></asp:BoundColumn>
                    </Columns>
                </asp:DataGrid></td>
        </tr>
        <tr>
            <td style="height: 24px">
                <input type="hidden" id="hdnLandmarkID" runat="server" />
                <input type="hidden" id="hdnCityID" runat="server" />
                <input type="hidden" id="hdnStNameID" runat="server" />
                <input type="hidden" id="hdnStNoID" runat="server" />
                <input type="hidden" id="hdnZipCodeID" runat="server" />
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
