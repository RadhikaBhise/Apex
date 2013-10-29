<%@ Control Language="VB" AutoEventWireup="false" CodeFile="stop.ascx.vb" Inherits="Modules_stop" %>

<%--<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>--%>

<!-- do not correct the errors which says "file not found" in the "link" and "script" tags-->
<script type="text/javascript"  language="javascript">

    function StopMuduleLookupStreetNo(stateid,stnameid,stno,cityid)
    {
        var ddlCounty = document.getElementById(stateid);
        var county = ddlCounty.options[ddlCounty.selectedIndex].value;
        var stName = document.getElementById(stnameid).value;
        var city = ChangeBoro(document.getElementById(cityid).value);

        if(GetStateType(city)==1 && county.toUpperCase()=="NY")
        {
            //##    only boro enable street # lookup
            if(stName.length>0)
            {
                PopupWindow("./lookupStreetNo.aspx?stNoID="+stno+"&direction=D&county="+city+"&stname="+stName,300,300);
                
            }else{
                alert("Please enter a street name first!");
            }
       }
//      else if(GetStateType(county)==0){
//            alert("Please select a state first!");
//        }
        else{
            alert("Bldg/House # lookup is only available for streets within the 5 boroughs!");
        }
    }

    function StopMuduleLookupStreet(stateid,stnameid,cityid)
    {
        var ddlCounty = document.getElementById(stateid);
        var county = ddlCounty.options[ddlCounty.selectedIndex].value;
        var stName = document.getElementById(stnameid).value;
        var city = document.getElementById(cityid).value;
        city = ChangeBoro(city);
        
        if(GetStateType(city)==1 && county.toUpperCase()=="NY")
        {
            //##    only boro enable street name lookup
            if(stName.length>=3)
            {
                PopupWindow("./lookupStreet.aspx?stnameid="+stnameid+"&direction=D&county="+city+"&stname="+stName,300,300);
            }else{
                alert("Please enter at least 3 characters in the street name field!");
            }
        }
//        else if(GetStateType(city)==0){
//            alert("Please select a borough first!");
//        }
        else{
            alert("Street lookup is only available for streets within the 5 boroughs!");
        }
    }
    
    function StopMuduleLookupCity(stateid,cityid)
    {
        var state = document.getElementById(stateid).options[document.getElementById(stateid).selectedIndex].value;
        var city = document.getElementById(cityid).value;
                
        if(GetStateType(state)==2)
        {
            if(city.length>=3 || state.toUpperCase()=='NY')
            {
                PopupWindow("./lookupCity.aspx?CityID="+cityid+"&state="+state+"&city="+city,300,300);
            }else{
                alert("Please enter at least 3 characters in the city field!");
            }
        }else if(GetStateType(state)==0){
            alert("Please select a state first!");
        }
        else{
            alert("City lookup is only available for OT!");
        }
    }
    //## added by joey  12/05/2007
    function StopMuduleLookupLandmark(stateid,cityid,landmarkid,stnameid,stnoid,zipid)
    {
        
        var state = document.getElementById(stateid).options[document.getElementById(stateid).selectedIndex].value;
        var landmark = document.getElementById(landmarkid).value;
        var city = document.getElementById(cityid).value;

        if(state.toUpperCase()=="NY" && GetStateType(city)==1)
        {
            state=ChangeBoro(city);
        }
        
        var para = "./lookupLandmark.aspx?CityID="+cityid+"&state="+state+"&landmark="+landmark+"&LandmarkID="+landmarkid+"&StNameID="+stnameid+"&StNoID="+stnoid+"&ZipID="+zipid;
        if(GetStateType(state)!=0){
            if(landmark.length>=3)
            {
                PopupWindow(para,300,300);
            }else{
                alert("Please enter at least 3 characters in the landmark field!");
            }
        }
        else
        {
            alert("Please select a state first!");
        }
    }

    function StopModuleSelectState(stateid,cityid)
    {
        var txtCity = document.getElementById(cityid);
        var ddlState = document.getElementById(stateid);  
        
        if (ddlState.selectedIndex > 0)
        {
            var StateType = GetStateType(ddlState.options[ddlState.selectedIndex].value);
         
            if(StateType == 1)
            {
                //##    Boro
                txtCity.value = "";
                txtCity.disabled = true;
                txtCity.className = "css_grayed";
            }
            else if(StateType == 2)
            {
                //##    OT
                txtCity.value = "";
                txtCity.disabled = false;
                txtCity.className = "";
            }
        }
    }
    function StopModuleSelectAirportState(ddlAirportState,ddlAirport)
    {
        if(ddlAirportState!=null && ddlAirport!=null)
        {
            if (ddlAirportState.selectedIndex>=0)
            {
                ddlAirport.length = 0;
                ddlAirport.options[ddlAirport.options.length] = new Option("Please Select","");
                
                var state = ddlAirportState.options[ddlAirportState.selectedIndex].value;
                if (ddlAirportState.selectedIndex==0)
                {
                    state = "";
                }
                
                var AirportString = StopMuduleGetSimpleXmlHttpResponse("./QuickOrderForm.aspx?StopModuleGetAirportByState=" + state);
                var arrAirports = AirportString.split("|");
                if (arrAirports.length>0)
                {
                    for(var i=0;i<arrAirports.length;i++)
                    {
                        var arrAirport = arrAirports[i].split(",");
                        if (arrAirport.length==2)
                        {
                            ddlAirport.options[ddlAirport.options.length] = new Option(arrAirport[0],arrAirport[1]);
                        }
                    }
                }
            }
        }
    }
    
    function StopMuduleSelectFreq(ddlFreq,rdNonAirp,point,stname,stno,xst,state,city,puphone,puphoneext,zip,landmark,direction)
    {
        var txtPoint = document.getElementById(point);
        var txtStName = document.getElementById(stname);
        var txtStNo = document.getElementById(stno);
        var txtXSt = document.getElementById(xst);
        var ddlState = document.getElementById(state);
        var txtCity = document.getElementById(city);
        var txtPuPhone = document.getElementById(puphone);
        var txtPuPhoneExt = document.getElementById(puphoneext);
        var txtZip = document.getElementById(zip);
        var txtLandmark = document.getElementById(landmark);
        var txtDirection = document.getElementById(direction);
        
        //##    1 Pickup Point  2 St Name   3 St No     4 Cross St  5 County    6 City
        //##    7 Pickup Phone  8 Pickup Phone Ext  9 Zip   10 Landmark  11 Direction
        var values = ddlFreq.options[ddlFreq.selectedIndex].value.split(",");
        
        rdNonAirp.checked = true;
        rdNonAirp.onclick();    
        
        if (values.length>=11)
        {
            if (txtPoint!=null)
                txtPoint.value = values[0];
            if (txtStName!=null)
                txtStName.value = values[1];
            if (txtStNo!=null)
                txtStNo.value = values[2];
            if (txtXSt!=null)
                txtXSt.value = values[3];
            if (ddlState!=null)
            {
                ddlState.value = values[4];
            }
            if (txtCity!=null)
                txtCity.value = values[5];
            if (txtPuPhone!=null)
                txtPuPhone.value = values[6];
            if (txtPuPhoneExt!=null)
                txtPuPhoneExt.value = values[7];
            if (txtZip!=null)
                txtZip.value = values[8];
            if (txtLandmark!=null)
                txtLandmark.value = values[9];
            if (txtDirection!=null)
                txtDirection.value = values[10];
        }
    }
    
    function StopMuduleSelectAirport(ddlAirport,ddlAirline,txtAirline,hdnAirport)
    {
        if (ddlAirport!=null && ddlAirline!=null && hdnAirport!=null && ddlAirport.selectedIndex>0)
        {
            ddlAirline.options.length = 0;
            ddlAirline.options[0] = new Option("Please Select","");
            
            var airport = ddlAirport.options[ddlAirport.selectedIndex].value;
            var airlineString = StopMuduleGetSimpleXmlHttpResponse("./QuickOrderForm.aspx?StopModuleGetAirlineByAirport=" + airport);
            
            //##    1/7/2008    Add hidden airport code (yang)
            hdnAirport.value = airport;

            var arrAirlines = airlineString.split("|");
            if (arrAirlines.length>1)
            {
                ddlAirline.style.display = "";
                txtAirline.style.display = "none";
                for(var i=0;i<arrAirlines.length;i++)
                {
                    var arrAirline = arrAirlines[i].split(",");
                    if (arrAirline.length==2)
                    {
                        ddlAirline.options[ddlAirline.options.length] = new Option(arrAirline[0],arrAirline[1]);
                    }
                }
            }
            else
            {
                ddlAirline.style.display = "none";
                txtAirline.style.display = "";
                txtAirline.value=""
            }
        }
    }
    function StopMuduleSelectAirline(ddlAirline,txtAirline,txtTerminal)
    {
        if (ddlAirline!=null && txtAirline!=null && ddlAirline.selectedIndex>0)
        {
            txtAirline.value = ddlAirline.options[ddlAirline.selectedIndex].text;
            if (txtTerminal!=null)
                txtTerminal.value = ddlAirline.options[ddlAirline.selectedIndex].value;
        }
    }
    //## added by joey  1/3/2007
    function ChangeBoro(city)
    {
        var out;
        switch(city.toLowerCase())
        {
            case "m":
            case "manhattan":
                out = "M";
                break;
            case "bk":
            case "brooklyn":
                out = "BK";
                break;
            case "bx":
            case "bronx":
                out = "BX";
                break;
            case "si":
            case "staten island":
                out = "SI";
                break;
            case "qu":
            case "queens":
                out = "QU";
                break;
            default:
                out="";
                break
        }
        
        return out;
    }

    function GetStateType(state)
    {
        //##    1: boro     2: ot       3: airport
        var out;

        if(state.length>0 && state!="Please Select")
        {
            switch(state.toLowerCase())
            {
                case "m":
                case "bk":
                case "bx":
                case "si":
                //case "qu":
                case "manhattan":
                case "brooklyn":
                case "bronx":
                case "staten island":
                    out = 1;
                    break;
                case "ct":
                case "nj":
                case "pa":
                case "ny":
                    out = 2;
                    break;
                case "jfk":
                case "lga":
                case "ewr":
                case "ai":
                case "phl":
                case "isl":
                case "teb":
                case "hpn":
                case "isp":
                    out = 3;
                    break;
                default:
                    out = 2;
                    break
            }
        }else{
            out = 0;
        }

        return out
    }
    
    function PopupWindow(url,width,height,title)
    {
        if ( title == null )
            title = "Aleph";
             
        window.open(url, title, 'width='+width+',height='+height+',scrollbars=yes,left='+(screen.width-width)/2+',top='+(screen.height-height)/2);
        return false;
    }

    //##    AJAX (yang)
    var xmlhttp;
    function StopMuduleCreateXmlHttpRequest()
    {
        try
        {
            if( window.XMLHttpRequest )
            {
                xmlhttp_request = new XMLHttpRequest();
                if (xmlhttp_request.overrideMimeType) 
                {
                    xmlhttp_request.overrideMimeType('text/xml');
                }
            }
            else if( window.ActiveXObject )
            {
                for( var i = 5; i; i-- )
                {
                    try
                    { 
                        if( i == 2 )
                        { 
                            xmlhttp_request = new ActiveXObject( "Microsoft.XMLHTTP" );
                        }else{
                            xmlhttp_request = new ActiveXObject( "Msxml2.XMLHTTP." + i + ".0" );
                        }
                        break;
                    }
                    catch(e)
                    {
                        xmlhttp_request = null;
                    }
                }
            }
        }
        catch(e)
        {
            xmlhttp_request = null;
        }
        
        return xmlhttp_request;
    }
    function StopMuduleGetSimpleXmlHttpResponse(url)
    {
        this.xmlhttp = StopMuduleCreateXmlHttpRequest();
        if(xmlhttp != null)
        {
            xmlhttp.open("GET",url,false);
            xmlhttp.send(null);
            return xmlhttp.responseText;
        }
    }
    //##    End AJAX
    
