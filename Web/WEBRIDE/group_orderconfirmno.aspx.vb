Imports Business

Partial Class group_orderconfirmno
    Inherits System.Web.UI.Page

#Region "Private Sub Pages"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If Not Page.IsPostBack Then
            Dim cno As String
            cno = Request.QueryString("cid")
            Session("cid") = cno

            If Not Request.QueryString("f") Is Nothing Then
                Me.hdnFrom.Value = Request.QueryString("f").Trim

                If Me.hdnFrom.Value = "group" Then  '## 12/4/2007   yang
                    Me.Submit.Attributes.Add("onclick", "javascript:window.location='group_rideinquiry.aspx';")
                Else
                    Me.Submit.Attributes.Add("onclick", "javascript:window.location='group_rideinquiry.aspx';")
                End If
            End If

            If Not Session("cid") Is Nothing Then
                ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage", "<script language=javascript>document.getElementById(""trPrint"").style.display='';</script>")
                LoadInfo(Session("cid").ToString)
            ElseIf Not Session.Item("Operator") Is Nothing Then
                LoadInfo("")
            Else
                Response.Redirect("group_login.aspx")
            End If
        Else
            If Not Session("cid") Is Nothing Then
                ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage", "<script language=javascript>document.getElementById(""trPrint"").style.display='';</script>")
                LoadInfo(Session("cid").ToString)
            ElseIf Not Session.Item("Operator") Is Nothing Then
                LoadInfo("")
            Else
                Response.Redirect("group_login.aspx")
            End If
        End If
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        ClientScript.RegisterStartupScript(GetType(String), "onclick", "<script language=javascript>ReceiptPrint('" & Me.txtShowType.Text & "');</script>")
    End Sub

#End Region

