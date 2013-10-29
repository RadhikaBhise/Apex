Imports Business
Imports System.Data

Partial Class airport_detail_1
    Inherits System.Web.UI.Page
    Dim strType As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strType = Request.QueryString("type")
        Me.txtType.Text = strType.Trim
        Me.btnSearch.Attributes.Add("onclick", "return batchValidate();")
        Me.form1.Attributes.Add("onload", "disable('" & strType & "');")
    End Sub

    Protected Sub dlstAirport_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlstAirport.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim strCode, strName As String
            strCode = DataBinder.Eval(e.Item.DataItem, "code").ToString
            strName = DataBinder.Eval(e.Item.DataItem, "description").ToString
            CType(e.Item.FindControl("hyAirName"), HyperLink).Text = strName
            CType(e.Item.FindControl("hyAirName"), HyperLink).NavigateUrl = "airport_detail_2.aspx?type=" & strType & "&code=" & strCode & "&name=" & strName

        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim gi As New GeoInfos

        Dim tmpDS As DataSet = gi.getAllAirport(Me.txtAirport_code.Text.Trim, Me.txtAirport_name.Text.Trim, "")

        If (Not tmpDS Is Nothing) AndAlso tmpDS.Tables.Count > 0 AndAlso tmpDS.Tables(0).Rows.Count > 0 Then
            Me.dlstAirport.DataSource = tmpDS
            Me.dlstAirport.DataBind()
            Me.dlstAirport.Visible = True
            Me.lblNone.Visible = False
        Else
            Me.dlstAirport.Visible = False
            Me.lblNone.Visible = True
            Me.lblNone.Text = "Sorry. No matching results found."
        End If

        'gi.Dispose()
        gi = Nothing
        tmpDS.Dispose()
        tmpDS = Nothing
    End Sub

End Class
