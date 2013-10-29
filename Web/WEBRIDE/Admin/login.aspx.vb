
Partial Class login
    Inherits System.Web.UI.Page

    Protected Sub Log_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Log.ServerClick
        If Me.username.Value = "ALEPH" And Me.password.Value = "123456" Then
            Session("admin") = "Y"
            Response.Redirect("admin_main.aspx", True)
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Log.Attributes.Add("onclick", "return batchValidate()")

        If Not Page.IsPostBack Then
            Dim msg As String
            msg = Request.QueryString("msg")
            If msg = "logoff" Then
                Session.Abandon()
                Response.Redirect("login.aspx", True)
            Else
                '--do nothing
            End If
        End If

    End Sub

End Class
