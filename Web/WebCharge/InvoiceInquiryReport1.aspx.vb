Imports Business
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess
Imports System
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.IO
Partial Class InvoiceInquiryReport1
    Inherits System.Web.UI.Page
    Private grdDV As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            Dim strInvoiceNo, strFromDate, strToDate, strSelacct As String
            strInvoiceNo = Trim(Request.QueryString("InvoiceNo"))
            strSelacct = Trim(Request.QueryString("SelectAcctid"))
            If strInvoiceNo = String.Empty Then
                strInvoiceNo = ""
                strFromDate = Trim(Request.QueryString("FromDate"))
                strToDate = Trim(Request.QueryString("ToDate"))
            Else
                '\\ Date arguments will be ignored if the "Invoice Number" was given.
                '\\ The recognizable date value was still needed for a procedure.
                strFromDate = Trim(Request.QueryString("FromDate"))
                strToDate = Trim(Request.QueryString("ToDate"))
            End If
            ViewState("InvoiceNo") = strInvoiceNo
            ViewState("FromDate") = strFromDate
            ViewState("ToDate") = strToDate
            ViewState("SelectAcct") = strSelacct
            Session("strSelectAcct") = strSelacct
            ViewState("SortExprValue") = ""
            Call Me.Load_Default()
            'DataGrid_InvoiceList.DataSource = GetDataSource()
            'DataGrid_InvoiceList.DataBind()

            'Me.lbl_PageIndex.Text = DataGrid_InvoiceList.CurrentPageIndex + 1
            'Me.lbl_PageAmount.Text = DataGrid_InvoiceList.PageCount
        End If
    End Sub
    Private Sub Load_Default()
        With Me.DataGrid_InvoiceList
            .DataSource = GetDataSource()

            If IsNumeric(ViewState("iPage")) Then
                .CurrentPageIndex = CInt(ViewState("iPage"))
            Else
                .CurrentPageIndex = 0
            End If
            .DataBind()
        End With
        Me.lbl_PageIndex.Text = DataGrid_InvoiceList.CurrentPageIndex + 1
        Me.lbl_PageAmount.Text = DataGrid_InvoiceList.PageCount
    End Sub

    Private Function GetDataSource() As DataView
        Dim obj_DataSource As New Report
        Dim strAcct_ID As String
        Dim strSubacctid As String
        Dim intInvoiceNo As String
        Dim strSelectAcct As String
        Dim strGroupFlag As String
        Dim date_FromDate, date_ToDate As String
        Dim m_DataSet As DataSet
        Dim m_DataTable As DataTable

        intInvoiceNo = Convert.ToString(ViewState("InvoiceNo")).Trim()
        date_FromDate = Convert.ToString(ViewState("FromDate")).Trim()
        date_ToDate = Convert.ToString(ViewState("ToDate")).Trim()
        strSelectAcct = Convert.ToString(ViewState("SelectAcct")).Trim()
        If Session("acct_id") Is Nothing Then
            strAcct_ID = ""
        Else
            strAcct_ID = Convert.ToString(Session("acct_id")).Trim()
        End If
        If Session("sub_acct_id") Is Nothing Then
            strSubacctid = ""
        Else
            strSubacctid = Convert.ToString(Session("sub_acct_id")).Trim()
        End If
        If Convert.ToString(Session("group_login_flag")).Trim() = "Y" Then
            strGroupFlag = "Y"
        Else
            strGroupFlag = "N"
        End If

        m_DataSet = obj_DataSource.GetInvoiceReport(intInvoiceNo, date_FromDate, date_ToDate, strGroupFlag, strAcct_ID, strSubacctid, strSelectAcct)
        If m_DataSet.Tables.Count > 0 Then
            m_DataTable = m_DataSet.Tables(0)
            Me.grdDV = m_DataSet.Tables(0).DefaultView
            Session("m_datatable") = m_DataTable

            obj_DataSource = Nothing

            If ViewState("SortExprValue") <> "" Then
                m_DataTable.DefaultView.Sort = ViewState("SortExprValue")
            End If

            If m_DataTable.Rows.Count = 0 Then
                Dim strMessage As String = "<script language=""JavaScript"">alert('No information about the ACCOUNT! Please try again...');" & _
                                           "history.go(-1);</script>"
                RegisterStartupScript("PopUpMessage", strMessage)
            End If

            Return m_DataTable.DefaultView
        Else
            Return Nothing
        End If
    End Function

    Protected Sub DataGrid_InvoiceList_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid_InvoiceList.PageIndexChanged
        ViewState("iPage") = e.NewPageIndex
        Load_Default()
    End Sub

    Protected Sub DataGrid_InvoiceList_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles DataGrid_InvoiceList.SortCommand
        Call Me.Load_Default()

        If e.SortExpression = "Invoice_No" Or e.SortExpression = "base_rate" Then
            Session("SortExprValue") = e.SortExpression & " DESC"
            Me.grdDV.Sort = e.SortExpression & " DESC"
        Else
            Session("SortExprValue") = e.SortExpression
            Me.grdDV.Sort = e.SortExpression
        End If

        Me.DataGrid_InvoiceList.DataBind()
    End Sub

End Class
