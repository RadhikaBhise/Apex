Imports Business
Imports DataAccess

Partial Class webride_OrderForm
    Inherits System.Web.UI.Page
    'Protected WithEvents bodyForm As System.Web.UI.HtmlControls.HtmlGenericControl
    Private objUserInfo As New UserData

#Region "Protected Page Load and Submit"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.btnSubmit.Attributes.Add("onclick", "return oncc()")
        '--for test----
        'Session("user_id") = "@000016"
        'Session("priority") = "A"
        'Session("acct_id") = "99999"
        'Session("sub_acct_id") = "0000000000"
        'Session("company") = "1"
        'Session("user_name") = "test"
        'Session("acct_name") = "Surrey"
        'Session("shareVoucherNo") = ""
        '--------------
        Dim strphone As String
        strphone = System.Configuration.ConfigurationManager.AppSettings("phone_number")
        If Session("user_id") Is Nothing Then
            Response.Redirect("login.aspx")
        End If
        '1 If Not Session("agent_id") Is Nothing Then
        'Dim cno As String
        'Dim rcno As String
        'cno = Request.QueryString("cno")
        'rcno = Request.QueryString("rcno")
        'Session("rcno") = rcno
        'If Not Session("rcno") Is Nothing Then
        '    Session("cno") = Session("rcno")
        'Else
        '    Session("cno") = cno
        'End If
        '3If Not Session("cno") Is Nothing Then
        '    Response.Redirect("agent_order_1.aspx")
        'Else
        '    Response.Redirect("agent_order_0.aspx")
        'End If
        ' End If

        Me.setAttributes(strphone)
      
        If Not Page.IsPostBack Then

            'Dim cno As String = Request.QueryString("cno")
            'Dim rcno As String

            If Not Request.QueryString("cno") Is Nothing AndAlso Request.QueryString("cno").Trim.Length > 0 Then
                Me.hdnConfNo.Value = Request.QueryString("cno").Trim
            End If

            'rcno = Request.QueryString("rcno")

            'Session("rcno") = rcno

            'If Session("cno") Is Nothing Then
            '    If Not Session("rcno") Is Nothing Then
            '        Session("cno") = Session("rcno")
            '    Else
            '        Session("cno") = cno
            '    End If
            'End If

            'Dim objSecurity As New Business.Security

            'If Session("user_id") Is Nothing Then
            '    Me.Change_bindFrqPU(Session("user_id").ToString)  '-- inite frequent pick up datalist
            '    Me.Change_bindFrqDest(Session("user_id").ToString)   '-- inite frequent destination datalist
            'End If

            '## add by joey     11/21/2007
            Dim strEvent As String = Request.QueryString("event")

            If Me.hdnConfNo.Value.Trim.Length > 0 Then
                '----------change the info
                LoadSessionCno(Me.hdnConfNo.Value)
            ElseIf Not Session.Item("Operator") Is Nothing And Not strEvent Is Nothing Then
                LoadSessionOperator()
            Else
                '---------load the info
                Me.LoadInfo()
            End If

            If Me.ckPAirport.Checked Then
                'RegisterStartupScript("PopUpMessage", "<script>document.getElemnetById('PState').style.display='none';alert('ok');</script>")
                'Me.txtPStName.Text = ""
                'Me.txtPStName.Enabled = False
                'Me.txtPStNo.Text = ""
                'Me.txtPStNo.Enabled = False
                'Me.txtPZip.Text = ""
                'Me.txtPZip.Enabled = False
                ClientScript.RegisterStartupScript(GetType(String), "EnableP", "<script language='javascript'>setenableControls('p')</script>")
            End If
            If Me.ckDAirport.Checked Then
                'RegisterStartupScript("PopUpMessage", "<script>document.getElemnetById('DState').style.display='none';</script>")
                'Me.txtDStName.Text = ""
                'Me.txtDStName.Enabled = False
                'Me.txtDStNo.Text = ""
                'Me.txtDStNo.Enabled = False
                'Me.txtDZip.Text = ""
                'Me.txtDZip.Enabled = False
                ClientScript.RegisterStartupScript(GetType(String), "EnableD", "<script language='javascript'>setenableControls('d')</script>")
            End If

            '## 11/22/2007  add for gray out payment if not credit card (yang)
            Me.ClientScript.RegisterStartupScript(GetType(String), "Payment", "<script type='text/javascript' language='javascript'>" & _
                    "PaytypeChange('" & Me.ddlPayType.ClientID & "','" & Me.ddlCardType.ClientID & "','" & Me.txtCardName.ClientID & "','" & Me.ddlMonth.ClientID & "','" & Me.ddlYear.ClientID & "','" & Me.txtCardNo.ClientID & "');</script>")
        End If

        'Try
        '    If Convert.ToString(Me.ddlPayType.SelectedValue).Trim = "5" Then
        '        Me.ddlPayType.SelectedValue = "5"

        '        ClientScript.RegisterStartupScript(GetType(String), "hidCreditCard", "<script language='javascript'>hidCard(1)</script>")
        '    Else
        '        ClientScript.RegisterStartupScript(GetType(String), "hidCreditCard", "<script language='javascript'>hidCard(0)</script>")
        '    End If
        'Catch ex As Exception
        '    ClientScript.RegisterStartupScript(GetType(String), "hidCreditCard", "<script language='javascript'>hidCard(0)</script>")
        'End Try
      

    End Sub

#End Region

