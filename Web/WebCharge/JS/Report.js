function AirOrCity()
{
 
document.getElementById("ctl00_MainContent_trLAir").style.display='none';
document.getElementById("ctl00_MainContent_trLAirList").style.display='none';
document.getElementById("ctl00_MainContent_trLState").style.display='none';
document.getElementById("ctl00_MainContent_trLCity").style.display='none';
document.getElementById("ctl00_MainContent_trRAir").style.display='none';
document.getElementById("ctl00_MainContent_trRAirList").style.display='none';
document.getElementById("ctl00_MainContent_trRState").style.display='none';
document.getElementById("ctl00_MainContent_trRCity").style.display='none';
document.getElementById("ctl00_MainContent_trReserve").style.display='none';
 if(document.all['ctl00_MainContent_radAtoA'].checked==true){
 document.getElementById("ctl00_MainContent_trLAir").style.display='';
document.getElementById("ctl00_MainContent_trLAirList").style.display='';
document.getElementById("ctl00_MainContent_trRAir").style.display='';
document.getElementById("ctl00_MainContent_trRAirList").style.display='';
document.getElementById("ctl00_MainContent_trReserve").style.display='';
 }
  if(document.all['ctl00_MainContent_radAtoC'].checked==true){
 document.getElementById("ctl00_MainContent_trLAir").style.display='';
document.getElementById("ctl00_MainContent_trLAirList").style.display='';
document.getElementById("ctl00_MainContent_trRState").style.display='';
document.getElementById("ctl00_MainContent_trRCity").style.display='';
 }
  if(document.all['ctl00_MainContent_radCtoA'].checked==true){
 document.getElementById("ctl00_MainContent_trLState").style.display='';
document.getElementById("ctl00_MainContent_trLCity").style.display='';
document.getElementById("ctl00_MainContent_trRAir").style.display='';
document.getElementById("ctl00_MainContent_trRAirList").style.display='';
 }
  if(document.all['ctl00_MainContent_radCtoC'].checked==true){
  document.getElementById("ctl00_MainContent_trLState").style.display='';
document.getElementById("ctl00_MainContent_trLCity").style.display='';
document.getElementById("ctl00_MainContent_trRState").style.display='';
document.getElementById("ctl00_MainContent_trRCity").style.display='';
document.getElementById("ctl00_MainContent_trReserve").style.display='';
 }

}

function ShowConfirmation(strconfirm){
 var width = window.screen.width - 150;
	var height = window.screen.height - 230;
	var PopUpWin=window.open("ConfirmationDetail.aspx?confirmation=" + strconfirm, "_VoucherDetail", "height=" + height
								+ ",left=75,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,"
								+ "toolbar=no,top=115,width=" + width);
}

	function FormValidate(stracct)
		{
			var strInvoiceNo, strFromDate, strToDate,strSelAcct;
			
			strInvoiceNo = document.getElementById("ctl00_MainContent_txt_InVoiceNo").value;
			strFromDate = document.getElementById("ctl00_MainContent_txt_InVoiceDate").value;
			strToDate = document.getElementById("ctl00_MainContent_txt_ToInVoiceDate").value;
			strSelAcct=stracct;
			
			if(strInvoiceNo!="")
			{
				if(!ValidateInvoiceNo(strInvoiceNo)) return false;
			}
			else
			{
				if(!ValidateDateForm(strFromDate, strToDate)) return false;
			}
			
			if (stracct=="Y"){
			  if(document.getElementById("ctl00_MainContent_listAcct").selectedIndex == -1){
			  alert("Please select a account");
			  return false;}
			 else{ return true;}

			} 
			else{
            return true;}
			
			
		}
		
		function CheckDate(strDate)
{
	if(strDate=="") return false;
	
	//------------------------------------------------------------------------
	// * Check whether the year is a leap Year or not
	//------------------------------------------------------------------------

	var m_YYYY = /(1[89]\d{2}|2\d{3})/;
	RegExp.$1="";
	m_YYYY.exec(strDate);
	var m_Year = RegExp.$1;
	if(m_Year=="") m_Year = (new Date()).getYear();
	var bln_LeapYear = false;
	if((m_Year%4==0 && m_Year%100!=0)||(m_Year%400==0)) bln_LeapYear = true;
	//------------------------------------------------------------------------
	
	var YYYY = "(1[89]\\d{2}|2\\d{3})";
	var MMDD_1 = "(0\?[13578]|1[02])[\-\/](0\?[1-9]|[12]\\d|3[01])";
	var MMDD_2 = "(0\?[469]|11)[\-\/](0\?[1-9]|[12]\\d|30)";
	var MMDD_3;
	if(bln_LeapYear)
		MMDD_3 = "0\?2[\-\/](0\?[1-9]|[12]\\d)";
	else
		MMDD_3 = "0\?2[\-\/](0\?[1-9]|1\\d|2[0-8])";
	var MMDD_All = "((" + MMDD_1 + ")|(" + MMDD_2 + ")|(" + MMDD_3 + "))";
	var DateFormat_1 = "(" + YYYY + "[\-\/]" + MMDD_All + ")";
	var DateFormat_2 = "(" + MMDD_All + "[\-\/]" + YYYY + ")";
	var DateFormat_3 = "(" + MMDD_All + ")";
	var DateFormat_All ="^(" + DateFormat_1 + "|" + DateFormat_2 + "|" + DateFormat_3 + ")$";
	var m_ChkDate = new RegExp(DateFormat_All);
	return(m_ChkDate.test(strDate));
}

