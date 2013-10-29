<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"  enableEventValidation="false" AutoEventWireup="false" CodeFile="contact_us.aspx.vb" Inherits="contact" title="Untitled Page" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
<table width="808" border="0" align="center" cellpadding="0" cellspacing="0">
   <tr>
    <td colspan="2" valign="top" class="title" style="padding-top:10px;"><p>CONTACT US </p>
      <p class="main_text">Text Textt Text Textt Text Textt Text Textt Text Textt   Text 
      Textt Text Textt Text Textt Text Textt Text Textt Text Textt 
      Text   Textt Text Textt Text Textt Text Textt Text Textt Text <br />
      Textt Text Textt Text   Textt Text Textt      Text Textt Text Textt Text Textt Text Textt Text Textt   Text <br />
      Textt Text Textt Text Textt Text Textt Text Textt Text Textt <br />
      </p>
      <form name="formsend" id="formsend" action="/sendmail.cs" method="post">
        <table style="float:left;" width="385" border="0" align="left" cellpadding="2" cellspacing="5">
          <tr>
            <td width="84" align="right" class="news_title">Name:</td>
            <td width="488"><input name="sender_name" type="text" class="form_text" onfocus="_f=document.formsend;if(_f.sender_name.value=='Name') _f.sender_name.value=''" onblur="_f=document.formsend;if(_f.sender_name.value.length==0) _f.sender_name.value='Name'" value="Name" size="40" /></td>
          </tr>
          <tr>
            <td align="right" class="news_title">E-mail:</td>
            <td><input name="sender_email" type="text" class="form_text" onfocus="_f=document.formsend;if(_f.sender_email.value=='e-mail') _f.sender_email.value=''" onblur="_f=document.formsend;if(_f.sender_email.value.length==0) _f.sender_email.value='e-mail'"  value="e-mail" size="40" /></td>
          </tr>
          <tr>
            <td align="right" class="news_title">Phone:</td>
            <td><input name="sender_tel" type="text" class="form_text" onfocus="_f=document.formsend;if(_f.sender_tel.value=='000-00-00') _f.sender_tel.value=''" onblur="_f=document.formsend;if(_f.sender_tel.value.length==0) _f.sender_tel.value='000-00-00'"  value="000-00-00" size="30" /></td>
          </tr>
          <tr>
            <td align="right" valign="top" class="news_title">Message:</td>
            <td><textarea  name="message" cols="65" rows="12" class="form_text_area"></textarea></td>
          </tr>
          <tr>
            <td colspan="2" align="center"><input style="border:0px; background:url(images/send.jpg); width:67px; height:21px; cursor:pointer;" type="submit" name="Submit2" value="" />
            </td>
          </tr>
        </table>
        <input type="hidden" name="op" value="ds" />
      </form>
      <p class="main_text">&nbsp; </p>
      <p><br />
      <br />
    </p></td>
  </tr>
 
</table>
</asp:content>
