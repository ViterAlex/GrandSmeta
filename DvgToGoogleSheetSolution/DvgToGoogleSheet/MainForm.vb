Imports System.IO

Public Class MainForm

#Region "Fields"

    Private Const CREDENTIALS As String = "cred.json"
    Private gapi As GoogleAPI

#End Region

#Region "Private Methods"

    'Подключение
    Private Async Sub btnConnect_Click(sender As Object, e As EventArgs) Handles ConnectToolStripMenuItem.Click
        If Not File.Exists(CREDENTIALS) Then
            MessageBox.Show($"File '{CREDENTIALS}' not found. Place it next to executable!", "Google API", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Dim token = File.ReadAllText(CREDENTIALS)
        gapi = New GoogleAPI(token)
        Dim result = Await gapi.Connect()
        cmbSpreadSheets.Enabled = result
        lblSheets.Enabled = result
        If result Then
            'Включаем нужные контролы, задаём текст и т.д.
            lblConnectionStatus.Text = "Connected"
            txtScriptId.Enabled = True
            btnGetSource.Enabled = True

            'В выпадающий список выводим список доступных книг
            cmbSpreadSheets.DisplayMember = "Name"
            cmbSpreadSheets.ValueMember = "Id"
            cmbSpreadSheets.DataSource = gapi.GetSpreadsheets()
        End If

    End Sub

    'Заполнение таблицы данными из выбранного листа книги
    Private Sub btnFillIn_Click(sender As Object, e As EventArgs) Handles btnFillIn.Click
        Dim spreadSheetId = cmbSpreadSheets.SelectedValue
        Dim range = $"{cmbSheets.SelectedValue.Properties.Title}!A1"
        gapi.Export(dgvSpreadSheet, spreadSheetId, range)
    End Sub

    'Заполнение списка с файлами исходников
    Private Sub btnGetSource_Click(sender As Object, e As EventArgs) Handles btnGetSource.Click
        Dim files = gapi.GetSourceCodeFiles(txtScriptId.Text)
        If files Is Nothing OrElse files.Count = 0 Then
            Return
        End If
        cmbSourceFiles.Enabled = True
        cmbFunctions.Enabled = True
        cmbVersions.Enabled = True
        btnSave.Enabled = True
        Dim selSourceIndex = cmbSourceFiles.SelectedIndex
        cmbSourceFiles.DisplayMember = "Name"
        cmbSourceFiles.ValueMember = "File"
        cmbSourceFiles.DataSource = files

        If selSourceIndex <> -1 Then
            cmbSourceFiles.SelectedIndex = selSourceIndex
        End If

        Dim versions = gapi.GetVersions(txtScriptId.Text)
        cmbVersions.DisplayMember = "VersionNumber"
        cmbVersions.DataSource = versions
    End Sub

    'Чтение листа из книги
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

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        gapi.RunScript(cmbFunctions.SelectedValue.Name, txtScriptId.Text, GetParams())
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        gapi.UpdateSourceFiles(txtScriptId.Text, cmbSourceFiles.SelectedItem.Name, ChangeLineEndings(txtSource.Text, vbCrLf, vbLf))
        btnGetSource_Click(btnGetSource, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Замена символов перевода строки.
    ''' </summary>
    ''' <param name="text">Текст, в котором нужно заменить окончания строк.</param>
    ''' <param name="[from]">Какое символ новой строки нужно заменить.</param>
    ''' <param name="[to]">На какой символ троки нужно заменить</param>
    ''' <remarks>В скриптах Google используется LF, а <see cref="TextBox"/> умеет правильно обрабатывать только CRLF</remarks>
    ''' <returns>Возвращает строку с заменёнными символами новой строки</returns>
    Private Function ChangeLineEndings(text As String, Optional [from] As String = vbLf, Optional [to] As String = vbCrLf) As String
        Return text.Replace([from], [to])
    End Function

    'Обработка выбор фукции из файла
    Private Sub cmbFunctions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFunctions.SelectedIndexChanged
        FillParams()
        Dim item = cmbFunctions.SelectedItem
        If item IsNot Nothing Then
            Dim index = txtSource.Text.IndexOf($"function {item.Name}")
            If index = -1 Then
                Return
            End If
            txtSource.SelectionStart = index
            txtSource.ScrollToCaret()
        End If
    End Sub

    'Обработка выбор листа в книге
    Private Sub cmbSheets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSheets.SelectedIndexChanged
        lblSheets.Enabled = True
        btnFillIn.Enabled = True
        btnRead.Enabled = True
    End Sub

    'Обработка выбора исходного файла
    Private Sub cmbSourceFiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSourceFiles.SelectedIndexChanged
        txtSource.Text = ChangeLineEndings(cmbSourceFiles.SelectedValue.Source.ToString())

        Dim funcs = gapi.GetFunctions(cmbSourceFiles.SelectedValue)

        btnRun.Enabled = funcs IsNot Nothing AndAlso funcs.Count > 0
        cmbFunctions.DisplayMember = "Name"
        cmbFunctions.DataSource = funcs
    End Sub

    'Обработка выбора книги
    Private Sub cmbSpreadSheets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSpreadSheets.SelectedIndexChanged
        cmbSheets.Enabled = True
        lblSheets.Enabled = True
        cmbSheets.DisplayMember = "Title"
        cmbSheets.ValueMember = "Sheet"
        cmbSheets.DataSource = gapi.GetSheets(cmbSpreadSheets.SelectedValue.ToString())
    End Sub

    Private Sub cmbVersions_Format(sender As Object, e As ListControlConvertEventArgs) Handles cmbVersions.Format
        e.Value = $"v.{e.Value} {e.ListItem.Description}"
    End Sub

    'Заполнение DataGridView случайными данными
    Private Sub FillDataGridView()
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

    'Заполняем таблицу параметров выбранной функции
    Private Sub FillParams()
        Dim parameters As List(Of String)

        If cmbFunctions.SelectedValue Is Nothing Then
            dgvParams.DataSource = Nothing
            Return
        End If

        parameters = cmbFunctions.SelectedValue.Parameters

        If parameters Is Nothing Then
            dgvParams.DataSource = Nothing
            Return
        End If
        dgvParams.DataSource = parameters.Select(Function(s)
                                                     Return New With {.Param = s, .Value = ""}
                                                 End Function).ToList()
    End Sub

    ''' <summary>
    ''' Получить параметры из таблицы параметров.
    ''' </summary>
    ''' <returns></returns>
    Private Function GetParams() As String()
        If dgvParams.DataSource Is Nothing Then
            Return New String() {}
        End If
        Return dgvParams.Rows _
            .Cast(Of DataGridViewRow) _
            .Select(Function(r)
                        Return r.Cells(1).Value.ToString()
                    End Function) _
                    .ToArray()
    End Function

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
        FillDataGridView()
    End Sub

#End Region

End Class