Imports Business
Imports System.Data

Partial Class quickorderconfirm
    Inherits System.Web.UI.Page


#Region "Protected Sub"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.btnBack.Attributes.Add("onclick", "javascript:document.getElementById('" & Me.trButton.ClientID & "').style.visibility='hidden';")

        If Not Page.IsPostBack Then

            '## 1/24/2008   Add Verify Credit Card  (Joey)
            Pricing.RegisterValidateCCScript(Me, Me.Submit, Me.trButton, Me.SubmitHide, 1)
            'Dim VerifyAmount As Double = Val(System.Web.Configuration.WebConfigurationManager.AppSettings("CCVerifyAmount"))
            'If VerifyAmount >= 0 AndAlso Not MySession.OperatorOrder Is Nothing AndAlso MySession.OperatorOrder.card_no.Trim.Length > 0 Then
            '    Me.Submit.Attributes.Add("onclick", "javascript:VerifyCC(document.getElementById('" & Me.trButton.ClientID & "'));return false;")
            '    Me.ClientScript.RegisterStartupScript(GetType(String), "CCVerify", "<script type='text/javascript'>function VerifyCreditCardGoingForward(){document.getElementById('" & Me.SubmitHide.ClientID & "').click();}</script>")
            'Else
            '    Me.Submit.Attributes.Add("onclick", "javascript:document.getElementById('" & Me.trButton.ClientID & "').style.visibility='hidden';")
            'End If
            'Me.ClientScript.RegisterStartupScript(GetType(String), "ShowSubmitButton", "<script type='text/javascript'>function ShowSubmitButton(show){document.getElementById('" & Me.trButton.ClientID & "').style.visibility=show?'':'hidden';}</script>")

            Dim pagetype As Int16
            pagetype = Convert.ToInt16(Request.QueryString("pagetype"))
            Dim stop1 As String
            Dim stop2 As String
            Dim stop3 As String
            stop1 = Convert.ToString(Session("stop_1"))
            stop2 = Convert.ToString(Session("stop_2"))
            stop3 = Convert.ToString(Session("stop_3"))


            Session("pagetype") = pagetype
            LoadInfo()
            'getEstimationPrice()
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
        Using objuser As New Users
            OperatorInfo()
            'CleanOperInfo_byPagetype() '## 12/6/2007   disabled by yang
            Get_Airline_Code()

            MySession.UserID = objuser.GetQuickVipNo

            If MySession.UserID.Trim.Length > 0 Then
                MySession.OperatorOrder.vip_no = MySession.UserID
                insertOperatorInfo()
            End If
        End Using
    End Sub
    Protected Sub SubmitHide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubmitHide.Click
        Me.Submit_Click(Nothing, Nothing)
    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBack.Click
        If Session("agent_id") Is Nothing Then
            Response.Redirect("quickorderform.aspx?event=isback")
        Else
            Response.Redirect("agent_order_1.aspx")
        End If
    End Sub

#End Region

