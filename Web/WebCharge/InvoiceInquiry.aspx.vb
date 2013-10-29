Imports Business.Common
Imports business
Imports DataAccess
Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.IO


Partial Class InvoiceInquiry
    Inherits System.Web.UI.Page

    Private grdDV As DataView

#Region "Report Search"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If MySession.AcctID Is Nothing Or MySession.AcctID.Length = 0 Then
            Response.Redirect("login.aspx")
        End If

        If Not Page.IsPostBack  Then
            ' Me.btn_Submit.Attributes.Add("OnClick", "return FormValidate('" & Me.txt_InVoiceNo.ClientID & "','" & Me.txt_InVoiceDate.ClientID & "','" & txt_ToInVoiceDate.ClientID & "');")
            ' Me.txt_InVoiceNo.Attributes.Add("OnChange", "FormatInvoiceNo();")
            'Dim date_FromDate As Date = DateAdd(DateInterval.Month, -6, Today())

            'If Convert.ToString(Session("group_login_flag")).Trim() = "Y" Then
            '    getSelectAcctid()
            '    Me.tdacct1.Visible = True
            '    Me.tdacct2.Visible = True
            'Else
            '    Me.tdacct1.Visible = False
            '    Me.tdacct2.Visible = False
            'End If

            Me.trData.Visible = False

            txt_InVoiceDate.Text = ShowDateTime(Now.AddMonths(-6), DateTimeStyle.DateOnly)
            txt_ToInVoiceDate.Text = ShowDateTime(Now, DateTimeStyle.DateOnly)

        End If

        'Me.btn_Submit.Attributes.Add("onclick", "return batchvalidate('" & Session("group_login_flag") & "','" & Me.txt_InVoiceNo.ClientID & "','" & Me.txt_InVoiceDate.ClientID & "','" & txt_ToInVoiceDate.ClientID & "');")
        'Me.btn_Submit.Attributes.Add("OnClick", "return FormValidate('" & Me.txt_InVoiceNo.ClientID & "','" & Me.txt_InVoiceDate.ClientID & "','" & txt_ToInVoiceDate.ClientID & "');")

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

    'Protected Sub btn_Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Submit.Click
    '    Me.LoadData()

    '    'Dim strselacct As String
    '    'If Convert.ToString(Session("group_login_flag")).Trim() = "Y" Then
    '    '    Dim n As Integer
    '    '    For n = 0 To Me.listAcct.Items.Count - 1
    '    '        If Me.listAcct.Items(n).Selected Then
    '    '            strselacct = strselacct & Me.listAcct.Items(n).Value.ToString.Trim() & ","
    '    '        End If
    '    '    Next
    '    '    strselacct = Mid(strselacct, 1, strselacct.Length - 1)
    '    'Else
    '    '    strselacct = ""
    '    'End If
    '    'Response.Redirect("InvoiceInquiryReport1.aspx?InvoiceNo=" & txt_InVoiceNo.Text & "&FromDate=" & txt_InVoiceDate.Text & "&ToDate=" & txt_ToInVoiceDate.Text & "&SelectAcctid=" & strselacct)

    '    'Me.view.Visible = True

    '    'Dim strInvoiceNo, strFromDate, strToDate As String

    '    'strInvoiceNo = Trim(Request.QueryString("InvoiceNo"))
    '    ''strSelacct = Trim(Request.QueryString("SelectAcctid"))
    '    'If strInvoiceNo = String.Empty Then
    '    '    strInvoiceNo = ""
    '    '    strFromDate = Trim(Request.QueryString("FromDate"))
    '    '    strToDate = Trim(Request.QueryString("ToDate"))
    '    'Else
    '    '    '\\ Date arguments will be ignored if the "Invoice Number" was given.
    '    '    '\\ The recognizable date value was still needed for a procedure.
    '    '    strFromDate = Trim(Request.QueryString("FromDate"))
    '    '    strToDate = Trim(Request.QueryString("ToDate"))
    '    'End If
    '    'ViewState("InvoiceNo") = strInvoiceNo
    '    'ViewState("FromDate") = strFromDate
    '    'ViewState("ToDate") = strToDate
    '    ''ViewState("SelectAcct") = strSelacct
    '    ''Session("strSelectAcct") = strSelacct
    '    'me.hdnSort.value = ""

    '    'Call Me.Load_Default()


    '    'DataGrid_InvoiceList.DataSource = GetDataSource()
    '    'DataGrid_InvoiceList.DataBind()

    '    'Me.lblPageIndex.Text = DataGrid_InvoiceList.CurrentPageIndex + 1
    '    'Me.lblPageAmount.Text = DataGrid_InvoiceList.PageCount

    '    'Response.Redirect("InvoiceInquiryReport1.aspx?InvoiceNo=" & txt_InVoiceNo.Text & "&FromDate=" & txt_InVoiceDate.Text & "&ToDate=" & txt_ToInVoiceDate.Text)
    'End Sub

    'Protected Sub Btn_Reset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Reset.Click
    '    Response.Redirect("InvoiceInquiry.aspx", True)
    'End Sub

