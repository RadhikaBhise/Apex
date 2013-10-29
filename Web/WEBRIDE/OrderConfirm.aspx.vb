Imports Business
Imports System.Data
Imports Business.Common

Partial Class webride_OrderConfirm
    Inherits System.Web.UI.Page

    'Protected WithEvents bodyForm As System.Web.UI.HtmlControls.HtmlGenericControl

#Region "Protected Sub"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        If Not Page.Request.QueryString("f") Is Nothing Then
            Me.hdnFrom.Value = Request.QueryString("f").Trim
        End If

        Me.btnBack.Attributes.Add("onclick", "javascript:document.getElementById('" & Me.trButton.ClientID & "').style.visibility='hidden';")

        'Dim objoperatordata As OperatorData = MySession.OperatorOrder
        If Not Page.IsPostBack Then

            '## 1/24/2008   Add Verify Credit Card  (Joey)
            'If MySession.OperatorOrder.confirmation_no.Length > 0 Then
            '    Dim data As New OperatorData
            '    Using obj As New Operators
            '        data = obj.FillRides(MySession.OperatorOrder.confirmation_no)
            '        If data.CC_Type_Default = MySession.OperatorOrder.CC_Type_Default And data.card_exp_date = MySession.OperatorOrder.card_exp_date And data.card_no = MySession.OperatorOrder.card_no Then
            '            'do nothing
            '        Else
            '            Pricing.RegisterValidateCCScript(Me, Me.Submit, Me.trButton, Me.SubmitHide, 1)
            '        End If
            '    End Using
            'Else
            Pricing.RegisterValidateCCScript(Me, Me.Submit, Me.trButton, Me.SubmitHide, 1)
            'End If

            '##added by joey    1/30/2008
            Dim objoperatordata As OperatorData
            objoperatordata = CType(Session.Item("Operator"), OperatorData)
            If objoperatordata.confirmation_no.Length > 0 Then
                Me.Submit.ImageUrl = "images/UpdateOrder.gif"
            Else
                Me.Submit.ImageUrl = "images/place order.gif"
            End If

            'Dim pagetype As Int16
            'pagetype = Convert.ToInt16(Request.QueryString("pagetype"))
            Dim stop1 As String
            Dim stop2 As String
            Dim stop3 As String
            stop1 = Convert.ToString(Session("stop_1"))
            stop2 = Convert.ToString(Session("stop_2"))
            stop3 = Convert.ToString(Session("stop_3"))

            'Session("pagetype") = pagetype
            LoadInfo()
            'Call getEstimationPrice()
            If Not Session("agent_id") Is Nothing Then
                ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage3", "<script language='javascript'>document.getElementById('APhone').style.display='';document.getElementById('AEmail').style.display='';</script>")
            End If
        Else
            'If Not Session("agent_id") Is Nothing Then
            '    ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage3", "<script language='javascript'>document.getElementById('APhone').style.display='';document.getElementById('AEmail').style.display='';</script>")
            'End If
            'LoadInfo()
        End If
    End Sub

    Protected Sub Submit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Submit.Click
        OperatorInfo()
        'CleanOperInfo_byPagetype() '## 12/6/2007   disabled by yang
        Get_Airline_Code()
        insertOperatorInfo()
    End Sub

    '## 1/25/2008   (yang)
    Protected Sub SubmitHide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubmitHide.Click
        Me.Submit_Click(Nothing, Nothing)
    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBack.Click
        If Session("agent_id") Is Nothing Then
            If Me.hdnFrom.Value = "order" Then
                Response.Redirect("order.aspx")
            ElseIf Me.hdnFrom.Value = "corporate" Then
                Response.Redirect("corp_orderform.aspx")
            ElseIf Me.hdnFrom.Value = "group" Then
                Response.Redirect("group_orderform.aspx")
            Else
                Response.Redirect("order.aspx?event=isback")
            End If
        Else
            Response.Redirect("agent_order_1.aspx")
        End If
    End Sub

#End Region

