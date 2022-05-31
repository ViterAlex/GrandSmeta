Imports System.ComponentModel
Imports System.Drawing.Design

Public Class EmailSettings
    <DisplayName("Адрес сервера")>
    Public Property Hostname() As String
    <DisplayName("Порт")>
    Public Property Port() As Integer
    <DisplayName("Почта")>
    Public Property Login() As String
    <DisplayName("Пароль")>
    Public Property Password() As String
    <DisplayName("Папка ""Входящие""")>
    <TypeConverter(GetType(EmailFolderConverter))>
    Public Property Inbox() As String
    <DisplayName("Папка ""Спам""")>
    <TypeConverter(GetType(EmailFolderConverter))>
    Public Property JunkMail() As String
    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Advanced)>
    Public Property ResetFolders() As Boolean

    Public Function Clone() As EmailSettings
        Return DirectCast(Me.MemberwiseClone(), EmailSettings)
    End Function
End Class
