Imports Business
Imports Business.Common
Imports System.Data
Imports System.Data.SqlClient

Partial Class Modules_stop
    Inherits System.Web.UI.UserControl

    Private ErrorMessage As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.LoadAjax()
        Me.LoadScript()
    End Sub

#Region " Properties "
    Private m_UserID As String
    Private m_AcctID As String
    Private m_SubAcctID As String
    Private m_Company As String

    Private m_PriceZone As String
    Private m_DispZone As String
    Private m_ZipCode As String

    Private m_StopType As StopType

    Public Property UserID() As String
        Get
            Return Me.m_UserID
        End Get
        Set(ByVal value As String)
            Me.m_UserID = value
            'Me.LoadFrequentAddressInfo()
        End Set
    End Property
    Public Property AcctID() As String
        Get
            Return Me.m_AcctID
        End Get
        Set(ByVal value As String)
            Me.m_AcctID = value
            'Me.LoadCampusLocationInfo()
            'Me.LoadFrequentAddressInfo()
        End Set
    End Property
    Public Property SubAcctID() As String
        Get
            Return Me.m_SubAcctID
        End Get
        Set(ByVal value As String)
            Me.m_SubAcctID = value
        End Set
    End Property
    Public Property Company() As String
        Get
            Return Me.m_Company
        End Get
        Set(ByVal value As String)
            Me.m_Company = value
        End Set
    End Property

    Public ReadOnly Property PriceZone() As String
        Get
            Return Me.m_PriceZone
        End Get
    End Property
    Public ReadOnly Property DispZone() As String
        Get
            Return Me.m_DispZone
        End Get
    End Property
    Public ReadOnly Property ZipCode() As String
        Get
            Return Me.m_ZipCode
        End Get
    End Property

    Enum StopType
        Pickup
        Destination
        WaitStop
        QuickQuotePickup
        QuickQuoteDestination
        FrequentAddress
    End Enum

#End Region

#Region " Address Properties "

#Region " Controls Properties "
    Public ReadOnly Property ctlDdlState() As DropDownList
        Get
            Return Me.ddlState
        End Get
    End Property
    Public ReadOnly Property ctlTxtCity() As TextBox
        Get
            Return Me.txtCity
        End Get
    End Property
    Public ReadOnly Property ctlTxtStName() As TextBox
        Get
            Return Me.txtStName
        End Get
    End Property
    Public ReadOnly Property ctlTxtStNo() As TextBox
        Get
            Return Me.txtStNo
        End Get
    End Property
    'Public ReadOnly Property ctlTxtZip() As TextBox
    '    Get
    '        Return Me.txtStName
    '    End Get
    'End Property
    'Public ReadOnly Property ctlTxtPPoint() As TextBox
    '    Get
    '        Return Me.txtStNo
    '    End Get
    'End Property
