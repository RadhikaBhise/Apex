Imports Business

Partial Class newAddress
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim vip_no As String
        'vip_no = Request.QueryString("vip_no")

        'Me.lblVipNo.Text = vip_no
        Me.lblVipNo.Text = MySession.UserID

        If Not Page.IsPostBack Then
            Me.Stop1.AddNewAddress()
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click

        Dim ord As New OperatorData
        Me.Stop1.GetValueFromScreen(ord)
        Dim result As Integer

        Using objuser As New Users
            result = objuser.AddNewAddewss(Me.lblVipNo.Text.Trim, ord)
            If result <= 0 Then
                Me.lblMsg.Text = "Failed to add new address,please try again!"
                Me.lblMsg.Visible = True
            Else
                Response.Write("<script>window.close(); window.opener.location=window.opener.location.href;</script>")
            End If
        End Using
    End Sub
End Class
