Imports Business

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If MySession.AcctID Is Nothing Or MySession.AcctID.Length = 0 Then
            Response.Redirect("login.aspx")
        End If

        Dim strlevel As String
        strlevel = Convert.ToString(MySession.LevelID).Trim()
        If strlevel = "1" Then
            If Convert.ToString(Session("group_login_flag")).Trim() = "Y" Then
                Me.trMaintenance.Visible = False
            End If
        End If

        If strlevel < "5" Then
            Me.trInvoice.Visible = True
            Me.trReport.Visible = True
        Else
            Me.trInvoice.Visible = False
            Me.trReport.Visible = False
        End If

        If Not Me.Page.IsPostBack Then
            Dim msg As String
            msg = ""
            msg = Trim(Request.QueryString("msg"))
            If msg = "nocomp" Then
                Response.Write("<script language='javascript'>alert('No Comp.ID associated with this acount!');</script>")
            Else
            End If
        End If
    End Sub

    Protected Sub lbtnVou_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnVou.Click
        Response.Redirect("InvoiceInquiry.aspx")
    End Sub

    Protected Sub lbtnCI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnCI.Click
        Response.Redirect("voucherinquiry.aspx")
    End Sub

    Protected Sub lbtnCustomer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnCustomer.Click
        Response.Redirect("QScustomer.aspx")
    End Sub

    Protected Sub lbtnVIP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnVIP.Click
        Response.Redirect("QSvip.aspx")
    End Sub

    Protected Sub lnkbtn_Maintain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbtn_Maintain.Click
        Response.Redirect("Maintenance.aspx")
    End Sub

    Protected Sub lbtnLogoff_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnLogoff.Click
        
        'MySession.UserID = Nothing
        'MySession.SubAcctID = Nothing
        'MySession.AcctName = Nothing
        'MySession.AcctID = Nothing
        'MySession.UserName = Nothing
        ''MySession.AcctID = Nothing
        'MySession.LevelID = Nothing
        'Session("account_list") = Nothing
        'Session("group_login_flag") = Nothing
        'Session("group_id") = Nothing

        MySession.ClearSession()
        Response.Redirect("login.aspx")

    End Sub
End Class
