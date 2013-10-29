<%@ Control Language="VB" AutoEventWireup="false" CodeFile="group_ridesearch.ascx.vb" Inherits="Modules_group_ridesearch" %>
<link href="../css/layout.css" type="text/css" rel="stylesheet" />
  <table border="0" cellpadding="0" cellspacing="2" width="100%">
   <tr><td align="left" class="css_desc">
   <asp:RadioButton id="radDate" runat="server" Text="RIDE DATE:" GroupName="searchby" Checked="True"></asp:RadioButton></td>
   <td><asp:textbox id="txtFDate" runat="server" Width="90px"></asp:textbox> &nbsp;<font class="main_text">To</font>&nbsp; 
   <asp:textbox id="txtTDate" runat="server" Width="90px"></asp:textbox>
   </td></tr>
   <tr><td align="left" class="css_desc">
   <asp:RadioButton id="radComp" runat="server" Text="COMP REQ:" GroupName="searchby"></asp:RadioButton></td>
   <td><asp:dropdownlist id="ddlComp_req" runat="server" Width="124px"></asp:dropdownlist>
   <asp:textbox id="txtComp_req_value" runat="server" Width="80px"></asp:textbox>
       <input id="hdnCompReq" runat="server" style="width: 24px" type="hidden" /></td></tr>       
   <tr><td colspan="2">
  <input src="../images/Submit.gif" type="image" name="ImageSubmit" id="ImageSubmit" runat="server" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('ctl00_ContentMain_ImageSubmit','','../images/button-submit.gif',1)">
   </td></tr>
   </table>