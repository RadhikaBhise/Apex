<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="setpw.aspx.vb" Inherits="setpw" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<script language="javascript" type="text/javascript">
//function batchValidate(){
//	if(document.forms[0].ctl00_MainContent_txtNewPwd.value == "" ){
//		alert("Please enter a Password.");
//		document.forms[0].ctl00_MainContent_txtNewPwd.focus();
//		return false;
//	}else if(document.forms[0].ctl00_MainContent_txtNewPwd.value.length < 4){
//		alert("Password must be at least 4 characters.");
//		document.forms[0].ctl00_MainContent_txtNewPwd.focus();
//		return false;
//	}else if(document.forms[0].ctl00_MainContent_txtPassword.value == ""){
//		alert("Please enter Confirm Password.");
//		document.forms[0].ctl00_MainContent_txtPassword.focus();
//		return false;
//	}else if(document.forms[0].ctl00_MainContentt_txtNewPwd.value!=document.forms[0].ctl00_MainContentt_txtPassword.value){
//	    alert("Passwords do not match! Please try again!");
//	    document.forms[0].ctl00_MainContent_txtPassword.focus();
//	    return false;
//	}
//}
</script>
<form id="bodyform" runat="server">
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="background: url(images/content-bg.jpg) repeat-x">
  <tr><td>
      </td>
  </tr>
  <tr>
    <td align="left" style=" height: 27px; padding-left: 276px; font-weight:bold" ><br />Please update you password.</td>
  </tr>
  <tr>
      <td align="center">
    
        
          <table style="height: 112px">
              <tr>
              <td colspan="2" align="left"  style=" font:arial; font-size:x-small; padding-left: 50px;color:red">PLEASE SELECT A PASSWORD OTHER THAN YOUR USERID<br /><br /></td></tr>						
	            <tr id="trerror" runat="server" visible="false">
		            <td colspan="2" style="font-weight:bold"><asp:label id="lblErr" runat="server" ForeColor="Red" ></asp:label></td>
	            </tr>
	            <tr  >
		            <td align="right" class="gray_12_b" >New Password:</td>
		            <td align="left"><asp:textbox runat="server" id="txtNewPwd" Width="135px"  MaxLength="20" Columns="18" TextMode="Password"></asp:textbox>&nbsp;<font color="#ff0033">*</font>   
		                <div style="position:absolute; " > 
		                      <asp:RequiredFieldValidator  ID="RequiredFieldValidatorNPwd"  Display="Dynamic" runat="server"  ControlToValidate="txtNewPwd" Font-Size="Smaller" ErrorMessage="Please enter a Password."></asp:RequiredFieldValidator>
                              <asp:CustomValidator ID="ProofLength" runat="server" OnServerValidate="Proof" ControlToValidate="txtNewPwd" Font-Size="Smaller" ErrorMessage="Password must be at least 4 characters!"></asp:CustomValidator>
	                    </div>
	                </td>
	            </tr>
	            <tr>
		            <td align="right" class="gray_12_b">Confirm Password:</td>
		            <td align="left" ><asp:textbox id="txtPassword" runat="server" Width="135px"  MaxLength="20" Columns="18" TextMode="Password"></asp:textbox>&nbsp;<font color="#ff0033">*</font>
		                 <div style="position:absolute; ">     
		                    <asp:RequiredFieldValidator   ID="RequiredFieldValidatorCPwd"  Display="Dynamic" runat="server" ControlToValidate="txtPassword" Font-Size="Smaller" ErrorMessage="Please enter Confirm Password."></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidatorNC" runat="server"  ControlToCompare="txtNewPwd" ControlToValidate="txtPassword" Font-Size="Smaller"  ErrorMessage="Passwords do not match! Please try again!"></asp:CompareValidator>
                         </div>
                    </td>
	            </tr>
	            <%--<tr>
		            <td align="left" class="orderformtd" style="width: 121px"><font class="GridFont">Confirm Password</font></td>
		            <td align="left" style="HEIGHT: 27px"><asp:textbox id="txtConfir" runat="server" Width="130px" MaxLength="25"></asp:textbox>&nbsp;<FONT color="#ff0033">*</FONT></td>
	            </tr>--%>
	            <tr>
		            <td  ><%--<a href="Home.aspx"><font face="arial" size="1">Back to Login Page</font></a>--%></td>
		            <td align="left"  >
                        <asp:ImageButton ID="ImgbtnSubmit" runat="server" ImageUrl="Images/Submit.gif" /></td>
	            </tr>
	            <tr>
	                <td>    <br />
                            <br /></td>
	                <td   align="left" > 
	                    <a href="login.aspx">Back to login</a>
	                </td>
	            </tr>
	           
    	
		  </table>
        
          <br />
          <br />
          <br />
          <br />
      </td>
  </tr>
</table>
</form>
</asp:Content>



