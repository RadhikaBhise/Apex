<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=System.Web.Configuration.WebConfigurationManager.AppSettings("title")%></title>
    <link href="../CSS/styles.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
function batchValidate() {
	
	if( document.all['username'].value.length== 0 ){
		alert("Please enter login name.");
		document.all['username'].focus();
		return false;
	}
	if( document.all['password'].value.length == 0 ){
		alert("Please enter your password.");
		document.all['password'].focus();
		return false;
	}
return true;
}

document.cookie = 'a' + escape('nothing')

</script>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
  <table width="346"   border="0" align="center" >
        <tr align="center">
      <td align="left" colspan="3"><font face="tahoma" size="4">&nbsp;</font></td>
    </tr>
    <tr>
      <td align="left" height="26"><font face="tahoma" size="4">&nbsp;</font></td>
        <td align="left" colspan="2" ><font class="loignhead"><b> 
          Login</b></font></td>
    </tr>
    <tr>
      <td align="left" width="3%" height="29" bgcolor="#FFFFFF"><b></b></td>
      <td align="left" width="33%" bgcolor="#F5F5F5"><strong><font class="loginfont"><b> 
        User Name</b></font></strong></td>
      <td align="left" width="64%"><input type="TEXT" name="username" size="20" maxlength="50" style="font-family: helvetica, arial, sans serif; font-size: 8pt" id="username" runat="server" /></td>
    </tr>
    <tr>
      <td align="left" height="27" bgcolor="#FFFFFF"><b></b></td>
        <td align="left" bgcolor="#F5F5F5"><strong><font class="loginfont">Password</font></strong></td>
      <td align="left"><font face="helvetica, arial, sans serif" size="1">
      <input type="password" id="password" name="password" size="20" maxlength="50" style="font-family: helvetica, arial, sans serif; font-size: 8pt" runat="server" />
</font></td>
    </tr>
    <tr>
      <td align="left" bgcolor="#FFFFFF">&nbsp;</td>
      <td align="left" bgcolor="#FFFFFF"><input name="Log" type="submit" id="Log" value=" Log " runat="server" /></td>
      <td align="left" height="60">      &nbsp;&nbsp;
        <input id="Reset1" type="reset" name="Submit2" value="Reset" runat="server" /></td></tr>
</table>
</div>
    </form>
</body>
</html>
