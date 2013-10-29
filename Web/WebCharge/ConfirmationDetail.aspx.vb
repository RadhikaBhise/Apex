Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports Business
Imports DataAccess

Partial Class ConfirmationDetail
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.IsPostBack Then
            Dim strConfirmation As String
            Dim strGroupFlag As String
            Dim strAcct_ID As String
            Dim strSubacctid As String
            Dim strAcct_list As String

            strConfirmation = Trim(Request.QueryString("confirmation"))
            ViewState("confirmationno") = strConfirmation
            If Convert.ToString(Session("group_login_flag")).Trim() = "Y" Then
                strGroupFlag = "Y"
                strAcct_list = Convert.ToString(Session("account_list")).Trim()
            Else
                strGroupFlag = "N"
                strAcct_list = ""
            End If
            If MySession.AcctID Is Nothing Then
                strAcct_ID = ""
            Else
                strAcct_ID = Convert.ToString(MySession.AcctID).Trim()
            End If
            If MySession.SubAcctID Is Nothing Then
                strSubacctid = ""
            Else
                strSubacctid = Convert.ToString(MySession.SubAcctID).Trim()
            End If
        End If
        DataGrid_InvoiceList.DataSource = GetDataSource()
        DataGrid_InvoiceList.DataBind()

        Me.lbl_PageIndex.Text = DataGrid_InvoiceList.CurrentPageIndex + 1
        Me.lbl_PageAmount.Text = DataGrid_InvoiceList.PageCount
    End Sub
    Public Function GetDataSource() As DataView

        Dim obj_DataSource As New Report
        Dim dv As New DataView
        Dim m_dataset As New DataSet
        Dim m_DataTable As New DataTable
        Dim m_DataTable2 As New DataTable
        Dim strGroupFlag As String
        Dim strAcct_ID As String
        Dim strSubacctid As String
        Dim strAcct_list As String
        Dim strConfirmation As String

        strConfirmation = Convert.ToString(ViewState("confirmationno")).Trim()
        If Convert.ToString(Session("group_login_flag")).Trim() = "Y" Then
            strGroupFlag = "Y"
            strAcct_list = Convert.ToString(Session("account_list")).Trim()
        Else
            strGroupFlag = "N"
            strAcct_list = ""
        End If
        If MySession.AcctID Is Nothing Then
            strAcct_ID = ""
        Else
            strAcct_ID = Convert.ToString(MySession.AcctID).Trim()
        End If
        If MySession.SubAcctID Is Nothing Then
            strSubacctid = ""
        Else
            strSubacctid = Convert.ToString(MySession.SubAcctID).Trim()
        End If
        Dim SortExpression As String
        Dim SortDirection As String
        SortExpression = Me.DataGrid_InvoiceList.Attributes("SortExpression")
        SortDirection = Me.DataGrid_InvoiceList.Attributes("SortDirection")
        m_dataset = obj_DataSource.GetConfirmationDetail(strAcct_ID, strSubacctid, strAcct_list, strGroupFlag, strConfirmation)

        If Not m_dataset Is Nothing Then
            If m_dataset.Tables.Count > 0 Then
                m_DataTable = m_dataset.Tables(0)
                m_DataTable2 = m_dataset.Tables(1)
                If m_DataTable2.Rows.Count > 0 Then
                    Dim n As Integer
                    For n = 0 To m_DataTable2.Rows.Count - 1
                        If IsDBNull(m_DataTable2.Rows(n).Item("req_desc")) Then
                            Session("strfield" & n + 1 & "name") = ""
                        ElseIf m_DataTable2.Rows(n).Item("req_desc").ToString.Trim() = "" Then
                            Session("strfield" & n + 1 & "name") = ""
                        Else
                            Session("strfield" & n + 1 & "name") = m_DataTable2.Rows(n).Item("req_desc")
                        End If
                    Next
                Else
                    Session("strfield1name") = ""
                    Session("strfield2name") = ""
                    Session("strfield3name") = ""
                    Session("strfield4name") = ""
                    Session("strfield5name") = ""
                    Session("strfield6name") = ""
                End If
                Session("m_datatable") = m_DataTable
                obj_DataSource = Nothing
                'If ViewState("SortExprValue") <> "" Then
                '    m_DataTable.DefaultView.Sort = ViewState("SortExprValue")
                'End If
                If SortExpression <> "" Then
                    m_DataTable.DefaultView.Sort = SortExpression & " " & SortDirection
                End If

                If m_DataTable.Rows.Count = 0 Then
                    'Response.Redirect("ConfirmInquiry.aspx?msg=errorcode")
                    Dim strMessage As String = "<script language=""JavaScript"">alert('No Information Found!');" & _
                                               "history.go(-1);</script>"
                    RegisterStartupScript("PopUpMessage", strMessage)

                End If
            End If
        End If

        Return m_DataTable.DefaultView
    End Function

    Protected Sub DataGrid_InvoiceList_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid_InvoiceList.ItemDataBound
        If e.Item.ItemType = ListItemType.Header Then
            If Not Session("strfield1name") Is Nothing And Convert.ToString(Session("strfield1name")).Trim() <> "" Then
                e.Item.Cells(6).Text = Convert.ToString(Session("strfield1name")).Trim()
            Else
                DataGrid_InvoiceList.Columns(6).Visible = False
            End If
            If Not Session("strfield2name") Is Nothing And Convert.ToString(Session("strfield2name")).Trim() <> "" Then
                e.Item.Cells(7).Text = Convert.ToString(Session("strfield2name")).Trim()
            Else
                DataGrid_InvoiceList.Columns(7).Visible = False
            End If
            If Not Session("strfield3name") Is Nothing And Convert.ToString(Session("strfield3name")).Trim() <> "" Then
                e.Item.Cells(8).Text = Convert.ToString(Session("strfield3name")).Trim()
            Else
                DataGrid_InvoiceList.Columns(8).Visible = False
            End If
            If Not Session("strfield4name") Is Nothing And Convert.ToString(Session("strfield4name")).Trim() <> "" Then
                e.Item.Cells(9).Text = Convert.ToString(Session("strfield4name")).Trim()
            Else
                DataGrid_InvoiceList.Columns(9).Visible = False
            End If
            If Not Session("strfield5name") Is Nothing And Convert.ToString(Session("strfield5name")).Trim() <> "" Then
                e.Item.Cells(10).Text = Convert.ToString(Session("strfield5name")).Trim()
            Else
                DataGrid_InvoiceList.Columns(10).Visible = False
            End If
            If Not Session("strfield6name") Is Nothing And Convert.ToString(Session("strfield6name")).Trim() <> "" Then
                e.Item.Cells(11).Text = Convert.ToString(Session("strfield6name")).Trim()
            Else
                DataGrid_InvoiceList.Columns(11).Visible = False
            End If
        End If
    End Sub
End Class
