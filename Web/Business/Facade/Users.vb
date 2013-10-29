Imports DataAccess
Imports System.Data
Imports System.Data.SqlClient

Public Class Users
    Inherits CommonDB

#Region " Normal Users Parts "

    '------------------------------------------------------------------------------
    '-- Function: getUserInfo
    '-- Description:  get the user detail information
    '-- Input: strUserId,strAcctId,strSubAcct,strCompany
    '-- Output:
    '-- Table: vip,account
    '-- Stored Procedure: skylimo_wr_vip_getUserInfo
    '-- 10/28/04 - Created (jack)
    '------------------------------------------------------------------------------
    Public Function check_username(ByVal strusername As String) As UserData
        Dim objuser As New UserData


        Me.OpenConnection()
        With Me.Command
            .CommandText = "skylimo_wr_vip_check_username"
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@username", strusername)
        End With
        Try
            Me.Reader = Me.Command.ExecuteReader(CommandBehavior.SingleRow)
            If Me.Reader.Read() Then
                With objUser
                    .check = Me.Reader.Item("check").ToString.Trim
                End With
            End If
            Me.Reader.Close()



        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try

        Return objuser

    End Function





    '------------------------------------------------------------------------------
    '-- Function: getUserInfo
    '-- Description:  get the user detail information
    '-- Input: strUserId,strAcctId,strSubAcct,strCompany
    '-- Output:
    '-- Table: vip,account
    '-- Stored Procedure: skylimo_wr_vip_getUserInfo
    '-- 10/28/04 - Created (Nanco)
    '------------------------------------------------------------------------------
    Public Function activateUser(ByVal strUserId As String, ByVal strAcctId As String, ByVal strSubAcct As String, ByVal strCompany As String, ByVal strusername As String, ByVal strpwd As String) As UserData
        Dim objUser As New UserData

        Me.OpenConnection()
        With Me.Command
            .CommandText = "skylimo_wr_vip_activateUser"
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@vip_no", strUserId)
            .Parameters.AddWithValue("@acct_id", strAcctId)
            .Parameters.AddWithValue("@sub_acct", strSubAcct)
            .Parameters.AddWithValue("@company", Convert.ToInt16(strCompany))
            .Parameters.AddWithValue("@username_give", strusername)
            .Parameters.AddWithValue("@pwd_give", strpwd)
        End With

        Try
            Me.Reader = Me.Command.ExecuteReader(CommandBehavior.SingleRow)
            If Me.Reader.Read() Then
                With objUser
                    .username = Me.Reader.Item("user_name").ToString.Trim
                    .password = Me.Reader.Item("pin_no").ToString.Trim
                    .fname = Me.Reader.Item("fname").ToString.Trim
                    .lname = Me.Reader.Item("lname").ToString.Trim
                    .Company = Me.Reader.Item("company").ToString.Trim
                    .office_phone = Me.Reader.Item("phone").ToString.Trim
                    .office_phone_ext = Me.Reader.Item("phone_ext").ToString.Trim
                    .cell_phone = Me.Reader.Item("cell_phone").ToString.Trim
                    .fax = Me.Reader.Item("fax").ToString.Trim
                    .email = Me.Reader.Item("email_add").ToString.Trim
                    .st_no = Me.Reader.Item("st_no").ToString.Trim
                    .st_name = Me.Reader.Item("st_name").ToString.Trim
                    .aux_street_add = Me.Reader.Item("aux_street_add").ToString.Trim
                    .city = Me.Reader.Item("city").ToString.Trim
                    .state = Me.Reader.Item("state").ToString.Trim
                    .zip_code = Me.Reader.Item("zip_code").ToString.Trim
                    .CCName = Me.Reader.Item("cc_name").ToString.Trim
                    .class_one_club = Me.Reader.Item("class_one_club").ToString.Trim
                    .acct_name = Me.Reader.Item("acct_name").ToString.Trim
                    .user_id = Me.Reader.Item("vip_no").ToString.Trim
                    .acct_id = Me.Reader.Item("acct_id").ToString.Trim
                    .sub_acct_id = Me.Reader.Item("sub_acct_id").ToString.Trim
                End With
            End If
            Me.Reader.Close()
        Catch ex As Exception
        Finally
            Me.CloseConnection()
        End Try

        Return objUser

    End Function




    '------------------------------------------------------------------------------
    '-- Function: getUserInfobyEmail
    '-- Description:  get the user detail information
    '-- Input: strUserId,strAcctId,strSubAcct,strCompany
    '-- Output:
    '-- Table: vip,account
    '-- Stored Procedure: skylimo_wr_vip_getUserInfo
    '-- 10/28/04 - Created (jack)
    '------------------------------------------------------------------------------
    Public Function getUserInfobyEmail(ByVal stremail As String, ByVal strfname As String, ByVal strlname As String) As UserData
        Dim objUser As New UserData


        Try
            Me.OpenConnection()
            With Me.Command
                .CommandText = "skylimo_wr_vip_getUserInfobyEmail"
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@email", stremail)
                .Parameters.AddWithValue("@fname", strfname)
                .Parameters.AddWithValue("@lname", strlname)

                Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)

                If Me.Reader.Read Then
                    With objUser
                        .email = Me.Reader.Item("email_add").ToString.Trim
                        .fname = Me.Reader.Item("fname").ToString.Trim
                        .lname = Me.Reader.Item("lname").ToString.Trim
                        .acct_id = Me.Reader.Item("acct_id").ToString.Trim
                        .sub_acct_id = Me.Reader.Item("sub_acct_id").ToString.Trim
                        .acct_name = Me.Reader.Item("acct_name").ToString.Trim
                        .user_id = Me.Reader.Item("vip_no").ToString.Trim
                        .Company = Me.Reader.Item("company").ToString.Trim
                        .username = Me.Reader.Item("user_name").ToString.Trim
                        .check = Me.Reader.Item("check").ToString.Trim
                        .password = Me.Reader.Item("pin_no").ToString.Trim
                    End With
                Else
                    objUser = Nothing
                End If


            End With


        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try

        Return objUser

    End Function


    '-----------------------------------------------------------------
    'Function:  GetAssistUsersInfo
    'Description: Get assist users' Info that are belong to the admin
    'Modification:  2004/10/17 Cooker
    'Table:               User_profile,admin_user_link
    'Input :              AdminID/Priority
    'OutPut:              DataSet
    '                    
    '-----------------------------------------------------------------
    Public Function GetAssistUsersInfo(ByVal strAdminID As String, ByVal strPriority As String) As DataSet
        Dim strSQL As String
        strSQL = "select u.*,v.division_name,v.company_name,v.office_name,v.dept_name from user_profile u,vip v where u.user_id in(select link_user_id from admin_user_link where admin_user_id='" & strAdminID & "')  and vip_no=user_id"

        Return Me.QueryData(strSQL, "AssistUsers")
    End Function

    '-------------------------------------------------------
    'Function:  LogOn
    'Description: For user Log into the system
    'Modification:  2004/10/14 Spring
    'Table:               User_profile
    'Input :              UserName/Password
    'OutPut:
    '                      1   OK
    '                      0   No User/pw
    '                      -1  fail to logi
    '-------------------------------------------------------
    Public Function LogOn(ByVal username As String, ByVal pw As String) As Int32
        Dim intResult As Int32
        Try
            Me.OpenConnection()
            With Me.Command
                .CommandText = "select count(*) from user_profile where guid='" & username & "' and passwd='" & pw & "'"
                intResult = CType(.ExecuteScalar(), Int32)
            End With
        Catch ex As Exception
            intResult = -1
        Finally
            Me.CloseConnection()
        End Try

        Return intResult
    End Function
    '------------------------------------------------------------------------------
    '-- Function: getUserInfo
    '-- Description:  get the user detail information
    '-- Input: strUserId,strAcctId,strSubAcct,strCompany
    '-- Output:
    '-- Table: vip,account
    '-- Stored Procedure: MTC_wr_vip_getUserInfo
    '-- 21/03/06 - Created (Daniel)

    '## 11/23/2007  (yang)
    Public Function getUserInfo(ByVal strUserId As String, ByVal strAcctId As String, ByVal strSubAcct As String, ByVal strCompany As String) As UserData
        Dim objUser As New UserData

        Me.OpenConnection()
        With Me.Command
            .CommandText = "apex_wr_vip_getUserInfo"
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@vip_no", strUserId)
            .Parameters.AddWithValue("@acct_id", strAcctId)
            .Parameters.AddWithValue("@sub_acct", strSubAcct)

            If Not strCompany Is Nothing AndAlso IsNumeric(strCompany) Then
                .Parameters.AddWithValue("@company", Convert.ToInt16(strCompany))
            Else
                .Parameters.AddWithValue("@company", 1)
            End If
        End With

        Try
            Me.Reader = Me.Command.ExecuteReader(CommandBehavior.SingleRow)
            If Me.Reader.Read() Then
                With objUser

                    .cell_phone = Me.Reader.Item("cell_phone").ToString.Trim        '--add by daniel for passenger cell phone #
                    .FnameOrd = Me.Reader.Item("fname").ToString.Trim
                    .LnameOrd = Me.Reader.Item("lname").ToString.Trim
                    .fname = Me.Reader.Item("fname").ToString.Trim
                    .lname = Me.Reader.Item("lname").ToString.Trim
                    .st_name = Me.Reader.Item("st_name").ToString.Trim
                    .st_no = Me.Reader.Item("st_no").ToString.Trim
                    .city = Me.Reader.Item("city").ToString.Trim
                    .state = Me.Reader.Item("state").ToString.Trim
                    .zip_code = Me.Reader.Item("zip_code").ToString.Trim
                    .email = Me.Reader.Item("email_address").ToString.Trim
                    .comp_id_1 = Me.Reader.Item("comp_id_1").ToString.Trim
                    .comp_id_2 = Me.Reader.Item("comp_id_2").ToString.Trim
                    .comp_id_3 = Me.Reader.Item("comp_id_3").ToString.Trim
                    .comp_id_4 = Me.Reader.Item("comp_id_4").ToString.Trim
                    .comp_id_5 = Me.Reader.Item("comp_id_5").ToString.Trim
                    .comp_id_6 = Me.Reader.Item("comp_id_6").ToString.Trim
                    .CCNo = Me.Reader.Item("cc_no").ToString.Trim
                    .CCMonth = Left(Me.Reader.Item("cc_exp").ToString.Trim, 2)
                    .CCYear = Right(Me.Reader.Item("cc_exp").ToString.Trim, 2)
                    .CCType = Me.Reader.Item("cc_type").ToString.Trim
                    '.CCName = Me.Reader.Item("cc_name").ToString.Trim
                    'If .CCName.Length = 0 Then
                    '    .CCName = .fname + " " + .lname
                    'End If
                    .office_phone = Me.Reader.Item("phone").ToString.Trim
                    'If .office_phone.Length > 7 Then
                    '    .office_phone_area = Left(.office_phone, 3)
                    '    .office_phone = Right(.office_phone, 7)
                    'Else
                    '    .office_phone_area = ""
                    'End If
                    .office_phone_ext = Me.Reader.Item("phone_ext").ToString.Trim
                    .user_id = Me.Reader.Item("vip_no").ToString.Trim
                    .Company = Me.Reader.Item("company").ToString.Trim
                    .priority = Me.Reader.Item("priority").ToString.Trim
                    .CashAccount = Me.Reader.Item("cash_account").ToString.Trim
                    .PaymenType = Me.Reader.Item("payment_type").ToString.Trim
                    '.CCNo1 = Me.Reader.Item("cc_no_2").ToString.Trim
                    '.CCMonth1 = Left(Me.Reader.Item("cc_exp_2").ToString.Trim, 2)
                    '.CCYear1 = Right(Me.Reader.Item("cc_exp_2").ToString.Trim, 2)
                    '.CCType1 = Me.Reader.Item("cc_type_2").ToString.Trim
                    '.CCName1 = Me.Reader.Item("cc_name_2").ToString.Trim
                    'If .CCName1.Length = 0 Then
                    '    .CCName1 = .fname + " " + .lname
                    'End If
                End With
            End If
            Me.Reader.Close()
        Catch ex As Exception
        Finally
            Me.CloseConnection()
        End Try

        Return objUser

    End Function

    '-------------------------------------------------------
    'Function: GetUserInfo
    'Description: Get User Information By GUID
    'Modification: 2004/10/14 Spring
    'Table:              user_profile
    'Input:              GUID#
    'OutPut:           A  UserData Component with User Info
    '-------------------------------------------------------
    Public Function GetUserInfo(ByVal GUID As String) As UserData
        Dim objUser As New UserData
        Try
            Me.OpenConnection()
            Me.Command.CommandText = "select * from user_profile where guid='" & GUID & "'"
            Me.Reader = Me.Command.ExecuteReader(CommandBehavior.SingleRow)
            If Me.Reader.Read() Then
                objUser.user_id = Convert.ToString(Me.Reader.Item("user_id")).Trim()
                objUser.priority = Convert.ToString(Me.Reader.Item("priority")).Trim()
                objUser.pu_index = Convert.ToString(Me.Reader.Item("pu_index")).Trim()
                objUser.username = GUID
            End If
            Me.Reader.Close()
        Catch ex As Exception
            'doing nothing just a blank user instance return
        Finally
            Me.CloseConnection()
        End Try

        Return objUser
    End Function

    '-------------------------------------------------------
    'Function: GetPuIndexByUserID
    'Description: Get pu_index by user_id
    'Modification: 2004/10/20 wan
    'Table:              user_profile
    'Input:              user_id
    'OutPut:             pu_index
    '-------------------------------------------------------
    Public Function GetPuIndexByUserID(ByVal user_id As String) As String
        Dim strPuIndex As String
        Try
            Me.OpenConnection()
            Me.Command.CommandText = "select * from user_profile where user_id='" & user_id & "'"
            Me.Reader = Me.Command.ExecuteReader(CommandBehavior.SingleRow)
            If Me.Reader.Read() Then
                strPuIndex = Convert.ToString(Me.Reader.Item("pu_index")).Trim
            End If
            Me.Reader.Close()
        Catch ex As Exception
            'doing nothing just a blank user instance return
            strPuIndex = ""
        Finally
            Me.CloseConnection()
        End Try

        Return strPuIndex
    End Function

    '*****************************************************************
    '**---get_username
    'Description: Display User Name by user_id   In Share Function : by orderdata.stop_emp_id_1 when search a user!
    '**Input      vip_id
    '**Output     username
    '*****************************************************************
    Function GetUserNameByID(ByVal vip_id As String) As String
        Dim username As String = ""
        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "gswr_getuser_byid"
                .Parameters.Add("@user_id", SqlDbType.Char, 10)
                .Parameters.Item("@user_id").Value = vip_id
            End With
            Me.Reader = Me.Command.ExecuteReader
            If Me.Reader.HasRows Then
                Me.Reader.Read()
                username = Convert.ToString(Me.Reader.Item("guid"))
            Else
                With Me.Command
                    .CommandText = "gswr_getNonEmployee_byid"
                    .Parameters.Clear()
                    .Parameters.Add("@user_id", SqlDbType.Char, 10)
                    .Parameters.Item("@user_id").Value = vip_id
                End With
                Me.Reader.Close()
                Me.Reader = Me.Command.ExecuteReader
                If Me.Reader.HasRows Then
                    Me.Reader.Read()
                    username = Convert.ToString(Me.Reader.Item("guid"))
                Else
                End If
            End If
        Catch ex As Exception
        Finally
            Me.CloseConnection()
        End Try
        Return username
    End Function

    '-------------------------------------------------------
    'Function: GetDetailUserInfo
    'Description: Get all fields User Information By user_id
    'Modification: 2006/03/06 eJay
    'Table:              VIP ,account
    'Input:              GUID#
    'OutPut:           A  UserData Component with User Info
    '-------------------------------------------------------
    Public Function GetDetailUserInfo(ByVal user_id As String) As UserData
        Dim objUser As New UserData
        Try
            Me.OpenConnection()
            Me.Command.CommandType = CommandType.StoredProcedure
            Me.Command.CommandText = "mtcwr_getuser_byid"
            Me.Command.Parameters.AddWithValue("@user_id", user_id)
            Me.Reader = Me.Command.ExecuteReader(CommandBehavior.SingleRow)
            If Me.Reader.Read() Then
                With Me.Reader
                    objUser.user_id = Trim(Convert.ToString(.Item("vip_no")))
                    objUser.lname = Convert.ToString(.Item("lname")).Trim
                    objUser.fname = Convert.ToString(.Item("fname")).Trim
                    objUser.st_no = Convert.ToString(.Item("st_no")).Trim
                    objUser.st_name = Convert.ToString(.Item("st_name")).Trim
                    objUser.city = Convert.ToString(.Item("city")).Trim
                    objUser.state = Convert.ToString(.Item("state")).Trim
                    objUser.zip_code = Convert.ToString(.Item("zip_code")).Trim
                    objUser.email = Convert.ToString(.Item("email_add")).Trim
                    objUser.office_phone = Convert.ToString(.Item("phone")).Trim
                    objUser.office_phone_ext = Convert.ToString(.Item("phone_ext")).Trim

                    If objUser.comp_id_1 = "" Then
                        objUser.comp_id_1 = Convert.ToString(.Item("comp_id_1")).Trim
                    End If
                    If objUser.comp_id_2 = "" Then
                        objUser.comp_id_2 = Convert.ToString(.Item("comp_id_2")).Trim
                    End If
                    objUser.comp_id_3 = Convert.ToString(.Item("comp_id_3")).Trim
                    objUser.comp_id_4 = Convert.ToString(.Item("comp_id_4")).Trim
                    objUser.comp_id_5 = Convert.ToString(.Item("comp_id_5")).Trim
                    objUser.comp_id_6 = .Item("comp_id_6").ToString.Trim()

                    objUser.CCNo = Trim(Convert.ToString(.Item("cc_no")))
                    objUser.CCMonth = Left(Convert.ToString(.Item("cc_exp")), 2)
                    objUser.CCYear = Right(Convert.ToString(.Item("cc_exp")), 2)
                    objUser.CCType = Trim(Convert.ToString(.Item("cc_type")))
                    objUser.CCName = Trim(Convert.ToString(.Item("cc_name")))
                    If StrComp(objUser.CCName, "") = 0 Then
                        objUser.CCName = objUser.fname & " " & objUser.lname
                    End If

                    objUser.priority = Convert.ToString(.Item("priority")).Trim
                    objUser.Company = Convert.ToString(.Item("company")).Trim
                    objUser.CashAccount = Convert.ToString(.Item("cash_account")).Trim
                    If Convert.ToString(.Item("close_date")).Trim.Length > 0 Then
                        objUser.close_date = Convert.ToString(.Item("close_date")).Trim
                    End If

                End With

            End If
            Me.Reader.Close()
        Catch ex As Exception
            'doing nothing just a blank user instance return
        Finally
            Me.CloseConnection()
        End Try
        Return objUser
    End Function

    '-------------------------------------------------------
    'Function: ActiveValid
    'Description: Validation for the vip_no
    'Modification: 2004/10/15 Nancy
    'Table:              vip
    'Input:              vip_no
    'OutPut:          
    '-1              Error. Cannot find matching GUID.
    '-2              Error. This user is already activated.
    '-3              error
    '1               valid
    '-------------------------------------------------------
    Public Function ActiveValid(ByVal strVipNo As String) As Int16
        Dim intValid As Int16
        Try
            Me.OpenConnection()
            With Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "gswr_active_valid"
                .Parameters.AddWithValue("@vip_no", strVipNo)

                Dim paraValid As SqlClient.SqlParameter = .Parameters.AddWithValue("@intValid", System.Data.SqlDbType.Int)
                paraValid.Direction = ParameterDirection.Output
                .ExecuteNonQuery()
                intValid = Convert.ToInt16(paraValid.Value)
            End With
        Catch ex As Exception
            Return -3
        Finally
            Me.CloseConnection()
        End Try
        Return intValid
    End Function
    '-------------------------------------------------------
    'Function: GetInfoFromVip
    'Description: Get  User Information from vip By vip_no
    'Modification: 2004/10/15 nancy
    'Table:              vip
    'Input:              vip_no
    'OutPut:           A  UserData Component with User Info
    '-------------------------------------------------------
    Public Function GetInfoFromVip(ByVal strGuid As String) As UserData
        Dim objUser As New UserData
        Try
            Me.OpenConnection()
            Me.Command.CommandText = "select fname,lname,email_address from vip where vip_no='" & strGuid & "'"
            Me.Reader = Me.Command.ExecuteReader(CommandBehavior.SingleRow)
            If Me.Reader.Read() Then
                objUser.user_id = Convert.ToString(Me.Reader.Item("fname")).Trim()
                objUser.priority = Convert.ToString(Me.Reader.Item("lname")).Trim()
                objUser.pu_index = Convert.ToString(Me.Reader.Item("email_address")).Trim()
                objUser.username = strGuid
            End If
            Me.Reader.Close()
        Catch ex As Exception
            'doing nothing just a blank user instance return
        Finally
            Me.CloseConnection()
        End Try
        Return objUser
    End Function
    '-------------------------------------------------------
    'Function: UserActivate
    'Description: Activate User
    'Modification: 2004/10/15 nancy
    'Table:              user_profile
    'Input:              A  UserData Component with User Info
    'OutPut:        
    '           -1     nouserinhr
    '           -2     duplicate guid
    '           -3     err 
    '            1      success
    '-------------------------------------------------------
    Public Function UserActive(ByVal objUserData As UserData) As Int16
        Dim iResult As Int16
        Try
            Me.OpenConnection()
            With Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "gswr_user_active"
                .Parameters.AddWithValue("@user_id", objUserData.user_id)
                .Parameters.AddWithValue("@fname", objUserData.fname)
                .Parameters.AddWithValue("@lname", objUserData.lname)
                .Parameters.AddWithValue("@passwd", objUserData.password)
                .Parameters.AddWithValue("@email", objUserData.email)
                .Parameters.AddWithValue("@home_phone", objUserData.home_phone)
                .Parameters.AddWithValue("@office_phone", objUserData.office_phone)
                .Parameters.AddWithValue("@office_phone_ext", objUserData.office_phone_ext)
                .Parameters.AddWithValue("@pu_index", objUserData.pu_index)
                .Parameters.AddWithValue("@st_name", objUserData.st_name)
                .Parameters.AddWithValue("@st_no", objUserData.st_no)
                .Parameters.AddWithValue("@city", objUserData.city)
                .Parameters.AddWithValue("@state", objUserData.state)

                .Parameters.AddWithValue("@numback", SqlDbType.Int)
                .Parameters("@numback").Direction = ParameterDirection.Output
                .ExecuteNonQuery()
                iResult = Convert.ToInt16(.Parameters("@numback").Value)
            End With
        Catch ex As Exception
            iResult = -3
        Finally
            Me.CloseConnection()
        End Try
        Return iResult
    End Function

    '-------------------------------------------------------
    'Function: CheckUserEmailDuplicate
    'Description: When Edit user_profile check if there's a same e_mail address exist in DB
    'Modification: 2004/10/15 wan
    'Table:              user_profile
    'Input:              userdata
    'OutPut:        
    '           true        Mail address is duplicate and not illegal
    '           false       Mail address not duplicate and illegal
    '           errCode     Error Class Output
    '-------------------------------------------------------
    Public Function CheckUserEmailDuplicate(ByVal usr As UserData, Optional ByRef errCode As String = "") As Boolean
        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "gswr_VIP_singleEmail"
                .Parameters.AddWithValue("@userid", usr.user_id)
                .Parameters.AddWithValue("@emailid", usr.email)
            End With
            Me.Reader = Me.Command.ExecuteReader()
            If Me.Reader.HasRows Then
                errCode = "dupemail"
                Return True
            Else
                With Me.Command
                    .CommandText = "gswr_user_profile_singleEmail"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@userid", usr.user_id)
                    .Parameters.AddWithValue("@email", usr.email)
                End With
                Me.Reader.Close()
                Me.Reader = Me.Command.ExecuteReader(CommandBehavior.CloseConnection)
                If Me.Reader.HasRows Then
                    errCode = "dupemail"
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            errCode = "dupemail"
            Return True
        End Try
    End Function

    '-------------------------------------------------------
    'Function: UpdateEditUserProfile
    'Description: Update Edit user_profile Info
    'Modification: 2004/10/15 wan
    'Table:              user_profile
    'Input:              userdata,editMode,current_userid
    '           current_userid      the current user_id who is editing the user_profile e.g. 'administrator'
    '           editMode = "edit"   Current User is administrator and can update fields like 'priority' etc.
    'OutPut:        
    '           true        Mail address is duplicate and not illegal
    '           false       Mail address not duplicate and illegal
    '           errCode     Error Class Output
    '-------------------------------------------------------
    Public Function UpdateEditUserProfile(ByVal usr As UserData, ByVal editMode As String, ByVal current_userid As String, Optional ByRef errCode As String = "") As Boolean
        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "gswr_editUser"
                .Parameters.Clear()
                .Parameters.AddWithValue("@user_id", usr.user_id)
                .Parameters.AddWithValue("@mode", editMode)
                .Parameters.AddWithValue("@fname", usr.fname)
                .Parameters.AddWithValue("@lname", usr.lname)
                .Parameters.AddWithValue("@password", usr.password)
                .Parameters.AddWithValue("@stname", usr.st_name)
                .Parameters.AddWithValue("@st_no", usr.st_no)
                .Parameters.AddWithValue("@city", usr.city)
                .Parameters.AddWithValue("@state", usr.state)
                .Parameters.AddWithValue("@zip_code", usr.zip_code)
                .Parameters.AddWithValue("@email", usr.email)
                .Parameters.AddWithValue("@cell_phone", usr.cell_phone)
                .Parameters.AddWithValue("@pager_no", usr.pager_no)
                .Parameters.AddWithValue("@office_phone", usr.office_phone)
                .Parameters.AddWithValue("@office_phone_ext", usr.office_phone_ext)
                .Parameters.AddWithValue("@pu_index", usr.pu_index)
                .Parameters.AddWithValue("@priority", usr.priority)
                .Parameters.AddWithValue("@comp_id_3", usr.comp_id_3)
                .Parameters.AddWithValue("@active_flag", usr.active_flag)
                .Parameters.AddWithValue("@term_date", usr.term_date)

                ''add on 09/20
                .Parameters.AddWithValue("@company", usr.Company)
                .Parameters.AddWithValue("@department", usr.Department)
                .Parameters.AddWithValue("@division", usr.Division)
                .Parameters.AddWithValue("@office", usr.Office)

                ''---ADD ON 09/27 by tom
                .Parameters.AddWithValue("@IBD_FICC", usr.IBD_FICC)

                ''---ADD ON 09/28 BY TOM
                .Parameters.AddWithValue("@GUID", usr.GUID)

                ''---ADD ON 10/18 by wan
                .Parameters.AddWithValue("@homedirection", usr.HomeDirection)

                .ExecuteNonQuery()

                ''-------audit fields edittion
                'Security.AuditTrail_UserEdit(current_userid, usr.user_id)

                ''--edit on 09/20 by Tom
                'If Left(Trim(usr.user_id), 2) = "WR" Then
                .CommandText = "gswr_editVIP"
                .Parameters.Clear()
                .Parameters.AddWithValue("@first_name", usr.fname)
                .Parameters.AddWithValue("@last_name", usr.lname)
                .Parameters.AddWithValue("@emplid", usr.user_id)
                .Parameters.AddWithValue("@deptid", usr.comp_id_3)
                .Parameters.AddWithValue("@emailid", usr.email)
                .Parameters.AddWithValue("@term_date", usr.term_date)
                .ExecuteNonQuery()
                'End If
            End With

            errCode = "usrupdate"
            Me.CloseConnection()
            Return True
        Catch ex As Exception
            Me.CloseConnection()
            errCode = ex.Message
            Return False
        End Try
    End Function

    '-------------------------------------------------------
    'Function: GetPrioritiesInfo
    'Description: Get Priorities Info
    'Modification: 2004/10/15 wan
    'Table:             priority
    'Input:             emp_id,express,priority
    'OutPut:            Priority info   
    '-------------------------------------------------------
    Public Function GetPrioritiesInfo(ByVal emp_id As String, ByVal express As String, ByVal priority As String) As DataSet
        Dim tmpDS As DataSet
        Select Case priority
            Case "d"
                tmpDS = Me.QueryData("exec gswr_getPriority '" & emp_id & "','='", "priority")
            Case "t", "c"
                tmpDS = Me.QueryData("exec gswr_getPriority 't','='", "priority")
            Case Else
                tmpDS = Me.QueryData("exec gswr_getPriority 't','<>'", "priority")
        End Select
        Return tmpDS
    End Function

    '-------------------------------------------------------
    'Function: SearchUser
    'Description: Search User by GUID or lanme,fname
    'Modification: 2004/10/15 wan
    'Table:             user_profile
    'Input:             guid,fname,lname,priority
    'OutPut:            DataSet of UserInfo
    '-------------------------------------------------------
    Public Overloads Function SearchUser(ByVal guid As String, ByVal fname As String, _
                                         ByVal lname As String, ByVal priority As String, _
                                         ByVal page As Integer, ByVal pageCount As Integer, _
                                         ByRef totalPages As Integer) As DataSet
        Dim ds As New DataSet
        Dim da As New Data.SqlClient.SqlDataAdapter
        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "gswr_searchUser"
                '.Parameters.AddWithValue("@guid", SqlDbType.Char, 10)
                '.Parameters.AddWithValue("@fname", SqlDbType.VarChar, 50)
                '.Parameters.AddWithValue("@lname", SqlDbType.VarChar, 50)
                '.Parameters.AddWithValue("@priority", SqlDbType.Char, 1)
                '.Parameters.AddWithValue("@page", SqlDbType.Int)
                '.Parameters.AddWithValue("@pageCount", SqlDbType.Int)
                .Parameters.AddWithValue("@totalPages", SqlDbType.Int)
                .Parameters.Item("@totalPages").Direction = ParameterDirection.InputOutput
                '.Parameters.Item("@guid").Value = sec.sqlsafe(Me.lblGUID.Text)
                .Parameters.AddWithValue("@guid", guid)
                '.Parameters.Item("@fname").Value = sec.sqlsafe(lblFname.Text)
                .Parameters.AddWithValue("@fname", fname)
                '.Parameters.Item("@lname").Value = sec.sqlsafe(lblLname.Text)
                .Parameters.AddWithValue("@lname", lname)
                '.Parameters.Item("@priority").Value = CChar(sec.sqlsafe(Session("priority")))
                .Parameters.AddWithValue("@priority", priority)
                If IsDBNull(page) Then
                    '.Parameters.Item("@page").Value = 1
                    .Parameters.AddWithValue("@page", 1)
                    'lblPage.Text = "1"
                Else
                    '.Parameters.Item("@page").Value = CInt(lblPage.Text)
                    .Parameters.AddWithValue("@page", page)
                End If
                '.Parameters.Item("@pageCount").Value = pageCount
                .Parameters.AddWithValue("@pageCount", pageCount)
                .Parameters.Item("@totalPages").Value = 0
                '.Parameters.AddWithValue("@totalPages", 0)
            End With
            da.SelectCommand = Me.Command
            da.Fill(ds, "user")
            'lblTotal.Text = CStr(da.SelectCommand.Parameters("@totalPages").Value)
            totalPages = Convert.ToInt16(da.SelectCommand.Parameters("@totalPages").Value)
            Return ds
        Catch ex As Exception
            Return ds
        Finally
            Me.CloseConnection()
        End Try
    End Function
    '-------------------------------------------------------
    'Function: SearchShareUser
    'Description: Search User or lanme,fname
    'Modification: 2004/10/17 wan
    'Table:             user_profile
    'Input:             last name , first name
    'OutPut:            DataSet of UserInfo
    '-------------------------------------------------------
    Public Function SearchShareUsers(ByVal fname As String, ByVal lname As String) As DataSet
        Return Me.QueryData("exec gswr_search_shareusers '" & fname & "','" & lname & "'", "share")
    End Function

    '-------------------------------------------------------
    'Function: GetAdminUserIDByLinkUserID
    'Description: Get the Amin User IDs which current user can order for
    'Modification: 2004/10/19 wan
    'Table:             admin_user_link
    'Input:             link_user_id
    'OutPut:            DataSet of Admin User ID
    '-------------------------------------------------------
    Public Function GetAdminUserIDByLinkUserID(ByVal link_user_id As String) As DataSet
        Dim sqlStr As String
        sqlStr = "select admin_user_id from admin_user_link(nolock) where "
        sqlStr = sqlStr & " rtrim(ltrim(link_user_id)) = '" & Trim((link_user_id)) & "'"
        Return Me.QueryData(sqlStr, "admin_user_link")
    End Function
    '-------------------------------------------------------
    'Function: SearchUsersForUserAssignUser
    'Description: 
    'Modification: 2004/10/19 wan
    'Table:             user_profile
    'Input:             user_id
    'OutPut:            DataSet of UserInfo
    '-------------------------------------------------------
    Public Function SearchUserForUserAssignUser(ByVal user_id As String, ByVal fname As String, ByVal lname As String) As DataSet
        Dim SQLStr As String
        SQLStr = "select user_id,GUID,fname,lname,priority from user_profile(nolock) where"
        SQLStr = SQLStr & " user_id <> '" & (user_id) & "' and (priority = 's' or priority = 'n') and "
        SQLStr = SQLStr & " active_flag = 'y' and term_date >= getdate() "
        If fname <> "" Then
            SQLStr = SQLStr & " and rtrim(ltrim(fname)) like '%" & (fname) & "%' "
        End If
        If lname <> "" Then
            SQLStr = SQLStr & " and rtrim(ltrim(lname)) like '%" & (lname) & "%' "
        End If
        SQLStr = SQLStr & " order by lname"
        Return Me.QueryData(SQLStr, "userassignuser")
    End Function
