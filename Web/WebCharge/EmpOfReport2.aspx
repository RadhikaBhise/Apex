<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EmpOfReport2.aspx.vb" Inherits="PassOfReport2" title="Untitled Page" %>

<%@ Register Src="Modules/VoucherList.ascx" TagName="VoucherList" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

<form id="Form1" method="post" runat="server">
        <table cellspacing="0" cellpadding="0" border="0" width="808px">
          
           <tr>
                <td align="left" class="css_desc2">
                    <asp:Label ID="lblTitle" runat="server" ></asp:Label>
                </td>
           </tr>
	        <tr>
		        <td align="left">
                    <uc1:VoucherList ID="VoucherList1" runat="server" />
		            <br />
		        </td>
	        </tr>
	        <tr class="noshown" id="trpage" runat="server">
		        <td class="css_font" align="center">
		            <br />
	                <a href ="rptmenu.aspx">Back To Report Page</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		            <a href ="default.aspx">Back To Main Menu</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		            <br />
		            <br />
		            <asp:HiddenField ID="hdnVipNo" runat="server" />
		            <asp:HiddenField ID="hdnDateType" runat="server" />
		            <asp:HiddenField ID="hdnFromDate" runat="server" />
		            <asp:HiddenField ID="hdnToDate" runat="server" />
		        </td>
	        </tr>
        </table>
    </form>
</asp:Content>

