Imports System.IO
Imports WordTools

Public Class MainForm

#Region "Private Methods"

    Private Async Sub btnAsyncOpenFile_Click(sender As Object, e As EventArgs) Handles btnAsyncOpenFile.Click
        If ofd.ShowDialog <> DialogResult.OK Then
            Return
        End If
        lvwDocsInfo.Items.Clear()
        lvwDocsInfo.Visible = True
        SetupProgressBar(ofd.FileNames)
        For Each file In ofd.FileNames
            Dim n = Await WordTool.AsyncCharactersWithoutSpaces(file)
            lvwDocsInfo.Items.Add(New ListViewItem(New String() {file, n}))
            prbProcess.PerformStep()
#If DEBUG Then
            Threading.Thread.Sleep(500)
#End If
        Next
        prbProcess.Visible = False
    End Sub

    Private Sub SetupProgressBar(items() As String)
        prbProcess.Visible = True
        prbProcess.Minimum = 0
        prbProcess.Maximum = items.Count
        prbProcess.Value = prbProcess.Minimum
    End Sub

    Private Sub menuOpenFile_Click(sender As Object, e As EventArgs) Handles menuOpenFile.Click
        If ofd.ShowDialog <> DialogResult.OK Then
            Return
        End If
        Dim result = New Dictionary(Of String, Integer)
        For Each file In ofd.FileNames
            result.Add(file, WordTool.CharactersWithoutSpaces(file))
        Next
        ShowInfo(result)
    End Sub

    Private Sub ShowInfo(info As Dictionary(Of String, Integer))
        If info Is Nothing OrElse info.Count = 0 Then
            Return
        End If
        lvwDocsInfo.Items.Clear()
        lvwDocsInfo.Visible = True
        For Each kvp In info
            lvwDocsInfo.Items.Add(New ListViewItem(New String() {kvp.Key, kvp.Value}))
        Next
    End Sub

#End Region

End Class