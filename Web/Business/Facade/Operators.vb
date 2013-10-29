Imports DataAccess
Imports Business.Common
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Text.RegularExpressions
Imports System.Text

Public Class Operators
    Inherits CommonDB

    Private m_intCount As Int32
    Private m_fields(40) As String
    Private m_values(40) As String

    Public Property Count() As Int32
        Get
            Return m_intCount
        End Get
        Set(ByVal Value As Int32)
            m_intCount = Value
        End Set
    End Property
    Public ReadOnly Property Fields() As String()
        Get
            Return m_fields
        End Get
    End Property
    Public ReadOnly Property Values() As String()
        Get
            Return m_values
        End Get
    End Property

    '--------------------------------------------------------------------
    '--Function:GetRides
    '--Description:  fills out the screen with ride information
    '--Input:Confirmation#
    '--Output:True -Succeed;False - Failed
    '--------------------------------------------------------------------
    Public Function FillRides(ByVal Conf_No As String) As OperatorData

        Dim strSQL As String
        Dim ds As DataSet
        strSQL = "APEX_wr_operator_fillrides"
        Dim objOperatorData As New OperatorData

        Try
            With Me.SelectCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@confirmation_no", Conf_No)
                ds = Me.QueryData("oper")
            End With

            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
                .Parameters.Add("@confirmation_no", Conf_No)
                Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)


                If ds.Tables.Count > 0 Then
                    If Me.Reader.Read Then
                        With objOperatorData
                            .confirmation_no = Conf_No
                            '--add by daniel for get account_no
                            '.CC_Code_Default = Me.Check_DBNULL(Me.Reader.Item("auth_telno"))
                            .opr_comment = Me.Check_DBNULL(Me.Reader.Item("opr_comment"))
                            .account_no = Me.Check_DBNULL(Me.Reader.Item("account_no"))
                            '-------------------------------------------------------------
                            .fname = Me.Check_DBNULL(Me.Reader.Item("fname"))
                            .lname = Me.Check_DBNULL(Me.Reader.Item("lname"))
                            .pu_phone = Me.Check_DBNULL(Me.Reader.Item("pu_phone"))
                            .pu_phone_ext = Me.Check_DBNULL(Me.Reader.Item("pu_phone_ext"))
                            .Comp_id_1 = Me.Check_DBNULL(Me.Reader.Item("comp_id_1"))
                            .Comp_id_2 = Me.Check_DBNULL(Me.Reader.Item("comp_id_2"))
                            .Comp_id_3 = Me.Check_DBNULL(Me.Reader.Item("comp_id_3"))
                            .Comp_id_4 = Me.Check_DBNULL(Me.Reader.Item("comp_id_4"))
                            .Comp_id_5 = Me.Check_DBNULL(Me.Reader.Item("comp_id_5"))
                            .Comp_id_6 = Me.Check_DBNULL(Me.Reader.Item("comp_id_6"))
                            .req_date_time = Me.Check_DBNULL_Date(Me.Reader.Item("req_date_time"))
                            .car_no = Me.Check_DBNULL(Me.Reader.Item("car_no"))
                            .eta_time = Me.Check_DBNULL(Me.Reader.Item("eta_time"))
                            .pu_st_no = Me.Check_DBNULL(Me.Reader.Item("pu_st_no"))
                            .pu_st_name = Me.Check_DBNULL(Me.Reader.Item("pu_st_name"))
                            .pu_city = Me.Check_DBNULL(Me.Reader.Item("pu_city"))
                            .pu_county = Me.Check_DBNULL(Me.Reader.Item("pu_county"))
                            .pu_zip = Me.Check_DBNULL(Me.Reader.Item("pu_zip"))
                            .pu_landmark = Me.Check_DBNULL(Me.Reader.Item("pu_landmark"))
                            .pu_point = Me.Check_DBNULL(Me.Reader.Item("pu_point"))
                            .Car_type = Me.Check_DBNULL(Me.Reader.Item("car_type"))
                            .dest_st_no = Me.Check_DBNULL(Me.Reader.Item("dest_st_no"))
                            .dest_st_name = Me.Check_DBNULL(Me.Reader.Item("dest_st_name"))
                            .dest_x_st = Me.Check_DBNULL(Me.Reader.Item("dest_x_st"))
                            .dest_city = Me.Check_DBNULL(Me.Reader.Item("dest_city"))
                            .dest_county = Me.Check_DBNULL(Me.Reader.Item("dest_county"))
                            .dest_zip = Me.Check_DBNULL(Me.Reader.Item("dest_zip"))
                            .dest_landmark = Me.Check_DBNULL(Me.Reader.Item("dest_landmark"))

                            .dest_phone = Me.Check_DBNULL(Me.Reader.Item("dest_phone"))
                            .auth_telno = Me.Check_DBNULL(Me.Reader.Item("auth_telno"))

                            .airport_airline = Me.Check_DBNULL(Me.Reader.Item("airport_airline"))
                            .airport_flight = Me.Check_DBNULL(Me.Reader.Item("airport_flight"))
                            .airport_terminal = Me.Check_DBNULL(Me.Reader.Item("airport_terminal"))
                            .airport_pu_point = Me.Check_DBNULL(Me.Reader.Item("airport_pu_point"))
                            .airport_comment = Me.Check_DBNULL(Me.Reader.Item("airport_comment"))
                            .airport_from = Me.Check_DBNULL(Me.Reader.Item("airport_from"))
                            '.direction = Me.Check_DBNULL(Me.Reader.Item("direction"))
                            .price_est = Me.Check_DBNULL(Me.Reader.Item("price_est"))
                            .email_add = Me.Check_DBNULL(Me.Reader.Item("email_address"))
                            .status_flag = Me.Check_DBNULL(Me.Reader.Item("status_flag"))
                            .dest_airport_airline = Me.Check_DBNULL(Me.Reader.Item("dest_airport_airline"))
                            .dest_airport_flight = Me.Check_DBNULL(Me.Reader.Item("dest_airport_flight"))
                            .dest_airport_terminal = Me.Check_DBNULL(Me.Reader.Item("dest_airport_terminal"))
                            .dest_airport_point = Me.Check_DBNULL(Me.Reader.Item("dest_airport_point"))
                            .dest_airport_comment = Me.Check_DBNULL(Me.Reader.Item("dest_airport_comment"))
                            .dest_airport_from = Me.Check_DBNULL(Me.Reader.Item("dest_airport_from"))
                            .vip_phone = Me.Check_DBNULL(Me.Reader.Item("vip_phone"))
                            .airport_name = Me.Check_DBNULL(Me.Reader.Item("airport_name"))
                            .dest_aiport_name = Me.Check_DBNULL(Me.Reader.Item("dest_airport_name"))
                            .pu_x_st = Me.Check_DBNULL(Me.Reader.Item("pu_x_st"))
                            .pax_no = Me.Check_DBNULL(Me.Reader.Item("no_pass"))
                            .voucher_no = Me.Check_DBNULL(Me.Reader.Item("voucher_no"))
                            .dest_point = Me.Check_DBNULL(Me.Reader.Item("dest_point"))
                            .direction = Me.Check_DBNULL(Me.Reader.Item("direction_type"))

                            .card_no = Me.Check_DBNULL(Me.Reader.Item("card_no"))
                            .card_exp_date = Me.Check_DBNULL(Me.Reader.Item("card_exp_date"))
                            '## added by joey   2/13/2008
                            .card_auth_no = Me.Check_DBNULL(Me.Reader.Item("card_auth_no"))
                            .cc_refer_id = Me.Check_DBNULL(Me.Reader.Item("cc_refer_id"))

                            '.card_name = Me.Check_DBNULL(Me.Reader.Item("card_name"))
                            '.payment_type = Me.Check_DBNULL(Me.Reader.Item("payment_type"))
                            '.Car_type_Desc = Me.Check_DBNULL(Me.Reader.Item("car_type_desc"))
                            .CC_Type_Default = Me.Check_DBNULL(Me.Reader.Item("card_type"))
                            .CC_No_Default = Me.Check_DBNULL(Me.Reader.Item("card_no"))
                            .CC_Exp_Date_Default = Me.Check_DBNULL(Me.Reader.Item("card_exp_date"))
                            '.CC_Name_Default = Me.Check_DBNULL(Me.Reader.Item("card_name"))
                            .payment_type = Me.Check_DBNULL(Me.Reader.Item("payment_type"))
                            .Car_type_Desc = Me.Check_DBNULL(Me.Reader.Item("car_type_desc"))

                            If Not IsDBNull(ds.Tables(0).Rows(0)) Then
                                If Convert.ToString(ds.Tables(0).Rows(0).Item("direction_type")) = "P" Then
                                    .pu_direction = Convert.ToString(ds.Tables(0).Rows(0).Item("direction_text"))
                                Else
                                    .dest_direction = Convert.ToString(ds.Tables(0).Rows(0).Item("direction_text"))
                                End If
                            End If

                            If ds.Tables(0).Rows.Count = 2 Then
                                If Convert.ToString(ds.Tables(0).Rows(1).Item("direction_type")) = "P" Then
                                    .pu_direction = Convert.ToString(ds.Tables(0).Rows(1).Item("direction_text"))
                                Else
                                    .dest_direction = Convert.ToString(ds.Tables(0).Rows(1).Item("direction_text"))
                                End If
                            End If

                            .PuAir = Me.Check_DBNULL(Me.Reader.Item("PuAir"))
                            .DestAir = Me.Check_DBNULL(Me.Reader.Item("DestAir"))
   
                            .option_9 = Convert.ToChar(Me.Check_DBNULL(Me.Reader.Item("option_9")))
                            'If IsDBNull(Me.Reader.Item("no_hours")) = True Then
                            '    .no_hours = 0D
                            'Else
                            '    .no_hours = Convert.ToDecimal(Me.Reader.Item("no_hours"))
                            'End If

                            'If IsDBNull(Me.Reader.Item("no_car_seat")) = True Then
                            '    .no_car_seat = 0
                            'Else
                            '    .no_car_seat = Convert.ToInt16(Me.Reader.Item("no_car_seat"))
                            'End If

                            '--add by eJay 2/1/05, enabled them again by eJay 10/3/2006 
                            '.Base_rate = Convert.ToDecimal(Me.Reader.Item("basic_rate"))
                            '.tolls_charges = Convert.ToDecimal(Me.Reader.Item("tolls_charges"))
                            '.parking_charges = Convert.ToDecimal(Me.Reader.Item("parking_charges"))
                            '.stops_charges = Convert.ToDecimal(Me.Reader.Item("stops_charges"))
                            '.WT_charges = Convert.ToDecimal(Me.Reader.Item("WT_charges"))
                            ''.tell_charages
                            '.service_fee = Convert.ToDecimal(Me.Reader.Item("service_fee"))
                            '.M_G_charges = Convert.ToDecimal(Me.Reader.Item("M_G_charges"))
                            ''.package
                            '.OT_charges = Convert.ToDecimal(Me.Reader.Item("OT_charges"))
                            '.tips_charges = Convert.ToDecimal(Me.Reader.Item("tips_charges"))
                            '.STC_charges = Convert.ToDecimal(Me.Reader.Item("STC_charges"))
                            '.expenses = Convert.ToDecimal(Me.Reader.Item("expenses"))
                            '.discount_cert = Convert.ToDecimal(Me.Reader.Item("discount_cert"))
                            '.discount = Convert.ToDecimal(Me.Reader.Item("discount"))
                            '.deposit = Convert.ToDecimal(Me.Reader.Item("deposit"))
                            ''.ticket_charges = Convert.ToDecimal(Me.Reader.Item("ticket_charges"))
                            ''.car_seat_charges = Convert.ToDecimal(Me.Reader.Item("car_seat_charges"))

                            ''add jack 01/28/05
                            '.tips_perc = Convert.ToDecimal(Me.Check_DBNULL(Me.Reader.Item("tips_perc")))
                            '.discount_cert_perc = Convert.ToDecimal(Me.Check_DBNULL(Me.Reader.Item("discount_cert_perc")))

                            'add daniel 27/10/06
                            .dest_airport_departureTime = Me.Check_DBNULL(Me.Reader.Item("dest_airport_dest"))

                            .vip_no = Convert.ToString(Me.Reader.Item("vip_no")).Trim   '## 12/4/2007   yang

                        End With
                        Me.Reader.Close()


                    End If
                End If
            End With

        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing
            Me.CloseConnection()

        End Try
        ds.Dispose()
        ds = Nothing
        Return objOperatorData

    End Function
    '--------------------------------------------------------------------
    '--Function:GetRides
    '--Description:  fills out the screen with ride information
    '--Input:Confirmation#
    '--Output:True -Succeed;False - Failed
    '--------------------------------------------------------------------
    Public Function VoucherDetails(ByVal Conf_No As String) As OperatorData

        Dim strSQL As String
        Dim ds As DataSet
        strSQL = "MTC_wr_Voucher_Detail_RideHistory"
        Dim objOperatorData As New OperatorData

        Try
            With Me.SelectCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@confirmno", Conf_No)
                ds = Me.QueryData("oper")
            End With

            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
                .Parameters.Add("@confirmno", Conf_No)
                Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)


                If ds.Tables.Count > 0 Then
                    If Me.Reader.Read Then
                        With objOperatorData
                            .confirmation_no = Conf_No
                            .voucher_no = Me.Check_DBNULL(Me.Reader.Item("voucher_no"))
                            .fname = Me.Check_DBNULL(Me.Reader.Item("fname"))
                            .lname = Me.Check_DBNULL(Me.Reader.Item("lname"))
                            .account_no = Me.Check_DBNULL(Me.Reader.Item("account_no"))
                            .sub_account_no = Me.Check_DBNULL(Me.Reader.Item("sub_account_no"))
                            .pu_st_no = Me.Check_DBNULL(Me.Reader.Item("pu_st_no"))
                            .pu_st_name = Me.Check_DBNULL(Me.Reader.Item("pu_st_name"))
                            .pu_x_st = Me.Check_DBNULL(Me.Reader.Item("pu_x_st"))
                            .pu_city = Me.Check_DBNULL(Me.Reader.Item("pu_city"))
                            .pu_county = Me.Check_DBNULL(Me.Reader.Item("pu_county"))
                            .pu_zip = Me.Check_DBNULL(Me.Reader.Item("pu_zip"))
                            .dest_st_no = Me.Check_DBNULL(Me.Reader.Item("dest_st_no"))
                            .dest_st_name = Me.Check_DBNULL(Me.Reader.Item("dest_st_name"))
                            .dest_x_st = Me.Check_DBNULL(Me.Reader.Item("dest_x_st"))
                            .dest_city = Me.Check_DBNULL(Me.Reader.Item("dest_city"))
                            .dest_county = Me.Check_DBNULL(Me.Reader.Item("dest_county"))
                            .dest_zip = Me.Check_DBNULL(Me.Reader.Item("dest_zip"))
                            .pu_landmark = Me.Check_DBNULL(Me.Reader.Item("pu_landmark"))
                            .dest_landmark = Me.Check_DBNULL(Me.Reader.Item("dest_landmark"))
                            .vip_no = Me.Check_DBNULL(Me.Reader.Item("vip_no"))
                            .Comp_id_1 = Me.Check_DBNULL(Me.Reader.Item("comp_id_1"))
                            .Comp_id_2 = Me.Check_DBNULL(Me.Reader.Item("comp_id_2"))
                            .Comp_id_3 = Me.Check_DBNULL(Me.Reader.Item("comp_id_3"))
                            .Comp_id_4 = Me.Check_DBNULL(Me.Reader.Item("comp_id_4"))
                            .Comp_id_5 = Me.Check_DBNULL(Me.Reader.Item("comp_id_5"))
                            .Comp_id_6 = Me.Check_DBNULL(Me.Reader.Item("comp_id_6"))
                            .price_est = Me.Check_DBNULL(Me.Reader.Item("price_est"))
                            .status_flag = Me.Check_DBNULL(Me.Reader.Item("status_flag"))

                            .display_date_time = Me.Check_DBNULL(Me.Reader.Item("display_date_time"))
                            .req_date_time = Me.Check_DBNULL_Date(Me.Reader.Item("req_date_time"))
                            .car_no = Me.Check_DBNULL(Me.Reader.Item("car_no"))
                            .email_add = Me.Check_DBNULL(Me.Reader.Item("email_address"))
                            .eta_time = Me.Check_DBNULL(Me.Reader.Item("eta_time"))
                            .payment_type = Me.Check_DBNULL(Me.Reader.Item("payment_type"))
                            .Car_type = Me.Check_DBNULL(Me.Reader.Item("car_type"))
                            .pu_point = Me.Check_DBNULL(Me.Reader.Item("pu_point"))
                            .dest_is_airport = Me.Check_DBNULL(Me.Reader.Item("dest_is_airport"))
                            .Pu_is_airport = Me.Check_DBNULL(Me.Reader.Item("pu_is_airport"))

                            .Base_rate = Me.Check_DBNULL_Decimal(Me.Reader.Item("base_rate"))
                            .tolls_charges = Me.Check_DBNULL_Decimal(Me.Reader.Item("tolls"))
                            .parking_charges = Me.Check_DBNULL_Decimal(Me.Reader.Item("parking"))
                            .WT_charges = Me.Check_DBNULL_Decimal(Me.Reader.Item("wait_amount"))
                            .Stops_amt = Me.Check_DBNULL_Decimal(Me.Reader.Item("stops_amt"))
                            .Stop_WT_amt = Me.Check_DBNULL_Decimal(Me.Reader.Item("stop_wt_amount"))
                            .package_charges = Me.Check_DBNULL(Me.Reader.Item("package_amt"))
                            .Misc = Me.Check_DBNULL_Decimal(Me.Reader.Item("miscellaneous"))
                            .tel_charges = Me.Check_DBNULL(Me.Reader.Item("phone_amt"))
                            .tips_charges = Me.Check_DBNULL_Decimal(Me.Reader.Item("tips"))
                            .service_fee = Me.Check_DBNULL_Decimal(Me.Reader.Item("service_fee"))
                            .discount = Me.Check_DBNULL_Decimal(Me.Reader.Item("Discount"))
                            .price_est = Me.Check_DBNULL(Me.Reader.Item("Net"))
                            .Wait_time_charges = Me.Check_DBNULL_Decimal(Me.Reader.Item("wait_time"))
                            .M_G_charges = Me.Check_DBNULL_Decimal(Me.Reader.Item("meet_greet_amt"))
                            .OT_charges = Me.Check_DBNULL_Decimal(Me.Reader.Item("OT_surcharge_amt"))
                            .expenses = Me.Check_DBNULL_Decimal(Me.Reader.Item("cash_layout"))
                            .STC_charges = Me.Check_DBNULL_Decimal(Me.Reader.Item("STC_charges"))
                            .discount_cert = Me.Check_DBNULL_Decimal(Me.Reader.Item("certif_discount"))


                        End With
                        Me.Reader.Close()


                    End If
                End If
            End With

        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing
            Me.CloseConnection()

        End Try
        ds.Dispose()
        ds = Nothing
        Return objOperatorData

    End Function
    '------------------------------------------------------------------------------
    '-- sub get_paymenttype
    '------------------------------------------------------------------------------
    Public Function get_paymenttype(ByVal payment_type_id As String) As String
        Dim SQLStr As String
        Dim DS As DataSet

        SQLStr = "select payment_type_desc from payment_type(nolock) where payment_type = '" & Trim(payment_type_id) & "'"

        Try
            DS = Me.QueryData(SQLStr, "get_paymenttype")
        Catch ex As Exception
            DS = Nothing
        End Try

        If Not DS Is Nothing Then
            If DS.Tables.Count > 0 Then
                If DS.Tables(0).Rows.Count > 0 Then
                    get_paymenttype = Me.Check_DBNULL(DS.Tables(0).Rows(0).Item("payment_type_desc"))
                Else
                    get_paymenttype = ""
                End If
            Else
                get_paymenttype = ""
            End If
        Else
            get_paymenttype = ""
        End If

        DS.Dispose()
        DS = Nothing
        Return get_paymenttype

    End Function
    '------------------------------------------------------------------------------
    '-- sub display_cartype
    '------------------------------------------------------------------------------
    Public Function display_cartype(ByVal cartype As String) As String
        Dim SQLStr As String
        Dim DS As DataSet

        SQLStr = "select car_type_desc from car_type(nolock) where car_type_id = '" & Trim(cartype) & "'"

        Try
            DS = Me.QueryData(SQLStr, "display_cartype")
        Catch ex As Exception
            DS = Nothing
        End Try

        If Not DS Is Nothing Then
            If DS.Tables.Count > 0 Then
                If DS.Tables(0).Rows.Count > 0 Then
                    display_cartype = Me.Check_DBNULL(DS.Tables(0).Rows(0).Item("car_type_desc"))
                Else
                    display_cartype = ""
                End If
            Else
                display_cartype = ""
            End If
        Else
            display_cartype = ""
        End If

        DS.Dispose()
        DS = Nothing
        Return display_cartype

    End Function

    '------------------------------------------------------------------------------
    '-- sub get_direction
    '------------------------------------------------------------------------------
    Public Function get_direction(ByVal strConfirmNo As String) As String
        Dim SQLStr As String
        Dim DS As DataSet

        SQLStr = "select direction_text from operator_direction(nolock) where confirmation_no = '" & Trim(strConfirmNo) & "'"

        Try
            DS = Me.QueryData(SQLStr, "get_direction")
        Catch ex As Exception
            DS = Nothing
        End Try

        If Not DS Is Nothing Then
            If DS.Tables.Count > 0 Then
                If DS.Tables(0).Rows.Count > 0 Then
                    get_direction = Me.Check_DBNULL(DS.Tables(0).Rows(0).Item("direction_text"))
                Else
                    get_direction = ""
                End If
            Else
                get_direction = ""
            End If
        Else
            get_direction = ""
        End If

        DS.Dispose()
        DS = Nothing
        Return get_direction

    End Function
    '------------------------------------------------------------------------------
    '-- sub create_compid
    '------------------------------------------------------------------------------
    Public Function create_compid_info(ByVal acct_id As String, ByVal sub_acct_id As String, ByVal company As String, ByVal i As Integer) As String
        Dim SQLStr As String
        Dim DS As DataSet

        SQLStr = "select req_desc from account a(nolock) inner join company_requirement cr(nolock) on "
        SQLStr = SQLStr & " a.comp_req_" & i + 1 & " = cr.req_id where a.acct_id = '" & Trim(acct_id)
        SQLStr = SQLStr & "' and a.sub_acct_id = '" & Trim(sub_acct_id) & "' and a.company = '" & Trim(company) & "'"

        Try
            DS = Me.QueryData(SQLStr, "create_compid_info")
        Catch ex As Exception
            DS = Nothing
        End Try

        If Not DS Is Nothing Then
            If DS.Tables.Count > 0 Then
                If DS.Tables(0).Rows.Count > 0 Then
                    create_compid_info = Me.Check_DBNULL(DS.Tables(0).Rows(0).Item("req_desc"))
                    'Response.Write("<tr><td " & cssDesc & "><b>" & cssFont)
                    'Response.write(SentenceCase(comp_desc) & "</font></td>")
                    'Response.Write("<td>" & cssFont2 & arrCompID(i - 1) & "</font></td></tr>")
                Else
                    create_compid_info = ""
                End If
            Else
                create_compid_info = ""
            End If
        Else
            create_compid_info = ""
        End If

        DS.Dispose()
        DS = Nothing

        Return create_compid_info

    End Function
    '--------------------------------------------------------------------
    '--Function:Create_compid
    '--Description:Get req_desc from company_requirement
    '--Input:AcctID,Sub_Acct_ID,Company,Conf_No
    '--Output:DataSet
    '--11/04/04 - Created (eJay)
    '--------------------------------------------------------------------
    Public Function Create_compid(ByVal AcctID As String, ByVal Sub_Acct_ID As String, ByVal Company As String, ByVal Conf_No As String) As DataSet

        Dim strSQL As String
        strSQL = "APEX_wr_CompanyRequirement_getDescription"

        Dim tmpDS As New DataSet

        Try

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@acct_id", AcctID)
                .Parameters.Add("@sub_acct_id", Sub_Acct_ID)
                .Parameters.Add("@company", Company)
                .Parameters.Add("@confirmation_no", Conf_No)

                tmpDS = Me.QueryData("Compid")

            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        'If tmpDS.Tables.Count = 0 Then
        '    tmpDS = Nothing

        'End If
        Return tmpDS

    End Function

    '--------------------------------------------------------------------
    '--Function:Check_stops
    '--Description:Check stops
    '--Input:Confirmation#
    '--Output:String YES for having stops
    '--11/04/04 - Created (eJay)
    '--------------------------------------------------------------------
    Public Function Check_stops(ByVal Conf_No As String) As String

        Dim strSQL As String
        strSQL = "MTC_wr_operator_checkstops"

        Dim strResult As String
        Dim iNumBack As Int16

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@confirmation_no", Conf_No)
                .Parameters.Add("@num_back", iNumBack)
                .Parameters("@num_back").Direction = ParameterDirection.Output

                .ExecuteNonQuery()

                iNumBack = Convert.ToInt16(.Parameters("@num_back").Value)

                If iNumBack = 1 Then
                    strResult = "YES"
                Else
                    strResult = "NO"
                End If

            End With

        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Return strResult

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
    '-------------------------------------------------------------------
    '--Function:Check_DBNULL
    '--Description:Check the value 
    '--Input:Value
    '--Output:Nothing for DBNULL
    '--11/4/04 - Created (eJay)
    '-------------------------------------------------------------------
    Private Function Check_DBNULL_Decimal(ByVal Value As Object) As Decimal

        If IsDBNull(Value) = True Then
            Return Nothing
        Else
            Return Convert.ToDecimal(Value)
        End If

    End Function

    '-------------------------------------------------------------------
    '--Function:Check_DBNULL
    '--Description:Check the value 
    '--Input:Value
    '--Output:Nothing for DBNULL
    '--11/4/04 - Created (eJay)
    '-------------------------------------------------------------------
    Private Function Check_DBNULL_Date(ByVal Value As Object) As DateTime

        If IsDBNull(Value) = True Then
            Return Nothing
        Else
            Return Convert.ToDateTime(Value)
        End If

    End Function


	Public Function Insert_Operator_Info(ByVal op As OperatorData, ByVal field_name As String, ByVal original As String, ByVal new_content As String) As Int16

		Dim encoder As New Encoder()
		Dim corrFeeStr As String = encoder.Encode(op.confirmation_no)
		Dim corrFee = Decimal.Parse(corrFeeStr)

		Dim iResult As Int16
		Me.OpenConnection()
		Try
			With Me.Command
				.CommandType = CommandType.StoredProcedure
				.CommandText = "apex_wr_operator_insert"
				.Parameters.Clear()
				.Parameters.AddWithValue("@corrFee", corrFee)
				.Parameters.AddWithValue("@field_name", field_name)
				.Parameters.AddWithValue("@original_content", original)
				.Parameters.AddWithValue("@new_content", new_content)
				.Parameters.AddWithValue("@Acct_ID", op.account_no)
				.Parameters.AddWithValue("@lname", op.pass_lname)
				.Parameters.AddWithValue("@fname", op.pass_fname)
				.Parameters.AddWithValue("@auth_lname", op.lname)
				.Parameters.AddWithValue("@auth_fname", op.fname)
				.Parameters.AddWithValue("@status_flag ", op.status_flag)
				.Parameters.AddWithValue("@req_date_time ", op.req_date_time)
				.Parameters.AddWithValue("@Priority ", op.priority)
				.Parameters.AddWithValue("@company ", op.company)
				.Parameters.AddWithValue("@original_company ", op.original_company)
				.Parameters.AddWithValue("@confirm_id ", op.confirmation_no)
				.Parameters.AddWithValue("@voucher_no ", "")

				.Parameters.AddWithValue("@comp_id_1 ", op.Comp_id_1)
				.Parameters.AddWithValue("@comp_id_2 ", op.Comp_id_2)
				.Parameters.AddWithValue("@comp_id_3 ", op.Comp_id_3)
				.Parameters.AddWithValue("@comp_id_4 ", op.Comp_id_4)
				.Parameters.AddWithValue("@comp_id_5 ", op.Comp_id_5)
				.Parameters.AddWithValue("@comp_id_6 ", op.Comp_id_6)

				.Parameters.AddWithValue("@Comp_Info0 ", op.comp_req_1)
				.Parameters.AddWithValue("@Comp_Info1 ", op.comp_req_2)
				.Parameters.AddWithValue("@Comp_Info2 ", op.comp_req_3)
				.Parameters.AddWithValue("@Comp_Info3 ", op.comp_req_4)
				.Parameters.AddWithValue("@Comp_Info4 ", op.comp_req_5)
				.Parameters.AddWithValue("@Comp_Info5 ", op.comp_req_6)

				.Parameters.AddWithValue("@sub_acct_id ", op.sub_account_no)
				.Parameters.AddWithValue("@user_id ", op.vip_no)


				.Parameters.AddWithValue("@pu_date_time ", op.pu_date_time)
				.Parameters.AddWithValue("@PCity", op.pu_city)
				.Parameters.AddWithValue("@PState ", op.pu_county)
				.Parameters.AddWithValue("@PPoint ", op.pu_point)
				.Parameters.AddWithValue("@PStrNo ", op.pu_st_no)
				.Parameters.AddWithValue("@PStrName", op.pu_st_name)

				.Parameters.AddWithValue("@pu_disp_zone", op.pu_disp_zone)		'## 12/7/2007   (yang)
				.Parameters.AddWithValue("@pu_price_zone", op.pu_price_zone)	'## 12/7/2007   (yang)

				.Parameters.AddWithValue("@pu_directions ", op.pu_direction)	   '--add by lily 12/06/2007

				.Parameters.AddWithValue("@PPhone ", op.pu_phone)
				.Parameters.AddWithValue("@PPhone_ext ", op.pu_phone_ext)		'--add by daniel 24/2/2007


				.Parameters.AddWithValue("@DCity ", op.dest_city)
				.Parameters.AddWithValue("@DState ", op.dest_county)
				.Parameters.AddWithValue("@DPoint ", "")
				.Parameters.AddWithValue("@DStrNo ", op.dest_st_no)
				.Parameters.AddWithValue("@DStrName ", op.dest_st_name)

				.Parameters.AddWithValue("@dest_disp_zone", op.dest_disp_zone)		'## 12/7/2007   (yang)
				.Parameters.AddWithValue("@dest_price_zone", op.dest_price_zone)	'## 12/7/2007   (yang)

				.Parameters.AddWithValue("@dest_directions", op.dest_direction)		  '--add by lily 12/06/2007

				.Parameters.AddWithValue("@PAirport ", op.airport_name)
				'.Parameters.AddWithValue("@PAirportDesc", op.airport_name_desc)
				.Parameters.AddWithValue("@PAirline ", op.airport_airline)
				.Parameters.AddWithValue("@PFlightNo ", op.airport_flight)
				.Parameters.AddWithValue("@PAirlineT ", op.airport_terminal)
				.Parameters.AddWithValue("@PPointAP ", op.airport_pu_point)
				.Parameters.AddWithValue("@PAirCity ", op.airport_from)


				.Parameters.AddWithValue("@PXStr ", "")
				.Parameters.AddWithValue("@DXStr ", op.dest_x_st)


				.Parameters.AddWithValue("@car_type ", op.Car_type)

				.Parameters.Add(New SqlParameter(("@CardT"), SqlDbType.Char, 1))
				.Parameters("@CardT").Value = op.card_type

				.Parameters.AddWithValue("@card_no ", op.card_no)

				.Parameters.Add(New SqlParameter(("@card_exp_date"), SqlDbType.Char, 4))
				.Parameters("@card_exp_date").Value = op.card_exp_date

				'## added by joey   1/25/2008
				'## 1/25/2008   Modified by yang
				If op.card_auth_no Is Nothing Then op.card_auth_no = ""
				.Parameters.AddWithValue("@card_auth_no", op.card_auth_no)

				.Parameters.AddWithValue("@card_name ", op.card_name)

				.Parameters.AddWithValue("@DAirport ", op.dest_aiport_name)
				'.Parameters.AddWithValue("@DAirportDesc", op.dest_airport_name_desc)
				.Parameters.AddWithValue("@DAirline ", op.dest_airport_airline)
				.Parameters.AddWithValue("@DFlightNo ", op.dest_airport_flight)
				.Parameters.AddWithValue("@DAirlineT ", op.dest_airport_terminal)
				.Parameters.AddWithValue("@DPointAP ", op.dest_airport_point)
				.Parameters.AddWithValue("@DAirCity ", op.dest_airport_from)
				.Parameters.AddWithValue("@DPhone", op.dest_phone)


				.Parameters.AddWithValue("@DPhone_ext", op.dest_phone_ext)

				.Parameters.AddWithValue("@pu_landmark ", op.pu_landmark)
				.Parameters.AddWithValue("@dest_landmark ", op.dest_landmark)


				.Parameters.AddWithValue("@PZipCode ", op.pu_zip)
				.Parameters.AddWithValue("@DZipCode ", op.dest_zip)

				.Parameters.AddWithValue("@PFlightTime ", op.airport_time)
				.Parameters.AddWithValue("@DFlightTime ", op.dest_airport_departureTime)
				.Parameters.AddWithValue("@fbo_name ", op.fbo_name)
				.Parameters.AddWithValue("@fbo_address ", op.fbo_address)
				.Parameters.AddWithValue("@dest_fbo_name ", op.dest_fbo_name)
				.Parameters.AddWithValue("@dest_fbo_address", op.dest_fbo_address)


				' .Parameters.addwithvalue("@direction ", op.direction)
				.Parameters.AddWithValue("@paymenttype ", op.payment_type)
				.Parameters.AddWithValue("@email ", op.email_add)
				.Parameters.AddWithValue("@airport_from ", op.airport_from)
				.Parameters.AddWithValue("@stops ", op.stops)


				.Parameters.AddWithValue("@pu_airline_code ", "")
				.Parameters.AddWithValue("@dest_airline_code ", "")
				.Parameters.AddWithValue("@vip_phone ", IIf(Not op.vip_phone Is Nothing, op.vip_phone, ""))
				If Not op.dest_phone_ext Is Nothing Then
					.Parameters.AddWithValue("@vip_phone_ext", op.dest_phone_ext)
				Else
					.Parameters.AddWithValue("@vip_phone_ext", "")
				End If

				.Parameters.AddWithValue("@no_pass", "1")

				'--add by eJay 11/23/04 for add stops===================================
				.Parameters.AddWithValue("@isairport1", "")
				.Parameters.AddWithValue("@isairport2", "")
				.Parameters.AddWithValue("@isairport3", "")

				.Parameters.AddWithValue("@city_airline_1", "")
				.Parameters.AddWithValue("@city_airline_2", "")
				.Parameters.AddWithValue("@city_airline_3", "")

				.Parameters.AddWithValue("@county_1", "")
				.Parameters.AddWithValue("@county_2", "")
				.Parameters.AddWithValue("@county_3", "")

				.Parameters.AddWithValue("@state_airport_1", "")
				.Parameters.AddWithValue("@state_airport_2", "")
				.Parameters.AddWithValue("@state_airport_3", "")

				.Parameters.AddWithValue("@st_no_flight_1", "")
				.Parameters.AddWithValue("@st_no_flight_2", "")
				.Parameters.AddWithValue("@st_no_flight_3", "")

				.Parameters.AddWithValue("@st_name_airp_from_1", "")
				.Parameters.AddWithValue("@st_name_airp_from_2", "")
				.Parameters.AddWithValue("@st_name_airp_from_3", "")

				.Parameters.AddWithValue("@x_street_airp_dest_1", "")
				.Parameters.AddWithValue("@x_street_airp_dest_2", "")
				.Parameters.AddWithValue("@x_street_airp_dest_3", "")

				'.Parameters.addwithvalue("@landmark_terminal_1", op.landmark_terminal_1)
				'.Parameters.addwithvalue("@landmark_terminal_2", op.landmark_terminal_2)
				'.Parameters.addwithvalue("@landmark_terminal_3", op.landmark_terminal_3)

				.Parameters.Add("@numback", SqlDbType.Int)
				.Parameters("@numback").Direction = ParameterDirection.Output

				.Parameters.AddWithValue("@meet_great", op.Meet_great)
				.Parameters.AddWithValue("@share", "")
				.Parameters.Add("@price_est", SqlDbType.Decimal)
				'## add by joey 11/22/2007
				.Parameters.AddWithValue("@AuthPhone", op.auth_telno)
				'## added by joey   1/29/2008
				If op.cc_refer_id Is Nothing Then op.cc_refer_id = ""
				.Parameters.AddWithValue("@cc_refer_id", op.cc_refer_id)

				If op.price_est.Length = 0 Then
					.Parameters("@price_est").Value = 0.0
				Else
					.Parameters("@price_est").Value = Convert.ToDecimal(op.price_est)
				End If

				.ExecuteNonQuery()
				iResult = Convert.ToInt16(.Parameters("@numback").Value)
			End With
		Catch ex As Exception
			Me.ErrorMessage = ex.Message
			iResult = -1
		End Try
		Me.CloseConnection()
		Return iResult
	End Function
    '-------------------------------------------------------------------
    '--Function:Update_Operator_info
    '--Description:
    '--Input:operatordata
    '--Output:iResult
    '--11/16/04 - Created (jack)
    '-------------------------------------------------------------------
    Public Function Update_Operator_Info(ByVal op As OperatorData) As Int16
        Dim iResult As Int16
        Me.OpenConnection()
        Try
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "apex_wr_operator_update"
                .Parameters.Clear()
                ''--add by daniel 02/09/06
                '.Parameters.addwithvalue("@field_name", struser_name)
                '.Parameters.addwithvalue("@original_content", stroriginal_content)
                '.Parameters.addwithvalue("@new_content", strnew_content)
                '===========================

                .Parameters.AddWithValue("@Acct_ID", op.account_no)
                .Parameters.AddWithValue("@lname", op.pass_lname)
                .Parameters.AddWithValue("@fname", op.pass_fname)
                .Parameters.AddWithValue("@auth_lname", op.lname)
                .Parameters.AddWithValue("@auth_fname", op.fname)
                .Parameters.AddWithValue("@status_flag ", op.status_flag)
                .Parameters.AddWithValue("@req_date_time ", op.req_date_time)
                .Parameters.AddWithValue("@Priority ", op.priority)
                .Parameters.AddWithValue("@company ", op.company)
                .Parameters.AddWithValue("@original_company ", op.original_company)
                .Parameters.AddWithValue("@confirm_id ", op.confirmation_no)
                If op.voucher_no Is Nothing Then
                    .Parameters.AddWithValue("@voucher_no ", "")
                Else
                    .Parameters.AddWithValue("@voucher_no ", op.voucher_no)
                End If


                .Parameters.AddWithValue("@comp_id_1 ", op.Comp_id_1)
                .Parameters.AddWithValue("@comp_id_2 ", op.Comp_id_2)
                .Parameters.AddWithValue("@comp_id_3 ", op.Comp_id_3)
                .Parameters.AddWithValue("@comp_id_4 ", op.Comp_id_4)
                .Parameters.AddWithValue("@comp_id_5 ", op.Comp_id_5)
                .Parameters.AddWithValue("@comp_id_6 ", op.Comp_id_6)

                .Parameters.AddWithValue("@Comp_Info0 ", op.comp_req_1)
                .Parameters.AddWithValue("@Comp_Info1 ", op.comp_req_2)
                .Parameters.AddWithValue("@Comp_Info2 ", op.comp_req_3)
                .Parameters.AddWithValue("@Comp_Info3 ", op.comp_req_4)
                .Parameters.AddWithValue("@Comp_Info4 ", op.comp_req_5)
                .Parameters.AddWithValue("@Comp_Info5 ", op.comp_req_6)

                .Parameters.AddWithValue("@sub_acct_id ", op.sub_account_no)
                .Parameters.AddWithValue("@user_id ", op.vip_no)


                .Parameters.AddWithValue("@pu_date_time ", op.pu_date_time)
                .Parameters.AddWithValue("@PCity ", op.pu_city)
                .Parameters.AddWithValue("@PState ", op.pu_county)
                .Parameters.AddWithValue("@PPoint ", op.pu_point)
                .Parameters.AddWithValue("@PStrNo ", op.pu_st_no)
                .Parameters.AddWithValue("@PStrName ", op.pu_st_name)

                .Parameters.AddWithValue("@pu_disp_zone", op.pu_disp_zone)      '## 12/7/2007   (yang)
                .Parameters.AddWithValue("@pu_price_zone", op.pu_price_zone)    '## 12/7/2007   (yang)

                .Parameters.AddWithValue("@PPhone ", op.pu_phone)
                .Parameters.AddWithValue("@PPhone_ext ", op.pu_phone_ext)       '--add by daniel 24/2/2007
                .Parameters.AddWithValue("@vip_phone ", IIf(Not op.vip_phone Is Nothing, op.vip_phone, "")) '--add by daniel 24/2/2007

                .Parameters.AddWithValue("@DCity ", op.dest_city)
                .Parameters.AddWithValue("@DState ", op.dest_county)
                '.Parameters.AddWithValue("@DPoint ", op.dest_point)
                .Parameters.AddWithValue("@DPoint ", "")
                .Parameters.AddWithValue("@DStrNo ", op.dest_st_no)
                .Parameters.AddWithValue("@DStrName ", op.dest_st_name)

                .Parameters.AddWithValue("@dest_disp_zone", op.dest_disp_zone)      '## 12/7/2007   (yang)
                .Parameters.AddWithValue("@dest_price_zone", op.dest_price_zone)    '## 12/7/2007   (yang)

                .Parameters.AddWithValue("@PAirport ", op.airport_name)
                '.Parameters.AddWithValue("@PAirportDesc", op.airport_name_desc)
                .Parameters.AddWithValue("@PAirline ", op.airport_airline)
                .Parameters.AddWithValue("@PFlightNo ", op.airport_flight)
                .Parameters.AddWithValue("@PAirlineT ", op.airport_terminal)
                .Parameters.AddWithValue("@PPointAP ", op.airport_pu_point)
                .Parameters.AddWithValue("@PAirCity ", op.airport_from)


                '.Parameters.AddWithValue("@PXStr ", op.pu_x_st)
                .Parameters.AddWithValue("@PXStr ", "")
                .Parameters.AddWithValue("@DXStr ", op.dest_x_st)


                .Parameters.AddWithValue("@car_type ", op.Car_type)
                .Parameters.Add(New SqlParameter(("@CardT"), SqlDbType.Char, 1))
                .Parameters("@CardT").Value = op.card_type
                ' .Parameters.addwithvalue("@CardT ", op.dest_st_no) 'op.card_type)
                '## added by joey   1/25/2008
                If op.card_auth_no Is Nothing Then op.card_auth_no = ""
                .Parameters.AddWithValue("@card_auth_no", op.card_auth_no)

                .Parameters.AddWithValue("@card_no ", op.card_no)

                .Parameters.Add(New SqlParameter(("@card_exp_date"), SqlDbType.Char, 4))
                .Parameters("@card_exp_date").Value = op.card_exp_date

                ' .Parameters.addwithvalue("@card_exp_date ", op.card_exp_date)
                .Parameters.AddWithValue("@card_name ", op.card_name)

                .Parameters.AddWithValue("@DAirport ", op.dest_aiport_name)
                '.Parameters.AddWithValue("@DAirportDesc", op.dest_airport_name_desc)
                .Parameters.AddWithValue("@DAirline ", op.dest_airport_airline)
                .Parameters.AddWithValue("@DFlightNo ", op.dest_airport_flight)
                .Parameters.AddWithValue("@DAirlineT ", op.dest_airport_terminal) 'nee
                .Parameters.AddWithValue("@DPointAP ", op.dest_airport_point)
                .Parameters.AddWithValue("@DAirCity ", op.dest_airport_from)
                .Parameters.AddWithValue("@DPhone", op.dest_phone)
             

                .Parameters.AddWithValue("@DPhone_ext", op.dest_phone_ext)      '--add by daniel 24/2/2007

                .Parameters.AddWithValue("@pu_landmark ", op.pu_landmark)
                .Parameters.AddWithValue("@dest_landmark ", op.dest_landmark)


                .Parameters.AddWithValue("@PZipCode ", op.pu_zip)
                .Parameters.AddWithValue("@DZipCode ", op.dest_zip)

                '.Parameters.AddWithValue("@PFlightTime ", op.airport_time)
                '.Parameters.AddWithValue("@DFlightTime ", op.dest_airport_departureTime)
                '.Parameters.AddWithValue("@fbo_name ", op.fbo_name)
                '.Parameters.AddWithValue("@fbo_address ", op.fbo_address)
                '.Parameters.AddWithValue("@dest_fbo_name ", op.dest_fbo_name)
                '.Parameters.AddWithValue("@dest_fbo_address", op.dest_fbo_address)

                ' .Parameters.addwithvalue("@direction ", op.direction)
                .Parameters.AddWithValue("@paymenttype ", op.payment_type)
                .Parameters.AddWithValue("@email ", op.email_add)
                .Parameters.AddWithValue("@airport_from ", op.airport_from)
                .Parameters.AddWithValue("@stops ", op.stops)

                '.Parameters.AddWithValue("@pu_airline_code ", op.pu_airport_airline_code)
                '.Parameters.AddWithValue("@dest_airline_code ", op.dest_aiprot_airline_code)
                .Parameters.AddWithValue("@pu_airline_code ", "")
                .Parameters.AddWithValue("@dest_airline_code ", "")
                '.Parameters.AddWithValue("@vip_phone ", op.vip_phone)
                '.Parameters.AddWithValue("@no_pass", op.pax_no)
                .Parameters.AddWithValue("@no_pass", "")

                '.Parameters.AddWithValue("@pu_directions", op.pu_direction)
                '.Parameters.AddWithValue("@dest_directions", op.dest_direction)



                'add jack 12/02/04==============================================changed 
                .Parameters.Add(New SqlParameter(("@pu_directions"), SqlDbType.Text))
                .Parameters("@pu_directions").Value = op.pu_direction

                .Parameters.Add(New SqlParameter(("@dest_directions"), SqlDbType.Text))
                .Parameters("@dest_directions").Value = op.dest_direction
                '================================================================


                ''--add by jack 12/07/04 ====================================================
                '.Parameters.Add(New SqlParameter(("@option_9"), SqlDbType.Char, 1))
                '.Parameters("@option_9").Value = op.option_9
                '.Parameters.Add(New SqlParameter(("@share"), SqlDbType.Char, 1))
                '.Parameters("@share").Value = op.share
                '.Parameters.Add(New SqlParameter(("@car_seat_type"), SqlDbType.Char, 1))
                '.Parameters("@car_seat_type").Value = op.car_seat_type


                ''--add by eJay 12/15/04====================================================

                '.Parameters.Add("@basic_rate", SqlDbType.Decimal, 9)
                '.Parameters("@basic_rate").Value = op.Base_rate

                '.Parameters.Add("@tips_perc", SqlDbType.Decimal, 9)
                '.Parameters("@tips_perc").Value = op.tips_perc

                '.Parameters.Add("@tolls_charges", SqlDbType.Decimal, 9)
                '.Parameters("@tolls_charges").Value = op.tolls_charges

                '.Parameters.Add("@tips_charges", SqlDbType.Decimal, 9)
                '.Parameters("@tips_charges").Value = op.tips_charges

                '.Parameters.Add("@parking_charges", SqlDbType.Decimal, 9)
                '.Parameters("@parking_charges").Value = op.parking_charges

                '.Parameters.Add("@STC_charges", SqlDbType.Decimal, 9)
                '.Parameters("@STC_charges").Value = op.STC_charges

                '.Parameters.Add("@stops_charges", SqlDbType.Decimal, 9)
                '.Parameters("@stops_charges").Value = op.stops_charges

                '.Parameters.Add("@expenses", SqlDbType.Decimal, 9)
                '.Parameters("@expenses").Value = op.expenses

                '.Parameters.Add("@waiting_time", SqlDbType.SmallInt)
                '.Parameters("@waiting_time").Value = op.waiting_time

                '.Parameters.Add("@discount_cert_perc", SqlDbType.Decimal, 9)
                '.Parameters("@discount_cert_perc").Value = op.discount_cert_perc


                '.Parameters.Add("@WT_charges", SqlDbType.Decimal, 9)
                '.Parameters("@WT_charges").Value = op.WT_charges

                '.Parameters.Add("@discount_cert", SqlDbType.Decimal, 9)
                '.Parameters("@discount_cert").Value = op.discount_cert

                '.Parameters.Add("@service_fee", SqlDbType.Decimal, 9)
                '.Parameters("@service_fee").Value = op.service_fee

                '.Parameters.Add("@discount", SqlDbType.Decimal, 9)
                '.Parameters("@discount").Value = op.discount

                '.Parameters.Add("@deposit", SqlDbType.Decimal, 9)
                '.Parameters("@deposit").Value = op.deposit

                '.Parameters.Add("@M_G_charges", SqlDbType.Decimal, 9)
                '.Parameters("@M_G_charges").Value = op.M_G_charges

                '.Parameters.Add("@ticket_charges", SqlDbType.Decimal, 9)
                '.Parameters("@ticket_charges").Value = op.ticket_charges

                '.Parameters.Add("@car_seat_charges", SqlDbType.Decimal, 9)
                '.Parameters("@car_seat_charges").Value = op.car_seat_charges

                '.Parameters.Add("@OT_charges", SqlDbType.Decimal, 9)
                '.Parameters("@OT_charges").Value = op.OT_charges

                '.Parameters.Add("@price_est", SqlDbType.Decimal, 9)
                '.Parameters("@price_est").Value = op.price_est1

                '.Parameters.Add("@no_hours", SqlDbType.Decimal, 9)
                '.Parameters("@no_hours").Value = op.no_hours

                '.Parameters.Add("@no_car_seat", SqlDbType.TinyInt)
                '.Parameters("@no_car_seat").Value = op.no_car_seat
                '==========================================================================
                '--add by jack 12/20/04 for add stops===================================
                '.Parameters.AddWithValue("@isairport1", op.isairport1)
                '.Parameters.AddWithValue("@isairport2", op.isairport2)
                '.Parameters.AddWithValue("@isairport3", op.isairport3)

                '.Parameters.AddWithValue("@city_airline_1", op.city_airline_1)
                '.Parameters.addwithvalue("@city_airline_2", op.city_airline_2)
                '.Parameters.AddWithValue("@city_airline_3", op.city_airline_3)

                '.Parameters.AddWithValue("@county_1", op.county_1)
                '.Parameters.AddWithValue("@county_2", op.county_2)
                '.Parameters.AddWithValue("@county_3", op.county_3)

                '.Parameters.AddWithValue("@state_airport_1", op.state_airport_1)
                '.Parameters.AddWithValue("@state_airport_2", op.state_airport_2)
                '.Parameters.AddWithValue("@state_airport_3", op.state_airport_3)

                '.Parameters.AddWithValue("@st_no_flight_1", op.st_no_flight_1)
                '.Parameters.AddWithValue("@st_no_flight_2", op.st_no_flight_2)
                '.Parameters.addwithvalue("@st_no_flight_3", op.st_no_flight_3)

                '.Parameters.AddWithValue("@st_name_airp_from_1", op.st_name_airp_from_1)
                '.Parameters.AddWithValue("@st_name_airp_from_2", op.st_name_airp_from_2)
                '.Parameters.AddWithValue("@st_name_airp_from_3", op.st_name_airp_from_3)

                '.Parameters.AddWithValue("@x_street_airp_dest_1", op.x_street_airp_dest_1)
                '.Parameters.AddWithValue("@x_street_airp_dest_2", op.x_street_airp_dest_2)
                '.Parameters.AddWithValue("@x_street_airp_dest_3", op.x_street_airp_dest_3)
                .Parameters.AddWithValue("@isairport1", "")
                .Parameters.AddWithValue("@isairport2", "")
                .Parameters.AddWithValue("@isairport3", "")

                .Parameters.AddWithValue("@city_airline_1", "")
                .Parameters.AddWithValue("@city_airline_2", "")
                .Parameters.AddWithValue("@city_airline_3", "")

                .Parameters.AddWithValue("@county_1", "")
                .Parameters.AddWithValue("@county_2", "")
                .Parameters.AddWithValue("@county_3", "")

                .Parameters.AddWithValue("@state_airport_1", "")
                .Parameters.AddWithValue("@state_airport_2", "")
                .Parameters.AddWithValue("@state_airport_3", "")

                .Parameters.AddWithValue("@st_no_flight_1", "")
                .Parameters.AddWithValue("@st_no_flight_2", "")
                .Parameters.AddWithValue("@st_no_flight_3", "")

                .Parameters.AddWithValue("@st_name_airp_from_1", "")
                .Parameters.AddWithValue("@st_name_airp_from_2", "")
                .Parameters.AddWithValue("@st_name_airp_from_3", "")

                .Parameters.AddWithValue("@x_street_airp_dest_1", "")
                .Parameters.AddWithValue("@x_street_airp_dest_2", "")
                .Parameters.AddWithValue("@x_street_airp_dest_3", "")

                '.Parameters.AddWithValue("@landmark_terminal_1", op.landmark_terminal_1)
                '.Parameters.AddWithValue("@landmark_terminal_2", op.landmark_terminal_2)
                '.Parameters.AddWithValue("@landmark_terminal_3", op.landmark_terminal_3)

                '--add by eJay 2/5/05 --meet_great
                .Parameters.AddWithValue("@meet_great", op.Meet_great)
                '--=======================================================================
                '--add by jack 03/22/05 
                '.Parameters.AddWithValue("@card_auth_no", 1)  'op.card_auth_no)
                '## added by joey   1/29/2008
                If op.cc_refer_id Is Nothing Then op.cc_refer_id = ""
                .Parameters.AddWithValue("@cc_refer_id", op.cc_refer_id)

                ' add by jiafeng  1/16/2006 for estimate prist
                .Parameters.Add("@price_est", SqlDbType.Decimal)
                If op.price_est.Length = 0 Then
                    .Parameters("@price_est").Value = 0.0
                Else
                    .Parameters("@price_est").Value = Convert.ToDecimal(op.price_est)
                End If

                '## add by joey 11/22/2007
                .Parameters.AddWithValue("@AuthPhone", op.auth_telno)

                .Parameters.Add("@numback", SqlDbType.Int)
                .Parameters("@numback").Direction = ParameterDirection.Output


                .ExecuteNonQuery()
                iResult = Convert.ToInt16(.Parameters("@numback").Value)
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
            iResult = -1
        End Try
        Me.CloseConnection()
        Return iResult
    End Function
    '-------------------------------------------------------------------
    '--Function:Insert_Operator_info
    '--Description:
    '--Input:operatordata
    '--Output:iResult
    '--11/16/04 - Created (jack)
    '-------------------------------------------------------------------
    'Public Function Insert_Operator_Info(ByVal op As OperatorData, ByVal field_name As String, ByVal original As String, ByVal new_content As String) As Int16
    '    Dim iResult As Int16
    '    Me.OpenConnection()
    '    Try
    '        With Me.Command
    '            .CommandType = CommandType.StoredProcedure
    '            .CommandText = "apex_wr_operator_insert"
    '            .Parameters.Clear()

    '            .Parameters.AddWithValue("@field_name", sqlsafe(field_name))
    '            .Parameters.AddWithValue("@original_content", sqlsafe(original))
    '            .Parameters.AddWithValue("@new_content", sqlsafe(new_content))
    '            .Parameters.AddWithValue("@Acct_ID", sqlsafe(op.account_no))
    '            .Parameters.AddWithValue("@lname", sqlsafe(op.lname))
    '            .Parameters.AddWithValue("@fname", sqlsafe(op.fname))
    '            .Parameters.AddWithValue("@status_flag ", sqlsafe(op.status_flag))
    '            .Parameters.AddWithValue("@req_date_time ", op.req_date_time)
    '            .Parameters.AddWithValue("@Priority ", sqlsafe(op.priority))
    '            .Parameters.AddWithValue("@company ", sqlsafe(op.company))
    '            .Parameters.AddWithValue("@original_company ", sqlsafe(op.original_company))
    '            .Parameters.AddWithValue("@confirm_id ", sqlsafe(op.confirmation_no))
    '            .Parameters.AddWithValue("@voucher_no ", "")

    '            .Parameters.AddWithValue("@vip_phone ", sqlsafe(op.vip_phone))

    '            .Parameters.AddWithValue("@comp_id_1 ", sqlsafe(op.Comp_id_1))
    '            .Parameters.AddWithValue("@comp_id_2 ", sqlsafe(op.Comp_id_2))
    '            .Parameters.AddWithValue("@comp_id_3 ", sqlsafe(op.Comp_id_3))
    '            .Parameters.AddWithValue("@comp_id_4 ", sqlsafe(op.Comp_id_4))
    '            .Parameters.AddWithValue("@comp_id_5 ", sqlsafe(op.Comp_id_5))
    '            .Parameters.AddWithValue("@comp_id_6 ", sqlsafe(op.Comp_id_6))

    '            .Parameters.AddWithValue("@Comp_Info0 ", sqlsafe(op.comp_req_1))
    '            .Parameters.AddWithValue("@Comp_Info1 ", sqlsafe(op.comp_req_2))
    '            .Parameters.AddWithValue("@Comp_Info2 ", sqlsafe(op.comp_req_3))
    '            .Parameters.AddWithValue("@Comp_Info3 ", sqlsafe(op.comp_req_4))
    '            .Parameters.AddWithValue("@Comp_Info4 ", sqlsafe(op.comp_req_5))
    '            .Parameters.AddWithValue("@Comp_Info5 ", sqlsafe(op.comp_req_6))

    '            .Parameters.AddWithValue("@sub_acct_id ", sqlsafe(op.sub_account_no))
    '            .Parameters.AddWithValue("@user_id ", sqlsafe(op.vip_no))


    '            .Parameters.AddWithValue("@pu_date_time ", op.pu_date_time)
    '            .Parameters.AddWithValue("@PCity ", sqlsafe(op.pu_city))
    '            .Parameters.AddWithValue("@PState ", sqlsafe(op.pu_county))
    '            .Parameters.AddWithValue("@PPoint ", sqlsafe(op.pu_point))
    '            .Parameters.AddWithValue("@PStrNo ", sqlsafe(op.pu_st_no))
    '            .Parameters.AddWithValue("@PStrName ", sqlsafe(op.pu_st_name))
    '            .Parameters.AddWithValue("@PPhone ", sqlsafe(op.pu_phone))
    '            .Parameters.AddWithValue("@PPhoneext ", sqlsafe(op.pu_phone_ext))

    '            .Parameters.AddWithValue("@DCity ", sqlsafe(op.dest_city))
    '            .Parameters.AddWithValue("@DState ", sqlsafe(op.dest_county))
    '            .Parameters.AddWithValue("@DPoint ", "")
    '            .Parameters.AddWithValue("@DStrNo ", sqlsafe(op.dest_st_no))
    '            .Parameters.AddWithValue("@DStrName ", sqlsafe(op.dest_st_name))

    '            '--modify by daniel for pu_county-->airport_name()2006/06/13)
    '            .Parameters.AddWithValue("@PAirport ", sqlsafe(op.airport_name))
    '            .Parameters.AddWithValue("@PAirline ", sqlsafe(op.airport_airline))
    '            .Parameters.AddWithValue("@PFlightNo ", sqlsafe(op.airport_flight))
    '            .Parameters.AddWithValue("@PPointAP ", sqlsafe(op.airport_pu_point))
    '            '.Parameters.Add("@PAirCity ", op.airport_terminal)
    '            .Parameters.AddWithValue("@PAirCity ", "")   '--airport_comment
    '            .Parameters.AddWithValue("@Airport_from ", sqlsafe(op.airport_from))
    '            .Parameters.AddWithValue("@pu_Direction ", sqlsafe(op.pu_direction))

    '            '--add by daniel for pu_zone and dest_zone
    '            .Parameters.AddWithValue("@pu_price_zone", sqlsafe(op.pu_price_zone))
    '            .Parameters.AddWithValue("@dest_price_zone", sqlsafe(op.dest_price_zone))

    '            .Parameters.AddWithValue("@PXStr ", "")
    '            .Parameters.AddWithValue("@DXStr ", sqlsafe(op.dest_x_st))


    '            .Parameters.AddWithValue("@car_type ", sqlsafe(op.Car_type))

    '            If op.Primary_Second_Type = "D" Then
    '                .Parameters.Add(New SqlParameter(("@CardT"), SqlDbType.Char, 1))
    '                .Parameters("@CardT").Value = sqlsafe(op.CC_Type_Default)

    '                .Parameters.Add("@card_no ", sqlsafe(op.CC_No_Default))

    '                .Parameters.Add(New SqlParameter(("@card_exp_date"), SqlDbType.Char, 4))
    '                .Parameters("@card_exp_date").Value = sqlsafe(op.CC_Exp_Date_Default)

    '                .Parameters.Add("@card_name ", sqlsafe(op.CC_Name_Default))
    '                .Parameters.AddWithValue("@auth_telno", sqlsafe(op.CC_Code_Default))
    '            ElseIf op.Primary_Second_Type = "P" Then
    '                .Parameters.Add(New SqlParameter(("@CardT"), SqlDbType.Char, 1))
    '                .Parameters("@CardT").Value = sqlsafe(op.card_type)

    '                .Parameters.Add("@card_no ", sqlsafe(op.card_no))

    '                .Parameters.Add(New SqlParameter(("@card_exp_date"), SqlDbType.Char, 4))
    '                .Parameters("@card_exp_date").Value = sqlsafe(op.card_exp_date)

    '                .Parameters.Add("@card_name ", sqlsafe(op.card_name))
    '                .Parameters.AddWithValue("@auth_telno", sqlsafe(op.CC_V_Code))
    '            ElseIf op.Primary_Second_Type = "S" Then
    '                .Parameters.Add(New SqlParameter(("@CardT"), SqlDbType.Char, 1))
    '                .Parameters("@CardT").Value = sqlsafe(op.CCType1)

    '                .Parameters.Add("@card_no ", sqlsafe(op.CCNo1))

    '                .Parameters.Add(New SqlParameter(("@card_exp_date"), SqlDbType.Char, 4))
    '                .Parameters("@card_exp_date").Value = sqlsafe(op.card_exp_date1)

    '                .Parameters.Add("@card_name ", sqlsafe(op.CCName1))
    '                .Parameters.AddWithValue("@auth_telno", sqlsafe(op.CC_V_Code2))
    '            ElseIf op.Primary_Second_Type = "N" Then
    '                .Parameters.Add(New SqlParameter(("@CardT"), SqlDbType.Char, 1))
    '                .Parameters("@CardT").Value = sqlsafe(op.CC_Type_New)

    '                .Parameters.Add("@card_no ", sqlsafe(op.CC_No_New))

    '                .Parameters.Add(New SqlParameter(("@card_exp_date"), SqlDbType.Char, 4))
    '                .Parameters("@card_exp_date").Value = sqlsafe(op.CC_Exp_Date_New)

    '                .Parameters.Add("@card_name ", sqlsafe(op.CC_Name_New))
    '                .Parameters.AddWithValue("@auth_telno", sqlsafe(op.CC_Code_New))
    '            End If

    '            '--modify by daniel for dest_county-->dest_airport_name()2006/06/13)
    '            .Parameters.AddWithValue("@DAirport ", sqlsafe(op.dest_aiport_name))
    '            .Parameters.AddWithValue("@DAirline ", sqlsafe(op.dest_airport_airline))
    '            .Parameters.AddWithValue("@DFlightNo ", sqlsafe(op.dest_airport_flight))
    '            ' .Parameters.Add("@DPointAP ", op.dest_airport_point)
    '            .Parameters.AddWithValue("@DPointAP ", sqlsafe(op.dest_airport_departureTime))        '--modify by dest_airport_point to dest_airport_departuretime
    '            '.Parameters.Add("@DAirCity ", op.dest_airport_terminal)
    '            .Parameters.AddWithValue("@DAirCity ", sqlsafe(op.dest_airport_comment))     '--dest_airport_comment
    '            .Parameters.AddWithValue("@Dest_Airport_from ", sqlsafe(op.dest_airport_from))
    '            .Parameters.AddWithValue("@DPhone ", sqlsafe(op.dest_phone))
    '            .Parameters.AddWithValue("@dest_Direction ", sqlsafe(op.dest_direction))
    '            '--add by daniel 27/10/06
    '            .Parameters.AddWithValue("@pu_landmark", sqlsafe(op.pu_landmark))
    '            .Parameters.AddWithValue("@dest_landmark", sqlsafe(op.dest_landmark))

    '            .Parameters.AddWithValue("@PZipCode ", sqlsafe(op.pu_zip))
    '            .Parameters.AddWithValue("@DZipCode ", sqlsafe(op.dest_zip))

    '            ' .Parameters.Add("@direction ", op.direction)
    '            .Parameters.AddWithValue("@paymenttype ", sqlsafe(op.payment_type))
    '            .Parameters.AddWithValue("@email ", sqlsafe(op.email_add))
    '            '.Parameters.Add("@airport_from ", op.airport_from)
    '            '.Parameters.Add("@stops ", op.stops)

    '            .Parameters.AddWithValue("@pu_airline_code ", sqlsafe(op.pu_airport_airline_code))
    '            .Parameters.AddWithValue("@dest_airline_code ", sqlsafe(op.dest_aiprot_airline_code))
    '            '.Parameters.Add("@vip_phone ", op.vip_phone)
    '            .Parameters.AddWithValue("@no_pass", 1) '--change it to 1

    '            '--add by eJay 11/23/04 for add stops===================================
    '            .Parameters.AddWithValue("@isairport1", "")
    '            .Parameters.AddWithValue("@isairport2", "")
    '            .Parameters.AddWithValue("@isairport3", "")

    '            .Parameters.AddWithValue("@city_airline_1", "")
    '            .Parameters.AddWithValue("@city_airline_2", "")
    '            .Parameters.AddWithValue("@city_airline_3", "")

    '            .Parameters.AddWithValue("@county_1", "")
    '            .Parameters.AddWithValue("@county_2", "")
    '            .Parameters.AddWithValue("@county_3", "")

    '            .Parameters.AddWithValue("@state_airport_1", "")
    '            .Parameters.AddWithValue("@state_airport_2", "")
    '            .Parameters.AddWithValue("@state_airport_3", "")

    '            .Parameters.AddWithValue("@st_no_flight_1", "")
    '            .Parameters.AddWithValue("@st_no_flight_2", "")
    '            .Parameters.AddWithValue("@st_no_flight_3", "")

    '            .Parameters.AddWithValue("@st_name_airp_from_1", "")
    '            .Parameters.AddWithValue("@st_name_airp_from_2", "")
    '            .Parameters.AddWithValue("@st_name_airp_from_3", "")

    '            .Parameters.AddWithValue("@x_street_airp_dest_1", "")
    '            .Parameters.AddWithValue("@x_street_airp_dest_2", "")
    '            .Parameters.AddWithValue("@x_street_airp_dest_3", "")

    '            '.Parameters.Add("@landmark_terminal_1", op.landmark_terminal_1)
    '            '.Parameters.Add("@landmark_terminal_2", op.landmark_terminal_2)
    '            '.Parameters.Add("@landmark_terminal_3", op.landmark_terminal_3)

    '            .Parameters.Add("@numback", SqlDbType.Int)
    '            .Parameters("@numback").Direction = ParameterDirection.Output

    '            .Parameters.AddWithValue("@meet_great", sqlsafe(op.Meet_great))
    '            .Parameters.AddWithValue("@share", "")

    '            .Parameters.AddWithValue("@mileage", op.Mileage)
    '            .Parameters.AddWithValue("@basic_rate", op.Base_rate)
    '            .Parameters.AddWithValue("@tolls_charges", op.tolls_charges)
    '            .Parameters.AddWithValue("@parking_charges", op.parking_charges)
    '            .Parameters.AddWithValue("@stops_charges", op.stops_charges)
    '            .Parameters.AddWithValue("@WT_charges", op.WT_charges)
    '            .Parameters.AddWithValue("@tel_charges", IIf(Trim(op.tel_charges) = "", "0.00", op.tel_charges))
    '            .Parameters.AddWithValue("@M_G_charges", op.M_G_charges)
    '            .Parameters.AddWithValue("@package_charges", IIf(Trim(op.package_charges) = "", "0.00", op.package_charges))
    '            .Parameters.AddWithValue("@OT_charges", op.OT_charges)
    '            .Parameters.AddWithValue("@tips_charges", op.tips_charges)
    '            .Parameters.AddWithValue("@discount", op.discount)
    '            .Parameters.AddWithValue("@STC_charges", op.STC_charges)
    '            .Parameters.AddWithValue("@service_fee", op.service_fee)

    '            .Parameters.AddWithValue("@Price_est", CSng(op.price_est))

    '            '--add by eJay 10/3/2006
    '            .Parameters.AddWithValue("@customer_text", sqlsafe(Left(op.vip_text, 255)))
    '            .Parameters.AddWithValue("@account_text", sqlsafe(Left(op.account_text, 255)))
    '            .Parameters.AddWithValue("@pu_disp_zone", op.pu_disp_zone)
    '            .Parameters.AddWithValue("@dest_disp_zone", op.dest_disp_zone)
    '            '--add by daniel 11/13/2006
    '            .Parameters.AddWithValue("@opr_comments", sqlsafe(op.opr_comment))
    '            '--add by eJay 10/4/2006
    '            .Parameters.AddWithValue("@card_auth_no", sqlsafe(Left(op.card_auth_no, 6)))
    '            .Parameters.AddWithValue("@cc_refer_id", sqlsafe(Left(op.cc_refer_id, 12)))
    '            .Parameters.AddWithValue("@cc_verify_comment", sqlsafe(Left(op.cc_verify_comment, 100)))

    '            .ExecuteNonQuery()
    '            iResult = Convert.ToInt16(.Parameters("@numback").Value)
    '        End With
    '    Catch ex As Exception
    '        Me.ErrorMessage = ex.Message
    '        iResult = -1
    '    End Try
    '    Me.CloseConnection()
    '    Return iResult
    'End Function

    '------------------------------------------------------------------------------
    '-- Function: getconfirmno
    '-- Description:  getconfirmno from table"system parameter"
    '-- Output: int32
    '-- Table: system parameter
    '-- Stored Procedure: GET_CONFIRMATION1
    '-- 11/16/04 - Created (jack)
    '------------------------------------------------------------------------------
    Public Function getconfirmno() As DataSet

        Return Me.QueryData("exec apex_wr_get_confirmation", "confirmono")

    End Function

    '------------------------------------------------------------------------------
    '-- Function: get comp_req form table account
    '-- Description:  
    '-- Output: dataset
    '-- Table: account
    '-- Stored Procedure: Get_Account_comp_req
    '-- 11/16/04 - Created (jack)
    '------------------------------------------------------------------------------
    Public Function Get_Account_comp_req(ByVal stracc_id As String, ByVal strsub_acc_id As String) As DataSet


        Dim tmpDS As New DataSet

        Try

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = "apex_wr_account_com_req_select"

                .Parameters.Add("@acct_id", stracc_id)
                .Parameters.Add("@sub_acct_id", strsub_acc_id)

                tmpDS = Me.QueryData("comp_req")

            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return tmpDS


    End Function


    '------------------------------------------------------------------------------
    '-- Function: get vip_text  form table vip  
    '-- Description:  
    '-- Output: dataset
    '-- Table: account
    '-- Stored Procedure: Get_Vip_Vip_text
    '-- 11/16/04 - Created (jack)
    '------------------------------------------------------------------------------
    Public Function Get_Vip_Vip_text(ByVal struser_id As String, ByVal stracc_id As String, ByVal strsub_acc_id As String) As DataSet


        Dim tmpDS As New DataSet

        Try

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = "APEX_wr_vip_select_vip_text"

                .Parameters.Add("@user_id", struser_id)
                .Parameters.Add("@acct_id", stracc_id)
                .Parameters.Add("@sub_acct_id", strsub_acc_id)

                tmpDS = Me.QueryData("vip_text")

            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return tmpDS


    End Function

    '------------------------------------------------------------------------------
    '-- Function: used to calcuate the pickupdatetime from the req_date_time 
    '-- Description:  
    '-- Output: dataset
    '-- Table: city
    '-- Stored Procedure: calc_pu_date_time
    '-- 11/22/04 - Created (jack)
    '------------------------------------------------------------------------------
    Function calc_pu_date_time(ByVal req_date_time As DateTime, ByVal pu_county As String, ByVal pu_city As String) As DateTime
        Dim pickup_time As DateTime
        Dim eta As Int32
        Dim ds As DataSet
        pickup_time = req_date_time
        '----- If within the 5 boroughs
        If pu_county = "M" Or pu_county = "BX" Or pu_county = "BK" Or pu_county = "SI" Or pu_county = "QU" Then
            pickup_time = DateAdd("n", -20, pickup_time)
        Else

            Try

                With Me.SelectCommand
                    .CommandType = CommandType.Text
                    .CommandText = "select eta from city(nolock) where state = '" & pu_county & "' and name = '" & pu_city & "'"
                    ds = Me.QueryData(.CommandText, "etaselect")
                    If Not IsDBNull(ds) Then
                        If IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                            eta = -120
                        Else
                            '--add by eJay 10/3/2006, Default to -120 mins if city.eta = 0.
                            If Convert.ToInt32(ds.Tables(0).Rows(0).Item(0)) = 0 Then
                                eta = -120
                            Else
                                eta = -1 * Convert.ToInt32(ds.Tables(0).Rows(0).Item(0))
                            End If
                        End If
                        pickup_time = DateAdd("n", eta, pickup_time)
                        ds.Dispose()
                        ds = Nothing
                    Else
                        pickup_time = DateAdd("n", -120, pickup_time)
                    End If
                End With

            Catch ex As Exception
                pickup_time = DateAdd("n", -120, pickup_time)       '--ADD BY eJay 10/4/2006
                Me.ErrorMessage = ex.Message
            Finally

                Me.SelectCommand.Dispose()
                Me.SelectCommand = Nothing
            End Try
        End If
        Return pickup_time
    End Function
    '-------------------------------------------------------------------
    '--Function:get_closedate
    '--Description:
    '--Input:stracc_id,strsub_acct_id
    '--Output:closedate
    '--11/12/04 - Created (jack)
    '-------------------------------------------------------------------


    Function get_closedate(ByVal stracc_id As String, ByVal strsub_acct_id As String) As DateTime
        Dim ds As DataSet
        Dim closedate As DateTime

        With Me.SelectCommand
            Try
                .CommandType = CommandType.Text
                .CommandText = "select close_date from account(nolock) where acct_id = '" & stracc_id & "' and sub_acct_id = '" & strsub_acct_id & "'"
                ds = Me.QueryData(.CommandText, "closedate")
                If Not IsDBNull(ds) Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        closedate = Convert.ToDateTime(ds.Tables(0).Rows(0).Item(0))
                    Else
                        closedate = Nothing

                    End If

                Else
                    closedate = Nothing

                End If
            Catch ex As Exception
                Me.ErrorMessage = ex.Message
            Finally
                Me.SelectCommand.Dispose()
                Me.SelectCommand = Nothing


            End Try
        End With
        ds.Dispose()
        ds = Nothing
        Return closedate
    End Function

    '-------------------------------------------------------------------
    '--Function:Update_Operator_info
    '--Description:
    '--Input:operatordata
    '--Output:iResult
    '--11/16/04 - Created (jack)
    '-------------------------------------------------------------------
    'Public Function Update_Operator_Info(ByVal op As OperatorData, ByVal field_name As String, ByVal original As String, ByVal new_content As String) As Int16
    '    Dim iResult As Int16
    '    Me.OpenConnection()
    '    Try
    '        With Me.Command
    '            .CommandType = CommandType.StoredProcedure
    '            .CommandText = "apex_wr_operator_update"
    '            .Parameters.Clear()

    '            .Parameters.Add("@field_name", sqlsafe(field_name))
    '            .Parameters.Add("@original_content", sqlsafe(original))
    '            .Parameters.Add("@new_content", sqlsafe(new_content))
    '            .Parameters.Add("@Acct_ID", sqlsafe(op.account_no))
    '            .Parameters.Add("@lname", sqlsafe(op.lname))
    '            .Parameters.Add("@fname", sqlsafe(op.fname))
    '            .Parameters.Add("@status_flag ", sqlsafe(op.status_flag))
    '            .Parameters.Add("@req_date_time ", op.req_date_time)
    '            .Parameters.Add("@Priority ", sqlsafe(op.priority))
    '            .Parameters.Add("@company ", sqlsafe(op.company))
    '            .Parameters.Add("@original_company ", sqlsafe(op.original_company))
    '            .Parameters.Add("@confirm_id ", sqlsafe(op.confirmation_no))
    '            .Parameters.Add("@voucher_no ", "")

    '            .Parameters.Add("@vip_phone ", sqlsafe(op.vip_phone))

    '            .Parameters.Add("@comp_id_1 ", sqlsafe(op.Comp_id_1))
    '            .Parameters.Add("@comp_id_2 ", sqlsafe(op.Comp_id_2))
    '            .Parameters.Add("@comp_id_3 ", sqlsafe(op.Comp_id_3))
    '            .Parameters.Add("@comp_id_4 ", sqlsafe(op.Comp_id_4))
    '            .Parameters.Add("@comp_id_5 ", sqlsafe(op.Comp_id_5))
    '            .Parameters.Add("@comp_id_6 ", sqlsafe(op.Comp_id_6))

    '            .Parameters.Add("@Comp_Info0 ", sqlsafe(op.comp_req_1))
    '            .Parameters.Add("@Comp_Info1 ", sqlsafe(op.comp_req_2))
    '            .Parameters.Add("@Comp_Info2 ", sqlsafe(op.comp_req_3))
    '            .Parameters.Add("@Comp_Info3 ", sqlsafe(op.comp_req_4))
    '            .Parameters.Add("@Comp_Info4 ", sqlsafe(op.comp_req_5))
    '            .Parameters.Add("@Comp_Info5 ", sqlsafe(op.comp_req_6))

    '            .Parameters.Add("@sub_acct_id ", sqlsafe(op.sub_account_no))
    '            .Parameters.Add("@user_id ", sqlsafe(op.vip_no))


    '            .Parameters.Add("@pu_date_time ", op.pu_date_time)
    '            .Parameters.Add("@PCity ", sqlsafe(op.pu_city))
    '            .Parameters.Add("@PState ", sqlsafe(op.pu_county))
    '            .Parameters.Add("@PPoint ", sqlsafe(op.pu_point))
    '            .Parameters.Add("@PStrNo ", sqlsafe(op.pu_st_no))
    '            .Parameters.Add("@PStrName ", sqlsafe(op.pu_st_name))
    '            .Parameters.Add("@PPhone ", sqlsafe(op.pu_phone))
    '            .Parameters.Add("@PPhoneext ", sqlsafe(op.pu_phone_ext))

    '            .Parameters.Add("@DCity ", sqlsafe(op.dest_city))
    '            .Parameters.Add("@DState ", sqlsafe(op.dest_county))
    '            .Parameters.Add("@DPoint ", "")
    '            .Parameters.Add("@DStrNo ", sqlsafe(op.dest_st_no))
    '            .Parameters.Add("@DStrName ", sqlsafe(op.dest_st_name))

    '            '--modify by daniel for pu_county-->airport_name()2006/06/13)
    '            .Parameters.Add("@PAirport ", sqlsafe(op.airport_name))
    '            .Parameters.Add("@PAirline ", sqlsafe(op.airport_airline))
    '            .Parameters.Add("@PFlightNo ", sqlsafe(op.airport_flight))
    '            .Parameters.Add("@PPointAP ", sqlsafe(op.airport_pu_point))
    '            '.Parameters.Add("@PAirCity ", op.airport_terminal)
    '            .Parameters.Add("@PAirCity ", "")  '--airport_comment
    '            .Parameters.Add("@Airport_from ", sqlsafe(op.airport_from))
    '            .Parameters.Add("@pu_Direction ", sqlsafe(op.pu_direction))

    '            '--add by daniel for pu_zone and dest_zone
    '            .Parameters.Add("@pu_price_zone", sqlsafe(op.pu_price_zone))
    '            .Parameters.Add("@dest_price_zone", sqlsafe(op.dest_price_zone))

    '            .Parameters.Add("@PXStr ", "")
    '            .Parameters.Add("@DXStr ", sqlsafe(op.dest_x_st))

    '            .Parameters.Add("@car_type ", sqlsafe(op.Car_type))

    '            If op.Primary_Second_Type = "D" Then
    '                .Parameters.Add(New SqlParameter(("@CardT"), SqlDbType.Char, 1))
    '                .Parameters("@CardT").Value = sqlsafe(op.CC_Type_Default)

    '                .Parameters.Add("@card_no ", sqlsafe(op.CC_No_Default))

    '                .Parameters.Add(New SqlParameter(("@card_exp_date"), SqlDbType.Char, 4))
    '                .Parameters("@card_exp_date").Value = sqlsafe(op.CC_Exp_Date_Default)

    '                .Parameters.Add("@card_name ", sqlsafe(op.CC_Name_Default))
    '                .Parameters.AddWithValue("@auth_telno", sqlsafe(op.CC_Code_Default))
    '            ElseIf op.Primary_Second_Type = "P" Then
    '                .Parameters.Add(New SqlParameter(("@CardT"), SqlDbType.Char, 1))
    '                .Parameters("@CardT").Value = sqlsafe(op.card_type)

    '                .Parameters.Add("@card_no ", sqlsafe(op.card_no))

    '                .Parameters.Add(New SqlParameter(("@card_exp_date"), SqlDbType.Char, 4))
    '                .Parameters("@card_exp_date").Value = sqlsafe(op.card_exp_date)

    '                .Parameters.Add("@card_name ", sqlsafe(op.card_name))
    '                .Parameters.AddWithValue("@auth_telno", sqlsafe(op.CC_V_Code))
    '            ElseIf op.Primary_Second_Type = "S" Then
    '                .Parameters.Add(New SqlParameter(("@CardT"), SqlDbType.Char, 1))
    '                .Parameters("@CardT").Value = sqlsafe(op.CCType1)

    '                .Parameters.Add("@card_no ", sqlsafe(op.CCNo1))

    '                .Parameters.Add(New SqlParameter(("@card_exp_date"), SqlDbType.Char, 4))
    '                .Parameters("@card_exp_date").Value = sqlsafe(op.card_exp_date1)

    '                .Parameters.Add("@card_name ", sqlsafe(op.CCName1))
    '                .Parameters.AddWithValue("@auth_telno", sqlsafe(op.CC_V_Code2))
    '            ElseIf op.Primary_Second_Type = "N" Then
    '                .Parameters.Add(New SqlParameter(("@CardT"), SqlDbType.Char, 1))
    '                .Parameters("@CardT").Value = sqlsafe(op.CC_Type_New)

    '                .Parameters.Add("@card_no ", sqlsafe(op.CC_No_New))

    '                .Parameters.Add(New SqlParameter(("@card_exp_date"), SqlDbType.Char, 4))
    '                .Parameters("@card_exp_date").Value = sqlsafe(op.CC_Exp_Date_New)

    '                .Parameters.Add("@card_name ", sqlsafe(op.CC_Name_New))
    '                .Parameters.AddWithValue("@auth_telno", sqlsafe(op.CC_Code_New))
    '            End If

    '            '--modify by daniel for dest_county-->dest_airport_name()2006/06/13)
    '            .Parameters.Add("@DAirport ", sqlsafe(op.dest_aiport_name))
    '            .Parameters.Add("@DAirline ", sqlsafe(op.dest_airport_airline))
    '            .Parameters.Add("@DFlightNo ", sqlsafe(op.dest_airport_flight))
    '            ' .Parameters.Add("@DPointAP ", op.dest_airport_point)
    '            .Parameters.Add("@DPointAP ", sqlsafe(op.dest_airport_departureTime))        '--modify by dest_airport_point to dest_airport_departuretime
    '            '.Parameters.Add("@DAirCity ", op.dest_airport_terminal)
    '            .Parameters.Add("@DAirCity ", sqlsafe(op.dest_airport_comment))  '--dest_airport_comment
    '            .Parameters.Add("@Dest_Airport_from ", sqlsafe(op.dest_airport_from))
    '            .Parameters.Add("@DPhone ", sqlsafe(op.dest_phone))
    '            .Parameters.Add("@dest_Direction ", sqlsafe(op.dest_direction))

    '            '--add by daniel 27/10/06
    '            .Parameters.AddWithValue("@pu_landmark", sqlsafe(op.pu_landmark))
    '            .Parameters.AddWithValue("@dest_landmark", sqlsafe(op.dest_landmark))

    '            .Parameters.Add("@PZipCode ", sqlsafe(op.pu_zip))
    '            .Parameters.Add("@DZipCode ", sqlsafe(op.dest_zip))


    '            ' .Parameters.Add("@direction ", op.direction)
    '            .Parameters.Add("@paymenttype ", sqlsafe(op.payment_type))
    '            .Parameters.Add("@email ", sqlsafe(op.email_add))
    '            '.Parameters.Add("@airport_from ", op.airport_from)
    '            '.Parameters.Add("@stops ", op.stops)

    '            .Parameters.Add("@pu_airline_code ", sqlsafe(op.pu_airport_airline_code))
    '            .Parameters.Add("@dest_airline_code ", sqlsafe(op.dest_aiprot_airline_code))
    '            '.Parameters.Add("@vip_phone ", op.vip_phone)
    '            .Parameters.Add("@no_pass", "")

    '            '--add by eJay 11/23/04 for add stops===================================
    '            .Parameters.Add("@isairport1", "")
    '            .Parameters.Add("@isairport2", "")
    '            .Parameters.Add("@isairport3", "")

    '            .Parameters.Add("@city_airline_1", "")
    '            .Parameters.Add("@city_airline_2", "")
    '            .Parameters.Add("@city_airline_3", "")

    '            .Parameters.Add("@county_1", "")
    '            .Parameters.Add("@county_2", "")
    '            .Parameters.Add("@county_3", "")

    '            .Parameters.Add("@state_airport_1", "")
    '            .Parameters.Add("@state_airport_2", "")
    '            .Parameters.Add("@state_airport_3", "")

    '            .Parameters.Add("@st_no_flight_1", "")
    '            .Parameters.Add("@st_no_flight_2", "")
    '            .Parameters.Add("@st_no_flight_3", "")

    '            .Parameters.Add("@st_name_airp_from_1", "")
    '            .Parameters.Add("@st_name_airp_from_2", "")
    '            .Parameters.Add("@st_name_airp_from_3", "")

    '            .Parameters.Add("@x_street_airp_dest_1", "")
    '            .Parameters.Add("@x_street_airp_dest_2", "")
    '            .Parameters.Add("@x_street_airp_dest_3", "")

    '            '.Parameters.Add("@landmark_terminal_1", op.landmark_terminal_1)
    '            '.Parameters.Add("@landmark_terminal_2", op.landmark_terminal_2)
    '            '.Parameters.Add("@landmark_terminal_3", op.landmark_terminal_3)

    '            .Parameters.Add("@numback", SqlDbType.Int)
    '            .Parameters("@numback").Direction = ParameterDirection.Output

    '            .Parameters.Add("@meet_great", sqlsafe(op.Meet_great))
    '            .Parameters.Add("@share", "")

    '            .Parameters.Add("@mileage", op.Mileage)
    '            .Parameters.Add("@basic_rate", op.Base_rate)
    '            .Parameters.Add("@tolls_charges", op.tolls_charges)
    '            .Parameters.Add("@parking_charges", op.parking_charges)
    '            .Parameters.Add("@stops_charges", op.stops_charges)
    '            .Parameters.Add("@WT_charges", op.WT_charges)
    '            .Parameters.Add("@tel_charges", IIf(Trim(op.tel_charges) = "", "0.00", sqlsafe(op.tel_charges)))
    '            .Parameters.Add("@M_G_charges", op.M_G_charges)
    '            .Parameters.Add("@package_charges", IIf(Trim(op.package_charges) = "", "0.00", sqlsafe(op.package_charges)))
    '            .Parameters.Add("@OT_charges", op.OT_charges)
    '            .Parameters.Add("@tips_charges", op.tips_charges)
    '            .Parameters.Add("@discount", op.discount)
    '            .Parameters.Add("@STC_charges", op.STC_charges)
    '            .Parameters.Add("@service_fee", op.service_fee)

    '            .Parameters.Add("@Price_est", CSng(op.price_est))

    '            '--add by eJay 10/3/2006
    '            .Parameters.AddWithValue("@customer_text", sqlsafe(Left(op.vip_text, 255)))
    '            .Parameters.AddWithValue("@account_text", sqlsafe(Left(op.account_text, 255)))
    '            .Parameters.AddWithValue("@pu_disp_zone", op.pu_disp_zone)
    '            .Parameters.AddWithValue("@dest_disp_zone", op.dest_disp_zone)
    '            '--add by daniel 11/13/2006
    '            .Parameters.AddWithValue("@opr_comments", sqlsafe(op.opr_comment))

    '            '--add by eJay 10/4/2006
    '            .Parameters.AddWithValue("@card_auth_no", sqlsafe(Left(op.card_auth_no, 6)))
    '            .Parameters.AddWithValue("@cc_refer_id", sqlsafe(Left(op.cc_refer_id, 12)))
    '            .Parameters.AddWithValue("@cc_verify_comment", sqlsafe(Left(op.cc_verify_comment, 100)))

    '            .ExecuteNonQuery()
    '            iResult = Convert.ToInt16(.Parameters("@numback").Value)
    '        End With
    '    Catch ex As Exception
    '        Me.ErrorMessage = ex.Message
    '        iResult = -1
    '    End Try
    '    Me.CloseConnection()
    '    Return iResult
    'End Function


    '-------------------------------------------------------------------------------
    '--Function:Get_email_Details
    '--Description:get email details with conf#
    '--Input:ConfNo,Status,Email_address
    '--Output:
    '--12/1/04 - Created (eJay)
    '-------------------------------------------------------------------------------
    Public Sub Get_email_Details(ByVal ConfNo As String, ByVal Status As String, ByRef Email_address As String)

      
        Dim strSQL As String = "apex_wr_get_Email_detail" 'change by lily 12/05/2007
        Dim tmpDS As DataSet
        'Dim objMail As New MailData

        Try

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@confirmation_no", ConfNo)
                .Parameters.Add("@status_flag", SqlDbType.Char, 1)
                .Parameters("@status_flag").Direction = ParameterDirection.Output
                .Parameters.Add("@email_addr", SqlDbType.VarChar, 50)
                .Parameters("@email_addr").Direction = ParameterDirection.Output


                tmpDS = Me.QueryData("emaildetail")

                Email_address = .Parameters("@email_addr").Value.ToString

                '--get details
                Dim iFor As Int32 = 0
                Dim iColumnCount As Int32 = 0
                Dim tmpDB As DataTable

                If Not tmpDS Is Nothing Then

                    tmpDB = tmpDS.Tables(0)

                    iColumnCount = tmpDB.Columns.Count

                    Count = iColumnCount

                    Dim i As Int32
                    For i = 0 To iColumnCount - 1

                        If tmpDB.Columns(i).ColumnName.Trim().Substring(0, 6) <> "Column" And i <> 40 Then

                            Me.m_fields(i) = tmpDB.Columns(i).ColumnName
                            Me.m_values(i) = tmpDB.Rows(0).Item(i).ToString

                        ElseIf i = 40 Then

                            Me.m_fields(i) = tmpDB.Columns(i).ColumnName.Replace("Column7", "")
                            Me.m_values(i) = tmpDB.Rows(0).Item(i).ToString

                        Else

                            Me.m_fields(i) = ""


                        End If


                    Next

                    'objMail.Field1 = tmpDB.Columns(0).ColumnName
                    'objMail.Value1 = tmpDB.Rows(0).Item(0).ToString
                    'objMail.Field2 = tmpDB.Columns(1).ColumnName
                    'objMail.Value2 = tmpDB.Rows(0).Item(1).ToString
                    'objMail.Field3 = tmpDB.Columns(2).ColumnName
                    'objMail.Value3 = tmpDB.Rows(0).Item(2).ToString
                    'objMail.Field4 = tmpDB.Columns(3).ColumnName
                    'objMail.Value4 = tmpDB.Rows(0).Item(3).ToString
                    'objMail.Field5 = tmpDB.Columns(4).ColumnName
                    'objMail.Value5 = tmpDB.Rows(0).Item(4).ToString
                    'objMail.Field6 = tmpDB.Columns(5).ColumnName
                    'objMail.Value6 = tmpDB.Rows(0).Item(5).ToString
                    'objMail.Field7 = tmpDB.Columns(6).ColumnName
                    'objMail.Value7 = tmpDB.Rows(0).Item(6).ToString
                    'objMail.Field8 = tmpDB.Columns(7).ColumnName
                    'objMail.Value8 = tmpDB.Rows(0).Item(7).ToString
                    'objMail.Field9 = tmpDB.Columns(8).ColumnName
                    'objMail.Value9 = tmpDB.Rows(0).Item(8).ToString
                    'objMail.Field10 = tmpDB.Columns(9).ColumnName
                    'objMail.Value10 = tmpDB.Rows(0).Item(9).ToString

                    'If iColumnCount > 10 Then
                    '41ge

                    'objMail.Field11 = tmpDB.Columns(10).ColumnName
                    'objMail.Value11 = tmpDB.Rows(0).Item(10).ToString
                    'objMail.Field12 = tmpDB.Columns(11).ColumnName
                    'objMail.Value12 = tmpDB.Rows(0).Item(11).ToString
                    'objMail.Field13 = tmpDB.Columns(12).ColumnName
                    'objMail.Value13 = tmpDB.Rows(0).Item(12).ToString

                    'End If

                    tmpDB.Dispose()
                    tmpDB = Nothing


                End If

            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            tmpDS.Dispose()
            tmpDS = Nothing

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try


    End Sub


    '-------------------------------------------------------------------------------
    '--Function:Get_Airline_Code
    '--Description:get airline code by airline name
    '--Input:strairline
    '--Output:airline_code
    '--12/03/04 - Created (jack)
    '-------------------------------------------------------------------------------
    Public Function Get_Airline_Code(ByVal strairline As String) As String

        Dim strSQL As String = "select airline_code from airline(NOLOCK) where airline='" & sqlsafe(strairline) & "'"
        Dim airline_code As String
        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.Text
                .CommandText = strSQL
                Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)
                If Me.Reader.Read Then
                    airline_code = Me.Check_DBNULL(Me.Reader.Item("airline_code").ToString)
                Else
                    airline_code = ""
                End If
                Me.Reader.Close()
            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message
        Finally

            Me.CloseConnection()
        End Try
        Return airline_code
    End Function

    '--------------------------------------------------------------------
    '--Function:GetStops
    '--Description:  fills out the screen with stops information
    '--Input:Confirmation#
    '--Output:True -Succeed;False - Failed
    '--12/20/04 - Created (jack)
    '--------------------------------------------------------------------
    Public Function FillStops(ByVal Conf_No As String) As OperatorData

        Dim strSQL As String
        strSQL = "skylimo_wr_operator_fillstops"
        Dim objOperatorData As New OperatorData
        Try

            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
                .Parameters.Add("@confirmation_no", Conf_No)
                Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)


                If Me.Reader.Read Then
                    With objOperatorData
                        .isairport1 = Me.Check_DBNULL(Me.Reader.Item("is_airport_2"))
                        .isairport2 = Me.Check_DBNULL(Me.Reader.Item("is_airport_3"))
                        .isairport3 = Me.Check_DBNULL(Me.Reader.Item("is_airport_4"))
                        .state_airport_1 = Me.Check_DBNULL(Me.Reader.Item("state_airport_2"))
                        .state_airport_2 = Me.Check_DBNULL(Me.Reader.Item("state_airport_3"))
                        .state_airport_3 = Me.Check_DBNULL(Me.Reader.Item("state_airport_4"))
                        .city_airline_1 = Me.Check_DBNULL(Me.Reader.Item("city_airline_2"))
                        .city_airline_2 = Me.Check_DBNULL(Me.Reader.Item("city_airline_3"))
                        .city_airline_3 = Me.Check_DBNULL(Me.Reader.Item("city_airline_4"))
                        .st_no_flight_1 = Me.Check_DBNULL(Me.Reader.Item("st_no_flight_2"))
                        .st_no_flight_2 = Me.Check_DBNULL(Me.Reader.Item("st_no_flight_3"))
                        .st_no_flight_3 = Me.Check_DBNULL(Me.Reader.Item("st_no_flight_4"))
                        .st_name_airp_from_1 = Me.Check_DBNULL(Me.Reader.Item("st_name_airp_from_2"))
                        .st_name_airp_from_2 = Me.Check_DBNULL(Me.Reader.Item("st_name_airp_from_3"))
                        .st_name_airp_from_3 = Me.Check_DBNULL(Me.Reader.Item("st_name_airp_from_4"))
                        .x_street_airp_dest_1 = Me.Check_DBNULL(Me.Reader.Item("x_street_airp_dest_2"))
                        .x_street_airp_dest_2 = Me.Check_DBNULL(Me.Reader.Item("x_street_airp_dest_3"))
                        .x_street_airp_dest_3 = Me.Check_DBNULL(Me.Reader.Item("x_street_airp_dest_4"))
                        .landmark_terminal_1 = Me.Check_DBNULL(Me.Reader.Item("landmark_terminal_2"))
                        .landmark_terminal_2 = Me.Check_DBNULL(Me.Reader.Item("landmark_terminal_3"))
                        .landmark_terminal_3 = Me.Check_DBNULL(Me.Reader.Item("landmark_terminal_4"))
                        .county_1 = Me.Check_DBNULL(Me.Reader.Item("county_2"))
                        .county_2 = Me.Check_DBNULL(Me.Reader.Item("county_3"))
                        .county_3 = Me.Check_DBNULL(Me.Reader.Item("county_4"))
                    End With
                    Me.Reader.Close()
                End If
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try
        Return objOperatorData

    End Function


    '--------------------------------------------------------------------
    '--Function:GetPaymethod
    '--Input:Confirmation#
    '--Output:True -Succeed;False - Failed
    '--8/23/05 - Created (maria)
    '## UserType
    '--#	1)	'group'		Credit Card Only
    '--#	2)	'corporate'	
    '--#	3)	'quick'		Credit Card Only
    '--#	4)	other
    '--------------------------------------------------------------------
    Public Function BindPaymentType(ByRef drpPaymentType As DropDownList, ByVal type As UserType) As Boolean
        Dim ds As DataSet = Me.GetPaymentType(type)
        Dim out As Boolean = True
        If Not ds Is Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            With drpPaymentType
                .DataSource = ds.Tables(0).DefaultView
                .DataTextField = "payment_type_desc"
                .DataValueField = "payment_type"
                .DataBind()
            End With
            out = True
        Else
            out = False
        End If
        Return out
    End Function
    Public Function GetPaymentType(ByVal type As UserType) As DataSet

        Dim sql As String = String.Format("exec apex_wr_get_paymenttype '{0}','{1}','{2}','{3}'", _
                MySession.AcctID, MySession.SubAcctID, MySession.Company, Common.GetUserTypeString(type))

        Return Me.QueryData(sql, "PaymentType")
        'Dim temtable As New DataTable
        'Dim dr As DataRow
        'Dim strsql As String
        'strsql = "MTC_wr_get_paymentall"

        'Try
        '    Me.OpenConnection()
        '    With Me.Command
        '        .CommandType = CommandType.StoredProcedure
        '        .CommandText = strsql
        '        .Parameters.Add("@acct_id", acct_id)
        '        .Parameters.Add("@sub_acct_id", sub_acct_id)
        '        .Parameters.Add("@company", company)
        '        Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)
        '        If Me.Reader.Read Then
        '            Dim strcc As String
        '            Dim strvc As String
        '            Dim strcash As String
        '            'Dim strcheck As String
        '            'Dim strissue As String
        '            'Dim strpaid As String
        '            'Dim strcomplement As String
        '            Dim strdirectbill As String
        '            'Dim strregular As String
        '            Dim strhouse As String
        '            strcc = Me.Check_DBNULL(Me.Reader.Item("req_cc"))
        '            strvc = Me.Check_DBNULL(Me.Reader.Item("req_vc"))
        '            strcash = Me.Check_DBNULL(Me.Reader.Item("cash_account"))
        '            'strcheck = Me.Check_DBNULL(Me.Reader.Item("check_"))
        '            'strissue = Me.Check_DBNULL(Me.Reader.Item("issue_voucher"))
        '            'strpaid = Me.Check_DBNULL(Me.Reader.Item("prepaid"))
        '            'strpaid = Me.Check_DBNULL(Me.Reader.Item("complement"))
        '            strdirectbill = Me.Check_DBNULL(Me.Reader.Item("direct_bill"))
        '            '= Me.Check_DBNULL(Me.Reader.Item("regular_charge"))
        '            strhouse = Me.Check_DBNULL(Me.Reader.Item("in_house_group_1"))
        '            temtable.Columns.Add("type")
        '            temtable.Columns.Add("content")
        '            If strcash = "t" Then
        '                dr = temtable.NewRow
        '                dr.Item(0) = "2"
        '                dr.Item(1) = "Cash"
        '                temtable.Rows.Add(dr)
        '            End If
        '            If strcc = "t" Then
        '                dr = temtable.NewRow
        '                dr.Item(0) = "5"
        '                dr.Item(1) = "Credit Card"
        '                temtable.Rows.Add(dr)
        '            End If
        '            If strdirectbill = "t" Then
        '                dr = temtable.NewRow
        '                dr.Item(0) = "7"
        '                dr.Item(1) = "In house Credit"
        '                temtable.Rows.Add(dr)
        '            End If

        '            'If strvc = "t" Then
        '            '    dr = temtable.NewRow
        '            '    dr.Item(0) = "2"
        '            '    dr.Item(1) = "Voucher"
        '            '    temtable.Rows.Add(dr)
        '            'End If

        '            'If strcc = "t" Then
        '            '    dr = temtable.NewRow
        '            '    dr.Item(0) = "4"
        '            '    dr.Item(1) = "Check "
        '            '    temtable.Rows.Add(dr)
        '            'End If
        '            'If strcc = "t" Then
        '            '    dr = temtable.NewRow
        '            '    dr.Item(0) = "5"
        '            '    dr.Item(1) = "Prepaid    "
        '            '    temtable.Rows.Add(dr)
        '            'End If
        '            'If strcc = "t" Then
        '            '    dr = temtable.NewRow
        '            '    dr.Item(0) = "6"
        '            '    dr.Item(1) = "Credit Card  "
        '            '    temtable.Rows.Add(dr)
        '            'End If
        '            'If strcc = "t" Then
        '            '    dr = temtable.NewRow
        '            '    dr.Item(0) = "7"
        '            '    dr.Item(1) = "Compliment "
        '            '    temtable.Rows.Add(dr)
        '            'End If

        '            'If strcc = "t" Then
        '            '    dr = temtable.NewRow
        '            '    dr.Item(0) = "9"
        '            '    dr.Item(1) = "Regular Charge   "
        '            '    temtable.Rows.Add(dr)
        '            'End If
        '            'If strcc = "t" Then
        '            '    dr = temtable.NewRow
        '            '    dr.Item(0) = "5"
        '            '    dr.Item(1) = "In House Group 1"
        '            '    temtable.Rows.Add(dr)
        '            'End If
        '            Me.Reader.Close()
        '        End If
        '    End With
        'Catch ex As Exception
        '    Me.ErrorMessage = ex.Message
        'Finally
        '    Me.CloseConnection()

        'End Try
        'Return temtable

    End Function
    '--------------------------------------------------------------------
    '--Function:GetPaymethod
    '--Input:Confirmation#
    '--Output:True -Succeed;False - Failed
    '--8/23/05 - Created (maria)
    '--------------------------------------------------------------------
    Public Function GetPaymethod_Group(ByVal acct_id As String, ByVal sub_acct_id As String, ByVal company As String) As DataTable
        Dim temtable As New DataTable
        Dim dr As DataRow
        Dim strsql As String
        strsql = "MTC_wr_get_paymentall_Group"

        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = strsql
                .Parameters.Add("@acct_id", acct_id)
                .Parameters.Add("@sub_acct_id", sub_acct_id)
                .Parameters.Add("@company", company)
                Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)
                If Me.Reader.Read Then
                    Dim strcc As String
                    Dim strvc As String
                    Dim strcash As String
                    'Dim strcheck As String
                    'Dim strissue As String
                    'Dim strpaid As String
                    'Dim strcomplement As String
                    Dim strdirectbill As String
                    Dim strregular As String
                    Dim strhouse As String
                    strcc = Me.Check_DBNULL(Me.Reader.Item("req_cc"))
                    strvc = Me.Check_DBNULL(Me.Reader.Item("req_vc"))
                    strcash = Me.Check_DBNULL(Me.Reader.Item("cash_account"))
                    'strcheck = Me.Check_DBNULL(Me.Reader.Item("check_"))
                    'strissue = Me.Check_DBNULL(Me.Reader.Item("issue_voucher"))
                    'strpaid = Me.Check_DBNULL(Me.Reader.Item("prepaid"))
                    'strpaid = Me.Check_DBNULL(Me.Reader.Item("complement"))
                    strdirectbill = Me.Check_DBNULL(Me.Reader.Item("direct_bill"))
                    strhouse = Me.Check_DBNULL(Me.Reader.Item("in_house_group_1"))
                    strregular = Me.Check_DBNULL(Me.Reader.Item("regular_charge"))

                    temtable.Columns.Add("type")
                    temtable.Columns.Add("content")
                    If strcc = "t" Then
                        dr = temtable.NewRow
                        dr.Item(0) = "5"
                        dr.Item(1) = "Credit Card"
                        temtable.Rows.Add(dr)
                    End If
                    If strdirectbill = "t" Then
                        dr = temtable.NewRow
                        dr.Item(0) = "7"
                        dr.Item(1) = "In house Credit"
                        temtable.Rows.Add(dr)
                    End If
                    If strhouse = "t" Then
                        dr = temtable.NewRow
                        dr.Item(0) = "5"
                        dr.Item(1) = "In house Grp 1"
                        temtable.Rows.Add(dr)
                    End If
                    If strregular = "t" Then
                        dr = temtable.NewRow
                        dr.Item(0) = "9"
                        dr.Item(1) = "Reg Charge"
                        temtable.Rows.Add(dr)
                    End If
                    'If strvc = "t" Then
                    '    dr = temtable.NewRow
                    '    dr.Item(0) = "2"
                    '    dr.Item(1) = "Voucher"
                    '    temtable.Rows.Add(dr)
                    'End If

                    'If strcc = "t" Then
                    '    dr = temtable.NewRow
                    '    dr.Item(0) = "4"
                    '    dr.Item(1) = "Check "
                    '    temtable.Rows.Add(dr)
                    'End If
                    'If strcc = "t" Then
                    '    dr = temtable.NewRow
                    '    dr.Item(0) = "5"
                    '    dr.Item(1) = "Prepaid    "
                    '    temtable.Rows.Add(dr)
                    'End If
                    'If strcc = "t" Then
                    '    dr = temtable.NewRow
                    '    dr.Item(0) = "6"
                    '    dr.Item(1) = "Credit Card  "
                    '    temtable.Rows.Add(dr)
                    'End If
                    'If strcc = "t" Then
                    '    dr = temtable.NewRow
                    '    dr.Item(0) = "7"
                    '    dr.Item(1) = "Compliment "
                    '    temtable.Rows.Add(dr)
                    'End If 
                    Me.Reader.Close()
                End If
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()

        End Try
        Return temtable

    End Function

    '--------------------------------------------------------------------
    '--Function:GetCompanyQue
    '--Input:Confirmation#
    '--Output:True -Succeed;False - Failed
    '--8/23/05 - Created (maria)
    '--------------------------------------------------------------------
    Public Function GetCompanyQue(ByVal acct_id As String, ByVal sub_acct_id As String, ByVal company As String) As DataTable


        Dim tmpDS As DataSet
        tmpDS = New DataSet

        Dim strSQL As String
        strSQL = "apex_wr_CompanyRequirement_get"

        Try

            Me.SelectCommand = New SqlCommand

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
                .Parameters.Add("@acct_id", sqlsafe(acct_id))
                .Parameters.Add("@sub_acct_id", sqlsafe(sub_acct_id))
                .Parameters.Add("@compnay", sqlsafe(company))

            End With
            tmpDS = Me.QueryData("company")

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        If tmpDS Is Nothing Then

            Return Nothing

        Else
            Return tmpDS.Tables("company")
        End If
    End Function
    '--Creator Daniel 
    '--2005-11-18
    '--Function Get operator table comp_req_1~6 value
    Public Function GetRequirmentinfomation_Operator(ByVal strconf As String) As DataTable
        Dim strSqlCmd As String
        Dim m_DataTable As New DataTable

        strSqlCmd = "skylimo_wr_getrequirmentinfomation"

        Try
            Me.SelectCommand = New SqlCommand
            With Me.SelectCommand
                .Parameters.Clear()

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSqlCmd
                .Parameters.Add("@confirmation_no", sqlsafe(strconf))

            End With

            m_DataTable = Me.QueryData("strconf").Tables("strconf")

        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally
            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return m_DataTable

    End Function
    '--Creator:daniel
    '--Function GetRequirment_desc
    '--Output company_requiments table 's req_desc
    '--2005-11-18
    Public Function GetRequirment_desc(ByVal req_id As String, ByVal strOperater As String) As DataTable
        Dim strSqlCmd As String
        Dim m_DataTable As New DataTable

        strSqlCmd = "skylimo_wr_getrequirmentdesciption"

        Try
            Me.SelectCommand = New SqlCommand
            With Me.SelectCommand
                .Parameters.Clear()

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSqlCmd
                .Parameters.Add("@req_id", sqlsafe(req_id))
                .Parameters.Add("@confirmation_no", sqlsafe(strOperater))

            End With

            m_DataTable = Me.QueryData("req_id").Tables("req_id")

        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally
            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return m_DataTable

    End Function
    '--Function companyrequirementcheck
    '--input comp_req_id,comp_req_no
    '--output strRequire
    '--Add by Daniel
    '--2005/12/1
    Public Function companyrequirementcheck(ByVal comp_req_id As String, ByVal comp_req_no As String) As String
        Dim Ds As DataSet
        Dim strRequire As String
        Ds = Me.QueryData("select * from validation where ltrim(rtrim(comp_req_no))='" & sqlsafe(comp_req_no) & "'", "requirement")
        If Ds.Tables("requirement").Rows.Count <> 0 Then
            strRequire = "requirement"
        Else
            'strRequire = "norequirement"
            Ds = Me.QueryData("select req_desc from company_requirement where req_id='" & sqlsafe(comp_req_id) & "'", "requirementlist")
            strRequire = Ds.Tables("requirementlist").Rows(0).Item("req_desc").ToString
        End If
        Return strRequire
    End Function
    '--------------------------------------------------------------------
    '--Function:GetPaymethod
    '--Input:Confirmation#
    '--Output:True -Succeed;False - Failed
    '--8/23/05 - Created (maria)
    '--------------------------------------------------------------------
    Public Function GetPaymethod(ByVal acct_id As String, ByVal sub_acct_id As String, ByVal compnay As String) As DataTable
        Dim temtable As New DataTable
        Dim dr As DataRow
        Dim strSQL As String
        strSQL = "ftl_wr_Get_PaymentTypeList"
        'Dim objOperatorData As New OperatorData
        Try

            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
                .Parameters.AddWithValue("@acct_id", acct_id)
                .Parameters.AddWithValue("@sub_acct_id", sub_acct_id)
                .Parameters.AddWithValue("@compnay", compnay)
                Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)


                If Me.Reader.Read Then
                    Dim req_cc As String
                    Dim req_vc As String
                    Dim cash_account As String
                    Dim check_ As String
                    Dim prepaid As String
                    Dim complement As String
                    Dim direct_bill As String
                    Dim regular_charge As String
                    Dim barter_type As String
                    Dim promotion_type As String
                    Dim donation_type As String

                    req_cc = Trim(Me.Check_DBNULL(Me.Reader.Item("req_cc")))
                    req_vc = Trim(Me.Check_DBNULL(Me.Reader.Item("req_vc")))
                    cash_account = Trim(Me.Check_DBNULL(Me.Reader.Item("cash_account")))
                    'cash				= trim(Me.Check_DBNULL(Me.Reader.Item("cash"))
                    check_ = Trim(Me.Check_DBNULL(Me.Reader.Item("check_")))
                    prepaid = Trim(Me.Check_DBNULL(Me.Reader.Item("prepaid")))
                    complement = Trim(Me.Check_DBNULL(Me.Reader.Item("complement")))
                    direct_bill = Trim(Me.Check_DBNULL(Me.Reader.Item("direct_bill")))
                    'in_house_group_1 = trim(Me.Check_DBNULL(Me.Reader.Item("in_house_group_1"))
                    regular_charge = Trim(Me.Check_DBNULL(Me.Reader.Item("regular_charge")))
                    barter_type = Trim(Me.Check_DBNULL(Me.Reader.Item("barter_type")))
                    promotion_type = Trim(Me.Check_DBNULL(Me.Reader.Item("promotion_type")))
                    donation_type = Trim(Me.Check_DBNULL(Me.Reader.Item("donation_type")))

                    temtable.Columns.Add("type")
                    temtable.Columns.Add("content")
                    If req_vc = "t" Then
                        dr = temtable.NewRow
                        dr.Item(0) = "1"
                        dr.Item(1) = "Voucher"
                        temtable.Rows.Add(dr)
                    End If
                    If cash_account = "t" Then
                        dr = temtable.NewRow
                        dr.Item(0) = "2"
                        dr.Item(1) = "Cash"
                        temtable.Rows.Add(dr)
                    End If
                    If check_ = "t" Then
                        dr = temtable.NewRow
                        dr.Item(0) = "3"
                        dr.Item(1) = "Check"
                        temtable.Rows.Add(dr)
                    End If
                    If prepaid = "t" Then
                        dr = temtable.NewRow
                        dr.Item(0) = "4"
                        dr.Item(1) = "Prepaid"
                        temtable.Rows.Add(dr)
                    End If
                    If req_cc = "t" Then
                        dr = temtable.NewRow
                        dr.Item(0) = "5"
                        dr.Item(1) = "Credit Card"
                        temtable.Rows.Add(dr)
                    End If
                    If complement = "t" Then
                        dr = temtable.NewRow
                        dr.Item(0) = "6"
                        dr.Item(1) = "Non Revenue"
                        temtable.Rows.Add(dr)
                    End If
                    If direct_bill = "t" Then
                        dr = temtable.NewRow
                        dr.Item(0) = "7"
                        dr.Item(1) = "Direct Bill"
                        temtable.Rows.Add(dr)
                    End If
                    If regular_charge = "t" Then
                        dr = temtable.NewRow
                        dr.Item(0) = "8"
                        dr.Item(1) = "Reg Charge"
                        temtable.Rows.Add(dr)
                    End If

                    'If promotion_type = "t" Then
                    '    dr = temtable.NewRow
                    '    dr.Item(0) = "8"
                    '    dr.Item(1) = "Promotional"
                    '    temtable.Rows.Add(dr)
                    'End If
                    If donation_type = "t" Then
                        dr = temtable.NewRow
                        dr.Item(0) = "11"
                        dr.Item(1) = "Donation"
                        temtable.Rows.Add(dr)
                    End If
                    If barter_type = "t" Then
                        dr = temtable.NewRow
                        dr.Item(0) = "12"
                        dr.Item(1) = "Barter"
                        temtable.Rows.Add(dr)
                    End If

                    Me.Reader.Close()
                End If
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try
        Return temtable

    End Function

    '--Created by joey  2/15/2008
    Public Function ValidationReq(ByVal acct_id As String, ByVal sub_acct_id As String, ByVal company As String, ByVal strReq As String()) As Integer
        Dim i As Integer
        Dim out As Integer
        Me.OpenConnection()
        With Me.Command
            Try
                .CommandType = CommandType.StoredProcedure
                .CommandText = "apex_wr_CompanyRequirement_Validation"
                .Parameters.AddWithValue("@acct_id", acct_id)
                .Parameters.AddWithValue("@sub_acct_id", sub_acct_id)
                .Parameters.AddWithValue("@company", company)
                .Parameters.AddWithValue("@req1", strReq(0))
                .Parameters.AddWithValue("@req2", strReq(1))
                .Parameters.AddWithValue("@req3", strReq(2))
                .Parameters.AddWithValue("@req4", strReq(3))
                .Parameters.AddWithValue("@req5", strReq(4))
                .Parameters.AddWithValue("@req6", strReq(5))

                .Parameters.AddWithValue("out", out)
                .Parameters("out").Direction = ParameterDirection.Output
                .ExecuteNonQuery()
                out = .Parameters("out").Value
            Catch ex As Exception

            End Try

        End With
        Me.CloseConnection()
        Return out
    End Function


