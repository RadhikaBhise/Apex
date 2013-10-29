Imports Business

Partial Class corp_selectuser
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.LoadUser()
        End If
    End Sub

    Private Sub LoadUser()
        Using user As New Users
            Dim ds As DataSet = user.GetOrderForUser(MySession.AcctID, MySession.SubAcctID, MySession.Company)

            If Not ds Is Nothing AndAlso ds.Tables.Count > 0 Then
                Me.ddlUserID.DataSource = ds.Tables(0).DefaultView
                Me.ddlUserID.DataTextField = "vip_info"
                Me.ddlUserID.DataValueField = "vip_no"
                Me.ddlUserID.DataBind()
            End If

            Me.ddlUserID.Items.Insert(0, New ListItem("-", ""))
        End Using
    End Sub

    Protected Sub ddlUserID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlUserID.SelectedIndexChanged
        If Me.ddlUserID.SelectedValue.Trim.Length > 0 Then
            Dim UserID As String = Me.ddlUserID.SelectedValue
            Response.Redirect("corp_orderform.aspx?userid=" & UserID)
        End If
    End Sub

End Class
