Imports Business

Partial Class billing
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not MySession.AcctID Is Nothing AndAlso MySession.AcctID.Length > 0 AndAlso _
                    Not MySession.UserID Is Nothing AndAlso MySession.UserID.Length > 0 Then

                Dim guid As String = ""
                Using user As New Users
                    guid = user.AccessWriteSession()
                End Using

                If guid.Trim.Length = 36 Then
                    Dim BillingWebSitePage As String = System.Web.Configuration.WebConfigurationManager.AppSettings("BillingWebSitePage")
                    Dim BillingUrl As String = String.Format("{0}?guid={1}", BillingWebSitePage, guid)
                    Response.Redirect(BillingUrl, True)
                Else
                    Response.Redirect("index.aspx")
                End If
            Else
                Response.Redirect("index.aspx")
            End If
        End If
    End Sub

End Class
