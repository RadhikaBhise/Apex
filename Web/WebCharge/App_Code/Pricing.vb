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

    Public Sub Dispose() Implements System.IDisposable.Dispose
        GC.SuppressFinalize(Me)
    End Sub
End Class
