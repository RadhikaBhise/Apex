Imports DataAccess
Imports System.Data.SqlClient

Public Class GeoInfos
    Inherits CommonDB

#Region "Get GeoInfo Functions"


    '------------------------------------------------------------------------------
    '-- Function: isAirportOn
    '-- Description:  to check if the airport is on
    '-- Output: boolean
    '-- Table: county_state_airport
    '-- Stored Procedure: MTC_wr_CountyStateAirport_isOn
    '-- 23/03/06 - Created (Daniel)
    '------------------------------------------------------------------------------
    Public Function isAirportOn(ByVal strStateAbbre As String) As Boolean
        Dim i As Int16
        Me.OpenConnection()
        With Me.Command
            .CommandText = "MTC_wr_CountyStateAirport_isOn"
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@code", strStateAbbre)
            Try
                i = Convert.ToInt16(.ExecuteScalar)
            Catch ex As Exception
            Finally
                Me.CloseConnection()
            End Try
        End With

        If i = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    'Public Function GetCityName(ByVal strcity As String) As DataSet
    '    Dim strsql As String
    '    strsql = "select distinct top 500 city.name,city.county,city.state,p.pricing_zone from city(nolock) left join "
    '    strsql = strsql & " pricing_table p on city.pricing_table_counter = p.pricing_table_counter where ltrim(rtrim(name)) like '" & Trim(sqlsafe(strcity)) & "%'"
    '    'strsql = "select name,county,state,price_zone from city(nolock) where ltrim(rtrim(name)) like '" & Trim(strcity) & "%' order by name,state,county"
    '    Return Me.QueryData(strsql, "cityname")

    'End Function
    'Public Function GetCityName(ByVal strcity As String) As DataSet
    '    Dim strsql As String
    '    strsql = "exec mtc_wr_query_city_state '" & sqlsafe(strcity) & "'"
    '    'strsql = "select name,county,state,price_zone from city(nolock) where ltrim(rtrim(name)) like '" & Trim(strcity) & "%' order by name,state,county"
    '    Return Me.QueryData(strsql, "GetCityName")

    'End Function
    'Public Function GetByCityName(ByVal strcity As String) As DataSet
    '    Dim strsql As String
    '    strsql = "exec mtc_wr_query_city_Name '" & sqlsafe(strcity) & "'"
    '    'strsql = "select name,county,state,price_zone from city(nolock) where ltrim(rtrim(name)) like '" & Trim(strcity) & "%' order by name,state,county"
    '    Return Me.QueryData(strsql, "GetByCityName")

    'End Function
    'Public Function GetCityName_Zone(ByVal strcity As String, ByVal strstate As String, ByRef GetCity_Zone As DataSet) As String
    '    Dim strsql As String
    '    Dim DS As New DataSet

    '    strsql = "exec mtc_wr_query_city_state_zone '" & sqlsafe(strcity) & "','" & sqlsafe(strstate) & "'"
    '    'strsql = "select name,county,state,price_zone from city(nolock) where ltrim(rtrim(name)) like '" & Trim(strcity) & "%' order by name,state,county"
    '    Try
    '        DS = Me.QueryData(strsql, "GetCityName_Zone")
    '    Catch ex As Exception
    '        DS = Nothing
    '    End Try

    '    If Not DS Is Nothing Then
    '        If DS.Tables.Count > 0 Then
    '            If DS.Tables(0).Rows.Count > 0 Then
    '                If DS.Tables(0).Rows.Count > 1 Then
    '                    GetCity_Zone = DS
    '                    GetCityName_Zone = Me.Check_DBNULL(DS.Tables(0).Rows(0).Item("pricing_zone"))
    '                Else
    '                    GetCity_Zone = Nothing
    '                    GetCityName_Zone = Me.Check_DBNULL(DS.Tables(0).Rows(0).Item("pricing_zone"))
    '                End If
    '            Else
    '                GetCity_Zone = Nothing
    '                GetCityName_Zone = ""
    '            End If
    '        Else
    '            GetCity_Zone = Nothing
    '            GetCityName_Zone = ""
    '        End If
    '    Else
    '        GetCity_Zone = Nothing
    '        GetCityName_Zone = ""
    '    End If

    '    Return GetCityName_Zone

    'End Function
    'Public Function GetByblur_city_State(ByVal strcity As String, ByVal strstate As String) As DataSet
    '    Dim strsql As String
    '    strsql = "exec mtc_wr_query_city_state_blur_zone '" & sqlsafe(strcity) & "','" & sqlsafe(strstate) & "'"
    '    'strsql = "select name,county,state,price_zone from city(nolock) where ltrim(rtrim(name)) like '" & Trim(strcity) & "%' order by name,state,county"
    '    Return Me.QueryData(strsql, "GetByblur_city_State")

    'End Function

    Public Function Get_Price_Zone(ByVal strcity As String, ByVal strstate As String) As DataSet
        Dim strsql As String
        strsql = "select name,county,state,price_zone from city(nolock) "
        strsql = strsql & " where ltrim(rtrim(name)) like '" & Trim(strcity) & "%' and ltrim(rtrim(state))='" & Trim(strstate) & "'"
        strsql = strsql & " order by name,state,county"
        Return Me.QueryData(strsql, "cityname")

    End Function

    '------------------------------------------------------------------------------
    '-- Function: getAllAirport
    '-- Description:  Get all airports
    '-- Output: DataSet
    '-- Table: county_state_airport
    '-- Stored Procedure: mtcwr_CountyStateAirport_getAirports
    '-- 03/07/06 - Created (eJay)
    '-- AirportCode     IF null or "" THEN all airports ELSE code = AirportCode
    '-- AirportName     IF null or "" THEN all airports ELSE description like AirportName
    '-- StateCode       IF null or "" THEN all states   ELSE type = StateCode
    '------------------------------------------------------------------------------
    Public Function getAllAirport(ByVal AirportCode As String, ByVal AirportName As String, ByVal StateCode As String) As DataSet
        Return Me.QueryData(String.Format("exec apex_geo_getairport '{0}','{1}','{2}',''", AirportCode, AirportName, StateCode), "airports")
    End Function

    '------------------------------------------------------------------------------
    '-- Function: getAllStateAirport
    '-- Description:  Get all Airline
    '-- Output: DataSet
    '-- Table: MTC_webride_states
    '-- Stored Procedure: MTC_wr_SkylimoWebrideStates_getStates
    '-- 11/23/07 - Created (yang)
    '-- AirportCode     IF null or "" THEN all airline ELSE code = AirportCode
    '-- Airline     IF null or "" THEN all airline ELSE airline like Airline
    '------------------------------------------------------------------------------
    Public Function getAllAirline(ByVal AirportCode As String, ByVal Airline As String) As DataSet
        Return Me.QueryData(String.Format("exec apex_geo_getairline '{0}','{1}'", AirportCode, Airline), "airline")
    End Function
    Public Function GetAirlineStringByAirport(ByVal AirportCode As String) As String
        Dim out As String = ""

        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "apex_geo_getairline"

                .Parameters.Clear()
                .Parameters.AddWithValue("@airport", AirportCode)
                .Parameters.AddWithValue("@airline", "")
                .Parameters.Add("@airlineinfo", SqlDbType.VarChar, 8000)
                .Parameters.Item("@airlineinfo").Direction = ParameterDirection.Output

                .ExecuteNonQuery()

                out = Convert.ToString(.Parameters.Item("@airlineinfo").Value).Trim()
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try

        Return out
    End Function
    Public Function GetAirportStringByState(ByVal StateCode As String) As String
        Dim out As String = ""

        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "apex_geo_getairport"

                .Parameters.Clear()
                .Parameters.AddWithValue("@code", "")
                .Parameters.AddWithValue("@name", "")
                .Parameters.AddWithValue("@state", StateCode)
                .Parameters.Add("@airportinfo", SqlDbType.VarChar, 8000)
                .Parameters.Item("@airportinfo").Direction = ParameterDirection.Output

                .ExecuteNonQuery()

                out = Convert.ToString(.Parameters.Item("@airportinfo").Value).Trim
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try

        Return out
    End Function

    '------------------------------------------------------------------------------
    '-- Function: getAllAirport
    '-- Description:  Get all airports
    '-- Output: DataSet
    '-- Table: county_state_airport
    '-- Stored Procedure: mtcwr_CountyStateAirport_getAirports
    '-- 03/07/06 - Created (eJay)
    '------------------------------------------------------------------------------
    Public Function getAllAirport_Airline() As DataSet

        Return Me.QueryData("exec MTC_wr_get_airport_all", "airportall")

    End Function
    '------------------------------------------------------------------------------
    '-- function Get_Price_code(strname)
    '-- 9/13/05 Check if the Get_Price_code is set for this vip (Naoki)
    '-- 05/29/06 add by (daniel)
    '------------------------------------------------------------------------------
    Public Function Get_Price(ByVal strtable_id As String, ByVal strfromzone As String, ByVal strtozone As String) As String
        Dim SQLStr As String
        Dim dr As DataSet
        '-- check for duplicates --
        SQLStr = "select price from price"
        SQLStr = SQLStr & " where from_zone='" & strfromzone & "' and to_zone='" & strtozone & "' and table_id='" & strtable_id & "'"

        dr = Me.QueryData(SQLStr, "price")
        If dr.Tables(0).Rows.Count > 0 Then
            'do nothing
            Get_Price = Convert.ToString(IIf(IsDBNull(dr.Tables(0).Rows(0).Item(0).ToString), "", dr.Tables(0).Rows(0).Item(0).ToString))
        Else
            Get_Price = ""
        End If

        dr.Dispose()
        dr = Nothing

        Return Get_Price

    End Function
    '------------------------------------------------------------------------------
    '-- function Get_Price_code(strname)
    '-- 9/13/05 Check if the Get_Price_code is set for this vip (Naoki)
    '-- 05/29/06 add by (daniel)
    '------------------------------------------------------------------------------
    Public Function Get_Price_code(ByVal strname As String) As String
        Dim SQLStr As String
        Dim dr As DataSet
        '-- check for duplicates --
        SQLStr = "select price_code from city"
        SQLStr = SQLStr & " where name='" & strname & "'"

        dr = Me.QueryData(SQLStr, "vip")
        If dr.Tables(0).Rows.Count > 0 Then
            'do nothing
            Get_Price_code = Convert.ToString(IIf(IsDBNull(dr.Tables(0).Rows(0).Item(0).ToString), "", dr.Tables(0).Rows(0).Item(0).ToString))
        Else
            Get_Price_code = ""
        End If

        dr.Dispose()
        dr = Nothing

        Return Get_Price_code

    End Function
    '------------------------------------------------------------------------------
    '-- Function: getAllStateAirport
    '-- Description:  Get all states
    '-- Output: DataSet
    '-- Table: mtc_webride_states
    '-- Stored Procedure: mtcwr_WebrideStates_getStates
    '-- 11/23/2007  (yang)
    '-- type    1: boro 2: ot   3: airport
    '-- code    if null then all else state_code=code
    '-- name    if null then all else state_name like name
    '------------------------------------------------------------------------------
    Public Function getAllState(ByVal type As String, ByVal code As String, ByVal name As String) As DataSet
        Return Me.QueryData(String.Format("exec apex_geo_getstates {0},'{1}','{2}'", type, code, name), "states")
    End Function

    '-------------------------------------------------------
    'Function: GetStatesType
    'InPut:               iType        
    '                     1    Boro & Town
    '                     2    OT
    '                     3    Airport
    '                     12    Boro & Town & OT.
    '                     23    OT & Airport
    '                     and so on
    'OutPut:              states info 
    '-------------------------------------------------------
    Public Function GetStates(ByVal Type As String, ByVal Code As String, ByVal Name As String) As DataSet
        Dim sql As String = String.Format("EXEC apex_geo_getstates '{0}','{1}','{2}'", Type, Code, Name)
        Return Me.QueryData(sql, "state")
    End Function
    ''-------------------------------------------------------
    ''Function: GetLocationInfo
    ''Description: Get all Location info where active_flag = 'Y'
    ''Modification: 2004/10/15 wan
    ''Table:              pu_locations
    ''InPut:             Sql: select * from pu_locations where active_flag ='y'
    ''OutPut:           All location info 
    ''-------------------------------------------------------
    'Public Function GetLocationInfo() As DataSet
    '    Dim tmpDS As DataSet
    '    tmpDS = Me.QueryData("exec gswr_pu_locations_select ", "location")
    '    Return tmpDS
    'End Function

    ''-------------------------------------------------------
    ''Function: GetAirInfo
    ''Description: Get all Air Info 
    ''Modification: 2004/10/17 Cooker
    ''Table:              airline,states
    ''InPut:            
    ''OutPut:          DataSet includes two tables:
    ''                         Tables("airport")   airport info
    ''                         Tables("airline")   airline info
    ''-------------------------------------------------------

    'Public Function GetAirInfo() As DataSet
    '    Dim tmpDS As DataSet
    '    tmpDS = Me.QueryData("select airport,airline,pu_point_1,pu_point_2,pu_point_3,pu_point_4,pu_point_5 from airline(nolock),states where airport=state_code order by airline", "tmpdt")

    '    'get table "airline"
    '    Dim tmpDT As DataTable
    '    If tmpDS.Tables.Count > 0 Then
    '        tmpDT = tmpDS.Tables(0).Copy
    '        tmpDT.TableName = "airline"
    '    End If

    '    'get table "airport"
    '    tmpDS = Me.QueryData("select state_code,state_name from states(nolock) where state_type=3 order by state_name", "airport")
    '    If Not tmpDT Is Nothing Then
    '        tmpDS.Tables.Add(tmpDT)
    '    End If

    '    Return tmpDS

    'End Function

    '-------------------------------------------------------
    'Function: GetOfficeAddr
    'Description: Get the Office Address
    'Modification: 2004/10/17 Tom
    'Table:           user_profile,pu_locations
    'InPut:           Pick up index
    'OutPut:          Location Object
    '-------------------------------------------------------
    Public Function GetOfficeAddr(ByVal strIndex As String) As Location
        Dim objLocation As New Location
        Dim strSQL As String
        Dim tmpDS As DataSet

        strSQL = "select * from pu_locations where Pu_Index='" + strIndex + "'"
        tmpDS = Me.QueryData(strSQL, "offAddress")

        If tmpDS.Tables.Count > 0 Then
            If tmpDS.Tables(0).Rows.Count > 0 Then
                With tmpDS.Tables(0).Rows(0)
                    objLocation.State = CStr(.Item("State")).Trim
                    objLocation.StNo = CStr(.Item("St_No")).Trim
                    objLocation.StName = CStr(.Item("St_Name")).Trim
                    objLocation.City = CStr(.Item("City")).Trim
                    objLocation.ZipCode = CStr(.Item("Zip_Code")).Trim
                End With
            End If
        End If

        Return objLocation
    End Function

    '-------------------------------------------------------
    'Function: GetLandmarks
    'Description: Get All Landmarks
    'Modification: 2004/10/17 Tom
    'Table:           landmark
    'InPut:           
    'OutPut:          landmark info
    '-------------------------------------------------------
    Public Function GetLandmarks() As DataSet
        Dim tmpDS As DataSet
        Dim strSQL As String

        strSQL = "select * from landmark"
        tmpDS = Me.QueryData(strSQL, "landmarks")

        Return tmpDS
    End Function

    ''-------------------------------------------------------
    ''Function: GetFreq
    ''Description: Get freq_pu or freq_dest of the user
    ''Modification: 2006/03/06 eJay
    ''Table:           vip_disp_add
    ''InPut:           user_id ,type('P' or 'D')
    ''OutPut:          Freq info
    ''-------------------------------------------------------
    'Public Function GetFreq(ByVal strUser_ID As String, ByVal Acct_ID As String, ByVal Sub_acct_id As String, ByVal strType As String) As DataSet
    '    Dim tmpDS As DataSet
    '    Dim strSQL As String

    '    If strType.CompareTo("P") = 0 Or strType.CompareTo("p") = 0 Then
    '        strSQL = "select address_type,st_no,suite,st_name,x_st,city,county,area,phone,ext,pu_point_1,zip,landmark from vip_disp_add where user_id='" + strUser_ID + "' and acct_id='" + Acct_ID + "' and sub_acct_id='" + Sub_acct_id + "' order by lfu DESC"  'address_counter"
    '    Else
    '        strSQL = "select address_type,st_no,suite,st_name,x_st,city,county,area,phone,ext,pu_point_1,zip,landmark from vip_disp_add where user_id='" + strUser_ID + "' and acct_id='" + Acct_ID + "' and sub_acct_id='" + Sub_acct_id + "' order by lfu DESC"    'address_counter"
    '    End If

    '    tmpDS = Me.QueryData(strSQL, "Freq")

    '    Return tmpDS
    'End Function


    '------------------------------------------------------------------------------
    '-- Function: getstrname
    '-- Description: 
    '-- Input: strStname,strState,strCity
    '-- Output: DataSet
    '-- Table: street
    '-- Stored Procedure: skylimo_wr_street_getstr_name
    '-- 11/04/04 - Created (jack)
    '------------------------------------------------------------------------------
    Public Function getStrName(ByVal strStname As String, _
                                ByVal strState As String, _
                                ByVal strCity As String) As DataSet
        Dim tmpDS As DataSet
        With SelectCommand
            .CommandText = "skylimo_wr_street_getstr_name"
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@strstate", strState)
            .Parameters.AddWithValue("@strcity", strCity)
            .Parameters.AddWithValue("@strname", strStname)

        End With

        tmpDS = Me.QueryData("strname")

        Return tmpDS
    End Function

