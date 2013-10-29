Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System
Imports Business
Imports DataAccess

Public Class EstPrice
    Inherits CommonDB

    'Dim sngBasicRate, fp_curTolls, fp_curParking, fp_curTel, fp_curM_G, fp_curPackage, fp_curOT, fp_curTips, fp_curDiscount, fp_curSTC, fp_curStops, fp_curWT, fp_curServiceFee, fp_curExpenses, fp_curDeposit, fp_intWTmin, fp_curDiscCert, iPuErr, iDestErr, iErr As String
    'Dim gsLocalCounty(100), gsLocalCountyState(100), gsLocalCountyDesc(100), gsStateOT(100), gsStateOTDesc(100), gsAirport(200), gsAirportDesc(200), gsngAirportParking(200) As VariantType
    ''Private iPuErr, iDestErr, iErr As Integer
    ''Private gsLocalCounty(100), gsLocalCountyState(100), gsLocalCountyDesc(100), gsStateOT(100), gsStateOTDesc(100), gsAirport(200), gsAirportDesc(200), gsngAirportParking(200) As String
    ''Private SQLStr
    ''Private PuPriceZone, DPriceZone, strCar_Type, strPCounty_true, strDCounty_true, strRequestTime, strCompany
    'Private DCity, PCity, DState, PState, PStrName, PStrNo, PZipCode, DStrName, DStrNo, DZipCode As String
    'Private StrMileage As Single
    'Public tmpDZone, tmpPZone As String
    'Public errflag(2), dispzone(2), pricezone(2), intAddrNo As Integer
    Private sngBasicRate, fp_curTolls, fp_curParking, fp_curTel, fp_curM_G, fp_curPackage, fp_curOT, fp_curTips, fp_curDiscount, fp_curSTC, fp_curStops, fp_curWT, fp_curServiceFee, fp_curExpenses, fp_curDeposit, fp_intWTmin, fp_curDiscCert As Single
    Private iPuErr, iDestErr, iErr As Integer
    Private gsLocalCounty(500), gsLocalCountyState(500), gsLocalCountyDesc(500), gsStateOT(500), gsStateOTDesc(500), gsAirport(500), gsAirportDesc(500), gsngAirportParking(500) As String
    'Private SQLStr
    'Private PuPriceZone, DPriceZone, strCar_Type, strPCounty_true, strDCounty_true, strRequestTime, strCompany
    Private DCity, PCity, DState, PState, PStrName, PStrNo, PZipCode, DStrName, DStrNo, DZipCode As String
    Private StrMileage As Single
    Public tmpDZone, tmpPZone As String
    Public errflag(2), dispzone(2), pricezone(2), intAddrNo As Integer

#Region "Perameters & Properties"

    Private m_mileage As Single
    Private m_base_rate As Decimal
    Private m_tools_charges As Decimal
    Private m_parking_charges As Decimal
    Private m_stops_charges As Decimal
    Private m_WT_charges As Decimal
    Private m_tel_charges As String
    Private m_M_G_charges As Decimal
    Private m_package_charges As String
    Private m_OT_charges As Decimal
    Private m_tips_charges As Decimal
    Private m_discount As Decimal
    Private m_STC_charges As Decimal
    Private m_service_fee As Decimal

    Public Property Mileage() As Single
        Get
            Return m_mileage
        End Get
        Set(ByVal Value As Single)
            m_mileage = Value
        End Set
    End Property
    Public Property Base_rate() As Decimal
        Get
            Return m_base_rate
        End Get
        Set(ByVal Value As Decimal)
            m_base_rate = Value
        End Set
    End Property
    Public Property Tool_Charges() As Decimal
        Get
            Return m_tools_charges
        End Get
        Set(ByVal Value As Decimal)
            m_tools_charges = Value
        End Set
    End Property
    Public Property Park_Charges() As Decimal
        Get
            Return m_parking_charges
        End Get
        Set(ByVal Value As Decimal)
            m_parking_charges = Value
        End Set
    End Property
    Public Property Stops_Charges() As Decimal
        Get
            Return m_stops_charges
        End Get
        Set(ByVal Value As Decimal)
            m_stops_charges = Value
        End Set
    End Property
    Public Property WT_Charges() As Decimal
        Get
            Return m_WT_charges
        End Get
        Set(ByVal Value As Decimal)
            m_WT_charges = Value
        End Set
    End Property
    Public Property Tel_charges() As String
        Get
            Return m_tel_charges
        End Get
        Set(ByVal value As String)
            m_tel_charges = value
        End Set
    End Property
    Public Property M_G_charges() As Decimal
        Get
            Return m_M_G_charges
        End Get
        Set(ByVal value As Decimal)
            m_M_G_charges = value
        End Set
    End Property
    Public Property Package_Charges() As String
        Get
            Return m_package_charges
        End Get
        Set(ByVal Value As String)
            m_package_charges = Value
        End Set
    End Property
    Public Property Tips_Charges() As Decimal
        Get
            Return m_tips_charges
        End Get
        Set(ByVal Value As Decimal)
            m_tips_charges = Value
        End Set
    End Property
    Public Property OT_Charges() As Decimal
        Get
            Return m_OT_charges
        End Get
        Set(ByVal Value As Decimal)
            m_OT_charges = Value
        End Set
    End Property
    Public Property Discount_Charges() As Decimal
        Get
            Return m_discount
        End Get
        Set(ByVal Value As Decimal)
            m_discount = Value
        End Set
    End Property
    Public Property STC_Charges() As Decimal
        Get
            Return m_STC_charges
        End Get
        Set(ByVal Value As Decimal)
            m_STC_charges = Value
        End Set
    End Property
    Public Property Service_Charges() As Decimal
        Get
            Return m_service_fee
        End Get
        Set(ByVal Value As Decimal)
            m_service_fee = Value
        End Set
    End Property

#End Region

#Region "Public Sub Perameters & Properties"

    Public Sub New()

        With Me
            .m_mileage = 0.0
            .m_base_rate = 0
            .m_tools_charges = 0
            .m_parking_charges = 0
            .m_stops_charges = 0
            .m_WT_charges = 0
            .m_tel_charges = "0"
            .m_M_G_charges = 0
            .m_package_charges = "0"
            .m_OT_charges = 0
            .m_tips_charges = 0
            .m_discount = 5
            .m_STC_charges = 0
            .m_service_fee = 0
        End With

    End Sub

#End Region

