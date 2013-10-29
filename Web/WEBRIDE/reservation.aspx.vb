
Partial Class reservation
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Page.Response.Redirect("order.aspx", True)
    End Sub

End Class
