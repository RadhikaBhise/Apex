 /****************************************************
 ** Function set_defaultinfo_pageload()
 ** Description:when the page load 
 ** Input:
 ** Output:
 ** 12/06/04 - Created(jack)
 ****************************************************/ 
 function set_defaultinfo_pageload()
 {var type=document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].value
  document.all["ctl00_content_hidcctype" + type].value=document.getElementById("ctl00_content_txtCardNo").value + "/" +document.getElementById("ctl00_content_ddlMonth").selectedIndex + "/" + document.getElementById("ctl00_content_ddlYear").selectedIndex;

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
 
 /*var type=document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType")").selectedIndex]").value
 if (type==0){document.getElementById("ctl00_content_txtCardNo")").value="";
				document.getElementById("ctl00_content_ddlMonth")").selectedIndex=0;
				document.getElementById("ctl00_content_ddlYear")").selectedIndex=0;}

 else{
 
				if (document.all["ctl00_content_hidcctype" + type]").value.length==0)
				{ document.getElementById("ctl00_content_txtCardNo")").value="";
				document.getElementById("ctl00_content_ddlMonth")").selectedIndex=0;
				document.getElementById("ctl00_content_ddlYear")").selectedIndex=0;
				}
				else{
				var arr=document.all["ctl00_content_hidcctype" + type]").value.split('/')
				document.getElementById("ctl00_content_txtCardNo")").value=arr[0];
				document.getElementById("ctl00_content_ddlMonth")").selectedIndex=arr[1];
				document.getElementById("ctl00_content_ddlYear")").selectedIndex=arr[2];
				}
   
   }*/

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
 /*
 var type=document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType")").selectedIndex]").value
  document.all["ctl00_content_hidcctype" + type]").value=document.getElementById("ctl00_content_txtCardNo")").value + "/" +document.getElementById("ctl00_content_ddlMonth")").selectedIndex + "/" + document.getElementById("ctl00_content_ddlYear")").selectedIndex;
 */
 }



	
/*********************************************************************************
**function:check_max_length
**Description:delte the leading space and the space tail
**Input:s
**Output:s
**11/23/04 - Created (jack)
*********************************************************************************/
function check_max_length()
{ 
if (document.getElementById("ctl00_content_ddlCardType").selectedIndex==0)
{alert('Please select the credit card type');
document.getElementById("ctl00_content_ddlCardType").focus();
}

  var checkcardtype=document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].value

  if (checkcardtype==1||checkcardtype==3)
    {document.getElementById("ctl00_content_txtCardNo").maxLength=15;
     
     }
    if (checkcardtype==2||checkcardtype==4||checkcardtype==5||checkcardtype==6)
    {document.getElementById("ctl00_content_txtCardNo").maxLength=16;
     }
}





/********************************************************************
**function:FillText
**Description:Fill the user name textbox
**Input:
**Output:
**11/19/04 - Created (eJay)
********************************************************************/
function FillText(){
	if (document.getElementById("ctl00_content_ckUserName").checked){
		document.getElementById("ctl00_content_txtUserName").value="";
		var index=document.getElementById("ctl00_content_ckUserName").sourceIndex+1
		//alert(document.all[index].innerText);
		document.getElementById("ctl00_content_txtUserName").value=document.getElementById("index").innerText;
	}
	else{
		document.getElementById("ctl00_content_txtUserName").value="";
	}
}

///********************************************************************
//**function:ShowName
//**Description:check whether to show name recommend
//**Input:
//**Output:
//**11/19/04 - Created (eJay)
//********************************************************************/
//function ShowName(){
//	 if(typeof(document.getElementById("lblShow"))=='undefined' ){
//			document.getElementById("trShow").style.display='none';

//	 }
//	 else
//	 {	document.getElementById("trShow").style.display='';

//	 }
//}