#Region "Quick_Passenger_Operator_Update"

    Public Function Update_Operator_Quick_Passenger(ByVal strvip_no As String, ByVal straccount_no As String, ByVal strconf As String) As Boolean
        Dim strsql As String
        Dim DS As DataSet

        strsql = "exec MTC_wr_Operator_Update_QuickPassenger '" & sqlsafe(strvip_no) & "','" & sqlsafe(straccount_no) & "','" & sqlsafe(strconf) & "'"

        Try
            DS = Me.QueryData(strsql, "Update_Operator_Quick_Passenger")
            Update_Operator_Quick_Passenger = True
        Catch ex As Exception
            DS = Nothing
            Update_Operator_Quick_Passenger = False
        End Try

        Return Update_Operator_Quick_Passenger

    End Function

#End Region

#Region "DB SQL SAFE"

    Function sqlsafe(ByVal inputvalue As String) As String

        If IsNull(inputvalue) Then
            sqlsafe = ""
        Else
            sqlsafe = Replace(inputvalue, "'", "")
            sqlsafe = Replace(sqlsafe, ",", "")
        End If

    End Function

    Public Function IsNull(ByVal values As String) As Boolean

        If Trim(Convert.ToString(values)) = "" Then

            Return True
        Else
            Return False

        End If

    End Function

