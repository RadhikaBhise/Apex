Imports Business

Partial Class corp_masterpage
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.btnSubmit.Attributes.Add("onclick", "return BatchValidatecorporateLogin('" & Me.txtLogin.ClientID & "','" & Me.txtPassword.ClientID & "');")
    End Sub


    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click


        Using corp As New Corporate

            Dim out As Integer = corp.Login(Me.txtLogin.Text, Me.txtPassword.Text)

            '## Output  1:  login successfully
            '##         0:  Unknow Excetions
            '##         -1: No user found
            '##         -2: Password Incorrect
            '##     `   -3: Account is expired
            '##         -4: Account is not set up for online ordering
            Select Case out
                Case 1
                    MySession.AcctID = corp.AcctID
                    MySession.SubAcctID = corp.SubAcctID
                    MySession.Company = corp.Company
                    MySession.Table_ID = corp.Table_ID  '--add by daniel for save the table_id 06/12/2007
                    Response.Redirect("corp_rideinquiry.aspx")
                Case -1
                    Msg.GetErrorMsg(Msg.MsgType.CorporateLoginNoAcctFound, Me.Page)
                Case -2
                    Msg.GetErrorMsg(Msg.MsgType.CorporateLoginPasswordIncorrect, Me.Page)
                Case -3
                    Msg.GetErrorMsg(Msg.MsgType.CorporateLoginAcctExpired, Me.Page)
                Case -4
                    Msg.GetErrorMsg(Msg.MsgType.CorporateLoginNotSetUpForOnlineOrdering, Me.Page)
                Case 0
                    Msg.GetErrorMsg(Msg.MsgType.CorporateLoginUnknowException, Me.Page)
            End Select

        End Using
    End Sub
End Class

