Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text

Module PasswordTools
    Private entropy As Byte() = Encoding.Unicode.GetBytes("Grand Smeta Email's")
    <Extension>
    Public Function ToUnsecure(text As SecureString) As String
        Dim result As String
        Dim ptr = Marshal.SecureStringToBSTR(text)
        Try
            result = Marshal.PtrToStringBSTR(ptr)
        Catch ex As Exception
        Finally
            Marshal.ZeroFreeBSTR(ptr)
        End Try
        Return result
    End Function

    <Extension>
    Public Function ToSecure(text As String) As SecureString
        Dim result = New SecureString()
        For Each ch As Char In text
            result.AppendChar(ch)
        Next
        result.MakeReadOnly()
        Return result
    End Function

    <Extension>
    Public Function ToBase64(input As SecureString) As String
        Dim bytes = Encoding.Unicode.GetBytes(input.ToUnsecure())
        Dim data = ProtectedData.Protect(bytes, entropy, DataProtectionScope.CurrentUser)
        Return Convert.ToBase64String(data)
    End Function

    <Extension>
    Public Function FromBase64(input As String) As SecureString
        Try
            Dim bytes = Convert.FromBase64String(input)
            Dim data = ProtectedData.Unprotect(bytes, entropy, DataProtectionScope.CurrentUser)
            Return Encoding.Unicode.GetString(data).ToSecure()
        Catch ex As Exception
            Return New SecureString()
        End Try
    End Function

End Module
