<%@ Page Language="VB" AutoEventWireup="false" CodeFile="airport_detail_1.aspx.vb" Inherits="airport_detail_1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=System.Web.Configuration.WebConfigurationManager.AppSettings("Title")%></title>
    <style type="text/css" >
        .form
    {
	    font-family:Arial;
	    font-size:12px;
	    color:#000000;
    }
        .formstyle
    {
   	    font-family:Arial;
	    font-size:12px;
	    color:#000000;
	    width:20px
    }
    </style>
    <script language="javascript" type="text/javascript" src="JS/Airport.js" ></script>

    <script language="javascript" type="text/javascript" >
     
        function clear_fields(fname){
		    if( fname == "code" ){
			    document.getElementById("txtAirport_code").value = "";
		    }else if( fname = "name") {
			    document.getElementById("txtAirport_name").value = "";
		    }else if( fname = "all") {
			    document.getElementById("txtAirport_code").value = "";
			    document.getElementById("txtAirport_name").value = "";
		    }
	    }
	    function batchValidate(){
		    if(document.getElementById("txtAirport_code").value=="" && document.getElementById("txtAirport_name").value==""){
		    //if(document.getElementById("txtAirport_code").value=="" && document.getElementById("txtAirport_name").value==""){
			    alert("Please enter either airport code or airport name to search on.");
			    document.getElementById("txtAirport_code").focus();
			    return false;
		    }else if(document.getElementById("txtAirport_code").value !="" && document.getElementById("txtAirport_name").value !=""){
			    alert("Please enter either airport code or airport name, but not both. Please clear either the airport code or airport name field, then click the search button.");
			    document.getElementById("txtAirport_code").focus();
			    return false;
		    }
	        //else
	 	    //return true;
	    }
    	  
    //  function   document.body.onunload()   
    //  {   
    //          alert("thank   you   for   your   visited!");   
    //  }   


    	
	</script>
</head>
<body onunload="displaystate();"> 
    <form id="form1" runat="server">
    <div>
    <table width="100%" cellspacing='0' cellpadding='0'>
<tr>
	<td width='50%' align='center' style="height: 19px"><font class="form">
		
		1. Select Airport</font>
			</td>
	
	<td width='50%' align='center' style="height: 19px"><font class="form">
				2. Enter Flight Details<br /></font>
	</td>
</tr>
<tr><td style="height:10px"></td></tr>
<tr><td colspan="2" style="background-image:url(images/line.gif)"></td></tr>

<tr><td style="height:10px"></td></tr>
</table>
    <table>
    <tr><td colspan="3">
    <font class="form">Search For Airport. Enter Either Airport Code or Airport Name to search on</font>
 </td></tr>
<tr>
	<td style="width:100px"><font class="form"><b>Airport Code</b></font></td>
	<td style="width: 7px"><font class="form">
        <asp:TextBox ID="txtAirport_code" runat="server"></asp:TextBox>&nbsp;</font></td>
	<td><font class="form"><a href="javascript:clear_fields('code');">[CLEAR FIELD]</a></font></td>
</tr>
<tr>
	<td style="width:120px"><font class="form"><b>Airport Name</b></font></td>
	<td style="width: 7px"><font class="form">
        <asp:TextBox ID="txtAirport_name" runat="server"></asp:TextBox></font></td>
	<td><font class="form"><a href="javascript:clear_fields('name');">[CLEAR FIELD]</a></font></td>
</tr>
<tr>
	<td colspan="2" align="right" style="height: 4px"><font class="form">
        <asp:Button ID="btnSearch" runat="server" Text="Search Airport" /></font></td>
</tr>
<tr>
					<td style="width:100%" colspan="3">
						<table id="tbresult" width="100%" align="left" runat="server">
							
							<tr>
								<td><asp:datalist id="dlstAirport" runat="server" CssClass="form">
										<ItemTemplate>
											<asp:HyperLink runat="server" ID="hyAirName"></asp:HyperLink>
										</ItemTemplate>
									</asp:datalist>
									
									</td>
							</tr>
							<tr><td align="center" colspan="2"><asp:Label id="lblNone" runat="server" Visible="False"></asp:Label></td></tr>
						</table>
					</td>
				</tr>
				<tr><td colspan="2" align="center"><font class="form"><a onclick="displaystate();" href="javascript:window.close();">CLOSE WINDOW</a> </font><span id="type" style="display:none;"><asp:TextBox ID="txtType" runat="server"></asp:TextBox></span> </td></tr>
				
				    </table>
    </div>
    </form>
</body>
</html>
