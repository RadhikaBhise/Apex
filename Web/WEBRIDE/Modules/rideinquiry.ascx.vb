Imports Business.Common
Imports Business.Security
Imports Business.Operators
Imports Business
Imports System.Data

Partial Class Modules_rideinquiry
    Inherits System.Web.UI.UserControl

    Private m_RideDataSet As DataSet
    Private m_EnableCancelRide As Boolean
    Private m_EnableModifyRide As Boolean
    Private m_EnablePaging As Boolean

    Private m_OrderModifyPage As String
    Private m_OrderDetailPage As String

    Public Event RideRefresh_Click()
    public event PageIndexChanged()

    Public WriteOnly Property RideDataSource() As DataSet
        Set(ByVal value As DataSet)
            Me.m_RideDataSet = value

            If Me.m_EnablePaging Then
                ViewState("RideDataSet") = Me.m_RideDataSet
            End If
        End Set
    End Property

    Public WriteOnly Property EnableCancelRide() As Boolean
        Set(ByVal value As Boolean)
            Me.m_EnableCancelRide = value
        End Set
    End Property
    Public WriteOnly Property EnableModifyRide() As Boolean
        Set(ByVal value As Boolean)
            Me.m_EnableModifyRide = value
        End Set
    End Property
    Public WriteOnly Property EnablePaging() As Boolean
        Set(ByVal value As Boolean)
            Me.m_EnablePaging = value
        End Set
    End Property

    Public Property OrderModifyPage() As String
        Get
            Return Me.m_OrderModifyPage
        End Get
        Set(ByVal value As String)
            Me.m_OrderModifyPage = value
        End Set
    End Property
    Public Property OrderDetailPage() As String
        Get
            Return Me.m_OrderDetailPage
        End Get
        Set(ByVal value As String)
            Me.m_OrderDetailPage = value
        End Set
    End Property

    Public Sub BindRideData()
        If Not Me.m_RideDataSet Is Nothing AndAlso Me.m_RideDataSet.Tables.Count > 0 Then
            Me.grdData.DataSource = Me.m_RideDataSet.Tables(0).DefaultView
            '## add by joey 3/13/2008
            If Me.grdData.CurrentPageIndex + 1 > Math.Ceiling(Me.m_RideDataSet.Tables(0).Rows.Count / Me.grdData.PageSize) Then
                Me.grdData.CurrentPageIndex = 0
            End If

            Try
                Me.grdData.DataBind()
            Catch ex As Exception
                Dim err As String = ex.Message
            End Try

        End If
    End Sub

