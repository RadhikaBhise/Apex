Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO


Public Class CommonDB
    Implements IDisposable

#Region " Variables "

    Private m_StrCon As String
    Private m_Con As SqlConnection
    Private m_ErrorMessage As String

    Private m_Command As SqlCommand    '--for insert,update,delete
    Private m_SelectCommand As SqlCommand  '--for select 
    Private m_Reader As SqlDataReader

    Private m_Transaction As SqlTransaction   '--11/19/04 for transaction

#End Region

#Region " Properties "

    Public Property ConnectionStr() As String
        Get
            Return m_StrCon
        End Get
        Set(ByVal Value As String)
            m_StrCon = Value
        End Set
    End Property

    Public ReadOnly Property Command() As SqlCommand
        Get
            Return m_Command
        End Get
    End Property

    Public Property Reader() As SqlDataReader
        Get
            Return m_Reader
        End Get
        Set(ByVal Value As SqlDataReader)
            m_Reader = Value
        End Set
    End Property

    Public Property SelectCommand() As SqlCommand
        Get
            '--10/28/04 intial a sqlcomamand here (spring)
            If Me.m_SelectCommand Is Nothing Then
                Me.m_SelectCommand = New SqlCommand
            End If
            Return Me.m_SelectCommand
        End Get
        Set(ByVal Value As SqlCommand)
            m_SelectCommand = Value
        End Set
    End Property
    '--11/19/04 for transaction (Spring)
    Public ReadOnly Property Transaction() As SqlTransaction
        Get
            Return Me.m_Transaction
        End Get
    End Property

    Public Property ErrorMessage() As String
        Get
            Return Me.m_ErrorMessage
        End Get
        Set(ByVal value As String)
            m_ErrorMessage = value
        End Set
    End Property
#End Region

