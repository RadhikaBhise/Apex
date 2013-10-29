Imports Business
Imports Business.Common
Imports Business.Security
Imports System.Data

Partial Class Modules_group_ridehistory
    Inherits System.Web.UI.UserControl

    Private m_RideDataSet As DataSet
    Private m_EnableCancelRide As Boolean
    Private m_EnableModifyRide As Boolean
    Private m_lnkConfNo As String
    Private m_IsEffiliate As Boolean
    Public Event RideRefresh_Click()

#Region "Public Property"

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

    Public Property lnkConfNo() As String
        Get
            Return m_lnkConfNo
        End Get
        Set(ByVal value As String)
            Me.m_lnkConfNo = value
        End Set
    End Property

    Public WriteOnly Property RideDataSource() As DataSet
        Set(ByVal value As DataSet)
            Me.m_RideDataSet = value
        End Set
    End Property

    Public WriteOnly Property IsEffiliate() As Boolean
        Set(ByVal value As Boolean)
            Me.m_IsEffiliate = value
        End Set
    End Property
    'Public Sub BindRideData()
    '    If Not Me.m_RideDataSet Is Nothing AndAlso Me.m_RideDataSet.Tables.Count > 0 Then
    '        Me.dgRides.DataSource = Me.m_RideDataSet.Tables(0).DefaultView
    '        Me.dgRides.DataBind()
    '    End If
    'End Sub

#End Region

#Region "Page Events"

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Me.m_EnableCancelRide = True
        Me.m_EnableModifyRide = True
    End Sub

#End Region

