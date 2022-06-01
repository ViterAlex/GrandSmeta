Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public Class EmailSettings
    ''' <summary>
    '''     Адрес IMAP-сервера. DNS-имя или IP-адрес.
    ''' </summary>
    <DisplayName("Адрес сервера")>
    <Description("Адрес IMAP-сервера.")>
    Public Property Hostname() As String
    ''' <summary>
    '''     Порт сервера для SSL-соединения. Не SSL не поддерживается.
    ''' </summary>
    <DisplayName("Порт")>
    <Description("Порт SSL.")>
    Public Property Port() As Integer
    ''' <summary>
    '''     Почтовый ящик пользователя.
    ''' </summary>
    <DisplayName("Почта")>
    <Description("Почтовый ящик пользователя.")>
    Public Property Login() As String
    ''' <summary>
    '''     Пароль к почтовому ящику.
    ''' </summary>
    <DisplayName("Пароль")>
    <Description("Пароль к учётной записи. При двухфакторной аутентификации нужно генерировать пароль приложения.")>
    Public Property Password() As String
    ''' <summary>
    '''     Название папки «Входящие».
    ''' </summary>
    <DisplayName("Папка ""Входящие""")>
    <Description("Название папки «Входящие».")>
    <TypeConverter(GetType(EmailFolderConverter))>
    Public Property Inbox() As String
    ''' <summary>
    '''     Название папки «Спам».
    ''' </summary>
    <DisplayName("Папка ""Спам""")>
    <Description("Название папки «Спам».")>
    <TypeConverter(GetType(EmailFolderConverter))>
    Public Property JunkMail() As String
    ''' <summary>
    '''     Флаг для сброса сохранённого списка папок.
    ''' </summary>
    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Advanced)>
    <DefaultValue(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property ResetFolders() As Boolean
    ''' <summary>
    '''     Имя учётной записи.
    ''' </summary>
    <DisplayName("Имя")>
    <Description("Имя учётной записи для удобства пользования")>
    Public Property Name() As String

    ''' <summary>
    '''     Создание независимой копии класса.
    ''' </summary>
    Public Function Clone() As EmailSettings
        Return DirectCast(Me.MemberwiseClone(), EmailSettings)
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj.GetType IsNot GetType(EmailSettings) Then
            Return False
        End If
        Dim s = DirectCast(obj, EmailSettings)
        Return s.Hostname = Hostname AndAlso
            s.Port = Port AndAlso
            s.Name = Name AndAlso
            s.Login = Login AndAlso
            s.Password = Password AndAlso
            s.Inbox = Inbox AndAlso
            s.JunkMail = JunkMail
    End Function

    Public Overrides Function ToString() As String
        Return $"{Name}:{Login}"
    End Function
End Class
