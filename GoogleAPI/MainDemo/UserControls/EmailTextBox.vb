Imports EmailLib

Public Class EmailTextBox
    Inherits TextBox

#Region "Private Fields"

    Private ReadOnly t As New Timer With {.Interval = 200}
    Private counter As Integer

#End Region

#Region "Public Constructors"

    Public Sub New()
        AddHandler t.Tick, AddressOf TimerTick
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

    Public Async Function LoadEmail(settings As Account) As Task
        [ReadOnly] = True
        Dim email = New Email(settings)
        t.Start()
        Text = Await email.ReceiveLastAsync()
        t.Stop()
        'Ждём окончания таймера
        While t.Enabled

        End While
        [ReadOnly] = False
        LastFolder = email.LastFolder
    End Function

#End Region

End Class