#Region " Data Grid Events "

    Protected Sub dgRides_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgRides.DeleteCommand
        Dim message As String = ""
        Dim out As Integer = 0
        Dim ConfNo As String = Convert.ToString(e.CommandArgument).Trim()

        Using rides As New Business.Rides
            out = rides.CancelRide(ConfNo)
        End Using

        Select Case out
            Case 1
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

    'Protected Sub dgRides_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgRides.ItemCommand
    '    If e.CommandName = "OnClickConf" Then
    '        Me.ViewState("sort") = "confirmation_no desc"
    '    ElseIf e.CommandName = "OnClickPickup" Then
    '        Me.ViewState("sort") = "pu_landmark,pu_st_no,pu_st_name,pu_city asc"
    '    ElseIf e.CommandName = "OnClickDest" Then
    '        Me.ViewState("sort") = "dest_landmark,dest_st_no,dest_st_name,dest_city desc"
    '    ElseIf e.CommandName = "OnClickStatus" Then
    '        Me.ViewState("sort") = "status_flag desc"
    '    ElseIf e.CommandName = "OnClickPrice" Then
    '        Me.ViewState("sort") = "price_est desc"
    '    ElseIf e.CommandName = "OnClickTime" Then
    '        Me.ViewState("sort") = "display_date_time desc"
    '    End If
    '    ' RaiseEvent RideSort_Click()
    'End Sub

    Protected Sub dgRides_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgRides.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim objItem As Object
            '--confirmation_no
            Dim strconfirmaton_no As String
            Dim objConfirmation As Object
            objConfirmation = DataBinder.Eval(e.Item.DataItem, "confirmation_no")

            strconfirmaton_no = Right(Convert.ToString(objConfirmation).Trim(), 4)

            CType(e.Item.FindControl("hy1"), HyperLink).Text = Right(strconfirmaton_no, 4)
            CType(e.Item.FindControl("hy1"), HyperLink).NavigateUrl = "group_detail.aspx?cid=" & objConfirmation & "&revive=ridehist"

            '--Status_flag
            Dim strStatus As String
            objItem = DataBinder.Eval(e.Item.DataItem, "status_flag")
            strStatus = Convert.ToString(objItem).Trim()
            Select Case strStatus
                Case "R", "Q"
                    CType(e.Item.FindControl("lblStatus"), Label).Text = "RESERVATION"
                Case "L"
                    CType(e.Item.FindControl("lblStatus"), Label).Text = "LIVE"
                Case "D", "M"
                    CType(e.Item.FindControl("lblStatus"), Label).Text = "DISPATCHED"
                Case "F", "C"
                    CType(e.Item.FindControl("lblStatus"), Label).Text = "CANCELLED"
                Case "T"
                    CType(e.Item.FindControl("lblStatus"), Label).Text = "PROCESSING"
                Case "K"
                    CType(e.Item.FindControl("lblStatus"), Label).Text = "COMPLETED"
                Case Else
                    CType(e.Item.FindControl("lblStatus"), Label).Text = ""
            End Select

            '-- set passenger name
            CType(e.Item.FindControl("lblName"), Label).Text = DataBinder.Eval(e.Item.DataItem, "lname").ToString.Trim & " , " & DataBinder.Eval(e.Item.DataItem, "fname").ToString.Trim

            '--Links
            objItem = DataBinder.Eval(e.Item.DataItem, "car_no")
            Dim strCarNo As String
            strCarNo = Convert.ToString(objItem).Trim()
            objItem = DataBinder.Eval(e.Item.DataItem, "display_date_time")

            Dim dtPu As DateTime
            dtPu = Convert.ToDateTime(objItem)
            Dim intTemp As Int64
            intTemp = DateDiff("n", Now, dtPu)

            If (strStatus = "L" Or strStatus = "R") And strCarNo = "" And intTemp > 720 Then

                CType(e.Item.FindControl("img1"), Image).Visible = True
                CType(e.Item.FindControl("lbCancel"), LinkButton).Visible = True
                CType(e.Item.FindControl("lbCancel"), LinkButton).CssClass = DataBinder.Eval(e.Item.DataItem, "confirmation_no").ToString.Trim()

                CType(e.Item.FindControl("img2"), Image).Visible = True
                CType(e.Item.FindControl("hyModify"), HyperLink).Visible = True
                Dim strNEW As String

                strNEW = DataBinder.Eval(e.Item.DataItem, "confirmation_no").ToString
                CType(e.Item.FindControl("hyModify"), HyperLink).NavigateUrl = "group_orderform.aspx?cno=" & strNEW
            ElseIf strStatus <> "F" And strStatus <> "C" And strStatus <> "K" Then
                CType(e.Item.FindControl("lblShow"), Label).Visible = True
                CType(e.Item.FindControl("lblShow"), Label).Text = CType(e.Item.FindControl("lblShow"), Label).Text & System.Web.Configuration.WebConfigurationManager.AppSettings("phone_number")
            End If

            '--Car#
            If strStatus = "D" Or strStatus = "K" Then

                Dim i As Int32
                For i = 1 To Len(strCarNo)
                    If Left(strCarNo, 1) = "0" Then
                        strCarNo = Right(strCarNo, Len(strCarNo) - 1)
                    Else
                        Exit For
                    End If
                Next
                CType(e.Item.FindControl("lblCarNo"), Label).Text = strCarNo
            End If

            '--ETA
            Dim intETA As Int64
            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "ETA")) Then

                objItem = DataBinder.Eval(e.Item.DataItem, "ETA")
                intETA = Convert.ToInt64(objItem)
            Else
                intETA = 0
            End If
            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "eta_time")) Then
                objItem = DataBinder.Eval(e.Item.DataItem, "eta_time")
                Dim strETATime As String
                strETATime = Convert.ToString(objItem)

                If strETATime <> "" Then

                    If IsNumeric(intETA) = True Then
                        If CLng(intETA) > 0 Then
                            CType(e.Item.FindControl("lblETA"), Label).Text = intETA & " min."
                        Else
                            CType(e.Item.FindControl("lblETA"), Label).Text = "0 min."
                        End If
                    Else
                        CType(e.Item.FindControl("lblETA"), Label).Text = "N/A"
                    End If
                Else

                End If

            Else

            End If

            '--PuAddress
            Dim strTemp As String

            strTemp = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_landmark")).Trim()
            If strTemp = "" Then

                strTemp = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_st_no")) & " "
                strTemp = strTemp & Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_st_name")) & " "
                strTemp = strTemp & Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_city")) & " "
                strTemp = strTemp & Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_county")) & " "
                strTemp = strTemp & Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_zip")) & " "
                strTemp = strTemp & Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_landmark")) & " "

                strTemp = Security.SentenceCase(strTemp)

            End If

            CType(e.Item.FindControl("lblPuAddress"), Label).Text = strTemp

            '--DestAddress
            strTemp = ""
            strTemp = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_landmark")).Trim()
            If strTemp = "" Then

                strTemp = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_st_no")) & " "
                strTemp = strTemp & Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_st_name")) & " "
                strTemp = strTemp & Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_city")) & " "
                strTemp = strTemp & Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_county")) & " "
                strTemp = strTemp & Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_zip")) & " "
                strTemp = strTemp & Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_landmark")) & " "

                strTemp = Security.SentenceCase(strTemp)

            End If

            CType(e.Item.FindControl("lblDestAddress"), Label).Text = strTemp

            '--travel time
            objItem = DataBinder.Eval(e.Item.DataItem, "display_date_time")
            If Not objItem Is Nothing AndAlso IsDate(objItem) Then
                Dim dt As DateTime = Convert.ToDateTime(objItem)
                CType(e.Item.FindControl("lblReq_date_time"), Label).Text = dt.ToString("MM/dd/yyyy") & "<br>" & dt.ToString("hh:mm:ss tt") 'dt.ToShortDateString & "<br>" & dt.Hour.ToString & ":" & dt.Minute.ToString & ":" & dt.Second.ToString
            Else
                CType(e.Item.FindControl("lblReq_date_time"), Label).Text = "n/a"
            End If

            Dim btn As LinkButton = CType(e.Item.FindControl("lbCancel"), LinkButton)
            btn.Attributes.Add("onclick", "return confirm('Are you sure you want to cancel the order?')")
        End If

    End Sub

    Protected Sub dgRides_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgRides.PageIndexChanged
        Me.ddlPage.SelectedIndex = e.NewPageIndex
        Me.m_RideDataSet.Tables(0).DefaultView.Sort = Convert.ToString(Session("sort"))
        Me.dgRides.CurrentPageIndex = e.NewPageIndex
        Me.dgRides.DataBind()

    End Sub

    Protected Sub dgRides_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgRides.SelectedIndexChanged
        Me.m_RideDataSet.Tables(0).DefaultView.Sort = Convert.ToString(Session("sort"))
        Me.dgRides.CurrentPageIndex = Me.ddlPage.SelectedIndex
        Me.dgRides.DataBind()

    End Sub

    Protected Sub ddlPage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPage.SelectedIndexChanged
        Me.m_RideDataSet.Tables(0).DefaultView.Sort = Convert.ToString(Session("sort"))
        Me.dgRides.CurrentPageIndex = Me.ddlPage.SelectedIndex
        Me.dgRides.DataBind()
    End Sub

    Protected Sub dgRides_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgRides.SortCommand
        Me.ViewState("sort") = e.SortExpression
    End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click

    End Sub