</script>

<style type="text/css">
    .css_stoptitle
    {
        font-family:Calibri;
        font-size:13pt;
        font-weight :bold;
        text-align:left;
        text-decoration: none;
        color:#ffffff
    }
    .css_stoptitlelink
    {
        font-family:Arial;
        font-size:11px;
        text-align:left;
        text-decoration: none;
        color:#ffffff
    }    
	.css_text
	{
	    font-family:Corbel;
        background-color:#018bd3;
        color:#FFFFFF;
	    font-size:10pt;
	    font-weight :bold;
	    height: 25px;
	    text-align:left;
	    width:40%;
	}
	.css_value
	{
	    font-family:Arial;
        background-color:#ffffff;
	    font-size:11px;
	    font-weight :bold;
	    height: 25px;
	    text-align:left;
	    width:60%;
	}
	.css_grayed
	{
	    background-color:#d3d3d3;
	}
	.frequent_font
	{
        font-family:Corbel;
        color:#ffffff;
	    font-size:10pt;
	    /*font-weight :bold;*/
	    text-align:left;
	    text-decoration: none;	    
	}
	.frequent_value
	{
        font-family:Arial;
        color:#ffffff;
	    font-size:10pt;
	    background-color:#275da3;
	    /*font-weight :bold;*/
	    text-align:left;
	    text-decoration: none;	    
	}	
	.looup_font
	{
	    font-family:Arial;
	    font-size:11px;
	    text-decoration:underline;
	}
