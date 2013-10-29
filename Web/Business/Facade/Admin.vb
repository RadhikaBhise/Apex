Imports System.Data
Imports System.Data.SqlClient

Public Class Admin
    Inherits DataAccess.CommonDB

#Region " Get emails for send email/Admin Module"
    '------------------------------------------------------------------------------------------
    '--Function:GetVipDetails
    '--Description:if user input SQL ,use to preview the vip details before send the email
    '--Input:SQL
    '--Output:all validation email address;Failed--SQL error
    '--2/14/05 - Created (jack)
    '------------------------------------------------------------------------------------------
    Public Function GetVipDetails(ByVal SQL As String) As DataSet

        Dim tmpDS As DataSet
        tmpDS = Nothing

        Try

            tmpDS = Me.QueryData(SQL, "GetVipDetails")

        Catch ex As Exception

            tmpDS = Nothing

        Finally
            '--do nothing

        End Try

        Return tmpDS

    End Function



    '------------------------------------------------------------------------------------------
    '--Function:GetEmailAddress
    '--Description:if user input SQL ,let him/her get all valid emaill_adress
    '--Input:SQL
    '--Output:all validation email address;Failed--SQL error
    '--2/5/05 - Created (eJay)
    '------------------------------------------------------------------------------------------
    Public Function GetEmailAddress(ByVal SQL As String) As String

        Dim tmpDS As DataSet
        Dim strResult As String = ""

        Try

            tmpDS = Me.QueryData(SQL, "GetEmailAddress")
            Dim i As Int32
            '--if SQL is error, then goto Catch error Module
            For i = 0 To tmpDS.Tables(0).Rows.Count - 1

                strResult = strResult.Trim() & tmpDS.Tables(0).Rows(i).Item("email_add").ToString.Trim() & ";"

            Next

            'strResult = Left(strResult, Len(strResult) - 1)

        Catch ex As Exception

            strResult = "Failed"
        Finally
            '--do nothing

        End Try

        Return strResult

    End Function

#End Region

#Region " Rush Hours"

    '-------------------------------------------------------------------------------
    '--Function:RushHourAdd
    '--Description:add a rush hour
    '--Input:DayofWeek,FromTime,ToTime
    '--Output:True--block;False--not block
    '--2/4/05 - Created (eJay)
    '-------------------------------------------------------------------------------
    Public Function RushHourCheck(ByVal BlockDate As String, ByVal Time As String) As Boolean

        Dim strSQL As String
        strSQL = "skylimo_wr_rushhour_check"
        Dim intResult As Int32

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@Block_date", BlockDate)
                .Parameters.Add("@Time", Time)

                intResult = Convert.ToInt32(.ExecuteScalar())

            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Dim blnResult As Boolean
        If intResult = 1 Then
            blnResult = True
        Else
            blnResult = False
        End If

        Return blnResult

    End Function


    '--------------------------------------------------------------------
    '--Function:RushHourAllGet
    '--Description:get all rush hour
    '--Input:
    '--Output:DataSet
    '--1/14/05 - Created (eJay)
    '--------------------------------------------------------------------
    Public Function RushHourFillOrderEntry() As DataSet

        Dim strSQL As String
        strSQL = "skylimo_wr_rushhour_fillorderentry"
        Dim tmpDS As DataSet

        Try

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                tmpDS = Me.QueryData("RushHour")

            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return tmpDS

    End Function


    '--------------------------------------------------------------------
    '--Function:RushHourAllGet
    '--Description:get all rush hour
    '--Input:
    '--Output:DataSet
    '--1/14/05 - Created (eJay)
    '--------------------------------------------------------------------
    Public Function RushHourAllGet() As DataSet

        Dim strSQL As String
        strSQL = "skylimo_wr_rushhour_allget"
        Dim tmpDS As DataSet

        Try

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                tmpDS = Me.QueryData("RushHour")

            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return tmpDS

    End Function

    '-------------------------------------------------------------------------------
    '--Function:RushHourAdd
    '--Description:add a rush hour
    '--Input:DayofWeek,FromTime,ToTime
    '--Output:True--success;False--failed
    '--1/14/05 - Created (eJay)
    '-------------------------------------------------------------------------------
    Public Function RushHourAdd(ByVal BlockDate As String, ByVal FromTime As String, ByVal ToTime As String) As Boolean

        Dim strSQL As String
        strSQL = "skylimo_wr_rushhour_add"
        Dim intResult As Int32

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@Block_date", Convert.ToDateTime(BlockDate))
                .Parameters.Add("@FromTime", FromTime)
                .Parameters.Add("@ToTime", ToTime)

                intResult = .ExecuteNonQuery()

            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Dim blnResult As Boolean
        If intResult = 1 Then
            blnResult = True
        Else
            blnResult = False
        End If

        Return blnResult

    End Function

    '---------------------------------------------------------------------------
    '--Function:RushHourDelete
    '--Description:delete a rush hour
    '--Input:Block_ID
    '--Output:True--success;False--failed
    '--1/15/05 - Created (eJay)
    '---------------------------------------------------------------------------
    Public Function RushHourDelete(ByVal Block_ID As Int32) As Boolean

        Dim strSQL As String
        strSQL = "skylimo_wr_rushhour_delete"
        Dim intResult As Int32

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@block_id", Block_ID)

                intResult = .ExecuteNonQuery

            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Dim blnResult As Boolean

        If intResult = 1 Then
            blnResult = True

        Else
            blnResult = False

        End If

        Return blnResult

    End Function

    '--------------------------------------------------------------------------------
    '--Function:RushHourUpdate
    '--Description:Update a rush hour
    '--Input:Block_ID,DayofWeek,FromTime,ToTime
    '--Output:True--Success;False--failed
    '--1/17/05 - Created (eJay)
    '--------------------------------------------------------------------------------
    Public Function RushHourUpdate(ByVal Block_ID As Int32, ByVal BlockDate As String, ByVal FromTime As String, ByVal ToTime As String) As Boolean

        Dim strSQL As String
        strSQL = "skylimo_wr_rushhour_update"
        Dim intResult As Int32

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@block_id", Block_ID)
                .Parameters.Add("@Block_date", Convert.ToDateTime(BlockDate))
                .Parameters.Add("@FromTime", FromTime)
                .Parameters.Add("@ToTime", ToTime)

                intResult = .ExecuteNonQuery

            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Dim blnResult As Boolean

        If intResult = 1 Then
            blnResult = True
        Else
            blnResult = False

        End If

        Return blnResult

    End Function

