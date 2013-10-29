Imports Business
Imports System.page

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Dim key1 = "Lhn2trcS3zHmvktdq637cX8t3nXSXfyeip9znYyLubt4q4aqb"
    Public strPassword As String

#Region "Protected Sub Page Events"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Errmsg As String

        Errmsg = Trim(Request.QueryString("msg"))

        Select Case Errmsg
            Case "notime"
                Call Me.AriseJavaScript("'Online order is blocked for now!\n\rPlease call 1-800-APEX-1800 to make a reservation.'")
                Call clear_auto_login()
            Case "no"
                Call Me.AriseJavaScript("'No User Found. Please Try again'")
                Call clear_auto_login()
            Case "renew"
                Call Me.AriseJavaScript("'This account is expired. Please renew'")
                Call clear_auto_login()
            Case "noacct"
                Call Me.AriseJavaScript("'No account found. Please try again'")
                Call clear_auto_login()
            Case "sessionexp"
                Call Me.AriseJavaScript("'Session has expired'")
                Call clear_auto_login()
            Case "nonet"
                Call Me.AriseJavaScript("'Your account is not set up for on line ordering.'")
                Call clear_auto_login()
            Case "pwerror"
                Call Me.AriseJavaScript("'Error with password setup. Please try again'")
                Call clear_auto_login()
            Case "pw"
                Call Me.AriseJavaScript("'Password is incorrect. Please try again'")
                Call clear_auto_login()
            Case "dupvip"
                Call Me.AriseJavaScript("'Error: Duplicate User. Please Call an APEX Representative.'")
                Call clear_auto_login()
            Case "usract"
                Call Me.AriseJavaScript("'User Has been Activated Successfully.'")
                Call clear_auto_login()
            Case "cnerror"
                Call Me.AriseJavaScript("'Connect SQL Server Error!'")
                Call clear_auto_login()
            Case "Success"
                Call Me.AriseJavaScript("'Thank you. Your profile has been created.'")
                Call clear_auto_login()
            Case "tcerror"
                Call Me.AriseJavaScript("'Error with Terms and Condition setup. Please try again.'")
                Call clear_auto_login()
           
            Case "logout"
                Session.Abandon()
                Response.Redirect("index.aspx", True)
            Case Else
                '--do nothing
                'Call Me.Load_info()
        End Select

        Load_JavaScript()

        If Not Page.IsPostBack Then
            'Session.Abandon()
            '--add by daniel for cookies 
            Dim user_id, acct_id, sub_acct_id As String

            user_id = Request.QueryString("user_id")
            acct_id = Request.QueryString("acct_id")

            sub_acct_id = Trim(Request.QueryString("sub_acct_id"))

            If sub_acct_id = "" Then
                sub_acct_id = "0000000000"
            End If

            '-- 9/19/05 If remember me checkbox is set then do auto login (Naoki)
            If check_auto_login() = True Then
                user_id = Server.HtmlEncode(Request.Cookies("username").Value) 'Request.Cookies("site_login")("username")
                Me.ckRemberme.Checked = True
                Me.txtLoginName.Text = user_id
                strPassword = Server.HtmlEncode(Request.Cookies("password").Value)
                'Me.txtPassword.Value = "1234"
            End If
            '------------------------------------------------------------------------
        Else
            strPassword = Me.hidtxtPassword.Value
        End If

    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLogin.Click
        '--add by daniel for login process 23/11/2007
        Dim username As String
        Dim password As String

        username = Me.txtLoginName.Text.Trim()
        password = Me.txtPassword.Text.Trim()

        Dim objHome As New Users
        Dim objVIPData As UserData

        If Not username Is Nothing And Not password Is Nothing And username <> "" And password <> "" Then
            objVIPData = objHome.VipUserLogin(username, password)

            Dim strCheckUser As String
            strCheckUser = objVIPData.check_user

            Select Case strCheckUser
                Case "No Time"
                    Response.Redirect("index.aspx?msg=notime", True)
                    Exit Sub
                Case "No User"
                    Response.Redirect("index.aspx?msg=no", True)
                    Exit Sub
                Case "Dup User"
                    Response.Redirect("index.aspx?msg=dupvip", True)
                    Exit Sub
                Case "Password incorrect"
                    Response.Redirect("index.aspx?msg=pw", True)
                    Exit Sub
                Case "Close date is valid"
                    Response.Redirect("index.aspx?msg=renew", True)
                    Exit Sub
                    'disable by lily 03/10/2008
                    'Case ""
                    '    '--Check Account
                    '    If objVIPData.checkAccount = "No Account" Then
                    '        Response.Redirect("index.aspx?msg=noacct&user_id=" & username, True)
                    '        Exit Sub
                    '    Else
                    '        '--check close_date
                    '        If Not objVIPData.close_date Is Nothing Then
                    '            If IsDate(objVIPData.close_date) Then
                    '                If DateDiff("d", Now(), DateValue(objVIPData.close_date)) < 0 Then
                    '                    Response.Redirect("index.aspx?msg=renew&user_id=" & username, True)
                    '                    Exit Sub
                    '                End If
                    '            Else
                    '                Response.Redirect("index.aspx?msg=renew&user_id=" & username, True)
                    '                Exit Sub
                    '            End If
                    '        Else
                    '            '--do nothing
                    '        End If

                    '        '--check internet
                    '        If Not objVIPData.Internet Is Nothing Then
                    '            If objVIPData.Internet.CompareTo("t") <> 0 Then
                    '                Response.Redirect("index.aspx?msg=nonet&user_id=" & username, True)
                    '                Exit Sub
                    '            End If
                    '        Else
                    '            Response.Redirect("index.aspx?msg=cnerror&user_id=" & username, True)
                    '            Exit Sub
                    '        End If
                    '    End If
                Case Else
                    '--do nothing
            End Select
            'added by lily 03/10/2008
            If objVIPData.checkAccount = "No Account" Then
                Response.Redirect("index.aspx?msg=noacct&user_id=" & username, True)
                Exit Sub
            Else
                '--check close_date
                If Not objVIPData.close_date Is Nothing Then
                    If IsDate(objVIPData.close_date) Then
                        If DateDiff("d", Now(), DateValue(objVIPData.close_date)) < 0 Then
                            Response.Redirect("index.aspx?msg=renew&user_id=" & username, True)
                            Exit Sub
                        End If
                    Else
                        Response.Redirect("index.aspx?msg=renew&user_id=" & username, True)
                        Exit Sub
                    End If
                Else
                    '--do nothing
                End If

                '--check internet
                If Not objVIPData.Internet Is Nothing Then
                    If objVIPData.Internet.CompareTo("t") <> 0 Then
                        Response.Redirect("index.aspx?msg=nonet&user_id=" & username, True)
                        Exit Sub
                    End If
                Else
                    Response.Redirect("index.aspx?msg=cnerror&user_id=" & username, True)
                    Exit Sub
                End If
            End If

            '--add by daniel for save cookies-----------------------------           
            If check_auto_login() = True And Me.ckRemberme.Checked = True Then
                username = Server.HtmlEncode(Request.Cookies("username").Value)
                password = Server.HtmlEncode(Request.Cookies("password").Value) 'DecryptIt(Server.HtmlEncode(Request.Cookies("password").Value), key1) 'DecryptIt(Request.Cookies("site_login")("password"), key1)
                Call save_auto_login(username, password)
            Else
                username = Me.txtLoginName.Text.Trim()
                password = Me.hidtxtPassword.Value.Trim()

                '-- if remember me is not already set but user check remember me checkbox then save (Naoki)
                'If StrComp(Request.Form("login_mode"), "yes") = 0 Then
                If Me.ckRemberme.Checked = True Then
                    Call save_auto_login(username, password)
                Else
                    Call clear_auto_login()
                End If
            End If


            MySession.UserID = objVIPData.user_id
            MySession.AcctID = objVIPData.acct_id
            MySession.SubAcctID = objVIPData.sub_acct_id
            MySession.Company = objVIPData.accountcompany

            MySession.AcctName = Security.SentenceCase(objVIPData.Name)
            MySession.Priority = objVIPData.priority
            MySession.Table_ID = objVIPData.table_id

            MySession.UserName = Security.SentenceCase(Trim(objVIPData.fname) & " " & Trim(objVIPData.lname))
            MySession.LevelID = objVIPData.level1_id

            'Session("email") = objVIPData.email
            'Session("lname") = Trim(objVIPData.lname)
            'Session("fname") = Trim(objVIPData.fname)
            'Session("session_id") = Session.SessionID

            If username.CompareTo(Me.txtPassword.Text.Trim()) = 0 Then
                Response.Redirect("setpw.aspx", True)
            Else
                Response.Redirect("Order.aspx", True)
            End If
        End If

    End Sub

