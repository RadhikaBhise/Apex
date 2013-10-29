Imports Business
Imports Business.Common

Partial Class order
    Inherits System.Web.UI.Page

    Private trReq(5) As HtmlTableRow
    Private lblReq(5) As Label
    Private txtReq(5) As TextBox

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Me.Orderentry1.AcctID = MySession.AcctID
            Me.Orderentry1.UserID = MySession.UserID
            Me.Orderentry1.SubAcctID = MySession.SubAcctID
            Me.Orderentry1.Company = MySession.Company
            Me.Orderentry1.LoadPaymentTypeAndVehicleType()
            Me.Orderentry1.LoadCreditCardAndUserProfile()
            Me.Orderentry1.LoadCompanyRequirement()

            Me.Stop1.AcctID = MySession.AcctID
            Me.Stop1.UserID = MySession.UserID
            Me.Stop1.SubAcctID = MySession.SubAcctID
            Me.Stop1.Company = MySession.Company
            Me.Stop1.LoadStatesAndAirports()
            Me.Stop1.LoadFrequentAddress()

            Me.Stop2.AcctID = MySession.AcctID
            Me.Stop2.UserID = MySession.UserID
            Me.Stop2.SubAcctID = MySession.SubAcctID
            Me.Stop2.Company = MySession.Company
            Me.Stop2.LoadStatesAndAirports()
            Me.Stop2.LoadFrequentAddress()

            If Not Page.Request.QueryString("f") Is Nothing Then
                Me.hdnFrom.Value = Request.QueryString("f").Trim
            End If

            If Not Page.Request.QueryString("cno") Is Nothing Then
                Me.hdnConfNo.Value = Request.QueryString("cno").Trim

                If Me.hdnConfNo.Value.Trim.Length > 0 Then
                    Using orders As New Operators
                        Dim ord As OperatorData = orders.FillRides(Me.hdnConfNo.Value)
                        Me.LoadOrderDetailToScreen(ord)
                    End Using
                End If

                '## 12/12/2007  for ride history "Use This Data" function
                If Me.hdnFrom.Value.ToLower = "rh" Then
                    Me.hdnConfNo.Value = ""
                    Me.Orderentry1.TravelDateTime = Now
                End If
            ElseIf Not MySession.OperatorOrder Is Nothing Then
                If Not MySession.OperatorOrder.confirmation_no Is Nothing And Not MySession.OperatorOrder.confirmation_no.Trim.Length = 0 Then
                    Me.hdnConfNo.Value = MySession.OperatorOrder.confirmation_no
                End If
                Me.LoadOrderDetailToScreen(MySession.OperatorOrder)
            ElseIf Page.Request.QueryString("cno") Is Nothing Then
                MySession.OperatorOrder = Nothing
            End If

            Me.btnSubmit.Attributes.Add("onclick", "return ValidateOrderForm();")
        End If

        Me.GetBannerMessage()
    End Sub

    Private Sub GetBannerMessage()
        Using objNews As New Business.News
            Dim strbannermsg As String

            strbannermsg = objNews.GetBannerMessage(1)

            If strbannermsg <> "" Then
                Me.ltrBannerMsg.Text = String.Format("<marquee scrollAmount=2 onmouseover=stop() onmouseout=start()>{0}</marquee>", strbannermsg)
            End If

        End Using
    End Sub

    Private Sub LoadOrderDetailToScreen(ByVal ord As OperatorData)
        With ord
            Me.Orderentry1.LoadValueToScreen(ord)
            Me.Stop1.LoadValueToScreen(ord)
            Me.Stop2.LoadValueToScreen(ord)
        End With
    End Sub

    Private Sub GetOrderDetailFromScreen()
        Dim ord As New OperatorData

        If Me.hdnConfNo.Value.Trim.Length > 0 Then
            Using orders As New Operators
                ord.confirmation_no = Me.hdnConfNo.Value
                ord = orders.FillRides(ord.confirmation_no)
            End Using
        End If

        Me.Orderentry1.GetValueFromScreen(ord)
        Me.Stop1.GetValueFromScreen(ord)
        Me.Stop2.GetValueFromScreen(ord)

        MySession.OperatorOrder = ord

    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click
        '## add ValidateReq by joey 2/15/2008
        Dim ValidateReq As Boolean
        ValidateReq = Me.Orderentry1.ValidationCompanyRequirement()
        If ValidateReq = True Then
            Me.GetOrderDetailFromScreen()

            Dim ord As OperatorData = MySession.OperatorOrder

            If Not ord Is Nothing AndAlso IsDate(ord.req_date_time) Then
                Dim TravelTimeHourInterval As String = System.Web.Configuration.WebConfigurationManager.AppSettings("TravelTimeHourInterval")
                If IsNumeric(TravelTimeHourInterval) = False Then TravelTimeHourInterval = "2"

                If DateDiff(DateInterval.Hour, Convert.ToDateTime(Now()), Convert.ToDateTime(ord.req_date_time)) < CInt(TravelTimeHourInterval) Then
                    ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage", String.Format("<script language=JavaScript>alert('The request time is within {0} hours of the current time. Please choose another time that is outside the {0}-hour window.');</script>", TravelTimeHourInterval))
                    Exit Sub
                End If
            End If

            Response.Redirect("orderconfirm.aspx?f=order")
        End If
    End Sub

End Class
