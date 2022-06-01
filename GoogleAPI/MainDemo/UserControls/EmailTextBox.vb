Imports EmailLib

Public Class EmailTextBox
    Inherits TextBox
    Private ReadOnly t As New Timer With {.Interval = 200}
    Public Property LastFolder() As String
    Private counter As Integer

    Public Sub New()
        AddHandler t.Tick, AddressOf TimerTick
        Font = New Font(Font.FontFamily, 12)
        Dock = DockStyle.Fill
        Margin = New Padding(0)
        Multiline = True
        ScrollBars = ScrollBars.Both
    End Sub

    Private Sub TimerTick(sender As Object, e As EventArgs)
        Text = $"Загружается{New String("."c, counter Mod 4)}"
        counter += 1
    End Sub

    Public Async Function LoadEmail(settings As EmailSettings) As Task
        [ReadOnly] = True
        Dim email = New Email(settings)
        t.Start()
        Text = Await email.ReceiveLastAsync()
        t.Stop()
        While t.Enabled

        End While
        [ReadOnly] = False
        LastFolder = email.LastFolder
    End Function
End Class