#End Region

#Region "admin change pwd"
    '-------------------------------------------------------------------
    '--Function:Update_Admin_Pwd
    '--Description:
    '--Input:strcur_pwd,strnow_pwd
    '--Output:iResult
    '--02/16/05 - Created (jack)
    '-------------------------------------------------------------------
    Public Function Update_Admin_Pwd(ByVal strcur_pwd As String, ByVal strnew_pwd As String) As Int32
        Dim iResult As Int32
        Me.OpenConnection()
        Try
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "skylimo_wr_admin_passwordupdate"
                .Parameters.Clear()

                .Parameters.Add("@cur_pwd", strcur_pwd)
                .Parameters.Add("@new_pwd", strnew_pwd)
                .Parameters.Add("@num_back", SqlDbType.Int)
                .Parameters("@num_back").Direction = ParameterDirection.Output

                .ExecuteNonQuery()
                iResult = Convert.ToInt16(.Parameters("@num_back").Value)
            End With

        Catch ex As Exception
            Me.ErrorMessage = ex.Message
            iResult = 0
        Finally
            Me.CloseConnection()
        End Try
        Return iResult

    End Function


    Public Function Find_Admin_Pwd() As DataSet
        Return Me.QueryData("select password from skylimo_wr_Admin_User", "adminpwd")
    End Function
