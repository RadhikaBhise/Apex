Imports Business
Imports System.Data

Partial Class Modules_corp_ridehistory
    Inherits System.Web.UI.UserControl

    Public Event RideRefresh_Click()

#Region "Protected Sub Page Events"

    Protected Sub dgRides_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgRides.ItemCommand
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

    Protected Sub dgRides_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgRides.ItemCreated
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim objFlag As Object = DataBinder.Eval(e.Item.DataItem, "Status_flag")
            If Not objFlag Is Nothing Then
                Dim strFlag As String = Convert.ToString(objFlag)
                If strFlag.ToUpper = "F" Then
                    e.Item.ForeColor = Drawing.Color.Blue
                Else
                    e.Item.ForeColor = Drawing.Color.Black
                End If
            End If
        End If
    End Sub

    Protected Sub dgRides_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgRides.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim objItem As Object

            '--confirmation_no
            Dim strconfirmaton_no As String
            Dim objConfirmation As Object
            objConfirmation = DataBinder.Eval(e.Item.DataItem, "confirmation_no")

            strconfirmaton_no = Right(Convert.ToString(objConfirmation).Trim(), 4)

            CType(e.Item.FindControl("hy1"), HyperLink).Text = Right(strconfirmaton_no, 4)
            CType(e.Item.FindControl("hy1"), HyperLink).NavigateUrl = "corp_detail.aspx?cid=" & objConfirmation & "&revive=ridehist"

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
                    Dim strconf_new As String
                    strconf_new = DataBinder.Eval(e.Item.DataItem, "confirmation_no").ToString
                    If (strStatus = "H" Or strStatus = "K") And is_voucher(strconf_new) = True Then
                        CType(e.Item.FindControl("hylkprint"), HyperLink).Text = "Print Receipt"
                        CType(e.Item.FindControl("hylkprint"), HyperLink).NavigateUrl = "receipt2.aspx?cno=" & strconf_new
                        CType(e.Item.FindControl("hylkprint"), HyperLink).Target = "_blank"
                    End If
                Case Else
                    CType(e.Item.FindControl("lblStatus"), Label).Text = ""
                    Dim strconf_new As String
                    strconf_new = DataBinder.Eval(e.Item.DataItem, "confirmation_no").ToString
                    If (strStatus = "H" Or strStatus = "K") And is_voucher(strconf_new) = True Then
                        CType(e.Item.FindControl("hylkprint"), HyperLink).Text = "Print Receipt"
                        CType(e.Item.FindControl("hylkprint"), HyperLink).NavigateUrl = "receipt2.aspx?cno=" & strconf_new
                        CType(e.Item.FindControl("hylkprint"), HyperLink).Target = "_blank"
                    End If

            End Select

            '-- set passenger name
            CType(e.Item.FindControl("lblName"), Label).Text = DataBinder.Eval(e.Item.DataItem, "lname").ToString.Trim & " , " & DataBinder.Eval(e.Item.DataItem, "fname").ToString.Trim

            '--Links
            objItem = DataBinder.Eval(e.Item.DataItem, "car_no")
            Dim strCarNo As String
            strCarNo = Convert.ToString(objItem).Trim()
            ' objItem = DataBinder.Eval(e.Item.DataItem, "pu_date_time")
            objItem = DataBinder.Eval(e.Item.DataItem, "display_date_time")
            Dim dtPu As DateTime
            dtPu = Convert.ToDateTime(objItem)
            Dim intTemp As Int64
            intTemp = DateDiff("n", Now, dtPu)

            If (strStatus = "L" Or strStatus = "R") And strCarNo = "" And intTemp > 720 Then

                CType(e.Item.FindControl("img1"), Image).Visible = True
                CType(e.Item.FindControl("lbCancel"), LinkButton).Visible = True
                CType(e.Item.FindControl("lbCancel"), LinkButton).CssClass = DataBinder.Eval(e.Item.DataItem, "confirmation_no").ToString.Trim()
                'CType(e.Item.FindControl("lbCancel"), LinkButton).Attributes.Add("onmouseover", "<script javascript>self.status = 'Click Here to Look Up Borough Street Name!'; return true</script>")

                CType(e.Item.FindControl("img2"), Image).Visible = True
                CType(e.Item.FindControl("hyModify"), HyperLink).Visible = True
                Dim strNEW As String

                strNEW = DataBinder.Eval(e.Item.DataItem, "confirmation_no").ToString
                CType(e.Item.FindControl("hyModify"), HyperLink).NavigateUrl = "corp_orderform1.aspx?cno=" & strNEW

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
            btn.Attributes.Add("onclick", "return confirm('Sure to cancel the order?')")

        End If
    End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        'Call Me.BindGrid_Excel()
        'Me.dgExcel.AllowPaging = False
        'Me.dgExcel.DataBind()
        'Call GenerateFileTemplate(Me, Me.dgExcel, "Corp Search.csv")
    End Sub

    Private Sub BindGrid_Excel()
        'Dim objRide As New Orders
        'Dim strFromDate As String = Me.txtFDate.Text.Trim
        'Dim strToDate As String = Me.txtTDate.Text.Trim
        'Dim strFname As String = Me.txtFName.Text.Trim
        'Dim strLname As String = Me.txtLName.Text.Trim
        'Dim strComp_req As String = Me.ddlComp_req.SelectedValue.Trim
        'Dim strComp_req_value As String = Me.txtComp_req_value.Text.Trim

        'Dim bol_Corp As Boolean = validate_CorpPw(ViewState("strPw"))

        'Try
        '    If bol_Corp = True Then
        '        Me.grdDV_Excel = objRide.Corp_GetOperatorRidesQuery(Convert.ToString(Session("acct_id")), Convert.ToString(Session("sub_acct_id")), strFromDate, strToDate, strFname, strLname, strComp_req, strComp_req_value, "true").Tables(0).DefaultView
        '    Else
        '        Me.grdDV_Excel = objRide.Corp_GetOperatorRidesQuery(Convert.ToString(Session("acct_id")), Convert.ToString(Session("sub_acct_id")), strFromDate, strToDate, strFname, strLname, strComp_req, strComp_req_value, "false").Tables(0).DefaultView
        '    End If
        '    If grdDV_Excel.Table.Rows.Count > 0 Then

        '        Me.dgExcel.DataSource = Me.grdDV_Excel
        '        Me.dgExcel.DataBind()

        '        objRide.Dispose()
        '        objRide = Nothing

        '    Else
        '        RegisterStartupScript("PopUpMessage", "<script language=""javascript"">alert('Nothing found. Please try again');</script>")
        '        Me.grdDV = Nothing
        '        Me.dgExcel.DataSource = Me.grdDV_Excel
        '        Me.dgExcel.DataBind()

        '        objRide.Dispose()
        '        objRide = Nothing

        '    End If

        'Catch ex As Exception
        '    Me.grdDV_Excel = Nothing
        'End Try

        'If Not Me.grdDV_Excel Is Nothing Then
        '    Me.dgExcel.DataSource = Me.grdDV_Excel
        '    Me.dgExcel.DataBind()
        'End If

    End Sub

#End Region

#Region "Private Sub & Function Events"

    Public Function is_voucher(ByVal confirm_no As String) As Boolean
        Dim objUsers As New Users
        Dim objBoolean As Boolean = False
        objBoolean = objUsers.is_voucher(confirm_no)

        Return objBoolean

    End Function

#End Region

End Class