#Region "Private Sub & Functions Parts"

    Private Sub AriseJavaScript(ByVal is_pu_airport As String, ByVal is_dest_airport As String)

        Dim strMessage As String
        strMessage = "<script language=""JavaScript"" type=""text/javascript"">"

        If is_pu_airport = "Y" Then
            strMessage = strMessage & "{document.getElementById('" & Me.tdpuairport.ClientID & "').style.display='';}"
            strMessage = strMessage & "{document.getElementById('" & Me.tdpu.ClientID & "').style.display='none';}"
        Else
            strMessage = strMessage & "{document.getElementById('" & Me.tdpuairport.ClientID & "').style.display='none';}"
            strMessage = strMessage & "{document.getElementById('" & Me.tdpu.ClientID & "').style.display='';}"
        End If
        If is_dest_airport = "Y" Then
            strMessage = strMessage & "{document.getElementById('" & Me.tddestairport.ClientID & "').style.display='';}"
            strMessage = strMessage & "{document.getElementById('" & Me.tddest.ClientID & "').style.display='none';}"
        Else
            strMessage = strMessage & "{document.getElementById('" & Me.tddestairport.ClientID & "').style.display='none';}"
            strMessage = strMessage & "{document.getElementById('" & Me.tddest.ClientID & "').style.display='';}"
        End If

        strMessage = strMessage & "</script>"

        'Response.Write(strMessage)
        ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage2", strMessage)

    End Sub

    Private Sub LoadInfo(ByVal strCno As String)
        Dim objoperatordata As OperatorData
        Dim objOperator As New Operators
        If strCno.Trim.Length > 0 Then
            objoperatordata = objOperator.FillRides(strCno)
        Else
            If Not Session.Item("Operator") Is Nothing Then
                objoperatordata = CType(Session.Item("Operator"), OperatorData)
            Else
                Exit Sub
            End If

        End If

        With objoperatordata
            Call Me.AriseJavaScript(.PuAir, .DestAir)
            Me.lblConfirmationNo.Text = Right(.confirmation_no.ToString, 4)
            If strCno.Trim.Length > 0 Then
                Convert.ToDateTime(.req_date_time)
                Me.lblReqDT.Text = .req_date_time
            Else
                Me.lblReqDT.Text = Month(.req_date_time) & "/" & Day(.req_date_time) & "/" & Year(.req_date_time) & " " & .Req_hour & ":" & .Req_min & " " & .Req_ampm
            End If

            Me.lblFullName.Text = objoperatordata.lname & ", " & objoperatordata.fname
            Me.lblAcct.Text = .account_no
            If Not Session("agent_id") Is Nothing Then
                Dim strMessage As String
                strMessage = "<script language=""JavaScript"" type=""text/javascript"">"
                strMessage = strMessage & "{document.getElementById('trAPhone').style.display='';document.getElementById('APhone').style.display='';}"
                strMessage = strMessage & "{document.getElementById('trAEmail').style.display='';document.getElementById('AEmail').style.display='';document.getElementById('trAName').style.display='';}"
                strMessage = strMessage & "</script>"
                ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage3", strMessage)
                'Using objAgent As New Agent
                '    Dim tmpds As DataSet
                '    tmpds = objAgent.GetAgent(Session("agent_id"))
                '    If tmpds.Tables(0).Rows.Count > 0 Then
                '        With tmpds.Tables(0).Rows.Item(0)
                '            Me.lblAName.Text = .Item("lname").ToString & "," & .Item("fname").ToString
                '            Me.lblAPhone.Text = .Item("contact_phone").ToString & " ext. " & .Item("contact_phone_ext").ToString
                '            Me.lblAEmail.Text = .Item("email").ToString
                '        End With
                '    End If
                'End Using
            End If
            If .pu_phone = "" Then
                Me.lblPhone.Text = ""
            Else
                Me.lblPhone.Text = Common.ShowPhoneNo(.pu_phone) & " Ext." & .pu_phone_ext
            End If
            'Me.lblConPhone.Text = .Auth_Telno
            If Not .Auth_Telno Is Nothing Then
                If Len(.Auth_Telno) = 10 Then
                    Me.lblConPhone.Text = Common.ShowPhoneNo(.Auth_Telno)

                Else
                    Me.lblConPhone.Text = ""
                End If
            End If
            'If .vip_phone = "" Then
            '    Me.lblPhone.Text = ""
            'ElseIf .vip_phone <> "" And .vip_phone.Length >= 10 Then
            '    Me.lblPhone.Text = "(" & Left(.vip_phone, 3) & ")-(" & .vip_phone.Substring(3, 7).ToString & ") Ext." & .dest_phone_ext
            'End If
            'If Not .Auth_Telno Is Nothing Then
            '    Me.lblConPhone.Text = .Auth_Telno
            'Else
            '    Me.lblConPhone.Text = ""
            'End If
            Me.lblEmail.Text = .email_add

            If .payment_type_desc.Trim.Length > 0 Then  '## 12/6/2007   (yang)
                Me.lblPaymentType.Text = .payment_type_desc.Trim
            Else
                Me.lblPaymentType.Text = Session("paytype")
            End If

            If .Car_type_Desc.Trim.Length > 0 Then  '## 12/6/2007   (yang)
                Me.lblCarType.Text = .Car_type_Desc
            Else
                Me.lblCarType.Text = Session("Cartype")
            End If

            If Not .car_no Is Nothing AndAlso .car_no <> "" Then
                Me.lblCarDriver.Text = .car_no
            Else
                Me.lblCarDriver.Text = "N/A"
            End If
            'If Not .dr_no Is Nothing AndAlso .dr_no <> "" Then
            '    Dim objRides As New Rides
            '    Dim tmpds As DataSet
            '    tmpds = objRides.get_driver_name(.dr_no.Trim)
            '    If tmpds.Tables(0).Rows.Count > 0 Then
            '        With tmpds.Tables(0).Rows.Item(0)
            '            Me.lblCarDriver.Text = Me.lblCarDriver.Text & .Item("lname").ToString & " " & .Item("fname").ToString
            '        End With
            '    Else
            '        Me.lblCarDriver.Text = Me.lblCarDriver.Text & "N/A"
            '    End If
            'Else
            '    Me.lblCarDriver.Text = Me.lblCarDriver.Text & "N/A"
            'End If
            Me.lblDirection.Text = .direction
            '--Pickup-----------------------------------------------
            Me.lblPState.Text = Convert.ToString(IIf(.pu_county_desc.Length > 0, .pu_county_desc, .pu_county)).Trim()   '## 11/22/2007  added by yang
            'If .pu_landmark <> "--Please select a landmark--" Then
            '    Me.lblPLndmrk.Text = .pu_landmark
            'End If
            Me.lblPAddress.Text = .pu_st_no & " " & .pu_st_name
            '## add by joey 11/22/2007
            If Msg.IsBoro(.pu_county, False) Then
                Me.lblPTown.Text = ""
            Else
                Me.lblPTown.Text = .pu_city
            End If


            Me.lblPCounty.Text = .pu_county
            Me.lblPArea.Text = .pu_st_no
            Me.lblPPoint.Text = .pu_point
            Me.lblPDirection.Text = .pu_direction                '# added by joey    1/14/2008

            Me.lblPairport.Text = .airport_name
            Me.lblPAirName.Text = .airport_airline
            Me.lblPAirFbo.Text = .airport_terminal
            Me.lblPAirTime.Text = .airport_time
            Me.lblPAirFli.Text = .airport_flight
            Me.lblPuAirpoint.Text = .airport_pu_point
            Me.lblPAirDirection.Text = .pu_direction             '# added by joey    1/14/2008

            '------------------------------------------------------------
            '--add by daniel for show stops 9/5/2007
            '--ination the show 
            Me.trstop1.Visible = False
            Me.trstop2.Visible = False
            Me.trstop3.Visible = False
            Me.trstop4.Visible = False
            Me.trstop5.Visible = False
            Me.trstop6.Visible = False
            Me.trstop7.Visible = False
            Me.trstop8.Visible = False
            Me.trstop9.Visible = False
            Me.trstop10.Visible = False
            '------------------------------------------------------------
            'Try
            '    Dim objRidestops As New Rides
            '    Dim objDataSet As New DataSet
            '    objDataSet = objRidestops.RideInquiry_Stops(.confirmation_no.ToString)
            '    If Not objDataSet Is Nothing Then
            '        If objDataSet.Tables.Count > 0 Then
            '            If objDataSet.Tables(0).Rows.Count > 0 Then
            '                Me.lblstops.Text = "YES"
            '                Dim iCount As Integer
            '                For iCount = 1 To 10
            '                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("is_airport_" & iCount)) Or Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("state_airport_" & iCount)) Then
            '                        If Convert.ToString(objDataSet.Tables(0).Rows(0).Item("is_airport_" & iCount)) <> "" Or Convert.ToString(objDataSet.Tables(0).Rows(0).Item("state_airport_" & iCount)) <> "" Then
            '                            If Convert.ToString(objDataSet.Tables(0).Rows(0).Item("is_airport_" & iCount)) = "Y" Then
            '                                ShowControls(iCount, True, Check_DBNULL(objDataSet.Tables(0).Rows(0).Item("state_airport_" & iCount)) & " " & Check_DBNULL(objDataSet.Tables(0).Rows(0).Item("state_airport_" & iCount)))
            '                            ElseIf Convert.ToString(objDataSet.Tables(0).Rows(0).Item("is_airport_" & iCount)) = "N" Then
            '                                ShowControls(iCount, True, Check_DBNULL(objDataSet.Tables(0).Rows(0).Item("st_no_flight_" & iCount)) & " " & Check_DBNULL(objDataSet.Tables(0).Rows(0).Item("st_name_airp_from_" & iCount)) & " " & Check_DBNULL(objDataSet.Tables(0).Rows(0).Item("city_airline_" & iCount)) & " " & Check_DBNULL(objDataSet.Tables(0).Rows(0).Item("county_" & iCount)) & " " & Check_DBNULL(objDataSet.Tables(0).Rows(0).Item("zip_" & iCount)) & " " & Check_DBNULL(objDataSet.Tables(0).Rows(0).Item("landmark_terminal_" & iCount)))
            '                            Else
            '                                ShowControls(iCount, True, Check_DBNULL(objDataSet.Tables(0).Rows(0).Item("st_no_flight_" & iCount)) & " " & Check_DBNULL(objDataSet.Tables(0).Rows(0).Item("st_name_airp_from_" & iCount)) & " " & Check_DBNULL(objDataSet.Tables(0).Rows(0).Item("city_airline_" & iCount)) & " " & Check_DBNULL(objDataSet.Tables(0).Rows(0).Item("county_" & iCount)) & " " & Check_DBNULL(objDataSet.Tables(0).Rows(0).Item("zip_" & iCount)) & " " & Check_DBNULL(objDataSet.Tables(0).Rows(0).Item("landmark_terminal_" & iCount)))
            '                            End If
            '                        Else
            '                            ShowControls(iCount, False, "")
            '                        End If
            '                    Else
            '                        ShowControls(iCount, False, "")
            '                    End If
            '                Next
            '            Else
            '                Me.lblstops.Text = "NO"
            '            End If
            '        Else
            '            Me.lblstops.Text = "NO"
            '        End If
            '    Else
            '        Me.lblstops.Text = "NO"
            '    End If
            'Catch ex As Exception
            '    Me.lblstops.Text = "NO"
            'End Try

            If Me.trstop1.Visible = False AndAlso Me.trstop2.Visible = False AndAlso Me.trstop3.Visible = False AndAlso Me.trstop4.Visible = False _
                    AndAlso Me.trstop5.Visible = False AndAlso Me.trstop6.Visible = False AndAlso Me.trstop7.Visible = False AndAlso Me.trstop8.Visible = False AndAlso Me.trstop9.Visible = False AndAlso Me.trstop10.Visible = False Then
                Me.tdstops.Visible = False
            Else
                Me.tdstops.Visible = True
            End If
            '--Destination-----------------------------------------------
            Me.lblDstate.Text = Convert.ToString(IIf(.dest_county_desc.Length > 0, .dest_county_desc, .dest_county)).Trim() '## 11/22/2007  added by yang
            'If .dest_landmark <> "--Please select a landmark--" Then
            '    Me.lblDLndmrk.Text = .dest_landmark
            'End If
            Me.lblDAddress.Text = .dest_st_no & " " & .dest_st_name

            '## add by joey 11/22/2007
            If Msg.IsBoro(.dest_county, False) Then
                Me.lblDTown.Text = ""
            Else
                Me.lblDTown.Text = .dest_city
            End If


            Me.lblDCounty.Text = .dest_county
            Me.lblDArea.Text = .dest_st_no
            Me.lblDPoint.Text = .dest_x_st
            Me.lblDDirection.Text = .dest_direction          '# added by joey    1/14/2008

            Me.lblDairport.Text = .dest_aiport_name
            Me.lblDairname.Text = .dest_airport_airline
            Me.lblDAirFbo.Text = .dest_airport_terminal
            Me.lblDestAirFlight.Text = .dest_airport_flight
            Me.lblDestAirDepartingCity.Text = .dest_airport_from
            Me.lblDairtime.Text = Common.ShowDateTime(.dest_airport_departureTime, Common.DateTimeStyle.TimeOnly)
            Me.lblDAirDirection.Text = .dest_direction      '# added by joey    1/14/2008
            '-------------------------------------------------------
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
            Try
                If Not .price_est Is Nothing Then
                    'Me.EPrice.Text = CStr(objEPrice)
                    Me.lblEstPrice.Text = Common.ShowPrice(.price_est, Common.PricePrefix.dollar)
                End If
            Catch ex As Exception
                Me.lblEstPrice.Text = "N/A"
            End Try

        End With

        objoperatordata = Nothing
        Session.Item("Operator") = Nothing
        'Session("cno") = Nothing
        'Session("rcno") = Nothing

        Session("voucher_no") = Nothing
        Session("payment_type") = Nothing
        Session("card_type") = Nothing
        Session("card_no") = Nothing
        Session("card_exp_date") = Nothing
        Session("card_name") = Nothing
        Session("pagetype") = Nothing
        Session("tips_perc") = Nothing
        Session("discount_cert_perc") = Nothing

        Session("stop_1") = Nothing
        Session("stop_2") = Nothing
        Session("stop_3") = Nothing
        Session("IsAirport1") = Nothing
        Session("IsAirport2") = Nothing
        Session("IsAirport3") = Nothing

    End Sub

