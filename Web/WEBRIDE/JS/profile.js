// JScript File

	// date field validation (called by other validation functions that specify minYear/maxYear)
	function isDate(gField,minYear,maxYear) { 
		var inputStr = gField.value; 
		// convert hyphen delimiters to slashes 
		while (inputStr.indexOf("-") != -1) { 
			var regexp = /-/;
			inputStr = inputStr.replace(regexp,"/"); }
		var delim1 = inputStr.indexOf("/")
		var delim2 = inputStr.lastIndexOf("/")
		if (delim1 != -1 && delim1 == delim2) { 
			// there is only one delimiter in the string
			alert("The date entry is not in an acceptable format.\n\nYou can enter dates in the following formats: mmddyyyy, mm/dd/yyyy, or mm-dd-yyyy. (If the month or date data is not available, enter \'01\' in the appropriate location.)")
			gField.focus()
			gField.select()
			return false }
		if (delim1 != -1) { 
			// there are delimiters; extract component values
			var mm = parseInt(inputStr.substring(0,delim1),10)
			var dd = parseInt(inputStr.substring(delim1 + 1,delim2),10)
			var yyyy = parseInt(inputStr.substring(delim2 + 1, inputStr.length),10)
		} else { 
			// there are no delimiters; extract component values
			var mm = parseInt(inputStr.substring(0,2),10)
			var dd = parseInt(inputStr.substring(2,4),10)
			var yyyy = parseInt(inputStr.substring(4,inputStr.length),10)
		}
		if (isNaN(mm) || isNaN(dd) || isNaN(yyyy)) { 
			// there is a non-numeric character in one of the component values
			alert("The date entry is not in an acceptable format.\n\nYou can enter dates in the following formats: mmddyyyy, mm/dd/yyyy, or mm-dd-yyyy.") 
			gField.focus()
			gField.select()
			return false
		}
		if (mm < 1 || mm > 12) { 
			// month value is not 1 thru 12 
			alert("Months must be entered between the range of 01 (January) and 12 (December).")
			gField.focus()
			gField.select()
			return false
		} 
		if (dd < 1 || dd > 31) { 
			// date value is not 1 thru 31 
			alert("Days must be entered between the range of 01 and a maximum of 31 (depending on the month and year).")
			gField.focus()
			gField.select()
			return false
		} 
		// validate year, allowing for checks between year ranges 
		// passed as parameters from other validation functions
		if (yyyy < 100) { 
			// entered value is two digits, which we allow for 1930-2029
			alert("Year must be entered in four-digit format.  Please try again!")
			gField.focus()
			gField.select()
			return false
		}
		if (yyyy < minYear || yyyy > maxYear) {
			alert("Year must be entered between the range of " + minYear + " and " + maxYear + "."); 
			gField.focus()
			gField.select()
			return false
		}	
		if (!checkMonthLength(mm,dd)) {
			gField.focus()
			gField.select()
			return false
		}
		if (mm == 2) {
			if (!checkLeapMonth(mm,dd,yyyy)) {
				gField.focus() 
				gField.select()
				return false
			}
		}
		gField.value = mm + "/" + dd + "/" + yyyy;
		return true;
	}
	// check the entered month for too high a value 
	function checkMonthLength(mm,dd) { 
		var months = new 
		Array("","January","February","March","April","May","June","July","August","September","October","November","December") 
		if ((mm == 4 || mm == 6 || mm == 9 || mm == 11) && dd > 30) { 
			alert(months[mm] + " has only 30 days.")
			return false
		} else if (dd > 31) { 
			alert(months[mm] + " has only 31 days.")
			return false
		}
		 return true
	}
	// check the entered February date for too high a value
	function checkLeapMonth(mm,dd,yyyy) { 
		if (yyyy % 4 > 0 && dd > 28) { 
			alert("February of " + yyyy + " has only 28 days.")
			return false
		} else if (dd > 29) { 
			alert("February of " + yyyy + " has only 29 days.")
			return false
		} 
		return true
	}
	// get current year
	function getTheYear() { 
		var thisYear = (new Date()).getFullYear();
		return thisYear
	} 	
	
function updatelevel()
{
document.form.action = "userprofile.aspx";
document.form.submit();

}
function admin_changepwd(){
    if(document.all['ctl00_MainContent_txtCurpwd'].value == "") {
            alert('Please enter password!');
			document.all['ctl00_MainContent_txtCurpwd'].focus();
			return false;
		}
		
	if(document.all['ctl00_MainContent_txtNewpwd'].value=="") {
			alert('Please enter password!');
			document.all['ctl00_MainContent_txtNewpwd'].focus();
			return false;
		}
	if(document.all['ctl00_MainContent_txtNewpwd'].value.length < 6 && document.all['ctl00_MainContent_txtNewpwd'].value.length > 0){
		alert('Password requires at least 6 characters!');
		document.all['ctl00_MainContent_txtNewpwd'].focus();
		return false;
	}	
	if (document.all['ctl00_MainContent_txtNewpwd'].value != document.all['ctl00_MainContent_txtConfpwd'].value) {
			alert('Password does not match! Please re-enter password.');
			document.all['ctl00_MainContent_txtConfpwd'].focus();
			return false;
		}
}

 /****************************************************
 ** Function sendEmail_confrim()
 ** Description:use to send mail page to confirm the sendmail:whether really want to send Email
 ** Input:
 ** Output:
 ** 02/15/05 - Created(jack)
 ****************************************************/ 
function sendEmail_confrim(){
return confirm("Do you really want to send email?");
}

 /****************************************************
 ** Function 
 ** Description:use to send mail page 
 ** Input:
 ** Output:
 ** 02/14/05 - Created(jack)
 ****************************************************/ 
function copyTex(){
document.getElementById('ctl00_MainContent_txtText').innerText=document.getElementById('myDiv').innerHTML;
	//--add by eJay 2/16/05
	document.getElementById('ctl00_MainContent_txtFooter').innerText=document.getElementById('divFooter').innerHTML;
	//document.all['ctl00_MainContent_txtFile'].value=document.all['browse'].value;
}
	
