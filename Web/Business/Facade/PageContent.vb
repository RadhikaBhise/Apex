Imports Microsoft.VisualBasic
Imports System.Data
Imports DataAccess

Public Class PageContent
    Inherits CommonDB

    '-----------------------------------------------------------------
    '--Function:  PageGet
    '--Description: get all pages
    '--Table:       content_page
    '--Input :              
    '--OutPut:              dataset
    '-- 3/2/06 - Created (eJay)
    '-----------------------------------------------------------------
    Public Function PageGet() As DataSet
        Dim strSql As String = "SELECT page_id,title,content,Editable_flag FROM content_page(NOLOCK) WHERE Editable_flag='Y'"
        Return Me.QueryData(strSql, "content_page")

    End Function

    '-----------------------------------------------------------------
    '--Function:  ContentGet
    '--Description: get content for special page
    '--Table:       content_page
    '--Input :              
    '--OutPut:              string
    '-- 3/2/06 - Created (eJay)
    '-----------------------------------------------------------------
    Public Function ContentGet(ByVal Page_id As Int32) As String
        Dim strContent As String
        strContent = ""
        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MTC_contentget"
                .Parameters.AddWithValue("@page_id", Page_id)
                Me.Reader = .ExecuteReader
            End With
            If Me.Reader.Read Then
                strContent = Convert.ToString(Me.Reader.Item("content")).Trim
            End If
        Catch ex As Exception

        Finally

            Me.CloseConnection()

        End Try

        Return strContent

    End Function

    '-----------------------------------------------------------------
    '--Function:  ContentUpdate
    '--Description: update content for special page
    '--Table:       content_page
    '--Input :              
    '--OutPut:              True for Success ;false for Failed 
    '-- 3/2/06 - Created (eJay)
    '-----------------------------------------------------------------
    Public Function ContentUpdate(ByVal Page_id As Int32, ByVal Content As String, ByVal HTML As String) As Boolean

        Dim blnResult As Boolean = False

        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MTC_contentupdate"
                .Parameters.AddWithValue("@page_id", Page_id)
                .Parameters.AddWithValue("@content", Content.ToString.Trim())
                .Parameters.AddWithValue("@HTML", HTML)
                .ExecuteNonQuery()

            End With

            blnResult = True
        Catch ex As Exception

            blnResult = False
        Finally
            Me.CloseConnection()

        End Try

        Return blnResult

    End Function

End Class
