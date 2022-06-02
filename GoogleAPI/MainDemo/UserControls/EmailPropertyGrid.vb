Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports EmailLib
''' <summary>
'''     <see cref="PropertyGrid"/> для отображения класса <see cref="EmailLib.Account"/>
''' </summary>
Public Class EmailPropertyGrid
    Inherits PropertyGrid

#Region "Private Fields"

    Private ReadOnly btnClear As New ToolStripLabel("Очистить папки", Nothing, True, AddressOf ClearFolders)

    Private ReadOnly btnTest As New ToolStripLabel("Тест", Nothing, True, AddressOf TestConnection) With {
        .Alignment = ToolStripItemAlignment.Right
    }

    Private ReadOnly lblTest As New ToolStripLabel(String.Empty) With {
        .Alignment = ToolStripItemAlignment.Right
    }

    Private _account As Account

#End Region

#Region "Public Constructors"

    Public Sub New()
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
        SelectedObject = Account
    End Sub

#End Region

#Region "Public Properties"

    <Browsable(False)>
    Public Property Account() As Account
        Get
            Return _account
        End Get
        Set
            _account = Value
            SelectedObject = _account
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property PropertySort As PropertySort
        Get
            Return PropertySort.Categorized
        End Get
        Set(value As PropertySort)
            MyBase.PropertySort = PropertySort.Categorized
        End Set
    End Property

#End Region

#Region "Private Methods"

    Private Sub ClearFolders(sender As Object, e As EventArgs)
        Account.ResetFolders = True
        Account.Inbox = String.Empty
        Account.JunkMail = String.Empty
        SelectedObject = Nothing
        SelectedObject = Account
    End Sub

    Private Async Sub TestConnection(sender As Object, e As EventArgs)
        lblTest.Text = "⏱"
        lblTest.ForeColor = Color.Black
        btnTest.Enabled = False
        If Await Email.Test(Account) Then
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