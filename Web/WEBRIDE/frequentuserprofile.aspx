<%@ Page Language="VB" MasterPageFile="~/MasterPageMenu.master" AutoEventWireup="false" CodeFile="frequentuserprofile.aspx.vb" Inherits="frequentuserprofile" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
    <form id="form1" runat="server">
        <script language="javascript" src="JS/AddUser.js" type="text/javascript"></script>
        <script type="text/javascript" language="javascript" src="js/common.js"></script>
        
        <table width="700px">
            <tr>
                <td colspan="2" align="left" class="css_header">
                    Edit Frequent Profile
                </td>
            </tr>
            <tr id="trsearch" visible="false" runat="server">
                <td style="display:none">
                    <img alt="" id="imgsearch"  runat="server" src="images/Search.gif"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DataGrid ID="grdFrequentUser" runat="server"  AutoGenerateColumns="False" Width="100%" AllowPaging="true" PageSize="15" PagerStyle-Mode="numericpages" >
                        <AlternatingItemStyle CssClass="css_alterdesc" Height="22" />
                        <ItemStyle CssClass="css_itemdesc" Height="22" />
                        <EditItemStyle CssClass="css_editdesc" Height="22" />
                        <HeaderStyle CssClass ="css_title"/>
                        
                        <Columns>
                            <asp:TemplateColumn SortExpression="fname" HeaderText="First Name">
                                <ItemTemplate>
                                    <asp:Label id="lblFname"  Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "fname") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox id="txtFname" Width="100px"  Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "fname") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn> 
                            <asp:TemplateColumn SortExpression="lname" HeaderText="Last Name">
                                <ItemTemplate >
                                    <asp:Label id="lblLname"  Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "lname") %>' ></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox id="txtLname" Width="100px"  Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "lname") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>  
                            <asp:TemplateColumn SortExpression="phone" HeaderText="Phone">
                                <ItemTemplate>
                                    <asp:Label id="lblPhone"  Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "phone") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox id="txtPhone" MaxLength="10" Width="80px"  Runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "phone") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn> 
                            <asp:TemplateColumn SortExpression="phone_ext" HeaderText="Phone Ext">
                                <ItemTemplate>
                                    <asp:Label id="lblPhoneExt"  Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "phone_ext") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox id="txtPhoneExt" MaxLength="5" Width="30px"  Runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "phone_ext") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn SortExpression="email" HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label id="lblEmail"  Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "email") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox id="txtEmail" Width="180px"  Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "email") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn> 
                            <asp:TemplateColumn HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton id="lnkEdit" Runat="server" CssClass="main_text" text="Edit"  CommandName="Edit"></asp:LinkButton>&nbsp;
                                    <asp:LinkButton id="lnkDelete" Runat="server"  CssClass="main_text" text="Delete"  CommandName="Delete"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton id="lnkUpdate" Runat="server"  CssClass="main_text" text="Update"  CommandName="Update"></asp:LinkButton>&nbsp;
                                    <asp:LinkButton id="lnkCancel" Runat="server" CssClass="main_text" text="Cancel"  CommandName="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Old Last Name" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblOldLName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.lname") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Old First Name" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblOldFName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.fname") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle Mode="NumericPages" />
                    </asp:DataGrid>
                </td>
            </tr>
            <tr>
                <td class="css_header">
                    <br />
                    <br />
                    Add New Frequent Profile
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td style="width: 125px" class="css_desc" align="left">First Name</td>
                            <td align="left" style="width: 415px">
                                <asp:textbox id="txtFname" runat="server"  MaxLength="20" Width="140px"></asp:textbox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFname"
                                    ErrorMessage="Please enter first name."></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 125px" class="css_desc" align="left">Last Name</td>
                            <td align="left" style="width: 415px">
                                <asp:textbox id="txtLname" runat="server"  MaxLength="20" Width="140px"></asp:textbox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLname"
                                    ErrorMessage="Please enter last name."></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 125px" class="css_desc" align="left">Phone</td>
                            <td align="left" style="width: 415px">
                                <asp:textbox id="txtPhone" runat="server"  MaxLength="10" Width="120px"></asp:textbox>
                                Ext
                                <asp:textbox id="txtPhoneExt" runat="server"  MaxLength="5" Width="50px"></asp:textbox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPhone"
                                    ErrorMessage="Please enter phone #."></asp:RequiredFieldValidator></td>
                        </tr>

                        <tr>
                            <td style="width: 125px" class="css_desc" align="left">Email</td>
                            <td align="left" style="width: 415px">
                                <asp:textbox id="txtEmail" runat="server"  MaxLength="80" Width="224px"></asp:textbox>
                                <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter email address." ControlToValidate="txtEmail" Font-Names="Arial" Font-Size="8pt" Display="Dynamic"></asp:requiredfieldvalidator>
                                <asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter a valid email address!" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Font-Names="Arial" Font-Size="11px" Display="Dynamic"></asp:regularexpressionvalidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" >
                                <br />
                                <asp:ImageButton ImageUrl="images/submit.gif" ID="btnSubmit" runat="server" />
                                <input src="images/Reset.gif" type="image" onclick="javascript:document.forms[0].reset();return false;" name="btnReset" id="btnReset" runat="server" />  
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
     </form>
</asp:Content>