#Region "Page Load_Sub"
    Private Sub setAttributes(ByVal strphone As String)
        Me.bodyform.Attributes.Add("onload", "load_PU_td('p');load_PU_td('d');")
        'Me.apCity.Attributes.Add("onclick", "citylookup('p');")
        'Me.ckPAirport.Attributes.Add("OnClick", "update_state_airport('P');")
        'Me.chk_as_directed.Attributes.Add("onclick", "set_asdirected();")
        Me.ckPAirport.Attributes.Add("OnClick", "if (document.getElementById('" & Me.ckPAirport.ClientID & "').checked) {document.getElementById('PState').style.display='none';window.open('airport_detail_1.aspx?type=p&code=','airport_new','width=450,height=450,scrollbars=1');}else{document.getElementById('PState').style.display='';enableControls('p');}")
        'Me.ckPAirport.Attributes.Add("onclick", "update_state_airport('P');toggle_airport_search('p','click');")
        Me.ckDAirport.Attributes.Add("OnClick", "if (document.getElementById('" & Me.ckDAirport.ClientID & "').checked) {document.getElementById('DState').style.display='none';window.open('airport_detail_1.aspx?type=d&code=','airport_new','width=450,height=450,scrollbars=1');}else{document.getElementById('DState').style.display='';enableControls('d');}")
        Me.btnSubmit.Attributes.Add("onclick", "return ValidateCheck('" & strphone & "');")

        Me.txtCardNo.Attributes.Add("onfocus", "check_search_max_length();")

        'Me.ddlCardType.Attributes.Add("onchange", "set_search_defaultinfo_cctypechange()")
        '## added by joey   11/20/2007
        Me.ddlPState.Attributes.Add("onchange", "javascript:StateChange('" & Me.txtPCity.ClientID & "','" & Me.ddlPState.ClientID & "','" & Me.txtPStNo.ClientID & "');")
        Me.ddlDState.Attributes.Add("onchange", "javascript:StateChange('" & Me.txtDCity.ClientID & "','" & Me.ddlDState.ClientID & "','" & Me.txtDStNo.ClientID & "');")
        '## added by joey   11/22/2007
        Me.ddlPayType.Attributes.Add("onchange", "javascript:PaytypeChange('" & Me.ddlPayType.ClientID & "','" & Me.ddlCardType.ClientID & "','" & Me.txtCardName.ClientID & "','" & Me.ddlMonth.ClientID & "','" & Me.ddlYear.ClientID & "','" & Me.txtCardNo.ClientID & "');")

    End Sub

    Private Sub LoadSessionCno(ByVal ConfNo As String)
        Me.bindFrqPU()
        Me.bindFrqDest()

        Using oper As New Operators
            Dim objOperInfo As OperatorData
            objOperInfo = oper.FillRides(ConfNo)

            'oper.Dispose()
            'oper = Nothing
            With objOperInfo

                '## Date Time Begin
                'ShowDateTime()
                'Dim strdate As String
                'strdate = Month(.req_date_time) & "/" & Day(.req_date_time) & "/" & Year(.req_date_time)
                'Me.ddlDate.SelectedValue = Convert.ToString(Month(.req_date_time) & "/" & Day(.req_date_time) & "/" & Year(.req_date_time))
                ''-- inite Travel Date/Time

                'If Hour(.req_date_time) = 0 Then
                '    Me.ddlHour.SelectedIndex = 12
                'ElseIf Hour(.req_date_time) > 12 Then
                '    Me.ddlHour.SelectedValue = Convert.ToString(Hour(.req_date_time) - 12)
                'Else
                '    Me.ddlHour.SelectedValue = Convert.ToString(Hour(.req_date_time))
                'End If


                'If Len(Convert.ToString(Minute(.req_date_time))) = 1 Then
                '    Me.ddlMin.SelectedValue = "0" & Convert.ToString(Minute(.req_date_time))
                'Else
                '    Me.ddlMin.SelectedValue = Convert.ToString(Minute(.req_date_time))
                'End If
                'If Hour(.req_date_time) >= 12 Then
                '    Me.ddlAMPM.SelectedValue = "PM"
                'Else
                '    Me.ddlAMPM.SelectedValue = "AM"
                'End If

                '## 11/14/2007  added by yang
                Me.Calendar1.DateTime = .req_date_time
                '## Date Time End


                'If Not Me.ddlAMPM.Items.FindByValue(Right(Convert.ToString(.req_date_time), 2)) Is Nothing Then
                '    Me.ddlAMPM.SelectedValue = Right(Convert.ToString(.req_date_time), 2)
                'End If

                'If Not .vip_phone Is Nothing Then
                '    If .vip_phone.Trim.Length = 10 Then
                '        Me.txtPhoneFront.Text = Left(.vip_phone, 3)
                '        Me.txtPhoneTail.Text = Right(.vip_phone, 7)
                '        Me.txtPhoneExt.Text = .pu_phone_ext
                '    End If
                'End If


                If Not .auth_telno Is Nothing Then
                    If .auth_telno.Trim.Length > 0 Then
                        Me.txtConPhoneFront.Text = Left(.auth_telno, 3)
                        Me.txtConPhoneTail.Text = Right(.auth_telno, 7)
                    End If
                End If
                '--modify by daniel for phone_number 24/2/2007
                If Not .pu_phone Is Nothing Then
                    If .pu_phone.Trim.Length = 10 Then
                        Me.txtPhoneFront.Text = Left(.pu_phone, 3)
                        Me.txtPhoneTail.Text = Right(.pu_phone, 7)
                        Me.txtPhoneExt.Text = .pu_phone_ext
                    End If
                End If
                'If Not .dest_phone Is Nothing Then
                '    If .dest_phone.Trim.Length > 0 Then
                '        Me.txtConPhoneFront.Text = .dest_phone
                '        Me.txtConPhoneTail.Text = .dest_phone_ext
                '    End If
                'End If
                'me.txtPhoneFront.Text=.
                'Me.txtPhoneExt.Text = .pu_phone_ext
                Me.txtLastName.Text = .lname
                Me.txtFirstName.Text = .fname
                Me.txtEmail.Text = .email_add


                '-- Payment Type, Credit Card, car type
                SetPayment()
                'Dim FindPaymentType As Boolean = False
                For Each li As ListItem In Me.ddlPayType.Items
                    If Not .payment_type Is Nothing AndAlso (li.Value.Trim = .payment_type.Trim OrElse li.Text.Trim = .payment_type.Trim) Then
                        Me.ddlPayType.SelectedIndex = -1
                        li.Selected = True
                        'FindPaymentType = True
                        Exit For
                    End If
                Next
                'If Not FindPaymentType Then
                InitControls()
                'End If
                'If Not ddlPayType.Items.FindByValue(.payment_type) Is Nothing Then
                '    Me.ddlPayType.SelectedValue = .payment_type
                'Else
                '    InitControls()
                'End If

                '## add credit card by joey     11/21/2007
                If Not ddlCardType.Items.FindByValue(.CC_Type_Default) Is Nothing And Not .CC_No_Default Is Nothing Then
                    Me.ddlCardType.SelectedValue = .CC_Type_Default
                    Me.txtCardNo.Text = .CC_No_Default
                End If
                Me.txtCardName.Text = .card_name

                If Not .card_exp_date Is Nothing Then
                    If .card_exp_date.Length > 1 Then
                        Me.ddlMonth.SelectedValue = Left(.card_exp_date, 2)
                        Me.ddlYear.SelectedValue = Right(.card_exp_date, 2)
                    End If
                End If

                If Not ddlVehicleType.Items.FindByValue(.Car_type) Is Nothing Then
                    Me.ddlVehicleType.SelectedValue = .Car_type
                End If
                '--Load P_point and airport
                If Not ddlPState.Items.FindByValue(.pu_county) Is Nothing Then
                    Me.ddlPState.SelectedValue = .pu_county
                End If

                Me.txtPStNo.Text = .pu_st_no
                Me.txtPStName.Text = .pu_st_name
                Me.txtPCity.Text = .pu_city
                Me.txtPZip.Text = .pu_zip

                Me.txtPPoint.Text = .pu_point

                If Not ddlPAirport.Items.FindByValue(.airport_name) Is Nothing Then
                    Me.ddlPAirport.SelectedValue = .airport_name
                End If
                If Not ddlPAirport.Items.FindByValue(.airport_name) Is Nothing AndAlso Not .airport_airline Is Nothing AndAlso .airport_airline.Trim.Length > 0 Then
                    Me.ckPAirport.Checked = True
                    .PuAir = "Y"
                Else
                    .PuAir = "N"
                End If
                If Not .airport_name_desc Is Nothing Then
                    Me.txtPAirName.Text = Convert.ToString(.airport_name_desc).Trim
                End If
                Me.ddlPAirport.SelectedValue = .airport_name
                Me.txtPAirline.Text = .airport_airline
                Me.txtPFlightNo.Text = .airport_flight
                Me.txtPAirPoint.Text = .airport_pu_point
                Me.txtPAirTime.Text = .airport_time
                'Me.txtPPhone.Text = .pu_phone
                Me.txtPAirCity.Text = .airport_from
                Me.txtPFbo.Text = .airport_terminal
                Dim str_output As String
                str_output = "Airport Name: " + .airport_name
                str_output += Chr(13) & "Airline: " + .airport_airline
                str_output += Chr(13) & "Flight #/Tail #: " + .airport_flight
                str_output += Chr(13) & "FBO: " + .airport_terminal
                str_output += Chr(13) & "Arrival Time: " + .airport_time
                str_output += Chr(13) & "Pass. Pickup Point: " + .airport_pu_point
                'str_output += Chr(13) & "Pass Pickup Phone: "
                'str_output += Chr(13) & "Departing City: "
                Me.pu_airport_detail.InnerText = str_output
                'Me.txtDirections.Text = .pu_direction

                '--Load D_point and airport
                If Not Me.ddlDState.Items.FindByValue(.dest_county) Is Nothing Then
                    Me.ddlDState.SelectedValue = .dest_county
                End If
                Me.txtDStNo.Text = .dest_st_no
                Me.txtDStName.Text = .dest_st_name
                Me.txtDCity.Text = .dest_city
                Me.txtDZip.Text = .dest_zip
                Me.txtDCross.Text = .dest_x_st

                '--load for DAir
                If Not ddlDAirport.Items.FindByValue(.dest_aiport_name) Is Nothing Then
                    Me.ddlDAirport.SelectedValue = .dest_aiport_name
                End If
                If Not ddlDAirport.Items.FindByValue(.dest_aiport_name) Is Nothing AndAlso Not .dest_airport_airline Is Nothing AndAlso .dest_airport_airline.Trim.Length > 0 Then
                    Me.ckDAirport.Checked = True
                    .DestAir = "Y"
                Else
                    .DestAir = "N"
                End If
                If Not .dest_airport_name_desc Is Nothing Then
                    Me.txtDAirName.Text = Convert.ToString(.dest_airport_name_desc).Trim
                End If
                Me.ddlDAirport.SelectedValue = .dest_airport_name_desc
                Me.txtDAirline.Text = .dest_airport_airline
                Me.txtDFlightNo.Text = .dest_airport_flight
                Me.txtDDepartingCity.Text = .dest_airport_from
                Me.txtDAirTime.Text = .dest_airport_departureTime
                Me.txtDFbo.Text = .dest_airport_terminal
                str_output = "Airport Name: " + .dest_airport_name_desc
                str_output += Chr(13) & "Airline: " + .dest_airport_airline
                str_output += Chr(13) & "Flight #/Tail #: " + .dest_airport_flight
                str_output += Chr(13) & "FBO: " + .dest_airport_terminal
                str_output += Chr(13) & "Arrival Time: " + .dest_airport_departureTime
                'str_output += Chr(13) & "Pass Pickup Phone: "
                'str_output += Chr(13) & "Departing City: " & .dest_airport_from
                Me.dest_airport_detail.InnerText = str_output
                'Me.dest_airport_detail.InnerText = .dest_airport_detail

                '--these info will be use into the orderconfirm.aspx
                'Session("voucher_no") = .voucher_no
                'Session("payment_type") = .payment_type
                'Session("card_type") = .card_type
                'Session("card_no") = .card_no
                'Session("card_exp_date") = .card_exp_date
                'Session("card_name") = .card_name

                'Session("tips_perc") = .tips_perc
                'Session("discount_cert_perc") = .discount_cert_perc

                ShowLit(objOperInfo)

            End With
        End Using

    End Sub

    Private Sub LoadSessionOperator()
        Me.bindFrqPU()
        Me.bindFrqDest()


        Dim objoperatordata As OperatorData
        objoperatordata = CType(Session.Item("Operator"), OperatorData)
        With objoperatordata


            'ShowDateTime()
            'Me.ddlDate.SelectedValue = Month(.req_date_time) & "/" & Day(.req_date_time) & "/" & Year(.req_date_time)
            ''-- inite Travel Date/Time

            'If Hour(.req_date_time) = 0 Then
            '    Me.ddlHour.SelectedIndex = 12
            'ElseIf Hour(.req_date_time) > 12 Then
            '    Me.ddlHour.SelectedValue = Convert.ToString(Hour(.req_date_time) - 12)
            'Else
            '    Me.ddlHour.SelectedValue = Convert.ToString(Hour(.req_date_time))
            'End If

            'If Len(Convert.ToString(Minute(.req_date_time))) = 1 Then
            '    Me.ddlMin.SelectedValue = "0" & Convert.ToString(Minute(.req_date_time))
            'Else
            '    Me.ddlMin.SelectedValue = Convert.ToString(Minute(.req_date_time))
            'End If
            'Me.ddlAMPM.SelectedValue = .Req_ampm
            '## 11/14/2007  added by yang
            Me.Calendar1.DateTime = .req_date_time

            'If Not Me.ddlAMPM.Items.FindByValue(Right(Convert.ToString(.req_date_time), 2)) Is Nothing Then
            '    Me.ddlAMPM.SelectedValue = Right(Convert.ToString(.req_date_time), 2)
            'End If

            'If .vip_phone <> "" And Len(.vip_phone) = 10 Then
            'If .vip_phone <> "" And Len(.vip_phone) >= 10 Then
            '    Me.txtPhoneFront.Text = Left(.vip_phone, 3)
            '    Me.txtPhoneTail.Text = .vip_phone.Substring(3, 7)
            '    Me.txtPhoneExt.Text = .vip_phone.Substring(10)
            'End If
            If .Auth_Telno.Trim.Length > 0 Then
                Me.txtConPhoneFront.Text = Left(.Auth_Telno, 3)
                Me.txtConPhoneTail.Text = Right(.Auth_Telno, 7)
            End If
            '--modify by daniel for phone_number 24/2/2007
            If .pu_phone <> "" And Len(.pu_phone) >= 10 Then
                Me.txtPhoneFront.Text = Left(.pu_phone, 3)
                Me.txtPhoneTail.Text = .pu_phone.Substring(3, 7)
                Me.txtPhoneExt.Text = .pu_phone_ext
            End If
            'If .dest_phone.Trim.Length > 0 Then
            '    Me.txtConPhoneFront.Text = .dest_phone
            '    Me.txtConPhoneTail.Text = .dest_phone_ext
            'End If
            'Me.txtPhoneExt.Text = .pu_phone_ext
            Me.txtLastName.Text = .lname
            Me.txtFirstName.Text = .fname
            Me.txtEmail.Text = .email_add
            SetPayment()

            Me.ddlPayType.SelectedValue = .payment_type
            Me.ddlCardType.SelectedValue = .card_type
            Me.txtCardNo.Text = .card_no
            'added by joey      11/22/2007
            Me.txtCardName.Text = .card_name
            If .card_exp_date.Length > 1 Then
                Me.ddlMonth.SelectedValue = Left(.card_exp_date, 2)
                Me.ddlYear.SelectedValue = Right(.card_exp_date, 2)
            End If




            '-- Payment Type, Credit Card, car type
            InitControls()
            Me.ddlVehicleType.SelectedValue = .Car_type
            '--Load pu_Point and pu_airport
            If .PuAir = "Y" Then
                Me.ckPAirport.Checked = True
            End If
            If .DestAir = "Y" Then
                Me.ckDAirport.Checked = True
            End If
            'Call Me.AriseJavaScript(.PuAir, .DestAir)
            If Not ddlPState.Items.FindByValue(.pu_county) Is Nothing Then
                Me.ddlPState.SelectedValue = .pu_county
            End If

            Me.txtPStNo.Text = .pu_st_no
            Me.txtPStName.Text = .pu_st_name
            Me.txtPCity.Text = .pu_city
            Me.txtPZip.Text = .pu_zip
            Me.txtPPoint.Text = .pu_point

            'for pu airport
            If Not ddlPAirport.Items.FindByValue(.airport_name.ToString) Is Nothing Then
                Me.ddlPAirport.SelectedValue = Convert.ToString(.airport_name)
            End If
            If Not .airport_name_desc Is Nothing Then
                Me.txtPAirName.Text = Convert.ToString(.airport_name_desc).Trim
            End If

            Me.txtPAirline.Text = Trim(Convert.ToString(.airport_airline))
            Me.txtPFlightNo.Text = .airport_flight
            Me.txtPAirTime.Text = .airport_time
            Me.txtPAirPoint.Text = .airport_pu_point
            Me.txtPFbo.Text = .airport_terminal
            Me.pu_airport_detail.InnerText = .airport_detail
            Me.txtPAirCity.Text = .airport_from

            '--Load D 
            If Not Me.ddlDState.Items.FindByValue(.dest_county) Is Nothing Then
                Me.ddlDState.SelectedValue = .dest_county
            End If
            Me.txtDStNo.Text = .dest_st_no
            Me.txtDStName.Text = .dest_st_name
            Me.txtDCity.Text = .dest_city
            Me.txtDZip.Text = .dest_zip
            Me.txtDCross.Text = .dest_x_st

            '--load dest airport
            If Not ddlDAirport.Items.FindByValue(.airport_name.ToString) Is Nothing Then
                Me.ddlDAirport.SelectedValue = Convert.ToString(.dest_aiport_name)
            End If
            If Not .dest_airport_name_desc Is Nothing Then
                Me.txtDAirName.Text = Convert.ToString(.dest_airport_name_desc).Trim
            End If
            Me.txtDAirline.Text = Trim(Convert.ToString(.dest_airport_airline))
            Me.txtDFlightNo.Text = .dest_airport_flight
            If Not Me.ddlDAirPoint.Items.FindByValue(.dest_airport_point.ToString) Is Nothing Then
                Me.ddlDAirPoint.SelectedValue = .dest_airport_point
            End If
            Me.txtDFbo.Text = .dest_airport_terminal
            Me.txtDAirTime.Text = .dest_airport_departureTime
            Me.dest_airport_detail.InnerText = .dest_airport_detail
            'If .dest_phone <> "" And Len(.dest_phone) = 10 Then
            'Me.txtDPhone.Text = .dest_phone
            Me.txtDDepartingCity.Text = .dest_airport_from

        End With
        Me.ShowLit(objoperatordata)

    End Sub

    Private Sub infodata()
        Dim i As Integer
        For i = 1 To 6
            If Not Request.Form.Item("comp_id_" & i) Is Nothing Then
                Session("comp_id_" & i) = Request.Form.Item("comp_id_" & i)
            Else
                Session("comp_id_" & i) = ""
            End If
        Next
        'Dim strComp_id_1 As String
        'Dim strComp_id_2 As String
        'Dim strComp_id_3 As String
        'Dim strComp_id_4 As String
        'Dim strComp_id_5 As String
        'Dim strComp_id_6 As String
        'strComp_id_1 = Me.hidcomp_id_1.Value 'Request.Form("comp_id_1")
        'strComp_id_2 = Me.hidcomp_id_2.Value 'Request.Form("comp_id_2")
        'strComp_id_3 = Me.hidcomp_id_3.Value 'Request.Form("comp_id_3")
        'strComp_id_4 = Me.hidcomp_id_4.Value 'Request.Form("comp_id_4")
        'strComp_id_5 = Me.hidcomp_id_5.Value 'Request.Form("comp_id_5")
        'strComp_id_6 = Me.hidcomp_id_6.Value 'Request.Form("comp_id_6")
        'If strComp_id_1 Is Nothing Then
        '    strComp_id_1 = ""
        '    Session("Comp_id_1") = ""
        'Else
        '    Session("Comp_id_1") = strComp_id_1
        'End If

        'If strComp_id_2 Is Nothing Then
        '    strComp_id_2 = ""
        '    Session("Comp_id_2") = ""
        'Else
        '    Session("Comp_id_2") = strComp_id_2
        'End If

        'If strComp_id_3 Is Nothing Then
        '    strComp_id_3 = ""
        '    Session("Comp_id_3") = ""
        'Else
        '    Session("Comp_id_3") = strComp_id_3
        'End If

        'If strComp_id_4 Is Nothing Then
        '    strComp_id_4 = ""
        '    Session("Comp_id_4") = ""
        'Else
        '    Session("Comp_id_4") = strComp_id_4
        'End If

        'If strComp_id_5 Is Nothing Then
        '    strComp_id_5 = ""
        '    Session("Comp_id_5") = ""

        'Else
        '    Session("Comp_id_5") = strComp_id_5
        'End If

        'If strComp_id_6 Is Nothing Then
        '    strComp_id_6 = ""
        '    Session("Comp_id_6") = ""
        'Else
        '    Session("Comp_id_6") = strComp_id_6
        'End If
        'ShowLit()
        Dim objoperatordata As New OperatorData
        With objoperatordata
            '## `11/26/2007 (yang)
            If Me.hdnConfNo.Value.Trim.Length > 0 Then
                objoperatordata.confirmation_no = Me.hdnConfNo.Value
            End If

            'infodata
            .Comp_id_1 = Session("Comp_id_1")
            .Comp_id_2 = Session("Comp_id_2")
            .Comp_id_3 = Session("Comp_id_3")
            .Comp_id_4 = Session("Comp_id_4")
            .Comp_id_5 = Session("Comp_id_5")
            .Comp_id_6 = Session("Comp_id_6")

            .comp_req_1 = Session("arrComReq1").ToString
            .comp_req_2 = Session("arrComReq2").ToString
            .comp_req_3 = Session("arrComReq3").ToString
            .comp_req_4 = Session("arrComReq4").ToString
            .comp_req_5 = Session("arrComReq5").ToString
            .comp_req_6 = Session("arrComReq6").ToString

            'infodata
            .vip_no = MySession.UserID
            .account_no = MySession.AcctID
            .sub_account_no = MySession.SubAcctID
            .company = MySession.Company
            .priority = Session("priority") = "n"

            .req_date_time = Me.Calendar1.DateTime
            .Req_min = Me.Calendar1.DateTime.Minute.ToString
            If Me.Calendar1.DateTime.Hour >= 0 AndAlso Me.Calendar1.DateTime.Hour < 12 Then
                .Req_ampm = "AM"
            Else
                .Req_ampm = "PM"
            End If
            If Me.Calendar1.DateTime.Hour > 0 AndAlso Me.Calendar1.DateTime.Hour <> 12 Then
                .Req_hour = Convert.ToString(Me.Calendar1.DateTime.Hour Mod 12)
            Else
                .Req_hour = "12"
            End If

            '--add by daniel for pu_phone and dest_phone 24/2/2007
            '.pu_phone_area = Me.txtPhoneFront.Text.Trim()
            .pu_phone = Me.txtPhoneFront.Text.Trim() & Me.txtPhoneTail.Text.Trim()
            .pu_phone_ext = Me.txtPhoneExt.Text.Trim()
            '----------------------------------------------------------
            ' .dest_phone = Me.txtConPhoneFront.Text.Trim()
            ' .dest_phone_ext = Me.txtConPhoneTail.Text.Trim()
            '----------------------------------------------------------
            '.vip_phone = Me.txtPhoneFront.Text.Trim() & Me.txtPhoneTail.Text.Trim()
            '.dest_phone_ext = Me.txtPhoneExt.Text.Trim()
            .dest_phone = Me.txtConPhoneFront.Text.Trim & Me.txtConPhoneTail.Text.Trim
            '## add by joey 11/22/2007
            .auth_telno = Me.txtConPhoneFront.Text.Trim & Me.txtConPhoneTail.Text.Trim

            .pass_lname = Me.txtLastName.Text.Trim()
            .pass_fname = Me.txtFirstName.Text.Trim()
            .lname = Me.txtLastName.Text.Trim()
            .fname = Me.txtFirstName.Text.Trim()
            .email_add = Me.txtEmail.Text.Trim()

            .payment_type = Me.ddlPayType.SelectedValue.Trim()
            If .payment_type = "" Then
                Session("paytype") = ""
            Else
                Session("paytype") = Me.ddlPayType.SelectedItem.Text.Trim

            End If

            .Car_type = Me.ddlVehicleType.SelectedValue.Trim()
            If .Car_type = "" Then
                Session("cartype") = ""
            Else
                Session("cartype") = Me.ddlVehicleType.SelectedItem.Text.Trim
            End If

            .card_type = Me.ddlCardType.SelectedValue.Trim()
            If .card_type = "" Then
                Session("cardtype") = ""
            Else
                Session("cardtype") = Me.ddlCardType.SelectedItem.Text.Trim
            End If

            .card_no = Me.txtCardNo.Text.Trim()
            .card_name = Me.txtCardName.Text.Trim()
            .card_exp_date = Convert.ToString(Me.ddlMonth.SelectedValue & Me.ddlYear.SelectedValue)
            If Me.ckPAirport.Checked Then
                .PuAir = "Y"
            Else
                .PuAir = "N"
            End If
            If Me.ckDAirport.Checked Then
                .DestAir = "Y"
            Else
                .DestAir = "N"
            End If
            'pickupdata
            'If ckDAirport.Checked = True Then
            '    .pu_county = Me.ddlPAirport.SelectedValue.Trim()
            'Else
            '    .pu_county = Me.ddlPState.SelectedValue.Trim()
            'End If
            .pu_county = Me.ddlPState.SelectedValue.Trim()
            .pu_county_desc = Me.ddlPState.SelectedItem.Text.Trim() '## 11/22/2007  added by yang
            .pu_city = Me.txtPCity.Text.Trim()
            .pu_st_no = Me.txtPStNo.Text.Trim()
            .pu_st_name = Me.txtPStName.Text.Trim()
            .pu_zip = Me.txtPZip.Text.Trim()
            .pu_point = Me.txtPPoint.Text.Trim()

            'destdata
            'If ckDAirport.Checked = True Then
            '    .dest_county = Me.ddlDAirport.SelectedValue.Trim()
            'Else
            '    .dest_county = Me.ddlDState.SelectedValue.Trim()
            'End If
            .dest_county = Me.ddlDState.SelectedValue.Trim()
            .dest_county_desc = Me.ddlDState.SelectedItem.Text.Trim()   '## 11/22/2007  added by yang
            .dest_city = Me.txtDCity.Text.Trim()
            .dest_st_no = Me.txtDStNo.Text.Trim()
            .dest_st_name = Me.txtDStName.Text.Trim()
            .dest_x_st = Me.txtDCross.Text.Trim()
            .dest_zip = Me.txtDZip.Text.Trim()

            'pickup airport
            .airport_name = Me.ddlPAirport.SelectedValue.Trim()
            .airport_airline = Me.txtPAirline.Text.Trim()
            .airport_flight = Me.txtPFlightNo.Text.Trim()
            .airport_pu_point = Me.txtPAirPoint.Text.Trim
            .airport_terminal = Me.txtPFbo.Text.Trim
            .airport_from = Me.txtPAirCity.Text.Trim()
            If Me.txtPAirTime.Text.Trim <> "" Then
                .airport_time = Convert.ToDateTime(Me.txtPAirTime.Text.Trim)
            Else
                .airport_time = .req_date_time
            End If
            .fbo_name = Me.txtPFboName.Text.Trim
            If .fbo_name Is Nothing Then
                .fbo_name = ""
            End If
            .fbo_address = Me.txtPFboAddress.Text.Trim
            If .fbo_address Is Nothing Then
                .fbo_address = ""
            End If
            .airport_detail = Me.pu_airport_detail.InnerText
            If Me.ckPAirport.Checked Then
                .airport_name_desc = Me.txtPCity.Text.Trim
            End If
            '--add by eJay 2/5/05--meet_great----------------------------
            .Meet_great = "N" '--default
            'If .airport_pu_point.StartsWith("Inside") Then
            '    .Meet_great = "Y"
            'End If
            '------------------------------------------------------------
            '.pu_phone = Me.txtPPhone.Text.Trim()

            'dest airport
            .dest_aiport_name = Me.ddlDAirport.SelectedValue.Trim()
            .dest_airport_airline = Me.txtDAirline.Text.Trim()
            .dest_airport_flight = Me.txtDFlightNo.Text.Trim()
            .dest_airport_point = Me.ddlDAirPoint.SelectedValue.Trim()
            '.dest_phone = Me.txtDPhone.Text.Trim()
            .dest_airport_from = Me.txtDDepartingCity.Text.Trim()
            .dest_airport_terminal = Me.txtDFbo.Text.Trim
            If Me.txtDAirTime.Text.Trim <> "" Then
                .dest_airport_departureTime = Convert.ToDateTime(Me.txtDAirTime.Text.Trim)
            Else
                .dest_airport_departureTime = Convert.ToDateTime(.req_date_time)
            End If

            .dest_fbo_address = Me.txtDFboAddress.Text.Trim
            If .dest_fbo_address Is Nothing Then
                .dest_fbo_address = ""
            End If
            .dest_fbo_name = Me.txtDFboName.Text.Trim
            If .dest_fbo_name Is Nothing Then
                .dest_fbo_name = ""
            End If
            .dest_airport_detail = Me.dest_airport_detail.InnerText
            If Me.ckDAirport.Checked Then
                .dest_airport_name_desc = Me.txtDCity.Text.Trim
            End If
            Dim gi As New GeoInfos
            If IsDate(.airport_time) And (gi.isAirportOn(.airport_name) Or gi.isAirportOn(.dest_aiport_name)) Then
                If DateDiff("n", .req_date_time, .airport_time) < 0 Then
                    ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage6", "alert('ok');alert('The flight arrival/depature date that you entered is before the travel date you specified. The flight date must be after the travel date.');")
                End If
                If DateDiff("n", .req_date_time, .dest_airport_departureTime) < 0 Then
                    ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage7", "alert('ok');alert('The flight arrival/depature date that you entered is before the travel date you specified. The flight date must be after the travel date.');")
                End If
            End If
        End With

        Session.Item("operator") = objoperatordata
    End Sub

    Private Sub UpdateVipEmail(ByVal Vip_no As String)
        Dim tmpuserinfo As New UserData
        'tmpuserinfo = Me.DaytimeVoucherInfo1.UserInfo
        Dim email As String
        email = Me.txtEmail.Text.Trim
        Using objuser As New Users
            objuser.VIPEmailUpdate(Vip_no, Session("acct_id").ToString, Session("sub_acct_id").ToString, Session("company").ToString, email)
            'objuser.Dispose()
            'objuser = Nothing
        End Using
    End Sub

