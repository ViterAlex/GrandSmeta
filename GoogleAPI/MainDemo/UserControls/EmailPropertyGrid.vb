Imports EmailLib

Public Class EmailPropertyGrid
    Inherits PropertyGrid

#Region "Private Fields"

    Private ReadOnly btnClear As New ToolStripButton("Очистить папки", Nothing, AddressOf ClearFolders)

    Private ReadOnly btnTest As New ToolStripButton("Тест", Nothing, AddressOf TestConnection) With {
        .Alignment = ToolStripItemAlignment.Right
    }

    Private ReadOnly lblTest As New ToolStripLabel(String.Empty) With {
        .Alignment = ToolStripItemAlignment.Right
    }

    Private _accounts As Account

#End Region

#Region "Public Constructors"

    Public Sub New()
        PropertySort = PropertySort.Categorized
        'Скрыть стандартные кнопки PropertyGrid. Добавить свою для сброса списка папок
        Dim ts = Controls.OfType(Of ToolStrip)().FirstOrDefault()
        If ts IsNot Nothing Then
            'Скрываем стандартные кнопки
            For Each ctrl As ToolStripItem In ts.Items
                ctrl.Visible = False
            Next
            'Добавляем свою
            ts.Items.AddRange({btnClear, lblTest, btnTest})
        End If
        SelectedObject = Accounts
    End Sub

#End Region

#Region "Public Properties"

    Public Property Accounts() As Account
        Get
            Return _accounts
        End Get
        Set
            _accounts = Value
            SelectedObject = _accounts
        End Set
    End Property

#End Region

#Region "Private Methods"

    Private Sub ClearFolders(sender As Object, e As EventArgs)
        Accounts.ResetFolders = True
        Accounts.Inbox = String.Empty
        Accounts.JunkMail = String.Empty
        SelectedObject = Nothing
        SelectedObject = Accounts
    End Sub

    Private Async Sub TestConnection(sender As Object, e As EventArgs)
        lblTest.Text = "⏱"
        lblTest.ForeColor = Color.Black
        btnTest.Enabled = False
        If Await Email.Test(Accounts) Then
            lblTest.Text = "✔"
            lblTest.ForeColor = Color.DarkGreen
        Else
            lblTest.Text = "✖"
            lblTest.ForeColor = Color.DarkRed
        End If
        btnTest.Enabled = True
    End Sub

#End Region

#Region "Protected Methods"

    Protected Overrides Sub OnPropertyValueChanged(e As PropertyValueChangedEventArgs)
        MyBase.OnPropertyValueChanged(e)
        lblTest.Text = String.Empty
    End Sub

    Protected Overrides Sub OnSelectedObjectsChanged(e As EventArgs)
        MyBase.OnSelectedObjectsChanged(e)
        btnClear.Visible = SelectedObject IsNot Nothing
        btnTest.Visible = SelectedObject IsNot Nothing
        lblTest.Text = String.Empty
    End Sub

#End Region

End Class