#End Region
End Class

Public Class Encoder
	Dim value As String

	Public Function Encode(ByVal value As String) As String
		If String.IsNullOrEmpty(value) Then
			Return value
		End If

		Me.value = value.Trim()

		' Verify that string contains 10 digits
		If Not Regex.IsMatch(value, "^\d{10}") Then
			Return value
		End If

		Dim sum As Integer = Char1 + Char2 + Char34 + Char5 + Char678 + Char9 * 3 + Char10 * 7
		sum *= 4

		Dim sb As New StringBuilder()
		sb.Append((sum / 100D).ToString("n2"))

		Dim lastDigit As Int32 = (10 - Char10)
		If lastDigit = 10 Then
			lastDigit = 0
		End If
		sb(sb.Length - 1) = lastDigit.ToString()(0)
		Return sb.ToString()
	End Function

	Private ReadOnly Property Char1() As Integer
		Get
			Return GetCharAsInt(0)
		End Get
	End Property

	Private ReadOnly Property Char2() As Integer
		Get
			Return GetCharAsInt(1)
		End Get
	End Property

	Private ReadOnly Property Char34() As Integer
		Get
			Return Integer.Parse(value.Substring(2, 2))
		End Get
	End Property

	Private ReadOnly Property Char5() As Integer
		Get
			Return GetCharAsInt(4)
		End Get
	End Property

	Private ReadOnly Property Char678() As Integer
		Get
			Return Integer.Parse(value.Substring(5, 3))
		End Get
	End Property

	Private ReadOnly Property Char9() As Integer
		Get
			Return GetCharAsInt(8)
		End Get
	End Property

	Private ReadOnly Property Char10() As Integer
		Get
			Return GetCharAsInt(9)
		End Get
	End Property

	Private Function GetCharAsInt(ByVal pos As Integer) As Integer
		Return Integer.Parse(value(pos).ToString())
	End Function

End Class
