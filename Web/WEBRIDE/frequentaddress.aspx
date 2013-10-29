<%@ Page Language="VB" MasterPageFile="~/MasterPageMenu.master" AutoEventWireup="false" CodeFile="frequentaddress.aspx.vb" Inherits="frequentaddress" title="Untitled Page" %>
<%@ Register Src="Modules/stop.ascx" TagName="stop" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
    <script type="text/javascript" language="javascript">
        // JScript File
        function ValidateAddress(state,city,stName,stNo)
        {
            var out = false;
            var para, returnValue;
            
            para = "type=freq&pstate="+state+"&pcity="+city+"&pstrname="+stName+"&pstrno="+stNo+"&pzip=&ptype=0" +
                    "&dstate="+state+"&dcity="+city+"&dstrname="+stName+"&dstrno="+stNo+"&dzip=&dtype=";
            
            if(para!=null && para.length>0)
            {
                //alert(para);
                returnValue = window.showModalDialog('VerifyStreet.aspx?' + para,'','dialogHeight: 500px;dialogWidth: 400px;status: no');
            }
            
            if(returnValue!=null && (returnValue=='T' || returnValue=="undefined"))
            {
                out=true;
            }else{
                out=false;
            }
            
            return out;
        }
    </script>
    
    <form id="form1" runat="server">
        <script type="text/javascript" language="javascript" src="js/common.js"></script>
        
        <table width="800px" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="2" align="left" class="css_header">
                    Edit Frequent Address
                </td>
            </tr>
            <tr id="trsearch" visible="false" runat="server">
                <td style="display:none">
                    <img alt="" id="imgsearch"  runat="server" src="images/Search.gif"/>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:DataGrid ID="grdFreqAddr" runat="server"  AutoGenerateColumns="False" Width="100%" AllowPaging="true" PageSize="15" PagerStyle-Mode="numericpages" >
                        <AlternatingItemStyle CssClass="css_alterdesc" Height="22" />
                        <ItemStyle CssClass="css_itemdesc" Height="22" />
                        <EditItemStyle CssClass="css_editdesc" Height="22" />
                        <HeaderStyle CssClass ="css_title"/>
                        
                        <Columns>
                            <asp:TemplateColumn SortExpression="county" HeaderText="State">
                                <ItemTemplate>
                                    <asp:Label id="lblState"  Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "county") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList id="ddlState" runat="server" Width="120px">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateColumn> 
                            <asp:TemplateColumn SortExpression="city" HeaderText="City">
                                <ItemTemplate >
                                    <asp:Label id="lblCity"  Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "city") %>' ></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox id="txtCity" MaxLength="20" Width="80px"  Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "city") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>  
                            <asp:TemplateColumn SortExpression="st_name" HeaderText="Street Name">
                                <ItemTemplate>
                                    <asp:Label id="lblStName"  Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "st_name") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox id="txtStName" MaxLength="20" Width="130px"  Runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "st_name") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn> 
                            <asp:TemplateColumn SortExpression="st_no" HeaderText="Bldg No.">
                                <ItemTemplate>
                                    <asp:Label id="lblStNo" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "st_no") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox id="txtStNo" MaxLength="5" Width="30px"  Runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "st_no") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn SortExpression="zip" HeaderText="Zip">
                                <ItemTemplate>
                                    <asp:Label id="lblzip"  Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "zip") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox id="txtzip" MaxLength="6" Width="30px"  Runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "zip") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn SortExpression="address_type" HeaderText="Pick Up Point">
                                <ItemTemplate>
                                    <asp:Label id="lblpoint"  Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pu_point_1") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox id="txtpoint"  Width="130px"  Runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "pu_point_1") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn SortExpression="address_type" HeaderText="Address Type">
                                <ItemTemplate>
                                    <asp:Label id="lblType"  Runat="server" Text='<%# IIF(DataBinder.Eval(Container.DataItem, "address_type")="P","Pickup","Destination") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:RadioButton ID="radPickup" runat="server" Text="Pickup" GroupName="address" /><asp:RadioButton ID="radDest" runat="server" Text="Destination" GroupName="address" />
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
                            <asp:TemplateColumn HeaderText="Old County" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblOldCounty" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.county") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Old City" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblOldCity" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.city") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Old Street Name" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblOldStName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.st_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Old Street #" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblOldStNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.st_no") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                                                  
                            <asp:TemplateColumn HeaderText="Old Address Type" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblOldAddrType" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.address_type") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle Mode="NumericPages" />
                    </asp:DataGrid>
                </td>
            </tr>
            <tr>
                <td class="css_header" colspan="2">
                    <br />
                    <br />
                    Add New Frequent Address
                    <br /><br />
                </td>
            </tr>
            <tr>
                <td>
                    <table width="500px" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="padding:0px 2px;">
                                <table width="100%">
                                    <tr>
                                        <td class="css_desc" style="width:38%">Address Type</td>
                                        <td>
                                            <asp:RadioButton ID="radPickup" runat="server" Checked="true" GroupName="address" Text="Pickup" />
                                            <asp:RadioButton ID="radDest" runat="server" GroupName="address" Text="Destination" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:stop ID="Stop1" runat="server" AddressType="FrequentAddress" />
                            </td>
                        </tr>
                        <tr>
                            <td>
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

