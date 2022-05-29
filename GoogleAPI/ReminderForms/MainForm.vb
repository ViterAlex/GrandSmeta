Imports System.ComponentModel
Imports ReminderAPI

Public Class MainForm
    Private reminder As Reminder
    Private dt As RemindersDataTable

    Protected Overrides Async Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        reminder = New Reminder("cred.json")
        Await reminder.Connect()
        ReloadData()
        AddHandler ReminderDataGridView.RowPrePaint, AddressOf RowPrePaint
        AddHandler ReminderDataGridView.CellEndEdit, AddressOf CellEndEdit
        AddHandler ReminderDataGridView.CurrentCellDirtyStateChanged, AddressOf CurrentCellDirtyStateChanged
    End Sub

    Private Sub CurrentCellDirtyStateChanged(sender As Object, e As EventArgs)
        If ReminderDataGridView.IsCurrentCellDirty _
            AndAlso ReminderDataGridView.CurrentCell Is GetType(DataGridViewCheckBoxCell) Then
            ReminderDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
            ReminderDataGridView.EndEdit()
            Validate()
            SetRowStyle(ReminderDataGridView.CurrentCell.RowIndex)
        End If
    End Sub

    Private Sub CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
        SetRowStyle(e.RowIndex)
        ReminderBindingNavigatorSaveItem.Enabled = True
    End Sub

    Private Sub RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs)
        SetRowStyle(e.RowIndex)
    End Sub

    Private Sub SetRowStyle(index As Integer)

        Dim row As DataGridViewRow = ReminderDataGridView.Rows(index)
        Dim dbi = DirectCast(row.DataBoundItem, DataRowView)
        If row.IsNewRow _
           OrElse dbi.IsNew _
           OrElse ReminderDataGridView.CurrentRow.IsNewRow Then
            Return
        End If
        Dim dataRow As RemindersDataTable.ReminderDataRow = dbi.Row
        row.DefaultCellStyle.BackColor = IIf(dataRow.Done, Color.LightGreen, Color.Empty)
        row.DefaultCellStyle.BackColor = IIf(dataRow.Done, Color.LightGreen, Color.Empty)
    End Sub

    Private Sub ReloadData()
        dt = New RemindersDataTable()
        For Each r In Reminder.List()
            Dim row = dt.NewRow()
            row.Id = r.Id
            row.Title = r.Title
            row.RemindAt = r.RemindAt
            row.CreatedAt = r.CreatedAt
            row.Done = r.Done
            row.AllDay = r.AllDay
            dt.Add(row)
        Next
        dt.AcceptChanges()
        ReminderBindingSource.DataSource = dt
    End Sub

    Private Sub ReminderBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles ReminderBindingNavigatorSaveItem.Click

        ProcessDeleted()
        ProcessAdded()
        ProcessModified()

        dt.AcceptChanges()
        ReminderBindingNavigatorSaveItem.Enabled = False
    End Sub

    Private Sub ProcessModified()
        Dim modifiedRows = dt.Rows.Cast(Of RemindersDataTable.ReminderDataRow).
                    Where(Function(r)
                              Return r.RowState = DataRowState.Modified
                          End Function)
        For Each row In modifiedRows
            reminder.Id = row.Id
            reminder.Title = row.Title
            reminder.RemindAt = row.RemindAt
            reminder.Done = row.Done
            reminder.AllDay = row.AllDay
            reminder.CreatedAt = reminder.CreatedAt
            reminder.Update()
        Next
    End Sub

    Private Sub ProcessAdded()
        Dim addedRows = dt.Rows.Cast(Of RemindersDataTable.ReminderDataRow).
                    Where(Function(r)
                              Return r.RowState = DataRowState.Added
                          End Function)
        For Each row In addedRows
            reminder.Create(row.Title, 60, row.Id)
        Next
    End Sub

    Private Sub ProcessDeleted()
        Dim deletedIds = dt.Rows.Cast(Of RemindersDataTable.ReminderDataRow).
                    Where(Function(r)
                              Return r.RowState = DataRowState.Deleted
                          End Function).
                          Select(Function(r)
                                     Return r("Id", DataRowVersion.Original).ToString()
                                 End Function)
        For Each id In deletedIds
            reminder.Delete(id)
        Next
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ReloadData()
    End Sub

    Private Sub ReminderDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ReminderDataGridView.CellClick
        If ReminderDataGridView.CurrentCell.OwningColumn.DataPropertyName = "RemindAt" Then
            ReminderDataGridView.BeginEdit(False)
        End If
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorAddNewItem.Click, BindingNavigatorDeleteItem.Click
        ReminderBindingNavigatorSaveItem.Enabled = True
    End Sub
End Class
