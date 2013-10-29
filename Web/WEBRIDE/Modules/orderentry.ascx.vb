Imports Business
Imports Business.Common

Partial Class Modules_orderentry
    Inherits System.Web.UI.UserControl

    Private Const CREDIT_CARD As String = "Credit Card"

#Region " Properties "

    Private m_UserID As String
    Private m_AcctID As String
    Private m_SubAcctID As String
    Private m_Company As String
    Private m_UserType As UserType

    Public Property UserID() As String
        Get
            Return Me.m_UserID
        End Get
        Set(ByVal value As String)
            Me.m_UserID = value
            'Me.LoadFrequentAddressInfo()
        End Set
    End Property
    Public Property AcctID() As String
        Get
            Return Me.m_AcctID
        End Get
        Set(ByVal value As String)
            Me.m_AcctID = value
            'Me.LoadCampusLocationInfo()
            'Me.LoadFrequentAddressInfo()
        End Set
    End Property
    Public Property SubAcctID() As String
        Get
            Return Me.m_SubAcctID
        End Get
        Set(ByVal value As String)
            Me.m_SubAcctID = value
        End Set
    End Property
    Public Property Company() As String
        Get
            Return Me.m_Company
        End Get
        Set(ByVal value As String)
            Me.m_Company = value
        End Set
    End Property

    Public WriteOnly Property SetUserType() As UserType
        Set(ByVal value As UserType)
            Me.m_UserType = value
        End Set
    End Property

    Public Property TravelDateTime() As DateTime
        Get
            Return Me.Calendar1.DateTime
        End Get
        Set(ByVal value As DateTime)
            Me.Calendar1.DateTime = value
        End Set
    End Property

    Public Property PhoneNo() As String
        Get
            Return Me.txtPhone.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.txtPhone.Text = ""
        End Set
    End Property
    Public Property PhoneExt() As String
        Get
            Return Me.txtPhoneExt.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.txtPhoneExt.Text = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return Me.txtLastName.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.txtLastName.Text = value
        End Set
    End Property
    Public Property FirstName() As String
        Get
            Return Me.txtFirstName.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.txtFirstName.Text = value
        End Set
    End Property

    Public Property EmailAddress() As String
        Get
            Return Me.txtEmailAddress.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.txtEmailAddress.Text = value
        End Set
    End Property

    Public Property PaymentType() As String
        Get
            Return Me.ddlPaymentType.SelectedValue
        End Get
        Set(ByVal value As String)
            If Not value Is Nothing Then
                For Each li As ListItem In Me.ddlPaymentType.Items
                    If li.Value.Trim = value.Trim Then
                        Me.ddlPaymentType.SelectedIndex = -1
                        li.Selected = True
                    End If
                Next
            End If
        End Set
    End Property

    Public Property CreditCardType() As String
        Get
            Return Me.ddlCardType.SelectedValue
        End Get
        Set(ByVal value As String)
            If Not value Is Nothing Then
                For Each li As ListItem In Me.ddlCardType.Items
                    If li.Value.Trim = value.Trim Then
                        Me.ddlCardType.SelectedIndex = -1
                        li.Selected = True
                    End If
                Next
            End If
        End Set
    End Property
    Public Property CreditCardNo() As String
        Get
            Return Me.txtCardNo.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.txtCardNo.Text = value
        End Set
    End Property
    Public Property CreditCardExpYear() As String
        Get
            Return Me.ddlCardExpYear.SelectedValue.Trim
        End Get
        Set(ByVal value As String)
            If Not value Is Nothing Then
                For Each li As ListItem In Me.ddlCardExpYear.Items
                    If li.Value.Trim = value.Trim Then
                        Me.ddlCardExpYear.SelectedIndex = -1
                        li.Selected = True
                    End If
                Next
            End If
        End Set
    End Property
    Public Property CreditCardExpMonth() As String
        Get
            Return Me.ddlCardExpMonth.SelectedValue
        End Get
        Set(ByVal value As String)
            If Not value Is Nothing Then
                For Each li As ListItem In Me.ddlCardExpMonth.Items
                    If li.Value.Trim = value.Trim Then
                        Me.ddlCardExpMonth.SelectedIndex = -1
                        li.Selected = True
                    End If
                Next
            End If
        End Set
    End Property

    Public Property VehicleType() As String
        Get
            Return Me.ddlVehicleType.SelectedValue
        End Get
        Set(ByVal value As String)
            If Not value Is Nothing Then
                For Each li As ListItem In Me.ddlVehicleType.Items
                    If li.Value.Trim = value.Trim Then
                        Me.ddlVehicleType.SelectedIndex = -1
                        li.Selected = True
                    End If
                Next
            End If
        End Set
    End Property

    Public ReadOnly Property txtCompReq() As TextBox()
        Get
            Return Me.txtReq
        End Get
    End Property

