Imports System.Runtime.InteropServices
Imports System.Text

Public Class NativeMethods
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Shared Function DragQueryFile(HDROP As IntPtr, UINT As UInteger,
                                         <MarshalAs(UnmanagedType.LPStr)> lpStr As StringBuilder,
                                         ch As UInteger) As UInteger

    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Shared Function CreatePopupMenu()

    End Function
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Shared Function InsertMenuItem(ByVal hMenu As IntPtr, ByVal uItem As Integer,
   ByVal fByPosition As Boolean, ByRef lpmii As MENUITEMINFO) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Shared Function SetMenuItemBitmaps(hMenu As IntPtr, uPosition As UInteger, uFlags As UInteger,
                                              hBitmapUnchecked As IntPtr, hBitmapChecked As IntPtr) As Boolean

    End Function
    <DllImport("shell32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Shared Sub SHChangeNotify(wEventId As Integer, uFlags As UInteger, dwItem1 As IntPtr, dwItem2 As IntPtr)

    End Sub

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Shared Function PostMessage(hWnd As IntPtr, <MarshalAs(UnmanagedType.U4)> msg As UInteger,
                                       wParam As IntPtr, lParam As IntPtr) As Boolean

    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Shared Function FindWindow(lpClassName As String, lpWindowName As String) As IntPtr

    End Function

    Public Const SHCNE_ASSOCCHANGED As Integer = &H8000000

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    Public Structure MENUITEMINFO
        Public Shared cbSize As Int32 = Marshal.SizeOf(GetType(MENUITEMINFO))
        Public Shared fMask As MIIM
        Public Shared fType As UInt32
        Public Shared fState As UInt32
        Public Shared wID As UInt32
        Public Shared hSubMenu As IntPtr
        Public Shared hbmpChecked As IntPtr
        Public Shared hbmpUnchecked As IntPtr
        Public Shared dwItemData As IntPtr
        Public Shared dwTypeData As String = Nothing
        Public Shared cch As UInt32
        Public Shared hbmpItem As IntPtr
    End Structure

    <Flags>
    Enum MIIM
        BITMAP = &H80
        CHECKMARKS = &H8
        DATA = &H20
        FTYPE = &H100
        ID = &H2
        STATE = &H1
        [STRING] = &H40
        SUBMENU = &H4
        TYPE = &H10
    End Enum
End Class
