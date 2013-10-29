<%@ Page Language="VB" MasterPageFile="~/MasterPageQuick.master" AutoEventWireup="false" CodeFile="Profile_add.aspx.vb" Inherits="Profile_add" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">

    <form id="form1" runat="server">

        <script language="javascript" src="JS/AddUser.js" type="text/javascript"></script>
        <script type="text/javascript" language="javascript" src="js/common.js"></script>

        <table width="800" border="0" cellspacing="0" cellpadding="0" >

            <tr>
                <td align="left" class="css_header">New User Setup</td>
            </tr>
            <tr>
                <td align="left">
                    <table >
                        <tr>
                          <td colspan="2" align="left" class="css_desc"><b>Please fill out form and enter a unique User Name which
                              you will use to login from now on.</b></td></tr>						
                        <tr>
                            <td align="center" colspan="3" style="height: 16px"><b><asp:label id="lblErr" runat="server" ForeColor="Red" Width="378px"></asp:label></b></td>
                        </tr>
                        <tr id="trlink" runat="server" visible="false">
                             <td align="center" colspan="3"  ><a href="index.aspx">Click here to return to main menu</a>
                             </td>
                        </tr>	
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >First Name</td>
                            <td align="left"><asp:textbox id="txtFname" runat="server" Width="130px" MaxLength="25"></asp:textbox>&nbsp;<font color="#ff0033">*</font></td>
                        </tr>
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >Last Name</td>
                            <td align="left" style="HEIGHT: 27px"><asp:textbox id="txtLname" runat="server" Width="130px" MaxLength="25"></asp:textbox>&nbsp;<font color="#ff0033">*</font></td>
                        </tr>
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >Company Name</td>
                            <td align="left" style="HEIGHT: 27px"><asp:textbox id="txtCompany" runat="server" Width="178px" MaxLength="25"></asp:textbox>&nbsp;<font color="#ff0033">*</font>
                            <input type="hidden" id="hidAcctName" runat ="server" style="width: 32px" /><input type="hidden" id="hidAcctId" runat ="server" style="width: 24px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >Acct ID</td>
                            <td align="left" width="450">
                                <asp:TextBox ID="txtAcctId" runat="server" Width="129px" MaxLength="10"></asp:TextBox><font class="css_desc1">(If you do not know your Acct ID, please leave this field blank.)</font>
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >User Name</td>
                            <td align="left"><asp:textbox id="txtUsername" runat="server" Width="178px" MaxLength="50"></asp:textbox>&nbsp;<FONT color="#ff0033">*</FONT></td>
                        </tr>
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >Password</td>
                            <td align="left" style="HEIGHT: 27px"><asp:textbox id="txtPassword" runat="server" Width="130px" MaxLength="50" TextMode="Password"></asp:textbox>&nbsp;<font color="#ff0033">*</font></td>
                        </tr>
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >Confirm Password</td>
                            <td align="left" style="HEIGHT: 27px"><asp:textbox id="txtConfir" runat="server" Width="130px" MaxLength="50" TextMode="Password"></asp:textbox>&nbsp;<font color="#ff0033">*</font></td>
                        </tr>
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >Credit Card #</td>
                            <td align="left">
                                <p><font class="css_desc1"><asp:dropdownlist id="ddlCardType" runat="server" Width="136px"></asp:dropdownlist>&nbsp;&nbsp;<asp:textbox id="txtCardNo" runat="server" Width="130px" MaxLength="16"></asp:textbox>&nbsp; Exp. 
	                                    Date&nbsp;<asp:dropdownlist id="ddlMonth" runat="server" Width="64px"></asp:dropdownlist></font>&nbsp;&nbsp;<asp:dropdownlist id="ddlYear" runat="server" Width="56px"></asp:dropdownlist><FONT color="#ff0033">*</FONT>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >Contact</td>
                            <td align="left"><asp:textbox id="txtContact" runat="server" Width="236px" MaxLength="20"></asp:textbox><input id="hidcctype3" type="hidden" size="1" name="Hidden1" runat="server"><INPUT id="hidcctype4" type="hidden" size="1" name="Hidden1" runat="server"/><input id="hidcctype5" type="hidden" size="1" name="Hidden1" runat="server"/><input id="hidcctype6" type="hidden" size="1" name="Hidden1" runat="server"/><input id="hidcctype1" type="hidden" size="1" name="Hidden1" runat="server"/><input id="hidcctype2" type="hidden" size="1" name="Hidden1" runat="server"/></td>
                        </tr>
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >Telephone #</td>
                            <td align="left"><asp:textbox id="txtPhoneArea" runat="server" Width="120px"  MaxLength="10" ></asp:textbox><FONT color="#ff0033">*</FONT> Ext.<asp:textbox id="txtPhonetail" runat="server" Width="54px" 
                                     MaxLength="5" ></asp:textbox></td>
                        </tr>
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >Cell #</td>
                            <td align="left"><asp:textbox id="txtCellPhoneArea" runat="server" Width="120px" 
                                     MaxLength="10" ></asp:textbox></td>
                        </tr>
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >Fax #</td>
                            <td align="left"><asp:textbox id="txtFaxArea" runat="server" Width="120px" 
                                     MaxLength="10" ></asp:textbox></td>
                        </tr>
                        <tr>
                            <td  style="width: 125px" align="left" class="css_desc" >Home Phone #</td>
                            <td align="left" style="width: 415px"><asp:textbox id="txtHomePage" runat="server"  MaxLength="10" Width="120px"></asp:textbox></td>
                        </tr>
                        <tr>
                            <td  style="width: 125px" align="left" class="css_desc" >Pager #</td>
                            <td align="left" style="width: 415px"><asp:textbox id="txtPager" runat="server"  MaxLength="10" Width="120px"></asp:textbox></td>
                        </tr>
                        <tr>
                            <td  style="width: 125px" align="left" class="css_desc" >Telephone # 2</td>
                            <td align="left" style="width: 415px"><asp:textbox id="txtPhone2" runat="server"  MaxLength="10" Width="120px"></asp:textbox></td>
                        </tr>
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >Email</td>
                            <td align="left"><asp:textbox id="txtEmail" runat="server" Width="272px" 
                                     MaxLength="50" ></asp:textbox>&nbsp;<FONT color="#ff0033">*</FONT></td>
                        </tr>
                        <tr>
                            <td align="left"colspan="2" style="height: 1px;width:100% ">
                                <hr  style="size:1" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2"><font class="css_desc1"><b>Mailing Address</b></font></td>
                        	
                        </tr>
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >Street #</td>
                            <td align="left" style="height: 13px"><asp:textbox id="txtStNo" runat="server" Width="56px"  
                                    MaxLength="10" ></asp:textbox><font color="#ff0033">*</font></td>
                        </tr>
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >Street Name</td>
                            <td align="left"><asp:textbox id="txtStName" runat="server" Width="130px" 
                                     MaxLength="20" ></asp:textbox><font color="#ff0033">*</font></td>
                        </tr>
                        <%--<tr>
                            <td align="left" class="css_desc"><font class="css_desc">Street 
                                    Address 2</font></td>
                            <td align="left"><asp:textbox id="txtAuxAddress" runat="server" Width="312px" 
                                     MaxLength="40" ></asp:textbox></td>
                        </tr>--%>
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >City</td>
                            <td align="left"><asp:textbox id="txtCity" runat="server" Width="130px" 
                                     MaxLength="20" ></asp:textbox><font color="#ff0033">*</font></td>
                        </tr>
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >State</td>
                            <td align="left"><asp:textbox id="txtState" runat="server" Width="130px" 
                                    ></asp:textbox><font color="#ff0033">*</font></td>
                        </tr>
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >Zip</td>
                            <td align="left"><font color="blue" face="arial" size="2"><asp:textbox id="txtZip" runat="server" Width="90px"  
		                                    MaxLength="6" ></asp:textbox><font color="#ff0033">*</font></font></td>
                        </tr>
                        <tr>
                            <td style="width: 125px" align="left" class="css_desc" >Sub Zip</td>
                            <td align="left"><font color="blue"  face="arial" size="2"><asp:textbox id="txtSubzip" runat="server" Width="64px"  
		                                    MaxLength="4" ></asp:textbox></font></td>
                        </tr>
                        <%--<tr>
                            <td align="left" class="css_desc"><font class="css_desc">Country</font></td>
                            <td align="left"><font color="blue"><font face="arial" size="2"><asp:textbox id="txtCounty" runat="server" Width="130px"  
		                                    MaxLength="20" ></asp:textbox></font></font></td>
                        </tr>--%>
                        <tr>
                            <td align="left"  style="width:100%;height:3px" colspan="2" >
                                <hr  style="size:1px"/>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="left" width="100%" colSpan="2" height="3">
                                <font class="css_desc1"><b>Frequent Ride Program</b>(<a href="FrequentRide.aspx" target="_new">Click here for more info</a>)</font>
                            </td>
                        </tr>--%>
                        <tr id="trButton" runat="server">
                            <td align="left" colspan="2">
                                <asp:ImageButton ImageUrl="images/submit.gif" ID="ImageSubmit" runat="server" />
                                <asp:Button ID="SubmitHide" runat="server" style="display:none" />
                                 &nbsp;&nbsp;&nbsp;
                                 <input src="images/Reset.gif" type="image" name="ImageReset" id="ImageReset" runat="server"/>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<font class="css_desc1"><a href="index.aspx">Back to Login Page</a></font></td>
                        </tr>
                        <tr>
                            <td colspan="2"><asp:Label ID='lblShow' Runat="server" Visible="False"></asp:Label></td>
                        </tr>   
                    </table>
                    <br />
                </td>
            </tr>
        </table>
    </form>
</asp:Content>

