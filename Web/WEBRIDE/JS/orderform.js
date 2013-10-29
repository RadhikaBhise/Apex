var PrefixID = "ctl00_content_";

/****************************************************
 ** Function ReceiptPrint
 ** Description:hide some table where customer not set info
 ** Input:pagetype
 ** Output:
 ** 11/18/04 - Created(jack)
 ** 27/04/06 - Copy (Daniel)
 ****************************************************/
 function ReceiptPrint(pagetype){
    window.print();
}

//## added by joey  11/22/2007
function PaytypeChange(paytype,cardtype,cardname,month,year,cardno)
{
    var ddlPayType,ddlCardType,txtCardName,ddlMonth,ddlYear,txtCardNo
    ddlPayType = document.getElementById(paytype);
    ddlCardType = document.getElementById(cardtype);
    txtCardName = document.getElementById(cardname);
    ddlMonth = document.getElementById(month);
    ddlYear = document.getElementById(year);
    txtCardNo = document.getElementById(cardno);

    if(ddlPayType.options[ddlPayType.selectedIndex].value != '5')
    {
        ddlCardType.disabled = true;
        txtCardName.disabled = true;
        ddlMonth.disabled = true;
        ddlYear.disabled = true;
        txtCardNo.disabled = true;
        ddlCardType.className = 'css_grayed';
        txtCardName.className = 'css_grayed';
        ddlMonth.className = 'css_grayed';
        ddlYear.className = 'css_grayed';
        txtCardNo.className = 'css_grayed';
    }
    else
    {
        ddlCardType.disabled = false;
        txtCardName.disabled = false;
        ddlMonth.disabled = false;
        ddlYear.disabled = false;
        txtCardNo.disabled = false;
        ddlCardType.className = '';
        txtCardName.className = '';
        ddlMonth.className = '';
        ddlYear.className = '';
        txtCardNo.className = '';
    }
}

//## added by joey   11/20/2007
function StateChange(city,state,street)
{
        var labelCity, txtCity, ddlState
       
        txtStreet = document.getElementById(street);
        txtCity = document.getElementById(city);
        ddlState = document.getElementById(state); 
        if (ddlState.selectedIndex > 0)
        {
            var StateType = GetStateType(ddlState.options[ddlState.selectedIndex].value);

            if(StateType==1)
            {
                //##    Boro
                txtCity.value = "";     //ddlState.options[ddlState.selectedIndex].text;    11/20/2007  changed by yang
                txtCity.disabled = true;
                txtCity.className = 'css_grayed';
            }
            else
            {
                //##    OT
                txtStreet.value = "";   //# 11/20/2007  added by yang
                txtCity.value = "";
                txtCity.disabled = false;
                txtCity.className = '';
            }
        }
}
function GetStateType(state)
{
    //##    1: boro     2: ot       3: airport
    var out;

    switch(state)
    {
        case "M":
        case "BK":
        case "BX":
        case "SI":
        //case "QU":    11/20/2007  removed by yang
        case "Manhanttan":
        case "Brooklyn":
        case "Bronx":
        case "Staten Island":
            out = 1;
            break;
        case "CT":
        case "NJ":
        case "PA":
        case "NY":
        case "DC":
            out = 2;
            break;
        case "JFK":
        case "LGA":
        case "EWR":
        case "AI":
        case "PHL":
        case "ISL":
        case "TEB":
        case "HPN":
        case "ISP":
            out = 3;
            break;
        default:
            out = 0;
            break
    }

    return out
}
function load_PU_td(type)
   	{
       if(type == "p"){
   	        if(document.getElementById(PrefixID + "ckPAirport").checked == true){
			 /*document.getElementById(PrefixID + "PAirportrow").style.display='';
			 document.getElementById(PrefixID + "ptr2").style.display='none';
			 document.getElementById(PrefixID + "ptr3").style.display='none';
			 document.getElementById(PrefixID + "ptr4").style.display='none';
			 document.getElementById(PrefixID + "ptr5").style.display='none';
			 document.getElementById(PrefixID + "ptr6").style.display='none';
			 document.getElementById(PrefixID + "ptr7").style.display='none';
             document.getElementById(PrefixID + "ckPAirport").value="1"; */  
            
	        }else if(document.getElementById(PrefixID + "ckPAirport").checked == false){
	            document.getElementById(PrefixID + "PAirportrow").style.display='none';
	            document.getElementById(PrefixID + "ptr2").style.display='';
			    document.getElementById(PrefixID + "ptr3").style.display='';
			    document.getElementById(PrefixID + "ptr4").style.display='';
			    document.getElementById(PrefixID + "ptr5").style.display='';
			    document.getElementById(PrefixID + "ptr6").style.display='';
			    document.getElementById(PrefixID + "ptr7").style.display='';
		        document.getElementById(PrefixID + "ckPAirport").value="0";
		        
		    }
   	    }
   	    if(type == "d"){
			if(document.getElementById(PrefixID + "ckDAirport").checked == true){
			 document.getElementById(PrefixID + "Tr16").style.display='';
			 document.getElementById(PrefixID + "Tr3").style.display='none';
			 document.getElementById(PrefixID + "Tr4").style.display='none';
			 document.getElementById(PrefixID + "Tr5").style.display='none';
			 document.getElementById(PrefixID + "Tr6").style.display='none';
			 document.getElementById(PrefixID + "Tr8").style.display='none';
			 document.getElementById(PrefixID + "Tr99").style.display='none';
			 document.getElementById(PrefixID + "ckDAirport").value="1";
			 
		    }else if(document.getElementById(PrefixID + "ckDAirport").checked == false){
			  document.getElementById(PrefixID + "Tr16").style.display='none';
			  document.getElementById(PrefixID + "Tr3").style.display='';
			  document.getElementById(PrefixID + "Tr4").style.display='';
			  document.getElementById(PrefixID + "Tr5").style.display='';
			  document.getElementById(PrefixID + "Tr6").style.display='';
			  document.getElementById(PrefixID + "Tr8").style.display='';
			  document.getElementById(PrefixID + "Tr99").style.display='';
			  document.getElementById(PrefixID + "ckDAirport").value="0";
			
		    }
		    } 	   
		    
   	}
   	
function Assign_Addr(point,st_name,st_no,x_st,state,city,phone,ext,zip,landmark,direction,type)
{
		var i,bolAirport;
		var IE4 = (document.getElementById) ? 1 : 0;
    
		bolAirport = false;
		var statevalue=document.getElementById(PrefixID + "hidstate").value;
		if(type.toUpperCase() == "D" )
		{
			if(bolAirport == true && document.getElementById(PrefixID + "ckDAirport").checked == false)
			{
				document.getElementById(PrefixID + "ckDAirport").checked = true;
			}else if(bolAirport == false && document.getElementById(PrefixID + "ckDAirport") == true)
			{
				document.getElementById(PrefixID + "ckDAirport").checked = false;
			}
			
			document.getElementById(PrefixID + "txtDStName").value = st_name.toUpperCase();
			document.getElementById(PrefixID + "txtDStNo").value	= st_no;
			document.getElementById(PrefixID + "txtDCross").value	= x_st;
			document.getElementById(PrefixID + "txtDCity").value	= city;
			document.getElementById(PrefixID + "txtDZip").value = zip;
			
			if (state!="")
			{
				document.getElementById(PrefixID + "ddlDState").selectedIndex=1;
				
				for (i=0;i<document.getElementById(PrefixID + "ddlDState").length;i++)
				{
                    if (document.getElementById(PrefixID + "ddlDState").options(i).value==state)
                    {
                        document.getElementById(PrefixID + "ddlDState").selectedIndex=i;
                        break;
                    }
				}
			}
			
			enableControls("d");
			
			try{
			    document.forms[0].ctl00_MainContent_chk_as_directed.checked = false;
			}catch(ex){}
        }
        else if(type.toUpperCase() == "P")
        {
            if(bolAirport == true && document.getElementById(PrefixID + "ckPAirport").checked == false)
            {
                document.getElementById(PrefixID + "ckPAirport").checked = true;
            //	update_state_airport("P");
            }else if(bolAirport == false && document.getElementById(PrefixID + "ckPAirport").checked == true)
            {
                document.getElementById(PrefixID + "ckPAirport").checked = false;
            //				update_state_airport("P");
            }
            
            document.getElementById(PrefixID + "txtPStName").value = st_name.toUpperCase();
            document.getElementById(PrefixID + "txtPStNo").value	= st_no;
            document.getElementById(PrefixID + "txtPCity").value	= city;
            document.getElementById(PrefixID + "txtPZip").value = zip;
            document.getElementById(PrefixID + "txtPPoint").value = point;
            
            if (state!="")
            {
                document.getElementById(PrefixID + "ddlPState").selectedIndex=1;
                for (i=0;i<document.getElementById(PrefixID + "ddlPState").length;i++)
                {
                    if (document.getElementById(PrefixID + "ddlPState").options(i).value==state)
                    {
                        document.getElementById(PrefixID + "ddlPState").selectedIndex=i;
                        break;
                    }
                }
            }
            enableControls("p");
	    }
		//set_validateflag(type);
        if (navigator.appName == "Netscape" && document.layers)
        {
            window.onResize = reloadIt;
        }
}

	
function LoadDefault()
{
 pickup_reset()
 dest_reset() 
 pickup_airport_reset()
 dest_airport_reset() 
 enableControls("p");
 enableControls("d");
}

function pickup_reset()
{
    try{
        document.getElementById(PrefixID + 'ddlPState').selectedIndex=0;
        document.getElementById(PrefixID + 'txtPPoint').value="";
        document.getElementById(PrefixID + 'txtPZip').value="";
        document.getElementById(PrefixID + 'txtPCity').value="";
        document.getElementById(PrefixID + 'txtPStNo').value="";
        document.getElementById(PrefixID + 'txtPStName').value="";
    }catch(ex){}
}

