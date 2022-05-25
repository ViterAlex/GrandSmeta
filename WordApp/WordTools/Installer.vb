Imports System.Runtime.InteropServices

<ComVisible(True)>
Public Class Installer
    Inherits System.Configuration.Install.Installer
    Public Overrides Sub Install(stateSaver As IDictionary)
        MyBase.Install(stateSaver)
        Dim regService As New RegistrationServices
        regService.RegisterAssembly(Me.GetType().Assembly, AssemblyRegistrationFlags.SetCodeBase)
    End Sub

    Public Overrides Sub Uninstall(savedState As IDictionary)
        MyBase.Uninstall(savedState)
        Dim regService As New RegistrationServices
        regService.UnregisterAssembly(Me.GetType().Assembly)
    End Sub
End Class
