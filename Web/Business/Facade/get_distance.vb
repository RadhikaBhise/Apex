Imports System
Imports System.Configuration
Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Imports System.Text.ASCIIEncoding

Public Class get_distance

    Public Function GetMileDistance(ByVal strAddr1 As String, ByVal strAddr2 As String, ByRef intErr1 As Integer, ByRef intErr2 As Integer) As Single
        Dim tmpDist As Single = 0
        If intErr1 > 1 Or intErr2 > 1 Then
            Return tmpDist
        End If

        Dim strRead As String
        Dim intSplit As Integer


        strRead = Me.u_DistanceCalc(strAddr1, strAddr2)
        If strRead.Length = 0 Then
            Return tmpDist
        End If

        intSplit = strRead.IndexOf("%")
        strRead = strRead.Substring(intSplit + 1)
        intSplit = strRead.LastIndexOf("%")
        strRead = strRead.Substring(0, intSplit)
        intSplit = strRead.IndexOf("%")

        Dim strResult As String
        Dim strDist As String
        Dim intResult As Integer
        Dim sngDist As Single

        strResult = strRead.Substring(0, intSplit)
        strDist = strRead.Substring(intSplit + 1)

        intResult = System.Convert.ToInt32(strResult)

        Select Case intResult
            Case -1 'location 1 wrong
                If intErr1 = 0 Then
                    intErr1 = -1
                Else
                    intErr1 = 5
                End If

            Case -2 'location 2 wrong
                If intErr2 = 0 Then
                    intErr2 = -1
                Else
                    intErr2 = 5
                End If

            Case -3 'calculate error

            Case 1  'ok
                tmpDist = System.Convert.ToSingle(strDist)
        End Select

        Return tmpDist

    End Function


    Private Function u_DistanceCalc(ByVal strAddr1 As String, ByVal strAddr2 As String) As String
        'Message format here
        Dim strFrom As String = "%" & strAddr1 & "%" & strAddr2 & "%"
        Dim tcpC As TcpClient
        Dim strIP As String
        Dim strPort As String
        Dim Port As Integer

        strIP = ConfigurationSettings.AppSettings("MapPointServerIp")
        strPort = ConfigurationSettings.AppSettings("MapPointServerPort")

        Try


            'Dim Iphost As IPHostEntry = Dns.Resolve("localhost")
            Dim IpAddr As IPAddress = IPAddress.Parse(strIP)
            Port = CType(strPort, Integer)

            tcpC = New TcpClient

            tcpC.Connect(IpAddr, Port)

            Dim s As Stream
            s = tcpC.GetStream()

            Dim bytRead(1024) As Byte
            Dim bytSend(1024) As Byte


            bytSend = ASCII.GetBytes(strFrom.ToCharArray())

            s.Write(bytSend, 0, bytSend.Length)

            Dim bytes As Integer = s.Read(bytRead, 0, 1024)
            Dim strRead As String = ASCII.GetString(bytRead)

            tcpC.Close()
            tcpC = Nothing

            Return strRead
        Catch ex As Exception
            tcpC = Nothing
            Return ""
        End Try

    End Function

End Class

