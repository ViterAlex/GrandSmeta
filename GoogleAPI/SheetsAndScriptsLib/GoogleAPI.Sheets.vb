Imports System.Windows.Forms
Imports Google.Apis.Drive.v3
Imports Google.Apis.Sheets.v4.Data
Imports Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource.UpdateRequest
Imports File = Google.Apis.Drive.v3.Data.File

Partial Public Class GoogleAPI

#Region "Public Methods"

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
                                       If c.Value Is Nothing Then
                                           Return String.Empty
                                       End If
                                       Return c.Value
                                   End Function).ToList()
                           Return DirectCast(cells, IList(Of Object))
                       End Function).ToList()
        Dim valRange = New ValueRange With {.Values = values}
        Dim req = sheetService.Spreadsheets.Values.Update(valRange, spreadSheetId, rng)
        req.ValueInputOption = ValueInputOptionEnum.USERENTERED
        req.Execute()
    End Sub

    ''' <summary>
    ''' Получить листы указанной книги
    ''' </summary>
    ''' <param name="fileId">Id файла.</param>
    ''' <remarks>Оборачиваем в класс <see cref="SheetInfo"/>, чтобы было удобно отображать имя листа</remarks>
    Public Function GetSheets(fileId As String) As IList(Of SheetInfo)
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
    ''' Получить доступные для редактирования файлы SpreadSheets
    ''' </summary>
    Public Function GetSpreadsheets() As IList(Of SpreadsheetInfo)
        Dim req = driveService.Files.List()
        Dim resp = req.Execute()
        Return resp.Files.Where(Function(f)
                                    Return f.MimeType = "application/vnd.google-apps.spreadsheet"
                                End Function).
                                Select(Function(f)
                                           Return New SpreadsheetInfo With {.Id = f.Id, .Name = f.Name}
                                       End Function).
                                       ToList()
    End Function

    ''' <summary>
    '''     Импорт листа из книги
    ''' </summary>
    ''' <param name="spreadSheetId">ID книги</param>
    ''' <param name="sheetName">Имя листа</param>
    ''' <returns></returns>
    Public Function Import(spreadSheetId As Object, sheetName As String) As List(Of List(Of String))
        Dim req = sheetService.Spreadsheets.Values.Get(spreadSheetId, sheetName)
        Dim resp = req.Execute()
        Return resp.Values.Select(Function(l)
                                      Return l.Select(Function(l1)
                                                          If l1 Is Nothing Then
                                                              Return String.Empty
                                                          End If
                                                          Return l1.ToString()
                                                      End Function).ToList()
                                  End Function) _
                                  .ToList()
    End Function

#End Region

End Class
