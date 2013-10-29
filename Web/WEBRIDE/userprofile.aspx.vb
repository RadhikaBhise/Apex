Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System
Imports Business

Partial Class webride_userprofile
    Inherits System.Web.UI.Page

#Region " Window Controls Event"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        Call Me.Load_JavaScript()

        If Not Page.IsPostBack Then
            Dim errmsg As String
            errmsg = Request.QueryString("msg")

            Select Case errmsg
                Case "4003"
                    Me.lblErr.Text = Err.ErrorDisplay(4003)
                    Call Load_Default()
                Case Else
                    Call Load_Default()
            End Select
        End If

    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click
        Dim objVIP As New Users
        Dim objVIPData As New UserData

        With objVIPData
            .user_id = MySession.UserID
            .acct_id = MySession.AcctID
            .sub_acct_id = MySession.SubAcctID
            .Company = MySession.Company

            .OriPWD = Me.password0.Text.Trim()
            If Me.password1.Text.Trim = "" Then
                .PinNo = Me.password0.Text.Trim()
            Else
                .PinNo = Me.password1.Text.Trim()
            End If

            .fname = Me.fname.Text.Trim()
            .lname = Me.lname.Text.Trim()
            .st_no = Me.stno.Text.Trim()
            .st_name = Me.stname.Text.Trim()
            .city = Me.city.Text.Trim()
            .state = Me.state.Text.Trim()
            .zip_code = Me.zipcode.Text.Trim()
            .email = Me.email.Text.Trim()
            .office_phone = Me.officephone.Text.Trim()
            .office_phone_ext = Me.officephoneext.Text.Trim()

            .CCNo = Me.hidcardno.Value.Trim()
            .CCName = Me.txtCardName.Text.Trim()
            Dim strCCExp As String
            If .CCNo <> "" Then
                .CCType = Me.ddlCardType.SelectedValue

                If Me.ddlExpMonth.SelectedIndex > 0 And Me.ddlExpYear.SelectedIndex > 0 Then
                    If Me.ddlExpMonth.SelectedIndex < 10 Then
                        strCCExp = "0" & Me.ddlExpMonth.SelectedIndex & Me.ddlExpYear.SelectedValue
                    Else
                        strCCExp = Me.ddlExpMonth.SelectedIndex & Me.ddlExpYear.SelectedValue
                    End If
                Else
                    strCCExp = ""
                End If
                .CCExp = strCCExp
            Else
                .CCType = ""
                .CCExp = ""

            End If

            .fax = Me.txtFax.Text.Trim()
            .cell_phone = Me.txtCellPhone.Text.Trim()
            .home_phone = Me.txtHomePage.Text.Trim()
            .pager_no = Me.txtPager.Text.Trim()
            .office_phone_area = Me.txtPhone2.Text.Trim()
            .office_phone_area_ext = Me.txtphone2_ext.Text.Trim()

        End With

        'If Me.hidclass_one_club.Value = "N" And objVIPData.class_one_club = "Y" Then
        '    '--send email
        '    Dim strhtmltableleft As String = "<table cellpadding=""0"" cellspacing=""0"" border=""0"">"
        '    Dim strhtmltableright As String = "</table>"
        '    Dim strhtmltrleft As String = "<tr>"
        '    Dim strhtmltrright As String = "</tr>"
        '    Dim strhtmltdleft As String = "<td style=""width: 300px;"">"
        '    Dim strhtmltdright As String = "</td>"

        '    Dim strBody As String
        '    Dim strTitle As String
        '    strTitle = System.Web.Configuration.WebConfigurationManager.AppSettings("company_name") & ": Update Passenger Profile Completed"

        '    strBody = "" & strhtmltableleft

        '    'strBody = strBody & strhtmltrleft & strhtmltdleft & "VIP Number: " & strhtmltdright & strhtmltdleft & Convert.ToString(Session("user_id")) & strhtmltdleft & "<br>"
        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "First Name: " & strhtmltdright & strhtmltdleft & objVIPData.fname.ToString & strhtmltdright & strhtmltrright
        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "Last Name: " & strhtmltdright & strhtmltdleft & objVIPData.lname.ToString & strhtmltdright & strhtmltrright
        '    'strBody = strBody & strhtmltrleft & strhtmltdleft & "Company Name: " & strhtmltdright & strhtmltdleft & objVIPData.Company.ToString & strhtmltdright & strhtmltrright
        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "Company Name: " & strhtmltdright & strhtmltdleft & "" & strhtmltdright & strhtmltrright
        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "Acct ID: " & strhtmltdright & strhtmltdleft & objVIPData.acct_id.ToString & strhtmltdright & strhtmltrright
        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "Username: " & strhtmltdright & strhtmltdleft & Convert.ToString(Session("username")) & strhtmltdright & strhtmltrright
        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "Password: " & strhtmltdright & strhtmltdleft & objVIPData.PinNo.ToString & strhtmltdright & strhtmltrright

        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "Street No: " & strhtmltdright & strhtmltdleft & objVIPData.st_no.ToString & strhtmltdright & strhtmltrright
        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "Street Name: " & strhtmltdright & strhtmltdleft & objVIPData.st_name.ToString & strhtmltdright & strhtmltrright
        '    'strBody = strBody & strhtmltrleft & strhtmltdleft & "Street add2: " & strhtmltdright & strhtmltdleft & objVIPData.aux_street_add.ToString & strhtmltdright & strhtmltrright
        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "City: " & strhtmltdright & strhtmltdleft & objVIPData.city.ToString & strhtmltdright & strhtmltrright
        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "State: " & strhtmltdright & strhtmltdleft & objVIPData.state.ToString & strhtmltdright & strhtmltrright
        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "Zip: " & strhtmltdright & strhtmltdleft & objVIPData.zip_code.ToString & strhtmltdright & strhtmltrright
        '    'strBody = strBody & strhtmltrleft & strhtmltdleft & "Country: " & strhtmltdright & strhtmltdleft & objVIPData.country.ToString & strhtmltdright & strhtmltrright
        '    'strBody = strBody & strhtmltrleft & strhtmltdleft & "Contact: " & strhtmltdright & strhtmltdleft & objVIPData.contact.ToString & strhtmltdright & strhtmltrright
        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "Phone: " & strhtmltdright & strhtmltdleft & objVIPData.office_phone.ToString & strhtmltdright & strhtmltrright
        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "Phone Ext: " & strhtmltdright & strhtmltdleft & objVIPData.office_phone_ext.ToString & strhtmltdleft & strhtmltdright & strhtmltrright
        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "Cell: " & strhtmltdright & strhtmltdleft & objVIPData.cell_phone.ToString & strhtmltdright & strhtmltrright
        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "Home: " & strhtmltdright & strhtmltdleft & Me.txtHomePage.Text.Trim() & strhtmltdright & strhtmltrright
        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "Pager: " & strhtmltdright & strhtmltdleft & Me.txtPager.Text.Trim() & strhtmltdright & strhtmltrright
        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "Fax #: " & strhtmltdright & strhtmltdleft & objVIPData.fax.ToString & strhtmltdright & strhtmltrright
        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "Email: " & strhtmltdright & strhtmltdleft & objVIPData.email.ToString & strhtmltdright & strhtmltrright
        '    strBody = strBody & strhtmltrleft & strhtmltdleft & "Freq Rider Program: " & strhtmltdright & strhtmltdleft & objVIPData.class_one_club & strhtmltdright & strhtmltrright & strhtmltableright

        '    Dim mto(,) As String
        '    Dim mcc(,) As String
        '    Dim mbcc(,) As String
        '    Dim matt() As String
        '    Dim tTo() As String
        '    Dim tBcc() As String
        '    Dim strReturn As String
        '    Dim y As Integer
        '    Try
        '        'Dim strto As String = "laura@mtclimousine.com;laura@mtclimousine.com"
        '        'Dim strto As String = "daniel.chen@surreytechnology.com;daniel.chen@surreytechnology.com"
        '        Dim strto As String = System.Configuration.ConfigurationManager.AppSettings("TOName") & ";" & System.Configuration.ConfigurationManager.AppSettings("TOName")
        '        tTo = Split(strto, ";")
        '        ReDim mto(2, UBound(tTo))

        '        For y = 0 To UBound(tTo)
        '            mto(0, y) = tTo(0)
        '            mto(1, y) = tTo(0)
        '        Next
        '        Dim strBcc As String = System.Configuration.ConfigurationManager.AppSettings("NewUserBCCName") & ";" & System.Configuration.ConfigurationManager.AppSettings("NewUserBCCName")
        '        tBcc = Split(strBcc, ";")
        '        ReDim mbcc(2, UBound(tBcc))

        '        For y = 0 To UBound(tBcc)
        '            mbcc(0, y) = tBcc(0)
        '            mbcc(1, y) = tBcc(0)
        '        Next
        '        strReturn = MTC.Business.Mail.SendEmail("", mto, mcc, mbcc, matt, strBody, strTitle, True)
        '        'If strReturn = "Success" Then
        '        '    Response.Redirect("Home.aspx?msg=Success", True)
        '        'Else
        '        '    Me.lblErr.Text = Me.lblErr.Text.Trim() & " But it has some err to send you the email!"
        '        'End If
        '    Catch ex As Exception
        '        'Throw New Exception(ex.Message)
        '    End Try

        'End If
        Dim iResult As Int32

        If Me.trAddress.Visible Then
            '## 12/6/2007   update addition profile address
            Dim addr2 As New OperatorData
            addr2.pu_county = Me.txtState2.Text
            addr2.pu_city = Me.txtCity2.Text
            addr2.pu_st_name = Me.txtStrName2.Text
            addr2.pu_st_no = Me.txtStrNo2.Text
            addr2.pu_zip = Me.txtZip2.Text
            objVIP.AddNewAddewss(MySession.UserID, addr2)
        End If
        iResult = objVIP.VIPUserUpdate(objVIPData)


        objVIPData = Nothing
        objVIP = Nothing

        If iResult = 1 Then
            Response.Redirect("userprofile.aspx?msg=4003", True)
        Else
            Me.lblErr.Text = Err.ErrorDisplay(iResult)
            If iResult = 4000 Then
                '--do nothing
            End If
        End If

    End Sub

    Protected Sub SubmitHide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubmitHide.Click
        Me.btnSubmit_Click(Nothing, Nothing)
    End Sub

    Protected Sub btnReset_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnReset.ServerClick
        Call Load_Default()
        Me.lblErr.Text = ""
    End Sub

