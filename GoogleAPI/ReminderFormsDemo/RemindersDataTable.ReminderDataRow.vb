Partial Public Class RemindersDataTable
    Public Class ReminderDataRow
        Inherits DataRow

        Public Property Id() As String
            Get
                Return Item(NameOf(Id))
            End Get
            Set
                Item(NameOf(Id)) = Value
            End Set
        End Property

        Public Property Title() As String
            Get
                Return Item(NameOf(Title))
            End Get
            Set
                Item(NameOf(Title)) = Value
            End Set
        End Property

        Public Property RemindAt() As DateTimeOffset
            Get
                Return Item(NameOf(RemindAt))
            End Get
            Set
                Item(NameOf(RemindAt)) = Value
            End Set
        End Property

        Public Property CreatedAt() As DateTimeOffset
            Get
                Return Item(NameOf(CreatedAt))
            End Get
            Set
                Item(NameOf(CreatedAt)) = Value
            End Set
        End Property

        Public Property Done() As Boolean
            Get
                If IsDBNull(Item(NameOf(Done))) Then
                    Return False
                End If
                Return Item(NameOf(Done))
            End Get
            Set
                Item(NameOf(Done)) = Value
            End Set
        End Property

        Public Property AllDay() As Boolean
            Get
                If IsDBNull(Item(NameOf(AllDay))) Then
                    Return False
                End If
                Return Item(NameOf(AllDay))
            End Get
            Set
                Item(NameOf(AllDay)) = Value
            End Set
        End Property


        Protected Friend Sub New(builder As DataRowBuilder)
            MyBase.New(builder)
            Id = ReminderAPI.Reminder.NewId()
        End Sub
    End Class
End Class
