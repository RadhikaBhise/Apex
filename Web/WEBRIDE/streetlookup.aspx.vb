Imports Business

Partial Class streetlookup
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then

            Dim strStName, strType, strState, strCity, strStNo As String

            '-- Get Variables
            strType = Request.QueryString("type").Trim
            strStName = Request.QueryString("stname").Trim
            strState = Request.QueryString("state").Trim
            strCity = Request.QueryString("city").Trim
            strStNo = Request.QueryString("stno").Trim
            lbltype.Text = strType.ToUpper()


            If strType = "" Or strStName = "" Or strState = "" Then
                Response.Write("<script language='javascript'>window.close();</script>")
            Else
                lblStName.Text = strStName '& "*" & strState

                Using gi As New GeoInfos
                    Dim tmpDS As DataSet = gi.GetStreetNameForStreetLookUp(strState, strCity, strStName, strStNo)
                    If (Not tmpDS Is Nothing) AndAlso tmpDS.Tables.Count > 0 AndAlso tmpDS.Tables(0).Rows.Count > 0 Then
                        Me.grdStreet.DataSource = tmpDS
                        Me.grdStreet.DataBind()
                    End If

                End Using

            End If
        End If

    End Sub



    Private Sub grdStreet_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdStreet.ItemDataBound

        Select Case e.Item.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                Dim county As String
                Dim strtype As String = Trim(lbltype.Text)
                Dim st_name As String
                Dim city As String
                Dim zip_code As String
                Dim strX_st As String
                county = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "county")).Trim
                st_name = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "st_name")).Trim
                'city = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "city")).Trim
                zip_code = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "zip_code")).Trim
                If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "x_st")) Then

                    strX_st = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "x_st")).Trim()
                Else
                    strX_st = ""
                End If


                Dim myTableCell As TableCell
                myTableCell = e.Item.Cells(4)
                Dim myButton As LinkButton
                myButton = CType(myTableCell.Controls(0), LinkButton)
                myButton.Text = st_name
                myButton.Attributes.Add("onClick", "street_name('" & st_name & "','" & UCase(strtype) & "','" & city & "','" & zip_code & "','" & strX_st & "','" & county & "');")

        End Select

    End Sub

End Class
