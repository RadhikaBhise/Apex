Imports Microsoft.VisualBasic
Imports System.Web.HttpContext
Imports Business.Security
Imports System.Web
Imports System.Text
Imports System.Web.UI.WebControls
Imports System.Text.RegularExpressions

Public Class Common

    Public Shared Function ContextSafe(ByVal Input As String) As String

        Input = Input.Replace("\r\n", "<br>")
        Input = Input.Replace("<", "[")
        Input = Input.Replace("/>", "/]")
        Input = Input.Replace(">", "]")
        Input = Input.Replace("</", "[/")

        Return Input

    End Function

    Public Shared Function ContextSafeBack(ByVal Input As String) As String

        Input = Input.Replace("[", "<")
        Input = Input.Replace("/]", "/>")
        Input = Input.Replace("]", ">")
        Input = Input.Replace("[/", "</")
        'Input = Input.Replace("<br>", "\r\n")

        Return Input

    End Function

    Public Shared Function ShowDateTime(ByVal DateTime As Object, Optional ByVal TimeStyle As DateTimeStyle = DateTimeStyle.DateOnly) As String
        Dim dt As System.DateTime
        Dim DateString As String = Convert.ToString(DateTime).Trim()

        If TimeStyle = DateTimeStyle.DateAndTimeInEn Then
            If Not IsDate(DateString) Then
                DateString = Convert.ToDateTime("1/1/1900 00:00:00")
            End If
        End If

        If IsDate(DateString) Then
            dt = Convert.ToDateTime(DateString)
            Dim Format As String = "MM/dd/yyyy"

            Select Case TimeStyle
                Case Common.DateTimeStyle.DateAndTime
                    Format = "MM/dd/yyyy hh:mm tt"
                Case Common.DateTimeStyle.DateOnly
                    Format = "MM/dd/yyyy"
                Case Common.DateTimeStyle.TimeOnly
                    Format = "hh:mm tt"
                    'added by lily 01/10/2008
                Case Common.DateTimeStyle.DateAndTimeInEn
                    Format = "MMM d yyyy hh:mm tt"
                    'Case Common.DateTimeStyle.DateOnlyInEn
                    '    Format = "MMM d yyyy"
            End Select

            DateString = dt.ToString(Format)
        End If

        Return DateString
    End Function
   

    Public Shared Function ShowAddress(ByVal StNo As String, ByVal StName As String, ByVal City As String, ByVal State As String, ByVal Zip As String, ByVal Landmark As String) As String
        Dim out As String = Landmark

        'If Landmark.Trim().Length = 0 Then
        '    out = SentenceCase(Trim(StNo) & " " & Trim(StName) & " " & Trim(City) & " " & Trim(State) & " " & Trim(Zip))
        'End If
        out &= " " & SentenceCase(Trim(StNo) & " " & Trim(StName) & " " & Trim(City) & " " & Trim(State) & " " & Trim(Zip))

        Return out.Trim
    End Function
    Public Shared Function ShowAirportAddress(ByVal airport As String, ByVal airline As String, ByVal flight As String, ByVal puPoint As String) As String
        Dim out As String

        out = airport.ToUpper().Trim & ",  AIRLINE: " & airline.Trim & ",  FLIGHT:" & flight.Trim

        If Not puPoint Is Nothing AndAlso puPoint.Trim.Length > 0 Then
            out &= ",  PICKUP:" & puPoint.Trim
        End If

        Return out.Trim
    End Function

    Public Shared Function ShowPhoneNo(ByVal strPhoneNo As String) As String
        Dim out As String

        If strPhoneNo.Length = 10 Then
            out = Left(strPhoneNo, 3) & "-" & strPhoneNo.Substring(3, 3) & "-" & Right(strPhoneNo, 4)
        Else
            out = strPhoneNo
        End If

        Return out
    End Function

    Public Shared Function ShowPrice(ByVal price As String, ByVal format As PricePrefix) As String
        Dim out As String

        Select Case format
            Case PricePrefix.dollar
                out = "$" & Val(Convert.ToString(price)).ToString("#,###,###0.00")
            Case Else
                out = Val(Convert.ToString(price)).ToString("#,###,###0.00")
        End Select

        Return out
    End Function

    Public Shared Sub ShowDropDownValue(ByRef DropDown As DropDownList, ByVal value As String, ByVal isNumValue As Boolean)
        If isNumValue Then
            For Each li As ListItem In DropDown.Items
                If Val(li.Value) = Val(value) Then
                    DropDown.SelectedIndex = -1
                    li.Selected = True
                    Exit For
                End If
            Next
        Else
            For Each li As ListItem In DropDown.Items
                If li.Value.Trim = value.Trim Then
                    DropDown.SelectedIndex = -1
                    li.Selected = True
                    Exit For
                End If
            Next
        End If
    End Sub

    '--SentenceCase
    Public Shared Function SentenceCase(ByVal str As String) As String
        Dim str1, temp As String
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

