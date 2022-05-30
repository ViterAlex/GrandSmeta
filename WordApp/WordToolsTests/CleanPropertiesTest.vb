Imports WordTools

<TestClass()> Public Class CleanPropertiesTest

#Region "Public Methods"

    <TestMethod()>
    Public Sub CleanDocxProperties_NoException_Test()
        Dim file = IO.Path.GetFullPath("SampleDocs\doc_1244.docx")
        WordTool.ClearDocxProperties(file)
        Assert.IsTrue(True)
    End Sub

    <TestMethod()>
    Public Sub CleanDocProperties_NoException_Test()
        Dim file = IO.Path.GetFullPath("SampleDocs\doc_8311.doc")
        Dim t = Type.GetTypeFromProgID("Word.Application")
        Dim wdApp As Object = Activator.CreateInstance(t)
        Dim wdDoc As Object
        wdDoc = wdApp.Documents.Open(file, AddToRecentFiles:=False)
        WordTool.ClearDocProperties(wdDoc)
        wdDoc.Close()
        wdApp.Quit(True)
        Assert.IsTrue(True)
    End Sub


#End Region

End Class