﻿Imports System.IO
Imports WordTools

Public Class MainForm

#Region "Fields"

    'Допустимые расширения файлов
    Private permitted As String() = New String() {"*.docx", "*.docm", "*.dotx", "*.dotm"}

#End Region

#Region "Private Methods"

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

    Private Async Sub btnAsyncOpenFile_Click(sender As Object, e As EventArgs) Handles btnAsyncOpenFile.Click
        If ofd.ShowDialog <> DialogResult.OK Then
            Return
        End If
        lvwDocsInfo.Items.Clear()
        lvwDocsInfo.Visible = True
        For Each file In ofd.FileNames
            Dim n = Await WordTool.AsyncCharactersWithoutSpaces(file)
            lvwDocsInfo.Items.Add(New ListViewItem(New String() {file, n}))
        Next
    End Sub

#End Region

End Class