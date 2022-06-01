Imports System.ComponentModel
Imports S22.Imap

Public Class EmailFolderConverter
    Inherits StringConverter

#Region "Private Fields"
    Private Shared cache As Dictionary(Of EmailSettings, List(Of String)) = New Dictionary(Of EmailSettings, List(Of String))
#End Region

#Region "Public Methods"

    Public Overrides Function GetStandardValues(context As ITypeDescriptorContext) As StandardValuesCollection

        Dim settings = DirectCast(context.Instance, EmailSettings)
        Dim result = New List(Of String)
        If settings Is Nothing Then
            result.Add("Невозможно получить контекст")
            Return New StandardValuesCollection(result)
        End If
        'Если редактируется тот же объект настроек
        If cache.ContainsKey(settings) Then
            'Если нужно очищать папки
            If settings.ResetFolders Then
                cache.Remove(settings)
                settings.ResetFolders = False
            Else
                'Пробуем использовать уже загруженные ящики
                Return New StandardValuesCollection(cache(settings))
            End If
        End If
        'Настройки изменились. Подключаемся заново

        If String.IsNullOrEmpty(settings.Hostname) Then
            result.Add("Не указан сервер IMAP")
        End If
        If String.IsNullOrEmpty(settings.Login) Then
            result.Add("Не указан адрес почты")
        End If
        If String.IsNullOrEmpty(settings.Password) Then
            result.Add("Не указан пароль")
        End If
        If settings.Port = 0 Then
            result.Add("Не указан порт")
        End If
        If result.Count > 0 Then
            Return New StandardValuesCollection(result)
        End If
        Try

            Using imap As New ImapClient(settings.Hostname, settings.Port, settings.Login, settings.Password, ssl:=True)
                If Not imap.Authed Then
                    result.Add("Невозможно авторизоваться")
                    Return New StandardValuesCollection(result)
                End If
                cache.Add(settings, imap.ListMailboxes().ToList())
            End Using
        Catch ex As Exception
            result.Add(ex.Message)
            Return New StandardValuesCollection(result)
        End Try
        Return New StandardValuesCollection(cache(settings))
    End Function

    Public Overrides Function GetStandardValuesExclusive(context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overrides Function GetStandardValuesSupported(context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

#End Region

End Class