#Region " Enum "
    Enum PricePrefix
        null = 0
        dollar = 1
    End Enum

    Public Enum DateTimeStyle
        DateAndTime
        DateOnly
        TimeOnly
        DateAndTimeInEn 'added by lily 01/10/2008
        'DateOnlyInEn    'added by lily 01/10/2008  '1/10/2008  Disabled By Yang
    End Enum

    Public Enum UserType
        NormalUser
        CorporateUser
        GroupUser
        QuickUser
    End Enum
    Public Shared Function GetUserTypeString(ByVal user As UserType) As String
        Dim out As String = ""
        Select Case user
            Case UserType.CorporateUser
                out = "corporate"
            Case UserType.GroupUser
                out = "group"
            Case UserType.QuickUser
                out = "quick"
            Case Else
                out = "user"
        End Select
        Return out
    End Function
#End Region

#Region "Generate Excel File From DataGrid"

    '## General CSV file
    '## 8/6/2007    created by yang
    Public Shared Sub GenerateCSVFile(ByRef Page As System.Web.UI.Page, ByVal MyDataGrid As System.Web.UI.WebControls.DataGrid, ByVal FileName As String)
        Dim resp As HttpResponse
        Dim colCount As Integer = MyDataGrid.Columns.Count - 1

        resp = Page.Response

        'resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312")
        'resp.Charset = "utf-8"
        'resp.AddFileDependency(FileName)
        'resp.ContentType = "Text/HTML"
        ''resp.AppendHeader("Content-Type", "text/html; charset=gb2312")

        resp.AppendHeader("Content-Disposition", "attachment;filename=" + FileName) 'DownLoad 

        Dim colHeaders As String = ""
        Dim strItems As StringBuilder = New StringBuilder

        Dim myCol As DataGridColumn

        Dim i As Integer

        For i = 0 To colCount
            myCol = MyDataGrid.Columns(i)
            If myCol.Visible = True Then
                colHeaders = colHeaders & myCol.HeaderText.ToString & ","
            End If
        Next

        If colHeaders.Length > 0 Then
            colHeaders = colHeaders.Substring(0, colHeaders.LastIndexOf(","))
        End If

        colHeaders = colHeaders & Chr(13) & Chr(10)
        colHeaders = HtmlEliminate(colHeaders)
        resp.Write(colHeaders)

        Dim colRow As String = ""

        Dim item As DataGridItem
        Dim iPage As Integer = MyDataGrid.PageCount

        For Each item In MyDataGrid.Items
            'resp.Write(FormatExportRow(colCount, item, MyDataGrid))
            Dim strItem As String = FormatExportRowTemplate(colCount, item, MyDataGrid)
            resp.Write(HtmlEliminate(strItem))
            If Not strItem.EndsWith(System.Environment.NewLine) Then
                resp.Write(Chr(13) & Chr(10))
            End If
        Next item

        resp.End()
    End Sub

    '------------------------------------------------------------------------------
    '-- Function: FormatExportRow
    '-- Description: FormatExportRow
    '-- Input: 
    '-- Output:string 
    '-- 05/119/04 - Created (Wan)
    '------------------------------------------------------------------------------
    Private Shared Function FormatExportRow(ByVal colCount As Integer, ByVal Item As DataGridItem, ByVal MyDataGrid As System.Web.UI.WebControls.DataGrid) As String
        Dim i As Integer
        Dim strItem As String = ""

        For i = 0 To colCount
            If MyDataGrid.Columns(i).Visible = True Then
                If Item.Cells(i).Text Is System.DBNull.Value Then
                    Item.Cells(i).Text = ""
                End If
                If i = colCount Then
                    strItem += Item.Cells(i).Text.ToString & Chr(13) & Chr(10)
                Else
                    strItem += Item.Cells(i).Text.ToString & ","
                End If
            End If
        Next
        strItem = Replace(strItem, " ", " ")
        Return strItem
    End Function

    '------------------------------------------------------------------------------
    '-- Function: FormatExportRowTemplate
    '-- Description: FormatExportRow
    '-- Input: 
    '-- Output:string 
    '-- 08/06/07 - Created (yang)
    '------------------------------------------------------------------------------
    Private Shared Function FormatExportRowTemplate(ByVal colCount As Integer, ByVal Item As DataGridItem, ByVal MyDataGrid As System.Web.UI.WebControls.DataGrid) As String
        Dim i As Integer
        Dim j As Int32
        Dim strItem As String = ""
        Dim NumOfControls As Int32
        Dim reg As New System.Text.RegularExpressions.Regex("^\$[\s\d]+\.\d+$")

        For i = 0 To colCount
            If MyDataGrid.Columns(i).Visible = True Then
                If Item.Cells(i).HasControls Then
                    NumOfControls = Item.Cells(i).Controls.Count

                    For j = 0 To NumOfControls - 1
                        If TypeOf (Item.Cells(i).Controls(j)) Is Label Then
                            '## Label
                            Dim lblTmp As Label = CType(Item.Cells(i).Controls(j), Label)
                            If lblTmp.ToolTip.Trim.Length > 0 Then
                                Dim tmp As String = ItemFlitrate(lblTmp.ToolTip)
                                If i = colCount AndAlso j = NumOfControls - 1 Then
                                    strItem &= tmp & Chr(13) & Chr(10)
                                ElseIf j = NumOfControls - 1 Then
                                    strItem &= tmp & ","
                                Else
                                    strItem &= tmp
                                End If
                            Else
                                Dim tmp As String = ItemFlitrate(lblTmp.Text)
                                If i = colCount AndAlso j = NumOfControls - 1 Then
                                    strItem &= tmp & Chr(13) & Chr(10)
                                ElseIf j = NumOfControls - 1 Then
                                    strItem &= tmp & ","
                                Else
                                    strItem &= tmp
                                End If
                            End If
                        ElseIf TypeOf (Item.Cells(i).Controls(j)) Is HyperLink Then
                            '## Hyperlink
                            Dim linkTmp As HyperLink = CType(Item.Cells(i).Controls(j), HyperLink)
                            Dim tmp As String = ItemFlitrate(linkTmp.Text)
                            If i = colCount AndAlso j = NumOfControls - 1 Then
                                strItem &= tmp & Chr(13) & Chr(10)
                            ElseIf j = NumOfControls - 1 Then
                                strItem &= tmp & ","
                            Else
                                strItem &= tmp
                            End If
                        ElseIf TypeOf (Item.Cells(i).Controls(j)) Is DropDownList Then
                            '## Dropdown List
                            Dim drpTmp As DropDownList = CType(Item.Cells(i).Controls(j), DropDownList)
                            Dim tmp As String = ItemFlitrate(drpTmp.SelectedItem.Text)
                            If i = colCount AndAlso j = NumOfControls - 1 Then
                                strItem &= tmp & Chr(13) & Chr(10)
                            ElseIf j = NumOfControls - 1 Then
                                strItem &= tmp & ","
                            Else
                                strItem &= tmp
                            End If
                        ElseIf TypeOf (Item.Cells(i).Controls(j)) Is TextBox Then
                            '## TextBox
                            Dim txtTmp As TextBox = CType(Item.Cells(i).Controls(j), TextBox)
                            Dim tmp As String = ItemFlitrate(txtTmp.Text)
                            If i = colCount AndAlso j = NumOfControls - 1 Then
                                strItem &= tmp & Chr(13) & Chr(10)
                            ElseIf j = NumOfControls - 1 Then
                                strItem &= tmp & ","
                            Else
                                strItem &= tmp
                            End If
                        ElseIf TypeOf (Item.Cells(i).Controls(j)) Is Literal Then
                            '## Literal
                            Dim txtTmp As Literal = CType(Item.Cells(i).Controls(j), Literal)
                            Dim tmp As String = txtTmp.Text
                            If i = colCount AndAlso j = NumOfControls - 1 Then
                                strItem &= tmp & Chr(13) & Chr(10)
                            ElseIf j = NumOfControls - 1 Then
                                strItem &= tmp & ","
                            Else
                                strItem &= tmp
                            End If
                        ElseIf TypeOf (Item.Cells(i).Controls(j)) Is LinkButton Then
                            '## Link Button
                            Dim btnTmp As LinkButton = CType(Item.Cells(i).Controls(j), LinkButton)
                            Dim tmp As String = btnTmp.Text
                            If i = colCount AndAlso j = NumOfControls - 1 Then
                                strItem &= tmp & Chr(13) & Chr(10)
                            ElseIf j = NumOfControls - 1 Then
                                strItem &= tmp & ","
                            Else
                                strItem &= tmp
                            End If
                        Else
                            If Item.Cells(i).Text Is System.DBNull.Value Then
                                Item.Cells(i).Text = ""
                            End If
                            Dim tmp As String = ItemFlitrate(Item.Cells(i).Text)

                            If i = colCount AndAlso j = NumOfControls - 1 Then
                                strItem += tmp & Chr(13) & Chr(10)
                            ElseIf j = NumOfControls - 1 Then
                                strItem += tmp & ","
                            Else
                                strItem += tmp
                            End If
                        End If
                    Next

                Else
                    If Item.Cells(i).Text Is System.DBNull.Value Then
                        Item.Cells(i).Text = ""
                    Else
                        '## Remove " ," in the cell Text
                        Item.Cells(i).Text = Item.Cells(i).Text.Replace(",", " ")
                    End If
                    Dim tmp As String = Item.Cells(i).Text

                    If reg.IsMatch(tmp) Then
                        tmp = Regex.Replace(tmp, "\s+", "")
                    End If

                    If i = colCount Then
                        strItem += tmp & Chr(13) & Chr(10)
                    Else
                        strItem += tmp & ","
                    End If
                End If
            End If
        Next

        Return strItem
    End Function

    Private Shared Function ItemFlitrate(ByVal strItem As String) As String
        If strItem.IndexOf(",") >= 0 Then
            strItem = """" & strItem & """"
        End If
        Return strItem
    End Function

    '------------------------------------------------------------------------------
    '-- Function: HtmlEliminate
    '-- Description: HtmlEliminate
    '-- Input: string
    '-- Output: string
    '-- 05/119/04 - Created (Wan)
    '------------------------------------------------------------------------------
    Private Shared Function HtmlEliminate(ByVal strTmp As String) As String
        'Function: Eliminate HTML
        Try
            '## Replace <br> with " "
            strTmp = Regex.Replace(strTmp, "\<br/?\>", " ", RegexOptions.IgnoreCase)

            Dim pat As String = "\<[^\<\>]*\>"
            strTmp = System.Text.RegularExpressions.Regex.Replace(strTmp, pat, "")
            pat = "(&nbsp;)"
            strTmp = System.Text.RegularExpressions.Regex.Replace(strTmp, pat, " ")
            Return strTmp
        Catch ex As Exception
            Return strTmp
        End Try

    End Function