function initDiv(){
document.getElementById('myDiv').innerHTML=document.getElementById('ctl00_MainContent_txtText').innerText;
	//--add by eJay 2/16/05
	
	if(document.getElementById('myDiv').innerHTML==""&&document.getElementById('ctl00_MainContent_txtEmailadd').value==""){
	
		document.getElementById('ctl00_MainContent_txtFooter').innerText="<TR><td align='center'width='100%' style='FONT-FAMILY: Arial'>Please visit <font color=blue size=3><a href='www.1800fly1800.com'>www.1800fly1800.com</a></font> or&nbsp;</td></TR><TR><td align='center'width='100%' style='FONT-FAMILY: Arial'>Call 1-800-<font color=blue>APEX</font>-1800 to make reservations at your convenience.</td></TR>";
	}
	
	
	document.getElementById('divFooter').innerHTML=document.getElementById('ctl00_MainContent_txtFooter').innerText;
	//alert(browse.value);
	//document.all['browse'].value=document.all['ctl00_MainContent_txtFile'].value;
	//document.all['ctl00_MainContent_txtFile'].style.display='none';
}
function jumpnewwindow(){
window.open('preview_email.aspx','Preview','width=800,height=400,scrollbars=1,resizable=yes');
}
function jumpvipwindow(){
window.open('details.aspx','VipPreview','width=800,height=400,scrollbars=1');
}
  /****************************************************
 ** Function set_defaultinfo_pageload()
 ** Description:when the page load 
 ** Input:
 ** Output:
 ** 12/06/04 - Created(jack)
 ****************************************************/ 
 function set_defaultinfo_pageload()
 {var type=document.all['ctl00_MainContent_ddlCardType'].options[document.all['ctl00_MainContent_ddlCardType'].selectedIndex].value
 if (document.all['ctl00_MainContent_txtCardNo'].value!="")
 {
  document.all["hidcctype" + type].value=document.all['ctl00_MainContent_txtCardNo'].value + "/" +document.all['ctl00_MainContent_ddlMonth'].selectedIndex + "/" + document.all['ctl00_MainContent_ddlYear'].selectedIndex;
}
 }
 
 
  /****************************************************
 ** Function set_defaultinfo_pageload()
 ** Description:when the page load 
 ** Input:
 ** Output:
 ** 12/24/04 - Created(eJay)
 ****************************************************/ 
 function set_defaultinfo1_pageload()
 {var type=document.all['ctl00_MainContent_ddlCardType1'].options[document.all['ctl00_MainContent_ddlCardType1'].selectedIndex].value
 if (document.all['ctl00_MainContent_txtCardNo1'].value!="")
 {
  document.all["hidcctype1" + type].value=document.all['ctl00_MainContent_txtCardNo1'].value + "/" +document.all['ctl00_MainContent_ddlMonth1'].selectedIndex + "/" + document.all['ctl00_MainContent_ddlYear1'].selectedIndex;
}
 }
 
 /****************************************************
 ** Function set_defaultinfo_cctypechange()
 ** Description:when the cctype is changed the default info should be show
 ** Input:
 ** Output:
 ** 12/06/04 - Created(jack)
 ****************************************************/ 
 function set_defaultinfo_cctypechange()
 {
 
 var type=document.all['ctl00_MainContent_ddlCardType'].options[document.all['ctl00_MainContent_ddlCardType'].selectedIndex].value
 if (type==0){document.all['ctl00_MainContent_txtCardNo'].value="";
				document.all['ctl00_MainContent_ddlMonth'].selectedIndex=0;
				document.all['ctl00_MainContent_ddlYear'].selectedIndex=0;}

 else{
 
				if (document.all["ctl00_MainContent_hidcctype" + type].value.length==0)
				{ document.all['ctl00_MainContent_txtCardNo'].value="";
				document.all['ctl00_MainContent_ddlMonth'].selectedIndex=0;
				document.all['ctl00_MainContent_ddlYear'].selectedIndex=0;
				}
				else{
				var arr=document.all["ctl00_MainContent_hidcctype" + type].value.split('/')
				document.all['ctl00_MainContent_txtCardNo'].value=arr[0];
				document.all['ctl00_MainContent_ddlMonth'].selectedIndex=arr[1];
				document.all['ctl00_MainContent_ddlYear'].selectedIndex=arr[2];
				}
   
   }

 }


/****************************************************
 ** Function set_defaultinfo_cctype1change()
 ** Description:when the cctype is changed the default info should be show
 ** Input:
 ** Output:
 ** 12/24/04 - Created(eJay)
 ****************************************************/ 
 function set_defaultinfo_cctype1change()
 {
 
 var type=document.all['ctl00_MainContent_ddlCardType1'].options[document.all['ctl00_MainContent_ddlCardType1'].selectedIndex].value
 if (type==0){document.all['ctl00_MainContent_txtCardNo1'].value="";
				document.all['ctl00_MainContent_ddlMonth1'].selectedIndex=0;
				document.all['ctl00_MainContent_ddlYear1'].selectedIndex=0;}

 else{
 
				if (document.all["hidcctype1" + type].value.length==0)
				{ document.all['ctl00_MainContent_txtCardNo1'].value="";
				document.all['ctl00_MainContent_ddlMonth1'].selectedIndex=0;
				document.all['ctl00_MainContent_ddlYear1'].selectedIndex=0;
				}
				else{
				var arr=document.all["hidcctype1" + type].value.split('/')
				document.all['ctl00_MainContent_txtCardNo1'].value=arr[0];
				document.all['ctl00_MainContent_ddlMonth1'].selectedIndex=arr[1];
				document.all['ctl00_MainContent_ddlYear1'].selectedIndex=arr[2];
				}
   
   }

 }
 
 
 /****************************************************
 ** Function set_defaultinfo_ccinfochange()
 ** Description:when the card info changed the info will be set to the hidetextbox
 ** Input:
 ** Output:
 ** 12/06/04 - Created(jack)
 ****************************************************/ 
 function set_defaultinfo_ccinfochange()
 {
 
 var type=document.all['ctl00_MainContent_ddlCardType'].options[document.all['ctl00_MainContent_ddlCardType'].selectedIndex].value
  document.all["ctl00_MainContent_hidcctype" + type].value=document.all['ctl00_MainContent_txtCardNo'].value + "/" +document.all['ctl00_MainContent_ddlMonth'].selectedIndex + "/" + document.all['ctl00_MainContent_ddlYear'].selectedIndex;
 }

 /****************************************************
 ** Function set_defaultinfo_ccinfo1change()
 ** Description:when the card info 2 changed the info will be set to the hidetextbox
 ** Input:
 ** Output:
 ** 12/24/04 - Created(eJay)
 ****************************************************/ 
 function set_defaultinfo_ccinfo1change()
 {
 
 var type=document.all['ctl00_MainContent_ddlCardType1'].options[document.all['ctl00_MainContent_ddlCardType1'].selectedIndex].value
 document.all["ctl00_MainContent_hidcctype1" + type].value=document.all['ctl00_MainContent_txtCardNo1'].value + "/" +document.all['ctl00_MainContent_ddlMonth1'].selectedIndex + "/" + document.all['ctl00_MainContent_ddlYear1'].selectedIndex;
  
 }


	
