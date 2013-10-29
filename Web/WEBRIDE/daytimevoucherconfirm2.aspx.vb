Imports Business

Partial Class daytimevoucherconfirm2
    Inherits System.Web.UI.Page

    Public strConfirmNo As String
    Public type As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Dim strRevive, strMsg, strReturnTrip As String

        strConfirmNo = Trim(CStr(Request.QueryString("cno")))
        strRevive = Trim(CStr(Request.QueryString("revive")))
        strMsg = Trim(Request.QueryString("msg"))
        strReturnTrip = Trim(Request.QueryString("rt"))

        Me.hidconf.Value = strConfirmNo
        If Not Page.IsPostBack Then
            If strConfirmNo <> "" Then
                Call Load_default(strConfirmNo)
            End If
        End If
    End Sub

    '------------------------------------------------------------------------------
    '--Function:Load_default
    '--Description:Load all infos
    '--Input:Conf_No
    '--Output:
    '--11/4/04 - Created (eJay)
    '------------------------------------------------------------------------------
    Private Sub Load_default(ByVal Conf_No As String)

        Dim objOperatorData As OperatorData
        Dim objOperator As New Operators

        If Not Session("acct_id") Is Nothing Then

            objOperatorData = objOperator.FillRides(Conf_No)

            With objOperatorData

                Me.lblconfirmno.Text = Right(.confirmation_no, 4)
                Me.TDate.Text = Convert.ToString(.req_date_time) & " " & Convert.ToString(.Req_hour) & ":" & Convert.ToString(.Req_min) & Convert.ToString(.Req_ampm)
                Me.PName.Text = .lname.ToString & "," & .fname.ToString
                Me.Phone.Text = .pu_phone & " Ext." & .pu_phone_ext
                Me.Email.Text = .email_add
                Try
                    Me.payment_type.Text = .payment_type
                Catch ex As Exception
                    Me.payment_type.Text = ""
                End Try

                Me.Car_Type.Text = .Car_type_Desc '.Car_type    --changed by eJay 10/3/2006
                Me.lblCarNo.Text = .car_no

                Me.lblStops.Text = objOperator.Check_stops(Conf_No)
                Me.EPrice.Text = FormatCurrency(.price_est)

                Me.rptComp.DataSource = objOperator.Create_compid(Convert.ToString(Session("acct_id")), Convert.ToString(Session("sub_acct_id")), Convert.ToString(Session("company")), Conf_No)

                If .eta_time Is Nothing Or .eta_time = "" Then
                    If .status_flag <> "K" And .status_flag <> "F" Then
                        Me.lblETA.Text = "N/A. Please check again."
                    Else
                        Me.lblETA.Text = "N/A"
                    End If
                Else
                    Me.lblETA.Text = .eta_time
                End If

                Dim strTemp As String
                Dim objRides As New Rides
                If objRides.isairport(.dest_county) = False And objRides.isairport(.pu_county) = False Then
                    strTemp = "0"
                    'Me.txtcheckpu.Text = "0" : Me.txtcheckdest.Text = "0"
                ElseIf objRides.isairport(.pu_county) And objRides.isairport(.dest_county) = False Then
                    strTemp = "1"
                    'Me.txtcheckpu.Text = "1" : Me.txtcheckdest.Text = "0"
                ElseIf objRides.isairport(.pu_county) = False And objRides.isairport(.dest_county) Then
                    strTemp = "2"
                    'Me.txtcheckpu.Text = "0" : Me.txtcheckdest.Text = "1"
                Else
                    strTemp = "3"
                End If
                Me.txtShowType.Text = strTemp.ToString

                Select Case strTemp
                    Case "0"
                        Me.ClientScript.RegisterStartupScript(GetType(String), "changcheck", "<script language=javascript>show_confirmpage('0');</script>")
                    Case "1"
                        Me.ClientScript.RegisterStartupScript(GetType(String), "changcheck", "<script language=javascript>show_confirmpage('1');</script>")
                    Case "2"
                        Me.ClientScript.RegisterStartupScript(GetType(String), "changcheck", "<script language=javascript>show_confirmpage('2');</script>")
                    Case "3"
                        Me.ClientScript.RegisterStartupScript(GetType(String), "changcheck", "<script language=javascript>show_confirmpage('3');</script>")
                End Select

                '========================================================================================================
                '--Pickup
                If Msg.IsBoro(.pu_county, True) Then
                    Me.lblState.Text = Msg.GetBoroFullName(.pu_county)
                Else
                    Me.lblState.Text = .pu_county
                End If

                Me.lblCity.Text = .pu_city
                Me.lblStNo.Text = .pu_st_no
                Me.lblStName.Text = .pu_st_name
                Me.lblZipCode.Text = .pu_zip
                Me.lblPuPoint.Text = .pu_point
                Me.lblPuDirections.Text = .pu_direction

                Me.lblPairport.Text = .pu_county
                Me.lblPAirName.Text = .airport_airline
                Me.lblPAirFli.Text = .airport_flight
                Me.lblAirPu.Text = .airport_pu_point
                Me.lblPCity.Text = .airport_terminal
                Me.lblPassDestPhone.Text = .airport_from
                Me.lblPuAirDirections.Text = .pu_direction

                '--Destination
                If Msg.IsBoro(.dest_county, True) Then
                    Me.lblDState.Text = Msg.GetBoroFullName(.dest_county)
                Else
                    Me.lblDState.Text = .dest_county
                End If

                Me.lblDCity.Text = .dest_city
                Me.lblDStNo.Text = .dest_st_no
                Me.lblDStName.Text = .dest_st_name
                Me.lblDZipCode.Text = .dest_zip
                Me.lblDStX.Text = .dest_x_st
                Me.lblDDirections.Text = .dest_direction

                Me.lblDairport.Text = .dest_county
                Me.lblDairname.Text = .dest_airport_airline
                Me.lblDairFli.Text = .dest_airport_flight
                Me.lblAirDest.Text = .dest_airport_point
                Me.lblDestCity.Text = .dest_airport_terminal
                Me.lblPassDestPhone.Text = .dest_phone
                Me.lblDestAirDirections.Text = .dest_direction

            End With

            objOperatorData = Nothing

            objOperator.Dispose()
            objOperator = Nothing

        End If

    End Sub

End Class
