'Creator:eJay 10/27/2004

Imports DataAccess
Imports System.Data
'Imports System.Data.SqlClient

Public Class Card
    Inherits CommonDB
    '------------------------------------------------------------------------------
    '-- Function: getAllCardType
    '-- Description:  get all Card Type
    '-- Input: 
    '-- Output: DataSet
    '-- Table: credit_card_type
    '-- Stored Procedure: skylimo_wr_CreditCardType_getAll
    '-- 10/28/04 - Created (Nanco)
    '------------------------------------------------------------------------------
    Public Function getAllCardType() As DataSet

        Return Me.QueryData("exec apex_wr_creditcardtype_getall", "CardType")

    End Function

End Class