#End Region

#Region " Private Sub"

    Private Sub SetTextBoxValue(ByVal Page As Control, ByVal TextBoxValue As String)
        For Each ctl As Control In Page.Controls
            If TypeOf ctl Is TextBox Then
                CType(ctl, TextBox).Text = TextBoxValue
            Else
                If ctl.Controls.Count > 0 Then
                    SetTextBoxValue(ctl, TextBoxValue)
                End If
            End If
        Next
    End Sub
    '-----------------------------------------------------------
    '--Sub:Load_default
    '--Description:Load default value when Page Load or Reload
    '--Input:
    '--Output:
    '-- 10/29/04 - Created (eJay)
    '-----------------------------------------------------------
    Private Sub Load_Default()

        Me.ddlCardType.Items.Clear()
        Me.ddlExpMonth.Items.Clear()
        Me.ddlExpYear.Items.Clear()

        'Get User Info
        Dim objVIP As New Users
        Dim objVIPData As UserData

        objVIPData = objVIP.VIPUserGet(MySession.UserID, MySession.AcctID, MySession.SubAcctID, MySession.Company)
        'objVIP.Dispose()
        objVIP = Nothing

        With objVIPData

            Me.lblUserID.Text = MySession.UserID
            Me.lblUserName.Text = MySession.UserName
            Me.fname.Text = .fname
            Me.lname.Text = .lname
            Me.stno.Text = .st_no
            Me.stname.Text = .st_name
            Me.city.Text = .city
            Me.state.Text = .state
            Me.zipcode.Text = .zip_code
            Me.email.Text = .email
            '--modify by daniel 26/11/06
            Me.txtvcode.Text = .CC_V_Code
            'Me.txtsecvcode.Text = objVIPData.CC_V_Code2

            If Not .CCNo Is Nothing Then
                Dim j As Int32
                For j = 0 To .CCNo.Length - 4
                    Me.lblCardNo.Text = Me.lblCardNo.Text & "*"
                Next
                Me.lblCardNo.Text = Me.lblCardNo.Text & Right(.CCNo, 4)
                Me.hidcardno.Value = .CCNo
            Else
                Me.lblCardNo.Text = ""
            End If

            If Not objVIPData.office_phone Is Nothing And objVIPData.office_phone <> "" Then
                Me.officephone.Text = objVIPData.office_phone
            Else
                Me.officephone.Text = ""
            End If

            Me.officephoneext.Text = objVIPData.office_phone_ext
            Me.txtCellPhone.Text = .cell_phone
            Me.txtCardName.Text = objVIPData.CCName
            'Me.txtsecCardName.Text = objVIPData.CCName1

            Me.txtPhone2.Text = .office_phone_area
            Me.txtphone2_ext.Text = .office_phone_area_ext
            Me.txtHomePage.Text = .home_phone
            Me.txtPager.Text = .pager_no
            Me.txtFax.Text = .fax

        End With

        '--1.Card Type

        Dim objCard As New Card
        Dim tmpDS As DataSet

        tmpDS = objCard.getAllCardType

        Me.ddlCardType.DataSource = tmpDS
        'Me.ddlseccartype.DataSource = tmpDS
        With Me.ddlCardType
            .DataTextField = "card_type_desc"
            .DataValueField = "card_type_id"
            .DataBind()

            .Items.Insert(0, New ListItem("Credit Card Type", ""))

            If objVIPData.CCType Is Nothing Or objVIPData.CCType = "" Or .Items.FindByValue(objVIPData.CCType) Is Nothing Then
                '--do nothing
            Else
                '## 1/25/2008   Modified by yang
                '.Items.FindByValue(objVIPData.CCType).Selected = True
                Common.ShowDropDownValue(Me.ddlCardType, objVIPData.CCType, False)
            End If

        End With
        'objCard.Dispose()
        objCard = Nothing

        '--2.YEAR
        Dim i As Int32
        Me.ddlExpYear.Items.Add("Year")
        'ddlYear1.Items.Add("Year")
        For i = 0 To 10
            Dim iYear As Int32
            iYear = Convert.ToInt32(Right(Now().Year.ToString, 2))
            iYear = iYear + i
            If iYear >= 10 Then
                Me.ddlExpYear.Items.Add(iYear.ToString)
            Else
                Me.ddlExpYear.Items.Add("0" & iYear.ToString)
            End If
        Next

        '--Year
        If objVIPData.CCYear Is Nothing Or objVIPData.CCYear = "" Or Me.ddlCardType.SelectedIndex = 0 Then
            '--do nothing
        Else
            Dim intYear As Int16
            If Convert.ToInt16(objVIPData.CCYear) > 50 Then
                intYear = Convert.ToInt16("19" & objVIPData.CCYear)
            Else
                intYear = Convert.ToInt16("20" & objVIPData.CCYear)
            End If

            If intYear >= Now.Year Then
                '## 1/25/2008   Modified by yang
                'ddlExpYear.Items.FindByValue(objVIPData.CCYear).Selected = True
                Common.ShowDropDownValue(Me.ddlExpYear, objVIPData.CCYear, True)
            Else
                '--do nothing
            End If
        End If

        '--Month
        Me.ddlExpMonth.Items.Add("Month")
        For i = 1 To 12
            Me.ddlExpMonth.Items.Add(New ListItem(MonthName(i, True), Convert.ToString(i).PadLeft(2, "0")))
        Next

        If objVIPData.CCMonth Is Nothing Or objVIPData.CCMonth = "" Or Me.ddlCardType.SelectedIndex = 0 Then
            '--do nothing
        Else
            '## 1/25/2008   Modified by yang
            'Me.ddlExpMonth.Items.FindByValue(Convert.ToString(Convert.ToInt16(objVIPData.CCMonth))).Selected = True
            Common.ShowDropDownValue(Me.ddlExpMonth, objVIPData.CCMonth, True)
        End If
        objVIPData = Nothing

        '## added by joey   12/06/2007
        Dim ds As DataSet
        Using objUser As New Users
            ds = objUser.getaddressbyvip()
            If Not ds Is Nothing And ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.trAddress.Visible = True
                    Me.lnkAddress.Visible = False
                    'Me.grdAddress.DataSource = ds
                    'Me.grdAddress.DataBind()

                    With ds.Tables(0).Rows(0)
                        Me.txtState2.Text = Convert.ToString(.Item("state")).Trim
                        Me.txtCity2.Text = Convert.ToString(.Item("city")).Trim
                        Me.txtStrName2.Text = Convert.ToString(.Item("st_name")).Trim
                        Me.txtStrNo2.Text = Convert.ToString(.Item("st_no")).Trim
                        Me.txtZip2.Text = Convert.ToString(.Item("zip_code")).Trim
                    End With
                Else
                    Me.trAddress.Visible = False
                    Me.lnkAddress.Visible = True
                End If
            End If
        End Using


    End Sub

