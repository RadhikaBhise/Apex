Imports Business
Imports Business.Common
Imports DataAccess
Imports System.Data
Imports System.Data.SqlClient

Partial Class RptOfPass
    Inherits System.Web.UI.Page

    Private dv As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Me.btn_Submit.Attributes.Add("onclick", "return batchvalidate('" & Session("group_login_flag") & "');")
        'Me.btn_Submit.Attributes.Add("OnClick", "return DateValidateEmployee('" & Me.txt_Top.ClientID & "','" & Me.txt_FromTrip.ClientID & "','" & Me.txt_ToTrip.ClientID & "');")

        If Session("acct_id") Is Nothing AndAlso Session("account_list") Is Nothing Then
            Response.Redirect("login.aspx")
        End If

        If Not Page.IsPostBack Then

            Me.trData.Visible = False
            txtFromDate.Text = ShowDateTime(Now.AddMonths(-6), DateTimeStyle.DateOnly)
            txtToDate.Text = ShowDateTime(Now, DateTimeStyle.DateOnly)

            'If Convert.ToString(Session("group_login_flag")).Trim() = "Y" Then
            '    getSelectAcctid()
            '    Me.trSelAcct.Visible = True
            '    Me.trSelList.Visible = True
            'Else
            '    Me.trSelAcct.Visible = False
            '    Me.trSelList.Visible = False
            'End If
        End If

        Me.btn_Submit.Attributes.Add("onclick", "javascript:return SubmitValidation('" & Me.txtTopCount.ClientID & "');")
    End Sub

    'Private Sub getSelectAcctid()
    '    Dim objAcct As New Users
    '    Dim objDS As New dataset
    '    Dim strgroupid As Int32
    '    Dim strvalue As String
    '    Dim strtext As String

    '    strgroupid = Convert.ToInt32(Session("group_id"))
    '    objDS = objAcct.GetSelectAcct(strgroupid)

    '    If Not objDS Is Nothing Then
    '        If objDS.Tables.Count > 0 Then
    '            If objDS.Tables(0).Rows.Count > 0 Then
    '                Me.listAcct.DataSource = objDS.Tables(0)
    '                With objDS.Tables(0)
    '                    Dim n As Integer
    '                    For n = 0 To .Rows.Count - 1
    '                        strvalue = .Rows(n).Item("acct_id").ToString.Trim()
    '                        strtext = .Rows(n).Item("acct_id").ToString.Trim() & " - " & .Rows(n).Item("name").ToString.Trim()
    '                        Me.listAcct.Items.Add(New ListItem(strtext, strvalue))
    '                    Next
    '                End With
    '            End If
    '        End If
    '    End If
    'End Sub

    'Protected Function getSelectAcct() As String
    '    Dim strselacct As String
    '    If Convert.ToString(Session("group_login_flag")).Trim() = "Y" Then
    '        Dim n As Integer
    '        For n = 0 To Me.listAcct.Items.Count - 1
    '            If Me.listAcct.Items(n).Selected Then
    '                strselacct = strselacct & Me.listAcct.Items(n).Value.ToString.Trim() & ","
    '            End If
    '        Next
    '        strselacct = Mid(strselacct, 1, strselacct.Length - 1)
    '    Else
    '        strselacct = ""
    '    End If
    '    Return strselacct
    'End Function

    Protected Sub btn_Submit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_Submit.Click
        'Dim strSelAcct As String
        'Dim strFromdate As String
        'Dim strTodate As String
        'Dim strArgs As String
        'Dim strTop As String
        'Dim strDaytype As String
        'Dim strSort As String


        'strSelAcct = getSelectAcct()
        'strFromdate = Me.txt_FromTrip.Text.Trim()
        'strTodate = Me.txt_ToTrip.Text.Trim()
        'strTop = Me.txt_Top.Text.Trim()
        'If Me.radTip.Checked = True Then
        '    strDaytype = "t"
        'Else
        '    strDaytype = "i"
        'End If
        'strSort = Me.lst_SortBy.SelectedValue.ToString.Trim()

        'strArgs = "SelAcctId=" & strSelAcct & "&Fromdate=" & strFromdate & "&Todate=" & strTodate & "&Top=" & strTop & "&Daytype=" & strDaytype & "&Sortby=" & strSort

        'Response.Redirect("EmpOfReport.aspx?" & strArgs & "&Req=QueryStatistics")

        Me.LoadData()
    End Sub

    'Protected Sub btn_Reset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Reset.Click
    '    Response.Redirect("RptOfEmp.aspx", True)
    'End Sub

