Imports DataAccess
Public Class Address
    Inherits CommonDB
    Private mPState As String
    Private mPCity As String
    Private mPStreetNo As String
    Private mPStreetName As String
    Private mPZip As String
    Private mPType As String

    Private mDState As String
    Private mDCity As String
    Private mDStreetNo As String
    Private mDStreetName As String
    Private mDZip As String
    Private mDType As String

    Private PZone As String = ""
    Private DZone As String = ""
    Private PriceTableId As String
    Private intAddrNo As Integer

    'Public Type As String
    Public errflag(1) As Integer
    Public dispzone(1) As String, pricezone(1) As String

    Public MatchPStreetName As String = ""
    Public MatchDStreetName As String = ""
    '## added by joey 1/2/2008
    Public mVerifyCity As String

    Public Sub New()
        Dim i As Integer
        For i = 0 To 1
            errflag(i) = -1
            dispzone(i) = ""
            pricezone(i) = ""
        Next


    End Sub

    '## added by joey 1/2/2008
    Public Property VerifyCity() As String
        Get
            Return mVerifyCity
        End Get
        Set(ByVal Value As String)
            mVerifyCity = Value
        End Set
    End Property

    Public Property PState() As String
        Get
            Return mPState
        End Get
        Set(ByVal Value As String)
            mPState = Value
        End Set
    End Property

    Public Property PCity() As String
        Get
            Return mPCity
        End Get
        Set(ByVal Value As String)
            mPCity = Value
        End Set
    End Property

    Public Property PStreetNo() As String
        Get
            Return mPStreetNo
        End Get
        Set(ByVal Value As String)
            mPStreetNo = Value
        End Set
    End Property

    Public Property PStreetName() As String
        Get
            Return mPStreetName
        End Get
        Set(ByVal Value As String)
            mPStreetName = Value
        End Set
    End Property

    Public Property PZip() As String
        Get
            Return mPZip
        End Get
        Set(ByVal Value As String)
            mPZip = Value
        End Set
    End Property

    Public Property PType() As String
        Get
            Return mPType
        End Get
        Set(ByVal Value As String)
            mPType = Value
        End Set
    End Property

    Public Property DState() As String
        Get
            Return mDState
        End Get
        Set(ByVal Value As String)
            mDState = Value
        End Set
    End Property

    Public Property DCity() As String
        Get
            Return mDCity
        End Get
        Set(ByVal Value As String)
            mDCity = Value
        End Set
    End Property

    Public Property DStreetNo() As String
        Get
            Return mDStreetNo
        End Get
        Set(ByVal Value As String)
            mDStreetNo = Value
        End Set
    End Property

    Public Property DStreetName() As String
        Get
            Return mDStreetName
        End Get
        Set(ByVal Value As String)
            mDStreetName = Value
        End Set
    End Property

    Public Property DZip() As String
        Get
            Return mDZip
        End Get
        Set(ByVal Value As String)
            mDZip = Value
        End Set
    End Property

    Public Property DType() As String
        Get
            Return mDType
        End Get
        Set(ByVal Value As String)
            mDType = Value
        End Set
    End Property

    '------------------------------------------------------------------------------
    '-- function verifystreetname(street)
    '-- This function will be inputed a street and it will try to match it with 
    '-- streets in the street table. If a direct match is not found then it will
    '-- run various convertions combinations till if finds the match. From the match
    '-- it will then try to match the street no, and boroughs within the results.
    '------------------------------------------------------------------------------
    Function verifystreetname(ByVal street As String, ByVal type As String) As String
        Dim strname As String, arrStreet As String(), strStElement As String, strNewStreet As String, strMatch As String
        Dim i As Integer, j As Integer, index As Integer
        If type = "P" Then
            index = 0
        Else
            index = 1
        End If
        strname = UCase(street)
        arrStreet = Split(strname, " ")

        Dim arrMatch(UBound(arrStreet) + 2) As String


        If check_table(strname) Then '---- If string is correct as inputed
            strMatch = strname
            arrMatch(0) = strMatch
        Else         '---- Do converstion and find if any are correct st names
            'Response.Write "START:<BR>"
            For j = 0 To UBound(arrStreet)
                strNewStreet = ""
                For i = 0 To UBound(arrStreet)
                    If i = j Then
                        If IsNumeric(Left(arrStreet(i), 1)) = False Then
                            strNewStreet = strNewStreet & convert_word(arrStreet(i)) & " "
                        Else
                            strNewStreet = strNewStreet & convert_number(arrStreet(i)) & " "
                        End If
                    Else
                        strNewStreet = strNewStreet & arrStreet(i) & " "
                    End If
                Next
                'Response.Write j & ":" & strNewStreet
                If check_table(Trim(strNewStreet)) = True Then
                    strMatch = strNewStreet
                    arrMatch(j) = strMatch
                    'Response.Write "<font class=match> <- MATCH</font> "
                End If
                'Response.Write "<br>"
            Next

            '---- Convert all words in street name and verify
            strNewStreet = ""
            For j = 0 To UBound(arrStreet)
                If IsNumeric(Left(arrStreet(j), 1)) = False Then
                    strNewStreet = strNewStreet & convert_word(arrStreet(j)) & " "
                Else
                    strNewStreet = strNewStreet & convert_number(arrStreet(j)) & " "
                End If
            Next
            'Response.Write j & ":" & strNewStreet
            If check_table(Trim(strNewStreet)) Then
                strMatch = strNewStreet
                arrMatch(j) = strMatch
                'Response.Write "<font class=match> <- MATCH</font> "
            End If
            'Response.Write "<br>"

            'Response.Write "END:<BR>"
        End If


        '------ If a street name match was found, then check st_no and state
        If strMatch <> "" Then
            strMatch = ""
            '---- Check array of matching street name 
            For j = 0 To UBound(arrMatch)
                If Trim(arrMatch(j)) <> "" Then
                    If type = "P" Then
                        If verifystreetno(Convert.ToInt32(PStreetNo), arrMatch(j), VerifyCity) = True Then
                            strMatch = arrMatch(j)
                        End If
                    Else
                        If verifystreetno(Convert.ToInt32(DStreetNo), arrMatch(j), VerifyCity) = True Then
                            strMatch = arrMatch(j)
                        End If
                    End If
                    'exit for
                End If
            Next

            If strMatch = "" Then  ' if st_no or county is not found
                errflag(index) = 2
                strMatch = ""
                PZone = ""
                DZone = ""
            End If
            verifystreetname = strMatch
        Else '-- Failed finding the street name
            errflag(index) = 1
            verifystreetname = ""
        End If

    End Function

    '------------------------------------------------------------------------------
    '-- function verifystreetno(streetno,streetname)
    '-- Once the street name has matched result(s) in the street borough table this
    '-- will verify the street no and borough.
    '------------------------------------------------------------------------------
    Function verifystreetno(ByVal streetno As Integer, ByVal streetname As String, ByVal state As String) As Boolean

        Dim SQLstr As String
        SQLstr = "select st_name,dispatch_zone,pricing_table_counter from street(nolock) where st_name = '" & sqlsafe(streetname) & "' and "
        SQLstr = SQLstr & " convert(int,from_st_no) <= '" & sqlsafe(streetno.ToString) & "' and convert(int,to_st_no) >= '" & sqlsafe(streetno.ToString) & "'"
        SQLstr = SQLstr & " and county = '" & sqlsafe(VerifyCity) & "' and st_no_type in ('0','" & getstreettype(streetno) & "')"

        Dim cdb As New CommonDB
        Dim ds As DataSet

        Try
            ds = cdb.QueryData(SQLstr, "street")
        Catch ex As Exception
            ds = Nothing
        End Try

        If Not ds Is Nothing Then
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    PZone = get_PZone(Convert.ToString(IIf(IsDBNull(ds.Tables(0).Rows(0).Item("pricing_table_counter")), "", ds.Tables(0).Rows(0).Item("pricing_table_counter").ToString)))
                    DZone = Convert.ToString(IIf(IsDBNull(ds.Tables(0).Rows(0).Item("dispatch_zone")), "", ds.Tables(0).Rows(0).Item("dispatch_zone").ToString))
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    '------------------------------------------------------------------------------
    '-- function get_PZone(ptc)
    '-- modifyed by joey    12/06/2007
    '------------------------------------------------------------------------------
    Private Function get_PZone(ByVal ptc As String) As String

        'If PriceTableId Is Nothing Then
        '    Throw New Exception("Must init price table id")
        'End If

        Dim pzone As String

        Dim SQLStr As String
        If PriceTableId Is Nothing Then
            SQLStr = "select top 1 pricing_zone from pricing_table(nolock) where pricing_table_counter = '" & sqlsafe(ptc) & "'"
        Else
            SQLStr = "select pricing_zone from pricing_table(nolock) where pricing_table_counter = '" & sqlsafe(ptc) & "'"
            SQLStr = SQLStr & " and pricing_table = '" & sqlsafe(PriceTableId) & "'"
        End If


        Dim cdb As New CommonDB
        Dim ds As DataSet

        Try
            ds = cdb.QueryData(SQLStr, "pricing_table")
        Catch ex As Exception
            ds = Nothing
        Finally
            cdb.Dispose()
            cdb = Nothing
        End Try

        If Not ds Is Nothing Then
            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                pzone = Convert.ToString(IIf(IsDBNull(ds.Tables(0).Rows(0).Item("pricing_zone")), "", ds.Tables(0).Rows(0).Item("pricing_zone").ToString))
            Else
                pzone = ""
            End If
        Else
            pzone = ""
        End If

        Return pzone
    End Function

    '------------------------------------------------------------------------------
    '-- function getstreettype(streetno)
    '-- This function checks if the street no is odd or even. Returns 1 odd, 2 even
    '------------------------------------------------------------------------------
    Private Function getstreettype(ByVal streetno As Integer) As Integer
        If streetno Mod 2 = 0 Then  '-- even
            getstreettype = 2
        Else         '-- odd
            getstreettype = 1
        End If
    End Function

    '------------------------------------------------------------------------------
    '-- function check_table(inputword)
    '-- This function will take-in a whole street name as input and check directly
    '-- against the street_borough table to see if there is a match
    '-- RETURNS: true: if matched / false: if no match is found
    '------------------------------------------------------------------------------
    Private Function check_table(ByVal inputword As String) As Boolean
        Dim strSQL As String = "select st_name from street(nolock) where st_name = '" & sqlsafe(inputword) & "'"

        Dim cdb As New CommonDB
        Dim ds As DataSet
        Try
            ds = cdb.QueryData(strSQL, "street")
        Catch ex As Exception
            ds = Nothing
        Finally
            cdb.Dispose()
            cdb = Nothing
        End Try

        'objRS = objConn.Execute(SQLStr)

        If Not ds Is Nothing Then
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Shared Function sqlsafe(ByVal inputvalue As String) As String

        If inputvalue Is Nothing Then
            sqlsafe = ""
        Else
            sqlsafe = Replace(inputvalue, "'", " ")
            sqlsafe = Replace(sqlsafe, ",", " ")
        End If
    End Function

    '------------------------------------------------------------------------------
    '-- function convert_word
    '-- This function will convert a word to a abbr. if a match is found in the 
    '-- verify_street table.  i.e. "street" -> "st"
    '------------------------------------------------------------------------------
    Public Shared Function convert_word(ByVal inputword As String) As String
        'Dim SQLStr, newword As String

        Dim cdb As New CommonDB
        Dim ds As DataSet

        Dim strSQL As String = "select output from verify_street(nolock) where input = '" & sqlsafe(inputword) & "' and search_type = 'w'"

        Try
            ds = cdb.QueryData(strSQL, "verifystreet")
        Catch ex As Exception
            ds = Nothing
        Finally
            cdb.Dispose()
            cdb = Nothing
        End Try

        Dim moreQuery As Boolean = True

        If Not ds Is Nothing Then
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    moreQuery = False
                    Return Trim(Convert.ToString(ds.Tables(0).Rows(0).Item("output")))
                Else
                    moreQuery = True
                End If
            Else
                moreQuery = True
            End If
        Else
            moreQuery = True
        End If

        If moreQuery = False Then
            Exit Function
        End If

        Dim cdb2 As New CommonDB
        Dim ds2 As DataSet
        strSQL = "select output from verify_street(nolock) where input like '" & sqlsafe(Right(inputword, 3)) & "' and search_type = 's'"

        Try
            ds2 = cdb.QueryData(strSQL, "verifystreet")
        Catch ex As Exception
            ds2 = Nothing
        Finally
            cdb2.Dispose()
            cdb2 = Nothing
        End Try

        If Not ds2 Is Nothing Then
            If ds2.Tables.Count > 0 Then
                If ds2.Tables(0).Rows.Count > 0 Then
                    moreQuery = False
                    Return Left(inputword, (Len(inputword) - 3)) & Trim(Convert.ToString(ds2.Tables(0).Rows(0).Item("output")))
                Else
                    Return inputword
                End If
            Else
                Return inputword
            End If
        Else
            Return inputword
        End If
    End Function

    ''------------------------------------------------------------------------------
    ''-- function convert_number
    ''-- This function will convert any group of numbers (like 10th,1rst) to the 
    ''-- proper abbreviation defined in the verify_street table. i.e. 10th -> 10
    ''------------------------------------------------------------------------------
    Public Shared Function convert_number(ByVal inputword As String) As String

        Dim cdb As New CommonDB
        Dim ds As DataSet

        Dim strSQL As String = "select output from verify_street(nolock) where input like '" & sqlsafe(Right(inputword, 3)) & "' and search_type = 's'"

        Try
            ds = cdb.QueryData(strSQL, "verifystreet")
        Catch ex As Exception
            ds = Nothing
        Finally
            ds.Dispose()
            ds = Nothing
        End Try

        If Not ds Is Nothing Then
            If ds.Tables.Count > 0 Then
                Return Left(inputword, (Len(inputword) - 3)) & Convert.ToString(IIf(IsDBNull(ds.Tables(0).Rows(0).Item("output")), "", ds.Tables(0).Rows(0).Item("output").ToString))
            Else
                Return inputword
            End If
        Else
            Return inputword
        End If
    End Function

    '------------------------------------------------------------------------------
    '-- function is_borough(statecode)
    '## modifyed by joey    12/06/2007
    '------------------------------------------------------------------------------
    Function is_borough(ByVal statecode As String, ByVal QueensIsBoro As Boolean) As Boolean
        'Select Case statecode.ToUpper()
        '    Case "M", "BX", "QU", "SI", "BK", "MANHATTAN", "QUEENS", "BROOKLYN", "BRONX", "STATEN ISLAND"
        '        Return True
        '    Case Else
        '        Return False
        'End Select
        Dim out As Boolean = False

        Select Case statecode.Trim().ToLower
            Case "m", "bx", "bk", "si", "manhattan", "brooklyn", "bronx", "staten island"
                out = True
            Case "qu", "queens"
                out = QueensIsBoro
            Case Else
                out = False
        End Select

        Return out
    End Function

    '------------------------------------------------------------------------------
    '-- sub verify_OT(city,state)
    '------------------------------------------------------------------------------
    Sub verify_OT(ByVal city As String, ByVal state As String, ByVal index As Integer)
        'objConn = server.CreateObject("ADODB.Connection")
        'objConn.Open(Application.Contents("ConnectionString"))

        Dim SQLStr As String = "select pricing_table_counter,dispatch_zone from city(nolock) where name = '" & sqlsafe(city) & "' and state = '" & sqlsafe(state) & "'"

        'Response.Write SQLStr

        'objRS = objConn.execute(SQLStr)
        Dim cdb As New CommonDB
        cdb.OpenConnection()
        cdb.Command.CommandType = CommandType.Text
        cdb.Command.CommandText = SQLStr
        Try
            cdb.Reader = cdb.Command.ExecuteReader(CommandBehavior.SingleRow)

            If cdb.Reader.Read Then
                'newword = Convert.ToString(cdb.Reader.Item("output")).Trim
                pricezone(index) = get_PZone(Convert.ToString(cdb.Reader.Item("pricing_table_counter")).Trim)
                dispzone(index) = Trim(Convert.ToString(cdb.Reader.Item(1)))
                'errflag(intAddrNo) = 4
                errflag(index) = 4
            Else
                'errflag(intAddrNo) = 3
                errflag(index) = 3
            End If

        Catch ex As Exception
            'errflag(intAddrNo) = 3
            errflag(index) = 3
        Finally
            cdb.Reader.Close()
            cdb.CloseConnection()
        End Try
    End Sub

    '------------------------------------------------------------------------------
    '-- is_airport(statecode)
    '------------------------------------------------------------------------------
    Function is_airport(ByVal statecode As String) As Boolean

        Dim tmpdzone As String, tmppzone As String

        Dim SQLStr As String = "select code from county_state_airport(nolock) where code = '" & sqlsafe(statecode) & "'"

        Dim cdb As New CommonDB
        cdb.OpenConnection()
        cdb.Command.CommandType = CommandType.Text
        cdb.Command.CommandText = SQLStr
        Try
            cdb.Reader = cdb.Command.ExecuteReader(CommandBehavior.SingleRow)
            If cdb.Reader.Read Then
                'SQLStr = "select distinct airport, dispatch_zone from airline(nolock) "
                'SQLStr = SQLStr & " where dispatch_zone != '0' and airport = '" & sqlsafe(statecode) & "'"
                'cdb.Command.CommandText = SQLStr
                'cdb.Reader = cdb.Command.ExecuteReader(CommandBehavior.SingleRow)
                'If cdb.Reader.Read Then
                '    tmpdzone = Trim(Convert.ToString(cdb.Reader.Item("dispatch_zone")))
                'Else
                '    tmpdzone = ""
                'End If
                'tmppzone = statecode

                'DZone = tmpdzone
                'PZone = tmppzone
                Return True
            Else
                PZone = ""
                DZone = ""
                Return False
            End If
        Catch ex As Exception
            PZone = ""
            DZone = ""
            Return False
        Finally
            cdb.CloseConnection()
            cdb.Dispose()
            cdb = Nothing
        End Try
    End Function

    '## added by joey   1/2/2008
    '## 1/25/2008   change "Select Case city" to "Select Case city.ToLower()"   yang
    Function ChangeBoro(ByVal city As String) As String
        Select Case city.Trim().ToLower()
            Case "manhattan", "m"
                Return "M"
            Case "queens", "qu"
                Return "QU"
            Case "brooklyn", "bk"
                Return "BK"
            Case "bronx", "bx"
                Return "BX"
            Case "staten island", "si"
                Return "SI"
        End Select
    End Function

    Public Sub Verify()
        '----- If PICKUP or BOTH then process PICKUP Address
        If PType.Equals("0") Then
            If PState = "NY" AndAlso is_borough(PCity, True) = True Then
                Me.mVerifyCity = ChangeBoro(PCity)
                Verify_City("P")
                MatchPStreetName = verifystreetname(PStreetName, "P")
                If MatchPStreetName <> "" Then
                    dispzone(0) = DZone
                    pricezone(0) = PZone
                End If
            ElseIf is_airport(PState) Then
                dispzone(0) = DZone
                pricezone(0) = PZone
                errflag(0) = 4
            Else
                MatchPStreetName = PStreetName
                verify_OT(PCity, PState, 0)
            End If
        End If
        '----- IF DESTINATION or BOTH, then process DESTINATION Address
        If DType.Equals("0") Then
            If is_borough(DCity, True) = True AndAlso DState = "NY" Then
                Me.mVerifyCity = ChangeBoro(DCity)
                Verify_City("D")
                MatchDStreetName = verifystreetname(DStreetName, "D")
                If MatchDStreetName <> "" Then
                    dispzone(1) = DZone
                    pricezone(1) = PZone
                End If
            ElseIf is_airport(DState) Then
                dispzone(1) = DZone
                pricezone(1) = PZone
                errflag(1) = 4
            Else
                MatchDStreetName = DStreetName
                verify_OT(DCity, DState, 1)
            End If
        End If

    End Sub
    '------------------------------------------------------------------------------
    '-- modifyed by joey    12/06/2007
    '------------------------------------------------------------------------------
    Private Sub Verify_City(ByVal type As String)

        Dim strSQL As String
        Dim index As Integer
        If (type.Equals("P")) Then
            strSQL = "select count(*) from street where county='" & sqlsafe(Me.VerifyCity) & "'"
            index = 0
        ElseIf (type.Equals("D")) Then
            strSQL = "select count(*) from street where county='" & sqlsafe(Me.VerifyCity) & "'"
            index = 1
        End If

        Dim cdb As New CommonDB
        Try
            cdb.OpenConnection()
            cdb.Command.CommandType = CommandType.Text
            cdb.Command.CommandText = strSQL
            cdb.Reader = cdb.Command.ExecuteReader(CommandBehavior.SingleRow)
            If cdb.Reader.Read Then
                If Convert.ToInt32(cdb.Reader.Item(0)) <= 0 Then
                    Me.errflag(index) = 3
                    Exit Sub
                Else
                    If (type.Equals("P")) Then
                        Verify_StreetName("P")
                    Else
                        Verify_StreetName("D")
                    End If
                End If
            Else
                Me.errflag(index) = -1
            End If
        Catch ex As Exception

        Finally
            cdb.CloseConnection()
            cdb.Dispose()
            cdb = Nothing
        End Try
    End Sub
    '------------------------------------------------------------------------------
    '-- modifyed by joey    12/06/2007
    '------------------------------------------------------------------------------
    Private Sub Verify_StreetName(ByVal type As String)
        Dim strSQL As String
        Dim index As Integer
        If (type.Equals("P")) Then
            strSQL = "select count(*) from street where county='" & sqlsafe(Me.VerifyCity) & "' and st_name='" & sqlsafe(Me.PStreetName) & "'"
            index = 0
        ElseIf (type.Equals("D")) Then
            strSQL = "select count(*) from street where county='" & sqlsafe(Me.VerifyCity) & "' and (st_name='" & sqlsafe(Me.DStreetName) & "' or '" & sqlsafe(Me.DStreetName) & "'='')"
            index = 1
        End If

        Dim cdb As New CommonDB
        Try
            cdb.OpenConnection()
            cdb.Command.CommandType = CommandType.Text
            cdb.Command.CommandText = strSQL
            cdb.Reader = cdb.Command.ExecuteReader(CommandBehavior.SingleRow)
            If cdb.Reader.Read Then
                If Convert.ToInt32(cdb.Reader.Item(0)) <= 0 Then
                    Me.errflag(index) = 1
                    Exit Sub
                Else
                    If (type.Equals("P")) Then
                        Verify_StreetNumber("P")
                    Else
                        Verify_StreetNumber("D")
                    End If
                End If
            Else
                Me.errflag(index) = -1
            End If
        Catch ex As Exception

        Finally
            cdb.CloseConnection()
            cdb.Dispose()
            cdb = Nothing
        End Try
    End Sub
    '------------------------------------------------------------------------------
    '-- modifyed by joey    12/06/2007
    '------------------------------------------------------------------------------
    Private Sub Verify_StreetNumber(ByVal type As String)
        Dim strSQL As String
        Dim index As Integer
        If (type.Equals("P")) Then
            strSQL = "select count(*) from street(nolock) where st_name = '" & sqlsafe(Me.PStreetName) & "' and (IsNUMERIC(TO_ST_NO)=1 and IsNUMERIC(from_ST_NO)=1) and convert(int,from_st_no) <= '" & sqlsafe(Me.PStreetNo.Trim) & "' and convert(int,to_st_no) >=  '" & sqlsafe(Me.PStreetNo.Trim) & "' and st_no_type in ('0',(case when( '" & sqlsafe(Me.PStreetNo.Trim) & "' % 2 = 0) then '2' else '1' end ) ) and county='" & sqlsafe(Me.VerifyCity) & "'"
            index = 0
        ElseIf (type.Equals("D")) Then
            strSQL = "select count(*) from street(nolock) where (st_name = '" & sqlsafe(Me.DStreetName) & "' or '" & sqlsafe(Me.DStreetName) & "'='') and (IsNUMERIC(TO_ST_NO)=1 and IsNUMERIC(from_ST_NO)=1) and ((convert(int,from_st_no) <= '" & sqlsafe(Me.DStreetNo.Trim) & "' and convert(int,to_st_no) >=  '" & sqlsafe(Me.DStreetNo.Trim) & "' and st_no_type in ('0',(case when( '" & sqlsafe(Me.DStreetNo.Trim) & "' % 2 = 0) then '2' else '1' end ) )) or '" & sqlsafe(Me.DStreetNo.Trim) & "'='') and county='" & sqlsafe(Me.VerifyCity) & "'"
            index = 1
        End If

        Dim cdb As New CommonDB
        Try
            cdb.OpenConnection()
            cdb.Command.CommandType = CommandType.Text
            cdb.Command.CommandText = strSQL
            cdb.Reader = cdb.Command.ExecuteReader(CommandBehavior.SingleRow)
            If cdb.Reader.Read Then
                If Convert.ToInt32(cdb.Reader.Item(0)) <= 0 Then
                    Me.errflag(index) = 2
                    Exit Sub
                Else
                    Me.errflag(index) = 0
                End If
            Else
                Me.errflag(index) = -1
            End If
        Catch ex As Exception

        Finally
            cdb.CloseConnection()
            cdb.Dispose()
            cdb = Nothing
        End Try
    End Sub

    '## 11/30/2007  yang
    Public Function GetClosetStreet(ByVal strState As String, ByVal strStreet As String, ByRef iMode As Int16) As DataSet

        iMode = -1
        Dim dsStreet As New DataSet

        '--1)   search with "lookup" Algorithm for partial valid input
        Dim objGeo As New GeoInfos
        dsStreet = objGeo.GetStreetNameForStreetLookUp(strState, strStreet)
        objGeo.Dispose()
        objGeo = Nothing

        If Not dsStreet Is Nothing AndAlso dsStreet.Tables.Count > 0 AndAlso dsStreet.Tables(0).Rows.Count > 0 Then
            iMode = 1
        Else
            '--2) search with new Algorithm for mis_spelling input
            Dim arrStreet(), strWord, strSQL, strField As String
            strWord = ""
            strField = "st_name" ' the street field name

            arrStreet = strStreet.Split(Convert.ToChar(" "))
            If UBound(arrStreet) > 0 Then
                For i As Integer = 0 To UBound(arrStreet)
                    If isCoreWord(arrStreet(i)) Then
                        If i = 0 Then
                            strWord &= arrStreet(i)
                        Else
                            strWord &= " " & arrStreet(i)
                        End If
                    Else
                        strWord &= "%"
                    End If
                Next
            End If

            Dim arrMatch As New ArrayList
            For i As Integer = 0 To strWord.Length - 1
                arrMatch.Add(strWord.Substring(0, i) & "%" & strWord.Substring(i + 1, strWord.Length - i - 1))
            Next


            strSQL = "SELECT DISTINCT st_name FROM street(NOLOCK) WHERE county='" & strState & "' "
            If arrMatch.Count > 0 Then
                strSQL &= "AND ( "
                For i As Integer = 0 To arrMatch.Count - 2
                    strSQL &= strField & " LIKE '" & Convert.ToString(arrMatch.Item(i)) & "' OR "
                Next
                strSQL &= strField & "  LIKE '" & Convert.ToString(arrMatch.Item(arrMatch.Count - 1)) & "')"
            Else
                strSQL &= " AND " & strField & " LIKE '" & strStreet & "%' "
            End If

            dsStreet = Me.QueryData(strSQL, "street")

            If Not dsStreet Is Nothing AndAlso dsStreet.Tables.Count > 0 AndAlso dsStreet.Tables(0).Rows.Count > 0 Then
                iMode = 2
            End If
        End If

        Return dsStreet
    End Function

    Private Function isCoreWord(ByVal strWord As String) As Boolean
        Dim sql As String
        sql = "SELECT COUNT(*) FROM (" & _
                    "SELECT 1 FROM verify_street(NOLOCK) WHERE [input]='" & strWord & "' OR [output]='" & strWord & "'"

        If strWord.Length > 1 AndAlso IsNumeric(Left(strWord, 1)) Then
            sql &= "UNION SELECT 1 FROM verify_street(NOLOCK) WHERE search_type='s' AND ([input]=RIGHT('" & strWord & "',3) OR [output]=RIGHT('" & strWord & "',1))"
        End If

        sql &= ") t"

        Dim iIsCoreWord As Int16 = 1
        If IsNumeric(strWord) Then
            iIsCoreWord = -1
        Else
            Try
                Me.OpenConnection()
                With Me.Command
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Parameters.AddWithValue("@strWord", strWord)
                    iIsCoreWord = Convert.ToInt16(.ExecuteScalar())
                End With
            Catch ex As Exception
                Me.ErrorMessage = ex.Message
            Finally
                Me.CloseConnection()
            End Try

            If iIsCoreWord = -1 Then
                Return False
            Else
                Return True
            End If
        End If
    End Function
End Class