#Region "Private Function Get Est Price"
    '------------------------------------------------------------------------------
    '-- function get_price()
    '------------------------------------------------------------------------------
    Function get_price(ByVal strAcctId As String, ByVal strSubAcctId As String, ByVal strCompany As String, _
                                ByVal DStrReqTime As Date, ByVal IstrCar_type As String, ByVal strPuState As String, _
                                ByVal strPuCounty As String, ByVal strPuCity As String, ByVal strDestState As String, _
                                ByVal strDestCounty As String, ByVal strDestCity As String, ByVal strPStNo As String, _
                                ByVal strPStrName As String, ByVal strPZipCode As String, ByVal strDestStNo As String, _
                                ByVal strDestStrName As String, ByVal strDestPZipCode As String, ByVal strCar_type As Integer, _
                                ByVal PuPriceZone As String, ByVal DPriceZone As String) As Single

        Const WEB_DISCOUNT As Single = 5.0

        Dim pu_type As Single = 0.0
        Dim dest_type As Single = 0.0
        Dim temp_price As String = "0.0"
        Dim sngPrice As Single = 0.0
        Dim boro As Single = 0.0
        Dim sngTips As Single = 0.0
        'Dim sngSTC 
        Dim sngTolls As Single = 0.0
        Dim sngParking As Single = 0.0
        Dim sngStops As Single = 0.0
        Dim sql_string As Single = 0.0
        Dim j As Integer

        '=========================================================================
        '== Get Mileage
        '=========================================================================
        'Dim intErr1, intEErr2 As Integer
        'Dim strAddr1, strAddr2 As String
        'strAddr1 = Me.get_address(strPStNo, strPStrName, strPuState, strPuCity, strPZipCode)
        'strAddr2 = Me.get_address(strDestStNo, strDestStrName, strDestState, strDestCity, strDestPZipCode)

        'StrMileage = Me.Operator_Pricing_GetMileage(strAddr1, strAddr2, intErr1, intEErr2)
        'StrMileage = 100
        '=========================================================================
        '=========================================
        PState = strPuState
        PCity = strPuCity
        DState = strDestState
        DCity = strDestCity

        PStrName = strPStrName
        PStrNo = strPStNo
        PZipCode = strPZipCode

        DStrName = strDestStrName
        DStrNo = strDestStNo
        DZipCode = strDestPZipCode
        '=========================================
        Dim sPuAddr, sDestAddr As String
        Dim price_est As Single
        price_est = CSng(price_est)
        Dim sngHrRate_tmp As Single
        sngHrRate_tmp = CSng(sngHrRate_tmp)
        Dim sngBonus_tmp As Single
        sngBonus_tmp = CSng(sngBonus_tmp)
        Dim sngTipsPerc_tmp As Single
        sngTipsPerc_tmp = CSng(sngTipsPerc_tmp)
        Dim sngPricePerMile_tmp As Single
        sngPricePerMile_tmp = CSng(sngPricePerMile_tmp)
        Dim rs As Single = 0.0
        Dim ss_cmbCompany As Single = 0.0
        Dim ss_cmbAccountNo As Single = 0.0
        Dim ss_cmbSubAccountNo As Single = 0.0
        Dim ss_cmbPuCounty As Single = 0.0
        Dim txtPuCountyTrue As String
        Dim ss_cmb_PuCity As Single = 0.0
        Dim txtPuStNo As Single = 0.0
        Dim ss_cmbPuStName As Single = 0.0
        Dim sPuZip As Single = 0.0
        Dim ss_cmbDestCounty As Single = 0.0
        Dim txtDestCountyTrue As String
        Dim ss_cmbDestCity As Single = 0.0
        Dim txtDestStNo As Single = 0.0
        Dim ss_cmbDestStName As Single = 0.0
        Dim sDestZip As Single = 0.0
        Dim sngBonus_AcctCarType(20) As String
        Dim sngTipsPerc_AcctCarType(20) As String
        Dim sngPriceMile_AcctCarType(20) As String
        Dim sngHrRate_AcctCarType(20) As String
        Dim bAcctCarType As Boolean
        Dim ss_cmbCarType As Single
        Dim ss_chkHrRate As Boolean
        Dim sngNoHours As Single
        sngNoHours = CSng(sngNoHours)
        Dim sPriceByMileage As String = "f"
        Dim iGraceReseyWT As Single
        Dim sngPricePerMile As Single
        sngPricePerMile = CSng(sngPricePerMile)
        Dim sngMileage As Single
        sngMileage = CSng(sngMileage)
        Dim sngMinPriceByMileage As Single
        sngMinPriceByMileage = CSng(sngMinPriceByMileage)
        Dim sngMinBaseRate As Single
        sngMinBaseRate = CSng(sngMinBaseRate)
        Dim pricing_table As Single
        Dim txtPuPriceZone As String
        Dim txtDestPriceZone As String
        Dim sngTipsPerc As Single
        sngTipsPerc = CSng(sngTipsPerc)
        Dim sNoTolls As String = "f"
        Dim sNoParking As String = "f"
        Dim sNoTips As String = "f"
        Dim sNoDiscount As String = "f"
        Dim sNoTollsCity As String = "f"
        Dim sNoParkingCity As String = "f"
        Dim sNoTipsCity As String = "f"
        Dim sNoDiscountCity As String = "f"
        Dim bAcctCityPricing As String
        'Dim IsAirport(8) As Boolean
        Dim IsAirport(8) As Boolean
        Dim sStateAirport(8) As String
        Dim sStopCounty(8) As String
        Dim sCityAirline(8) As String
        Dim sngDiscountPerc As Single
        '==Add by Daniel=======================
        Dim fp_curTolls As Single
        Dim fp_curParking As Single
        Dim fp_curTel As Single
        Dim fp_curM_G As Single
        Dim fp_curPackage As Single
        Dim fp_curOT As Single
        Dim fp_curTips As Single
        Dim fp_curDiscount As Single
        Dim fp_curSTC As Single
        Dim fp_curStops As Single
        Dim fp_curWT As Single
        Dim fp_curExpenses As Single
        Dim fp_curDeposit As Single
        Dim fp_intWTmin As Single
        'Dim PuPriceZone As String
        'Dim DPriceZone As String
        'Dim strCar_Type As Integer = CInt(IstrCar_type)
        Dim strPCounty_true As String = strPuCounty
        Dim strDCounty_true As String = strDestCounty
        Dim strRequestTime As String = Convert.ToString(DStrReqTime)
        Dim fp_curServiceFee As Single
        '======================================
        sngDiscountPerc = CSng(sngDiscountPerc)
        Dim iWTCharges(9) As Integer
        Dim sngWTChargePerHr As Single
        sngWTChargePerHr = CSng(sngWTChargePerHr)
        Dim sngSTCPerc As Single
        sngSTCPerc = CSng(sngSTCPerc)
        Dim sPriceByMilage As Single
        '-- 8/16 add
        Dim sngAM_Holiday_Surcharge As Single
        Dim sFrom_AM_Holiday_Surcharge As String = ""
        Dim sTo_AM_Holiday_Surcharge As String = ""
        Dim sngAM_Holiday_Surcharge2 As Single
        Dim sFrom_AM_Holiday_Surcharge2 As String = ""
        Dim sTo_AM_Holiday_Surcharge2 As String = ""
        Dim sReqTime As String
        Dim sReqDate As String = ""
        Dim bFoundInPriceTable As Boolean
        Dim iAirportWTCustomer As Integer
        Dim fp_sngDiscCertPerc As Single
        fp_sngDiscCertPerc = CSng(fp_sngDiscCertPerc)
        Dim sM_G As String
        Dim sngTipsPerc_Opr As Single
        sngTipsPerc_Opr = CSng(sngTipsPerc_Opr)
        Dim fp_curDiscCert As Single
        fp_curDiscCert = CSng(fp_curDiscCert)

        '##-- ASSIGN VARIABELES SET BY OPERATOR TABLE --##
        ss_chkHrRate = False
        fp_curTolls = 0.0
        fp_curParking = 0.0
        fp_curTel = 0.0
        fp_curM_G = 0.0
        sM_G = ""
        fp_curPackage = 0.0
        fp_curOT = 0.0
        fp_curTips = 0.0
        fp_curDiscount = 0.0
        fp_curSTC = 0.0
        fp_curStops = 0.0
        fp_curWT = 0.0
        fp_curExpenses = 0.0
        fp_curDeposit = 0.0
        fp_curDiscCert = WEB_DISCOUNT
        fp_intWTmin = 0.0
        fp_sngDiscCertPerc = 0.0
        sngTipsPerc_Opr = 0.0
        txtPuPriceZone = PuPriceZone
        txtDestPriceZone = DPriceZone
        ss_cmbCarType = strCar_type
        txtPuCountyTrue = strPCounty_true
        txtDestCountyTrue = strDCounty_true
        '-- 8/16/02
        If Convert.ToString(strRequestTime) <> "" Then
            sReqTime = Convert.ToString(FormatDateTime(Now, vbShortTime))
        Else
            sReqTime = Convert.ToString(FormatDateTime(CDate(strRequestTime), vbShortTime))
            'sReqTime = Format(rs("req_date_time"), "HH:MM")
        End If
        '##---------------------------------------------##
        Dim PricePerMile As Decimal = 0
        Dim sngCar_typePrice_per_mile As Decimal = 0
        Dim sngAccountPrice_per_mile As Decimal = 0
        Dim sngAccountCartypePrice_per_mile As Decimal = 0
        Dim strAccountprice_mileage As String = "0"
        '-- 8/16/02

        'If strRequestTime = "" Then
        '    sReqTime = CStr(FormatDateTime(Now, vbShortTime))
        '    sReqDate = DateValue(Now)
        'Else
        '    sReqTime = CStr(FormatDateTime(CDate(strRequestTime), vbShortTime))
        '    sReqDate = DateValue(CDate(strRequestTime))
        '    'sReqTime = Format(rs("req_date_time"), "HH:MM")
        'End If
        '##---------------------------------------------##
        Call LoadGeography()

        Dim SQLStr As String
        Dim Ds As DataSet
        SQLStr = "select min_price_by_mileage,min_base_rate from system_parameter(nolock) where company = '" & sqlsafe(strCompany) & "'"

        Ds = Me.QueryData(SQLStr, "price")

        If Not Ds Is Nothing Then
            If Ds.Tables("price").Rows.Count = 0 Then
                '**Response.Write "ERRORSQL0"
                sngMinPriceByMileage = 0.0
                sngMinBaseRate = 0.0
            Else
                '**call show_var("sngMinPriceByMileage",sngMinPriceByMileage,false)
                sngMinPriceByMileage = CSng(Val(Ds.Tables("price").Rows(0).Item("min_price_by_mileage").ToString))
                sngMinBaseRate = CSng(Val(Ds.Tables("price").Rows(0).Item("min_base_rate").ToString))
            End If
        Else
            sngMinPriceByMileage = 0.0
            sngMinBaseRate = 0.0
        End If
        
        Ds.Dispose()
        Ds = Nothing

        SQLStr = "select * from car_type(nolock) where car_type_id = '" & sqlsafe(strCar_type.ToString) & "'"
        Ds = Me.QueryData(SQLStr, "car_type")

        If Not Ds Is Nothing Then
            If Ds.Tables("car_type").Rows.Count = 0 Then
                '**Response.Write "ERRORSQL0"
                sngHrRate_tmp = 0.0
                sngBonus_tmp = 0.0
                sngTipsPerc_tmp = 0.0
                sngPricePerMile_tmp = 0.0
            Else
                '**call show_var("sngBonus_tmp",sngBonus_tmp,false)
                sngHrRate_tmp = CSng(Val(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("hr_rate")), "0.00", Ds.Tables(0).Rows(0).Item("hr_rate").ToString)))
                sngBonus_tmp = CSng(Val(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("bonus")), "0.00", Ds.Tables(0).Rows(0).Item("bonus")))))
                sngTipsPerc_tmp = CSng(Val(Trim(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("tips_perc")), "0.00", Ds.Tables(0).Rows(0).Item("tips_perc"))))))
                sngPricePerMile_tmp = CSng(Val(Trim(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("price_per_mile")), "0.00", Ds.Tables(0).Rows(0).Item("price_per_mile")))))) '-- 3/20/03 
            End If
        Else
            sngHrRate_tmp = 0.0
            sngBonus_tmp = 0.0
            sngTipsPerc_tmp = 0.0
            sngPricePerMile_tmp = 0.0
        End If
        
        Ds.Dispose()
        Ds = Nothing

        SQLStr = "select * from account(nolock) where company = '" & sqlsafe(strCompany) & "' and acct_id = '" & sqlsafe(strAcctId) & "' "
        SQLStr = SQLStr & " and sub_acct_id = '" & sqlsafe(strSubAcctId) & "'"

        Ds = Me.QueryData(SQLStr, "account")

        If Ds.Tables("account").Rows.Count = 0 Then
            '**Response.Write "ERROR0A"
        Else
            sPriceByMilage = CSng(Trim(Convert.ToString(Val(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("price_by_mileage_flag")), 0.0, Ds.Tables(0).Rows(0).Item("price_by_mileage_flag"))))))
            sngPricePerMile = CInt(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("price_per_mile")), "0", Ds.Tables(0).Rows(0).Item("price_per_mile")))
            pricing_table = CSng(Val(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("table_id")), "0", Ds.Tables(0).Rows(0).Item("table_id")))))
            sngDiscountPerc = CSng(Val(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("discount_perc")), "0.00", Ds.Tables(0).Rows(0).Item("discount_perc")))))
            sNoTolls = CStr(Val(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("no_tolls")), "f", Ds.Tables(0).Rows(0).Item("no_tolls")))))
            sNoParking = CStr(Trim(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("no_parking")), "f", Ds.Tables(0).Rows(0).Item("no_parking")))))
            sNoTips = CStr(Trim(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("no_tips")), "f", Ds.Tables(0).Rows(0).Item("no_tips")))))
            sNoDiscount = CStr(Trim(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("no_discount")), "f", Ds.Tables(0).Rows(0).Item("no_discount")))))
            'sngWTChargePerHr	= val(trim(convert.tostring(Ds.Tables(0).Rows(0).Item("WT_Charge_Per_Hr"))))	'-- 3/20/03
            sngTipsPerc = CSng(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("tip_perc")), "0.00", Ds.Tables(0).Rows(0).Item("tip_perc").ToString)))
            sngSTCPerc = CSng(Trim(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("STC_perc")), "0.00", Ds.Tables(0).Rows(0).Item("STC_perc")))))
            iGraceReseyWT = CSng(Trim(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("grace_resey_WT")), "0.00", Ds.Tables(0).Rows(0).Item("grace_resey_WT").ToString))))
            fp_curServiceFee = CSng(Trim(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("service_fee_A")), "0.00", Ds.Tables(0).Rows(0).Item("service_fee_A")))))
            '-- 8/16/02
            sngAM_Holiday_Surcharge = CSng(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("AM_Holiday_Surcharge")), 0.0, Ds.Tables(0).Rows(0).Item("AM_Holiday_Surcharge"))))
            sFrom_AM_Holiday_Surcharge = CStr(Trim(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("From_AM_Holiday_Surcharge")), "0:00", Ds.Tables(0).Rows(0).Item("From_AM_Holiday_Surcharge"))))) '--"0:00"
            sTo_AM_Holiday_Surcharge = CStr(Trim(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("To_AM_Holiday_Surcharge")), "0:00", Ds.Tables(0).Rows(0).Item("To_AM_Holiday_Surcharge")))))   '--"0:00"
            '-- 3/20/03
            sngAM_Holiday_Surcharge2 = CSng(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("AM_Holiday_Surcharge_2")), "0.00", Ds.Tables(0).Rows(0).Item("AM_Holiday_Surcharge_2").ToString)))
            sFrom_AM_Holiday_Surcharge2 = CStr(Trim(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("From_AM_Holiday_Surcharge_2")), "0", Ds.Tables(0).Rows(0).Item("From_AM_Holiday_Surcharge_2")))))
            sTo_AM_Holiday_Surcharge2 = CStr(Trim(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("To_AM_Holiday_Surcharge_2")), "0", Ds.Tables(0).Rows(0).Item("To_AM_Holiday_Surcharge_2")))))
            iAirportWTCustomer = CInt(Convert.ToString(IIf(IsDBNull(Ds.Tables(0).Rows(0).Item("airport_WT_cus")), 0, Ds.Tables(0).Rows(0).Item("airport_WT_cus").ToString)))
            '**call show_var("sPriceByMilage",sPriceByMilage,false)
            '**call show_var("sngPricePerMile",sngPricePerMile,false)
            '**call show_var("pricing_table",pricing_table,false)
            '**call show_var("sngDiscountPerc",sngDiscountPerc,false)
            '**call show_var("sNoTolls",sNoTolls,false)
            '**call show_var("sNoParking",sNoParking,false)
            '**call show_var("sNoTips",sNoTips,false)
            '**call show_var("sNoDiscount",sNoDiscount,false)
            '**call show_var("sngWTChargePerHr",sngWTChargePerHr,false)
            '**call show_var("sngTipsPerc",sngTipsPerc,false)
            '**call show_var("sngSTCPerc",sPriceByMilage,false)
            '**call show_var("iGraceReseyWT",iGraceReseyWT,false)
            '**call show_var("fp_curServiceFee",fp_curServiceFee,false)	
        End If
        Ds.Dispose()
        Ds = Nothing

        bAcctCarType = get_call_account_car_type(CInt(strCompany), strAcctId, strSubAcctId, sngBonus_AcctCarType, sngTipsPerc_AcctCarType, sngPriceMile_AcctCarType, sngHrRate_AcctCarType, 20)
        bAcctCityPricing = get_call_account_city_pricing(CInt(strCompany), strAcctId, strSubAcctId, PState, txtPuCountyTrue, PCity, DState, txtDestCountyTrue, DCity, sNoTollsCity, sNoParkingCity, sNoTipsCity, sNoDiscountCity)

        '-- 8/25/03 --
        If sngPricePerMile = 0 Then
            sngPricePerMile = sngPricePerMile_tmp
        End If

        If bAcctCarType Then
            '**Response.Write "strCar_Type:" & strCar_Type & "<br>"
            '**Response.Write "sngPriceMile_AcctCarType:" & sngPriceMile_AcctCarType(Val(strCar_Type)) & "<br>"
            '**Response.Write "sngTipsPerc_AcctCarType:" & sngTipsPerc_AcctCarType(Val(strCar_Type)) & "<br>"
            If CInt(sngPriceMile_AcctCarType(CInt(strCar_type))) > 0 Then
                sngPricePerMile = CInt(sngPriceMile_AcctCarType(CInt(strCar_type)))
            End If
            If CLng(sngTipsPerc_AcctCarType(CInt(strCar_type))) > 0 Then
                sngTipsPerc = CInt(sngPriceMile_AcctCarType(CInt(strCar_type)))
            End If
            If CInt(sngHrRate_AcctCarType(CInt(strCar_type))) > 0 Then
                sngHrRate_tmp = CInt(sngHrRate_AcctCarType(CInt(strCar_type)))
            End If
            If CLng(sngBonus_AcctCarType(CInt(strCar_type))) > 0 Then
                sngBonus_tmp = CInt(sngBonus_AcctCarType(CInt(strCar_type)))
            End If
        Else
            '-- if not in account table then to get Price/Mile from Car_type table
            '-- 8/25/03 removed. moved up.
            'if sngPricePerMile = 0 then sngPricePerMile = sngPricePerMile_tmp
        End If

        '**Response.Write "sngPricePerMile:" & sngPricePerMile & "<br>"
        '**Response.Write "IsAirport_SearchInTable(PState):" & IsAirport_SearchInTable(PState) & "<br>"
        '**Response.Write "IsAirport_SearchInTable(DState):" & IsAirport_SearchInTable(DState) & "<br>"

        If ss_chkHrRate Then
            '**Response.Write "*** PRICE BY HOUR RATE ***<br>"
            If sngNoHours = 0 Then
                'iErr = 2
                'Screen.MousePointer = vbDefault
                'Exit Function
                price_est = 0
                '**Response.Write "ERROR1"
            Else
                price_est = sngNoHours * sngHrRate_tmp
                price_est = CSng(price_est * 100) / 100
            End If

        ElseIf sPriceByMileage = "t" And sngPricePerMile > 0 And Not IsAirport_SearchInTable(PState) And Not IsAirport_SearchInTable(DState) Then
            '**Response.Write "*** PRICE BY MILAGE ***<br>"

            sPuAddr = get_call_addr_string(PState, PCity, PStrNo, PStrName, PZipCode, iPuErr)
            sDestAddr = get_call_addr_string(DState, DCity, DStrNo, DStrName, DZipCode, iDestErr)
            If iPuErr <= 1 And iDestErr <= 1 Then
                sngMileage = 0
                sngMileage = StrMileage 'get_mileage(sPuAddr, sDestAddr, iPuErr, iDestErr)
            End If
            ' iPuErr = -2 means PuAddr is absent
            ' iPuErr = -1 means PuAddr not found
            ' iPuErr = 5 means ZIP is required
            ' iPuErr = 0 means PuAddr found
            price_est = CSng(IIf(sngMileage > 0, sngMileage * sngPricePerMile, 0))
            If price_est > 0 And price_est < sngMinPriceByMileage Then
                price_est = sngMinPriceByMileage
            End If
            If price_est > 0 Then
                price_est = CSng((price_est + sngBonus_tmp) * 100) / 100
            End If
        Else ' if gsPriceByMileage <> "t" then calculate price in a standard way
            '**Response.Write "*** PRICE BY OTHER ***<br>"
            temp_price = "0.00"       'clear price

            '------ Start 3/20/03 New ------
            j = update_price_book_by_account(CInt(strCar_type), CInt(strCompany), strAcctId, strSubAcctId, CInt(pricing_table))

            If j > 0 Then
                pricing_table = j
                temp_price = get_call_city_to_city_pricing(CInt(pricing_table), PState, txtPuCountyTrue, PCity, DState, txtDestCountyTrue, DCity, CInt(strCompany), strAcctId, strSubAcctId, txtPuPriceZone, txtDestPriceZone, bFoundInPriceTable, fp_curTolls)
                '**call show_var("temp_price",temp_price,false)
            Else
                temp_price = "0.00"
            End If

            If IsNumeric(temp_price) And Val(temp_price) > 0 Then
                price_est = CSng((Val(temp_price) + sngBonus_tmp) * 100) / 100
            Else
                price_est = 0
            End If
            '------ End 3/20/03 New ------

            If price_est = 0 And sngPricePerMile > 0 Then
                sPuAddr = get_call_addr_string(PState, PCity, PStrNo, PStrName, PZipCode, iPuErr)
                sDestAddr = get_call_addr_string(DState, DCity, DStrNo, DStrName, DZipCode, iDestErr)

                '**Response.Write "sPuAddr:"&sPuAddr&"<br>"
                '**Response.Write "sDestAddr:"&sDestAddr&"<br>"

                If iPuErr <= 1 And iDestErr <= 1 Then
                    sngMileage = 0
                    sngMileage = StrMileage
                    'sngMileage = get_mileage(sPuAddr, sDestAddr, iPuErr, iDestErr)
                End If
                ' iPuErr = -2 means PuAddr is absent
                ' iPuErr = -1 means PuAddr not found
                ' iPuErr = 5 means ZIP is required
                ' iPuErr = 0 means PuAddr found

                '**Response.Write "sngMileage:"&sngMileage&"<br>"

                price_est = CSng(IIf(sngMileage > 0, sngMileage * sngPricePerMile, 0))

                '**call show_var("price_est",price_est,false)
                '**call show_var("sngBonus_tmp",sngBonus_tmp,false)
                '**Response.Write "price_est + sngBonus_tmp:" & csng(price_est) &"+"& csng(sngBonus_tmp) & "<br>"

                '**Response.Write "price_est ():" & price_est & "<br>"
                '**call show_var("sngMinPriceByMileage",sngMinPriceByMileage,false)
                If price_est > 0 And CSng(price_est) < CSng(sngMinPriceByMileage) Then
                    '**Response.Write "price_est > 0 And price_est < sngMinPriceByMileage TRUE"
                    price_est = sngMinPriceByMileage
                End If
                If price_est > 0 Then
                    price_est = CSng((CSng(price_est) + CSng(sngBonus_tmp)) * 100) / 100
                End If

                '**Response.Write "Price(): " & price_est
            End If

            '-- 8/2503. New code --
            If price_est > 0 And price_est < sngMinBaseRate Then
                price_est = sngMinBaseRate
            End If

            sngBasicRate = price_est
            If sngBasicRate > 0 Then
                fp_curTolls = CSng(get_call_est_tolls(fp_curTolls, bFoundInPriceTable, PState, PCity, DState, DCity, sNoTolls))
                fp_curParking = CSng(get_call_est_parking(PState, CStr(Check_DBNULL(sNoParking))))
                fp_curStops = CSng(get_call_est_stops(ss_chkHrRate, PState, txtPuCountyTrue, PCity, DState, txtDestCountyTrue, DCity, sStateAirport, sStopCounty, sCityAirline, IsAirport))
                fp_curWT = CSng(get_call_est_WT_charges(CInt(strCompany), iAirportWTCustomer, PState, ss_chkHrRate, iWTCharges, sngWTChargePerHr, CInt(Check_DBNULL(iGraceReseyWT)), CInt(Check_DBNULL(fp_intWTmin))))
                fp_curOT = CSng(get_call_est_OT_charges(CInt(strCompany), strAcctId, strSubAcctId, sngAM_Holiday_Surcharge, sFrom_AM_Holiday_Surcharge, sTo_AM_Holiday_Surcharge, sngAM_Holiday_Surcharge2, sFrom_AM_Holiday_Surcharge2, sTo_AM_Holiday_Surcharge2, sReqTime, sReqDate)) '-- 8/16/02 updated 8/20/03
                fp_curTips = CSng(get_call_est_tips(sngBasicRate, fp_curStops, fp_curWT, fp_curOT, sngTipsPerc, sngTipsPerc_tmp, sngTipsPerc_Opr, sNoTips))
                fp_curSTC = CSng(get_call_est_STC(sngBasicRate, fp_curStops, fp_curWT, fp_curOT, sngSTCPerc))
                fp_curDiscount = CSng(get_call_est_discount(sngBasicRate, fp_curStops, fp_curWT, fp_curOT, sngDiscountPerc, CStr(Check_DBNULL(sNoDiscount))))
                '-- Start New 03/20/03 --
                'fp_curDiscCert = Clng(fp_sngDiscCertPerc * sngBasicRate) / 100  ' disabled 7/7/03

                Me.Base_rate = Convert.ToDecimal(Check_DBNULL(sngBasicRate))
                Me.Mileage = Convert.ToSingle(Check_DBNULL(sngMileage))
                Me.Tool_Charges = Convert.ToDecimal(Check_DBNULL(fp_curTolls))
                Me.Park_Charges = Convert.ToDecimal(Check_DBNULL(fp_curParking))
                Me.Stops_Charges = Convert.ToDecimal(Check_DBNULL(fp_curStops))
                Me.WT_Charges = Convert.ToDecimal(Check_DBNULL(fp_curWT))
                Me.Tel_charges = Convert.ToString(Check_DBNULL(fp_curTel))
                Me.M_G_charges = Convert.ToDecimal(Check_DBNULL(fp_curM_G))
                Me.Package_Charges = Convert.ToString(Check_DBNULL(fp_curPackage))
                Me.OT_Charges = Convert.ToDecimal(Check_DBNULL(fp_curOT))
                Me.Tips_Charges = Convert.ToDecimal(Check_DBNULL(fp_curTips))
                Me.Discount_Charges = Convert.ToDecimal(Check_DBNULL(fp_curDiscount))
                Me.STC_Charges = Convert.ToDecimal(Check_DBNULL(fp_curSTC))
                Me.Service_Charges = Convert.ToDecimal(Check_DBNULL(fp_curServiceFee))

                If sM_G <> "Y" Then fp_curM_G = 0

                '-- End   New 03/20/03 --
                If ss_chkHrRate Then
                    '**Response.Write sngBasicRate &"+"& fp_curTolls &"+"& fp_curParking &"+"& fp_curTel &"+"& fp_curM_G &"+"& fp_curPackage &"+"& fp_curOT &"+"& fp_curTips &"-"& fp_curDiscount &"+"& fp_curSTC &"+"& fp_curServiceFee &"<br>"
                    price_est = CSng((sngBasicRate + fp_curTolls + fp_curParking + fp_curTel + fp_curM_G + fp_curPackage + fp_curOT + fp_curTips - fp_curDiscount - fp_curDiscCert + +fp_curSTC + fp_curServiceFee + fp_curExpenses - fp_curDeposit) * 100) / 100
                Else
                    '-- old
                    '**Response.write sngBasicRate &"+"& fp_curTolls &"+"& fp_curParking &"+"& fp_curTel &"+"& fp_curM_G &"+"& fp_curPackage &"+"& fp_curOT &"+"& fp_curTips &"-"& fp_curDiscount &"+"& fp_curSTC &"+"& fp_curStops &"+"& fp_curWT &"+"& fp_curServiceFee &"<br>"
                    'price_est = CLng((sngBasicRate + fp_curTolls + fp_curParking + fp_curTel + fp_curM_G + fp_curPackage + fp_curOT + fp_curTips - fp_curDiscount + fp_curSTC + fp_curStops + fp_curWT + fp_curServiceFee) * 100) / 100
                    '-- new 03/20/03
                    price_est = CSng((sngBasicRate + fp_curTolls + fp_curParking + fp_curStops + fp_curWT + fp_curTel + fp_curM_G + fp_curPackage + fp_curOT + fp_curTips - fp_curDiscount - fp_curDiscCert + fp_curSTC + fp_curServiceFee + fp_curExpenses - fp_curDeposit) * 100) / 100
                End If
            Else
                get_price = 0
            End If
            '**call show_var("sngBasicRate",sngBasicRate,false)
            '**call show_var("fp_curTolls",fp_curTolls,false)
            '**call show_var("fp_curParking",fp_curParking,false)
            '**call show_var("fp_curStops",fp_curStops,false)
            '**call show_var("fp_curWT",fp_curWT,false)
            '**call show_var("fp_curTel",fp_curTel,false)
            '**call show_var("fp_curM_G",fp_curM_G,false)
            '**call show_var("fp_curPackage",fp_curPackage,false)
            '**call show_var("fp_curOT",fp_curOT,false)
            '**call show_var("fp_curTips",fp_curTips,false)
            '**call show_var("fp_curDiscount",fp_curDiscount,false)
            '**call show_var("fp_curSTC",fp_curSTC,false)
            '**Response.Write "FINAL Price: " & price_est
        End If
        get_price = price_est

    End Function

    '------------------------------------------------------------------------------
    '-- function get_call_account_car_type -- 3/20/03
    '------------------------------------------------------------------------------
    Function get_call_account_car_type(ByVal sComp As Integer, ByVal sAcctNo As String, ByVal sSubAcctNo As String, ByRef sngBonus_AcctCarType() As String, ByRef sngTipsPerc_AcctCarType() As String, ByRef sngPriceMile_AcctCarType() As String, ByRef sngHrRate_AcctCarType() As String, ByVal iSize As Integer) As Boolean
        Dim sSQL As String
        Dim rs As DataSet
        Dim i As Integer
        Dim bAcctCarType As Boolean

        For i = 0 To iSize
            sngBonus_AcctCarType(i) = "0"
            sngTipsPerc_AcctCarType(i) = "0"
            sngPriceMile_AcctCarType(i) = "0"
            sngHrRate_AcctCarType(i) = "0"
        Next
        bAcctCarType = False
        sSQL = "SELECT * FROM Account_Car_Type(NOLOCK) WHERE company=" & sComp & " and acct_id='" & sqlsafe(sAcctNo) & "' and sub_acct_id='" & sqlsafe(sSubAcctNo) & "' order by car_type_id"
        rs = Me.QueryData(sSQL, "Account_Car_Type")
        If rs.Tables("Account_Car_Type").Rows.Count > 0 Then
            Dim j As Integer
            Do While j < rs.Tables("Account_Car_Type").Rows.Count
                bAcctCarType = True

                sngBonus_AcctCarType(CInt(rs.Tables(0).Rows(j).Item("car_type_id"))) = Convert.ToString(IIf(IsNull(Convert.ToString(rs.Tables(0).Rows(j).Item("bonus"))) = True, "0", Convert.ToString(rs.Tables(0).Rows(j).Item("bonus"))))
                sngTipsPerc_AcctCarType(CInt(rs.Tables(0).Rows(j).Item("car_type_id"))) = Convert.ToString(IIf(IsNull(Convert.ToString(rs.Tables(0).Rows(j).Item("tips_perc"))), 0, Convert.ToString(rs.Tables(0).Rows(j).Item("tips_perc"))))
                sngPriceMile_AcctCarType(CInt(rs.Tables(0).Rows(j).Item("car_type_id"))) = Convert.ToString(IIf(IsNull(Convert.ToString(rs.Tables(0).Rows(j).Item("price_per_mile"))), 0, Convert.ToString(rs.Tables(0).Rows(j).Item("price_per_mile"))))
                sngHrRate_AcctCarType(CInt(rs.Tables(0).Rows(j).Item("car_type_id"))) = Convert.ToString(IIf(IsNull(Convert.ToString(rs.Tables(0).Rows(j).Item("hr_rate"))), 0, Convert.ToString(rs.Tables(0).Rows(j).Item("hr_rate"))))
                'rs.MoveNext()
                j = j + 1
            Loop
        End If
        rs.Dispose()
        rs = Nothing
        get_call_account_car_type = bAcctCarType
    End Function
    '------------------------------------------------------------------------------
    '-- function IIf -- 3/20/03
    '------------------------------------------------------------------------------
    'Function IIf(ByVal bol_value As VariantType, ByVal value1 As VariantType, ByVal value2 As VariantType) As VariantType
    '    If bol_value = True Then
    '        IIf = value1
    '    ElseIf bol_value = False Then
    '        IIf = value2
    '    End If
    'End Function
    '------------------------------------------------------------------------------
    '-- function Val -- 3/20/03
    '------------------------------------------------------------------------------
    'Function Val(ByVal sInput As VariantType) As Double
    '    Dim re, tmpVal

    '    If isnull(sInput) Then
    '        Val = 0
    '        Exit Function
    '    End If
    '    If sInput = "" Then
    '        Val = 0
    '        Exit Function
    '    End If

    '    'set re = new regexp 
    '    're.pattern = "[^\d]" 
    '    're.global = true 
    '    'Val = re.replace(sInput, "") 
    '    Val = sInput
    'End Function
    '------------------------------------------------------------------------------
    '-- function get_call_account_city_pricing -- 4/25/06
    '------------------------------------------------------------------------------
    Function get_call_account_city_pricing(ByVal sComp As Integer, ByVal sAcctNo As String, ByVal sSubAcctNo As String, ByVal sPuState As String, ByVal sPuCounty As String, ByVal sPuCity As String, ByVal sDestState As String, ByVal sDestCounty As String, ByVal sDestCity As String, ByRef sNoTolls As String, ByRef sNoParking As String, ByRef sNoTips As String, ByRef sNoDiscount As String) As String
        Dim sSQL, ssPuState, ssPuCity, ssDestState, ssDestCity, ssCity, ssState As String
        Dim sNoTollsCity, sNoParkingCity, sNoTipsCity, sNoDiscountCity As String
        Dim rs As DataSet

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
        sSQL = sSQL & "WHERE company=" & sComp & " and acct_id='" & sqlsafe(sAcctNo) & "' and sub_acct_id='" & sqlsafe(sSubAcctNo) & "'"
        sSQL = sSQL & " and (state='" & sqlsafe(sDestState) & "' and county='" & sqlsafe(sDestCounty) & "' and city='" & sqlsafe(sDestCity) & "'"
        sSQL = sSQL & " OR state='" & sqlsafe(sPuState) & "' and county='" & sqlsafe(sPuCounty) & "' and city='" & sqlsafe(sPuCity) & "')"
        'Else
        '  Exit Function
        'End If
        rs = Me.QueryData(sSQL, "Account_City_Pricing")
        If rs.Tables("Account_City_Pricing").Rows.Count > 0 Then
            Dim i As Integer = 0
            Do While i < rs.Tables("Account_City_Pricing").Rows.Count

                If sNoTollsCity <> "t" Then sNoTollsCity = Trim("" & Convert.ToString(rs.Tables(0).Rows(i).Item("No_tolls")))
                If sNoParkingCity <> "t" Then sNoParkingCity = Trim("" & Convert.ToString(rs.Tables(0).Rows(i).Item("No_parking")))
                If sNoTipsCity <> "t" Then sNoTipsCity = Trim("" & Convert.ToString(rs.Tables(0).Rows(i).Item("No_tips")))
                If sNoDiscountCity <> "t" Then sNoDiscountCity = Trim("" & Convert.ToString(rs.Tables(i).Rows(0).Item("No_discount")))
                'rs.MoveNext()
                i = i + 1
            Loop
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
    '------------------------------------------------------------------------------
    '-- Function get_city_by_boro -- 3/20/03
    '------------------------------------------------------------------------------
    Function get_city_by_boro(ByVal sBorough As String, ByVal sCity As String, ByVal sState As String) As Boolean
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
    '------------------------------------------------------------------------------
    '-- Function IsAirport_SearchInTable -- 3/20/03
    '------------------------------------------------------------------------------
    Function IsAirport_SearchInTable(ByVal s As String) As Boolean
        'Dim rs
        '	Set rs = objConn.Execute("SELECT n=count(*) FROM County_State_Airport(NOLOCK) WHERE code='" & s & "'")
        '	If rs("n") > 0 Then IsAirport_SearchInTable = True Else IsAirport_SearchInTable = False
        '	rs.Close : set rs = nothing
        Dim i As Integer
        i = 0

        IsAirport_SearchInTable = False
        Try
            Do While gsAirport(i) <> ""
                If gsAirport(i) = Trim(s) Then
                    IsAirport_SearchInTable = True
                    Exit Do
                End If
                i = i + 1
            Loop
            IsAirport_SearchInTable = True

        Catch ex As Exception
            IsAirport_SearchInTable = False

        End Try

    End Function
    '------------------------------------------------------------------------------
    '--
    '------------------------------------------------------------------------------
    Function get_call_city_pricing(ByVal sComp As Integer, ByVal sAcct As String, ByVal sSubAcct As String, ByVal State As String, ByVal County As String, ByVal town As String, ByVal borough As String, ByVal pricing_table As Integer) As String
        Dim sql_string As String
        Dim rdofind As DataSet
        get_call_city_pricing = "0.00"
        ' search special price by account
        sql_string = "select price_1,price_2,price_3,price_4,price_5,price_6,price_7,price_8 from Account_city_pricing(NOLOCK) where company=" & sComp & " and acct_id= '" & sqlsafe(sAcct) & "' and sub_acct_id= '" & sqlsafe(sSubAcct) & "' and state = '" & sqlsafe(State) & "' and city = '" & sqlsafe(town) & "' and county = '" & sqlsafe(County) & "'"
        'rdofind = objConn.Execute(sql_string)
        rdofind = Me.QueryData(sql_string, "account_city_pricing")

        If rdofind.Tables("Account_City_Pricing").Rows.Count > 0 Then
            Select Case Trim(borough)
                Case "EPS"
                    get_call_city_pricing = "" & Trim(rdofind.Tables(0).Rows(0).Item("price_8").ToString)
                Case "JC"
                    get_call_city_pricing = "" & rdofind.Tables(0).Rows(0).Item("price_7").ToString
                Case "M", "QU", "BK", "BX", "SI"
                    get_call_city_pricing = "" & rdofind.Tables(0).Rows(0).Item("price_6").ToString
                Case "STW"
                    get_call_city_pricing = "" & rdofind.Tables(0).Rows(0).Item("price_5").ToString
                Case "WCP"
                    get_call_city_pricing = "" & rdofind.Tables(0).Rows(0).Item("price_4").ToString
                Case "JFK"
                    get_call_city_pricing = "" & rdofind.Tables(0).Rows(0).Item("price_3").ToString
                Case "LGA"
                    get_call_city_pricing = "" & rdofind.Tables(0).Rows(0).Item("price_2").ToString
                Case "EWR"
                    get_call_city_pricing = "" & rdofind.Tables(0).Rows(0).Item("price_1").ToString
            End Select
        End If
        rdofind.Dispose() : rdofind = Nothing
        If Val(get_call_city_pricing) = 0 Then ' take the price from city_pricing table
            sql_string = "select price_1,price_2,price_3,price_4,price_5,price_6,price_7,price_8 from city(NOLOCK),city_pricing_table(NOLOCK) where city_pricing_table.pricing_table = " & pricing_table & " and state = '" & sqlsafe(State) & "' and county = '" & sqlsafe(County) & "' and name = '" & sqlsafe(town) & "' and city.pricing_table_counter *= city_pricing_table.pricing_table_counter"
            'rdofind = objConn.Execute(sql_string)
            rdofind = Me.QueryData(sql_string, "city_citypricing_table")
            '**Response.Write "*<i>from get_call_city_pricing()</i>" & sql_string & "<br>"
            If rdofind.Tables("Account_City_Pricing").Rows.Count > 0 Then
                Select Case Trim(borough)
                    Case "EPS"
                        get_call_city_pricing = "" & rdofind.Tables(0).Rows(0).Item("price_8").ToString
                    Case "JC"
                        get_call_city_pricing = "" & rdofind.Tables(0).Rows(0).Item("price_7").ToString
                    Case "M", "QU", "BK", "BX", "SI"
                        get_call_city_pricing = "" & rdofind.Tables(0).Rows(0).Item("price_6").ToString
                    Case "STW"
                        get_call_city_pricing = "" & rdofind.Tables(0).Rows(0).Item("price_5").ToString
                    Case "WCP"
                        get_call_city_pricing = "" & rdofind.Tables(0).Rows(0).Item("price_4").ToString
                    Case "JFK"
                        get_call_city_pricing = "" & rdofind.Tables(0).Rows(0).Item("price_3").ToString
                    Case "LGA"
                        get_call_city_pricing = "" & rdofind.Tables(0).Rows(0).Item("price_2").ToString
                    Case "EWR"
                        get_call_city_pricing = "" & rdofind.Tables(0).Rows(0).Item("price_1").ToString
                End Select
            End If
            rdofind.Dispose() : rdofind = Nothing
        End If
    End Function
    '------------------------------------------------------------------------------
    '-- Function get_call_est_tolls -- 3/20/2003
    '------------------------------------------------------------------------------
    Function get_call_est_tolls(ByVal fp_curTolls As Single, ByVal bFoundInPriceTable As Boolean, ByVal PuCounty As String, ByVal PuCity As String, ByVal DestCounty As String, ByVal DestCity As String, ByVal sNoTolls As String) As Single
        Dim i, j As Integer
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
            '-- start new 3/20/03 --
            If PuCounty = "NY" And i <> 1 Then ' NY but not boro  
                i = 6
            End If
            '-- end   new 3/20/03 --

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

            '-- start new 3/20/03 --
            If DestCounty = "NY" And i <> 1 Then ' NY but not boro  
                j = 6
            End If
            '-- end   new 3/20/03 --

            If j = -1 And DestCounty = "NJ" Then
                j = 0
            End If
            If i < 0 Or j < 0 Then
                '-- start new 03/20/03 --
                If i = 3 Or i = 4 Or j = 3 Or j = 4 Then ' PU or Dest in LGA or JFK
                    get_call_est_tolls = 16.5
                Else
                    get_call_est_tolls = 0
                End If
                Exit Function
                '-- end   new 03/20/03 --
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
    '------------------------------------------------------------------------------
    '-- Function get_call_est_parking -- 3/20/03
    '------------------------------------------------------------------------------
    Function get_call_est_parking(ByVal PuCounty As String, ByVal sNoParking As String) As Single
        Dim vInd As Integer
        If IsAirport_SearchInTable(PuCounty) Then
            Dim i As Integer
            i = 0
            'IsAirport_SearchInTable = false
            Do While gsAirport(i) <> ""
                If gsAirport(i) = Trim(PuCounty) Then
                    'IsAirport_SearchInTable = true
                    vInd = i
                    Exit Do
                End If
                i = i + 1
            Loop

            Try
                get_call_est_parking = CSng(IIf(gsngAirportParking(vInd) = "", 0, gsngAirportParking(vInd)))
            Catch ex As Exception
                get_call_est_parking = 0
            End Try
        Else
            get_call_est_parking = 0
        End If
        If sNoParking = "t" Then get_call_est_parking = 0
    End Function
    '------------------------------------------------------------------------------
    '-- Function get_call_est_stops - 03/20/03
    '------------------------------------------------------------------------------
    Function get_call_est_stops(ByVal ss_chkHrRate As Boolean, ByVal sPuCounty As String, ByVal sPuCountyTrue As String, ByVal sPuCity As String, ByVal sDestCounty As String, ByVal sDestCountyTrue As String, ByVal sDestCity As String, ByVal sStateAirport() As String, ByVal sStopCounty() As String, ByVal sCityAirline() As String, ByVal IsAirport() As Boolean) As Single
        Dim i, iStopsCount As Integer
        Dim PuState, PuCounty, PuCity As String
        Dim DestState, DestCounty, DestCity As String
        Dim StopState, StopCounty, StopCity As String
        get_call_est_stops = 0
        If ss_chkHrRate = True Then Exit Function
        If Not IsAirport_SearchInTable(sPuCounty) Then
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
        If Not IsAirport_SearchInTable(sDestCounty) Then
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
            If sStateAirport(i) <> "" And Not IsAirport(i) Then
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
                            get_call_est_stops = get_call_est_stops + 10
                        Else
                            get_call_est_stops = get_call_est_stops + 15
                        End If
                    Else
                        get_call_est_stops = get_call_est_stops + 20
                    End If
                Else
                    get_call_est_stops = 0
                End If
            End If
        Next
        If iStopsCount > 1 Then get_call_est_stops = 0
    End Function
    '------------------------------------------------------------------------------
    '--
    '------------------------------------------------------------------------------
    Function get_city_county(ByVal sST As String, ByVal sCity As String) As String
        Dim rs As DataSet
        get_city_county = ""
        If sST <> "" And sCity <> "" Then
            'rs = cn.OpenResultset("select county from City(Nolock) where state= '" & sqlsafe(sST) & "' and name= '" & sqlsafe(sCity) & "'", rdOpenForwardOnly, rdConcurReadOnly)
            rs = Me.QueryData("select county from City(Nolock) where state= '" & sqlsafe(sST) & "' and name= '" & sqlsafe(sCity) & "'", "City")

            If rs.Tables(0).Rows.Count > 0 Then
                get_city_county = Trim("" & rs.Tables(0).Rows(0).Item("county").ToString)
            End If
            rs.Dispose() : rs = Nothing
        End If
    End Function
    '-- Function get_call_est_discount -- 03/20/03
    '------------------------------------------------------------------------------
    Function get_call_est_discount(ByVal sngBasicRate As Single, ByVal fp_curStops As Single, ByVal fp_curWT As Single, ByVal fp_curOT As Single, ByVal sngDiscountPerc As Single, ByVal sNoDiscount As String) As Single
        Dim tmpValue As String
        tmpValue = CStr((sngBasicRate) * sngDiscountPerc / 100)
        If Not IsNull(tmpValue) Then
            Try
                get_call_est_discount = CSng(tmpValue)
            Catch ex As Exception
                get_call_est_discount = 0.0
            End Try
        Else
            get_call_est_discount = 0.0
        End If

        'get_call_est_discount = Val(sngBasicRate + fp_curStops + fp_curWT + fp_curOT) * sngDiscountPerc / 100
        If sNoDiscount = "t" Then get_call_est_discount = 0
    End Function
    '------------------------------------------------------------------------------
    '-- Function get_call_est_WT_charges -- 03/20/03
    '------------------------------------------------------------------------------
    Function get_call_est_WT_charges(ByVal cmp As Integer, ByVal iAirportWTCustomer As Integer, ByVal ss_cmbPuCounty As String, ByVal ss_chkHrRate As Boolean, ByVal iWT() As Integer, ByVal sngWTChargePerHr As Single, ByVal iGraceReseyWT As Integer, ByVal iWTMinAdd As Integer) As Single
        Dim i As Integer
        Dim iWTMinTotal As Single
        Dim sngPricePerHour As String
        Dim iGracePeriod As Integer

        get_call_est_WT_charges = 0
        iWTMinTotal = 0
        If ss_chkHrRate = False Then
            For i = 0 To 9
                iWTMinTotal = iWTMinTotal + iWT(i)
            Next
        End If
        iWTMinTotal = iWTMinTotal + WT_min_correction(cmp, iWTMinAdd, IsAirport_SearchInTable(ss_cmbPuCounty))

        If IsAirport_SearchInTable(ss_cmbPuCounty) Then
            iGracePeriod = iAirportWTCustomer
        Else
            iGracePeriod = iGraceReseyWT
        End If

        iWTMinTotal = CSng(IIf(iWTMinTotal - iGracePeriod > 0, iWTMinTotal - iGracePeriod, 0))


        get_call_est_WT_charges = CSng((iWTMinTotal * sngWTChargePerHr / 60) * 100) / 100
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
    '------------------------------------------------------------------------------
    '-- Function get_call_est_tips - 03/20/03
    '------------------------------------------------------------------------------
    Function get_call_est_tips(ByVal sngBasicRate As Single, ByVal fp_curStops As Single, ByVal fp_curWT As Single, ByVal fp_curOT As Single, ByVal sngTipsPerc As Single, ByVal sngTipsPercCarType As Single, ByVal sngTipsPerc_Opr As Single, ByVal sNoTips As String) As Single

        If sngTipsPerc_Opr > 0 Then
            get_call_est_tips = (sngBasicRate + fp_curStops + fp_curWT + fp_curOT) * sngTipsPerc_Opr / 100
        Else
            get_call_est_tips = (sngBasicRate + fp_curStops + fp_curWT + fp_curOT) * CSng(IIf(sngTipsPerc = 0, sngTipsPercCarType, sngTipsPerc)) / 100
        End If
        If sNoTips = "t" Then get_call_est_tips = 0

    End Function
    '------------------------------------------------------------------------------
    '-- Function get_call_est_STC -- 03/20/03
    '------------------------------------------------------------------------------
    Function get_call_est_STC(ByVal sngBasicRate As Single, ByVal fp_curStops As Single, ByVal fp_curWT As Single, ByVal fp_curOT As Single, ByVal sngSTCPerc As Single) As Single
        get_call_est_STC = CSng(sngBasicRate + fp_curStops + fp_curWT + fp_curOT) * sngSTCPerc / 100
    End Function
    '------------------------------------------------------------------------------
    '-- Function get_call_addr_string -- 3/20/03
    '------------------------------------------------------------------------------
    Function get_call_addr_string(ByVal sCounty As String, ByVal sCity As String, ByVal sStNo As String, ByVal sStName As String, ByVal sZip As String, ByRef iErrCode As Integer) As String
        Dim ssCity, ssState As String
        get_call_addr_string = "" : iErrCode = 0
        If IsAirport_SearchInTable(sCounty) Then
            get_call_addr_string = Trim(sCounty) ' airport code
        Else
            If Trim(sStNo) <> "" Then
                get_call_addr_string = get_call_addr_string & Trim(sStNo)
                If Trim(sStName) <> "" Then
                    get_call_addr_string = get_call_addr_string & " " & Trim(sStName)
                    If Trim(sCity) <> "" Then
                        get_call_addr_string = get_call_addr_string & "," & Trim(sCity)
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
    '------------------------------------------------------------------------------
    '-- function get_state_by_boro -- 3/20/03
    '------------------------------------------------------------------------------
    Function get_state_by_boro(ByVal sBorough As String) As String
        get_state_by_boro = sBorough
        Select Case sBorough
            Case "LI", "WE", "M", "BK", "BX", "QU", "SI"
                get_state_by_boro = "NY"
        End Select
    End Function
    '------------------------------------------------------------------------------
    '-- Debugging function -- 3/20/03
    '------------------------------------------------------------------------------
    'Function show_var(ByVal desc As VariantType, ByVal variable As VariantType, ByVal bolend As Boolean) As String
    '    Response.Write(desc & ":" & variable & "<br>")
    '    If bolend = True Then
    '        Response.End()
    '    End If
    'End Function
    '------------------------------------------------------------------------------
    '-- Sub LoadGeography()
    '------------------------------------------------------------------------------
    Sub LoadGeography()
        Dim i As Integer
        Dim SQLStr As String
        Dim dr As DataSet
        SQLStr = "Select * from County_State_Town(nolock) order by type_pos,code_pos"
        dr = Me.QueryData(SQLStr, "County_State_Town")
        i = 0
        Try
            If dr.Tables(0).Rows.Count > 0 Then
                Do While i < dr.Tables(0).Rows.Count
                    gsLocalCounty(i) = Trim("" & Convert.ToString(dr.Tables(0).Rows(i).Item("code")))
                    gsLocalCountyDesc(i) = Trim("" & Convert.ToString(dr.Tables(0).Rows(i).Item("description")))
                    gsLocalCountyState(i) = Trim("" & Convert.ToString(dr.Tables(0).Rows(i).Item("type")))
                    'dr.MoveNext()
                    i = i + 1
                Loop
            End If
        Catch ex As Exception

        End Try
        dr.Dispose()
        dr = Nothing
        SQLStr = "Select * from County_State_OT(nolock) order by type_pos,code_pos"
        dr = Me.QueryData(SQLStr, "County_State_OT")
        i = 0
        Try
            If dr.Tables(0).Rows.Count > 0 Then
                Do While i < dr.Tables(0).Rows.Count
                    gsStateOT(i) = Trim("" & Convert.ToString(dr.Tables(0).Rows(i).Item("code")))
                    gsStateOTDesc(i) = Trim("" & Convert.ToString(dr.Tables(0).Rows(i).Item("description")))
                    'dr.MoveNext()
                    i = i + 1
                Loop
            End If
        Catch ex As Exception

        End Try
        dr.Dispose()
        dr = Nothing
        SQLStr = "Select * from County_State_Airport order by type_pos,code_pos,code"
        dr = Me.QueryData(SQLStr, "County_State_Airport")
        i = 0
        Try
            If dr.Tables(0).Rows.Count > 0 Then
                Do While i < dr.Tables(0).Rows.Count
                    gsAirport(i) = Trim("" & Convert.ToString(dr.Tables(0).Rows(i).Item("code")))
                    gsAirportDesc(i) = Trim("" & Convert.ToString(dr.Tables(0).Rows(i).Item("description")))
                    gsngAirportParking(i) = Trim("" & Convert.ToString(dr.Tables(0).Rows(i).Item("parking_charge")))
                    'dr.MoveNext()
                    i = i + 1
                Loop
            End If
        Catch ex As Exception

        End Try
        dr.Dispose()
        dr = Nothing
    End Sub
    '------------------------------------------------------------------------------
    '-- Function IsBoro -- 3/20/03
    '------------------------------------------------------------------------------
    Function IsBoro(ByVal boro As String) As Boolean
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
    '------------------------------------------------------------------------------
    '-- Function BoroughToState(boro) -- 3/20/03
    '------------------------------------------------------------------------------
    Function BoroughToState(ByVal boro As String) As String
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
    '------------------------------------------------------------------------------
    '-- Function BoroughToCity(boro) -- 3/20/03
    '------------------------------------------------------------------------------
    Function BoroughToCity(ByVal boro As String) As String
        Dim i As Integer
        i = 0 : BoroughToCity = ""
        Do While gsLocalCounty(i) <> ""
            If Trim(gsLocalCounty(i)) = Trim(boro) Then
                BoroughToCity = Trim(gsLocalCountyDesc(i))
                Exit Do
            End If
            i = i + 1
        Loop
    End Function
    '------------------------------------------------------------------------------
    '-- Function get_call_local_pricing
    '------------------------------------------------------------------------------
    Function get_call_local_pricing(ByVal Cmp As Integer, ByVal Acct As String, ByVal SubAcct As String, ByVal Pu_State As String, ByVal pu_county As String, ByVal pu_city As String, ByVal Pu_Price_Zone As String, ByVal Dest_State As String, ByVal dest_county As String, ByVal dest_city As String, ByVal Dest_Price_Zone As String, ByVal pr_book As Integer) As String
        Dim PuState, PuCounty, PuCity, DestState, DestCounty, DestCity, borough As String
        Dim SQLStr As String
        Dim dr As DataSet
        If Not IsAirport_SearchInTable(Pu_State) Then
            If IsBoro(Pu_State) Then
                PuState = BoroughToState(Pu_State)
                PuCounty = Pu_State ' Should it be "pu_country" ?
                PuCity = BoroughToCity(Pu_State)
            Else
                PuState = Pu_State
                PuCounty = pu_county
                PuCity = pu_city
            End If
            If IsBoro(Dest_State) Or IsAirport_SearchInTable(Dest_State) Then
                borough = Dest_State
            Else
                Select Case UCase(Trim(dest_city))
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
            get_call_local_pricing = "0.00"
            ' search special price by account
            SQLStr = "select price_1,price_2,price_3,price_4,price_5,price_6,price_7,price_8 from Account_city_pricing(NOLOCK) where company=" & Cmp & " and acct_id='" & sqlsafe(Acct) & "' and sub_acct_id='" & sqlsafe(SubAcct) & "' and state = '" & sqlsafe(PuState) & "' and city = '" & sqlsafe(PuCity) & "' and county = '" & sqlsafe(PuCounty) & "'"
            dr = Me.QueryData(SQLStr, "Account_city_pricing")
            If dr.Tables(0).Rows.Count > 0 Then
                Select Case Trim(borough)
                    Case "EPS"
                        get_call_local_pricing = "" & Convert.ToString(dr.Tables(0).Rows(0).Item("price_8"))
                    Case "JC"
                        get_call_local_pricing = "" & Convert.ToString(dr.Tables(0).Rows(0).Item("price_7"))
                    Case "M", "QU", "BK", "BX", "SI"
                        get_call_local_pricing = "" & Convert.ToString(dr.Tables(0).Rows(0).Item("price_6"))
                    Case "STW"
                        get_call_local_pricing = "" & Convert.ToString(dr.Tables(0).Rows(0).Item("price_5"))
                    Case "WCP"
                        get_call_local_pricing = "" & Convert.ToString(dr.Tables(0).Rows(0).Item("price_4"))
                    Case "JFK"
                        get_call_local_pricing = "" & Convert.ToString(dr.Tables(0).Rows(0).Item("price_3"))
                    Case "LGA"
                        get_call_local_pricing = "" & Convert.ToString(dr.Tables(0).Rows(0).Item("price_2"))
                    Case "EWR"
                        get_call_local_pricing = "" & Convert.ToString(dr.Tables(0).Rows(0).Item("price_1"))
                End Select
            End If
            dr.Dispose()
            dr = Nothing
            If get_call_local_pricing <> "0.00" Then
                Exit Function
            End If
        End If
        If Not IsAirport_SearchInTable(Dest_State) Then
            If IsBoro(Dest_State) Then
                DestState = BoroughToState(Dest_State)
                DestCounty = Dest_State
                DestCity = BoroughToCity(Dest_State)
            Else
                DestState = Dest_State
                DestCounty = dest_county
                DestCity = dest_city
            End If
            If IsBoro(Pu_State) Or IsAirport_SearchInTable(Pu_State) Then
                borough = Pu_State
            Else
                Select Case UCase(Trim(pu_city))
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
            get_call_local_pricing = "0.00"
            ' search special price by account
            SQLStr = "select price_1,price_2,price_3,price_4,price_5,price_6,price_7,price_8 from Account_city_pricing(NOLOCK) where company=" & Cmp & " and acct_id='" & sqlsafe(Acct) & "' and sub_acct_id='" & sqlsafe(SubAcct) & "' and state = '" & sqlsafe(DestState) & "' and city = '" & sqlsafe(DestCity) & "' and county = '" & sqlsafe(DestCounty) & "'"
            dr = Me.QueryData(SQLStr, "Account_city_pricing")
            If dr.Tables(0).Rows.Count > 0 Then
                Select Case Trim(borough)
                    Case "EPS"
                        get_call_local_pricing = "" & Convert.ToString(dr.Tables(0).Rows(0).Item("price_8"))
                    Case "JC"
                        get_call_local_pricing = "" & Convert.ToString(dr.Tables(0).Rows(0).Item("price_7"))
                    Case "M", "QU", "BK", "BX", "SI"
                        get_call_local_pricing = "" & Convert.ToString(dr.Tables(0).Rows(0).Item("price_6"))
                    Case "STW"
                        get_call_local_pricing = "" & Convert.ToString(dr.Tables(0).Rows(0).Item("price_5"))
                    Case "WCP"
                        get_call_local_pricing = "" & Convert.ToString(dr.Tables(0).Rows(0).Item("price_4"))
                    Case "JFK"
                        get_call_local_pricing = "" & Convert.ToString(dr.Tables(0).Rows(0).Item("price_3"))
                    Case "LGA"
                        get_call_local_pricing = "" & Convert.ToString(dr.Tables(0).Rows(0).Item("price_2"))
                    Case "EWR"
                        get_call_local_pricing = "" & Convert.ToString(dr.Tables(0).Rows(0).Item("price_1"))
                End Select
            End If
            dr.Dispose()
            dr = Nothing

            If get_call_local_pricing <> "0.00" Then
                Exit Function
            End If
        End If
        SQLStr = "select price from price(NOLOCK) where table_id = " & pr_book & " and from_zone = '" & sqlsafe(Pu_Price_Zone) & "' and to_zone = '" & sqlsafe(Dest_Price_Zone) & "'"
        dr = Me.QueryData(SQLStr, "price")
        If dr.Tables(0).Rows.Count > 0 Then
            get_call_local_pricing = "" & Convert.ToString(dr.Tables(0).Rows(0).Item("price"))
        Else
            dr.Dispose()
            dr = Nothing
            SQLStr = "select price from price(NOLOCK) where table_id = " & pr_book & " and from_zone = '" & sqlsafe(Dest_Price_Zone) & "' and to_zone = '" & sqlsafe(Pu_Price_Zone) & "'"
            dr = Me.QueryData(SQLStr, "price")
            If dr.Tables(0).Rows.Count > 0 Then
                get_call_local_pricing = "" & Convert.ToString(dr.Tables(0).Rows(0).Item("price"))
            Else
                get_call_local_pricing = "0.00"
            End If
        End If
        dr.Dispose()
        dr = Nothing

    End Function
    '------------------------------------------------------------------------------
    '-- Public Function get_call_est_OT_charges -- 8/16/02 Add
    '------------------------------------------------------------------------------
    Public Function get_call_est_OT_charges(ByVal comp As Integer, ByVal acct As String, ByVal sub_acct As String, ByVal sngAM_Holiday_Surcharge As Single, ByVal sFrom_AM_Holiday_Surcharge As String, ByVal sTo_AM_Holiday_Surcharge As String, ByVal sngAM_Holiday_Surcharge2 As Single, ByVal sFrom_AM_Holiday_Surcharge2 As String, ByVal sTo_AM_Holiday_Surcharge2 As String, ByVal sReqTime As String, ByVal sReqDate As String) As Single
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
    '------------------------------------------------------------------------------
    '-- Function get_holiday_surcharge -- 03/20/03 ADD
    '------------------------------------------------------------------------------
    'Function get_holiday_surcharge(ByVal comp As Integer, ByVal acct As String, ByVal sub_acct As String, ByVal sTime As String, ByVal sDate As String) As Single
    '    Dim dr_ghs As DataSet
    '    Dim YYYY As String
    '    Dim dFrom As DateTime
    '    Dim dTo As DateTime
    '    Dim dCur As DateTime
    '    Dim SQLStr As String
    '    get_holiday_surcharge = 0
    '    dCur = CDate(sDate & " " & sTime)
    '    YYYY = Convert.ToString(Year(Now))
    '    SQLStr = "Select * from Account_Holiday(nolock) where "
    '    SQLStr = SQLStr & " company=" & comp
    '    SQLStr = SQLStr & " and acct_id='" & acct & "'"
    '    SQLStr = SQLStr & " and sub_acct_id='" & sub_acct & "'"
    '    dr_ghs = Me.QueryData(SQLStr, "Account_Holiday")
    '    If dr_ghs.Tables(0).Rows.Count > 0 Then
    '        dFrom = CDate(Month(CDate(Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("from_date_time")))) & "/" & Day(CDate(Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("from_date_time")))) & "/" & YYYY & " " & Hour(CDate(Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("from_date_time")))) & ":" & Minute(CDate(Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("from_date_time")))))
    '        dTo = CDate(Month(CDate(Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("to_date_time")))) & "/" & Day(CDate(Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("to_date_time")))) & "/" & YYYY & " " & Hour(CDate(Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("to_date_time")))) & ":" & Minute(CDate(Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("to_date_time")))))
    '        If dFrom <= dTo Then
    '            If dFrom <= dCur And dCur <= dTo Then
    '                get_holiday_surcharge = CSng("" & Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("surcharge")))
    '                Exit Function
    '            End If
    '        Else
    '            If dFrom <= dCur And dCur <= DateAdd("yyyy", 1, dTo) Then
    '                get_holiday_surcharge = CSng("" & Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("surcharge")))
    '                Exit Function
    '            End If
    '        End If
    '        'dr_ghs.MoveNext()
    '    End If
    '    dr_ghs.Dispose()
    '    dr_ghs = Nothing

    'End Function
    '------------------------------------------------------------------------------
    '-- Function get_holiday_surcharge -- 03/20/03 ADD
    '------------------------------------------------------------------------------
    Function get_holiday_surcharge(ByVal comp As Integer, ByVal acct As String, ByVal sub_acct As String, ByVal sTime As String, ByVal sDate As String) As Single
        Dim dr_ghs As DataSet
        Dim YYYY As String
        Dim dFrom As DateTime
        Dim dTo As DateTime
        Dim dCur As DateTime
        Dim SQLStr As String
        get_holiday_surcharge = 0
        dCur = CDate(sDate & " " & sTime)
        YYYY = Convert.ToString(Year(Now))
        SQLStr = "Select * from Account_Holiday(nolock) where "
        SQLStr = SQLStr & " company=" & comp
        SQLStr = SQLStr & " and acct_id='" & sqlsafe(acct) & "'"
        SQLStr = SQLStr & " and sub_acct_id='" & sqlsafe(sub_acct) & "'"
        dr_ghs = Me.QueryData(SQLStr, "Account_Holiday")
        If dr_ghs.Tables(0).Rows.Count > 0 Then
            dFrom = CDate(Month(CDate(Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("from_date_time")))) & "/" & Day(CDate(Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("from_date_time")))) & "/" & YYYY & " " & Hour(CDate(Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("from_date_time")))) & ":" & Minute(CDate(Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("from_date_time")))))
            dTo = CDate(Month(CDate(Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("to_date_time")))) & "/" & Day(CDate(Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("to_date_time")))) & "/" & YYYY & " " & Hour(CDate(Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("to_date_time")))) & ":" & Minute(CDate(Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("to_date_time")))))
            If dFrom <= dTo Then
                If dFrom <= dCur And dCur <= dTo Then
                    get_holiday_surcharge = CSng("" & Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("surcharge")))
                    Exit Function
                End If
            Else
                If dFrom <= dCur And dCur <= DateAdd("yyyy", 1, dTo) Then
                    get_holiday_surcharge = CSng("" & Convert.ToString(dr_ghs.Tables(0).Rows(0).Item("surcharge")))
                    Exit Function
                End If
            End If
            'dr_ghs.MoveNext()
        End If
        dr_ghs.Dispose()
        dr_ghs = Nothing

    End Function

    '------------------------------------------------------------------------------
    '-- Function update_price_book_by_account -- 3/20/03 NEW
    '------------------------------------------------------------------------------
    Function update_price_book_by_account(ByVal sCarType As Integer, ByVal sComp As Integer, ByVal sAcct As String, ByVal sSubAcct As String, ByVal price_book As Integer) As Integer
        '-- update price book only. price zones depend on price book too, but it leaves then unchanged
        update_price_book_by_account = price_book
        '-- If MTC --
        If Val(sComp) = 2 And (sAcct = "12000" Or sAcct = "13000" Or sAcct = "24000") Then
            Select Case Val(sCarType)
                Case 1 'Sedan
                    update_price_book_by_account = 3
                Case 2 ' 6 pax limo
                    update_price_book_by_account = 4
                Case 4 ' suv
                    update_price_book_by_account = 5
                Case Else
                    update_price_book_by_account = 0
            End Select
        End If
        '-- End if MTC --
    End Function
    '------------------------------------------------------------------------------
    '-- Function get_call_city_to_city_pricing -- 3/20/03 NEW
    '-- UPDATE: 8/20/03 - strCar_Type
    '-- UPDATE: 8/25/03 - remove car_type and update val(get_call_city_to_city_pricing) <> 0
    '------------------------------------------------------------------------------
    Function get_call_city_to_city_pricing(ByVal pr_book As Integer, ByVal ss_cmbPuCounty As String, ByVal txtPuCountyTrue As String, ByVal ss_cmbPuCity As String, ByVal ss_cmbDestCounty As String, ByVal txtDestCountyTrue As String, ByVal ss_cmbDestCity As String, ByVal ss_cmbCompany As Integer, ByVal ss_cmbAccountNo As String, ByVal ss_cmbSubAccountNo As String, ByVal txtPuPriceZone As String, ByVal txtDestPriceZone As String, ByRef bFoundInPriceTable As Boolean, ByRef fp_curTolls As Single) As String
        Dim sql_string As String
        Dim dr_gcctcp As DataSet
        Dim PuState As String
        Dim PuCounty As String
        Dim PuCity As String
        Dim DestState As String
        Dim DestCounty As String
        Dim DestCity As String
        Dim borough As String
        Dim sMsg As String
        bFoundInPriceTable = False

        If IsBoro(ss_cmbPuCounty) Then

            PuState = BoroughToState(ss_cmbPuCounty)
            PuCounty = ss_cmbPuCounty
            PuCity = BoroughToCity(ss_cmbPuCounty)
        ElseIf Not IsAirport_SearchInTable(ss_cmbPuCounty) Then
            PuState = ss_cmbPuCounty
            PuCounty = txtPuCountyTrue
            PuCity = ss_cmbPuCity
        End If
        If IsBoro(ss_cmbDestCounty) Then
            DestState = BoroughToState(ss_cmbDestCounty)
            DestCounty = ss_cmbDestCounty
            DestCity = BoroughToCity(ss_cmbDestCounty)
        ElseIf Not IsAirport_SearchInTable(ss_cmbDestCounty) Then
            DestState = ss_cmbDestCounty
            DestCounty = txtDestCountyTrue
            DestCity = ss_cmbDestCity
        End If
        If Not IsAirport_SearchInTable(ss_cmbPuCounty) Then
            If IsBoro(ss_cmbDestCounty) Or IsAirport_SearchInTable(ss_cmbDestCounty) Then
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
            get_call_city_to_city_pricing = "0"
            '-- 8/20/03 : and strCar_Type = "1" --
            '-- 8/25/03 : removed and strCar_Type = "1" --
            If Not IsAirport_SearchInTable(ss_cmbDestCounty) Then 'and strCar_Type = "1"then
                sql_string = "select price, tolls from Account_city_to_city_pricing(NOLOCK) where company=" & ss_cmbCompany & " and acct_id='" & sqlsafe(ss_cmbAccountNo) & "' and sub_acct_id='" & sqlsafe(ss_cmbSubAccountNo) & "' and from_state = '" & sqlsafe(PuState) & "' and from_county = '" & sqlsafe(PuCounty) & "' and from_city = '" & sqlsafe(PuCity) & "' and to_state='" & sqlsafe(DestState) & "' and to_county='" & sqlsafe(DestCounty) & "' and to_city='" & sqlsafe(DestCity) & "'"
                dr_gcctcp = Me.QueryData(sql_string, "Account_city_to_city_pricing")
                If dr_gcctcp.Tables("Account_city_to_city_pricing").Rows.Count > 0 Then

                    get_call_city_to_city_pricing = FormatNumber(Convert.ToString(dr_gcctcp.Tables(0).Rows(0).Item("price")), 2)
                    fp_curTolls = CSng("0" & Convert.ToString(dr_gcctcp.Tables(0).Rows(0).Item("tolls")))
                    bFoundInPriceTable = True
                End If
                dr_gcctcp.Dispose()
                dr_gcctcp = Nothing
                '-- 8/25/03 : "0.00" to 0
                If CInt(get_call_city_to_city_pricing) <> 0 Then Exit Function
            End If

            '-- 8/20/03 : and strCar_Type = "1" --
            '-- 8/25/03 : removed and strCar_type = "1" --
            If IsAirport_SearchInTable(ss_cmbDestCounty) Then 'and strCar_Type = "1" Then
                sql_string = "select price, tolls from Account_city_to_airport_pricing(NOLOCK) where company=" & ss_cmbCompany & " and acct_id='" & sqlsafe(ss_cmbAccountNo) & "' and sub_acct_id='" & sqlsafe(ss_cmbSubAccountNo) & "' and state = '" & sqlsafe(PuState) & "' and city = '" & sqlsafe(PuCity) & "' and county = '" & sqlsafe(PuCounty) & "' and airport='" & sqlsafe(ss_cmbDestCounty) & "'"

                dr_gcctcp = Me.QueryData(sql_string, "Account_city_to_airport_pricing")
                If dr_gcctcp.Tables("Account_city_to_airport_pricing").Rows.Count > 0 Then

                    get_call_city_to_city_pricing = FormatNumber(Convert.ToString(dr_gcctcp.Tables(0).Rows(0).Item("price")), 2)
                    fp_curTolls = CSng("0" & Convert.ToString(dr_gcctcp.Tables(0).Rows(0).Item("tolls")))
                    bFoundInPriceTable = True
                End If
                dr_gcctcp.Dispose()
                dr_gcctcp = Nothing
                '-- 8/25/03 : "0.00" to 0
                If CInt(get_call_city_to_city_pricing) <> 0 Then Exit Function
            End If

        End If
        If Not IsAirport_SearchInTable(ss_cmbDestCounty) Then
            If IsBoro(ss_cmbPuCounty) Or IsAirport_SearchInTable(ss_cmbPuCounty) Then
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
            '-- 8/20/03 : and strCar_Type = "1" --
            '-- 8/25/03 : removed and strCar_Type = "1" --
            If Not IsAirport_SearchInTable(ss_cmbPuCounty) Then ' and strCar_Type = "1" Then
                sql_string = "select price, tolls from Account_city_to_city_pricing(NOLOCK) where company=" & ss_cmbCompany & " and acct_id='" & sqlsafe(ss_cmbAccountNo) & "' and sub_acct_id='" & sqlsafe(ss_cmbSubAccountNo) & "' and from_state = '" & sqlsafe(DestState) & "' and from_county = '" & sqlsafe(DestCounty) & "' and from_city = '" & sqlsafe(DestCity) & "' and to_state='" & sqlsafe(PuState) & "' and to_county='" & sqlsafe(PuCounty) & "' and to_city='" & sqlsafe(PuCity) & "'"
                dr_gcctcp = Me.QueryData(sql_string, "Account_city_to_city_pricing")
                If dr_gcctcp.Tables(0).Rows.Count > 0 Then
                    get_call_city_to_city_pricing = FormatNumber(dr_gcctcp.Tables(0).Rows(0).Item("price").ToString, 2)
                    fp_curTolls = CSng("0" & Convert.ToString(dr_gcctcp.Tables(0).Rows(0).Item("tolls")))
                    bFoundInPriceTable = True
                End If
                dr_gcctcp.Dispose()
                dr_gcctcp = Nothing
                '-- 8/25/03 : "0.00" to 0
                If CInt(get_call_city_to_city_pricing) <> 0 Then Exit Function
            End If

            '-- 8/20/03 : and strCar_Type = "1" --
            '-- 8/25/03 : removed and strCar_Type = "1" --
            If IsAirport_SearchInTable(ss_cmbPuCounty) Then ' and strCar_Type = "1" Then
                sql_string = "select price, tolls from Account_city_to_airport_pricing(NOLOCK) where company=" & ss_cmbCompany & " and acct_id='" & sqlsafe(ss_cmbAccountNo) & "' and sub_acct_id='" & sqlsafe(ss_cmbSubAccountNo) & "' and state = '" & sqlsafe(DestState) & "' and city = '" & sqlsafe(DestCity) & "' and county = '" & sqlsafe(DestCounty) & "' and airport='" & sqlsafe(ss_cmbPuCounty) & "'"
                dr_gcctcp = Me.QueryData(sql_string, "Account_city_to_airport_pricing")
                If dr_gcctcp.Tables("Account_city_to_airport_pricing").Rows.Count > 0 Then
                    get_call_city_to_city_pricing = FormatNumber(Convert.ToString(dr_gcctcp.Tables(0).Rows(0).Item("price")), 2)
                    fp_curTolls = CSng("0" & Convert.ToString(dr_gcctcp.Tables(0).Rows(0).Item("tolls")))
                    bFoundInPriceTable = True
                End If
                dr_gcctcp.Dispose()
                dr_gcctcp = Nothing
                '-- 8/25/03 : "0.00" to 0
                If CInt(get_call_city_to_city_pricing) <> 0 Then Exit Function
            End If
        End If

        '-- 8/20/03 : and strCar_Type = "1" --
        '-- 8/25/03 : removed and strCar_Type = "1" --
        If IsAirport_SearchInTable(ss_cmbPuCounty) And IsAirport_SearchInTable(ss_cmbDestCounty) Then ' and strCar_Type = "1" Then
            'If Pricing_Table_From_Account > 0 Then pricing_table = Pricing_Table_From_Account 'user account info at first
            get_call_city_to_city_pricing = "0.00"
            ' search special price by account
            sql_string = "select price, tolls from Account_airport_to_airport_pricing(NOLOCK) where company=" & ss_cmbCompany & " and acct_id='" & sqlsafe(ss_cmbAccountNo) & "' and sub_acct_id='" & sqlsafe(ss_cmbSubAccountNo) & "' and from_airport = '" & sqlsafe(ss_cmbPuCounty) & "' and to_airport = '" & sqlsafe(ss_cmbDestCounty) & "'"
            dr_gcctcp = Me.QueryData(sql_string, "Account_airport_to_airport_pricing")
            If dr_gcctcp.Tables("Account_airport_to_airport_pricing").Rows.Count > 0 Then
                get_call_city_to_city_pricing = FormatNumber(Convert.ToString(dr_gcctcp.Tables(0).Rows(0).Item("price")), 2)
                fp_curTolls = CSng("0" & Convert.ToString(dr_gcctcp.Tables(0).Rows(0).Item("tolls")))
                bFoundInPriceTable = True
            End If
            dr_gcctcp.Dispose()
            dr_gcctcp = Nothing
            '-- 8/25/03 : "0.00" to 0
            If CInt(get_call_city_to_city_pricing) <> 0 Then Exit Function
        End If

        get_call_city_to_city_pricing = "0.00"


        If Trim(CStr(txtPuPriceZone)) <> "" And Trim(txtDestPriceZone) <> "" Then
            sql_string = "select price,tolls from price(NOLOCK) where table_id = " & pr_book & " and from_zone like  '%" & sqlsafe(txtPuPriceZone) & "' and to_zone like '%" & sqlsafe(txtDestPriceZone) & "'"

            dr_gcctcp = Me.QueryData(sql_string, "price")
            If dr_gcctcp.Tables("price").Rows.Count > 0 Then
                get_call_city_to_city_pricing = FormatNumber(Convert.ToString(dr_gcctcp.Tables(0).Rows(0).Item("price")), 2)
                fp_curTolls = CSng("0" & Convert.ToString(dr_gcctcp.Tables(0).Rows(0).Item("tolls")))
                bFoundInPriceTable = True
            Else
                dr_gcctcp.Dispose()
                dr_gcctcp = Nothing
                sql_string = "select price,tolls from price(NOLOCK) where table_id = " & pr_book & " and from_zone like '%" & sqlsafe(txtDestPriceZone) & "' and to_zone like '%" & sqlsafe(txtPuPriceZone) & "'"
                dr_gcctcp = Me.QueryData(sql_string, "price")
                If dr_gcctcp.Tables("price").Rows.Count > 0 Then
                    'sMsg = "The direct price is missing" & vbCrLf & "Do you want to retrieve the return price instead"
                    'If MsgBox(sMsg, vbQuestion + vbYesNo) = vbYes Then
                    get_call_city_to_city_pricing = FormatNumber(Convert.ToString(dr_gcctcp.Tables(0).Rows(0).Item("price")), 2)
                    fp_curTolls = CSng("0" & Convert.ToString(dr_gcctcp.Tables(0).Rows(0).Item("tolls")))
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