#Region "Private Sub"
    'Private Sub getEstimationPrice()
    '    Dim objoperatordata As OperatorData
    '    objoperatordata = CType(Session.Item("Operator"), OperatorData)
    '    Dim strResult As String = ""

    '    Using objPrice As New Pricing
    '        '## 11/20/2007  Use PricingLimo.dll to calculate to price estimate  (yang)
    '        With objoperatordata
    '            strResult = objPrice.GetPriceEst(objoperatordata)
    '            .price_est = strResult.Trim
    '        End With
    '        'objoperatordata.price_est = objPrice.get_call_price_est(objoperatordata.confirmation_no, 0, 0, 0, 0, 0, _
    '        '            0, 0, 0, 0, 0, 0, _
    '        '            0, 0, 0, 0, 0, 0, 0, _
    '        '            0, 0)
    '    End Using

    '    'If Val(objoperatordata.price_est) > 0 Then
    '    '    Me.lblEstPrice.Text = "$" & objoperatordata.price_est
    '    'Else
    '    '    Me.lblEstPrice.Text = "N/A"
    '    'End If

    '    Session.Item("Operator") = objoperatordata
    'End Sub
    Private Sub LoadInfo()
        Dim objoperatordata As OperatorData
        objoperatordata = CType(Session.Item("Operator"), OperatorData)
        With objoperatordata
            'If Not Session("stop_1") Is Nothing Then
            '    .stops = "Y"
            'Else
            '    .stops = "N"
            'End If

            Me.lblReqDT.Text = Month(.req_date_time) & "/" & Day(.req_date_time) & "/" & Year(.req_date_time) & " " & .Req_hour & ":" & .Req_min & " " & .Req_ampm & " (RESERVATION)"


            Me.lblFullName.Text = objoperatordata.lname & ", " & objoperatordata.fname
            'If .vip_phone = "" Then
            '    Me.lblPhone.Text = ""
            'Else
            '    Me.lblPhone.Text = Left(.vip_phone, 3) & "-" & .vip_phone.Substring(3, 7) & " Ext." & .dest_phone_ext
            'End If
            If .pu_phone = "" Then
                Me.lblPhone.Text = ""
            Else
                Me.lblPhone.Text = Common.ShowPhoneNo(.pu_phone) '& " Ext." & .pu_phone_ext
            End If
            Me.lblEmail.Text = .email_add
            Me.lblAcct.Text = .account_no
            Me.lblConPhone.Text = .auth_telno
            If Not .auth_telno Is Nothing Then
                If Len(.auth_telno) = 10 Then
                    Me.lblConPhone.Text = Common.ShowPhoneNo(.auth_telno)

                Else
                    Me.lblConPhone.Text = ""
                End If
            End If

            '## 12/3/2007   yang
            If .payment_type_desc.Trim.Length > 0 Then
                Me.lblPayment.Text = .payment_type_desc.Trim
            Else
                Me.lblPayment.Text = Session("paytype")
            End If

            Try
                If Not .price_est Is Nothing Then
                    'Me.EPrice.Text = CStr(objEPrice)
                    Me.lblEstPrice.Text = ShowPrice(.price_est, PricePrefix.dollar)
                End If
            Catch ex As Exception
                Me.lblEstPrice.Text = "$ N/A"
            End Try
            'If Me.lblPayment.Text = "Cash" Then
            '    Dim strMessage As String
            '    strMessage = "<script language=""JavaScript"" type=""text/javascript"">"
            '    strMessage = strMessage & "{document.getElementById(""ctype"").style.display='none';}"
            '    strMessage = strMessage & "{document.getElementById(""cno"").style.display='none';}"
            '    strMessage = strMessage & "{document.getElementById(""cname"").style.display='none';}"
            '    strMessage = strMessage & "</script>"
            '    ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage2", strMessage)
            'End If

            '## 12/2/2007   yang
            If .Car_type_Desc.Trim.Length > 0 Then
                Me.lblCarType.Text = .Car_type_Desc.Trim
            Else
                Me.lblCarType.Text = Session("cartype")
            End If

            'Me.lblpax.Text = .pax_no
            'Me.lblStops.Text = .stops
            'Me.txtVoucherno.Text = Convert.ToString(Session("voucher_no"))
            'If .pu_landmark <> "--Please select a landmark--" Then
            '    Me.lblLandmark2.Text = .pu_landmark
            'End If
            '============Pickup=============================
            'If .isairport1 = "Y" Then
            Call Me.AriseJavaScript(.PuAir, .DestAir)
            'End If
            Me.lblState.Text = Convert.ToString(IIf(.pu_county_desc.Length > 0, .pu_county_desc, .pu_county)).Trim()
            '## 11/22/2007  added by yang
            '## add by joey 11/22/2007
            If Msg.IsBoro(.pu_county, False) Then
                Me.lblPuCity.Text = ""
            Else
                Me.lblPuCity.Text = .pu_city
            End If

            Me.lblPBlogNo.Text = .pu_st_no
            Me.lblPStName.Text = .pu_st_name
            'Me.lblAddress.Text = .pu_st_name
            Me.lblPuPoint.Text = .pu_point
            Me.lblPDirection.Text = .pu_direction  'added by lily 12/10/2007

            Me.lblPairport.Text = .airport_name
            Me.lblPAirName.Text = .airport_airline
            Me.lblPAirFli.Text = .airport_flight
            Me.lblAirPu.Text = .airport_pu_point
            'Me.lblPassPuPhone.Text = .pu_phone & .pu_phone_ext
            Me.lblPairfbo.Text = .airport_terminal
            Me.lblPairtime.Text = .airport_time
            Me.lblPuAirDepartingCity.Text = .airport_from
            Me.lblPAirDirection.Text = .pu_direction   'added by lily 12/10/2007
            '===============================================
            '==================Destination==================
            Me.lblDestState.Text = Convert.ToString(IIf(.dest_county_desc.Length > 0, .dest_county_desc, .dest_county)).Trim()    '## 11/22/2007  added by yang
            '## add by joey 11/22/2007
            If Msg.IsBoro(.dest_county, False) Then
                Me.lblDestCity.Text = ""
            Else
                Me.lblDestCity.Text = .dest_city
            End If

            Me.lblDestBlogno.Text = .dest_st_no
            Me.lblDStName.Text = .dest_st_name
            'Me.lblDestAddress.Text = .dest_st_name
            Me.lblDstrross.Text = .dest_x_st
            Me.lblDDirection.Text = .dest_direction  'added by lily 12/10/2007

            Me.lblDairport.Text = .dest_aiport_name
            Me.lblDairname.Text = .dest_airport_airline
            Me.lblDestAirFlight.Text = .dest_airport_flight
            Me.lblDAirFbo.Text = .dest_airport_terminal
            Me.lblDAirDirection.Text = .dest_direction  'added by lily 12/10/2007
            'Me.lblDairtime.Text = .dest_airport_departureTime
            ' Me.lblDestAirDepartingCity.Text = .dest_airport_from
            'If Not .direction Is Nothing Then
            '    Me.lblDirection.Text = .direction
            'Else
            '    Me.lblDirection.Text = ""
            'End If

            ' Me.lblDestAirPu.Text = .dest_airport_point
            'Me.lblDestPuPhone.Text = .Auth_Telno & .Auth_Telno_ext
            ' Me.lblDestAirDepartingCity.Text = .dest_airport_terminal
            '===============================================
            ''----Car Seat-------------------------
            'If .share = "Y" Then

            'objPrice.IsCarSeat = True
            'objPrice.CarSeatSize = .no_car_seat

            'End If
            'Dim nStopsCount As Integer = 0
            'If Not Session("stop_1") Is Nothing Then
            '    nStopsCount = nStopsCount + 1
            'End If
            'If Not Session("stop_2") Is Nothing Then
            '    nStopsCount = nStopsCount + 1
            'End If
            'If Not Session("stop_3") Is Nothing Then
            '    nStopsCount = nStopsCount + 1
            'End If
            'objPrice.StopsCount = nStopsCount
            'Call objPrice.Calculate()

            'Me.txtBaseRate.Text = objPrice.BaseRate.ToString
            'Me.txtStops.Text = objPrice.StopsPrice.ToString
            'Me.txtMg.Text = objPrice.MGPrice.ToString
            'Me.txtCarseat.Text = objPrice.CarSeatPrice.ToString
            '' Me.txtGra.Text = Convert.ToString(objPrice.BaseRate * Convert.ToSingle(Me.txtGraPer.Text) / 100)
            'Me.txtDis.Text = objPrice.DiscountPrice.ToString
            'Me.txtDisC.Text = objPrice.DiscountCertPrice.ToString
            'Me.txtExpen.Text = objPrice.ExpensePrice.ToString
            'Me.txtPark.Text = objPrice.ParkingPrice.ToString
            'Me.txtTicket.Text = objPrice.TicketPrice.ToString
            'Me.txtTolls.Text = objPrice.TollsPrice.ToString
            'Me.txtStc.Text = objPrice.STCPrice.ToString
            'Me.txtService.Text = objPrice.ServiceFee.ToString
            'Me.txtTicket.Text = objPrice.TicketPrice.ToString
            'Me.txtWtchar.Text = objPrice.WTPrice.ToString
            'Me.txtAmhol.Text = objPrice.OTPrice.ToString
            'Me.txtTotal.Text = objPrice.TotalPrice.ToString

            'Me.txtGraPer.Text = Convert.ToString(Session("tips_perc"))
            'Me.txtDisCPer.Text = Convert.ToString(Session("discount_cert_perc"))

            'Added by Johnson
            'Show Company Requirments

            Dim arrComID(6) As String
            arrComID(0) = Trim(.Comp_id_1)
            arrComID(1) = Trim(.Comp_id_2)
            arrComID(2) = Trim(.Comp_id_3)
            arrComID(3) = Trim(.Comp_id_4)
            arrComID(4) = Trim(.Comp_id_5)
            arrComID(5) = Trim(.Comp_id_6)

            Dim objcom As New Operators
            Dim tabcom As New DataTable
            Dim i As Byte
            tabcom = objcom.GetCompanyQue(CStr(Session("acct_id")), CStr(Session("sub_acct_id")), CStr(Session("company")))
            objcom = Nothing
            
            If Not tabcom Is Nothing And tabcom.Rows.Count > 0 Then
                lit_ComReq.Text = ""

                For i = 0 To CByte(tabcom.Rows.Count - 1)
                    '## added by joey   2/1/2008
                    Dim display As Int16 = Convert.ToInt16(tabcom.Rows(i).Item("display"))
                    If Not display = 2 And Not display = 0 Then
                        lit_ComReq.Text = lit_ComReq.Text & _
                                          "<TR>" & vbCrLf & _
                                          "    <TD class=""css_desc"" style=""HEIGHT: 18px"" align='left'><b>" & Security.SentenceCase(Trim(tabcom.Rows(i).Item("req_desc").ToString)) & "</b></TD>" & vbCrLf & _
                                          "    <TD class=""font2"" width=""185"" style=""HEIGHT: 18px"" align='left'><span id=""lbl_Comp_id_" & i & """ style=""width:100%;"">" & arrComID(i) & "</span></TD>" & vbCrLf & _
                                          "</TR>" & vbCrLf
                    End If
                Next
            End If

            tabcom = Nothing

        End With

        'If Not Session("stop_1") Is Nothing Then
        '    Me.lblstop1.Text = Replace(Session("stop_1").ToString, "|", " ")
        'End If
        'If Not Session("stop_2") Is Nothing Then
        '    Me.lblstop2.Text = Replace(Session("stop_2").ToString, "|", " ")
        'End If
        'If Not Session("stop_3") Is Nothing Then
        '    Me.lblstop3.Text = Replace(Session("stop_3").ToString, "|", " ")
        'End If



    End Sub


    Private Sub OperatorInfo()
        Dim objoperatordata As OperatorData
        objoperatordata = CType(Session.Item("Operator"), OperatorData)
        With objoperatordata
            Dim tmpoper2 As New Operators
            Dim ds2 As DataSet
            ds2 = tmpoper2.Get_Account_comp_req(Convert.ToString(Session("acct_id")), Convert.ToString(Session("sub_acct_id")))
            'tmpoper2.Dispose()
            tmpoper2 = Nothing


            Dim tmpoper3 As New Operators
            Dim ds3 As DataSet
            ds3 = tmpoper3.Get_Vip_Vip_text(Convert.ToString(Session("user_id")), Convert.ToString(Session("acct_id")), Convert.ToString(Session("sub_acct_id")))
            ds2.Dispose()
            ds3 = Nothing


            .account_no = Convert.ToString(Session("acct_id"))
            .status_flag = "R"
            '.req_date_time = Convert.ToDateTime(Me.lblReqDT.Text)

            .priority = Convert.ToString(Session("priority"))
            '## 3/20/2008   Default to "A" if priority is nothing   (yang)
            'If .priority Is Nothing OrElse .priority.Trim.Length = 0 Then
            '    .priority = "A"
            'End If

            .company = Convert.ToString(Session("company"))
            .original_company = Convert.ToString(Session("company"))
            '.confirmation_no = confirm_id
            '.voucher_no = Me.txtVoucherno.Text.Trim

            '.Comp_id_1 = IIf(Not Session("Comp_id_1") Is Nothing, Session("Comp_id_1").ToString, "")
            '.Comp_id_2 = IIf(Not Session("Comp_id_2") Is Nothing, Session("Comp_id_2").ToString, "")
            '.Comp_id_3 = IIf(Not Session("Comp_id_3") Is Nothing, Session("Comp_id_3").ToString, "")
            '.Comp_id_4 = IIf(Not Session("Comp_id_4") Is Nothing, Session("Comp_id_4").ToString, "")
            '.Comp_id_5 = IIf(Not Session("Comp_id_5") Is Nothing, Session("Comp_id_5").ToString, "")
            '.Comp_id_6 = IIf(Not Session("Comp_id_6") Is Nothing, Session("Comp_id_6").ToString, "")
            .comp_req_1 = Convert.ToString(ds2.Tables(0).Rows(0).Item(0))
            .comp_req_2 = Convert.ToString(ds2.Tables(0).Rows(0).Item(1))
            .comp_req_3 = Convert.ToString(ds2.Tables(0).Rows(0).Item(2))
            .comp_req_4 = Convert.ToString(ds2.Tables(0).Rows(0).Item(3))
            .comp_req_5 = Convert.ToString(ds2.Tables(0).Rows(0).Item(4))
            .comp_req_6 = Convert.ToString(ds2.Tables(0).Rows(0).Item(5))

            .sub_account_no = Convert.ToString(Session("sub_acct_id"))

            If Me.hdnFrom.Value <> "corporate" Then '## 12/4/2007   yang
                .vip_no = MySession.UserID
            End If

            '.payment_type = Me.lblPayment.Text.Trim
            '.card_type = Me.lblCardType.Text.Trim
            '.card_no = Trim(Me.lblCardNo.Text)
            '.card_exp_date = Convert.ToString(Me.ddlCCMonth.SelectedValue & Me.ddlCCYear.SelectedValue)
            If Len(.card_exp_date) = 3 Then
                .card_exp_date = "0" & .card_exp_date
            End If
            '.card_name = Trim(Me.lblCardName.Text)
            .stops = "N"

            check_pu_date_time()

            '--add by eJay 11/23/04 for stops!========================================
            'Dim strStops As String()
            '.isairport1 = ""
            '.isairport2 = ""
            '.isairport3 = ""
            ''--stops1
            'If Not Session("stop_1") Is Nothing Then
            '    strStops = Session("stop_1").ToString.Split(Char.Parse(Me.PIPE))

            '    If Not Session("IsAirport1") Is Nothing And Session("IsAirport1").ToString = "Y" Then

            '        .isairport1 = "Y"
            '        .city_airline_1 = strStops(0)
            '        .state_airport_1 = strStops(1)

            '    ElseIf Not Session("IsAirport1") Is Nothing And Session("IsAirport1").ToString = "N" Then

            '        .isairport1 = "N"
            '        .st_no_flight_1 = strStops(0).Trim()
            '        .st_name_airp_from_1 = strStops(1).Trim()
            '        .city_airline_1 = strStops(2).Trim()
            '        .state_airport_1 = strStops(3).Trim()
            '        .county_1 = strStops(3).Trim()
            '        .x_street_airp_dest_1 = strStops(4).Trim()
            '        .landmark_terminal_1 = strStops(5).Trim()
            '        .zip_1 = strStops(6).Trim()

            '    End If
            'End If

            ''--stops2
            'If Not Session("stop_2") Is Nothing Then
            '    strStops = Session("stop_2").ToString.Split(Char.Parse(Me.PIPE))

            '    If Not Session("IsAirport2") Is Nothing And Session("IsAirport2").ToString = "Y" Then

            '        .isairport2 = "Y"
            '        .city_airline_2 = strStops(0)
            '        .state_airport_2 = strStops(1)

            '    ElseIf Not Session("IsAirport2") Is Nothing And Session("IsAirport2").ToString = "N" Then

            '        .isairport2 = "N"
            '        .st_no_flight_2 = strStops(0).Trim()
            '        .st_name_airp_from_2 = strStops(1).Trim()
            '        .city_airline_2 = strStops(2).Trim()
            '        .state_airport_2 = strStops(3).Trim()
            '        .county_2 = strStops(3).Trim()
            '        .x_street_airp_dest_2 = strStops(4).Trim()
            '        .landmark_terminal_2 = strStops(5).Trim()
            '        .zip_2 = strStops(6).Trim()

            '    End If
            'End If

            ''--stops3
            'If Not Session("stop_3") Is Nothing Then
            '    strStops = Session("stop_3").ToString.Split(Char.Parse(Me.PIPE))

            '    If Not Session("IsAirport3") Is Nothing And Session("IsAirport3").ToString = "Y" Then

            '        .isairport3 = "Y"
            '        .city_airline_3 = strStops(0)
            '        .state_airport_3 = strStops(1)

            '    ElseIf Not Session("IsAirport3") Is Nothing And Session("IsAirport3").ToString = "N" Then

            '        .isairport3 = "N"
            '        .st_no_flight_3 = strStops(0).Trim()
            '        .st_name_airp_from_3 = strStops(1).Trim()
            '        .city_airline_3 = strStops(2).Trim()
            '        .state_airport_3 = strStops(3).Trim()
            '        .county_3 = strStops(3).Trim()
            '        .x_street_airp_dest_3 = strStops(4).Trim()
            '        .landmark_terminal_3 = strStops(5).Trim()
            '        .zip_3 = strStops(6).Trim()

            '    End If
            'End If

            '=========================================================================

            '--add by eJay 12/15/04 ==================================================

            '.Base_rate = Convert.ToDecimal(Me.txtBaseRate.Text.Trim())
            '.tolls_charges = Convert.ToDecimal(Me.txtTolls.Text.Trim())
            '.price_est1 = Convert.ToDecimal(Me.txtTotal.Text.Trim())
            '.tips_charges = Convert.ToDecimal(Me.txtGra.Text.Trim())
            '.tips_perc = Convert.ToDecimal(Me.txtGraPer.Text.Trim())
            '.parking_charges = Convert.ToDecimal(Me.txtPark.Text.Trim())
            '.stops_charges = Convert.ToDecimal(Me.txtStops.Text.Trim())
            '.WT_charges = Convert.ToDecimal(Me.txtWtchar.Text.Trim())
            ''phone fees
            '.service_fee = Convert.ToDecimal(Me.txtService.Text.Trim())
            '.M_G_charges = Convert.ToDecimal(Me.txtMg.Text.Trim())
            ''package charges
            '.OT_charges = Convert.ToDecimal(Me.txtAmhol.Text.Trim())
            '.STC_charges = Convert.ToDecimal(Me.txtStc.Text.Trim())
            '.expenses = Convert.ToDecimal(Me.txtExpen.Text.Trim())
            '.discount_cert = Convert.ToDecimal(Me.txtDisC.Text.Trim())
            '.discount_cert_perc = Convert.ToDecimal(Me.txtDisCPer.Text.Trim)
            '.discount = Convert.ToDecimal(Me.txtDis.Text.Trim())
            '.deposit = Convert.ToDecimal(Me.txtDeposit.Text.Trim())
            '.ticket_charges = Convert.ToDecimal(Me.txtTicket.Text.Trim())
            '.car_seat_charges = Convert.ToDecimal(Me.txtCarseat.Text.Trim())

            '=========================================================================

        End With


    End Sub


    Private Sub insertOperatorInfo()
        'the insert operatorinfo
        Dim MissingConfNoFailedScript As String = "alert('Failed to update, please try again.');window.location='order.aspx?cno=';"

        If Session.Item("Operator") Is Nothing Then
            Exit Sub
        End If

        Dim objoperatordata As OperatorData
        objoperatordata = CType(Session.Item("Operator"), OperatorData)

        With objoperatordata
            'If Session("cno") Is Nothing Or (Not Session("cno") Is Nothing And Not Session("rcno") Is Nothing) Then
            If objoperatordata.confirmation_no Is Nothing OrElse objoperatordata.confirmation_no.Trim.Length = 0 Then
                '## 11/26/2007  changed by yang

                'If blnResult = True Then'
                '----get the confirmationg_no==================================  
                Dim tmpoper As New Operators
                Dim ds As DataSet
                ds = tmpoper.getconfirmno()
                Dim confirmno As String
                confirmno = Convert.ToString(ds.Tables(0).Rows(0).Item(0))
                'tmpoper.Dispose()
                tmpoper = Nothing


                Dim i As Int16
                Dim confirm_id As String
                confirm_id = Right(Convert.ToString(Year(Now())), 2)
                For i = 1 To Convert.ToInt16(8 - Len(confirmno))
                    confirm_id = confirm_id & "0"
                Next
                .confirmation_no = confirm_id & confirmno
                If .PuAir = "Y" Then
                    .pu_county = .airport_name
                    .pu_city = ""
                Else
                    .airport_name = ""
                    .airport_airline = ""
                End If
                If .DestAir = "Y" Then
                    .dest_county = .dest_aiport_name
                    .dest_city = ""
                Else
                    .dest_aiport_name = ""
                    .dest_airport_airline = ""
                End If

                '=========================================================================
                'check the mode save or change
                'Session("cno") = .confirmation_no
                '---------------------------
                Dim oper As New Operators
                Dim intresult As Int16 = 0

                '## 2/13/2008   Check Auth No & Refer ID for Credit Card Order  (yang)
                Dim errMsg As String = ""
                If Pricing.ValidateCreditCardOrder(objoperatordata, errMsg) Then
                    intresult = oper.Insert_Operator_Info(objoperatordata, MySession.AcctID, "", "")  'added vip_no by lily 01/27/2008
                Else
                    If errMsg Is Nothing OrElse errMsg.Trim.Length = 0 Then
                        errMsg = "Credit Card is invalid."
                    End If

                    Page.ClientScript.RegisterStartupScript(GetType(String), "validate", String.Format("<script type='text/javascript'>alert('{0}');</script>", errMsg))
                End If

                If intresult = 1 Then
                    ''## 3/28/2008   Check Conf # exists in the table    (yang)
                    'Dim ord As OperatorData = oper.FillRides(objoperatordata.confirmation_no)

                    'If Not ord Is Nothing AndAlso ord.confirmation_no.Trim.Length > 0 AndAlso ord.vip_no.Trim.Length > 0 Then
                    send_mail()
                    Response.Redirect("Orderconfirmno.aspx?f=" & Me.hdnFrom.Value)
                    'Else
                    '    Page.ClientScript.RegisterStartupScript(GetType(String), "Update", MissingConfNoFailedScript, True)
                    'End If
                Else
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Update", MissingConfNoFailedScript, True)
                End If

                'oper.Dispose()
                oper = Nothing

                'ElseIf Not Session("cno") Is Nothing And Session("rcno") Is Nothing Then
            ElseIf Not objoperatordata.confirmation_no Is Nothing AndAlso objoperatordata.confirmation_no.Trim.Length > 0 Then
                '## 11/26/2007  changed by yang

                'If blnResult = True Then '
                '.confirmation_no = Convert.ToString(Session("cno"))

                If .PuAir = "Y" Then
                    .pu_county = .airport_name
                    .pu_city = ""
                Else
                    .airport_name = ""
                    .airport_airline = ""
                End If
                If .DestAir = "Y" Then
                    .dest_county = .dest_aiport_name
                    .dest_city = ""
                Else
                    .dest_aiport_name = ""
                    .dest_airport_airline = ""
                End If

                Dim oper As New Operators
                Dim intresult As Int16 = 0

                '## 2/13/2008   Check Auth No & Refer ID for Credit Card Order  (yang)
                Dim errMsg As String = ""

                '## 3/28/2008   (yang)
                Dim tmpOrd As OperatorData = oper.FillRides(objoperatordata.confirmation_no)

                If Not tmpOrd Is Nothing AndAlso tmpOrd.confirmation_no.Trim.Length > 0 And tmpOrd.vip_no.Trim.Length > 0 Then
                    If Pricing.ValidateCreditCardOrder(objoperatordata, errMsg) Then
                        intresult = oper.Update_Operator_Info(objoperatordata)
                    Else
                        If errMsg Is Nothing OrElse errMsg.Trim.Length = 0 Then
                            errMsg = "Credit Card is invalid."
                        End If

                        Page.ClientScript.RegisterStartupScript(GetType(String), "validate", String.Format("<script type='text/javascript'>alert('{0}');</script>", errMsg))
                    End If
                Else
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Update", MissingConfNoFailedScript, True)
                End If

                If intresult = 1 Then
                    send_mail()
                    'Response.Redirect("rideinquiry.aspx")
                    Response.Redirect("orderconfirmno.aspx?f=" & Me.hdnFrom.Value)
                End If
                'oper.Dispose()
                oper = Nothing
                'Else
                '    Response.Redirect("orderconfirm.aspx?msg=nocard&pagetype=" & Session("pagetype").ToString, True)
                'End If


            End If
        End With
    End Sub


    Private Sub check_pu_date_time()
        Dim oper As New Operators
        Dim objoperatordata As OperatorData
        objoperatordata = CType(Session.Item("Operator"), OperatorData)
        With objoperatordata
            .pu_date_time = oper.calc_pu_date_time(.req_date_time, .pu_county, .pu_city)
        End With
        'oper.Dispose()
        oper = Nothing

    End Sub

    '-----------------------------------------------------------------------------------
    '--Sub:send_mail
    '--Description:To show send_mail
    '--Input:
    '--Output:
    '--03/08/07 - Created (Daniel)
    '-----------------------------------------------------------------------------------
    Private Sub send_mail()
        Dim objoperatordata As OperatorData
        objoperatordata = CType(Session.Item("Operator"), OperatorData)

        With objoperatordata

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

            'title = "Your request of confirm#: " & .confirmation_no & "/" & Session("user_name").ToString & " (Please do not reply to this email)"
            title = "APEX  Confirmation#: " & .confirmation_no & "/" & MySession.UserName & " (Please do not reply to this email)"

            HTML_HEADER = "<html><head>" & vbCrLf
            HTML_HEADER = HTML_HEADER & "</head><body TOPMARGIN=""0"" MARGINHEIGHT=""0"" MARGINWIDTH=""0"">"
            HTML_FOOTER = "</body></html>"
            strBody = strBody & "<table width=""100%""><tr><td>"
            strBody = strBody & "<font face=""arial"" size=""2"">"
            strBody = strBody & "Thank you for booking with APEX - the follwing reservation has been confirmed. Please review it for accuracy.<p>"
            strBody = strBody & "</font></td></tr></table>"

            strBody = strBody & "<table cellpadding=2>"
            Dim oper As New Operators

            Dim mailfields(40) As String
            Dim mailvalues(40) As String

            Dim strMail As String = ""
            '-- modify by eJay 12/15/04
            Call oper.Get_email_Details(.confirmation_no, "", strMail)

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

            Dim mcc(,) As String
            Dim mbcc(,) As String
            Dim matt() As String
            Dim strReturn As String
            strReturn = Business.Mail.SendEmail("", strMail, title, strBody, True)
            If strReturn = "Success" Then
                'do nothing
            Else
                '--do nothing
            End If

        End With

    End Sub

    'Private Sub CleanOperInfo_byPagetype() '## 12/6/2007   disabled by yang
    '    If Session.Item("Operator") Is Nothing Then
    '        Exit Sub
    '    End If

    '    Dim objoperatordata As OperatorData
    '    objoperatordata = CType(Session.Item("Operator"), OperatorData)
    '    With objoperatordata

    '        Select Case Convert.ToString(Session("pagetype"))
    '            Case "0"
    '                'pickup airport
    '                .airport_name = ""
    '                .airport_name_desc = ""
    '                .airport_airline = ""
    '                .airport_flight = ""
    '                .airport_from = ""
    '                .airport_pu_point = ""

    '                'dest airport
    '                .dest_aiport_name = ""
    '                .dest_airport_name_desc = ""
    '                .dest_airport_airline = ""
    '                .dest_airport_flight = ""

    '            Case "1"
    '                'pickupdata
    '                .pu_landmark = ""
    '                .pu_county = .airport_name
    '                .pu_city = ""
    '                .pu_st_no = ""
    '                .pu_st_name = ""
    '                .pu_x_st = ""
    '                .pu_zip = ""
    '                .pu_point = ""

    '                'dest airport
    '                .dest_aiport_name = ""
    '                .dest_airport_name_desc = ""
    '                .dest_airport_airline = ""
    '                .dest_airport_flight = ""

    '            Case "2"
    '                'destdata
    '                .dest_landmark = ""
    '                .dest_county = .dest_aiport_name
    '                .dest_city = ""
    '                .dest_st_no = ""
    '                .dest_st_name = ""
    '                .dest_x_st = ""
    '                .dest_zip = ""
    '                .dest_point = ""

    '                'pickup airport
    '                .airport_name = ""
    '                .airport_name_desc = ""
    '                .airport_airline = ""
    '                .airport_flight = ""
    '                .airport_from = ""
    '                .airport_pu_point = ""
    '                'If tmpuserairport1.airport_phone <> "" Then
    '                '    .pu_phone = tmpuserairport1.airport_phone()
    '                'End If
    '            Case "3"
    '                'pickupdata
    '                .pu_landmark = ""
    '                .pu_county = .airport_name
    '                .pu_city = ""
    '                .pu_st_no = ""
    '                .pu_st_name = ""
    '                .pu_x_st = ""
    '                .pu_zip = ""
    '                .pu_point = ""

    '                'destdata
    '                .dest_landmark = ""
    '                .dest_county = .dest_aiport_name
    '                .dest_city = ""
    '                .dest_st_no = ""
    '                .dest_st_name = ""
    '                .dest_x_st = ""
    '                .dest_zip = ""
    '                .dest_point = ""

    '        End Select

    '    End With
    '    Session.Item("Operator") = objoperatordata
    'End Sub
    Private Sub Get_Airline_Code()
        Dim oper As New Operators
        Dim objoperatordata As OperatorData
        objoperatordata = CType(Session.Item("Operator"), OperatorData)
        With objoperatordata
            .pu_airport_airline_code = oper.Get_Airline_Code(.airport_airline)
            .dest_aiprot_airline_code = oper.Get_Airline_Code(.dest_airport_airline)
        End With
    End Sub

    'Private Sub Get_paymethod()
    '    Dim tabpaymethod As New DataTable
    '    Dim objpaymethod As New Operators
    '    tabpaymethod = objpaymethod.GetPaymethod(CStr(Session("acct_id")), CStr(Session("sub_acct_id")), CStr(Session("company")))
    '    ddlPaymenType.DataSource = tabpaymethod
    '    ddlPaymenType.DataBind()
    'End Sub

    'Private Sub insertAddress()

    '    Dim tmpaddress As New address_1
    '    Dim pu_address As String
    '    Dim dest_address As String

    '    If tmpuser1.state <> "" And tmpuser1.city <> "" And tmpuser2.state <> "" And tmpuser2.city <> "" Then
    '        address1 = tmpaddress.get_address(tmpuser1.st_no, tmpuser1.st_name, tmpuser1.state, tmpuser1.city, tmpuser1.zip_code)
    '        address2 = tmpaddress.get_address(tmpuser2.st_no, tmpuser2.st_name, tmpuser2.state, tmpuser2.city, tmpuser2.zip_code)

    '        Dim result As Int16
    '        Dim objGeoInfos As New GeoInfos
    '        result = objGeoInfos.insertorder(address1, address2)



    '        If result = 1 Then
    '            Response.Write("<script language=javascript>window.alert('Success');</script>")
    '            ' Response.Write("<script languge='javascript'>window.open('getdistance.aspx','zip',' width=375,height=400, top=200, left=300, toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no');</script>")
    '        End If
    '    End If


    'End Sub
#End Region

#Region "Private Function"

    Private Function loadUserInfo() As UserData
        Dim objGetUser As New Business.Users
        Return objGetUser.getUserInfo(Session("user_id").ToString, Session("acct_id").ToString, Session("sub_acct_id").ToString, Session("company"))
        'objGetUser.Dispose()
        objGetUser = Nothing
    End Function

#End Region

#Region "Private sub and Function"

    Private Sub AriseJavaScript(ByVal is_pu_airport As String, ByVal is_dest_airport As String)

        Dim strMessage As String
        strMessage = "<script language=""JavaScript"" type=""text/javascript"">"
        'strMessage = strMessage & ErrorMessage
        'strMessage = strMessage & ");"
        'strMessage = strMessage & "document.forms[0].txtUser.focus();"
        'strMessage = strMessage & "document.all['txtCCNo'].focus();"
        If is_pu_airport = "Y" Then
            'strMessage = strMessage & "{document.getElementById(""ctl00_MainContent_tdpuairport"").style.display='';}"
            'strMessage = strMessage & "{document.getElementById(""tdpu"").style.display='none';}"
            Me.tdpu.Style.Add("display", "none")
            Me.tdpuairport.Style.Add("display", "")
        Else
            'strMessage = strMessage & "{document.getElementById(""ctl00_MainContent_tdpuairport"").style.display='none';}"
            'strMessage = strMessage & "{document.getElementById(""tdpu"").style.display='';}"
            Me.tdpu.Style.Add("display", "")
            Me.tdpuairport.Style.Add("display", "none")
        End If
        If is_dest_airport = "Y" Then
            'strMessage = strMessage & "document.getElementById(""ctl00_MainContent_tddestairport"").style.display='';"
            'strMessage = strMessage & "document.getElementById(""tddest"").style.display='none';"
            Me.tddest.Style.Add("display", "none")
            Me.tddestairport.Style.Add("display", "")
        Else
            'strMessage = strMessage & "{document.getElementById(""ctl00_MainContent_tddestairport"").style.display='none';}"
            'strMessage = strMessage & "{document.getElementById(""tddest"").style.display='';}"
            Me.tddest.Style.Add("display", "")
            Me.tddestairport.Style.Add("display", "none")
        End If

        strMessage = strMessage & "</script>"

        'Response.Write(strMessage)
        ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage", strMessage)

    End Sub

    Private Function change_strname(ByVal strname As String) As String
        Dim tmpfind As String
        Dim tmpreplace As String
        Dim arrwhname As ArrayList
        Dim arrshname As ArrayList
        Dim dt As DataTable
        Dim dr As DataRow
        Dim i As Int32

        If strname <> "" Then
            arrwhname = New ArrayList
            arrwhname.Add("street")
            arrwhname.Add("boulevard")
            arrwhname.Add("avenue")
            arrwhname.Add("road")
            arrwhname.Add("highway")


            arrwhname.Add("place")
            arrwhname.Add("drive")
            arrwhname.Add("court")
            arrwhname.Add("circle")
            arrwhname.Add("lane")



            arrshname = New ArrayList
            arrshname.Add("St")
            arrshname.Add("Blvd")
            arrshname.Add("Ave")
            arrshname.Add("Rd")
            arrshname.Add("Hwy")

            arrshname.Add("PL")
            arrshname.Add("Dr")
            arrshname.Add("Ct")
            arrshname.Add("Cir")
            arrshname.Add("Ln")



            dt = New DataTable
            dt.Columns.Add(New DataColumn("whname", GetType(String)))
            dt.Columns.Add(New DataColumn("shname", GetType(String)))

            For i = 0 To arrwhname.Count - 1
                dr = dt.NewRow()
                dr(0) = arrwhname.Item(i)
                dr(1) = arrshname.Item(i)
                dt.Rows.Add(dr)
            Next


            tmpfind = Mid(strname, strname.LastIndexOf(" ") + 2)
            If tmpfind <> "" Then
                For i = 0 To dt.Rows.Count - 1
                    If LCase(tmpfind) = dt.Rows(i).Item(0).ToString Then
                        tmpreplace = dt.Rows(i).Item(1).ToString
                        strname = Replace(strname, Mid(strname, strname.LastIndexOf(" ") + 2), tmpreplace)
                    End If
                Next
            End If
        End If

        Return strname
    End Function
#End Region

End Class

