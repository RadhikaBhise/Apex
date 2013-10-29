Imports System.Data
Imports Business.Common

Partial Class Modules_VoucherList
    Inherits System.Web.UI.UserControl

#Region " Properties "

    Private m_RideDataSet As DataSet
    Private m_Total(13) As Double

    '## 1/8/2008    Disabled by yang
    'Private baserate As Double
    'Private toll As Double
    'Private parking As Double
    'Private wait As Double
    'Private stops As Double
    'Private stop_wt As Double
    'Private package As Double
    'Private surcharge As Double
    'Private phone As Double
    'Private tips As Double
    'Private service_fee As Double
    'Private gross As Double
    'Private discount As Double
    'Private net As Double


    Public WriteOnly Property DataSetSource() As DataSet
        Set(ByVal value As DataSet)
            Me.m_RideDataSet = value
            ViewState("RideDataSet") = Me.m_RideDataSet
        End Set
    End Property

    Public Sub DataSetBind(ByVal PageIndex As Int16, ByVal SortExpression As String)
        If Me.GetDataSet() Then

            Me.ResetTotal()

            If SortExpression.Trim.Length > 0 Then
                If Me.hdnSort.Value = SortExpression Then
                    Me.hdnSort.Value = SortExpression & " DESC"
                Else
                    Me.hdnSort.Value = SortExpression
                End If
            End If

            Dim dv As DataView = Me.m_RideDataSet.Tables(0).DefaultView

            If PageIndex >= 0 Then
                Me.grdData.CurrentPageIndex = PageIndex
            End If

            If Math.Ceiling(Me.m_RideDataSet.Tables(0).Rows.Count / Me.grdData.PageSize) < Me.grdData.CurrentPageIndex + 1 Then
                'Me.grdData.CurrentPageIndex = Math.Ceiling(Me.m_RideDataSet.Tables(0).Rows.Count / Me.grdData.PageSize) - 1
                Me.grdData.CurrentPageIndex = 0
            End If

            If Me.DataSetHasFields(Me.hdnSort.Value.Replace(" DESC", "")) Then
                dv.Sort = Me.hdnSort.Value
            End If

            '## Display Company Requirement Fields
            Dim CompReqFieldName, CompReqFieldValue As String
            Dim CompReqDataGridFieldIndex As Integer = 25

            For i As Integer = 0 To 5
                CompReqFieldName = "comp_id_" & Convert.ToString(i + 1) & "_desc"

                If Me.m_RideDataSet.Tables(0).Columns.Contains(CompReqFieldName) AndAlso _
                        Me.m_RideDataSet.Tables(0).Rows.Count > 0 Then

                    CompReqFieldValue = Convert.ToString(Me.m_RideDataSet.Tables(0).Rows(0).Item(CompReqFieldName)).Trim

                    If CompReqFieldValue.Length > 0 Then
                        Me.grdData.Columns(CompReqDataGridFieldIndex + i).HeaderText = CompReqFieldValue
                        Me.grdData.Columns(CompReqDataGridFieldIndex + i).Visible = True
                    Else
                        Me.grdData.Columns(CompReqDataGridFieldIndex + i).Visible = False
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
            '## END Display Company Requirement Fields

            Me.grdData.DataSource = dv
            Me.grdData.DataBind()

            Me.lblPageIndex.Text = Convert.ToString(Me.grdData.CurrentPageIndex + 1)
            Me.lblPageCount.Text = Convert.ToString(Me.grdData.PageCount)

        
            '# display total in last page  added by lily 01/04/2007
            If grdData.PageCount - grdData.CurrentPageIndex <= 1 Then
                grdData.ShowFooter = False      '## Do not display Total for now    (yang)
            Else
                grdData.ShowFooter = False
            End If
        End If
    End Sub

#End Region

#Region " Private Functions "

    Public Function GetDataSet() As Boolean
        Dim out As Boolean = False

        If Not ViewState("RideDataSet") Is Nothing AndAlso TypeOf (ViewState("RideDataSet")) Is DataSet Then
            Me.m_RideDataSet = CType(ViewState("RideDataSet"), DataSet)

            If Me.m_RideDataSet.Tables.Count > 0 Then
                out = True
            End If
        End If

        Return out
    End Function

    Private Function DataSetHasFields(ByVal fields As String) As Boolean
        Dim out As Boolean = False

        If fields.Trim.Length > 0 AndAlso Me.GetDataSet Then
            out = True

            Dim arrFields() As String = fields.Split(Char.Parse(","))

            For Each field As String In arrFields
                If Me.m_RideDataSet.Tables(0).Columns.Contains(field) = False Then
                    out = False
                    Exit For
                End If
            Next
        End If

        Return out
    End Function

    Private Sub ResetTotal()
        For i As Integer = 0 To 13
            Me.m_Total(i) = 0
        Next
    End Sub
#End Region

