Imports SheetsAndScriptsLib

Public Class BaseUC
    Protected Gapi As GoogleAPI
    Public Overridable Sub Connect(gapi As GoogleAPI)
        Me.Gapi = gapi
    End Sub
End Class
