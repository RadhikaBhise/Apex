Imports DataAccess
Imports System.Data
Imports System.Data.SqlClient


Public Class Orders
    Inherits CommonDB


    Public Function CarType_Set() As DataSet

        Dim strSQL As String
        strSQL = "EXEC mtcwr_cartype_get "

        Return Me.QueryData(strSQL, "Car_Type")
        
    End Function
    '------------------------------------------------------------------------------
    '-- Function: getCarType
    '-- Description:  get Car Type
    '-- Input: 
    '-- Output: DataSet
    '-- Table: car_type
    '-- Stored Procedure: MTC_wr_cartype_get
    '-- 21/03/06 - Created (Daniel)
    '------------------------------------------------------------------------------
    Public Function getCarType() As DataSet

        Return Me.QueryData("exec apex_wr_cartype_get", "CarType")

    End Function

    '------------------------------------------------------------------------------
    '-- Function: CreateCompId
    '-- Description: get company requirement according to the user info
    '-- Input: strAcctId,strSubAcctId,strCompany
    '-- Output: Datatable  
    '-- Table: account,company_requirement
    '-- Stored Procedure: mtcwr_CompanyRequirement_get
    '-- 03/10/06 - Created (eJay)
    '------------------------------------------------------------------------------
    Public Function CreateCompId(ByVal strAcctId As String, _
                                 ByVal strSubAcctId As String, _
                                 ByVal strCompany As String) As DataTable
        Dim tmpDS As DataTable
        Try
            With SelectCommand
                .CommandText = "mtcwr_CompanyRequirement_get"
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@acct_id", strAcctId)
                .Parameters.AddWithValue("@sub_acct_id", strSubAcctId)
                .Parameters.AddWithValue("@company", Convert.ToInt16(strCompany))
            End With

            tmpDS = Me.QueryData("compId").Tables("compId")

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return tmpDS

    End Function
    '-----------------------------------------------------------------------------
    '--Function:get section_id
    '--Description:select from MTC_Section
    '--Input: 
    '--Output:DataSet
    '--05/26/2006- Created (Yuki)
    '-----------------------------------------------------------------------------
    Public Function Get_SectionId() As DataSet
        Return Me.QueryData("exec MTC_SectionId_get", "section_id")
    End Function
    '------------------------------------------------------------------------------
    '-- Function: GetContent
    '-- Description:show the Content
    '-- Input:
    '-- Output: dataset
    '-- Table:MTC_content_page
    '-- Stored Procedure: MTC_ShowContent
    '-- 06/06/06 - Created by(yuki)
    '------------------------------------------------------------------------------
    Public Function GetContent() As DataSet
        Dim strSQL As String
        strSQL = "MTC_ShowContent"

        Dim tmpDS As DataSet

        Me.SelectCommand = New SqlCommand
        With Me.SelectCommand

            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL



        End With
        tmpDS = Me.QueryData("MTC_ShowContent")
        Return tmpDS

        'Return Me.QueryData(" exec MTC_ShowContent", "pricing_table")

    End Function
    '-----------------------------------------------------------------------------
    '--Function:Update_Content
    '--Description:
    '--Input Content,Page_id
    '--Output:DataSet
    '--06/09/2006- Created (yuki)
    '-----------------------------------------------------------------------------
    Public Function Update_Content(ByVal Page_id As String, ByVal Content As String) As Boolean
        Dim blnResult As Boolean
        Dim objDB As CommonDB

        objDB = New CommonDB
        With objDB
            Try
                .OpenConnection()
                With .Command
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "MTC_Update_Content"

                    .Parameters.Add("@Page_id", Page_id)
                    .Parameters.Add("@Content", Content)
                   
                    .ExecuteNonQuery()
                End With
                blnResult = True
            Catch ex As Exception
                blnResult = False
            Finally
                .CloseConnection()
                .Dispose()
            End Try
        End With

        objDB = Nothing

        Return blnResult

    End Function