#End Region

#Region "Load Information Sub"

    Public Sub LoadInfo()

        '-- inite Travel Date/Time
        'ShowDateTime()
        '## 11/14/2007  added by yang
        Me.Calendar1.DateTime = Now
        'Me.bindExpDate()

        '-- load default value for the page controls
        'loadUserInfo()
        Using objGetUser As New Business.Users
            Dim objUserInfo As UserData
            objUserInfo = objGetUser.getUserInfo(Session("user_id").ToString, Session("acct_id").ToString, Session("sub_acct_id").ToString, Session("company").ToString)
            'objGetUser.Dispose()
            'objGetUser = Nothing

            '-- Primary Phone Number
            Me.txtPhoneFront.Text = objUserInfo.office_phone_area
            Me.txtPhoneTail.Text = objUserInfo.office_phone
            Me.txtPhoneExt.Text = objUserInfo.office_phone_ext
            If Not objUserInfo.fax Is Nothing AndAlso objUserInfo.fax.Trim.Length > 7 Then
                Me.txtConPhoneFront.Text = Left(objUserInfo.fax, 3)
                Me.txtConPhoneTail.Text = Right(objUserInfo.fax, 7)
            End If

            '## 11/23/2007  added by yang
            Me.txtPhoneFront.Attributes.Add("onpropertychange", "javascript:GoToNextPhoneBox(this.id,'" & Me.txtPhoneTail.ClientID & "'," & Me.txtPhoneFront.MaxLength & ");")
            Me.txtPhoneTail.Attributes.Add("onpropertychange", "javascript:GoToNextPhoneBox(this.id,'" & Me.txtPhoneExt.ClientID & "'," & Me.txtPhoneTail.MaxLength & ");")
            Me.txtConPhoneFront.Attributes.Add("onpropertychange", "javascript:GoToNextPhoneBox(this.id,'" & Me.txtConPhoneTail.ClientID & "'," & Me.txtConPhoneFront.MaxLength & ");")

            '-- Last, First Name
            Me.txtFirstName.Text = objUserInfo.fname
            Me.txtLastName.Text = objUserInfo.lname

            '-- Email Address
            Me.txtEmail.Text = objUserInfo.email
            Me.txtCardName.Text = objUserInfo.CCName
            SetPayment()

            Me.ddlPayType.SelectedValue = objUserInfo.PaymenType
            Me.ddlCardType.SelectedValue = objUserInfo.CCType
            '-- Payment Type, Credit Card, car type
            InitControls()

            bindFrqPU()
            bindFrqDest()
            Me.pu_airport_detail.InnerText = "Airport Name:" & Chr(13) & "Airline:" & Chr(13) & "Flight #/Tail #:" & Chr(13) & "FBO:" & Chr(13) & "Arrival(Time):" & Chr(13) & "Pass. Pickup Point:"
            Me.dest_airport_detail.InnerText = "Airport Name:" & Chr(13) & "Airline:" & Chr(13) & "Flight #/Tail #:" & Chr(13) & "FBO:" & Chr(13) & "Arrival(Time):"
        End Using
        '-- Bind Comp Id Reapter
        ShowLit()      '--add by daniel for bill's request

        '--Puairport or no


    End Sub
    'Private Sub ShowDateTime()
    '    Dim i As Int32
    '    '-- show Date  
    '    Me.ddlDate.Items.Clear()

    '    For i = 0 To 91
    '        Dim daytime As DateTime = DateAdd(DateInterval.Day, i, Now())

    '        Dim ddlweekname As String
    '        ddlweekname = Left(WeekdayName(Weekday(daytime)), 3)
    '        Dim ddltext As String = Year(daytime) & "-" & Month(daytime) & "-" & Day(daytime) & " " & ddlweekname 'Left(WeekdayName(Weekday(daytime)), 3)
    '        ' Dim ddltext As String = Month(daytime) & "/" & Day(daytime) & "/" & Year(daytime) & " " & Left(WeekdayName(Weekday(daytime)), 3)
    '        Dim ddlvalue As String = Month(daytime) & "/" & Day(daytime) & "/" & Year(daytime)
    '        Me.ddlDate.Items.Add(New ListItem(ddltext, ddlvalue))
    '        'Me.ddlDate.Items.Add(New ListItem(DateValue(CStr(DateAdd("d", i, Now))) & " " & WeekdayName(Weekday(DateValue(CStr(DateAdd("d", i, Now)))), True), DateValue(CStr(DateAdd("d", i, Now))).ToString))
    '    Next
    '    'Me.ddlDate.Items.FindByValue(DateValue(Now.ToString).ToString).Selected = True     '-- default is today
    '    ' Me.ddldate.Items.FindByValue(strReqDateTime).Selected()

    '    '-- show Hour
    '    Me.ddlHour.Items.Clear()
    '    'Me.ddlHour.Items.Add(New ListItem("-", ""))
    '    For i = 1 To 12
    '        Me.ddlHour.Items.Add(New ListItem(i.ToString, i.ToString))
    '    Next
    '    i = Hour(Now) Mod 12
    '    i = CInt(IIf(i = 0, 12, i))
    '    Me.ddlHour.Items.FindByValue(i.ToString).Selected = True    '-- default is now
    '    ' Me.ddldate.Items.FindByValue(strReqDateTime).Selected()

    '    '-- show minute
    '    '-- every 5 minite
    '    Me.ddlMin.Items.Clear()
    '    'Me.ddlMin.Items.Add(New ListItem("-", ""))
    '    For i = 0 To 59
    '        If i < 10 Then
    '            Me.ddlMin.Items.Add(New ListItem("0" + i.ToString, "0" + i.ToString))
    '        Else
    '            Me.ddlMin.Items.Add(New ListItem(i.ToString, i.ToString))
    '        End If
    '    Next
    '    ' Me.ddlMin.Items.FindByValue(Format(Minute(Now), "00")).Selected = True '-- default is close to now
    '    Me.ddlMin.SelectedIndex = Now.Minute
    '    '-- set default for am or pm
    '    If Hour(Now) < 12 Then
    '        Me.ddlAMPM.SelectedIndex = 0  '-- is am
    '    Else
    '        Me.ddlAMPM.SelectedIndex = 1  '-- is pm
    '    End If

    'End Sub
    Private Sub InitControls()
        ' -- set Payment Type, no default value
        Using objOrder As New Business.Orders

            '-- set car type
            With Me.ddlVehicleType
                .DataSource = objOrder.getCarType
                .DataTextField = "car_type_desc"
                .DataValueField = "car_type_id"
                .DataBind()

                '.Items.Insert(0, New ListItem("-", ""))

            End With

            'With Me.hidddlCarType
            '    .DataSource = objOrder.getCarType
            '    .DataTextField = "car_type_desc"
            '    .DataValueField = "max_passenger"
            '    .DataBind()

            '    .Items.Insert(0, New ListItem("-", ""))
            'End With


            If Convert.ToString(Session("table_id")) = "100" Then
                With Me.ddlVehicleType
                    .Items.RemoveAt(0)
                    .Items.RemoveAt(0)
                    .Items.RemoveAt(0)
                    .Items.RemoveAt(2)
                    .Items.RemoveAt(2)
                    .Items.RemoveAt(2)
                End With
                With Me.hidddlCarType
                    .Items.RemoveAt(0)
                    .Items.RemoveAt(0)
                    .Items.RemoveAt(0)
                    .Items.RemoveAt(2)
                    .Items.RemoveAt(2)
                    .Items.RemoveAt(2)
                End With
            End If
        End Using
        'objOrder.Dispose()
        'objOrder = Nothing
        '--For load all state to hidstate
        Me.load_state()
        '--For pick up 
        Me.loadStateAirport()
        '--For load all airport to hidairport
        Me.load_airport()
        '--For load all airline to hidairline
        'Me.load_airline()
        '--For Dest State
        'Me.LoadDestStateAirport()

    End Sub
    '--Sub ShowLit
    '--Description Show company_requirement
    '--input
    '--output
    '--Add by Daniel
    '--2006/4/12
    Private Sub ShowLit(Optional ByVal opr As OperatorData = Nothing)
        Dim arrCompID(6) As String
        Dim comp_id(6) As String
        Dim objcom As New Operators
        Dim tabcom As New DataTable

        Dim i As Integer
        If Not opr Is Nothing Then
            comp_id(0) = opr.Comp_id_1
            comp_id(1) = opr.Comp_id_2
            comp_id(2) = opr.Comp_id_3
            comp_id(3) = opr.Comp_id_4
            comp_id(4) = opr.Comp_id_5
            comp_id(5) = opr.Comp_id_6
        End If

        lit1.Text = ""
        tabcom = objcom.GetCompanyQue(CStr(Session("acct_id")), Session("sub_acct_id").ToString, Session("company").ToString)

        If Not tabcom Is Nothing Then
            For i = 0 To tabcom.Rows.Count - 1
                arrCompID(i) = Trim(tabcom.Rows(i).Item("comp_req_1").ToString)
                If Not IsDBNull(tabcom.Rows(i).Item("comp_ver_1")) Then
                    If Trim(tabcom.Rows(i).Item("comp_ver_1").ToString) = "2" Or Trim(tabcom.Rows(i).Item("comp_ver_1").ToString) = "1" Then
                        If Not Session("comp_id_" & i + 1 & "") Is Nothing Then
                            lit1.Text = lit1.Text & "<tr><td align=""left"" class=""css_desc"">" & Security.SentenceCase(Trim(tabcom.Rows(i).Item("req_desc").ToString)) & "</td><td align=""left""><input type=""text"" id=""comp_id_" & i + 1 & """ name=""comp_id_" & i + 1 & """  CssClass=""cssSelect"" maxlength=""20"" value='" & comp_id(i) & "'>"
                        Else
                            lit1.Text = lit1.Text & "<tr><td align=""left"" class=""css_desc"">" & Security.SentenceCase(Trim(tabcom.Rows(i).Item("req_desc").ToString)) & "</td><td align=""left""><input type=""text"" id=""comp_id_" & i + 1 & """ name=""comp_id_" & i + 1 & """ CssClass=""cssSelect"" maxlength=""20"" value='" & comp_id(i) & "'>"
                        End If
                        lit1.Text = lit1.Text & "<img alt="""" src='Images/required_star.gif' /><span id='reddot'style='display:none;'><img alt='' src='Images/reddot.gif' style='src:url(Images/required_star.gif)' /></span><input type=""hidden"" name=""hidcom_id_" & i + 1 & """ value=""" & Security.SentenceCase(Trim(tabcom.Rows(i).Item("req_desc").ToString)) & """></td></tr>"
                        Me.hidreque1.Value = Me.hidreque1.Value & "|" & Trim(tabcom.Rows(i).Item("req_desc").ToString)
                    Else
                        lit1.Text = lit1.Text & "<tr><td align=""left"" class=""css_desc"">" & Security.SentenceCase(Trim(tabcom.Rows(i).Item("req_desc").ToString)) & "</td><td align=""left"" style=""width: 478px; height: 26px;""><input type=""text"" id=""comp_id_" & i + 1 & """ name=""comp_id_" & i + 1 & """ CssClass=""cssSelect"" maxlength=""20"" value='" & comp_id(i) & "'></td></tr>"
                    End If
                Else
                    lit1.Text = lit1.Text & "<tr><td align=""left"" class=""css_desc"">" & Security.SentenceCase(Trim(tabcom.Rows(i).Item("req_desc").ToString)) & "</td><td align=""left"" style=""width: 478px; height: 26px;""><input type=""text"" id=""comp_id_" & i + 1 & """ name=""comp_id_" & i + 1 & """ CssClass=""cssSelect"" maxlength=""20"" value='" & comp_id(i) & "'></td></tr>"
                End If
            Next

            If tabcom.Rows.Count = 0 Then
                lit1.Text = "" 'lit1.Text & "<tr><td></td></tr>"
            End If

            Session("arrComReq1") = arrCompID(0)
            Session("arrComReq2") = arrCompID(1)
            Session("arrComReq3") = arrCompID(2)
            Session("arrComReq4") = arrCompID(3)
            Session("arrComReq5") = arrCompID(4)
            Session("arrComReq6") = arrCompID(5)

            If Session("arrComReq1") Is Nothing Then
                Session("arrComReq1") = ""
            End If
            If Session("arrComReq2") Is Nothing Then
                Session("arrComReq2") = ""
            End If
            If Session("arrComReq3") Is Nothing Then
                Session("arrComReq3") = ""
            End If
            If Session("arrComReq4") Is Nothing Then
                Session("arrComReq4") = ""
            End If
            If Session("arrComReq5") Is Nothing Then
                Session("arrComReq5") = ""
            End If
            If Session("arrComReq6") Is Nothing Then
                Session("arrComReq6") = ""
            End If

        End If

    End Sub
    Private Sub SetPayment()

        Dim objGetUser As New Business.Users
        Dim objUserInfo As UserData
        objUserInfo = objGetUser.getUserInfo(Session("user_id").ToString, Session("acct_id").ToString, Session("sub_acct_id").ToString, Session("company").ToString)
        'objGetUser.Dispose()
        objGetUser = Nothing

        Dim objcard As New Business.Card
        'With objUserInfo
        '    '    Me.hidcardtype2.Value = .CCType1
        '    '    Me.hidcardno2.Value = .CCNo1
        '    '    'Me.hidcardmonth.Value = .CCMonth1.TrimStart(Convert.ToChar("0"))
        '    '    Me.hidcardmonth.Value = .CCMonth1
        '    '    Me.hidcardyear.Value = .CCYear1
        '    '    Me.hidcardname2.Value = .CCName1

        '    Me.hidcardtype.Value = .CCType
        '    Me.hidcardno.Value = .CCNo
        '    'Me.hidcardmonth1.Value = .CCMonth.TrimStart(Convert.ToChar("0"))
        '    Me.hidcardmonth.Value = .CCMonth
        '    Me.hidcardyear.Value = .CCYear
        '    Me.hidcardname.Value = .CCName

        'End With


        '-- set Card Type
        'If Session("cno") Is Nothing Then
        '    Me.ddlPaymenType.SelectedValue = "5"
        'End If


        GetPaymethod()
        With Me.ddlCardType
            Dim CCDataSet As DataSet = objcard.getAllCardType
            If Not CCDataSet Is Nothing AndAlso CCDataSet.Tables.Count > 0 Then
                .DataSource = CCDataSet
                .DataTextField = "card_type_desc"
                .DataValueField = "card_type_id"
                .DataBind()
                .Items.Insert(0, New ListItem("Credit Card Type", ""))
                '.Items.RemoveAt(2)
                '.Items.RemoveAt(2)
                '.Items.RemoveAt(2)

                If objUserInfo.CCType Is Nothing Or objUserInfo.CCType = "" Then
                    '--do nothing
                    .SelectedIndex = 0
                ElseIf .Items.FindByValue(objUserInfo.CCType) Is Nothing Then
                    '--do nothing
                    '    .SelectedIndex = 0
                Else
                    .Items.FindByValue(objUserInfo.CCType).Selected = True
                End If
            End If
        End With
        'objcard.Dispose()
        objcard = Nothing

        Dim i As Int32
        '-- set credit card month
        With Me.ddlMonth
            .Items.Add(New ListItem("Month", ""))
            For i = 1 To 12
                .Items.Add(New ListItem(MonthName(i, True), i.ToString("00")))
            Next

            If objUserInfo.CCMonth Is Nothing Or objUserInfo.CCMonth = "" Then
                .SelectedIndex = 0
                '--do nothing
            ElseIf .Items.FindByValue(objUserInfo.CCMonth) Is Nothing Then
                .SelectedIndex = 0
                '--do nothing

            Else
                .Items.FindByValue(objUserInfo.CCMonth).Selected = True

            End If

        End With

        '-- set credit card year
        With Me.ddlYear
            .Items.Add(New ListItem("Year", ""))
            For i = 0 To 10
                .Items.Add(New ListItem(Right(Year(DateAdd("yyyy", i, Now)).ToString, 2), Right(Year(DateAdd("yyyy", i, Now)).ToString, 2)))
            Next

            If objUserInfo.CCYear Is Nothing Or objUserInfo.CCYear = "" Then
                .SelectedIndex = 0
                '--do nothing
            ElseIf .Items.FindByValue(objUserInfo.CCYear) Is Nothing Then
                .SelectedIndex = 0
                '--do nothing
            Else
                Dim intYear As Int16
                If Convert.ToInt16(objUserInfo.CCYear) > 50 Then
                    intYear = Convert.ToInt16("19" & objUserInfo.CCYear)
                Else
                    intYear = Convert.ToInt16("20" & objUserInfo.CCYear)
                End If

                If intYear >= Now.Year Then
                    .Items.FindByValue(objUserInfo.CCYear).Selected = True
                Else
                    '--do nothing

                End If

            End If

        End With

        Me.txtCardNo.Text = objUserInfo.CCNo
        Me.txtCardName.Text = objUserInfo.CCName


        'If Not Session("cno") Is Nothing Then
        '    'If Not Session("payment_type") Is Nothing Then
        '    '    If Session("payment_type").ToString <> "" And Not Me.ddlPaymenType.Items.FindByText(Convert.ToString(Session("payment_type"))) Is Nothing Then
        '    '        Me.ddlPaymenType.Items.FindByText(Convert.ToString(Session("payment_type"))).Selected = True
        '    '        '  Me.ddlPaymenType.SelectedIte = Convert.ToString(Session("payment_type"))
        '    '    End If
        '    'End If


        '    If Not Session("card_type") Is Nothing Then
        '        If Session("card_type").ToString <> "" And Not Me.ddlCardType.Items.FindByValue(Convert.ToString(Session("card_type"))) Is Nothing Then

        '            Me.ddlCardType.SelectedValue = Convert.ToString(Session("card_type"))
        '        End If
        '    End If


        '    If Not Session("card_no") Is Nothing Then
        '        If Session("card_no").ToString <> "" Then
        '            Me.txtCardNo.Text = Convert.ToString(Session("card_no"))
        '        End If
        '    End If

        '    If Not Session("card_exp_date") Is Nothing Then
        '        If Session("card_exp_date").ToString <> "" And Not Me.ddlMonth.Items.FindByValue(Left(Convert.ToString(Session("card_exp_date")), 2).TrimStart(Convert.ToChar("0"))) Is Nothing And Not Me.ddlYear.Items.FindByValue(Right(Convert.ToString(Session("card_exp_date")), 2)) Is Nothing Then
        '            Me.ddlMonth.SelectedValue = Left(Convert.ToString(Session("card_exp_date")), 2).TrimStart(Convert.ToChar("0"))
        '            Me.ddlYear.SelectedValue = Right(Convert.ToString(Session("card_exp_date")), 2)
        '        End If
        '    End If

        '    If Not Session("card_name") Is Nothing Then
        '        If Session("card_name").ToString <> "" Then
        '            Me.txtCardName.Text = Convert.ToString(Session("card_name"))
        '        End If
        '    End If

        'End If

    End Sub

    Private Sub GetPaymethod()
        Using payment As New Operators
            payment.BindPaymentType(Me.ddlPayType, Common.UserType.NormalUser)
            Me.ddlPayType.Items.Insert(0, New ListItem("DISABLED", "99"))
        End Using
    End Sub

