Imports System.Data
Imports System.Drawing.Graphics
Imports Business
Partial Class CustomerList
    Inherits System.Web.UI.Page
    Private grdDV As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            
            ViewState("FromTrip") = Trim(Request.QueryString("FromDate"))
            ViewState("ToTrip") = Trim(Request.QueryString("ToDate"))
            ViewState("str_SearchValue") = Trim(Request.QueryString("SearchValue"))
            ViewState("str_Comreq") = Trim(Request.QueryString("custom"))
            ViewState("custext") = Trim(Request.QueryString("custext"))
            ViewState("sel_acct_id") = Trim(Request.QueryString("SelAcctId"))
            ViewState("DateType") = Trim(Request.QueryString("DateType"))
            If Not ViewState("sel_acct_id") Is Nothing And Convert.ToString(ViewState("sel_acct_id")).Trim() <> "" Then
                Me.lbl_content.Text = "From Trip Date: <font color='green'>" & Convert.ToString(ViewState("FromTrip")).Trim() & "</font> To Trip Date:<font color='green'>" & Convert.ToString(ViewState("ToTrip")).Trim() & "</font> Customer Reference:<font color='green'>" & Convert.ToString(ViewState("custext")).Trim() & "</font> Seach Value:<font color='green'>" & Convert.ToString(ViewState("str_SearchValue")).Trim() & "</font> Account:<font color='green'>" & Convert.ToString(Session("sel_acct_id")).Trim() & "</font>"
            Else
                Me.lbl_content.Text = "From Trip Date: <font color='green'>" & Convert.ToString(ViewState("FromTrip")).Trim() & "</font> To Trip Date:<font color='green'>" & Convert.ToString(ViewState("ToTrip")).Trim() & "</font> Customer Reference:<font color='green'>" & Convert.ToString(ViewState("custext")).Trim() & "</font> Seach Value:<font color='green'>" & Convert.ToString(ViewState("str_SearchValue")).Trim() & "</font> Account:<font color='green'>" & Convert.ToString(Session("acct_id")).Trim() & "</font>"

            End If

        End If
        If Me.DataGrid_VoucherList.Attributes("SortExpression") = "" Then
            Me.DataGrid_VoucherList.Attributes("SortExpression") = "Invoice_No"
            Me.DataGrid_VoucherList.Attributes("SortDirection") = "asc"
        End If
        Call Me.Load_Default()

        'DataGrid_VoucherList.DataSource = GetDataSource()
        'DataGrid_VoucherList.DataBind()

        'Me.lbl_PageIndex.Text = DataGrid_VoucherList.CurrentPageIndex + 1
        'Me.lbl_PageAmount.Text = DataGrid_VoucherList.PageCount
    End Sub
    Private Sub Load_Default()
        With Me.DataGrid_VoucherList
            .DataSource = GetDataSource()

            If IsNumeric(ViewState("iPage")) Then
                .CurrentPageIndex = CInt(ViewState("iPage"))
            Else
                .CurrentPageIndex = 0
            End If
            .DataBind()
        End With
        Me.lbl_PageIndex.Text = DataGrid_VoucherList.CurrentPageIndex + 1
        Me.lbl_PageAmount.Text = DataGrid_VoucherList.PageCount
    End Sub
    Public Function GetDataSource() As DataView
        Dim FromTrip As String
        Dim ToTrip As String
        Dim level_id As String
        Dim vip_no As String
        Dim acct_id As String
        Dim sub_acct_id As String
        Dim sel_acct_id As String
        Dim group_flag As String
        Dim str_SearchValue As String
        Dim str_Comreq As String
        Dim strDatetype As String
        Dim obj_DataSource As New Report
        Dim dv As New DataView
        Dim m_dataset As New DataSet
        Dim m_DataTable As New DataTable
        Dim m_DataTable2 As New DataTable


        FromTrip = Convert.ToString(ViewState("FromTrip")).Trim()
        ToTrip = Convert.ToString(ViewState("ToTrip")).Trim()
        str_SearchValue = Convert.ToString(ViewState("str_SearchValue")).Trim()
        str_Comreq = Convert.ToString(ViewState("str_Comreq")).Trim()
        sel_acct_id = Convert.ToString(ViewState("sel_acct_id")).Trim()
        strDatetype = Convert.ToString(ViewState("DateType")).Trim()
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
        'm_dataset = obj_DataSource.GetCustomerList(acct_id, sub_acct_id, sel_acct_id, vip_no, level_id, group_flag, FromTrip, ToTrip, str_Comreq, str_SearchValue, strDatetype)

        If Not m_dataset Is Nothing Then
            If m_dataset.Tables.Count > 0 Then
                m_DataTable = m_dataset.Tables(0)
                Me.grdDV = m_DataTable.DefaultView
                Session("m_datatable") = m_DataTable
                obj_DataSource = Nothing
                'If ViewState("SortExprValue") <> "" Then
                '    m_DataTable.DefaultView.Sort = ViewState("SortExprValue")
                'End If
                If SortExpression <> "" Then
                    m_DataTable.DefaultView.Sort = SortExpression & " " & SortDirection
                End If

                If m_DataTable.Rows.Count = 0 Then
                    Dim strMessage As String = "<script language=""JavaScript"">alert('No Information Found!');" & _
                                               "history.go(-1);</script>"
                    RegisterStartupScript("PopUpMessage", strMessage)

                End If
            End If
        End If

        Return m_DataTable.DefaultView
    End Function

    'Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
    '    Dim strLevelID As String = Trim(Session("level_id"))
    '    Dim strFileName As String = "CustomList"
    '    Dim obj_DataGrid As DataGrid = DataGrid_VoucherList

    '    If strLevelID = String.Empty Then
    '        'ERROR: Session "Acct_ID" missing
    '        'Response.Redirect("Login.aspx?LogOff=1")
    '        Exit Sub
    '    End If

    '    If obj_DataGrid Is Nothing Then
    '        'ERROR: Session "ojb_DataGrid"
    '        Exit Sub
    '    End If

    '    Response.Clear()
    '    Response.Buffer = True
    '    Response.Charset = "utf-8"
    '    Response.AppendHeader("Content-Disposition", "attachment;filename=" & strFileName & ".xls")
    '    Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8")
    '    Response.ContentType = "application/ms-excel"

    '    obj_DataGrid.EnableViewState = False

    '    obj_DataGrid.AllowPaging = False
    '    obj_DataGrid.DataBind()

    '    Dim strTmp As String

    '    Dim obj_Col As DataGridColumn
    '    For Each obj_Col In obj_DataGrid.Columns
    '        Response.Write(Adjust(obj_Col.HeaderText) & vbTab)
    '    Next
    '    Response.Write(vbCrLf)

    '    Dim obj_Row As DataGridItem
    '    Dim obj_Cell As TableCell
    '    For Each obj_Row In obj_DataGrid.Items
    '        For Each obj_Cell In obj_Row.Cells
    '            Dim obj_Ctrl As Control
    '            For Each obj_Ctrl In obj_Cell.Controls
    '                If obj_Ctrl.GetType Is GetType(HyperLink) Then
    '                    Dim obj_hplnk As HyperLink
    '                    obj_hplnk = CType(obj_Ctrl, HyperLink)
    '                    Response.Write(Adjust(obj_hplnk.Text))
    '                ElseIf obj_Ctrl.GetType Is GetType(Label) Then
    '                    Dim obj_Label As Label
    '                    obj_Label = CType(obj_Ctrl, Label)
    '                    Response.Write(Adjust(obj_Label.Text))
    '                End If
    '            Next
    '            Response.Write(Adjust(obj_Cell.Text) & vbTab)
    '        Next
    '        Response.Write(vbCrLf)
    '    Next

    '    For Each obj_Col In obj_DataGrid.Columns
    '        Response.Write(Adjust(obj_Col.FooterText) & vbTab)
    '    Next
    '    Response.Write(vbCrLf)

    '    Response.End()
    'End Sub
    Public Function Adjust(ByVal strText As String) As String
        Dim strTmp As String
        strTmp = strText.Trim
        strTmp = Replace(strTmp, "'", "''")
        strTmp = Replace(strTmp, "&nbsp;", " ")
        Return strTmp
    End Function

    Protected Sub DataGrid_VoucherList_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid_VoucherList.PageIndexChanged
        ViewState("iPage") = e.NewPageIndex
        Load_Default()
    End Sub

    Protected Sub DataGrid_VoucherList_SortCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles DataGrid_VoucherList.SortCommand
        Call Me.Load_Default()

        If e.SortExpression = "Invoice_No" Or e.SortExpression = "base_rate" Then
            Session("SortExprValue") = e.SortExpression & " DESC"
            Me.grdDV.Sort = e.SortExpression & " DESC"
        Else
            Session("SortExprValue") = e.SortExpression
            Me.grdDV.Sort = e.SortExpression
        End If

        Me.DataGrid_VoucherList.DataBind()
    End Sub
End Class
