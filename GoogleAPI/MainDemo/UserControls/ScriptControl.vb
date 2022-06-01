Imports FastColoredTextBoxNS
Imports SheetsAndScriptsLib

Public Class ScriptControl

#Region "Private Methods"

    Private Sub btnGetProject_Click(sender As Object, e As EventArgs) Handles btnGetProject.Click
        Dim files = Gapi.GetSourceCodeFiles(txtScriptId.Text)
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

        Dim versions = Gapi.GetVersions(txtScriptId.Text)
        cmbVersions.DisplayMember = "VersionNumber"
        cmbVersions.DataSource = versions
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        Gapi.RunScript(cmbFunctions.SelectedValue.Name, txtScriptId.Text, GetParams())
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Gapi.UpdateSourceFiles(txtScriptId.Text, cmbSourceFiles.SelectedItem.Name, ChangeLineEndings(txtSource.Text, vbCrLf, vbLf))
        btnGetProject_Click(btnGetProject, EventArgs.Empty)
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

    Private Sub cmbFunctions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFunctions.SelectedIndexChanged
        FillParams()
        Dim item = cmbFunctions.SelectedItem
        If item IsNot Nothing Then
            Dim index = txtSource.Text.IndexOf($"function {item.Name}")
            If index = -1 Then
                Return
            End If
            txtSource.SelectionStart = index
            'txtSource.ScrollToCaret()
        End If
    End Sub

    Private Sub cmbSourceFiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSourceFiles.SelectedIndexChanged
        Dim si = DirectCast(cmbSourceFiles.SelectedItem, ScriptInfo)
        Select Case si.Type
            Case "JSON"
                txtSource.Language = Language.JSON
            Case "HTML"
                txtSource.Language = Language.HTML
            Case Else
                txtSource.Language = Language.JS
        End Select
        txtSource.Text = si.Source
        Dim funcs = Gapi.GetFunctions(cmbSourceFiles.SelectedItem)

        btnRun.Enabled = funcs IsNot Nothing AndAlso funcs.Count > 0
        cmbFunctions.DisplayMember = "Name"
        cmbFunctions.DataSource = funcs
    End Sub

    Private Sub cmbVersions_Format(sender As Object, e As ListControlConvertEventArgs) Handles cmbVersions.Format
        e.Value = $"v.{e.Value} {e.ListItem.Description}"
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

#End Region

#Region "Public Methods"

    Public Overrides Sub Connect(gapi As GoogleAPI)
        MyBase.Connect(gapi)
        txtScriptId.Enabled = True
        btnGetProject.Enabled = True
    End Sub

#End Region

End Class