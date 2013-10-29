<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ridesearch.ascx.vb" Inherits="Modules_ridesearch" %>
<link href="../css/layout.css" type="text/css" rel="stylesheet" />
<table border="0" cellpadding="0" cellspacing="2" width="100%">
	   <tr  align="left" >
         <td colspan="2"><b>SEARCH</b></td>
         <td colspan="4"><i>Clear Search Field and return all data based on date.</i>
               <input src="../images/Clear.gif" type="image" name="btnClear" id="btnClear" runat="server" style="height:15px;width:50px">
         </td> 
        </tr>
        <tr style="font-weight:bold;">
			<td class="css_desc">Passenger Last Name</td>
			<td class="css_desc">Agent Last Name</td>
			<td class="css_desc">PNR</td>
			<td class="css_desc">Conf. #</td>
			<td class="css_desc">Cancel #</td>
			<td class="css_desc">Date</td>
		</tr>
		<tr align="left" >
			<td><asp:textbox id="txtLname" runat="server" Width="100px"  ></asp:textbox></td>
			<td>
			    <asp:textbox id="txtAuLname" runat="server" Width="100" ></asp:textbox></td>
			<td>
			   <asp:textbox id="txtComp_id_6" runat="server" Width="100"></asp:textbox></td>
			<td>
			   <asp:textbox id="txtConf_no" runat="server"   Width="70px"></asp:textbox></td>
			<td>
               <asp:TextBox ID="txtCancel" runat="server" Width="70px"></asp:TextBox></td>
			<td>
               <asp:DropDownList  ID="ddlDate" runat="server" AutoPostBack="True"></asp:DropDownList></td>
        </tr>
        <tr align="left" >
            <td>
			     <input src="../images/Search.gif" type="image" name="btnlname" id="btnlname" runat="server" style="height:15px;width:50px"></td>
			<td>
                 <input src="../images/Search.gif" type="image" name="btnaulname" id="btnaulname" runat="server" style="height:15px;width:50px"></td>
			<td>
                 <input src="../images/Search.gif" type="image" name="btncomp_id_6" id="btncomp_id_6" runat="server" style="height:15px;width:50px"></td>
			<td>
                 <input src="../images/Search.gif" type="image" name="btnconfirmation_no" id="btnconfirmation_no" runat="server" style="height:15px;width:50px"></td>
			<td>
                 <input src="../images/Search.gif" type="image" name="btnCancel" id="btnCancel" runat="server" style="height:15px;width:50px"></td>
            <td>or enter date range
            </td>
	   </tr>
	   <tr align="right" >
			<td colspan="6">
                <asp:TextBox ID="txtFdate" runat="server" Width="70px" ></asp:TextBox>
				to<asp:TextBox ID="txtTdate" runat="server" Width="70px" ></asp:TextBox>
	           <br /><input src="../images/Search.gif" type="image" name="btnDate" id="btnDate" runat="server" style="height:15px;width:50px">
	        </td>
	  </tr>
</table>