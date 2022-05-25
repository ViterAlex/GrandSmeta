Imports System.IO
Imports DocumentFormat.OpenXml.Wordprocessing
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml

Public Class WordTool
    ''' <summary>
    ''' Подсчёт количества символов без пробелов
    ''' </summary>
    ''' <param name="path">Путь к файлу</param>
    Public Shared Function CharactersWithoutSpaces(path As String) As Integer
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

    Public Shared Async Function AsyncCharactersWithoutSpaces(path As String) As Task(Of Integer)
        Return Await Task.Run(Function()
                                  Return CharactersWithoutSpaces(path)
                              End Function)
    End Function

    ''' <summary>
    ''' Обработка концевых сносок
    ''' </summary>
    Private Shared Function ProcessEndnotes(en As EndnotesPart) As Integer
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
    Private Shared Function ProcessFootnotes(fn As FootnotesPart) As Integer
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
    Private Shared Function ProcessMainDoc(body As Body) As Integer
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
    Private Shared Function NoSpacesLength(text As String) As Integer
        'Убираем пробелы, неразрывные пробелы, табуляции
        Return text.Replace(" ", "") _
            .Replace(ChrW(&HA0), "") _
            .Replace(vbTab, "") _
            .Length
    End Function
End Class
