Imports Business
Imports DataAccess
Imports System.Data
Imports System.Data.SqlClient
Partial Class RptOfCustom
    Inherits System.Web.UI.Page
    Private grdDV As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  Me.btn_Submit.Attributes.Add("onclick", "return batchvalidate('" & Session("group_login_flag") & "');")
        Me.btnSubmit.Attributes.Add("OnClick", "return DateValidateEmployee('" & Me.txtTop.ClientID & "','" & Me.txtFromDate.ClientID & "','" & Me.txtToDate.ClientID & "');")

        If Session("acct_id") Is Nothing Then
            Response.Redirect("login.aspx")
        End If

        If Not Page.IsPostBack Then
         
            Me.txtFromDate.Text = Common.ShowDateTime(Now.AddMonths(-6), Common.DateTimeStyle.DateOnly)
            Me.txtToDate.Text = Common.ShowDateTime(Now, Common.DateTimeStyle.DateOnly)
            If Convert.ToString(Session("group_login_flag")).Trim() = "Y" Then
                getSelectAcctid()
                'Me.trSelAcct.Visible = True
                'Me.trSelList.Visible = True
                Me.trCusRef.Visible = False
                Me.trCusList.Visible = False
            Else
                Dim strgroupflag As String
                Dim strAcct As String
                Dim strSubAcct As String
                Dim strSelAcct As String

                strSelAcct = ""
                If Not Session("acct_id") Is Nothing And Convert.ToString(Session("acct_id")).Trim() <> "" Then
                    strAcct = Convert.ToString(Session("acct_id")).Trim()
                Else
                    strAcct = ""
                End If
                If Not Session("sub_acct_id") Is Nothing And Convert.ToString(Session("sub_acct_id")).Trim() <> "" Then
                    strSubAcct = Convert.ToString(Session("sub_acct_id")).Trim()
                Else
                    strSubAcct = ""
                End If

                If Not Session("group_login_flag") Is Nothing And Convert.ToString(Session("group_login_flag")).Trim() <> "" Then
                    strgroupflag = Convert.ToString(Session("group_login_flag")).Trim()
                Else
                    strgroupflag = "N"
                End If
                Call getCusRef(strAcct, strSubAcct, strSelAcct, strgroupflag)
                ' Me.trSelAcct.Visible = False
                ' Me.trSelList.Visible = False
                Me.trCusRef.Visible = True
                Me.trCusList.Visible = True
            End If
        End If
    End Sub
    Private Sub getSelectAcctid()
        Dim objAcct As New Users
        Dim objDS As New dataset
        Dim strgroupid As Int32
        Dim strvalue As String
        Dim strtext As String

        strgroupid = Convert.ToInt32(Session("group_id"))
        objDS = objAcct.GetSelectAcct(strgroupid)

        If Not objDS Is Nothing Then
            If objDS.Tables.Count > 0 Then
                If objDS.Tables(0).Rows.Count > 0 Then
                    'Me.listAcct.DataSource = objDS.Tables(0)
                    With objDS.Tables(0)
                        Dim n As Integer
                        For n = 0 To .Rows.Count - 1
                            strvalue = .Rows(n).Item("acct_id").ToString.Trim()
                            strtext = .Rows(n).Item("acct_id").ToString.Trim() & " - " & .Rows(n).Item("name").ToString.Trim()
                            'Me.listAcct.Items.Add(New ListItem(strtext, strvalue))
                        Next
                    End With
                End If
            End If
        End If
    End Sub
    Private Sub getCusRef(ByVal acctid, ByVal subacctid, ByVal selacctid, ByVal groupflag)
        Dim objAcct As New Users
        Dim objDS As New DataSet
        Dim strvalue As String
        Dim strtext As String

        objDS = objAcct.GetCusRef(acctid, subacctid, selacctid, groupflag)
        If Not objDS Is Nothing Then
            If objDS.Tables.Count > 0 Then
                If objDS.Tables(0).Rows.Count > 0 Then
                    Dim n As Integer
                    For n = 0 To objDS.Tables(0).Rows.Count - 1
                        If Not IsDBNull(objDS.Tables(0).Rows(n).Item(0)) Then
                            strvalue = n + 1
                            strtext = objDS.Tables(0).Rows(n).Item(0).ToString.Trim()
                            Me.lst_CmpReq.Items.Add(New ListItem(strtext, strvalue))
                        End If
                    Next
                    Me.trCusRef.Visible = True
                    Me.trCusList.Visible = True
                Else
                    Response.Redirect("default.aspx?msg=nocomp")
                    'Dim strMessage As String = "<script language=""JavaScript"">history.go(-1);" & _
                    '                                           "alert('No Comp.ID associated with this acount!');</script>"
                    'RegisterStartupScript("PopUpMessage", strMessage)
                End If
            Else
                Response.Redirect("default.aspx?msg=nocomp")
                'Dim strMessage As String = "<script language=""JavaScript"">history.go(-1);" & _
                '                                                               "alert('No Comp.ID associated with this acount!');</script>"
                'RegisterStartupScript("PopUpMessage", strMessage)
            End If
        Else
            Response.Redirect("default.aspx?msg=nocomp")
            'Dim strMessage As String = "<script language=""JavaScript"">history.go(-1);" & _
            '                                                               "alert('No Comp.ID associated with this acount!');</script>"
            'RegisterStartupScript("PopUpMessage", strMessage)
        End If
    End Sub
    'Protected Sub listAcct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles listAcct.SelectedIndexChanged
    '    Dim strgroupflag As String
    '    Dim strAcct As String
    '    Dim strSubAcct As String
    '    Dim strSelAcct As String

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

    '    If Not Session("group_login_flag") Is Nothing And Convert.ToString(Session("group_login_flag")).Trim() <> "" Then
    '        strgroupflag = Convert.ToString(Session("group_login_flag")).Trim()
    '    Else
    '        strgroupflag = "N"
    '    End If

    '    'strSelAcct = getSelectAcct()

    '    Call getCusRef(strAcct, strSubAcct, strSelAcct, strgroupflag)

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

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click
        Dim date_FromTrip As String
        Dim date_ToTrip As String
        Dim str_top As String
        Dim strsort As String
        Dim strMessage As String

        date_FromTrip = Trim(Me.txtFromDate.Text.ToString)
        date_ToTrip = Trim(Me.txtToDate.Text.ToString)
      
        str_top = Me.txtTop.Text.Trim()
        strsort = Me.lst_SortBy.SelectedValue.ToString.Trim()

        MySession.CompID = Trim(Me.lst_CmpReq.SelectedItem.ToString)

        If Not Me.lst_CmpReq.Items.Count > 0 Then
            strMessage = "<script language=""JavaScript"">alert('No information about the ACCOUNT! Please try again...');</script>"

            RegisterStartupScript("PopUpMessage", strMessage)
        Else
            'strArgs = "custom=" & Trim(Me.lst_CmpReq.SelectedValue.ToString) & "&FromDate=" & date_FromTrip & "&ToDate=" & date_ToTrip & "&SelAcctId=" & strSelAcct & "&DateType=" & strDatetype & "&Sortby=" & strsort & "&Top=" & str_top
            'Response.Redirect("CustomerOfReport.aspx?" & strArgs & "&Req=report")
            Me.LoadData()
        End If
    End Sub

