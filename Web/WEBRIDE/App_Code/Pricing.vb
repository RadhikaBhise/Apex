Imports Microsoft.VisualBasic
Imports Business
Imports DataAccess

Public Class Pricing
    Implements IDisposable

    '## Use PricingLimo dll to calculate the price estimate
    '## 11/20/2007  (yang)
    Public Function GetPriceEst(ByVal order As OperatorData) As String
        Dim rate As Single = 0

        Try
            'Dim pricing As New PricingDLL.PricingLimo

            'pricing.ConnectionString = System.Configuration.ConfigurationManager.AppSettings("PricingConnectionString")

            'pricing.MileagePricing = Me.PricingIsByMileage(order.account_no, order.sub_account_no, order.company)

            'pricing.Company = order.company
            'pricing.AccountNo = order.account_no
            'pricing.SubAccountNo = order.sub_account_no
            'pricing.CarType = order.Car_type

            'pricing.puCounty = order.pu_county
            'pricing.puCity = order.pu_city
            'pricing.puStName = order.pu_st_name
            'pricing.puStNo = order.pu_st_no
            'pricing.puZip = order.pu_zip

            'pricing.DestCounty = order.dest_county
            'pricing.DestCity = order.dest_city
            'pricing.DestStName = order.dest_st_name
            'pricing.DestStNo = order.dest_st_no
            'pricing.DestZip = order.dest_zip

            'rate = pricing.PricingRate

            'pricing = Nothing

            rate = 0

        Catch ex As Exception
            Dim ErrorMessage As String = ex.Message
        End Try

        Return rate.ToString
    End Function

    '## Get Pricing is base on mileage
    '## 11/21/2007  (yang)
    'Public Function PricingIsByMileage(ByVal AcctID As String, ByVal SubAcctID As String, ByVal Company As String) As Boolean

    '    Dim out As Boolean = False
    '    Dim sql As String = String.Format("SELECT price_by_mileage_flag FROM account(NOLOCK) " & _
    '            "WHERE acct_id='{0}' AND sub_acct_id='{1}' AND company='{2}'", AcctID, SubAcctID, Company)

    '    Try
    '        Me.OpenConnection()
    '        Me.Command.CommandType = CommandType.Text
    '        Me.Command.CommandText = sql

    '        out = Convert.ToString(Me.Command.ExecuteScalar).Trim().ToUpper.Equals("T")
    '    Catch ex As Exception
    '        out = False
    '        Me.ErrorMessage = ex.Message
    '    Finally
    '        Me.CloseConnection()
    '    End Try

    '    Return out
    'End Function

    '## type
    '#  1 - normal validate
    '#  2 - validate from user profile screen
    Public Shared Sub RegisterValidateCCScript(ByRef basePage As Page, ByVal btnSubmit As ImageButton, _
            ByVal trSubmit As HtmlTableRow, ByVal hdnSubmit As Button, ByVal type As Int16)

        Dim VerifyAmount As Double = Val(System.Web.Configuration.WebConfigurationManager.AppSettings("CCVerifyAmount"))

        If type = 2 Then

            '## Validate Credit Card for User Profile screen
            If VerifyAmount > 0 Then
                btnSubmit.Attributes.Add("onclick", "javascript:batchValidate(true);return false;")
            Else
                btnSubmit.Attributes.Add("onclick", "javascript:batchValidate(false);return false;")
            End If

            basePage.ClientScript.RegisterStartupScript(GetType(String), "CCVerify", "<script type='text/javascript'>function VerifyCreditCardGoingForward(){document.getElementById('" & hdnSubmit.ClientID & "').click();}</script>")
            basePage.ClientScript.RegisterStartupScript(GetType(String), "ShowSubmitButton", "<script type='text/javascript'>function ShowSubmitButton(show){document.getElementById('" & trSubmit.ClientID & "').style.visibility=show?'':'hidden';}</script>")
        Else

            '## Validate Credit Card for general screens
            If VerifyAmount >= 0 AndAlso Not MySession.OperatorOrder Is Nothing AndAlso MySession.OperatorOrder.card_no.Trim.Length > 0 Then

                If MySession.OperatorOrder.confirmation_no.Trim.Length > 0 Then
                    '## Check card # is changed in order modify function
                    Using obj As New Operators
                        Dim tmpOrd As OperatorData = obj.FillRides(MySession.OperatorOrder.confirmation_no)

                        If tmpOrd.CC_Type_Default = MySession.OperatorOrder.CC_Type_Default AndAlso tmpOrd.CC_Type_Default.Trim.Length > 0 AndAlso _
                                tmpOrd.card_exp_date = MySession.OperatorOrder.card_exp_date AndAlso tmpOrd.card_exp_date.Trim.Length > 0 AndAlso _
                                tmpOrd.card_no = MySession.OperatorOrder.card_no AndAlso tmpOrd.card_no.Trim.Length > 0 AndAlso _
                                tmpOrd.card_auth_no.Trim.Length > 0 AndAlso tmpOrd.cc_refer_id.Trim.Length > 0 Then

                            '## Credit Card not changed and no need to validate
                            btnSubmit.Attributes.Add("onclick", "javascript:document.getElementById('" & trSubmit.ClientID & "').style.visibility='hidden';")
                        Else
                            '## Credit Card has been changed and need to re-validate Credit Card
                            btnSubmit.Attributes.Add("onclick", "javascript:VerifyCC(document.getElementById('" & trSubmit.ClientID & "'));return false;")
                            basePage.ClientScript.RegisterStartupScript(GetType(String), "CCVerify", "<script type='text/javascript'>function VerifyCreditCardGoingForward(){document.getElementById('" & hdnSubmit.ClientID & "').click();}</script>")
                        End If
                    End Using

                Else
                    '## It's a new order and credit card must be validated.
                    btnSubmit.Attributes.Add("onclick", "javascript:VerifyCC(document.getElementById('" & trSubmit.ClientID & "'));return false;")
                    basePage.ClientScript.RegisterStartupScript(GetType(String), "CCVerify", "<script type='text/javascript'>function VerifyCreditCardGoingForward(){document.getElementById('" & hdnSubmit.ClientID & "').click();}</script>")
                End If
            Else
                '## None Credit Card Order, no need to validate.
                btnSubmit.Attributes.Add("onclick", "javascript:document.getElementById('" & trSubmit.ClientID & "').style.visibility='hidden';")
            End If

            basePage.ClientScript.RegisterStartupScript(GetType(String), "ShowSubmitButton", "<script type='text/javascript'>function ShowSubmitButton(show){document.getElementById('" & trSubmit.ClientID & "').style.visibility=show?'':'hidden';}</script>")
        End If

    End Sub

    Public Shared Function ValidateCreditCardOrder(ByVal ord As OperatorData, Optional ByRef errorMsg As String = "") As Boolean
        Dim out As Boolean = True
        Dim PaymentTypeIDOfCreditCard As String = System.Web.Configuration.WebConfigurationManager.AppSettings("PaymentTypeIDOfCreditCard")

        If ord.payment_type = PaymentTypeIDOfCreditCard Then
            If ord.card_no Is Nothing OrElse ord.card_no.Trim.Length = 0 Then
                errorMsg = "Credit Card # is invalid."
                out = False
            ElseIf ord.card_auth_no Is Nothing OrElse ord.card_auth_no.Trim.Length = 0 Then
                errorMsg = "Credit Card Auth # is invalid."
                out = False
            ElseIf ord.cc_refer_id Is Nothing OrElse ord.cc_refer_id.Trim.Length = 0 Then
                errorMsg = "Credit Card Refer ID is invalid."
                out = False
            End If
        End If

        Return out
    End Function

    Public Sub Dispose() Implements System.IDisposable.Dispose
        GC.SuppressFinalize(Me)
    End Sub
End Class
