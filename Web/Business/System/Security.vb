Imports System.Diagnostics
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports DataAccess

Public Class Security
    '----------------------------------------------------------------------------------------
    'Function: access
    'Description:  
    'Modification: 2004/10/26   Nanco
    '----------------------------------------------------------------------------------------
    Public Function access(ByVal priority As String, ByVal level1 As String, ByVal level2 As String, ByVal level3 As String, ByVal level4 As String, ByVal level5 As String, ByVal level6 As String) As Boolean
        If level1 <> "" Then
            If priority = level1 Then
                Return True
            End If
        End If
        If level2 <> "" Then
            If priority = level2 Then
                Return True
            End If
        End If
        If level3 <> "" Then
            If priority = level3 Then
                Return True
            End If
        End If
        If level4 <> "" Then
            If priority = level4 Then
                Return True
            End If
        End If
        If level5 <> "" Then
            If priority = level5 Then
                Return True
            End If
        End If
        If level6 <> "" Then
            If priority = level6 Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Function access(ByVal id As String, ByVal priority As String) As Boolean
        Dim bolValue As Boolean
        bolValue = True
        '-- if hardcoded to admin only --
        If StrComp(id, "a", CompareMethod.Text) = 0 Then
            If StrComp(priority, "a", CompareMethod.Text) <> 0 Then
                bolValue = False
            Else
                bolValue = True
            End If
        Else
            Dim pid As Integer
            pid = CInt(id)
            Dim m_DB As New CommonDB
            With m_DB
                Try
                    .OpenConnection()
                    Dim SQLStrAccess As String
                    SQLStrAccess = "select pid from webride_permission(nolock) where "

                    SQLStrAccess = SQLStrAccess & " pid = '" & id & "' and priority = '" & priority & "' and active_flag = 'y'"
                    .Command.CommandText = SQLStrAccess
                    .Reader = .Command.ExecuteReader

                    If .Reader.HasRows Then
                        bolValue = True
                    Else
                        bolValue = False
                    End If
                Catch ex As Exception
                    .CloseConnection()
                    bolValue = False
                End Try
            End With
        End If
        Return bolValue
    End Function

    Public Shared Function SQLSafe(ByVal input_value As String) As String
        If IsDBNull(input_value) Or input_value.Length = 0 Then
            Return ""
        Else
            Return Replace(input_value, "'", "''")
        End If
    End Function


    '-------------------------------------------------------
    'Input     an Object ,its default property is ToString
    'Output    String
    'Author    Tom
    '--------------------------------------------------------
    Public Shared Function StrOut(ByVal o As Object) As String
        If IsDBNull(o) Then
            Return ""
        Else
            Return Convert.ToString(o).Trim()
        End If
    End Function

    '--SentenceCase
    Public Shared Function SentenceCase(ByVal str As String) As String
        Dim str1, temp, firstChar As String
        Dim i, nStrLen As Integer

        temp = LCase(Trim(str))
        str1 = ""
        nStrLen = Len(temp)

        For i = 1 To nStrLen
            str1 = str1 + Mid(temp, i, 1)
            If i <> 1 Then
                If Mid(temp, i - 1, 1) = Chr(32) Then str1 = Mid(str1, 1, i - 1) + UCase(Mid(temp, i, 1))
            Else
                str1 = UCase(str1)
            End If
        Next
        Return str1
    End Function

    '-------------------------------------------------------------------
    '--Function:Check_DBNULL
    '--Description:Check the value 
    '--Input:Value
    '--Output:Nothing for DBNULL
    '--12/4/07 - Created (Daniel)
    '-------------------------------------------------------------------
    Public Function Check_DBNULL(ByVal Value As Object) As String

        If IsDBNull(Value) = True Then
            Return Nothing
        Else
            Return Convert.ToString(Value).Trim()
        End If

    End Function

