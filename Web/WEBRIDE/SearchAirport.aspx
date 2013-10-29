<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SearchAirport.aspx.vb" Inherits="SearchAirport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=System.Web.Configuration.WebConfigurationManager.AppSettings("title")%></title>
    <script type="text/javascript" src="JS/price.js"></script>
    <script type="text/javascript">
    function airportlookupname(type,airportname){    
    if (type=='p' || type=='P'){        
        if (window.self.opener.document.getElementById("ctl00_content_FormName").value=="N"){
            window.self.opener.document.getElementById("ctl00_content_txtFrom").value=airportname;
            window.self.opener.document.getElementById("ctl00_content_FormName").value='Y';
         }else if (window.self.opener.document.getElementById("ctl00_content_FormName").value=="Y"){
            try{          
                window.self.opener.document.getElementById("ctl00_content_ddlpucity").value=""           
            }catch(e){
                window.self.opener.document.getElementById("ctl00_content_txtFrom").value=airportname;
            }
            //window.self.opener.document.getElementById("ctl00_content_txtFrom").style.display=""; 
            //window.self.opener.document.getElementById("ctl00_content_txtFrom").style.display="";             
            //window.self.opener.document.getElementById("ctl00_content_txtFrom").value=airportname;            
         }                
    }else if (type=='d' || type=='D'){   
        if (window.self.opener.document.getElementById("ctl00_content_ToName").value=="N"){
            window.self.opener.document.getElementById("ctl00_content_txtTo").value=airportname;
            window.self.opener.document.getElementById("ctl00_content_ToName").value='Y';
         }else if (window.self.opener.document.getElementById("ctl00_content_ToName").value=="Y"){ 
            try{
                window.self.opener.document.getElementById("ctl00_content_txtTo").value=airportname;            
            }catch(e){
                window.self.opener.document.getElementById("ctl00_content_txtTo").value=airportname;
            }                    
         }       
    }
        window.close('SearchAirport.aspx'); 
        
    }
    
   
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <A NAME=top></A> 
    <table width="100%" border="0" cellpadding="1">
        <tr> 
            <tb><table cellspacing="0" cellpadding="0" width="100%" border="0"><tr><td align="center"><asp:DataList ID="dltABC" runat="server" CssClass="citylookup" RepeatColumns="27"
                            RepeatDirection="Horizontal" >
                            <ItemTemplate>
                                <asp:HyperLink ID="hlinkABC" runat="server"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:DataList></td></tr></table></tb>
                
        </tr>
    </table>

  
        <tr> 
            <th nowrap><i><font color="#990000">Please make your selection by clicking on the airport name.</font></i></th>
        </tr>
        <tr><td align="left"><asp:datalist id="ddlairportResult" runat="server" CssClass="citylookup" >
										<ItemTemplate>
											<asp:LinkButton ID="lbtnCity" Runat="server"  />
											<asp:LinkButton ID="lbtname" Runat="server" Visible="false" />
										</ItemTemplate>
									</asp:datalist>
            <input id="hidtype" name="hidtype" style="width: 56px" type="hidden" runat="server" /></td></tr>
    </div>
    </form>
</body>
</html>
