Imports System.Runtime.InteropServices
Imports Microsoft.Win32

Public Class ShellExtension
    Implements IShellExtInit, IContextMenu

    <ComRegisterFunction>
    Public Shared Sub RegisterServer(type As Type)
        'Dim approved = String.Empty
        'Dim contextMenu = String.Empty
        'Dim root = Registry.LocalMachine
        'Dim rk = root.OpenSubKey("\SOFTWARE\Classes\*\shellex\ContextMenuHandlers\WordToolsShell")
        'rk.SetValue(type.GUID.ToString("B"), "docx")
    End Sub

    <ComUnregisterFunction>
    Public Shared Sub UnregisterServer(type As Type)

    End Sub
    Public Function Initialize(pidFolder As IntPtr, lpdobj As IntPtr, hKeyProgID As UInteger) As Integer Implements IShellExtInit.Initialize
        Throw New NotImplementedException()
    End Function

    Public Function QueryContextMenu(hmenu As UInteger, iMenu As UInteger, idCmdFirst As Integer, idCmdLast As Integer, uFlags As UInteger) As Object Implements IContextMenu.QueryContextMenu
        Throw New NotImplementedException()
    End Function

    Public Sub InvokeCommand(pici As IntPtr) Implements IContextMenu.InvokeCommand
        Throw New NotImplementedException()
    End Sub

    Public Function GetCommandString(idCmd As Integer, uFlags As UInteger, pwPreserved As Integer, <MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=4)> <Out> pszName As Byte, cchMax As UInteger) As Object Implements IContextMenu.GetCommandString
        Throw New NotImplementedException()
    End Function
End Class