#End Region

End Class

Public Class MySession

    Public Shared Property AcctID() As String
        Get
            Return Convert.ToString(Current.Session("acct_id")).Trim()
        End Get
        Set(ByVal value As String)
            Current.Session("acct_id") = value
        End Set
    End Property
    Public Shared Property UserID() As String
        Get
            Return Convert.ToString(Current.Session("user_id")).Trim()
        End Get
        Set(ByVal value As String)
            Current.Session("user_id") = value
        End Set
    End Property
    Public Shared Property SubAcctID() As String
        Get
            Return Convert.ToString(Current.Session("sub_acct_id")).Trim()
        End Get
        Set(ByVal value As String)
            Current.Session("sub_acct_id") = value
        End Set
    End Property
    Public Shared Property Company() As String
        Get
            Return Convert.ToString(Current.Session("company")).Trim()
        End Get
        Set(ByVal value As String)
            Current.Session("company") = value
        End Set
    End Property
    '--add by daniel 23/11/2007
    Public Shared Property AcctName() As String
        Get
            Return Convert.ToString(Current.Session("acct_name")).Trim()
        End Get
        Set(ByVal value As String)
            Current.Session("acct_name") = value
        End Set
    End Property
    Public Shared Property UserName() As String
        Get
            Return Convert.ToString(Current.Session("username")).Trim()
        End Get
        Set(ByVal value As String)
            Current.Session("username") = value
        End Set
    End Property

    Public Shared Property OperatorOrder() As OperatorData
        Get
            Return Current.Session.Item("operator")
        End Get
        Set(ByVal value As OperatorData)
            Current.Session.Item("operator") = value
        End Set
    End Property

    '--add by daniel 6/12/2007
    Public Shared Property Table_ID() As String
        Get
            Return Convert.ToString(Current.Session("table_id")).Trim()
        End Get
        Set(ByVal value As String)
            Current.Session("table_id") = value
        End Set
    End Property
    'added by lily 12/11/2007
    Public Shared Property LevelID() As String
        Get
            Return Convert.ToString(Current.Session("level_id")).Trim()
        End Get
        Set(ByVal value As String)
            Current.Session("level_id") = value
        End Set
    End Property
    Public Shared Property Priority() As String
        Get
            Return Convert.ToString(Current.Session("priority")).Trim()
        End Get
        Set(ByVal value As String)
            Current.Session("priority") = value
        End Set
    End Property
    Public Shared Property CompID() As String
        Get
            Return Convert.ToString(Current.Session("CompID")).Trim()
        End Get
        Set(ByVal value As String)
            Current.Session("CompID") = value
        End Set
    End Property

    '## 12/13/2007  added by yang
    Public Shared Sub ClearSession()
        Current.Session.Clear()
    End Sub

End Class
