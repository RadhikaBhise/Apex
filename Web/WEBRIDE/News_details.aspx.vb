Imports Business
Imports System.Data
Imports System.Data.SqlClient

Partial Class News_details
    Inherits System.Web.UI.Page

    Public Full_Title As String = ""
    Public Full_Text As String = ""

#Region "Protected Sub Pages Parts"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strmsgid As String
        strmsgid = Request.QueryString("id")

        If Not Page.IsPostBack Then
            If Not strmsgid Is Nothing Then
                Call Me.Load_Date(strmsgid)
            End If
        End If

    End Sub

#End Region

#Region "Public Sub Pages Parts"

    Public Sub Load_Date(ByVal id As String)
        Dim objNews As New Business.News
        Dim objDataSet As New DataSet
        objDataSet = objNews.GetNewsInformationsByID(Convert.ToInt32(id))
        If Not objDataSet Is Nothing Then
            If objDataSet.Tables.Count > 0 Then
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Full_Title = Me.Check_DBNULL(objDataSet.Tables(0).Rows(0).Item("full_title"))
                    Full_Text = Me.Check_DBNULL(objDataSet.Tables(0).Rows(0).Item("full_text"))
                Else
                    Full_Title = ""
                    Full_Text = ""
                End If
            Else
                Full_Title = ""
                Full_Text = ""
            End If
        Else
            Full_Title = ""
            Full_Text = ""
        End If

    End Sub

    '-------------------------------------------------------------------
    '--Function:Check_DBNULL
    '--Description:Check the value 
    '--Input:Value
    '--Output:Nothing for DBNULL
    '--11/4/04 - Created (eJay)
    '-------------------------------------------------------------------
    Private Function Check_DBNULL(ByVal Value As Object) As String

        If IsDBNull(Value) = True Then
            Return Nothing
        Else
            Return Convert.ToString(Value).Trim()
        End If

    End Function

#End Region

End Class