#End Region

#Region " Admin Users Parts"
    ''--7/20/05 - Created (maria)
    ''--01/20/06 - Modify (Daniel)delete ByVal vipno As String
    ''Public Function VIPSearch(ByVal acctid As String, ByVal lname As String, ByVal fname As String, ByVal vipno As String) As DataSet
    'Public Function VIPSearch(ByVal acctid As String, ByVal lname As String, ByVal fname As String) As DataSet
    '    Dim Ds As DataSet
    '    Dim sqlstr As String
    '    Dim questr As String
    '    'Dim strdate As String
    '    questr = " acct_id='" & acctid & "'"
    '    If lname <> "" Then
    '        questr = questr & "and lname like '%" & lname & "%'"
    '    End If
    '    If fname <> "" Then
    '        questr = questr & "and fname like '%" & fname & "%'"
    '    End If
    '    'If vipno <> "" Then
    '    '    questr = questr & "and vip_no='" & vipno & "'"
    '    'End If
    '    sqlstr = "select vip_no,acct_id,lname,fname,close_date from VIP where"
    '    'sqlstr = "select acct_id,lname,fname,close_date from VIP where" ' modify by daniel for requirement
    '    sqlstr = sqlstr & questr
    '    sqlstr = sqlstr & "order by lname" '--Add by daniel for requirement

    '    Ds = Me.QueryData(sqlstr, "link_user")

    '    Return Ds
    'End Function


    '--7/21/05 - Created (maria)
    Public Function VIPDetailSearch(ByVal vipno As String) As DataSet
        Dim Ds As DataSet
        Dim sqlstr As String

        sqlstr = "select * from vip where vip_no= '" & vipno & "'"
        Ds = Me.QueryData(sqlstr, "vipsearch")
        Return Ds
    End Function


    '--7/29/05 - Created (maria)
    '--01/24/06 - Modify (daniel) for add x_st,pu_point_1,direction
    Public Function VIPaddressInsert(ByVal vipno As String, ByVal straddtype As String, ByVal strlandmark As String, ByVal strstate As String, ByVal strcity As String, ByVal strdig As Int32, ByVal strstename As String, ByVal strzip As Int32, ByVal strx_st As String, ByVal strPickup As String, ByVal strDirection As String) As Int32

        Dim iResult As Int32
        Dim strSQL As String
        strSQL = "skylimo_wr_vipaddressinsert"

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@vip_no", Trim(vipno))
                .Parameters.AddWithValue("@address_type", straddtype)
                .Parameters.AddWithValue("@landmark", strlandmark)

                .Parameters.AddWithValue("@county", strstate)
                .Parameters.AddWithValue("@city", strcity)
                .Parameters.AddWithValue("@st_no", strdig)
                .Parameters.AddWithValue("@st_name", strstename)
                .Parameters.AddWithValue("@zip", strzip)
                .Parameters.AddWithValue("@x_st", strx_st)
                .Parameters.AddWithValue("@pu_point1", strPickup)
                .Parameters.AddWithValue("@direction", strDirection)


                iResult = .ExecuteNonQuery()

            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally
            Me.CloseConnection()

        End Try

        If iResult > 0 Then
            iResult = 0
        Else
            'Define some Exception Type

        End If

        Return iResult

    End Function


    Public Function DeleteVipAddress(ByVal vipno As String, ByVal count As Int32, ByVal acctid As String, ByVal subacctid As String, ByVal company As Int32) As Int32
        Dim intReturn As Int32
        Try
            Me.OpenConnection()
            With Me.Command
                .CommandText = "skylimo_wr_vipaddressdelete"
                .CommandType = CommandType.StoredProcedure

                .Parameters.AddWithValue("@vipno", Trim(vipno))
                .Parameters.AddWithValue("@count", count)
                .Parameters.AddWithValue("@acctid", acctid)
                .Parameters.AddWithValue("@subacctid", subacctid)
                .Parameters.AddWithValue("@company", company)
                .Parameters.AddWithValue("@return", intReturn)

                .Parameters("@return").Direction = ParameterDirection.Output

                .ExecuteNonQuery()
                intReturn = CInt(.Parameters("@return").Value)

            End With
        Catch ex As Exception
            intReturn = -2 '-- unexpected error
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try

        Return intReturn
    End Function

    '--modify by daniel
    '--add fields byval strx_st,byval strPickup,byval strDirection
    Public Function VIPAddressUpdate(ByVal vipno As String, ByVal count As Int32, ByVal type As String, ByVal stno As String, ByVal stname As String, ByVal city As String, ByVal state As String, ByVal zip As String, ByVal landmark As String, ByVal strx_st As String, ByVal strPickup As String, ByVal strDirection As String) As Int32

        Dim iResult As Int32
        Dim strSQL As String
        strSQL = "skylimo_wr_vipaddressupdate"

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@vipno ", Trim(vipno))
                .Parameters.AddWithValue("@address_count", count)
                .Parameters.AddWithValue("@address_type", type)
                .Parameters.AddWithValue("@st_no", stno)
                .Parameters.AddWithValue("@st_name", stname)

                .Parameters.AddWithValue("@city", city)
                .Parameters.AddWithValue("@state", state)
                .Parameters.AddWithValue("@zip_code", zip)
                .Parameters.AddWithValue("@landmark", landmark)
                .Parameters.AddWithValue("@x_st", strx_st)
                .Parameters.AddWithValue("@pu_point1", strPickup)
                .Parameters.AddWithValue("@direction", strDirection)

                iResult = .ExecuteNonQuery

            End With
        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        If iResult > 0 Then
            iResult = 0
        End If

        Return iResult

    End Function


    '--7/29/05 - Created (maria)
    Public Function VIPAddressSelect(ByVal vipno As String) As DataSet
        Dim Ds As DataSet
        Dim sqlstr As String
        vipno = Trim(vipno)
        sqlstr = "select vip_no,acct_id,sub_acct_id,company,address_counter,address_type,st_no,st_name,city,county,zip,landmark,x_st,pu_point_1,direction,case when address_type='P' then 'Business' when address_type='D' then 'Home' else 'Other' end as type from Vip_Disp_Add where vip_no= '" & vipno & "' order by address_counter desc"
        Ds = Me.QueryData(sqlstr, "vipaddress")

        Return Ds


    End Function

    '--7/20/05 - Created (maria)
    Public Function VIPUpdate(ByVal VipInfo As UserData, ByVal vipno As String, ByRef name As String) As Int32

        Dim iResult As Int32
        Dim strSQL As String
        strSQL = "skylimo_wr_vipupdate"
        'Dim company As Int32
        'company = 1
        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@vip_no", vipno)
                .Parameters.AddWithValue("@user_name", VipInfo.user_id)
                .Parameters.AddWithValue("@acct_id", VipInfo.acct_id)
                '.Parameters.AddWithValue("@company", company)
                .Parameters.AddWithValue("@pin_no", VipInfo.PinNo)

                .Parameters.AddWithValue("@lname", VipInfo.lname)
                .Parameters.AddWithValue("@fname", VipInfo.fname)
                '--add by daniel requirement 01/19/06
                .Parameters.AddWithValue("@st_no", VipInfo.st_no)
                .Parameters.AddWithValue("@st_name", VipInfo.st_name)
                .Parameters.AddWithValue("@city", VipInfo.city)
                .Parameters.AddWithValue("@state", VipInfo.state)
                .Parameters.AddWithValue("@zip_code", VipInfo.zip_code)
                '-----------------------------------------------
                .Parameters.AddWithValue("@email", VipInfo.email)
                .Parameters.AddWithValue("@phone", VipInfo.office_phone)
                .Parameters.AddWithValue("@phone_ext", VipInfo.office_phone_ext)
                .Parameters.AddWithValue("@cc_no", VipInfo.CCNo)
                .Parameters.AddWithValue("@cc_exp", VipInfo.CCExp)
                .Parameters.AddWithValue("@cc_type", VipInfo.CCType)
                .Parameters.AddWithValue("@cc_name", VipInfo.CCName)
                .Parameters.AddWithValue("@cell_phone", VipInfo.cell_phone)

                .Parameters.AddWithValue("@fax", VipInfo.fax)
                .Parameters.AddWithValue("@contact", VipInfo.contact)
                .Parameters.AddWithValue("@country", VipInfo.country)
                .Parameters.AddWithValue("@class_one_club", VipInfo.class_one_club)
                .Parameters.AddWithValue("@aux_street_add", VipInfo.aux_street_add) '-add by daniel
                .Parameters.AddWithValue("@close_com", VipInfo.close_comment)
                '.Parameters.AddWithValue(New SqlParameter("@int_back", SqlDbType.Int))
                '.Parameters("@int_back").Direction = ParameterDirection.Output
                .Parameters.Add(New SqlParameter("@name_back", SqlDbType.VarChar, 50))
                .Parameters("@name_back").Direction = ParameterDirection.Output
                '.Parameters.AddWithValue(New SqlParameter("@sub_acct", SqlDbType.Char, 10))
                '.Parameters("@sub_acct").Direction = ParameterDirection.Output

                .ExecuteNonQuery()

                'iResult = Convert.ToInt32(.Parameters("@int_back").Value)
                name = Convert.ToString(.Parameters("@name_back").Value)
            End With
        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        If name <> "Succeed" Then
            iResult = 4004
        Else
            iResult = 1
        End If
        'If Name <> "Succeed" Then
        '    iResult = 8
        'End If
        Return iResult


    End Function

    '--7/20/05 - Created (maria)
    '--01/29/06 - modify (daniel)(ByVal VipNo As String,)
    Public Function VIPInsert(ByVal VipInfo As UserData, ByRef Name As String, ByRef vipback As String) As Int32

        Dim iResult As Int32
        Dim strSQL As String
        strSQL = "skylimo_wr_vipinsert"

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                '.Parameters.AddWithValue("@vip_no", Trim(VipNo))
                .Parameters.AddWithValue("@user_name", VipInfo.user_id)
                .Parameters.AddWithValue("@acct_id", VipInfo.acct_id)
                .Parameters.AddWithValue("@pin_no", VipInfo.PinNo)

                .Parameters.AddWithValue("@lname", VipInfo.lname)
                .Parameters.AddWithValue("@fname", VipInfo.fname)
                '.Parameters.AddWithValue("@st_no", VipInfo.st_no)
                '.Parameters.AddWithValue("@st_name", VipInfo.st_name)
                '.Parameters.AddWithValue("@city", VipInfo.city)
                '.Parameters.AddWithValue("@state", VipInfo.state)
                '.Parameters.AddWithValue("@zip_code", VipInfo.zip_code)
                '--Add by Daniel for requirement 01/19/06
                '.Parameters.AddWithValue("@st_no", VipInfo.st_no)
                '.Parameters.AddWithValue("@st_name", VipInfo.st_name)
                '.Parameters.AddWithValue("@city", VipInfo.city)
                '.Parameters.AddWithValue("@state", VipInfo.state)
                '.Parameters.AddWithValue("@zip_code", VipInfo.zip_code)
                '----------------------------------------
                .Parameters.AddWithValue("@email", VipInfo.email)
                .Parameters.AddWithValue("@phone", VipInfo.office_phone)
                .Parameters.AddWithValue("@phone_ext", VipInfo.office_phone_ext)
                .Parameters.AddWithValue("@cc_no", VipInfo.CCNo)
                .Parameters.AddWithValue("@cc_exp", VipInfo.CCExp)
                .Parameters.AddWithValue("@cc_type", VipInfo.CCType)
                .Parameters.AddWithValue("@cc_name", VipInfo.CCName)
                .Parameters.AddWithValue("@cell_phone", VipInfo.cell_phone)

                .Parameters.AddWithValue("@fax", VipInfo.fax)
                .Parameters.AddWithValue("@contact", VipInfo.contact)
                .Parameters.AddWithValue("@country", VipInfo.country)
                .Parameters.AddWithValue("@class_one_club", VipInfo.class_one_club)
                '.Parameters.AddWithValue("@aux_street_add", VipInfo.aux_street_add)
                .Parameters.Add(New SqlParameter("@Name_back", SqlDbType.VarChar, 50))
                .Parameters("@Name_back").Direction = ParameterDirection.Output
                .Parameters.Add(New SqlParameter("@vip_back", SqlDbType.Char, 10))
                .Parameters("@vip_back").Direction = ParameterDirection.Output

                .ExecuteNonQuery()

                Name = Convert.ToString(.Parameters("@Name_back").Value)
                vipback = Trim(Convert.ToString(.Parameters("@vip_back").Value))


            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        If Name <> "Succeed" Then

            iResult = 4004
        Else
            iResult = 1
        End If

        'If vipback <> "Succeed" Then
        '    iResult = 4006
        'Else
        '    If Name <> "Succeed" Then
        '        iResult = 4004
        '    Else
        '        iResult = 1
        '    End If
        'End If

        Return iResult

    End Function
    '--Cretor:Daniel 02/07/06
    '--Create a new vip to vip table
    Public Function Insert_New_VIP(ByVal VipInfo As UserData, ByRef Name As String, ByRef vipback As String) As Int32

        Dim iResult As Int32
        Dim strSQL As String
        strSQL = "skylimo_wr_vipinsert"

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@user_name", VipInfo.user_id)
                .Parameters.AddWithValue("@acct_id", "ALEPH")
                .Parameters.AddWithValue("@pin_no", "123456")
                .Parameters.AddWithValue("@lname", VipInfo.lname)
                .Parameters.AddWithValue("@fname", VipInfo.fname)
                .Parameters.AddWithValue("@email", VipInfo.email)
                .Parameters.AddWithValue("@phone", VipInfo.office_phone)
                .Parameters.AddWithValue("@phone_ext", VipInfo.office_phone_ext)
                .Parameters.AddWithValue("@cc_no", "")
                .Parameters.AddWithValue("@cc_exp", "")
                .Parameters.AddWithValue("@cc_type", "")
                .Parameters.AddWithValue("@cc_name", "")
                .Parameters.AddWithValue("@cell_phone", "")
                .Parameters.AddWithValue("@fax", "")
                .Parameters.AddWithValue("@contact", "")
                .Parameters.AddWithValue("@country", "")
                .Parameters.AddWithValue("@class_one_club", "")

                .Parameters.Add(New SqlParameter("@Name_back", SqlDbType.VarChar, 50))
                .Parameters("@Name_back").Direction = ParameterDirection.Output
                .Parameters.Add(New SqlParameter("@vip_back", SqlDbType.Char, 10))
                .Parameters("@vip_back").Direction = ParameterDirection.Output

                .ExecuteNonQuery()

                Name = Convert.ToString(.Parameters("@Name_back").Value)
                vipback = Trim(Convert.ToString(.Parameters("@vip_back").Value))

            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        If Name <> "Succeed" Then

            iResult = 4004
        Else
            iResult = 1
        End If

        Return iResult

    End Function
    '## added by joey   1/10/2008   get vip_no for quick order
    Public Function GetQuickVipNo() As String
        Dim out As String = ""
        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "apex_wr_vip_getquickvipno"
                .Parameters.Add("@vip_no", SqlDbType.VarChar, 10)
                .Parameters.Item("@vip_no").Direction = ParameterDirection.Output

                '## 1/11/2008   Fixed by yang
                .ExecuteNonQuery()
                out = Convert.ToString(.Parameters.Item("@vip_no").Value).Trim()
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try
        Return out
    End Function

    Public Function InsertVip(ByVal userdata As UserData, ByRef vip_no As String) As Int32
        Dim out As Int32
        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "apex_wr_vip_insertvip"

                .Parameters.AddWithValue("@fname", userdata.fname)
                .Parameters.AddWithValue("@lname", userdata.lname)
                .Parameters.AddWithValue("@Company", userdata.Company)
                .Parameters.AddWithValue("@username", userdata.username)
                .Parameters.AddWithValue("@acct_id", userdata.acct_id)
                .Parameters.AddWithValue("@password", userdata.password)
                .Parameters.AddWithValue("@CCType", userdata.CCType)
                .Parameters.AddWithValue("@CCNo", userdata.CCNo)
                .Parameters.AddWithValue("@CCYear", userdata.CCYear)
                .Parameters.AddWithValue("@CCMonth", userdata.CCMonth)
                .Parameters.AddWithValue("@contact", userdata.contact)
                .Parameters.AddWithValue("@office_phone", userdata.office_phone)
                .Parameters.AddWithValue("@office_phone_ext", userdata.office_phone_ext)
                .Parameters.AddWithValue("@cell_phone", userdata.cell_phone)
                .Parameters.AddWithValue("@fax", userdata.fax)
                .Parameters.AddWithValue("@home_phone", userdata.home_phone)
                .Parameters.AddWithValue("@pager_no", userdata.pager_no)
                .Parameters.AddWithValue("@office_phone_area", userdata.office_phone_area)
                .Parameters.AddWithValue("@email", userdata.email)
                .Parameters.AddWithValue("@st_name", userdata.st_name)
                .Parameters.AddWithValue("@st_no", userdata.st_no)
                .Parameters.AddWithValue("@city", userdata.city)
                .Parameters.AddWithValue("@state", userdata.state)
                .Parameters.AddWithValue("@zip_code", userdata.zip_code)
                .Parameters.AddWithValue("@sub_zip", userdata.sub_zip)
                .Parameters.AddWithValue("@quickuserid", userdata.user_id)
                .Parameters.Add("@vip_no", SqlDbType.VarChar, 20)
                .Parameters.AddWithValue("@out", SqlDbType.SmallInt)

                .Parameters.Item("@vip_no").Direction = ParameterDirection.Output
                .Parameters.Item("@out").Direction = ParameterDirection.Output
                .ExecuteNonQuery()

                vip_no = Convert.ToString(.Parameters.Item("@vip_no").Value).Trim
                out = Convert.ToInt16(.Parameters.Item("@out").Value)
            End With
        Catch ex As Exception
            out = 0
        End Try
        Return out
    End Function

    '## added by joey 11/30/2007
    'Public Function QuickInsertVIP(ByVal VipInfo As UserData, ByVal conf As String, ByRef NewUserID As String) As Int32

    '    Dim iResult As Int32
    '    Dim strSQL As String

    '    strSQL = "apex_wr_vip_quickinsertvip"

    '    Try

    '        Me.OpenConnection()

    '        With Me.Command

    '            .CommandType = CommandType.StoredProcedure
    '            .CommandText = strSQL

    '            .Parameters.AddWithValue("@user_name", VipInfo.username)
    '            .Parameters.AddWithValue("@acct_id", VipInfo.acct_id)
    '            .Parameters.AddWithValue("@sub_acct_id", VipInfo.sub_acct_id)
    '            .Parameters.AddWithValue("@pin_no", VipInfo.PinNo)
    '            .Parameters.AddWithValue("@lname", VipInfo.lname)
    '            .Parameters.AddWithValue("@fname", VipInfo.fname)
    '            .Parameters.AddWithValue("@email", VipInfo.email)
    '            .Parameters.AddWithValue("@phone", VipInfo.office_phone)
    '            .Parameters.AddWithValue("@phone_ext", VipInfo.office_phone_ext)
    '            .Parameters.AddWithValue("@conf", conf)
    '            .Parameters.Add("@vip_no", SqlDbType.VarChar, 20)
    '            .Parameters.AddWithValue("@out", SqlDbType.SmallInt)

    '            .Parameters.Item("@out").Direction = ParameterDirection.Output
    '            .ExecuteNonQuery()

    '            iResult = Convert.ToInt16(.Parameters.Item("@out").Value)
    '        End With

    '    Catch ex As Exception

    '        Me.ErrorMessage = ex.Message
    '        iResult = -1
    '    Finally

    '        Me.CloseConnection()

    '    End Try

    '    Return iResult

    'End Function

    '-------------------------------------------------------
    'Function: SearchUserByName
    'Description: Get User Info
    'Modification: 2004/10/17 nancy
    'Table:             manual_newuser,user_profile,priority,
    'Input:             Fname,Lname
    'OutPut:            datatable of user info
    '-------------------------------------------------------
    Public Function SearchUserByName(ByVal strFname As String, ByVal strLname As String, ByVal strPuIndex As String, ByVal strDept As String) As DataSet
        Dim tmpDs As DataSet
        tmpDs = Me.QueryData("exec gswr_user_getbyname " & strFname & "," & strLname & "," & strPuIndex & "," & strDept, "UserInfo")
        Return tmpDs
    End Function
    '-------------------------------------------------------
    'Function: GetAssistantInfo
    'Description: Get Assistant Info
    'Modification: 2004/10/17 nancy
    'Table:             
    'Input:             
    'OutPut:            
    '-------------------------------------------------------
    Public Function GetAssistantInfo() As DataSet
        Dim Ds As DataSet
        Ds = Me.QueryData("select user_id,fname, lname,priority from user_profile(nolock) where priority = 's' ", "Assistant")
        Return Ds
    End Function
    '-------------------------------------------------------
    'Function: SearchUserByAdminId
    'Description: Search User By AdminId
    'Modification: 2004/10/17 nancy
    'Table:             
    'Input:             
    'OutPut:            
    '-------------------------------------------------------
    Public Function SearchUserByAdminId(ByVal strAdminUserId As String) As DataSet
        Dim Ds As DataSet
        Dim sqlstr As String
        sqlstr = "select user_id,link_user_id,name=fname + ',' + lname from admin_user_link(nolock),user_profile(nolock) where link_user_id = user_id"
        sqlstr = sqlstr & " and admin_user_id = '" & strAdminUserId & "'"
        Ds = Me.QueryData(sqlstr, "link_user")
        Return Ds
    End Function
    '-------------------------------------------------------
    'Function: del_assign_user
    'Description: del_assign_user
    'Modification: 2004/10/17 nancy
    'Table:             
    'Input:             
    'OutPut:            
    '-------------------------------------------------------
    Public Function del_assign_user(ByVal admin_user_id As String, ByVal link_user_id As String) As Int16
        Dim strSQL As String
        Dim iResult As Int16
        strSQL = "delete from admin_user_link where "
        strSQL = strSQL & " admin_user_id = '" & admin_user_id & "' and "
        strSQL = strSQL & " link_user_id = '" & link_user_id & "'"
        Me.OpenConnection()
        Me.Command.CommandText = strSQL
        iResult = Convert.ToInt16(Me.Command.ExecuteNonQuery())
        Return iResult
    End Function
    '-------------------------------------------------------
    'Function: SearchUserToAgssign
    'Description: Search User To Agssign
    'Modification: 2004/10/17 nancy
    'Table:             
    'Input:             
    'OutPut:            
    '-------------------------------------------------------
    Public Function SearchUserToAgssign(ByVal strFname As String, ByVal strLname As String, ByVal strPuIndex As String, ByVal strDeptName As String, ByVal strUser_id As String) As DataSet
        Dim ds As DataSet
        ds = Me.QueryData("exec gswr_SearchUserToAssigned " & strFname & "," & strLname & "," & strPuIndex & "," & strDeptName & "," & strUser_id, "UserToAssign")
        Return ds
    End Function
    '-------------------------------------------------------
    'Function: GetAdminInfoById
    'Description: Get Admin Info By Id
    'Modification: 2004/10/17 nancy
    'Table:             
    'Input:             
    'OutPut:            
    '-------------------------------------------------------
    Public Function GetAdminInfoById(ByVal strUserId As String) As DataSet
        Dim strSQL As String
        strSQL = "select distinct(admin_user_id) from admin_user_link where link_user_id = '" & strUserId & "'"
        'strSQL = strSQL & " a.link_user_id = '" & strUserId & "'"
        Dim DS As DataSet
        DS = Me.QueryData(strSQL, "AdminInfo")
        Return DS
    End Function
    '-------------------------------------------------------
    'Function: AssignUser
    'Description: Assign User to Assistant
    'Modification: 2004/10/17 nancy
    'Table:             admin_user_link
    'Input:             admin_user_id, link_user_id
    'OutPut:           iResult
    '                  1        successful
    '                  0,-1     failed
    '                  -2       duplicate records
    '-------------------------------------------------------
    Public Function AssignUser(ByVal admin_user_id As String, ByVal link_user_id As String) As Int16
        Dim iResult As Int16
        Try
            Me.OpenConnection()
            With Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "gswr_user_assign"
                .Parameters.AddWithValue("@admin_user_id", admin_user_id)
                .Parameters.AddWithValue("@link_user_id", link_user_id)
                .Parameters.AddWithValue("@numback", SqlDbType.Int)
                .Parameters("@numback").Direction = ParameterDirection.Output
                .ExecuteNonQuery()
                iResult = Convert.ToInt16(.Parameters("@numback").Value)
            End With
        Catch ex As Exception
            Return -1
        Finally
            Me.CloseConnection()
        End Try
        Return iResult
    End Function
    '-------------------------------------------------------
    'Function: UpgradeUserToAdminAssistant
    'Description: Upgrade a Normal user to Administrator Assistant
    'Modification: 2004/10/19 wan
    'Table:             user_profile
    'Input:             user_id
    'OutPut:           iResult
    '                  1        successful
    '                  other    failed
    '                  -1       Nor original normal user found
    '-------------------------------------------------------
    Public Function UpgradeUserToAdminAssistant(ByVal user_id As String) As Integer
        Dim iResult As Integer
        Try
            Me.OpenConnection()
            Me.Command.CommandType = CommandType.StoredProcedure
            Me.Command.CommandText = "gswr_upgrade_user_to_adminassistant"
            Me.Command.Parameters.Clear()
            Me.Command.Parameters.AddWithValue("@user_id", user_id)
            Me.Command.Parameters.AddWithValue("@output", SqlDbType.SmallInt)
            Me.Command.Parameters.Item("@output").Direction = ParameterDirection.Output
            Me.Command.ExecuteNonQuery()
            iResult = Convert.ToInt32(Val(Me.Command.Parameters.Item("@output").Value))
        Catch ex As Exception
            iResult = 0
        Finally
            Me.CloseConnection()
        End Try
        Return iResult
    End Function

    '-------------------------------------------------------
    'Function: CreateNewUser
    'Description: Create a New User
    'Modification: 2004/10/17 wan
    'Table:             manual_usernew,user_profile,vip,
    'Input:             UserData, current_userid
    'OutPut:            boolean
    '-------------------------------------------------------
    Public Function CreateNewUser(ByVal usr As UserData, ByVal current_userid As String, Optional ByRef errmsg As String = "") As Boolean
        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "gswr_addUser"
                .Parameters.Clear()

                '.Parameters.Item("@user_id").Value = sec.SQLSafe(usr.user_id)
                .Parameters.AddWithValue("@user_id", usr.user_id)
                '.Parameters.Item("@fname").Value = sec.SQLSafe(usr.fname)
                .Parameters.AddWithValue("@fname", usr.fname)
                '.Parameters.Item("@lname").Value = sec.SQLSafe(usr.lname)
                .Parameters.AddWithValue("@lname", usr.lname)
                '.Parameters.Item("@password").Value = sec.SQLSafe(usr.password)
                .Parameters.AddWithValue("@password", usr.password)
                '.Parameters.Item("@st_name").Value = sec.SQLSafe(usr.st_name)
                .Parameters.AddWithValue("@st_name", usr.st_name)
                '.Parameters.Item("@st_no").Value = sec.SQLSafe(usr.st_no)
                .Parameters.AddWithValue("@st_no", usr.st_no)
                '.Parameters.Item("@city").Value = sec.SQLSafe(usr.city)
                .Parameters.AddWithValue("@city", usr.city)
                '.Parameters.Item("@state").Value = sec.SQLSafe(usr.state)
                .Parameters.AddWithValue("@state", usr.state)
                '.Parameters.Item("@zip_code").Value = sec.SQLSafe(usr.zip_code)
                .Parameters.AddWithValue("@zip_code", usr.zip_code)
                '.Parameters.Item("@email").Value = sec.SQLSafe(usr.email)
                .Parameters.AddWithValue("@email", usr.email)
                '.Parameters.Item("@cell_phone").Value = sec.SQLSafe(usr.cell_phone)
                .Parameters.AddWithValue("@cell_phone", usr.cell_phone)
                '.Parameters.Item("@pager_no").Value = sec.SQLSafe(usr.pager_no)
                .Parameters.AddWithValue("@pager_no", usr.pager_no)
                '.Parameters.Item("@office_phone").Value = sec.SQLSafe(usr.office_phone)
                .Parameters.AddWithValue("@office_phone", usr.office_phone)
                '.Parameters.Item("@office_phone_ext").Value = sec.SQLSafe(usr.office_phone_ext)
                .Parameters.AddWithValue("@office_phone_ext", usr.office_phone_ext)
                '.Parameters.Item("@pu_index").Value = sec.SQLSafe(usr.pu_index)
                .Parameters.AddWithValue("@pu_index", usr.pu_index)
                '.Parameters.Item("@priority").Value = sec.SQLSafe(usr.priority)
                .Parameters.AddWithValue("@priority", usr.priority)
                '.Parameters.Item("@comp_id_3").Value = sec.SQLSafe(usr.comp_id_3)
                .Parameters.AddWithValue("@comp_id_3", usr.comp_id_3)
                '.Parameters.Item("@comp_id_4").Value = sec.SQLSafe(usr.comp_id_4)
                .Parameters.AddWithValue("@comp_id_4", usr.comp_id_4)
                '.Parameters.Item("@active_flag").Value = sec.SQLSafe(usr.active_flag)
                .Parameters.AddWithValue("@active_flag", usr.active_flag)
                '.Parameters.Item("@term_date").Value = usr.term_date
                .Parameters.AddWithValue("@term_date", usr.term_date)
                '.Parameters.Item("@created_by").Value = CStr(Session("user_id"))
                .Parameters.AddWithValue("@created_by", current_userid)

                '.Parameters.Item("@company").Value = usr.Company
                .Parameters.AddWithValue("@company", usr.Company)
                '.Parameters.Item("@department").Value = usr.Department
                .Parameters.AddWithValue("@department", usr.Department)
                '.Parameters.Item("@division").Value = usr.Division
                .Parameters.AddWithValue("@division", usr.Division)
                '.Parameters.Item("@office").Value = usr.Office
                .Parameters.AddWithValue("@office", usr.Office)

                '.Parameters.Item("@IBD_FICC").Value = usr.IBD_FICC
                .Parameters.AddWithValue("@IBD_FICC", usr.IBD_FICC)

                '.Parameters.Item("@GUID").Value = usr.GUID
                .Parameters.AddWithValue("@GUID", usr.GUID)

                .Parameters.AddWithValue("@homedirection", usr.HomeDirection)

                .ExecuteNonQuery()

                ''---add on 09/29 by tom
                'Audit the creation
                'Security.AuditTrail_UserCreate(current_userid, usr.user_id)

                '.CommandType = CommandType.Text
                '.CommandText = "select St_No,St_Name,State,City,pu_location from pu_locations(nolock) where pu_index = '" & sec.SQLSafe(usr.pu_index) & "'"

                'Me.Reader = Me.Command.ExecuteReader
            End With

            ''-- save address template as default HOME --
            'Dim objTemplate As address_template1
            'objTemplate = New address_template1
            'objTemplate.user_id = usr.user_id
            'objTemplate.pu_landmark = ""
            'objTemplate.pu_index = usr.pu_index

            'If Me.Reader.Read Then
            '    objTemplate.pu_st_no = Me.Reader.GetString(0)
            '    objTemplate.pu_st_name = Me.Reader.GetString(1)
            '    objTemplate.pu_city = Me.Reader.GetString(2)
            '    objTemplate.pu_state = Me.Reader.GetString(3)
            'End If

            'objTemplate.dest_landmark = ""
            'objTemplate.dest_index = ""
            'objTemplate.dest_st_no = usr.st_no
            'objTemplate.dest_st_name = usr.st_name
            'objTemplate.dest_city = usr.city
            'objTemplate.dest_state = usr.state
            'objTemplate.pu_point_desc = ""
            'objTemplate.template_desc = "Home"

            ''-- Add this address to template, if already exists then it will increment counter --
            'Call objTemplate.AddWithValue()

            ''Dim audit As New audit_lib

            ''Call audit.audit_record(Session("user_id"), "New User Created:", usr.username, "10")
            ''audit = Nothing

            errmsg = "usradd"
            Return True
        Catch ex As Exception
            errmsg = ex.Message
            Return False
        Finally
            Me.CloseConnection()
        End Try
    End Function