#End Region
#Region "Public Functions"
    Public Function updateTimeframe(ByVal strtimeframe As String, ByVal DisableWebRide As Boolean) As Int16
        Dim iResult As Int16
        Me.OpenConnection()

        Try
            Dim intWebRide As Int16
            If DisableWebRide = True Then
                intWebRide = 1
            Else
                intWebRide = 0
            End If

            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "skylimo_wr_system_parameter_update_timeframe"
                .Parameters.Clear()
                .Parameters.Add("@timeframe", strtimeframe)
                .Parameters.Add("@DisableWebRide", intWebRide)

                iResult = Convert.ToInt16(.ExecuteNonQuery)
            End With
        Catch ex As Exception
            iResult = -1
        End Try
        Me.CloseConnection()
        Return iResult
    End Function
    '------------------------------------------------------------------------------
    '-- Function: getTimeframe
    '-- Description:  get the wr_timeframe in the table system_parameter
    '-- Output: DataSet
    '-- Table: system_parameter
    '-- Stored Procedure: skylimo_wr_System_Parameter_Timeframe
    '-- 12/14/04 - Created (jack)
    '------------------------------------------------------------------------------
    Public Function getTimeframe() As DataSet

        Return Me.QueryData("exec skylimo_wr_System_Parameter_Timeframe", "timeframe")

    End Function

    '-----------------------------------------------------------------
    'Function:  UpdateLineupSchedule
    'Description: Update Lineup Schedule
    'Modification:  2004/10/21  nancy
    'Table:               lineup schedule
    'Input :              arrLineSche, strPuIndex
    'OutPut:              1   successful
    '                     -1  fail
    '-----------------------------------------------------------------
    Public Function UpdateLineupSchedule(ByVal arrLineSche() As String, ByVal strPuIndex As String) As Int16
        Dim iResult As Int16
        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "gswr_update_lineupschedule"

                .Parameters.Add("@pu_index", strPuIndex)


                .Parameters.Add("@sun_start", arrLineSche(0))
                .Parameters.Add("@mon_start", arrLineSche(1))
                .Parameters.Add("@tue_start", arrLineSche(2))
                .Parameters.Add("@wed_start", arrLineSche(3))
                .Parameters.Add("@thu_start", arrLineSche(4))
                .Parameters.Add("@fri_start", arrLineSche(5))
                .Parameters.Add("@sat_start", arrLineSche(6))

                .Parameters.Add("@sun_duration", GetDuration(Convert.ToString(arrLineSche(0)), Convert.ToString(arrLineSche(7))))
                .Parameters.Add("@mon_duration", GetDuration(Convert.ToString(arrLineSche(1)), Convert.ToString(arrLineSche(8))))
                .Parameters.Add("@tue_duration", GetDuration(Convert.ToString(arrLineSche(2)), Convert.ToString(arrLineSche(9))))
                .Parameters.Add("@wed_duration", GetDuration(Convert.ToString(arrLineSche(3)), Convert.ToString(arrLineSche(10))))
                .Parameters.Add("@thu_duration", GetDuration(Convert.ToString(arrLineSche(4)), Convert.ToString(arrLineSche(11))))
                .Parameters.Add("@fri_duration", GetDuration(Convert.ToString(arrLineSche(5)), Convert.ToString(arrLineSche(12))))
                .Parameters.Add("@sat_duration", GetDuration(Convert.ToString(arrLineSche(6)), Convert.ToString(arrLineSche(13))))

                .Parameters.Add("@numback", SqlDbType.Int)
                .Parameters("@numback").Direction = ParameterDirection.Output
            End With

            Me.Command.ExecuteNonQuery()
            iResult = Convert.ToInt16(Me.Command.Parameters("@numback").Value)

        Catch ex As Exception
            iResult = -1
        Finally
            Me.CloseConnection()
        End Try
        Return iResult
    End Function

    '-----------------------------------------------------------------
    'Function:  GetLineupSchedule
    'Description: Get Lineup Schedule
    'Modification:  2004/10/21  nancy
    'Table:               lineup schedule
    'Input :             strPuIndex
    'OutPut:             arrLineSche[0-6]   strat time 
    '                    arrLineSche[7-13]  end time 
    '-----------------------------------------------------------------
    Public Function GetLineupSchedule(ByVal strPuIndex As String) As String()
        Dim arrLineSche(14) As String
        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "gswr_getlineupschedule"
                .Parameters.Add("@pu_index", strPuIndex)
            End With

            Me.Reader = Me.Command.ExecuteReader(CommandBehavior.SingleRow)

            If Reader.Read Then
                For i As Int16 = 0 To 6
                    arrLineSche(i) = Convert.ToString(Reader.Item(i))
                    If IsDate(arrLineSche(i)) Then
                        arrLineSche(i + 7) = DateAdd("n", Me.Reader.GetInt16(i + 7), arrLineSche(i)).ToString
                    End If
                Next
            End If

        Catch ex As Exception
            Dim strErr As String = ex.Message
        Finally
            Me.CloseConnection()
        End Try
        Return arrLineSche
    End Function


    '-----------------------------------------------------------------
    'Function:  GetLineupSchedule
    'Description: Get Lineup Schedule
    'Modification:  2004/10/25  tom
    'Table:         pu_locations & lineup_schedule
    'Input :    
    'OutPut:      Dataset
    '-----------------------------------------------------------------
    Public Function GetLineupSchedule() As DataSet
        Dim strSQL As String
        strSQL = "SELECT * FROM lineup_schedule where pu_index in(select pu_index from pu_locations)"
        Return Me.QueryData(strSQL, "Lineup_Schedule")
    End Function

