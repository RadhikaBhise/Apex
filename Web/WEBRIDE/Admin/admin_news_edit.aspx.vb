Imports Business
Imports System.Data

Partial Class Admin_admin_news_edit
    Inherits System.Web.UI.Page

    Protected Sub LnkBtnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkBtnNew.Click

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.btnUpdate.Attributes.Add("onclick", "return batchValidate();")

        If Not Page.IsPostBack Then

            If Not Session("admin") Is Nothing Then
                '--do nothing
            Else
                Response.Redirect("login.aspx", True)
            End If

            Dim strStyle As String
            Dim strid As String
            strStyle = Request.QueryString("style")
            strid = Request.QueryString("ID")

            If Not strid Is Nothing Then
                Me.hidtxtid.Value = strid
            End If
            If strStyle = "add" Then
                Call clearAll()
                ViewState("state") = "add"
            Else
                'do nothing
                Call GetInfoBy_term_date(strid)
                ViewState("state") = "edit"
            End If

        End If

    End Sub

    Public Sub clearAll()
        Me.txtsummary_text.Text = ""
        Me.txtSummarytitle.Text = ""
        Me.txtfull_text.Text = ""
        Me.txtfull_title.Text = ""
    End Sub

    Public Function GetInfoBy_term_date(ByVal ID As String)
        Dim objusers As New News
        Dim objDateset As DataSet

        objDateset = objusers.GetNewsInformationsByID(ID)
        objusers.Dispose() : objusers = Nothing

        If Not objDateset Is Nothing Then
            If objDateset.Tables.Count > 0 Then
                If objDateset.Tables(0).Rows.Count > 0 Then
                    Me.txtSummarytitle.Text = Me.Check_DBNULL(objDateset.Tables(0).Rows(0).Item("summary_title"))
                    Me.txtsummary_text.Text = Me.Check_DBNULL(objDateset.Tables(0).Rows(0).Item("summary_text"))
                    Me.txtfull_title.Text = Me.Check_DBNULL(objDateset.Tables(0).Rows(0).Item("full_title"))
                    Me.txtfull_text.Text = Me.Check_DBNULL(objDateset.Tables(0).Rows(0).Item("full_text"))
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
        Dim objIntState As Int16
        '--first check exist the data in database
        Dim objExistBoolean As Boolean
        objExistBoolean = objusers.Add_NewsInformations(Me.hidtxtid.Value, Me.txtSummarytitle.Text.Trim, Me.txtsummary_text.Text.Trim, Me.txtfull_title.Text.Trim, Me.txtfull_text.Text.Trim)

        If objExistBoolean = True Then
            Response.Redirect("admin_news.aspx?msg=CreateSuccess", True)
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