#End Region

#Region " VIP USERS Parts"

    'creator:eJay 10/27/2004

    Public Function GetAssistantByAdminID(ByVal Vip_no As String, ByVal AcctID As String, ByVal SubAcctID As String, ByVal Company As String) As DataSet

        Dim strSQL As String = "skylimo_wr_vip_getAssistantUserInfo"
        Dim tmpDS As DataSet
        Try
            Me.SelectCommand = New SqlCommand

            With Me.SelectCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@acct_id", AcctID)
                .Parameters.AddWithValue("@sub_acct_id ", SubAcctID)
                .Parameters.AddWithValue("@Vip_no", Vip_no)
                .Parameters.AddWithValue("@company", Company)

            End With

            tmpDS = Me.QueryData("AssistantUserList")

        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return tmpDS

    End Function

    '--------------------------------------------------------------------------
    '--Function VIPUserLogin2
    '--Description:for dup vip user to login
    '--Input:UserID,Password
    '--Output:UserData
    '--11/12/04 - Created (eJay)
    '--------------------------------------------------------------------------
    Public Function VIPUserLogin2(ByVal UserID As String, ByVal Password As String) As UserData

        Dim strSQL As String
        strSQL = "MTC_wr_vip_userlogin2"

        Dim objUserData As New UserData

        Try
            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@user_id", UserID)
                .Parameters.AddWithValue("@pin_no", Password)

                Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)
                If Me.Reader.Read Then

                    With Me.Reader

                        objUserData.Name = Me.Check_DBNULL(.Item("name"))
                        If objUserData.Name Is Nothing Then

                            objUserData.checkAccount = "No Account"
                        Else

                            objUserData.checkAccount = ""

                        End If

                        objUserData.user_id = Convert.ToString(.Item("vip_no")).Trim()
                        objUserData.acct_id = Convert.ToString(.Item("acct_id")).Trim()
                        objUserData.sub_acct_id = Convert.ToString(.Item("sub_acct_id")).Trim()
                        objUserData.Company = Convert.ToString(.Item("company")).Trim()

                        objUserData.fname = Me.Check_DBNULL(.Item("fname"))
                        objUserData.lname = Me.Check_DBNULL(.Item("lname"))
                        objUserData.PinNo = Me.Check_DBNULL(.Item("pin_no"))
                        objUserData.check_user = ""

                        objUserData.Internet = Me.Check_DBNULL(.Item("internet"))
                        objUserData.accountcompany = Convert.ToString(.Item("acompany"))

                        If Not IsDBNull(.Item("table_id")) Then
                            objUserData.table_id = Convert.ToInt32(.Item("table_id"))
                        Else
                            objUserData.table_id = 0
                        End If

                        'Dim objDate As Date
                        objUserData.close_date = Me.Check_DBNULL(.Item("close_date"))

                        'If Not IsDBNull(.Item("close_date")) Then
                        '    objUserData.close_date = Convert.ToString(.Item("close_date"))
                        'Else
                        '    objUserData.close_date = Nothing
                        'End If

                    End With

                Else

                    objUserData.check_user = "No User"

                End If

            End With

        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Return objUserData

    End Function

    'Purpose   :To find a special vip user
    'Accept    :UserID,Password
    'Return    :UserData
    Public Function VipUserLogin(ByVal UserID As String, ByVal Password As String) As UserData


        Dim strSQL As String
        strSQL = "APEX_wr_vip_vipselect"

        Dim strFirst As String
        Dim objUserData As New UserData

        Try
            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@user_id", UserID)
                .Parameters.AddWithValue("@pin_no", Password)

                strFirst = Convert.ToString(.ExecuteScalar()).Trim

                '--add by eJay 2/1/05
                If strFirst.CompareTo("No Time") = 0 Then
                    objUserData.check_user = "No Time"
                ElseIf strFirst.CompareTo("No User") = 0 Then

                    objUserData.check_user = "No User"

                ElseIf strFirst.CompareTo("Dup User") = 0 Then
                    objUserData.check_user = "Dup User"
                ElseIf strFirst.CompareTo("Password incorrect") = 0 Then
                    objUserData.check_user = "Password incorrect"
                ElseIf strFirst.CompareTo("Close date is valid") = 0 Then
                    objUserData.check_user = "Close date is valid"
                Else
                    Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)
                    If Me.Reader.Read Then

                        With Me.Reader

                            objUserData.Name = Me.Check_DBNULL(.Item("name"))
                            objUserData.acct_name = Me.Check_DBNULL(.Item("name")).Trim

                            If objUserData.Name Is Nothing Then
                                objUserData.checkAccount = "No Account"
                            Else
                                objUserData.checkAccount = ""
                            End If

                            objUserData.priority = Me.Check_DBNULL(.Item("priority"))   '--add by daniel for a.priority 15/12/2006
                            'objUserData.CC_V_Code = Me.Check_DBNULL(.Item("cc_v_code"))
                            objUserData.email = Convert.ToString(IIf(IsDBNull(.Item("email_address")), "", .Item("email_address"))).Trim()
                            'objUserData.email_text_format = Convert.ToString(IIf(IsDBNull(.Item("email_text_format")), "N", .Item("email_text_format"))).Trim()
                            objUserData.user_id = Convert.ToString(.Item("vip_no")).Trim()
                            objUserData.acct_id = Convert.ToString(.Item("acct_id")).Trim()
                            objUserData.sub_acct_id = Convert.ToString(.Item("sub_acct_id")).Trim()
                            objUserData.Company = Convert.ToString(.Item("company")).Trim()

                            objUserData.fname = Me.Check_DBNULL(.Item("fname"))
                            objUserData.lname = Me.Check_DBNULL(.Item("lname"))
                            objUserData.PinNo = Me.Check_DBNULL(.Item("pin_no"))
                            objUserData.check_user = ""

                            objUserData.Internet = Me.Check_DBNULL(.Item("internet"))
                            objUserData.accountcompany = Convert.ToString(.Item("acompany"))

                            If Not IsDBNull(.Item("table_id")) AndAlso IsNumeric(.Item("table_id")) Then
                                objUserData.table_id = Convert.ToInt32(.Item("table_id"))
                            Else
                                objUserData.table_id = 1
                            End If

                            objUserData.close_date = Me.Check_DBNULL(.Item("close_date"))

                            '--add by daniel for name and user_name 21/09/2006
                            'objUserData.Name = Me.Check_DBNULL(.Item("name"))

                            objUserData.username = Me.Check_DBNULL(.Item("user_name"))

                            objUserData.level1_id = Me.Check_DBNULL(.Item("level_id")).Trim

                        End With

                    Else

                        objUserData.check_user = "No User"

                    End If

                End If

            End With

        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Return objUserData

    End Function
    'Purpose   :To find a special vip user
    'Accept    :UserID,Password
    'Return    :UserData
    Public Function VipUserLoginby(ByVal UserID As String, ByVal Password As String, _
                ByVal AcctID As String, ByVal SubAcctID As String, ByVal MustHasPinNo As Boolean) As UserData


        Dim strSQL As String
        strSQL = "APEX_wr_vip_vipselect_by"

        Dim strFirst As String
        Dim objUserData As New UserData

        Try
            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@user_id", UserID)
                .Parameters.AddWithValue("@pin_no", Password)
                .Parameters.AddWithValue("@acct_id", AcctID)
                .Parameters.AddWithValue("@sub_acct_id", SubAcctID)
                .Parameters.AddWithValue("@must_has_pin_no", IIf(MustHasPinNo, "Y", "N"))

                strFirst = Convert.ToString(.ExecuteScalar()).Trim

                If strFirst.CompareTo("No Time") = 0 Then
                    objUserData.check_user = "No Time"
                ElseIf strFirst.CompareTo("No User") = 0 Then
                    objUserData.check_user = "No User"
                ElseIf strFirst.CompareTo("Dup User") = 0 Then
                    objUserData.check_user = "Dup User"
                ElseIf strFirst.CompareTo("Password incorrect") = 0 Then
                    objUserData.check_user = "Password incorrect"
                Else
                    Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)
                    If Me.Reader.Read Then

                        With Me.Reader

                            objUserData.Name = Me.Check_DBNULL(.Item("name"))
                            If objUserData.Name Is Nothing Then

                                objUserData.checkAccount = "No Account"
                            Else

                                objUserData.checkAccount = ""

                            End If

                            ' objUserData.priority = Me.Check_DBNULL(.Item("priority"))   '--add by daniel for a.priority 15/12/2006
                            'objUserData.CC_V_Code = Me.Check_DBNULL(.Item("cc_v_code"))
                            '  objUserData.email = Convert.ToString(IIf(IsDBNull(.Item("email_address")), "", .Item("email_address"))).Trim()
                            'objUserData.email_text_format = Convert.ToString(IIf(IsDBNull(.Item("email_text_format")), "N", .Item("email_text_format"))).Trim()
                            objUserData.level1_id = Convert.ToString(.Item("level_id")).Trim()
                            objUserData.user_id = Convert.ToString(.Item("vip_no")).Trim()
                            objUserData.acct_id = Convert.ToString(.Item("acct_id")).Trim()
                            objUserData.sub_acct_id = Convert.ToString(.Item("sub_acct_id")).Trim()
                            'objUserData.Company = Convert.ToString(.Item("company")).Trim()

                            objUserData.fname = Me.Check_DBNULL(.Item("fname"))
                            objUserData.lname = Me.Check_DBNULL(.Item("lname"))
                            objUserData.PinNo = Me.Check_DBNULL(.Item("pin_no"))
                            objUserData.check_user = ""

                            objUserData.Internet = Me.Check_DBNULL(.Item("internet"))
                            objUserData.accountcompany = Convert.ToString(.Item("acompany"))

                            If Not IsDBNull(.Item("table_id")) Then
                                objUserData.table_id = Convert.ToInt32(.Item("table_id"))
                            Else
                                objUserData.table_id = 0
                            End If

                            objUserData.close_date = Me.Check_DBNULL(.Item("close_date"))
                            '--add by daniel for name and user_name 21/09/2006
                            objUserData.Name = Me.Check_DBNULL(.Item("name"))
                            objUserData.username = Me.Check_DBNULL(.Item("user_name"))

                        End With

                    Else

                        objUserData.check_user = "No User"

                    End If

                End If

            End With

        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Return objUserData

    End Function
    'Purpose   :To find a special vip user
    'Accept    :UserID,fname,lname,Password
    'Return    :UserData
    Public Function VipUserLogon2(ByVal UserID As String, ByVal fname As String, ByVal lname As String, ByVal Password As String) As UserData


        Dim strSQL As String
        strSQL = "MTC_wr_vip_vipselectLogon2"

        Dim strFirst As String
        Dim objUserData As New UserData

        Try
            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@user_id", UserID)
                .Parameters.AddWithValue("@fname", fname)
                .Parameters.AddWithValue("@lname", lname)
                .Parameters.AddWithValue("@pin_no", Password)

                strFirst = Convert.ToString(.ExecuteScalar()).Trim

                '--add by eJay 2/1/05
                If strFirst.CompareTo("No Time") = 0 Then
                    objUserData.check_user = "No Time"
                ElseIf strFirst.CompareTo("No User") = 0 Then

                    objUserData.check_user = "No User"

                ElseIf strFirst.CompareTo("Dup User") = 0 Then
                    objUserData.check_user = "Dup User"
                ElseIf strFirst.CompareTo("Password incorrect") = 0 Then
                    objUserData.check_user = "Password incorrect"
                Else
                    Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)
                    If Me.Reader.Read Then

                        With Me.Reader

                            objUserData.Name = Me.Check_DBNULL(.Item("name"))
                            If objUserData.Name Is Nothing Then

                                objUserData.checkAccount = "No Account"
                            Else

                                objUserData.checkAccount = ""

                            End If

                            objUserData.email = Convert.ToString(IIf(IsDBNull(.Item("email_add")), "", .Item("email_add"))).Trim()
                            objUserData.email_text_format = Convert.ToString(IIf(IsDBNull(.Item("email_text_format")), "N", .Item("email_text_format"))).Trim()
                            objUserData.user_id = Convert.ToString(.Item("vip_no")).Trim()
                            objUserData.acct_id = Convert.ToString(.Item("acct_id")).Trim()
                            objUserData.sub_acct_id = Convert.ToString(.Item("sub_acct_id")).Trim()
                            objUserData.Company = Convert.ToString(.Item("company")).Trim()

                            objUserData.fname = Me.Check_DBNULL(.Item("fname"))
                            objUserData.lname = Me.Check_DBNULL(.Item("lname"))
                            objUserData.PinNo = Me.Check_DBNULL(.Item("pin_no"))
                            objUserData.check_user = ""

                            objUserData.Internet = Me.Check_DBNULL(.Item("internet"))
                            objUserData.accountcompany = Convert.ToString(.Item("acompany"))

                            If Not IsDBNull(.Item("table_id")) Then
                                objUserData.table_id = Convert.ToInt32(.Item("table_id"))
                            Else
                                objUserData.table_id = 0
                            End If

                            objUserData.close_date = Me.Check_DBNULL(.Item("close_date"))


                        End With

                    Else

                        objUserData.check_user = "No User"

                    End If

                End If

            End With

        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Return objUserData

    End Function
    '------------------------------------------------------------------------------
    '-- function check_term_condition_is_set(uid,aid,sid,co)
    '-- 9/13/05 Check if the term_condition is set for this vip (Naoki)
    '-- 05/09/06 add by (daniel)
    '------------------------------------------------------------------------------
    Public Function check_term_condition_is_set(ByVal uid As String, ByVal aid As String, ByVal sid As String, ByVal co As String) As Boolean
        Dim SQLStr_tc As String
        Dim dr As DataSet
        Dim bolTCset As Boolean

        SQLStr_tc = "select term_condition_timestamp from vip (nolock) "
        SQLStr_tc = SQLStr_tc & " where vip_no = '" & sqlsafe(uid) & "' "
        SQLStr_tc = SQLStr_tc & " and acct_id = '" & sqlsafe(aid) & "' and sub_acct_id = '" & sqlsafe(sid) & "' "
        SQLStr_tc = SQLStr_tc & " and company = '" & sqlsafe(co) & "' " '-- 9/13/04 added for user w/ duplicate vip_no

        Try
            dr = Me.QueryData(SQLStr_tc, "vip")
        Catch ex As Exception
            dr = Nothing
        End Try

        bolTCset = False
        If Not dr Is Nothing Then
            If dr.Tables.Count > 0 Then
                If dr.Tables(0).Rows.Count > 0 Then
                    If IsDBNull(dr.Tables(0).Rows(0).Item(0)) Then
                        bolTCset = False
                    ElseIf IsDate(dr.Tables(0).Rows(0).Item(0)) = True Then
                        bolTCset = True
                    Else
                        bolTCset = False
                    End If
                Else
                    bolTCset = False
                End If
            Else
                bolTCset = False
            End If
        Else
            bolTCset = False
        End If

        dr.Dispose() : dr = Nothing
        check_term_condition_is_set = bolTCset

    End Function
    '------------------------------------------------------------------------------
    '-- function check_challenge_question(uid,aid,sid,co)
    '-- 9/13/05 Check if the challenge_question is set for this vip (Naoki)
    '-- 05/09/06 add by (daniel)
    '------------------------------------------------------------------------------
    Public Function check_challenge_question(ByVal uid As String, ByVal aid As String, ByVal sid As String, ByVal co As String) As Boolean
        Dim SQLStr_tc As String
        Dim dr As DataSet
        Dim bolTCset As Boolean

        SQLStr_tc = "select isnull(challenge_question,'') from vip (nolock)"
        SQLStr_tc = SQLStr_tc & " where vip_no = '" & sqlsafe(uid) & "' "
        SQLStr_tc = SQLStr_tc & " and acct_id = '" & sqlsafe(aid) & "' and sub_acct_id = '" & sqlsafe(sid) & "' "
        SQLStr_tc = SQLStr_tc & " and company = '" & sqlsafe(co) & "' " '-- 9/13/04 added for user w/ duplicate vip_no

        Try
            dr = Me.QueryData(SQLStr_tc, "vip")
        Catch ex As Exception
            dr = Nothing
        End Try

        bolTCset = False
        If Not dr Is Nothing Then
            If dr.Tables.Count > 0 Then
                If dr.Tables(0).Rows.Count > 0 Then
                    If IsDBNull(dr.Tables(0).Rows(0).Item(0)) Then
                        bolTCset = False
                    ElseIf Trim(dr.Tables(0).Rows(0).Item(0).ToString) <> "" Then
                        bolTCset = True
                    Else
                        bolTCset = False
                    End If
                Else
                    bolTCset = False
                End If
            Else
                bolTCset = False
            End If
        Else
            bolTCset = False
        End If

        dr.Dispose() : dr = Nothing
        check_challenge_question = bolTCset

    End Function
    '------------------------------------------------------------------------------
    '-- function Email_getpassword_for(stremail)
    '-- 9/13/05 Check if the Email_getpassword_for is set for this vip (Naoki)
    '-- 06/21/06 add by (daniel)
    '------------------------------------------------------------------------------
    Public Function Email_password_find(ByVal strLogin As String, ByVal challenge_question As String, ByVal strpin_no As String) As Boolean
        Dim SQLStr As String
        Dim dr As DataSet
        Dim bolValid As Boolean

        '-- 9/14/05 updated to validate with challenge question (Naoki)
        SQLStr = "select user_name,pin_no,email_add from vip(nolock) where "
        SQLStr = SQLStr & " user_name = '" & sqlsafe(strLogin) & "' "
        'SQLStr = SQLStr & " and acct_id ='" & sqlsafe( strAcctID)& "'"
        'SQLStr = SQLStr & " and email_add ='" & sqlsafe( strEmail)& "'"
        SQLStr = SQLStr & " and challenge_question = '" & sqlsafe(challenge_question) & "'"

        Try
            dr = Me.QueryData(SQLStr, "Vip")
        Catch ex As Exception
            dr = Nothing
        End Try

        If Not dr Is Nothing Then
            If dr.Tables.Count > 0 Then
                If dr.Tables(0).Rows.Count > 0 Then
                    strpin_no = Me.Check_DBNULL(dr.Tables(0).Rows(0).Item("pin_no"))
                    Call sendemail(Me.Check_DBNULL(dr.Tables(0).Rows(0).Item("email_add").ToString), Me.Check_DBNULL(dr.Tables(0).Rows(0).Item("pin_no").ToString), Convert.ToString(IIf(IsDBNull(dr.Tables(0).Rows(0).Item("user_name")), "", dr.Tables(0).Rows(0).Item("user_name").ToString)))
                    bolValid = True
                Else
                    bolValid = False
                End If
            Else
                bolValid = False
            End If
        Else
            bolValid = False
        End If
        Email_password_find = bolValid
        dr.Dispose()
        dr = Nothing

    End Function
    '------------------------------------------------------------------------------
    '-- function Email_getpassword_for(stremail)
    '-- 9/13/05 Check if the Email_getpassword_for is set for this vip (Naoki)
    '-- 06/21/06 add by (daniel)
    '------------------------------------------------------------------------------
    Public Function Email_getpassword_for(ByVal stremail As String) As Boolean
        Dim SQLStr As String
        Dim dr As DataSet
        Dim bolValid As Boolean

        SQLStr = "select user_name,pin_no,email_add from vip(nolock) where "
        SQLStr = SQLStr & " email_add = '" & sqlsafe(stremail) & "' "

        Try
            dr = Me.QueryData(SQLStr, "vipemailtable")
        Catch ex As Exception
            dr = Nothing
        End Try

        bolValid = False
        If Not dr Is Nothing Then
            If dr.Tables.Count > 0 Then
                If dr.Tables(0).Rows.Count > 0 Then

                    Call sendemail(Trim(dr.Tables(0).Rows(0).Item("email_add").ToString), Trim(dr.Tables(0).Rows(0).Item("pin_no").ToString), Convert.ToString(IIf(IsDBNull(dr.Tables(0).Rows(0).Item("user_name")), "", dr.Tables(0).Rows(0).Item("user_name").ToString)))
                    bolValid = True
                Else
                    bolValid = False
                End If
            Else
                bolValid = False
            End If
        Else
            bolValid = False
        End If

        dr.Dispose() : dr = Nothing
        Email_getpassword_for = bolValid
    End Function
    '------------------------------------------------------------------------------
    '-- function find_challenge_question(strusername)
    '-- 9/13/05 Check if the challenge_question is set for this vip (Naoki)
    '-- 05/09/06 add by (daniel)
    '------------------------------------------------------------------------------
    Public Function find_challenge_question(ByVal strusername As String) As String
        Dim SQLStr_tc As String
        Dim dr As DataSet

        SQLStr_tc = "select isnull(challenge_question,'') from vip (nolock)"
        'SQLStr_tc = SQLStr_tc & " where user_name = '" & sqlsafe(strusername) & "' "
        SQLStr_tc = SQLStr_tc & " where email_add = '" & sqlsafe(strusername) & "' "

        Try
            dr = Me.QueryData(SQLStr_tc, "vip")
        Catch ex As Exception
            dr = Nothing
        End Try

        If Not dr Is Nothing Then
            If dr.Tables.Count > 0 Then
                If dr.Tables(0).Rows.Count > 0 Then
                    If IsDBNull(dr.Tables(0).Rows(0).Item(0)) Then
                        find_challenge_question = ""
                    ElseIf Trim(dr.Tables(0).Rows(0).Item(0).ToString) <> "" Then
                        find_challenge_question = dr.Tables(0).Rows(0).Item(0).ToString
                    Else
                        find_challenge_question = ""
                    End If
                Else
                    find_challenge_question = ""
                End If
            Else
                find_challenge_question = ""
            End If
        Else
            find_challenge_question = ""
        End If

        dr.Dispose()
        dr = Nothing

        Return find_challenge_question

    End Function
    '------------------------------------------------------------------------------
    '-- function challenge_question_for(strusername,strquestion)
    '-- 9/13/05 Check if the challenge_question_for is set for this vip (Naoki)
    '-- 05/09/06 add by (daniel)
    '------------------------------------------------------------------------------
    Public Function challenge_question_for(ByVal strLogin As String, ByVal strchallenge_ask As String) As Boolean
        Dim SQLStr As String
        Dim dr As DataSet
        Dim bolValid As Boolean

        SQLStr = "select pin_no,email_add from vip(nolock) where "
        SQLStr = SQLStr & " user_name = '" & sqlsafe(strLogin) & "' "
        'SQLStr = SQLStr & " and acct_id ='" & sqlsafe( strAcctID)& "'"
        'SQLStr = SQLStr & " and email_add ='" & sqlsafe( strEmail)& "'"
        SQLStr = SQLStr & " and challenge_ask = '" & sqlsafe(strchallenge_ask) & "'"

        dr = Me.QueryData(SQLStr, "viptable")

        bolValid = False
        If dr.Tables(0).Rows.Count > 0 Then

            Call sendemail(Trim(dr.Tables(0).Rows(0).Item("email_add").ToString), Trim(dr.Tables(0).Rows(0).Item("pin_no").ToString), strLogin)
            bolValid = True
        Else
            bolValid = False
        End If

        dr.Dispose() : dr = Nothing
        challenge_question_for = bolValid
    End Function
    ''------------------------------------------------------------------------------
    ''-- function challenge_question_for(strusername,strquestion)
    ''-- 9/13/05 Check if the challenge_question_for is set for this vip (Naoki)
    ''-- 05/09/06 add by (daniel)
    ''------------------------------------------------------------------------------
    'Public Function Get_PasswordEmail(ByVal strLogin As String, ByVal challenge_question As String) As Boolean
    '    Dim SQLStr As String
    '    Dim dr As DataSet
    '    Dim bolValid As Boolean

    '    SQLStr = "select pin_no,email_add from vip(nolock) where "
    '    SQLStr = SQLStr & " user_name = '" & sqlsafe(strLogin) & "' "
    '    'SQLStr = SQLStr & " and acct_id ='" & sqlsafe( strAcctID)& "'"
    '    'SQLStr = SQLStr & " and email_add ='" & sqlsafe( strEmail)& "'"
    '    SQLStr = SQLStr & " and challenge_question = '" & sqlsafe(challenge_question) & "'"

    '    dr = Me.QueryData(SQLStr, "viptable")

    '    bolValid = False
    '    If dr.Tables(0).Rows.Count > 0 Then

    '        Call sendemail(Trim(dr.Tables(0).Rows(0).Item("email_add").ToString), Trim(dr.Tables(0).Rows(0).Item("pin_no").ToString), strLogin)
    '        bolValid = True
    '    Else
    '        bolValid = False
    '    End If

    '    dr.Dispose() : dr = Nothing

    'End Function
    '------------------------------------------------------------------------------
    '-- function set_term_condition(uid,aid,sid,co)
    '-- 9/13/05 Check if the challenge_question is set for this vip (Naoki)
    '-- 05/09/06 add by (daniel)
    '------------------------------------------------------------------------------
    Public Function set_term_condition(ByVal uid As String, ByVal aid As String, ByVal sid As String, ByVal co As String, ByVal strChallenge_question As String, ByVal strSet_Challenge_question As String) As Boolean
        Dim SQLStr As String
        Dim dr As DataSet
        'Dim bolTCset As Boolean
        '-- set the term condition field in vip table 
        SQLStr = "update vip set term_condition_timestamp = getdate() "
        If StrComp(strSet_Challenge_question, "Y", CompareMethod.Text) = 0 And strChallenge_question <> "" Then
            SQLStr = SQLStr & " , challenge_question = '" & sqlsafe(strChallenge_question) & "'"
        End If
        SQLStr = SQLStr & " where vip_no = '" & sqlsafe(uid) & "'"
        SQLStr = SQLStr & " and acct_id = '" & sqlsafe(aid) & "' and sub_acct_id = '" & sqlsafe(sid) & "' "
        SQLStr = SQLStr & " and company = '" & sqlsafe(co) & "' " '-- 9/13/04 added for user w/ duplicate vip_no

        dr = Me.QueryData(SQLStr, "vip")
        dr.Dispose()
        dr = Nothing

    End Function

    '----------------------------------------------------------------
    '--Function:PasswordFind
    '--Description:Find password to be send
    '--Input:UserID,AcctID,Email
    '--Output:Password
    '--11/10/04 - Created (eJay)
    Public Function PasswordFind(ByVal UserID As String, ByVal Email As String) As String

        Dim strSQL As String
        strSQL = "skylimo_wr_vip_passwordfind"

        Dim strResult As String = ""

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@vip_no", UserID)
                '.Parameters.AddWithValue("@acct_id", AcctID)
                .Parameters.AddWithValue("@email", Email)

                strResult = .ExecuteScalar().ToString

            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Return strResult

    End Function

    '----------------------------------------------------------------
    '--Function PasswordUpdate
    '--Description:Update the password
    '--Input:UserID,AcctID,Sub_acct_id,Company,Password
    '--Output:1-Success;0-Failed
    '--11/10/04 - Created (eJay)
    '----------------------------------------------------------------
    Public Function PasswordUpdate(ByVal UserID As String, ByVal AcctID As String, ByVal Sub_acct_id As String, ByVal Company As Int16, ByVal Password As String) As Int16

        Dim strSQL As String
        strSQL = "skylimo_wr_vip_passwordupdate"

        Dim iResult As Int16

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@vip_no", UserID)
                .Parameters.AddWithValue("@acct_id", AcctID)
                .Parameters.AddWithValue("@sub_acct_id", Sub_acct_id)
                .Parameters.AddWithValue("@company", Company)
                .Parameters.AddWithValue("@password", Password)
                .Parameters.AddWithValue("@num_back", iResult)
                .Parameters("@num_back").Direction = ParameterDirection.Output

                .ExecuteNonQuery()

                iResult = Convert.ToInt16(.Parameters("@num_back").Value)

            End With
        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Return iResult

    End Function

    '----------------------------------------------------------------
    '--Function VIPUserGet
    '--Description:Get VIP User Information for updated
    '--Input:UserID,Account ID,Sub Account ID,Company
    '--Output:UserData
    '--10/28/04 - Created(eJay)
    '----------------------------------------------------------------
    Public Function VIPUserGet(ByVal UserID As String, ByVal Acct_id As String, ByVal Sub_acct_id As String, ByVal Company As Int16) As UserData

        Dim strSQL As String
        Dim objUserData As New UserData
        strSQL = "APEX_wr_vip_getvip"

        Try
            Me.OpenConnection()

            With Me.Command


                .CommandText = strSQL
                .CommandType = CommandType.StoredProcedure

                .Parameters.AddWithValue("@user_id", UserID)
                .Parameters.AddWithValue("@acct_id", Acct_id)
                .Parameters.AddWithValue("@sub_acct_id", Sub_acct_id)
                .Parameters.AddWithValue("@Company", Company)

                Me.Reader = Me.Command.ExecuteReader(CommandBehavior.SingleRow)

                If Me.Reader.Read Then

                    With Me.Reader

                        objUserData.user_id = Convert.ToString(.Item("vip_no")).Trim()

                        objUserData.fname = Me.Check_DBNULL(.Item("fname"))
                        objUserData.lname = Me.Check_DBNULL(.Item("lname"))
                        objUserData.st_no = Me.Check_DBNULL(.Item("st_no"))
                        objUserData.st_name = Me.Check_DBNULL(.Item("st_name"))
                        objUserData.city = Me.Check_DBNULL(.Item("city"))
                        objUserData.state = Me.Check_DBNULL(.Item("state"))
                        objUserData.zip_code = Me.Check_DBNULL(.Item("zip_code"))
                        objUserData.email = Me.Check_DBNULL(.Item("email_address"))
                        objUserData.office_phone = Me.Check_DBNULL(.Item("phone"))
                        objUserData.office_phone_ext = Me.Check_DBNULL(.Item("phone_ext"))
                        objUserData.CCNo = Me.Check_DBNULL(.Item("cc_no"))
                        objUserData.CCType = Me.Check_DBNULL(.Item("cc_type"))
                        objUserData.CCExp = Me.Check_DBNULL(.Item("cc_exp"))
                        'objUserData.CCName = Me.Check_DBNULL(.Item("cc_name"))
                        '--add by eJay 11/17/04 
                        objUserData.cell_phone = Me.Check_DBNULL(.Item("cell_phone"))

                        '--add by eJay 11/30/04
                        'objUserData.aux_street_add = Me.Check_DBNULL(.Item("aux_street_add"))
                        objUserData.fax = Me.Check_DBNULL(.Item("fax"))

                        If Not objUserData.CCName Is Nothing Then
                            If objUserData.CCName.Length = 0 Then
                                objUserData.CCName = objUserData.fname & " " & objUserData.lname
                            End If
                        End If

                        If Me.Check_DBNULL(.Item("cc_exp")) Is Nothing Then

                            objUserData.CCMonth = ""
                            objUserData.CCYear = ""

                        Else

                            objUserData.CCMonth = Left(.Item("cc_exp").ToString.Trim, 2)
                            objUserData.CCYear = Right(.Item("cc_exp").ToString.Trim, 2)

                        End If

                        '--add by eJay 12/24/04
                        'objUserData.CCType1 = Me.Check_DBNULL(.Item("cc_type_2"))
                        'objUserData.CCNo1 = Me.Check_DBNULL(.Item("cc_no_2"))
                        'If Me.Check_DBNULL(.Item("cc_exp_2")) Is Nothing Then

                        '    objUserData.CCMonth1 = ""
                        '    objUserData.CCYear1 = ""

                        'Else

                        '    objUserData.CCMonth1 = Left(.Item("cc_exp_2").ToString.Trim, 2)
                        '    objUserData.CCYear1 = Right(.Item("cc_exp_2").ToString.Trim, 2)

                        'End If

                        '--add by eJay 12/30/04
                        'objUserData.CCName1 = Me.Check_DBNULL(.Item("cc_name_2"))
                        '--add by daniel
                        objUserData.pager_no = Me.Check_DBNULL(.Item("pager"))
                        objUserData.home_phone = Me.Check_DBNULL(.Item("home_phone"))
                        objUserData.office_phone_area = Me.Check_DBNULL(.Item("phone_2"))
                        objUserData.office_phone_area_ext = Me.Check_DBNULL(.Item("phone_ext_2"))   '--add by daniel 29'/11/06 for phone_2
                        'objUserData.class_one_club = Me.Check_DBNULL(.Item("class_one_club"))       '--add by daniel 30/10/06 for class_one_club
                        '--add by daniel for cc_v_code
                        'objUserData.CC_V_Code = Me.Check_DBNULL(.Item("cc_v_code"))
                        'objUserData.CC_V_Code2 = Me.Check_DBNULL(.Item("cc_v_code_2"))

                    End With

                End If

            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Return objUserData

    End Function
    '-----------------------------------------------------------------
    '--Function:VIPUserInsert
    '--Description:Update the VIP Info
    '--Input:Class UserData
    '--Output:1--success,0--failed
    '--11/17/04 - Created(eJay)
    '--11/18/04 - Updated new code (eJay)
    '-----------------------------------------------------------------
    Public Function VIPQuickPassengerUserInsert(ByVal VipInfo As UserData, ByRef Name As String) As Int32

        Dim iResult As Int32
        Dim strSQL As String
        strSQL = "MTC_wr_vip_QuickPassengerinsert"

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
                '--add by daniel 6/12/2006
                .Parameters.AddWithValue("@cc_v_code", VipInfo.CC_V_Code)
                .Parameters.AddWithValue("@cc_name", VipInfo.CCName)
                '------------------------------------------------------
                .Parameters.AddWithValue("@acct_id", VipInfo.acct_id)
                .Parameters.AddWithValue("@sub_acct_id", "0000000000")
                .Parameters.AddWithValue("@company", VipInfo.Company)
                .Parameters.AddWithValue("@lname", VipInfo.lname)
                .Parameters.AddWithValue("@fname", VipInfo.fname)
                .Parameters.AddWithValue("@acct_name", VipInfo.acct_name)
                .Parameters.AddWithValue("@vip_flag", "P")
                .Parameters.AddWithValue("@level_id", "5")
                .Parameters.AddWithValue("@phone", VipInfo.office_phone)
                .Parameters.AddWithValue("@phone_ext", VipInfo.office_phone_ext)
                .Parameters.AddWithValue("@fax", VipInfo.fax)
                .Parameters.AddWithValue("@open_date", "")
                .Parameters.AddWithValue("@priority", "A")
                .Parameters.AddWithValue("@contact", VipInfo.contact)

                .Parameters.AddWithValue("@st_no", VipInfo.st_no)
                .Parameters.AddWithValue("@st_name", VipInfo.st_name)
                .Parameters.AddWithValue("@aux_street_add", VipInfo.aux_street_add)
                .Parameters.AddWithValue("@city", VipInfo.city)
                .Parameters.AddWithValue("@state", VipInfo.state)
                .Parameters.AddWithValue("@zip_code", VipInfo.zip_code)
                .Parameters.AddWithValue("@sub_zip_code", VipInfo.sub_zip)
                .Parameters.AddWithValue("@country", VipInfo.country)
                .Parameters.AddWithValue("@email_add", VipInfo.email)

                .Parameters.AddWithValue("@cc_no", VipInfo.CCNo)
                .Parameters.AddWithValue("@cc_exp", VipInfo.CCExp)
                .Parameters.AddWithValue("@cc_type", VipInfo.CCType)
                .Parameters.AddWithValue("@class_one_club", VipInfo.class_one_club)
                .Parameters.AddWithValue("@cell_phone", VipInfo.cell_phone)

                .Parameters.AddWithValue("@home_phone", VipInfo.home_phone)
                .Parameters.AddWithValue("@pager", VipInfo.pager_no)
                .Parameters.AddWithValue("@phone_2", VipInfo.office_phone_area)
                '===============================================================
                '===add by daniel 05/05/06
                .Parameters.AddWithValue("@user_name", VipInfo.username)
                .Parameters.AddWithValue("@pin_no", VipInfo.PinNo)
                .Parameters.AddWithValue("@airline_name", VipInfo.airport_airline)
                '===============================================================

                .Parameters.Add(New SqlParameter("@Name_back", SqlDbType.VarChar, 50))
                .Parameters("@Name_back").Direction = ParameterDirection.Output

                .ExecuteNonQuery()

                Name = Convert.ToString(.Parameters("@Name_back").Value)

            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        If Name <> "Succeed" Then
            iResult = 4004
        Else
            iResult = 1
        End If

        Return iResult

    End Function
    '-----------------------------------------------------------------
    '--Function:VIPUserInsert
    '--Description:Update the VIP Info
    '--Input:Class UserData
    '--Output:1--success,0--failed
    '--11/17/04 - Created(eJay)
    '--11/18/04 - Updated new code (eJay)
    '-----------------------------------------------------------------
    Public Function VIPUserInsert(ByVal VipInfo As UserData, ByRef Name As String) As Int32

        Dim iResult As Int32
        Dim strSQL As String
        strSQL = "APEX_wr_vip_vipinsert"

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@acct_id", VipInfo.acct_id)
                .Parameters.AddWithValue("@sub_acct_id", "0000000000")
                .Parameters.AddWithValue("@company", VipInfo.Company)
                .Parameters.AddWithValue("@lname", VipInfo.lname)
                .Parameters.AddWithValue("@fname", VipInfo.fname)
                .Parameters.AddWithValue("@acct_name", VipInfo.acct_name)
                .Parameters.AddWithValue("@vip_flag", "P")
                .Parameters.AddWithValue("@level_id", "5")
                .Parameters.AddWithValue("@phone", VipInfo.office_phone)
                .Parameters.AddWithValue("@phone_ext", VipInfo.office_phone_ext)
                .Parameters.AddWithValue("@fax", VipInfo.fax)
                .Parameters.AddWithValue("@open_date", "")
                .Parameters.AddWithValue("@priority", "A")
                .Parameters.AddWithValue("@contact", VipInfo.contact)

                .Parameters.AddWithValue("@st_no", VipInfo.st_no)
                .Parameters.AddWithValue("@st_name", VipInfo.st_name)
                '.Parameters.AddWithValue("@aux_street_add", VipInfo.aux_street_add)
                .Parameters.AddWithValue("@city", VipInfo.city)
                .Parameters.AddWithValue("@state", VipInfo.state)
                .Parameters.AddWithValue("@zip_code", VipInfo.zip_code)
                .Parameters.AddWithValue("@sub_zip_code", VipInfo.sub_zip)
                '.Parameters.AddWithValue("@country", VipInfo.country)
                .Parameters.AddWithValue("@email_add", VipInfo.email)

                .Parameters.AddWithValue("@cc_no", VipInfo.CCNo)
                .Parameters.AddWithValue("@cc_exp", VipInfo.CCExp)
                .Parameters.AddWithValue("@cc_type", VipInfo.CCType)
                .Parameters.AddWithValue("@class_one_club", VipInfo.class_one_club)
                .Parameters.AddWithValue("@cell_phone", VipInfo.cell_phone)

                .Parameters.AddWithValue("@home_phone", VipInfo.home_phone)
                .Parameters.AddWithValue("@pager", VipInfo.pager_no)
                .Parameters.AddWithValue("@phone_2", VipInfo.office_phone_area)
                '===============================================================
                '===add by daniel 05/05/06
                .Parameters.AddWithValue("@user_name", VipInfo.username)
                .Parameters.AddWithValue("@pin_no", VipInfo.PinNo)
                '===============================================================

                .Parameters.Add(New SqlParameter("@Name_back", SqlDbType.VarChar, 50))
                .Parameters("@Name_back").Direction = ParameterDirection.Output

                .ExecuteNonQuery()

                Name = Convert.ToString(.Parameters("@Name_back").Value)

            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        If Name <> "Succeed" Then
            iResult = 4004
        Else
            iResult = 1
        End If

        Return iResult

    End Function
    '-----------------------------------------------------------------
    '--Function:VIPUserInsert
    '--Description:Update the VIP Info
    '--Input:Class UserData
    '--Output:1--success,0--failed
    '--11/17/04 - Created(eJay)
    '--11/18/04 - Updated new code (eJay)
    '-----------------------------------------------------------------
    Public Function CorporateVIPUserInsert(ByVal VipInfo As UserData, ByRef Name As String) As Int32

        Dim iResult As Int32
        Dim strSQL As String
        strSQL = "skylimo_wr_Corport_vipinsert"

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@user_name", VipInfo.user_id)
                .Parameters.AddWithValue("@pin_no", VipInfo.PinNo)

                .Parameters.AddWithValue("@lname", VipInfo.lname)
                .Parameters.AddWithValue("@fname", VipInfo.fname)
                .Parameters.AddWithValue("@st_no", VipInfo.st_no)
                .Parameters.AddWithValue("@st_name", VipInfo.st_name)
                .Parameters.AddWithValue("@city", VipInfo.city)
                .Parameters.AddWithValue("@state", VipInfo.state)
                .Parameters.AddWithValue("@zip_code", VipInfo.zip_code)
                .Parameters.AddWithValue("@email", VipInfo.email)
                .Parameters.AddWithValue("@phone", VipInfo.office_phone)
                .Parameters.AddWithValue("@phone_ext", VipInfo.office_phone_ext)
                .Parameters.AddWithValue("@cc_no", VipInfo.CCNo)
                .Parameters.AddWithValue("@cc_exp", VipInfo.CCExp)
                .Parameters.AddWithValue("@cc_type", VipInfo.CCType)
                .Parameters.AddWithValue("@cc_name", VipInfo.CCName)
                .Parameters.AddWithValue("@cell_phone", VipInfo.cell_phone)
                '--add by eJay 11/18/04
                .Parameters.AddWithValue("@fax", VipInfo.fax)
                .Parameters.AddWithValue("@contact", VipInfo.contact)
                .Parameters.AddWithValue("@country", VipInfo.country)
                .Parameters.AddWithValue("@class_one_club", VipInfo.class_one_club)
                .Parameters.AddWithValue("@aux_street_add", VipInfo.aux_street_add)
                .Parameters.Add(New SqlParameter("@Name_back", SqlDbType.VarChar, 50))
                .Parameters("@Name_back").Direction = ParameterDirection.Output

                .ExecuteNonQuery()

                Name = Convert.ToString(.Parameters("@Name_back").Value)

            End With

        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        If Name <> "Succeed" Then
            iResult = 4004
        Else
            iResult = 1
        End If

        'If iResult >= 1 Then
        '    iResult = 1
        'ElseIf iResult < 1 Then
        '    iResult = 4004
        'End If

        Return iResult
    End Function

    '-----------------------------------------------------------------
    '--Function:VIPUserUpdate
    '--Description:Update the VIP Info
    '--Input:Class UserData
    '--Output:1--success,0--failed
    '--10/28/04 - Created(eJay)
    '-----------------------------------------------------------------
    Public Function VIPUserUpdate(ByVal VipInfo As UserData) As Int32

        Dim iResult As Int32
        Dim strSQL As String
        strSQL = "APEX_wr_vip_updatevip"

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@user_id", sqlsafe(VipInfo.user_id))
                .Parameters.AddWithValue("@acct_id", sqlsafe(VipInfo.acct_id))
                .Parameters.AddWithValue("@sub_acct_id", sqlsafe(VipInfo.sub_acct_id))
                .Parameters.AddWithValue("@Company", sqlsafe(VipInfo.Company))

                .Parameters.AddWithValue("@oripwd", sqlsafe(VipInfo.OriPWD))
                .Parameters.AddWithValue("@pin_no", sqlsafe(VipInfo.PinNo))
                .Parameters.AddWithValue("@lname", sqlsafe(VipInfo.lname))
                .Parameters.AddWithValue("@fname", sqlsafe(VipInfo.fname))
                .Parameters.AddWithValue("@st_no", sqlsafe(VipInfo.st_no))
                .Parameters.AddWithValue("@st_name", sqlsafe(VipInfo.st_name))
                .Parameters.AddWithValue("@city", sqlsafe(VipInfo.city))
                .Parameters.AddWithValue("@state", sqlsafe(VipInfo.state))
                .Parameters.AddWithValue("@zip_code", sqlsafe(VipInfo.zip_code))
                .Parameters.AddWithValue("@email", sqlsafe(VipInfo.email))
                .Parameters.AddWithValue("@phone", sqlsafe(VipInfo.office_phone))
                .Parameters.AddWithValue("@phone_ext", sqlsafe(VipInfo.office_phone_ext))

                .Parameters.AddWithValue("@cc_no", sqlsafe(VipInfo.CCNo))
                .Parameters.AddWithValue("@cc_exp", sqlsafe(VipInfo.CCExp))
                .Parameters.AddWithValue("@cc_type", sqlsafe(VipInfo.CCType))
                '.Parameters.AddWithValue("@cc_name", sqlsafe(VipInfo.CCName))
                '--add by eJAY 11/17/04
                .Parameters.AddWithValue("@cell_phone", sqlsafe(VipInfo.cell_phone))
                .Parameters.AddWithValue("@fax", sqlsafe(VipInfo.fax))
                .Parameters.AddWithValue("@home_phone", sqlsafe(VipInfo.home_phone))
                .Parameters.AddWithValue("@pager_no", sqlsafe(VipInfo.pager_no))
                .Parameters.AddWithValue("@office_phone_area", sqlsafe(VipInfo.office_phone_area))
                .Parameters.AddWithValue("@office_phone_area_ext", sqlsafe(VipInfo.office_phone_area_ext)) '--add by daniel 29/11/06
                '--add by eJay 11/30/04
                '.Parameters.AddWithValue("@aux_street_add", VipInfo.aux_street_add)
                '--add by daniel 11/21/06
                '.Parameters.AddWithValue("@cc_no_2", sqlsafe(VipInfo.CCNo1))
                '.Parameters.AddWithValue("@cc_exp_2", sqlsafe(VipInfo.CCExp1))
                '.Parameters.AddWithValue("@cc_type_2", sqlsafe(VipInfo.CCType1))
                '.Parameters.AddWithValue("@cc_name_2", sqlsafe(VipInfo.CCName1))
                '.Parameters.AddWithValue("@cc_v_code", sqlsafe(VipInfo.CC_V_Code))
                '.Parameters.AddWithValue("@cc_v_code_2", sqlsafe(VipInfo.CC_V_Code2))
                '-------------------------------------------------------
                '.Parameters.AddWithValue("@class_one_club", sqlsafe(VipInfo.class_one_club))

                iResult = .ExecuteNonQuery

            End With
        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        If iResult >= 1 Then
            iResult = 1
        ElseIf iResult < 1 Then
            iResult = 4000
        End If

        Return iResult

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

    '-----------------------------------------------------------------
    '--Function:VIPUserUpdate
    '--Description:Update the VIP email
    '--Input:Class UserData
    '--Output:1--success,0--failed
    '--22/03/06 - Created(Daniel)
    '-----------------------------------------------------------------
    Public Function VIPEmailUpdate(ByVal struserid As String, _
                                    ByVal stracctid As String, _
                                     ByVal strsubacctid As String, _
                                      ByVal company As String, _
                                        ByVal email As String) As Int32

        Dim iResult As Int32
        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = "MTC_wr_vip_update_email"

                .Parameters.AddWithValue("@user_id", struserid)
                .Parameters.AddWithValue("@acct_id", stracctid)
                .Parameters.AddWithValue("@sub_acct_id", strsubacctid)
                .Parameters.AddWithValue("@Company", company)
                .Parameters.AddWithValue("@email", email)

                .Parameters.Add(New SqlParameter(("@intresult"), SqlDbType.Int))
                .Parameters("@intresult").Direction = ParameterDirection.Output

                .ExecuteNonQuery()

                iResult = Convert.ToInt32(.Parameters("@intresult").Value)


            End With
        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try


        Return iResult

    End Function

    Public Function GetEmailHtml(ByVal strVipno As String) As String
        Dim StrSql As String
        Dim dr As DataSet

        StrSql = "select email_text_format from vip where vip_no= '" & strVipno & "'"
        dr = Me.QueryData(StrSql, "vip")
        If dr.Tables(0).Rows.Count > 0 Then
            GetEmailHtml = dr.Tables(0).Rows(0).Item(0).ToString
        Else
            GetEmailHtml = ""
        End If

        dr.Dispose()
        dr = Nothing

    End Function

    Public Function GetUserInfo1(ByVal strfname As String, ByVal strlname As String, ByVal cc_no As String, ByVal email As String) As String
        Dim SQLStr As String
        Dim dr As DataSet

        SQLStr = "select user_name,email_add from vip(nolock) where fname = '" & strfname & "'"
        SQLStr = SQLStr & " and lname = '" & strlname & "' and cc_no = '" & cc_no & "'"
        If email <> "" Then
            SQLStr = SQLStr & " and email_add = '" & email & "'"
        End If
        dr = Me.QueryData(SQLStr, "vipnewuser")
        If dr.Tables(0).Rows.Count > 0 Then
            If dr.Tables(0).Rows(0).Item(0).ToString = "" Then
                GetUserInfo1 = dr.Tables(0).Rows(0).Item(1).ToString
            Else
                GetUserInfo1 = dr.Tables(0).Rows(0).Item(0).ToString
            End If
        Else
            GetUserInfo1 = ""
        End If

        dr.Dispose()
        dr = Nothing

    End Function

    Public Function NewVipUpdate(ByVal user_name As String, ByVal pin_no As String, _
                                ByVal fname As String, ByVal lname As String, ByVal cc_no As String, _
                                ByVal email_add As String) As String
        Dim iResult As String = "0"
        Dim strSQL As String
        strSQL = "MTC_wr_update_new_vip"

        Try

            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@user_name", user_name)
                .Parameters.AddWithValue("@pin_no", pin_no)
                .Parameters.AddWithValue("@fname", fname)
                .Parameters.AddWithValue("@lname", lname)

                .Parameters.AddWithValue("@cc_no", cc_no)
                .Parameters.AddWithValue("@email_add", email_add)

                .Parameters.Add(New SqlParameter(("@errmsg"), SqlDbType.Int))
                .Parameters("@errmsg").Direction = ParameterDirection.Output

                .ExecuteNonQuery()

                iResult = Convert.ToString(.Parameters("@errmsg").Value)

            End With
        Catch ex As Exception

            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        If iResult = "1" Then
            iResult = "1"
        ElseIf iResult = "0" Then
            iResult = "0"
        End If

        Return iResult

    End Function

    'Purpose   :To Get a New vip user info
    'Accept    :UserID,Password
    'Return    :UserData
    Public Function GetNewVipInfo(ByVal UserID As String, ByVal Password As String) As UserData


        Dim strSQL As String
        strSQL = "MTC_wr_vip_Newvipselect"

        Dim strFirst As String
        Dim objUserData As New UserData

        Try
            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@user_id", UserID)
                .Parameters.AddWithValue("@pin_no", Password)

                strFirst = Convert.ToString(.ExecuteScalar()).Trim

                '--add by eJay 2/1/05
                'If strFirst.CompareTo("No Time") = 0 Then
                '    objUserData.check_user = "No Time"
                'Else
                If strFirst.CompareTo("No User") = 0 Then

                    objUserData.check_user = "No User"

                ElseIf strFirst.CompareTo("Dup User") = 0 Then
                    objUserData.check_user = "Dup User"
                    'ElseIf strFirst.CompareTo("Password incorrect") = 0 Then
                    '    objUserData.check_user = "Password incorrect"
                Else
                    Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)
                    If Me.Reader.Read Then

                        With Me.Reader

                            'objUserData.Name = Me.Check_DBNULL(.Item("name"))
                            'If objUserData.Name Is Nothing Then

                            '    objUserData.checkAccount = "No Account"
                            'Else

                            '    objUserData.checkAccount = ""

                            'End If
                            objUserData.user_id = Convert.ToString(IIf(IsDBNull(.Item("vip_no")), "", .Item("vip_no"))).Trim()

                            objUserData.email_text_format = Convert.ToString(IIf(IsDBNull(.Item("email_text_format")), "", .Item("email_text_format"))).Trim()
                            objUserData.fname = Convert.ToString(IIf(IsDBNull(.Item("fname")), "", .Item("fname"))).Trim()
                            objUserData.lname = Convert.ToString(IIf(IsDBNull(.Item("lname")), "", .Item("lname"))).Trim()
                            objUserData.username = Convert.ToString(IIf(IsDBNull(.Item("user_name")), "", .Item("user_name"))).Trim()
                            objUserData.Company = Convert.ToString(IIf(IsDBNull(.Item("company")), "", .Item("company"))).Trim()
                            objUserData.contact = Convert.ToString(IIf(IsDBNull(.Item("contact")), "", .Item("contact"))).Trim()
                            objUserData.office_phone = Convert.ToString(IIf(IsDBNull(.Item("phone")), "", .Item("phone"))).Trim()
                            objUserData.office_phone_ext = Convert.ToString(IIf(IsDBNull(.Item("phone_ext")), "", .Item("phone_ext"))).Trim()
                            objUserData.cell_phone = Convert.ToString(IIf(IsDBNull(.Item("cell_phone")), "", .Item("cell_phone"))).Trim()
                            objUserData.fax = Convert.ToString(IIf(IsDBNull(.Item("fax")), "", .Item("fax"))).Trim()
                            objUserData.email = Convert.ToString(IIf(IsDBNull(.Item("email_add")), "", .Item("email_add"))).Trim()
                            objUserData.st_no = Convert.ToString(IIf(IsDBNull(.Item("st_no")), "", .Item("st_no"))).Trim()
                            objUserData.st_name = Convert.ToString(IIf(IsDBNull(.Item("st_name")), "", .Item("st_name"))).Trim()
                            objUserData.aux_street_add = Convert.ToString(IIf(IsDBNull(.Item("aux_street_add")), "", .Item("aux_street_add"))).Trim()
                            objUserData.city = Convert.ToString(IIf(IsDBNull(.Item("city")), "", .Item("city"))).Trim()
                            objUserData.state = Convert.ToString(IIf(IsDBNull(.Item("state")), "", .Item("state"))).Trim()
                            objUserData.zip_code = Convert.ToString(IIf(IsDBNull(.Item("zip_code")), "", .Item("zip_code"))).Trim()
                            objUserData.sub_zip = Convert.ToString(IIf(IsDBNull(.Item("sub_zip_code")), "", .Item("sub_zip_code"))).Trim()
                            objUserData.country = Convert.ToString(IIf(IsDBNull(.Item("country")), "", .Item("country"))).Trim()
                            objUserData.CCName = Convert.ToString(IIf(IsDBNull(.Item("cc_name")), "", .Item("cc_name"))).Trim()
                            objUserData.class_one_club = Convert.ToString(IIf(IsDBNull(.Item("class_one_club")), "", .Item("class_one_club"))).Trim()

                            'If Not IsDBNull(.Item("table_id")) Then
                            '    objUserData.table_id = Convert.ToInt32(.Item("table_id"))
                            'Else
                            '    objUserData.table_id = 0
                            'End If

                            'Dim objDate As Date
                            'objUserData.close_date = Me.Check_DBNULL(.Item("close_date"))
                            '--add by eJay 2/17/2006    --disabled by eJay 2/22/2006
                            'objUserData.admin_assistant_flag = Me.Check_DBNULL(.Item("admin_assistant_flag"))

                            'If Not IsDBNull(.Item("close_date")) Then
                            '    objUserData.close_date = Convert.ToString(.Item("close_date"))
                            'Else
                            '    objUserData.close_date = Nothing
                            'End If

                        End With

                    Else

                        objUserData.check_user = "No User"

                    End If

                End If

            End With

        Catch ex As Exception
            Me.ErrorMessage = ex.Message

        Finally

            Me.CloseConnection()

        End Try

        Return objUserData

    End Function

    Public Function GetUserName(ByVal strusername As String) As String
        Dim SQLStr As String
        Dim dr As DataSet

        SQLStr = "SELECT count(*) FROM vip(NOLOCK) WHERE [user_name]='" & sqlsafe(strusername) & "'"

        dr = Me.QueryData(SQLStr, "webride_cc_account")
        If Not dr Is Nothing Then
            If dr.Tables.Count > 0 Then
                If dr.Tables(0).Rows.Count > 0 Then
                    'do nothing
                    GetUserName = Convert.ToString(IIf(IsDBNull(dr.Tables(0).Rows(0).Item(0).ToString), "0", dr.Tables(0).Rows(0).Item(0).ToString))
                Else
                    GetUserName = "0"
                End If
            Else
                GetUserName = "0"
            End If
        Else
            GetUserName = "0"
        End If

        dr.Dispose()
        dr = Nothing

        Return GetUserName

    End Function

    Public Function Check_duplicates(ByVal strLname As String, ByVal strFname As String, ByVal strCC_no As String, ByVal strEmail_add As String) As Int16
        Dim SQLStr As String
        Dim dr As DataSet
        '-- check for duplicates --
        SQLStr = "select vip_no from vip(nolock) where lname = '" & sqlsafe(strLname) & "' and fname = '" & sqlsafe(strFname) & "'"
        SQLStr = SQLStr & " and cc_no = '" & sqlsafe(strCC_no) & "' and email_address = '" & sqlsafe(strEmail_add) & "'"

        dr = Me.QueryData(SQLStr, "vip")
        If Not dr Is Nothing Then
            If dr.Tables.Count > 0 Then
                If dr.Tables(0).Rows.Count > 0 Then
                    'do nothing
                    Check_duplicates = 1
                Else
                    Check_duplicates = 0
                End If
            Else
                Check_duplicates = 0
            End If
        Else
            Check_duplicates = 0
        End If

        dr.Dispose()
        dr = Nothing

        Return Check_duplicates

    End Function

    Public Function Check_duplicates_New(ByVal strLname As String, ByVal strFname As String, ByVal strEmail_add As String) As Int16
        Dim SQLStr As String
        Dim dr As DataSet
        '-- check for duplicates --
        SQLStr = "select vip_no from vip(nolock) where lname = '" & sqlsafe(strLname) & "' and fname = '" & sqlsafe(strFname) & "'"
        SQLStr = SQLStr & " and email_address = '" & sqlsafe(strEmail_add) & "'"

        dr = Me.QueryData(SQLStr, "vip")
        If dr.Tables(0).Rows.Count > 0 Then
            'do nothing
            Check_duplicates_New = 1
        Else
            Check_duplicates_New = 0
        End If

        dr.Dispose()
        dr = Nothing

        Return Check_duplicates_New

    End Function

    Public Function Check_duplicates_VIP(ByVal strEmail_add As String) As Int16
        Dim SQLStr As String
        Dim dr As DataSet
        '-- check for duplicates --
        SQLStr = "select vip_no from vip(nolock) where user_name = '" & sqlsafe(strEmail_add) & "'"

        dr = Me.QueryData(SQLStr, "Check_duplicates_VIP")
        If dr.Tables(0).Rows.Count > 0 Then
            'do nothing
            Check_duplicates_VIP = 1
        Else
            Check_duplicates_VIP = 0
        End If

        dr.Dispose()
        dr = Nothing

        Return Check_duplicates_VIP

    End Function
   
