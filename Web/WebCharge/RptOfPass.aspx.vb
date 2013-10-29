Imports Business
Imports DataAccess
Imports System.Data
Imports System.Data.SqlClient
Partial Class RptOfPass
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.btn_Submit.Attributes.Add("OnClick", "return DateValidate('" & Session("group_login_flag") & "');")
        If Not Page.IsPostBack Then
            Dim date_FromDate As Date
            date_FromDate = DateValue(DateAdd("m", -6, Now))
            txt_FromTrip.Text = Format(date_FromDate, "M\/d\/yyyy")
            txt_ToTrip.Text = Format(Now, "M\/d\/yyyy")
            If Convert.ToString(Session("group_login_flag")).Trim() = "Y" Then
                getSelectAcctid()
                Me.trSelAcct.Visible = True
                Me.trSelList.Visible = True
            Else
                Me.trSelAcct.Visible = False
                Me.trSelList.Visible = False
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
                    Me.listAcct.DataSource = objDS.Tables(0)
                    With objDS.Tables(0)
                        Dim n As Integer
                        For n = 0 To .Rows.Count - 1
                            strvalue = .Rows(n).Item("acct_id").ToString.Trim()
                            strtext = .Rows(n).Item("acct_id").ToString.Trim() & " - " & .Rows(n).Item("name").ToString.Trim()
                            Me.listAcct.Items.Add(New ListItem(strtext, strvalue))
                        Next
                    End With
                End If
            End If
        End If
    End Sub
    Protected Function getSelectAcct() As String
        Dim strselacct As String = ""
        If Convert.ToString(Session("group_login_flag")).Trim() = "Y" Then
            Dim n As Integer
            For n = 0 To Me.listAcct.Items.Count - 1
                If Me.listAcct.Items(n).Selected Then
                    strselacct = strselacct & Me.listAcct.Items(n).Value.ToString.Trim() & ","
                End If
            Next
            If strselacct = "" Then
            Else
                strselacct = Mid(strselacct, 1, strselacct.Length - 1)
            End If

        Else
            strselacct = ""
        End If
        Return strselacct
    End Function

    Protected Sub btn_Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Submit.Click
        Dim strSelAcct As String
        Dim strFromdate As String
        Dim strTodate As String
        Dim strArgs As String
        Dim strTop As String
        Dim strDaytype As String
        Dim strSort As String


        strSelAcct = getSelectAcct()
        strFromdate = Me.txt_FromTrip.Text.Trim()
        strTodate = Me.txt_ToTrip.Text.Trim()
        strTop = Me.txt_Top.Text.Trim()
        If Me.radTip.Checked = True Then
            strDaytype = "t"
        Else
            strDaytype = "i"
        End If
        strSort = Me.lst_SortBy.SelectedValue.ToString.Trim()

        strArgs = "SelAcctId=" & strSelAcct & "&Fromdate=" & strFromdate & "&Todate=" & strTodate & "&Top=" & strTop & "&Daytype=" & strDaytype & "&Sortby=" & strSort

        Response.Redirect("PassOfReport.aspx?" & strArgs & "&Req=QueryStatistics")
    End Sub
End Class
