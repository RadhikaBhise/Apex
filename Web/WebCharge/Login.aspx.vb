Imports Business
Imports DataAccess
Imports System.Data
Imports System.Data.SqlClient
Partial Class Login
    Inherits System.Web.UI.Page

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Me.btn_Login.Attributes.Add("onclick", "return validate();")

    '    Dim strLogInfo As String = String.Empty
    '    If Not (Request.QueryString("LogOff") Is Nothing) Then
    '        strLogInfo = Request.QueryString("LogOff")
    '    End If
    'End Sub

    'Protected Sub btn_Login_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Login.Click
    '    Dim strVipno, strPassword As String
    '    Dim strErrMsg As String

    '    If Not FormValidate() Then
    '        Exit Sub
    '    End If

    '    strVipno = Replace(txt_vipno.Text, "'", "''")
    '    strPassword = Replace(txt_Password.Text, "'", "''")

    '    strErrMsg = GroupLogin(strVipno, strPassword)  'group login
    '    If strErrMsg = "This account is not found." Then
    '        strErrMsg = Me.viplogin(strVipno, strPassword) 'vip login
    '        If strErrMsg <> "" Then
    '            Me.lbl_ErrMsg.Text = strErrMsg
    '            Me.lbl_ErrMsg.Visible = True
    '        Else
    '            If Convert.ToString(Session("level_id")).Trim() = "9" Then
    '                RegisterStartupScript("Popupmessage", "<script language='javascript'>alert('You do not have level permission.')</script>")
    '            Else
    '                Response.Redirect("default.aspx")
    '            End If
    '        End If

    '    ElseIf strErrMsg = "" Then
    '        Response.Redirect("default.aspx")
    '    Else
    '        Me.lbl_ErrMsg.Text = strErrMsg
    '        Me.lbl_ErrMsg.Visible = True

    '    End If

    'End Sub

    'Protected Sub btn_Clear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Clear.Click
    '    txt_vipno.Text = String.Empty
    '    txt_Password.Text = String.Empty
    '    acct_id.Text = String.Empty
    '    sub_acct_id.Text = String.Empty
    '    lbl_ErrMsg.Text = String.Empty
    'End Sub

    'Function FormValidate() As Boolean
    '    'If Not CheckCookie() Then
    '    '    Return False
    '    'End If
    '    Dim scriptString As String
    '    If Trim(txt_vipno.Text) = "" Then
    '        lbl_ErrMsg.Text = "Please enter a login"

    '        scriptString = "document.getElementById('ctl00_MainContent_txt_vipno').focus();"
    '        RegisterStartupScript("Popupmessage", "<script language='javascript'>" & scriptString & "</script>")
    '        'Response.Write("<Script Language='Javascript'> document.all['txt_AcctID'].focus(); </Script>")
    '        Return False
    '    End If
    '    If Trim(txt_Password.Text) = "" Then
    '        lbl_ErrMsg.Text = "Please enter your password!"
    '        scriptString = "document.getElementById('ctl00_MainContent_txt_Password').focus();"
    '        RegisterStartupScript("Popupmessage", "<script language='javascript'>" & scriptString & "</script>")
    '        ' Response.Write("<Script Language='Javascript'> document.all['txt_Password'].focus(); </Script>")
    '        Return False
    '    End If
    '    Return True
    'End Function
    'Function CheckCookie() As Boolean
    '    '? Check the status of Cookie
    '    If Request.Cookies.Count = 0 Then
    '        lbl_ErrMsg.Text = "Cookies need to be enabled!"
    '        Return False
    '    Else
    '        Return True
    '    End If
    'End Function
    'Function GroupLogin(ByVal strAcctID As String, ByVal strPassword As String) As String
    '    Dim objuser As New Users
    '    Dim objDS As New DataSet
    '    Dim strAcctlist As String
    '    Dim strResult As String

    '    strResult = ""
    '    objDS = objuser.CheckGroupLogin(strAcctID, strPassword)
    '    If Not objDS Is Nothing Then
    '        If objDS.Tables.Count > 0 Then
    '            If objDS.Tables(0).Columns.Count > 1 Then
    '                Session("group_id") = objDS.Tables(0).Rows(0).Item("group_id").ToString.Trim()
    '                Session("group_login_flag") = "Y"
    '                Session("level_id") = "1"
    '                Dim n As Integer
    '                For n = 0 To objDS.Tables(0).Rows.Count - 1
    '                    strAcctlist = strAcctlist & objDS.Tables(0).Rows(n).Item("acct_id").ToString.Trim() & ","
    '                Next
    '                Session("account_list") = Mid(strAcctlist, 1, strAcctlist.Length - 1)
    '            Else
    '                strResult = objDS.Tables(0).Rows(0).Item(0).ToString.Trim()
    '            End If
    '        End If
    '    End If
    '    Return strResult

    'End Function

    'Function viplogin(ByVal strAcctID As String, ByVal strPassword As String) As String
    '    Dim objDS As New DataSet
    '    Dim objuser As New Users
    '    '  Dim strAcctlist As String
    '    Dim strResult As String

    '    strResult = ""
    '    objDS = objuser.CheckVipLogin(strAcctID, strPassword)
    '    If Not objDS Is Nothing Then
    '        If objDS.Tables.Count > 0 Then
    '            If objDS.Tables(0).Columns.Count > 1 Then
    '                Session("vip_no") = objDS.Tables(0).Rows(0).Item("vip_no").ToString.Trim()
    '                Session("acct_id") = objDS.Tables(0).Rows(0).Item("acct_id").ToString.Trim()
    '                Session("sub_acct_id") = objDS.Tables(0).Rows(0).Item("sub_acct_id").ToString.Trim()
    '                Session("acct_name") = objDS.Tables(0).Rows(0).Item("name").ToString.Trim()
    '                Session("acct") = objDS.Tables(0).Rows(0).Item("acct_name").ToString.Trim()
    '                Session("user_name") = objDS.Tables(0).Rows(0).Item("lname").ToString.Trim() & " " & objDS.Tables(0).Rows(0).Item("fname").ToString.Trim()
    '                If IsDBNull(objDS.Tables(0).Rows(0).Item("level_id")) Then
    '                    Session("level_id") = "9"
    '                ElseIf objDS.Tables(0).Rows(0).Item("level_id").ToString.Trim() = "" Then
    '                    Session("level_id") = "9"
    '                Else
    '                    Session("level_id") = objDS.Tables(0).Rows(0).Item("level_id").ToString.Trim()
    '                End If
    '            Else
    '                strResult = objDS.Tables(0).Rows(0).Item(0).ToString.Trim()
    '            End If
    '        End If
    '    End If

    '    Return strResult
    'End Function

    'Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    '    Dim strErrmsg As String
    '    Try
    '        strErrmsg = Trim(Request.QueryString("msg"))
    '    Catch ex As Exception
    '        strErrmsg = ""
    '    End Try

    '    Select Case strErrmsg
    '        Case "notime"
    '            Call Me.AriseJavaScript("'Online order is blocked for now!\n\rPlease call 1-800-FLY-1800 to make a reservation.'")
    '        Case "no"
    '            Call Me.AriseJavaScript("'No User Found. Please Try again.'")
    '        Case "renew"
    '            Call Me.AriseJavaScript("'This account is expired. Please renew'")
    '        Case "noacct"
    '            Call Me.AriseJavaScript("'No account found. Please try again'")
    '        Case "sessionexp"
    '            Call Me.AriseJavaScript("'Session has expired'")
    '        Case "nonet"
    '            Call Me.AriseJavaScript("'Your account is not set up for on line ordering.'")
    '        Case "pwerror"
    '            Call Me.AriseJavaScript("'Error with password setup. Please try again'")
    '        Case "pw"
    '            Call Me.AriseJavaScript("'Password is incorrect. Please try again'")
    '        Case "dupvip"
    '            Call Me.AriseJavaScript("'Error: Duplicate User. Please Call a FlyteTyme Representative.'")
    '        Case "usract"
    '            Call Me.AriseJavaScript("'User Has been Activated Successfully.'")
    '        Case "Success"
    '            Call Me.AriseJavaScript("'Thank you. Your profile has been created.'")
    '        Case "cnerror"
    '            Call Me.AriseJavaScript("'Connect SQL Server Error!'")
    '        Case "lvl"
    '            Call Me.AriseJavaScript("'This user does not have the correct level permission!'")
    '        Case Else
    '            '--do nothing
    '    End Select
    '    If Not Page.IsPostBack Then
    '        Session.Abandon()
    '    End If

    'End Sub

    '-----------------------------------------------------------------------------------
    '--Sub:AriseJavaScript
    '--Description:To show the error message
    '--Input:ErrorMessage
    '--Output:
    '--11/09/04 - Created (eJay)
    '-----------------------------------------------------------------------------------
    'Private Sub AriseJavaScript(ByVal ErrorMessage As String)

    '    Dim strMessage As String
    '    strMessage = "<script language=""JavaScript"">alert("
    '    strMessage = strMessage & ErrorMessage
    '    strMessage = strMessage & ");"
    '    strMessage = strMessage & "</script>"

    '    RegisterStartupScript("PopUpMessage", strMessage)
    'End Sub

    'Protected Sub btn_Login_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Login.Click
    '    ' Dim message As String = ""
    '    Dim objLogin As New Users
    '    Dim objVIPData As UserData

    '    objVIPData = objLogin.VipUserLoginby(Me.txt_vipno.Text.Trim(), Me.txt_Password.Text.Trim(), Me.txt_acct_id.Text.Trim(), Me.txt_sub_acct_id.Text.Trim())

    '    Dim strCheckUser As String
    '    strCheckUser = objVIPData.check_user

    '    Select Case strCheckUser

    '        '--add case "No Time" by eJAY 2/1/05
    '        Case "No Time"
    '            'Response.Redirect("login.aspx?msg=notime", True)

    '            ' message = Msg.GetErrorMsg(Msg.MsgType.UserLoginNoTime)
    '            Msg.GetErrorMsg(Msg.MsgType.UserLoginNoTime)
    '            Exit Sub
    '        Case "No User"
    '            'Response.Redirect("login.aspx?msg=no", True)

    '            'message = Msg.GetErrorMsg(Msg.MsgType.UserLoginNoUser)
    '            Msg.GetErrorMsg(Msg.MsgType.UserLoginNoUser)
    '            Exit Sub
    '        Case "Dup User"
    '            MySession.UserID = Me.txt_vipno.Text
    '            Response.Redirect("login2.aspx?user_id=" & Me.txt_vipno.Text.Trim(), True)
    '            ' Exit Sub
    '            'Case "Level error"
    '            '    Response.Redirect("login.aspx?msg=lvl", True)
    '            Exit Sub
    '        Case "Password incorrect"
    '            ' message = Msg.GetErrorMsg(Msg.MsgType.UserLoginPwdIncorrect)
    '            'Response.Redirect("login.aspx", True)
    '            Msg.GetErrorMsg(Msg.MsgType.UserLoginPwdIncorrect, Me)
    '            Exit Sub


    '        Case ""
    '            '--Check Account
    '            If objVIPData.checkAccount = "No Account" Then
    '                'Response.Redirect("login.aspx?msg=noacct&user_id=" & Me.txt_vipno.Text.Trim(), True)

    '                'message = Msg.GetErrorMsg(Msg.MsgType.UserLoginNoAccount)
    '                Msg.GetErrorMsg(Msg.MsgType.UserLoginNoAccount, Me)
    '                Exit Sub
    '            Else

    '                '--check close_date
    '                If Not objVIPData.close_date Is Nothing Then

    '                    If IsDate(objVIPData.close_date) Then

    '                        If DateDiff("d", Now(), DateValue(objVIPData.close_date)) < 0 Then

    '                            'Response.Redirect("login.aspx?msg=renew&user_id=" & Me.txt_vipno.Text.Trim(), True)

    '                            'message = Msg.GetErrorMsg(Msg.MsgType.UserLoginReNew)
    '                            Msg.GetErrorMsg(Msg.MsgType.UserLoginReNew, Me)
    '                            Exit Sub
    '                        End If
    '                    Else

    '                        'Response.Redirect("login.aspx?msg=renew&user_id=" & Me.txt_vipno.Text.Trim(), True)

    '                        ' message = Msg.GetErrorMsg(Msg.MsgType.UserLoginReNew)
    '                        Msg.GetErrorMsg(Msg.MsgType.UserLoginReNew, Me)
    '                        Exit Sub
    '                    End If

    '                Else
    '                    '--do nothing

    '                End If

    '                '--check internet
    '                If Not objVIPData.Internet Is Nothing Then
    '                    If objVIPData.Internet.CompareTo("t") <> 0 Then

    '                        'Response.Redirect("login.aspx?msg=nonet&user_id=" & Me.txt_vipno.Text.Trim(), True)

    '                        'message = Msg.GetErrorMsg(Msg.MsgType.UserLoginNoNet)
    '                        Msg.GetErrorMsg(Msg.MsgType.UserLoginNoNet, Me)
    '                        Exit Sub
    '                    End If
    '                Else

    '                    ''Response.Redirect("login.aspx?msg=nonet&user_id=" & Me.txtUser.Text.Trim(), True)
    '                    'Response.Redirect("login.aspx?msg=cnerror&user_id=" & Me.txt_vipno.Text.Trim(), True)

    '                    Msg.GetErrorMsg(Msg.MsgType.UserLoginConnectSQLerror, Me)
    '                    Exit Sub
    '                End If

    '            End If


    '        Case Else
    '            '--do nothing

    '    End Select
    '    If objVIPData.level1_id = "9" Or objVIPData.level1_id = "" Or Not IsNumeric(objVIPData.level1_id) Then

    '        'Response.Redirect("login.aspx?msg=lvl", True)

    '        Msg.GetErrorMsg(Msg.MsgType.UserLoginLevelError, Me)
    '        Exit Sub
    '    End If



    '    MySession.UserID = objVIPData.user_id
    '    MySession.AcctID = objVIPData.acct_id
    '    MySession.SubAcctID = objVIPData.sub_acct_id
    '    MySession.Company = objVIPData.accountcompany
    '    MySession.LevelID = objVIPData.level1_id

    '    MySession.AcctName = Security.SentenceCase(objVIPData.Name)
    '    MySession.Priority = "n"
    '    MySession.Table_ID = objVIPData.table_id
    '    'Session("session_id") = Session.SessionID
    '    'Response.Cookies("agent_flag").Value = "n"
    '    MySession.UserName = Security.SentenceCase(Trim(objVIPData.fname) & " " & Trim(objVIPData.lname))
    '    'Session("phoneNumber") = objVIPData.username

    '    '--add by eJay 2/17/2006 --to Check whether this person is Admin Assistant or not
    '    'Session("admin_assistant_flag") = objVIPData.admin_assistant_flag

    '    'If message.Length > 0 Then
    '    '    ' Page.ClientScript.RegisterStartupScript(GetType(String), "Message", String.Format("<script type='text/javascript'>alert('{0}');</script>", message))
    '    '    Msg.GetErrorMsg(message, Me)
    '    '    Exit Sub
    '    'End If
    '    If Me.txt_vipno.Text.Trim().CompareTo(Me.txt_Password.Text.Trim()) = 0 Then

    '        Response.Redirect("setpw.aspx", True)


    '    Else
    '        Response.Redirect("default.aspx", True)
    '    End If


    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim LocalDebug As String = System.Web.Configuration.WebConfigurationManager.AppSettings("LocalDebug")
        Dim HomePage As String = System.Web.Configuration.WebConfigurationManager.AppSettings("ReservationWebSitePage")

        If LocalDebug = "Y" Then
            HomePage = "login.aspx"
        End If

        If Not Page.IsPostBack Then
            If Not Request.QueryString("guid") Is Nothing Then
                Dim guid As String = Request.QueryString("guid").Trim

                If guid.Length = 36 Then
                    Using user As New Users
                        Dim objVipData As UserData = user.AccessReadSession(guid)
                        Me.Login(objVipData)
                    End Using
                Else
                    If LocalDebug <> "Y" Then
                        Response.Redirect(HomePage, True)
                    End If
                End If
            Else
                If LocalDebug <> "Y" Then
                    Response.Redirect(HomePage, True)
                End If
            End If
        Else
            If LocalDebug <> "Y" Then
                Response.Redirect(HomePage, True)
            End If
        End If
    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLogin.Click
        ' Dim message As String = ""
        Dim objLogin As New Users
        Dim objVIPData As UserData

        objVIPData = objLogin.VipUserLoginby(Me.txt_vipno.Text.Trim(), Me.txt_Password.Text.Trim(), _
                    Me.txt_acct_id.Text.Trim(), Me.txt_sub_acct_id.Text.Trim(), True)

        Me.Login(objVIPData)
    End Sub

    Public Sub Login(ByVal objVIPData As UserData)

        Dim strCheckUser As String
        strCheckUser = objVIPData.check_user

        Select Case strCheckUser
            Case "No Time"
                Msg.GetErrorMsg(Msg.MsgType.UserLoginNoTime)
                Exit Sub
            Case "No User"
                Msg.GetErrorMsg(Msg.MsgType.UserLoginNoUser)
                Exit Sub
                'Case "Dup User"
                '    MySession.UserID = Me.txt_vipno.Text
                '    Response.Redirect("login2.aspx?user_id=" & Me.txt_vipno.Text.Trim(), True)
                '    Exit Sub
            Case "Password incorrect"
                Msg.GetErrorMsg(Msg.MsgType.UserLoginPwdIncorrect, Me)
                Exit Sub

            Case ""
                '--Check Account
                If objVIPData.checkAccount = "No Account" Then
                    Msg.GetErrorMsg(Msg.MsgType.UserLoginNoAccount, Me)
                    Exit Sub
                Else

                    '--check close_date
                    If Not objVIPData.close_date Is Nothing Then

                        If IsDate(objVIPData.close_date) Then

                            If DateDiff("d", Now(), DateValue(objVIPData.close_date)) < 0 Then
                                Msg.GetErrorMsg(Msg.MsgType.UserLoginReNew, Me)
                                Exit Sub
                            End If
                        Else
                            Msg.GetErrorMsg(Msg.MsgType.UserLoginReNew, Me)
                            Exit Sub
                        End If

                    Else
                        '--do nothing
                    End If

                    '--check internet
                    If Not objVIPData.Internet Is Nothing Then
                        If objVIPData.Internet.CompareTo("t") <> 0 Then
                            Msg.GetErrorMsg(Msg.MsgType.UserLoginNoNet, Me)
                            Exit Sub
                        End If
                    Else
                        Msg.GetErrorMsg(Msg.MsgType.UserLoginConnectSQLerror, Me)
                        Exit Sub
                    End If

                End If

            Case Else
                '--do nothing
        End Select

        If objVIPData.level1_id = "9" Or objVIPData.level1_id = "" Or Not IsNumeric(objVIPData.level1_id) Then
            Msg.GetErrorMsg(Msg.MsgType.UserLoginLevelError, Me)
            Exit Sub
        End If

        MySession.UserID = objVIPData.user_id
        MySession.AcctID = objVIPData.acct_id
        MySession.SubAcctID = objVIPData.sub_acct_id
        MySession.Company = objVIPData.accountcompany
        MySession.LevelID = objVIPData.level1_id

        MySession.AcctName = Security.SentenceCase(objVIPData.Name)
        MySession.Priority = "n"
        MySession.Table_ID = objVIPData.table_id
        MySession.UserName = Security.SentenceCase(Trim(objVIPData.fname) & " " & Trim(objVIPData.lname))

        If Me.txt_vipno.Text.Trim.Length > 0 AndAlso _
                    Me.txt_vipno.Text.Trim().CompareTo(Me.txt_Password.Text.Trim()) = 0 Then
            Response.Redirect("setpw.aspx", True)
        Else
            Response.Redirect("default.aspx", True)
        End If
    End Sub

End Class
