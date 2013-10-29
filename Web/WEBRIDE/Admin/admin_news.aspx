<%@ Page Language="VB" AutoEventWireup="false" CodeFile="admin_news.aspx.vb" Inherits="Admin_admin_news" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../Modules/admin_header.ascx" TagName="admin_header" TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title><%=System.Web.Configuration.WebConfigurationManager.AppSettings("title")%></title>
    <link href="../CSS/layout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<div align="center">
    		<table id="Table1" cellspacing="1" cellpadding="1" width="700" border="0">
				<tr>
				<td colspan="2"><uc1:admin_header ID="Admin_header1" runat="server" /></td>
				</tr>
					<tr>
						<td class="loignhead" style="HEIGHT: 17px" align="left" colspan="2">Admin News Maintenance</td>
					</tr>
					<tr>						
						<td align="left"><a href="admin_news_edit.aspx?style=add"><font class="loginfont"><b>Add News</b></font></a></td>
						<td align="right"><a href="admin_main.aspx"><%=System.Web.Configuration.WebConfigurationManager.AppSettings("adminBack")%></a></td>
					</tr>
					<tr>
						<td colspan="2"><asp:datagrid id="dgverbage" runat="server" AlternatingItemStyle-BorderColor="#FFFFFF" CssClass="GridFont" BackColor="White" AllowSorting="True" AllowPaging="True" PageSize="15" AutoGenerateColumns="False" Width="80%">
													<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
													<ItemStyle Height="30px" BackColor="White"></ItemStyle>
													<HeaderStyle Height="25px" BackColor="#A2ABC4" CssClass="loginfont" ForeColor="Black"></HeaderStyle>
													<Columns>	
												<asp:BoundColumn SortExpression="id" DataField="id" Visible="false"></asp:BoundColumn>																																
												<asp:TemplateColumn SortExpression="summary_title" HeaderText="Summary Title">
												    <HeaderStyle Width="80px" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
												    <ItemTemplate>
												    <asp:Label ID="lblsummary_title" CssClass="loginfont" runat="server"></asp:Label>
												    </ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Summary Text">
												    <HeaderStyle Width="100px" HorizontalAlign="left"></HeaderStyle>
												    <ItemTemplate>
												    <asp:Label ID="lblsummary_text" CssClass="loginfont" runat="server"></asp:Label>
												    </ItemTemplate>
												</asp:TemplateColumn>																									
												<asp:TemplateColumn HeaderText="Action">
													<HeaderStyle Width="100px"></HeaderStyle>
													<ItemTemplate>
                                                        <asp:HyperLink ID="btnLinkModify" CssClass="loginfont" runat="server"></asp:HyperLink>&nbsp;&nbsp;
                                                        <asp:LinkButton ID="btnLinkDelete" CssClass="loginfont" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>														
													</ItemTemplate>
											</asp:TemplateColumn>
											</Columns>	
											<PagerStyle Mode="NumericPages"></PagerStyle>										
										</asp:datagrid>
                            <input id="hdnSort" runat="server" type="hidden" /></td>
					</tr>
				</table>				
				</div>        
    </form>
</body>
</html>