#End Region

#Region "Geo Look Up Functions"

    '-------------------------------------------------------
    '--Function:GetLandmarkForCityNameLookUp
    '--Description:Get Landmark for City and Name LookUp
    '--Intput:City,Name
    '--Output:
    '--11/16/04 - Created (eJay)
    '-------------------------------------------------------
    Public Function GetLandmarkForCityNameLookUp(ByVal state As String, ByVal City As String, ByVal landmark As String) As DataSet

        Return Me.QueryData("EXEC mtc_wr_landmark_landmarksearch '" & state & "','" & City & "','" & landmark & "'", "Landmark")

    End Function
    '-------------------------------------------------------
    'Function: GetStreetNameForCityLookUp
    'Description: GetStreetNameForCityLookUp
    'Modification: 2004/10/18 wan
    'Table:           price_ot_zone
    'InPut:           state,city
    'OutPut:          DataSet of StreetName Info
    '-------------------------------------------------------
    Public Function GetStreetNameForCityLookUp(ByVal state As String, ByVal city As String) As DataSet
        Return Me.QueryData("exec gswr_getstreetname_for_citylookup '" & state & "','" & city & "'", "price_ot_zone")
    End Function

    '-------------------------------------------------------
    '--Function: GetStreetNameForStreetLookUp
    '--Description: GetStreetNameForStreetLookUp
    '--Modification: 2004/10/18 wan
    '--Modify by eJay 11/30/04 add x_st
    '--Table:           street
    '--InPut:           state,city
    '--OutPut:          DataSet of StreetName Info
    '-------------------------------------------------------
    'Public Function GetStreetNameForStreetLookUp(ByVal state As String, ByVal street As String, ByVal strcity As String) As DataSet
    '    'Dim sqlstr As String = "select distinct st_name,county,city,zip_code,x_st,from_st_no,to_st_no from street(nolock) where state = '" & Trim(state) & "' and city = '" & Trim(strcity) & "'"
    '    'sqlstr = sqlstr & " and st_name like '" & Trim(street) & "%' order by st_name"
    '    'Return Me.QueryData(sqlstr, "streetlookup")
    '    Return Me.QueryData("exec MTC_wr_Street_lookup '" & state & "','" & strcity & "','" & street & "'", "GetStreetNameForStreetLookUp")
    'End Function
    '------------------------------------------------------------
    '--add by daniel for streetlookup1.aspx
    '------------------------------------------------------------
    Public Function GetStreetNameForStreetLookUp1(ByVal state As String, ByVal street As String) As DataSet
        'Dim sqlstr As String = "select distinct top 500 county,st_name,city,zip_code,x_st,from_st_no,to_st_no from street(nolock) where county = '" & state & "' "
        Dim sqlstr As String = "select distinct top 500 st_name,county from street(nolock) where county = '" & state & "' "
        If street = "ALL" Then
            '--do nothing
            sqlstr = " order by st_name"
        Else
            sqlstr = sqlstr & " and st_name like '%" & street & "%' order by st_name"
        End If

        Return Me.QueryData(sqlstr, "streetlookup1")
    End Function
    Public Function GetStreetNameForStreetLookUp(ByVal state As String, ByVal city As String, ByVal street As String, ByVal strStNo As String) As DataSet
        'Dim sqlstr As String = "select distinct county,st_name,city,zip_code,x_st,from_st_no,to_st_no from street where rtrim(ltrim(city))='" & city & "' and  rtrim(ltrim(st_name)) like '" & street & "%' "
        Dim sqlstr As String = "apex_geo_getstreetname"
        Dim tmpDs As DataSet

        'If strStNo.Trim.Length > 0 Then
        '    sqlstr &= " AND CAST(CASE ISNUMERIC(from_st_no) WHEN 1 THEN from_st_no ELSE 0 END AS INT)<= " & strStNo & _
        '                " AND CAST(CASE ISNUMERIC(to_st_no) WHEN 1 THEN to_st_no ELSE 999 END AS INT)>= " & strStNo & ""
        'End If
        'sqlstr &= " order by st_name,county,city,from_st_no"

        '## add by joey
        Try
            Me.OpenConnection()
            Me.SelectCommand = New SqlCommand
            With Me.SelectCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = sqlstr
                .Parameters.AddWithValue("@state", state)
                .Parameters.AddWithValue("@city", city)
                .Parameters.AddWithValue("@street", street)
                .Parameters.AddWithValue("@strStNo", strStNo)

            End With
            tmpDs = Me.QueryData("streetlookup")
        Catch ex As Exception

        Finally
            Me.CloseConnection()
        End Try

        If strStNo.Trim.Length > 0 Then
            Try
                If tmpDs Is Nothing Or tmpDs.Tables(0).Rows.Count < 2 Then
                    'do nothing
                Else
                    Dim i, j, count As Integer
                    Dim length As Integer = tmpDs.Tables(0).Rows.Count
                    Dim values(length) As String
                    ' initialize valuse (get street name)
                    For i = 0 To length - 1
                        values(i) = Convert.ToString(tmpDs.Tables(0).Rows(i)(0)).Trim
                    Next
                    Dim deleteRow As DataRow
                    For i = 0 To length - 1
                        If i > 0 Then
                            count = 0
                            For j = 0 To i - 1
                                'opinion if has multinomial value ,then clean it 
                                If (values(i) = values(j)) Then
                                    count += 1
                                End If
                            Next
                            'delete data rows
                            If count > 0 Then
                                deleteRow = tmpDs.Tables(0).Rows(i)
                                deleteRow.Delete()
                            End If
                        End If
                    Next
                End If
            Catch ex As Exception
                'do nothing
            End Try
        End If
        Return tmpDs
    End Function

    '-------------------------------------------------------
    'Function: GetStreetNoForStreetNoLookUp
    'Description: GetStreetNoForStreetNoLookUp
    'Modification: 2004/10/18 wan
    'Table:           street
    'InPut:           state,st_name
    'OutPut:          DataSet of StreetNo Info
    '-------------------------------------------------------
    Public Function GetStreetNoForStreetNoLookUp(ByVal state As String, ByVal st_name As String) As DataSet
        Dim sqlstr As String = "select x_st,from_st_no,to_st_no from street(NOLOCK) where county = '" & state & "' "
        sqlstr = sqlstr & " and st_name = '" & st_name & "' order by st_name"   ' modified 04/10/22 nancy  street_borough->street
        Return Me.QueryData(sqlstr, "strNo")
    End Function

    '------------------------------------------------------------------------------
    '-- public function: street_name_lookup	1/29/04
    '-- Description: This function is used by the street lookup function. It will generate a array
    '-- of similar street names for the street lookup sql query to perform a like statement on. 
    '-- Creator: Nancy, Modified: Wan
    '-- Table:      null
    '-- Input:      street
    '-- Output:     Array of street info
    '------------------------------------------------------------------------------
    Public Function street_name_lookup(ByVal street As String) As Array
        Dim strname, arrStreet(), arrMatch(), strNewStreet As String
        Dim i, j, index_counter As Integer

        strname = UCase(street)
        '-- remove any % symbols the user might have entered --
        strname = Replace(strname, "%", " ")
        arrStreet = Split(strname, " ")

        If UBound(arrStreet) = 0 And is_direction(arrStreet(0)) Then
            strNewStreet = ""
            strNewStreet = convert_word(arrStreet(0))
            ReDim arrMatch(3)
            arrMatch(0) = "%" & arrStreet(0) & "%"
            arrMatch(1) = strNewStreet & " %"
            arrMatch(2) = "% " & strNewStreet & " %"
            arrMatch(3) = strNewStreet & " %"
        Else
            If UBound(arrStreet) = 0 And IsNumeric(Left(arrStreet(0), 1)) Then
                strNewStreet = ""
                strNewStreet = convert_number(arrStreet(0))
                ReDim arrMatch(3)
                arrMatch(0) = "%" & arrStreet(0) & "%"
                arrMatch(1) = strNewStreet & " %"
            Else
                ReDim arrMatch(((UBound(arrStreet) + 1) * 2) + 3) '-- create array to hold all temporary address
                index_counter = 0
                For j = 0 To UBound(arrStreet) '-- tells which token to convert
                    strNewStreet = ""
                    For i = 0 To UBound(arrStreet) '-- go through whole street name / convert only active token
                        If i = j Then

                            If IsNumeric(Left(arrStreet(i), 1)) = False Then '-- if token is not numeric then convert word
                                strNewStreet = strNewStreet & convert_word(arrStreet(i)) & " "
                            Else '-- if token is numeric then convert number
                                strNewStreet = strNewStreet & convert_number(arrStreet(i)) & " "
                            End If
                        Else
                            strNewStreet = strNewStreet & arrStreet(i) & " "
                        End If
                    Next
                    strNewStreet = "%" & Trim(strNewStreet) & "%" '-- add % for search statement
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
                strNewStreet = "%" & Trim(strNewStreet) & "%"

                '-- Insert orignal street name as search value --
                arrMatch(index_counter) = "%" & Trim(strname) & "%"
                index_counter = index_counter + 1

                '-- Special Case --
                '-- Insert a sql "%" around words that do not convert to a street suffix (ie st, ave, blvd) --
                '-- UPDATED SPECIAL CASE --
                For j = 0 To UBound(arrStreet) '-- tells which token to convert
                    strNewStreet = ""
                    For i = 0 To UBound(arrStreet) '-- go through whole street name / convert only active token
                        If i = j Then
                            If IsNumeric(Left(arrStreet(i), 1)) = False Then '-- if token is not numeric then convert word
                                'strNewStreet = strNewStreet & convert_word(arrStreet(i))
                                Select Case convert_word(arrStreet(i))
                                    Case "N", "S", "W", "E"
                                        Select Case i
                                            Case 0
                                                strNewStreet = strNewStreet & convert_word(arrStreet(i)) & " %"
                                            Case UBound(arrStreet)
                                                strNewStreet = strNewStreet & "% " & convert_word(arrStreet(i))
                                            Case Else
                                                strNewStreet = strNewStreet & "% " & convert_word(arrStreet(i)) & " %"
                                        End Select
                                    Case Else
                                        If i = 0 Then
                                            strNewStreet = "%" & strNewStreet
                                        End If
                                        strNewStreet = strNewStreet & convert_word(arrStreet(i))
                                        If i <= UBound(arrStreet) - 1 Then
                                            strNewStreet = strNewStreet & "%"
                                        End If
                                End Select
                            Else '-- if token is numeric then convert number
                                If i = 0 Then
                                    strNewStreet = "%" & strNewStreet
                                End If
                                strNewStreet = strNewStreet & convert_number(arrStreet(i))
                                If i <= UBound(arrStreet) - 1 Then
                                    strNewStreet = strNewStreet & "%"
                                End If
                            End If
                        Else
                            'strNewStreet = strNewStreet & arrStreet(i)
                            Select Case arrStreet(i)
                                Case "N", "S", "W", "E"
                                    Select Case i
                                        Case 0
                                            strNewStreet = strNewStreet & arrStreet(i) & " %"
                                        Case UBound(arrStreet)
                                            strNewStreet = strNewStreet & "% " & arrStreet(i)
                                        Case Else
                                            strNewStreet = strNewStreet & "% " & arrStreet(i) & " %"
                                    End Select
                                Case Else
                                    If i = 0 Then
                                        strNewStreet = "%" & strNewStreet
                                    End If
                                    strNewStreet = strNewStreet & arrStreet(i)
                                    If i <= UBound(arrStreet) - 1 Then
                                        strNewStreet = strNewStreet & "%"
                                    End If
                            End Select
                            'strNewStreet = strNewStreet & "%"
                        End If
                    Next

                    'Response.Write "%" & trim(strNewStreet) & "%" & "<br>" '-- add % for search statement
                    strNewStreet = Trim(strNewStreet) & "%"
                    If is_in_array(arrMatch, Trim(strNewStreet)) = False Then
                        arrMatch(index_counter) = Trim(strNewStreet)
                    End If
                    index_counter = index_counter + 1
                Next

                '---- Convert all words in street name and verify
                strNewStreet = ""
                For j = 0 To UBound(arrStreet)
                    If IsNumeric(Left(arrStreet(j), 1)) = False Then
                        'strNewStreet = strNewStreet & convert_word(arrStreet(j))
                        Select Case convert_word(arrStreet(j))
                            Case "N", "S", "W", "E"
                                Select Case j
                                    Case 0
                                        strNewStreet = strNewStreet & convert_word(arrStreet(j)) & " %"
                                    Case UBound(arrStreet)
                                        strNewStreet = strNewStreet & "% " & convert_word(arrStreet(j))
                                    Case Else
                                        strNewStreet = strNewStreet & "% " & convert_word(arrStreet(j)) & " %"
                                End Select
                            Case Else
                                If j = 0 Then
                                    strNewStreet = "%" & strNewStreet
                                End If
                                strNewStreet = strNewStreet & convert_word(arrStreet(j))
                                If j <= UBound(arrStreet) - 1 Then
                                    strNewStreet = strNewStreet & "%"
                                End If
                        End Select
                    Else
                        If j = 0 Then
                            strNewStreet = "%" & strNewStreet
                        End If
                        strNewStreet = strNewStreet & convert_number(arrStreet(j))
                        If j <= UBound(arrStreet) - 1 Then
                            strNewStreet = strNewStreet & "%"
                        End If
                    End If
                Next
                strNewStreet = Trim(strNewStreet) & "%"
                If is_in_array(arrMatch, Trim(strNewStreet)) = False Then
                    arrMatch(index_counter) = Trim(strNewStreet)
                End If
                index_counter = index_counter + 1

                strNewStreet = ""
                For j = 0 To UBound(arrStreet)
                    If IsNumeric(Left(arrStreet(j), 1)) = False Then
                        'strNewStreet = strNewStreet & arrStreet(j)
                        Select Case arrStreet(j)
                            Case "N", "S", "W", "E"
                                Select Case j
                                    Case 0
                                        strNewStreet = strNewStreet & arrStreet(j) & " %"
                                    Case UBound(arrStreet)
                                        strNewStreet = strNewStreet & arrStreet(j) & "% "
                                    Case Else
                                        strNewStreet = strNewStreet & "% " & arrStreet(j) & " %"
                                End Select
                            Case Else
                                If j = 0 Then
                                    strNewStreet = "%" & strNewStreet
                                End If
                                strNewStreet = strNewStreet & arrStreet(j)
                                If j <= UBound(arrStreet) - 1 Then
                                    strNewStreet = strNewStreet & "%"
                                End If
                        End Select
                    Else
                        If j = 0 Then
                            strNewStreet = "%" & strNewStreet
                        End If
                        strNewStreet = strNewStreet & convert_number(arrStreet(j))
                        If j <= UBound(arrStreet) - 1 Then
                            strNewStreet = strNewStreet & "%"
                        End If
                    End If
                Next
                strNewStreet = Trim(strNewStreet) & "%"
                If is_in_array(arrMatch, Trim(strNewStreet)) = False Then
                    arrMatch(index_counter) = Trim(strNewStreet)
                End If
                index_counter = index_counter + 1
            End If
        End If
        '-- return array --
        'street_name_lookup = arrMatch
        Return arrMatch
    End Function

    '------------------------------------------------------------------------------
    '-- private function: convert_word
    '-- This function will convert a word to a abbr. if a match is found in the 
    '-- verify_street table.  i.e. "street" -> "st"  private Function only for: 'street_name_lookup','verifystreetname'
    '-- Modified:       wan
    '-- Table:          verify_street
    '-- Input:          string of inputword
    '-- Output:         string of new word
    '------------------------------------------------------------------------------
    Private Function convert_word(ByVal inputword As String) As String
        Dim SQLStr, newword As String

        SQLStr = "select output from verify_street(nolock) where input = '" & Replace(inputword, "'", "''") & "' and search_type = 'w'"

        Me.OpenConnection()
        Me.Command.CommandType = CommandType.Text
        Me.Command.CommandText = SQLStr
        Try
            Me.Reader = Me.Command.ExecuteReader(CommandBehavior.SingleRow)

            If Me.Reader.Read Then
                newword = Convert.ToString(Me.Reader.Item("output")).Trim
            Else
                SQLStr = "select output from verify_street(nolock) where input like '" & Replace(Right(inputword, 3), "'", "''") & "' and search_type = 's'"
                Me.Command.CommandType = CommandType.Text
                Me.Command.CommandText = SQLStr

                Me.Reader = Me.Command.ExecuteReader(CommandBehavior.SingleRow)

                If Me.Reader.Read Then
                    newword = Left(inputword, (Len(inputword) - 3)) & Convert.ToString(Me.Reader.Item("output")).Trim
                Else
                    newword = inputword
                End If
            End If
            Me.Reader.Close()
        Catch ex As Exception
            newword = inputword
        Finally
            Me.CloseConnection()
        End Try
        Return newword
    End Function

    '------------------------------------------------------------------------------
    '-- Private function: convert_number   Only For: 'street_name_lookup','verifystreetname'
    '-- This function will convert any group of numbers (like 10th,1rst) to the 
    '-- proper abbreviation defined in the verify_street table. i.e. 10th -> 10 
    '-- Modified:       wan
    '-- Table:          verify_street
    '-- Input:          string of inputword
    '-- Output:         string of newword
    '------------------------------------------------------------------------------
    Private Function convert_number(ByVal inputword As String) As String
        Dim newword, sqlstr As String

        sqlstr = "select output from verify_street(nolock) where input like '" & Replace(Right(inputword, 3), "'", "''") & "' and search_type = 's'"

        Me.OpenConnection()
        Me.Command.CommandType = CommandType.Text
        Me.Command.CommandText = sqlstr
        Try
            Me.Reader = Me.Command.ExecuteReader(CommandBehavior.SingleRow)

            If Me.Reader.Read Then
                newword = Left(inputword, (Len(inputword) - 3)) & Convert.ToString(Me.Reader.Item("output")).Trim
            Else
                newword = inputword
            End If
            Me.Reader.Close()
        Catch ex As Exception
            newword = inputword
        Finally
            Me.CloseConnection()
        End Try
        Return newword
    End Function
    '------------------------------------------------------------------------------
    '-- private function: is_in_array   Only For: 'street_name_lookup'
    '-- Description:    return the truth if the array contains such object
    '-- Modified:       wan
    '-- Table:          nothing
    '-- Input:          array_value = The array ; search_value = The value to search
    '-- Output:         boolean
    '--             true:   Value is in Array
    '--             false:  Value not in Array
    '------------------------------------------------------------------------------
    Private Function is_in_array(ByVal array_value As Array, ByVal search_value As Object) As Boolean
        'Dim bol_value As Boolean
        'bol_value = False
        'For i As Integer = 0 To UBound(array_value)
        '    If StrComp(Trim(Convert.ToString(array_value(i))), search_value.Trim, 1) = 0 Then
        '        bol_value = True
        '        Exit For
        '    End If
        'Next
        'is_in_array = bol_value
        If (Array.BinarySearch(array_value, search_value) >= 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    '------------------------------------------------------------------------------
    '-- private function: is_direction 2004/10/18
    '-- Description: This function is private and only for: 'street_name_lookup'
    '-- Modified:       Wan
    '-- Table:          verify_street
    '-- Input:          streetname  
    '-- Output:         true:   st_name is direction
    '--                 false:  st_name is not direction
    '------------------------------------------------------------------------------
    Private Function is_direction(ByVal streetname As String) As Boolean
        Dim SQLStr, newword As String
        Dim bolIsDirection As Boolean

        SQLStr = "select verify_street.input from verify_street(nolock) where search_type = 'w' "
        SQLStr = SQLStr & " and isnumeric(verify_street.output) = 0 "
        SQLStr = SQLStr & " and (input = '" & Replace(streetname, "'", "''") & "' or output = '" & Replace(streetname, "'", "''") & "' )"
        SQLStr = SQLStr & " and (verify_street.output = 'N' or verify_street.output = 'S' or verify_street.output = 'W' or verify_street.output = 'E')"
        Try
            Me.OpenConnection()
            Me.Command.CommandType = CommandType.Text
            Me.Command.CommandText = SQLStr
            Me.Reader = Me.Command.ExecuteReader(CommandBehavior.CloseConnection)
            If Me.Reader.Read Then
                bolIsDirection = True
            Else
                bolIsDirection = False
            End If
            Me.Reader.Close()
        Catch ex As Exception
            bolIsDirection = False
        Finally
            Me.CloseConnection()
        End Try
        Return bolIsDirection
    End Function
    '-- private function: is_borough
    '-- Modified:       wan
    '-- Input:          st_name
    '-- Output:         true:   st_name is borough
    '                   flase:  st_name is not borough
    Private Function is_borough(ByVal statecode As String) As Boolean
        Select Case statecode
            Case "M", "BX", "QU", "SI", "BK"
                Return True
            Case Else
                Return False
        End Select
    End Function
    '-- Private function: is_airport
    '-- description: 
    '-- Modified:       wan
    '-- Input:          state
    '-- Output          true:   address is airport
    '--                 false:  address is not airport
    Private Function is_airport(ByVal statecode As String) As Boolean
        Dim value As Boolean
        If statecode = "EWR" Then
            statecode = "NWK"
        End If
        If statecode = "LGA" Then
            statecode = "LAG"
        End If

        Dim dzone, pzone, SQLStr As String
        SQLStr = "select distinct airport from airline(nolock) where airport = '" '& Security.SQLSafe(statecode) & "'"
        Try
            Me.OpenConnection()
            Me.Command.CommandType = CommandType.Text
            Me.Command.CommandText = SQLStr
            Me.Reader = Me.Command.ExecuteReader
            If Me.Reader.Read Then
                SQLStr = "select distinct airport, dispatch_zone from airline(nolock) "
                SQLStr = SQLStr & " where dispatch_zone != '0' and airport = '" '& Security.SQLSafe(statecode) & "'"
                Me.Command.CommandText = SQLStr
                Me.Reader.Close()
                Me.Reader = Me.Command.ExecuteReader
                If Me.Reader.Read Then
                    'mdisp_zone = Security.StrOut(Me.Reader.Item("dispatch_zone"))
                Else
                    'mdisp_zone = ""
                End If
                If statecode = "NWK" Then
                    'mprice_zone = "73003"
                Else
                    'mprice_zone = statecode
                End If
                value = True
            Else
                value = False
            End If
            Me.Reader.Close()
        Catch ex As Exception
            value = False
        Finally
            Me.CloseConnection()
        End Try
        Return value
    End Function

    Public Function getLandmarkInfoByCountyCityAndLandmark(ByVal strCounty As String, ByVal strCity As String, ByVal strLandmark As String) As DataSet
        Try
            Dim sqlstr As String = "SELECT state,city,[name],county,st_name,st_no,x_st,zip_code,phone,direction FROM landmark WHERE state='" & strCounty & "' and city = '" & strCity & "' AND [name] = '" & strLandmark & "'"
            Return Me.QueryData(sqlstr, "landmarkinfo")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    '-- Private function: getAllCountyFromLandmark
    '-- description:  Get all County from landmark
    '-- Input:          
    '-- Output:  dataset of states
    '-- Created 2005-4-22 (Ming)
    Public Function getAllCountyFromLandmark() As DataSet
        Try
            Dim sqlstr As String = "select distinct state from landmark order by state"
            Return Me.QueryData(sqlstr, "counties")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    '-- Private function: getCityFromLandmarkByCounty
    '-- description:  Get city from landmark by county
    '-- Input: state         
    '-- Output:  dataset of cities 
    '-- Created 2005-4-22 (Ming)
    Public Function getCityFromLandmarkByCounty(ByVal strCounty As String) As DataSet
        Try
            Dim sqlstr As String = "select DISTINCT city from landmark(NOLOCK) where state ='" & strCounty & "' order by city"
            Return Me.QueryData(sqlstr, "cities")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    '-- Private function: getLandmarkFromLandmarkByCountyAndCity
    '-- description: Get landmark from landmark by county and city
    '-- Input: state,city        
    '-- Output:  dataset of landmarks
    '-- Created 2005-4-22 (Ming)
    '## Modifyed by joey    12/05/2007
    Public Function getLandmarkFromLandmarkByCountyAndCity(ByVal strCounty As String, ByVal strLandmark As String) As DataSet

        'Try
        '    Me.OpenConnection()
        '    With Me.Command
        '        .CommandType = CommandType.StoredProcedure
        '        .CommandText = "APEX_wr_lookuplandmark"

        '        .Parameters.Clear()
        '        .Parameters.AddWithValue("@state", strCounty)
        '        .Parameters.AddWithValue("@landmark", strLandmark)
        '        .ExecuteNonQuery()

        '    End With
        'Catch ex As Exception
        'Finally
        '    Me.CloseConnection()
        'End Try

        'Return Me.QueryData("landmark")
        Return Me.QueryData(String.Format("exec APEX_wr_lookuplandmark '{0}','{1}'", strCounty, strLandmark), "landmark")
    End Function
    '## added by joey   1/2/2008
    Public Function getBoroByState() As DataSet
        Try
            Dim sqlstr As String

            sqlstr = "select name=description from county_state_town"

            Return Me.QueryData(sqlstr, "cities")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function getCityFromCityByStateAndCityHeader(ByVal strState As String, ByVal strCityHeader As String) As DataSet
        Try
            Dim sqlstr As String
            If strCityHeader <> "" Then
                sqlstr = "select DISTINCT name from city(NOLOCK) where state='" & strState.Trim & "' and name like '" & strCityHeader.Trim & "%' order by name"
            Else
                Return Nothing
            End If
            'Dim sqlstr As String = "select name from city where state='MD' and name like '" & strCityHeader.Trim & "%' order by name"
            Return Me.QueryData(sqlstr, "cities")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function getCityFromCityHeader(ByVal strCityHeader As String) As DataSet
        Try
            Dim sqlstr As String = "select DISTINCT name from city(NOLOCK) where name like '" & strCityHeader.Trim & "%' order by name"
            'Dim sqlstr As String = "select name from city where state='MD' and name like '" & strCityHeader.Trim & "%' order by name"
            Return Me.QueryData(sqlstr, "cities")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

#Region "Geo Operate Function"

    '-------------------------------------------------------
    'Function: insert order
    'Description: Save Stops
    'Modification: 11/02/2004
    'Table:             stops
    'Input:             OrderData
    'OutPut:            
    '                    1    Successful
    '                    -1,0   Fail to Save
    '-------------------------------------------------------
    Public Function insertorder(ByVal straddress1 As String, ByVal straddress2 As String) As Int16
        Dim iResult As Int16
        Me.OpenConnection()
        Try
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "skylimo_wr_find_dist_insert"
                .Parameters.Clear()
                .Parameters.AddWithValue("@strAddr1", straddress1)
                .Parameters.AddWithValue("@strAddr2", straddress2)
                iResult = Convert.ToInt16(.ExecuteNonQuery)
            End With
        Catch ex As Exception
            iResult = -1
        End Try
        Me.CloseConnection()
        Return iResult
    End Function
#End Region

#Region " Geo Receipt Function"

  


    '-------------------------------------------------------------------
    '--Function:Check_DBNULL
    '--Description:Check the value 
    '--Input:Value
    '--Output:Nothing for DBNULL
    '--11/4/04 - Created (eJay)
    '-------------------------------------------------------------------
    Public Function Check_DBNULL(ByVal Value As Object) As String

        If IsDBNull(Value) = True Then
            Return Nothing
        Else
            Return Convert.ToString(Value)
        End If

    End Function

    '-------------------------------------------------------------------
    '--Function:Check_DBNULL_Double
    '--Description:Check the value 
    '--Input:Value
    '--Output:Nothing for DBNULL
    '--11/4/04 - Created (eJay)
    '-------------------------------------------------------------------
    Private Function Check_DBNULL_Double(ByVal Value As Object) As Double

        If IsDBNull(Value) = True Then
            Return Nothing
        Else
            Return Convert.ToDouble(Value)
        End If

    End Function

    '-------------------------------------------------------------------
    '--Function:Check_DBNULL_Date
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

    '-------------------------------------------------------------------
    '--Function:Check_DBNULL_Short
    '--Description:Check the value 
    '--Input:Value
    '--Output:Nothing for DBNULL
    '--11/4/04 - Created (eJay)
    '-------------------------------------------------------------------
    Private Function Check_DBNULL_Short(ByVal Value As Object) As Int16

        If IsDBNull(Value) = True Then
            Return Nothing
        Else
            Return Convert.ToInt16(Value)
        End If

    End Function

    '-------------------------------------------------------------------
    '--Function:Check_DBNULL_Int
    '--Description:Check the value 
    '--Input:Value
    '--Output:Nothing for DBNULL
    '--11/4/04 - Created (eJay)
    '-------------------------------------------------------------------
    Private Function Check_DBNULL_Int(ByVal Value As Object) As Int32

        If IsDBNull(Value) = True Then
            Return Nothing
        Else
            Return Convert.ToInt32(Value)
        End If

    End Function

  

#End Region

#Region " Geo Verify Address"

    Public Function verify_OT(ByVal city As String, ByVal state As String, ByVal Table_id As String, ByRef price_zone As String, ByRef disp_zone As String) As Boolean

        Dim StrSQL As String
        Dim drReader As SqlClient.SqlDataReader
        Dim blnResult As Boolean = False

        StrSQL = "mtcwr_verify_OT"
        Try

            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = StrSQL
                .Parameters.AddWithValue("@city", city)
                .Parameters.AddWithValue("@state", state)
                .Parameters.AddWithValue("@table_id", Table_id)
                drReader = .ExecuteReader()

            End With
            If drReader.Read() Then

                price_zone = drReader.Item("pricing_zone").ToString
                disp_zone = drReader.Item("dispatch_zone").ToString
                blnResult = True

            End If

        Catch ex As Exception

        Finally
            Me.CloseConnection()
        End Try

        Return blnResult

    End Function

    Public Function verifystreetno(ByVal streetno As Int32, ByVal streetname As String, ByVal state As String) As Boolean

        Dim StrSql As String

        StrSql = "select st_name,dispatch_zone,pricing_table_counter from street(nolock) where st_name = '" & streetname & "' and "
        StrSql &= " convert(int,from_st_no) <= '" & streetno & "' and convert(int,to_st_no) >= '" & streetno & "'"
        StrSql &= " and county = '" & state & "' and st_no_type in ('0','" & getstreettype(streetno) & "')"

    End Function

    Public Function getstreettype(ByVal streetno As Int32) As String
        If streetno Mod 2 = 0 Then  '-- even
            getstreettype = "2"
        Else         '-- odd
            getstreettype = "1"
        End If
    End Function

    '------------------------------------------------------------------
    '-Function:GetAllPrice
    '--Description:Get price exp:base_rate,tolls,parking,stops_amt,wait_amount,service_fee,miscellaneous,O_T_surcharge_amt......Voucher_archive table
    '--Input:Conf_No
    '--Output:All of requirment price
    '--06/12/05 - Created (Daniel)
    '------------------------------------------------------------------
    Public Function GetAllPrice(ByVal Conf_No As String) As VoucherData

        Dim strSQL As String
        strSQL = "MTC_wr_voucherarchive_getprice"

        Dim objVoucherData As New VoucherData

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@confirmation_no", Conf_No)

                Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)

                If Me.Reader.Read Then

                    With objVoucherData
                        'price
                        .net = Me.Check_DBNULL_Double(Me.Reader.Item("net"))
                        .base_rate = Me.Check_DBNULL_Double(Me.Reader.Item("base_rate"))
                        .tolls = Me.Check_DBNULL_Double(Me.Reader.Item("tolls"))
                        .parking = Me.Check_DBNULL_Double(Me.Reader.Item("parking"))
                        .stops_amt = Me.Check_DBNULL_Double(Me.Reader.Item("stops_amt"))
                        .wait_amount = Me.Check_DBNULL_Double(Me.Reader.Item("wait_amount"))
                        .stop_wt_amount = Me.Check_DBNULL_Double(Me.Reader.Item("stop_wt_amount"))
                        .phone_amt = Me.Check_DBNULL_Double(Me.Reader.Item("phone_amt"))
                        .service_fee = Me.Check_DBNULL_Double(Me.Reader.Item("service_fee"))
                        .miscellaneous = Me.Check_DBNULL_Double(Me.Reader.Item("miscellaneous"))
                        .OT_surcharge_amt = Me.Check_DBNULL_Double(Me.Reader.Item("OT_surcharge_amt"))
                        .tips = Me.Check_DBNULL_Double(Me.Reader.Item("tips"))
                        .cash_layout = Me.Check_DBNULL_Double(Me.Reader.Item("cash_layout"))
                        .certif_discount = Me.Check_DBNULL_Double(Me.Reader.Item("certif_discount"))
                        .Discount = Me.Check_DBNULL_Double(Me.Reader.Item("Discount"))
                        .stop_wt_amount = Me.Check_DBNULL_Double(Me.Reader.Item("stop_wt_amount"))
                        .package_amt = Me.Check_DBNULL_Double(Me.Reader.Item("package_amt"))
                        .STC_charges = Me.Check_DBNULL_Double(Me.Reader.Item("STC_charges"))
                        .meet_greet_amt = Me.Check_DBNULL_Double(Me.Reader.Item("meet_greet_amt"))
                    End With

                    Me.Reader.Close()

                End If


            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Return objVoucherData

    End Function

    '## 11/30/2007  yang
    Public Function LookUpStreetName_(ByVal street As String) As Array
        Dim strname, arrStreet(), arrMatch(), strNewStreet As String
        Dim i, j, index_counter As Integer

        street = Security.SQLSafe(street)

        strname = UCase(street)
        strname = Replace(strname, "%", " ")
        arrStreet = Split(strname, " ")

        If UBound(arrStreet) = 0 And IsDirection(arrStreet(0)) Then
            strNewStreet = ""
            strNewStreet = Address.Convert_Word(arrStreet(0))
            ReDim arrMatch(3)
            arrMatch(0) = "%" & arrStreet(0) & "%"
            arrMatch(1) = strNewStreet & " %"
            arrMatch(2) = "% " & strNewStreet & " %"
            arrMatch(3) = strNewStreet & " %"
        Else
            If UBound(arrStreet) = 0 And IsNumeric(Left(arrStreet(0), 1)) Then
                strNewStreet = ""
                strNewStreet = Address.Convert_Number(arrStreet(0))
                ReDim arrMatch(3)
                arrMatch(0) = "%" & arrStreet(0) & "%"
                arrMatch(1) = strNewStreet & " %"
            Else
                ReDim arrMatch(((UBound(arrStreet) + 1) * 2) + 3) '-- create array to hold all temporary address
                index_counter = 0
                For j = 0 To UBound(arrStreet) '-- tells which token to convert
                    strNewStreet = ""
                    For i = 0 To UBound(arrStreet) '-- go through whole street name / convert only active token
                        If i = j Then

                            If IsNumeric(Left(arrStreet(i), 1)) = False Then '-- if token is not numeric then convert word
                                strNewStreet = strNewStreet & Address.Convert_Word(arrStreet(i)) & " "
                            Else '-- if token is numeric then convert number
                                strNewStreet = strNewStreet & Address.Convert_Number(arrStreet(i)) & " "
                            End If
                        Else
                            strNewStreet = strNewStreet & arrStreet(i) & " "
                        End If
                    Next
                    strNewStreet = "%" & Trim(strNewStreet) & "%" '-- add % for search statement
                Next

                '---- Convert all words in street name and verify
                strNewStreet = ""
                For j = 0 To UBound(arrStreet)
                    If IsNumeric(Left(arrStreet(j), 1)) = False Then
                        strNewStreet = strNewStreet & Address.Convert_Word(arrStreet(j)) & " "
                    Else
                        strNewStreet = strNewStreet & Address.Convert_Number(arrStreet(j)) & " "
                    End If
                Next
                strNewStreet = "%" & Trim(strNewStreet) & "%"

                '-- Insert orignal street name as search value --
                arrMatch(index_counter) = "%" & Trim(strname) & "%"
                index_counter = index_counter + 1

                '-- Special Case --
                '-- Insert a sql "%" around words that do not convert to a street suffix (ie st, ave, blvd) --
                '-- UPDATED SPECIAL CASE --
                For j = 0 To UBound(arrStreet) '-- tells which token to convert
                    strNewStreet = ""
                    For i = 0 To UBound(arrStreet) '-- go through whole street name / convert only active token
                        If i = j Then
                            If IsNumeric(Left(arrStreet(i), 1)) = False Then '-- if token is not numeric then convert word
                                'strNewStreet = strNewStreet & address.convert_word(arrStreet(i))
                                Select Case Address.Convert_Word(arrStreet(i))
                                    Case "N", "S", "W", "E"
                                        Select Case i
                                            Case 0
                                                strNewStreet = strNewStreet & Address.Convert_Word(arrStreet(i)) & " %"
                                            Case UBound(arrStreet)
                                                strNewStreet = strNewStreet & "% " & Address.Convert_Word(arrStreet(i))
                                            Case Else
                                                strNewStreet = strNewStreet & "% " & Address.Convert_Word(arrStreet(i)) & " %"
                                        End Select
                                    Case Else
                                        If i = 0 Then
                                            strNewStreet = "%" & strNewStreet
                                        End If
                                        strNewStreet = strNewStreet & Address.Convert_Word(arrStreet(i))
                                        If i <= UBound(arrStreet) - 1 Then
                                            strNewStreet = strNewStreet & "%"
                                        End If
                                End Select
                            Else '-- if token is numeric then convert number
                                If i = 0 Then
                                    strNewStreet = "%" & strNewStreet
                                End If
                                strNewStreet = strNewStreet & Address.Convert_Number(arrStreet(i))
                                If i <= UBound(arrStreet) - 1 Then
                                    strNewStreet = strNewStreet & "%"
                                End If
                            End If
                        Else
                            'strNewStreet = strNewStreet & arrStreet(i)
                            Select Case arrStreet(i)
                                Case "N", "S", "W", "E"
                                    Select Case i
                                        Case 0
                                            strNewStreet = strNewStreet & arrStreet(i) & " %"
                                        Case UBound(arrStreet)
                                            strNewStreet = strNewStreet & "% " & arrStreet(i)
                                        Case Else
                                            strNewStreet = strNewStreet & "% " & arrStreet(i) & " %"
                                    End Select
                                Case Else
                                    If i = 0 Then
                                        strNewStreet = "%" & strNewStreet
                                    End If
                                    strNewStreet = strNewStreet & arrStreet(i)
                                    If i <= UBound(arrStreet) - 1 Then
                                        strNewStreet = strNewStreet & "%"
                                    End If
                            End Select
                            'strNewStreet = strNewStreet & "%"
                        End If
                    Next

                    'Response.Write "%" & trim(strNewStreet) & "%" & "<br>" '-- add % for search statement
                    strNewStreet = Trim(strNewStreet) & "%"
                    If IsInArray(arrMatch, Trim(strNewStreet)) = False Then
                        arrMatch(index_counter) = Trim(strNewStreet)
                    End If
                    index_counter = index_counter + 1
                Next

                '---- Convert all words in street name and verify
                strNewStreet = ""
                For j = 0 To UBound(arrStreet)
                    If IsNumeric(Left(arrStreet(j), 1)) = False Then
                        'strNewStreet = strNewStreet & address.convert_word(arrStreet(j))
                        Select Case Address.Convert_Word(arrStreet(j))
                            Case "N", "S", "W", "E"
                                Select Case j
                                    Case 0
                                        strNewStreet = strNewStreet & Address.Convert_Word(arrStreet(j)) & " %"
                                    Case UBound(arrStreet)
                                        strNewStreet = strNewStreet & "% " & Address.Convert_Word(arrStreet(j))
                                    Case Else
                                        strNewStreet = strNewStreet & "% " & Address.Convert_Word(arrStreet(j)) & " %"
                                End Select
                            Case Else
                                If j = 0 Then
                                    strNewStreet = "%" & strNewStreet
                                End If
                                strNewStreet = strNewStreet & Address.Convert_Word(arrStreet(j))
                                If j <= UBound(arrStreet) - 1 Then
                                    strNewStreet = strNewStreet & "%"
                                End If
                        End Select
                    Else
                        If j = 0 Then
                            strNewStreet = "%" & strNewStreet
                        End If
                        strNewStreet = strNewStreet & Address.Convert_Number(arrStreet(j))
                        If j <= UBound(arrStreet) - 1 Then
                            strNewStreet = strNewStreet & "%"
                        End If
                    End If
                Next
                strNewStreet = Trim(strNewStreet) & "%"
                If IsInArray(arrMatch, Trim(strNewStreet)) = False Then
                    arrMatch(index_counter) = Trim(strNewStreet)
                End If
                index_counter = index_counter + 1

                strNewStreet = ""
                For j = 0 To UBound(arrStreet)
                    If IsNumeric(Left(arrStreet(j), 1)) = False Then
                        'strNewStreet = strNewStreet & arrStreet(j)
                        Select Case arrStreet(j)
                            Case "N", "S", "W", "E"
                                Select Case j
                                    Case 0
                                        strNewStreet = strNewStreet & arrStreet(j) & " %"
                                    Case UBound(arrStreet)
                                        strNewStreet = strNewStreet & arrStreet(j) & "% "
                                    Case Else
                                        strNewStreet = strNewStreet & "% " & arrStreet(j) & " %"
                                End Select
                            Case Else
                                If j = 0 Then
                                    strNewStreet = "%" & strNewStreet
                                End If
                                strNewStreet = strNewStreet & arrStreet(j)
                                If j <= UBound(arrStreet) - 1 Then
                                    strNewStreet = strNewStreet & "%"
                                End If
                        End Select
                    Else
                        If j = 0 Then
                            strNewStreet = "%" & strNewStreet
                        End If
                        strNewStreet = strNewStreet & Address.Convert_Number(arrStreet(j))
                        If j <= UBound(arrStreet) - 1 Then
                            strNewStreet = strNewStreet & "%"
                        End If
                    End If
                Next
                strNewStreet = Trim(strNewStreet) & "%"
                If IsInArray(arrMatch, Trim(strNewStreet)) = False Then
                    arrMatch(index_counter) = Trim(strNewStreet)
                End If
                index_counter = index_counter + 1
            End If
        End If
        '-- return array --
        'street_name_lookup = arrMatch
        Return arrMatch
    End Function
    '## 11/30/2007  yang
    Public Function GetStreetNameForStreetLookUp(ByVal state As String, ByVal street As String) As DataSet
        state = Security.SQLSafe(state)
        street = Security.SQLSafe(street)

        Dim arrMatches As Array = Me.LookUpStreetName_(street)

        Dim sqlstr As String = "SELECT DISTINCT st_name FROM street(NOLOCK) WHERE county = '" & state & "' AND ("
        For i As Integer = 0 To UBound(arrMatches)
            If (Not arrMatches.GetValue(i) Is Nothing) AndAlso (CType(arrMatches.GetValue(i), String) <> "") Then
                If i <> 0 Then
                    sqlstr = sqlstr & " OR "
                End If
                sqlstr = sqlstr & " RTRIM(LTRIM(st_name)) LIKE '" & Replace(Convert.ToString(arrMatches.GetValue(i)), "'", "''") & "' "
            End If
        Next
        sqlstr = sqlstr & ") ORDER BY st_name"

        Return Me.QueryData(sqlstr, "streetlookup")
    End Function
    '## 11/30/2007  yang
    Private Function IsDirection(ByVal streetname As String) As Boolean
        Dim SQLStr As String
        Dim bolIsDirection As Boolean

        SQLStr = "SELECT verify_street.input FROM verify_street(nolock) WHERE search_type = 'w' "
        SQLStr = SQLStr & " and isnumeric(verify_street.output) = 0 "
        SQLStr = SQLStr & " and (input = '" & Security.SQLSafe(streetname) & "' or output = '" & Security.SQLSafe(streetname) & "' )"
        SQLStr = SQLStr & " and (verify_street.output = 'N' or verify_street.output = 'S' or verify_street.output = 'W' or verify_street.output = 'E')"
        Try
            Me.OpenConnection()
            Me.Command.CommandType = CommandType.Text
            Me.Command.CommandText = SQLStr
            Me.Reader = Me.Command.ExecuteReader(CommandBehavior.CloseConnection)
            If Me.Reader.Read Then
                bolIsDirection = True
            Else
                bolIsDirection = False
            End If
            Me.Reader.Close()
        Catch ex As Exception
            bolIsDirection = False
        Finally
            Me.CloseConnection()
        End Try
        Return bolIsDirection
    End Function
    '## 11/30/2007  yang
    Private Function IsInArray(ByVal array_value As Array, ByVal search_value As Object) As Boolean
        If (Array.BinarySearch(array_value, search_value) >= 0) Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "Geo Price Function"

    '-------------------------------------------------------
    'Function: GetPrice_State
    'Description: Get GetPrice_State 
    'Modification: 2006/09/15 daniel
    'Table:           account_city_to_city_pricing
    'InPut:           
    'OutPut:          Freq info
    '-------------------------------------------------------
    Public Function GetPrice_State() As DataSet
        Dim tmpDS As DataSet
        Dim strSQL As String

        strSQL = "select distinct state from (select from_state as state from account_city_to_city_pricing"
        strSQL = strSQL & " union select to_state as state from account_city_to_city_pricing) as state"

        tmpDS = Me.QueryData(strSQL, "state")

        Return tmpDS
    End Function

    '-------------------------------------------------------
    'Function: GetPrice_County
    'Description: Get GetPrice_County 
    'Modification: 2006/09/15 daniel
    'Table:           account_city_to_city_pricing
    'InPut:           
    'OutPut:          Freq info
    '-------------------------------------------------------
    Public Function GetPrice_County() As DataSet
        Dim tmpDS As DataSet
        Dim strSQL As String

        strSQL = "select distinct county from (select from_county as county from account_city_to_city_pricing "
        strSQL = strSQL & " where from_county<>'' and from_county is not null"
        strSQL = strSQL & " union select to_county as county from account_city_to_city_pricing"
        strSQL = strSQL & " where to_county<>'' and to_county is not null) as county"

        tmpDS = Me.QueryData(strSQL, "COUNTY")

        Return tmpDS
    End Function

    '-------------------------------------------------------
    'Function: GetPrice_City
    'Description: Get GetPrice_City 
    'Modification: 2006/09/15 daniel
    'Table:           account_city_to_city_pricing
    'InPut:           
    'OutPut:          Freq info
    '-------------------------------------------------------
    Public Function GetPrice_City(ByVal strtype As String, ByVal strcounty As String, ByVal strcity As String) As DataSet
        Dim tmpDS As DataSet
        Dim strSQL As String

        If Trim(strtype) = "P" Or Trim(strtype) = "p" Then
            strSQL = "select from_county,from_city name from account_city_to_city_pricing"
            strSQL = strSQL & " where from_county='" & strcounty & "' and from_city like '" & strcity & "%'"
        End If

        If Trim(strtype) = "D" Or Trim(strtype) = "d" Then
            strSQL = "select to_county,to_city as name from account_city_to_city_pricing"
            strSQL = strSQL & " where to_county='" & strcounty & "' and to_city like '" & strcity & "%'"
        End If

        tmpDS = Me.QueryData(strSQL, "City")

        Return tmpDS
    End Function

