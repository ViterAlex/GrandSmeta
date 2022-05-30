Imports WordTools

<TestClass()> Public Class ProcessDocxTest

#Region "Public Methods"

    <TestMethod()>
    Public Sub Count_Equals_1244_Test()
        Dim file = IO.Path.GetFullPath("SampleDocs\doc_1244.docx")
        Dim n = WordTool.ProcessDocx(file)
        Assert.IsTrue(n = 1244, $"n={n}")
    End Sub

    <TestMethod()>
    Public Sub Count_Equals_8293551_Test()
        Dim file = IO.Path.GetFullPath("SampleDocs\doc_829351.docx")
        Dim n = WordTool.ProcessDocx(file)
        Assert.IsTrue(n = 829351, $"n={n}")
    End Sub

    <TestMethod()>
    Public Sub Count_EndnoteFootnote_Equals_23_Test()
        Dim file = IO.Path.GetFullPath("SampleDocs\doc_footnote_endnote_23.docx")
        Dim n = WordTool.ProcessDocx(file)
        Assert.IsTrue(n = 23, $"n={n}")
    End Sub

    <TestMethod()>
    Public Sub Count_Caption_Equals_27_Test()
        Dim file = IO.Path.GetFullPath("SampleDocs\doc_caption_27.docx")
        Dim n = WordTool.ProcessDocx(file)
        Assert.IsTrue(n = 27, $"n={n}")
    End Sub

    <TestMethod()>
    Public Sub Count_Fields_Equals_6_Test()
        Dim file = IO.Path.GetFullPath("SampleDocs\doc_fields_6.docx")
        Dim n = WordTool.ProcessDocx(file)
        Assert.IsTrue(n = 6, $"n={n}")
    End Sub

    <TestMethod()>
    Public Sub Count_TableHeader_Equals_8311_Test()
        Dim file = IO.Path.GetFullPath("SampleDocs\doc_table_header_8311.docx")
        Dim n = WordTool.ProcessDocx(file)
        Assert.IsTrue(n = 8311, $"n={n}")
    End Sub

    <TestMethod()>
    Public Sub Count_Table_Equals_8311_Test()
        Dim file = IO.Path.GetFullPath("SampleDocs\doc_table_8311.docx")
        Dim n = WordTool.ProcessDocx(file)
        Assert.IsTrue(n = 8311, $"n={n}")
    End Sub

    <TestMethod()>
    Public Sub Count_NoOpenXml_Equals_8311_Test()
        Dim file = IO.Path.GetFullPath("SampleDocs\doc_8311.doc")
        Dim t = Type.GetTypeFromProgID("Word.Application")
        Dim wdApp As Object = Activator.CreateInstance(t)
        Dim wdDoc As Object
        wdDoc = wdApp.Documents.Open(file, AddToRecentFiles:=False)
        Dim n = WordTool.ProcessDocFile(wdDoc)
        wdApp.Quit(False)
        Assert.IsTrue(n = 8311, $"n={n}")
    End Sub

#End Region

End Class