////added by lily 12/18/2007
//		function CheckDateValue(Date)
//		
//{
//    var strDate=document.getElementById(Date).value;
//	if(strDate=="") return false;
//	
//	//------------------------------------------------------------------------
//	// * Check whether the year is a leap Year or not
//	//------------------------------------------------------------------------

//	var m_YYYY = /(1[89]\d{2}|2\d{3})/;
//	RegExp.$1="";
//	m_YYYY.exec(strDate);
//	var m_Year = RegExp.$1;
//	if(m_Year=="") m_Year = (new Date()).getYear();
//	var bln_LeapYear = false;
//	if((m_Year%4==0 && m_Year%100!=0)||(m_Year%400==0)) bln_LeapYear = true;
//	//------------------------------------------------------------------------
//	
//	var YYYY = "(1[89]\\d{2}|2\\d{3})";
//	var MMDD_1 = "(0\?[13578]|1[02])[\-\/](0\?[1-9]|[12]\\d|3[01])";
//	var MMDD_2 = "(0\?[469]|11)[\-\/](0\?[1-9]|[12]\\d|30)";
//	var MMDD_3;
//	if(bln_LeapYear)
//		MMDD_3 = "0\?2[\-\/](0\?[1-9]|[12]\\d)";
//	else
//		MMDD_3 = "0\?2[\-\/](0\?[1-9]|1\\d|2[0-8])";
//	var MMDD_All = "((" + MMDD_1 + ")|(" + MMDD_2 + ")|(" + MMDD_3 + "))";
//	var DateFormat_1 = "(" + YYYY + "[\-\/]" + MMDD_All + ")";
//	var DateFormat_2 = "(" + MMDD_All + "[\-\/]" + YYYY + ")";
//	var DateFormat_3 = "(" + MMDD_All + ")";
//	var DateFormat_All ="^(" + DateFormat_1 + "|" + DateFormat_2 + "|" + DateFormat_3 + ")$";
//	var m_ChkDate = new RegExp(DateFormat_All);
//	return(m_ChkDate.test(strDate));
//}
		function ValidateDateForm(strFromDate, strToDate)
{
	if(strFromDate=="")
	{
		alert("From Date should not be blank!");
		return false;
	}
	if(strToDate=="")
	{
		alert("To Date should not be blank!");
		return false;
	}
	if(!CheckDate(strFromDate))
	{
		alert("From Date is invalid!");
		return false;
	}
	if(!CheckDate(strToDate))
	{
		alert("To Date is invalid!");
		return false;
	}
	if(!CheckDateRange(strFromDate, strToDate))
	{
		alert("Inquery date range is invalid!");
		return false;
	}
	return true;
}

function CheckDateRange(strFromDate, strToDate)
{
	if(strFromDate=="" || strToDate=="") return false;
	
	//-------------------------------------------------------------------------------------
	// * Format date to 'yyyy/M/d' if 'yyyy' is defaulted
	// * Purpose: new Date("yyyy/M/d")
	//-------------------------------------------------------------------------------------
	strFromDate = strFromDate.replace(/\-/g,"\/");
	strToDate = strToDate.replace(/\-/g,"\/");
	var m_YYYY =/1[89]\d{2}|2\d{3}/;
	if(!m_YYYY.test(strFromDate)) strFromDate = (new Date()).getYear() + "\/" + strFromDate;
	if(!m_YYYY.test(strToDate)) strToDate = (new Date()).getYear() + "\/" + strToDate;
	//-------------------------------------------------------------------------------------

	var m_FromDate, m_ToDate;			
	m_FromDate = new Date(strFromDate);
	m_ToDate = new Date(strToDate);
	if(m_FromDate>m_ToDate)
		return false;
	else
		return true;
}
		
