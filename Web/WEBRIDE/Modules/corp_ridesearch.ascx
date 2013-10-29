<%@ Control Language="VB" AutoEventWireup="false" CodeFile="corp_ridesearch.ascx.vb" Inherits="Modules_corp_ridesearch" %>
<link href="../css/layout.css" type="text/css" rel="stylesheet" />
<table width="100%" border="0" cellspacing="2" cellpadding="2">
   <tr><td  class="css_desc">
            <asp:label id="lblDate" runat="server" CssClass="css_desc">RIDE DATE:</asp:label></td>
   <td ><asp:textbox id="txtFDate" runat="server" Width="124px"></asp:textbox> To 
            <asp:textbox id="txtTDate" runat="server" Width="124px"></asp:textbox></td>
   </tr>
   <tr><td  class="css_desc">
            <asp:label id="lblname" runat="server"  CssClass="css_desc">Name (First/Last)</asp:label></td>
       <td>
            <asp:textbox id="txtFName" runat="server" Width="124px"></asp:textbox>  &nbsp;
            <asp:textbox id="txtLName" runat="server" Width="124px"></asp:textbox></td>
   </tr>
   <tr id="trCompReq">
        <td  class="css_desc">
           <asp:label id="lblComp" runat="server" CssClass="css_desc">COMP REQ:</asp:label></td>
        <td>
           <asp:dropdownlist id="ddlComp_req" runat="server" Width="130px"></asp:dropdownlist>  &nbsp;
           <asp:textbox id="txtComp_req_value" runat="server" Width="124px"></asp:textbox>
        </td>
   </tr>
   <tr><td colspan="2">
            <input src="../images/Search.gif" type="image" name="ImageSubmit" id="ImageSubmit" runat="server" />
       </td>
   </tr>
   <tr><td  class="css_desc">
            <asp:label id="lblPW" runat="server" CssClass="css_desc">Enter Corporate PW:</asp:label></td>
       <td>
            <asp:textbox id="txtPW" runat="server" Width="130px" TextMode="Password"></asp:textbox>
	        <input id="hdnCompReq" type="hidden" runat="server"/>					
	   </td>
    </tr>
	<tr><td  colspan ="2"  >
             <asp:label id="lblerror" runat="server" ForeColor="#FF0066" ></asp:label>
    
	</td></tr>
   </table>