Imports System.Data
Imports System.Drawing.Graphics
Imports Business

'## 12/18/2007  disabled by yang
'Partial Class PassOfReport
'    Inherits System.Web.UI.Page

'    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
'        If Not Me.Page.IsPostBack Then
'            ViewState("sel_acct_id") = Trim(Request.QueryString("SelAcctId"))
'            Session("select_acct") = Trim(Request.QueryString("SelAcctId"))
'            ViewState("fromdate") = Trim(Request.QueryString("Fromdate"))
'            ViewState("todate") = Trim(Request.QueryString("Todate"))
'            'add by william 2007/07/13
'            Session("fromdate") = Trim(Request.QueryString("Fromdate"))
'            Session("todate") = Trim(Request.QueryString("Todate"))

'            ViewState("top") = Trim(Request.QueryString("Top"))
'            ViewState("daytype") = Trim(Request.QueryString("Daytype"))
'            ViewState("sortby") = Trim(Request.QueryString("Sortby"))

'            If Me.DataGrid_VoucherList.Attributes("SortExpression") = "" Then
'                If Not ViewState("sortby") Is Nothing Then
'                    If ViewState("sortby").ToString = "1" Then
'                        Me.DataGrid_VoucherList.Attributes("SortExpression") = "totalNet"
'                        Me.hdnSort.Value = "totalNet  DESC"
'                    ElseIf ViewState("sortby").ToString = "2" Then
'                        Me.DataGrid_VoucherList.Attributes("SortExpression") = "totalCount"
'                        Me.hdnSort.Value = "totalCount  DESC"
'                    End If
'                Else
'                    '--do nothing
'                    Me.DataGrid_VoucherList.Attributes("SortExpression") = "passenger_name"
'                    Me.hdnSort.Value = "passenger_name  DESC"
'                End If
'                'Me.DataGrid_VoucherList.Attributes("SortDirection") = "DESC"
'            End If
'            DataGrid_VoucherList.DataSource = GetDataSource()
'            DataGrid_VoucherList.DataBind()

'            Me.lbl_PageIndex.Text = DataGrid_VoucherList.CurrentPageIndex + 1
'            Me.lbl_PageAmount.Text = DataGrid_VoucherList.PageCount

'        End If

'    End Sub
'    Public Function GetDataSource() As DataView
'        Dim obj_DataSource As New Report
'        Dim dv As New DataView
'        Dim m_dataset As New DataSet
'        Dim m_DataTable As New DataTable
'        Dim level_id As String
'        Dim vip_no As String
'        Dim acct_id As String
'        Dim sub_acct_id As String
'        Dim sel_acct_id As String
'        Dim group_flag As String
'        Dim sel_vip_no As String
'        Dim strfromdate As String
'        Dim strtodate As String
'        Dim strTop As String
'        Dim strDaytype As String
'        Dim strSortby As String

'        strfromdate = Convert.ToString(ViewState("fromdate")).Trim()
'        strtodate = Convert.ToString(ViewState("todate")).Trim()
'        sel_vip_no = Convert.ToString(ViewState("SelVip")).Trim()
'        sel_acct_id = Convert.ToString(ViewState("SelAcct")).Trim()
'        strTop = Convert.ToString(ViewState("top")).Trim()
'        strDaytype = Convert.ToString(ViewState("daytype")).Trim()
'        strSortby = Convert.ToString(ViewState("sortby")).Trim()
'        If Not Session("acct_id") Is Nothing And Convert.ToString(Session("acct_id")).Trim() <> "" Then
'            acct_id = Convert.ToString(Session("acct_id")).Trim()
'        Else
'            acct_id = ""
'        End If
'        If Not Session("sub_acct_id") Is Nothing And Convert.ToString(Session("sub_acct_id")).Trim() <> "" Then
'            sub_acct_id = Convert.ToString(Session("sub_acct_id")).Trim()
'        Else
'            sub_acct_id = ""
'        End If

'        If Not Session("group_login_flag") Is Nothing And Convert.ToString(Session("group_login_flag")).Trim() <> "" Then
'            group_flag = Convert.ToString(Session("group_login_flag")).Trim()
'        Else
'            group_flag = "N"
'        End If
'        If Not Session("vip_no") Is Nothing And Convert.ToString(Session("vip_no")).Trim() <> "" Then
'            vip_no = Convert.ToString(Session("vip_no")).Trim()
'        Else
'            vip_no = "N"
'        End If
'        If Not Session("level_id") Is Nothing And Convert.ToString(Session("level_id")).Trim() <> "" Then
'            level_id = Convert.ToString(Session("level_id")).Trim()
'        Else
'            level_id = "N"
'        End If