function ValidateInvoiceNo(strInvoiceNo)
{
	if(strInvoiceNo=="")
	{
//		//alert("Invoice Number should not be blank!");
		return false;
	}
	else if(!IsPosInt(strInvoiceNo))
	{
		alert("Top number should be a positive integer. Please check your input!");
		return false;
	}
	return true;
}

function IsPosInt(strNum)
{
	if(strNum=="") return false;
	
	var m_PosInt=/^[1-9]\d*$/;
	return m_PosInt.test(strNum);
}
		
function FormatInvoiceNo()
		{
			var strInvoiceNo = document.getElementById("ctl00_MainContent_txt_InVoiceNo").value;
			if (isNaN(strInvoiceNo)){
			alert("Please make sure entries are positive numbers only.");
			document.getElementById("ctl00_MainContent_txt_InVoiceNo").focus();
			return false;
			}
			document.getElementById("ctl00_MainContent_txt_InVoiceNo").value = strInvoiceNo;
		}
		
function DateValidate(stracct)
		{
			var strInvoiceNo, strFromDate, strToDate,strSelAcct;
			strFromDate = document.getElementById("ctl00_MainContent_txt_FromTrip").value;
			strToDate = document.getElementById("ctl00_MainContent_txt_ToTrip").value;
						strSelAcct=stracct;
			if(!ValidateDateForm(strFromDate, strToDate)) return false;
//			if (stracct=="Y"){
//			  if(document.getElementById("ctl00_MainContent_listAcct").selectedIndex == -1){
//			  alert("Please select a account");
//			  return false;}
//			 else{ return true;}

//			} 
//			else{
//            return true;}
			
			
		}
//		function ConfNoValidate()
//{

//	var i,count;
//	
//	count = 0;
//	
//	for(i=0 ; i < 15; i++){
//	var strId="ctl00_MainContent_txtcn0" + i +
////		if(document.getElementById("ctl00_MainContent_txtcn0" + i + ).value.length > 0){
//	if(document.getElementById(strId).value.length > 0){
//			count++;
//		}
//	}

//	
//	if(count == 0 ) {
//		alert("Please enter a comfirmation number!");
//		document.forms[0].input_1.focus();	
//		return false;
//	}
//	
//	// Verifies Date
//	if(!isDate(document.form1.pu_date,(getTheYear() - 5),(getTheYear())))
//	{
//		document.forms[0].pu_date.focus();
//		return false;
//	}
//	return true;
//}



//****************************************************************************************
//																						//
//			Creater: Johnson.Wang														//
//																						//
//			Content Info: Form Validate													//
//																						//
//****************************************************************************************


// Common Functions //

//mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm

// * Function: Trim()

function Trim(strObject)
{
	return strObject.replace(/(^\s*)|(\s*$)/g,"");
}

//mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm

// * Function: Remove blanks and meaningless zeros form strObject

function TrimLeftZero(strObject)
{
	if(Trim(strObject)=="") return "";
	strObject=strObject.replace(/(^(\s|0)*)|(\s*$)|(\.+(0|\s)*$)/g,"").replace(/^(\.)+/,"0.");
	return (strObject=="")?"0":strObject;
}

//mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm

// * Function: if(strNum>=0) return true;

function IsPosNum(strNum)
{
	var m_PosInt=/^(0|0\.\d*|[1-9]\d*\.?\d*)$/;
	// * /0\.\d*[1-9]\d*|[1-9]\d*\.?\d*)$/
	return m_PosInt.test(strNum);
}

//mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm

// * Function: Check whether strNum is a positive integer or not

function IsPosInt(strNum)
{
	if(strNum=="") return false;
	
	var m_PosInt=/^[1-9]\d*$/;
	return m_PosInt.test(strNum);
}


// ################################################################################################
// #####									TKO_WebCharge									  #####
// ################################################################################################