#Region "Tracing current user action"
    '----------------------------------
    'Creator: Nanco
    'Time: 2004/9/28
    'Modify:2004/10/14 Spring
    'For: Audit Trail
    '----------------------------------

    '------------------------------------
    'Base Function
    'Recorde the user action in data base
    '------------------------------------
    Public Shared Function AuditTrail(ByVal action_type As Int16, _
                               ByVal opr_no As String, _
                               Optional ByVal confirmation_no As String = "0000000000", _
                               Optional ByVal host_name As String = "", _
                               Optional ByVal car_no As String = "") As Boolean
        '--------------------------------------
        'Store Procedure:  gswr_Audit_Action
        '--------------------------------------
        Dim blnResult As Boolean
        Dim objDB As CommonDB

        objDB = New CommonDB

        With objDB
            Try
                .OpenConnection()
                With .Command
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "gswr_Audit_Action"

                    ''origial code by nanco
                    '.Parameters.Add(New SqlParameter("@confirmation_no", SqlDbType.Char, 10))
                    ' .Parameters("@confirmation_no").Value = confirmation_no
                    '.Parameters.Add(New SqlParameter("@action_type", SqlDbType.TinyInt))
                    ' .Parameters("@action_type").Value = action_type
                    ' .Parameters.Add(New SqlParameter("@car_no", SqlDbType.Char, 4))
                    ' .Parameters("@car_no").Value = car_no
                    '.Parameters.Add(New SqlParameter("@opr_no", SqlDbType.Char, 20))
                    ' .Parameters("@opr_no").Value = opr_no
                    '  .Parameters.Add(New SqlParameter("@host_name", SqlDbType.Char, 15))
                    '  .Parameters("@host_name").Value = host_name

                    '  .Parameters.Add(New SqlParameter("@field_name", SqlDbType.Char, 30))
                    '  .Parameters("@field_name").Value = field_name

                    '  .Parameters.Add(New SqlParameter("@original_content", SqlDbType.VarChar, 80))
                    '  .Parameters("@original_content").Value = original_content

                    '  .Parameters.Add(New SqlParameter("@new_content", SqlDbType.VarChar, 80))
                    '  .Parameters("@new_content").Value = new_content

                    'new code by spring
                    .Parameters.Add("@confirmation_no", confirmation_no)
                    .Parameters.Add("@action_type", action_type)
                    .Parameters.Add("@car_no", car_no)
                    .Parameters.Add("@opr_no", opr_no)
                    .Parameters.Add("@host_name", host_name)

                    .ExecuteNonQuery()
                End With
                blnResult = True
            Catch ex As Exception
                blnResult = False
            Finally
                .CloseConnection()
                .Dispose()
            End Try
        End With

        objDB = Nothing

        Return blnResult

    End Function
    '------------------------------------------
    'Function: AuditTrail_LogIn
    'Description: record the user login action
    'Modification: 2004/10/14 Spring
    'Table:  Action
    '------------------------------------------
    Public Shared Function AuditTrail_LogIn(ByVal user_id As String) As Boolean
        '201 is  login action type
        Return AuditTrail(CType(201, Int16), user_id)
    End Function
    '------------------------------------------
    '    Function: AuditTrail_LogOut
    '    Description: record the user logout action
    '    Modification: 2004/10/14 Spring
    '    Table:  Action
    '------------------------------------------
    Public Shared Function AuditTrail_LogOut(ByVal user_id As String) As Boolean
        '202 is  logout action type
        Return AuditTrail(CType(202, Int16), user_id)
    End Function
    '------------------------------------------
    'Function: AuditTrail_UserEdit
    'Description: Record Edit User Profile Action
    'Modification: 2004/10/14 Spring
    'Table:  Action
    '------------------------------------------
    Public Shared Function AuditTrail_UserEdit(ByVal user_id As String, ByVal user_edited As String) As Boolean
        '203 is for acting user profile
        Return AuditTrail(CType(203, Int16), user_id, "0000000000", user_edited, "E")
    End Function
    '------------------------------------------
    'Function: AuditTrail_UserCreate
    'Description: Record Create User Profile Action
    'Modification: 2004/10/14 Spring
    'Table:  Action
    '------------------------------------------
    Public Shared Function AuditTrail_UserCreate(ByVal user_id As String, ByVal user_created As String) As Boolean
        '203 is for acting user profile
        Return AuditTrail(CType(203, Int16), user_id, "0000000000", user_created, "C")
    End Function
    '------------------------------------------
    'Function: AuditTrail_OrderUpdate
    'Description: Record Order Update Action
    'Modification: 2004/10/14 Spring
    'Table:  Action
    '------------------------------------------
    Public Shared Function AuditTrail_OrderUpdate(ByVal user_id As String, ByVal confirmation_no As String) As Boolean
        '204 is for acting order info
        Return AuditTrail(CType(204, Int16), user_id, confirmation_no, "", "E")
    End Function
    '------------------------------------------
    'Function: AuditTrail_OrderCancel
    'Description: Record Order Cancel Action
    'Modification: 2004/10/14 Spring
    'Table:  Action
    '------------------------------------------
    Public Function AuditTrail_OrderCancel(ByVal user_id As String, ByVal confirmation_no As String) As Boolean
        '204 is for acting order info
        Return AuditTrail(CType(204, Int16), user_id, confirmation_no, "", "C")
    End Function

