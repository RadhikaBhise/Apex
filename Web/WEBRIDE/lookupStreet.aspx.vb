Imports Business
Imports System.Data

Partial Class lookupStreet
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim StName As String = ""
            Dim County As String = ""

            If Not Page.Request.QueryString("county") Is Nothing Then
                County = Request.QueryString("county")
            End If
            If Not Page.Request.QueryString("stname") Is Nothing Then
                StName = Request.QueryString("stname")
            End If
            If Not Page.Request.QueryString("direction") Is Nothing Then
                Me.hdnDirection.Value = Request.QueryString("direction")
            End If

            If Not Page.Request.QueryString("stnameid") Is Nothing Then
                Me.hdnStNameID.Value = Request.QueryString("stnameid")
            Else
                Me.hdnStNameID.Value = ""
            End If

            Using address As New Address()
                Dim Mode As Int16
                Dim ds As DataSet = address.GetClosetStreet(County, StName, Mode)

                If Not ds Is Nothing AndAlso ds.Tables.Count > 0 Then
                    Me.grdStreet.DataSource = ds.Tables(0).DefaultView
                    Me.grdStreet.DataBind()
                End If

                If Mode = 2 Then
                    Me.lblMsg.Text = String.Format("There were no matches for <a style='color:white'>{0}</a>" & _
                                      " , but the following matches are close. Did you mean to select one of these?", StName)
                Else
                    Me.lblMsg.Text = String.Format("Your search for <a style='color:white'>{0}</a> has returned the following results.", StName)
                End If
            End Using
        End If
    End Sub

    Protected Sub grdStreet_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdStreet.ItemDataBound
        Select Case e.Item.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                Dim StName As String = Convert.ToString(e.Item.DataItem("st_name")).Trim
                Dim lnk As LinkButton = CType(e.Item.Cells(0).Controls(0), LinkButton)

                lnk.Text = StName
                lnk.Attributes.Add("onclick", String.Format("javascript:returnValue('{0}');", StName))
        End Select
    End Sub

End Class
