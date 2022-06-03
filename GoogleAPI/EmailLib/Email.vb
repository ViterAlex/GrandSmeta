Imports System.Net.Mail
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Xml
Imports S22.Imap

Public Class Email

#Region "Private Fields"

    Private _lastFolder As String
    Private account As Account
    Private imap As ImapClient

#End Region

#Region "Public Constructors"

    Public Sub New(account As Account)
        Me.account = account
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Папка, из которой было получено последнее письмо.
    ''' </summary>
    Public ReadOnly Property LastFolder() As String
        Get
            Return _lastFolder
        End Get
    End Property

#End Region

#Region "Private Methods"

    Private Function ReceiveLast() As String
        'Пытаемся подключиться
        Try
            imap = New ImapClient(account.Hostname, account.Port, account.Login, account.Password, ssl:=True)
        Catch ex As Exception
            Return ex.Message
        End Try

        If String.IsNullOrEmpty(account.Inbox) Then
            Return "Не указана папка ""Входящие"""
        End If

        If String.IsNullOrEmpty(account.JunkMail) Then
            Return "Не указана папка ""Спам"""
        End If

        Dim inboxMessage As Net.Mail.MailMessage
        Dim junkMessage As Net.Mail.MailMessage

        'Последнее письмо из Входящих
        Dim inboxUid = imap.Search(SearchCondition.All, account.Inbox).LastOrDefault()
        If inboxUid <> 0 Then
            inboxMessage = imap.GetMessage(inboxUid, False, account.Inbox)
        End If

        'Последнее письмо из Спама
        Dim junkUid = imap.Search(SearchCondition.All, account.JunkMail).LastOrDefault()
        If junkUid <> 0 Then
            junkMessage = imap.GetMessage(junkUid, False, account.JunkMail)
        End If

        If junkMessage Is Nothing Then
            _lastFolder = account.Inbox
            Return GetMessageText(inboxMessage)
        End If
        If inboxMessage Is Nothing Then
            _lastFolder = account.JunkMail
            Return GetMessageText(junkMessage)
        End If
        'Возвращаем то, которое пришло позже и запоминаем последнюю папку
        If inboxMessage.Date < junkMessage.Date Then
            _lastFolder = account.JunkMail
            Return GetMessageText(junkMessage)
        End If
        _lastFolder = account.Inbox
        Return GetMessageText(inboxMessage)
    End Function

    Private Function GetMessageText(m As MailMessage) As String
        If Not m.IsBodyHtml Then
            Return m.Body
        End If
        Dim result As String
        result = m.Body.Replace(vbCr, vbCrLf)
        result = result.Replace(vbTab, " ")
        result = Regex.Replace(result, "\\s+", " ")
        result = Regex.Replace(result, "<head.*?</head>", "", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        result = Regex.Replace(result, " < script.*?</script>", "", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        Dim sb = New StringBuilder(result)
        Dim oldWords = {"&nbsp;", "&amp;", "&quot;", "&lt;", "&gt;", "&reg;", "&copy;", "&bull;", "&trade;", "&#39;", "&zwnj;"}
        Dim newWords = {ChrW(160), "&", """", "<", ">", "®", "©", "•", "™", "'", "😭"}
        For i = 0 To oldWords.Length - 1
            sb.Replace(oldWords(i), newWords(i))
        Next
        sb.Replace("<br>", "\n<br>")
        sb.Replace("<br ", "\n<br ")
        sb.Replace("<p ", "\n<p ")
        result = Regex.Replace(sb.ToString(), "<[^>]*>", "")
        Return result
    End Function

#End Region

#Region "Public Methods"

    Public Shared Async Function Test(account As Account) As Task(Of Boolean)
        Return Await Task.Run(Function()
                                  Try
                                      Using client = New ImapClient(account.Hostname, account.Port, account.Login, account.Password, ssl:=True)
                                          Return client.Authed
                                      End Using
                                  Catch ex As Exception
                                      Return False
                                  End Try
                              End Function)
    End Function

    ''' <summary>
    '''     Получить последнее письмо.
    ''' </summary>
    ''' <returns>Возвращает тело письма или сообщение об ошибке.</returns>
    Public Async Function ReceiveLastAsync() As Task(Of String)
        Return Await Task.Run(Function()
                                  Return ReceiveLast()
                              End Function)
    End Function

#End Region

End Class