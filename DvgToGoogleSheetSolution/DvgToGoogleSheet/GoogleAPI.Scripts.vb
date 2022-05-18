Imports Google.Apis.Script.v1.Data
Imports ScriptFile = Google.Apis.Script.v1.Data.File

Public Class GoogleAPI

#Region "Internal Methods"

    ''' <summary>
    ''' Получить функции из файла исходного кода
    ''' </summary>
    ''' <param name="file">Ссылка на файл исходного кода</param>
    Friend Function GetFunctions(file As ScriptFile) As IList(Of GoogleAppsScriptTypeFunction)
        If file.FunctionSet.Values IsNot Nothing Then
            Return file.FunctionSet.Values
        End If
        Return New List(Of GoogleAppsScriptTypeFunction)
    End Function

#End Region

#Region "Public Methods"

    ''' <summary>
    ''' Получить файлы с исходным кодом из проекта
    ''' </summary>
    ''' <param name="scriptId">ID проекта скриптов</param>
    Public Function GetSourceCodeFiles(scriptId As String) As IList(Of ScriptInfo)
        Dim req = scriptService.Projects.GetContent(scriptId)
        Dim resp = req.Execute()
        Return resp.Files.Select(Function(f)
                                     Return New ScriptInfo With {.Name = f.Name, .File = f}
                                 End Function).ToList()
        'resp.Files.
    End Function

    ''' <summary>
    ''' Получить версии приложении для проекта
    ''' </summary>
    ''' <param name="scriptId">ID проекта скриптов</param>
    Public Function GetVersions(scriptId As String) As IList(Of Version)
        Dim req = scriptService.Projects.Versions.List(scriptId)
        Dim resp = req.Execute()
        Return resp.Versions
    End Function

    ''' <summary>
    ''' Запуск указанного скрипта
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="param"></param>
    Public Function RunScript(v As Version, f As String, id As String, ParamArray param() As String) As Boolean
        'Получить текущию версию
        Dim deplReq = scriptService.Projects.Deployments.List(id)
        Dim deplResp = deplReq.Execute()

        Dim deploy = deplResp.Deployments.First(Function(dep)
                                                    Return dep.DeploymentConfig.VersionNumber.HasValue
                                                End Function)
        If deploy Is Nothing Then
            Return False
        End If

        Dim config = New UpdateDeploymentRequest With {
        .DeploymentConfig = New DeploymentConfig With {
        .Description = v.Description,
        .ManifestFileName = deploy.DeploymentConfig.ManifestFileName,
        .ScriptId = id,
        .VersionNumber = v.VersionNumber
                }
        }

        Dim deplUpdateReq = scriptService.Projects.Deployments.Update(config, id, deploy.DeploymentId)
        Dim deplUpdateResp = deplUpdateReq.Execute()

        Dim exreq = New ExecutionRequest With {
            .[Function] = f,
            .Parameters = param
        }

        Dim req = scriptService.Scripts.Run(exreq, deploy.DeploymentId)
        Dim resp = req.Execute()
        Return resp.Done
    End Function

#End Region

End Class