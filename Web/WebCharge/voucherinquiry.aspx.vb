Imports Business
Imports Business.Common
Imports DataAccess
Imports System.Data
Imports System.Data.SqlClient

Partial Class VoucherInquiry
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If MySession.AcctID Is Nothing OrElse MySession.AcctID.Length = 0 Then
            Response.Redirect("login.aspx")
        End If

        If Not Page.IsPostBack Then
            ' Me.txtDateAfter.Text = "01/01/" & Year(Today())
            'Dim date_FromDate As Date
            'date_FromDate = "01/01/" & Year(Today())
            Me.txtDateAfter.Text = Common.ShowDateTime(Now.AddMonths(-3), Common.DateTimeStyle.DateOnly)

            Me.trSearch.Visible = True
            Me.trData.Visible = False

            Me.btnBack.Visible = False
        End If
    End Sub

#Region " Private Function"

    Private Function ValidateSearchFilter()
        Dim out As Boolean = True

        If Not IsDate(Me.txtDateAfter.Text.Trim) Then
            out = False
            Me.ClientScript.RegisterStartupScript(GetType(String), "Validate", "<script type='text/javascript'>alert('Trip Date On After enter is invalid.');</script>")
        ElseIf Me.GetConfNoString.Trim.Length = 0 Then
            out = False
            Me.ClientScript.RegisterStartupScript(GetType(String), "Validate", "<script type='text/javascript'>alert('Please enter at least 1 voucher number.');</script>")
        End If

        Return out
    End Function

    Private Function GetConfNoString() As String
        Dim out As String
        Dim sb As New StringBuilder()

        If txtcn01.Text.Trim() <> "" Then
            sb.Append("'" & Me.txtcn01.Text.Trim() & "',")
        End If
        If txtcn02.Text.Trim() <> "" Then
            sb.Append("'" & Me.txtcn02.Text.Trim() & "',")
        End If
        If txtcn03.Text.Trim() <> "" Then
            sb.Append("'" & Me.txtcn03.Text.Trim() & "',")
        End If
        If txtcn04.Text.Trim() <> "" Then
            sb.Append("'" & Me.txtcn04.Text.Trim() & "',")
        End If
        If txtcn05.Text.Trim() <> "" Then
            sb.Append("'" & Me.txtcn05.Text.Trim() & "',")
        End If
        If txtcn06.Text.Trim() <> "" Then
            sb.Append("'" & Me.txtcn06.Text.Trim() & "',")
        End If
        If txtcn07.Text.Trim() <> "" Then
            sb.Append("'" & Me.txtcn07.Text.Trim() & "',")
        End If
        If txtcn08.Text.Trim() <> "" Then
            sb.Append("'" & Me.txtcn08.Text.Trim() & "',")
        End If
        If txtcn09.Text.Trim() <> "" Then
            sb.Append("'" & Me.txtcn09.Text.Trim() & "',")
        End If
        If txtcn10.Text.Trim() <> "" Then
            sb.Append("'" & Me.txtcn10.Text.Trim() & "',")
        End If
        If txtcn11.Text.Trim() <> "" Then
            sb.Append("'" & Me.txtcn11.Text.Trim() & "',")
        End If
        If txtcn12.Text.Trim() <> "" Then
            sb.Append("'" & Me.txtcn12.Text.Trim() & "',")
        End If
        If txtcn13.Text.Trim() <> "" Then
            sb.Append("'" & Me.txtcn13.Text.Trim() & "',")
        End If
        If txtcn14.Text.Trim() <> "" Then
            sb.Append("'" & Me.txtcn14.Text.Trim() & "',")
        End If
        If txtcn15.Text.Trim() <> "" Then
            sb.Append("'" & Me.txtcn15.Text.Trim() & "',")
        End If
        If sb.ToString.EndsWith(",") Then
            out = sb.ToString.Substring(0, sb.ToString.Length - 1)
        Else
            out = sb.ToString
        End If


        Return out

    End Function

    Private Sub LoadData()
        Using rpt As New Report
            Dim ConfNoString = Me.GetConfNoString
            Dim ds As DataSet = rpt.GetVoucherNo(Me.txtDateAfter.Text.Trim, MySession.AcctID, MySession.SubAcctID, MySession.AcctID, "N", ConfNoString)

            If Not ds Is Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                Me.grdData.DataSource = ds.Tables(0).DefaultView
                Me.grdData.DataBind()

                Me.trData.Visible = True
                Me.trSearch.Visible = False

                Me.btnBack.Visible = True
            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Startup", "<script type='text/javascript'>alert('No information found!');</script>")
            End If
        End Using
    End Sub

#End Region

#Region " Page Events "

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSubmit.Click
        If Me.txtcn01.Text.Trim.ToLower = "all" OrElse Me.ValidateSearchFilter Then
            If Me.txtcn01.Text.Trim.ToLower = "all" Then Me.txtcn01.Text = ""
            Me.LoadData()
        End If
    End Sub

    'Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnReset.Click
    '    txtcn01.Text = ""
    '    txtcn02.Text = ""
    '    txtcn03.Text = ""
    '    txtcn04.Text = ""
    '    txtcn05.Text = ""
    '    txtcn06.Text = ""
    '    txtcn07.Text = ""
    '    txtcn08.Text = ""
    '    txtcn09.Text = ""
    '    txtcn10.Text = ""
    '    txtcn11.Text = ""
    '    txtcn12.Text = ""
    '    txtcn13.Text = ""
    '    txtcn14.Text = ""
    '    txtcn15.Text = ""
    '    'Dim date_FromDate As Date
    '    'date_FromDate = "01/01/" & Year(Today())
    '    Me.txtDateAfter.Text = Common.ShowDateTime(date_FromDate, Common.DateTimeStyle.DateOnly)
    'End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("voucherinquiry.aspx")
    End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExcel.Click
        Me.LoadData()
        Common.GenerateCSVFile(Me, Me.grdData, "VoucherInquiry.csv")
    End Sub

#End Region

End Class
