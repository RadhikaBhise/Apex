Imports System.Data
Imports System.Drawing.Graphics
Imports Business
Partial Class zoneOfReport2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            ViewState("zone") = Trim(Request.QueryString("zone"))
            ViewState("pu") = Trim(Request.QueryString("pu"))
            ViewState("do") = Trim(Request.QueryString("do"))
            ViewState("pucity") = Trim(Request.QueryString("pucity"))
            ViewState("docity") = Trim(Request.QueryString("docity"))
        End If
        If Me.DataGrid_VoucherList.Attributes("SortExpression") = "" Then
            Me.DataGrid_VoucherList.Attributes("SortExpression") = "confirmation_no"
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
        Dim strAcct_ID As String = Trim(Session("Acct_ID"))
        Dim strSub_acct_id As String = Trim(Session("sub_acct_id"))
        Dim strZone As String = Convert.ToString(ViewState("zone")).Trim()
        Dim strPu As String = Convert.ToString(ViewState("pu")).Trim()
        Dim strDo As String = Convert.ToString(ViewState("do")).Trim()
        Dim strPucity As String = Convert.ToString(ViewState("pucity")).Trim()
        Dim strDocity As String = Convert.ToString(ViewState("docity")).Trim()
        Dim strSelectAcct As String = Convert.ToString(Session("select_acct")).Trim()
        Dim strGroupFlag As String



        If Session("group_login_flag") Is Nothing Then
            strGroupFlag = "N"
        ElseIf Convert.ToString(Session("group_login_flag")).Trim() = "" Then
            strGroupFlag = "N"
        Else
            strGroupFlag = Convert.ToString(Session("group_login_flag")).Trim()
        End If

        Dim SortExpression As String
        Dim SortDirection As String
        SortExpression = Me.DataGrid_VoucherList.Attributes("SortExpression")
        SortDirection = Me.DataGrid_VoucherList.Attributes("SortDirection")

        '## 12/17/2007  disabled errors (yang)
        'm_dataset = obj_DataSource.GetZoneReport2(strAcct_ID, strSub_acct_id, strSelectAcct, strGroupFlag, strZone, strPu, strDo, strPucity, strDocity)

        'If Not m_dataset Is Nothing Then
        '    If m_dataset.Tables.Count > 0 Then
        '        m_DataTable = m_dataset.Tables(0)
        '        m_DataTable2 = m_dataset.Tables(1)
        '        If m_DataTable2.Rows.Count > 0 Then
        '            Dim n As Integer
        '            For n = 0 To m_DataTable2.Rows.Count - 1
        '                If IsDBNull(m_DataTable2.Rows(n).Item("req_desc")) Then
        '                    Session("strfield" & n + 1 & "name") = ""
        '                ElseIf m_DataTable2.Rows(n).Item("req_desc").ToString.Trim() = "" Then
        '                    Session("strfield" & n + 1 & "name") = ""
        '                Else
        '                    Session("strfield" & n + 1 & "name") = m_DataTable2.Rows(n).Item("req_desc")
        '                End If
        '            Next

        '        Else
        '            Session("strfield1name") = ""
        '            Session("strfield2name") = ""
        '            Session("strfield3name") = ""
        '            Session("strfield4name") = ""
        '            Session("strfield5name") = ""
        '            Session("strfield6name") = ""
        '        End If
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
        If e.Item.ItemType = ListItemType.Header Then
            If Not Session("strfield1name") Is Nothing And Convert.ToString(Session("strfield1name")).Trim() <> "" Then
                e.Item.Cells(15).Text = Convert.ToString(Session("strfield1name")).Trim()
            Else
                DataGrid_VoucherList.Columns(15).Visible = False
            End If
            If Not Session("strfield2name") Is Nothing And Convert.ToString(Session("strfield2name")).Trim() <> "" Then
                e.Item.Cells(16).Text = Convert.ToString(Session("strfield2name")).Trim()
            Else
                DataGrid_VoucherList.Columns(16).Visible = False
            End If
            If Not Session("strfield3name") Is Nothing And Convert.ToString(Session("strfield3name")).Trim() <> "" Then
                e.Item.Cells(17).Text = Convert.ToString(Session("strfield3name")).Trim()
            Else
                DataGrid_VoucherList.Columns(17).Visible = False
            End If
            If Not Session("strfield4name") Is Nothing And Convert.ToString(Session("strfield4name")).Trim() <> "" Then
                e.Item.Cells(18).Text = Convert.ToString(Session("strfield4name")).Trim()
            Else
                DataGrid_VoucherList.Columns(18).Visible = False
            End If
            If Not Session("strfield5name") Is Nothing And Convert.ToString(Session("strfield5name")).Trim() <> "" Then
                e.Item.Cells(19).Text = Convert.ToString(Session("strfield5name")).Trim()
            Else
                DataGrid_VoucherList.Columns(19).Visible = False
            End If
            If Not Session("strfield6name") Is Nothing And Convert.ToString(Session("strfield6name")).Trim() <> "" Then
                e.Item.Cells(20).Text = Convert.ToString(Session("strfield6name")).Trim()
            Else
                DataGrid_VoucherList.Columns(20).Visible = False
            End If
        End If
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

    Protected Sub DataGrid_VoucherList_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid_VoucherList.PageIndexChanged
        DataGrid_VoucherList.DataSource = GetDataSource()
        Me.DataGrid_VoucherList.CurrentPageIndex = e.NewPageIndex

        DataGrid_VoucherList.DataBind()

    End Sub

End Class
