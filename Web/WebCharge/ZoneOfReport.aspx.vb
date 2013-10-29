Imports System.Data
Imports System.Drawing.Graphics
Imports Business
Partial Class ZoneOfReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.IsPostBack Then
            ViewState("sel_acct_id") = Trim(Request.QueryString("SelAcctId"))
            Session("select_acct") = Trim(Request.QueryString("SelAcctId"))
            ViewState("fromdate") = Trim(Request.QueryString("Fromdate"))
            ViewState("todate") = Trim(Request.QueryString("Todate"))
            ViewState("daytype") = Trim(Request.QueryString("Daytype"))
            ViewState("zone") = Trim(Request.QueryString("Zone"))
            ViewState("pstate") = Trim(Request.QueryString("Pstate"))
            ViewState("dstate") = Trim(Request.QueryString("Dstate"))
            ViewState("pcity") = Trim(Request.QueryString("Pcity"))
            ViewState("dcity") = Trim(Request.QueryString("Dcity"))
            ViewState("reser") = Trim(Request.QueryString("Reser"))
        End If
        If Me.DataGrid_VoucherList.Attributes("SortExpression") = "" Then
            Me.DataGrid_VoucherList.Attributes("SortExpression") = "no_rides"
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
        Dim strReser As String
        Dim strDaytype As String
        Dim strZone As String
        Dim strPstate As String
        Dim strDstate As String
        Dim strPcity As String
        Dim strDcity As String


        strfromdate = Convert.ToString(ViewState("fromdate")).Trim()
        strtodate = Convert.ToString(ViewState("todate")).Trim()
        sel_vip_no = Convert.ToString(ViewState("SelVip")).Trim()
        sel_acct_id = Convert.ToString(ViewState("SelAcct")).Trim()
        strReser = Convert.ToString(ViewState("reser")).Trim()
        strDaytype = Convert.ToString(ViewState("daytype")).Trim()
        strZone = Convert.ToString(ViewState("zone")).Trim()
        strPstate = Convert.ToString(ViewState("pstate")).Trim()
        strDstate = Convert.ToString(ViewState("dstate")).Trim()
        strPcity = Convert.ToString(ViewState("pcity")).Trim()
        strDcity = Convert.ToString(ViewState("dcity")).Trim()
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

        '## 12/17/2007  disabled errors (yang)
        'm_dataset = obj_DataSource.GetZoneReport(acct_id, sub_acct_id, sel_acct_id, group_flag, strfromdate, strtodate, strDaytype, strZone, strPstate, strDstate, strPcity, strDcity, strReser)
        'If Not m_dataset Is Nothing Then
        '    If m_dataset.Tables.Count > 0 Then
        '        m_DataTable = m_dataset.Tables(0)

        '        Session("m_datatable") = m_DataTable
        '        obj_DataSource = Nothing
        '        'If ViewState("SortExprValue") <> "" Then
        '        '    m_DataTable.DefaultView.Sort = ViewState("SortExprValue")
        '        'End If
        '        If SortExpression <> "" Then
        '            m_DataTable.DefaultView.Sort = SortExpression & " " & SortDirection
        '        End If

        '        If m_DataTable.Rows.Count = 0 Then
        '            Dim strMessage As String = "<script language=""JavaScript"">alert('No Information Found!');" & _
        '                                       "history.go(-1);</script>"
        '            RegisterStartupScript("PopUpMessage", strMessage)

        '        End If
        '    End If
        'End If

        Return m_DataTable.DefaultView
    End Function

    Protected Sub DataGrid_VoucherList_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid_VoucherList.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim btn As HyperLink = CType(e.Item.FindControl("HyperLink1"), HyperLink)
            Dim lbl As Label = CType(e.Item.FindControl("lbldo"), Label)
            Dim strpu As String
            Dim strZone As String
            Dim strDo As String
            Dim postpu As String
            Dim postdo As String
            Dim strpucity As String
            Dim strdocity As String

            strZone = Convert.ToString(ViewState("zone")).Trim()
            If strZone = "3" Or strZone = "4" Then
                strpu = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_city_airline")) & ","
                strpucity = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_city_airline"))
            End If
            strpu = strpu & Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_county_airp"))
            If strZone = "2" Or strZone = "4" Then
                strDo = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_city_airline")) & ","
                strdocity = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_city_airline"))
            End If
            strDo = strDo & Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_county_airp"))

            btn.Text = strpu
            lbl.Text = strDo

            postpu = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_county_airp"))
            postdo = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_county_airp"))

            btn.NavigateUrl = "zoneOfReport2.aspx?zone=" & strZone & "&pu=" & postpu & "&do=" & postdo & "&pucity=" & strpucity & "&docity=" & strdocity

        End If
    End Sub

    Protected Sub DataGrid_VoucherList_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid_VoucherList.PageIndexChanged
        DataGrid_VoucherList.DataSource = GetDataSource()
        Me.DataGrid_VoucherList.CurrentPageIndex = e.NewPageIndex

        DataGrid_VoucherList.DataBind()

    End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim strLevelID As String = Trim(Session("level_id"))
        Dim strFileName As String = "Account Zone Analysis Report"
        Dim obj_DataGrid As DataGrid = DataGrid_VoucherList

        If strLevelID = String.Empty Then
            'ERROR: Session "Acct_ID" missing
            'Response.Redirect("Login.aspx?LogOff=1")
            Exit Sub
        End If

        If obj_DataGrid Is Nothing Then
            'ERROR: Session "ojb_DataGrid"
            Exit Sub
        End If

        Response.Clear()
        Response.Buffer = True
        Response.Charset = "utf-8"
        Response.AppendHeader("Content-Disposition", "attachment;filename=" & strFileName & ".xls")
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8")
        Response.ContentType = "application/ms-excel"

        obj_DataGrid.EnableViewState = False

        obj_DataGrid.AllowPaging = False
        obj_DataGrid.DataBind()

        Dim strTmp As String

        Dim obj_Col As DataGridColumn
        For Each obj_Col In obj_DataGrid.Columns
            Response.Write(Adjust(obj_Col.HeaderText) & vbTab)
        Next
        Response.Write(vbCrLf)

        Dim obj_Row As DataGridItem
        Dim obj_Cell As TableCell
        For Each obj_Row In obj_DataGrid.Items
            For Each obj_Cell In obj_Row.Cells
                Dim obj_Ctrl As Control
                For Each obj_Ctrl In obj_Cell.Controls
                    If obj_Ctrl.GetType Is GetType(HyperLink) Then
                        Dim obj_hplnk As HyperLink
                        obj_hplnk = CType(obj_Ctrl, HyperLink)
                        Response.Write(Adjust(obj_hplnk.Text))
                    ElseIf obj_Ctrl.GetType Is GetType(Label) Then
                        Dim obj_Label As Label
                        obj_Label = CType(obj_Ctrl, Label)
                        Response.Write(Adjust(obj_Label.Text))
                    End If
                Next
                Response.Write(Adjust(obj_Cell.Text) & vbTab)
            Next
            Response.Write(vbCrLf)
        Next

        For Each obj_Col In obj_DataGrid.Columns
            Response.Write(Adjust(obj_Col.FooterText) & vbTab)
        Next
        Response.Write(vbCrLf)

        Response.End()

    End Sub
    Public Function Adjust(ByVal strText As String) As String
        Dim strTmp As String
        strTmp = strText.Trim
        strTmp = Replace(strTmp, "'", "''")
        strTmp = Replace(strTmp, "&nbsp;", " ")
        Return strTmp
    End Function
End Class
