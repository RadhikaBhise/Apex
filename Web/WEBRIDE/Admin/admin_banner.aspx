<%@ Page Language="VB" AutoEventWireup="false" CodeFile="admin_banner.aspx.vb" Inherits="Admin_admin_banner" %>

<%@ Register Src="../Modules/admin_header.ascx" TagName="admin_header" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><%=System.Web.Configuration.WebConfigurationManager.AppSettings("title")%></title>
    <link href="../CSS/layout.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
    function batchValidate(){
        if (document.getElementById("txtcontent").value.length==0){
            alert('Please enter content.');
            document.getElementById("txtcontent").focus();
            return false;        
        }else if(document.getElementById("txtcontent").value.length>0){
            return confirm("Are you sure you want to save the content?");
        }
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center"><table style="width: 688px">
    <tr><td colspan="2">
        <uc1:admin_header ID="Admin_header1" runat="server" />
    </td></tr>
    <tr><td colspan="2" align="left"><font class="loginfont"><b>Admin Banner Maintenance</b></font></td></tr>
    <tr><td colspan="2" align="right"><a href="admin_main.aspx"><font class="loginfont"><b>Back</b></font></a></td></tr>
    <tr><td align="left" bgcolor="#F5F5F5" style="width: 125px"><font class="loginfont"><b>Content<br />
        <br />
        <br />
    </b></font></td>
<td align="left" style="width: 645px">
    <asp:TextBox ID="txtcontent" runat="server" Width="392px" CssClass="mainfont" Height="48px" TextMode="MultiLine"></asp:TextBox>
    </td></tr>

    <tr><td style="width: 125px; height: 23px;"></td>
    <td align="right" style="width: 645px; height: 23px;">
        <asp:Button ID="btnUpdate" runat="server" Text="Add Banner" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="False" />
        </td></tr></table>
        </div>
    </form>
</body>
</html>
