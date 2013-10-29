Imports Business

Partial Class MasterPageMenu
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not MySession.LevelID Is Nothing AndAlso IsNumeric(MySession.LevelID) Then
            If Val(MySession.LevelID) < 9 AndAlso Val(MySession.LevelID) > 0 Then
                Me.tdBilling.Visible = True
            Else
                Me.tdBilling.Visible = False
            End If
        Else
            Me.tdBilling.Visible = False
        End If
    End Sub

End Class

