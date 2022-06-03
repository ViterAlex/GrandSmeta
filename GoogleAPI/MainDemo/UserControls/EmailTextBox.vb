Imports EmailLib
''' <summary>
'''     Контрол для показа содержимого письма и процесса его загрузки.
''' </summary>
Public Class EmailTextBox
    Inherits TextBox

#Region "Private Fields"

    Private ReadOnly aminationTimer As New Timer With {.Interval = 200}
    Private counter As Integer

#End Region

#Region "Public Constructors"

    Public Sub New()
        AddHandler aminationTimer.Tick, AddressOf TimerTick
        Font = New Font(Font.FontFamily, 12)
        Dock = DockStyle.Fill
        Margin = New Padding(0)
        Multiline = True
        ScrollBars = ScrollBars.Both
    End Sub

#End Region

#Region "Public Properties"

    Public Property LastFolder() As String

#End Region

#Region "Private Methods"

    Private Sub TimerTick(sender As Object, e As EventArgs)
        Text = $"Загружается{New String("."c, counter Mod 4)}"
        counter += 1
    End Sub

#End Region

#Region "Public Methods"

    Public Async Function LoadEmail(account As Account) As Task
        [ReadOnly] = True
        Dim email = New Email(account)
        aminationTimer.Start()
        Text = Await email.ReceiveLastAsync()
        aminationTimer.Stop()
        'Ждём окончания таймера
        While aminationTimer.Enabled

        End While
        [ReadOnly] = False
        LastFolder = email.LastFolder
    End Function

#End Region

End Class