Public Class FormatInformation
    'Description : format the time like YYYY MM DD HH:MM:SS AM/PM 
    'input:        date
    'output        string
    'author:       jiafeng
    'date:         12/27/2006
    Public Function formatDate(ByVal data As Date) As String
        Dim strResult As String = ""
        Try
            strResult = data.ToShortDateString
            'If data.Hour + data.Minute + data.Second > 0 Then
            Dim intHour As Integer
            intHour = data.Hour
            If intHour > 12 Then
                strResult &= " " & Convert.ToString(intHour - 12)
            Else
                strResult &= " " & intHour.ToString
            End If
            If data.Minute >= 10 Then
                strResult &= ":" & data.Minute.ToString
            Else
                strResult &= ":0" & data.Minute.ToString
            End If
            If data.Second >= 10 Then
                strResult &= ":" & data.Second.ToString
            Else
                strResult &= ":0" & data.Second.ToString
            End If


            If intHour > 12 Then
                strResult &= " PM"
            Else
                strResult &= " AM"
            End If
            ' End If

        Catch ex As Exception
            strResult = data.ToString
        End Try
        Return strResult
    End Function
End Class