#End Region

    Public Property IsAirport() As Boolean
        Get
            Return Me.rdAirp.Checked
        End Get
        Set(ByVal value As Boolean)
            Me.rdAirp.Checked = value

            Me.tblNonAirp.Style.Add("display", Convert.ToString(IIf(value, "none", "")))
            Me.tblAirp.Style.Add("display", Convert.ToString(IIf(value, "", "none")))
        End Set
    End Property

    Public Property State() As String
        Get
            Return Me.ddlState.SelectedValue.Trim
        End Get
        Set(ByVal value As String)
            For Each li As ListItem In Me.ddlState.Items
                If li.Value.Trim() = value.Trim Then
                    Me.ddlState.SelectedIndex = -1
                    li.Selected = True
                End If
            Next
        End Set
    End Property
    Public ReadOnly Property StateName() As String
        Get
            Return Me.ddlState.SelectedItem.Text.Trim()
        End Get
    End Property
    Public Property StNo() As String
        Get
            Return Me.txtStNo.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.txtStNo.Text = value
        End Set
    End Property
    Public Property StName() As String
        Get
            Return Me.txtStName.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.txtStName.Text = value
        End Set
    End Property
    Public Property City() As String
        Get
            Return Me.txtCity.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.txtCity.Text = value
        End Set
    End Property
    Public Property Zip() As String
        Get
            Return Me.txtZip.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.txtZip.Text = value
        End Set
    End Property
    Public Property XSt() As String
        Get
            Return Me.txtXSt.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.txtXSt.Text = value
        End Set
    End Property
    Public Property Landmark() As String
        Get
            Return Me.txtLandmark.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.txtLandmark.Text = value
        End Set
    End Property
    Public Property PickupPoint() As String
        Get
            Return Me.txtPoint.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.txtPoint.Text = value
        End Set
    End Property

    Public ReadOnly Property Freq() As String
        Get
            Return Me.lstFreq.SelectedValue.Trim
        End Get
    End Property

    Public Property Airport() As String
        Get
            Return Me.ddlAirport.SelectedValue.Trim
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then value = ""

            For Each li As ListItem In Me.ddlAirport.Items
                If li.Value.Trim() = value.Trim() Then
                    Me.ddlAirport.SelectedIndex = -1
                    li.Selected = True
                End If
            Next

            'Me.Page.ClientScript.RegisterStartupScript(GetType(String), Me.ID & "Airport", "<script type='text/javascript'>document.getElementById('" & Me.ddlAirport.ClientID & "').fireEvent('onchange');</script>")
            ''##  Load airline
            If Me.ddlAirport.SelectedIndex >= 0 Then
                Using geo As New GeoInfos
                    Dim ds As DataSet = geo.getAllAirline(Me.ddlAirport.SelectedValue, "")

                    If Not ds Is Nothing AndAlso ds.Tables.Count > 0 Then
                        Me.ddlAirline.DataSource = ds.Tables(0).DefaultView
                        Me.ddlAirline.DataTextField = "airline"
                        'Me.ddlAirline.DataValueField = "airlinevalue"
                        Me.ddlAirline.DataBind()
                    End If
                End Using
            End If

            Me.ddlAirline.Items.Insert(0, "Please Select")
        End Set
    End Property
    Public ReadOnly Property AirportName() As String
        Get
            Return Me.ddlAirport.SelectedItem.Text.Trim()
        End Get
    End Property

    Public Property Airline() As String
        Get
            'Return Me.ddlAirline.SelectedValue.Trim
            Return Me.txtAirline.Text.Trim()
        End Get
        Set(ByVal value As String)
            'For Each li As ListItem In Me.ddlAirline.Items
            '    If li.Text.Trim() = value.Trim Then
            '        Me.ddlAirline.SelectedIndex = -1
            '        li.Selected = True
            '        Exit For
            '    End If
            'Next
            If value Is Nothing Then value = ""

            Common.ShowDropDownValue(Me.ddlAirline, value, False)
            Me.txtAirline.Text = value

            If Me.ddlAirline.Items.Count > 1 Then
                Me.txtAirline.Style.Add("display", "none")
                Me.ddlAirline.Style.Add("display", "")
            Else
                Me.ddlAirline.Style.Add("display", "none")
                Me.txtAirline.Style.Add("display", "")
            End If
        End Set
    End Property
    Public Property AirportFlight() As String
        Get
            Return Me.txtAirportFlight.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.txtAirportFlight.Text = value
        End Set
    End Property
    Public Property AirportTerminal() As String
        Get
            Return Me.txtTerminal.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.txtTerminal.Text = value
        End Set
    End Property
    Public Property AirportCity() As String
        Get
            Return Me.txtAirportCity.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.txtAirportCity.Text = value
        End Set
    End Property
    Public Property AirportOption() As String
        Get
            Return Me.ddlAirportOption.SelectedValue.Trim()
        End Get
        Set(ByVal value As String)
            For Each li As ListItem In Me.ddlAirportOption.Items
                If li.Value.Trim = value.Trim Then
                    Me.ddlAirportOption.SelectedIndex = -1
                    li.Selected = True
                End If
            Next
        End Set
    End Property

    Public WriteOnly Property AddressType() As StopType
        Set(ByVal value As StopType)
            Me.m_StopType = value

            Select Case value
                Case StopType.Destination
                    Me.rdAirp.Text = "Airport Destination"
                    Me.rdNonAirp.Text = "Destination"

                    Me.trPuPoint.Visible = False
                    Me.trCross.Visible = True
                    Me.trComments.Visible = False

                    Me.labelAirportCity.Text = "To"
                    Me.trAirpOption.Visible = False
                    Me.trAirpFlightTime.Visible = False

                    Me.trAirpTerminal.Visible = False
                    Me.lblFrequent.Text = "Frequent Destination"

                Case StopType.Pickup
                    Me.rdAirp.Text = "Airport Pick Up"
                    Me.rdNonAirp.Text = "Pick Up"

                    Me.trPuPoint.Visible = True
                    Me.trCross.Visible = False

                    Me.trComments.Visible = False

                    Me.labelAirportCity.Text = "Departing/Connecting City"
                    Me.trAirpOption.Visible = True
                    Me.trAirpFlightTime.Visible = False

                    Me.trAirpTerminal.Visible = False
                    Me.lblFrequent.Text = "Frequent Pickup"

                Case StopType.WaitStop

                Case StopType.QuickQuotePickup
                    Me.rdAirp.Text = "Airport Pick Up"
                    Me.rdNonAirp.Text = "Pick Up"

                    Me.trZipCode.Style.Add("display", "none")   'modifyed by joey   12/13/2007
                    Me.trPuPoint.Visible = False
                    Me.trCross.Visible = False
                    Me.trDirections.Visible = False
                    Me.trComments.Visible = False

                    Me.trAirpFlightNo.Visible = False
                    Me.trAirpCity.Visible = False
                    Me.trAirpFlightTime.Visible = False
                    Me.trAirpOption.Visible = False
                    Me.trAirpTerminal.Visible = False
                    Me.trAirpPhone.Visible = False
                    Me.trAirpDirections.Visible = False

                    Me.lnkAddrFormat.Visible = False
                    Me.tdFreq.Visible = False

                Case StopType.QuickQuoteDestination
                    Me.rdAirp.Text = "Airport Destination"
                    Me.rdNonAirp.Text = "Destination"

                    Me.trZipCode.Style.Add("display", "none")   'modifyed by joey   12/13/2007
                    Me.trPuPoint.Visible = False
                    Me.trCross.Visible = False
                    Me.trDirections.Visible = False
                    Me.trComments.Visible = False

                    Me.trAirpFlightNo.Visible = False
                    Me.trAirpCity.Visible = False
                    Me.trAirpFlightTime.Visible = False
                    Me.trAirpOption.Visible = False
                    Me.trAirpTerminal.Visible = False
                    Me.trAirpPhone.Visible = False
                    Me.trAirpDirections.Visible = False

                    Me.lnkAddrFormat.Visible = False
                    Me.tdFreq.Visible = False

                Case StopType.FrequentAddress
                    Me.rdAirport.Visible = False

                    Me.trLandmark.Visible = False
                    'Me.trZipCode.Visible = False     'disabled by lily 02/13/2008
                    'Me.trPuPoint.Visible = False
                    Me.trCross.Visible = False
                    Me.trDirections.Visible = False
                    Me.trComments.Visible = False
                    Me.lnkAddrFormat.Visible = False
                    Me.tdFreq.Visible = False
            End Select
        End Set
    End Property

