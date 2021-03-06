Imports System.ComponentModel
Imports System.Security
''' <summary>
'''     Класс для хранения учётных данных почты.
''' </summary>
<DefaultProperty("Name")>
Public Class Account

#Region "Public Properties"

    ''' <summary>
    '''     Адрес IMAP-сервера. DNS-имя или IP-адрес.
    ''' </summary>
    <DisplayName("Адрес сервера")>
    <Description("Адрес IMAP-сервера. DNS-имя или IP-адрес.")>
    <OrderedCategory("Подключение", 1, 4)>
    Public Property Hostname() As String

    ''' <summary>
    '''     Название папки «Входящие».
    ''' </summary>
    <DisplayName("Папка «Входящие»")>
    <Description("Название папки «Входящие».")>
    <OrderedCategory("Настройки получения", 3, 4)>
    <TypeConverter(GetType(EmailFolderConverter))>
    Public Property Inbox() As String

    ''' <summary>
    '''     Название папки «Спам».
    ''' </summary>
    <DisplayName("Папка «Спам»")>
    <Description("Название папки «Спам».")>
    <TypeConverter(GetType(EmailFolderConverter))>
    <OrderedCategory("Настройки получения", 3, 4)>
    Public Property JunkMail() As String

    ''' <summary>
    '''     Почтовый ящик пользователя.
    ''' </summary>
    <DisplayName("Почта")>
    <Description("Почтовый ящик пользователя.")>
    <OrderedCategory("Учётная запись", 2, 4)>
    Public Property Login() As String

    ''' <summary>
    '''     Имя учётной записи.
    ''' </summary>
    <DisplayName("Имя")>
    <Description("Имя учётной записи для удобства пользования")>
    <OrderedCategory("Разное", 0, 4)>
    Public Property Name() As String

    ''' <summary>
    '''     Пароль к почтовому ящику.
    ''' </summary>
    ''' <remarks>
    '''     Хранится в виде base64-строки, полученной из <see cref="SecureString"/>.
    ''' </remarks>
    <DisplayName("Пароль")>
    <Description("Пароль к учётной записи. При двухфакторной аутентификации нужно генерировать пароль приложения.")>
    <OrderedCategory("Учётная запись", 2, 4)>
    <TypeConverter(GetType(AccountPasswordConverter))>
    Public Property Password() As String

    ''' <summary>
    '''     Порт сервера для SSL-соединения. Не SSL не поддерживается.
    ''' </summary>
    <DisplayName("Порт")>
    <Description("Порт SSL.")>
    <OrderedCategory("Подключение", 1, 4)>
    Public Property Port() As Integer

    ''' <summary>
    '''     Флаг для сброса сохранённого списка папок.
    ''' </summary>
    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Advanced)>
    <DefaultValue(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property ResetFolders() As Boolean

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Создание независимой копии класса.
    ''' </summary>
    Public Function Clone() As Account
        Return DirectCast(Me.MemberwiseClone(), Account)
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj.GetType IsNot GetType(Account) Then
            Return False
        End If
        Dim s = DirectCast(obj, Account)
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

#End Region

End Class