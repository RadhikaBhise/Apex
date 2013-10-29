Imports System.Data
Imports System.Drawing.Graphics
Imports Business

Partial Class PassOfReport2
    Inherits System.Web.UI.Page

    Private grdDV As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack() Then
            If Not Request.QueryString("vipno") Is Nothing Then
                Me.hdnVipNo.Value = Request.QueryString("vipno").Trim
            End If

            If Not Request.QueryString("datetype") Is Nothing Then
                Me.hdnDateType.Value = Request.QueryString("datetype").Trim
            End If

            If Not Request.QueryString("fromdate") Is Nothing Then
                Me.hdnFromDate.Value = Request.QueryString("fromdate").Trim
            End If

            If Not Request.QueryString("todate") Is Nothing Then
                Me.hdnToDate.Value = Request.QueryString("todate").Trim
            End If

            If IsDate(Me.hdnFromDate.Value) AndAlso IsDate(Me.hdnToDate.Value) Then
                Me.lblTitle.Text = String.Format("From {0} Date: {1}&nbsp;&nbsp;&nbsp;&nbsp;To {0} Date: {2}&nbsp;&nbsp;&nbsp;&nbsp;Employee: {3}", IIf(Me.hdnDateType.Value = "t", "Trip", "Invoice"), Me.hdnFromDate.Value, Me.hdnToDate.Value, Me.hdnVipNo.Value)
            End If

            Using rpt As New Report
                Dim ds As DataSet = rpt.GetEmpReport2(MySession.AcctID, MySession.SubAcctID, Me.hdnVipNo.Value, Me.hdnDateType.Value, Me.hdnFromDate.Value, Me.hdnToDate.Value)
                Me.VoucherList1.DataSetSource = ds
                Me.VoucherList1.DataSetBind(-1, "")
            End Using
        End If

    End Sub

End Class