#End Region

#Region "Login_qickpassenger"

    '------------------------------------------------------------------------------
    '-- function login_qp_account(aid)
    '-- gets account id and checks if this is availiable to use quickpass module
    '-- 5/4/06 Created (Naoki)
    '------------------------------------------------------------------------------
    Public Function login_qp_account(ByVal aid As String) As String
        'Dim objConn, objRS, SQLStr
        'Dim bolFound As Boolean
        Dim SQLStr As String
        Dim dr As DataSet
        Dim strVipno As String
        'Dim objUserData As New UserData

        SQLStr = "select * from mtc_webride_quickpassenger_accts (nolock) where acct_id = '" & sqlsafe(aid) & "'"
        SQLStr = SQLStr & " and term_date > getdate() "

        dr = Me.QueryData(SQLStr, "mtc_webride_quickpassenger_accts")
        If dr.Tables(0).Rows.Count > 0 Then
            strVipno = Trim(dr.Tables(0).Rows(0).Item("vip_no").ToString)
            'objUserData.sub_acct_id = Trim(dr.Tables(0).Rows(0).Item("sub_acct_id").ToString)
            'bolFound = True
            'objRS.Close()
        Else
            strVipno = ""
        End If
        login_qp_account = strVipno

        dr.Dispose()
        dr = Nothing

        Return login_qp_account
    End Function

    Public Function gp_Getusername(ByVal aid As String) As UserData
        'Dim objConn, objRS, SQLStr
        'Dim bolFound As Boolean
        Dim SQLStr As String
        Dim dr As DataSet
        'Dim strVipno As String
        Dim objUserData As New UserData

        SQLStr = "select * from vip where vip_no= '" & sqlsafe(aid) & "'"
        'SQLStr = SQLStr & " and term_date > getdate() "

        dr = Me.QueryData(SQLStr, "vip")
        If dr.Tables(0).Rows.Count > 0 Then
            objUserData.username = Trim(dr.Tables(0).Rows(0).Item("user_name").ToString)
            objUserData.PinNo = Trim(dr.Tables(0).Rows(0).Item("pin_no").ToString)
            'bolFound = True
            'objRS.Close()
        Else
            objUserData.username = ""
            objUserData.PinNo = ""
        End If

        dr.Dispose()
        dr = Nothing

        Return objUserData
    End Function

