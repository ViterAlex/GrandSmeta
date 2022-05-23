'****************************** Module Header ******************************'
' Module Name:  ShellExtLib.vb
' Project:      VBShellExtContextMenuHandler
' Copyright (c) Microsoft Corporation.
' 
' The file declares the imported Shell interfaces: IShellExtInit and 
' IContextMenu, implements the helper functions for registering and 
' unregistering a shell context menu handler, and declares the Win32 enums, 
' structs, consts, and functions used by the code sample.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************'

#Region "Imports directives"

Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports Microsoft.Win32
Imports System.Security.AccessControl

#End Region

Namespace ShellExtContextMenuHandler


#Region "Shell Interfaces"

    <ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    Guid("000214e8-0000-0000-c000-000000000046")>
    Friend Interface IShellExtInit
        Sub Initialize(
            ByVal pidlFolder As IntPtr,
            ByVal pDataObj As IntPtr,
            ByVal hKeyProgID As IntPtr)
    End Interface


    <ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    Guid("000214e4-0000-0000-c000-000000000046")>
    Friend Interface IContextMenu

        <PreserveSig()>
        Function QueryContextMenu(
        ByVal hMenu As IntPtr,
        ByVal iMenu As UInt32,
        ByVal idCmdFirst As UInt32,
        ByVal idCmdLast As UInt32,
        ByVal uFlags As UInt32) _
    As Integer

        Sub InvokeCommand(ByVal pici As IntPtr)

        Sub GetCommandString(
            ByVal idCmd As UIntPtr,
            ByVal uFlags As UInt32,
            ByVal pReserved As IntPtr,
            ByVal pszName As StringBuilder,
            ByVal cchMax As UInt32)

    End Interface

#End Region


