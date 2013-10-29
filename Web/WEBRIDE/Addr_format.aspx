<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Addr_format.aspx.vb" Inherits="Addr_format" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Address Format</title>
     <style type="text/css">
    .bodyfont
{
	font-family: Arial;
	font-size: 12px;
	color: #000000;

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

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="375">
            <tr>
                <td>
                    <font class="bodyfont"><b>Example 1:<br />
                    </b>Building Number: <font class="font2">153 </font>
                        <br />
                        Street Address: <font class="font2">E 52 St</font><br />
                        <br />
                        <b>Example 2: (Queens address)<br />
                        </b>Building Number: <font color="green">47-53</font><br />
                        Street Address: <font color="green">43 Ave</font><br />
                        <br />
                        <b>List of Abbreviations:</b>
                        <br />
                        <font class="font2">Ave = Avenue<br />
                            Blvd = Boulevard<br />
                            Ga = Garden<br />
                            Pl = Place<br />
                            Plz = Plaza<br />
                            Rd = Road<br />
                            St = Street<br />
                            Te = Terrace<br />
                            N, W, E, S = North, West, East, South<br />
                        </font>
                        <br />
                        <br />
                        <a href="javascript:window.close();">CLOSE WINDOW</a> </font>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
