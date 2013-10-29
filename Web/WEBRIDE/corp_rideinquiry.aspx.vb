Imports Business

Partial Class corp_rideinquiry
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.ServerClick
        Using corp As New Corporate

            Dim SearchBy As String = "ridedate"
            If Me.rdPassengerName.Checked Then
                SearchBy = "name"
            ElseIf Me.rdCompReq.Checked Then
                SearchBy = "comp"
            End If

            corp.AcctID = MySession.AcctID
            'Dim ds As DataSet = corp.GetRideInquiry(Me.chkShowCancelledRides.Checked, SearchBy, RideSearch.FromDate, RideSearch.ToDate, RideSearch.FName, RideSearch.LName, RideSearch.Comp_ID, RideSearch.Comp_Value)
            Dim ds As DataSet = corp.GetRideInquiry(Me.chkShowCancelledRides.Checked, SearchBy, _
                              Me.txtFromDate.Text.Trim, Me.txtToDate.Text.Trim, Me.txtFirstName.Text.Trim, _
                              Me.txtLastName.Text.Trim, Me.ddlCompReq.SelectedValue.Trim, Me.txtCompReqValue.Text.Trim)

            Me.Rideinquiry1.RideDataSource = ds
            Me.Rideinquiry1.BindRideData()
        End Using
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.BindCompanyRequirement()

            'Me.txtFDate.Text = Common.ShowDateTime(Now, Common.DateTimeStyle.DateOnly)
            'Me.txtToDate.Text = Common.ShowDateTime(Now.AddDays(1), Common.DateTimeStyle.DateOnly)

            Me.txtFromDate.Text = Common.ShowDateTime(Now, Common.DateTimeStyle.DateOnly)
            Me.txtToDate.Text = Common.ShowDateTime(Now.AddDays(7), Common.DateTimeStyle.DateOnly)

            Me.btnSubmit_ServerClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub BindCompanyRequirement()
        Using corp As New Corporate

            corp.AcctID = MySession.AcctID
            corp.SubAcctID = MySession.SubAcctID

            Dim ds As DataSet = corp.get_comp_req(corp.AcctID, corp.SubAcctID)
            If Not ds Is Nothing AndAlso ds.Tables.Count > 0 Then
                ddlCompReq.DataSource = ds.Tables(0).DefaultView
                ddlCompReq.DataTextField = "req_desc"
                ddlCompReq.DataValueField = "comp_id"
                ddlCompReq.DataBind()
            End If

            Dim HasCompReq As Boolean = corp.HasCompanyRequirement()
            'If HasCompReq Then
            '    Me.RideSearch.trCompReq.Visible = True
            'Else
            '    Me.RideSearch.trCompReq.Visible = False
            'End If
            If HasCompReq Then
                Me.trCompReq.Visible = True
            Else
                Me.trCompReq.Visible = False
            End If
        End Using
    End Sub

    Protected Sub Rideinquiry1_RideRefresh_Click() Handles Rideinquiry1.RideRefresh_Click
        Me.btnSubmit_ServerClick(Nothing, Nothing)
    End Sub

    'add by joey    3/14/2008
    Protected Sub ddlRefresh_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlRefresh.SelectedIndexChanged
        Select Case Me.ddlRefresh.SelectedValue
            Case "0"
                Me.Timer1.Enabled = False
            Case Else
                Me.Timer1.Enabled = True
                Me.Timer1.Interval = Val(Me.ddlRefresh.SelectedValue) * 1000
        End Select

    End Sub

    Protected Sub FreshTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Using corp As New Corporate

            Dim SearchBy As String = "ridedate"
            If Me.rdPassengerName.Checked Then
                SearchBy = "name"
            ElseIf Me.rdCompReq.Checked Then
                SearchBy = "comp"
            End If

            corp.AcctID = MySession.AcctID
            'Dim ds As DataSet = corp.GetRideInquiry(Me.chkShowCancelledRides.Checked, SearchBy, RideSearch.FromDate, RideSearch.ToDate, RideSearch.FName, RideSearch.LName, RideSearch.Comp_ID, RideSearch.Comp_Value)
            Dim ds As DataSet = corp.GetRideInquiry(Me.chkShowCancelledRides.Checked, SearchBy, _
                              Me.txtFromDate.Text.Trim, Me.txtToDate.Text.Trim, Me.txtFirstName.Text.Trim, _
                              Me.txtLastName.Text.Trim, Me.ddlCompReq.SelectedValue.Trim, Me.txtCompReqValue.Text.Trim)

            Me.Rideinquiry1.RideDataSource = ds
            Me.Rideinquiry1.BindRideData()
        End Using
    End Sub

End Class
