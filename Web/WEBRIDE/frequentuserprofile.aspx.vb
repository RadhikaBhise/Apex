Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System
Imports Business.Common
Imports Business.Security
Imports Business.Operators
Imports Business

Partial Class frequentuserprofile
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

            Call LoadData()
            'Me.fname.Attributes.Add("onkeypress", "javascript:entervalues();")
            'Me.lname.Attributes.Add("onkeypress", "javascript:entervalues();")
            'Me.email.Attributes.Add("onkeypress", "javascript:entervalues();")
            'Me.officephone.Attributes.Add("onkeypress", "javascript:entervalues();")
            'Me.officephoneext.Attributes.Add("onkeypress", "javascript:entervalues();")
            'Me.btnSubmit.Attributes.Add("onClick", "return batchValidate();")
        End If

    End Sub

#Region " Private Functions "

    Private Sub LoadData()

        Using user As New Users

            Dim ds As DataSet = user.GetFrequentProfile(MySession.UserID, MySession.AcctID, MySession.SubAcctID, MySession.Company)

            If Not ds Is Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                Me.grdFrequentUser.Visible = True

                Try
                    grdFrequentUser.DataSource = ds.Tables(0).DefaultView
                    grdFrequentUser.DataBind()
                Catch
                End Try

                If Me.grdFrequentUser.PageCount <= 1 Then
                    Me.grdFrequentUser.PagerStyle.Visible = False
                Else
                    Me.grdFrequentUser.PagerStyle.Visible = True
                End If
            End If

        End Using

    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click

        If Me.IsValid Then

            Dim out As Integer = 0
            Dim usr As New UserData

            With usr
                .user_id = MySession.UserID
                .acct_id = MySession.AcctID
                .sub_acct_id = MySession.SubAcctID
                .Company = MySession.Company

                .fname = Me.txtFname.Text.Trim()
                .lname = Me.txtLname.Text.Trim()
                .office_phone = Me.txtPhone.Text.Trim()
                .office_phone_ext = Me.txtPhoneExt.Text.Trim()
                .email = Me.txtEmail.Text.Trim()
            End With

            Using user As New Users
                out = user.AddFrequentProfile(usr)
            End Using

            If out = -2 Then
                Msg.GetErrorMsg(Msg.MsgType.FrequentProfileDuplicate, Me)
            ElseIf out <= 0 Then
                Msg.GetErrorMsg(Msg.MsgType.FrequentProfileUpdateFailed, Me)
            Else
                Me.grdFrequentUser.EditItemIndex = -1
                Me.LoadData()

                Me.txtEmail.Text = ""
                Me.txtLname.Text = ""
                Me.txtFname.Text = ""
                Me.txtPhone.Text = ""
                Me.txtPhoneExt.Text = ""
            End If
        End If
    End Sub

#End Region

