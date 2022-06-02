Public Class CalendarCell
    Inherits DataGridViewTextBoxCell

#Region "Public Constructors"

    Public Sub New()
        ' Use the short date format.
        Me.Style.Format = "dd.MM.yyyy HH:mm:ss"
    End Sub

#End Region

#Region "Public Properties"

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value.
            Return DateTimeOffset.Now
        End Get
    End Property

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing control that CalendarCell uses.
            Return GetType(CalendarEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CalendarCell contains.
            Return GetType(DateTimeOffset)
        End Get
    End Property

#End Region

#Region "Protected Methods"

    Protected Overrides Sub OnEnter(rowIndex As Integer, throughMouseClick As Boolean)
        MyBase.OnEnter(rowIndex, throughMouseClick)
        DataGridView.BeginEdit(False)
    End Sub

#End Region

#Region "Public Methods"

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer,
                        ByVal initialFormattedValue As Object,
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue,
            dataGridViewCellStyle)

        Dim ctl As CalendarEditingControl =
            CType(DataGridView.EditingControl, CalendarEditingControl)

        ' Use the default row value when Value property is null.
        If (Me.Value Is Nothing) Then
            ctl.Value = CType(Me.DefaultNewRowValue, DateTime)
        Else
            If IsDBNull(Me.Value) OrElse Me.Value Is Nothing Then
                ctl.Value = DateTime.Now
            Else
                ctl.Value = CType(Me.Value, DateTimeOffset).DateTime
            End If
        End If
        ctl.Size = Size
    End Sub

    Public Overrides Sub PositionEditingControl(setLocation As Boolean, setSize As Boolean, cellBounds As Rectangle, cellClip As Rectangle, cellStyle As DataGridViewCellStyle, singleVerticalBorderAdded As Boolean, singleHorizontalBorderAdded As Boolean, isFirstDisplayedColumn As Boolean, isFirstDisplayedRow As Boolean)
        Dim s = New Size(cellBounds.Width + 20, cellBounds.Height + 10)
        cellBounds = New Rectangle(cellBounds.Location, s)
        MyBase.PositionEditingControl(setLocation, setSize, cellBounds, cellBounds, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, isFirstDisplayedColumn, isFirstDisplayedRow)
    End Sub

#End Region

End Class