#End Region

    Private trReq(5) As HtmlTableRow
    Private lblReq(5) As Label
    Private txtReq(5) As TextBox
    Private req(5) As Label

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetReqCtlList()
        Me.LoadScript()
        Me.LoadFrequentUser()
    End Sub

    Private Sub LoadVehicleType()
        Using order As New Orders
            With Me.ddlVehicleType
                .DataSource = order.getCarType
                .DataTextField = "car_type_desc"
                .DataValueField = "car_type_id"
                .DataBind()
            End With
        End Using
    End Sub

    Private Sub LoadPaymentType()
        Using payment As New Operators
            Dim out As Boolean = payment.BindPaymentType(Me.ddlPaymentType, Me.m_UserType)
            If out = False Then
                Me.ddlPaymentType.Items.Insert(0, New ListItem("DISABLED", "99"))
            End If

            '## Disabled Credit Card for Group User
            'If Me.m_UserType = UserType.GroupUser Then
            'Me.trCreditCard.Visible = False
            'Me.ddlCardType.Visible = False
            'End If
        End Using

        Me.ddlPaymentType.Attributes.Add("onchange", "javascript:OrderEntryModuleSelectPaymentType('" & _
                Me.ddlPaymentType.ClientID & "','" & Me.ddlCardType.ClientID & "','" & Me.ddlCardExpMonth.ClientID & "','" & _
                Me.ddlCardExpYear.ClientID & "','" & Me.txtCardNo.ClientID & "');")
    End Sub

    Public Sub LoadScript()
        Dim script As String

        Me.txtPhone.Attributes.Add("onpropertychange", "javascript:OrderEntryModuleGoToNextPhoneBox(this.id,'" & Me.txtPhoneExt.ClientID & "',10);")

        script = "<script type='text/javascript'>" & _
                "function OrderEntryModule" & Me.ID & "Validate(){" & _
                    "var out=true,travelDate;" & _
                    "travelDate=CalendarModule" & Me.Calendar1.ID & "GetTravelDate();var c=new Date;c.setHours(c.getHours() + 2);" & _
                    "if((c>travelDate)==true){" & _
                        "alert('Based on your pick up location, the call could not be completed because the ride time falls within 2 hours from the current time.  Please call 718-522-0427 immediately for special arrangement of your ride request.');out=false;}" & _
                    "else if(document.getElementById('" & Me.txtPhone.ClientID & "').value.length==0){" & _
                        "alert('Phone enter phone number.');out=false;}" & _
                    "else if(document.getElementById('" & Me.txtPhone.ClientID & "').value.length!=10){" & _
                        "alert('Phone number is incorrect, please verify phone number.');out=false;}" & _
                    "else if(isNaN(document.getElementById('" & Me.txtPhone.ClientID & "').value)){" & _
                        "alert('Please Enter only numeric values in  phone number.');out=false;}" & _
                    "else if(document.getElementById('" & Me.txtLastName.ClientID & "').value.length==0){" & _
                        "alert('Please enter a passenger last name.');out=false;}" & _
                    "else if(document.getElementById('" & Me.txtFirstName.ClientID & "').value.length==0){" & _
                        "alert('Please enter a passenger first name.');out=false;}" & _
                    "else if(document.getElementById('" & Me.txtEmailAddress.ClientID & "').value.length==0){" & _
                        "alert('Please enter a email address.');out=false;}" & _
                    "else if(document.getElementById('" & Me.txtEmailAddress.ClientID & "').value.match(/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/)==null){" & _
                        "alert('Please Enter the Correct Email Address.');out=false;}"

        'If Me.m_UserType <> UserType.GroupUser Then
        script &= "else if(document.getElementById('" & Me.ddlPaymentType.ClientID & "').options[document.getElementById('" & Me.ddlPaymentType.ClientID & "').selectedIndex].text=='" & CREDIT_CARD & "' && document.getElementById('" & Me.ddlCardType.ClientID & "').selectedIndex<=0){" & _
                    "alert('Please select a credit card type.');out=false;}" & _
                "else if(document.getElementById('" & Me.ddlPaymentType.ClientID & "').options[document.getElementById('" & Me.ddlPaymentType.ClientID & "').selectedIndex].text=='" & CREDIT_CARD & "' && (document.getElementById('" & Me.ddlCardExpYear.ClientID & "').selectedIndex<=0 || document.getElementById('" & Me.ddlCardExpMonth.ClientID & "').selectedIndex<=0)){" & _
                    "alert('Please enter the valid credit card expiration date!');out=false;}" & _
                "else if(document.getElementById('" & Me.ddlPaymentType.ClientID & "').options[document.getElementById('" & Me.ddlPaymentType.ClientID & "').selectedIndex].text=='" & CREDIT_CARD & "' && document.getElementById('" & Me.txtCardNo.ClientID & "').value.length !=15 && document.getElementById('" & Me.ddlCardType.ClientID & "').options[document.getElementById('" & Me.ddlCardType.ClientID & "').selectedIndex].text=='AMEX'){" & _
                    "alert('AMEX has 15 digits! Please re-enter.');out=false;}" & _
                "else if(document.getElementById('" & Me.ddlPaymentType.ClientID & "').options[document.getElementById('" & Me.ddlPaymentType.ClientID & "').selectedIndex].text=='" & CREDIT_CARD & "' && document.getElementById('" & Me.txtCardNo.ClientID & "').value.length !=15 && document.getElementById('" & Me.ddlCardType.ClientID & "').options[document.getElementById('" & Me.ddlCardType.ClientID & "').selectedIndex].text=='DINERS '){" & _
                    "alert('DINERS has 15 digits! Please re-enter.');out=false;}" & _
                "else if(document.getElementById('" & Me.ddlPaymentType.ClientID & "').options[document.getElementById('" & Me.ddlPaymentType.ClientID & "').selectedIndex].text=='" & CREDIT_CARD & "' && document.getElementById('" & Me.txtCardNo.ClientID & "').value.length !=16 && document.getElementById('" & Me.ddlCardType.ClientID & "').options[document.getElementById('" & Me.ddlCardType.ClientID & "').selectedIndex].text!='AMEX' && document.getElementById('" & Me.ddlCardType.ClientID & "').options[document.getElementById('" & Me.ddlCardType.ClientID & "').selectedIndex].text!='DINERS'){" & _
                    "alert('Credit Card has 16 digits! Please re-enter.');out=false;}" & _
                "else if(document.getElementById('" & Me.ddlPaymentType.ClientID & "').options[document.getElementById('" & Me.ddlPaymentType.ClientID & "').selectedIndex].text=='" & CREDIT_CARD & "' && isNaN(document.getElementById('" & Me.txtCardNo.ClientID & "').value)){" & _
                    "alert('Please enter numeric values as credit card no!');out=false;}" & _
                "else if(document.getElementById('" & Me.ddlPaymentType.ClientID & "').options[document.getElementById('" & Me.ddlPaymentType.ClientID & "').selectedIndex].text=='" & CREDIT_CARD & "' && document.getElementById('" & Me.ddlCardExpYear.ClientID & "').selectedIndex<=1 && document.getElementById('" & Me.ddlCardExpMonth.ClientID & "').selectedIndex<" & Now.Month & "){" & _
                    "alert('Please enter the valid credit card expiration date!');out=false;}"
        'End If

        For i As Integer = 0 To 5
            If Me.txtReq(i).Visible And Me.req(i).Visible Then
                script &= "else if(document.getElementById('" & Me.txtReq(i).ClientID & "').value.length==0){" & _
                        "alert('Required Company ID fields are incorrect.');out=false;}"
            End If
        Next

        script &= "return out;}</script>"

        Me.Page.ClientScript.RegisterStartupScript(GetType(String), Me.ID & "Validate", script)

        script = "<script type='text/javascript'>OrderEntryModuleSelectPaymentType('" & _
                Me.ddlPaymentType.ClientID & "','" & Me.ddlCardType.ClientID & "','" & Me.ddlCardExpMonth.ClientID & "','" & _
                Me.ddlCardExpYear.ClientID & "','" & Me.txtCardNo.ClientID & "');</script>"
        Me.Page.ClientScript.RegisterStartupScript(GetType(String), Me.ID & "PaymentType", script)

    End Sub

    Private Sub LoadUserProfile()
        Using users As New Business.Users

            Me.Calendar1.DateTime = Now

            Dim user As UserData

            user = users.getUserInfo(Me.m_UserID, Me.m_AcctID, Me.m_SubAcctID, Me.m_Company)

            '-- Primary Phone Number
            Me.txtPhone.Text = user.office_phone
            Me.txtPhoneExt.Text = user.office_phone_ext

            '-- Last, First Name
            Me.txtFirstName.Text = user.fname
            Me.txtLastName.Text = user.lname

            '-- Email Address
            Me.txtEmailAddress.Text = user.email

            '## Payment Type
            If Not user.CCType Is Nothing Then
                For Each li As ListItem In Me.ddlPaymentType.Items
                    If li.Value.Trim = user.CCType.Trim Then
                        Me.ddlPaymentType.SelectedIndex = -1
                        li.Selected = True
                    End If
                Next
            End If

            '## Credit Card
            Me.txtCardNo.Text = user.CCNo
            Me.CreditCardExpMonth = user.CCMonth
            Me.CreditCardExpYear = user.CCYear
            Me.CreditCardType = user.CCType
        End Using
    End Sub

