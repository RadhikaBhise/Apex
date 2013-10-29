
Partial Class Modules_ridesearch
    Inherits System.Web.UI.UserControl

    Public Event RideSearch_Click()
    Public ReadOnly Property PassengerLastName() As String
        Get
            Return Me.txtLname.Text.Trim()
        End Get
    End Property
    Public ReadOnly Property ConfNo() As String
        Get
            Return Me.txtConf_no.Text.Trim
        End Get
    End Property
    Public ReadOnly Property FromDate() As String
        Get
            Return Me.txtFdate.Text.Trim
        End Get
    End Property
    Public ReadOnly Property ToDate() As String
        Get
            Return Me.txtTdate.Text.Trim
        End Get
    End Property
    Public ReadOnly Property DateType() As String
        Get
            Return Me.ddlDate.SelectedValue.Trim
        End Get
    End Property

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Not Page.IsPostBack Then
            Me.LoadDateType()
        End If
    End Sub

    Private Sub LoadDateType()
        Me.ddlDate.Items.Add(New ListItem("-", "0"))
        Me.ddlDate.Items.Add(New ListItem("+/- 4 hours", "1"))
        Me.ddlDate.Items.Add(New ListItem("Today", "2"))
        Me.ddlDate.Items.Add(New ListItem("Yesterday", "3"))
        Me.ddlDate.Items.Add(New ListItem("Tomorrow", "4"))

        For i As Integer = 0 To 14
            Dim text As String = Now.AddDays(i + 2).ToString("yyyy-MM-dd") & " " & WeekdayName(Weekday(Now.AddDays(i + 2)), True)
            Me.ddlDate.Items.Add(New ListItem(text, Convert.ToString(i + 5)))
        Next
    End Sub

    Protected Sub btnlname_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnlname.ServerClick
        RaiseEvent RideSearch_Click()
    End Sub

    Protected Sub btnClear_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClear.ServerClick
        Me.txtLname.Text = ""
        Me.txtAuLname.Text = ""
        Me.txtComp_id_6.Text = ""
        Me.txtConf_no.Text = ""
        Me.txtCancel.Text = ""
        Me.ddlDate.SelectedIndex = "0"
        Me.txtFdate.Text = ""
        Me.txtTdate.Text = ""
    End Sub

    Protected Sub btnaulname_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnaulname.ServerClick
        RaiseEvent RideSearch_Click()
    End Sub

    Protected Sub btncomp_id_6_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btncomp_id_6.ServerClick
        RaiseEvent RideSearch_Click()
    End Sub

    Protected Sub btnconfirmation_no_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnconfirmation_no.ServerClick
        RaiseEvent RideSearch_Click()
    End Sub

    Protected Sub btnCancel_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancel.ServerClick
        RaiseEvent RideSearch_Click()
    End Sub

    Protected Sub btnDate_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDate.ServerClick
        RaiseEvent RideSearch_Click()
    End Sub

    Protected Sub ddlDate_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDate.SelectedIndexChanged
        RaiseEvent RideSearch_Click()
    End Sub

End Class