/********************************************************************
**function:ClearAll
**Description:ClearAll
**Input:
**Output:
**11/18/04 - Created (eJay)
********************************************************************/
function ClearAll(){
	//alert(document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType")").selectedIndex].text);
	document.getElementById("ctl00_content_txtUserName").value = "";
	document.getElementById("ctl00_content_txtFname").value = "";
	document.getElementById("ctl00_content_txtLname").value = "";
	document.getElementById("ctl00_content_txtPwd").value = "";
	document.getElementById("ctl00_content_txtConfpwd").value ="";
	document.getElementById("ctl00_content_txtStNo").value ="";
	document.getElementById("ctl00_content_txtZip").value="";
	document.getElementById("ctl00_content_txtEmail").value = "";
	document.getElementById("ctl00_content_txtPhoneArea").value = "";
	document.getElementById("ctl00_content_txtPhoneFront").value = "";
	document.getElementById("ctl00_content_txtPhonetail").value = "";
	document.getElementById("ctl00_content_txtCellPhoneArea").value = "";
	document.getElementById("ctl00_content_txtCellPhoneFront").value = "";
	document.getElementById("ctl00_content_txtCellPhonetail").value = "";
	document.getElementById("ctl00_content_txtCardNo").value="";
	document.getElementById("ctl00_content_txtPhoneext").value="";
	document.getElementById("ctl00_content_ddlMonth").selectedIndex = 0;
	document.getElementById("ctl00_content_ddlYear").selectedIndex = 0;
	document.getElementById("ctl00_content_ddlCardType").selectedIndex = 0;
	document.getElementById("ctl00_content_txtStName").value="";
	document.getElementById("ctl00_content_txtCity").value="";
	document.getElementById("ctl00_content_txtState").value="";
	document.getElementById("ctl00_content_txtFullName").value="";
	//document.getElementById("txtContact").value="";
	document.getElementById("ctl00_content_txtFaxArea").value = "";
	document.getElementById("ctl00_content_txtFaxFront").value = "";
	document.getElementById("ctl00_content_txtFaxtail").value = "";
	//document.getElementById("txtCountry").value="";
	document.getElementById("ctl00_content_txtAuxAddress").value="";
}

/********************************************************************
**function:batchValidate
**Description:For admin_profile_Add page validating
**Input:
**Output:
**11/17/04 - Created (eJay)
********************************************************************/

