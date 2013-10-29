Imports Business

Partial Class lookupCity
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim state, city As String

        If Not Page.Request.QueryString("CityID") Is Nothing Then
            Me.hdnCityID.Value = Page.Request.QueryString("CityID").Trim
        End If
        If Not Page.Request.QueryString("direction") Is Nothing Then
            Me.hdnDirection.Value = Request.QueryString("direction")
        End If

        If Not Page.Request.QueryString("state") Is Nothing Then
            state = Request.QueryString("state").Trim
            Me.lblState.Text = state
        Else
            state = ""
        End If
        If Not Page.Request.QueryString("city") Is Nothing Then
            city = Request.QueryString("city").Trim
        Else
            city = ""
        End If

        Using gi As New GeoInfos
            If state = "NY" Then
                Dim ds As DataSet = gi.getBoroByState
                If Not ds Is Nothing AndAlso ds.Tables.Count > 0 And ds.Tables(0).Rows.Count > 0 Then
                    Me.grdBoro.DataSource = ds
                    Me.grdBoro.DataBind()
                End If
            End If
            Dim tmpDS As DataSet = gi.getCityFromCityByStateAndCityHeader(state, city)

            If (Not tmpDS Is Nothing) AndAlso tmpDS.Tables.Count > 0 Then
                If tmpDS.Tables(0).Rows.Count > 0 Then
                    Me.grdCity.DataSource = tmpDS
                    Me.grdCity.DataBind()
                End If
            End If

        End Using
        initABC()
    End Sub
    '## added by joey   1/10/2008
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
    '## added by joey   1/10/2008
    Private Sub dltABC_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dltABC.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myLink As HyperLink
            myLink = CType(e.Item.FindControl("hlinkABC"), HyperLink)

            Dim strCityHeader = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Header")).Trim
            myLink.Text = strCityHeader
            myLink.NavigateUrl = "lookupcity.aspx?city=" & strCityHeader & "&state=" & Me.lblState.Text.Trim & "&CityID=" & Me.hdnCityID.Value
        End If

    End Sub

    Protected Sub grdCity_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdCity.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim city As String = DataBinder.Eval(e.Item.DataItem, "name").ToString.Trim
            Dim lnkCity As LinkButton = CType(e.Item.FindControl("lnkCity"), LinkButton)
            lnkCity.Attributes.Add("onclick", String.Format("javascript:returnValue('{0}');", city))
        End If
    End Sub

    Protected Sub grdBoro_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdBoro.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim city As String = DataBinder.Eval(e.Item.DataItem, "name").ToString.Trim
            Dim lnkBoro As LinkButton = CType(e.Item.FindControl("lnkBoro"), LinkButton)
            lnkBoro.Attributes.Add("onclick", String.Format("javascript:returnValue('{0}');", city))
        End If
    End Sub
End Class