function dest_reset()
{
    try{
        document.getElementById(PrefixID + 'ddlDState').selectedIndex=0;
        document.getElementById(PrefixID + 'txtDZip').value="";
        document.getElementById(PrefixID + 'txtDCity').value="";
        document.getElementById(PrefixID + 'txtDCross').value="";
        document.getElementById(PrefixID + 'txtDStNo').value="";
        document.getElementById(PrefixID + 'txtDStName').value="";
    }catch(ex){}
}

/****************************************************
 ** Function p/u airport reset
 ** Description:clean the p/u airport address
 ** Input:
 ** Output:
 ** 04/11/06 - Created(Daniel)
 ****************************************************/
 function pickup_airport_reset()
 {
    try{
         document.getElementById(PrefixID + 'ddlPAirport').selectedIndex=0;
         document.getElementById(PrefixID + 'txtPAirline').value="";
         document.getElementById(PrefixID + 'txtPFlightNo').value="";
         document.getElementById(PrefixID + 'ddlPAirPoint').value="";
         document.getElementById(PrefixID + 'txtPPhone').value="";
         document.getElementById(PrefixID + 'txtPAirCity').value="";
     }catch(ex){}
 
 
 }

 /****************************************************
 ** Functiondest airport reset
 ** Description:clean the dest airport address
 ** Input:
 ** Output:
 ** 04/11/06 - Created(Daniel)
 ****************************************************/
 function dest_airport_reset()
 {
       try{
         document.getElementById(PrefixID + 'ddlDAirport').selectedIndex=0;
         document.getElementById(PrefixID + 'txtDAirline').value="";
         document.getElementById(PrefixID + 'txtDFlightNo').value="";
         document.getElementById(PrefixID + 'ddlDAirPoint').value="";
         document.getElementById(PrefixID + 'txtDPhone').value="";
         document.getElementById(PrefixID + 'txtDDepartingCity').value="";
       }catch(ex){}
 }