#End Region

#Region " Private Methods "

    Private Sub LoadScript()

        Dim script As String = "javascript:document.getElementById('" & Me.tblAirp.ClientID & _
                                            "').style.display=this.checked?'{0}':'{1}';" & _
                                "javascript:document.getElementById('" & Me.tblNonAirp.ClientID & _
                                            "').style.display=this.checked?'{1}':'{0}';"

        Me.rdAirp.Attributes.Add("onclick", String.Format(script, "", "none"))
        Me.rdNonAirp.Attributes.Add("onclick", String.Format(script, "none", ""))

        'Me.txtStNo.Attributes.Add("onkeyup", "javascript:ResumeColor(" & Me.txtStNo.ClientID & ");")
        'Me.txtStName.Attributes.Add("onkeyup", "javascript:ResumeColor(" & Me.txtStName.ClientID & ");")
        'Me.txtCity.Attributes.Add("onkeyup", "javascript:ResumeColor(" & Me.txtCity.ClientID & ");")

        Me.lookupStreet.HRef = "javascript:StopMuduleLookupStreet('" & Me.ddlState.ClientID & "','" & Me.txtStName.ClientID & "','" & Me.txtCity.ClientID & "');"
        Me.lookupStreetNo.HRef = "javascript:StopMuduleLookupStreetNo('" & Me.ddlState.ClientID & "','" & Me.txtStName.ClientID & "','" & Me.txtStNo.ClientID & "','" & Me.txtCity.ClientID & "');"
        Me.lookupCity.HRef = "javascript:StopMuduleLookupCity('" & Me.ddlState.ClientID & "','" & Me.txtCity.ClientID & "');"
        Me.lookupLandmark.HRef = "javascript:StopMuduleLookupLandmark('" & Me.ddlState.ClientID & "','" & Me.txtCity.ClientID & "','" & Me.txtLandmark.ClientID & "','" & Me.txtStName.ClientID & "','" & Me.txtStNo.ClientID & "','" & Me.txtZip.ClientID & "');"

        Dim AddressPrefix As String = ""
        Dim NeedFlightNo As String = "false"
        Dim NeedAirline As String = "false"     '## add by joey 3/25/2008

        Select Case Me.m_StopType
            Case StopType.Pickup, StopType.QuickQuotePickup
                Me.lblAirpCityAsterisk.Visible = True
                Me.lblAirpFlightNoAsterisk.Visible = True
                Me.destairline.Visible = True       '## add by joey 3/25/2008
                NeedFlightNo = "true"
                NeedAirline = "true"                '## add by joey 3/25/2008

                AddressPrefix = "p"
            Case StopType.Destination, StopType.QuickQuoteDestination
                Me.lblAirpCityAsterisk.Visible = False
                Me.lblAirpFlightNoAsterisk.Visible = False
                Me.destairline.Visible = False       '## add by joey 3/25/2008
                NeedFlightNo = "false"
                NeedAirline = "false"               '## add by joey 3/25/2008

                AddressPrefix = "d"
            Case Else
                Me.lblAirpCityAsterisk.Visible = False
                Me.lblAirpFlightNoAsterisk.Visible = False
                Me.destairline.Visible = False       '## add by joey 3/25/2008
                NeedFlightNo = "false"
                NeedAirline = "false"               '## add by joey 3/25/2008

                AddressPrefix = ""
        End Select

        script = "<script type='text/javascript'>" & _
                    "function StopModule" & Me.ID & "Validate()" & _
                    "{" & _
                        "var out = true;" & _
                        "if(document.getElementById('" & Me.rdNonAirp.ClientID & "').checked){" & _
                            "if(document.getElementById('" & Me.ddlState.ClientID & "').selectedIndex>0){" & _
                                "var type = GetStateType(document.getElementById('" & Me.ddlState.ClientID & "').options[" & _
                                        "document.getElementById('" & Me.ddlState.ClientID & "').selectedIndex].value);" & _
                                "if(document.getElementById('" & Me.ddlState.ClientID & "').selectedIndex<=0){" & _
                                    "alert('Please select a state.');out=false;}" & _
                                "else{if(type==1){" & _
                                    "if(document.getElementById('" & Me.txtStName.ClientID & "').value.length==0){" & _
                                        "alert('Please enter a street name.');out=false;}" & _
                                    "else if(document.getElementById('" & Me.txtStNo.ClientID & "').value.length==0){" & _
                                        "alert('Please enter a street no.');out=false;}" & _
                                "}else if(type==2){" & _
                                    "if(document.getElementById('" & Me.txtCity.ClientID & "').value.length==0){" & _
                                        "alert('Please enter a city.');out=false;}}}" & _
                            "}else{alert('Please select a state.');out=false;}" & _
                        "}else{" & _
                            "if(document.getElementById('" & Me.ddlAirport.ClientID & "').selectedIndex<=0){" & _
                                "alert('Please select an airport.');out=false;}" & _
                            "else if(" & NeedAirline & " && document.getElementById('" & Me.ddlAirline.ClientID & "').style.display!='none' && " & _
                                        "document.getElementById('" & Me.ddlAirline.ClientID & "').selectedIndex<=0){" & _
                                "alert('Please select an airline.');out=false;}" & _
                            "else if(" & NeedAirline & " && document.getElementById('" & Me.txtAirline.ClientID & "').style.display!='none' && " & _
                                        "document.getElementById('" & Me.txtAirline.ClientID & "').value.length==0){" & _
                                "alert('Please enter an airline.');out=false;}" & _
                            "else if(" & NeedFlightNo & " && document.getElementById('" & Me.txtAirportFlight.ClientID & "').value.length==0){" & _
                                    "alert('Please enter a flight #.');out=false;}" & _
                            "else if(" & NeedFlightNo & " && document.getElementById('" & Me.txtAirportCity.ClientID & "').value.length==0){" & _
                                    "alert('Please enter a Departing/Connecting City!');out=false;}" & _
                            "}" & _
                            "return out;" & _
                        "}"

        script &= "function StopModule" & Me.ID & "VerifyStreet()" & _
                    "{" & _
                        "var strquery='';" & _
                        "if(document.getElementById('" & Me.rdAirp.ClientID & "').checked == false){" & _
                            "var index =document.getElementById( '" & Me.ddlState.ClientID & "').selectedIndex;" & _
                            "var strState=index>=0?document.getElementById('" & Me.ddlState.ClientID & "').options[index].value:'';" & _
                            "var strCity=document.getElementById('" & Me.txtCity.ClientID & "').value;" & _
                            "var strStrNo=document.getElementById('" & Me.txtStNo.ClientID & "').value;" & _
                            "var strStrName=document.getElementById('" & Me.txtStName.ClientID & "').value;" & _
                            "var strZip=document.getElementById('" & Me.txtZip.ClientID & "').value;" & _
                            "var strType='0';" & _
                            String.Format("strquery=strquery+'{0}state='+strState+'&{0}city='+strCity+'&{0}strno='+strStrNo+'&{0}strname='+strStrName+'&{0}zip='+strZip+'&{0}type='+strType;", AddressPrefix) & _
                        "}else{" & _
                            String.Format("strquery=strquery+'{0}state=&{0}city=&{0}strno=&{0}strname=&{0}zip=&{0}type=100'", AddressPrefix) & _
                        "}" & _
                        "return strquery;" & _
                    "}" & _
                "</script>"

        'script &= "function StopModule" & Me.ID & "VerifyDStreet()" & _
        '            "{" & _
        '                "var strquery='';" & _
        '                "if(document.getElementById('" & Me.rdAirp.ClientID & "').checked == false){" & _
        '                    "var index =document.getElementById( '" & Me.ddlState.ClientID & "').selectedIndex;" & _
        '                    "var strState=document.getElementById('" & Me.ddlState.ClientID & "').options[index].value;" & _
        '                    "var strCity=document.getElementById('" & Me.txtCity.ClientID & "').value;" & _
        '                    "var strStrNo=document.getElementById('" & Me.txtStNo.ClientID & "').value;" & _
        '                    "var strStrName=document.getElementById('" & Me.txtStName.ClientID & "').value;" & _
        '                    "var strZip=document.getElementById('" & Me.txtZip.ClientID & "').value;" & _
        '                    "var strType='0';" & _
        '                    "strquery=strquery+'dstate=' + strState + '&dcity=' + strCity + '&dstrno=' + strStrNo + '&dstrname=' + strStrName + '&dzip=' + strZip + '&dtype=' + strType;" & _
        '                "}else{" & _
        '                    "strquery=strquery+'&dtype=100'" & _
        '                "}" & _
        '                "return strquery;" & _
        '            "}" & _
        '        "</script>"

        Me.Page.ClientScript.RegisterClientScriptBlock(GetType(String), Me.ID & "Validate", script)
        'Me.Page.ClientScript.RegisterClientScriptBlock(GetType(String), Me.ID & "VerifyPStreet", script)
        'Me.Page.ClientScript.RegisterClientScriptBlock(GetType(String), Me.ID & "VerifyDStreet", script)

    End Sub

    Private Sub LoadStates()
        '## 1 Boro  2 OT    3 Airport
        '## 12 Boro & OT    123 ALL  and so on
        Dim OT_ONLY As String = 2

        Using geo As New GeoInfos()
            Dim ds As DataSet = geo.GetStates(OT_ONLY, "", "")

            If Not ds Is Nothing AndAlso ds.Tables.Count > 0 Then
                '## Bind Non-airport States
                Me.ddlState.DataSource = ds.Tables(0).DefaultView
                Me.ddlState.DataTextField = "description"
                Me.ddlState.DataValueField = "code"
                Me.ddlState.DataBind()

                '## Bind Airport States
                Me.ddlAirportState.DataSource = ds.Tables(0).DefaultView
                Me.ddlAirportState.DataTextField = "description"
                Me.ddlAirportState.DataValueField = "code"
                Me.ddlAirportState.DataBind()
            End If

            Me.ddlState.Items.Insert(0, "Please Select")
            Me.ddlAirportState.Items.Insert(0, "ALL")

        End Using

        Me.ddlState.Attributes.Add("onchange", "javascript:StopModuleSelectState('" & Me.ddlState.ClientID & "','" & Me.txtCity.ClientID & "');")
        Me.ddlAirportState.Attributes.Add("onchange", "javascript:StopModuleSelectAirportState(this,document.getElementById('" & Me.ddlAirport.ClientID & "'));")

    End Sub

    Private Sub LoadAirport()
        '## 1 Boro  2 OT    3 Airport
        '## 12 Boro & OT    123 ALL  and so on
        Dim AIRPORT As String = "3"

        Using geo As New GeoInfos
            Dim ds As DataSet = geo.GetStates(AIRPORT, "", "")

            If Not ds Is Nothing AndAlso ds.Tables.Count > 0 Then
                Me.ddlAirport.DataSource = ds.Tables(0).DefaultView
                Me.ddlAirport.DataTextField = "description"
                Me.ddlAirport.DataValueField = "code"
                Me.ddlAirport.DataBind()
            End If

            Me.ddlAirport.Items.Insert(0, "Please Select")

            Me.ddlAirport.Attributes.Add("onchange", "javascript:StopMuduleSelectAirport(this,document.getElementById('" & Me.ddlAirline.ClientID & "'),document.getElementById('" & Me.txtAirline.ClientID & "'),document.getElementById('" & Me.hdnAirport.ClientID & "'));")
            Me.ddlAirline.Attributes.Add("onchange", "javascript:StopMuduleSelectAirline(this,document.getElementById('" & Me.txtAirline.ClientID & "'),document.getElementById('" & Me.txtTerminal.ClientID & "'));")
        End Using
    End Sub

    'Private Sub LoadAirLine()
    '    If Me.ddlAirport.SelectedIndex > 0 Then
    '        Using geo As New GeoInfos
    '            Dim ds As DataSet = geo.GetAirlineDataSetByAirline(Me.ddlAirport.SelectedValue)

    '            If Not ds Is Nothing AndAlso ds.Tables.Count > 0 Then
    '                Me.ddlAirline.DataSource = ds.Tables(0).DefaultView
    '                Me.ddlAirline.DataTextField = "airline"
    '                Me.ddlAirline.DataValueField = "airlinevalue"
    '                Me.ddlAirline.DataBind()
    '            End If
    '        End Using

    '        'For Each li As ListItem In Me.ddlDAirline.Items
    '        '    If li.Text.Trim().Equals(ord.dest_city.Trim()) Then
    '        '        Me.ddlDAirline.SelectedIndex = -1
    '        '        li.Selected = True
    '        '        Exit For
    '        '    End If
    '        'Next
    '    End If
    'End Sub

    Private Sub LoadAjax()
        If Not Page.Request.QueryString("StopModuleGetAirlineByAirport") Is Nothing Then
            Dim AirportID As String = Request.QueryString("StopModuleGetAirlineByAirport").Trim

            Using geo As New GeoInfos
                Dim out As String = geo.GetAirlineStringByAirport(AirportID)
                Response.Write(out)
                Response.End()
            End Using
        ElseIf Not Page.Request.QueryString("StopModuleGetAirportByState") Is Nothing Then
            Dim StateCode As String = Request.QueryString("StopModuleGetAirportByState").Trim

            Using geo As New GeoInfos
                Dim out As String = geo.GetAirportStringByState(StateCode)
                Response.Write(out)
                Response.End()
            End Using
        End If
    End Sub