#End Region

#Region "Public Sub Install Price Module"

    Public Function Query_Price(ByVal strfromzone As String, ByVal strtozone As String, ByVal strtable_id As String) As Decimal
        Dim SQLStr As String
        Dim dr As DataSet

        SQLStr = "select price,tolls from price(nolock)"
        SQLStr = SQLStr & " where table_id='" & sqlsafe(strtable_id) & "' and from_zone like '%" & sqlsafe(strfromzone) & "'"
        SQLStr = SQLStr & " and	to_zone like '%" & sqlsafe(strtozone) & "'"

        dr = Me.QueryData(SQLStr, "installprice")
        If Not dr Is Nothing Then
            If dr.Tables.Count > 0 Then
                If dr.Tables(0).Rows.Count > 0 Then
                    'do nothing
                    Query_Price = Convert.ToDecimal(IIf(IsDBNull(dr.Tables(0).Rows(0).Item(0)), 0, Convert.ToDecimal(dr.Tables(0).Rows(0).Item(0))))
                Else
                    Query_Price = 0
                End If
            Else
                Query_Price = 0
            End If
        Else
            Query_Price = 0
        End If

        dr.Dispose()
        dr = Nothing

        Return Query_Price

    End Function

    Function sqlsafe(ByVal inputvalue As String) As String

        If IsNull(inputvalue) Then
            sqlsafe = ""
        Else
            sqlsafe = Replace(inputvalue, "'", " ")
            sqlsafe = Replace(sqlsafe, ",", " ")
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

#Region "Private DB Null User Parts"

    Public Function Check_DBNULL(ByVal Value As Object) As String

        If IsDBNull(Value) = True Then
            Return Nothing
        Else
            Return Convert.ToString(Value).Trim()
        End If

    End Function

    'Private Function Check_DBNULL(ByVal Value As Object) As String

    '    If IsDBNull(Value) = True Then
    '        Return Nothing
    '    Else
    '        Return Convert.ToString(Value).Trim()
    '    End If

    'End Function

#End Region

End Class