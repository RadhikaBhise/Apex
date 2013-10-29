Imports Business
Partial Class VerifyStreet
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'RegisterStartupScript("", "<script language='javascript'>filldata();</script>")
        Dim strPickUp As String
        Dim strDest As String
        Dim objAddr As New Address
        Dim strMsg As String

        With objAddr
            .PState = Request.QueryString("pstate")
            .PCity = Request.QueryString("pcity")
            .PStreetNo = Request.QueryString("pstrno")
            .PStreetName = Request.QueryString("pstrname")
            .PZip = Request.QueryString("pzip")
            .PType = Request.QueryString("ptype")

            .DState = Request.QueryString("dstate")
            .DCity = Request.QueryString("dcity")
            .DStreetNo = Request.QueryString("dstrno")
            .DStreetName = Request.QueryString("dstrname")
            .DZip = Request.QueryString("dzip")
            .DType = Request.QueryString("dtype")
        End With

        '## 2/4/2008    Add address type    (yang)
        '## 1) type = freq  For freq address validate.  
        If Not Request.QueryString("type") Is Nothing Then
            Me.hdnType.Value = Request.QueryString("type").Trim
        End If

        If Me.hdnType.Value = "freq" Then
            Me.lblPickUp.Text = "Frequent Address:"
            Me.trDest.Style.Add("display", "none")

            Me.btnYes.Value = "Click here to save the address"
            Me.btnNo.Value = "Click here to return back"
        End If

        Call objAddr.Verify()

        Me.hidMatchPStreet.Value = objAddr.MatchPStreetName.Trim
        Me.hidMatchDStreet.Value = objAddr.MatchDStreetName.Trim

        Dim strScript As String
        If objAddr.errflag(0) <> 3 And objAddr.errflag(0) <> 2 And objAddr.errflag(0) <> 1 And objAddr.errflag(1) <> 1 And objAddr.errflag(1) <> 2 And objAddr.errflag(1) <> 3 Then
            '  If True Then
            'strScript = "<script language='javascript'> window.returnValue='T|" & objAddr.MatchPStreetName.Trim & "|" & objAddr.MatchDStreetName.Trim & "';</script>"
            strScript = "<script language='javascript'> window.returnValue='T';window.close();</script>"
        Else
            'strScript = "<script language='javascript'>  window.returnValue='F|" & objAddr.MatchPStreetName.Trim & "|" & objAddr.MatchDStreetName.Trim & "';</script>"
            strScript = "<script language='javascript'> window.returnValue='F';</script>"
        End If


        RegisterClientScriptBlock("setOpner", strScript)

        '''''--Result Page
        'Dim html1 As String = "<center><b><font face=""arial"" size=""2"" color=""black"">Street Validation</font></b><br><table width=""100%"" border=1 cellspacing=""0""><tr><td valign=""top"" bgcolor=""lightgrey""><font face=""tahoma,arial"" size=""2""><b>Pickup<br>Address:</td><td>"
        'Response.Write(html1)
        If objAddr.PType.Equals("0") Then
            Select Case objAddr.errflag(0)
                Case 1
                    strPickUp = "<font class=error>STREET NAME NOT FOUND</font>"
                Case 2
                    strPickUp = "<font class=error>STREET NO. INVALID WITH STREET NAME</font>"
                Case 3
                    strPickUp = "<font class=error>OT CITY/STATE NOT FOUND. PLEASE VERIFY CITY AND STATE NAME.</font><br />" 'THIS ORDER WILL NOT BE PRICED</font>"
                    strPickUp = strPickUp & "If you think this address is a valid address you may click the button below to continue. Please note that this order will NOT be priced until dispatched."
                    'Case 4
                    '  strPickUp = "<font class=match>OT CITY/STATE ACCEPTED</font>"
                Case Else
                    strPickUp = "<font class=match>ADDRESS ACCEPTED<br></font>"
            End Select
        Else
            strPickUp = "<font class=match>ADDRESS ACCEPTED<br></font>"
        End If
        Me.lblPickUp.Text = strPickUp

        'Dim html2 = "</td><tr><td valign=""top"" bgcolor=""lightgrey""><font face=""tahoma,arial"" size=""2""><b>Destination<br>Address:</td><td>"
        'Response.Write(html2)

        If objAddr.DType.Equals("0") Then
            Select Case objAddr.errflag(1)
                Case 1
                    strDest = "<font class=error>STREET NAME NOT FOUND</font>"
                Case 2
                    strDest = "<font class=error>STREET NO. INVALID WITH STREET NAME</font>"
                Case 3
                    strDest = "<font class=error>OT CITY/STATE NOT FOUND. PLEASE VERIFY CITY AND STATE NAME.</font><br />"
                    strDest = strDest & "<font class=error>If you think this address is a valid address you may click the button below to continue. Please note that this order will NOT be priced until dispatched.</font>"
                    'Case 4
                    '  strDest = "<font class=match>OT CITY/STATE ACCEPTED</font>"
                Case Else
                    strDest = "<font class=match>ADDRESS ACCEPTED<br></font>"
            End Select
        Else
            strDest = "<font class=match>ADDRESS ACCEPTED<br></font>"
        End If
        Me.lblDest.Text = strDest

        'strMsg = "<hr noshade><font class=tips>"


        'If objAddr.errflag(0) = 1 Or objAddr.errflag(0) = 2 Or objAddr.errflag(1) = 1 Or objAddr.errflag(1) = 2 Then
        '  strMsg &= "Tips for entering street names:<br><ol>"

        '  If objAddr.errflag(0) = 2 Or objAddr.errflag(1) = 2 Then
        '    strMsg &= "<li>Please check the street # and borough.</li>"

        '  End If
        '  strMsg &= "<li>Enter the directions &quot;North&quot;,&quot;East&quot;,&quot;West&quot;,&quot;South&quot; as full names do not abbreviate<br><font color=""red"">i.e. For the street &quot;West Ave&quot;, type &quot;West Ave&quot; not &quot;W Ave&quot;</font></li><li>Enter numeric street names as numbers not spelled out.<br><font color=""red"">i.e. For the street &quot;10th Ave&quot;, type &quot;10th Ave&quot; not &quot;Tenth Ave&quot;</font></li><li>If you are still unable to find the street, please contact the administrator</li></ol></font>"

        'End If

        ''''''
        'ltrMsg.Text = strMsg
        ''Session("VerifyAddr") = objAddr
        'objAddr = Nothing

        'Response.Redirect("./verifyStreet2.aspx")
    End Sub

    'Protected Sub btnNo_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNo.ServerClick
    '    Me.Response.Redirect("orderform.aspx")
    '    Dim strScript As String
    '    strScript = "<script language='javascript'> window.returnValue='F';</script>"
    '    RegisterClientScriptBlock("setOpner", strScript)
    'End Sub
End Class
