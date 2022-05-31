Imports ReminderAPI

Module MainModule

    Sub Main()
        Dim reminder = New Reminder("cred.json")
        reminder.Connect().Wait()
        reminder.Delete("client-reminder-1653635452313")
        'reminder.Create("Call Bob. 12346789", 2)
        PrettyPrint(reminder)
    End Sub


    Sub PrettyPrint(reminder As Reminder)
        Dim i = 1
        For Each r In reminder.List()
            i = i Mod 16
            Console.ForegroundColor = i
            Console.WriteLine(r)
            Console.WriteLine()
            Console.ResetColor()
            i = IIf(i = 15, 1, i + 1)
        Next
    End Sub

    Sub ClearReminders(r As Reminder)
        For Each re In r.List()
            r.Delete(r.Id)
        Next
    End Sub



End Module
