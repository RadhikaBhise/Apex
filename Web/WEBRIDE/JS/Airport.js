PrefixID = "ctl00_content_";

function displaystate(){
        
	    if (document.getElementById('txtType').value=='p'){
	    
	    self.opener.document.getElementById(PrefixID + "ckPAirport").checked=false;
	    self.opener.document.getElementById('PState').style.display='';
	    }else{
	       
	       self.opener.document.getElementById(PrefixID + "ckDAirport").checked=false;
	       self.opener.document.getElementById('DState').style.display='';
	       }
	
	}
    	

    function SetCurrentDateTime()
    {
        //##    11/21/2007  Use calendar instead    (yang)
        var hdnArrivalTime = document.getElementById("hdnArrivalTime");
        var ddlDate = self.opener.document.getElementById(PrefixID + 'Calendar1_ddlDate');
        var ddlHour = self.opener.document.getElementById(PrefixID + 'Calendar1_ddlHour');
        var ddlMinute = self.opener.document.getElementById(PrefixID + 'Calendar1_ddlMinute');
        var ddlAmPm = self.opener.document.getElementById(PrefixID + 'Calendar1_ddlAmPm');
        
        if (hdnArrivalTime!=null && hdnArrivalTime.value=="")
        {
            if ( ddlDate!=null && ddlHour!=null && ddlMinute!=null && ddlAmPm!=null )
            {
                var date = ddlDate.value;
                var hour = ddlHour.value;
                var min = ddlMinute.value;
                var ampm = ddlAmPm.value;
                //var date=self.opener.document.getElementById(PrefixID + 'ddlDate').value;
                //var hour=self.opener.document.getElementById(PrefixID + 'ddlHour').value;
                //var min=self.opener.document.getElementById(PrefixID + 'ddlMin').value;
                //var ampm=self.opener.document.getElementById(PrefixID + 'ddlAMPM').value;
                
                try
                {
                    if (date!=""){
			            document.getElementById("ddlDate").selectedIndex=1;
			            for (i=0;i<document.getElementById("ddlDate").length;i++){
				            if (document.getElementById("ddlDate").options(i).value==date){
		                     document.getElementById("ddlDate").selectedIndex=i;
		                     break;
				             }
			            }
		            }
                    if (hour!=""){
			            document.getElementById("ddlHour").selectedIndex=1;
			            for (i=0;i<document.getElementById("ddlHour").length;i++){
				            if (document.getElementById("ddlHour").options(i).value==hour){
		                     document.getElementById("ddlHour").selectedIndex=i;
		                     break;
				             }
			            }
		            }
                    if (min!=""){
			            document.getElementById("ddlMin").selectedIndex=1;
			            for (i=0;i<document.getElementById("ddlMin").length;i++){
				            if (document.getElementById("ddlMin").options(i).value==min){
		                     document.getElementById("ddlMin").selectedIndex=i;
		                     break;
				             }
			            }
		            }
                    if (ampm!=""){
			            document.getElementById("ddlAMPM").selectedIndex=1;
			            for (i=0;i<document.getElementById("ddlAMPM").length;i++){
				            if (document.getElementById("ddlAMPM").options(i).value==ampm){
		                     document.getElementById("ddlAMPM").selectedIndex=i;
		                     break;
				             }
			            }
		            }						
                }catch(ex){
                
                }
            }
        }
    }
	
    function disable(addr_type)
    {
        var objState = self.opener.document.getElementById(addr_type.toUpperCase() + "State");
        var txtCity = self.opener.document.getElementById(PrefixID + "txt" + addr_type.toUpperCase() + "City");
        var txtStNo = self.opener.document.getElementById(PrefixID + "txt" + addr_type.toUpperCase() + "StNo");
        var txtStName = self.opener.document.getElementById(PrefixID + "txt" + addr_type.toUpperCase() + "StName");
        var txtZip = self.opener.document.getElementById(PrefixID + "txt" + addr_type.toUpperCase() + "Zip");
        var txtPoint = self.opener.document.getElementById(PrefixID + "txt" + addr_type.toUpperCase() + "Point");
        var txtCross = self.opener.document.getElementById(PrefixID + "txt" + addr_type.toUpperCase() + "Cross");
        
        if (objState!=null)
            objState.style.display = "none";
        if (txtCity!=null)
            txtCity.className = "css_grayed";
        if (txtStNo!=null)
            txtStNo.className = "css_grayed";
        if (txtStName!=null)
            txtStName.className = "css_grayed";
        if (txtZip!=null)
            txtZip.className = "css_grayed";
        if (txtPoint!=null)
        {
            txtPoint.className = "css_grayed";
            txtPoint.focus;
        }
        if (txtCross!=null)
        {
            txtCross.className = "css_grayed";
            txtCross.focus;
        }
        
        /*if (addr_type=='p'||addr_type=="P")
        {
            self.opener.document.getElementById("PState").style.display='none';
            self.opener.document.getElementById(PrefixID + "txtPCity").style.color='gray';
            self.opener.document.getElementById(PrefixID + "txtPStNo").style.color='gray';
            self.opener.document.getElementById(PrefixID + "txtPStName").style.color='gray';
            self.opener.document.getElementById(PrefixID + "txtPZip").style.color='gray';
            self.opener.document.getElementById(PrefixID + "txtPPoint").focus;
        }
        else
        {
            self.opener.document.getElementById("PState").style.display='none';
            self.opener.document.getElementById(PrefixID + "txtDCity").style.color='gray';
            self.opener.document.getElementById(PrefixID + "txtDStNo").style.color='gray';
            self.opener.document.getElementById(PrefixID + "txtDStName").style.color='gray';
            self.opener.document.getElementById(PrefixID + "txtDZip").style.color='gray';
            self.opener.document.getElementById(PrefixID + "txtDCross").focus;
        }*/
    }