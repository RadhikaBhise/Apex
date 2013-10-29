Imports Business
Imports System.Data

Partial Class SearchAirport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim strheader As String, strtype As String
            strheader = Request.QueryString("airport")
            strtype = Request.QueryString("type")
            Me.hidtype.Value = strtype.Trim

            If Not strheader Is Nothing Then
                If strheader.Trim <> "" Then
                    Me.SearchAirport(strheader.Trim)
                End If
            End If
            Call Me.initABC()

        End If

    End Sub

    Protected Sub dltABC_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dltABC.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myLink As HyperLink
            myLink = CType(e.Item.FindControl("hlinkABC"), HyperLink)

            Dim strCityHeader As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "airport")).Trim
            myLink.Text = strCityHeader
            'myLink.NavigateUrl = "landmark.aspx?type=" & Me.lbltype.Text.Trim & "&Landmarkheader=" & strCityHeader & "&state=" & Me.lblState.Text.Trim & "&city=" & Me.lblcity.Text.Trim
            myLink.NavigateUrl = "SearchAirport.aspx?airport=" & strCityHeader & "&type=" & Me.hidtype.Value.Trim
        End If
    End Sub

    Public Sub SearchAirport(ByVal strheader As String)
        Dim objUsers As New Price
        Dim objdataset As DataSet
        objdataset = objUsers.SearchAirport_ByName(strheader)
        If Not objdataset Is Nothing Then
            ddlairportResult.DataSource = objdataset
            ddlairportResult.DataBind()
        End If
        objUsers.Dispose()
        objUsers = Nothing

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
        dt.Columns.Add(New DataColumn("airport", GetType(String)))

        For i = 0 To 26
            dr = dt.NewRow()
            dr(0) = ABCAL(i).ToString()
            dt.Rows.Add(dr)
        Next

        Me.dltABC.DataSource = New DataView(dt)
        Me.dltABC.DataBind()

        ABCAL = Nothing
    End Sub

    Protected Sub ddlairportResult_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles ddlairportResult.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myButton As LinkButton
            myButton = CType(e.Item.FindControl("lbtncity"), LinkButton)
            Dim myShow As LinkButton
            myShow = CType(e.Item.FindControl("lbtname"), LinkButton)

            Dim strCity As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "description")).Trim
            myButton.Text = strCity

            Dim strname As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "name")).Trim
            myShow.Text = strname

            Dim jsFunction As String = "javascript:airportlookupname('" & Me.hidtype.Value.Trim & "','" & strname & "');return false;"
            'Dim jsFunction As String = "window.alert('Hello')"
            'myButton.Attributes.Add("onClick", "window.alert('Hello');")
            myButton.Attributes.Add("onClick", jsFunction)
        End If
    End Sub

End Class
