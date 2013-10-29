Imports Microsoft.VisualBasic
Imports System.Web.HttpContext

Public Class Msg

    Public Enum MsgType

        '## Cancel Order
        CancelOrderSuccessful
        CancelOrderFailed
        CancelOrderFailedForTimeClosely

        '## Corporate Login
        CorporateLoginNoAcctFound
        CorporateLoginPasswordIncorrect
        CorporateLoginAcctExpired
        CorporateLoginNotSetUpForOnlineOrdering
        CorporateLoginUnknowException


        '## Delete Profile
        FrequentProfileDeleteSuccessful
        FrequentProfileDeleteFailed
        FrequentProfileUpdateSuccessful
        FrequentProfileUpdateFailed
        FrequentProfileDuplicate

        '## Delete Address
        FrequentAddressDeleteSuccessful
        FrequentAddressDeleteFailed
        FrequentAddressUpdateSuccessful
        FrequentAddressUpdateFailed
        FrequentAddressDuplicate

    End Enum

    Public Shared Function GetErrorMsg(ByVal type As MsgType) As String
        Dim out As String = ""

        Select Case type
            '## Cancel Order
            Case MsgType.CancelOrderSuccessful
                out = "Cancellation Successful."
            Case MsgType.CancelOrderFailed
                out = "Error with cancellation. Please try again."
            Case MsgType.CancelOrderFailedForTimeClosely
                out = "Too close to the pick up time, please contact our reservation center at 1-800-920-LIMO (5466)."



                '## Corporate Login
            Case MsgType.CorporateLoginAcctExpired
                out = "This account is expired. Please renew."
            Case MsgType.CorporateLoginNoAcctFound
                out = "No account found. Please try again."
            Case MsgType.CorporateLoginNotSetUpForOnlineOrdering
                out = "Your account is not set up for on line ordering."
            Case MsgType.CorporateLoginPasswordIncorrect
                out = "Error with password setup. Please try again."
            Case MsgType.CorporateLoginUnknowException
                out = "Failed to login. Please try again."

                '## Delete Profile       
            Case MsgType.FrequentProfileDeleteSuccessful
                out = ""
            Case MsgType.FrequentProfileDeleteFailed
                out = "Failed to delete this profile. Please try again."
            Case MsgType.FrequentProfileUpdateSuccessful
                out = ""
            Case MsgType.FrequentProfileUpdateFailed
                out = "Failed to update profile. Please try again."
            Case MsgType.FrequentProfileDuplicate
                out = "Failed to update, frequent Profile is duplicate."


                '## Delete Address       
            Case MsgType.FrequentAddressDeleteSuccessful
                out = ""
            Case MsgType.FrequentAddressDeleteFailed
                out = "Failed to delete this address. Please try again."
            Case MsgType.FrequentAddressUpdateSuccessful
                out = ""
            Case MsgType.FrequentAddressUpdateFailed
                out = "Failed to update address. Please try again."
            Case MsgType.FrequentAddressDuplicate
                out = "Failed to update, frequent address is duplicate."
        End Select

        Return out
    End Function

    Public Shared Sub GetErrorMsg(ByVal type As MsgType, ByRef page As Page)
        page.ClientScript.RegisterStartupScript(GetType(String), "Message", _
            String.Format("<script type='text/javascript'>alert('{0}')</script>", GetErrorMsg(type)))
    End Sub

    Public Shared Function IsBoro(ByVal county As String, ByVal QueensIsBoro As Boolean) As Boolean
        Dim out As Boolean = False

        Select Case county.Trim().ToLower
            Case "m", "bx", "bk", "si", "manhattan", "brooklyn", "bronx", "staten island"
                out = True
            Case "qu", "queens"
                out = QueensIsBoro
            Case Else
                out = False
        End Select

        Return out
    End Function

    Public Shared Function GetBoroFullName(ByVal BoroCode As String) As String
        Dim out As String

        Select Case BoroCode.Trim.ToLower
            Case "m", "manhattan"
                out = "Manhattan"
            Case "bx", "bronx"
                out = "Bronx"
            Case "bk", "brooklyn"
                out = "Brooklyn"
            Case "si", "staten island"
                out = "Staten Island"
            Case "qu", "queens"
                out = "Queens"
            Case Else
                out = BoroCode
        End Select

        Return out
    End Function

End Class
