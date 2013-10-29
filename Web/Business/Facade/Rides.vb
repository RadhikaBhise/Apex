Imports DataAccess
Imports Microsoft.VisualBasic

Public Class Rides
    Inherits CommonDB

#Region " Perameters & Properties"

    Private m_email As String
    Private m_voucher_no As String
    Private m_req_date_time As String
    Private m_pu_county As String

    Public Property pu_county() As String
        Get
            Return m_pu_county
        End Get
        Set(ByVal Value As String)
            m_pu_county = Value
        End Set
    End Property
    Public Property req_date_time() As String
        Get
            Return m_req_date_time
        End Get
        Set(ByVal Value As String)
            m_req_date_time = Value
        End Set
    End Property
    Public Property voucher_no() As String
        Get
            Return m_voucher_no
        End Get
        Set(ByVal Value As String)
            m_voucher_no = Value
        End Set
    End Property
    Public Property email() As String
        Get
            Return m_email
        End Get
        Set(ByVal Value As String)
            m_email = Value
        End Set
    End Property

#End Region


    '-----------------------------------------------------------------------------------
    '--Function:GeteMailDetail
    '--Description:Get eMail Detail of a Canceled Ride
    '--Input:ConfNo,Email,Type
    '--Output:
    '--11/17/04 - Created (eJay)   --to be continued...
    '-----------------------------------------------------------------------------------
    Public Function GeteMailDetail(ByVal ConfNo As String, ByVal Email As String, ByVal Type As String) As RideData

        Dim strSQL As String
        strSQL = "get_mail_detail"

        'Dim objRide As New RideData

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@confirmation_no", ConfNo)
                .Parameters.Add("@email_addr", Email)
                .Parameters.Add("@status_flag", Type)

                .Parameters("@email_addr").Direction = ParameterDirection.Output
                .Parameters("status_flag").Direction = ParameterDirection.Output

                Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)

                If Me.Reader.Read Then


                End If

            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

    End Function

    '-----------------------------------------------------------------------------------
    '--Function:CancelRide
    '--Description:Cancel the ride
    '--Input:ConfNo,AcctID,HostName
    '--Output:True--Success;False--Faild
    '--11/11/04 - Created (eJay)
    '-- 11/15/2007  modified by yang
    '-- out: -2:    failed to cancel, to close the pickup time
    '--      -3:    no ride found
    '--       1:    cancel successfully
    '-----------------------------------------------------------------------------------
    Public Function CancelRide(ByVal ConfNo As String) As Integer

        Dim strSQL As String
        Dim out As Integer = 0

        strSQL = "APEX_wr_operator_ridecancel"

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@confirmation_no", ConfNo)
                .Parameters.AddWithValue("@account_no", MySession.AcctID)
                .Parameters.Add("@out", SqlDbType.SmallInt)

                .Parameters.Item("@out").Direction = ParameterDirection.Output

                .ExecuteNonQuery()
                out = Convert.ToInt32(Val(Convert.ToString(.Parameters.Item("@out").Value)))

            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try

        Return out

    End Function
    '-----------------------------------------------------------------------------------
    '--Function:Show_club_Point
    '--Description:Show the point
    '--Input:vip_no,acct_id,sub_acct_id,strCompany
    '--Output:True--Success;False--Faild
    '--2006/04/24 Creator:Daniel
    '--2006/06/08 modify by Daniel
    '-----------------------------------------------------------------------------------
    Public Function Show_club_Point(ByVal Vip_no As String, ByVal AcctID As String, ByVal SubAcctId As String, ByVal strCompany As String) As String

        Dim SQLStr As String
        Dim dr As DataSet

        SQLStr = "select class_one_club,club_points from VIP(nolock)"
        SQLStr = SQLStr & " where vip_no    = '" & sqlsafe(Vip_no) & "'"
        SQLStr = SQLStr & " and  acct_id    = '" & sqlsafe(AcctID) & "' "
        SQLStr = SQLStr & " and sub_acct_id = '" & sqlsafe(SubAcctId) & "' "
        SQLStr = SQLStr & " and company = '" & sqlsafe(strCompany) & "' " '-- 9/13/04 added for user w/ duplicate vip_no
        SQLStr = SQLStr & " and class_one_club = 'y'"

        dr = Me.QueryData(SQLStr, "VIP")

        If dr.Tables(0).Rows.Count > 0 Then
            Show_club_Point = Convert.ToString(IIf(IsDBNull(dr.Tables(0).Rows(0).Item("club_points")), "", dr.Tables(0).Rows(0).Item("club_points").ToString))
            
        Else
            Show_club_Point = ""
        End If

        dr.Dispose()
        dr = Nothing

        Return Show_club_Point

    End Function

    Public Function sqlsafe(ByVal inputvalue As String) As String

        If inputvalue Is Nothing Then
            sqlsafe = ""
        Else
            If inputvalue = "" Then
                sqlsafe = inputvalue
            Else
                sqlsafe = Replace(inputvalue, "'", "''")
            End If
        End If

    End Function
    '-----------------------------------------------------------------------------------
    '--Function:Show_PhoneNo
    '--Description:Show the Show_PhoneNo
    '--Input:vip_no,acct_id,sub_acct_id,strCompany
    '--Output:Table
    '--2006/04/24 Creator:Daniel
    '-----------------------------------------------------------------------------------
    Public Function Show_PhoneNo(ByVal Vip_no As String, ByVal AcctID As String, ByVal SubAcctId As String, ByVal strCompany As String) As DataTable
        Dim dr As DataRow
        Dim strSQL As String
        strSQL = "MTC_wr_Get_PhoneN"

        Dim tmpDT As New DataTable

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@vip_no", Vip_no)
                .Parameters.Add("@acct_id", AcctID)
                .Parameters.Add("@sub_acct_id", SubAcctId)
                .Parameters.Add("@company", strCompany)
                Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)
                If Me.Reader.Read Then
                    Dim strphone As String
                    Dim strhome_phone As String
                    Dim strpager As String
                    Dim strphone_2 As String
                    Dim strcell_phone As String
                    Dim strfax As String
                    Dim strNew As String = "New"

                    strphone = Me.Check_DBNULL(Me.Reader.Item("phone")) & "," & Me.Check_DBNULL(Me.Reader.Item("phone_ext"))
                    strhome_phone = Me.Check_DBNULL(Me.Reader.Item("home_phone"))
                    strpager = Me.Check_DBNULL(Me.Reader.Item("pager"))
                    strphone_2 = Me.Check_DBNULL(Me.Reader.Item("phone_2")) & "," & Me.Check_DBNULL(Me.Reader.Item("phone_ext_2"))
                    strfax = Me.Check_DBNULL(Me.Reader.Item("cell_phone"))
                    strcell_phone = Me.Check_DBNULL(Me.Reader.Item("fax"))
                    tmpDT.Columns.Add("phoneno")
                    tmpDT.Columns.Add("content")
                    If strphone <> "" AndAlso strphone <> "," Then
                        dr = tmpDT.NewRow
                        dr.Item(0) = strphone
                        dr.Item(1) = "Tel# 1:" & strphone
                        tmpDT.Rows.Add(dr)
                    End If
                    If strhome_phone <> "" Then
                        dr = tmpDT.NewRow
                        dr.Item(0) = strhome_phone
                        dr.Item(1) = "Home #.:" & strhome_phone
                        tmpDT.Rows.Add(dr)
                    End If
                    If strpager <> "" Then
                        dr = tmpDT.NewRow
                        dr.Item(0) = strpager
                        dr.Item(1) = "Pager #:" & strpager
                        tmpDT.Rows.Add(dr)
                    End If
                    If strphone_2 <> "" AndAlso strphone_2 <> "," Then
                        dr = tmpDT.NewRow
                        dr.Item(0) = strphone_2
                        dr.Item(1) = "Tel# 2:" & strphone_2
                        tmpDT.Rows.Add(dr)
                    End If
                    If strfax <> "" Then
                        dr = tmpDT.NewRow
                        dr.Item(0) = strfax
                        dr.Item(1) = "Cell #:" & strfax
                        tmpDT.Rows.Add(dr)
                    End If
                    If strcell_phone <> "" Then
                        dr = tmpDT.NewRow
                        dr.Item(0) = strcell_phone
                        dr.Item(1) = "Fax #:" & strcell_phone
                        tmpDT.Rows.Add(dr)
                    End If
                    '--add by daniel for "New" 14/11/06
                    If strNew <> "" Then
                        dr = tmpDT.NewRow
                        dr.Item(0) = ""
                        dr.Item(1) = strNew
                        tmpDT.Rows.Add(dr)
                    End If
                    Me.Reader.Close()
                End If
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return tmpDT

    End Function
    '-----------------------------------------------------------------------------------
    '--Function:SelectCancelRide
    '--Description:Select Ride for canceling
    '--Input:ConfNo,AcctID
    '--Output:True--Success;false--No this Ride
    '-- 11/11/04 - Created (eJay)
    '-----------------------------------------------------------------------------------
    Public Function SelectCancelRide(ByVal ConfNo As String, ByVal AcctID As String) As Boolean

        Dim strSQL As String
        strSQL = "MTC_wr_operator_selectridecancel"

        Dim blnResult As Boolean = False

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@confirmation_no", ConfNo)
                .Parameters.Add("@account_no", AcctID)

                Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)

                If Me.Reader.Read Then

                    Me.voucher_no = Me.Check_DBNULL(Me.Reader.Item("voucher_no"))
                    Me.req_date_time = Me.Check_DBNULL(Me.Reader.Item("req_date_time"))
                    Me.pu_county = Me.Check_DBNULL(Me.Reader.Item("pu_county"))
                    Me.email = Me.Check_DBNULL(Me.Reader.Item("email_add"))

                    blnResult = True

                End If

            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Return blnResult

    End Function

    '-----------------------------------------------------------------------------------
    '--Function:GetOperatorCounts
    '--Description:counts the # of rides shown & the total # of rides for a pickup point
    '--Input:UserID,Acct_ID,Sub_acct_id,Company
    '--Output:Counts
    '-- 11/1/04 - Created (eJay)
    '-----------------------------------------------------------------------------------
    Public Function GetOperatorCounts(ByVal UserID As String, ByVal Acct_ID As String, ByVal Sub_acct_id As String, ByVal Company As String, ByVal strfname As String, ByVal strlname As String) As Int32

        Dim strSQL As String
        strSQL = "MTC_wr_operator_getcounts"

        Dim iResult As Int32

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@user_id", UserID)
                .Parameters.Add("@acct_id", Acct_ID)
                .Parameters.Add("@sub_acct_id", Sub_acct_id)
                .Parameters.Add("@company", Company)
                .Parameters.Add("@fname", strfname)
                .Parameters.Add("@lname", strlname)

                .Parameters.Add("@counts", iResult)
                .Parameters("@counts").Direction = ParameterDirection.Output

                .ExecuteNonQuery()
                iResult = Convert.ToInt32(.Parameters("@counts").Value)

            End With

        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Return iResult

    End Function
    '-----------------------------------------------------------------------------------
    '--Function:GetOperatorCounts
    '--Description:counts the # of rides shown & the total # of rides for a pickup point
    '--Input:UserID,Acct_ID,Sub_acct_id,Company
    '--Output:Counts
    '-- 11/1/04 - Created (eJay)
    '-----------------------------------------------------------------------------------
    Public Function GetOperator_Shuttle_Counts(ByVal UserID As String, ByVal Acct_ID As String, ByVal Sub_acct_id As String, ByVal Company As String, ByVal strfname As String, ByVal strlname As String) As Int32

        Dim strSQL As String
        strSQL = "MTC_wr_operator_shuttle_getcounts"

        Dim iResult As Int32

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@user_id", UserID)
                .Parameters.Add("@acct_id", Acct_ID)
                .Parameters.Add("@sub_acct_id", Sub_acct_id)
                .Parameters.Add("@company", Company)
                .Parameters.Add("@fname", strfname)
                .Parameters.Add("@lname", strlname)

                .Parameters.Add("@counts", iResult)
                .Parameters("@counts").Direction = ParameterDirection.Output

                .ExecuteNonQuery()
                iResult = Convert.ToInt32(.Parameters("@counts").Value)

            End With

        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Return iResult

    End Function
    '-----------------------------------------------------------------------------------
    '--Function:GetOperatorInquiryCounts
    '--Description:counts the # of rides shown & the total # of rides for a pickup point
    '--Input:vip_no,Acct_no,Sub_acct_id,Company
    '--Output:Counts
    '-- 13/3/06 - Created (Daniel)
    '-----------------------------------------------------------------------------------
    Public Function GetOperatorInquiryCounts(ByVal vip_no As String, ByVal Acct_no As String, ByVal Sub_acct_id As String, ByVal Company As String) As Int32

        Dim strSQL As String
        strSQL = "MTC_wr_operator_rideinquiryCount"

        Dim iResult As Int32

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@vip_no", vip_no)
                .Parameters.Add("@account_no", Acct_no)
                .Parameters.Add("@sub_account_no", Sub_acct_id)
                .Parameters.Add("@company", Company)

                .Parameters.Add("@record_count", iResult)
                .Parameters("@record_count").Direction = ParameterDirection.Output

                .ExecuteNonQuery()
                iResult = Convert.ToInt32(.Parameters("@record_count").Value)

            End With

        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Return iResult

    End Function
    '-----------------------------------------------------------------------------------
    '--Function:GetOperatorInquiryCounts
    '--Description:counts the # of rides shown & the total # of rides for a pickup point
    '--Input:vip_no,Acct_no,Sub_acct_id,Company
    '--Output:Counts
    '-- 13/3/06 - Created (Daniel)
    '-----------------------------------------------------------------------------------
    Public Function GetOperatorInquiry_ShuttleCounts(ByVal vip_no As String, ByVal Acct_no As String, ByVal Sub_acct_id As String, ByVal Company As String) As Int32

        Dim strSQL As String
        strSQL = "MTC_wr_operator_rideinquiry_ShuttleCount"

        Dim iResult As Int32

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@vip_no", vip_no)
                .Parameters.Add("@account_no", Acct_no)
                .Parameters.Add("@sub_account_no", Sub_acct_id)
                .Parameters.Add("@company", Company)

                .Parameters.Add("@record_count", iResult)
                .Parameters("@record_count").Direction = ParameterDirection.Output

                .ExecuteNonQuery()
                iResult = Convert.ToInt32(.Parameters("@record_count").Value)

            End With

        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Return iResult

    End Function

    '-----------------------------------------------------------------------------------
    '--Function:GetOperatorRides
    '--Description:retieves all the rides given the sortby criteria, or by a given letter
    '--Input:UserID,Acct_ID,Sub_acct_id,Company
    '--Output:DataSet
    '--11/1/04 - Created (eJay)
    '-----------------------------------------------------------------------------------
    Public Function GetOperatorRides(ByVal UserID As String, ByVal Acct_ID As String, ByVal Sub_acct_id As String, ByVal Company As String, ByVal strfname As String, ByVal strlname As String) As DataSet

        Dim strSQL As String
        strSQL = "MTC_wr_operator_getrides"

        Dim tmpDS As DataSet

        Try

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@user_id", UserID)
                .Parameters.Add("@acct_id", Acct_ID)
                .Parameters.Add("@sub_acct_id", Sub_acct_id)
                .Parameters.Add("@company", Company)
                .Parameters.Add("@fname", strfname)
                .Parameters.Add("@lname", strlname)

                tmpDS = Me.QueryData("OperatorRides")

            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return tmpDS

    End Function
    '-----------------------------------------------------------------------------------
    '--Function:GetOperatorRides
    '--Description:retieves all the rides given the sortby criteria, or by a given letter
    '--Input:UserID,Acct_ID,Sub_acct_id,Company
    '--Output:DataSet
    '--11/1/04 - Created (eJay)
    '-----------------------------------------------------------------------------------
    Public Function GetOperator_Shuttle_Rides(ByVal UserID As String, ByVal Acct_ID As String, ByVal Sub_acct_id As String, ByVal Company As String, ByVal strfname As String, ByVal strlname As String) As DataSet

        Dim strSQL As String
        strSQL = "MTC_wr_operator_shuttle_getrides"

        Dim tmpDS As DataSet

        Try

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@user_id", UserID)
                .Parameters.Add("@acct_id", Acct_ID)
                .Parameters.Add("@sub_acct_id", Sub_acct_id)
                .Parameters.Add("@company", Company)
                .Parameters.Add("@fname", strfname)
                .Parameters.Add("@lname", strlname)

                tmpDS = Me.QueryData("OperatorRides")

            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return tmpDS

    End Function

    '-----------------------------------------------------------------------------
    '--Function:CheckReceipt
    '--Description:check receipt 
    '--Input:Confirmation_No
    '--Output:True -Yes;False - No
    '--11/1/04 - Created (eJay)
    '-----------------------------------------------------------------------------
    Public Function CheckReceipt(ByVal Conf_No As String) As Boolean

        Dim strSQL As String
        strSQL = "MTC_wr_voucher_checkreceipt"

        Dim strConf_No As String
        Dim blnIsHave As Boolean

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@confirmation_no", Conf_No)

                strConf_No = Convert.ToString(.ExecuteScalar())

            End With
        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        If Trim(strConf_No) <> "" Then
            blnIsHave = True
        Else
            blnIsHave = False

        End If

        Return blnIsHave

    End Function


    '-----------------------------------------------------------------------------
    '--Function:GetPrice
    '--Description:Get price from voucher archive
    '--Input:Confirmation_no
    '--Output:Field NET
    '--11/1/04 - Created (eJay)
    '-----------------------------------------------------------------------------
    Public Function GetPrice(ByVal Conf_No As String) As String

        Dim strSQL As String
        strSQL = "MTC_wr_voucher_getprice"

        Dim strNet As String

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
                .Parameters.AddWithValue("@confirmation_no", Conf_No)

                strNet = Convert.ToString(.ExecuteScalar)

            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        If strNet Is Nothing Or IsDBNull(strNet) Then
            strNet = "Nothing"
        End If

        Return strNet

    End Function

    '## 11/19/2007  Added by yang
    Public Function RideInquiry(ByVal agent_id As String, ByVal User As OperatorData, ByVal strDate As String, ByVal fdate As String, ByVal tdate As String) As DataSet
        Dim tmpDS As DataSet
        Dim strSQL As String = "APEX_wr_operator_rideinquiry"

        Try
            Me.OpenConnection()

            With Me.SelectCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@user_id", Me.sqlsafe(User.vip_no))
                .Parameters.AddWithValue("@acct_id", Me.sqlsafe(User.account_no))
                .Parameters.AddWithValue("@sub_acct_id", Me.sqlsafe(User.sub_account_no))
                .Parameters.AddWithValue("@company", Me.sqlsafe(User.company))
                .Parameters.AddWithValue("@agent_id", Me.sqlsafe(agent_id))
                .Parameters.AddWithValue("@fname", Me.sqlsafe(User.fname))
                .Parameters.AddWithValue("@lname", Me.sqlsafe(User.lname))
                .Parameters.AddWithValue("@comp_id_6", Me.sqlsafe(User.Comp_id_6))
                .Parameters.AddWithValue("@conf_no", Me.sqlsafe(User.confirmation_no))
                .Parameters.AddWithValue("@comp_id_5", Me.sqlsafe(User.Comp_id_5))
                .Parameters.AddWithValue("@fdate", Me.sqlsafe(fdate))
                .Parameters.AddWithValue("@tdate", Me.sqlsafe(tdate))
                .Parameters.AddWithValue("@date", Me.sqlsafe(strDate))
                .Parameters.AddWithValue("@comp_id", Me.sqlsafe(User.Comp_id_1))
                .Parameters.AddWithValue("@comp_id_value", Me.sqlsafe(User.comp_req_1))

                tmpDS = Me.QueryData("OperatorRides")
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
            tmpDS = Nothing
        Finally
            Me.CloseConnection()
        End Try

        Return tmpDS

    End Function

    '## 11/19/2007  Added by yang
    Public Function GetHistoryRides(ByVal agent_id As String, ByVal User As OperatorData, ByVal strDate As String, ByVal fdate As String, ByVal tdate As String) As DataSet
        Dim tmpDS As DataSet
        Dim strSQL As String = "APEX_wr_operator_ridehistory"

        Try
            Me.OpenConnection()

            With Me.SelectCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@user_id", Me.sqlsafe(User.vip_no))
                .Parameters.AddWithValue("@acct_id", Me.sqlsafe(User.account_no))
                .Parameters.AddWithValue("@sub_acct_id", Me.sqlsafe(User.sub_account_no))
                .Parameters.AddWithValue("@company", Me.sqlsafe(User.company))
                .Parameters.AddWithValue("@agent_id", Me.sqlsafe(agent_id))
                .Parameters.AddWithValue("@fname", Me.sqlsafe(User.fname))
                .Parameters.AddWithValue("@lname", User.lname)
                .Parameters.AddWithValue("@comp_id_6", Me.sqlsafe(User.Comp_id_6))
                .Parameters.AddWithValue("@conf_no", Me.sqlsafe(User.confirmation_no))
                .Parameters.AddWithValue("@comp_id_5", Me.sqlsafe(User.Comp_id_5))
                .Parameters.AddWithValue("@fdate", Me.sqlsafe(fdate))
                .Parameters.AddWithValue("@tdate", Me.sqlsafe(tdate))
                .Parameters.AddWithValue("@date", Me.sqlsafe(strDate))
                .Parameters.AddWithValue("@comp_id", Me.sqlsafe(User.Comp_id_1))
                .Parameters.AddWithValue("@comp_id_value", Me.sqlsafe(User.comp_req_1))

                tmpDS = Me.QueryData("OperatorRides")

            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try

        Return tmpDS
    End Function

    '-----------------------------------------------------------------------------
    '--Function:RideInquiry
    '--Description:Get Rides for page inquiry1.aspx to cancel or modify
    '--Input:UserID,AcctID,Sub_acct_id,Company
    '--Output:DataSet
    '--11/08/04 - Created (eJay)
    '-----------------------------------------------------------------------------
    Public Function RideInquiry_Shuttle(ByVal UserID As String, ByVal AcctID As String, ByVal Sub_acct_id As String, ByVal Company As String) As DataSet

        Dim strSQL As String
        strSQL = "MTC_wr_operator_rideinquiry_shuttle"

        Dim tmpDS As DataSet

        Try

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@vip_no", UserID)
                .Parameters.Add("@account_no", AcctID)
                .Parameters.Add("@sub_account_no", Sub_acct_id)
                .Parameters.Add("@company", Company)

                tmpDS = Me.QueryData("RideInquiry_Shuttle")

            End With

        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return tmpDS

    End Function

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
    '==Add by daniel 
    '==Get County
    '==Input state,city
    '==Output County
    Public Function get_county(ByVal state As String, ByVal city As String) As String
        Dim county As String
        Dim dr_ghs As DataSet
        Dim StrSql As String

        StrSql = "select county from city(nolock) where state = '" & state & "' and name = '" & city & "'"
        dr_ghs = Me.QueryData(StrSql, "Account_Holiday")
        If dr_ghs.Tables(0).Rows.Count > 0 Then
            county = dr_ghs.Tables(0).Rows(0).Item("county").ToString
        Else
            county = ""
        End If
        get_county = county
        dr_ghs.Dispose()
        dr_ghs = Nothing

    End Function
    '==Add by daniel 
    '==Get County
    '==Input state,city
    '==Output County
    Public Function get_county_price(ByVal county As String, ByVal city As String) As String
        Dim strcounty As String
        Dim dr_ghs As DataSet
        Dim StrSql As String

        StrSql = "select county from city(nolock) where state = '" & sqlsafe(county) & "' and name = '" & sqlsafe(city) & "'"
        dr_ghs = Me.QueryData(StrSql, "Account_Holiday")
        If dr_ghs.Tables(0).Rows.Count > 0 Then
            strcounty = dr_ghs.Tables(0).Rows(0).Item("county").ToString
        Else
            strcounty = ""
        End If
        get_county_price = strcounty
        dr_ghs.Dispose()
        dr_ghs = Nothing

    End Function

    Public Function isairport(ByVal statecode As String) As Boolean
        Dim StrSql As String
        Dim dr As DataSet

        StrSql = "select code from county_state_airport(nolock) where code = '" & sqlsafe(statecode) & "'"
        dr = Me.QueryData(StrSql, "county_state_airport")
        If dr.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

        dr.Dispose()
        dr = Nothing

    End Function

    Public Function GetAcct_Name(ByVal stracctid As String) As String
        Dim StrSql As String
        Dim dr As DataSet

        StrSql = "select name from account(nolock) where acct_id = '" & stracctid & "'"
        dr = Me.QueryData(StrSql, "account")
        If dr.Tables(0).Rows.Count > 0 Then
            'do nothing
            GetAcct_Name = dr.Tables(0).Rows(0).Item(0).ToString
        Else
            GetAcct_Name = ""
        End If

        Return GetAcct_Name

        dr.Dispose()
        dr = Nothing

    End Function

    Public Function GetAcct_No(ByVal stracctid As String) As String
        Dim StrSql As String
        Dim dr As DataSet

        'StrSql = "select account_no from webride_cc_account(nolock) where account_no = '" & stracctid & "'"
        StrSql = "select acct_id from account(nolock) where acct_id ='" & stracctid & "' and internet='t'"  '--modify by daniel 2007-09-19
        dr = Me.QueryData(StrSql, "webride_cc_account")
        If dr.Tables(0).Rows.Count > 0 Then
            'do nothing
            GetAcct_No = dr.Tables(0).Rows(0).Item(0).ToString
        Else
            GetAcct_No = ""
        End If

        Return GetAcct_No

        dr.Dispose()
        dr = Nothing

    End Function

    Public Function Get_Vip_no(ByVal strfname As String, ByVal strlname As String, ByVal strCCno As String, ByVal strEmail As String) As String
        Dim SQLStr As String
        Dim dr As DataSet

        SQLStr = "select vip_no from vip(nolock) where lname = '" & strlname & "' and fname = '" & strfname & "'"
        SQLStr = SQLStr & " and cc_no = '" & strCCno & "' and email_add = '" & strEmail & "'"

        dr = Me.QueryData(SQLStr, "webride_cc_account")
        If dr.Tables(0).Rows.Count > 0 Then
            'do nothing
            Get_Vip_no = dr.Tables(0).Rows(0).Item(0).ToString
        Else
            Get_Vip_no = ""
        End If

        dr.Dispose()
        dr = Nothing

        Return Get_Vip_no

    End Function

    '-----------------------------------------------------------------------------
    '--Function:bookedtrip
    '--Description:Get Rides for 
    '--Input:conf,email,CardNo
    '--Output:DataSet
    '--05/10/06 - Created (nair)
    '-----------------------------------------------------------------------------
    Public Function bookedtrip(ByVal conf As String, ByVal email As String, ByVal CardNo As String) As DataSet

        Dim strSQL As String
        strSQL = "MTC_wr_booktrip"

        Dim tmpDS As DataSet

        Try

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@confirmation_no", conf)
                .Parameters.Add("@email", email)
                .Parameters.Add("@Credit_Card", CardNo)

                tmpDS = Me.QueryData("bookedtrip")

            End With

        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return tmpDS

    End Function

    '-----------------------------------------------------------------------------
    '--Function:bookedtrip
    '--Description:Get Rides for 
    '--Input:conf,email,CardNo
    '--Output:DataSet
    '--05/10/06 - Created (nair)
    '-----------------------------------------------------------------------------
    Public Function trip_status(ByVal conf As String, ByVal email As String, ByVal CardNo As String) As String

        Dim strSQL As String
        strSQL = "MTC_wr_tripstatus"

        Dim strNet As String

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
                .Parameters.Add("@confirmation_no", conf)
                .Parameters.Add("@email", email)
                .Parameters.Add("@Credit_Card", CardNo)

                strNet = Convert.ToString(.ExecuteScalar)

            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        If strNet Is Nothing Or IsDBNull(strNet) Then
            strNet = "Nothing"
        End If

        Return strNet
    End Function
    Public Function getAllAccountInfo() As DataSet
        Dim strSQL As String
        strSQL = "select name,acct_id from account"
        Dim tmpDS As DataSet
        Try
            With Me.SelectCommand
                .CommandText = strSQL
                tmpDS = Me.QueryData("AccountInfo")

            End With

        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try
        Return tmpDS
    End Function

