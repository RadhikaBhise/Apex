Imports DataAccess
Imports System.Data
Imports System.Data.SqlClient

Public Class News
    Inherits CommonDB

#Region "Get News informations"

    '--Region GetIndex_NewsInformations creter by daniel for index.aspx 16/11/06
    Public Function GetIndex_NewsInformations() As DataSet
        Dim tmpDS As New DataSet
        Dim strSQL As String
        strSQL = "APEX_wr_news_index_get"

        Try

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                tmpDS = Me.QueryData("GetIndex_NewsInformations")

            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
            tmpDS = Nothing
        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return tmpDS

    End Function

    '--Region GetNewsInformationsByID creter by daniel for index.aspx 16/11/06
    Public Function GetNewsInformationsByID(ByVal id As Integer) As DataSet
        Dim tmpDS As New DataSet
        Dim strSQL As String
        strSQL = "APEX_wr_news_get_byID"

        Try

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@id", id)

                tmpDS = Me.QueryData("GetNewsInformationsByID")

            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
            tmpDS = Nothing
        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return tmpDS

    End Function

    '--Region GetNewsInformationsByID creter by daniel for index.aspx 16/11/06
    Public Function GetALLNewsInformations() As DataSet
        Dim tmpDS As New DataSet

        Try
            tmpDS = Me.QueryData("Exec APEX_wr_news_selectAll", "GetALLNewsInformations")
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
            tmpDS = Nothing
        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return tmpDS

    End Function

#End Region

#Region "Add & Edit & Remove News informations"

    '--Region GetIndex_NewsInformations creter by daniel for index.aspx 16/11/06
    Public Function Add_NewsInformations(ByVal id As String, ByVal summary_title As String, _
                                            ByVal summary_text As String, ByVal full_title As String, _
                                            ByVal full_text As String) As Boolean
        Dim tmpDS As New DataSet
        Dim strSQL As String
        strSQL = "APEX_wr_news_add_update"

        Try

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@id", id)
                .Parameters.AddWithValue("@summary_title", summary_title)
                .Parameters.AddWithValue("@summary_text", summary_text)
                .Parameters.AddWithValue("@full_title", full_title)
                .Parameters.AddWithValue("@full_text", full_text)

                tmpDS = Me.QueryData("Add_NewsInformations")
                Add_NewsInformations = True

            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
            Add_NewsInformations = False
            tmpDS = Nothing
        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return Add_NewsInformations

    End Function

    '--Region GetIndex_NewsInformations creter by daniel for index.aspx 16/11/06
    Public Function Delete_NewsInformations(ByVal id As String) As Integer
        Dim tmpDS As New DataSet
        Dim strSQL As String
        strSQL = "APEX_wr_news_deletebyId"

        Try

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@id", id)

                tmpDS = Me.QueryData("Delete_NewsInformations")
                Delete_NewsInformations = 1

            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
            Delete_NewsInformations = 0
            tmpDS = Nothing
        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return Delete_NewsInformations

    End Function

#End Region

#Region "Banner Maintance"

    '--Region GetIndex_NewsInformations creter by daniel for index.aspx 16/11/06
    Public Function GetBannerInformations() As DataSet
        Dim tmpDS As New DataSet
        Dim strSQL As String
        strSQL = "APEX_wr_getBanner"

        Try

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                tmpDS = Me.QueryData("GetBannerInformations")

            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
            tmpDS = Nothing
        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return tmpDS

    End Function

    '--Region GetBannerMessage creter by daniel for index.aspx 16/11/06
    '## MsgStyle    1/11/2008   Add MessageStyle by yang
    '## 0   Default style
    '## 1   Bold & Red
    Public Function GetBannerMessage(ByVal MsgStyle As Int16) As String
        Dim tmpDS As New DataSet
        Dim strSQL As String
        strSQL = "APEX_wr_getBanner"

        Try

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                tmpDS = Me.QueryData("GetBannerMessage")

            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
            tmpDS = Nothing
        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        If Not tmpDS Is Nothing Then
            If tmpDS.Tables.Count > 0 Then
                If tmpDS.Tables(0).Rows.Count > 0 Then
                    Select Case MsgStyle
                        Case 1
                            GetBannerMessage = "<a style='font-weight:bold;color:Red;'>" & tmpDS.Tables(0).Rows(0).Item("content") & "</a>"
                        Case Else
                            GetBannerMessage = tmpDS.Tables(0).Rows(0).Item("content")
                    End Select
                Else
                    GetBannerMessage = ""
                End If
            Else
                GetBannerMessage = ""
            End If
        Else
            GetBannerMessage = ""
        End If

        Return GetBannerMessage

    End Function

    '--Region GetIndex_NewsInformations creter by daniel for index.aspx 16/11/06
    Public Function Add_BannerInformations(ByVal content As String) As Boolean
        Dim tmpDS As New DataSet
        Dim strSQL As String
        strSQL = "APEX_wr_banner_add_update"

        Try

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@content", content)

                tmpDS = Me.QueryData("Add_BannerInformations")
                Add_BannerInformations = True

            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
            Add_BannerInformations = False
            tmpDS = Nothing
        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return Add_BannerInformations

    End Function

#End Region

End Class
