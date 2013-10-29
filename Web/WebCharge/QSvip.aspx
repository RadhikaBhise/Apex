<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="QSvip.aspx.vb" Inherits="QSvip" title="Untitled Page" %>

<%@ Register Src="Modules/VoucherList.ascx" TagName="VoucherList" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <script language="javascript" type="text/javascript">
        function batchvalidate(stracct,from,to)
        {

            var fromdate=document.getElementById(from).value;
            var todate=document.getElementById(to).value;

            if(fromdate=="")
	        {
		        alert("From Date should not be blank!");
		        return false;
	        }
	        if(todate=="")
	        {
		        alert("To Date should not be blank!");
		        return false;
	        }
	        if(!CheckDate(fromdate)){
	            alert("From Date is invalid!");
	            return false;
	        }
	        if(!CheckDate(todate)){
	            alert("From Date is invalid!");
	            return false;
	        }
            if((new Date(fromdate)).getYear() < (new Date()).getYear() - 5 || (new Date(todate)).getYear() < (new Date()).getYear() - 5){
                alert("Yesr must be entered between the range of "+ ((new Date()).getYear() - 5) +" and "+ (new Date()).getYear());
                return false;
                
            }

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
    </script>
        
    <form id="Form1" name="Form1" method="post" runat="server" style="text-align:left">
        <table id="tbSearch" width="800px" border="0" runat="server">
		    <tr>
			    <td class="css_header" colspan="4">Query &amp; Statistics: VIP</td>
		    </tr>
		    <tr id="trSelAcct" runat ="server">
			    <td class="css_desc" style="width:30%">VIP</td>
			    <td class="css_desc" style="width:20%">From Date</td>
			    <td class="css_desc" style="width:20%">To Date</td>
			    <td class="css_desc" style="width:30%"></td>
		    </tr>
		    <tr id="trVipList" runat="server">
			    <td class="font3" style="width:30%" align="left"><asp:dropdownlist id="ddlvipno" tabIndex="1" runat="server"></asp:dropdownlist></td>
			    <td class="font3" style="width:20%" align="left"><asp:textbox id="txtFromDate" tabIndex="2" runat="server" Width="100px" MaxLength="10"></asp:textbox></td>
			    <td class="font3" style="width:20%" align="left"><asp:textbox id="txtToDate" tabIndex="3" runat="server" Width="100px" MaxLength="10"></asp:textbox></td>
			    <td class="font3" style="width:30%" align="left"><asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/Images/Submit.gif" /></td>
		    </tr>
            <tr id="trData" runat="server">
		        <td colspan="4">
                    <uc1:VoucherList ID="VoucherList1" runat="server" />
		        </td>
            </tr>
            <tr class="noshown" id="trpage" runat="server">
	            <td align="center" class="css_font" colspan="4">
	                <br />
	                <a href="default.aspx">Back To Main Menu</a>
	                <br /><br />
                </td>
            </tr>
        </table>
    </form>
    
</asp:Content>

