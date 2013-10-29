Imports Business
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess

Partial Class CustomerOfReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.IsPostBack Then

            ViewState("FromTrip") = Trim(Request.QueryString("FromDate"))
            ViewState("ToTrip") = Trim(Request.QueryString("ToDate"))
            ViewState("str_Comreq") = Trim(Request.QueryString("custom"))
            ViewState("sel_acct_id") = Trim(Request.QueryString("SelAcctId"))
            Session("selacctid") = Trim(Request.QueryString("SelAcctId"))
            ViewState("DateType") = Trim(Request.QueryString("DateType"))
            ViewState("Sort") = Trim(Request.QueryString("Sortby"))
            ViewState("Top") = Trim(Request.QueryString("Top"))
            'ViewState("customtext") = Trim(Request.QueryString("customtext"))
            Me.lbl_TabCap.Text = "Your Requested Top <font color='green'>" & Convert.ToString(ViewState("top")).Trim() & " </font> Employee(s) Report"
            If Convert.ToString(ViewState("sortby")).Trim() = "1" Then
                Me.lbl_TabCap.Text = Me.lbl_TabCap.Text & " By Total Voucher Amount:"
            Else
                Me.lbl_TabCap.Text = Me.lbl_TabCap.Text & " By Total Number of Rides:"
            End If

        End If
        If Me.DataGrid_InvoiceList.Attributes("SortExpression") = "" Then
            Me.DataGrid_InvoiceList.Attributes("SortExpression") = "totalBase"
            Me.DataGrid_InvoiceList.Attributes("SortDirection") = "asc"
        End If
        DataGrid_InvoiceList.DataSource = GetDataSource()
        DataGrid_InvoiceList.DataBind()

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
        Dim str_SearchValue As String
        Dim str_Comreq As String
        Dim strDatetype As String
        Dim strSort As String
        Dim strTop As String
        Dim obj_DataSource As New Report
        Dim dv As New DataView
        Dim m_dataset As New DataSet
        Dim m_DataTable As New DataTable
        Dim m_DataTable2 As New DataTable


        FromTrip = Convert.ToString(ViewState("FromTrip")).Trim()
        ToTrip = Convert.ToString(ViewState("ToTrip")).Trim()
        str_Comreq = Convert.ToString(ViewState("str_Comreq")).Trim()
        sel_acct_id = Convert.ToString(ViewState("sel_acct_id")).Trim()
        strDatetype = Convert.ToString(ViewState("DateType")).Trim()
        strSort = Convert.ToString(ViewState("Sort")).Trim()
        strTop = Convert.ToString(ViewState("Top")).Trim()
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

                End If
            End If
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
            strcomp = "comp_id_" & Convert.ToString(ViewState("str_Comreq")).Trim()
            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, strcomp)) Then
                objlink.Text = Convert.ToString(DataBinder.Eval(e.Item.DataItem, strcomp))
            Else
                objlink.Text = ""
            End If
            objlink.NavigateUrl = "CustomerOfReport2.aspx?com_id=" & Convert.ToString(ViewState("str_Comreq")).Trim() & _
                                  "&comtext=" & Convert.ToString(DataBinder.Eval(e.Item.DataItem, strcomp))
        End If
    End Sub
End Class