'        Dim SortExpression As String
'        Dim SortDirection As String
'        SortExpression = Me.DataGrid_VoucherList.Attributes("SortExpression")
'        SortDirection = Me.DataGrid_VoucherList.Attributes("SortDirection")

'        '## 12/17/2007  disabled errors (yang)
'        'm_dataset = obj_DataSource.GetPassReport(acct_id, sub_acct_id, sel_acct_id, group_flag, strfromdate, strtodate, strTop, strDaytype, strSortby)
'        'If Not m_dataset Is Nothing Then
'        '    If m_dataset.Tables.Count > 0 Then
'        '        m_DataTable = m_dataset.Tables(0)

'        '        Session("m_datatable") = m_DataTable
'        '        obj_DataSource = Nothing
'        '        'If ViewState("SortExprValue") <> "" Then
'        '        '    m_DataTable.DefaultView.Sort = ViewState("SortExprValue")
'        '        'End If
'        '        If Me.hdnSort.Value.Length > 0 Then
'        '            m_DataTable.DefaultView.Sort = Me.hdnSort.Value.Trim
'        '        End If
'        '        'If SortExpression <> "" Then
'        '        '    m_DataTable.DefaultView.Sort = SortExpression & " " & SortDirection
'        '        'End If

'        '        If m_DataTable.Rows.Count = 0 Then
'        '            Dim strMessage As String = "<script language=""JavaScript"">alert('No Information Found!');" & _
'        '                                       "history.go(-1);</script>"
'        '            RegisterStartupScript("PopUpMessage", strMessage)

'        '        End If
'        '    End If
'        'End If

'        Return m_DataTable.DefaultView
'    End Function

'    Protected Sub DataGrid_VoucherList_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid_VoucherList.PageIndexChanged
'        Me.DataGrid_VoucherList.CurrentPageIndex = e.NewPageIndex
'        DataGrid_VoucherList.DataSource = GetDataSource()
'        DataGrid_VoucherList.DataBind()

'    End Sub
'    Protected Sub DataGrid_VoucherList_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles DataGrid_VoucherList.SortCommand
'        If Me.hdnSort.Value.Trim.Length = 0 Then
'            Me.hdnSort.Value = e.SortExpression
'        ElseIf Me.hdnSort.Value.Trim.CompareTo(e.SortExpression) = 0 Then
'            Me.hdnSort.Value = e.SortExpression & " DESC"
'        Else
'            Me.hdnSort.Value = e.SortExpression
'        End If

'        DataGrid_VoucherList.DataSource = GetDataSource()
'        DataGrid_VoucherList.DataBind()

'    End Sub

'    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
'        'Dim strLevelID As String = Trim(Session("level_id"))
'        'Dim strFileName As String = "PassengerReport"
'        'Dim obj_DataGrid As DataGrid = DataGrid_VoucherList

'        'If strLevelID = String.Empty Then
'        '    'ERROR: Session "Acct_ID" missing
'        '    'Response.Redirect("Login.aspx?LogOff=1")
'        '    Exit Sub
'        'End If

'        'If obj_DataGrid Is Nothing Then
'        '    'ERROR: Session "ojb_DataGrid"
'        '    Exit Sub
'        'End If

'        'Response.Clear()
'        'Response.Buffer = True
'        'Response.Charset = "utf-8"
'        'Response.AppendHeader("Content-Disposition", "attachment;filename=" & strFileName & ".xls")
'        'Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8")
'        'Response.ContentType = "application/ms-excel"

'        'obj_DataGrid.EnableViewState = False

'        'obj_DataGrid.AllowPaging = False
'        'obj_DataGrid.DataBind()

'        'Dim strTmp As String

'        'Dim obj_Col As DataGridColumn
'        'For Each obj_Col In obj_DataGrid.Columns
'        '    Response.Write(Adjust(obj_Col.HeaderText) & vbTab)
'        'Next
'        'Response.Write(vbCrLf)

