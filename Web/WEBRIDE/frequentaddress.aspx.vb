Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System
Imports Business.Common
Imports Business.Security
Imports Business.Operators
Imports Business
Partial Class frequentaddress
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then
            Call LoadData()
            Me.Stop1.LoadStatesAndAirports()

            Dim script As String = String.Format("javascript:return ValidateAddress({0}{2}{1},{0}{3}{1},{0}{4}{1},{0}{5}{1});", _
                    "document.getElementById('", "').value", Me.Stop1.ctlDdlState.ClientID, Me.Stop1.ctlTxtCity.ClientID, Me.Stop1.ctlTxtStName.ClientID, Me.Stop1.ctlTxtStNo.ClientID)

            Me.btnSubmit.Attributes.Add("onclick", script)
        End If

    End Sub

#Region " Private Functions "

    Private Sub LoadData()
        Using geo As New GeoInfos

            Dim ds As DataSet = geo.getFrequent(MySession.UserID, MySession.AcctID, MySession.SubAcctID, MySession.Company, "A")

            If Not ds Is Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                Me.grdFreqAddr.Visible = True

                Try
                    grdFreqAddr.DataSource = ds.Tables(0).DefaultView
                    grdFreqAddr.DataBind()
                Catch
                End Try

                If Me.grdFreqAddr.PageCount <= 1 Then
                    Me.grdFreqAddr.PagerStyle.Visible = False
                Else
                    Me.grdFreqAddr.PagerStyle.Visible = True
                End If
            End If

        End Using

    End Sub

    Private Sub LoadStates(ByRef ddlState As DropDownList)
        '## 1 Boro  2 OT    3 Airport
        '## 12 Boro & OT    123 ALL  and so on
        Dim OT_ONLY As String = 2

        Using geo As New GeoInfos()
            Dim ds As DataSet = geo.GetStates(OT_ONLY, "", "")

            If Not ds Is Nothing AndAlso ds.Tables.Count > 0 Then
                '## Bind Non-airport States
                ddlState.DataSource = ds.Tables(0).DefaultView
                ddlState.DataTextField = "description"
                ddlState.DataValueField = "code"
                ddlState.DataBind()
            End If

            ddlState.Items.Insert(0, "Please Select")
            'Me.ddlAirportState.Items.Insert(0, "ALL")
        End Using

        'ddlState.Attributes.Add("onchange", "javascript:StopModuleSelectState('" & Me.ddlState.ClientID & "','" & Me.txtCity.ClientID & "');")
        ' Me.ddlAirportState.Attributes.Add("onchange", "javascript:StopModuleSelectAirportState(this,document.getElementById('" & Me.ddlAirport.ClientID & "'));")
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click

        If Me.AddressIsValidate(Me.Stop1.ctlDdlState, Me.Stop1.ctlTxtCity, Me.Stop1.ctlTxtStName, Me.Stop1.ctlTxtStNo) Then
            Dim out As Integer = 0
            Dim usr As New UserData

            With usr
                .user_id = MySession.UserID
                .acct_id = MySession.AcctID
                .sub_acct_id = MySession.SubAcctID
                .Company = MySession.Company

                .county = Me.Stop1.State
                .city = Me.Stop1.City
                .st_name = Me.Stop1.StName
                .st_no = Me.Stop1.StNo

                .zip_code = Me.Stop1.Zip
                .PPoint = Me.Stop1.PickupPoint

            End With

            Using geo As New GeoInfos
                out = geo.AddFrequentAddress(usr, Convert.ToString(IIf(Me.radPickup.Checked, "P", "D")))
            End Using

            If out = -2 Then
                Msg.GetErrorMsg(Msg.MsgType.FrequentAddressDuplicate, Me)
            ElseIf out <= 0 Then
                Msg.GetErrorMsg(Msg.MsgType.FrequentAddressUpdateFailed, Me)
            Else
                Me.grdFreqAddr.EditItemIndex = -1
                Me.LoadData()
            End If
        End If
    End Sub

    Private Function AddressIsValidate(ByVal ddlState As DropDownList, ByVal txtCity As TextBox, ByVal txtStName As TextBox, ByVal txtStNo As TextBox) As Boolean
        Dim out As Boolean = True
        Dim msg As String = ""

        If ddlState.SelectedIndex <= 0 Then
            out = False
            msg = "Please select a county."
        ElseIf txtCity.Text.Trim.Length = 0 Then
            out = False
            msg = "Please enter a city."
        ElseIf txtStName.Text.Trim.Length = 0 Then
            out = False
            msg = "Please enter a street name."
        ElseIf txtStNo.Text.Trim.Length = 0 Then
            out = False
            msg = "Please enter a street #."
            'ElseIf txtzip.Text.Trim.Length = 0 Then   'changed by lily 02/13/2008
            '    out = False
            '    msg = "Please enter a zip code."
            'ElseIf txtppoint.Text.Trim.Length = 0 Then
            '    out = False
            '    msg = "Please enter a pick up point."
        End If

        If Not out AndAlso msg.Trim.Length > 0 Then
            Me.ClientScript.RegisterStartupScript(GetType(String), "validate", String.Format("<script type='text/javascript'>alert('{0}');</script>", msg))
        End If

        Return out
    End Function
