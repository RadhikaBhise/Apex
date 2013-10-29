// JScript File
function batch_check(type){
 if(type=='p'){
    if (document.getElementById("ctl00_content_txtCityPickup").value==""){
        alert('Please enter City!');
        document.getElementById("ctl00_content_txtCityPickup").focus();
        return false;
        }
    }
  if (type=='d'){
        if (document.getElementById("ctl00_content_txtCityDropOff").value==""){
        alert('Please enter City!');
        document.getElementById("ctl00_content_txtCityDropOff").focus();
        return false;
     }
    }
    return true;
}

function load_lookup_address(type){

    if(type=='p'){
        if (document.forms[0].ctl00_content_rbtnPickup1.checked == true)
        {   
//                        document.forms[0].ctl00_content_rbtnPickup1.selectedIndex=0;
//                        document.forms[0].ctl00_content_txtZippickup.value="";
//                        document.forms[0].ctl00_content_txtCityPickup.value="";                                                                      
        }
//        if (document.forms[0].ctl00_content_rbtnPickup2.checked == true)
//        {   
//                        document.forms[0].ctl00_content_ddlPickupPickup.selectedIndex=0;
////                        document.forms[0].ctl00_content_txtZippickup.value="";
////                        document.forms[0].ctl00_content_txtCityPickup.value="";                                                                      
//        }
         if (document.forms[0].ctl00_content_rbtnPickup3.checked == true)
        {   
//                        document.forms[0].ctl00_content_rbtnPickup1.selectedIndex=0;
//                        document.forms[0].ctl00_content_txtZippickup.value="";
//                        document.forms[0].ctl00_content_txtCityPickup.value="";                                                                        
        }
    }
    if(type=='d'){
    if (document.forms[0].ctl00_content_rbtnDropoff1.checked == true)
        {   
//                        document.forms[0].ctl00_content_ddlAirportDropOff.selectdIndex=0;
                        //document.forms[0].ctl00_content_txtAirportDropoff.value="";
//                        document.forms[0].ctl00_content_txtCityDropOff.value="";                                                                         
        }
//        if (document.forms[0].ctl00_content_rbtnDropoff2.checked == true)
//        {   
//                        document.forms[0].ctl00_content_ddlAirportDropOff.selectedIndex=0;
////                        document.forms[0].ctl00_content_txtAirportDropoff.value="";
////                        document.forms[0].ctl00_content_txtCityDropOff.value="";                                                                        
//        }
         if (document.forms[0].ctl00_content_rbtnDropoff3.checked == true)
        {   
//                        document.forms[0].ctl00_content_ddlAirportDropOff.selectdIndex=0;
//                        document.forms[0].ctl00_content_txtAirportDropoff.value="";
//                        document.forms[0].ctl00_content_txtCityDropOff.value="";                                                                          
        }    
    }
}


function select_address(type)
{   
       if (type=="p1")
       {    
            document.getElementById("ctl00_content_rbtnPickup1").checked = true;
            load_lookup_address('p')
       }
        if (type=="p2")
       {    
            document.getElementById("ctl00_content_rbtnPickup2").checked = true;
            load_lookup_address('p')
       }
        if (type=="p3")
       {    
            document.getElementById("ctl00_content_rbtnPickup3").checked = true;
            load_lookup_address('p')
       }
        if (type=="d1")
       {    
            document.getElementById("ctl00_content_rbtnDropoff1").checked = true;
            load_lookup_address('d')
       }
        if (type=="d2")
       {    
            document.getElementById("ctl00_content_rbtnDropoff2").checked = true;
            load_lookup_address('d')
       }
        if (type=="d3")
       {    
            document.getElementById("ctl00_content_rbtnDropoff3").checked = true;
            load_lookup_address('d')
       }

}


function batch_lookup()
{
    if (document.forms[0].ctl00_content_rbtnPickup1.checked == true)
        {   
                      if(document.forms[0].ctl00_content_ddlPickupPickup.selectedIndex==0){
                            alert('Please select airport!');
                            document.forms[0].ctl00_content_ddlPickupPickup.focus();
                            return false;
                      }                                                                      
        }
    if (document.forms[0].ctl00_content_rbtnPickup3.checked == true)
    {
        if(document.forms[0].ctl00_content_txtCityPickup.value==""){
                alert('Please enter City!');
                document.forms[0].ctl00_content_txtCityPickup.focus();
                return false;
        }
    }
    
    if (document.forms[0].ctl00_content_rbtnDropoff1.checked == true)
        {   
                     if(document.forms[0].ctl00_content_ddlAirportDropOff.selectedIndex==0){
                            alert('Please select airport!');
                            document.forms[0].ctl00_content_ddlAirportDropOff.focus();
                            return false;
                      }                                                                                             
        }
       
         if (document.forms[0].ctl00_content_rbtnDropoff3.checked == true)
        {   
                     if(document.forms[0].ctl00_content_txtCityDropOff.value==""){
                            alert('Please enter City!');
                            document.forms[0].ctl00_content_txtCityDropOff.focus();
                            return false;
                      }                                                                                            
        }
 }
    
