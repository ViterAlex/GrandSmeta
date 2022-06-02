Imports EmailLib

Public Class EmailControl

#Region "Private Fields"

    Private accounts As Accounts

#End Region

#Region "Private Methods"

    Private Async Sub btnGetLastEmail_Click(sender As Object, e As EventArgs) Handles btnGetLastEmail.Click
        Dim tasks As New List(Of Task)
        EmailsTabControl.TabPages.Clear()
        For Each s In accounts
            tasks.Add(Task.Run(Sub()
                                   EmailsTabControl.Invoke(Sub()
                                                               GetLastEmail(s)
                                                           End Sub)
                               End Sub))
        Next
        Await Task.WhenAll(tasks)
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        'Показываем диалог редактирования настроек почты
        Using f As New EmailSettingsForm()
            If accounts IsNot Nothing AndAlso accounts.Count > 0 Then
                f.Accounts = accounts
            Else
                f.Accounts = New Accounts()
            End If
            If f.ShowDialog() <> DialogResult.OK Then
                Return
            End If
            'Сохраняем настройки
            accounts = f.Accounts
            My.Settings.Accounts = accounts
            My.Settings.Save()
        End Using
    End Sub

    Private Async Sub GetLastEmail(setting As Account)
        EmailsTabControl.TabPages.Add(setting.Name)
        Dim tab = EmailsTabControl.TabPages.Item(EmailsTabControl.TabPages.Count - 1)
        Dim emailTextBox = New EmailTextBox()
        tab.Controls.Add(emailTextBox)
        Await emailTextBox.LoadEmail(setting)
        tab.Text &= $" ({emailTextBox.LastFolder})"
    End Sub

#End Region

#Region "Protected Methods"

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        accounts = My.Settings.Accounts
    End Sub

#End Region

End Class