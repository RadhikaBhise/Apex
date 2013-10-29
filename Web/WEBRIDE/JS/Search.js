// JScript File
//function pLname(){
//document.getElementById("ctl00_MainContent_txtAuLname").value = ""
//document.getElementById("ctl00_MainContent_txtComp_id_6").value = ""
//document.getElementById("ctl00_MainContent_txtConf_no").value = ""
//document.getElementById("ctl00_MainContent_txtCancel").value = ""
//document.getElementById("ctl00_MainContent_txtFdate").value = ""
//document.getElementById("ctl00_MainContent_txtTdate").value = ""
//document.getElementById("ctl00_MainContent_ddlDate").selectedIndex = 0
//}
//function authLname(){
//document.getElementById("ctl00_MainContent_txtLname").value = ""
//document.getElementById("ctl00_MainContent_txtComp_id_6").value = ""
//document.getElementById("ctl00_MainContent_txtConf_no").value = ""
//document.getElementById("ctl00_MainContent_txtCancel").value = ""
//document.getElementById("ctl00_MainContent_txtFdate").value = ""
//document.getElementById("ctl00_MainContent_txtTdate").value = ""
//document.getElementById("ctl00_MainContent_ddlDate").selectedIndex = 0
//}
function handleEnterSubmission (field, evt,search_type) {
	  var keyCode = evt.which ? evt.which : evt.keyCode;
	  if (keyCode == 13) {
document.getElementById("ctl00_MainContent_search_type").value = search_type;
		 if(search_type=="fname"){
			document.getElementById("ctl00_MainContent_txtAuLname").value = "";
document.getElementById("ctl00_MainContent_txtComp_id_6").value = "";
document.getElementById("ctl00_MainContent_txtConf_no").value = "";
document.getElementById("ctl00_MainContent_txtCancel").value = "";
		 }else if(search_type=="lname"){
		 	document.getElementById("ctl00_MainContent_txtLname").value = "";
document.getElementById("ctl00_MainContent_txtComp_id_6").value = "";
document.getElementById("ctl00_MainContent_txtConf_no").value = "";
document.getElementById("ctl00_MainContent_txtCancel").value = "";
		 }else if(search_type=="comp_id_6"){
		 	document.getElementById("ctl00_MainContent_txtAuLname").value = "";
document.getElementById("ctl00_MainContent_txtLname").value = "";
document.getElementById("ctl00_MainContent_txtConf_no").value = "";
document.getElementById("ctl00_MainContent_txtCancel").value = "";
		 }else if(search_type=="confirmation_no"){
		document.getElementById("ctl00_MainContent_txtAuLname").value = "";
document.getElementById("ctl00_MainContent_txtComp_id_6").value = "";
document.getElementById("ctl00_MainContent_txtLname").value = "";
document.getElementById("ctl00_MainContent_txtCancel").value = "";
		}else if(search_type=="cancellation_no"){	
			document.getElementById("ctl00_MainContent_txtAuLname").value = "";
document.getElementById("ctl00_MainContent_txtComp_id_6").value = "";
document.getElementById("ctl00_MainContent_txtConf_no").value = "";
document.getElementById("ctl00_MainContent_txtLname").value = "";
		 }
		 else if(search_type=="comp_id"){	
			document.getElementById("ctl00_MainContent_txtAuLname").value = "";
document.getElementById("ctl00_MainContent_txtComp_id_6").value = "";
document.getElementById("ctl00_MainContent_txtConf_no").value = "";
document.getElementById("ctl00_MainContent_txtLname").value = "";
document.getElementById("ctl00_MainContent_txtCancel").value = "";
		 }
	    SearchBatchValidate();
	    return false;
	  }
	  else 
		 document.getElementById("ctl00_MainContent_search_type").value = search_type;
		 if(search_type=="fname"){
			document.getElementById("ctl00_MainContent_txtAuLname").value = "";
document.getElementById("ctl00_MainContent_txtComp_id_6").value = "";
document.getElementById("ctl00_MainContent_txtConf_no").value = "";
document.getElementById("ctl00_MainContent_txtCancel").value = "";
		 }else if(search_type=="lname"){
		 		document.getElementById("ctl00_MainContent_txtLname").value = "";
document.getElementById("ctl00_MainContent_txtComp_id_6").value = "";
document.getElementById("ctl00_MainContent_txtConf_no").value = "";
document.getElementById("ctl00_MainContent_txtCancel").value = "";
		 }else if(search_type=="comp_id_6"){
		 		document.getElementById("ctl00_MainContent_txtAuLname").value = "";
document.getElementById("ctl00_MainContent_txtLname").value = "";
document.getElementById("ctl00_MainContent_txtConf_no").value = "";
document.getElementById("ctl00_MainContent_txtCancel").value = "";
		 }else if(search_type=="confirmation_no"){
		document.getElementById("ctl00_MainContent_txtAuLname").value = "";
document.getElementById("ctl00_MainContent_txtComp_id_6").value = "";
document.getElementById("ctl00_MainContent_txtLname").value = "";
document.getElementById("ctl00_MainContent_txtCancel").value = "";
		 }else if(search_type=="cancellation_no"){	
			document.getElementById("ctl00_MainContent_txtAuLname").value = "";
document.getElementById("ctl00_MainContent_txtComp_id_6").value = "";
document.getElementById("ctl00_MainContent_txtConf_no").value = "";
document.getElementById("ctl00_MainContent_txtLname").value = "";
		 }
		 else if(search_type=="comp_id"){	
			document.getElementById("ctl00_MainContent_txtAuLname").value = "";
document.getElementById("ctl00_MainContent_txtComp_id_6").value = "";
document.getElementById("ctl00_MainContent_txtConf_no").value = "";
document.getElementById("ctl00_MainContent_txtLname").value = "";
document.getElementById("ctl00_MainContent_txtCancel").value = "";
		 }
		 document.getElementById("ctl00_MainContent_ddlDate").selectedIndex = 0;
		 if(search_type != "date2"){
			document.getElementById("ctl00_MainContent_txtFdate").value = "";
document.getElementById("ctl00_MainContent_txtTdate").value = "";
		 }
	    return true;
	}
	function SearchBatchValidate(){
		 if(document.getElementById("ctl00_MainContent_txtLname").value == "" && document.getElementById("ctl00_MainContent_txtAuLname").value == "" && document.getElementById("ctl00_MainContent_txtComp_id_6").value == "" && document.getElementById("ctl00_MainContent_txtConf_no").value == "" && document.getElementById("ctl00_MainContent_txtCancel").value == "" && document.getElementById("ctl00_MainContent_txtFdate").value == "" && document.getElementById("ctl00_MainContent_txtTdate").value == "" && document.getElementById("ctl00_MainContent_txtComp").value == "" && document.getElementById("ctl00_MainContent_ddlDate").selectedIndex ==0){
		 alert("Please enter either passenger last name, last name, confirmation #, acct_id, cancellation # or PNR if not search date is set");
			document.getElementById("ctl00_MainContent_txtLname").focus();
			return false;
		 }
		 
		if( document.getElementById("ctl00_MainContent_search_type").value == "fname" && document.getElementById("ctl00_MainContent_txtLname").value!="" &&  document.getElementById("ctl00_MainContent_txtLname").value.length < 3){
			alert("Please enter at least 3 characaters in the passenger last name search box");
			 document.getElementById("ctl00_MainContent_txtLname").focus();
			return false;
		}
		if( document.getElementById("ctl00_MainContent_search_type").value == "lname" && document.getElementById("ctl00_MainContent_txtAuLname").value!="" &&  document.getElementById("ctl00_MainContent_txtAuLname").value.length < 3){
			alert("Please enter at least 3 characaters in the last name search box");
			 document.getElementById("ctl00_MainContent_txtLname").focus();
			return false;
		}
		if( document.getElementById("ctl00_MainContent_search_type").value == "comp_id_6" &&  document.getElementById("ctl00_MainContent_txtComp_id_6").value != "" &&  document.getElementById("ctl00_MainContent_txtComp_id_6").value.length < 3){
			alert("Please enter at least 3 characaters in the PNR search box");
			 document.getElementById("ctl00_MainContent_txtLname").focus();
			return false;
		}
		if( document.getElementById("ctl00_MainContent_search_type").value == "confirmation_no" && document.getElementById("ctl00_MainContent_txtConf_no").value!="" &&  document.getElementById("ctl00_MainContent_txtConf_no").value.length != 4){
			alert("Please enter 4 digit confirmation number");
			 document.getElementById("ctl00_MainContent_txtConf_no").focus();
			return false;
		}
		
		if( document.getElementById("ctl00_MainContent_comp_id").type != "hidden"){
			if( document.getElementById("ctl00_MainContent_comp_id").selectedIndex != 0 && document.getElementById("ctl00_MainContent_comp_id_value").value==""){
				alert("Please enter a company requirment search value.");
				 document.getElementById("ctl00_MainContent_comp_id_value").focus();
				return false;
			}
		}
		
		if( document.getElementById("ctl00_MainContent_txtFdate").value.length==0 &&  document.getElementById("ctl00_MainContent_txtTdate").value.length>0){
			alert("Please enter both from and to dates in a valid format. (ie 1/1/2003)");
			 document.getElementById("ctl00_MainContent_txtFdate").focus();
			return false;
		}else if(document.getElementById("ctl00_MainContent_txtFdate").value!="" && !/[0-9]{1,2}(\/)[0-9]{1,2}(\/)[0-9]{2,4}?/.test( document.getElementById("ctl00_MainContent_txtFdate").value)){
			alert("Please enter a date in a valid format. (ie 1/1/2003)");
			 document.getElementById("ctl00_MainContent_txtFdate").focus();
			return false;
		}else if( document.getElementById("ctl00_MainContent_txtFdate").value != ""){
			var arrDate2 =  document.getElementById("ctl00_MainContent_txtFdate").value.split(/(\/)/);
			if (arrDate2[2].length != 2 && arrDate2[2].length != 4){
				alert("Please enter a date in a valid format. (ie 1/1/2003)");
				 document.getElementById("ctl00_MainContent_txtFdate").focus();
				return false;
			}
		}
		
		if( document.getElementById("ctl00_MainContent_txtFdate").value!="" &&  document.getElementById("ctl00_MainContent_txtTdate").value==""){
			alert("Please enter both from and to dates in a valid format. (ie 1/1/2003)");
			 document.getElementById("ctl00_MainContent_txtTdate").focus();
			return false;
		}else if(document.getElementById("ctl00_MainContent_txtTdate").value!="" && !/[0-9]{1,2}(\/)[0-9]{1,2}(\/)[0-9]{2,4}?/.test( document.getElementById("ctl00_MainContent_txtTdate").value)){
			alert("Please enter a date in a valid format. (ie 1/1/2003)");
			 document.getElementById("ctl00_MainContent_txtTdate").focus();
			return false;
		}else if(document.getElementById("ctl00_MainContent_txtTdate").value!=""){
			arrDate2 =  document.getElementById("ctl00_MainContent_txtTdate").value.split(/(\/)/);
			if (arrDate2[2].length != 2 && arrDate2[2].length != 4){
				alert("Please enter a date in a valid format. (ie 1/1/2003)");
				 document.getElementById("ctl00_MainContent_txtTdate").focus();
				return false;
			}
		}
				return true;
////		document.inquiry_search.submit();
	}