function batchValidate(verifyCC){

		if(document.getElementById("ctl00_content_txtFname").value == ""){
			alert("Please enter first name!");
			document.getElementById("ctl00_content_txtFname").focus();
			return false;
		}
		if(document.getElementById("ctl00_content_txtLname").value == ""){
			alert("Please enter last name!");
			document.getElementById("ctl00_content_txtLname").focus();
			return false;
		}
		if(document.getElementById("ctl00_content_txtCompany").value == ""){
			alert("Please enter Company!");
			document.getElementById("ctl00_content_txtCompany").focus();
			return false;
		}
		if(document.getElementById("ctl00_content_txtUsername").value == "" ){
		    alert("Please enter a user name.");
		    document.getElementById("ctl00_content_txtUsername").focus();
		    return false;
	    }
	    if(document.getElementById("ctl00_content_txtUsername").value.length < 4){
		    alert("User name must be at least 4 characters.");
		    document.getElementById("ctl00_content_txtUsername").focus();
		    return false;
	    }
	    if(document.getElementById("ctl00_content_txtPassword").value.length < 3){
		    alert("Password must be at least 3 characters.");
		    document.getElementById("ctl00_content_txtPassword").focus();
		    return false;
	    }
	    if(document.getElementById("ctl00_content_txtPassword").value != document.getElementById("ctl00_content_txtConfir").value){
		    alert("Password and confirmed password do not match.");
		    document.getElementById("ctl00_content_txtConfir").focus();
		    return false;
	    }
	    if(document.getElementById("ctl00_content_txtUsername").value == document.getElementById("ctl00_content_txtPassword").value){
		    alert("Username may not be the same as your password.");
		    document.getElementById("ctl00_content_txtPassword").focus();
		    return false;
	    }
		if(document.getElementById("ctl00_content_txtPhoneArea").value == ""){
			alert("Please enter full telephone information with area code!")
			document.getElementById("ctl00_content_txtPhoneArea").focus();
			return false;
		}		
		if(isNaN(document.getElementById("ctl00_content_txtPhoneArea").value)){
			alert("Please enter numeric values as phone number");
			document.getElementById("ctl00_content_txtPhoneArea").focus();
			return false;
		}
		/*if (document.getElementById("ctl00_content_txtPhoneArea").value.length!=3)
		{
		    alert("Phone Number must be 3 digits (i.e. ###)!");
			document.getElementById("ctl00_content_txtPhoneArea").focus();
			return false;
		}
		if(document.getElementById("ctl00_content_txtPhoneFront").value == ""){
			alert("Please enter full telephone information with area code!")
			document.getElementById("ctl00_content_txtPhoneFront").focus();
			return false;
		}
		if(isNaN(document.getElementById("ctl00_content_txtPhoneFront").value)){
			alert("Please enter numeric values as phone number");
			document.getElementById("ctl00_content_txtPhoneFront").focus();
			return false;
		}		
		if (document.getElementById("ctl00_content_txtPhoneFront").value.length!=7)
		{
		    alert("Phone Number must be 7 digits (i.e. #######)!");
			document.getElementById("ctl00_content_txtPhoneFront").focus();
			return false;
		}*/
//		if(document.getElementById("ctl00_content_txtPhonetail").value == ""){
//			alert("Please enter full telephone information with area code!")
//			document.getElementById("ctl00_content_txtPhonetail").focus();
//			return false;
//		}
		if(isNaN(document.getElementById("ctl00_content_txtPhonetail").value)){
			alert("Please enter numeric values as phone number");
			document.getElementById("ctl00_content_txtPhonetail").focus();
			return false;
		}
//		if(document.getElementById("ctl00_content_txtPhoneArea").value.length!=3||document.getElementById("ctl00_content_txtPhoneFront").value.length!=7)
//		{alert("Please enter full telephone information with area code!");
//			document.getElementById("ctl00_content_txtPhoneArea").focus();
//			return false;		
//		}
		/*if (document.getElementById("ctl00_content_txtPhonetail").value!="" && document.getElementById("ctl00_content_txtPhonetail").value.length!=5)
		{
		    alert("Phone Number must be 5 digits (i.e. #####)!");
			document.getElementById("ctl00_content_txtPhonetail").focus();
			return false;
		}*/
        if (document.getElementById("ctl00_content_txtPhonetail").value!="" && document.getElementById("ctl00_content_txtPhonetail").value.length>5){
            alert("Phone Number Ext must be less than 5 digits (i.e.#####)!");
            document.getElementById("ctl00_content_txtPhonetail").focus();
            return false;
        }		
		/*if(document.getElementById("ctl00_content_txtCellPhoneArea").value == ""){
			alert("Please enter a cell phone!");
			document.getElementById("ctl00_content_txtCellPhoneArea").focus();
			return false;
		}*/
		if(document.getElementById("ctl00_content_txtCellPhoneArea").value != "" && isNaN(document.getElementById("ctl00_content_txtCellPhoneArea").value)){
			alert("lease enter full telephone information with area code!")
			document.getElementById("ctl00_content_txtCellPhoneArea").focus();
			return false;
		}
		/*if(document.getElementById("ctl00_content_txtCellPhoneFront").value == ""){
			alert("Please enter a cell phone!");
			document.getElementById("ctl00_content_txtCellPhoneFront").focus();
			return false;
		}*/
//		if(document.getElementById("ctl00_content_txtCellPhoneFront").value != "" && isNaN(document.getElementById("ctl00_content_txtCellPhoneFront").value)){
//			alert("Please enter numeric values as phone number!")
//			document.getElementById("ctl00_content_txtCellPhoneFront").focus();
//			return false;
//		}
		/*if(document.getElementById("ctl00_content_txtCellPhonetail").value == ""){
			alert("Please enter a cell phone!");
			document.getElementById("ctl00_content_txtCellPhonetail").focus();
			return false;
		}*/
//		if(document.getElementById("ctl00_content_txtCellPhonetail").value != "" && isNaN(document.getElementById("ctl00_content_txtCellPhonetail").value)){
//			alert("Please enter numeric values as phone number!")
//			document.getElementById("ctl00_content_txtCellPhonetail").focus();
//			return false;
//		}	
		if(document.getElementById("ctl00_content_ddlCardType").selectedIndex != 0 && document.getElementById("ctl00_content_txtCardNo").value.length == 0){
			alert('Please enter credit card No!');
			document.getElementById("ctl00_content_txtCardNo").focus();
			return false;			
		
		}
		/*add by daniel
		01/20/06*/
		if(document.getElementById("ctl00_content_ddlCardType").selectedIndex == 0){
			alert('Please select the credit card type!');
			document.getElementById("ctl00_content_ddlCardType").focus();
			return false;
		}
		if(document.getElementById("ctl00_content_txtCardNo").value.length !=15 && document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text == "AMEX"){
			alert("AMEX has 15 digits! Please re-enter.");
			document.getElementById("ctl00_content_txtCardNo").focus();
			return false;
		}
		if(document.getElementById("ctl00_content_txtCardNo").value.length > 0 && document.getElementById("ctl00_content_txtCardNo").value.length !=16 && document.getElementById("ctl00_content_ddlCardType").selectedIndex != 0 && (document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text == "VISA" || document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text == "MASTERCARD")){
			alert("VISA and MASTERCARD has 16 digits! Please re-enter.");
			document.getElementById("ctl00_content_txtCardNo").focus();
			return false;
		}
		//*****************************************************************END
		/*if(document.getElementById("ctl00_content_txtCardNo").value.length !=15 && document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType")").selectedIndex].text == "AMEX"){
			alert("'AMEX' should be limited to 15 digits!");
			document.getElementById("ctl00_content_txtCardNo").focus();
			return false;
		}*/
		//if(document.getElementById("ctl00_content_txtCardNo").value.length > 0 && document.getElementById("ctl00_content_txtCardNo").value.length <16 && document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType")").selectedIndex].text != "AMEX"){
		/*
		if(document.getElementById("ctl00_content_txtCardNo").value.length > 0 && document.getElementById("ctl00_content_txtCardNo").value.length <16 && document.getElementById("ctl00_content_ddlCardType")").selectedIndex != 0 && (document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType")").selectedIndex].text == "AMEX" || document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType")").selectedIndex].text == "DINERS")){
			alert("'AMEX' and 'DINERS' should be 16 digits!");
			document.getElementById("ctl00_content_txtCardNo").focus();
			return false;
		}
		if(document.getElementById("ctl00_content_txtCardNo").value.length !=15 && document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType")").selectedIndex].text != "AMEX" && document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType")").selectedIndex].text != "DINERS"){
			alert("Credit Card Number must be 15 digits!");
			document.getElementById("ctl00_content_txtCardNo").focus();
			return false;
		}
		*/
		if(document.getElementById("ctl00_content_txtCardNo").value.length > 0 && document.getElementById("ctl00_content_txtCardNo").value.length !=15 && document.getElementById("ctl00_content_ddlCardType").selectedIndex != 0 && (document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text == "AMEX" || document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text == "DINERS")){
			alert("'AMEX' and 'DINERS' should be 15 digits!");
			document.getElementById("ctl00_content_txtCardNo").focus();
			return false;
		}
		if(document.getElementById("ctl00_content_txtCardNo").value.length !=16 && document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text != "AMEX" && document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text != "DINERS"){
			alert("Credit Card Number must be 16 digits!");
			document.getElementById("ctl00_content_txtCardNo").focus();
			return false;
		}
		if(isNaN(document.getElementById("ctl00_content_txtCardNo").value)){
			alert("Please enter numeric values as credit card no!");
			document.getElementById("ctl00_content_txtCardNo").focus();
			return false;
		}
		if(document.getElementById("ctl00_content_txtCardNo").value.length > 0 && (document.getElementById("ctl00_content_ddlMonth").selectedIndex == 0 || document.getElementById("ctl00_content_ddlYear").selectedIndex == 0 )){
			alert("Please enter the credit card expiration date!");
			if(document.getElementById("ctl00_content_ddlMonth").selectedIndex == 0){
				document.getElementById("ctl00_content_ddlMonth").focus();
			}
			else{
				document.getElementById("ctl00_content_ddlYear").focus();
			}
			return false;
		}

		
		/*if(document.getElementById("txtFaxArea").value == ""){
			alert("Please enter a fax!");
			document.getElementById("txtFaxArea").focus();
			return false;
		}
		if(document.getElementById("ctl00_content_txtFaxArea").value != "" && isNaN(document.getElementById("ctl00_content_txtFaxArea").value)){
			alert("Please enter numeric values as fax number!")
			document.getElementById("ctl00_content_txtFaxArea").focus();
			return false;
		}*/
		/*if(document.getElementById("txtFaxFront").value == ""){
			alert("Please enter a fax!");
			document.getElementById("txtFaxFront").focus();
			return false;
		}*/
		/*if(document.getElementById("ctl00_content_txtFaxFront").value != "" && isNaN(document.getElementById("ctl00_content_txtFaxFront").value)){
			alert("Please enter numeric values as fax number!")
			document.getElementById("ctl00_content_txtFaxFront").focus();
			return false;
		}
		if(document.getElementById("txtFaxtail").value == ""){
			alert("Please enter a fax!");
			document.getElementById("txtFaxtail").focus();
			return false;
		}
		if(document.getElementById("ctl00_content_txtFaxtail").value != "" && isNaN(document.getElementById("ctl00_content_txtFaxtail").value)){
			alert("Please enter numeric values as fax number!")
			document.getElementById("ctl00_content_txtFaxtail").focus();
			return false;
		}*/	
		if(document.getElementById("ctl00_content_txtEmail").value == ""){
			alert("Please enter email address!");
			document.getElementById("ctl00_content_txtEmail").focus();
			return false;
		}
		if(document.getElementById("ctl00_content_txtEmail").value != "" && document.getElementById("ctl00_content_txtEmail").value != null && !isEmailValid(document.getElementById("ctl00_content_txtEmail").value)){
			alert("Please enter a valid Email Address!");
			document.getElementById("ctl00_content_txtEmail").focus();
			return false;
		}

		try{
			if(document.getElementById("ctl00_content_txtStNo").value == ""){
				alert("Please enter street no!");
				document.getElementById("ctl00_content_txtStNo").focus();
				return false;
			}
			
			if(document.getElementById("ctl00_content_txtStNo").value!="" && isNaN(document.getElementById("ctl00_content_txtStNo").value)){
				alert("Please enter numeric values as Street No!");
				document.getElementById("ctl00_content_txtStNo").focus();
				return false;
			}
		
			if(document.getElementById("ctl00_content_txtStName").value == ""){
				alert("Please enter street name!");
				document.getElementById("ctl00_content_txtStName").focus();
				return false;
			}
			
			/*if(document.getElementById("txtAuxAddress").value == ""){
				alert("Please enter street address 2!");
				document.getElementById("txtAuxAddress").focus();
				return false;
			}*/
			if(document.getElementById("ctl00_content_txtCity").value == ""){
				alert("Please enter city!");
				document.getElementById("ctl00_content_txtCity").focus();
				return false;
			}
			if(document.getElementById("ctl00_content_txtState").value == ""){
				alert("Please enter state!");
				document.getElementById("ctl00_content_txtState").focus();
				return false;
			}
			if(document.getElementById("ctl00_content_txtZip").value==""){
				alert("Please enter Zip Code!");
				document.getElementById("ctl00_content_txtZip").focus();
				return false;
			}
			if(isNaN(document.getElementById("ctl00_content_txtZip").value)){
				alert("Please enter numeric values as zip number!");
				document.getElementById("ctl00_content_txtZip").focus();
				return false;
			}
		}
		catch(e)
		{
			//alert("Passed!");
			
		}
		
		//return true;
		var cc_no = document.getElementById("ctl00_content_txtCardNo").value;
		var cc_exp = document.getElementById("ctl00_content_ddlMonth").options[document.getElementById("ctl00_content_ddlMonth").selectedIndex].value +
		                document.getElementById("ctl00_content_ddlYear").options[document.getElementById("ctl00_content_ddlYear").selectedIndex].value;
		var cc_type = document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].value;
		
		if (verifyCC==null || verifyCC==true){
		    VerifyCC(null,cc_no,cc_exp,cc_type,"2")   //##    1/24/2008   (yang)
		}else{
		    document.getElementById("ctl00_content_SubmitHide").click();}
		    
		return false;
	}

