Imports Google.Apis.Script.v1.Data
Imports ScriptFile = Google.Apis.Script.v1.Data.File
Partial Public Class GoogleAPI

#Region "Fields"

    Private loadedScriptFiles As IList(Of ScriptFile)

#End Region

#Region "Public Methods"

    ''' <summary>
    ''' Получить функции из файла исходного кода.
    ''' </summary>
    ''' <param name="file">Ссылка на файл исходного кода.</param>
    Public Function GetFunctions(file As ScriptFile) As IList(Of GoogleAppsScriptTypeFunction)
        If file.FunctionSet.Values IsNot Nothing Then
            Return file.FunctionSet.Values
        End If
        Return New List(Of GoogleAppsScriptTypeFunction)
    End Function

    ''' <summary>
    ''' Получить файлы с исходным кодом из проекта
    ''' </summary>
    ''' <param name="scriptId">ID проекта скриптов</param>
    Public Function GetSourceCodeFiles(scriptId) As IList(Of ScriptInfo)

        Dim req = scriptService.Projects.GetContent(scriptId)
        Dim resp = req.Execute()
        loadedScriptFiles = resp.Files
        Return loadedScriptFiles.Select(Function(f)
                                            Return New ScriptInfo With {
                                     .Name = f.Name,
                                     .File = f
                                     }
                                        End Function).ToList()
    End Function

    ''' <summary>
    ''' Получить версии приложении для проекта
    ''' </summary>
    Public Function GetVersions(scriptId As String) As IList(Of Version)
        Dim req = scriptService.Projects.Versions.List(scriptId)
        Dim resp = req.Execute()
        Return resp.Versions
    End Function

    ''' <summary>
    ''' Запуск указанного скрипта
    ''' </summary>
    ''' <param name="f">Имя функции.</param>
    ''' <param name="param">Параметры функции.</param>
    Public Function RunScript(f As String, scriptId As String, ParamArray param() As String) As Boolean

        Dim body = New ExecutionRequest With {
            .[Function] = f,
            .Parameters = param,
            .DevMode = True
        }
        Dim req = scriptService.Scripts.Run(body, scriptId)
        Dim resp = req.Execute()
        Return resp.Done
    End Function

    ''' <summary>
    ''' Обновление исходных файлов проекта.
    ''' </summary>
    ''' <param name="scriptId">ID проекта скриптов</param>
    ''' <param name="sourceFileName">Имя файла, который нужно обновить.</param>
    ''' <param name="sourceCode">Исходный код файла.</param>
    Public Sub UpdateSourceFiles(scriptId As String, sourceFileName As String, sourceCode As String)
        If loadedScriptFiles Is Nothing OrElse loadedScriptFiles.Count = 0 Then
            Return
        End If
        For Each file In loadedScriptFiles
            If file.Name = sourceFileName Then
                file.Source = sourceCode
                Exit For
            End If
        Next

        Dim body = New Content With {
        .Files = loadedScriptFiles,
        .ScriptId = scriptId
        }
        Dim req = scriptService.Projects.UpdateContent(body, scriptId)
        Dim resp = req.Execute()
    End Sub

#End Region

End Class