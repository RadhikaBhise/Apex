// JScript File
function ValidateOrderForm()
{
    var out = false;
    var para, returnValue;
    
    out = OrderEntryModuleOrderentry1Validate();
    
    if (out==true)
    {
        para = StopModuleStop1VerifyStreet();
        out = StopModuleStop1Validate();
    }
    
    if (out==true)
    {
        para = para + "&" + StopModuleStop2VerifyStreet();
        out = StopModuleStop2Validate();
    }
    
    if (out==true)
    {
        if(para!=null && para.length>0)
        {
            //alert(para);
            returnValue = window.showModalDialog('VerifyStreet.aspx?' + para,'','dialogHeight: 500px;dialogWidth: 400px;status: no');
        }
        if(returnValue!=null && (returnValue=='T' || returnValue=="undefined"))
        {
            out=true;
        }else{
            out=false;
        }
    }
    
    return out;
}
        
function VerifyCC(btnSubmit,cc_no,cc_exp,cc_type,from)
{
    //##    from
    //#     1   general screens
    //#     2   user profile screen
    
    var out = false;
    
    if(btnSubmit != null)
        btnSubmit.style.visibility='hidden';
        
    var width = 350;
	var height = 400;
    var result = window.open('./Verify_cc_payflow.aspx?f='+from+'&cc_no='+cc_no+'&cc_exp='+cc_exp+'&cc_type='+cc_type,'Verify_Credit_Card','width='+width+',height='+height+',scrollbars=yes,left='+(screen.width-width)/2+',top='+(screen.height-height)/2);
			
    if (result == null)
        out = false;
    else if (result == "1")
        out = true;
    else
        out = false;
    
    if(btnSubmit != null && out == false)
        btnSubmit.style.display = "";
        
    //return out;
    return false;
}
