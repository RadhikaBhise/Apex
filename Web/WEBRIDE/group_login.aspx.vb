Imports Business
Imports System.Data

Partial Class group_login
    Inherits System.Web.UI.Page

    Public BannerMsg As String

#Region "Protected Sub Page User"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Errmsg As String
        Errmsg = Trim(Request.QueryString("msg"))
        Select Case Errmsg

            Case "no"
                Call Me.AriseJavaScript("'No User Found. Please Try again'")
            Case "closed"
                Call Me.AriseJavaScript("'This account is expired.'")
            Case "noacct"
                Call Me.AriseJavaScript("'No account found. Please try again'")
            Case "sessionexp"
                Call Me.AriseJavaScript("'Session has expired'")
            Case "nonet"
                Call Me.AriseJavaScript("'Your account is not set up for on line ordering.'")
            Case "pwerror"
                Call Me.AriseJavaScript("'Error with password setup. Please try again'")
            Case "nowebgroup"
                Call Me.AriseJavaScript("'This account is not set up for web group reservation..'")
            Case "pw"
                Call Me.AriseJavaScript("'Password is incorrect. Please try again'")
            Case "cnerror"
                Call Me.AriseJavaScript("'Connect SQL Server Error!'")
            Case "Success"
                Call Me.AriseJavaScript("'Thank you. Your profile has been created.'")
            Case "logout"
                Session.Abandon()
                Response.Redirect("./group_login.aspx", True)
            Case Else
                '--do nothing
        End Select

        Call Me.GetBannerMessage()

    End Sub

#End Region

#Region "Public Sub Users Part"

    Private Sub GetBannerMessage()
        Using objNews As New Business.News
            Dim strbannermsg As String

            strbannermsg = objNews.GetBannerMessage(0)

            If strbannermsg <> "" Then
                BannerMsg = strbannermsg
            Else
                BannerMsg = ""
            End If
        End Using
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

#End Region

End Class
