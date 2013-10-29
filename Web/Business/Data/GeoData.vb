Public Class Location
    Private m_st_no As String
    Private m_st_name As String
    Private m_city As String
    Private m_state As String
    Private m_landmark As String
    Private m_zipcode As String     'add by tom on 10/17
    Public Property StNo() As String
        Get
            Return m_st_no
        End Get
        Set(ByVal Value As String)
            m_st_no = Value
        End Set
    End Property
    Public Property StName() As String
        Get
            Return m_st_name
        End Get
        Set(ByVal Value As String)
            m_st_name = Value
        End Set
    End Property
    Public Property City() As String
        Get
            Return m_city
        End Get
        Set(ByVal Value As String)
            m_city = Value
        End Set
    End Property
    Public Property State() As String
        Get
            Return m_state
        End Get
        Set(ByVal Value As String)
            m_state = Value
        End Set
    End Property
    Public Property Landmark() As String
        Get
            Return m_landmark
        End Get
        Set(ByVal Value As String)
            m_landmark = Value
        End Set
    End Property

    Public Property ZipCode() As String
        Get
            Return m_zipcode
        End Get
        Set(ByVal Value As String)
            m_zipcode = Value
        End Set
    End Property
End Class

#Region " --Stops--"
'A single Stop Class
'2004/10/21 Spring
Public Class StopOne
    Private m_BoroState As String
    Private m_StName As String
    Private m_StNo As String
    Private m_StCross As String
    Private m_City As String

    Private m_IsAirport As Boolean

    Private m_AirPort As String
    Private m_AirLine As String

    Private m_IndexAirport As Int32
    Private m_IndexAirLine As Int32

    Private m_IndexFreq As Int32

    Private m_IndexStop As Int32    'add on 10/21 by wan
    Private m_Landmark As String

    Public Property BoroState() As String
        Get
            Return Me.m_BoroState
        End Get
        Set(ByVal Value As String)
            Me.m_BoroState = Value
        End Set
    End Property

    Public Property StName() As String
        Get
            Return Me.m_StName
        End Get
        Set(ByVal Value As String)
            Me.m_StName = Value
        End Set
    End Property

    Public Property StNo() As String
        Get
            Return Me.m_StNo
        End Get
        Set(ByVal Value As String)
            Me.m_StNo = Value
        End Set
    End Property

    Public Property City() As String
        Get
            Return Me.m_City
        End Get
        Set(ByVal Value As String)
            Me.m_City = Value
        End Set
    End Property

    Public Property StCross() As String
        Get
            Return Me.m_StCross
        End Get
        Set(ByVal Value As String)
            Me.m_StCross = Value
        End Set
    End Property

    Public Property IsAirport() As Boolean
        Get
            Return Me.m_IsAirport
        End Get
        Set(ByVal Value As Boolean)
            Me.m_IsAirport = Value
        End Set
    End Property

    Public Property Airport() As String
        Get
            Return Me.m_AirPort
        End Get
        Set(ByVal Value As String)
            Me.m_AirPort = Value
        End Set
    End Property

    Public Property AirLine() As String
        Get
            Return Me.m_AirLine
        End Get
        Set(ByVal Value As String)
            Me.m_AirLine = Value
        End Set
    End Property

    Public Property IndexAirport() As Int32
        Get
            Return Me.m_IndexAirport
        End Get
        Set(ByVal Value As Int32)
            Me.m_IndexAirport = Value
        End Set
    End Property

    Public Property IndexAirLine() As Int32
        Get
            Return Me.m_IndexAirLine
        End Get
        Set(ByVal Value As Int32)
            Me.m_IndexAirLine = Value
        End Set
    End Property

    Public Property IndexFreq() As Int32
        Get
            Return Me.m_IndexFreq
        End Get
        Set(ByVal Value As Int32)
            Me.m_IndexFreq = Value
        End Set
    End Property

    Public Property IndexStop() As Int32
        Get
            Return Me.m_IndexStop
        End Get
        Set(ByVal Value As Int32)
            Me.m_IndexStop = Value
        End Set
    End Property
    Public Property Landmark() As String
        Get
            Return Me.m_Landmark
        End Get
        Set(ByVal Value As String)
            Me.m_Landmark = Value
        End Set
    End Property

    Public Sub New()
        Me.m_BoroState = ""
        Me.m_StName = ""
        Me.m_StNo = ""
        Me.m_StCross = ""
        Me.m_City = ""

        Me.m_IsAirport = False

        Me.m_AirPort = ""
        Me.m_AirLine = ""

        Me.m_IndexAirport = 0
        Me.m_IndexAirLine = 0

        Me.m_IndexFreq = 0

        Me.m_IndexStop = 0   'add on 10/21 by wan
        Me.m_Landmark = ""
    End Sub
End Class

'Stops collection 
'Spring 2004/10/21
Public Class Stops
    Inherits System.Collections.CollectionBase
    Default Public Property Item(ByVal index As Integer) As StopOne
        Get
            Return CType(List(index), StopOne)
        End Get
        Set(ByVal Value As StopOne)
            List(index) = Value
        End Set
    End Property
    Public Function Add(ByVal s As StopOne) As Integer
        Return List.Add(s)
    End Function

    Public Sub Remove(ByVal index As Integer)
        List.RemoveAt(index)
    End Sub

End Class

#End Region