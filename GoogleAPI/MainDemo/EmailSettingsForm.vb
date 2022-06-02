Imports System.Text.RegularExpressions
Imports EmailLib

Public Class EmailSettingsForm

#Region "Private Fields"

    Private lastSelectedNodeIndex As Integer

#End Region

#Region "Public Properties"

    Public Property Accounts() As Accounts

#End Region

#Region "Private Methods"

    Private Sub BuildUp()
        tvwNames.Nodes.Clear()
        For Each s In Accounts
            tvwNames.Nodes.Add(s.Name)
        Next
        lblDeleteAccount.Visible = tvwNames.Nodes.Count > 0
    End Sub

    Private Sub EmailPropertyGrid1_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles EmailPropertyGrid1.PropertyValueChanged
        'При смене имени обновляем его в дереве
        If e.ChangedItem.PropertyDescriptor.Name = "Name" Then
            BuildUp()
        End If
    End Sub

    Private Function GetNewName() As String
        Dim count = Accounts.AsEnumerable().Count(Function(s)
                                                      Return Regex.IsMatch(s.Name, "Email(\d+)")
                                                  End Function)
        Return $"Email{count + 1:00}"
    End Function

    Private Sub lblAddAccount_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblAddAccount.LinkClicked
        Accounts.Add(New Account With {
                     .Name = GetNewName(),
                     .Port = 993
                     })
        BuildUp()
        tvwNames.SelectedNode = tvwNames.Nodes(tvwNames.Nodes.Count - 1)
    End Sub

    Private Sub lblDeleteAccount_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblDeleteAccount.LinkClicked
        'При удалении из списка выбираем или последний элемент дерева или следующий за удалённым
        Dim indexAfterDelete As Integer
        If lastSelectedNodeIndex = Accounts.Count - 1 Then
            indexAfterDelete = lastSelectedNodeIndex - 1
        Else
            indexAfterDelete = lastSelectedNodeIndex
        End If
        Accounts.RemoveAt(lastSelectedNodeIndex)
        BuildUp()
        If indexAfterDelete = -1 Then
            EmailPropertyGrid1.Accounts = Nothing
            Return
        End If
        tvwNames.SelectedNode = tvwNames.Nodes(indexAfterDelete)
    End Sub

    Private Sub tvwAccounts_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwNames.AfterSelect
        lastSelectedNodeIndex = tvwNames.SelectedNode.Index
        EmailPropertyGrid1.Accounts = Accounts(lastSelectedNodeIndex)
    End Sub

#End Region

#Region "Protected Methods"

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        BuildUp()
        If tvwNames.Nodes.Count > 0 Then
            tvwNames.SelectedNode = tvwNames.Nodes(0)
        End If
    End Sub

#End Region

End Class