#End Region

#Region "Private JavaScript"

    Private Sub Load_JavaScript()

        '--add by daniel for remove '20070921
        Me.txtCardNo.Attributes.Add("onfocus", "check_search_max_length();")
        Me.txtvcode.Attributes.Add("onfocus", "check_search_max_length();")

        '## 1/25/2008   Changed by yang
        'Me.btnSubmit.Attributes.Add("onclick", "return CheckPassword();")
        Pricing.RegisterValidateCCScript(Me, Me.btnSubmit, Me.trButton, Me.SubmitHide, 2)
        '## 1/24/2008   Add Verify Credit Card  (Joey)
        'Dim strCCExp As String
        'If Me.ddlExpMonth.SelectedIndex < 10 Then
        '    strCCExp = "0" & Me.ddlExpMonth.SelectedIndex & Me.ddlExpYear.SelectedValue
        'Else
        '    strCCExp = Me.ddlExpMonth.SelectedIndex & Me.ddlExpYear.SelectedValue
        'End If
        'Using objVIP As New Users
        '    Dim objVIPData As UserData

        '    objVIPData = objVIP.VIPUserGet(MySession.UserID, MySession.AcctID, MySession.SubAcctID, MySession.Company)
        '    If objVIPData.CCType = Me.ddlCardType.SelectedValue And objVIPData.CCExp = strCCExp And objVIPData.CCNo = Me.txtCardNo.Text.Trim Then
        '        'do nothing
        '    Else
        '        Pricing.RegisterValidateCCScript(Me, Me.btnSubmit, Me.trButton, Me.SubmitHide, 1)
        '    End If
        'End Using

        Me.fname.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.lname.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.password0.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.password1.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.password2.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.stno.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.stname.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.city.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.state.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.zipcode.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.email.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.officephone.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.officephoneext.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.txtCellPhone.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.txtFax.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.txtHomePage.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.txtPager.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.txtPhone2.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.txtphone2_ext.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.txtCardNo.Attributes.Add("onkeypress", "javascript:entervalues();")
        Me.txtCardName.Attributes.Add("onkeypress", "javascript:entervalues();")
        'Me.txtsecardno.Attributes.Add("onkeypress", "javascript:entervalues();")
        'Me.txtsecCardName.Attributes.Add("onkeypress", "javascript:entervalues();")

        '#added by joey 12/06/2007
        Me.lnkAddress.Attributes.Add("onclick", "window.open('newAddress.aspx?vip_no=" & MySession.UserID & "','newaddress','height=300,width=500');return false;")

    End Sub

#End Region


   
End Class