function ValidateCheck(phone){
    //--confirm requestdate 
    //     var d,year,month,day,hour,minute,ampm;
	 d = new Date();
	 year=d.getYear();
	 month=d.getMonth()+1;
	 day=d.getDate();
	 var checkday=day
	 if(checkday<10)
	 {
	 day="0"+day;
	 }
	 hour=d.getHours();
	 minute=d.getMinutes();
	 
	 //##   11/14/2007  changed by yang
	 var ddlDate = document.getElementById(PrefixID + "Calendar1_ddlDate");
	 var ddlHour = document.getElementById(PrefixID + "Calendar1_ddlHour");
	 var ddlMin = document.getElementById(PrefixID + "Calendar1_ddlMinute");
	 var ddlAmPm = document.getElementById(PrefixID + "Calendar1_ddlAmPm");
	 
	 var pagehour=ddlHour.options[ddlHour.selectedIndex].value
	 var pageminute=ddlMin.options[ddlMin.selectedIndex].value
	 var time=(ddlDate.options[ddlDate.selectedIndex].value == month+"/"+day+"/"+year)
	
	var air_phonea=document.getElementById(PrefixID + 'txtPhoneFront').value;
	var air_phone1=document.getElementById(PrefixID + 'txtPhoneTail').value;
	var air_phone2=document.getElementById(PrefixID + 'txtPhoneExt').value;
	var air_phone=air_phonea+air_phone1+air_phone2;
	var flag;

	
	if(document.getElementById(PrefixID + 'ddlPayType').value=="5"){
	    flag=true;
	   } 
	   else
	   {
	   flag=false;
	   }
	
//		if (document.getElementById(PrefixID + 'ddlHour').selectedIndex == 0){
//			alert("Please Select Travel Hour");
//			return false;
//		}
//		else if(document.getElementById(PrefixID + 'ddlMin').selectedIndex == 0){
//			alert("Please Select Travel Minute");
//			return false;
//		}
//		else if(document.getElementById(PrefixID + 'ddlAMPM').selectedIndex == 0){
//			alert("Please Select Travel Date ampm");
//			return false;
//		}
//		else

       if(ddlDate.value ==""){
			alert("Please Select Travel Date");
			return false;
		}
		else if((time==true) && (ddlAmPm.selectedIndex ==1) && ((hour-pagehour-12)==0) && ((pageminute-minute)<10))
		{
		alert("Based on your pick up location, the call could not be completed because the ride time falls within 24 hours from the current time.  Please call " + phone + " immediately for special arrangement of your ride request.");
		return false;
		}
		else if((time==true) && (ddlAmPm.selectedIndex ==0) && ((hour-pagehour)==0) && ((pageminute-minute)<10)){
		alert("Based on your pick up location, the call could not be completed because the ride time falls within 12 hours from the current time.  Please call " + phone + " immediately for special arrangement of your ride request.");
		return false;
		}
		else if((time==true) && (ddlAmPm.selectedIndex ==1) && ((hour-pagehour-12)>0)){
		alert("Based on your pick up location, the call could not be completed because the ride time falls within 24 hours from the current time.  Please call " + phone + " immediately for special arrangement of your ride request.");
		return false;
		}
		else if((time==true) && (ddlAmPm.selectedIndex ==0) && ((hour-pagehour)>0)){
		alert("Based on your pick up location, the call could not be completed because the ride time falls within 12 hours from the current time.  Please call " + phone + " immediately for special arrangement of your ride request.");
		return false;
		}
//		else if(document.getElementById(PrefixID + 'ddlCardType').selectedIndex <>0){
        //## Modified by joey   11/22/2007
		else if(flag && document.getElementById(PrefixID + 'txtCardNo').value.length !=15 && document.getElementById(PrefixID + 'ddlCardType').options[document.getElementById(PrefixID + 'ddlCardType').selectedIndex].innerText == "AMEX"){
			alert("AMEX has 15 digits! Please re-enter.");
			document.getElementById(PrefixID + 'txtCardNo').focus();
			return false;
		}
		else if(flag && document.getElementById(PrefixID + 'txtCardNo').value.length !=16 && document.getElementById(PrefixID + 'ddlCardType').options[document.getElementById(PrefixID + 'ddlCardType').selectedIndex].innerText == "VISA"){
			alert("VISA and MASTERCARD has 16 digits! Please re-enter.");
			document.getElementById(PrefixID + 'txtCardNo').focus();
			return false;
		}
		else if(flag && document.getElementById(PrefixID + 'txtCardNo').value.length !=16 && document.getElementById(PrefixID + 'ddlCardType').options[document.getElementById(PrefixID + 'ddlCardType').selectedIndex].innerText == "MASTERCARD"){
		    alert("MASTERCARD has 16 digits! Please re-enter.");
			document.getElementById(PrefixID + 'txtCardNo').focus();
			return false;
		}	
		else if(flag && document.getElementById(PrefixID + 'txtCardNo').value.length !=15 && document.getElementById(PrefixID + 'ddlCardType').options[document.getElementById(PrefixID + 'ddlCardType').selectedIndex].innerText == "DINERS"){
			alert("DINERS should be 15 digits!");
			document.getElementById(PrefixID + 'txtCardNo').focus();
			return false;
		}
		//## end Modified
		
//		else if(document.getElementById(PrefixID + 'txtCardNo').value.length !=16 && document.getElementById(PrefixID + 'ddlCardType').options[document.getElementById(PrefixID + 'ddlCardType').selectedIndex].innerText != "AMEX" && document.getElementById(PrefixID + 'ddlCardType').options[document.getElementById(PrefixID + 'ddlCardType').selectedIndex].innerText != "DINERS"){
//			alert("Credit Card Number must be 16 digits!");
//			document.getElementById(PrefixID + 'txtCardNo').focus();
//			return false;
//		}

		else if(flag && isNaN(document.getElementById(PrefixID + 'txtCardNo').value)){
			alert("Please enter numeric values as credit card no!");
			document.getElementById(PrefixID + 'txtCardNo').focus();
			return false;
		}
		else if(flag && document.getElementById(PrefixID + 'ddlPayType').selectedIndex != 0 && document.getElementById(PrefixID + 'txtCardNo').value.length > 0 && (document.getElementById(PrefixID + 'ddlMonth').selectedIndex == 0 || document.getElementById(PrefixID + 'ddlYear').selectedIndex == 0 )){
			alert("Please enter the credit card expiration date!");
			if(document.getElementById(PrefixID + 'ddlMonth').selectedIndex == 0){
				document.getElementById(PrefixID + 'ddlMonth').focus();
			}
			else{
				document.getElementById(PrefixID + 'ddlYear').focus();
			}
			return false;
		}
		
		//##    11/21/2007  Modified by yang
		//else if(document.getElementById(PrefixID + 'ddlPayType').selectedIndex != 0 && document.getElementById(PrefixID + 'txtCardNo').value.length > 0 )
		else if(document.getElementById(PrefixID + 'ddlPayType').options[document.getElementById(PrefixID + 'ddlPayType').selectedIndex].text=="Credit Card" && 
		        document.getElementById(PrefixID + 'ddlYear').selectedIndex<=1 && document.getElementById(PrefixID + 'ddlMonth').selectedIndex < month)
		{
            alert("Please enter the valid credit card expiration date!");
            document.getElementById(PrefixID + 'ddlMonth').focus();
            return false
//		    if(document.getElementById(PrefixID + 'ddlYear').options[document.getElementById(PrefixID + 'ddlYear').selectedIndex].value < year)
//		    {
//                alert("Please enter the valid credit card expiration date!");
//			    document.getElementById(PrefixID + 'ddlYear').focus();
//			    return false
//			}

		}
		//##    11/21/2007  End
		//## Modified by joey   11/22/2007  add flag to make sure ddlPayType.selectedvalue = '5'
//		else if(flag && document.getElementById(PrefixID + 'txtCardName').value.length==0){
//		    alert('Please enter a Credit CardName');
//		    document.getElementById(PrefixID + 'txtCardName').focus();
//		    return false;
//		}
     // }
		else if(document.getElementById(PrefixID + 'txtPhoneFront').value == "" || document.getElementById(PrefixID + 'txtPhoneFront').value.length ==0){
			alert("Please Enter a phone area")
			document.getElementById(PrefixID + 'txtPhoneFront').focus();
			return false;
		}
		else if(document.getElementById(PrefixID + 'txtPhoneTail').value == "" || document.getElementById(PrefixID + 'txtPhoneTail').value.length ==0){
			alert("Please Enter first 3-digit Phone Number")
			document.getElementById(PrefixID + 'txtPhoneTail').focus();
			return false;
		}
//		else if(document.getElementById(PrefixID + 'txtPhoneExt').value == "" || document.getElementById(PrefixID + 'txtPhoneExt').value.length ==0){
//			alert("Please Enter last 5-digit Phone Number")
//			document.getElementById(PrefixID + 'txtPhoneExt').focus();
//			return false;
//		}
		else if(isNaN(document.getElementById(PrefixID + 'txtPhoneFront').value))
		{alert("Please Enter only numeric values in  phone area")
			document.getElementById(PrefixID + 'txtPhoneFront').focus();
			return false;
		
		}
		else if(isNaN(document.getElementById(PrefixID + 'txtPhoneTail').value))
		{alert("Please Enter only numeric values in  phone number")
			document.getElementById(PrefixID + 'txtPhoneTail').focus();
			return false;
		
		}
		else if(isNaN(document.getElementById(PrefixID + 'txtPhoneExt').value))
		{alert("Please Enter only numeric values in  phone number")
			document.getElementById(PrefixID + 'txtPhoneExt').focus();
			return false;
		}
		
		else if(document.getElementById(PrefixID + 'txtPhoneFront').value.length!=3 )
		{alert("Primary phone number is incomplete.Please verify primary phone number.");
		document.getElementById(PrefixID + 'txtPhoneFront').focus();
		return false;						      
		}
		else if(document.getElementById(PrefixID + 'txtPhoneTail').value.length!=7)
		{alert("Primary phone number is incomplete.Please verify primary phone number.");
		document.getElementById(PrefixID + 'txtPhoneTail').focus();
		return false;						      
		}
//		else if(document.getElementById(PrefixID + 'txtPhoneExt').value.length!=5)
//		{alert("Primary phone number is incomplete.Please verify primary phone number.");
//		document.getElementById(PrefixID + 'txtPhoneExt').focus();
//		return false;						      
//		}
		else if(document.getElementById(PrefixID + 'txtLastName').value == "" || document.getElementById(PrefixID + 'txtLastName').value.length == 0 ){
			alert("Please enter a passenger last name");
			document.getElementById(PrefixID + 'txtLastName').focus();
			return false;
		}
		else if(document.getElementById(PrefixID + 'txtFirstName').value == "" || document.getElementById(PrefixID + 'txtFirstName').length == 0 ) { 
			alert("Please enter a passenger first name");
			document.getElementById(PrefixID + 'txtFirstName').focus();
			return false;
		}
		else if(document.getElementById(PrefixID + 'txtEmail').value == "" || document.getElementById(PrefixID + 'txtEmail').value.length == 0 ){
			alert("Please enter a email address");
			document.getElementById(PrefixID + 'txtEmail').focus();
			return false;
		}
		
		else if(document.getElementById(PrefixID + 'txtEmail').value.match(/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/)==null)
		{
            alert('Please Enter the Correct Email Address ');
            document.getElementById(PrefixID + 'txtEmail').focus();
            return false;
         }
         
         else if(document.getElementById("comp_id_1") !=null && document.getElementById("comp_id_1").value==""){
             try{
                 alert('Required Company ID fields are incorrect!(In correct fileds are marked with red circles)')
                  document.getElementById("comp_id_1").focus();
                 //document.getElementById("reddot").style.display='';
              }catch(ex){
                 return false;
              }
           
           return false;
         }
         else {
			 	 if(document.getElementById(PrefixID + "ckPAirport").checked == true){
//						 	 var req_date,req_hour,req_min,req_ampm;
//		                        req_date	= document.getElementById(PrefixID + "ddlDate").options[document.getElementById("ddlDate").selectedIndex].value;
//								req_hour	= document.getElementById(PrefixID + "ddlHour").options[document.getElementById("ddlHour").selectedIndex].value;
//								req_min		= document.getElementById(PrefixID + "ddlMin").options[document.getElementById("ddlMin").selectedIndex].value;
//								req_ampm	= document.getElementById(PrefixID + "ddlAMPM").options[document.getElementById("ddlAMPM").selectedIndex].value;
//								time        = req_date +" " + req_hour +":"+req_min +":00 "  + req_ampm
//						 	 if(document.getElementById(PrefixID + "txtPAirTime").value != "" && document.getElementById(PrefixID + "txtPAirTime").value < =time){
//						 	      
//						 	 } 
//								if(document.getElementById(PrefixID + 'ddlPAirport').selectedIndex==0){
//								alert("Please Select the Pickup Airport.");
//								document.Form1.airports1_ddlPAirport.focus();
//									return false;
//							      
//								}
//								else if(document.getElementById(PrefixID + 'txtPAirline').value=="")
//								{alert("Please Select the Pickup Airline.");
//								document.getElementById(PrefixID + '_txtPAirline').focus();
//								return false;
//								}
//								else if(document.getElementById('airports1_txtPairport_flight').value == ""){
//									alert("Please Enter the Pickup Flight Number.");
//									document.Form1.airports1_txtPairport_flight.focus();
//									return false;
//								}
//								if(document.getElementById('airports1_txtPairport_flight').value!="" && document.getElementById('airports1_txtPairport_flight').value!= null)
//	                            {
//									if(isNaN(document.getElementById('airports1_txtPairport_flight').value)){
//										alert("Please enter numeric values as flight number!");
//										document.getElementById('airports1_txtPairport_flight').focus();
//										return false;
//									}
//								}
//								else if(document.Form1.airports1_txtParriving_from.value  == ""){
//									alert("Please Enter the Pickup Arriving From.");
//									document.Form1.airports1_txtParriving_from.focus();
//									return false;
//								}
			     								     
			
					}
				    
				    var ddlPState = document.getElementById(PrefixID + 'ddlPState');
					if(document.getElementById(PrefixID + "ckPAirport").checked == false){
					
					            if(document.getElementById(PrefixID + 'ddlPAirport').selectedIndex==0){
								    if(document.getElementById(PrefixID + 'ddlPState').selectedIndex==0){
									alert("Please Select the Pickup State");	
									document.getElementById(PrefixID + 'ddlPState').focus();
									return false;
									}
									else if (document.getElementById(PrefixID + 'txtPCity').value=="" && GetStateType(ddlPState.options[ddlPState.selectedIndex].value)!=1)
									{alert("Please Enter the Pickup City");
									document.getElementById(PrefixID + 'txtPCity').focus();
									return false;
									}	    
			    					else if(document.getElementById(PrefixID + 'txtPStNo').value == "" || document.getElementById(PrefixID + 'txtPStNo').value.length == 0) {
			    					//## ADDED BY JOEY  11/21/2007
			    					if(GetStateType(ddlPState.options[ddlPState.selectedIndex].value)==1){
									alert("Please Enter the Pickup Street No.");
									document.getElementById(PrefixID + 'txtPStNo').focus();
									return false;
									}
									}else if(isNaN(document.getElementById(PrefixID + 'txtPStNo').value)){
									alert("Please Enter the Numeric only Pickup Street No.");
									document.getElementById(PrefixID + 'txtPStNo').focus();
									return false;	
									}else if(document.getElementById(PrefixID + 'txtPStName').value == "" || document.getElementById(PrefixID + 'txtPStName').value.length == 0){
									alert("Please Enter the Pickup Street Name");
									document.getElementById(PrefixID + 'txtPStName').focus();
									return false;
									}else if(isNaN(document.getElementById(PrefixID + 'txtPZip').value)){
									alert("Please Enter the Numeric only Pickup Zip Code.");
									document.getElementById(PrefixID + 'txtPZip').focus();
									return false;	
									}							      
								}									
									/*else if(document.getElementById('DaytimeVoucherPU1_txtPZipCode').value==""){
									alert("Please Enter the Pickup Zip Code");
									document.Form1.DaytimeVoucherPU1_txtPZipCode.focus();
									return false;
								 	}*/
								 		
								  
												    
							}
					
					if (document.getElementById(PrefixID + "ckDAirport").checked == true)
					{
						if (document.getElementById(PrefixID + 'ddlDAirport').selectedIndex==0)
						{
						    alert("Please Select the Destination Airport");
						    
						    if (document.getElementById(PrefixID + 'ddlDAirport').style.display="")
						        document.getElementById(PrefixID + 'ddlDAirport').focus();
						        
						    return false;
						}
						else if(document.getElementById(PrefixID + "txtDAirline").value=="")
						{
						    alert("Please Select the Destination Airline");
						    
						    if (document.getElementById(PrefixID + 'txtDAirline').style.display="")
						        document.getElementById(PrefixID + 'txtDAirline').focus();
						        
						    return false;
						}
						/*else if(document.getElementById(PrefixID + 'txtDFlightNo').value!="" && document.getElementById(PrefixID + 'txtDFlightNo').value!= null)
						{
					    	//if(isNaN(document.getElementById(PrefixID + 'txtDFlightNo').value)){
								//alert("Please enter numeric values as flight number!");
								//document.getElementById(PrefixID + 'txtDFlightNo').focus();
								//return false;
							//}
						}*/
					}
					
					var ddlDState1 = document.getElementById(PrefixID + 'ddlDState');
				
				    if(ddlDState1!=null && ddlDState1.selectedIndex>=0)
				    {
				        var DStateType1 = GetStateType(ddlDState1.options[ddlDState1.selectedIndex].value);
    					    
					    if (document.getElementById(PrefixID + "ckDAirport").checked == false)
					    {
						    if (document.getElementById(PrefixID + 'ddlDState').selectedIndex==0){
						        alert("Please Select the Destination State");
						        document.getElementById(PrefixID + 'ddlDState').focus();
						        return false;
						    }

						    else if(document.getElementById(PrefixID + 'txtDCity').value=="" && DStateType1 != 1){
						            alert("Please Enter the Destination City");
						            document.getElementById(PrefixID + 'txtDCity').focus();
						            return false;
						    }
						    else if(document.getElementById(PrefixID + 'txtDStNo').value == "" || document.getElementById(PrefixID + 'txtDStNo').value.length == 0){
						        if(DStateType1 == 1){
						            alert("Please Enter the Destination Street No.");
						            document.getElementById(PrefixID + 'txtDStNo').focus();
						            return false;
						        }
						    }
						    else if(isNaN(document.getElementById(PrefixID + 'txtDStNo').value)) {
						        alert("Please Enter the Numeric only Destination Street No.");
						        document.getElementById(PrefixID + 'txtDStNo').focus();
						        return false;
						    }
						    else if(isNaN(document.getElementById(PrefixID + 'txtDZip').value)){
							    alert("Please Enter the Numeric only Destination Zip Code.");
							    document.getElementById(PrefixID + 'txtDZip').focus();
							    return false;	
						    }
			            }
			        }
     }
     var strquery="";
     if(document.getElementById(PrefixID + "ckPAirport").checked == false){
         //pu
            var index;
	        index=document.getElementById(PrefixID + 'ddlPState').selectedIndex
	        var strPState=document.getElementById(PrefixID + 'ddlPState').options[index].value
	        var strPCity=document.getElementById(PrefixID + 'txtPCity').value
	        var strPStrNo=document.getElementById(PrefixID + 'txtPStNo').value
	        var strPStrName=document.getElementById(PrefixID + 'txtPStName').value
	        var strPZip=document.getElementById(PrefixID + 'txtPZip').value
	        var strPType=document.getElementById(PrefixID + 'txtcheckpu').value
	        strquery=strquery+"pstate=" + strPState + "&pcity=" + strPCity + "&pstrno=" + strPStrNo + "&pstrname=" + strPStrName + "&pzip=" + strPZip + "&ptype=" + strPType;
       }
       else{
          strquery=strquery+"&ptype=100"
       }
//	//Dest
	if(document.getElementById(PrefixID + "ckDAirport").checked == false){
	    index=document.getElementById(PrefixID + 'ddlDState').selectedIndex;
	    var strDState=document.getElementById(PrefixID + 'ddlDState').options[index].value
	    var strDCity=document.getElementById(PrefixID + 'txtDCity').value
	    var strDStrNo=document.getElementById(PrefixID + 'txtDStNo').value
	    var strDStrName=document.getElementById(PrefixID + 'txtDStName').value
	    var strDZip=document.getElementById(PrefixID + 'txtDZip').value
	    var strDType=document.getElementById(PrefixID + 'txtcheckdest').value
	    //var strquery="?pstate=" + strPState + "&pcity=" + strPCity + "&pstrno=" + strPStrNo + "&pstrname=" + strPStrName + "&pzip=" + strPZip + "&ptype=" + strPType + "&dstate=" + strDState + "&dcity=" + strDCity + "&dstrno=" + strDStrNo + "&dstrname=" + strDStrName + "&dzip=" + strDZip + "&dtype=" + strDType
          //strquery=strquery+"pstate=" + strPState + "&pcity=" + strPCity + "&pstrno=" + strPStrNo + "&pstrname=" + strPStrName + "&pzip=" + strPZip + "&ptype=" + strPType + "&dstate=" + strDState + "&dcity=" + strDCity + "&dstrno=" + strDStrNo + "&dstrname=" + strDStrName + "&dzip=" + strDZip + "&dtype=" + strDType 
                
//        if (document.getElementById(PrefixID + "chk_as_directed").checked == true)
//        {
//            var strDType="100";
//        }
        
         strquery=strquery+ "&dstate=" + strDState + "&dcity=" + strDCity + "&dstrno=" + strDStrNo + "&dstrname=" + strDStrName + "&dzip=" + strDZip + "&dtype=" + strDType 
     }
     else
     {
         strquery=strquery+"&dtype=100"
     }
    
 //    var strquery="?pstate=" + strPState
//     window.open("verifystreet.aspx?type=b","zip","width=375,height=400");
if(strquery.length>0)
{
  var str=window.showModalDialog('VerifyStreet.aspx?' + strquery,'','dialogHeight: 500px;dialogWidth: 400px;status: no');
}

   //return true;
	if(str=='T' || str=="undefined"){  
	    try{
                 document.getElementById(PrefixID + "hidcomp_id_1").value=document.getElementById("comp_id_1").value;
                 document.getElementById(PrefixID + "hidcomp_id_2").value=document.getElementById("comp_id_2").value;
                 document.getElementById(PrefixID + "hidcomp_id_3").value=document.getElementById("comp_id_3").value;
                 document.getElementById(PrefixID + "hidcomp_id_4").value=document.getElementById("comp_id_4").value;
                 document.getElementById(PrefixID + "hidcomp_id_5").value=document.getElementById("comp_id_5").value;
                 document.getElementById(PrefixID + "hidcomp_id_6").value=document.getElementById("comp_id_6").value;	
	    }catch(ex){
                return true;	
	    }	
	  return true;
	}
     else{
        return false;
	}

}		
function AgentValidate()
{
    //--confirm requestdate 
    //     var d,year,month,day,hour,minute,ampm;
    /*
	 d = new Date();
	 year=d.getYear();
	 month=d.getMonth()+1;
	 day=d.getDate();
	 var checkday=day
	 if(checkday<10)
	 {
	 day="0"+day;
	 }
	 hour=d.getHours();
	 minute=d.getMinutes();
	 var pagehour=document.getElementById(PrefixID + 'ddlHour').options[document.getElementById(PrefixID + 'ddlHour').selectedIndex].value
	 var pageminute=document.getElementById(PrefixID + 'ddlMin').options[document.getElementById(PrefixID + 'ddlMin').selectedIndex].value
	 var time=(document.getElementById(PrefixID + 'ddlDate').value ==month+"/"+day+"/"+year)
	
	var air_phonea=document.getElementById(PrefixID + 'txtPhoneFront').value;
	var air_phone1=document.getElementById(PrefixID + 'txtPhoneTail').value;
	var air_phone2=document.getElementById(PrefixID + 'txtPhoneExt').value;
	var air_phone=air_phonea+air_phone1+air_phone2;
	
       if(document.getElementById(PrefixID + 'ddlDate').value ==""){
			alert("Please Select Travel Date");
			return false;
		}
		else if(document.getElementById(PrefixID + 'ddlAMPM').selectedIndex ==-0){
		alert("Please select AM or PM!");
		return false;
		}
		else if((time==true) && (document.getElementById(PrefixID + 'ddlAMPM').selectedIndex ==2) && ((hour-pagehour-12)==0) && ((pageminute-minute)<10))
		{
		alert("The time is not at a permitted time");
		return false;
		}
		else if((time==true) && (document.getElementById(PrefixID + 'ddlAMPM').selectedIndex ==1) && ((hour-pagehour)==0) && ((pageminute-minute)<10)){
		alert("The time is not at a permitted time");
		return false;
		}
		else if((time==true) && (document.getElementById(PrefixID + 'ddlAMPM').selectedIndex ==2) && ((hour-pagehour-12)>0)){
		alert("The time is not at a permitted time");
		return false;
		}
		else if((time==true) && (document.getElementById(PrefixID + 'ddlAMPM').selectedIndex ==1) && ((hour-pagehour)>0)){
		alert("The time is not at a permitted time");
		return false;
		}
		else if(document.getElementById(PrefixID + 'txtPhoneFront').value == "" || document.getElementById(PrefixID + 'txtPhoneFront').value.length ==0){
			alert("Please Enter a phone area")
			document.getElementById(PrefixID + 'txtPhoneFront').focus();
			return false;
		}
		else if(document.getElementById(PrefixID + 'txtPhoneTail').value == "" || document.getElementById(PrefixID + 'txtPhoneTail').value.length ==0){
			alert("Please Enter first 3-digit Phone Number")
			document.getElementById(PrefixID + 'txtPhoneTail').focus();
			return false;
		}
		else if(isNaN(document.getElementById(PrefixID + 'txtPhoneFront').value))
		{alert("Please Enter only numeric values in  phone area")
			document.getElementById(PrefixID + 'txtPhoneFront').focus();
			return false;
		
		}
		else if(isNaN(document.getElementById(PrefixID + 'txtPhoneTail').value))
		{alert("Please Enter only numeric values in  phone number")
			document.getElementById(PrefixID + 'txtPhoneTail').focus();
			return false;
		
		}
		else if(isNaN(document.getElementById(PrefixID + 'txtPhoneExt').value))
		{alert("Please Enter only numeric values in  phone number")
			document.getElementById(PrefixID + 'txtPhoneExt').focus();
			return false;
		}
		
		else if(document.getElementById(PrefixID + 'txtPhoneFront').value.length!=3 )
		{alert("Primary phone number is incomplete.Please verify primary phone number.");
		document.getElementById(PrefixID + 'txtPhoneFront').focus();
		return false;						      
		}
		else if(document.getElementById(PrefixID + 'txtPhoneTail').value.length!=7)
		{alert("Primary phone number is incomplete.Please verify primary phone number.");
		document.getElementById(PrefixID + 'txtPhoneTail').focus();
		return false;						      
		}
		else if(document.getElementById(PrefixID + 'txtLastName').value == "" || document.getElementById(PrefixID + 'txtLastName').value.length == 0 ){
			alert("Please enter a passenger last name");
			document.getElementById(PrefixID + 'txtLastName').focus();
			return false;
		}
		else if(document.getElementById(PrefixID + 'txtFirstName').value == "" || document.getElementById(PrefixID + 'txtFirstName').length == 0 ) { 
			alert("Please enter a passenger first name");
			document.getElementById(PrefixID + 'txtFirstName').focus();
			return false;
		}
		else if(document.getElementById(PrefixID + 'txtEmail').value == "" || document.getElementById(PrefixID + 'txtEmail').value.length == 0 ){
			alert("Please enter a email address");
			document.getElementById(PrefixID + 'txtEmail').focus();
			return false;
		}*/
		 //else if(document.getElementById(PrefixID + 'txtEmail').value.match(/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/)==null)
		//{
        //  alert('Please Enter the Correct Email Address ');
        //  document.getElementById(PrefixID + 'txtEmail').focus();
        //   return false;
        // }
         /*else if(document.getElementById("comp_id_1") !=null && document.getElementById("comp_id_1").value==""){
         
         alert('Required Company ID fields are incorrect!(In correct fileds are marked with red circles)')
         //document.getElementById("reddot").style.display='';
         document.getElementById("comp_id_1").focus();
         return false;
              }
         else {
						 	 if(document.getElementById(PrefixID + "ckPAirport").checked == true){
								if(document.getElementById(PrefixID + 'ddlPAirport').selectedIndex==0){
								alert("Please Select the Pickup Airport.");
								document.Form1.airports1_ddlPAirport.focus();
									return false;
							      
								}
								else if(document.getElementById(PrefixID + 'txtPAirline').value=="")
								{alert("Please Select the Pickup Airline.");
								document.getElementById(PrefixID + '_txtPAirline').focus();
								return false;
								}

						     								     
						
					}
				    
				  
					if(document.getElementById(PrefixID + "ckPAirport").checked == false){
									if(document.getElementById(PrefixID + 'ddlPState').selectedIndex==0){
									alert("Please Select the Pickup State");	
									document.getElementById(PrefixID + 'ddlPState').focus();
									return false;
									}
									else if (document.getElementById(PrefixID + 'txtPCity').value=="")	
									{alert("Please Enter the Pickup City");
									document.getElementById(PrefixID + 'txtPCity').focus();
									return false;
									}	    
			    					else if(document.getElementById(PrefixID + 'txtPStNo').value == "" || document.getElementById(PrefixID + 'txtPStNo').value.length == 0) {
									alert("Please Enter the Pickup Street No.");
									document.getElementById(PrefixID + 'txtPStNo').focus();
									return false;
									}else if(isNaN(document.getElementById(PrefixID + 'txtPStNo').value)){
									alert("Please Enter the Numeric only Pickup Street No.");
									document.getElementById(PrefixID + 'txtPStNo').focus();
									return false;	
									}else if(document.getElementById(PrefixID + 'txtPStName').value == "" || document.getElementById(PrefixID + 'txtPStName').value.length == 0){
									alert("Please Enter the Pickup Street Name");
									document.getElementById(PrefixID + 'txtPStName').focus();
									return false;
									}else if(isNaN(document.getElementById(PrefixID + 'txtPZip').value)){
									alert("Please Enter the Numeric only Pickup Zip Code.");
									document.getElementById(PrefixID + 'txtPZip').focus();
									return false;	
									}		    
							}
					if (document.getElementById(PrefixID + "ckDAirport").checked == true){
					
										if (document.getElementById(PrefixID + 'ddlDAirport').selectedIndex==0){
										alert("Please Select the Destination Airport");	
										document.getElementById(PrefixID + 'ddlDAirport').focus();
										return false;
										}
					}
					if (document.getElementById(PrefixID + "ckDAirport").checked == false){
							if (document.getElementById(PrefixID + 'ddlDState').selectedIndex==0){
							alert("Please Select the Destination State");
							document.getElementById(PrefixID + 'ddlDState').focus();
							return false;
							}else if(document.getElementById(PrefixID + 'txtDCity').value==""){
							alert("Please Enter the Destination City");
							document.getElementById(PrefixID + 'txtDCity').focus();
							return false;
							}else if(isNaN(document.getElementById(PrefixID + 'txtDStNo').value)) {
											alert("Please Enter the Numeric only Destination Street No.");
											document.getElementById(PrefixID + 'txtDStNo').focus();
											return false;
							}else if(isNaN(document.getElementById(PrefixID + 'txtDZip').value)){
									alert("Please Enter the Numeric only Destination Zip Code.");
									document.getElementById(PrefixID + 'txtDZip').focus();
									return false;	
									}     
					    
					}	
     }
     
         //---------------------------pu
            var index;
	        index=document.getElementById(PrefixID + 'ddlPState').selectedIndex;
	        if(index>=0){
	            var strPState=document.getElementById(PrefixID + 'ddlPState').options[index].value;
	        }
	        else
	        {
	            var strPState="";
	        }
	        
	       
	        var strPCity=document.getElementById(PrefixID + 'txtPCity').value;
	        var strPStrNo=document.getElementById(PrefixID + 'txtPStNo').value;
	        var strPStrName=document.getElementById(PrefixID + 'txtPStName').value;
	        var strPZip=document.getElementById(PrefixID + 'txtPZip').value;
	        
	        if(document.getElementById(PrefixID + "ckPAirport").checked == false){
	            var strPType="0";
	        }
	        else{
	             var strPType="1"
	        }
	       
;
	//------------------------Dest

	index=document.getElementById(PrefixID + 'ddlDState').selectedIndex;
	if(index>=0){
	     var strDState=document.getElementById(PrefixID + 'ddlDState').options[index].value;      
    }
    else
    {
       var strDState="";
    }
	
	var strDCity=document.getElementById(PrefixID + 'txtDCity').value;
	var strDStrNo=document.getElementById(PrefixID + 'txtDStNo').value;
	var strDStrName=document.getElementById(PrefixID + 'txtDStName').value;
	var strDZip=document.getElementById(PrefixID + 'txtDZip').value;
	
	if(document.getElementById(PrefixID + "ckDAirport").checked == false){
	    var strDType="0";
	}
	else{
	    var strDType="1";
	}
 
	
	var strquery="?pstate=" + strPState + "&pcity=" + strPCity + "&pstrno=" + strPStrNo + "&pstrname=" + strPStrName + "&pzip=" + strPZip + "&ptype=" + strPType + "&dstate=" + strDState + "&dcity=" + strDCity + "&dstrno=" + strDStrNo + "&dstrname=" + strDStrName + "&dzip=" + strDZip + "&dtype=" + strDType

    var str=window.showModalDialog('VerifyStreet.aspx' + strquery,'','dialogHeight: 400px;dialogWidth: 470px;status: no');

//alert(strPType+strDType);
	if(str=='T'  || str=='undefined')  
				{
	            try{
                         document.getElementById(PrefixID + "hidcomp_id_1").value=document.getElementById("comp_id_1").value;
                         document.getElementById(PrefixID + "hidcomp_id_2").value=document.getElementById("comp_id_2").value;
                         document.getElementById(PrefixID + "hidcomp_id_3").value=document.getElementById("comp_id_3").value;
                         document.getElementById(PrefixID + "hidcomp_id_4").value=document.getElementById("comp_id_4").value;
                         document.getElementById(PrefixID + "hidcomp_id_5").value=document.getElementById("comp_id_5").value;
                         document.getElementById(PrefixID + "hidcomp_id_6").value=document.getElementById("comp_id_6").value;	
	            }catch(ex){
                        return true;	
	            }				
				return true;
				}
			else
				{
				
				return false;             
				}*/
}		

