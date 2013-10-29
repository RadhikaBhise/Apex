Imports System.Data
Imports System.Drawing.Graphics
Imports Business
Partial Class ElementOfReport
    Inherits System.Web.UI.Page
    Private grdDV As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ViewState("sel_acct_id") = Trim(Request.QueryString("SelAcctId"))
            ViewState("fromdate") = Trim(Request.QueryString("Fromdate"))
            ViewState("todate") = Trim(Request.QueryString("Todate"))
            ViewState("Element") = Trim(Request.QueryString("Element"))
            ViewState("Daytype") = Trim(Request.QueryString("Daytype"))
            ViewState("RideTotal") = Trim(Request.QueryString("RideTotal"))

        End If
        If Me.DataGrid_VoucherList.Attributes("SortExpression") = "" Then
            Me.DataGrid_VoucherList.Attributes("SortExpression") = "Invoice_No"
            Me.DataGrid_VoucherList.Attributes("SortDirection") = "asc"
        End If
        DataGrid_VoucherList.DataSource = GetDataSource()
        DataGrid_VoucherList.DataBind()

        Me.lbl_PageIndex.Text = DataGrid_VoucherList.CurrentPageIndex + 1
        Me.lbl_PageAmount.Text = DataGrid_VoucherList.PageCount
    End Sub
    Public Function GetDataSource() As DataView
        Dim obj_DataSource As New Report
        Dim dv As New DataView
        Dim m_dataset As New DataSet
        Dim m_DataTable As New DataTable
        Dim m_DataTable2 As New DataTable
        Dim level_id As String
        Dim vip_no As String
        Dim acct_id As String
        Dim sub_acct_id As String
        Dim sel_acct_id As String
        Dim group_flag As String
        Dim sel_vip_no As String
        Dim strfromdate As String
        Dim strtodate As String
        Dim strElement As String
        Dim strRidetotal As String
        Dim strDaytype As String


        strfromdate = Convert.ToString(ViewState("fromdate")).Trim()
        strtodate = Convert.ToString(ViewState("todate")).Trim()
        sel_vip_no = Convert.ToString(ViewState("SelVip")).Trim()
        sel_acct_id = Convert.ToString(ViewState("sel_acct_id")).Trim()
        strElement = Convert.ToString(ViewState("Element")).Trim()
        strRidetotal = Convert.ToString(ViewState("RideTotal")).Trim()
        strDaytype = Convert.ToString(ViewState("Daytype")).Trim()
        If Not Session("acct_id") Is Nothing And Convert.ToString(Session("acct_id")).Trim() <> "" Then
            acct_id = Convert.ToString(Session("acct_id")).Trim()
        Else
            acct_id = ""
        End If
        If Not Session("sub_acct_id") Is Nothing And Convert.ToString(Session("sub_acct_id")).Trim() <> "" Then
            sub_acct_id = Convert.ToString(Session("sub_acct_id")).Trim()
        Else
            sub_acct_id = ""
        End If

        If Not Session("group_login_flag") Is Nothing And Convert.ToString(Session("group_login_flag")).Trim() <> "" Then
            group_flag = Convert.ToString(Session("group_login_flag")).Trim()
        Else
            group_flag = "N"
        End If
        If Not Session("vip_no") Is Nothing And Convert.ToString(Session("vip_no")).Trim() <> "" Then
            vip_no = Convert.ToString(Session("vip_no")).Trim()
        Else
            vip_no = "N"
        End If
        If Not Session("level_id") Is Nothing And Convert.ToString(Session("level_id")).Trim() <> "" Then
            level_id = Convert.ToString(Session("level_id")).Trim()
        Else
            level_id = "N"
        End If

        Dim SortExpression As String
        Dim SortDirection As String
        SortExpression = Me.DataGrid_VoucherList.Attributes("SortExpression")
        SortDirection = Me.DataGrid_VoucherList.Attributes("SortDirection")
        'm_dataset = obj_DataSource.GetElementReport(acct_id, sub_acct_id, sel_acct_id, group_flag, strfromdate, strtodate, strDaytype, strElement, strRidetotal)
        If Not m_dataset Is Nothing Then
            If m_dataset.Tables.Count > 0 Then
                m_DataTable = m_dataset.Tables(0)
                Me.grdDV = m_DataTable.DefaultView
                Try
                    If Not m_dataset.Tables(1) Is Nothing Then
                        m_DataTable2 = m_dataset.Tables(1)
                        If m_DataTable2.Rows.Count > 0 Then
                            Dim n As Integer
                            For n = 0 To m_DataTable2.Rows.Count - 1
                                If IsDBNull(m_DataTable2.Rows(n).Item("req_desc")) Then
                                    Session("strfield" & n + 1 & "name") = ""
                                ElseIf m_DataTable2.Rows(n).Item("req_desc").ToString.Trim() = "" Then
                                    Session("strfield" & n + 1 & "name") = ""
                                Else
                                    Session("strfield" & n + 1 & "name") = m_DataTable2.Rows(n).Item("req_desc")
                                End If
                            Next

                        Else
                            Session("strfield1name") = ""
                            Session("strfield2name") = ""
                            Session("strfield3name") = ""
                            Session("strfield4name") = ""
                            Session("strfield5name") = ""
                            Session("strfield6name") = ""
                        End If
                    End If
                Catch ex As Exception
                    ' Exit Function
                End Try
                
                Session("m_datatable") = m_DataTable
                obj_DataSource = Nothing
                'If ViewState("SortExprValue") <> "" Then
                '    m_DataTable.DefaultView.Sort = ViewState("SortExprValue")
                'End If
                If SortExpression <> "" Then
                    m_DataTable.DefaultView.Sort = SortExpression & " " & SortDirection
                End If

                If m_DataTable.Rows.Count = 0 Then
                    Dim strMessage As String = "<script language=""JavaScript"">alert('No information about the ACCOUNT! Please try again...');" & _
                                               "history.go(-1);</script>"
                    RegisterStartupScript("PopUpMessage", strMessage)

                End If
            End If
        End If

        Return m_DataTable.DefaultView
    End Function
    Protected Sub DataGrid_VoucherList_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid_VoucherList.ItemDataBound
        If e.Item.ItemType = ListItemType.Header Then
            If Not Session("strfield1name") Is Nothing And Convert.ToString(Session("strfield1name")).Trim() <> "" Then
                e.Item.Cells(22).Text = Convert.ToString(Session("strfield1name")).Trim()
            Else
                DataGrid_VoucherList.Columns(22).Visible = False
            End If
            If Not Session("strfield2name") Is Nothing And Convert.ToString(Session("strfield2name")).Trim() <> "" Then
                e.Item.Cells(23).Text = Convert.ToString(Session("strfield2name")).Trim()
            Else
                DataGrid_VoucherList.Columns(23).Visible = False
            End If
            If Not Session("strfield3name") Is Nothing And Convert.ToString(Session("strfield3name")).Trim() <> "" Then
                e.Item.Cells(24).Text = Convert.ToString(Session("strfield3name")).Trim()
            Else
                DataGrid_VoucherList.Columns(24).Visible = False
            End If
            If Not Session("strfield4name") Is Nothing And Convert.ToString(Session("strfield4name")).Trim() <> "" Then
                e.Item.Cells(25).Text = Convert.ToString(Session("strfield4name")).Trim()
            Else
                DataGrid_VoucherList.Columns(25).Visible = False
            End If
            If Not Session("strfield5name") Is Nothing And Convert.ToString(Session("strfield5name")).Trim() <> "" Then
                e.Item.Cells(26).Text = Convert.ToString(Session("strfield5name")).Trim()
            Else
                DataGrid_VoucherList.Columns(26).Visible = False
            End If
            If Not Session("strfield6name") Is Nothing And Convert.ToString(Session("strfield6name")).Trim() <> "" Then
                e.Item.Cells(27).Text = Convert.ToString(Session("strfield6name")).Trim()
            Else
                DataGrid_VoucherList.Columns(27).Visible = False
            End If
        End If
    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click

        Dim strFileName As String = "ElementOfReport.csv"
        Me.LoadDefault()
        Common.GenerateCSVFile(Me, Me.DataGrid_VoucherList, strFileName)

        'Dim strLevelID As String = Trim(Session("level_id"))
        'Dim strFileName As String = "ElementOfReport"
        'Dim obj_DataGrid As DataGrid = DataGrid_VoucherList

        'If strLevelID = String.Empty Then
        '    'ERROR: Session "Acct_ID" missing
        '    'Response.Redirect("Login.aspx?LogOff=1")
        '    Exit Sub
        'End If

        'If obj_DataGrid Is Nothing Then
        '    'ERROR: Session "ojb_DataGrid"
        '    Exit Sub
        'End If

        'Response.Clear()
        'Response.Buffer = True
        'Response.Charset = "utf-8"
        'Response.AppendHeader("Content-Disposition", "attachment;filename=" & strFileName & ".xls")
        'Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8")
        'Response.ContentType = "application/ms-excel"

        'obj_DataGrid.EnableViewState = False

        'obj_DataGrid.AllowPaging = False
        'obj_DataGrid.DataBind()

        'Dim strTmp As String

        'Dim obj_Col As DataGridColumn
        'For Each obj_Col In obj_DataGrid.Columns
        '    Response.Write(Adjust(obj_Col.HeaderText) & vbTab)
        'Next
        'Response.Write(vbCrLf)

        'Dim obj_Row As DataGridItem
        'Dim obj_Cell As TableCell
        'For Each obj_Row In obj_DataGrid.Items
        '    For Each obj_Cell In obj_Row.Cells
        '        Dim obj_Ctrl As Control
        '        For Each obj_Ctrl In obj_Cell.Controls
        '            If obj_Ctrl.GetType Is GetType(HyperLink) Then
        '                Dim obj_hplnk As HyperLink
        '                obj_hplnk = CType(obj_Ctrl, HyperLink)
        '                Response.Write(Adjust(obj_hplnk.Text))
        '            ElseIf obj_Ctrl.GetType Is GetType(Label) Then
        '                Dim obj_Label As Label
        '                obj_Label = CType(obj_Ctrl, Label)
        '                Response.Write(Adjust(obj_Label.Text))
        '            End If
        '        Next
        '        Response.Write(Adjust(obj_Cell.Text) & vbTab)
        '    Next
        '    Response.Write(vbCrLf)
        'Next

        'For Each obj_Col In obj_DataGrid.Columns
        '    Response.Write(Adjust(obj_Col.FooterText) & vbTab)
        'Next
        'Response.Write(vbCrLf)

        'Response.End()
    End Sub
    'Public Function Adjust(ByVal strText As String) As String
    '    Dim strTmp As String
    '    strTmp = strText.Trim
    '    strTmp = Replace(strTmp, "'", "''")
    '    strTmp = Replace(strTmp, "&nbsp;", " ")
    '    Return strTmp
    'End Function
    Private Sub LoadDefault()
        With Me.DataGrid_VoucherList
            .DataSource = GetDataSource()

            If IsNumeric(ViewState("iPage")) Then
                .CurrentPageIndex = CInt(ViewState("iPage"))
            Else
                .CurrentPageIndex = 0
            End If
            .DataBind()
            If .PageCount <= 1 Then
                .PagerStyle.Visible = False
            Else
                .PagerStyle.Visible = True
            End If
        End With
        Me.lbl_PageIndex.Text = DataGrid_VoucherList.CurrentPageIndex + 1
        Me.lbl_PageAmount.Text = DataGrid_VoucherList.PageCount
    End Sub
    Protected Sub DataGrid_VoucherList_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid_VoucherList.PageIndexChanged
        ViewState("iPage") = e.NewPageIndex
        LoadDefault()
    End Sub
    Protected Sub DataGrid_VoucherList_SortCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles DataGrid_VoucherList.SortCommand
        Me.LoadDefault()
        If e.SortExpression = "Invoice_No" Or e.SortExpression = "base_rate" Then
            Me.grdDV.Sort = e.SortExpression & " DESC"
        Else
            Me.grdDV.Sort = e.SortExpression
        End If

        Me.DataGrid_VoucherList.DataBind()
    End Sub

End Class
