Imports System.Data
Imports System.Drawing.Graphics
Imports Business
Partial Class DriveOfReport2
    Inherits System.Web.UI.Page
    Private grdDV As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            If Not Request.QueryString("carno") Is Nothing Then
                Me.hdnCarNo.Value = Request.QueryString("carno").Trim
            End If

            If Not Request.QueryString("datetype") Is Nothing Then
                Me.hdnDateType.Value = Request.QueryString("datetype").Trim
            End If

            If Not Request.QueryString("fromdate") Is Nothing Then
                Me.hdnFromDate.Value = Request.QueryString("fromdate").Trim
            End If

            If Not Request.QueryString("todate") Is Nothing Then
                Me.hdnToDate.Value = Request.QueryString("todate").Trim
            End If

            If IsDate(Me.hdnFromDate.Value) AndAlso IsDate(Me.hdnToDate.Value) Then
                Me.lblTitle.Text = String.Format("From {0} Date: {1}&nbsp;&nbsp;&nbsp;&nbsp;To {0} Date: {2}&nbsp;&nbsp;&nbsp;&nbsp;Car No: {3}", IIf(Me.hdnDateType.Value = "t", "Trip", "Invoice"), Me.hdnFromDate.Value, Me.hdnToDate.Value, Me.hdnCarNo.Value)
            End If

            Using rpt As New Report
                Dim ds As DataSet = rpt.GetDriveReport2(MySession.AcctID, MySession.SubAcctID, Me.hdnCarNo.Value, Me.hdnDateType.Value, Me.hdnFromDate.Value, Me.hdnToDate.Value)

                Me.VoucherList1.DataSetSource = ds
                Me.VoucherList1.DataSetBind(-1, "")
            End Using
        End If

    End Sub

    'Public Function GetDataSource() As DataView

    '    Dim obj_DataSource As New Report
    '    Dim dv As New DataView
    '    Dim m_dataset As New DataSet
    '    Dim m_DataTable As New DataTable
    '    Dim m_DataTable2 As New DataTable
    '    Dim strAcct_ID As String = Trim(Session("Acct_ID"))
    '    Dim strSub_acct_id As String = Trim(Session("sub_acct_id"))
    '    Dim strInvoiceNo As String = Convert.ToString(ViewState("InvoiceNo")).Trim()
    '    Dim strInvoiceDate As String = Convert.ToString(ViewState("InvoiceDate")).Trim()
    '    Dim strSelectAcct As String = Convert.ToString(Session("select_acct")).Trim()
    '    Dim strGroupFlag As String
    '    Dim strCarno As String

    '    strCarno = Me.hdnVipNo.Value
    '    If Session("group_login_flag") Is Nothing Then
    '        strGroupFlag = "N"
    '    ElseIf Convert.ToString(Session("group_login_flag")).Trim() = "" Then
    '        strGroupFlag = "N"
    '    Else
    '        strGroupFlag = Convert.ToString(Session("group_login_flag")).Trim()
    '    End If

    '    'Dim SortExpression As String
    '    'Dim SortDirection As String
    '    'SortExpression = Me.DataGrid_VoucherList.Attributes("SortExpression")
    '    'SortDirection = Me.DataGrid_VoucherList.Attributes("SortDirection")
    '    m_dataset = obj_DataSource.GetDriveReport2(strAcct_ID, strSub_acct_id, strSelectAcct, strGroupFlag, strCarno, Me.hdnDateType.Value, Me.hdnFromDate.Value, Me.hdnToDate.Value)

    '    If Not m_dataset Is Nothing Then
    '        If m_dataset.Tables.Count > 0 Then
    '            m_DataTable = m_dataset.Tables(0)
    '            m_DataTable2 = m_dataset.Tables(1)
    '            Me.tbGrid.Visible = True
    '            If m_DataTable2.Rows.Count > 0 Then
    '                Dim n As Integer
    '                For n = 0 To m_DataTable2.Rows.Count - 1
    '                    If IsDBNull(m_DataTable2.Rows(n).Item("req_desc")) Then
    '                        Session("strfield" & n + 1 & "name") = ""
    '                    ElseIf m_DataTable2.Rows(n).Item("req_desc").ToString.Trim() = "" Then
    '                        Session("strfield" & n + 1 & "name") = ""
    '                    Else
    '                        Session("strfield" & n + 1 & "name") = m_DataTable2.Rows(n).Item("req_desc")
    '                    End If
    '                Next

    '            Else
    '                Session("strfield1name") = ""
    '                Session("strfield2name") = ""
    '                Session("strfield3name") = ""
    '                Session("strfield4name") = ""
    '                Session("strfield5name") = ""
    '                Session("strfield6name") = ""
    '            End If
    '            Me.grdDV = m_DataTable.DefaultView
    '            Session("m_datatable") = m_DataTable
    '            obj_DataSource = Nothing
    '            'If ViewState("SortExprValue") <> "" Then
    '            '    m_DataTable.DefaultView.Sort = ViewState("SortExprValue")
    '            'End If
    '            'If SortExpression <> "" Then
    '            '    m_DataTable.DefaultView.Sort = SortExpression & " " & SortDirection
    '            'End If

    '            If m_DataTable.Rows.Count = 0 Then
    '                Dim strMessage As String = "<script language=""JavaScript"">alert('No Information Found!');" & _
    '                                           "history.go(-1);</script>"
    '                ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage", strMessage)

    '            End If

    '            If IsDate(Me.hdnFromDate.Value) AndAlso IsDate(Me.hdnToDate.Value) Then
    '                Me.lblTitle.Text = String.Format("From {0} Date: {1}&nbsp;&nbsp;&nbsp;&nbsp;To {0} Date: {2}&nbsp;&nbsp;&nbsp;&nbsp;Car No: {3}", IIf(Me.hdnDateType.Value = "t", "Trip", "Invoice"), Me.hdnFromDate.Value, Me.hdnToDate.Value, Me.hdnVipNo.Value)
    '            End If
    '        Else
    '            Me.tbGrid.Visible = False
    '        End If
    '    End If

    '    Return m_DataTable.DefaultView
    'End Function

    'Protected Sub DataGrid_VoucherList_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid_VoucherList.ItemDataBound
    '    If e.Item.ItemType = ListItemType.Header Then
    '        If Not Session("strfield1name") Is Nothing And Convert.ToString(Session("strfield1name")).Trim() <> "" Then
    '            e.Item.Cells(24).Text = Convert.ToString(Session("strfield1name")).Trim()
    '        Else
    '            DataGrid_VoucherList.Columns(24).Visible = False
    '        End If
    '        If Not Session("strfield2name") Is Nothing And Convert.ToString(Session("strfield2name")).Trim() <> "" Then
    '            e.Item.Cells(25).Text = Convert.ToString(Session("strfield2name")).Trim()
    '        Else
    '            DataGrid_VoucherList.Columns(25).Visible = False
    '        End If
    '        If Not Session("strfield3name") Is Nothing And Convert.ToString(Session("strfield3name")).Trim() <> "" Then
    '            e.Item.Cells(26).Text = Convert.ToString(Session("strfield3name")).Trim()
    '        Else
    '            DataGrid_VoucherList.Columns(26).Visible = False
    '        End If
    '        If Not Session("strfield4name") Is Nothing And Convert.ToString(Session("strfield4name")).Trim() <> "" Then
    '            e.Item.Cells(27).Text = Convert.ToString(Session("strfield4name")).Trim()
    '        Else
    '            DataGrid_VoucherList.Columns(27).Visible = False
    '        End If
    '        If Not Session("strfield5name") Is Nothing And Convert.ToString(Session("strfield5name")).Trim() <> "" Then
    '            e.Item.Cells(28).Text = Convert.ToString(Session("strfield5name")).Trim()
    '        Else
    '            DataGrid_VoucherList.Columns(28).Visible = False
    '        End If
    '        If Not Session("strfield6name") Is Nothing And Convert.ToString(Session("strfield6name")).Trim() <> "" Then
    '            e.Item.Cells(29).Text = Convert.ToString(Session("strfield6name")).Trim()
    '        Else
    '            DataGrid_VoucherList.Columns(29).Visible = False
    '        End If
    '    End If
    'End Sub

    'Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExcel.Click

    '    Dim strFileName As String = "DriveOfReport.csv"
    '    Me.DataGrid_VoucherList.AllowPaging = False
    '    DataGrid_VoucherList.DataSource = GetDataSource()
    '    DataGrid_VoucherList.DataBind()
    '    Common.GenerateCSVFile(Me, Me.DataGrid_VoucherList, strFileName)
    '    'Dim obj_DataGrid As DataGrid = DataGrid_VoucherList

    '    'If strLevelID = String.Empty Then
    '    '    Exit Sub
    '    'End If

    '    'If obj_DataGrid Is Nothing Then
    '    '    Exit Sub
    '    'End If

    '    'Response.Clear()
    '    'Response.Buffer = True
    '    'Response.Charset = "utf-8"
    '    'Response.AppendHeader("Content-Disposition", "attachment;filename=" & strFileName & ".xls")
    '    'Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8")
    '    'Response.ContentType = "application/ms-excel"

    '    'obj_DataGrid.EnableViewState = False

    '    'obj_DataGrid.AllowPaging = False
    '    'obj_DataGrid.DataBind()

    '    'Dim strTmp As String

    '    'Dim obj_Col As DataGridColumn
    '    'For Each obj_Col In obj_DataGrid.Columns
    '    '    Response.Write(Adjust(obj_Col.HeaderText) & vbTab)
    '    'Next
    '    'Response.Write(vbCrLf)

    '    'Dim obj_Row As DataGridItem
    '    'Dim obj_Cell As TableCell
    '    'For Each obj_Row In obj_DataGrid.Items
    '    '    For Each obj_Cell In obj_Row.Cells
    '    '        Dim obj_Ctrl As Control
    '    '        For Each obj_Ctrl In obj_Cell.Controls
    '    '            If obj_Ctrl.GetType Is GetType(HyperLink) Then
    '    '                Dim obj_hplnk As HyperLink
    '    '                obj_hplnk = CType(obj_Ctrl, HyperLink)
    '    '                Response.Write(Adjust(obj_hplnk.Text))
    '    '            ElseIf obj_Ctrl.GetType Is GetType(Label) Then
    '    '                Dim obj_Label As Label
    '    '                obj_Label = CType(obj_Ctrl, Label)
    '    '                Response.Write(Adjust(obj_Label.Text))
    '    '            End If
    '    '        Next
    '    '        Response.Write(Adjust(obj_Cell.Text) & vbTab)
    '    '    Next
    '    '    Response.Write(vbCrLf)
    '    'Next

    '    'For Each obj_Col In obj_DataGrid.Columns
    '    '    Response.Write(Adjust(obj_Col.FooterText) & vbTab)
    '    'Next
    '    'Response.Write(vbCrLf)

    '    'Response.End()
    'End Sub

    ''Public Function Adjust(ByVal strText As String) As String
    ''    Dim strTmp As String
    ''    strTmp = strText.Trim
    ''    strTmp = Replace(strTmp, "'", "''")
    ''    strTmp = Replace(strTmp, "&nbsp;", " ")
    ''    Return strTmp
    ''End Function

    'Protected Sub DataGrid_VoucherList_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid_VoucherList.PageIndexChanged
    '    Try
    '        Me.DataGrid_VoucherList.CurrentPageIndex = e.NewPageIndex
    '        Me.DataGrid_VoucherList.DataSource = Me.GetDataSource
    '        If Me.grdDV.Table.Columns.Contains(Me.hdnSort.Value.Replace(" DESC", "")) Then
    '            Me.grdDV.Sort = Me.hdnSort.Value
    '        End If
    '        Me.DataGrid_VoucherList.DataBind()

    '        Me.lbl_PageIndex.Text = DataGrid_VoucherList.CurrentPageIndex + 1
    '        Me.lbl_PageAmount.Text = DataGrid_VoucherList.PageCount
    '    Catch
    '    End Try
    'End Sub

    'Protected Sub DataGrid_VoucherList_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles DataGrid_VoucherList.SortCommand
    '    DataGrid_VoucherList.DataSource = GetDataSource()
    '    DataGrid_VoucherList.DataBind()
    '    If Me.hdnSort.Value = e.SortExpression Then
    '        Me.hdnSort.Value = e.SortExpression & " DESC"
    '    Else
    '        Me.hdnSort.Value = e.SortExpression
    '    End If
    '    If Me.grdDV.Table.Columns.Contains(Me.hdnSort.Value.Replace(" DESC", "")) Then
    '        Me.grdDV.Sort = Me.hdnSort.Value
    '    End If
    '    Me.DataGrid_VoucherList.DataBind()
    'End Sub

End Class
