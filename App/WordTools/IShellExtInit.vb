Imports System.Runtime.InteropServices

<ComImport()>
<InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
<Guid("000214e8-0000-0000-c000-000000000046")>
Public Interface IShellExtInit
    <PreserveSig>
    Function Initialize(pidFolder As IntPtr, lpdobj As IntPtr, hKeyProgID As UInteger) As Integer
End Interface
