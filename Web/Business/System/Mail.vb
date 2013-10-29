'Imports System.Web.Mail
Imports System.Net.Mail
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

Public Class Mail
    '-------------------------------------------------------------------
    '--Function:SendEMail
    '--Description:For User to send an Email
    '--Input:Body,Title,SendTo
    '--Output:True--Success;False--False
    '--03/10/06 - Created (Daniel)
    '-------------------------------------------------------------------
    Public Shared Function SendEmail(ByVal strFromPass As String, ByVal strTo As String, ByVal strCc As String, ByVal strBcc As String, _
                ByVal strSubject As String, ByVal strBody As String, ByVal isBodyHtml As Boolean) As String

        Dim Msg As New MailMessage 'MailMessage   
        Dim tMAddr As MailAddress   'MailAddress   

        Dim strSMTPServer As String
        Dim strFrom As String
        Dim strPsd As String
        Dim Frm As String
        Dim FrmName As String
        Dim regMailAddress As String = "\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"

        strSMTPServer = System.Web.Configuration.WebConfigurationManager.AppSettings("SMTPServer")
        strFrom = System.Web.Configuration.WebConfigurationManager.AppSettings("From")
        strPsd = System.Web.Configuration.WebConfigurationManager.AppSettings("Pwd")
        Frm = System.Web.Configuration.WebConfigurationManager.AppSettings("Frm")
        FrmName = System.Web.Configuration.WebConfigurationManager.AppSettings("FrmName")

        Dim client As New SmtpClient
        client = New SmtpClient(strSMTPServer)

        client.UseDefaultCredentials = True
        client.Credentials = New System.Net.NetworkCredential(strFrom, strPsd)
        client.DeliveryMethod = SmtpDeliveryMethod.Network

        Try

            tMAddr = New MailAddress(Frm, FrmName)  'MailAddress£¬EMail,Name   
            Msg.From = tMAddr


            Msg.Subject = strSubject
            Msg.IsBodyHtml = isBodyHtml

            If isBodyHtml Then
                Dim tBody As String

                tBody = "<html><head><style>.dl{font-size:14}</style></head><body><table width=100% boder=0><tr><td class=dl>" + strBody + "</td></tr></table></body></html>"
                Msg.Body = tBody
            Else
                Msg.Body = strBody
            End If

            '## Add Mail To list
            If strTo.Trim.Length > 0 Then
                Dim MailTo() As String = strTo.Split(";")

                For i As Integer = 0 To MailTo.Length - 1
                    If MailTo(i).Length > 0 AndAlso Regex.IsMatch(MailTo(i), regMailAddress) Then
                        Try
                            Msg.To.Add(MailTo(i))
                        Catch
                        End Try
                    End If
                Next
            End If

            '## 12/11/2007  Add Mail Cc (yang)
            If strCc.Trim.Length > 0 Then
                Dim MailCc() As String = strCc.Split(";")

                For i As Integer = 0 To MailCc.Length - 1
                    If MailCc(i).Trim.Length > 0 AndAlso Regex.IsMatch(MailCc(i), regMailAddress) Then
                        Try
                            Msg.CC.Add(MailCc(i))
                        Catch
                        End Try
                    End If
                Next
            End If

            '## 11/20/2007  Add Mail BCC    (yang)
            If strBcc.Trim.Length > 0 Then
                Dim MailBcc() As String = strBcc.Split(";")

                For i As Integer = 0 To MailBcc.Length - 1
                    If MailBcc(i).Trim.Length > 0 AndAlso Regex.IsMatch(MailBcc(i), regMailAddress) Then
                        Try
                            Msg.Bcc.Add(MailBcc(i))
                        Catch
                        End Try
                    End If
                Next
            End If

            client.Send(Msg)
            SendEmail = "Success"
        Catch ex As Exception
          
            SendEmail = "False"
        Finally
            Msg.Dispose()
            Msg = Nothing
            tMAddr = Nothing
            client = Nothing

        End Try

    End Function
    '-------------------------------------------------------------------
    '--Function:SendEMail
    '--Description:For User to send an Email
    '--Input:Body,Title,SendTo
    '--Output:True--Success;False--False
    '--03/10/06 - Created (Daniel)
    '-------------------------------------------------------------------
    Public Shared Function SendEmail(ByVal strFromPass As String, ByVal strto As String, ByVal strSubject As String, ByVal strBody As String, ByVal isBodyHtml As Boolean) As String

        Dim Msg As New MailMessage 'MailMessage   
        Dim tMAddr As MailAddress   'MailAddress   
        'Dim y As Integer            'int 

        Dim strSMTPServer As String
        Dim strFrom As String
        Dim strPsd As String
        Dim Frm As String
        Dim FrmName As String
        Dim BCCName As String
        BCCName = System.Web.Configuration.WebConfigurationManager.AppSettings("MailBcc")

        Dim regMailAddress As String = "\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"

        strSMTPServer = System.Web.Configuration.WebConfigurationManager.AppSettings("SMTPServer")
        strFrom = System.Web.Configuration.WebConfigurationManager.AppSettings("From")
        strPsd = System.Web.Configuration.WebConfigurationManager.AppSettings("Pwd")
        Frm = System.Web.Configuration.WebConfigurationManager.AppSettings("Frm")
        FrmName = System.Web.Configuration.WebConfigurationManager.AppSettings("FrmName")

        'SmtpClient£¬MailServer,Port   
        'Dim smtpClnt As New SmtpClient("msa.hinet.net", "25") 'self's MailServer 
        Dim client As New SmtpClient
        client = New SmtpClient(strSMTPServer)
        client.UseDefaultCredentials = True
        client.Credentials = New System.Net.NetworkCredential(strFrom, strPsd)
        client.DeliveryMethod = SmtpDeliveryMethod.Network

        Try

            tMAddr = New MailAddress(Frm, FrmName)  'MailAddress£¬EMail,Name   
            Msg.From = tMAddr
            Msg.Subject = strSubject
            Msg.IsBodyHtml = isBodyHtml
            If isBodyHtml Then

                Dim tBody As String
                'Body = Replace(Body, vbCrLf, "<br>")    '<br>replace enter   
                tBody = "<html><head><style>.dl{font-size:14}</style></head><body><table width=100% boder=0><tr><td class=dl>" + strBody + "</td></tr></table></body></html>"
                Msg.Body = tBody
            Else
                Msg.Body = strBody
            End If

            If strto <> "" Then
                Dim stremailto As String
                Dim strleveemail As String
                Dim i As Integer
                Dim intLen As Integer
                'Dim strto As String = "daniel.chen@surreytechnology.com;william.dong@surreytechnology.com;daniel_c_tao@hotmail.com"
                If Right(strto, 1) = ";" Then
                    '--do nothing
                Else
                    strto = strto & ";'"
                End If
                i = InStr(strto, ";", CompareMethod.Text)
                strleveemail = strto.Substring(0, i - 1)

                Do While i > 0
                    stremailto = strto.Substring(0, i - 1)
                    intLen = Len(strto) - Len(stremailto) - 1
                    If intLen >= 0 Then
                        strto = strto.Substring(i, intLen)
                    End If
                    'strto = strto.Substring(i + 1, Len(strto) - Len(stremailto))
                    i = InStr(strto, ";", CompareMethod.Text)
                    Try
                        tMAddr = New MailAddress(stremailto)
                        Msg.To.Add(tMAddr)
                    Catch ex As Exception
                        tMAddr = New MailAddress(strleveemail)
                        Msg.To.Add(tMAddr)
                    End Try
                Loop

                'If BCCName <> "" Then
                '    tMAddr = New MailAddress(BCCName)
                '    Msg.Bcc.Add(tMAddr)
                'End If
                If BCCName.Trim.Length > 0 Then
                    Dim MailBcc() As String = BCCName.Split(";")

                    For i = 0 To MailBcc.Length - 1
                        If MailBcc(i).Trim.Length > 0 AndAlso Regex.IsMatch(MailBcc(i), regMailAddress) Then
                            Try
                                Msg.Bcc.Add(MailBcc(i))
                            Catch
                            End Try
                        End If
                    Next
                End If

            End If

            client.Send(Msg)
            SendEmail = "Success"

        Catch ex As Exception
            'Throw New Exception(ex.Message)
            SendEmail = "False"
        Finally
            Msg.Dispose()
            Msg = Nothing
            tMAddr = Nothing
            client = Nothing

        End Try

    End Function

    '-------------------------------------------------------------------
    '--Function:SendEMail
    '--Description:For User to send an Email
    '--Input:Body,Title,SendTo
    '--Output:True--Success;False--False
    '--03/10/06 - Created (Daniel)
    '-------------------------------------------------------------------
    Public Shared Function SendEmail(ByVal strto As String, ByVal mto(,) As String, ByVal cc(,) As String, ByVal bcc(,) As String, ByVal Attachment() As String, ByVal strBody As String, ByVal strSubject As String, ByVal isBodyHtml As Boolean) As String

        Dim Msg As New MailMessage 'MailMessage   
        Dim tMAddr As MailAddress   'MailAddress   
        Dim y As Integer            'int 

        Dim strSMTPServer As String
        Dim strFrom As String
        Dim strPsd As String
        Dim Frm As String
        Dim FrmName As String
        Dim BCCName As String
        BCCName = System.Configuration.ConfigurationSettings.AppSettings("BCCName")

        strSMTPServer = System.Configuration.ConfigurationSettings.AppSettings("SMTPServer")
        strFrom = System.Configuration.ConfigurationSettings.AppSettings("From")
        strPsd = System.Configuration.ConfigurationSettings.AppSettings("Pwd")
        Frm = System.Configuration.ConfigurationSettings.AppSettings("Frm")
        FrmName = System.Configuration.ConfigurationSettings.AppSettings("FrmName")

        'SmtpClient£¬MailServer,Port   
        'Dim smtpClnt As New SmtpClient("msa.hinet.net", "25") 'self's MailServer 
        Dim client As New SmtpClient
        client = New SmtpClient(strSMTPServer)
        client.UseDefaultCredentials = True
        'client.Credentials = New System.Net.NetworkCredential(strFrom, strPsd)
        client.DeliveryMethod = SmtpDeliveryMethod.Network

        Try

            tMAddr = New MailAddress(Frm, FrmName)  'MailAddress£¬EMail,Name   
            Msg.From = tMAddr
            Msg.Subject = strSubject
            Msg.IsBodyHtml = isBodyHtml
            If isBodyHtml Then

                Dim tBody As String
                'Body = Replace(Body, vbCrLf, "<br>")    '<br>replace enter   
                tBody = "<html><head><style>.dl{font-size:14}</style></head><body><table width=100% boder=0><tr><td class=dl>" + strBody + "</td></tr></table></body></html>"
                Msg.Body = tBody
            Else
                Msg.Body = strBody
            End If

            If strto <> "" Then
                Dim stremailto As String
                Dim strleveemail As String
                Dim i As Integer
                Dim intLen As Integer
                'Dim strto As String = "daniel.chen@surreytechnology.com;william.dong@surreytechnology.com;daniel_c_tao@hotmail.com"
                If Right(strto, 1) = ";" Then
                    '--do nothing
                Else
                    strto = strto & ";'"
                End If
                i = InStr(strto, ";", CompareMethod.Text)
                strleveemail = strto.Substring(0, i - 1)

                Do While i > 0
                    stremailto = strto.Substring(0, i - 1)
                    intLen = Len(strto) - Len(stremailto) - 1
                    If intLen >= 0 Then
                        strto = strto.Substring(i, intLen)
                    End If
                    'strto = strto.Substring(i + 1, Len(strto) - Len(stremailto))
                    i = InStr(strto, ";", CompareMethod.Text)
                    Try
                        tMAddr = New MailAddress(stremailto)
                        Msg.To.Add(tMAddr)
                    Catch ex As Exception
                        tMAddr = New MailAddress(strleveemail)
                        Msg.To.Add(tMAddr)
                    End Try
                Loop

                If BCCName <> "" Then
                    tMAddr = New MailAddress(BCCName)
                    Msg.Bcc.Add(tMAddr)
                End If

            End If

            If IsArray(mto) Then

                For y = 0 To UBound(mto, 2)
                    'tMAddr = New MailAddress(mto(0, y), mto(1, y))
                    tMAddr = New MailAddress(mto(y, 0), mto(y, 1))
                    Msg.To.Add(tMAddr)
                Next
            End If

            If IsArray(cc) Then

                For y = 0 To UBound(cc, 2) - 1
                    tMAddr = New MailAddress(cc(0, y), cc(1, y))
                    Msg.CC.Add(tMAddr)
                Next
            End If


            If IsArray(bcc) Then

                For y = 0 To UBound(bcc, 2) - 1
                    tMAddr = New MailAddress(bcc(0, y), bcc(1, y))
                    Msg.Bcc.Add(tMAddr)
                Next
            End If


            'If IsArray(Attachment) Then

            '    Dim matt As Attachment
            '    For y = 0 To UBound(Attachment) - 1
            '        matt = New Attachment(Attachment(y))
            '        Msg.Attachments.Add(matt)
            '    Next
            'End If

            client.Send(Msg)
            SendEmail = "Success"

        Catch ex As Exception
            'Throw New Exception(ex.Message) 
            SendEmail = "False"
        Finally
            Msg.Dispose()
            Msg = Nothing
            tMAddr = Nothing
            client = Nothing

        End Try

    End Function

End Class