#End Region

#Region "Public Events Users Parts"

    Public Sub Load_JavaScript()
        Me.btnLogin.Attributes.Add("onclick", "return BatchValidateLogin();")
    End Sub

#End Region

#Region "Private & Public(Sub & Function)"

    '-----------------------------------------------------------------------------------
    '--Sub:AriseJavaScript
    '--Description:To show the error message
    '--Input:ErrorMessage
    '--Output:
    '--11/09/04 - Created (eJay)
    '-----------------------------------------------------------------------------------
    Private Sub AriseJavaScript(ByVal ErrorMessage As String)

        Dim strMessage As String
        strMessage = "<script language=""JavaScript"">alert("
        strMessage = strMessage & ErrorMessage
        strMessage = strMessage & ");"
        'strMessage = strMessage & "document.forms[0].txtUser.focus();"
        'strMessage = strMessage & "document.all['txtUsername'].focus();"
        strMessage = strMessage & "</script>"

        Response.Write(strMessage)

    End Sub
    '--add by daniel for cookies-------------------------
    '--06/19/2006----------------------------------------
    Public Function EncryptIt(ByVal it, ByVal key) As String
        Dim keylen, size, encryptstr, keymod, i
        keylen = Len(key)
        size = Len(it)
        encryptstr = ""
        'On Error Resume Next
        For i = 1 To size Step 1
            keymod = (i Mod keylen) + 1
            encryptstr = encryptstr & Convert.ToString(Asc(Mid(it, i, 1)) + Asc(Mid(key, keymod, 1)))
        Next
        EncryptIt = encryptstr
    End Function

    Public Function DecryptIt(ByVal it, ByVal key) As String
        Dim keylen, size, decryptstr, keymod, i
        keylen = Len(key)
        size = Len(it)
        decryptstr = ""
        On Error Resume Next
        For i = 1 To size Step 1
            keymod = (i Mod keylen) + 1
            decryptstr = decryptstr & Convert.ToString(Asc(Mid(it, i, 1)) - Asc(Mid(key, keymod, 1)))
        Next
        DecryptIt = decryptstr
    End Function
    '------------------------------------------------------------------------------
    '-- Function check_auto_login()
    '-- 9/19/05 Created. Check if remember me cookie is set and if values are saved (Naoki)
    '------------------------------------------------------------------------------
    Public Function check_auto_login() As Boolean
        Dim strRememberMe As String
        Dim bolRememberMe As Boolean
        bolRememberMe = False
        Try
            strRememberMe = Server.HtmlEncode(Request.Cookies("rememberme").Value) 'Request.Cookies("site_login")("rememberme")
        Catch ex As Exception
            strRememberMe = ""
        End Try
        '--Modify by daniel add the try catch. 2008/10/28
        Try
            If StrComp(strRememberMe, "yes") = 0 Then
                If Not Request.Cookies("username") Is Nothing AndAlso Request.Cookies("password") Is Nothing Then
                    If Server.HtmlEncode(Request.Cookies("username").Value) <> "" AndAlso Server.HtmlEncode(Request.Cookies("password").Value) <> "" Then
                        bolRememberMe = True
                    End If
                End If
                'If Request.Cookies("site_login")("username") <> "" And Request.Cookies("site_login")("password") <> "" Then
                '    bolRememberMe = True
                'End If
            End If
        Catch ex As Exception
            '--do nothing
        End Try
        'If StrComp(strRememberMe, "yes") = 0 Then
        '    If Not Request.Cookies("username") Is Nothing AndAlso Request.Cookies("password") Is Nothing Then
        '        If Server.HtmlEncode(Request.Cookies("username").Value) <> "" AndAlso Server.HtmlEncode(Request.Cookies("password").Value) <> "" Then
        '            bolRememberMe = True
        '        End If
        '    End If
        '    'If Request.Cookies("site_login")("username") <> "" And Request.Cookies("site_login")("password") <> "" Then
        '    '    bolRememberMe = True
        '    'End If
        'End If
        check_auto_login = bolRememberMe
    End Function
    '------------------------------------------------------------------------------
    '-- Function save_auto_login()
    '-- 9/19/05 Created. Save auto login information into cookies (Naoki)
    '------------------------------------------------------------------------------
    Public Sub save_auto_login(ByVal user_name, ByVal pw)

        'Response.Cookies("site_login")("rememberme") = "yes"
        'Response.Cookies("site_login")("username") = user_name
        'Response.Cookies("site_login")("password") = EncryptIt(pw, key1)
        'Response.Cookies("site_login").Expires = DateAdd("d", 14, Now)
        Response.Cookies("rememberme").Value = "yes"
        Response.Cookies("username").Value = user_name
        Response.Cookies("password").Value = pw 'EncryptIt(pw, key1)
        Response.Cookies("rememberme").Expires = DateAdd(DateInterval.Day, 14, Now)
        Response.Cookies("username").Expires = DateAdd(DateInterval.Day, 14, Now)
        Response.Cookies("password").Expires = DateAdd(DateInterval.Day, 14, Now)
    End Sub
    '------------------------------------------------------------------------------
    '-- Function save_auto_login()
    '-- 9/19/05 Created. Save auto login information into cookies (Naoki)
    '------------------------------------------------------------------------------
    Public Sub clear_auto_login()

        Response.Cookies("rememberme").Value = ""
        Response.Cookies("username").Value = ""
        Response.Cookies("password").Value = ""
        Response.Cookies("rememberme").Expires = DateAdd(DateInterval.Day, -2, Now)
        Response.Cookies("username").Expires = DateAdd(DateInterval.Day, -2, Now)
        Response.Cookies("password").Expires = DateAdd(DateInterval.Day, -2, Now)
    End Sub

#End Region

End Class

