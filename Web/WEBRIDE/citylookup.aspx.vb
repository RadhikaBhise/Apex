Imports Business
Partial Class citylookup
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then


           
            '-- Get Variables
            Me.lbltype.Text = Request.QueryString("type").Trim.ToUpper
            Me.lblState.Text = Request.QueryString("state").Trim
            Me.lblCity.Text = Request.QueryString("city").Trim.ToUpper
            If Not Request.QueryString("cityHeader") Is Nothing Then
                Me.lblCityHeader.Text = Request.QueryString("cityHeader")
                If Me.lblCityHeader.Text.Trim.Length = 0 Then
                    Me.tbresult.Visible = False
                Else
                    Me.tbresult.Visible = True
                    Call initCityDLT()
                End If

            Else

            End If

            Using gi As New GeoInfos
                Dim tmpDS As DataSet = gi.getCityFromCityByStateAndCityHeader(Me.lblState.Text.Trim, Me.lblCity.Text)
                If (Not tmpDS Is Nothing) AndAlso tmpDS.Tables.Count > 0 And tmpDS.Tables(0).Rows.Count > 0 Then
                    Me.grdcity.DataSource = tmpDS
                    Me.grdcity.DataBind()
                End If

            End Using

            'lbltype.Text = lbltype.Text.ToUpper()

            'If strType = "" Or strCity = "" Or strState = "" Then
            '    Response.Write("<script language='javascript'>window.close();</script>")
            'Else
            'lblCity.Text = strCity '& "*" & strState


            initABC()
        End If
        'End If

    End Sub
    Private Sub grdcity_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdcity.ItemDataBound
        Dim strCity As String
        strCity = Me.lblCity.Text.Trim

        Select Case e.Item.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem

                Dim strtype As String = Trim(lbltype.Text)
                Dim city As String
                city = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "name")).Trim
                If city = strCity Then
                    Call AriseJavaScript(1, "City has been verified!")
                    Response.End()
                End If
                Dim myTableCell As TableCell
                myTableCell = e.Item.Cells(0)
                Dim myButton As LinkButton
                myButton = CType(myTableCell.Controls(0), LinkButton)
                myButton.Text = city
                myButton.Attributes.Add("onClick", "city('" & city & "','" & UCase(strtype) & "');")
        End Select

    End Sub
    Private Sub AriseJavaScript(ByVal No As Int16, ByVal ErrorMessage As String)

        Dim strMessage As String
        strMessage = "<script language=""JavaScript"" type=""text/javascript"">"
        strMessage = strMessage & "alert('"
        strMessage = strMessage & ErrorMessage
        strMessage = strMessage & "');"
        If No = 1 Then
            strMessage = strMessage & "window.close();"
        End If

        strMessage = strMessage & "</script>"

        Response.Write(strMessage)
        ClientScript.RegisterStartupScript(GetType(String), "PopUpMessage", strMessage)
    End Sub
    Private Sub initCityDLT()
        If lblCityHeader.Text.ToUpper.Trim.Equals("ALL") Then
            lblCityHeader.Text = ""
        End If

        Using objGeo As New Business.GeoInfos
            Dim tmpDS As DataSet
            tmpDS = objGeo.getCityFromCityByStateAndCityHeader(Me.lblState.Text.Trim, Me.lblCityHeader.Text.Trim)
            If (Not tmpDS Is Nothing) AndAlso tmpDS.Tables.Count > 0 And tmpDS.Tables(0).Rows.Count > 0 Then
                With Me.dltCitis
                    .DataSource = tmpDS
                    .DataBind()
                End With
            Else
                Me.lblErr.Visible = True
                Me.lblErr.Text = "There is no city available!"
            End If
        End Using
    End Sub
    Private Sub initABC()
        Dim ABCAL As New ArrayList
        Dim i As Integer = 0
        For i = 0 To 25
            ABCAL.Add(Convert.ToString(Chr(65 + i)))
        Next
        ABCAL.Add("ALL")

        Dim dt As DataTable
        Dim dr As DataRow

        dt = New DataTable
        dt.Columns.Add(New DataColumn("Header", GetType(String)))

        For i = 0 To 26
            dr = dt.NewRow()
            dr(0) = ABCAL(i).ToString()
            dt.Rows.Add(dr)
        Next

        Me.dltABC.DataSource = New DataView(dt)
        Me.dltABC.DataBind()

        ABCAL = Nothing
    End Sub
    Private Sub dltABC_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dltABC.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myLink As HyperLink
            myLink = CType(e.Item.FindControl("hlinkABC"), HyperLink)

            Dim strCityHeader = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Header")).Trim
            myLink.Text = strCityHeader
            myLink.NavigateUrl = "citylookup.aspx?type=" & Me.lbltype.Text.Trim & "&cityHeader=" & strCityHeader & "&state=" & Me.lblState.Text.Trim & "&city=" & Me.lblCity.Text.Trim
        End If

    End Sub

    Private Sub dltCitis_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dltCitis.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myButton As LinkButton
            myButton = CType(e.Item.FindControl("lbtncity"), LinkButton)

            Dim strCity = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "name")).Trim
            myButton.Text = strCity

            Dim jsFunction As String = "city('" & strCity & "','" & Me.lbltype.Text.Trim & "')"
            'Dim jsFunction As String = "window.alert('Hello')"

            myButton.Attributes.Add("onClick", jsFunction)
        End If

    End Sub
End Class
