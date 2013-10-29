Imports Microsoft.VisualBasic
Imports System.Web.HttpContext

Public Class Msg

    Public Enum MsgType
        'added bu lily 12/12/2007
        'user logon 
        UserLoginNoTime
        UserLoginNoUser
        UserLoginPwdIncorrect
        UserLoginNoAccount
        UserLoginReNew
        UserLoginNoNet
        UserLoginConnectSQLerror
        UserLoginLevelError

        'added by lily 12/13/2007
        'set password
        SetUPPasswordError

        'added by lily 12/14/2007
        'fail to get Employee information
        NoEmployeeInformation


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
    End Enum

    Public Shared Function GetErrorMsg(ByVal type As MsgType) As String
        Dim out As String = ""

        Select Case type
            'added by lily 12/12/2007
            'user logon
            Case MsgType.UserLoginNoTime
                out = "Online order is blocked for now!\n\rPlease call 1-800-FLY-1800 to make a reservation."
            Case MsgType.UserLoginNoUser
                out = "No User Found. Please Try again."
            Case MsgType.UserLoginPwdIncorrect
                out = "Password is incorrect. Please try again."
            Case MsgType.UserLoginNoAccount
                out = "No account found. Please try again."
            Case MsgType.UserLoginReNew
                out = "This account is expired. Please renew."
            Case MsgType.UserLoginNoNet
                out = "Your account is not set up for on line ordering."
            Case MsgType.UserLoginConnectSQLerror
                out = "Connect SQL Server Error!."
            Case MsgType.UserLoginLevelError
                out = "This user does not have the correct level permission!"

                'added by lily 12/13/2007
            Case MsgType.SetUPPasswordError
                out = "Error with password setup. Please try again!"

                'added by lily 12/14/2007
                'fail to get Employee information
            Case MsgType.NoEmployeeInformation
                out = "No information about the ACCOUNT! Please try again..."


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
        End Select

        Return out
    End Function

    Public Shared Sub GetErrorMsg(ByVal type As MsgType, ByRef page As Page)
        page.ClientScript.RegisterStartupScript(GetType(String), "Message", _
            String.Format("<script type='text/javascript'>alert('{0}')</script>", GetErrorMsg(type)))

    End Sub

    Public Shared Function IsBoro(ByVal county As String) As Boolean
        Dim out As Boolean = False
        Select Case county.Trim().ToLower
            Case "m", "bx", "bk", "si", "manhattan", "brooklyn", "bronx", "staten island"
                out = True
            Case Else
                out = False
        End Select

        Return out
    End Function

End Class