function select_date_object(name){
		if(name == "date"){
		document.getElementById("ctl00_MainContent_txtFdate").value = "";
        document.getElementById("ctl00_MainContent_txtTdate").value = "";
		}else if(name == "date2"){
			document.getElementById("ctl00_MainContent_ddlDate").selectedIndex =0;
		}
	}
	function submit_order(search_type){
		document.getElementById("ctl00_MainContent_search_type").value = search_type;
		 if(search_type=="fname"){
			document.getElementById("ctl00_MainContent_txtAuLname").value = "";
document.getElementById("ctl00_MainContent_txtComp_id_6").value = "";
document.getElementById("ctl00_MainContent_txtConf_no").value = "";
document.getElementById("ctl00_MainContent_txtCancel").value = "";
		 }else if(search_type=="lname"){
		 	document.getElementById("ctl00_MainContent_txtLname").value = "";
document.getElementById("ctl00_MainContent_txtComp_id_6").value = "";
document.getElementById("ctl00_MainContent_txtConf_no").value = "";
document.getElementById("ctl00_MainContent_txtCancel").value = "";
		 }else if(search_type=="comp_id_6"){
		 	document.getElementById("ctl00_MainContent_txtAuLname").value = "";
document.getElementById("ctl00_MainContent_txtLname").value = "";
document.getElementById("ctl00_MainContent_txtConf_no").value = "";
document.getElementById("ctl00_MainContent_txtCancel").value = "";
		 }else if(search_type=="confirmation_no"){
		document.getElementById("ctl00_MainContent_txtAuLname").value = "";
document.getElementById("ctl00_MainContent_txtComp_id_6").value = "";
document.getElementById("ctl00_MainContent_txtLname").value = "";
document.getElementById("ctl00_MainContent_txtCancel").value = "";
		}else if(search_type=="cancellation_no"){	
			document.getElementById("ctl00_MainContent_txtAuLname").value = "";
document.getElementById("ctl00_MainContent_txtComp_id_6").value = "";
document.getElementById("ctl00_MainContent_txtConf_no").value = "";
document.getElementById("ctl00_MainContent_txtLname").value = "";
		 }
		 else if(search_type=="comp_id"){	
			document.getElementById("ctl00_MainContent_txtAuLname").value = "";
document.getElementById("ctl00_MainContent_txtComp_id_6").value = "";
document.getElementById("ctl00_MainContent_txtConf_no").value = "";
document.getElementById("ctl00_MainContent_txtLname").value = "";
document.getElementById("ctl00_MainContent_txtCancel").value = "";
if(document.getElementById("ctl00_MainContent_ddlComp").selectedIndex >0 && document.getElementById("ctl00_MainContent_txtComp").value == ""){
 	alert("Please enter a company requirment search value.");
				document.getElementById("ctl00_MainContent_txtComp").focus();
				return false;
			}
		 }
		 if(document.getElementById("ctl00_MainContent_txtLname").value == "" && document.getElementById("ctl00_MainContent_txtAuLname").value == "" && document.getElementById("ctl00_MainContent_txtComp_id_6").value == "" && document.getElementById("ctl00_MainContent_txtConf_no").value == "" && document.getElementById("ctl00_MainContent_txtCancel").value == "" && document.getElementById("ctl00_MainContent_txtFdate").value == "" && document.getElementById("ctl00_MainContent_txtTdate").value == "" && document.getElementById("ctl00_MainContent_txtComp").value == "" && document.getElementById("ctl00_MainContent_ddlDate").selectedIndex ==0){
		 alert("Please enter either passenger last name, last name, confirmation #, acct_id, cancellation # or PNR if not search date is set");
			document.getElementById("ctl00_MainContent_txtLname").focus();
			return false;
		 
		 }
	   var out = SearchBatchValidate();
	   return out;
	}
	function searchClear(page){
		document.getElementById("ctl00_MainContent_txtLname").value = "";
	document.getElementById("ctl00_MainContent_txtAuLname").value = "";
document.getElementById("ctl00_MainContent_txtComp_id_6").value = "";
document.getElementById("ctl00_MainContent_txtConf_no").value = "";
document.getElementById("ctl00_MainContent_txtCancel").value = "";
document.getElementById("ctl00_MainContent_txtFdate").value = "";
document.getElementById("ctl00_MainContent_txtTdate").value = "";
if (page=="inquiry"){
document.getElementById("ctl00_MainContent_ddlDate").selectedIndex =2;}
else
{document.getElementById("ctl00_MainContent_ddlDate").selectedIndex =1;
}
	}