#End Region

#Region " Encrypt "

    Public Shared bolSuccess As Boolean

    Public Enum EncryptionAlgorithm
        DES = 1
        SHA1 = 2
    End Enum

    '------------------------------------------------------------------------------
    '-- Function   : Encrypt() 
    '-- Description: Encryption function using default  Encryption Algorithm
    '-- Input      : strInput      input String which need to be encrypted
    '-- Output     : string        Encrypted string
    '--                 "-1"       error occured ,failed to encrypt
    '--                 "-2"       input string is empty
    '-- 2005/6/14 -    Created (Nancy)
    '------------------------------------------------------------------------------
    Public Shared Function Encrypt(ByVal strInput As String) As String
        Return DESEncrypt(strInput)
    End Function

    '------------------------------------------------------------------------------
    '-- Function   : Decrypt() 
    '-- Description: Decryption function using default  Decryption Algorithm
    '-- Input      : strInput      input String which need to be decrypted
    '-- Output     : string        Decrypted string
    '--                 "-1"       error occured ,failed to decrypt
    '--                 "-2"       input string is empty
    '-- 2005/6/14 -    Created (Nancy)
    '------------------------------------------------------------------------------
    Public Shared Function Decrypt(ByVal strInput As String) As String
        Return DESDecrypt(strInput)
    End Function

    '------------------------------------------------------------------------------
    '-- Function   : Encrypt() 
    '-- Description: Encryption function  using desinated  Encryption Algorithm
    '-- Input      : strInput      input String which need to be encrypted
    '--              Algorithm     the  Encryption  Algorithm  desinated 
    '-- Output     : string        Encrypted string
    '--                 "-1"       failed to encrypt( error occured  / can't find the desinated Algorithm)
    '--                 "-2"       input string is empty
    '-- 2005/6/14 -    Created (Nancy)
    '------------------------------------------------------------------------------
    Private Shared Function Encrypt(ByVal strInput As String, ByVal Algorithm As EncryptionAlgorithm) As String

        Dim strResult As String

        Select Case Algorithm
            Case EncryptionAlgorithm.DES
                strResult = DESEncrypt(strInput)
                Exit Select
            Case EncryptionAlgorithm.SHA1
                strResult = SHA1Encrypt(strInput)
                Exit Select
            Case Else
                '--not supply the desinated Algorithm Encryption
                strResult = ""
                bolSuccess = False
        End Select

        Return strResult
    End Function

    '------------------------------------------------------------------------------
    '-- Function   : Decrypt() 
    '-- Description: Decryption function using default  Decryption Algorithm
    '-- Input      : strInput      input String which need to be decrypted
    '--              Algorithm     the  Decryption  Algorithm  desinated 
    '-- Output     : string        Decrypted string
    '--                 "-1"       failed to decrypt( error occured / can't find the desinated Algorithm /  one-way Algorithm without decrypting)
    '--                 "-2"       input string is empty
    '-- 2005/6/14 -    Created (Nancy)
    '------------------------------------------------------------------------------
    Private Shared Function Decrypt(ByVal strInput As String, ByVal Algorithm As EncryptionAlgorithm) As String

        Dim strResult As String

        Select Case Algorithm
            Case EncryptionAlgorithm.DES
                strResult = DESDecrypt(strInput)
                Exit Select
            Case EncryptionAlgorithm.SHA1
                '-- can't decrypt with SHA1
                strResult = ""
                bolSuccess = False
                Exit Select
            Case Else
                '--not supply  the desinated Algorithm decryption
                strResult = ""
                bolSuccess = False
                Exit Select
        End Select

        Return strResult
    End Function

    '------------------------------------------------------------------------------
    '-- Function   : DESEncrypt() 
    '-- Description: Encryption function using  Encryption Algorithm "DES"
    '-- Input      : strInput      input String which need to be encrypted
    '-- Output     : string        Encrypted string
    '--                 "-1"       error occured ,failed to encrypt
    '--                 "-2"       input string is empty
    '-- 2005/6/14 -    Created (Nancy)
    '------------------------------------------------------------------------------
    Private Shared Function DESEncrypt(ByVal strInput As String) As String

        bolSuccess = False

        strInput = strInput.Trim
        Dim strResult As String

        Dim strKey As String = "12345678"
        Dim strIV As String = "12345678"

        Dim bytKey() As Byte = System.Text.Encoding.GetEncoding("utf-8").GetBytes(strKey)
        Dim bytIV() As Byte = System.Text.Encoding.GetEncoding("utf-8").GetBytes(strIV)

        If strInput.Length > 0 Then
            Try
                Dim cryptoProvider As New DESCryptoServiceProvider
                Dim ms As New MemoryStream
                Dim cs As New CryptoStream(ms, cryptoProvider.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write)
                Dim sw As New StreamWriter(cs)

                sw.Write(strInput)
                sw.Flush()
                cs.FlushFinalBlock()
                ms.Flush()

                strResult = Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length))
                bolSuccess = True

            Catch ex As Exception
                strResult = ""
            End Try
        Else
            strResult = ""
        End If
        Return strResult
    End Function

    '------------------------------------------------------------------------------
    '-- Function   : DESDecrypt() 
    '-- Description: Decryption function using   Decryption Algorithm "DES"
    '-- Input      : strInput      input String which need to be decrypted
    '-- Output     : string        Decrypted string
    '--                 "-1"       error occured ,failed to decrypt
    '--                 "-2"       input string is empty
    '-- 2005/6/14 -    Created (Nancy)
    '------------------------------------------------------------------------------
    Private Shared Function DESDecrypt(ByVal strInput As String) As String

        bolSuccess = False

        strInput = strInput.Trim
        Dim strResult As String

        Dim strKey As String = "12345678"
        Dim strIV As String = "12345678"

        Dim bytKey() As Byte = System.Text.Encoding.GetEncoding("utf-8").GetBytes(strKey)
        Dim bytIV() As Byte = System.Text.Encoding.GetEncoding("utf-8").GetBytes(strIV)

        If strInput.Length > 0 Then
            Try

                Dim cryptoProvider As New DESCryptoServiceProvider
                Dim bytData As Byte() = Convert.FromBase64String(strInput)
                Dim ms As MemoryStream = New MemoryStream(bytData)
                Dim cs As CryptoStream = New CryptoStream(ms, cryptoProvider.CreateDecryptor(bytKey, bytIV), CryptoStreamMode.Read)
                Dim sr As StreamReader = New StreamReader(cs)

                strResult = sr.ReadToEnd()

                bolSuccess = True

            Catch ex As Exception
                strResult = ""
            End Try
        Else
            strResult = ""
        End If
        Return strResult
    End Function

    '------------------------------------------------------------------------------
    '-- Function   : SHA1Encrypt() 
    '-- Description: Encryption function using  Encryption Algorithm "SHA1"
    '-- Input      : strInput      input String which need to be encrypted
    '-- Output     : string        Encrypted string
    '--                 "-1"       error occured ,failed to encrypt
    '--                 "-2"       input string is empty
    '-- 2005/6/14 -    Created (Nancy)
    '------------------------------------------------------------------------------
    Private Shared Function SHA1Encrypt(ByVal strInput As String) As String
        bolSuccess = False

        Dim bytResult() As Byte
        Dim bytInput() As Byte

        strInput = strInput.Trim
        Dim strResult As String

        If strInput.Length > 0 Then
            Try

                bytInput = System.Text.Encoding.GetEncoding("utf-8").GetBytes(strInput)
                Dim sha As New SHA1CryptoServiceProvider
                bytResult = sha.ComputeHash(bytInput)
                Dim sb As New System.Text.StringBuilder

                Dim iLen As Integer = bytResult.Length
                For i As Integer = 0 To iLen - 1
                    sb.Append(bytResult(i).ToString("x").PadLeft(2, Char.Parse("0")))
                Next
                strResult = sb.ToString

                bolSuccess = True

            Catch ex As Exception
                strResult = ""
            End Try
        Else
            strResult = ""
        End If
        Return strResult
    End Function
    
#End Region

End Class



