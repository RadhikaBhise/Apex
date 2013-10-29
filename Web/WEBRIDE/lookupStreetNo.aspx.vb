Imports Business
Imports System.Data

Partial Class lookupStreetNo
    Inherits System.Web.UI.Page

    Protected Sub dgStrNo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgStrNo.Load
        If Not Page.IsPostBack Then
            Dim County As String = ""
            Dim StName As String = ""

            If Not Request.QueryString("county") Is Nothing Then
                County = Request.QueryString("county")
            End If
            If Not Request.QueryString("stname") Is Nothing Then
                StName = Request.QueryString("stname")
            End If
            If Not Request.QueryString("direction") Is Nothing Then
                Me.hdnDirection.Value = Request.QueryString("direction")
            End If
            If Not Request.QueryString("stNoID") Is Nothing Then
                Me.hdnStNoID.Value = Request.QueryString("stNoID")
            End If

            Using geo As New GeoInfos
                Dim ds As DataSet = geo.GetStreetNoForStreetNoLookUp(County, StName)
                If Not ds Is Nothing AndAlso ds.Tables.Count > 0 Then
                    Me.dgStrNo.DataSource = ds.Tables(0).DefaultView
                    Me.dgStrNo.DataBind()
                End If
            End Using
        End If
    End Sub

    Private Sub dgStrNo_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgStrNo.ItemDataBound
        Select Case e.Item.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                Dim StNo As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "to_st_no")).Trim()
                Dim myButton As LinkButton = CType(e.Item.Cells(0).Controls(0), LinkButton)

                myButton.Attributes.Add("onclick", String.Format("javascript:returnValue('{0}');", StNo))
        End Select
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
