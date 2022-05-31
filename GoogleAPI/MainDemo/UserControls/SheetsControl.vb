Imports SheetsAndScriptsLib

Public Class SheetsControl

    Private tableData()() As String
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
#If DEBUG Then
        FillWithRandomData()
#End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Overrides Sub Connect(gapi As GoogleAPI)
        MyBase.Connect(gapi)
        cmbSpreadSheets.Enabled = True
        cmbSpreadSheets.DisplayMember = "Name"
        cmbSpreadSheets.ValueMember = "Id"
        cmbSpreadSheets.DataSource = gapi.GetSpreadsheets()
    End Sub

    Private Sub FillWithRandomData()
        Dim rnd As New Random()
        Dim cols = rnd.Next(10, 20)
        Dim rows = rnd.Next(30, 50)
        tableData = New String(rows - 1)() {}
        For i = 0 To rows - 1
            tableData(i) = New String(cols - 1) {}
            For j = 0 To cols - 1
                tableData(i)(j) = rnd.Next(100, 999).ToString()
            Next
        Next
        dgvSpreadSheet.ColumnCount = cols
        dgvSpreadSheet.RowCount = rows
        dgvSpreadSheet.Update()
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
        Dim values = Gapi.Import(cmbSpreadSheets.SelectedValue, $"{cmbSheets.SelectedValue.Properties.Title}")
        'Считаем количество столбцов
        Dim cols = values.Max(Function(l)
                                  Return l.Count
                              End Function)
        tableData = New String(values.Count - 1)() {}
        For i = 0 To tableData.Length - 1

            tableData(i) = New String(cols - 1) {}

            Dim src As String() = values(i).ToArray()
            Array.Copy(src, tableData(i), src.Length)

        Next
        'Добавляем столбцы
        dgvSpreadSheet.ColumnCount = cols
        dgvSpreadSheet.RowCount = values.Count
        dgvSpreadSheet.Update()
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
        cmbSheets.DataSource = Gapi.GetSheets(cmbSpreadSheets.SelectedValue.ToString())
    End Sub

    Private Sub dgvSpreadSheet_CellValueNeeded(sender As Object, e As DataGridViewCellValueEventArgs) Handles dgvSpreadSheet.CellValueNeeded
        If tableData Is Nothing Then
            Return
        End If
        e.Value = tableData(e.RowIndex)(e.ColumnIndex)
    End Sub

    Private Sub dgvSpreadSheet_CellValuePushed(sender As Object, e As DataGridViewCellValueEventArgs) Handles dgvSpreadSheet.CellValuePushed
        If e.Value Is Nothing Then
            tableData(e.RowIndex)(e.ColumnIndex) = String.Empty
        Else
            tableData(e.RowIndex)(e.ColumnIndex) = e.Value.ToString()
        End If
    End Sub

    Private Sub dgvSpreadSheet_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles dgvSpreadSheet.ColumnAdded
        e.Column.HeaderText = $"{ChrW(e.Column.DisplayIndex + 65)}"
    End Sub
End Class