/*********************************************************************************
**function:check_max_length
**Description:delte the leading space and the space tail
**Input:s
**Output:s
**11/23/04 - Created (jack)
*********************************************************************************/
function check_max_length(){ 
    if (document.getElementById("ctl00_content_ddlCarType").selectedI,dex==0){
        alert('Please select the credit card type');
        document.getElementById("ctl00_content_ddlCarType").focus();
    }

    var checkcardtype=document.getElementById("ctl00_content_ddlCarType").options[document.getElementById("ctl00_content_ddlCarType").selectedIndex].value;
    if (checkcardtype==1||checkcardtype==3){
        document.getElementById("ctl00_content_txtCardNo").maxLength=15;
    }else if (checkcardtype==2||checkcardtype==4||checkcardtype==5||checkcardtype==6){
        document.getElementById("ctl00_content_txtCardNo").maxLength=16;
    }    
}	
	//-------------------------------------------
	//--Function:check_time_frame
	//--Description:when the admin login the function use the check the time_frame
	//--Input:
	//--Output:
	//--12/14/04 - Created (jack)
	//-------------------------------------------
	function check_time_frame()
	{     
	       
	          if (document.all['ctl00_MainContent_txtTimeframe'].value=="")
				{alert('Please enter the timeframe');
				document.all['ctl00_MainContent_txtTimeframe'].focus();
				return false;
				}
				if (isNaN(document.all['ctl00_MainContent_txtTimeframe'].value))
				{alert('Please enter numeric values as timeframe');
				document.all['ctl00_MainContent_txtTimeframe'].focus();
				return false;
				}

	
	}
	
	
	//-------------------------------------------
	//--Function:ShowTable
	//--Description:Used for setpw1.aspx
	//--Input:
	//--Output:
	//--11/10/04 - Created (eJay_
	//-------------------------------------------
	function ShowTable(){
	    if(typeof(document.all['ctl00_MainContent_lblShow'])=='undefined' ){
			document.all['ctl00_MainContent_tbUser'].style.display='';
			//alert('undefined');
	    }
	    else
	    {	document.all['ctl00_MainContent_tbUser'].style.display='none';
			//alert('Defined');
	    }
	}
	
	
	//--------------------------------------------
	//Function:IsValidCardType
	//Description:Check if the Card Type is valid
	//Input:
	//Output:
	// 10/29/04 - Created (eJay)
	//--------------------------------------------
	function IsValidCardType(){
		var num;
		var index1;
		var index2;
		num=document.adduserForm.ctl00_MainContent_txtCardNo.value;
		index1=document.adduserForm.ctl00_MainContent_ddlCardType.selectedIndex;
		index2=document.adduserForm.ctl00_MainContent_ddlMonth.selectedIndex;
		
		if(num!=""){
			if(0==index1){
				alert("Please select the Credit Card Type");
				//return true;
				document.adduserForm.ctl00_MainContent_ddlCardType.selectedIndex=1;
				return false;
			}
			else if( (0==index2) || (0==document.adduserForm.ctl00_MainContent_ddlYear.selectedIndex)){
				alert("Please enter the credit card expiration date!");
				if (0==index2){
				document.adduserForm.ctl00_MainContent_ddlMonth.selectedIndex=1;}
				if (0==document.all['ctl00_MainContent_ddlYear'].selectedIndex){
					document.all['ctl00_MainContent_ddlYear'].selectedIndex=1;
				}
				
				return false;
			}	
		}
		else
			return true;
		
	}
	
	function batchValidate_bkyang(){
	
		if(document.getElementById("ctl00_MainContent_userprofile_txtNewpwd").value.length < 6 && document.getElementById("ctl00_MainContent_userprofile_txtNewpwd").value.length > 0){
			alert('Password requires at least 6 characters!');
			document.getElementById['ctl00_MainContent_userprofile_txtNewpwd'].focus();
			return false;
		}
		if (document.getElementById("ctl00_MainContent_userprofile_txtNewpwd").value != document.getElementById("ctl00_MainContent_userprofile_txtConfpwd").value) {
			alert('Password do not match!');
			document.getElementById("ctl00_MainContent_userprofile_txtConfpwd").focus();
			return false;
		}
		if(document.forms[0].ctl00_MainContent_userprofile_ddlCardType.selectedIndex == 0){
			alert('Please select the credit card  type!');
			document.forms[0].ctl00_MainContent_userprofile_ddlCardType.focus();
			return false;
		}
		if(document.forms[0].ctl00_MainContent_userprofile_ddlCardType.selectedIndex != 0 && document.forms[0].ctl00_MainContent_userprofile_txtCardNo.value.length == 0){
			alert('Please enter credit card !');
			document.forms[0].ctl00_MainContent_userprofile_txtCardNo.focus();
			return false;	
		}
		if(document.forms[0].ctl00_MainContent_userprofile_txtCardNo.value.length > 0 && document.forms[0].ctl00_MainContent_userprofile_txtCardNo.value.length !=15 && document.all['ctl00_MainContent_userprofile_ddlCardType'].selectedIndex != 0 && (document.all['ctl00_MainContent_userprofile_ddlCardType'].options[document.all['ctl00_MainContent_userprofile_ddlCardType'].selectedIndex].innerText == "AMEX" || document.all['ctl00_MainContent_userprofile_ddlCardType'].options[document.all['ctl00_MainContent_userprofile_ddlCardType'].selectedIndex].innerText == "DINERS")){
			alert("'AMEX' and 'DINERS' should be 15 digits!");
			document.forms[0].ctl00_MainContent_userprofile_txtCardNo.focus();
			return false;
		}
		if(document.forms[0].ctl00_MainContent_userprofile_txtCardNo.value.length !=16 && document.all['ctl00_MainContent_userprofile_ddlCardType'].options[document.all['ctl00_MainContent_userprofile_ddlCardType'].selectedIndex].innerText != "AMEX" && document.all['ctl00_MainContent_userprofile_ddlCardType'].options[document.all['ctl00_MainContent_userprofile_ddlCardType'].selectedIndex].innerText != "DINERS"){
			alert("Credit Card Number must be 16 digits!");
			document.forms[0].ctl00_MainContent_userprofile_txtCardNo.focus();
			return false;
		}
		if(isNaN(document.forms[0].ctl00_MainContent_userprofile_txtCardNo.value)){
			alert("Please enter numeric values as credit card !");
			document.forms[0].ctl00_MainContent_userprofile_txtCardNo.focus();
			return false;
		}
		if(document.forms[0].ctl00_MainContent_userprofile_txtCardNo.value.length > 0 && (document.forms[0].ctl00_MainContent_userprofile_ddlMonth.selectedIndex == 0 || document.forms[0].ctl00_MainContent_userprofile_ddlYear.selectedIndex == 0 )){
			alert("Please enter the credit card  expiration date!");
			if(document.forms[0].ctl00_MainContent_userprofile_ddlMonth.selectedIndex == 0){
				document.all['ctl00_MainContent_userprofile_ddlMonth'].focus();
			}
			else{
				document.all['ctl00_MainContent_userprofile_ddlYear'].focus();
			}
			return false;
		}
		if(document.forms[0].ctl00_MainContent_userprofile_txtEmail.value != "" && document.forms[0].ctl00_MainContent_userprofile_txtEmail.value != null && (document.all['ctl00_MainContent_userprofile_txtEmail'].value.match(/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/)==null)){
			alert("Please enter a valid Email Address!");
			document.forms[0].ctl00_MainContent_userprofile_txtEmail.focus();
			return false;
		}
		if(document.forms[0].ctl00_MainContent_userprofile_txtStNo.value!="" && isNaN(document.forms[0].ctl00_MainContent_userprofile_txtStNo.value)){
			alert("Please enter numeric values as Street No!");
			document.forms[0].ctl00_MainContent_userprofile_txtStNo.focus();
			return false;
		}
		if(isNaN(document.forms[0].ctl00_MainContent_userprofile_txtZip.value)){
			alert("Please enter numeric values as zip number!");
			document.forms[0].ctl00_MainContent_userprofile_txtZip.focus();
			return false;
		}

		return true;
	}
	
	function agent_user_batchValidate(){
	
	   		
		if(document.getElementById("ctl00_MainContent_txtFname").value == ""){
			alert("Please enter first name!");
			document.getElementById("ctl00_MainContent_txtFname").focus();
			return false;
		}
		if(document.getElementById("ctl00_MainContent_txtLname").value == ""){
			alert("Please enter last name!");
			document.getElementById("ctl00_MainContent_txtLname").focus();
			return false;
		}
		if(document.forms[0].ctl00_MainContent_ddlCardType.selectedIndex == 0){
			alert('Please select the credit card  type!');
			document.forms[0].ctl00_MainContent_ddlCardType.focus();
			return false;
		}
		if(document.forms[0].ctl00_MainContent_ddlCardType.selectedIndex != 0 && document.forms[0].ctl00_MainContent_txtCardNo.value.length == 0){
			alert('Please enter credit card !');
			document.forms[0].ctl00_MainContent_txtCardNo.focus();
			return false;			
		
		}
		if(document.forms[0].ctl00_MainContent_txtCardNo.value.length > 0 && document.forms[0].ctl00_MainContent_txtCardNo.value.length !=15 && document.all['ctl00_MainContent_ddlCardType'].selectedIndex != 0 && (document.all['ctl00_MainContent_ddlCardType'].options[document.all['ctl00_MainContent_ddlCardType'].selectedIndex].innerText == "AMEX" || document.all['ctl00_MainContent_ddlCardType'].options[document.all['ctl00_MainContent_ddlCardType'].selectedIndex].innerText == "DINERS")){
			alert("'AMEX' and 'DINERS' should be 15 digits!");
			document.forms[0].ctl00_MainContent_txtCardNo.focus();
			return false;
		}
		if(document.forms[0].ctl00_MainContent_txtCardNo.value.length !=16 && document.all['ctl00_MainContent_ddlCardType'].options[document.all['ctl00_MainContent_ddlCardType'].selectedIndex].innerText != "AMEX" && document.all['ctl00_MainContent_ddlCardType'].options[document.all['ctl00_MainContent_ddlCardType'].selectedIndex].innerText != "DINERS"){
			alert("Credit Card Number must be 16 digits!");
			document.forms[0].ctl00_MainContent_txtCardNo.focus();
			return false;
		}
		if(isNaN(document.forms[0].ctl00_MainContent_txtCardNo.value)){
			alert("Please enter numeric values as credit card !");
			document.forms[0].ctl00_MainContent_txtCardNo.focus();
			return false;
		}
		if(document.forms[0].ctl00_MainContent_txtCardNo.value.length > 0 && (document.forms[0].ctl00_MainContent_ddlMonth.selectedIndex == 0 || document.forms[0].ctl00_MainContent_ddlYear.selectedIndex == 0 )){
			alert("Please enter the credit card  expiration date!");
			if(document.forms[0].ctl00_MainContent_ddlMonth.selectedIndex == 0){
				document.all['ctl00_MainContent_ddlMonth'].focus();
			}
			else{
				document.all['ctl00_MainContent_ddlYear'].focus();
			}
			return false;
		}
		
		if(document.forms[0].ctl00_MainContent_txtFullName.value == ""){
			alert("Please enter cardholder's name!");
			document.forms[0].ctl00_MainContent_txtFullName.focus();
			return false;
		}
		//--add by eJay 12/24/04*******************************************************
//		if(document.forms[0].ctl00_MainContent_ddlCardType1.selectedIndex != 0 && document.forms[0].ctl00_MainContent_txtCardNo1.value.length == 0){
//			alert('Please enter credit card 2!');
//			document.forms[0].ctl00_MainContent_txtCardNo1.focus();
//			return false;			
//		
//		}
//		if(document.forms[0].ctl00_MainContent_txtCardNo1.value.length > 0 && document.forms[0].ctl00_MainContent_txtCardNo1.value.length !=15 && document.all['ctl00_MainContent_ddlCardType1'].selectedIndex != 0 && (document.all['ctl00_MainContent_ddlCardType1'].options[document.all['ctl00_MainContent_ddlCardType1'].selectedIndex].innerText == "AMEX" || document.all['ctl00_MainContent_ddlCardType1'].options[document.all['ctl00_MainContent_ddlCardType1'].selectedIndex].innerText == "DINERS")){
//			alert("'AMEX' and 'DINERS' should be 15 digits!");
//			document.forms[0].ctl00_MainContent_txtCardNo1.focus();
//			return false;
//		}
//		if(document.all['ctl00_MainContent_ddlCardType1'].selectedIndex != 0 && document.forms[0].ctl00_MainContent_txtCardNo1.value.length !=16 && document.all['ctl00_MainContent_ddlCardType1'].options[document.all['ctl00_MainContent_ddlCardType1'].selectedIndex].innerText != "AMEX" && document.all['ctl00_MainContent_ddlCardType1'].options[document.all['ctl00_MainContent_ddlCardType1'].selectedIndex].innerText != "DINERS"){
//			alert("Credit Card Number must be 16 digits!");
//			document.forms[0].ctl00_MainContent_txtCardNo1.focus();
//			return false;
//		}
//		if(document.all['ctl00_MainContent_ddlCardType1'].selectedIndex != 0 && isNaN(document.forms[0].ctl00_MainContent_txtCardNo1.value)){
//			alert("Please enter numeric values as credit card 2!");
//			document.forms[0].ctl00_MainContent_txtCardNo1.focus();
//			return false;
//		}
//		if(document.all['ctl00_MainContent_ddlCardType1'].selectedIndex != 0 && document.forms[0].ctl00_MainContent_txtCardNo1.value.length > 0 && (document.forms[0].ctl00_MainContent_ddlMonth1.selectedIndex == 0 || document.forms[0].ctl00_MainContent_ddlYear1.selectedIndex == 0 )){
//			alert("Please enter the credit card 2 expiration date!");
//			if(document.forms[0].ctl00_MainContent_ddlMonth1.selectedIndex == 0){
//				document.all['ctl00_MainContent_ddlMonth1'].focus();
//			}
//			else{
//				document.all['ctl00_MainContent_ddlYear1'].focus();
//			}
//			return false;
//		}
		//************************************************************************
//		if(document.all['ctl00_MainContent_ddlCardType1'].selectedIndex != 0 && document.forms[0].ctl00_MainContent_txtCCName2.value == ""){
//			alert("Please enter cardholder's name!");
//			document.forms[0].ctl00_MainContent_txtCCName2.focus();
//			return false;
//		}
		/*if(document.forms[0].ctl00_MainContent_txtCardNo.value.length > 0 && (document.forms[0].ctl00_MainContent_ddlCardType.selectedIndex == 0)){
			alert("Please select the Credit Card Type");
			document.forms[0].ctl00_MainContent_ddlCardType.focus();
			return false;
		}*/
		    if(document.forms[0].ctl00_MainContent_txtPhoneArea.value == ""){
			alert("Please enter a primary phone number!")
			document.forms[0].ctl00_MainContent_txtPhoneArea.focus();
			return false;
		}		
		if(isNaN(document.forms[0].ctl00_MainContent_txtPhoneArea.value)){
			alert("Please enter numeric values as phone number");
			document.forms[0].ctl00_MainContent_txtPhoneArea.focus();
			return false;
		}
		if(document.forms[0].ctl00_MainContent_txtPhoneFront.value == ""){
			alert("Please enter a primary phone number!")
			document.forms[0].ctl00_MainContent_txtPhoneFront.focus();
			return false;
		}
		if(isNaN(document.forms[0].ctl00_MainContent_txtPhoneFront.value)){
			alert("Please enter numeric values as phone number");
			document.forms[0].ctl00_MainContent_txtPhoneFront.focus();
			return false;
		}		
		if(document.forms[0].ctl00_MainContent_txtPhonetail.value == ""){
			alert("Please enter a primary phone number!")
			document.forms[0].ctl00_MainContent_txtPhonetail.focus();
			return false;
		}
		if(isNaN(document.forms[0].ctl00_MainContent_txtPhonetail.value)){
			alert("Please enter numeric values as phone number");
			document.forms[0].ctl00_MainContent_txtPhonetail.focus();
			return false;
		}
		/*if(document.forms[0].ctl00_MainContent_txtPhoneext.value == ""){
			alert('Please enter a phone ext!');
			document.forms[0].ctl00_MainContent_txtPhoneext.focus();
			return false;
		}*/
		if(isNaN(document.forms[0].ctl00_MainContent_txtPhoneext.value)){
			alert("Please enter numeric values as phone ext!");
			document.forms[0].ctl00_MainContent_txtPhoneext.focus();
			return false;
		}
		/*if(document.forms[0].ctl00_MainContent_txtCellPhoneArea.value == ""){
			alert("Please enter a cell phone!");
			document.forms[0].ctl00_MainContent_txtCellPhoneArea.focus();
			return false;
		}*/
		if(document.forms[0].ctl00_MainContent_txtCellPhoneArea.value != "" && isNaN(document.forms[0].ctl00_MainContent_txtCellPhoneArea.value)){
			alert("Please enter numeric values as phone number!")
			document.forms[0].ctl00_MainContent_txtCellPhoneArea.focus();
			return false;
		}
		/*if(document.forms[0].ctl00_MainContent_txtCellPhoneFront.value == ""){
			alert("Please enter a cell phone!");
			document.forms[0].ctl00_MainContent_txtCellPhoneFront.focus();
			return false;
		}*/
		if(document.forms[0].ctl00_MainContent_txtCellPhoneFront.value != "" && isNaN(document.forms[0].ctl00_MainContent_txtCellPhoneFront.value)){
			alert("Please enter numeric values as phone number!")
			document.forms[0].ctl00_MainContent_txtCellPhoneFront.focus();
			return false;
		}
		/*if(document.forms[0].ctl00_MainContent_txtCellPhonetail.value == ""){
			alert("Please enter a cell phone!");
			document.forms[0].ctl00_MainContent_txtCellPhonetail.focus();
			return false;
		}*/
		if(document.forms[0].ctl00_MainContent_txtCellPhonetail.value != "" && isNaN(document.forms[0].ctl00_MainContent_txtCellPhonetail.value)){
			alert("Please enter numeric values as phone number!")
			document.forms[0].ctl00_MainContent_txtCellPhonetail.focus();
			return false;
		}	
		/*if(document.forms[0].ctl00_MainContent_txtFaxArea.value == ""){
			alert("Please enter a fax!");
			document.forms[0].ctl00_MainContent_txtFaxArea.focus();
			return false;
		}*/
		if(document.forms[0].ctl00_MainContent_txtFaxArea.value != "" && isNaN(document.forms[0].ctl00_MainContent_txtFaxArea.value)){
			alert("Please enter numeric values as fax number!")
			document.forms[0].ctl00_MainContent_txtFaxArea.focus();
			return false;
		}
		/*if(document.forms[0].ctl00_MainContent_txtFaxFront.value == ""){
			alert("Please enter a fax!");
			document.forms[0].ctl00_MainContent_txtFaxFront.focus();
			return false;
		}*/
		if(document.forms[0].ctl00_MainContent_txtFaxFront.value != "" && isNaN(document.forms[0].ctl00_MainContent_txtFaxFront.value)){
			alert("Please enter numeric values as fax number!")
			document.forms[0].ctl00_MainContent_txtFaxFront.focus();
			return false;
		}
		/*if(document.forms[0].ctl00_MainContent_txtFaxtail.value == ""){
			alert("Please enter a fax!");
			document.forms[0].ctl00_MainContent_txtFaxtail.focus();
			return false;
		}*/
		if(document.forms[0].ctl00_MainContent_txtFaxtail.value != "" && isNaN(document.forms[0].ctl00_MainContent_txtFaxtail.value)){
			alert("Please enter numeric values as fax number!")
			document.forms[0].ctl00_MainContent_txtFaxtail.focus();
			return false;
		}	
		if(document.forms[0].ctl00_MainContent_txtEmail.value == ""){
			alert("Please enter email address!");
			document.forms[0].ctl00_MainContent_txtEmail.focus();
			return false;
		}
	
		if(document.forms[0].ctl00_MainContent_txtEmail.value != "" && document.forms[0].ctl00_MainContent_txtEmail.value != null && (document.all['ctl00_MainContent_txtEmail'].value.match(/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/)==null)){
			alert("Please enter a valid Email Address!");
			document.forms[0].ctl00_MainContent_txtEmail.focus();
			return false;
		}	
		
		if(document.forms[0].ctl00_MainContent_txtStNo.value == ""){
			alert("Please enter street no!");
			document.forms[0].ctl00_MainContent_txtStNo.focus();
			return false;
		}
		if(document.forms[0].ctl00_MainContent_txtStNo.value!="" && isNaN(document.forms[0].ctl00_MainContent_txtStNo.value)){
			alert("Please enter numeric values as Street No!");
			document.forms[0].ctl00_MainContent_txtStNo.focus();
			return false;
		}
		if(document.forms[0].ctl00_MainContent_txtStName.value == ""){
			alert("Please enter street name!");
			document.forms[0].ctl00_MainContent_txtStName.focus();
			return false;
		}
		/*if(document.forms[0].ctl00_MainContent_txtAuxAddress.value == ""){
			alert("Please enter street address 2!");
			document.forms[0].ctl00_MainContent_txtAuxAddress.focus();
			return false;
		}*/
		if(document.forms[0].ctl00_MainContent_txtCity.value == ""){
			alert("Please enter city!");
			document.forms[0].ctl00_MainContent_txtCity.focus();
			return false;
		}
		if(document.forms[0].ctl00_MainContent_txtState.value == ""){
			alert("Please enter state!");
			document.forms[0].ctl00_MainContent_txtState.focus();
			return false;
		}
		if(document.forms[0].ctl00_MainContent_txtZip.value==""){
			alert("Please enter Zip Code!");
		    document.forms[0].ctl00_MainContent_txtZip.focus();
		    return false;
		}
		if(isNaN(document.forms[0].ctl00_MainContent_txtZip.value)){
			alert("Please enter numeric values as zip number!");
			document.forms[0].ctl00_MainContent_txtZip.focus();
			return false;
		}

		return true;	
		
		
	}
	
	
	function admin_user_batchValidate()
	{
	    if(document.all['ctl00_MainContent_txtNewpwd'].value.length < 6 ){
			alert('Password requires at least 6 characters!');
			document.all['ctl00_MainContent_txtNewpwd'].focus();
			return false;
		}
		if (document.all['ctl00_MainContent_txtNewpwd'].value != document.all['ctl00_MainContent_txtConfpwd'].value) {
			alert('Password do not match!');
			document.all['ctl00_MainContent_txtConfpwd'].focus();
			return false;
		}
		if(document.getElementById("ctl00_MainContent_txtFname").value == ""){
			alert("Please enter first name!");
			document.getElementById("ctl00_MainContent_txtFname").focus();
			return false;
		}
		if(document.getElementById("ctl00_MainContent_txtLname").value == ""){
			alert("Please enter last name!");
			document.getElementById("ctl00_MainContent_txtLname").focus();
			return false;
			
		}
		if(document.getElementById("ctl00_MainContent_txtUserName").value == ""){
			alert("Please enter User Name!");
			document.getElementById("ctl00_MainContent_txtUserName").focus();
			return false;
		}
		if(document.forms[0].ctl00_MainContent_txtEmail.value == ""){
			alert("Please enter email address!");
			document.forms[0].ctl00_MainContent_txtEmail.focus();
			return false;
		}
	
		if(document.forms[0].ctl00_MainContent_txtEmail.value != "" && document.forms[0].ctl00_MainContent_txtEmail.value != null && (document.all['ctl00_MainContent_txtEmail'].value.match(/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/)==null)){
			alert("Please enter a valid Email Address!");
			document.forms[0].ctl00_MainContent_txtEmail.focus();
			return false;
		}
	}
	
	
	function admin_user_reset()
	{
	    document.getElementById("ctl00_MainContent_txtEmail").value ="";
	    document.getElementById("ctl00_MainContent_txtUserName").value ="";
	    document.getElementById("ctl00_MainContent_txtFname").value ="";
	    document.getElementById("ctl00_MainContent_txtLname").value ="";
	    document.all['ctl00_MainContent_txtNewpwd'].value ="";
	    document.all['ctl00_MainContent_txtConfpwd'].value="";
	    return false;
	    
	}
	
	////////////////////////////////////////////
	function add_admin_user_batchValidate()
	{
	    if(document.getElementById("ctl00_MainContent_txtUserName").value == ""){
			alert("Please enter User Name!");
			document.getElementById("ctl00_MainContent_txtUserName").focus();
			return false;
		}
	    if(document.all['ctl00_MainContent_txtNewpwd'].value.length < 6 ){
			alert('Password requires at least 6 characters!');
			document.all['ctl00_MainContent_txtNewpwd'].focus();
			return false;
		}
		if (document.all['ctl00_MainContent_txtNewpwd'].value != document.all['ctl00_MainContent_txtConfpwd'].value) {
			alert('Password do not match!');
			document.all['ctl00_MainContent_txtConfpwd'].focus();
			return false;
		}
		if(document.getElementById("ctl00_MainContent_txtFname").value == ""){
			alert("Please enter first name!");
			document.getElementById("ctl00_MainContent_txtFname").focus();
			return false;
		}
		if(document.getElementById("ctl00_MainContent_txtLname").value == ""){
			alert("Please enter last name!");
			document.getElementById("ctl00_MainContent_txtLname").focus();
			return false;
			
		}
		if(document.getElementById("ctl00_MainContent_ddlMonth").selectedIndex == 0){
			alert("Please select mouth!");
			document.getElementById("ctl00_MainContent_ddlMonth").focus();
			return false;
			
		}
		if(document.getElementById("ctl00_MainContent_ddlDay").selectedIndex == 0){
			alert("Please select day!");
			document.getElementById("ctl00_MainContent_ddlDay").focus();
			return false;
			
		}
		if(document.getElementById("ctl00_MainContent_ddlYear").selectedIndex == 0){
			alert("Please select Year!");
			document.getElementById("ctl00_MainContent_ddlYear").focus();
			return false;
			
		}
		
		if(document.forms[0].ctl00_MainContent_txtEmail.value == ""){
			alert("Please enter email address!");
			document.forms[0].ctl00_MainContent_txtEmail.focus();
			return false;
		}
	
		if(document.forms[0].ctl00_MainContent_txtEmail.value != "" && document.forms[0].ctl00_MainContent_txtEmail.value != null && (document.all['ctl00_MainContent_txtEmail'].value.match(/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/)==null)){
			alert("Please enter a valid Email Address!");
			document.forms[0].ctl00_MainContent_txtEmail.focus();
			return false;
		}
	}
	
	/*********************************************************************************
**function:trim
**Description:delte the leading space and the space tail
**Input:s
**Output:s
**11/23/04 - Created (eJay)
*********************************************************************************/
function trim(s)
{
    if (s == null)
    {
        return s;
    }

    var i;
    var beginIndex = 0;
    var endIndex = s.length - 1;

    for (i=0; i<s.length; i++)
    {
        if (s.charAt(i) == ' ' || s.charAt(i) == '　')
        {
            beginIndex++;
        }
        else
        {
            break;
        }
    }

    for (i = s.length - 1; i >= 0; i--)
    {
        if (s.charAt(i) == ' ' || s.charAt(i) == '　')
        {
            endIndex--;
        }
        else
        {
            break;
        }
    }

    if (endIndex < beginIndex)
    {
        return "";
    }

    return s.substring(beginIndex, endIndex + 1);
}



