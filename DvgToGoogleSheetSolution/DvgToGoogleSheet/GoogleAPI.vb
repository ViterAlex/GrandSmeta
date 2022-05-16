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

    Private ReadOnly Scopes As IEnumerable(Of String) = New String() {
        DriveService.Scope.Drive,
        SheetsService.Scope.Spreadsheets
    }

    Private credentials As UserCredential
    Private driveService As DriveService
    Private sheetService As SheetsService

    ''' <summary>
    ''' Создание нового сеанса с GoogleAPI
    ''' </summary>
    ''' <param name="token">Токен авторизации.</param>
    Public Sub New(token As String)
        Me.token = token
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
        Return True
    End Function

    ''' <summary>
    ''' Получить листы указанной книги
    ''' </summary>
    ''' <param name="fileId">Id файла.</param>
    ''' <remarks>Оборачиваем в класс <see cref="SheetInfo"/>, чтобы было удобно отображать имя листа</remarks>
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
    ''' <param name="dgv">Источник данных.</param>
    ''' <param name="spreadSheetId">Идентификатор книги.</param>
    ''' <param name="rng">Адрес ячейки, с которой начинать таблицу. В формате ИмяЛиста!А1.</param>
    Public Sub Export(dgv As DataGridView, spreadSheetId As String, rng As String)
        If dgv.Columns.Count = 0 Then
            Return
        End If
        'Получение данных из DataGridView в виде массива массивов
        Dim values = dgv.Rows.OfType(Of DataGridViewRow) _
            .Where(Function(r)
                       Return Not r.IsNewRow
                   End Function) _
                   .Select(Function(r)
                               Dim cells = r.Cells.OfType(Of DataGridViewCell) _
                               .Select(Function(c)
                                           Return c.Value
                                       End Function).ToList()
                               Return DirectCast(cells, IList(Of Object))
                           End Function).ToList()
        Dim valRange = New ValueRange With {.Values = values}
        Dim req = sheetService.Spreadsheets.Values.Update(valRange, spreadSheetId, rng)
        req.ValueInputOption = ValueInputOptionEnum.USERENTERED
        req.Execute()
    End Sub

End Class