#End Region

#Region "Corporate Users Parts"
    '----------------------------------------------------------------
    '--Function CorporateLogin
    '--Description:To find a special Corporate user
    '--Input:UserID,Password
    '--Output:UserData
    '--06/07/2006 - Created (nair)
    '----------------------------------------------------------------
    Public Function CorporateLogin(ByVal UserID As String, ByVal Password As String) As UserData
        Dim strSQL As String
        strSQL = "mtc_account_Corporateselect"

        Dim strFirst As String
        Dim objUserData As New UserData

        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@user_id", UserID)
                .Parameters.Add("@pin_no", Password)

                strFirst = .ExecuteScalar().ToString()

                If strFirst.CompareTo("No User") = 0 Then
                    objUserData.check_user = "No User"
                ElseIf strFirst.CompareTo("Dup User") = 0 Then
                    objUserData.check_user = "Dup User"
                ElseIf strFirst.CompareTo("Password incorrect") = 0 Then
                    objUserData.check_user = "Password incorrect"
                Else
                    Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)
                    If Me.Reader.Read Then
                        With Me.Reader
                            objUserData.Name = Me.Check_DBNULL(.Item("name"))
                            If objUserData.Name Is Nothing Then
                                objUserData.checkAccount = "No Account"
                            Else
                                objUserData.checkAccount = ""
                            End If

                            objUserData.priority = Me.Check_DBNULL(.Item("priority"))
                            objUserData.acct_name = Me.Check_DBNULL(.Item("name"))
                            objUserData.acct_id = Convert.ToString(.Item("acct_id")).Trim()
                            objUserData.user_id = ""
                            objUserData.sub_acct_id = Convert.ToString(.Item("sub_acct_id")).Trim()
                            objUserData.Company = Convert.ToString(.Item("company")).Trim()
                            objUserData.PinNo = Me.Check_DBNULL(.Item("password"))
                            objUserData.Internet = Me.Check_DBNULL(.Item("internet"))
                            If Not IsDBNull(.Item("table_id")) Then
                                objUserData.table_id = Convert.ToInt32(.Item("table_id"))
                            Else
                                objUserData.table_id = 0
                            End If
                            objUserData.close_date = Me.Check_DBNULL(.Item("close_date"))

                        End With
                    Else
                        objUserData.check_user = "No User"
                    End If
                End If
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try
        Return objUserData
    End Function
    '----------------------------------------------------------------
    '--Function GetOrderForUser
    '--Description:get all user about corporate
    '--Input:AcctID,SubAcctID,Company
    '--Output:UserData
    '--added by lily 12/04/2007
    '---------------------------------------------------------------
    Public Function GetOrderForUser(ByVal AcctID As String, ByVal SubAcctID As String, ByVal Company As String) As DataSet
        Dim sql As String = String.Format("EXEC APEX_wr_vip_getorderforuser '{0}','{1}','{2}'", AcctID, SubAcctID, Company)
        Return Me.QueryData(sql, "vip")
    End Function

