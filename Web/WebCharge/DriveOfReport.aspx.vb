Imports System.Data
Imports System.Drawing.Graphics
Imports Business
Partial Class DriveOfReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.IsPostBack Then
            ViewState("sel_acct_id") = Trim(Request.QueryString("SelAcctId"))
            Session("select_acct") = Trim(Request.QueryString("SelAcctId"))
            ViewState("fromdate") = Trim(Request.QueryString("Fromdate"))
            ViewState("todate") = Trim(Request.QueryString("Todate"))
            ViewState("top") = Trim(Request.QueryString("Top"))
            ViewState("daytype") = Trim(Request.QueryString("Daytype"))
            ViewState("sortby") = Trim(Request.QueryString("Sortby"))
            Me.Label1.Text = "Your Requested Top <font color='green'>" & Convert.ToString(ViewState("top")).Trim() & "</font> Drivers Report <font color='green'>"
            If Convert.ToString(ViewState("sortby")).Trim() = "1" Then
                Me.Label1.Text = Me.Label1.Text & "</font>By Total Voucher Amount"
            Else
                Me.Label1.Text = Me.Label1.Text & "</font>By Total Number of Rides"
            End If

        End If
        If Me.DataGrid_VoucherList.Attributes("SortExpression") = "" Then
            Me.DataGrid_VoucherList.Attributes("SortExpression") = "car_no"
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
        sel_acct_id = Convert.ToString(ViewState("sel_acct_id")).Trim()
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

        m_dataset = obj_DataSource.GetDriveReport(acct_id, sub_acct_id, sel_acct_id, group_flag, strfromdate, strtodate, strTop, strDaytype, strSortby)

        If Not m_dataset Is Nothing Then
            If m_dataset.Tables.Count > 0 Then
                m_DataTable = m_dataset.Tables(0)

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
End Class