#Region "Report Details"

    Private Sub LoadData()
        Me.trdata.Visible = True
        Dim top As String = Me.txtTop.Text.Trim()
        Me.lbl_TabCap.Text = "Your Requested Top " & Convert.ToString(top).Trim() & " Employee(s) Report"
        If Convert.ToString(ViewState("sortby")).Trim() = "1" Then
            Me.lbl_TabCap.Text = Me.lbl_TabCap.Text & " (By Total Voucher Amount):"
        Else
            Me.lbl_TabCap.Text = Me.lbl_TabCap.Text & " (By Total Number of Rides):"
        End If
        If Me.DataGrid_InvoiceList.Attributes("SortExpression") = "" Then
            Me.DataGrid_InvoiceList.Attributes("SortExpression") = "totalBase"
            Me.DataGrid_InvoiceList.Attributes("SortDirection") = "asc"
        End If
        Me.LoadDefault()
    End Sub

    Private Sub LoadDefault()
        With Me.DataGrid_InvoiceList
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
        Me.lbl_PageIndex.Text = DataGrid_InvoiceList.CurrentPageIndex + 1
        Me.lbl_PageAmount.Text = DataGrid_InvoiceList.PageCount
    End Sub
    Public Function GetDataSource() As DataView
        Dim FromTrip As String
        Dim ToTrip As String
        Dim level_id As String
        Dim vip_no As String
        Dim acct_id As String
        Dim sub_acct_id As String
        Dim sel_acct_id As String
        Dim group_flag As String
        ' Dim str_SearchValue As String
        Dim str_Comreq As String
        Dim strDatetype As String
        Dim strSort As String
        Dim strTop As String
        Dim obj_DataSource As New Report
        Dim dv As New DataView
        Dim m_dataset As New DataSet
        Dim m_DataTable As New DataTable
        Dim m_DataTable2 As New DataTable


        FromTrip = Me.txtFromDate.Text.Trim()
        ToTrip = Me.txtToDate.Text.Trim()
        str_Comreq = Me.lst_CmpReq.SelectedValue.ToString
        sel_acct_id = Convert.ToString(ViewState("sel_acct_id")).Trim()
        If Me.radTrip.Checked = True Then
            strDatetype = "t"
        End If
        If Me.radInvoice.Checked = True Then
            strDatetype = "i"
        End If
        strTop = Me.txtTop.Text.Trim()
        strSort = Me.lst_SortBy.SelectedValue.ToString.Trim()
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
        SortExpression = Me.DataGrid_InvoiceList.Attributes("SortExpression")
        SortDirection = Me.DataGrid_InvoiceList.Attributes("SortDirection")
        m_dataset = obj_DataSource.GetCustomReport(FromTrip, ToTrip, group_flag, acct_id, sub_acct_id, sel_acct_id, str_Comreq, strSort, strTop, strDatetype)

        If Not m_dataset Is Nothing Then
            If m_dataset.Tables.Count > 0 Then


                m_DataTable = m_dataset.Tables(0)
                Me.grdDV = m_DataTable.DefaultView
                Session("m_datatable") = m_DataTable
                obj_DataSource = Nothing
                If SortExpression <> "" Then
                    m_DataTable.DefaultView.Sort = SortExpression & " " & SortDirection
                End If

                If m_DataTable.Rows.Count = 0 Then
                    Dim strMessage As String = "<script language=""JavaScript"">alert('No information about the ACCOUNT! Please try again...');" & _
                                               "history.go(-1);</script>"
                    RegisterStartupScript("PopUpMessage", strMessage)

                End If
          
            End If
        End If

        '## add by joey 3/13/2008
        If Me.DataGrid_InvoiceList.CurrentPageIndex + 1 > Math.Ceiling(m_DataTable.Rows.Count / Me.DataGrid_InvoiceList.PageSize) Then
            Me.ViewState("iPage") = 0
        End If

        Return m_DataTable.DefaultView
    End Function
  

    Protected Sub DataGrid_InvoiceList_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid_InvoiceList.ItemDataBound
        If e.Item.ItemType = ListItemType.Header Then
            If Convert.ToString(MySession.CompID).Trim() <> "" Then
                e.Item.Cells(0).Text = Convert.ToString(MySession.CompID).Trim()
            Else
                e.Item.Cells(0).Text = ""
            End If
        End If

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim objlink As New HyperLink
            objlink = CType(e.Item.FindControl("HyperLink1"), HyperLink)
            Dim strcomp As String
            Dim str_Comreq As String = Me.lst_CmpReq.SelectedValue.ToString
            strcomp = "comp_id_" & Convert.ToString(str_Comreq).Trim()
            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, strcomp)) Then
                objlink.Text = Convert.ToString(DataBinder.Eval(e.Item.DataItem, strcomp))
            Else
                objlink.Text = ""
            End If
            Dim DateType As String = Convert.ToString(IIf(Me.radTrip.Checked, "t", "i")).Trim
            'objlink.NavigateUrl = "CustomerOfReport2.aspx?com_id=" & Convert.ToString(str_Comreq).Trim() & _
            '                      "&comtext=" & Convert.ToString(DataBinder.Eval(e.Item.DataItem, strcomp) & "&name=" & Me.lst_CmpReq.SelectedItem.ToString & "&datetype=" & Convert.ToString(DateType).Trim() & _
            '                      "&fromdate=" & Me.txtFromDate.Text & "&todate=" & Me.txtToDate.Text)
            objlink.NavigateUrl = String.Format("CustomerOfReport2.aspx?com_id={0}&datetype={1}&fromdate={2}&todate={3}&comtext={4}", str_Comreq, DateType, Me.txtFromDate.Text, Me.txtToDate.Text, Convert.ToString(DataBinder.Eval(e.Item.DataItem, strcomp)).Trim)

        End If
    End Sub
  
    
    Protected Sub DataGridVoucherList_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid_InvoiceList.PageIndexChanged
        ViewState("iPage") = e.NewPageIndex
        LoadDefault()
        If Me.grdDV.Table.Columns.Contains(Me.hdnSort.Value.Replace(" DESC", "")) Then
            Me.grdDV.Sort = Me.hdnSort.Value
        End If
        Me.DataGrid_InvoiceList.DataBind()
    End Sub

    Protected Sub DataGrid_InvoiceList_SortCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles DataGrid_InvoiceList.SortCommand
        Me.LoadDefault()
        If Me.hdnSort.Value = e.SortExpression Then
            Me.hdnSort.Value = e.SortExpression & " DESC"
        Else
            Me.hdnSort.Value = e.SortExpression
        End If
        If Me.grdDV.Table.Columns.Contains(Me.hdnSort.Value.Replace(" DESC", "")) Then
            Me.grdDV.Sort = Me.hdnSort.Value
        End If
        Me.DataGrid_InvoiceList.DataBind()
    End Sub
#End Region

  

    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExport.Click
        Dim strFileName As String = "Custom.csv"
        Me.LoadData()
        Common.GenerateCSVFile(Me, Me.DataGrid_InvoiceList, strFileName)
    End Sub
End Class