#End Region

#Region " Address Validate "

    ''------------------------------------------------------------------------------
    ''-- Function addr_validate
    ''-- Description: 
    ''-- Input:
    ''-- Output: 1              valid address 
    ''           -1             STREET NAME NOT FOUND
    ''           -2             STREET NO. OR BOROUGH INVALID WITH STREET
    ''           -3             THIS OUT OF TOWN ADDRESS CANNOT BE FOUND
    ''           -4             error
    ''-- 10/18/04 - Created (Nancy)
    ''-- 05/13/05 - Save Dispatch Zone (Spring)
    ''-- 01/16/06 - Default City "HEMPSTEAD" to LI but not NY (eJay)
    ''------------------------------------------------------------------------------
    'Public Function ValidateAddress() As Boolean
    '    Dim out As Boolean = False
    '    Dim intError As Integer
    '    Dim County, City, StName, StNo As String

    '    If Me.IsAirport Then
    '        County = Me.ddlAirport.SelectedValue.Trim()
    '        City = Me.ddlAirline.SelectedValue.Trim
    '        StName = "" : StNo = ""
    '    Else
    '        County = Me.ddlState.SelectedValue.Trim()
    '        City = Me.txtCity.Text.Trim()
    '        StName = Me.txtStName.Text.Trim()
    '        StNo = Me.txtStNo.Text.Trim()
    '    End If

    '    Using addrValid As New Address

    '        '## Default Hempstead to LI, will change back after verify
    '        If City.ToUpper = "HEMPSTEAD" AndAlso County.ToUpper = "NY" Then
    '            County = "LI"
    '        End If

    '        addrValid.st_no = StNo
    '        addrValid.st_name = StName
    '        addrValid.city = City
    '        addrValid.state = County

    '        addrValid.Verify()

    '        Me.m_PriceZone = addrValid.price_zone
    '        Me.m_DispZone = addrValid.disp_zone
    '        Me.m_ZipCode = addrValid.Zip

    '        If addrValid.verify_status = 1 Then
    '            Me.txtStName.Text = addrValid.final_st_name
    '        End If

    '        intError = addrValid.verify_status

    '    End Using

    '    If intError >= -3 AndAlso intError <= -1 Then
    '        Me.ShowAddressError(intError)
    '        out = False
    '    Else
    '        out = True
    '    End If

    '    Return out
    'End Function

    ''------------------------------------------------------------------------------
    ''-- Function Show_addr_err
    ''-- Description: Show_addr_err
    ''-- Input:
    ''-- Output:
    ''-- 10/18/04 - Created (Nancy)
    ''-- 10/26/04 - Updated some code (Tom)
    ''------------------------------------------------------------------------------
    'Private Sub ShowAddressError(ByVal intError As Integer)
    '    If intError >= -4 AndAlso intError <= -1 Then
    '        Using addr As New Address
    '            addr.state = Me.ddlState.SelectedValue.Trim()
    '            addr.city = Me.txtCity.Text.Trim()
    '            addr.st_name = Me.txtStName.Text.Trim
    '            addr.verify_status = intError
    '            addr.Show_addr_err(Me.Page, "", Me.txtStName.ClientID, Me.txtStNo.ClientID, Me.txtCity.ClientID, 400)
    '        End Using
    '    End If
    'End Sub

    'Public Sub InitAddress()
    '    Dim value As Boolean = Me.hdnIsAirport.Value.Trim().ToUpper().Equals("Y")
    '    Me.tableDest.Style.Add("display", Convert.ToString(IIf(value, "none", "")))
    '    Me.tableAirportDest.Style.Add("display", Convert.ToString(IIf(value, "", "none")))
    'End Sub

