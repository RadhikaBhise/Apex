Imports Business

Partial Class corp_login
    Inherits System.Web.UI.Page

    Public BannerMsg As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.Request.QueryString("action") Is Nothing Then
            Dim action As String = Page.Request.QueryString("action")

            If action = "logout" Then
                Session.Abandon()
                Response.Redirect("corp_login.aspx", True)
            End If
        End If

        Call Me.GetBannerMessage()

    End Sub
    'Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
    '    Using corp As New Corporate
    '        Dim out As Integer = corp.Login(Me.txtName.Text, Me.txtPwd.Text)

    '        '## Output  1:  login successfully
    '        '##         0:  Unknow Excetions
    '        '##         -1: No user found
    '        '##         -2: Password Incorrect
    '        '##     `   -3: Account is expired
    '        '##         -4: Account is not set up for online ordering
    '        Select Case out
    '            Case 1
    '                MySession.AcctID = corp.AcctID
    '                MySession.SubAcctID = corp.SubAcctID
    '                MySession.Company = corp.Company
    '                Response.Redirect("corporate_rideinquiry.aspx")
    '            Case -1
    '                Msg.GetErrorMsg(Msg.MsgType.CorporateLoginNoAcctFound, Me)
    '            Case -2
    '                Msg.GetErrorMsg(Msg.MsgType.CorporateLoginPasswordIncorrect, Me)
    '            Case -3
    '                Msg.GetErrorMsg(Msg.MsgType.CorporateLoginAcctExpired, Me)
    '            Case -4
    '                Msg.GetErrorMsg(Msg.MsgType.CorporateLoginNotSetUpForOnlineOrdering, Me)
    '            Case 0
    '                Msg.GetErrorMsg(Msg.MsgType.CorporateLoginUnknowException, Me)
    '        End Select
    '    End Using
    'End Sub

#Region "Private Sub Users Parts"

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

#End Region

End Class
