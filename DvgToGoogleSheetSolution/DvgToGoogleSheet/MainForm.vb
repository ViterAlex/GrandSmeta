Imports System.IO

Public Class MainForm

#Region "Fields"

    Private Const CREDENTIALS As String = "cred.json"
    Private gapi As GoogleAPI

#End Region

#Region "Private Methods"

    Private Async Sub btnConnect_Click(sender As Object, e As EventArgs) Handles ConnectToolStripMenuItem.Click
        If Not File.Exists(CREDENTIALS) Then
            MessageBox.Show($"File '{CREDENTIALS}' not found. Place it next to executable!", "Google API", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Dim token = File.ReadAllText(CREDENTIALS)
        gapi = New GoogleAPI(token)
        Dim result = Await gapi.Connect()
        cmbSpreadSheets.Enabled = result
        lblTwo.Enabled = result
        If result Then
            lblConnectionStatus.Text = "Connected"
            cmbSpreadSheets.DisplayMember = "Name"
            cmbSpreadSheets.ValueMember = "Id"
            cmbSpreadSheets.DataSource = gapi.GetSpreadsheets()
        End If

    End Sub

    Private Sub btnFillIn_Click(sender As Object, e As EventArgs) Handles btnFillIn.Click
        gapi.Export(dgvSpreadSheet, cmbSpreadSheets.SelectedValue, $"{cmbSheets.SelectedValue.Properties.Title}!A1")
    End Sub

    Private Sub btnRead_Click(sender As Object, e As EventArgs) Handles btnRead.Click
        'Очищаем
        dgvSpreadSheet.Columns.Clear()
        'Получаем значения
        Dim values = gapi.Import(cmbSpreadSheets.SelectedValue, $"{cmbSheets.SelectedValue.Properties.Title}")
        'Считаем количество столбцов
        Dim cols = values.Max(Function(l)
                                  Return l.Count
                              End Function)
        'Добавляем столбцы
        For j = 0 To cols - 1
            dgvSpreadSheet.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = $"{ChrW(j + 65)}"})
        Next
        'Добавляем значения
        For i = 0 To values.Count - 1
            dgvSpreadSheet.Rows.Add()
            For j = 0 To values(i).Count - 1
                dgvSpreadSheet.Rows(i).Cells(j).Value = values(i)(j)
            Next
        Next
    End Sub

    Private Sub cmbSheets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSheets.SelectedIndexChanged
        lblTwo.Enabled = True
        btnFillIn.Enabled = True
        btnRead.Enabled = True
    End Sub

    Private Sub cmbSpreadSheets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSpreadSheets.SelectedIndexChanged
        cmbSheets.Enabled = True
        lblTwo.Enabled = True
        lblThree.Enabled = True
        cmbSheets.DisplayMember = "Title"
        cmbSheets.ValueMember = "Sheet"
        cmbSheets.DataSource = gapi.GetSheets(cmbSpreadSheets.SelectedValue.ToString())
    End Sub

    'Заполнение DataGridView случайными данными
    Private Sub FillDataGridView()
        Dim rnd As New Random()
        Dim cols = rnd.Next(10, 20)
        Dim rows = rnd.Next(30, 50)
        For i = 0 To cols - 1
            dgvSpreadSheet.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = $"{ChrW(i + 65)}"})
        Next
        For i = 0 To rows - 1
            dgvSpreadSheet.Rows.Add()
            For Each cell As DataGridViewCell In dgvSpreadSheet.Rows(i).Cells
                cell.Value = rnd.Next(100, 999)
            Next
        Next
    End Sub

    Private Sub lblConnectionStatus_TextChanged(sender As Object, e As EventArgs) Handles lblConnectionStatus.TextChanged
        lblConnectionStatus.Image = DirectCast(My.Resources.ResourceManager.GetObject(lblConnectionStatus.Text), Bitmap)
    End Sub

#End Region

#Region "Protected Methods"

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        lblConnectionStatus.Text = "Disconnected"
        FillDataGridView()
    End Sub

#End Region

End Class