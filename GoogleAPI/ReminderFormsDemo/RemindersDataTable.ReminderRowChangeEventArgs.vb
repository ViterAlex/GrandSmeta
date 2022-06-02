Public Class RemindersDataTable

#Region "Public Classes"

    Public Class ReminderRowChangeEventArgs
        Inherits EventArgs

#Region "Private Fields"

        Private eventAction As DataRowAction
        Private eventRow As ReminderDataRow

#End Region

#Region "Public Constructors"

        Public Sub New(row As ReminderDataRow, action As DataRowAction)
            eventRow = row
            eventAction = action
        End Sub

#End Region

#Region "Public Properties"

        Public ReadOnly Property Action() As DataRowAction
            Get
                Return eventAction
            End Get
        End Property

        Public ReadOnly Property Row() As ReminderDataRow
            Get
                Return eventRow
            End Get
        End Property

#End Region

    End Class

#End Region

End Class