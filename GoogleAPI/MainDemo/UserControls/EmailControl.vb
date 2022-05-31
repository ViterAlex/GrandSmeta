Imports EmailLib

Public Class EmailControl
    Private email As Email
    Private emailSettings As New EmailSettings

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        emailSettings = My.Settings.EmailSettings
        'emailSettings = New EmailSettings With {
        '    .Login = "viter.alex@gmail.com",
        '    .Password = "gvqyvgawqmeztrct",
        '    .Port = 993,
        '    .Hostname = "imap.gmail.com"
        '}
    End Sub

    Private Async Sub btnGetLastEmail_Click(sender As Object, e As EventArgs) Handles btnGetLastEmail.Click
        email = New Email(emailSettings)
        txtEmailContent.Text = Await email.ReceiveLastAsync()
        If email.LastFolder = emailSettings.Inbox Then
            lblFolder.Text = "Входящие"
            lblFolder.ForeColor = Color.DarkGreen
        Else
            lblFolder.Text = "Спам"
            lblFolder.ForeColor = Color.DarkRed
        End If
        lblFolder.Visible = True
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Using f As New EmailSettingsForm()
            f.Settings = emailSettings
            If f.ShowDialog() <> DialogResult.OK Then
                Return
            End If
            emailSettings = f.Settings
            My.Settings.EmailSettings = emailSettings
            My.Settings.Save()
        End Using
    End Sub
End Class