function check_search_max_length()
{ 
//if (document.getElementById(PrefixID + 'ddlCardType').selectedIndex==0)
//{alert('Please select the credit card type');
//document.getElementById(PrefixID + 'ddlCardType').focus();
//}

  var checkcardtype=document.getElementById(PrefixID + 'ddlCardType').options[document.getElementById(PrefixID + 'ddlCardType').selectedIndex].value

  if (checkcardtype==1)
  {
	document.getElementById(PrefixID + 'txtCardNo').maxLength=15;
  }
  if (checkcardtype==3)
  {
	document.getElementById(PrefixID + 'txtCardNo').maxLength=15;    //## set maxLength 14->15   11/22/2007  joey
  }
  //if (checkpayment==5&&(checkcardtype==2||checkcardtype==4||checkcardtype==5||checkcardtype==6))
  if (checkcardtype==2||checkcardtype==4||checkcardtype==5||checkcardtype==6)
  {
    document.getElementById(PrefixID + 'txtCardNo').maxLength=16;
  }
        
     
}
function citylookup(type)
{
    var borough,city
    if (type=='p' || type=='P')
    {
        borough=document.getElementById(PrefixID + 'ddlPState').value;
        city=document.getElementById(PrefixID + 'txtPCity').value;
        
        if (borough=='')
        {
            alert("Please Select A State");
            document.getElementById(PrefixID + 'ddlPState').focus;
            return false;
        }
        else if(city=='' || city.length <3)
        {
            alert("Please enter at least 3 characters in the city field!");
            document.getElementById(PrefixID + 'txtPCity').focus;
            return false;
        }
    }
    else
    {
        borough=document.getElementById(PrefixID + 'ddlDState').value;
        city=document.getElementById(PrefixID + 'txtDCity').value;
        if (borough=='')
        {
            alert("Please Select A State");
            document.getElementById(PrefixID + 'ddlDState').focus;
            return false;
        }
        else if(city=='' || city.length <3)
        {
            alert("Please enter at least 3 characters in the city field!");
            document.getElementById(PrefixID + 'txtDCity').focus;
            return false;
        }
    }
	window.open('citylookup.aspx?type='+type + '&city='+city+'&state='+borough,'city','width=400,height=420,scrollbars=1');
}