#End Region

#Region "Public Check_DBNull Function"

    '-------------------------------------------------------------------
    '--Function:Check_DBNULL
    '--Description:Check the value 
    '--Input:Value
    '--Output:Nothing for DBNULL
    '--11/4/04 - Created (eJay)
    '-------------------------------------------------------------------
    Private Function Check_DBNULL(ByVal Value As Object) As String

        If IsDBNull(Value) = True Then
            Return Nothing
        Else
            Return Convert.ToString(Value).Trim()
        End If

    End Function

#End Region

#Region "Public Check_DBNull Function"

    Private Sub ShowControls(ByVal Control_id As Integer, ByVal show As Boolean, ByVal text As String)
        Select Case Control_id
            Case 1
                If show = True Then
                    Me.trstop1.Visible = True
                    Me.lblstop1.Text = text
                Else
                    Me.trstop1.Visible = False
                End If
            Case 2
                If show = True Then
                    Me.trstop2.Visible = True
                    Me.lblstop2.Text = text
                Else
                    Me.trstop2.Visible = False
                End If
            Case 3
                If show = True Then
                    Me.trstop3.Visible = True
                    Me.lblstop3.Text = text
                Else
                    Me.trstop3.Visible = False
                End If
            Case 4
                If show = True Then
                    Me.trstop4.Visible = True
                    Me.lblstop4.Text = text
                Else
                    Me.trstop4.Visible = False
                End If
            Case 5
                If show = True Then
                    Me.trstop5.Visible = True
                    Me.lblstop5.Text = text
                Else
                    Me.trstop5.Visible = False
                End If
            Case 6
                If show = True Then
                    Me.trstop6.Visible = True
                    Me.lblstop6.Text = text
                Else
                    Me.trstop6.Visible = False
                End If
            Case 7
                If show = True Then
                    Me.trstop7.Visible = True
                    Me.lblstop7.Text = text
                Else
                    Me.trstop7.Visible = False
                End If
            Case 8
                If show = True Then
                    Me.trstop8.Visible = True
                    Me.lblstop8.Text = text
                Else
                    Me.trstop8.Visible = False
                End If
            Case 9
                If show = True Then
                    Me.trstop9.Visible = True
                    Me.lblstop9.Text = text
                Else
                    Me.trstop9.Visible = False
                End If
            Case 10
                If show = True Then
                    Me.trstop10.Visible = True
                    Me.lblstop10.Text = text
                Else
                    Me.trstop10.Visible = False
                End If
            Case Else
                '--do nothing
        End Select

    End Sub

#End Region

End Class
