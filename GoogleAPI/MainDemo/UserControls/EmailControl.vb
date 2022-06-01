Imports EmailLib

Public Class EmailControl
    Private email As Email
    Private emailSettings As New EmailSettings
    'Таймер анимации загрузки
    Private ReadOnly t As New Timer() With {.Interval = 200}
    Private counter As Integer

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        emailSettings = My.Settings.EmailSettings
        AddHandler t.Tick, AddressOf TimerTick
    End Sub

    Private Sub TimerTick(sender As Object, e As EventArgs)
        'Добавляем точки анимации
        txtEmailContent.Text = $"Загружается{New String("."c, counter Mod 4)}"
        counter += 1
    End Sub

    Private Async Sub btnGetLastEmail_Click(sender As Object, e As EventArgs) Handles btnGetLastEmail.Click
        email = New Email(emailSettings)

        txtEmailContent.ReadOnly = True
        t.Start()
        Dim text = Await email.ReceiveLastAsync()
        t.Stop()
        While t.Enabled
            'Ждём пока таймер выключится
        End While
        txtEmailContent.Text = text
        txtEmailContent.ReadOnly = False

        If email.LastFolder = emailSettings.Inbox Then
            lblFolder.ForeColor = Color.DarkGreen
        Else
            lblFolder.ForeColor = Color.DarkRed
        End If
        lblFolder.Text = email.LastFolder
        lblFolder.Visible = True
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        'Показываем диалог редактирования настроек почты
        Using f As New EmailSettingsForm()
            f.Settings = emailSettings.Clone()
            If f.ShowDialog() <> DialogResult.OK Then
                Return
            End If
            'Сохраняем настройки
            emailSettings = f.Settings
            My.Settings.EmailSettings = emailSettings
            My.Settings.Save()
        End Using
    End Sub
End Class
