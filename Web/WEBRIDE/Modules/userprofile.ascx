<%@ Control Language="VB" AutoEventWireup="false" CodeFile="userprofile.ascx.vb" Inherits="Modules_userprofile" %>
<script language="javascript" type="text/javascript" src="../JS/profile.js"></script>
<table style="width: 90%">
							<tr>
								<td align="center" colspan="2">
									<font style="FONT-SIZE: 8pt;COLOR: red" face="helvetica, arial, sans serif" size="1">
										<b>
                                            <asp:Label ID="lblErr" runat="server" ForeColor="Red" Width="330px"></asp:Label></b></font></td>
							</tr>						
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">VIP Number</td>
								<td align="left" style="width: 415px"><asp:label id="lblUserID" runat="server" Width="130px" CssClass="font2"></asp:label></td>
							</tr>		
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">First Name</td>
								<td align="left" style="width: 415px"><asp:textbox id="fname" runat="server"  MaxLength="20" Width="140px"></asp:textbox></td>
							</tr>
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">Last Name</td>
								<td align="left" style="width: 415px"><asp:textbox id="lname" runat="server"  MaxLength="20" Width="140px"></asp:textbox></td>
							</tr>
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">User Name</td>
								<td align="left" style="width: 415px"><asp:label id="lblUserName" runat="server" Width="130px" CssClass="font2"></asp:label></td>
							</tr>								
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">Current Password</td>
								<td align="left" style="width: 415px"><asp:textbox id="password0" runat="server"  MaxLength="12" Width="140px"
											TextMode="Password"></asp:textbox><font face="arial" color="red" size="2">*</font></td>
							</tr>
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">New Password</td>
								<td align="left" style="width: 415px"><asp:textbox id="password1" runat="server"  MaxLength="12" Width="140px"
											TextMode="Password"></asp:textbox><font face="arial" color="red" size="2">*</font></td>
							</tr>
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">Re-Enter Password</td>
								<td align="left" style="width: 415px"><asp:textbox id="password2" runat="server"  MaxLength="12" Width="140px"
											TextMode="Password"></asp:textbox><font face="arial" color="red" size="2">*</font></td>
							</tr>
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">Street No</td>
								<td align="left" style="width: 415px"><asp:textbox id="stno" runat="server"  MaxLength="4" Width="50px"></asp:textbox></td>
							</tr>
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">Street Name</td>
								<td align="left" style="width: 415px"><asp:textbox id="stname" runat="server"  MaxLength="20" Width="140px"></asp:textbox></td>
							</tr>
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">City</td>
								<td align="left" style="width: 415px"><asp:textbox id="city" runat="server"  MaxLength="20" Width="140px"></asp:textbox></td>
							</tr>
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">State</td>
								<td align="left" style="width: 415px"><asp:textbox id="state" runat="server"  MaxLength="2" Width="40px"></asp:textbox></td>
							</tr>
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">ZipCode</td>
								<td align="left" style="width: 415px"><asp:textbox id="zipcode" runat="server"  MaxLength="4" Width="50px"></asp:textbox><font face="arial" color="blue" size="2">*</font></td>
							</tr>
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">Email</td>
								<td align="left" style="width: 415px"><asp:textbox id="email" runat="server"  MaxLength="80" Width="224px"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="email"
										Font-Names="Arial" Font-Size="8pt"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter a valid email address!"
										ControlToValidate="email" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Font-Names="Arial" Font-Size="11px"></asp:regularexpressionvalidator></td>
							</tr>
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">Office Phone</td>
								<td align="left" style="width: 415px"><font face="helvetica,arial" size="1"><asp:textbox id="officephone" runat="server"  MaxLength="25" Width="120px"></asp:textbox><font class="GridFont1">ext</font></font>
									<asp:textbox id="officephoneext" runat="server"  MaxLength="5" Width="50px"></asp:textbox></td>
							</tr>
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">Cell Phone</td>
								<td align="left" style="width: 415px"><asp:textbox id="txtCellPhone" runat="server"  MaxLength="25" Width="120px"></asp:textbox></td>
							</tr>
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">Fax</td>
								<td align="left" style="width: 415px"><asp:textbox id="txtFax" runat="server"  MaxLength="25" Width="120px"></asp:textbox></td>
							</tr>
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">Home Phone</td>
								<td align="left" style="width: 415px"><asp:textbox id="txtHomePage" runat="server"  MaxLength="25" Width="120px"></asp:textbox></td>
							</tr>
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">Pager</td>
								<td align="left" style="width: 415px"><asp:textbox id="txtPager" runat="server"  MaxLength="25" Width="120px"></asp:textbox></td>
							</tr>
							<tr>
								<td style="WIDTH: 100px" class="css_desc" height="27" align="left">Phone 2</td>
								<td align="left" style="width: 415px"><asp:textbox id="txtPhone2" runat="server"  MaxLength="25" Width="120px"></asp:textbox><font class="GridFont1">ext</font>
								<asp:textbox id="txtphone2_ext" runat="server"  MaxLength="5" Width="50px"></asp:textbox></td>
							</tr>
							<tr>
								<td style="WIDTH: 100px; height: 27;" class="css_desc" align="left">Credit Card #</td>								
								<td align="left" style="width:415px; height: 37px;">
								<table border="1" cellspacing="1" cellpadding="1" style="height:100%;width:130%"><tr><td>
                                <asp:DropDownList ID='ddlCardType' runat="server"  Width="120px"></asp:DropDownList>
                                    <asp:Label ID="lblCardNo" runat="server" Height="16px" Width="90px"></asp:Label>Card  No.
                                <asp:TextBox ID="txtCardNo" runat="server" MaxLength="16"  Width="160px"></asp:TextBox><span style="color: #ff0000" class="OrderFormStart">*</span><br /><asp:TextBox
                                    ID="txtvcode" runat="server" Width="48px" MaxLength="4" Visible="false"></asp:TextBox><font class="GridFont1">Exp.Date</font>&nbsp;<asp:DropDownList ID='ddlExpMonth' runat="server"  Width="59px"></asp:DropDownList><span style="color: #ff0000" class="OrderFormStart">*</span>&nbsp;
                                <asp:DropDownList ID='ddlExpYear' runat="server"  Width="57px"></asp:DropDownList><span style="color: #ff0000" class="OrderFormStart">*</span><%--Cardholder Name
                                <asp:TextBox ID="txtCardName"  runat="server" MaxLength="50" Width="120px"></asp:TextBox>--%></td></tr>
                           
                </table><input id="hidcardno" type="hidden" name="hidcardno" runat="server" style="width: 16px" />
                                 <tr>   
							
							<td colspan="2" height="15px">
							</td></tr>
							<tr>
								<td colSpan="2" align="left">
								<input src="../images/Submit.gif" type="image" name="btnSubmit" id="btnSubmit" runat="server">
                                     &nbsp;&nbsp;&nbsp;
                                     <input src="../images/Reset.gif" type="image" name="btnReset" id="btnReset" runat="server">                                    
		        <font face="arial" color="red" > <img  alt="" id="img12" src ="../Images/required_star.gif"/> = REQUIRED FIELDS</font> &nbsp;&nbsp; <font color="blue"><font face="arial" >*</font></font> <font face="arial" color="red">= REQUIRED FOR TEMP USERS</font>&nbsp;
								</td>
							</tr>
						</table>