#Region " Methods "

    '--Add by eJay 7/18/05
    Public Sub New(ByVal ConnectString As String)

        Me.m_StrCon = ConnectString
        Me.m_StrCon = Me.DESDecrypt(Me.m_StrCon)

    End Sub

    Public Sub New()
        'Me.m_StrCon = "user id=sa;password=;initial catalog=blackcar_gs;data source=surreyn;Connect Timeout=60"
        Me.m_StrCon = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
        '--08/03/05 - Add this control here for ProcessCenter Invoking (Spring)
        If Me.m_StrCon Is Nothing Then Exit Sub

        'Me.m_StrCon = Me.DESDecrypt(Me.m_StrCon)   '--disabled by eJay 3/6/2006

    End Sub

    '------------------------------------------------------------------------------
    '-- Function   : QueryDataTable
    '-- Description: This function is used for query data by sql statements,it will
    '--              return a datatable object,when call it,judge if the datatable
    '--              object is nothing or not,then datatable.rows.count,then use it
    '--              e.g.:  1. strSql = "select * from tableA"
    '--                     2. strSql = "exec sp_xx_xx varA,varB,varC"
    '-- Input      : strSql  
    '--              tabName
    '-- Output     : A datatable
    '-- 11/19/04 -   Created (Spring)
    '------------------------------------------------------------------------------
    Public Overloads Function QueryDataTable(ByVal strSql As String, ByVal tabName As String) As DataTable
        Dim tmpDS As DataSet
        Dim tmpTab As DataTable = Nothing

        tmpDS = Me.QueryData(strSql, tabName)

        If tmpDS.Tables.Count > 0 Then
            tmpTab = tmpDS.Tables(0)
        End If

        Return tmpTab

    End Function
    '------------------------------------------------------------------------------
    '-- Function   : QueryDataTable()
    '-- Description: This function is used for query data by Selectcommand,it will
    '--              return a datatable object,when call it,judge if the datatable
    '--              object is nothing or not,then datatable.rows.count,then use it
    '--              First should set the SelectCommand 
    '-- Input      : tabName
    '-- Output     : A datatable
    '-- 11/19/04 -   Created (Spring)
    '------------------------------------------------------------------------------
    Public Overloads Function QueryDataTable(ByVal tabName As String) As DataTable
        Dim tmpDS As DataSet
        Dim tmpTab As DataTable = Nothing

        tmpDS = Me.QueryData(tabName)

        If tmpDS.Tables.Count > 0 Then
            tmpTab = tmpDS.Tables(0)
        End If

        Return tmpTab

    End Function
    '------------------------------------------------------------------------------
    '-- Function   : QueryData
    '-- Description: This function is used for query data by sql statements,it will
    '--              return a dataset anyway.
    '--              e.g.:  1. strSql = "select * from tableA"
    '--                     2. strSql = "exec sp_xx_xx varA,varB,varC"
    '-- Input      : strSql  
    '--              tabName
    '-- Output     : A dataset
    '-- 07/01/04 -   Created (Spring)
    '------------------------------------------------------------------------------
    Public Overloads Function QueryData(ByVal strSql As String, ByVal tabName As String) As DataSet
        Dim tmpDA As SqlDataAdapter
        Dim tmpDS As DataSet


        If tabName.Trim().Length = 0 Then
            tabName = "TEMP"
        End If

        tmpDS = New DataSet

        Try
            tmpDA = New SqlDataAdapter(strSql, Me.m_StrCon)
            tmpDA.MissingSchemaAction = MissingSchemaAction.AddWithKey

            tmpDA.Fill(tmpDS, tabName)

        Catch ex As Exception
            Me.m_ErrorMessage = ex.Message
        Finally
            If Not tmpDA Is Nothing Then
                If Not tmpDA.SelectCommand Is Nothing Then
                    If Not tmpDA.SelectCommand.Connection Is Nothing Then
                        tmpDA.SelectCommand.Connection.Dispose()
                    End If
                    tmpDA.SelectCommand.Dispose()
                End If
                tmpDA.Dispose()
                tmpDA = Nothing
            End If
        End Try

        Return tmpDS
    End Function

    '------------------------------------------------------------------------------
    '-- Function   : QueryData
    '-- Description: This function is used for query data by Selectcommand,it will
    '--              return a dataset anyway.
    '--              First should set the SelectCommand 
    '-- Input      : tabName
    '-- Output     : A dataset
    '-- 07/01/04 -   Created (Spring)
    '------------------------------------------------------------------------------
    Public Overloads Function QueryData(ByVal tabName As String) As DataSet
        Dim tmpDA As SqlDataAdapter
        Dim tmpDS As DataSet
        Dim tmpCon As SqlConnection

        If tabName.Trim().Length = 0 Then
            tabName = "TEMP"
        End If

        tmpDS = New DataSet

        Try
            tmpCon = New SqlConnection(Me.m_StrCon)
            Me.m_SelectCommand.Connection = tmpCon
            tmpDA = New SqlDataAdapter(Me.m_SelectCommand)
            tmpDA.MissingSchemaAction = MissingSchemaAction.AddWithKey

            tmpDA.Fill(tmpDS, tabName)

        Catch ex As Exception
            Me.m_ErrorMessage = ex.Message
        Finally
            If Not tmpDA Is Nothing Then
                If Not tmpDA.SelectCommand Is Nothing Then
                    If Not tmpDA.SelectCommand.Connection Is Nothing Then
                        tmpDA.SelectCommand.Connection.Dispose()
                    End If
                    tmpDA.SelectCommand.Dispose()
                End If
                tmpDA.Dispose()
                tmpDA = Nothing

                tmpCon = Nothing
            End If
        End Try

        Return tmpDS
    End Function
    '------------------------------------------------------------------------------
    '-- Function   : OpenConnection()  
    '-- Description: This function will open a native connection for insert/update
    '--              and delete command
    '-- Input      : None
    '-- Output     : None
    '-- 07/01/04 -   Created (Spring)
    '------------------------------------------------------------------------------
    Public Sub OpenConnection()
        Me.m_Con = New SqlConnection(Me.m_StrCon)
        Me.m_Con.Open()
        Me.m_Command = New SqlCommand
        Me.m_Command.Connection = Me.m_Con
    End Sub
    '------------------------------------------------------------------------------
    '-- Function   : OpenTransactionConnection()  
    '-- Description: This function will open a native connection only for transaction
    '-- Input      : None
    '-- Output     : None
    '-- 11/19/04 -   Created (Spring)
    '------------------------------------------------------------------------------
    Public Sub OpenTransactionConnection()
        Me.m_Con = New SqlConnection(Me.m_StrCon)
        Me.m_Con.Open()
        Me.m_Command = New SqlCommand
        Me.m_Command.Connection = Me.m_Con

        Me.m_Transaction = Me.m_Con.BeginTransaction(IsolationLevel.Serializable)
        Me.m_Command.Transaction = Me.m_Transaction

    End Sub

    '------------------------------------------------------------------------------
    '-- Function   : CloseConnection()  
    '-- Description: This function will close a open native connection,ensure call
    '--              it after OpenConnection() and excute a SqlCommand!!!!!!!!
    '-- Input      : None
    '-- Output     : None
    '-- 07/01/04 -   Created (Spring)
    '------------------------------------------------------------------------------
    Public Sub CloseConnection()

        If Not Me.m_Command Is Nothing Then
            Me.m_Command.Dispose()
            Me.m_Command = Nothing
        End If
        If Not Me.m_Con Is Nothing Then
            If Me.m_Con.State <> ConnectionState.Closed Then
                Me.m_Con.Close()
            End If
            Me.m_Con.Dispose()
            Me.m_Con = Nothing
        End If
        '--11/19/04  for transaction dispose
        If Not Me.m_Transaction Is Nothing Then
            Me.m_Transaction.Dispose()
            Me.m_Transaction = Nothing
        End If
        If Not Me.SelectCommand Is Nothing Then
            If Not Me.SelectCommand.Connection Is Nothing Then
                Me.SelectCommand.Connection.Dispose()
            End If
            Me.SelectCommand.Dispose()
        End If
    End Sub

    Public Overloads Sub Dispose() Implements System.IDisposable.Dispose
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Overloads Sub Dispose(ByVal disposing As Boolean)
        If Not disposing Then
            Exit Sub
        End If

        Me.CloseConnection()

    End Sub

#End Region

#Region " Encript "
    '------------------------------------------------------------------------------
    '-- Function   : DESEncrypt() 
    '-- Description: Encryption function using  Encryption Algorithm "DES"
    '-- Input      : strInput      input String which need to be encrypted
    '-- Output     : string        Encrypted string
    '--                 "-1"       error occured ,failed to encrypt
    '--                 "-2"       input string is empty
    '-- 2005/6/14 -    Created (Nancy)
    '------------------------------------------------------------------------------
    Public Shared Function DESEncrypt(ByVal strInput As String) As String

        Dim bolSuccess As Boolean = False

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

    Public Function DESDecrypt(ByVal strInput As String) As String

        Dim bolSuccess As Boolean = False

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
#End Region

End Class

