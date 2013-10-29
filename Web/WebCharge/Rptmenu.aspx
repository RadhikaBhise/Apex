<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Rptmenu.aspx.vb" Inherits="Rptmenu" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <form id="Form1"  method="post" runat="server">
    
        <table border ="0" cellspacing="2" cellpadding="2"  width="100%" >
				<tr>
					<td align="center" style=" padding-top:8px;font-size:x-large;COLOR:#018bd3; font:Arial; font-weight:bold">Reports</td>
				</tr>
				<tr>
				    <td style="height:10px;"></td>
				</tr>
				<tr>
					<td align="center" class="rptmenu_font">
					    <asp:HyperLink id="HyperLink3" runat="server" NavigateUrl="RptOfDay.aspx">Time of Day Report</asp:HyperLink></td>
				</tr>
				<tr>
					<td align="center" class="rptmenu_font">
							<asp:HyperLink id="lnk_TopDrivers" runat="server" NavigateUrl="RptOfDrive.aspx">Top Drivers</asp:HyperLink>
					</td></tr>
				<tr>
					<td align="center"  class="rptmenu_font">
						<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="RptOfCustom.aspx">Top Customer Reference</asp:HyperLink>
					</td>
				</tr>
				<tr>
					<td align="center"  class="rptmenu_font">
						<asp:HyperLink id="lnk_Elements" runat="server" NavigateUrl="RptOfElement.aspx">Elements</asp:HyperLink>
					</td>
			    </tr>
				<tr>
					<td align="center" class="rptmenu_font">
							<asp:HyperLink id="lnk_TopEmployee" runat="server" NavigateUrl="RptOfemp.aspx">Top Employee</asp:HyperLink>
					</td>
				</tr>
				<tr>
					<td  align="center" style="padding-top:20px "><a href="default.aspx">Back To Main Menu</a></td>
				</tr>
			</table>
    </form>
</asp:Content>

