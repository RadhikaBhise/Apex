Imports Business
Imports DataAccess
Imports System.Data
Imports System.Data.SqlClient
Partial Class RptOfElement
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Me.btn_Submit.Attributes.Add("onclick", "return batchvalidate('" & Session("group_login_flag") & "');")

        Me.btnSubmit.Attributes.Add("OnClick", "return batchValidate('" & Me.txtAmount.ClientID & "','" & Me.txtFromDate.ClientID & "','" & Me.txtToDate.ClientID & "');")

        If Session("acct_id") Is Nothing Then
            Response.Redirect("login.aspx")
        End If

        If Not Page.IsPostBack Then
            Me.txtFromDate.Text = Common.ShowDateTime(Now.AddMonths(-6), Common.DateTimeStyle.DateOnly)
            txtToDate.Text = Common.ShowDateTime(Now, Common.DateTimeStyle.DateOnly)
            Me.trDatagrid.Visible = False
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click
        Me.LoadData()
    End Sub

    Private Sub LoadData()
        Using rpt As New Report
            Dim ds As DataSet = rpt.GetElementReport(MySession.AcctID, MySession.SubAcctID, Me.txtFromDate.Text, Me.txtToDate.Text, _
                    Convert.ToString(IIf(Me.radTip.Checked, "t", "i")), Me.lst_rType.SelectedValue.Trim.ToLower(), Me.txtAmount.Text)

            If Not ds Is Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                Me.VoucherList1.DataSetSource = ds
                Me.VoucherList1.DataSetBind(-1, "")
                Me.trDatagrid.Visible = True
            Else
                Me.trDatagrid.Visible = False
            End If
        End Using

        'If Me.DataGrid_VoucherList.Attributes("SortExpression") = "" Then
        '    Me.DataGrid_VoucherList.Attributes("SortExpression") = "Invoice_No"
        '    Me.DataGrid_VoucherList.Attributes("SortDirection") = "asc"
        'End If

        'With Me.DataGrid_VoucherList
        '    .DataSource = GetDataSource()

        '    If IsNumeric(ViewState("iPage")) Then
        '        .CurrentPageIndex = CInt(ViewState("iPage"))
        '    Else
        '        .CurrentPageIndex = 0
        '    End If
        '    .DataBind()
        '    If .PageCount <= 1 Then
        '        .PagerStyle.Visible = False
        '    Else
        '        .PagerStyle.Visible = True
        '    End If
        'End With

        'Me.lblPageIndex.Text = DataGrid_VoucherList.CurrentPageIndex + 1
        'Me.lblPageAmount.Text = DataGrid_VoucherList.PageCount
    End Sub

    'Public Function GetDataSource() As DataView
    '    Dim obj_DataSource As New Report
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
    '    Dim strElement As String
    '    Dim strRidetotal As String
    '    Dim strDaytype As String

    '    strfromdate = Me.txtFromDate.Text.Trim
    '    strtodate = Me.txtToDate.Text.Trim
    '    sel_vip_no = ""
    '    sel_acct_id = ""
    '    strElement = Me.lst_rType.SelectedItem.Text.ToString.Trim()
    '    strRidetotal = Me.txtAmount.Text.ToString.Trim()
    '    If Me.radTip.Checked = True Then
    '        strDaytype = "t"
    '    Else
    '        strDaytype = "i"
    '    End If

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

    '    Dim SortExpression As String
    '    SortExpression = Me.DataGrid_VoucherList.Attributes("SortExpression")
    '    m_dataset = obj_DataSource.GetElementReport(acct_id, sub_acct_id, sel_acct_id, group_flag, strfromdate, strtodate, strDaytype, strElement, strRidetotal)
    '    If Not m_dataset Is Nothing Then
    '        If m_dataset.Tables.Count > 0 Then
    '            Me.trDatagrid.Visible = True
    '            m_DataTable = m_dataset.Tables(0)
    '            Try
    '                If Not m_dataset.Tables(1) Is Nothing Then
    '                    m_DataTable2 = m_dataset.Tables(1)
    '                    If m_DataTable2.Rows.Count > 0 Then

    '                        Dim n As Integer
    '                        For n = 0 To m_DataTable2.Rows.Count - 1
    '                            If IsDBNull(m_DataTable2.Rows(n).Item("req_desc")) Then
    '                                Session("strfield" & n + 1 & "name") = ""
    '                            ElseIf m_DataTable2.Rows(n).Item("req_desc").ToString.Trim() = "" Then
    '                                Session("strfield" & n + 1 & "name") = ""
    '                            Else
    '                                Session("strfield" & n + 1 & "name") = m_DataTable2.Rows(n).Item("req_desc")
    '                            End If
    '                        Next

    '                    Else
    '                        Session("strfield1name") = ""
    '                        Session("strfield2name") = ""
    '                        Session("strfield3name") = ""
    '                        Session("strfield4name") = ""
    '                        Session("strfield5name") = ""
    '                        Session("strfield6name") = ""
    '                    End If
    '                End If
    '            Catch ex As Exception

    '            End Try

    '            Session("m_datatable") = m_DataTable
    '            obj_DataSource = Nothing

    '            If SortExpression <> "" Then
    '                m_DataTable.DefaultView.Sort = SortExpression
    '            End If

    '            If m_DataTable.Rows.Count = 0 Then
    '                Dim strMessage As String = "<script language=""JavaScript"">alert('No information about the ACCOUNT! Please try again...');" & _
    '                                           "history.go(-1);</script>"
    '                ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage", strMessage)

    '            End If
    '        Else
    '            Me.trDatagrid.Visible = False
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

    '    Dim strFileName As String = "ElementOfReport.csv"
    '    Me.DataGrid_VoucherList.AllowPaging = False
    '    Me.LoadData()
    '    Common.GenerateCSVFile(Me, Me.DataGrid_VoucherList, strFileName)

    'End Sub
    'Protected Sub DataGrid_VoucherList_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid_VoucherList.PageIndexChanged
    '    ViewState("iPage") = e.NewPageIndex
    '    LoadData()
    'End Sub

    'Protected Sub DataGrid_VoucherList_SortCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles DataGrid_VoucherList.SortCommand
    '    Me.LoadData()
    '    If e.SortExpression = "Invoice_No" Or e.SortExpression = "base_rate" Then
    '        Me.DataGrid_VoucherList.Attributes("SortExpression") = e.SortExpression & " DESC"
    '    Else
    '        Me.DataGrid_VoucherList.Attributes("SortExpression") = e.SortExpression
    '    End If

    '    Me.DataGrid_VoucherList.DataBind()
    'End Sub

End Class
