
Partial Class voucherimage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request.QueryString("vno") Is Nothing Then
            Me.Header.Title = Request.QueryString("vno").Trim

            If Not Request.QueryString("cno") Is Nothing Then
                Dim ConfNo As String = Request.QueryString("cno").Trim

                If ConfNo.Length >= 9 Then
                    '--2008/04/30 spring changed the URL to 216.254.75.170 
                    Me.Image1.ImageUrl = "http://216.254.75.170:8088/vimage/" & _
                        Left(ConfNo, 4) & "/" & Mid(ConfNo, 5, 3) & "/" & ConfNo & ".jpg"
                End If
            End If
        End If
    End Sub

End Class
