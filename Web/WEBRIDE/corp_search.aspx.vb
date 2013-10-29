Imports System.Data
Imports System.Data.SqlClient
Imports Business
Imports System.Web.UI.WebControls

Partial Class corp_search
    Inherits System.Web.UI.Page

    Protected strMeta As String = "<meta http-equiv='refresh' content='15' url='rideinquery.aspx' />"     'HTML of Auto Refresh

#Region "Protected Sub Page Users Parts"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If MySession.UserID Is Nothing OrElse MySession.UserID.Length = 0 Then
            Response.Redirect("corp_login.aspx")
        End If

        If Not Page.IsPostBack Then
            Me.LoadData()
        End If

    End Sub

    Protected Sub Corp_ridesearch1_Corp_RideSearch_Click() Handles Corp_ridesearch1.Corp_RideSearch_Click
        Me.LoadData()
    End Sub

#End Region

#Region "Private Sub Users Parts"

    Private Sub LoadData()
        Using rides As New Rides

            Dim user As New OperatorData
            user.vip_no = MySession.UserID
            user.account_no = MySession.AcctID
            user.sub_account_no = MySession.SubAcctID
            user.company = MySession.Company

            'user.f = Me.Corp_ridesearch1.FromDate
            'user.confirmation_no = Me.Corp_ridesearch1.ConfNo
            'Dim text As String = ""
            'Dim i As Integer = Convert.ToInt32(Me.Corp_ridesearch1.DateType)
            'Select Case i
            '    Case 0
            '        text = ""
            '    Case 1
            '        text = Now().ToString("yyyy-MM-dd")
            '    Case 2
            '        text = Now().ToString("yyyy-MM-dd")
            '    Case 3
            '        text = Now().AddDays(-1).ToString("yyyy-MM-dd")
            '    Case 4
            '        text = Now().AddDays(1).ToString("yyyy-MM-dd")
            '    Case Else
            '        text = Now.AddDays(i - 3).ToString("yyyy-MM-dd")
            'End Select
            ''Dim ds As DataSet = rides.RideInquiry("", user, Me.Ridesearch1.DateType, Me.Ridesearch1.FromDate, Me.Ridesearch1.ToDate)
            'Dim ds As DataSet = rides.RideInquiry("", user, text, Me.Ridesearch1.FromDate, Me.Ridesearch1.ToDate)

            'Me.Rideinquiry1.lnkConfNo = "../orderform.aspx?cno="
            'Me.Rideinquiry1.RideDataSource = ds
            'Me.Rideinquiry1.BindRideData()
        End Using

    End Sub

#End Region

End Class
