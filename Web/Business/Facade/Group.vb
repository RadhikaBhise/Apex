Imports Business
Imports Business.Common
Imports System.Web.UI.WebControls
Imports System.Web.Configuration.WebConfigurationManager

Public Class Group
    Inherits DataAccess.CommonDB

#Region " Properties "

    Private m_AcctID As String
    Private m_SubAcctID As String
    Private m_Password As String
    Private m_Company As String

    Public Sub New()
        'Private m_{:i} As String
        'Me.m_\1 = ""
        Me.m_AcctID = ""
        Me.m_SubAcctID = ""
        Me.m_Password = ""
        Me.m_Company = ""
    End Sub

    'Private m_{:i} As {:i+}
    'Public Property \1 As \2\nGet\nReturn Me.m_\1\nEnd Get\nSet(Byval Value As \2)\nMe.m_\1=Value\nEnd Set\nEnd Property
    Public Property AcctID() As String
        Get
            Return Me.m_AcctID
        End Get
        Set(ByVal Value As String)
            Me.m_AcctID = Value
        End Set
    End Property
    Public Property SubAcctID() As String
        Get
            Return Me.m_SubAcctID
        End Get
        Set(ByVal Value As String)
            Me.m_SubAcctID = Value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return Me.m_Password
        End Get
        Set(ByVal Value As String)
            Me.m_Password = Value
        End Set
    End Property
    Public Property Company() As String
        Get
            Return Me.m_Company
        End Get
        Set(ByVal Value As String)
            Me.m_Company = Value
        End Set
    End Property
#End Region

#Region " Functions "

    '## 11/28/2007  Corporate Login (yang)
    '## Output  1:  login successfully
    '##         0:  Unknow Excetions
    '##         -1: No user found
    '##         -2: Password Incorrect
    '##     `   -3: Account is expired
    '##         -4: Account is not set up for online ordering
    Public Function Login(ByVal AcctID As String, ByVal Password As String) As UserData
        Dim strSQL As String = "APEX_group_login"

        Dim strFirst As String
        Dim objSecurity As New Security
        Dim objUserData As New UserData
        Dim GroupUserID As String = AppSettings("GroupOrderDefaultUserID")

        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@user_id", AcctID)
                .Parameters.AddWithValue("@pin_no", Password)
                .Parameters.AddWithValue("@group_user_id", GroupUserID)

                strFirst = .ExecuteScalar().ToString()

                If strFirst.CompareTo("No User") = 0 Then
                    objUserData.check_user = "No User"
                ElseIf strFirst.CompareTo("Dup User") = 0 Then
                    objUserData.check_user = "Dup User"
                ElseIf strFirst.CompareTo("Password incorrect") = 0 Then
                    objUserData.check_user = "Password incorrect"
                ElseIf strFirst.CompareTo("nowebgroup") = 0 Then
                    objUserData.check_user = "nowebgroup"
                Else
                    Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)
                    If Me.Reader.Read Then
                        With Me.Reader
                            objUserData.Name = objSecurity.Check_DBNULL(.Item("name"))
                            If objUserData.Name Is Nothing Then
                                objUserData.checkAccount = "No Account"
                            Else
                                objUserData.checkAccount = ""
                            End If

                            objUserData.priority = objSecurity.Check_DBNULL(.Item("priority"))     '--add by daniel 
                            objUserData.acct_name = objSecurity.Check_DBNULL(.Item("name"))
                            objUserData.acct_id = Convert.ToString(.Item("acct_id")).Trim()
                            objUserData.user_id = ""
                            objUserData.sub_acct_id = Convert.ToString(.Item("sub_acct_id")).Trim()
                            objUserData.Company = Convert.ToString(.Item("company")).Trim()
                            objUserData.fname = objSecurity.Check_DBNULL(.Item("fname"))
                            objUserData.lname = objSecurity.Check_DBNULL(.Item("lname"))
                            objUserData.PinNo = objSecurity.Check_DBNULL(.Item("password"))
                            objUserData.Internet = objSecurity.Check_DBNULL(.Item("internet"))
                            If Not IsDBNull(.Item("table_id")) Then
                                objUserData.table_id = Convert.ToInt32(.Item("table_id"))
                            Else
                                objUserData.table_id = 0
                            End If
                            objUserData.close_date = objSecurity.Check_DBNULL(.Item("close_date"))
                        End With
                    Else
                        objUserData.check_user = "No User"
                    End If
                End If
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try

        Return objUserData

    End Function

    '------------------------------------------------------------------------------
    '-- Function: GetRideInquiry
    '-- Description:  GetRideInquiry
    '-- Input: 
    '-- Output: DataSet
    '-- Table: operator,car_type
    '-- Stored Procedure: APEX_wr_group_rideinquiry
    '-- 12/03/07 - Created (Daniel Chen)
    '------------------------------------------------------------------------------
    Public Function GetRideInquiry(ByVal ShowCancelledRides As Boolean, ByVal SearchBy As String, ByVal FromDate As String, ByVal ToDate As String, _
                ByVal FirstName As String, ByVal LastName As String, ByVal CompReqID As String, ByVal CompReqValue As String) As DataSet

        Dim GroupUserID As String = AppSettings("GroupOrderDefaultUserID")

        Dim sql As String = String.Format("EXEC APEX_wr_group_rideinquiry '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}'", _
            Me.m_AcctID, IIf(ShowCancelledRides, "Y", "N"), SearchBy, FromDate, ToDate, FirstName, LastName, CompReqID, CompReqValue, GroupUserID)

        Return Me.QueryData(sql, "CorporateRides")

    End Function

