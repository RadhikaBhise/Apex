Public Class VoucherData
    'add by daniel
    Private m_cc_name As String
    Private m_pu_address As String
    Private m_dest_address As String
    Private m_stop_area As String
    Private m_no_passengers As String
    '''''''''end''''''''''''''
    Private m_car_type_desc As String
    Private m_confirmation_no As String
    Private m_status_flag As String
    Private m_invoice_no As String
    Private m_company As String
    Private m_check_no As String
    Private m_batch_no As Int16
    Private m_export_cc As String
    Private m_export_CC_date_time As DateTime
    Private m_car_no As String
    Private m_payment_type As String
    Private m_dr_id As String
    Private m_cc_type As String
    Private m_job_no As Int16
    Private m_cc_no As String
    Private m_verif_opr_no As String
    Private m_cc_expr As String
    Private m_verif_date_time As DateTime
    Private m_cc_auth_code As String
    Private m_pu_date_time As DateTime
    Private m_auth_person As String
    Private m_lname As String
    Private m_fname As String
    Private m_auth_telno As String
    Private m_account_no As String
    Private m_sub_account_no As String
    Private m_car_type As String
    Private m_pu_is_airport As String
    Private m_pu_county_airp As String
    Private m_dest_is_airport As String
    Private m_dest_county_airp As String
    Private m_pu_city_airline As String
    Private m_dest_city_airline As String
    Private m_pu_landmark_terminal As String
    Private m_dest_landmark_terminal As String
    Private m_pu_st_no As String
    Private m_dest_st_no As String
    Private m_pu_st_name_flight As String
    Private m_dest_st_name_flight As String
    Private m_pu_x_str As String
    Private m_dest_x_str As String
    Private m_pu_area As String
    Private m_dest_area As String
    Private m_pu_zip As String
    Private m_dest_zip As String
    Private m_pu_point As String
    Private m_dest_point As String
    Private m_pu_disp_zone As Int16
    Private m_dest_disp_zone As Int16
    Private m_pu_price_zone As String
    Private m_dest_price_zone As String
    Private m_table_id As Int32
    Private m_STC_charges As Double
    Private m_voucher_no As String
    Private m_meet_greet_amt As Double
    Private m_base_rate As Double
    Private m_OT_surcharge_amt As Double
    Private m_tolls As Double
    Private m_cash_layout As Double
    Private m_wait_time As DateTime
    Private m_wait_amount As Double
    Private m_tips As Double
    Private m_stops_amt As Double
    Private m_certif_discount As Double
    Private m_stop_wt_amount As Double
    Private m_package_amt As Double
    Private m_miscellaneous As Double
    Private m_parking As Double
    Private m_service_fee As Double
    Private m_phone_amt As Double
    Private m_Discount As Double
    Private m_net As Double
    Private m_comment As String
    Private m_Stop_StrName_City_01 As String
    '## add by lily 12/18/2007
    Private m_invoice_date As DateTime
    Private m_passenger As String
    Private m_gross As String
    Private m_cc_date As String
    Private m_comp_id_1 As String
    Private m_comp_id_2 As String
    Private m_comp_id_3 As String
    Private m_comp_id_4 As String
    Private m_comp_id_5 As String
    Private m_comp_id_6 As String
    ''''add by daniel
    Property Stop_area() As String
        Get
            Return m_stop_area
        End Get
        Set(ByVal Value As String)
            m_stop_area = Value
        End Set
    End Property
    Property Pu_address() As String
        Get
            Return m_pu_address
        End Get
        Set(ByVal Value As String)
            m_pu_address = Value
        End Set
    End Property
    Property Dest_address() As String
        Get
            Return m_dest_address
        End Get
        Set(ByVal Value As String)
            m_dest_address = Value
        End Set
    End Property
    Property CC_Name() As String
        Get
            Return m_cc_name
        End Get
        Set(ByVal Value As String)
            m_cc_name = Value
        End Set
    End Property
    Property Number_passenger() As String
        Get
            Return m_no_passengers
        End Get
        Set(ByVal Value As String)
            m_no_passengers = Value
        End Set
    End Property
    '''''''''''''''''end'''''''''''''''
    Property dest_city_airline() As String
        Get
            Return m_dest_city_airline
        End Get
        Set(ByVal Value As String)
            m_dest_city_airline = Value
        End Set
    End Property
    Property pu_landmark_terminal() As String
        Get
            Return m_pu_landmark_terminal
        End Get
        Set(ByVal Value As String)
            m_pu_landmark_terminal = Value
        End Set
    End Property
    Property dest_landmark_terminal() As String
        Get
            Return m_dest_landmark_terminal
        End Get
        Set(ByVal Value As String)
            m_dest_landmark_terminal = Value
        End Set
    End Property
    Property pu_st_no() As String
        Get
            Return m_pu_st_no
        End Get
        Set(ByVal Value As String)
            m_pu_st_no = Value
        End Set
    End Property
    Property dest_st_no() As String
        Get
            Return m_dest_st_no
        End Get
        Set(ByVal Value As String)
            m_dest_st_no = Value
        End Set
    End Property
    Property pu_st_name_flight() As String
        Get
            Return m_pu_st_name_flight
        End Get
        Set(ByVal Value As String)
            m_pu_st_name_flight = Value
        End Set
    End Property
    Property dest_st_name_flight() As String
        Get
            Return m_dest_st_name_flight
        End Get
        Set(ByVal Value As String)
            m_dest_st_name_flight = Value
        End Set
    End Property
    Property pu_x_str() As String
        Get
            Return m_pu_x_str
        End Get
        Set(ByVal Value As String)
            m_pu_x_str = Value
        End Set
    End Property
    Property dest_x_str() As String
        Get
            Return m_dest_x_str
        End Get
        Set(ByVal Value As String)
            m_dest_x_str = Value
        End Set
    End Property
    Property pu_area() As String
        Get
            Return m_pu_area
        End Get
        Set(ByVal Value As String)
            m_pu_area = Value
        End Set
    End Property
    Property dest_area() As String
        Get
            Return m_dest_area
        End Get
        Set(ByVal Value As String)
            m_dest_area = Value
        End Set
    End Property
    Property pu_zip() As String
        Get
            Return m_pu_zip
        End Get
        Set(ByVal Value As String)
            m_pu_zip = Value
        End Set
    End Property
    Property dest_zip() As String
        Get
            Return m_dest_zip
        End Get
        Set(ByVal Value As String)
            m_dest_zip = Value
        End Set
    End Property
    Property pu_point() As String
        Get
            Return m_pu_point
        End Get
        Set(ByVal Value As String)
            m_pu_point = Value
        End Set
    End Property
    Property dest_point() As String
        Get
            Return m_dest_point
        End Get
        Set(ByVal Value As String)
            m_dest_point = Value
        End Set
    End Property

    Property pu_price_zone() As String
        Get
            Return m_pu_price_zone
        End Get
        Set(ByVal Value As String)
            m_pu_price_zone = Value
        End Set
    End Property
    Property dest_price_zone() As String
        Get
            Return m_dest_price_zone
        End Get
        Set(ByVal Value As String)
            m_dest_price_zone = Value
        End Set
    End Property
    Property voucher_no() As String
        Get
            Return m_voucher_no
        End Get
        Set(ByVal Value As String)
            m_voucher_no = Value
        End Set
    End Property
    Property Stop_StrName_City_01() As String
        Get
            Return m_Stop_StrName_City_01
        End Get
        Set(ByVal Value As String)
            m_Stop_StrName_City_01 = Value
        End Set
    End Property

    Property meet_greet_amt() As Double
        Get
            Return m_meet_greet_amt
        End Get
        Set(ByVal Value As Double)
            m_meet_greet_amt = Value
        End Set
    End Property
    Property base_rate() As Double
        Get
            Return m_base_rate
        End Get
        Set(ByVal Value As Double)
            m_base_rate = Value
        End Set
    End Property
    Property OT_surcharge_amt() As Double
        Get
            Return m_OT_surcharge_amt
        End Get
        Set(ByVal Value As Double)
            m_OT_surcharge_amt = Value
        End Set
    End Property
    Property tolls() As Double
        Get
            Return m_tolls
        End Get
        Set(ByVal Value As Double)
            m_tolls = Value
        End Set
    End Property
    Property cash_layout() As Double
        Get
            Return m_cash_layout
        End Get
        Set(ByVal Value As Double)
            m_cash_layout = Value
        End Set
    End Property

    Property car_type_desc() As String
        Get
            Return m_car_type_desc
        End Get
        Set(ByVal Value As String)
            m_car_type_desc = Value
        End Set
    End Property
    Property confirmation_no() As String
        Get
            Return m_confirmation_no
        End Get
        Set(ByVal Value As String)
            m_confirmation_no = Value
        End Set
    End Property
    Property status_flag() As String
        Get
            Return m_status_flag
        End Get
        Set(ByVal Value As String)
            m_status_flag = Value
        End Set
    End Property
    Property invoice_no() As String
        Get
            Return m_invoice_no
        End Get
        Set(ByVal Value As String)
            m_invoice_no = Value
        End Set
    End Property
    Property company() As String
        Get
            Return m_company
        End Get
        Set(ByVal Value As String)
            m_company = Value
        End Set
    End Property
    Property check_no() As String
        Get
            Return m_check_no
        End Get
        Set(ByVal Value As String)
            m_check_no = Value
        End Set
    End Property
    Property batch_no() As Int16
        Get
            Return m_batch_no
        End Get
        Set(ByVal Value As Int16)
            m_batch_no = Value
        End Set
    End Property
    Property export_cc() As String
        Get
            Return m_export_cc
        End Get
        Set(ByVal Value As String)
            m_export_cc = Value
        End Set
    End Property
    Property export_CC_date_time() As DateTime
        Get
            Return m_export_CC_date_time
        End Get
        Set(ByVal Value As DateTime)
            m_export_CC_date_time = Value
        End Set
    End Property
    Property car_no() As String
        Get
            Return m_car_no
        End Get
        Set(ByVal Value As String)
            m_car_no = Value
        End Set
    End Property
    Property payment_type() As String
        Get
            Return m_payment_type
        End Get
        Set(ByVal Value As String)
            m_payment_type = Value
        End Set
    End Property
    Property dr_id() As String
        Get
            Return m_dr_id
        End Get
        Set(ByVal Value As String)
            m_dr_id = Value
        End Set
    End Property
    Property cc_type() As String
        Get
            Return m_cc_type
        End Get
        Set(ByVal Value As String)
            m_cc_type = Value
        End Set
    End Property
    Property job_no() As Int16
        Get
            Return m_job_no
        End Get
        Set(ByVal Value As Int16)
            m_job_no = Value
        End Set
    End Property
    Property cc_no() As String
        Get
            Return m_cc_no
        End Get
        Set(ByVal Value As String)
            m_cc_no = Value
        End Set
    End Property
    Property verif_opr_no() As String
        Get
            Return m_verif_opr_no
        End Get
        Set(ByVal Value As String)
            m_verif_opr_no = Value
        End Set
    End Property
    Property cc_expr() As String
        Get
            Return m_cc_expr
        End Get
        Set(ByVal Value As String)
            m_cc_expr = Value
        End Set
    End Property
    Property verif_Date_time() As DateTime
        Get
            Return m_verif_date_time
        End Get
        Set(ByVal Value As DateTime)
            m_verif_date_time = Value
        End Set
    End Property
    Property cc_auth_code() As String
        Get
            Return m_cc_auth_code
        End Get
        Set(ByVal Value As String)
            m_cc_auth_code = Value
        End Set
    End Property
    Property pu_date_time() As DateTime
        Get
            Return m_pu_date_time
        End Get
        Set(ByVal Value As DateTime)
            m_pu_date_time = Value
        End Set
    End Property
    Property auth_person() As String
        Get
            Return m_auth_person
        End Get
        Set(ByVal Value As String)
            m_auth_person = Value
        End Set
    End Property
    Property Lname() As String
        Get
            Return m_lname
        End Get
        Set(ByVal Value As String)
            m_lname = Value
        End Set
    End Property
    Property Fname() As String
        Get
            Return m_fname
        End Get
        Set(ByVal Value As String)
            m_fname = Value
        End Set
    End Property
    Property auth_telno() As String
        Get
            Return m_auth_telno
        End Get
        Set(ByVal Value As String)
            m_auth_telno = Value
        End Set
    End Property
    Property account_no() As String
        Get
            Return m_account_no
        End Get
        Set(ByVal Value As String)
            m_account_no = Value
        End Set
    End Property
    Property sub_account_no() As String
        Get
            Return m_sub_account_no
        End Get
        Set(ByVal Value As String)
            m_sub_account_no = Value
        End Set
    End Property
    Property car_type() As String
        Get
            Return m_car_type
        End Get
        Set(ByVal Value As String)
            m_car_type = Value
        End Set
    End Property
    Property pu_is_airport() As String
        Get
            Return m_pu_is_airport
        End Get
        Set(ByVal Value As String)
            m_pu_is_airport = Value
        End Set
    End Property
    Property pu_county_airp() As String
        Get
            Return m_pu_county_airp
        End Get
        Set(ByVal Value As String)
            m_pu_county_airp = Value
        End Set
    End Property
    Property dest_is_airport() As String
        Get
            Return m_dest_is_airport
        End Get
        Set(ByVal Value As String)
            m_dest_is_airport = Value
        End Set
    End Property
    Property dest_county_airp() As String
        Get
            Return m_dest_county_airp
        End Get
        Set(ByVal Value As String)
            m_dest_county_airp = Value
        End Set
    End Property
    Property pu_city_airline() As String
        Get
            Return m_pu_city_airline
        End Get
        Set(ByVal Value As String)
            m_pu_city_airline = Value
        End Set
    End Property
    Property pu_disp_zone() As Int16
        Get
            Return m_pu_disp_zone
        End Get
        Set(ByVal Value As Int16)
            m_pu_disp_zone = Value
        End Set
    End Property
    Property dest_disp_zone() As Int16
        Get
            Return m_dest_disp_zone
        End Get
        Set(ByVal Value As Int16)
            m_dest_disp_zone = Value
        End Set
    End Property
    Property table_id() As Int32
        Get
            Return m_table_id
        End Get
        Set(ByVal Value As Int32)
            m_table_id = Value
        End Set
    End Property
    Property STC_charges() As Double
        Get
            Return m_STC_charges
        End Get
        Set(ByVal Value As Double)
            m_STC_charges = Value
        End Set
    End Property
    Property wait_time() As DateTime
        Get
            Return m_wait_time
        End Get
        Set(ByVal Value As DateTime)
            m_wait_time = Value
        End Set
    End Property
    Property wait_amount() As Double
        Get
            Return m_wait_amount
        End Get
        Set(ByVal Value As Double)
            m_wait_amount = Value
        End Set
    End Property
    Property tips() As Double
        Get
            Return m_tips
        End Get
        Set(ByVal Value As Double)
            m_tips = Value
        End Set
    End Property
    Property stops_amt() As Double
        Get
            Return m_stops_amt
        End Get
        Set(ByVal Value As Double)
            m_stops_amt = Value
        End Set
    End Property
    Property certif_discount() As Double
        Get
            Return m_certif_discount
        End Get
        Set(ByVal Value As Double)
            m_certif_discount = Value
        End Set
    End Property
    Property stop_wt_amount() As Double
        Get
            Return m_stop_wt_amount
        End Get
        Set(ByVal Value As Double)
            m_stop_wt_amount = Value
        End Set
    End Property
    Property package_amt() As Double
        Get
            Return m_package_amt
        End Get
        Set(ByVal Value As Double)
            m_package_amt = Value
        End Set
    End Property
    Property miscellaneous() As Double
        Get
            Return m_miscellaneous
        End Get
        Set(ByVal Value As Double)
            m_miscellaneous = Value
        End Set
    End Property
    Property parking() As Double
        Get
            Return m_parking
        End Get
        Set(ByVal Value As Double)
            m_parking = Value
        End Set
    End Property
    Property service_fee() As Double
        Get
            Return m_service_fee
        End Get
        Set(ByVal Value As Double)
            m_service_fee = Value
        End Set
    End Property
    Property phone_amt() As Double
        Get
            Return m_phone_amt
        End Get
        Set(ByVal Value As Double)
            m_phone_amt = Value
        End Set
    End Property
    Property Discount() As Double
        Get
            Return m_Discount
        End Get
        Set(ByVal Value As Double)
            m_Discount = Value
        End Set
    End Property
    Property net() As Double
        Get
            Return m_net
        End Get
        Set(ByVal Value As Double)
            m_net = Value
        End Set
    End Property
    Property comment() As String
        Get
            Return m_comment
        End Get
        Set(ByVal Value As String)
            m_comment = Value
        End Set
    End Property
    '## add by lily 12/18/2007
    Property invoice_date() As DateTime
        Get
            Return m_invoice_date
        End Get
        Set(ByVal Value As DateTime)
            m_invoice_date = Value
        End Set
    End Property
    Property Passenger() As String
        Get
            Return m_passenger
        End Get
        Set(ByVal Value As String)
            m_passenger = Value
        End Set
    End Property

    Property gross() As String
        Get
            Return m_gross
        End Get
        Set(ByVal Value As String)
            m_gross = Value
        End Set
    End Property

    Property cc_date() As String
        Get
            Return m_cc_date
        End Get
        Set(ByVal Value As String)
            m_cc_date = Value
        End Set
    End Property
    Property comp_id_1() As String
        Get
            Return m_comp_id_1
        End Get
        Set(ByVal Value As String)
            m_comp_id_1 = Value
        End Set
    End Property
    Property comp_id_2() As String
        Get
            Return m_comp_id_2
        End Get
        Set(ByVal Value As String)
            m_comp_id_2 = Value
        End Set
    End Property
    Property comp_id_3() As String
        Get
            Return m_comp_id_3
        End Get
        Set(ByVal Value As String)
            m_comp_id_3 = Value
        End Set
    End Property
    Property comp_id_4() As String
        Get
            Return m_comp_id_4
        End Get
        Set(ByVal Value As String)
            m_comp_id_4 = Value
        End Set
    End Property
    Property comp_id_5() As String
        Get
            Return m_comp_id_5
        End Get
        Set(ByVal Value As String)
            m_comp_id_5 = Value
        End Set
    End Property
    Property comp_id_6() As String
        Get
            Return m_comp_id_6
        End Get
        Set(ByVal Value As String)
            m_comp_id_6 = Value
        End Set
    End Property
End Class
