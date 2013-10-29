Imports Business
Imports DataAccess
Imports System.Data
Imports System.Data.SqlClient

Partial Class ConfirmInquiry
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If MySession.AcctID Is Nothing OrElse MySession.AcctID.Length = 0 Then
            Response.Redirect("login.aspx")
        End If

        If Not Page.IsPostBack Then
            Me.txtDateAfter.Text = "01/01/" & Year(Today())

            Me.trSearch.Visible = True
            Me.trData.Visible = False

            Me.btnBack.Visible = False
            'Dim msg As String
            'msg = ""
            'msg = Trim(Request.QueryString("msg"))

            'If msg = "errorcode" Then
            '    Response.Write("<script language='javascript'>alert('Invalid Voucher No! Please Try Again...');</script>")
            'Else
            'End If
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
            Dim ds As DataSet = rpt.GetConfirmationNo(Me.txtDateAfter.Text.Trim, MySession.AcctID, MySession.SubAcctID, MySession.AcctID, "N", ConfNoString)

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

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        'If Me.ValidateSearchFilter Then
        Me.LoadData()
        'End If

        ' Dim strGroupFlag As String
        ' Dim strAcct_ID As String
        ' Dim strSubacctid As String
        ' Dim strPudate As String
        ' Dim strAcct_list As String
        ' Dim strConfirm As String
        ' Dim objDataset As New DataSet
        ' Dim objDatatable As New DataTable
        ' Dim objConfirm As New Report

        ' strPudate = Me.txtDateAfter.Text.Trim()

        ' If Convert.ToString(Session("group_login_flag")).Trim() = "Y" Then
        '     strGroupFlag = "Y"
        '     strAcct_list = Convert.ToString(Session("account_list")).Trim()
        ' Else
        '     strGroupFlag = "N"
        '     strAcct_list = ""
        ' End If
        ' If Session("acct_id") Is Nothing Then
        '     strAcct_ID = ""
        ' Else
        '     strAcct_ID = Convert.ToString(Session("acct_id")).Trim()
        ' End If
        ' If Session("sub_acct_id") Is Nothing Then
        '     strSubacctid = ""
        ' Else
        '     strSubacctid = Convert.ToString(Session("sub_acct_id")).Trim()
        ' End If
        ' strConfirm = ""

        ' If txtcn01.Text.Trim() = "" And txtcn02.Text.Trim() = "" And txtcn03.Text.Trim() = "" And txtcn04.Text.Trim() = "" And txtcn05.Text.Trim() = "" _
        'And txtcn06.Text.Trim() = "" And txtcn07.Text.Trim() = "" And txtcn08.Text.Trim() = "" And txtcn09.Text.Trim() = "" And txtcn10.Text.Trim() = "" _
        'And txtcn11.Text.Trim() = "" And txtcn12.Text.Trim() = "" And txtcn13.Text.Trim() = "" And txtcn14.Text.Trim() = "" And txtcn15.Text.Trim() = "" Then

        '     Response.Write("<script language='javascript'>alert('Please Enter a Voucher Number!');</script>")
        '     Exit Sub
        ' Else

        '     If txtcn01.Text.Trim() <> "" Then
        '         strConfirm = txtcn01.Text.Trim() + ","
        '     End If
        '     If txtcn02.Text.Trim() <> "" Then
        '         strConfirm = strConfirm & txtcn02.Text.Trim() + ","
        '     End If
        '     If txtcn03.Text.Trim() <> "" Then
        '         strConfirm = strConfirm & txtcn03.Text.Trim() + ","
        '     End If
        '     If txtcn04.Text.Trim() <> "" Then
        '         strConfirm = strConfirm & txtcn04.Text.Trim() + ","
        '     End If
        '     If txtcn05.Text.Trim() <> "" Then
        '         strConfirm = strConfirm & txtcn05.Text.Trim() + ","
        '     End If
        '     If txtcn06.Text.Trim() <> "" Then
        '         strConfirm = strConfirm & txtcn06.Text.Trim() + ","
        '     End If
        '     If txtcn07.Text.Trim() <> "" Then
        '         strConfirm = strConfirm & txtcn07.Text.Trim() + ","
        '     End If
        '     If txtcn08.Text.Trim() <> "" Then
        '         strConfirm = strConfirm & txtcn08.Text.Trim() + ","
        '     End If
        '     If txtcn09.Text.Trim() <> "" Then
        '         strConfirm = strConfirm & txtcn09.Text.Trim() + ","
        '     End If
        '     If txtcn10.Text.Trim() <> "" Then
        '         strConfirm = strConfirm & txtcn10.Text.Trim() + ","
        '     End If
        '     If txtcn11.Text.Trim() <> "" Then
        '         strConfirm = strConfirm & txtcn11.Text.Trim() + ","
        '     End If
        '     If txtcn12.Text.Trim() <> "" Then
        '         strConfirm = strConfirm & txtcn12.Text.Trim() + ","
        '     End If
        '     If txtcn13.Text.Trim() <> "" Then
        '         strConfirm = strConfirm & txtcn13.Text.Trim() + ","
        '     End If
        '     If txtcn14.Text.Trim() <> "" Then
        '         strConfirm = strConfirm & txtcn14.Text.Trim() + ","
        '     End If
        '     If txtcn15.Text.Trim() <> "" Then
        '         strConfirm = strConfirm & txtcn15.Text.Trim() + ","
        '     End If

        '     strConfirm = Mid(strConfirm, 1, strConfirm.Length - 1)
        '     Response.Redirect("ConfirmationList.aspx?pudate=" & strPudate & "&Confirm=" & strConfirm)
        ' End If
    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtcn01.Text = ""
        txtcn02.Text = ""
        txtcn03.Text = ""
        txtcn04.Text = ""
        txtcn05.Text = ""
        txtcn06.Text = ""
        txtcn07.Text = ""
        txtcn08.Text = ""
        txtcn09.Text = ""
        txtcn10.Text = ""
        txtcn11.Text = ""
        txtcn12.Text = ""
        txtcn13.Text = ""
        txtcn14.Text = ""
        txtcn15.Text = ""
        Dim date_FromDate As Date
        date_FromDate = "01/01/" & Year(Today())
        Me.txtDateAfter.Text = Format(date_FromDate, "M\/d\/yyyy")
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("confirminquiry.aspx")
    End Sub

    'Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
    '    Me.LoadData()
    '    Common.GenerateCSVFile(Me, Me.grdData, "VoucherInquiry.csv")
    'End Sub

#End Region

End Class