#Region " Credit Card "

    Public Sub LoadCardType()
        Using card As New Card
            Dim CCDataSet As DataSet = card.getAllCardType
            If Not CCDataSet Is Nothing AndAlso CCDataSet.Tables.Count > 0 Then
                Me.ddlCardType.DataSource = CCDataSet
                Me.ddlCardType.DataTextField = "card_type_desc"
                Me.ddlCardType.DataValueField = "card_type_id"
                Me.ddlCardType.DataBind()
            End If

            Me.ddlCardType.Items.Insert(0, New ListItem("Credit Card Type", ""))
        End Using
    End Sub
    Public Sub LoadExpYear()
        Me.ddlCardExpYear.Items.Clear()
        Me.ddlCardExpYear.Items.Add(New ListItem("Year", ""))

        For i As Integer = 0 To 10
            Dim text As String = Now.AddYears(i).Year.ToString.Substring(2, 2)
            Me.ddlCardExpYear.Items.Add(New ListItem(text, text))
        Next
    End Sub
#End Region

#Region " Company Requirement "

    Public Sub SetAcctReqVisible(ByVal Visible As Boolean)
        Me.SetReqCtlList()
        For i As Integer = 0 To 5
            Me.trReq(i).Visible = Visible
        Next
    End Sub
    Public Sub SetReqCtlList()
        Me.trReq(0) = Me.trReq1
        Me.trReq(1) = Me.trReq2
        Me.trReq(2) = Me.trReq3
        Me.trReq(3) = Me.trReq4
        Me.trReq(4) = Me.trReq5
        Me.trReq(5) = Me.trReq6

        Me.lblReq(0) = Me.lblReq1
        Me.lblReq(1) = Me.lblReq2
        Me.lblReq(2) = Me.lblReq3
        Me.lblReq(3) = Me.lblReq4
        Me.lblReq(4) = Me.lblReq5
        Me.lblReq(5) = Me.lblReq6

        Me.txtReq(0) = Me.txtReq1
        Me.txtReq(1) = Me.txtReq2
        Me.txtReq(2) = Me.txtReq3
        Me.txtReq(3) = Me.txtReq4
        Me.txtReq(4) = Me.txtReq5
        Me.txtReq(5) = Me.txtReq6

        Me.req(0) = Me.req1
        Me.req(1) = Me.req2
        Me.req(2) = Me.req3
        Me.req(3) = Me.req4
        Me.req(4) = Me.req5
        Me.req(5) = Me.req6
    End Sub

    '--created by joey 2/15/2008
    Public Function ValidationCompanyRequirement() As Boolean
        Dim strReq(5) As String
        Dim i As Integer
        Dim out As Integer
        Dim ValidateReq As Boolean
        For i = 0 To 5
            If Me.req(i).Visible = True And Me.trReq(i).Visible = True Then
                strReq(i) = Me.txtReq(i).Text.Trim
            Else
                strReq(i) = ""
            End If
        Next
        Using objOperator As New Operators
            out = objOperator.ValidationReq(MySession.AcctID, MySession.SubAcctID, MySession.Company, strReq)
        End Using
        Select Case out
            Case 0
                ValidateReq = True
                'Case 1
                '    ValidateReq = False
                '    Page.ClientScript.RegisterStartupScript(GetType(String), "Message", _
                '                String.Format("<script type='text/javascript'>alert('{0}')</script>", "Required Company ID fields(" & Me.lblReq1.Text.Trim & ")are incorrect!"))
                'Case 2
                '    ValidateReq = False
                '    Page.ClientScript.RegisterStartupScript(GetType(String), "Message", _
                '                String.Format("<script type='text/javascript'>alert('{0}')</script>", "Required Company ID fields(" & Me.lblReq2.Text.Trim & ")are incorrect!"))
                'Case 3
                '    ValidateReq = False
                '    Page.ClientScript.RegisterStartupScript(GetType(String), "Message", _
                '                String.Format("<script type='text/javascript'>alert('{0}')</script>", "Required Company ID fields(" & Me.lblReq3.Text.Trim & ")are incorrect!"))
                'Case 4
                '    ValidateReq = False
                '    Page.ClientScript.RegisterStartupScript(GetType(String), "Message", _
                '                String.Format("<script type='text/javascript'>alert('{0}')</script>", "Required Company ID fields(" & Me.lblReq4.Text.Trim & ")are incorrect!"))
                'Case 5
                '    ValidateReq = False
                '    Page.ClientScript.RegisterStartupScript(GetType(String), "Message", _
                '                String.Format("<script type='text/javascript'>alert('{0}')</script>", "Required Company ID fields(" & Me.lblReq5.Text.Trim & ")are incorrect!"))
                'Case 6
                '    ValidateReq = False
                '    Page.ClientScript.RegisterStartupScript(GetType(String), "Message", _
                '                String.Format("<script type='text/javascript'>alert('{0}')</script>", "Required Company ID fields(" & Me.lblReq6.Text.Trim & ")are incorrect!"))
            Case Else
                ValidateReq = False
        End Select

        '## 2/15/2008   Modified by yang
        If ValidateReq = False AndAlso _
                    Not Me.lblReq(out - 1) Is Nothing AndAlso TypeOf (Me.lblReq(out - 1)) Is Label AndAlso _
                    Not Me.req(out - 1) Is Nothing AndAlso TypeOf (Me.req(out - 1)) Is Label Then

            Dim ErrMsg As String

            'ErrMsg = "Required Company ID fields (" & Me.lblReq(out - 1).Text.Trim & ") is incorrect!"
            ErrMsg = "Required Company ID fields are incorrect! (Incorrect fields are marked with red circles)"

            Page.ClientScript.RegisterStartupScript(GetType(String), "Message", _
                        String.Format("<script type='text/javascript'>alert('{0}')</script>", ErrMsg))

            Me.req(out - 1).Text = "<img src='images/reddot.gif'/>"
        End If

        Return ValidateReq
    End Function
