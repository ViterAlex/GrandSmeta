Imports EmailLib

Public Class EmailSettingsForm

    Public Property Settings() As EmailSettings
    Private ReadOnly btnClear = New ToolStripButton("Очистить папки", Nothing, AddressOf ClearFolders)
    Private ReadOnly btnTest As New ToolStripButton("Тест", Nothing, AddressOf TestConnection) With {
        .Alignment = ToolStripItemAlignment.Right
    }
    Private ReadOnly lblTest As New ToolStripLabel(String.Empty) With {
        .Alignment = ToolStripItemAlignment.Right
    }

    Private Async Sub TestConnection(sender As Object, e As EventArgs)
        lblTest.Text = "⏱"
        lblTest.ForeColor = Color.Black
        btnTest.Enabled = False
        If Await Email.Test(Settings) Then
            lblTest.Text = "✔"
            lblTest.ForeColor = Color.DarkGreen
        Else
            lblTest.Text = "✖"
            lblTest.ForeColor = Color.DarkRed
        End If
        btnTest.Enabled = True
    End Sub

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
            ts.Items.AddRange({btnClear, lblTest, btnTest})
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

    Private Sub EmailPropertyGrid_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles EmailPropertyGrid.PropertyValueChanged
        lblTest.Text = String.Empty
    End Sub
End Class