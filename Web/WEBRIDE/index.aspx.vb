Imports Business

Partial Class index
    Inherits System.Web.UI.Page

    Public BannerMsg As String

#Region "Protected Sub Page Users Parts"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.Request.QueryString("action") Is Nothing Then
            Dim action As String = Page.Request.QueryString("action")

            If action = "logout" Then
                Session.Abandon()
                Response.Redirect("index.aspx", True)
            End If
        End If

        Call Me.GetBannerMessage()

    End Sub

#End Region

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