#End Region

#Region "Private Function User Parts"

    Public Sub BindRideData()
        If Not Me.m_RideDataSet Is Nothing AndAlso Me.m_RideDataSet.Tables.Count > 0 Then
            'Me.lblCountRide.Text = Me.m_RideDataSet.Tables(0).Rows.Count
            If Not Me.ViewState("sort") Is Nothing Then
                If Me.ViewState("sort").ToString.Length > 0 Then
                    Me.m_RideDataSet.Tables(0).DefaultView.Sort = Me.ViewState("sort")
                End If
            End If
            Me.dgRides.DataSource = Me.m_RideDataSet.Tables(0).DefaultView
            '## add by joey 3/13/2008
            If Me.dgRides.CurrentPageIndex + 1 > Math.Ceiling(Me.m_RideDataSet.Tables(0).Rows.Count / Me.dgRides.PageSize) Then
                Me.dgRides.CurrentPageIndex = 0
            End If
            Me.dgRides.DataBind()
            Me.lblCountRide.Text = Me.m_RideDataSet.Tables(0).Rows.Count.ToString
            Me.BindGridPageToDrop()
            Me.btnExcel.Enabled = True
        Else
            Me.btnExcel.Enabled = False
        End If

    End Sub

    Private Function ConvertDateTimeTOString(ByVal value As Object) As String
        If IsDBNull(value) Then
            Return "N/A"
        Else
            Return Convert.ToString(Convert.ToDateTime(value)).Trim
        End If
    End Function

    Private Sub BindGridPageToDrop()

        Me.ddlPage.Items.Clear()
        For i As Integer = 1 To Me.dgRides.PageCount
            Me.ddlPage.Items.Add(i & "/" & Me.dgRides.PageCount)
        Next

    End Sub

    Private Function Check_DBNULL(ByVal Value As Object) As String

        If IsDBNull(Value) = True Then
            Return Nothing
        Else
            Return Convert.ToString(Value).Trim()
        End If

    End Function

#End Region

End Class
