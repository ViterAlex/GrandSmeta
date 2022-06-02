Imports System.ComponentModel
Imports System.Windows.Forms

Public Class OrderedCategoryAttribute
    Inherits CategoryAttribute
    Private Const NonPrintableChar As Char = vbTab

    ''' <summary>
    '''     Сортируемая категория в <see cref="PropertyGrid"/>.
    ''' </summary>
    ''' <param name="name">Имя категории.</param>
    ''' <param name="position">Положение при сортировке. 0-based.</param>
    ''' <param name="total">Общее количество категорий.</param>
    Public Sub New(name As String, position As Integer, total As Integer)
        MyBase.New(name.PadLeft(name.Length + total - position - 1, NonPrintableChar))
    End Sub

End Class
