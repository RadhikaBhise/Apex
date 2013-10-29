Imports Business
Imports Business.Common
Imports System.Web.UI.WebControls

Public Class Corporate
    Inherits DataAccess.CommonDB

#Region " Properties "

    Private m_AcctID As String
    Private m_SubAcctID As String
    Private m_Password As String
    Private m_Company As String
    Private m_TableID As String

    Public Sub New()
        'Private m_{:i} As String
        'Me.m_\1 = ""
        Me.m_AcctID = ""
        Me.m_SubAcctID = ""
        Me.m_Password = ""
        Me.m_Company = ""
        Me.m_TableID = ""
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
    Public Property Table_ID() As String
        Get
            Return Me.m_TableID
        End Get
        Set(ByVal Value As String)
            Me.m_TableID = Value
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
    Public Function Login(ByVal AcctID As String, ByVal Password As String) As Integer
        Dim out As Integer = 0
        Dim sql As String = "apex_corp_login"

        Try
            Me.OpenConnection()

            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = sql
                .Parameters.Clear()
                .Parameters.AddWithValue("@acct_id", AcctID)
                .Parameters.AddWithValue("@password", Password)
                .Parameters.Add("@out", SqlDbType.SmallInt)
                .Parameters.Item("@out").Direction = ParameterDirection.Output

                .ExecuteNonQuery()
                out = Convert.ToInt32(Val(Convert.ToString(.Parameters.Item("@out").Value)))
            End With

            If out > 0 Then
                Me.Reader = Me.Command.ExecuteReader

                With Me.Reader
                    If .Read Then
                        Me.m_AcctID = Convert.ToString(.Item("acct_id")).Trim
                        Me.m_SubAcctID = Convert.ToString(.Item("sub_acct_id")).Trim
                        Me.m_Company = Convert.ToString(.Item("company")).Trim
                        Me.m_TableID = Convert.ToString(.Item("table_id")).Trim
                    End If
                End With
            End If

        Catch ex As Exception
            Me.ErrorMessage = ex.Message
            out = 0
        Finally
            Me.CloseConnection()
        End Try

        Return out
    End Function

    'Public Function GetCompanyRequirement() As DataSet
    '    Dim sql As String = String.Format("EXEC apex_corp_getcompanyrequirement {0},'{1}'", 0, "")
    '    Return Me.QueryData(sql, "CompReq")
    'End Function
    'Public Sub BindCompanyRequirement(ByRef ddlCompReq As dropdownlist)
    '    Dim ds As DataSet = Me.GetCompanyRequirement()

    '    If Not ds Is Nothing AndAlso ds.Tables.Count > 0 Then
    '        ddlCompReq.DataSource = ds.Tables(0).DefaultView
    '        ddlCompReq.DataTextField = "req_desc"
    '        ddlCompReq.DataValueField = "req_id"
    '        ddlCompReq.DataBind()
    '    End If
    'End Sub

    'Public Function GetRideInquiry(ByVal ShowCancelledRides As Boolean, ByVal SearchBy As String, ByVal FromDate As String, ByVal ToDate As String, _
    '            ByVal FirstName As String, ByVal LastName As String, ByVal CompReqID As String, ByVal CompReqValue As String) As DataSet

    '    Dim sql As String = String.Format("EXEC apex_corp_rideinquiry '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'", _
    '        Me.m_AcctID, IIf(ShowCancelledRides, "Y", "N"), SearchBy, FromDate, ToDate, FirstName, LastName, CompReqID, CompReqValue)

    '    Return Me.QueryData(sql, "CorporateRides")

    'End Function

    'Public Function HasCompanyRequirement() As Boolean
    '    Dim out As Boolean = False
    '    Dim sql As String = "apex_corp_hascompanyrequirement"

    '    Try
    '        Me.OpenConnection()

    '        With Me.Command
    '            .CommandType = CommandType.StoredProcedure
    '            .CommandText = sql

    '            .Parameters.Clear()
    '            .Parameters.AddWithValue("@acct_id", Me.m_AcctID)
    '            .Parameters.AddWithValue("@sub_acct_id", Me.m_SubAcctID)

    '            out = Val(Convert.ToString(.ExecuteScalar)) > 0
    '        End With
    '    Catch ex As Exception
    '        Me.ErrorMessage = ex.Message
    '    Finally
    '        Me.CloseConnection()
    '    End Try

    '    Return out
    'End Function

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


    '------------------------------------------------------------------------------
    '-- Function: GetRideInquiry
    '-- Description:  GetRideInquiry
    '-- Input: 
    '-- Output: DataSet
    '-- Table: operator,car_type
    '-- Stored Procedure: APEX_wr_corporate_rideinquiry
    '-- 12/03/07 - Created (lily)
    '------------------------------------------------------------------------------
    Public Function GetRideInquiry(ByVal ShowCancelledRides As Boolean, ByVal SearchBy As String, ByVal FromDate As String, ByVal ToDate As String, _
                ByVal FirstName As String, ByVal LastName As String, ByVal CompReqID As String, ByVal CompReqValue As String) As DataSet

        Dim sql As String = String.Format("EXEC APEX_wr_corporate_rideinquiry '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'", _
            Me.m_AcctID, IIf(ShowCancelledRides, "Y", "N"), SearchBy, FromDate, ToDate, FirstName, LastName, CompReqID, CompReqValue)

        Return Me.QueryData(sql, "CorporateRides")

    End Function
    Public Function GetCompanyRequirement() As DataSet
        Dim sql As String = String.Format("EXEC APEX_wr_corporate_getcompanyrequirement {0},'{1}'", 0, "")
        Return Me.QueryData(sql, "CompReq")
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

    Public Function GetCompanyRequirementDescByID(ByVal ReqID As String) As String
        Dim out As String = ""
        Dim sql As String = String.Format("APEX_wr_corporate_getcompanyrequirement")

        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = sql

                .Parameters.AddWithValue("@req_id", ReqID)
                .Parameters.AddWithValue("@req_desc", "")

                Me.Reader = .ExecuteReader

                If Me.Reader.Read Then
                    out = Convert.ToString(Me.Reader.Item("req_desc")).Trim()
                End If
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
