<%@ Page Language="VB" MasterPageFile="~/corp_masterpage.master" AutoEventWireup="false" CodeFile="corp_search.aspx.vb" Inherits="corp_search" title="Untitled Page" %>

<%@ Register Src="Modules/corp_ridesearch.ascx" TagName="corp_ridesearch" TagPrefix="uc1" %>
<%@ Register Src="Modules/corp_ridehistory.ascx" TagName="corp_ridehistory" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
    <uc1:corp_ridesearch ID="Corp_ridesearch1" runat="server" />
    <uc2:corp_ridehistory ID="Corp_ridehistory1" runat="server" />
</asp:Content>

