Public Class UserData
    '--add by daniel
    Private m_sub_zip As String
    Private m_email_text_format As String

    Private m_user_id As String
    Private m_fname As String
    Private m_lname As String
    Private m_password As String
    Private m_st_name As String
    Private m_st_no As String
    Private m_suite As String
    Private m_city As String
    Private m_county As String
    Private m_state As String
    Private m_zip_code As String
    Private m_email As String
    Private m_cell_phone As String
    Private m_home_phone As String
    Private m_office_phone As String
    Private m_office_phone_ext As String
    Private m_pager_no As String
    Private m_priority As String
    Private m_pu_index As String
    Private m_acct_id As String
    Private m_sub_acct_id As String
    Private m_comp_id_1 As String
    Private m_comp_id_2 As String
    Private m_comp_id_3 As String
    Private m_comp_id_4 As String
    Private m_comp_id_5 As String
    Private m_comp_id_6 As String
    Private m_level1_id As String
    Private m_level2_id As String
    Private m_level3_id As String
    Private m_active_flag As String
    Private m_term_date As DateTime
    Private m_reservation_flag As String
    Private m_username As String

    ''---add on 09/20 by tom
    Private m_company As String
    Private m_department As String
    Private m_division As String
    Private m_office As String

    ''---add on 09/27 by tom
    Private m_IBD_FICC_flag As String

    '---add on 09/27 by tom
    Private m_GUID As String

    ''---add on 10/18 by wan
    Private m_homedirection As String

    'add by eJay 10/27/2004
    Private m_pinNo As String       'varchar(50)

    '--10/28/04 - add the variables (eJay)
    Private m_originalpwd As String     'varchar(50)
    Private m_ccno As String        'char(16)
    Private m_ccexp As String       'char(4)
    Private m_cctype As String      'char(1)
    Private m_ccname As String      'varchar(30)
    Private m_fnameOrd As String '-- 10/28/04 (nanco)
    Private m_lnameOrd As String  '-- 10/28/04 (nanco)
    Private m_CCMonth As String   '-- 10/28/04 (nanco)
    Private m_CCYear As String   '-- 10/28/04 (nanco)
    Private m_office_phone_Area As String     '-- 10/28/04 (nanco)
    Private m_cash_account As String      '-- 10/28/04 (nanco)
    Private m_check_user As String          '--11/09/04 (eJay)

    Private m_close_date As String         '--11/09/04 (eJay)
    Private m_close_comment As String      '--07/25/05 (maria)
    Private m_table_id As Int32             '--11/09/04 (eJay)
    Private m_elseSubID As String           '--11/09/04 (eJay)
    Private m_accountcompany As String      '--11/09/04 (eJay)
    Private m_internet As String            '--11/09/04 (eJay)
    Private m_name As String                '--11/09/04 (eJay)

    Private m_checkAccount As String        '--11/09/04 (eJay)


    '--11/10/04 (jack)
    Private m_Req_date As String
    Private m_Req_hour As String
    Private m_Req_min As String
    Private m_Req_ampm As String
    Private m_PaymenType As String
    Private m_cartype As String
    Private m_PPoint As String
    Private m_strcross As String

    Private m_airport As String
    Private m_airport_airline As String
    Private m_airport_flight As String
    Private m_airport_from As String
    Private m_airport_point As String
    Private m_airport_phone As String
    Private m_airport_comment As String
    Private m_pax_no As String
    Private m_pu_landmark As String
    Private m_dest_landmark As String
    '--11/17/04 (jack)
    Private m_pu_phone As String
    Private m_direction As String
    Private m_stops As String
    '--11/18/04 eJay
    Private m_fax As String
    Private m_country As String
    Private m_contact As String
    Private m_aux_street_add As String
    Private m_class_one_club As String
    '--11/22/04 (jack)
    Private m_car_type_desc As String
    Private m_airport_desc As String
    Private m_DPoint As String
    '--12/07/04 (jack)
    Private m_share As Char
    Private m_car_seat_type As Char
    Private m_option_9 As Char
    Private m_car_seat_type_desc As String

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

    Private m_acct_name As String
    Private m_check As String

    '--added by ming 2005-4-28 -------------------------------------------
    Private m_flightNo As String     'varchar(10)
    Private m_departureTime As String 'char(5)

    '--add by jack 05/17/05
    Private mhr_rate As String       'char(1)
    '--add by eJay 2/17/2006
    Private m_admin_assistant_flag As String    'char(1)
    Private m_cc_v_code As String
    Private m_cc_v_code2 As String
    Private m_phone_2_ext As String  'char(5)

    Public Property office_phone_area_ext() As String
        Get
            Return m_phone_2_ext
        End Get
        Set(ByVal value As String)
            m_phone_2_ext = value
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
    Public Property CC_V_Code() As String
        Get
            Return m_cc_v_code
        End Get
        Set(ByVal value As String)
            m_cc_v_code = value
        End Set
    End Property

    Public Property email_text_format() As String
        Get
            Return m_email_text_format
        End Get
        Set(ByVal value As String)
            m_email_text_format = value
        End Set
    End Property

    Public Property sub_zip() As String
        Get
            Return m_sub_zip
        End Get
        Set(ByVal Value As String)
            m_sub_zip = Value
        End Set
    End Property

    Public Property admin_assistant_flag() As String
        Get
            Return m_admin_assistant_flag
        End Get
        Set(ByVal Value As String)
            m_admin_assistant_flag = Value
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

    Public Property airport_FlightNO() As String
        Get
            Return m_flightNo
        End Get
        Set(ByVal Value As String)
            m_flightNo = Value
        End Set
    End Property

    Public Property airport_DepartureTime() As String
        Get
            Return m_departureTime
        End Get
        Set(ByVal Value As String)
            m_departureTime = Value
        End Set
    End Property

    Public Property check() As String
        Get
            Return m_check
        End Get
        Set(ByVal Value As String)
            m_check = Value
        End Set
    End Property


    Public Property acct_name() As String
        Get
            Return m_acct_name
        End Get
        Set(ByVal Value As String)
            m_acct_name = Value
        End Set
    End Property
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
    '-----------------------------------------------------------------------

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

    Public Property share() As Char
        Get
            Return m_share
        End Get
        Set(ByVal Value As Char)
            m_share = Value
        End Set
    End Property
    Public Property DPoint() As String
        Get
            Return m_DPoint
        End Get
        Set(ByVal Value As String)
            m_DPoint = Value
        End Set
    End Property

    Public Property airport_desc() As String
        Get
            Return m_airport_desc
        End Get
        Set(ByVal Value As String)
            m_airport_desc = Value
        End Set
    End Property

    Public Property car_type_desc() As String
        Get
            Return m_car_type_desc
        End Get
        Set(ByVal Value As String)
            m_car_type_desc = Value
        End Set
    End Property

    Public Property class_one_club() As String
        Get
            Return m_class_one_club
        End Get
        Set(ByVal Value As String)
            m_class_one_club = Value
        End Set
    End Property
    Public Property aux_street_add() As String
        Get
            Return m_aux_street_add
        End Get
        Set(ByVal Value As String)
            m_aux_street_add = Value
        End Set
    End Property
    Public Property contact() As String
        Get
            Return m_contact
        End Get
        Set(ByVal Value As String)
            m_contact = Value
        End Set
    End Property
    Public Property country() As String
        Get
            Return m_country
        End Get
        Set(ByVal Value As String)
            m_country = Value
        End Set
    End Property
    Public Property fax() As String
        Get
            Return m_fax
        End Get
        Set(ByVal Value As String)
            m_fax = Value
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
    Public Property direction() As String
        Get
            Return m_direction
        End Get
        Set(ByVal Value As String)
            m_direction = Value
        End Set
    End Property

    Public Property pu_phone() As String
        Get
            Return m_pu_phone
        End Get
        Set(ByVal Value As String)
            m_pu_phone = Value
        End Set
    End Property

    Public Property dest_landmark() As String
        Get
            Return m_dest_landmark
        End Get
        Set(ByVal Value As String)
            m_dest_landmark = Value
        End Set
    End Property
    Public Property pu_landmark() As String
        Get
            Return m_pu_landmark
        End Get
        Set(ByVal Value As String)
            m_pu_landmark = Value
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

    Public Property airport_comment() As String
        Get
            Return m_airport_comment
        End Get
        Set(ByVal Value As String)
            m_airport_comment = Value
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
    Public Property airport_point() As String
        Get
            Return m_airport_point
        End Get
        Set(ByVal Value As String)
            m_airport_point = Value
        End Set
    End Property
    Public Property airport_from() As String
        Get
            Return m_airport_from
        End Get
        Set(ByVal Value As String)
            m_airport_from = Value
        End Set
    End Property
    Public Property airport_flight() As String
        Get
            Return m_airport_flight
        End Get
        Set(ByVal Value As String)
            m_airport_flight = Value
        End Set
    End Property

    Public Property airport_airline() As String
        Get
            Return m_airport_airline
        End Get
        Set(ByVal Value As String)
            m_airport_airline = Value
        End Set
    End Property

    Public Property airport() As String
        Get
            Return m_airport
        End Get
        Set(ByVal Value As String)
            m_airport = Value
        End Set
    End Property


    Public Property strcross() As String
        Get
            Return m_strcross
        End Get
        Set(ByVal Value As String)
            m_strcross = Value
        End Set
    End Property

    Public Property PPoint() As String
        Get
            Return m_PPoint
        End Get
        Set(ByVal Value As String)
            m_PPoint = Value
        End Set
    End Property
    Public Property cartype() As String
        Get
            Return m_cartype
        End Get
        Set(ByVal Value As String)
            m_cartype = Value
        End Set
    End Property

    Public Property PaymenType() As String
        Get
            Return m_PaymenType
        End Get
        Set(ByVal Value As String)
            m_PaymenType = Value
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

    Public Property Req_date() As String
        Get
            Return m_Req_date
        End Get
        Set(ByVal Value As String)
            m_Req_date = Value
        End Set
    End Property

    Public Property checkAccount() As String
        Get
            Return m_checkAccount
        End Get
        Set(ByVal Value As String)
            m_checkAccount = Value
        End Set
    End Property

    Public Property close_date() As String
        Get
            Return m_close_date
        End Get
        Set(ByVal Value As String)
            m_close_date = Value
        End Set
    End Property
    Public Property close_comment() As String
        Get
            Return m_close_comment
        End Get
        Set(ByVal Value As String)
            m_close_comment = Value
        End Set
    End Property
    Public Property table_id() As Int32
        Get
            Return m_table_id
        End Get
        Set(ByVal Value As Int32)
            m_table_id = Value
        End Set
    End Property
    Public Property elseSubID() As String
        Get
            Return m_elseSubID
        End Get
        Set(ByVal Value As String)
            m_elseSubID = Value
        End Set
    End Property
    Public Property accountcompany() As String
        Get
            Return m_accountcompany
        End Get
        Set(ByVal Value As String)
            m_accountcompany = Value
        End Set
    End Property
    Public Property Internet() As String
        Get
            Return m_internet
        End Get
        Set(ByVal Value As String)
            m_internet = Value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return m_name
        End Get
        Set(ByVal Value As String)
            m_name = Value
        End Set
    End Property
    '--properties begin-----------------------
    'add by eJay 10/27/2004
    Public Property check_user() As String
        Get
            Return m_check_user
        End Get
        Set(ByVal Value As String)
            m_check_user = Value
        End Set
    End Property
    Public Property PinNo() As String
        Get
            Return m_pinNo
        End Get
        Set(ByVal Value As String)
            m_pinNo = Value

        End Set
    End Property

    Public Property OriPWD() As String
        Get
            Return m_originalpwd
        End Get
        Set(ByVal Value As String)
            m_originalpwd = Value
        End Set
    End Property

    Public Property CCNo() As String
        Get
            Return m_ccno
        End Get
        Set(ByVal Value As String)
            m_ccno = Value
        End Set
    End Property

    Public Property CCExp() As String
        Get
            Return m_ccexp
        End Get
        Set(ByVal Value As String)
            m_ccexp = Value
        End Set
    End Property

    Public Property CCType() As String
        Get
            Return m_cctype
        End Get
        Set(ByVal Value As String)
            m_cctype = Value
        End Set
    End Property

    Public Property CCName() As String
        Get
            Return m_ccname
        End Get
        Set(ByVal Value As String)
            m_ccname = Value
        End Set
    End Property
    '-- 10/28/04 (nanco) for order entry
    Public Property CCMonth() As String
        Get
            Return Me.m_CCMonth
        End Get
        Set(ByVal Value As String)
            Me.m_CCMonth = Value
        End Set
    End Property
    Public Property CCYear() As String
        Get
            Return Me.m_CCYear
        End Get
        Set(ByVal Value As String)
            Me.m_CCYear = Value
        End Set
    End Property
    '-------- end ---------

    Public Property user_id() As String
        Get
            Return m_user_id
        End Get
        Set(ByVal Value As String)
            m_user_id = Value
        End Set
    End Property

    Public Property fname() As String
        Get
            Return m_fname
        End Get
        Set(ByVal Value As String)
            m_fname = Value
        End Set
    End Property


    Public Property lname() As String
        Get
            Return m_lname
        End Get
        Set(ByVal Value As String)
            m_lname = Value
        End Set
    End Property

    Public Property password() As String
        Get
            Return m_password
        End Get
        Set(ByVal Value As String)
            m_password = Value
        End Set
    End Property

    Public Property st_name() As String
        Get
            Return m_st_name
        End Get
        Set(ByVal Value As String)
            m_st_name = Value
        End Set
    End Property


    Public Property st_no() As String
        Get
            Return m_st_no
        End Get
        Set(ByVal Value As String)
            m_st_no = Value
        End Set
    End Property


    Public Property suite() As String
        Get
            Return m_suite
        End Get
        Set(ByVal Value As String)
            m_suite = Value
        End Set
    End Property

    Public Property city() As String
        Get
            Return m_city
        End Get
        Set(ByVal Value As String)
            m_city = Value
        End Set
    End Property

    Public Property county() As String
        Get
            Return m_county
        End Get
        Set(ByVal Value As String)
            m_county = Value
        End Set
    End Property

    Public Property state() As String
        Get
            Return m_state
        End Get
        Set(ByVal Value As String)
            m_state = Value
        End Set
    End Property

    Public Property zip_code() As String
        Get
            Return m_zip_code
        End Get
        Set(ByVal Value As String)
            m_zip_code = Value
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


    Public Property cell_phone() As String
        Get
            Return m_cell_phone
        End Get
        Set(ByVal Value As String)
            m_cell_phone = Value
        End Set
    End Property

    Public Property home_phone() As String
        Get
            Return m_home_phone
        End Get
        Set(ByVal Value As String)
            m_home_phone = Value
        End Set
    End Property
    '--
    Public Property office_phone_area() As String
        Get
            Return Me.m_office_phone_Area
        End Get
        Set(ByVal Value As String)
            Me.m_office_phone_Area = Value
        End Set
    End Property
    Public Property office_phone() As String
        Get
            Return m_office_phone
        End Get
        Set(ByVal Value As String)
            m_office_phone = Value
        End Set
    End Property


    Public Property office_phone_ext() As String
        Get
            Return m_office_phone_ext
        End Get
        Set(ByVal Value As String)
            m_office_phone_ext = Value
        End Set
    End Property


    ''--Alias Home Phone
    Public Property pager_no() As String
        Get
            Return m_pager_no
        End Get
        Set(ByVal Value As String)
            m_pager_no = Value
        End Set
    End Property


    Public Property priority() As String
        Get
            Return m_priority
        End Get
        Set(ByVal Value As String)
            m_priority = Value
        End Set
    End Property


    Public Property pu_index() As String
        Get
            Return m_pu_index
        End Get
        Set(ByVal Value As String)
            m_pu_index = Value
        End Set
    End Property


    Public Property acct_id() As String
        Get
            Return m_acct_id
        End Get
        Set(ByVal Value As String)
            m_acct_id = Value
        End Set
    End Property

    Public Property sub_acct_id() As String
        Get
            Return m_sub_acct_id
        End Get
        Set(ByVal Value As String)
            m_sub_acct_id = Value
        End Set
    End Property


    Public Property comp_id_1() As String
        Get
            Return m_comp_id_1
        End Get
        Set(ByVal Value As String)
            m_comp_id_1 = Value
        End Set
    End Property

    Public Property comp_id_2() As String
        Get
            Return m_comp_id_2
        End Get
        Set(ByVal Value As String)
            m_comp_id_2 = Value
        End Set
    End Property

    Public Property comp_id_3() As String
        Get
            Return m_comp_id_3
        End Get
        Set(ByVal Value As String)
            m_comp_id_3 = Value
        End Set
    End Property

    Public Property comp_id_4() As String
        Get
            Return m_comp_id_4
        End Get
        Set(ByVal Value As String)
            m_comp_id_4 = Value
        End Set
    End Property

    Public Property comp_id_5() As String
        Get
            Return m_comp_id_5
        End Get
        Set(ByVal Value As String)
            m_comp_id_5 = Value
        End Set
    End Property

    Public Property comp_id_6() As String
        Get
            Return m_comp_id_6
        End Get
        Set(ByVal Value As String)
            m_comp_id_6 = Value
        End Set
    End Property


    Public Property level1_id() As String
        Get
            Return m_level1_id
        End Get
        Set(ByVal Value As String)
            m_level1_id = Value
        End Set
    End Property

    Public Property level2_id() As String
        Get
            Return m_level2_id
        End Get
        Set(ByVal Value As String)
            m_level2_id = Value
        End Set
    End Property

    Public Property level3_id() As String
        Get
            Return m_level3_id
        End Get
        Set(ByVal Value As String)
            m_level3_id = Value
        End Set
    End Property

    Public Property active_flag() As String
        Get
            Return m_active_flag
        End Get
        Set(ByVal Value As String)
            m_active_flag = Value
        End Set
    End Property

    Public Property term_date() As DateTime
        Get
            Return m_term_date
        End Get
        Set(ByVal Value As DateTime)
            m_term_date = Value
        End Set
    End Property

    Public Property reservation_flag() As String
        Get
            Return m_reservation_flag
        End Get
        Set(ByVal Value As String)
            m_reservation_flag = Value
        End Set
    End Property

    Public Property username() As String
        Get
            Return m_username
        End Get
        Set(ByVal Value As String)
            m_username = Value
        End Set
    End Property

    ''---add on 09/20
    Public Property Company() As String
        Get
            Return m_company
        End Get
        Set(ByVal Value As String)
            m_company = Value
        End Set
    End Property

    Public Property Department() As String
        Get
            Return m_department
        End Get
        Set(ByVal Value As String)
            m_department = Value
        End Set
    End Property

    Public Property Division() As String
        Get
            Return m_division
        End Get
        Set(ByVal Value As String)
            m_division = Value
        End Set
    End Property

    Public Property Office() As String
        Get
            Return m_office
        End Get
        Set(ByVal Value As String)
            m_office = Value
        End Set
    End Property

    ''---add on 09/27 by tom
    Public Property IBD_FICC() As String
        Get
            Return m_IBD_FICC_flag
        End Get
        Set(ByVal Value As String)
            m_IBD_FICC_flag = Value
        End Set
    End Property

    ''---add on 09/28 by tom
    Public Property GUID() As String
        Get
            Return m_GUID
        End Get
        Set(ByVal Value As String)
            m_GUID = Value
        End Set
    End Property

    ''---add on 10/18 by wan
    Public Property HomeDirection() As String
        Get
            Return Me.m_homedirection
        End Get
        Set(ByVal Value As String)
            Me.m_homedirection = Value
        End Set
    End Property

    '--properties end-----------------------

    '-- 10/28/04 (nanco) for order entry 
    Public Property FnameOrd() As String
        Get
            Return Me.m_fnameOrd
        End Get
        Set(ByVal Value As String)
            Me.m_fnameOrd = Value
        End Set
    End Property
    Public Property LnameOrd() As String
        Get
            Return Me.m_lnameOrd
        End Get
        Set(ByVal Value As String)
            Me.m_lnameOrd = Value
        End Set
    End Property
    Public Property CashAccount() As String
        Get
            Return Me.m_cash_account
        End Get
        Set(ByVal Value As String)
            Me.m_cash_account = Value
        End Set
    End Property
    '------ end --------


    'constructor
    Public Sub New()
        With Me
            .admin_assistant_flag = "N" '--add by eJay 2/22/2006
            .GUID = ""
            .user_id = ""
            .fname = " "
            .lname = " "
            .password = " "
            .acct_id = ""
            .active_flag = ""
            .cell_phone = ""
            .city = ""
            .comp_id_1 = ""
            .comp_id_2 = ""
            .comp_id_3 = ""
            .comp_id_4 = ""
            .comp_id_5 = ""
            .comp_id_6 = ""
            .county = ""
            .email = ""
            .home_phone = ""
            .level1_id = ""
            .level2_id = ""
            .level3_id = ""
            .office_phone = ""
            .office_phone_ext = ""
            .pager_no = ""
            .priority = ""
            .pu_index = ""
            .reservation_flag = ""
            .st_name = ""
            .st_no = "0"
            .state = ""
            .sub_acct_id = ""
            .suite = ""
            .term_date = Now()
            .username = ""
            .zip_code = ""
            .Company = ""
            .Department = ""
            .Division = ""
            .Office = ""
            .IBD_FICC = ""

            Me.m_homedirection = ""
        End With
    End Sub


End Class
