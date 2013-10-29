<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RptOfDay.aspx.vb" Inherits="RptOfDay" title="Untitled Page" %>

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
            if((new Date(fromdate)).getYear() < (new Date()).getYear() - 5 || (new Date(todate)).getYear() < (new Date()).getYear() - 5)
            {
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
        
    <form id="Form1" method="post" runat="server" style="text-align:left">
        <table width="800px" id="tbSearch" runat="server">
        	
	        <tr>
		        <td class="css_header" colspan="5">Time of Day Report
		        </td>
	        </tr>
            <tr align="left">
		        <td class="css_desc" style="width:20%">From Trip Date</td>
		        <td class="css_desc" style="width:20%">To Trip Date</td>
		        <td class="css_desc" style="width:20%">From:</td>
		        <td class="css_desc" style="width:20%">To:</td>
		        <td class="css_desc" style="width:20%"></td>
	        </tr>
	        <tr align="left">
	            <td style="width:20%" class="font3" align="left"><asp:textbox id="txtFromDate" Runat="server"></asp:textbox></td>
		        <td style="width:20%" class="font3" align="left"><asp:textbox id="txtToDate" Runat="server"></asp:textbox></td>
		        <td style="width:20%" class="font3" align="left"><asp:dropdownlist id="drpfrom" Runat="server" Width="100%">
				        <asp:ListItem Value="0" Selected="True">00:00</asp:ListItem>
				        <asp:ListItem Value="1">01:00</asp:ListItem>
				        <asp:ListItem Value="2">02:00</asp:ListItem>
				        <asp:ListItem Value="3">03:00</asp:ListItem>
				        <asp:ListItem Value="4">04:00</asp:ListItem>
				        <asp:ListItem Value="5">05:00</asp:ListItem>
				        <asp:ListItem Value="6">06:00</asp:ListItem>
				        <asp:ListItem Value="7">07:00</asp:ListItem>
				        <asp:ListItem Value="8">08:00</asp:ListItem>
				        <asp:ListItem Value="9">09:00</asp:ListItem>
				        <asp:ListItem Value="10">10:00</asp:ListItem>
				        <asp:ListItem Value="11">11:00</asp:ListItem>
				        <asp:ListItem Value="12">12:00</asp:ListItem>
				        <asp:ListItem Value="13">13:00</asp:ListItem>
				        <asp:ListItem Value="14">14:00</asp:ListItem>
				        <asp:ListItem Value="15">15:00</asp:ListItem>
				        <asp:ListItem Value="16">16:00</asp:ListItem>
				        <asp:ListItem Value="17">17:00</asp:ListItem>
				        <asp:ListItem Value="18">18:00</asp:ListItem>
				        <asp:ListItem Value="19">19:00</asp:ListItem>
				        <asp:ListItem Value="20">20:00</asp:ListItem>
				        <asp:ListItem Value="21">21:00</asp:ListItem>
				        <asp:ListItem Value="22">22:00</asp:ListItem>
				        <asp:ListItem Value="23">23:00</asp:ListItem>
			        </asp:dropdownlist></td>
		        <td style="width:20%" class="font3" align="left"><asp:dropdownlist id="drpto" Runat="server" Width="100%">
				        <asp:ListItem Value="0" Selected="True">00:00</asp:ListItem>
				        <asp:ListItem Value="1">01:00</asp:ListItem>
				        <asp:ListItem Value="2">02:00</asp:ListItem>
				        <asp:ListItem Value="3">03:00</asp:ListItem>
				        <asp:ListItem Value="4">04:00</asp:ListItem>
				        <asp:ListItem Value="5">05:00</asp:ListItem>
				        <asp:ListItem Value="6">06:00</asp:ListItem>
				        <asp:ListItem Value="7">07:00</asp:ListItem>
				        <asp:ListItem Value="8">08:00</asp:ListItem>
				        <asp:ListItem Value="9">09:00</asp:ListItem>
				        <asp:ListItem Value="10">10:00</asp:ListItem>
				        <asp:ListItem Value="11">11:00</asp:ListItem>
				        <asp:ListItem Value="12">12:00</asp:ListItem>
				        <asp:ListItem Value="13">13:00</asp:ListItem>
				        <asp:ListItem Value="14">14:00</asp:ListItem>
				        <asp:ListItem Value="15">15:00</asp:ListItem>
				        <asp:ListItem Value="16">16:00</asp:ListItem>
				        <asp:ListItem Value="17">17:00</asp:ListItem>
				        <asp:ListItem Value="18">18:00</asp:ListItem>
				        <asp:ListItem Value="19">19:00</asp:ListItem>
				        <asp:ListItem Value="20">20:00</asp:ListItem>
				        <asp:ListItem Value="21">21:00</asp:ListItem>
				        <asp:ListItem Value="22">22:00</asp:ListItem>
				        <asp:ListItem Value="23">23:00</asp:ListItem>
			        </asp:dropdownlist></td>
		        <td style="width:20%" class="font3" align="left"><asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/Images/Submit.gif" /></td>
	        </tr>
	        <tr id="trData" runat="server" visible="false"><td colspan="5">
                <uc1:VoucherList ID="VoucherList1" runat="server" />
            </td></tr>
            <tr>
                <td align="center" colspan="5"><br />
                    <a href ="rptmenu.aspx">Back To Report Page</a> &nbsp; &nbsp;&nbsp;&nbsp;
		            <a href ="default.aspx">Back To Main Menu</a>
                    <br /><br />
                </td>
            </tr>
        </table>

    </form>
</asp:Content>

