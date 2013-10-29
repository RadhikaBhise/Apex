<%@ Page Language="VB" AutoEventWireup="false" CodeFile="admin_news_edit.aspx.vb" Inherits="Admin_admin_news_edit"   validateRequest="false" %>

<%@ Register Src="../Modules/admin_header.ascx" TagName="admin_header" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><%=System.Web.Configuration.WebConfigurationManager.AppSettings("title")%></title>
    <link href="../CSS/layout.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
    function batchValidate(){
        if (document.all['txtSummarytitle'].value==""){
            alert('Please enter Summary Title.');
            document.all['txtSummarytitle'].focus();
            return false;        
        }else if(document.all['txtsummary_text'].value==""){
            alert('Please enter Summary Text.');
            document.all['txtsummary_text'].focus();
            return false;
        }else if(document.all['txtfull_title'].value==""){
            alert('Please enter Full Title.');
            document.all['txtfull_title'].focus();
            return false;
        }else if(document.all['txtfull_text'].value==""){
            alert('Please enter Full Text.');
            document.all['txtfull_text'].focus();
            return false;
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
    <tr><td colspan="2" align="left"><font class="loginfont"><b>Add New News</b></font></td></tr>
    <tr><td colspan="2" align="right"><a href="admin_news.aspx"><font class="loginfont"><b>Back to Admin News</b></font></a></td></tr>
    <tr><td align="left" bgcolor="#F5F5F5" style="width: 125px"><font class="loginfont"><b>Summary Title</b></font></td>
<td align="left" style="width: 645px">
    <asp:TextBox ID="txtSummarytitle" runat="server" Width="376px" CssClass="mainfont"></asp:TextBox>
    <asp:LinkButton ID="LnkBtnNew" runat="server" CssClass="loginfont" Visible="False">Add New News</asp:LinkButton></td></tr>
<tr><td align="left" bgcolor="#F5F5F5" style="width: 125px"><font class="loginfont"><b>Summary Text</b><br /></font></td>
<td align="left" style="width: 645px">
    <asp:TextBox ID="txtsummary_text" runat="server" Width="376px" CssClass="mainfont" TextMode="MultiLine"></asp:TextBox></td></tr>
  
    <tr><td align="left" bgcolor="#F5F5F5" style="width: 125px"><font class="loginfont"><b>Full Title</b></font><br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </td><td align="left" style="width: 645px"><asp:TextBox ID="txtfull_title" runat="server" Height="104px" TextMode="MultiLine" Width="376px" CssClass="mainfont"></asp:TextBox>
        <input id="hidtxtid" style="width: 64px" type="hidden" runat="server" /></td></tr>
     <tr><td align="left" bgcolor="#F5F5F5" style="width: 125px"><font class="loginfont"><b>Full Text</b></font><br />
        <br />
         <br />
         <br />
        <br />
        <br />
        <br />
    </td><td align="left" style="width: 645px"><asp:TextBox ID="txtfull_text" runat="server" Height="104px" TextMode="MultiLine" Width="376px" CssClass="mainfont"></asp:TextBox>
        <input id="Hidden1" style="width: 64px" type="hidden" runat="server" /></td></tr>
    <tr><td style="width: 125px; height: 23px;"></td>
    <td align="right" style="width: 645px; height: 23px;">
        <asp:Button ID="btnUpdate" runat="server" Text="Add News" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="False" />
        </td></tr></table>
        </div>
    </form>
</body>
</html>
