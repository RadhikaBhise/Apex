<%@ Page Language="VB" AutoEventWireup="false" CodeFile="airport_detail_2.aspx.vb" Inherits="airport_detail_2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title><%=System.Web.Configuration.WebConfigurationManager.AppSettings("Title")%></title>
<link rel="stylesheet" type="text/css" href="CSS/layout.css" />
<script language="javascript" type="text/javascript" src="JS/Airport.js"></script>
<script type="text/javascript" >
    function LoadInfo(type){
        var PrefixID = "ctl00_content_";
        
            var pairline,dairline
            if (type=='p' || type=='P'){
                //document.getElementById("lblAirport_name").value=self.opener.document.getElementById(PrefixID + "txtPAirName").value;
        	    pairline=self.opener.document.getElementById(PrefixID + "txtPAirline").value;
        	    alert('ok');
        	    if (pairline=="PRIVATE"){
        	    // document.getElementById("txtAirline").style.display='none';
            	 
                 document.getElementById("txtFbo").style.display='none';
                 document.getElementById("FboDetail").style.display='';
                 document.getElementById("Private").style.display='';
                
                }
                 document.getElementById("txtFboName").value=self.opener.document.getElementById(PrefixID + "txtPFboName").value;
                 document.getElementById("txtFboAddress").value=self.opener.document.getElementById(PrefixID + "txtPFboAddress").value;
			    document.getElementById("txtFlightNo").value=self.opener.document.getElementById(PrefixID + "txtPFlightNo").value;
			    document.getElementById("txtFbo").value=self.opener.document.getElementById(PrefixID + "txtPFbo").value;
			    document.getElementById("time").value=self.opener.document.getElementById(PrefixID + "txtPAirTime").value;
			    document.getElementById("lblPoint").value=self.opener.document.getElementById(PrefixID + "txtPAirPoint").value;
			    }
			    else{
			     //document.getElementById("lblAirport_name").value=self.opener.document.getElementById(PrefixID + "txtDAirName").value;
        	    pairline=self.opener.document.getElementById(PrefixID + "txtDAirline").value;
        	    alert('ok');
        	    if (pairline=="PRIVATE"){
        	     //document.getElementById("txtAirline").style.display='none';
                 document.getElementById("txtFbo").style.display='none';
                 document.getElementById("FboDetail").style.display='';
                 document.getElementById("Private").style.display='';
                
                }
                 document.getElementById("txtFboName").value=self.opener.document.getElementById(PrefixID + "txtDFboName").value;
                 document.getElementById("txtFboAddress").value=self.opener.document.getElementById(PrefixID + "txtDFboAddress").value;
			    document.getElementById("txtFlightNo").value=self.opener.document.getElementById(PrefixID + "txtDFlightNo").value;
			    document.getElementById("txtFbo").value=self.opener.document.getElementById(PrefixID + "txtDFbo").value;
			    document.getElementById("time").value=self.opener.document.getElementById(PrefixID + "txtDAirTime").value;
			    document.getElementById("txtCity").value=self.opener.document.getElementById(PrefixID + "txtDDepartingCity").value;
			    }
    }
    function hidAirline(flag)
    {
       
       if(flag=="1"){
            document.getElementById("txtAirline").style.display='none';
       }
       else{
            document.getElementById("ddlairportairline").style.display='none';
       }
       
    }
    function display(){
       if (document.getElementById("ckPrivate").checked){
          if(document.getElementById("hidAirlineFlag").value="1"){
              document.getElementById("ddlairportairline").style.display='none';
          }
          else{
              document.getElementById("txtAirline").style.display='none';
          }
          document.getElementById("txtFbo").style.display='none';
          document.getElementById("FboDetail").style.display='';
          document.getElementById("Private").style.display='';
       }else{
          if(document.getElementById("hidAirlineFlag").value="1"){
              document.getElementById("ddlairportairline").style.display='';
          }
          else{
              document.getElementById("txtAirline").style.display='';
          }
          
          document.getElementById("txtFbo").style.display='';
          document.getElementById("FboDetail").style.display='none';
          document.getElementById("Private").style.display='none';
       }
    }
    function update_time(){
	    }
    	
    function save_data(addr_type)
    {
	    var airport,phone,flight,airline,airline_value,airline_code,terminal,comment,aptime,pu_point;
	    var addr_type,str_output;
	    var fbo_name,fbo_address;
    	var PrefixID = "ctl00_content_";
    	
	    //update_time();
	    var req_date,req_hour,req_min,req_ampm;
	    req_date	= document.getElementById("ddlDate").options[document.getElementById("ddlDate").selectedIndex].value;
	    req_hour	= document.getElementById("ddlHour").options[document.getElementById("ddlHour").selectedIndex].value;
	    req_min		= document.getElementById("ddlMin").options[document.getElementById("ddlMin").selectedIndex].value;
	    req_ampm	= document.getElementById("ddlAMPM").options[document.getElementById("ddlAMPM").selectedIndex].value;
	    document.getElementById("time").value=req_date +" " + req_hour +":"+req_min +":00 "  + req_ampm;
    	
	    //phone		= document.AIRPORT_DETAILS.airport_phone;
	    airport     = document.getElementById("lblAirport_name").innerText  ;//11/21/2007 add by lily
	    flight      = document.getElementById("txtFlightNo").value;
	    terminal	= document.getElementById("txtFbo").value;
	    comment		= document.getElementById("txtCity").value;
	    aptime		= document.getElementById("time").value;
	    //airline_code= document.AIRPORT_DETAILS.airline_code;
	    fbo_name	= document.getElementById("txtFboName").value;
	    //alert(document.getElementById("txtFboName").value);
	    fbo_address	= document.getElementById("txtFboAddress").value;
    	
        if (document.getElementById("ckPrivate").checked)
        {
            airline="PRIVATE";
        }else{
            if(document.getElementById("hidAirlineFlag").value="1")
            {
                var ind;
                ind=document.getElementById("ddlairportairline").selectedIndex;
                airline=document.getElementById('ddlairportairline').options[ind].value
            }else{
                airline= document.getElementById("txtAirline").value;
            }
        }
    		
    	
	    if(addr_type == "p")
	    {
	        if(document.getElementById("txtAirport_pu_point").value!="")
	        {
		        pu_point = document.getElementById("txtAirport_pu_point").value
	        }else{
		        pu_point = document.getElementById("ddlPAirPoint").options[document.getElementById("ddlPAirPoint").selectedIndex].value;
	        }
	    }
    		
        enableControls(addr_type);
        
    	//alert(airline + "       " + pu_point);
    	
	    if (addr_type == "p" || addr_type=="P")
	    {
		    if(flight==""){
			    alert("Please enter a flight number.");
			    document.getElementById("txtFlightNo").focus();
			    return false;
		    /*}else if(phone.value != "" && isNaN(phone.value)){
			    alert("Please enter only numeric values in the phone number field. Please verify the phone number.");
			    phone.focus();
			    return false;*/
		    }else if(airline==""){
			    alert("Please enter a airline.");
    			
			      if(document.getElementById("hidAirlineFlag").value="1"){
                      document.getElementById("ddlairportairline").focus();
                  }
                  else{
                      document.getElementById("txtAirline").focus();
                  }
			    return false;
		    }else{
		        str_output = "Airport Name: " + airport; //11/21/2007 add by lily
		        str_output += "\nAirline: " + airline;
		        str_output += "\nFlight #/Tail #: " + flight;
		        if(airline == "PRIVATE"){
		          str_output += "\nFBO: " + fbo_address + " " +  fbo_name;
		          terminal =  fbo_address + " " + fbo_name ;}
		        else
		          {str_output += "\nFBO: " + terminal;}
		        str_output += "\nArrival Time: " + aptime;
		        str_output += "\nPass. Pickup Point: " + pu_point;
		        //str_output += "\nPass Pickup Phone: " //+ obj_phone;
		        //str_output += "\nDeparting City: "// + obj_comment;
		        self.opener.document.getElementById(PrefixID + "pu_airport_detail").value = str_output;
		        self.opener.document.getElementById(PrefixID + "txtPAirName").value=document.getElementById("lblAirport_name").value;
		        self.opener.document.getElementById(PrefixID + "txtPAirline").value=airline;
		        self.opener.document.getElementById(PrefixID + "txtPFlightNo").value = flight;
		        self.opener.document.getElementById(PrefixID + "txtPFbo").value=terminal;
		        self.opener.document.getElementById(PrefixID + "txtPAirTime").value=aptime;
		        self.opener.document.getElementById(PrefixID + "txtPFboName").value=fbo_name;
		        self.opener.document.getElementById(PrefixID + "txtPFboAddress").value=fbo_address;
        		
		        self.opener.document.getElementById(PrefixID + "txtPAirPoint").value=pu_point;
		        self.opener.document.getElementById(PrefixID + "txtcheckpu").value="1";
		        //alert(self.opener.document.getElementById(PrefixID + "ddlPAirPoint").value);
		        /*self.opener.document.getElementById(PrefixID + "txtPAirReqDate").value=req_date;
		        self.opener.document.getElementById(PrefixID + "txtPAirReqHour").value=req_hour;
		        self.opener.document.getElementById(PrefixID + "txtPAirReqMin").value=req_min;
		        self.opener.document.getElementById(PrefixID + "txtPAirAMPM").value=req_ampm;*/
		        //self.opener.window.close();
    		
			    window.close();
		    }
	    }
	    else {
			    str_output = "Airport Name: " + airport; //11/21/2007 add by lily
		    str_output += "\nAirline: " + airline;
		    str_output += "\nFlight #/Tail #: " + flight;
		    if(airline == "PRIVATE"){
		    str_output += "\nFBO: " + fbo_address + " " + fbo_name;
		    terminal= fbo_address + " " +  fbo_name;}
		       else
		    {str_output += "\nFBO: " + terminal;}
		    str_output += "\nArrival Time: " + aptime;
		    //str_output += "\nPass. Pickup Point: " + obj_point;
		    //str_output += "\nPass Pickup Phone: " //+ obj_phone;
		    //str_output += "\nDeparting City: " + comment;
		    self.opener.document.getElementById(PrefixID + "dest_airport_detail").value = str_output;
		    self.opener.document.getElementById(PrefixID + "txtDAirName").value=document.getElementById("lblAirport_name").value;
		    self.opener.document.getElementById(PrefixID + "txtDAirline").value=airline;
		    self.opener.document.getElementById(PrefixID + "txtDFlightNo").value = flight;
		    self.opener.document.getElementById(PrefixID + "txtDFbo").value=terminal;
		    self.opener.document.getElementById(PrefixID + "txtDDepartingCity").value=comment;
		    self.opener.document.getElementById(PrefixID + "txtDAirTime").value=aptime;
		    self.opener.document.getElementById(PrefixID + "txtDFboName").value=fbo_name;
		    self.opener.document.getElementById(PrefixID + "txtDFboAddress").value=fbo_address;
		    self.opener.document.getElementById(PrefixID + "txtcheckdest").value="1";
		    //self.opener.document.getElementById(PrefixID + "txtDDepartingCity").value=comment;
		    /*self.opener.document.getElementById(PrefixID + "txtDAirReqDate").value=req_date;
		    self.opener.document.getElementById(PrefixID + "txtDAirReqHour").value=req_hour;
		    self.opener.document.getElementById(PrefixID + "txtDAirReqMin").value=req_min;
		    self.opener.document.getElementById(PrefixID + "txtDAirAMPM").value=req_ampm;*/
		    window.close();
		    /*}*/
	    }
    	
    }
    
	function enableControls(flag)
	{
	    var PrefixID = "ctl00_content_";
	    
	    //##    11/21/2007  Modified by yang
	    var ckAirport = self.opener.document.getElementById(PrefixID + "ck" + flag.toUpperCase() + "Airport");
	    var txtCity = self.opener.document.getElementById(PrefixID + "txt" + flag.toUpperCase() + "City");
	    var txtStNo = self.opener.document.getElementById(PrefixID + "txt" + flag.toUpperCase() + "StNo");
	    var txtStName = self.opener.document.getElementById(PrefixID + "txt" + flag.toUpperCase() + "StName");
	    var txtZip = self.opener.document.getElementById(PrefixID + "txt" + flag.toUpperCase() + "Zip");
	    var txtPoint = self.opener.document.getElementById(PrefixID + "txt" + flag.toUpperCase() + "Point");
	    var txtCross = self.opener.document.getElementById(PrefixID + "txt" + flag.toUpperCase() + "Cross");
	    
	    if (ckAirport!=null)
	        ckAirport.checked = true;
	    if (txtCity!=null)
	    {
	        txtCity.className="css_grayed";
	        txtCity.disabled = true;
	    }
	    if (txtStNo!=null)
	    {
	        txtStNo.className="css_grayed";
	        txtStNo.disabled = true;
	    }
	    if (txtStName!=null)
	    {
	        txtStName.className="css_grayed";
	        txtStName.disabled = true;
	    }
	    if (txtZip!=null)
	    {
	        txtZip.className="css_grayed";
	        txtZip.disabled = true;
	    }
	    if (txtPoint!=null)
	    {
	        txtPoint.className="css_grayed";
	        txtPoint.disabled = true;
	        txtPoint.value = "";
	    }
	    if (txtCross!=null)
	    {
	        txtCross.className="css_grayed";
	        txtCross.disabled = true;
	    }
	    
	    if (flag.toLowerCase()=="d")
	    {
	        var chkAsDirected = self.opener.document.getElementById(PrefixID + "chk_as_directed");
	        if (chkAsDirected!=null)
	            chkAsDirected.checked = false;
	    }
	    
	   /*if(flag=="p" || flag=="P"){
	        self.opener.document.getElementById(PrefixID + "ckPAirport").checked =true;
	        self.opener.document.getElementById(PrefixID + "txtPCity").disabled=true;
	        self.opener.document.getElementById(PrefixID + "txtPCity").style.backgroundColor = 'lightgrey';
	        self.opener.document.getElementById(PrefixID + "txtPStNo").disabled=true;
	        self.opener.document.getElementById(PrefixID + "txtPStNo").style.backgroundColor = 'lightgrey';
	        self.opener.document.getElementById(PrefixID + "txtPStNo").value="";
	        self.opener.document.getElementById(PrefixID + "txtPStName").disabled=true;
	        self.opener.document.getElementById(PrefixID + "txtPStName").style.backgroundColor = 'lightgrey';
	        self.opener.document.getElementById(PrefixID + "txtPStName").value="";
	        self.opener.document.getElementById(PrefixID + "txtPZip").disabled=true;
	        self.opener.document.getElementById(PrefixID + "txtPZip").style.backgroundColor = 'lightgrey';
	        self.opener.document.getElementById(PrefixID + "txtPZip").value="";
	        self.opener.document.getElementById(PrefixID + "txtPPoint").disabled=true;
	        self.opener.document.getElementById(PrefixID + "txtPPoint").style.backgroundColor = 'lightgrey';
	        try{
	            self.opener.document.getElementById(PrefixID + "txtPPoint").value="";
	        }
	        catch(ex){}
	    }
	   else{
	        self.opener.document.getElementById(PrefixID + 'ckDAirport').checked =true;
	        self.opener.document.getElementById(PrefixID + "txtDCity").disabled=true;
	        self.opener.document.getElementById(PrefixID + "txtDCity").style.backgroundColor = 'lightgrey';
	        self.opener.document.getElementById(PrefixID + "txtDStNo").disabled=true;
	        self.opener.document.getElementById(PrefixID + "txtDStNo").value="";
	        self.opener.document.getElementById(PrefixID + "txtDStNo").style.backgroundColor = 'lightgrey';
	        self.opener.document.getElementById(PrefixID + "txtDStName").disabled=true;
	        self.opener.document.getElementById(PrefixID + "txtDStName").value="";
	        self.opener.document.getElementById(PrefixID + "txtDStName").style.backgroundColor = 'lightgrey';
	        self.opener.document.getElementById(PrefixID + "txtDZip").disabled=true;
	        self.opener.document.getElementById(PrefixID + "txtDZip").value="";
	        self.opener.document.getElementById(PrefixID + "txtDZip").style.backgroundColor = 'lightgrey';
	        self.opener.document.getElementById(PrefixID + "txtDCross").disabled=true;
	        self.opener.document.getElementById(PrefixID + "txtDCross").value="";
	        self.opener.document.getElementById(PrefixID + "txtDCross").style.backgroundColor = 'lightgrey';
	        try{
	         self.opener.document.forms[0].ctl00_MainContent_chk_as_directed.checked = false;
	       }catch(ex){}
	   }*/
	}
	
	
	
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%" cellspacing='0' cellpadding='0'>
<tr>
	<td style="width:50%" align='center'>
	    <a class="form_new">
	        <asp:HyperLink ID="lnkSelect" runat="server" Text="1. Select Airport"></asp:HyperLink>
	    </a>
	</td>
	<td style="width: 50%" align='center'><a class="form_new">
				2. Enter Flight Details<br /></a>
	</td>
