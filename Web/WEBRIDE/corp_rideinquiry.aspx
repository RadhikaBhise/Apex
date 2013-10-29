<%@ Page Language="VB" MasterPageFile="~/corp_MasterPageMenu.master" AutoEventWireup="false" CodeFile="corp_rideinquiry.aspx.vb" Inherits="corp_rideinquiry" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="Modules/rideinquiry.ascx" TagName="rideinquiry" TagPrefix="uc1" %>
<%@ Register Src="Modules/corp_ridesearch.ascx" TagName="ridesearch" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
   <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <table width="700px">
            <tr>
                <td class="css_header">Search</td>
                <td align="right"><a href="corp_login.aspx?action=logout">LOGOUT</a></td>
            </tr>
            <tr>
                <td colspan="2">
                <%--  <uc2:ridesearch ID="RideSearch" runat="server"  />--%>

                   <table width="100%">
                        <tr>
                            <td class="css_desc" style="width:10px">
                                <asp:RadioButton ID="rdRideDate" runat="server" Checked="True" GroupName="searchby" /></td>
                            <td class="css_desc" style="width: 16%">
                                Ride Date</td>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server" Width="80px"></asp:TextBox>&nbsp; to
                                <asp:TextBox ID="txtToDate" runat="server" Width="80px"></asp:TextBox></td>
                            <td align="right" id="tdRefresh" runat="server"><b>Refresh</b>
                                <asp:DropDownList ID="ddlRefresh" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRefresh_SelectedIndexChanged">
                                <asp:ListItem Value="0">OFF</asp:ListItem>
                                <asp:ListItem Value="10" Selected="true">10 sec</asp:ListItem>
                                <asp:ListItem Value="15">15 sec</asp:ListItem>
                                <asp:ListItem Value="30">30 sec</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="css_desc" style="width:10px">
                                <asp:RadioButton ID="rdPassengerName" runat="server" GroupName="searchby" /></td>
                            <td class="css_desc" style="width: 16%">
                                Name <i>(First/Last)</i></td>
                            <td>
                                <asp:TextBox ID="txtFirstName" runat="server" Width="80px"></asp:TextBox>
                                &nbsp;
                                <asp:TextBox ID="txtLastName" runat="server" Width="80px"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr id="trCompReq" runat="server">
                            <td class="css_desc" style="width:10px">
                                <asp:RadioButton ID="rdCompReq" runat="server" GroupName="searchby" /></td>
                            <td class="css_desc" style="width: 16%">
                                Comp REQ</td>
                            <td>
                                <asp:DropDownList ID="ddlCompReq" runat="server">
                                </asp:DropDownList>
                                &nbsp;
                                <asp:TextBox ID="txtCompReqValue" runat="server" Width="80px"></asp:TextBox></td>
                            <td></td>
                        </tr>
                    </table>
                    <asp:CheckBox ID="chkShowCancelledRides" runat="server" Text="Show Cancelled Rides" Checked="True" />
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <input src="images/Search.gif" type="image" name="ImageSubmit" id="btnSubmit" runat="server" />
                    <%--<asp:Button ID="btnSubmit" runat="server" Text="Submit" />--%></td>
            </tr>
            <tr>
                <td colspan="2"></td>
            </tr>
            <tr>
                <td colspan="2">
                    <%--add by joey     3/14/2008--%>
				    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate >
                    <div id="divUpdateProgress" style="position: absolute;" class="css_loadingprogress">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="50">
                            <ProgressTemplate>
                                <img alt="" src="Images/loading.gif" /><br />
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                    <asp:Timer ID="Timer1" runat="server" Interval ="10000" OnTick="FreshTimer_Tick" />
                    <uc1:rideinquiry ID="Rideinquiry1" runat="server" EnableCancelRide="true" EnableModifyRide="true" EnablePaging="true" OrderModifyPage="corp_orderform.aspx" />
                    </ContentTemplate>
				    </asp:UpdatePanel>
                </td>
            </tr>
      </table>
    </form>
</asp:Content>