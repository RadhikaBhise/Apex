Imports Business
Imports System.Data
Imports System.Web.Configuration.WebConfigurationManager

Partial Class group_masterpage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.btnSubmit.Attributes.Add("onclick", "return BatchValidateLogin();")

        If Not Page.Request.QueryString("action") Is Nothing Then
            Dim action As String = Page.Request.QueryString("action")

            If action = "logout" Then
                Session.Abandon()
                Response.Redirect("group_login.aspx", True)
            End If
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click
        Dim objLogin As New Group
        Dim objVIPData As UserData

        objVIPData = objLogin.Login(Me.txtLoginName.Text.Trim(), Me.txtPassword.Text.Trim())

        Dim strCheckUser As String
        strCheckUser = objVIPData.check_user

        Select Case strCheckUser
            Case "No Time"
                Response.Redirect("group_login.aspx?msg=notime", True)
                Exit Sub
            Case "No User"
                Response.Redirect("group_login.aspx?msg=no", True)
                Exit Sub
            Case "Dup User"
                Response.Redirect("group_login.aspx?user_id=" & Me.txtLoginName.Text.Trim(), True)
                Exit Sub
            Case "Password incorrect"
                Response.Redirect("group_login.aspx?msg=pw", True)
                Exit Sub
            Case "nowebgroup"
                Response.Redirect("group_login.aspx?msg=nowebgroup", True)
                Exit Sub
                'disabled by lily 03/10/2008
                'Case ""
                '    '--Check Account
                '    If objVIPData.checkAccount = "No Account" Then
                '        Response.Redirect("group_login.aspx?msg=noacct&user_id=" & Me.txtLoginName.Text.Trim(), True)
                '        Exit Sub
                '    Else
                '        '--check close_date
                '        If Not objVIPData.close_date Is Nothing Then

                '            If IsDate(objVIPData.close_date) Then

                '                If DateDiff("d", Now(), DateValue(objVIPData.close_date)) < 0 Then

                '                    Response.Redirect("group_login.aspx?msg=renew&user_id=" & Me.txtLoginName.Text.Trim(), True)
                '                    Exit Sub

                '                End If
                '            Else

                '                Response.Redirect("group_login.aspx?msg=renew&user_id=" & Me.txtLoginName.Text.Trim(), True)
                '                Exit Sub

                '            End If

                '        Else
                '            '--do nothing

                '        End If

                '        '--check internet
                '        If Not objVIPData.Internet Is Nothing Then
                '            If objVIPData.Internet.CompareTo("t") <> 0 Then

                '                Response.Redirect("group_login.aspx?msg=nonet&user_id=" & Me.txtLoginName.Text.Trim(), True)
                '                Exit Sub

                '            End If
                '        Else
                '            Response.Redirect("group_login.aspx?msg=nonet&user_id=" & Me.txtLoginName.Text.Trim(), True)
                '            Exit Sub
                '        End If

                '    End If


            Case Else
                '--do nothing

        End Select
        'added by lily 03/10/2008
        ' --Check Account
        If objVIPData.checkAccount = "No Account" Then
            Response.Redirect("group_login.aspx?msg=noacct&user_id=" & Me.txtLoginName.Text.Trim(), True)
            Exit Sub
        Else
            '--check close_date
            If Not objVIPData.close_date Is Nothing Then

                If IsDate(objVIPData.close_date) Then

                    If DateDiff("d", Now(), DateValue(objVIPData.close_date)) < 0 Then

                        Response.Redirect("group_login.aspx?msg=renew&user_id=" & Me.txtLoginName.Text.Trim(), True)
                        Exit Sub

                    End If
                Else

                    Response.Redirect("group_login.aspx?msg=renew&user_id=" & Me.txtLoginName.Text.Trim(), True)
                    Exit Sub

                End If

            Else
                '--do nothing

            End If

            '--check internet
            If Not objVIPData.Internet Is Nothing Then
                If objVIPData.Internet.CompareTo("t") <> 0 Then

                    Response.Redirect("group_login.aspx?msg=nonet&user_id=" & Me.txtLoginName.Text.Trim(), True)
                    Exit Sub

                End If
            Else
                Response.Redirect("group_login.aspx?msg=nonet&user_id=" & Me.txtLoginName.Text.Trim(), True)
                Exit Sub
            End If

        End If

        'modified by lily 01/10/2008
        'MySession.UserID = "webres"     '"webridegp"   'vip_no
        MySession.UserID = System.Web.Configuration.WebConfigurationManager.AppSettings("GroupOrderDefaultUserID")
        MySession.AcctName = objVIPData.Name
        MySession.Table_ID = objVIPData.table_id
        MySession.SubAcctID = objVIPData.sub_acct_id
        MySession.Company = objVIPData.Company
        MySession.AcctID = objVIPData.acct_id
        MySession.UserName = Security.SentenceCase(Trim(objVIPData.fname) & " " & Trim(objVIPData.lname))
        MySession.Priority = IIf(objVIPData.priority Is Nothing, "", objVIPData.priority)

        Response.Redirect("./group_orderform.aspx", True)
    End Sub

End Class

