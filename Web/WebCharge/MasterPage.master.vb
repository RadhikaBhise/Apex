Imports Business
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim time As String
        time = Format(Now, "h:mm:ss")
        If Convert.ToInt16(Now.Hour) >= 12 Then
            lbl_Time.Text = time & "  PM"
        Else
            lbl_Time.Text = time & "  AM"
        End If

        lbl_Date.Text = Format(Now, "M\/d\/yyyy")

        If Not MySession.AcctID Is Nothing And Convert.ToString(MySession.AcctID).Trim <> "" Then
            Me.lbl_Welcome.Text = "Welcome <font color='blue'>" & Convert.ToString(MySession.UserName).Trim() & "</font>&nbsp;/&nbsp;<font color='blue'>" & Convert.ToString(MySession.AcctID).Trim() & "</font>"
        Else
            Me.trwelcome.Visible = False

        End If

        Dim strReWebSitePage As String = System.Web.Configuration.WebConfigurationManager.AppSettings("ReservationWebSitePage")

        Me.Index1.HRef = strReWebSitePage
        Me.Index2.HRef = strReWebSitePage
        Me.Index3.HRef = strReWebSitePage

        Me.ContactUs.HRef = strReWebSitePage.Replace("index", "contact_us")
        Me.Reservations.HRef = strReWebSitePage.Replace("index", "reservation")
        Me.Rates.HRef = strReWebSitePage.Replace("index", "price")
        Me.Fleet.HRef = strReWebSitePage.Replace("index", "fleet")
        Me.News.HRef = strReWebSitePage.Replace("index", "News")
        Me.CO.HRef = strReWebSitePage.Replace("index", "company_overview")
        Me.CSC.HRef = strReWebSitePage.Replace("index", "customer_services")
        Me.OD.HRef = strReWebSitePage.Replace("index", "our_drivers")
        Me.CA.HRef = strReWebSitePage.Replace("index", "corporate_account")
        Me.IA.HRef = strReWebSitePage.Replace("index", "individual_account")
        Me.CP.HRef = strReWebSitePage.Replace("index", "cancellation_policy")
        Me.GT.HRef = strReWebSitePage.Replace("index", "global_travel")
        Me.AT.HRef = strReWebSitePage.Replace("index", "airport_transfer")
        Me.CM.HRef = strReWebSitePage.Replace("index", "conven+tion_meeting")
        Me.HC.HRef = strReWebSitePage.Replace("index", "hourly_charters")
        Me.SO.HRef = strReWebSitePage.Replace("index", "special_occasions")

        Me.order.HRef = strReWebSitePage.Replace("index.aspx", "order.aspx?cno=")
        Me.rideinquiry.HRef = strReWebSitePage.Replace("index", "rideinquiry")
        Me.ridehistory.HRef = strReWebSitePage.Replace("index", "ridehistory")
        Me.userprofile.HRef = strReWebSitePage.Replace("index", "userprofile")
        Me.logout.HRef = strReWebSitePage.Replace("index.aspx", "index.aspx?action=logout")

    End Sub
End Class