#End Region
#Region "Private Functions"

    '-------------------------------------------------------------------------------------------
    '--Function:CheckSqlSafe
    '--Description:check & modify sql to be safe
    '--Input:SQL
    '--Output:safe SQL
    '--2/5/05 - Created (eJay)
    '-------------------------------------------------------------------------------------------
    Private Function CheckSqlSafe(ByVal SQL As String) As String


    End Function

    '-----------------------------------------------------------------
    'Function:  GetDuration
    'Description:This function calculated and returns the difference between the 2 times in minutes
    'Modification:  2004/10/21 nancy
    '-----------------------------------------------------------------
    Private Function GetDuration(ByVal start_time As String, ByVal end_time As String) As Integer
        If DateDiff("n", start_time, end_time) >= 0 Then
            GetDuration = Convert.ToInt32(DateDiff("n", start_time, end_time))
        Else
            GetDuration = Convert.ToInt32(DateDiff("n", start_time, DateAdd("d", 1, end_time)))
        End If
    End Function
#End Region

#Region "Maintain"
    '------------------------------------------------------------------------------
    '-- Function: GetContent_Page
    '-- Description:  get the content in the table content_page
    '-- Output: DataSet
    '-- Table: content_page
    '-- Stored Procedure: GetContent_page
    '-- 06/19/06 - Created (Fei)
    '------------------------------------------------------------------------------
    Public Function GetContent_Page(ByVal Page_id As Int32, ByVal SectionTitle As String) As DataSet
        Dim tmpDS As DataSet
        Dim strSQL As String
        strSQL = "GetContent_page"
        Try
            With SelectCommand
                .CommandText = strSQL
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@Page_id", Page_id)
                .Parameters.AddWithValue("@Section_title", SectionTitle)
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        End Try
        tmpDS = Me.QueryData("GetContent_page")
        Return tmpDS
    End Function
    '------------------------------------------------------------------------------
    '-- Function: UpdateContent_Page
    '-- Description:  Update the content in the table content_page
    '-- Input:page_id,title,content
    '-- Table: content_page
    '-- Stored Procedure:UpdateContent_page
    '-- 06/14/06 - Created (Fei)
    '------------------------------------------------------------------------------
    Public Function UpdateContent_Page(ByVal Page_id As Int32, ByVal tilte As String, ByVal content As String) As Boolean
        Dim strSQL As String
        Dim blnIs As Boolean = True
        strSQL = "UpdateContent_page"
        Try
            Me.OpenConnection()
            With Command
                .CommandText = strSQL
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@Page_id", Page_id)
                .Parameters.AddWithValue("@title", tilte)
                .Parameters.AddWithValue("@content", content)
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
            blnIs = False
        End Try
        Me.CloseConnection()
        Return blnIs
    End Function
    '------------------------------------------------------------------------------
    '-- Function: GetSections
    '-- Description:  get from Sections
    '-- Input:
    '-- Table: sections
    '-- Stored Procedure:GetSections
    '-- 06/19/06 - Created (Fei)
    '------------------------------------------------------------------------------
    Public Function GetSections() As DataSet
        Dim strSQL As String
        Dim tmpDs As DataSet
        strSQL = "GetSections"
        Try
            With Me.SelectCommand
                .CommandText = strSQL
                .CommandType = CommandType.StoredProcedure
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        End Try
        tmpDs = Me.QueryData("Sections")
        Return tmpDs
    End Function
    '------------------------------------------------------------------------------
    '-- Function: GetMaintainUser
    '-- Description: compare the user_id and password 
    '-- Input:user_id,password
    '-- Table: Maintain_user
    '-- Stored Procedure:GetMaintainUser
    '-- 06/19/06 - Created (Fei)
    '------------------------------------------------------------------------------
    Public Function GetMaintainUser(ByVal User_id As String, ByVal password As String) As Boolean
        Dim strSQL As String
        Dim blnIs As Boolean = True
        Dim return_value As New SqlParameter
        strSQL = "GetMaintainUser"
        Try
            Me.OpenConnection()
            With Command
                .CommandText = strSQL
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@User_Id", User_id)
                .Parameters.AddWithValue("@Password", password)
                return_value = .Parameters.AddWithValue("@return_value", SqlDbType.Int)
                return_value.Direction = ParameterDirection.ReturnValue
                .ExecuteReader()
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
            blnIs = False
        End Try
        Me.CloseConnection()
        If Convert.ToInt16(return_value.Value) = 0 Then
            blnIs = False
        Else
            blnIs = True
        End If
        Return blnIs
    End Function
#End Region

End Class
