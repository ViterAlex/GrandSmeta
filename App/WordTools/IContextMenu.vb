Imports System.Runtime.InteropServices

<ComImport>
<InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
<Guid("000214e4-0000-0000-c000-000000000046")>
Public Interface IContextMenu
    <PreserveSig>
    Function QueryContextMenu(hmenu As UInteger, iMenu As UInteger, idCmdFirst As Integer, idCmdLast As Integer, uFlags As UInteger)
    <PreserveSig>
    Sub InvokeCommand(pici As IntPtr)
    <PreserveSig>
    Function GetCommandString(idCmd As Integer, uFlags As UInteger, pwPreserved As Integer, <Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=4)> pszName As Byte, cchMax As UInteger)
End Interface
