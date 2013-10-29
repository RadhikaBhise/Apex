Imports Business.Common
Imports Microsoft.VisualBasic

Partial Class Modules_calendar
    Inherits System.Web.UI.UserControl

    Private Const DateFormatString As String = "MM/dd/yyyy"
    Public Property DateTime() As DateTime
        Get
            Dim DateTimeString As String = Me.ddlDate.SelectedValue & " " & _
                    Me.ddlHour.SelectedValue & ":" & Me.ddlMinute.SelectedValue & " " & Me.ddlAmPm.SelectedValue

            If IsDate(DateTimeString) Then
                Return Convert.ToDateTime(DateTimeString)
            Else
                Return Now
            End If
        End Get
        Set(ByVal value As DateTime)
            '## Get Date
            For Each li As ListItem In Me.ddlDate.Items
                If IsDate(li.Value) AndAlso IsDate(value) AndAlso DateDiff(DateInterval.Day, CDate(li.Value), value) = 0 Then
                    Me.ddlDate.SelectedIndex = -1
                    li.Selected = True
                    Exit For
                End If
            Next

            '## Get Hour and AmPm
            Dim Hour As Integer = value.Hour
            If Hour < 12 Then
                Me.ddlAmPm.SelectedIndex = 0
            Else
                Me.ddlAmPm.SelectedIndex = 1
            End If
            If Me.ddlHour.Items.Count >= 12 Then
                If Hour > 0 AndAlso Hour <> 12 Then
                    Me.ddlHour.SelectedIndex = (Hour Mod 12) - 1
                Else
                    Me.ddlHour.SelectedIndex = 11
                End If
            End If

            '## Get Minutes
            If Me.ddlMinute.Items.Count > value.Minute Then
                Me.ddlMinute.SelectedIndex = value.Minute
            End If
        End Set
    End Property

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        For i As Int16 = 0 To 91
            Dim value As String = Now.AddDays(i).ToString("M/dd/yyyy")
            Dim text As String = Now.AddDays(i).ToString(DateFormatString) & " " & WeekdayName(Weekday(Now.AddDays(i)), True)
            Me.ddlDate.Items.Add(New ListItem(text, value))
        Next
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '## java script function to get the travel date
        '## "CalendarModule" & Me.ID & "GetTravelDate"
        Dim script As String = "<script type='text/javascript'>" & _
                            "function CalendarModule" & Me.ID & "GetTravelDate(){" & _
                                "var tdate=document.getElementById('" & Me.ddlDate.ClientID & "').options[document.getElementById('" & Me.ddlDate.ClientID & "').selectedIndex].value;" & _
                                "var thour=document.getElementById('" & Me.ddlHour.ClientID & "').options[document.getElementById('" & Me.ddlHour.ClientID & "').selectedIndex].value;" & _
                                "var tminute=document.getElementById('" & Me.ddlMinute.ClientID & "').options[document.getElementById('" & Me.ddlMinute.ClientID & "').selectedIndex].value;" & _
                                "var tampm=document.getElementById('" & Me.ddlAmPm.ClientID & "').options[document.getElementById('" & Me.ddlAmPm.ClientID & "').selectedIndex].text;" & _
                                "var travelDate=new Date(tdate+' '+thour+':'+tminute+':00 '+tampm);" & _
                                "return travelDate;}" & _
                            "</script>"

        Page.ClientScript.RegisterStartupScript(GetType(String), Me.ID & "GetTravelDate", script)
    End Sub

End Class
