Imports Business
Imports DataAccess
Imports System.Data
Imports System.Data.SqlClient
Partial Class RptOfZone
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.btn_Submit.Attributes.Add("OnClick", "return DateValidate('" & Session("group_login_flag") & "');")
        Me.radAtoA.Attributes.Add("onclick", "AirOrCity();")
        Me.radAtoC.Attributes.Add("onclick", "AirOrCity();")
        Me.radCtoA.Attributes.Add("onclick", "AirOrCity();")
        Me.radCtoC.Attributes.Add("onclick", "AirOrCity();")
        Me.btnPCity_Search.Attributes.Add("onclick", "citylookup('p'); return false;")
        Me.btnDCity_Search.Attributes.Add("onclick", "citylookup('d'); return false;")

        If Not Page.IsPostBack Then
            Dim date_FromDate As Date
            date_FromDate = DateValue(DateAdd("m", -6, Now))
            txt_FromTrip.Text = Format(date_FromDate, "M\/d\/yyyy")
            txt_ToTrip.Text = Format(Now, "M\/d\/yyyy")
            Call getState()
            Call Me.Init_Date()
            If Convert.ToString(Session("group_login_flag")).Trim() = "Y" Then
                getSelectAcctid()
                Me.trSelAcct.Visible = True
                Me.trSelList.Visible = True
            Else
                Me.trSelAcct.Visible = False
                Me.trSelList.Visible = False
            End If
        End If
    End Sub
    Private Sub getState()
        Dim objState As New Report
        Dim objDate As New DataSet

        objDate = objState.GetAllState()
        If Not objDate Is Nothing Then
            If objDate.Tables.Count > 0 Then
                If objDate.Tables(0).Rows.Count > 0 Then

                    Me.ddlLstate.DataSource = objDate.Tables(0)
                    Me.ddlLstate.DataValueField = "state_name"
                    Me.ddlLstate.DataTextField = "state_desc"
                    Me.ddlLstate.DataBind()

                    Me.ddlRstate.DataSource = objDate.Tables(0)
                    Me.ddlRstate.DataValueField = "state_name"
                    Me.ddlRstate.DataTextField = "state_desc"
                    Me.ddlRstate.DataBind()
                End If
            End If
        End If
        Me.ddlLstate.Items.Insert(0, New ListItem("All", "All"))
        Me.ddlRstate.Items.Insert(0, New ListItem("All", "All"))
    End Sub
    Private Sub getSelectAcctid()
        Dim objAcct As New Users
        Dim objDS As New dataset
        Dim strgroupid As Int32
        Dim strvalue As String
        Dim strtext As String

        strgroupid = Convert.ToInt32(Session("group_id"))
        objDS = objAcct.GetSelectAcct(strgroupid)

        If Not objDS Is Nothing Then
            If objDS.Tables.Count > 0 Then
                If objDS.Tables(0).Rows.Count > 0 Then
                    Me.listAcct.DataSource = objDS.Tables(0)
                    With objDS.Tables(0)
                        Dim n As Integer
                        For n = 0 To .Rows.Count - 1
                            strvalue = .Rows(n).Item("acct_id").ToString.Trim()
                            strtext = .Rows(n).Item("acct_id").ToString.Trim() & " - " & .Rows(n).Item("name").ToString.Trim()
                            Me.listAcct.Items.Add(New ListItem(strtext, strvalue))
                        Next
                    End With
                End If
            End If
        End If
    End Sub
    Protected Function getSelectAcct() As String
        Dim strselacct As String = ""
        If Convert.ToString(Session("group_login_flag")).Trim() = "Y" Then
            Dim n As Integer
            For n = 0 To Me.listAcct.Items.Count - 1
                If Me.listAcct.Items(n).Selected Then
                    strselacct = strselacct & Me.listAcct.Items(n).Value.ToString.Trim() & ","
                End If
            Next
            If strselacct = "" Then
            Else
                strselacct = Mid(strselacct, 1, strselacct.Length - 1)
            End If
        Else
            strselacct = ""
        End If
        Return strselacct
    End Function

    Protected Sub btn_Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Submit.Click
        Dim strSelAcct As String
        Dim strFromdate As String
        Dim strTodate As String
        Dim strArgs As String
        Dim strDaytype As String
        Dim strZone As String
        Dim strReser As String
        Dim strPstate As String
        Dim strDstate As String
        Dim strPcity As String
        Dim strDcity As String

        strSelAcct = getSelectAcct()
        strFromdate = Me.txt_FromTrip.Text.Trim()
        strTodate = Me.txt_ToTrip.Text.Trim()
        If Me.radTip.Checked = True Then
            strDaytype = "t"
        Else
            strDaytype = "i"
        End If
        If Me.radAtoA.Checked = True Then
            strZone = "1"
            strPstate = Me.txtlAir.Text.ToString.Trim()
            strPcity = ""
            strDstate = Me.txtrAir.Text.ToString.Trim()
            strDcity = ""
        End If
        If Me.radAtoC.Checked = True Then
            strZone = "2"
            strPstate = Me.txtlAir.Text.ToString.Trim()
            strPcity = ""
            strDstate = Me.ddlRstate.SelectedValue.ToString.Trim()
            strDcity = Me.txtRcity.Text.Trim()
        End If
        If Me.radCtoA.Checked = True Then
            strZone = "3"
            strPstate = Me.ddlLstate.SelectedValue.ToString.Trim()
            strPcity = Me.txtLcity.Text.Trim()
            strDstate = Me.txtrAir.Text.ToString.Trim()
            strDcity = ""
        End If
        If Me.radCtoC.Checked = True Then
            strZone = "4"
            strPstate = Me.ddlLstate.SelectedValue.ToString.Trim()
            strPcity = Me.txtLcity.Text.Trim()
            strDstate = Me.ddlRstate.SelectedValue.ToString.Trim()
            strDcity = Me.txtRcity.Text.Trim()
        End If

        If Me.chkReserve.Checked = True Then
            strReser = "Y"
        Else
            strReser = "N"
        End If
        strArgs = "SelAcctId=" & strSelAcct & "&Fromdate=" & strFromdate & "&Todate=" & strTodate & "&Daytype=" & strDaytype & "&Zone=" & strZone & "&Pstate=" & strPstate & "&Dstate=" & strDstate & "&Pcity=" & strPcity & "&Dcity=" & strDcity & "&Reser=" & strReser

        Response.Redirect("ZoneOfReport.aspx?" & strArgs & "&Req=QueryStatistics")
    End Sub

    Protected Sub btnLsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLsearch.Click
        '## 12/17/2007  disabled errors (yang)
        'Dim gi As New GeoInfos
        'Dim tmpDS As DataSet = gi.search_airports("", Me.txtlAir.Text.Trim)
        'If (Not tmpDS Is Nothing) AndAlso tmpDS.Tables.Count > 0 And tmpDS.Tables(0).Rows.Count > 0 Then
        '    Me.dlstPAirport.DataSource = tmpDS
        '    Me.dlstPAirport.DataBind()
        '    Me.dlstPAirport.Visible = True
        '    'Me.lblNone.Visible = False
        'Else
        '    Me.dlstPAirport.Visible = False
        '    'Me.lblNone.Visible = True
        '    'Me.lblNone.Text = "Sorry. No matching results found."
        'End If
        'gi.Dispose()
        'gi = Nothing
        'tmpDS.Dispose()
        'tmpDS = Nothing
    End Sub

    Protected Sub dlstPAirport_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlstPAirport.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim strCode, strName As String
            strCode = DataBinder.Eval(e.Item.DataItem, "code").ToString
            strName = DataBinder.Eval(e.Item.DataItem, "description").ToString
            CType(e.Item.FindControl("hyPAirName"), HyperLink).Text = strName
            CType(e.Item.FindControl("hyPAirName"), HyperLink).Attributes.Add("onclick", "javascript:GetSearchValue('P','Airport','" & strCode & "');")
            CType(e.Item.FindControl("hyPAirName"), HyperLink).NavigateUrl = "#"

        End If
    End Sub

    Protected Sub dlstDAirport_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlstDAirport.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim strCode, strName As String
            strCode = DataBinder.Eval(e.Item.DataItem, "code").ToString
            strName = DataBinder.Eval(e.Item.DataItem, "description").ToString
            CType(e.Item.FindControl("hyDAirName"), HyperLink).Text = strName
            CType(e.Item.FindControl("hyDAirName"), HyperLink).Attributes.Add("onclick", "javascript:GetSearchValue('D','Airport','" & strCode & "');")
            CType(e.Item.FindControl("hyDAirName"), HyperLink).NavigateUrl = "#"

        End If
    End Sub

    Protected Sub btnRsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRsearch.Click
        '## 12/17/2007  disabled errors (yang)
        'Dim gi As New GeoInfos
        'Dim tmpDS As DataSet = gi.search_airports("", Me.txtrAir.Text.Trim)
        'If (Not tmpDS Is Nothing) AndAlso tmpDS.Tables.Count > 0 And tmpDS.Tables(0).Rows.Count > 0 Then
        '    Me.dlstDAirport.DataSource = tmpDS
        '    Me.dlstDAirport.DataBind()
        '    Me.dlstDAirport.Visible = True
        '    'Me.lblNone.Visible = False
        'Else
        '    Me.dlstDAirport.Visible = False
        '    'Me.lblNone.Visible = True
        '    'Me.lblNone.Text = "Sorry. No matching results found."
        'End If
        'gi.Dispose()
        'gi = Nothing
        'tmpDS.Dispose()
        'tmpDS = Nothing
    End Sub

    Public Sub Init_Date()
        '## 12/17/2007  disabled errors (yang)
        'Dim objGeo As New Business.GeoInfos
        ''-- load states
        'With Me.ddlLstate
        '    .DataSource = objGeo.getAllState
        '    .DataTextField = "state_desc"
        '    .DataValueField = "state_name"
        '    .DataBind()
        '    .Items.Insert(0, New ListItem("-", ""))

        '    'If Not .Items.FindByValue(strStateAbbre) Is Nothing Then
        '    '    .Items.FindByValue(strStateAbbre).Selected = True
        '    'End If
        '    .SelectedValue = "NY"
        'End With
        'With Me.ddlRstate
        '    .DataSource = objGeo.getAllState
        '    .DataTextField = "state_desc"
        '    .DataValueField = "state_name"
        '    .DataBind()
        '    .Items.Insert(0, New ListItem("-", ""))
        '    'If Not .Items.FindByValue(strStateAbbre) Is Nothing Then
        '    '    .Items.FindByValue(strStateAbbre).Selected = True
        '    'End If
        '    .SelectedValue = "NY"
        'End With
        ''End If
        'objGeo.Dispose()
        'objGeo = Nothing
    End Sub

End Class
