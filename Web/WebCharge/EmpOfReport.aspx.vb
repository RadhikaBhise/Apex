Imports System.Data
Imports System.Drawing.Graphics
Imports Business
Partial Class PassOfReport
    Inherits System.Web.UI.Page
    Private grdDV As DataView
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.IsPostBack Then
            ViewState("sel_acct_id") = Trim(Request.QueryString("SelAcctId"))
            Session("select_acct") = Trim(Request.QueryString("SelAcctId"))
            ViewState("fromdate") = Trim(Request.QueryString("Fromdate"))
            ViewState("todate") = Trim(Request.QueryString("Todate"))
            ViewState("top") = Trim(Request.QueryString("Top"))
            ViewState("daytype") = Trim(Request.QueryString("Daytype"))
            ViewState("sortby") = Trim(Request.QueryString("Sortby"))
            Me.lbl_TabCap.Text = "Your Requested Top <font color='green'>" & Convert.ToString(ViewState("top")).Trim() & " </font> Employee(s) Report"
            If Convert.ToString(ViewState("sortby")).Trim() = "1" Then
                Me.lbl_TabCap.Text = Me.lbl_TabCap.Text & " By Total Voucher Amount:"
            Else
                Me.lbl_TabCap.Text = Me.lbl_TabCap.Text & " By Total Number of Rides:"
            End If
        End If
        If Me.DataGrid_VoucherList.Attributes("SortExpression") = "" Then
            Me.DataGrid_VoucherList.Attributes("SortExpression") = "vip_no"
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
        Dim level_id As String
        Dim vip_no As String
        Dim acct_id As String
        Dim sub_acct_id As String
        Dim sel_acct_id As String
        Dim group_flag As String
        Dim sel_vip_no As String
        Dim strfromdate As String
        Dim strtodate As String
        Dim strTop As String
        Dim strDaytype As String
        Dim strSortby As String

        strfromdate = Convert.ToString(ViewState("fromdate")).Trim()
        strtodate = Convert.ToString(ViewState("todate")).Trim()
        sel_vip_no = Convert.ToString(ViewState("SelVip")).Trim()
        sel_acct_id = Convert.ToString(ViewState("SelAcct")).Trim()
        strTop = Convert.ToString(ViewState("top")).Trim()
        strDaytype = Convert.ToString(ViewState("daytype")).Trim()
        strSortby = Convert.ToString(ViewState("sortby")).Trim()
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
        m_dataset = obj_DataSource.GetEMPReport(acct_id, sub_acct_id, sel_acct_id, group_flag, strfromdate, strtodate, strTop, strDaytype, strSortby)
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
                    Dim strMessage As String = "<script language=""JavaScript"">alert('No information about the ACCOUNT! Please try again...');" & _
                                               "history.go(-1);</script>"
                    RegisterStartupScript("PopUpMessage", strMessage)
                    'Msg.GetErrorMsg(Msg.MsgType.NoEmployeeInformation, Me)
                End If
            End If
        End If

        Return m_DataTable.DefaultView
    End Function
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
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim strFileName As String = "EmployeetopList.csv"
        Me.LoadDefault()
        Common.GenerateCSVFile(Me, Me.DataGrid_VoucherList, strFileName)
    End Sub
    Protected Sub DataGrid_VoucherList_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid_VoucherList.PageIndexChanged
        ViewState("iPage") = e.NewPageIndex
        LoadDefault()
    End Sub
    Protected Sub DataGrid_VoucherList_SortCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles DataGrid_VoucherList.SortCommand
        Me.LoadDefault()
        If e.SortExpression = "vip_no" Or e.SortExpression = "totalBase" Then
            Me.grdDV.Sort = e.SortExpression & " DESC"
        Else
            Me.grdDV.Sort = e.SortExpression
        End If

        Me.DataGrid_VoucherList.DataBind()
    End Sub

    Protected Sub DataGrid_VoucherList_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles DataGrid_VoucherList.SortCommand

    End Sub
End Class