//if (document.forms[0].ctl00_content_txtCityPickup.value.length==0){
//    if (document.forms[0].ctl00_content_rbtnPickup1.checked == true)
//        {   
//                      if(document.forms[0].ctl00_content_ddlPickupPickup.selectedIndex==0){
//                            alert('Please select airport!');
//                            document.forms[0].ctl00_content_ddlPickupPickup.focus();
//                            return false;
//                      }                                                                      
//        }
//    if (document.forms[0].ctl00_content_rbtnPickup2.checked == true)
//    {
//        if(document.forms[0].ctl00_content_txtZippickup.value==""){
//                alert('Please enter zip/postal code!');
//                document.forms[0].ctl00_content_txtZippickup.focus();
//                return false;
//        }
//    }
//  }else{
//    if (document.forms[0].ctl00_content_rbtnPickup3.checked == true)
//    {
//        if(document.forms[0].ctl00_content_txtCityPickup.value==""){
//                alert('Please enter City!');
//                document.forms[0].ctl00_content_txtCityPickup.focus();
//                return false;
//        }
//    }
//    }
//       /*check dropoff */ 
//      if (document.forms[0].ctl00_content_txtCityDropOff.value.length==0){
//        if (document.forms[0].ctl00_content_rbtnDropoff1.checked == true)
//        {   
//                     if(document.forms[0].ctl00_content_ddlAirportDropOff.selectedIndex==0){
//                            alert('Please select airport!');
//                            document.forms[0].ctl00_content_ddlAirportDropOff.focus();
//                            return false;
//                      }                                                                                             
//        }
//        if (document.forms[0].ctl00_content_rbtnDropoff2.checked == true)
//        {   
//                     if(document.forms[0].ctl00_content_txtAirportDropoff.value==""){
//                            alert('Please enter zip/postal code!');
//                            document.forms[0].ctl00_content_txtAirportDropoff.focus();
//                            return false;
//                      }                                                                                             
//        }
//       }else{
//         if (document.forms[0].ctl00_content_rbtnDropoff3.checked == true)
//        {   
//                     if(document.forms[0].ctl00_content_txtCityDropOff.value==""){
//                            alert('Please enter City!');
//                            document.forms[0].ctl00_content_txtCityDropOff.focus();
//                            return false;
//                      }                                                                                            
//        }
//        }



function citylookupname(type,city)
{
	if(type == 'P' || type=='p')
	{
		self.opener.document.getElementById("ctl00_content_txtCityPickup").value = city;
	}
	else if(type=='D' || type=='d')
	{
		self.opener.document.getElementById("ctl00_content_txtCityDropOff").value = city;
	}
//	else if(type=='s' || type=='S')
//	{
//		self.opener.document.getElementById("txtSCity").value = city;
//	}

	window.close();
}

function CityLookUp(type){
		var borough,city_name,ind;
		    
		if(type == "p") {
//		ind = document.forms[0].ctl00_content_ddlPuState.selectedIndex;
//		borough = document.forms[0].ctl00_content_ddlPuState.options[ind].value;
		city_name = document.getElementById("ctl00_content_txtCityPickup").value;
		if (city_name=="New York" || city_name=="New York City"){
		    alert('You must select one of the five boroughs (Manhattan, Manhattan1, Queens, Bronx, Brooklyn, Staten Island).');
		    document.getElementById("ctl00_content_txtCityPickup").focus();
		    return false;
		}
		}else{
//		ind = document.forms[0].ctl00_content_ddlDestState.selectedIndex;
//		borough = document.forms[0].ctl00_content_ddlDestState.options[ind].value;
		city_name = document.getElementById("ctl00_content_txtCityDropOff").value;
		if (city_name=="New York" || city_name=="New York City"){
		    alert('You must select one of the five boroughs (Manhattan, Manhattan1, Queens, Bronx, Brooklyn, Staten Island).');
		    document.getElementById("ctl00_content_txtCityDropOff").focus();
		    return false;
		}		
		}
//		
//		if(borough != "M" && borough != "SI" && borough != "QU" && borough != "BK" && borough != "BX" && borough != "LGA" && borough != "JFK" && borough != "EWR" && borough != ""){
//			//if(city_name.length >= 3){
        if(batch_check(type)==true){
				eval("window.open('CityLookUp.aspx?type="+type+"&city="+city_name+"','street','width=500,height=400,scrollbars=1');");
				}
			//} else {
			//	alert("Please enter at least 3 characters in the city field!");
			//}
//		} else {
//			alert("City lookup function is only available for out of town addresses");
//		}
		
	}

function searchairport(type)
{
   eval("window.open('SearchAirport.aspx?type="+type+"','street','width=500,height=400,scrollbars=1');");
   //eval("window.open('SearchAirport.aspx?type="+type+"');");
}

function show_which_tr(type){
    //alert(type);
    if (type=='Y'){
        document.getElementById("ctl00_content_trdd").style.display="";
        document.getElementById("ctl00_content_ddlpucity").style.display="";
        document.getElementById("ctl00_content_trfrom").style.display="none";
    }else{
        document.getElementById("ctl00_content_trdd").style.display="none";
        document.getElementById("ctl00_content_trfrom").style.display="";    
    }
}

/********************************************************
**funciton add by daniel for some entervalues 12/14/2006
********************************************************/
function entervalues(){

	if(event.keyCode==44)
	{
		//event.returnValue=false;
		//alert("Don't enter commas (,) ");
	}else if (event.keyCode==39){
		event.returnValue=false;
		//alert("Don't enter apostrophes (') ");	
	}
	
}