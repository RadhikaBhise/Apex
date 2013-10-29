<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Verify_cc_payflow.aspx.vb" Inherits="Verify_cc_payflow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Verifying Credit Card</title>
    <link href="CSS/layout.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
        .form
        {
            font-family:Arial;
            font-size:12px;
            color:#000000;
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width:100%">
            <tr id="lblProcessing" runat="server">
                <td align="center" style="FONT-WEIGHT: bold; FONT-SIZE: 11px; FONT-FAMILY: Arial">Verifying 
					Credit Card information. Please wait...</td>
            </tr>
            <tr>
                <td class="form" >
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="form">
                    <asp:label ID="lblError" runat="server" style="color:red"></asp:label>
                </td>
            </tr>
            <tr>
                <td class="form">
                    <a href="javascript:window.close();window.opener=null;">Close Window</a>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
