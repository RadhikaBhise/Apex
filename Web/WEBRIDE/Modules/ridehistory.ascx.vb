Imports Business.Common
Imports Business.Security
Imports Business
Imports system.Data

Partial Class Modules_ridehistory
    Inherits System.Web.UI.UserControl

    'Public Event RideSort_Click()

    Private m_RideDataSet As DataSet
    Private m_IsEffiliate As Boolean

#Region "Public WriteOnly Property"

    Public WriteOnly Property RideDataSource() As DataSet
        Set(ByVal value As DataSet)
            Me.m_RideDataSet = value
            ViewState("RideDataSet") = Me.m_RideDataSet
        End Set
    End Property

    Public WriteOnly Property IsEffiliate() As Boolean
        Set(ByVal value As Boolean)
            Me.m_IsEffiliate = value
        End Set
    End Property

#End Region

#Region " Data Grid Events "

    Protected Sub dgRide_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgRide.ItemCommand

        '## 12/12/2007  changed by yang
        Select Case e.CommandName
            Case "sort"
                If Me.GetDataSet Then
                    Dim dv As DataView = Me.m_RideDataSet.Tables(0).DefaultView
                    Dim SortFields As String = Convert.ToString(e.CommandArgument).Trim

                    Select Case SortFields
                        Case "pu_landmark"
                            If Me.hdnSort.Value = "pu_landmark,pu_st_no,pu_st_name,pu_city" Then
                                Me.hdnSort.Value = "pu_landmark desc,pu_st_no desc,pu_st_name desc,pu_city desc"
                            Else
                                Me.hdnSort.Value = "pu_landmark,pu_st_no,pu_st_name,pu_city"
                            End If
                        Case "dest_landmark"
                            If Me.hdnSort.Value = "dest_landmark,dest_st_no,dest_st_name,dest_city" Then
                                Me.hdnSort.Value = "dest_landmark desc,dest_st_no desc,dest_st_name desc,dest_city desc"
                            Else
                                Me.hdnSort.Value = "dest_landmark,dest_st_no,dest_st_name,dest_city"
                            End If
                        Case Else
                            If Me.hdnSort.Value = SortFields Then
                                Me.hdnSort.Value = SortFields & " desc"
                            Else
                                Me.hdnSort.Value = SortFields
                            End If
                    End Select

                    If Me.DataSetHasFields(Me.hdnSort.Value.Replace(" desc", "")) Then
                        dv.Sort = Me.hdnSort.Value
                        Me.dgRide.DataSource = dv
                        Me.dgRide.DataBind()
                    End If
                End If
        End Select
    End Sub

    Private Sub dgRides_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgRide.ItemDataBound

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim strConfNo As String
            Dim objRide As New Rides

            Dim objItem As Object = DataBinder.Eval(e.Item.DataItem, "status_flag")
            strConfNo = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "confirmation_no"))

            '--Status
            Select Case objItem
                Case "F"
                    CType(e.Item.FindControl("lblstatus"), Label).Text = "CANCELLED"
                Case "K"
                    CType(e.Item.FindControl("lblstatus"), Label).Text = ("CONFIRMED")
            End Select

            '--datetime
            If Me.m_IsEffiliate = True Then
                Dim objFormat As New FormatInformation
                If Not Check_DBNULL(DataBinder.Eval(e.Item.DataItem, "dsp_date_time")) Is Nothing Then
                    CType(e.Item.FindControl("lblDisp"), Label).Text = objFormat.formatDate(Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "dsp_date_time")))
                End If
                If Not Check_DBNULL(DataBinder.Eval(e.Item.DataItem, "os_date_time")) Is Nothing Then
                    CType(e.Item.FindControl("lblos"), Label).Text = objFormat.formatDate(Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "os_date_time")))
                End If
                If Not Check_DBNULL(DataBinder.Eval(e.Item.DataItem, "ld_date_time")) Is Nothing Then
                    CType(e.Item.FindControl("lblLoad"), Label).Text = objFormat.formatDate(Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "ld_date_time")))
                End If
                If Not Check_DBNULL(DataBinder.Eval(e.Item.DataItem, "ul_date_time")) Is Nothing Then
                    CType(e.Item.FindControl("lblUnload"), Label).Text = objFormat.formatDate(Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "ul_date_time")))
                End If
            End If

            CType(e.Item.FindControl("lblName"), Label).Text = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "fname")).Trim & ", " & Convert.ToString(DataBinder.Eval(e.Item.DataItem, "lname")).Trim
            CType(e.Item.FindControl("lblCdate"), Label).Text = ConvertDateTimeTOString(DataBinder.Eval(e.Item.DataItem, "display_date_time")) ' Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "display_date_time"))
            CType(e.Item.FindControl("lblReq_date_time"), Label).Text = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "req_date_time"))

            '--Confirmation
            objItem = DataBinder.Eval(e.Item.DataItem, "share")
            Dim strVoucherNo As String
            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "voucher_no")) Then
                strVoucherNo = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "voucher_no"))
            Else
                strVoucherNo = ""
            End If

            If Not objItem Is Nothing Then
                If Convert.ToString(objItem).Trim().ToUpper = "Y" Then
                    CType(e.Item.FindControl("hlnkConf"), HyperLink).Text = strConfNo
                    '        CType(e.Item.FindControl("hy1"), HyperLink).NavigateUrl = "voucherSRConfirm02.aspx?vno=" & strVoucherNo & "&revive=ridehist"
                Else
                    CType(e.Item.FindControl("hlnkConf"), HyperLink).Text = Right(strConfNo, 4)
                    CType(e.Item.FindControl("hlnkConf"), HyperLink).NavigateUrl = "../daytimevoucherconfirm2.aspx?cno=" & strConfNo & "&revive=ridehist"

                End If
            End If

            '--Pick Up Point
            Dim st_no, st_name, city, county As String
            objItem = DataBinder.Eval(e.Item.DataItem, "pu_landmark")
            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "pu_st_no")) Then
                st_no = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_st_no")).Trim
            Else
                st_no = ""
            End If
            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "pu_st_name")) Then
                st_name = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_st_name")).Trim
            Else
                st_name = ""
            End If
            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "pu_city")) Then
                city = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_city")).Trim
            Else
                city = ""
            End If
            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "pu_county")) Then
                county = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "pu_county")).Trim
            Else
                county = ""
            End If

            '## add by joey 5/7/2008
            Dim Airport, Airline, Flight, PuPoint As String
            Airport = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "airport_name")).Trim
            Airline = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "airport_airline")).Trim
            Flight = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "airport_flight")).Trim
            PuPoint = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "airport_pu_point")).Trim

            '##modified by joey 1/08/2008
            'Dim sec As New Security
            If IsAirport(county) Then
                CType(e.Item.FindControl("lblPuAddress"), Label).Text = ShowAirportAddress(Airport, Airline, Flight, PuPoint)
            Else
                CType(e.Item.FindControl("lblPuAddress"), Label).Text = ShowAddress(st_no, st_name, city, county, "", Convert.ToString(objItem))
            End If

            '--Destination Point
            objItem = DataBinder.Eval(e.Item.DataItem, "dest_landmark")
            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "dest_st_no")) Then
                st_no = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_st_no")).Trim
            Else
                st_no = ""
            End If
            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "dest_st_name")) Then
                st_name = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_st_name")).Trim
            Else
                st_name = ""
            End If
            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "dest_city")) Then
                city = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_city")).Trim
            Else
                city = ""
            End If
            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "dest_county")) Then
                county = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_county")).Trim
            Else
                county = ""
            End If

            '## add by joey 5/7/2008
            Airport = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_airport_name")).Trim
            Airline = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_airport_airline")).Trim
            Flight = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "dest_airport_flight")).Trim

            '##modified by joey 5/7/2008
            If IsAirport(county) Then 'If Not objItem Is Nothing AndAlso Convert.ToString(objItem).Trim.Length > 0 Then     '--modify by daniel for the dest display. 07/05/2008
                CType(e.Item.FindControl("lblDestAddress"), Label).Text = ShowAirportAddress(Airport, Airline, Flight, "")
            Else
                CType(e.Item.FindControl("lblDestAddress"), Label).Text = ShowAddress(st_no, st_name, city, county, "", Convert.ToString(objItem))
            End If

            'price_est
            Dim strPrice As String = DataBinder.Eval(e.Item.DataItem, "price_est")
            Dim lblPrice As Label = CType(e.Item.FindControl("lblPrice"), Label)
            If strPrice.Length < 0 Then
                strPrice = "n/a"
            Else
                If IsNumeric(strPrice) = True Then
                    strPrice = FormatCurrency(strPrice, 2)
                Else
                    strPrice = "$" & strPrice
                End If
            End If

            lblPrice.Text = strPrice
        End If


    End Sub

    Private Sub dgRides_ItemCreated(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgRide.ItemCreated

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim objFlag As Object = DataBinder.Eval(e.Item.DataItem, "status_flag")
            If Not objFlag Is Nothing Then
                Dim strFlag As String = Convert.ToString(objFlag)
                If strFlag.ToUpper = "F" Then
                    e.Item.ForeColor = Drawing.Color.Blue
                Else
                    e.Item.ForeColor = Drawing.Color.Black
                End If
            End If
        End If

    End Sub

    Private Sub dgRides_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgRide.PageIndexChanged
        If Me.GetDataSet() Then
            Dim dv As DataView = Me.m_RideDataSet.Tables(0).DefaultView

            Me.dgRide.CurrentPageIndex = e.NewPageIndex
            If Me.DataSetHasFields(Me.hdnSort.Value.Replace(" desc", "")) Then
                dv.Sort = Me.hdnSort.Value
            End If

            Me.dgRide.DataSource = dv
            Me.dgRide.DataBind()
        End If
    End Sub

    Private Function GetDataSet() As Boolean
        Dim out As Boolean = False

        If Not ViewState("RideDataSet") Is Nothing AndAlso TypeOf (ViewState("RideDataSet")) Is DataSet Then
            Me.m_RideDataSet = CType(ViewState("RideDataSet"), DataSet)

            If Me.m_RideDataSet.Tables.Count > 0 Then
                out = True
            End If
        End If

        Return out
    End Function

    Private Function DataSetHasFields(ByVal fields As String) As Boolean
        Dim out As Boolean = False

        If fields.Trim.Length > 0 AndAlso Me.GetDataSet Then
            out = True

            Dim arrFields() As String = fields.Split(Char.Parse(","))

            For Each field As String In arrFields
                If Me.m_RideDataSet.Tables(0).Columns.Contains(field) = False Then
                    out = False
                    Exit For
                End If
            Next
        End If

        Return out
    End Function

#End Region

#Region "Private Function User Parts"

    Public Sub BindRideData()
        If Not Me.m_RideDataSet Is Nothing AndAlso Me.m_RideDataSet.Tables.Count > 0 Then
            'Me.lblCountRide.Text = Me.m_RideDataSet.Tables(0).Rows.Count
            If Not Me.ViewState("sort") Is Nothing Then
                If Me.ViewState("sort").ToString.Length > 0 Then
                    Me.m_RideDataSet.Tables(0).DefaultView.Sort = Me.ViewState("sort")
                End If
            End If
            Me.dgRide.DataSource = Me.m_RideDataSet.Tables(0).DefaultView
            '## add by joey 3/13/2008
            If Me.dgRide.CurrentPageIndex + 1 > Math.Ceiling(Me.m_RideDataSet.Tables(0).Rows.Count / Me.dgRide.PageSize) Then
                Me.dgRide.CurrentPageIndex = 0
            End If

            Try
                Me.dgRide.DataBind()
            Catch
            End Try

            Me.lblCountRide.Text = Me.m_RideDataSet.Tables(0).Rows.Count.ToString
        End If
    End Sub

    Private Function ConvertDateTimeTOString(ByVal value As Object) As String
        If IsDBNull(value) Then
            Return "N/A"
        Else
            Return Convert.ToString(Convert.ToDateTime(value)).Trim
        End If
    End Function

    Private Function Check_DBNULL(ByVal Value As Object) As String

        If IsDBNull(Value) = True Then
            Return Nothing
        Else
            Return Convert.ToString(Value).Trim()
        End If

    End Function

    '## add by joey 4/28/2008
    Private Function IsAirport(ByVal county As String) As Boolean
        Dim out As Boolean
        Using objAddress As New Address
            out = objAddress.is_airport(county)
        End Using
        Return out
    End Function

#End Region

End Class