#Region " Data Grid Events "

    Protected Sub grdFrequentUser_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdFrequentUser.EditCommand
        grdFrequentUser.EditItemIndex = e.Item.ItemIndex
        Me.LoadData()
    End Sub

    Protected Sub grdFrequentUser_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdFrequentUser.DeleteCommand
        Dim out As Integer = 0
        Dim usr As New UserData
        Dim lblOldLName As Label = CType(e.Item.FindControl("lblOldLName"), Label)
        Dim lblOldFName As Label = CType(e.Item.FindControl("lblOldFName"), Label)

        usr.acct_id = MySession.AcctID
        usr.sub_acct_id = MySession.SubAcctID
        usr.Company = MySession.Company
        usr.user_id = MySession.UserID

        usr.lname = lblOldLName.Text
        usr.fname = lblOldFName.Text

        Using user As New Business.Users
            out = user.DeleteFrequentProfile(usr)
        End Using

        If out <= 0 Then
            Msg.GetErrorMsg(Msg.MsgType.FrequentProfileDeleteFailed, Me)
        Else
            Me.grdFrequentUser.EditItemIndex = -1
            Me.LoadData()
        End If

    End Sub

    Protected Sub grdFrequentUser_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdFrequentUser.UpdateCommand
        Dim out As Integer = 0
        Dim usr As New UserData

        Dim txtLname As TextBox = CType(e.Item.FindControl("txtLname"), TextBox)
        Dim txtFname As TextBox = CType(e.Item.FindControl("txtFname"), TextBox)
        Dim txtPhone As TextBox = CType(e.Item.FindControl("txtPhone"), TextBox)
        Dim txtPhoneExt As TextBox = CType(e.Item.FindControl("txtPhoneExt"), TextBox)
        Dim txtEmail As TextBox = CType(e.Item.FindControl("txtEmail"), TextBox)

        Dim lblOldLName As Label = CType(e.Item.FindControl("lblOldLName"), Label)
        Dim lblOldFName As Label = CType(e.Item.FindControl("lblOldFName"), Label)

        usr.acct_id = MySession.AcctID
        usr.sub_acct_id = MySession.SubAcctID
        usr.Company = MySession.Company
        usr.user_id = MySession.UserID

        usr.lname = txtLname.Text
        usr.fname = txtFname.Text
        usr.office_phone = txtPhone.Text
        usr.office_phone_ext = txtPhoneExt.Text
        usr.email = txtEmail.Text

        Using user As New Business.Users
            out = user.UpdateFrequentProfile(usr, lblOldLName.Text, lblOldFName.Text)
        End Using

        If out = -2 Then
            Msg.GetErrorMsg(Msg.MsgType.FrequentProfileDuplicate, Me)
        ElseIf out <= 0 Then
            Msg.GetErrorMsg(Msg.MsgType.FrequentProfileUpdateFailed, Me)
        Else
            Me.grdFrequentUser.EditItemIndex = -1
            Me.LoadData()
        End If
    End Sub

    Protected Sub grdFrequentUser_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdFrequentUser.CancelCommand
        Me.grdFrequentUser.EditItemIndex = -1
        Me.LoadData()
    End Sub

    Protected Sub grdFrequentUser_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdFrequentUser.PageIndexChanged
        Me.grdFrequentUser.CurrentPageIndex = e.NewPageIndex
        Me.LoadData()
    End Sub

    Protected Sub grdFrequentUser_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdFrequentUser.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lnkEdit As LinkButton = CType(e.Item.FindControl("lnkEdit"), LinkButton)
            Dim lnkDelete As LinkButton = CType(e.Item.FindControl("lnkDelete"), LinkButton)

            lnkEdit.CausesValidation = False
            lnkDelete.CausesValidation = False

            lnkDelete.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this profile?');")
        ElseIf e.Item.ItemType = ListItemType.EditItem Then
            Dim lnkUpdate As LinkButton = CType(e.Item.FindControl("lnkUpdate"), LinkButton)
            Dim lnkCancel As LinkButton = CType(e.Item.FindControl("lnkCancel"), LinkButton)

            lnkUpdate.CausesValidation = False
            lnkCancel.CausesValidation = False
        End If
    End Sub

#End Region

    ''-----------------------------------------------------------------------------------
    ''--Sub:AriseJavaScript
    ''--Description:To show the error message
    ''--Input:ErrorMessage
    ''--Output:
    ''--11/09/04 - Created (eJay)
    ''-----------------------------------------------------------------------------------
    'Private Sub AriseJavaScript(ByVal ErrorMessage As String)

    '    Dim strMessage As String
    '    strMessage = "<script language='javascript'>alert(" & ErrorMessage & ");</script>"
    '    RegisterStartupScript("PopUpMessage", strMessage)

    'End Sub

    'Private Sub SetTextBoxValue(ByVal Page As Control, ByVal TextBoxValue As String)
    '    For Each ctl As Control In Page.Controls
    '        If TypeOf ctl Is TextBox Then
    '            CType(ctl, TextBox).Text = TextBoxValue
    '        Else
    '            If ctl.Controls.Count > 0 Then
    '                SetTextBoxValue(ctl, TextBoxValue)
    '            End If
    '        End If
    '    Next
    'End Sub

    'Protected Sub lnkAddprofile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAddprofile.Click
    '    Me.linkAdd.Visible = False
    '    Me.adduser.Visible = True

    'End Sub

    ''Protected Sub grdFrequentUser_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdFrequentUser.ItemCommand
    ''    If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
    ''    End If
    ''End Sub

End Class