#End Region

#Region "Private Sub"
    Private Sub bindExpDate()
        '## 11/20/2007  added by joey
        Dim i As Integer
        Dim year As Integer = Now.Year
        Me.ddlYear.Items.Clear()
        Me.ddlMonth.Items.Clear()
        For i = 0 To 10
            Me.ddlYear.Items.Add((year + i).ToString)
        Next
        Me.ddlYear.Items.Insert(0, "Year")
        For i = 1 To 12
            Me.ddlMonth.Items.Add(i.ToString)
        Next
        Me.ddlMonth.Items.Insert(0, "Month")
    End Sub
    Private Sub bindFrqPU()
        Using objGeoInfos As New GeoInfos
            Me.dlstPU.DataSource = objGeoInfos.getFrequent(Session("user_id").ToString, Session("acct_id").ToString, Session("sub_acct_id").ToString, Session("company").ToString, "P")
            Me.dlstPU.DataBind()
        End Using
        'objGeoInfos.Dispose()
        'objGeoInfos = Nothing
    End Sub

    Private Sub bindFrqDest()
        Using objGeoInfos As New GeoInfos
            Me.dlst.DataSource = objGeoInfos.getFrequent(Session("user_id").ToString, Session("acct_id").ToString, Session("sub_acct_id").ToString, Session("company").ToString, "D")
            Me.dlst.DataBind()
        End Using
        'objGeoInfos.Dispose()
        'objGeoInfos = Nothing
    End Sub

    Private Sub Change_bindFrqPU(ByVal Vip_no As String)
        Using objGeoInfos As New GeoInfos
            Me.dlstPU.DataSource = objGeoInfos.getFrequent(Vip_no, Session("acct_id").ToString, Session("sub_acct_id").ToString, Session("company").ToString, "P")
            dlstPU.DataBind()
        End Using
        'objGeoInfos.Dispose()
        'objGeoInfos = Nothing
    End Sub
    Private Sub Change_bindFrqDest(ByVal Vip_no As String)
        Using objGeoInfos As New GeoInfos
            dlst.DataSource = objGeoInfos.getFrequent(Vip_no, Session("acct_id").ToString, Session("sub_acct_id").ToString, Session("company").ToString, "D")
            dlst.DataBind()
        End Using
        'objGeoInfos.Dispose()
        'objGeoInfos = Nothing
    End Sub

