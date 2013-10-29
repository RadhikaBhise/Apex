Imports System.Data
Imports System.Data.SqlClient
Imports Business
Imports System.Web.UI.WebControls

Partial Class group_search
    Inherits System.Web.UI.Page

#Region "Protected Sub Page Users Parts"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If MySession.UserID Is Nothing OrElse MySession.UserID.Length = 0 Then
            Response.Redirect("group_login.aspx")
        End If

        If Not Page.IsPostBack Then
            Me.LoadData()
        End If

    End Sub

    Protected Sub Group_ridesearch_Click() Handles Group_ridesearch1.Group_RideSearch_Click
        Me.LoadData()
    End Sub

#End Region

#Region "Private Sub Users Parts"

    Private Sub LoadData()
        Using rides As New Group

            Dim user As New OperatorData
            user.vip_no = MySession.UserID
            user.account_no = MySession.AcctID
            user.sub_account_no = MySession.SubAcctID
            user.company = MySession.Company
            user.Search_Value = Me.Group_ridesearch1.Search_Value

            '## 1/10/2008   Disabled by yang
            'Dim ds As DataSet = rides.GetOperatorRidesQuery(user, Me.Group_ridesearch1.FromDate, Me.Group_ridesearch1.ToDate, Me.Group_ridesearch1.Comp_ID, Me.Group_ridesearch1.Comp_Value)
           
            'Me.Group_ridehistory1.lnkConfNo = "../group_orderform.aspx?cno="
            'Me.Group_ridehistory1.RideDataSource = ds
            'Me.Group_ridehistory1.BindRideData()
        End Using

    End Sub

#End Region

End Class