</style>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td align="left" valign="top">
            <table width="100%">
                <tr id="rdAirport" runat="server">
                    <td colspan="4" align="left" style="background-image:url(images/background.gif); height: 27px; padding-left: 50px;" class="css_stoptitle">
                        <asp:RadioButton ID="rdNonAirp" runat="server" GroupName="airport" Text="Pick Up" Checked="True" />
                        <asp:RadioButton ID="rdAirp" runat="server" GroupName="airport" Text="Airport Pick Up" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a id="lnkAddrFormat" runat="server" href="javascript:void(0);" onclick="javascript:PopupWindow('addr_format.aspx',300,400);"><font class="css_stoptitlelink">[FOR PROPER ADDRESS FORMAT]</font></a>
                    </td>
                </tr>
                <tr>
                    <td valign="top" colspan="2" style="width: 60%">
                        <table id="tblNonAirp" runat="server" style="width:100%;height:100%;" >
                            <tr id="trState" runat ="server" >
                                <td class="css_text" style="width: 37%">
                                    State</td>
                                <td class="css_value">
                                    <asp:DropDownList ID="ddlState" runat="server" Width="120px">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr id="trCity" runat ="server" >
                                <td class="css_text" style="width: 37%">
                                    <asp:Label  id="labelDCity" runat="server" >City</asp:Label></td>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtCity" runat="server" Width="120px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <a id="lookupCity" runat="server" onmouseover="self.status = 'Click Here to Look Up of City Names'; return true"
				title="Click Here to Look Up of City Names" onmouseout="self.status = ''; return true" href="javascript:void(0);"><font class="looup_font">City Lookup</font></a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trLandmark" runat="server">
                                <td class="css_text" style="width: 37%">
                                    Landmark</td>
                                <td>
                                     <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtLandmark" runat="server" Width="120px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <a id="lookupLandmark" runat="server" href="javascript:void(0);"><font class="looup_font">Landmark Lookup</font></a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trStreetNo" runat ="server">
                                <td class="css_text" style="width: 37%">
                                    Bldg No.</td>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtStNo" runat="server" Width="120px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <a id="lookupStreetNo" runat="server"  href="javascript:void(0);"><font class="looup_font">Lookup</font></a>
                                            </td>
                                        </tr>
                                    </table>
                                </td> 
                            </tr>
                            <tr  id="trStreetName" runat ="server" >
                                <td class="css_text" style="width: 37%">
                                    Street Name</td>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtStName" runat="server" Width="120px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <a id="lookupStreet" runat="server"  onmouseover="self.status = 'Click Here to Look Up Borough Street Name!'; return true" title="Click Here to Look Up Borough Street Name" onmouseout="self.status = ''; return true" href="javascript:void(0);"><font class="looup_font">Street Lookup</font></a> 
                                            </td> 
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trCross" runat ="server" >
                                <td class="css_text" style="width: 37%">
                                    Nearest
                                    Cross Street</td>
                                <td class="css_value">
                                    <asp:TextBox ID="txtXSt" runat="server" Width="120px"></asp:TextBox></td>
                            </tr>
                            <tr runat="server" id="trZipCode">
                                <td class="css_text" style="width: 37%">
                                    Zip Code</td>
                                <td class="css_value">
                                    <asp:TextBox ID="txtZip" runat="server" Width="120px"></asp:TextBox></td>
                            </tr>
                            <tr id="trPuPoint" runat="server">
                                <td class="css_text" style="width: 37%">
                                    Pick Up Point</td>
                                <td class="css_value">
                                    <asp:TextBox ID="txtPoint" runat="server" Width="120px"></asp:TextBox></td>
                            </tr>
                            <tr runat="server" id="trDirections">
                                <td class="css_text" style="width: 37%">
                                    Directions</td>
                                <td class="css_value">
                                    <asp:TextBox ID="txtDirections" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr id="trComments" runat="server">
                                <td class="css_text" style="width: 37%">
                                    Comments</td>
                                <td class="css_value">
                                    <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>
                        
                        <table id="tblAirp" width="100%" runat="server" style="display:none">
                            <tr runat="server">
                                <td align="left" class="css_text" style="width: 37%">State
                                </td>
                                <td class="css_value">
                                    <asp:DropDownList ID="ddlAirportState" runat="server" Width="152px">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr id="trAirport" runat ="server">
                                <td align="left" class="css_text" style="width: 37%">
                                    Airport Name</td>
                                <td class="css_value">
                                    <asp:DropDownList ID="ddlAirport" runat="server" Width="152px">
                                    </asp:DropDownList><a style="color:Red">*</a><asp:HiddenField ID="hdnAirport" runat="server" /></td>
                            </tr>
                            <tr id="trAirline" runat ="server">
                                <td align="left" class="css_text" style="height: 24px; width: 37%;">
                                    Airline Name</td>
                                <td class="css_value" style="height: 24px">
                                    <asp:DropDownList ID="ddlAirline" runat="server" Width="152px"></asp:DropDownList>
                                    <asp:TextBox ID="txtAirline" runat="server" MaxLength="20" Width="90px" style="display:none"></asp:TextBox><a style="color:Red" id="destairline" runat="server">*</a>
                                </td>
                            </tr>
                            <tr id="trAirpFlightNo" runat="server">
                                <td id="tdAirportFlight" runat="server" class="css_text" style="width: 37%">
                                    <asp:Label ID="labelAirportFlight" runat="server" Text="Airline Flight #"></asp:Label></td>
                                <td class="css_value">
                                    <asp:TextBox ID="txtAirportFlight" runat="server" MaxLength="5" Width="40px"></asp:TextBox><a id="lblAirpFlightNoAsterisk" runat="server" style="color:Red">*</a></td>
                            </tr>
                            <tr id="trAirpCity" runat="server">
                                <td id="tdAirportCity" runat="server" class="css_text" style="width: 37%">
                                    <asp:Label ID="labelAirportCity" runat="server" Text="Departing/Connecting City"></asp:Label></td>
                                <td class="css_value">
                                    <asp:TextBox ID="txtAirportCity" runat="server" MaxLength="15"></asp:TextBox><a id="lblAirpCityAsterisk" runat="server" style="color:Red">*</a></td>
                            </tr>
                            <tr id="trAirpFlightTime" runat="server">
                                <td class="css_text" style="width: 37%">
                                    Flight Departure Time
                                </td>
                                <td class="css_value">
                                    HH:<asp:DropDownList ID="ddlHour" runat="server">
                                        <asp:ListItem Value="">-</asp:ListItem>
                                        <asp:ListItem Value="0">00</asp:ListItem>
                                        <asp:ListItem Value="1">01</asp:ListItem>
                                        <asp:ListItem Value="2">02</asp:ListItem>
                                        <asp:ListItem Value="3">03</asp:ListItem>
                                        <asp:ListItem Value="4">04</asp:ListItem>
                                        <asp:ListItem Value="5">05</asp:ListItem>
                                        <asp:ListItem Value="6">06</asp:ListItem>
                                        <asp:ListItem Value="7">07</asp:ListItem>
                                        <asp:ListItem Value="8">08</asp:ListItem>
                                        <asp:ListItem Value="9">09</asp:ListItem>
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="11">11</asp:ListItem>
                                        <asp:ListItem Value="12">12</asp:ListItem>
                                        <asp:ListItem Value="13">13</asp:ListItem>
                                        <asp:ListItem Value="14">14</asp:ListItem>
                                        <asp:ListItem Value="15">15</asp:ListItem>
                                        <asp:ListItem Value="16">16</asp:ListItem>
                                        <asp:ListItem Value="17">17</asp:ListItem>
                                        <asp:ListItem Value="18">18</asp:ListItem>
                                        <asp:ListItem Value="19">19</asp:ListItem>
                                        <asp:ListItem Value="20">20</asp:ListItem>
                                        <asp:ListItem Value="21">21</asp:ListItem>
                                        <asp:ListItem Value="22">22</asp:ListItem>
                                        <asp:ListItem Value="23">23</asp:ListItem>
                                    </asp:DropDownList>
                                    MM:<asp:DropDownList ID="ddlMinute" runat="server">
                                        <asp:ListItem Value="">-</asp:ListItem>
                                        <asp:ListItem Value="0">00</asp:ListItem>
                                        <asp:ListItem Value="1">01</asp:ListItem>
                                        <asp:ListItem Value="2">02</asp:ListItem>
                                        <asp:ListItem Value="3">03</asp:ListItem>
                                        <asp:ListItem Value="4">04</asp:ListItem>
                                        <asp:ListItem Value="5">05</asp:ListItem>
                                        <asp:ListItem Value="6">06</asp:ListItem>
                                        <asp:ListItem Value="7">07</asp:ListItem>
                                        <asp:ListItem Value="8">08</asp:ListItem>
                                        <asp:ListItem Value="9">09</asp:ListItem>
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        
                                        <asp:ListItem Value="11">11</asp:ListItem>
                                        <asp:ListItem Value="12">12</asp:ListItem>
                                        <asp:ListItem Value="13">13</asp:ListItem>
                                        <asp:ListItem Value="14">14</asp:ListItem>
                                        <asp:ListItem Value="15">15</asp:ListItem>
                                        <asp:ListItem Value="16">16</asp:ListItem>
                                        <asp:ListItem Value="17">17</asp:ListItem>
                                        <asp:ListItem Value="18">18</asp:ListItem>
                                        <asp:ListItem Value="19">19</asp:ListItem>
                                        <asp:ListItem Value="20">20</asp:ListItem>
                                        
                                        <asp:ListItem Value="21">21</asp:ListItem>
                                        <asp:ListItem Value="22">22</asp:ListItem>
                                        <asp:ListItem Value="23">23</asp:ListItem>
                                        <asp:ListItem Value="24">24</asp:ListItem>
                                        <asp:ListItem Value="25">25</asp:ListItem>
                                        <asp:ListItem Value="26">26</asp:ListItem>
                                        <asp:ListItem Value="27">27</asp:ListItem>
                                        <asp:ListItem Value="28">28</asp:ListItem>
                                        <asp:ListItem Value="29">29</asp:ListItem>
                                        <asp:ListItem Value="30">30</asp:ListItem>
                                        
                                        <asp:ListItem Value="31">31</asp:ListItem>
                                        <asp:ListItem Value="32">32</asp:ListItem>
                                        <asp:ListItem Value="33">33</asp:ListItem>
                                        <asp:ListItem Value="34">34</asp:ListItem>
                                        <asp:ListItem Value="35">35</asp:ListItem>
                                        <asp:ListItem Value="36">36</asp:ListItem>
                                        <asp:ListItem Value="37">37</asp:ListItem>
                                        <asp:ListItem Value="38">38</asp:ListItem>
                                        <asp:ListItem Value="39">39</asp:ListItem>
                                        <asp:ListItem Value="40">40</asp:ListItem>
                                        
                                        <asp:ListItem Value="41">41</asp:ListItem>
                                        <asp:ListItem Value="42">42</asp:ListItem>
                                        <asp:ListItem Value="43">43</asp:ListItem>
                                        <asp:ListItem Value="44">44</asp:ListItem>
                                        <asp:ListItem Value="45">45</asp:ListItem>
                                        <asp:ListItem Value="46">46</asp:ListItem>
                                        <asp:ListItem Value="47">47</asp:ListItem>
                                        <asp:ListItem Value="48">48</asp:ListItem>
                                        <asp:ListItem Value="49">49</asp:ListItem>
                                        <asp:ListItem Value="50">50</asp:ListItem>
                                        
                                        <asp:ListItem Value="51">51</asp:ListItem>
                                        <asp:ListItem Value="52">52</asp:ListItem>
                                        <asp:ListItem Value="53">53</asp:ListItem>
                                        <asp:ListItem Value="54">54</asp:ListItem>
                                        <asp:ListItem Value="55">55</asp:ListItem>
                                        <asp:ListItem Value="56">56</asp:ListItem>
                                        <asp:ListItem Value="57">57</asp:ListItem>
                                        <asp:ListItem Value="58">58</asp:ListItem>
                                        <asp:ListItem Value="59">59</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="trAirpOption" runat="server">
                                <td id="tdAirportOption" runat="server" class="css_text" style="height: 24px; width: 37%;">
                                    <asp:Label ID="labelAirportOption" runat="server" Text="Airport Pickup Point"></asp:Label></td>
                                <td class="css_value" style="height: 24px">
                                    <asp:DropDownList ID="ddlAirportOption" runat="server">
                                        <asp:ListItem Value="MEET & GREET" Selected="True">MEET & GREET</asp:ListItem>
		                                <asp:ListItem Value="OUTSIDE ARRIVALS">OUTSIDE ARRIVALS</asp:ListItem>
                                    </asp:DropDownList>&nbsp;</td>
                            </tr>                   
                            <tr id="trAirpPhone" runat="server" style="display:none">
                                <td runat="server" class="css_text" style="width: 37%">
                                    Passenger Cell Phone</td>
                                <td class="css_value">
                                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr id="trAirpTerminal" runat="server">
                                <td id="tdTerminal" runat="server" class="css_text" style="width: 37%">
                                    <asp:Label ID="labelTerminal" runat="server" Text="Terminal #"></asp:Label></td>
                                <td class="css_value">
                                    <asp:TextBox ID="txtTerminal" runat="server" MaxLength="20"></asp:TextBox>&nbsp;</td>
                            </tr>
                            <tr id="trAirpDirections" runat="server">
                                <td runat="server" class="css_text" style="width: 37%">
                                    Directions</td>
                                <td class="css_value" style="height: 24px">
                                    <asp:TextBox ID="txtAirpDirections" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>
                        
                    </td>
                    <td id="tdFreq" runat="server" valign="top" colspan="2" style="width: 40%"> 
                        <table border="0" style="width: 64%">
                            <tr>
                                <td style="height: 26px;width:100%; background-image:url(Images/frequent_bk.gif);">
                                    <asp:Label ID="lblFrequent" runat="server" CssClass="frequent_font"></asp:Label>
                                    <%--<font class="frequent_font">Frequent Destination</font>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="frequent_value">
                                    <asp:ListBox ID="lstFreq" runat="server" Rows="10" Width="100%"></asp:ListBox></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>