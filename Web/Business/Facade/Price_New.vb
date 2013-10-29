Imports Business
Imports DataAccess
Imports System.Data
Imports System.Data.Sql



Public Class Price_New
    Inherits CommonDB

    Private gsLocalCounty(100), gsLocalCountyState(100), gsLocalCountyDesc(100), gsStateOT(100), gsStateOTDesc(100), gsAirport(200), gsAirportDesc(200), gsngAirportParking(200) As String
    Private ServerIsMTC As Boolean

#Region "Public User Function"

    Public Function get_call_price(ByVal Conf_no As String, ByVal sngBasicRate As Single, ByVal fp_curTolls As Single, ByVal fp_curParking As Single, ByVal fp_curTel As Single, ByVal fp_curM_G As Single, ByVal fp_curPackage As Single, ByVal fp_curOT As Single, ByVal fp_curTips As Single, ByVal fp_curDiscount As Single, ByVal fp_curSTC As Single, ByVal fp_curStops As Single, ByVal fp_curWT As Single, ByVal fp_curServiceFee As Single, ByVal fp_curExpenses As Single, ByVal fp_curDeposit As Single, ByVal fp_intWTmin As Integer, ByVal fp_curDiscCert As Single, ByVal sPuAddError As String, ByVal sDestAddError As String, ByVal sError As String) As Single
        Dim iPuErrCode As Integer, iDestErrCode As Integer, iErrCode As Integer
        get_call_price = get_call_price_est(Conf_no, sngBasicRate, fp_curTolls, fp_curParking, fp_curTel, fp_curM_G, fp_curPackage, fp_curOT, fp_curTips, fp_curDiscount, fp_curSTC, fp_curStops, fp_curWT, fp_curServiceFee, fp_curExpenses, fp_curDeposit, fp_intWTmin, fp_curDiscCert, iPuErrCode, iDestErrCode, iErrCode)
        display_call_addr_err_message(iPuErrCode, iDestErrCode, iErrCode, sPuAddError, sDestAddError, sError)
    End Function

    Public Sub display_call_addr_err_message(ByVal iPuErr As Integer, ByVal iDestErr As Integer, ByVal iErr As Integer, ByVal sPuErrMsg As String, ByVal sDestErrMsg As String, ByVal sErrMsg As String)
        Select Case iPuErr
            Case -1
                sPuErrMsg = "Pu Address is not found"
            Case 5
                sPuErrMsg = "Pu zip code required"
            Case 2
                sPuErrMsg = "Pu Street No. is missing"
            Case 3
                sPuErrMsg = "Pu Street Name is missing"
            Case 4
                sPuErrMsg = "Pu City is missing"
            Case Else
                sPuErrMsg = ""
        End Select
        Select Case iDestErr
            Case -1
                sDestErrMsg = "Dest Address is not found"
            Case 5
                sDestErrMsg = "Dest zip code required"
            Case 2
                sDestErrMsg = "Dest Street No. is missing"
            Case 3
                sDestErrMsg = "Dest Street Name is missing"
            Case 4
                sDestErrMsg = "Dest City is missing"
            Case Else
                sDestErrMsg = ""
        End Select
        Select Case iErr
            Case 1
                sErrMsg = "Call not found in Operator table"
            Case 2
                sErrMsg = "For call with ""Price-by-hourly-rate"" No. of hours is missing"
            Case 3
                sErrMsg = "Call's account is missing in Account table"
            Case 4
                sErrMsg = "Call's company is missing in System_parameter table"
        End Select
    End Sub

    Public Function get_call_price_est(ByVal ConfNo As String, ByVal sngBasicRate As Single, ByVal fp_curTolls As Single, ByVal fp_curParking As Single, ByVal fp_curTel As Single, ByVal fp_curM_G As Single, ByVal fp_curPackage As Single, ByVal fp_curOT As Single, ByVal fp_curTips As Single, ByVal fp_curDiscount As Single, ByVal fp_curSTC As Single, ByVal fp_curStops As Single, ByVal fp_curWT As Single, ByVal fp_curServiceFee As Single, ByVal fp_curExpenses As Single, ByVal fp_curDeposit As Single, ByVal fp_intWTmin As Integer, ByVal fp_curDiscCert As Single, ByVal iPuErr As Integer, ByVal iDestErr As Integer, ByVal iErr As Integer) As Single
        'other field is not blank check  for zone   'check type of pricing ot,borough  'MsgBox "price estimate"
        Dim pu_type As Integer
        Dim dest_type As Integer
        Dim temp_price As String  '  Dim temp_price As Single
        Dim sngPrice As Single
        Dim boro As String
        Dim sngTips As Single
        'Dim sngSTC As Single
        Dim sngTolls As Single
        Dim sngParking As Single
        Dim sngStops As Single
        Dim sql_string As String
        Dim j As Integer

        Dim sPuAddr As String, sDestAddr As String
        Dim price_est As Single
        Dim sngHrRate_tmp As Single
        Dim sngBonus_tmp As Single
        Dim sngTipsPerc_tmp As Single
        Dim sngPricePerMile_tmp As Single
        '--modify by daniel for price
        'Dim rs As rdoResultset
        Dim SQLStr As String
        Dim rs As DataSet
        '----------------------------------
        Dim ss_cmbCompany As String
        Dim ss_cmbAccountNo As String
        Dim ss_cmbSubAccountNo As String
        Dim ss_cmbPuCounty As String
        Dim txtPuCountyTrue As String
        Dim ss_cmbPuCity As String
        Dim txtPuStNo As String
        Dim ss_cmbPuStName As String
        Dim sPuZip As String
        Dim ss_cmbDestCounty As String
        Dim txtDestCountyTrue As String
        Dim ss_cmbDestCity As String
        Dim txtDestStNo As String
        Dim ss_cmbDestStName As String
        Dim sDestZip As String
        Dim sngBonus_AcctCarType(20) As Single
        Dim sngTipsPerc_AcctCarType(20) As Single
        Dim sngPriceMile_AcctCarType(20) As Single
        Dim sngHrRate_AcctCarType(20) As Single
        Dim bAcctCarType As Boolean
        Dim ss_cmbCarType As String
        Dim ss_chkHrRate As Boolean
        Dim sngNoHours As Single
        Dim sPriceByMileage As String
        Dim iGraceReseyWT As Integer
        Dim sngPricePerMile As Single
        Dim sngMileage As Single
        Dim sngMinPriceByMileage As Single
        Dim sngMinBaseRate As Single
        Dim pricing_table As Integer
        Dim txtPuPriceZone As String
        Dim txtDestPriceZone As String
        Dim sngTipsPerc As Single
        Dim sNoTolls As String
        Dim sNoParking As String
        Dim sNoTips As String
        Dim sNoDiscount As String
        Dim sNoTollsCity As String
        Dim sNoParkingCity As String
        Dim sNoTipsCity As String
        Dim sNoDiscountCity As String
        Dim bAcctCityPricing As Boolean
        Dim bIsAirport(8) As Boolean
        Dim sStateAirport(8) As String
        Dim sCityAirline(8) As String
        Dim sStopCounty(8) As String
        Dim sngDiscountPerc As Single
        Dim iWTCharges(9) As Integer
        Dim sngWTChargePerHr As Single
        Dim sngSTCPerc As Single
        Dim sngAM_Holiday_Surcharge As Single
        Dim sFrom_AM_Holiday_Surcharge As String
        Dim sTo_AM_Holiday_Surcharge As String
        Dim sngAM_Holiday_Surcharge2 As Single
        Dim sFrom_AM_Holiday_Surcharge2 As String
        Dim sTo_AM_Holiday_Surcharge2 As String
        Dim sReqTime As String
        Dim sReqDate As String
        Dim bFoundInPriceTable As Boolean
        Dim iAirportWTCustomer As Integer
        Dim fp_sngDiscCertPerc As Single
        Dim sM_G As String
        Dim sngTipsPerc_Opr As Single

        'Screen.MousePointer = vbHourglass
        LoadGeography() ' uses global gsLocalCounty(100) as string, gsStateOT(100) as string, gsAirport(300) as string, gsngAirportParking(300) as string
        get_call_price_est = 0 : iPuErr = -2 : iDestErr = -2 : iErr = 0

        rs = Me.QueryData("SELECT * FROM Operator(NOLOCK) WHERE confirmation_no='" & ConfNo & "'", "Operator")

        'rs = cn.OpenResultset("SELECT * FROM Operator(NOLOCK) WHERE confirmation_no='" & ConfNo & "'", rdOpenForwardOnly, rdConcurReadOnly)
        If rs.Tables(0).Rows.Count > 0 Then
            iErr = 1 ' call not found
            rs.Dispose()
            rs = Nothing
            'Screen.MousePointer = vbDefault
            Exit Function
        End If
        ss_cmbCompany = CStr(Val("" & rs.Tables(0).Rows(0).Item("company").ToString))
        ss_cmbAccountNo = Trim("" & rs.Tables(0).Rows(0).Item("account_no").ToString)
        ss_cmbSubAccountNo = Trim("" & rs.Tables(0).Rows(0).Item("sub_account_no").ToString)
        ss_cmbPuCounty = Trim("" & rs.Tables(0).Rows(0).Item("pu_county").ToString)
        txtPuCountyTrue = Trim("" & rs.Tables(0).Rows(0).Item("pu_county_true").ToString)
        ss_cmbPuCity = Trim("" & rs.Tables(0).Rows(0).Item("pu_city").ToString)
        txtPuStNo = Trim("" & rs.Tables(0).Rows(0).Item("pu_st_no").ToString)
        ss_cmbPuStName = Trim("" & rs.Tables(0).Rows(0).Item("pu_st_name").ToString)
        sPuZip = Trim("" & rs.Tables(0).Rows(0).Item("pu_zip").ToString)
        txtPuPriceZone = Trim("" & rs.Tables(0).Rows(0).Item("pu_price_zone").ToString)
        ss_cmbDestCounty = Trim("" & rs.Tables(0).Rows(0).Item("dest_county").ToString)
        txtDestCountyTrue = Trim("" & rs.Tables(0).Rows(0).Item("dest_county_true").ToString)
        ss_cmbDestCity = Trim("" & rs.Tables(0).Rows(0).Item("dest_city").ToString)
        txtDestStNo = Trim("" & rs.Tables(0).Rows(0).Item("dest_st_no").ToString)
        ss_cmbDestStName = Trim("" & rs.Tables(0).Rows(0).Item("dest_st_name").ToString)
        sDestZip = Trim("" & rs.Tables(0).Rows(0).Item("dest_zip").ToString)
        txtDestPriceZone = Trim("" & rs.Tables(0).Rows(0).Item("dest_price_zone").ToString)
        ss_cmbCarType = Trim("" & rs.Tables(0).Rows(0).Item("car_type").ToString)
        If Trim("" & rs.Tables(0).Rows(0).Item("hr_rate").ToString) = "Y" Then ss_chkHrRate = True Else ss_chkHrRate = False
        sngNoHours = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("no_hours").ToString)
        fp_curTolls = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("tolls_charges").ToString)
        fp_curParking = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("parking_charges").ToString)
        fp_curTel = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("tel_charges").ToString)
        fp_curM_G = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("M_G_charges").ToString)
        sM_G = Trim("" & rs.Tables(0).Rows(0).Item("meet_greet").ToString)
        fp_curPackage = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("package_charges").ToString)
        fp_curOT = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("OT_charges").ToString)
        fp_curTips = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("tips_charges").ToString)
        fp_curDiscount = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("discount").ToString)
        fp_curDiscCert = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("discount_cert").ToString)
        fp_curSTC = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("STC_charges").ToString)
        fp_curStops = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("stops_charges").ToString)
        fp_curWT = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("WT_charges").ToString)
        sReqTime = Format(rs.Tables(0).Rows(0).Item("req_date_time"), "HH:MM")
        sReqDate = Format(rs.Tables(0).Rows(0).Item("req_date_time"), "MM/DD/YYYY")
        'fp_curServiceFee = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("service_fee"))
        fp_curExpenses = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("expenses").ToString)
        fp_curDeposit = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("deposit").ToString)
        fp_intWTmin = Convert.ToInt32("" & rs.Tables(0).Rows(0).Item("WT_minutes_add").ToString)
        fp_sngDiscCertPerc = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("discount_cert_perc").ToString)
        sngTipsPerc_Opr = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("tips_perc").ToString)
        rs.Dispose()
        rs = Nothing
        rs = Me.QueryData("SELECT * FROM Operator_Stops(NOLOCK) WHERE confirmation_no='" & ConfNo & "'", "Operator_Stops")
        If Not rs.Tables(0).Rows.Count > 0 Then
            bIsAirport(1) = Convert.ToBoolean(IIf(Convert.ToString("" & rs.Tables(0).Rows(0).Item("is_airport_2").ToString) = "Y", True, False))
            bIsAirport(2) = Convert.ToBoolean(IIf(Trim("" & rs.Tables(0).Rows(0).Item("is_airport_3").ToString) = "Y", True, False))
            bIsAirport(3) = Convert.ToBoolean(IIf(Trim("" & rs.Tables(0).Rows(0).Item("is_airport_4").ToString) = "Y", True, False))
            bIsAirport(4) = Convert.ToBoolean(IIf(Trim("" & rs.Tables(0).Rows(0).Item("is_airport_5").ToString) = "Y", True, False))
            bIsAirport(5) = Convert.ToBoolean(IIf(Trim("" & rs.Tables(0).Rows(0).Item("is_airport_6").ToString) = "Y", True, False))
            bIsAirport(6) = Convert.ToBoolean(IIf(Trim("" & rs.Tables(0).Rows(0).Item("is_airport_7").ToString) = "Y", True, False))
            bIsAirport(7) = Convert.ToBoolean(IIf(Trim("" & rs.Tables(0).Rows(0).Item("is_airport_8").ToString) = "Y", True, False))
            bIsAirport(8) = Convert.ToBoolean(IIf(Trim("" & rs.Tables(0).Rows(0).Item("is_airport_9").ToString) = "Y", True, False))
            sStateAirport(1) = Trim("" & rs.Tables(0).Rows(0).Item("state_airport_2").ToString)
            sStateAirport(2) = Trim("" & rs.Tables(0).Rows(0).Item("state_airport_3").ToString)
            sStateAirport(3) = Trim("" & rs.Tables(0).Rows(0).Item("state_airport_4").ToString)
            sStateAirport(4) = Trim("" & rs.Tables(0).Rows(0).Item("state_airport_5").ToString)
            sStateAirport(5) = Trim("" & rs.Tables(0).Rows(0).Item("state_airport_6").ToString)
            sStateAirport(6) = Trim("" & rs.Tables(0).Rows(0).Item("state_airport_7").ToString)
            sStateAirport(7) = Trim("" & rs.Tables(0).Rows(0).Item("state_airport_8").ToString)
            sStateAirport(8) = Trim("" & rs.Tables(0).Rows(0).Item("state_airport_9").ToString)
            sCityAirline(1) = Trim("" & rs.Tables(0).Rows(0).Item("city_airline_2").ToString)
            sCityAirline(2) = Trim("" & rs.Tables(0).Rows(0).Item("city_airline_3").ToString)
            sCityAirline(3) = Trim("" & rs.Tables(0).Rows(0).Item("city_airline_4").ToString)
            sCityAirline(4) = Trim("" & rs.Tables(0).Rows(0).Item("city_airline_5").ToString)
            sCityAirline(5) = Trim("" & rs.Tables(0).Rows(0).Item("city_airline_6").ToString)
            sCityAirline(6) = Trim("" & rs.Tables(0).Rows(0).Item("city_airline_7").ToString)
            sCityAirline(7) = Trim("" & rs.Tables(0).Rows(0).Item("city_airline_8").ToString)
            sCityAirline(8) = Trim("" & rs.Tables(0).Rows(0).Item("city_airline_9").ToString)
            iWTCharges(0) = Convert.ToInt32("" & rs.Tables(0).Rows(0).Item("wt_1").ToString)
            iWTCharges(1) = Convert.ToInt32("" & rs.Tables(0).Rows(0).Item("wt_2").ToString)
            iWTCharges(2) = Convert.ToInt32("" & rs.Tables(0).Rows(0).Item("wt_3").ToString)
            iWTCharges(3) = Convert.ToInt32("" & rs.Tables(0).Rows(0).Item("wt_4").ToString)
            iWTCharges(4) = Convert.ToInt32("" & rs.Tables(0).Rows(0).Item("wt_5").ToString)
            iWTCharges(5) = Convert.ToInt32("" & rs.Tables(0).Rows(0).Item("wt_6").ToString)
            iWTCharges(6) = Convert.ToInt32("" & rs.Tables(0).Rows(0).Item("wt_7").ToString)
            iWTCharges(7) = Convert.ToInt32("" & rs.Tables(0).Rows(0).Item("wt_8").ToString)
            iWTCharges(8) = Convert.ToInt32("" & rs.Tables(0).Rows(0).Item("wt_9").ToString)
            iWTCharges(9) = Convert.ToInt32("" & rs.Tables(0).Rows(0).Item("wt_10").ToString)
            sStopCounty(1) = Trim("" & rs.Tables(0).Rows(0).Item("county_2").ToString)
            sStopCounty(2) = Trim("" & rs.Tables(0).Rows(0).Item("county_3").ToString)
            sStopCounty(3) = Trim("" & rs.Tables(0).Rows(0).Item("county_4").ToString)
            sStopCounty(4) = Trim("" & rs.Tables(0).Rows(0).Item("county_5").ToString)
            sStopCounty(5) = Trim("" & rs.Tables(0).Rows(0).Item("county_6").ToString)
            sStopCounty(6) = Trim("" & rs.Tables(0).Rows(0).Item("county_7").ToString)
            sStopCounty(7) = Trim("" & rs.Tables(0).Rows(0).Item("county_8").ToString)
            sStopCounty(8) = Trim("" & rs.Tables(0).Rows(0).Item("county_9").ToString)
        End If
        rs.Dispose()
        rs = Nothing
        rs = Me.QueryData("SELECT Min_Price_By_Mileage, Min_Base_Rate FROM System_parameter(NOLOCK) WHERE company=" & ss_cmbCompany & "", "System_parameter")
        'rs = cn.OpenResultset("SELECT Min_Price_By_Mileage, Min_Base_Rate FROM System_parameter(NOLOCK) WHERE company=" & ss_cmbCompany, rdOpenForwardOnly, rdConcurReadOnly)
        If rs.Tables(0).Rows.Count <= 0 Then
            iErr = 4
            rs.Dispose()
            rs = Nothing
            'Screen.MousePointer = vbDefault
            Exit Function
        Else
            sngMinPriceByMileage = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("Min_Price_By_Mileage").ToString)
            sngMinBaseRate = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("Min_Base_Rate").ToString)
        End If
        rs.Dispose()
        rs = Nothing
        rs = Me.QueryData("SELECT * FROM Car_type(NOLOCK) WHERE car_type_id=" & ss_cmbCarType, "car_type")

        'rs = cn.OpenResultset("SELECT * FROM Car_type(NOLOCK) WHERE car_type_id=" & ss_cmbCarType, rdOpenForwardOnly, rdConcurReadOnly)
        If rs.Tables(0).Rows.Count > 0 Then
            sngHrRate_tmp = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("hr_rate").ToString)
            sngBonus_tmp = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("bonus").ToString)
            sngTipsPerc_tmp = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("tips_perc").ToString)
            sngPricePerMile_tmp = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("price_per_mile").ToString)
        End If
        rs.Dispose()
        rs = Nothing
        rs = Me.QueryData("SELECT * from Account(NOLOCK) WHERE company=" & ss_cmbCompany & " AND acct_id='" & ss_cmbAccountNo & "' AND sub_acct_id='" & ss_cmbSubAccountNo & "'", "Account")
        'rs.Tables(0).Rows(0).Item = cn.OpenResultset("SELECT * from Account(NOLOCK) WHERE company=" & ss_cmbCompany & " AND acct_id='" & ss_cmbAccountNo & "' AND sub_acct_id='" & ss_cmbSubAccountNo & "'", rdOpenForwardOnly, rdConcurReadOnly)
        If rs.Tables(0).Rows.Count <= 0 Then
            iErr = 3
            rs.Dispose()
            'Screen.MousePointer = vbDefault
            Exit Function
        Else
            sPriceByMileage = Trim("" & rs.Tables(0).Rows(0).Item("price_by_mileage_flag").ToString)
            sngPricePerMile = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("price_per_mile").ToString)
            pricing_table = Convert.ToInt32("" & rs.Tables(0).Rows(0).Item("table_id").ToString)
            sngDiscountPerc = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("discount_perc").ToString)
            sNoTolls = Trim("" & rs.Tables(0).Rows(0).Item("no_tolls").ToString)
            sNoParking = Trim("" & rs.Tables(0).Rows(0).Item("no_parking").ToString)
            sNoTips = Trim("" & rs.Tables(0).Rows(0).Item("no_tips").ToString)
            sNoDiscount = Trim("" & rs.Tables(0).Rows(0).Item("no_discount").ToString)
            'sngWTChargePerHr = Val("" & rs.Tables(0).Rows(0).Item("WT_Charge_Per_Hr"))
            sngTipsPerc = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("tip_perc").ToString)
            sngSTCPerc = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("STC_perc").ToString)
            iGraceReseyWT = Convert.ToInt32("" & rs.Tables(0).Rows(0).Item("grace_resey_WT").ToString)
            fp_curServiceFee = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("service_fee_A").ToString)
            sngAM_Holiday_Surcharge = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("AM_Holiday_Surcharge").ToString)
            sFrom_AM_Holiday_Surcharge = Trim("" & rs.Tables(0).Rows(0).Item("From_AM_Holiday_Surcharge").ToString)
            sTo_AM_Holiday_Surcharge = Trim("" & rs.Tables(0).Rows(0).Item("To_AM_Holiday_Surcharge").ToString)
            sngAM_Holiday_Surcharge2 = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("AM_Holiday_Surcharge_2").ToString)
            sFrom_AM_Holiday_Surcharge2 = Trim("" & rs.Tables(0).Rows(0).Item("From_AM_Holiday_Surcharge_2").ToString)
            sTo_AM_Holiday_Surcharge2 = Trim("" & rs.Tables(0).Rows(0).Item("To_AM_Holiday_Surcharge_2").ToString)
            iAirportWTCustomer = Convert.ToInt32("" & rs.Tables(0).Rows(0).Item("airport_WT_cus").ToString)
        End If
        bAcctCarType = get_call_account_car_type(ss_cmbCompany, ss_cmbAccountNo, ss_cmbSubAccountNo, sngBonus_AcctCarType, sngTipsPerc_AcctCarType, sngPriceMile_AcctCarType, sngHrRate_AcctCarType, 20)
        bAcctCityPricing = get_call_account_city_pricing(ss_cmbCompany, ss_cmbAccountNo, ss_cmbSubAccountNo, ss_cmbPuCounty, txtPuCountyTrue, ss_cmbPuCity, ss_cmbDestCounty, txtDestCountyTrue, ss_cmbDestCity, sNoTollsCity, sNoParkingCity, sNoTipsCity, sNoDiscountCity)
        '''''''''''''''''''''''''''''If bAcctCityPricing Then
        '''''''''''''''''''''''''''''  If sNoTolls = "t" And (sNoTollsCity = "f" Or sNoTollsCity = "") Then sNoTolls = "f" Else sNoTolls = "t"
        '''''''''''''''''''''''''''''  If sNoParking = "t" And (sNoParkingCity = "f" Or sNoParkingCity = "") Then sNoParking = "f" Else sNoParking = "t"
        '''''''''''''''''''''''''''''  If sNoTips = "t" And (sNoTipsCity = "f" Or sNoTipsCity = "") Then sNoTips = "f" Else sNoTips = "t"
        '''''''''''''''''''''''''''''  If sNoDiscount = "t" And (sNoDiscountCity = "f" Or sNoDiscountCity = "") Then sNoDiscount = "f" Else sNoDiscount = "t"
        '''''''''''''''''''''''''''''End If
        ' if not in Account table then to get Price/Mile from Car_type table
        If sngPricePerMile = 0 Then sngPricePerMile = sngPricePerMile_tmp
        If bAcctCarType Then
            If sngPriceMile_AcctCarType(Convert.ToInt32(ss_cmbCarType)) > 0 Then sngPricePerMile = sngPriceMile_AcctCarType(Convert.ToInt32(ss_cmbCarType))
            If sngTipsPerc_AcctCarType(Convert.ToInt32(ss_cmbCarType)) > 0 Then sngTipsPerc = sngTipsPerc_AcctCarType(Convert.ToInt32(ss_cmbCarType))
            If sngHrRate_AcctCarType(Convert.ToInt32(ss_cmbCarType)) > 0 Then sngHrRate_tmp = sngHrRate_AcctCarType(Convert.ToInt32(ss_cmbCarType))
            If sngBonus_AcctCarType(Convert.ToInt32(ss_cmbCarType)) > 0 Then sngBonus_tmp = sngBonus_AcctCarType(Convert.ToInt32(ss_cmbCarType))
        End If
        If ss_chkHrRate Then
            If sngNoHours = 0 Then
                iErr = 2
                'Screen.MousePointer = vbDefault
                Exit Function
            Else
                price_est = sngNoHours * sngHrRate_tmp
                price_est = Convert.ToSingle(price_est * 100) / 100
            End If
        ElseIf sPriceByMileage = "t" And sngPricePerMile > 0 And Not IsAirport(ss_cmbPuCounty) And Not IsAirport(ss_cmbDestCounty) Then
            sPuAddr = get_call_addr_string(ss_cmbPuCounty, ss_cmbPuCity, txtPuStNo, ss_cmbPuStName, sPuZip, iPuErr)
            sDestAddr = get_call_addr_string(ss_cmbDestCounty, ss_cmbDestCity, txtDestStNo, ss_cmbDestStName, sDestZip, iDestErr)
            'If ServerIsConcord Then iPuErr = 100 : iDestErr = 100
            If iPuErr <= 1 And iDestErr <= 1 Then
                sngMileage = 0
                sngMileage = get_mileage(sPuAddr, sDestAddr, iPuErr, iDestErr)
            End If
            ' iPuErr = -2 means PuAddr is absent
            ' iPuErr = -1 means PuAddr not found
            ' iPuErr = 5 means ZIP is required
            ' iPuErr = 0 means PuAddr found
            price_est = Convert.ToSingle(IIf(sngMileage > 0, sngMileage * sngPricePerMile, 0))
            If price_est > 0 And price_est < sngMinPriceByMileage Then price_est = sngMinPriceByMileage
            If price_est > 0 Then price_est = Convert.ToSingle((price_est + sngBonus_tmp) * 100) / 100
        Else ' if gsPriceByMileage <> "t" then calculate price in a standard way
            temp_price = "0.00"       'clear price

            j = update_price_book_by_account(ss_cmbCarType, ss_cmbCompany, ss_cmbAccountNo, ss_cmbSubAccountNo, pricing_table)
            If j > 0 Then
                pricing_table = j
                temp_price = get_call_city_to_city_pricing(pricing_table, ss_cmbPuCounty, txtPuCountyTrue, ss_cmbPuCity, ss_cmbDestCounty, txtDestCountyTrue, ss_cmbDestCity, ss_cmbCompany, ss_cmbAccountNo, ss_cmbSubAccountNo, txtPuPriceZone, txtDestPriceZone, bFoundInPriceTable, fp_curTolls)
            Else
                temp_price = "0.00"
            End If


            If IsNumeric(temp_price) And Val(temp_price) > 0 Then
                price_est = Convert.ToSingle((Val(temp_price) + sngBonus_tmp) * 100) / 100
            Else
                price_est = 0
            End If
            If price_est = 0 And sngPricePerMile > 0 Then
                sPuAddr = get_call_addr_string(ss_cmbPuCounty, ss_cmbPuCity, txtPuStNo, ss_cmbPuStName, sPuZip, iPuErr)
                sDestAddr = get_call_addr_string(ss_cmbDestCounty, ss_cmbDestCity, txtDestStNo, ss_cmbDestStName, sDestZip, iDestErr)
                'If ServerIsConcord Then iPuErr = 100 : iDestErr = 100
                If iPuErr <= 1 And iDestErr <= 1 Then
                    sngMileage = 0
                    sngMileage = get_mileage(sPuAddr, sDestAddr, iPuErr, iDestErr)
                End If
                ' iPuErr = -2 means PuAddr is absent
                ' iPuErr = -1 means PuAddr not found
                ' iPuErr = 5 means ZIP is required
                ' iPuErr = 0 means PuAddr found
                price_est = Convert.ToSingle(IIf(sngMileage > 0, sngMileage * sngPricePerMile, 0))
                If price_est > 0 And price_est < sngMinPriceByMileage Then price_est = sngMinPriceByMileage
                If price_est > 0 Then price_est = Convert.ToSingle((price_est + sngBonus_tmp) * 100) / 100
            End If
        End If
        If price_est > 0 And price_est < sngMinBaseRate Then price_est = sngMinBaseRate
        sngBasicRate = price_est
        If sngBasicRate > 0 Then
            fp_curTolls = get_call_est_tolls(fp_curTolls, bFoundInPriceTable, ss_cmbPuCounty, ss_cmbPuCity, ss_cmbDestCounty, ss_cmbDestCity, sNoTolls)
            fp_curParking = get_call_est_parking(ss_cmbPuCounty, sNoParking)
            fp_curStops = get_call_est_stops(ss_chkHrRate, ss_cmbPuCounty, txtPuCountyTrue, ss_cmbPuCity, ss_cmbDestCounty, txtDestCountyTrue, ss_cmbDestCity, sStateAirport, sStopCounty, sCityAirline, bIsAirport, ss_cmbCarType)
            fp_curWT = get_call_est_WT_charges(ss_cmbCompany, iAirportWTCustomer, ss_cmbPuCounty, ss_chkHrRate, iWTCharges, sngHrRate_tmp, iGraceReseyWT, fp_intWTmin)
            fp_curOT = get_call_est_OT_charges(ss_cmbCompany, ss_cmbAccountNo, ss_cmbSubAccountNo, sngAM_Holiday_Surcharge, sFrom_AM_Holiday_Surcharge, sTo_AM_Holiday_Surcharge, sngAM_Holiday_Surcharge2, sFrom_AM_Holiday_Surcharge2, sTo_AM_Holiday_Surcharge2, sReqTime, sReqDate)
            fp_curTips = get_call_est_tips(sngBasicRate, fp_curStops, fp_curWT, fp_curOT, sngTipsPerc, sngTipsPerc_tmp, sngTipsPerc_Opr, sNoTips, fp_curPackage)
            fp_curSTC = get_call_est_STC(sngBasicRate, fp_curStops, fp_curWT, fp_curOT, sngSTCPerc, fp_curPackage)
            fp_curDiscount = get_call_est_discount(sngBasicRate, fp_curStops, fp_curWT, fp_curOT, sngDiscountPerc, sNoDiscount)
            'fp_curDiscCert = CLng(fp_sngDiscCertPerc * sngBasicRate) / 100
            If sM_G <> "Y" Then fp_curM_G = 0
            If ss_chkHrRate Then
                price_est = Convert.ToSingle((sngBasicRate + fp_curTolls + fp_curParking + fp_curTel + fp_curM_G + fp_curPackage + fp_curOT + fp_curTips - fp_curDiscount - fp_curDiscCert + fp_curSTC + fp_curServiceFee + fp_curExpenses - fp_curDeposit) * 100) / 100
            Else
                price_est = Convert.ToSingle((sngBasicRate + fp_curTolls + fp_curParking + fp_curStops + fp_curWT + fp_curTel + fp_curM_G + fp_curPackage + fp_curOT + fp_curTips - fp_curDiscount - fp_curDiscCert + fp_curSTC + fp_curServiceFee + fp_curExpenses - fp_curDeposit) * 100) / 100
            End If
        Else
            get_call_price_est = 0
        End If
        get_call_price_est = price_est
        'Screen.MousePointer = vbDefault
    End Function

    '------------------------------------------------------------------------------
    '-- Debugging function -- 3/20/03
    '------------------------------------------------------------------------------
    'Public Sub show_var(ByVal desc As String, ByVal variable As String, ByVal bolend As Boolean)
    '    Response.Write(desc & ":" & variable & "<br>")
    '    If bolend = True Then
    '        Response.End()
    '    End If
    'End Sub
    '------------------------------------------------------------------------------
    '-- Sub LoadGeography()
    '------------------------------------------------------------------------------
    Public Sub LoadGeography()
        Dim i As Integer
        Dim SQLStr As String
        Dim dr As DataSet
        SQLStr = "Select * from County_State_Town(nolock) order by type_pos,code_pos"
        dr = Me.QueryData(SQLStr, "County_State_Town")
        i = 0
        If dr.Tables(0).Rows.Count > 0 Then
            Do While i <= dr.Tables(0).Rows.Count
                gsLocalCounty(i) = Trim("" & Convert.ToString(dr.Tables(0).Rows(0).Item("code")))
                gsLocalCountyDesc(i) = Trim("" & Convert.ToString(dr.Tables(0).Rows(0).Item("description")))
                gsLocalCountyState(i) = Trim("" & Convert.ToString(dr.Tables(0).Rows(0).Item("type")))

                i = i + 1
            Loop
        End If
        dr.Dispose()
        dr = Nothing
        SQLStr = "Select * from County_State_OT(nolock) order by type_pos,code_pos"
        dr = Me.QueryData(SQLStr, "County_State_OT")
        i = 0
        If dr.Tables(0).Rows.Count > 0 Then
            Do While i <= dr.Tables(0).Rows.Count
                gsStateOT(i) = Trim("" & Convert.ToString(dr.Tables(0).Rows(0).Item("code")))
                gsStateOTDesc(i) = Trim("" & Convert.ToString(dr.Tables(0).Rows(0).Item("description")))
                'dr.MoveNext()
                i = i + 1
            Loop
        End If
        dr.Dispose()
        dr = Nothing
        SQLStr = "Select * from County_State_Airport order by type_pos,code_pos,code"
        dr = Me.QueryData(SQLStr, "County_State_Airport")
        i = 0

        If dr.Tables(0).Rows.Count > 0 Then
            Do While i <= dr.Tables(0).Rows.Count
                gsAirport(i) = Trim("" & Convert.ToString(dr.Tables(0).Rows(0).Item("code")))
                gsAirportDesc(i) = Trim("" & Convert.ToString(dr.Tables(0).Rows(0).Item("description")))
                gsngAirportParking(i) = Trim("" & Convert.ToString(dr.Tables(0).Rows(0).Item("parking_charge")))
                'dr.MoveNext()
                i = i + 1
            Loop
        End If
        dr.Dispose()
        dr = Nothing
    End Sub

    '------------------------------------------------------------------------------
    '-- function get_call_account_car_type -- 3/20/03
    '------------------------------------------------------------------------------
    Public Function get_call_account_car_type(ByVal sComp As String, ByVal sAcctNo As String, ByVal sSubAcctNo As String, ByVal sngBonus_AcctCarType() As Single, ByVal sngTipsPerc_AcctCarType() As Single, ByVal sngPriceMile_AcctCarType() As Single, ByVal sngHrRate_AcctCarType() As Single, ByVal iSize As Integer) As Boolean
        Dim sSQL As String
        Dim i As Integer
        Dim rs As DataSet
        Dim bAcctCarType As Boolean
        'Screen.MousePointer = vbHourglass
        For i = 0 To iSize
            sngBonus_AcctCarType(i) = 0
            sngTipsPerc_AcctCarType(i) = 0
            sngPriceMile_AcctCarType(i) = 0
            sngHrRate_AcctCarType(i) = 0
        Next i
        bAcctCarType = False
        sSQL = "SELECT * FROM Account_Car_Type(NOLOCK) WHERE company=" & sComp & " and acct_id='" & sAcctNo & "' and sub_acct_id='" & sSubAcctNo & "' order by car_type_id"
        rs = Me.QueryData(sSQL, "Account_Car_Type")
        'rs = cn.OpenResultset(sSQL, rdOpenForwardOnly, rdConcurReadOnly)
        Dim j As Integer
        j = 0
        Do While Not j >= rs.Tables(0).Rows.Count
            bAcctCarType = True
            sngBonus_AcctCarType(Convert.ToInt32(rs.Tables(0).Rows(0).Item("car_type_id"))) = Convert.ToSingle(IIf(IsNull(rs.Tables(0).Rows(0).Item("bonus").ToString), 0, rs.Tables(0).Rows(0).Item("bonus")))
            sngTipsPerc_AcctCarType(Convert.ToInt32(rs.Tables(0).Rows(0).Item("car_type_id"))) = Convert.ToSingle(IIf(IsNull(rs.Tables(0).Rows(0).Item("tips_perc").ToString), 0, rs.Tables(0).Rows(0).Item("tips_perc")))
            sngPriceMile_AcctCarType(Convert.ToInt32(rs.Tables(0).Rows(0).Item("car_type_id"))) = Convert.ToSingle(IIf(IsNull(rs.Tables(0).Rows(0).Item("price_per_mile").ToString), 0, rs.Tables(0).Rows(0).Item("price_per_mile")))
            sngHrRate_AcctCarType(Convert.ToInt32(rs.Tables(0).Rows(0).Item("car_type_id"))) = Convert.ToSingle(IIf(IsNull(rs.Tables(0).Rows(0).Item("hr_rate").ToString), 0, rs.Tables(0).Rows(0).Item("hr_rate")))
            'rs.MoveNext()
            j = j + 1
        Loop
        rs.Dispose()
        rs = Nothing
        get_call_account_car_type = bAcctCarType
        'Screen.MousePointer = vbDefault
    End Function

    '------------------------------------------------------------------------------
    '-- function get_call_account_city_pricing -- 4/25/06
    '------------------------------------------------------------------------------
    Public Function get_call_account_city_pricing(ByVal sComp As String, ByVal sAcctNo As String, ByVal sSubAcctNo As String, ByVal sPuState As String, ByVal sPuCounty As String, ByVal sPuCity As String, ByVal sDestState As String, ByVal sDestCounty As String, ByVal sDestCity As String, ByVal sNoTolls As String, ByVal sNoParking As String, ByVal sNoTips As String, ByVal sNoDiscount As String) As Boolean
        Dim rs As DataSet
        Dim sSQL As String
        Dim ssPuState As String, ssPuCity As String, ssDestState As String, ssDestCity As String
        Dim ssCity As String, ssState As String
        Dim sNoTollsCity As String
        Dim sNoParkingCity As String
        Dim sNoTipsCity As String
        Dim sNoDiscountCity As String

        sNoTollsCity = "-"
        sNoParkingCity = "-"
        sNoTipsCity = "-"
        sNoDiscountCity = "-"
        If get_city_by_boro(sPuState, ssCity, ssState) Then
            ssPuState = ssState
            ssPuCity = ssCity
        Else
            ssPuState = sPuState
            ssPuCity = sPuCity
        End If
        If get_city_by_boro(sDestState, ssCity, ssState) Then
            ssDestState = ssState
            ssDestCity = ssCity
        Else
            ssDestState = sDestState
            ssDestCity = sDestCity
        End If
        'If Not IsAirport_SearchInTable(sPuState) And ss_chkDestIsAirport.Value Then
        '  sSQL = "SELECT no_tolls,no_parking,no_tips,no_discount FROM Account_City_Pricing(NOLOCK) "
        '  sSQL = sSQL & "WHERE company=" & strCompany & " and acct_id='" & ss_cmbAccountNo & "' and sub_acct_id='" & ss_cmbSubAccountNo & "'"
        '  sSQL = sSQL & " and state='" & sPuState & "' and county='" & txtPuCountyTrue & "' and city='" & sPuCity & "'"
        'ElseIf ss_chkPuIsAirport.Value And Not ss_chkDestIsAirport.Value Then
        '  sSQL = "SELECT no_tolls,no_parking,no_tips,no_discount FROM Account_City_Pricing(NOLOCK) "
        '  sSQL = sSQL & "WHERE company=" & strCompany & " and acct_id='" & ss_cmbAccountNo & "' and sub_acct_id='" & ss_cmbSubAccountNo & "'"
        '  sSQL = sSQL & " and state='" & sDestState & "' and county='" & txtDestCountyTrue & "' and city='" & sDestCity & "'"
        'ElseIf Not ss_chkPuIsAirport.Value And Not ss_chkDestIsAirport.Value Then
        sSQL = "SELECT no_tolls,no_parking,no_tips,no_discount FROM Account_City_Pricing(NOLOCK) "
        sSQL = sSQL & "WHERE company=" & sComp & " and acct_id='" & sAcctNo & "' and sub_acct_id='" & sSubAcctNo & "'"
        sSQL = sSQL & " and (state='" & sDestState & "' and county='" & sDestCounty & "' and city='" & sDestCity & "'"
        sSQL = sSQL & " OR state='" & sPuState & "' and county='" & sPuCounty & "' and city='" & sPuCity & "')"
        'Else
        '  Exit Function
        'End If
        rs = Me.QueryData(sSQL, "Account_City_Pricing")
        If rs.Tables("Account_City_Pricing").Rows.Count > 0 Then
            If sNoTollsCity <> "t" Then sNoTollsCity = Trim("" & Convert.ToString(rs.Tables(0).Rows(0).Item("No_tolls")))
            If sNoParkingCity <> "t" Then sNoParkingCity = Trim("" & Convert.ToString(rs.Tables(0).Rows(0).Item("No_parking")))
            If sNoTipsCity <> "t" Then sNoTipsCity = Trim("" & Convert.ToString(rs.Tables(0).Rows(0).Item("No_tips")))
            If sNoDiscountCity <> "t" Then sNoDiscountCity = Trim("" & Convert.ToString(rs.Tables(0).Rows(0).Item("No_discount")))
            'rs.MoveNext()
        End If
        rs.Dispose()
        rs = Nothing

        If sNoTollsCity = "-" Then ' not found in Account_City_Pricing
            If sNoTolls = "t" Then sNoTolls = "t" Else sNoTolls = "f"
        ElseIf sNoTollsCity = "t" Then
            sNoTolls = "t"
        Else ' sNoTollsCity = "f" Or sNoTollsCity = ""
            sNoTolls = "f"
        End If
        If sNoParkingCity = "-" Then ' not found in Account_City_Pricing
            If sNoParking = "t" Then sNoParking = "t" Else sNoParking = "f"
        ElseIf sNoParkingCity = "t" Then
            sNoParking = "t"
        Else ' sNoParkingCity = "f" Or sNoParkingCity = ""
            sNoParking = "f"
        End If
        If sNoTipsCity = "-" Then ' not found in Account_City_Pricing
            If sNoTips = "t" Then sNoTips = "t" Else sNoTips = "f"
        ElseIf sNoTipsCity = "t" Then
            sNoTips = "t"
        Else ' sNoTipsCity = "f" Or sNoTipsCity = ""
            sNoTips = "f"
        End If
        If sNoDiscountCity = "-" Then ' not found in Account_City_Pricing
            If sNoDiscount = "t" Then sNoDiscount = "t" Else sNoDiscount = "f"
        ElseIf sNoDiscountCity = "t" Then
            sNoDiscount = "t"
        Else ' sNoDiscountCity = "f" Or sNoDiscountCity = ""
            sNoDiscount = "f"
        End If

    End Function

    'Public Function get_city_by_boro(ByVal sBorough As String, ByVal sCity As String, ByVal sState As String) As Boolean
    '    get_city_by_boro = False
    '    Select Case sBorough
    '        Case "M"
    '            sCity = "Manhattan"
    '            sState = "NY"
    '            get_city_by_boro = True
    '        Case "BK"
    '            sCity = "Brooklyn"
    '            sState = "NY"
    '            get_city_by_boro = True
    '        Case "QU"
    '            sCity = "Queens"
    '            sState = "NY"
    '            get_city_by_boro = True
    '        Case "BX"
    '            sCity = "Bronx"
    '            sState = "NY"
    '            get_city_by_boro = True
    '        Case "SI"
    '            sCity = "Staten Island"
    '            sState = "NY"
    '            get_city_by_boro = True
    '    End Select
    'End Function

    Public Function IsAirport(ByVal boro As String, Optional ByVal vInd As Integer = 0) As Boolean
        Dim i As Integer
        i = 0
        IsAirport = False
        Do While gsAirport(i) <> ""
            If gsAirport(i) = Trim(boro) Then
                IsAirport = True
                vInd = i
                Exit Do
            End If
            i = i + 1
        Loop
        'Select Case Trim(boro)
        'Case "JFK", "LGA", "EWR", "TTB", "WEA", "MCA", "NBG", "BDL", "MCC", "RNO", "EXE", "SIG", "NLV", "HEA"
        '  IsAirport = True
        'Case Else
        '  IsAirport = False
        'End Select
    End Function

    Public Function get_call_addr_string(ByVal sCounty As String, ByVal sCity As String, ByVal sStNo As String, ByVal sStName As String, ByVal sZip As String, ByVal iErrCode As Integer) As String
        Dim ssCity As String, ssState As String
        get_call_addr_string = "" : iErrCode = 0
        If IsAirport(sCounty) Then
            get_call_addr_string = Trim(sCounty) ' airport code
        Else
            If Trim(sStNo) <> "" Then
                get_call_addr_string = get_call_addr_string & Trim(sStNo)
                If Trim(sStName) <> "" Then
                    get_call_addr_string = get_call_addr_string & " " & Trim(sStName)
                    If Trim(sCity) <> "" Then
                        Select Case UCase(Trim(sCity))
                            Case "MANHATTAN1", "MANHATTAN1 (BELOW 25TH ST)"
                                ssCity = "MANHATTAN"
                            Case Else
                                ssCity = sCity
                        End Select
                        get_call_addr_string = get_call_addr_string & "," & Trim(ssCity)
                        get_call_addr_string = get_call_addr_string & "," & get_state_by_boro(Trim(sCounty))
                        If sZip <> "" Then
                            get_call_addr_string = get_call_addr_string & " " & sZip
                        Else
                            iErrCode = 1 ' no zip
                        End If
                        get_call_addr_string = get_call_addr_string & " United States"
                    ElseIf get_city_by_boro(sCounty, ssCity, ssState) Then
                        get_call_addr_string = get_call_addr_string & "," & ssCity
                        get_call_addr_string = get_call_addr_string & "," & ssState
                        If sZip <> "" Then
                            get_call_addr_string = get_call_addr_string & " " & sZip
                        Else
                            iErrCode = 1 ' no zip
                        End If
                        get_call_addr_string = get_call_addr_string & " United States"
                    Else
                        get_call_addr_string = ""
                        iErrCode = 4 ' no city
                    End If
                Else
                    get_call_addr_string = ""
                    iErrCode = 3 ' no street name
                End If
            Else
                get_call_addr_string = ""
                If sCity = "" And sStName = "" Then
                    iErrCode = -2 ' no street address
                Else
                    iErrCode = 2 ' no street no.
                End If
            End If
        End If
    End Function

    Public Function get_state_by_boro(ByVal sBorough As String) As String
        get_state_by_boro = sBorough
        Select Case sBorough
            Case "LI", "WE", "M", "BK", "BX", "QU", "SI"
                get_state_by_boro = "NY"
        End Select
    End Function

    Public Function get_city_by_boro(ByVal sBorough As String, ByVal sCity As String, ByVal sState As String) As Boolean
        get_city_by_boro = False
        Select Case sBorough
            Case "M"
                sCity = "Manhattan"
                sState = "NY"
                get_city_by_boro = True
            Case "BK"
                sCity = "Brooklyn"
                sState = "NY"
                get_city_by_boro = True
            Case "QU"
                sCity = "Queens"
                sState = "NY"
                get_city_by_boro = True
            Case "BX"
                sCity = "Bronx"
                sState = "NY"
                get_city_by_boro = True
            Case "SI"
                sCity = "Staten Island"
                sState = "NY"
                get_city_by_boro = True
        End Select
    End Function

    Public Function get_mileage(ByVal sAddr1 As String, ByVal sAddr2 As String, ByVal iErr1 As Integer, ByVal iErr2 As Integer) As Single
        'Dim objLoc(0 To 2) As MapPoint.Location
        'Dim m_Map As MapPoint.Application
        ''Screen.MousePointer = vbHourglass
        'get_mileage = 0
        'Dim objMapPointMap As MapPoint.Map
        'Dim objMapPointRoute As MapPoint.Route

        'If iErr1 <= 1 And iErr2 <= 1 Then

        '    objLoc(1) = objMapPointMap.Find(sAddr1)
        '    If objLoc(1) Is Nothing Then
        '        If iErr1 = 0 Then iErr1 = -1 Else If iErr1 = 1 Then iErr1 = 5
        '    Else
        '        iErr1 = 0
        '    End If
        '    objLoc(2) = objMapPointMap.Find(sAddr2)
        '    If objLoc(2) Is Nothing Then
        '        If iErr2 = 0 Then iErr2 = -1 Else If iErr2 = 1 Then iErr2 = 5
        '    Else
        '        iErr2 = 0
        '    End If
        If iErr1 = 0 And iErr2 = 0 Then
            'objMapPointRoute.Waypoints.Add(objLoc(1))
            'objMapPointRoute.Waypoints.Add(objLoc(2))
            'objMapPointRoute.Calculate()
            'get_mileage = Convert.ToSingle(objMapPointRoute.Distance)
            'objMapPointRoute.Clear()
        End If
        'End If
        'Screen.MousePointer = vbDefault
    End Function
    'Public Function get_mileage(ByVal sAddr1 As String, ByVal sAddr2 As String, ByVal iErr1 As Integer, ByVal iErr2 As Integer) As Single
    '    Dim objMapPointComp As Object, strMileage As Integer

    '    objMapPointComp = Server.CreateObject("wr_mappoint_test.GetMilaege")

    '    'Dim objLoc(1 To 2) As MapPoint.Location
    '    Dim objLoc(2) As MapPoint.Location
    '    strMileage = 0
    '    If iErr1 <= 1 And iErr2 <= 1 Then
    '        strMileage = objMapPointComp.GetMilage(CStr(sAddr1), CStr(sAddr2))
    '        '	Set objLoc(1) = objMapPointMap.Find(sAddr1)
    '        '	If objLoc(1) Is Nothing Then	
    '        If strMileage = -1 Or strMileage = -3 Then
    '            If iErr1 = 0 Then
    '                iErr1 = -1
    '            ElseIf iErr1 = 1 Then
    '                iErr1 = 5
    '            Else
    '                iErr1 = 0
    '            End If
    '        End If
    '        '	Set objLoc(2) = objMapPointMap.Find(sAddr2)
    '        '	If objLoc(2) Is Nothing Then
    '        If strMileage = -2 Or strMileage = -3 Then
    '            If iErr2 = 0 Then
    '                iErr2 = -1
    '            ElseIf iErr2 = 1 Then
    '                iErr2 = 5
    '            Else
    '                iErr2 = 0
    '            End If
    '        End If
    '        '	If iErr1 = 0 And iErr2 = 0 Then
    '        '		objMapPointRoute.Waypoints.Add objLoc(1)
    '        '		objMapPointRoute.Waypoints.Add objLoc(2)
    '        '		objMapPointRoute.Calculate
    '        '		get_mileage = objMapPointRoute.Distance
    '        '		objMapPointRoute.Clear
    '        '	End If
    '        'End If
    '        'Screen.MousePointer = vbDefault
    '    End If
    '    Response.Write("Mileage: " & strMileage & "<br>")
    '    get_mileage = strMileage
    'End Function

    Public Function update_price_book_by_account(ByVal sCarType As String, ByVal sComp As String, ByVal sAcct As String, ByVal sSubAcct As String, ByVal price_book As Integer) As Integer
        ' update Price Book only. Price zones depends on Price book too, but it leaves them unchanged
        update_price_book_by_account = price_book
        If ServerIsMTC Then
            If Val(sComp) = 2 And (sAcct = "12000" Or sAcct = "13000" Or sAcct = "24000") Then
                Select Case Val(sCarType)
                    Case 1 ' SEDAN
                        update_price_book_by_account = 3
                    Case 2 ' 6 pax Limo
                        update_price_book_by_account = 5
                    Case 4 ' SUV
                        update_price_book_by_account = 4
                    Case Else
                        update_price_book_by_account = 0
                End Select
            End If
        End If
    End Function

    Public Function get_call_city_to_city_pricing(ByVal pr_book As Integer, ByVal ss_cmbPuCounty As String, ByVal txtPuCountyTrue As String, ByVal ss_cmbPuCity As String, ByVal ss_cmbDestCounty As String, ByVal txtDestCountyTrue As String, ByVal ss_cmbDestCity As String, ByVal ss_cmbCompany As String, ByVal ss_cmbAccountNo As String, ByVal ss_cmbSubAccountNo As String, ByVal txtPuPriceZone As String, ByVal txtDestPriceZone As String, ByVal bFoundInPriceTable As Boolean, ByVal fp_curTolls As Single) As String
        Dim sql_string As String
        Dim PuState As String
        Dim PuCounty As String
        Dim PuCity As String
        Dim DestState As String
        Dim DestCounty As String
        Dim DestCity As String
        Dim borough As String
        Dim sMsg As String
        Dim dr_gcctcp As DataSet

        bFoundInPriceTable = False
        If IsBoro(ss_cmbPuCounty) Then
            PuState = BoroughToState(ss_cmbPuCounty)
            PuCounty = ss_cmbPuCounty
            PuCity = BoroughToCity(ss_cmbPuCounty)
        ElseIf Not IsAirport(ss_cmbPuCounty) Then
            PuState = ss_cmbPuCounty
            PuCounty = txtPuCountyTrue
            PuCity = ss_cmbPuCity
        End If
        If IsBoro(ss_cmbDestCounty) Then
            DestState = BoroughToState(ss_cmbDestCounty)
            DestCounty = ss_cmbDestCounty
            DestCity = BoroughToCity(ss_cmbDestCounty)
        ElseIf Not IsAirport(ss_cmbDestCounty) Then
            DestState = ss_cmbDestCounty
            DestCounty = txtDestCountyTrue
            DestCity = ss_cmbDestCity
        End If
        If Not IsAirport(ss_cmbPuCounty) Then
            If IsBoro(ss_cmbDestCounty) Or IsAirport(ss_cmbDestCounty) Then
                borough = ss_cmbDestCounty
            Else
                Select Case UCase(Trim(ss_cmbDestCity))
                    Case "MANHATTAN"
                        borough = "M"
                    Case "BROOKLYN"
                        borough = "BK"
                    Case "BRONX"
                        borough = "BX"
                    Case "QUEENS"
                        borough = "QU"
                    Case "STATEN ISLAND"
                        borough = "SI"
                End Select
            End If
            'If Pricing_Table_From_Account > 0 Then pricing_table = Pricing_Table_From_Account 'user account info at first
            get_call_city_to_city_pricing = "0.00"
            ' search special price by account
            If Not IsAirport(ss_cmbDestCounty) Then
                'sql_string = "select price, tolls from Account_city_to_city_pricing(NOLOCK) where company=" & ss_cmbCompany & " and acct_id='" & ss_cmbAccountNo & "' and sub_acct_id='" & ss_cmbSubAccountNo & "' and from_state = '" & PuState & "' and from_county = '" & PuCounty & "' and from_city = '" & PuCity & "' and to_state='" & DestState & "' and to_county='" & DestCounty & "' and to_city='" & DestCity & "'"
                sql_string = "select price, tolls from Account_city_to_city_pricing(NOLOCK) where company=" & ss_cmbCompany & " and from_county = '" & PuCounty & "' and from_city = '" & PuCity & "' and to_county='" & DestCounty & "' and to_city='" & DestCity & "'"
                dr_gcctcp = Me.QueryData(sql_string, "Account_city_to_city_pricing")
                If dr_gcctcp.Tables("Account_city_to_city_pricing").Rows.Count > 0 Then
                    get_call_city_to_city_pricing = dr_gcctcp.Tables(0).Rows(0).Item("price").ToString
                    fp_curTolls = CSng("0" & dr_gcctcp.Tables(0).Rows(0).Item("tolls").ToString)
                    bFoundInPriceTable = True
                End If
                dr_gcctcp.Dispose()
                dr_gcctcp = Nothing
                If Val(get_call_city_to_city_pricing) <> 0 Then Exit Function
            End If
            If IsAirport(ss_cmbDestCounty) Then
                'sql_string = "select price, tolls from Account_city_to_airport_pricing(NOLOCK) where company=" & ss_cmbCompany & " and acct_id='" & ss_cmbAccountNo & "' and sub_acct_id='" & ss_cmbSubAccountNo & "' and state = '" & PuState & "' and city = '" & PuCity & "' and county = '" & PuCounty & "' and airport='" & ss_cmbDestCounty & "'"
                sql_string = "select price, tolls from Account_city_to_airport_pricing(NOLOCK) where company=" & ss_cmbCompany & " and city = '" & PuCity & "' and county = '" & PuCounty & "' and airport='" & ss_cmbDestCounty & "'"
                dr_gcctcp = Me.QueryData(sql_string, "Account_city_to_airport_pricing")
                If dr_gcctcp.Tables("Account_city_to_city_pricing").Rows.Count > 0 Then
                    get_call_city_to_city_pricing = dr_gcctcp.Tables(0).Rows(0).Item("price").ToString
                    fp_curTolls = CSng("0" & dr_gcctcp.Tables(0).Rows(0).Item("tolls").ToString)
                    bFoundInPriceTable = True
                End If
                dr_gcctcp.Dispose()
                dr_gcctcp = Nothing
                If Val(get_call_city_to_city_pricing) <> 0 Then Exit Function
            End If
        End If
        If Not IsAirport(ss_cmbDestCounty) Then
            If IsBoro(ss_cmbPuCounty) Or IsAirport(ss_cmbPuCounty) Then
                borough = ss_cmbPuCounty
            Else
                Select Case UCase(Trim(ss_cmbPuCity))
                    Case "MANHATTAN"
                        borough = "M"
                    Case "BROOKLYN"
                        borough = "BK"
                    Case "BRONX"
                        borough = "BX"
                    Case "QUEENS"
                        borough = "QU"
                    Case "STATEN ISLAND"
                        borough = "SI"
                End Select
            End If
            'If Pricing_Table_From_Account > 0 Then pricing_table = Pricing_Table_From_Account 'user account info at first
            get_call_city_to_city_pricing = "0.00"
            ' search special price by account
            If Not IsAirport(ss_cmbPuCounty) Then
                'sql_string = "select price, tolls from Account_city_to_city_pricing(NOLOCK) where company=" & ss_cmbCompany & " and acct_id='" & ss_cmbAccountNo & "' and sub_acct_id='" & ss_cmbSubAccountNo & "' and from_state = '" & DestState & "' and from_county = '" & DestCounty & "' and from_city = '" & DestCity & "' and to_state='" & PuState & "' and to_county='" & PuCounty & "' and to_city='" & PuCity & "'"
                sql_string = "select price, tolls from Account_city_to_city_pricing(NOLOCK) where company=" & ss_cmbCompany & " and from_county = '" & DestCounty & "' and from_city = '" & DestCity & "' and to_county='" & PuCounty & "' and to_city='" & PuCity & "'"
                dr_gcctcp = Me.QueryData(sql_string, "Account_city_to_city_pricing")
                If dr_gcctcp.Tables(0).Rows.Count > 0 Then
                    get_call_city_to_city_pricing = dr_gcctcp.Tables(0).Rows(0).Item("price").ToString
                    fp_curTolls = CSng("0" & Convert.ToString(dr_gcctcp.Tables(0).Rows(0).Item("tolls")))
                    bFoundInPriceTable = True
                End If
                dr_gcctcp.Dispose()
                dr_gcctcp = Nothing
                If Val(get_call_city_to_city_pricing) <> 0 Then Exit Function
            End If
            If IsAirport(ss_cmbPuCounty) Then ' and strCar_Type = "1" Then
                'sql_string = "select price, tolls from Account_city_to_airport_pricing(NOLOCK) where company=" & ss_cmbCompany & " and acct_id='" & ss_cmbAccountNo & "' and sub_acct_id='" & ss_cmbSubAccountNo & "' and state = '" & DestState & "' and city = '" & DestCity & "' and county = '" & DestCounty & "' and airport='" & ss_cmbPuCounty & "'"
                sql_string = "select price, tolls from Account_city_to_airport_pricing(NOLOCK) where company=" & ss_cmbCompany & " and city = '" & DestCity & "' and county = '" & DestCounty & "' and airport='" & ss_cmbPuCounty & "'"
                dr_gcctcp = Me.QueryData(sql_string, "Account_city_to_airport_pricing")
                If dr_gcctcp.Tables("Account_city_to_airport_pricing").Rows.Count > 0 Then
                    get_call_city_to_city_pricing = dr_gcctcp.Tables(0).Rows(0).Item("price").ToString
                    fp_curTolls = CSng("0" & Convert.ToString(dr_gcctcp.Tables(0).Rows(0).Item("tolls")))
                    bFoundInPriceTable = True
                End If
                dr_gcctcp.Dispose()
                dr_gcctcp = Nothing
                If Val(get_call_city_to_city_pricing) <> 0 Then Exit Function
            End If
        End If
        If IsAirport(ss_cmbPuCounty) And IsAirport(ss_cmbDestCounty) Then
            'If Pricing_Table_From_Account > 0 Then pricing_table = Pricing_Table_From_Account 'user account info at first
            get_call_city_to_city_pricing = "0.00"
            ' search special price by account
            'sql_string = "select price, tolls from Account_airport_to_airport_pricing(NOLOCK) where company=" & ss_cmbCompany & " and acct_id='" & ss_cmbAccountNo & "' and sub_acct_id='" & ss_cmbSubAccountNo & "' and from_airport = '" & ss_cmbPuCounty & "' and to_airport = '" & ss_cmbDestCounty & "'"
            sql_string = "select price, tolls from Account_airport_to_airport_pricing(NOLOCK) where company=" & ss_cmbCompany & " and from_airport = '" & ss_cmbPuCounty & "' and to_airport = '" & ss_cmbDestCounty & "'"
            dr_gcctcp = Me.QueryData(sql_string, "Account_airport_to_airport_pricing")
            If dr_gcctcp.Tables(0).Rows.Count > 0 Then
                get_call_city_to_city_pricing = Format(dr_gcctcp.Tables(0).Rows(0).Item("price").ToString, "#.00")
                fp_curTolls = CSng("0" & dr_gcctcp.Tables(0).Rows(0).Item("tolls").ToString)
                bFoundInPriceTable = True
            End If
            dr_gcctcp.Dispose()
            dr_gcctcp = Nothing
            If Val(get_call_city_to_city_pricing) <> 0 Then Exit Function
        End If
        get_call_city_to_city_pricing = "0.00"
        If Trim(txtPuPriceZone) <> "" And Trim(txtDestPriceZone) <> "" Then
            sql_string = "select price,tolls from price(NOLOCK) where table_id = " & pr_book & " and from_zone = '" & Trim(txtPuPriceZone) & "' and to_zone = '" & Trim(txtDestPriceZone) & "'"
            dr_gcctcp = Me.QueryData(sql_string, "price")
            If dr_gcctcp.Tables(0).Rows.Count > 0 Then
                get_call_city_to_city_pricing = dr_gcctcp.Tables(0).Rows(0).Item("price").ToString
                fp_curTolls = CSng("0" & dr_gcctcp.Tables(0).Rows(0).Item("tolls").ToString)
                bFoundInPriceTable = True
            Else
                dr_gcctcp.Dispose()
                sql_string = "select price,tolls from price(NOLOCK) where table_id = " & pr_book & " and from_zone = '" & txtDestPriceZone & "' and to_zone = '" & txtPuPriceZone & "'"
                dr_gcctcp = Me.QueryData(sql_string, "price")
                If dr_gcctcp.Tables(0).Rows.Count > 0 Then
                    'sMsg = "The direct price is missing" & vbCrLf & "Do you want to retrieve the return price instead"
                    'If MsgBox(sMsg, vbQuestion + vbYesNo) = vbYes Then
                    get_call_city_to_city_pricing = dr_gcctcp.Tables(0).Rows(0).Item("price").ToString
                    fp_curTolls = CSng("0" & dr_gcctcp.Tables(0).Rows(0).Item("tolls").ToString)
                    bFoundInPriceTable = True
                    'Else
                    '  get_call_city_to_city_pricing = "0.00"
                    'End If
                Else
                    get_call_city_to_city_pricing = "0.00"
                End If
            End If
            dr_gcctcp.Dispose()
            dr_gcctcp = Nothing
        End If
    End Function


    Public Function IsBoro(ByVal boro As String) As Boolean
        Dim i As Integer
        i = 0
        IsBoro = False
        Do While gsLocalCounty(i) <> ""
            If gsLocalCounty(i) = Trim(boro) Then
                IsBoro = True
                Exit Do
            End If
            i = i + 1
        Loop
    End Function

    Public Function BoroughToState(ByVal boro As String) As String
        Dim i As Integer
        i = 0 : BoroughToState = ""
        Do While gsLocalCounty(i) <> ""
            If Trim(gsLocalCounty(i)) = Trim(boro) Then
                BoroughToState = gsLocalCountyState(i)
                Exit Do
            End If
            i = i + 1
        Loop
    End Function

    Public Function BoroughToCity(ByVal boro As String) As String
        Dim i As Integer
        i = 0 : BoroughToCity = ""
        Do While gsLocalCounty(i) <> ""
            If UCase(Trim(gsLocalCounty(i))) = UCase(Trim(boro)) Then
                BoroughToCity = Trim(gsLocalCountyDesc(i))
                Exit Do
            End If
            i = i + 1
        Loop
    End Function

    Public Function get_call_est_tolls(ByVal fp_curTolls As Single, ByVal bFoundInPriceTable As Boolean, ByVal PuCounty As String, ByVal PuCity As String, ByVal DestCounty As String, ByVal DestCity As String, ByVal sNoTolls As String) As Single
        Dim i As Integer
        Dim j As Integer
        If bFoundInPriceTable Then
            If sNoTolls = "t" Then
                get_call_est_tolls = 0
            Else
                get_call_est_tolls = fp_curTolls
            End If
        Else
            i = -1 : j = -1
            If PuCounty = "NJ" And UCase(Trim(PuCity)) = "NEWARK" Then
                i = 5
            End If
            If PuCounty = "LGA" Then
                i = 4
            End If
            If PuCounty = "JFK" Then
                i = 3
            End If
            If PuCounty = "EWR" Then
                i = 2
            End If
            If PuCounty = "M" Or (PuCounty = "NY" And UCase(Trim(PuCity)) = "MANHATTAN") Then
                i = 1
            End If
            If PuCounty = "BK" Or (PuCounty = "NY" And UCase(Trim(PuCity)) = "BROOKLYN") Then
                i = 1
            End If
            If PuCounty = "BX" Or (PuCounty = "NY" And UCase(Trim(PuCity)) = "BRONX") Then
                i = 1
            End If
            If PuCounty = "QU" Or (PuCounty = "NY" And UCase(Trim(PuCity)) = "QUEENS") Then
                i = 1
            End If
            If PuCounty = "SI" Or (PuCounty = "NY" And UCase(Trim(PuCity)) = "STATEN ISLAND") Then
                i = 1
            End If
            If PuCounty = "NY" And i <> 1 Then ' NY but not boro
                i = 6
            End If
            If i = -1 And PuCounty = "NJ" Then
                i = 0
            End If
            If DestCounty = "NJ" And UCase(Trim(DestCity)) = "NEWARK" Then
                j = 5
            End If
            If DestCounty = "LGA" Then
                j = 4
            End If
            If DestCounty = "JFK" Then
                j = 3
            End If
            If DestCounty = "EWR" Then
                j = 2
            End If
            If DestCounty = "M" Or (DestCounty = "NY" And UCase(Trim(DestCity)) = "MANHATTAN") Then
                j = 1
            End If
            If DestCounty = "BK" Or (DestCounty = "NY" And UCase(Trim(DestCity)) = "BROOKLYN") Then
                j = 1
            End If
            If DestCounty = "BX" Or (DestCounty = "NY" And UCase(Trim(DestCity)) = "BRONX") Then
                j = 1
            End If
            If DestCounty = "QU" Or (DestCounty = "NY" And UCase(Trim(DestCity)) = "QUEENS") Then
                j = 1
            End If
            If DestCounty = "SI" Or (DestCounty = "NY" And UCase(Trim(DestCity)) = "STATEN ISLAND") Then
                j = 1
            End If
            If DestCounty = "NY" And j <> 1 Then ' NY but not boro
                j = 6
            End If
            If j = -1 And DestCounty = "NJ" Then
                j = 0
            End If
            If i < 0 Or j < 0 Then
                If i = 3 Or i = 4 Or j = 3 Or j = 4 Then ' PU or Dest is LGA or JFK
                    get_call_est_tolls = 16.5
                Else
                    get_call_est_tolls = 0
                End If
                Exit Function
            End If
            Select Case i + 10 * j
                Case 0  ' NJ "Other" <--> NJ "Other"
                    get_call_est_tolls = 0
                Case 1, 10  ' NYC <--> NJ "Other"
                    get_call_est_tolls = 6.5
                Case 2, 20  ' EWR <--> NJ "Other"
                    get_call_est_tolls = 2.5
                Case 3, 30  ' JFK <--> NJ "Other"
                    get_call_est_tolls = 16.5
                Case 4, 40  ' LGA <--> NJ "Other"
                    get_call_est_tolls = 16.5
                Case 5, 50  ' NJ Newark <--> NJ "Other"
                    get_call_est_tolls = 0
                Case 11 ' NYC <--> NYC
                    get_call_est_tolls = 0
                Case 12, 21 ' EWR <--> NYC
                    get_call_est_tolls = 14
                Case 13, 31 ' JFK <--> NYC
                    get_call_est_tolls = 16.5
                Case 14, 41 ' LGA <--> NYC
                    get_call_est_tolls = 16.5
                Case 15, 51 ' NJ Newark <--> NYC
                    get_call_est_tolls = 6.5
                Case 16, 61 ' NYC <--> NY not boro
                    get_call_est_tolls = 6.5
                Case 22     ' EWR <--> EWR
                    get_call_est_tolls = 0
                Case 23, 32 ' EWR <--> JFK
                    get_call_est_tolls = 16.5
                Case 24, 42 ' EWR <--> LGA
                    get_call_est_tolls = 16.5
                Case 25, 52 ' NJ Newark <--> EWR
                    get_call_est_tolls = 2.5
                Case 26, 62 ' EWR <--> NY not boro
                    get_call_est_tolls = 2.5
                Case 33     ' JFK <--> JFK
                    get_call_est_tolls = 0
                Case 34, 43 ' JFK <--> LGA
                    get_call_est_tolls = 16.5
                Case 35, 53 ' JFK <--> NJ Newark
                    get_call_est_tolls = 16.5
                Case 36, 63 ' JFK <--> NY not boro
                    get_call_est_tolls = 16.5
                Case 44     ' LGA <--> LGA
                    get_call_est_tolls = 0
                Case 45, 54 ' LGA <--> NJ Newark
                    get_call_est_tolls = 16.5
                Case 46, 64 ' LGA <--> NY not boro
                    get_call_est_tolls = 16.5
                Case 55     ' NJ Newark <--> NJ Newark
                    get_call_est_tolls = 0
                Case Else
                    get_call_est_tolls = 0
            End Select
            If sNoTolls = "t" Then
                get_call_est_tolls = 0
            End If
        End If
    End Function

    Public Function get_call_est_parking(ByVal PuCounty As String, ByVal sNoParking As String) As Single
        'Dim vInd As Object
        Dim vInd As Integer
        If IsAirport(PuCounty, vInd) Then
            get_call_est_parking = Convert.ToSingle(gsngAirportParking(vInd))
        Else
            get_call_est_parking = 0
        End If
        If sNoParking = "t" Then get_call_est_parking = 0
    End Function

    Public Function get_call_est_stops(ByVal ss_chkHrRate As Boolean, ByVal sPuCounty As String, ByVal sPuCountyTrue As String, ByVal sPuCity As String, ByVal sDestCounty As String, ByVal sDestCountyTrue As String, ByVal sDestCity As String, ByVal sStateAirport() As String, ByVal sStopCounty() As String, ByVal sCityAirline() As String, ByVal bIsAirport() As Boolean, ByVal ss_cmbCarType As String) As Single
        Dim i As Integer, iStopsCount As Integer
        Dim PuState As String, PuCounty As String, PuCity As String
        Dim DestState As String, DestCounty As String, DestCity As String
        Dim StopState As String, StopCounty As String, StopCity As String
        get_call_est_stops = 0
        If ss_chkHrRate = True Then Exit Function
        If Not IsAirport(sPuCounty) Then
            If IsBoro(sPuCounty) Then
                PuState = BoroughToState(sPuCounty)
                PuCounty = sPuCounty
                PuCity = BoroughToCity(sPuCounty)
            Else
                PuState = sPuCounty
                PuCounty = sPuCountyTrue
                PuCity = sPuCity
            End If
        Else
            PuState = ""
            PuCounty = ""
            PuCity = ""
        End If
        If Not IsAirport(sDestCounty) Then
            If IsBoro(sDestCounty) Then
                DestState = BoroughToState(sDestCounty)
                DestCounty = sDestCounty
                DestCity = BoroughToCity(sDestCounty)
            Else
                DestState = sDestCounty
                DestCounty = sDestCountyTrue
                DestCity = sDestCity
            End If
        Else
            DestState = ""
            DestCounty = ""
            DestCity = ""
        End If

        iStopsCount = 0
        For i = 1 To 8
            If sStateAirport(i) <> "" Then iStopsCount = iStopsCount + 1
            If sStateAirport(i) <> "" And Not bIsAirport(i) Then
                If IsBoro(sStateAirport(i)) Then
                    StopState = BoroughToState(sStateAirport(i))
                    StopCounty = sStateAirport(i)
                    StopCity = BoroughToCity(sStateAirport(i))
                Else
                    StopState = sStateAirport(i)
                    StopCounty = sStopCounty(i)
                    StopCity = sCityAirline(i)
                End If
                If StopState = PuState Or StopState = DestState Then
                    If StopCounty = PuCounty Or StopCounty = DestCounty Then
                        If StopCity = PuCity Or StopCity = DestCity Then
                            'get_call_est_stops = get_call_est_stops + IIf(ServerIsConcord And ss_cmbCarType <> "1", 20, 10)
                            get_call_est_stops = get_call_est_stops + Convert.ToSingle(IIf(ss_cmbCarType <> "1", 20, 10))
                        Else
                            'get_call_est_stops = get_call_est_stops + IIf(ServerIsConcord And ss_cmbCarType <> "1", 30, 15)
                            get_call_est_stops = get_call_est_stops + Convert.ToSingle(IIf(ss_cmbCarType <> "1", 30, 15))
                        End If
                    Else
                        'get_call_est_stops = get_call_est_stops + IIf(ServerIsConcord And ss_cmbCarType <> "1", 40, 20)
                        get_call_est_stops = get_call_est_stops + Convert.ToSingle(IIf(ss_cmbCarType <> "1", 40, 20))
                    End If
                Else
                    get_call_est_stops = 0
                End If
            End If
        Next i
        If iStopsCount > 1 Then get_call_est_stops = 0
    End Function

    Public Function get_call_est_WT_charges(ByVal cmp As String, ByVal iAirportWTCustomer As Integer, ByVal ss_cmbPuCounty As String, ByVal ss_chkHrRate As Boolean, ByVal iWT() As Integer, ByVal sngWTChargePerHr As Single, ByVal iGraceReseyWT As Integer, ByVal iWTMinAdd As Integer) As Single
        Dim i As Integer
        Dim iWTMinTotal As Integer
        Dim sngPricePerHour As Single
        Dim iGracePeriod As Integer
        get_call_est_WT_charges = 0
        iWTMinTotal = 0
        If ss_chkHrRate = False Then
            For i = 0 To 9
                iWTMinTotal = iWTMinTotal + iWT(i)
            Next i
        End If
        iWTMinTotal = iWTMinTotal + Convert.ToInt32(WT_min_correction(Convert.ToInt32(cmp), iWTMinAdd, IsAirport(ss_cmbPuCounty)))  'Val(Form66!fp_intWTmin)
        If IsAirport(ss_cmbPuCounty) Then
            iGracePeriod = iAirportWTCustomer
        Else
            iGracePeriod = iGraceReseyWT
        End If
        iWTMinTotal = Convert.ToInt32(IIf(iWTMinTotal - iGracePeriod > 0, iWTMinTotal - iGracePeriod, 0))
        get_call_est_WT_charges = CSng((iWTMinTotal * sngWTChargePerHr / 60) * 100) / 100
    End Function

    Public Function get_call_est_OT_charges(ByVal comp As String, ByVal acct As String, ByVal sub_acct As String, ByVal sngAM_Holiday_Surcharge As Single, ByVal sFrom_AM_Holiday_Surcharge As String, ByVal sTo_AM_Holiday_Surcharge As String, ByVal sngAM_Holiday_Surcharge2 As Single, ByVal sFrom_AM_Holiday_Surcharge2 As String, ByVal sTo_AM_Holiday_Surcharge2 As String, ByVal sReqTime As String, ByVal sReqDate As String) As Single
        get_call_est_OT_charges = 0
        get_call_est_OT_charges = get_holiday_surcharge(comp, acct, sub_acct, sReqTime, sReqDate)
        If get_call_est_OT_charges > 0 Then Exit Function
        If sFrom_AM_Holiday_Surcharge <= sTo_AM_Holiday_Surcharge Then
            If sReqTime >= sFrom_AM_Holiday_Surcharge And sReqTime <= sTo_AM_Holiday_Surcharge Then
                get_call_est_OT_charges = sngAM_Holiday_Surcharge
            End If
        Else
            If (sReqTime >= sFrom_AM_Holiday_Surcharge And sReqTime <= "23:59") Or (sReqTime >= "00:00" And sReqTime <= sTo_AM_Holiday_Surcharge) Then
                get_call_est_OT_charges = sngAM_Holiday_Surcharge
            End If
        End If
        If get_call_est_OT_charges > 0 Then Exit Function
        If sFrom_AM_Holiday_Surcharge2 <= sTo_AM_Holiday_Surcharge2 Then
            If sReqTime >= sFrom_AM_Holiday_Surcharge2 And sReqTime <= sTo_AM_Holiday_Surcharge2 Then
                get_call_est_OT_charges = sngAM_Holiday_Surcharge2
            End If
        Else
            If (sReqTime >= sFrom_AM_Holiday_Surcharge2 And sReqTime <= "23:59") Or (sReqTime >= "00:00" And sReqTime <= sTo_AM_Holiday_Surcharge2) Then
                get_call_est_OT_charges = sngAM_Holiday_Surcharge2
            End If
        End If
    End Function

    Public Function get_holiday_surcharge(ByVal comp As String, ByVal acct As String, ByVal sub_acct As String, ByVal sTime As String, ByVal sDate As String) As Single
        Dim rs As DataSet
        Dim sSQL As String
        Dim YYYY As String
        Dim dFrom As Date
        Dim dTo As Date
        Dim dCur As Date
        get_holiday_surcharge = 0
        dCur = CDate(sDate & " " & sTime)
        YYYY = Convert.ToString(Year(Now))
        sSQL = "Select * from Account_Holiday(nolock) where "
        sSQL = sSQL & " company=" & comp
        sSQL = sSQL & " and acct_id='" & acct & "'"
        sSQL = sSQL & " and sub_acct_id='" & sub_acct & "'"
        rs = Me.QueryData(sSQL, "Account_Holiday")
        Dim i As Integer
        'rs = cn.OpenResultset(sSQL, rdOpenForwardOnly, rdConcurReadOnly)
        Do While Not i <= rs.Tables(0).Rows.Count
            dFrom = CDate(Format(rs.Tables(0).Rows(0).Item("from_date_time"), "MM/DD") & "/" & YYYY & " " & Format(rs.Tables(0).Rows(0).Item("from_date_time"), "HH:MM"))
            dTo = CDate(Format(rs.Tables(0).Rows(0).Item("to_date_time"), "MM/DD") & "/" & YYYY & " " & Format(rs.Tables(0).Rows(0).Item("to_date_time"), "HH:MM"))
            If dFrom <= dTo Then
                If dFrom <= dCur And dCur <= dTo Then
                    get_holiday_surcharge = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("surcharge").ToString)
                    Exit Do
                End If
            Else
                If dFrom <= dCur And dCur <= DateAdd("yyyy", 1, dTo) Then
                    get_holiday_surcharge = Convert.ToSingle("" & rs.Tables(0).Rows(0).Item("surcharge").ToString)
                    Exit Do
                End If
            End If
            i = i + 1
        Loop
        rs.Dispose()
        rs = Nothing
    End Function

    Public Function get_call_est_tips(ByVal sngBasicRate As Single, ByVal fp_curStops As Single, ByVal fp_curWT As Single, ByVal fp_curOT As Single, ByVal sngTipsPerc As Single, ByVal sngTipsPercCarType As Single, ByVal sngTipsPerc_Opr As Single, ByVal sNoTips As String, ByVal fp_curPackage As Single) As Single
        If sngTipsPerc_Opr > 0 Then
            'get_call_est_tips = (sngBasicRate + fp_curStops + fp_curWT + fp_curOT + IIf(ServerIsConcord, fp_curPackage, 0)) * sngTipsPerc_Opr / 100
            get_call_est_tips = (sngBasicRate + fp_curStops + fp_curWT + fp_curOT + fp_curPackage) * sngTipsPerc_Opr / 100
        Else
            'get_call_est_tips = (sngBasicRate + fp_curStops + fp_curWT + fp_curOT + IIf(ServerIsConcord, fp_curPackage, 0)) * IIf(sngTipsPerc = 0, sngTipsPercCarType, sngTipsPerc) / 100
            get_call_est_tips = (sngBasicRate + fp_curStops + fp_curWT + fp_curOT + fp_curPackage) * Convert.ToSingle(IIf(sngTipsPerc = 0, sngTipsPercCarType, sngTipsPerc)) / 100
        End If
        If sNoTips = "t" Then get_call_est_tips = 0
    End Function
    '------------------------------------------------------------------------------
    '-- Function get_call_est_tips - 03/20/03
    '------------------------------------------------------------------------------
    'Function get_call_est_tips(ByVal sngBasicRate As Single, ByVal fp_curStops As Single, ByVal fp_curWT As Single, ByVal fp_curOT As Single, ByVal sngTipsPerc As Single, ByVal sngTipsPercCarType As Single, ByVal sngTipsPerc_Opr As Single, ByVal sNoTips As String) As Single

    '    If sngTipsPerc_Opr > 0 Then
    '        get_call_est_tips = (sngBasicRate + fp_curStops + fp_curWT + fp_curOT) * sngTipsPerc_Opr / 100
    '    Else
    '        get_call_est_tips = (sngBasicRate + fp_curStops + fp_curWT + fp_curOT) * CSng(IIf(sngTipsPerc = 0, sngTipsPercCarType, sngTipsPerc)) / 100
    '    End If
    '    If sNoTips = "t" Then get_call_est_tips = 0

    'End Function
    '------------------------------------------------------------------------------
    '-- Function get_call_est_STC -- 03/20/03
    '------------------------------------------------------------------------------
    'Function get_call_est_STC(ByVal sngBasicRate As Single, ByVal fp_curStops As Single, ByVal fp_curWT As Single, ByVal fp_curOT As Single, ByVal sngSTCPerc As Single) As Single
    '    get_call_est_STC = CSng(sngBasicRate + fp_curStops + fp_curWT + fp_curOT) * sngSTCPerc / 100
    'End Function
    Public Function get_call_est_STC(ByVal sngBasicRate As Single, ByVal fp_curStops As Single, ByVal fp_curWT As Single, ByVal fp_curOT As Single, ByVal sngSTCPerc As Single, ByVal fp_curPackage As Single) As Single
        'get_call_est_STC = Val(sngBasicRate + fp_curStops + fp_curWT + fp_curOT + IIf(ServerIsConcord, fp_curPackage, 0)) * sngSTCPerc / 100
        get_call_est_STC = Convert.ToSingle(sngBasicRate + fp_curStops + fp_curWT + fp_curOT + fp_curPackage) * sngSTCPerc / 100
    End Function

    Public Function get_call_est_discount(ByVal sngBasicRate As Single, ByVal fp_curStops As Single, ByVal fp_curWT As Single, ByVal fp_curOT As Single, ByVal sngDiscountPerc As Single, ByVal sNoDiscount As String) As Single
        get_call_est_discount = Convert.ToSingle(sngBasicRate) * sngDiscountPerc / 100
        'get_call_est_discount = Val(sngBasicRate + fp_curStops + fp_curWT + fp_curOT) * sngDiscountPerc / 100
        If sNoDiscount = "t" Then get_call_est_discount = 0
    End Function

    Public Function IsNull(ByVal values As String) As Boolean

        If Trim(Convert.ToString(values)) = "" Then

            Return True
        Else
            Return False

        End If

    End Function

    '------------------------------------------------------------------------------
    '-- Function get_city_by_boro1 -- 3/20/03
    '------------------------------------------------------------------------------
    Function get_city_by_boro1(ByVal sBorough As String, ByRef sCity As String, ByRef sState As String) As Boolean
        get_city_by_boro1 = False
        Select Case sBorough
            Case "M"
                sCity = "Manhattan"
                sState = "NY"
                get_city_by_boro1 = True
            Case "BK"
                sCity = "Brooklyn"
                sState = "NY"
                get_city_by_boro1 = True
            Case "QU"
                sCity = "Queens"
                sState = "NY"
                get_city_by_boro1 = True
            Case "BX"
                sCity = "Bronx"
                sState = "NY"
                get_city_by_boro1 = True
            Case "SI"
                sCity = "Staten Island"
                sState = "NY"
                get_city_by_boro1 = True
        End Select
    End Function

    '------------------------------------------------------------------------------
    '-- Function WT_min_correction -- 03/20/03
    '------------------------------------------------------------------------------
    Function WT_min_correction(ByVal cmp As Integer, ByVal iMin As Integer, ByVal BisAirport As Boolean) As Single
        Dim dr_wtmc As DataSet
        Dim SQLStr As String
        SQLStr = "select charge_minute from " & Convert.ToString(IIf(BisAirport, "Waiting_Time_Airport(nolock) ", "Waiting_time_General(nolock) "))
        SQLStr = SQLStr & "where company=" & cmp & " and from_minute <= " & iMin & " and to_minute >= " & iMin
        dr_wtmc = Me.QueryData(SQLStr, "tt")
        If dr_wtmc.Tables(0).Rows.Count = 0 Then
            WT_min_correction = iMin
        Else
            WT_min_correction = CSng(dr_wtmc.Tables(0).Rows(0).Item("charge_minute"))
        End If
        dr_wtmc.Dispose()
        dr_wtmc = Nothing
    End Function

#End Region

End Class
