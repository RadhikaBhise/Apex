Imports Business

Public Class Verify_cc_payflow
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim cc_no, cc_exp, cc_type, from As String
            'Dim strMessage, strErrorMessage, strAuthCode, strRefer_id, strErrorCode As String

            '##    from
            '#     1   general screens
            '#     2   user profile screen
            If Not Request.QueryString("f") Is Nothing Then
                from = Request.QueryString("f").Trim
            Else
                from = "1"
            End If

            If from = "2" AndAlso Not Request.QueryString("cc_no") Is Nothing AndAlso _
                        Not Request.QueryString("cc_exp") Is Nothing AndAlso Not Request.QueryString("cc_type") Is Nothing Then
                cc_no = Request.QueryString("cc_no").Trim
                cc_exp = Request.QueryString("cc_exp").Trim
                cc_type = Request.QueryString("cc_type").Trim
            ElseIf Not MySession.OperatorOrder Is Nothing Then
                cc_no = MySession.OperatorOrder.card_no.Trim
                cc_exp = MySession.OperatorOrder.card_exp_date.Trim
                cc_type = MySession.OperatorOrder.card_type
            Else
                cc_no = ""
                cc_exp = ""
                cc_type = ""
            End If

            Using verify As New Payflow
                verify.cc_no = cc_no
                verify.exp_date = cc_exp
                verify.amount = System.Web.Configuration.WebConfigurationManager.AppSettings("CCVerifyAmount")

                If verify.authorize = True AndAlso _
                        Not verify.AUTHCODE Is Nothing AndAlso verify.AUTHCODE.Trim.Length > 0 AndAlso _
                        Not verify.PNREF Is Nothing AndAlso verify.PNREF.Trim.Length > 0 Then
                    '## 2/13/2008   Add validate authcode and pnref value.  (yang)

                    Me.lblMessage.Text = "Validation Complete"
                    Me.lblError.Text = verify.error_msg
                    Me.lblError.Visible = False

                    'strAuthCode = Payflow.AUTHCODE
                    'strRefer_id = Payflow.PNREF
                    If Not MySession.OperatorOrder Is Nothing Then
                        MySession.OperatorOrder.card_auth_no = verify.AUTHCODE
                        MySession.OperatorOrder.cc_refer_id = verify.PNREF
                    End If

                    Response.Write("<script type='text/javascript' language='javascript'>alert('Validation Complete!');self.opener.VerifyCreditCardGoingForward();window.close();</script>")
                Else
                    Me.lblMessage.Text = "Credit Card Validation Error."
                    Me.lblError.Text = verify.error_msg
                    Me.lblError.Visible = True
                    'strErrorCode = Payflow.RESULT
                    Me.ClientScript.RegisterStartupScript(GetType(String), "validate", "<script type='text/javascript'>self.opener.ShowSubmitButton(true);</script>")
                End If

                Me.lblProcessing.Visible = False
            End Using

        End If

    End Sub


End Class
