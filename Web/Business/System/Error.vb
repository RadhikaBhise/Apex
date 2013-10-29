Imports System
Imports System.Web

Public Class Err

#Region " Order_entry Exception -10-"

#End Region

#Region " Ride_history Exception -20-"

#End Region

#Region " Ride_status Exception -30-"

#End Region

#Region " User_profile Exception -40-"

    Private Const INVALID_PASSWORD As Int32 = 4000
    Private Const PASSWORD_NOT_MATCH As Int32 = 4001
    Private Const INVALID_EXPIRATION_DATE As Int32 = 4002
    Private Const USER_UPDATED As Int32 = 4003
    Private Const USER_INSERT_FAILED As Int32 = 4004
    Private Const USER_INSERTED As Int32 = 4005

#End Region

    '-----------------------------------------------------------------
    '--Function:GetExceptionMessage
    '--Description:Return Exception Message back to page
    '--Input:Errod ID that defined above
    '--Output:Exception Message
    '--10/29/04 - Created (eJay)
    '-----------------------------------------------------------------
    Public Shared Function ErrorDisplay(ByVal ErrorID As Int32) As String

        Dim strErrDetail As String

        Select Case ErrorID
            Case 4003
                strErrDetail = "User Updated!"
            Case 4002
                strErrDetail = "ERROR: Invalid CC expiration Date. Please Try Again."
            Case 4001
                strErrDetail = "ERROR: Passwords Did Not Match!"
            Case 4000
                strErrDetail = "Please enter your current password." '"INVALID Password!"
            Case 4004
                strErrDetail = "User name not available.Please enter a new user name."
            Case 4005
                strErrDetail = "User Insert!"
            Case 4006
                strErrDetail = "Already has this user!"

        End Select

        Return strErrDetail

    End Function



End Class