#Region " Data Grid Events "

    Protected Sub grdData_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdData.DeleteCommand
        Dim message As String = ""
        Dim out As Integer = 0
        Dim ConfNo As String = Convert.ToString(e.CommandArgument).Trim()

        Using rides As New Business.Rides
            out = rides.CancelRide(ConfNo)
        End Using

        Select Case out
            Case 1
                CreateMailBody(ConfNo, "", "")
                message = Msg.GetErrorMsg(Msg.MsgType.CancelOrderSuccessful)
            Case -2
                message = Msg.GetErrorMsg(Msg.MsgType.CancelOrderFailedForTimeClosely)
            Case Else
                message = Msg.GetErrorMsg(Msg.MsgType.CancelOrderFailed)
        End Select

        If message.Length > 0 Then
            Page.ClientScript.RegisterStartupScript(GetType(String), "Message", String.Format("<script type='text/javascript'>alert('{0}');</script>", message))
        End If

        '## added by joey   11/22/2007  refresh the rideInquiry
        RaiseEvent RideRefresh_Click()
    End Sub

    Protected Sub grdData_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdData.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim ConfNo As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "confirmation_no")).Trim()
            Dim StatusFlag As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "status_flag")).Trim().ToUpper()
            Dim CarNo As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "car_no")).Trim()
            Dim ReqDateTime As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "req_date_time")).Trim()
            Dim PuPhone As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_phone")).Trim

            Dim EtaTime As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "eta_time")).Trim()
            Dim CarType As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "car_type_desc")).Trim

            Dim PriceEst As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "price_est")).Trim

            Dim OnSceneTime As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "os_date_time")).Trim
            Dim LoadTime As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "ld_date_time")).Trim
            Dim UnloadTime As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "ul_date_time")).Trim

            '## add by joey 6/3/2008
            Dim car_type As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "car_type")).Trim

            Dim StNo, StName, City, County, Zip, Landmark As String
            Dim Airport, Airline, Flight, PuPoint As String

            Dim lnkConfNo As HyperLink = CType(e.Item.FindControl("lnkConfNo"), HyperLink)
            Dim btnCancel As LinkButton = CType(e.Item.FindControl("btnCancel"), LinkButton)
            Dim btnModify As HyperLink = CType(e.Item.FindControl("btnModify"), HyperLink)
            Dim imgCancel As Web.UI.WebControls.Image = CType(e.Item.FindControl("imgCancel"), Web.UI.WebControls.Image)
            Dim imgModify As Web.UI.WebControls.Image = CType(e.Item.FindControl("imgModify"), Web.UI.WebControls.Image)

            Dim lblOnScene As Label = CType(e.Item.FindControl("lblOnScene"), Label)
            Dim lblLoad As Label = CType(e.Item.FindControl("lblLoad"), Label)
            Dim lblUnload As Label = CType(e.Item.FindControl("lblUnload"), Label)

            Dim lblStatus As Label = CType(e.Item.FindControl("lblStatus"), Label)

            Dim lblPuPhone As Label = CType(e.Item.FindControl("lblDPhone"), Label)

            Dim lblReqDateTime As Label = CType(e.Item.FindControl("lblReqDateTime"), Label)
            Dim lblCarNo As Label = CType(e.Item.FindControl("lblCarNo"), Label)
            Dim lblETA As Label = CType(e.Item.FindControl("lblETA"), Label)
            Dim lblPickup As Label = CType(e.Item.FindControl("lblPickup"), Label)
            Dim lblDropoff As Label = CType(e.Item.FindControl("lblDropoff"), Label)

            Dim lblPriceEst As Label = CType(e.Item.FindControl("lblPriceEst"), Label)
            '--add by daniel 06/12/2007 for the Passenger Name
            CType(e.Item.FindControl("lblName"), Label).Text = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "fname")).Trim & ", " & Convert.ToString(DataBinder.Eval(e.Item.DataItem, "lname")).Trim

            '## add by joey
            lblETA.Text = EtaTime & " / " & CarType
            If Val(PriceEst) > 0 Then
                lblPriceEst.Text = ShowPrice(PriceEst, PricePrefix.dollar)
            Else
                lblPriceEst.Text = ""
            End If

            lblPuPhone.Text = ShowPhoneNo(PuPhone)

            '## Load Conf # link
            lnkConfNo.Text = Right(ConfNo, 4)
            If (StatusFlag = "R" OrElse StatusFlag = "Q" OrElse StatusFlag = "L") AndAlso CarNo.Length = 0 Then
                If Me.m_EnableModifyRide AndAlso (Not Me.m_OrderModifyPage Is Nothing) _
                        AndAlso Me.m_OrderModifyPage.Trim.Length > 0 Then
                    btnModify.Visible = True
                    btnModify.NavigateUrl = "../" & Me.m_OrderModifyPage & "?cno=" & ConfNo
                Else
                    btnModify.Visible = False
                End If

                'btnCancel.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to cancel this order?');")
                If Me.m_EnableCancelRide Then
                    btnCancel.Visible = True
                Else
                    btnCancel.Visible = False
                End If
            Else
                btnModify.Visible = False
                btnCancel.Visible = False
            End If
            imgModify.Visible = btnModify.Visible
            imgCancel.Visible = btnCancel.Visible

            If Not Me.m_OrderDetailPage Is Nothing AndAlso Me.m_OrderDetailPage.Trim.Length > 0 Then
                lnkConfNo.ToolTip = "Click here to view order detail."
                lnkConfNo.NavigateUrl = "../" & m_OrderDetailPage & "?cno=" & ConfNo
            Else
                lnkConfNo.ToolTip = ""
                lnkConfNo.NavigateUrl = ""
            End If

            '## Load Status
            Select Case StatusFlag
                Case "R", "Q"
                    lblStatus.Text = "RESERVATION"
                Case "L"
                    lblStatus.Text = "LIVE"
                Case "D"
                    lblStatus.Text = "DISPATCHED"
                Case "F"
                    lblStatus.Text = "CANCELLED"
                Case "C"
                    lblStatus.Text = "CANCELLED"
                Case "T"
                    lblStatus.Text = "PROCESSING"
                Case "K"
                    lblStatus.Text = "CONFIRMED"
                Case Else
                    lblStatus.Text = ""
            End Select


            '## Load Trip Date
            lblReqDateTime.Text = ShowDateTime(ReqDateTime, DateTimeStyle.DateAndTime)

            lblOnScene.Text = ShowDateTime(OnSceneTime, DateTimeStyle.DateAndTime)
            lblLoad.Text = ShowDateTime(LoadTime, DateTimeStyle.DateAndTime)
            lblUnload.Text = ShowDateTime(UnloadTime, DateTimeStyle.DateAndTime)

            '## Load Pickup
            StNo = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_st_no")).Trim()
            StName = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_st_name")).Trim()
            City = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_city")).Trim()
            County = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_county")).Trim()
            Zip = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_city")).Trim()
            Landmark = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_landmark")).Trim()

            Airport = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "airport_name")).Trim
            Airline = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "airport_airline")).Trim
            Flight = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "airport_flight")).Trim
            PuPoint = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "airport_pu_point")).Trim

            If IsAirport(County) Then
                lblPickup.Text = ShowAirportAddress(Airport, Airline, Flight, PuPoint)
            Else
                lblPickup.Text = ShowAddress(StNo, StName, City, County, "", Landmark)
            End If

            '## Load Dropoff
            StNo = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_st_no")).Trim()
            StName = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_st_name")).Trim()
            City = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_city")).Trim()
            County = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_county")).Trim()
            Zip = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_city")).Trim()
            Landmark = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_landmark")).Trim()

            Airport = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_airport_name")).Trim
            Airline = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_airport_airline")).Trim
            Flight = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_airport_flight")).Trim

            If IsAirport(County) Then
                lblDropoff.Text = ShowAirportAddress(Airport, Airline, Flight, "")
            Else
                lblDropoff.Text = ShowAddress(StNo, StName, City, County, "", Landmark)
            End If

            '## add by joey 6/3/2008
            '## 6/10/2008   Add Val() by yang
            If Val(car_type) >= 2 AndAlso Val(car_type) <= 12 Then
                btnCancel.Attributes.Add("onclick", "javascript:alert('This job may not be cancelled online, please call 718-522-1313.');return false;")
            End If
        End If
    End Sub

    '------------------------------------------------------------------------------
    '--Function:CreateMailBody
    '--Description:create mail body ,ready to send
    '--Input:ConfNo,Status,Email_address
    '--Output:Mail body string
    '--12/06/07 - Modify some code (Daniel)
    '------------------------------------------------------------------------------
    Private Function CreateMailBody(ByVal ConfNo As String, ByVal Status As String, ByRef strMail As String) As String

        Dim strBody As String = ""
        Dim title As String
        Dim strEnd As String = ""
        Dim strBegin As String = ""
        Dim HTML_HEADER, HTML_FOOTER As String
        Dim TD_LABEL, TD_TEXT As String
        Dim FONT_LABEL, FONT_TEXT, FONT_TERMS As String

        TD_LABEL = "<td bgcolor=""lightgrey"">"
        FONT_LABEL = "<font face=""arial"" size=""2""><b>"
        FONT_TEXT = "<font face=""arial"" size=""2"">"
        FONT_TERMS = "<font face=""arial"" size=""1"">"

        'title = "Your request of confirm#: " & strconfno & "/" & Session("user_name").ToString & " (Please do not reply to this email)"
        title = "APEX Confirmation#: " & ConfNo & "/" & MySession.UserName & " (Please do not reply to this email)"

        HTML_HEADER = "<html><head>" & vbCrLf
        HTML_HEADER = HTML_HEADER & "</head><body TOPMARGIN=""0"" MARGINHEIGHT=""0"" MARGINWIDTH=""0"">"
        HTML_FOOTER = "</body></html>"
        strBody = strBody & "<table width=""100%""><tr><td>"
        strBody = strBody & "<font face=""arial"" size=""2"">"
        strBody = strBody & "Thank you for booking with APEX. Per your "
        strBody = strBody & "request, your reservation has been CANCELLED."
        strBody = strBody & "</font></td></tr></table>"

        strBody = strBody & "<table cellpadding=2>"
        Dim oper As New Business.Operators

        Dim mailfields(40) As String
        Dim mailvalues(40) As String

        'Dim strMail As String = ""
        '-- modify by eJay 12/15/04
        Call oper.Get_email_Details(ConfNo, "", strMail)

        Dim i As Int32 = 0
        Dim iCount As Int32 = oper.Count
        mailfields = oper.Fields
        mailvalues = oper.Values

        '--add by daniel 2005-11-18
        For i = 0 To iCount - 1
            strBody = strBody & "<tr>" & TD_LABEL & FONT_LABEL
            strBody = strBody & mailfields(i) & "</td><td>" & FONT_TEXT
            strBody = strBody & " " & vbCrLf
            strBody = strBody & mailvalues(i) & "</td></tr>"
        Next i
        strBody = strBody & "</table>"
  
        Dim mto(1, 1) As String
        mto(0, 0) = strMail
        mto(0, 1) = ""
        Dim mcc(,) As String
        Dim mbcc(,) As String
        Dim matt() As String
        Dim strReturn As String
        strReturn = Business.Mail.SendEmail("", strMail, title, strBody, True)
        If strReturn = "Success" Then
            'do nothing
        Else
            '--do nothing
            strReturn = ""
        End If

        Return strReturn

    End Function

#End Region

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Me.m_EnableCancelRide = False
        'Me.m_EnableModifyRide = False
        Me.grdData.AllowPaging = Me.m_EnablePaging
        'Me.grdData.DataBind()
    End Sub

    Protected Sub grdData_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdData.PageIndexChanged
        Try
            If Not ViewState("RideDataSet") Is Nothing Then
                Me.grdData.DataSource = ViewState("RideDataSet")
                Me.grdData.CurrentPageIndex = e.NewPageIndex
                Me.grdData.DataBind()
            End If
        Catch
        End Try
    End Sub

    '## add by joey 4/28/2008
    Private Function IsAirport(ByVal county As String) As Boolean
        Dim out As Boolean
        Using objAddress As New Address
            out = objAddress.is_airport(county)
        End Using
        Return out
    End Function
End Class
