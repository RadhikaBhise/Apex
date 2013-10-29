Imports Business
Imports DataAccess
Imports System.Data
Imports System.Data.SqlClient
Partial Class RptOfDay
    Inherits System.Web.UI.Page
    Private grdDV As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.btnSubmit.Attributes.Add("onclick", "return batchvalidate('" & Session("group_login_flag") & "','" & Me.txtFromDate.ClientID & "','" & Me.txtToDate.ClientID & "');")

        If Not Page.IsPostBack Then
            txtFromDate.Text = Common.ShowDateTime(Now.AddMonths(-6), Common.DateTimeStyle.DateOnly)
            txtToDate.Text = Common.ShowDateTime(Now(), Common.DateTimeStyle.DateOnly)

            Me.trData.Visible = False
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click
        Me.LoadData()
    End Sub

    Private Sub LoadData()
        Using rpt As New Report
            Dim ds As DataSet = rpt.GetDayReport(MySession.AcctID, MySession.SubAcctID, Me.txtFromDate.Text, Me.txtToDate.Text, Me.drpfrom.SelectedValue, Me.drpto.SelectedValue)

            Me.VoucherList1.DataSetSource = ds
            Me.VoucherList1.DataSetBind(-1, "")
            Me.trData.Visible = True
        End Using
        'If Me.hdnSort.Value = "" Then
        '    Me.hdnSort.Value = "Invoice_No asc"
        'End If
        'DataGridVoucherList.DataSource = GetDataSource()
        'If IsNumeric(ViewState("iPage")) Then
        '    DataGridVoucherList.CurrentPageIndex = CInt(ViewState("iPage"))
        'Else
        '    DataGridVoucherList.CurrentPageIndex = 0
        'End If
        'DataGridVoucherList.DataBind()
        'If DataGridVoucherList.PageCount <= 1 Then
        '    DataGridVoucherList.PagerStyle.Visible = False
        'Else
        '    DataGridVoucherList.PagerStyle.Visible = True
        'End If

        'Me.lblPageIndex.Text = DataGridVoucherList.CurrentPageIndex + 1
        'Me.lblPageAmount.Text = DataGridVoucherList.PageCount
    End Sub

    'Public Function GetDataSource() As DataView
    '    Dim objDataSource As New Report
    '    Dim dv As New DataView
    '    Dim m_dataset As New DataSet
    '    Dim m_DataTable As New DataTable
    '    Dim m_DataTable2 As New DataTable
    '    Dim level_id As String
    '    Dim vip_no As String
    '    Dim acct_id As String
    '    Dim sub_acct_id As String
    '    Dim sel_acct_id As String
    '    Dim group_flag As String
    '    Dim sel_vip_no As String
    '    Dim strfromdate As String
    '    Dim strtodate As String

    '    strfromdate = Me.txtFromDate.Text.ToString.Trim
    '    strtodate = Me.txtToDate.Text.ToString.Trim
    '    sel_vip_no = ""
    '    sel_acct_id = ""
    '    If Not MySession.AcctID Is Nothing And Convert.ToString(MySession.AcctID).Trim() <> "" Then
    '        acct_id = Convert.ToString(MySession.AcctID).Trim()
    '    Else
    '        acct_id = ""
    '    End If
    '    If Not MySession.SubAcctID Is Nothing And Convert.ToString(MySession.SubAcctID).Trim() <> "" Then
    '        sub_acct_id = Convert.ToString(MySession.SubAcctID).Trim()
    '    Else
    '        sub_acct_id = ""
    '    End If

    '    If Not Session("group_login_flag") Is Nothing And Convert.ToString(Session("group_login_flag")).Trim() <> "" Then
    '        group_flag = Convert.ToString(Session("group_login_flag")).Trim()
    '    Else
    '        group_flag = "N"
    '    End If
    '    If Not MySession.UserID Is Nothing And Convert.ToString(MySession.UserID).Trim() <> "" Then
    '        vip_no = Convert.ToString(MySession.UserID).Trim()
    '    Else
    '        vip_no = "N"
    '    End If
    '    If Not MySession.LevelID Is Nothing And Convert.ToString(MySession.LevelID).Trim() <> "" Then
    '        level_id = Convert.ToString(MySession.LevelID).Trim()
    '    Else
    '        level_id = "N"
    '    End If

    '    'Dim SortExpression As String
    '    'Dim SortDirection As String
    '    'SortExpression = Me.DataGridVoucherList.Attributes("SortExpression")
    '    'SortDirection = Me.DataGridVoucherList.Attributes("SortDirection")
    '    m_dataset = objDataSource.GetDayReport(acct_id, sub_acct_id, sel_acct_id, group_flag, strfromdate, strtodate, Me.drpfrom.SelectedValue, Me.drpto.SelectedValue)
    '    If Not m_dataset Is Nothing Then
    '        If m_dataset.Tables.Count > 0 Then
    '            Me.tbDatagrid.Visible = True
    '            m_DataTable = m_dataset.Tables(0)
    '            m_DataTable2 = m_dataset.Tables(1)
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
    '            objDataSource = Nothing
    '            'If SortExpression <> "" Then
    '            '    m_DataTable.DefaultView.Sort = SortExpression & " " & SortDirection
    '            'End If

    '            If m_DataTable.Rows.Count = 0 Then
    '                Dim strMessage As String = "<script language=""JavaScript"">alert('No Information Found!');" & _
    '                                           "history.go(-1);</script>"
    '                ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage", strMessage)

    '            End If
    '        End If
    '    Else
    '        Me.tbDatagrid.Visible = False
    '    End If

    '    Return m_DataTable.DefaultView
    'End Function
    'Protected Sub DataGridVoucherList_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGridVoucherList.ItemDataBound
    '    If e.Item.ItemType = ListItemType.Header Then
    '        If Not Session("strfield1name") Is Nothing And Convert.ToString(Session("strfield1name")).Trim() <> "" Then
    '            e.Item.Cells(24).Text = Convert.ToString(Session("strfield1name")).Trim()
    '        Else
    '            DataGridVoucherList.Columns(24).Visible = False
    '        End If
    '        If Not Session("strfield2name") Is Nothing And Convert.ToString(Session("strfield2name")).Trim() <> "" Then
    '            e.Item.Cells(25).Text = Convert.ToString(Session("strfield2name")).Trim()
    '        Else
    '            DataGridVoucherList.Columns(25).Visible = False
    '        End If
    '        If Not Session("strfield3name") Is Nothing And Convert.ToString(Session("strfield3name")).Trim() <> "" Then
    '            e.Item.Cells(26).Text = Convert.ToString(Session("strfield3name")).Trim()
    '        Else
    '            DataGridVoucherList.Columns(26).Visible = False
    '        End If
    '        If Not Session("strfield4name") Is Nothing And Convert.ToString(Session("strfield4name")).Trim() <> "" Then
    '            e.Item.Cells(27).Text = Convert.ToString(Session("strfield4name")).Trim()
    '        Else
    '            DataGridVoucherList.Columns(27).Visible = False
    '        End If
    '        If Not Session("strfield5name") Is Nothing And Convert.ToString(Session("strfield5name")).Trim() <> "" Then
    '            e.Item.Cells(28).Text = Convert.ToString(Session("strfield5name")).Trim()
    '        Else
    '            DataGridVoucherList.Columns(28).Visible = False
    '        End If
    '        If Not Session("strfield6name") Is Nothing And Convert.ToString(Session("strfield6name")).Trim() <> "" Then
    '            e.Item.Cells(29).Text = Convert.ToString(Session("strfield6name")).Trim()
    '        Else
    '            DataGridVoucherList.Columns(29).Visible = False
    '        End If
    '    End If
    'End Sub
    'Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExcel.Click
    '    Dim strFileName As String = "DayOfReport.csv"
    '    Me.DataGridVoucherList.AllowPaging = False
    '    Me.LoadData()
    '    Common.GenerateCSVFile(Me, Me.DataGridVoucherList, strFileName)
    'End Sub
    'Public Function Adjust(ByVal strText As String) As String
    '    Dim strTmp As String
    '    strTmp = strText.Trim
    '    strTmp = Replace(strTmp, "'", "''")
    '    strTmp = Replace(strTmp, "&nbsp;", " ")
    '    Return strTmp
    'End Function

    'Protected Sub DataGridVoucherList_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGridVoucherList.PageIndexChanged
    '    ViewState("iPage") = e.NewPageIndex
    '    LoadData()
    '    If Me.grdDV.Table.Columns.Contains(Me.hdnSort.Value.Replace(" DESC", "")) Then
    '        Me.grdDV.Sort = Me.hdnSort.Value
    '    End If
    '    Me.DataGridVoucherList.DataBind()
    'End Sub

    'Protected Sub DataGridVoucherList_SortCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles DataGridVoucherList.SortCommand
    '    Me.LoadData()
    '    If Me.hdnSort.Value = e.SortExpression Then
    '        Me.hdnSort.Value = e.SortExpression & " DESC"
    '    Else
    '        Me.hdnSort.Value = e.SortExpression
    '    End If
    '    If Me.grdDV.Table.Columns.Contains(Me.hdnSort.Value.Replace(" DESC", "")) Then
    '        Me.grdDV.Sort = Me.hdnSort.Value
    '    End If
    '    Me.DataGridVoucherList.DataBind()
    'End Sub

End Class