#Region "Verfy_cc"

    '--Modify by eJay 10/4/2006
    Public Function Init_variables(ByRef icverify_amt_to_charge As String) As Boolean
        Dim StrSql As String
        Dim dr As DataSet

        Dim blnResult As Boolean = False
        StrSql = "select icverify_request_dir,icverify_trans_lenght,icverify_max_users,icverify_amt_to_charge from system_parameter_dispatch(nolock)"

        Try

            dr = Me.QueryData(StrSql, "system_parameter_dispatch")
            If dr.Tables(0).Rows.Count > 0 Then
                icverify_amt_to_charge = dr.Tables(0).Rows(0).Item("icverify_amt_to_charge").ToString
                blnResult = True
            End If

        Catch ex As Exception
            blnResult = False

        End Try

        dr.Dispose()
        dr = Nothing

        Return blnResult

    End Function

    Public Function calc_price(ByVal strPuZone As String, ByVal strDestZone As String) As Single
        Dim SQLStr As String
        Dim dr As DataSet

        SQLStr = "select price from price(nolock) where from_zone = '" & strPuZone & "' and "
        SQLStr = SQLStr & " to_zone = '" & strDestZone & "'" ' and table_id = '" & session("table_id")) & "'"

        dr = Me.QueryData(SQLStr, "price")
        If dr.Tables(0).Rows.Count > 0 Then
            'do nothing
            calc_price = CSng(IIf(IsDBNull(dr.Tables(0).Rows(0).Item(0).ToString), 0.0, dr.Tables(0).Rows(0).Item(0).ToString))
        Else
            calc_price = 0.0
        End If

        Return calc_price

        dr.Dispose()
        dr = Nothing

    End Function

    Public Function begin_verify_cc(ByVal est_price As Single, ByVal strPuZone As String, ByVal strDestZone As String, _
                                    ByVal icverify_request_dir As String, ByVal icverifytranslength As Single, _
                                    ByVal icverify_max_users As Single, ByVal icverify_amt_to_charge As String, _
                                    ByVal strCC_comment_string As String, ByVal cc_no As String, ByVal cc_yr As String, _
                                    ByVal cc_mm As String) As String
        Dim i As Integer
        Dim FSO, objTStream, objFile As Object
        Dim strTrans As String
        Dim merch_code, amt_to_check As String
        Dim icv_stationNo, icv_amt_to_charge As String
        Dim SQLStr As String
        Dim dr As DataSet

        '-- init variables --
        icv_stationNo = "000"

        '-- Check is sharing folder exists --
        If checkfolderexists(icverify_request_dir) = False Then
            begin_verify_cc = "nosharefld"
            Exit Function
        End If
        '-- delete old system files --
        ClearOldSystemFiles(Convert.ToInt32(icverify_max_users), icverify_request_dir, Convert.ToInt32(icverifytranslength))
        'if serveristko then
        'else
        merch_code = "rify"
        'end if

        For i = 1 To Convert.ToInt32(icverify_max_users)
            '-- check if anyfiles with the file name icver###.* exists in shared folder --
            If My.Computer.FileSystem.FileExists("icver" & set_station_no(i.ToString)) = False Then
                icv_stationNo = set_station_no(i.ToString)
                Exit For
            Else

            End If
        Next
        '-- if station_no is not found then service is busy --
        If StrComp(icv_stationNo, "000") = 0 Then
            begin_verify_cc = "verservicebusy"
            Exit Function
        End If
        '-- Create icver###.tmp file --	
        'FSO = server.CreateObject("Scripting.FileSystemObject")
        Try
            Microsoft.VisualBasic.FileSystem.FileOpen(1, icverify_request_dir & "\icver" & icv_stationNo & ".tmp", OpenMode.Output)
        Catch ex As Exception
            begin_verify_cc = "collision"
            Exit Function
        End Try

        '-- 11/23/2004 updated to newer version (Naoki)
        If IsNumeric(CLng(est_price)) Then
            amt_to_check = CStr(CLng(est_price) + CLng(icverify_amt_to_charge))
        Else
            amt_to_check = CStr(icverify_amt_to_charge)
        End If

        '-- no confirmation # yet
        strTrans = """C6"","""",""" & strCC_comment_string & """,""" & cc_no & """,""" & Right(cc_yr, 2) & cc_mm & """,""" & amt_to_check & ".00"""
        '-- 11/23/2004 updated to newer version (Naoki)
        '-- Write request string to tmp file --
        Microsoft.VisualBasic.FileSystem.Print(2, strTrans)
        Microsoft.VisualBasic.FileClose()

        '-- Create file to measure the time of the biginning of verification --
        Microsoft.VisualBasic.FileSystem.FileOpen(2, icverify_request_dir & "\icver" & icv_stationNo & ".tt1", OpenMode.Output)
        Microsoft.VisualBasic.FileClose()

        If My.Computer.FileSystem.FileExists(icverify_request_dir & "\icver" & icv_stationNo & ".req") = True Then
            My.Computer.FileSystem.GetFiles(icverify_request_dir & "\icver" & icv_stationNo & ".req")
            My.Computer.FileSystem.DeleteFile(icverify_request_dir & "\icver" & icv_stationNo & ".req")
        End If
        If My.Computer.FileSystem.FileExists(icverify_request_dir & "\icver" & icv_stationNo & ".ans") = True Then
            My.Computer.FileSystem.GetFiles(icverify_request_dir & "\icver" & icv_stationNo & ".ans")
            My.Computer.FileSystem.DeleteFile(icverify_request_dir & "\icver" & icv_stationNo & ".ans")
        End If

        '-- Rename tmp file to req file --
        Try
            My.Computer.FileSystem.GetFiles(icverify_request_dir & "\icver" & icv_stationNo & ".tmp")
            My.Computer.FileSystem.RenameFile(icverify_request_dir & "\icver" & icv_stationNo & ".tmp", "icver" & icv_stationNo & ".req")
        Catch ex As Exception
            begin_verify_cc = "errgen"
            Exit Function
        End Try

        begin_verify_cc = icv_stationNo

        dr.Dispose()
        dr = Nothing

    End Function

    '------------------------------------------------------------------------------
    '-- Sub ClearOldSystemFiles()
    '------------------------------------------------------------------------------
    Sub ClearOldSystemFiles(ByVal icverify_max_users As Integer, ByVal icverify_request_dir As String, ByVal icverifytranslength As Integer)
        Dim iCurrentUser As Integer
        Dim FileNumber As Integer
        Dim FSO, objFile, objTStream As Object
        Dim dtDate1, dtDate2 As DateTime
        'On Error Resume Next
        'FSO = Microsoft.VisualBasic.FileSystem.FilePutObject(
        For iCurrentUser = 1 To icverify_max_users
            If My.Computer.FileSystem.FileExists(icverify_request_dir & "\icver" & set_station_no(iCurrentUser.ToString) & ".tt1") = True Then

                '-- Create file to measure the time of the biginning of verification --
                Microsoft.VisualBasic.FileSystem.FileOpen(1, icverify_request_dir & "\icver" & set_station_no(iCurrentUser.ToString) & ".tt2", OpenMode.Output)
                Microsoft.VisualBasic.FileSystem.FileClose(1)

                objFile = My.Computer.FileSystem.GetFiles(icverify_request_dir & "\icver" & set_station_no(iCurrentUser.ToString) & ".tt1")
                dtDate1 = CDate(My.Computer.FileSystem.GetFileInfo(icverify_request_dir & "\icver" & set_station_no(iCurrentUser.ToString) & ".tt1").CreationTime)
                objFile = Nothing
                objFile = My.Computer.FileSystem.GetFiles(icverify_request_dir & "\icver" & set_station_no(iCurrentUser.ToString) & ".tt2")
                dtDate2 = CDate(My.Computer.FileSystem.GetFileInfo(icverify_request_dir & "\icver" & set_station_no(iCurrentUser.ToString) & ".tt2").CreationTime)
                objFile = Nothing

                If DateDiff("s", dtDate1, dtDate2) > icverifytranslength Then
                    ' old system file, remove all
                    My.Computer.FileSystem.DeleteFile("icver" & set_station_no(iCurrentUser.ToString))
                Else
                    My.Computer.FileSystem.DeleteFile(icverify_request_dir & "\icver" & set_station_no(iCurrentUser.ToString) & ".tt2")
                    'objFile = My.Computer.FileSystem.GetFiles(icverify_request_dir & "\icver" & set_station_no(iCurrentUser.ToString) & ".tt2")
                    'objFile.delete()
                    'objFile = Nothing
                End If
            Else
                My.Computer.FileSystem.DeleteDirectory("icver" & set_station_no(iCurrentUser.ToString), FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If
        Next
        FSO = Nothing
    End Sub

    '------------------------------------------------------------------------------
    '-- Function checkfolderexists
    '------------------------------------------------------------------------------
    Function checkfolderexists(ByVal icverify_request_dir As String) As Boolean
        'Response.Write "Checking Folder: " & icverify_request_dir & "<br>"
        If (My.Computer.FileSystem.FileExists(icverify_request_dir)) Then
            checkfolderexists = True
        Else
            checkfolderexists = False
        End If

    End Function

    '------------------------------------------------------------------------------
    '-- function set_station_no(station_no)
    '-- 3/4/06 Update to use 2 prefix to avoid collision with gd25 (Naoki)
    '------------------------------------------------------------------------------
    Public Function set_station_no(ByVal station_no As String) As String
        Dim final_station As String
        Dim cnt As Integer
        final_station = ""
        station_no = CStr(station_no)
        For cnt = Len(station_no) To 1  '-- 2
            final_station = final_station & "0"
        Next
        final_station = "2" & final_station & station_no    '-- 3/24/06 add 2 prefix
        set_station_no = final_station
    End Function

#End Region

End Class
