Imports WordTools

<TestClass()> Public Class CharactersWithoutSpacesTest

#Region "Public Methods"

    <TestMethod()>
    Public Sub CleanDocumentTest()
        Dim file = IO.Path.GetFullPath("SampleDocs\doc_1244.docx")
        Dim n = WordTool.CharactersWithoutSpaces(file)
        Assert.IsTrue(n = 1244, $"n={n}")
    End Sub

    <TestMethod()>
    Public Sub CleanLargeDocumentTest()
        Dim file = IO.Path.GetFullPath("SampleDocs\doc_829351.docx")
        Dim n = WordTool.CharactersWithoutSpaces(file)
        Assert.IsTrue(n = 829351, $"n={n}")
    End Sub

    <TestMethod()>
    Public Sub Doc8CharactersTest()
        Dim file = IO.Path.GetFullPath("SampleDocs\doc_footnote_endnote_23.docx")
        Dim n = WordTool.CharactersWithoutSpaces(file)
        Assert.IsTrue(n = 23, $"n={n}")
    End Sub

    <TestMethod()>
    Public Sub DocumentWithCaptionTest()
        Dim file = IO.Path.GetFullPath("SampleDocs\doc_caption_27.docx")
        Dim n = WordTool.CharactersWithoutSpaces(file)
        Assert.IsTrue(n = 27, $"n={n}")
    End Sub

    <TestMethod()>
    Public Sub DocumentWithFieldsTest()
        Dim file = IO.Path.GetFullPath("SampleDocs\doc_fields_6.docx")
        Dim n = WordTool.CharactersWithoutSpaces(file)
        Assert.IsTrue(n = 6, $"n={n}")
    End Sub

    <TestMethod()>
    Public Sub DocumentWithHeadersTest()
        Dim file = IO.Path.GetFullPath("SampleDocs\doc_table_header_8311.docx")
        Dim n = WordTool.CharactersWithoutSpaces(file)
        Assert.IsTrue(n = 8311, $"n={n}")
    End Sub

    <TestMethod()>
    Public Sub DocumentWithTablesTest()
        Dim file = IO.Path.GetFullPath("SampleDocs\doc_table_8311.docx")
        Dim n = WordTool.CharactersWithoutSpaces(file)
        Assert.IsTrue(n = 8311, $"n={n}")
    End Sub
    <TestMethod()>
    Public Sub DocFileTest()
        Dim file = IO.Path.GetFullPath("SampleDocs\doc_8311.doc")
        Dim n = WordTool.CharactersWithoutSpaces(file)
        Assert.IsTrue(n = 8311, $"n={n}")
    End Sub

#End Region

End Class