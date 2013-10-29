Imports Business
Imports System.Data

Partial Class rate_lookup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.Stop1.LoadStatesAndAirports()

            Me.Stop2.LoadStatesAndAirports()

            Me.trRateResult.Visible = False
            Me.trFailed.Visible = False
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim ord As New OperatorData
        Dim HasSession As Boolean = Me.CheckSession

        ord.account_no = MySession.AcctID
        ord.sub_account_no = MySession.SubAcctID
        ord.company = MySession.Company
        ord.vip_no = MySession.UserID

        Me.Stop1.GetValueFromScreen(ord)
        Me.Stop2.GetValueFromScreen(ord)

        Me.trRateResult.Visible = True

        If Val(ord.price_est) > 0 Then
            Me.lblRate.Text = String.Format("Estimated Total: {0}", Common.ShowPrice(ord.price_est, Common.PricePrefix.null))
            Me.trFailed.Visible = False
        Else
            Me.lblRate.Text = ""
            Me.trFailed.Visible = True
        End If
        Me.Stop1.LoadValueToScreen(ord)
        Me.Stop2.LoadValueToScreen(ord)

        If Not HasSession Then
            MySession.ClearSession()
        End If
    End Sub

    Private Function CheckSession() As Boolean
        Dim out As Boolean = True

        If MySession.AcctID Is Nothing OrElse MySession.AcctID.Trim.Length = 0 Then
            MySession.AcctID = System.Web.Configuration.WebConfigurationManager.AppSettings("QuickOrderDefaultAcctID")
            out = False
        End If

        If MySession.SubAcctID Is Nothing OrElse MySession.SubAcctID.Trim.Length = 0 Then
            MySession.SubAcctID = System.Web.Configuration.WebConfigurationManager.AppSettings("QuickOrderDefaultSubAcctID")
            out = False
        End If

        If MySession.Company Is Nothing OrElse MySession.Company.Trim.Length = 0 Then
            MySession.Company = System.Web.Configuration.WebConfigurationManager.AppSettings("QuickOrderDefaultCompany")
            out = False
        End If

        If MySession.UserID Is Nothing OrElse MySession.UserID.Trim.Length = 0 Then
            MySession.UserID = System.Web.Configuration.WebConfigurationManager.AppSettings("QuickOrderDefaultUserID")
            out = False
        End If

        If MySession.Table_ID Is Nothing OrElse MySession.Table_ID.Trim.Length = 0 Then
            MySession.Table_ID = "1"
            out = False
        End If

        Return out
    End Function

    '#Region "Protected Sub Page Parts"

    '    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '        '--add by daniel for check login or not 
    '        Me.txtFrom.Attributes.Add("onkeypress", "javascript:entervalues();")
    '        Me.txtTo.Attributes.Add("onkeypress", "javascript:entervalues();")

    '        If Not Page.IsPostBack Then
    '            Me.ddlpucity.Visible = False
    '            Me.txtFrom.Visible = True
    '            Me.trhavenotResult.Visible = False
    '            Me.trgetprice.Visible = False
    '            Me.trwelcome.Visible = True
    '            'Call Me.Load_info()
    '        End If
    '        '-----------------------------------------------------------------------------------------

    '    End Sub

    '    Protected Sub btnreservation_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnreservation.ServerClick
    '        If Not Session("from_zone") Is Nothing AndAlso Not Session("to_zone") Is Nothing Then
    '            Response.Cookies("from_is_airport").Value = Session("from_is_airport").ToString
    '            If Session("from_is_airport").ToString = "True" Then
    '                Response.Cookies("from_airport").Value = Session("from_airport").ToString
    '            Else
    '                Response.Cookies("from_state").Value = Session("from_state").ToString
    '                Response.Cookies("from_city").Value = Session("from_city").ToString
    '            End If
    '            Response.Cookies("pickup_county").Value = Session("from_zone").ToString

    '            Response.Cookies("to_is_airport").Value = Session("to_is_airport").ToString
    '            If Session("to_is_airport").ToString = "True" Then
    '                Response.Cookies("to_airport").Value = Session("to_airport").ToString
    '            Else
    '                Response.Cookies("to_state").Value = Session("to_state").ToString
    '                Response.Cookies("to_city").Value = Session("to_city").ToString
    '            End If
    '            Response.Cookies("destination_county").Value = Session("to_zone").ToString

    '            Response.Redirect("webride/orderform.aspx", True)
    '        End If
    '    End Sub

    '    Protected Sub btnlookup_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnlookup.ServerClick
    '        Response.Redirect("Install.aspx", True)
    '    End Sub

    '    Protected Sub imgbtnquote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgbtnquote.Click
    '        '--hidtype is 'Y' then is airport else not or get it is airport
    '        '--first step:is airport
    '        '--add viewstate("from_airport_none") and viewstate("to_airport_none") by daniel 23/1/2007
    '        '--ViewState("from_airport_none") = "N" then only airport else is airport and cities. viewstate("to_airport_none") is same.
    '        Dim pu_price_zone As String
    '        Dim dest_price_zone As String
    '        Dim strfrom As String
    '        Dim strto As String
    '        'Session.Abandon()
    '        Session("to_value") = Nothing
    '        Session("from_value") = Nothing
    '        ViewState("from_airport_none") = "N"
    '        ViewState("to_airport_none") = "N"

    '        If Me.FormName.Value = "N" Then
    '            strfrom = Me.txtFrom.Text.Trim()
    '            Dim objPrice As New Price
    '            If objPrice.isairport(strfrom) Then
    '                pu_price_zone = strfrom
    '                Session("from_is_airport") = "True"
    '                Session("from_airport") = strfrom
    '                ViewState("from_airport_none") = "N"
    '                GoTo FormName
    '            Else
    '                ViewState("from_airport_none") = "N"

    '                Session("from_is_airport") = "False"
    'FROM:           If InStr(UCase(strfrom), ",", CompareMethod.Text) > 0 Then
    '                    Dim i As Integer = InStr(strfrom, ",", CompareMethod.Text)
    '                    Dim strleft As String
    '                    Dim strright As String
    '                    If i > 0 Then
    '                        strleft = Trim(Left(strfrom, i - 1))
    '                        strright = Trim(strfrom.Substring(i + 1, Len(strfrom) - i - 1))
    '                    Else
    '                        strleft = ""
    '                        strright = ""
    '                    End If
    '                    Dim objGeo As New Price
    '                    Dim pu_zone As String
    '                    Dim pu_DataZone As DataSet
    '                    pu_zone = objGeo.GetCityName_Zone(strleft, strright, pu_DataZone)
    '                    If pu_zone <> "" Then
    '                        If pu_DataZone Is Nothing Then
    '                            pu_price_zone = pu_zone
    '                            Session("from_state") = strright
    '                            Session("from_city") = strleft
    '                            'Me.FormName.Value = "Y"
    '                            'Me.txtFrom.Visible = False
    '                            'Me.ddlpucity.Visible = True
    '                        ElseIf Not pu_DataZone Is Nothing Then
    '                            If pu_DataZone.Tables.Count > 0 Then
    '                                Me.ddlpucity.DataSource = pu_DataZone
    '                                Me.ddlpucity.DataTextField = "description"
    '                                Me.ddlpucity.DataValueField = "pricing_zone"
    '                                Me.ddlpucity.DataBind()

    '                                Me.FormName.Value = "Y"
    '                                Me.txtFrom.Visible = False
    '                                Me.ddlpucity.Visible = True

    '                                ViewState("from") = "Y"
    '                                'Me.txtTo.Visible = True
    '                                'Me.ddldestcity.Visible = False
    '                                Me.trwelcome.Visible = False
    '                                Me.trhavenotResult.Visible = True
    '                                Me.trgetprice.Visible = False
    '                                Exit Sub
    '                            End If
    '                        End If
    '                    Else
    '                        Me.ddlpucity.Items.Clear()
    '                        If UCase(Me.txtFrom.Text.Trim()) = "NEW YORK, NY" Then
    '                            Me.ddlpucity.Items.Insert(0, New ListItem("Manhattan, NY", "01796"))
    '                            Me.ddlpucity.Items.Insert(1, New ListItem("Queens, NY", "02011"))
    '                            Me.ddlpucity.Items.Insert(2, New ListItem("Bronx, NY", "01730"))
    '                            Me.ddlpucity.Items.Insert(3, New ListItem("Brooklyn, NY", "01712"))
    '                            Me.ddlpucity.Items.Insert(4, New ListItem("Staten Island, NY", "02079"))

    '                            Me.FormName.Value = "Y"
    '                            Me.txtFrom.Visible = False
    '                            Me.ddlpucity.Visible = True

    '                            ViewState("from") = "Y"
    '                            Me.txtTo.Visible = True
    '                            Me.ddldestcity.Visible = False
    '                            Me.trwelcome.Visible = False
    '                            Me.trhavenotResult.Visible = True
    '                            Me.trgetprice.Visible = False
    '                            'Exit Sub
    '                        Else
    '                            Dim objDarkDataset As DataSet
    '                            objDarkDataset = objGeo.GetByblur_city_State(strleft, strright)
    '                            If Not objDarkDataset Is Nothing Then
    '                                If objDarkDataset.Tables.Count > 0 Then
    '                                    If objDarkDataset.Tables(0).Rows.Count > 0 Then
    '                                        Me.ddlpucity.DataSource = objDarkDataset
    '                                        Me.ddlpucity.DataTextField = "description"
    '                                        Me.ddlpucity.DataValueField = "pricing_zone"
    '                                        Me.ddlpucity.DataBind()

    '                                        Me.FormName.Value = "Y"
    '                                        Me.txtFrom.Visible = False
    '                                        Me.ddlpucity.Visible = True

    '                                        ViewState("from") = "Y"
    '                                        Me.txtTo.Visible = True
    '                                        Me.ddldestcity.Visible = False
    '                                        Me.trwelcome.Visible = False
    '                                        Me.trhavenotResult.Visible = True
    '                                        Me.trgetprice.Visible = False
    '                                        Exit Sub
    '                                    Else
    '                                        pu_price_zone = ""
    '                                        Me.FormName.Value = "N"
    '                                        Me.txtFrom.Visible = True
    '                                        Me.ddlpucity.Visible = False
    '                                        GoTo FormName
    '                                    End If
    '                                Else
    '                                    pu_price_zone = ""
    '                                    Me.FormName.Value = "N"
    '                                    Me.txtFrom.Visible = True
    '                                    Me.ddlpucity.Visible = False
    '                                    GoTo FormName
    '                                End If
    '                            Else
    '                                pu_price_zone = ""
    '                                Me.FormName.Value = "N"
    '                                Me.txtFrom.Visible = True
    '                                Me.ddlpucity.Visible = False
    '                                GoTo FormName
    '                            End If
    '                        End If
    '                    End If
    '                    objGeo.Dispose()
    '                    objGeo = Nothing
    '                Else
    'FormName:           Me.ddlpucity.Items.Clear()
    '                    If InStr(UCase(strfrom), "N", CompareMethod.Text) > 0 Then
    '                        Dim objUsers As New Price
    '                        Dim objDataset As DataSet

    '                        objDataset = objUsers.GetCityName(strfrom)
    '                        If Not objDataset Is Nothing Then
    '                            If objDataset.Tables.Count > 0 Then
    '                                If objDataset.Tables(0).Rows.Count > 0 Then
    '                                    Me.ddlpucity.DataSource = objDataset
    '                                    Me.ddlpucity.DataTextField = "description"
    '                                    Me.ddlpucity.DataValueField = "pricing_zone"
    '                                    Me.ddlpucity.DataBind()

    '                                    Me.ddlpucity.Items.Insert(0, New ListItem("Manhattan, NY", "01796"))
    '                                    Me.ddlpucity.Items.Insert(1, New ListItem("Queens, NY", "02011"))
    '                                    Me.ddlpucity.Items.Insert(2, New ListItem("Bronx, NY", "01730"))
    '                                    Me.ddlpucity.Items.Insert(3, New ListItem("Brooklyn, NY", "01712"))
    '                                    Me.ddlpucity.Items.Insert(4, New ListItem("Staten Island, NY", "02079"))

    '                                    If Not Session("from_is_airport") Is Nothing Then
    '                                        If Session("from_is_airport") = "True" Then
    '                                            Me.ddlpucity.Items.Insert(5, New ListItem(UCase(strfrom), UCase(strfrom)))  '--modify by daniel 23/1/2007
    '                                            ViewState("from_airport_none") = "Y"
    '                                        Else
    '                                            '--do nothing
    '                                        End If
    '                                    End If

    '                                    Me.FormName.Value = "Y"
    '                                    Me.txtFrom.Visible = False
    '                                    Me.ddlpucity.Visible = True

    '                                    ViewState("from") = "Y"
    '                                    Me.txtTo.Visible = True
    '                                    Me.ddldestcity.Visible = False
    '                                    Me.trwelcome.Visible = False
    '                                    Me.trhavenotResult.Visible = True
    '                                    Me.trgetprice.Visible = False
    '                                    Exit Sub
    '                                Else
    '                                    ViewState("from_airport_none") = "N"
    '                                    Me.FormName.Value = "N"
    '                                    Me.txtFrom.Visible = True
    '                                    Me.ddlpucity.Visible = False
    '                                End If
    '                            Else
    '                                ViewState("from_airport_none") = "N"
    '                                Me.FormName.Value = "N"
    '                                Me.txtFrom.Visible = True
    '                                Me.ddlpucity.Visible = False
    '                            End If
    '                        Else
    '                            ViewState("from_airport_none") = "N"
    '                            Me.FormName.Value = "N"
    '                            Me.txtFrom.Visible = True
    '                            Me.ddlpucity.Visible = False
    '                        End If
    '                        objUsers.Dispose()
    '                        objUsers = Nothing
    '                    Else
    '                        Dim objUsers As New Price
    '                        Dim objDataset As DataSet

    '                        objDataset = objUsers.GetCityName(strfrom)
    '                        If Not objDataset Is Nothing Then
    '                            If objDataset.Tables.Count > 0 Then
    '                                If objDataset.Tables(0).Rows.Count > 0 Then
    '                                    Me.ddlpucity.DataSource = objDataset
    '                                    Me.ddlpucity.DataTextField = "description"
    '                                    Me.ddlpucity.DataValueField = "pricing_zone"
    '                                    Me.ddlpucity.DataBind()

    '                                    If Not Session("from_is_airport") Is Nothing Then
    '                                        If Session("from_is_airport") = "True" Then
    '                                            Me.ddlpucity.Items.Insert(0, New ListItem(UCase(strfrom), UCase(strfrom)))  '--modify by daniel 23/1/2007
    '                                            ViewState("from_airport_none") = "Y"
    '                                        Else
    '                                            '--do nothing
    '                                        End If
    '                                    End If

    '                                    Me.FormName.Value = "Y"
    '                                    Me.txtFrom.Visible = False
    '                                    Me.ddlpucity.Visible = True

    '                                    ViewState("from") = "Y"
    '                                    Me.txtTo.Visible = True
    '                                    Me.ddldestcity.Visible = False
    '                                    Me.trwelcome.Visible = False
    '                                    Me.trhavenotResult.Visible = True
    '                                    Me.trgetprice.Visible = False
    '                                    Exit Sub
    '                                Else
    '                                    ViewState("from_airport_none") = "N"
    '                                    Me.FormName.Value = "N"
    '                                    Me.txtFrom.Visible = True
    '                                    Me.ddlpucity.Visible = False
    '                                End If
    '                            Else
    '                                ViewState("from_airport_none") = "N"
    '                                Me.FormName.Value = "N"
    '                                Me.txtFrom.Visible = True
    '                                Me.ddlpucity.Visible = False
    '                            End If
    '                        Else
    '                            ViewState("from_airport_none") = "N"
    '                            Me.FormName.Value = "N"
    '                            Me.txtFrom.Visible = True
    '                            Me.ddlpucity.Visible = False
    '                        End If
    '                        objUsers.Dispose()
    '                        objUsers = Nothing
    '                    End If
    '                End If
    '            End If
    '        Else
    '            '--else the ddlpucity is get pricing_zone
    '            If Me.txtFrom.Visible = True Then
    '                pu_price_zone = Me.txtFrom.Text.Trim()
    '                Session("from_is_airport") = "True"
    '                Session("from_airport") = Me.txtFrom.Text.Trim()
    '            Else
    '                If ViewState("from_airport_none") = "N" Then
    '                    pu_price_zone = Me.ddlpucity.SelectedValue.Trim()
    '                    Session("from_value") = Me.ddlpucity.SelectedItem.Text.Trim()
    '                    Dim i As Integer = InStr(Me.ddlpucity.SelectedItem.Text.Trim(), ",", CompareMethod.Text)
    '                    Dim strleft As String
    '                    Dim strright As String
    '                    If i > 0 Then
    '                        strleft = Trim(Left(Me.ddlpucity.SelectedItem.Text.Trim(), i - 1))
    '                        strright = Trim(Me.ddlpucity.SelectedItem.Text.Trim().Substring(i + 1, Len(Me.ddlpucity.SelectedItem.Text.Trim()) - i - 1))
    '                    Else
    '                        strleft = ""
    '                        strright = ""
    '                    End If
    '                    Session("from_state") = strright
    '                    Session("from_city") = strleft
    '                Else
    '                    pu_price_zone = Me.ddlpucity.SelectedValue.Trim()
    '                    Session("from_value") = Me.ddlpucity.SelectedItem.Text.Trim()
    '                    Dim i As Integer = InStr(Me.ddlpucity.SelectedItem.Text.Trim(), ",", CompareMethod.Text)
    '                    Dim strleft As String
    '                    Dim strright As String
    '                    If i > 0 Then
    '                        strleft = Trim(Left(Me.ddlpucity.SelectedItem.Text.Trim(), i - 1))
    '                        strright = Trim(Me.ddlpucity.SelectedItem.Text.Trim().Substring(i + 1, Len(Me.ddlpucity.SelectedItem.Text.Trim()) - i - 1))
    '                    Else
    '                        '--do nothing
    '                    End If
    '                    pu_price_zone = Me.ddlpucity.SelectedValue.Trim()
    '                    Session("from_is_airport") = "True"
    '                    Session("from_airport") = Me.ddlpucity.SelectedValue.Trim()
    '                End If
    '            End If
    '        End If

    '        '--to 
    '        If Me.txtTo.Value.Trim = "" Then
    '            Exit Sub
    '        End If
    '        If Me.ToName.Value = "N" Then
    '            strto = Me.txtTo.Value.Trim()
    '            Dim objRides As New Price
    '            If objRides.isairport(strto) Then
    '                dest_price_zone = strto
    '                Me.ToName.Value = "Y"
    '                Session("to_is_airport") = "True"
    '                Session("to_airport") = strto
    '                ViewState("to_airport_none") = "N"
    '                GoTo ToName
    '            Else
    '                Session("to_is_airport") = "False"
    'TOTO:           If InStr(strto, ",", CompareMethod.Text) > 0 Then
    '                    Dim i As Integer = InStr(strto, ",", CompareMethod.Text)
    '                    Dim strleft As String
    '                    Dim strright As String
    '                    If i > 0 Then
    '                        strleft = Trim(Left(strto, i - 1))
    '                        strright = Trim(strto.Substring(i + 1, Len(strto) - i - 1))
    '                    Else
    '                        strleft = ""
    '                        strright = ""
    '                    End If
    '                    Dim objGeo As New Price
    '                    Dim dest_zone As String
    '                    Dim dest_DataZone As DataSet
    '                    dest_zone = objGeo.GetCityName_Zone(strleft, strright, dest_DataZone)
    '                    If dest_zone <> "" Then
    '                        If dest_DataZone Is Nothing Then
    '                            dest_price_zone = dest_zone
    '                            Session("to_state") = strright
    '                            Session("to_city") = strleft
    '                        ElseIf Not dest_DataZone Is Nothing Then
    '                            If dest_DataZone.Tables.Count > 0 Then
    '                                Me.ddldestcity.DataSource = dest_DataZone
    '                                Me.ddldestcity.DataTextField = "description"
    '                                Me.ddldestcity.DataValueField = "pricing_zone"
    '                                Me.ddldestcity.DataBind()

    '                                Me.ToName.Value = "Y"
    '                                Me.txtTo.Visible = False
    '                                Me.ddldestcity.Visible = True
    '                                Exit Sub
    '                            End If
    '                        End If
    '                    Else
    '                        Me.ddldestcity.Items.Clear()
    '                        If UCase(Me.txtTo.Value.Trim()) = "NEW YORK, NY" Then
    '                            Me.ddldestcity.Items.Insert(0, New ListItem("Manhattan, NY", "01796"))
    '                            Me.ddldestcity.Items.Insert(1, New ListItem("Queens, NY", "02011"))
    '                            Me.ddldestcity.Items.Insert(2, New ListItem("Bronx, NY", "01730"))
    '                            Me.ddldestcity.Items.Insert(3, New ListItem("Brooklyn, NY", "01712"))
    '                            Me.ddldestcity.Items.Insert(4, New ListItem("Staten Island, NY", "02079"))

    '                            Me.ToName.Value = "Y"
    '                            Me.txtTo.Visible = False
    '                            Me.ddldestcity.Visible = True

    '                            'ViewState("from") = "Y"
    '                            'Me.txtTo.Visible = True
    '                            'Me.ddldestcity.Visible = False
    '                            'Me.trwelcome.Visible = False
    '                            'Me.trhavenotResult.Visible = True
    '                            'Me.trgetprice.Visible = False
    '                            Exit Sub
    '                        Else
    '                            Dim objDarkDataset As DataSet
    '                            objDarkDataset = objGeo.GetByblur_city_State(strleft, strright)
    '                            If Not objDarkDataset Is Nothing Then
    '                                If objDarkDataset.Tables.Count > 0 Then
    '                                    If objDarkDataset.Tables(0).Rows.Count > 0 Then
    '                                        Me.ddldestcity.DataSource = objDarkDataset
    '                                        Me.ddldestcity.DataTextField = "description"
    '                                        Me.ddldestcity.DataValueField = "pricing_zone"
    '                                        Me.ddldestcity.DataBind()

    '                                        Me.ToName.Value = "Y"
    '                                        Me.txtTo.Visible = False
    '                                        Me.ddldestcity.Visible = True
    '                                        Exit Sub
    '                                    Else
    '                                        dest_price_zone = ""
    '                                        Me.ToName.Value = "N"
    '                                        Me.txtTo.Visible = True
    '                                        Me.ddldestcity.Visible = False
    '                                        GoTo ToName
    '                                    End If
    '                                Else
    '                                    dest_price_zone = ""
    '                                    Me.ToName.Value = "N"
    '                                    Me.txtTo.Visible = True
    '                                    Me.ddldestcity.Visible = False
    '                                    GoTo ToName
    '                                End If
    '                            Else
    '                                dest_price_zone = ""
    '                                Me.ToName.Value = "N"
    '                                Me.txtTo.Visible = True
    '                                Me.ddldestcity.Visible = False
    '                                GoTo ToName
    '                            End If
    '                        End If
    '                    End If
    '                    objGeo.Dispose()
    '                    objGeo = Nothing
    '                Else
    'ToName:             Me.ddldestcity.Items.Clear()
    '                    If InStr(UCase(strto), "N", CompareMethod.Text) > 0 Then
    '                        Dim objUsers As New Price
    '                        Dim objDataset As DataSet

    '                        objDataset = objUsers.GetCityName(strto)
    '                        If Not objDataset Is Nothing Then
    '                            If objDataset.Tables.Count > 0 Then
    '                                If objDataset.Tables(0).Rows.Count > 0 Then
    '                                    Me.ddldestcity.DataSource = objDataset
    '                                    Me.ddldestcity.DataTextField = "description"
    '                                    Me.ddldestcity.DataValueField = "pricing_zone"
    '                                    Me.ddldestcity.DataBind()

    '                                    Me.ddldestcity.Items.Insert(0, New ListItem("Manhattan, NY", "01796"))
    '                                    Me.ddldestcity.Items.Insert(1, New ListItem("Queens, NY", "02011"))
    '                                    Me.ddldestcity.Items.Insert(2, New ListItem("Bronx, NY", "01730"))
    '                                    Me.ddldestcity.Items.Insert(3, New ListItem("Brooklyn, NY", "01712"))
    '                                    Me.ddldestcity.Items.Insert(4, New ListItem("Staten Island, NY", "02079"))

    '                                    If Not Session("to_is_airport") Is Nothing Then
    '                                        If Session("to_is_airport") = "True" Then
    '                                            Me.ddldestcity.Items.Insert(5, New ListItem(UCase(strto), UCase(strto)))
    '                                            ViewState("to_airport_none") = "Y"
    '                                        Else
    '                                            '--do nothing
    '                                        End If
    '                                    End If

    '                                    Me.ToName.Value = "Y"
    '                                    Me.txtTo.Visible = False
    '                                    Me.ddldestcity.Visible = True
    '                                    'ViewState("to") = "Y"
    '                                    'Me.txtFrom.Visible = True
    '                                    'Me.ddlpucity.Visible = False
    '                                    'Me.trwelcome.Visible = False
    '                                    'Me.trhavenotResult.Visible = True
    '                                    'Me.trgetprice.Visible = False
    '                                    Exit Sub
    '                                Else
    '                                    ViewState("to_airport_none") = "N"
    '                                    Me.ToName.Value = "N"
    '                                    Me.txtTo.Visible = True
    '                                    Me.ddldestcity.Visible = False
    '                                End If
    '                            Else
    '                                ViewState("to_airport_none") = "N"
    '                                Me.ToName.Value = "N"
    '                                Me.txtTo.Visible = True
    '                                Me.ddldestcity.Visible = False
    '                            End If
    '                        Else
    '                            ViewState("to_airport_none") = "N"
    '                            Me.ToName.Value = "N"
    '                            Me.txtTo.Visible = True
    '                            Me.ddldestcity.Visible = False
    '                        End If
    '                        objUsers.Dispose()
    '                        objUsers = Nothing
    '                    Else
    '                        Dim objUsers As New Price
    '                        Dim objDataset As DataSet

    '                        objDataset = objUsers.GetCityName(strto)
    '                        If Not objDataset Is Nothing Then
    '                            If objDataset.Tables.Count > 0 Then
    '                                If objDataset.Tables(0).Rows.Count > 0 Then
    '                                    Me.ddldestcity.DataSource = objDataset
    '                                    Me.ddldestcity.DataTextField = "description"
    '                                    Me.ddldestcity.DataValueField = "pricing_zone"
    '                                    Me.ddldestcity.DataBind()

    '                                    If Not Session("to_is_airport") Is Nothing Then
    '                                        If Session("to_is_airport") = "True" Then
    '                                            Me.ddldestcity.Items.Insert(0, New ListItem(UCase(strto), UCase(strto)))
    '                                            ViewState("to_airport_none") = "Y"
    '                                        Else
    '                                            '--do nothing
    '                                        End If
    '                                    End If

    '                                    Me.ToName.Value = "Y"
    '                                    Me.txtTo.Visible = False
    '                                    Me.ddldestcity.Visible = True

    '                                    'Me.txtFrom.Visible = True
    '                                    'Me.ddlpucity.Visible = False
    '                                    'Me.trwelcome.Visible = False
    '                                    'Me.trhavenotResult.Visible = True
    '                                    'Me.trgetprice.Visible = False
    '                                    Exit Sub
    '                                Else
    '                                    ViewState("to_airport_none") = "N"
    '                                    Me.ToName.Value = "N"
    '                                    Me.txtTo.Visible = True
    '                                    Me.ddldestcity.Visible = False
    '                                End If
    '                            Else
    '                                ViewState("to_airport_none") = "N"
    '                                Me.ToName.Value = "N"
    '                                Me.txtTo.Visible = True
    '                                Me.ddldestcity.Visible = False
    '                            End If
    '                        Else
    '                            ViewState("to_airport_none") = "N"
    '                            Me.ToName.Value = "N"
    '                            Me.txtTo.Visible = True
    '                            Me.ddldestcity.Visible = False
    '                        End If
    '                        objUsers.Dispose()
    '                        objUsers = Nothing
    '                    End If
    '                End If
    '            End If
    '            'objRides.Dispose()
    '            'objRides = Nothing
    '        Else
    '            '--else the ddlpucity is get pricing_zone
    '            If Me.txtTo.Visible = True Then
    '                dest_price_zone = Me.txtTo.Value.Trim()
    '                Session("to_is_airport") = "True"
    '                Session("to_airport") = Me.txtTo.Value.Trim()
    '            Else
    '                If ViewState("to_airport_none") = "N" Then
    '                    dest_price_zone = Me.ddldestcity.SelectedValue.Trim()
    '                    Session("to_value") = Me.ddldestcity.SelectedItem.Text.Trim()
    '                    Dim i As Integer = InStr(Me.ddldestcity.SelectedItem.Text.Trim(), ",", CompareMethod.Text)
    '                    Dim strleft As String
    '                    Dim strright As String
    '                    If i > 0 Then
    '                        strleft = Trim(Left(Me.ddldestcity.SelectedItem.Text.Trim(), i - 1))
    '                        strright = Trim(Me.ddldestcity.SelectedItem.Text.Trim().Substring(i + 1, Len(Me.ddldestcity.SelectedItem.Text.Trim()) - i - 1))
    '                    Else
    '                        strleft = ""
    '                        strright = ""
    '                    End If
    '                    Session("to_state") = strright
    '                    Session("to_city") = strleft
    '                Else
    '                    dest_price_zone = Me.ddldestcity.SelectedValue.Trim()
    '                    Session("to_value") = Me.ddldestcity.SelectedItem.Text.Trim()
    '                    Dim i As Integer = InStr(Me.ddldestcity.SelectedItem.Text.Trim(), ",", CompareMethod.Text)
    '                    Dim strleft As String
    '                    Dim strright As String
    '                    If i > 0 Then
    '                        strleft = Trim(Left(Me.ddldestcity.SelectedItem.Text.Trim(), i - 1))
    '                        strright = Trim(Me.ddldestcity.SelectedItem.Text.Trim().Substring(i + 1, Len(Me.ddldestcity.SelectedItem.Text.Trim()) - i - 1))
    '                    Else
    '                        '--do nothing
    '                    End If
    '                    dest_price_zone = Me.ddldestcity.SelectedValue.Trim()
    '                    Session("to_is_airport") = "True"
    '                    Session("to_airport") = Me.ddldestcity.SelectedValue.Trim()
    '                End If
    '            End If
    '        End If

    '        '--secord step:get estprice
    '        Dim objEstprice As New EstPrice
    '        Dim DecimalPrice As Decimal
    '        Dim strtable_id As Integer
    '        If Not Session("table_id") Is Nothing Then
    '            strtable_id = Convert.ToString(Session("table_id"))
    '        Else
    '            strtable_id = 1
    '        End If

    '        If pu_price_zone Is Nothing Or pu_price_zone = "" Then
    '            Me.trwelcome.Visible = False
    '            Me.trhavenotResult.Visible = True
    '            Me.trgetprice.Visible = False

    '            If Not Session("from_value") Is Nothing Then
    '                Me.txtFrom.Text = Session("from_value").ToString
    '                Me.txtFrom.Visible = True
    '                Me.ddlpucity.Visible = False

    '            End If
    '            If Not Session("to_value") Is Nothing Then
    '                Me.txtTo.Value = Session("to_value").ToString
    '                Me.txtTo.Visible = True
    '                Me.ddldestcity.Visible = False
    '            Else
    '                If Me.txtTo.Visible = True Then
    '                    Me.txtTo.Visible = True
    '                    Me.ddldestcity.Visible = False
    '                Else
    '                    Me.ddldestcity.Visible = True
    '                    Me.txtTo.Visible = False
    '                End If
    '            End If

    '            Exit Sub
    '        ElseIf dest_price_zone Is Nothing Or dest_price_zone = "" Then
    '            Me.trwelcome.Visible = False
    '            Me.trhavenotResult.Visible = True
    '            Me.trgetprice.Visible = False

    '            If Not Session("from_value") Is Nothing Then
    '                Me.txtFrom.Text = Session("from_value").ToString
    '                Me.txtFrom.Visible = True
    '                Me.ddlpucity.Visible = False

    '            End If
    '            If Not Session("to_value") Is Nothing Then
    '                Me.txtTo.Value = Session("to_value").ToString
    '                Me.txtTo.Visible = True
    '                Me.ddldestcity.Visible = False
    '            Else
    '                If Me.txtTo.Visible = True Then
    '                    Me.txtTo.Visible = True
    '                    Me.ddldestcity.Visible = False
    '                Else
    '                    Me.ddldestcity.Visible = True
    '                    Me.txtTo.Visible = False
    '                End If
    '            End If
    '        Else
    '            If InStr(pu_price_zone, ",", CompareMethod.Text) > 0 Then
    '                strfrom = pu_price_zone
    '                GoTo FROM
    '            End If
    '            If InStr(dest_price_zone, ",", CompareMethod.Text) > 0 Then
    '                strto = dest_price_zone
    '                GoTo TOTO
    '            End If

    '            DecimalPrice = objEstprice.Query_Price(pu_price_zone, dest_price_zone, strtable_id)
    '            If DecimalPrice > 0 Then
    '                If Me.FormName.Value = "Y" Then
    '                    If Me.txtFrom.Visible = True Then
    '                        Me.lblfrom.Text = Me.txtFrom.Text.Trim()
    '                    Else
    '                        Me.lblfrom.Text = Me.ddlpucity.SelectedItem.Text.Trim()
    '                    End If
    '                Else
    '                    Me.lblfrom.Text = Me.txtFrom.Text.Trim()
    '                End If
    '                If Me.ToName.Value = "Y" Then
    '                    If Me.txtTo.Visible = True Then
    '                        Me.lblto.Text = Me.txtTo.Value.Trim()
    '                    Else
    '                        Me.lblto.Text = Me.ddldestcity.SelectedItem.Text.Trim()
    '                    End If
    '                Else
    '                    Me.lblto.Text = Me.txtTo.Value.Trim()
    '                End If
    '                'Me.lblto.Text = Me.txtTo.Value.Trim()
    '                Me.lblcartype.Text = "Sedan"
    '                Me.lbltotal.Text = FormatCurrency(DecimalPrice)
    '                Me.trwelcome.Visible = False
    '                Me.trhavenotResult.Visible = False
    '                Me.trgetprice.Visible = True
    '                Session("from_zone") = pu_price_zone
    '                Session("to_zone") = dest_price_zone
    '                Me.FormName.Value = "N"
    '                Me.ToName.Value = "N"
    '                '-------------------------------
    '                Me.ddlpucity.Visible = False
    '                Me.ddldestcity.Visible = False
    '                Me.txtFrom.Visible = True
    '                Me.txtTo.Visible = True
    '                Me.txtFrom.Text = ""
    '                Me.txtTo.Value = ""
    '                'If Not Session("from_value") Is Nothing Then
    '                '    Me.txtFrom.Text = Session("from_value").ToString
    '                'End If
    '                'If Not Session("to_value") Is Nothing Then
    '                '    Me.txtTo.Value = Session("to_value").ToString
    '                'End If
    '                '--add by daniel for show informaitions
    '                Call Load_info()

    '                Exit Sub
    '            Else
    '                Me.FormName.Value = "N"
    '                Me.ToName.Value = "N"
    '                Me.trwelcome.Visible = False
    '                Me.trhavenotResult.Visible = True
    '                Me.trgetprice.Visible = False
    '                '-------------------------------
    '                '-------------------------------
    '                'Me.ddlpucity.Visible = False
    '                'Me.ddldestcity.Visible = False
    '                'Me.txtFrom.Visible = True
    '                'Me.txtTo.Visible = True
    '                'Me.txtFrom.Text = ""
    '                'Me.txtTo.Value = ""
    '                If Not Session("from_value") Is Nothing Then
    '                    Me.txtFrom.Text = Session("from_value").ToString
    '                    Me.txtFrom.Visible = True
    '                    Me.ddlpucity.Visible = False

    '                End If
    '                If Not Session("to_value") Is Nothing Then
    '                    Me.txtTo.Value = Session("to_value").ToString
    '                    Me.txtTo.Visible = True
    '                    Me.ddldestcity.Visible = False
    '                Else
    '                    If Me.txtTo.Visible = True Then
    '                        Me.txtTo.Visible = True
    '                        Me.ddldestcity.Visible = False
    '                    Else
    '                        Me.ddldestcity.Visible = True
    '                        Me.txtTo.Visible = False
    '                    End If
    '                End If

    '            End If
    '        End If

    '    End Sub

    '#End Region

    '#Region "Private Sub Users Parts"

    '    Private Sub Load_info()
    '        Dim objUsers As New Business.Users
    '        Dim strText As String

    '        If Not Session("user_id") Is Nothing AndAlso Not Session("acct_id") Is Nothing Then
    '            strText = objUsers.mtc_web_price_quote_verbage_custom_get(Session("acct_id").ToString, Session("sub_acct_id").ToString)
    '            If Trim(strText) = "" Then
    '                strText = objUsers.mtc_web_price_quote_verbage_default_get()
    '            End If
    '        Else
    '            strText = objUsers.mtc_web_price_quote_verbage_default_get()
    '        End If
    '        objUsers.Dispose()
    '        objUsers = Nothing

    '        Me.lblshowtext.Text = strText.Trim

    '    End Sub

    '    '-------------------------------------------------------------------
    '    '--Function:Check_DBNULL
    '    '--Description:Check the value 
    '    '--Input:Value
    '    '--Output:Nothing for DBNULL
    '    '--11/4/04 - Created (eJay)
    '    '-------------------------------------------------------------------
    '    Private Function Check_DBNULL(ByVal Value As Object) As String

    '        If IsDBNull(Value) = True Then
    '            Return Nothing
    '        Else
    '            Return Convert.ToString(Value).Trim()
    '        End If

    '    End Function

    '#End Region

End Class