#End Region

#Region "Private Function"

    'Private Function operatorFillData(ByVal ConfNo As String) As OperatorData
    '    Using oper As New Operators
    '        Return oper.FillRides(ConfNo)
    '    End Using
    '    'oper.Dispose()
    '    'oper = Nothing
    'End Function

#End Region

#Region "Private Load_Pu_Airport Sub"

    Private Sub loadStateAirport()
        'onChange="is_fields_changed('p');is_airport('P');update_city_field(this.options[this.selectedIndex].value,'P');
        '	call Set_State(PState,"P")
        'Dim strStateAbbre As String = String.Empty
        Using objGeo As New Business.GeoInfos
            'If strStateAbbre.Length <> 0 And objGeo.isAirportOn(strStateAbbre) Then
            '-- load airports
            Dim AirportDataSet As DataSet = objGeo.getAllAirport("", "", "")
            With Me.ddlPAirport
                If Not AirportDataSet Is Nothing AndAlso AirportDataSet.Tables.Count > 0 Then
                    .DataSource = AirportDataSet
                    .DataTextField = "description"
                    .DataValueField = "code"
                    .DataBind()
                End If

                .Items.Insert(0, New ListItem("-", ""))
                'If Not .Items.FindByValue(strStateAbbre) Is Nothing Then
                '    .Items.FindByValue(strStateAbbre).Selected = True
                'End If
                .SelectedIndex = 0
            End With
            With Me.ddlDAirport
                If Not AirportDataSet Is Nothing AndAlso AirportDataSet.Tables.Count > 0 Then
                    .DataSource = AirportDataSet
                    .DataTextField = "description"
                    .DataValueField = "code"
                    .DataBind()
                End If

                .Items.Insert(0, New ListItem("-", ""))
                'If Not .Items.FindByValue(strStateAbbre) Is Nothing Then
                '    .Items.FindByValue(strStateAbbre).Selected = True
                'End If
                .SelectedIndex = 0
            End With
            'Else
            '-- load states

            '## get state   (1: boro, 2: ot, 3: airports)   (yang)
            Dim StateDataSet As DataSet = objGeo.getAllState("12", "", "")
            With Me.ddlPState
                If Not StateDataSet Is Nothing AndAlso StateDataSet.Tables.Count > 0 Then
                    .DataSource = StateDataSet
                    .DataTextField = "description"
                    .DataValueField = "code"
                    .DataBind()
                End If

                .Items.Insert(0, New ListItem("-", ""))

                If Not .Items.FindByValue("NY") Is Nothing Then
                    .SelectedIndex = -1
                    .Items.FindByValue("NY").Selected = True
                End If
            End With
            With Me.ddlDState
                If Not StateDataSet Is Nothing AndAlso StateDataSet.Tables.Count > 0 Then
                    .DataSource = StateDataSet
                    .DataTextField = "description"
                    .DataValueField = "code"
                    .DataBind()
                End If

                .Items.Insert(0, New ListItem("-", ""))

                If Not .Items.FindByValue("NY") Is Nothing Then
                    .SelectedIndex = -1
                    .Items.FindByValue("NY").Selected = True
                End If
            End With
        End Using
        'End If
        'objGeo.Dispose()
        'objGeo = Nothing
    End Sub

    Private Sub load_airport()
        Using objGeo As New GeoInfos
            Dim da As DataSet
            da = objGeo.getAllAirport("", "", "")
            With da.Tables(0)
                Dim i As Int32
                For i = 0 To .Rows.Count - 1
                    Me.hidairport.Value &= CStr(.Rows(i).Item(1)) & "/"
                    Me.hidairportvalue.Value &= CStr(.Rows(i).Item(0)) & "/"
                Next
            End With
        End Using
        'objGeo.Dispose()
        'objGeo = Nothing
    End Sub

    Private Sub load_state()
        Using objGeo As New GeoInfos
            Dim da1 As DataSet
            da1 = objGeo.getAllState(0, "", "")
            With da1.Tables(0)
                Dim i As Int32
                For i = 0 To .Rows.Count - 1
                    Me.hidstate.Value &= CStr(.Rows(i).Item(1)) & "/"
                    Me.hidstatevalue.Value &= CStr(.Rows(i).Item(0)) & "/"
                Next
            End With
        End Using
    End Sub
    Private Sub load_airline()
        Using objGeo As New GeoInfos
            Dim da2 As DataSet
            da2 = objGeo.getAllAirline("", "")
            With da2.Tables(0)
                Dim i As Int32
                For i = 0 To .Rows.Count - 1
                    Me.hidairline_airport.Value &= CStr(.Rows(i).Item(0)) & "/"
                    Me.hidairline.Value &= CStr(.Rows(i).Item(1)) & "/"
                Next
            End With
        End Using
    End Sub