#Region " Data Grid Functions "

    Protected Sub grdData_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdData.PageIndexChanged
        Me.DataSetBind(e.NewPageIndex, "")
    End Sub

    Protected Sub grdData_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdData.SortCommand
        Me.DataSetBind(-1, e.SortExpression)
    End Sub

    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExport.Click
        If Me.GetDataSet() Then
            Me.grdData.AllowPaging = False
            Me.DataSetBind(-1, "")
            Business.Common.GenerateCSVFile(Me.Page, Me.grdData, "Report.csv")
        End If
    End Sub

    ''added by lily 01/04/2008
    Protected Sub grdData_ItemDataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdData.ItemDataBound

        'If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
        '    For i As Integer = 0 To Me.m_Total.Length - 1
        '        If Not e.Item.Cells(i + StartColumnIndex) Is Nothing AndAlso IsNumeric(e.Item.Cells(i + StartColumnIndex).Text) Then
        '            Me.m_Total(i) = Me.m_Total(i) + Convert.ToDouble(e.Item.Cells(i + StartColumnIndex).Text)
        '        End If
        '    Next
        'Else

        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then

            'Dim CCDate As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "cc_settle_comment")).Trim
            'Dim lblCCDate As Label = CType(e.Item.FindControl("lblCCDate"), Label)
            'lblCCDate.Text = ShowDateTime(CCDate, DateTimeStyle.DateOnlyInEn)

            '## 1/10/2008   User control id instead of cell index   (yang)
            Dim CCSettlementDate As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "export_cc_date_time")).Trim
            Dim lblCCSettlementDate As Label = CType(e.Item.FindControl("lblCCSettlementDate"), Label)
            lblCCSettlementDate.Text = ShowDateTime(CCSettlementDate, DateTimeStyle.DateAndTimeInEn)

            'e.Item.Cells(23).Text = ShowDateTime(e.Item.Cells(23).Text, DateTimeStyle.DateOnlyInEn)
            'e.Item.Cells(24).Text = ShowDateTime(e.Item.Cells(24).Text, DateTimeStyle.DateAndTimeInEn)

        ElseIf e.Item.ItemType = ListItemType.Footer Then

            Dim StartColumnIndex As Integer = 9
            GetValue(StartColumnIndex)

            e.Item.Cells(7).Text = "Total:"

            '## 1/8/2008    Modified by yang
            For i As Integer = 0 To Me.m_Total.Length - 2
                If Not e.Item.Cells(i + StartColumnIndex) Is Nothing Then
                    e.Item.Cells(i + StartColumnIndex).Text = ShowPrice(Me.m_Total(i), PricePrefix.null)
                End If



            Next

            'Modified by lily 01/09/2008
            If Not e.Item.Cells(Me.m_Total.Length - 1 + StartColumnIndex) Is Nothing Then
                e.Item.Cells(Me.m_Total.Length - 1 + StartColumnIndex).Text = ShowPrice(Me.m_Total(Me.m_Total.Length - 1), PricePrefix.dollar)
            End If

            'e.Item.Cells(9).Text = ShowPrice(baserate, PricePrefix.null)
            'e.Item.Cells(10).Text = ShowPrice(toll, PricePrefix.null)
            'e.Item.Cells(11).Text = ShowPrice(parking, PricePrefix.null)
            'e.Item.Cells(12).Text = ShowPrice(wait, PricePrefix.null)
            'e.Item.Cells(13).Text = ShowPrice(stops, PricePrefix.null)
            'e.Item.Cells(14).Text = ShowPrice(stop_wt, PricePrefix.null)
            'e.Item.Cells(15).Text = ShowPrice(package, PricePrefix.null)
            'e.Item.Cells(16).Text = ShowPrice(surcharge, PricePrefix.null)
            'e.Item.Cells(17).Text = ShowPrice(phone, PricePrefix.null)
            'e.Item.Cells(18).Text = ShowPrice(tips, PricePrefix.null)
            'e.Item.Cells(19).Text = ShowPrice(service_fee, PricePrefix.null)
            'e.Item.Cells(20).Text = ShowPrice(gross, PricePrefix.null)
            'e.Item.Cells(21).Text = ShowPrice(discount, PricePrefix.null)
            'e.Item.Cells(22).Text = ShowPrice(net, PricePrefix.null)
        End If

        'For j As Integer = 9 To 22
        '    For Each i As DataGridItem In grdData.Items
        '        sum = sum + i.Cells(j).Text
        '    Next
        'Next
    End Sub

    'get column value added by lily 01/07/2008
    Public Sub GetValue(ByVal StartColumnIndex As Integer)

        If Me.GetDataSet() Then

            For Each row As DataRow In Me.m_RideDataSet.Tables(0).Rows

                '## 1/8/2008    Modified by yang
                For i As Integer = 0 To Me.m_Total.Length - 1

                    Dim dgc As DataGridColumn = Me.grdData.Columns(StartColumnIndex + i)

                    If Not dgc Is Nothing AndAlso TypeOf (dgc) Is BoundColumn Then
                        Dim FieldName As String = CType(dgc, BoundColumn).DataField

                        If Not row(FieldName) Is Nothing AndAlso IsNumeric(Convert.ToString(row(FieldName))) Then
                            Me.m_Total(i) = Me.m_Total(i) + Convert.ToDouble(row(FieldName))
                        End If
                    End If
                Next

                'If Me.grdData.Columns(9).HeaderText.ToString = "RATE" And Not row("base_rate") Is Nothing And IsNumeric(Convert.ToString(row("base_rate"))) Then
                '    baserate = baserate + Convert.ToDouble(row("base_rate"))

                'End If
                'If Me.grdData.Columns(10).HeaderText.ToString = "TOLLS" And Not row("tolls") Is Nothing And IsNumeric(Convert.ToString(row("tolls"))) Then
                '    toll = toll + Convert.ToDouble(row("tolls"))

                'End If
                'If Me.grdData.Columns(11).HeaderText.ToString = "PARK" And Not row("parking") Is Nothing And IsNumeric(Convert.ToString(row("parking"))) Then
                '    parking = parking + Convert.ToDouble(row("parking"))

                'End If
                'If Me.grdData.Columns(12).HeaderText.ToString = "W.T." And Not row("wait_amount") Is Nothing And IsNumeric(Convert.ToString(row("wait_amount"))) Then
                '    wait = wait + Convert.ToDouble(row("wait_amount"))

                'End If
                'If Me.grdData.Columns(13).HeaderText.ToString = "STOPS" And Not row("stops_amt") Is Nothing And IsNumeric(Convert.ToString(row("stops_amt"))) Then
                '    stops = stops + Convert.ToDouble(row("stops_amt"))
                'End If

                'If Me.grdData.Columns(14).HeaderText.ToString = "STP/W.T." And Not row("stop_wt_amount") Is Nothing And IsNumeric(Convert.ToString(row("stop_wt_amount"))) Then
                '    stop_wt = stop_wt + Convert.ToDouble(row("stop_wt_amount"))

                'End If
                'If Me.grdData.Columns(15).HeaderText.ToString = "PACK" And Not row("package_amt") Is Nothing And IsNumeric(Convert.ToString(row("package_amt"))) Then
                '    package = package + Convert.ToDouble(row("package_amt"))

                'End If
                'If Me.grdData.Columns(16).HeaderText.ToString = "NYS SURCHARGE" And Not row("Surcharge") Is Nothing And IsNumeric(Convert.ToString(row("Surcharge"))) Then
                '    surcharge = surcharge + Convert.ToDouble(row("Surcharge"))

                'End If

                'If Me.grdData.Columns(17).HeaderText.ToString = "PHONE" And Not row("phone_amt") Is Nothing And IsNumeric(Convert.ToString(row("phone_amt"))) Then
                '    phone = phone + Convert.ToDouble(row("phone_amt"))

                'End If
                'If Me.grdData.Columns(18).HeaderText.ToString = "ADJ" And Not row("tips") Is Nothing And IsNumeric(Convert.ToString(row("tips"))) Then
                '    tips = tips + Convert.ToDouble(row("tips"))

                'End If
                'If Me.grdData.Columns(19).HeaderText.ToString = "SVR" And Not row("service_fee") Is Nothing And IsNumeric(Convert.ToString(row("service_fee"))) Then
                '    service_fee = service_fee + Convert.ToDouble(row("service_fee"))

                'End If
                'If Me.grdData.Columns(20).HeaderText.ToString = "GROSS" And Not row("Gross") Is Nothing And IsNumeric(Convert.ToString(row("Gross"))) Then
                '    gross = gross + Convert.ToDouble(row("Gross"))

                'End If
                'If Me.grdData.Columns(21).HeaderText.ToString = "DISC" And Not row("Discount") Is Nothing And IsNumeric(Convert.ToString(row("Discount"))) Then
                '    discount = discount + Convert.ToDouble(row("Discount"))

                'End If
                'If Me.grdData.Columns(22).HeaderText.ToString = "NET" And Not row("Net") Is Nothing And IsNumeric(Convert.ToString(row("Net"))) Then
                '    net = net + Convert.ToDouble(row("Net"))

                'End If
            Next

            'For Each row As DataRow In Me.m_RideDataSet.Tables(0).Rows
            'For row As Integer = 0 To Me.m_RideDataSet.Tables(0).Rows.Count - 1
            'For i As Integer = 0 To Me.m_Total.Length - 1

            '    If Not row(i + StartColumnIndex) Is Nothing AndAlso IsNumeric(Me.m_RideDataSet.Tables(0).Columns(i + StartColumnIndex).Table.Rows(row).ToString) Then

            '        Me.m_Total(i) = Me.m_Total(i) + Convert.ToDouble(Me.m_RideDataSet.Tables(0).Columns(i + StartColumnIndex).Table.Rows(row).ToString)

            '    End If

            'Next
            'Next
        End If
    End Sub

#End Region

End Class
