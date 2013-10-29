Imports Business

Partial Class lookupLandmark
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim state, landmark As String

            If Not Page.Request.QueryString("CityID") Is Nothing Then
                Me.hdnCityID.Value = Page.Request.QueryString("CityID").Trim
            End If
            If Not Page.Request.QueryString("LandmarkID") Is Nothing Then
                Me.hdnLandmarkID.Value = Request.QueryString("LandmarkID")
            End If
            If Not Page.Request.QueryString("StNameID") Is Nothing Then
                Me.hdnStNameID.Value = Request.QueryString("StNameID")
            End If
            If Not Page.Request.QueryString("StNoID") Is Nothing Then
                Me.hdnStNoID.Value = Request.QueryString("StNoID")
            End If
            If Not Page.Request.QueryString("ZipID") Is Nothing Then
                Me.hdnZipCodeID.Value = Request.QueryString("ZipID")
            End If

            If Not Page.Request.QueryString("state") Is Nothing Then
                state = Request.QueryString("state").Trim
            Else
                state = ""
            End If
            If Not Page.Request.QueryString("landmark") Is Nothing Then
                landmark = Request.QueryString("landmark").Trim
            Else
                landmark = ""
            End If

            'Me.hdnCityID.Value = "ctl00_content_Stop1_txtCity"
            'Me.hdnLandmarkID.Value = "ctl00_content_Stop1_txtLandmark"
            'Me.hdnStNameID.Value = "ctl00_content_Stop1_txtStName"
            'Me.hdnStNoID.Value = "ctl00_content_Stop1_txtStNo"
            'Me.hdnZipCodeID.Value = "ctl00_content_Stop1_txtZip"



            Using gi As New GeoInfos
                Dim tmpDS As DataSet = gi.getLandmarkFromLandmarkByCountyAndCity(state, landmark)

                If (Not tmpDS Is Nothing) AndAlso tmpDS.Tables.Count > 0 And tmpDS.Tables(0).Rows.Count > 0 Then
                    Me.grdLandmark.DataSource = tmpDS
                    Me.grdLandmark.DataBind()
                End If

            End Using
        End If
    End Sub



    Protected Sub grdLandmark_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdLandmark.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim name As String = DataBinder.Eval(e.Item.DataItem, "name").ToString.Trim
            Dim city As String = DataBinder.Eval(e.Item.DataItem, "city").ToString.Trim
            Dim st_name As String = DataBinder.Eval(e.Item.DataItem, "st_name").ToString.Trim
            Dim st_no As String = DataBinder.Eval(e.Item.DataItem, "st_no").ToString.Trim
            Dim zip_code As String = DataBinder.Eval(e.Item.DataItem, "zip_code").ToString.Trim
            Dim lnkLandmark As LinkButton = CType(e.Item.FindControl("lnkLandmark"), LinkButton)
            lnkLandmark.Attributes.Add("onclick", "javascript:returnValue('" & name & "','" & city & "','" & st_name & "','" & st_no & "','" & zip_code & "');")

        End If
    End Sub
End Class