#End Region

#Region "Geo Get Price_Zone Function"

    Public Function GetPriceZone(ByVal strcity As String, ByVal strCounty As String, ByVal strstate As String, ByVal strpricetable As String, ByRef Dispatch_zone As Int16) As String
        Dim strsql As String
        Dim price_counter As String

        Dim objdataset As DataSet
        Select Case UCase(Trim(strstate))
            Case "M", "BK", "BX", "QU", "SI"
                'strsql = "select name,county,state,price_zone from city(nolock) where ltrim(rtrim(name))='" & Trim(strCounty) & "' and state='NY' order by name,state,county"
                'objdataset = Me.QueryData(strsql, "cityname")

                'If objdataset.Tables(0).Rows.Count > 0 Then
                '    GetPriceZone = objdataset.Tables(0).Rows(0).Item("price_zone").ToString
                'Else
                '    GetPriceZone = ""
                'End If
                strstate = "NY"
            Case Else
                strstate = strstate

        End Select
        strsql = "select pricing_table_counter,dispatch_zone=isnull(dispatch_zone,0) from city(nolock) where ltrim(rtrim(name))='" & Trim(strcity) & "' and state='" & Trim(strstate) & "' order by name,state,county"
        objdataset = Me.QueryData(strsql, "cityname")

        If objdataset.Tables(0).Rows.Count > 0 Then
            price_counter = objdataset.Tables(0).Rows(0).Item("pricing_table_counter").ToString
            '--add by eJay 10/3/2006
            Dispatch_zone = Convert.ToInt16(objdataset.Tables(0).Rows(0).Item("dispatch_zone"))
        Else
            price_counter = "NA"
            Dispatch_zone = 0
        End If

        strsql = "select pricing_zone from pricing_table(nolock) where ltrim(rtrim(pricing_table_counter))='" & Trim(price_counter) & "' and pricing_table='" & Trim(strpricetable) & "'"
        objdataset = Me.QueryData(strsql, "cityname")

        If objdataset.Tables(0).Rows.Count > 0 Then
            GetPriceZone = objdataset.Tables(0).Rows(0).Item("pricing_zone").ToString
        Else
            GetPriceZone = ""
        End If

        objdataset.Dispose() : objdataset = Nothing

    End Function

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


