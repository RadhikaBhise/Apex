Imports Business
Imports System.Data

Partial Class Modules_corp_ridesearch
    Inherits System.Web.UI.UserControl

    Public Event Corp_RideSearch_Click()

#Region "Public ReadOnly Property"

    Public ReadOnly Property FromDate()
        Get
            Return Me.txtFDate.Text.Trim
        End Get
    End Property

    Public ReadOnly Property ToDate()
        Get
            Return Me.txtTDate.Text.Trim
        End Get
    End Property

    Public ReadOnly Property FName()
        Get
            Return Me.txtFName.Text.Trim
        End Get
    End Property

    Public ReadOnly Property LName()
        Get
            Return Me.txtLName.Text.Trim
        End Get
    End Property
    Public ReadOnly Property Comp_ID()
        Get
            Return Me.ddlComp_req.SelectedValue.Trim
        End Get
    End Property

    Public ReadOnly Property Comp_Value()
        Get
            Return Me.txtComp_req_value.Text.Trim
        End Get
    End Property

    Public ReadOnly Property Search_Password()
        Get
            Return Me.txtPW.Text.Trim
        End Get
    End Property

#End Region

#Region "Protected Sub Page Users Parts"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.LoadCompDate()
        End If

    End Sub

    Protected Sub ImageSubmit_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSubmit.ServerClick
        RaiseEvent Corp_RideSearch_Click()

    End Sub

#End Region

#Region "Private Sub Users Parts"

    Private Sub LoadCompDate()
        Dim objCompDesc As New Corporate
        Dim objDS As New DataSet
        Dim strvalue As String
        Dim strtext As String
        objDS = objCompDesc.get_comp_req(Convert.ToString(MySession.AcctID), Convert.ToString(MySession.SubAcctID))
        If Not objDS Is Nothing Then
            If objDS.Tables(0).Rows.Count > 0 Then
                Dim n As Integer
                For n = 0 To objDS.Tables(0).Rows.Count - 1
                    If Not IsDBNull(objDS.Tables(0).Rows(n).Item(0)) Then
                        strvalue = n + 1
                        strtext = objDS.Tables(0).Rows(n).Item(0).ToString.Trim()
                        Me.ddlComp_req.Items.Add(New ListItem(strtext, strvalue))
                    End If
                Next
            Else
                hdnCompReq.Value = "False"
            End If
        Else
            'donothing
        End If

    End Sub

#End Region

End Class
