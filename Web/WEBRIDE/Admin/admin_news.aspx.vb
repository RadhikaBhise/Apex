Imports Business
Imports System.Data

Partial Class Admin_admin_news
    Inherits System.Web.UI.Page

#Region "Protected Sub Page Users Parts"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strmsg As String
        strmsg = Request.QueryString("msg")
        If Not strmsg Is Nothing Then
            Select Case strmsg
                Case "CreateSuccess"
                    Call Me.AriseJavaScript("'Added News successfully!'")
                Case Else

            End Select
        End If
        If Not Page.IsPostBack Then
            Call Me.Load_News()
        End If

    End Sub

    Protected Sub dgverbage_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgverbage.ItemCommand
        If e.CommandName = "Delete" Then
            Dim delUsers As New News
            Dim delint As Int16
            Dim delid As String

            delid = e.Item.Cells(0).Text.Trim
            delint = delUsers.Delete_NewsInformations(delid)
            delUsers.Dispose()
            delUsers = Nothing
            If delint = 1 Then
                Me.AriseJavaScript("'Deleted successfully!'")
            Else
                Me.AriseJavaScript("'Deleted failed,please try later!'")
            End If

            Response.Redirect("admin_news.aspx", True)

        End If

    End Sub

    Protected Sub dgverbage_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgverbage.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim strsummary_title As String
            strsummary_title = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "summary_title"))
            CType(e.Item.FindControl("lblsummary_title"), Label).Text = strsummary_title

            Dim strsummary_text As String
            strsummary_text = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "summary_text"))
            CType(e.Item.FindControl("lblsummary_text"), Label).Text = strsummary_text

            CType(e.Item.FindControl("btnLinkModify"), HyperLink).Text = "Modify"
            Dim id As String
            id = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "id"))
            CType(e.Item.FindControl("btnLinkModify"), HyperLink).NavigateUrl = "admin_news_edit.aspx?style=edit&id=" & id

            CType(e.Item.FindControl("btnLinkDelete"), LinkButton).ToolTip = "Delete"
            CType(e.Item.FindControl("btnLinkDelete"), LinkButton).Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            'CType(e.Item.FindControl("btnLinkDelete"), HyperLink).Text = "Delete"
            'CType(e.Item.FindControl("btnLinkDelete"), HyperLink).NavigateUrl = "admin_verbage.aspx?style=delete&Acct_id=" & stracctid & "&sub_acct_id=" & strsubacctid

        End If
    End Sub

#End Region

#Region "Private Sub & Functions"

    '-----------------------------------------------------------------------------------
    '--Sub:AriseJavaScript
    '--Description:To show the error message
    '--Input:ErrorMessage
    '--Output:
    '--11/09/04 - Created (eJay)
    '-----------------------------------------------------------------------------------
    Private Sub AriseJavaScript(ByVal ErrorMessage As String)

        Dim strMessage As String
        strMessage = "<script language=""JavaScript"">alert("
        strMessage = strMessage & ErrorMessage
        strMessage = strMessage & ");"
        'strMessage = strMessage & "document.forms[0].txtUser.focus();"
        'strMessage = strMessage & "document.all['txtUsername'].focus();"
        strMessage = strMessage & "</script>"

        'Response.Write(strMessage)
        'RegisterStartupScript("PopUpMessage", "<script language=""JavaScript"">document.all['password0'].focus();</script>")
        RegisterStartupScript("PopUpMessage", strMessage)

    End Sub

    Private Sub Load_News()
        Dim objNews As New News
        Dim objDataSet As DataSet
        objDataSet = objNews.GetALLNewsInformations()
        If Not objDataSet Is Nothing Then
            If objDataSet.Tables.Count > 0 Then
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    With Me.dgverbage
                        .DataSource = objDataSet
                        .DataBind()
                    End With
                Else
                    With Me.dgverbage
                        .DataSource = Nothing
                        .DataBind()
                    End With
                End If
            Else
                With Me.dgverbage
                    .DataSource = Nothing
                    .DataBind()
                End With
            End If
        Else
            With Me.dgverbage
                .DataSource = Nothing
                .DataBind()
            End With
        End If

    End Sub

#End Region

End Class
