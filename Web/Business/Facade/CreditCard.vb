Imports DataAccess

Public Class CreditCard
    Inherits CommonDB

    Public Function CardTypeGet() As DataSet

        Dim StrSQL As String

        StrSQL = "SELECT * FROM credit_card_type(NOLOCK)"
        Return Me.QueryData(StrSQL, "Card_Type")

    End Function

End Class