#Region "Shell Registration"

    Friend Class ShellExtReg

        ''' <summary>
        ''' Register the context menu handler.
        ''' </summary>
        ''' <param name="clsid">The CLSID of the component.</param>
        ''' <param name="fileType">
        ''' The file type that the context menu handler is associated with. For 
        ''' example, '*' means all file types; '.txt' means all .txt files. The 
        ''' parameter must not be NULL or an empty string. 
        ''' </param>
        ''' <param name="friendlyName">Friendly name of the component</param>
        Public Shared Sub RegisterShellExtContextMenuHandler(
                        ByVal clsid As Guid,
                        ByVal fileType As String,
                        ByVal friendlyName As String)

            If clsid = Guid.Empty Then
                Throw New ArgumentException("clsid must not be empty")
            End If
            If String.IsNullOrEmpty(fileType) Then
                Throw New ArgumentException("fileType must not be null or empty")
            End If

            ' If fileType starts with '.', try to read the default value of 
            ' the HKCR\<File Type> key which contains the ProgID to which the 
            ' file type is linked.
            Dim view As RegistryView = IIf(Environment.Is64BitOperatingSystem, RegistryView.Registry64, RegistryView.Registry32)
            If (fileType.StartsWith(".")) Then
                Using hkcr As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, view)
                    Using key As RegistryKey = hkcr.OpenSubKey(fileType)
                        If (key IsNot Nothing) Then
                            ' If the key exists and its default value is not empty, 
                            ' use the ProgID as the file type.

                            ' {PL} updated to allow for custom exts
                            ' with no default value
                            Dim defaultVal As String = ""
                            If key.GetValue(Nothing) IsNot Nothing Then
                                defaultVal = key.GetValue(Nothing).ToString
                            End If
                            If (Not String.IsNullOrEmpty(defaultVal)) Then
                                fileType = defaultVal
                            End If
                        End If
                    End Using
                End Using
            End If

            ' Create the HKCR\<File Type>\shellex\ContextMenuHandlers\{<CLSID>} key.
            Dim keyName As String = $"{fileType }\shellex\ContextMenuHandlers\{clsid:B}"
            Using hkcr As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, view)
                Using key As RegistryKey = hkcr.CreateSubKey(keyName)
                    ' Set the default value of the key.
                    If ((key IsNot Nothing) AndAlso (Not String.IsNullOrEmpty(friendlyName))) Then
                        key.SetValue(Nothing, friendlyName)
                    End If
                End Using
            End Using
        End Sub


        ''' <summary>
        ''' Unregister the context menu handler.
        ''' </summary>
        ''' <param name="clsid">The CLSID of the component.</param>
        ''' <param name="fileType">
        ''' The file type that the context menu handler is associated with. For 
        ''' example, '*' means all file types; '.txt' means all .txt files. The 
        ''' parameter must not be NULL or an empty string. 
        ''' </param>
        Public Shared Sub UnregisterShellExtContextMenuHandler(ByVal clsid As Guid,
                                                               ByVal fileType As String)

            If clsid = Guid.Empty Then
                Throw New ArgumentException("clsid must not be empty")
            End If
            If String.IsNullOrEmpty(fileType) Then
                Throw New ArgumentException("fileType must not be null or empty")
            End If

            ' If fileType starts with '.', try to read the default value of 
            ' the HKCR\<File Type> key which contains the ProgID to which the 
            ' file type is linked.
            Dim view As RegistryView = IIf(Environment.Is64BitOperatingSystem, RegistryView.Registry64, RegistryView.Registry32)
            If (fileType.StartsWith(".")) Then
                Using hkcr As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, view)
                    Using key As RegistryKey = hkcr.OpenSubKey(fileType)
                        If (key IsNot Nothing) Then
                            ' If the key exists and its default value is not empty, 
                            ' use the ProgID as the file type.

                            ' {PL} updated to allow for custom exts
                            ' with no default value
                            Dim defaultVal As String = ""
                            If key.GetValue(Nothing) IsNot Nothing Then
                                defaultVal = key.GetValue(Nothing).ToString
                            End If
                            If (Not String.IsNullOrEmpty(defaultVal)) Then
                                fileType = defaultVal
                            End If
                        End If
                    End Using
                End Using
            End If

            ' Remove the HKCR\<File Type>\shellex\ContextMenuHandlers\{<CLSID>} key.
            Dim keyName As String = $"{fileType }\shellex\ContextMenuHandlers\{clsid:B}"
            Using hkcr As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, view)
                hkcr.DeleteSubKeyTree(keyName, False)
            End Using
        End Sub

        Friend Shared Function SetThreadingModel(g As Guid) As Boolean
            If g = Guid.Empty Then
                Return False
            End If

            Dim os = My.Computer.Info.OSVersion.Split("."c)
            If os(0) < 6 Then
                'Server 2003 or earlier
                Return False
            End If
            If os(0) = 6 AndAlso os(1) = 1 Then
                'Windows 7
                Return False
            End If
            Dim view As RegistryView = IIf(Environment.Is64BitOperatingSystem, RegistryView.Registry64, RegistryView.Registry32)
            Using hkcr As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, view)
                Using key As RegistryKey = hkcr.OpenSubKey($"CLSID\{{{g}}}\InprocServer32", True)
                    'need to set this key for OS starting Windows 8
                    key.SetValue("ThreadingModel", "Apartment")
                End Using
            End Using
            Return True
        End Function
    End Class

#End Region


#Region "Enums & Structs"

    Friend Enum GCS As UInt32
        GCS_VERBA = 0
        GCS_HELPTEXTA = 1
        GCS_VALIDATEA = 2
        GCS_HELPTEXTW = 5
        GCS_UNICODE = 4
        GCS_VERBW = 4
        GCS_VALIDATEW = 6
        GCS_VERBICONW = 20
    End Enum


    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Friend Structure CMINVOKECOMMANDINFO
        Public cbSize As UInt32
        Public fMask As CMIC
        Public hwnd As IntPtr
        Public verb As IntPtr
        <MarshalAs(UnmanagedType.LPStr)>
        Public parameters As String
        <MarshalAs(UnmanagedType.LPStr)>
        Public directory As String
        Public nShow As Integer
        Public dwHotKey As UInt32
        Public hIcon As IntPtr
    End Structure


    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Friend Structure CMINVOKECOMMANDINFOEX
        Public cbSize As UInt32
        Public fMask As CMIC
        Public hwnd As IntPtr
        Public verb As IntPtr
        <MarshalAs(UnmanagedType.LPStr)>
        Public parameters As String
        <MarshalAs(UnmanagedType.LPStr)>
        Public directory As String
        Public nShow As Integer
        Public dwHotKey As UInt32
        Public hIcon As IntPtr
        <MarshalAs(UnmanagedType.LPStr)>
        Public title As String
        Public verbW As IntPtr
        Public parametersW As String
        Public directoryW As String
        Public titleW As String
        Private ptInvoke As POINT
    End Structure


    <Flags()>
    Friend Enum CMIC As UInt32
        CMIC_MASK_ICON = &H10
        CMIC_MASK_HOTKEY = &H20
        CMIC_MASK_NOASYNC = &H100
        CMIC_MASK_FLAG_NO_UI = &H400
        CMIC_MASK_UNICODE = &H4000
        CMIC_MASK_NO_CONSOLE = &H8000
        CMIC_MASK_ASYNCOK = &H100000
        CMIC_MASK_NOZONECHECKS = &H800000
        CMIC_MASK_FLAG_LOG_USAGE = &H4000000
        CMIC_MASK_SHIFT_DOWN = &H10000000
        CMIC_MASK_PTINVOKE = &H20000000
        CMIC_MASK_CONTROL_DOWN = &H40000000
    End Enum


    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Public Structure POINT
        Public X As Integer
        Public Y As Integer
    End Structure


    Friend Enum CLIPFORMAT As UInt32
        CF_TEXT = 1
        CF_BITMAP = 2
        CF_METAFILEPICT = 3
        CF_SYLK = 4
        CF_DIF = 5
        CF_TIFF = 6
        CF_OEMTEXT = 7
        CF_DIB = 8
        CF_PALETTE = 9
        CF_PENDATA = 10
        CF_RIFF = 11
        CF_WAVE = 12
        CF_UNICODETEXT = 13
        CF_ENHMETAFILE = 14
        CF_HDROP = 15
        CF_LOCALE = &H10
        CF_MAX = &H11

        CF_OWNERDISPLAY = &H80
        CF_DSPTEXT = &H81
        CF_DSPBITMAP = &H82
        CF_DSPMETAFILEPICT = &H83
        CF_DSPENHMETAFILE = &H8E

        CF_PRIVATEFIRST = &H200
        CF_PRIVATELAST = &H2FF

        CF_GDIOBJFIRST = &H300
        CF_GDIOBJLAST = &H3FF
    End Enum


    <Flags()>
    Friend Enum CMF
        CMF_NORMAL = 0
        CMF_DEFAULTONLY = 1
        CMF_VERBSONLY = 2
        CMF_EXPLORE = 4
        CMF_NOVERBS = 8
        CMF_CANRENAME = &H10
        CMF_NODEFAULT = &H20
        CMF_INCLUDESTATIC = &H40
        CMF_ITEMMENU = &H80
        CMF_EXTENDEDVERBS = &H100
        CMF_DISABLEDVERBS = &H200
        CMF_ASYNCVERBSTATE = &H400
        CMF_OPTIMIZEFORINVOKE = &H800
        CMF_SYNCCASCADEMENU = &H1000
        CMF_DONOTPICKDEFAULT = &H2000
        CMF_RESERVED = &HFFFF0000
    End Enum


    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Friend Structure MENUITEMINFO
        Public cbSize As UInt32
        Public fMask As MIIM
        Public fType As MFT
        Public fState As MFS
        Public wID As UInt32
        Public hSubMenu As IntPtr
        Public hbmpChecked As IntPtr
        Public hbmpUnchecked As IntPtr
        Public dwItemData As UIntPtr
        <MarshalAs(UnmanagedType.LPTStr)>
        Public dwTypeData As String
        Public cch As UInt32
        Public hbmpItem As IntPtr
    End Structure


    <Flags()>
    Friend Enum MIIM As UInt32
        MIIM_STATE = 1
        MIIM_ID = 2
        MIIM_SUBMENU = 4
        MIIM_CHECKMARKS = 8
        MIIM_TYPE = &H10
        MIIM_DATA = &H20
        MIIM_STRING = &H40
        MIIM_BITMAP = &H80
        MIIM_FTYPE = &H100
    End Enum


    Friend Enum MFT As UInt32
        MFT_STRING = 0
        MFT_BITMAP = 4
        MFT_MENUBARBREAK = &H20
        MFT_MENUBREAK = &H40
        MFT_OWNERDRAW = &H100
        MFT_RADIOCHECK = &H200
        MFT_SEPARATOR = &H800
        MFT_RIGHTORDER = &H2000
        MFT_RIGHTJUSTIFY = &H4000
    End Enum


    Friend Enum MFS As UInt32
        MFS_ENABLED = 0
        MFS_UNCHECKED = 0
        MFS_UNHILITE = 0
        MFS_DISABLED = 3
        MFS_GRAYED = 3
        MFS_CHECKED = 8
        MFS_HILITE = &H80
        MFS_DEFAULT = &H1000
    End Enum

#End Region


    Friend Class NativeMethods

        ''' <summary>
        ''' Retrieve the names of dropped files that result from a successful 
        ''' drag-and-drop operation.
        ''' </summary>
        ''' <param name="hDrop">
        ''' Identifier of the structure that contains the file names of the 
        ''' dropped files.
        ''' </param>
        ''' <param name="iFile">
        ''' Index of the file to query. If the value of this parameter is 
        ''' 0xFFFFFFFF, DragQueryFile returns a count of the files dropped. 
        ''' </param>
        ''' <param name="pszFile">
        ''' The address of a buffer that receives the file name of a dropped 
        ''' file when the function returns.
        ''' </param>
        ''' <param name="cch">
        ''' The size, in characters, of the pszFile buffer.
        ''' </param>
        ''' <returns>A non-zero value indicates a successful call.</returns>
        <DllImport("shell32", CharSet:=CharSet.Unicode)>
        Public Shared Function DragQueryFile(ByVal hDrop As IntPtr,
                            ByVal iFile As UInt32,
                            ByVal pszFile As StringBuilder,
                            ByVal cch As Integer) As UInt32
        End Function


        ''' <summary>
        ''' Free the specified storage medium.
        ''' </summary>
        ''' <param name="pmedium">
        ''' Reference of the storage medium that is to be freed.
        ''' </param>
        <DllImport("ole32.dll", CharSet:=CharSet.Unicode)>
        Public Shared Sub ReleaseStgMedium(ByRef pmedium As STGMEDIUM)
        End Sub


        ''' <summary>
        ''' Insert a new menu item at the specified position in a menu.
        ''' </summary>
        ''' <param name="hMenu">
        ''' A handle to the menu in which the new menu item is inserted. 
        ''' </param>
        ''' <param name="uItem">
        ''' The identifier or position of the menu item before which to 
        ''' insert the new item. The meaning of this parameter depends on the 
        ''' value of fByPosition.
        ''' </param>
        ''' <param name="fByPosition">
        ''' Controls the meaning of uItem. If this parameter is false, uItem 
        ''' is a menu item identifier. Otherwise, it is a menu item position. 
        ''' </param>
        ''' <param name="mii">
        ''' A reference of a MENUITEMINFO structure that contains information 
        ''' about the new menu item.
        ''' </param>
        ''' <returns>
        ''' If the function succeeds, the return value is true.
        ''' </returns>
        <DllImport("user32", CharSet:=CharSet.Unicode, SetLastError:=True)>
        Public Shared Function InsertMenuItem(ByVal hMenu As IntPtr,
                    ByVal uItem As UInt32,
                    <MarshalAs(UnmanagedType.Bool)> ByVal fByPosition As Boolean,
                    ByRef mii As MENUITEMINFO) As <MarshalAs(UnmanagedType.Bool)> Boolean

        End Function


        ''' <summary>
        ''' The DeleteObject function deletes a logical pen, brush, font, bitmap, 
        ''' region, or palette, freeing all system resources associated with the 
        ''' object. After the object is deleted, the specified handle is no longer 
        ''' valid.
        ''' </summary>
        ''' <param name="hObject">
        ''' A handle to a logical pen, brush, font, bitmap, region, or palette.
        ''' </param>
        ''' <returns>
        ''' If the function succeeds, the return value is true.
        ''' </returns>
        ''' <remarks></remarks>
        <DllImport("gdi32.dll", CharSet:=CharSet.Unicode, SetLastError:=True)>
        Public Shared Function DeleteObject(hObject As IntPtr) As Boolean
        End Function

        Public Shared Function HighWord(ByVal number As Integer) As Integer
            Return If(((number And &H80000000) = &H80000000), (number >> &H10), ((number >> &H10) And &HFFFF))
        End Function

        Public Shared Function LowWord(ByVal number As Integer) As Integer
            Return (number And &HFFFF)
        End Function

    End Class


    Friend Class WinError

        Public Const S_OK As Integer = 0
        Public Const S_FALSE As Integer = 1
        Public Const E_FAIL As Integer = -2147467259
        Public Const E_INVALIDARG As Integer = -2147024809
        Public Const E_OUTOFMEMORY As Integer = -2147024882
        Public Const STRSAFE_E_INSUFFICIENT_BUFFER As Integer = -2147024774

        Public Const SEVERITY_ERROR As UInt32 = 1
        Public Const SEVERITY_SUCCESS As UInt32 = 0

        ''' <summary>
        ''' Create an HRESULT value from component pieces.
        ''' </summary>
        ''' <param name="sev">The severity to be used</param>
        ''' <param name="fac">The facility to be used</param>
        ''' <param name="code">The error number</param>
        ''' <returns>A HRESULT constructed from the above 3 values</returns>
        Public Shared Function MAKE_HRESULT(ByVal sev As UInt32,
                                            ByVal fac As UInt32, ByVal code As UInt32) As Integer

            Return CInt((((sev << &H1F) Or (fac << &H10)) Or code))
        End Function

    End Class

End Namespace