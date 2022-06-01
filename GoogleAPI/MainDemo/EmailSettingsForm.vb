Imports EmailLib

Public Class EmailSettingsForm

    Public Property Settings() As EmailSettings

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        'Скрыть стандартные кнопки PropertyGrid. Добавить свою для сброса списка папок
        Dim ts = EmailPropertyGrid.Controls.OfType(Of ToolStrip)().FirstOrDefault()
        If ts IsNot Nothing Then
            'Скрываем стандартные кнопки
            For Each ctrl As ToolStripItem In ts.Items
                ctrl.Visible = False
            Next
            'Добавляем свою
            Dim btn = New ToolStripButton("Очистить папки", Nothing, AddressOf ClearFolders)
            ts.Items.Add(btn)
        End If
        EmailPropertyGrid.SelectedObject = Settings
    End Sub

    Private Sub ClearFolders(sender As Object, e As EventArgs)
        Settings.ResetFolders = True
        Settings.Inbox = String.Empty
        Settings.JunkMail = String.Empty
        EmailPropertyGrid.SelectedObject = Nothing
        EmailPropertyGrid.SelectedObject = Settings
    End Sub
End Class