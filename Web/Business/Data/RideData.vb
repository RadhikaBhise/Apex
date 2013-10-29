Public Class RideData

    Private m_confirmation_no As String
    Private m_status_flag As String
    Private m_req_date_time As DateTime
    Private m_car_no As String
    Private m_ETA As Int64
    Private m_pu_st_no As String
    Private m_pu_st_name As String
    Private m_pu_city As String
    Private m_pu_county As String
    Private m_pu_zip As String
    Private m_pu_landmark As String
    Private m_dest_st_no As String
    Private m_dest_st_name As String
    Private m_dest_city As String
    Private m_dest_county As String
    Private m_dest_zip As String
    Private m_dest_landmark As String

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
    Property req_date_time() As DateTime
        Get
            Return m_req_date_time
        End Get
        Set(ByVal Value As DateTime)
            m_req_date_time = Value
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
    Property ETA() As Int64
        Get
            Return m_ETA
        End Get
        Set(ByVal Value As Int64)
            m_ETA = Value
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
    Property pu_st_name() As String
        Get
            Return m_pu_st_name
        End Get
        Set(ByVal Value As String)
            m_pu_st_name = Value
        End Set
    End Property
    Property pu_city() As String
        Get
            Return m_pu_city
        End Get
        Set(ByVal Value As String)
            m_pu_city = Value
        End Set
    End Property
    Property pu_county() As String
        Get
            Return m_pu_county
        End Get
        Set(ByVal Value As String)
            m_pu_county = Value
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
    Property pu_landmark() As String
        Get
            Return m_pu_landmark
        End Get
        Set(ByVal Value As String)
            m_pu_landmark = Value
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
    Property dest_st_name() As String
        Get
            Return m_dest_st_name
        End Get
        Set(ByVal Value As String)
            m_dest_st_name = Value
        End Set
    End Property
    Property dest_city() As String
        Get
            Return m_dest_city
        End Get
        Set(ByVal Value As String)
            m_dest_city = Value
        End Set
    End Property
    Property dest_county() As String
        Get
            Return m_dest_county
        End Get
        Set(ByVal Value As String)
            m_dest_county = Value
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
    Property dest_landmark() As String
        Get
            Return m_dest_landmark
        End Get
        Set(ByVal Value As String)
            m_dest_landmark = Value
        End Set
    End Property

End Class