#End Region

#Region " Public Functions "

    Public Sub GetValueFromScreen(ByRef ord As OperatorData)
       
        With ord
            .vip_no = MySession.UserID
            .account_no = MySession.AcctID
            .sub_account_no = MySession.SubAcctID
            .company = MySession.Company
            .priority = "n"

            '## Travel Date
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

            '## Phone
            .pu_phone = Me.txtPhone.Text.Trim
            .pu_phone_ext = Me.txtPhoneExt.Text.Trim

            '## Email
            .email_address = Me.txtEmailAddress.Text.Trim
            .email_add = Me.txtEmailAddress.Text.Trim

            '## Passenger Name
            .pass_fname = UCase(Me.txtFirstName.Text.Trim)      'added the Ucase  by lily 01/27/2008
            .pass_lname = UCase(Me.txtLastName.Text.Trim)       'added the Ucase  by lily 01/27/2008
            .lname = UCase(Me.txtLastName.Text.Trim)            'added the Ucase  by lily 01/27/2008
            .fname = UCase(Me.txtFirstName.Text.Trim)           'added the Ucase  by lily 01/27/2008

            '## Payment Type
            .payment_type = Me.ddlPaymentType.SelectedValue.Trim
            .payment_type_desc = Me.ddlPaymentType.SelectedItem.Text.Trim

            'If Me.m_UserType <> UserType.GroupUser Then
            '## Group User does not need Credit Card Info
            If .payment_type_desc = CREDIT_CARD Then
                .card_type = Me.ddlCardType.SelectedValue
                .card_no = Me.txtCardNo.Text.Trim()
                .card_exp_date = Convert.ToString(Me.ddlCardExpMonth.SelectedValue & Me.ddlCardExpYear.SelectedValue)
            Else
                .card_type = ""
                .card_no = ""
                .card_exp_date = ""
            End If
            'End If

            '## Vehicle Type
            .Car_type_Desc = Me.ddlVehicleType.SelectedItem.Text.Trim
            .Car_type = Me.ddlVehicleType.SelectedValue

            '## Company Requirement
            If Me.trReq1.Visible Then
                .Comp_id_1 = Me.txtReq1.Text.Trim
            Else
                .Comp_id_1 = ""
            End If
            If Me.trReq2.Visible Then
                .Comp_id_2 = Me.txtReq2.Text.Trim
            Else
                .Comp_id_2 = ""
            End If
            If Me.trReq3.Visible Then
                .Comp_id_3 = Me.txtReq3.Text.Trim
            Else
                .Comp_id_3 = ""
            End If
            If Me.trReq4.Visible Then
                .Comp_id_4 = Me.txtReq4.Text.Trim
            Else
                .Comp_id_4 = ""
            End If
            If Me.trReq5.Visible Then
                .Comp_id_5 = Me.txtReq5.Text.Trim
            Else
                .Comp_id_5 = ""
            End If
            If Me.trReq6.Visible Then
                .Comp_id_6 = Me.txtReq6.Text.Trim
            Else
                .Comp_id_6 = ""
            End If
        End With

    End Sub
    Public Sub LoadValueToScreen(ByVal ord As OperatorData)
        With ord
            Me.Calendar1.DateTime = ord.req_date_time
            Me.txtPhone.Text = ord.pu_phone
            Me.txtPhoneExt.Text = ord.pu_phone_ext
            Me.txtLastName.Text = ord.lname
            Me.txtFirstName.Text = ord.fname
            Me.txtEmailAddress.Text = ord.email_add

            Me.PaymentType = ord.payment_type

            If ord.payment_type = "5" OrElse ord.payment_type_desc = CREDIT_CARD Then
                Me.CreditCardType = .CC_Type_Default    '##changed car_type to CC_Type_Default by joey  1/29/2008
                Me.txtCardNo.Text = .card_no
                If .card_exp_date.Trim.Length = 4 Then
                    Me.CreditCardExpMonth = .card_exp_date.Substring(0, 2)
                    Me.CreditCardExpYear = .card_exp_date.Substring(2, 2)
                Else
                    Me.CreditCardExpMonth = ""
                    Me.CreditCardExpYear = ""
                End If
            End If

            Me.VehicleType = .Car_type

            Me.txtReq1.Text = .Comp_id_1
            Me.txtReq2.Text = .Comp_id_2
            Me.txtReq3.Text = .Comp_id_3
            Me.txtReq4.Text = .Comp_id_4
            Me.txtReq5.Text = .Comp_id_5
            Me.txtReq6.Text = .Comp_id_6
        End With
    End Sub

    Public Sub LoadPaymentTypeAndVehicleType()
        Me.LoadVehicleType()
        Me.LoadPaymentType()
        Me.LoadCardType()
        Me.LoadExpYear()
    End Sub

    Public Sub LoadCompanyRequirement()
        Dim ControlIndex As Int16 = 0

        Me.SetAcctReqVisible(False)

        Using account As New Operators
            Dim dt As DataTable = account.GetCompanyQue(Me.m_AcctID, Me.m_SubAcctID, Me.m_Company)

            For Each dr As DataRow In dt.Rows
                Dim CompReqDesc As String = SentenceCase(Convert.ToString(dr.Item("req_desc")).Trim())
                '## added by joey   1/30/2008
                Dim display As Int16 = Convert.ToInt16(dr.Item("display"))
                If Not display = 2 And Not display = 0 Then
                    Me.trReq(ControlIndex).Visible = True
                    Me.lblReq(ControlIndex).Text = CompReqDesc
                    If dr.Item("comp_ver_1") = 2 Then
                        Me.req(ControlIndex).Visible = True
                    Else
                        Me.req(ControlIndex).Visible = False
                    End If
                End If
                ControlIndex += 1
            Next
        End Using
    End Sub

    Public Sub LoadCreditCardAndUserProfile()
        Me.LoadUserProfile()
    End Sub

