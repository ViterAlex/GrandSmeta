Imports System.Runtime.CompilerServices
Module Helpers
    <Extension>
    Public Sub Print(text As String, color As ConsoleColor)
        Console.ForegroundColor = color
        Console.WriteLine(text)
        Console.ResetColor()
    End Sub

    Public Sub Print(lines As IEnumerable(Of String), color As ConsoleColor)
        Console.ForegroundColor = color
        For Each line In lines
            Console.WriteLine(line)
        Next
        Console.ResetColor()
    End Sub
End Module