/*function isEmpty(field)
	{
		if(field").value == "" || field").value.length == 0){
			return true;
		}else{
			return false;
		}
	}
	function batchValidate()
	{
		if(isEmpty(document.getElementById("ctl00_content_txtFname)){
			alert("Please enter first name!");
			document.getElementById("ctl00_content_txtFname").focus();
			return false;
		}else if(isEmpty(document.getElementById("ctl00_content_txtLname)){
			alert("Please enter last name!");
			document.getElementById("ctl00_content_txtLname").focus();
			return false;
		}else if(isEmpty(document.getElementById("ctl00_content_txtCompany)){
			alert("Please enter company!");
			document.getElementById("ctl00_content_txtCompany").focus();
			return false;
	//	}else if(isEmpty(document.getElementById("acct_name)){
	//		alert("Please enter account name!");
	//		document.getElementById("acct_name").focus();
	//		return false;
		}else if(isEmpty(document.getElementById("area) || isEmpty(document.getElementById("phone)){
			alert("Please enter full telephone information with area code!");
			if(isEmpty(document.getElementById("area)) {
				document.getElementById("area").focus();
			}else if(isEmpty(document.getElementById("phone)){
				document.getElementById("phone").focus();
			}
			return false;
		}else if(!validPhone1(document.getElementById("area,document.getElementById("phone,document.getElementById("ext)){
			return false;
		// 8-10-05
		}else if(!isValidIntPhone(document.getElementById("home_phone)){
			alert("Please enter numeric values. Dashes and spaces are allowed");
			document.getElementById("home_phone").focus();
			return false;
		}else if(!isValidIntPhone(document.getElementById("pager)){
			alert("Please enter numeric values. Dashes and spaces are allowed");
			document.getElementById("pager").focus();
			return false;
		}else if(!isValidIntPhone(document.getElementById("phone_2)){
			alert("Please enter numeric values. Dashes and spaces are allowed");
			document.getElementById("phone_2").focus();
			return false;
		}else if(!isEmail(document.getElementById("email_add").value)){
			alert("Please enter a email address!");
			document.getElementById("email_add").focus();
			return false;
		}else if(document.getElementById("cc_no").value == ""){
			alert("Please enter a credit card number.");
			return false;
		}else if(document.getElementById("cc_month").selectedIndex == 0 ){
			alert("Please enter a credit card month.");
			return false;
		}else if(document.getElementById("cc_year").selectedIndex == 0 ){
			alert("Please enter a credit card year.");
			return false;
		}else if(document.getElementById("cc_type").selectedIndex == 0 ){
			alert("Please enter a credit card type.");
			return false;
		}
		
		if (document.getElementById("acct_id").value != ""){
			window.open('newuser_verifyacct.asp?acct_id=' + document.getElementById("acct_id").value,'verify_acct','height=300,width=300');
			return false;
		} else {
			//window.open('verify_cc_0.asp','verify_cc','height=300,width=300');			
			
		
		// 8-11/05 temp disable	
			verify_cc();
			
		}
		// 8-11/05 temp disable
		return false;
		// 8-11/05 temp turn on
		//document.getElementById("submit();
		//return true;
	}*/
	
