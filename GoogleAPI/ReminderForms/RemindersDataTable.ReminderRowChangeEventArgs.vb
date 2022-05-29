Public Class RemindersDataTable
    Public Class ReminderRowChangeEventArgs
        Inherits EventArgs
        Private eventRow As ReminderDataRow
        Private eventAction As DataRowAction

        Public Sub New(row As ReminderDataRow, action As DataRowAction)
            eventRow = row
            eventAction = action
        End Sub

        Public ReadOnly Property Row() As ReminderDataRow
            Get
                Return eventRow
            End Get
        End Property

        Public ReadOnly Property Action() As DataRowAction
            Get
                Return eventAction
            End Get
        End Property

    End Class
End Class
