<%@ Page Language="VB" MasterPageFile="MasterPageMenu.master" AutoEventWireup="false" CodeFile="rideinquiry.aspx.vb" Inherits="webride_RideInquiry" title="Untitled Page" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="Modules/footer.ascx" TagName="footer" TagPrefix="uc3" %>

<%@ Register Src="Modules/rideinquiry.ascx" TagName="rideinquiry" TagPrefix="uc1" %>
<%@ Register Src="Modules/ridesearch.ascx" TagName="ridesearch" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">

<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<table border="0" cellpadding="0" cellspacing="0" style="background-image:url(images/mainbg.gif); width:100%; height:100%">
<tr>
<td align="left">
      <table border="0" cellpadding="0" cellspacing="0" id="table1" width="620"  >
     <%--   <tr >                    
                <td style="font-family:Arial; font-size:x-large; font-weight:bold" align="left"></td>--%>
        <tr>
            <td class="css_header">Ride Inquiry</td>
        </tr>
        <tr>
            <td align="left">Here you can check the status of any active or reservation rides.<br />
            <%--<a style="color:Red">Note:</a> This page automatically reloads every 15 seconds.--%> 
            
            </td>
            <td id="tdRefresh" runat="server" align="right">
                <b>Refresh</b>
                <asp:DropDownList ID="ddlRefresh" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRefresh_SelectedIndexChanged">
                <asp:ListItem Value="0">OFF</asp:ListItem>
                <asp:ListItem Value="10" Selected="true">10 sec</asp:ListItem>
                <asp:ListItem Value="15">15 sec</asp:ListItem>
                <asp:ListItem Value="30">30 sec</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <uc2:ridesearch ID="Ridesearch1" runat="server"   />
            </td>
        </tr>
      
        <tr>
            <td align="left" colspan="2">
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
                <uc1:rideinquiry ID="Rideinquiry1" runat="server" EnableCancelRide="true" EnableModifyRide="true" EnablePaging="true" OrderModifyPage="order.aspx" />
                </ContentTemplate>
				</asp:UpdatePanel>
            </td>
        </tr>
       <tr>         
            <td   align="left"  colspan="2">
                <uc3:footer ID="Footer1" runat="server" />            
            </td>
            </tr>
    </table>
</td>
</tr>
</table>
</form>
</asp:Content>