#Region "Private Sub"

    Private Sub LoadInfo()

        Dim objoperatordata As OperatorData
        objoperatordata = CType(Session.Item("Operator"), OperatorData)

        With objoperatordata

            Me.lblReqDT.Text = Month(.req_date_time) & "/" & Day(.req_date_time) & "/" & Year(.req_date_time) & " " & .Req_hour & ":" & .Req_min & " " & .Req_ampm & " (RESERVATION)"

            Me.lblFullName.Text = objoperatordata.lname & ", " & objoperatordata.fname

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

            '## 1/11/2008   (yang)
            Me.lblEstPrice.Text = Common.ShowPrice(.price_est, Common.PricePrefix.null)

            If .Car_type_Desc.Trim.Length > 0 Then
                Me.lblCarType.Text = .Car_type_Desc.Trim
            Else
                Me.lblCarType.Text = Session("cartype")
            End If

            '============Pickup=============================
            'If .isairport1 = "Y" Then
            Call Me.AriseJavaScript(.PuAir, .DestAir)

            Me.lblState.Text = Convert.ToString(IIf(.pu_county_desc.Length > 0, .pu_county_desc, .pu_county)).Trim()

            If Msg.IsBoro(.pu_county, False) Then
                Me.lblPuCity.Text = ""
            Else
                Me.lblPuCity.Text = .pu_city
            End If

            Me.lblPBlogNo.Text = .pu_st_no
            Me.lblPStName.Text = .pu_st_name
            Me.lblPuPoint.Text = .pu_point
            Me.lblPDirection.Text = .pu_direction  'added by lily 12/10/2007

            Me.lblPairport.Text = .airport_name
            Me.lblPAirName.Text = .airport_airline
            Me.lblPAirFli.Text = .airport_flight
            Me.lblAirPu.Text = .airport_pu_point
            Me.lblPairfbo.Text = .airport_terminal
            Me.lblPairtime.Text = .airport_time
            Me.lblPuAirDepartingCity.Text = .airport_from
            Me.lblPAirDirection.Text = .pu_direction   'added by lily 12/10/2007
            '===============================================
            '==================Destination==================
            Me.lblDestState.Text = Convert.ToString(IIf(.dest_county_desc.Length > 0, .dest_county_desc, .dest_county)).Trim()    '## 11/22/2007  added by yang

            If Msg.IsBoro(.dest_county, False) Then
                Me.lblDestCity.Text = ""
            Else
                Me.lblDestCity.Text = .dest_city
            End If

            Me.lblDestBlogno.Text = .dest_st_no
            Me.lblDStName.Text = .dest_st_name
            Me.lblDstrross.Text = .dest_x_st
            Me.lblDDirection.Text = .dest_direction  'added by lily 12/10/2007

            Me.lblDairport.Text = .dest_aiport_name
            Me.lblDairname.Text = .dest_airport_airline
            Me.lblDestAirFlight.Text = .dest_airport_flight
            Me.lblDAirFbo.Text = .dest_airport_terminal
            Me.lblDAirDirection.Text = .dest_direction  'added by lily 12/10/2007

            Dim arrComID(6) As String
            arrComID(0) = Trim(.Comp_id_1)
            arrComID(1) = Trim(.Comp_id_2)
            arrComID(2) = Trim(.Comp_id_3)
            arrComID(3) = Trim(.Comp_id_4)
            arrComID(4) = Trim(.Comp_id_5)
            arrComID(5) = Trim(.Comp_id_6)

        End With



    End Sub


    Private Sub OperatorInfo()

        Dim objoperatordata As OperatorData
        objoperatordata = CType(Session.Item("Operator"), OperatorData)

        With objoperatordata
            .account_no = Convert.ToString(Session("acct_id"))
            .status_flag = "R"

            .priority = Convert.ToString(Session("priority"))
            .company = Convert.ToString(Session("company"))
            .original_company = Convert.ToString(Session("company"))

            .sub_account_no = Convert.ToString(Session("sub_acct_id"))
            .vip_no = Convert.ToString(Session("user_id"))

            If Len(.card_exp_date) = 3 Then
                .card_exp_date = "0" & .card_exp_date
            End If
            .stops = "N"

            check_pu_date_time()
        End With

    End Sub


    Private Sub insertOperatorInfo()
        'the insert operatorinfo
        If Session.Item("Operator") Is Nothing Then
            Exit Sub
        End If

        Dim objoperatordata As OperatorData
        objoperatordata = CType(Session.Item("Operator"), OperatorData)

        With objoperatordata

            If objoperatordata.confirmation_no Is Nothing OrElse objoperatordata.confirmation_no.Trim.Length = 0 Then
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
                Using oper As New Operators
                    Dim intresult As Int16 = 0

                    '## 2/13/2008   Check Auth No & Refer ID for Credit Card Order  (yang)
                    If Pricing.ValidateCreditCardOrder(objoperatordata) Then
                        intresult = oper.Insert_Operator_Info(objoperatordata, MySession.AcctID, "", "")
                    End If

                    If intresult = 1 Then
                        send_mail()                                      'added bu lily 12/07/2007
                        Response.Redirect("quickorderconfirmno.aspx")
                    End If
                End Using
            End If
        End With
    End Sub


    Private Sub check_pu_date_time()
        Using oper As New Operators
            Dim objoperatordata As OperatorData
            objoperatordata = CType(Session.Item("Operator"), OperatorData)
            With objoperatordata
                .pu_date_time = oper.calc_pu_date_time(.req_date_time, .pu_county, .pu_city)
            End With

        End Using

    End Sub

    'changed by lily 12/07/2007
    Private Sub send_mail()
        Dim objoperatordata As OperatorData
        objoperatordata = CType(Session.Item("Operator"), OperatorData)

        With objoperatordata

            Dim strBody As String = ""
            Dim title As String
            Dim strEnd As String = ""
            Dim strBegin As String = ""
            Dim HTML_HEADER, HTML_FOOTER As String
            Dim TD_LABEL As String
            Dim FONT_LABEL, FONT_TEXT, FONT_TERMS As String

            TD_LABEL = "<td bgcolor=""lightgrey"">"
            FONT_LABEL = "<font face=""arial"" size=""2""><b>"
            FONT_TEXT = "<font face=""arial"" size=""2"">"
            FONT_TERMS = "<font face=""arial"" size=""1"">"

            'title = "Your request of confirm#: " & .confirmation_no & "/" & Session("user_name").ToString & " (Please do not reply to this email)"
            title = "APEX Confirmation#: " & .confirmation_no & "/" & MySession.UserName & " (Please do not reply to this email)"

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


            Dim strReturn As String
            strReturn = Business.Mail.SendEmail("", strMail, title, strBody, True)
            'If strReturn = "Success" Then
            '    'do nothing
            'Else
            '    '--do nothing
            'End If

        End With

    End Sub

    Private Sub Get_Airline_Code()
        Dim oper As New Operators
        Dim objoperatordata As OperatorData
        objoperatordata = CType(Session.Item("Operator"), OperatorData)
        With objoperatordata
            .pu_airport_airline_code = oper.Get_Airline_Code(.airport_airline)
            .dest_aiprot_airline_code = oper.Get_Airline_Code(.dest_airport_airline)
        End With
    End Sub

#End Region

#Region "Private Function"

    'Private Function loadUserInfo() As UserData
    '    Dim objGetUser As New Business.Users
    '    Return objGetUser.getUserInfo(Session("user_id").ToString, Session("acct_id").ToString, Session("sub_acct_id").ToString, Session("company"))
    '    objGetUser = Nothing
    'End Function

#End Region

#Region "Private sub and Function"

    Private Sub AriseJavaScript(ByVal is_pu_airport As String, ByVal is_dest_airport As String)

        Dim strMessage As String
        strMessage = "<script language=""JavaScript"" type=""text/javascript"">"

        If is_pu_airport = "Y" Then
            Me.tdpu.Style.Add("display", "none")
            Me.tdpuairport.Style.Add("display", "")
            'Me.lblAirpuDirection.Text = .pu_direction
        Else
            Me.tdpu.Style.Add("display", "")
            Me.tdpuairport.Style.Add("display", "none")
            ' Me.lblpuDirection.Text = .pu_direction
        End If
        If is_dest_airport = "Y" Then
            Me.tddest.Style.Add("display", "none")
            Me.tddestairport.Style.Add("display", "")
        Else
            Me.tddest.Style.Add("display", "")
            Me.tddestairport.Style.Add("display", "none")
        End If

        strMessage = strMessage & "</script>"

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