#End Region

    Public Sub LoadFrequentUser()
        If Not Me.m_AcctID Is Nothing AndAlso Convert.ToString(Me.m_AcctID).Trim().Length > 0 AndAlso _
            Not Me.m_UserID Is Nothing AndAlso Convert.ToString(Me.m_UserID).Trim().Length > 0 AndAlso _
            Not Me.m_SubAcctID Is Nothing AndAlso Convert.ToString(Me.m_SubAcctID).Trim.Length > 0 AndAlso _
            Not Me.m_Company Is Nothing AndAlso Convert.ToString(Me.m_Company).Trim.Length > 0 Then

            Using objuser As New Users
                Dim ds As DataSet
                Dim strDefault As String = Me.txtPhone.Text.Trim & "|" & Me.txtPhoneExt.Text.Trim & "|" & Me.txtLastName.Text.Trim & _
                    "|" & Me.txtFirstName.Text.Trim & "|" & Me.txtEmailAddress.Text.Trim

                ds = objuser.GetFrequentProfile(Me.m_UserID, Me.m_AcctID, Me.m_SubAcctID, Me.m_Company)

                If Not ds Is Nothing AndAlso ds.Tables.Count > 0 Then
                    Me.lstFreq.DataSource = ds.Tables(0).DefaultView
                    Me.lstFreq.DataTextField = "name"
                    Me.lstFreq.DataValueField = "info"
                    Me.lstFreq.DataBind()

                    '## 1 phone, 2 phone_ext, 3 lname, 4 fname, 5 Email address 
                    Dim script As String = "this,'" & _
                        Me.txtPhone.ClientID & "','" & Me.txtPhoneExt.ClientID & "','" & Me.txtLastName.ClientID & "','" & _
                        Me.txtFirstName.ClientID & "','" & Me.txtEmailAddress.ClientID & "'"

                    Me.lstFreq.Attributes.Add("onclick", "javascript:OrderEntryMuduleSelectFreqUser(" & script & ");")
                End If

                Me.lstFreq.Items.Insert(0, New ListItem("Default", strDefault))
            End Using
        End If
    End Sub

End Class
