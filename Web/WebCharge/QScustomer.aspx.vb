Imports Business
Imports DataAccess
Imports System.Data
Imports System.Data.SqlClient
Partial Class QScustomer
    Inherits System.Web.UI.Page
    Private grdDV As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("acct_id") Is Nothing Then
            Response.Redirect("login.aspx")
        End If

        If Not Page.IsPostBack Then
            Me.txtFromDate.Text = Common.ShowDateTime(Now.AddMonths(-6), Common.DateTimeStyle.DateOnly)
            Me.txtToDate.Text = Common.ShowDateTime(Now, Common.DateTimeStyle.DateOnly)

            Me.getCusRef(MySession.AcctID, MySession.SubAcctID, MySession.AcctID, "")

            Me.trData.Visible = False
        End If
        'End If

        Me.btnSubmit.Attributes.Add("onclick", "javascript:return CustomerReferenceSubmitValidation('" & Me.txtSearchValue.ClientID & "');")
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
                            Me.lstCmpReq.Items.Add(New ListItem(strtext, strvalue))
                        End If
                    Next
                Else
                    Response.Redirect("default.aspx?msg=nocomp")

                End If
            Else
                Response.Redirect("default.aspx?msg=nocomp")

            End If
        Else
            Response.Redirect("default.aspx?msg=nocomp")

        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click

        If Me.ValidateSearchFilter Then

            Dim strMessage As String

            If Not Me.lstCmpReq.Items.Count > 0 Then
                strMessage = "<script language=""JavaScript"">alert('No Information Found!');" & _
                                                   "</script>"
                ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage", strMessage)
            Else
                Me.LoadData()
            End If
        End If

    End Sub

    Private Function ValidateSearchFilter() As Boolean
        Dim out As Boolean = True

        If Not IsDate(Me.txtFromDate.Text) Then
            Page.ClientScript.RegisterStartupScript(GetType(String), "validate", "<script type='text/javascript'>alert('The date entry is not in an acceptable format.');</script>")
            out = False
        ElseIf Not IsDate(Me.txtToDate.Text) Then
            Page.ClientScript.RegisterStartupScript(GetType(String), "validate", "<script type='text/javascript'>alert('The date entry is not in an acceptable format.');</script>")
            out = False
        End If

        Return out
    End Function

    Private Sub LoadData()
        Using rpt As New Report
            Dim ds As DataSet = rpt.GetCustomerList(MySession.AcctID, MySession.SubAcctID, MySession.UserID, MySession.LevelID, Me.txtFromDate.Text, _
                    Me.txtToDate.Text, Me.lstCmpReq.SelectedValue, Me.txtSearchValue.Text, Convert.ToString(IIf(Me.radTrip.Checked, "t", "i")))

            Me.VoucherList1.DataSetSource = ds
            Me.VoucherList1.DataSetBind(-1, "")
            Me.trData.Visible = True
        End Using
    End Sub

End Class
