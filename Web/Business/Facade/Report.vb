Imports DataAccess
Imports System.Data
Imports System.Data.SqlClient

Public Class Report
    Inherits CommonDB
    Public Function GetInvoiceReport(ByVal strInvoiceno As String, ByVal strFromdate As String, ByVal strTodate As String, ByVal strGroupFlag As String, ByVal strAcct As String, ByVal strSubacct As String, ByVal strSelacct As String) As DataSet
        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_getInvoiceInquiry"

        Me.SelectCommand = New SqlCommand
        With Me.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL
            .Parameters.AddWithValue("@invoiceno", strInvoiceno)
            .Parameters.AddWithValue("@invoice_fromdate", strFromdate)
            .Parameters.AddWithValue("@invoice_todate", strTodate)
            .Parameters.AddWithValue("@group_flag", strGroupFlag)
            .Parameters.AddWithValue("@acct_id", strAcct)
            .Parameters.AddWithValue("@sub_acct_id", strSubacct)
            .Parameters.AddWithValue("@select_acct_id", strSelacct)

        End With

        strDS = Me.QueryData("InvoiceReport")

        Return strDS
    End Function
    Public Function GetInvoiceReportbyVIP(ByVal strInvoiceno As String, ByVal strFromdate As String, ByVal strTodate As String, ByVal strGroupFlag As String, ByVal strVipNO As String, ByVal strAcct As String, ByVal strSubacct As String, ByVal strSelacct As String) As DataSet
        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_getInvoiceInquirybyVIP"

        Me.SelectCommand = New SqlCommand
        With Me.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL
            .Parameters.AddWithValue("@invoiceno", strInvoiceno)
            .Parameters.AddWithValue("@invoice_fromdate", strFromdate)
            .Parameters.AddWithValue("@invoice_todate", strTodate)
            .Parameters.AddWithValue("@group_flag", strGroupFlag)
            .Parameters.AddWithValue("@VipNO", strVipNO)
            .Parameters.AddWithValue("@acct_id", strAcct)
            .Parameters.AddWithValue("@sub_acct_id", strSubacct)
            .Parameters.AddWithValue("@select_acct_id", strSelacct)

        End With

        strDS = Me.QueryData("InvoiceReport")

        Return strDS
    End Function

    Public Function GetInvoiceReport2(ByVal strInvoiceno As String, ByVal strInvoicedate As String, ByVal strAcct As String, ByVal strSubacct As String, ByVal VipNo As String) As DataSet
        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_GetInvoiceInquiry2"

        Me.SelectCommand = New SqlCommand
        With Me.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL
            .Parameters.AddWithValue("@vip_no", VipNo)
            .Parameters.AddWithValue("@invoice_no", strInvoiceno)
            .Parameters.AddWithValue("@invoice_date", strInvoicedate)
            .Parameters.AddWithValue("@acct_id", strAcct)
            .Parameters.AddWithValue("@sub_acct_id", strSubacct)

        End With

        strDS = Me.QueryData("InvoiceReport2")

        Return strDS
    End Function

    'Public Function GetInvoiceReport2byVIP(ByVal strVipno As String, ByVal strInvoiceno As String, ByVal strInvoicedate As String, ByVal strGroupFlag As String, ByVal strAcct As String, ByVal strSubacct As String, ByVal strSelacct As String) As DataSet
    '    Dim strSQL As String
    '    Dim strDS As DataSet

    '    strSQL = "APEX_wc_GetInvoiceInquiry2byVIP"

    '    Me.SelectCommand = New SqlCommand
    '    With Me.SelectCommand
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = strSQL
    '        .Parameters.AddWithValue("@vip_no", strVipno)
    '        .Parameters.AddWithValue("@invoice_no", strInvoiceno)
    '        .Parameters.AddWithValue("@invoice_date", strInvoicedate)
    '        .Parameters.AddWithValue("@group_flag", strGroupFlag)
    '        .Parameters.AddWithValue("@acct_id", strAcct)
    '        .Parameters.AddWithValue("@sub_acct_id", strSubacct)
    '        .Parameters.AddWithValue("@sel_acct_id", strSelacct)

    '    End With

    '    strDS = Me.QueryData("InvoiceReport2")

    '    Return strDS
    'End Function

    Public Function GetConfirmationNo(ByVal strPudate As String, ByVal strAcctid As String, ByVal strSubacctid As String, ByVal strAcctlist As String, ByVal strGroupflag As String, ByVal strConfirm As String) As DataSet
        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_GetConfirmation"

        Me.SelectCommand = New SqlCommand
        With Me.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL
            .Parameters.AddWithValue("@pu_date", strPudate)
            .Parameters.AddWithValue("@acct_id", strAcctid)
            .Parameters.AddWithValue("@sub_acct_id", strSubacctid)
            .Parameters.AddWithValue("@acct_list", strAcctlist)
            .Parameters.AddWithValue("@group_flag", strGroupflag)
            .Parameters.AddWithValue("@confirmation_no", strConfirm)

        End With

        strDS = Me.QueryData("ConfirmationReport")

        Return strDS
    End Function
    Public Function GetVoucherNo(ByVal strPudate As String, ByVal strAcctid As String, ByVal strSubacctid As String, ByVal strAcctlist As String, ByVal strGroupflag As String, ByVal strConfirm As String) As DataSet
        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_GetVoucher"

        Me.SelectCommand = New SqlCommand
        With Me.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL
            .Parameters.AddWithValue("@pu_date", strPudate)
            .Parameters.AddWithValue("@acct_id", strAcctid)
            .Parameters.AddWithValue("@sub_acct_id", strSubacctid)
            .Parameters.AddWithValue("@acct_list", strAcctlist)
            .Parameters.AddWithValue("@group_flag", strGroupflag)
            .Parameters.AddWithValue("@confirmation_no", strConfirm)

        End With

        strDS = Me.QueryData("VoucherReport")

        Return strDS
    End Function

    Public Function GetConfirmationDetail(ByVal strAcctid As String, ByVal strSubacctid As String, ByVal strAcctlist As String, ByVal strGroupflag As String, ByVal strConfirm As String) As DataSet
        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_GetConfirmationDetail"

        Me.SelectCommand = New SqlCommand
        With Me.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL
            .Parameters.AddWithValue("@acct_id", strAcctid)
            .Parameters.AddWithValue("@sub_acct_id", strSubacctid)
            .Parameters.AddWithValue("@acct_list", strAcctlist)
            .Parameters.AddWithValue("@group_flag", strGroupflag)
            .Parameters.AddWithValue("@confirmation_no", strConfirm)

        End With

        strDS = Me.QueryData("ConfirmationDetail")

        Return strDS
    End Function
    Public Function UpdateMainLog(ByVal strAcctid As String, ByVal strSubacctid As String, ByVal strVipno As String, ByVal strPinNo As String, ByVal strPassword As String) As String
        Dim strSQL As String
        Dim strDS As DataSet
        Dim strResult As String
        strResult = ""
        strSQL = "APEX_wc_MainLogUpdate"

        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
                .Parameters.AddWithValue("@vip_no", strVipno)
                .Parameters.AddWithValue("@acct_id", strAcctid)
                .Parameters.AddWithValue("@sub_acct_id", strSubacctid)
                .Parameters.AddWithValue("@pin_no", strPinNo)
                .Parameters.AddWithValue("@password", strPassword)
                .Parameters.Add("@result", SqlDbType.VarChar, 50)
                .Parameters("@result").Value = strResult
                .Parameters("@result").Direction = ParameterDirection.Output

                .ExecuteNonQuery()
                strResult = Convert.ToString(.Parameters("@result").Value)
            End With
        Catch ex As Exception
            strResult = "0"
        Finally
            Me.CloseConnection()
        End Try

        Return strResult
    End Function

    Public Function GetCustomerList(ByVal strAcctid As String, ByVal strSubacctid As String, ByVal strVipNo As String, ByVal strLevel As String, _
                ByVal strFromdate As String, ByVal strTodate As String, ByVal strComId As String, ByVal strComValue As String, ByVal strDateType As String) As DataSet

        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_getCustomList"

        Me.SelectCommand = New SqlCommand
        With Me.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL
            .Parameters.AddWithValue("@acct_id", strAcctid)
            .Parameters.AddWithValue("@sub_acct_id", strSubacctid)
            .Parameters.AddWithValue("@vip_no", strVipNo)
            .Parameters.AddWithValue("@level_id", strLevel)
            .Parameters.AddWithValue("@from_date", strFromdate)
            .Parameters.AddWithValue("@to_date", strTodate)
            .Parameters.AddWithValue("@com_id", strComId)
            .Parameters.AddWithValue("@com_value", strComValue)
            .Parameters.AddWithValue("@date_type", strDateType)
        End With

        strDS = Me.QueryData("CustomerList")

        Return strDS
    End Function

    Public Function GetVipList(ByVal strAcctid As String, ByVal strSubacctid As String, ByVal strSelVip As String, ByVal strVipNo As String, _
                    ByVal strLevel As String, ByVal FromTripDate As String, ByVal ToTripDate As String, Optional ByRef date_type As String = "t") As DataSet

        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_getVipList"

        Me.SelectCommand = New SqlCommand
        With Me.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL
            .Parameters.AddWithValue("@acct_id", strAcctid)
            .Parameters.AddWithValue("@sub_acct_id", strSubacctid)
            .Parameters.AddWithValue("@sel_vip_no", strSelVip)
            .Parameters.AddWithValue("@vip_no", strVipNo)
            .Parameters.AddWithValue("@level_id", strLevel)
            '--add by daniel 
            .Parameters.AddWithValue("@date_type", date_type)
            .Parameters.AddWithValue("@FromTripDate", FromTripDate)
            .Parameters.AddWithValue("@ToTripDate", ToTripDate)
        End With

        strDS = Me.QueryData("VipList")

        Return strDS
    End Function

    Public Function GetDayReport(ByVal strAcctid As String, ByVal strSubacctid As String, ByVal strFromdate As String, _
                    ByVal strTodate As String, ByVal strFromtime As String, ByVal strTotime As String) As DataSet

        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_getDayRpt"

        Me.SelectCommand = New SqlCommand
        With Me.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL
            .Parameters.AddWithValue("@acct_id", strAcctid)
            .Parameters.AddWithValue("@sub_acct_id", strSubacctid)
            '.Parameters.AddWithValue("@sel_acct_id", strAcctlist)
            '.Parameters.AddWithValue("@group_flag", strGroupflag)
            .Parameters.AddWithValue("@from_date", strFromdate)
            .Parameters.AddWithValue("@to_date", strTodate)
            .Parameters.AddWithValue("@from_time", strFromtime)
            .Parameters.AddWithValue("@to_time", strTotime)

        End With

        strDS = Me.QueryData("DayOfReport")

        Return strDS
    End Function
    Public Function GetDriveReport(ByVal strAcctid As String, ByVal strSubacctid As String, ByVal strAcctlist As String, ByVal strGroupflag As String, ByVal strFromdate As String, ByVal strTodate As String, ByVal strTop As String, ByVal strDaytype As String, ByVal strSortby As String) As DataSet
        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_getDriveRpt"

        Me.SelectCommand = New SqlCommand
        With Me.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL
            .Parameters.AddWithValue("@acct_id", strAcctid)
            .Parameters.AddWithValue("@sub_acct_id", strSubacctid)
            .Parameters.AddWithValue("@sel_acct_id", strAcctlist)
            .Parameters.AddWithValue("@group_flag", strGroupflag)
            .Parameters.AddWithValue("@from_datetime", strFromdate)
            .Parameters.AddWithValue("@to_datetime", strTodate)
            .Parameters.AddWithValue("@toptip", strTop)
            .Parameters.AddWithValue("@day_type", strDaytype)
            .Parameters.AddWithValue("@sortby", strSortby)

        End With

        strDS = Me.QueryData("DriveOfReport")

        Return strDS
    End Function

    Public Function GetDriveReport2(ByVal strAcctid As String, ByVal strSubacctid As String, ByVal strCarno As String, _
                    ByVal strDaytype As String, ByVal strFromdate As String, ByVal strTodate As String) As DataSet

        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_getDriveRpt2"

        Me.SelectCommand = New SqlCommand
        With Me.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL
            .Parameters.AddWithValue("@acct_id", strAcctid)
            .Parameters.AddWithValue("@sub_acct_id", strSubacctid)
            '.Parameters.AddWithValue("@sel_acct_id", strAcctlist)
            '.Parameters.AddWithValue("@group_flag", strGroupflag)
            .Parameters.AddWithValue("@car_no", strCarno)
            .Parameters.AddWithValue("@date_type", strDaytype)
            .Parameters.AddWithValue("@from_date", strFromdate)
            .Parameters.AddWithValue("@to_date", strTodate)

        End With

        strDS = Me.QueryData("DriveOfReport2")

        Return strDS
    End Function

    Public Function GetElementReport(ByVal strAcctid As String, ByVal strSubacctid As String, ByVal strFromdate As String, _
                    ByVal strTodate As String, ByVal strDaytype As String, ByVal strRideEle As String, ByVal strRideTotal As String) As DataSet

        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_getElementRpt"

        Me.SelectCommand = New SqlCommand
        With Me.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL
            .Parameters.AddWithValue("@acct_id", strAcctid)
            .Parameters.AddWithValue("@sub_acct_id", strSubacctid)
            '.Parameters.AddWithValue("@sel_acct_id", strAcctlist)
            '.Parameters.AddWithValue("@group_flag", strGroupflag)
            .Parameters.AddWithValue("@from_datetime", strFromdate)
            .Parameters.AddWithValue("@to_datetime", strTodate)
            .Parameters.AddWithValue("@daytype", strDaytype)
            .Parameters.AddWithValue("@rideElement", strRideEle)
            .Parameters.AddWithValue("@ridetotal", strRideTotal)

        End With

        strDS = Me.QueryData("ElementOfReport")

        Return strDS
    End Function

    Public Function GetEMPReport(ByVal strAcctid As String, ByVal strSubacctid As String, ByVal strAcctlist As String, ByVal strGroupflag As String, ByVal strFromdate As String, ByVal strTodate As String, ByVal strTop As String, ByVal strDaytype As String, ByVal strSortby As String) As DataSet
        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_getEmpRpt"

        Me.SelectCommand = New SqlCommand
        With Me.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL
            .Parameters.AddWithValue("@acct_id", strAcctid)
            .Parameters.AddWithValue("@sub_acct_id", strSubacctid)
            .Parameters.AddWithValue("@sel_acct_id", strAcctlist)
            .Parameters.AddWithValue("@group_flag", strGroupflag)
            .Parameters.AddWithValue("@from_datetime", strFromdate)
            .Parameters.AddWithValue("@to_datetime", strTodate)
            .Parameters.AddWithValue("@toptip", strTop)
            .Parameters.AddWithValue("@day_type", strDaytype)
            .Parameters.AddWithValue("@sortby", strSortby)

        End With

        strDS = Me.QueryData("PassOfReport")

        Return strDS
    End Function
    Public Function GetEmpReport2(ByVal strAcctid As String, ByVal strSubacctid As String, _
                    ByVal strVipno As String, ByVal DateType As String, ByVal FromDate As String, ByVal ToDate As String) As DataSet

        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_getEmpRpt2"

        Me.SelectCommand = New SqlCommand
        With Me.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL
            .Parameters.AddWithValue("@acct_id", strAcctid)
            .Parameters.AddWithValue("@sub_acct_id", strSubacctid)
            .Parameters.AddWithValue("@vip_no", strVipno)
            .Parameters.AddWithValue("@date_type", DateType)
            .Parameters.AddWithValue("@from_date", FromDate)
            .Parameters.AddWithValue("@to_date", ToDate)

        End With

        strDS = Me.QueryData("PassOfReport2")
        Return strDS
    End Function
    Public Function GetAllState() As DataSet
        Dim tmpDS As DataSet
        Dim strSQL As String

        strSQL = "select distinct * from MTC_wc_webride_states(nolock) where type > 2 order by type,state_desc"
        tmpDS = Me.QueryData(strSQL, "state")

        Return tmpDS
    End Function

    Public Function GetCustomReport(ByVal strFromdate As String, ByVal strTodate As String, ByVal strGroupFlag As String, ByVal strAcct As String, ByVal strSubacct As String, ByVal strSelacct As String, ByVal strcomid As String, ByVal strsort As String, ByVal strtop As String, ByVal strdaytype As String) As DataSet
        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_getCustomRpt"
        Me.SelectCommand = New SqlCommand
        With Me.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL
            .Parameters.AddWithValue("@acct_id", strAcct)
            .Parameters.AddWithValue("@sub_acct_id", strSubacct)
            .Parameters.AddWithValue("@sel_acct_id", strSelacct)
            .Parameters.AddWithValue("@group_flag", strGroupFlag)
            .Parameters.AddWithValue("@from_date", strFromdate)
            .Parameters.AddWithValue("@to_date", strTodate)
            .Parameters.AddWithValue("@com_id", strcomid)
            .Parameters.AddWithValue("@date_type", strdaytype)
            .Parameters.AddWithValue("@sort", strsort)
            .Parameters.AddWithValue("@top", strtop)

        End With
        strDS = Me.QueryData("CustomReport")
        Return strDS
    End Function

    Public Function GetCustomReport2(ByVal strAcct As String, ByVal strSubacct As String, ByVal strcomid As String, _
                    ByVal strcomtext As String, ByVal strDaytype As String, ByVal strFromdate As String, ByVal strTodate As String) As DataSet

        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_getCustomRpt2"


        Me.SelectCommand = New SqlCommand
        With Me.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL
            .Parameters.AddWithValue("@acct_id", strAcct)
            .Parameters.AddWithValue("@sub_acct_id", strSubacct)
            '.Parameters.AddWithValue("@sel_acct_id", strSelacct)
            '.Parameters.AddWithValue("@group_flag", strGroupFlag)
            .Parameters.AddWithValue("@com_id", strcomid)
            .Parameters.AddWithValue("@com_text", strcomtext)
            .Parameters.AddWithValue("@date_type", strDaytype)
            .Parameters.AddWithValue("@from_date", strFromdate)
            .Parameters.AddWithValue("@to_date", strTodate)
        End With

        strDS = Me.QueryData("CustomReport2")
        Return strDS

    End Function

    '## 12/18/2007  added by lily
    Public Function GetVoucherInquiryDetail(ByVal VoucherNo As String, ByVal InvoiceNo As String) As VoucherData
        Dim sql As String = "APEX_wc_getvoucherinquirydetail"
        Dim objVoucherData As New VoucherData
        Me.OpenConnection()
        With Me.Command
            .CommandType = CommandType.StoredProcedure
            .CommandText = sql
            .Parameters.AddWithValue("@acct_id", MySession.AcctID)
            .Parameters.AddWithValue("@sub_acct_id", MySession.SubAcctID)
            .Parameters.AddWithValue("@voucher_no", VoucherNo)
            .Parameters.AddWithValue("@invoice_no", InvoiceNo)
            Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)
            If Me.Reader.Read Then
                With objVoucherData
                    .confirmation_no = Me.Check_DBNULL(Me.Reader.Item("confirmation_no"))
                    .voucher_no = Me.Check_DBNULL(Me.Reader.Item("Voucher_No"))
                    .invoice_no = Me.Check_DBNULL(Me.Reader.Item("Invoice_No"))
                    .invoice_date = Me.Check_DBNULL(Me.Reader.Item("Invoice_Date"))
                    .car_no = Me.Check_DBNULL(Me.Reader.Item("Car_No"))
                    .Passenger = Me.Check_DBNULL(Me.Reader.Item("Passenger"))
                    .pu_date_time = Me.Check_DBNULL(Me.Reader.Item("Pu_Date_Time"))
                    .Pu_address = Me.Check_DBNULL(Me.Reader.Item("Pu_Address"))
                    .Dest_address = Me.Check_DBNULL(Me.Reader.Item("Dest_Address"))
                    .base_rate = Me.Check_DBNULL(Me.Reader.Item("base_rate"))
                    .tolls = Me.Check_DBNULL(Me.Reader.Item("tolls"))
                    .parking = Me.Check_DBNULL(Me.Reader.Item("parking"))
                    .wait_amount = Me.Check_DBNULL(Me.Reader.Item("wait_amount"))
                    .stops_amt = Me.Check_DBNULL(Me.Reader.Item("stops_amt"))
                    .stop_wt_amount = Me.Check_DBNULL(Me.Reader.Item("stop_wt_amount"))
                    .package_amt = Me.Check_DBNULL(Me.Reader.Item("package_amt"))
                    .phone_amt = Me.Check_DBNULL(Me.Reader.Item("phone_amt"))
                    .service_fee = Me.Check_DBNULL(Me.Reader.Item("service_fee"))
                    .miscellaneous = Me.Check_DBNULL(Me.Reader.Item("miscellaneous"))
                    .tips = Me.Check_DBNULL(Me.Reader.Item("tips"))
                    .gross = Me.Check_DBNULL(Me.Reader.Item("gross"))
                    .OT_surcharge_amt = Me.Check_DBNULL(Me.Reader.Item("surcharge"))
                    .Discount = Me.Check_DBNULL(Me.Reader.Item("discount"))
                    .net = Me.Check_DBNULL(Me.Reader.Item("net"))
                    .comment = Me.Check_DBNULL(Me.Reader.Item("comment"))
                    .cc_date = Me.Check_DBNULL(Me.Reader.Item("cc_settle_comment"))

                    .comp_id_1 = Me.Check_DBNULL(Me.Reader.Item("comp_id_1"))
                    .comp_id_2 = Me.Check_DBNULL(Me.Reader.Item("comp_id_2"))
                    .comp_id_3 = Me.Check_DBNULL(Me.Reader.Item("comp_id_3"))
                    .comp_id_4 = Me.Check_DBNULL(Me.Reader.Item("comp_id_4"))
                    .comp_id_5 = Me.Check_DBNULL(Me.Reader.Item("comp_id_5"))
                    .comp_id_6 = Me.Check_DBNULL(Me.Reader.Item("comp_id_6"))
                End With
            End If
        End With

        Return objVoucherData


    End Function
    Public Function GetCompofVoucherInquiryDetail(ByVal VoucherNo As String, ByVal InvoiceNo As String) As DataSet

        Dim sql As String = "APEX_wc_getvoucherinquirydetail"
        Dim strDS As DataSet

        Me.SelectCommand = New SqlCommand
        With Me.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = sql
            .Parameters.AddWithValue("@acct_id", MySession.AcctID)
            .Parameters.AddWithValue("@sub_acct_id", MySession.SubAcctID)
            .Parameters.AddWithValue("@voucher_no", VoucherNo)
            .Parameters.AddWithValue("@invoice_no", InvoiceNo)
            'Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)

        End With


        strDS = Me.QueryData("comp")

        Return strDS


    End Function
    '## add by lily 12/18/2007
    Private Function Check_DBNULL(ByVal Value As Object) As String

        If IsDBNull(Value) = True Then
            Return Nothing
        Else
            Return Convert.ToString(Value).Trim()
        End If

    End Function
End Class
