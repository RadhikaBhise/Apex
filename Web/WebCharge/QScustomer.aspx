<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="QScustomer.aspx.vb" Inherits="QScustomer" title="Untitled Page" %>

<%@ Register Src="Modules/VoucherList.ascx" TagName="VoucherList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script language="javascript" type="text/javascript">
        
        function CustomerReferenceSubmitValidation(reqID)
        {
            var txtReq = document.getElementById(reqID);
            if (txtReq.value.length == 0)
            {
                alert("Please enter a search value.");
                return false;
            }
            
            return true;
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
    
    <form id="Form1" method="post" runat="server" style="width:100%">
        <table id="Table1" width="100%" border="0">
	        <tr>
		        <td colspan="6"></td>
	        </tr>
	        <tr>
		        <td class="css_header" colspan="6">Query &amp; Statistics: Customer Reference</td>
	        </tr>
            <tr>
                <td class="css_desc" style="width:20%">Select Customer Reference</td>
                <td class="css_desc" style="width:15%">Enter Search Value</td>
                <td class="css_desc" style="width:10%">From Date</td>
		        <td class="css_desc" style="width:10%">To Date</td>
		        <td class="css_desc" style="width:25%">Date Type</td>
		        <td class="css_desc" style="width:20%"></td>
            </tr>
            <tr>
                <td class="font3" style="width:20%" align="left">
		            <asp:dropdownlist id="lstCmpReq" runat="server" DataTextField="req_desc" DataValueField="req_id" Width="120px">
		            </asp:dropdownlist>
		        </td>
		        <td class="font3" style="width:15%" align="left"><asp:textbox id="txtSearchValue" runat="server" Columns="10" MaxLength="10"></asp:textbox>
		        </td>
		        <td class="font3" style="width:10%" align="left"><asp:textbox id="txtFromDate" runat="server" Columns="10" MaxLength="10" Width="100px"></asp:textbox></td>
		        <td class="font3" style="width:10%" align="left"><asp:textbox id="txtToDate" runat="server" Columns="10" MaxLength="10" Width="100px"></asp:textbox></td>
                <td class="font3" style="width:25%" align="left">
		            <asp:RadioButton ID="radTrip" runat ="server" GroupName="raddate" Text="Trip Date" Checked="true" />
			        <asp:RadioButton ID="radInvoice" runat ="server" GroupName="raddate" Text="Invoice Date" />
		        </td>
		        <td class="font3" style="width:20%" align="left"><asp:ImageButton ID="btnSubmit" ImageUrl="~/Images/Submit.gif"  runat="server"/></td>
            </tr>
            <tr>
                <td colspan="6"></td>
            </tr>
            <tr id="trData" runat="server">
		        <td align="left" colspan="6">
                    <uc1:VoucherList ID="VoucherList1" runat="server" />
		        </td>
	        </tr>
	        <tr>
		        <td align="center" colspan="6"></td>
	        </tr>
	        <tr class="noshown" id="trpage" runat="server">
		        <td align="center" class="css_font" colspan="6">
		            <br />
		            <a href ="default.aspx">Back To Main Menu</a>&nbsp;
		            <br />
                </td>
	        </tr>
        </table>
    </form>
</asp:Content>

