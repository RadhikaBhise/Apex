Imports Business
Imports DataAccess
Imports System.Data
Imports System.Data.SqlClient
Partial Class QSvip
    Inherits System.Web.UI.Page
    Private grdDV As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.btnSubmit.Attributes.Add("onclick", "return batchvalidate('" & Session("group_login_flag") & "','" & Me.txtFromDate.ClientID & "','" & Me.txtToDate.ClientID & "');")

        If MySession.AcctID Is Nothing Or MySession.AcctID.Length = 0 Then
            Response.Redirect("login.aspx")
        End If

        If Not Page.IsPostBack Then
            Me.txtFromDate.Text = Common.ShowDateTime(Now.AddMonths(-6), Common.DateTimeStyle.DateOnly)
            Me.txtToDate.Text = Common.ShowDateTime(Now, Common.DateTimeStyle.DateOnly)

            'Dim strgroupflag As String
            'Dim strAcct As String
            'Dim strSubAcct As String
            'Dim strSelAcct As String
            'Dim strlevel As String
            'Dim strVipno As String

            'strSelAcct = ""
            'If Not MySession.AcctID Is Nothing And Convert.ToString(MySession.AcctID).Trim() <> "" Then
            '    strAcct = Convert.ToString(MySession.AcctID).Trim()
            'Else
            '    strAcct = ""
            'End If
            'If Not MySession.SubAcctID Is Nothing And Convert.ToString(MySession.SubAcctID).Trim() <> "" Then
            '    strSubAcct = Convert.ToString(MySession.SubAcctID).Trim()
            'Else
            '    strSubAcct = ""
            'End If

            'If Not Session("group_login_flag") Is Nothing And Convert.ToString(Session("group_login_flag")).Trim() <> "" Then
            '    strgroupflag = Convert.ToString(Session("group_login_flag")).Trim()
            'Else
            '    strgroupflag = "N"
            'End If
            'If Not MySession.UserID Is Nothing And Convert.ToString(MySession.UserID).Trim() <> "" Then
            '    strVipno = Convert.ToString(MySession.UserID).Trim()
            'Else
            '    strVipno = ""
            'End If
            'If Not MySession.LevelID Is Nothing And Convert.ToString(MySession.LevelID).Trim() <> "" Then
            '    strlevel = Convert.ToString(MySession.LevelID).Trim()
            'Else
            '    strlevel = ""
            'End If
            'getVipNO(strAcct, strSubAcct, strSelAcct, strVipno, strgroupflag, strlevel)

            Me.getVipNO(MySession.AcctID, MySession.SubAcctID, MySession.AcctID, MySession.UserID, "", MySession.LevelID)

            Me.trData.Visible = False
        End If
        'End If
    End Sub