#End Region

#Region " Group Users Parts"
    '----------------------------------------------------------------
    '--Function GroupUserLogin
    '--Description:To find a special group user
    '--Input:UserID,Password
    '--Output:UserData
    '--05/24/2006 - Created (nair)
    '----------------------------------------------------------------
    Public Function GroupUserLogin(ByVal UserID As String, ByVal Password As String) As UserData
        Dim strSQL As String
        strSQL = "mtc_account_groupselect"

        Dim strFirst As String
        Dim objUserData As New UserData

        Try
            Me.OpenConnection()
            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.Add("@user_id", UserID)
                .Parameters.Add("@pin_no", Password)

                strFirst = .ExecuteScalar().ToString()

                If strFirst.CompareTo("No User") = 0 Then
                    objUserData.check_user = "No User"
                ElseIf strFirst.CompareTo("Dup User") = 0 Then
                    objUserData.check_user = "Dup User"
                ElseIf strFirst.CompareTo("Password incorrect") = 0 Then
                    objUserData.check_user = "Password incorrect"
                ElseIf strFirst.CompareTo("nowebgroup") = 0 Then
                    objUserData.check_user = "nowebgroup"
                Else
                    Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)
                    If Me.Reader.Read Then
                        With Me.Reader
                            objUserData.Name = Me.Check_DBNULL(.Item("name"))
                            If objUserData.Name Is Nothing Then
                                objUserData.checkAccount = "No Account"
                            Else
                                objUserData.checkAccount = ""
                            End If

                            objUserData.priority = Me.Check_DBNULL(.Item("priority"))     '--add by daniel 
                            objUserData.acct_name = Me.Check_DBNULL(.Item("name"))
                            objUserData.acct_id = Convert.ToString(.Item("acct_id")).Trim()
                            objUserData.user_id = ""
                            objUserData.sub_acct_id = Convert.ToString(.Item("sub_acct_id")).Trim()
                            objUserData.Company = Convert.ToString(.Item("company")).Trim()
                            objUserData.fname = Me.Check_DBNULL(.Item("fname"))
                            objUserData.lname = Me.Check_DBNULL(.Item("lname"))
                            objUserData.PinNo = Me.Check_DBNULL(.Item("password"))
                            objUserData.Internet = Me.Check_DBNULL(.Item("internet"))
                            If Not IsDBNull(.Item("table_id")) Then
                                objUserData.table_id = Convert.ToInt32(.Item("table_id"))
                            Else
                                objUserData.table_id = 0
                            End If
                            objUserData.close_date = Me.Check_DBNULL(.Item("close_date"))
                            'objUserData.priority = "n"
                            'If Me.Check_DBNULL(.Item("active_flag")) Is Nothing Then
                            '    objUserData.active_flag = ""
                            'Else
                            '    objUserData.active_flag = Me.Check_DBNULL(.Item("active_flag"))
                            'End If
                        End With
                    Else
                        objUserData.check_user = "No User"
                    End If
                End If
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try
        Return objUserData
    End Function