function search_batchValidate1(){

		if(document.getElementById("ctl00_content_txtsname").value == "") {
			alert("User ID is required!");
			document.getElementById("ctl00_content_txtsname").focus();
			return false;
		} 
		if ((document.getElementById("ctl00_content_txtsname").value.toUpperCase())=="ADMIN"){
		  	alert("User ID can't be "+document.getElementById("ctl00_content_txtsname").value);
			document.getElementById("ctl00_content_txtsname").focus();
			return false;
		}	
		
		
	
		if (document.getElementById("ctl00_content_txtsname").value==document.getElementById("ctl00_content_txtspas").value){
		    alert('User Name and Password can not be the same. Please enter a new password.');
			document.getElementById("ctl00_content_txtspas").focus();
			return false;		
		}
	
		if(document.getElementById("ctl00_content_txtspas").value != document.getElementById("ctl00_content_txtsconpas").value){
			alert("Passwords do not match!");
			document.getElementById("ctl00_content_txtsconpas").focus();
			return false;
		}
		
		if(document.getElementById("ctl00_content_txtsfname").value == ""){
			alert("Please enter first name!");
			document.getElementById("ctl00_content_txtsfname").focus();
			return false;
		}
		if(document.getElementById("ctl00_content_txtslname").value == ""){
			alert("Please enter last name!");
			document.getElementById("ctl00_content_txtslname").focus();
			return false;
		}
		if(document.getElementById("ctl00_content_drpscard").selectedIndex == 0){
			alert('Please select the credit card type!');
			document.getElementById("ctl00_content_drpscard").focus();
			return false;
		}
		if(document.getElementById("ctl00_content_drpscard").selectedIndex != 0 && document.getElementById("ctl00_content_txtscardno").value.length == 0){
			alert('Please enter credit card No!');
			document.getElementById("ctl00_content_txtscardno").focus();
			return false;			
		
		}

		/*add by daniel
		01/20/06*/
		if(document.getElementById("ctl00_content_txtscardno").value.length !=15 && document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text == "AMEX"){
			alert("AMEX has 15 digits! Please re-enter.");
			document.getElementById("ctl00_content_txtscardno").focus();
			return false;
		}
		if(document.getElementById("ctl00_content_txtscardno").value.length > 0 && document.getElementById("ctl00_content_txtscardno").value.length !=16 && document.getElementById("ctl00_content_ddlCardType").selectedIndex != 0 && (document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text == "VISA" || document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text == "MASTERCARD")){
			alert("VISA and MASTERCARD has 16 digits! Please re-enter.");
			document.getElementById("ctl00_content_txtscardno").focus();
			return false;
		}
		//*****************************************************************END
		/*if(document.getElementById("txtscardno").value.length !=15 && document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType")").selectedIndex].text == "AMEX"){
			alert("'AMEX' should be limited to 15 digits!");
			document.getElementById("txtscardno").focus();
			return false;
		}*/
		//if(document.getElementById("txtscardno").value.length > 0 && document.getElementById("txtscardno").value.length <16 && document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType")").selectedIndex].text != "AMEX"){
		/*
		if(document.getElementById("txtscardno").value.length > 0 && document.getElementById("txtscardno").value.length <16 && document.getElementById("ctl00_content_ddlCardType")").selectedIndex != 0 && (document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType")").selectedIndex].text == "AMEX" || document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType")").selectedIndex].text == "DINERS")){
			alert("'AMEX' and 'DINERS' should be 16 digits!");
			document.getElementById("txtscardno").focus();
			return false;
		}
		if(document.getElementById("txtscardno").value.length !=15 && document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType")").selectedIndex].text != "AMEX" && document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType")").selectedIndex].text != "DINERS"){
			alert("Credit Card Number must be 15 digits!");
			document.getElementById("txtscardno").focus();
			return false;
		}
		*/
		if(document.getElementById("ctl00_content_txtscardno").value.length > 0 && document.getElementById("ctl00_content_txtscardno").value.length !=15 && document.getElementById("ctl00_content_ddlCardType").selectedIndex != 0 && (document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text == "AMEX" || document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text == "DINERS")){
			alert("'AMEX' and 'DINERS' should be 15 digits!");
			document.getElementById("ctl00_content_txtscardno").focus();
			return false;
		}
		if(document.getElementById("txtscardno").value.length !=16 && document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text != "AMEX" && document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text != "DINERS"){
			alert("Credit Card Number must be 16 digits!");
			document.getElementById("txtscardno").focus();
			return false;
		}
		if(isNaN(document.getElementById("txtscardno").value)){
			alert("Please enter numeric values as credit card no!");
			document.getElementById("txtscardno").focus();
			return false;
		}
		if(document.getElementById("txtscardno").value.length > 0 && (document.getElementById("ctl00_content_ddlMonth").selectedIndex == 0 || document.getElementById("ctl00_content_ddlYear").selectedIndex == 0 )){
			alert("Please enter the credit card expiration date!");
			if(document.getElementById("ctl00_content_ddlMonth").selectedIndex == 0){
				document.getElementById("ctl00_content_ddlMonth").focus();
			}
			else{
				document.getElementById("ctl00_content_ddlYear").focus();
			}
			return false;
		}
	    if(document.getElementById("txtscardno").value.length !=15 && document.getElementById("drpscard").selectedIndex != 0 && document.getElementById("drpscard").options[document.getElementById("drpscard").selectedIndex].text == "AMEX"){
			alert("AMEX has 15 digits! Please re-enter");
			document.getElementById("txtscardno").focus();
			return false;
		}
		if(document.getElementById("txtscardno").value.length !=14 && document.getElementById("drpscard").selectedIndex != 0 && document.getElementById("drpscard").options[document.getElementById("drpscard").selectedIndex].text == "DINERS"){
			alert("'DINERS' should be 14 digits!");
			document.getElementById("txtscardno").focus();
			return false;
		}
		if((document.getElementById("txtscardno").value.length !=16 || document.getElementById("txtscardno").value.length !=13) && document.getElementById("drpscard").selectedIndex != 0 && (document.getElementById("drpscard").options[document.getElementById("drpscard").selectedIndex].text == "MASTERCARD" || document.getElementById("ctl00_content_ddlCardType").options[document.getElementById("ctl00_content_ddlCardType").selectedIndex].text == "DISCOVER")){
			alert("'MASTERCARD' and 'DISCOVER' should be 16 digits!");
			document.getElementById("txtscardno").focus();
			return false;
		}
		 if((document.getElementById("txtscardno").value.length !=16 || document.getElementById("txtscardno").value.length !=13) && document.getElementById("drpscard").selectedIndex != 0 && document.getElementById("drpscard").options[document.getElementById("drpscard").selectedIndex].text == "VISA"){
			alert("'VISA' should be 13 or 16 digits!");
			document.getElementById("txtscardno").focus();
			return false;
		}
		
		/*if(document.getElementById("txtscardno").value.length > 0 && document.getElementById("txtscardno").value.length !=15 && document.getElementById("drpscard").selectedIndex != 0 && (document.getElementById("drpscard").options[document.getElementById("drpscard").selectedIndex].text == "AMEX" || document.getElementById("drpscard").options[document.getElementById("drpscard").selectedIndex].text == "DINERS")){
			alert("'AMEX' and 'DINERS' should be 15 digits!");
			document.getElementById("txtscardno").focus();
			return false;
		}
		if(document.getElementById("txtscardno").value.length > 0 && document.getElementById("txtscardno").value.length !=16 && document.getElementById("drpscard").selectedIndex != 0 && (document.getElementById("drpscard").options[document.getElementById("drpscard").selectedIndex].text == "VISA")){
			alert("'VISA' should be 16 digits!");
			document.getElementById("txtscardno").focus();
			return false;
		}*/
		/*if(document.getElementById("txtscardno").value.length !=16 && document.getElementById("drpscard").options[document.getElementById("drpscard").selectedIndex].text != "AMEX" && document.getElementById("drpscard").options[document.getElementById("drpscard").selectedIndex].text != "DINERS"){
			alert("Credit Card Number must be 16 digits!");
			document.getElementById("txtscardno").focus();
			return false;
		}*/
		/*Add by daniel
		*01/20/06 for requirement
		*/
		/* changed by joey  1/23/2008   */
		if(document.getElementById("txtscardno").value.length !=16 && (document.getElementById("drpscard").options[document.getElementById("drpscard").selectedIndex].text == "VISA" || document.getElementById("drpscard").options[document.getElementById("drpscard").selectedIndex].text == "MASTERCARD")){
			alert("VISA and MASTERCARD has 16 digits! Please re-enter.");
			document.getElementById("txtscardno").focus();
			return false;
			}
		//**********************************************************
		if(isNaN(document.getElementById("txtscardno").value)){
			alert("Please enter numeric values as credit card no!");
			document.getElementById("txtscardno").focus();
			return false;
		}
		if(document.getElementById("txtscardno").value.length > 0 && (document.getElementById("drpsmon").selectedIndex == 0 || document.getElementById("drpsyear").selectedIndex == 0 )){
			alert("Please enter the credit card expiration date!");
			if(document.getElementById("drpsmon").selectedIndex == 0){
				document.getElementById("drpsmon").focus();
			}
			else{
				document.getElementById("drpsyear").focus();
			}
			return false;
		}
		if(document.getElementById("txtscardname").value == ""){
			alert("Please enter cardholder's name!");
			document.getElementById("txtscardname").focus();
			return false;
		}
	
		if(document.getElementById("txtsprinum1").value == ""){
			alert("Please enter a primary phone number!")
			document.getElementById("txtsprinum1").focus();
			return false;
		}		
		if(isNaN(document.getElementById("txtsprinum1").value)){
			alert("Please enter numeric values as phone number");
			document.getElementById("txtsprinum1").focus();
			return false;
		}
		if(document.getElementById("txtsprinum2").value == ""){
			alert("Please enter a primary phone number!")
			document.getElementById("txtsprinum2").focus();
			return false;
		}
		if(isNaN(document.getElementById("txtsprinum2").value)){
			alert("Please enter numeric values as phone number");
			document.getElementById("txtsprinum2").focus();
			return false;
		}		
		if(document.getElementById("txtsprinum3").value == ""){
			alert("Please enter a primary phone number!")
			document.getElementById("txtsprinum3").focus();
			return false;
		}
		if(isNaN(document.getElementById("txtsprinum3").value)){
			alert("Please enter numeric values as phone number");
			document.getElementById("txtsprinum3").focus();
			return false;
		}
	
		if(isNaN(document.getElementById("txtsprinum4").value)){
			alert("Please enter numeric values as phone ext!");
			document.getElementById("txtsprinum4").focus();
			return false;
		}
		if(document.getElementById("txtsprinum1").value.length!=3||document.getElementById("txtsprinum2").value.length!=3||document.getElementById("txtsprinum3").value.length!=4)
		{alert("Please check primary phone number field.");
			document.getElementById("txtsprinum3").focus();
			return false;
		
		}	
		
		if(document.getElementById("txtsemail").value == ""){
			alert("Please enter email address!");
			document.getElementById("txtsemail").focus();
			return false;
		}
		if(document.getElementById("txtsemail").value != "" && document.getElementById("txtsemail").value != null && !isEmailValid(document.getElementById("txtsemail").value)){
			alert("Please enter a valid Email Address!");
			document.getElementById("txtsemail").focus();
			return false;
		}		
		
		return true;	
	}

