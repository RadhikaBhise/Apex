Imports Business
Imports DataAccess
Imports System.Data
Imports System.Data.SqlClient
Partial Class RptOfDrive
    Inherits System.Web.UI.Page
    Private grdDV As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.btnSubmit.Attributes.Add("onclick", "return batchvalidate('" & Session("group_login_flag") & "','" & Me.txtFromDate.ClientID & "','" & Me.txtToDate.ClientID & "','" & Me.txtTop.ClientID & "');")
        If Session("account_list") Is Nothing And Session("acct_id") Is Nothing Then
            Response.Redirect("login.aspx")
        End If

        If Not Page.IsPostBack Then
            'Dim date_FromDate As Date
            'date_FromDate = "01/01/" & Year(Today())
            txtFromDate.Text = Common.ShowDateTime(Now.AddMonths(-6), Common.DateTimeStyle.DateOnly)
            txtToDate.Text = Common.ShowDateTime(Now, Common.DateTimeStyle.DateOnly)
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click
        LoadData()
    End Sub

    Private Sub LoadData()
        Me.trdata.Visible = True
        Dim top As String = Me.txtTop.Text.Trim()
        Me.lbl_TabCap.Text = "Your Requested Top " & Convert.ToString(top).Trim() & " Employee(s) Report"
        If Convert.ToString(ViewState("sortby")).Trim() = "1" Then
            Me.lbl_TabCap.Text = Me.lbl_TabCap.Text & " By Total Voucher Amount:"
        Else
            Me.lbl_TabCap.Text = Me.lbl_TabCap.Text & " By Total Number of Rides:"
        End If
        If Me.hdnSort.Value = "" Then
            Me.hdnSort.Value = "car_no asc"
        End If
        DataGridVoucherList.DataSource = GetDataSource()
        If IsNumeric(ViewState("iPage")) Then
            DataGridVoucherList.CurrentPageIndex = CInt(ViewState("iPage"))
        Else
            DataGridVoucherList.CurrentPageIndex = 0
        End If
       
        DataGridVoucherList.DataBind()
        If DataGridVoucherList.PageCount <= 1 Then
            DataGridVoucherList.PagerStyle.Visible = False
        Else
            DataGridVoucherList.PagerStyle.Visible = True
        End If

        Me.lblPageIndex.Text = DataGridVoucherList.CurrentPageIndex + 1
        Me.lblPageAmount.Text = DataGridVoucherList.PageCount
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

        strfromdate = Me.txtFromDate.Text.ToString.Trim
        strtodate = Me.txtToDate.Text.ToString.Trim
        sel_vip_no = Convert.ToString(ViewState("SelVip")).Trim()
        sel_acct_id = Convert.ToString(ViewState("sel_acct_id")).Trim()
        strTop = Me.txtTop.Text.Trim()
        If Me.radTip.Checked = True Then
            strDaytype = "t"
        Else
            strDaytype = "i"
        End If
        strSortby = Me.lst_SortBy.SelectedValue.ToString.Trim()
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
        If Not MySession.UserID Is Nothing And Convert.ToString(MySession.UserID).Trim() <> "" Then
            vip_no = Convert.ToString(MySession.UserID).Trim()
        Else
            vip_no = "N"
        End If
        If Not Session("level_id") Is Nothing And Convert.ToString(Session("level_id")).Trim() <> "" Then
            level_id = Convert.ToString(Session("level_id")).Trim()
        Else
            level_id = "N"
        End If

        'Dim SortExpression As String
        'Dim SortDirection As String
        'SortExpression = Me.DataGridVoucherList.Attributes("SortExpression")
        'SortDirection = Me.DataGridVoucherList.Attributes("SortDirection")
        m_dataset = obj_DataSource.GetDriveReport(acct_id, sub_acct_id, sel_acct_id, group_flag, strfromdate, strtodate, strTop, strDaytype, strSortby)
        If Not m_dataset Is Nothing Then
            If m_dataset.Tables.Count > 0 Then
                m_DataTable = m_dataset.Tables(0)
                Me.grdDV = m_DataTable.DefaultView
                Session("m_datatable") = m_DataTable
                obj_DataSource = Nothing
                'If SortExpression <> "" Then
                '    m_DataTable.DefaultView.Sort = SortExpression & " " & SortDirection
                'End If

                If m_DataTable.Rows.Count = 0 Then

                    Dim strMessage As String = "<script language=""JavaScript"">alert('No Information Found!');" & _
                                               "history.go(-1);</script>"
                    ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage", strMessage)
                Else
                    Me.DataGridVoucherList.Visible = True
                    Me.trpage.Visible = True
                End If

            End If
           
        End If
        '## add by joey 3/13/2008
        If Me.DataGridVoucherList.CurrentPageIndex + 1 > Math.Ceiling(m_DataTable.Rows.Count / Me.DataGridVoucherList.PageSize) Then
            Me.ViewState("iPage") = 0
        End If

        Return m_DataTable.DefaultView
    End Function
    Protected Sub DataGridVoucherList_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGridVoucherList.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
            Dim CarNo As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "car_no")).Trim
            Dim DateType As String = Convert.ToString(IIf(Me.radTip.Checked, "t", "i")).Trim

            Dim lnkCarNo As HyperLink = CType(e.Item.FindControl("HyperLink1"), HyperLink)

            lnkCarNo.NavigateUrl = String.Format("DriveOfReport2.aspx?carno={0}&datetype={1}&fromdate={2}&todate={3}", CarNo, DateType, Me.txtFromDate.Text, Me.txtToDate.Text)
        End If
    End Sub


    Protected Sub DataGridVoucherList_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGridVoucherList.PageIndexChanged
        ViewState("iPage") = e.NewPageIndex
        LoadData()
        If Me.grdDV.Table.Columns.Contains(Me.hdnSort.Value.Replace(" DESC", "")) Then
            Me.grdDV.Sort = Me.hdnSort.Value
        End If
        Me.DataGridVoucherList.DataBind()
    End Sub

    Protected Sub DataGridVoucherList_SortCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles DataGridVoucherList.SortCommand
        Me.LoadData()
        If Me.hdnSort.Value = e.SortExpression Then
            Me.hdnSort.Value = e.SortExpression & " DESC"
        Else
            Me.hdnSort.Value = e.SortExpression 
        End If
        If Me.grdDV.Table.Columns.Contains(Me.hdnSort.Value.Replace(" DESC", "")) Then
            Me.grdDV.Sort = Me.hdnSort.Value
        End If
        Me.DataGridVoucherList.DataBind()
    End Sub

    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExport.Click
        Me.DataGridVoucherList.AllowPaging = False
        Me.LoadData()
        Common.GenerateCSVFile(Me, Me.DataGridVoucherList, "driversOfReport.csv")
    End Sub
End Class