function city(city,type){
			if(type == "P" || type=="p") {
			self.opener.document.getElementById(PrefixID + 'txtPCity').value = city;
					}
		else if(type=="D" || type=="d"){
						self.opener.document.getElementById(PrefixID + 'txtDCity').value =city;
						}
						window.close();
}

function streetlookup(type){
	var borough,city,st_name,ind,st_name,st_no;

	if(type == "p" || type == "P")
	{
		ind = document.getElementById(PrefixID + 'ddlPState').selectedIndex;
		if(ind>=0)
		{
			borough = document.getElementById(PrefixID + 'ddlPState').options[ind].value;
		}
		else
		{
			borough='';
		}
		//## get city when is boro  11/22/2007  joey
		if(GetStateType(borough)==1)
		{
		    city = document.getElementById(PrefixID + 'ddlPState').options[ind].text;
		}
		else
		{
		    city=document.getElementById(PrefixID + 'txtPCity').value;
		}
		st_name = document.getElementById(PrefixID + 'txtPStName').value;
		st_no=document.getElementById(PrefixID + 'txtPStNo').value;
	}
	else if(type == "d" || type == "D")
	{
		ind = document.getElementById(PrefixID + 'ddlDState').selectedIndex;
		if(ind>=0)
		{
			borough = document.getElementById(PrefixID + 'ddlDState').options[ind].value;
		}
		else
		{
			borough='';
		}
		//## get city when is boro  11/22/2007  joey
		if(GetStateType(borough)==1)
		{
		    city = document.getElementById(PrefixID + 'ddlDState').options[ind].text;
		}
		else
		{
		    city=document.getElementById(PrefixID + 'txtDCity').value;
		}

		
		st_name = document.getElementById(PrefixID + 'txtDStName').value;
		st_no=document.getElementById(PrefixID + 'txtDStNo').value;
	}
//	else if (type == "s" || type=="S"){
//		ind=document.getElementById('ddlSState').selectedIndex;
//		borough=document.getElementById('ddlSState').options[ind].value;
//		city=document.getElementById('txtSCity').value;
//		st_name=document.getElementById('txtSStrName').value;
//	}
	
	
	if(borough=='')
	{
		alert('Please Select A State');
	}
	else if(city=='' && GetStateType(borough)!=1)
	{
		alert('Please input A City');
	}
	else
	{
		if(st_name.length >= 3){
			window.open('streetlookup.aspx?type='+type+'&stname='+st_name+'&state='+borough+'&city='+city+'&stno='+st_no+'','street','width=375,height=400,scrollbars=1');
		} else {
			alert("Please enter at least 3 characters in the street name field!");
		}
	}
}

 /****************************************************
 ** Function street_name
 ** Description:StreetNameLookUp 
 ** Input:
 ** Output:
 ** 4/12/06 - Copy (Daniel)
 ****************************************************/
