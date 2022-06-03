Imports System.ComponentModel
Imports System.Windows.Forms
Imports S22.Imap
''' <summary>
'''     Конвертер для выбора папок в <see cref="PropertyGrid"/>.
''' </summary>
''' <remarks>
'''     Конвертер нужен, чтобы пользователь мог выбрать только реальные папки, 
'''     существующие в почтовом ящике.
''' </remarks>
Public Class EmailFolderConverter
    Inherits StringConverter

#Region "Private Fields"

    Private Shared cache As Dictionary(Of Account, List(Of String)) = New Dictionary(Of Account, List(Of String))

#End Region

#Region "Public Methods"

    Public Overrides Function GetStandardValues(context As ITypeDescriptorContext) As StandardValuesCollection

        Dim account = DirectCast(context.Instance, Account)
        Dim result = New List(Of String)
        If account Is Nothing Then
            result.Add("Невозможно получить контекст.")
            Return New StandardValuesCollection(result)
        End If
        'Если редактируется тот же объект настроек
        If cache.ContainsKey(account) Then
            'Если нужно очищать папки
            If account.ResetFolders Then
                cache.Remove(account)
                account.ResetFolders = False
            Else
                'Пробуем использовать уже загруженные ящики
                Return New StandardValuesCollection(cache(account))
            End If
        End If
        'Настройки изменились. Подключаемся заново

        If String.IsNullOrEmpty(account.Hostname) Then
            result.Add("Не указан сервер IMAP.")
        End If
        If String.IsNullOrEmpty(account.Login) Then
            result.Add("Не указан адрес почты.")
        End If
        If String.IsNullOrEmpty(account.Password) Then
            result.Add("Не указан пароль.")
        End If
        If account.Port = 0 Then
            result.Add("Не указан порт")
        End If
        If result.Count > 0 Then
            Return New StandardValuesCollection(result)
        End If

        Try
            Dim pass = account.Password.FromBase64().ToUnsecure()
            Using imap As New ImapClient(account.Hostname, account.Port, account.Login, pass, ssl:=True)
                If Not imap.Authed Then
                    result.Add("Невозможно авторизоваться")
                    Return New StandardValuesCollection(result)
                End If
                cache.Add(account, imap.ListMailboxes().ToList())
            End Using
        Catch ex As Exception
            result.Add(ex.Message)
            Return New StandardValuesCollection(result)
        End Try
        Return New StandardValuesCollection(cache(account))
    End Function

    Public Overrides Function GetStandardValuesExclusive(context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overrides Function GetStandardValuesSupported(context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

#End Region

End Class