//author jiafeng
function changedate()
{
    var daysInMonth = new Array(31, 28, 31, 30, 31, 30, 31, 31,30, 31, 30, 31);
    var mouth=document.getElementById("ctl00_MainContent_ddlMonth").selectedIndex;
    var indyear=document.getElementById("ctl00_MainContent_ddlYear").selectedIndex;
    var year=document.getElementById("ctl00_MainContent_ddlYear").options[indyear].value;
    
    
    if(mouth*indyear>0){
      var flag=isLeapYear(parseInt(year));
      document.getElementById("ctl00_MainContent_ddlDay").length = 0;
      var length=daysInMonth[mouth-1];
      if((mouth==2)&&(flag==true)){
        length=length+1;
      }
      document.getElementById("ctl00_MainContent_ddlDay").options[0] = new Option("Day","");
      var j;
      for(j=1;j<=length;j++)
      {
        document.getElementById("ctl00_MainContent_ddlDay").options[j] = new Option(j,j);
      }
    }
  
    
}

function isLeapYear(oYear)
{
  if(oYear%4!=0){
    return false;
  }
  if (((oYear%4==0) && (oYear% 00!=0)) || (oYear%400==0)) {
        return true;
  }
  else{
        return false;
  }
    
}
function reset_user_profile_value()
{
     try{
        document.getElementById("ctl00_MainContent_txtUserName").value="";
        document.getElementById("ctl00_MainContent_txtNewpwd").value="";
        document.getElementById("ctl00_MainContent_txtConfpwd").value="";
        document.getElementById("ctl00_MainContent_txtFname").value="";
        document.getElementById("ctl00_MainContent_txtLname").value="";
        document.getElementById("ctl00_MainContent_txtEmail").value="";
        document.getElementById("ctl00_MainContent_ddlAdminFlag").selectedIndex=0;
        document.getElementById("ctl00_MainContent_ddlMonth").selectedIndex=0;
        document.getElementById("ctl00_MainContent_ddlDay").selectedIndex=0;
        document.getElementById("ctl00_MainContent_ddlYear").selectedIndex=0;
        
     }
     catch(ex)
     {
       
        //dothingt
     }
      return false
}


