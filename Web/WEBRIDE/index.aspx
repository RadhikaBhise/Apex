<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"  enableEventValidation="false" AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="index" title="Untitled Page" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
<table width="808" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td colspan="2" align="center">
        <table>
            <tr>
                <td align="center">
                    <img src="images/line1.jpg" height="150" hspace="0" vspace="5" style="width: 300px" />
                </td>
                <td style="width:30px"></td>
                <td align="center" style="width: 161px">
                    <img src="images/line2.jpg" height="150" vspace="5" style="width: 156px"  />
                </td>
                <td style="width: 10px">
                </td>
                <td align="center">
                    <%-- <img src="images/line3.jpg" width="238" height="145" vspace="5" /> --%>
                </td>
                <td style="width: 10px">
                </td>
                <td>
                    <img src="images/line4.jpg" height="150" vspace="5" border="0" style="width: 156px"  />
                </td>
            </tr>
        </table>
    </td>
  </tr>
  <tr>
    <td colspan="2" style="padding-top:10px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
    
        <tr>
          <td rowspan="2" valign="top" style="width: 284px"><img src="images/news_inform.gif" width="259" height="33" /><br />
          <table id="noticeTable" cellspacing="0" cellpadding="0"   border="0" style="width:100%" height="462px" class="css_table_frame">        
      <tr>       
      <td align="right">     
   <marquee id="mrqBanner" scrollAmount=2 onmouseover=stop() onmouseout=start()><font class="news_title"><%=BannerMsg%></font></marquee>
    </td>          
      <tr>       
      <td height="100%">     
   <iframe id="Fun" name="Fun" src="index_news.aspx" frameBorder="0"  width="100%" scrolling="no"  height="100%"></iframe>
    </td>
    </tr>
    </table>
            </td>
          <td width="525" valign="bottom" style="padding-top:15px; padding-left:15px;"><table width="100%" border="0" cellspacing="10" cellpadding="0">
              <tr>
			  	<td></td>
                <td valign="top"><p class="title">About APEX:</p>
                  <p><span class="main_text">Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. Lorem ipsum dolor sit amet, </span><span class="main_text">Lorem</span><br />
                      <a href="about.aspx" class="read_more" style="float:right;">READ MORE</a><br />
                  </p>
                  <hr color="#4990c8" /></td>
                  <td width="10px"></td>
                <td valign="top" style="padding-bottom:7px;"><div style="padding:1px; background-color:#3090d3;width:198px; height:141px;"><img src="images/pic1.jpg" width="196" height="139" align="top" style="border:1px solid #f2f7fc;" /></div></td>
              </tr>
            </table>
            <p class="title">
            </p>
</td>
        </tr>
        <tr>
          <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr><td valign="top" class="title" style="padding-top:15px; padding-left:30px; height: 331px;"><p>Our Services</p>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td valign="top"><p><span class="news_title"><a href="airport_transfer.aspx" class="news_title">Airport Transportation</a></span><br />
                    <span class="main_text">Enjoy a pleasant ride with a courteous driver from the moment you arrive to the moment you depart.</span><a href="airport_transfer.aspx" class="read_more" style="float:right;">READ MORE</a></p>
                  <p><span class="news_title"><a href="special_occasions.aspx" class="news_title">Special Occasions</a></span><br />
                    <span class="main_text">Chauffeured limousine services for birthdays, parties, evenings &quot;on the town,&quot; sporting events and more.</span><a href="special_occasions.aspx" class="read_more" style="float:right;">READ MORE</a></p>
                  <p><span class="news_title"><a href="hourly_charters.aspx" class="news_title">Hourly Charters</a></span><br />
                    <span class="main_text">Enjoy the flexibility and convenience of on-demand chauffeur service. The finest in Customized, as-directed chauffeur service is here for you.</span><a href="hourly_charters.aspx" class="read_more" style="float:right;">READ MORE</a></p></td>
				<td valign="top" width="20px"></td>
                <td valign="top"><p><span class="news_title"><a href="global_travel.aspx" class="news_title">Global Pickups</a></span><br />
                    <span class="main_text">You can count on us to deliver great service all over the world - wherever your travels take you. 24 hours a day, 7 days a week, 365 days a year.</span><a href="global_travel.aspx" class="read_more" style="float:right;">READ MORE</a></p>
                  <p><span class="news_title"><a href="convention_meeting.aspx" class="news_title">Conventions &amp; Meetings</a></span><br />
                    <span class="main_text">Professional transportation services are available to flawlessly execute all your transportation plans. We handle it all.</span><a href="convention_meeting.aspx" class="read_more" style="float:right;">READ MORE</a></p>
                  <p><span class="news_title"><a href="#" class="news_title">Attractions &amp; Sightseeing</a></span><br />
                    <span class="main_text">Professional transportation services are available to flawlessly execute all your transportation plans. We handle it all.</span><a href="#" class="read_more" style="float:right;">READ MORE</a></p></td>
              </tr>
            </table>            <p>&nbsp;</p></td>
        </tr></table></td></tr>
      </table></td>
  </tr>
</table> 
</asp:Content>
