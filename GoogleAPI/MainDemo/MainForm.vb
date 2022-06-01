Imports System.IO
Imports SheetsAndScriptsLib

Public Class MainForm

#Region "Fields"

    Private Const CREDENTIALS As String = "cred.json"

#End Region

#Region "Private Methods"

    'Подключение
    Private Async Sub btnConnect_Click(sender As Object, e As EventArgs) Handles ConnectToolStripMenuItem.Click
        If Not File.Exists(CREDENTIALS) Then
            MessageBox.Show($"File '{CREDENTIALS}' not found. Place it next to executable!", "Google API", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Dim token = File.ReadAllText(CREDENTIALS)
        Dim gapi = New GoogleAPI(token)
        Dim result = Await gapi.Connect()
        If result Then
            lblConnectionStatus.Text = "Connected"
        End If
        ScriptControl1.Connect(gapi)
        SheetsControl1.Connect(gapi)
    End Sub

    'Смена надписи на метке статуса подключения
    Private Sub lblConnectionStatus_TextChanged(sender As Object, e As EventArgs) Handles lblConnectionStatus.TextChanged
        lblConnectionStatus.Image = DirectCast(My.Resources.ResourceManager.GetObject(lblConnectionStatus.Text), Bitmap)
    End Sub

#End Region

#Region "Protected Methods"

    'Начальное состояние формы при загрузке
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        lblConnectionStatus.Text = "Disconnected"
        CheckSettingsVersion()
    End Sub

    Private Sub CheckSettingsVersion()
        Dim s = New My.MySettings()
        Dim v = My.Application.Info.Version
        If Not String.Equals(s.Version, $"{v.Major}.{v.Minor}.{v.Build}") Then
            s.Upgrade()
            s.Version = $"{v.Major}.{v.Minor}.{v.Build}"
            s.Save()
        End If
    End Sub

#End Region

End Class