</tr>
<tr><td style="height:10px"></td></tr>
<tr><td colspan="2" style="background-image:url(images/line.gif)"></td></tr>

<tr><td style="height:10px"></td></tr>
</table>
    <table width='100%' cellspacing='2' cellpadding='5'>

		<tr>
		<td class="css_desc">Airport Name</td>
		<td class="font2" >
            <asp:Label ID="lblAirport_name" runat="server" ></asp:Label></td>
	</tr>
	<tr style="visibility:visible ">
		<td   class="css_desc">Airline</td>
		<td >
		<span id="Private" style="display:none">Private</span>
            <asp:DropDownList ID="ddlairportairline" runat="server" Width="150px">
            </asp:DropDownList>
            <asp:TextBox ID="txtAirline" runat="server" ></asp:TextBox>
            <asp:CheckBox ID="ckPrivate" runat="server" Text="Private" />
            <input type ="hidden" runat ="server" id="hidAirlineFlag" name="hidAirlineFlag"   /> </td>
	</tr>
	<tr>
		<td style="width: 87px" class="css_desc">Flight #/Tail #</td>
		<td class="form_new" style="width: 478px">
            <asp:TextBox ID="txtFlightNo" runat="server" MaxLength="10"></asp:TextBox>
            <img alt="" src="Images/required_star.gif" /></td>
	</tr>
	<tr>
		<td  class="css_desc">FBO/Terminal</td>
		<td  ><asp:TextBox ID="txtFbo" runat="server" ></asp:TextBox>
       <span id="FboDetail" style="display:none">    <%-- 1. Enter FBO Name:<br />--%>
            <asp:TextBox runat="server" ID="txtFboName"></asp:TextBox>
           <%-- 2. Enter FBO Address:<br />--%><asp:TextBox runat="server" ID="txtFboAddress"></asp:TextBox>
            <img alt="" src="Images/required_star.gif" /></span></td>
	</tr>
	<tr style="display:none">
		<td  class="css_desc">Arrival Time</td>
		<td align="left"  ><asp:DropDownList ID='ddlDate' runat="server" CssClass="form" Width="130px"></asp:DropDownList>
           <asp:DropDownList ID='ddlHour' runat="server" CssClass="form" Width="50px"></asp:DropDownList>:&nbsp;<asp:DropDownList ID='ddlMin' runat="server" CssClass="form" Width="50px"></asp:DropDownList>&nbsp;
                <asp:DropDownList ID='ddlAMPM' runat="server" CssClass="form" Width="50px">
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList><span style="color: #ff0000"></span>
           <input type="hidden" id="hdnArrivalTime" runat="server" style="width:60px" />
        </td> 
	</tr>

	<tr id="trPickup" runat="server">
		<td  class="css_desc">PU Instructions</td>
		<td align="left"  ><asp:DropDownList ID='ddlPAirPoint' runat="server" Width="130px"></asp:DropDownList>
		
		    <a style="display:none"><asp:label ID="word" runat="server" >or type in point:</asp:label>
            <asp:TextBox ID="txtAirport_pu_point" runat="server"></asp:TextBox></a></td>
	</tr>

	<tr style="display:none">
		<td class="form_new" ><font class="form_new"><b>Contact Phone</b><br /><i>Please Enter Numbers Only<br />(No Symbols ex. 5551112222)</i></font></td>
		<td class="form_new" ></td>
	</tr>
	
	<tr id="trCity" style="display:none;">
		<td class="bodyfont" ><font class="form_new"><b> City</b></font></td>
		<td class="form_new" ><asp:TextBox runat="server" ID="txtCity" MaxLength="20"></asp:TextBox></td>
	</tr>
	<tr>
		<td colspan='2' valign="top" align="center"><input type="button" id="btnSubmit" value="Save Airport Details and close window" runat="server" /></td>
	</tr>
    <tr style="display:none;"><td><asp:Label runat="server" ID="time"></asp:Label><asp:Label runat="server" ID="lblPoint"></asp:Label></td></tr>
</table>
    </div>
    </form>
</body>
</html>