#End Region

#Region "Function sqlsafe "

    Public Function sqlsafe(ByVal inputvalue As String) As String

        If inputvalue Is Nothing Then
            sqlsafe = ""
        Else
            sqlsafe = inputvalue.Replace("'", "")
            sqlsafe = sqlsafe.Replace(",", "")
        End If

        If sqlsafe Is Nothing Then
            sqlsafe = ""
        End If

    End Function

    Public Function Get_Close_date(ByVal stracctid As String, ByVal strsubacctid As String) As String
        Dim SQLStr As String
        Dim dr As DataSet
        '-- Get_Close_date --
        SQLStr = "select close_date from account(nolock) where"
        SQLStr = SQLStr & " acct_id = '" & sqlsafe(stracctid) & "' and sub_acct_id = '" & sqlsafe(strsubacctid) & "'"

        dr = Me.QueryData(SQLStr, "vip")
        If dr.Tables(0).Rows.Count > 0 Then
            'do nothing
            Get_Close_date = dr.Tables(0).Rows(0).Item("close_date").ToString
        Else
            Get_Close_date = ""
        End If

        dr.Dispose()
        dr = Nothing


        Return Get_Close_date

    End Function

#End Region

#Region "Sub SendEmail"

    Public Sub sendemail(ByVal email As String, ByVal pw As String, ByVal userid As String)
        Dim strBody As String
        Dim strTitle As String = "Password Help"

        strBody = "This email is from " & System.Configuration.ConfigurationSettings.AppSettings("company_name") & " : Password Help." & vbCr & "<br>"
        strBody = strBody & "USER ID : " & userid & "<br>"
        strBody = strBody & "PASSWORD: " & pw & "<br>"

        Dim mto(1, 1) As String
        mto(0, 0) = email
        'mto(0, 0) = "daniel_c_tao@hotmail.com"
        mto(0, 1) = ""
        Dim mcc(,) As String
        Dim mbcc(1, 1) As String
        'mbcc(0, 0) = "web_dev_team@alephcomputer.com"
        mbcc(0, 0) = "daniel.chen@surreytechnology.com"
        mbcc(0, 1) = ""
        Dim matt() As String
        Dim blnResult As String

        'Try
        blnResult = Business.Mail.SendEmail("", email, strTitle, strBody, True)
        'Catch ex As Exception

        'End Try

    End Sub

#End Region

#Region "CheckGroup"

    Public Function GetVipNo(ByVal strAcct As String, ByVal strSubAcct As String, ByVal strSelAcct As String, ByVal strVipNo As String, ByVal strGroupflag As String, ByVal strLevel As String) As DataSet
        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_VipReq"

        Try
            Me.SelectCommand = New SqlCommand
            With Me.SelectCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
                .Parameters.Add("@acct_id", strAcct)
                .Parameters.Add("@sub_acct_id", strSubAcct)
                .Parameters.Add("@seleacct_id", strSelAcct)
                .Parameters.Add("@vip_no", strVipNo)
                .Parameters.Add("@group_flag", strGroupflag)
                .Parameters.Add("@level_id", strLevel)

            End With

            strDS = Me.QueryData("selectVipNo")
        Catch ex As Exception
            Dim strmessage As String
            strmessage = ex.Message.ToString
        End Try

        Return strDS
    End Function

    Public Function CheckGroupLogin(ByVal strAcct_ID As String, ByVal strPassword As String) As DataSet
        Dim strSQL As String
        Dim objuser As New Business.UserData
        Dim strDS As DataSet

        strSQL = "APEX_wc_CheckGroupLogin"

        Try
            Me.SelectCommand = New SqlCommand
            With Me.SelectCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
                .Parameters.Add("@acct_id", strAcct_ID)
                .Parameters.Add("@password", strPassword)

            End With


            'Me.Reader = Me.Command.ExecuteReader(CommandBehavior.SingleRow)
            'If Me.Reader.Read() Then
            '    While Me.Reader.Read()
            '        objuser.strGroupId = Me.Reader.Item("group_id").ToString.Trim()
            '        objuser.strAcctList = objuser.strAcctList & Me.Reader.Item("acct_id").ToString.Trim() & ","
            '    End While
            'End If
            'Me.Reader.Close()
            strDS = Me.QueryData("group")
        Catch ex As Exception
            Dim strmessage As String
            strmessage = ex.Message.ToString
        End Try

        Return strDS
    End Function
    Public Function CheckVipLogin(ByVal strAcct_ID As String, ByVal strPassword As String) As DataSet
        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_CheckVipLogin"

        Try
            Me.SelectCommand = New SqlCommand
            With Me.SelectCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
                .Parameters.AddWithValue("@user_name", strAcct_ID)
                .Parameters.AddWithValue("@password", strPassword)

            End With

            strDS = Me.QueryData("APEX_wc_CheckVipLogin")
        Catch ex As Exception
            Dim strmessage As String
            strmessage = ex.Message.ToString
        End Try

        Return strDS
    End Function
    Public Function GetSelectAcct(ByVal strGroupId As Int32) As DataSet
        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_getSelectAcct"

        Try
            Me.SelectCommand = New SqlCommand
            With Me.SelectCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
                .Parameters.Add("@group_id", strGroupId)

            End With

            strDS = Me.QueryData("selectAcct")
        Catch ex As Exception
            Dim strmessage As String
            strmessage = ex.Message.ToString
        End Try

        Return strDS
    End Function

    Public Function GetCusRef(ByVal strAcct As String, ByVal strSubAcct As String, ByVal strSelAcct As String, ByVal strGroupflag As String) As DataSet
        Dim strSQL As String
        Dim strDS As DataSet

        strSQL = "APEX_wc_getCusReq"

        Try
            Me.SelectCommand = New SqlCommand
            With Me.SelectCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
                .Parameters.Add("@acct_id", strAcct)
                .Parameters.Add("@sub_acct_id", strSubAcct)
                .Parameters.Add("@seleacct_id", strSelAcct)
                .Parameters.Add("@group_flag", strGroupflag)

            End With

            strDS = Me.QueryData("selectCusRef")
        Catch ex As Exception
            Dim strmessage As String
            strmessage = ex.Message.ToString
        End Try

        Return strDS
    End Function

#End Region

#Region "WebCharge Admin Users Parts"

    Public Function Check_webcharge_admin(ByVal strUser As String, ByVal strPwd As String) As String
        Dim SQLStr As String
        Dim dr As DataSet

        SQLStr = "select * from admin_billing_password(nolock)"
        SQLStr = SQLStr & " where user_login = '" & strUser & "'"
        SQLStr = SQLStr & " and	password = '" & strPwd & "'"

        dr = Me.QueryData(SQLStr, "admin_billing_password")
        If dr.Tables(0).Rows.Count > 0 Then
            'do nothing
            Check_webcharge_admin = strUser
        Else
            Check_webcharge_admin = ""
        End If

        dr.Dispose()
        dr = Nothing

        Return Check_webcharge_admin

    End Function

#End Region

#Region "Admin_Install_rate_modules Users Parts"

    Public Function mtc_web_price_quote_verbage_default_get() As String
        Dim SQLStr As String
        Dim dr As DataSet
        '-- check for duplicates --
        SQLStr = "select * from mtc_web_price_quote_verbage_default(nolock)"
        Try
            dr = Me.QueryData(SQLStr, "mtc_web_price_quote_verbage_default")
        Catch ex As Exception
            dr = Nothing
        End Try

        If Not dr Is Nothing Then
            If dr.Tables.Count > 0 Then
                If dr.Tables(0).Rows.Count > 0 Then
                    mtc_web_price_quote_verbage_default_get = Me.Check_DBNULL(dr.Tables(0).Rows(0).Item(0))
                Else
                    mtc_web_price_quote_verbage_default_get = ""
                End If
            Else
                mtc_web_price_quote_verbage_default_get = ""
            End If
        Else
            mtc_web_price_quote_verbage_default_get = ""
        End If

        Return mtc_web_price_quote_verbage_default_get

    End Function

    Public Function mtc_web_price_quote_verbage_default_update(ByVal strtext As String) As Int16
        Dim SQLStr As String
        Dim dr As DataSet
        '-- check for duplicates --
        SQLStr = "update mtc_web_price_quote_verbage_default set Default_quote_verbage='" & sqlsafe(strtext) & "'"
        Try
            dr = Me.QueryData(SQLStr, "mtc_web_price_quote_verbage_default")
            mtc_web_price_quote_verbage_default_update = 1
        Catch ex As Exception
            dr = Nothing
            mtc_web_price_quote_verbage_default_update = 0
        End Try

        Return mtc_web_price_quote_verbage_default_update

    End Function

    Public Function mtc_web_price_quote_verbage_custom_getall() As DataSet
        Dim SQLStr As String
        Dim dr As DataSet
        '-- check for duplicates -- 
        SQLStr = "select * from mtc_web_price_quote_verbage_custom(nolock) order by term_date desc"

        Try
            dr = Me.QueryData(SQLStr, "mtc_web_price_quote_verbage_custom_getall")
        Catch ex As Exception
            dr = Nothing
        End Try

        Return dr

    End Function

    Public Function mtc_web_price_quote_verbage_custom_get_bytermdate(ByVal acct_id As String, ByVal sub_acct_id As String) As DataSet
        Dim SQLStr As String
        Dim dr As DataSet
        '-- check for duplicates --
        SQLStr = "select acct_id,sub_acct_id,price_quote_verbage from mtc_web_price_quote_verbage_custom(nolock) "
        SQLStr = SQLStr & "where acct_id='" & sqlsafe(acct_id) & "' and sub_acct_id='" & sqlsafe(sub_acct_id) & "'"      ' --and term_date='10/30/2006 04:23:39' 
        SQLStr = SQLStr & "order by term_date desc"

        Try
            dr = Me.QueryData(SQLStr, "mtc_web_price_quote_verbage_custom_get_bytermdate")
        Catch ex As Exception
            dr = Nothing
        End Try

        Return dr

    End Function

    Public Function mtc_web_price_quote_verbage_custom_get(ByVal acct_id As String, ByVal sub_acct_id As String) As String
        Dim SQLStr As String
        Dim dr As DataSet
        '-- check for duplicates --
        SQLStr = "select top 1 price_quote_verbage from mtc_web_price_quote_verbage_custom(nolock)"
        SQLStr = SQLStr & " where acct_id='" & sqlsafe(acct_id) & "' and sub_acct_id='" & sqlsafe(sub_acct_id) & "'"
        SQLStr = SQLStr & " order by term_date desc"

        Try
            dr = Me.QueryData(SQLStr, "mtc_web_price_quote_verbage_custom_get")
        Catch ex As Exception
            dr = Nothing
        End Try

        If Not dr Is Nothing Then
            If dr.Tables.Count > 0 Then
                If dr.Tables(0).Rows.Count > 0 Then
                    mtc_web_price_quote_verbage_custom_get = Me.Check_DBNULL(dr.Tables(0).Rows(0).Item(0))
                Else
                    mtc_web_price_quote_verbage_custom_get = ""
                End If
            Else
                mtc_web_price_quote_verbage_custom_get = ""
            End If
        Else
            mtc_web_price_quote_verbage_custom_get = ""
        End If

        Return mtc_web_price_quote_verbage_custom_get

    End Function
    '--function mtc_web_price_quote_verbage_custom_check
    '--Input:acct_id,sub_acct_id
    '--Output:True/False if true then not exist else exist
    '--Cretor:Daniel
    Public Function mtc_web_price_quote_verbage_custom_check(ByVal acct_id As String, ByVal sub_acct_id As String) As Boolean
        Dim SQLStr As String
        Dim dr As DataSet
        '-- check for duplicates --
        SQLStr = "select count(*) from mtc_web_price_quote_verbage_custom"
        SQLStr = SQLStr & " where acct_id='" & sqlsafe(acct_id) & "' and sub_acct_id='" & sqlsafe(sub_acct_id) & "'"

        Try
            dr = Me.QueryData(SQLStr, "mtc_web_price_quote_verbage_custom_check")
        Catch ex As Exception
            dr = Nothing
        End Try

        If Not dr Is Nothing Then
            If dr.Tables.Count > 0 Then
                If dr.Tables(0).Rows.Count > 0 Then
                    If CInt(Me.Check_DBNULL(dr.Tables(0).Rows(0).Item(0))) > 0 Then
                        mtc_web_price_quote_verbage_custom_check = False
                    Else
                        mtc_web_price_quote_verbage_custom_check = True
                    End If
                Else
                    mtc_web_price_quote_verbage_custom_check = True
                End If
            Else
                mtc_web_price_quote_verbage_custom_check = True
            End If
        Else
            mtc_web_price_quote_verbage_custom_check = True
        End If

        Return mtc_web_price_quote_verbage_custom_check

    End Function

    Public Function mtc_web_price_quote_verbage_custom_update(ByVal id As String, ByVal acct_id As String, ByVal sub_acct_id As String, ByVal strtext As String) As Int16
        Dim SQLStr As String
        Dim dr As DataSet
        '-- check for duplicates --
        'SQLStr = "update mtc_web_price_quote_verbage_custom"
        'SQLStr = SQLStr & " set acct_id='" & sqlsafe(acct_id) & "',sub_acct_id='" & sqlsafe(sub_acct_id) & "',price_quote_verbage='" & sqlsafe(strtext) & "',term_date=getdate()"
        'SQLStr = SQLStr & " where id='" & sqlsafe(id) & "'"
        SQLStr = "EXEC MTC_wr_price_quote_verbage_custom_update '" & sqlsafe(acct_id) & "','" & sqlsafe(sub_acct_id) & "','" & sqlsafe(strtext) & "'"

        Try
            dr = Me.QueryData(SQLStr, "mtc_web_price_quote_verbage_custom_update")
        Catch ex As Exception
            dr = Nothing
        End Try

        If Not dr Is Nothing Then
            mtc_web_price_quote_verbage_custom_update = 1
        Else
            mtc_web_price_quote_verbage_custom_update = 0
        End If

        Return mtc_web_price_quote_verbage_custom_update

    End Function

    Public Function mtc_web_price_quote_verbage_custom_insert(ByVal acct_id As String, ByVal sub_acct_id As String, ByVal strtext As String) As Int16
        Dim SQLStr As String
        Dim dr As DataSet
        '-- check for duplicates --
        SQLStr = "insert into mtc_web_price_quote_verbage_custom"
        SQLStr = SQLStr & " values('" & sqlsafe(acct_id) & "','" & sqlsafe(sub_acct_id) & "','" & sqlsafe(strtext) & "',getdate())"

        Try
            dr = Me.QueryData(SQLStr, "mtc_web_price_quote_verbage_custom_insert")
        Catch ex As Exception
            dr = Nothing
        End Try

        If Not dr Is Nothing Then
            mtc_web_price_quote_verbage_custom_insert = 1
        Else
            mtc_web_price_quote_verbage_custom_insert = 0
        End If

        Return mtc_web_price_quote_verbage_custom_insert

    End Function

    Public Function mtc_web_price_quote_verbage_custom_delete(ByVal stracctid As String, ByVal strsubacctid As String) As Int16
        Dim SQLStr As String
        Dim dr As DataSet
        '-- check for duplicates --
        SQLStr = "delete mtc_web_price_quote_verbage_custom where acct_id='" & sqlsafe(stracctid) & "' and sub_acct_id='" & sqlsafe(strsubacctid) & "'"

        Try
            dr = Me.QueryData(SQLStr, "mtc_web_price_quote_verbage_custom_delete")
        Catch ex As Exception
            dr = Nothing
        End Try

        If Not dr Is Nothing Then
            mtc_web_price_quote_verbage_custom_delete = 1
        Else
            mtc_web_price_quote_verbage_custom_delete = 0
        End If

        Return mtc_web_price_quote_verbage_custom_delete

    End Function

