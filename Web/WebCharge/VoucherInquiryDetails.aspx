<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="VoucherInquiryDetails.aspx.vb" Inherits="VoucherInquiryDetails"  title="Untitled Page"%>
<asp:content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<script type="text/javascript" language="javascript">
    function ShowVoucherImage(vno,cno)
    {
        var width = 700+30;    //window.screen.width - 150;
        var height = 400+40;   //window.screen.height - 230;
       
        window.open("voucherimage.aspx?vno="+vno+"&cno="+cno, "_VoucherDetail", "height=" + height
				                + ",left=75,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,"
				                + "toolbar=no,top=115,width=" + width);
	              
				              
    }
</script>
<form id="Form1" method="post" runat="server">
    <table cellspacing="0" cellpadding="0" border="0" style="width:100%" >
        <tr>
            <td align ="left" class="css_header" style="padding-left:80px">Your Requested Voucher Detail:
            </td>
        </tr>
       
        <tr>
			<td  align="center" >
				<table  cellspacing="2" cellpadding="2" border="0"  width="650px">
				    <tr>
				        <td class="css_desc" >Voucher No:
				        </td>
				        <td align="left">
				            <asp:LinkButton ID="lnkImage" runat="server" CssClass="css_lable" ForeColor ="Blue"></asp:LinkButton>
				            <%--<asp:Label ID="lblVoucherNo" runat ="server"  CssClass="css_lable"></asp:Label>--%>
				        </td>
				        <td class="css_desc">Invoice No:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblInvoiceNo" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				    </tr>
				    <tr>
				        <td class="css_desc">Invoice Date:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblInvoiceDate" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				        <td class="css_desc">Car No:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblCarNo" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				    </tr>
				    <tr>
				     <td class="css_desc">Passenger:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblPassenger" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				        <td class="css_desc">Pick Up Date:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblPUDate" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				     </tr>
				    <tr>
				         <td class="css_desc">Pick Up Time:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblPUTime" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				   
				        <td class="css_desc">Pick Up Address:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblPUAddress" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				    </tr>
				    <tr>  
				        <td class="css_desc">Destination:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblDestination" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>				        
				        <td class="css_desc">Base Rate:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblBaseRate" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				    </tr>
				    
				
				    
				    <tr>
				        <td class="css_desc">Tolls:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblTolls" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				        <td class="css_desc">Parking:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblParking" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				    </tr> 
				    <tr>
				        <td class="css_desc">Wait Amount:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblWaitAmount" runat ="server"  CssClass="css_lable"></asp:Label>
				        </td>
				        <td class="css_desc">Stop Amount:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblStAmount" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				    </tr>
				    <tr>
				        <td class="css_desc">Stop/Wait Amount:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblSWAmount" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				        <td class="css_desc">Package Amount:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblPackageAmount" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				    </tr>
				    <tr>
				        <td class="css_desc">Phone Amount:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblPhoneAmount" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				        <td class="css_desc">Service Fee:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblService" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				    </tr>
				    <tr>
				        <td class="css_desc">Miscellaneous:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblMiscellaneous" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				        <td class="css_desc">Tips:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblTips" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				    </tr>
				    <tr>
				        <td class="css_desc">Gross:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblGross" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				           <td class="css_desc">NYS Surcharge:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblSurcharge" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				        
				    </tr>
				    <tr>     
				        <td class="css_desc">Discount:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblDiscount" runat ="server"  CssClass="css_lable"></asp:Label>
				        </td>
				   
				        <td class="css_desc">Net:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblNet" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				        </tr>
				    <tr>    
				        <td class="css_desc">Comment:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblComment" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				           <td class="css_desc">CC Date:
				        </td>
				        <td  align="left">
				            <asp:Label ID="lblCcdate" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				    </tr>
				        <tr>  
				        <td class="css_desc" id="td1" runat="server" style="height: 27px">	
				            <asp:Label ID="tdComp1" runat ="server" ></asp:Label>

				        </td>
				        <td id="td2" runat="server"  align="left" style="height: 27px">
				            <asp:Label ID="lblComp1" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>				        
				        <td class="css_desc" id="td3" runat="server" style="height: 27px">	
				        <asp:Label ID="tdComp2" runat ="server" ></asp:Label>

				        </td>
				        <td id="td4" runat="server"  align="left" style="height: 27px">
				            <asp:Label ID="lblComp2" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				    </tr>
				    <tr>  
				        <td class="css_desc" id="td5" runat="server">	
				            <asp:Label ID="tdComp3" runat ="server" ></asp:Label>

				        </td>
				        <td id="td6" runat="server"  align="left">
				            <asp:Label ID="lblComp3" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>				        
				        <td class="css_desc" id="td7" runat="server">	
				            <asp:Label ID="tdComp4" runat ="server"></asp:Label>

				        </td>
				        <td id="td8" runat="server"  align="left">
				            <asp:Label ID="lblComp4" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				    </tr>
				    <tr>  
				        <td class="css_desc" id="td9" runat="server" >	
				            <asp:Label ID="tdComp5" runat ="server"></asp:Label>

				        </td>
				        <td id="td10" runat="server"  align="left">
				            <asp:Label ID="lblComp5" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>				        
				        <td class="css_desc" id="td11" runat="server" >	
				             <asp:Label ID="tdComp6" runat ="server" ></asp:Label>

				        </td>
				        <td id="td12" runat="server"  align="left"> 
				            <asp:Label ID="lblComp6" runat ="server" CssClass="css_lable"></asp:Label>
				        </td>
				    </tr>
				</table>
		
				
			</td>
		</tr>
		
		<tr class="noshown" id="trpage" runat="server">
			<td>
			 
				<br /><a href ="voucherinquiry.aspx">Back To Voucher Inquiry</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<a href ="default.aspx">Back To Main Menu</a><%--<asp:Button ID="btnExcel" runat ="server" Text ="Export To Excel Format" />--%>
			</td>
		</tr>
		<tr>
            <td align="center" style="height:40">
            </td>
        </tr>
    </table>
</form>
</asp:content>
