Imports SheetsAndScriptsLib

Public Class SheetsControl
    Public Overrides Sub Connect(gapi As GoogleAPI)
        MyBase.Connect(gapi)
        cmbSpreadSheets.Enabled = True
        cmbSpreadSheets.DisplayMember = "Name"
        cmbSpreadSheets.ValueMember = "Id"
        cmbSpreadSheets.DataSource = gapi.GetSpreadsheets()
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        FillWithRandomData()
    End Sub

    Private Sub FillWithRandomData()
        Dim rnd As New Random()
        Dim cols = rnd.Next(10, 20)
        Dim rows = rnd.Next(30, 50)
        For i = 0 To cols - 1
            dgvSpreadSheet.Columns.Add(New DataGridViewTextBoxColumn With
                                       {
                                       .HeaderText = $"{ChrW(i + 65)}"
                                       })
        Next
        For i = 0 To rows - 1
            dgvSpreadSheet.Rows.Add()
            For Each cell As DataGridViewCell In dgvSpreadSheet.Rows(i).Cells
                cell.Value = rnd.Next(100, 999)
            Next
        Next
    End Sub

    Private Sub btnFillIn_Click(sender As Object, e As EventArgs) Handles btnFillIn.Click
        Dim spreadSheetId = cmbSpreadSheets.SelectedValue
        Dim range = $"{cmbSheets.SelectedValue.Properties.Title}!A1"
        Gapi.Export(dgvSpreadSheet, spreadSheetId, range)
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
        lblSheets.Enabled = True
        btnFillIn.Enabled = True
        btnRead.Enabled = True
    End Sub

    Private Sub cmbSpreadSheets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSpreadSheets.SelectedIndexChanged
        cmbSheets.Enabled = True
        lblSheets.Enabled = True
        cmbSheets.DisplayMember = "Title"
        cmbSheets.ValueMember = "Sheet"
        cmbSheets.DataSource = gapi.GetSheets(cmbSpreadSheets.SelectedValue.ToString())
    End Sub
End Class