#Region "Report Search"

    Private Sub getVipNO(ByVal acctid, ByVal subacctid, ByVal selacctid, ByVal vipno, ByVal groupflag, ByVal level)
        Dim objAcct As New Users
        Dim objDS As New DataSet
        Dim strvalue As String
        Dim strtext As String

        objDS = objAcct.GetVipNo(acctid, subacctid, selacctid, vipno, groupflag, level)

        If Not objDS Is Nothing AndAlso objDS.Tables.Count > 0 AndAlso objDS.Tables(0).Rows.Count > 0 Then
            Dim n As Integer
            For n = 0 To objDS.Tables(0).Rows.Count - 1
                If Not IsDBNull(objDS.Tables(0).Rows(n).Item(0)) Then
                    strvalue = objDS.Tables(0).Rows(n).Item(0).ToString.Trim()
                    strtext = (objDS.Tables(0).Rows(n).Item("lname").ToString.Trim() & "," & " " & _
                            objDS.Tables(0).Rows(n).Item("fname").ToString.Trim()).PadRight(30, System.Web.HttpUtility.HtmlDecode("&nbsp;")) & _
                            " [VIP #]:" & objDS.Tables(0).Rows(n).Item(0).ToString.Trim()
                    Me.ddlvipno.Items.Add(New ListItem(strtext, strvalue))
                End If
            Next
        Else
            Dim strMessage As String = "<script language=""JavaScript"">history.go(-1);" & _
                                                       "alert('No Comp.ID associated with this acount!');</script>"

            ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage", strMessage)
        End If
    End Sub

    'Private Sub getSelectAcctid()
    '    Dim objAcct As New Users
    '    Dim objDS As New DataSet
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
    '    Dim strselacct As String = ""
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


    'Dim strSelAcct As String
    'strSelAcct = getSelectAcct()
    'Dim strvipno As String
    'Dim strArgs As String
    'strvipno = Me.ddlvipno.SelectedValue.ToString.Trim()
    'strArgs = "SelAcctId=" & strSelAcct & "&SelVip=" & strvipno

    'Response.Redirect("vipList.aspx?" & strArgs & "&Req=QueryStatistics")
    'Me.tbReport.Visible = True
    'Me.tbSearch.Visible = False

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click
        Me.LoadData()
    End Sub


    'Protected Sub listAcct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles listAcct.SelectedIndexChanged
    '    Dim strgroupflag As String
    '    Dim strAcct As String
    '    Dim strSubAcct As String
    '    Dim strSelAcct As String
    '    Dim strVip As String
    '    Dim strLevel As String


    '    strSelAcct = ""
    '    If Not Session("acct_id") Is Nothing And Convert.ToString(Session("acct_id")).Trim() <> "" Then
    '        strAcct = Convert.ToString(Session("acct_id")).Trim()
    '    Else
    '        strAcct = ""
    '    End If
    '    If Not Session("sub_acct_id") Is Nothing And Convert.ToString(Session("sub_acct_id")).Trim() <> "" Then
    '        strSubAcct = Convert.ToString(Session("sub_acct_id")).Trim()
    '    Else
    '        strSubAcct = ""
    '    End If
    '    If Not Session("vip_no") Is Nothing And Convert.ToString(Session("vip_no")).Trim() <> "" Then
    '        strVip = Convert.ToString(Session("vip_no")).Trim()
    '    Else
    '        strVip = ""
    '    End If
    '    If Not Session("level_id") Is Nothing And Convert.ToString(Session("level_id")).Trim() <> "" Then
    '        strLevel = Convert.ToString(Session("level_id")).Trim()
    '    Else
    '        strLevel = ""
    '    End If
    '    If Not Session("group_login_flag") Is Nothing And Convert.ToString(Session("group_login_flag")).Trim() <> "" Then
    '        strgroupflag = Convert.ToString(Session("group_login_flag")).Trim()
    '    Else
    '        strgroupflag = "N"
    '    End If

    '    strSelAcct = ""

    '    getVipNO(strAcct, strSubAcct, strSelAcct, strVip, strgroupflag, strLevel)

    'End Sub

#End Region

#Region "Report Details"

    Private Sub LoadData()
        Using rpt As New Report
            Dim ds As DataSet = rpt.GetVipList(MySession.AcctID, MySession.SubAcctID, Me.ddlvipno.SelectedValue, _
                        MySession.UserID, MySession.LevelID, Me.txtFromDate.Text.Trim, Me.txtToDate.Text.Trim, "t")

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

    '    sel_vip_no = Me.ddlvipno.SelectedValue.ToString
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
    '    m_dataset = obj_DataSource.GetVipList(acct_id, sub_acct_id, sel_acct_id, sel_vip_no, vip_no, group_flag, level_id, Me.txtFromDate.Text.Trim, Me.txtToDate.Text.Trim, "t")
    '    If Not m_dataset Is Nothing Then
    '        If m_dataset.Tables.Count > 0 Then
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
    '            obj_DataSource = Nothing

    '            'If SortExpression <> "" Then
    '            '    m_DataTable.DefaultView.Sort = SortExpression & " " & SortDirection
    '            'End If

    '            If m_DataTable.Rows.Count = 0 Then
    '                Dim strMessage As String = "<script language=""JavaScript"">alert('No Information Found!');</script>"
    '                ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage", strMessage)
    '                Me.DataGridVoucherList.DataSource = Nothing
    '                Me.DataGridVoucherList.DataBind()
    '            Else
    '                Me.trData.Visible = True
    '            End If
    '        End If
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

    '    Dim strFileName As String = "DriveOfReport.csv"
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

#End Region

End Class