#Region " Frequent User Address "

    '------------------------------------------------------------------------------
    '-- Function: getFavoritePU
    '-- Description:  Get top 10 frequent point , 
    '--               if strType is "P" the get frequent pickup,
    '--               if "D" then get frequent destination point
    '-- Input: strUserId,strAcctId,strSubAcctId,strCompany,strType
    '-- Output: DataSet
    '-- Table: vip_disp_add
    '-- Stored Procedure: MTC_wr_VipDispAdd_getFrequent
    '-- 22/03/06 - Created (Daniel)
    '------------------------------------------------------------------------------
    Public Function getFrequent(ByVal strUserId As String, _
                                ByVal strAcctId As String, _
                                ByVal strSubAcctId As String, _
                                ByVal strCompany As String, _
                                ByVal strType As String) As DataSet
        Dim tmpDS As DataSet
        With SelectCommand
            .CommandText = "apex_wr_VipDispAdd_getFrequent"
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@vip_no", strUserId)
            .Parameters.AddWithValue("@acct_id", strAcctId)
            .Parameters.AddWithValue("@sub_acct", strSubAcctId)

            If Not strCompany Is Nothing AndAlso IsNumeric(strCompany) Then
                .Parameters.AddWithValue("@company", strCompany)
            Else
                .Parameters.AddWithValue("@company", 1)
            End If

            .Parameters.AddWithValue("@type", strType)
        End With

        tmpDS = Me.QueryData("frequent")

        Return tmpDS
    End Function



    '----------------------------------------------------------------
    '--Function NewProfileAdd
    '--Description:Insert Passenger Information 
    '--01/31/08 - Created(lily)
    '## out
    '## -2  Frequent Address duplicate
    '----------------------------------------------------------------
    Public Function AddFrequentAddress(ByVal usr As UserData, ByVal addrType As String) As Int32
        Dim out As Int32 = 0

        Try
            Me.OpenConnection()

            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "apex_wr_vipdispadd_addfrequent"

                .Parameters.AddWithValue("@vip_no", usr.user_id)
                .Parameters.AddWithValue("@acct_id", usr.acct_id)
                .Parameters.AddWithValue("@sub_acct_id", usr.sub_acct_id)
                .Parameters.AddWithValue("@company", usr.Company)

                .Parameters.AddWithValue("@county", usr.county)
                .Parameters.AddWithValue("@city", usr.city)
                .Parameters.AddWithValue("@st_name", usr.st_name)
                .Parameters.AddWithValue("@st_no", usr.st_no)

                .Parameters.AddWithValue("@zip", usr.zip_code)  'added by lily 02/13/2008
                .Parameters.AddWithValue("@pu_point", usr.PPoint)

                .Parameters.AddWithValue("@address_type", addrType)

                .Parameters.Add("@out", SqlDbType.SmallInt)
                .Parameters.Item("@out").Direction = ParameterDirection.Output
                .ExecuteNonQuery()

                out = Convert.ToInt32(Val(Convert.ToString(.Parameters.Item("@out").Value)))
            End With
        Catch ex As Exception
            out = 0
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try

        Return out
    End Function

    '## out
    '## -2  Frequent Address duplicate
    Public Function UpdateFrequentAddress(ByVal usr As UserData, ByVal oldAddrType As String, ByVal newAddrType As String, _
                                    ByVal oldCounty As String, ByVal oldCity As String, ByVal oldStName As String, ByVal oldStNo As String) As Int32

        Dim out As Int32 = 0

        Try
            Me.OpenConnection()

            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "apex_wr_vipdispadd_updatefrequent"

                .Parameters.AddWithValue("@vip_no", usr.user_id)
                .Parameters.AddWithValue("@acct_id", usr.acct_id)
                .Parameters.AddWithValue("@sub_acct_id", usr.sub_acct_id)
                .Parameters.AddWithValue("@company", usr.Company)

                .Parameters.AddWithValue("@old_county", oldCounty)
                .Parameters.AddWithValue("@old_city", oldCity)
                .Parameters.AddWithValue("@old_st_name", oldStName)
                .Parameters.AddWithValue("@old_st_no", oldStNo)
                .Parameters.AddWithValue("@old_address_type", oldAddrType)

                .Parameters.AddWithValue("@new_county", usr.county)
                .Parameters.AddWithValue("@new_city", usr.city)
                .Parameters.AddWithValue("@new_st_name", usr.st_name)
                .Parameters.AddWithValue("@new_st_no", usr.st_no)

                .Parameters.AddWithValue("@new_zip", usr.zip_code)   'added by lily 02/13/2008
                .Parameters.AddWithValue("@new_point", usr.PPoint)   'added by lily 02/13/2008

                .Parameters.AddWithValue("@new_address_type", newAddrType)

                .Parameters.Add("@out", SqlDbType.SmallInt)
                .Parameters.Item("@out").Direction = ParameterDirection.Output
                .ExecuteNonQuery()

                out = Convert.ToInt32(Val(Convert.ToString(.Parameters.Item("@out").Value)))
            End With
        Catch ex As Exception
            out = 0
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try

        Return out
    End Function

    '## out
    '## -1  Frequent Address doest not exist
    Public Function DeleteFrequentAddress(ByVal usr As UserData, ByVal addressType As String) As Int32
        Dim out As Int32 = 0

        Try
            Me.OpenConnection()

            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "apex_wr_vipdispadd_deletefrequent"

                .Parameters.AddWithValue("@vip_no", usr.user_id)
                .Parameters.AddWithValue("@acct_id", usr.acct_id)
                .Parameters.AddWithValue("@sub_acct_id", usr.sub_acct_id)
                .Parameters.AddWithValue("@company", usr.Company)

                .Parameters.AddWithValue("@county", usr.county)
                .Parameters.AddWithValue("@city", usr.city)
                .Parameters.AddWithValue("@st_name", usr.st_name)
                .Parameters.AddWithValue("@st_no", usr.st_no)
                .Parameters.AddWithValue("@address_type", addressType)

                .Parameters.Add("@out", SqlDbType.SmallInt)
                .Parameters.Item("@out").Direction = ParameterDirection.Output

                out = .ExecuteNonQuery()
                out = Convert.ToInt32(Val(Convert.ToString(.Parameters.Item("@out").Value)))
            End With
        Catch ex As Exception
            out = 0 '-- unexpected error
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try

        Return out
    End Function

#End Region

End Class