function agent_new_user_Validate()
{   
     if(document.getElementById("ctl00_MainContent_txtUserName").value == ""){
			alert("Please enter User Name!");
			document.getElementById("ctl00_MainContent_txtUserName").focus();
			return false;
		}
	    if(document.all['ctl00_MainContent_txtNewpwd'].value.length < 6 ){
			alert('Password requires at least 6 characters!');
			document.all['ctl00_MainContent_txtNewpwd'].focus();
			return false;
		}
		if (document.all['ctl00_MainContent_txtNewpwd'].value != document.all['ctl00_MainContent_txtConfpwd'].value) {
			alert('Password do not match!');
			document.all['ctl00_MainContent_txtConfpwd'].focus();
			return false;
		}
		if(document.getElementById("ctl00_MainContent_txtFname").value == ""){
			alert("Please enter first name!");
			document.getElementById("ctl00_MainContent_txtFname").focus();
			return false;
		}
		if(document.getElementById("ctl00_MainContent_txtLname").value == ""){
			alert("Please enter last name!");
			document.getElementById("ctl00_MainContent_txtLname").focus();
			return false;
			
		}
		
		 if(document.forms[0].ctl00_MainContent_txtPhoneArea.value == ""){
			alert("Please enter a primary phone number!")
			document.forms[0].ctl00_MainContent_txtPhoneArea.focus();
			return false;
		}		
		if(isNaN(document.forms[0].ctl00_MainContent_txtPhoneArea.value)){
			alert("Please enter numeric values as phone number");
			document.forms[0].ctl00_MainContent_txtPhoneArea.focus();
			return false;
		}
		if(document.forms[0].ctl00_MainContent_txtPhoneFront.value == ""){
			alert("Please enter a primary phone number!")
			document.forms[0].ctl00_MainContent_txtPhoneFront.focus();
			return false;
		}
		if(isNaN(document.forms[0].ctl00_MainContent_txtPhoneFront.value)){
			alert("Please enter numeric values as phone number");
			document.forms[0].ctl00_MainContent_txtPhoneFront.focus();
			return false;
		}		
		if(document.forms[0].ctl00_MainContent_txtPhonetail.value == ""){
			alert("Please enter a primary phone number!")
			document.forms[0].ctl00_MainContent_txtPhonetail.focus();
			return false;
		}
		if(isNaN(document.forms[0].ctl00_MainContent_txtPhonetail.value)){
			alert("Please enter numeric values as phone number");
			document.forms[0].ctl00_MainContent_txtPhonetail.focus();
			return false;
		}
		if(isNaN(document.forms[0].ctl00_MainContent_txtPhoneext.value)){
			alert("Please enter numeric values as phone ext!");
			document.forms[0].ctl00_MainContent_txtPhoneext.focus();
			return false;
		}
	
		if(document.getElementById("ctl00_MainContent_ddlMonth").selectedIndex == 0){
			alert("Please select mouth!");
			document.getElementById("ctl00_MainContent_ddlMonth").focus();
			return false;
			
		}
		if(document.getElementById("ctl00_MainContent_ddlDay").selectedIndex == 0){
			alert("Please select day!");
			document.getElementById("ctl00_MainContent_ddlDay").focus();
			return false;
			
		}
		if(document.getElementById("ctl00_MainContent_ddlYear").selectedIndex == 0){
			alert("Please select Year!");
			document.getElementById("ctl00_MainContent_ddlYear").focus();
			return false;
			
		}	
		if(document.forms[0].ctl00_MainContent_txtEmail.value == ""){
			alert("Please enter email address!");
			document.forms[0].ctl00_MainContent_txtEmail.focus();
			return false;
		}
	
		if(document.forms[0].ctl00_MainContent_txtEmail.value != "" && document.forms[0].ctl00_MainContent_txtEmail.value != null && (document.all['ctl00_MainContent_txtEmail'].value.match(/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/)==null)){
			alert("Please enter a valid Email Address!");
			document.forms[0].ctl00_MainContent_txtEmail.focus();
			return false;
		}
    
}