#End Region

#Region "Search Ride Functions"

    ''-----------------------------------------------------------------------------------
    ''--Function:GetOperatorRides
    ''--Description:retieves all the rides given the sortby criteria, or by a given letter
    ''--Input:UserID,Acct_ID,Sub_acct_id,...
    ''--Output:DataSet
    ''--03/12/07 - Created (Daniel)
    ''##    1/10/2008   Disabled by yang
    ''-----------------------------------------------------------------------------------
    'Public Function GetOperatorRidesQuery(ByVal User As OperatorData, ByVal fromDate As String, ByVal toDate As String, ByVal com_req As String, ByVal com_req_value As String) As DataSet

    '    Dim strSQL As String
    '    strSQL = "APEX_operator_group_getrides"
    '    Dim tmpDS As DataSet

    '    With Me.SelectCommand
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = strSQL

    '        .Parameters.AddWithValue("@user_id", Me.sqlsafe(User.vip_no))
    '        .Parameters.AddWithValue("@acct_id", Me.sqlsafe(User.account_no))
    '        .Parameters.AddWithValue("@sub_acct_id", Me.sqlsafe(User.sub_account_no))
    '        .Parameters.AddWithValue("@search_by", Me.sqlsafe(User.Search_Value))
    '        .Parameters.AddWithValue("@from_date", fromDate)
    '        .Parameters.AddWithValue("@to_date", toDate)
    '        .Parameters.AddWithValue("@com_req", com_req)
    '        .Parameters.AddWithValue("@comp_req_value", com_req_value)

    '    End With

    '    tmpDS = Me.QueryData("GetOperatorRidesQuery")
    '    Return tmpDS

    'End Function

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

    '------------------------------------------------------------------------------
    '-- Function: get_comp_desc
    '-- Description:  get_comp_desc
    '-- Input: 
    '-- Output: DataSet
    '-- Table: car_type
    '-- Stored Procedure: APEX_wr_CompReq_get
    '-- 11/30/07 - Created (Daniel)
    '------------------------------------------------------------------------------
    Public Function get_comp_req(ByVal Acct_Id As String, _
                                 ByVal Sub_acct_id As String) As DataSet

        Dim strSQL As String
        strSQL = "APEX_wr_CompReq_get"

        Dim tmpDS As DataSet

        With Me.SelectCommand

            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL

            .Parameters.AddWithValue("@acct_id", Acct_Id)
            .Parameters.AddWithValue("@Sub_acct_id", Sub_acct_id)
        End With
        Try
            tmpDS = Me.QueryData("get_comp_req")
        Catch ex As Exception
            tmpDS = Nothing
        End Try

        Return tmpDS

    End Function

    Public Function HasCompanyRequirement() As Boolean
        Dim out As Boolean = False
        Dim sql As String = "APEX_wr_corporate_hascompanyrequirement"

        Try
            Me.OpenConnection()

            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = sql

                .Parameters.Clear()
                .Parameters.AddWithValue("@acct_id", Me.m_AcctID)
                .Parameters.AddWithValue("@sub_acct_id", Me.m_SubAcctID)

                out = Val(Convert.ToString(.ExecuteScalar)) > 0
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try

        Return out
    End Function

#End Region

End Class
