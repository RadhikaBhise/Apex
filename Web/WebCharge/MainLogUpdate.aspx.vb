Imports Business
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess
Partial Class MainLogUpdate
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.IsPostBack Then
            If Not MySession.UserID Is Nothing Then
                Me.lblVipno.Text = Convert.ToString(MySession.UserID).Trim()
            Else
                Me.lblVipno.Text = ""
            End If
            If Not MySession.AcctID Is Nothing Then
                Me.lblAcct.Text = Convert.ToString(MySession.AcctID).Trim()
            Else
                Me.lblAcct.Text = ""
            End If

        End If
        Me.btnSubmit.Attributes.Add("onclick", "return CheckPass();")
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click
        Dim strVip As String
        Dim strAcct As String
        Dim strSubAcct As String
        Dim strOpass As String
        Dim strNpass As String
        Dim strCpass As String

        If Not MySession.UserID Is Nothing Then
            strVip = Convert.ToString(MySession.UserID).Trim()
        Else
            strVip = ""
        End If
        If Not MySession.AcctID Is Nothing Then
            strAcct = Convert.ToString(MySession.AcctID).Trim()
        Else
            strAcct = ""
        End If
        If Not MySession.SubAcctID Is Nothing Then
            strSubAcct = Convert.ToString(MySession.SubAcctID).Trim()
        Else
            strSubAcct = ""
        End If
        strOpass = Me.txtOpass.Text.Trim()
        strNpass = Me.txtNpass.Text.Trim()
        strCpass = Me.txtCpass.Text.Trim()

        Dim strResult As String
        Dim objReport As New Report

        strResult = objReport.UpdateMainLog(strAcct, strSubAcct, strVip, strOpass, strNpass)

        If strResult = "0" Then
            Dim strMessage As String = "<script language=""JavaScript"">alert('Update failed!');" & _
                                           "history.go(-1);</script>"
            ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage", strMessage)
        ElseIf strResult = "1" Then
            Dim strMessage As String = "<script language=""JavaScript"">alert('The logon has been successfully updated!');" & _
                                                       "history.go(-1);</script>"
            ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage", strMessage)
        Else

        End If
    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnReset.Click
        Me.txtOpass.Text = ""
        Me.txtNpass.Text = ""
        Me.txtCpass.Text = ""
    End Sub

End Class
