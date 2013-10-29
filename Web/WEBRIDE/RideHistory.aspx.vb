Imports Business
Imports System.Drawing

Partial Class webride_RideHistory
    Inherits System.Web.UI.Page

#Region "Protected Sub Page Users Parts"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.LoadData()
        End If
    End Sub

    Protected Sub Ridesearch1_RideSearch_Click() Handles Ridesearch1.RideSearch_Click
        Me.LoadData()
    End Sub

    'Protected Sub Ridehistory1_RideSort_Click() Handles Ridehistory1.RideSort_Click
    '    Me.LoadData()
    'End Sub

#End Region

#Region "Private Sub Users Parts"

    Private Sub LoadData()

        Using rides As New Rides

            Dim user As New OperatorData
            user.vip_no = MySession.UserID
            user.account_no = MySession.AcctID
            user.sub_account_no = MySession.SubAcctID
            user.company = MySession.Company

            user.lname = Me.Ridesearch1.PassengerLastName
            user.confirmation_no = Me.Ridesearch1.ConfNo
            Dim text As String = ""
            Dim i As Integer = Convert.ToInt32(Me.Ridesearch1.DateType)
            Select Case i
                Case 0
                    text = ""
                Case 1
                    text = Now().ToString("yyyy-MM-dd")
                Case 2
                    text = Now().ToString("yyyy-MM-dd")
                Case 3
                    text = Now().AddDays(-1).ToString("yyyy-MM-dd")
                Case 4
                    text = Now().AddDays(1).ToString("yyyy-MM-dd")
                Case Else
                    text = Now.AddDays(i - 3).ToString("yyyy-MM-dd")
            End Select
            'Dim ds As DataSet = rides.GetHistoryRides("", user, Me.Ridesearch1.DateType, Me.Ridesearch1.FromDate, Me.Ridesearch1.ToDate)
            Dim ds As DataSet = rides.GetHistoryRides("", user, text, Me.Ridesearch1.FromDate, Me.Ridesearch1.ToDate)

            'Me.Ridehistory1.lnkConfNo = "../orderform.aspx?cno="
            Me.Ridehistory1.RideDataSource = ds
            Me.Ridehistory1.BindRideData()
        End Using

    End Sub

#End Region

End Class