function street_name(st_name,type,city,zip_code,x_st,county){
	try{
		if(type == "P" || type=="p") {
			//alert(""+st_name+" ");
			self.opener.document.getElementById(PrefixID + 'txtPStName').value = st_name;
			self.opener.document.getElementById(PrefixID + 'txtPCity').value = city;
			//self.opener.document.getElementById(PrefixID + 'txtPZip').value =zip_code;
			//self.opener.document.getElementById('txtPStrCross').value=x_st;
			//self.opener.document.getElementById(PrefixID + 'ddlPState').value=county;  11/21/2007 disabled by yang
		}
		else if(type=="D" || type=="d"){
			self.opener.document.getElementById(PrefixID + 'txtDStName').value = st_name;
			self.opener.document.getElementById(PrefixID + 'txtDCity').value =city;
			//self.opener.document.getElementById(PrefixID + 'txtDZip').value = zip_code;
			self.opener.document.getElementById(PrefixID + 'txtDCross').value = x_st;
			//self.opener.document.getElementById(PrefixID + 'ddlDState').value = county;    11/21/2007 disabled by yang
		}
//		else if(type=="s" || type=="S"){
//			self.opener.document.forms[0].txtSStrName.value=st_name;
//			self.opener.document.forms[0].txtSCity.value=city;
//			self.opener.document.forms[0].txtSZip.value=zip_code;
//			self.opener.document.forms[0].txtSStrCross.value=x_st;
//		}
		/*else if(type=="B" || type=="b"){
			self.opener.document.forms[0].txtStName.value = st_name;
		}
		else if(type=="A" || type=="a"){
			self.opener.document.forms[0].DStrName.value = st_name;
		}*/
	}
	catch(e)
	{
		try{
			if(type == "P") {
				self.opener.document.getElementById(PrefixID + 'txtPStName').value = st_name;
			self.opener.document.getElementById(PrefixID + 'txtPCity').value = city;
			self.opener.document.getElementById(PrefixID + 'txtPZip').value =zip_code;
			//self.opener.document.getElementById('txtPStrCross').value=x_st;
			//self.opener.document.getElementById(PrefixID + 'ddlPState').value=county;  11/21/2007 disabled by yang
			}
			else if(type=="D"){
				self.opener.document.getElementById(PrefixID + 'txtDStName').value = st_name;
			self.opener.document.getElementById(PrefixID + 'txtDCity').value =city;
			self.opener.document.getElementById(PrefixID + 'txtDZip').value = zip_code;
			self.opener.document.getElementById(PrefixID + 'txtDCross').value = x_st;
			//self.opener.document.getElementById(PrefixID + 'ddlDState').value = county;    11/21/2007 disabled by yang
			}
//			else if(type=="s" || type =="S"){
//				self.opener.document.forms[0].SStrName.value=st_name;
//				self.opener.document.forms[0].SCity.value=city;
//				self.opener.document.forms[0].txtSZip.value=zip_code;
//				self.opener.document.forms[0].txtSStrCross.value=x_st;
//			}
			//else if(type=="B"){
				//self.opener.document.forms[0].PStrName.value = st_name;
			//}
					alert("Finished From Catch!!!");
			}
			catch(e)
			{
				// Source Code: Red Top
				// 2005-08-29
				/****************************************************
				** Function street_name
				** Description:StreetNameLookUp 
				** Input:
				** Output:
				** 11/16/04 - Created(eJay)
				****************************************************/
				try{
					if(type == "P" || type=="p") {
						//alert(""+st_name+" ");
						self.opener.document.getElementById(PrefixID + 'txtPStName').value = st_name;
			self.opener.document.getElementById(PrefixID + 'txtPCity').value = city;
			self.opener.document.getElementById(PrefixID + 'txtPZip').value =zip_code;
			//self.opener.document.getElementById('txtPStrCross').value=x_st;
			//self.opener.document.getElementById(PrefixID + 'ddlPState').value=county;  11/21/2007 disabled by yang
					}
					else if(type=="D" || type=="d"){
						self.opener.document.getElementById(PrefixID + 'txtDStName').value = st_name;
			            self.opener.document.getElementById(PrefixID + 'txtDCity').value =city;
			            self.opener.document.getElementById(PrefixID + 'txtDZip').value = zip_code;
			            self.opener.document.getElementById(PrefixID + 'txtDCross').value = x_st;
			            //self.opener.document.getElementById(PrefixID + 'ddlDState').value = county;    11/21/2007 disabled by yang
					}
//					else if(type=="s" || type=="S"){
//						self.opener.document.forms[0].txtSStrName.value=st_name;
//						self.opener.document.forms[0].txtSCity.value=city;
//						self.opener.document.forms[0].txtSZip.value=zip_code;
//						//self.opener.document.forms[0].txtSStrCross.value=x_st;
//					}
					/*else if(type=="B" || type=="b"){
						self.opener.document.forms[0].txtStName.value = st_name;
					}
					else if(type=="A" || type=="a"){
						self.opener.document.forms[0].DStrName.value = st_name;
					}*/
				}catch(e)
				{
					if(type == "P") {
						self.opener.document.getElementById(PrefixID + 'txtPStName').value = st_name;
			self.opener.document.getElementById(PrefixID + 'txtPCity').value = city;
			self.opener.document.getElementById(PrefixID + 'txtPZip').value =zip_code;
			//self.opener.document.getElementById('txtPStrCross').value=x_st;
			//self.opener.document.getElementById(PrefixID + 'ddlPState').value=county;  11/21/2007 disabled by yang
						//self.opener.document.forms[0].ctl00_MainContent_ctl00_MainContent_ddlPState.value=county;
					}
					else if(type=="D"){
						self.opener.document.getElementById(PrefixID + 'txtDStName').value = st_name;
			            self.opener.document.getElementById(PrefixID + 'txtDCity').value =city;
			            self.opener.document.getElementById(PrefixID + 'txtDZip').value = zip_code;
			            self.opener.document.getElementById(PrefixID + 'txtDCross').value = x_st;
			            //self.opener.document.getElementById(PrefixID + 'ddlDState').value = county;    11/21/2007 disabled by yang
						//self.opener.document.forms[0].ctl00_MainContent_ctl00_MainContent_ddlDState.value = county;
					}
//					else if(type=="s" || type =="S"){
//						self.opener.document.forms[0].SStrName.value=st_name;
//						self.opener.document.forms[0].SCity.value=city;
//						self.opener.document.forms[0].txtSZip.value=zip_code;
//						self.opener.document.forms[0].txtSStrCross.value=x_st;
//					}
				}
			}
	}
	window.close();
}

    function display_airport_detail(type)
    {
        var airport,airport_name,airline,flight,terminal,comment,fbo_address,fbo_name,time,pu_point
        if (type.toLowerCase() == 'p')
        {
            airport=document.getElementById(PrefixID + 'ddlPAirport').value;
            airport_name=document.getElementById(PrefixID + 'txtPCity').value;
            airline=document.getElementById(PrefixID + "txtPAirline").value;
            flight=document.getElementById(PrefixID + "txtPFlightNo").value;
            terminal=document.getElementById(PrefixID + "txtPFbo").value;
            fbo_name=document.getElementById(PrefixID + "txtPFboName").value;
            fbo_address=document.getElementById(PrefixID + "txtPFboAddress").value;
            pu_point=document.getElementById(PrefixID + "txtPAirPoint").value;
            airtime = document.getElementById(PrefixID + "txtPAirTime").value;
            
            if(document.getElementById(PrefixID + 'ckPAirport').checked == false ) 
            {
                //enableControls('p');
                alert('This feature is for airport rides only.'); 
            }else{
                window.open('airport_detail_2.aspx?type=p&code='+airport + '&name='+airport_name+
                        '&airline='+airline+'&flight='+flight+'&terminal='+terminal+'&fbo_name='+fbo_name+
                        '&fbo_address='+fbo_address+'&pu_point='+pu_point+"&airtime="+airtime,
                        'airport_new','width=450,height=450,scrollbars=1');
            }
        }
        else
        {
            airport=document.getElementById(PrefixID + 'ddlDAirport').value;
            airport_name=document.getElementById(PrefixID + 'txtDCity').value;
            airline=document.getElementById(PrefixID + "txtDAirline").value;
            flight=document.getElementById(PrefixID + "txtDFlightNo").value;
            terminal=document.getElementById(PrefixID + "txtDFbo").value;
            fbo_name=document.getElementById(PrefixID + "txtDFboName").value;
            fbo_address=document.getElementById(PrefixID + "txtDFboAddress").value;
            comment=document.getElementById(PrefixID + "txtDDepartingCity").value;
            airtime = document.getElementById(PrefixID + "txtDAirTime").value;
            
            if(document.getElementById(PrefixID + 'ckDAirport').checked == false ) 
            {
                // enableControls('d');
                alert('This feature is for airport rides only.');
            }else{
                window.open('airport_detail_2.aspx?type=d&code='+airport + '&name='+airport_name+
                        '&airline='+airline+'&flight='+flight+'&terminal='+terminal+'&fbo_name='+fbo_name+
                        '&fbo_address='+fbo_address+'&comment='+comment+"&airtime="+airtime,
                        'airport_new','width=450,height=450,scrollbars=1');
            }
        }
    }

	function enableControls(flag)
	{
	    //##    11/21/2007  Modified by yang
        var ckAirport = document.getElementById(PrefixID + "ck" + flag.toUpperCase() + "Airport");
	    var txtCity = document.getElementById(PrefixID + "txt" + flag.toUpperCase() + "City");
	    var txtStNo = document.getElementById(PrefixID + "txt" + flag.toUpperCase() + "StNo");
	    var txtStName = document.getElementById(PrefixID + "txt" + flag.toUpperCase() + "StName");
	    var txtZip = document.getElementById(PrefixID + "txt" + flag.toUpperCase() + "Zip");
	    var txtPoint = document.getElementById(PrefixID + "txt" + flag.toUpperCase() + "Point");
	    var txtCross = document.getElementById(PrefixID + "txt" + flag.toUpperCase() + "Cross");
	    
	    if (ckAirport!=null)
	        ckAirport.checked = false;
	    if (txtCity!=null)
	    {
	        txtCity.className="";
	        txtCity.disabled = false;
	        //txtCity.value = "";
	    }
	    if (txtStNo!=null)
	    {
	        txtStNo.className="";
	        txtStNo.disabled = false;
	        //txtStNo.value = "";
	    }
	    if (txtStName!=null)
	    {
	        txtStName.className="";
	        txtStName.disabled = false;
	        //txtStName.value = "";
	    }
	    if (txtZip!=null)
	    {
	        txtZip.className="";
	        txtZip.disabled = false;
	        //txtZip.value = "";
	    }
	    if (txtPoint!=null)
	    {
	        txtPoint.className="";
	        txtPoint.disabled = false;
	        //txtPoint.value = "";
	    }
	    if (txtCross!=null)
	    {
	        txtCross.className="";
	        txtCross.disabled = false;
	        //txtCross.value = "";
	    }
	    	    
	    /*
	   if(flag=="p" || flag=="P"){
	        document.getElementById(PrefixID + 'ckPAirport').checked = false;
	        document.getElementById(PrefixID + "txtPCity").disabled=false;
	        document.getElementById(PrefixID + "txtPCity").style.backgroundColor = 'white';
	        //document.getElementById(PrefixID + "txtPCity").value="";
	        document.getElementById(PrefixID + "txtPStNo").disabled=false;
	        document.getElementById(PrefixID + "txtPStNo").style.backgroundColor = 'white';
	        //document.getElementById(PrefixID + "txtPStNo").value="";
	        document.getElementById(PrefixID + "txtPStName").disabled=false;
	        document.getElementById(PrefixID + "txtPStName").style.backgroundColor = 'white';
	        //document.getElementById(PrefixID + "txtPStName").value="";
	        document.getElementById(PrefixID + "txtPZip").disabled=false;
	        document.getElementById(PrefixID + "txtPZip").style.backgroundColor = 'white';
	        //document.getElementById(PrefixID + "txtPZip").value="";
	        document.getElementById(PrefixID + "txtPPoint").disabled=false;
	        document.getElementById(PrefixID + "txtPPoint").style.backgroundColor = 'white';
	        //document.getElementById(PrefixID + "txtPPoint").value="";
	   }
	   else{
	        document.getElementById(PrefixID + 'ckDAirport').checked = false;
	        document.getElementById(PrefixID + "txtDCity").disabled=false;
	        document.getElementById(PrefixID + "txtDCity").style.backgroundColor = 'white';
	        //document.getElementById(PrefixID + "txtDCity").value="";
	        document.getElementById(PrefixID + "txtDStNo").disabled=false;
	        document.getElementById(PrefixID + "txtDStNo").style.backgroundColor = 'white';
	        //document.getElementById(PrefixID + "txtPPoint").value="";
	        document.getElementById(PrefixID + "txtDStName").disabled=false;
	        document.getElementById(PrefixID + "txtDStName").style.backgroundColor = 'white';
	        //document.getElementById(PrefixID + "txtDStName").value="";
	        document.getElementById(PrefixID + "txtDZip").disabled=false;
	        document.getElementById(PrefixID + "txtDZip").style.backgroundColor = 'white';
	        //document.getElementById(PrefixID + "txtDZip").value="";
	        document.getElementById(PrefixID + "txtDCross").disabled=false;
	        document.getElementById(PrefixID + "txtDCross").style.backgroundColor = 'white';
	        //document.getElementById(PrefixID + "txtDCross").value="";
	   }*/
	}
	
	function setenableControls(flag)
	{
	
	    //##    11/21/2007  modified by yang
	    var ckAirport = document.getElementById(PrefixID + "ck" + flag.toUpperCase() + "Airport");
	    var txtCity = document.getElementById(PrefixID + "txt" + flag.toUpperCase() + "City");
	    var txtStNo = document.getElementById(PrefixID + "txt" + flag.toUpperCase() + "StNo");
	    var txtStName = document.getElementById(PrefixID + "txt" + flag.toUpperCase() + "StName");
	    var txtZip = document.getElementById(PrefixID + "txt" + flag.toUpperCase() + "Zip");
	    var txtPoint = document.getElementById(PrefixID + "txt" + flag.toUpperCase() + "Point");
	    var txtCross = document.getElementById(PrefixID + "txt" + flag.toUpperCase() + "Cross");
	    
	    if (ckAirport!=null)
	        ckAirport.checked = true;
	    if (txtCity!=null)
	    {
	        txtCity.className="css_grayed";
	        txtCity.disabled = true;
	        txtCity.value = "";
	    }
	    if (txtStNo!=null)
	    {
	        txtStNo.className="css_grayed";
	        txtStNo.disabled = true;
	        txtStNo.value = "";
	    }
	    if (txtStName!=null)
	    {
	        txtStName.className="css_grayed";
	        txtStName.disabled = true;
	        txtStName.value = "";
	    }
	    if (txtZip!=null)
	    {
	        txtZip.className="css_grayed";
	        txtZip.disabled = true;
	        txtZip.value = "";
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
	        txtCross.value = "";
	    }
	    
	    /*
	   if(flag=="p" || flag=="P"){
	        document.getElementById(PrefixID + 'ckPAirport').checked = true;
	        document.getElementById(PrefixID + "txtPCity").disabled=true;
	        document.getElementById(PrefixID + "txtPCity").style.backgroundColor = 'lightgrey';
	        document.getElementById(PrefixID + "txtPCity").value="";
	        document.getElementById(PrefixID + "txtPStNo").disabled=true;
	        document.getElementById(PrefixID + "txtPStNo").style.backgroundColor = 'lightgrey';
	        document.getElementById(PrefixID + "txtPStNo").value="";
	        document.getElementById(PrefixID + "txtPStName").disabled=true;
	        document.getElementById(PrefixID + "txtPStName").style.backgroundColor = 'lightgrey';
	        document.getElementById(PrefixID + "txtPStName").value="";
	        document.getElementById(PrefixID + "txtPZip").disabled=true;
	        document.getElementById(PrefixID + "txtPZip").style.backgroundColor = 'lightgrey';
	        document.getElementById(PrefixID + "txtPZip").value="";
	        document.getElementById(PrefixID + "txtPPoint").disabled=true;
	        document.getElementById(PrefixID + "txtPPoint").style.backgroundColor = 'lightgrey';
	        document.getElementById(PrefixID + "txtPPoint").value="";
	   }
	   else{
	        document.getElementById(PrefixID + 'ckDAirport').checked = true;
	        document.getElementById(PrefixID + "txtDCity").disabled=true;
	        document.getElementById(PrefixID + "txtDCity").style.backgroundColor = 'lightgrey';
	        document.getElementById(PrefixID + "txtDCity").value="";
	        document.getElementById(PrefixID + "txtDStNo").disabled=true;
	        document.getElementById(PrefixID + "txtDStNo").style.backgroundColor = 'lightgrey';
	        document.getElementById(PrefixID + "txtPPoint").value="";
	        document.getElementById(PrefixID + "txtDStName").disabled=true;
	        document.getElementById(PrefixID + "txtDStName").style.backgroundColor = 'lightgrey';
	        document.getElementById(PrefixID + "txtDStName").value="";
	        document.getElementById(PrefixID + "txtDZip").disabled=true;
	        document.getElementById(PrefixID + "txtDZip").style.backgroundColor = 'lightgrey';
	        document.getElementById(PrefixID + "txtDZip").value="";
	        document.getElementById(PrefixID + "txtDCross").disabled=true;
	        document.getElementById(PrefixID + "txtDCross").style.backgroundColor = 'lightgrey';
	        document.getElementById(PrefixID + "txtDCross").value="";
	   }*/
	   
	}