#End Region

#Region "Report Details1"

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not IsPostBack() Then
    '        Dim strInvoiceNo, strFromDate, strToDate, strSelacct As String
    '        strInvoiceNo = Trim(Request.QueryString("InvoiceNo"))
    '        strSelacct = Trim(Request.QueryString("SelectAcctid"))
    '        If strInvoiceNo = String.Empty Then
    '            strInvoiceNo = ""
    '            strFromDate = Trim(Request.QueryString("FromDate"))
    '            strToDate = Trim(Request.QueryString("ToDate"))
    '        Else
    '            '\\ Date arguments will be ignored if the "Invoice Number" was given.
    '            '\\ The recognizable date value was still needed for a procedure.
    '            strFromDate = Trim(Request.QueryString("FromDate"))
    '            strToDate = Trim(Request.QueryString("ToDate"))
    '        End If
    '        ViewState("InvoiceNo") = strInvoiceNo
    '        ViewState("FromDate") = strFromDate
    '        ViewState("ToDate") = strToDate
    '        ViewState("SelectAcct") = strSelacct
    '        Session("strSelectAcct") = strSelacct
    '        me.hdnSort.value = ""
    '        Call Me.Load_Default()
    '        'DataGrid_InvoiceList.DataSource = GetDataSource()
    '        'DataGrid_InvoiceList.DataBind()

    '        'Me.lbl_PageIndex.Text = DataGrid_InvoiceList.CurrentPageIndex + 1
    '        'Me.lbl_PageAmount.Text = DataGrid_InvoiceList.PageCount
    '    End If
    'End Sub

    'Private Sub Load_Default()
    '    With Me.DataGrid_InvoiceList
    '        .DataSource = GetDataSource()

    '        If IsNumeric(ViewState("iPage")) Then
    '            .CurrentPageIndex = CInt(ViewState("iPage"))
    '        Else
    '            .CurrentPageIndex = 0
    '        End If
    '        .DataBind()
    '    End With
    '    Me.lblPageIndex.Text = DataGrid_InvoiceList.CurrentPageIndex + 1
    '    Me.lblPageAmount.Text = DataGrid_InvoiceList.PageCount
    'End Sub

    Private Sub LoadData()

        Using obj_DataSource As New Report

            'Dim strAcct_ID As String
            'Dim strSubacctid As String
            'Dim intInvoiceNo As String
            ''Dim strSelectAcct As String
            Dim strGroupFlag As String
            'Dim date_FromDate, date_ToDate As String
            Dim m_DataSet As DataSet
            'Dim m_DataTable As DataTable
            'Dim strSelacct As String = ""

            'intInvoiceNo = Me.txt_InVoiceNo.Text.ToString.Trim()
            'date_FromDate = Me.txt_InVoiceDate.Text.ToString.Trim()
            'date_ToDate = Me.txt_ToInVoiceDate.Text.ToString.Trim()
            ''strSelectAcct = Convert.ToString(ViewState("SelectAcct")).Trim()
            'If MySession.AcctID Is Nothing Or MySession.AcctID.Length = 0 Then
            '    strAcct_ID = ""
            'Else
            '    strAcct_ID = Convert.ToString(MySession.AcctID).Trim()
            'End If
            'If MySession.SubAcctID Is Nothing Or MySession.SubAcctID.Length = 0 Then
            '    strSubacctid = ""
            'Else
            '    strSubacctid = Convert.ToString(MySession.SubAcctID).Trim()
            'End If

            If Convert.ToString(Session("group_login_flag")).Trim() = "Y" Then
                strGroupFlag = "Y"
            Else
                strGroupFlag = "N"
            End If

            'changed by lily 12/17/2007
            If MySession.LevelID = 1 Then
                'm_DataSet = obj_DataSource.GetInvoiceReport(intInvoiceNo, date_FromDate, date_ToDate, strGroupFlag, strAcct_ID, strSubacctid, strSelacct)
                m_DataSet = obj_DataSource.GetInvoiceReport(Me.txt_InVoiceNo.Text, Me.txt_InVoiceDate.Text, Me.txt_ToInVoiceDate.Text, strGroupFlag, MySession.AcctID, MySession.SubAcctID, MySession.AcctID)
            Else
                'm_DataSet = obj_DataSource.GetInvoiceReportbyVIP(intInvoiceNo, date_FromDate, date_ToDate, strGroupFlag, MySession.UserID, strAcct_ID, strSubacctid, strSelacct)
                m_DataSet = obj_DataSource.GetInvoiceReportbyVIP(Me.txt_InVoiceNo.Text, Me.txt_InVoiceDate.Text, Me.txt_ToInVoiceDate.Text, strGroupFlag, MySession.UserID, MySession.AcctID, MySession.SubAcctID, MySession.AcctID)
            End If


            If Not m_DataSet Is Nothing AndAlso m_DataSet.Tables.Count > 0 AndAlso _
                            m_DataSet.Tables(0).Rows.Count > 0 Then

                'm_DataTable = m_DataSet.Tables(0)
                Me.grdDV = m_DataSet.Tables(0).DefaultView
                'Session("m_datatable") = m_DataTable

                'obj_DataSource = Nothing

                If Me.hdnSort.Value <> "" AndAlso _
                            Me.grdDV.Table.Columns.Contains(Me.hdnSort.Value.Replace(" DESC", "")) Then

                    'm_DataTable.DefaultView.Sort = me.hdnSort.value
                    Me.grdDV.Sort = Me.hdnSort.Value
                End If

                '## add by joey 3/13/2008
                If Me.grdData.CurrentPageIndex + 1 > Math.Ceiling(m_DataSet.Tables(0).Rows.Count / Me.grdData.PageSize) Then
                    Me.grdData.CurrentPageIndex = 0
                End If

                Try
                    Me.grdData.DataSource = Me.grdDV
                    Me.grdData.DataBind()
                Catch
                End Try


                Me.lblPageCount.Text = Me.grdData.PageCount.ToString
                Me.lblPageIndex.Text = Convert.ToString(Me.grdData.CurrentPageIndex + 1)

                Me.trData.Visible = True
                'Return m_DataTable.DefaultView
            Else
                Dim strMessage As String = "<script type='text/javascript'>alert('No Information found!');</script>"
                ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage", strMessage)
            End If

        End Using

        'Return Me.grdDV
    End Sub

    Protected Sub grdData_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdData.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
            Dim lnkInvoiceNo As HyperLink = CType(e.Item.FindControl("lnkInvoiceNo"), HyperLink)

            Dim InvoiceNo As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "invoice_no")).Trim
            Dim InvoiceDate As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "invoice_date")).Trim

            lnkInvoiceNo.Text = Common.ShowDateTime(InvoiceDate, DateTimeStyle.DateOnly)
            lnkInvoiceNo.NavigateUrl = String.Format("InvoiceInquiryReport2.aspx?InvoiceNo={0}&InvoiceDate={1}", InvoiceNo, ShowDateTime(InvoiceDate, DateTimeStyle.DateOnly))
        End If
    End Sub

    Protected Sub grdData_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdData.PageIndexChanged
        'ViewState("iPage") = e.NewPageIndex
        'Load_Default()
        Try
            Me.grdData.CurrentPageIndex = e.NewPageIndex
            Me.LoadData()

            If Not Me.grdDV Is Nothing AndAlso Not Me.grdDV.Table Is Nothing AndAlso _
                        Me.grdDV.Table.Columns.Contains(Me.hdnSort.Value.Replace(" DESC", "")) Then
                'm_DataTable.DefaultView.Sort = me.hdnSort.value
                Me.grdDV.Sort = Me.hdnSort.Value
            End If

            Me.grdData.DataBind()
        Catch
        End Try
    End Sub

    Protected Sub grdData_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdData.SortCommand
        'Call Me.Load_Default()

        'If e.SortExpression = "Invoice_No" Or e.SortExpression = "base_rate" Then
        '    Session("SortExprValue") = e.SortExpression & " DESC"
        '    Me.grdDV.Sort = e.SortExpression & " DESC"
        'Else
        '    Session("SortExprValue") = e.SortExpression
        '    Me.grdDV.Sort = e.SortExpression
        'End If

        'Me.grdData.DataBind()
        If Me.hdnSort.Value = e.SortExpression Then
            Me.hdnSort.Value = e.SortExpression & " DESC"
        Else
            Me.hdnSort.Value = e.SortExpression
        End If

        Me.LoadData()

        If Not Me.grdDV Is Nothing AndAlso Not Me.grdDV.Table Is Nothing AndAlso _
                    Me.grdDV.Table.Columns.Contains(Me.hdnSort.Value.Replace(" DESC", "")) Then
            'm_DataTable.DefaultView.Sort = me.hdnSort.value
            Me.grdDV.Sort = Me.hdnSort.Value
        End If

        Me.grdData.DataBind()
    End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExcel.Click
        'GetDataSource()
        Me.grdData.AllowPaging = False
        Me.LoadData()
        Common.GenerateCSVFile(Me, Me.grdData, "InvoiceInquiryReport.csv")
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click
        Me.LoadData()
    End Sub

#End Region

End Class