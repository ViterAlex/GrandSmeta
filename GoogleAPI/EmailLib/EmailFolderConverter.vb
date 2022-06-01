Imports System.ComponentModel
Imports S22.Imap

Public Class EmailFolderConverter
    Inherits StringConverter

#Region "Private Fields"

    'Для хранения уже загруженных папок
    Private Shared mailboxes As List(Of String)

    'Для хранения старых настроек
    Private Shared oldSettings As EmailSettings

#End Region

#Region "Public Methods"

    Public Overrides Function GetStandardValues(context As ITypeDescriptorContext) As StandardValuesCollection

        Dim settings = DirectCast(context.Instance, EmailSettings)
        Dim result = New List(Of String)
        If settings Is Nothing Then
            result.Add("Невозможно получить контекст")
            Return New StandardValuesCollection(result)
        End If

        'Если настройки не изменились с последнего вызова
        If oldSettings IsNot Nothing AndAlso
        oldSettings.Login = settings.Login AndAlso
        oldSettings.Password = settings.Password AndAlso
        oldSettings.Hostname = settings.Hostname AndAlso
        oldSettings.Port = settings.Port Then
            If settings.ResetFolders Then
                mailboxes.Clear()
                settings.ResetFolders = False
            End If
            'Пробуем использовать уже загруженные ящики
            If mailboxes IsNot Nothing AndAlso mailboxes.Count > 0 Then
                Return New StandardValuesCollection(mailboxes)
            End If

        End If

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
        'Настройки изменились. Подключаемся заново
        Try

            Using imap As New ImapClient(settings.Hostname, settings.Port, settings.Login, settings.Password, ssl:=True)
                If Not imap.Authed Then
                    result.Add("Невозможно авторизоваться")
                    Return New StandardValuesCollection(result)
                End If
                mailboxes = imap.ListMailboxes().ToList()
                oldSettings = settings.Clone()
            End Using
        Catch ex As Exception
            result.Add(ex.Message)
            Return New StandardValuesCollection(result)
        End Try
        Return New StandardValuesCollection(mailboxes)
    End Function

    Public Overrides Function GetStandardValuesExclusive(context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overrides Function GetStandardValuesSupported(context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

#End Region

End Class