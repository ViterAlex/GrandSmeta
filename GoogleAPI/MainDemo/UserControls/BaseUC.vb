Imports SheetsAndScriptsLib

Public Class BaseUC

#Region "Protected Fields"

    Protected Gapi As GoogleAPI

#End Region

#Region "Public Methods"

    Public Overridable Sub Connect(gapi As GoogleAPI)
        Me.Gapi = gapi
    End Sub

#End Region

End Class