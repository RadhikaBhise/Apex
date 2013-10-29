// check if input string is empty
function isEmpty(inputStr) {
	if (inputStr == null || inputStr == "") {
		return true;
	}
	return false;
}
// check if input value is positve integer
function isPosInteger(inputVal) {
	inputStr = inputVal.toString();
	for (var i = 0; i < inputStr.length; i++) {
		var oneChar = inputStr.charAt(i);
		if (oneChar < "0" || oneChar > "9") {
			return false;
		}
	}
	return true;
}
// checks if input value specified within the start position and including the end position
// is an alphabet character
function isAlpha(inputVal, startPos, endPos) {
	var strValue = inputVal.substring(startPos,endPos)
	for (var i = 0; i < strValue.length; i++) {
		var oneChar = strValue.charAt(i);
		if (!(oneChar >= "A" && oneChar <= "Z") && !(oneChar >= "a" && oneChar <= "z")) {
			return false;
			
		}
	}
	return true;
} 
// checks if input value specified within the start position and including the end position
// is an integer character
function isInteger(inputVal, startPos, endPos){
	var strValue = inputVal.substring(startPos,endPos)
	for (var i = 0; i < strValue.length; i++) {
		var oneChar = strValue.charAt(i);
		if (oneChar < "0" || oneChar > "9") {
			return false;
		}
	}
	return true;
} 
// check if input value is seven-digit
function isSevenDigits(inputVal) {
	inputStr = inputVal.toString();
	if (inputStr.length < 7 || inputStr.length > 7) {
		return false;
	}
	return true;
}
// check if input value is five-digit
function isFiveDigits(inputVal) {
	inputStr = inputVal.toString();
	if (inputStr.length < 5 || inputStr.length > 5) {
		return false;
	}
	return true;
}
// check if inpout value is four-digit
function isFourDigits(inputVal) {
	inputStr = inputVal.toString();
	if (inputStr.length < 4 || inputStr.length > 4) {
		return false;
	}
	return true;
}
// check if inpout value is three-digit
function isThreeDigits(inputVal) {
	inputStr = inputVal.toString();
	if (inputStr.length < 3 || inputStr.length > 3) {
		return false;
	}
	return true;
}
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
