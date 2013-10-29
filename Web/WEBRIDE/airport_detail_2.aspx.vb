Imports Business
Imports Business.Common
Imports System.Data

Partial Class airport_detail_2
    Inherits System.Web.UI.Page
    
    Private Const PrefixClientID = "ctl00_content_"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strType, strAirCode, strAirName As String
        strAirCode = Request.QueryString("code")
        strAirName = Request.QueryString("name")
        strType = Request.QueryString("type")

        If Not strType Is Nothing Then
            If strType.ToLower = "p" Then
                Me.txtAirline.Text = Request.QueryString("airline")
                Me.txtFlightNo.Text = Request.QueryString("flight")
                Me.txtFbo.Text = Request.QueryString("terminal")
                Me.txtFboName.Text = Request.QueryString("fbo_name")
                Me.txtFboAddress.Text = Request.QueryString("fbo_address")
                Me.txtAirport_pu_point.Text = Request.QueryString("pu_point")
            ElseIf strType.ToLower = "d" Then
                Me.txtAirline.Text = Request.QueryString("airline")
                Me.txtFlightNo.Text = Request.QueryString("flight")
                Me.txtFbo.Text = Request.QueryString("terminal")
                Me.txtFboName.Text = Request.QueryString("fbo_name")
                Me.txtFboAddress.Text = Request.QueryString("fbo_address")
                Me.txtCity.Text = Request.QueryString("comment")
            End If
            ' Me.form1.Attributes.Add("onload", "LoadInfo('" & strType & "');")
        End If

        '## 11/21/2007  Added by yang
        If Not Request.QueryString("airtime") Is Nothing Then
            Me.hdnArrivalTime.Value = ShowDateTime(Request.QueryString("airtime"), DateTimeStyle.DateAndTime)
        End If

        Dim strMessage As String
        strMessage = "<script language=""JavaScript"" type=""text/javascript"">SetCurrentDateTime();"

        Me.ckPrivate.Attributes.Add("onclick", "display();")
        If Not strType Is Nothing Then

            Me.btnSubmit.Attributes.Add("onclick", "return save_data('" & strType & "');")
            Me.lnkSelect.NavigateUrl = "airport_detail_1.aspx?type=" & strType & ""

            If strType.ToLower = "p" Then
                strMessage = strMessage & "self.opener.document.getElementById('" & Me.PrefixClientID & "txtPCity').value='" & Replace(strAirName, "'", "") & "';"
                strMessage = strMessage & "self.opener.document.getElementById('" & Me.PrefixClientID & "ddlPAirport').value='" & strAirCode & "';"
                strMessage = strMessage & "self.opener.document.getElementById('" & Me.PrefixClientID & "ddlPState').value='" & strAirCode & "';"
                strMessage = strMessage & "document.getElementById('txtAirport_pu_point').style.display='none';"
                'strMessage = strMessage & "document.getElementById('trCity').style.display='none';"
                strMessage = strMessage & "document.getElementById('word').style.display='none';"
                strMessage = strMessage & "document.getElementById('" & Me.trPickup.ClientID & "').style.display='';"
            Else
                strMessage = strMessage & "self.opener.document.getElementById('" & Me.PrefixClientID & "txtDCity').value='" & Replace(strAirName, "'", "") & "';"
                strMessage = strMessage & "self.opener.document.getElementById('" & Me.PrefixClientID & "ddlDAirport').value='" & strAirCode & "';"
                strMessage = strMessage & "self.opener.document.getElementById('" & Me.PrefixClientID & "ddlDState').value='" & strAirCode & "';"
                'strMessage = strMessage & "alert(self.opener.document.getElementById('" & Me.PrefixClientID & "'ddlDAirport').value);"
                strMessage = strMessage & "document.getElementById('" & Me.trPickup.ClientID & "').style.display='none';"
                'strMessage = strMessage & "document.getElementById('trCity').style.display='';"
            End If

            If Me.txtAirline.Text.Trim = "PRIVATE" Then
                Me.ckPrivate.Checked = True
                strMessage = strMessage & "document.getElementById('txtAirline').style.display='none';"
                strMessage = strMessage & "document.getElementById('Private').style.display='';"
                strMessage = strMessage & "document.getElementById('Fbo').style.display='none';"
                strMessage = strMessage & "document.getElementById('FboDetail').style.display='';"
            End If
        End If
        strMessage = strMessage & "</script>"

        RegisterStartupScript("PopUpMessage", strMessage)

        GetDateTime()
        'If Not strAirName Is Nothing Then
        '    Me.lblAirport_name.Text = strAirName
        'End If
        If Not strType Is Nothing Then
            ' If strType = "p" OrElse strType = "pinfo" Then
            'Using gi As New GeoInfos
            '    Dim tmpDS As New DataSet
            '    If Not strAirCode Is Nothing Then
            '        tmpDS = gi.get_airport_pu_point(strAirCode, Me.txtFbo.Text.Trim)
            '    End If
            '    If (Not tmpDS Is Nothing) AndAlso tmpDS.Tables.Count > 0 And tmpDS.Tables(0).Rows.Count > 0 Then
            '        Me.ddlPAirPoint.DataSource = tmpDS
            '        Me.ddlPAirPoint.DataBind()
            '    Else
            With Me.ddlPAirPoint.Items
                .Add("Inside by baggage")
                .Add("Inside by customs")
                .Add("Outside by curb")
                .Add("At carousel")
                .Add("Bottom of escalators")
                .Add("Zero level")
            End With
            'Response.Write("<i><br>or type in point:</i>")
            Me.txtAirport_pu_point.Visible = True
            '    End If
            'End Using
            'End If
        End If

        '## 11/21/2007  Added by yang
        For Each li As ListItem In Me.ddlPAirPoint.Items
            If li.Text.Trim = Me.txtAirport_pu_point.Text.Trim Then
                Me.ddlPAirPoint.SelectedIndex = -1
                li.Selected = True
                Exit For
            End If
        Next


        If strAirCode <> "" And strAirName = "" Then
            Using gi As New GeoInfos
                Dim tmpDS As New DataSet
                tmpDS = gi.getAllAirport(strAirCode, "", "")
                If (Not tmpDS Is Nothing) AndAlso tmpDS.Tables.Count > 0 And tmpDS.Tables(0).Rows.Count > 0 Then
                    Me.lblAirport_name.Text = tmpDS.Tables(0).Rows.Item(0).Item("description").ToString
                End If
            End Using
        Else
            Me.lblAirport_name.Text = strAirName
        End If
        If Not IsPostBack Then
            Call getAirline(strAirCode)
        End If

        '## 11/21/2007  Added by yang
        Me.ddlDate.Style.Add("display", "none")
       
    End Sub
    Private Sub GetDateTime()
        Dim i As Int32
        '-- show Date  
        Me.ddlDate.Items.Clear()

        '## 11/21/2007  Modified by yang
        For i = 0 To 91
            Dim daytime As DateTime = DateAdd(DateInterval.Day, i, Now())

            Dim ddltext As String = ShowDateTime(daytime, DateTimeStyle.DateOnly) & " " & WeekdayName(Weekday(daytime), True)
            ' Dim ddltext As String = Month(daytime) & "/" & Day(daytime) & "/" & Year(daytime) & " " & Left(WeekdayName(Weekday(daytime)), 3)
            Dim ddlvalue As String = ShowDateTime(daytime, DateTimeStyle.DateOnly)
            Me.ddlDate.Items.Add(New ListItem(ddltext, ddlvalue))
            'Me.ddlDate.Items.Add(New ListItem(DateValue(CStr(DateAdd("d", i, Now))) & " " & WeekdayName(Weekday(DateValue(CStr(DateAdd("d", i, Now)))), True), DateValue(CStr(DateAdd("d", i, Now))).ToString))
        Next

        If Not Me.ddlDate.Items.FindByValue(ShowDateTime(Now, DateTimeStyle.DateOnly)) Is Nothing Then
            Me.ddlDate.SelectedIndex = -1
            Me.ddlDate.Items.FindByValue(ShowDateTime(Now, DateTimeStyle.DateOnly)).Selected = True
        End If
        'Me.ddlDate.Items.FindByValue(DateValue(Now.ToString).ToString).Selected = True     '-- default is today
        'Me.ddlDate.Items.FindByValue(strReqDateTime).Selected()

        '-- show Hour
        Me.ddlHour.Items.Clear()
        Me.ddlHour.Items.Add(New ListItem("-", ""))
        For i = 1 To 12
            Me.ddlHour.Items.Add(New ListItem(i.ToString, i.ToString))
        Next
        i = Hour(Now) Mod 12
        i = CInt(IIf(i = 0, 12, i))
        Me.ddlHour.Items.FindByValue(i.ToString).Selected = True    '-- default is now
        'Me.ddlDate.Items.FindByValue(strReqDateTime).Selected()

        '-- show minute
        '-- every 5 minite
        Me.ddlMin.Items.Clear()
        'Me.ddlMin.Items.Add(New ListItem("-", ""))
        For i = 0 To 59
            If i < 10 Then
                Me.ddlMin.Items.Add(New ListItem("0" + i.ToString, "0" + i.ToString))
            Else
                Me.ddlMin.Items.Add(New ListItem(i.ToString, i.ToString))
            End If
        Next
        ' Me.ddlMin.Items.FindByValue(Format(Minute(Now), "00")).Selected = True '-- default is close to now
        Me.ddlMin.SelectedIndex = Now.Minute
        '-- set default for am or pm
        If Hour(Now) < 12 Then
            Me.ddlAMPM.SelectedIndex = 0  '-- is am
        Else
            Me.ddlAMPM.SelectedIndex = 1  '-- is pm
        End If

        '## 11/21/2007  Added by yang
        If Me.hdnArrivalTime.Value.Trim.Length > 0 AndAlso IsDate(Me.hdnArrivalTime.Value) Then
            '## Get Date
            Dim ArrivalTime As System.DateTime = Convert.ToString(Me.hdnArrivalTime.Value)

            For Each li As ListItem In Me.ddlDate.Items
                If li.Value.Trim = Common.ShowDateTime(ArrivalTime) Then
                    Me.ddlDate.SelectedIndex = -1
                    li.Selected = True
                    Exit For
                End If
            Next

            '## Get Hour and AmPm
            Dim Hour As Integer = ArrivalTime.Hour
            If Hour < 12 Then
                Me.ddlAMPM.SelectedIndex = 0
            Else
                Me.ddlAMPM.SelectedIndex = 1
            End If
            If Me.ddlHour.Items.Count >= 12 Then
                If Hour > 0 AndAlso Hour <> 12 Then
                    Me.ddlHour.SelectedIndex = (Hour Mod 12)
                Else
                    Me.ddlHour.SelectedIndex = 12
                End If
            End If

            '## Get Minutes
            If Me.ddlMin.Items.Count > ArrivalTime.Minute Then
                Me.ddlMin.SelectedIndex = ArrivalTime.Minute
            End If
        End If

    End Sub
    Private Sub getAirline(ByVal airport As String)
        Dim airlines As New Business.GeoInfos
        Dim tmpDS As New DataSet
        Dim intflag As Integer = 0
        tmpDS = airlines.getAllAirline(airport.Trim, "")
        If Not tmpDS Is Nothing And tmpDS.Tables.Count > 0 Then
            With Me.ddlairportairline
                .DataSource = tmpDS
                .DataTextField = "airline"
                .DataValueField = "airline"
                .DataBind()

                '.Items.Add(New ListItem("-Please select airline-", ""))
                .Items.Insert(0, New ListItem("-Please select airline-", ""))
            End With
            intflag = 1 'hid textBox
            ' RegisterStartupScript("PopUpMessage", "<script language='JavaScript'>document.getElementById('txtAirline').style.display='none';</script>")
            Me.txtAirline.Visible = False
        Else
            intflag = 0 'show textBox
            ' RegisterStartupScript("PopUpMessage", "<script language='JavaScript'>document.getElementById('ddlairportairline').style.display='none';</script>")
            Me.ddlairportairline.Visible = False
        End If

        Me.hidAirlineFlag.Value = intflag.ToString.Trim

        'RegisterStartupScript("PopUpMessage", "<script language='JavaScript'></script>")
        '## 11/21/2007  Added by yang
        For Each li As ListItem In Me.ddlairportairline.Items
            If li.Value.Trim() = Me.txtAirline.Text.Trim Then
                Me.ddlairportairline.SelectedIndex = -1
                li.Selected = True
                Exit For
            End If
        Next

    End Sub

End Class