#End Region

#Region "VIP_Users_Recepit_By_Conf"

    '--Region VIP_Users_Recepit_By_Conf creter by daniel for recepit2.aspx 16/11/06
    Public Function Recepit_By_Conf_Print(ByVal strconf As String) As DataSet
        Dim tmpDS As New DataSet
        Dim strSQL As String
        strSQL = "MTC_wr_operator_recepit_print"

        Try

            With Me.SelectCommand

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@conf", strconf)

                tmpDS = Me.QueryData("Recepit_By_Conf_Print")

            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
            tmpDS = Nothing
        Finally

            Me.SelectCommand.Dispose()
            Me.SelectCommand = Nothing

        End Try

        Return tmpDS

    End Function

    '------------------------------------------------------------------------------
    Public Function get_payment_type(ByVal payment_id As String) As String
        Dim SQLStr As String
        Dim objDataSet As DataSet
        Dim strTemp As String
        SQLStr = "select payment_type_desc from payment_type(nolock) where payment_type ='" & sqlsafe(payment_id) & "'"

        Try
            objDataSet = Me.QueryData(SQLStr, "get_payment_type")
        Catch ex As Exception
            objDataSet = Nothing
        End Try

        If Not objDataSet Is Nothing Then
            If objDataSet.Tables.Count > 0 Then
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strTemp = Me.Check_DBNULL(objDataSet.Tables(0).Rows(0).Item(0))
                Else
                    strTemp = ""
                End If
            Else
                strTemp = ""
            End If
        Else
            strTemp = ""
        End If
        objDataSet.Dispose() : objDataSet = Nothing
        get_payment_type = strTemp

    End Function
    '------------------------------------------------------------------------------
    Public Function get_driver_name(ByVal driver_id As String) As String
        Dim SQLStr As String
        Dim objDataSet As DataSet
        Dim strTemp As String
        SQLStr = "select lname,fname from driver(nolock) where dr_id ='" & sqlsafe(driver_id) & "'"
        Try
            objDataSet = Me.QueryData(SQLStr, "get_driver_name")
        Catch ex As Exception
            objDataSet = Nothing
        End Try

        If Not objDataSet Is Nothing Then
            If objDataSet.Tables.Count > 0 Then
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strTemp = Me.Check_DBNULL(objDataSet.Tables(0).Rows(0).Item(0))
                Else
                    strTemp = ""
                End If
            Else
                strTemp = ""
            End If
        Else
            strTemp = ""
        End If
        objDataSet.Dispose() : objDataSet = Nothing
        get_driver_name = strTemp

    End Function
    '------------------------------------------------------------------------------
    Public Function get_company_name(ByVal company_id As String) As String
        Dim SQLStr As String
        Dim objDataSet As DataSet
        Dim strTemp As String
        SQLStr = "select company_name from system_parameter(nolock) where company ='" & sqlsafe(company_id) & "'"
        Try
            objDataSet = Me.QueryData(SQLStr, "get_company_name")
        Catch ex As Exception
            objDataSet = Nothing
        End Try

        If Not objDataSet Is Nothing Then
            If objDataSet.Tables.Count > 0 Then
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strTemp = Me.Check_DBNULL(objDataSet.Tables(0).Rows(0).Item(0))
                Else
                    strTemp = ""
                End If
            Else
                strTemp = ""
            End If
        Else
            strTemp = ""
        End If
        objDataSet.Dispose() : objDataSet = Nothing
        get_company_name = strTemp

    End Function
    '------------------------------------------------------------------------------
    Public Function get_car_type_name(ByVal car_type_id As String) As String
        Dim SQLStr As String
        Dim objDataSet As DataSet
        Dim strTemp As String
        SQLStr = "select car_type_desc from car_type(nolock) where car_type_id ='" & sqlsafe(car_type_id) & "'"
        Try
            objDataSet = Me.QueryData(SQLStr, "get_car_type_name")
        Catch ex As Exception
            objDataSet = Nothing
        End Try

        If Not objDataSet Is Nothing Then
            If objDataSet.Tables.Count > 0 Then
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strTemp = Me.Check_DBNULL(objDataSet.Tables(0).Rows(0).Item(0))
                Else
                    strTemp = ""
                End If
            Else
                strTemp = ""
            End If
        Else
            strTemp = ""
        End If
        objDataSet.Dispose() : objDataSet = Nothing
        get_car_type_name = strTemp

    End Function
    '------------------------------------------------------------------------------
    'Public Function get_card_type_name(ByVal car_type_id As String) As String
    '    Dim SQLStr As String
    '    Dim objDataSet As DataSet
    '    Dim strTemp As String
    '    SQLStr = "select description from credit_card_type where code ='" & sqlsafe(car_type_id) & "'"
    '    Try
    '        objDataSet = Me.QueryData(SQLStr, "get_card_type_name")
    '    Catch ex As Exception
    '        objDataSet = Nothing
    '    End Try

    '    If Not objDataSet Is Nothing Then
    '        If objDataSet.Tables.Count > 0 Then
    '            If objDataSet.Tables(0).Rows.Count > 0 Then
    '                strTemp = Me.Check_DBNULL(objDataSet.Tables(0).Rows(0).Item(0))
    '            Else
    '                strTemp = ""
    '            End If
    '        Else
    '            strTemp = ""
    '        End If
    '    Else
    '        strTemp = ""
    '    End If
    '    objDataSet.Dispose() : objDataSet = Nothing
    '    get_card_type_name = strTemp

    'End Function
    '------------------------------------------------------------------------------
    Public Function get_account_name(ByVal account_id As String) As String
        Dim SQLStr As String
        Dim objDataSet As DataSet
        Dim strTemp As String
        SQLStr = "select name from account(nolock) where acct_id =  '" & sqlsafe(account_id) & "'"
        Try
            objDataSet = Me.QueryData(SQLStr, "get_account_name")
        Catch ex As Exception
            objDataSet = Nothing
        End Try

        If Not objDataSet Is Nothing Then
            If objDataSet.Tables.Count > 0 Then
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strTemp = Me.Check_DBNULL(objDataSet.Tables(0).Rows(0).Item(0))
                Else
                    strTemp = ""
                End If
            Else
                strTemp = ""
            End If
        Else
            strTemp = ""
        End If
        objDataSet.Dispose() : objDataSet = Nothing
        get_account_name = strTemp

    End Function
    '------------------------------------------------------------------------------
    Public Function get_card_type_name(ByVal card_type_id As String) As String
        Dim SQLStr As String
        Dim objDataSet As DataSet
        Dim strTemp As String
        SQLStr = "select description from credit_card_type(nolock) where code ='" & sqlsafe(card_type_id) & "'"
        Try
            objDataSet = Me.QueryData(SQLStr, "get_card_type_name")
        Catch ex As Exception
            objDataSet = Nothing
        End Try

        If Not objDataSet Is Nothing Then
            If objDataSet.Tables.Count > 0 Then
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strTemp = Me.Check_DBNULL(objDataSet.Tables(0).Rows(0).Item(0))
                Else
                    strTemp = ""
                End If
            Else
                strTemp = ""
            End If
        Else
            strTemp = ""
        End If
        objDataSet.Dispose() : objDataSet = Nothing
        get_card_type_name = strTemp

    End Function
    '------------------------------------------------------------------------------
    '------------------------------------------------------------------------------
    Public Function Get_CC_from_operator_passengers_archive(ByVal strconf As String) As DataSet
        Dim SQLStr As String
        Dim objDataSet As DataSet
        SQLStr = "select cc_no,cc_exp,approval_code from operator_passengers_archive(nolock) where confirmation_no = '" & sqlsafe(strconf) & "'"
        Try
            objDataSet = Me.QueryData(SQLStr, "Get_CC_from_operator_passengers_archive")
        Catch ex As Exception
            objDataSet = Nothing
        End Try

        Return objDataSet

    End Function
    '------------------------------------------------------------------------------

#End Region

#Region "Install_Price_Set"

    '-------------------------------------------------------
    'Function: SearchUsersForUserAssignUser
    'Description: 
    'Modification: 2004/10/19 wan
    'Table:             user_profile
    'Input:             user_id
    'OutPut:            DataSet of UserInfo
    '-------------------------------------------------------
    Public Function SearchAirport_ByName(ByVal strname As String) As DataSet
        
        Return Me.QueryData("exec mtc_wr_query_airport_by_aleph '" & sqlsafe(strname) & "'", "SearchAirport_ByName")

    End Function

    '-------------------------------------------------------
    'Function: SearchUsersForUserAssignUser
    'Description: 
    'Modification: 2004/10/19 wan
    'Table:             user_profile
    'Input:             user_id
    'OutPut:            DataSet of UserInfo
    '-------------------------------------------------------
    Public Function SearchInstall_city_state(ByVal strname As String) As DataSet

        Return Me.QueryData("exec mtc_wr_query_airport_by_aleph '" & sqlsafe(strname) & "'", "SearchAirport_ByName")

    End Function

    '-------------------------------------------------------
    'Function: SearchUsersForUserAssignUser
    'Description: 
    'Modification: 2004/10/19 wan
    'Table:             user_profile
    'Input:             user_id
    'OutPut:            DataSet of UserInfo
    '-------------------------------------------------------
    Public Function SearchInstall_Bycity(ByVal strname As String, ByVal strprice As Integer) As DataSet

        Return Me.QueryData("exec mtc_wr_query_city_name_bystate '" & sqlsafe(strname) & "'," & strprice & "", "SearchAirport_ByName")

    End Function

#End Region

    Public Function is_voucher(ByVal confirm_no As String) As Boolean
        Dim SQLStr As String
        Dim ds As DataSet

        SQLStr = "select invoice_no,net from voucher_archive(nolock) where ltrim(rtrim(confirmation_no)) = '" & sqlsafe(Trim(confirm_no)) & "'"
        SQLStr = SQLStr & " and (invoice_no is not null or export_cc_date_time is not null)"

        Try
            ds = Me.QueryData(SQLStr, "is_voucher")
        Catch ex As Exception
            ds = Nothing
        End Try

        If Not ds Is Nothing Then
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    is_voucher = True
                Else
                    is_voucher = False
                End If
            Else
                is_voucher = False
            End If
        Else
            is_voucher = False
        End If

        Return is_voucher

    End Function

#Region "Sub SetPassword Users"

    Public Function UpdatePassword(ByVal pw As String, ByVal user_id As String, ByVal acct_id As String, ByVal sub_acct_id As String, ByVal company As String) As Boolean
        Dim UpdateSuccessful As Boolean
        Dim SQLStr As String
        Dim ds As DataSet

        SQLStr = "update vip set pin_no = '" & sqlsafe(pw) & "' where "
        SQLStr = SQLStr & " vip_no = '" & sqlsafe(user_id) & "' and acct_id = '" & sqlsafe(acct_id) & "'"
        SQLStr = SQLStr & " and sub_acct_id = '" & sqlsafe(Trim(sub_acct_id)) & "'"
        SQLStr = SQLStr & " and company = '" & sqlsafe(company) & "' " '-- 9/13/04 added for user w/ duplicate vip_no

        Try
            ds = Me.QueryData(SQLStr, "UpdatePassword")
        Catch ex As Exception
            ds = Nothing
        End Try

        If Not ds Is Nothing Then
            UpdateSuccessful = True
        Else
            UpdateSuccessful = False
        End If

        Return UpdateSuccessful

    End Function

    Public Function QueryCompany(ByVal strCompany As String) As String
        Dim StrQuery As String
        Dim SQLStr As String
        Dim ds As DataSet

        SQLStr = "select * from system_parameter(nolock)"
        SQLStr = SQLStr & " where company_name='" & sqlsafe(strCompany) & "'"
        'SQLStr = SQLStr & " where company='" & sqlsafe(strCompany) & "'"

        Try
            ds = Me.QueryData(SQLStr, "QueryCompany")
        Catch ex As Exception
            ds = Nothing
        End Try

        If Not ds Is Nothing Then
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    StrQuery = Convert.ToString(ds.Tables(0).Rows(0).Item("company"))
                Else
                    StrQuery = ""
                End If
            Else
                StrQuery = ""
            End If
        Else
            StrQuery = ""
        End If

        Return StrQuery

    End Function
    '## added by joey   12/06/2007
    Public Function AddNewAddewss(ByVal vip_no As String, ByVal ord As OperatorData) As Integer
        Dim out As Integer

        Me.OpenConnection()
        With Me.Command
            Try
                .CommandType = CommandType.StoredProcedure
                .CommandText = "apex_wr_vip_addnewaddress"
                .Parameters.AddWithValue("@vip_no", vip_no)
                .Parameters.AddWithValue("@state", ord.pu_county)
                .Parameters.AddWithValue("@city", ord.pu_city)
                .Parameters.AddWithValue("@st_name", ord.pu_st_name)
                .Parameters.AddWithValue("@st_no", ord.pu_st_no)
                .Parameters.AddWithValue("@zip", ord.pu_zip)

                out = .ExecuteNonQuery

            Catch ex As Exception
                out = -1
            End Try
        End With
        Me.CloseConnection()

        Return out
    End Function

    Public Function GetAddressByVip() As DataSet
        Return Me.QueryData("exec apex_wr_getaddressbyvipno " & MySession.UserID, "Address")
    End Function

#End Region

#Region " Write Session for accessing Webride to Webcharge "

    Public Function AccessWriteSession() As String
        Dim out As String = ""

        Try
            Me.OpenConnection()

            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "apex_vip_access"

                .Parameters.AddWithValue("@vip_no", MySession.UserID)
                .Parameters.AddWithValue("@acct_id", MySession.AcctID)
                .Parameters.AddWithValue("@sub_acct_id", MySession.SubAcctID)
                .Parameters.AddWithValue("@guid", "")

                out = Convert.ToString(.ExecuteScalar).Trim
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try

        Return out
    End Function

    Public Function AccessReadSession(ByVal guid As String) As UserData

        Dim strFirst As String = ""
        Dim strSQL As String = "apex_vip_access"
        Dim objUserData As New UserData

        Try
            Me.OpenConnection()

            With Me.Command

                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL

                .Parameters.AddWithValue("@vip_no", "")
                .Parameters.AddWithValue("@acct_id", "")
                .Parameters.AddWithValue("@sub_acct_id", "")
                .Parameters.AddWithValue("@guid", guid)

                'strFirst = Convert.ToString(.ExecuteScalar()).Trim

                'If strFirst.CompareTo("No Time") = 0 Then
                '    objUserData.check_user = "No Time"
                'ElseIf strFirst.CompareTo("No User") = 0 Then
                '    objUserData.check_user = "No User"
                'ElseIf strFirst.CompareTo("Dup User") = 0 Then
                '    objUserData.check_user = "Dup User"
                'ElseIf strFirst.CompareTo("Password incorrect") = 0 Then
                '    objUserData.check_user = "Password incorrect"
                'Else
                Me.Reader = .ExecuteReader(CommandBehavior.SingleRow)

                If Me.Reader.Read Then

                    With Me.Reader
                        If Me.Reader.FieldCount = 1 Then
                            strFirst = Convert.ToString(Me.Reader.Item(0)).Trim
                        ElseIf Me.Reader.FieldCount > 10 Then
                            objUserData.Name = Me.Check_DBNULL(.Item("name"))
                            If objUserData.Name Is Nothing Then
                                objUserData.checkAccount = "No Account"
                            Else
                                objUserData.checkAccount = ""
                            End If

                            objUserData.level1_id = Convert.ToString(.Item("level_id")).Trim()
                            objUserData.user_id = Convert.ToString(.Item("vip_no")).Trim()
                            objUserData.acct_id = Convert.ToString(.Item("acct_id")).Trim()
                            objUserData.sub_acct_id = Convert.ToString(.Item("sub_acct_id")).Trim()

                            objUserData.fname = Me.Check_DBNULL(.Item("fname"))
                            objUserData.lname = Me.Check_DBNULL(.Item("lname"))
                            objUserData.PinNo = Me.Check_DBNULL(.Item("pin_no"))
                            objUserData.check_user = ""

                            objUserData.Internet = Me.Check_DBNULL(.Item("internet"))
                            objUserData.accountcompany = Convert.ToString(.Item("acompany"))

                            If Not IsDBNull(.Item("table_id")) Then
                                objUserData.table_id = Convert.ToInt32(.Item("table_id"))
                            Else
                                objUserData.table_id = 0
                            End If

                            objUserData.close_date = Me.Check_DBNULL(.Item("close_date"))
                            objUserData.username = Me.Check_DBNULL(.Item("user_name"))
                        End If
                    End With
                Else
                    objUserData.check_user = "No User"
                End If
                'End If
            End With
        Catch ex As Exception
            Me.ErrorMessage = ex.Message
        Finally
            Me.CloseConnection()
        End Try

        Return objUserData
    End Function

#End Region

#Region " Frequent User Profile "


    '------------------------------------------------------------------------------
    '-- Function: getFavoriteUser
    '-- Description:  Get top 10 frequent User , 
    '-- Input: strUserId,strAcctId,strSubAcctId,strCompany
    '-- Output: DataSet
    '-- Table: vip_freq_profile
    '-- Stored Procedure: MTC_wr_VipDispAdd_getFrequent
    '-- 1/30/2008 - Created (joey)
    '------------------------------------------------------------------------------
    Public Function GetFrequentProfile(ByVal strUserId As String, ByVal strAcctId As String, ByVal strSubAcctId As String, ByVal strCompany As String) As DataSet
        Dim tmpDS As DataSet

        With SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = "apex_wr_vipfreq_getFrequentProfile"

            .Parameters.AddWithValue("@vip_no", strUserId)
            .Parameters.AddWithValue("@acct_id", strAcctId)
            .Parameters.AddWithValue("@sub_acct", strSubAcctId)
            .Parameters.AddWithValue("@company", strCompany)
        End With

        tmpDS = Me.QueryData("frequent")

        Return tmpDS
    End Function


    '----------------------------------------------------------------
    '--Function NewProfileAdd
    '--Description:Insert Passenger Information 
    '--01/31/08 - Created(lily)
    '## out
    '## -2  Profile is duplicate
    '----------------------------------------------------------------
    Public Function AddFrequentProfile(ByVal userdata As UserData) As Int32
        Dim out As Int32 = 0

        Try
            Me.OpenConnection()

            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "apex_wr_vipfreq_addfrequentprofile"

                .Parameters.AddWithValue("@vip_no", userdata.user_id)
                .Parameters.AddWithValue("@acct_id", userdata.acct_id)
                .Parameters.AddWithValue("@sub_acct_id", userdata.sub_acct_id)
                .Parameters.AddWithValue("@Company", userdata.Company)

                .Parameters.AddWithValue("@fname", userdata.fname)
                .Parameters.AddWithValue("@lname", userdata.lname)

                .Parameters.AddWithValue("@phone", userdata.office_phone)
                .Parameters.AddWithValue("@phone_ext", userdata.office_phone_ext)

                .Parameters.AddWithValue("@email", userdata.email)

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
    '## -2  Profile is duplicate
    Public Function UpdateFrequentProfile(ByVal userdata As UserData, ByVal oldLastName As String, ByVal oldFirstName As String) As Int32
        Dim out As Int32 = 0

        Try
            Me.OpenConnection()

            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "apex_wr_vipfreq_updatefrequentprofile"

                .Parameters.AddWithValue("@vip_no", userdata.user_id)
                .Parameters.AddWithValue("@acct_id", userdata.acct_id)
                .Parameters.AddWithValue("@sub_acct_id", userdata.sub_acct_id)
                .Parameters.AddWithValue("@Company", userdata.Company)

                .Parameters.AddWithValue("@old_fname", oldFirstName)
                .Parameters.AddWithValue("@old_lname", oldLastName)

                .Parameters.AddWithValue("@new_fname", userdata.fname)
                .Parameters.AddWithValue("@new_lname", userdata.lname)

                .Parameters.AddWithValue("@phone", userdata.office_phone)
                .Parameters.AddWithValue("@phone_ext", userdata.office_phone_ext)

                .Parameters.AddWithValue("@email", userdata.email)

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

    Public Function DeleteFrequentProfile(ByVal usr As UserData) As Int32
        Dim out As Int32 = 0

        Try
            Me.OpenConnection()

            With Me.Command
                .CommandType = CommandType.StoredProcedure
                .CommandText = "apex_wr_vipfreq_deletefrequentprofile"

                .Parameters.AddWithValue("@vip_no", usr.user_id)
                .Parameters.AddWithValue("@acct_id", usr.acct_id)
                .Parameters.AddWithValue("@sub_acct_id", usr.sub_acct_id)
                .Parameters.AddWithValue("@company", usr.Company)
                .Parameters.AddWithValue("@fname", usr.fname)
                .Parameters.AddWithValue("@lname", usr.lname)

                out = .ExecuteNonQuery()
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
