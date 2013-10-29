Imports Business
Imports DataAccess
Imports Business.Common

Partial Class QuickOrderForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then


            Me.Orderentry1.LoadPaymentTypeAndVehicleType()
            Me.Orderentry1.LoadCompanyRequirement()

            Me.Stop1.LoadStatesAndAirports()

            Me.Stop2.LoadStatesAndAirports()

            Using orders As New Operators
                If Not MySession.OperatorOrder Is Nothing Then
                    Me.LoadOrderDetailToScreen(MySession.OperatorOrder)
                End If

            End Using

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

        Me.Orderentry1.GetValueFromScreen(ord)
        Me.Stop1.GetValueFromScreen(ord)
        Me.Stop2.GetValueFromScreen(ord)

        ord.vip_no = MySession.UserID

        MySession.OperatorOrder = ord

    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click

        MySession.AcctID = System.Web.Configuration.WebConfigurationManager.AppSettings("QuickOrderDefaultAcctID")
        MySession.SubAcctID = System.Web.Configuration.WebConfigurationManager.AppSettings("QuickOrderDefaultSubAcctID")
        MySession.Company = System.Web.Configuration.WebConfigurationManager.AppSettings("QuickOrderDefaultCompany")
        MySession.Table_ID = "1"

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

        Response.Redirect("quickorderconfirm.aspx")

    End Sub

End Class
