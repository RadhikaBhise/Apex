Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports Business
Imports DataAccess
Partial Class ConfirmationList
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim stracct As String
            Dim strsubacct As String
            Dim stracctlist As String
            Dim strgroup As String
            Dim strPudate As String
            Dim strconfirm As String
            Dim objDataset As New DataSet
            Dim objDatatable As New DataTable
            Dim objConfirm As New Report

            strPudate = Request.QueryString("pudate").Trim()
            strconfirm = Request.QueryString("Confirm").Trim()
            If Convert.ToString(Session("group_login_flag")).Trim() = "Y" Then
                strgroup = "Y"
                stracctlist = Convert.ToString(Session("account_list")).Trim()
            Else
                strgroup = "N"
                stracctlist = ""
            End If
            If Session("acct_id") Is Nothing Then
                stracct = ""
            Else
                stracct = Convert.ToString(Session("acct_id")).Trim()
            End If
            If Session("sub_acct_id") Is Nothing Then
                strsubacct = ""
            Else
                strsubacct = Convert.ToString(Session("sub_acct_id")).Trim()
            End If

            objDataset = objConfirm.GetConfirmationNo(strPudate, stracct, strsubacct, stracctlist, strgroup, strconfirm)
            If Not objDataset Is Nothing Then
                If objDataset.Tables.Count > 0 Then
                    If objDataset.Tables(0).Rows.Count > 0 Then
                        DataGrid_Confirm.DataSource = objDataset.Tables(0)
                        DataGrid_Confirm.DataBind()

                    Else
                        Response.Redirect("ConfirmInquiry.aspx?msg=errorcode")
                        'Response.Write("<script language='javascript'>history.go(-1);alert('Invalid Voucher No! Please Try Again...');</script>")
                    End If
                Else
                    Response.Redirect("ConfirmInquiry.aspx?msg=errorcode")
                    'Response.Write("<script language='javascript'>history.go(-1);alert('Invalid Voucher No! Please Try Again...');</script>")
                End If
            Else
                Response.Redirect("ConfirmInquiry.aspx?msg=errorcode")
                'Response.Write("<script language='javascript'>ahistory.go(-1);lert('Invalid Voucher No! Please Try Again...');</script>")
            End If

            Me.lbl_PageIndex.Text = DataGrid_Confirm.CurrentPageIndex + 1
            Me.lbl_PageAmount.Text = DataGrid_Confirm.PageCount
        End If
    End Sub

End Class
