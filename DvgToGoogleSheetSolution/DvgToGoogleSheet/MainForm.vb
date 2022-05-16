﻿Imports System.IO

Public Class MainForm
    Private Const CREDENTIALS As String = "cred.json"
    Private gapi As GoogleAPI

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        FillDataGridView()
    End Sub

    'Заполнение DataGridView случайными данными
    Private Sub FillDataGridView()
        Dim rnd As New Random()
        Dim cols = rnd.Next(10, 20)
        Dim rows = rnd.Next(30, 50)
        For i = 0 To cols - 1
            dgv.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = $"Data{i:00}"})
        Next
        For i = 0 To rows - 1
            dgv.Rows.Add()
            For Each cell As DataGridViewCell In dgv.Rows(i).Cells
                cell.Value = rnd.Next(100, 999)
            Next
        Next
    End Sub

    Private Async Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
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
            cmbSpreadSheets.DisplayMember = "Name"
            cmbSpreadSheets.ValueMember = "Id"
            cmbSpreadSheets.DataSource = gapi.GetSpreadsheets()
        End If
    End Sub

    Private Sub cmbSheets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSheets.SelectedIndexChanged
        lblFour.Enabled = True
        btnFillIn.Enabled = True
    End Sub

    Private Sub cmbSpreadSheets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSpreadSheets.SelectedIndexChanged
        cmbSheets.Enabled = True
        lblTwo.Enabled = True
        lblThree.Enabled = True
        cmbSheets.DisplayMember = "Title"
        cmbSheets.ValueMember = "Sheet"
        cmbSheets.DataSource = gapi.GetSheets(cmbSpreadSheets.SelectedValue.ToString())
    End Sub

    Private Sub btnFillIn_Click(sender As Object, e As EventArgs) Handles btnFillIn.Click
        gapi.Export(dgv, cmbSpreadSheets.SelectedValue, $"{cmbSheets.SelectedValue.Properties.Title}!A1")
    End Sub

End Class