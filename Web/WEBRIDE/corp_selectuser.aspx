<%@ Page Language="VB" MasterPageFile="~/corp_masterpageMenu.master" AutoEventWireup="false" CodeFile="corp_selectuser.aspx.vb" Inherits="corp_selectuser" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="content">
    <form id="form1" runat="server">
        <table width="600">
            <tr>
                <td class="css_header">Select User</td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlUserID" runat="server" AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
