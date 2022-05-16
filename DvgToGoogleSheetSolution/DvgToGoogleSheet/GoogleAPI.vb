Imports System.IO
Imports System.Text
Imports System.Threading
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Drive.v3
Imports Google.Apis.Services
Imports Google.Apis.Sheets.v4
Imports Google.Apis.Sheets.v4.Data
Imports Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource.UpdateRequest
Imports Google.Apis.Util.Store
Imports File = Google.Apis.Drive.v3.Data.File

Public Class GoogleAPI
    Private ReadOnly token As String
    Private sheetName As String
    Private Scopes As IEnumerable(Of String) = New String() {
        DriveService.Scope.Drive,
        SheetsService.Scope.Spreadsheets
    }
    Private credentials As UserCredential
    Private driveService As DriveService
    Private sheetService As SheetsService
    Private sheetId As String

    ''' <summary>
    ''' Создание нового сеанса с GoogleAPI
    ''' </summary>
    ''' <param name="token">Токен авторизации</param>
    ''' <param name="sheetName">Имя файла</param>
    Public Sub New(token As String, sheetName As String)
        Me.token = token
        Me.sheetName = sheetName
    End Sub
    ''' <summary>
    ''' Получить доступные для редактирования файлы SpreadSheets
    ''' </summary>
    Friend Function GetSpreadsheets() As IList(Of File)
        Dim req = driveService.Files.List()
        Dim resp = req.Execute()
        Return resp.Files.Where(Function(f)
                                    Return f.MimeType = "application/vnd.google-apps.spreadsheet"
                                End Function).ToList()
    End Function


    ''' <summary>
    ''' Установить соединение с Google API
    ''' </summary>
    ''' <returns></returns>
    Public Async Function Connect() As Task(Of Boolean)
        Dim credPath = Path.Combine(Environment.CurrentDirectory, ".cred", Application.ProductName)
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
                                           .ApplicationName = Application.ProductName
                                        })
        sheetService = New SheetsService(New BaseClientService.Initializer() With {
                                           .HttpClientInitializer = credentials,
                                           .ApplicationName = Application.ProductName
                                        })
        Dim reqDrive = driveService.Files.List()
        Dim respDrive = reqDrive.Execute()
        Dim file = respDrive.Files.First(Function(f)
                                             Return f.Name = sheetName
                                         End Function)
        If file IsNot Nothing Then
            sheetId = file.Id
            Dim reqSheets = sheetService.Spreadsheets.Get(sheetId)
            Dim respSheets = reqSheets.Execute()
            sheetName = respSheets.Sheets(0).Properties.Title
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' Получить листы указанной книги
    ''' </summary>
    ''' <param name="fileId">Id файла</param>
    Friend Function GetSheets(fileId As String) As IList(Of SheetInfo)
        Dim req = sheetService.Spreadsheets.Get(fileId)
        Dim resp = req.Execute()
        Return resp.Sheets().Select(Function(s)
                                        Return New SheetInfo With {
                                        .Title = s.Properties.Title,
                                        .SheetId = s.Properties.SheetId,
                                        .Sheet = s
                                        }
                                    End Function).ToList()
    End Function

    ''' <summary>
    ''' Экспортировать данные из <see cref="DataGridView"/>
    ''' </summary>
    ''' <param name="dgv">Источник данных</param>
    ''' <param name="rng">Адрес ячейки, с которой начинать таблицу</param>
    Public Sub Export(dgv As DataGridView, sheetId As String, rng As String)
        If dgv.Columns.Count = 0 Then
            Return
        End If

        Dim values = DirectCast(dgv.Rows.OfType(Of DataGridViewRow) _
            .Where(Function(r)
                       Return Not r.IsNewRow
                   End Function) _
                   .Select(Function(r)
                               Return DirectCast(r.Cells.OfType(Of DataGridViewCell) _
                               .Select(Function(c)
                                           Return c.Value
                                       End Function).ToList(), IList(Of Object))
                           End Function).ToList(), IList(Of IList(Of Object)))

        Dim req = sheetService.Spreadsheets.Values.Update(New ValueRange() With {
                                                          .Values = values
        }, sheetId, rng)
        req.ValueInputOption = ValueInputOptionEnum.USERENTERED
        req.Execute()
    End Sub
End Class
