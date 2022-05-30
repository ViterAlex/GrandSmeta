Imports WordTools

Public Class MainForm

#Region "Private Methods"

    Private Async Sub btnAsyncOpenFile_Click(sender As Object, e As EventArgs) Handles btnAsyncOpenFile.Click
        If ofd.ShowDialog <> DialogResult.OK Then
            Return
        End If
        Await ProcessFiles(ofd.FileNames)
    End Sub

    Private Sub ProgressChanged(sender As Object, e As ProgressInfo)
        prbProcess.Value = e.Progress
        prbProcess.Text = $"{e.StopWatch.ElapsedMilliseconds / 1000:f1} c {prbProcess.Value} из {prbProcess.Maximum} ({(prbProcess.Value / CSng(prbProcess.Maximum)):p1})"
        Dim di = e.DocInfo.Last()
        Dim n = lvwDocsInfo.Items.Count + 1
        lvwDocsInfo.Items.Add(New ListViewItem({n, di.Path, di.CharactersCount, IIf(di.IsCleared, "✔", "✖")}))
    End Sub

    Private Async Function ProcessFiles(paths As IList(Of String)) As Task
        prbProcess.Minimum = 1
        prbProcess.Maximum = paths.Count
        prbProcess.Visible = True
        lvwDocsInfo.Visible = True
        Dim pp As New Progress(Of ProgressInfo)
        AddHandler pp.ProgressChanged, AddressOf ProgressChanged
        Await WordTool.ProcessFilesAsync(paths, pp)
        prbProcess.Visible = False
    End Function

#End Region
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        If My.Application.CommandLineArgs.Count > 0 Then
            ProcessFiles(My.Application.CommandLineArgs.ToArray())
        End If
    End Sub
End Class