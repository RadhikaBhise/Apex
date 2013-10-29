Imports Business
Imports System.Data

Partial Class index_news
    Inherits System.Web.UI.Page

#Region "Public News Informations Users Parts"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Call Me.Load_Date()
        End If
    End Sub

#End Region

#Region "Public Events Users Functions"

    Public Sub Load_Date()
        Dim objNews As New Business.News
        Dim objDataSet As New DataSet
        objDataSet = objNews.GetIndex_NewsInformations()

        If Not objDataSet Is Nothing AndAlso objDataSet.Tables.Count > 0 Then
            With Me.dlNews
                .DataSource = objDataSet.Tables(0).DefaultView
                .DataBind()
            End With
        End If

    End Sub

#End Region

End Class
