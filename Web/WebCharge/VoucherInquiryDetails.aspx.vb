Imports System.Data
Imports System.Drawing.Graphics
Imports Business
Partial Class VoucherInquiryDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim strVoucherNo, strInvoiceNo As String
            If Not Request.QueryString("VoucherNo") Is Nothing Then
                strVoucherNo = Request.QueryString("VoucherNo")
            Else
                strVoucherNo = ""
            End If
            If Not Request.QueryString("InvoiceNo") Is Nothing Then
                strInvoiceNo = Request.QueryString("InvoiceNo")
            Else
                strInvoiceNo = ""
            End If
            LoadData(strVoucherNo, strInvoiceNo)
        End If
    End Sub
    Private Sub LoadData(ByVal strVoucherNo As String, ByVal strInvoiceNo As String)
        Using objReport As New Report
            Dim ds As VoucherData
            ds = objReport.GetVoucherInquiryDetail(strVoucherNo, strInvoiceNo)

            Me.lnkImage.Text = ds.voucher_no
            Me.lnkImage.Attributes.Add("onclick", "javascript:ShowVoucherImage('" & ds.voucher_no & "','" & ds.confirmation_no & "')")
            Me.lblInvoiceNo.Text = ds.invoice_no
            Me.lblInvoiceDate.Text = Common.ShowDateTime(ds.invoice_date, Common.DateTimeStyle.DateOnly)
            Me.lblCarNo.Text = ds.car_no
            Me.lblPassenger.Text = ds.Passenger
            Me.lblPUDate.Text = Common.ShowDateTime(ds.pu_date_time, Common.DateTimeStyle.DateOnly)
            Me.lblPUTime.Text = Common.ShowDateTime(ds.pu_date_time, Common.DateTimeStyle.TimeOnly)
            Me.lblPUAddress.Text = ds.Pu_address
            Me.lblDestination.Text = ds.Dest_address        
            Me.lblBaseRate.Text = Common.ShowPrice(ds.base_rate, Common.PricePrefix.null)
            Me.lblTolls.Text = Common.ShowPrice(ds.tolls, Common.PricePrefix.null)
            Me.lblParking.Text = Common.ShowPrice(ds.parking, Common.PricePrefix.null)
            Me.lblWaitAmount.Text = Common.ShowPrice(ds.wait_amount, Common.PricePrefix.null)
            Me.lblStAmount.Text = Common.ShowPrice(ds.stops_amt, Common.PricePrefix.null)
            Me.lblSWAmount.Text = Common.ShowPrice(ds.stop_wt_amount, Common.PricePrefix.null)
            Me.lblPackageAmount.Text = Common.ShowPrice(ds.package_amt, Common.PricePrefix.null)
            Me.lblPhoneAmount.Text = Common.ShowPrice(ds.phone_amt, Common.PricePrefix.null)
            Me.lblService.Text = Common.ShowPrice(ds.service_fee, Common.PricePrefix.null)
            Me.lblMiscellaneous.Text = Common.ShowPrice(ds.miscellaneous, Common.PricePrefix.null)
            Me.lblTips.Text = Common.ShowPrice(ds.tips, Common.PricePrefix.null)
            Me.lblGross.Text = Common.ShowPrice(ds.gross, Common.PricePrefix.null)
            Me.lblSurcharge.Text = Common.ShowPrice(ds.OT_surcharge_amt, Common.PricePrefix.null)
            Me.lblDiscount.Text = Common.ShowPrice(ds.Discount, Common.PricePrefix.null)
            Me.lblNet.Text = Common.ShowPrice(ds.net, Common.PricePrefix.null)
            Me.lblComment.Text = ds.comment

            '## 1/10/2007   Modified by yang
            'Me.lblCcdate.Text = Common.ShowDateTime(ds.cc_date, Common.DateTimeStyle.DateOnlyInEn)
            Me.lblCcdate.Text = ds.cc_date


            Dim obj_DataSource As New Report
            Dim m_dataset As New DataSet
            Dim m_DataTable As New DataTable
            Dim m_DataTable2 As New DataTable

            m_dataset = obj_DataSource.GetCompofVoucherInquiryDetail(strVoucherNo, strInvoiceNo)
            If Not m_dataset Is Nothing Then
                If m_dataset.Tables.Count > 0 Then
                    m_DataTable = m_dataset.Tables(0)
                    m_DataTable2 = m_dataset.Tables(1)
                    If m_DataTable2.Rows.Count > 0 Then
                        Dim n As Integer
                        For n = 0 To m_DataTable2.Rows.Count - 1
                            If IsDBNull(m_DataTable2.Rows(n).Item("req_desc")) Then
                                Session("strfield" & n + 1 & "name") = ""
                            ElseIf m_DataTable2.Rows(n).Item("req_desc").ToString.Trim() = "" Then
                                Session("strfield" & n + 1 & "name") = ""
                            Else
                                Session("strfield" & n + 1 & "name") = m_DataTable2.Rows(n).Item("req_desc")
                            End If
                        Next

                    Else
                        Session("strfield1name") = ""
                        Session("strfield2name") = ""
                        Session("strfield3name") = ""
                        Session("strfield4name") = ""
                        Session("strfield5name") = ""
                        Session("strfield6name") = ""
                    End If
                    Session("m_datatable") = m_DataTable
                    obj_DataSource = Nothing

                    If m_DataTable.Rows.Count = 0 Then
                        Dim strMessage As String = "<script language=""JavaScript"">alert('No information about the ACCOUNT! Please try again...');" & _
                                                   "history.go(-1);</script>"
                        RegisterStartupScript("PopUpMessage", strMessage)

                    End If
                End If
            End If

            If Not Session("strfield1name") Is Nothing And Convert.ToString(Session("strfield1name")).Trim() <> "" Then
                Me.tdComp1.Text = Session("strfield1name")
                Me.lblComp1.Text = ds.comp_id_1
            Else
                Me.td1.Visible = False
                Me.td2.Visible = False
            End If
            If Not Session("strfield2name") Is Nothing And Convert.ToString(Session("strfield2name")).Trim() <> "" Then
                Me.tdComp2.Text = Session("strfield2name")
                Me.lblComp2.Text = ds.comp_id_2
            Else
                Me.td3.Visible = False
                Me.td4.Visible = False
            End If
            If Not Session("strfield3name") Is Nothing And Convert.ToString(Session("strfield3name")).Trim() <> "" Then
                Me.tdComp3.Text = Session("strfield3name")
                Me.lblComp3.Text = ds.comp_id_3
            Else
                Me.td5.Visible = False
                Me.td6.Visible = False
            End If
            If Not Session("strfield4name") Is Nothing And Convert.ToString(Session("strfield4name")).Trim() <> "" Then
                Me.tdComp4.Text = Session("strfield4name")
                Me.lblComp4.Text = ds.comp_id_4
            Else
                Me.td7.Visible = False
                Me.td8.Visible = False
            End If
            If Not Session("strfield5name") Is Nothing And Convert.ToString(Session("strfield5name")).Trim() <> "" Then
                Me.tdComp5.Text = Session("strfield5name")
                Me.lblComp5.Text = ds.comp_id_5
            Else
                Me.td9.Visible = False
                Me.td10.Visible = False
            End If
            If Not Session("strfield6name") Is Nothing And Convert.ToString(Session("strfield6name")).Trim() <> "" Then
                Me.tdComp6.Text = Session("strfield6name")
                Me.lblComp6.Text = ds.comp_id_6
            Else
                Me.td11.Visible = False
                Me.td12.Visible = False
            End If
        End Using
    End Sub

End Class
