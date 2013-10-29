<%@ Control Language="VB" AutoEventWireup="false" CodeFile="calendar.ascx.vb" Inherits="Modules_calendar" %>
<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td><asp:DropDownList ID="ddlDate" runat="server"></asp:DropDownList>&nbsp;</td>
        <td>
            <asp:DropDownList ID="ddlHour" runat="server">
                <asp:ListItem Value="1">01</asp:ListItem>
                <asp:ListItem Value="2">02</asp:ListItem>
                <asp:ListItem Value="3">03</asp:ListItem>
                <asp:ListItem Value="4">04</asp:ListItem>
                <asp:ListItem Value="5">05</asp:ListItem>
                <asp:ListItem Value="6">06</asp:ListItem>
                <asp:ListItem Value="7">07</asp:ListItem>
                <asp:ListItem Value="8">08</asp:ListItem>
                <asp:ListItem Value="9">09</asp:ListItem>
                <asp:ListItem Value="10">10</asp:ListItem>
                <asp:ListItem Value="11">11</asp:ListItem>
                <asp:ListItem Value="12">12</asp:ListItem>
            </asp:DropDownList>&nbsp;:&nbsp;</td>
        <td>
            <asp:DropDownList ID="ddlMinute" runat="server">
                <asp:ListItem Value="0">00</asp:ListItem>
                <asp:ListItem Value="1">01</asp:ListItem>
                <asp:ListItem Value="2">02</asp:ListItem>
                <asp:ListItem Value="3">03</asp:ListItem>
                <asp:ListItem Value="4">04</asp:ListItem>
                <asp:ListItem Value="5">05</asp:ListItem>
                <asp:ListItem Value="6">06</asp:ListItem>
                <asp:ListItem Value="7">07</asp:ListItem>
                <asp:ListItem Value="8">08</asp:ListItem>
                <asp:ListItem Value="9">09</asp:ListItem>
                
                <asp:ListItem Value="10">10</asp:ListItem>
                <asp:ListItem Value="11">11</asp:ListItem>
                <asp:ListItem Value="12">12</asp:ListItem>
                <asp:ListItem Value="13">13</asp:ListItem>
                <asp:ListItem Value="14">14</asp:ListItem>
                <asp:ListItem Value="15">15</asp:ListItem>
                <asp:ListItem Value="16">16</asp:ListItem>
                <asp:ListItem Value="17">17</asp:ListItem>
                <asp:ListItem Value="18">18</asp:ListItem>
                <asp:ListItem Value="19">19</asp:ListItem>
                
                <asp:ListItem Value="20">20</asp:ListItem>
                <asp:ListItem Value="21">21</asp:ListItem>
                <asp:ListItem Value="22">22</asp:ListItem>
                <asp:ListItem Value="23">23</asp:ListItem>
                <asp:ListItem Value="24">24</asp:ListItem>
                <asp:ListItem Value="25">25</asp:ListItem>
                <asp:ListItem Value="26">26</asp:ListItem>
                <asp:ListItem Value="27">27</asp:ListItem>
                <asp:ListItem Value="28">28</asp:ListItem>
                <asp:ListItem Value="29">29</asp:ListItem>
                
                <asp:ListItem Value="30">30</asp:ListItem>
                <asp:ListItem Value="31">31</asp:ListItem>
                <asp:ListItem Value="32">32</asp:ListItem>
                <asp:ListItem Value="33">33</asp:ListItem>
                <asp:ListItem Value="34">34</asp:ListItem>
                <asp:ListItem Value="35">35</asp:ListItem>
                <asp:ListItem Value="36">36</asp:ListItem>
                <asp:ListItem Value="37">37</asp:ListItem>
                <asp:ListItem Value="38">38</asp:ListItem>
                <asp:ListItem Value="39">39</asp:ListItem>
                
                <asp:ListItem Value="40">40</asp:ListItem>
                <asp:ListItem Value="41">41</asp:ListItem>
                <asp:ListItem Value="42">42</asp:ListItem>
                <asp:ListItem Value="43">43</asp:ListItem>
                <asp:ListItem Value="44">44</asp:ListItem>
                <asp:ListItem Value="45">45</asp:ListItem>
                <asp:ListItem Value="46">46</asp:ListItem>
                <asp:ListItem Value="47">47</asp:ListItem>
                <asp:ListItem Value="48">48</asp:ListItem>
                <asp:ListItem Value="49">49</asp:ListItem>
                
                <asp:ListItem Value="50">50</asp:ListItem>
                <asp:ListItem Value="51">51</asp:ListItem>
                <asp:ListItem Value="52">52</asp:ListItem>
                <asp:ListItem Value="53">53</asp:ListItem>
                <asp:ListItem Value="54">54</asp:ListItem>
                <asp:ListItem Value="55">55</asp:ListItem>
                <asp:ListItem Value="56">56</asp:ListItem>
                <asp:ListItem Value="57">57</asp:ListItem>
                <asp:ListItem Value="58">58</asp:ListItem>
                <asp:ListItem Value="59">59</asp:ListItem>
            </asp:DropDownList>&nbsp;</td>
        <td>
            <asp:DropDownList ID="ddlAmPm" runat="server">
                <asp:ListItem>AM</asp:ListItem>
                <asp:ListItem>PM</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
</table>

