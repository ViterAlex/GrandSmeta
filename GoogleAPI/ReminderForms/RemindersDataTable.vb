Partial Public Class RemindersDataTable
    Inherits DataTable

    Private _IdColumn As DataColumn
    Private _TitleColumn As DataColumn
    Private _RemindAtColumn As DataColumn
    Private _CreatedAtColumn As DataColumn
    Private _DoneColumn As DataColumn
    Private _AllDayColumn As DataColumn

    Public Shadows Event RowChanged As EventHandler(Of ReminderRowChangeEventArgs)

    Public Shadows Event RowChanging As EventHandler(Of ReminderRowChangeEventArgs)

    Public Shadows Event RowDeleting As EventHandler(Of ReminderRowChangeEventArgs)

    Public Shadows Event RowDeleted As EventHandler(Of ReminderRowChangeEventArgs)

    Protected Overrides Sub OnRowChanged(e As DataRowChangeEventArgs)
        MyBase.OnRowChanged(e)
        Dim row = DirectCast(e.Row, ReminderDataRow)
        RaiseEvent RowChanged(Me, New ReminderRowChangeEventArgs(row, e.Action))
    End Sub

    Protected Overrides Sub OnRowChanging(e As DataRowChangeEventArgs)
        MyBase.OnRowChanging(e)
        Dim row = DirectCast(e.Row, ReminderDataRow)
        RaiseEvent RowChanging(Me, New ReminderRowChangeEventArgs(row, e.Action))
    End Sub

    Protected Overrides Sub OnRowDeleting(e As DataRowChangeEventArgs)
        MyBase.OnRowDeleting(e)
        Dim row = DirectCast(e.Row, ReminderDataRow)
        RaiseEvent RowChanged(Me, New ReminderRowChangeEventArgs(row, e.Action))
    End Sub

    Protected Overrides Sub OnRowDeleted(e As DataRowChangeEventArgs)
        MyBase.OnRowDeleted(e)
        Dim row = DirectCast(e.Row, ReminderDataRow)
        RaiseEvent RowChanged(Me, New ReminderRowChangeEventArgs(row, e.Action))
    End Sub

    Default Public ReadOnly Property Item(ByVal index As Integer) As ReminderDataRow
        Get
            Return DirectCast(Rows(index), ReminderDataRow)
        End Get
    End Property

    Public ReadOnly Property IdColumn() As DataColumn
        Get
            Return _IdColumn
        End Get
    End Property

    Public ReadOnly Property TitleColumn() As DataColumn
        Get
            Return _TitleColumn
        End Get
    End Property

    Public ReadOnly Property RemindAtColumn() As DataColumn
        Get
            Return _RemindAtColumn
        End Get
    End Property

    Public ReadOnly Property CreatedAtColumn() As DataColumn
        Get
            Return _CreatedAtColumn
        End Get
    End Property

    Public ReadOnly Property DoneColumn() As DataColumn
        Get
            Return _DoneColumn
        End Get
    End Property

    Public ReadOnly Property AllDayColumn() As DataColumn
        Get
            Return _AllDayColumn
        End Get
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            Return Rows.Count
        End Get
    End Property

    Public Sub Add(row As ReminderDataRow)
        Rows.Add(row)
    End Sub

    Public Sub Remove(row As ReminderDataRow)
        Rows.Remove(row)
    End Sub

    Public Overrides Function Clone() As DataTable
        Dim cln = DirectCast(MyBase.Clone(), RemindersDataTable)
        cln.InitVars()
        Return cln
    End Function

    Private Sub InitVars()
        _IdColumn = Columns("Id")
        _TitleColumn = Columns("Title")
        _RemindAtColumn = Columns("RemindAt")
        _CreatedAtColumn = Columns("CreatedAt")
        _DoneColumn = Columns("Done")
        _AllDayColumn = Columns("AllDay")
    End Sub

    Protected Overrides Function GetRowType() As Type
        Return GetType(ReminderDataRow)
    End Function

    Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
        Return New ReminderDataRow(builder)
    End Function

    Public Sub New()
        TableName = "Reminders"
        BeginInit()
        InitClass()
        EndInit()
    End Sub

    Public Function FindById(id As String) As ReminderDataRow
        Return Rows.Find(id)
    End Function

    Protected Overrides Function CreateInstance() As DataTable
        Return New RemindersDataTable()
    End Function

    Public Overloads Function NewRow() As ReminderDataRow
        Return DirectCast(MyBase.NewRow, ReminderDataRow)
    End Function

    Private Sub InitClass()
        _IdColumn = New DataColumn("Id", GetType(String)) With {.DefaultValue = -1, .Unique = True}
        Columns.Add(_IdColumn)
        _TitleColumn = New DataColumn("Title", GetType(String))
        Columns.Add(_TitleColumn)
        _RemindAtColumn = New DataColumn("RemindAt", GetType(DateTimeOffset))
        Columns.Add(_RemindAtColumn)
        _CreatedAtColumn = New DataColumn("CreatedAt", GetType(DateTimeOffset))
        Columns.Add(_CreatedAtColumn)
        _DoneColumn = New DataColumn("Done", GetType(Boolean)) With {.DefaultValue = False}
        Columns.Add(_DoneColumn)
        _AllDayColumn = New DataColumn("AllDay", GetType(Boolean)) With {.DefaultValue = False}
        Columns.Add(_AllDayColumn)
    End Sub

End Class