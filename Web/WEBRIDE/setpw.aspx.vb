Imports Business

Partial Class setpw
    Inherits System.Web.UI.Page

    Protected Sub ImgbtnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbtnSubmit.Click
        If Not MySession.UserID Is Nothing AndAlso Not MySession.AcctID Is Nothing AndAlso Not MySession.SubAcctID Is Nothing Then
            If Trim(MySession.UserID) <> "" And Trim(MySession.AcctID) <> "" And Trim(MySession.SubAcctID) <> "" Then
                Dim objUsers As New Users
                Dim UpdatedSuccessful As Boolean
                UpdatedSuccessful = objUsers.UpdatePassword(Trim(Me.txtPassword.Text), MySession.UserID.ToString, MySession.AcctID.ToString, MySession.SubAcctID.ToString, MySession.Company.ToString)
                If UpdatedSuccessful = True Then
                    Response.Redirect("order.aspx", True)
                Else
                    Response.Redirect("index.aspx?msg=pwerror")
                End If
            Else
                Response.Redirect("index.aspx?msg=pwerror")
            End If
        Else
            Response.Redirect("index.aspx?msg=pwerror")
        End If
    End Sub

End Class