'        'Dim obj_Row As DataGridItem
'        'Dim obj_Cell As TableCell
'        'For Each obj_Row In obj_DataGrid.Items
'        '    For Each obj_Cell In obj_Row.Cells
'        '        Dim obj_Ctrl As Control
'        '        For Each obj_Ctrl In obj_Cell.Controls
'        '            If obj_Ctrl.GetType Is GetType(HyperLink) Then
'        '                Dim obj_hplnk As HyperLink
'        '                obj_hplnk = CType(obj_Ctrl, HyperLink)
'        '                Response.Write(Adjust(obj_hplnk.Text))
'        '            ElseIf obj_Ctrl.GetType Is GetType(Label) Then
'        '                Dim obj_Label As Label
'        '                obj_Label = CType(obj_Ctrl, Label)
'        '                Response.Write(Adjust(obj_Label.Text))
'        '            End If
'        '        Next
'        '        Response.Write(Adjust(obj_Cell.Text) & vbTab)
'        '    Next
'        '    Response.Write(vbCrLf)
'        'Next

'        'For Each obj_Col In obj_DataGrid.Columns
'        '    Response.Write(Adjust(obj_Col.FooterText) & vbTab)
'        'Next
'        'Response.Write(vbCrLf)

'        'Response.End()

'        Me.DataGrid_VoucherList.DataSource = Nothing
'        Me.DataGrid_VoucherList.DataBind()

'        Me.DataGrid_VoucherList.DataSource = GetDataSource()
'        Me.DataGrid_VoucherList.AllowPaging = False
'        Me.DataGrid_VoucherList.DataBind()
'        Dim obj_DataGrid As DataGrid = DataGrid_VoucherList

'        'Call Me.ConvertExcel(Me.DataGrid_InvoiceList.DataSource, Response)

'        'Call GenerateFile(Me, Me.DataGrid_InvoiceList, "InvoiceInquiryReport.csv")
'        '--modify by daniel for new request 13/04/2007
'        If obj_DataGrid Is Nothing Then
'            'ERROR: Session "ojb_DataGrid"
'            Exit Sub
'        End If

'        Response.Clear()
'        Response.Buffer = True
'        Response.Charset = "utf-8"
'        'Response.AppendHeader("Content-Disposition", "attachment;filename=" & strFileName & ".xls")
'        Response.AppendHeader("Content-Disposition", "attachment;filename=InvoiceInquiryReport.xls")
'        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8")
'        Response.ContentType = "application/ms-excel"

'        DataGrid_VoucherList.EnableViewState = False
'        DataGrid_VoucherList.AllowPaging = False
'        DataGrid_VoucherList.DataBind()

'        Dim obj_Col As DataGridColumn
'        For Each obj_Col In obj_DataGrid.Columns
'            Response.Write(Adjust(obj_Col.HeaderText) & vbTab)
'        Next
'        Response.Write(vbCrLf)

'        Dim obj_Row As DataGridItem
'        Dim obj_Cell As TableCell
'        For Each obj_Row In obj_DataGrid.Items
'            For Each obj_Cell In obj_Row.Cells
'                Dim obj_Ctrl As Control
'                For Each obj_Ctrl In obj_Cell.Controls
'                    If obj_Ctrl.GetType Is GetType(HyperLink) Then
'                        Dim obj_hplnk As HyperLink
'                        obj_hplnk = CType(obj_Ctrl, HyperLink)
'                        Response.Write(Adjust(obj_hplnk.Text))
'                    ElseIf obj_Ctrl.GetType Is GetType(Label) Then
'                        Dim obj_Label As Label
'                        obj_Label = CType(obj_Ctrl, Label)
'                        Response.Write(Adjust(obj_Label.Text))
'                    End If
'                Next
'                Response.Write(Adjust(obj_Cell.Text) & vbTab)
'            Next
'            Response.Write(vbCrLf)
'        Next

'        For Each obj_Col In obj_DataGrid.Columns
'            Response.Write(Adjust(obj_Col.FooterText) & vbTab)
'        Next
'        Response.Write(vbCrLf)
'        Response.End()
'    End Sub
'    Public Function Adjust(ByVal strText As String) As String
'        Dim strTmp As String
'        strTmp = strText.Trim
'        strTmp = Replace(strTmp, "'", "''")
'        strTmp = Replace(strTmp, "&nbsp;", " ")
'        Return strTmp
'    End Function

'End Class
