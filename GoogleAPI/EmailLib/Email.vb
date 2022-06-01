Imports S22.Imap

Public Class Email
    Private imap As ImapClient
    Private settings As EmailSettings
    Private _lastFolder As String
    ''' <summary>
    '''     Папка, из которой было получено последнее письмо.
    ''' </summary>
    Public ReadOnly Property LastFolder() As String
        Get
            Return _lastFolder
        End Get
    End Property

    Public Sub New(settings As EmailSettings)
        Me.settings = settings
    End Sub

    ''' <summary>
    '''     Получить последнее письмо.
    ''' </summary>
    ''' <returns>Возвращает тело письма или сообщение об ошибке.</returns>
    Public Async Function ReceiveLastAsync() As Task(Of String)
        Return Await Task.Run(Function()
                                  Return ReceiveLast()
                              End Function)
    End Function

    Private Function ReceiveLast() As String
        'Пытаемся подключиться
        Try
            imap = New ImapClient(settings.Hostname, settings.Port, settings.Login, settings.Password, ssl:=True)
        Catch ex As Exception
            Return ex.Message
        End Try

        If String.IsNullOrEmpty(settings.Inbox) Then
            Return "Не указана папка ""Входящие"""
        End If

        If String.IsNullOrEmpty(settings.JunkMail) Then
            Return "Не указана папка ""Спам"""
        End If

        Dim inboxMessage As Net.Mail.MailMessage
        Dim junkMessage As Net.Mail.MailMessage

        'Последнее письмо из Входящих
        Dim inboxUid = imap.Search(SearchCondition.All, settings.Inbox).LastOrDefault()
        If inboxUid <> 0 Then
            inboxMessage = imap.GetMessage(inboxUid, False, settings.Inbox)
        End If

        'Последнее письмо из Спама
        Dim junkUid = imap.Search(SearchCondition.All, settings.JunkMail).LastOrDefault()
        If junkUid <> 0 Then
            junkMessage = imap.GetMessage(junkUid, False, settings.JunkMail)
        End If

        If junkMessage Is Nothing Then
            _lastFolder = settings.Inbox
            Return inboxMessage.Body
        End If
        If inboxMessage Is Nothing Then
            _lastFolder = settings.JunkMail
            Return junkMessage.Body
        End If
        'Возвращаем то, которое пришло позже и запоминаем последнюю папку
        If inboxMessage.Date < junkMessage.Date Then
            _lastFolder = settings.JunkMail
            Return junkMessage.Body
        End If
        _lastFolder = settings.Inbox
        Return inboxMessage.Body
    End Function

    Public Shared Async Function Test(settings As EmailSettings) As Task(Of Boolean)
        Return Await Task.Run(Function()
                                  Try
                                      Using client = New ImapClient(settings.Hostname, settings.Port, settings.Login, settings.Password, ssl:=True)
                                          Return client.Authed
                                      End Using
                                  Catch ex As Exception
                                      Return False
                                  End Try
                              End Function)
    End Function
End Class
