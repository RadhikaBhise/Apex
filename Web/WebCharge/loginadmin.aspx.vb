Imports Business

Partial Class loginadmin
    Inherits System.Web.UI.Page

    Protected Sub btn_Login_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Login.Click
        Dim objusers As New Users
        Dim strReturn As String
        Dim strReDir As String
        strReturn = objusers.Check_webcharge_admin(Me.txt_AcctID.Text.Trim(), Me.txt_pwd.Text.Trim())
        If strReturn = Me.txt_AcctID.Text.Trim() Then
            strReDir = "Admin/default.aspx?admin_id=" & strReturn
            Session("admin") = strReturn
            Response.Redirect(strReDir, True)
        Else
            Response.Redirect("logonadmin.aspx?errcode=invalidlogon", True)
        End If
    End Sub

    Protected Sub btn_Clear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Clear.Click
        Me.txt_AcctID.Text = String.Empty
        Me.txt_pwd.Text = String.Empty
        Me.txt_subAcctid.Text = String.Empty
        Me.ddlCompany.SelectedIndex = 0
        lbl_ErrMsg.Text = String.Empty
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.btn_Login.Attributes.Add("onclick", "return validate();")

        Dim strLogInfo As String = String.Empty
        If Not (Request.QueryString("LogOff") Is Nothing) Then
            strLogInfo = Request.QueryString("LogOff")
        End If

        Dim errmsg As String
        errmsg = Request.QueryString("errcode")
        Select Case errmsg
            Case "invalidlogon"
                Call Me.AriseJavaScript("'Invalid Logon!  Please try again...'")
            Case Else
                '--do nothing
        End Select
    End Sub

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

        'Response.Write(strMessage)
        'RegisterStartupScript("PopUpMessage", "<script language=""JavaScript"">document.all['password0'].focus();</script>")
        RegisterStartupScript("PopUpMessage", strMessage)

    End Sub

End Class
