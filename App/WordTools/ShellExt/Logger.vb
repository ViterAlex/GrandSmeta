Imports System.IO

Public Class Logger
    Private logpath As String

    Public Sub New(path As String)
        logpath = path
    End Sub

    Public Sub Open()
        If Not Directory.Exists(logpath) Then
            Directory.CreateDirectory(Path.GetDirectoryName(logpath))
        End If
        Using sw As New StreamWriter(logpath, True)
            sw.WriteLine(New String("*", 40))
            sw.WriteLine($"{Now:G}")
        End Using
    End Sub

    Public Sub LogMethod()
        Dim st = New StackTrace()
        If st.FrameCount >= 2 Then
            Dim f = st.GetFrame(1)
            Log($"Executing {f.GetMethod().Name}")
        End If
    End Sub

    Public Sub Log(text As String)
        Using sw As New StreamWriter(logpath, True)
            sw.WriteLine($"{Now:G}{vbTab}{text}")
        End Using
    End Sub

    Friend Sub Separator()
        Using sw As New StreamWriter(logpath, True)
            sw.WriteLine(New String("*"c, 40))
        End Using
    End Sub
End Class