#End Region

#Region " Public Functions "

    Public Sub LoadStatesAndAirports()
        Me.LoadStates()
        Me.LoadAirport()
    End Sub

    Public Sub LoadFrequentAddress()
        If Not Me.m_AcctID Is Nothing AndAlso Convert.ToString(Me.m_AcctID).Trim().Length > 0 AndAlso _
                Not Me.m_UserID Is Nothing AndAlso Convert.ToString(Me.m_UserID).Trim().Length > 0 AndAlso _
                Not Me.m_SubAcctID Is Nothing AndAlso Convert.ToString(Me.m_SubAcctID).Trim.Length > 0 AndAlso _
                Not Me.m_Company Is Nothing AndAlso Convert.ToString(Me.m_Company).Trim.Length > 0 Then

            Using geo As New GeoInfos
                Dim ds As DataSet

                Select Case Me.m_StopType
                    Case StopType.Pickup
                        ds = geo.getFrequent(Me.m_UserID, Me.m_AcctID, Me.m_SubAcctID, Me.m_Company, "P")
                    Case Else
                        ds = geo.getFrequent(Me.m_UserID, Me.m_AcctID, Me.m_SubAcctID, Me.m_Company, "D")
                End Select

                If Not ds Is Nothing AndAlso ds.Tables.Count > 0 Then
                    Me.lstFreq.DataSource = ds.Tables(0).DefaultView
                    Me.lstFreq.DataTextField = "pickupaddr"
                    Me.lstFreq.DataValueField = "addrvalue"
                    Me.lstFreq.DataBind()

                    '## 1 Pickup Point  2 St Name   3 St No     4 Cross St  5 County    6 City
                    '   7 Pickup Phone  8 Pickup Phone Ext  9 Zip   10 Landmark  11 Direction
                    Dim script As String = "this,document.getElementById('" & Me.rdNonAirp.ClientID & "'),'" & _
                        Me.txtPoint.ClientID & "','" & Me.txtStName.ClientID & "','" & Me.txtStNo.ClientID & "','" & _
                        Me.txtXSt.ClientID & "','" & Me.ddlState.ClientID & "','" & Me.txtCity.ClientID & "','" & _
                        Me.txtPhone.ClientID & "','" & "pickup_phone_ext" & "','" & _
                        Me.txtZip.ClientID & "','" & Me.txtLandmark.ClientID & "','" & Me.txtDirections.ClientID & "'"


                    Me.lstFreq.Attributes.Add("onclick", "javascript:StopMuduleSelectFreq(" & script & ");")
                End If

                Me.lstFreq.Items.Insert(0, New ListItem("Please Select"))
            End Using
        End If
    End Sub

    Public Sub GetValueFromScreen(ByRef ord As OperatorData)
        Select Case Me.m_StopType
            Case StopType.Pickup, StopType.QuickQuotePickup
                With ord
                    If Me.rdAirp.Checked Then
                        .PuAir = "Y"

                        .pu_county_desc = ""
                        .pu_city = ""
                        .pu_st_no = ""
                        .pu_st_name = ""
                        .pu_zip = ""
                        .pu_point = ""
                        ' .pu_direction = Me.txtDirections.Text.Trim
                        .pu_landmark = ""

                        '## 1/7/2008    Add hdnAirport  (yang)
                        If Me.ddlAirport.SelectedValue.Trim.Length > 0 Then
                            .airport_name = Me.ddlAirport.SelectedValue.Trim().ToUpper
                        Else
                            .airport_name = Me.hdnAirport.Value.ToUpper
                        End If

                        .pu_county = .airport_name.ToUpper   '--add by daniel 12/06/2007

                        .airport_airline = Me.txtAirline.Text.Trim().ToUpper
                        .airport_flight = Me.txtAirportFlight.Text.Trim().ToUpper     'added toupper  by lily 01/30/2008
                        .airport_pu_point = Me.ddlAirportOption.SelectedValue.ToUpper
                        .airport_terminal = Me.txtTerminal.Text.Trim.ToUpper
                        .airport_from = Me.txtAirportCity.Text.Trim.ToUpper
                        .airport_phone = Me.txtPhone.Text.Trim.ToUpper  '## added by joey   12/05/2007
                        .airport_comment = Me.txtComments.Text.Trim.ToUpper
                        .pu_direction = Me.txtAirpDirections.Text.Trim.ToUpper  'added by lily 12/07/2007

                    Else
                        .PuAir = "N"

                        .pu_county = Me.ddlState.SelectedValue.Trim().ToUpper
                        .pu_county_desc = Me.ddlState.SelectedItem.Text.Trim().ToUpper  '## 11/22/2007  added by yang  ,added the Ucase  by lily 01/28/2008
                        .pu_city = Me.txtCity.Text.Trim().ToUpper                       'added the Ucase  by lily 01/28/2008
                        .pu_st_no = Me.txtStNo.Text.Trim()
                        .pu_st_name = Me.txtStName.Text.Trim().ToUpper                  'added the Ucase  by lily 01/28/2008
                        .pu_zip = Me.txtZip.Text.Trim()
                        .pu_point = Me.txtPoint.Text.Trim().ToUpper                   'added toupper by lily 01/30/2008
                        .pu_direction = Me.txtDirections.Text.Trim.ToUpper
                        .pu_landmark = Me.txtLandmark.Text.Trim.ToUpper

                        .airport_name = ""
                        .airport_airline = ""
                        .airport_flight = ""
                        .airport_pu_point = ""
                        .airport_terminal = ""
                        .airport_from = ""
                        .airport_phone = ""
                        .airport_comment = ""
                        ' .pu_airport_direction = ""  ' added by lily 12/07/2007
                    End If
                    '--Add by daniel 06/12/2007 for the Pu Dispatch Zone and Pu Price Zone
                    Dim objPrice As New Price

                    '## 12/6/2007   change to a new GetPriceZone function
                    .pu_price_zone = objPrice.GetPriceZone(MySession.Table_ID, .pu_county, .pu_city, .pu_st_name, .pu_st_no, .pu_landmark, .pu_disp_zone)
                    'If .PuAir = "Y" Then
                    '    .pu_price_zone = .airport_name
                    'Else
                    '    .pu_price_zone = objPrice.GetPriceZone(.pu_city, .pu_county_desc, .pu_county, MySession.Table_ID, .pu_disp_zone)
                    'End If

                    objPrice.Dispose() : objPrice = Nothing

                End With
            Case StopType.Destination, StopType.QuickQuoteDestination
                With ord
                    If Me.rdAirp.Checked Then
                        .DestAir = "Y"

                        .dest_county_desc = ""
                        .dest_city = ""
                        .dest_st_no = ""
                        .dest_st_name = ""
                        .dest_zip = ""
                        .dest_point = ""
                        ' .dest_direction = Me.txtDirections.Text.Trim
                        .dest_landmark = ""

                        .dest_aiport_name = Me.ddlAirport.SelectedValue.Trim().ToUpper
                        .dest_county = .dest_aiport_name.ToUpper   '--add by daniel 12/06/2007
                        .dest_airport_airline = Me.txtAirline.Text.Trim().ToUpper
                        .dest_airport_flight = Me.txtAirportFlight.Text.Trim().ToUpper
                        .dest_airport_point = Me.ddlAirportOption.SelectedValue.ToUpper
                        .dest_airport_terminal = Me.txtAirportCity.Text.Trim.ToUpper
                        .dest_airport_from = Me.txtAirportCity.Text.Trim.ToUpper
                        .dest_airport_comment = Me.txtComments.Text.Trim.ToUpper    '## added by joey   12/03/2007
                        .dest_direction = Me.txtAirpDirections.Text.Trim().ToUpper         'added by lily 12/07/2007

                        If IsDate(Me.ddlHour.SelectedValue & ":" & Me.ddlMinute.SelectedValue) Then
                            .dest_airport_departureTime = Convert.ToDateTime(Me.ddlHour.SelectedValue & ":" & Me.ddlMinute.SelectedValue)
                        Else
                            .dest_airport_departureTime = Now
                        End If

                    Else
                        .DestAir = "N"

                        .dest_county = Me.ddlState.SelectedValue.Trim().ToUpper
                        .dest_county_desc = Me.ddlState.SelectedItem.Text.Trim().ToUpper  '## 11/22/2007  added by yang,added the Ucase  by lily 01/27/2008
                        .dest_city = Me.txtCity.Text.Trim().ToUpper                 'added the Ucase  by lily 01/28/2008
                        .dest_st_no = Me.txtStNo.Text.Trim()
                        .dest_st_name = Me.txtStName.Text.Trim().ToUpper                'added the Ucase  by lily 01/28/2008
                        .dest_zip = Me.txtZip.Text.Trim()
                        .dest_point = Me.txtPoint.Text.Trim().ToUpper
                        .dest_direction = Me.txtDirections.Text.Trim.ToUpper
                        .dest_landmark = Me.txtLandmark.Text.Trim.ToUpper    '## added by joey   12/03/2007

                        .dest_aiport_name = ""
                        .dest_airport_airline = ""
                        .dest_airport_flight = ""
                        .dest_airport_point = ""
                        .dest_airport_terminal = ""
                        .dest_airport_from = ""
                        .dest_airport_comment = ""
                        ' .dest_airport_direction = ""  ' added by lily 12/07/2007
                    End If

                    '--Add by daniel 06/12/2007 for the Dest Dispatch Zone and Dest Price Zone
                    Dim objPrice As New Price

                    '## 12/6/2007   change to a new GetPriceZone function
                    .dest_price_zone = objPrice.GetPriceZone(MySession.Table_ID, .dest_county, .dest_city, .dest_st_name, .dest_st_no, .dest_landmark, .dest_disp_zone)
                    'If .DestAir = "Y" Then
                    '    .dest_price_zone = .dest_aiport_name
                    'Else
                    '    .dest_price_zone = objPrice.GetPriceZone(.dest_city, .dest_county_desc, .dest_county, MySession.Table_ID, .dest_disp_zone)
                    'End If

                    '## 12/6/2007   change to a new GetRate function
                    .price_est = objPrice.GetRate(MySession.Table_ID, .pu_county, .pu_city, .pu_st_name, .pu_price_zone, .dest_county, .dest_city, .dest_st_name, .dest_price_zone).ToString
                    'Try
                    '    Dim objEPrice As Single
                    '    objEPrice = objPrice.get_price(MySession.AcctID, MySession.SubAcctID, MySession.Company, _
                    '                                    CDate(.req_date_time), .Car_type, .pu_county, .pu_county_desc, _
                    '                                    .pu_city, .dest_county, .dest_county_desc, .dest_city, .pu_st_no, _
                    '                                    .pu_st_name, .pu_zip, .dest_st_no, .dest_st_name, .dest_zip, _
                    '                                    .Car_type, .pu_price_zone, .dest_price_zone)

                    '    .price_est = FormatCurrency(objEPrice)
                    '    .Mileage = objPrice.Mileage
                    '    .Base_rate = objPrice.Base_rate
                    '    .tolls_charges = objPrice.Tool_Charges
                    '    .parking_charges = objPrice.Park_Charges
                    '    .stops_charges = objPrice.Stops_Charges
                    '    .WT_charges = objPrice.WT_Charges
                    '    .tel_charges = objPrice.Tel_charges
                    '    .M_G_charges = objPrice.M_G_charges
                    '    .package_charges = objPrice.Package_Charges
                    '    .OT_charges = objPrice.OT_Charges
                    '    .tips_charges = objPrice.Tips_Charges
                    '    .discount = objPrice.Discount_Charges
                    '    .STC_charges = objPrice.STC_Charges
                    '    .service_fee = objPrice.Service_Charges
                    'Catch ex As Exception
                    '    .price_est = FormatCurrency(0.0)
                    '    .Mileage = 0.0
                    '    .Base_rate = 0
                    '    .tolls_charges = 0
                    '    .parking_charges = 0
                    '    .stops_charges = 0
                    '    .WT_charges = 0
                    '    .tel_charges = "0"
                    '    .M_G_charges = 0
                    '    .package_charges = "0"
                    '    .OT_charges = 0
                    '    .tips_charges = 0
                    '    .discount = 0
                    '    .STC_charges = 0
                    '    .service_fee = 0
                    'Finally
                    '    objPrice.Dispose()
                    '    objPrice = Nothing
                    'End Try

                End With

        End Select
    End Sub
    Public Sub LoadValueToScreen(ByVal ord As OperatorData)
        Select Case Me.m_StopType
            Case StopType.Pickup, StopType.QuickQuotePickup
                With ord
                    Me.IsAirport = ord.PuAir.Equals("Y")

                    If Me.rdAirp.Checked Then
                        Me.Airport = ord.airport_name
                        Me.Airline = ord.airport_airline    '## added by joey   12/05/2007
                        Me.txtAirline.Text = ord.airport_airline
                        Me.txtAirportFlight.Text = .airport_flight
                        Me.AirportOption = .airport_pu_point
                        Me.txtTerminal.Text = .airport_terminal
                        Me.txtAirportCity.Text = .airport_from
                        Me.txtPhone.Text = .airport_phone
                        Me.txtComments.Text = .airport_comment
                        Me.txtAirpDirections.Text = .pu_direction 'added by lily 12/07/2007
                    Else
                        Me.State = .pu_county
                        Me.txtCity.Text = .pu_city
                        Me.txtStNo.Text = .pu_st_no
                        Me.txtStName.Text = .pu_st_name
                        Me.txtZip.Text = .pu_zip
                        Me.txtPoint.Text = .pu_point
                        Me.txtDirections.Text = .pu_direction
                        Me.txtLandmark.Text = .pu_landmark  '## added by joey   12/03/2007

                    End If
                End With
            Case StopType.Destination, StopType.QuickQuoteDestination
                With ord
                    Me.IsAirport = ord.DestAir.Equals("Y")

                    If Me.rdAirp.Checked Then
                        Me.Airport = ord.dest_aiport_name
                        Me.Airline = ord.dest_airport_airline    '## added by joey   12/05/2007
                        Me.txtAirline.Text = ord.dest_airport_airline
                        Me.txtAirportFlight.Text = .dest_airport_flight
                        Me.txtTerminal.Text = .dest_airport_terminal
                        Me.txtAirportCity.Text = .dest_airport_terminal '## changed by joey 12/05/2007
                        Me.txtComments.Text = .dest_airport_comment
                        Me.txtAirpDirections.Text = .dest_direction 'added by lily 12/07/2007
                    Else
                        Me.State = .dest_county
                        Me.txtCity.Text = .dest_city
                        Me.txtStNo.Text = .dest_st_no
                        Me.txtStName.Text = .dest_st_name
                        Me.txtZip.Text = .dest_zip
                        Me.txtPoint.Text = .dest_point
                        Me.txtDirections.Text = .dest_direction
                        Me.txtLandmark.Text = .dest_landmark    '## added by joey   12/03/2007
                    End If
                End With
        End Select
    End Sub

    '## added by joey   12/06/2007
    Public Sub AddNewAddress()
        Me.trPuPoint.Style.Add("display", "none")
        Me.trLandmark.Style.Add("display", "none")
        Me.trDirections.Style.Add("display", "none")
        Me.trCross.Style.Add("display", "none")
        Me.trComments.Style.Add("display", "none")
        Me.IsAirport = False
        Me.rdAirport.Style.Add("display", "none")
        Me.tdFreq.Style.Add("display", "none")
        Me.LoadStates()
        Me.m_StopType = StopType.Pickup
    End Sub

#End Region

End Class
