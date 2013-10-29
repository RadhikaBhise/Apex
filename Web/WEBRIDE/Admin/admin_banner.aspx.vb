Imports Business
Imports System.Data

Partial Class Admin_admin_banner
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.btnUpdate.Attributes.Add("onclick", "return batchValidate();")

        Dim strmsg As String
        strmsg = Request.QueryString("msg")
        If Not strmsg Is Nothing Then
            Select Case strmsg
                Case "CreateSuccess"
                    Call Me.AriseJavaScript("'Saved News successfully!'")
                    Response.Redirect("admin_main.aspx", True)
                Case Else
                    '--do nothing
            End Select
        End If
        If Not Page.IsPostBack Then

            If Not Session("admin") Is Nothing Then
                '--do nothing
            Else
                Response.Redirect("login.aspx", True)
            End If

            Call GetBanner()

        End If

    End Sub

    Public Sub clearAll()
        Me.txtcontent.Text = ""
    End Sub

    Public Function GetBanner()
        Dim objusers As New News
        Dim objDateset As DataSet

        objDateset = objusers.GetBannerInformations()
        objusers.Dispose() : objusers = Nothing

        If Not objDateset Is Nothing Then
            If objDateset.Tables.Count > 0 Then
                If objDateset.Tables(0).Rows.Count > 0 Then
                    Me.txtcontent.Text = Me.Check_DBNULL(objDateset.Tables(0).Rows(0).Item("content"))
                End If
            End If
        End If

        objDateset.Dispose()
        objDateset = Nothing

    End Function

    '-------------------------------------------------------------------
    '--Function:Check_DBNULL
    '--Description:Check the value 
    '--Input:Value
    '--Output:Nothing for DBNULL
    '--11/4/04 - Created (Daniel)
    '-------------------------------------------------------------------
    Private Function Check_DBNULL(ByVal Value As Object) As String

        If IsDBNull(Value) = True Then
            Return Nothing
        Else
            Return Convert.ToString(Value).Trim()
        End If

    End Function

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim objusers As New News
        Dim objExistBoolean As Boolean
        objExistBoolean = objusers.Add_BannerInformations(Me.txtcontent.Text.Trim)

        If objExistBoolean = True Then
            Response.Redirect("admin_banner.aspx?msg=CreateSuccess", True)
        Else
            objusers.Dispose()
            objusers = Nothing
            Call Me.AriseJavaScript("'The record has already existed in database. Try again!'")
        End If

    End Sub

    '-----------------------------------------------------------------------------------
    '--Sub:AriseJavaScript
    '--Description:To show the error message
    '--Input:ErrorMessage
    '--Output:
    '--11/09/04 - Created (eJay)
    '-----------------------------------------------------------------------------------
    Private Sub AriseJavaScript(ByVal ErrorMessage As String)

        Dim strMessage As String
        strMessage = "<script language=""JavaScript"">alert("
        strMessage = strMessage & ErrorMessage
        strMessage = strMessage & ");"
        'strMessage = strMessage & "document.forms[0].txtUser.focus();"
        'strMessage = strMessage & "document.all['txtUsername'].focus();"
        strMessage = strMessage & "</script>"

        'Response.Write(strMessage)
        'RegisterStartupScript("PopUpMessage", "<script language=""JavaScript"">document.all['password0'].focus();</script>")
        RegisterStartupScript("PopUpMessage", strMessage)

    End Sub

End Class