#End Region

    '#Region "Private Load_Dest_Airport Sub"

    '    Private Sub LoadDestStateAirport()
    '        Dim strStateAbbre As String = String.Empty
    '        Dim objGeo As New Business.GeoInfos
    '        If strStateAbbre.Length <> 0 And objGeo.isAirportOn(strStateAbbre) Then
    '            '-- load airports
    '            With Me.ddlDAirport
    '                .DataSource = objGeo.getAllAirport
    '                .DataTextField = "description"
    '                .DataValueField = "code"
    '                .DataBind()
    '                .Items.Insert(0, New ListItem("-Please select airport-", ""))
    '                'If Not .Items.FindByValue(strStateAbbre) Is Nothing Then
    '                '    .Items.FindByValue(strStateAbbre).Selected = True
    '                'End If
    '                .SelectedIndex = 0
    '            End With
    '            'Else
    '            '-- load states
    '            With Me.ddlDState
    '                .DataSource = objGeo.getAllState
    '                .DataTextField = "state_desc"
    '                .DataValueField = "state_name"
    '                .DataBind()
    '                .Items.Insert(0, New ListItem("-", ""))
    '                'If Not .Items.FindByValue(strStateAbbre) Is Nothing Then
    '                '    .Items.FindByValue(strStateAbbre).Selected = True
    '                'End If
    '                .SelectedIndex = 0
    '            End With
    '        End If
    '        'objGeo.Dispose()
    '        objGeo = Nothing
    '    End Sub

    '#End Region

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click
        infodata()

        'Dim req_date As String
        Dim objoperatordata As OperatorData
        objoperatordata = CType(Session.Item("Operator"), OperatorData)

        Dim tmpAdmin As New Admin
        '--add by eJay 2/4/05 check rush hour---------------------------------------------------
        Dim strReqDate, strReqTime As String
        strReqDate = Common.ShowDateTime(objoperatordata.req_date_time, Common.DateTimeStyle.DateOnly)

        If objoperatordata.Req_ampm = "AM" Then  '--1 am;2 pm
            strReqTime = objoperatordata.Req_hour.ToString & ":" & objoperatordata.Req_min.ToString
        Else
            strReqTime = (Convert.ToInt32(objoperatordata.Req_hour) + 12).ToString & ":" & objoperatordata.Req_min.ToString
        End If

        Dim blnResult As Boolean
        'blnResult = tmpAdmin.RushHourCheck(strReqDate, strReqTime)
        If blnResult = True Then
            '--true for block
            ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage", "<script language=JavaScript>alert('Orders cannot be made online at this time.');</script>")
            Exit Sub
        End If
        '---------------------------------------------------------------------------------------

        'req_date = tmpAdmin.getTimeframe.Tables(0).Rows(0).Item(0).ToString

        'With objoperatordata
        '    .req_date_time = Convert.ToDateTime(Convert.ToString(.req_date_time & " " & .Req_hour & ":" & .Req_min & ":00 " & .Req_ampm))
        '    If DateDiff("n", Now(), .req_date_time) < Convert.ToDouble(req_date) Then
        '        'Me.hidpuairline.Value = .airport_airline
        '        'Me.hiddestairline.Value = .dest_airport_airline
        '        '------------------------change the checkbox whether is checked
        '        Me.checkAirportdisplay("pagetype")
        '        RegisterStartupScript("PopUpMessage", "<script language=JavaScript>alert('Your reservation can not be made online.');</script>")
        '        Exit Sub
        '    End If
        'End With
        '--add by daniel for verify datatime.
        '-- check if date is before current time. 24/2/2007
        If DateDiff(DateInterval.Hour, Convert.ToDateTime(Now()), Convert.ToDateTime(objoperatordata.req_date_time)) < 5 Then
            ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage", "<script language=JavaScript>alert('The request time is within 5 hours of the current time. Please choose another time that is outside the 5-hour window.');</script>")
            'Me.txtPuCity.Text = objoperatordata.pu_city.ToString
            'Me.txtDestCity.Text = objoperatordata.dest_city.ToString
            'Call Me.Set_Show_IsAirport()
            Exit Sub
        End If

        If Session("admin_assistant") Is Nothing Then
            UpdateVipEmail(Session("user_id").ToString)
        Else
            UpdateVipEmail(Session("admin_assistant").ToString)
        End If

        'check_req_date()

        Dim pagetype As Int16
        If Me.ckPAirport.Checked = True Then
            Me.txtcheckpu.Text = "1"
        Else
            Me.txtcheckpu.Text = "0"
        End If
        If Me.ckDAirport.Checked = True Then
            Me.txtcheckdest.Text = "1"
        Else
            Me.txtcheckdest.Text = "0"
        End If
        If Me.txtcheckpu.Text = "0" And Me.txtcheckdest.Text = "0" Then
            pagetype = 0
        ElseIf Me.txtcheckpu.Text = "1" And Me.txtcheckdest.Text = "0" Then
            pagetype = 1
        ElseIf Me.txtcheckpu.Text = "0" And Me.txtcheckdest.Text = "1" Then
            pagetype = 2
        Else
            pagetype = 3
        End If

        Response.Redirect("orderconfirm.aspx?pagetype=" & pagetype & "")
    End Sub

End Class
