Imports Microsoft.VisualBasic

Public Class Payflow
    Implements IDisposable

#Region " Priorities "

    Private m_cc_no As String
    Private m_exp_date As String
    Private m_amount As String
    Private m_error_msg As String
    '-- internal --
    Private m_pwd As String
    Private m_user As String
    Private m_vendor As String
    Private m_partner As String

    Private m_RESULT As String
    Private m_PNREF As String
    Private m_RESPMSG As String
    Private m_AUTHCODE As String

    Public Property cc_no() As String
        Get
            Return m_cc_no
        End Get
        Set(ByVal Value As String)
            m_cc_no = Value
        End Set
    End Property

    Public Property exp_date() As String
        Get
            Return m_exp_date
        End Get
        Set(ByVal Value As String)
            m_exp_date = Value
        End Set
    End Property
    Public Property amount() As String
        Get
            Return m_amount
        End Get
        Set(ByVal Value As String)
            m_amount = Value
        End Set
    End Property
    Public Property error_msg() As String
        Get
            Return m_error_msg
        End Get
        Set(ByVal Value As String)
            m_error_msg = Value
        End Set
    End Property

    '-- internal --
    Public Property pwd() As String
        Get
            Return m_pwd
        End Get
        Set(ByVal Value As String)
            m_pwd = Value
        End Set
    End Property
    Public Property user() As String
        Get
            Return m_user
        End Get
        Set(ByVal Value As String)
            m_user = Value
        End Set
    End Property
    Public Property partner() As String
        Get
            Return m_partner
        End Get
        Set(ByVal Value As String)
            m_partner = Value
        End Set
    End Property
    Public Property RESULT() As String
        Get
            Return m_RESULT
        End Get
        Set(ByVal Value As String)
            m_RESULT = Value
        End Set
    End Property
    Public Property PNREF() As String
        Get
            Return m_PNREF
        End Get
        Set(ByVal Value As String)
            m_PNREF = Value
        End Set
    End Property
    Public Property RESPMSG() As String
        Get
            Return m_RESPMSG
        End Get
        Set(ByVal Value As String)
            m_RESPMSG = Value
        End Set
    End Property
    Public Property AUTHCODE() As String
        Get
            Return m_AUTHCODE
        End Get
        Set(ByVal Value As String)
            m_AUTHCODE = Value
        End Set
    End Property

#End Region

#Region " Structor "

    Public Sub New()
        Me.m_pwd = "54fcxqj2"
        Me.m_user = "gustoi"
        Me.m_vendor = "gustoi"
        Me.m_partner = "VeriSign"
    End Sub

#End Region

#Region " Functions "

    Private Sub Dispose() Implements IDisposable.Dispose
        GC.SuppressFinalize(Me)
    End Sub

    '-- verify that input fields have been inputed --
    Private Function verify_fields()
        Dim bolVerify
        bolVerify = True
        If m_cc_no = "" Then
            bolVerify = False
            m_error_msg = "No CC # Passed"
        ElseIf Trim(m_exp_date) = "" Then
            bolVerify = False
            m_error_msg = "No Exp Date Passed"
        ElseIf Trim(m_amount) = "" Then
            bolVerify = False
            m_error_msg = "No Amount Passed"
        End If
        verify_fields = bolVerify
    End Function

    '-- Performs validation --
    '-- returns true if validated. false if error or not validated --
    Public Function authorize()
        Dim objClient As New PFProCOMLib.PNCom
        Dim parmList, Ctx1, curString, varString As String
        Dim name, value As String

        If verify_fields() = True Then

            'build the parameter list, such that we have a sale transaction and
            'a credit card tender.
            parmList = "TRXTYPE=A&TENDER=C&COMMENT1=ASP/COM Web Transaction"

            'set the account form the html form
            parmList = parmList & "&ACCT=" & m_cc_no

            'set the password from the html form
            parmList = parmList & "&PWD=" & m_pwd

            'set the user from the HTML form
            parmList = parmList & "&USER=" & m_user

            'set the vendor from the HTML form
            parmList = parmList & "&VENDOR=" & m_user

            'set the partner from the HTML form
            parmList = parmList & "&PARTNER=" & m_partner

            'set the expiration date form the HTML form
            parmList = parmList & "&EXPDATE=" & m_exp_date

            'set the amount from the HTML form
            parmList = parmList & "&AMT=" & m_amount


            Ctx1 = objClient.CreateContext("payflow.verisign.com", 443, 30, "", 0, "", "")
            curString = objClient.SubmitTransaction(Ctx1, parmList, Len(parmList))
            objClient.DestroyContext(Ctx1)


            'loop until we're done processing the entire string
            Do While Len(curString) <> 0

                'get the next name value pair

                If InStr(curString, "&") Then
                    varString = Left(curString, InStr(curString, "&") - 1)
                Else
                    varString = curString
                End If

                'get the name part of the name/value pair
                name = Left(varString, InStr(varString, "=") - 1)

                'get the value out of the name/value pair
                value = Right(varString, Len(varString) - (Len(name) + 1))

                Select Case UCase(name)
                    Case "RESULT"
                        m_RESULT = value
                    Case "PNREF"
                        m_PNREF = value
                    Case "RESPMSG"
                        m_RESPMSG = value
                    Case "AUTHCODE"
                        m_AUTHCODE = value
                End Select

                'skip over the &
                If Len(curString) <> Len(varString) Then
                    curString = Right(curString, Len(curString) - (Len(varString) + 1))
                Else
                    curString = ""
                End If
            Loop

            objClient = Nothing

            m_error_msg = m_RESPMSG


            If m_RESULT = "0" Then
                authorize = True
            Else
                authorize = False
            End If


        Else
            authorize = False
        End If
    End Function

#End Region

End Class