#End Region

#Region " Data Grid Events "

    Protected Sub grdFrequentAddress_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdFreqAddr.EditCommand
        grdFreqAddr.EditItemIndex = e.Item.ItemIndex
        Me.LoadData()
    End Sub

    Protected Sub grdFrequentAddress_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdFreqAddr.DeleteCommand
        Dim out As Integer = 0
        Dim usr As New UserData

        Dim lblOldCounty As Label = CType(e.Item.FindControl("lblOldCounty"), Label)
        Dim lblOldCity As Label = CType(e.Item.FindControl("lblOldCity"), Label)
        Dim lblOldStName As Label = CType(e.Item.FindControl("lblOldStName"), Label)
        Dim lblOldStNo As Label = CType(e.Item.FindControl("lblOldStNo"), Label)
        Dim lblOldAddrType As Label = CType(e.Item.FindControl("lblOldAddrType"), Label)

        usr.acct_id = MySession.AcctID
        usr.sub_acct_id = MySession.SubAcctID
        usr.Company = MySession.Company
        usr.user_id = MySession.UserID

        usr.county = lblOldCounty.Text
        usr.city = lblOldCity.Text
        usr.st_name = lblOldStName.Text
        usr.st_no = lblOldStNo.Text
       

        Using geo As New Business.GeoInfos
            out = geo.DeleteFrequentAddress(usr, lblOldAddrType.Text.Trim.ToUpper())
        End Using

        If out <= 0 Then
            Msg.GetErrorMsg(Msg.MsgType.FrequentAddressDeleteFailed, Me)
        Else
            Me.grdFreqAddr.EditItemIndex = -1
            Me.LoadData()
        End If

    End Sub

    Protected Sub grdFrequentAddress_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdFreqAddr.UpdateCommand

        Dim out As Integer = 0
        Dim usr As New UserData

        Dim ddlNewCounty As DropDownList = CType(e.Item.FindControl("ddlState"), DropDownList)
        Dim txtNewCity As TextBox = CType(e.Item.FindControl("txtCity"), TextBox)
        Dim txtNewStName As TextBox = CType(e.Item.FindControl("txtStName"), TextBox)
        Dim txtNewStNo As TextBox = CType(e.Item.FindControl("txtStNo"), TextBox)

        Dim txtNewZip As TextBox = CType(e.Item.FindControl("txtzip"), TextBox)
        Dim txtNewPoint As TextBox = CType(e.Item.FindControl("txtpoint"), TextBox)

        Dim radPickup As RadioButton = CType(e.Item.FindControl("radPickup"), RadioButton)

        If Me.AddressIsValidate(ddlNewCounty, txtNewCity, txtNewStName, txtNewStNo) Then
            Dim lblOldCounty As Label = CType(e.Item.FindControl("lblOldCounty"), Label)
            Dim lblOldCity As Label = CType(e.Item.FindControl("lblOldCity"), Label)
            Dim lblOldStName As Label = CType(e.Item.FindControl("lblOldStName"), Label)
            Dim lblOldStNo As Label = CType(e.Item.FindControl("lblOldStNo"), Label)
            Dim lblOldAddrType As Label = CType(e.Item.FindControl("lblOldAddrType"), Label)

            usr.acct_id = MySession.AcctID
            usr.sub_acct_id = MySession.SubAcctID
            usr.Company = MySession.Company
            usr.user_id = MySession.UserID

            usr.county = ddlNewCounty.SelectedValue.Trim
            usr.city = txtNewCity.Text.Trim
            usr.st_name = txtNewStName.Text.Trim
            usr.st_no = txtNewStNo.Text.Trim

            usr.zip_code = txtNewZip.Text.Trim
            usr.PPoint = txtNewPoint.Text.Trim

            Using geo As New Business.GeoInfos
                out = geo.UpdateFrequentAddress(usr, lblOldAddrType.Text.Trim, Convert.ToString(IIf(radPickup.Checked, "P", "D")), _
                            lblOldCounty.Text.Trim, lblOldCity.Text.Trim, lblOldStName.Text.Trim, lblOldStNo.Text.Trim)
            End Using

            If out = -2 Then
                Msg.GetErrorMsg(Msg.MsgType.FrequentAddressDuplicate, Me)
            ElseIf out <= 0 Then
                Msg.GetErrorMsg(Msg.MsgType.FrequentAddressUpdateFailed, Me)
            Else
                Me.grdFreqAddr.EditItemIndex = -1
                Me.LoadData()
            End If
        End If
    End Sub

    Protected Sub grdFrequentAddress_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdFreqAddr.CancelCommand
        Me.grdFreqAddr.EditItemIndex = -1
        Me.LoadData()
    End Sub

    Protected Sub grdFrequentAddress_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdFreqAddr.PageIndexChanged
        Me.grdFreqAddr.CurrentPageIndex = e.NewPageIndex
        Me.LoadData()
    End Sub

    Protected Sub grdFrequentAddress_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdFreqAddr.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lnkEdit As LinkButton = CType(e.Item.FindControl("lnkEdit"), LinkButton)
            Dim lnkDelete As LinkButton = CType(e.Item.FindControl("lnkDelete"), LinkButton)

            lnkEdit.CausesValidation = False
            lnkDelete.CausesValidation = False

            lnkDelete.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this address?');")
        ElseIf e.Item.ItemType = ListItemType.EditItem Then
            Dim lnkUpdate As LinkButton = CType(e.Item.FindControl("lnkUpdate"), LinkButton)
            Dim lnkCancel As LinkButton = CType(e.Item.FindControl("lnkCancel"), LinkButton)
            Dim ddlState As DropDownList = CType(e.Item.FindControl("ddlState"), DropDownList)
            Dim radPickup As RadioButton = CType(e.Item.FindControl("radPickup"), RadioButton)
            Dim radDest As RadioButton = CType(e.Item.FindControl("radDest"), RadioButton)

            Dim ddlNewCounty As DropDownList = CType(e.Item.FindControl("ddlState"), DropDownList)
            Dim txtNewCity As TextBox = CType(e.Item.FindControl("txtCity"), TextBox)
            Dim txtNewStName As TextBox = CType(e.Item.FindControl("txtStName"), TextBox)
            Dim txtNewStNo As TextBox = CType(e.Item.FindControl("txtStNo"), TextBox)

            Dim county As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "county")).Trim
            Dim addressType As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "address_type")).Trim.ToUpper

            Me.LoadStates(ddlState)

            Common.ShowDropDownValue(ddlState, county, False)
            If addressType = "P" Then
                radPickup.Checked = True
            Else
                radDest.Checked = True
            End If

            lnkUpdate.CausesValidation = False
            lnkCancel.CausesValidation = False

            Dim script As String = String.Format("javascript:return ValidateAddress({0}{2}{1},{0}{3}{1},{0}{4}{1},{0}{5}{1});", _
                    "document.getElementById('", "').value", ddlNewCounty.ClientID, txtNewCity.ClientID, txtNewStName.ClientID, txtNewStNo.ClientID)

            lnkUpdate.Attributes.Add("onclick", script)
        End If
    End Sub

#End Region

  
End Class
