<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="CustomerOfReport2.aspx.vb" Inherits="CustomerOfReport2" title="Untitled Page" %>

<%@ Register Src="Modules/VoucherList.ascx" TagName="VoucherList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <form id="Form1" method="post" runat="server">
        <table >
            <tr>
                <td align="left" class="css_desc2">
                    <asp:Label ID="lblTitle" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr id="trdata" runat="server" align="left">
                <td>
                    <uc1:VoucherList ID="VoucherList1" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="center">
                <br />
                <a href ="rptmenu.aspx">Back To Report Page</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <a href ="default.aspx">Back To Main Menu</a><br />
                <asp:HiddenField ID="hdnCompID" runat="server" />
                <asp:HiddenField ID="hdnCompValue" runat="server" />
                <asp:HiddenField ID="hdnDateType" runat="server" />
                <asp:HiddenField ID="hdnFromDate" runat="server" />
                <asp:HiddenField ID="hdnToDate" runat="server" />
                <br />
                </td>
            </tr>
        </table>
    </form>
</asp:Content>