#Region " DataGrid Events "

    Protected Sub grdData_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdData.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
            Dim VipNo As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "vip_no")).Trim
            Dim DateType As String = Convert.ToString(IIf(Me.radTip.Checked, "t", "i")).Trim

            Dim lnkVipNo As HyperLink = CType(e.Item.FindControl("lnkVipNo"), HyperLink)

            lnkVipNo.NavigateUrl = String.Format("empOfReport2.aspx?vipno={0}&datetype={1}&fromdate={2}&todate={3}", VipNo, DateType, Me.txtFromDate.Text, Me.txtToDate.Text)
        End If
    End Sub

    Protected Sub grdData_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdData.PageIndexChanged
        Try
            Me.grdData.CurrentPageIndex = e.NewPageIndex

            Me.LoadData()

            If Me.dv.Table.Columns.Contains(Me.hdnSort.Value.Replace(" DESC", "")) Then
                Me.dv.Sort = Me.hdnSort.Value
            End If
            Me.grdData.DataBind()
        Catch
        End Try
    End Sub

    Protected Sub grdData_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdData.SortCommand
        If Me.hdnSort.Value = e.SortExpression Then
            Me.hdnSort.Value = e.SortExpression & " DESC"
        Else
            Me.hdnSort.Value = e.SortExpression
        End If

        Me.LoadData()
        If Me.dv.Table.Columns.Contains(Me.hdnSort.Value.Replace(" DESC", "")) Then
            Me.dv.Sort = Me.hdnSort.Value
        End If
        Me.grdData.DataBind()
    End Sub

    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExport.Click
        Me.grdData.AllowPaging = False
        Me.LoadData()
        Common.GenerateCSVFile(Me, Me.grdData, "PassOfReport.csv")
    End Sub

#End Region

#Region " Private Functions "

    Private Sub LoadData()

        Dim ds As DataSet
        Dim GroupFlag As String = "N"
        Dim DateType As String = "t"

        If Not Session("group_login_flag") Is Nothing AndAlso _
                    Convert.ToString(Session("group_login_flag")).Trim() <> "" Then
            GroupFlag = Convert.ToString(Session("group_login_flag")).Trim()
        End If

        If Me.radTip.Checked Then
            DateType = "t"
            Me.lblTitle.Text = "Your Requested Top " & Me.txtTopCount.Text & " Employee(s) Report (By Total Voucher Amount)".Replace(" ", "&nbsp;")
        Else
            DateType = "i"
            Me.lblTitle.Text = "Your Requested Top " & Me.txtTopCount.Text & " Employee(s) Report (By Total Number of Rides)".Replace(" ", "&nbsp;")
        End If

        Using rpt As New Report

            ds = rpt.GetEMPReport(MySession.AcctID, MySession.SubAcctID, MySession.AcctID, GroupFlag, Me.txtFromDate.Text, Me.txtToDate.Text, Me.txtTopCount.Text, DateType, Me.ddlSortBy.SelectedValue)

            If Not ds Is Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                If Math.Ceiling(ds.Tables(0).Rows.Count / Me.grdData.PageSize) < Me.grdData.CurrentPageIndex + 1 Then
                    Me.grdData.CurrentPageIndex = 0
                End If

                Me.dv = ds.Tables(0).DefaultView
                Me.grdData.DataSource = Me.dv
                Me.grdData.DataBind()

                Me.trData.Visible = True
                Me.lbl_PageAmount.Text = Me.grdData.PageCount.ToString
                Me.lbl_PageIndex.Text = Convert.ToString(Me.grdData.CurrentPageIndex + 1)
            Else
                Me.trData.Visible = False
                Dim strMessage As String = "<script type='text/javascript' language='javascript'>alert('No information Found!');</script>"
                Me.ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage", strMessage)
            End If
        End Using
    End Sub

#End Region
   
End Class