#Region "group function"
    '------------------------------------------------------------------------------
    '-- Function: get_comp_desc
    '-- Description:  get_comp_desc
    '-- Input: 
    '-- Output: DataSet
    '-- Table: car_type
    '-- Stored Procedure: MTC_wr_cartype_get
    '-- 05/30/06 - Created (Nair)
    '------------------------------------------------------------------------------
    Public Function get_comp_req(ByVal Acct_Id As String, ByVal Sub_acct_id As String) As DataSet

        Dim strSQL As String
        strSQL = "APEX_wr_CompReq_get"  'changed by lily 12/03/2007

        Dim tmpDS As DataSet

        With Me.SelectCommand

            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL

            .Parameters.AddWithValue("@acct_id", Acct_Id)
            .Parameters.AddWithValue("@Sub_acct_id", Sub_acct_id)
        End With
        tmpDS = Me.QueryData("get_comp_req")
        Return tmpDS
    End Function

 


    '-----------------------------------------------------------------------------------
    '--Function:Corp_GetOperatorRidesQuery
    '--Description:retieves all the rides given the sortby criteria, or by a given letter
    '--Input:UserID,Acct_ID,Sub_acct_id,...
    '--Output:DataSet
    '--06/08/06 - Created (Nair)
    '-----------------------------------------------------------------------------------
    Public Function Corp_GetOperatorRidesQuery(ByVal Acct_ID As String, ByVal Sub_acct_id As String, ByVal fromDate As String, ByVal toDate As String, ByVal fname As String, ByVal lname As String, ByVal com_req As String, ByVal com_req_value As String, ByVal bol_Corp As String) As DataSet

        Dim strSQL As String
        strSQL = "Mtc_operator_corp_getrides"
        Dim tmpDS As DataSet

        With Me.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL

            .Parameters.AddWithValue("@acct_id", Acct_ID)
            .Parameters.AddWithValue("@sub_acct_id", Sub_acct_id)
            .Parameters.AddWithValue("@from_date", fromDate)
            .Parameters.AddWithValue("@to_date", toDate)
            .Parameters.AddWithValue("@fname", fname)
            .Parameters.AddWithValue("@lname", lname)
            .Parameters.AddWithValue("@com_req", com_req)
            .Parameters.AddWithValue("@comp_req_value", com_req_value)
            .Parameters.AddWithValue("@bol_Corp", bol_Corp)

        End With

        tmpDS = Me.QueryData("Corp_GetOperatorRidesQuery")
        Return tmpDS

    End Function
#End Region

#Region "corp function"
    '------------------------------------------------------------------------------
    '-- Function: get_vip
    '-- Description:  get_vip
    '-- Input: 
    '-- Output: DataSet
    '-- Table:  
    '-- Stored Procedure: MTC_wr_cartype_get
    '-- 06/07/06 - Created (Nair)
    '------------------------------------------------------------------------------
    Public Function get_vip(ByVal Acct_Id As String, _
                                 ByVal Sub_acct_id As String) As DataSet

        Dim strSQL As String
        strSQL = "mtc_vip_getvip"

        Dim tmpDS As DataSet

        With Me.SelectCommand

            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL

            .Parameters.AddWithValue("@acct_id", Acct_Id)
            .Parameters.AddWithValue("@Sub_acct_id", Sub_acct_id)
        End With
        tmpDS = Me.QueryData("get_vip")
        Return tmpDS
    End Function

    '------------------------------------------------------------------------------
    '-- Function: validate_corp_pw
    '-- Description:  validate_corp_pw
    '-- Input: 
    '-- Output: DataSet
    '-- Table: car_type
    '-- Stored Procedure: MTC_wr_cartype_get
    '-- 06/09/06 - Created (Nair)
    '------------------------------------------------------------------------------
    Public Function validate_corp_pw(ByVal Acct_Id As String, _
                                 ByVal Sub_acct_id As String) As DataSet

        Dim strSQL As String
        strSQL = "mtc_wr_validate_corpPW"

        Dim tmpDS As DataSet

        With Me.SelectCommand

            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL

            .Parameters.AddWithValue("@acct_id", Acct_Id)
            .Parameters.AddWithValue("@Sub_acct_id", Sub_acct_id)
        End With
        tmpDS = Me.QueryData("validate_corp_pw")
        Return tmpDS
    End Function
#End Region
End Class
