Imports System.Threading
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Util
Imports Google.Apis.Util.Store

Partial Public Class GoogleAPI

    Private ReadOnly Scopes As IEnumerable(Of String) = New String() {
        "https://www.googleapis.com/auth/reminders"
    }
    Private ReadOnly token As String
    Private ReadOnly path As String
    Private credentials As UserCredential

    Friend Sub New(path As String)
        Me.path = path
    End Sub

    Friend Async Function Connect(Optional toolName As String = "") As Task(Of String)
        Dim productName As String = My.Application.Info.ProductName
        Dim credPath = IO.Path.Combine(Environment.CurrentDirectory, ".cred", IIf(String.IsNullOrEmpty(toolName), productName, toolName))
        Try

            credentials = Await GoogleWebAuthorizationBroker.AuthorizeAsync(clientSecrets:=GoogleClientSecrets.FromFile(path).Secrets,
                                                                            scopes:=Scopes,
                                                                            user:="user",
                                                                            taskCancellationToken:=CancellationToken.None,
                                                                            dataStore:=New FileDataStore(credPath, True))
            If credentials.Token.IsExpired(SystemClock.Default) Then
                Await credentials.RefreshTokenAsync(CancellationToken.None)
            End If
        Catch ex As Exception
            Return String.Empty
        End Try
        Return credentials.Token.AccessToken
    End Function

End Class