/*********************************************************
**function set_asdirected cretor:daniel 
**19/12/2006
*********************************************************/
function set_asdirected()
{
	if(document.forms[0].ctl00_MainContent_chk_as_directed.checked == true){
		//document.forms[0].ctl00_MainContent_DLandmark_Name.value = "AS DIRECTED";
		afterSetDirect(1);
		document.forms[0].ctl00_MainContent_txtDCity.value = "AS DIRECTED";
		Assign_Addr('','','','','','AS DIRECTED','','','','AS DIRECTED','d');
	}else{
	    afterSetDirect(0);
		//document.forms[0].ctl00_MainContent_DLandmark_Name.value = "";
		document.forms[0].ctl00_MainContent_txtDCity.value = "";
	}
}


function afterSetDirect(flag)
{
    if(flag==1){
            document.getElementById(PrefixID + 'ckDAirport').checked = false;
            document.getElementById(PrefixID + "txtDCity").disabled=false;
	        document.getElementById(PrefixID + "txtDCity").style.backgroundColor = 'white';
	        document.getElementById(PrefixID + "txtDStNo").disabled=true;
	        document.getElementById(PrefixID + "txtDStNo").style.backgroundColor = 'lightgrey';
	        document.getElementById(PrefixID + "txtPPoint").value="";
	        document.getElementById(PrefixID + "txtDStName").disabled=true;
	        document.getElementById(PrefixID + "txtDStName").style.backgroundColor = 'lightgrey';
	        document.getElementById(PrefixID + "txtDStName").value="";
	        document.getElementById(PrefixID + "txtDZip").disabled=true;
	        document.getElementById(PrefixID + "txtDZip").style.backgroundColor = 'lightgrey';
	        document.getElementById(PrefixID + "txtDZip").value="";
	        document.getElementById(PrefixID + "txtDCross").disabled=true;
	        document.getElementById(PrefixID + "txtDCross").style.backgroundColor = 'lightgrey';
	        document.getElementById(PrefixID + "txtDCross").value="";
	}else
	{
	    enableControls('d');
	}
	
}
/*********************************************************
**function update_state_airport cretor:daniel 
**19/12/2006
*********************************************************/
function update_state_airport(addr_type){
	var i;
	var indSelect = "";
		
	if(addr_type == "P") {
		if(document.forms[0].ctl00_MainContent_ckPAirport.checked == true){
			document.forms[0].ctl00_MainContent_ddlPState.length = 0;
			document.forms[0].ctl00_MainContent_ddlPState.options[0] = new Option("- Please select airport -","");
		}else if(document.forms[0].ctl00_MainContent_ckPAirport.checked == false){
			document.forms[0].ctl00_MainContent_ddlPState.length = 0;
			document.forms[0].ctl00_MainContent_ddlPState.options[0] = new Option("-","");
			
			for(i=0; i < arrStates.length ; i++){
				document.forms[0].ctl00_MainContent_ddlPState.options[i+1] = new Option(arrStatesDesc[i],arrStates[i]);
				if(arrStates[i] == "NY"){
					indSelect = i+1;
				}
			}
			if(indSelect != "") {
				document.forms[0].ctl00_MainContent_ddlPState.selectedIndex = indSelect;
			}
		}
		document.forms[0].ctl00_MainContent_txtPCity.value = "";
		document.forms[0].ctl00_MainContent_txtPStNo.value = "";
		document.forms[0].ctl00_MainContent_txtPStName.value = "";
	}else if(addr_type == "D"){
		if(document.forms[0].ctl00_MainContent_ckDAirport.checked == true){
			document.forms[0].ctl00_MainContent_ddlDState.length = 0;
			document.forms[0].ctl00_MainContent_ddlDState.options[0] = new Option("- Please select airport -","");
		}else if(document.forms[0].ctl00_MainContent_ckDAirport.checked == false){
			document.forms[0].ctl00_MainContent_ddlDState.length = 0;
			document.forms[0].ctl00_MainContent_ddlDState.options[0] = new Option("-","");
			
			for(i=0; i < arrStates.length ; i++){
				document.forms[0].ctl00_MainContent_ddlDState.options[i+1] = new Option(arrStatesDesc[i],arrStates[i]);
				if(arrStates[i] == "NY"){
					indSelect = i+1;
				}
			}
			if(indSelect != "") {
				document.forms[0].ctl00_MainContent_ddlDState.selectedIndex = indSelect;
			}
		}
		document.forms[0].ctl00_MainContent_txtDCity.value = "";
		document.forms[0].ctl00_MainContent_txtDStNo.value = "";
		document.forms[0].ctl00_MainContent_txtDStName.value = "";
	}
}

