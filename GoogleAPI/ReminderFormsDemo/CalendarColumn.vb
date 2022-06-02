﻿Public Class CalendarColumn
    Inherits DataGridViewColumn

#Region "Public Constructors"

    Public Sub New()
        MyBase.New(New CalendarCell())
    End Sub

#End Region

#Region "Public Properties"

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a CalendarCell.
            If (value IsNot Nothing) AndAlso
                Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) _
                Then
                Throw New InvalidCastException("Must be a CalendarCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property

#End Region

End Class