<%@ Page Language="VB" AutoEventWireup="false" CodeFile="errorpage.aspx.vb" Inherits="errorpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=System.Web.Configuration.WebConfigurationManager.AppSettings("title")%></title>
</head>
<body style="TEXT-ALIGN: center">
		<form id="Form1" method="post" runat="server">
			<table id="Table1" width="949" cellSpacing="1" cellPadding="1" border="0" style="WIDTH: 949px; HEIGHT: 576px">
				<TR>
					<TD align="center" style="FONT-WEIGHT: bold; FONT-SIZE: 12pt; FONT-FAMILY: Arial">
						Sorry, you've experienced an error. The support team has been notified. Please 
						close this screen and login again.
					</TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