function reset_agent_profile_value()
{
     try{
        document.getElementById("ctl00_MainContent_txtUserName").value="";
        document.getElementById("ctl00_MainContent_txtNewpwd").value="";
        document.getElementById("ctl00_MainContent_txtConfpwd").value="";
        document.getElementById("ctl00_MainContent_txtFname").value="";
        document.getElementById("ctl00_MainContent_txtLname").value="";
        document.getElementById("ctl00_MainContent_txtEmail").value=""; 
        document.getElementById("ctl00_MainContent_ddlMonth").selectedIndex=0;
        document.getElementById("ctl00_MainContent_ddlDay").selectedIndex=0;
        document.getElementById("ctl00_MainContent_ddlYear").selectedIndex=0;
        document.getElementById("ctl00_MainContent_txtPhoneArea").value="";
        document.getElementById("ctl00_MainContent_txtPhoneFront").value="";
        document.getElementById("ctl00_MainContent_txtPhonetail").value="";
        document.getElementById("ctl00_MainContent_txtPhoneext").value="";
        
     }
     catch(ex)
     {
       
        //dothingt
     }
      return false
}

function affiliate_user_Validate()
{   
        if(document.getElementById("ctl00_MainContent_txtName").value == ""){
			alert("Please enter  Name!");
			document.getElementById("ctl00_MainContent_txtName").focus();
			return false;
		}
        if(document.getElementById("ctl00_MainContent_txtUserName").value == ""){
			alert("Please enter User Name!");
			document.getElementById("ctl00_MainContent_txtUserName").focus();
			return false;
		}
	    if(document.all['ctl00_MainContent_txtNewpwd'].value.length < 6 ){
			alert('Password requires at least 6 characters!');
			document.all['ctl00_MainContent_txtNewpwd'].focus();
			return false;
		}
		if (document.all['ctl00_MainContent_txtNewpwd'].value != document.all['ctl00_MainContent_txtConfpwd'].value) {
			alert('Password do not match!');
			document.all['ctl00_MainContent_txtConfpwd'].focus();
			return false;
		}
		
		 if(document.forms[0].ctl00_MainContent_txtPhoneArea.value == ""){
			alert("Please enter a primary phone number!")
			document.forms[0].ctl00_MainContent_txtPhoneArea.focus();
			return false;
		}		
		if(isNaN(document.forms[0].ctl00_MainContent_txtPhoneArea.value)){
			alert("Please enter numeric values as phone number");
			document.forms[0].ctl00_MainContent_txtPhoneArea.focus();
			return false;
		}
		if(document.forms[0].ctl00_MainContent_txtPhoneFront.value == ""){
			alert("Please enter a primary phone number!")
			document.forms[0].ctl00_MainContent_txtPhoneFront.focus();
			return false;
		}
		if(isNaN(document.forms[0].ctl00_MainContent_txtPhoneFront.value)){
			alert("Please enter numeric values as phone number");
			document.forms[0].ctl00_MainContent_txtPhoneFront.focus();
			return false;
		}		
		if(document.forms[0].ctl00_MainContent_txtPhonetail.value == ""){
			alert("Please enter a primary phone number!")
			document.forms[0].ctl00_MainContent_txtPhonetail.focus();
			return false;
		}
		if(isNaN(document.forms[0].ctl00_MainContent_txtPhonetail.value)){
			alert("Please enter numeric values as phone number");
			document.forms[0].ctl00_MainContent_txtPhonetail.focus();
			return false;
		}		
		if(document.getElementById("ctl00_MainContent_ddlAffiliateName").selectedIndex == 0){
			alert("Please select affiliate name!");
			document.getElementById("ctl00_MainContent_ddlAffiliateName").focus();
			return false;
			
		}
		
}