/****************************************************************************
**Function:isEmailValid
**Description:Check if email valid
**Input:email value
**Output:true--valid;
**11/17/04 - Created (eJay)
****************************************************************************/
function isEmailValid(Value){

	//var re=/^\w+@\w+\.\w{2,3}/;
	var re=/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
	var r=Value.match(re);
	
	if (r==null){
		return false;
	}
	
	return true;
}


/****************************************************************************
**Function:getAccountName
**Description:getAccountName
**2/6/07 - Created (eJay)
****************************************************************************/
function getAccountName()
{
    if(document.getElementById("ctl00_content_txtCompany").value!="" && document.getElementById("ctl00_content_txtCompany").value.length>0){
        var acctName=document.getElementById("ctl00_content_hidAcctName").value.split('|');
        var acctID=document.getElementById("ctl00_content_hidAcctId").value.split('|');
        var inputAccountName=trim(document.getElementById("ctl00_content_txtCompany").value);
        var i;
        for(i=1;i<acctName.length-1;i++)
        {
            if(inputAccountName.toLowerCase()==acctName[i].toLowerCase()){
                document.getElementById("ctl00_content_txtAcctId").value=acctID[i];
                break;
            }
        }
    }
    
    
}
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

/********************************************************
**funciton add by daniel for some entervalues 12/14/2006
********************************************************/
function entervalues(){

	if(event.keyCode==44)
	{
		event.returnValue=false;
		//alert("Don't enter commas (,) ");
	}else if (event.keyCode==39){
		event.returnValue=false;
		//alert("Don't enter apostrophes (') ");	
	}
	
}

