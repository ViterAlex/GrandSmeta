Imports System.Runtime.CompilerServices
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Wordprocessing

<Assembly: InternalsVisibleTo("WordToolsTests, PublicKey = 0024000004800000940" +
                              "0000006020000002400005253413100040000010001007" +
                              "5382c02228e71076d491124ac27236474101c29d2f26a4" +
                              "0e4ad19fb244995795962fd21e37f2d00190675353f5bf" +
                              "d3c763c46400f05f21bd0d8b830318a38d1657c5bc620c" +
                              "f034a8e5fc00ed09caea13fe237f78ee24d5eb287b586f" +
                              "7fdd69793ec6310fd3eed7e7c2d36e728cc976948e2069" +
                              "1bd057a3d8a4455e214bdf8be")>

Public Class WordTool

    ''' <summary>
    ''' Подсчёт количества символов без пробелов
    ''' </summary>
    ''' <param name="path">Путь к файлу</param>
    Friend Shared Function ProcessDocx(path As String) As Integer
        Using doc = WordprocessingDocument.Open(path, False)
            Dim fn = doc.MainDocumentPart.FootnotesPart
            Dim en = doc.MainDocumentPart.EndnotesPart
            Dim body = doc.MainDocumentPart.Document.Body
            Dim md_count = ProcessMainDoc(body)
            Dim fn_count = ProcessFootnotes(fn)
            Dim en_count = ProcessEndnotes(en)
            Return md_count + fn_count + en_count
        End Using
    End Function

    Friend Shared Sub ClearDocxProperties(path As String)
        Using doc = WordprocessingDocument.Open(path, True)
            doc.PackageProperties.Category = Nothing
            doc.PackageProperties.ContentStatus = Nothing
            doc.PackageProperties.ContentType = Nothing
            doc.PackageProperties.Created = Nothing
            doc.PackageProperties.Creator = Nothing
            doc.PackageProperties.Description = Nothing
            doc.PackageProperties.Identifier = Nothing
            doc.PackageProperties.Keywords = Nothing
            doc.PackageProperties.Language = Nothing
            doc.PackageProperties.LastModifiedBy = Nothing
            doc.PackageProperties.LastPrinted = Nothing
            doc.PackageProperties.Modified = Nothing
            doc.PackageProperties.Revision = Nothing
            doc.PackageProperties.Subject = Nothing
            doc.PackageProperties.Title = Nothing
            doc.PackageProperties.Version = Nothing
            doc.Save()
        End Using
    End Sub

    ''' <summary>
    ''' Обработка выбранных файлов
    ''' </summary>
    ''' <param name="paths">Пути к файлам.</param>
    ''' <param name="progress">Класс для информирования о прогрессе</param>
    ''' <remarks>Обрабатыаются только файлы с расширениями *.doc, *.docx, *.docm, *.dotx, *.dotm. Остальные игнорируются</remarks>
    ''' <returns></returns>
    Public Shared Async Function ProcessFilesAsync(paths As IList(Of String), progress As IProgress(Of ProgressInfo)) As Task
        Dim docs = paths.Where(Function(p)
                                   Return p.EndsWith(".doc")
                               End Function)
        Dim docx = paths.Where(Function(p)
                                   Return p.EndsWith(".docx") OrElse p.EndsWith(".docm") OrElse p.EndsWith(".dotx") OrElse p.EndsWith(".dotm")
                               End Function)
        Dim pi As New ProgressInfo
        pi.StopWatch.Start()
        Await Task.WhenAll({
                           Task.Run(Sub()
                                        ProcessDocxFiles(docx, progress, pi)
                                    End Sub),
                           Task.Run(Sub()
                                        ProcessDocFiles(docs, progress, pi)
                                    End Sub)})
    End Function

    ''' <summary>
    ''' Обработка OpenXML документов
    ''' </summary>
    ''' <param name="files">Пути к файлам</param>
    ''' <param name="progress">Класс для информирования о прогрессе</param>
    ''' <param name="pi">Общий класс для учёта прогресса</param>
    Friend Shared Sub ProcessDocxFiles(files As IEnumerable(Of String), progress As IProgress(Of ProgressInfo), pi As ProgressInfo)
        For Each path In files
            Dim count = ProcessDocx(path)
            ClearDocxProperties(path)
            Dim item As New DocInfo With {
                .CharactersCount = count,
                .Path = path,
                .IsCleared = True
            }
            pi.Progress += 1
            pi.DocInfo.Add(item)
            progress.Report(pi)
        Next
    End Sub

    ''' <summary>
    ''' Обработка не-OpenXML документов
    ''' </summary>
    ''' <param name="files">Пути к файлам</param>
    ''' <param name="progress">Класс для информирования о прогрессе</param>
    ''' <param name="pi">Общий класс для учёта прогресса</param>
    Friend Shared Sub ProcessDocFiles(files As IEnumerable(Of String), progress As IProgress(Of ProgressInfo), pi As ProgressInfo)
        'Используем позднее связывание, чтобы не привязываться к версии Word
        Dim t = Type.GetTypeFromProgID("Word.Application")
        Dim wdApp As Object = Nothing
        Dim wdDoc As Object
        Try
            wdApp = Activator.CreateInstance(t)
#If DEBUG Then
            wdApp.Visible = True
#End If
        Catch ex As Exception
            'Return -1
        End Try
        For Each path In files

            wdDoc = wdApp.Documents.Open(path, AddToRecentFiles:=False)
            Dim count = ProcessDocFile(wdDoc)
            ClearDocProperties(wdDoc)
            Dim item As New DocInfo With {
                .CharactersCount = count,
                .Path = path,
                .IsCleared = True
            }
            pi.Progress += 1
            pi.DocInfo.Add(item)
            progress.Report(pi)
        Next

        wdApp.Quit(False)
    End Sub

    Friend Shared Function ProcessDocFile(wdDoc As Object) As Integer
        Const wdStatisticCharacters As Integer = 3
        Return Convert.ToInt32(wdDoc.Range.ComputeStatistics(wdStatisticCharacters))
    End Function

    ''' <summary>
    ''' Очистка свойств в не-OpenXML документах
    ''' </summary>
    ''' <param name="wdDoc">Документ</param>
    Friend Shared Sub ClearDocProperties(wdDoc As Object)
        Const wdRDIDocumentProperties As Integer = 8
        Try
            wdDoc.RemoveDocumentInformation(wdRDIDocumentProperties)
            For Each prop In wdDoc.BuiltInDocumentProperties
                prop.Value = Nothing
            Next
        Catch ex As Exception

        End Try
        wdDoc.Save()
        'wdDoc.Close()
    End Sub

    ''' <summary>
    ''' Обработка концевых сносок
    ''' </summary>
    Friend Shared Function ProcessEndnotes(en As EndnotesPart) As Integer
        If en Is Nothing OrElse en.Endnotes Is Nothing Then
            Return 0
        End If
        Dim texts = en.Endnotes.Descendants(Of Text)
        Dim textExcludeFallbacks = texts.Where(Function(t)
                                                   Return Not t.Ancestors(Of AlternateContentFallback)().Any()
                                               End Function)
        Dim count = textExcludeFallbacks.Sum(Function(t)
                                                 Return NoSpacesLength(t.InnerText)
                                             End Function)
        Return count
    End Function

    ''' <summary>
    ''' Обработка выносок
    ''' </summary>
    Friend Shared Function ProcessFootnotes(fn As FootnotesPart) As Integer
        If fn Is Nothing OrElse fn.Footnotes Is Nothing Then
            Return 0
        End If
        Dim texts = fn.Footnotes.Descendants(Of Text)
        Dim textExcludeFallbacks = texts.Where(Function(t)
                                                   Return Not t.Ancestors(Of AlternateContentFallback)().Any()
                                               End Function)
        Dim count = textExcludeFallbacks.Sum(Function(t)
                                                 Return NoSpacesLength(t.InnerText)
                                             End Function)
        Return count
    End Function

    ''' <summary>
    ''' Обработка основной части документа
    ''' </summary>
    Friend Shared Function ProcessMainDoc(body As Body) As Integer
        'Все текстовые фрагменты
        Dim texts = body.Descendants(Of Text)
        'Текстовые фрагметы, кроме тех, что отображаются вместо надмисей
        Dim textExcludeFallbacks = texts.Where(Function(t)
                                                   Return Not t.Ancestors(Of AlternateContentFallback)().Any()
                                               End Function)
        'Сумма длин текста
        Dim count = textExcludeFallbacks.Sum(Function(t)
                                                 Return NoSpacesLength(t.InnerText)
                                             End Function)
        Return count
    End Function

    ''' <summary>
    ''' Определение длины строки без пробелов
    ''' </summary>
    Friend Shared Function NoSpacesLength(text As String) As Integer
        'Убираем пробелы, неразрывные пробелы, табуляции
        Return text.Replace(" ", "") _
            .Replace(ChrW(&HA0), "") _
            .Replace(vbTab, "") _
            .Length
    End Function

End Class