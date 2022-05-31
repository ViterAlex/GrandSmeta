Imports EmailLib

Public Class EmailSettingsForm
    Private _settings As EmailSettings

    Public Property Settings() As EmailSettings
        Get
            Return _settings
        End Get
        Set
            If Value Is Nothing Then
                _settings = New EmailSettings()
                Return
            End If
            _settings = Value.Clone()
        End Set
    End Property

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        Dim ts = PropertyGrid1.Controls.OfType(Of ToolStrip)().FirstOrDefault()
        If ts IsNot Nothing Then
            'Скрываем стандартные кнопки
            For Each ctrl As ToolStripItem In ts.Items
                ctrl.Visible = False
            Next
            'Добавляем свою
            Dim btn = New ToolStripButton("Очистить папки", Nothing, AddressOf ClearFolders) With {
                .Name = "ResetFolders"}
            ts.Items.Add(btn)
        End If
        PropertyGrid1.SelectedObject = _settings
    End Sub

    Private Sub ClearFolders(sender As Object, e As EventArgs)
        _settings.ResetFolders = True
        _settings.Inbox = String.Empty
        _settings.JunkMail = String.Empty
        PropertyGrid1.Invalidate()
    End Sub
End Class