/********************************************************************
**function:batchValidate
**Description:For Frequent  profile Add page validating
**01/31/08 - Created (lily)
********************************************************************/

function batchValidate(){

		if(document.getElementById("ctl00_content_fname").value == ""){
			alert("Please enter first name!");
			document.getElementById("ctl00_content_fname").focus();
			return false;
		}
		if(document.getElementById("ctl00_content_lname").value == ""){
			alert("Please enter last name!");
			document.getElementById("ctl00_content_lname").focus();
			return false;
		}

		
		if(document.getElementById("ctl00_content_officephone").value = "" ){
			alert("Please enter the phone number!")
			document.getElementById("ctl00_content_officephone").focus();
			return false;
		}
	
		
	if(document.getElementById("ctl00_content_officephone").value != "" && isNaN(document.getElementById("ctl00_content_officephone").value)){
			alert("lease enter full telephone information with area code!")
			document.getElementById("ctl00_content_officephone").focus();
			return false;
		}

		if(isNaN(document.getElementById("ctl00_content_officephoneext").value)){
			alert("Please enter numeric values as phone number");
			document.getElementById("ctl00_content_officephoneext").focus();
			return false;
		}

     	
	
	


		if(document.getElementById("ctl00_content_email").value == ""){
			alert("Please enter email address!");
			document.getElementById("ctl00_content_email").focus();
			return false;
		}
	
	}