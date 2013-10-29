Imports Business

Partial Class setpw
    Inherits System.Web.UI.Page

    Sub Proof(ByVal objectSource As Object, ByVal args As ServerValidateEventArgs) Handles ProofLength.ServerValidate
        Dim intvalue As String = args.Value

        If (intvalue.Length < 4) Then
            args.IsValid = False
        Else
            args.IsValid = True

        End If

    End Sub

    Protected Sub ImgbtnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbtnSubmit.Click

        If Not MySession.UserID Is Nothing AndAlso Not MySession.AcctID Is Nothing AndAlso Not MySession.SubAcctID Is Nothing Then
            If Trim(MySession.UserID) <> "" And Trim(MySession.AcctID) <> "" And Trim(MySession.SubAcctID) <> "" Then
                Dim objUsers As New Users
                Dim UpdatedSuccessful As Boolean
                UpdatedSuccessful = objUsers.UpdatePassword(Trim(Me.txtPassword.Text), MySession.UserID.ToString, MySession.AcctID.ToString, MySession.SubAcctID.ToString, MySession.Company.ToString)
                If UpdatedSuccessful = True Then
                    Response.Redirect("default.aspx", True)
                Else
                    Msg.GetErrorMsg(Msg.MsgType.SetUPPasswordError, Me)
                    'Response.Redirect("login.aspx")
                End If
            Else
                Msg.GetErrorMsg(Msg.MsgType.SetUPPasswordError, Me)
                ' Response.Redirect("login.aspx?msg=pwerror")
            End If
        Else
            Msg.GetErrorMsg(Msg.MsgType.SetUPPasswordError, Me)
            ' Response.Redirect("login.aspx?msg=pwerror")
        End If
     
    End Sub


End Class