function ValidateInvoiceNo(strInvoiceNo)
{
	if(strInvoiceNo=="")
		return false;
	else if(!IsPosInt(strInvoiceNo))
	{
		alert("Top number should be a positive integer. Please check your input!");
		return false;
	}
	return true;
}

//-------------------------------------------------------------------------------------------------

function ValidateTopNo(strTopNo)
{
	if(strTopNo=="")
	{
		alert("Please enter a Top value!");
		return false;
	}
	else if(!IsPosInt(strTopNo))
	{
		alert("Top number should be a positive integer. Please check your input!");
		return false;
	}
	return true;
}

//-------------------------------------------------------------------------------------------------

function ValidateGreaterThan(strGreaterThan)
{
	if(strGreaterThan=="")
	{
		alert("Greater Than should not be blank!");
		return false;
	}
	else if(!IsPosNum(strGreaterThan))
	{
		alert("Greater Than should be a positive number. Please check your input!");
		return false;
	}
	return true;
}

//-------------------------------------------------------------------------------------------------

function ValidateSearchValue(strSearchValue)
{
	if(strSearchValue=="")
	{
		alert("Please enter a Search Value!");
		return false;
	}
	else
		return true;
}

//-------------------------------------------------------------------------------------------------
function ValidateOldPswd(strOldPswd)
{
	if(strOldPswd=="")
	{
		alert("Please enter your Old Password!");
		return false;
	}
	return true;
}

//-------------------------------------------------------------------------------------------------

function ValidateNewPswd(strNewPswd, strConfirm)
{
	if(strNewPswd=="")
	{
		alert("Please enter a new Password!");
		return false;
	}
	if(strConfirm=="")
	{
		alert("Confirmation should not be blank!");
		return false;
	}
	if(strNewPswd!=strConfirm)
	{
		alert("Please check your new password!");
		return false;
	}
	return true;
}

//added  by lily 12/12/2007
function isValid(inputVal) {
	inputStr = inputVal.toString();
	for (var i = 0; i < inputStr.length; i++) {
		var oneChar = inputStr.charAt(i);
		if ((oneChar < "0" || oneChar > "9") && oneChar != ".") {
			return false;
		}
	}
	return true;
}
function DateValidateEmployee(top,FromDate,ToDate)
		{
			var strInvoiceNo, strFromDate, strToDate,strSelAcct;
			strFromDate = document.getElementById(FromDate).value;
			strToDate = document.getElementById(ToDate).value;
			if(document.getElementById(top).value == "" || document.getElementById(top).value.length == 0){
		        alert("Please Enter A Top Value!");
		        document.getElementById(top).focus();
		        return false;
		     }
						
			if(!ValidateDateForm(strFromDate, strToDate)) return false;
			if(!isValid(document.getElementById(top).value)){
		        alert("Please enter valid top number!");
		        document.getElementById(top).focus();
		        return false;
	}
		}
		
function batchValidate(Amount,FromTrip,ToTrip)
{   var  strFromDate, strToDate;
			strFromDate = document.getElementById(FromTrip).value;
			strToDate = document.getElementById(ToTrip).value;
			
	if(document.getElementById(Amount).value == "" || document.getElementById(Amount).value.length == 0){
		alert("Please enter a greater than amount!");
		document.getElementById(Amount).focus();
		return false;
	}
	
	if(!ValidateDateForm(strFromDate, strToDate)) return false;
	
	if(!isValid(document.getElementById(Amount).value)){
		alert("Please enter valid dollar amount!");
		document.getElementById(Amount).focus();
		return false;
	}
	
	return true;
}	
//added by lily 12/17/2007
function FormValidate(strInvoiceNo, FromDate, ToDate)
{             var  strFromDate, strToDate;
            // strInvoiceNo= document.getElementById(InvoiceNo).value;
			strFromDate = document.getElementById(FromDate).value;
			strToDate = document.getElementById(ToDate).value;
		
			if(document.getElementById(strInvoiceNo).value== "" || document.getElementById(strInvoiceNo).value.length == 0)
			{       alert("Invoice Number should not be blank");
		            document.getElementById(strInvoiceNo).focus();
		            return false;
			}
				
			else
			{
				if(!ValidateInvoiceNo(document.getElementById(strInvoiceNo).value)) return false;
				if(!ValidateDateForm(strFromDate, strToDate)) return false;
			}
			
									
			return true;
		}
		

//-------------------------------------------------------------------------------------------------
