'------------------------------------------------------------------------------
'-- Class operator
'-- 10/5/2004: Created (Naoki)
'-- This is the base operator class. Try to limit changes to this class, and 
'-- use the subclass to add new properties or functions. Note any changes here
'-- in the comments.
'-- 11/1/04 - Changed the Class Name to OperatorData (eJay)
'-- 11/4/04 - Add some fields
'------------------------------------------------------------------------------
Public Class OperatorData
    Public Sub New()

        'Private m_{:i} As String
        'Me.m_\1 = "0"
        Me.mconfirmation_no = ""
        Me.mpu_date_time = now
        Me.mko_date_time = now
        Me.mdsp_date_time = Now
        Me.mcar_no = ""
        Me.mpriority = ""
        Me.mcompany = ""
        Me.maccount_no = ""
        Me.msub_account_no = ""
        Me.mvip_no = ""
        Me.mlname = ""
        Me.mfname = ""
        Me.mpass_lname = ""
        Me.mpass_fname = ""
        Me.mpu_county = ""
        Me.mpu_county_desc = ""   '## 11/22/2007  added by yang
        Me.mpu_city = ""
        Me.mpu_landmark = ""
        Me.mpu_st_no = ""
        Me.mpu_st_name = ""
        Me.mpu_x_st = ""
        Me.mpu_disp_zone = 0
        Me.mpu_price_zone = ""
        Me.mpu_phone = ""
        Me.mpu_phone_ext = ""
        Me.mpu_point = ""
        Me.mdest_county = ""
        Me.mdest_county_desc = "" '## 11/22/2007  added by yang
        Me.mdest_city = ""
        Me.mdest_landmark = ""
        Me.mdest_st_no = ""
        Me.mdest_st_name = ""
        Me.mdest_x_st = ""
        Me.mdest_disp_zone = 0
        Me.mdest_price_zone = ""
        Me.mdest_phone = ""
        Me.mdest_phone_ext = ""
        Me.mauth_telno = ""   '## 11/23/2007  added by yang
        Me.mdest_point = ""
        Me.mreq_date_time = Now
        Me.mcall_back = ""
        Me.mline_no = ""
        Me.mnow_flag = ""
        Me.mno_pass = ""
        Me.mshare = ""
        Me.meta_time = ""
        Me.mprice_est = ""
        Me.mno_cars = ""
        Me.mdr_no = ""
        Me.mvoucher_no = ""

        'Me.mpayment_type = ""
        Me.mpayment_type = ""
        Me.mpayment_type_desc = ""  '## 12/2/2007   yang

        Me.mcard_type = ""
        Me.mcard_no = ""
        Me.mcard_exp_date = ""
        Me.mcard_auth_no = ""
        Me.mairport_name = ""
        Me.mairport_airline = ""
        Me.mairport_flight = ""
        Me.mairport_terminal = ""
        Me.mairport_pu_point = ""
        Me.mairport_from = ""
        Me.mairport_comment = ""
        Me.mairport_time = "" '## 11/22/2007  added by yang
        Me.mairport_detail = ""   '## 11/22/2007  added by yang
        Me.mairport_dest = ""
        Me.mfbo_name = "" '## 11/22/2007  added by yang
        Me.mfbo_address = ""  '## 11/22/2007  added by yang
        Me.mComp_id_1 = ""
        Me.mComp_id_2 = ""
        Me.mComp_id_3 = ""
        Me.mComp_id_4 = ""
        Me.mComp_id_5 = ""
        Me.mComp_id_6 = ""
        Me.mstatus_flag = ""
        Me.mdirection = ""
        Me.mpu_zip = ""
        Me.mdest_zip = ""
        Me.mcancel_date_time = ""
        Me.moriginal_company = ""
        Me.memail_address = ""
        Me.mpu_index = ""
        Me.morder_by = ""
        Me.morder_by_lname = ""
        Me.morder_by_fname = ""
        Me.mtrans_no = ""
        Me.mpu_point_desc = ""
        Me.mdest_point_desc = ""
        Me.mvendor_confirmation_no = ""

        '--add by eJay 11/4/04-----------------------------------
        Me.m_car_type = ""
        Me.m_car_type_desc = ""
        Me.m_PuAir = ""
        Me.m_DestAir = ""
        Me.m_direction_Text = ""
        Me.m_email_add = ""
        Me.m_dest_airport_airline = ""
        Me.m_dest_airport_flightNO = ""
        Me.m_dest_airport_departureTime = ""
        Me.m_dest_airport_flight = ""
        Me.m_dest_airport_terminal = ""
        Me.m_dest_airport_point = ""
        Me.m_dest_airport_comment = ""
        Me.m_dest_airport_from = ""
        Me.m_dest_airport_detail = "" '## 11/22/2007  added by yang
        Me.m_dest_fbo_name = ""   '## 11/22/2007  added by yang
        Me.m_dest_fbo_address = ""    '## 11/22/2007  added by yang
        '--add by jack  11/15/04-----------------------------------
        Me.m_Req_hour = ""
        Me.m_Req_min = ""
        Me.m_Req_ampm = ""
        Me.m_pax_no = ""
        '--add by jack  11/16/04-----------------------------------
        Me.m_airport_phone = ""
        Me.m_dest_aiport_name = ""
        Me.m_comp_req_1 = ""
        Me.m_comp_req_2 = ""
        Me.m_comp_req_3 = ""
        Me.m_comp_req_4 = ""
        Me.m_comp_req_5 = ""
        Me.m_comp_req_6 = ""
        Me.m_option_10 = ""
        Me.m_stops = ""
        Me.m_card_name = ""
        Me.m_pu_airport_airline_code = ""
        Me.m_dest_aiprot_airline_code = ""
        '--add by jack  11/18/04-----------------------------------
        Me.m_vip_phone = ""
        Me.m_airport_name_desc = ""
        Me.m_dest_airport_name_desc = ""
        '--add by eJay 11/23/04-------------------------------------------------
        Me.m_isairport1 = "" ' char(1)
        Me.m_isairport2 = "" ' char(1)
        Me.m_isairport3 = "" ' char(1)
        Me.m_city_airline_2 = "" ' varchar(20)
        Me.m_city_airline_3 = "" ' varchar(20)
        Me.m_county_1 = "" ' varchar(40)
        Me.m_county_2 = "" ' varchar(40)
        Me.m_county_3 = "" ' varchar(40)
        Me.m_state_airport_1 = "" ' char(3)
        Me.m_state_airport_2 = "" ' char(3)
        Me.m_state_airport_3 = "" ' char(3)
        Me.m_st_no_flight_1 = "" ' varchar(6)
        Me.m_st_no_flight_2 = "" ' varchar(6)
        Me.m_st_no_flight_3 = "" ' varchar(6)
        Me.m_st_name_airp_from_1 = "" ' varchar(20)
        Me.m_st_name_airp_from_2 = "" ' varchar(20)
        Me.m_st_name_airp_from_3 = "" ' varchar(20)
        Me.m_x_street_airp_dest_1 = "" ' varchar(20)
        Me.m_x_street_airp_dest_2 = "" ' varchar(20)
        Me.m_x_street_airp_dest_3 = "" ' varchar(20)
        Me.m_landmark_terminal_2 = "" ' varchar(40)
        Me.m_landmark_terminal_3 = "" ' varchar(40)
        Me.m_zip_1 = ""       'char(5)
        Me.m_zip_2 = ""
        Me.m_zip_3 = ""
        '--add by jack  11/26/04-----------------------------------
        Me.m_pu_direction = ""
        Me.m_dest_direction = ""

        ''--added by lily  12/07/2007-----------------------------------
        'Me.m_pu_airport_direction = ""
        'Me.m_dest_airport_direction = ""

        '--12/07/04 (jack)
        Me.m_car_seat_type = ""
        Me.m_option_9 = ""
        Me.m_car_seat_type_desc = ""
        Me.m_Misc = 0

        Me.m_base_rate = 0
        Me.m_tips_perc = 0
        Me.m_tolls_charges = 0
        Me.m_tips_charges = 0
        Me.m_parking_charges = 0
        Me.m_STC_charges = 0
        Me.m_stops_charges = 0
        Me.m_expenses = 0
        Me.m_waiting_time = 0
        Me.m_discount_cert_perc = 0
        Me.m_WT_charges = 0
        Me.m_discount_cert = 0
        Me.m_service_fee = 0
        Me.m_discount = 0
        Me.m_deposit = 0
        Me.m_M_G_charges = 0
        Me.m_ticket_charges = 0
        Me.m_car_seat_charges = 0
        Me.m_OT_charges = 0
        Me.m_price_est = 0

        '--add by eJay 12/16/04
        Me.m_no_car_seat = 0
        Me.m_no_hours = 0

        '--add by eJay 12/24/04-----------------------------------------------
        Me.m_ccno1 = ""        'char(16)
        Me.m_ccexp1 = ""       'char(4)
        Me.m_cctype1 = ""      'char(1)
        Me.m_ccname1 = ""      'varchar(30)
        Me.m_CCMonth1 = ""
        Me.m_CCYear1 = ""
        Me.m_Card_Exp_date = ""   '--add by daniel 11/30/06

        '--add by eJay 2/5/05-------------------------------------------------
        Me.m_meet_great = ""   'char(1)
        Me.m_cc_refer_id = ""  'char(19)

        '--add by ming 2005-05-13
        Me.mMileage = 0
        Me.mhr_rate = ""       'char(1)
        Me.m_tel_charges = ""
        Me.m_package_charges = ""

        '--add by eJay 10/3/2006
        Me.m_vip_text = ""
        Me.m_account_text = ""
        '--add by eJay 10/4/2006
        Me.m_cc_verify_comment = ""
        '--add by daniel 11/13/2006
        Me.m_opr_comment = ""
        Me.m_cc_v_code = ""
        Me.m_cc_v_code2 = ""
        Me.m_dest_is_airport = ""
        Me.m_pu_is_airport = ""
        Me.m_display_date_time = ""
        '--add by daniel 11/30/2006
        Me.m_stops_amt = 0
        Me.m_wait_time = 0
        Me.m_stop_wt_amt = 0
        Me.m_pri_sec = ""     '--char(1) 'D','P','S','N'
        '---------------------------------------------------------------
        Me.m_ccno_new = ""        'char(16)
        Me.m_cctype_new = ""      'char(1)
        Me.m_ccname_new = ""      'varchar(30)
        Me.m_CCMonth_new = ""
        Me.m_CCYear_new = ""
        Me.m_Card_Exp_date_new = ""   '--add by daniel 11/30/06
        Me.m_cc_v_code_new = ""

        Me.m_cctype_default = ""      'char(1)
        Me.m_ccname_default = ""      'varchar(30)
        Me.m_CCMonth_default = ""
        Me.m_CCYear_default = ""
        Me.m_Card_Exp_date_default = ""   '--add by daniel 11/30/06
        Me.m_cc_v_code_default = ""
        Me.m_return_value = ""

        Me.m_search_value = ""   '--add by daniel 12/03/2007

    End Sub

    Private mconfirmation_no As String
    Private mpu_date_time As DateTime
    Private mko_date_time As DateTime
    Private mdsp_date_time As DateTime
    Private mcar_no As String
    Private mpriority As String
    Private mcompany As String
    Private maccount_no As String
    Private msub_account_no As String
    Private mvip_no As String
    Private mlname As String
    Private mfname As String
    Private mpass_lname As String
    Private mpass_fname As String
    Private mpu_county As String
    Private mpu_county_desc As String   '## 11/22/2007  added by yang
    Private mpu_city As String
    Private mpu_landmark As String
    Private mpu_st_no As String
    Private mpu_st_name As String
    Private mpu_x_st As String
    Private mpu_disp_zone As Int16
    Private mpu_price_zone As String
    Private mpu_phone As String
    Private mpu_phone_ext As String
    Private mpu_point As String
    Private mdest_county As String
    Private mdest_county_desc As String '## 11/22/2007  added by yang
    Private mdest_city As String
    Private mdest_landmark As String
    Private mdest_st_no As String
    Private mdest_st_name As String
    Private mdest_x_st As String
    Private mdest_disp_zone As Int16
    Private mdest_price_zone As String
    Private mdest_phone As String
    Private mdest_phone_ext As String
    Private mauth_telno As String   '## 11/23/2007  added by yang
    Private mdest_point As String
    Private mreq_date_time As DateTime
    Private mcall_back As Char
    Private mline_no As String
    Private mnow_flag As Char
    Private mno_pass As String
    Private mshare As Char
    Private meta_time As String
    Private mprice_est As String
    Private mno_cars As String
    Private mdr_no As String
    Private mvoucher_no As String
    'Private mpayment_type As Char

    Private mpayment_type As String
    Private mpayment_type_desc As String    '## 12/2/2007   yang

    Private mcard_type As Char
    Private mcard_no As String
    Private mcard_exp_date As String
    Private mcard_auth_no As String
    Private mairport_name As String
    Private mairport_airline As String
    Private mairport_flight As String
    Private mairport_terminal As String
    Private mairport_pu_point As String
    Private mairport_from As String
    Private mairport_comment As String
    Private mairport_time As String '## 11/22/2007  added by yang
    Private mairport_detail As String   '## 11/22/2007  added by yang
    Private mairport_dest As String
    Private mfbo_name As String '## 11/22/2007  added by yang
    Private mfbo_address As String  '## 11/22/2007  added by yang
    Private mComp_id_1 As String
    Private mComp_id_2 As String
    Private mComp_id_3 As String
    Private mComp_id_4 As String
    Private mComp_id_5 As String
    Private mComp_id_6 As String
    Private mstatus_flag As String
    Private mdirection As String
    Private mpu_zip As String
    Private mdest_zip As String
    Private mcancel_date_time As String
    Private moriginal_company As String
    Private memail_address As String
    Private mpu_index As String
    Private morder_by As String
    Private morder_by_lname As String
    Private morder_by_fname As String
    Private mtrans_no As String
    Private mpu_point_desc As String
    Private mdest_point_desc As String
    Private mvendor_confirmation_no As String

    '--add by eJay 11/4/04-----------------------------------
    Private m_car_type As String
    Private m_car_type_desc As String
    Private m_PuAir As String
    Private m_DestAir As String
    Private m_direction_Text As String
    Private m_email_add As String
    Private m_dest_airport_airline As String
    Private m_dest_airport_flightNO As String
    Private m_dest_airport_departureTime As String
    Private m_dest_airport_flight As String
    Private m_dest_airport_terminal As String
    Private m_dest_airport_point As String
    Private m_dest_airport_comment As String
    Private m_dest_airport_from As String
    Private m_dest_airport_detail As String '## 11/22/2007  added by yang
    Private m_dest_fbo_name As String   '## 11/22/2007  added by yang
    Private m_dest_fbo_address As String    '## 11/22/2007  added by yang
    '--add by jack  11/15/04-----------------------------------
    Private m_Req_hour As String
    Private m_Req_min As String
    Private m_Req_ampm As String
    Private m_pax_no As String
    '--add by jack  11/16/04-----------------------------------
    Private m_airport_phone As String
    Private m_dest_aiport_name As String
    Private m_comp_req_1 As String
    Private m_comp_req_2 As String
    Private m_comp_req_3 As String
    Private m_comp_req_4 As String
    Private m_comp_req_5 As String
    Private m_comp_req_6 As String
    Private m_option_10 As String
    Private m_stops As String
    Private m_card_name As String
    Private m_pu_airport_airline_code As String
    Private m_dest_aiprot_airline_code As String
    '--add by jack  11/18/04-----------------------------------
    Private m_vip_phone As String
    Private m_airport_name_desc As String
    Private m_dest_airport_name_desc As String
    '--add by eJay 11/23/04-------------------------------------------------
    Private m_isairport1 As String ' char(1)
    Private m_isairport2 As String ' char(1)
    Private m_isairport3 As String ' char(1)
    Private m_city_airline_1 As String ' varchar(20)
    Private m_city_airline_2 As String ' varchar(20)
    Private m_city_airline_3 As String ' varchar(20)
    Private m_county_1 As String ' varchar(40)
    Private m_county_2 As String ' varchar(40)
    Private m_county_3 As String ' varchar(40)
    Private m_state_airport_1 As String ' char(3)
    Private m_state_airport_2 As String ' char(3)
    Private m_state_airport_3 As String ' char(3)
    Private m_st_no_flight_1 As String ' varchar(6)
    Private m_st_no_flight_2 As String ' varchar(6)
    Private m_st_no_flight_3 As String ' varchar(6)
    Private m_st_name_airp_from_1 As String ' varchar(20)
    Private m_st_name_airp_from_2 As String ' varchar(20)
    Private m_st_name_airp_from_3 As String ' varchar(20)
    Private m_x_street_airp_dest_1 As String ' varchar(20)
    Private m_x_street_airp_dest_2 As String ' varchar(20)
    Private m_x_street_airp_dest_3 As String ' varchar(20)
    Private m_landmark_terminal_1 As String ' varchar(40)
    Private m_landmark_terminal_2 As String ' varchar(40)
    Private m_landmark_terminal_3 As String ' varchar(40)
    Private m_zip_1 As String       'char(5)
    Private m_zip_2 As String
    Private m_zip_3 As String
    '--add by jack  11/26/04-----------------------------------
    Private m_pu_direction As String
    Private m_dest_direction As String

    ''--added by lily  12/07/2007-----------------------------------
    'Private m_pu_airport_direction As String
    'Private m_dest_airport_direction As String

    '--12/07/04 (jack)
    Private m_car_seat_type As Char
    Private m_option_9 As Char
    Private m_car_seat_type_desc As String

    '--12/15/04 Added (eJay)
    Private m_Misc As Decimal

    Private m_base_rate As Decimal
    Private m_tips_perc As Decimal
    Private m_tolls_charges As Decimal
    Private m_tips_charges As Decimal
    Private m_parking_charges As Decimal
    Private m_STC_charges As Decimal
    Private m_stops_charges As Decimal
    Private m_expenses As Decimal
    Private m_waiting_time As Int16
    Private m_discount_cert_perc As Decimal
    Private m_WT_charges As Decimal
    Private m_discount_cert As Decimal
    Private m_service_fee As Decimal
    Private m_discount As Decimal
    Private m_deposit As Decimal
    Private m_M_G_charges As Decimal
    Private m_ticket_charges As Decimal
    Private m_car_seat_charges As Decimal
    Private m_OT_charges As Decimal
    Private m_price_est As Decimal

    '--add by eJay 12/16/04
    Private m_no_car_seat As Int16
    Private m_no_hours As Decimal

    '--add by eJay 12/24/04-----------------------------------------------
    Private m_ccno1 As String        'char(16)
    Private m_ccexp1 As String       'char(4)
    Private m_cctype1 As String      'char(1)
    Private m_ccname1 As String      'varchar(30)
    Private m_CCMonth1 As String
    Private m_CCYear1 As String
    Private m_Card_Exp_date As String   '--add by daniel 11/30/06

    '--add by eJay 2/5/05-------------------------------------------------
    Private m_meet_great As String   'char(1)
    Private m_cc_refer_id As String  'char(19)

    '--add by ming 2005-05-13
    Private mMileage As Single

    '--add by jack 05/17/05
    Private mhr_rate As String       'char(1)
    Private m_tel_charges As String
    Private m_package_charges As String

    '--add by eJay 10/3/2006
    Private m_vip_text As String
    Private m_account_text As String
    '--add by eJay 10/4/2006
    Private m_cc_verify_comment As String
    '--add by daniel 11/13/2006
    Private m_opr_comment As String
    Private m_cc_v_code As String
    Private m_cc_v_code2 As String
    Private m_dest_is_airport As String
    Private m_pu_is_airport As String
    Private m_display_date_time As String
    '--add by daniel 11/30/2006
    Private m_stops_amt As Decimal
    Private m_wait_time As Decimal
    Private m_stop_wt_amt As Decimal
    Private m_pri_sec As String     '--char(1) 'D','P','S','N'
    '---------------------------------------------------------------
    Private m_ccno_new As String        'char(16)
    Private m_cctype_new As String      'char(1)
    Private m_ccname_new As String      'varchar(30)
    Private m_CCMonth_new As String
    Private m_CCYear_new As String
    Private m_Card_Exp_date_new As String   '--add by daniel 11/30/06
    Private m_cc_v_code_new As String

    Private m_ccno_default As String        'char(16)
    Private m_cctype_default As String      'char(1)
    Private m_ccname_default As String      'varchar(30)
    Private m_CCMonth_default As String
    Private m_CCYear_default As String
    Private m_Card_Exp_date_default As String   '--add by daniel 11/30/06
    Private m_cc_v_code_default As String
    Private m_return_value As String
    Private m_search_value As String    '--add by daniel 12/03/2007

    Public Property Search_Value() As String
        Get
            Return m_search_value
        End Get
        Set(ByVal value As String)
            m_search_value = value
        End Set
    End Property

    Public Property Return_Value() As String
        Get
            Return m_return_value
        End Get
        Set(ByVal value As String)
            m_return_value = value
        End Set
    End Property
    Public Property CC_Code_Default() As String
        Get
            Return m_cc_v_code_default
        End Get
        Set(ByVal value As String)
            m_cc_v_code_default = value
        End Set
    End Property
    Public Property CC_Code_New() As String
        Get
            Return m_cc_v_code_new
        End Get
        Set(ByVal value As String)
            m_cc_v_code_new = value
        End Set
    End Property

    Public Property CC_No_Default() As String
        Get
            Return m_ccno_Default
        End Get
        Set(ByVal value As String)
            m_ccno_Default = value
        End Set
    End Property
    Public Property CC_Type_Default() As String
        Get
            Return m_cctype_Default
        End Get
        Set(ByVal value As String)
            m_cctype_Default = value
        End Set
    End Property
    Public Property CC_Name_Default() As String
        Get
            Return m_ccname_Default
        End Get
        Set(ByVal value As String)
            m_ccname_Default = value
        End Set
    End Property
    Public Property CC_Month_Default() As String
        Get
            Return m_CCMonth_Default
        End Get
        Set(ByVal value As String)
            m_CCMonth_Default = value
        End Set
    End Property
    Public Property CC_Year_Default() As String
        Get
            Return m_CCYear_Default
        End Get
        Set(ByVal value As String)
            m_CCYear_Default = value
        End Set
    End Property
    Public Property CC_Exp_Date_Default() As String
        Get
            Return m_Card_Exp_date_default
        End Get
        Set(ByVal value As String)
            m_Card_Exp_date_default = value
        End Set
    End Property

    Public Property CC_No_New() As String
        Get
            Return m_ccno_new
        End Get
        Set(ByVal value As String)
            m_ccno_new = value
        End Set
    End Property
    Public Property CC_Type_New() As String
        Get
            Return m_cctype_new
        End Get
        Set(ByVal value As String)
            m_cctype_new = value
        End Set
    End Property
    Public Property CC_Name_New() As String
        Get
            Return m_ccname_new
        End Get
        Set(ByVal value As String)
            m_ccname_new = value
        End Set
    End Property
    Public Property CC_Month_new() As String
        Get
            Return m_CCMonth_new
        End Get
        Set(ByVal value As String)
            m_CCMonth_new = value
        End Set
    End Property
    Public Property CC_Year_new() As String
        Get
            Return m_CCYear_new
        End Get
        Set(ByVal value As String)
            m_CCYear_new = value
        End Set
    End Property
    Public Property CC_Exp_Date_New() As String
        Get
            Return m_Card_Exp_date_new
        End Get
        Set(ByVal value As String)
            m_Card_Exp_date_new = value
        End Set
    End Property

    Public Property Primary_Second_Type() As String
        Get
            Return m_pri_sec
        End Get
        Set(ByVal value As String)
            m_pri_sec = value
        End Set
    End Property
    Public Property Stops_amt() As Decimal
        Get
            Return m_stops_amt
        End Get
        Set(ByVal value As Decimal)
            m_stops_amt = value
        End Set
    End Property
    Public Property Wait_time_charges() As Decimal
        Get
            Return m_wait_time
        End Get
        Set(ByVal value As Decimal)
            m_wait_time = value
        End Set
    End Property
    Public Property Stop_WT_amt() As Decimal
        Get
            Return m_stop_wt_amt
        End Get
        Set(ByVal value As Decimal)
            m_stop_wt_amt = value
        End Set
    End Property


    Public Property card_exp_date1() As String
        Get
            Return m_Card_Exp_date
        End Get
        Set(ByVal value As String)
            m_Card_Exp_date = value
        End Set
    End Property
    Public Property Pu_is_airport() As String
        Get
            Return m_pu_is_airport
        End Get
        Set(ByVal value As String)
            m_pu_is_airport = value
        End Set
    End Property
    Public Property dest_is_airport() As String
        Get
            Return m_dest_is_airport
        End Get
        Set(ByVal value As String)
            m_dest_is_airport = value
        End Set
    End Property
    Public Property Display_date_time() As String
        Get
            Return m_display_date_time
        End Get
        Set(ByVal value As String)
            m_display_date_time = value
        End Set
    End Property

    Public Property CC_V_Code() As String
        Get
            Return m_cc_v_code
        End Get
        Set(ByVal value As String)
            m_cc_v_code = value
        End Set
    End Property
    Public Property CC_V_Code2() As String
        Get
            Return m_cc_v_code2
        End Get
        Set(ByVal value As String)
            m_cc_v_code2 = value
        End Set
    End Property
    Public Property opr_comment() As String
        Get
            Return m_opr_comment
        End Get
        Set(ByVal value As String)
            m_opr_comment = value
        End Set
    End Property
    Public Property cc_verify_comment() As String
        Get
            Return m_cc_verify_comment
        End Get
        Set(ByVal value As String)
            m_cc_verify_comment = value
        End Set
    End Property

    Public Property vip_text() As String
        Get
            Return m_vip_text
        End Get
        Set(ByVal value As String)
            m_vip_text = value
        End Set
    End Property
    Public Property account_text() As String
        Get
            Return m_account_text
        End Get
        Set(ByVal value As String)
            m_account_text = value
        End Set
    End Property

    Public Property tel_charges() As String
        Get
            Return m_tel_charges
        End Get
        Set(ByVal Value As String)
            m_tel_charges = Value
        End Set
    End Property
    Public Property package_charges() As String
        Get
            Return m_package_charges
        End Get
        Set(ByVal Value As String)
            m_package_charges = Value
        End Set
    End Property
    ''''''''''add by daniel
    '''''''''2005-11-14
    Public Property Misc() As Decimal
        Get
            Return m_Misc
        End Get
        Set(ByVal Value As Decimal)
            m_Misc = Value
        End Set
    End Property
    Public Property hr_rate() As String
        Get
            Return mhr_rate
        End Get
        Set(ByVal Value As String)
            mhr_rate = Value
        End Set
    End Property

    Public Property Mileage() As Single
        Get
            Return mMileage
        End Get
        Set(ByVal Value As Single)
            mMileage = Value
        End Set
    End Property

    Public Property cc_refer_id() As String
        Get
            Return m_cc_refer_id
        End Get
        Set(ByVal Value As String)
            m_cc_refer_id = Value
        End Set
    End Property


    Public Property Meet_great() As String
        Get
            Return m_meet_great
        End Get
        Set(ByVal Value As String)
            m_meet_great = Value
        End Set
    End Property
    '---------------------------------------------------------------------

    Public Property CCNo1() As String
        Get
            Return m_ccno1
        End Get
        Set(ByVal Value As String)
            m_ccno1 = Value
        End Set
    End Property

    Public Property CCExp1() As String
        Get
            Return m_ccexp1
        End Get
        Set(ByVal Value As String)
            m_ccexp1 = Value
        End Set
    End Property

    Public Property CCType1() As String
        Get
            Return m_cctype1
        End Get
        Set(ByVal Value As String)
            m_cctype1 = Value
        End Set
    End Property

    Public Property CCName1() As String
        Get
            Return m_ccname1
        End Get
        Set(ByVal Value As String)
            m_ccname1 = Value
        End Set
    End Property
    Public Property CCMonth1() As String
        Get
            Return Me.m_CCMonth1
        End Get
        Set(ByVal Value As String)
            Me.m_CCMonth1 = Value
        End Set
    End Property
    Public Property CCYear1() As String
        Get
            Return Me.m_CCYear1
        End Get
        Set(ByVal Value As String)
            Me.m_CCYear1 = Value
        End Set
    End Property

    Public Property no_car_seat() As Int16
        Get
            Return m_no_car_seat
        End Get
        Set(ByVal Value As Int16)
            m_no_car_seat = Value
        End Set
    End Property
    Public Property no_hours() As Decimal
        Get
            Return m_no_hours
        End Get
        Set(ByVal Value As Decimal)
            m_no_hours = Value
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

    Public Property tips_perc() As Decimal
        Get
            Return m_tips_perc
        End Get
        Set(ByVal Value As Decimal)
            m_tips_perc = Value
        End Set
    End Property
    Public Property tolls_charges() As Decimal
        Get
            Return m_tolls_charges
        End Get
        Set(ByVal Value As Decimal)
            m_tolls_charges = Value
        End Set
    End Property

    Public Property tips_charges() As Decimal
        Get
            Return m_tips_charges
        End Get
        Set(ByVal Value As Decimal)
            m_tips_charges = Value
        End Set
    End Property
    Public Property parking_charges() As Decimal
        Get
            Return m_parking_charges
        End Get
        Set(ByVal Value As Decimal)
            m_parking_charges = Value
        End Set
    End Property

    Public Property STC_charges() As Decimal
        Get
            Return m_STC_charges
        End Get
        Set(ByVal Value As Decimal)
            m_STC_charges = Value
        End Set
    End Property
    Public Property stops_charges() As Decimal
        Get
            Return m_stops_charges
        End Get
        Set(ByVal Value As Decimal)
            m_stops_charges = Value
        End Set
    End Property
    Public Property expenses() As Decimal
        Get
            Return m_expenses
        End Get
        Set(ByVal Value As Decimal)
            m_expenses = Value
        End Set
    End Property
    Public Property waiting_time() As Int16
        Get
            Return m_waiting_time
        End Get
        Set(ByVal Value As Int16)
            m_waiting_time = Value
        End Set
    End Property

    Public Property discount_cert_perc() As Decimal
        Get
            Return m_discount_cert_perc
        End Get
        Set(ByVal Value As Decimal)
            m_discount_cert_perc = Value
        End Set
    End Property
    Public Property WT_charges() As Decimal
        Get
            Return m_WT_charges
        End Get
        Set(ByVal Value As Decimal)
            m_WT_charges = Value
        End Set
    End Property
    Public Property discount_cert() As Decimal
        Get
            Return m_discount_cert
        End Get
        Set(ByVal Value As Decimal)
            m_discount_cert = Value
        End Set
    End Property
    Public Property service_fee() As Decimal
        Get
            Return m_service_fee
        End Get
        Set(ByVal Value As Decimal)
            m_service_fee = Value
        End Set
    End Property

    Public Property discount() As Decimal
        Get
            Return m_discount
        End Get
        Set(ByVal Value As Decimal)
            m_discount = Value
        End Set
    End Property
    Public Property deposit() As Decimal
        Get
            Return m_deposit
        End Get
        Set(ByVal Value As Decimal)
            m_deposit = Value
        End Set
    End Property
    Public Property M_G_charges() As Decimal
        Get
            Return m_M_G_charges
        End Get
        Set(ByVal Value As Decimal)
            m_M_G_charges = Value
        End Set
    End Property
    Public Property ticket_charges() As Decimal
        Get
            Return m_ticket_charges
        End Get
        Set(ByVal Value As Decimal)
            m_ticket_charges = Value
        End Set
    End Property

    Public Property car_seat_charges() As Decimal
        Get
            Return m_car_seat_charges
        End Get
        Set(ByVal Value As Decimal)
            m_car_seat_charges = Value
        End Set
    End Property
    Public Property OT_charges() As Decimal
        Get
            Return m_OT_charges
        End Get
        Set(ByVal Value As Decimal)
            m_OT_charges = Value
        End Set
    End Property
    Public Property price_est1() As Decimal
        Get
            Return m_price_est
        End Get
        Set(ByVal Value As Decimal)
            m_price_est = Value
        End Set
    End Property

    '=================================================================================
    Public Property car_seat_type_desc() As String
        Get
            Return m_car_seat_type_desc
        End Get
        Set(ByVal Value As String)
            m_car_seat_type_desc = Value
        End Set
    End Property
    Public Property option_9() As Char
        Get
            Return m_option_9
        End Get
        Set(ByVal Value As Char)
            m_option_9 = Value
        End Set
    End Property
    Public Property car_seat_type() As Char
        Get
            Return m_car_seat_type
        End Get
        Set(ByVal Value As Char)
            m_car_seat_type = Value
        End Set
    End Property


    Public Property zip_1() As String
        Get
            Return m_zip_1
        End Get
        Set(ByVal Value As String)
            m_zip_1 = Value
        End Set
    End Property
    Public Property zip_2() As String
        Get
            Return m_zip_2
        End Get
        Set(ByVal Value As String)
            m_zip_2 = Value
        End Set
    End Property
    Public Property zip_3() As String
        Get
            Return m_zip_3
        End Get
        Set(ByVal Value As String)
            m_zip_3 = Value
        End Set
    End Property

    Public Property pu_direction() As String
        Get
            Return m_pu_direction
        End Get
        Set(ByVal Value As String)
            m_pu_direction = Value
        End Set
    End Property
    Public Property dest_direction() As String
        Get
            Return m_dest_direction
        End Get
        Set(ByVal Value As String)
            m_dest_direction = Value
        End Set
    End Property
    ''added by lily 12/07/2007 
    'Public Property pu_airport_direction() As String
    '    Get
    '        Return m_pu_airport_direction
    '    End Get
    '    Set(ByVal Value As String)
    '        m_pu_airport_direction = Value
    '    End Set
    'End Property
    'Public Property dest_airport_direction() As String
    '    Get
    '        Return m_dest_airport_direction
    '    End Get
    '    Set(ByVal Value As String)
    '        m_dest_airport_direction = Value
    '    End Set
    'End Property

    Public Property isairport1() As String
        Get
            Return m_isairport1
        End Get
        Set(ByVal Value As String)
            m_isairport1 = Value
        End Set
    End Property
    Public Property isairport2() As String
        Get
            Return m_isairport2
        End Get
        Set(ByVal Value As String)
            m_isairport2 = Value
        End Set
    End Property
    Public Property isairport3() As String
        Get
            Return m_isairport3
        End Get
        Set(ByVal Value As String)
            m_isairport3 = Value
        End Set
    End Property
    Public Property city_airline_1() As String
        Get
            Return m_city_airline_1
        End Get
        Set(ByVal Value As String)
            m_city_airline_1 = Value
        End Set
    End Property
    Public Property city_airline_2() As String
        Get
            Return m_city_airline_2
        End Get
        Set(ByVal Value As String)
            m_city_airline_2 = Value
        End Set
    End Property
    Public Property city_airline_3() As String
        Get
            Return m_city_airline_3
        End Get
        Set(ByVal Value As String)
            m_city_airline_3 = Value
        End Set
    End Property
    Public Property county_1() As String
        Get
            Return m_county_1
        End Get
        Set(ByVal Value As String)
            m_county_1 = Value
        End Set
    End Property
    Public Property county_2() As String
        Get
            Return m_county_2
        End Get
        Set(ByVal Value As String)
            m_county_2 = Value
        End Set
    End Property
    Public Property county_3() As String
        Get
            Return m_county_3
        End Get
        Set(ByVal Value As String)
            m_county_3 = Value
        End Set
    End Property
    Public Property state_airport_1() As String
        Get
            Return m_state_airport_1
        End Get
        Set(ByVal Value As String)
            m_state_airport_1 = Value
        End Set
    End Property
    Public Property state_airport_2() As String
        Get
            Return m_state_airport_2
        End Get
        Set(ByVal Value As String)
            m_state_airport_2 = Value
        End Set
    End Property
    Public Property state_airport_3() As String
        Get
            Return m_state_airport_3
        End Get
        Set(ByVal Value As String)
            m_state_airport_3 = Value
        End Set
    End Property
    Public Property st_no_flight_1() As String
        Get
            Return m_st_no_flight_1
        End Get
        Set(ByVal Value As String)
            m_st_no_flight_1 = Value
        End Set
    End Property
    Public Property st_no_flight_2() As String
        Get
            Return m_st_no_flight_2
        End Get
        Set(ByVal Value As String)
            m_st_no_flight_2 = Value
        End Set
    End Property
    Public Property st_no_flight_3() As String
        Get
            Return m_st_no_flight_3
        End Get
        Set(ByVal Value As String)
            m_st_no_flight_3 = Value
        End Set
    End Property
    Public Property st_name_airp_from_1() As String
        Get
            Return m_st_name_airp_from_1
        End Get
        Set(ByVal Value As String)
            m_st_name_airp_from_1 = Value
        End Set
    End Property
    Public Property st_name_airp_from_2() As String
        Get
            Return m_st_name_airp_from_2
        End Get
        Set(ByVal Value As String)
            m_st_name_airp_from_2 = Value
        End Set
    End Property
    Public Property st_name_airp_from_3() As String
        Get
            Return m_st_name_airp_from_3
        End Get
        Set(ByVal Value As String)
            m_st_name_airp_from_3 = Value
        End Set
    End Property
    Public Property x_street_airp_dest_1() As String
        Get
            Return m_x_street_airp_dest_1
        End Get
        Set(ByVal Value As String)
            m_x_street_airp_dest_1 = Value
        End Set
    End Property
    Public Property x_street_airp_dest_2() As String
        Get
            Return m_x_street_airp_dest_2
        End Get
        Set(ByVal Value As String)
            m_x_street_airp_dest_2 = Value
        End Set
    End Property
    Public Property x_street_airp_dest_3() As String
        Get
            Return m_x_street_airp_dest_3
        End Get
        Set(ByVal Value As String)
            m_x_street_airp_dest_3 = Value
        End Set
    End Property
    Public Property landmark_terminal_1() As String
        Get
            Return m_landmark_terminal_1
        End Get
        Set(ByVal Value As String)
            m_landmark_terminal_1 = Value
        End Set
    End Property
    Public Property landmark_terminal_2() As String
        Get
            Return m_landmark_terminal_2
        End Get
        Set(ByVal Value As String)
            m_landmark_terminal_2 = Value
        End Set
    End Property
    Public Property landmark_terminal_3() As String
        Get
            Return m_landmark_terminal_3
        End Get
        Set(ByVal Value As String)
            m_landmark_terminal_3 = Value
        End Set
    End Property

    '-----------------------------------------------------------------------

    Public Property airport_name_desc() As String
        Get
            Return m_airport_name_desc
        End Get
        Set(ByVal Value As String)
            m_airport_name_desc = Value
        End Set
    End Property
    Public Property dest_airport_name_desc() As String
        Get
            Return m_dest_airport_name_desc
        End Get
        Set(ByVal Value As String)
            m_dest_airport_name_desc = Value
        End Set
    End Property
    Public Property dest_airport_detail() As String '## 11/22/2007  added by yang
        Get
            Return Me.m_dest_airport_detail
        End Get
        Set(ByVal value As String)
            Me.m_dest_airport_detail = value
        End Set
    End Property
    Property dest_fbo_name() As String '## 11/22/2007  added by yang
        Get
            Return m_dest_fbo_name
        End Get
        Set(ByVal value As String)
            m_dest_fbo_name = value
        End Set
    End Property
    Property dest_fbo_address() As String '## 11/22/2007  added by yang
        Get
            Return m_dest_fbo_address
        End Get
        Set(ByVal value As String)
            m_dest_fbo_address = value
        End Set
    End Property

    Public Property vip_phone() As String
        Get
            Return m_vip_phone
        End Get
        Set(ByVal Value As String)
            m_vip_phone = Value
        End Set
    End Property

    Public Property pu_airport_airline_code() As String
        Get
            Return m_pu_airport_airline_code
        End Get
        Set(ByVal Value As String)
            m_pu_airport_airline_code = Value
        End Set
    End Property

    Public Property dest_aiprot_airline_code() As String
        Get
            Return m_dest_aiprot_airline_code
        End Get
        Set(ByVal Value As String)
            m_dest_aiprot_airline_code = Value
        End Set
    End Property
    Public Property card_name() As String
        Get
            Return m_card_name
        End Get
        Set(ByVal Value As String)
            m_card_name = Value
        End Set
    End Property

    Public Property stops() As String
        Get
            Return m_stops
        End Get
        Set(ByVal Value As String)
            m_stops = Value
        End Set
    End Property

    Public Property option_10() As String
        Get
            Return m_option_10
        End Get
        Set(ByVal Value As String)
            m_option_10 = Value
        End Set
    End Property

    Public Property comp_req_1() As String
        Get
            Return m_comp_req_1
        End Get
        Set(ByVal Value As String)
            m_comp_req_1 = Value
        End Set
    End Property

    Public Property comp_req_2() As String
        Get
            Return m_comp_req_2
        End Get
        Set(ByVal Value As String)
            m_comp_req_2 = Value
        End Set
    End Property

    Public Property comp_req_3() As String
        Get
            Return m_comp_req_3
        End Get
        Set(ByVal Value As String)
            m_comp_req_3 = Value
        End Set
    End Property

    Public Property comp_req_4() As String
        Get
            Return m_comp_req_4
        End Get
        Set(ByVal Value As String)
            m_comp_req_4 = Value
        End Set
    End Property
    Public Property comp_req_5() As String
        Get
            Return m_comp_req_5
        End Get
        Set(ByVal Value As String)
            m_comp_req_5 = Value
        End Set
    End Property

    Public Property comp_req_6() As String
        Get
            Return m_comp_req_6
        End Get
        Set(ByVal Value As String)
            m_comp_req_6 = Value
        End Set
    End Property

    Public Property dest_aiport_name() As String
        Get
            Return m_dest_aiport_name
        End Get
        Set(ByVal Value As String)
            m_dest_aiport_name = Value
        End Set
    End Property


    Public Property airport_phone() As String
        Get
            Return m_airport_phone
        End Get
        Set(ByVal Value As String)
            m_airport_phone = Value
        End Set
    End Property

    Public Property pax_no() As String
        Get
            Return m_pax_no
        End Get
        Set(ByVal Value As String)
            m_pax_no = Value
        End Set
    End Property


    Public Property Req_ampm() As String
        Get
            Return m_Req_ampm
        End Get
        Set(ByVal Value As String)
            m_Req_ampm = Value
        End Set
    End Property
    Public Property Req_min() As String
        Get
            Return m_Req_min
        End Get
        Set(ByVal Value As String)
            m_Req_min = Value
        End Set
    End Property

    Public Property Req_hour() As String
        Get
            Return m_Req_hour
        End Get
        Set(ByVal Value As String)
            m_Req_hour = Value
        End Set
    End Property

    Property dest_airport_from() As String
        Get
            Return m_dest_airport_from
        End Get
        Set(ByVal Value As String)
            m_dest_airport_from = Value
        End Set
    End Property
    Property dest_airport_comment() As String
        Get
            Return m_dest_airport_comment
        End Get
        Set(ByVal Value As String)
            m_dest_airport_comment = Value
        End Set
    End Property
    Property dest_airport_point() As String
        Get
            Return m_dest_airport_point
        End Get
        Set(ByVal Value As String)
            m_dest_airport_point = Value
        End Set
    End Property
    Property dest_airport_terminal() As String
        Get
            Return m_dest_airport_terminal
        End Get
        Set(ByVal Value As String)
            m_dest_airport_terminal = Value
        End Set
    End Property
    Property dest_airport_flight() As String
        Get
            Return m_dest_airport_flight
        End Get
        Set(ByVal Value As String)
            m_dest_airport_flight = Value
        End Set
    End Property
    Property dest_airport_airline() As String
        Get
            Return m_dest_airport_airline
        End Get
        Set(ByVal Value As String)
            m_dest_airport_airline = Value
        End Set
    End Property

    Property dest_airport_flightNO() As String
        Get
            Return m_dest_airport_flightNO
        End Get
        Set(ByVal Value As String)
            m_dest_airport_flightNO = Value
        End Set
    End Property

    Property dest_airport_departureTime() As String
        Get
            Return m_dest_airport_departureTime
        End Get
        Set(ByVal Value As String)
            m_dest_airport_departureTime = Value
        End Set
    End Property
    Property airport_time() As String   '## 11/22/2007  added by yang
        Get
            Return Me.mairport_time
        End Get
        Set(ByVal value As String)
            Me.mairport_time = value
        End Set
    End Property
    Property airport_detail() As String   '## 11/22/2007  added by yang
        Get
            Return Me.mairport_detail
        End Get
        Set(ByVal value As String)
            Me.mairport_detail = value
        End Set
    End Property
    Property fbo_name() As String   '## 11/22/2007  added by yang
        Get
            Return mfbo_name
        End Get
        Set(ByVal value As String)
            mfbo_name = value
        End Set
    End Property
    Property fbo_address() As String   '## 11/22/2007  added by yang
        Get
            Return mfbo_address
        End Get
        Set(ByVal value As String)
            mfbo_address = value
        End Set
    End Property

    Property email_add() As String
        Get
            Return m_email_add
        End Get
        Set(ByVal Value As String)
            m_email_add = Value
        End Set
    End Property

    Property Car_type() As String
        Get
            Return m_car_type
        End Get
        Set(ByVal Value As String)
            m_car_type = Value
        End Set
    End Property

    Property Car_type_Desc() As String
        Get
            Return m_car_type_desc
        End Get
        Set(ByVal Value As String)
            m_car_type_desc = Value
        End Set
    End Property

    Property PuAir() As String
        Get
            Return m_PuAir
        End Get
        Set(ByVal Value As String)
            m_PuAir = Value
        End Set
    End Property
    Property DestAir() As String
        Get
            Return m_DestAir
        End Get
        Set(ByVal Value As String)
            m_DestAir = Value
        End Set
    End Property
    Property Direction_Text() As String
        Get
            Return m_direction_Text
        End Get
        Set(ByVal Value As String)
            m_direction_Text = Value
        End Set
    End Property
    '--------------------------------------------------------

    Property confirmation_no() As String
        Get
            Return mconfirmation_no
        End Get
        Set(ByVal Value As String)
            '-- Cannot set confirmation directly through property
            mconfirmation_no = Value
        End Set
    End Property
    Property pu_date_time() As DateTime
        Get
            Return mpu_date_time
        End Get
        Set(ByVal Value As DateTime)
            mpu_date_time = Value
        End Set
    End Property
    Property ko_date_time() As DateTime
        Get
            Return mko_date_time
        End Get
        Set(ByVal Value As DateTime)

        End Set
    End Property
    Property dsp_date_time() As DateTime
        Get
            Return mdsp_date_time
        End Get
        Set(ByVal Value As DateTime)

        End Set
    End Property
    Property car_no() As String
        Get
            Return mcar_no
        End Get
        Set(ByVal Value As String)
            mcar_no = Value
        End Set
    End Property
    Property priority() As String
        Get
            Return mpriority
        End Get
        Set(ByVal Value As String)
            mpriority = Value
        End Set
    End Property
    Property company() As String
        Get
            Return mcompany
        End Get
        Set(ByVal Value As String)
            mcompany = Value
        End Set
    End Property
    Property account_no() As String
        Get
            Return maccount_no
        End Get
        Set(ByVal Value As String)
            maccount_no = Value
        End Set
    End Property
    Property sub_account_no() As String
        Get
            Return msub_account_no
        End Get
        Set(ByVal Value As String)
            msub_account_no = Value
        End Set
    End Property
    Property vip_no() As String
        Get
            Return mvip_no
        End Get
        Set(ByVal Value As String)
            mvip_no = Value
        End Set
    End Property
    Property lname() As String
        Get
            Return mlname
        End Get
        Set(ByVal Value As String)
            mlname = Value
        End Set
    End Property
    Property fname() As String
        Get
            Return mfname
        End Get
        Set(ByVal Value As String)
            mfname = Value
        End Set
    End Property
    Property pass_lname() As String
        Get
            Return mlname
        End Get
        Set(ByVal Value As String)
            mlname = Value
        End Set
    End Property
    Property pass_fname() As String
        Get
            Return mpass_fname
        End Get
        Set(ByVal Value As String)
            mpass_fname = Value
        End Set
    End Property
    Property pu_county() As String
        Get
            Return mpu_county
        End Get
        Set(ByVal Value As String)
            mpu_county = Value
        End Set
    End Property
    Property pu_county_desc() As String '## 11/22/2007  added by yang
        Get
            Return Me.mpu_county_desc
        End Get
        Set(ByVal value As String)
            Me.mpu_county_desc = value
        End Set
    End Property
    Property pu_city() As String
        Get
            Return mpu_city
        End Get
        Set(ByVal Value As String)
            mpu_city = Value
        End Set
    End Property
    Property pu_landmark() As String
        Get
            Return mpu_landmark
        End Get
        Set(ByVal Value As String)
            mpu_landmark = Value
        End Set
    End Property
    Property pu_st_no() As String
        Get
            Return mpu_st_no
        End Get
        Set(ByVal Value As String)
            mpu_st_no = Value
        End Set
    End Property
    Property pu_st_name() As String
        Get
            Return mpu_st_name
        End Get
        Set(ByVal Value As String)
            mpu_st_name = Value
        End Set
    End Property
    Property pu_x_st() As String
        Get
            Return mpu_x_st
        End Get
        Set(ByVal Value As String)
            mpu_x_st = Value
        End Set
    End Property
    Property pu_disp_zone() As Int16
        Get
            Return mpu_disp_zone
        End Get
        Set(ByVal Value As Int16)
            mpu_disp_zone = Value
        End Set
    End Property
    Property pu_price_zone() As String
        Get
            Return mpu_price_zone
        End Get
        Set(ByVal Value As String)
            mpu_price_zone = Value
        End Set
    End Property
    Property pu_phone() As String
        Get
            Return mpu_phone
        End Get
        Set(ByVal Value As String)
            mpu_phone = Value
        End Set
    End Property
    Property pu_phone_ext() As String
        Get
            Return mpu_phone_ext
        End Get
        Set(ByVal Value As String)
            mpu_phone_ext = Value
        End Set
    End Property
    Property pu_point() As String
        Get
            Return mpu_point
        End Get
        Set(ByVal Value As String)
            mpu_point = Value
        End Set
    End Property
    Property dest_county() As String
        Get
            Return mdest_county
        End Get
        Set(ByVal Value As String)
            mdest_county = Value
        End Set
    End Property
    Property dest_county_desc() As String '## 11/22/2007  added by yang
        Get
            Return Me.mdest_county_desc
        End Get
        Set(ByVal value As String)
            Me.mdest_county_desc = value
        End Set
    End Property
    Property dest_city() As String
        Get
            Return mdest_city
        End Get
        Set(ByVal Value As String)
            mdest_city = Value
        End Set
    End Property
    Property dest_landmark() As String
        Get
            Return mdest_landmark
        End Get
        Set(ByVal Value As String)
            mdest_landmark = Value
        End Set
    End Property
    Property dest_st_no() As String
        Get
            Return mdest_st_no
        End Get
        Set(ByVal Value As String)
            mdest_st_no = Value
        End Set
    End Property
    Property dest_st_name() As String
        Get
            Return mdest_st_name
        End Get
        Set(ByVal Value As String)
            mdest_st_name = Value
        End Set
    End Property
    Property dest_x_st() As String
        Get
            Return mdest_x_st
        End Get
        Set(ByVal Value As String)
            mdest_x_st = Value
        End Set
    End Property
    Property dest_disp_zone() As Int16
        Get
            Return mdest_disp_zone
        End Get
        Set(ByVal Value As Int16)
            mdest_disp_zone = Value
        End Set
    End Property
    Property dest_price_zone() As String
        Get
            Return mdest_price_zone
        End Get
        Set(ByVal Value As String)
            mdest_price_zone = Value
        End Set
    End Property
    Property dest_phone() As String
        Get
            Return mdest_phone
        End Get
        Set(ByVal Value As String)
            mdest_phone = Value
        End Set
    End Property
    Property dest_phone_ext() As String
        Get
            Return mdest_phone_ext
        End Get
        Set(ByVal Value As String)
            mdest_phone_ext = Value
        End Set
    End Property
    Property auth_telno() As String '## 11/23/2007  added by yang
        Get
            Return Me.mauth_telno
        End Get
        Set(ByVal value As String)
            Me.mauth_telno = value
        End Set
    End Property
    Property dest_point() As String
        Get
            Return mdest_point
        End Get
        Set(ByVal Value As String)
            mdest_point = Value
        End Set
    End Property
    Property req_date_time() As DateTime
        Get
            Return mreq_date_time
        End Get
        Set(ByVal Value As DateTime)
            mreq_date_time = Value
        End Set
    End Property
    Property call_back() As Char
        Get
            Return mcall_back
        End Get
        Set(ByVal Value As Char)
            mcall_back = Value
        End Set
    End Property
    Property line_no() As String
        Get
            Return mline_no
        End Get
        Set(ByVal Value As String)
            mline_no = Value
        End Set
    End Property
    Property now_flag() As Char
        Get
            Return mnow_flag
        End Get
        Set(ByVal Value As Char)
            mnow_flag = Value
        End Set
    End Property
    Property no_pass() As String
        Get
            Return mno_pass
        End Get
        Set(ByVal Value As String)
            mno_pass = Value
        End Set
    End Property
    Property share() As Char
        Get
            Return mshare
        End Get
        Set(ByVal Value As Char)
            mshare = Value
        End Set
    End Property
    Property eta_time() As String
        Get
            Return meta_time
        End Get
        Set(ByVal Value As String)
            meta_time = Value
        End Set
    End Property
    Property price_est() As String
        Get
            Return mprice_est
        End Get
        Set(ByVal Value As String)
            mprice_est = Value
        End Set
    End Property
    Property no_cars() As String
        Get
            Return mno_cars
        End Get
        Set(ByVal Value As String)
            mno_cars = Value
        End Set
    End Property
    Property dr_no() As String
        Get
            Return mdr_no
        End Get
        Set(ByVal Value As String)
            mdr_no = Value
        End Set
    End Property
    Property voucher_no() As String
        Get
            Return mvoucher_no
        End Get
        Set(ByVal Value As String)
            mvoucher_no = Value
        End Set
    End Property
    Property payment_type() As String
        Get
            Return mpayment_type
        End Get
        Set(ByVal Value As String)
            mpayment_type = Value
        End Set
    End Property
    Property payment_type_desc() As String
        Get
            Return Me.mpayment_type_desc
        End Get
        Set(ByVal value As String)
            Me.mpayment_type_desc = value
        End Set
    End Property
    Property card_type() As Char
        Get
            Return mcard_type
        End Get
        Set(ByVal Value As Char)
            mcard_type = Value
        End Set
    End Property
    Property card_no() As String
        Get
            Return mcard_no
        End Get
        Set(ByVal Value As String)
            mcard_no = Value
        End Set
    End Property
    Property card_exp_date() As String
        Get
            Return mcard_exp_date
        End Get
        Set(ByVal Value As String)
            mcard_exp_date = Value
        End Set
    End Property
    Property card_auth_no() As String
        Get
            Return mcard_auth_no
        End Get
        Set(ByVal Value As String)
            mcard_auth_no = Value
        End Set
    End Property
    Property airport_name() As String
        Get
            Return mairport_name
        End Get
        Set(ByVal Value As String)
            mairport_name = Value
        End Set
    End Property
    Property airport_airline() As String
        Get
            Return mairport_airline
        End Get
        Set(ByVal Value As String)
            mairport_airline = Value
        End Set
    End Property
    Property airport_flight() As String
        Get
            Return mairport_flight
        End Get
        Set(ByVal Value As String)
            mairport_flight = Value
        End Set
    End Property
    Property airport_terminal() As String
        Get
            Return mairport_terminal
        End Get
        Set(ByVal Value As String)
            mairport_terminal = Value
        End Set
    End Property
    Property airport_pu_point() As String
        Get
            Return mairport_pu_point
        End Get
        Set(ByVal Value As String)
            mairport_pu_point = Value
        End Set
    End Property
    Property airport_from() As String
        Get
            Return mairport_from
        End Get
        Set(ByVal Value As String)
            mairport_from = Value
        End Set
    End Property
    Property airport_comment() As String
        Get
            Return mairport_comment
        End Get
        Set(ByVal Value As String)
            mairport_comment = Value
        End Set
    End Property
    Property airport_dest() As String
        Get
            Return mairport_dest
        End Get
        Set(ByVal Value As String)
            Value = mairport_dest
        End Set
    End Property
    Property Comp_id_1() As String
        Get
            Return mComp_id_1
        End Get
        Set(ByVal Value As String)
            mComp_id_1 = Value
        End Set
    End Property
    Property Comp_id_2() As String
        Get
            Return mComp_id_2
        End Get
        Set(ByVal Value As String)
            mComp_id_2 = Value
        End Set
    End Property
    Property Comp_id_3() As String
        Get
            Return mComp_id_3
        End Get
        Set(ByVal Value As String)
            mComp_id_3 = Value
        End Set
    End Property
    Property Comp_id_4() As String
        Get
            Return mComp_id_4
        End Get
        Set(ByVal Value As String)
            mComp_id_4 = Value
        End Set
    End Property
    Property Comp_id_5() As String
        Get
            Return mComp_id_5
        End Get
        Set(ByVal Value As String)
            mComp_id_5 = Value
        End Set
    End Property
    Property Comp_id_6() As String
        Get
            Return mComp_id_6
        End Get
        Set(ByVal Value As String)
            mComp_id_6 = Value
        End Set
    End Property
    Property status_flag() As String
        Get
            Return mstatus_flag
        End Get
        Set(ByVal Value As String)
            mstatus_flag = Value
        End Set
    End Property
    Property direction() As String
        Get
            Return mdirection
        End Get
        Set(ByVal Value As String)
            mdirection = Value
        End Set
    End Property
    Property pu_zip() As String
        Get
            Return mpu_zip
        End Get
        Set(ByVal Value As String)
            mpu_zip = Value
        End Set
    End Property
    Property dest_zip() As String
        Get
            Return mdest_zip
        End Get
        Set(ByVal Value As String)
            mdest_zip = Value
        End Set
    End Property
    Property cancel_date_time() As String
        Get
            Return mcancel_date_time
        End Get
        Set(ByVal Value As String)
            mcancel_date_time = Value
        End Set
    End Property
    Property original_company() As String
        Get
            Return moriginal_company
        End Get
        Set(ByVal Value As String)
            moriginal_company = Value
        End Set
    End Property
    Property email_address() As String
        Get
            Return memail_address
        End Get
        Set(ByVal Value As String)
            memail_address = Value
        End Set
    End Property
    Property pu_index() As String
        Get
            Return mpu_index
        End Get
        Set(ByVal Value As String)
            mpu_index = Value
        End Set
    End Property
    Property order_by() As String
        Get
            Return morder_by
        End Get
        Set(ByVal Value As String)
            morder_by = Value
        End Set
    End Property
    Property order_by_lname() As String
        Get
            Return morder_by_lname
        End Get
        Set(ByVal Value As String)
            morder_by_lname = Value
        End Set
    End Property
    Property order_by_fname() As String
        Get
            Return morder_by_fname
        End Get
        Set(ByVal Value As String)
            morder_by_fname = Value
        End Set
    End Property
    Property trans_no() As String
        Get
            Return mtrans_no
        End Get
        Set(ByVal Value As String)
            mtrans_no = Value
        End Set
    End Property
    Property pu_point_desc() As String
        Get
            Return mpu_point_desc
        End Get
        Set(ByVal Value As String)
            mpu_point_desc = Value
        End Set
    End Property
    Property dest_point_desc() As String
        Get
            Return mdest_point_desc
        End Get
        Set(ByVal Value As String)
            mdest_point_desc = Value
        End Set
    End Property
    Property vendor_confirmation_no() As String
        Get
            Return mvendor_confirmation_no
        End Get
        Set(ByVal Value As String)
            mvendor_confirmation_no = Value
        End Set
    End Property
End Class