/*********************************************************
**function update_state_airport cretor:daniel 
**19/12/2006
*********************************************************/
function toggle_airport_search(type,event_mode){
	var objElement,objElement2;
	isNS4 = (document.layers) ? true : false;
	isIE4 = (document.all && !document.getElementById) ? true : false;
	isIE5 = (document.all && document.getElementById) ? true : false;
	isNS6 = (!document.all && document.getElementById) ? true : false;
	
	//identify the element based on browser type
	if (isNS4){
		objElement = document.layers[type.toLowerCase() + "_divairsearch"];
		objElement2= document.layers[type.toLowerCase() + "_statemenu"];
	}else if (isIE4) {
		objElement = document.all[type.toLowerCase() + "_divairsearch"];
		objElement2= document.all[type.toLowerCase() + "_statemenu"];
	}else if (isIE5 || isNS6) {
		objElement = document.getElementById(type.toLowerCase() + "_divairsearch");
		objElement2= document.getElementById(type.toLowerCase() + "_statemenu");
	}
	
	if(type == "p"){
		if(document.forms[0].ctl00_MainContent_ckPAirport.checked == false){
			objElement.style.visibility = "hidden";
			objElement2.style.visibility = "visible";
		}else{
			objElement.style.visibility = "hidden";
			objElement2.style.visibility = "hidden";
			//document.forms[0].pu_airport_search_text.focus();
			if(event_mode != "startup")
				window.open('airport_details_0.asp?type=p&code=','airport_new','width=450,height=450,scrollbars=1');
		}
		
		update_city_field("","P");
		
	}else{
		if(document.forms[0].ctl00_MainContent_ckPAirport.checked == false){
			objElement.style.visibility = "hidden";
			objElement2.style.visibility = "visible";
		}else{
			objElement.style.visibility = "hidden";
			objElement2.style.visibility = "hidden";
			//document.forms[0].dest_airport_search_text.focus();
			if(event_mode != "startup")
				window.open('airport_details_0.asp?type=d&code=','airport_new','width=450,height=450,scrollbars=1');
		}
		update_city_field("","D");
		
	}
}


function hidCard(flag)
{
    if(flag==0)
    {
        document.getElementById(PrefixID + 'ddlCardType').style.display="none";
        document.getElementById('trCreditCard').style.display="none";
        //document.getElementById('trCreditCardName').style.display="none";
    }
    else
    {
        document.getElementById(PrefixID + 'ddlCardType').style.display="";
        document.getElementById('trCreditCard').style.display="";
        //document.getElementById('trCreditCardName').style.display="";
    }
}

//##    move the focus to next phone box.
//##    11/23/2007  added by yang
function GoToNextPhoneBox(thisBoxId,nextBoxId,maxlength)
{
    var thisBox = document.getElementById(thisBoxId);
    var nextBox = document.getElementById(nextBoxId);
    if (thisBox!=null && nextBox!=null & thisBox.value.length>=maxlength)
    {
        nextBox.focus();
    }
}