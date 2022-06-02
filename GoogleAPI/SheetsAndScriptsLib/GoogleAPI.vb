Imports System.IO
Imports System.Text
Imports System.Threading
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Drive.v3
Imports Google.Apis.Script.v1
Imports Google.Apis.Services
Imports Google.Apis.Sheets.v4
Imports Google.Apis.Util.Store

Partial Public Class GoogleAPI

#Region "Private Fields"

    Private ReadOnly Scopes As IEnumerable(Of String) = New String() {
        DriveService.Scope.Drive,
        SheetsService.Scope.Spreadsheets,
        ScriptService.Scope.ScriptProjects,
        ScriptService.Scope.ScriptDeployments
    }

    Private ReadOnly token As String
    Private credentials As UserCredential
    Private driveService As DriveService
    Private scriptService As ScriptService
    Private sheetService As SheetsService

#End Region

#Region "Public Constructors"

    ''' <summary>
    ''' Создание нового сеанса с GoogleAPI
    ''' </summary>
    ''' <param name="token">Токен авторизации.</param>
    Public Sub New(token As String)
        Me.token = token
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    ''' Установить соединение с Google API
    ''' </summary>
    Public Async Function Connect() As Task(Of Boolean)
        Dim productName As String = My.Application.Info.ProductName

        Dim credPath = Path.Combine(Environment.CurrentDirectory, ".cred", productName)
        Try

            Using s As New MemoryStream(Encoding.UTF8.GetBytes(token))
                credentials = Await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    clientSecrets:=GoogleClientSecrets.FromStream(s).Secrets,
                    scopes:=Scopes,
                    user:="user",
                    taskCancellationToken:=CancellationToken.None,
                    dataStore:=New FileDataStore(credPath, True))
            End Using

            driveService = New DriveService(New BaseClientService.Initializer() With {
                                            .HttpClientInitializer = credentials,
                                            .ApplicationName = productName
                                            })
            sheetService = New SheetsService(New BaseClientService.Initializer() With {
                                             .HttpClientInitializer = credentials,
                                             .ApplicationName = productName
                                             })
            scriptService = New ScriptService(New BaseClientService.Initializer() With {
                                              .HttpClientInitializer = credentials,
                                              .ApplicationName = productName
                                              })
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

#End Region

End Class