Imports EmailLib

Public Class EmailControl
    Private settings As List(Of EmailSettings)

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        settings = My.Settings.EmailSettingsList
    End Sub

    Private Async Sub btnGetLastEmail_Click(sender As Object, e As EventArgs) Handles btnGetLastEmail.Click
        Dim tasks As New List(Of Task)
        EmailsTabControl.TabPages.Clear()
        For Each s In settings
            tasks.Add(Task.Run(Sub()
                                   EmailsTabControl.Invoke(Sub()
                                                               GetLastEmail(s)
                                                           End Sub)
                               End Sub))
        Next
        Await Task.WhenAll(tasks)
    End Sub

    Private Async Sub GetLastEmail(setting As EmailSettings)
        EmailsTabControl.TabPages.Add(setting.Name)
        Dim tab = EmailsTabControl.TabPages.Item(EmailsTabControl.TabPages.Count - 1)
        Dim emailTextBox = New EmailTextBox()
        tab.Controls.Add(emailTextBox)
        Await emailTextBox.LoadEmail(setting)
        tab.Text &= $" ({emailTextBox.LastFolder})"
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        'Показываем диалог редактирования настроек почты
        Using f As New EmailSettingsForm()
            If settings IsNot Nothing AndAlso settings.Count > 0 Then
                f.Settings = settings.ToList()
            Else
                f.Settings = New List(Of EmailSettings)
            End If
            If f.ShowDialog() <> DialogResult.OK Then
                Return
            End If
            'Сохраняем настройки
            settings = f.Settings
            My.Settings.EmailSettingsList = settings
            My.Settings.Save()
        End Using
    End Sub
End Class