function reset_Affliate_profile_value()
{
     try{
        document.getElementById("ctl00_MainContent_txtUserName").value="";
        document.getElementById("ctl00_MainContent_txtNewpwd").value="";
        document.getElementById("ctl00_MainContent_txtConfpwd").value="";
        document.getElementById("ctl00_MainContent_txtName").value="";
        document.getElementById("ctl00_MainContent_ddlAffiliateName").selectedIndex=0;
        document.getElementById("ctl00_MainContent_txtPhoneArea").value="";
        document.getElementById("ctl00_MainContent_txtPhoneFront").value="";
        document.getElementById("ctl00_MainContent_txtPhonetail").value="";

        
     }
     catch(ex)
     {
       
        //dothingt
     }
      return false
}

function batchValidate(verifyCC){
    //##    1/25/2008   Change from "CheckPassword" to "batchValidate"  (yang)
    if(document.getElementById("ctl00_content_password0").value=="" || document.getElementById("ctl00_content_password0").value.length==0){
        alert('Plese enter Current Password!');
        document.getElementById("ctl00_content_password0").focus();
        return false;
    }else if(document.getElementById("ctl00_content_password1").value!="" || document.getElementById("ctl00_content_password1").value.length>0){   
        if(document.getElementById("ctl00_content_password1").value=="" || document.getElementById("ctl00_content_password1").value.length==0){
            alert('please enter New Password!');
            document.getElementById("ctl00_content_password1").focus();
            return false;
        }else if (document.getElementById("ctl00_content_password2").value=="" || document.getElementById("ctl00_content_password2").value.length==0){
            alert('please enter New Confirm Password!');
            document.getElementById("ctl00_content_password2").focus();
            return false;
        }else if (document.getElementById("ctl00_content_password2").value!=document.getElementById("ctl00_content_password1").value){
            alert('New Password and Confirm Password!');
            document.getElementById("ctl00_content_password2").focus();
            return false;
        }
    }
    if (document.getElementById("ctl00_content_ddlCardType").selectedIndex==0){
        alert('Please select the credit card type');
        document.getElementById("ctl00_content_ddlCardType").focus();
        return false;
    }
    if(document.getElementById("ctl00_content_txtCardNo").value !="" && document.getElementById("ctl00_content_txtCardNo").value.length > 0){
		 if(document.getElementById("ctl00_content_txtCardNo").value.length !=15 && document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text == "AMEX"){
			alert("AMEX has 15 digits! Please re-enter.");
			document.getElementById("ctl00_content_txtCardNo").focus();
			return false;
		}else if(document.getElementById("ctl00_content_txtCardNo").value.length > 0 && document.getElementById("ctl00_content_txtCardNo").value.length !=16 && document.getElementById("ctl00_content_ddlCardType").selectedIndex != 0 && (document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text == "VISA" || document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text == "MASTERCARD")){
			alert("VISA and MASTERCARD has 16 digits! Please re-enter.");
			document.getElementById("ctl00_content_txtCardNo").focus();
			return false;
		}else if(document.getElementById("ctl00_content_txtCardNo").value.length > 0 && document.getElementById("ctl00_content_txtCardNo").value.length !=15 && document.getElementById("ctl00_content_ddlCardType").selectedIndex != 0 && (document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text == "AMEX" || document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text == "DINERS")){
			alert("'AMEX' and 'DINERS' should be 15 digits!");
			document.getElementById("ctl00_content_txtCardNo").focus();
			return false;
		}else if(document.getElementById("ctl00_content_txtCardNo").value.length !=16 && document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text != "AMEX" && document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text != "DINERS"){
			alert("Credit Card Number must be 16 digits!");
			document.getElementById("ctl00_content_txtCardNo").focus();
			return false;
		}else if(isNaN(document.getElementById("ctl00_content_txtCardNo").value)){
			alert("Please enter numeric values as credit card no!");
			document.getElementById("ctl00_content_txtCardNo").focus();
			return false;
		}else if(document.getElementById("ctl00_content_txtCardNo").value.length > 0 && (document.getElementById("ctl00_content_ddlExpMonth").selectedIndex == 0 || document.getElementById("ctl00_content_ddlExpYear").selectedIndex == 0 )){
			alert("Please enter the credit card expiration date!");
			if(document.getElementById("ctl00_content_ddlExpMonth").selectedIndex == 0){
				document.getElementById("ctl00_content_ddlExpMonth").focus();
			}else{
				document.getElementById("ctl00_content_ddlExpYear").focus();
			}
			    return false;
		    }
		}else if(document.getElementById("ctl00_content_ddlExpMonth").selectedIndex == 0 || document.getElementById("ctl00_content_ddlExpYear").selectedIndex ==0){
			alert("Please enter the credit card expiration date!");
			if(document.getElementById("ctl00_content_ddlExpMonth").selectedIndex == 0){
				document.getElementById("ctl00_content_ddlExpMonth").focus();
			}
			else{
				document.getElementById("ctl00_content_ddlExpYear").focus();
			}
			return false;
	    }
	    if(document.getElementById("ctl00_content_ddlExpMonth").selectedIndex == 0 || document.getElementById("ctl00_content_ddlExpYear").selectedIndex ==0){
		    alert("Please enter the credit card expiration date!");
		    if(document.getElementById("ctl00_content_ddlExpMonth").selectedIndex == 0){
			    document.getElementById("ctl00_content_ddlExpMonth").focus();
		    }else{
			    document.getElementById("ctl00_content_ddlExpYear").focus();
		    }
		    return false;
        }
		if (document.getElementById("ctl00_content_txtCardNo").value!="" && document.getElementById("ctl00_content_txtCardNo").value.length>12){
            document.getElementById("ctl00_content_hidcardno").value=document.getElementById("ctl00_content_txtCardNo").value;
        }else{
            //do nothing
        }

		var cc_no = document.getElementById("ctl00_content_txtCardNo").value;
		var cc_exp = document.getElementById("ctl00_content_ddlExpMonth").options[document.getElementById("ctl00_content_ddlExpMonth").selectedIndex].value +
		                document.getElementById("ctl00_content_ddlExpYear").options[document.getElementById("ctl00_content_ddlExpYear").selectedIndex].value;
		var cc_type = document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].value;
		
		if (cc_no.length>0 && (verifyCC==null || verifyCC==true)){
		    VerifyCC(null,cc_no,cc_exp,cc_type,"2")   //##    1/24/2008   (yang)
		}else{
		    document.getElementById("ctl00_content_SubmitHide").click();}
		    
		return false;
}

function check_search_max_length(){ 
    if (document.getElementById("ctl00_content_ddlCardType").selectedIndex==0){
        alert('Please select the credit card type');
        document.getElementById("ctl00_content_ddlCardType").focus();
    }

    var checkcardtype=document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].value;
    if (checkcardtype==1){
        document.getElementById("ctl00_content_txtCardNo").maxLength=15;
        //document.getElementById("ctl00_content_txtvcode").maxLength=4;
    }else if (checkcardtype==3){
        document.getElementById("ctl00_content_txtCardNo").maxLength=15;    //modify by daniel for change to 15 length. 15/08/2007
        //document.getElementById("ctl00_content_txtvcode").maxLength=15;
    }else if (checkcardtype==2||checkcardtype==4||checkcardtype==5||checkcardtype==6){
        document.getElementById("ctl00_content_txtCardNo").maxLength=16;
        //document.getElementById("ctl00_content_txtvcode").maxLength=3;
     }  
     
}

/********************************************************
**funciton add by daniel for some entervalues 12/14/2006
********************************************************/
function entervalues(){

	if(event.keyCode==44){
		event.returnValue=false;		
	}else if (event.keyCode==39){
		event.returnValue=false;	
	}	
}