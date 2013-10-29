Imports System.Data
Imports System.Drawing.Graphics
Imports Business

Partial Class InvoiceInquiryReport2
    Inherits System.Web.UI.Page

    Private grdDV As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then

            If Not Request.QueryString("InvoiceNo") Is Nothing Then
                Me.lblInvoiceNo.Text = Request.QueryString("invoiceno").Trim
            End If

            If Not Request.QueryString("InvoiceDate") Is Nothing Then
                Me.lblInvoiceDate.Text = Request.QueryString("invoicedate").Trim
            End If

            'ViewState("InvoiceNo") = strInvoiceNo
            'ViewState("InvoiceDate") = strInvoiceDate
            'ViewState("SelectAcctId") = Convert.ToString(Session("strSelectAcct")).Trim()
            ''    'Me.lbl_TabCap.Text = Me.lbl_TabCap.Text & "<font color='darkblue'>INVOICE # " & strInvoiceNo
            ''    'Me.lbl_TabCap.Text = Me.lbl_TabCap.Text & "</font>"
            ''    'If Not Session("strSelectAcct") Is Nothing And Convert.ToString(Session("strSelectAcct")).Trim() <> "" Then
            ''    '    Me.lbl_invoice.Text = "Invoice Date: <font color='green'>" & strInvoiceDate & "</font> Invoice #:<font color='green'>" & strInvoiceNo & "</font> Account:<font color='green'>" & Convert.ToString(Session("strSelectAcct")).Trim() & "</font>"
            ''    'Else
            ''    '    Me.lbl_invoice.Text = "Invoice Date: <font color='green'>" & strInvoiceDate & "</font> Invoice #:<font color='green'>" & strInvoiceNo & "</font> Account:<font color='green'>" & Convert.ToString(Session("Acct_id")).Trim() & "</font>"
            ''    'End If
        End If

        'If Me.DataGrid_VoucherList.Attributes("SortExpression") = "" Then
        '    Me.DataGrid_VoucherList.Attributes("SortExpression") = "Invoice_No"
        '    Me.DataGrid_VoucherList.Attributes("SortDirection") = "asc"
        'End If

        Call Me.LoadData()

        'DataGrid_VoucherList.DataSource = GetDataSource()
        'DataGrid_VoucherList.DataBind()

        'Me.lbl_PageIndex.Text = DataGrid_VoucherList.CurrentPageIndex + 1
        'Me.lbl_PageAmount.Text = DataGrid_VoucherList.PageCount
    End Sub

    Public Sub LoadData()
        Using rpt As New Report
            Dim ds As DataSet = rpt.GetInvoiceReport2(Me.lblInvoiceNo.Text, Me.lblInvoiceDate.Text, MySession.AcctID, MySession.SubAcctID, MySession.UserID)

            Me.VoucherList1.DataSetSource = ds
            Me.VoucherList1.DataSetBind(-1, "")
        End Using

        'With Me.grdData
        '    .DataSource = GetDataSource()

        '    If IsNumeric(ViewState("iPage")) Then
        '        .CurrentPageIndex = CInt(ViewState("iPage"))
        '    Else
        '        .CurrentPageIndex = 0
        '    End If

        '    .DataBind()
        'End With

        'Me.lbl_PageIndex.Text = Me.grdData.CurrentPageIndex + 1
        'Me.lbl_PageAmount.Text = Me.grdData.PageCount

    End Sub

    'Public Function GetDataSource() As DataView


    '    Dim obj_DataSource As New Report
    '    Dim dv As New DataView
    '    Dim m_dataset As New DataSet
    '    Dim m_DataTable As New DataTable
    '    Dim m_DataTable2 As New DataTable

    '    'Dim m_DataTable1 As New DataTable
    '    Dim strAcct_ID As String = Trim(Session("acct_id"))
    '    Dim strSub_acct_id As String = Trim(Session("sub_acct_id"))

    '    Dim strInvoiceNo As String = Me.lblInvoiceNo.Text
    '    Dim strInvoiceDate As String = Me.lblInvoiceDate.Text
    '    Dim strSelectAcct As String = MySession.AcctID

    '    Dim strGroupFlag As String

    '    If Session("group_login_flag") Is Nothing Then
    '        strGroupFlag = "N"
    '    ElseIf Convert.ToString(Session("group_login_flag")).Trim() = "" Then
    '        strGroupFlag = "N"
    '    Else
    '        strGroupFlag = Convert.ToString(Session("group_login_flag")).Trim()
    '    End If

    '    Dim SortExpression As String
    '    Dim SortDirection As String
    '    SortExpression = Me.grdData.Attributes("SortExpression")
    '    SortDirection = Me.grdData.Attributes("SortDirection")

    '    'added by lily 12/17/2007
    '    If MySession.LevelID = 1 Then
    '        m_dataset = obj_DataSource.GetInvoiceReport2(strInvoiceNo, strInvoiceDate, strGroupFlag, strAcct_ID, strSub_acct_id, strSelectAcct)
    '    Else
    '        m_dataset = obj_DataSource.GetInvoiceReport2byVIP(MySession.UserID, strInvoiceNo, strInvoiceDate, strGroupFlag, strAcct_ID, strSub_acct_id, strSelectAcct)
    '    End If

    '    If Not m_dataset Is Nothing Then
    '        If m_dataset.Tables.Count > 0 Then
    '            m_DataTable = m_dataset.Tables(0)
    '            Me.grdDV = m_DataTable.DefaultView
    '            m_DataTable2 = m_dataset.Tables(1)
    '            ' m_datatable1 = m_dataset.Tables(1)
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

    '            'Session("m_datatable") = m_DataTable
    '            'Session("m_datetable1") = m_datatable1

    '            obj_DataSource = Nothing
    '            'If ViewState("SortExprValue") <> "" Then
    '            '    m_DataTable.DefaultView.Sort = ViewState("SortExprValue")
    '            'End If

    '            If SortExpression <> "" AndAlso m_DataTable.Columns.Contains(SortExpression.Replace(" DESC", "")) Then
    '                m_DataTable.DefaultView.Sort = SortExpression & " " & SortDirection
    '            End If

    '            If m_DataTable.Rows.Count = 0 Then
    '                Dim strMessage As String = "<script language=""JavaScript"">alert('No Information Found!');</script>"
    '                RegisterStartupScript("PopUpMessage", strMessage)
    '            End If

    '        End If
    '    End If

    '    Return m_DataTable.DefaultView
    'End Function

    'Protected Sub DataGrid_VoucherList_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdData.ItemDataBound
    '    If e.Item.ItemType = ListItemType.Header Then
    '        If Not Session("strfield1name") Is Nothing And Convert.ToString(Session("strfield1name")).Trim() <> "" Then
    '            e.Item.Cells(22).Text = Convert.ToString(Session("strfield1name")).Trim()
    '        Else
    '            grdData.Columns(22).Visible = False
    '        End If
    '        If Not Session("strfield2name") Is Nothing And Convert.ToString(Session("strfield2name")).Trim() <> "" Then
    '            e.Item.Cells(23).Text = Convert.ToString(Session("strfield2name")).Trim()
    '        Else
    '            grdData.Columns(23).Visible = False
    '        End If
    '        If Not Session("strfield3name") Is Nothing And Convert.ToString(Session("strfield3name")).Trim() <> "" Then
    '            e.Item.Cells(24).Text = Convert.ToString(Session("strfield3name")).Trim()
    '        Else
    '            grdData.Columns(24).Visible = False
    '        End If
    '        If Not Session("strfield4name") Is Nothing And Convert.ToString(Session("strfield4name")).Trim() <> "" Then
    '            e.Item.Cells(25).Text = Convert.ToString(Session("strfield4name")).Trim()
    '        Else
    '            grdData.Columns(25).Visible = False
    '        End If
    '        If Not Session("strfield5name") Is Nothing And Convert.ToString(Session("strfield5name")).Trim() <> "" Then
    '            e.Item.Cells(26).Text = Convert.ToString(Session("strfield5name")).Trim()
    '        Else
    '            grdData.Columns(26).Visible = False
    '        End If
    '        If Not Session("strfield6name") Is Nothing And Convert.ToString(Session("strfield6name")).Trim() <> "" Then
    '            e.Item.Cells(27).Text = Convert.ToString(Session("strfield6name")).Trim()
    '        Else
    '            grdData.Columns(27).Visible = False
    '        End If
    '        'Dim m_DataTable As New DataTable
    '        'm_DataTable = Session("m_datatable")
    '        'e.Item.Cells(8).Text = "Total:"

    '        'If IsDBNull(m_DataTable.Rows(0).Item("srate")) Then
    '        '    e.Item.Cells(10).Text = ""
    '        'Else
    '        '    e.Item.Cells(10).Text = m_DataTable.Rows(0).Item("srate")
    '        'End If
    '        'If IsDBNull(m_DataTable.Rows(0).Item("stoll")) Then
    '        '    e.Item.Cells(11).Text = ""
    '        'Else
    '        '    e.Item.Cells(11).Text = m_DataTable.Rows(0).Item("stoll")
    '        'End If
    '        'If IsDBNull(m_DataTable.Rows(0).Item("srate")) Then
    '        '    e.Item.Cells(10).Text = ""
    '        'Else
    '        '    e.Item.Cells(10).Text = m_DataTable.Rows(0).Item("sparking")
    '        'End If
    '        'If IsDBNull(m_DataTable.Rows(0).Item("stoll")) Then
    '        '    e.Item.Cells(11).Text = ""
    '        'Else
    '        '    e.Item.Cells(11).Text = m_DataTable.Rows(0).Item("swait")
    '        'End If

    '        'If IsDBNull(m_DataTable.Rows(0).Item("srate")) Then
    '        '    e.Item.Cells(10).Text = ""
    '        'Else
    '        '    e.Item.Cells(10).Text = m_DataTable.Rows(0).Item("srate")
    '        'End If
    '        'If IsDBNull(m_DataTable.Rows(0).Item("sstops")) Then
    '        '    e.Item.Cells(11).Text = ""
    '        'Else
    '        '    e.Item.Cells(11).Text = m_DataTable.Rows(0).Item("sstopwt")
    '        'End If
    '    End If
    'End Sub

    ''Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
    ''    Dim strLevelID As String = Trim(Session("level_id"))
    ''    Dim strFileName As String = "InvoiceInquiryReport"
    ''    Dim obj_DataGrid As DataGrid = DataGrid_VoucherList

    ''    If strLevelID = String.Empty Then
    ''        'ERROR: Session "Acct_ID" missing
    ''        'Response.Redirect("Login.aspx?LogOff=1")
    ''        Exit Sub
    ''    End If

    ''    If obj_DataGrid Is Nothing Then
    ''        'ERROR: Session "ojb_DataGrid"
    ''        Exit Sub
    ''    End If

    ''    Response.Clear()
    ''    Response.Buffer = True
    ''    Response.Charset = "utf-8"
    ''    Response.AppendHeader("Content-Disposition", "attachment;filename=" & strFileName & ".xls")
    ''    Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8")
    ''    Response.ContentType = "application/ms-excel"

    ''    obj_DataGrid.EnableViewState = False

    ''    obj_DataGrid.AllowPaging = False
    ''    obj_DataGrid.DataBind()

    ''    Dim strTmp As String

    ''    Dim obj_Col As DataGridColumn
    ''    For Each obj_Col In obj_DataGrid.Columns
    ''        Response.Write(Adjust(obj_Col.HeaderText) & vbTab)
    ''    Next
    ''    Response.Write(vbCrLf)

    ''    Dim obj_Row As DataGridItem
    ''    Dim obj_Cell As TableCell
    ''    For Each obj_Row In obj_DataGrid.Items
    ''        For Each obj_Cell In obj_Row.Cells
    ''            Dim obj_Ctrl As Control
    ''            For Each obj_Ctrl In obj_Cell.Controls
    ''                If obj_Ctrl.GetType Is GetType(HyperLink) Then
    ''                    Dim obj_hplnk As HyperLink
    ''                    obj_hplnk = CType(obj_Ctrl, HyperLink)
    ''                    Response.Write(Adjust(obj_hplnk.Text))
    ''                ElseIf obj_Ctrl.GetType Is GetType(Label) Then
    ''                    Dim obj_Label As Label
    ''                    obj_Label = CType(obj_Ctrl, Label)
    ''                    Response.Write(Adjust(obj_Label.Text))
    ''                End If
    ''            Next
    ''            Response.Write(Adjust(obj_Cell.Text) & vbTab)
    ''        Next
    ''        Response.Write(vbCrLf)
    ''    Next

    ''    For Each obj_Col In obj_DataGrid.Columns
    ''        Response.Write(Adjust(obj_Col.FooterText) & vbTab)
    ''    Next
    ''    Response.Write(vbCrLf)

    ''    Response.End()
    ''    Me.DataGrid_VoucherList.AllowPaging = False
    ''    Me.DataGrid_VoucherList.DataSource = Me.GetDataSource
    ''    Me.DataGrid_VoucherList.DataBind()
    ''    Common.GenerateCSVFile(Me, Me.DataGrid_VoucherList, "invoice_inquiry.csv")

    ''End Sub

    ''Public Function Adjust(ByVal strText As String) As String
    ''    Dim strTmp As String
    ''    strTmp = strText.Trim
    ''    strTmp = Replace(strTmp, "'", "''")
    ''    strTmp = Replace(strTmp, "&nbsp;", " ")
    ''    Return strTmp
    ''End Function

    'Protected Sub DataGrid_VoucherList_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdData.PageIndexChanged
    '    ViewState("iPage") = e.NewPageIndex
    '    Load_Default()
    'End Sub

    'Protected Sub DataGrid_VoucherList_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdData.SortCommand
    '    Call Me.Load_Default()

    '    If e.SortExpression = "Invoice_No" Or e.SortExpression = "confirmation_no" Then
    '        Me.grdData.Attributes("SortExpression") = e.SortExpression & " DESC"
    '        Me.grdDV.Sort = e.SortExpression & " DESC"
    '    Else
    '        Me.grdData.Attributes("SortExpression") = e.SortExpression
    '        Me.grdDV.Sort = e.SortExpression
    '    End If

    '    Me.grdData.DataBind()
    'End Sub

    'Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExport.Click
    '    Me.grdData.AllowPaging = False
    '    Me.Load_Default()
    '    Common.GenerateCSVFile(Me, Me.grdData, "invoice_inquiry.csv")
    'End Sub

End Class
