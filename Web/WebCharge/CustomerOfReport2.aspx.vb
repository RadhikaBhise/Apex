Imports System.Data
Imports System.Drawing.Graphics
Imports Business
Partial Class CustomerOfReport2
    Inherits System.Web.UI.Page
    Private grdDV As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack() Then

            If Not Request.QueryString("com_id") Is Nothing Then
                Me.hdnCompID.Value = Request.QueryString("com_id").Trim
            End If
            If Not Request.QueryString("comtext") Is Nothing Then
                Me.hdnCompValue.Value = Request.QueryString("comtext").Trim
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

            Using account As New Corporate
                Dim ReqDesc As String = account.GetCompanyRequirementDescByID(Me.hdnCompID.Value)

                If IsDate(Me.hdnFromDate.Value) AndAlso IsDate(Me.hdnToDate.Value) Then
                    Me.lblTitle.Text = String.Format("From {0} Date: {1}&nbsp;&nbsp;&nbsp;&nbsp;To {0} Date: {2}&nbsp;&nbsp;&nbsp;&nbsp;" & _
                            "Customer Reference: {3}&nbsp;&nbsp;&nbsp;&nbsp;Seach Value: {4}", IIf(Me.hdnDateType.Value = "t", "Trip", "Invoice"), Me.hdnFromDate.Value, Me.hdnToDate.Value, ReqDesc, Me.hdnCompValue.Value)
                End If
            End Using

            Using rpt As New Report
                Dim ds As DataSet = rpt.GetCustomReport2(MySession.AcctID, MySession.SubAcctID, Me.hdnCompID.Value, Me.hdnCompValue.Value, Me.hdnDateType.Value, Me.hdnFromDate.Value, Me.hdnToDate.Value)

                Me.VoucherList1.DataSetSource = ds
                Me.VoucherList1.DataSetBind(-1, "")
            End Using
        End If

        'If Me.DataGrid_VoucherList.Attributes("SortExpression") = "" Then
        '    Me.DataGrid_VoucherList.Attributes("SortExpression") = "Invoice_No"
        '    Me.DataGrid_VoucherList.Attributes("SortDirection") = "asc"
        'End If
        'DataGrid_VoucherList.DataSource = GetDataSource()
        'DataGrid_VoucherList.DataBind()

        'Me.lbl_PageIndex.Text = DataGrid_VoucherList.CurrentPageIndex + 1
        'Me.lbl_PageAmount.Text = DataGrid_VoucherList.PageCount
    End Sub

    '    Public Function GetDataSource() As DataView


    '        Dim obj_DataSource As New Report
    '        Dim dv As New DataView
    '        Dim m_dataset As New DataSet
    '        Dim m_DataTable As New DataTable
    '        Dim m_DataTable2 As New DataTable
    '        Dim strInvoiceNo As String = Convert.ToString(ViewState("InvoiceNo")).Trim()
    '        Dim strInvoiceDate As String = Convert.ToString(ViewState("InvoiceDate")).Trim()
    '        Dim strSelectAcct As String = Convert.ToString(Session("selacctid")).Trim()
    '        Dim strGroupFlag As String
    '        Dim strComid As String
    '        Dim strComtext As String

    '        strComid = Convert.ToString(ViewState("comid")).Trim()
    '        strComtext = Convert.ToString(ViewState("comtext")).Trim()
    '        If Session("group_login_flag") Is Nothing Then
    '            strGroupFlag = "N"
    '        ElseIf Convert.ToString(Session("group_login_flag")).Trim() = "" Then
    '            strGroupFlag = "N"
    '        Else
    '            strGroupFlag = Convert.ToString(Session("group_login_flag")).Trim()
    '        End If

    '        Dim SortExpression As String
    '        Dim SortDirection As String
    '        SortExpression = Me.DataGrid_VoucherList.Attributes("SortExpression")
    '        SortDirection = Me.DataGrid_VoucherList.Attributes("SortDirection")
    '        m_dataset = obj_DataSource.GetCustomReport2(strGroupFlag, MySession.AcctID, MySession.SubAcctID, strSelectAcct, strComid, strComtext, Me.hdnDateType.Value, Me.hdnFromDate.Value, Me.hdnToDate.Value)



    '        If Not m_dataset Is Nothing Then
    '            If m_dataset.Tables.Count > 0 Then
    '                m_DataTable = m_dataset.Tables(0)
    '                Me.grdDV = m_DataTable.DefaultView
    '                m_DataTable2 = m_dataset.Tables(1)
    '                If m_DataTable2.Rows.Count > 0 Then

    '                    Dim n As Integer
    '                    For n = 0 To m_DataTable2.Rows.Count - 1
    '                        If IsDBNull(m_DataTable2.Rows(n).Item("req_desc")) Then
    '                            Session("strfield" & n + 1 & "name") = ""
    '                        ElseIf m_DataTable2.Rows(n).Item("req_desc").ToString.Trim() = "" Then
    '                            Session("strfield" & n + 1 & "name") = ""
    '                        Else
    '                            Session("strfield" & n + 1 & "name") = m_DataTable2.Rows(n).Item("req_desc")
    '                        End If
    '                    Next

    '                Else
    '                    Session("strfield1name") = ""
    '                    Session("strfield2name") = ""
    '                    Session("strfield3name") = ""
    '                    Session("strfield4name") = ""
    '                    Session("strfield5name") = ""
    '                    Session("strfield6name") = ""
    '                End If
    '                Session("m_datatable") = m_DataTable
    '                obj_DataSource = Nothing
    '                'If ViewState("SortExprValue") <> "" Then
    '                '    m_DataTable.DefaultView.Sort = ViewState("SortExprValue")
    '                'End If
    '                If SortExpression <> "" Then
    '                    m_DataTable.DefaultView.Sort = SortExpression & " " & SortDirection
    '                End If

    '                If m_DataTable.Rows.Count = 0 Then
    '                    Dim strMessage As String = "<script language=""JavaScript"">alert('No information about the ACCOUNT! Please try again...');" & _
    '                                               "history.go(-1);</script>"
    '                    RegisterStartupScript("PopUpMessage", strMessage)

    '                End If


    '            End If
    '        End If

    '        Return m_DataTable.DefaultView
    '    End Function

    '    Protected Sub DataGrid_VoucherList_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid_VoucherList.ItemDataBound
    '        If e.Item.ItemType = ListItemType.Header Then
    '            If Not Session("strfield1name") Is Nothing And Convert.ToString(Session("strfield1name")).Trim() <> "" Then
    '                e.Item.Cells(24).Text = Convert.ToString(Session("strfield1name")).Trim()
    '            Else
    '                DataGrid_VoucherList.Columns(24).Visible = False
    '            End If
    '            If Not Session("strfield2name") Is Nothing And Convert.ToString(Session("strfield2name")).Trim() <> "" Then
    '                e.Item.Cells(25).Text = Convert.ToString(Session("strfield2name")).Trim()
    '            Else
    '                DataGrid_VoucherList.Columns(25).Visible = False
    '            End If
    '            If Not Session("strfield3name") Is Nothing And Convert.ToString(Session("strfield3name")).Trim() <> "" Then
    '                e.Item.Cells(26).Text = Convert.ToString(Session("strfield3name")).Trim()
    '            Else
    '                DataGrid_VoucherList.Columns(26).Visible = False
    '            End If
    '            If Not Session("strfield4name") Is Nothing And Convert.ToString(Session("strfield4name")).Trim() <> "" Then
    '                e.Item.Cells(27).Text = Convert.ToString(Session("strfield4name")).Trim()
    '            Else
    '                DataGrid_VoucherList.Columns(27).Visible = False
    '            End If
    '            If Not Session("strfield5name") Is Nothing And Convert.ToString(Session("strfield5name")).Trim() <> "" Then
    '                e.Item.Cells(28).Text = Convert.ToString(Session("strfield5name")).Trim()
    '            Else
    '                DataGrid_VoucherList.Columns(28).Visible = False
    '            End If
    '            If Not Session("strfield6name") Is Nothing And Convert.ToString(Session("strfield6name")).Trim() <> "" Then
    '                e.Item.Cells(29).Text = Convert.ToString(Session("strfield6name")).Trim()
    '            Else
    '                DataGrid_VoucherList.Columns(29).Visible = False
    '            End If
    '        End If
    '    End Sub

    '#Region "Report Details"

    '    Private Sub LoadData()


    '        If Me.DataGrid_VoucherList.Attributes("SortExpression") = "" Then
    '            Me.DataGrid_VoucherList.Attributes("SortExpression") = "Invoice_No"
    '            Me.DataGrid_VoucherList.Attributes("SortDirection") = "asc"
    '        End If
    '        Me.LoadDefault()
    '    End Sub

    '    Private Sub LoadDefault()
    '        With Me.DataGrid_VoucherList
    '            .DataSource = GetDataSource()

    '            If IsNumeric(ViewState("iPage")) Then
    '                .CurrentPageIndex = CInt(ViewState("iPage"))
    '            Else
    '                .CurrentPageIndex = 0
    '            End If
    '            .DataBind()
    '            If .PageCount <= 1 Then
    '                .PagerStyle.Visible = False
    '            Else
    '                .PagerStyle.Visible = True
    '            End If
    '        End With
    '        Me.lbl_PageIndex.Text = DataGrid_VoucherList.CurrentPageIndex + 1
    '        Me.lbl_PageAmount.Text = DataGrid_VoucherList.PageCount
    '    End Sub

    '    Protected Sub DataGridVoucherList_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid_VoucherList.PageIndexChanged
    '        ViewState("iPage") = e.NewPageIndex
    '        LoadDefault()
    '    End Sub

    '    Protected Sub DataGridVoucherList_SortCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles DataGrid_VoucherList.SortCommand
    '        Me.LoadDefault()
    '        If e.SortExpression = "Invoice_No" Or e.SortExpression = "base_rate" Then
    '            Me.grdDV.Sort = e.SortExpression & " DESC"
    '        Else
    '            Me.grdDV.Sort = e.SortExpression
    '        End If

    '        Me.DataGrid_VoucherList.DataBind()
    '    End Sub
    '#End Region
    '    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExcel.Click
    '        Dim strFileName As String = "Customreport.csv"
    '        Me.DataGrid_VoucherList.AllowPaging = False
    '        Me.LoadData()
    '        Common.GenerateCSVFile(Me, Me.DataGrid_VoucherList, strFileName)
    '    End Sub
End Class
