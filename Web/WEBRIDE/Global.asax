<%@ Application Language="VB" %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
        '--add by daniel for handle the error informations. 26/11/2007
        Dim PageUrl As String = Convert.ToString(System.Web.HttpContext.Current.Request.Url)
        Dim ErrorInfo As Exception = Server.GetLastError()

        Dim Message As String = "Url:" & PageUrl & "</br></br>"
        Message = Message & " Path: " & Convert.ToString(System.Web.HttpContext.Current.Request.Path) & "</br></br>"
        Message = Message & " MachineName: " & Convert.ToString(Server.MachineName) & "</br></br>"
        Message = Message & " PhysicalPath: " & Convert.ToString(System.Web.HttpContext.Current.Request.PhysicalPath) & "</br></br>"
        Message = Message & " UserHostAddress: " & Convert.ToString(System.Web.HttpContext.Current.Request.UserHostAddress) & "</br></br>"
        Message = Message & " Error: "
        Message = Message & ErrorInfo.ToString & "</br></br>"
        
        Business.Mail.SendEmail("www.apexlimo.com", "web_dev_team@surreytechnology.com", "daniel.chen@surreytechnology.com", "", "APEX .NET Error", Message, True)
        
        Server.ClearError()
        
        'Response.Redirect("http://66.211.99.151/apex/errorpage.aspx", True)
        Response.Redirect("https://www.apexlimo.com/errorpage.aspx", True)
        
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
       
    Public Sub Global_AcquireRequestState(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.AcquireRequestState
        Dim url As String = System.IO.Path.GetFileName(Request.Path).Trim().ToLower()
        Select Case url
            Case "index.aspx", "index_news.aspx", "login.aspx", "pngfix.htc"
                Exit Sub
            Case "group_login.aspx", "corp_login.aspx"
                Exit Sub
            Case "register.aspx", "quickorderform.aspx", "quickorderconfirm.aspx", "quickorderconfirmno.aspx"
                Exit Sub
            Case Else
                If Not System.Web.HttpContext.Current.Session Is Nothing Then
                    If Session("user_id") Is Nothing Then
                        'Session("user_id") = "123456"
                        'Session("acct_id") = "201"
                        'session("sub_acct_id") = "0000000000"
                        'session("company") = "1"
                        
                        Select Case url
                            Case "order.aspx", "orderform.aspx"
                                'If Request.QueryString("StopModuleGetAirlineByAirport") Is Nothing Then
                                Response.Redirect("index.aspx")
                                'End If
                            Case "orderconfirm.aspx", "orderconfirmno.aspx", "rideinquiry.aspx", "ridehistory.aspx", "userprofile.aspx"
                                Response.Redirect("index.aspx")
                        End Select
                    ElseIf Session("acct_id") Is Nothing Then
                        Select Case url
                            Case "group_orderform.aspx", "group_orderconfirm.aspx", "group_orderconfirmno.aspx", "group_rideinquiry.aspx", "group_search.aspx"
                                Response.Redirect("index.aspx")
                            Case "corp_orderform.aspx", "corp_orderconfirm.aspx", "corp_orderconfirmno.aspx", "corp_rideinquiry.aspx", "corp_search.aspx", "corp_selectuser.aspx"
                                Response.Redirect("index.aspx")
                        End Select
                    End If
                End If
        End Select
    
        'If Not System.Web.HttpContext.Current.Session Is Nothing Then
        '    If Session("user_id") Is Nothing Then
        '        ' System.Web.HttpContext.Current.Session.Timeout = 150
        '        'Dim LocalDebug As String = System.Configuration.ConfigurationManager.AppSettings("LocalDebug")
        '        'If LocalDebug.Equals("Y") Then
        '        '    Session("user_id") = "admin"
        '        '    Session("priority") = "A"
        '        'End If
        '        Response.Redirect("index.aspx")
        '    End If
        'End If
    End Sub
    
</script>