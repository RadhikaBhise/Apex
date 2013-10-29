<%@ Page Language="VB" AutoEventWireup="false" CodeFile="voucherimage.aspx.vb" Inherits="voucherimage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>

</head>
<body>
    <form id="form1" runat="server">
   <table>
            <tr id="print"><td>
    
                   <asp:Image ID="Image1" runat="server" Width="680" Height="350" />
                    <br />
                </td>
            </tr>
            <tr>
                    <td align="right">
             
               <%--  <INPUT onclick="document.execCommand('print','true','true')" type=button value=´òÓ¡>--%>
                     
                   <INPUT  id="btnPrint" onclick="javascript:window.print(Image1);return false;" type="image"  src="images/print.gif">
                 
               
                    </td>
           </tr></table> 
    </form>
</body>
</html>
